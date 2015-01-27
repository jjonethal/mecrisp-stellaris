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

@ Input routine Query - with Unicode support.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cexpect" @ ( cstr-addr maxlength ) Collecting your keystrokes into a counted string !
@ -----------------------------------------------------------------------------
  push {lr}
  ldr r0, [psp]  @ Fetch address
  push {r0}
  adds r0, #1    @ Add one to skip length byte for accept area
  str r0, [psp]
  bl accept
  pop {r0}
  strb tos, [r0] @ Store accepted length into length byte of counted string
  drop
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "accept" @ ( c-addr maxlength -- length ) Collecting your keystrokes !
accept: @ Nimmt einen String entgegen und legt ihn in einen Puffer.
@ -----------------------------------------------------------------------------
        push    {lr}

        @ Registers:
        @ r0: Tastendruck      The pressed key
        @ r1: Pufferzeiger     Buffer pointer
        @ r2: Pufferfüllstand  Buffer fill gauge
        @ r3: Helferlein       Temporary
        @ tos:Längengrenze     Maximum length

        ldm psp!, {r1}          @ Pufferadresse holen                 Fetch buffer address
        subs r1, #1             @ Einen abziehen, weil die Routine bislang eigentlich abgezählte Strings erwartet hat.
        movs r2, #0             @ Momentaner Pufferfüllstand Null     Currently zero characters typed

1:      @ Queryschleife  Collcting loop
        bl key              @ Tastendruck holen  Fetch keypress
        popda r0

        cmp     r0, #127          @ Delete
        beq     6f                @ Should do the same as Backspace

        cmp     r0, #32           @ ASCII 0-31 sind Steuerzeichen, 32 ist Space. Die Steuerzeichen müssten einzeln behandelt werden.
        bhs     2f                @ Space wird hier einfach so mit aufgenommen.
        
        @ Steuerzeichen bearbeiten.
        @ Handle control characters below ascii 32 = space here.
        cmp     r0, #9            @ TAB ?
        beq     5f                @ Jump to replace TAB with space and include as normal character.

        cmp     r0, #10           @ Bei Enter sind wir fertig - LF  Finish with LF
        beq     3f
        cmp     r0, #13           @ Bei Enter sind wir fertig - CR  Finish with CR
        beq     3f

        cmp     r0, #8            @ Backspace
        bne     1b                @ Alle anderen Steuerzeichen ignorieren  Ignore all other control characters

6:        cmp     r2, #0            @ Null Zeichen im Puffer ? Dann ist nichts zu löschen da.
          beq     1b                @ Zero characters in buffer ? Then we cannot delete one.

          bl dotgaensefuesschen  @ Clear a character visually. Emit sequence to delete one character in terminal.
          .byte 3, 8, 32, 8  @ Cursor einen Schritt zurück. Mit Leerzeichen überschreiben. Nochmal zurück.
                             @ Step back cursor, overwrite with space, step back cursor again.

/*
  @ Ohne Unicode: Simply decrement count if one-byte-per-character is used.
        @ Tatsächlich ein Zeichen löschen. Noch ohne Unicode-Unterstützung.
        subs r2, #1                @ Ein Zeichen weniger im Puffer
*/

  @ Mit Unicode:
  
      @ Unicode-Zeichen sind so aufgebaut:
      @ 11xx xxxx,  10xx xxxx,  10xx xxxx......
      @ Wenn das letzte Zeichen also vorne ein 10 hat,
      @ muss ich so lange weiterlöschen, bis ich eins mit 11 vorne erwische.
      @ Prüfe natürlich immer, ob der Puffer vielleicht schon leer ist. Ausgetrickst !

      @ Remove character from buffer and watch for Unicode !
      @ Unicode: Maybe I have to remove more than one byte from buffer.
      @ Unicode-Characters have this format:
      @ 11xx xxxx,  10xx xxxx,  10xx xxxx......
      @ If the last character has 10... then I have to delete until i reach a character that has 11....
      @ Always check if buffer may be already empty !

4:    cmp     r2, #0            @ Null Zeichen im Puffer ? Dann ist nichts zu löschen da.
      beq     1b                @ Anything available to be deleted ?

      @ Hole das letzte Zeichen und schneide es ab.
      @ Fetch character from the end and cut it off.
      ldrb    r0, [r1, r2]      @ Letztes Zeichen im Puffer holen
      subs    r2, #1            @  und abschneiden

      @ Teste das Zeichen auf Unicode, oberstes Bit gesetzt ?
      @ Check character for Unicode, is MSB set ?
      @ tst r0, 0x80
      movs r3, #0x80
      ands r3, r0
      beq 1b @ Wenn nein, dann war das ein normales Zeichen und ich bin schon fertig.
             @ If not, then this has been a normal character and my task is finished.

      @ Ansonsten könnten noch mehr Unicode-Zeichen folgen.
      @ Zeichen das erste Byte eines Unicode-Zeichens ?
      @ Else I have to remove more bytes of this single Unicode character.
      @ Have I reached the first byte of this particular Unicode character yet ?
      @ tst r0, 0x40
      movs r3, #0x40
      ands r3, r0
      beq 4b @ Wenn nein, lösche ein weiteres Zeichen. No ? Delete one more byte.
      b 1b   @ Wenn ja, fertig. Dann habe ich soeben das erste Byte eines Unicode-Zeichens entfernt.  Yes ? Finished deleting.


5:      @ Replace TAB with space:
        movs r0, #32       

2:      @ Normale Zeichen annehmen
        @ Add a character to buffer if there is space left and echo it back.
        cmp     r2, tos              @ Ist der Puffer voll ?  Check buffer fill level.
        bhs     1b                   @ Keine weiteren Zeichen mehr annehmen.  No more characters if buffer is full !

        pushda r0
        bl emit                   @ Zeichen ausgeben
        adds    r2, #1            @ Pufferfüllstand erhöhen
        strb    r0, [r1, r2]      @ Zeichen in Puffer speichern
        b       1b

3:      @ Return has been pressed: Store string length, print space and leave.
        movs tos, r2              @ Give back accepted length
        bl space                  @ Statt des Zeilenumbruches ein Leerzeichen ausgeben
        pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_0, "tib" @ ( -- addr )
@ -----------------------------------------------------------------------------
tib:
  pushdatos
  ldr tos, =Eingabepuffer
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, ">in" @ ( -- addr )
  CoreVariable Pufferstand
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =Pufferstand
  bx lr
  .word 0

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_2variable, "current-source" @ ( -- addr )
  DoubleCoreVariable current_source
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =current_source
  bx lr
  .word 0              @ Empty TIB for default
  .word Eingabepuffer


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "setsource" @ ( c-addr len -- )
setsource:
@ -----------------------------------------------------------------------------
  ldr r0, =current_source
  ldm psp!, {r1}
  str tos, [r0]
  str r1, [r0, #4]
  drop
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "source" @ ( c-addr len -- )
source:
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =current_source

  subs psp, #4        @ Opcodes for 2@
  ldr r0, [tos, #4]
  str r0, [psp]
  ldr tos, [tos]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "query" @ Collecting your keystrokes into TIB ! Forth at your fingertips :-)
query: @ ( -- ) Nimmt einen String in den Eingabepuffer auf
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}

  ldr r0, =Pufferstand @ Aktueller Offset in den Eingabepuffer  Zero characters consumed yet
  movs r1, #0
  str r1, [r0]

  bl tib
  dup
  pushdaconst Maximaleeingabe
  bl accept
  bl setsource
  
  pop {r0, r1, r2, r3, pc}
