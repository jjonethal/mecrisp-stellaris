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

.word nullhandler+1 @ Position  0:  Real Time Clock 1/Wakeup Timer/Hibernate RTC/ LFXTAL Clock Failure
.word nullhandler+1 @ Position  1:  External Interrupt 0
.word nullhandler+1 @ Position  2:  External Interrupt 1
.word nullhandler+1 @ Position  3:  External Interrupt 2
.word nullhandler+1 @ Position  4:  External Interrupt 3/ UART0_RX_Wakeup
.word irq_vektor_watchdog+1 @ Position  5:  Watchdog Timer
.word nullhandler+1 @ Position  6:  VREG Over
.word nullhandler+1 @ Position  7:  Battery Voltage Range
.word nullhandler+1 @ Position  8:  Real Time Clock 0
.word irq_vektor_gpioa+1 @ Position  9:  GPIO IntA
.word irq_vektor_gpiob+1 @ Position 10:  GPIO IntB
.word irq_vektor_timer0+1 @ Position 11:  General Purpose Timer 0
.word irq_vektor_timer1+1 @ Position 12:  General Purpose Timer 1
.word nullhandler+1 @ Position 13:  Flash Controller
.word nullhandler+1 @ Position 14:  UART0
.word nullhandler+1 @ Position 15:  SPI0
.word nullhandler+1 @ Position 16:  SPI2
.word nullhandler+1 @ Position 17:  I2C0 Slave
.word nullhandler+1 @ Position 18:  I2C0 Master
.word nullhandler+1 @ Position 19:  DMA Error
.word nullhandler+1 @ Position 20:  DMA Channel 0 Done
.word nullhandler+1 @ Position 21:  DMA Channel 1 Done
.word nullhandler+1 @ Position 22:  DMA Channel 2 Done
.word nullhandler+1 @ Position 23:  DMA Channel 3 Done
.word nullhandler+1 @ Position 24:  DMA Channel 4 Done
.word nullhandler+1 @ Position 25:  DMA Channel 5 Done
.word nullhandler+1 @ Position 26:  DMA Channel 6 Done
.word nullhandler+1 @ Position 27:  DMA Channel 7 Done
.word nullhandler+1 @ Position 28:  DMA Channel 8 Done
.word nullhandler+1 @ Position 29:  DMA Channel 9 Done
.word nullhandler+1 @ Position 30:  DMA Channel 10 Done
.word nullhandler+1 @ Position 31:  DMA Channel 11 Done
.word nullhandler+1 @ Position 32:  DMA Channel 12 Done
.word nullhandler+1 @ Position 33:  DMA Channel 13 Done
.word nullhandler+1 @ Position 34:  DMA Channel 14 Done
.word nullhandler+1 @ Position 35:  DMA Channel 15 Done
.word nullhandler+1 @ Position 36:  SPORT0A
.word nullhandler+1 @ Position 37:  SPORT0B
.word nullhandler+1 @ Position 38:  Crypto
.word nullhandler+1 @ Position 39:  DMA Channel 24 Done
.word nullhandler+1 @ Position 40:  General Purpose Timer 2
.word nullhandler+1 @ Position 41:  Crystal Oscillator
.word nullhandler+1 @ Position 42:  SPI1
.word nullhandler+1 @ Position 43:  PLL
.word nullhandler+1 @ Position 44:  Random Number Generator
.word nullhandler+1 @ Position 45:  Beeper
.word irq_vektor_adc+1 @ Position 46:  ADC
.word 0x00000000    @ Position 47:    Reserved
.word 0x00000000    @ Position 48:    Reserved
.word 0x00000000    @ Position 49:    Reserved
.word 0x00000000    @ Position 50:    Reserved
.word 0x00000000    @ Position 51:    Reserved
.word 0x00000000    @ Position 52:    Reserved
.word 0x00000000    @ Position 53:    Reserved
.word 0x00000000    @ Position 54:    Reserved
.word 0x00000000    @ Position 55:    Reserved
.word nullhandler+1 @ Position 56:  DMA Channel 16 Done
.word nullhandler+1 @ Position 57:  DMA Channel 17 Done
.word nullhandler+1 @ Position 58:  DMA Channel 18 Done
.word nullhandler+1 @ Position 59:  DMA Channel 19 Done
.word nullhandler+1 @ Position 60:  DMA Channel 20 Done
.word nullhandler+1 @ Position 61:  DMA Channel 21 Done
.word nullhandler+1 @ Position 62:  DMA Channel 22 Done
.word nullhandler+1 @ Position 63:  DMA Channel 23 Done
.word 0x00000000    @ Position 64:    Reserved
.word 0x00000000    @ Position 65:    Reserved
.word nullhandler+1 @ Position 66:  UART1
.word nullhandler+1 @ Position 67:  DMA Channel 25 Done
.word nullhandler+1 @ Position 68:  DMA Channel 26 Done
.word nullhandler+1 @ Position 69:  Timer RGB
.word 0x00000000    @ Position 70:    Reserved
.word nullhandler+1 @ Position 71:  Root Clock Failure

@ Take care of the flash FLCC_WRPROT.WORD at address 0x0000019C. It MUST be $FFFF FFFF in order not to lock us out.

.org 0x180, 0x00000000 @ Advance to the sensitive fields

.word 0xFFFFFFFF @ Security options
.word 0xFFFFFFFF
.word 0xFFFFFFFF
.word 0xFFFFFFFF
.word 0xA79C3203
.word 0x00000000 @ LASTCRCPAGE
.word 0xFFFFFFFF
.word 0xFFFFFFFF

.org 0x800, 0xFFFFFFFF @ and fill the complete 2 kb flash page.

@ MBED examples start at $0000 0800, too.

@ -----------------------------------------------------------------------------
