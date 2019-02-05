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
@  Wires and Connections on the XMC2GO board:
@ -----------------------------------------------------------------------------

@ P1.0  Red LED 1
@ P1.1  Red LED 2

@ P2.1  TXD
@ P2.2  RXD

@ On Reset, the chip runs with internal 8 MHz oscillator.

@ -----------------------------------------------------------------------------
@  GPIO
@ -----------------------------------------------------------------------------

.equ P0_BASE, 0x40040000
.equ P1_BASE, 0x40040100
.equ P2_BASE, 0x40040200

.equ P0_OUT    , P0_BASE + 0x0000
.equ P0_OMR    , P0_BASE + 0x0004
.equ P0_IOCR0  , P0_BASE + 0x0010
.equ P0_IOCR4  , P0_BASE + 0x0014
.equ P0_IOCR8  , P0_BASE + 0x0018
.equ P0_IOCR12 , P0_BASE + 0x001c
.equ P0_IN     , P0_BASE + 0x0024
.equ P0_PHCR0  , P0_BASE + 0x0040
.equ P0_PHCR1  , P0_BASE + 0x0044
.equ P0_PDISC  , P0_BASE + 0x0060
.equ P0_PPS    , P0_BASE + 0x0070
.equ P0_HWSEL  , P0_BASE + 0x0074

.equ P1_OUT    , P1_BASE + 0x0000
.equ P1_OMR    , P1_BASE + 0x0004
.equ P1_IOCR0  , P1_BASE + 0x0010
.equ P1_IOCR4  , P1_BASE + 0x0014
.equ P1_IOCR8  , P1_BASE + 0x0018
.equ P1_IOCR12 , P1_BASE + 0x001c
.equ P1_IN     , P1_BASE + 0x0024
.equ P1_PHCR0  , P1_BASE + 0x0040
.equ P1_PHCR1  , P1_BASE + 0x0044
.equ P1_PDISC  , P1_BASE + 0x0060
.equ P1_PPS    , P1_BASE + 0x0070
.equ P1_HWSEL  , P1_BASE + 0x0074

.equ P2_OUT    , P2_BASE + 0x0000
.equ P2_OMR    , P2_BASE + 0x0004
.equ P2_IOCR0  , P2_BASE + 0x0010
.equ P2_IOCR4  , P2_BASE + 0x0014
.equ P2_IOCR8  , P2_BASE + 0x0018
.equ P2_IOCR12 , P2_BASE + 0x001c
.equ P2_IN     , P2_BASE + 0x0024
.equ P2_PHCR0  , P2_BASE + 0x0040
.equ P2_PHCR1  , P2_BASE + 0x0044
.equ P2_PDISC  , P2_BASE + 0x0060
.equ P2_PPS    , P2_BASE + 0x0070
.equ P2_HWSEL  , P2_BASE + 0x0074

@ -----------------------------------------------------------------------------
@  System control - not necessary, those registers are set through the "vector table"
@ -----------------------------------------------------------------------------

@ .equ SCU_BASE, 0x40010000
@ .equ SCU_GCU_BASE, SCU_BASE + 0x000
@ .equ SCU_CCU_BASE, SCU_BASE + 0x300

@ .equ SCU_PASSWD,   SCU_GCU_BASE + 0x24
@ .equ SCU_CGATCLR0, SCU_CCU_BASE + 0x10

@ -----------------------------------------------------------------------------
@  USCI0, the UART
@ -----------------------------------------------------------------------------

.equ USIC0_CH0_BASE, 0x48000000

.equ USIC0_ID         , USIC0_CH0_BASE + 0x08

.equ USIC0_CH0_CCFG   , USIC0_CH0_BASE + 0x004
.equ USIC0_CH0_KSCFG  , USIC0_CH0_BASE + 0x00c
.equ USIC0_CH0_FDR    , USIC0_CH0_BASE + 0x010
.equ USIC0_CH0_BRG    , USIC0_CH0_BASE + 0x014
.equ USIC0_CH0_INPR   , USIC0_CH0_BASE + 0x018
.equ USIC0_CH0_DX0CR  , USIC0_CH0_BASE + 0x01c
.equ USIC0_CH0_DX1CR  , USIC0_CH0_BASE + 0x020
.equ USIC0_CH0_DX2CR  , USIC0_CH0_BASE + 0x024
.equ USIC0_CH0_DX3CR  , USIC0_CH0_BASE + 0x028
.equ USIC0_CH0_DX4CR  , USIC0_CH0_BASE + 0x02c
.equ USIC0_CH0_DX5CR  , USIC0_CH0_BASE + 0x030
.equ USIC0_CH0_SCTR   , USIC0_CH0_BASE + 0x034
.equ USIC0_CH0_TCSR   , USIC0_CH0_BASE + 0x038
.equ USIC0_CH0_PCR    , USIC0_CH0_BASE + 0x03c
.equ USIC0_CH0_CCR    , USIC0_CH0_BASE + 0x040
.equ USIC0_CH0_CMTR   , USIC0_CH0_BASE + 0x044
.equ USIC0_CH0_PSR    , USIC0_CH0_BASE + 0x048
.equ USIC0_CH0_PSCR   , USIC0_CH0_BASE + 0x04c

.equ USIC0_CH0_RBUFSR         , USIC0_CH0_BASE + 0x050
.equ USIC0_CH0_RBUF           , USIC0_CH0_BASE + 0x054
.equ USIC0_CH0_RBUFD          , USIC0_CH0_BASE + 0x058
.equ USIC0_CH0_RBUF0          , USIC0_CH0_BASE + 0x05c
.equ USIC0_CH0_RBUF1          , USIC0_CH0_BASE + 0x060
.equ USIC0_CH0_RBUF01SR       , USIC0_CH0_BASE + 0x064
.equ USIC0_CH0_FMR            , USIC0_CH0_BASE + 0x068

@ USIC0_CH0_TBUF IS AN ARRAY OF 32 WORDS (INDEX 0 TO 31)
.equ USIC0_CH0_TBUF           , USIC0_CH0_BASE + 0x080

.equ USIC0_CH0_BYP            , USIC0_CH0_BASE + 0x100
.equ USIC0_CH0_BYPCR          , USIC0_CH0_BASE + 0x104
.equ USIC0_CH0_TBCTR          , USIC0_CH0_BASE + 0x108
.equ USIC0_CH0_RBCTR          , USIC0_CH0_BASE + 0x10c
.equ USIC0_CH0_TRBPTR         , USIC0_CH0_BASE + 0x110
.equ USIC0_CH0_TRBSR          , USIC0_CH0_BASE + 0x114
.equ USIC0_CH0_TRBSCR         , USIC0_CH0_BASE + 0x118
.equ USIC0_CH0_OUTR           , USIC0_CH0_BASE + 0x11c
.equ USIC0_CH0_OUTDR          , USIC0_CH0_BASE + 0x120

@ USIC_CH0_IN IS AN ARRAY OF 32 WORDS (INDEX 0 TO 31)
.equ USIC0_CH0_IN             , USIC0_CH0_BASE + 0x180

@ UART baud rate constants for 115.2kbps @ MCLK=8MHz
.equ UART_FDR_STEP, 590 @ 590 is the calculated value, but values in the range of 565 to 585 work fine with my chip.
.equ UART_BRG_PDIV, 3
.equ UART_BRG_DCTQ, 9
.equ UART_BRG_PCTQ, 0

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  @ LED's are on P1.0 and P1.1
  @ So make these push-pull outputs and set to high

  @ ldr r0, =P1_IOCR0
  @ ldr r1, =(1 << 15) | ( 1 << 7)
  @ str r1, [r0]

  @ ldr r0, =P1_OUT
  @ movs r1, #3
  @ str r1, [r0]

  
  @ Set pins of P2 to digital mode
  ldr r0, =P2_PDISC
  movs r1, #0
  str r1, [r0]
      
  @ Enable the module kernel clock and the module functionality
  ldr r0, =USIC0_CH0_KSCFG
  movs r1, #BIT1 + BIT0
  str r1, [r0]
   
  @ fFD = fPB, FDR.DM = 02b (Fractional divider mode)
  ldr r0, =USIC0_CH0_FDR
  ldr r1, =(2 << 14) | UART_FDR_STEP
  str r1, [r0]
  
  @ Configure baud rate generator
  @ BAUDRATE = fCTQIN/(BRG.PCTQ x BRG.DCTQ)
  @ CLKSEL = 0 (fPIN = fFD), CTQSEL = 00b (fCTQIN = fPDIV), PPPEN = 0 (fPPP=fPIN)
  ldr r0, =USIC0_CH0_BRG
  ldr r1, =(UART_BRG_PCTQ << 8) | (UART_BRG_DCTQ << 10) | (UART_BRG_PDIV << 16)
  str r1, [r0]

  @ Configuration of USIC Shift Control
  @ SCTR.FLE = 8 (Frame Length)
  @ SCTR.WLE = 8 (Word Length)
  @ SCTR.TRM = 1 (Transmission Mode)
  @ SCTR.PDL = 1 (This bit defines the output level at the shift data output signal when no data is available for transmission)

  ldr r0, =USIC0_CH0_SCTR
  ldr r1, =(7 << 24) | (7 << 16) | (1 << 8) | (1 << 1)
  str r1, [r0]

  @ Configuration of USIC Transmit Control/Status Register
  @ TBUF.TDEN = 1 (TBUF Data Enable: A transmission of the data word in TBUF can be started if TDV = 1
  @ TBUF.TDSSM = 1 (Data Single Shot Mode: allow word-by-word data transmission which avoid sending the same data several times

  ldr r0, =USIC0_CH0_TCSR
  ldr r1, =(1 << 10) | (1 << 8)
  str r1, [r0]
  
  @ Configuration of Protocol Control Register, page 345
  @ PCR.SMD = 1 (Sample Mode based on majority)
  @ PCR.STPB = 0 (1x Stop bit)
  @ PCR.SP = 5 (Sample Point)  9 ?
  @ PCR.PL = 0 (Pulse Length is equal to the bit length)

  ldr r0, =USIC0_CH0_PCR
  ldr r1, =(9 << 8) | 1    | ( 1 << 17 ) @ Transmitter Status Enable --> Busy PSR[9]
  str r1, [r0]

  @ Select P2.2 as input for USIC DX3 -> UCIC DX0
  ldr r0, =USIC0_CH0_DX3CR
  movs r1, #0
  str r1, [r0]

  @ Route USIC DX3 input signal to USIC DX0 (DSEL=DX0G)
  ldr r0, =USIC0_CH0_DX0CR
  movs r1, #6
  str r1, [r0]

  @ Configure Receive Buffer */
  @ Standard Receive buffer event is enabled */
  @ Define start entry of Receive Data FIFO buffer DPTR = 32*/
  @ Set Receive Data Buffer Size to 32 and set data pointer to position 32*/

  ldr r0, =USIC0_CH0_RBCTR
  ldr r1, =(5 << 24) | 32
  str r1, [r0]

  @ Configure Transmit Buffer
  @ Standard transmit buffer event is enabled 
  @ Define start entry of Transmit Data FIFO buffer DPTR = 0
  @ Set Transmit Data Buffer Size to 32 and set data pointer to position 0

  ldr r0, =USIC0_CH0_TBCTR
  ldr r1, =(5 << 24) | 0
  str r1, [r0]

  @ Initialize UART_TX (DOUT), P2.1 as output controlled by ALT6 = U0C0.DOUT0
  @ Initialize UART_RX (DX0),  P2.2 as input
 
  ldr r0, =P2_IOCR0
  ldr r1, =0xB000 @ %00000 Direct input. %10000 000 Direct output, push-pull. %10110 000 Direct output, push-pull, AF6. One Byte for every pin.
  str r1, [r0]

  @ Configuration of Channel Control Register
  @ CCR.PM = 00 ( Disable parity generation)
  @ CCR.MODE = 2 (ASC mode enabled. Note: 0 (USIC channel is disabled))

  ldr r0, =USIC0_CH0_CCR
  movs r1, #2
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
   
   ldr r0, =USIC0_CH0_IN   
   strb tos, [r0] @ Store character into FIFO
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
   ldr tos, =USIC0_CH0_OUTR
   ldrb tos, [tos] @ Read character and clear it from FIFO
  
   @ ldr r0, =P1_OUT @ Show the two lowest bits of the character on the LEDs
   @ str tos, [r0]   @ Just for debugging.
   
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0

 @  ldr r0, =USIC0_CH0_TRBSR @ Transmit/Receive Buffer Status Register
 @  ldr r2, =(1 << 12) @ Transmit buffer full

   ldr r0, =USIC0_CH0_PSR @ BUSY Flag, configured to reflect transmitter state
   ldr r2, =(1<<9)

   ldr r1, [r0]
   ands r1, r2
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

   ldr r0, =USIC0_CH0_TRBSR @ Transmit/Receive Buffer Status Register
   movs r2, #(1 << 3) @ Receive buffer empty

   ldr r1, [r0]
   ands r1, r2
   bne 1f
     mvns tos, tos
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
