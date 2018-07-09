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

.include "../common/vectors-common.s"

@ Special interrupt handlers for this particular chip:

.word nullhandler+1            @ Position  0: Low V. Detect
.word nullhandler+1            @ Position  1: Cache
.word 0                        @           2: Reserved
.word nullhandler+1            @ Position  3: Pwr Mgr
.word nullhandler+1            @ Position  4: PICU0
.word nullhandler+1            @ Position  5: PICU1
.word nullhandler+1            @ Position  6: PICU2
.word nullhandler+1            @ Position  7: PICU3
.word nullhandler+1            @ Position  8: PICU4
.word nullhandler+1            @ Position  9: PICU5
.word nullhandler+1            @ Position 10: PICU6
.word nullhandler+1            @ Position 11: PICU12
.word nullhandler+1            @ Position 12: PICU15
.word nullhandler+1            @ Position 13: Comparators
.word nullhandler+1            @ Position 14: Sw. Caps
.word nullhandler+1            @ Position 15: I2C
.word 0                        @          16: Reserved
.word 0                        @          17: Reserved
.word 0                        @          18: Reserved
.word 0                        @          19: Reserved
.word 0                        @          20: Reserved
.word nullhandler+1            @ Position 21: USB SOF
.word nullhandler+1            @ Position 22: USB Arb
.word nullhandler+1            @ Position 23: USB Bus
.word nullhandler+1            @ Position 24: USB EP0
.word nullhandler+1            @ Position 25: USB EP Data
.word 0                        @          26: Reserved
.word 0                        @          27: Reserved
.word nullhandler+1            @ Position 28: DFB
.word nullhandler+1            @ Position 29: Decimator
.word nullhandler+1            @ Position 30: phub_err
.word nullhandler+1            @ Position 31: eeprom_fault
@ .word nullhandler+1            @ Position 32:
@ .word nullhandler+1            @ Position 33:
@ .word nullhandler+1            @ Position 34:
@ .word nullhandler+1            @ Position 35:
@ .word nullhandler+1            @ Position 36:
@ .word nullhandler+1            @ Position 37:
@ .word nullhandler+1            @ Position 38:
@ .word nullhandler+1            @ Position 39:
@ .word nullhandler+1            @ Position 40:
@ .word nullhandler+1            @ Position 41:
@ .word nullhandler+1            @ Position 42:
@ .word nullhandler+1            @ Position 43:
@ .word nullhandler+1            @ Position 44:
@ .word nullhandler+1            @ Position 45:

@ .word 0  @ 46: Reserved
@ .word 0  @ 47: Reserved
@ .word nullhandler+1 @ Position 48:
@ .word 0  @ 49: Reserved
@ 
@ .word nullhandler+1 @ Position 50:
@ .word nullhandler+1 @ Position 51:
@ .word nullhandler+1 @ Position 52:
@ .word nullhandler+1 @ Position 53:
@ .word nullhandler+1 @ Position 54:
@ .word nullhandler+1 @ Position 55:
@ .word nullhandler+1 @ Position 56:
@ .word nullhandler+1 @ Position 57:
@ .word nullhandler+1 @ Position 58:
@ .word nullhandler+1 @ Position 59:
@ .word nullhandler+1 @ Position 60:

@ -----------------------------------------------------------------------------
