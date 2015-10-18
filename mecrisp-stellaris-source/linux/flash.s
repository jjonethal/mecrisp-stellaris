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

@ Simply store, as everything is in RAM on this target.

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

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3f  
  
  str r1, [r0]
  
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

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3f  
  
  strh r1, [r0]
  
  bx lr
 
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

  @ Ist die gewünschte Stelle im Flash-Dictionary ? Außerhalb des Forth-Kerns ?
  ldr r3, =Kernschutzadresse
  cmp r0, r3
  blo 3f
  
  strb r1, [r0]  
  
  bx lr
