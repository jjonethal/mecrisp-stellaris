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
.cpu cortex-m4
.thumb

@ -----------------------------------------------------------------------------
@ Switches for capabilities of this chip
@ -----------------------------------------------------------------------------

@ .equ m0core, 1			K20 sub-family is Cortex-M4
.equ emulated16bitflashwrites, 1
@ .equ charkommaavailable, 1		K20 can only write long words (4 bytes)

@ -----------------------------------------------------------------------------
@ Start with some essential macro definitions
@ -----------------------------------------------------------------------------

.include "../common/datastackandmacros.s"

@ -----------------------------------------------------------------------------
@ Speicherkarte für Flash und RAM
@ Memory map for Flash and RAM
@ -----------------------------------------------------------------------------

@ Konstanten für die Größe des Ram-Speichers
@ Constants for the size of the Ram memory

.equ RamAnfang, 0x1FFF8000 @ Start of RAM          Porting: Change this !
.equ RamEnde,   0x20008000 @ End   of RAM.  64 kb. Porting: Change this !

@ Konstanten für die Größe und Aufteilung des Flash-Speichers
@ Constants for the size and layout of the flash memory

.equ Kernschutzadresse,     0x00004000 @ Darunter wird niemals etwas geschrieben ! Mecrisp core never writes flash below this address.
.equ FlashDictionaryAnfang, 0x00004000 @ 16 kb für den Kern reserviert...           16 kb Flash reserved for core.
.equ FlashDictionaryEnde,   0x00040000 @ 240 kb Platz für das Flash-Dictionary     240 kb Flash available. Porting: Change this !
.equ Backlinkgrenze,        RamAnfang  @ Ab dem Ram-Start.


@ -----------------------------------------------------------------------------
@ Anfang im Flash - Interruptvektortabelle ganz zu Beginn
@ Flash start - Vector table has to be placed here
@ -----------------------------------------------------------------------------
.text    @ Hier beginnt das Vergnügen mit der Stackadresse und der Einsprungadresse
	 @ Here is where the fun begins with the stack address and the entry address
.include "vectors.s" @ You have to change vectors for Porting !

@ -----------------------------------------------------------------------------
@ Include the Forth core of Mecrisp-Stellaris
@ -----------------------------------------------------------------------------

.include "../common/forth-core.s"

@ -----------------------------------------------------------------------------
Reset: @ Einsprung zu Beginn
       @ entry point at the beginning
@ -----------------------------------------------------------------------------

  @ Disable the watchdog timer
  movs r1, #0
  ldr  r0, =0x40052000 @ WDOG_STCTRLH
  @ Write the magic unlock sequence to the watchdog unlock register (see manual pg 478)
  movw r2, #50464		@ Unlock sequence #1
  strh r2, [r0, #14]		@ Write to unlock register
  movw r2, #55592		@ Unlock sequence #2	
  strh r2, [r0, #14]		@ Write to unlock register
  @ Now read WDOG_STCTRLH, clear bit 0 (Wathdog enable) and write it back
  ldrh r2, [r0, #0]
  bic.w r2,r2, #1	
  strh r2, [r0, #0]

   @ Initialisierungen der Hardware, habe und brauche noch keinen Datenstack dafür
   @ Initializations for Terminal hardware, without Datastack.
   bl uart_init

Restart:
   @ Catch the pointers for Flash dictionary
   .include "../common/catchflashpointers.s"

   welcome " by Matthias Koch"
   @ You do not have to include the below ... my contributions were minor
   writeln "Configuration for Teensy 3.1 platform by Mark Schweizer"
   @ Dear Mark, you created a whole new target ! My congratulations - and of course you get credits for this :-) Matthias

   @ Ready to fly !
   .include "../common/boot.s"
