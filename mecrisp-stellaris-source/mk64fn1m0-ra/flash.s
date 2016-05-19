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

.equ FTFE_FSTAT,  0x40020000
.equ FTFE_FCNFG,  0x40020001
.equ FTFE_FSEC,   0x40020002
.equ FTFE_FOPT,   0x40020003

.equ FTFE_FCCOB3, 0x40020004
.equ FTFE_FCCOB2, 0x40020005
.equ FTFE_FCCOB1, 0x40020006
.equ FTFE_FCCOB0, 0x40020007

.equ FTFE_FCCOB7, 0x40020008
.equ FTFE_FCCOB6, 0x40020009
.equ FTFE_FCCOB5, 0x4002000A
.equ FTFE_FCCOB4, 0x4002000B

.equ FTFE_FCCOBB, 0x4002000C
.equ FTFE_FCCOBA, 0x4002000D
.equ FTFE_FCCOB9, 0x4002000E
.equ FTFE_FCCOB8, 0x4002000F


.equ CCIF,     0x80
.equ RDCOLERR, 0x40
.equ ACCERR,   0x20
.equ FPVIOL,   0x10


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "16flash!" @ Writes 16 Bytes at once into Flash.
hexflashstore: @ ( x1 x2 x3 x4 addr -- ) x1 contains LSB of those 128 bits.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r4, r5, lr}

  @ High-Teil
  push {tos}
  adds tos, #8
  bl flash8komma

  @ Low-Teil
  pushdatos
  pop {tos}
  bl flash8komma

  pop {r0, r1, r2, r3, r4, r5, pc}

@ -----------------------------------------------------------------------------
flash8komma: @ ( x1 x2 addr ) Writes 8 Bytes at once into Flash.
             @ x1 contains LSB of those 128 bits.
@ -----------------------------------------------------------------------------
  popda r0 @ Adresse
  popda r1 @ Inhalt High
  @ TOS    @ Inhalt Low

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 5f @ Schreibzugriffe in den Kern ignorieren.

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ands r3, r1, tos @ Verundere High und Low zusammen. Ergebnis ist nur -1, wenn beide -1 waren.
  adds r3, #1
  beq 2f

  @ Prüfe die Adresse: Sie muss auf 8 gerade sein:
  movs r2, #7
  ands r2, r0
  bne 3f

  @ Ist an der gewünschten Stelle -1 im Speicher ?
  ldr r2, [r0]
  cmp r2, #-1
  bne 4f

  ldr r2, [r0, 4]
  cmp r2, #-1
  bne 4f

  @ Alles okay, alle Proben bestanden. Kann beginnen, zu schreiben.

  @ Read status - Flash idle ?
1:ldr r2, =FTFE_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b

  @ Check for Flash errors
  movs r2, #ACCERR|FPVIOL
  ands r2, r3
  beq 1f

    @ Clear old errors if any
    ldr r2, =FTFE_FSTAT
    movs r3, #0x30
    strb r3, [r2]

1:@ Give command to write Flash location
  ldr r2, =FTFE_FCCOB0
  movs r3, #0x07 @ Program Phrase Command
  strb r3, [r2]

  ldr r2, =FTFE_FCCOB3
  strb r0, [r2] @ Flash address [7:0]

  lsrs r0, #8
  ldr r2, =FTFE_FCCOB2
  strb r0, [r2] @ Flash address [15:8]

  lsrs r0, #8
  ldr r2, =FTFE_FCCOB1
  strb r0, [r2] @ Flash address [23:16]


  @ Low-Teil

  ldr r2, =FTFE_FCCOB7
  strb tos, [r2] @ Byte 3 program value

  lsrs tos, #8
  ldr r2, =FTFE_FCCOB6
  strb tos, [r2] @ Byte 2 program value

  lsrs tos, #8
  ldr r2, =FTFE_FCCOB5
  strb tos, [r2] @ Byte 1 program value

  lsrs tos, #8
  ldr r2, =FTFE_FCCOB4
  strb tos, [r2] @ Byte 0 program value

  @ High-Teil

  ldr r2, =FTFE_FCCOBB
  strb r1, [r2] @ Byte 7 program value

  lsrs r1, #8
  ldr r2, =FTFE_FCCOBA
  strb r1, [r2] @ Byte 6 program value

  lsrs r1, #8
  ldr r2, =FTFE_FCCOB9
  strb r1, [r2] @ Byte 5 program value

  lsrs r1, #8
  ldr r2, =FTFE_FCCOB8
  strb r1, [r2] @ Byte 4 program value


  @ Launch the command
  ldr r2, =FTFE_FSTAT
  movs r3, #0x80
  strb r3, [r2]

  @ Read status - Wait for Finish
1:ldr r2, =FTFE_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b

2:drop
  bx lr

3:Fehler_Quit "Address has to be 8-aligned for writing flash !"
4:Fehler_Quit "Flash location cannot be written twice !"
5:Fehler_Quit "Cannot write into core !"


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 4kb großen Flashblock
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
1:ldr r2, =FTFE_FSTAT
  ldrb r3, [r2]
  movs r2, #CCIF
  ands r2, r3
  beq 1b

  @ Check for Flash errors
  movs r2, #ACCERR|FPVIOL
  ands r2, r3
  beq 1f

    @ Clear old errors if any
    ldr r2, =FTFE_FSTAT
    movs r3, #0x30
    strb r3, [r2]

1:@ Give command to erase Flash sector
  ldr r2, =FTFE_FCCOB0
  movs r3, #0x09 @ Erase Flash Sector Command
  strb r3, [r2]

  ldr r2, =FTFE_FCCOB3
  strb r0, [r2] @ Flash address [7:0]

  lsrs r0, #8
  ldr r2, =FTFE_FCCOB2
  strb r0, [r2] @ Flash address [15:8]

  lsrs r0, #8
  ldr r2, =FTFE_FCCOB1
  strb r0, [r2] @ Flash address [23:16]

  @ Launch the command
  ldr r2, =FTFE_FSTAT
  movs r3, #0x80
  strb r3, [r2]

  @ Read status - Wait for Finish
1:ldr r2, =FTFE_FSTAT
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
