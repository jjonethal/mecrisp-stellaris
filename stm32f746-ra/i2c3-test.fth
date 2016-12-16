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

\ file        : i2c3-test.fth
\ author      : jean jonethal
\ description : i2c driver concept

\ ********** history ***********************************************************
\ 2016dec14jjo rework i2c state machine
\ 2016nov24jjo initial version

\        1         2         3         4         5         6         7         8
\ 345678901234567890123456789012345678901234567890123456789012345678901234567890

\ C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf
\ http://www.st.com/resource/en/reference_manual/dm00124865.pdf
\ C:\Users\jeanjo\Downloads\stm\DM00166116 STM32F746NG datasheet.pdf
\ http://www.st.com/resource/en/datasheet/stm32f745ie.pdf
\ Wolfson audio codec
\ C:\Users\jeanjo\Downloads\doc\circuits\WM8994_v4.4.pdf
\ http://www.cirrus.com/en/pubs/proDatasheet/WM8994_v4.4.pdf
\ stm32f746g-disco user manual
\ C:\Users\jeanjo\Downloads\stm\DM00190424 UM1907 Discovery kit for STM32F7 Series with STM32F746NG MCU en.pdf
\ http://www.st.com/resource/en/user_manual/dm00190424.pdf

\ require utils.fth
\ require gpio.fth
\ require rcc.fth

$90 RCC_BASE + constant RCC_DKCFGR2       \ RCC dedicated clk cfg reg
1 #28 lshift constant SDMMCSEL
1 #27 lshift constant CK48MSEL            \ SDMMC clk src sel
1 #26 lshift constant CECSEL              \ HDMI-CEC clk src sel
3 #24 lshift constant LPTIM1SE            \ Low-power timer 1 clk src sel

\ ********** i2c ports *********************************************************
$40005400 constant I2C1                   \ i2c1 port
$40005800 constant I2C2                   \ i2c2 port
$40005C00 constant I2C3                   \ i2c3 port
$40006000 constant I2C4                   \ i2c4 port

\ project specific settings
I2C3      constant i2c-base

\ ********** i2c error and event numbers ***************************************
#31 #16 + constant I2C1_EV                \ I2C1 event interrupt
#32 #16 + constant I2C1_ER                \ I2C1 error interrupt 
#33 #16 + constant I2C2_EV                \ I2C2 event interrupt
#34 #16 + constant I2C2_ER                \ I2C2 error interrupt 
#72 #16 + constant I2C3_EV                \ I2C3 event interrupt
#73 #16 + constant I2C3_ER                \ I2C3 error interrupt 
#95 #16 + constant I2C4_EV                \ I2C4 event interrupt
#96 #16 + constant I2C4_ER                \ I2C4 error interrupt 

\ ********** i2c timings *******************************************************
   1   #28 lshift                         \ PRESC
   4   #20 lshift or                      \ SCLDEL
   $2  #16 lshift or                      \ SDADEL
   $F   #8 lshift or                      \ SCLH
   $13            or                      \ SCLL
   constant i2c-8MHz-100K                 \ input clock 8 MHz - i2c clk 100 kHz

   $3  #28 lshift                         \ PRESC
   $4  #20 lshift or                      \ SCLDEL
   $2  #16 lshift or                      \ SDADEL
   $F   #8 lshift or                      \ SCLH
   $13            or                      \ SCLL
   constant i2c-16MHz-100K                \ input clock 16 MHz - i2c clk 100 kHz

\ ********** i2c functions *****************************************************
: i2c# ( a -- n )                         \ calculate i2c number from port adr
   I2C1 - #10 rshift 1-foldable ;
: i2c_cr1 ( base -- a )
   0 + 1-foldable ;
: i2c-rcc-on ( -- )                       \ turn on i2c clock
   i2c-base i2c# 20 + 1 swap lshift RCC_APB1ENR bis ! ;
: i2c-clk-m ( n -- m )                    \ calculate i2c clk mask from i2c nr 
   2 * #14 + 3 swap lshift 1-foldable ;   \ for RCC_DCKCFGR2 reg
: i2c-in-clk ( n -- )                     \ set timing clock source
   i2c-base i2c# i2c-clk-m RCC_DKCFGR2 bits! ;   
: i2c-rcc-init ( -- )                     \ turn on i2c clk, hsi timing
   i2c-rcc-on 2 i2c-in-clk ;
: i2c-pe?  ( -- f )
   1 i2c-base i2c_cr1 bit@ ;
: i2c-pe!  ( f -- )
   0<> 1 i2c-base i2c_cr1 bit! ;
: i2c-wait-pe0 ( -- )
   begin i2c-pe? not until pause loop ;
: i2c-wait-pe1 ( -- )
   begin i2c-pe? until pause loop ;
: i2c-reset  ( -- )                       \ reset i2c interface
    0 i2c-pe! i2c-wait-pe0 1 i2c-pe! i2c-wait-pe1 ;
: i2c-start-read  ( a -- )                \ start read on target addr
   
: i2c-write ( d n ia -- )                 \ write data to i2c port
   i2c-start-write i2c-send ;
: i2c-read ( n ia -- )                    \ read data from i2c port
   i2c-start-read i2c-receive ;
: i2c-init ( -- ) 
   i2c-gpio-init i2c-rcc-init ;
