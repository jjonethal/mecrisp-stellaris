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

.word nullhandler+1 @ Position 00:  DMA channel 0 transfer complete
.word nullhandler+1 @ Position 01:  DMA channel 1 transfer complete
.word nullhandler+1 @ Position 02:  DMA channel 2 transfer complete
.word nullhandler+1 @ Position 03:  DMA channel 3 transfer complete
.word nullhandler+1 @ Position 04:  DMA channel 4 transfer complete
.word nullhandler+1 @ Position 05:  DMA channel 5 transfer complete
.word nullhandler+1 @ Position 06:  DMA channel 6 transfer complete
.word nullhandler+1 @ Position 07:  DMA channel 7 transfer complete
.word nullhandler+1 @ Position 08:  DMA channel 8 transfer complete
.word nullhandler+1 @ Position 09:  DMA channel 9 transfer complete
.word nullhandler+1 @ Position 10:  DMA channel 10 transfer complete
.word nullhandler+1 @ Position 11:  DMA channel 11 transfer complete
.word nullhandler+1 @ Position 12:  DMA channel 12 transfer complete
.word nullhandler+1 @ Position 13:  DMA channel 13 transfer complete
.word nullhandler+1 @ Position 14:  DMA channel 14 transfer complete
.word nullhandler+1 @ Position 15:  DMA channel 15 transfer complete
.word nullhandler+1 @ Position 16:  DMA error interrupt channels 0-15
.word nullhandler+1 @ Position 17:  MCM interrupt
.word nullhandler+1 @ Position 18:  Command complete
.word nullhandler+1 @ Position 19:  Read collision
.word nullhandler+1 @ Position 20:  Low-voltage detect, low-voltage warning
.word nullhandler+1 @ Position 21:  Low Leakage Wakeup
.word nullhandler+1 @ Position 22:  Watchdog
.word nullhandler+1 @ Position 23:  Random Number Generator
.word nullhandler+1 @ Position 24:  I2C0
.word nullhandler+1 @ Position 25:  I2C1
.word nullhandler+1 @ Position 26:  SPI0
.word nullhandler+1 @ Position 27:  SPI1
.word nullhandler+1 @ Position 28:  I2S0
.word nullhandler+1 @ Position 29:  I2S0
.word nullhandler+1 @ Position 30:  ---
.word nullhandler+1 @ Position 31:  UART0 Status
.word nullhandler+1 @ Position 32:  UART0 Error
.word nullhandler+1 @ Position 33:  UART1 Status
.word nullhandler+1 @ Position 34:  UART1 Error
.word nullhandler+1 @ Position 35:  UART2 Status
.word nullhandler+1 @ Position 36:  UART2 Error
.word nullhandler+1 @ Position 37:  UART3 Status
.word nullhandler+1 @ Position 38:  UART3 Error
.word irq_vektor_adc0+1 @ Position 39:  ADC0
.word irq_vektor_cmp0+1 @ Position 40:  CMP0
.word irq_vektor_cmp1+1 @ Position 41:  CMP1
.word nullhandler+1 @ Position 42:  FTM0
.word nullhandler+1 @ Position 43:  FTM1
.word nullhandler+1 @ Position 44:  FTM2
.word nullhandler+1 @ Position 45:  CMT
.word nullhandler+1 @ Position 46:  RTC Alarm
.word nullhandler+1 @ Position 47:  RTC Seconds
.word nullhandler+1 @ Position 48:  PIT Channel 0
.word nullhandler+1 @ Position 49:  PIT Channel 1
.word nullhandler+1 @ Position 50:  PIT Channel 2
.word nullhandler+1 @ Position 51:  PIT Channel 3
.word nullhandler+1 @ Position 52:  PDB
.word nullhandler+1 @ Position 53:  USB OTG
.word nullhandler+1 @ Position 54:  USB Charger Detect
.word nullhandler+1 @ Position 55:  ---
.word irq_vektor_dac0 @ Position 56:  DAC0
.word nullhandler+1 @ Position 57:  MCG
.word nullhandler+1 @ Position 58:  Low Power Timer
.word irq_vektor_porta+1 @ Position 59:  Pin detect (Port A)
.word irq_vektor_portb+1 @ Position 60:  Pin detect (Port B)
.word irq_vektor_portc+1 @ Position 61:  Pin detect (Port C)
.word irq_vektor_portd+1 @ Position 62:  Pin detect (Port D)
.word irq_vektor_porte+1 @ Position 63:  Pin detect (Port E)
.word nullhandler+1 @ Position 64:  Software Interrupt
.word nullhandler+1 @ Position 65:  SPI2
.word nullhandler+1 @ Position 66:  UART4 Status
.word nullhandler+1 @ Position 67:  UART4 Error
.word nullhandler+1 @ Position 68:  UART5 Status
.word nullhandler+1 @ Position 69:  UART5 Error
.word irq_vektor_cmp2+1 @ Position 70:  CMP2
.word nullhandler+1 @ Position 71:  FTM3
.word irq_vektor_dac1+1 @ Position 72:  DAC1
.word irq_vektor_adc1+1 @ Position 73:  ADC1
.word nullhandler+1 @ Position 74:  I2C2
.word nullhandler+1 @ Position 75:  CAN0 OR'ed Message buffer (0-15)
.word nullhandler+1 @ Position 76:  CAN0 Bus Off
.word nullhandler+1 @ Position 77:  CAN0 Error
.word nullhandler+1 @ Position 78:  CAN0 Transmit Warning
.word nullhandler+1 @ Position 79:  CAN0 Receive Warning
.word nullhandler+1 @ Position 80:  CAN0 Wake Up
.word nullhandler+1 @ Position 81:  SDHC
.word nullhandler+1 @ Position 82:  Ethernet MAC IEEE 1588 Timer Interrupt
.word nullhandler+1 @ Position 83:  Ethernet MAC Transmit interrupt
.word nullhandler+1 @ Position 84:  Ethernet MAC Receive interrupt
.word nullhandler+1 @ Position 85:  Ethernet MAC Error and miscellaneous interrupt

@ See page 53 in manual

@  VECTORS (rx)      : ORIGIN = 0x0,         LENGTH = 0x00c0
@  FLASHCFG (rx)     : ORIGIN = 0x00000400,  LENGTH = 0x00000010
@  FLASH (rx)        : ORIGIN = 0x00000410,  LENGTH = 128K - 0x410
@  RAM  (rwx)        : ORIGIN = 0x1FFFF000,  LENGTH = 16K


@ Flash configuration field (loaded into flash memory at 0x400)
.org 0x400, 0xFFFFFFFF @ Advance to Flash Configuration Field (FCF)

.word 0xFFFFFFFF
.word 0xFFFFFFFF
.word 0xFFFFFFFF
.word 0xFFFFFDFE

@ Start for real code !

@ -----------------------------------------------------------------------------
