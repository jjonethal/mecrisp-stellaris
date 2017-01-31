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

.equ  WDTCTL, 0x4000480C
.equ    WDTHOLD, 0x0080 @  /* Watchdog timer hold */
.equ    WDTPW,   0x5A00 @  /* WDT Key Value for WDT write access */

.equ  P1IN,   0x40004C00 @  /* Port 1 Input */
.equ  P2IN,   0x40004C01 @  /* Port 2 Input */
.equ  P2OUT,  0x40004C03 @  /* Port 2 Output */
.equ  P1OUT,  0x40004C02 @  /* Port 1 Output */
.equ  P1DIR,  0x40004C04 @  /* Port 1 Direction */
.equ  P2DIR,  0x40004C05 @  /* Port 2 Direction */
.equ  P1REN,  0x40004C06 @  /* Port 1 Resistor Enable */
.equ  P2REN,  0x40004C07 @  /* Port 2 Resistor Enable */
.equ  P1DS,   0x40004C08 @  /* Port 1 Drive Strength */
.equ  P2DS,   0x40004C09 @  /* Port 2 Drive Strength */
.equ  P1SEL0, 0x40004C0A @  /* Port 1 Select 0 */
.equ  P2SEL0, 0x40004C0B @  /* Port 2 Select 0 */
.equ  P1SEL1, 0x40004C0C @  /* Port 1 Select 1 */
.equ  P2SEL1, 0x40004C0D @  /* Port 2 Select 1 */
.equ  P1SELC, 0x40004C16 @  /* Port 1 Complement Select */
.equ  P2SELC, 0x40004C17 @  /* Port 2 Complement Select */

.equ  UCA0CTLW0, 0x40001000 @  /* eUSCI_Ax Control Word Register 0 */
.equ  UCA0BRW,   0x40001006 @  /* eUSCI_Ax Baud Rate Control Word Register */
.equ  UCA0MCTLW, 0x40001008 @  /* eUSCI_Ax Modulation Control Word Register */

.equ    UCSWRST,       0x0001  @  /* Software reset enable */
.equ    UCSSEL__SMCLK, 0x0080  @  /* SMCLK */

.equ  CSKEY,     0x40010400
.equ  CSCTL0,    0x40010404

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ Setup Pins

  movs r1, #0x0C     @ Switch P1.2 and P1.3 to UART mode
  ldr  r0, =P1SEL0
  strb r1, [r0]

  @ Setup Clock

  ldr  r1, =0x695A
  ldr  r0, =CSKEY    @ Unlock CS module for register access
  str  r1, [r0]

  ldr  r1, =0x00030000
  ldr  r0, =CSCTL0   @ Set DCO to 12MHz (nominal, center of 8-16MHz range), reset tuning parameters
  str  r1, [r0]

  movs r1, #0
  ldr  r0, =CSKEY    @ Lock CS module from unintended accesses
  str  r1, [r0]

  @ Setup Communications

  ldr  r1, =UCSWRST               @ Put eUSCI in reset
  ldr  r0, =UCA0CTLW0
  strh r1, [r0]

  ldr  r1, =UCSWRST|UCSSEL__SMCLK @ Set SMCLK as clock source
  strh r1, [r0]

@  movs r1, #26                    @ 3000000 Hz / 115200 Baud = 26.042
@  ldr  r0, =UCA0BRW
@  strh r1, [r0]

@  movs r1, #0                     @ 3000000/115200 - INT(3000000/115200) = 0.042
@  ldr r0, =UCA0MCTLW              @ UCBRSx value = 0x00 (See UG)
@  strh r1, [r0]

  movs r1, #6                     @ 12 MHz / (16*115200 Baud) = 6.5104
  ldr  r0, =UCA0BRW
  strh r1, [r0]

  ldr r1, =0x2081                 @ BRF 8, UCBRS $20, UCOS16
  ldr r0, =UCA0MCTLW
  strh r1, [r0]

  ldr  r1, =UCSSEL__SMCLK         @ Initialize eUSCI
  ldr  r0, =UCA0CTLW0
  strh r1, [r0]

  bx lr


.include "../common/terminalhooks.s"

.equ UCA0RXBUF, 0x4000100C @  /* eUSCI_Ax Receive Buffer Register */
.equ UCA0TXBUF, 0x4000100E @  /* eUSCI_Ax Transmit Buffer Register */
.equ UCA0IFG,   0x4000101C @  /* eUSCI_Ax Interrupt Flag Register */

.equ   UCRXIFG, 0x0001 @  /* Receive interrupt flag */
.equ   UCTXIFG, 0x0002 @  /* Transmit interrupt flag */

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push {lr}

   @ movs r1, #3 @ Switch on P2.0 & P2.1
   @ ldr  r0, =P2DIR
   @ strb r1, [r0]

   @ movs r1, #1 @ Switch on P2.0
   @ ldr r0, =P2OUT
   @ strb r1, [r0]

1: bl serial_qemit
   cmp tos, #0
   drop
   beq 1b

   ldr r0, =UCA0TXBUF  @ Abschicken
   strb tos, [r0]
   drop

   @ movs r1, #0 @ Switch off P2.0
   @ ldr r0, =P2OUT
   @ strb r1, [r0]

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
   push {lr}

   @ movs r1, #3 @ Switch on P2.0 & P2.1
   @ ldr  r0, =P2DIR
   @ strb r1, [r0]

   @ movs r1, #2 @ Switch on P2.1
   @ ldr r0, =P2OUT
   @ strb r1, [r0]

1: bl serial_qkey
   cmp tos, #0
   drop
   beq 1b

   ldr r0, =UCA0RXBUF @ Einkommendes Zeichen abholen
   stmdb psp!, {tos}  @ Platz auf dem Datenstack schaffen

   ldrb tos, [r0]     @ Register lesen
   @ uxtb tos, tos      @ 8 Bits davon nehmen, Rest mit Nullen auffüllen.

   @ movs r1, #0 @ Switch off P2.0
   @ ldr r0, =P2OUT
   @ strb r1, [r0]
  
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0
   ldr r0, =UCA0IFG
   ldrh r1, [r0]
   ands r1, #UCTXIFG
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
   ldr r0, =UCA0IFG
   ldrh r1, [r0]
   ands r1, #UCRXIFG
   beq 1f
     mvns tos, tos
1: pop {pc}


  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
         @ Write the many special hardware locations now !
