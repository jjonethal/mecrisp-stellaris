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

@ -----------------------------------------------------------------------------
@ Peripheral registers
@ -----------------------------------------------------------------------------

.equ PRT0_Base, 0x40040000
.equ PRT1_Base, 0x40040100
.equ PRT2_Base, 0x40040200
.equ PRT3_Base, 0x40040300
.equ PRT4_Base, 0x40040400

.equ PRT1_DR,      PRT1_Base + 0x00         @ Port Output Data Register
.equ PRT1_PS,      PRT1_Base + 0x04         @ Port Pin State Register - Reads the logical pin state of I/O
.equ PRT1_PC,      PRT1_Base + 0x08         @ Port Configuration Register - Configures the output drive mode, input threshold, and slew rate
.equ PRT1_INTCFG,  PRT1_Base + 0x0C         @ Port Interrupt Configuration Register
.equ PRT1_INTSTAT, PRT1_Base + 0x10         @ Port Interrupt Status Register
.equ PRT1_PC2,     PRT1_Base + 0x18         @ Port Secondary Configuration Register - Configures the input buffer of I/O pin

.equ PRT2_DR,      PRT2_Base + 0x00         @ Port Output Data Register
.equ PRT2_PS,      PRT2_Base + 0x04         @ Port Pin State Register - Reads the logical pin state of I/O
.equ PRT2_PC,      PRT2_Base + 0x08         @ Port Configuration Register - Configures the output drive mode, input threshold, and slew rate
.equ PRT2_INTCFG,  PRT2_Base + 0x0C         @ Port Interrupt Configuration Register
.equ PRT2_INTSTAT, PRT2_Base + 0x10         @ Port Interrupt Status Register
.equ PRT2_PC2,     PRT2_Base + 0x18         @ Port Secondary Configuration Register - Configures the input buffer of I/O pin

.equ PRT3_DR,      PRT3_Base + 0x00         @ Port Output Data Register
.equ PRT3_PS,      PRT3_Base + 0x04         @ Port Pin State Register - Reads the logical pin state of I/O
.equ PRT3_PC,      PRT3_Base + 0x08         @ Port Configuration Register - Configures the output drive mode, input threshold, and slew rate
.equ PRT3_INTCFG,  PRT3_Base + 0x0C         @ Port Interrupt Configuration Register
.equ PRT3_INTSTAT, PRT3_Base + 0x10         @ Port Interrupt Status Register
.equ PRT3_PC2,     PRT3_Base + 0x18         @ Port Secondary Configuration Register - Configures the input buffer of I/O pin

.equ PRT4_DR,      PRT4_Base + 0x00         @ Port Output Data Register
.equ PRT4_PS,      PRT4_Base + 0x04         @ Port Pin State Register - Reads the logical pin state of I/O
.equ PRT4_PC,      PRT4_Base + 0x08         @ Port Configuration Register - Configures the output drive mode, input threshold, and slew rate
.equ PRT4_INTCFG,  PRT4_Base + 0x0C         @ Port Interrupt Configuration Register
.equ PRT4_INTSTAT, PRT4_Base + 0x10         @ Port Interrupt Status Register
.equ PRT4_PC2,     PRT4_Base + 0x18         @ Port Secondary Configuration Register - Configures the input buffer of I/O pin


@ -----------------------------------------------------------------------------
uart_init:
@ -----------------------------------------------------------------------------

  @ Watchdog timer is not active after reset - no need to take care of it.
  @ Blue LED is connected to P1.6, active High

  ldr r0, =PRT1_PC      @ Drive mode
  ldr r1, =0x00180000
  str r1, [r0]

  @ Three bits for every pin:
  @ 000 0 High-Impedance Analog
  @ 001 1 High-impedance Digital
  @ 010 2 Resistive Pull Up
  @ 011 3 Resistive Pull Down
  @ 100 4 Open Drain, Drives Low
  @ 101 5 Open Drain, Drives High
  @ 110 6 Strong Drive
  @ 111 7 Resistive Pull Up and Down

  ldr r0, =PRT1_PC2    @ Input disable
  ldr r1, =0x00000040
  str r1, [r0]

  ldr r0, =PRT1_DR     @ LED on
  movs r1, #64
  str r1, [r0]

  @ Possible Pinouts for Terminal:
  @
  @   P3.0 SCB1 UART RX, Alternate function 2
  @   P3.1 SCB1 UART TX, Alternate function 2
  @
  @   P4.0 SCB0 UART RX, Alternate function 2  ***   In use on
  @   P4.1 SCB0 UART TX, Alternate function 2  ***  CY8CKIT-049
  @
  @   P0.4 SCB1 UART RX, Alternate function 2
  @   P0.5 SCB1 UART TX, Alternate function 2

  ldr r0, =PRT4_PC
  ldr r1, = 6 << 3 | 1  @ Strong drive for P4.1 TX, digital input for P4.0 RX
  str r1, [r0]

  ldr r0, =PRT4_PC2
  movs r1, #0           @ Do not disable any inputs
  str r1, [r0]

  ldr r0, =PRT4_DR      @ TX high
  movs r1, #2
  str r1, [r0]

  bx lr


@    @ Most simple test: "Electric echo" on the terminal lines
@  
@    ldr r0, =PRT4_PS  @ Pin state = IN Register
@    ldr r1, =PRT4_DR  @             OUT Register
@  
@  1:ldr r2, [r0]
@    lsls r2, #1 @ Shift RX pin signal to TX pin
@    str r2, [r1]
@    b.n 1b
@
@
@    @ TX Test: Transmit characters in a loop
@  
@    movs r6, #0
@  1:bl bitbang_uart_tx
@    adds r6, #1
@  
@    bl delay
@    b.n 1b
@  
@  
@    @ RX & TX Test: Echo characters back with increment
@  
@  1:bl bitbang_uart_rx
@    adds r6, #1
@    bl bitbang_uart_tx
@    b.n 1b



.include "../common/terminalhooks.s"


@ -----------------------------------------------------------------------------
delay_half_bit:
@ -----------------------------------------------------------------------------
  ldr r2, = 312  @ 24 MHz / 4 cycles for each loop run / 2 for half-bit-delay / 9600 Baud = 416
1:subs r2, #1
  bne 1b
  bx lr

@ -----------------------------------------------------------------------------
sample_rx: @ Get RX pin state into LSB of r0
@ -----------------------------------------------------------------------------
  ldr r1, =PRT4_PS
  ldr r0, [r1]
  @ lsrs r0, #0 @ Shift pin to LSB
  movs r1, #1
  ands r0, r1
  bx lr

@ -----------------------------------------------------------------------------
tx_bit: @ Transmit LSB of r0
@ -----------------------------------------------------------------------------
  push {lr}

  movs r1, #1
  ands r0, r1
  lsls r0, #1 @ Shift LSB to pin

  ldr r1, =PRT4_DR
  str r0, [r1]

  bl delay_half_bit
  bl delay_half_bit

  pop {pc}

@ -----------------------------------------------------------------------------
rx_bit: @ Receive one bit into r0
@ -----------------------------------------------------------------------------
  push {lr}
  bl delay_half_bit
  bl delay_half_bit
  bl sample_rx
  pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push {lr}

1: bl serial_qemit
   cmp tos, #0
   drop
   beq 1b

   @ --------
  movs r0, #0                @ Start bit
  bl tx_bit

  lsrs r0, r6, #0
  bl tx_bit

  lsrs r0, r6, #1
  bl tx_bit

  lsrs r0, r6, #2
  bl tx_bit

  lsrs r0, r6, #3
  bl tx_bit

  lsrs r0, r6, #4
  bl tx_bit

  lsrs r0, r6, #5
  bl tx_bit

  lsrs r0, r6, #6
  bl tx_bit

  lsrs r0, r6, #7
  bl tx_bit

  movs r0, #1                @ Stop bit
  bl tx_bit
   @ --------

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

   @ --------
1:bl sample_rx        @ Wait for start bit
  cmp r0, #0
  bne 1b

  bl delay_half_bit   @ Advance to the middle of the bit time

  bl rx_bit
  lsls r6, r0, #0

  bl rx_bit
  lsls r0, #1
  orrs r6, r0

  bl rx_bit
  lsls r0, #2
  orrs r6, r0

  bl rx_bit
  lsls r0, #3
  orrs r6, r0

  bl rx_bit
  lsls r0, #4
  orrs r6, r0

  bl rx_bit
  lsls r0, #5
  orrs r6, r0

  bl rx_bit
  lsls r0, #6
  orrs r6, r0

  bl rx_bit
  lsls r0, #7
  orrs r6, r0

  bl rx_bit     @ Stop bit, to get timing right
   @ --------

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   @ Always true for bitbang terminal.
   pushdaconst 0
   mvns tos, tos

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   @ Always true for bitbang terminal.
   pushdaconst 0
   mvns tos, tos

   pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
