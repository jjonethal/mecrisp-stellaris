\ stm32F303VCT6 rcc clock control
\
\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"
\ "http://graphics.stanford.edu/~seander/bithacks.html"

\ project specific value
#8000000 constant HSE_CLOCK

#8000000 constant HSI_CLOCK

$40022000 constant FLASH_BASE
$00 FLASH_BASE or constant FLASH_ACR
$04 FLASH_BASE or constant FLASH_KEYR
$08 FLASH_BASE or constant FLASH_OPTKEYR
$0C FLASH_BASE or constant FLASH_SR
$10 FLASH_BASE or constant FLASH_CR
$14 FLASH_BASE or constant FLASH_AR
$1C FLASH_BASE or constant FLASH_OBR
$20 FLASH_BASE or constant FLASH_WRPR


$40021000 constant RCC_BASE
$00 RCC_BASE + constant RCC_CR
#1 #25 lshift  constant PLLRDY
#1 #24 lshift  constant PLLON
#1 #19 lshift  constant CSSON
#1 #18 lshift  constant HSEBYP
#1 #17 lshift  constant HSERDY
#1 #16 lshift  constant HSE_ON
$FF #8 lshift  constant HSICAL
$F  #4 lshift  constant HSITRIM
#1  #1 lshift  constant HSIRDY
#1             constant HSION

$04 RCC_BASE + constant RCC_CFGR
#1 #31 lshift  constant PLLNODIV
#3 #29 lshift  constant MCOPRE
#1 #28 lshift  constant MCOF
#7 #24 lshift  constant MCO
#1 #23 lshift  constant I2SSRC
#1 #22 lshift  constant USBPRE
$F #18 lshift  constant PLLMUL
#1 #17 lshift  constant PLLXTPRE
#1 #16 lshift  constant PLLSRC
#7 #11 lshift  constant PPRE2
#7  #8 lshift  constant PPRE1
$f  #4 lshift  constant HPRE
#3  #2 lshift  constant SWS
#3             constant SW

$08 RCC_BASE + constant RCC_CIR
#1 #23 lshift constant CSSC
#1 #20 lshift constant PLLRDYC
#1 #19 lshift constant HSERDYC
#1 #18 lshift constant HSIRDYC
#1 #17 lshift constant LSERDYC
#1 #16 lshift constant LSIRDYC
#1 #12 lshift constant PLLRDYIE
#1 #11 lshift constant HSERDYIE
#1 #10 lshift constant HSIRDYIE
#1  #9 lshift constant LSERDYIE
#1  #8 lshift constant LSIRDYIE
#1  #7 lshift constant CSSF
#1  #4 lshift constant PLLRDYF
#1  #3 lshift constant HSERDYF
#1  #2 lshift constant HSIRDYF
#1  #1 lshift constant LSERDYF
#1            constant LSIRDYF

$0C RCC_BASE + constant RCC_APB2RSTR
#1 #18 lshift constant TIM17RST
#1 #17 lshift constant TIM16RST
#1 #16 lshift constant TIM15RST
#1 #14 lshift constant USART1RST
#1 #13 lshift constant TIM8RST
#1 #12 lshift constant SPI1RST
#1 #11 lshift constant TIM1RST
#1            constant SYSCFGRST

$10 RCC_BASE + constant RCC_APB1RSTR
#1 #29 lshift constant DAC1RST
#1 #28 lshift constant PWRRST
#1 #26 lshift constant DAC2RST
#1 #25 lshift constant CANRST
#1 #23 lshift constant USBRST
#1 #22 lshift constant I2C2RST
#1 #21 lshift constant I2C1RST
#1 #20 lshift constant UART5RST
#1 #19 lshift constant UART4RST
#1 #18 lshift constant USART3RST
#1 #17 lshift constant USART2RST
#1 #15 lshift constant SPI3RST
#1 #14 lshift constant SPI2RST
#1 #11 lshift constant WWDGRST
#1 #5  lshift constant TIM7RST
#1 #4  lshift constant TIM6RST
#1 #2  lshift constant TIM4RST
#1 #1  lshift constant TIM3RST
#1 #0  lshift constant TIM2RST

$14 RCC_BASE + constant RCC_AHBENR
#1 #29 lshift constant ADC34EN
#1 #28 lshift constant ADC12EN
#1 #24 lshift constant TSCEN
#1 #22 lshift constant IOPFEN
#1 #21 lshift constant IOPEEN
#1 #20 lshift constant IOPDEN
#1 #19 lshift constant IOPCEN
#1 #18 lshift constant IOPBEN
#1 #17 lshift constant IOPAEN
#1  #6 lshift constant CRCEN
#1  #4 lshift constant FLITFEN
#1  #2 lshift constant SRAMEN
#1  #1 lshift constant DMA2EN
#1  #0 lshift constant DMA1EN

$18 RCC_BASE + constant RCC_APB2ENR
#1 #18 lshift constant TIM17EN
#1 #17 lshift constant TIM16EN
#1 #16 lshift constant TIM15EN
#1 #14 lshift constant USART1EN
#1 #13 lshift constant TIM8EN
#1 #12 lshift constant SPI1EN
#1 #11 lshift constant TIM1EN
#1            constant SYSCFGEN

$1C RCC_BASE + constant RCC_APB1ENR
#1 #29 lshift constant DAC1EN
#1 #28 lshift constant PWREN
#1 #26 lshift constant DAC2EN
#1 #25 lshift constant CANEN
#1 #23 lshift constant USBEN
#1 #22 lshift constant I2C2EN
#1 #21 lshift constant I2C1EN
#1 #20 lshift constant UART5EN
#1 #19 lshift constant UART4EN
#1 #18 lshift constant USART3EN
#1 #17 lshift constant USART2EN
#1 #15 lshift constant SPI3EN
#1 #14 lshift constant SPI2EN
#1 #11 lshift constant WWDGEN
#1 #5  lshift constant TIM7EN
#1 #4  lshift constant TIM6EN
#1 #2  lshift constant TIM4EN
#1 #1  lshift constant TIM3EN
#1 #0  lshift constant TIM2EN

$20 RCC_BASE + constant RCC_BDCR
#1 #16 lshift constant BDRST
#1 #15 lshift constant RTCEN
#3  #8 lshift constant RTCSEL
#3  #3 lshift constant LSEDRV
#1  #2 lshift constant LSEBYP
#1  #1 lshift constant LSERDY
#1  #0 lshift constant LSEON

$24 RCC_BASE + constant RCC_CSR
#1 #31 lshift constant LPWRSTF
#1 #30 lshift constant WWDGRSTF
#1 #29 lshift constant IWDGRSTF
#1 #28 lshift constant SFTRSTF
#1 #27 lshift constant PORRSTF
#1 #26 lshift constant PINRSTF
#1 #25 lshift constant OBLRSTF
#1 #24 lshift constant RMVF
#1  #1 lshift constant LSIRDY
#1  #0 lshift constant LSION

$28 RCC_BASE + constant RCC_AHBRSTR
#1 #29 lshift constant ADC34RST
#1 #28 lshift constant ADC12RST
#1 #24 lshift constant TSCRST
#1 #22 lshift constant IOPFRST
#1 #21 lshift constant IOPERST
#1 #20 lshift constant IOPDRST
#1 #19 lshift constant IOPCRST
#1 #18 lshift constant IOPBRST
#1 #17 lshift constant IOPARST

$2C RCC_BASE + constant RCC_CFGR2
$1F #9 lshift constant ADC34PRES
$1F #4 lshift constant ADC12PRES
$F            constant PREDIV

$30 RCC_BASE + constant RCC_CFGR3
#3 #22 lshift constant UART5SW
#3 #20 lshift constant UART4SW
#3 #18 lshift constant USART3SW
#3 #16 lshift constant USART2SW
#1  #9 lshift constant TIM8SW
#1  #8 lshift constant TIM1SW
#1  #5 lshift constant I2C2SW
#1  #4 lshift constant I2C1SW
#3  #0 lshift constant USART1SW

: ux.8 ( u -- ) base @ >R hex 
 0 <# # # # # # # # # #> type
 R> base ! ;
 
: set-mask ( m adr -- ) dup >R @ or R> ! ;
: clr-mask ( m adr -- ) >R not R@ @ and R> ! ;

: dw ( a -- a ) dup 6 + ctype ;                   \ dictionary word
: ds ( -- a )   dictionarystart dup . SPACE dw ;  \ dictionary start 
: dn ( a -- a ) dictionarynext . dup . dw ;       \ dictionary next

decimal
: cnt0 ( m -- b ) \ count trailing zeros without clz
  dup negate and dup >R
  0<>                           ( -- -1 )
  $ffff     R@ and 0<> #-16 and  ( -- -1 -16 )
  $FF00FF   R@ and 0<>  #-8 and  ( -- -1 -16 -8 )
  $F0F0F0F  R@ and 0<>  #-4 and  ( -- -1 -16 -8 -4 )
  $33333333 R@ and 0<>  #-2 and  ( -- -1 -16 -8 -4 -2 )
  $55555555 R> and 0<>  #-1 and  ( -- -1 -16 -8 -4 -2 -1 )
  #32 + + + + + +
;

: cnt0 ( m -- b )  \ count trailing zeros with hw support
  dup negate and 1- clz negate #32 +
;

: getbits ( m adr -- b ) @ over and swap cnt0 rshift ;
: setbits  ( v m adr -- ) 
  >R dup >R cnt0 lshift     \ shift value to proper pos
  R@ and                    \ mask out unrelated bits
  R> not R@ @ and           \ invert bitmask and makout new bits
  or r> !                   \ apply value and store back
;

: mask-shift ( m v -- m v )
  over cnt0 lshift
  over and
;

\ : setbits ( m v adr -- )
\   >R over cnt0 lshift over and
\   swap R@ @ and or R> !
\ ;

: hse-on     ( -- ) HSE_ON RCC_CR set-mask ;
: hse-off    ( -- ) HSE_ON RCC_CR clr-mask ;
: hse-byp-on ( -- ) hse-off HSEBYP CSSON or RCC_CR set-mask hse-on ;
: ?hse-ready ( -- f ) RCC_CR @ HSERDY and 0<> ;
: set-prediv ( v -- ) RCC_CFGR2 @ PREDIV not and or RCC_CFGR2 ! ; 

: RCC_CR. BASE >R hex cr
  ." RCC_CR " RCC_CR @ ux.8 cr
  ."  PLLRDY  " PLLRDY  RCC_CR getbits . cr
  ."  PLLON   " PLLON   RCC_CR getbits . cr
  ."  CSSON   " CSSON   RCC_CR getbits . cr
  ."  HSEBYP  " HSEBYP  RCC_CR getbits . cr
  ."  HSERDY  " HSERDY  RCC_CR getbits . cr
  ."  HSE_ON  " HSE_ON  RCC_CR getbits . cr
  ."  HSICAL  " HSICAL  RCC_CR getbits . cr
  ."  HSITRIM " HSITRIM RCC_CR getbits . cr
  ."  HSIRDY  " HSIRDY  RCC_CR getbits . cr
  ."  HSION   " HSION   RCC_CR getbits . cr
  R> BASE !
;

: RCC_CFGR. hex cr
  ." RCC_CFGR " RCC_CFGR @ ux.8 cr
  ."  PLLNODIV " PLLNODIV RCC_CFGR getbits . cr 
  ."  MCOPRE   " MCOPRE   RCC_CFGR getbits . cr
  ."  MCOF     " MCOF     RCC_CFGR getbits . cr
  ."  MCO      " MCO      RCC_CFGR getbits . cr
  ."  I2SSRC   " I2SSRC   RCC_CFGR getbits . cr
  ."  USBPRE   " USBPRE   RCC_CFGR getbits . cr
  ."  PLLMUL   " PLLMUL   RCC_CFGR getbits . cr
  ."  PLLXTPRE " PLLXTPRE RCC_CFGR getbits . cr
  ."  PLLSRC   " PLLSRC   RCC_CFGR getbits . cr
  ."  PPRE2    " PPRE2    RCC_CFGR getbits . cr
  ."  PPRE1    " PPRE1    RCC_CFGR getbits . cr
  ."  HPRE     " HPRE     RCC_CFGR getbits . cr
  ."  SWS      " SWS      RCC_CFGR getbits . cr
  ."  SW       " SW       RCC_CFGR getbits . cr
;

\ calculate link adress from token length and code adress 
: c-adr>link ( token-len c-adr -- link-adr ) \ return 0 when c-adr is 0
  dup 0<> -rot                               \ check for 0 adr
\ link-adr = code-adr - len(token) -1 (length byte) - pad(1/0) - 6(4link+2flags)
  swap - 1- -2 and 6 - and                   \ -2 and -> clear lowest bit
;

\ find link adress of next token
: >LINK ( -- ) token 2dup find ( tadr tlen c-adr flags -- )
  drop ( tadr tlen c-adr ) \ we only need token length and c-adr
  rot drop ( tlen c-adr )
  c-adr>link \ find link adress
;

: flash-prefetch-enable ( -- )
  $10 FLASH_ACR BIS! 
;

: flash-prefetch-disable ( -- )
  $10 FLASH_ACR BIC! 
;

: flash-half-cycle-enable ( -- )
  $8 FLASH_ACR BIS!
;

: flash-half-cycle-disable ( -- )
  $8 FLASH_ACR BIC!
;

: flash-set-latency ( n -- )
  FLASH_ACR @ [ 7 not literal, ] and or FLASH_ACR !
;

: set-pll-mul ( n -- )
 1- PLLMUL rcc_cfgr setbits 
;


: get-clk-sw RCC_CFGR @ 3 and ;

: clk-source-hsi?
   get-clk-sw
   case 
     0 of -1 endof                           \ hsi 
     2 of RCC_CFGR_PLLSRC RCC_CFGR 0= endof  \ pll get pll source
     0                                       \ probably HSE
   endcase
;

: pll-set-system-speed-hsi ( hz -- )
  hsi-on clk-source-hsi
  #2 HSI_CLOCK */ #4 max 16 min
  set-pll-mul  
;

