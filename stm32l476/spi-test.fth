\ spi test


\ ********** gpio interface **************
$0C          constant GPIO_PUPDR
$18          constant GPIO_BSRR
$20          constant GPIO_AFRL

: gpio-port# ( a -- n )                   \ calculate port number from pin
   #10 rshift #7 and 1-foldable ; 
: gpio-pin  ( pinNr portNr -- pin )       \ calculate PIN from pin number and port number
   #10 lshift $48000000
   or or 2-foldable ;                     \ PortA:0 .. PortH:7
: port-base ( pin -- a )                  \ extract port base address from pin
   #7 not and 1-foldable ;
: pin# ( pin -- n ) $F and 1-foldable ;

: gpio-2-bit-mask ( pin -- m )            \ generate 2 bit mask for gpio
   pin# 2* 3 swap lshift 1-foldable ;

: GPIO-BSRR ( pin -- a )                  \ calculate GPIO_BSRR reg addr from pin
   port-base $18 + 1-foldable ;
: BSRR-MASK-SET ( pin -- m )              \ calculate bsrr set mask for pin
   $f and 1 swap lshift 1-foldable ;
: BSRR-MASK-RESET ( pin -- m )            \ calculate bsrr reset mask for pin
   BSRR-MASK-SET #16 lshift 1-foldable ;
: PIN-SET ( n -- m a )                    \ calculate bsrr set mask + bsrr adr from pin
   dup BSRR-MASK-SET swap                 \ can be optimized
   port-base $18 + 1-foldable ;
: PIN-RESET ( n -- m a )                  \ calculate bsrr reset mask + bsrr adr from pin
   dup BSRR-MASK-RESET swap               
   port-base $18 + 1-foldable ;           \ can be optimized
: gpio-mode! ( mode pin -- )              \ set gpio mode for pin
   dup gpio-2-bit-mask
   swap port-base bits! ;
: af-mask  ( pin -- mask )                \ alternate function bitmask
   $7 and #2 lshift $f swap lshift 1-foldable ;
: af-reg  ( pin -- adr )                  \ alternate function register address for pin
   dup $8 and 2/ swap
   port-base GPIO_AFRL + + 1-foldable ;
: mode-af ( af pin -- )                   \ set alternate function mode
   #2 over gpio-mode!
   dup af-mask swap af-reg bits! ;
: dump-gpio-moder ( port -- )             \ dump gpio-moder from pin
   cr port-base @ 0 #15 do i u.2 space -1 +loop cr
   0 #15 do dup 3 i 2* lshift and i 2* rshift u.2 space -1 +loop  drop ;
: gpio-data ( pin -- n a )                \ get input data from pin
   dup pin# swap
   port-base $10 +  1-foldable ;

\ ********** RCC constants ***************
$40021000       constant RCC_BASE
$38 RCC_BASE or constant RCC_APB1RSTR1
  1 #14 lshift  constant RCC_APB1RSTR1_SPI2RST
$4C RCC_BASE or constant RCC_AHB2ENR
$58 RCC_BASE or constant RCC_APB1ENR1
  1 #14 lshift  constant RCC_APB1ENR1_SPI2EN
 
: RCC-GPIO-CLK! ( f port -- )              \ enable / disable gpio port clock 
   gpio-port# 1 swap lshift
   RCC_AHB2ENR  bits! ;
: rcc-spi2-ena ( -- )                     \ enable spi2 clock
   1 RCC_APB1ENR1_SPI2EN RCC_APB1ENR1 bits! ;
: rcc-spi2-reset ( -- )                   \ reset spi2 block
   1 RCC_APB1RSTR1_SPI2RST RCC_APB1RSTR1 bits! ;

$40003800 constant SPI2_BASE
$00 SPI2_BASE or constant SPI2_CR1
1 #15 lshift     constant SPI_CR1_BIDIMODE \ bidi mode halft duplex M:MOSI S:MISO
1 #14 lshift     constant SPI_CR1_BIDIOE   \ 0-bidi rx,1-bidi tx
1 #13 lshift     constant SPI_CR1_CRCEN    \ enable crc calc
1 #12 lshift     constant SPI_CR1_CRCNEXT  \ transfer next data fom tx crc reg
1 #11 lshift     constant SPI_CR1_CRCL     \ 8/16 bit crc
1 #10 lshift     constant SPI_CR1_RXONLY
1  #9 lshift     constant SPI_CR1_SSM
1  #8 lshift     constant SPI_CR1_SSI
1  #7 lshift     constant SPI_CR1_LSBFIRST \ 0-msb,1-lsb first
1  #6 lshift     constant SPI_CR1_SPE      \ SPI enable
7  #3 lshift     constant SPI_CR1_BR       \ Bitrate = fclk / ( 2^(BR+1))
1  #2 lshift     constant SPI_CR1_MSTR     \ master mode
1  #1 lshift     constant SPI_CR1_CPOL     \ clock idle polarity
1  #0 lshift     constant SPI_CR1_CPHA     \ sample on 0-first,1-second edge

$04 SPI2_BASE or constant SPI2_CR2
1 #14 lshift constant SPI_CR2_LDMA_TX
1 #13 lshift constant SPI_CR2_LDMA_RX
1 #12 lshift constant SPI_CR2_FRXTH
$f #8 lshift constant SPI_CR2_DS
1  #7 lshift constant SPI_CR2_TXEIE
1  #6 lshift constant SPI_CR2_RXNEIE
1  #5 lshift constant SPI_CR2_ERRIE
1  #4 lshift constant SPI_CR2_FRF
1  #3 lshift constant SPI_CR2_NSSP
1  #2 lshift constant SPI_CR2_SSOE
1  #1 lshift constant SPI_CR2_TXDMAEN
1  #0 lshift constant SPI_CR2_RXDMAEN

$08 SPI2_BASE or constant SPI2_SR
3 #11 lshift constant SPI_SR_FTLVL
3  #9 lshift constant SPI_SR_FRLVL
1  #8 lshift constant SPI_SR_FRE
1  #7 lshift constant SPI_SR_BSY
1  #6 lshift constant SPI_SR_OVR
1  #5 lshift constant SPI_SR_MODF
1  #4 lshift constant SPI_SR_CRCERR
1  #1 lshift constant SPI_SR_TXE
1  #0 lshift constant SPI_SR_RXNE

$0C SPI2_BASE or constant SPI2_DR
: .spi2
   hex cr
   ." spi2_cr1 " spi2_cr1 @ u. cr 
   ." spi2_cr2 " spi2_cr2 @ u. cr
   ." spi2_sr  " spi2_sr  @ u. cr ;

\ PD4 - MOSI
\ PD1 - SCK

4 3 gpio-pin constant PD4
1 3 gpio-pin constant PD1

PD4 constant MOSI
PD1 constant SCK

: mosi-1 ( -- )   MOSI PIN-SET ! ;
: mosi-0 ( -- )   MOSI PIN-RESET ! ;
: mosi@  ( -- b ) MOSI gpio-data @ swap lshift 1 and ;
: sck-1  ( -- )   SCK PIN-SET ! ;
: sck-0  ( -- )   SCK PIN-RESET ! ;
: sck@   ( -- b ) SCK gpio-data @ swap lshift 1 and ;
: spi!   ( w -- ) SPI2_DR ! ;
: spi@   ( -- w ) SPI2_DR @ ; 
: clk-on ( -- ) 1 MOSI RCC-GPIO-CLK! rcc-spi2-ena ;
: spi-gpio ( -- ) 5 MOSI mode-af 5 SCK mode-af ;
: spi-on  ( -- )  SPI_CR1_SPE SPI2_CR1 bis! ;
: spi-off ( -- )  SPI_CR1_SPE SPI2_CR1 bic! ;
: spi-init ( -- ) clk-on spi-gpio
   SPI_CR1_BIDIMODE SPI2_CR1 bis!
   SPI_CR1_BIDIOE   SPI2_CR1 bis!
   SPI_CR1_MSTR     SPI2_CR1 bis!
   SPI_CR1_CPOL     SPI2_CR1 bis!
   SPI_CR1_CPHA     SPI2_CR1 bis!
   SPI_CR2_FRF      SPI2_CR2 bic!
   SPI_CR2_FRXTH    SPI2_CR2 bis!
   7 SPI_CR1_BR     SPI2_CR1 bits!
;



