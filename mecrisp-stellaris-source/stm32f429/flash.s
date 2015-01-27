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

@ Schreiben und Löschen des Flash-Speichers im STM32F429.

@ In diesem Chip gibt es Flashschreibzugriffe mit wählbarer Breite -
@ so ist es diesmal ganz komfortabel. Leider gibt es nur wenige große
@ Sektoren, die getrennt gelöscht werden können.

@ Write and Erase Flash in STM32F429.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!

.equ FLASH_Base, 0x40023C00

.equ FLASH_ACR,     FLASH_Base + 0x00 @ Flash Access Control Register
.equ FLASH_KEYR,    FLASH_Base + 0x04 @ Flash Key Register
.equ FLASH_OPTKEYR, FLASH_Base + 0x08 @ Flash Option Key Register
.equ FLASH_SR,      FLASH_Base + 0x0C @ Flash Status Register
.equ FLASH_CR,      FLASH_Base + 0x10 @ Flash Control Register
.equ FLASH_OPTCR,   FLASH_Base + 0x14 @ Flash Option Control Register


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
  ands r2, r0, #1
  cmp r2, #0
  bne 3f

  @ Ist an der gewünschten Stelle -1 im Speicher ?
  ldrh r2, [r0]
  cmp r2, r3
  bne 3f

  @ Okay, alle Proben bestanden. 

  @ Im STM32F4 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  adds r0, #0x08000000

  @ Bereit zum Schreiben !

  @ Unlock Flash Control
  ldr r2, =FLASH_KEYR
  ldr r3, =0x45670123
  str r3, [r2]
  ldr r3, =0xCDEF89AB
  str r3, [r2]

  @ Set size to write
  ldr r2, =FLASH_CR
  ldr r3, =0x00000101 @ 16 Bits programming
  str r3, [r2]

  @ Write to Flash !
  strh r1, [r0]

  @ Wait for Flash BUSY Flag to be cleared
  ldr r2, =FLASH_SR

1:  ldr r3, [r2]
    ands r3, #0x00010000
    bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_CR
  ldr r3, =0x80000000
  str r3, [r2]

2:bx lr
3:Fehler_Quit "Wrong address or data for writing flash !"




 @ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cflash!" @ ( x Addr -- )
  @ Schreibt ein einzelnes Byte in den Flash.
c_flashkomma:
@ -----------------------------------------------------------------------------
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3b

  ldr r3, =FlashDictionaryEnde
  cmp r0, r3
  bhs 3b


  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ands r1, #0xFF @ Alles Unwichtige von den Daten wegmaskieren
  cmp  r1, #0xFF
  beq 2f @ Fertig ohne zu Schreiben

  @ Ist an der gewünschten Stelle -1 im Speicher ?
  ldrb r2, [r0]
  cmp r2, #0xFF
  bne 3b

  @ Okay, alle Proben bestanden. 

  @ Im STM32F4 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  adds r0, #0x08000000

  @ Bereit zum Schreiben !

  @ Unlock Flash Control
  ldr r2, =FLASH_KEYR
  ldr r3, =0x45670123
  str r3, [r2]
  ldr r3, =0xCDEF89AB
  str r3, [r2]

  @ Set size to write
  ldr r2, =FLASH_CR
  ldr r3, =0x00000001 @ 8 Bits programming
  str r3, [r2]

  @ Write to Flash !
  strb r1, [r0]

  @ Wait for Flash BUSY Flag to be cleared
  ldr r2, =FLASH_SR

1:  ldr r3, [r2]
    ands r3, #0x00010000
    bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_CR
  ldr r3, =0x80000000
  str r3, [r2]

2:bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflashsector" @ ( u -- )
eraseflashsector:  @ Löscht einen Flash-Sektor
@ -----------------------------------------------------------------------------
  push {lr}

  cmp tos, #1   @ Nicht den Kern in Sektor 0 löschen  Never erase sector 0
  blo 2f
  cmp tos, #28  @ Es gibt nur 24 Sektoren, allerdings mit einer Lücke dazwischen.
  bhs 2f        @ There are 24 sectors, but with an hole in between.

  cmp tos, #12   @ Don't accept the invalid sectors between the both Flash banks for erasure.
  beq 2f
  cmp tos, #13
  beq 2f
  cmp tos, #14
  beq 2f
  cmp tos, #15
  beq 2f


  ldr r2, =FLASH_KEYR
  ldr r3, =0x45670123
  str r3, [r2]
  ldr r3, =0xCDEF89AB
  str r3, [r2]

  write "Erase sector "
  dup
  bl udot

  @ Set sector to erase
  ldr r2, =FLASH_CR
  ldr r3, =0x00010002
  lsls tos, #3
  orrs r3, tos
  str r3, [r2]

    @ Wait for Flash BUSY Flag to be cleared
    ldr r2, =FLASH_SR
1:    ldr r3, [r2]
      ands r3, #0x00010000
      bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_CR
  ldr r3, =0x80000000
  str r3, [r2]

  writeln "from Flash."

2:drop
  pop {pc}


.macro loeschpruefung Anfang Ende Sektornummer
  ldr r0, =\Anfang
  ldr r1, =\Ende
1:ldr r2, [r0]
  cmp r2, #0xFFFFFFFF
  beq 2f
    pushdaconst \Sektornummer
    bl eraseflashsector
    b 3f
2:adds r0, #4
  cmp r0, r1
  blo 1b
3:@ Diesen Sektor fertig durchkämmt
.endm

  @ Agenda: SRAM-Block 2 aktivieren ? Löschen des RAMs zu Beginn scheitert komischerweise.
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
@ -----------------------------------------------------------------------------
  @ Flash ist in Sektoren aufgeteilt. Prüfe die nacheinander, ob ein Löschen nötig ist.
  @ So kann ich den Speicher schonen und flott löschen :-)
  cpsid i @ Interrupt-Handler deaktivieren

  push {lr}

@ -----------------------------------------------------------------------------
@ Bank 1
@ -----------------------------------------------------------------------------
@ 16 kb sectors
  @ Sector 0 contains core and never is erased.
  loeschpruefung  0x08004000  0x08007FFF  1
  loeschpruefung  0x08008000  0x0800BFFF  2
  loeschpruefung  0x0800C000  0x0800FFFF  3

@ -----------------------------------------------------------------------------
@ 64 kb sector
  loeschpruefung  0x08010000  0x0801FFFF  4

@ -----------------------------------------------------------------------------
@ 128 kb sectors
  loeschpruefung  0x08020000  0x0803FFFF  5
  loeschpruefung  0x08040000  0x0805FFFF  6
  loeschpruefung  0x08060000  0x0807FFFF  7
  loeschpruefung  0x08080000  0x0809FFFF  8
  loeschpruefung  0x080A0000  0x080BFFFF  9
  loeschpruefung  0x080C0000  0x080DFFFF  10
  loeschpruefung  0x080E0000  0x080FFFFF  11

@ -----------------------------------------------------------------------------
@ Bank 2, starting with sector 16
@ -----------------------------------------------------------------------------
@ 16 kb sectors
  loeschpruefung  0x08100000  0x08103FFF  16
  loeschpruefung  0x08104000  0x08107FFF  17
  loeschpruefung  0x08108000  0x0810BFFF  18
  loeschpruefung  0x0810C000  0x0810FFFF  19

@ -----------------------------------------------------------------------------
@ 64 kb sector
  loeschpruefung  0x08110000  0x0811FFFF  20

@ -----------------------------------------------------------------------------
@ 128 kb sectors
  loeschpruefung  0x08120000  0x0813FFFF  21
  loeschpruefung  0x08140000  0x0815FFFF  22
  loeschpruefung  0x08160000  0x0817FFFF  23
  loeschpruefung  0x08180000  0x0819FFFF  24
  loeschpruefung  0x081A0000  0x081BFFFF  25
  loeschpruefung  0x081C0000  0x081DFFFF  26
  loeschpruefung  0x081E0000  0x081FFFFF  27

  writeln "Finished. Reset !"

  pop {lr}

  cpsie i
  b Restart
