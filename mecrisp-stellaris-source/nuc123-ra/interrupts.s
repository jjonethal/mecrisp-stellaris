@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@    Copyright (C) 2017,2018  juju2013@github
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

interrupt pendsv
interrupt bod_out
interrupt wdt
interrupt eint0
interrupt eint1
interrupt gpab
interrupt gpcdf
interrupt pwma
interrupt timer0
interrupt timer1
interrupt timer2
interrupt timer3
interrupt uart0
interrupt uart1
interrupt spi0
interrupt spi1
interrupt spi2
interrupt i2c0
interrupt i2c1
interrupt usb
interrupt ps2
interrupt pdma
interrupt i2s
interrupt pwrwu
interrupt adc

.ltorg
@------------------------------------------------------------------------------
