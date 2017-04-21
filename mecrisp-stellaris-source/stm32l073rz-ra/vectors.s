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
.word nullhandler+1 @ Position  1: PVD through EXTI line detection
.word irq_vektor_rtc+1      @ Position  2: RTC Wakeup
.word nullhandler+1 @ Position  3: Flash
.word nullhandler+1 @ Position  4: RCC and CRS
.word irq_vektor_exti0_1+1  @ Position  5: EXTI Line 0 - 1
.word irq_vektor_exti2_3+1  @ Position  6: EXTI Line 2 - 3
.word irq_vektor_exti4_15+1 @ Position  7: EXTI Line 4 - 15
.word irq_vektor_touch+1    @ Position  8: Touch sensing
.word irq_vektor_dma1+1     @ Position  9: DMA1, Channel 1
.word irq_vektor_dma2_3+1   @ Position 10: DMA1, Channel 2-3
.word irq_vektor_dma4_7+1   @ Position 11: DMA1, Channel 4-7
.word irq_vektor_adc+1      @ Position 12: ADC and Comp interrupts
.word irq_vektor_lptim1+1   @ Position 13: LPTIM1
.word nullhandler+1 @ Position 14:
.word irq_vektor_tim2+1     @ Position 15: Timer 2 global
.word nullhandler+1 @ Position 16:
.word irq_vektor_dac+1      @ Position 17: TIM6, DAC
.word nullhandler+1 @ Position 18:
.word nullhandler+1 @ Position 19:
.word irq_vektor_tim21+1    @ Position 20: TIM21
.word nullhandler+1 @ Position 21:
.word irq_vektor_tim22+1    @ Position 22: TIM22
.word irq_vektor_i2c1+1     @ Position 23: I2C1
.word irq_vektor_i2c2+1     @ Position 24: I2C2
.word irq_vektor_spi1+1     @ Position 25: SPI1
.word irq_vektor_spi2+1     @ Position 26: SPI2
.word irq_vektor_usart1+1   @ Position 27: USART1
.word irq_vektor_usart2+1   @ Position 28: USART2
.word irq_vektor_rng+1      @ Position 29: LPUART1, AES, RNG
.word irq_vektor_lcd+1      @ Position 30: LCD
.word irq_vektor_usb+1      @ Position 31: USB

@ -----------------------------------------------------------------------------
