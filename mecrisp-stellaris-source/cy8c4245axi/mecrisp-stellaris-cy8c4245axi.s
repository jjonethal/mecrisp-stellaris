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

@ -----------------------------------------------------------------------------
@ Swiches for capabilities of this chip
@ -----------------------------------------------------------------------------

.equ m0core, 1
@ Not available: .equ charkommaavailable, 1

@ -----------------------------------------------------------------------------
@ Start with some essential macro definitions
@ -----------------------------------------------------------------------------

.include "../common/datastackandmacros.s"

@ -----------------------------------------------------------------------------
@ Speicherkarte für Flash und RAM
@ Memory map for Flash and RAM
@ -----------------------------------------------------------------------------

@ Konstanten für die Größe des Ram-Speichers

.equ RamAnfang, 0x20000000 @ Start of RAM          Porting: Change this !
.equ RamEnde,   0x20001000 @ End   of RAM.   4 kb. Porting: Change this !

@ Konstanten für die Größe und Aufteilung des Flash-Speichers

.equ Kernschutzadresse,     0x00004000 @ Darunter wird niemals etwas geschrieben ! Mecrisp core never writes flash below this address.
.equ FlashDictionaryAnfang, 0x00004000 @ 16 kb für den Kern reserviert...           16 kb Flash reserved for core.
.equ FlashDictionaryEnde,   0x00008000 @ 32 kb Platz für das Flash-Dictionary       32 kb Flash available. Porting: Change this
.equ Backlinkgrenze,        RamAnfang  @ Ab dem Ram-Start.


@ -----------------------------------------------------------------------------
@ Anfang im Flash - Interruptvektortabelle ganz zu Beginn
@ Flash start - Vector table has to be placed here
@ -----------------------------------------------------------------------------
.text    @ Hier beginnt das Vergnügen mit der Stackadresse und der Einsprungadresse
.include "vectors.s" @ You have to change vectors for Porting !

@ -----------------------------------------------------------------------------
@ Include the Forth core of Mecrisp-Stellaris
@ -----------------------------------------------------------------------------

.include "../common/forth-core.s"

@ -----------------------------------------------------------------------------
Reset: @ Einsprung zu Beginn
@ -----------------------------------------------------------------------------
   @ Initialisierungen der Hardware, habe und brauche noch keinen Datenstack dafür
   @ Initialisations for Terminal hardware, without Datastack.
   bl uart_init

   @ Catch the pointers for Flash dictionary
   .include "../common/catchflashpointers.s"

   welcome " with M0 core for CY8C4245AXI by Matthias Koch"

   @ Ready to fly !
   .include "../common/boot.s"

.ltorg @ Write constant pool. You need to also do this in between when ranges for LDR get too large to assemble.

@ Necessary to increase the binary size to the exact Flash size for OpenOCD.

.balign FlashDictionaryEnde, 0xff

@ -----------------------------------------------------------------------------
@   Flashing
@ -----------------------------------------------------------------------------
@
@  The Cypress needs an external SWD programmer. In-target Bootloader is not supported.
@
@  My solution uses a STM32F303 or STM32F407 Discovery board, featuring a ST-Link v2:
@
@  ST-Link:              Connect to PSoC4 pin:
@
@  Pin 1 (White dot)
@  Pin 2                 SWDCLK
@  Pin 3                 GND
@  Pin 4                 SWDIO
@  Pin 5                 Reset
@  Pin 6
@
@  VDD (on double row)   VDD
@
@ Flash with:
@ openocd -f interface/stlink-v2.cfg -c "transport select hla_swd" -f target/psoc4.cfg -c "program mecrisp-stellaris-cy8c4245axi.hex verify reset exit"
@
