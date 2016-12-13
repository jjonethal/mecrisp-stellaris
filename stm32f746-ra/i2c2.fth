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
\ file i2c2-test.fth
\ ********** history ********************
\ 2016nov24jjo initial version

\ C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf
\ http://www.st.com/resource/en/reference_manual/dm00124865.pdf
\ C:\Users\jeanjo\Downloads\stm\DM00166116 STM32F746NG datasheet.pdf
\ http://www.st.com/resource/en/datasheet/stm32f745ie.pdf
\ Wolfson audio codec
\ C:\Users\jeanjo\Downloads\doc\circuits\WM8994_v4.4.pdf
\ http://www.cirrus.com/en/pubs/proDatasheet/WM8994_v4.4.pdf
\ require utils.fth
\ require gpio.fth
\ require rcc.fth


: ftab: ( -- )  ( name )                 \ create a function table
   <builds does> swap 2 lshift + @ execute ;
: enum ( n -- n + 1 ) ( "name" )         \ enumeration constant
   dup constant 1+ ;
: enum; ( n -- ) drop ;                  \ finish enumeration

0 enum i2c-s-init#
enum;

: i2c-next-byte  ( -- b )                \ next byte to transfer or -1 on end
    i2c-byte-count @ i2c-len @ <
    if i2c-byte-count @ i2c-buffer @ +
      c@ i2c-byte-count 1 +!
    else -1
    then ;
   
: i2c-next-byte? ( -- f )                \ bytes to xfer, decr num-bytes   
   i2c-num-bytes @ dup 0<> if dup 1- i2c-num-bytes ! then ;
: i2c-tx-next-byte ( -- )
   i2c-next-byte? if i2c-next-byte i2c_txdr ! i2c-s-tx-bytes# ->
                  else i2c-stop  i2c-s-idle#  ->  then ; 


: i2c-s-init ( -- )   i2c-init-gpio i2c-set-timing -> i2c-s-idle ;
:   i2c-s-idle i2c-req-rx? if i2c-rx-start else i2c-tx-start then ;
:   i2c-s-tx-started
      i2c_isr case
        dup i2c_isr_nackf and ?of -> i2c-s-idle     endof
        dup i2c_isr_txis  and ?of -> i2c-s-tx-bytes endof
      endcase ;
:   i2c-s-tx-bytes
      i2c_isr case
        dup ;
:   i2c-s-rx-start ;
:   i2c-s-rx-send-start ;
:   i2c-s-tx-bytes ;




: i2c-start-write ( -- )
   i2c-set-adr-mode i2c-set-slave-addr i2c-set-rw-mode
   i2c-bytes-to-xfer i2c-start ;
: i2c-s-byte-sent  ( -- ) \ a byte was sent
   i2c-more-bytes? if i2c-send-byte else i2c-stop then ;
: i2c-s-stopped ( -- )
: i2c-s-started i2c-send-byte i2c-more-bytes? if -> i2c-byte-sent ;
: i2c-s-idle 

: codec-send-register ( d r -- ) 
    codec-i2c-adr i2c-start
    dup ;
: codec-send-data 
: codec-read-register ;

0 variable i2c-state

: i2c-handler ( -- )
   ipsr i2c-irq =
   if i2c-state @ dup 0<> if execute then
   then ;

: codec-volume
   i2c-start
   i2c-send-reg
   i2c-send-data
   ;
0 variable i2c-state
: i2c-state-sending-data
   i2c-more-bytes?
   if i2c-send-byte
   else i2c-send-stop
   then ;
: i2c-write-sequential
   i2c-init
   i2c-set-dest-adr
   i2c-set-bit-mode
   i2c-set-num-bytes
   i2c-start
   ' i2c-state-sending-data i2c-state ! ;
   
   i2c-bytes-to-send#
   0 do 
      i2c-send-byte
      i2c-wait-sent
   loop
   i2c-stop ;
