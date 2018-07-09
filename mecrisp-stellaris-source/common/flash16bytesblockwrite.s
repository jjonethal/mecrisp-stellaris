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

@ Emulation for hflash! to circumvent problems with 16-Byte-ECC Flash
@ 16-Bit Flash writes are collected here to be written later as 16 Byte blocks

@ Einfügen im Hauptteil:  
@ .equ Sammelstellen, 32 @ 32 * (8 + 4) = 384 Bytes
@ ramallot Sammeltabelle, Sammelstellen * 12 @ Buffer 32 blocks of 8 bytes each for ECC constrained Flash write

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "initflash" @ Zu Beginn und in Quit !
initflash: @ ( -- ) Löscht alle Einträge in der Sammeldatei
                     @ Clear the table at the beginning and in quit
@ -----------------------------------------------------------------------------
  ldr r0, =Sammeltabelle
  ldr r1, =20 * Sammelstellen
  movs r2, #0

1:strb r2, [r0]
  adds r0, #1
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

1:pushdatos
  ldr tos, [r0]
  push {r0, r1}
  write "Adresse: "
  pop {r0, r1}
  bl hexdot

  push {r0, r1}
  write "Inhalt: "
  pop {r0, r1}

  pushdatos
  ldr tos, [r0, #4]
  bl hexdot

  pushdatos
  ldr tos, [r0, #8]
  bl hexdot

  pushdatos
  ldr tos, [r0, #12]
  bl hexdot

  pushdatos
  ldr tos, [r0, #16]
  bl hexdot
  
  push {r0, r1}
  writeln " >"
  pop {r0, r1} 

  adds r0, #20
  subs r1, #1
  bne 1b

  pop {pc}
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" @ Übernimmt die Rolle des großen hflash! :-)
h_flashkomma: @ ( x addr -- ) Fügt einen Eintrag in die Tabelle ein und brennt Päärchen.
              @ Emulates hflash! - collects values in table and writes completed pairs.
@ -----------------------------------------------------------------------------
  @ Idee: Prüfe, ob der 16-Byte-Block gerade in der Tabelle ist.
  @ Wenn ja: Einfügen, und falls es der 8. Schreibzugriff ist, weiterleiten.
  @ Wenn nein: Neuen 16-Byte-Block eröffnen und mit $FF füllen - Achtung, Tabellenüberlauf !

  @ Tabellenaufbau:
  @ Adresse, auf 16 gerade, mit der Zahl der bereits geschriebenen Stellen in den Low-Bits.
  @ 16 Bytes $FF bzw. die geschriebenen Stellen.

  push {r4, r5, lr}

  @ r0:    @ Tabelleneintragsstartadresse
  @ r1:    @ Manchmal Zähler fürs durchgucken der Tabelle
  popda r2 @ Adresse
  @ TOS:   @ Inhalt

  @ Prüfe, ob die Adresse gerade ist
  lsrs r0, r2, #1
  bcc 1f
    Fehler_Quit "hflash! needs even addresses."
1:

  @ Check if address is outside of Forth core
  ldr r3, =Kernschutzadresse
  cmp r2, r3
  bhs 2f

  Fehler_Quit "Cannot write into core !"
2:

  @ Suche nach einem Eintrag, der die Adresse ohne $F trägt !
  @ Search if the 16-Byte truncated address is already buffered in the table !

  lsrs r3, r2, #4 @ Prepare address for crawling by removing low bits

  ldr r0, =Sammeltabelle
  movs r1, #Sammelstellen

2:ldr r4, [r0]
  lsrs r4, #4 @ Prepare address by removing low bits

  cmp r4, r3 @ Ist das passende Päärchen gefunden ?
  beq.n hflashstoreemulation_gefunden @ Found the pair ?

  @ Ansonsten weitersuchen:
  @ Continue searching the table
  adds r0, #20
  subs r1, #1
  bne 2b

  @ Nicht gefunden: Suche eine leere Stelle in der Tabelle !
  @ Not found. Search for an empty place in table to fill this request in

  ldr r0, =Sammeltabelle
  movs r1, #Sammelstellen

3:ldr r4, [r0]
  cmp r4, #0
  @ Ist eine leere Stelle aufgetaucht ? Is this table place empty ?
  beq.n hflashstoreemulation_leerestelle

  @ Ansonsten weitersuchen:
  @ Continue searching the table
  adds r0, #20
  subs r1, #1
  bne 3b

  Fehler_Quit "Too many scattered Flash writes."

hflashstoreemulation_leerestelle:
  @writeln "Leerstelle präparieren"
  @ r0 zeigt gerade auf die Stelle, wo ich meinen Wunsch einfügen kann:
  @ r0 is pointer into an empty table place to fill in now:

  @ Set table entry properly
  lsls r3, #4  @ Address has just been shifted right before
  str r3, [r0] @ Address of new block

  subs r1, r1, #1 @ Prepare constant -1
  str r1, [r0, #4]
  str r1, [r0, #8]
  str r1, [r0, #12]
  str r1, [r0, #16]

hflashstoreemulation_gefunden: @ Found !
@  writeln "Einfügen"
  @ r0 zeigt auf den passenden Tabelleneintrag.
  @ Zieladresse in r2, Inhalt in TOS.
  @ r1 wird nicht mehr benötigt.

  @ Insert the new entry into the table
  @ Prepare low bits of address as offset into table:
  movs r1, #15
  ands r1, r2
  adds r1, #4 @ So skip table entry header
  strh tos, [r0, r1]  @ Store desired value into table
  drop

  @ Increment number of stores to this table
  ldr r1, [r0] @ Fetch old count
  adds r1, #1  @ Increment count of writes
  str r1, [r0] @ Store new count

  @ Enough writes to fill a 16 byte block ?
  movs r2, #15
  ands r1, r2

@  pushda r1
@  bl hexdot  

  cmp r1, #8 @ Is this the eigth write to this table ?
  bne.n hflashstoreemulation_fertig

    @ A 16 Byte block is finished ! Let's write !
    bl flushblock
    bl hexflashstore

hflashstoreemulation_fertig:
  pop {r4, r5, pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flushflash" @ Flushes all remaining table entries
flushflash:
@ -----------------------------------------------------------------------------
  push {lr}

  ldr r0, =Sammeltabelle
  movs r1, #Sammelstellen

2:ldr r2, [r0] @ Does this table entry contain something ?
  cmp r2, #0
  beq 3f
    bl flushblock
    bl hexflashstore

3:adds r0, #20
  subs r1, #1
  bne 2b

  pop {pc}

@ -----------------------------------------------------------------------------
flushblock: @ Put a table entry which address is in r0 on data stack for later 16flash!
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, [r0, #4]
  pushdatos
  ldr tos, [r0, #8]
  pushdatos
  ldr tos, [r0, #12]
  pushdatos
  ldr tos, [r0, #16]

  pushdatos             @ Place address on stack
  movs tos, #15
  mvns tos, tos
  ldr r2, [r0] @ Load the address of the table entry
  ands tos, r2 @ Cut off the lowest four bits that contain the write count

  movs r2, #0  @ Clear table entry
  str r2, [r0] 
  bx lr
