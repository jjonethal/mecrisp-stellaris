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
\ 2016sep5jjo initial version, add docs
\
\ C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf
\ C:\Users\jeanjo\Downloads\stm\DM00166116 STM32F746NG datasheet.pdf
\ require utils.fth
\ require gpio.fth
\ require rcc.fth


\ I2C_SDA (PB9)  package pin (D14) 
\ I2C_SCL (PB8)  package pin (D14) I2C1_SCL

\ PH7 - LCD_SCL / AUDIO_SCL / I2C3_SCL
\ PH8 - LCD_SDA / AUDIO_SDA / I2C3_SDA

\ ********** i2c global states **********

\ ********** i2c interface functions ****
: i2c-init ( p -- ) ;
: i2c-stop ( p -- ) ;
: i2c-rcc-on ( p -- ) ;
: i2c-gpio-ena ( p -- ) ;
: i2c-int-ena ( p -- ) ;
: i2c-int-dis ( p -- ) ;
: i2c-int-handler ( -- ) ;

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
: i2c-start-7-write (  numbytes slaveadr -- ) ;
   $7F and                               \ num bytes and slave address
   swap $FF and #16 lshift or
   i2c_cr2 !
   i2c-start ;         \ start
   