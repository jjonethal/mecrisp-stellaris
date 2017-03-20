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

\ i2c driver
\ file i2c.fth
\ ********** history ********************
\ 2017jan31jjo copy to stm32l476
\ 2016oct17jjo continue init, addresses
\ 2016sep5jjo initial version, add docs
\
\ ********** documents online reference **
\            offline *********************
\ programming manual
\   http://www.st.com/resource/en/programming_manual/dm00046982.pdf
\ data sheet
\   C:\Users\jeanjo\Downloads\stm\en.DM00108832 STM32L476xx datasheet .pdf
\   http://www.st.com/resource/en/datasheet/stm32l476je.pdf
\ Reference manual
\   http://www.st.com/resource/en/reference_manual/dm00083560.pdf
\   C:\Users\jeanjo\Downloads\stm\en.DM00083560 RM0351 STM32L4x6 advanced ARM®-based 32-bit MCUs .pdf
\ discovery kit manual
\   C:\Users\jeanjo\Downloads\stm\DM00172179 UM1879 User manual Discovery kit with STM32L476VG MCU.pdf
\ ********** external libraries **********
\ require utils.fth
\ require gpio.fth
\ require rcc.fth

\ ********** i2c pin definitions *********
\ I2C_SDA (PB9)  package pin (D14) 
\ I2C_SCL (PB8)  package pin (D14) I2C1_SCL

\ PH7 - LCD_SCL / AUDIO_SCL / I2C3_SCL
\ PH8 - LCD_SDA / AUDIO_SDA / I2C3_SDA

\ ********** i2c address calc ************
: i2c-port ( n -- a )                     \ calculate i2c base addres from number
   #7 and $14 + #10 lshift                \ nr 1..4
   $40000000 or 1-foldable ;
: i2c-nr ( a -- n )                       \ i2c-addr -> i2c nr
   #10 rshift #5 - 7 and 1-foldable ;

\ ********** i2c DCKCFGR2 ****************
decimal
: i2c-clk-m ( n -- m )                    \ calculate i2c clock mask from i2c# 
   2 * #14 + 3 swap lshift 1-foldable ;   \ DCKCFGR2 register

\ ********** i2c driver interface var ****
3 i2c-port variable i2c_base              \ i2c base address of port

\ ********** i2c base address words ******
: i2c_base@ ( -- a ) i2c_base @ ;         \ fetch i2c base address
: i2c# ( -- n ) i2c_base@ i2c-nr ;        \ get current i2c port number

\ ********** i2c timings *****************
   1   #28 lshift                         \ PRESC
   4   #20 lshift or                      \ SCLDEL
   $2  #16 lshift or                      \ SDADEL
   $F   #8 lshift or                      \ SCLH
   $13            or                      \ SCLL
   constant i2c-8MHz-100K                 \ input clock 8 MHz - i2c clock 100 kHz

   $3  #28 lshift                         \ PRESC
   $4  #20 lshift or                      \ SCLDEL
   $2  #16 lshift or                      \ SDADEL
   $F   #8 lshift or                      \ SCLH
   $13            or                      \ SCLL
   constant i2c-16MHz-100K                \ input clock 16 MHz - i2c clock 100 kHz

\ ********** i2c registers ***************
: i2c_cr1! ( n -- ) i2c_base@ ! ;         \ store value to i2c_cr1 
: i2c_cr2  ( -- a ) i2c_base@ 4 + ;       \ address of i2c_cr2 register
: i2c_timingr ( -- a ) i2c_base@ $10 + ;  \ I2C_TIMINGR
: i2c_isr ( -- a ) i2c_base@ $18 + ;      \ I2C_ISR
\ ********** i2c interface functions ****
: i2c-rcc-on ( -- )                       \ turn on i2c clock
   i2c# 20 + 1 swap lshift
   RCC_APB1ENR bis ! ;
: i2c-in-clk ( n -- )                     \ set timing clock source
    i2c# i2c-clk-m DCKCFGR2 bits! ;   
: i2c-init ( -- )                         \ initialize i2c interface
   0 over i2c_cr1! wait-3-clk             \ reset i2c instance wait 3 APB clk
   1 swap i2c_cr1! ;                      \ enable i2c
: i2c-stop ( p -- )                       \ stop generation
   1 14 lshift i2c_cr2 bis! ;
: i2c-gpio-ena ( p -- )                   \ enable gpio pin for i2c port
   dup port# rcc-gpio-clk-on              \ turn clock on
   4 gpio-mode-af! ;                      \ Alternate funcion mode 4 for i2c
: i2c-int-ena ( p -- ) ;
: i2c-int-dis ( p -- ) ;
: i2c-int-handler ( -- )                  \ this is called from interrupt
   ipsr @       endcase ;

: i>c #47 - dup #3 rshift dup 0<> -2 and + + 7 and ; 

: i2c-timing ( -- )                       \ 16MHz i2c clock 100 khz
   2 i2c-in-clk                           \ set hsi cock source
   i2c-16MHz-100K i2c_timingr ! ;

: bis/bic! ( m a f -- )                   \ depending of flag set or reset bits 
   if bis! else bic ! then ;

: i2c-state-init ( -- ) ;
: i2c-start-read ( a -- ) ;
: i2c-adr-mode-10bit ( adrMode -- )
   0<> 1 #11 lshift i2c-cr2 bits! ;
: i2c-txis? ( -- f )
   #2 i2c_isr bit@ ;
: i2c-start ( -- )                        \ start i2c master transfer
   1 #13 lshift i2c_cr2 bis! ;
: i2c-tx-adr ( a -- )                     \ set i2c target address
   $3ff i2c_cr2 bits! ;
: i2c-auto-end ( n -- )                   \ set auto end on/off
   1 #25 lshift i2c_cr2 bits! ;
: i2c-write ( numbytes slaveadr -- )      \ start tx 7 bit adr
   $FE and                                \ num bytes and slave address
   swap $FF and #16 lshift or             \
   1 i2c-auto-end                         \ enable auto end
   i2c_cr2 !
   i2c-start ;                            \ start
: i2c-receive ( numbytes slaveadr -- )    \ start i2c receiving

