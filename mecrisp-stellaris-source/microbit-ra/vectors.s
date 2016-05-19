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

.word irq_vektor_power+1 	/*POWER_CLOCK*/ 	@ Position  0: Window Watchdog
.word irq_vektor_radio+1 	/*RADIO */			@ Position  1: PVD through EXTI line detection
.word irq_vektor_uart+1		/*UART0 */			@ Position  2: RTC Wakeup
.word irq_vektor_spi0+1		/*SPI0_TWI0 */		@ Position  3: Flash
.word irq_vektor_spi1+1		/*SPI1_TWI1 */		@ Position  4: RCC
.word 0				  		/*Reserved */		@ .word irq_vektor_exti0_1+1  @ Position  5: EXTI Line 0 - 1
.word irq_vektor_gpiote+1	/*GPIOTE */			@ .word irq_vektor_exti2_3+1  @ Position  6: EXTI Line 2 - 3
.word irq_vektor_adc+1  	/*ADC */			@ .word irq_vektor_exti4_15+1 @ Position  7: EXTI Line 4 - 15
.word irq_vektor_tim0+1  	/*TIMER0 */			@ Position  8: Touch sensing
.word irq_vektor_tim1+1		/*TIMER1 */			@ Position  9: DMA
.word irq_vektor_tim2+1 	/*TIMER2 */			@ Position 10: DMA
.word irq_vektor_rtc0+1		/*RTC0 */			@ Position 11: DMA
.word irq_vektor_temp+1  	/*TEMP */			@ .word irq_vektor_adc+1     @ Position 12: ADC and Comp interrupts
.word irq_vektor_rng+1  	/*RNG */			@ .word irq_vektor_tim1_up+1 @ Position 13: Timer 1 Break & Update
.word irq_vektor_ecb+1  	/*ECB */			@ .word irq_vektor_tim1_cc+1 @ Position 14: Timer 1 Capture & Compare
.word irq_vektor_ccm_aar+1  /*CCM_AAR */		@ .word irq_vektor_tim2+1    @ Position 15: Timer 2 global
.word irq_vektor_wdt+1  	/*WDT */			@ .word irq_vektor_tim3+1    @ Position 16: Timer 3 global
.word irq_vektor_rtc1+1  	/*RTC1 */			@ 
.word irq_vektor_qdec+1  	/*QDEC */			@ 
.word irq_vektor_lpcomp+1  	/*LPCOMP */			@ 
.word irq_vektor_swi0+1		/*SWI0 */			@ 
.word irq_vektor_swi1+1		/*SWI1 */			@ 
.word irq_vektor_swi2+1		/*SWI2 */			@ 
.word irq_vektor_swi3+1		/*SWI3 */			@ 
.word irq_vektor_swi4+1		/*SWI4 */			@ 
.word irq_vektor_swi5+1		/*SWI5 */			@ 
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved

@ Much more ! 

@ -----------------------------------------------------------------------------
