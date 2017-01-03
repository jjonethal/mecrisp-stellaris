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

.word nullhandler+1  @ PSS ISR   
.word nullhandler+1  @ CS ISR   
.word nullhandler+1  @ PCM ISR   
.word irq_vektor_watchdog+1  @ WDT ISR   
.word nullhandler+1  @ FPU ISR   
.word nullhandler+1  @ FLCTL ISR  
.word nullhandler+1  @ COMP0 ISR  
.word nullhandler+1  @ COMP1 ISR  
.word irq_vektor_timera0+1  @ TA0_0 ISR  
.word irq_vektor_timera1+1  @ TA0_N ISR  
.word nullhandler+1  @ TA1_0 ISR  
.word nullhandler+1  @ TA1_N ISR  
.word nullhandler+1  @ TA2_0 ISR  
.word nullhandler+1  @ TA2_N ISR  
.word nullhandler+1  @ TA3_0 ISR  
.word nullhandler+1  @ TA3_N ISR  
.word nullhandler+1  @ EUSCIA0 ISR 
.word nullhandler+1  @ EUSCIA1 ISR 
.word nullhandler+1  @ EUSCIA2 ISR 
.word nullhandler+1  @ EUSCIA3 ISR 
.word nullhandler+1  @ EUSCIB0 ISR 
.word nullhandler+1  @ EUSCIB1 ISR 
.word nullhandler+1  @ EUSCIB2 ISR 
.word nullhandler+1  @ EUSCIB3 ISR 
.word irq_vektor_adc+1  @ ADC12 ISR  
.word nullhandler+1  @ T32_INT1 ISR
.word nullhandler+1  @ T32_INT2 ISR
.word nullhandler+1  @ T32_INTC ISR
.word nullhandler+1  @ AES ISR   
.word nullhandler+1  @ RTC ISR   
.word nullhandler+1  @ DMA_ERR ISR 
.word nullhandler+1  @ DMA_INT3 ISR
.word nullhandler+1  @ DMA_INT2 ISR
.word nullhandler+1  @ DMA_INT1 ISR
.word nullhandler+1  @ DMA_INT0 ISR
.word irq_vektor_port1+1  @ PORT1 ISR  
.word irq_vektor_port2+1  @ PORT2 ISR  
.word irq_vektor_port3+1  @ PORT3 ISR  
.word irq_vektor_port4+1  @ PORT4 ISR  
.word irq_vektor_port5+1  @ PORT5 ISR  
.word irq_vektor_port6+1  @ PORT6 ISR  
.word nullhandler+1  @ Reserved 41 
.word nullhandler+1  @ Reserved 42 
.word nullhandler+1  @ Reserved 43 
.word nullhandler+1  @ Reserved 44 
.word nullhandler+1  @ Reserved 45 
.word nullhandler+1  @ Reserved 46 
.word nullhandler+1  @ Reserved 47 
.word nullhandler+1  @ Reserved 48 
.word nullhandler+1  @ Reserved 49 
.word nullhandler+1  @ Reserved 50 
.word nullhandler+1  @ Reserved 51 
.word nullhandler+1  @ Reserved 52 
.word nullhandler+1  @ Reserved 53 
.word nullhandler+1  @ Reserved 54 
.word nullhandler+1  @ Reserved 55 
.word nullhandler+1  @ Reserved 56 
.word nullhandler+1  @ Reserved 57 
.word nullhandler+1  @ Reserved 58 
.word nullhandler+1  @ Reserved 59 
.word nullhandler+1  @ Reserved 60 
.word nullhandler+1  @ Reserved 61 
.word nullhandler+1  @ Reserved 62 
.word nullhandler+1  @ Reserved 63 
.word nullhandler+1  @ Reserved 64

@ -----------------------------------------------------------------------------
