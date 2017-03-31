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

@ Schreiben und Löschen des Flash-Speichers im Stellaris.

@ In diesem Chip gibt es nur 32-aligned-Schreibzugriffe, die aber dafür beliebig 1->0 setzen können.
@ Auch mehrere Schreibzugriffe auf eine Word-Stelle sind damit möglich.
@ Deshalb laufen all die kleineren Schreibzugriffe über den 32-Bit-Zugriff.
@ Dies ist aber sehr speziell und muss für andere Chips sicherlich ganz neu geschrieben werden.

@ Write and Erase Flash in TM4C1294.
@ Porting: Rewrite this ! You need hflash! and - as far as possible - cflash!

.equ FLASH_FMA, 0x400FD000
.equ FLASH_FMD, 0x400FD004
.equ FLASH_FMC, 0x400FD008

.equ FLASH_FMC2, 0x400FD020
.equ FLASHCONF,  0x400FDFC8

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flash!" @ ( x Addr -- )
  @ Schreibt an die auf 4 gerade Adresse in den Flash.
@ -----------------------------------------------------------------------------
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


flashkomma_innen:
  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3f

  @ Alles paletti. Schreibe tatsächlich !
  ldr r2, =FLASH_FMD @ 1. Write source data to the FMD register.
  str r1, [r2]

  ldr r2, =FLASH_FMA @ 2. Write the target address to the FMA register.
  str r0, [r2]

  ldr r2, =FLASH_FMC @ 3. Write the Flash memory write key and the WRITE bit (a value of 0xA442.0001) to the FMC register.
  ldr r3, =0xA4420001
  str r3, [r2]

1:ldr r3, [r2]       @ 4. Poll the FMC register until the WRITE bit is cleared.
  ands r3, #1
  cmp r3, #0
  bne 1b

2:bx lr

3:Fehler_Quit "Wrong address or data for writing flash !"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" @ ( x Addr -- )
  @ Schreibt an die auf 2 gerade Adresse in den Flash.
h_flashkomma:
@ -----------------------------------------------------------------------------
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ldr r3, =0xFFFF
  ands r1, r3  @ High-Halfword der Daten wegmaskieren
  cmp r1, r3
  beq 2b

  @ Prüfe die Adresse: Sie muss auf 2 gerade sein:
  ands r2, r0, #1
  cmp r2, #0
  bne 3b

  @ Ist an der gewünschten Stelle -1 im Speicher ? Muss noch ersetzt werden durch eine Routine, die prüft, ob nur 1->0 Wechsel auftreten.
  ldrh r2, [r0]
  cmp r2, r3
  bne 3b

h_flashkomma_innen:
  @ Alles okay, alle Proben bestanden. Kann beginnen, zu schreiben.
  @ Ist die Adresse auf 4 gerade ?
  ands r2, r0, #2
  cmp r2, #0
  beq.n hflash_gerade

  @ hflash! ungerade:
  @ Muss an der auf 4 geraden Adresse davor ein Word holen.
  subs r0, #2
  ldrh r2, [r0]
  lsls r1, #16  @ Die Daten hochschieben
  orrs r1, r2 @ Den Inhalt zu den gewünschten Daten hinzuverodern
  @ Fertig. Habe die Daten für den auf 4 geraden Zugriff fertig.
  b.n flashkomma_innen

  @ hflash! gerade:
hflash_gerade:
  adds r2, r0, #2
  ldrh r3, [r2]
  lsls r3, #16
  orrs r1, r3 @ Den Inhalt zu den gewünschten Daten hinzuverodern
  @ Fertig. Habe die Daten für den auf 4 geraden Zugriff fertig.
  b.n flashkomma_innen


 @ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cflash!" @ ( x Addr -- )
  @ Schreibt ein einzelnes Byte in den Flash.
c_flashkomma:
@ -----------------------------------------------------------------------------
  popda r0 @ Adresse
  popda r1 @ Inhalt.

  @ Prüfe Inhalt. Schreibe nur, wenn es NICHT -1 ist.
  ands r1, #0xFF @ Alles Unwichtige von den Daten wegmaskieren
  cmp  r1, #0xFF
  beq 2b

  @ Ist an der gewünschten Stelle -1 im Speicher ? Muss noch ersetzt werden durch eine Routine, die prüft, ob nur 1->0 Wechsel auftreten.
  ldrb r2, [r0]
  cmp r2, #0xFF
  bne 3b

  @ Alles okay, alle Proben bestanden. Kann beginnen, zu schreiben.
  @ Ist die Adresse auf 2 gerade ?
  ands r2, r0, #1
  cmp r2, #0
  beq.n cflash_gerade

  @ cflash! ungerade:
  @ Muss an der geraden Adresse davor ein Word holen.
  subs r0, #1
  ldrb r2, [r0]
  lsls r1, #8  @ Die Daten hochschieben
  orrs r1, r2 @ Den Inhalt zu den gewünschten Daten hinzuverodern
  @ Fertig. Habe die Daten für den auf 4 geraden Zugriff fertig.
  b.n h_flashkomma_innen

  @ cflash! gerade:
cflash_gerade:
  adds r2, r0, #1
  ldrb r3, [r2]
  lsls r3, #8
  orrs r1, r3 @ Den Inhalt zu den gewünschten Daten hinzuverodern
  @ Fertig. Habe die Daten für den auf 4 geraden Zugriff fertig.
  b.n h_flashkomma_innen


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashpageerase" @ ( Addr -- )
  @ Löscht einen 16kb großen Flashblock
flashpageerase:
@ -----------------------------------------------------------------------------
  @ Lösche gleich und ohne viel Federlesen.
  push {r0, r1, r2, r3}
  popda r0 @ Adresse zum Löschen holen Address to erase

  movw r3, 0x3FFF @ Align to begin of 16 kb Flash block
  bics r0, r3

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 2f

  ldr r2, =FLASH_FMA @ 1. Write the page address to the FMA register.
  str r0, [r2]

  ldr r2, =FLASH_FMC @ 2. Write the Flash memory write key and the ERASE bit (a value of 0xA442.0002) to the FMC register.
  ldr r3, =0xA4420002
  str r3, [r2]

1:ldr r3, [r2]       @ 3. Poll the FMC register until the ERASE bit is cleared
  ands r3, #2
  cmp r3, #0
  bne 1b

  pop {r0, r1, r2, r3}
  bx lr

2:Fehler_Quit "Wrong address for erasing flash !"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ ( -- )
  @ Löscht den gesamten Inhalt des Flashdictionaries.
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
