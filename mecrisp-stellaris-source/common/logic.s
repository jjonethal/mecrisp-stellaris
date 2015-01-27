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
  Wortbirne Flag_foldable_0|Flag_inline, "true" @ ( -- -1 )
@ -----------------------------------------------------------------------------
  pushdatos
  movs tos, #0
  mvns tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_0|Flag_inline, "false" @ ( x -- 0 )
@ -----------------------------------------------------------------------------
  pushdatos
  movs tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Rechenlogik_M3, "and" @ ( x1 x2 -- x1&x2 )
                        @ Combines the top two stack elements using bitwise AND.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  ands tos, r0
  bx lr
  ands tos, r0 @ Opcode for use with literal in register

  .ifndef m0core @ Opcode with 12-bit encoded constant only available on M3/M4
  .hword 0x0600
  .hword 0xF016
  .endif @ Opcode ands tos, tos, #imm12

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Rechenlogik_M3, "bic" @ ( x1 x2 -- x1&~x2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  bics r0, tos
  movs tos, r0
  bx lr
  bics tos, r0 @ Opcode for use with literal in register

  .ifndef m0core @ Opcode with 12-bit encoded constant only available on M3/M4
  .hword 0x0600
  .hword 0xF036
  .endif @ Opcode bics tos, tos, #imm12

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Rechenlogik_M3, "or" @ ( x1 x2 -- x1|x2 )
                       @ Combines the top two stack elements using bitwise OR.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  orrs tos, r0
  bx lr
  orrs tos, r0 @ Opcode for use with literal in register

  .ifndef m0core @ Opcode with 12-bit encoded constant only available on M3/M4
  .hword 0x0600
  .hword 0xF056
  .endif @ Opcode orrs tos, tos, #imm12

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Rechenlogik_M3, "xor" @ ( x1 x2 -- x1|x2 )
                        @ Combines the top two stack elements using bitwise exclusive-OR.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  eors tos, r0
  bx lr
  eors tos, r0 @ Opcode for use with literal in register

  .ifndef m0core @ Opcode with 12-bit encoded constant only available on M3/M4
  .hword 0x0600
  .hword 0xF096
  .endif @ Opcode eors tos, tos, #imm12


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "not" @ ( x -- ~x )
@ -----------------------------------------------------------------------------
  mvns tos, tos
  bx lr


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
  Wortbirne Flag_foldable_1|Flag_inline, "clz" @ ( x -- u )
                        @ Counts leading zeroes in x.
@ -----------------------------------------------------------------------------
  clz tos, tos
  bx lr

  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "shr" @ ( x -- x' ) @ Um eine Stelle rechts schieben
@ -----------------------------------------------------------------------------
  lsrs tos, #1
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "shl" @ ( x -- x' ) @ Um eine Stelle links schieben
@ -----------------------------------------------------------------------------
  lsls tos, #1
  bx lr

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
  Wortbirne Flag_inline|Flag_opcodierbar_Schieben, "rshift" @ ( x n -- x' )
                           @ Shifts 'x' right by 'n' bits.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  lsrs r0, tos
  movs tos, r0
  bx lr
  .hword 0x0836 @ Opcode lsrs r6, r6, #0
  movs tos, #0  @ Opcode if shift is > 31 places.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Schieben, "arshift" @ ( x n -- x' )
                            @ Shifts 'x' right by 'n' bits, shifting in x's MSB.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  asrs r0, tos
  movs tos, r0
  bx lr
  .hword 0x1036 @ Opcode asrs r6, r6, #0
  asrs tos, #31 @ Opcode if shift is > 31 places.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_Schieben, "lshift" @ ( x n -- x' )
                           @ Shifts 'x' left by 'n' bits.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  lsls r0, tos
  movs tos, r0
  bx lr
  .hword 0x0036 @ Opcode lsls r6, r6, #0
  movs tos, #0  @ Opcode if shift is > 31 places.
