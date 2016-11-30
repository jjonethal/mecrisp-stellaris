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


: i2c-init ( -- )   i2c-init-gpio i2c-set-timing i2c-idle i2c-state-set ;
:   i2c-s-idle  ;
:   i2c-s-tx-start ;
:   i2c-s-tx-bytes ;
:   i2c-s-rx-start ;
:   i2c-s-rx-send-start ;
:   i2c-s-tx-bytes ;



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
