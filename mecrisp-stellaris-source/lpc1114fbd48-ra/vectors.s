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

.word nullhandler+1 @ Position 00: PIO0_0
.word nullhandler+1 @ Position 01: PIO0_1
.word nullhandler+1 @ Position 02: PIO0_2
.word nullhandler+1 @ Position 03: PIO0_3
.word nullhandler+1 @ Position 04: PIO0_4
.word nullhandler+1 @ Position 05: PIO0_5
.word nullhandler+1 @ Position 06: PIO0_6
.word nullhandler+1 @ Position 07: PIO0_7
.word nullhandler+1 @ Position 08: PIO0_8
.word nullhandler+1 @ Position 09: PIO0_9
.word nullhandler+1 @ Position 10: PIO0_10
.word nullhandler+1 @ Position 11: PIO0_11
.word nullhandler+1 @ Position 12: PIO1_0
.word nullhandler+1 @ Position 13: RESERVED
.word nullhandler+1 @ Position 14: SSP1
.word irq_vektor_i2c+1 @ Position 15: I2C
.word nullhandler+1 @ Position 16: CT16B0
.word nullhandler+1 @ Position 17: CT16B1
.word nullhandler+1 @ Position 18: CT32B0
.word nullhandler+1 @ Position 19: CT32B1
.word nullhandler+1 @ Position 20: SSP0
.word irq_vektor_uart+1 @ Position 21: UART
.word nullhandler+1 @ Position 22: RESERVED
.word nullhandler+1 @ Position 23: RESERVED
.word irq_vektor_adc+1 @ Position 24: ADC
.word nullhandler+1 @ Position 25: WDT
.word nullhandler+1 @ Position 26: BOD
.word nullhandler+1 @ Position 27: RESERVED
.word nullhandler+1 @ Position 28: PIO3
.word nullhandler+1 @ Position 29: PIO2
.word nullhandler+1 @ Position 30: PIO1
.word nullhandler+1 @ Position 31: PIO0

.org 0x300, 0xFFFFFFFF @ Disable Code Read protection field at address 2FC !

@ -----------------------------------------------------------------------------
