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

.word nullhandler+1 @ Position 00: DMA Channel 0 Transfer Complete and Error
.word nullhandler+1 @ Position 01: DMA Channel 1 Transfer Complete and Error
.word nullhandler+1 @ Position 02: DMA Channel 2 Transfer Complete and Error
.word nullhandler+1 @ Position 03: DMA Channel 3 Transfer Complete and Error
.word nullhandler+1 @ Position 04: Normal Interrupt
.word nullhandler+1 @ Position 05: FTFL Interrupt
.word nullhandler+1 @ Position 06: PMC Interrupt
.word nullhandler+1 @ Position 07: Low Leakage Wake-up
.word nullhandler+1 @ Position 08: I2C0 interrupt
.word nullhandler+1 @ Position 09: I2C1 interrupt
.word nullhandler+1 @ Position 10: SPI0 Interrupt
.word nullhandler+1 @ Position 11: SPI1 Interrupt
.word nullhandler+1 @ Position 12: UART0 Status and Error interrupt
.word nullhandler+1 @ Position 13: UART1 Status and Error interrupt
.word nullhandler+1 @ Position 14: UART2 Status and Error interrupt
.word irq_vektor_adc+1 @ Position 15: ADC0 interrupt
.word irq_vektor_cmp+1 @ Position 16: CMP0 interrupt
.word nullhandler+1 @ Position 17: FTM0 fault, overflow and channels interrupt
.word nullhandler+1 @ Position 18: FTM1 fault, overflow and channels interrupt
.word nullhandler+1 @ Position 19: FTM2 fault, overflow and channels interrupt
.word nullhandler+1 @ Position 20: RTC Alarm interrupt
.word nullhandler+1 @ Position 21: RTC Seconds interrupt
.word nullhandler+1 @ Position 22: PIT timer all channels interrupt
.word nullhandler+1 @ Position 23: Reserved interrupt 39/23
.word nullhandler+1 @ Position 24: USB interrupt
.word irq_vektor_dac+1 @ Position 25: DAC0 interrupt
.word nullhandler+1 @ Position 26: TSI0 Interrupt
.word nullhandler+1 @ Position 27: MCG Interrupt
.word nullhandler+1 @ Position 28: LPTimer interrupt
.word nullhandler+1 @ Position 29: Reserved interrupt 45/29
.word irq_vektor_porta+1 @ Position 30: Port A interrupt
.word irq_vektor_portd+1 @ Position 31: Port D interrupt

@ See page 53 in manual

@  VECTORS (rx)      : ORIGIN = 0x0,         LENGTH = 0x00c0
@  FLASHCFG (rx)     : ORIGIN = 0x00000400,  LENGTH = 0x00000010
@  FLASH (rx)        : ORIGIN = 0x00000410,  LENGTH = 128K - 0x410
@  RAM  (rwx)        : ORIGIN = 0x1FFFF000,  LENGTH = 16K


@ Flash configuration field (loaded into flash memory at 0x400)
.org 0x400, 0xFFFFFFFF @ Advance to Flash Configuration Field (FCF)
.org 0x410, 0xFFFFFFFF @ Fill this field with FF to have Reset Pin enabled.

@ Start for real code !

@ -----------------------------------------------------------------------------
