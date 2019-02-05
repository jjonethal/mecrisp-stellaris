\ =========================================================================
\  Program: example-st7735.fs for Mecrisp-Stellaris by Matthias Koch
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
\     - An SPI1 driver
\     - An ST7735 160 x 128 color display which shows various messages
\
\  Hardware:
\     - STM32F051K8T6 on DIP conversion board
\     - Two leds, yellow on PF0, green on PF1 (330 ohm dropping resistors)
\     - Pushbutton with internal pullup and software debounce on PA4
\     - Rotary encoder with 30 alternate detents on PA0 and PA1 with
\       internal pullups and hardware debounce.
\     - Adafruit 160 x 128 color TFT display with ST7735R controller and
\       these connections:
\ 
\           Module Pin   STM32 Pin
\             GND           GND
\             VCC           3V3
\             RESET         PA12
\             D/C           PA11
\             CARD_CS       3V3
\             TFT_CS        PA8
\             MOSI/SDI      PA7
\             SCK           PA5
\             MISO/SDO      PA6
\             LITE          3V3
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
\  2018.02.14
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
  RCC $18 + constant RCC_APB2ENR
  \ RCC $1C + constant RCC_APB1ENR
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

$40013000 constant SPI1
  SPI1 $00 + constant SPI1_CR1
  SPI1 $04 + constant SPI1_CR2
  SPI1 $08 + constant SPI1_SR
  SPI1 $0C + constant SPI1_DR
  SPI1 $10 + constant SPI1_CRCPR
  \ SPI1 $14 + constant SPI1_RXCRCR
  \ SPI1 $18 + constant SPI1_TXCRCR
  \ SPI1 $1C + constant SPI1_I2SCFGR
  \ SPI1 $20 + constant SPI1_I2SPR
  
  
  
\ $40005400 constant I2C1
  \ I2C1 $00 + constant I2C1_CR1
  \ I2C1 $04 + constant I2C1_CR2
  \ I2C1 $08 + constant I2C1_OAR1
  \ I2C1 $0C + constant I2C1_OAR2
  \ I2C1 $10 + constant I2C1_TIMINGR
  \ I2C1 $14 + constant I2C1_TIMEOUTR
  \ I2C1 $18 + constant I2C1_ISR
  \ I2C1 $1C + constant I2C1_ICR
  \ I2C1 $20 + constant I2C1_PECR
  \ I2C1 $24 + constant I2C1_RXDR
  \ I2C1 $28 + constant I2C1_TXDR

\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\ Null (event sink) action used by pushbutton and rotary encoder tasks.
: null-act ( -- )  nop ;

\ Wait while the word test with address 'test results in a true, or until
\ timeout ends.  Returns status = 0 if exits before timeout, returns
\ status = 1 if timeout occurs.
\ : timed ( 'test -- status )
\     $FFFF                             \ Timeout value
\     begin swap dup execute while
\       swap 1- dup 0= if
\         2drop 1 exit                  \ Timed out
\       then
\     repeat
\     2drop 0                           \ 'test became false before timeout
\ ;

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
  or h,
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

  \ Set pins PA5 (SCK), PA6 (MISO), and PA7 (MOSI) for SPI1
  $FFF 20 lshift GPIOA_AFRL bic!        \ Alternate function 0
  %10 10 lshift %10 12 lshift or %10 14 lshift or GPIOA_MODER bis!
  %1 5 lshift %1 7 lshift or GPIOA_OTYPER bic!  \ SCK, MOSI push-pull out
  %11 10 lshift %11 14 lshift or GPIOA_OSPEEDR bis! \ SCK, MOSI high speed
  %01 12 lshift GPIOA_PUPDR bis!                \ MISO input, pullup
 
  \ Configure ST7735 control pins PA8, PA11, and PA12 as push-pull outputs
  %01 16 lshift %01 22 lshift or %01 24 lshift or GPIOA_MODER bis!
  %1 8 lshift %1 11 lshift or %1 12 lshift or GPIOA_OTYPER bic! \ Push-pull
  %11 16 lshift %01 22 lshift or GPIOA_OSPEEDR bis! \ CS high, D/C medium 
  %11 24 lshift or GPIOA_OSPEEDR bic!   \ Reset low speed
;

\ Bit masks and port registers for ST7735 control pins
%1 12 lshift constant ST7735_RST
%1 11 lshift constant ST7735_DC
%1  8 lshift constant ST7735_CS
GPIOA_BRR  constant ST7735_BRR
GPIOA_BSRR constant ST7735_BSRR

\ -------------------------------------------------------------------------
\  SPI1 drivers for 8-bit and 16-bit transfers
\ -------------------------------------------------------------------------
\ 25 constant SPI1_IRQn
\ 2 constant SPI1_PRIORITY

\ SPI speed is set using array SPI1_SPEED, containing bit masks for BR
\ bits in SPI1_CR1.  Index values are 0 = slow/div32, 1 = med/div16,
\ 2 = fast/div4.
create SPI1_SPEED %100 3 lshift , %011 3 lshift , %001 3 lshift ,
%111 3 lshift constant SPI1_BR_MSK

: spi1-set-speed ( speed-index -- )
  SPI1_BR_MSK SPI1_CR1 bic!
  SPI1_SPEED swap 2 lshift + @ SPI1_CR1 bis! 
;

\ ST7735 client tasks use these for slave selection
: spi1-desel-st7735 ( -- )  ST7735_CS ST7735_BSRR bis! ;
: spi1-sel-st7735 ( -- )  ST7735_CS ST7735_BRR bis! ;

: spi1-init ( -- )
  %1 12 lshift RCC_APB2ENR bis!   \ Enable peripheral clock
  
  %1 2 lshift %1 8 lshift or SPI1_CR1 bis!  \ Master mode 
  %11 SPI1_CR1 bic!               \ Phase 1 Edge, clock polarity low
  %1 7 lshift SPI1_CR1 bic!       \ Frame format MSB first
  %1 10 lshift %11 14 lshift or SPI1_CR1 bic!   \ Full duplex
  \ Set speed to fast (div4)
  2 spi1-set-speed
  \ Set data size to 8 bits
  %1111 8 lshift SPI1_CR2 bic!
  %0111 8 lshift SPI1_CR2 bis!
  \ Set crc polynomial reg to 7 (reset value)
  $FFFF SPI1_CRCPR bic!
  %111 SPI1_CRCPR bis!
  \ The next setting is not used in STM32F103 version
  \ It is necessary so that the RXNE flag will be set after a single
  \ byte is received.
  %1 12 lshift SPI1_CR2 bis!
  \ Use software slave management
  %1 9 lshift SPI1_CR1 bis!
  %1 2 lshift SPI1_CR2 bic!

  \ Configure SPI1 interrupt
  \ Set interrupt priority
  \ SPI1_PRIORITY 6 lshift $FF and  \ Priority byte
  \ SPI1_IRQn %11 and 3 lshift      \ Bit shift
  \ lshift
  \ SPI1_IRQn 2 rshift 2 lshift     \ Byte offset from NVIC_IPR0
  \ NVIC_IPR0 + bis!                \ Write priority bits
  \ Enable interrupt
  \ %1 SPI1_IRQn lshift NVIC_ISER bis!

  \ Deselect all devices on bus
  spi1-desel-st7735
  
  \ Enable SPI1 RXNE interrupt  
  \ %1 SPI1_IRQn lshift NVIC_ICPR bis!
  \ %1 6 lshift SPI1_CR2 bis!

  \ Enable SPI1
  %1 6 lshift SPI1_CR1 bis!
;

\ Return true if the SPI1 rx buffer is not empty
: spi1-rxne? ( -- flag )  %1 SPI1_SR bit@ ;

: spi1-rw ( rbuf-addr tbuf-addr cnt spdindx -- )
  \ SPI1 read/write cnt bytes at spi1 speed given by index spdindx
  \ If tbuf-addr is zero, only dummy bytes are transmitted
  \ If rbut-addr is zero, received bytes are discarded
  
  spi1-set-speed    \ (consumes spdindx from stack)   
  dup 0 > if   \ There is data
    0 do          \ Consumes cnt, stack now ( rbuf-addr tbuf-addr )
      dup if
        dup i + c@ $FF and SPI1_DR c!
      else
        $FF SPI1_DR c!
      then
      begin spi1-rxne? until    \ Wait for RXNE set
      over if
        over i + SPI1_DR c@ swap c!
      else
        SPI1_DR c@ drop
      then
    loop
  else
    drop  \ No data, drop cnt
  then
  drop drop   \ Drop rbuf-addr, tbuf-addr
;

: spi1-rw16 ( rbuf-addr tbuf-addr cnt revbits spdindx -- )
  \ SPI1 read/write cnt hwords at spi1 speed given by index spdindx
  \ If revbits is non-zero, send data LSB first
  \ If tbuf-addr is zero, only dummy bytes are transmitted
  \ If rbut-addr is zero, received bytes are discarded
  
  spi1-set-speed      \ (consumes spdindx from stack)
  
  \ Set for 16 bit transfers
  %1111 8 lshift SPI1_CR2 bis!
  %1 12 lshift SPI1_CR2 bic!

  \ Set frame format
  dup if
    %1 7 lshift SPI1_CR1 bis!       \ Frame format LSB first
  then
  \ Stack now ( rbuf-addr tbuf-addr cnt revbits )
  swap 2swap rot
  \ Stack now ( revbits rbuf-addr tbuf-addr cnt )
  dup 0 > if   \ There is data
    0 do       \ Consumes cnt, stack now ( revbits rbuf-addr tbuf-addr -- )
      dup if
        dup i 1 lshift + h@ SPI1_DR h!
      else
        $FFFF SPI1_DR h!
      then
      begin spi1-rxne? until    \ Wait for RXNE set
      over if
        over i 1 lshift + SPI1_DR h@ swap h!
      else
        SPI1_DR h@ drop
      then
    loop
  else
    drop    \ No data, drop cnt  
  then
  drop drop   \ Drop rbuf-addr, tbuf-addr

  \ Reset for 8 bit transfers
  %1111 8 lshift SPI1_CR2 bic!
  %0111 8 lshift SPI1_CR2 bis!
  %1 12 lshift SPI1_CR2 bis!

  if    \ Consumes revbits
    %1 7 lshift SPI1_CR1 bic!  \ Frame format back to default MSB first
  then
;

\ -------------------------------------------------------------------------
\  Drivers for TFT display with ST7735 driver using SPI1.  The display
\  is treated as a character display with NUM_ROWS rows and NUM_COLS
\  columns.
\
\  There are two modes of use.  In both modes the display buffer
\  contents are sent to the display using the task
\
\                     st7735-show
\
\  This task is called in the main loop and writes one character
\  to the display per main loop tick (except for one initialization
\  tick).
\
\  In non-scrolling mode, strings are written to the display with a
\  specified starting row and column using the functions:
\
\                     st7735-wrt-str
\                     st7735-clr-str
\                     st7735-clr-row
\                     st7735-clr-scrn
\
\  In this mode, the display buffer is treated as non-circular for display
\  purposes, although writing a long string to it can wrap around to the
\  start.
\
\  In scrolling mode, strings are written at the display bottom row and
\  the rows above the bottom row are scrolled upward using the function:
\
\                     st7735-str-scroll
\
\  In this mode, the display buffer is treated as circular to facilitate
\  scrolling, with the display starting at the index value in the variable
\  st7735-Buf-Start.
\
\  The reset mode is non-scrolling with st7735-Buf-Start = 0, but if the
\  scrolling display function is used, the mode switches to scrolling.
\  To return to non-scrolling mode within a program, call the function:
\
\                     st7735-rst-scroll
\
\  which resets st7735-Buf-Start to zero and also clears the screen.
\
\ -------------------------------------------------------------------------
\  This code is original except for translations of code from these C
\  sources:
\
\  Some code is taken from Brown, Ch. 7 which in turn is a modification of
\  the Adafruit library, which has this in its header:
\  
\  This is a library for the Adafruit 1.8" SPI display.
\  This library works with the Adafruit 1.8" TFT Breakout w/SD card
\  ----> http://www.adafruit.com/products/358
\  as well as Adafruit raw 1.8" TFT display
\  ----> http://www.adafruit.com/products/618
\ 
\  Check out the links above for our tutorials and wiring diagrams
\  These displays use SPI to communicate, 4 or 5 pins are required to
\  interface (RST is optional)
\  Adafruit invests time and resources providing this open source code,
\  please support Adafruit and open-source hardware by purchasing
\  products from Adafruit!
\ 
\  Written by Limor Fried/Ladyada for Adafruit Industries.
\  MIT license, all text above must be included in any redistribution
\ 
\ -------------------------------------------------------------------------
\  The 5x7 font in glcdfont.fs is taken from the software accompanying
\  Brown's book "Discovering the STM32."
\
\  Andrew Palm
\  2018.02.14
\ -------------------------------------------------------------------------
\ Colors are 565 RGB (5 bits Red, 6 bits green, 5 bits blue)
\ *** With current configuration, these are bit-reversed when sent ***
$0000 constant ST7735_BLACK       \    0,   0,   0
$000F constant ST7735_NAVY        \    0,   0, 128
$03E0 constant ST7735_DARKGREEN   \    0, 128,   0
$03EF constant ST7735_DARKCYAN    \    0, 128, 128
$7800 constant ST7735_MAROON      \  128,   0,   0
$780F constant ST7735_PURPLE      \  128,   0, 128
$7BE0 constant ST7735_OLIVE       \  128, 128,   0
$C618 constant ST7735_LIGHTGREY   \  192, 192, 192
$7BEF constant ST7735_DARKGREY    \  128, 128, 128
$001F constant ST7735_BLUE        \    0,   0, 255
$07E0 constant ST7735_GREEN       \    0, 255,   0
$07FF constant ST7735_CYAN        \    0, 255, 255
$F800 constant ST7735_RED         \  255,   0,   0
$F81F constant ST7735_MAGENTA     \  255,   0, 255
$FFE0 constant ST7735_YELLOW      \  255, 255,   0
$FFFF constant ST7735_WHITE       \  255, 255, 255
$FD20 constant ST7735_ORANGE      \  255, 165,   0
$AFE5 constant ST7735_GREENYELLOW \  173, 255,  47
$F81F constant ST7735_PINK

$5 constant MADCTLLAND  \ Landscape mode
$6 constant MADCTLPORT  \ Portrait mode
$2 constant MADCTLBMP   \ Portrait BMP file mode

\ Defines specific to landscape text display mode
MADCTLLAND constant MADCTL
160 constant ST7735_WIDTH      \ ST7735 display width in pixels
128 constant ST7735_HEIGHT     \ ST7735 LCD height in pixels
ST7735_NAVY constant BKGD_COLOR
ST7735_YELLOW constant FONT_COLOR

2 constant ST7735_SPEED_INDX

0 constant ST7735_CMD
1 constant ST7735_DATA

$2A constant ST7735_CASET
$2B constant ST7735_RASET
$36 constant ST7735_MADCTL
$2C constant ST7735_RAMWR
$2E constant ST7735_RAMRD
$3A constant ST7735_COLMOD

\ -------------------------------------------------------------------------
\ Low level helper words for ST7735

: st7735-wrt ( tbuf-addr cnt dc -- )
  \ Send cnt bytes from buffer at tbuf-addr to ST7735
  \ Set dc = 1 for data, dc = 0 for command
  if          \ dc consumed
    ST7735_DC ST7735_BSRR bis! 
  else 
    ST7735_DC ST7735_BRR bis!
  then
  spi1-sel-st7735
  0 -rot ST7735_SPEED_INDX spi1-rw
  spi1-desel-st7735
;

: st7735-wrt16 ( tbuf-addr cnt revbits dc -- )
  \ Send cnt hwords from buffer at tbuf-addr to ST7735
  \ Set dc = 1 for data, dc = 0 for command
  \ Set revbits = 1 to send LSB first, 0 for default MSB first
  if             \ dc consumed
    ST7735_DC ST7735_BSRR bis! 
  else 
    ST7735_DC ST7735_BRR bis!
  then
  spi1-sel-st7735
  0 swap 2swap rot ST7735_SPEED_INDX spi1-rw16
  spi1-desel-st7735
;

1 buffer: st7735-Cmd-Buf
: st7735-wrtcmd ( cmd-byte -- )
  \ Write a command to the ST7735 display controller
  st7735-Cmd-Buf c!
  st7735-Cmd-Buf 1 ST7735_CMD st7735-wrt
;

: st7735-madval ( u -- u )  5 lshift 8 or ;

MADCTL st7735-madval variable st7735-Madval-Cur
2 buffer: st7735-Addrwin-Buf

: st7735-set-addrwin ( y1 y0 x1 x0 madctl -- )
  \ Set ST7735 address window with corners (x0, y0) and (x1, y1)
  \ If madctl is not current value, send to display and save new value
  st7735-madval dup st7735-Madval-Cur @ <> if
    dup st7735-Madval-Cur !       \ Save new madctl value
    st7735-Addrwin-Buf c!         \ Put new value in (tx) buffer
    ST7735_MADCTL st7735-wrtcmd   \ Send command sequence to change
    st7735-Addrwin-Buf 1 ST7735_DATA st7735-wrt
  else
    drop    \ No need to change madctl value
  then

  ST7735_CASET st7735-wrtcmd  \ Set column address limits
  st7735-Addrwin-Buf h!       \ Put x0 in buffer
  st7735-Addrwin-Buf 1 0 ST7735_DATA st7735-wrt16
  st7735-Addrwin-Buf h!       \ Put x1 in buffer
  st7735-Addrwin-Buf 1 0 ST7735_DATA st7735-wrt16

  ST7735_RASET st7735-wrtcmd  \ Set row address limits
  st7735-Addrwin-Buf h!       \ Put y0 in buffer
  st7735-Addrwin-Buf 1 0 ST7735_DATA st7735-wrt16
  st7735-Addrwin-Buf h!       \ Put y1 in buffer
  st7735-Addrwin-Buf 1 0 ST7735_DATA st7735-wrt16
  
  ST7735_RAMWR st7735-wrtcmd
;

: st7735-push-color ( colbuf-addr cnt -- )
  \ Send cnt hwords from buffer of color codes at colbuf-addr
  \ with bits reversed
  1 ST7735_DATA st7735-wrt16
;

2 buffer: st7735-Fill-Buf
: st7735-fill-scrn ( color-hword -- )
  \ Fill display with a single color with code color-hword

  \ Set address window to entire display
  ST7735_HEIGHT 1 - 0 ST7735_WIDTH 1 - 0 MADCTL st7735-set-addrwin
  \ Store color code in buffer
  st7735-Fill-Buf h!
  \ Send color hword to all addresses
  ST7735_WIDTH 0 do
    ST7735_HEIGHT 0 do
      st7735-Fill-Buf 1 st7735-push-color
    loop
  loop
;

\ -------------------------------------------------------------------------
\ Defines for text display
12 constant ST7735_NUM_ROWS
26 constant ST7735_NUM_COLS
312 constant ST7735_BUF_LGT
2 constant X_START
4 constant Y_START
6 constant X_STEP
10 constant Y_STEP

218 constant BLOCK_CHAR

\ Font for display
#include glcdfont.fs

6 buffer: st7735-Char-Buf
120 buffer: st7735-Color-Buf
\ Draw a single character on the display at row and col position
\ Note:  Row and col value limits are not checked here, as this is a
\        helper word.  Values must satisfy 0 <= row < ST7735_NUM_ROWS,
\        0 <= col < ST7735_NUM_COLS.
: st7735-draw-chr ( row col char -- )
  \ Load character bit pattern into buffer
  6 0 do
    dup 5x7FONT swap 6 * i + + c@ st7735-Char-Buf i + c!
  loop
  drop    \ Drop char from stack
  
  \ Set colors for 8x6 subgrid
  6 0 do          \ Go through 6 bit pattern bytes
    8 0 do        \ Go through 8 bits of each pattern byte
      st7735-Char-Buf j + c@ 1 i lshift and if
        FONT_COLOR  
      else
        BKGD_COLOR
      then
      st7735-Color-Buf i 6 * j + 1 lshift + h!
    loop
  loop
  \ Two additional blank rows below character to fill out 10x6 grid
  6 0 do
    BKGD_COLOR st7735-Color-Buf 8 6 * i + 1 lshift + h!
    BKGD_COLOR st7735-Color-Buf 9 6 * i + 1 lshift + h!  
  loop

  swap
  \ Stack here: ( col row )
  \ Draw 10x6 grid at x = col*X_STEP + X_START, y = row*Y_STEP + Y_START
  Y_STEP * Y_START + dup 9 + swap rot
  X_STEP * X_START + dup 5 + swap   \ Stack: ( y+9 y x+5 x )
  MADCTL st7735-set-addrwin
  st7735-Color-Buf 60 st7735-push-color
;

\ -------------------------------------------------------------------------
\ Hardware initialization arrays for "Red Tag" displays
\ Format: Command byte, delay byte (ms), number of data bytes, data bytes
\ Stored as byte array using custom word h><, to load bytes
\ Software Reset
create SWRESET $0196 h><, $0000 h><,
\ Leave sleep mode
create SLPOUT $1196 h><, $0000 h><,
\ Frame rate configuration, normal mode, idle
\ frame rate = fosc / (1 x 2 + 40) * (LINE + 2C + 2D)
create FRMCTR1 $B100 h><, $0301 h><, $2C2D h><,
create FRMCTR2 $B200 h><, $0301 h><, $2C2D h><,
\ Frame rate configuration, partial mode 
create FRMCTR3 $B300 h><, $0601 h><, $2C2D h><, $012C h><, $2D00 h><,
\ Display inversion (no inversion)
create INVCTR $B400 h><, $0107 h><,
\ Power control -4.6V, auto mode
create PWCTR1 $C000 h><, $03A2 h><, $0284 h><,
\ Power control VGH25 2.4C, VGSEL -10, VGH = 3 * AVDD
create PWCTR2 $C100 h><, $01C5 h><,
\ Power control, opamp current small, boost frequency
create PWCTR3 $C200 h><, $020A h><, $0000 h><,
\ Power control, BLK/2, opamp current small and medium low
create PWCTR4 $C300 h><, $028A h><, $2A00 h><,
\ Power control
create PWCTR5 $C400 h><, $028A h><, $EE00 h><,
\ Power control
create VMCTR1 $C500 h><, $010E h><,
\ Don't invert display
create INVOFF $2000 h><, $0000 h><,
\ Mem access directions row addr/col addr, bottom to top refresh (10.1.27)
create MEMACD ST7735_MADCTL 8 lshift h><, 
                 $0100 MADCTL st7735-madval or h><, 
\ Color mode 16 bit (10.1.30)
create COLMOD ST7735_COLMOD 8 lshift h><, $0105 h><,
\ Column address set 0..127
create CASET ST7735_CASET 8 lshift h><, $0400 h><, $0000 h><, $7F00 h><,
\ Row address set 0..159
create RASET ST7735_RASET 8 lshift h><, $0400 h><, $0000 h><, $9F00 h><,
\ Gamma correction
create GMCTRP1 $E000 h><, $1002 h><, $1C07 h><, $1237 h><, $3229 h><, 
                $2D29 h><, $252B h><, $3900 h><, $0103 h><, $1000 h><,
\ Gamma polarity correction
create GMCTRP2 $E000 h><, $1003 h><, $1D07 h><, $062E h><, $2C29 h><, 
                $2D2E h><, $2E37 h><, $3F00 h><, $0002 h><, $1000 h><,
\ Display on
create DISPON $2964 h><, $0000 h><, 
\ Normal on
create NORON $130A h><, $0000 h><,

create ST7735_CMD_ARRY SWRESET , SLPOUT , FRMCTR1 , FRMCTR2 , FRMCTR3 , 
    INVCTR , PWCTR1 , PWCTR2 , PWCTR3 , PWCTR4 , PWCTR5 , VMCTR1 , INVOFF ,   
    MEMACD , COLMOD , CASET , RASET , GMCTRP1 , GMCTRP2 , DISPON , NORON ,

: st7735-init-hw
  spi1-desel-st7735
  ST7735_RST ST7735_BSRR bis!
  10 ms-delay
  ST7735_RST ST7735_BRR bis!
  10 ms-delay
  ST7735_RST ST7735_BSRR bis!
  10 ms-delay
  
  \ Loop through initialization arrays
  21 0 do
    ST7735_CMD_ARRY i 2 lshift + @    \ Addr of i-th init array on stack
    dup c@ st7735-wrtcmd              \ Write command in byte 0 of array
    dup 2 + c@ dup 0 > if             \ Number of data bytes > 0?
      over 3 + swap ST7735_DATA st7735-wrt  \ Send data for command
    else
      drop
    then
    1 + c@ dup 0 > if                 \ If delay time > 0, do delay
      ms-delay
    else
      drop
    then
  loop

  BKGD_COLOR st7735-fill-scrn
;

\ -------------------------------------------------------------------------
\ Client tasks

ST7735_BUF_LGT buffer: st7735-Txt-Buf
\ Starting index to display, treating st7735-Text-Buf as circular
0 variable st7735-Buf-Start

0 constant ST7735_SHOW_START
1 constant ST7735_SHOW_DRAW
0 variable st7735-Show-State

0 variable st7735-Show-Row
0 variable st7735-Show-Col

\ Show characters in the text buffer on the display.
\ This task is called in the main loop and writes one character
\ to the display per main loop tick (except for one initialization
\ tick), going through all characters in the text buffer.
\ The variable st7735-Buf-Start is controlled by the write functions.
\ In non-scrolling mode it will remain zero.  In scrolling mode its value
\ will change to scroll the rows upward in the display.
: st7735-show ( -- )
  st7735-Show-State @ case

    ST7735_SHOW_START of
      0 st7735-Show-Row !
      0 st7735-Show-Col !
      ST7735_SHOW_DRAW st7735-Show-State !
    endof

    ST7735_SHOW_DRAW of
      st7735-Show-Row @
      st7735-Show-Col @
      over ST7735_NUM_COLS * over + st7735-Buf-Start @ +
      ST7735_BUF_LGT mod st7735-Txt-Buf + c@
      st7735-draw-chr

      1 st7735-Show-Col +!
      st7735-Show-Col @
      ST7735_NUM_COLS >= if
        0 st7735-Show-Col !
        1 st7735-Show-Row +!
        st7735-Show-Row @
        ST7735_NUM_ROWS >= if
          ST7735_SHOW_START st7735-Show-State !
        then
      then
    endof

  endcase
;

\ -------------------------------------------------------------------------
\ These tasks are for non-scrolling mode only.

\ Write a string to the display buffer starting at row and col position.
\ Text is wrapped if it exceeds buffer size.
: st7735-wrt-str ( row col str-addr str-lgt  -- )
  \ Check limits 0 <= row < ST7735_NUM_ROWS
  3 pick dup 0< swap ST7735_NUM_ROWS 1 - > or if
    drop drop drop drop exit
  then
  \ Check limits 0 <= col < ST7735_NUM_COLS
  2 pick dup 0< swap ST7735_NUM_COLS 1 - > or if
    drop drop drop drop exit
  then

  \ Calculate starting index in text buffer
  3 pick ST7735_NUM_COLS * 3 pick + -rot

  0 do
    \ ( stack: row col start str-addr )
    dup i + c@ 2 pick i + ST7735_BUF_LGT mod
    st7735-Txt-Buf + c!
  loop
  drop drop drop drop
;

\ Clear cnt characters of text starting at row and col posittion.
\ Must have 0<=row<=3 and 0<=col<=21.  Wraps in the text buffer.
: st7735-clr-str ( row col cnt -- )
  \ Check limits 0 <= row < ST7735_NUM_ROWS
  2 pick dup 0< swap ST7735_NUM_ROWS 1 - > or if
    drop drop drop exit
  then
  \ Check limits 0 <= col < ST7735_NUM_COLS
  over dup 0< swap ST7735_NUM_COLS 1 - > or if
    drop drop drop exit
  then

  \ Calculate starting index in text buffer
  2 pick ST7735_NUM_COLS * 2 pick + swap

  0 do
    \ ( stack: row col start )
    dup i + ST7735_BUF_LGT mod
    st7735-Txt-Buf + 32 swap c!    \ Load space
  loop
  drop drop drop
;

: st7735-clr-row ( row -- )
  \ Check limits 0 <= row < ST7735_NUM_ROWS
  dup dup 0< swap ST7735_NUM_ROWS 1 - > or if
    drop exit
  then

  0 ST7735_NUM_COLS st7735-clr-str
;

: st7735-clr-scrn ( -- )
  0 0 ST7735_BUF_LGT st7735-clr-str
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
: st7735-str-scroll ( str-addr str-lgt -- )
  \ Exit if string length non-positive
  dup 0 <= if
    drop exit
  then
  \ Prepare to over-write previous first row with new bottom row
  st7735-Buf-Start @ dup 
  \ ( stack: str-addr str-lgt new-row-start old-start)
  \ Make previously second row now the first row
  ST7735_NUM_COLS + ST7735_BUF_LGT mod st7735-Buf-Start !
  \ ( stack: str-addr str-lgt new-row-start)
  \ Write out new bottom row, with trailing blanks, if needed
  ST7735_NUM_COLS 0 do
    dup i + ST7735_BUF_LGT mod st7735-Txt-Buf +
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
: st7735-rst-scroll ( -- )
  0 st7735-Buf-Start !
  st7735-clr-scrn
;

\ -------------------------------------------------------------------------
\ Initial display on startup

: st7735-splash1 s" **************************" ;
: st7735-splash2 s" *      Andrew Palm       *" ;
: st7735-splash3 s" *       Feb, 2018        *" ;

: st7735-init
  0 st7735-Buf-Start !     \ Non-scrolling mode

  st7735-clr-scrn
  0 0 st7735-splash1 st7735-wrt-str
  1 0 st7735-splash2 st7735-wrt-str
  2 0 st7735-splash3 st7735-wrt-str
  3 0 st7735-splash1 st7735-wrt-str
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
    s" Led 1 incr duty cycle" st7735-str-scroll
  else
    drop drop
  then
;

: led1-dc- ( -- )
  \ Decrease led duty cycle
  led1-On-Cnt @ LED1_DEL_TKS - dup dup LED1_MIN_TKS >= if
    led1-On-Cnt !
    LED1_MAX_TKS swap - led1-Off-Cnt !
    s" Led 1 decr duty cycle" st7735-str-scroll
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
  s" Led 2 off" st7735-str-scroll
;

: led2-on ( -- )  
  LED2_MSK GPIOF_BSRR bis!
  s" Led 2 on" st7735-str-scroll
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
  spi1-init     \ Initialize SPI1
  st7735-init-hw  \ Initialize ST7735 display controller
  eint          \ Global interrupt enable

  \ Tasks
  pb1-init
  enc1-init
  led1-init
  led2-init
  st7735-init

  \ ---------------- Main loop --------------------------------------------
  begin wait-for-tick
    \ Inputs
    pb1-task
    enc1-task
    \ Outputs
    led1-task
    st7735-show
  key? until            \ Escape from main loop on key press
;

\ -------------------------------------------------------------------------
compiletoram
