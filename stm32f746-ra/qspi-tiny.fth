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

PB6  constant QS                                    \ QSPI_NCS
PB2  constant QC                                    \ QSPI_CLK
PD11 constant QD0                                   \ QSPI_D0
PD12 constant QD1                                   \ QSPI_D1
PE2  constant QD2                                   \ QSPI_D2
PD13 constant QD3                                   \ QSPI_D3

: q-g>  ( pin -- ) gpio-output ;                    \ configure pin as gpio output
: q-g<  ( pin -- ) 0 over gpio-pupd! gpio-input ;   \ input no pull up/down
: q-g<U ( pin -- ) 1 over gpio-pupd! gpio-input ;   \ input pullup
: q-g<D ( pin -- ) 2 over gpio-pupd! gpio-input ;   \ input pulldown
: g-on  ( pin -- ) 1 swap gpio-clk! ;               \ gpio clock on
: q-on<U ( pin -- ) dup g-on q-g<U ;                \ gpio clk on input pullup
: q-on<Ux2 ( 2xpin -- ) q-on<U q-on<U ;             \ 2 pins inp pu - p p 
: q-on<Ux4 ( 4xpin -- ) q-on<Ux2 q-on<Ux2 ;         \ 4 pins inp pu - p p p p
: q-on<Ux6 ( 6xpin -- ) q-on<Ux4 q-on<Ux2 ;         \ 6 pins inp pu - p p p p p p
: q-ini ( -- ) QS QC QD0 QD1 QD2 QD3 q-on<Ux6 ;     \ gpio clk on input pullup
: QD0-1 ( -- ) QD0 pin-on  ! ;                      \ set QD0 to 1
: QD0-0 ( -- ) QD0 pin-off ! ;                      \ set QD0 to 0
: QD1-1 ( -- ) QD1 pin-on  ! ;                      \ set QD1 to 1
: QD1-0 ( -- ) QD1 pin-off ! ;                      \ set QD1 to 0
: QD2-1 ( -- ) QD2 pin-on  ! ;                      \ set QD2 to 1
: QD2-0 ( -- ) QD2 pin-off ! ;                      \ set QD2 to 0
: QD3-1 ( -- ) QD3 pin-on  ! ;                      \ set QD3 to 1
: QD3-0 ( -- ) QD3 pin-off ! ;                      \ set QD3 to 0
: QS-1  ( -- ) QS  pin-on  ! ;                      \ set CS  to 1
: QS-0  ( -- ) QS  pin-off ! ;                      \ set CS  to 0
: QC-1  ( -- ) QC  pin-on  ! ;                      \ set CLK to 1
: QC-0  ( -- ) QC  pin-off ! ;                      \ set CLK to 0

: qd0@ ( n -- n ) 2* QD0  gpio-idr @ QD0 pin# rshift 1 and or ;
: qd1@ ( n -- n ) 2* QD1  gpio-idr @ QD1 pin# rshift 1 and or ;
: qd2@ ( n -- n ) 2* QD2  gpio-idr @ QD2 pin# rshift 1 and or ;
: qd3@ ( n -- n ) 2* QD3  gpio-idr @ QD3 pin# rshift 1 and or ;

\ : qd0! ( n -- n ) dup 0< if QD0-1 else QD0-0 then 2* ;
\ : qd1! ( n -- n ) dup 0< if QD1-1 else QD1-0 then 2* ;
\ : qd2! ( n -- n ) dup 0< if QD2-1 else QD2-0 then 2* ;
\ : qd3! ( n -- n ) dup 0< if QD3-1 else QD3-0 then 2* ;

: qd0! ( n -- n ) dup #31 rshift dup 1 xor #16 lshift or QD0 pin# lshift QD0 gpio-bsrr ! 2* ;
: qd1! ( n -- n ) dup #31 rshift dup 1 xor #16 lshift or QD1 pin# lshift QD1 gpio-bsrr ! 2* ;
: qd2! ( n -- n ) dup #31 rshift dup 1 xor #16 lshift or QD2 pin# lshift QD2 gpio-bsrr ! 2* ;
: qd3! ( n -- n ) dup #31 rshift dup 1 xor #16 lshift or QD3 pin# lshift QD3 gpio-bsrr ! 2* ;


: qd0> ( -- ) QD0 q-g> ;                          \ QD0 output mode
: qd1> ( -- ) QD1 q-g> ;                          \ QD1 output mode
: qd2> ( -- ) QD2 q-g> ;                          \ QD2 output mode
: qd3> ( -- ) QD3 q-g> ;                          \ QD3 output mode
: qd0< ( -- ) QD0 q-g< ;                          \ QD0 input  mode
: qd1< ( -- ) QD1 q-g< ;                          \ QD1 input  mode
: qd2< ( -- ) QD2 q-g< ;                          \ QD2 input  mode
: qd3< ( -- ) QD3 q-g< ;                          \ QD3 input  mode
: q1-init ( -- )                                  \ single mode init
   QD0-1 QD1-1 QS-1 QC-1                          \ all lines to idle
   QD0 QS QC q-g> q-g> q-g>                       \ q0,qc,qs output
   QD1 q-g< ;                                     \ q1 input 
: q1>  ( -- )  ;                                  \ q1-write mode
: q1<  ( -- )  ;                                  \ q1-read mode

: q1b1@ ( n -- n )  qc-0 qc-1 qd1@ ;              \ single input 1 bit
: q1b2@ ( n -- n )  q1b1@ q1b1@ ;                 \ single input 2 bit
: q1b4@ ( n -- n )  q1b2@ q1b2@ ;                 \ single input 4 bit
: q1b8@ ( n -- n )  q1b4@ q1b4@ ;                 \ single input 8 bit
: q1b1! ( n -- n )  qc-0 qd0! qc-1 ;              \ single output 1 bit
: q1b2! ( n -- n )  q1b1! q1b1! ;                 \ single output 2 bit
: q1b4! ( n -- n )  q1b2! q1b2! ;                 \ single output 4 bit
: q1b8! ( n -- n )  q1b4! q1b4! ;                 \ single output 8 bit
: q1c!  ( n --   )  #24 lshift q1b8! ;            \ single output 1 byte
: q1c@  (   -- n )  0 q1b8@ ;                     \ single input 1 byte

: q2-init ( -- ) q1-init qd1> ;                   \ same as q1 init but q1 as output
: q2>   (   --   ) QD0-1 QD1-1 qd0> qd1> ;        \ dual output mode
: q2<   (   --   ) QD0-1 QD1-1 qd0< qd1< ;        \ dual input mode
: q2b2! ( n -- n ) qc-0 qd1! qd0! qc-1 ;          \ dual output 2 bit
: q2b8! ( n -- n ) q2b2! q2b2! q2b2! q2b2! ;      \ dual output 8 bit
: q2b2@ ( n -- n ) qc-0 qc-1 qd1@ qd0@ ;          \ dual input 2 bit
: q2b8@ ( n -- n ) q2b2@ q2b2@ q2b2@ q2b2@ ;      \ dual input 8 bit
: q2c!  ( n --   ) #24 lshift q2b8! ;
: q2c@  (   -- n ) 0 q2b8@ ;

: q4-init ( -- ) QD2-1 QD3-1 qd2> qd3> q2-init ; \ quad mode init
: q4> ( -- ) QD2-1 QD3-1 qd2> qd3> q2> ;         \ quad output mode
: q4< ( -- ) qd2< qd3< q2< ;                       \ quad input mode
: q4b4! ( n -- n )                                 \ quad mode 4 bit transfer
   qc-0 qd3! qd2! qd1! qd0! qc-1 ;
: q4b8! ( n -- n ) q4b4! q4b4! ;                   \ quad output 8 bit
: q4b4@ ( n -- n ) qc-0 qc-1 qd3@ qd2@ qd1@ qd0@ ;     \ quad input 4 bit
: q4b8@ ( n -- n ) q4b4@ q4b4@ ;                   \ quad input 8 bit
: q4c! ( n -- ) #24 lshift q4b8! ;                 \ quad mode output 1 byte
: q4c@ ( -- n ) 0 q4b8@ ;                          \ quad mode read one byte

\ : q-block@ ( ba len qa -- )                        \ read a block from qspi
\    q-read over + swap do qc@ i c! loop q-end ;
\   ;
\ : q-block! ( ba l qa -- )                          \ write a block to qspi
\   q-write-ena q-write over + swap do i c@ qc! loop q-end ;
\   ;
