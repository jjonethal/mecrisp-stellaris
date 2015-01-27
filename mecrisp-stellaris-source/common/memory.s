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

@ Speicherzugriffe aller Art
@ Memory access


@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "move"  @ Move some bytes around. This can cope with overlapping memory areas.
move:  @ ( Quelladdr Zieladdr Byteanzahl -- ) ( Source Destination Count -- )
@------------------------------------------------------------------------------

  push {r0, r1, r2, lr}

  popda r1 @ Count
  popda r2 @ Destination address
  @ TOS:     Source address

  @ Count > 0 ?
  cmp r1, #0
  beq 3f @ Nothing to do if count is zero.

  @ Compare source and destination address to find out which direction to copy.
  cmp r2, tos
  beq 3f @ If source and destionation are the same, nothing to do.
  blo 2f

  subs tos, #1
  subs r2, #1

1:@ Source > Destination --> Backward move
  ldrb r0, [tos, r1]
  strb r0, [r2, r1]
  subs r1, #1
  bne 1b
  b 3f

2:@ Source < Destination --> Forward move
  ldrb r0, [tos]
  strb r0, [r2]
  adds tos, #1
  adds r2, #1
  subs r1, #1
  bne 2b

3:drop
  pop {r0, r1, r2, pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "fill"  @ Fill memory with given byte.
  @ ( Destination Count Filling -- )
@------------------------------------------------------------------------------
  @ 6.1.1540 FILL CORE ( c-addr u char -- ) If u is greater than zero, store char in each of u consecutive characters of memory beginning at c-addr. 

  popda r0 @ Filling byte
  popda r1 @ Count
  @ TOS      Destination

  cmp r1, #0
  beq 2f

1:subs r1, #1
  strb r0, [tos, r1]
  bne 1b

2:drop
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "@" @ ( 32-addr -- x )
                              @ Loads the cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldr tos, [tos]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "!" @ ( x 32-addr -- )
@ Given a value 'x' and a cell-aligned address 'addr', stores 'x' to memory at 'addr', consuming both.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  str r0, [tos]      @ Popping both saves a cycle.
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  str tos, [r0]
  bx lr

  @ For opcoding with two constants
  str r1, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "+!" @ ( x 32-addr -- )
                               @ Adds 'x' to the memory cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos]     @ Load the current cell value
  adds r2, r0        @ Do the add
  str  r2, [tos]     @ Store it back
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldr r2, [r0]
  adds r2, tos
  str r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldr r2, [r0]
  adds r2, r1
  str r2, [r0]
  bx lr


@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "h@" @ ( 16-addr -- x )
                              @ Loads the half-word at 'addr'.
@ -----------------------------------------------------------------------------
  ldrh tos, [tos]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "h!" @ ( x 16-addr -- )
@ Given a value 'x' and an 16-bit-aligned address 'addr', stores 'x' to memory at 'addr', consuming both.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  strh r0, [tos]     @ Popping both saves a cycle.
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  strh tos, [r0]
  bx lr

  @ For opcoding with two constants
  strh r1, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "h+!" @ ( x 16-addr -- )
                                @ Adds 'x' to the memory cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos]     @ Load the current cell value
  adds r2, r0        @ Do the add
  strh r2, [tos]     @ Store it back
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrh r2, [r0]
  adds r2, tos
  strh r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrh r2, [r0]
  adds r2, r1
  strh r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "c@" @ ( 8-addr -- x )
                              @ Loads the byte at 'addr'.
@ -----------------------------------------------------------------------------
  ldrb tos, [tos]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "c!" @ ( x 8-addr -- )
@ Given a value 'x' and an 8-bit-aligned address 'addr', stores 'x' to memory at 'addr', consuming both.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  strb r0, [tos]     @ Popping both saves a cycle.
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  strb tos, [r0]
  bx lr

  @ For opcoding with two constants
  strb r1, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "c+!" @ ( x 8-addr -- )
                               @ Adds 'x' to the memory cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos]     @ Load the current cell value
  adds r2, r0        @ Do the add
  strb r2, [tos]     @ Store it back
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrb r2, [r0]
  adds r2, tos
  strb r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrb r2, [r0]
  adds r2, r1
  strb r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "bis!" @ ( x 32-addr -- )  Set bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos] @ Alten Inhalt laden
  orrs r2, r0    @ Hinzuverodern
  str  r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldr  r2, [r0]
  orrs r2, tos
  str  r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldr  r2, [r0]
  orrs r2, r1
  str  r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "bic!" @ ( x 32-addr -- )  Clear bits
  @ Löscht die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos] @ Alten Inhalt laden
  bics r2, r0    @ Bits löschen
  str  r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldr  r2, [r0]
  bics r2, tos
  str  r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldr  r2, [r0]
  bics r2, r1
  str  r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "xor!" @ ( x 32-addr -- )  Toggle bits
  @ Wechselt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos] @ Alten Inhalt laden
  eors r2, r0    @ Bits umkehren
  str  r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldr  r2, [r0]
  eors r2, tos
  str  r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldr  r2, [r0]
  eors r2, r1
  str  r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Spezialfall, "bit@" @ ( x 32-addr -- Flag )  Check bits
  @ Prüft, ob Bits in der Speicherstelle gesetzt sind
@ -----------------------------------------------------------------------------
  ldm psp!, {r0} @ Bitmaske holen
  ldr tos, [tos] @ Speicherinhalt holen
struktur_bitfetch:
  ands tos, r0   @ Bleibt nach AND etwas über ?

  .ifdef m0core
  subs tos, #1
  sbcs tos, tos
  mvns tos, tos
  bx lr
  .else
  it ne
  movne tos, #-1 @ Bleibt etwas über, mache ein ordentliches true-Flag daraus.
  bx lr
  .endif

  @------------------------------------------------------------------------------
  @ Opcodable optimisations enter here.
  ldr r2, =0x6800 @ ldr r0, [r0, #0] Opcode

bitfetch_opcoding:
    push {lr}
    cmp r3, #1
    bne 2f

    @ Exactly one folding constant available
    @ Encode the address
    pushdaconst 0
    bl registerliteralkomma
    @ subs r3, #1 @ Not necessary

    pushda r2 @ ldr... r0, [r0, #0] Opcode
    bl hkomma
    b.n 3f

2:  @ Two or more folding constants available
    @ Fetch the Bitmask from the stack and write all folding constants left.
    ldmia psp!, {r1} @ NOS into r1
    subs r3, #1 @ One constant less to write
    bl konstantenschreiben @ Write all other constants in dictionary

    @ Address is now already in TOS. Generate fetch opcode:
    pushdaconst 0x0036
    orrs tos, r2 @ ldr... r6 [ r6 #0 ] Opcode
    bl hkomma

    @ Encode the bitmask into r0.
    pushda r1
    pushdaconst 0
    bl registerliteralkomma

3:  pushdatos
    ldr tos, =struktur_bitfetch
    bl inlinekomma

    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "hbis!" @ ( x 16-addr -- )  Set bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos] @ Alten Inhalt laden
  orrs r2, r0    @ Hinzuverodern
  strh r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrh r2, [r0]
  orrs r2, tos
  strh r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrh r2, [r0]
  orrs r2, r1
  strh r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "hbic!" @ ( x 16-addr -- )  Clear bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos] @ Alten Inhalt laden
  bics r2, r0    @ Hinzuverodern
  strh r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrh r2, [r0]
  bics r2, tos
  strh r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrh r2, [r0]
  bics r2, r1
  strh r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "hxor!" @ ( x 16-addr -- )  Toggle bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos] @ Alten Inhalt laden
  eors r2, r0    @ Hinzuverodern
  strh r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrh r2, [r0]
  eors r2, tos
  strh r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrh r2, [r0]
  eors r2, r1
  strh r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Spezialfall, "hbit@" @ ( x 16-addr -- Flag )  Check bits
  @ Prüft, ob Bits in der Speicherstelle gesetzt sind
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}  @ Bitmaske holen
  ldrh tos, [tos] @ Speicherinhalt holen
  ands tos, r0    @ Bleibt nach AND etwas über ?

  .ifdef m0core
  subs tos, #1
  sbcs tos, tos
  mvns tos, tos
  bx lr
  .else
  it ne
  movne tos, #-1 @ Bleibt etwas über, mache ein ordentliches true-Flag daraus.
  bx lr
  .endif

  @------------------------------------------------------------------------------
  @ Opcodable optimisations enter here.
  ldr r2, =0x8800 @ ldrh r0, [r0, #0] Opcode
  b.n bitfetch_opcoding

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "cbis!" @ ( x 8-addr -- )  Set bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos] @ Alten Inhalt laden
  orrs r2, r0    @ Hinzuverodern
  strb r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrb r2, [r0]
  orrs r2, tos
  strb r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrb r2, [r0]
  orrs r2, r1
  strb r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "cbic!" @ ( x 8-addr -- )  Clear bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos] @ Alten Inhalt laden
  bics r2, r0    @ Hinzuverodern
  strb r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrb r2, [r0]
  bics r2, tos
  strb r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrb r2, [r0]
  bics r2, r1
  strb r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Speicherschreiben, "cxor!" @ ( x 8-addr -- )  Toggle bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos] @ Alten Inhalt laden
  eors r2, r0     @ Hinzuverodern
  strb r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

  @ For opcoding with one constant
  ldrb r2, [r0]
  eors r2, tos
  strb r2, [r0]
  bx lr

  @ For opcoding with two constants
  ldrb r2, [r0]
  eors r2, r1
  strb r2, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Spezialfall, "cbit@" @ ( x 8-addr -- Flag )  Check bits
  @ Prüft, ob Bits in der Speicherstelle gesetzt sind
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}  @ Bitmaske holen
  ldrb tos, [tos] @ Speicherinhalt holen
  ands tos, r0    @ Bleibt nach AND etwas über ?

  .ifdef m0core
  subs tos, #1
  sbcs tos, tos
  mvns tos, tos
  bx lr
  .else
  it ne
  movne tos, #-1 @ Bleibt etwas über, mache ein ordentliches true-Flag daraus.
  bx lr
  .endif

  @------------------------------------------------------------------------------
  @ Opcodable optimisations enter here.
  ldr r2, =0x7800 @ ldrb r0, [r0, #0] Opcode
  b.n bitfetch_opcoding

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "cell+" @ ( x -- x+4 ) 
@ -----------------------------------------------------------------------------
  adds tos, #4
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "cells" @ ( x -- 4*x ) 
@ -----------------------------------------------------------------------------
  lsls tos, #2
  bx lr
