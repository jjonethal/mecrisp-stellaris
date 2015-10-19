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

@ Schreiben und Löschen des Flash-Speichers im STM32L476.

@ In diesem Chip gibt es Flashschreibzugriffe mit wählbarer Breite -
@ so ist es diesmal ganz komfortabel. Leider gibt es nur weniger große
@ Sektoren, die getrennt gelöscht werden können.

@ Write and Erase Flash in STM32L476.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!


.equ FLASH_Base, 0x40022000

.equ FLASH_ACR,      FLASH_Base + 0x00 @ Flash Access Control Register
.equ FLASH_PDKEYR    FLASH_Base + 0x04 @ Flash Power-down key register
.equ FLASH_KEYR,     FLASH_Base + 0x08 @ Flash Key Register
.equ FLASH_OPTKEYR,  FLASH_Base + 0x0C @ Flash Option Key Register
.equ FLASH_SR,       FLASH_Base + 0x10 @ Flash Status Register
.equ FLASH_CR,       FLASH_Base + 0x14 @ Flash Control Register
.equ FLASH_ECCR,     FLASH_Base + 0x18 @ Flash ECC register
.equ FLASH_OPTR,     FLASH_Base + 0x20 @ Flash option register
.equ FLASH_PCROP1SR, FLASH_Base + 0x24 @ Flash Bank 1 PCROP Start address register
.equ FLASH_PCROP1ER, FLASH_Base + 0x28 @ Flash Bank 1 PCROP End address register
.equ FLASH_WRP1AR,   FLASH_Base + 0x2C @ Flash Bank 1 WRP area A address register
.equ FLASH_WRP1BR,   FLASH_Base + 0x30 @ Flash Bank 1 WRP area B address register
.equ FLASH_PCROP2SR, FLASH_Base + 0x44 @ Flash Bank 2 PCROP Start address register
.equ FLASH_PCROP2ER, FLASH_Base + 0x48 @ Flash Bank 2 PCROP End address register
.equ FLASH_WRP2AR,   FLASH_Base + 0x4C @ Flash Bank 2 WRP area A address register
.equ FLASH_WRP2BR,   FLASH_Base + 0x50 @ Flash Bank 2 WRP area B address register


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cflash!" @ ( x Addr -- )
  @ write on character into flash.
c_flashkomma:
@ -----------------------------------------------------------------------------
  @ check boundaries
  @ getDword at address
  @ progadr = Addr and $fffffff8
  @ shift = (Addr and 3) << 3
  @ mask = $ff << shift
  @ shifted_val = x << shift
  @ shifted_val = shifted_val or not mask
  @ wordl = [progadr]
  @ wordh = [progadr+4]
  @ if addr and 4 
  @   prog_wordh = shifted_val
  @   prog_wordl = $ffff_ffff
  @   if wordh and mask and shifted_val != shifted_val error
  @ else
  @   prog_wordl = shifted_val
  @   prog_wordh = $ffff_ffff
  @   if wordl and mask and shifted_val != shifted_val error
  @ end
  @ writel = prog_wordl and wordl
  @ writeh = prog_wordh and wordl
  @ [progadr]   = writel
  @ [progadr+4] = writeh
  popda r0 @ address
  popda r1 @ value
  movs  r2, #0xff
  ands  r1, r2  @ mask out other then byte0
  movs  r3, #3  @ which byte 0..3
  ands  r3, r0  @ shift value ( progadr bits 0,1)
  movs  r2, #3
  lsl   r3, r2  @ number of bits to shift in r3 now
  lsl   r1, r3  @ shift value to final position
  movs  r2, #0xff
  lsl   r2, r3  @ shift mask to same position as value r2 contains shifted mask
  movs  r4, #7  @ mask for double word base address
  mvn   r4, r4
  ands  r4, r0  @ r4 contains double word base adress
1:
  bx lr

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

  @ Im STM32L476 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  @ Flash memory is mirrored, use true address later for write
  ldr r2, =0x08000000
  adds r0, r2

  @ Bereit zum Schreiben !

  @ Unlock Flash Control
  ldr r2, =FLASH_KEYR
  ldr r3, =0x45670123
  str r3, [r2]
  ldr r3, =0xCDEF89AB
  str r3, [r2]

  @ Enable write
  ldr r2, =FLASH_CR
  movs r3, #1 @ Select Flash programming
  str r3, [r2]

  @ Write to Flash !
  strh r1, [r0]

  @ Wait for Flash BUSY Flag to be cleared
  ldr r2, =FLASH_SR

1:  ldr r3, [r2]
    @ ands r3, #1
    movs r0, #1
    ands r0, r3
    bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_CR
  movs r3, #0x80
  str r3, [r2]

2:bx lr
3:Fehler_Quit "Wrong address or data for writing flash !"


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 2kb großen Flashblock  Deletes one 2kb Flash page
flashpageerase:
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
  popda r0 @ Adresse zum Löschen holen Fetch address to erase.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ? Don't erase Forth core.
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 2f

  ldr r2, =FLASH_KEYR
  ldr r3, =0x45670123
  str r3, [r2]
  ldr r3, =0xCDEF89AB
  str r3, [r2]

  @ Enable erase
  ldr r2, =FLASH_CR
  movs r3, #2 @ Set Erase bit
  str r3, [r2]

  @ Set page to erase
  ldr r2, =FLASH_AR
  str r0, [r2]

  @ Start erasing
  ldr r2, =FLASH_CR
  movs r3, #0x42 @ Start + Erase
  str r3, [r2]

    @ Wait for Flash BUSY Flag to be cleared
    ldr r2, =FLASH_SR
1:    ldr r3, [r2]
      movs r0, #1
      ands r0, r3
      bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_CR
  movs r3, #0x80
  str r3, [r2]

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
