@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@    Copyright (C) 2018  juju2013@github
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
@ nRF52 has 1 interrupt by peripheric, which may share a same ID
@   and the ID is connected to NVIC
@ All interrupt handlers work the same way and are generated with a macro:
@------------------------------------------------------------------------------

interrupt NVIC0
interrupt NVIC1
interrupt NVIC2
interrupt NVIC3
interrupt NVIC4
interrupt NVIC5
interrupt NVIC6
interrupt NVIC7
interrupt NVIC8
interrupt NVIC9
interrupt NVIC10
interrupt NVIC11
interrupt NVIC12
interrupt NVIC13
interrupt NVIC14
interrupt NVIC15
interrupt NVIC16
interrupt NVIC17
interrupt NVIC18
interrupt NVIC19
interrupt NVIC20
interrupt NVIC21
interrupt NVIC22
interrupt NVIC23
interrupt NVIC24
interrupt NVIC25
interrupt NVIC26
interrupt NVIC27
interrupt NVIC28
interrupt NVIC29
interrupt NVIC30
interrupt NVIC31
interrupt NVIC32
interrupt NVIC33
interrupt NVIC34
interrupt NVIC35
interrupt NVIC36
interrupt NVIC37
interrupt NVIC38

.ltorg
@------------------------------------------------------------------------------
