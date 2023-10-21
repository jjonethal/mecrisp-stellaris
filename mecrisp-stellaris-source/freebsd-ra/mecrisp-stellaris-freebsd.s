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
@ First and foremost, an ELF header
@ -----------------------------------------------------------------------------

.include "elfheader.s"

@ -----------------------------------------------------------------------------
@ Then, Mecrisp as usual
@ -----------------------------------------------------------------------------

.section mecrisp, "awx" @ Everything is writeable and executable

@ -----------------------------------------------------------------------------
@ A Thumb mode entry sequence instead of a vector table
@ -----------------------------------------------------------------------------

  .global _start
  @ On some versions of FreeBSD up to and including FreeBSD 12.2 and 13.0, only
  @ ARM mode entry ports are supported, so we have to use this shim to work
  @ around the problem.  The shim will be kept until FreeBSD 13.1 and 12.3 are
  @ released.  For details see https://bugs.freebsd.org/256899
_start:
  blx Reset_with_arguments @ switch to thumb mode

.thumb

@ -----------------------------------------------------------------------------
@ Swiches for capabilities of this chip
@ -----------------------------------------------------------------------------

.equ charkommaavailable, 1
.equ does_above_64kb, 1
.equ within_os, 1
.equ registerallocator, 1
.equ erasedflashcontainszero, 1

@ -----------------------------------------------------------------------------
@ Start with some essential macro definitions
@ -----------------------------------------------------------------------------

.include "../common/datastackandmacros.s"

@ -----------------------------------------------------------------------------
@ Include the Forth core of Mecrisp-Stellaris
@ -----------------------------------------------------------------------------

.include "../common/forth-core.s"

@ -----------------------------------------------------------------------------
Reset_with_arguments:
@ -----------------------------------------------------------------------------
   ldr r0, =arguments  @ Save the initial stack pointer, as it contains
   mov r1, sp
   str r1, [r0]        @ command line arguments. Do this only once on first entry.
   @ b eraseflash      @ Fill flash memory with $FF

@ -----------------------------------------------------------------------------
Reset: @ Einsprung zu Beginn
@ -----------------------------------------------------------------------------

   @ Catch the pointers for "Flash" dictionary
   .include "../common/catchflashpointers.s"

   @ set up termios to not do input processing and to not echo
   bl uart_init

   @ set up signal handlers for SIGINT (^C) and SIGTERM
   ldr r4, =bye
   movs tos, #2			@ SIGINT -> bye
   pushdatos
   movs tos, r4
   bl signal

   movs tos, #15		@ SIGTERM -> bye
   pushdatos
   movs tos, r4
   bl signal

   ldr r0, =arguments
   ldr r0, [r0]
   ldr r0, [r0]
   cmp r0, #1    @ Skip welcome message if user gives command line arguments
   bne 1f
     welcome " for FreeBSD by Matthias Koch"
1:
   @ Ready to fly !
   .include "../common/boot.s"
   
@ -----------------------------------------------------------------------------
@ Special memory map for "Flash" and RAM sections within target RAM.
@ -----------------------------------------------------------------------------

.equ Kernende,              . @ Ende des Forth-Kerns

.bss
.equ Kernschutzadresse,     . @ Darunter wird niemals etwas geschrieben !
                              @ Mecrisp core never writes flash below this address.


.equ FlashDictionaryAnfang, . @ Ein bisschen Platz für den Kern reserviert...
                              @ Some space reserved for core.

  .space 1024 * 1024          @ 1024 * 1024 = 1 MB for "Flash" dictionary

.equ FlashDictionaryEnde,   .  @ 1 MB Platz für das Flash-Dictionary
                               @ 1 MB Flash available. Porting: Change this !
.equ Backlinkgrenze,        .  @ Ab dem Ram-Start.
   
@ Konstanten für die Größe des Ram-Speichers

.equ RamAnfang, . @ Start of RAM

  .space 1024 * 1024           @ 1024 * 1024 = 1 MB for RAM dictionary
  
.equ RamEnde,   . @ End   of RAM.
