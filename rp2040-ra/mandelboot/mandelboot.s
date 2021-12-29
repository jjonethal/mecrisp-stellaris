@
@    Mandelboot - Booting RP2040 into printing Mandelbrot fractal
@    Copyright (C) 2021  Matthias Koch
@
@    This program is free software: you can redistribute it and/or modify
@    it under the terms of the GNU General Public License as published by
@    the Free Software Foundation, either version 3 of the License, or
@    (at your option) any later version.
@
@    This program is distributed in the hope that it will be useful,
@    but WITHOUT ANY WARRANTY; without even the implied warranty of
@    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
@    GNU General Public License for more details.
@
@    You should have received a copy of the GNU General Public License
@    along with this program.  If not, see <http://www.gnu.org/licenses/>.
@

@ Many thanks to Robert Clausecker for the challenge, saved bytes and a smooth blink
@ Many thanks to Jan Bramkamp for hints on initialisation of the RP2040

.syntax unified
.cpu cortex-m0
.thumb

@ -----------------------------------------------------------------------------
@  Resets
@ -----------------------------------------------------------------------------

.equ RESETS_BASE, 0x4000c000
.equ RESET      , 0
.equ WDSEL      , 4
.equ RESET_DONE , 8

@ -----------------------------------------------------------------------------
@ Crystal Oscillator
@ -----------------------------------------------------------------------------

.equ XOSC_BASE, 0x40024000

.equ XOSC_CTRL   , 0x00 @ Crystal Oscillator Control
.equ XOSC_STATUS , 0x04 @ Crystal Oscillator Status
.equ XOSC_DORMANT, 0x08 @ Crystal Oscillator pause control
.equ XOSC_STARTUP, 0x0c @ Controls the startup delay
.equ XOSC_COUNT  , 0x1c @ A down counter running at the XOSC frequency which counts to zero and stops.

.equ XOSC_RANGE_12MHZ , 0x000aa0
.equ XOSC_ENABLE_12MHZ, 0xfabaa0
.equ XOSC_DELAY       , 47 @ ceil((f_crystal * t_stable) / 256)

@ -----------------------------------------------------------------------------
@  Clock tree
@ -----------------------------------------------------------------------------

.equ CLOCKS_BASE, 0x40008000

.equ CLK_REF_CTRL        , 0x30 @ Clock control, can be changed on-the-fly (except for auxsrc)
.equ CLK_REF_DIV         , 0x34 @ Clock divisor, can be changed on-the-fly
.equ CLK_REF_SELECTED    , 0x38 @ Indicates which src is currently selected (one-hot)

.equ CLK_SYS_CTRL        , 0x3c @ Clock control, can be changed on-the-fly (except for auxsrc)
.equ CLK_SYS_DIV         , 0x40 @ Clock divisor, can be changed on-the-fly
.equ CLK_SYS_SELECTED    , 0x44 @ Indicates which src is currently selected (one-hot)

.equ CLK_PERI_CTRL       , 0x48 @ Clock control, can be changed on-the-fly (except for auxsrc)
.equ CLK_PERI_SELECTED   , 0x50 @ Indicates which src is currently selected (one-hot)

@ -----------------------------------------------------------------------------
@  Pins and their configuration
@ -----------------------------------------------------------------------------

.equ IO_BANK0_BASE,   0x40014000
.equ GPIO_25_STATUS,  IO_BANK0_BASE + 8 * 24
.equ GPIO_25_CTRL,    IO_BANK0_BASE + 8 * 25 + 4

.equ PADS_BANK0_BASE, 0x4001c000
.equ GPIO_25_PAD,     PADS_BANK0_BASE + 0x68

@ -----------------------------------------------------------------------------
@  IO on pins
@ -----------------------------------------------------------------------------

.equ SIO_BASE,        0xd0000000
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

@ -----------------------------------------------------------------------------
@  UART
@ -----------------------------------------------------------------------------

.equ UART0_BASE, 0x40034000

.equ UARTDR   , 0x00 @ Data Register, UARTDR
.equ UARTRSR  , 0x04 @ Receive Status Register/Error Clear Register, UARTRSR/UARTECR
.equ UARTFR   , 0x18 @ Flag Register, UARTFR
.equ UARTILPR , 0x20 @ IrDA Low-Power Counter Register, UARTILPR
.equ UARTIBRD , 0x24 @ Integer Baud Rate Register, UARTIBRD
.equ UARTFBRD , 0x28 @ Fractional Baud Rate Register, UARTFBRD
.equ UARTLCR_H, 0x2c @ Line Control Register, UARTLCR_H
.equ UARTCR   , 0x30 @ Control Register, UARTCR
.equ UARTIFLS , 0x34 @ Interrupt FIFO Level Select Register, UARTIFLS
.equ UARTIMSC , 0x38 @ Interrupt Mask Set/Clear Register, UARTIMSC
.equ UARTRIS  , 0x3c @ Raw Interrupt Status Register, UARTRIS
.equ UARTMIS  , 0x40 @ Masked Interrupt Status Register, UARTMIS
.equ UARTICR  , 0x44 @ Interrupt Clear Register, UARTICR
.equ UARTDMACR, 0x48 @ DMA Control Register, UARTDMACR

@ -----------------------------------------------------------------------------
Reset: @ Let it shine !
@ -----------------------------------------------------------------------------

    @ Load initialisation constants

    adr  r0, literal_pool
    ldm  r0!, {r1-r5}

    @ Activate all peripherals

    movs r0, 0
    str  r0, [r1, #RESET]       @ r1 = 0x4000c000 (RESET_BASE)

    @ Compute further constants

    movs r1, 2                  @ r1 = 0x00000002 XOSC as clock source for everything
                                @ r2 = 0x40034000 UART0_BASE
                                @ r3 = 0x00fabaa0 XOSC_ENABLE_12MHZ
                                @ r4 = 0x40008000 CLOCKS_BASE
                                @ r5 = 0x00000301
    lsls r7, r1, 15             @ r7 = 0x00010000
    subs r6, r2, r7             @ r6 = 0x40024000 XOSC_BASE
    subs r7, r6, r7             @ r7 = 0x40014000 IO_BANK0_BASE

    @ Activate XOSC

    str  r5, [r6, #XOSC_STARTUP] @ A value of 47 for XOSC_DELAY would suffice, but writing 0x301 to is saves one opcode !

    str  r3, [r6, #XOSC_CTRL] @ r3 = XOSC_ENABLE_12MHZ

1:  ldr  r0, [r6, #XOSC_STATUS] @ Wait for stable flag (in MSB)
    asrs r0, r0, 31
    bpl  1b

     @ Select XOSC as source for clk_ref, which is the clock source of everything in reset configuration

    str  r1, [r4, #CLK_REF_CTRL] @ r1 = 2, r4 = CLOCKS_BASE

    @ Enable clk_peri, which drives the UART

    lsls r3, r1, 10 @ Reuse the constant "2" already in r1. r3 = 0x800
    str  r3, [r4, #CLK_PERI_CTRL]

    @ Configure the UART and set baud rate

    movs r3, 6                   @ 12e6/(16*115200) = 6.5104
    str  r3, [r2, #UARTIBRD]     @ r2 = UART0_BASE
    movs r3, 33                  @                   (0.5104*64)+0.5 = 33.166
    str  r3, [r2, #UARTFBRD]
    movs r3, (3 << 5) | (1 << 4) @ 8N1, enable FIFOs
    str  r3, [r2, #UARTLCR_H]

    @ Enable UART

    str  r5, [r2, #UARTCR]       @ UART enable

    @ Set UART special function for the RX and TX pins

    str  r1, [r7, #4+0]          @ r7 = IO_BANK0_BASE
    str  r1, [r7, #4+8]

    @ Set pin for LED as output

    movs r1, 5                   @ SIO control for this pin
    adds r7, 4+8*25              @ GPIO_25_CTRL
    str  r1, [r7]

    @ r0 now contains -1.

@ -----------------------------------------------------------------------------
mandelbrot:  @ Print mandelbrot set with shining LED.
@ -----------------------------------------------------------------------------

    ldrb r3, [r2, #UARTDR]       @ Fetch character to clear UART flag

    lsls r7, r2, 14 @ SIO_BASE = UART0_BASE << 14. Initialisation and emit set r2 to UART0_BASE.
    movs r5, 1
    lsls r1, r5, 25
    str r1, [r7, #GPIO_OE]       @ Set Pin 25 as output
    str r1, [r7, #GPIO_OUT]      @ Set LED

@ -----------------------------------------------------------------------------
@  Constants for the section of the Mandelbrot set,
@  partially hardwired in code to save space.
@ -----------------------------------------------------------------------------

    .equ mandel_shift , 12
    .equ xmax         ,  3
    .equ ymax         ,  2
    .equ dx           , (2*xmax << mandel_shift) / 192
  @ .equ dy           , (2*ymax << mandel_shift) / 64
  @ .equ norm_max     ,  4

    @ r0: Mandelbrot / Tricorn switch, must be kept
    @ r1: Zr for iteration loop
    @ r2: Zi for iteratopn loop
    @ r3: Scratch
    @ r4: Iteration count
    @ r5: Constant 1
    @ r6: Loop X
    @ r7: Loop Y

    negs r0, r0 @ Switch between 1 and -1 to select Mandelbrot or Tricorn fractal

    mvns r7, r5 @ ymax = -2
    lsls r7, r7, mandel_shift
y_loop:

      movs r6, xmax
      negs r6, r6
      lsls r6, mandel_shift
x_loop:

      movs r1, r6  @ Zr = Cr
      movs r2, r7  @ Zi = Ci
      movs r4, 64

iteration_loop:

        movs r3, r2
        muls r3, r2 @ (Zi * Zi)
        muls r2, r1 @ (Zr * Zi)
        muls r1, r1 @ (Zr * Zr)
        subs r1, r3 @ (Zr^2 - Zi^2)

        adds r3, r3 @ Add the already subtracted value back two times to get (Zr^2 - Zi^2 + 2*Zi^2) = (Zr^2 + Zi^2)
        adds r3, r1 @ This detour saves the one register necessary to switch between Mandelbrot and Tricorn fractal
        lsrs r3, r3, 14 + mandel_shift @ Finished if (Zr^2 + Zi^2) get larger than norm_max = 4 << 12.
        bne.n iteration_finished

        asrs r1, r1, mandel_shift   @ (Zr^2 - Zi^2) >>> mandel_shift
        asrs r2, r2, mandel_shift-1 @ 2 * (Zr * Zi) >>> mandel_shift

        muls r2, r0 @ Complex conjugate of Zi to select between Mandelbrot and Tricorn fractal

        adds r1, r6 @ Zr' = Zr^2 - Zi^2 + Cr
        adds r2, r7 @ Zi' = 2 * Zr * Zi + Ci

        subs r4, 1
        bne.n iteration_loop

iteration_finished:

        movs r1, 15
        ands r4, r1
        adr r3, colormap
        ldrb r4, [r3, r4]
        bl emit

      adds r6, dx
      movs r1, xmax
      lsls r1, mandel_shift
      cmp r6, r1
      ble.n x_loop

      movs r4, 10
      bl emit

    lsls r1, r5, 8 @ dy = 0x100 = 1 << 8
    adds r7, r1
    lsls r1, r5, 13 @ ymax = 2 << 12 = 1 << 13
    cmp r7, r1
    ble.n y_loop

@ -----------------------------------------------------------------------------
breathe_initialisation:
@ -----------------------------------------------------------------------------

 @ movs r5, 1                    @ Set up initial x, y for Minsky circle algorithm
   lsls r6, r5, 19

@ -----------------------------------------------------------------------------
breathe_led: @ Generate breathing LED effect while waiting for keypress
@ -----------------------------------------------------------------------------

    @ r0 : Mandelbrot / Tricorn switch, must be kept
    @ r1 : Scratch
    @ r2 : Initialised with UART0_BASE, must be kept
    @ r3 : Scratch
    @ r4 : Blink type, starts with 10
    @ r5 : Minsky circle alg x = sin(t)
    @ r6 : Minsky circle alg y = cos(t)
    @ r7 : Phase accumulator for sigma-delta modulator

    eors r4, r0  @ Blink with a different speed depending on fractal type
    bmi 1f       @ Tricorns -1 skips every second Minsky step

                                 @ Minsky circle algorithm x, y = sin(t), cos(t)
    asrs r1, r5, 17              @ -dx = y >> 17
    subs r6, r1                  @  x += dx
    asrs r1, r6, 17              @  dy = x >> 17
    adds r5, r1                  @  y += dy

1:  asrs r1, r6, 13              @ -49 <= r4 <= 64   --> scaled cos(t)
    adds r1, 183                 @ 134 <= r4 <= 247  --> scaled cos(t) with offset

    movs r3, 7                   @ Simplified bitexp function.
    ands r3, r1                  @
    adds r3, 8                   @   Valid for inputs from 0x10 = 16 to 0xF7 = 247.
    lsrs r1, r1, 3               @   Gives 0 if below 16, and too small values above 247.
    subs r1, 2                   @ Input  in r1
    lsls r3, r1                  @ Output in r3

    bpl.n 1f                     @ Terminate only on apex of blinking to give smooth transitions.
    ldr r1, [r2, #UARTFR]        @ Fetch status, r2 still contains UART0_BASE from the last call to emit
    lsls r1, r1, 31-4            @ RX FIFO empty, bit 4. Mask just a single bit by shifting
    bpl.n mandelbrot
1:
    subs r7, r3                  @ Sigma-Delta phase accumulator
    sbcs r3, r3                  @ Sigma-Delta output through carry, which is inverted for subs

    lsls r1, r2, 14              @ SIO_BASE = UART0_BASE << 14. Initialisation and emit set r2 to UART0_BASE.
    str r3, [r1, #GPIO_OUT]      @ Set LED
    b.n breathe_led

@ -----------------------------------------------------------------------------
emit: @ Emit one character in r4
@ -----------------------------------------------------------------------------
    ldr r2, uart0_base
1:  ldr r3, [r2, #UARTFR]        @ Fetch status
    lsls r3, r3, 31-5            @ TX FIFO full, bit 5. Mask just a single bit by shifting
    bmi 1b
    strb r4, [r2, #UARTDR]       @ Output the character
    bx lr

    .align
literal_pool:
    @ Constants for clock initialisation
    .word RESETS_BASE            @ R1
uart0_base:
    .word UART0_BASE             @ R2
    .word XOSC_ENABLE_12MHZ      @ R3
    .word CLOCKS_BASE            @ R4
    .word (1 << 9) | (1 << 8) | (1 << 0) @ R5
    .ltorg

                 @  1234567890123456
@ colormap: .ascii " .,:;*vnm%8O0@+ "
  colormap: .ascii " +@0O8%mnv*;:,. " @ Iteration backwards
