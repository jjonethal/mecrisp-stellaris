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

@ Schreiben und Löschen des Flash-Speichers im STM32F051.

@ In diesem Chip gibt es Flashschreibzugriffe mit wählbarer Breite -
@ so ist es diesmal ganz komfortabel. Leider gibt es nur weniger große
@ Sektoren, die getrennt gelöscht werden können.

@ Write and Erase Flash in STM32F051.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!


.equ FLASH_Base, 0x40022000

.equ FLASH_Offset_ACR,     0x00 @ Flash Access Control Register
.equ FLASH_Offset_KEYR,    0x04 @ Flash Key Register
.equ FLASH_Offset_OPTKEYR, 0x08 @ Flash Option Key Register
.equ FLASH_Offset_SR,      0x0C @ Flash Status Register
.equ FLASH_Offset_CR,      0x10 @ Flash Control Register
.equ FLASH_Offset_AR,      0x14 @ Flash Address Register
.equ FLASH_Offset_OBR,     0x1C @ Flash Option Byte Register

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" @ ( x Addr -- )
  @ Schreibt an die auf 2 gerade Adresse in den Flash.
h_flashkomma:
@ -----------------------------------------------------------------------------
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3f

  ldr r3, =FlashDictionaryEnde
  cmp r0, r3
  bhs 3f


  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ldr r3, =0xFFFF
  ands r1, r3  @ High-Halfword der Daten wegmaskieren
  cmp r1, r3
  beq 2f @ Fertig ohne zu Schreiben

  @ Prüfe die Adresse: Sie muss auf 2 gerade sein:
  movs r2, #1
  ands r2, r0
  cmp r2, #0
  bne 3f

  @ Ist an der gewünschten Stelle -1 im Speicher ?
  ldrh r2, [r0]
  cmp r2, r3
  bne 3f

  @ Okay, alle Proben bestanden. 

  @ Im STM32F051 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  @ Flash memory is mirrored, use true address later for write
  ldr r2, =0x08000000
  adds r0, r2

  @ Bereit zum Schreiben !

  ldr r2, =FLASH_Base

  @ Unlock Flash Control
  ldr r3, =0x45670123
  str r3, [r2, #FLASH_Offset_KEYR]
  ldr r3, =0xCDEF89AB
  str r3, [r2, #FLASH_Offset_KEYR]

  @ Enable write
  movs r3, #1 @ Select Flash programming
  str r3, [r2, #FLASH_Offset_CR]

  @ Write to Flash !
  strh r1, [r0]

  @ Wait for Flash BUSY Flag to be cleared
1:  ldr r3, [r2, #FLASH_Offset_SR]
    movs r0, #1
    ands r0, r3
    bne 1b

  @ Lock Flash after finishing this
  movs r3, #0x80
  str r3, [r2, #FLASH_Offset_CR]

2:bx lr
3:Fehler_Quit "Wrong write to flash !"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
  @ A very small eraseflash that takes care of two flash pages only.
@ -----------------------------------------------------------------------------
  cpsid i

  ldr r2, =FLASH_Base

  ldr r3, =0x45670123
  str r3, [r2, #FLASH_Offset_KEYR]
  ldr r3, =0xCDEF89AB
  str r3, [r2, #FLASH_Offset_KEYR]

  @ Enable erase
  movs r3, #2 @ Set Erase bit
  str r3, [r2, #FLASH_Offset_CR]

  @ Delete two pages
  movs r0, 0x38 @ 00
  bl erasepage
  movs r0, 0x3C @ 00
  bl erasepage

  @ Lock Flash after finishing this
  movs r3, #0x80
  str r3, [r2, #FLASH_Offset_CR]

  bl Restart

erasepage:
  @ Set page to erase
  lsls r0, #8
  str r0, [r2, #FLASH_Offset_AR]

  @ Start erasing
  movs r3, #0x42 @ Start + Erase
  str r3, [r2, #FLASH_Offset_CR]

    @ Wait for Flash BUSY Flag to be cleared
1:    ldr r3, [r2, #FLASH_Offset_SR]
      movs r0, #1
      ands r0, r3
      bne 1b
  bx lr
