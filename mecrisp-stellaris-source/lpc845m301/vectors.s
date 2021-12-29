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

.word nullhandler+1 @ Position 00: SPI0_IRQ
.word nullhandler+1 @ Position 01: SPI1_IRQ
.word irq_vektor_dac0+1 @ Position 02: DAC0_IRQ
.word nullhandler+1 @ Position 03: USART0_IRQ
.word nullhandler+1 @ Position 04: USART1_IRQ
.word nullhandler+1 @ Position 05: USART2_IRQ
.word nullhandler+1 @ Position 06: Reserved22_IRQ
.word nullhandler+1 @ Position 07: I2C1_IRQ
.word nullhandler+1 @ Position 08: I2C0_IRQ
.word nullhandler+1 @ Position 09: SCT0_IRQ
.word nullhandler+1 @ Position 10: MRT0_IRQ
.word irq_vektor_cmp+1 @ Position 11: CMP_CAPT_IRQ
.word nullhandler+1 @ Position 12: WDT_IRQ
.word nullhandler+1 @ Position 13: BOD_IRQ
.word nullhandler+1 @ Position 14: FLASH_IRQ
.word nullhandler+1 @ Position 15: WKT_IRQ
.word irq_vektor_adc0seqa+1 @ Position 16: ADC0_SEQA_IRQ
.word irq_vektor_adc0seqb+1 @ Position 17: ADC0_SEQB_IRQ
.word irq_vektor_adc0thcmp+1 @ Position 18: ADC0_THCMP_IRQ
.word irq_vektor_adc0ovr+1 @ Position 19: ADC0_OVR_IRQ
.word nullhandler+1 @ Position 20: DMA0_IRQ
.word nullhandler+1 @ Position 21: I2C2_IRQ
.word nullhandler+1 @ Position 22: I2C3_IRQ
.word nullhandler+1 @ Position 23: CTIMER0_IRQ
.word nullhandler+1 @ Position 24: PIN_INT0_IRQ
.word nullhandler+1 @ Position 25: PIN_INT1_IRQ
.word nullhandler+1 @ Position 26: PIN_INT2_IRQ
.word nullhandler+1 @ Position 27: PIN_INT3_IRQ
.word nullhandler+1 @ Position 28: PIN_INT4_IRQ
.word nullhandler+1 @ Position 29: PIN_INT5_DAC1_IRQ
.word nullhandler+1 @ Position 30: PIN_INT6_USART3_IRQ
.word nullhandler+1 @ Position 31: PIN_INT7_USART4_IRQ

.org 0x300, 0xFFFFFFFF @ Disable Code Read protection field at address 2FC !

@ -----------------------------------------------------------------------------
