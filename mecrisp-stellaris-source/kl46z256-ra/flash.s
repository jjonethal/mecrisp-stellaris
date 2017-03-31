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

@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!
@ This chip has 32-bit-one-time writes only and needs an emulation layer for hflash!

.equ FTFA_FSTAT,  0x40020000
.equ FTFA_FCNFG,  0x40020001
.equ FTFA_FSEC,   0x40020002
.equ FTFA_FOPT,   0x40020003

.equ FTFA_FCCOB3, 0x40020004
.equ FTFA_FCCOB2, 0x40020005
.equ FTFA_FCCOB1, 0x40020006
.equ FTFA_FCCOB0, 0x40020007

.equ FTFA_FCCOB7, 0x40020008
.equ FTFA_FCCOB6, 0x40020009
.equ FTFA_FCCOB5, 0x4002000A
.equ FTFA_FCCOB4, 0x4002000B

.equ FTFA_FCCOBB, 0x4002000C
.equ FTFA_FCCOBA, 0x4002000D
.equ FTFA_FCCOB9, 0x4002000E
.equ FTFA_FCCOB8, 0x4002000F


.equ CCIF,   0x80
.equ ACCERR, 0x20
.equ FPVIOL, 0x10

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

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ldr r3, =-1
  cmp r1, r3
  beq 2f

  @ Prüfe die Adresse: Sie muss auf 4 gerade sein:
  movs r2, #3
  ands r2, r0
  bne 3f

  @ Ist an der gewünschten Stelle -1 im Speicher ? Muss noch ersetzt werden durch eine Routine, die prüft, ob nur 1->0 Wechsel auftreten.
  ldr r2, [r0]
  cmp r2, r3
  bne 4f

  @ Alles okay, alle Proben bestanden. Kann beginnen, zu schreiben.

  @ str r1, [r0] For RAM only.


  @ Read status - Flash idle ?
1:ldr r2, =FTFA_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b
  
  @ Check for Flash errors
  movs r2, #ACCERR|FPVIOL
  ands r2, r3
  beq 1f

    @ Clear old errors if any
    ldr r2, =FTFA_FSTAT
    movs r3, #0x30
    strb r3, [r2]

1:@ Give command to write Flash location
  ldr r2, =FTFA_FCCOB0
  movs r3, #0x06 @ Program Longword Command
  strb r3, [r2]

  ldr r2, =FTFA_FCCOB3
  strb r0, [r2] @ Flash address [7:0]

  lsrs r0, #8
  ldr r2, =FTFA_FCCOB2  
  strb r0, [r2] @ Flash address [15:8]

  lsrs r0, #8
  ldr r2, =FTFA_FCCOB1  
  strb r0, [r2] @ Flash address [23:16]

  ldr r2, =FTFA_FCCOB7
  strb r1, [r2] @ Byte 3 program value

  lsrs r1, #8
  ldr r2, =FTFA_FCCOB6
  strb r1, [r2] @ Byte 2 program value

  lsrs r1, #8
  ldr r2, =FTFA_FCCOB5
  strb r1, [r2] @ Byte 1 program value

  lsrs r1, #8
  ldr r2, =FTFA_FCCOB4
  strb r1, [r2] @ Byte 0 program value

  @ Launch the command
  ldr r2, =FTFA_FSTAT
  movs r3, #0x80
  strb r3, [r2]
  
  @ Read status - Wait for Finish
1:ldr r2, =FTFA_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b

2:bx lr

3:Fehler_Quit "Address has to be 4-aligned for writing flash !"
4:Fehler_Quit "Flash location cannot be written twice !"
5:Fehler_Quit "Cannot write into core !"


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 1kb großen Flashblock
flashpageerase:
@ -----------------------------------------------------------------------------
  @ Lösche gleich und ohne viel Federlesen.
  push {r0, r1, r2, r3, lr}
  popda r0 @ Adresse zum Löschen holen

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 2f

  @ Adresse auf 4 gerade machen.
  movs r3, #3
  bics r0, r3

  @ Read status - Flash idle ?
1:ldr r2, =FTFA_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b
  
  @ Check for Flash errors
  movs r2, #ACCERR|FPVIOL
  ands r2, r3
  beq 1f

    @ Clear old errors if any
    ldr r2, =FTFA_FSTAT
    movs r3, #0x30
    strb r3, [r2]

1:@ Give command to erase Flash sector
  ldr r2, =FTFA_FCCOB0
  movs r3, #0x09 @ Erase Flash Sector Command
  strb r3, [r2]

  ldr r2, =FTFA_FCCOB3
  strb r0, [r2] @ Flash address [7:0]

  lsrs r0, #8
  ldr r2, =FTFA_FCCOB2  
  strb r0, [r2] @ Flash address [15:8]

  lsrs r0, #8
  ldr r2, =FTFA_FCCOB1  
  strb r0, [r2] @ Flash address [23:16]

  @ Launch the command
  ldr r2, =FTFA_FSTAT
  movs r3, #0x80
  strb r3, [r2]
  
  @ Read status - Wait for Finish
1:ldr r2, =FTFA_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b
 
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
        ldr r2, =0xFFFFFFFF

1:      ldr r3, [r0]
        cmp r3, r2
        beq 2f
          pushda r0
            dup
            write "Erase block at  "
            bl hexdot
            writeln " from Flash"
          bl flashpageerase
2:      adds r0, #4
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
