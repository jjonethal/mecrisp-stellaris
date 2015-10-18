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

@PD5-USART_TX, PD6-USART_RX USART2

  .equ GPIOA_BASE      ,   0x48000000
  .equ GPIOA_MODER     ,   GPIOA_BASE + 0x00
  .equ GPIOA_OTYPER    ,   GPIOA_BASE + 0x04
  .equ GPIOA_OSPEEDR   ,   GPIOA_BASE + 0x08
  .equ GPIOA_PUPDR     ,   GPIOA_BASE + 0x0C
  .equ GPIOA_IDR       ,   GPIOA_BASE + 0x10
  .equ GPIOA_ODR       ,   GPIOA_BASE + 0x14
  .equ GPIOA_BSRR      ,   GPIOA_BASE + 0x18
  .equ GPIOA_LCKR      ,   GPIOA_BASE + 0x1C
  .equ GPIOA_AFRL      ,   GPIOA_BASE + 0x20
  .equ GPIOA_AFRH      ,   GPIOA_BASE + 0x24

  .equ GPIOD_BASE      ,   0x48000C00
  .equ GPIOD_MODER     ,   GPIOA_BASE + 0x00
  .equ GPIOD_OTYPER    ,   GPIOA_BASE + 0x04
  .equ GPIOD_OSPEEDR   ,   GPIOA_BASE + 0x08
  .equ GPIOD_PUPDR     ,   GPIOA_BASE + 0x0C
  .equ GPIOD_IDR       ,   GPIOA_BASE + 0x10
  .equ GPIOD_ODR       ,   GPIOA_BASE + 0x14
  .equ GPIOD_BSRR      ,   GPIOA_BASE + 0x18
  .equ GPIOD_LCKR      ,   GPIOA_BASE + 0x1C
  .equ GPIOD_AFRL      ,   GPIOA_BASE + 0x20
  .equ GPIOD_AFRH      ,   GPIOA_BASE + 0x24

  .equ RCC_BASE        ,   0x40021000
  .equ RCC_AHB2ENR     ,   RCC_BASE + 0x4C
  .equ RCC_APB1ENR1    ,   RCC_BASE + 0x58



  .equ Terminal_USART_Base, 0x40004400 @ USART 2
  .include "../common/stm-terminal.s"  @ Common STM terminal code for emit, key and key?

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

        @ Enable all GPIO peripheral clocks
        ldr r1, = RCC_AHB2ENR
        movs r0, #0xFF
        str r0, [r1]

        @ Set PORTD pins in alternate function mode
        ldr r1, = GPIOD_MODER
        ldr r0, [r1]
        orrs r0, #0x2800  @ PD5, PD6 Alternate function 
        str r0, [r1]

        @ Set alternate function 7 to enable USART2 pins on Port PD5 and PD6
        ldr  r1, = GPIOA_AFRL
        and  r0, 0xF00FFFFF      @ Zero the bits 20-27
        orrs r0, #0x07700000     @ Alternate function 7 for TX and RX pins of USART2 on PORTA(5,6)
        str  r0, [r1]

        @ Enable the USART2 peripheral clock by setting bit 17
        ldr r1, = RCC_APB1ENR1
        ldr r0, = BIT17
        str r0, [r1]
@@@@@TODO::

    @ Configure BRR by deviding the bus clock with the baud rate

    ldr r1, =Terminal_USART_BRR
    movs r0, #0x8B  @ 115200 bps / 16 MHz HSI
    str r0, [r1]

    @ Enable the USART, TX, and RX circuit
    ldr r1, =Terminal_USART_CR1
    ldr r0, =BIT13+BIT3+BIT2 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
    str r0, [r1]

        bx lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
