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

@ Schreiben und Löschen des Flash-Speichers im STM32L152.
@ Write and Erase Flash in STM32L152.
@ Porting: Rewrite this !

@ This chip has word writes only and very small erasable pages of 256 bytes.
@ One special feature is that erased Flash contains zeros !

.equ FLASH_Base, 0x40023C00

.equ FLASH_ACR,     FLASH_Base + 0x00 @ Flash Access Control Register
.equ FLASH_PECR,    FLASH_Base + 0x04 @ Flash
.equ FLASH_PDKEYR,  FLASH_Base + 0x08 @ Flash
.equ FLASH_PEKEYR,  FLASH_Base + 0x0C @ Flash
.equ FLASH_PRGKEYR, FLASH_Base + 0x10 @ Flash program memory key register
.equ FLASH_OPTKEYR, FLASH_Base + 0x14 @ Flash
.equ FLASH_SR,      FLASH_Base + 0x18 @ Flash Status Register
.equ FLASH_OBR,     FLASH_Base + 0x1C @ Flash


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flash!" @ ( x Addr -- )
  @ Schreibt an die auf 4 gerade Adresse in den Flash.
flashkomma:
@ -----------------------------------------------------------------------------
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 5f @ Schreibzugriffe in den Kern ignorieren.

  @ Prüfe die Adresse: Sie muss auf 4 gerade sein:
  movs r2, #3
  ands r2, r0
  bne 3f

  @ Prüfe Daten. Schreibe nur, wenn es NICHT 0 ist.

    cmp r1, #0
    beq 2f

  @ Prüfe Inhalt. Muss zum Schreiben 0 enthalten.

    ldr r2, [r0]
    cmp r2, #0
    bne 4f

  @ Alles okay, alle Proben bestanden. Kann beginnen, zu schreiben.

  @ Im STM32 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  @ Flash memory is mirrored, use true address later for write
  adds r0, #0x08000000

  @ Bereit zum Schreiben !

  @ Unlock Flash PECR register

  ldr r2, =FLASH_PEKEYR
  ldr r3, =0x89ABCDEF
  str r3, [r2]
  ldr r3, =0x02030405
  str r3, [r2]

  @ Unlock program memory

  ldr r2, =FLASH_PRGKEYR
  ldr r3, =0x8C9DAEBF
  str r3, [r2]
  ldr r3, =0x13141516
  str r3, [r2]

  @ Write to Flash ! No need to set a write bit before.
  str r1, [r0]

  @ Wait for Flash BUSY Flag to be cleared
  ldr r2, =FLASH_SR

1:  ldr r3, [r2]
    ands r3, #1
    bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_PECR
  movs r3, #7
  str r3, [r2]

2:bx lr

3:Fehler_Quit "Address has to be 4-aligned for writing flash !"
4:Fehler_Quit "Flash location cannot be written twice !"
5:Fehler_Quit "Cannot write into core !"


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 256 Bytes großen Flashblock  Deletes one 256 Bytes Flash page
flashpageerase:
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
  popda r0 @ Adresse zum Löschen holen Fetch address to erase.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ? Don't erase Forth core.
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 2f

  @ Im STM32L152 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  @ Flash memory is mirrored, use true address later for write and erase.
  adds r0, #0x08000000

  @ Unlock Flash PECR register

  ldr r2, =FLASH_PEKEYR
  ldr r3, =0x89ABCDEF
  str r3, [r2]
  ldr r3, =0x02030405
  str r3, [r2]

  @ Unlock program memory

  ldr r2, =FLASH_PRGKEYR
  ldr r3, =0x8C9DAEBF
  str r3, [r2]
  ldr r3, =0x13141516
  str r3, [r2]

  @ Set erase mode

  ldr r2, =FLASH_PECR
  movs r3, #BIT9+BIT3  @ ERASE + PROG
  str r3, [r2]

  @ Select page to erase:

  bics r0, #0xFF @ Write 0 to first word of Program page - mask away lower bits. One page is 64 words = 4*64 Bytes = 256 Bytes long.
  movs r2, #0
  str r2, [r0]

  @ Wait for Flash BUSY Flag to be cleared

  ldr r2, =FLASH_SR

1:  ldr r3, [r2]
    ands r3, #1
    bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_PECR
  movs r3, #7
  str r3, [r2]

  pop {r0, r1, r2, r3, pc}

2:Fehler_Quit "Cannot erase core !"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
@ -----------------------------------------------------------------------------
        ldr r0, =FlashDictionaryAnfang
eraseflash_intern:
  cpsid i
        ldr r1, =FlashDictionaryEnde

1:      ldrh r3, [r0]
        cmp r3, #0
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
