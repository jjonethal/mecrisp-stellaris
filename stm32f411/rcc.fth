\ stm32F411 rcc clock control
\ 

$40023800 constant RCC_CR
#1 #16 lshift constant HSE_ON 

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

: set-hse-on  ( -- ) HSE_ON RCC_CR set-mask ;
: set-hse-off ( -- ) HSE_ON RCC_CR clr-mask ;




