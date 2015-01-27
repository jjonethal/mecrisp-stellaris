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

@ Serial terminal code common to all TI parts which share same UART layout
@ Define Terminal_UART_Base before use !

.equ UART0_BASE, 0x4000C000
.equ UARTDR,     Terminal_UART_Base + 0x000
.equ UARTFR,     Terminal_UART_Base + 0x018
.equ UARTIBRD,   Terminal_UART_Base + 0x024
.equ UARTFBRD,   Terminal_UART_Base + 0x028
.equ UARTLCRH,   Terminal_UART_Base + 0x02C
.equ UARTCTL,    Terminal_UART_Base + 0x030
.equ UARTCC,     Terminal_UART_Base + 0xFC8


.macro Set_Terminal_UART_Baudrate
  
   @ UART-Einstellungen vornehmen

  movs r1, #0         @ UART stop
  ldr  r0, =UARTCTL
  str  r1, [r0]

  @ Baud rate generation:
  @ 16000000 / (16 * 115200 ) = 1000000 / 115200 = 8.6805
  @ 0.6805... * 64 = 43.5   ~ 44
  @ use 8 and 44

  movs r1, #8
  ldr  r0, =UARTIBRD
  str r1, [r0]

  movs r1, #44
  ldr  r0, =UARTFBRD
  str r1, [r0]

  movs r1, #0x60|0x10  @ 8N1, enable FIFOs !
  ldr  r0, =UARTLCRH
  str r1, [r0]

  movs r1, #5          @ Choose PIOSC as source
  ldr  r0, =UARTCC
  str r1, [r0]

  movs    r1, #0
  ldr     r0, =UARTFR
  str r1, [r0]

  movw r1, #0x301      @ UART start
  ldr  r0, =UARTCTL
  str  r1, [r0]

.endm

.include "../common/terminalhooks.s"

@ Werte für den UARTFR-Register
.equ RXFE, 0x10 @ Receive  FIFO empty
.equ TXFF, 0x20 @ Transmit FIFO full

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push {lr}

1: bl serial_qemit
   cmp tos, #0
   drop
   beq 1b

   ldr r0, =UARTDR  @ Abschicken
   str tos, [r0]
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

   ldr r0, =UARTDR    @ Einkommendes Zeichen abholen
   stmdb psp!, {tos}  @ Platz auf dem Datenstack schaffen

   ldr tos, [r0]      @ Register lesen
   uxtb tos, tos      @ 8 Bits davon nehmen, Rest mit Nullen auffüllen.
  
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0
   ldr r0, =UARTFR
   ldr r1, [r0]
   ands r1, #TXFF
   bne 1f
     mvns tos, tos
1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0
   ldr r0, =UARTFR
   ldr r1, [r0]
   ands r1, #RXFE
   bne 1f
     mvns tos, tos
1: pop {pc}
