\ delay on tim2 counter

16000000 constant FCK_PSC \ PSC clock frequency

: init-delaytim2
RCC_APB1ENR_TIM2EN RCC_APB1ENR bis! \ System configuration controller clock enable
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




