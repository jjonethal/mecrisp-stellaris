\ delay on tim2 counter
\ from stm32f411
compiletoflash
50000000 constant FCK_PSC \ PSC clock frequency
\ Warning!!! 
\ When TIMPRE bit of the RCC_DCKCFGR register is reset, if APBx prescaler is 1, then TIMxCLK = PCLKx, otherwise
\ TIMxCLK = 2x PCLKx.
\ When TIMPRE bit in the RCC_DCKCFGR register is set, if APBx prescaler is 1,2 or 4, then TIMxCLK = HCLK, otherwise
\ TIMxCLK = 4x PCLKx.

: init-delaytim2
1 RCC_APB1ENR bis! \ System configuration controller clock enable
0 TIM2_CR1 ! \ 
;


: delay-tim2
1 TIM2_EGR bis! \ Update generation
$19 TIM2_CR1 bis! \ start counter in mode: One-pulse mode+Counter used as downcounter
dup TIM2_ARR ! TIM2_CNT !
 begin 1 TIM2_CR1 bit@ 0= until
;

: us ( n -- ) init-delaytim2 FCK_PSC 1000001 / TIM2_PSC ! delay-tim2 ;
: ms ( n -- ) init-delaytim2 FCK_PSC 1001 /  TIM2_PSC ! delay-tim2 ;
compiletoram
