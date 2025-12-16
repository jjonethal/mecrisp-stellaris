
@ -----------------------------------------------------------------------------
@  A blinky example for the stage 2 boot block
@ -----------------------------------------------------------------------------

.syntax unified
.cpu cortex-m0
.thumb

@ -----------------------------------------------------------------------------
@  Register definitions
@ -----------------------------------------------------------------------------

.equ CLOCKS_BASE,     0x40008000
.equ IO_BANK0_BASE,   0x40014000
.equ PADS_BANK0_BASE, 0x4001c000
.equ SIO_BASE,        0xd0000000

.equ WAKE_EN0, CLOCKS_BASE + 0x000000a0

.equ GPIO_25_STATUS,  IO_BANK0_BASE + 8 * 24
.equ GPIO_25_CTRL,    IO_BANK0_BASE + 8 * 25 + 4

.equ GPIO_25_PAD,     PADS_BANK0_BASE + 0x68

.equ CPUID          , 0x000 @ Processor core identifier
.equ GPIO_IN        , 0x004 @ Input value for GPIO pins
.equ GPIO_HI_IN     , 0x008 @ Input value for QSPI pins
.equ GPIO_OUT       , 0x010 @ GPIO output value
.equ GPIO_OUT_SET   , 0x014 @ GPIO output value set
.equ GPIO_OUT_CLR   , 0x018 @ GPIO output value clear
.equ GPIO_OUT_XOR   , 0x01c @ GPIO output value XOR
.equ GPIO_OE        , 0x020 @ GPIO output enable
.equ GPIO_OE_SET    , 0x024 @ GPIO output enable set
.equ GPIO_OE_CLR    , 0x028 @ GPIO output enable clear
.equ GPIO_OE_XOR    , 0x02c @ GPIO output enable XOR
.equ GPIO_HI_OUT    , 0x030 @ QSPI output value
.equ GPIO_HI_OUT_SET, 0x034 @ QSPI output value set
.equ GPIO_HI_OUT_CLR, 0x038 @ QSPI output value clear
.equ GPIO_HI_OUT_XOR, 0x03c @ QSPI output value XOR
.equ GPIO_HI_OE     , 0x040 @ QSPI output enable
.equ GPIO_HI_OE_SET , 0x044 @ QSPI output enable set
.equ GPIO_HI_OE_CLR , 0x048 @ QSPI output enable clear
.equ GPIO_HI_OE_XOR , 0x04c @ QSPI output enable XOR

.equ RESETS_BASE, 0x4000c000
.equ RESET      , 0
.equ WDSEL      , 4
.equ RESET_DONE , 8

.equ ALIAS_RW , 0<<12
.equ ALIAS_XOR, 1<<12
.equ ALIAS_SET, 2<<12
.equ ALIAS_CLR, 3<<12

.equ RESETS_USBCTRL   , 24
.equ RESETS_UART1     , 23
.equ RESETS_UART0     , 22
.equ RESETS_TIMER     , 21
.equ RESETS_TBMAN     , 20
.equ RESETS_SYSINFO   , 19
.equ RESETS_SYSCFG    , 18
.equ RESETS_SPI1      , 17
.equ RESETS_SPI0      , 16
.equ RESETS_RTC       , 15
.equ RESETS_PWM       , 14
.equ RESETS_PLL_USB   , 13
.equ RESETS_PLL_SYS   , 12
.equ RESETS_PIO1      , 11
.equ RESETS_PIO0      , 10
.equ RESETS_PADS_QSPI ,  9
.equ RESETS_PADS_BANK0,  8
.equ RESETS_JTAG      ,  7
.equ RESETS_IO_QSPI   ,  6
.equ RESETS_IO_BANK0  ,  5
.equ RESETS_I2C1      ,  4
.equ RESETS_I2C0      ,  3
.equ RESETS_DMA       ,  2
.equ RESETS_BUSCTRL   ,  1
.equ RESETS_ADC       ,  0
.equ RESETS_ALL       , 0x01ffffff
.equ RESETS_EARLY     , RESETS_ALL & ~(1<<RESETS_IO_QSPI) & ~(1<<RESETS_PADS_QSPI) & ~(1<<RESETS_PLL_USB) & ~(1<<RESETS_PLL_SYS)
.equ RESETS_CLK_GLMUX , RESETS_ALL & ~(1<<RESETS_ADC) & ~(1<<RESETS_RTC) & ~(1<<RESETS_SPI0) & ~(1<<RESETS_SPI1) & ~(1<<RESETS_UART0) & ~(1<<RESETS_UART1) & ~(1<<RESETS_USBCTRL)

.equ DELAY, 1000000

@ -----------------------------------------------------------------------------
Reset: @ Let it shine !
@ -----------------------------------------------------------------------------

  // Reset as much as possible. We have to keep the flash (QSPI, XIP banks)
  // and the PLLs not protected by a glitchless muxes running for now.
  ldr  r1, =RESETS_BASE|ALIAS_SET
  ldr  r0, =RESETS_EARLY
  str  r0, [r1, #RESET]

  // Start everything that's clocked by clk_sys and clk_ref
  ldr  r1, =RESETS_BASE|ALIAS_CLR
  ldr  r0, =RESETS_CLK_GLMUX
  str  r0, [r1, #RESET]

  // Wait for the peripherals to return from reset
  ldr  r1, =RESETS_BASE
1:ldr  r2, [r1, #RESET_DONE]
  mvns r2, r2
  ands r2, r0
  bne  1b

  // Set GPIO[25] function to single-cyle I/O
  ldr  r1, =GPIO_25_CTRL
  movs r0, 5
  str  r0, [r1]

  // Set GPIO[25] output enable
  ldr  r1, =SIO_BASE
  ldr  r0, =1<<25
  str  r0, [r1, #GPIO_OE_SET]

Blinky:
  ldr  r2, =DELAY
1:subs r2, #1
  bne  1b
  str r0, [r1, #GPIO_OUT_XOR]
  b.n Blinky
