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

@ Write and Erase Flash in MSP432P401R.
@ Porting: Rewrite this !

.equ FLCTL_PRG_CTLSTAT,        0x40011050    @ Program Control and Status Register
.equ FLCTL_ERASE_CTLSTAT,      0x400110A0    @ Erase Control and Status Register
.equ FLCTL_ERASE_SECTADDR,     0x400110A4    @ Erase Sector Address Register
.equ FLCTL_BANK0_MAIN_WEPROT,  0x400110B4    @ Main Memory Bank0 Write/Erase Protection Register
.equ FLCTL_BANK1_MAIN_WEPROT,  0x400110C4    @ Main Memory Bank1 Write/Erase Protection Register
.equ FLCTL_IFG,                0x400110F0    @ Interrupt Flag Register
.equ FLCTL_CLRIFG,             0x400110F8    @ Clear Interrupt Flag Register

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flash!" @ ( x Addr -- )
  @ Schreibt an die auf 4 gerade Adresse in den Flash.
@ -----------------------------------------------------------------------------
  push {lr}
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  cmp r1, #-1
  beq 2f

  @ Prüfe die Adresse: Sie muss auf 4 gerade sein:
  ands r2, r0, #3
  cmp r2, #0
  bne 3f

  @ Ist an der gewünschten Stelle -1 im Speicher ? Muss noch ersetzt werden durch eine Routine, die prüft, ob nur 1->0 Wechsel auftreten.
  ldr r2, [r0]
  cmp r2, #-1
  bne 3f

  bl preparewrite @ Prüft gleich noch den Speicherbereich
  str r1, [r0]
  bl finishwrite

2:pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" @ ( x Addr -- )
  @ Schreibt an die auf 2 gerade Adresse in den Flash.
h_flashkomma:
@ -----------------------------------------------------------------------------
  push {lr}
  popda r0 @ Adresse
  popda r1 @ Inhalt.

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

  bl preparewrite @ Prüft gleich noch den Speicherbereich
  strh r1, [r0]
  bl finishwrite

2:pop {pc}
3:Fehler_Quit "Wrong address or data for writing flash !"

 @ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cflash!" @ ( x Addr -- )
  @ Schreibt ein einzelnes Byte in den Flash.
c_flashkomma:
@ -----------------------------------------------------------------------------
  push {lr}
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ands r1, #0xFF @ Alles Unwichtige von den Daten wegmaskieren
  cmp  r1, #0xFF
  beq 2f @ Fertig ohne zu Schreiben

  @ Ist an der gewünschten Stelle -1 im Speicher ?
  ldrb r2, [r0]
  cmp r2, #0xFF
  bne 3b

  bl preparewrite @ Prüft gleich noch den Speicherbereich
  strb r1, [r0]
  bl finishwrite

2:pop {pc}

@ -----------------------------------------------------------------------------
preparewrite:
  push {lr}
  bl prepareflash

  @ Initiate write
  movs r3, #1
  ldr r2, =FLCTL_PRG_CTLSTAT
  str r3, [r2]

  pop {pc}

@ -----------------------------------------------------------------------------
prepareflash:
  @ Check address. Never erase or write into core !
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3b

  ldr r3, =FlashDictionaryEnde
  cmp r0, r3
  bhs 3b

  @ Unlock segments
  movs r3, #0
  ldr  r2, =FLCTL_BANK0_MAIN_WEPROT
  str  r3, [r2]
  ldr  r2, =FLCTL_BANK1_MAIN_WEPROT
  str  r3, [r2]

  @ Clear all pending flags
  ldr r3, =0x33F
  ldr r2, =FLCTL_CLRIFG
  str r3, [r2]
  bx lr

@ -----------------------------------------------------------------------------
finishwrite:
  @ Wait for program operation to finish
  ldr r2, =FLCTL_IFG
1:ldr r3, [r2]
  ands r3, #0x08
  cmp  r3, #0x08
  bne 1b

@ -----------------------------------------------------------------------------
finishflash:
  @ Clear program and erasure registers
  movs r3, #0
  ldr r2, =FLCTL_PRG_CTLSTAT
  str r3, [r2]
  ldr r2, =FLCTL_ERASE_CTLSTAT
  str r3, [r2]

  @ Lock segments again
  movs r3, #-1
  ldr  r2, =FLCTL_BANK0_MAIN_WEPROT
  str  r3, [r2]
  ldr  r2, =FLCTL_BANK1_MAIN_WEPROT
  str  r3, [r2]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 4 kb großen Flashblock
flashpageerase:
@ -----------------------------------------------------------------------------
  @ Lösche gleich und ohne viel Federlesen.
  push {r0, r1, r2, r3, lr}
  cpsid i
  popda r0 @ Adresse zum Löschen holen

  bl prepareflash

  @ Select sector for erasure
  ldr r2, =FLCTL_ERASE_SECTADDR
  str r0, [r2]

  @ Initiate erasure
  movs r1, #1
  ldr r2, =FLCTL_ERASE_CTLSTAT
  str r1, [r2]

  @ Wait for erasure to finish
  ldr r2, =FLCTL_IFG
1:ldr r3, [r2]
  ands r3, #0x20
  cmp  r3, #0x20
  bne 1b

  bl finishflash

  @ Clear "successfully erased" Flags
  movs r3, #1<<19
  ldr  r2, =FLCTL_ERASE_CTLSTAT
  str  r3, [r2]

  pop {r0, r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
eraseflash: @ Löscht den gesamten Inhalt des Flashdictionaries.
@ -----------------------------------------------------------------------------
        ldr r0, =FlashDictionaryAnfang
eraseflash_intern:
        ldr r1, =FlashDictionaryEnde
        movw r2, #0xFFFF

1:      ldrh r3, [r0]
        cmp r3, r2
        beq 2f
          pushda r0
            dup
            write "Erase block at  "
            bl hexdot
            writeln " from Flash"
          bl flashpageerase
2:      adds r0, #2
        cmp r0, r1
        bne 1b
  writeln "Finished. Reset !"
  b Restart

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflashfrom" @ ( Addr -- )
  @ Beginnt an der angegebenen Adresse mit dem Löschen des Dictionaries.
@ -----------------------------------------------------------------------------
        popda r0
        b.n eraseflash_intern
