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

@ Routinen für die Interrupthandler, die zur Laufzeit neu gesetzt werden können.
@ Code for interrupt handlers that are exchangeable on the fly

@------------------------------------------------------------------------------
@ Alle Interrupthandler funktionieren gleich und werden komfortabel mit einem Makro erzeugt:
@ All interrupt handlers work the same way and are generated with a macro:
@------------------------------------------------------------------------------

interrupt svcall
interrupt pendsv

interrupt TIMER_0
interrupt TIMER_1
interrupt TIMER_2
interrupt TIMER_3
interrupt PWM_WRAP
interrupt USBCTRL
interrupt XIP
interrupt PIO0_0
interrupt PIO0_1
interrupt PIO1_0
interrupt PIO1_1
interrupt DMA_0
interrupt DMA_1

.ltorg

interrupt IO_BANK0
interrupt IO_QSPI
interrupt SIO_PROC0
interrupt SIO_PROC1
interrupt CLOCKS
interrupt SPI0
interrupt SPI1
interrupt UART0
interrupt UART1
interrupt ADC_FIFO
interrupt I2C0
interrupt I2C1
interrupt RTC

.ltorg

@------------------------------------------------------------------------------

