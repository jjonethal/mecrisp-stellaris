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

@ Routinen für die Interrupthandler, die zur Laufzeit neu gesetzt werden können.
@ Code for interrupt handlers that are exchangeable on the fly

@------------------------------------------------------------------------------
@ Alle Interrupthandler funktionieren gleich und werden komfortabel mit einem Makro erzeugt:
@ All interrupt handlers work the same way and are generated with a macro:
@------------------------------------------------------------------------------

interrupt power
interrupt radio
interrupt uart
interrupt spi0
interrupt spi1
interrupt gpiote
interrupt adc
interrupt tim0
interrupt tim1
interrupt tim2
interrupt rtc0
interrupt temp
interrupt rng
interrupt ecb
interrupt ccm_aar
interrupt wdt
interrupt rtc1
interrupt qdec
interrupt lpcomp
interrupt swi0
interrupt swi1
interrupt swi2
interrupt swi3
interrupt swi4
interrupt swi5

.ltorg
@------------------------------------------------------------------------------
