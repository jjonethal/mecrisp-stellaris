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

  .equ RCC_BASE        ,   0x40021000
  .equ RCC_AHB1ENR     ,   RCC_BASE + 0x48
  .equ RCC_AHB2ENR     ,   RCC_BASE + 0x4C @ gpiod  - b3
  .equ RCC_APB1ENR1    ,   RCC_BASE + 0x58 @ usart2 - b17

        @ stm32l476 discovery board uses PA2, PA15 on usart2
        
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
uart_init: @ ( -- ) A few bits are different 
@ -----------------------------------------------------------------------------

  @ Enable all GPIO peripheral clock
  ldr r1, = RCC_AHB2ENR
  ldr r0, = BIT7+BIT6+BIT5+BIT4+BIT3+BIT2+BIT1+BIT0 @ $0 is Reset value
  str r0, [r1]

  @ Enable the USART2 peripheral clock
  ldr r1, = RCC_APB1ENR1
  ldr r0, = BIT17
  str r0, [r1]

  @ Set PORTA pins 2 and 15 in alternate function mode
  ldr r1, = GPIOA_MODER
  ldr r0, = 0xABFFFFEF @ ABFF FFFF is Reset value for Port A, and switch PA2 and PA15 to alternate function
  str r0, [r1]

  @ Set alternate function 7 to enable USART 2 pins on Port A
  ldr r1, = GPIOA_AFRH
  ldr r0, = 0x30000000      @ Alternate function 3 for RX pins of USART2 on PORTA PA15
  str r0, [r1]
  ldr r1, = GPIOA_AFRL
  ldr r0, = 0x00000700      @ Alternate function 7 for TX pins of USART2 on PORTA PA2
  str r0, [r1]

  @ Configure BRR by deviding the bus clock with the baud rate
  ldr r1, = USART2_BRR
  movs r0, #(4000000 + (115200/2)) / 115200  @ 115200 bps, ein ganz kleines bisschen langsamer...
  str r0, [r1]

  @ disable overrun detection before UE to avoid USART blocking on overflow
  ldr r1, =USART2_CR3
  ldr r0, =BIT12 @ USART_CR3_OVRDIS
  str r0, [r1]

  @ Enable the USART, TX, and RX circuit
  ldr r1, =USART2_CR1
  ldr r0, =BIT3+BIT2+BIT0 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
  str r0, [r1]

  bx lr

.ifdef turbo
@ change baudrate for 48 MHz mode
@ -----------------------------------------------------------------------------
serial_115200_48MHZ: @ set usart2 baudrate to 115200 baud at 48 MHz
@ -----------------------------------------------------------------------------
    ldr r0, =USART2_BRR
    ldr r1, =(48000000 + 115200 / 2) / 115200
    str r1, [r0]
    bx  lr  
.endif  @ .ifdef turbo
  
@ Following code is the same as for STM32F051
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

   pushdaconst 0  @ False Flag
   ldr r0, =USART2_ISR
   ldr r1, [r0]     @ Fetch status
   movs r0, #TXE
   ands r1, r0
   beq 1f
     mvns tos, tos @ True Flag
1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0  @ False Flag
   ldr r0, =USART2_ISR
   ldr r1, [r0]     @ Fetch status
   movs r0, #RXNE
   ands r1, r0
   beq 1f
   mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
