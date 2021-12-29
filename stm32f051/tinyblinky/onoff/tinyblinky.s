@ Tinyblinky for STM32F0 Discovery, by Matthias Koch
@ Blue Led is connected to PC8.
@ Challenges: Blinky, binary as small as possible, no strange electrical states on other pins.

.syntax unified
.cpu cortex-m0
.thumb
.text

blinky:                         @ Execute the vector table :-)

.word 0x40020C5C                @ Stack pointer: Plus a suitable offset, this gives RCC_AHBENR (0x40021014).
                                @ But it is also this sequence of opcodes:
                                @   lsrs    r4, r3, #17  @ Divide a bit to get blink frequency into visible range.
                                @   ands    r2, r0       @ Doesn't harm here.

.word reset + 1                 @ Reset Handler.
                                @ Opcode sequence:
                                @   movs    r1, r1
                                @   movs    r0, r0
reset:

   movs r2, #0x48               @ Start to generate address of PIOC_MODER (0x48000800)
   lsls r2, r2, #16             @ 0x48 --> 0x480000
   str r2, [sp, 0x40021014-0x40020C5C] @Set 0x80000 in RCC_AHBENR (0x40021014). Bit 0x400000 enables PIOF, but this is fine within challenge rules.
   adds r2, #8                  @      --> 0x480008
   lsls r2, #8                  @    --> 0x48000800

   lsls r1, r2, #5              @ 0x48000800 << 5 = 0x10000 for PC8, blue LED
@  lsls r1, r2, #7              @ 0x48000800 << 7 = 0x40000 for PC9, green LED
   str  r1, [r2]                @ Switch pin to output

   adds r3, #0xFF               @ Count up. Change this to adjust speed.
   str  r4, [r2, 0x14]          @ Set output accordingly
   b blinky                     @ Jump to blinky:

@ tinyblinky.bin = 28 bytes
