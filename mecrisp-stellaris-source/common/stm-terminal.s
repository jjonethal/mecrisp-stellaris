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

@ Serial terminal code common to all STM parts which share same UART layout
@ Define Terminal_USART_Base before use !

  .equ Terminal_USART_SR,    Terminal_USART_Base + 0x00
  .equ Terminal_USART_DR,    Terminal_USART_Base + 0x04
  .equ Terminal_USART_BRR,   Terminal_USART_Base + 0x08
  .equ Terminal_USART_CR1,   Terminal_USART_Base + 0x0c
  .equ Terminal_USART_CR2,   Terminal_USART_Base + 0x10
  .equ Terminal_USART_CR3,   Terminal_USART_Base + 0x14
  .equ Terminal_USART_GTPR,  Terminal_USART_Base + 0x18

  .equ RXNE,  BIT5
  .equ TC,    BIT6
  .equ TXE,   BIT7

  @ Baudrate settings: Bit 11-4 Divider, Bit 3-0 Fractional

  @ Baud rate generation for 16 MHz:
  @ 16000000 / (16 * 115200 ) = 1000000 / 115200 = 8.6805
  @ 0.6805... * 16 = 10,8 rounds to 11 = B
  @ $8B

  @ For 8 MHz:

  @  8000000 / (16 * 115200 ) = 4.3403
  @  0.3403 * 16 = 5.4448
  @  Divider 4, Fractional term 5 or 6 --> $45 or $46.

  .macro Set_Terminal_USART_Baudrate
  
    @ Configure BRR by deviding the bus clock with the baud rate

    ldr r1, =Terminal_USART_BRR
    @ ldr r0, =0x341  @  9600 bps
    @ movs r0, #0xD0  @ 38400 bps
    @ movs r0, #0x45  @ 115200 bps
    movs r0, #0x46  @ 115200 bps, ein ganz kleines bisschen langsamer...
    str r0, [r1]

    @ Enable the USART, TX, and RX circuit
    ldr r1, =Terminal_USART_CR1
    ldr r0, =BIT13+BIT3+BIT2 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
    str r0, [r1]

  .endm
 
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

   ldr r2, =Terminal_USART_DR
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
   ldr r2, =Terminal_USART_DR
   ldrb tos, [r2]         @ Fetch the character

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0
   ldr r0, =Terminal_USART_SR
   ldr r1, [r0]     @ Fetch status
   movs r0, #TXE
   ands r1, r0
   beq 1f
     mvns tos, tos
1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0
   ldr r0, =Terminal_USART_SR
   ldr r1, [r0]     @ Fetch status
   movs r0, #RXNE
   ands r1, r0
   beq 1f
     mvns tos, tos
1: pop {pc}
