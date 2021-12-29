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

@ Schreiben und Löschen des Flash-Speichers im STM32F746.

@ In diesem Chip gibt es Flashschreibzugriffe mit wählbarer Breite -
@ so ist es diesmal ganz komfortabel. Leider gibt es nur weniger große
@ Sektoren, die getrennt gelöscht werden können.

@ Write and Erase Flash in STM32F746.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!

.equ FLASH_Base, 0x40023C00

.equ FLASH_ACR,     FLASH_Base + 0x00 @ Flash Access Control Register
.equ FLASH_KEYR,    FLASH_Base + 0x04 @ Flash Key Register
.equ FLASH_OPTKEYR, FLASH_Base + 0x08 @ Flash Option Key Register
.equ FLASH_SR,      FLASH_Base + 0x0C @ Flash Status Register
.equ FLASH_CR,      FLASH_Base + 0x10 @ Flash Control Register
.equ FLASH_OPTCR,   FLASH_Base + 0x14 @ Flash Option Control Register

.equ flashOverwrite, 1

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
.ifndef flashOverwrite 
  @ is there 0xffff at programming location ?
  ldrh r2, [r0]
  cmp r2, r3
  bne 3f
.else  
  @ Is place overwritable ?
  ldrh r2, [r0]
  and r2, r1
  cmp r2, r1
  bne 3f
.endif
  
  @ Okay, all tests passed. 

  @ In STM32F7 flash-memory write location is at 0x0800 0000
  @ so we relocate write request to that area
  bics r0, #0xff000000
  bics r0, #0x00F00000
  adds r0, #0x08000000

  @ ready for writing !

  @ Unlock Flash Control
  ldr r2, =FLASH_KEYR
  ldr r3, =0x45670123
  str r3, [r2]
  ldr r3, =0xCDEF89AB
  str r3, [r2]

  @ Set size to write
4: ldr r2, =FLASH_CR
  ldr r3, =0x00000101 @ 16 Bits programming
  str r3, [r2]
  ldr r3, [r2]
  ldr r2, =0x00000101
  cmp r3, r2
  bne 4b
  
  @ make sure r1 is written after flash programming enabled
  DSB 

  @ Write to Flash !
  strh r1, [r0]
  dsb
  @ wait with turn of after flash written 

.ifdef turnOff  
  @ turn off writing write
5: ldr r2, =FLASH_CR
  ldr r3, =0x00000100 @ 16 Bits programming
  str r3, [r2]
  ldr r3, [r2]
  ldr r2, =0x00000100
  cmp r3, r2
  bne 5b 
.endif  
  
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
  bics r0, #0xFF000000
  bics r0, #0x00E00000
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
  dsb
  strb r1, [r0]
  dsb

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

  cmp tos, #1   @ Nicht den Kern in Sektor 0 löschen
  blo 2f
  cmp tos, #8   @ Es gibt nur 8 Sektoren
  bhs 2f

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
1:  ldr r3, [r2]
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

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
@ -----------------------------------------------------------------------------
  @ Flash ist in Sektoren aufgeteilt. Prüfe die nacheinander, ob ein Löschen nötig ist.
  @ So kann ich den Speicher schonen und flott löschen :-)
  cpsid i @ Interrupt-Handler deaktivieren

  push {lr}

@ -----------------------------------------------------------------------------
@ 32 kb sectors
@ loeschpruefung  0x08000000  0x08007FFF  0
  loeschpruefung  0x08008000  0x0800FFFF  1
  loeschpruefung  0x08010000  0x08017FFF  2
  loeschpruefung  0x08018000  0x0801FFFF  3

@ -----------------------------------------------------------------------------
@ 128 kb sector
  loeschpruefung  0x08020000  0x0803FFFF  4

@ -----------------------------------------------------------------------------
@ 256 kb sectors
  loeschpruefung  0x08040000  0x0807FFFF  5
  loeschpruefung  0x08080000  0x080BFFFF  6
  loeschpruefung  0x080C0000  0x080FFFFF  7

  writeln "Finished. Reset !"

  pop {lr}

  cpsie i
  b Restart
