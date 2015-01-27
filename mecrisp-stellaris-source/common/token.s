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

@ Token und Parse zum Zerlegen des Eingabepuffers
@ Token and parse to cut contents of input buffer apart

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "token" @ ( -- c-addr length )
token:
@ -----------------------------------------------------------------------------
  pushdatos
  movs tos, #32 @ Leerzeichen  Space
  b.n parse

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "parse" @ ( c -- c-addr length )
parse:
@ -----------------------------------------------------------------------------
  push {r4, lr} @ Eigentlich nur r4 nötig
  @ Parse nochmal neu überdenken:

  bl source
  popda r1  @ Length  of input buffer
  popda r0  @ Pointer to input buffer

  ldr r2, =Pufferstand
  ldr r2, [r2] @ Current >IN gauge

  adds r4, r0, r2 @ Start address of parsed string

  @ Speziell for Token, falls das Trennzeichen das Leerzeichen ist:
  cmp tos, #32
  bne 2f

1:  cmp r1, r2 @ Any characters left ?
    beq 3f
      ldrb r3, [r0, r2] @ Fetch character
      cmp r3, tos @ Ist es das Leerzeichen ? Is this the delimiter which is space in this loop ?
      bne 2f
        adds r2, #1     @ Don't collect spaces, advance >IN to skip.
        adds r4, r0, r2 @ Recalculate start address of parsed string
        b 1b

2:@ Sammelschleife. Collecting loop.
  cmp r1, r2 @ Any characters left ?
  beq 3f
    ldrb r3, [r0, r2] @ Fetch character
    adds r2, #1       @ Advance >IN
    cmp r3, tos @ Is this the delimiter ?
    bne 2b
      @ Finished, fallthrough for delimiter detected.
      adds tos, r0, r2
      subs tos, r4
      subs tos, #1 @ Delimiter should not be part of the parsed string but needs to be count in >IN
      b 4f

3:@ Finished. Fallthrough for end-of-string. Calculate length of parsed string
  adds tos, r0, r2
  subs tos, r4

4:@ Store start address
  subs psp, #4
  str r4, [psp]

  @ Store new >IN
  ldr r0, =Pufferstand
  str r2, [r0] @ Fresh >IN gauge

  pop {r4, pc}
