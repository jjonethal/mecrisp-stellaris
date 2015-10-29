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
.word nullhandler+1 @ Position  2: Tamper and TimeStamp through EXTI line
.word nullhandler+1 @ Position  3: RTC Wakeup
.word nullhandler+1 @ Position  4: Flash
.word nullhandler+1 @ Position  5: RCC
.word irq_vektor_exti0+1 @ Position  6: EXTI Line 0
.word irq_vektor_exti1+1 @ Position  7: EXTI Line 1
.word irq_vektor_exti2+1 @ Position  8: EXTI Line 2
.word irq_vektor_exti3+1 @ Position  9: EXTI Line 3
.word irq_vektor_exti4+1 @ Position 10: EXTI Line 4
.word nullhandler+1 @ Position 11: DMA1 Stream 0
.word nullhandler+1 @ Position 12: DMA1 Stream 1
.word nullhandler+1 @ Position 13: DMA1 Stream 2
.word nullhandler+1 @ Position 14: DMA1 Stream 3
.word nullhandler+1 @ Position 15: DMA1 Stream 4
.word nullhandler+1 @ Position 16: DMA1 Stream 5
.word nullhandler+1 @ Position 17: DMA1 Stream 6
.word irq_vektor_adc+1 @ Position 18: ADC global interrupts
.word nullhandler+1 @ Position 19:
.word nullhandler+1 @ Position 20:
.word irq_vektor_dac+1 @ Position 21: DAC interrupt
.word nullhandler+1 @ Position 22:
.word nullhandler+1 @ Position 23:
.word nullhandler+1 @ Position 24:
.word nullhandler+1 @ Position 25:
.word nullhandler+1 @ Position 26:
.word nullhandler+1 @ Position 27:
.word irq_vektor_tim2+1 @ Position 28: TIM2
.word irq_vektor_tim3+1 @ Position 29: TIM3
.word irq_vektor_tim4+1 @ Position 30: TIM4
.word irq_vektor_i2c1_ev+1 @ Position 31:  I2C1 Event Interrupt
.word irq_vektor_i2c1_er+1 @ Position 32: I2C1 Error Interrupt
.word irq_vektor_i2c2_ev+1 @ Position 33: I2C2 Event Interrupt
.word irq_vektor_i2c2_er+1 @ Position 34: I2C2 Error Interrupt
.word irq_vektor_spi1+1 @ Position 35: SPI1 global Interrupt
.word irq_vektor_spi2+1 @ Position 36: SPI2 global Interrupt
.word irq_vektor_usart1+1 @ Position 37: USART1 global Interrupt
.word irq_vektor_usart2+1 @ Position 38: USART2 global Interrupt
.word irq_vektor_usart3+1 @ Position 39: USART3 global Interrupt
.word nullhandler+1 @ Position 40:
.word irq_vektor_rtc_alarm+1 @ Position 41: RTC Alarm through EXTI Line Interrupt
.word nullhandler+1 @ Position 42:
.word irq_vektor_tim6+1 @ Position 43: TIM6
.word irq_vektor_tim7+1 @ Position 44: TIM7

@ -----------------------------------------------------------------------------
