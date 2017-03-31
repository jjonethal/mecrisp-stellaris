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

.word nullhandler+1 @ Position  0: Supply Controller
.word nullhandler+1 @ Position  1: Reset Controller
.word nullhandler+1 @ Position  2: Real Time Clock
.word nullhandler+1 @ Position  3: Real Time Timer
.word nullhandler+1 @ Position  4: Watchdog Timer
.word nullhandler+1 @ Position  5: Power Management Controller
.word nullhandler+1 @ Position  6: Enhanced Embedded Flash Controller
.word nullhandler+1 @ Position  7: UART0
.word nullhandler+1 @ Position  8: UART1
.word nullhandler+1 @ Position  9: unused
.word irq_vektor_pioa+1 @ Position 10: PIOA

.word irq_vektor_piob+1 @ Position 11: PIOB
.word irq_vektor_pioc+1 @ Position 12: PIOC
.word irq_vektor_usart0+1 @ Position 13: USART0
.word irq_vektor_usart1+1 @ Position 14: USART1
.word irq_vektor_usart2+1 @ Position 15: USART2
.word irq_vektor_piod+1 @ Position 16: PIOD
.word irq_vektor_pioe+1 @ Position 17: PIOE
.word irq_vektor_hsmci+1 @ Position 18: HSMCI
.word irq_vektor_twihs0+1 @ Position 19: TWIHS0
.word irq_vektor_twihs1+1 @ Position 20: TWIHS1

.word irq_vektor_spi0+1 @ Position 21: SPI0
.word nullhandler+1 @ Position 22: SSC
.word nullhandler+1 @ Position 23: TC0
.word nullhandler+1 @ Position 24: TC1
.word nullhandler+1 @ Position 25: TC2
.word nullhandler+1 @ Position 26: TC3
.word nullhandler+1 @ Position 27: TC4
.word nullhandler+1 @ Position 28: TC5
.word irq_vektor_afec0+1 @ Position 29: Analog Front End Controller 0

.word irq_vektor_dacc+1 @ Position 30: Digital To Analog Convertor
.word irq_vektor_pwm0+1 @ Position 31: PWM0
.word nullhandler+1 @ Position 32: Integrity Check Monitor
.word nullhandler+1 @ Position 33: Analog Comparator Controller
.word nullhandler+1 @ Position 34: USBHS
.word nullhandler+1 @ Position 35: CAN0 irq line 0
.word nullhandler+1 @ Position 36: CAN0 irq line 1
.word nullhandler+1 @ Position 37: CAN1 irq line 0
.word nullhandler+1 @ Position 38: CAN1 irq line 1
.word nullhandler+1 @ Position 39: Ethernet MAC

.word irq_vektor_afec1+1 @ Position 40: Analog Front End Controller 1
.word irq_vektor_twihs2+1 @ Position 41: TWIHS2
.word irq_vektor_spi1+1 @ Position 42: SPI1
.word nullhandler+1 @ Position 43: QSPI
.word nullhandler+1 @ Position 44: UART2
.word nullhandler+1 @ Position 45: UART3
.word nullhandler+1 @ Position 46: UART4
.word nullhandler+1 @ Position 47: TC6
.word nullhandler+1 @ Position 48: TC7
.word nullhandler+1 @ Position 49: TC8

.word nullhandler+1 @ Position 50: TC9
.word nullhandler+1 @ Position 51: TC10
.word nullhandler+1 @ Position 52: TC11
.word nullhandler+1 @ Position 53: RESERVED
.word nullhandler+1 @ Position 54: RESERVED
.word nullhandler+1 @ Position 55: RESERVED
.word nullhandler+1 @ Position 56: AES
.word irq_vektor_trng+1 @ Position 57: True Random Number Generator
.word nullhandler+1 @ Position 58: DMA Controller
.word nullhandler+1 @ Position 59: Image Sensor Controller

.word irq_vektor_pwm1+1 @ Position 60: PWM1
.word nullhandler+1 @ Position 61: ARM Floating Point Unit
.word nullhandler+1 @ Position 62: unused
.word nullhandler+1 @ Position 63: Reinforced Safety Watchdog Timer
.word nullhandler+1 @ Position 64: ARM Cache ECC Warning
.word nullhandler+1 @ Position 65: ARM Cache ECC Fault
.word nullhandler+1 @ Position 66: GMAC Queue1
.word nullhandler+1 @ Position 67: GMAC Queue2
.word nullhandler+1 @ Position 68: ARM Floating Point 
.word nullhandler+1 @ Position 69: I2SC0 Inter-IC Sound Controller 0

.word nullhandler+1 @ Position 70: I2SC1 Inter-IC Sound Controller 1


@ -----------------------------------------------------------------------------
