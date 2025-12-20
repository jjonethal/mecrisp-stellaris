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
.global Interruptvektortabelle
Interruptvektortabelle:
.GLOBAL returnstackanfang
.word returnstackanfang         @ 00: Stack top address
.word Reset                 + 1 @ 01: Reset Vector  +1 wegen des Thumb-Einsprunges
.word faulthandler          + 1 @ 02: The NMI handler
.word faulthandler          + 1 @ 03: The hard fault handler
.word 0                         @ 04: The MPU fault handler
.word 0                         @ 05: BusFault
.word 0                         @ 06: UsageFault
.word 0                         @ 07: SecureFault
.word 0                         @ 08: Reserved
.word 0                         @ 09: Reserved
.word 0                         @ 10: Reserved
.word irq_vektor_svcall     + 1 @ 11: SVCall handler
.word 0                         @ 12: DebugMonitor
.word 0                         @ 13: Reserved
.word irq_vektor_pendsv     + 1 @ 14: The PendSV handler
.word irq_vektor_systick    + 1 @ 15: The SysTick handler

@ Special interrupt handlers for this particular chip:

@ On RP2350, only the lower 45 IRQ signals are connected on the NVIC, and IRQs 46 to 51 are tied to zero (never firing).
@ The core can still be forced to enter the relevant interrupt handler by writing bits 46 to 51 in the NVIC ISPR register.

.word irq_vektor_TIMER0_IRQ_0     + 1 @ Position  0: TIMER0_IRQ_0
.word irq_vektor_TIMER0_IRQ_1     + 1 @ Position  1: TIMER0_IRQ_1
.word irq_vektor_TIMER0_IRQ_2     + 1 @ Position  2: TIMER0_IRQ_2
.word irq_vektor_TIMER0_IRQ_3     + 1 @ Position  3: TIMER0_IRQ_3
.word irq_vektor_TIMER1_IRQ_0     + 1 @ Position  4: TIMER1_IRQ_0
.word irq_vektor_TIMER1_IRQ_1     + 1 @ Position  5: TIMER1_IRQ_1
.word irq_vektor_TIMER1_IRQ_2     + 1 @ Position  6: TIMER1_IRQ_2
.word irq_vektor_TIMER1_IRQ_3     + 1 @ Position  7: TIMER1_IRQ_3
.word irq_vektor_PWM_IRQ_WRAP_0   + 1 @ Position  8: PWM_IRQ_WRAP_0
.word irq_vektor_PWM_IRQ_WRAP_1   + 1 @ Position  9: PWM_IRQ_WRAP_1
.word irq_vektor_DMA_IRQ_0        + 1 @ Position 10: DMA_IRQ_0
.word irq_vektor_DMA_IRQ_1        + 1 @ Position 11: DMA_IRQ_1
.word irq_vektor_DMA_IRQ_2        + 1 @ Position 12: DMA_IRQ_2
.word irq_vektor_DMA_IRQ_3        + 1 @ Position 13: DMA_IRQ_3
.word irq_vektor_USBCTRL_IRQ      + 1 @ Position 14: USBCTRL_IRQ
.word irq_vektor_PIO0_IRQ_0       + 1 @ Position 15: PIO0_IRQ_0
.word irq_vektor_PIO0_IRQ_1       + 1 @ Position 16: PIO0_IRQ_1
.word irq_vektor_PIO1_IRQ_0       + 1 @ Position 17: PIO1_IRQ_0
.word irq_vektor_PIO1_IRQ_1       + 1 @ Position 18: PIO1_IRQ_1
.word irq_vektor_PIO2_IRQ_0       + 1 @ Position 19: PIO2_IRQ_0
.word irq_vektor_PIO2_IRQ_1       + 1 @ Position 20: PIO2_IRQ_1
.word irq_vektor_IO_IRQ_BANK0     + 1 @ Position 21: IO_IRQ_BANK0
.word irq_vektor_IO_IRQ_BANK0_NS  + 1 @ Position 22: IO_IRQ_BANK0_NS
.word irq_vektor_IO_IRQ_QSPI      + 1 @ Position 23: IO_IRQ_QSPI
.word irq_vektor_IO_IRQ_QSPI_NS   + 1 @ Position 24: IO_IRQ_QSPI_NS
.word irq_vektor_SIO_IRQ_FIFO     + 1 @ Position 25: SIO_IRQ_FIFO
.word irq_vektor_SIO_IRQ_BELL     + 1 @ Position 26: SIO_IRQ_BELL
.word irq_vektor_SIO_IRQ_FIFO_NS  + 1 @ Position 27: SIO_IRQ_FIFO_NS
.word irq_vektor_SIO_IRQ_BELL_NS  + 1 @ Position 28: SIO_IRQ_BELL_NS
.word irq_vektor_SIO_IRQ_MTIMECMP + 1 @ Position 29: SIO_IRQ_MTIMECMP
.word irq_vektor_CLOCKS_IRQ       + 1 @ Position 30: CLOCKS_IRQ
.word irq_vektor_SPI0_IRQ         + 1 @ Position 31: SPI0_IRQ
.word irq_vektor_SPI1_IRQ         + 1 @ Position 32: SPI1_IRQ
.word irq_vektor_UART0_IRQ        + 1 @ Position 33: UART0_IRQ
.word irq_vektor_UART1_IRQ        + 1 @ Position 34: UART1_IRQ
.word irq_vektor_ADC_IRQ_FIFO     + 1 @ Position 35: ADC_IRQ_FIFO
.word irq_vektor_I2C0_IRQ         + 1 @ Position 36: I2C0_IRQ
.word irq_vektor_I2C1_IRQ         + 1 @ Position 37: I2C1_IRQ
.word irq_vektor_OTP_IRQ          + 1 @ Position 38: OTP_IRQ
.word irq_vektor_TRNG_IRQ         + 1 @ Position 39: TRNG_IRQ
.word irq_vektor_PROC0_IRQ_CTI    + 1 @ Position 40: PROC0_IRQ_CTI
.word irq_vektor_PROC1_IRQ_CTI    + 1 @ Position 41: PROC1_IRQ_CTI
.word irq_vektor_PLL_SYS_IRQ      + 1 @ Position 42: PLL_SYS_IRQ
.word irq_vektor_PLL_USB_IRQ      + 1 @ Position 43: PLL_USB_IRQ
.word irq_vektor_POWMAN_IRQ_POW   + 1 @ Position 44: POWMAN_IRQ_POW
.word irq_vektor_POWMAN_IRQ_TIMER + 1 @ Position 45: POWMAN_IRQ_TIMER
.word irq_vektor_SPAREIRQ_IRQ_0   + 1 @ Position 46: SPAREIRQ_IRQ_0
.word irq_vektor_SPAREIRQ_IRQ_1   + 1 @ Position 47: SPAREIRQ_IRQ_1
.word irq_vektor_SPAREIRQ_IRQ_2   + 1 @ Position 48: SPAREIRQ_IRQ_2
.word irq_vektor_SPAREIRQ_IRQ_3   + 1 @ Position 49: SPAREIRQ_IRQ_3
.word irq_vektor_SPAREIRQ_IRQ_4   + 1 @ Position 50: SPAREIRQ_IRQ_4
.word irq_vektor_SPAREIRQ_IRQ_5   + 1 @ Position 51: SPAREIRQ_IRQ_5

@ -----------------------------------------------------------------------------

@ ---- IMAGE_DEF --------------------------------------------------------------
@ must be located within the first 4 kByte
.word 0xffffded3 @ PICOBIN_BLOCK_MARKER_START
.word 0x10210142
.word 0x000001ff
.word 0x00000000
.word 0xab123579
