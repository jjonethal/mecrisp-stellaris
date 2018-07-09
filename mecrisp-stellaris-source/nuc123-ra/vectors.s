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

.equ addresszero, . @ This is needed to circumvent address relocation issues.
.word returnstackanfang  @ 00: Stack top address

@ Special interrupt handlers for this particular chip:

.word Reset+1 	/*RESET*/ 	
.word faulthandler+1 	/*NMI */	
.word faulthandler+1		/*hard_fault */	
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word nullhandler+1		/*svcall */	
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word irq_vektor_pendsv+1		/*pendsv */
.word irq_vektor_systick+1	/*sys tick */	


.word irq_vektor_bod_out+1  	/*Brown-out low voltage detected interrupt */	
.word irq_vektor_wdt+1  	    /*Watchdog/Window Watchdog Timer interrupt */	
.word irq_vektor_eint0+1		  /*External signal interrupt from PB.14 pin */	
.word irq_vektor_eint1+1 	    /*External signal interrupt from PB.15 or PD.11 pin */	
.word irq_vektor_gpab+1		    /*External signal interrupt from PA[15:0]/PB[13:0] */		
.word irq_vektor_gpcdf+1  	  /*External interrupt from PC[15:0]/PD[15:0]/PF[3:0] */		
.word irq_vektor_pwma+1  	        /*PWM0, PWM1, PWM2 and PWM3 interrupt */		
.word 0				 		/*Reserved */		@ reserved
.word irq_vektor_timer0+1  	        /*Timer 0 interrupt */		
.word irq_vektor_timer1+1  	        /*Timer 1 interrupt */		
.word irq_vektor_timer2+1  	        /*Timer 2 interrupt */		
.word irq_vektor_timer3+1  	        /*Timer 3 interrupt */		
.word irq_vektor_uart0+1  	        /*UART0 interrupt */		
.word irq_vektor_uart1+1  	        /*UART1 interrupt */		
.word irq_vektor_spi0+1  	        /*SPI0 interrupt */		
.word irq_vektor_spi1+1  	        /*SPI1 interrupt */		
.word irq_vektor_spi2+1  	        /*SPI2 interrupt */		
.word 0				 		/*Reserved */		@ reserved
.word irq_vektor_i2c0+1  	        /*I2C0 interrupt */		
.word irq_vektor_i2c1+1  	        /*I2C1 interrupt */		
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved
.word irq_vektor_usb+1  	        /*USB 2.0 FS Device interrupt */		
.word irq_vektor_ps2+1  	        /*PS/2 interrupt */		
.word 0				 		/*Reserved */		@ reserved
.word irq_vektor_pdma+1  	        /*PDMA interrupt */		
.word irq_vektor_i2s+1  	        /*I2S interrupt */		
.word irq_vektor_pwrwu+1  	        /*Clock controller interrupt for chip wake-up from Power-down state */		
.word irq_vektor_adc+1  	        /*ADC interrupt */		
.word 0				 		/*Reserved */		@ reserved
.word 0				 		/*Reserved */		@ reserved

@ -----------------------------------------------------------------------------
