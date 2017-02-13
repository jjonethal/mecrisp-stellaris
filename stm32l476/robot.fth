\ Copyright Jean Jonethal 2015, 2016
\
\ This program is free software: you can redistribute it and/or modify
\ it under the terms of the GNU General Public License as published by
\ the Free Software Foundation, either version 3 of the License, or
\ (at your option) any later version.
\
\ This program is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program.  If not, see <http://www.gnu.org/licenses/>.

\ file robot.fth
\ stm32l476 discovery board robot brain ;)
\ ********** history *********************
\ 2017feb12jjo try spi hw block in bidi mode
\ 2017feb11jjo add gpio debugging add documentation references
\ 2017jan31jjo initial version 
\ ********** documents *******************
\ programming manual
\   http://www.st.com/resource/en/programming_manual/dm00046982.pdf
\ data sheet
\   C:\Users\jeanjo\Downloads\stm\en.DM00108832 STM32L476xx datasheet .pdf
\   http://www.st.com/resource/en/datasheet/stm32l476je.pdf
\ Reference manual
\   http://www.st.com/resource/en/reference_manual/dm00083560.pdf
\   C:\Users\jeanjo\Downloads\stm\en.DM00083560 RM0351 STM32L4x6 advanced ARM®-based 32-bit MCUs .pdf
\ discovery kit manual
\   C:\Users\jeanjo\Downloads\stm\DM00172179 UM1879 User manual Discovery kit with STM32L476VG MCU.pdf

\ ********** Hardware concept ************
\ hardware SPI block 2 on  stm32L476 can be used for bidi communication
\ PD1 - serial clock
\ PD3 - MISO
\ PD4 - MOSI

reset

\ ********** Common utilities ************
: KBYTE ( n -- n ) #1024 * 1-foldable ;   \ convert kbyte to byte

\ ********** system memory definitions ***

$10000000 CONSTANT SRAM2_START            \ start address of sram2
$10007FFF CONSTANT SRAM2_END              \ end address of sram2
SRAM2_END SRAM2_START - 1+
          CONSTANT SRAM2_SIZE             \ size of SRAM2
$20000000 CONSTANT SRAM1_START            \ start address of sram1
#96 KBYTE CONSTANT SRAM1_SIZE             \ size of sram1
SRAM1_START SRAM1_SIZE + 1-
          CONSTANT SRAM1_END              \ end address of sram1

\ ********** GPIO interface **************
: gpio-pin  ( pinNr portNr -- pin )       \ calculate PIN from pin number and port number
   #10 lshift $48000000
   or or 2-foldable ;                     \ PortA:0 .. PortH:7
: gpio-port# ( a -- n )                      \ calculate port number from pin
   #10 rshift #7 and 1-foldable ; 
: port-base ( pin -- a )                  \ extract port base address from pin
   #7 not and 1-foldable ;
: pin# ( pin -- n ) $F and 1-foldable ;

: 2** ( n -- n ) 1 swap lshift 1-foldable ;

0 #0 gpio-pin constant PORTA
0 #1 gpio-pin constant PORTB
0 #2 gpio-pin constant PORTC
0 #3 gpio-pin constant PORTD
0 #4 gpio-pin constant PORTE
0 #5 gpio-pin constant PORTF
0 #6 gpio-pin constant PORTG
0 #7 gpio-pin constant PORTH

$0C          constant GPIO_PUPDR
$18          constant GPIO_BSRR
$20          constant GPIO_AFRL

: gpio-2-bit-mask ( pin -- m )            \ generate 2 bit mask for gpio
   pin# 2* 3 swap lshift 1-foldable ;
: BSRR ( pin -- a )                       \ calculate GPIO_BSRR reg addr from pin
   port-base $18 + 1-foldable ;
: BSRR-MASK-SET ( pin -- m )              \ calculate bsrr set mask for pin
   $f and 1 swap lshift 1-foldable ;
: BSRR-MASK-RESET ( pin -- m )            \ calculate bsrr reset mask for pin
   BSRR-MASK-SET #16 lshift 1-foldable ;
: BSRR-MASK ( pin -- m )                  \ calculate bit-set-reset mask for pin
   BSRR-MASK-SET dup #16 lshift or
   1-foldable ;
: PIN-SET ( n -- m a )                    \ calculate bsrr set mask + bsrr adr from pin
   dup BSRR-MASK-SET swap                 \ can be optimized
   port-base $18 + 1-foldable ;
: PIN-RESET ( n -- m a )                  \ calculate bsrr reset mask + bsrr adr from pin
   dup BSRR-MASK-RESET swap               
   port-base $18 + 1-foldable ;           \ can be optimized
: PIN-CHANGE ( n -- m a )                 \ calculate bsrr reset mask + bsrr adr from pin
   dup BSRR-MASK swap               
   port-base $18 + 1-foldable ;           \ can be optimized
: BSRR-SEL ( f - m )                      \ BSRR set/reset selector mask
   0= $FFFF xor 1-foldable ;              \ pin change mask f=0: $FFFF0000 f=1:$FFFF
: GPIO-OTYPE-PUSH-PULL ( pin -- )         \ set pin output type to push-pull
   dup pin# 1 swap lshift
   swap port-base $4 + bic! ;
: GPIO-OTYPE-OPEN-DRAIN ( pin -- )        \ set pin output type to open drain
   dup pin# 1 swap lshift
   swap port-base $4 + bis! ;
: GPIO-OUTPUT ( pin -- )
   1 swap
   dup gpio-2-bit-mask
   swap port-base bits! ;
: gpio-pupd ( m pin -- )
   dup gpio-2-bit-mask
   swap port-base $C + bits! ;
: GPIO-INPUT ( pin -- )                   \ set pin to input mode
   0 swap
   dup gpio-2-bit-mask
   swap port-base bits! ;
: GPIO-OUTPUT-PP ( pin -- )               \ set pin to output mode push-pull
   dup GPIO-OTYPE-PUSH-PULL
   GPIO-OUTPUT ;
: GPIO-OUTPUT-OD ( pin -- )               \ set pin to output mode open drain
   dup GPIO-OTYPE-OPEN-DRAIN
   GPIO-OUTPUT ;
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
: gpio-data? ( pin -- )                   \ get input data from pin
   dup pin# 1 swap lshift swap
   port-base $10 + bit@ ;
: moder-id ( n -- )                      \ emit symbolic gpio-moder values
    #3 and 2* s" INOUAFAN" drop + 2 type ; \ 0-IN 1-OU 2-AF 3-AN
: otyper-id ( n -- )
    #1 and 2* s" PPOD" drop + 2 type ; \ 0-PP 1-OD
: pupdr-id ( n -- )                      \ emit symbolic gpio-pupdr values
    #3 and 2* s" NOPUPDXX" drop + 2 type ; \ 0-NO 1-PU 2-PD 3-XX

: base-save-10 ( n -- base n )
   base @ swap decimal ;
: base! ( base -- ) base ! ;
: dump15-0 ( -- ) 0 15 do i u.2 space -1 +loop ;
: .gpio-moder ( r -- )                    \ dump gpio moder
   base-save-10
   port-base @ cr dump15-0 cr
   hex
   0 #15 do dup i 2* rshift 3 and u.2 space -1 +loop cr
   0 #15 do dup i 2* rshift 3 and moder-id space -1 +loop cr
   drop base! ;
: .gpio-otyper ( r -- )
  base-save-10
  cr dump15-0 cr
  port-base 4 + @
  0 15 do dup i rshift 1 and u.2 space -1 +loop cr
  0 15 do dup i rshift 1 and otyper-id space -1 +loop cr 
  drop base! ;
: .gpio-pupdr ( r -- )                    \ dump gpio pupdr
   base-save-10
   port-base $c + @ cr dump15-0 cr
   hex
   0 #15 do dup i 2* rshift 3 and u.2 space -1 +loop cr
   0 #15 do dup i 2* rshift 3 and pupdr-id space -1 +loop cr
   drop base! ;
: .gpio-idr ( r -- )
   base-save-10
   cr dump15-0 cr
   port-base $10 + @
   0 15 do dup i rshift 1 and u.2 space -1 +loop cr
   drop base! ;
: 4* ( n -- n )  2 lshift 1-foldable ;
: .gpio-afr ( r -- )                    \ dump gpio pupdr
   base-save-10
   port-base $24 + dup @ cr dump15-0 cr
   hex
   0 #7 do dup i 4* rshift $f and u.2 space -1 +loop
   drop 4 - @
   0 #7 do dup i 4* rshift $f and u.2 space -1 +loop cr
   drop base! ;

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

\ ********** L3GD20 Pins *****************
\ http://www.st.com/resource/en/datasheet/l3gd20.pdf
PORTD 1 or CONSTANT MEMS_SCK              \ SPI/I2C clock
PORTD 4 or CONSTANT MEMS_MOSI             \ SDA/SDI/SDO/i2c sda
PORTD 3 or CONSTANT MEMS_MISO             \ SDO/SA0 SPI data out/ I2C adr0
PORTD 7 or CONSTANT GYRO_CS               \ 0-SPI mode 1-i2c mode/spi idle
PORTB 8 or CONSTANT GYRO_INT2             \ DRDY/INT2 Data ready/FIFO interrupt 
PORTD 2 or CONSTANT GYRO_INT1             \ INT1 Programmable interrupt

\ ********** LSM303CTR Pins **************
\ http://www.st.com/resource/en/datasheet/lsm303c.pdf
\ C:\Users\jeanjo\Downloads\stm\stm32l476 discovery\en.DM00089896.pdf
PORTD 1 or CONSTANT MEMS_SCK              \ spi / i2c clock
PORTE 0 or CONSTANT XL_CS                 \ 1-i2c 0- accel spi mode
PORTC 0 or CONSTANT MAG_CS                \ 1-i2c 0 - mag spi mode
PORTE 1 or CONSTANT XL_INT                \ accel interrupt
PORTD 4 or CONSTANT MEMS_MOSI             \ SDA/SDI/SDO
PORTC 2 or CONSTANT MAG_RDY               \ Magnetometer data ready
PORTC 1 or CONSTANT MAG_INT               \ Magnetometer interrupt signal

\ ********** LSM303CTR registers *********
$23 constant CTRL_REG4_A
#3 #6 lshift constant CTRL_REG4_A.BW
#3 #4 lshift constant CTRL_REG4_A.FS
#1 #3 lshift constant CTRL_REG4_A.BW_SCALE_ODR
#1 #2 lshift constant CTRL_REG4_A.IF_ADD_INC
#1 #1 lshift constant CTRL_REG4_A.I2C_DISABLE
#1 #0 lshift constant CTRL_REG4_A.SIM

$22 constant CTRL_REG3_M
#1 #7 lshift constant CTRL_REG3_M.I2C_DISABLE
#1 #5 lshift constant CTRL_REG3_M.LP
#1 #2 lshift constant CTRL_REG3_M.SIM
#1 #1 lshift constant CTRL_REG3_M.MD1
#1 #0 lshift constant CTRL_REG3_M.MD0

\ ********** sensor pin functions ********
: XL-CS-1     ( -- ) XL_CS     PIN-SET   ! ;  \ set accelerator chip select to 1 
: XL-CS-0     ( -- ) XL_CS     PIN-RESET ! ;  \ reset accelerator chip select to 0 
: MAG-CS-1    ( -- ) MAG_CS    PIN-SET   ! ;  \ set magnetometer chip select to 1
: MAG-CS-0    ( -- ) MAG_CS    PIN-RESET ! ;  \ reset magnetometer chip select to 0
: GYRO-CS-1   ( -- ) GYRO_CS   PIN-SET   ! ;  \ set gyro chip select to 1
: GYRO-CS-0   ( -- ) GYRO_CS   PIN-RESET ! ;  \ reset gyro chip select to 0
: MEMS-SCK-1  ( -- ) MEMS_SCK  PIN-SET   ! ;  \ set mems clock line to 1
: MEMS-SCK-0  ( -- ) MEMS_SCK  PIN-RESET ! ;  \ reset mems clock line to 0
: MEMS-MOSI-1 ( -- ) MEMS_MOSI PIN-SET   ! ;  \ set mems mosi signal to 1
: MEMS-MOSI-0 ( -- ) MEMS_MOSI PIN-RESET ! ;  \ reset mems mosi signal to 0
: MEMS-MOSI?  ( -- f )                    \ query mems-mosi pin, used by 3-wire
   1 MEMS_MOSI pin# lshift                \ spi read for xl sensor
   MEMS_MOSI port-base $10 + @ and 0<> ;
: SCK? ( -- f )                           \ query sck data pin
   MEMS_SCK gpio-data? ;
: XL-cs? ( -- f ) XL_CS gpio-data? ;

: 1& ( n -- n ) 1 and 1-foldable ;

0 variable DEBUG-SPI

: .spi ( -- )
   DEBUG-SPI @ if
   ." XL-CS " XL-cs? 1& . ." SCK " SCK? 1& . ." MOSI " MEMS-MOSI? 1& . cr
   then ;
	
: XL-CS! ( f -- )                         \ set/reset XL_CS pin depending on flag
   BSRR-SEL XL_CS BSRR-MASK
   and XL_CS BSRR ! ;
: MAG-CS! ( f -- )                        \ set/reset MAG_CS pin depending on flag
   BSRR-SEL MAG_CS BSRR-MASK
   and MAG_CS BSRR ! ;                     
: GYRO-CS! ( f -- )                       \ set/reset GYRO_CS pin depending on flag
   BSRR-SEL GYRO_CS BSRR-MASK
   and GYRO_CS BSRR ! ;                    
: MEMS-SCK! ( f -- )                      \ set/reset MEMS_SCK pin depending on flag
   BSRR-SEL MEMS_SCK BSRR-MASK
   and MEMS_SCK BSRR ! ;
: MEMS-MOSI! ( f -- )                     \ set/reset MEMS_MOSI pin depending on flag
   BSRR-SEL MEMS_MOSI BSRR-MASK
   and MEMS_MOSI BSRR ! ;
: do? MEMS-MOSI? ;
: ck-0 ( -- ) MEMS-SCK-0 ;                \ set clock 0
: ck-1 ( -- ) MEMS-SCK-1 ;                \ set clock 1
: do-0 ( -- ) MEMS-MOSI-0 ;               \ set data out 0
: do-1 ( -- ) MEMS-MOSI-1 ;               \ set data out 1
: do!  ( f -- )  MEMS-MOSI! ;             \ send bit to mems_mosi
: bit ( w n -- b f )                      \ extract bit number n from w
   1 swap lshift over and 0<> 2-foldable ;
: <<bit ( b -- b f )                      \ extract bit 31 and shift left reminder
	 dup 2* swap 0< 1-foldable ;
: tx-bit ( b -- b )                       \ transfer on bit31 of a byte via spi 
   ck-0
   .spi
   <<bit
   mems-mosi!
   .spi
   ck-1
   .spi
   ;           \ and shift byte left by 1 bit
: tx-2-bit ( b -- b )                     \ transfer bit 31..30 via spi 
   tx-bit tx-bit ;                        \ and shift byte left by 2 bit
: tx-4-bit ( b -- b )                     \ transfer bit 31..28 via spi 
   tx-bit tx-bit tx-bit tx-bit ;          \ and shift byte left by 4 bit
: tx-7-bit ( b -- b )                     \ transfer bit 31..25 via spi 
   tx-4-bit tx-bit tx-bit tx-bit ;        \ and shift byte left by 7 bit
: tx-8-bit ( b -- b )                     \ transfer bit 31..24 via spi 
   tx-4-bit tx-4-bit ;                    \ and shift byte left by 8 bit
: bit<< ( b f -- b )                      \ shift word left shift in bit from spi    <--spi
   1 and swap 2* or 2-foldable ;
: rx-bit ( b -- b )                       \ receive one bit
   .spi
   ck-0
   .spi
   2* mems-mosi? 1 and or
   ck-1
   .spi   ; 
: rx-2-bit ( b -- b )                     \ receive 2 bits
   rx-bit rx-bit ;   
: rx-4-bit ( b -- b )                     \ receive 4 bits
   rx-bit rx-bit rx-bit rx-bit ;   
: rx-8-bit ( b -- b )                     \ receive 8 bits from spi
   rx-4-bit rx-4-bit ;   
: cs-1-all  ( -- )                        \ set all chip select 1 ( idle )
   mag-cs-1 gyro-cs-1 xl-cs-1 ;            

: spi-xfer-init-reg ( reg r/w -- )        \ init transfer to reg read(1)/write(0)
   mems_mosi gpio-output                  \ switch mems_mosi to output
   .spi
   ck-0
   .spi
   do!
   .spi
   ck-1                                   \ signal read/write mode
   .spi
   #25 lshift                             \ shift AD6..0 to b31..b25
   tx-7-bit                               \ AD6..AD0 -write
   drop   ;                               \ drop reg

: spi-write-reg ( b reg -- ) 
   0 spi-xfer-init-reg                    \ init write from reg
   #24 lshift                             \ b7..0 -> b31..24
   tx-8-bit ;
: spi-write-bytes  ( cnt adr reg -- )     \ send buffer at adr
   0 spi-xfer-init-reg                    \ init write to reg
   tuck + swap                            \ calc loop end
   ?do i c@ tx-8-bit                      \ transmit bytes 
   drop loop ;
: spi-read-byte ( reg -- b )              \ read a byte from reg
   1 spi-xfer-init-reg                    \ init read from reg
   .spi
   mems_mosi gpio-input                   \ switch miso to input
   .spi
   0 rx-8-bit ;                           \ read in 8 bit from mosi 3-wire spi
: spi-read-bytes ( cnt adr reg -- )
   1 spi-xfer-init-reg                    \ init read from reg
   mems_mosi gpio-input                   \ switch miso to input
   tuck + swap
   ?do 0 rx-8-bit i c! loop ;             \ read in 8 bit from mosi 3-wire spi

: XL-WRITE-BYTE  ( b reg -- )              \ write byte to register address
   .spi
   cs-1-all                               \ sensor-spi-idle
   .spi
   ck-1                                   \ clock idle
   xl-cs-0                                \ start cs-0
   .spi
   spi-write-reg                          \ send register and byte
   .spi
   xl-cs-1
   .spi ;
: XL-READ-BYTE ( adr -- b )               \ read 1 byte from sensor at address
   cs-1-all                               \ all sensors idle
   .spi
   ck-1                                   \ clock idle
   .spi
   xl-cs-0                                \ activate acceleraror
   .spi
   spi-read-byte                          \ read in 8 bit from mosi 3-wire spi
   .spi
   xl-cs-1
   .spi ;
: MAG-WRITE-BYTE  ( b reg -- )            \ write byte to register address
   .spi
   cs-1-all                               \ sensor-spi-idle
   .spi
   ck-1                                   \ clock idle
   mag-cs-0                               \ start cs-0
   .spi
   spi-write-reg                          \ send register and byte
   .spi
   mag-cs-1
   .spi ;
: MAG-READ-BYTE ( adr -- b )              \ read 1 byte from sensor at address
   cs-1-all                               \ all sensors idle
   .spi
   ck-1                                   \ clock idle
   .spi
   mag-cs-0                               \ activate acceleraror
   .spi
   spi-read-byte                          \ read in 8 bit from mosi 3-wire spi
   .spi
   mag-cs-1
   .spi ;
\ ********** global Sensor init **********
: SENSOR-GPIO-INIT  ( -- )
   1 PORTB RCC-GPIO-CLK!                  \ enable gpio clocks
   1 PORTC RCC-GPIO-CLK!
   1 PORTD RCC-GPIO-CLK!
   1 PORTE RCC-GPIO-CLK!
   XL-CS-1                                \ disable accel sensor
   XL_CS   GPIO-OUTPUT-PP
   MAG-CS-1
   MAG_CS  GPIO-OUTPUT-PP
   GYRO-CS-1
   GYRO_CS GPIO-OUTPUT-PP
   MEMS_MOSI GPIO-OUTPUT-PP
   MEMS_SCK  GPIO-OUTPUT-PP
   MEMS-SCK-1
   GYRO_INT2 GPIO-INPUT
   GYRO_INT1 GPIO-INPUT
   XL_INT    GPIO-INPUT
   MAG_RDY   GPIO-INPUT
   MAG_INT   GPIO-INPUT ;

\ ********** SPI sensor driver ***********
: ACCEL-SPI-GPIO-INIT  ( -- )
;
 
: ACCEL-SPI-INIT ( -- f )                 \ initialize accelerator spi mode
   SENSOR-GPIO-INIT                       \ turn on sensor gpio ports
   5 CTRL_REG4_A XL-WRITE-BYTE
   $f xl-read-byte $41 = ;                          
: xl-spi-read-enable ( -- )               \ enable spi read 
   5 CTRL_REG4_A XL-WRITE-BYTE ;
: mag-spi-read-enable ( -- )
   CTRL_REG3_M.SIM CTRL_REG3_M MAG-WRITE-BYTE ;
: test \ test acceleration-sensor 
   SENSOR-GPIO-INIT
   5 CTRL_REG4_A XL-WRITE-BYTE            \ enable spi read 
   ." xl-write " cr
   $f xl-read-byte hex ." xl who ami $41=" . cr
   mag-spi-read-enable
   $F mag-read-byte hex ." mag who ami $3D=" . cr
   ;                          

\ ********** SPI HW Operations ***********
\ PD1 AF5 SPI2_SCK  - MEMS_SCK
\ PD3 AF5 SPI2_MISO - MEMS_MISO
\ PD4 AF5 SPI2_MOSI - MEMS_MOSI
\ PD7     GPIO      - GYRO_CS               
\ PE0     GPIO      - XL_CS                 \ 1-i2c 0- accel spi mode
\ PC0     GPIO      - MAG_CS                \ 1-i2c 0 - mag spi mode
MEMS_MOSI constant SPI2_MOSI
MEMS_SCK  constant SPI2_SCK

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

: spi2-off
   0 SPI_CR1_SPE SPI2_CR1 bits! ;           \ enable spi
: spi2-on
   1 SPI_CR1_SPE SPI2_CR1 bits! ;           \ enable spi
: spi2-bidioe  ( f -- )
   SPI_CR1_BIDIOE SPI2_CR1 bits! ;          \ enable spi bidi output enable


: test-hw-clk ( -- )
   sck? begin sck? over <> until drop ." test-hw-clk toggle " cr ;

: sensor-hw-spi-init  ( -- )                \ initialize spi hw block   
   SENSOR-GPIO-INIT                         \ gpio port D clock enabled
   rcc-spi2-ena                             \ spi clock enabled
   5 SPI2_MOSI mode-af                      \ alternate function for MOSI pin
   5 SPI2_SCK  mode-af                      \ alternate function for spi clock
   0 SPI2_CR1 !                             \ turn off spi2
   1 SPI_CR1_SSM  SPI2_CR1 bits!            \ software slave select mode
   1 SPI_CR1_SSI  SPI2_CR1 bits!            \ software slave select mode
   1 SPI_CR1_MSTR SPI2_CR1 bits!            \ we are the master
   1 SPI_CR1_CPOL SPI2_CR1 bits!            \ clock idle - H 
   1 SPI_CR1_CPHA SPI2_CR1 bits!            \ sample data on rising edge
   7 SPI_CR1_BR SPI2_CR1 bits!              \ bit rate 1/4 of APB1 clock
   1 SPI_CR1_BIDIMODE SPI2_CR1 bits!        \ bidi mode
   1 SPI_CR1_BIDIOE SPI2_CR1 bits!          \ output enable - we start in tx mode 
   0 SPI2_CR2 !                             \ reset spi_cr2
   1 SPI_CR2_FRXTH SPI2_CR2 bits!           \ trigger RXNE when one byte arrived
   1 SPI_CR2_FRF SPI2_CR2 bits!             \ ti mode
   7 SPI_CR2_DS SPI2_CR2 bits!              \ 8 bit transfer unit
   spi2-on ;                                \ enable spi
: spi2-txe? ( -- f )
   SPI_SR_TXE SPI2_SR bit@ ;
: spi2-rxne? ( -- f )
   SPI_SR_RXNE SPI2_SR bit@ ;
: spi-pause-until-txe ( -- )
   ." txe pause " cr
   begin SPI2-TXE? not while pause repeat
   ." txe pause end " cr ;
: spi-pause-until-rxne ( -- )
\   ." rxne pause " cr 
   begin SPI2-RXNE? not while pause repeat
\   ." rxne pause end " cr
   ;
: spi-dr-dump ( -- )
   ." spi_dr dump " begin SPI2-RXNE? while spi2_dr c@ . space repeat cr ;

\ ********** mini - la *******************
0 variable cnt
1000 buffer: la-buffer
0 variable last-data
0 variable do-last
: put-sample ( c -- )
   dup last-data !
   cnt @ dup 1+ dup 1000 < and cnt !
   la-buffer + c! ;
: sample
   sck? 1 and do? 2 and or dup
   last-data @ <> if put-sample else drop then ;
: mini-la-tx
   begin sample spi2-txe? until ;
: dump-la
	cnt @ la-buffer + la-buffer
	  ?do i c@ dup 1 and . 2/ 1 and . cr
	  loop cr ;
   
: spi-write-reg-h ( b reg -- )
   spi2-off
   1 SPI_CR1_BIDIOE SPI2_CR1 bits!        \ switch to tx mode
   spi2-on
   SPI2_DR !     
   mini-la-tx   
   spi-pause-until-txe
   SPI2_DR !
   spi-pause-until-txe ;
: spi-read-reg-h ( reg -- b )
   spi2-off
   1 SPI_CR1_BIDIOE SPI2_CR1 bits!        \ switch to tx mode
   spi2-on
   SPI2_DR !
   ." spi-read-reg-h 1" .spi2 
   spi-pause-until-txe
   ." spi-read-reg-h 2" .spi2 
   spi2-off
   0 SPI_CR1_BIDIOE SPI2_CR1 bits!        \ switch to rx mode
   spi2-on
   \ ." spi-read-reg-h 4" .spi2 
   spi-pause-until-rxne                   \ wait for incomming byte
   1 SPI_CR1_BIDIOE SPI2_CR1 bits!        \ switch to rx mode
   spi-dr-dump 
   SPI2_DR c@ 
   spi2-off ;
: xl-write-byte-hw ( b reg -- )           \ write 1 byte via hw mode
   XL-CS-0
   $7F and                                \ in register write mode bit7 ->0
   spi-write-reg-h
   spi-pause-until-txe
   XL-CS-1 ;
: xl-read-byte-hw ( reg -- b )            \ read 1 byte via hw mode
   XL-CS-0
   $80 or                                 \ for bidi read mode set bit 7 in reg
   spi-read-reg-h
   XL-CS-1 ;
: mag-write-byte-hw ( b reg -- )          \ write 1 byte via hw mode
   MAG-CS-0
   $7F and                                \ in register write mode bit7 ->0
   spi-write-reg-h
   spi-pause-until-txe
   mag-CS-1 ;
: mag-read-byte-hw ( reg -- b )           \ read 1 byte via hw mode
   mag-cs-0
   $80 or                                 \ for bidi read mode set bit 7 in reg
   spi-read-reg-h
   mag-cs-1 ;
: xl-spi-read-enable-hw ( -- )            \ enable spi read 
   CTRL_REG4_A.IF_ADD_INC
   CTRL_REG4_A.SIM OR
   CTRL_REG4_A xl-write-byte-hw ;
: mag-spi-read-enable-hw ( -- )
   CTRL_REG3_M.SIM CTRL_REG3_M mag-write-byte-hw ;

: test-hw ( -- )
   sensor-hw-spi-init
   xl-spi-read-enable-hw
   .spi2
   $f xl-read-byte-hw hex ." xl who ami $41=" . cr
   mag-spi-read-enable-hw
   $F mag-read-byte-hw hex ." mag who ami $3D=" . cr ;

   
\ ********** QSPI Memory *****************
\ N25Q128A13EF840E
\ https://www.micron.com/~/media/documents/products/data-sheet/nor-flash/serial-nor/n25q/n25q_128mb_3v_65nm.pdf
\ C:\Users\jeanjo\Downloads\stm\stm32l476 discovery\n25q_128mb_3v_65nm.pdf
PORTE #10 + CONSTANT QSPI_CLK             \ QSPI clock
PORTE #11 + CONSTANT QSPI_CS              \ QSPI chip select
PORTE #12 + CONSTANT QSPI_D0              \ QSPI data 0
PORTE #13 + CONSTANT QSPI_D1              \ QSPI data 1
PORTE #14 + CONSTANT QSPI_D2              \ QSPI data 2
PORTE #15 + CONSTANT QSPI_D3              \ QSPI data 3

\ ********** Robot States ****************
\ robot battery full
\ robot battery low
\ robot battery empty
\ robot happyness
\ robot sadness
\ robot health
\ robot object-affinity
