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

: KBYTE ( n -- n ) 1024 * 1-foldable ;    \ convert kbyte to byte

\ ********** system memory definitions ***

$10000000 CONSTANT SRAM2_START            \ start address of sram2
$10007FFF CONSTANT SRAM2_END              \ end address of sram2
SRAM2_END SRAM2_START - 1+
          CONSTANT SRAM2_SIZE             \ size of SRAM2
$20000000 CONSTANT SRAM1_START            \ start address of sram1
96 KBYTE  CONSTANT SRAM1_SIZE             \ size of sram1
SRAM1_START SRAM1_SIZE + 1-
          CONSTANT SRAM1_END              \ end address of sram1

\ ********** GPIO interface **************
: GPIO-PIN  ( pinNr portNr -- pin )       \ calculate PIN from pin number and port number
   10 lshift $48000000 or or 2-foldable ; \ PortA:0 .. PortH:7
: port-nr ( a -- n )                      \ calculate port number from pin
   10 rshift 7 and 1-foldable ; 
: port-base ( pin -- a )                  \ extract port base address from pin
   7 not and 1-foldable ;
: pin# ( pin -- n ) $F and 1-foldable ;
  
0 0 GPIO-PIN constant PORTA
0 1 GPIO-PIN constant PORTB
0 2 GPIO-PIN constant PORTC
0 3 GPIO-PIN constant PORTD
0 4 GPIO-PIN constant PORTE
0 5 GPIO-PIN constant PORTF
0 6 GPIO-PIN constant PORTG
0 7 GPIO-PIN constant PORTH

$0C          constant GPIO_PUPDR
$18          constant GPIO_BSRR
$20          constant GPIO_AFRL

: BSRR ( pin -- a )
   port-base $18 + 1-foldable ;
: BSRR-MASK-SET ( pin -- m )              \ calculate bsrr set mask for pin
   $f and 1 swap lshift 1-foldable ;
: BSRR-MASK-RESET ( pin -- m )            \ calculate bsrr reset mask for pin
   BSRR-MASK-SET #16 lshift 1-foldable ;
: BSRR-MASK ( pin -- m )                  \ calculate bit-set-reset mask for pin
   BSRR-MASK-SET dup 16 lshift or
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
: GPIO-OTYPE-PUSH-PULL ( pin -- )
   dup pin# 1 swap lshift
   swap port-base 4 + bic! ;
: GPIO-OTYPE-OPEN-DRAIN ( pin -- )
   dup pin# 1 swap lshift
   swap port-base 4 + bis! ;
: GPIO-OUTPUT ( pin -- )
   1 swap
   dup $f and 2* 3 swap lshift
   swap port-base bits! ;
: GPIO-INPUT ( pin -- )
   0 swap
   dup $f and 2* 3 swap lshift
   swap port-base bits! ;
: GPIO-OUTPUT-PP ( pin -- )               \ set pin to output mode push-pull
   dup GPIO-OTYPE-PUSH-PULL
   GPIO-OUTPUT ;
: GPIO-OUTPUT-OD ( pin -- )               \ set pin to output mode open drain
   dup GPIO-OTYPE-OPEN-DRAIN
   GPIO-OUTPUT ;
: gpio-mode! ( mode pin -- )
   dup pin# 2* 3 swap lshift
   swap port-base bits! ;
: af-mask  ( pin -- mask )                \ alternate function bitmask
   $7 and #2 lshift $f swap lshift 1-foldable ;
: af-reg  ( pin -- adr )                  \ alternate function register address for pin
   dup $8 and 2/ swap
   port-base GPIO_AFRL + + 1-foldable ;
: mode-af ( af pin -- )                   \ set alternate function mode
   #2 over gpio-mode!
   dup af-mask swap af-reg bits! ;

\ TODO : GPIO_PUPD ( m pin -- ) ;    
\ ********** RCC constants ***************
$40021000       constant RCC_BASE
$4C RCC_BASE or constant RCC_AHB2ENR 
: RCC-GPIO-CLK ( f port -- )              \ enable / disable gpio port clock 
   port-nr 1 swap lshift
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
: MEMS_MOSI-1 ( -- ) MEMS_MOSI PIN-SET   ! ;  \ set mems mosi signal to 1
: MEMS_MOSI-0 ( -- ) MEMS_MOSI PIN-RESET ! ;  \ reset mems mosi signal to 0
: XL-CS! ( f -- )
   BSRR-SEL XL_CS BSRR-MASK
   and XL_CS BSRR ! ;                     \ set/reset XL_CS pin depending on flag 
: MAG-CS! ( f -- )
   BSRR-SEL MAG_CS BSRR-MASK
   and MAG_CS BSRR ! ;                    \ set/reset MAG_CS pin depending on flag 
: GYRO-CS! ( f -- )
   BSRR-SEL GYRO_CS BSRR-MASK
   and GYRO_CS BSRR ! ;                   \ set/reset GYRO_CS pin depending on flag 
: MEMS-SCK! ( f -- )
   BSRR-SEL MEMS_SCK BSRR-MASK
   and MEMS_SCK BSRR ! ;                  \ set/reset MEMS_SCK pin depending on flag 
: MEMS-MOSI! ( f -- )
   BSRR-SEL MEMS_MOSI BSRR-MASK
   and MEMS_MOSI BSRR ! ;                 \ set/reset MEMS_MOSI pin depending on flag 

\ ********** global Sensor init **********
: GLOBAL-SENSOR-INIT-SPI  ( -- )
   1 PORTB RCC-GPIO-CLK
   1 PORTC RCC-GPIO-CLK
   1 PORTD RCC-GPIO-CLK
   1 PORTE RCC-GPIO-CLK
   XL-CS-1
   XL_CS   GPIO-OUTPUT-PP
   MAG-CS-1
   MAG_CS  GPIO-OUTPUT-PP
   GYRO-CS-1
   GYRO_CS GPIO-OUTPUT-PP
   MEMS_SCK GPIO-INPUT
   MEMS_MOSI GPIO-OUTPUT-OD ;

\ ********** SPI sensor driver ***********
: ACCEL-SPI-GPIO-INIT  ( -- )
;

: ACCEL-INIT-SPI ( -- )                   \ initialize accelerator spi mode
   GLOBAL-SENSOR-INIT-SPI ;               \ turn on sensor gpio ports

\ ********** QSPI Memory *****************
\ N25Q128A13EF840E
\ https://www.micron.com/~/media/documents/products/data-sheet/nor-flash/serial-nor/n25q/n25q_128mb_3v_65nm.pdf
\ C:\Users\jeanjo\Downloads\stm\stm32l476 discovery\n25q_128mb_3v_65nm.pdf
PE11 CONSTANT QSPI_CS                     \ QSPI chip select
PE10 CONSTANT QSPI_CLK                    \ QSPI clock
PE12 CONSTANT QSPI_D0                     \ QSPI data 0
PE13 CONSTANT QSPI_D1                     \ QSPI data 1
PE14 CONSTANT QSPI_D2                     \ QSPI data 2
PE15 CONSTANT QSPI_D3                     \ QSPI data 3

\ ********** Robot States ****************
\ robot battery full
\ robot battery low
\ robot battery empty
\ robot happyness
\ robot sadness
\ robot health
\ robot love
