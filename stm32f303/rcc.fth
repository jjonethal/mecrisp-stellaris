\ stm32F303VCT6 rcc clock control
\
\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"
$40021000 constant RCC_BASE
RCC_BASE $00 + constant RCC_CR
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


: ux.8 ( u -- ) base @ hex
 0 <# # # # # # # # # #> type
 base ! ;
 
: set-mask ( m adr -- ) dup >R @ or R> ! ;
: clr-mask ( m adr -- ) >R not R@ @ and R> ! ;

decimal
: cnt0 ( m -- b ) \ count trailing zeros
  dup negate and dup >R
  0<>                           ( -- -1 )
  $ffff     R@ and 0<> -16 and  ( -- -1 -16 )
  $FF00FF   R@ and 0<>  -8 and  ( -- -1 -16 -8 )
  $F0F0F0F  R@ and 0<>  -4 and  ( -- -1 -16 -8 -4 )
  $33333333 R@ and 0<>  -2 and  ( -- -1 -16 -8 -4 -2 )
  $55555555 R> and 0<>  -1 and  ( -- -1 -16 -8 -4 -2 -1 )
  #32 + + + + + +
;

: getbits ( m adr -- b ) @ over and swap cnt0 rshift ;

: hse-on  ( -- ) HSE_ON RCC_CR set-mask ;
: hse-off ( -- ) HSE_ON RCC_CR clr-mask ;
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


