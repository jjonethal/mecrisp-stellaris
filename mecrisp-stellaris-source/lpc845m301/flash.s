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

@ Universal Flash experimentation toolkit.
@ It allows you to write your own Flash controller code directly in Forth.
@ Just fill in these three hooks.
@ Do compiletoram, set hooks, compiletoflash, set hooks in init.

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "hook-initflash" @ ( -- addr )
  CoreVariable hook_initflash
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =hook_initflash
  bx lr
  .word nop_vektor

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "hook-hflash!" @ ( -- addr )
  CoreVariable hook_h_flashkomma
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =hook_h_flashkomma
  bx lr
  .word ddrop_vektor

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "hook-flushflash" @ ( -- addr )
  CoreVariable hook_flushflash
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =hook_flushflash
  bx lr
  .word nop_vektor


@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "initflash" @ ( -- )
initflash:
@------------------------------------------------------------------------------
  ldr r0, =hook_initflash
  ldr r0, [r0]
  mov pc, r0

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hflash!" 
h_flashkomma: @ ( x addr -- )
@ -----------------------------------------------------------------------------
  @ Check if address is even
  lsrs r0, tos, #1
  bcc 1f
    Fehler_Quit "hflash! needs even addresses."
1:

  @ Check if address is outside of Forth core
  ldr r3, =Kernschutzadresse
  cmp tos, r3
  blo 2f

  @ Fine !
  ldr r0, =hook_h_flashkomma
  ldr r0, [r0]
  mov pc, r0
  
2:Fehler_Quit "Cannot write into core !"

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "flushflash" @ ( -- )
flushflash:
@------------------------------------------------------------------------------
  ldr r0, =hook_flushflash
  ldr r0, [r0]
  mov pc, r0
