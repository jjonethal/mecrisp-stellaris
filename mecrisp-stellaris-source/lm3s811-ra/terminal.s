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

.equ RCGCPIO,    0x400FE108
.equ RCGCUART,   0x400FE104

.equ GPIOA_BASE, 0x40004000
.equ GPIOAFSEL,  0x40004420
.equ GPIODEN,    0x4000451C

.equ Terminal_UART_Base, 0x4000C000 @ UART 0
.include "../common/ti-terminal.s"
.ltorg 
@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------
	movs	r3, #1
    @ SysCtlPeripheralEnable(SYSCTL_PERIPH_UART0);
	ldr	r2, =0x400fe104
	str	r3, [r2]
	@ SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOA);
	str	r3, [r2, #4]
    @ GPIOPinTypeUART(GPIO_PORTA_BASE, GPIO_PIN_0 | GPIO_PIN_1);
	ldr	r2, =0x40004400
	ldr	r4, =0x4000c018  @ (UART0_BASE + UART_O_FR)
	ldr	r3, [r2]
	bic	r3, r3, #3
	str	r3, [r2]
	ldr	r3, [r2, #32]
	add	r2, r2, #260
	orr	r3, r3, #3
	str	r3, [r2, #-228]
	ldr	r3, [r2, #-4]
	orr	r3, r3, #3
	str	r3, [r2, #-4]
	ldr	r3, [r2]
	bic	r3, r3, #3
	str	r3, [r2]
	ldr	r3, [r2, #4]
	bic	r3, r3, #3
	str	r3, [r2, #4]
	ldr	r3, [r2, #20]
	bic	r3, r3, #3
	str	r3, [r2, #20]
	ldr	r3, [r2, #8]
	bic	r3, r3, #3
	str	r3, [r2, #8]
	ldr	r3, [r2, #12]
	bic	r3, r3, #3
	str	r3, [r2, #12]
	ldr	r3, [r2, #16]
	bic	r3, r3, #3
	str	r3, [r2, #16]
	ldr	r3, [r2, #24]
	orr	r3, r3, #3
	str	r3, [r2, #24]
	ldr	r3, [r2, #36]
	bic	r3, r3, #3
	str	r3, [r2, #36]
@     while(HWREG(UART0_BASE + UART_O_FR) & UART_FR_BUSY) {}
.Loop:
	ldr	r0, [r4]
	ands	r0, r0, #8
	bne	.Loop
	movs	r5, #3
@ disable fifo
	ldr	r2, =0x4000c02c @ ulBase + UART_O_LCRH
	ldr	r3, [r2]
	bic	r3, r3, #16
	str	r3, [r2]
@ disable uart
	ldr	r3, =0x4000c030 @ (ulBase + UART_O_CTL)
	ldr	r1, [r3]
	bic	r1, r1, #768
	bic	r1, r1, #1
	str	r1, [r3]
	ldr	r1, [r3]
	bic	r1, r1, #32
	str	r1, [r3]
	ldr	r1, =0x4000c024
	str	r5, [r1]
	movs	r5, #16
	str	r5, [r1, #4]
	movs	r1, #96
	str	r1, [r2]
	str	r0, [r4]
	ldr	r1, [r2]
	orrs	r1, r1, r5
	str	r1, [r2]
	ldr	r2, [r3]
	orr	r2, r2, #768
	orr	r2, r2, #1
	str	r2, [r3]

	bx lr
@ Const
	.align	2

	.ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
         @ Write the many special hardware locations now !
