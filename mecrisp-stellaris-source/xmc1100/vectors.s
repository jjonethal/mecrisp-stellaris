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

@ -----------------------------------------------------------------------------
@ Interruptvektortabelle
@ -----------------------------------------------------------------------------

.equ addresszero, . @ This is needed to circumvent address relocation issues.

.word returnstackanfang  @ 10001000: Stack top address
.word Reset+1            @ 10001004: Reset Vector  +1 for Thumb entry

.word 0xFFFFFFFF  @ 10001008
.word 0xFFFFFFFF  @ 1000100C
.word 0xFFFFFFFF  @ 10001010  @ CLK_VAL1  --> SCU_CLKCR    if Bit 31 is zero.
.word 0x00000008  @ 10001014  @ CLK_VAL2  --> SCU_CGATCLR0 if Bit 31 is zero.


@ Interrupt handlers are strangely remapped into RAM by a fixed "Startup ROM".
@ Actual vector table and interrupt handling are quite different from other chips.

@ -----------------------------------------------------------------------------
