\ =========================================================================
\  Program: example-ssd1306.fs for Mecrisp-Stellaris by Matthias Koch
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
\     - An SSD1306 128 x 32 monochrome display which shows various messages
\
\  Hardware:
\     - STM32F051K8T6 on DIP conversion board
\     - Two leds, yellow on PF0, green on PF1 (330 ohm dropping resistors)
\     - Pushbutton with internal pullup and software debounce on PA4
\     - Rotary encoder with 30 alternate detents on PA0 and PA1 with
\       internal pullups and hardware debounce.
\     - SSD1306 128 x 32 display on I2C1 SCL/PB6 and SDA/PB7, external
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
\  2018.02.04
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
52000 constant LOOPS/MS
: ms-delay ( n -- )   LOOPS/MS * 4 rshift 0 DO nop LOOP ;

\ 52 constant LOOPS/US
\ : us-delay ( n -- )   LOOPS/US * 4 rshift 0 DO nop LOOP ;

\ Aids to simple printing
\ : hex.dec ( n|u -- )  hex . decimal ;
\ : tab ( -- )  9 emit ;

\ To store halfword with high and low bytes swapped
: h><, ( hx -- )
  dup $00FF and 8 lshift
  swap $FF00 and 8 rshift
  or h, ;

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
\  Drivers for OLED display with SSD1306 driver using I2C1.  The display
\  is treated as a character display with NUM_ROWS rows and NUM_COLS
\  columns.
\
\  There are two modes of use.  In both modes the display buffer
\  contents are sent to the display using the task
\
\                     ssd1306-show
\
\  This task is called in the main loop and writes one character
\  to the display per main loop tick (except for one initialization
\  tick).
\
\  In non-scrolling mode, strings are written to the display with a
\  specified starting row and column using the functions:
\
\                     ssd1306-wrt-str
\                     ssd1306-clr-str
\                     ssd1306-clr-row
\                     ssd1306-clr-scrn
\
\  In this mode, the display buffer is treated as non-circular for display
\  purposes, although writing a long string to it can wrap around to the
\  start.
\
\  In scrolling mode, strings are written at the display bottom row and
\  the rows above the bottom row are scrolled upward using the function:
\
\                     ssd1306-str-scroll
\
\  In this mode, the display buffer is treated as circular to facilitate
\  scrolling, with the display starting at the index value in the variable
\  ssd1306-Buf-Start.
\
\  The reset mode is non-scrolling with ssd1306-Buf-Start = 0, but if the
\  scrolling display function is used, the mode switches to scrolling.
\  To return to non-scrolling mode within a program, call the function:
\
\                     ssd1306-rst-scroll
\
\  which resets ssd1306-Buf-Start to zero and also clears the screen.
\
\ -------------------------------------------------------------------------
\
\  This code is original with these exceptions:
\
\  The initialization function is based on tut7-SSD1306 example code with
\  this in its header:
\
\  Originally from Olivier Van den Eede 2016
\  Modified by Le Tan Phuc to be suitable for SSD1306 0.91" OLED display
\  Work with STM32Cube MX HAL library, Jul 2017
\
\  The SSD1306 commands are from the Adafruit SSD1306 library with
\  this in its header:
\
\  Adafruit SSD1306 library written by Limor Fried/Ladyada
\  for Adafruit Industries.
\  BSD license, check license.txt for more information
\
\  The 5x7 font in glcdfont.fs is taken from the software accompanying
\  Brown's book "Discovering the STM32."
\
\  Andrew Palm
\  2018.02.03
\ -------------------------------------------------------------------------
$78 constant SSD1306_I2C_ADDR   \ SSD1306 I2C address, preshifted
128 constant SSD1306_WIDTH      \ SSD1306 display width in pixels
32 constant SSD1306_HEIGHT      \ SSD1306 LCD height in pixels

$00 constant SSD1306_BLACK
$01 constant SSD1306_WHITE

\ Commands
$81 constant SSD1306_SETCONTRAST
$A4 constant SSD1306_DISPLAYALLON_RESUME
$A5 constant SSD1306_DISPLAYALLON
$A6 constant SSD1306_NORMALDISPLAY
$A7 constant SSD1306_INVERTDISPLAY
$AE constant SSD1306_DISPLAYOFF
$AF constant SSD1306_DISPLAYON

$D3 constant SSD1306_SETDISPLAYOFFSET
$DA constant SSD1306_SETCOMPINS

$DB constant SSD1306_SETVCOMDETECT

$D5 constant SSD1306_SETDISPLAYCLOCKDIV
$D9 constant SSD1306_SETPRECHARGE

$A8 constant SSD1306_SETMULTIPLEX

$00 constant SSD1306_SETLOWCOLUMN
$10 constant SSD1306_SETHIGHCOLUMN

$40 constant SSD1306_SETSTARTLINE

$20 constant SSD1306_MEMORYMODE
$21 constant SSD1306_COLUMNADDR
$22 constant SSD1306_PAGEADDR

$C0 constant SSD1306_COMSCANINC
$C8 constant SSD1306_COMSCANDEC

$A0 constant SSD1306_SEGREMAP

$8D constant SSD1306_CHARGEPUMP

$01 constant SSD1306_EXTERNALVCC
$02 constant SSD1306_SWITCHCAPVCC


$40 constant SSD1306_DC_BIT_DATA
$00 constant SSD1306_DC_BIT_CMD

\ Character row and column sizes
4 constant SSD1306_NUM_ROWS
21 constant SSD1306_NUM_COLS
84 constant SSD1306_BUF_LGT

218 constant BLOCK_CHAR

#include glcdfont.fs      \ Font for display

\ -------------------------------------------------------------------------
2 buffer: ssd1306-Cmd-Buf
\ Write a command to the SSD1306 display controller
: ssd1306-wrtcmd ( cmd-byte -- )
  ssd1306-Cmd-Buf 1 + c!
  SSD1306_DC_BIT_CMD ssd1306-Cmd-Buf c!
  ssd1306-Cmd-Buf SSD1306_I2C_ADDR 2 i2c1-write
  dup 0= if
    drop
  else
    cr ." Problem writing SSD1306 command, exit code " .
  then
;

5 buffer: ssd1306-Fill-Buf
\ Fill display with a single color
: ssd1306-fill-scrn ( color-byte -- )
  SSD1306_WHITE = if $FF else $00 then 
  SSD1306_DC_BIT_DATA ssd1306-Fill-Buf c!
  dup ssd1306-Fill-Buf 1 + c!
  dup ssd1306-Fill-Buf 2 + c!
  dup ssd1306-Fill-Buf 3 + c!
  ssd1306-Fill-Buf 4 + c!

  4 0 do
    $B0 i + ssd1306-wrtcmd      \ Set row (ssd1306 page)
    \ Clear four columns at a time in one row
    SSD1306_WIDTH 2 rshift 0 do
      SSD1306_SETLOWCOLUMN i 2 lshift $F and + ssd1306-wrtcmd
      SSD1306_SETHIGHCOLUMN i 2 rshift $F and + ssd1306-wrtcmd
      ssd1306-Fill-Buf SSD1306_I2C_ADDR 5 i2c1-write
      dup 0= if
        drop
      else
        cr ." Problem filling SSD1306, exit code " .
      then
    loop
  loop
;

7 buffer: ssd1306-Chr-Buf
\ Draw a single character on the display at row and col position
\ Note:  Row and col value limits are not checked here, as this is a
\        helper word.  Values must satisfy 0 <= row < SSD1306_NUM_ROWS,
\        0 <= col < SSD1306_NUM_COLS.
: ssd1306-draw-chr ( row col char -- )

  \ Load character bit pattern into i2c buffer (including one trailing
  \ blank column) to send as 6 data bytes
  SSD1306_DC_BIT_DATA ssd1306-Chr-Buf c!
  6 0 do
    dup 5x7FONT swap 6 * i + + c@ ssd1306-Chr-Buf i + 1+ c!
  loop
  drop    \ Drop char from stack

  swap $B0 + ssd1306-wrtcmd   \ Set row (ssd1306 page), row consumed
  \ Set ssd1306 columns
  6 * 1 + dup
  $F and SSD1306_SETLOWCOLUMN + ssd1306-wrtcmd
  4 rshift $F and SSD1306_SETHIGHCOLUMN + ssd1306-wrtcmd

  ssd1306-Chr-Buf SSD1306_I2C_ADDR 7 i2c1-write
  dup 0= if
    drop
  else
    cr ." Problem writing character to SSD1306, exit code " .
  then

;

SSD1306_BUF_LGT buffer: ssd1306-Txt-Buf
\ Starting index to display, treating ssd1306-Text-Buf as circular
0 variable ssd1306-Buf-Start

0 constant SSD1306_SHOW_START
1 constant SSD1306_SHOW_DRAW
0 variable ssd1306-Show-State

0 variable ssd1306-Show-Row
0 variable ssd1306-Show-Col

\ Show characters in the text buffer on the display.
\ This task is called in the main loop and writes one character
\ to the display per main loop tick (except for one initialization
\ tick), going through all characters in the text buffer.
\ The variable ssd1306-Buf-Start is controlled by the write functions.
\ In non-scrolling mode it will remain zero.  In scrolling mode its value
\ will change to scroll the rows upward in the display.
: ssd1306-show ( -- )
  ssd1306-Show-State @ case

    SSD1306_SHOW_START of
      0 ssd1306-Show-Row !
      0 ssd1306-Show-Col !
      SSD1306_SHOW_DRAW ssd1306-Show-State !
    endof

    SSD1306_SHOW_DRAW of
      ssd1306-Show-Row @
      ssd1306-Show-Col @
      over SSD1306_NUM_COLS * over + ssd1306-Buf-Start @ +
      SSD1306_BUF_LGT mod ssd1306-Txt-Buf + c@
      ssd1306-draw-chr

      1 ssd1306-Show-Col +!
      ssd1306-Show-Col @
      SSD1306_NUM_COLS >= if
        0 ssd1306-Show-Col !
        1 ssd1306-Show-Row +!
        ssd1306-Show-Row @
        SSD1306_NUM_ROWS >= if
          SSD1306_SHOW_START ssd1306-Show-State !
        then
      then
    endof

  endcase
;

\ -------------------------------------------------------------------------
\ These tasks are for non-scrolling mode only.

\ Write a string to the display buffer starting at row and col position.
\ Text is wrapped if it exceeds buffer size.
: ssd1306-wrt-str ( row col str-addr str-lgt  -- )
  \ Check limits 0 <= row < SSD1306_NUM_ROWS
  3 pick dup 0< swap SSD1306_NUM_ROWS 1 - > or if
    drop drop drop drop exit
  then
  \ Check limits 0 <= col < SSD1306_NUM_COLS
  2 pick dup 0< swap SSD1306_NUM_COLS 1 - > or if
    drop drop drop drop exit
  then

  \ Calculate starting index in text buffer
  3 pick SSD1306_NUM_COLS * 3 pick + -rot

  0 do
    \ ( stack: row col start str-addr )
    dup i + c@ 2 pick i + SSD1306_BUF_LGT mod
    ssd1306-Txt-Buf + c!
  loop
  drop drop drop drop
;

\ Clear cnt characters of text starting at row and col posittion.
\ Must have 0<=row<=3 and 0<=col<=21.  Wraps in the text buffer.
: ssd1306-clr-str ( row col cnt -- )
  \ Check limits 0 <= row < SSD1306_NUM_ROWS
  2 pick dup 0< swap SSD1306_NUM_ROWS 1 - > or if
    drop drop drop exit
  then
  \ Check limits 0 <= col < SSD1306_NUM_COLS
  over dup 0< swap SSD1306_NUM_COLS 1 - > or if
    drop drop drop exit
  then

  \ Calculate starting index in text buffer
  2 pick SSD1306_NUM_COLS * 2 pick + swap

  0 do
    \ ( stack: row col start )
    dup i + SSD1306_BUF_LGT mod
    ssd1306-Txt-Buf + 32 swap c!    \ Load space
  loop
  drop drop drop
;

: ssd1306-clr-row ( row -- )
  \ Check limits 0 <= row < SSD1306_NUM_ROWS
  dup dup 0< swap SSD1306_NUM_ROWS 1 - > or if
    drop exit
  then

  0 SSD1306_NUM_COLS ssd1306-clr-str
;

: ssd1306-clr-scrn ( -- )
  0 0 SSD1306_BUF_LGT ssd1306-clr-str
;

\ -------------------------------------------------------------------------
\ These tasks are for scrolling mode

\ Write text to the bottom line of the display, shifting the other rows
\ upward.  If the text is shorter than one row, trailing blanks are
\ added.  If the text is longer than one row, rows are added at the
\ bottom until all the text is written (with trailing blanks on the
\ last row, if needed).  If the text is longer than all rows in the
\ display, then only the last group of characters that fits in the
\ display will be shown.
: ssd1306-str-scroll ( str-addr str-lgt -- )
  \ Exit if string length non-positive
  dup 0 <= if
    drop exit
  then
  \ Prepare to over-write previous first row with new bottom row
  ssd1306-Buf-Start @ dup 
  \ ( stack: str-addr str-lgt new-row-start old-start)
  \ Make previously second row now the first row
  SSD1306_NUM_COLS + SSD1306_BUF_LGT mod ssd1306-Buf-Start !
  \ ( stack: str-addr str-lgt new-row-start)
  \ Write out new bottom row, with trailing blanks, if needed
  SSD1306_NUM_COLS 0 do
    dup i + SSD1306_BUF_LGT mod ssd1306-Txt-Buf +
    \ ( stack: str-addr str-lgt new-row-start store-addr)
    2 pick i > if
      3 pick i + c@ swap c!   \ i < str-lgt, write next char from str
    else
      32 swap c!               \ i >= str-lgt, write space
    then 
  loop
  drop drop drop
;

\ Switch back to non-scrolling mode and clear the display
: ssd1306-rst-scroll ( -- )
  0 ssd1306-Buf-Start !
  ssd1306-clr-scrn
;

\ -------------------------------------------------------------------------
\ Initialization tasks
: ssd1306-init-hw
  1 i2c1-Fast !
  i2c1-init
  100 ms-delay

  SSD1306_DISPLAYOFF ssd1306-wrtcmd

  SSD1306_MEMORYMODE ssd1306-wrtcmd
  $02 ssd1306-wrtcmd    \ Page address mode

  SSD1306_SETCONTRAST ssd1306-wrtcmd
  $F0 ssd1306-wrtcmd

  SSD1306_NORMALDISPLAY ssd1306-wrtcmd

  SSD1306_SETMULTIPLEX ssd1306-wrtcmd
  SSD1306_HEIGHT 1 - ssd1306-wrtcmd

  SSD1306_DISPLAYALLON_RESUME ssd1306-wrtcmd

  SSD1306_SETDISPLAYOFFSET ssd1306-wrtcmd
  $00 ssd1306-wrtcmd

  SSD1306_SETDISPLAYCLOCKDIV ssd1306-wrtcmd
  $80 ssd1306-wrtcmd

  SSD1306_SETPRECHARGE ssd1306-wrtcmd
  $22 ssd1306-wrtcmd

  SSD1306_SETCOMPINS ssd1306-wrtcmd
  $02 ssd1306-wrtcmd    \ 128*32

  SSD1306_SETVCOMDETECT ssd1306-wrtcmd
  $40 ssd1306-wrtcmd

  SSD1306_CHARGEPUMP ssd1306-wrtcmd
  $14 ssd1306-wrtcmd

  SSD1306_DISPLAYON ssd1306-wrtcmd
;

: ssd1306-splash1 s" *********************" ;
: ssd1306-splash2 s" *    Andrew Palm    *" ;
: ssd1306-splash3 s" *     Feb, 2018     *" ;

: ssd1306-init
  SSD1306_BLACK ssd1306-fill-scrn
  0 ssd1306-Buf-Start !     \ Non-scrolling mode

  0 0 ssd1306-splash1 ssd1306-wrt-str
  1 0 ssd1306-splash2 ssd1306-wrt-str
  2 0 ssd1306-splash3 ssd1306-wrt-str
  3 0 ssd1306-splash1 ssd1306-wrt-str
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
    s" Led 1 incr duty cycle" ssd1306-str-scroll
  else
    drop drop
  then
;

: led1-dc- ( -- )
  \ Decrease led duty cycle
  led1-On-Cnt @ LED1_DEL_TKS - dup dup LED1_MIN_TKS >= if
    led1-On-Cnt !
    LED1_MAX_TKS swap - led1-Off-Cnt !
    s" Led 1 decr duty cycle" ssd1306-str-scroll
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

: led2-off ( -- )
  LED2_MSK GPIOF_BRR bis!
  s" Led 2 off" ssd1306-str-scroll
;

: led2-on ( -- )  
  LED2_MSK GPIOF_BSRR bis!
  s" Led 2 on" ssd1306-str-scroll
;

: led2-init ( -- )
  led2-off
  \ Register with pushbutton
  ['] led2-on 'pb1-Short-Act !
  ['] led2-off 'pb1-Long-Act !
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
  ssd1306-init-hw  \ Initialize I2C1 and SSD1306 display controller
  eint          \ Global interrupt enable

  \ Tasks
  pb1-init
  enc1-init
  led1-init
  led2-init
  ssd1306-init

  \ ---------------- Main loop --------------------------------------------
  begin wait-for-tick
    \ Inputs
    pb1-task
    enc1-task
    \ Outputs
    led1-task
    ssd1306-show
  key? until            \ Escape from main loop on key press
;

\ -------------------------------------------------------------------------
compiletoram
