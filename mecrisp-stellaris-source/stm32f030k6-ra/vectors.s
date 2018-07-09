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

.word nullhandler+1 @ Position  0: Window Watchdog
.word nullhandler+1 @ Position  1: Reserved
.word nullhandler+1 @ Position  2: RTC Wakeup
.word nullhandler+1 @ Position  3: Flash
.word nullhandler+1 @ Position  4: RCC
.word irq_vektor_exti0_1+1  @ Position  5: EXTI Line 0 - 1
.word irq_vektor_exti2_3+1  @ Position  6: EXTI Line 2 - 3
.word irq_vektor_exti4_15+1 @ Position  7: EXTI Line 4 - 15
.word nullhandler+1 @ Position  8: Reserved
.word irq_vektor_dma_ch1+1 @ Position  9: DMA1 Channel 1
.word irq_vektor_dma_ch2_3+1 @ Position 10: DMA1 Channel 2 and Channel 3
.word irq_vektor_dma_ch4_5+1 @ Position 11: DMA1 Channel 4 and Channel 5
.word irq_vektor_adc+1     @ Position 12: ADC1 interrupts
.word irq_vektor_tim1_up+1 @ Position 13: Timer 1 Break, Update, Trigger & Computation
.word irq_vektor_tim1_cc+1 @ Position 14: Timer 1 Capture & Compare
.word nullhandler+1 @ Position 15: Reserved
.word irq_vektor_tim3+1    @ Position 16: Timer 3 global

.word nullhandler+1 @ Position 17: Reserved
.word nullhandler+1 @ Position 18: Reserved
.word irq_vektor_tim14+1 @ Position 19: TIM14
.word nullhandler+1 @ Position 20: Reserved
.word irq_vektor_tim16+1 @ Position 21: TIM16
.word irq_vektor_tim17+1 @ Position 22: TIM17
.word irq_vektor_i2c1+1 @ Position 23: I2C1
.word nullhandler+1 @ Position 24: Reserved
.word irq_vektor_spi1+1 @ Position 25: SPI1
.word nullhandler+1 @ Position 26: Reserved
.word irq_vektor_usart1+1 @ Position 27: USART1
.word nullhandler+1 @ Position 28: Reserved
.word nullhandler+1 @ Position 29: Reserved
.word nullhandler+1 @ Position 30: Reserved
.word nullhandler+1 @ Position 31: Reserved

@ -----------------------------------------------------------------------------
