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
  Wortbirne Flag_inline|Flag_allocator, "@" @ ( 32-addr -- x )
                              @ Loads the cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldr tos, [tos]
  bx lr

allocator_4fetch:
    pushdaconstw 0x6800 @ ldr r0, [r0, #0] Opcode

allocator_4fetch_anderer_opcode:
    push {lr}
    bl expect_one_element

    @ Sollte TOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_tos]
    cmp r3, #constant
    bne 2f
      ldr r3, [r0, #offset_constant_tos]

      @ Die fünf Bits, die in den LDR-Opcode passen, werden nun direkt dort eingepflegt.
      movs r1, 0x7C @ %1111100
      ands r1, r3   @ Bits herausholen
      lsls r1, #4
      orrs tos, r1

      movs r1, 0x7C @ %1111100
      bics r3, r1

      bl generiere_adresskonstante

2:  @ r3 sagt nun in jedem Fall, in welchem Register die Adresse zum Laden bereitliegt.
    lsls r3, #3
    orrs tos, r3

    @ Elementkopien umschiffen - das Ladeergebnis benötigt auf jeden Fall einen frischen Register:
    bl tos_registerwechsel

    orrs tos, r3  @ Der Endzielregister ist gar nicht geschoben
    bl hkomma
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "!" @ ( x 32-addr -- )
@ Given a value 'x' and a cell-aligned address 'addr', stores 'x' to memory at 'addr', consuming both.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  str r0, [tos]      @ Popping both saves a cycle.
  movs tos, r1
  bx lr

allocator_4store:
    pushdaconstw 0x6000 @ str r0, [r0, #0] Opcode

allocator_4store_anderer_opcode:
    push {lr}
    bl expect_two_elements

    @ Sollte TOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_tos]
    cmp r3, #constant
    bne 2f
      ldr r3, [r0, #offset_constant_tos]

      @ Die fünf Bits, die in den STR-Opcode passen, werden nun direkt dort eingepflegt.
      movs r1, 0x7C @ %1111100
      ands r1, r3   @ Bits herausholen
      lsls r1, #4
      orrs tos, r1

      movs r1, 0x7C @ %1111100
      bics r3, r1

      bl generiere_adresskonstante
      str r3, [r0, #offset_state_tos]

2:  @ r3 sagt nun in jedem Fall, in welchem Register die Adresse zum Schreiben bereitliegt.
    lsls r3, #3
    orrs tos, r3


    @ Sollte NOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_nos]
    cmp r3, #constant
    bne 3f
      ldr r3, [r0, #offset_constant_nos]
      bl generiere_konstante
3:  @ r3 sagt nun in jedem Fall, in welchem Register der Inhalt zum Schreiben bereitliegt.
    orrs tos, r3
    bl hkomma

    bl eliminiere_tos
    bl eliminiere_tos
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "+!" @ ( x 32-addr -- )
                               @ Adds 'x' to the memory cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos]     @ Load the current cell value
  adds r2, r0        @ Do the add
  str  r2, [tos]     @ Store it back
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_4fetch
      bl rot_allocator
      bl plus_allocator
      bl swap_allocator
      bl allocator_4store
    pop {pc}

  @  Idea behind this snipplet code: Try to compile this through the allocator.
  @
  @  : +! ( x addr )
  @    dup ( x addr addr )
  @    @ ( x addr inhalt )
  @    rot ( addr inhalt x )
  @    + ( addr inhalt* )
  @    swap ( inhalt* addr )
  @    !
  @  ;

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "h@" @ ( 16-addr -- x )
                              @ Loads the half-word at 'addr'.
@ -----------------------------------------------------------------------------
  ldrh tos, [tos]
  bx lr

allocator_2fetch:
    push {lr}
    bl expect_one_element
    pushdaconstw 0x8800 @ ldrh r0, [r0, #0] Opcode

    @ Sollte TOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_tos]
    cmp r3, #constant
    bne 2f
      ldr r3, [r0, #offset_constant_tos]

      @ Die fünf Bits, die in den LDRH-Opcode passen, werden nun direkt dort eingepflegt.
      movs r1, 0x3E @ %1111100
      ands r1, r3   @ Bits herausholen
      lsls r1, #5
      orrs tos, r1

      movs r1, 0x3E @ %1111100
      bics r3, r1

      bl generiere_adresskonstante

2:  @ r3 sagt nun in jedem Fall, in welchem Register die Adresse zum Laden bereitliegt.
    lsls r3, #3
    orrs tos, r3

    @ Elementkopien umschiffen - das Ladeergebnis benötigt auf jeden Fall einen frischen Register:
    bl tos_registerwechsel

    orrs tos, r3  @ Der Endzielregister ist gar nicht geschoben
    bl hkomma
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "h!" @ ( x 16-addr -- )
@ Given a value 'x' and an 16-bit-aligned address 'addr', stores 'x' to memory at 'addr', consuming both.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  strh r0, [tos]     @ Popping both saves a cycle.
  movs tos, r1
  bx lr

allocator_2store:
    push {lr}
    bl expect_two_elements
    pushdaconstw 0x8000 @ strh r0, [r0, #0] Opcode

    @ Sollte TOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_tos]
    cmp r3, #constant
    bne 2f
      ldr r3, [r0, #offset_constant_tos]

      @ Die fünf Bits, die in den STRH-Opcode passen, werden nun direkt dort eingepflegt.
      movs r1, 0x3E @ %1111100
      ands r1, r3   @ Bits herausholen
      lsls r1, #5
      orrs tos, r1

      movs r1, 0x3E @ %1111100
      bics r3, r1

      bl generiere_adresskonstante
      str r3, [r0, #offset_state_tos]

2:  @ r3 sagt nun in jedem Fall, in welchem Register die Adresse zum Schreiben bereitliegt.
    lsls r3, #3
    orrs tos, r3


    @ Sollte NOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_nos]
    cmp r3, #constant
    bne 3f
      ldr r3, [r0, #offset_constant_nos]
      bl generiere_konstante
3:  @ r3 sagt nun in jedem Fall, in welchem Register der Inhalt zum Schreiben bereitliegt.
    orrs tos, r3
    bl hkomma

    bl eliminiere_tos
    bl eliminiere_tos
    pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "h+!" @ ( x 16-addr -- )
                                @ Adds 'x' to the memory cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos]     @ Load the current cell value
  adds r2, r0        @ Do the add
  strh r2, [tos]     @ Store it back
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_2fetch
      bl rot_allocator
      bl plus_allocator
      bl swap_allocator
      bl allocator_2store
    pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "c@" @ ( 8-addr -- x )
                              @ Loads the byte at 'addr'.
@ -----------------------------------------------------------------------------
  ldrb tos, [tos]
  bx lr

allocator_1fetch:
    push {lr}
    bl expect_one_element
    pushdaconstw 0x7800 @ ldrb r0, [r0, #0] Opcode

    @ Sollte TOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_tos]
    cmp r3, #constant
    bne 2f
      ldr r3, [r0, #offset_constant_tos]

      @ Die fünf Bits, die in den LDRB-Opcode passen, werden nun direkt dort eingepflegt.
      movs r1, 0x1F @ %111110
      ands r1, r3   @ Bits herausholen
      lsls r1, #6
      orrs tos, r1

      movs r1, 0x1F @ %111110
      bics r3, r1

      bl generiere_adresskonstante

2:  @ r3 sagt nun in jedem Fall, in welchem Register die Adresse zum Laden bereitliegt.
    lsls r3, #3
    orrs tos, r3

    @ Elementkopien umschiffen - das Ladeergebnis benötigt auf jeden Fall einen frischen Register:
    bl tos_registerwechsel

    orrs tos, r3  @ Der Endzielregister ist gar nicht geschoben
    bl hkomma
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "c!" @ ( x 8-addr -- )
@ Given a value 'x' and an 8-bit-aligned address 'addr', stores 'x' to memory at 'addr', consuming both.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  strb r0, [tos]     @ Popping both saves a cycle.
  movs tos, r1
  bx lr

allocator_1store:
    push {lr}
    bl expect_two_elements
    pushdaconstw 0x7000 @ strb r0, [r0, #0] Opcode

    @ Sollte TOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_tos]
    cmp r3, #constant
    bne 2f
      ldr r3, [r0, #offset_constant_tos]

      @ Die fünf Bits, die in den STRB-Opcode passen, werden nun direkt dort eingepflegt.
      movs r1, 0x1F @ %111110
      ands r1, r3   @ Bits herausholen
      lsls r1, #6
      orrs tos, r1

      movs r1, 0x1F @ %111110
      bics r3, r1

      bl generiere_adresskonstante
      str r3, [r0, #offset_state_tos]

2:  @ r3 sagt nun in jedem Fall, in welchem Register die Adresse zum Schreiben bereitliegt.
    lsls r3, #3
    orrs tos, r3


    @ Sollte NOS gerade eine Konstante sein, generiere sie so gut es geht.
    ldr r3, [r0, #offset_state_nos]
    cmp r3, #constant
    bne 3f
      ldr r3, [r0, #offset_constant_nos]
      bl generiere_konstante
3:  @ r3 sagt nun in jedem Fall, in welchem Register der Inhalt zum Schreiben bereitliegt.
    orrs tos, r3
    bl hkomma

    bl eliminiere_tos
    bl eliminiere_tos
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "c+!" @ ( x 8-addr -- )
                               @ Adds 'x' to the memory cell at 'addr'.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos]     @ Load the current cell value
  adds r2, r0        @ Do the add
  strb r2, [tos]     @ Store it back
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_1fetch
      bl rot_allocator
      bl plus_allocator
      bl swap_allocator
      bl allocator_1store
    pop {pc}

  .ltorg

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "bis!" @ ( x 32-addr -- )  Set bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos] @ Alten Inhalt laden
  orrs r2, r0    @ Hinzuverodern
  str  r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_4fetch
      bl rot_allocator
      pushdaconstw 0x4300 @ orrs r0, r0      Opcode
      bl alloc_kommutativ
      bl swap_allocator
      bl allocator_4store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "bic!" @ ( x 32-addr -- )  Clear bits
  @ Löscht die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos] @ Alten Inhalt laden
  bics r2, r0    @ Bits löschen
  str  r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_4fetch
      bl rot_allocator
      pushdaconstw 0x4380 @ bics r0, r0      Opcode
      bl alloc_unkommutativ
      bl swap_allocator
      bl allocator_4store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "xor!" @ ( x 32-addr -- )  Toggle bits
  @ Wechselt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldr  r2, [tos] @ Alten Inhalt laden
  eors r2, r0    @ Bits umkehren
  str  r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_4fetch
      bl rot_allocator
      pushdaconstw 0x4040 @ eors r0, r0      Opcode
      bl alloc_kommutativ
      bl swap_allocator
      bl allocator_4store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "bit@" @ ( x 32-addr -- Flag )  Check bits
  @ Prüft, ob Bits in der Speicherstelle gesetzt sind
@ -----------------------------------------------------------------------------
  ldm psp!, {r0} @ Bitmaske holen
  ldr tos, [tos] @ Speicherinhalt holen
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

    push {lr}
      bl expect_two_elements
      bl allocator_4fetch
      pushdaconstw 0x4000 @ ands r0, r0 Opcode
      bl alloc_kommutativ
      bl allocator_unequal_zero
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "hbis!" @ ( x 16-addr -- )  Set bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos] @ Alten Inhalt laden
  orrs r2, r0    @ Hinzuverodern
  strh r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_2fetch
      bl rot_allocator
      pushdaconstw 0x4300 @ orrs r0, r0      Opcode
      bl alloc_kommutativ
      bl swap_allocator
      bl allocator_2store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "hbic!" @ ( x 16-addr -- )  Clear bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos] @ Alten Inhalt laden
  bics r2, r0    @ Hinzuverodern
  strh r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_2fetch
      bl rot_allocator
      pushdaconstw 0x4380 @ bics r0, r0      Opcode
      bl alloc_unkommutativ
      bl swap_allocator
      bl allocator_2store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "hxor!" @ ( x 16-addr -- )  Toggle bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrh r2, [tos] @ Alten Inhalt laden
  eors r2, r0    @ Hinzuverodern
  strh r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_2fetch
      bl rot_allocator
      pushdaconstw 0x4040 @ eors r0, r0      Opcode
      bl alloc_kommutativ
      bl swap_allocator
      bl allocator_2store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "hbit@" @ ( x 16-addr -- Flag )  Check bits
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

    push {lr}
      bl expect_two_elements
      bl allocator_2fetch
      pushdaconstw 0x4000 @ ands r0, r0 Opcode
      bl alloc_kommutativ
      bl allocator_unequal_zero
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "cbis!" @ ( x 8-addr -- )  Set bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos] @ Alten Inhalt laden
  orrs r2, r0    @ Hinzuverodern
  strb r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_1fetch
      bl rot_allocator
      pushdaconstw 0x4300 @ orrs r0, r0      Opcode
      bl alloc_kommutativ
      bl swap_allocator
      bl allocator_1store
    pop {pc}
@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "cbic!" @ ( x 8-addr -- )  Clear bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos] @ Alten Inhalt laden
  bics r2, r0    @ Hinzuverodern
  strb r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_1fetch
      bl rot_allocator
      pushdaconstw 0x4380 @ bics r0, r0      Opcode
      bl alloc_unkommutativ
      bl swap_allocator
      bl allocator_1store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "cxor!" @ ( x 8-addr -- )  Toggle bits
  @ Setzt die Bits in der Speicherstelle
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1} @ X is the new TOS after the store completes.
  ldrb r2, [tos] @ Alten Inhalt laden
  eors r2, r0     @ Hinzuverodern
  strb r2, [tos] @ Zurückschreiben
  movs tos, r1
  bx lr

    push {lr}
      bl expect_two_elements
      bl dup_allocator
      bl allocator_1fetch
      bl rot_allocator
      pushdaconstw 0x4040 @ eors r0, r0      Opcode
      bl alloc_kommutativ
      bl swap_allocator
      bl allocator_1store
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "cbit@" @ ( x 8-addr -- Flag )  Check bits
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

    push {lr}
      bl expect_two_elements
      bl allocator_1fetch
      pushdaconstw 0x4000 @ ands r0, r0 Opcode
      bl alloc_kommutativ
      bl allocator_unequal_zero
    pop {pc}

.ltorg
