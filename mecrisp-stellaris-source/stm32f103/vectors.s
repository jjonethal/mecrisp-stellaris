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

.word nullhandler+1 @ Position  0: Window Watchdog
.word nullhandler+1 @ Position  1: PVD through EXTI line detection
.word nullhandler+1 @ Position  2: Tamper and TimeStamp through EXTI line
.word nullhandler+1 @ Position  3: RTC Wakeup
.word nullhandler+1 @ Position  4: Flash
.word nullhandler+1 @ Position  5: RCC
.word irq_vektor_exti0+1 @ Position  6: EXTI Line 0
.word irq_vektor_exti1+1 @ Position  7: EXTI Line 1
.word irq_vektor_exti2+1 @ Position  8: EXTI Line 2
.word irq_vektor_exti3+1 @ Position  9: EXTI Line 3
.word irq_vektor_exti4+1 @ Position 10: EXTI Line 4
.word nullhandler+1 @ Position 11: DMA1 Stream 0
.word nullhandler+1 @ Position 12: DMA1 Stream 1
.word nullhandler+1 @ Position 13: DMA1 Stream 2
.word nullhandler+1 @ Position 14: DMA1 Stream 3
.word nullhandler+1 @ Position 15: DMA1 Stream 4
.word nullhandler+1 @ Position 16: DMA1 Stream 5
.word nullhandler+1 @ Position 17: DMA1 Stream 6
.word irq_vektor_adc+1 @ Position 18: ADC global interrupts

.word nullhandler+1 @ Position 19:
.word nullhandler+1 @ Position 20:
.word nullhandler+1 @ Position 21:
.word nullhandler+1 @ Position 22:
.word nullhandler+1 @ Position 23:
.word nullhandler+1 @ Position 24:
.word nullhandler+1 @ Position 25:
.word nullhandler+1 @ Position 26:
.word nullhandler+1 @ Position 27:
.word nullhandler+1 @ Position 28:
.word nullhandler+1 @ Position 29:
.word nullhandler+1 @ Position 30:
.word nullhandler+1 @ Position 31:
.word nullhandler+1 @ Position 32:
.word nullhandler+1 @ Position 33:
.word nullhandler+1 @ Position 34:
.word nullhandler+1 @ Position 35:
.word nullhandler+1 @ Position 36:
.word nullhandler+1 @ Position 37:
.word nullhandler+1 @ Position 38:
.word nullhandler+1 @ Position 39:
.word nullhandler+1 @ Position 40:
.word nullhandler+1 @ Position 41:
.word nullhandler+1 @ Position 42:

.word 0  @ 43: Reserved
.word 0  @ 44: Reserved
.word 0  @ 45: Reserved
.word 0  @ 46: Reserved
.word 0  @ 47: Reserved
.word 0  @ 48: Reserved
.word 0  @ 49: Reserved

.word nullhandler+1 @ Position 50:
.word nullhandler+1 @ Position 51:
.word nullhandler+1 @ Position 52:
.word nullhandler+1 @ Position 53:
.word nullhandler+1 @ Position 54:
.word nullhandler+1 @ Position 55:
.word nullhandler+1 @ Position 56:
.word nullhandler+1 @ Position 57:
.word nullhandler+1 @ Position 58:
.word nullhandler+1 @ Position 59:
.word nullhandler+1 @ Position 60:
.word nullhandler+1 @ Position 61:
.word nullhandler+1 @ Position 62:
.word nullhandler+1 @ Position 63:
.word nullhandler+1 @ Position 64:
.word nullhandler+1 @ Position 65:
.word nullhandler+1 @ Position 66:
.word nullhandler+1 @ Position 67:

@ -----------------------------------------------------------------------------
