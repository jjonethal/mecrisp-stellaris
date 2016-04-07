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

@ Vergleichsoperatoren
@ Comparision operators

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "0=" @ ( x -- ? )
@ -----------------------------------------------------------------------------
@        subs TOS, TOS, #1       ; if zero, carry is set, else carry is clear
@        sbc TOS, TOS, TOS       ; subtracting r0 from itself leaves zero if
@                                ; carry was clear or -1 if carry was set.
  subs tos, #1
  sbcs tos, tos
  bx lr


@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "0<>" @ ( x -- ? )
@ -----------------------------------------------------------------------------
  subs tos, #1
  sbcs tos, tos
  mvns tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline, "0<" @ ( n -- ? )
@ -----------------------------------------------------------------------------
  movs TOS, TOS, asr #31    @ Turn MSB into 0xffffffff or 0x00000000
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_0|Flag_inline, "true" @ ( -- -1 )
@ -----------------------------------------------------------------------------
  pushdatos
generate_true:
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
  Wortbirne Flag_foldable_2, ">=" @ ( x1 x2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get x1 into a register.
  cmp r0, tos         @ Is x2 less or equal ?
  bge.n generate_true
  movs tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "<=" @ ( x1 x2 -- ? )          
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get x1 into a register.
  cmp r0, tos        @ Is x2 greater or equal ?
  ble.n generate_true
  movs tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "<" @ ( x1 x2 -- ? )
                      @ Checks if x2 is less than x1.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get x1 into a register.
  cmp r0, tos        @ Is x2 less?
  blt.n generate_true
  movs tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, ">" @ ( x1 x2 -- ? )
                      @ Checks if x2 is greater than x1.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get x1 into a register.
  cmp r0, tos        @ Is x2 greater?
  bgt.n generate_true
  movs tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "u>=" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get u1 into a register.
  subs tos, r0, tos   @ subs tos, w, tos   @ TOS = a-b  -- carry set if a is less than b
  sbcs tos, tos
  mvns tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "u<=" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs tos, r0
  sbcs tos, tos
  mvns tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "u<" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get u1 into a register.
  subs tos, r0, tos   @ subs tos, w, tos   @ TOS = a-b  -- carry set if a is less than b
  sbcs tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "u>" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs tos, r0
  sbcs tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_GleichUngleich, "<>" @ ( x1 x2 -- ? )
                       @ Compares the top two stack elements for inequality.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get the next elt into a register.
  subs tos, r0        @ Z=equality; if equal, TOS=0

  subs tos, #1
  sbcs tos, tos
  mvns tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_opcodierbar_GleichUngleich, "=" @ ( x1 x2 -- ? )
                      @ Compares the top two stack elements for equality.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get the next elt into a register.
  subs tos, r0       @ Z=equality; if equal, TOS=0

  subs tos, #1       @ Wenn es Null war, gibt es jetzt einen Überlauf
  sbcs tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "min" @ ( x1 x2 -- x3 )
                        @ x3 is the lesser of x1 and x2.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  bgt 1f
  movs tos, r0
1:bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "max" @ ( x1 x2 -- x3 )
                        @ x3 is the greater of x1 and x2.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  blt 1f
  movs tos, r0
1:bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "umax" @ ( u1 u2 -- u1|u2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  blo 1f
  movs tos, r0
1:bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "umin" @ ( u1 u2 -- u1|u2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  bhi 1f
  movs tos, r0
1:bx lr

