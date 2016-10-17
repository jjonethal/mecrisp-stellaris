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

\ i2c driver
\ file i2c.fth
\ ********** history ********************
\ 2016oct17jjo continue init, addresses
\ 2016sep5jjo initial version, add docs
\
\ C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf
\ C:\Users\jeanjo\Downloads\stm\DM00166116 STM32F746NG datasheet.pdf
\ require utils.fth
\ require gpio.fth
\ require rcc.fth

\ ********** i2c pin definitions ********
\ I2C_SDA (PB9)  package pin (D14) 
\ I2C_SCL (PB8)  package pin (D14) I2C1_SCL

\ PH7 - LCD_SCL / AUDIO_SCL / I2C3_SCL
\ PH8 - LCD_SDA / AUDIO_SDA / I2C3_SDA

$40005400 constant i2c1_base
$40005800 constant i2c2_base
$40005C00 constant i2c3_base
$40006000 constant i2c4_base

i2c3_base     constant i2c_base 
i2c_base      constant i2c_cr1 
i2c_base 4 or constant i2c_cr2 

\ ********** i2c timings ****************
   1   #28 lshift                        \ PRESC
   4   #20 lshift or                     \ SCLDEL
   $2  #16 lshift or                     \ SDADEL
   $F   #8 lshift or                     \ SCLH
   $13            or                     \ SCLL
   constant i2c-8MHz-100K

   3   #28 lshift                        \ PRESC
   4   #20 lshift or                     \ SCLDEL
   $2  #16 lshift or                     \ SDADEL
   $F   #8 lshift or                     \ SCLH
   $13            or                     \ SCLL
   constant i2c-16MHz-100K


\ ********** i2c global states **********

: i2c_cr1! ( n -- )                      \ store value to i2c_cr1 
   i2c_cr1 ! ;

\ ********** i2c interface functions ****
: i2c-init ( p -- )                     \ initialize i2c interface
   0 i2c_cr1! wait-3-clk                \ reset i2c instance wait 3 APB clk
   1 i2c_cr1! ;                         \ enable i2c
: i2c-stop ( p -- ) ;
: i2c-rcc-on ( p -- ) ;
: i2c-gpio-ena ( p -- ) ;
: i2c-int-ena ( p -- ) ;
: i2c-int-dis ( p -- ) ;
: i2c-int-handler ( -- ) ;

   

: i2c-timing ( -- )                      \ 8MHz i2c clock 100 khz
   i2c-8MHz-100K I2C_TIMINGR ! ;

: bis/bic! ( m a f -- )                  \ 
   if bis! else bic ! then ;

: i2c-state-init ( -- ) ;
: i2c-start-read ( a -- ) ;
: i2c-adr-mode-10bit ( adrMode -- )
   0<> 1 #11 lshift i2c-cr2 bits! ;
: i2c-txis? ( -- f )
   #2 i2c_isr bit@ ;
: i2c-start ( -- )                       \ start i2c master transfer
   1 #13 lshift i2c_cr2 bis! ;
: i2c-tx-adr ( a -- )                    \ set i2c target address
   $3ff I2C_CR2 bits! ;
: i2c-write ( numbytes slaveadr -- )     \ start tx 7 bit adr
   $FF and                               \ num bytes and slave address
   swap $FF and #16 lshift or            \
   1 #25 lshift or                       \ enable auto end
   i2c_cr2 !
   i2c-start ;                           \ start
: i2c-receive ( numbytes slaveadr -- )   \ start i2c receiving