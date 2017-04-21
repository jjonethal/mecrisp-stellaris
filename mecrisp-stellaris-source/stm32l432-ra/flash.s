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

@ this chip has ecc flash memory protection and supports 64 bit writes
@ as 2 consecutive word accesses to one 64 bit area only

@ Write and Erase Flash in STM32L476.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!


.equ FLASH_Base, 0x40022000

.equ FLASH_ACR,      FLASH_Base + 0x00 @ Flash Access Control Register
.equ FLASH_PDKEYR,   FLASH_Base + 0x04 @ Flash Power-down key register
.equ FLASH_KEYR,     FLASH_Base + 0x08 @ Flash Key Register
.equ FLASH_OPTKEYR,  FLASH_Base + 0x0C @ Flash Option Key Register
.equ FLASH_SR,       FLASH_Base + 0x10 @ Flash Status Register
.equ FLASH_CR,       FLASH_Base + 0x14 @ Flash Control Register
.equ FLASH_ECCR,     FLASH_Base + 0x18 @ Flash ECC register
.equ FLASH_OPTR,     FLASH_Base + 0x20 @ Flash option register
.equ FLASH_PCROP1SR, FLASH_Base + 0x1C @ Flash Bank 1 PCROP Start address register
.equ bit9, 1 << 9
.equ bit10, 1 << 10
.equ bit11, 1 << 11
.equ bit12, 1 << 12
@for stm32l476 we will introduce 8 byte mode later

hexflashstore_fehler:
  Fehler_Quit "Flash cannot be written twice"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "16flash!" @ Writes 16 Bytes at once into Flash.
hexflashstore: @ ( x1 x2 x3 x4 addr -- ) x1 contains LSB of those 128 bits.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r4, r5, lr}
  @ Check if this goes into core - don't allow that ! No need to check for because of the second check.
  @ Perform write only if desired destination is in erased state...

  movs r0, #15
  ands r0, tos
  beq 1f
    Fehler_Quit "16flash! needs 16-aligned address"

1:ldr r0, [tos]  @ tos contains address to write
  adds r0, #1    @ quick check if memory contains $ffffffff
  bne hexflashstore_fehler

  ldr r0, [tos, #4] @ check next 4 bytes at offset 4
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #8] @ check empty at offset 8 - for stm32l476 
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #12]
  adds r0, #1
  bne hexflashstore_fehler

  @ Okay, alle Proben bestanden. 
  
  @ Im STM32L476 ist der Flash-Speicher gespiegelt, die wirkliche Adresse liegt weiter hinten !
  @ Flash memory is mirrored, use true address later for write
  ldr r2, =0x08000000
  adds tos, r2

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
  
  
  ldmia psp!, {r3}    @ Fetch data to be written
  ldmia psp!, {r2}
  ldmia psp!, {r1}
  ldmia psp!, {r0}

  stmia tos!,{r0}
  stmia tos!,{r1}

  @ Wait for Flash BUSY Flag to be cleared
  bl waitflashopcomplete
  
  stmia tos!,{r2}  @ program next 2 words
  stmia tos!,{r3}

  @ wait again for flash op complete
  bl waitflashopcomplete

  @ turn off programming mode
  ldr r2, =FLASH_CR
  ldrh r0,[r2]
  movs r1, #1
  bics r0, r1
  strh r0,[r2]

  @ lock flash again
  ldr r2, =FLASH_CR
  ldr r0,[r2]
  ldr r1, =0x80000000
  orrs r0, r1
  str r0,[r2]

  drop @ Forget destination address
  pop {r0, r1, r2, r3, r4, r5, pc}

.ltorg

waitflashopcomplete:
  push {r0, r1} 
  @ Wait for Flash BUSY Flag to be cleared
1:  ldr r1, =FLASH_SR+2
    ldrh r0, [r1]
    movs r1, #1
    ands r0, r1
    bne 1b
@ Wait for EOP Flag to be Set
    pop {r0, r1}
    bx LR
  

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

  @ page size 2048 byte
  @ bit 10:0 byte address
  @ bit 18:11 page number
  @ bit 19 bank number
  @ Set page to erase
  @ shift down bits 19:11 -> bit 11:3
  movs r1, #11-3
  lsrs r0, r1      @ shift down bankNr and address address to BKER, PNB[7:0]
  ldr r2, =0xFF8   @ bank and page mask
  ands r0, r2      @ mask out other bits
  movs r1 ,#2
  orrs r0, r1      @ select page erase  
  ldr r2, =FLASH_CR
  strh r0, [r2]    @ write page and erase page

  @ start erasing
  movs r0,#1     @ select start
  ldr r2, =FLASH_CR+2 
  strh r0, [r2]  @ start page erase

    @ Wait for Flash BUSY Flag to be cleared
    ldr r2, =FLASH_SR+2
1:    ldrh r3, [r2]
      movs r0, #1
      ands r0, r3
      bne 1b

  @ Lock Flash after finishing this
  ldr r2, =FLASH_CR + 3
  movs r3, #0x80
  strb r3, [r2]
  
  @ clear cache
  @ save old cache settings
  ldr r2, =FLASH_ACR
  ldr r1, [r2]
  push {r1}
  
  @ turn cache off
  ldr r0,=bit10+bit9
  bics r1, r0
  str r1, [r2]
  
  @ reset cache
  ldr r0, =bit12+bit11
  orrs r1, r0
  str r1, [r2]
  
  @ restore flash settings
  pop {r1}  
  str r1, [r2]
  
2:pop {r0, r1, r2, r3, pc}

.ltorg  
 

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
.ltorg
