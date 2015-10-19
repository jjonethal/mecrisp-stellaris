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

  .equ GPIOA_BASE      ,   0x40020000
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

  .equ RCC_BASE        ,   0x40023800
  .equ RCC_CR          ,   RCC_BASE + 0x00
  .equ RCC_CFGR        ,   RCC_BASE + 0x08
  .equ RCC_AHBENR      ,   RCC_BASE + 0x1C
  .equ RCC_APB1ENR     ,   RCC_BASE + 0x20
  .equ RCC_APB1ENR     ,   RCC_BASE + 0x24

  .equ PWR_BASE        ,   0x40007000
  .equ PWR_CR          ,   PWR_BASE + 0x00
  .equ PWR_CSR         ,   PWR_BASE + 0x04

  .equ Terminal_USART_Base, 0x40004400 @ USART 2
  .include "../common/stm-terminal.s"  @ Common STM terminal code for emit, key and key?

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ Switch internal voltage regulator to high-performance "Range 1"
  ldr r1, =PWR_CR
  movs r0, #BIT11
  str r0, [r1]
  
  @ Select 16 MHz HSI clock instead of MSI which is boot default
  ldr r1, =RCC_CR
  movs r0, #1       @ HSI on
  str r0, [r1]

1:ldr r0, [r1]      @ Check HSIRDY flag
  ands r0, #2
  beq 1b

  ldr r1, =RCC_CFGR
  movs r0, #1       @ HSI as system clock source
  str r0, [r1]

        @ Enable all GPIO peripheral clock
        ldr r1, = RCC_AHBENR
        ldr r0, = 0x80FF @ FLITFEN and all GPIO clocks
        str r0, [r1]

        @ Enable the USART2 peripheral clock by setting bit 17
        ldr r1, = RCC_APB1ENR
        ldr r0, = BIT17
        str r0, [r1]

        @ Set PORTA pins in alternate function mode
        ldr r1, = GPIOA_MODER
        ldr r0, [r1]
        orrs r0, #0xA0
        str r0, [r1]

        @ Set alternate function 7 to enable USART2 pins on Port A
        ldr r1, = GPIOA_AFRL
        ldr r0, = 0x7700              @ Alternate function 7 for TX and RX pins of USART2 on PORTA 
        str r0, [r1]

    @ Configure BRR by deviding the bus clock with the baud rate

    ldr r1, =Terminal_USART_BRR
    movs r0, #0x8B  @ 115200 bps at 16 MHz
    str r0, [r1]

    @ Enable the USART, TX, and RX circuit
    ldr r1, =Terminal_USART_CR1
    ldr r0, =BIT13+BIT3+BIT2 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
    str r0, [r1]

        bx lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
