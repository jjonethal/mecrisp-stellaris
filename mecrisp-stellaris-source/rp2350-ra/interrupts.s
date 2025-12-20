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

interrupt TIMER0_IRQ_0
interrupt TIMER0_IRQ_1
interrupt TIMER0_IRQ_2
interrupt TIMER0_IRQ_3
interrupt TIMER1_IRQ_0
interrupt TIMER1_IRQ_1
interrupt TIMER1_IRQ_2
interrupt TIMER1_IRQ_3
interrupt PWM_IRQ_WRAP_0
interrupt PWM_IRQ_WRAP_1
interrupt DMA_IRQ_0
interrupt DMA_IRQ_1
interrupt DMA_IRQ_2
interrupt DMA_IRQ_3
interrupt USBCTRL_IRQ
.ltorg
interrupt PIO0_IRQ_0
interrupt PIO0_IRQ_1
interrupt PIO1_IRQ_0
interrupt PIO1_IRQ_1
interrupt PIO2_IRQ_0
interrupt PIO2_IRQ_1
interrupt IO_IRQ_BANK0
interrupt IO_IRQ_BANK0_NS
interrupt IO_IRQ_QSPI
interrupt IO_IRQ_QSPI_NS
interrupt SIO_IRQ_FIFO
interrupt SIO_IRQ_BELL
interrupt SIO_IRQ_FIFO_NS
interrupt SIO_IRQ_BELL_NS
interrupt SIO_IRQ_MTIMECMP
interrupt CLOCKS_IRQ
.ltorg
interrupt SPI0_IRQ
interrupt SPI1_IRQ
interrupt UART0_IRQ
interrupt UART1_IRQ
interrupt ADC_IRQ_FIFO
interrupt I2C0_IRQ
interrupt I2C1_IRQ
interrupt OTP_IRQ
interrupt TRNG_IRQ
interrupt PROC0_IRQ_CTI
interrupt PROC1_IRQ_CTI
interrupt PLL_SYS_IRQ
interrupt PLL_USB_IRQ
interrupt POWMAN_IRQ_POW
interrupt POWMAN_IRQ_TIMER
interrupt SPAREIRQ_IRQ_0
interrupt SPAREIRQ_IRQ_1
interrupt SPAREIRQ_IRQ_2
interrupt SPAREIRQ_IRQ_3
interrupt SPAREIRQ_IRQ_4
interrupt SPAREIRQ_IRQ_5

.ltorg

@------------------------------------------------------------------------------

