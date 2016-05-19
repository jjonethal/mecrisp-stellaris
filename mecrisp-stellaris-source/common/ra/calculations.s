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

@ Kleine Rechenmeister
@ Small calculations

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "+" @ ( x1 x2 -- x1+x2 )
                      @ Adds x1 and x2.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  adds tos, r0
  bx lr

plus_allocator:

    push {lr}
    bl expect_two_elements

    pushdaconstw 0x3000 @ adds r0, #imm8
    .ifndef m0core
      pushdatos
      ldr tos, =0xF1100000 @ adds r0, r0, #Imm12
    .endif
    pushdaconstw 0x1800 @ adds r0, r0, r0

    @ Ist in TOS oder in NOS eine kleine Konstante ?
    ldr r1, [r0, #offset_state_nos]
    cmp r1, #constant
    bne 1f
      bl swap_allocator @ Wenn NOS eine Konstante gewesen ist, war TOS es nicht (Vorherige Faltung !) und ich kann einfach umtauschen.
      b.n 1f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "-" @ ( x1 x2 -- x1-x2 )
                      @ Subtracts x2 from x1.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs tos, r0, tos
  bx lr

minus_allocator:

    push {lr}
    bl expect_two_elements

    pushdaconstw 0x3800 @ subs r0, #imm8
    .ifndef m0core
      pushdatos
      ldr tos, =0xF1B00000 @ subs r0, r0, #Imm12
    .endif
    pushdaconstw 0x1A00 @ subs r0, r0, r0

1:  @ Minus ist nicht kommutativ, deswegen hier eine Optimierung weniger als bei Plus.

    bl expect_nos_in_register

    @ Jetzt sind mindestens zwei Element in den Registern, also TOS und NOS gefüllt.
    @ Der Fall, dass beide Konstanten sind tritt nicht auf, weil er von der Faltung bereits erledigt wird.
    @ Entweder zwei Register, oder eine Konstante und einen Register.

    @ Ist jetzt TOS eine kleine Konstante ?

    ldr r1, [r0, #offset_state_tos]
    cmp r1, #constant
    bne 4f
      ldr r1, [r0, #offset_constant_tos]
      cmp r1, #0xff
      bhi 3f
        drop @ Vergiß den Drei-Register-Opcode

        .ifndef m0core
        drop @ Vergiß den Imm12-Opcode
        .endif

        @ writeln "Plusminus kleine Konstante"
        bl nos_change_tos_away_later
        @ TOS ist eine kleine Konstante.
        orrs tos, r1
        ldr r1, [r0, offset_state_nos] @ NOS dann der Faltung wegen unbedingt ein Register.
        lsls r1, #8
        orrs tos, r1
        bl hkomma

        bl eliminiere_tos
        pop {pc}

3:  @ TOS war keine kleine Konstante

        .ifndef m0core
        @ Vielleicht ist TOS eine große Konstante, die sich als Imm12 darstellen lässt ?
        pushda r1 @ Konstante auf den Stack legen
        bl twelvebitencoding @ ( Konstante -- Bitmaske true | Konstante false )
        ldmia psp!, {r1} @ Entweder die Bitmaske oder wieder die Konstante

        cmp tos, #0
        drop   @ Preserves Flags !
        beq 4f
          @ Die Konstante lässt sich als Imm12 darstellen - fein !

          drop @ Vergiß den Drei-Register-Opcode
          nip  @ Vergiß den Imm8-Opcode

          orrs tos, r1 @ Bitmaske für Imm12 hinzufügen

          ldr r1, [r0, offset_state_nos] @ NOS dann der Faltung wegen unbedingt ein Register.

          orrs tos, tos, r1, lsl #16 @ Quellregister hinzufügen

          @ Vergiß die Konstante
          bl eliminiere_tos

          bl tos_registerwechsel
          orrs tos, tos, r3, lsl #8  @ Den Zielregister hinzufügen

          bl reversekomma
          pop {pc}
        .endif

4:  @ TOS war überhaupt keine Konstante oder ließ sich nicht opcodieren.

    nip @ Vergiß den Imm8-Opcode

    .ifndef m0core
    nip @ Vergiß denn Imm12-Opcode
    .endif

    @ Es ist egal, wierum die Quellregister liegen, da ich mir bei diesen Opcodes den Zielregister frei aussuchen kann.
    @ Schritt eins: Die Konstante, falls TOS oder NOS eine sein sollten, laden.

    bl expect_tos_in_register

    @ Baue Quell- und "Ziel-" Register in den Opcode ein.

    lsls r1, #6  @ Erster Operand ist um 6 Stellen geschoben

    ldr r2, [r0, #offset_state_nos]
    lsls r2, #3  @ Zweiter Operand ist um 3 Stellen geschoben

    @ Baue jetzt den Opcode zusammen:

    orrs tos, r1
    orrs tos, r2

    @ Vergiss die bisherige Registerzuordnung

    bl eliminiere_tos
    
    @ Den Zielregister des Gesamtergebnis bestimmen, ganz komfortabel, und möglichst in r6:
    bl tos_registerwechsel

    orrs tos, r3  @ Der Endzielregister ist gar nicht geschoben
    bl hkomma

    pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "1-" @ ( u -- u-1 )
                      @ Subtracts one from the cell on top of the stack.
@ -----------------------------------------------------------------------------
  subs tos, #1
  bx lr

allocator_one_minus:
    pushdaconstw 0x1E00 + 1<<6
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "1+" @ ( u -- u+1 )
                       @ Adds one to the cell on top of the stack.
@ -----------------------------------------------------------------------------
  adds tos, #1
  bx lr

    pushdaconstw 0x1C00 + 1<<6
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "2-" @ ( u -- u-1 )
                      @ Subtracts two from the cell on top of the stack.
@ -----------------------------------------------------------------------------
  subs tos, #2
  bx lr

    pushdaconstw 0x1E00 + 2<<6
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "2+" @ ( u -- u+1 )
                       @ Adds two to the cell on top of the stack.
@ -----------------------------------------------------------------------------
  adds tos, #2
  bx lr

    pushdaconstw 0x1C00 + 2<<6
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "cell+" @ ( x -- x+4 )
@ -----------------------------------------------------------------------------
  adds tos, #4
  bx lr

    pushdaconstw 0x1C00 + 4<<6
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "negate" @ ( n1 -- -n1 )
@ -----------------------------------------------------------------------------
  rsbs tos, tos, #0
  bx lr

allocator_negate:
    pushdaconstw 0x4240 @ rsbs r0, r0, #0

smalltworegisters:
    push {lr}
    bl expect_one_element @ Da nicht gefaltet worden ist, muss es sich um einen Register handeln.
    ldr r1, [r0, #offset_state_tos]
    lsls r1, #3
    orrs tos, r1
    bl tos_registerwechsel
    orrs tos, r3
    bl hkomma
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "not" @ ( x -- ~x )
@ -----------------------------------------------------------------------------
  mvns tos, tos
  bx lr

allocator_not:
    pushdaconstw 0x43C0 @ mvns r0, r0
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1|Flag_allocator, "shr" @ ( x -- x' ) @ Um eine Stelle rechts schieben
@ -----------------------------------------------------------------------------
  lsrs tos, #1
  bx lr

    pushdaconstw 0x0840 @ lsrs r0, r0, #1
    b.n smalltworegisters


@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1|Flag_allocator, "shl" @ ( x -- x' ) @ Um eine Stelle links schieben
@ -----------------------------------------------------------------------------
  lsls tos, #1
  bx lr

    b.n 1f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "2*" @ ( n -- n*2 )
@ -----------------------------------------------------------------------------
  lsls tos, #1
  bx lr

1:  pushdaconst 0x0040 @ lsls r0, r0, #1
    b.n smalltworegisters

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "cells" @ ( x -- 4*x )
@ -----------------------------------------------------------------------------
  lsls tos, #2
  bx lr

    pushdaconst 0x0080 @ lsls r0, r0, #2
    b.n smalltworegisters


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "2/" @ ( n -- n/2 )
@ -----------------------------------------------------------------------------
  asrs tos, #1
  bx lr

    pushdaconstw 0x1040 @ asrs r0, r0, #1
    b.n smalltworegisters


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "abs" @ ( n1 -- |n1| )
@ -----------------------------------------------------------------------------
  asrs r0, tos, #31 @ Turn MSB into 0xffffffff or 0x00000000
  adds tos, r0
  eors tos, r0
  bx lr

    push {lr} @ Eine Konstante wären weggefaltet worden, also muss TOS jetzt ein Register sein.
    bl expect_one_element
    pushdaconstw 0x2800 @ cmp r0, #0
    ldr r1, [r0, #offset_state_tos]
    lsls r1, #8
    orrs tos, r1
    bl hkomma

    pushdaconstw 0xD500 @ bpl
    bl hkomma

    bl allocator_negate
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "u/mod" @ ( u1 u2 -- rem quot )
u_divmod:                            @ ARM provides no remainder operation, so we fake it by un-dividing and subtracting.
@ -----------------------------------------------------------------------------
  .ifdef m0core

  popda r1
  @ Catch divide by zero..
  cmp r1, #0
  bne 1f          @ Alles ist Rest
    pushdaconst 0 @ Ergebnis Null
    bx lr
1:

  @ Shift left the denominator until it is greater than the numerator
  movs r2, #1    @ Zähler
  movs r3, #0    @ Ergebnis
  cmp tos, r1
  bls 3f
  adds r1, #0    @ Don't shift if denominator would overflow
  bmi 3f

2:lsls r2, #1
  lsls r1, #1
  bmi 3f
  cmp tos, r1
  bhi 2b

3:cmp tos, r1
  bcc 4f         @ if (num>denom)
  subs tos, r1     @ numerator -= denom
  orrs r3, r2      @ result(r3) |= bitmask(r2)

4:lsrs r1, #1    @ denom(r1) >>= 1
  lsrs r2, #1    @ bitmask(r2) >>= 1
  bne 3b

  pushda r3
  bx lr

  .else

  ldm psp!, {r0}       @ Get u1 into a register
  movs r1, tos        @ Back up the divisor in X.
  udiv tos, r0, tos  @ Divide: quotient in TOS.
  muls r1, tos, r1    @ Un-divide to compute remainder.
  subs r0, r1          @ Compute remainder.
  subs psp, #4
  str r0, [psp]
  bx lr

  .endif


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "/mod" @ ( n1 n2 -- rem quot )
divmod:                             @ ARM provides no remainder operation, so we fake it by un-dividing and subtracting.
@ -----------------------------------------------------------------------------
  .ifdef m0core

  push {lr}
  popda r0 @ Divisor
  @     TOS: Dividend

  cmp tos, #0 @ Prüfe den Dividenden
  bge.n divmod_plus
  rsbs tos, tos, #0

divmod_minus:
    cmp r0, #0
    bge.n divmod_minus_plus

divmod_minus_minus:
      rsbs r0, r0, #0
      pushda r0
      bl u_divmod
      popda r0
      rsbs tos, tos, #0
      pushda r0
      pop {pc}

divmod_minus_plus:
      pushda r0
      bl u_divmod
      popda r0
      rsbs r0, r0, #0
      rsbs tos, tos, #0
      pushda r0
      pop {pc}

divmod_plus:
    cmp r0, #0
    bge.n divmod_plus_plus

divmod_plus_minus:
      rsbs r0, r0, #0
      pushda r0
      bl u_divmod
      rsbs tos, tos, #0
      pop {pc}

divmod_plus_plus:
      pushda r0
      bl u_divmod
      pop {pc}

  .else

  ldm psp!, {r0}       @ Get u1 into a register
  movs r1, tos       @ Back up the divisor in X.
  sdiv tos, r0, tos @ Divide: quotient in TOS.
  muls r1, tos, r1   @ Un-divide to compute remainder.
  subs r0, r1         @ Compute remainder.
  subs psp, #4
  str r0, [psp]
  bx lr

  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "mod" @ ( n1 n2 -- rem )
@ -----------------------------------------------------------------------------
  push {lr}
  bl divmod
  drop
  pop {pc}

  .ifdef m0core
@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "/" @ ( n1 n2 -- n1/n2 )
@ -----------------------------------------------------------------------------
  push {lr}
  bl divmod
  adds psp, #4    @ NIP - Move SP to eliminate next element.
  pop {pc}

  .else

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "/" @ ( n1 n2 -- n1/n2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}       @ Get n1 into a register
  sdiv tos, r0, tos    @ Divide !
  bx lr

    push {lr}
    bl expect_two_elements
    bl expect_tos_in_register
    bl expect_nos_in_register

    @ Baue den Opcode zusammen:
    pushdatos
    ldr tos, =0xFB90F0F0

    ldr r1, [r0, #offset_state_tos]
    orrs tos, r1 @ Quellregister 1 hinzufügen

    ldr r1, [r0, #offset_state_nos]
    orrs tos, tos, r1, lsl #16 @ Quellregister 2 hinzufügen
    
    bl eliminiere_tos

    bl tos_registerwechsel

    orrs tos, tos, r3, lsl #8 @ Zielregister hinzufügen
    bl reversekomma
    pop {pc}

  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "even" @ ( x -- x' )
@ -----------------------------------------------------------------------------
  movs r0, #1
  ands r0, tos
  adds tos, r0
  bx lr

/*
@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "even4" @ ( x -- x' )
@ -----------------------------------------------------------------------------
  ands r1, tos, #1 @ Gerade machen
  adds tos, r1
  ands r1, tos, #2 @ Auf vier gerade machen
  adds tos, r1
  bx lr
*/

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "base" @ ( -- addr )
  CoreVariable base
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =base
  bx lr
  .word 10

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "binary" @ ( -- )
@ -----------------------------------------------------------------------------
  ldr r0, =base
  movs r1, #2
  str r1, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "decimal" @ ( -- )
@ -----------------------------------------------------------------------------
  ldr r0, =base
  movs r1, #10
  str r1, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hex" @ ( -- )
@ -----------------------------------------------------------------------------
  ldr r0, =base
  movs r1, #16
  str r1, [r0]
  bx lr

 .ltorg
