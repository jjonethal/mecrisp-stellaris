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
  Wortbirne Flag_inline|Flag_opcodierbar_Plusminus, "+" @ ( x1 x2 -- x1+x2 )
                      @ Adds x1 and x2.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  adds tos, r0
  bx lr
  adds tos, r0 @ Opcode for use with literal in register
  adds tos, #0 @ Opcode for use with byte literal

  .ifndef m0core @ Opcode with 12-bit encoded constant only available on M3/M4
  .hword 0x0600
  .hword 0xF116
  .endif @ Opcode adds tos, tos, #imm12

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Plusminus, "-" @ ( x1 x2 -- x1-x2 )
                      @ Subtracts x2 from x1.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs tos, r0, tos
  bx lr
  subs tos, r0 @ Opcode for use with literal in register
  subs tos, #0 @ Opcode for use with byte literal

  .ifndef m0core @ Opcode with 12-bit encoded constant only available on M3/M4
  .hword 0x0600
  .hword 0xF1B6
  .endif @ Opcode subs tos, tos, #imm12

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "1-" @ ( u -- u-1 )
                      @ Subtracts one from the cell on top of the stack.
@ -----------------------------------------------------------------------------
  subs tos, #1
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "1+" @ ( u -- u+1 )
                       @ Adds one to the cell on top of the stack.
@ -----------------------------------------------------------------------------
  adds tos, #1
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "2-" @ ( u -- u-1 )
                      @ Subtracts two from the cell on top of the stack.
@ -----------------------------------------------------------------------------
  subs tos, #2
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "2+" @ ( u -- u+1 )
                       @ Adds two to the cell on top of the stack.
@ -----------------------------------------------------------------------------
  adds tos, #2
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "negate" @ ( n1 -- -n1 )
@ -----------------------------------------------------------------------------
  rsbs tos, tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "abs" @ ( n1 -- |n1| )
@ -----------------------------------------------------------------------------
  .ifdef m0core
  cmp tos, #0
  bpl 1f
  rsbs tos, tos, #0
1:bx lr
  .else
  cmp tos, #0
  it mi
  rsbsmi tos, tos, #0
  bx lr
  .endif

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
  Wortbirne Flag_foldable_2|Flag_inline, "/" @ ( n1 n2 -- n1/n2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}       @ Get n1 into a register
  sdiv tos, r0, tos    @ Divide !
  bx lr
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Rechenlogik, "*" @ ( u1|n1 u2|n2 -- u3|n3 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}    @ Get u1|n1 into a register.
  muls tos, r0      @ Multiply!
  bx lr
  muls tos, r0      @ Opcode for use with literal in register

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "2*" @ ( n -- n*2 )
@ -----------------------------------------------------------------------------
  lsls tos, #1
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "2/" @ ( n -- n/2 )
@ -----------------------------------------------------------------------------
  asrs tos, #1
  bx lr

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
