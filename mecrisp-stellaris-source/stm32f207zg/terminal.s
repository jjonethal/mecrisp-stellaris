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

  .equ GPIOD_BASE      ,   0x40020C00
  .equ GPIOD_MODER     ,   GPIOD_BASE + 0x00
  .equ GPIOD_OTYPER    ,   GPIOD_BASE + 0x04
  .equ GPIOD_OSPEEDR   ,   GPIOD_BASE + 0x08
  .equ GPIOD_PUPDR     ,   GPIOD_BASE + 0x0C
  .equ GPIOD_IDR       ,   GPIOD_BASE + 0x10
  .equ GPIOD_ODR       ,   GPIOD_BASE + 0x14
  .equ GPIOD_BSRR      ,   GPIOD_BASE + 0x18
  .equ GPIOD_LCKR      ,   GPIOD_BASE + 0x1C
  .equ GPIOD_AFRL      ,   GPIOD_BASE + 0x20
  .equ GPIOD_AFRH      ,   GPIOD_BASE + 0x24

  .equ RCC_BASE        ,   0x40023800
  .equ RCC_AHB1ENR     ,   RCC_BASE + 0x30
  .equ RCC_APB1ENR     ,   RCC_BASE + 0x40

  .equ Terminal_USART_Base, 0x40004800 @ USART 3
  .include "../common/stm-terminal.s"  @ Common STM terminal code for emit, key and key?

@ -----------------------------------------------------------------------------
Setup_Clocks: @ ( -- )
@ -----------------------------------------------------------------------------
       @ Enable all GPIO peripheral clock
        ldr r1, = RCC_AHB1ENR
        ldr r0, = BIT8+BIT7+BIT6+BIT5+BIT4+BIT3+BIT2+BIT1+BIT0
        str r0, [r1]
	@ Enable UART3 clock
        ldr r1, = RCC_APB1ENR
        ldr r0, = BIT18
        str r0, [r1]

	bx lr

@ -----------------------------------------------------------------------------
Setup_UART: @ ( -- )
@ -----------------------------------------------------------------------------
@ Configure BRR by deviding the bus clock with the baud rate

	ldr r1, =Terminal_USART_BRR
	ldr r0, =0x8B  @ 115200 bps accoring to documentation
	str r0, [r1]

	@ Enable the USART, TX, and RX circuit
	ldr r1, =Terminal_USART_CR1
	ldr r0, =BIT13+BIT3+BIT2 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
	str r0, [r1]

        @ Set alternate function 7 to enable USART3 pins on Port D
        ldr r1, = GPIOD_AFRH
        ldr r0, = 0x0077              @ Alternate function 7 for TX and RX pins of USART3 on PORTD 8+9
        str r0, [r1]

        @ Set PORTD pins 8+9 in alternate function mode
        ldr r1, = GPIOD_MODER
        ldr r0, [r1]
	ldr r2, = 0x0A0000
        orrs r0, r2
        str r0, [r1]

	bx lr

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

	push {lr}

	bl Setup_Clocks
	bl Setup_UART

	pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
