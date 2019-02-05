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

.word irq_vektor_port0+1 @ Position  0:  GPIO Interrupt - Port 0
.word irq_vektor_port1+1 @ Position  1:  GPIO Interrupt - Port 1
.word irq_vektor_port2+1 @ Position  2:  GPIO Interrupt - Port 2
.word irq_vektor_port3+1 @ Position  3:  GPIO Interrupt - Port 3
.word irq_vektor_port4+1 @ Position  4:  GPIO Interrupt - Port 4
.word nullhandler+1      @ Position  5:  <DSI-only>
.word nullhandler+1      @ Position  6:  <DSI-only>  
.word nullhandler+1      @ Position  7:  <DSI-only> 
.word nullhandler+1      @ Position  8:  LPCOMP (Low-power Comparator) 
.word nullhandler+1      @ Position  9:  WDT (Watchdog timer) 
.word nullhandler+1      @ Position 10:  SCB1 (Serial Communication Block 1) 
.word nullhandler+1      @ Position 11:  SCB2 (Serial Communication Block 2) 
.word nullhandler+1      @ Position 12:  SPC (System Performance Controller) 
.word nullhandler+1      @ Position 13:  PWR (Power Manager) 
.word irq_vektor_adc+1   @ Position 14:  SAR (Successive Approximation ADC) 
.word nullhandler+1      @ Position 15:  CSD (CapSense block counter overflow interrupt) 
.word nullhandler+1      @ Position 16:  TCPWM0 (Timer/Counter/PWM 0) 
                                    
.word nullhandler+1      @ Position 17:  TCPWM1 (Timer/Counter/PWM 1)
.word nullhandler+1      @ Position 18:  TCPWM2 (Timer/Counter/PWM 2)
.word nullhandler+1      @ Position 19:  TCPWM3 (Timer/Counter/PWM 3)
.word nullhandler+1      @ Position 20:  <DSI-only>
.word nullhandler+1      @ Position 21:  <DSI-only>
.word nullhandler+1      @ Position 22:  <DSI-only>
.word nullhandler+1      @ Position 23:  <DSI-only>
.word nullhandler+1      @ Position 24:  <DSI-only>
.word nullhandler+1      @ Position 25:  <DSI-only>
.word nullhandler+1      @ Position 26:  <DSI-only>
.word nullhandler+1      @ Position 27:  <DSI-only>
.word nullhandler+1      @ Position 28:  <DSI-only>
.word nullhandler+1      @ Position 29:  <DSI-only>
.word nullhandler+1      @ Position 30:  <DSI-only>
.word nullhandler+1      @ Position 31:  <DSI-only>


@ -----------------------------------------------------------------------------
