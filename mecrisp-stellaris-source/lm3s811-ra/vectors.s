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

.word nullhandler+1             @ 16:       GPIO Port A                ; 
.word nullhandler+1             @ 17:       GPIO Port B                ;
.word nullhandler+1             @ 18:       GPIO Port C                ; 
.word nullhandler+1             @ 19:       GPIO Port D                ; 
.word nullhandler+1             @ 20:       GPIO Port E                ; 
.word irq_vektor_terminal+1     @ 21:       UART0 Rx and Tx            ; 
.word nullhandler+1             @ 22:       UART1 Rx and Tx            ; 
.word nullhandler+1             @ 23:       SSI0 Rx and Tx             ;
.word nullhandler+1             @ 24:       I2C0 Master and Slave      ; 
.word nullhandler+1             @ 25:       PWM Fault                  ; 
.word nullhandler+1             @ 26:       PWM Generator 0            ; 
.word nullhandler+1             @ 27:       PWM Generator 1            ; 
.word nullhandler+1             @ 28:       PWM Generator 2            ; 
.word nullhandler+1             @ 29:       Quadrature Encoder 0       ;
.word irq_vektor_adc0seq0+1     @ 30:       ADC Sequence 0             ; 
.word irq_vektor_adc0seq1+1     @ 31:       ADC Sequence 1             ; 
.word irq_vektor_adc0seq2+1     @ 32:       ADC Sequence 2             ; 
.word irq_vektor_adc0seq3+1     @ 33:       ADC Sequence 3                                                  
.word nullhandler+1             @ 34:       Watchdog timer                                                  
.word irq_vektor_timer0a+1      @ 35:       Timer 0 subtimer A                                              
.word irq_vektor_timer0b+1      @ 36:       Timer 0 subtimer B                                              
.word irq_vektor_timer1a+1      @ 37:       Timer 1 subtimer A                                              
.word irq_vektor_timer1b+1      @ 38:       Timer 1 subtimer B                                              
.word irq_vektor_timer2a+1      @ 39:       Timer 2 subtimer A                                              
.word irq_vektor_timer2b+1      @ 40:       Timer 2 subtimer B                                              
.word nullhandler+1             @ 41:       Analog Comparator 0                                             
.word nullhandler+1             @ 42:       Analog Comparator 1                                             
.word nullhandler+1             @ 43:       Analog Comparator 2                                             
.word nullhandler+1             @ 44:       System Control (PLL, OSC, BO)                                       
.word nullhandler+1             @ 45:       FLASH Control                                                   

@ -----------------------------------------------------------------------------
