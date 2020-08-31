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

@ stm32wb55 nucleo board uses PB6 and PB7 on USART1

@ -----------------------------------------------------------------------------
uart_init:
        @ ( -- ) A few bits are different
@ -----------------------------------------------------------------------------

	@ Enable all GPIO peripheral clock
	ldr	r1, =RCC_AHB2ENR
	ldr	r0, =BIT7+BIT6+BIT5+BIT4+BIT3+BIT2+BIT1+BIT0 @ $0 is Reset value
	str	r0, [r1]

	@ Enable the USART1 peripheral clock
	ldr	r1, =RCC_APB2ENR
	ldr	r0, =1<<RCC_USART1EN_Shift
	str	r0, [r1]

	@ Set PORTB pins 6 and 7 in alternate function mode 2
	@ green LED2 PB0 and red LED3 PB1 output mode 1
	@ other pins are input mode 0
	ldr	r1, =GPIOB_MODER
	ldr	r0, =2<<GPIOB_MODER7_Shift + 2<<GPIOB_MODER6_Shift + 1<<GPIOB_MODER1_Shift +  1<<GPIOB_MODER0_Shift 
	str	r0, [r1]

	@ set green LED PB0
	ldr	r1, =GPIOB_BSRR
	ldr	r0, =1<<GPIOB_BS0_Shift
	str	r0, [r1]

	@ Set alternate function 7 to enable USART 1 pins on Port B6 and B7
	ldr	r1, =GPIOB_AFRL
	ldr	r0, =7<<GPIOB_AFSEL7_Shift + 7<<GPIOB_AFSEL6_Shift
	str	r0, [r1]

	@ Configure BRR by deviding the bus clock with the baud rate
	ldr	r1, =USART1_BRR
	ldr	r0, =(4000000 + (115200/2)) / 115200  @ 115200 bps, ein ganz kleines bisschen langsamer...
	str	r0, [r1]

	@ disable overrun detection before UE to avoid USART blocking on overflow
	ldr	r1, =USART1_CR3
	ldr	r0, =1<<USART1_OVRDIS_Shift
	str	r0, [r1]

	@ Enable the USART, TX, and RX circuit
	ldr	r1, =USART1_CR1
	ldr	r0, =1<<USART1_UE_Shift + 1<<USART1_TE_Shift + 1<<USART1_RE_Shift
	str	r0, [r1]

	bx	lr

.ifdef turbo
@ change baudrate for 48 MHz mode
@ -----------------------------------------------------------------------------
serial_115200_48MHZ:
        @ set usart1 baudrate to 115200 baud at 48 MHz
@ -----------------------------------------------------------------------------
	ldr	r0, =USART1_BRR
	ldr	r1, =(48000000 + 115200 / 2) / 115200
	str	r1, [r0]
	bx	lr
.endif

@ Following code is the same as for STM32F051
.include "../common/terminalhooks.s"

@ -----------------------------------------------------------------------------
        Wortbirne Flag_visible, "serial-emit"
serial_emit:
        @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
	push	{lr}

1:	bl	serial_qemit
	cmp	tos, #0
	drop
	beq	1b

	ldr	r2, =USART1_TDR
	strb	tos, [r2]			@ Output the character
	drop

	pop	{pc}

@ -----------------------------------------------------------------------------
        Wortbirne Flag_visible, "serial-key"
serial_key:
        @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
	push	{lr}

1:	bl	serial_qkey
	cmp	tos, #0
	drop
	beq	1b

	pushdatos
	ldr	r2, =USART1_RDR
	ldrb	tos, [r2]			@ Fetch the character

	pop	{pc}

@ -----------------------------------------------------------------------------
        Wortbirne Flag_visible, "serial-emit?"
serial_qemit:
        @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
	push	{lr}
	bl	pause

	pushdaconst 0				@ False Flag
	ldr	r0, =USART1_ISR
	ldr	r1, [r0]			@ Fetch status
	ldr	r0, =1<<USART1_TXE_Shift
	ands	r1, r1, r0
	beq	1f
	mvns	tos, tos 			@ True Flag
1:	pop	{pc}

@ -----------------------------------------------------------------------------
        Wortbirne Flag_visible, "serial-key?"
serial_qkey:
        @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
	push	{lr}
	bl	pause

	pushdaconst 0				@ False Flag
	ldr	r0, =USART1_ISR
	ldr	r1, [r0]			@ Fetch status
	ldr	r0, =1<<USART1_RXNE_Shift
	ands	r1, r1, r0
	beq	1f
	mvns	tos, tos			@ True Flag
1:	pop	{pc}

.ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
