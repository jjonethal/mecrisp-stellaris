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
   
\ TODO : GPIO_PUPD ( m pin -- ) ;    
\ ********** RCC constants ***************
$40021000       constant RCC_BASE
$4C RCC_BASE or constant RCC_AHB2ENR 
: RCC-GPIO-CLK! ( f port -- )              \ enable / disable gpio port clock 
   gpio-port# 1 swap lshift
   RCC_AHB2ENR  bits! ;

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
   MEMS_MOSI port-base #10 + bit@ ;
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
   ck-0 <<bit mems-mosi! ck-1 ;           \ and shift byte left by 1 bit
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
   ck-0 2* mems-mosi? 1 and or ck-1 ; 
: rx-2-bit ( b -- b )                     \ receive bit
   rx-bit rx-bit ;   
: rx-4-bit ( b -- b )
   rx-bit rx-bit rx-bit rx-bit ;   
: rx-8-bit ( b -- b )                     \ receive 8 bit from spi
   rx-4-bit rx-4-bit ;   
: cs-1-all  ( -- )                        \ set all chip select 1 ( idle )
   mag-cs-1 gyro-cs1 xl-cs-1 ;            

: spi-xfer-init-reg ( reg f -- )          \ init transfer to reg read/write
   mems-mosi gpio-output                  \ switch mems_mosi to output
   ck-0 do! ck-1                          \ signal read/write mode
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
   ?do i c@ tx-8-bit                       \ b2..data 
   drop loop ;
: spi-read-byte ( reg -- b )
   1 spi-xfer-init-reg                    \ init read from reg
   mems-mosi gpio-input                   \ switch miso to input
   0 rx-8-bit ;                           \ read in 8 bit from mosi 3-wire spi
: spi-read-bytes ( cnt adr reg -- )
   1 spi-xfer-init-reg                    \ init read from reg
   mems-mosi gpio-input                   \ switch miso to input
   tuck + swap
   ?do 0 rx-8-bit i c! loop ;             \ read in 8 bit from mosi 3-wire spi

: XL-WRITE-REG  ( b reg -- )              \ write byte to register address
   cs-1-all                               \ sensor-spi-idle
   ck-1                                   \ clock idle
   xl-cs-0                                \ start cs-0
   spi-write-reg                          \ send register and byte
   xl-cs-0 ;
: XL-READ-BYTE ( adr -- b )               \ read 1 byte from sensor at address
   cs-1-all                               \ all sensors idle
   ck-1                                   \ clock idle
   xl-cs-0                                \ activate acceleraror
   spi-read-byte ;                        \ read in 8 bit from mosi 3-wire spi
   
   
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
   MEMS_MOSI GPIO-OUTPUT-OD
   MEMS_SCK  GPIO-INPUT
   GYRO_INT2 GPIO-INPUT
   GYRO_INT1 GPIO-INPUT
   XL_INT    GPIO-INPUT
   MAG_RDY   GPIO-INPUT
   MAG_INT   GPIO-INPUT ;

\ ********** SPI sensor driver ***********
: ACCEL-SPI-GPIO-INIT  ( -- )
;

: ACCEL-INIT-SPI ( -- )                   \ initialize accelerator spi mode
   SENSOR-GPIO-INIT ;               \ turn on sensor gpio ports

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
