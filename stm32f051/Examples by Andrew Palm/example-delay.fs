\ =========================================================================
\  Program Name: example-delay.fs for Mecrisp-Stellaris by Matthias Koch
\
\  Blink an led at 1 Hz rate using blocking delays.
\
\  This example contains code to set the system clock to 48 MHz using
\  the PLL and internal RC oscillator.
\
\  Hardware:
\     - STM32F051K8T6 on DIP conversion board
\     - Led on PF0
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.02.07
\ =========================================================================

compiletoflash
\ -------------------------------------------------------------------------
\  Core and peripheral registers
\  Unused registers are commented out
\ -------------------------------------------------------------------------

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
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
52000 constant LOOPS/MS
: ms-delay ( n -- )
	LOOPS/MS * 4 rshift
	0 DO nop LOOP
;

52 constant LOOPS/US
: us-delay ( n -- )
	LOOPS/US * 4 rshift
	0 DO nop LOOP
;

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
\  Initialize gpio peripheral clocks and pins
\ -------------------------------------------------------------------------
: gpio-init ( -- )
  \ Enable GPIOF peripheral clock and set pin PF0 and PF1 as output
  \ (push-pull, low speed) for led
  %1 22 lshift RCC_AHBENR bis!
  %01 GPIOF_MODER !
;

\ -------------------------------------------------------------------------
\ Led tasks
\ -------------------------------------------------------------------------
%1 constant LED1_MSK

: led1-init ( -- )
  \ Initialize led as off
  %1 GPIOF_ODR bic!
;

: led1-task ( -- )
  \ Toggle led
  %1 GPIOF_ODR xor!
;

\ -------------------------------------------------------------------------
\  Main program that starts on reset
\ -------------------------------------------------------------------------
: init ( -- )

  \ ---------------- Initialization ---------------------------------------
  \ Hardware
  48MHz         \ Set system clock to 48 MHz
  gpio-init     \ Initialize port pins and pin interrupts

  \ Tasks
  led1-init

  \ ---------------- Main loop --------------------------------------------
  begin
    led1-task
    500 ms-delay
  key? until            \ Escape from main loop on key press
;
\ -------------------------------------------------------------------------
compiletoram
