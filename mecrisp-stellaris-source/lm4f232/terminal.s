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

@ Terminalroutinen
@ Terminal code and initialisations.
@ Porting: Rewrite this !

.equ RCGCGPIO,    0x400FE608
.equ RCGCUART,    0x400FE618

@ albert 20131012 modify to uart5 for LM4F232H5QC
.equ GPIOE_BASE, 0x40024000
.equ GPIOAFSEL,  0x40024420
.equ GPIODEN,    0x4002451C

.equ GPIO_PORTE_PCTL_R, 0x4002452C  @ albert 20131014
.equ GPIO_PORTE_AMSEL_R,0x40024528  @ albert 20131014

@ albert 20131012 modify to uart5 for LM4F232H5QC
.equ Terminal_UART_Base, 0x40011000 @ UART 5
.include "../common/ti-terminal.s"

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  movs r1,#0x20        @ #0x20 ---> UART5 (Albert 20131012) e#1 ---->UART0        @ UART0 aktivieren (enable)
  ldr  r0, =RCGCUART
  str  r1, [r0]

  movs r1, #0x3F      @ Alle GPIO-Ports aktivieren (Enable all GPIO ports)
  ldr  r0, =RCGCGPIO
  str  r1, [r0]

  movs r1, #0x30         @ PE4 und PE5 auf UART-Sonderfunktion schalten (Special function switch) albert 20131013
  ldr  r0, =GPIOAFSEL
  str  r1, [r0]

  movs r1, #0x30    @ PE4 und PE5 als digitale Leitungen aktivieren (activate the digital lines)albert 20131013
  ldr  r0, =GPIODEN
  str  r1, [r0]

@  Note that each pin must be programmed individually; 
@     configure as UART5            @ albert 20131014

    ldr r1, =GPIO_PORTE_PCTL_R      @ R1 = &GPIO_PORTE_PCTL_R
    ldr r0, [r1]                    @ R0 = [R1]
    bic r0, r0, #0x000F0000         @ R0 = R0&~0x00FF0000 (clear port control field for PE4)
    add r0, r0, #0x00010000         @ R0 = R0+0x00110000 (configure PE4 as UART)
    str r0, [r1]                    @ [R1] = R0


    ldr r1, =GPIO_PORTE_PCTL_R      @ R1 = &GPIO_PORTE_PCTL_R
    ldr r0, [r1]                    @ R0 = [R1]
    bic r0, r0, #0x00F00000         @ R0 = R0&~0x00FF0000 (clear port control field for PE5)
    add r0, r0, #0x00100000         @ R0 = R0+0x00110000 (configure PE5 as UART)
    str r0, [r1]                    @ [R1] = R0

  Set_Terminal_UART_Baudrate

  bx lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
         @ Write the many special hardware locations now !
