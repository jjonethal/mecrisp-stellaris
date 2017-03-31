\ interrupt Handling
\
\ REQUIRE st32l152.f 
\ 

\ ******  STM32L specific Interrupt Numbers ***********************************************************
0 constant WWDG_IRQn \ Window WatchDog Interrupt                               
1 constant PVD_IRQn \ PVD through EXTI Line detection Interrupt               
2 constant TAMPER_STAMP_IRQn \ Tamper and TimeStamp interrupts through the EXTI line   
3 constant RTC_WKUP_IRQn \ RTC Wakeup Timer through EXTI Line Interrupt            
4 constant FLASH_IRQn \ FLASH global Interrupt                                  
6 constant EXTI0_IRQn  \ EXTI Line0 Interrupt
7 constant EXTI1_IRQn  \ EXTI Line1 Interrupt
8 constant EXTI2_IRQn  \ EXTI Line2 Interrupt
9 constant EXTI3_IRQn  \ EXTI Line3 Interrupt
10 constant EXTI4_IRQn  \ EXTI Line4 Interrupt
11 constant DMA1_Channel1_IRQn \ DMA1 Channel 1 global Interrupt                         
12 constant DMA1_Channel2_IRQn \ DMA1 Channel 2 global Interrupt                         
13 constant DMA1_Channel3_IRQn \ DMA1 Channel 3 global Interrupt                         
14 constant DMA1_Channel4_IRQn \ DMA1 Channel 4 global Interrupt                         
15 constant DMA1_Channel5_IRQn \ DMA1 Channel 5 global Interrupt                         
16 constant DMA1_Channel6_IRQn \ DMA1 Channel 6 global Interrupt                         
17 constant DMA1_Channel7_IRQn \ DMA1 Channel 7 global Interrupt                         
18 constant ADC1_IRQn \ ADC1 global Interrupt                                   
19 constant USB_HP_IRQn \ USB High Priority Interrupt                             
20 constant USB_LP_IRQn \ USB Low Priority Interrupt                              
21 constant DAC_IRQn \ DAC Interrupt                                           
22 constant COMP_IRQn \ Comparator through EXTI Line Interrupt                  
23 constant EXTI9_5_IRQn \ External Line[9:5] Interrupts                           
24 constant LCD_IRQn \ LCD Interrupt                                           
25 constant TIM9_IRQn \ TIM9 global Interrupt                                   
26 constant TIM10_IRQn \ TIM10 global Interrupt                                  
27 constant TIM11_IRQn \ TIM11 global Interrupt                                  
28 constant TIM2_IRQn \ TIM2 global Interrupt                                   
29 constant TIM3_IRQn \ TIM3 global Interrupt                                   
30 constant TIM4_IRQn \ TIM4 global Interrupt                                   
31 constant I2C1_EV_IRQn \ I2C1 Event Interrupt                                    
32 constant I2C1_ER_IRQn \ I2C1 Error Interrupt                                    
33 constant I2C2_EV_IRQn \ I2C2 Event Interrupt                                    
34 constant I2C2_ER_IRQn \ I2C2 Error Interrupt                                    
35 constant SPI1_IRQn \ SPI1 global Interrupt                                   
36 constant SPI2_IRQn \ SPI2 global Interrupt                                   
37 constant USART1_IRQn \ USART1 global Interrupt                                 
38 constant USART2_IRQn \ USART2 global Interrupt                                 
39 constant USART3_IRQn \ USART3 global Interrupt                                 
40 constant EXTI15_10_IRQn \ External Line[15:10] Interrupts                         
41 constant RTC_Alarm_IRQn \ RTC Alarm through EXTI Line Interrupt                   
42 constant USB_FS_WKUP_IRQn \ USB FS WakeUp from suspend through EXTI Line Interrupt  
43 constant TIM6_IRQn \ TIM6 global Interrupt                                   
44 constant TIM7_IRQn \ TIM7 global Interrupt                      

\ ******************  Bit definition for RCC_APB2ENR register  *****************
$1 constant RCC_APB2ENR_SYSCFGEN	\ System Configuration SYSCFG clock enable 
$4 constant RCC_APB2ENR_TIM9EN		\ TIM9 interface clock enable 
$8 constant RCC_APB2ENR_TIM10EN		\ TIM10 interface clock enable 
$10 constant RCC_APB2ENR_TIM11EN	\ TIM11 Timer clock enable 
$200 constant  RCC_APB2ENR_ADC1EN	\ ADC1 clock enable 
$1000 constant RCC_APB2ENR_SPI1EN	\ SPI1 clock enable 
$4000 constant RCC_APB2ENR_USART1EN	\ USART1 clock enable 


\ *****************  Bit definition for RCC_APB1ENR register  ******************
$1 constant RCC_APB1ENR_TIM2EN		\ Timer 2 clock enabled
$2 constant RCC_APB1ENR_TIM3EN		\ Timer 3 clock enable 
$4 constant RCC_APB1ENR_TIM4EN		\ Timer 4 clock enable 
$10 constant RCC_APB1ENR_TIM6EN		\ Timer 6 clock enable 
$20 constant RCC_APB1ENR_TIM7EN		\ Timer 7 clock enable 
$200 constant RCC_APB1ENR_LCDEN		\ LCD clock enable 
$800 constant RCC_APB1ENR_WWDGEN	\ Window Watchdog clock enable 
$4000 constant RCC_APB1ENR_SPI2EN	\ SPI 2 clock enable 
$20000 constant RCC_APB1ENR_USART2EN	\ USART 2 clock enable 
$40000 constant RCC_APB1ENR_USART3EN	\ USART 3 clock enable 
$200000 constant RCC_APB1ENR_I2C1EN	\ I2C 1 clock enable 
$400000 constant RCC_APB1ENR_I2C2EN	\ I2C 2 clock enable 
$800000 constant RCC_APB1ENR_USBEN	\ USB clock enable 
$10000000 constant RCC_APB1ENR_PWREN	\ Power interface clock enable 
$20000000 constant RCC_APB1ENR_DACEN	\ DAC interface clock enable 
$80000000 constant RCC_APB1ENR_COMPEN	\ Comparator interface clock enable 

\ ----------------------------
\  Interrupt controller tools
\ ----------------------------

$E000E100 constant en0 ( Interrupt Set Enable  0-31  )
$E000E104 constant en1 ( Interrupt Set Enable 32-63  )
$E000E108 constant en2 ( Interrupt Set Enable 64-95  )
$E000E10C constant en3 ( Interrupt Set Enable 96-127 )

$E000E180 constant dis0 ( Interrupt Clear Enable  0-31  )
$E000E184 constant dis1 ( Interrupt Clear Enable 32-63  )
$E000E188 constant dis2 ( Interrupt Clear Enable 64-95  )
$E000E18C constant dis3 ( Interrupt Clear Enable 96-127 )


: nvic-enable ( irq# -- )
  \ 16 - \ Cortex Core Vectors
  dup 32 u< if      1 swap lshift en0 ! exit then
  dup 64 u< if 32 - 1 swap lshift en1 ! exit then
  dup 96 u< if 64 - 1 swap lshift en2 ! exit then
               96 - 1 swap lshift en3 !
;

: nvic-disable ( irq# -- )
  \ 16 - \ Cortex Core Vectors
  dup 32 u< if      1 swap lshift dis0 ! exit then
  dup 64 u< if 32 - 1 swap lshift dis1 ! exit then
  dup 96 u< if 64 - 1 swap lshift dis2 ! exit then
               96 - 1 swap lshift dis3 !
;
 
: nvic-priority ( priority irq# -- )
  $E000E400 + c!
;

\ Sample
\ From stm32discovery
\ By pressing a button the user runs the interrupt handler compiletoram 

\ interrupt handler
\ : myirq cr ." my irq!" nvic_iabr0 @ .
\ 1 EXTI_PR ! ;

\ ' myirq irq-exti0 !

\ : myinit
\ RCC_APB2ENR dup @ RCC_APB2ENR_SYSCFGEN  or swap ! \ System configuration controller clock enable
\ SYSCFG_EXTICR1 dup @ 0 or swap !		\ interrupt pin PA.0 enable
\ 1 EXTI_RTSR !		\ line 0 rising edge trigger
\ EXTI0_IRQn nvic-enable
\ EXTI_IMR dup @ 1 or swap !
\ eint
\ ;
