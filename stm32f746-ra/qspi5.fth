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

\ file qspi5.fth
\ author jean jonethal
\ qspi flash part N25Q128A13EF840E
\ qspi flash datasheet "C:\Users\jeanjo\Downloads\stm\n25q_128mb_3v_65nm.pdf"
\ https://www.micron.com/~/media/documents/products/data-sheet/nor-flash/serial-nor/n25q/n25q_128mb_3v_65nm.pdf
\ stm32f746 user manual "C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf"
reset \ ok.

include util.fth
include gpio.fth
require gpio.fth

\ QSPI_NCS - PB6  - AF10                 \ chip select
\ QSPI_CLK - PB2  - AF9                  \ clock 
\ QSPI_D0  - PD11 - AF9                  \ data 0
\ QSPI_D1  - PD12 - AF9                  \ data 1
\ QSPI_D2  - PE2  - AF9                  \ data 2
\ QSPI_D3  - PD13 - AF9                  \ data 3

\ ********** qspi driver io ports *******   
 #1 GPIO    constant GPIOB
 #3 GPIO    constant GPIOD
 #4 GPIO    constant GPIOE
 #2 GPIOB + constant PB2
 #6 GPIOB + constant PB6
#11 GPIOD + constant PD11
#12 GPIOD + constant PD12
#13 GPIOD + constant PD13
 #2 GPIOE + constant PE2

PB6  constant QSPI_NCS 
PB2  constant QSPI_CLK 
PD11 constant QSPI_D0
PD12 constant QSPI_D1
PE2  constant QSPI_D2
PD13 constant QSPI_D3

#10 constant AF10
 #9 constant AF9

\ ********** qspi helper functions *******
: hh/l# ( f -- m ) 0= $FFFF xor          \ Mask high/low half word low 0:$ffff0000 1:0000FFFF
   1-foldable ;
: pin-10# ( pin -- m )                   \ pin on / off mask
   bsrr-on dup 16 lshift or 1-foldable ;
 
 
\ ********** qspi registers **************
$A0001000 constant QSPI_BASE

: qspi-gpio-init-hw ( -- )                       \ use qspi hardware block
   AF10 QSPI_NCS gpio-mode-af! 
   AF9  QSPI_CLK gpio-mode-af!
   AF9  QSPI_D0  gpio-mode-af!
   AF9  QSPI_D1  gpio-mode-af!
   AF9  QSPI_D2  gpio-mode-af!
   AF9  QSPI_D3  gpio-mode-af! ;

: qspi-gpio-clk-on ( -- )                        \ turn on gpio clock
   1 GPIOB gpio-clk!
   1 GPIOD gpio-clk!
   1 GPIOE gpio-clk! ;

: qspi-gpio-init-sw ( -- )                       \ qspi bitbang
   qspi-gpio-clk-on
   QSPI_NCS 1 gpio-mode!
   QSPI_CLK 1 gpio-mode!
   QSPI_D0  1 gpio-mode!
   QSPI_D1  1 gpio-mode! 
   QSPI_D2  1 gpio-mode!
   QSPI_D3  1 gpio-mode! ;

\ ********** input pins ******************
: qd0@ QSPI_D0  gpio-in# QSPI_D0  gpio-idr bit@ ;
: qd1@ QSPI_D1  gpio-in# QSPI_D1  gpio-idr bit@ ;
: qd2@ QSPI_D2  gpio-in# QSPI_D2  gpio-idr bit@ ;
: qd3@ QSPI_D3  gpio-in# QSPI_D3  gpio-idr bit@ ;
: qcs@ QSPI_NCS gpio-in# QSPI_NCS gpio-idr bit@ ;
: qck@ QSPI_CLK gpio-in# QSPI_CLK gpio-idr bit@ ;

\ ********** output high *****************
: qd0-1 QSPI_D0  pin-on ! ;
: qd1-1 QSPI_D1  pin-on ! ;
: qd2-1 QSPI_D2  pin-on ! ;
: qd3-1 QSPI_D3  pin-on ! ;
: qcs-1 QSPI_NCS pin-on ! ;
: qck-1 QSPI_CLK pin-on ! ;

\ ********** output low ******************
: qd0-0 QSPI_D0  pin-off ! ;
: qd1-0 QSPI_D1  pin-off ! ;
: qd2-0 QSPI_D2  pin-off ! ;
: qd3-0 QSPI_D3  pin-off ! ;
: qcs-0 QSPI_NCS pin-off ! ;
: qck-0 QSPI_CLK pin-off ! ;

\ ********** output bit ******************
: qd0! 0= #16 and QSPI_D0  bsrr-on swap lshift QSPI_D0  gpio-bsrr ! ;
: qd1! 0= #16 and QSPI_D1  bsrr-on swap lshift QSPI_D1  gpio-bsrr ! ;
: qd2! 0= #16 and QSPI_D2  bsrr-on swap lshift QSPI_D2  gpio-bsrr ! ;
: qd3! 0= #16 and QSPI_D3  bsrr-on swap lshift QSPI_D3  gpio-bsrr ! ;
: qcs! 0= #16 and QSPI_NCS bsrr-on swap lshift QSPI_NCS gpio-bsrr ! ;
: qck! 0= #16 and QSPI_CLK bsrr-on swap lshift QSPI_CLK gpio-bsrr ! ;

\ ********** output mode *****************
: qd0> QSPI_D0  gpio-output ;
: qd1> QSPI_D1  gpio-output ;
: qd2> QSPI_D2  gpio-output ;
: qd3> QSPI_D3  gpio-output ;
: qcs> QSPI_NCS gpio-output ;
: qck> QSPI_CLK gpio-output ;

\ ********** input mode ******************
: qd0< QSPI_D0  gpio-input ;
: qd1< QSPI_D1  gpio-input ;
: qd2< QSPI_D2  gpio-input ;
: qd3< QSPI_D3  gpio-input ;
: qcs< QSPI_NCS gpio-input ;
: qck< QSPI_CLK gpio-input ;

: q-init ( -- )                           \ initialize sw qspi
   qspi-gpio-init-sw qcs-1 qck-1 qcs> qck> \ clk, cs output high
   qd0> qd1<    \ qd0 output qd1 input
   \ in single/dual spi qd2 is /write protect so we set it to 1
   qd2-1 qd2> qd2-1                       
   \ in single/dual spi qd3 this /hold so we disable hold - 1
   qd3-1 qd3> qd3-1 ;                     

: la ( -- )
   cr qcs@ 1 and . qck@ 1 and . qd0@ 1 and . ;
\ ******** serializing *******************
: qb! ( n -- n )                          \ shifting out highest bit
   qck-0 la
   dup 0< qd0! la
   2* qck-1 la ;
: qb4! ( n -- n )  qb! qb! qb! qb! ;      \ shifting out highest nibble
: qb8! ( n -- n )  qb4! qb4! ;            \ shifting out highest byte
    
: qb@ ( n -- n )                          \ shifting in 1 bit from spi
   qck-0 la qck-1 la 2* qd1@ 1 and or
   dup .   ;
: qb4@ ( n -- n )  qb@ qb@ qb@ qb@  ;     \ shifting in 1 nibble from spi
: qb8@ ( n -- n )  qb4@ qb4@ ;            \ shifting in 1 byte from spi
: qb32@ ( n -- n ) qb8@ qb8@ qb8@ qb8@ ;  \ read 1 32 bit word
: q-start ( -- ) la qd0> la qcs-0 la ;       \ start transfer
: q-end ( -- ) qcs-1 la ;
: qc!  ( b -- 0 ) 24 lshift qb8! ;        \ write 1 byte

\ ********** flash driver ****************
$9E constant READ_ID
: read-id ( a -- )                        \ read id to buffer 20 bytes
   q-start READ_ID qc! qd0<
   20 0 do 0 qb8@ dup i + ! loop q-end ;
: .id  ( -- )                             \ print id
   q-start READ_ID qc! qd0<
   20 0 do 0 qb8@ x.2 space loop q-end cr ;
 
\ ********** read-block ******************

\ ********** write block *****************


\ ********** soft reset ******************
