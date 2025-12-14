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

.word irq_vektor_appr+1	      /*APPROTECT */    @ Position  0: Window Watchdog
.word irq_vektor_radio+1 	   /*RADIO */        @ Position  1: PVD through EXTI line detection
.word irq_vektor_uart0+1      /*UART0 */        @ Position  2: Uart with EasyDMA, unit 0
.word irq_vektor_spi0+1		   /*SPI0_TWI0 */    @ Position  3: Flash
.word irq_vektor_spi1+1		   /*SPI1_TWI1 */    @ Position  4: RCC
.word irq_vektor_nfct+1		   /*NFCT */         @ Position  5: NFCT
.word irq_vektor_gpiote+1	   /*GPIOTE */       @ Position  6: GPIOTE
.word irq_vektor_saadc+1  	   /*SAADC */        @ Postition 7: SAADC
.word irq_vektor_tim0+1  	   /*TIMER0 */			@ Position  8: Timer/counter 0
.word irq_vektor_tim1+1		   /*TIMER1 */			@ Position  9: Timer/counter 1
.word irq_vektor_tim2+1 	   /*TIMER2 */			@ Position 10: Timer/counter 2
.word irq_vektor_rtc0+1		   /*RTC0 */			@ Position 11: Real time counter 0
.word irq_vektor_temp+1  	   /*TEMP */         @ Position 12: Temperature sensor
.word irq_vektor_rng+1  	   /*RNG */          @ Position 13: Random number generator
.word irq_vektor_ecb+1  	   /*ECB */          @ Position 14: AES Electronic code book mode block encryption
.word irq_vektor_ccm_aar+1    /*CCM_AAR */      @ Position 15: Accelerated address resolver & CBC-MAC mode block encryption
.word irq_vektor_wdt+1  	   /*WDT */          @ Position 16: Watchdog Timer
.word irq_vektor_rtc1+1  	   /*RTC1 */         @ Position 17: Real time counter 1
.word irq_vektor_qdec+1  	   /*QDEC */         @ Position 18: Quadrature decoder
.word irq_vektor_lpcomp+1  	/*LPCOMP */       @ Position 19: General purpose and low power comparitors
.word irq_vektor_swi0+1	      /*EGUI0_SWI0 */   @ Position 20: Software interrupt 0
.word irq_vektor_swi1+1       /*EGUI1_SWI1 */   @ Position 21: Software interrupt 1
.word irq_vektor_swi2+1       /*EGUI2_SWI2 */   @ Position 22: Software interrupt 2
.word irq_vektor_swi3+1       /*EGUI3_SWI3 */   @ Position 23: Software interrupt 3
.word irq_vektor_swi4+1       /*EGUI4_SWI4 */   @ Position 24: Software interrupt 4
.word irq_vektor_swi5+1       /*EGUI5_SWI5 */   @ Position 25: Software interrupt 5
.word irq_vektor_tim3+1	      /*TIMER3 */       @ Position 26: Timer 3
.word irq_vektor_tim4+1	      /*TIMER4 */       @ Position 27: Timer 4
.word irq_vektor_pwm0+1       /*PWM0 */         @ Position 28: Pulse width modulation 0
.word irq_vektor_pdm+1        /*PDM */          @ Position 29: Pulse density modulation (digital microphone) interface
.word irq_vektor_acl+1        /*ACL_NVMC */     @ Position 30: Access control lists and non volatile memory controller
.word irq_vektor_ppi+1        /*PPI */          @ Position 31: Programmable peripheral interconnect
.word irq_vektor_mwu+1        /*MWU */          @ Position 32: Memory watch unit
.word irq_vektor_pwm1+1       /*PWM1 */         @ Position 33: Pulse width modulation 1
.word irq_vektor_pwm2+1       /*PWM2 */         @ Position 34: Pulse width modulation 2
.word irq_vektor_spi2+1       /*SPI2 */         @ Position 35: SPI master 2
.word irq_vektor_rtc2+1       /*RTC2 */         @ Position 36: Real time counter 2
.word irq_vektor_i2s+1        /*I2S */          @ Position 37: Inter-IC sound interface
.word irq_vektor_fpu+1        /*FPU */          @ Position 38: FPU interrupt
.word irq_vektor_usbd+1       /*USBD */         @ Position 39: Universal serial bus interface
.word irq_vektor_uarte1+1     /*UARTE1 */       @ Position 40: Universal asynchronous receiver/transmitter with EasyDMA, unit 1
.word nullhandler+1           /*Reserved */     @ reserved
.word nullhandler+1           /*Reserved */     @ reserved
.word nullhandler+1           /*Reserved */     @ reserved
.word nullhandler+1           /*Reserved */     @ reserved
.word irq_vektor_pwm3+1       /*PWM3 */         @ Position 45: Pulse width modulation 3   
.word nullhandler+1           /*Reserved */     @ reserved
.word irq_vektor_spim3+1      /*SPIM3 */        @ Position 47: SPI master 3

@ Much more ! 

@ -----------------------------------------------------------------------------
