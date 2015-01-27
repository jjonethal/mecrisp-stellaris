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
.equ IOCON_PIO1_6,  0x400440A4
.equ IOCON_PIO1_7,  0x400440A8
.equ UARTCLKDIV,    0x40048098

@ LED on P1.8
.equ IOCON_PIO1_8,  0x40044014
.equ GPIO1_DATA,    0x50013FFC
.equ GPIO1_DIR,     0x50018000

@ UART
@ registers appear to share addresses here.  Depending 
@ on the state of DLAB different registers are active.
@ Also some registers are read-only, some write-only

.equ UART_Base, 0x40008000

.equ  U0RBR, UART_Base + 0x000 
.equ  U0THR, UART_Base + 0x000
.equ  U0DLL, UART_Base + 0x000
.equ  U0DLM, UART_Base + 0x004
.equ  U0IER, UART_Base + 0x004
.equ  U0IIR, UART_Base + 0x008
.equ  U0FCR, UART_Base + 0x008
.equ  U0LCR, UART_Base + 0x00C
.equ  U0MCR, UART_Base + 0x010
.equ  U0LSR, UART_Base + 0x014
.equ  U0MSR, UART_Base + 0x018
.equ  U0SCR, UART_Base + 0x01C
.equ  U0ACR, UART_Base + 0x020
.equ  U0FDR, UART_Base + 0x028
.equ  U0TER, UART_Base + 0x030
.equ  U0RS485CTRL, UART_Base + 0x04C
.equ  U0RS485ADRMATCH, UART_Base + 0x050
.equ  U0RS485DLY, UART_Base + 0x054



@ 7.16.1.1 Internal RC oscillator
@  The IRC may be used as the clock source for the WDT, and/or as the clock that drives the
@  PLL and subsequently the CPU. The nominal IRC frequency is 12 MHz. The IRC is
@  trimmed to 1 % accuracy over the entire voltage and temperature range.
@  Upon power-up or any chip reset, the LPC1110/11/12/13/14/15 use the IRC as the clock
@  source. Software may later switch to one of the other available clock sources.

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ Turn on clock for GPIOs
  ldr r0, =SYSAHBCLKCTRL
  ldr r2, =BIT6 + BIT16 @ Enable GPIO and IOCON
  ldr r1, [r0]
  orrs r1, r2
  str r1, [r0]

  @ Enable LED on P1.8

  @ ldr r0, =IOCON_PIO1_6 @ Set P1.8 as GPIO without Pullup/Pulldown
  @ movs r1, #0xC0 @ Reserved bits in this register
  @ str r1, [r0]

  @ ldr r0, =GPIO1_DIR @ Set P1.8 as Output
  @ ldr r1, =256
  @ str r1, [r0]

  @ ldr r0, =GPIO1_DATA @ Let it shine
  @ ldr r1, =256
  @ str r1, [r0]  

  @ Set pin mode for RXD and TXD
  ldr r0, =IOCON_PIO1_6 @ Enable RXD on PIO1_6
  movs r1, #0xC1  
  str r1, [r0]  

  ldr r0, =IOCON_PIO1_7 @ Enable TXD on PIO1_7
  @ movs r1, #0xC1  
  str r1, [r0]  

  @ Turn on clock for UART
  ldr r0, =SYSAHBCLKCTRL
  ldr r2, =BIT12 @ Enable UART
  ldr r1, [r0]
  orrs r1, r2
  str r1, [r0]

  @ Configure UART

  ldr r0, =UARTCLKDIV @ Set UART clock divider to 1
  movs r1, #1
  str r1, [r0]

  ldr r0, =U0LCR @ Enable divisor latch access
  movs r1, #BIT7
  str r1, [r0]

  @ Baud rate clock needs to be 16 * the desired baud rate.
  @ Fractional divider is set to 1 on Reset.
  @ 12 MHz / (115200 Hz * 16) = 6.5  :-(
  @ 12 MHz / (9600 Hz * 16) = 78.125 seems ok.

  @ Baud rate config for 9600 Baud

  @ ldr r0, =U0DLL
  @ movs r1, #78
  @ str r1, [r0]

  @ ldr r0, =U0DLM
  @ movs r1, #0
  @ str r1, [r0]


    @ PCLK is 12 MHz on Reset.
    @ Baud rate = PCLK / [ 16 * (256 * U0DLM + U0DLL) * (1 + DivAddVal/MulVal) ]

    @ The value of MULVAL and DIVADDVAL should comply to the following conditions:
    @   1 <= MULVAL <= 15
    @   0 <= DIVADDVAL <= 14
    @   DIVADDVAL < MULVAL

    @ Example 2: UART_PCLK = 12 MHz, BR = 115200
    @ According to the provided algorithm DLest = PCLK/(16 x BR) = 12 MHz / (16 x 115200) =
    @ 6.51. This DLest is not an integer number and the next step is to estimate the FR
    @ parameter. Using an initial estimate of FRest = 1.5 a new DLest = 4 is calculated and FRest
    @ is recalculated as FRest = 1.628. Since FRest = 1.628 is within the specified range of 1.1
    @ and 1.9, DIVADDVAL and MULVAL values can be obtained from the attached look-up
    @ table.
    @ The closest value for FRest = 1.628 in the look-up Table 201 is FR = 1.625. It is
    @ equivalent to DIVADDVAL = 5 and MULVAL = 8.
    @ Based on these findings, the suggested UART setup would be: DLM = 0, DLL = 4,
    @ DIVADDVAL = 5, and MULVAL = 8. According to Equation 3, the UART’s baud rate is
    @ 115384. This rate has a relative error of 0.16% from the originally specified 115200.

  @ Baud rate config for 115200 Baud

  ldr r0, =U0FDR @ Set DivAddVal = 5; MulVal = 8
  movs r1, #(8<<4)+5
  str r1, [r0]

  ldr r0, =U0DLL
  movs r1, #4
  str r1, [r0]

  ldr r0, =U0DLM
  movs r1, #0
  str r1, [r0]

  @ Baud rate config finished. Enable UART and FIFOs

  ldr r0, =U0LCR @ Disable divisor latch access and set 8N1 mode
  movs r1, #3
  str r1, [r0]

  ldr r0, =U0FCR @ Enable and clear FIFOs with trigger level set to one character
  movs r1, #7
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
   ldr r0, =U0THR  @ Abschicken
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
   ldr tos, =U0RBR    @ Adresse für den Ankunftsregister
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

   ldr r0, =U0LSR
   movs r2, #32     @ Transmitter holding register empty

   ldr r1, [r0]     @ Warte solange bis wieder Platz im Sende-FIFO ist.
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

   ldr r0, =U0LSR
   movs r2, #1      @ Receiver data ready

   ldr r1, [r0]     @ Warte solange bis etwas im Empfangs-FIFO ist.
   ands r1, r2
   beq 1f
     mvns tos, tos
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
