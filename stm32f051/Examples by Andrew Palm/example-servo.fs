\ =========================================================================
\  Program Name: example-servo.fs for Mecrisp-Stellaris by Matthias Koch
\
\  This program is a template for larger projects, as it includes a main
\  loop controlled by the SysTick timer.  There are these tasks:
\
\     - A flashing yellow led with variable duty cycle controlled by a
\       rotary encoder.
\     - A green led that is toggled by a short push on a pushbutton
\     - A red led that indicates the control mode (see below)
\     - A pushbutton driver (interrupt version)
\     - A driver for a rotary encoder with alternate detents
\     - A small servo motor which is also control by the pushbutton and
\       rotary encoder
\     - When a long (> 1 sec) push is made on the pushbutton, the control
\       toggles between two modes:
\         Mode 0: Red led off
\                 The pushbutton toggles the green led on and off
\                 The rotary encoder controls the duty cycle of the yellow
\                 led
\         Mode 1: Red led on
\                 The pushbutton centers the servo motor
\                 The rotary encoder controls the servo motor
\
\  Hardware:
\     - STM32F051K8T6 on DIP conversion board
\     - Two leds, yellow on PF0, green on PF1 (330 ohm dropping resistors)
\     - A red led on PA6 (330 ohm dropping resistor)
\     - Pushbutton with internal pullup and software debounce on PA4
\     - Rotary encoder with 30 alternate detents on PA0 and PA1 with
\       internal pullups and hardware debounce.
\     - Small servo motor with these connections:
\ 
\          Servo   STM32 Pin
\           GND      GND
\            V+      3V3
\           SIG      PA7  (TIM14_CH1 output)
\
\ -------------------------------------------------------------------------
\  To run stand-alone:
\     - This example uses the "init" word so that the main program will
\       run on a reset by the reset button or a terminal command.
\     - The main loop uses "key? until" so that when running with a
\       terminal connected (PA9 TX and PA10 RX) a key press can break
\       execution.
\     - However, if the terminal RX connection on PA10 is removed, the
\       program hangs due to the use of key? in the main loop.
\     - To allow the program to run without the terminal but retain the
\       use of key? for possible later updating or debugging, connect PA10
\       to 3.3V (VDD) when not using the terminal (or just using TX on PA9).
\
\ -------------------------------------------------------------------------
\  Style:
\     - All words are in lower case with parts separted by hyphens.
\     - Constants are in upper case, with parts separated by
\       underscores.
\     - Variables and words associated with a task are prefixed by the
\       task name (which is in lower case) with subsequent parts of
\       variable names having the initial letter in upper case and
\       separated by hyphens.
\     - Variables acting as function pointers (containing the address
\       of a word) have a tick prefix.
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.02.07
\ =========================================================================

compiletoflash
\ -------------------------------------------------------------------------
\  Core and peripheral registers
\  Unused registers are commented out
\ -------------------------------------------------------------------------
$E000E010 constant SysTick
  SysTick $00 + constant SysTick_CTRL
  SysTick $04 + constant SysTick_LOAD
  SysTick $08 + constant SysTick_VAL
  SysTick $0C + constant SysTick_CALIB

$E000E100 constant NVIC
  NVIC $000 + constant NVIC_ISER
  \ NVIC $080 + constant NVIC_ICER
  \ NVIC $100 + constant NVIC_ISPR
  NVIC $180 + constant NVIC_ICPR
  NVIC $300 + constant NVIC_IPR0

$E000ED00 constant SCB
  SCB $01C + constant SCB_SHPR2

$40021000 constant RCC
  RCC $00 + constant RCC_CR
  RCC $04 + constant RCC_CFGR
  \ RCC $08 + constant RCC_CIR
  \ RCC $0C + constant RCC_APB2RSTR
  \ RCC $10 + constant RCC_APB1RSTR
  RCC $14 + constant RCC_AHBENR
  RCC $18 + constant RCC_APB2ENR
  RCC $1C + constant RCC_APB1ENR
  \ RCC $20 + constant RCC_BDCR
  \ RCC $24 + constant RCC_CSR
  \ RCC $28 + constant RCC_AHBRSTR
  \ RCC $2C + constant RCC_CFGR2
  \ RCC $30 + constant RCC_CRGR3
  \ RCC $34 + constant RCC_CR2

$40022000 constant FLASH
  FLASH $0 + constant FLASH_ACR

$40010000 constant SYSCFG
  \ SYSCFG $00 + constant SYSCFG_CFGR1
  \ SYSCFG $08 + constant SYSCFG_EXTICR1
  SYSCFG $0C + constant SYSCFG_EXTICR2
  \ SYSCFG $10 + constant SYSCFG_EXTICR3
  \ SYSCFG $14 + constant SYSCFG_EXTICR4
  \ SYSCFG $18 + constant SYSCFG_CFGR2

$40010400 constant EXTI
  EXTI $00 + constant EXTI_IMR
  EXTI $04 + constant EXTI_EMR
  \ EXTI $08 + constant EXTI_RTSR
  EXTI $0C + constant EXTI_FTSR
  \ EXTI $10 + constant EXTI_SWIER
  EXTI $14 + constant EXTI_PR

$48000000 constant GPIOA
  GPIOA $00 + constant GPIOA_MODER
  GPIOA $04 + constant GPIOA_OTYPER
  GPIOA $08 + constant GPIOA_OSPEEDR
  GPIOA $0C + constant GPIOA_PUPDR
  GPIOA $10 + constant GPIOA_IDR
  \ GPIOA $14 + constant GPIOA_ODR
  GPIOA $18 + constant GPIOA_BSRR
  \ GPIOA $1C + constant GPIOA_LCKR
  GPIOA $20 + constant GPIOA_AFRL
  \ GPIOA $24 + constant GPIOA_AFRH
  GPIOA $28 + constant GPIOA_BRR

\ $48000400 constant GPIOB
  \ GPIOB $00 + constant GPIOB_MODER
  \ GPIOB $04 + constant GPIOB_OTYPER
  \ GPIOB $08 + constant GPIOB_OSPEEDR
  \ GPIOB $0C + constant GPIOB_PUPDR
  \ GPIOB $10 + constant GPIOB_IDR
  \ GPIOB $14 + constant GPIOB_ODR
  \ GPIOB $18 + constant GPIOB_BSRR
  \ GPIOB $1C + constant GPIOB_LCKR
  \ GPIOB $20 + constant GPIOB_AFRL
  \ GPIOB $24 + constant GPIOB_AFRH
  \ GPIOB $28 + constant GPIOB_BRR

$48001400 constant GPIOF
  GPIOF $00 + constant GPIOF_MODER
  \ GPIOF $04 + constant GPIOF_OTYPER
  \ GPIOF $08 + constant GPIOF_OSPEEDR
  \ GPIOF $0C + constant GPIOF_PUPDR
  \ GPIOF $10 + constant GPIOF_IDR
  GPIOF $14 + constant GPIOF_ODR
  GPIOF $18 + constant GPIOF_BSRR
  GPIOF $28 + constant GPIOF_BRR

$40013800 constant USART1
  USART1 $C + constant USART1_BRR

\ $40000400 constant TIM3
  \ TIM3 $00 + constant TIM3_CR1
  \ TIM3 $04 + constant TIM3_CR2
  \ TIM3 $08 + constant TIM3_SMCR
  \ TIM3 $0C + constant TIM3_DIER
  \ TIM3 $10 + constant TIM3_SR
  \ TIM3 $18 + constant TIM3_CCMR1
  \ TIM3 $20 + constant TIM3_CCER
  \ TIM3 $28 + constant TIM3_PSC
  \ TIM3 $2C + constant TIM3_ARR
  \ TIM3 $38 + constant TIM3_CCR2

$40002000 constant TIM14
  TIM14 $00 + constant TIM14_CR1
  TIM14 $14 + constant TIM14_EGR
  TIM14 $18 + constant TIM14_CCMR1
  TIM14 $20 + constant TIM14_CCER
  TIM14 $28 + constant TIM14_PSC
  TIM14 $2C + constant TIM14_ARR
  TIM14 $34 + constant TIM14_CCR1


\ $40012400 constant ADC
  \ ADC $00 + constant ADC_ISR
  \ ADC $04 + constant ADC_IER
  \ ADC $08 + constant ADC_CR
  \ ADC $0C + constant ADC_CFGR1
  \ ADC $14 + constant ADC_SMPR
  \ ADC $28 + constant ADC_CHSELR
  \ ADC $40 + constant ADC_DR

\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\  Null (event sink) action used by pushbutton and rotary encoder tasks.
: null-act ( -- )  nop ;

\ -------------------------------------------------------------------------
\  Clock setup and timing plus USART1 baud set to 115200 for cortex-m0.
\  Uses 8 MHz internal oscillator divided by 2 and x12 PLL multiplier.
\
\  Clock initialization code is modified from usb-f1.txt by Jean-Claude
\  Wippler.
\  Adjusted for STM32F051 @ 48 MHz (original STM32F100 by Igor de om1zz).
\ -------------------------------------------------------------------------
: 48MHz ( -- )
\ Set the main clock to 48 MHz, keep baud rate at 115200

  %1 RCC_CR bis!                        \ set HSION
  begin %1 1 lshift RCC_CR bit@ until  \ wait for HSIRDY

  %10001 FLASH_ACR !    \ One flash wait state, enable prefetch buffer

  \ HSI clock /2 = 4 MHz source for PLL
  %1111 18 lshift RCC_CFGR bic!
  %1010 18 lshift RCC_CFGR bis!   \ PLL factor: 4 MHz * 12 = 48 MHz

  %1111 4 lshift RCC_CFGR bic!    \ HPRE DIV 1, HCLK = SYSCLK
  %111  8 lshift RCC_CFGR bic!    \ PPRE DIV 1, PCLK = HCLK

  %1 24 lshift RCC_CR bis!                \ set PLLON
  begin %1 25 lshift RCC_CR bit@ until    \ wait for PLLRDY

  %11 RCC_CFGR bic!
  %10 RCC_CFGR bis!               \ PLL is system clock

  $1A1 USART1_BRR !               \ Set console baud rate to 115200
;

\ -------------------------------------------------------------------------
\  Set up SysTick for main loop 1 ms tick
\ -------------------------------------------------------------------------
1 constant MAIN_TICKS  \ Number of systicks for main loop repeat
MAIN_TICKS variable main-Tick-Cnt

1 constant SysTick_PRIORITY
-1 constant SysTick_IRQn

: systick-handler ( -- )
  main-Tick-Cnt @ if
    -1 main-Tick-Cnt +!
  then
;

: wait-for-tick ( -- )
  begin main-Tick-Cnt @ 0= until
  MAIN_TICKS main-Tick-Cnt !
;

: systick-init ( -- )
  %011 SysTick_CTRL bic!    \ Disable timer and interrupt
  48000 1 - SysTick_LOAD !  \ (SystemCoreClock/1000)-1 for 1 ms tick
  0 SysTick_VAL !
  %101 SysTick_CTRL bis!    \ Set CLKSOURCE, ENABLE bits

  \ Set SysTick interrupt priority
  SysTick_PRIORITY 6 lshift $FF and  \ Priority byte
  SysTick_IRQn %11 and 3 lshift      \ Bit shift
  lshift
  SysTick_IRQn %1111 and 8 - 2 rshift 2 lshift  \ Byte offset from SCB_SHPR2
  SCB_SHPR2 + bis!                    \ Write priority bits

  ['] systick-handler irq-systick !   \ Register systick-handler
  %010 SysTick_CTRL bis!    \ Enable system tick interrupt (bit TICKINT)
;

\ -------------------------------------------------------------------------
\  Initialize gpio peripheral clocks and pins
\ -------------------------------------------------------------------------
7 constant EXTI4_15_IRQn
2 constant EXTI4_15_PRIORITY

: gpio-init ( -- )
  \ Enable GPIOF peripheral clock and set pins PF0 and PF1 as output
  \ (push-pull, low speed) for leds
  %1 22 lshift RCC_AHBENR bis!
  %0101 GPIOF_MODER !

  \ Enable GPIOA peripheral clock and set pins PA0, PA1, and PA4 to
  \ input with internal pullups
  %1 17 lshift RCC_AHBENR bis!
  %01 8 lshift %01 2 lshift or %01 or GPIOA_PUPDR bis!

  \ Set up external interrupt on PA4
  %111 SYSCFG_EXTICR2 bic!    \ Assign PA4 to EXTI line 4(reset value)
  %1 4 lshift EXTI_IMR bis!   \ Enable interrupt, line 4
  %1 4 lshift EXTI_FTSR bis!  \ Falling edge trigger enabled, line 4
  %1 4 lshift EXTI_EMR bis!   \ Enable event, line 4
  \ Set interrupt priority
  EXTI4_15_PRIORITY 6 lshift $FF and  \ Priority byte
  EXTI4_15_IRQn %11 and 3 lshift      \ Bit shift
  lshift
  EXTI4_15_IRQn 2 rshift 2 lshift     \ Byte offset from NVIC_IPR0
  NVIC_IPR0 + bis!                    \ Write priority bits
  \ Enable interrupt
  %1 EXTI4_15_IRQn lshift NVIC_ISER bis!

  \ Set pin PA6 as output for led (push-pull, low speed)
  %01 12 lshift GPIOA_MODER bis!
  
  \ Set pin PA7 for TIM14_CH1 output for servo motor signal  
  %0100 28 lshift GPIOA_AFRL bis!   \ PA7 AF 4 for TIME14_CH1
  %10 14 lshift GPIOA_MODER bis!    \ AF mode
  %11 14 lshift GPIOA_OSPEEDR bis!  \ High speed
  %1 7 lshift GPIOA_OTYPER bic!     \ Push-pull (reset value)
;

\ -------------------------------------------------------------------------
\  Pushbutton driver for pushbutton pb0 on pin PA4 with software debounce.
\  This is an interrupt version that assumes that pb1-task is called in the
\  main loop.  The interrupt is used to start a timer on a falling edge.
\  Input pin value is assumed low on push, high (pulled up) on release.
\  Pushbutton action occurs when button is released.
\  There are two types of pushes, short (<= 1 sec) and long (> 1 sec).
\  A client task registers short and long push actions (event sinks)
\  by loading the associated word addresses into the pointer variables
\  'pb1-Short-Act and 'pb1-Long-Act, resp.
\ -------------------------------------------------------------------------
%1 4 lshift constant PB1_MSK

PB1_MSK variable pb1-Val
0 variable pb1-Timer-Cnt
0 variable pb1-Timer-On?

' null-act variable 'pb1-Short-Act
' null-act variable 'pb1-Long-Act

: pb1-get ( -- )  GPIOA_IDR @ PB1_MSK and pb1-Val ! ;

: pb1-handler
  \ If falling edge detected on PA4, start pushbutton timer
  EXTI_PR @ PB1_MSK and if    \ Interrupt for EXTI line 4 asserted?
    1 pb1-Timer-On? !         \ Turn timer on
    PB1_MSK EXTI_PR bis!      \ Reset the interrupt flag
  then
;
: pb1-init ( -- )
  pb1-get
  ['] null-act 'pb1-Short-Act !
  ['] null-act 'pb1-Long-Act !
  ['] pb1-handler irq-exti4_15 !    \ Register systick-handler
;

: pb1-task
  pb1-Timer-On? if
    1 pb1-Timer-Cnt +!    \ Increment timer
    pb1-get
    pb1-Val @ PB1_MSK = if    \ Button released?
      pb1-Timer-Cnt @ 1000 > if   \ Long push if more than 1000 main ticks
        'pb1-Long-Act @ execute
      else
        pb1-Timer-Cnt @ 20 > if   \ Debounce delay 20 main loop ticks
          'pb1-Short-Act @ execute
        then
      then
      0 pb1-Timer-Cnt !   \ Reset timer count
      0 pb1-Timer-On? !   \ Turn timer off
    then
  then
;

\ -------------------------------------------------------------------------
\  Rotary encoder driver (alternating detent type) on PA0 and PA1.
\  (If encoder does not have alternating detents, see comment below.)
\  If the encoder is mechanical, it is assumed that the channels are
\  debounced in hardware.
\  This is a polling version that assumes that pb1-task is called in the
\  main loop.  Input pins are pulled up.
\  A client task registers clockwise and counter-clockwise actions (event
\  sinks) by loading the associated word addresses into the pointer
\  variables 'enc1-CW-Act and 'enc1-CCW-Act, resp.
\ -------------------------------------------------------------------------
' null-act variable 'enc1-CW-Act
' null-act variable 'enc1-CCW-Act

%01 constant CH_A_MSK
%10 constant CH_B_MSK

CH_A_MSK variable enc1-ChA-Val
CH_A_MSK variable enc1-ChA-Last-Val
CH_B_MSK variable enc1-ChB-Val

: enc1-cha-get ( -- )  GPIOA_IDR @ CH_A_MSK and enc1-ChA-Val ! ;

: enc1-chb-get ( -- )  GPIOA_IDR @ CH_B_MSK and enc1-ChB-Val ! ;

: enc1-init ( -- )
  enc1-cha-get
  enc1-chb-get
  enc1-ChA-Val @ enc1-ChA-Last-Val !
;

: enc1-task ( -- )
  enc1-cha-get
  enc1-chb-get

  enc1-ChA-Val @ 0= enc1-ChA-Last-Val @ 0<> and if
    enc1-ChB-Val @ 0<> if
      'enc1-CW-Act @ execute
    else
      'enc1-CCW-Act @ execute
    then
  then

  \ If rotary encoder does not have alternating detents, comment out
  \ the if-then below
  enc1-ChA-Val @ 0<> enc1-ChA-Last-Val @ 0= and if
    enc1-ChB-Val @ 0<> if
      'enc1-CCW-Act @ execute
    else
      'enc1-CW-Act @ execute
    then
  then

  enc1-ChA-Val @ enc1-ChA-Last-Val !
;

\ -------------------------------------------------------------------------
\  Servo motor tasks
\  Timer 14 Ch1 on PA7 generates the control signal pulses using PWM
\ -------------------------------------------------------------------------
150 constant SRVO_PW_CNTR
200 constant SRVO_PW_MAX
100 constant SRVO_PW_MIN      
5 constant SRVO_PW_DEL

SRVO_PW_CNTR variable srvo-PW

: srvo-init-hw ( -- )
  \ Set up Timer 14 for trigger pulse output on PA7
  \ Enable timer peripheral clock
  %1 8 lshift RCC_APB1ENR bis!

  \ PWM frequency = 50 hz with 48 Mhz system clock
  \ 48000000/100000 = 480
  \ 100000/2000 = 50
  480 1 - TIM14_PSC h!           \ Prescaler (16 bit register)
  2000 1 - TIM14_ARR !           \ Period

  \ PWM1 Mode configuration : Channel 1 output
  \ Edge - aligned ; not single pulse mode
  %111 4 lshift %11 or TIM14_CCMR1 bic!
  %110 4 lshift TIM14_CCMR1 bis!
  %1 3 lshift TIM14_CCMR1 bis!      \ Enable output compare preload
  %1 7 lshift TIM14_CR1 bis!        \ Auto reload register buffered
  SRVO_PW_CNTR TIM14_CCR1 h!        \ Ch 1 compare value

  \  Reset counters and enable channel
  %1 TIM14_EGR bis!
  %1 TIM14_CCER bis!
  \ Enable Timer
  %1 TIM14_CR1 bis!
;

: srvo-cntr ( -- )
  \ Center servo motor
  SRVO_PW_CNTR srvo-PW !
  srvo-PW @ TIM14_CCR1 h!
;

: srvo-cw ( -- )
  \ Turn servo motor one increment clockwise
  srvo-PW @ SRVO_PW_MAX SRVO_PW_DEL - > if
    SRVO_PW_MAX srvo-PW !
  else
    SRVO_PW_DEL srvo-PW +!
  then
  srvo-PW @ TIM14_CCR1 h!
;

: srvo-ccw ( -- )
  \ Turn servo motor one increment counter-clockwise
  srvo-PW @ SRVO_PW_MIN SRVO_PW_DEL + < if
    SRVO_PW_MIN srvo-PW !
  else
    srvo-PW @ SRVO_PW_DEL - srvo-PW !
  then
  srvo-PW @ TIM14_CCR1 h!
;

: srvo-init ( -- )
  srvo-cntr
;

\ -------------------------------------------------------------------------
\  Yellow led task (client of rotary encoder task)
\  Assumes that led is on if output pin is high.
\ -------------------------------------------------------------------------
%1 constant LED1_MSK

500 constant LED1_DFLT_TKS
1000 constant LED1_MAX_TKS
50 constant LED1_MIN_TKS
50 constant LED1_DEL_TKS

LED1_DFLT_TKS variable led1-On-Cnt
LED1_DFLT_TKS variable led1-Off-Cnt
LED1_DFLT_TKS variable led1-Cnt

: led1-dc+ ( -- )
  \ Increase led duty cycle
  led1-On-Cnt @ LED1_DEL_TKS + dup dup LED1_MAX_TKS < if
    led1-On-Cnt !
    LED1_MAX_TKS swap - led1-Off-Cnt !
  else
    drop drop
  then
;

: led1-dc- ( -- )
  \ Decrease led duty cycle
  led1-On-Cnt @ LED1_DEL_TKS - dup dup LED1_MIN_TKS >= if
    led1-On-Cnt !
    LED1_MAX_TKS swap - led1-Off-Cnt !
  else
    drop drop
  then
;

: led1-init ( -- )
  LED1_DFLT_TKS led1-On-Cnt !
  LED1_DFLT_TKS led1-Off-Cnt !
  LED1_DFLT_TKS led1-Cnt !
;

: led1-task ( -- )
  -1 led1-Cnt +!
  led1-Cnt @ 0= if
    GPIOF_ODR @ LED1_MSK and dup if   \ Is led on?
      GPIOF_BRR bis!                  \ Turn led off
      led1-Off-Cnt @ led1-Cnt !       \ Load off tick count
    else
      drop LED1_MSK GPIOF_BSRR bis!   \ Turn led on
      led1-On-Cnt @ led1-Cnt !        \ Load on tick count
    then
  then
;

\ -------------------------------------------------------------------------
\  Green led task (client of pushbutton task)
\  Assumes that led is on if output pin is high.
\ -------------------------------------------------------------------------
%10 constant LED2_MSK

: led2-off ( -- )  LED2_MSK GPIOF_BRR bis! ;

: led2-on ( -- )  LED2_MSK GPIOF_BSRR bis! ;

: led2-tggl ( -- ) LED2_MSK GPIOF_ODR xor! ;

: led2-init ( -- )
  led2-off
;

\ -------------------------------------------------------------------------
\  Red led task (client of control task)
\  Assumes that led is on if output pin is high.
\ -------------------------------------------------------------------------
%1 6 lshift constant LED3_MSK

: led3-off ( -- )  LED3_MSK GPIOA_BRR bis! ;

: led3-on ( -- )  LED3_MSK GPIOA_BSRR bis! ;

\ -------------------------------------------------------------------------
\  Control task
\  Task toggles the control mode when there is a long push on the
\  pushbutton.
\ -------------------------------------------------------------------------
1 variable cntl-Next-Mode  \ Control mode state variable

: cntl-mode-0 ( -- )
  led3-off
  ['] led1-dc+ 'enc1-CW-Act !
  ['] led1-dc- 'enc1-CCW-Act !
  ['] led2-tggl 'pb1-Short-Act !
;

: cntl-mode-1 ( -- )
  led3-on
  ['] srvo-cw 'enc1-CW-Act !
  ['] srvo-ccw 'enc1-CCW-Act !
  ['] srvo-cntr 'pb1-Short-Act !
;

: cntl-mode ( -- )
  \ Set function pointers for new mode, set next mode value
  cntl-Next-Mode @ case
    0 of
      cntl-mode-0
      1 cntl-Next-Mode !
    endof  
    1 of
      cntl-mode-1
      0 cntl-Next-Mode !
    endof
  endcase
;

: cntl-init ( -- )
  \ Register with pushbutton long push
  ['] cntl-mode 'pb1-Long-Act !
  \ Initialize in mode 0
  cntl-mode-0
  1 cntl-Next-Mode !
;

\ -------------------------------------------------------------------------
\  Main program that starts on reset
\ -------------------------------------------------------------------------
: init ( -- )

  \ ---------------- Initialization ---------------------------------------
  \ Hardware
  dint          \ Global interrupt disable
  48MHz         \ Set system clock to 48 MHz
  systick-init  \ Set system tick for 1 ms
  gpio-init     \ Initialize port pins and pin interrupts
  srvo-init-hw  \ Initialize servo motor timer
  eint          \ Global interrupt enable

  \ Tasks
  pb1-init
  enc1-init
  cntl-init
  srvo-init
  led1-init
  led2-init

  \ ---------------- Main loop --------------------------------------------
  begin wait-for-tick
    pb1-task
    enc1-task
    led1-task
  key? until            \ Escape from main loop on key press
;
\ -------------------------------------------------------------------------
compiletoram
