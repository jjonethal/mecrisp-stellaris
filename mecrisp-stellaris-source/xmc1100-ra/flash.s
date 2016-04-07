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

@ Flash handling for XMC1100
@ This one has a beasty hardware ECC which operates on 16 byte blocks and cannot be disabled.

.equ NVM_BASE, 0x40050000

.equ NVMSTATUS, NVM_BASE + 0 @ NVM Status Register
.equ NVMPROG,   NVM_BASE + 4 @ NVM Programming Control Register
.equ NVMCONF,   NVM_BASE + 8 @ NVM Configuration Register


hexflashstore_fehler:
  Fehler_Quit "Flash cannot be written twice"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "16flash!" @ Writes 16 Bytes at once into Flash.
hexflashstore: @ ( x1 x2 x3 x4 addr -- ) x1 contains LSB of those 128 bits.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
  @ Check if this goes into core - don't allow that ! No need to check for because of the second check.
  @ Perform write only if desired destination is in erased state...

  movs r0, #15
  ands r0, tos
  beq 1f
    Fehler_Quit "16flash! needs 16-aligned address"

1:ldr r0, [tos]             @ Make sure to write to empty locations only !
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #4]
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #8]
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #12]
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, =NVMPROG
  movs r1, #0x91 @ One shot write without verify
  str r1, [r0]

  ldmia psp!, {r3}    @ Fetch data to be written
  ldmia psp!, {r2}
  ldmia psp!, {r1}
  ldmia psp!, {r0}

  str r0, [tos]       @ Write it to flash, in ascending address order !
  str r1, [tos, #4]
  str r2, [tos, #8]
  str r3, [tos, #12]
 
  ldr r2, =NVMSTATUS  @ Wait for Flash BUSY Flag to be cleared
1:ldr r3, [r2]
  movs r0, #1
  ands r0, r3
  bne 1b

  @ ldr r0, =NVMPROG
  @ movs r1, #0x00 @ No action
  @ str r1, [r0]

  drop @ Forget destination address
  pop {r0, r1, r2, r3, pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 256 Bytes großen Flashblock  Deletes one 256 Byte Flash page
flashpageerase:
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
  popda r0 @ Adresse zum Löschen holen Fetch address to erase.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ? Don't erase Forth core.
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 2f

  ldr r3, =NVMPROG
  movs r1, #0x92 @ One shot erase
  str r1, [r3]

  str r0, [r0] @ Write a dummy value to the page which is to be erased

  ldr r2, =NVMSTATUS  @ Wait for Flash BUSY Flag to be cleared
1:ldr r3, [r2]
  movs r0, #1
  ands r0, r3
  bne 1b

  @ ldr r3, =NVMPROG
  @ movs r1, #0x00 @ No action
  @ str r1, [r3]

2:pop {r0, r1, r2, r3, pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
@ -----------------------------------------------------------------------------
        ldr r0, =FlashDictionaryAnfang
eraseflash_intern:
  cpsid i
        ldr r1, =FlashDictionaryEnde
        ldr r2, =0xFFFF

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
  bl Restart

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflashfrom" @ ( Addr -- )
  @ Beginnt an der angegebenen Adresse mit dem Löschen des Dictionaries.
@ -----------------------------------------------------------------------------
        popda r0
        b.n eraseflash_intern
