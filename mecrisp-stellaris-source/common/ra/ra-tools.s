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

@ Register allocator tools to work with the stack model.

@ -----------------------------------------------------------------------------
generiere_veraenderliche_konstante:
generiere_konstante:       @ Nimmt Konstante in r3 entgegen, generiert wenn nötig passende Opcodes
                           @ und gibt den Register in r3 zurück, in der sie daraufhin enthalten ist.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, lr}
  pushda r3 @ Die Konstante
  bl get_free_register @ Einen Register nehmen, der gerade nicht im RA angemeldet ist.
  pushda r3 @ Das ist jetzt der Register, wo sie hinein soll
  bl registerliteralkomma
  pop {r0, r1, r2, pc}

@ -----------------------------------------------------------------------------
generiere_adresskonstante: @ Gleiche Schnittstelle, doch bevorzugt in r0.
@ -----------------------------------------------------------------------------

  push {r0, r1, r2, lr}

  @ Probe, ob die Konstante in r0 bereitliegt
  ldr r1, [r0, #offset_state_r0]
  cmp r1, #constant
  bne 1f
    ldr r1, [r0, #offset_constant_r0]
    cmp r1, r3
    bne 1f
      movs r3, #0 @ Wenn ja, fein ! Register melden, Rücksprung.
      pop {r0, r1, r2, pc}
1:

  @ Ist r0 frei ?

  ldr r1, [r0, #offset_state_tos]
  cmp r1, #0
  beq r0_unfrei
  
  ldr r1, [r0, #offset_state_nos]
  cmp r1, #0
  beq r0_unfrei

  ldr r1, [r0, #offset_state_3os]
  cmp r1, #0
  beq r0_unfrei

  ldr r1, [r0, #offset_state_4os]
  cmp r1, #0
  beq r0_unfrei

  ldr r1, [r0, #offset_state_5os]
  cmp r1, #0
  beq r0_unfrei

  @ r0 ist frei.

    str r3, [r0, #offset_constant_r0]
    pushda r3 @ Die Konstante
    pushdaconst 0 @ Das ist jetzt der Register, wo sie hinein soll
    bl registerliteralkomma
    movs r1, #constant
    str r1, [r0, #offset_state_r0]
    movs r3, #0
    pop {r0, r1, r2, pc}

r0_unfrei:
  pushda r3 @ Die Konstante
  bl get_free_register @ Einen Register nehmen, der gerade nicht im RA angemeldet ist.
  pushda r3 @ Das ist jetzt der Register, wo sie hinein soll
  bl registerliteralkomma
  pop {r0, r1, r2, pc}

  .ltorg

@ -----------------------------------------------------------------------------
get_free_register: @ Gibt den Register in r3 zurück. Setzt noch keinen Zustand.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r4, r5, lr}

  ldr r0, =allocator_base
  ldr r1, [r0, #offset_state_tos]
  ldr r2, [r0, #offset_state_nos]
  ldr r3, [r0, #offset_state_3os]
  ldr r4, [r0, #offset_state_4os]
  ldr r5, [r0, #offset_state_5os]

  movs r0, #6 @ Prüfe zunächst r6 auf Freiheit:
  bl get_free_register_intern

  movs r0, #3 @ Anschließend die ganzen anderen Register:
  bl get_free_register_intern

  movs r0, #2 @ Anschließend die ganzen anderen Register:
  bl get_free_register_intern

  movs r0, #1 @ Anschließend die ganzen anderen Register:
  bl get_free_register_intern

  movs r3, #0 @ Nur noch r0 ist übrig geblieben

  ldr r0, =allocator_base
  movs r1, #unknown @ Muss die Adresskonstantenspeicherstelle wieder freigeben...
  str r1, [r0, #offset_state_r0]

  pop {r0, r1, r2, r4, r5, pc}

get_free_register_intern: @ Welcher Register geprüft werden soll, steht in r0. Rückgabe in r3.
  cmp r1, r0
  beq 1f
  cmp r2, r0
  beq 1f
  cmp r3, r0
  beq 1f
  cmp r4, r0
  beq 1f
  cmp r5, r0
  beq 1f   
    movs r3, r0
    pop {r0, r1, r2, r4, r5, pc}
1:bx lr

@ -----------------------------------------------------------------------------
erstes_element_belegen:
  pushdaconstw 0xCF00 @ ldm r7!, { ... }
element_belegen: @ Nimmt das zu belegende Element aus r2.
  push {lr}
  ldr r1, [r0, r2]
  cmp r1, #unknown
  bne 1f @ Wenn es bereits belegt ist, muss ich hier nichts unternehmen.

    @ Lade es nach !
    bl get_free_register
    str r3, [r0, r2]

    movs r1, #1
    lsls r1, r3
    orrs tos, r1

1:pop {pc}

@ -----------------------------------------------------------------------------
expect_one_element: @ Sorgt dafür, dass mindestens ein Element bereitliegt.
@ -----------------------------------------------------------------------------
  push {lr}

  @ Kernfrage besteht darin: Ist TOS belegt oder nicht ?
  @ Wenn ja, fertig. Wenn nein, sind auch NOS und 3OS leer, also TOS direkt vom Stack nachfüllen.

  ldr r1, [r0, #offset_state_tos]
  cmp r1, #unknown
  bne 1f @ Wenn schon etwas in TOS enthalten ist, bin ich fertig.

    movs r2, #offset_state_tos
    bl erstes_element_belegen
  
    bl hkomma
1:pop {pc}

@ -----------------------------------------------------------------------------
expect_two_elements: @ Sorgt dafür, dass mindestens zwei Elemente bereitliegen.
@ -----------------------------------------------------------------------------
  push {lr}

  @ Es könnten kein Element, ein Element oder zwei Elemente geholt werden müssen.

  ldr r1, [r0, #offset_state_nos]
  cmp r1, #unknown
  bne 1f @ Wenn schon etwas in NOS enthalten ist, bin ich fertig.

    movs r2, #offset_state_nos   @ Der größere Register, der zuletzt geladen wird, muss diesmal NOS werden.
    bl erstes_element_belegen

    movs r2, #offset_state_tos   @ Der kleinere Register, der danach geladen wird, muss TOS werden.
    bl element_belegen
  
    bl hkomma
1:pop {pc}

@ -----------------------------------------------------------------------------
expect_three_elements: @ Sorgt dafür, dass mindestens drei Elemente bereitliegen.
@ -----------------------------------------------------------------------------
  push {lr}

  @ Es könnten kein Element, ein Element, zwei oder drei Elemente geholt werden müssen.

  ldr r1, [r0, #offset_state_3os]
  cmp r1, #unknown
  bne 1f @ Wenn schon etwas in 3OS enthalten ist, bin ich fertig.

    movs r2, #offset_state_3os   @ Der größere Register, der zuletzt geladen wird, muss diesmal 3OS werden.
    bl erstes_element_belegen

    movs r2, #offset_state_nos   @ Der kleinere Register, der danach geladen wird, muss NOS werden.
    bl element_belegen

    movs r2, #offset_state_tos   @ Der kleinste Register, der als letztes geladen wird, muss TOS werden.
    bl element_belegen
  
    bl hkomma
1:pop {pc}

@ -----------------------------------------------------------------------------
expect_four_elements: @ Sorgt dafür, dass mindestens vier Elemente bereitliegen.
@ -----------------------------------------------------------------------------
  push {lr}

  @ Es könnten kein Element, ein Element, zwei oder drei oder vier Elemente geholt werden müssen.

  ldr r1, [r0, #offset_state_4os]
  cmp r1, #unknown
  bne 1f @ Wenn schon etwas in 4OS enthalten ist, bin ich fertig.

    movs r2, #offset_state_4os
    bl erstes_element_belegen

    movs r2, #offset_state_3os
    bl element_belegen

    movs r2, #offset_state_nos
    bl element_belegen

    movs r2, #offset_state_tos
    bl element_belegen
  
    bl hkomma
1:pop {pc}

 .ltorg

@ -----------------------------------------------------------------------------
expect_tos_in_register: @ Sorgt dafür, dass TOS auf jeden Fall einem Register liegt,
                        @ welcher in r1 zurückgegeben wird.
@ -----------------------------------------------------------------------------
  push {lr}

    @ Sollte jetzt TOS eine Konstante sein, so wird sie geladen.

    ldr r1, [r0, #offset_state_tos]
    cmp r1, #constant
    bne 4f
      ldr r3, [r0, #offset_constant_tos] @ Hole die Konstante ab
      bl generiere_veraenderliche_konstante
      str r3, [r0, #offset_state_tos]
      movs r1, r3

4:  @ Beide Argumente sind jetzt in Registern.
  pop {pc}


@ -----------------------------------------------------------------------------
expect_nos_in_register: @ Sorgt dafür, dass NOS auf jeden Fall einem Register liegt,
                        @ welcher in r1 zurückgegeben wird.
@ -----------------------------------------------------------------------------
  push {lr}

    @ Sollte jetzt NOS eine Konstante sein, so wird sie geladen.

    ldr r1, [r0, #offset_state_nos]
    cmp r1, #constant
    bne 4f
      ldr r3, [r0, #offset_constant_nos] @ Hole die Konstante ab
      bl generiere_veraenderliche_konstante
      str r3, [r0, #offset_state_nos]
      movs r1, r3

4:  @ Beide Argumente sind jetzt in Registern.
  pop {pc}

@ -----------------------------------------------------------------------------
expect_3os_in_register: @ Sorgt dafür, dass 3OS auf jeden Fall einem Register liegt,
                        @ welcher in r1 zurückgegeben wird.
@ -----------------------------------------------------------------------------
  push {lr}

    @ Sollte jetzt 3OS eine Konstante sein, so wird sie geladen.

    ldr r1, [r0, #offset_state_3os]
    cmp r1, #constant
    bne 4f
      ldr r3, [r0, #offset_constant_3os] @ Hole die Konstante ab
      bl generiere_veraenderliche_konstante
      str r3, [r0, #offset_state_3os]
      movs r1, r3

4:  @ Beide Argumente sind jetzt in Registern.
  pop {pc}

@ -----------------------------------------------------------------------------
nos_change_tos_away_later: @ NOS wird jetzt verändert, TOS danach freigegeben.
@ -----------------------------------------------------------------------------
  @ Agenda:
  @ Zwei Elemente bereithalten (vorher schon passiert)
  @ Prüfen, ob die Register für NOS und 3OS zufällig identisch sind
  @   --> Registerkopie anfertigen

  @ r0 soll die allocator_base enthalten !
  push {r1, r2, r3, r4, r5, lr}

  ldr r2, [r0, #offset_state_nos]
  ldr r3, [r0, #offset_state_3os]
  ldr r4, [r0, #offset_state_4os]
  ldr r5, [r0, #offset_state_5os]

  cmp r2, r3
  beq 1f
  cmp r2, r4
  beq 1f
  cmp r2, r5
  bne 2f

1:  @ Identisch. Sind es Register ?
    cmp r2, #7 @ Es gibt nur 7 Register - alle anderen Fälle sind größer.
    bhi 2f

      @ Ja, es sind beides Register. Mache für NOS einen Registerwechsel, möglichst in r6 hinein.
      pushdatos
      lsls tos, r2, #3 @ Quellregister
      bl get_free_register
      orrs tos, r3 @ Zielregister
      str r3, [r0, #offset_state_nos]
      bl hkomma

2:pop {r1, r2, r3, r4, r5, pc}

@ -----------------------------------------------------------------------------
make_tos_changeable: @ Lege eine Elementkopie an, falls TOS woanders schon belegt ist.
@ -----------------------------------------------------------------------------
  @ r0 soll die allocator_base enthalten !
  push {r1, r2, r3, r4, r5, lr}

  ldr r1, [r0, #offset_state_tos]
  ldr r2, [r0, #offset_state_nos]
  ldr r3, [r0, #offset_state_3os]
  ldr r4, [r0, #offset_state_4os]
  ldr r5, [r0, #offset_state_5os]

  cmp r1, r2
  beq 1f
  cmp r1, r3
  beq 1f
  cmp r1, r4
  beq 1f
  cmp r1, r5
  beq 1f
    pop {r1, r2, r3, r4, r5, pc}

1: @ Registerwechsel mit Elementkopie für TOS.

      pushdatos
      lsls tos, r1, #3 @ Quellregister
      bl get_free_register
      orrs tos, r3 @ Zielregister
      str r3, [r0, #offset_state_tos]
      bl hkomma

    pop {r1, r2, r3, r4, r5, pc}

@ -----------------------------------------------------------------------------
tos_registerwechsel: @ Wechselt den TOS-Register, gibt diesen in r3 zurück
@ -----------------------------------------------------------------------------
  push {lr}
  @ Registerwechsel direkt im Opcode. Nutze das natürlich aus :-) Spare mir damit eventuelle Elementkopien.
  bl eliminiere_tos
  bl befreie_tos
  bl get_free_register
  str r3, [r0, #offset_state_tos]
  pop {pc}

@ -----------------------------------------------------------------------------
push_lr_nachholen:
@ -----------------------------------------------------------------------------
  push {r0, lr}
    ldr r0, =state
    ldr r3, [r0]
    adds r3, #1 @ Wenn es -1 war, ergibt dies Null, und es war schon im push {lr} Modus.
    beq.n 1f

      movs r3, #0  @ State auf klassisch "true" setzen.
      mvns r3, r3
      str r3, [r0]

      @ writeln "Nachholen von push {lr}"
      pushdaconstw 0xb500 @ Opcode für push {lr} schreiben  Write opcode for push {lr}
      bl hkomma

1:pop {r0, pc}
