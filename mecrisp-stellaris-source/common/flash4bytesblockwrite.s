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

@ Emulation for hflash!
@ 16-Bit Flash writes are collected here to be written later as 32-Bit accesses.

@ Einfügen im Hauptteil: ramallot Sammeltabelle, Sammelstellen * 6
@ .equ Sammelstellen, 32 @ 32 * 6 = 192 Bytes.
@ ramallot Sammeltabelle, Sammelstellen * 6 @ 16-Bit Flash write emulation collection buffer

@ -----------------------------------------------------------------------------
@  Wortbirne Flag_visible, "initflash" @ Zu Beginn und in Quit !
initflash: @ ( -- ) Löscht alle Einträge in der Sammeldatei
                     @ Clear the table at the beginning and in quit
@ -----------------------------------------------------------------------------
  ldr r0, =Sammeltabelle
  movs r1, # 3 * Sammelstellen
  movs r2, #0

1:strh r2, [r0]
  adds r0, #2
  subs r1, #1
  bne 1b

  bx lr

  .ifdef debug
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "stmalen" @ Nur zur Fehlersuche
sammeltabellemalen: @ ( -- ) Malt den Inhalt der Sammeltabelle
                    @ Write contents of collection table, for experiments only.
@ -----------------------------------------------------------------------------
  push {lr}

  ldr r0, =Sammeltabelle
  movs r1, #Sammelstellen

1:ldrh r2, [r0]
  ldrh r3, [r0, #2]
  lsls r3, #16
  orrs r2, r3

  push {r0, r1}
  pushda r2
  write "Adresse: "
  bl udot
  pop {r0, r1}

  ldrh r2, [r0, #4]

  push {r0, r1}
  pushda r2
  write "Inhalt: "
  bl udot
  writeln ""
  pop {r0, r1}

  adds r0, #6
  subs r1, #1
  bne 1b

  pop {pc}
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" @ Übernimmt die Rolle des großen hflash! :-)
h_flashkomma: @ ( x addr -- ) Fügt einen Eintrag in die Tabelle ein und brennt Päärchen.
              @ Emulates hflash! - collects values in table and writes completed pairs.
@ -----------------------------------------------------------------------------
  @ Idee: Prüfe, ob der Nachbar in der Tabelle ist. 
  @ Wenn ja: Zusammenfügen, als 32-Bit-Schreibzugriff weiterleiten, aus Tabelle löschen.
  @ Wenn nein: In Tabelle einfügen - Achtung, Tabellenüberlauf !

  push {r4, r5, lr}

  popda r2 @ Adresse
  @ TOS:   @ Inhalt

  @ Prüfe, ob die Adresse gerade ist
  lsrs r0, r2, #1
  bcc 1f
    Fehler_Quit "hflash! needs even addresses."
1:

  @ Wonach wird gesucht ?
  @ ...10 benötigt ...00 als Päärchen,
  @ ...00 benötigt ...10 als Päärchen.
  @ Dies ist ein Fall für eors !

  movs r3, #2 @ Calculate address of the other location in this pair
  eors r3, r2 @ Päärchenadresse bestimmen

  ldr r0, =Sammeltabelle
  movs r1, #Sammelstellen

2:ldrh r4, [r0]
  ldrh r5, [r0, #2]
  lsls r5, #16
  orrs r4, r5

  cmp r4, r3 @ Ist das passende Päärchen gefunden ?
  beq.n hflashstoreemulation_gefunden @ Found the pair ?

  @ Ansonsten weitersuchen:
  @ Continue searching the table
  adds r0, #6
  subs r1, #1
  bne 2b

  @ Nicht gefunden: Suche eine leere Stelle in der Tabelle !
  @ Not found. Search for an empty place in table to fill this request in

  ldr r0, =Sammeltabelle
  movs r1, #Sammelstellen

3:ldrh r4, [r0]
  ldrh r5, [r0, #2]
  lsls r5, #16
  orrs r4, r5

  @ Ist eine leere Stelle aufgetaucht ? Is this table place empty ?
  beq.n hflashstoreemulation_leerestelle

  @ Ansonsten weitersuchen:
  @ Continue searching the table
  adds r0, #6
  subs r1, #1
  bne 3b

  Fehler_Quit "Too many unpaired 16-bit Flash writes."

hflashstoreemulation_leerestelle:
  @ r0 zeigt gerade auf die Stelle, wo ich meinen Wunsch einfügen kann:
  @ r0 is pointer into an empty table place to fill in now:
  strh r2, [r0]
  lsrs r2, #16
  strh r2, [r0, #2]
  strh tos, [r0, #4]
  drop
  pop {r4, r5, pc}

hflashstoreemulation_gefunden: @ Found !
  @ r0 zeigt auf die Stelle, wo das passende Päärchen bereitliegt.
  @ Zieladresse in r2, Inhalt in TOS.
  @ r1 wird nicht mehr benötigt.

  @ r0 is pointer to the other in the pair.
  @ Target address in r2, value in TOS.
  @ r1 not used anymore.

  movs r1, #2
  ands r1, r2
  beq 4f

  @ Neuer Wert ist an der ungeraden=größeren Adresse.
  @ Current request is on 4-uneven address
  subs r2, #2
  ldrh r1, [r0, #4]
  lsls tos, #16
  b 5f

4:@ Neuer Wert ist an der geraden=kleineren Adresse.
  @ Current request is on 4-even address
  ldrh r1, [r0, #4]
  lsls r1, #16
  
5:orrs tos, r1 @ Or values together for one 32 bit value
  pushda r2 @ Adresse obendrauflegen  Put address on top

  @ Eintrag aus der Tabelle löschen
  @ Remove collection table entry
  movs r1, #0
  strh r1, [r0]
  strh r1, [r0, #2]
  strh r1, [r0, #4]

  bl flashkomma
  pop {r4, r5, pc}


@ -----------------------------------------------------------------------------
@ Am Anfang der Definition und in Smudge.
@ Check if table is empty - the align4, in smudge will handle the last entry.
@ This should never trigger, but just to be sure...
@ -----------------------------------------------------------------------------

@ -----------------------------------------------------------------------------
@  Wortbirne Flag_visible, "flushflash" @ Flushes all remaining table entries
flushflash:
@ -----------------------------------------------------------------------------

  ldr r0, =Sammeltabelle
  movs r1, # 3 * Sammelstellen

1:ldrh r2, [r0]
  cmp r2, #0
  beq 2f
    Fehler_Quit "Unpaired 16-bit Flash write."

2:adds r0, #2
  subs r1, #1
  bne 1b

  bx lr
