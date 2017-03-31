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

@ Logikfunktionen
@ Logic.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "and" @ ( x1 x2 -- x1&x2 )
                        @ Combines the top two stack elements using bitwise AND.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  ands tos, r0
  bx lr

  pushdaconstw 0x4000 @ ands r0, r0
  b.n alloc_kommutativ

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "bic" @ ( x1 x2 -- x1&~x2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  bics r0, tos
  movs tos, r0
  bx lr

  pushdaconstw 0x4380 @ bics r0, r0
  b.n alloc_unkommutativ

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "or" @ ( x1 x2 -- x1|x2 )
                       @ Combines the top two stack elements using bitwise OR.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  orrs tos, r0
  bx lr

or_allocator:
  pushdaconstw 0x4300 @ orrs r0, r0
  b.n alloc_kommutativ

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "xor" @ ( x1 x2 -- x1|x2 )
                        @ Combines the top two stack elements using bitwise exclusive-OR.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  eors tos, r0
  bx lr

xor_allocator:
  pushdaconstw 0x4040 @ eors r0, r0
  b.n alloc_kommutativ

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "*" @ ( u1|n1 u2|n2 -- u3|n3 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}    @ Get u1|n1 into a register.
  muls tos, r0      @ Multiply!
  bx lr

  pushdaconstw 0x4340 @ muls r0, r0
  b.n alloc_kommutativ

  .ifdef m0core
@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1, "clz" @ ( x -- u )
                        @ Counts leading zeroes in x.
@ -----------------------------------------------------------------------------
  movs r0, tos @ Fetch contents
  beq 3f @ If TOS contains 0 we have 32 leading zeros.

  movs tos, #0 @ No zeros counted yet.

1:lsls r0, #1 @ Shift TOS one place
  beq 2f @ Stop if register is zero.
  bcs 2f @ Stop if an one has been shifted out.
  adds tos, #1
  b 1b

2:bx lr

3:movs tos, #32
  bx lr

  .else

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "clz" @ ( x -- u )
                        @ Counts leading zeroes in x.
@ -----------------------------------------------------------------------------
  clz tos, tos
  bx lr

    push {lr}
    bl expect_one_element
    pushdatos
    ldr tos, =0xfab0f080 @ clz r0, r0
    bl expect_tos_in_register
    orrs tos, r1 @ Quellregister
    orrs tos, tos, r1, lsl #16 @ Quellregister nochmal

    bl tos_registerwechsel

    orrs tos, tos, r3, lsl #8 @ Zielregister
    bl reversekomma
    
    pop {pc}

  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "ror" @ ( x -- x' ) @ Um eine Stelle rechts rotieren
@ -----------------------------------------------------------------------------
  .ifdef m0core
    movs r0, #1
    rors tos, r0
    bx lr
  .else
    rors tos, #1
    bx lr
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "rol" @ ( x -- x' ) @ Um eine Stelle links rotieren
@ -----------------------------------------------------------------------------
  @ Rotate left by one bit place
  .ifdef m0core
    movs r0, #0
    adds tos, tos, tos
    adcs tos, r0
    bx lr
  .else
    adds tos, tos, tos
    adcs tos, #0
    bx lr
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "arshift" @ ( x n -- x' )
                            @ Shifts 'x' right by 'n' bits, shifting in x's MSB.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  asrs r0, tos
  movs tos, r0
  bx lr

  @ -----------------------------------------------------------------------------
    push {lr}
    pushdaconstw 0x4100 @ asrs r0, r0
    pushdaconstw 0x1000 @ asrs r0, r0, #0

    bl expect_two_elements

    ldr r1, [r0, #offset_constant_tos] @ Ich weiß zwar noch nicht, ob es eine Konstante oder ein Register ist, aber das ist egal.
    cmp r1, #31                        @ Falls es eine Konstante ist, kappe sie, wenn es ein Register sein sollte, ändert sich nichts.
    bls 5f
      movs r1, #31 @ Größere Schübe ? --> asrs mit Weite 31 generieren, damit das Vorzeichen stimmt !
      str r1, [r0, #offset_constant_tos]
      b.n 5f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "rshift" @ ( x n -- x' )
                           @ Shifts 'x' right by 'n' bits.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  lsrs r0, tos
  movs tos, r0
  bx lr

  @ -----------------------------------------------------------------------------
    push {lr}
    pushdaconstw 0x40C0 @ lsrs r0, r0
    pushdaconstw 0x0800 @ lsrs r0, r0, #0
    b.n 5f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "lshift" @ ( x n -- x' )
                           @ Shifts 'x' left by 'n' bits.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  lsls r0, tos
  movs tos, r0
  bx lr

  @ -----------------------------------------------------------------------------
    push {lr}
    pushdaconstw 0x4080 @ lsls r0, r0
    pushdaconst  0x0000 @ lsls r0, r0, #0

5:  bl expect_two_elements

    ldr r1, [r0, #offset_state_tos]
    cmp r1, #constant
    beq 1f
      @ TOS ist keine Konstante --> Also Register-Register-Schub. Es gibt nur Opcodes im M0, bei denen Quelle und Ziel identisch sind.
      drop @ Vergiß den Shift-Immediate-Opcode
      bl alloc_unkommutativ @ Kümmert sich um alles.
      pop {pc}
1:  @ TOS ist eine Konstante ! NOS muss jetzt ein Register sein, weil es sonst bereits vorher gefaltet worden wäre.

    nip @ Vergiß den Shift-Register-Register-Opcode

    @ Hole die Konstante !
    ldr r1, [r0, #offset_constant_tos]
    bl eliminiere_tos

    cmp r1, #0 @ Gar nicht schieben ?
    bne 3f
      drop
      pop {pc}
3:

    cmp r1, #31
    bhi 2f
      @ Konstante kleiner als 31 --> Schiebebefehl generieren.
      lsls r1, #6  @ Shift places accordingly
      orrs tos, r1  @ Build shift opcode

      ldr r2, [r0, #offset_state_tos]
      lsls r2, #3
      orrs tos, r2

      @ Registerwechsel in r6, wenn möglich - Schiebeopcode gibt das her
      bl tos_registerwechsel
      orrs tos, r3

      bl hkomma
      pop {pc}

2:  @ Konstante größer als 31 --> Alles rausschieben.
    drop @ Vergiß den zweiten Opcode auch
    bl tos_registerwechsel

    pushdaconstw 0x2000 @ movs r0, #0
    lsls r3, #8
    orrs tos, r3
    bl hkomma
    pop {pc}
