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

\ file rcc.fth

\ ***** rcc definitions *****************
\ http://www.st.com/web/en/resource/technical/document/reference_manual/DM00124865.pdf#page=128&zoom=auto,67,755
$40023800      constant RCC_BASE         \ RCC base address
$00 RCC_BASE + constant RCC_CR           \ RCC clock control register
$1 #18 lshift  constant RCC_CR_HSEBYP    \ HSE clock bypass
$1 #17 lshift  constant RCC_CR_HSERDY    \ HSE clock ready flag
$1 #16 lshift  constant RCC_CR_HSEON     \ HSE clock enable
$1  #1 lshift  constant RCC_CR_HSIRDY    \ Internal high-speed clock ready flag
$1             constant RCC_CR_HSION     \ Internal high-speed clock enable
$04 RCC_BASE + constant RCC_PLLCFGR      \ RCC PLL configuration register
$08 RCC_BASE + constant RCC_CFGR         \ RCC clock configuration register
$20 RCC_BASE + constant RCC_APB1RSTR     \ RCC APB1 peripheral reset register
$30 RCC_BASE + constant RCC_AHB1ENR      \ AHB1 peripheral clock register
$40 RCC_BASE + constant RCC_APB1ENR      \ RCC APB1 peripheral clock enable register
$44 RCC_BASE + constant RCC_APB2ENR      \ APB2 peripheral clock enable register
$88 RCC_BASE + constant RCC_PLLSAICFGR   \ RCC SAI PLL configuration register
$8C RCC_BASE + constant RCC_DKCFGR1      \ RCC dedicated clocks configuration register
$90 RCC_BASE + constant RCC_DKCFGR2      \ RCC dedicated clocks configuration register

$0             constant PLLP/2
$1             constant PLLP/4
$2             constant PLLP/6
$3             constant PLLP/8

$0             constant PPRE/1
$4             constant PPRE/2
$5             constant PPRE/4
$6             constant PPRE/8
$7             constant PPRE/16

$0             constant HPRE/1
$8             constant HPRE/2
$9             constant HPRE/4
$A             constant HPRE/8
$B             constant HPRE/16
$C             constant HPRE/64
$D             constant HPRE/128
$E             constant HPRE/256
$F             constant HPRE/512

$0             constant PLLSAI-DIVR/2
$1             constant PLLSAI-DIVR/4
$2             constant PLLSAI-DIVR/8
$3             constant PLLSAI-DIVR/16


\ ***** rcc words ***********************
: rcc-gpio-clk-on  ( n -- )              \ enable single gpio port clock 0:GPIOA..10:GPIOK
  1 swap lshift RCC_AHB1ENR bis! ;
: rcc-gpio-clk-off  ( n -- )             \ disable gpio port n clock 0:GPIOA..10:GPIOK
  1 swap lshift RCC_AHB1ENR bic! ;
: rcc-ltdc-clk-on ( -- )                 \ turn on lcd controller clock
   #1 #26 lshift RCC_APB2ENR bis! ;
: rcc-ltdc-clk-off  ( -- )               \ tun off lcd controller clock
   #1 #26 lshift RCC_APB2ENR bic! ;
: hse-on  ( -- )                         \ turn on hsi
   RCC_CR_HSEON RCC_CR bis! ;
: hse-stable?  ( -- f )                  \ hsi running ?
   RCC_CR_HSERDY RCC_CR bit@ ;
: hse-wait-stable  ( -- )                \ turn on hsi wait until stable
   begin hse-on hse-stable? until ;
: hse-off  ( -- )                        \ turn off hse
   RCC_CR_HSEON RCC_CR bic! ;
: hse-byp-on  ( -- )                     \ turn on HSE bypass mode
   RCC_CR_HSEBYP RCC_CR bis! ;
: hsi-on  ( -- )                         \ turn on hsi
   RCC_CR_HSION RCC_CR bis! ;
: hsi-stable?  ( -- f )                  \ hsi running ?
   RCC_CR_HSIRDY RCC_CR bit@ ;
: hsi-wait-stable  ( -- )                \ turn on hsi wait until stable
   hsi-on begin hsi-stable? until ;
: clk-source-hsi  ( -- )                 \ set system clock to hsi clock
   RCC_CFGR dup @ $3 bic swap ! ;
: clk-source-hse  ( -- )                 \ set system clock to hse clock
   #1 #3 RCC_CFGR bits! ;
: clk-source-pll  ( -- )                 \ set system clock to pll clock
   #2 #3 RCC_CFGR bits! ;
: pll-off  ( -- )                        \ turn off main pll
   #1 #24 lshift RCC_CR bic! ;
: pll-on  ( -- )                         \ turn on main pll
   #1 #24 lshift RCC_CR bis! ;
: pll-ready?  ( -- f )                   \ pll stable ?
   #1 #25 lshift RCC_CR bit@ ;
: pll-wait-stable  ( -- )                \ wait until pll is stable
   begin pll-on pll-ready? until ;
: pll-clk-src-hse  ( -- )                \ set main pll source to hse
   #1 #22 lshift RCC_PLLCFGR bis! ;
: pll-m!  ( n -- )                       \ set main pll clock pre divider
   $1f RCC_PLLCFGR bits! ;
: pll-m@  ( -- n )                       \ get main pll clock pre divider
   $1f RCC_PLLCFGR bits@ ;
: pll-n!  ( n -- )                       \ set Main PLL (PLL) multiplication factor
   $1ff #6 lshift RCC_PLLCFGR bits! ;
: pll-n@  ( -- n )                       \ get Main PLL (PLL) multiplication factor
   $1ff #6 lshift RCC_PLLCFGR bits@ ;
: pll-p!  ( n -- )                       \ set Main PLL (PLL) divider
   #3 #16 lshift RCC_PLLCFGR bits! ;
: pll-p@  ( n -- )                       \ get Main PLL (PLL) divider
   #3 #16 lshift RCC_PLLCFGR bits@ ;
: pllsai-off  ( -- )                     \ turn off PLLSAI
   #1 #28 lshift RCC_CR bic! ;
: pllsai-on  ( -- )                      \ turn on PLLSAI
   #1 #28 lshift RCC_CR bis! ;
: pllsai-ready?  ( -- f )                \ PLLSAI stable ?
   #1 #29 lshift RCC_CR bit@ ;
: pllsai-wait-stable  ( -- )             \ wait until PLLSAI is stable
   begin pllsai-on pllsai-ready? until ;
: pllsai-n!  ( n -- )                    \ set PLLSAI clock multiplication factor
   $1ff #6 lshift RCC_PLLSAICFGR bits! ;
: pllsai-r!  ( n -- )                    \ set PLLSAI clock division factor
   $7 #28 lshift RCC_PLLSAICFGR bits! ;
: pllsai-divr!  ( n -- )                 \ division factor for LCD_CLK
   $3 #16 lshift RCC_DKCFGR1 bits! ;
: ahb-prescaler! ( n -- )                \ set AHB prescaler
   $F0 RCC_CFGR bits! ;
: apb1-prescaler! ( n -- )               \ set APB1 low speed prescaler
   $7 #10 lshift RCC_CFGR bits! ;
: apb2-prescaler! ( n -- )               \ set APB2 high speed prescaler
   $7 #13 lshift RCC_CFGR bits! ;
