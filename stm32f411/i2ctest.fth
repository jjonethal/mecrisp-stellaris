\ i2c tester
\ requires gpio, util, pll
\ sample 12c-scl and i2c-sda, timestamp



GPIOB 10 + constant PB10
GPIOB 11 + constant PB11

PB10 ( PB6 PB8 ) constant i2c-scl  \ most paired i2c hw ports have sda = scl+1 
PB11 ( PB7 PB9 ) constant i2c-sda

$40000000 constant TIMER2          \ timer2 constants
        0 constant TIMx_CR1    
        4 constant TIMx_CR2
      $24 constant TIMx_CNT
      $2C constant TIMx_ARR
: timer-start
   TIM2EN RCC_APB1ENR bis!
   -1 TIMx_ARR TIMER2 + !
    1 TIMx_CR1 TIMER2 + !  ;

: time-stamp ( -- n )  TIMER2 TIMx_CNT + @ inline ;        \ get timestamp

0 variable lastTime

TIMER2 TIMx_CNT + constant TIMER_CNT
: dt ( -- n )
    TIMER_CNT @ lastTime @ over lastTime ! - ;


\ ********** logic analyser ****************************************************
0 variable LA-STATE                       \ logic analyser state

: i2c-pins@ i2c-sda port# GPIO_IDR + @
   i2c-scl pin# rshift 3 and ;

: state-idle-D1C1
   i2c-pins@
   case %01 of ." S" endof                \ start detected
        %10 of ." E" endof                \ error 
        %00 of ." E" endof                \ error both 0 in short time
        %11 of ." 3" endof
   endcase ;

: log ( n dt -- )                         \ log current i2c state
   2 lshift swap 3 and or   
   . cr ;

0 variable i2c-state-last
0 variable i2c-state-current

: poll  ( -- )                            \ poll current linestate
   i2c-pins@ dup
   i2c-state-last @ <>
   dt dup 63 >= or
   if log
   else drop
   then ;
   

: gpio-init                               \ gpio init i2c ports
   0 i2c-scl gpio-pupd!
   0 i2c-scl gpio-mode!
   3 i2c-scl gpio-speed!

   0 i2c-sda gpio-pupd!
   0 i2c-sda gpio-mode!
   3 i2c-sda gpio-speed! ;

: usart-baud  ( usart baud  -- )                    \ set terminal baud rate to 230400
   get-sys-clk 2/ usart-set-baud ;

: i2c-analyser ( -- )
   gpio-init clk-96-hse ;