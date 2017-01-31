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

@ Routines to write and erase Flash memory in EFM32HG322F64.
@ Porting: Rewrite this !
@ You need hflash! and - as far as possible - cflash!

.equ MSC_Base, 0x400C0000

.equ MSC_CTRL,        MSC_Base + 0x00 @ Memory System Control Register
.equ MSC_READCTRL,    MSC_Base + 0x04 @ Read Control Register
.equ MSC_WRITECTRL,   MSC_Base + 0x08 @ Write Control Register
.equ MSC_WRITECMD,    MSC_Base + 0x0C @ Write Command Register
.equ MSC_ADDRB,       MSC_Base + 0x10 @ Page Erase/Write Address Buffer
.equ MSC_WDATA,       MSC_Base + 0x18 @ Write Data Register
.equ MSC_STATUS,      MSC_Base + 0x1C @ Status Register
.equ MSC_IF,          MSC_Base + 0x2C @ Interrupt Flag Register
.equ MSC_IFS,         MSC_Base + 0x30 @ Interrupt Flag Set Register
.equ MSC_IFC,         MSC_Base + 0x34 @ Interrupt Flag Clear Register
.equ MSC_IEN,         MSC_Base + 0x38 @ Interrupt Enable Register
.equ MSC_LOCK,        MSC_Base + 0x3C @ Configuration Lock Register
.equ MSC_CMD,         MSC_Base + 0x40 @ Command Register
.equ MSC_CACHEHITS,   MSC_Base + 0x44 @ Cache Hits Performance Counter
.equ MSC_CACHEMISSES, MSC_Base + 0x48 @ Cache Misses Performance Counter
.equ MSC_TIMEBASE,    MSC_Base + 0x50 @ Flash Write and Erase Timebase
.equ MSC_MASSLOCK,    MSC_Base + 0x54 @ Mass Erase Lock Register

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

@         1 msc_writectrl !
@     $8000 msc_addrb ! 
@ $12345678 msc_wdata !
@         1 msc_writecmd !
@         8 msc_writecmd !
@         0 msc_writectrl !

  @ r0: Adresse
  @ r1: Inhalt

  ldr r2, =MSC_WRITECTRL
  movs r3, #1
  str r3, [r2]

  movs r2, #2
  movs r3, r0
  bics r3, r2
  ldr r2, =MSC_ADDRB
  str r3, [r2]

  ldr r2, =MSC_WDATA
  movs r3, #2
  ands r3, r0
  bne 4f
  @ Lower 16 Bits
    ldr r3, =0xFFFF0000
    b 5f
4:@ Higher 16 Bits
    lsls r1, #16
    ldr r3, =0xFFFF
5:orrs r1, r3
  str r1, [r2]

  ldr r2, =MSC_WRITECMD
  movs r3, #1
  str r3, [r2]

  ldr r2, =MSC_WRITECMD
  movs r3, #8
  str r3, [r2]

  ldr r2, =MSC_STATUS
  movs r0, #1
1:ldr r3, [r2]
  ands r3, r0   @ Wait for Flash BUSY Flag to be cleared
  bne 1b
 
  ldr r2, =MSC_WRITECTRL
  movs r3, #0
  str r3, [r2]

2:bx lr
3:Fehler_Quit "Wrong address or data for writing flash !"


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 1 kb großen Flashblock  Deletes one 1 kb Flash page
flashpageerase:
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
  popda r0 @ Adresse zum Löschen holen Fetch address to erase.

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ? Don't erase Forth core.
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 2f

  ldr  r2, =MSC_WRITECTRL  @ Enable write access
  movs r3, #1
  str r3, [r2]

  movs r2, #2
  movs r3, r0
  bics r3, r2
  ldr r2, =MSC_ADDRB       @ Set address, aligned on 4-even
  str r3, [r2]

  ldr r2, =MSC_WRITECMD    @ Load the just written address into logic
  movs r3, #1
  str r3, [r2]

  ldr r2, =MSC_WRITECMD    @ Erase page command
  movs r3, #2
  str r3, [r2]             

  ldr r2, =MSC_STATUS
  movs r0, #1
1:ldr r3, [r2]
  ands r3, r0   @ Wait for Flash BUSY Flag to be cleared
  bne 1b

  ldr  r2, =MSC_WRITECTRL  @ Disable write access
  movs r3, #0
  str r3, [r2]

2:pop {r0, r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
eraseflash: @ Löscht den gesamten Inhalt des Flashdictionaries.
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
