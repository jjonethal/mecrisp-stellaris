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

.word returnstackanfang         @ 00: Stack top address
.word Reset                 + 1 @ 01: Reset Vector  +1 wegen des Thumb-Einsprunges

.word faulthandler          + 1 @ 02: The NMI handler
.word faulthandler          + 1 @ 03: The hard fault handler
.word 0                         @ 04: The MPU fault handler
.word 0                         @ 05: Reserved
.word 0                         @ 06: Reserved
.word 0                         @ 07: Reserved
.word 0                         @ 08: Reserved
.word 0                         @ 09: Reserved
.word 0                         @ 10: Reserved
.word irq_vektor_svcall     + 1 @ 11: SVCall handler
.word 0                         @ 12: Reserved
.word 0                         @ 13: Reserved
.word irq_vektor_pendsv     + 1 @ 14: The PendSV handler
.word irq_vektor_systick    + 1 @ 15: The SysTick handler

@ Special interrupt handlers for this particular chip:

@ On RP2040, only the lower 26 IRQ signals are connected on the NVIC, and IRQs 26 to 31 are tied to zero (never firing).
@ The core can still be forced to enter the relevant interrupt handler by writing bits 26 to 31 in the NVIC ISPR register.

.word irq_vektor_TIMER_0    + 1 @ Position  0: TIMER_IRQ_0
.word irq_vektor_TIMER_1    + 1 @ Position  1: TIMER_IRQ_1
.word irq_vektor_TIMER_2    + 1 @ Position  2: TIMER_IRQ_2
.word irq_vektor_TIMER_3    + 1 @ Position  3: TIMER_IRQ_3
.word irq_vektor_PWM_WRAP   + 1 @ Position  4: PWM_IRQ_WRAP
.word irq_vektor_USBCTRL    + 1 @ Position  5: USBCTRL_IRQ
.word irq_vektor_XIP        + 1 @ Position  6: XIP_IRQ
.word irq_vektor_PIO0_0     + 1 @ Position  7: PIO0_IRQ_0
.word irq_vektor_PIO0_1     + 1 @ Position  8: PIO0_IRQ_1
.word irq_vektor_PIO1_0     + 1 @ Position  9: PIO1_IRQ_0
.word irq_vektor_PIO1_1     + 1 @ Position 10: PIO1_IRQ_1
.word irq_vektor_DMA_0      + 1 @ Position 11: DMA_IRQ_0
.word irq_vektor_DMA_1      + 1 @ Position 12: DMA_IRQ_1
.word irq_vektor_IO_BANK0   + 1 @ Position 13: IO_IRQ_BANK0
.word irq_vektor_IO_QSPI    + 1 @ Position 14: IO_IRQ_QSPI
.word irq_vektor_SIO_PROC0  + 1 @ Position 15: SIO_IRQ_PROC0
.word irq_vektor_SIO_PROC1  + 1 @ Position 16: SIO_IRQ_PROC1
.word irq_vektor_CLOCKS     + 1 @ Position 17: CLOCKS_IRQ
.word irq_vektor_SPI0       + 1 @ Position 18: SPI0_IRQ
.word irq_vektor_SPI1       + 1 @ Position 19: SPI1_IRQ
.word irq_vektor_UART0      + 1 @ Position 20: UART0_IRQ
.word irq_vektor_UART1      + 1 @ Position 21: UART1_IRQ
.word irq_vektor_ADC_FIFO   + 1 @ Position 22: ADC_IRQ_FIFO
.word irq_vektor_I2C0       + 1 @ Position 23: I2C0_IRQ
.word irq_vektor_I2C1       + 1 @ Position 24: I2C1_IRQ
.word irq_vektor_RTC        + 1 @ Position 25: RTC_IRQ

.word nullhandler           + 1 @ Position 26: Reserved
.word nullhandler           + 1 @ Position 27: Reserved
.word nullhandler           + 1 @ Position 28: Reserved
.word nullhandler           + 1 @ Position 29: Reserved
.word nullhandler           + 1 @ Position 30: Reserved
.word nullhandler           + 1 @ Position 31: Reserved

@ -----------------------------------------------------------------------------
