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

        @ GPIO register map is similiar to STM32F4 chips.

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
        .equ GPIOA_BRR       ,   GPIOA_BASE + 0x28

        @ System control registers

        .equ RCC_BASE        ,   0x40021000
        .equ RCC_AHBENR      ,   RCC_BASE + 0x14
        .equ RCC_APB2ENR     ,   RCC_BASE + 0x18
        .equ RCC_APB1ENR     ,   RCC_BASE + 0x1C

        @ Note that the STM32F051 USART is different to the bigger STM32F1/STM32F4 chips.

        .equ USART2_BASE     ,   0x40004400

        .equ USART2_CR1      ,   USART2_BASE + 0x00
        .equ USART2_CR2      ,   USART2_BASE + 0x04
        .equ USART2_CR3      ,   USART2_BASE + 0x08
        .equ USART2_BRR      ,   USART2_BASE + 0x0C
        .equ USART2_GTPR     ,   USART2_BASE + 0x10
        .equ USART2_RTOR     ,   USART2_BASE + 0x14
        .equ USART2_RQR      ,   USART2_BASE + 0x18
        .equ USART2_ISR      ,   USART2_BASE + 0x1C
        .equ USART2_ICR      ,   USART2_BASE + 0x20
        .equ USART2_RDR      ,   USART2_BASE + 0x24
        .equ USART2_TDR      ,   USART2_BASE + 0x28

        @ Flags for USART2_ISR register:
          .equ RXNE            ,   BIT5
          .equ TC              ,   BIT6
          .equ TXE             ,   BIT7

@ -----------------------------------------------------------------------------
uart_init:
@ -----------------------------------------------------------------------------

  @ Turn on the clocks for all GPIOs.
  ldr r1, = RCC_AHBENR
  ldr r0, = BIT17 + BIT18 + BIT19 + BIT20 + BIT22 @ IOPAEN IOPBEN IOPCEN IOPDEN IOPFEN
  str r0, [r1]

  @ Turn on the clock for USART2.
  ldr r1, = RCC_APB1ENR
  ldr r0, = BIT17 @ USART2EN
  str r0, [r1]

  @ Set PORTA pins 2 and 3 in alternate function mode
  ldr r1, = GPIOA_MODER
  ldr r0, = 0x280000A0 @ 2800 0000 is Reset value for Port A, and switch PA2 and PA3 to alternate function
  str r0, [r1]

  @ Set alternate function 1 to enable USART2 pins on Port A
  ldr r1, = GPIOA_AFRL
  ldr r0, = 0x1100     @ Alternate function 1 for TX and RX pins of USART2 on PORTA (PA2 and PA3)
  str r0, [r1]

  @ Configure BRR by deviding the bus clock with the baud rate
  ldr r1, = USART2_BRR
  movs r0, #0x46  @ 115200 bps, ein ganz kleines bisschen langsamer...
  str r0, [r1]

  @ Enable the USART, TX, and RX circuit
  ldr r1, =USART2_CR1
  ldr r0, =BIT3+BIT2+BIT0 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
  str r0, [r1]

  bx lr

.include "../common/terminalhooks.s"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push {lr}

1: bl serial_qemit
   cmp tos, #0
   drop
   beq 1b

   ldr r2, =USART2_TDR
   strb tos, [r2]         @ Output the character
   drop

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
   push {lr}

1: bl serial_qkey
   cmp tos, #0
   drop
   beq 1b

   pushdatos
   ldr r2, =USART2_RDR
   ldrb tos, [r2]         @ Fetch the character

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause
   movs r2, #TXE
   b.n serial_qkey_intern

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause
   movs r2, #RXNE

serial_qkey_intern:
   pushdaconst 0  @ False Flag
   ldr r0, =USART2_ISR
   ldr r1, [r0]     @ Fetch status
   ands r1, r2
   beq 1f
     mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
