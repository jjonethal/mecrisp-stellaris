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

@ Common Cortex core vector tables

.ifdef m0core @ Common vector table for all Cortex M0 targets

.equ addresszero, . @ This is needed to circumvent address relocation issues.

.word returnstackanfang  @ 00: Stack top address
.word Reset+1            @ 01: Reset Vector  +1 wegen des Thumb-Einsprunges

.word faulthandler+1  @ 02: The NMI handler
.word faulthandler+1  @ 03: The hard fault handler
.word 0               @ 04: The MPU fault handler
.word 0               @ 05: Reserved
.word 0               @ 06: Reserved
.word 0               @ 07: Reserved
.word 0               @ 08: Reserved
.word 0               @ 09: Reserved
.word 0               @ 10: Reserved
.word nullhandler+1   @ 11: SVCall handler
.word 0               @ 12: Reserved
.word 0               @ 13: Reserved
.word nullhandler+1   @ 14: The PendSV handler
.word irq_vektor_systick+1   @ 15: The SysTick handler

.else @ Common vector table for all Cortex M3/M4 targets

.word returnstackanfang  @ 00: Stack top address
.word Reset+1            @ 01: Reset Vector  +1 wegen des Thumb-Einsprunges

.word faulthandler+1  @ 02: The NMI handler
.word faulthandler+1  @ 03: The hard fault handler
.word faulthandler+1  @ 04: The MPU fault handler
.word faulthandler+1  @ 05: The bus fault handler
.word faulthandler+1  @ 06: The usage fault handler
.word 0               @ 07: Reserved
.word 0               @ 08: Reserved
.word 0               @ 09: Reserved
.word 0               @ 10: Reserved
.word nullhandler+1   @ 11: SVCall handler
.word nullhandler+1   @ 12: Debug monitor handler
.word 0               @ 13: Reserved
.word nullhandler+1   @ 14: The PendSV handler
.word irq_vektor_systick+1   @ 15: The SysTick handler

.endif

@ Bis hierhin ist die Interruptvektortabelle bei allen ARM Cortex Chips gleich.
@ Danach geht es mit den Besonderheiten eines jeden Chips los.  
