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

@ Schreiben und Löschen des Flash-Speichers.
@ Write and erase of flash memory.

.equ FLCC0_STAT           ,  0x40018000  @  0x00000000   FLCC0 Status
.equ FLCC0_IEN            ,  0x40018004  @  0x00000060   FLCC0 Interrupt Enable
.equ FLCC0_CMD            ,  0x40018008  @  0x00000000   FLCC0 Command
.equ FLCC0_KH_ADDR        ,  0x4001800C  @  0x00000000   FLCC0 Write Address
.equ FLCC0_KH_DATA0       ,  0x40018010  @  0xFFFFFFFF   FLCC0 Write Lower Data
.equ FLCC0_KH_DATA1       ,  0x40018014  @  0xFFFFFFFF   FLCC0 Write Upper Data
.equ FLCC0_PAGE_ADDR0     ,  0x40018018  @  0x00000000   FLCC0 Lower Page Address
.equ FLCC0_PAGE_ADDR1     ,  0x4001801C  @  0x00000000   FLCC0 Upper Page Address
.equ FLCC0_KEY            ,  0x40018020  @  0x00000000   FLCC0 Key
.equ FLCC0_WR_ABORT_ADDR  ,  0x40018024  @  0x00000000   FLCC0 Write Abort Address
.equ FLCC0_WRPROT         ,  0x40018028  @  0xFFFFFFFF   FLCC0 Write Protection
.equ FLCC0_SIGNATURE      ,  0x4001802C  @  0x00000000   FLCC0 Signature
.equ FLCC0_UCFG           ,  0x40018030  @  0x00000000   FLCC0 User Configuration
.equ FLCC0_TIME_PARAM0    ,  0x40018034  @  0xB8954950   FLCC0 Time Parameter 0
.equ FLCC0_TIME_PARAM1    ,  0x40018038  @  0x00000004   FLCC0 Time Parameter 1
.equ FLCC0_ABORT_EN_LO    ,  0x4001803C  @  0x00000000   FLCC0 IRQ Abort Enable (Lower Bits)
.equ FLCC0_ABORT_EN_HI    ,  0x40018040  @  0x00000000   FLCC0 IRQ Abort Enable (Upper Bits)
.equ FLCC0_ECC_ADDR       ,  0x40018048  @  0x00000000   FLCC0 ECC Status (Address)
.equ FLCC0_POR_SEC        ,  0x40018050  @  0x00000000   FLCC0 Flash Security
.equ FLCC0_VOL_CFG        ,  0x40018054  @  0x00000001   FLCC0 Volatile Flash Configuration

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "8flash!" @ Writes 8 Bytes at once into Flash with ECC.
eightflashstore: @ ( x1 x2 addr -- ) x1 contains LSB of those 64 bits.
@ -----------------------------------------------------------------------------
  @ Check if this goes into core - don't allow that ! No need to check for because of the second check.
  @ Perform write only if desired destination is in erased state...

  push {r0, r1, r2, r3, lr} @ Saving registers is necessary for "flash8bytesblockwrite" emulation layer !

  movs r0, #7
  ands r0, tos
  beq 1f
    Fehler_Quit "8flash! needs 8-aligned address !"
1:

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?

  ldr r3, =Kernschutzadresse
  cmp tos, r3
  blo.n flash_error

  ldr r3, =FlashDictionaryEnde
  cmp tos, r3
  bhs.n flash_error

  @ Ist die gewünschte Stelle noch unbeschrieben ?

  ldr r0, [tos]
  adds r0, #1
  bne.n flash_twice

  ldr r0, [tos, #4]
  adds r0, #1
  bne.n flash_twice

  @ Daten holen, die geschrieben werden sollen.

  ldmia psp!, {r1}
  ldmia psp!, {r0}

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 -1 ist.

  movs r3, r0
  ands r3, r1
  cmp r3, #-1
  beq 2f @ Fertig ohne zu Schreiben

  @ Okay, alle Proben bestanden. 

  ldr r3, =FLCC0_KH_ADDR
  str tos, [r3]

  ldr r3, =FLCC0_KH_DATA0
  str r0, [r3]
  
  ldr r3, =FLCC0_KH_DATA1
  str r1, [r3]

  ldr r3, =FLCC0_CMD
  movs r2, #4 @ WRITE
  str r2, [r3]

  ldr r3, =FLCC0_STAT
1:ldr r2, [r3]
  ands r2, #4 @ CMDCOMP
  beq 1b

  @ Automatically clears when a new command is requested...
  @ movs r2, #4
  @ str r2, [r3]

2:drop
  pop {r0, r1, r2, r3, pc}

flash_error:
  Fehler_Quit "Wrong address or data for writing flash !"

flash_twice:
  Fehler_Quit "Flash cannot be written twice !"

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

  @ Okay, alle Proben bestanden. 

  ldr r3, =FLCC0_PAGE_ADDR0
  str r0, [r3]

  ldr r3, =FLCC0_KEY
  ldr r2, =0x676C7565
  str r2, [r3]

  ldr r3, =FLCC0_CMD
  movs r2, #6 @ ERASEPAGE
  str r2, [r3]

  ldr r3, =FLCC0_STAT
1:ldr r2, [r3]
  ands r2, #4 @ CMDCOMP
  beq 1b

  @ Automatically clears when a new command is requested...
  @ movs r2, #4
  @ str r2, [r3]

  ldr r3, =FLCC0_KEY
  movs r2, #0
  str r2, [r3]

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
