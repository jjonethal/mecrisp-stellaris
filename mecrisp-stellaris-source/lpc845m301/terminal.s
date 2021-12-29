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

.equ SYSAHBCLKCTRL, 0x40048080
.equ PINASSIGN0,    0x4000C000
.equ UART0CLKSEL,   0x40048090

.equ FRG0DIV,       0x400480D0
.equ FRG0MULT,      0x400480D4
.equ FRG0CLKSEL,    0x400480D8

.equ DIR0    , 0xA0002000
.equ DIR1    , 0xA0002004
.equ MASK0   , 0xA0002080
.equ MASK1   , 0xA0002084
.equ PIN0    , 0xA0002100
.equ PIN1    , 0xA0002104
.equ MPIN0   , 0xA0002180
.equ SET0    , 0xA0002200
.equ SET1    , 0xA0002204
.equ CLR0    , 0xA0002280
.equ CLR1    , 0xA0002284
.equ NOT0    , 0xA0002300
.equ NOT1    , 0xA0002304
.equ DIRSET0 , 0xA0002380
.equ DIRSET1 , 0xA0002384
.equ DIRCLR0 , 0xA0002400
.equ DIRCLR1 , 0xA0002404
.equ DIRNOT0 , 0xA0002480
.equ DIRNOT1 , 0xA0002484

.equ UART_Base, 0x40064000

.equ CFG       , UART_Base + 0x000
.equ CTL       , UART_Base + 0x004
.equ STAT      , UART_Base + 0x008
.equ INTENSET  , UART_Base + 0x00C
.equ INTENCLR  , UART_Base + 0x010
.equ RXDAT     , UART_Base + 0x014
.equ RXDATSTAT , UART_Base + 0x018
.equ TXDAT     , UART_Base + 0x01C
.equ BRG       , UART_Base + 0x020
.equ INTSTAT   , UART_Base + 0x024
.equ OSR       , UART_Base + 0x028
.equ ADDR      , UART_Base + 0x02C


@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ Turn on clock for GPIOs and UART0

  ldr r0, =SYSAHBCLKCTRL
  ldr r1, =BIT28|BIT20|BIT18| BIT14 | BIT7|BIT6|BIT4|BIT2|BIT1|BIT0
  str r1, [r0]

  @ Enable LEDs on P1.0 (green), P1.1 (blue), P1.2 (red)

  ldr  r0, =DIR1
  movs r1, #7
  str  r1, [r0]

  ldr r0, =PIN1
  movs r1, #BIT2|BIT1 @ Set all other LED bits high, as they are active low. Only one can be activated at once.
  str r1, [r0]

  @ Configure pins for communication

  ldr r0, =DIR0
  ldr r1, =BIT25 @ Set TXD as output.
  str r1, [r0]

  ldr r0, =PIN0
  ldr r1, =BIT25 @ Set TXD high.
  str r1, [r0]

  @ Assign UART RX and TX pins

  ldr r0, =PINASSIGN0
  ldr r1, =0xFFFF1819 @ CTS disabled, RTS disabled, RXD on P0.24, TXD on P0.25. See User Manual, 10.5.1 Pin assign register 0, page 135.
  str r1, [r0]

  @ Configure fractional clock generator

  ldr  r0, =FRG0DIV
  movs r1, #255
  str r1, [r0]

  ldr  r0, =FRG0MULT
  movs r1, #22          @ 256 * ( 1 / (6 / 12e6 * (115200*16) ) - 1 ) =  21.778
  str r1, [r0]

  ldr  r0, =FRG0CLKSEL
  movs r1, #1           @ Main clock
  str r1, [r0]

  @ Configure UART clock source

  ldr r0, =UART0CLKSEL
  movs r1, 2 @ FRG0
  str r1, [r0]

  @ PRESETCTRL0 is -1, all peripheral resets are cleared for default.

  @ Configure UART

  ldr r0, =BRG
  movs r1, #5  @ Output of FPG0 is divided by 5+1 for 16x desired baud clock of 115200 baud.
  str r1, [r0]

  ldr r0, =CFG
  movs r1, #BIT2 | BIT0 @ 8 Bits | Enable
  str r1, [r0]

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

   uxtb tos, tos
   ldr r0, =TXDAT  @ Abschicken
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

   pushdatos          @ Platz auf dem Datenstack schaffen
   ldr tos, =RXDAT    @ Adresse für den Ankunftsregister
   ldr tos, [tos]     @ Einkommendes Zeichen abholen
   uxtb tos, tos      @ 8 Bits davon nehmen

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0

   ldr r0, =STAT
   movs r2, #4     @ Transmitter Ready

   ldr r1, [r0]
   ands r1, r2
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

   ldr r0, =STAT
   movs r2, #1      @ Receiver Ready

   ldr r1, [r0]
   ands r1, r2
   beq 1f
     mvns tos, tos
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
