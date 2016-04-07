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

@ -----------------------------------------------------------------------------
@ A Thumb mode entry sequence instead of a vector table
@ -----------------------------------------------------------------------------
.text
  .global _start
_start:
  ldr r0, =Reset+1
  bx r0 @ Switch to thumb mode

.data
.thumb

@ -----------------------------------------------------------------------------
@ Swiches for capabilities of this chip
@ -----------------------------------------------------------------------------

.equ charkommaavailable, 1
.equ does_above_64kb, 1
.equ within_os, 1

@ -----------------------------------------------------------------------------
@ Start with some essential macro definitions
@ -----------------------------------------------------------------------------

.include "../common/datastackandmacros.s"

@ -----------------------------------------------------------------------------
@ Include the Forth core of Mecrisp-Stellaris
@ -----------------------------------------------------------------------------

.include "../common/forth-core.s"

@ -----------------------------------------------------------------------------
Reset: @ Einsprung zu Beginn
@ -----------------------------------------------------------------------------
   @ No initialisation necessary, as we are not running bare metal.

   @ Catch the pointers for "Flash" dictionary
   .include "../common/catchflashpointers.s"

   welcome " for Linux by Matthias Koch"

   @ Ready to fly !
   .include "../common/boot.s"
   
@ -----------------------------------------------------------------------------
@ Special memory map for "Flash" and RAM sections within target RAM.
@ -----------------------------------------------------------------------------

.p2align 2         @ Auf 4 gerade Adressen ausrichten  Align to 4-even locations

.equ Kernschutzadresse,     . @ Darunter wird niemals etwas geschrieben ! Mecrisp core never writes flash below this address.
.equ FlashDictionaryAnfang, . @ Ein bisschen Platz für den Kern reserviert... Some space reserved for core.

  .rept 32768      @ 32768*4 = 128 kb for "Flash" dictionary
  .word 0xFFFFFFFF
  .endr

.equ FlashDictionaryEnde,   .  @ 128 kb Platz für das Flash-Dictionary     128 kb Flash available. Porting: Change this !
.equ Backlinkgrenze,        .  @ Ab dem Ram-Start.
   
@ Konstanten für die Größe des Ram-Speichers

.equ RamAnfang, . @ Start of RAM

  .rept 32768      @ 32768*4 = 128 kb for RAM dictionary
  .word 0xFFFFFFFF
  .endr
  
.equ RamEnde,   . @ End   of RAM.

