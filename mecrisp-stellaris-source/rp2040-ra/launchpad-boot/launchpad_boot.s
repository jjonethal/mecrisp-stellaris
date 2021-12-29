@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
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
.cpu cortex-m0
.thumb

.equ load_to,   0x20000000
.equ load_from, 0x10001000
.equ load_size, 0x00020000

.text

   @ Set stack pointer to the end of SRAM5 temporarily
   ldr r3, =0x20042000
   mov sp, r3

   @ Connect flash
   ldr r6, ='I+('F<<8)
   bl  rom_code
   blx r6

   @ Flush cache
   ldr r6, ='F+('C<<8)
   bl  rom_code
   blx r6

   @ Enter XIP
   ldr  r6, ='C+('X<<8)
   bl   rom_code
   blx  r6

   @ Copy Forth core into RAM
   ldr r0, =load_from
   ldr r1, =load_to
   ldr r2, =load_size

1: subs r2, #4
   ldr r3, [r0, r2]
   str r3, [r1, r2]
   bne 1b

   @ Set vector table in RAM
   ldr r3, =0xe000ed08 @ VTOR
   str r1, [r3]        @ Set vector table offset into the table copied to RAM

   @ Set stack pointer
   ldr r3, [r0]        @ Set stack pointer according to the image just copied
   mov sp, r3

   @ Launch Forth !
   ldr r3, [r0, #4]    @ Fetch Reset pointer of the image
   bx r3               @ Jump into it.


@ -----------------------------------------------------------------------------
rom_code:
@ -----------------------------------------------------------------------------

   push {lr}

   movs r2, #0x00000000	@ All fields are within reach from 0x0000
   ldrh r0, [r2, #0x14]	@ Pass the ROM table as first argument
   movs r1, r6          @ and the code as second argument
   ldrh r2, [r2, #0x18] @ Call the table lookup function from the rom
   blx  r2
   movs r6, r0

   pop  {pc}

.ltorg
