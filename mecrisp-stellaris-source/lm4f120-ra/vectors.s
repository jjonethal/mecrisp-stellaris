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

.word irq_vektor_porta+1   @ 16: GPIO Port A
.word irq_vektor_portb+1   @ 17: GPIO Port B
.word irq_vektor_portc+1   @ 18: GPIO Port C
.word irq_vektor_portd+1   @ 19: GPIO Port D
.word irq_vektor_porte+1   @ 20: GPIO Port E
.word irq_vektor_terminal+1   @ 21: UART0 Rx and Tx
.word nullhandler+1   @ 22: UART1 Rx and Tx
.word nullhandler+1   @ 23: SSI0 Rx and Tx
.word nullhandler+1   @ 24: I2C0 Master and Slave

.word 0  @ 25: Reserved
.word 0  @ 26: Reserved
.word 0  @ 27: Reserved
.word 0  @ 28: Reserved
.word 0  @ 29: Reserved

.word irq_vektor_adc0seq0+1   @ 30: ADC Sequence 0
.word irq_vektor_adc0seq1+1   @ 31: ADC Sequence 1
.word irq_vektor_adc0seq2+1   @ 32: ADC Sequence 2
.word irq_vektor_adc0seq3+1   @ 33: ADC Sequence 3

.word nullhandler+1   @ 34: Watchdog timers 0 and 1

.word irq_vektor_timer0a+1   @ 35: Timer 0 subtimer A
.word irq_vektor_timer0b+1   @ 36: Timer 0 subtimer B
.word irq_vektor_timer1a+1   @ 37: Timer 1 subtimer A
.word irq_vektor_timer1b+1   @ 38: Timer 1 subtimer B
.word irq_vektor_timer2a+1   @ 39: Timer 2 subtimer A
.word irq_vektor_timer2b+1   @ 40: Timer 2 subtimer B

.word nullhandler+1   @ 41: Analog Comparator 0
.word nullhandler+1   @ 42: Analog Comparator 1

.word 0  @ 43: Reserved

.word nullhandler+1   @ 44: System Control (PLL, OSC, BO)
.word nullhandler+1   @ 45: FLASH Control

.word irq_vektor_portf+1   @ 46: GPIO Port F


.word 0  @ 47: Reserved
.word 0  @ 48: Reserved
.word nullhandler+1   @ 49:
.word nullhandler+1   @ 50:
.word nullhandler+1   @ 51:
.word nullhandler+1   @ 52:
.word nullhandler+1   @ 53:
.word 0  @ 54: Reserved
.word nullhandler+1   @ 55:
.word 0  @ 56: Reserved
.word 0  @ 57: Reserved
.word 0  @ 58: Reserved
.word nullhandler+1   @ 59:
.word nullhandler+1   @ 60:
.word 0  @ 61: Reserved

.word nullhandler+1   @ 62:
.word nullhandler+1   @ 63:
.word nullhandler+1   @ 64:
.word nullhandler+1   @ 65:
.word nullhandler+1   @ 66:
.word nullhandler+1   @ 67:

.word 0  @ 68: Reserved
.word 0  @ 69: Reserved
.word 0  @ 70: Reserved
.word 0  @ 71: Reserved
.word 0  @ 72: Reserved

.word nullhandler+1   @ 73:
.word nullhandler+1   @ 74:
.word nullhandler+1   @ 75:
.word nullhandler+1   @ 76:
.word nullhandler+1   @ 77:
.word nullhandler+1   @ 78:
.word nullhandler+1   @ 79:

.word 0  @ 80: Reserved
.word 0  @ 81: Reserved
.word 0  @ 82: Reserved
.word 0  @ 83: Reserved

.word nullhandler+1   @ 84:
.word nullhandler+1   @ 85:
.word nullhandler+1   @ 86:
.word nullhandler+1   @ 87:

.word 0  @ 88: Reserved
.word 0  @ 89: Reserved
.word 0  @ 90: Reserved
.word 0  @ 91: Reserved
.word 0  @ 92: Reserved
.word 0  @ 93: Reserved
.word 0  @ 94: Reserved
.word 0  @ 95: Reserved
.word 0  @ 96: Reserved
.word 0  @ 97: Reserved
.word 0  @ 98: Reserved
.word 0  @ 99: Reserved
.word 0  @ 100: Reserved
.word 0  @ 101: Reserved
.word 0  @ 102: Reserved
.word 0  @ 103: Reserved
.word 0  @ 104: Reserved
.word 0  @ 105: Reserved
.word 0  @ 106: Reserved
.word 0  @ 107: Reserved

.word nullhandler+1   @ 108:
.word nullhandler+1   @ 109:
.word nullhandler+1   @ 110:
.word nullhandler+1   @ 111:
.word nullhandler+1   @ 112:
.word nullhandler+1   @ 113:
.word nullhandler+1   @ 114:
.word nullhandler+1   @ 115:
.word nullhandler+1   @ 116:
.word nullhandler+1   @ 117:
.word nullhandler+1   @ 118:
.word nullhandler+1   @ 119:
.word nullhandler+1   @ 120:
.word nullhandler+1   @ 121:
.word nullhandler+1   @ 122:

@ 123-154 reserved, space can be used for core instead.

@ -----------------------------------------------------------------------------
