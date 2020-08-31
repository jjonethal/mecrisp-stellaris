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
.word irq_vektor_rtc+1 @ Position  3: RTC Wakeup
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

.word nullhandler+1 @ Position 19: CAN1_TX
.word nullhandler+1 @ Position 20: CAN1_RX0
.word nullhandler+1 @ Position 21: CAN1_RX1
.word nullhandler+1 @ Position 22: CAN1_SCE
.word irq_vektor_exti5+1 @ Position 23: EXTI9_5
.word irq_vektor_tim1brk+1 @ Position 24: TIM1_BRK
.word irq_vektor_tim1up+1 @ Position 25: TIM1_UP
.word irq_vektor_tim1trg+1 @ Position 26: TIM1_TRG_COM
.word irq_vektor_tim1cc+1 @ Position 27: TIM1_CC
.word irq_vektor_tim2+1 @ Position 28: TIM2
.word irq_vektor_tim3+1 @ Position 29: TIM3
.word irq_vektor_tim4+1 @ Position 30: TIM4
.word irq_vektor_i2c1ev+1 @ Position 31: I2C1_EV
.word irq_vektor_i2c1er+1 @ Position 32: I2C1_ER
.word irq_vektor_i2c2ev+1 @ Position 33: I2C2_EV
.word irq_vektor_i2c2er+1 @ Position 34: I2C2_ER
.word irq_vektor_spi1+1 @ Position 35: SPI1
.word irq_vektor_spi2+1 @ Position 36: SPI2
.word irq_vektor_usart1+1 @ Position 37: USART1
.word irq_vektor_usart2+1 @ Position 38: USART2
.word irq_vektor_usart3+1 @ Position 39: USART3
.word irq_vektor_exti10+1 @ Position 40: EXTI15_10
.word irq_vektor_rtcalarm+1 @ Position 41: RTCAlarm
.word irq_vektor_usbwkup+1 @ Position 42: OTG_FS_WKUP
      
.word 0  @ 43: Reserved
.word 0  @ 44: Reserved
.word 0  @ 45: Reserved
.word 0  @ 46: Reserved
.word 0  @ 47: Reserved
.word 0  @ 48: Reserved
.word 0  @ 49: Reserved

.word irq_vektor_tim5+1 @ Position 50: TIM5
.word irq_vektor_spi3+1 @ Position 51: SPI3
.word irq_vektor_uart4+1 @ Position 52: UART4
.word irq_vektor_uart5+1 @ Position 53: UART5
.word irq_vektor_tim6+1 @ Position 54: TIM6
.word irq_vektor_tim7+1 @ Position 55: TIM7
.word nullhandler+1 @ Position 56: DMA2_Channel1
.word nullhandler+1 @ Position 57: DMA2_Channel2
.word nullhandler+1 @ Position 58: DMA2_Channel3
.word nullhandler+1 @ Position 59: DMA2_Channel4
.word nullhandler+1 @ Position 60: DMA2_Channel5
.word nullhandler+1 @ Position 61: ETH
.word nullhandler+1 @ Position 62: ETH_WKUP
.word nullhandler+1 @ Position 63: CAN2_TX
.word nullhandler+1 @ Position 64: CAN2_RX0
.word nullhandler+1 @ Position 65: CAN2_RX1
.word nullhandler+1 @ Position 66: CAN2_SCE
.word irq_vektor_usbfs+1 @ Position 67: OTG_FS

@ -----------------------------------------------------------------------------
