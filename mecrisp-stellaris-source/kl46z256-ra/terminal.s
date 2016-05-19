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


@ 32 Bit Register

.equ SIM_SCGC4,  0x40048034
.equ SIM_SCGC5,  0x40048038

.equ SIM_SCGC4_UART0_MASK, 0x0400

.equ SIM_SCGC5_PORTA_MASK, 0x0200
.equ SIM_SCGC5_PORTB_MASK, 0x0400
.equ SIM_SCGC5_PORTC_MASK, 0x0800
.equ SIM_SCGC5_PORTD_MASK, 0x1000
.equ SIM_SCGC5_PORTE_MASK, 0x2000


.equ SIM_SOPT2,  0x40048004
.equ SIM_SOPT2_UART0SRC_1,   1<<26

@ 32 Bit Register

.equ PORTA_PCR1,  0x40049004
.equ PORTA_PCR2,  0x40049008


.equ PORT_PCR_MUX_2, 2<<8
.equ SIM_SOPT2_UART0SRC_1,  1<<26


@ Byte-Registers
.equ UART0_BDH,   0x4006A000
.equ UART0_BDL,   0x4006A001
.equ UART0_C1,    0x4006A002
.equ UART0_C2,    0x4006A003
.equ UART0_S1,    0x4006A004
.equ UART0_S2,    0x4006A005
.equ UART0_C3,    0x4006A006
.equ UART0_D,     0x4006A007
.equ UART0_MA1,   0x4006A008
.equ UART0_MA2,   0x4006A009
.equ UART0_C4,    0x4006A00A
.equ UART0_C5,    0x4006A00B

.equ UARTLP_C2_RE_MASK, 0x4
.equ UARTLP_C2_TE_MASK, 0x8

.equ UART_S1_OR_MASK,   0x8

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ Allgemeine Systemeinstellungen

  ldr  r1, = 0x00000180 | SIM_SCGC5_PORTA_MASK | SIM_SCGC5_PORTB_MASK | SIM_SCGC5_PORTC_MASK | SIM_SCGC5_PORTD_MASK | SIM_SCGC5_PORTE_MASK
  ldr  r0, =SIM_SCGC5 @ Alle GPIO-Ports aktivieren  Switch on clock for all GPIO ports
  str  r1, [r0]

  @ Turn on clock to UART0 module and select 48Mhz clock (FLL/PLL source)

  ldr  r1, = 0xF0000030 | SIM_SCGC4_UART0_MASK @ UART aktivieren
  ldr  r0, =SIM_SCGC4
  str  r1, [r0]

  ldr  r1, = 0x00000000 | SIM_SOPT2_UART0SRC_1 @ FLL/PLL source
  ldr  r0, =SIM_SOPT2
  str  r1, [r0]
 
  @ Select "Alt 2" usage to enable UART0 on pins
  ldr r1, =PORT_PCR_MUX_2

  ldr r0, =PORTA_PCR1
  str r1, [r0]
  ldr r0, =PORTA_PCR2
  str r1, [r0]

  @ Init UART
  movs r1, #0
  ldr  r0, =UART0_C2
  strb r1, [r0]
  ldr  r0, =UART0_C1
  strb r1, [r0]  
  ldr  r0, =UART0_C3
  strb r1, [r0]
  ldr  r0, =UART0_S2
  strb r1, [r0]


  @ Set the baud rate divisor
  @ #define UARTLP_BDH_SBR_MASK                      0x1Fu
  @ #define UARTLP_BDH_SBNS_MASK                     0x20u
  @ #define UARTLP_BDH_RXEDGIE_MASK                  0x40u
  @ #define UARTLP_BDH_LBKDIE_MASK                   0x80u
  @ #define UARTLP_BDL_SBR_MASK                      0xFFu

    @ #define OVER_SAMPLE 16
    @ uint16_t divisor = (CORE_CLOCK / OVER_SAMPLE) / baud_rate;
    @ UART0_C4 = UARTLP_C4_OSR(OVER_SAMPLE - 1);
    @ UART0_BDH = (divisor >> 8) & UARTLP_BDH_SBR_MASK;
    @ UART0_BDL = (divisor & UARTLP_BDL_SBR_MASK);

    @ After exiting reset, or recovering from a very low leakage state, the MCG will be in FLL
    @ engaged internal (FEI) mode with MCGCLKOUT at 20.97 MHz, assuming a factory
    @ trimmed slow IRC frequency of 32.768 kHz. If a different MCG mode is required, the
    @ MCG can be transitioned to that mode under software control.

    @ divisor = (20.97MHz / 16) / 115200 = 11.377
    @ --> bdh = 0
    @ --> bdl = 11

    @ divisor = (20.97MHz / 7) / 115200 = 26.004
  
  movs r1, #6 @ Oversampling = 6+1 = 7
  ldr  r0, =UART0_C4
  strb r1, [r0]

  movs r1, #0 @ Baudrate High
  ldr  r0, =UART0_BDH
  strb r1, [r0]

  movs r1, #26 @ Baudrate Low
  ldr  r0, =UART0_BDL
  strb r1, [r0]

  movs r1, #UARTLP_C2_RE_MASK | UARTLP_C2_TE_MASK
  ldr  r0, =UART0_C2
  strb r1, [r0]

  bx lr


.include "../common/terminalhooks.s"

@ Werte für den UART0_S1-Register
.equ UART_S1_RDRF_MASK, 0x20  @ Receive  Data Register Full
.equ UART_S1_TDRE_MASK, 0x80  @ Transmit Data Register Empty

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push {lr}

1: bl serial_qemit
   cmp tos, #0
   drop
   beq 1b

   ldr r0, =UART0_D  @ Abschicken
   strb tos, [r0]
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

   ldr r0, =UART0_D   @ Einkommendes Zeichen abholen
   pushdatos          @ Platz auf dem Datenstack schaffen

   ldrb tos, [r0]     @ Register lesen
   uxtb tos, tos      @ 8 Bits davon nehmen, Rest mit Nullen auffüllen.
  
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   @ Clear receiver overrun flag as it could stall communication completely.
   ldr  r0, =UART0_S1
   movs r1, #UART_S1_OR_MASK
   strb r1, [r0]

   pushdaconst 0

   ldr r0, =UART0_S1
   movs r2, #UART_S1_TDRE_MASK

   ldrb r1, [r0]     @ Warte solange bis Receive-Register voll ist.
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

   @ Clear receiver overrun flag as it could stall communication completely.
   ldr  r0, =UART0_S1
   movs r1, #UART_S1_OR_MASK
   strb r1, [r0]

   pushdaconst 0

   ldr r0, =UART0_S1
   movs r2, #UART_S1_RDRF_MASK

   ldrb r1, [r0]     @ Warte solange bis Receive-Register voll ist.
   ands r1, r2
   beq 1f
     mvns tos, tos
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
