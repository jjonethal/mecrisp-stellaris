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

\ file demo-3.fth
\ sound demo
\ Autor Jean Jonethal
\ 
\ stm32f746g-disco user manual
\ C:\Users\jeanjo\Downloads\stm\DM00190424 UM1907 Discovery kit for STM32F7 Series with STM32F746NG MCU en.pdf
\ http://www.st.com/resource/en/user_manual/dm00190424.pdf

\ stm32f746ng reference manual RM0385
\ C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf
\ http://www.st.com/resource/en/reference_manual/dm00124865.pdf

\ stm32f746ng dataheet DS10916
\ C:\Users\jeanjo\Downloads\stm\DM00166116 STM32F746NG datasheet.pdf
\ http://www.st.com/resource/en/datasheet/stm32f746ng.pdf

\ Wolfson audio codec
\ C:\Users\jeanjo\Downloads\doc\circuits\WM8994_v4.4.pdf
\ http://www.cirrus.com/en/pubs/proDatasheet/WM8994_v4.4.pdf

\ stm32f746ng Programming Manuals
\ http://www.st.com/resource/en/programming_manual/dm00237416.pdf

\ pin allocations
\ B_USER  - PI11 - User button
\ USD_D0  - microsSD card
\ USD_D1  - microsSD card
\ USD_D2  - microsSD card
\ USD_D3  - microsSD card
\ USD_CLK - microSD card clock
\ USD_CMD - microSD
\ USD_DETECT - micro sd-card


\ ********** Audio Interface ************
\ AUDIO_I2C_ADR 00110100
\ AUDIO_SDA -  STM32 PIN PH8  I2C3_SDA/AF4
\ AUDIO_SCL -  STM32 PIN PH7  I2C3_SCL/AF4
\ Audio_INT -  STM32 PIN PD6  
\ SAI2_MCLKA - STM32 PIN PI4
\ SAI2_SCKA  - STM32 PIN PI5
\ SAI2_FSA   - STM32 PIN PI7

#25000000 constant HSE_CLK_HZ
#16000000 constant HSI_CLK_HZ

\ LCD_BL_CTRL - PK3 display led backlight control 0-off 1-on

\ ********** utility functions *************************************************
\ ********** bitfield utility functions ****************************************
: cnt0   ( m -- b )                      \ count trailing zeros with hw support
   dup negate and 1-
   clz negate #32 + 1-foldable ;
: bits@  ( m adr -- b )                  \ get bitfield at masked position
   @ over and swap cnt0 rshift ;         \ e.g $1234 v ! $f0 v bits@ $3 = . (-1)
: bits!  ( n m adr -- )                  \ set bitfield value n to value at masked position
   >R dup >R cnt0 lshift                 \ shift value to proper position
   R@ and                                \ mask out unrelated bits
   R> not R@ @ and                       \ invert bitmask and maskout new bits in current value
   or r> ! ;                             \ apply value and store back
                                         \ example :
                                         \   RCC_PLLCFGR.PLLN = 400 -> #400 $1FF #6 lshift RCC_PLLCFGR bits!
                                         \ PLLN: bit[14:6] -> mask :$1FF << 6 = $7FC0
                                         \ #400 $7FC0 RCC_PLLCFGR bits!
                                         \ $1FF #6 lshift constant PLLN
                                         \ #400 PLLN RCC_PLLCFGR bits!
: u.8 ( n -- )                           \ unsigned output 8 digits
   0 <# # # # # # # # # #> type ;
: x.8 ( n -- )                           \ hex output 8 digits
   base @ hex swap u.8 base ! ;
: x.2 ( n -- )                           \ hex output 2 digits
   base @ hex swap 0 <# # # #> type base ! ;
: cfill ( c n a -- )                     \ fill memory block at address a length
   tuck + swap do dup i c! loop drop ;   \   n with char c
: d2**  ( n -- d )                       \ return 2^n 
   dup #31 > if
     #32 - 1 swap lshift 0 swap
   else
     1 swap lshift 0
   then 1-foldable ;
: dxor ( d d -- d )                      \ double xor
   rot xor -rot xor swap 4-foldable ;
: $. ( -- )                              \ print a dollar sign 
   [char] $ emit ;


\ ********** gpio definitions **************************************************
\ http://www.st.com/web/en/resource/technical/document/reference_manual/DM00124865.pdf#page=195&zoom=auto,67,755
$40020000 constant GPIO-BASE
: gpio ( n -- adr )
   $f and #10 lshift GPIO-BASE or 1-foldable ;
$00         constant GPIO_MODER
$04         constant GPIO_OTYPER
$08         constant GPIO_OSPEEDR
$0C         constant GPIO_PUPDR
$10         constant GPIO_IDR
$14         constant GPIO_ODR
$18         constant GPIO_BSRR
$1C         constant GPIO_LCKR
$20         constant GPIO_AFRL
$24         constant GPIO_AFRH

#0  GPIO    constant GPIOA
#1  GPIO    constant GPIOB
#2  GPIO    constant GPIOC
#3  GPIO    constant GPIOD
#4  GPIO    constant GPIOE
#5  GPIO    constant GPIOF
#6  GPIO    constant GPIOG
#7  GPIO    constant GPIOH
#8  GPIO    constant GPIOI
#9  GPIO    constant GPIOJ
#10 GPIO    constant GPIOK

: pin#  ( pin -- nr )                    \ get pin number from pin
   $f and 1-foldable ;
: port-base  ( pin -- adr )              \ get port base from pin
   $f bic 1-foldable ;
: port# ( pin -- n )                     \ return gpio port number A:0 .. K:10
   #10 rshift $f and 1-foldable ;
: mode-mask  ( pin -- m )
   #3 swap pin# 2* lshift 1-foldable ;
: mode-shift ( mode pin -- mode<< )      \ shift mode by pin number * 2 for
   pin# 2* lshift 2-foldable ;           \  gpio_moder
: set-mask! ( v m a -- )
   tuck @ swap bic rot or swap ! ;
: bsrr-on  ( pin -- v )                  \ gpio_bsrr mask pin on
   pin# 1 swap lshift 1-foldable ;
: bsrr-off  ( pin -- v )                 \ gpio_bsrr mask pin off
   pin# #16 + 1 swap lshift 1-foldable ;
: af-mask  ( pin -- mask )               \ alternate function bitmask
   $7 and #2 lshift $f swap lshift 1-foldable ;
: af-reg  ( pin -- adr )                 \ alternate function register address
   dup $8 and 2/ swap                    \   for pin
   port-base GPIO_AFRL + + 1-foldable ;
: af-shift ( af pin -- af )
   pin# #2 lshift swap lshift 2-foldable ;
: gpio-mode! ( mode pin -- )
   tuck mode-shift swap dup
   mode-mask swap port-base set-mask! ;
: mode-af ( af pin -- )
   #2 over gpio-mode!
   dup af-mask swap af-reg bits! ;
: speed-mode ( speed pin -- )            \ set speed mode 0:low speed 1:medium
   dup pin# 2* #3 swap lshift            \                2:fast 3:high speed
   swap port-base #8 + bits! ;
: mode-af-fast ( af pin -- )
   #2 over speed-mode mode-af ;

\ ********** Flash read access config ******************************************
$40023C00      constant FLASH_ACR
: flash-ws! ( n -- )                     \ set flash latency
   $f FLASH_ACR bits! ;
: flash-prefetch-ena  ( -- )             \ enable prefetch
   #1 #8 lshift FLASH_ACR bis! ;
: flash-art-ena?  ( -- f )               \ ART enable ?
   #1 #9 lshift FLASH_ACR bit@ ;
: flash-art-ena  ( -- )                  \ enable ART
   #1 #9 lshift FLASH_ACR bis! ;
: flash-art-dis  ( -- )                  \ disable ART
   #1 #9 lshift FLASH_ACR bic! ;
: flash-art-reset  ( -- )                \ reset ART
   #1 #11 lshift FLASH_ACR bis! ;
: flash-art-unreset  ( -- )              \ unreset ART
   #1 #11 lshift FLASH_ACR bic! ;
: flash-art-clear  ( -- )                \ clear art cache
   flash-art-ena?
   flash-art-dis
   flash-art-reset
   flash-art-unreset
   if flash-art-ena then ;

\ ********** rcc definitions ***************************************************
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
$40 RCC_BASE + constant RCC_APB1ENR      \ APB1 peripheral clock enable register
$44 RCC_BASE + constant RCC_APB2ENR      \ APB2 peripheral clock enable register
$88 RCC_BASE + constant RCC_PLLSAICFGR   \ RCC SAI PLL configuration register
$8C RCC_BASE + constant RCC_DKCFGR1      \ RCC dedicated clocks config reg 1
$90 RCC_BASE + constant RCC_DKCFGR2      \ RCC dedicated clocks config reg 2

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
: rcc-gpio-clk-on  ( n -- )              \ enable single gpio port clock
  1 swap lshift RCC_AHB1ENR bis! ;       \   0:GPIOA..10:GPIOK
: rcc-gpio-clk-off  ( n -- )             \ disable gpio port n clock
  1 swap lshift RCC_AHB1ENR bic! ;       \   0:GPIOA..10:GPIOK
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
: pll-n!  ( n -- )                       \ set Main PLL (PLL) multiplier
   $1ff #6 lshift RCC_PLLCFGR bits! ;
: pll-n@  ( -- n )                       \ get Main PLL (PLL) multiplier
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
: pllsai-n!  ( n -- )                    \ set PLLSAI clock multiplier
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

\ ***** PWR constants and words *********
$40007000      constant PWR_BASE         \ PWR base address
$00 PWR_BASE + constant PWR_CR1          \ PWR power control register
$04 PWR_BASE + constant PWR_CSR1         \ PWR power control/status register
: overdrive-enable ( -- )                \ enable over drive mode
   #1 #16 lshift PWR_CR1 bis! ;
: overdrive-ready? ( -- f )              \ overdrive ready ?
   #1 #16 lshift PWR_CSR1 bit@ ;
: overdrive-switch-on  ( -- )            \ initiate overdrive switch
   #1 #17 lshift PWR_CR1 bis! ;
: overdrive-switch-ready?  ( -- f )      \ overdrive switch complete
   #1 #17 lshift PWR_CSR1 bit@ ;
: pwr-clock-on  ( -- )                   \ turn on power interface clock
   $01 #28 lshift RCC_APB1ENR bis! ;
: overdrive-on ( -- )                    \ turn on overdrive on
   pwr-clock-on                          \   ( not when system clock is pll )
   overdrive-enable
   begin overdrive-ready? until
   overdrive-switch-on
   begin overdrive-switch-ready? until ;
: voltage-scale-mode-3  ( -- )           \ activate voltage scale mode 3
   1 $03 #14 lshift PWR_CR1 bits! ;
: voltage-scale-mode-1  ( -- )           \ activate voltage scale mode 1
   #3 $03 #14 lshift PWR_CR1 bits! ;

\ ********** usart constants & words *******************************************
$40011000               constant USART1_BASE
$0C                     constant USART_BRR
USART_BRR USART1_BASE + constant USART1_BRR
: usart1-clk-sel!  ( n -- )              \ set usart1 clk source
   $3 RCC_DKCFGR2 bits! ;
: usart1-baud-update!  ( baud -- )       \ update usart baudrate
   #2 usart1-clk-sel!                    \ use hsi clock
   HSI_CLK_HZ over 2/ + swap /           \ calculate baudrate for 16 times
   USART1_BRR ! ;                        \    oversampling

\ ***** clock management ****************
: sys-clk-200-mhz  ( -- )                \ supports also sdram clock <= 200 MHz
   hsi-wait-stable
   clk-source-hsi                        \ switch to hsi clock
   hse-off hse-byp-on hse-on             \ hse bypass mode
   pll-off pll-clk-src-hse               \ pll use hse as clock source
   HSE_CLK_HZ #1000000 / PLL-M!          \ PLL input clock 1 Mhz
   #400 pll-n! PLLP/2 PLL-P!             \ VCO clock 400 MHz
   voltage-scale-mode-1                  \ for flash clock > 168 MHz voltage
   overdrive-on                          \ for flash clock > 180 MHz over drive
   hse-wait-stable                       \ hse must be stable before use
   pll-on
   flash-prefetch-ena                    \ activate prefetch reduce latency
   #6 flash-ws!
   flash-art-clear                       \ prepare cache
   flash-art-ena                         \ turn on cache
   HPRE/1 ahb-prescaler!                 \ 200 MHz AHB
   PPRE/2 apb2-prescaler!                \ 100 MHz APB2
   PPRE/4 apb1-prescaler!                \ 50 MHz APB1
   pll-wait-stable clk-source-pll
   #115200 usart1-baud-update! ;
: pllsai-clk-192-mhz ( -- )              \ 9.6 MHz pixel clock for RK043FN48H
   pllsai-off
   #192 pllsai-n!                        \ 192 mhz
   #5  pllsai-r!                         \ 38.4 mhz
   PLLSAI-DIVR/4 pllsai-divr!            \ 9.6 mhz PLLSAIDIVR = /2
   pllsai-wait-stable ;

   
\ ********** i2c driver ********************************************************
$40005400 constant I2C1                  \ i2c1 port
$40005800 constant I2C2                  \ i2c2 port
$40005C00 constant I2C3                  \ i2c3 port
$40006000 constant I2C4                  \ i2c4 port

#31 #16 + constant I2C1_EV               \ I2C1 event interrupt
#32 #16 + constant I2C1_ER               \ I2C1 error interrupt 
#33 #16 + constant I2C2_EV               \ I2C2 event interrupt
#34 #16 + constant I2C2_ER               \ I2C2 error interrupt 
#72 #16 + constant I2C3_EV               \ I2C3 event interrupt
#73 #16 + constant I2C3_ER               \ I2C3 error interrupt 
#95 #16 + constant I2C4_EV               \ I2C4 event interrupt
#96 #16 + constant I2C4_ER               \ I2C4 error interrupt 

0 variable i2c-state                     \ current state of i2c handler
0 variable i2c-adr                       \ target address
0 variable i2c-nr-bytes-to-send
0 variable i2c-nr-bytes-to-receive
0 variable i2c-job-current 

\ 0 variable i2c-port                      \ i2c base address
I2C3 constant i2c-port                   \ i2c base address

: i2c-nr ( a -- n )
    I2C1 - #10 rshift 1-foldable ;
: test-i2c-nr ( -- f )                   \ test i2c-nr passed -> true
   i2c1 i2c-nr 0 =
   i2c2 i2c-nr 1 = and
   i2c3 i2c-nr 2 = and 
   i2c4 i2c-nr 3 = and ;

0 variable i2c-old-irq-handler
   
: i2c-read-request ( i2c-addr n -- )  ;  \ read n bytes from i2c
: i2c-send-request ( -- ) ;              \ notify driver new job 
: i2c-handler ( -- )                     \ handle irq request
   i2c-state @ dup if execute else drop then ;
: i2c-rcc-bitmask ( i2c-port -- n )      \ calculate i2c bitmask for clock 
    i2c-nr #21 + 1 swap lshift 1-foldable ;
: i2c-reset  ( -- )                      \ perform i2c reset
    i2c-port i2c-rcc-bitmask RCC_APB1RSTR bis! ;
: i2c-unreset  ( -- )                    \ release i2c reset
    i2c-port i2c-rcc-bitmask RCC_APB1RSTR bic! ;
: i2c-clk-on  ( -- )                     \ turn on i2c clock
    i2c-port i2c-rcc-bitmask RCC_APB1ENR bis! ;
: i2c-clk-off  ( -- )                    \ turn off i2c clock
    i2c-port i2c-rcc-bitmask RCC_APB1ENR bic! ;
: i2c-read  ( -- c )                     \ read data from i2c port
   i2c-port $24 + c@ ; 
: i2c-write  ( c -- )                    \ write data to i2c port
   i2c-port $28 + c! ;
: i2c-txe?  ( -- f )                     \ i2c txe ?
   i2c-port $18 + 1 bit@ ;
: i2c-int-ena  ( -- )                    \ enable TCIE+STOPIE+NACKIE+RXIE+TXIE
   $36 i2c-port bis ! ;
: i2c-on ( -- )                          \ turn on i2c port
    i2c-port 1 bis! ;
: i2c-off ( -- )                         \ turn off i2c port
    i2c-port 1 bic! ;
: i2c-clk-src-mask ( i2c-port -- m )     \ generate i2c port mask
    i2c-nr 2* #16 + 3 swap lshift 1-foldable ;
: i2c-clk-src ( -- )                     \ set i2c clock source to APB(PCLK1)
   i2c-port i2c-clk-src-mask RCC_DKCFGR2 bic! ;   \  for this demo
: i2c-timing-cfg ( -- )                  \ configure i2c timing
   \ i2c-clk PCLK1=50MHZ 100khz PRESC=1, SCLDEL=8, SDADEL=0, SCLH=97, SCLL=144
   $10806190 i2c-port $10 + ! ;          \ I2C_TIMINGR
: i2c-isr ( -- a )                       \ i2c-isr addr
   i2c-port $18 + 0-foldable ;
: i2c-isr@ ( -- a )                      \ get i2c status 
   i2c-port $18 + @ ;
: i2c-isr-bit@ ( m -- f )                \ get bit flag from i2c_isr for mask
   i2c-isr bit@ ;
: i2c-sm-adr? ( -- i2ca )                \ i2c received address in slave mode
   i2c-isr @ #17 rshift $7f and ;
: i2c-sm-dir? ( -- f )                   \ direction in slave mode
   $10000 i2c-isr-bit@ ;
: i2c-busy? ( -- f )                     \ get busy flag from i2c_isr
   $8000 i2c-isr-bit@ ;
: i2c-tcr? ( -- f )                      \ get transfer complete reload flag
   $8000 i2c-isr-bit@ ;
: i2c-set-irq-handler ( -- )             \ install irq handler
   i2c-old-irq-handler
   0= if                                 \ backup original handler
     irq-collection @ i2c-handler irq-collection !
     i2c-old-irq-handler !
   then ;
: i2c-init ( -- )                        \ setup i2c port
   i2c-reset
   i2c-clk-on
   i2c-unreset
   i2c-clear-ints
   i2c-set-irq-handler
   100k i2c-set-baud
   i2c-int-ena ;
: irq-handler ( -- )
   ipsr case 
   ;
: codec-read ( r -- )
   codec-adr i2c-start-write dup 8 rshift i2c-write i2c-write codec-adr i2c-start-read
   i2c-read i2c-stop ;
: codec-id? ( -- )
   0 codec-read ;
: codec-handler ( -- ) ;
: codec-state-init ( -- ) ;
: code-state-init-mic1 ;
: codec-state-init-mic2 ;
: codec-state-reset ( -- ) ;
: codec-state-activate ( -- ) ;
: codec-state-fading-in ( -- ) ;
: codec-state-fading-out ( -- ) ;


\ ********* start sound demo ************
: demo 
   sys-clk-200-mhz ;
