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
: hh/l# ( f -- m ) 0= $FFFF xor           \ Mask high/low half word low 0:$ffff0000 1:0000FFFF
  1-foldable ;
: pin-10# ( pin -- m )                    \ pin on / off mask
  bsrr-on dup 16 lshift or 1-foldable ;
 
 
\ ********** qspi registers **************
$A0001000 constant QSPI_BASE

: qspi-gpio-init-hw ( -- )                \ use qspi hardware block
   AF10 QSPI_NCS gpio-mode-af! 
   AF9  QSPI_CLK gpio-mode-af!
   AF9  QSPI_D0  gpio-mode-af!
   AF9  QSPI_D1  gpio-mode-af!
   AF9  QSPI_D2  gpio-mode-af!
   AF9  QSPI_D3  gpio-mode-af! ;

: qspi-gpio-clk-on ( -- )                 \ turn on gpio clock
   1 GPIOB gpio-clk!
   1 GPIOD gpio-clk!
   1 GPIOE gpio-clk! ;

: qspi-gpio-init-sw ( -- )                \ qspi bitbang
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
: qd0< ( -- ) QSPI_D0  gpio-input 0 QSPI_D0 gpio-pupd! ;
: qd1< ( -- ) QSPI_D1  gpio-input 0 QSPI_D1 gpio-pupd! ;
: qd2< ( -- ) QSPI_D2  gpio-input 0 QSPI_D2 gpio-pupd! ;
: qd3< ( -- ) QSPI_D3  gpio-input 0 QSPI_D3 gpio-pupd! ;
: qcs< ( -- ) QSPI_NCS gpio-input ;
: qck< ( -- ) QSPI_CLK gpio-input ;
: qd2<-pu ( -- ) 1 QSPI_D2 dup gpio-input gpio-pupd! ;
: qd3<-pu ( -- ) 1 QSPI_D3 dup gpio-input gpio-pupd! ;

: q-init ( -- )                            \ initialize sw qspi
   qspi-gpio-init-sw qcs-1 qck-1 qcs> qck> \ clk, cs output high
   qd0> qd1<                               \ qd0 output qd1 input
   \ in single/dual spi qd2 is /write protect so we set it to 1
   qd2<-pu                       
   \ in single/dual spi qd3 this /hold so we disable hold - 1
   qd3<-pu
   ;                     

: la ( -- )                               \ logic analyser
\   cr qcs@ 1 and . qck@ 1 and . qd0@ 1 and .
   ;
\ ********** serializing *****************

\ ********** single spi mode *************
: q1b1!  ( n -- n )                       \ single mode shifting out highest bit
   qck-0 la
   dup 0< qd0! la
   2* qck-1 la ;
: q1b2!  ( n -- n ) q1b1! q1b1! ;         \ single mode shifting out top 2 bits
: q1b4!  ( n -- n ) q1b2! q1b2! ;         \ shifting out highest nibble
: q1b8!  ( n -- n ) q1b4! q1b4! ;         \ shifting out highest byte

: q1b1@ ( n -- n )                        \ shifting in 1 bit from spi
   qck-0 la qck-1 la 2* qd1@ 1 and or
\   dup .
   ;
: q1b2@  ( n -- n )  q1b1@ q1b1@ ;        \ shifting in 1 nibble from spi
: q1b4@  ( n -- n )  q1b2@ q1b2@ ;        \ shifting in 1 nibble from spi
: q1b8@  ( n -- n )  q1b4@ q1b4@ ;        \ shifting in 1 byte from spi
: q1b32@  ( n -- n )                      \ read 1 32 bit word
   q1b8@ q1b8@ q1b8@ q1b8@ ;

\ ********** dual spi mode ***************
: q2b2! ( n -- n )                        \ dual mode spi 2 bit shift out
   qck-0 la
   dup 0< qd1! 2*
   dup 0< qd0! 2* qck-1 la ;
: q2b4! ( n -- n )  q2b2! q2b2! ;         \ dual mode spi 4 bit shift out
: q2b8! ( n -- n )  q2b4! q2b4! ;         \ dual mode spi 8 bit shift out

: q2b2@ ( n -- n )                        \ dual mode read 2 bits from qspi
   qck-0 la qck-1 la
   2* qd1@ 1 and or
   2* qd0@ 1 and or
\   dup .
   ;
: q2b4@  ( n -- n ) q2b2@ q2b2@ ;         \ dual mode shift in 4 bits from spi  
: q2b8@  ( n -- n ) q2b4@ q2b4@ ;         \ dual mode shift in 8 bits from spi

\ ********** quad spi mode ***************
: q4b4! ( n -- n )                        \ quad spi 4 bit shift out
   qck-0 la
   dup 0< qd3! 2*
   dup 0< qd2! 2*
   dup 0< qd1! 2*
   dup 0< qd0! 2*
   qck-1 la ;
: q4b8! ( n -- n )  q4b4! q4b4! ;         \ quad spi 8 bit shift out
    
: q4b4@ ( n -- n )                        \ quad spi mode shift in 4 bits
   qck-0 la qck-1 la
   2* qd3@ 1 and or
   2* qd2@ 1 and or
   2* qd1@ 1 and or
   2* qd0@ 1 and or
\   dup .
   ;
: q4b8@  ( n -- n ) q4b4@ q4b4@ ;         \ quad mode shift in 8 bits from qspi  

\ ********** qspi mode switch ************
: q1<  ( -- ) qd1< ;                      \ single spi input mode
: q1>  ( -- ) qd0> ;                      \ single spi output mode
: q2<  ( -- ) qd0< qd1< ;                 \ dual spi input mode
: q2>  ( -- ) qd0> qd1> ;                 \ dual spi output mode
: q4<  ( -- ) qd0< qd1< qd2< qd3< ;       \ quad spi input mode
: q4>  ( -- ) qd0> qd1> qd2> qd3> ;       \ quad spi output mode

' q1> variable qd>-hook                   \ hook switch to output mode
' q1< variable qd<-hook                   \ hook switch to input mode
' q1b8! variable qb!-hook                 \ hook byte shift out
' q1b8@ variable qb@-hook                 \ hoot byte shift in

: qd>  ( -- ) qd>-hook @ execute ;        \ switch to output 
: qd<  ( -- ) qd<-hook @ execute ;        \ switch to input
: qb8!  ( n -- n ) qb!-hook @ execute ;   \ shift out 1 byte
: qb8@  ( n -- n ) qb@-hook @ execute ;   \ shift in 1 byte
: q1 ( -- )                               \ set single spi mode
   ['] q1>   qd>-hook !
   ['] q1<   qd<-hook !
   ['] q1b8! qb!-hook !
   ['] q1b8@ qb@-hook !
   \ in single/dual spi qd2 is /write protect so we set it to 1
   qd2<-pu                       
   \ in single/dual spi qd3 this /hold so we disable hold - 1
   qd3<-pu ;
: q2 ( -- )                               \ set dual spi mode
   ['] q2>   qd>-hook !
   ['] q2<   qd<-hook !
   ['] q2b8! qb!-hook !
   ['] q2b8@ qb@-hook !
   \ in single/dual spi qd2 is /write protect so we set it to 1
   qd2<-pu                       
   \ in single/dual spi qd3 this /hold so we disable hold - 1
   qd3<-pu ;
: q4 ( -- )                               \ set quad qspi mode
   ['] q4> qd>-hook !
   ['] q4< qd<-hook !
   ['] q4b8! qb!-hook !
   ['] q4b8@ qb@-hook ! ;

: q-start  ( -- ) la qd> la qcs-0 la ;    \ start transfer
: q-end  ( -- ) qcs-1 la ;                \ finish qspi transfer
: qc!  ( b -- 0 ) 24 lshift qb8! ;        \ send 1 byte

\ ********** flash driver ****************
$50 constant Q_CLEAR_FLAG_REG
$70 constant Q_READ_FLAG_REG
$03 constant Q_READ
$0B constant Q_READ_FAST
$9E constant Q_READ_ID
$B5 constant Q_READ_NV_CFG_REG
$B1 constant Q_WRITE_NV_CFG_REG
$05 constant Q_READ_STAT_REG
$85 constant Q_READ_VOL_CFG_REG
$81 constant Q_WRITE_VOL_CFG_REG
$66 constant Q_RESET_ENABLE
$99 constant Q_RESET_MEM
$04 constant Q_WRITE_DIS
$06 constant Q_WRITE_ENA

: read-id ( a -- )                        \ read id to buffer 20 bytes
   q-start Q_READ_ID qc! drop
   dup 20 + swap do 0 qb8@ i c! loop q-end ;
: .id  ( -- )                             \ print id
   q-start Q_READ_ID qc! drop
   20 0 do 0 qb8@ x.2 space loop q-end cr ;
 
\ ********** read-block ******************
: q-dump ( len qa -- )
   q-start Q_READ qc! drop 8 lshift
   qb8! qb8! qb8! swap do qc@ 
\ ********** write block *****************


\ ********** soft reset ******************
