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
.equ does_above_64kb, 1
.equ charkommaavailable, 1
.equ registerallocator, 1
.equ color, 1

@ -----------------------------------------------------------------------------
@ Start with some essential macro definitions
@ -----------------------------------------------------------------------------

.include "../common/datastackandmacros.s"

@ -----------------------------------------------------------------------------
@ Speicherkarte für Flash und RAM
@ Memory map for Flash and RAM
@ -----------------------------------------------------------------------------


.equ SramAnfang,  0x20000000
.equ SramSize,    0x40000
.equ SramEnde,    SramAnfang + SramSize

.equ FlashEraseSize,      0x1000
.equ FlashEraseCmd,       0x020
.equ BootSize,            FlashEraseSize
.equ KernelSize,          6  * FlashEraseSize   @  6 * 4kiB = 24kiB für den Kern reserviert...  24kiB reserved for core.
.equ FlashDictionarySize, 10 * FlashEraseSize   @ 10 * 4kiB = 40kiB für das Flash-Dictionary... 40kiB flash dictionary available
.equ FirstDictionary,     BootSize + KernelSize @ The second stage bootloader takes up a whole flash erase sector in flash

@ Konstanten für die Größe und Aufteilung des Flash-Speichers

@ At runtime the kernel lives at the beginning of SRAM followed by a copy of the flash dictionary.
.equ FlashDictionaryAnfang, SramAnfang + KernelSize
.equ FlashDictionaryEnde,   FlashDictionaryAnfang + FlashDictionarySize
.equ Backlinkgrenze,        RamAnfang                                   @ Ab dem Ram-Start.

@ Konstanten für die Größe des Ram-Speichers

.equ RamAnfang, FlashDictionaryEnde @ Start of RAM          Porting: Change this !
.equ RamEnde,   SramEnde            @ End   of RAM. 192 kb. Porting: Change this !

@ -----------------------------------------------------------------------------
@ Anfang im Flash - Interruptvektortabelle ganz zu Beginn
@ Flash start - Vector table has to be placed here
@ -----------------------------------------------------------------------------
.text    @ Hier beginnt das Vergnügen mit der Stackadresse und der Einsprungadresse

.include "vectors.s" @ Contains Second-Stage-Loader-Block, too.

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

   welcome " with M0 core for Raspberry Pico by Matthias Koch"

   @ Ready to fly !
   .include "../common/boot.s"

@ Pad the kernel with zeros and make sure that the kernel fits.
@ The validation works because it's a fatal error to .org backwards.
@ Next append an empty flash dictionary (all ones).
.org KernelSize, 0x00
.org KernelSize + FlashDictionarySize, 0xFF
