\ stm32F303VCT6 rcc clock control
\
\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"
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

: ux.8 ( u -- ) base @ >R hex 
 0 <# # # # # # # # # #> type
 R> base ! ;
 
: set-mask ( m adr -- ) dup >R @ or R> ! ;
: clr-mask ( m adr -- ) >R not R@ @ and R> ! ;

: dw ( a -- a ) dup 6 + ctype ; 
: ds ( -- a )   dictionarystart dup . SPACE dw ;
: dn ( a -- a ) dictionarynext . dup . dw ;

decimal
: cnt0 ( m -- b ) \ count trailing zeros without clz
  dup negate and dup >R
  0<>                           ( -- -1 )
  $ffff     R@ and 0<> -16 and  ( -- -1 -16 )
  $FF00FF   R@ and 0<>  -8 and  ( -- -1 -16 -8 )
  $F0F0F0F  R@ and 0<>  -4 and  ( -- -1 -16 -8 -4 )
  $33333333 R@ and 0<>  -2 and  ( -- -1 -16 -8 -4 -2 )
  $55555555 R> and 0<>  -1 and  ( -- -1 -16 -8 -4 -2 -1 )
  #32 + + + + + +
;

: cnt0 ( m -- b ) \ count trailing zeros with hw support
  dup negate and 1- clz negate 32 +
;

: getbits ( m adr -- b ) @ over and swap cnt0 rshift ;
: setval  ( v m adr -- ) 
  >R dup R> cnt0 lshift     \ shift value to proper pos
  R@ and                    \ mask out unrelated bits
  R> not R@ @ and           \ invert bitmask and makout new bits
  or r> !                   \ apply value and store back
;

: hse-on     ( -- ) HSE_ON RCC_CR set-mask ;
: hse-off    ( -- ) HSE_ON RCC_CR clr-mask ;
: hse-byp-on ( -- ) hse-off HSEBYP CSSON or RCC_CR set-mask hse-on ;
: ?hse-ready ( -- f ) RCC_CR @ HSERDY and 0<> ;

: RCC_CR. hex cr
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
;


