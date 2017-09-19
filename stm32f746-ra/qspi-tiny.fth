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
: q<  ( pin -- ) 0 over gpio-pupd! gpio-input ;   \ input no pull up/down
: q<U ( pin -- ) 1 over gpio-pupd! gpio-input ;   \ input pullup
: q<D ( pin -- ) 2 over gpio-pupd! gpio-input ;   \ input pulldown
: g-on ( pin -- ) 1 swap gpio-clk! ;              \ gpio clock on
: q-on<U ( pin -- ) dup g-on q<U ;                \ gpio clk on input pullup
: q-on<Ux2 ( 2xpin -- ) q-on<U q-on<U ;
: q-on<Ux4 ( 4xpin -- ) q-on<Ux2 q-on<Ux2 ;
: q-on<Ux6 ( 6xpin -- ) q-on<Ux4 q-on<Ux2 ;
: q-ini ( -- ) QS QC QD0 QD1 QD2 QD3 q-on<Ux6 ;   \ gpio clk on input pullup
: Q0-1 ( -- ) QD0 pin-on ! ;
: Q0-0 ( -- ) QD0 pin-off ! ;
: Q1-1 ( -- ) QD1 pin-on ! ;
: Q1-0 ( -- ) QD1 pin-off ! ;
: Q2-1 ( -- ) QD2 pin-on ! ;
: Q2-0 ( -- ) QD2 pin-off ! ;
: Q3-1 ( -- ) QD3 pin-on ! ;
: Q3-0 ( -- ) QD3 pin-off ! ;
: QS-1 ( -- ) QS  pin-on ! ;
: QS-0 ( -- ) QS  pin-off ! ;
: QC-1 ( -- ) QC  pin-on ! ;
: QC-0 ( -- ) QC  pin-off ! ;
: q0@ ( n -- n ) 2* QD0  gpio-in# QD0  gpio-idr bit@ 1 and or ;
: q1@ ( n -- n ) 2* QD1  gpio-in# QD1  gpio-idr bit@ 1 and or ;
: q2@ ( n -- n ) 2* QD2  gpio-in# QD2  gpio-idr bit@ 1 and or ;
: q3@ ( n -- n ) 2* QD3  gpio-in# QD3  gpio-idr bit@ 1 and or ;
: qb0! ( n -- n ) dup 0< if Q0-1 else Q0-0 then 2* ;
: qb1! ( n -- n ) dup 0< if Q1-1 else Q1-0 then 2* ;
: qb2! ( n -- n ) dup 0< if Q2-1 else Q2-0 then 2* ;
: qb3! ( n -- n ) dup 0< if Q3-1 else Q3-0 then 2* ;
: q0> QD0 Q> ;
: q1> QD1 Q> ;
: q2> QD2 Q> ;
: q3> QD3 Q> ;
: q0< QD0 Q< ;
: q1< QD1 Q< ;
: q2< QD2 Q< ;
: q3< QD3 Q< ;
: q-1-init ( -- )                                 \ single mode init
   Q0-1 Q1-1 QS-1 QC-1                            \ all lines to idle
   Q0 QS QC q> q> q>                              \ q0,qc,qs output
   Q1 q< ;                                        \ q1 input 
: q-1>  ( -- )  ;                                 \ q1-write mode
: q-1<  ( -- )  ;                                 \ q1-read mode

: q1b1@ ( n -- n )  qc-0 qc-1 q1@ ;
: q1b8@ ( n -- n )  q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ ;
: q1b1! ( n -- n )  qc-0 qb0! qc-1 ;              \ output single bit via qd0
: q1b8! ( n -- n )  q1b1! q1b1! q1b1! q1b1! q1b1! q1b1! q1b1! q1b1! ;
: q1c! ( n -- ) #24 lshift q1b8! ;
: q1c@ ( -- n ) 0 q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ q1b1@ ;

: q-2-init ( -- ) q-1-init q1 q> ;                \  same as q1 init but q1 as output
: q-2> ( -- ) Q0-1 Q1-1 Q0> Q1> ;                 \ dual output mode
: q-2< ( -- ) Q0-1 Q1-1 Q0< Q1< ;                 \ dual input mode
: q2b2! ( n -- n ) qc-0 qb1! qb0! qc-1 ;
: q2b8! ( n -- n ) q2b2! q2b2! q2b2! q2b2! ;      \ dual output 8 bit
: q2b2@ ( n -- n ) qc-0 qc-1 q1@ q0@ ;            \ dual input 2 bit
: q2b8@ ( n -- n ) q2b2@ q2b2@ q2b2@ q2b2@ ;      \ dual output 8 bit
: q2c! ( n -- ) #24 lshift q2b8! ;
: q2c@ ( -- n ) 0 q2b8@ ;

: q-4-init ( -- ) q2-1 q3-1 q2> q3> q-2-init ;    \ quad mode init
: q-4> ( -- ) q2-1 q3-1 Q2> Q3> q-2> ;            \ quad output mode
: q-4< ( -- ) Q2< Q3< Q-2< ;                      \ quad input mode
: q4b4! ( n -- n ) qc-0 qb3! qb2! qb1! qb0! qc-1 ;
: q4b8! ( n -- n ) q4b4! q4b4! ;                  \ dual output 8 bit
: q4b4@ ( n -- n ) qc-0 qc-1 q3@ q2@ q1@ q0@ ;    \ dual input 2 bit
: q4b8@ ( n -- n ) q4b4@ q4b4@ ;
: q4c! ( n -- ) #24 lshift q4b8! ;
: q4c@ ( -- n ) 0 q4b8@ ;

: q-block@ ( ba len qa -- ) \ read a block from qspi
   q-read over + swap do qc@ i c! loop q-end ;
  ;
: q-block! ( ba l qa -- ) \ write a block to qspi
  q-write-ena q-write over + swap do i c@ qc! loop q-end ;
  ;
