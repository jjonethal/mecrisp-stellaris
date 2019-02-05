\ =========================================================================
\  Program: example-nunchuk-i2c.fs for Mecrisp-Stellaris by Matthias Koch
\
\  This program is a template for larger projects, as it includes a main
\  loop controlled by the SysTick timer.  There are these tasks:
\
\     - A flashing yellow led with variable duty cycle
\     - A green led that is turned on (short push) and off (long push) by
\       a pushbutton
\     - A pushbutton driver (interrupt version)
\     - A driver for a rotary encoder with alternate detents that increases
\       (cw) or decreases (ccw) the duty cycle of the yellow led
\     - An I2C driver
\     - Wii nunchuk tasks to fetch and display the joystick xy-coordinates,
\       pushbutton positions, and accelerometer values on the serial 
\       terminal
\
\  Hardware:
\     - STM32F051K8T6 on DIP conversion board
\     - Two leds, yellow on PF0, green on PF1 (330 ohm dropping resistors)
\     - Pushbutton with internal pullup and software debounce on PA4
\     - Rotary encoder with 30 alternate detents on PA0 and PA1 with
\       internal pullups and hardware debounce.
\     - Wii nunchuk with adapter on I2C1 SCL/PB6 and SDA/PB7, external
\       bus pullups of 4.7 Kohms.
\
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
\  2018.02.02
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
  RCC $10 + constant RCC_APB1RSTR
  RCC $14 + constant RCC_AHBENR
  \ RCC $18 + constant RCC_APB2ENR
  RCC $1C + constant RCC_APB1ENR
  \ RCC $20 + constant RCC_BDCR
  \ RCC $24 + constant RCC_CSR
  \ RCC $28 + constant RCC_AHBRSTR
  \ RCC $2C + constant RCC_CFGR2
  RCC $30 + constant RCC_CFGR3
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
  \ GPIOA $00 + constant GPIOA_MODER
  \ GPIOA $04 + constant GPIOA_OTYPER
  \ GPIOA $08 + constant GPIOA_OSPEEDR
  GPIOA $0C + constant GPIOA_PUPDR
  GPIOA $10 + constant GPIOA_IDR
  \ GPIOA $14 + constant GPIOA_ODR
  \ GPIOA $18 + constant GPIOA_BSRR
  \ GPIOA $1C + constant GPIOA_LCKR
  \ GPIOA $20 + constant GPIOA_AFRL
  \ GPIOA $24 + constant GPIOA_AFRH
  \ GPIOA $28 + constant GPIOA_BRR

$48000400 constant GPIOB
  GPIOB $00 + constant GPIOB_MODER
  GPIOB $04 + constant GPIOB_OTYPER
  GPIOB $08 + constant GPIOB_OSPEEDR
  \ GPIOB $0C + constant GPIOB_PUPDR
  \ GPIOB $10 + constant GPIOB_IDR
  \ GPIOB $14 + constant GPIOB_ODR
  \ GPIOB $18 + constant GPIOB_BSRR
  \ GPIOB $1C + constant GPIOB_LCKR
  GPIOB $20 + constant GPIOB_AFRL
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

$40005400 constant I2C1
  I2C1 $00 + constant I2C1_CR1
  I2C1 $04 + constant I2C1_CR2
  I2C1 $08 + constant I2C1_OAR1
  \ I2C1 $0C + constant I2C1_OAR2
  I2C1 $10 + constant I2C1_TIMINGR
  \ I2C1 $14 + constant I2C1_TIMEOUTR
  I2C1 $18 + constant I2C1_ISR
  I2C1 $1C + constant I2C1_ICR
  \ I2C1 $20 + constant I2C1_PECR
  I2C1 $24 + constant I2C1_RXDR
  I2C1 $28 + constant I2C1_TXDR

\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\ Null (event sink) action used by pushbutton and rotary encoder tasks.
: null-act ( -- )  nop ;

\ Wait while the word test with address 'test results in a true, or until
\ timeout ends.  Returns status = 0 if exits before timeout, returns
\ status = 1 if timeout occurs. 
: timed ( 'test -- status )
    $FFFF                             \ Timeout value
    begin swap dup execute while
      swap 1- dup 0= if
        2drop 1 exit                  \ Timed out
      then
    repeat
    2drop 0                           \ 'test became false before timeout 
; 

\ Blocking delays (approximate) for 48 MHz system clock
\ 52000 constant LOOPS/MS
\ : ms-delay ( n -- )   LOOPS/MS * 4 rshift 0 DO nop LOOP ;

\ 52 constant LOOPS/US
\ : us-delay ( n -- )   LOOPS/US * 4 rshift 0 DO nop LOOP ;

\ Aids to simple printing
: hex.dec ( n|u -- )  hex . decimal ;
: tab ( -- )  9 emit ;

\ -------------------------------------------------------------------------
\  Clock setup and timing plus USART1 baud set to 115200 for cortex-m0.
\  Uses 8 MHz internal oscillator divided by 2 and x12 PLL multiplier.
\
\  Clock initialization code is modified from usb-f1.txt by Jean-Claude
\  Wippler.
\  Adjusted for STM32F030 @ 48 MHz (original STM32F100 by Igor de om1zz).
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

3 constant SysTick_PRIORITY
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

  \ Enable GPIOB peripheral clock and set pins PB6 and PB7 for I2C1,
  \ open drain, low speed, alternate function 1
  %1 18 lshift RCC_AHBENR bis!
  %1010 12 lshift GPIOB_MODER bis!
  %11 6 lshift GPIOB_OTYPER bis!
  %0101 12 lshift GPIOB_OSPEEDR bic!
  %0001 28 lshift %0001 24 lshift or GPIOB_AFRL bis!
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
  \ Register with rotary encoder
  ['] led1-dc+ 'enc1-CW-Act !
  ['] led1-dc- 'enc1-CCW-Act !
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

: led2-init ( -- )
  led2-off
  \ Register with pushbutton
  ['] led2-on 'pb1-Short-Act !
  ['] led2-off 'pb1-Long-Act !
;

\ -------------------------------------------------------------------------
\  I2C1 driver for master send and receive, 7 bit addressing.
\  I2C speed is determined by value of variable i2c1-Fast (0 = 100 KHz,
\  1 = 400 KHz).  Timing values are from Table 76 of RM0360 for I2CCLK =
\  SYSCLK = 48 MHz.
\ -------------------------------------------------------------------------
1 variable i2c1-Fast

: i2c1-init ( -- )
  %1 21 lshift RCC_APB1ENR bis!   \ Enable peripheral clock
  %1 4 lshift RCC_CFGR3 bis!      \ I2C1 clock source is SYSCLK
  %1 21 lshift RCC_APB1RSTR bis!  \ Force reset
  %1 21 lshift RCC_APB1RSTR bic!  \ Clear reset

  %1 I2C1_CR1 bic!                \ Disable I2C1
  %11 20 lshift I2C1_CR1 bic!     \ I2C mode
  %1 12 lshift I2C1_CR1 bic!      \ Enable analog filter
  %1111 8 lshift I2C1_CR1 bic!    \ Disable digital filter
  %1 17 lshift I2C1_CR1 bic!      \ Enable clock stretching

  $F0FFFFFF I2C1_TIMINGR bic!     \ Clear timing register     
  i2c1-Fast @ if
    $50330309 I2C1_TIMINGR bis!   \ Use fast timing parameters
  else
    $B0420F13 I2C1_TIMINGR bis!   \ Use slow timing parameters
  then

  %1 11 lshift I2C1_CR2 bic!      \ Use 7 bit address mode
  %1 25 lshift I2C1_CR2 bic!      \ Disable auto end mode
  
  %1 I2C1_CR1 bis!                \ Enable I2C1
;

\ These words are used for timed waits
\ Return true if I2C1 busy, false if not busy
: i2c1-busy? ( -- flag )  %1 15 lshift I2C1_ISR bit@ ;

\ Return true if the I2C1 rx buffer is empty
: i2c1-nrxne? ( -- flag )  %1 2 lshift I2C1_ISR bit@ not ;

: i2c1-ntxis? ( -- flag )  %1 1 lshift I2C1_ISR bit@ not ;

\ Return true if stop flag not set
: i2c1-nstopf? ( -- flag)  %1 5 lshift I2C1_ISR bit@ not ;

\ I2C1 read/write nbytes bytes into/from buffer with address buf-addr
\ to slave with (left-shifted) address slave-addr
: i2c1-read ( buf-addr slave-addr nbytes -- exit-status )

  \ If nbytes = 0, nothing to do
  dup 0= if
    2drop drop 0 exit
  then
  
  ['] i2c1-busy? timed if
    2drop drop 
    \ cr cr ." i2c1-read: bus is busy timeout" cr
    1 exit
  then
  \ Prepare for transfer
  $0 I2C1_CR2 !                 \ Clear register
  swap over 16 lshift or        \ Slave address (consumed) and num bytes
  %1 25 lshift or               \ Auto end mode
  %1 10 lshift or               \ Master read
  %1 13 lshift or I2C1_CR2 !    \ Start transfer

  0 do  \ nbyte consumed, only buf-addr remains
    \ Wait until rx buffer has data
    ['] i2c1-nrxne? timed if
      drop 
      \ cr cr ." i2c1-read: rx buffer empty timeout" cr
      2 unloop exit
    then
    \ Receive next byte of data
    dup i + I2C1_RXDR c@ swap c!
  loop
  drop    \ Drop buf-addr
  
  0   \ No error exit status
;

: i2c1-write ( buf-addr slave-addr nbytes -- exit-status )

  \ If nbytes = 0, nothing to do
  dup 0= if 
    2drop drop 0 exit
  then
  
  ['] i2c1-busy? timed if
    2drop drop 
    \ cr cr ." i2c1-write: bus is busy timeout" cr
    1 exit
  then
  
  \ Prepare for transfer
  $0 I2C1_CR2 !                 \ Clear register
  swap over 16 lshift or        \ Slave address (consumed) and num bytes
  %1 25 lshift or               \ Auto end mode
  %1 13 lshift or I2C1_CR2 !    \ Start write transfer
  
  0 do  \ nbyte consumed, only buf-addr remains
    \ Wait until tx buffer is empty
    ['] i2c1-ntxis? timed if
      drop 
      \ cr cr ." i2c1-write: tx buffer not empty timeout" cr
      2 unloop exit
    then
    \ Send next byte of data
    dup i + c@ I2C1_TXDR c!
    \ Stop transfer if data byte is not acknowledged by slave
    %1 4 lshift I2C1_ISR @ and if
      \ cr cr ." i2c1-write: tx stopped early, slave NACK" cr
      leave
    then
  loop
  drop    \ Drop buf-addr

  ['] i2c1-nstopf? timed if
    \ cr cr ." i2c1-write: no stop generated timeout" cr
    3 exit
  then
  %1 5 lshift I2C1_ICR bis!   \ Clear stop flag
  %1 4 lshift I2C1_ISR @ and if   \ NACK received from slave?
    \ cr cr ." i2c1-write: NACK at end of transfer" cr
    4 exit
  then

  0   \ No error exit status
;

\ -------------------------------------------------------------------------
\  Wii nunchuk
\ -------------------------------------------------------------------------
$52 1 lshift constant NCHK_ADDR   \ Pre-shifted slave address
3 buffer: nchk-Init-Buf   \ Byte buffer for nunchuk initialization 

: nchk-init-hw ( -- )
  1 i2c1-Fast !   \ Use fast speed
  i2c1-init
;

: nchk-init
  \ To initialize nunchuk, write buffer with $40, $00, $00 and send
  $40 nchk-Init-Buf c!
  $00 nchk-Init-Buf 1 + c!
  $00 nchk-Init-Buf 2 + c!
  nchk-Init-Buf NCHK_ADDR 3 i2c1-write
  dup 0= if 
    drop
  else
    cr ." Problem inititializing nunchuk, exit code " .
  then
  
  \ Note:  Some Wii nunchuks require a different initialization sequence.
  \        For these send the two bytes $F0 $55; then send $FB, $00.
;

\ Buffer to hold nunchuk data register byte values
6 buffer: nchk-Reg

\ Values calculated from nunchuk data, stored as seven half words
\ Joy-X, Joy-Y, C-Button, Z-Button, Accel-X, Accel-Y, Accel-Z
14 buffer: nchk-Vals

\ Nunchuk read state machine states
0 constant NCHK_RD_WRT_ADDR
1 constant NCHK_RD_WT
2 constant NCHK_RD_RG
3 constant NCHK_RD_CLC1
4 constant NCHK_RD_CLC2
\ State variable for state machine in nchk-read
0 variable nchk-Rd-St

\ Read nunchuk data register, then calculate derived values.
\ Uses state machine to split up retrieval of nunchuk data and the
\ calculation of derived values across five main loop cycles.
: nchk-read
  nchk-Rd-St @ case
  
    NCHK_RD_WRT_ADDR of  \ Write data register address $00 to nunchuk
      $00 nchk-Init-Buf c!
      nchk-Init-Buf NCHK_ADDR 1 i2c1-write
      dup 0= if 
        drop
      else
        cr ." Problem sending data reg addr, exit code " .
      then
      NCHK_RD_WT nchk-Rd-St ! 
    endof
  
    NCHK_RD_WT of  \ Wait min of 250 us for nunchuk to respond with data
      NCHK_RD_RG nchk-Rd-St !    
    endof

    NCHK_RD_RG of  \ Read six bytes from nunchuk data register
      nchk-Reg NCHK_ADDR 6 i2c1-read
      dup 0= if 
        drop
      else
        cr ." Problem reading data, exit code " .
      then
      NCHK_RD_CLC1 nchk-Rd-St !
    endof

    NCHK_RD_CLC1 of   \ Calculate joystick coordinates and button values
    
      nchk-Reg c@ nchk-Vals h!                \ Joystick x
      nchk-Reg 1 + c@ nchk-Vals 2 + h!        \ Joystick y
      
      nchk-Reg 5 + c@ $03 and 1+ $03 and dup
      1 rshift nchk-Vals 4 + h!               \ C-Button (1 = pushed)
      $01 and nchk-Vals 6 + h!                \ Z-Button (1 = pushed)
   
      NCHK_RD_CLC2 nchk-Rd-St !
    endof
    
    NCHK_RD_CLC2 of   \ Calculate accelerometer values
    
      nchk-Reg 2 + c@ 2 lshift 
      nchk-Reg 5 + c@ $0C and 2 rshift
      + nchk-Vals 8 + h!                      \ Accelerometer x
      
      nchk-Reg 3 + c@ 2 lshift 
      nchk-Reg 5 + c@ $30 and 4 rshift
      + nchk-Vals 10 + h!                     \ Accelerometer y

      nchk-Reg 4 + c@ 2 lshift 
      nchk-Reg 5 + c@ $C0 and 6 rshift
      + nchk-Vals 12 + h!                     \ Accelerometer z
       
      NCHK_RD_WRT_ADDR nchk-Rd-St !
    endof
  
  endcase  
;

223 constant NCHK_TCK_DLY     \ About 4 write cycles per second
0 variable nchk-Dly-Cnt       \ Tick count for delay between displays

\ Display state machine states
0 constant NCHK_DSPLY_BGN
1 constant NCHK_DSPLY_DLY
2 constant NCHK_DSPLY_JY
3 constant NCHK_DSPLY_BT
4 constant NCHK_DSPLY_ACCL
\ State variable for display state machine
0 variable nchk-Dsply-St
\ Sub-state machine state variable
0 variable nchk-Dsply-Cnt

\ State machine that splits up writing nunchuk derived values to terminal
\ into several parts.  Also handles delay interval between write cycles.
: nchk-display
  nchk-Dsply-St @ case
  
    NCHK_DSPLY_BGN of                 \ Initialize write cycle
      NCHK_TCK_DLY nchk-Dly-Cnt !     \ Load delay tick count
      NCHK_DSPLY_DLY nchk-Dsply-St !
    endof
  
    NCHK_DSPLY_DLY of                 \ Wait for delay between writes 
      nchk-Dly-Cnt dup @ 1- dup rot !
      0= if
        NCHK_DSPLY_JY nchk-Dsply-St !
        0 nchk-Dsply-Cnt !
      then
    endof
  
    NCHK_DSPLY_JY of                  \ Write joystick values
      nchk-Dsply-Cnt @ case
        0 of
          cr
          tab ." Joy-x: " nchk-Vals h@ hex.dec
          1 nchk-Dsply-Cnt +!
        endof
        1 of
          tab ." Joy-y: " nchk-Vals 2 + h@ hex.dec
          1 nchk-Dsply-Cnt +!
          NCHK_DSPLY_BT nchk-Dsply-St !
        endof
      endcase
    endof
    
    NCHK_DSPLY_BT of                  \ Write button values
      nchk-Dsply-Cnt @ case
        2 of
          tab ." C: " nchk-Vals 4 + h@ hex.dec
          1 nchk-Dsply-Cnt +!
        endof
        3 of
          tab ." Z: " nchk-Vals 6 + h@ hex.dec
          1 nchk-Dsply-Cnt +!
          NCHK_DSPLY_ACCL nchk-Dsply-St !          
        endof
      endcase
    endof
      
    NCHK_DSPLY_ACCL of                \ Write accelerometer values
      nchk-Dsply-Cnt @ case
        4 of
          tab ." Accel-x: " nchk-Vals 8 + h@ hex.dec
          1 nchk-Dsply-Cnt +!
        endof
        5 of
          tab ." Accel-y: " nchk-Vals 10 + h@ hex.dec
          1 nchk-Dsply-Cnt +!
        endof
        6 of
          tab ." Accel-z: " nchk-Vals 12 + h@ hex.dec
          NCHK_DSPLY_BGN nchk-Dsply-St !          
        endof
      endcase
    endof
  
  endcase
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
  nchk-init-hw  \ Initialize i2c for nunchuk
  eint          \ Global interrupt enable

  \ Tasks
  pb1-init
  enc1-init
  led1-init
  led2-init
  nchk-init

  \ ---------------- Main loop --------------------------------------------
  begin wait-for-tick
    \ Inputs  
    pb1-task
    enc1-task
    nchk-read
    \ Outputs
    led1-task
    nchk-display
  key? until            \ Escape from main loop on key press
;

\ -------------------------------------------------------------------------
compiletoram
