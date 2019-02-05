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

.equ WDT0_LOAD      , 0x40002C00   @ 0x00001000  WDT0 Load Value
.equ WDT0_CCNT      , 0x40002C04   @ 0x00001000  WDT0 Current Count Value
.equ WDT0_CTL       , 0x40002C08   @ 0x000000E9  WDT0 Control
.equ WDT0_RESTART   , 0x40002C0C   @ 0x00000000  WDT0 Clear Interrupt
.equ WDT0_STAT      , 0x40002C18   @ 0x00000000  WDT0 Status
                       
.equ CLKG0_CLK_CTL0 , 0x4004C300   @ 0x00000078  CLKG0_CLK Misc Clock Settings
.equ CLKG0_CLK_CTL1 , 0x4004C304   @ 0x00100404  CLKG0_CLK Clock Dividers
.equ CLKG0_CLK_CTL2 , 0x4004C308   @ 0x00000000  CLKG0_CLK HF Oscillator Divided Clock Select
.equ CLKG0_CLK_CTL3 , 0x4004C30C   @ 0x0000681A  CLKG0_CLK System PLL
.equ CLKG0_CLK_CTL5 , 0x4004C314   @ 0x0000005F  CLKG0_CLK User Clock Gating Control
.equ CLKG0_CLK_STAT0, 0x4004C318   @ 0x00000000  CLKG0_CLK Clocking Status
                       
.equ GPIO0_CFG     ,  0x40020000   @  0x00000000  GPIO0 Port Configuration
.equ GPIO0_OEN     ,  0x40020004   @  0x00000000  GPIO0 Port Output Enable
.equ GPIO0_PE      ,  0x40020008   @  0x000000C0  GPIO0 Port Output Pull-up/Pull-down Enable
.equ GPIO0_IEN     ,  0x4002000C   @  0x00000000  GPIO0 Port Input Path Enable
.equ GPIO0_IN      ,  0x40020010   @  0x00000000  GPIO0 Port Registered Data Input
.equ GPIO0_OUT     ,  0x40020014   @  0x00000000  GPIO0 Port Data Output
.equ GPIO0_SET     ,  0x40020018   @  0x00000000  GPIO0 Port Data Out Set
.equ GPIO0_CLR     ,  0x4002001C   @  0x00000000  GPIO0 Port Data Out Clear
.equ GPIO0_TGL     ,  0x40020020   @  0x00000000  GPIO0 Port Pin Toggle
.equ GPIO0_POL     ,  0x40020024   @  0x00000000  GPIO0 Port Interrupt Polarity
.equ GPIO0_IENA    ,  0x40020028   @  0x00000000  GPIO0 Port Interrupt A Enable
.equ GPIO0_IENB    ,  0x4002002C   @  0x00000000  GPIO0 Port Interrupt B Enable
.equ GPIO0_INT     ,  0x40020030   @  0x00000000  GPIO0 Port Interrupt Status
.equ GPIO0_DS      ,  0x40020034   @  0x00000000  GPIO0 Port Drive Strength Select

.equ GPIO2_CFG     ,  0x40020080   @  0x00000000  GPIO2 Port Configuration
.equ GPIO2_OEN     ,  0x40020084   @  0x00000000  GPIO2 Port Output Enable
.equ GPIO2_PE      ,  0x40020088   @  0x00000000  GPIO2 Port Output Pull-up/Pull-down Enable
.equ GPIO2_IEN     ,  0x4002008C   @  0x00000000  GPIO2 Port Input Path Enable
.equ GPIO2_IN      ,  0x40020090   @  0x00000000  GPIO2 Port Registered Data Input
.equ GPIO2_OUT     ,  0x40020094   @  0x00000000  GPIO2 Port Data Output
.equ GPIO2_SET     ,  0x40020098   @  0x00000000  GPIO2 Port Data Out Set
.equ GPIO2_CLR     ,  0x4002009C   @  0x00000000  GPIO2 Port Data Out Clear
.equ GPIO2_TGL     ,  0x400200A0   @  0x00000000  GPIO2 Port Pin Toggle
.equ GPIO2_POL     ,  0x400200A4   @  0x00000000  GPIO2 Port Interrupt Polarity
.equ GPIO2_IENA    ,  0x400200A8   @  0x00000000  GPIO2 Port Interrupt A Enable
.equ GPIO2_IENB    ,  0x400200AC   @  0x00000000  GPIO2 Port Interrupt B Enable
.equ GPIO2_INT     ,  0x400200B0   @  0x00000000  GPIO2 Port Interrupt Status
.equ GPIO2_DS      ,  0x400200B4   @  0x00000000  GPIO2 Port Drive Strength Select

.equ UART0_TX      ,  0x40005000   @  0x00000000  UART0 Transmit Holding Register
.equ UART0_RX      ,  0x40005000   @  0x00000000  UART0 Receive Buffer Register
.equ UART0_IEN     ,  0x40005004   @  0x00000000  UART0 Interrupt Enable
.equ UART0_IIR     ,  0x40005008   @  0x00000001  UART0 Interrupt ID
.equ UART0_LCR     ,  0x4000500C   @  0x00000000  UART0 Line Control
.equ UART0_MCR     ,  0x40005010   @  0x00000000  UART0 Modem Control
.equ UART0_LSR     ,  0x40005014   @  0x00000060  UART0 Line Status
.equ UART0_MSR     ,  0x40005018   @  0x00000000  UART0 Modem Status
.equ UART0_SCR     ,  0x4000501C   @  0x00000000  UART0 Scratch Buffer
.equ UART0_FCR     ,  0x40005020   @  0x00000000  UART0 FIFO Control
.equ UART0_FBR     ,  0x40005024   @  0x00000000  UART0 Fractional Baud Rate
.equ UART0_DIV     ,  0x40005028   @  0x00000000  UART0 Baud Rate Divider
.equ UART0_LCR2    ,  0x4000502C   @  0x00000002  UART0 Second Line Control
.equ UART0_CTL     ,  0x40005030   @  0x00000100  UART0 UART Control Register
.equ UART0_RFC     ,  0x40005034   @  0x00000000  UART0 RX FIFO Byte Count
.equ UART0_TFC     ,  0x40005038   @  0x00000000  UART0 TX FIFO Byte Count
.equ UART0_RSC     ,  0x4000503C   @  0x00000000  UART0 RS485 Half-duplex Control
.equ UART0_ACR     ,  0x40005040   @  0x00000000  UART0 Auto Baud Control
.equ UART0_ASRL    ,  0x40005044   @  0x00000000  UART0 Auto Baud Status (Low)
.equ UART0_ASRH    ,  0x40005048   @  0x00000000  UART0 Auto Baud Status (High)

@ -----------------------------------------------------------------------------
uart_init: @ ( -- ) A few bits are different to STM32F051
@ -----------------------------------------------------------------------------

  @ Stop Watchdog
  ldr  r1, =WDT0_CTL
  movs r0, #0
  str  r0, [r1]
  
@  @ Enable all clocks by removing all clock disable bits
@  ldr  r1, =CLKG0_CLK_CTL5
@  movs r0, #0
@  str  r0, [r1]

  @ Set clock dividers for HCLK and PCLK to one for 26 MHz. Keep ACLK divider on default value.
  ldr  r1, =CLKG0_CLK_CTL1
  ldr  r0, =0x00100101
  str  r0, [r1]

@    @ LED1 an P2.2 einschalten; Kathoden sind am Microcontroller
@  
@    ldr  r1, =GPIO2_CFG
@    movs r0, #0
@    str  r0, [r1]
@  
@    ldr  r1, =GPIO2_OEN
@    movs r0, #4
@    str  r0, [r1]
@  
@    movs r3, #7
@  Blinky:
@  
@    ldr  r1, =GPIO2_TGL
@    movs r0, #4
@    str  r0, [r1]
@  
@    ldr  r2, =0x80000
@  1:subs r2, #1
@    bne 1b
@  
@    subs r3, #1
@    bne.n Blinky
@  
@    @ Am Ende ist die LED aus, weil sie mit der Kathode angeschlossen ist.

@ Page 103: Pin multiplexing.
@ UART0_TX_N / GPIO 10 / Pin 58 / UART0_TXD  --  P0_10 Multiplexed Function 1:   /UART0_TX
@ UART0_RX_N / GPIO 11 / Pin 57 / UART0_RXD  --  P0_11 Multiplexed Function 1:   /UART0_RX

  ldr  r1, =GPIO0_CFG
  ldr  r0, =1<<(2*11) | 1<<(2*10)
  str  r0, [r1]

  ldr  r1, =UART0_LCR
  movs r0, #3 @ 8 bit word length
  strh r0, [r1]

  ldr  r1, =UART0_LCR2
  movs r0, #3 @ Oversampling rate
  strh r0, [r1]

  ldr  r1, =UART0_DIV
  movs r0, #3
  strh r0, [r1]

  ldr  r1, =UART0_FBR
  ldr  r0, =1<<15 | 2<<11 | 719
  strh r0, [r1]

  ldr r1, =UART0_FCR
  movs r0, 7 @ TFCLR|RFCLR|FIFOEN
  strh r0, [r1]

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

   ldr r2, =UART0_TX
   strh tos, [r2]         @ Output the character
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
   ldr r2, =UART0_RX
   ldrh tos, [r2]         @ Fetch the character

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0  @ False Flag
   ldr r0, =UART0_LSR
   ldrh r1, [r0]     @ Fetch line status
   movs r0, #32     @ Transmit Register Empty Bit
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
   ldr r0, =UART0_LSR
   ldrh r1, [r0]     @ Fetch line status
   movs r0, #1      @ Data Ready Bit
   ands r1, r0
   beq 1f
     mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
