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

.syntax unified

.section mecrisp, "awx" @ Everything is writeable and executable
.align 4

@ -----------------------------------------------------------------------------
@ A Thumb mode entry sequence instead of a vector table
@ -----------------------------------------------------------------------------

  .global _start
_start:
  ldr r0, =reset+1
  bx r0 @ Switch to thumb mode

.thumb

@ -----------------------------------------------------------------------------
@ Start with some essential tool definitions
@ -----------------------------------------------------------------------------

.include "terminal.s"

@ -----------------------------------------------------------------------------
@ Print both fractals
@ -----------------------------------------------------------------------------

reset:
  movs r0, -1
  bl mandelbrot
  movs r0, 1
  bl mandelbrot
  bl bye

@ -----------------------------------------------------------------------------
mandelbrot:  @ Print mandelbrot set
@ -----------------------------------------------------------------------------
  push {lr}
    movs r5, 1

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

  pop {pc}

.ltorg

                 @  1234567890123456
@ colormap: .ascii " .,:;*vnm%8O0@+ "
  colormap: .ascii " +@0O8%mnv*;:,. " @ Iteration backwards
