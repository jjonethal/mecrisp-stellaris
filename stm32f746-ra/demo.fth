\ stm32f746g-disco display demo
\ pin allocations
\ B_USER  - PI11 - User button
\ USD_D0  - microsSD card
\ USD_D1  - microsSD card
\ USD_D2  - microsSD card
\ USD_D3  - microsSD card
\ USD_CLK - microSD card clock
\ USD_CMD - microSD
\ USD_DETECT - micro sd-card

#25000000 constant HSE_CLK_HZ
#16000000 constant HSI_CLK_HZ

\ LCD_BL_CTRL - PK3 display led backlight control 0-off 1-on

\ ***** utility functions ***************
\ ***** bitfield utility functions ******
: cnt0   ( m -- b )                      \ count trailing zeros with hw support
   dup negate and 1-
   clz negate #32 + 1-foldable ;
: bits@  ( m adr -- b )                  \ get bitfield at masked position e.g $1234 v ! $f0 v bits@ $3 = . (-1)
   @ over and swap cnt0 rshift ;
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

\ ***** gpio definitions ****************
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
: mode-shift ( mode pin -- mode<< )      \ shift mode by pin number * 2 for gpio_moder
   pin# 2* lshift 2-foldable ;
: set-mask! ( v m a -- )
   tuck @ swap bic rot or swap ! ;
: bsrr-on  ( pin -- v )                  \ gpio_bsrr mask pin on
   pin# 1 swap lshift 1-foldable ;
: bsrr-off  ( pin -- v )                 \ gpio_bsrr mask pin off
   pin# #16 + 1 swap lshift 1-foldable ;
: af-mask  ( pin -- mask )               \ alternate function bitmask
   $7 and #2 lshift $f swap lshift 1-foldable ;
: af-reg  ( pin -- adr )                 \ alternate function register address for pin
   dup $8 and 2/ swap
   port-base GPIO_AFRL + + 1-foldable ;
: af-shift ( af pin -- af )
   pin# #2 lshift swap lshift 2-foldable ;
: gpio-mode! ( mode pin -- )
   tuck mode-shift swap dup
   mode-mask swap port-base set-mask! ;
: mode-af ( af pin -- )
   #2 over gpio-mode!
   dup af-mask swap af-reg bits! ;
: speed-mode ( speed pin -- )            \ set speed mode 0:low speed 1:medium 2:fast 3:high speed
   dup pin# 2* #3 swap lshift
   swap port-base #8 + bits! ;
: mode-af-fast ( af pin -- )
   #2 over speed-mode mode-af ;
   
\ ***** Flash read access config ********
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
: overdrive-on ( -- )                    \ turn on overdrive on ( not when system clock is pll )
   pwr-clock-on
   overdrive-enable
   begin overdrive-ready? until
   overdrive-switch-on
   begin overdrive-switch-ready? until ;
: voltage-scale-mode-3  ( -- )           \ activate voltage scale mode 3
   1 $03 #14 lshift PWR_CR1 bits! ;
: voltage-scale-mode-1  ( -- )           \ activate voltage scale mode 3
   #3 $03 #14 lshift PWR_CR1 bits! ;

\ ***** usart constants & words *********
$40011000               constant USART1_BASE
$0C                     constant USART_BRR
USART_BRR USART1_BASE + constant USART1_BRR
: usart1-clk-sel!  ( n -- )              \ set usart1 clk source
   $3 RCC_DKCFGR2 bits! ;
: usart1-baud-update!  ( baud -- )       \ update usart baudrate
   #2 usart1-clk-sel!                    \ use hsi clock
   HSI_CLK_HZ over 2/ + swap /           \ calculate baudrate for 16 times oversampling
   USART1_BRR ! ;

\ ***** clock management ****************
: sys-clk-200-mhz  ( -- )                \ supports also sdram clock <= 200 MHz
   hsi-wait-stable
   clk-source-hsi                        \ switch to hsi clock for reconfiguration
   hse-off hse-byp-on hse-on             \ hse bypass mode
   pll-off pll-clk-src-hse               \ pll use hse as clock source
   HSE_CLK_HZ #1000000 / PLL-M!          \ PLL input clock 1 Mhz
   #400 pll-n! PLLP/2 PLL-P!             \ VCO clock 400 MHz
   voltage-scale-mode-1                  \ for flash clock > 168 MHz voltage scale 1(0b011)
   overdrive-on                          \ for flash clock > 180 over drive mode
   hse-wait-stable                       \ hse must be stable before use
   pll-on
   flash-prefetch-ena                    \ activate prefetch to reduce latency impact
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

\ ***** lcd definitions *****************
$40016800        constant LTDC              \ LTDC base
$08 LTDC +       constant LTDC_SSCR         \ LTDC Synchronization Size Configuration Register
$FFF #16 lshift  constant LTDC_SSCR_HSW     \ Horizontal Synchronization Width  ( pixel-1 )
$7FF             constant LTDC_SSCR_VSH     \ Vertical   Synchronization Height ( pixel-1 )
$0C LTDC +       constant LTDC_BPCR         \ Back Porch Configuration Register
$FFF #16 lshift  constant LTDC_BPCR_AHBP    \ HSYNC Width  + HBP - 1
$7FF             constant LTDC_BPCR_AVBP    \ VSYNC Height + VBP - 1
$10 LTDC +       constant LTDC_AWCR         \ Active Width Configuration Register
$FFF #16 lshift  constant LTDC_AWCR_AAW     \ HSYNC width  + HBP  + Active Width  - 1
$7FF             constant LTDC_AWCR_AAH     \ VSYNC Height + BVBP + Active Height - 1
$14 LTDC +       constant LTDC_TWCR         \ Total Width Configuration Register
$FFF #16 lshift  constant LTDC_TWCR_TOTALW  \ HSYNC Width + HBP  + Active Width  + HFP - 1
$7FF             constant LTDC_TWCR_TOTALH  \ VSYNC Height+ BVBP + Active Height + VFP - 1
$18 LTDC +       constant LTDC_GCR          \ Global Control Register
1  #31 lshift    constant LTDC_GCR_HSPOL    \ Horizontal Synchronization Polarity 0:active low 1: active high
1  #30 lshift    constant LTDC_GCR_VSPOL    \ Vertical Synchronization Polarity 0:active low 1:active high
1  #29 lshift    constant LTDC_GCR_DEPOL    \ Not Data Enable Polarity 0:active low 1:active high
1  #28 lshift    constant LTDC_GCR_PCPOL    \ Pixel Clock Polarity 0:nomal 1:inverted
1  #16 lshift    constant LTDC_GCR_DEN      \ dither enable
$7 #12 lshift    constant LTDC_GCR_DRW      \ Dither Red Width
$7  #8 lshift    constant LTDC_GCR_DGW      \ Dither Green Width
$7  #4 lshift    constant LTDC_GCR_DBW      \ Dither Blue Width
$1               constant LTDC_GCR_LTDCEN   \ LCD-TFT controller enable bit
$24 LTDC +       constant LTDC_SRCR         \ Shadow Reload Configuration Register
1 1 lshift       constant LTDC_SRCR_VBR     \ Vertical Blanking Reload
1                constant LTDC_SRCR_IMR     \ Immediate Reload
$2C LTDC +       constant LTDC_BCCR         \ Background Color Configuration Register RGB888
$FF #16 lshift   constant LTDC_BCCR_BCRED   \ Background Color Red
$FF  #8 lshift   constant LTDC_BCCR_BCGREEN \ Background Color Green
$FF              constant LTDC_BCCR_BCBLUE  \ Background Color Blue
$34 LTDC +       constant LTDC_IER          \ Interrupt Enable Register
#1 #3 lshift     constant LTDC_IER_RRIE     \ Register Reload interrupt enable
#1 #2 lshift     constant LTDC_IER_TERRIE   \ Transfer Error Interrupt Enable
#1 #1 lshift     constant LTDC_IER_FUIE     \ FIFO Underrun Interrupt Enable
#1               constant LTDC_IER_LIE      \ Line Interrupt Enable
$38 LTDC +       constant LTDC_ISR          \ Interrupt Status Register
#1 #3 lshift     constant LTDC_ISR_RRIF     \ Register Reload interrupt flag
#1 #2 lshift     constant LTDC_ISR_TERRIF   \ Transfer Error Interrupt flag
#1 #1 lshift     constant LTDC_ISR_FUIF     \ FIFO Underrun Interrupt flag
#1               constant LTDC_ISR_LIF      \ Line Interrupt flag
$3C LTDC +       constant LTDC_ICR          \ Interrupt Clear Register
#1 #3 lshift     constant LTDC_ICR_CRRIF    \ Register Reload interrupt flag
#1 #2 lshift     constant LTDC_ICR_CTERRIF  \ Transfer Error Interrupt flag
#1 #1 lshift     constant LTDC_ICR_CFUIF    \ FIFO Underrun Interrupt flag
#1               constant LTDC_ICR_CLIF     \ Line Interrupt flag
$40 LTDC +       constant LTDC_LIPCR        \ Line Interrupt Position Configuration Register
$7FF             constant LTDC_LIPCR_LIPOS  \ Line Interrupt Position
$44 LTDC +       constant LTDC_CPSR         \ Current Position Status Register
$FFFF #16 lshift constant LTDC_CPSR_CXPOS   \ Current X Position
$FFFF            constant LTDC_CPSR_CYPOS   \ Current Y Position
$48 LTDC +       constant LTDC_CDSR         \ Current Display Status Register
1 3 lshift       constant LTDC_CDSR_HSYNCS  \ Horizontal Synchronization display Status
1 2 lshift       constant LTDC_CDSR_VSYNCS  \ Vertical Synchronization display Status
1 1 lshift       constant LTDC_CDSR_HDES    \ Horizontal Data Enable display Status
1                constant LTDC_CDSR_VDES    \ Vertical Data Enable display Status
$84 LTDC +       constant LTDC_L1CR         \ Layer1 Control Register
1 4 lshift       constant LTDC_LxCR_CLUTEN  \ Color Look-Up Table Enable
1 2 lshift       constant LTDC_LxCR_COLKEN  \ Color Keying Enable
1                constant LTDC_LxCR_LEN     \ layer enable

$88 LTDC +       constant LTDC_L1WHPCR      \ Layer1 Window Horizontal Position Configuration Register
$8C LTDC +       constant LTDC_L1WVPCR      \ Layer1 Window Vertical Position Configuration Register
$90 LTDC +       constant LTDC_L1CKCR       \ Layer1 Color Keying Configuration Register
$94 LTDC +       constant LTDC_L1PFCR       \ Layer1 Pixel Format Configuration Register
$98 LTDC +       constant LTDC_L1CACR       \ Layer1 Constant Alpha Configuration Register
$9C LTDC +       constant LTDC_L1DCCR       \ Layer1 Default Color Configuration Register
$A0 LTDC +       constant LTDC_L1BFCR       \ Layer1 Blending Factors Configuration Register
$AC LTDC +       constant LTDC_L1CFBAR      \ Layer1 Color Frame Buffer Address Register
$B0 LTDC +       constant LTDC_L1CFBLR      \ Layer1 Color Frame Buffer Length Register
$B4 LTDC +       constant LTDC_L1CFBLNR     \ Layer1 ColorFrame Buffer Line Number Register
$C4 LTDC +       constant LTDC_L1CLUTWR     \ Layer1 CLUT Write Register

$84 LTDC + $80 + constant LTDC_L2CR         \ Layer2 Control Register
$88 LTDC + $80 + constant LTDC_L2WHPCR      \ Layer2 Window Horizontal Position Configuration Register
$8C LTDC + $80 + constant LTDC_L2WVPCR      \ Layer2 Window Vertical Position Configuration Register
$90 LTDC + $80 + constant LTDC_L2CKCR       \ Layer2 Color Keying Configuration Register
$94 LTDC + $80 + constant LTDC_L2PFCR       \ Layer2 Pixel Format Configuration Register
$98 LTDC + $80 + constant LTDC_L2CACR       \ Layer2 Constant Alpha Configuration Register
$9C LTDC + $80 + constant LTDC_L2DCCR       \ Layer2 Default Color Configuration Register
$A0 LTDC + $80 + constant LTDC_L2BFCR       \ Layer2 Blending Factors Configuration Register
$AC LTDC + $80 + constant LTDC_L2CFBAR      \ Layer2 Color Frame Buffer Address Register
$B0 LTDC + $80 + constant LTDC_L2CFBLR      \ Layer2 Color Frame Buffer Length Register
$B4 LTDC + $80 + constant LTDC_L2CFBLNR     \ Layer2 ColorFrame Buffer Line Number Register
$C4 LTDC + $80 + constant LTDC_L2CLUTWR     \ Layer2 CLUT Write Register

\ ***** lcd constants *******************
#0 constant LCD-PF-ARGB8888              \ pixel format argb
#1 constant LCD-PF-RGB888                \ pixel format rgb
#2 constant LCD-PF-RGB565                \ pixel format 16 bit
#3 constant LCD-PF-ARGB1555              \ pixel format 16 bit alpha
#4 constant LCD-PF-ARGB4444              \ pixel format 4 bit/color + 4 bit alpha
#5 constant LCD-PF-L8                    \ pixel format luminance 8 bit
#6 constant LCD-PF-AL44                  \ pixel format 4 bit alpha 4 bit luminance
#7 constant LCD-PF-AL88                  \ pixel format 8 bit alpha 8 bit luminance

\ ***** lcd gpio ports ******************
#4  GPIOE + constant PE4

#12 GPIOG + constant PG12

#7  GPIOH + constant PH7
#8  GPIOH + constant PH8

#0  GPIOJ + constant PJ0
#1  GPIOJ + constant PJ1
#2  GPIOJ + constant PJ2
#3  GPIOJ + constant PJ3
#4  GPIOJ + constant PJ4
#5  GPIOJ + constant PJ5
#6  GPIOJ + constant PJ6
#7  GPIOJ + constant PJ7
#8  GPIOJ + constant PJ8
#9  GPIOJ + constant PJ9
#10 GPIOJ + constant PJ10
#11 GPIOJ + constant PJ11
#13 GPIOJ + constant PJ13
#14 GPIOJ + constant PJ14
#15 GPIOJ + constant PJ15

#9   GPIOI + constant PI9
#10  GPIOI + constant PI10
#12  GPIOI + constant PI12
#13  GPIOI + constant PI13
#14  GPIOI + constant PI14
#15  GPIOI + constant PI15

#0  GPIOK + constant PK0
#1  GPIOK + constant PK1
#2  GPIOK + constant PK2
#3  GPIOK + constant PK3
#4  GPIOK + constant PK4
#5  GPIOK + constant PK5
#6  GPIOK + constant PK6
#7  GPIOK + constant PK7

\ ***** lcd io ports ********************
PI15 constant LCD_R0                     \ GPIO-AF14
PJ0  constant LCD_R1                     \ GPIO-AF14
PJ1  constant LCD_R2                     \ GPIO-AF14
PJ2  constant LCD_R3                     \ GPIO-AF14
PJ3  constant LCD_R4                     \ GPIO-AF14
PJ4  constant LCD_R5                     \ GPIO-AF14
PJ5  constant LCD_R6                     \ GPIO-AF14
PJ6  constant LCD_R7                     \ GPIO-AF14

PJ7  constant LCD_G0                     \ GPIO-AF14
PJ8  constant LCD_G1                     \ GPIO-AF14
PJ9  constant LCD_G2                     \ GPIO-AF14
PJ10 constant LCD_G3                     \ GPIO-AF14
PJ11 constant LCD_G4                     \ GPIO-AF14
PK0  constant LCD_G5                     \ GPIO-AF14
PK1  constant LCD_G6                     \ GPIO-AF14
PK2  constant LCD_G7                     \ GPIO-AF14

PE4  constant LCD_B0                     \ GPIO-AF14
PJ13 constant LCD_B1                     \ GPIO-AF14
PJ14 constant LCD_B2                     \ GPIO-AF14
PJ15 constant LCD_B3                     \ GPIO-AF14
PG12 constant LCD_B4                     \ GPIO-AF9
PK4  constant LCD_B5                     \ GPIO-AF14
PK5  constant LCD_B6                     \ GPIO-AF14
PK6  constant LCD_B7                     \ GPIO-AF14

PI14 constant LCD_CLK                    \ GPIO-AF14
PK7  constant LCD_DE                     \ GPIO-AF14
PI10 constant LCD_HSYNC                  \ GPIO-AF14
PI9  constant LCD_VSYNC                  \ GPIO-AF14
PI12 constant LCD_DISP
PI13 constant LCD_INT                    \ touch interrupt
PH7  constant LCD_SCL                    \ I2C3_SCL GPIO-AF4 touch i2c
PH8  constant LCD_SDA                    \ I2C3_SCL GPIO-AF4 touch i2c
PK3  constant LCD_BL                     \ lcd back light port

\ ***** LCD Timings *********************
#480 constant RK043FN48H_WIDTH
#272 constant RK043FN48H_HEIGHT
#41  constant RK043FN48H_HSYNC           \ Horizontal synchronization
#13  constant RK043FN48H_HBP             \ Horizontal back porch
#32  constant RK043FN48H_HFP             \ Horizontal front porch
#10  constant RK043FN48H_VSYNC           \ Vertical synchronization
#2   constant RK043FN48H_VBP             \ Vertical back porch
#2   constant RK043FN48H_VFP             \ Vertical front porch

RK043FN48H_WIDTH  constant MAX_WIDTH     \ maximum width
RK043FN48H_HEIGHT constant MAX_HEIGHT    \ maximum height
\ ***** lcd functions *******************
: lcd-backlight-init  ( -- )             \ initialize lcd backlight port
   LCD_BL port# rcc-gpio-clk-on          \ turn on gpio clock
   1 LCD_BL mode-shift
   LCD_BL mode-mask
   LCD_BL port-base set-mask! ;
: lcd-backlight-on  ( -- )               \ lcd back light on
   LCD_BL bsrr-on LCD_BL port-base GPIO_BSRR + ! ;
: lcd-backlight-off  ( -- )              \ lcd back light on
   LCD_BL bsrr-off LCD_BL port-base GPIO_BSRR + ! ;
: lcd-clk-init ( -- )                    \ enable 
   rcc-ltdc-clk-on
   pllsai-clk-192-mhz ;
: lcd-gpio-init ( -- )                   \ initialize all lcd gpio ports
   #14 LCD_R0 MODE-AF-FAST  #14 LCD_R1 MODE-AF-FAST  #14 LCD_R2 MODE-AF-FAST  #14 LCD_R3 MODE-AF-FAST
   #14 LCD_R4 MODE-AF-FAST  #14 LCD_R5 MODE-AF-FAST  #14 LCD_R6 MODE-AF-FAST  #14 LCD_R7 MODE-AF-FAST

   #14 LCD_G0 MODE-AF-FAST  #14 LCD_G1 MODE-AF-FAST  #14 LCD_G2 MODE-AF-FAST  #14 LCD_G3 MODE-AF-FAST
   #14 LCD_G4 MODE-AF-FAST  #14 LCD_G5 MODE-AF-FAST  #14 LCD_G6 MODE-AF-FAST  #14 LCD_G7 MODE-AF-FAST

   #14 LCD_B0 MODE-AF-FAST  #14 LCD_B1 MODE-AF-FAST  #14 LCD_B2 MODE-AF-FAST  #14 LCD_B3 MODE-AF-FAST
    #9 LCD_B4 MODE-AF-FAST  #14 LCD_B5 MODE-AF-FAST  #14 LCD_B6 MODE-AF-FAST  #14 LCD_B7 MODE-AF-FAST

   #14 LCD_VSYNC MODE-AF-FAST  #14 LCD_HSYNC MODE-AF-FAST
   #14 LCD_CLK MODE-AF-FAST    #14 LCD_DE    MODE-AF-FAST
   01 LCD_DISP gpio-mode! ;
: lcd-disp-on  ( -- )                    \ enable display
   LCD_DISP bsrr-on LCD_DISP port-base GPIO_BSRR + ! ;
: lcd-disp-off  ( -- )                   \ disable display
   LCD_DISP bsrr-off LCD_DISP port-base GPIO_BSRR + ! ;
: lcd-back-color! ( r g b -- )           \ lcd background color
   $ff and swap $ff and #8 lshift or
   swap $ff and #16 lshift or LTDC_BCCR ! ;
: lcd-reg-update ( -- )                  \ update register settings
   1 LTDC_SRCR bis! ;
: lcd-display-init ( -- )                \ set display configuration
   LTDC_GCR_LTDCEN LTDC_GCR bis!
   RK043FN48H_HSYNC 1- #16 lshift
   RK043FN48H_VSYNC 1- or LTDC_SSCR !

   RK043FN48H_HSYNC RK043FN48H_HBP + 1- #16 lshift
   RK043FN48H_VSYNC RK043FN48H_VBP + 1- or LTDC_BPCR !

   RK043FN48H_WIDTH  RK043FN48H_HSYNC + RK043FN48H_HBP + 1- #16 lshift
   RK043FN48H_HEIGHT RK043FN48H_VSYNC + RK043FN48H_VBP + 1- or LTDC_AWCR !

   RK043FN48H_WIDTH RK043FN48H_HSYNC +
   RK043FN48H_HBP + RK043FN48H_HFP + 1- #16 lshift
   RK043FN48H_HEIGHT RK043FN48H_VSYNC +
   RK043FN48H_VBP + RK043FN48H_VFP + 1- or LTDC_TWCR !

   0 0 0 lcd-back-color!                 \ black back ground
   1 LTDC_GCR !                          \ LTDCEN LCD-TFT controller enable
   
   lcd-backlight-init lcd-backlight-on ;
\ ***** lcd layer functions *************
0   constant layer1
$80 constant layer2
$10 constant LTDC_LxCR_CLUTEN                \ Color Look-Up Table Enable
 $2 constant LTDC_LxCR_COLKEN                \ Color Keying Enable
 $1 constant LTDC_LxCR_LEN                   \ layer enable
: layer-base ( l -- offset )                 \ layer base address
   0<> $80 and LTDC + 1-foldable ;
: layer-base ( l -- offset )                 \ layer base address
   LTDC + 1-foldable ;
: lcd-layer-on!  ( lcfg layer -- )           \ set layer control register
   layer-base $84 + swap 1 or swap ! ;
: lcd-layer-off  ( layer -- )                \ set layer off
   layer-base $84 + 0 swap ! ;
: lcd-layer-h-pos! ( start end layer -- )    \ set layer window horizontal position
   layer-base $88 +
   -rot #16 lshift or swap ! ;
: lcd-layer-v-pos! ( start end layer -- )    \ set layer window vertical position
   layer-base $8C +
   -rot #16 lshift or swap ! ;
: lcd-layer-key-color! ( color layer -- )    \ set layer color keying color
   layer-base $90 + ! ;
: lcd-layer-pixel-format! ( fmt layer -- )   \ set layer pixel format
   layer-base $94 + ! ;
: lcd-layer-const-alpha! ( alpha layer -- )  \ set layer constant alpha
   layer-base $98 + ! ;
: lcd-layer-default-color! ( c layer -- )    \ set layer default color ( argb8888 )
   layer-base $9C + ! ;
: lcd-layer-blend-cfg! ( bf1 bf2 layer -- )  \ set layer blending function
   layer-base $a0 + -rot swap 8 lshift or swap ! ;
: lcd-layer-fb-adr!  ( a layer -- )          \ set layer frame buffer start adr
   layer-base $ac + ! ;
: lcd-layer-fb-adr@  ( layer -- a )          \ get layer frame buffer start adr
   layer-base $ac + @ ;
: lcd-layer-fb-line-length! ( len layer -- ) \ set layer line length in byte
   layer-base $B0 +
   swap dup #16 lshift
   swap 3 + or swap ! ;
: lcd-layer-num-lines! ( lines layer -- )    \ set layer number of lines to buffer
   layer-base $b4 + ! ;
: lcd-layer-color-map ( c i l -- )           \ set layer color at map index
   layer-base $c4 +
   -rot $ff and #24 lshift                   \ shift index to pos [31..24]
   swap $ffffff and or                       \ cleanup color
   swap ! ;

\ setup a frame buffer   
MAX_WIDTH MAX_HEIGHT * dup BUFFER: lcd-fb1-buffer constant lcd-fb1-size#

lcd-fb1-buffer variable lcd-fb1              \ frame buffer 1 pointer
lcd-fb1-size#  variable lcd-fb1-size         \ frame buffer 1 size
: lcd-layer-colormap-gray-scale ( layer -- ) \ grayscale colormap quick n dirty
   >R
   #256 0 do
     i dup dup #8 lshift or #8 lshift or
     i r@ lcd-layer-color-map
   loop rdrop ;
: red-884 ( i -- c )                         \ calc red component for 8-8-4 palette
   $e0 and #5 rshift
   #255 * #3 + #7 /
   #16 lshift ;
: green-884 ( i -- c )                       \ green component for 8-8-4 palette
   $1C and #2 rshift
   #255 * #3 + #7 /
   #8 lshift ;
: blue-884 ( i -- c )                        \ blue component for 8-8-4 palette
   $3 and
   #255 * 1 + 3 / ;
   
: lcd-layer-color-map-8-8-4 ( layer -- )     \ colormap 8 level red 8 green 4 blue
   >R
  256 0 do
    i dup red-884                            \ red
    over  green-884 or                       \ green
    over  blue-884 or                        \ blue
    swap R@ lcd-layer-color-map
    lcd-reg-update
  loop rdrop ;
   
: fb-init-0-ff ( layer -- )              \ fill frame buffer with values 0..255
   lcd-reg-update
   lcd-layer-fb-adr@
   MAX_WIDTH MAX_HEIGHT * 0 do dup i + i swap c! loop drop ;

\ layer 1 view port constants
RK043FN48H_HSYNC RK043FN48H_HBP +       constant L1-h-start
L1-h-start       RK043FN48H_WIDTH + 1-  constant L1-h-end
RK043FN48H_VSYNC RK043FN48H_VBP +       constant L1-v-start
L1-v-start       RK043FN48H_HEIGHT + 1- constant L1-v-end


: lcd-layer1-init ( -- )
   layer1 lcd-layer-off
   L1-h-start L1-h-end layer1 lcd-layer-h-pos!
   L1-v-start L1-v-end layer1 lcd-layer-v-pos!
   0 layer1 lcd-layer-key-color!         \ key color black no used here
   #5 layer1 lcd-layer-pixel-format!     \ 8 bit per pixel frame buffer format
   lcd-fb1 @ layer1 lcd-layer-fb-adr!    \ set frame buffer address
   MAX_WIDTH layer1 lcd-layer-fb-line-length!
   MAX_HEIGHT layer1 lcd-layer-num-lines!
   layer1 fb-init-0-ff
   layer1 lcd-layer-color-map-8-8-4
   LTDC_LxCR_CLUTEN layer1 lcd-layer-on!
   0 layer1 lcd-layer-default-color!
   lcd-reg-update
   ;
: lcd-init  ( -- )                       \ pll-input frequency must be 1 MHz
   lcd-clk-init lcd-backlight-init
   lcd-display-init lcd-reg-update lcd-gpio-init lcd-disp-on ;
: demo ( -- )
   sys-clk-200-mhz lcd-init lcd-layer1-init lcd-reg-update lcd-backlight-on ;
: >token ( a -- a )                      \ retrieve token name address for cfa
   1- dup c@ 0= +                        \ skip the padding zero 
   #256 1 do 1- dup c@ i = if leave then loop ; \ backtrack to start of counted string
: ctype.n ( width a -- )                 \ output counted string with fixed width
   dup ctype c@ - spaces ;
: const. ( a -- )                        \ dump register constant
   cr dup >token #15 swap ctype.n
   execute dup x.8 space @ x.8 ;
: 'reg. ( -- ) ( n:constant )            \ dump next word as register constant 
   postpone ['] postpone const. immediate ; 
: lcd. ( -- )                            \ dump lcd registers
  'reg. LTDC_SSCR
  'reg. LTDC_BPCR
  'reg. LTDC_AWCR
  'reg. LTDC_TWCR
  'reg. LTDC_GCR
  'reg. LTDC_SRCR
  'reg. LTDC_BCCR
  'reg. LTDC_IER
  'reg. LTDC_ISR
  'reg. LTDC_ICR
  'reg. LTDC_LIPCR
  'reg. LTDC_CPSR
  'reg. LTDC_CDSR cr ;
: lcd-l1.  ( -- )                         \ dump lcd layer1 registers
  'reg. LTDC_L1CR
  'reg. LTDC_L1WHPCR
  'reg. LTDC_L1WVPCR
  'reg. LTDC_L1CKCR
  'reg. LTDC_L1PFCR
  'reg. LTDC_L1CACR
  'reg. LTDC_L1DCCR
  'reg. LTDC_L1BFCR
  'reg. LTDC_L1CFBAR
  'reg. LTDC_L1CFBLR
  'reg. LTDC_L1CFBLNR
  'reg. LTDC_L1CLUTWR cr ;
: lcd-l2.  ( -- )  
  'reg. LTDC_L2CR
  'reg. LTDC_L2WHPCR
  'reg. LTDC_L2WVPCR
  'reg. LTDC_L2CKCR
  'reg. LTDC_L2PFCR
  'reg. LTDC_L2CACR
  'reg. LTDC_L2DCCR
  'reg. LTDC_L2BFCR
  'reg. LTDC_L2CFBAR
  'reg. LTDC_L2CFBLR
  'reg. LTDC_L2CFBLNR
  'reg. LTDC_L2CLUTWR cr ;
: gpiox. ( base -- base )                \ output string "gpio[a..x]_"
  dup ." GPIO" port# [char] A + emit [char] _ emit ; 
: gpio. ( pin -- )                       \ dump gpio port settings for pin
  dup cr ." PIN " $f and . cr
  port-base
  cr dup gpiox. ." MODER   " GPIO_MODER + @ x.8
  cr dup gpiox. ." OTYPER  " GPIO_OTYPER + @ x.8
  cr dup gpiox. ." OSPEEDR " GPIO_OSPEEDR + @ x.8
  cr dup gpiox. ." PUPDR   " GPIO_PUPDR + @ x.8
  cr dup gpiox. ." IDR     " GPIO_IDR + @ x.8
  cr dup gpiox. ." ODR     " GPIO_ODR + @ x.8
  cr dup gpiox. ." BSRR    " GPIO_BSRR + @ x.8
  cr dup gpiox. ." LCKR    " GPIO_LCKR + @ x.8
  cr dup gpiox. ." AFRL    " GPIO_AFRL + @ x.8
  cr     gpiox. ." AFRH    " GPIO_AFRH + @ x.8 cr ;

: vfade ( -- )                           \ vertical fade test
  lcd-fb1 @
  MAX_HEIGHT 0  do  MAX_WIDTH 0  do  j over c! 1+  loop  loop  drop ;
: clear ( -- )                           \ fill with 0
   lcd-fb1 @ dup MAX_HEIGHT MAX_WIDTH * + swap do 0 i ! #4 +loop ;
: fill ( c -- )                          \ fill sceen with color
   dup #8 lshift or dup #16 lshift or
   lcd-fb1 @ dup MAX_HEIGHT MAX_WIDTH * + swap do dup i ! #4 +loop drop ;
0 variable l1-x                          \ graphics x-pos
0 variable l1-y                          \ graphics y-pos
0 variable l1-c                          \ color
0 variable l1-fg                         \ forground color
0 variable l1-c4                         \ cccc
0 variable l1-bg                         \ background color
0 variable l1-bg4                        \ bcbcbcbc 4xbackground color
: y-limit ( y -- y )                     \ limit y
   0 max MAX_HEIGHT 1- min ;    
: x-limit ( y -- y )                     \ limit y
   0 max MAX_WIDTH 1- min ;    
: draw-pixel ( -- )                      \ draw pixel with current color
   l1-c @ l1-y @ y-limit MAX_WIDTH *
   l1-x @ x-limit + lcd-fb1 @ + c! ;
: l1-x++ ( -- )
   l1-x @ dup MAX_WIDTH 1- < - l1-x ! ;
: l1-x-- ( -- )
   l1-x @ dup 1 >= + l1-x ! ;
: l1-y++ ( -- )
   l1-y @ dup MAX_HEIGHT 1- < - l1-y ! ;
: l1-y-- ( -- )
   l1-y @ dup 1 >= + l1-y ! ;
: hline  ( l -- )                        \ draw horizontal line
   dup 0<
   if negate 0 do draw-pixel l1-x-- loop
   else      0 do draw-pixel l1-x++ loop then ;
: vline  ( h -- )                        \ draw vertical line
   dup 0<
   if negate 0 ?do draw-pixel l1-y-- loop
   else      0 ?do draw-pixel l1-y++ loop then ;
: rect ( w h -- )                        \ draw a rectangle
  over hline
  dup vline
  swap negate hline
  negate vline ;

0 variable x-alt
0 variable x-neu
0 variable x-sum
0 variable y-alt
0 variable y-neu
0 variable y-sum

0 variable dy
0 variable dx
0 variable xinc
0 variable yinc

: line-x>=y-test  ( -- )                 \ line drawing with rounding test
  0 x-alt !
  dx @ x-neu !
  0 y-sum !
  0 yinc !
  dx @ 1+ 0 do
   draw-pixel
   l1-x++
   y-sum @ dy @ + y-sum !
   y-sum @ x-neu @ >= if dx @ x-alt +! dx @ x-neu +! 1 yinc ! then
   y-sum @ x-alt @ - x-neu @ y-sum @ - >= if yinc @ l1-y +! 0 yinc ! then
  loop ;

: line-x>=y  ( -- )                      \ line for dx >= dy
  0 x-alt !
  dx @ x-neu !
  0 y-sum !
  dx @ 0 do
   draw-pixel
   xinc @ l1-x +!
   dy @ y-sum +!
   y-sum @ x-neu @ >= if dx @ x-alt +! dx @ x-neu +! yinc @ l1-y +! then
  loop draw-pixel ;
: line-y>=x  ( -- )                      \ line for dy >= dx
  0 y-alt !
  dy @ y-neu !
  0 x-sum !
  dy @ 0 do
   draw-pixel
   yinc @ l1-y +!
   dx @ x-sum +!
   x-sum @ y-neu @ >= if dy @ y-alt +! dy @ y-neu +! xinc @ l1-x +! then
  loop draw-pixel ;
: line  ( dx dy -- )                     \ line relative dx, dy
   1 xinc !
   1 yinc !
   dup 0< if -1 yinc ! negate then swap
   dup 0< if -1 xinc ! negate then swap
   2dup dy ! dx !
   >= if line-x>=y else
         line-y>=x then ;
: color! ( c -- )
   $ff and l1-c ! ;
: move-to ( x y -- )                     \ move graphics cursor to
   y-limit l1-y !
   x-limit l1-x ! ;
: move-by ( dx dy -- )                   \ move graphics cursor relative
   l1-y @ + y-limit l1-y !
   l1-x @ + x-limit l1-x ! ;
: nics-home ( -- )                       \ draw saint nicolaus home
  0 fill 0 0 move-to
   100    0 line 
  -100  100 line
   100    0 line
   -50   50 line
   -50  -50 line
     0 -100 line
   100  100 line
     0 -100 line ;
: hline-cx  ( l -- )                     \ hline constant x
  l1-x @ swap hline l1-x ! ;
: fill-rect ( w h -- )                   \ fill a rectangle
   l1-y @ tuck + swap
   do i l1-y ! dup hline-cx loop
   drop ;
: fill-rect-bg ( w h -- )
  l1-c @ -rot l1-bg @ l1-c ! fill-rect l1-c ! ; 
0 variable vx
0 variable vy
0 variable fx
0 variable fy

: vsync? ( -- f )                        \ in vsync state ?
   $4 LTDC_CDSR bit@ ;
: wait-vsync ( -- )                      \ wait for vertical sync
   begin vsync? not until
   begin vsync?     until ;   
: <0> ( n -- n )                         \ sign <0:-1, 0:0, >0:1
   dup 0< swap 0 > negate or ;
: mod-step ( a d -- m d )                \ modulo step (a<0): a+d, -1 (a>=d):a-d, 1 else a, 0
   abs 2dup >=
   if - 1
   else over 0< if + -1 else drop 0 then
   then ;
\ : s vx @ abs vy @ abs > if vy @ fy +!
0 variable idx                           \ current color cycling palette index 
: idx++ ( -- )
  idx @ 1+ $ff and idx ! ;
: rgb>color ( r g b -- c )               \ calc color c from r-g-b components
  $ff and swap $ff and 8 lshift or swap $ff and #16 lshift or ;
: r-g-b-r ( -- )                         \ red green blue palette for color cycling, start at idx
  #256 0 do #255 i - i 0 rgb>color idx @ layer1 lcd-layer-color-map idx++ 3 +loop
  #256 0 do 0 #255 i - i rgb>color idx @ layer1 lcd-layer-color-map idx++ 3 +loop
  #256 0 do i 0 #255 i - rgb>color idx @ layer1 lcd-layer-color-map idx++ 3 +loop ;

: delay 0 do loop ;
: palette-demo ( -- )                    \ color cycle palette
   begin wait-vsync r-g-b-r key? until ;
: palette-demo1 ( didx -- )              \ color cycle palette
   begin wait-vsync r-g-b-r dup idx +! key? until drop ;
: circle-test ( div -- )
  MAX_HEIGHT 0
  do
    MAX_WIDTH  0
    do
      i l1-x ! j l1-y ! i MAX_WIDTH 2/ - dup * j MAX_HEIGHT 2/ - dup * + over / color! draw-pixel
    loop
  loop drop ;
: circle-demo ( -- )
  begin
  150 1 do i circle-test 
    wait-vsync r-g-b-r
    key? if leave then
  loop
  150 1 do 150 i - circle-test 
    wait-vsync r-g-b-r
    key? if leave then
  loop
  key? until ;
: n->bbbb ( n -- n )                     \ make byte mask from nibble $c->$FF00FF00
  dup  $8 and #21 lshift
  over $4 and #14 lshift or
  over $2 and  #7 lshift or
  swap  1 and            or
  dup 2* or dup 2 lshift or ;
(create) nibble-mask-tab
   #0 n->bbbb ,  #1 n->bbbb ,  #2 n->bbbb ,  #3 n->bbbb ,
   #4 n->bbbb ,  #5 n->bbbb ,  #6 n->bbbb ,  #7 n->bbbb ,
   #8 n->bbbb ,  #9 n->bbbb , #10 n->bbbb , #11 n->bbbb ,
  #12 n->bbbb , #13 n->bbbb , #14 n->bbbb , #15 n->bbbb , smudge
' nibble-mask-tab constant nibble-mask-tab-adr   
: pixel-4-mask ( n -- n )                \ cache table
   2 lshift nibble-mask-tab-adr + @ 1-foldable ; 
0 variable pixel-adr
: b->bbbb ( -- )                         \ expand a byte to 4 byte 0xAB -> 0xABAB_ABAB
   dup #8 lshift or dup #16 lshift or ;
: pixel-line-4 ( n -- )                  \ draw 4 2-color pixel 1-forground 0 background
   $f and pixel-4-mask dup negate l1-bg @ b->bbbb and
   swap l1-c @ b->bbbb and or pixel-adr @ ! ;
: pixel-line-2 ( n -- )                  \ draw 2 2-color pixel 1-forground 0 background
   $3 and pixel-4-mask dup negate l1-bg @ b->bbbb and
   swap l1-c @ b->bbbb and or pixel-adr @ 2 + h! ;
: pixel-line-6-y++ ( n -- )              \ draw 6 2-color pixel in a line starting from pixel-adr
   dup pixel-line-4                      \ update pixel adr to next line
   4 rshift pixel-line-2
   pixel-adr @ MAX_WIDTH + pixel-adr ! ; \ next line
: draw-letter-6x8 ( a -- )
   2@ dup pixel-line-6-y++
   dup #6 rshift pixel-line-6-y++
   dup #12 rshift pixel-line-6-y++
   dup #18 rshift pixel-line-6-y++
   dup #24 rshift pixel-line-6-y++
   #30 rshift swap 2 lshift or
   dup pixel-line-6-y++
   dup #6 rshift pixel-line-6-y++
      #12 rshift pixel-line-6-y++ ;
MAX_HEIGHT 8 2 + / constant grid-space   \ grid space for 6x8 raster
grid-space 1 -     constant grid-fill    \ fill width of grid
MAX_WIDTH  grid-space 6 * - 2/ constant grid-h-start
MAX_HEIGHT grid-space 8 * - 2/ constant grid-v-start
grid-space 8 * constant grid-v-length
grid-space 6 * constant grid-h-length
: draw-raster-h-grid ( -- )              \ draw vertical lines of raster - horizontal grid
   grid-h-start grid-space 6 * 1+ +
   grid-h-start
   do
     grid-v-start l1-y ! i l1-x ! grid-v-length vline
   grid-space +loop ;
: draw-raster-v-grid ( -- )              \ draw horizontal lines of raster - vertical grid
   grid-v-start grid-space 8 * 1+ + 
   grid-v-start
   do
     i l1-y ! grid-h-start l1-x ! grid-h-length hline
   grid-space +loop ;
   
: draw-raster-6x8 ( -- )                 \ draw a 6x8 raster
   draw-raster-h-grid
   draw-raster-v-grid ;
0 variable raster-pixel-x
0 variable raster-pixel-y
: pixel-coord ( -- )                     \ update-pixel-coordinates
   raster-pixel-x @ grid-space * grid-h-start + 1+ l1-x !
   raster-pixel-y @ grid-space * grid-v-start + 1+ l1-y !
   raster-pixel-x @ 1+ dup 5 >
   if 1 raster-pixel-y +! drop 0 then 
   raster-pixel-x ! ;
: draw-raster-6x8-fill ( d -- d )        \ draw lsb a square and shift down
   pixel-coord
   over 1 and 0<>
   if   grid-fill dup fill-rect
   else grid-fill dup fill-rect-bg then
   dshr ;
: draw-raster-6x8-line ( d -- d )        \ draw a 6 pixel line
   draw-raster-6x8-fill draw-raster-6x8-fill
   draw-raster-6x8-fill draw-raster-6x8-fill
   draw-raster-6x8-fill draw-raster-6x8-fill ;
: draw-raster-6x8-letter ( d -- )        \ draw a character bitmap on raster
   0 raster-pixel-x !
   0 raster-pixel-y !
   \ 2@
   draw-raster-6x8-line draw-raster-6x8-line
   draw-raster-6x8-line draw-raster-6x8-line
   draw-raster-6x8-line draw-raster-6x8-line
   draw-raster-6x8-line draw-raster-6x8-line 2drop ;
: test-pixel-coord-line ( n -- )
   . raster-pixel-x @ . raster-pixel-y @ . l1-x @ . l1-y @ .
   pixel-coord ."  | "
   raster-pixel-x @ . raster-pixel-y @ . l1-x @ . l1-y @ .
   cr ;
: trp ( -- )                             \ test pixel-coord
   cr
   0 raster-pixel-x ! 0 raster-pixel-y ! 49 0
   do i test-pixel-coord-line loop ; 
: circle-palette-test ( -- )             \ animated color cycling circles
   demo 50 circle-test -1 palette-demo1 ;
\ circle-palette-test

: bit-reverse-5..0 ( w - w ) \ reverse b0-b5
   $3f and
   dup  $01 and #5 lshift
   over $02 and #3 lshift or
   over $04 and shl or
   over $08 and shr or
   over $10 and #3 rshift or
   swap $20 and #5 rshift or ;
: 5dlshift ( d -- d )                    \ shift double left by 5 bits
  #64 0 ud* ;
: bit-5..0-rev-append ( w d -- d )       \ reverse bits 5..0 and append them to double word on stack
  5dlshift rot bit-reverse-5..0  rot or swap ;
: genchar ( l1 l2 l3 l4 l5 l6 l7 l8 -- d ) \ generate character bitmap line by line
   bit-reverse-5..0 0                    \ line 8 
   bit-5..0-rev-append                   \ line 7
   bit-5..0-rev-append                   \ line 6
   bit-5..0-rev-append                   \ line 5
   bit-5..0-rev-append                   \ line 4
   bit-5..0-rev-append                   \ line 3
   bit-5..0-rev-append                   \ line 2
   bit-5..0-rev-append ;                 \ line 1

\ some colors in 8-8-4 palette
\ red b7..5 green b4..2 blue b1..0
              7 2 lshift    constant green
   7 5 lshift 7 2 lshift or constant yellow
   7 5 lshift 4 2 lshift or constant orange
   7 5 lshift               constant red
                          3 constant blue
                          0 constant black
                          
: test-genchar                           \ test genchar
   demo                                  \ init display
   layer1 lcd-layer-color-map-8-8-4      \ colormap rgb 8-8-4
   black fill                            \ clear screen
   232 color! draw-raster-6x8            \ orange raster
   green color!
   %001000   \ b00,b01,b02,b03,b04,b05
   %010100   \ b06,b07,b08,b09,b10,b11
   %100010   \ b12,b13,b14,b15,b16,b17
   %111110   \ b18,b19,b20,b21,b22,b23
   %100010   \ b24,b25,b26,b27,b28,b29
   %100010   \ b30,b31,b32,b33,b34,b35
   %000000   \ b36,b37,b38,b39,b40,b41
   %000000   \ b36,b37,b38,b39,b40,b41
   genchar
   draw-raster-6x8-letter ;
: raster-color-up ( -- )                 \ next color
  l1-c @ 1+ $ff and dup . cr color! draw-raster-6x8 ;
: raster-color-down ( -- )               \ previous color
  l1-c @ 1- $ff and dup . cr color! draw-raster-6x8 ;
: raster-color-sel ( -- )                \ change raster color
   l1-c @ . cr draw-raster-6x8
   begin key case [char] w of raster-color-up   0 endof \ next color
                  [char] s of raster-color-down 0 endof \ previous color
                  [char] q of                   1 endof
                  1
             endcase
   until ;
