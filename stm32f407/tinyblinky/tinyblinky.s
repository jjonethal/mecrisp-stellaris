
@ Tiny blinky for STM32F4 Discovery

@ Flash with: st-flash write tinyblinky.bin 0x08000000
@ Physical start address of flash memory is 0x08000000, but its contents are mirrored to 0x00000000 for execution.

.syntax unified
.cpu cortex-m4
.thumb


  .equ RCC_BASE    ,  0x40023800
  .equ RCC_AHB1ENR ,  RCC_BASE + 0x30

  .equ GPIOD_BASE  ,  0x40020C00

  .equ MODER       ,  0x00  @ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
  .equ OTYPER      ,  0x04  @ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
  .equ OSPEEDR     ,  0x08  @ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
  .equ PUPDR       ,  0x0C  @ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
  .equ IDR         ,  0x10  @ RO      Input Data Register
  .equ ODR         ,  0x14  @ Reset 0 Output Data Register
  .equ BSRR        ,  0x18  @ WO      Bit set/reset register   31:16 Reset 15:0 Set
  .equ LCKR        ,  0x1C  @         ... is Lock Register, unused
  .equ AFRL        ,  0x20  @ Reset 0 Alternate function  low register
  .equ AFRH        ,  0x24  @ Reset 0 Alternate function high register


.text
.word 0x20000000 + 4096         @ Stack pointer somewhere in RAM
.word blinky + 1                @ Reset Handler, +1 for Thumb mode.

blinky:

  @ Enable all GPIO peripheral clocks

  ldr r1, = RCC_AHB1ENR
  ldr r0, = 0x1FF
  str r0, [r1]

  @ Switch pins PD12, PD13, PD14, PD15 to output

  ldr r1, = GPIOD_BASE

  ldr r0, = 1 << (12*2) | 1 << (13*2) | 1 << (14*2) | 1 << (15*2)
  str r0, [r1, MODER]

1:adds r3, #1            @ Count up
  lsrs r4, r3, #8        @ Divide a bit to get blink frequency into visible range. Change this to adjust speed.
  str  r4, [r1, ODR]     @ Set output accordingly
  b 1b

  .ltorg  # Write constant pool
