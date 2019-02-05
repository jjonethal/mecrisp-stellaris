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

.syntax unified
.cpu cortex-m4
.thumb

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
  .equ RCC_AHB1ENR     ,   RCC_BASE + 0x30
  .equ RCC_APB2ENR     ,   RCC_BASE + 0x44

  .equ Terminal_USART_Base, 0x40011400 @ USART 6
  .equ Terminal_USART_SR,    Terminal_USART_Base + 0x00
  .equ Terminal_USART_DR,    Terminal_USART_Base + 0x04
  .equ Terminal_USART_BRR,   Terminal_USART_Base + 0x08
  .equ Terminal_USART_CR1,   Terminal_USART_Base + 0x0C
  .equ Terminal_USART_CR2,   Terminal_USART_Base + 0x10
  .equ Terminal_USART_CR3,   Terminal_USART_Base + 0x14
  .equ Terminal_USART_GTPR,  Terminal_USART_Base + 0x18


.text

  .word 0x20000100
  .word Reset+1

@ -----------------------------------------------------------------------------
Reset:
@ -----------------------------------------------------------------------------

  @ Enable all GPIO peripheral clocks
  ldr r1, = RCC_AHB1ENR
  ldr r0, [r1]
  orrs r0, #0xFF
  str r0, [r1]

  @ Set PORTA 11 and 12 pins as outputs
  ldr r1, = GPIOA_MODER
  ldr r0, [r1]
    bics r0, # 3<<(11*2) | 3<<(12*2)
    orrs r0, # 1<<(11*2) | 1<<(12*2)
  str  r0, [r1]

  movs r3, #16

Blinky:

  ldr r1, =GPIOA_BSRR
  ldr r0, =1<<(11+16) | 1<<(12)
  str r0, [r1]

  movs r2, #0x80000
2:subs r2, #1
  bne 2b

  ldr r1, =GPIOA_BSRR
  ldr r0, =1<<(11) | 1<<(12+16)
  str r0, [r1]

  movs r2, #0x80000
2:subs r2, #1
  bne 2b

  subs r3, #1
  bne.n Blinky


  @ Enable the USART6 peripheral clock by setting bit 5
  ldr r1, = RCC_APB2ENR
  ldr r0, [r1]
  orrs r0, #1<<5
  str r0, [r1]

  @ Set PORTA 11 and 12 pins in alternate function mode
  ldr r1, = GPIOA_MODER
  ldr r0, [r1]
  bics r0, # 3<<(11*2) | 3<<(12*2)
  orrs r0, # 2<<(11*2) | 2<<(12*2)
  str r0, [r1]

  @ Set alternate function 8 for USART 6 pins on PA11 and PA12.  PA11 = D- = TX. PA12 = D+ = RX.
  ldr r1, = GPIOA_AFRH
  ldr r0, [r1]
  bics r0, # 15 << (4*(11-8)) | 15 << (4*(12-8))
  orrs r0, #  8 << (4*(11-8)) |  8 << (4*(12-8))
  str r0, [r1]

  @ Configure BRR by dividing the bus clock with the baud rate

  ldr r1, =Terminal_USART_BRR
  movs r0, #0x8B  @ 115200 bps / 16 MHz HSI
  str r0, [r1]

  @ Enable the USART, TX, and RX circuit
  ldr r1, =Terminal_USART_CR1
  ldr r0, =1<<13|1<<3|1<<2 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
  str r0, [r1]


1:@ Emit a character for test purposes
  ldr r1, =Terminal_USART_DR
  movs r0, 0x42
  strb r0, [r1]

  movs r2, #0x80000
2:subs r2, #1
  bne 2b

  b 1b

  .ltorg
