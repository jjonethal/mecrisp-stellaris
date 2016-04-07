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

@ Terminal interface for stm32f746GDiscovery via debug virtual comport
@ VCP_TX - PA9 USART1 AF7 USART1_TX
@ VCP_RX - PB7 USART1 AF7 USART1_RX


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

  .equ GPIOB_BASE      ,   (0x40020000 + (1*0x400))
  .equ GPIOB_MODER     ,   GPIOB_BASE + 0x00
  .equ GPIOB_OTYPER    ,   GPIOB_BASE + 0x04
  .equ GPIOB_OSPEEDR   ,   GPIOB_BASE + 0x08
  .equ GPIOB_PUPDR     ,   GPIOB_BASE + 0x0C
  .equ GPIOB_IDR       ,   GPIOB_BASE + 0x10
  .equ GPIOB_ODR       ,   GPIOB_BASE + 0x14
  .equ GPIOB_BSRR      ,   GPIOB_BASE + 0x18
  .equ GPIOB_LCKR      ,   GPIOB_BASE + 0x1C
  .equ GPIOB_AFRL      ,   GPIOB_BASE + 0x20
  .equ GPIOB_AFRH      ,   GPIOB_BASE + 0x24
  
  .equ GPIOK_MODER     ,   (GPIOA_BASE + (10*0x400))

  .equ RCC_BASE        ,   0x40023800
  .equ RCC_AHB1ENR     ,   RCC_BASE + 0x30
  .equ RCC_APB1ENR     ,   RCC_BASE + 0x40
  .equ RCC_APB2ENR     ,   RCC_BASE + 0x44

  .equ Terminal_USART_Base, 0x40011000 @ USART 1

  .equ Terminal_CR1    ,   Terminal_USART_Base + 0x00
  .equ Terminal_CR2    ,   Terminal_USART_Base + 0x04
  .equ Terminal_CR3    ,   Terminal_USART_Base + 0x08
  .equ Terminal_BRR    ,   Terminal_USART_Base + 0x0C
  .equ Terminal_GTPR   ,   Terminal_USART_Base + 0x10
  .equ Terminal_RTOR   ,   Terminal_USART_Base + 0x14
  .equ Terminal_RQR    ,   Terminal_USART_Base + 0x18
  .equ Terminal_ISR    ,   Terminal_USART_Base + 0x1C
  .equ Terminal_ICR    ,   Terminal_USART_Base + 0x20
  .equ Terminal_RDR    ,   Terminal_USART_Base + 0x24
  .equ Terminal_TDR    ,   Terminal_USART_Base + 0x28

@ defs for USART_CR1 register
  .equ USART_CR1_UE    ,   BIT0
  .equ USART_CR1_TE    ,   BIT3
  .equ USART_CR1_RE    ,   BIT2
@ Flags for USART_ISR register:
  .equ RXNE            ,   BIT5
  .equ TC              ,   BIT6
  .equ TXE             ,   BIT7
@ Flag for USART_CR3
  .equ USART_CR3_OVRDIS ,  BIT12
  
@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ Enable all GPIO peripheral clocks
  ldr  r1, = RCC_AHB1ENR
  ldr  r0, [r1]
  orrs r0, #0x00F
  orrs r0, #0x7F0
  str  r0, [r1]
  
  @ shutdown display illumination for now
  ldr r1, =GPIOK_MODER
  ldr r0, =0x80
  str r0, [r1]  

  @ Set PORTA pins in alternate function mode
  ldr  r1, = GPIOA_MODER
  ldr  r0, [r1]
  and  r0, #0xFFF3FFFF     @ Zero the bits 18-19 config for PA9 
  orrs r0, #0x00080000     @ AF mode for PA9
  str  r0, [r1]

  @ Set PORTB pins in alternate function mode
  ldr r1, = GPIOB_MODER
  ldr r0, [r1]
  and r0,  #0xFFFF3FFF     @ Zero the bits 14-15 config for PB7 
  orrs r0, #0x00008000     @ AF mode for PB7
  str r0, [r1]

  @ Set alternate function 7 to enable USART1 pins on Port PA9
  ldr  r1, = GPIOA_AFRH
  ldr r0, [r1]
  and  r0, #0xFFFFFF0F     @ Zero the bits 4-7
  orrs r0, #0x70          @ Alternate function 7 for TX pin of USART1 on PA9
  str  r0, [r1]

  @ Set alternate function 7 to enable USART1 pins on Port PB7
  ldr  r1, = GPIOB_AFRL
  ldr  r0, [r1]
  and  r0, #0x0FFFFFFF    @ Zero the bits 28-31
  orrs r0, #0x70000000    @ Alternate function 7 for RX pin of USART1 on PB7
  str  r0, [r1]

  @ Enable the USART1 peripheral clock by setting bit 4
  ldr r1, = RCC_APB2ENR
  ldr r0, [r1]
  orrs r0, #0x10
  str r0, [r1]

  @ Configure BRR by dividing the bus clock with the baud rate
  ldr  r1, =Terminal_BRR
  movs r0, #0x8B @#(16000000 + 1152000 / 2) / 115200 @ 0x8B  -> 16 MHz HSI / 115200 baud  
  str  r0, [r1]

  @ disable overrun detection before UE to avoid USART blocking on overflow
  ldr r1, =Terminal_CR3
  ldr r0, =USART_CR3_OVRDIS @ USART_CR3_OVRDIS
  str r0, [r1]

  @ Enable the USART, TX, and RX circuit
  ldr r1, =Terminal_CR1
  ldr r0, =USART_CR1_UE + USART_CR1_TE + USART_CR1_RE
  str r0, [r1]

  bx lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !

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

   ldr r2, =Terminal_TDR
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
   ldr r2, =Terminal_RDR
   ldrb tos, [r2]         @ Fetch the character

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0    @ False Flag
   ldr r0, =Terminal_ISR
   ldr r1, [r0]     @ Fetch status
   movs r0, #TXE
   ands r1, r0
   beq 1f
   mvns tos, tos    @ True Flag
1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0  @ False Flag
   ldr r0, =Terminal_ISR
   ldr r1, [r0]     @ Fetch status
   movs r0, #RXNE
   ands r1, r0
   beq 1f
   mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
