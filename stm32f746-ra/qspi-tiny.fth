\ qspi-tiny.fth
\ Copyright Jean Jonethal 2015, 2016, 2017
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

PB6  constant QS 
PB2  constant QC 
PD11 constant QD0
PD12 constant QD1
PE2  constant QD2
PD13 constant QD3

: times ( a n -- ) 0 do dup >r execute r> loop drop ; \ invoke adr n times
: q>  ( pin -- ) gpio-output ;
: q<  ( pin -- ) 0 over gpio-pupd! gpio-input ;  \ input no pull up/down
: q<U ( pin -- ) 1 over gpio-pupd! gpio-input ; \ input pullup
: q<D ( pin -- ) 2 over gpio-pupd! gpio-input ; \ input pulldown
: g-on ( pin -- ) 1 swap gpio-clk! ;            \ gpio clock on
: q-on<U ( pin -- ) dup g-on q<U ;              \ gpio clk on input pullup
: q-ini ( -- ) QS QC Q0 Q1 Q2 Q3 ['] q-on<U 6 times ;

: q-block@ ( ba len qa -- ) \ read a block from qspi
   q-read over + swap do qc@ i c! loop ;
  ;
: q-block! ( qa ba l -- ) \ write a block to qspi

  ;
