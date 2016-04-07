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

@ Stackjongleure
@ Stack jugglers

@ Stack pointers

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "sp@" @ ( -- a-addr )
@ -----------------------------------------------------------------------------
  pushdatos
  movs tos, psp
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "sp!" @ ( a-addr -- )
@ -----------------------------------------------------------------------------
  movs psp, tos
  ldm psp!, {tos}
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "rp@" @ ( -- a-addr )
@ -----------------------------------------------------------------------------
  pushdatos
  mov tos, sp
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "rp!" @ ( a-addr -- )
@ -----------------------------------------------------------------------------
  mov sp, tos
  ldm psp!, {tos}
  bx lr

@ Stack juggling

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "dup" @ ( x -- x x )
@ -----------------------------------------------------------------------------
  dup
  bx lr

dup_allocator:
    push {r1, r2, lr} @ Spezialeinsprung des Registerallokators:
    bl expect_one_element  @ Mindestens ein Wert vorhanden

    ldr r1, [r0, #offset_state_tos]
    ldr r2, [r0, #offset_constant_tos]

    bl befreie_tos

    str r1, [r0, #offset_state_tos]
    str r2, [r0, #offset_constant_tos]

    pop {r1, r2, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "drop" @ ( x -- )
drop_einsprung:
@ -----------------------------------------------------------------------------
  drop
  bx lr

drop_allocator:
    push {lr} @ Spezialeinsprung des Registerallokators:
    @ Falten geht von selbst vorher.
    @ Wenn kein Element da ist, generiere den regulären drop-Opcode:
    @ Wenn ein Element da ist, vernichte es und lasse nachrutschen.

    ldr r1, [r0, #offset_state_tos]
    cmp r1, #unknown
    bne 2f

      pushdaconstw 0x3704 @ adds r7, #4 - Momentan ist TOS auf dem Stack, kann direkt runterwerfen
      bl hkomma
      pop {pc}

2: @ Es ist ein Element da, das muss ich beachten.
   bl eliminiere_tos
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "?dup" @ ( x -- 0 | x x )
@ -----------------------------------------------------------------------------
  cmp tos, #0
  beq 1f
  pushdatos
1:bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "swap" @ ( x y -- y x )
@ -----------------------------------------------------------------------------
  ldr r1,  [psp]  @ Load X from the stack, no SP change.
  str tos, [psp]  @ Replace it with TOS.
  movs tos, r1    @ And vice versa.
  bx lr

swap_allocator:
    push {r2, r3, lr} @ Spezialeinsprung des Registerallokators:

    bl expect_two_elements

    @ TOS und NOS vertauschen.
    ldr r2, [r0, #offset_state_tos]
    ldr r3, [r0, #offset_state_nos]
    str r3, [r0, #offset_state_tos]
    str r2, [r0, #offset_state_nos]

    ldr r2, [r0, #offset_constant_tos]
    ldr r3, [r0, #offset_constant_nos]
    str r3, [r0, #offset_constant_tos]
    str r2, [r0, #offset_constant_nos]

    pop {r2, r3, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "nip" @ ( x y -- x )
@ -----------------------------------------------------------------------------
  nip
  bx lr

nip_allocator:
    push {lr} @ Spezialeinsprung des Registerallokators:

    @ Falten geht von selbst vorher.
    @ Was passiert, wenn Konstanten da sind ?
    @ 2 oder mehr Konstanten --> Falten
    @ 1 Konstante --> TOS weg
    @ Wenn kein Element  da ist, muss ich eins holen und eins löschen.
    @ Wenn  ein Element  da ist, verändere den Stackpointer
    @ Wenn zwei Elemente in Registern sind, vernichte NOS.

    bl expect_one_element @ TOS auf jeden Fall belegen.

    ldr r1, [r0, #offset_state_nos]
    cmp r1, #unknown
    beq 1f
      @ NOS ist belegt - kann das Element direkt eliminieren
      bl eliminiere_nos
      pop {pc}

1:  @ NOS nicht belegt - lösche einfach das nächste Stackelement, ohne es zu laden
    @ Vernichte also das obere Element auf dem Stack im Speicher, welches dann NOS darstellt.
    pushdaconstw 0x3704 @ adds r7, #4 - Momentan ist NOS auf dem Stack, kann direkt runterwerfen
    bl hkomma
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "over" @ ( x y -- x y x )
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, [psp, #4]
  bx lr

over_allocator:
    push {lr} @ Spezialeinsprung des Registerallokators:

    bl expect_two_elements

    ldr r1, [r0, #offset_state_nos]
    ldr r2, [r0, #offset_constant_nos]

    bl befreie_tos

    str r1, [r0, #offset_state_tos]
    str r2, [r0, #offset_constant_tos]

    pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "tuck" @ ( x1 x2 -- x2 x1 x2 )
@ -----------------------------------------------------------------------------
tuck:
  ldm psp!, {r0}
  subs psp, #8
  str tos, [psp, #4]
  str r0, [psp]
  bx lr

    push {lr} @ Spezialeinsprung des Registerallokators:
    bl expect_two_elements
    bl dup_allocator
    bl minusrot_allocator
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_3|Flag_inline|Flag_allocator, "rot" @ ( x w y -- w y x )
@ -----------------------------------------------------------------------------
rot:
  ldm psp!, {r0, r1}
  subs psp, #8
  str r0, [psp, #4]
  str tos, [psp]
  movs tos, r1
  bx lr

rot_allocator:
    push {r1, r2, r3, lr} @ Spezialeinsprung des Registerallokators:
    bl expect_three_elements
    @ ( 3OS NOS TOS )

    @ TOS --> NOS
    @ NOS --> 3OS
    @ 3OS --> TOS

    ldr r1, [r0, #offset_state_tos]
    ldr r2, [r0, #offset_state_nos]
    ldr r3, [r0, #offset_state_3os]

    str r1, [r0, #offset_state_nos]
    str r2, [r0, #offset_state_3os]
    str r3, [r0, #offset_state_tos]

    ldr r1, [r0, #offset_constant_tos]
    ldr r2, [r0, #offset_constant_nos]
    ldr r3, [r0, #offset_constant_3os]

    str r1, [r0, #offset_constant_nos]
    str r2, [r0, #offset_constant_3os]
    str r3, [r0, #offset_constant_tos]
    pop {r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_3|Flag_inline|Flag_allocator, "-rot" @ ( x w y -- y x w )
@ -----------------------------------------------------------------------------
minusrot:
  ldm psp!, {r0, r1}
  subs psp, #8
  str tos, [psp, #4]
  str r1, [psp]
  movs tos, r0
  bx lr

minusrot_allocator:
    push {lr} @ Spezialeinsprung des Registerallokators:
    bl rot_allocator  @ -rot = rot rot
    bl rot_allocator
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_inline, "pick" @ ( xu .. x1 x0 u -- xu ... x1 x0 xu )
@ -----------------------------------------------------------------------------
  .ifdef m0core
  lsls r0, tos, #2
  ldr tos, [psp, r0]
  bx lr
  .else
  ldr tos, [psp, tos, lsl #2]  @ I love ARM. :-)
  bx lr
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "depth" @ ( -- Zahl der Elemente, die vorher auf den Datenstack waren )
                                  @ ( -- Number of elements that have been on datastack before )
@ -----------------------------------------------------------------------------
  @ Berechne den Stackfüllstand
  ldr r1, =datenstackanfang @ Anfang laden  Calculate stack fill gauge
  subs r1, psp @ und aktuellen Stackpointer abziehen
  pushdatos
  lsrs tos, r1, #2 @ Durch 4 teilen  Divide through 4 Bytes/element.
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "rdepth"
@ -----------------------------------------------------------------------------
  pushdatos
  mov tos, sp
  ldr r1, =returnstackanfang @ Anfang laden  Calculate stack fill gauge
  subs r1, tos @ und aktuellen Stackpointer abziehen
  lsrs tos, r1, #2 @ Durch 4 teilen  Divide through 4 Bytes/element.
  bx lr

@ Returnstack

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, ">r" @ Legt das oberste Element des Datenstacks auf den Returnstack.
@------------------------------------------------------------------------------
  push {tos}
  ldm psp!, {tos}
  bx lr

allocator_to_r:
    push {lr}
    bl push_lr_nachholen
    bl expect_one_element
    bl expect_tos_in_register @ Gibt den Register in r1 zurück.

    pushdaconstw 0xB400 @ push {...}

    movs r2, #1
    lsls r2, r1
    orrs tos, r2

    bl hkomma
    bl eliminiere_tos
    pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "r>" @ Holt das zwischengespeicherte Element aus dem Returnstack zurück
@------------------------------------------------------------------------------
  pushdatos
  pop {tos}
  bx lr

allocator_r_from:
    push {lr}
    bl push_lr_nachholen
    bl befreie_tos
    bl get_free_register
    str r3, [r0, #offset_state_tos]

    pushdaconstw 0xBC00 @ pop {...}

    movs r2, #1
    lsls r2, r3
    orrs tos, r2

    bl hkomma
    pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "r@" @ Kopiert das oberste Element des Returnstacks auf den Datenstack
@------------------------------------------------------------------------------
  pushdatos
  ldr tos, [sp]
  bx lr
    push {lr}
    bl push_lr_nachholen
    bl rfetch_allocator
    pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "rdrop" @ Entfernt das oberste Element des Returnstacks
@------------------------------------------------------------------------------
  add sp, #4
  bx lr
    push {lr}
    bl push_lr_nachholen
    pushdaconstw 0xB001  @ Opcode add sp, #4
    bl hkomma
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_inline, "rpick" @ ( u -- xu R: xu .. x1 x0 -- xu ... x1 x0 )
@ -----------------------------------------------------------------------------
  lsls tos, #2
  add tos, sp
  ldr tos, [tos]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "roll" @ ( xu xu-1 ... x0 u -- xu-1 ... x0 xu )
roll:
@ -----------------------------------------------------------------------------
  @ 2 ROLL is equivalent to ROT, 1 ROLL is equivalent to SWAP and 0 ROLL is a null operation.
  @ TOS enthält das Element, welches am Ende nach oben rutschen soll.

  cmp tos, #0 @ No moves ?
  bne 1f
    drop
    bx lr

1:lsls r0, tos, #2
  ldr r1, [psp, r0] @ Pick final TOS value temporarily into r1

  @ One element is removed from the stack, let all other values fall down one place

  @ (  5  4  3  2  1   TOS: 4)
  @ (  5     3  2  1 )
  @ (  5  3  2  1    )
  @ ( 16 12  8  4  0


  @ TOS contains number of moves, r0 number of bytes offset from stack pointer

  @ Wo fange ich an ?
  @ In der Lücke, die sich aufgetan hat. Lasse nachrutschen !
  @ Also holen: Eine Stelle über der Lücke
  @ Einfügen direkt in der Lücke.

  @ Lückenadresse = psp + r0

  @ Lege von psp + r0 - 4 an die Stelle psp + r0.

    adds r0, psp

2:  subs r3, r0, #4   @ Dies hier noch ein bisschen verschönern ! Funktioniert aber schonmal.
    ldr r2, [r3]
    str r2, [r0]
    subs r0, #4

    subs tos, #1
    bne 2b

  adds psp, #4 @ Element entfernen

3:@ Finished shifting of stack. Load result into TOS.
  movs tos, r1
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "-roll" @ ( xu-1 ... x0 xu u -- xu xu-1 ... x0 u )
minusroll: @ Kehrt die Wirkung von roll um.
@ -----------------------------------------------------------------------------
  @ 2 ROLL is equivalent to ROT, 1 ROLL is equivalent to SWAP and 0 ROLL is a null operation.
  @ TOS enthält das Element, welches am Ende nach oben rutschen soll.

  cmp tos, #0 @ No moves ?
  bne 1f
    drop
    bx lr


1:@ TOS contains number of moves.

  ldr r0, [psp] @ Das jetztige NOS soll später in die Lücke hinein, wird aber überschrieben.

  @ (  5  4  3  2  1  X   TOS: 4)
  @ (  5  4  4  3  2  1 )
  @ (  5  X  4  3  2  1 )

  @ Beginne direkt beim Stackpointer:
  mov r1, psp

2:@ Mache nun die gewünschte Zahl von Schüben:
  ldr r2, [r1, #4]
  str r2, [r1]
  adds r1, #4
  subs tos, #1
  bne 2b

  @ Lege das NOS-Element in die Lücke
  str r0, [r1]

  @ Vergiss den Zähler in TOS
  drop
  bx lr

   .ltorg
