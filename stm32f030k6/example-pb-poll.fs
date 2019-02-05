\ ========================================================================= 
\  Program Name: example-pb-poll.fs for Mecrisp-Stellaris by Matthias Koch
\ 
\  This program is a template for larger projects, as it includes a main
\  loop controlled by the SysTick timer.  There are four tasks:
\ 
\     - A flashing yellow led with variable duty cycle
\			- A green led that is turned on (short push) and off (long push) by
\       a pushbutton
\ 		- A pushbutton driver (polled version)
\			- A driver for a rotary encoder with alternate detents that increases
\       (cw) or decreases (ccw) the duty cycle of the yellow led
\  
\  Hardware: 
\			- STM32F030K6T6 on DIP conversion board
\     - Two leds, yellow on PF0, green on PF1 (330 ohm dropping resistors)
\     - Pushbutton with internal pullup and software debounce on PA4
\		 	- Rotary encoder with 30 alternate detents on PA0 and PA1 with
\ 		  internal pullups.
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
\			- All words are in lower case with parts separted by hyphens.  
\ 		-	Program constants are in upper case, with parts separated by
\ 			underscores.
\ 		-	Variables and words	associated with a task are prefixed by the 
\ 			task name (which is in lower case) with subsequent parts of
\				variable names having the initial letter in upper case and
\				separated by hyphens.  
\ 		-	Variables acting as function pointers (containing the address
\ 			of a word) have a tick prefix.
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.01.24
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

\ $E000E100 constant NVIC
  \ NVIC $000 + constant NVIC_ISER
  \ NVIC $080 + constant NVIC_ICER
  \ NVIC $100 + constant NVIC_ISPR
  \ NVIC $180 + constant NVIC_ICPR
  \ NVIC $300 + constant NVIC_IPR0

\ $E000ED00 constant SCB
  \ SCB $01C + constant SCB_SHPR2

$40021000 constant RCC
  RCC $00 + constant RCC_CR
  RCC $04 + constant RCC_CFGR
  \ RCC $08 + constant RCC_CIR
  \ RCC $0C + constant RCC_APB2RSTR
  \ RCC $10 + constant RCC_APB1RSTR
  RCC $14 + constant RCC_AHBENR
  \ RCC $18 + constant RCC_APB2ENR
  \ RCC $1C + constant RCC_APB1ENR
  \ RCC $20 + constant RCC_BDCR
  \ RCC $24 + constant RCC_CSR
  \ RCC $28 + constant RCC_AHBRSTR
  \ RCC $2C + constant RCC_CFGR2
  \ RCC $30 + constant RCC_CRGR3
  \ RCC $34 + constant RCC_CR2

$40022000 constant FLASH
  FLASH $0 + constant FLASH_ACR

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

\ -------------------------------------------------------------------------
\  Misc. helper words and variables
\ -------------------------------------------------------------------------
\  Null (event sink) action used by pushbutton and rotary encoder tasks.
: null-act ( -- )  nop ;

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

  %1 RCC_CR bis!               					\ set HSION
  begin %1 1 lshift RCC_CR bit@ until  \ wait for HSIRDY

  %10001 FLASH_ACR !		\ One flash wait state, enable prefetch buffer

  \ HSI clock /2 = 4 MHz source for PLL
	%1111 18 lshift RCC_CFGR bic!
  %1010 18 lshift RCC_CFGR bis!   \ PLL factor: 4 MHz * 12 = 48 MHz

	%1111 4 lshift RCC_CFGR bic!		\ HPRE DIV 1, HCLK = SYSCLK
  %111  8 lshift RCC_CFGR bic!    \ PPRE DIV 1, PCLK = HCLK

  %1 24 lshift RCC_CR bis!              	\ set PLLON
  begin %1 25 lshift RCC_CR bit@ until  	\ wait for PLLRDY

	%11 RCC_CFGR bic!
	%10 RCC_CFGR bis!								\ PLL is system clock

  $1A1 USART1_BRR !               \ Set console baud rate to 115200
;

\ -------------------------------------------------------------------------
\  Set up SysTick for main loop 1 ms tick
\ -------------------------------------------------------------------------
1 constant MAIN_TICKS  \ Number of systicks for main loop repeat
MAIN_TICKS variable main-Tick-Cnt

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

	['] systick-handler irq-systick !		\ Register systick-handler
	%010 SysTick_CTRL bis!                \ Enable SysTick interrupt
;

\ -------------------------------------------------------------------------
\  Initialize gpio peripheral clocks and pins
\ -------------------------------------------------------------------------
: gpio-init ( -- )
	\ Enable GPIOF peripheral clock and set pins PF0 and PF1 as output
	\ (push-pull, low speed) for leds
	%1 22 lshift RCC_AHBENR bis!
	%0101 GPIOF_MODER !
	
	\ Enable GPIOA peripheral clock and set pins PA0, PA1, and PA4 to
  \ input with internal pullups
  %1 17 lshift RCC_AHBENR bis!
  %01 8 lshift %01 2 lshift or %01 or GPIOA_PUPDR bis!
;

\ -------------------------------------------------------------------------
\  Pushbutton driver for pushbutton pb0 on pin PA4 with software debounce.
\  This is a polling version that assumes that pb1-task is called in the
\  main loop.
\  Input pin value is assumed low on push, high (pulled up) on release.
\  Pushbutton action occurs when button is released.
\  There are two types of pushes, short (<= 1 sec) and long (> 1 sec).  
\  A client task registers short and long push actions (event sinks)
\  by loading the associated word addresses into the pointer variables
\  'pb1-Short-Act and 'pb1-Long-Act, resp. 
\ -------------------------------------------------------------------------
%1 4 lshift constant PB1_UP
%0 4 lshift constant PB1_DOWN
%1 4 lshift constant PB1_MASK

PB1_UP variable pb1-Val
PB1_UP variable pb1-Last-Val	
0 variable pb1-Timer

' null-act variable 'pb1-Short-Act
' null-act variable 'pb1-Long-Act

: pb1-get ( -- )  GPIOA_IDR @ PB1_MASK and pb1-Val ! ;

: pb1-init ( -- )
	pb1-get
	pb1-Val @ pb1-Last-Val !
	['] null-act 'pb1-Short-Act !
	['] null-act 'pb1-Long-Act !
;

: pb1-task ( -- )
	pb1-get
	pb1-Val @ PB1_DOWN = if
		1 pb1-Timer +!		\ Increment timer when button is down
	else
		pb1-Last-Val @ PB1_DOWN = if	\ Button just released?
			pb1-Timer @ 1000 > if				\ Long push if more than 1000 main ticks
				'pb1-Long-Act @ execute
			else
				pb1-Timer @ 20 > if					\ Debounce delay 20 main loop ticks
					'pb1-Short-Act @ execute
				then
			then
		then
		0 pb1-Timer !		\ Reset timer when button is up
	then
	pb1-Val @ pb1-Last-Val !
;

\ -------------------------------------------------------------------------
\  Rotary encoder driver (alternating detent type) on PA0 and PA1.
\  (If encoder does not have alternating detents, see comment below.)
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

	enc1-ChA-Val @ 0= enc1-ChA-Last-Val @ 0<>	and if
		enc1-ChB-Val @ 0<> if
			'enc1-CW-Act @ execute
		else
			'enc1-CCW-Act @ execute
		then
	then

	\ If rotary encoder does not have alternating detents, comment out
	\ the if-then below
	enc1-ChA-Val @ 0<> enc1-ChA-Last-Val @ 0=	and if
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
  	GPIOF_ODR @ LED1_MSK and dup if		\ Is led on?
  		GPIOF_BRR bis!									\ Turn led off
  		led1-Off-Cnt @ led1-Cnt !				\ Load off tick count
  	else
  		drop LED1_MSK GPIOF_BSRR bis!		\ Turn led on
  		led1-On-Cnt @ led1-Cnt !				\ Load on tick count
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
\  Main program that starts on reset
\ -------------------------------------------------------------------------
:	init ( -- )

	\	---------------- Initialization ---------------------------------------
	\ Hardware
	dint					\ Disable all interrupts
	48MHz					\ Set system clock to 48 MHz
	systick-init  \ Initialize system tick
	gpio-init			\ Initialize port pins
	eint					\ Enable global interrupts

	\ Tasks
	pb1-init
	enc1-init
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
