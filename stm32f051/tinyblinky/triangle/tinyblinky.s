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
@ -----------------------------------------------------------------------------
reset:
@ -----------------------------------------------------------------------------

   movs r2, #0x48               @ Start to generate address of PIOC_MODER (0x48000800)
   lsls r2, r2, #16             @ 0x48 --> 0x480000
   str r2, [sp, 0x40021014-0x40020C5C] @ Set 0x80000 in RCC_AHBENR (0x40021014). Bit 0x400000 enables PIOF, but this is fine within challenge rules.
   adds r2, #8                  @      --> 0x480008
   lsls r2, #8                  @    --> 0x48000800

   lsls r1, r2, #5              @ 0x48000800 << 5 = 0x10000 for PC8, blue LED
@  lsls r1, r2, #7              @ 0x48000800 << 7 = 0x40000 for PC9, green LED
   str  r1, [r2]                @ Switch pin to output

@ -----------------------------------------------------------------------------
breathe_led: @ Generate smooth breathing LED effect
@ -----------------------------------------------------------------------------

    @ Register usage:

    @ r0 : Unused
    @ r1 : Scratch
    @ r2 : Initialised with IO address for GPIO
    @ r3 : Scratch
    @ r4 : Unused
    @ r5 : Delay counter
    @ r6 : Slow triangle counter, clipped
    @ r7 : Phase accumulator for sigma-delta modulator

    adds r5, 1                   @ Delay counter

    lsls r6, r5, 12              @ Select blinking speed here.
    asrs r6, r6, 15              @ Triangle generator between 0 and 0x10000.
    bpl  1f                      @ Idea:
    negs r6, r6                  @   abs((upcounter << 11) >>> 15)
1:
    movs r1, 231-117             @ Scale range:
    muls r6, r1                  @ (high-low) * x / 65536 + low
    lsrs r6, 16                  @
    adds r6, 117                 @ Baseline minimum brightness

    movs r3, 7                   @ Simplified bitexp function.
    ands r3, r6                  @   Valid for inputs up to 231
    adds r3, 8                   @   Gives too small values above 231
    lsrs r1, r6, 3               @   Input  in r6 is kept
    lsls r3, r1                  @   Output in r3

    subs r7, r3                  @ Sigma-Delta phase accumulator
    sbcs r3, r3                  @ Sigma-Delta output through carry, which is inverted for subs

   str  r3, [r2, 0x14]          @ Set output accordingly
   b.n breathe_led
