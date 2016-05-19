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

.equ CMU_Base, 0x400C8000
.equ CMU_HFPERCLKEN0, CMU_Base + 0x044

.equ GPIO_Base, 0x40006000
.equ GPIO_PE_Base, 0x40006090
.equ GPIO_PF_Base, 0x400060B4

.equ      GPIO_PE_CTRL      , GPIO_PE_Base + 0x00  @ RW  Port Control Register
.equ      GPIO_PE_MODEL     , GPIO_PE_Base + 0x04  @ RW  Port Pin Mode Low Register
.equ      GPIO_PE_MODEH     , GPIO_PE_Base + 0x08  @ RW  Port Pin Mode High Register
.equ      GPIO_PE_DOUT      , GPIO_PE_Base + 0x0C  @ RW  Port Data Out Register
.equ      GPIO_PE_DOUTSET   , GPIO_PE_Base + 0x10  @ W1  Port Data Out Set Register
.equ      GPIO_PE_DOUTCLR   , GPIO_PE_Base + 0x14  @ W1  Port Data Out Clear Register
.equ      GPIO_PE_DOUTTGL   , GPIO_PE_Base + 0x18  @ W1  Port Data Out Toggle Register
.equ      GPIO_PE_DIN       , GPIO_PE_Base + 0x1C  @ R   Port Data In Register
.equ      GPIO_PE_PINLOCKN  , GPIO_PE_Base + 0x20  @ RW  Port Unlocked Pins Register

.equ      GPIO_PF_CTRL      , GPIO_PF_Base + 0x00  @ RW  Port Control Register
.equ      GPIO_PF_MODEL     , GPIO_PF_Base + 0x04  @ RW  Port Pin Mode Low Register
.equ      GPIO_PF_MODEH     , GPIO_PF_Base + 0x08  @ RW  Port Pin Mode High Register
.equ      GPIO_PF_DOUT      , GPIO_PF_Base + 0x0C  @ RW  Port Data Out Register
.equ      GPIO_PF_DOUTSET   , GPIO_PF_Base + 0x10  @ W1  Port Data Out Set Register
.equ      GPIO_PF_DOUTCLR   , GPIO_PF_Base + 0x14  @ W1  Port Data Out Clear Register
.equ      GPIO_PF_DOUTTGL   , GPIO_PF_Base + 0x18  @ W1  Port Data Out Toggle Register
.equ      GPIO_PF_DIN       , GPIO_PF_Base + 0x1C  @ R   Port Data In Register
.equ      GPIO_PF_PINLOCKN  , GPIO_PF_Base + 0x20  @ RW  Port Unlocked Pins Register

@ 0  DISABLED                  Input disabled. Pullup if DOUT is set.
@ 1  INPUT                     Input enabled. Filter if DOUT is set
@ 2  INPUTPULL                 Input enabled. DOUT determines pull direction
@ 3  INPUTPULLFILTER           Input enabled with filter. DOUT determines pull direction
@ 4  PUSHPULL                  Push-pull output
@ 5  PUSHPULLDRIVE             Push-pull output with drive-strength set by DRIVEMODE
@ 6  WIREDOR                   Wired-or output
@ 7  WIREDORPULLDOWN           Wired-or output with pull-down
@ 8  WIREDAND                  Open-drain output
@ 9  WIREDANDFILTER            Open-drain output with filter
@ 10 WIREDANDPULLUP            Open-drain output with pullup
@ 11 WIREDANDPULLUPFILTER      Open-drain output with filter and pullup
@ 12 WIREDANDDRIVE             Open-drain output with drive-strength set by DRIVEMODE
@ 13 WIREDANDDRIVEFILTER       Open-drain output with filter and drive-strength set by DRIVEMODE
@ 14 WIREDANDDRIVEPULLUP       Open-drain output with pullup and drive-strength set by DRIVEMODE
@ 15 WIREDANDDRIVEPULLUPFILTER Open-drain output with filter, pullup and drive-strength set by DRIVEMODE


@ The kit contains a board controller that is responsible for performing various board level tasks, such
@ as handling the debugger and the Advanced Energy Monitor. An interface is provided between the
@ EFM32 and the board controller in the form of a UART connection. The connection is enabled by setting
@ the EFM_BC_EN (PF7) line high, and using the lines EFM_BC_TX (PE0) and EFM_BC_RX (PE1) for
@ communicating.

@ PB9:  Button 0
@ PB10: Button 1

@ PE0:  UART TX, UART0, Location 1
@ PE1:  UART RX, UART0, Location 1

@ PE2:  LED 0
@ PE3:  LED 1

@ PF7:  Terminal enable

.equ UART0_Base, 0x4000E000

.equ UART0_CTRL       , UART0_Base + 0x00    @ Control Register
.equ UART0_FRAME      , UART0_Base + 0x04    @ USART Frame Format Register
.equ UART0_TRIGCTRL   , UART0_Base + 0x08    @ USART Trigger Control register
.equ UART0_CMD        , UART0_Base + 0x0C    @ Command Register
.equ UART0_STATUS     , UART0_Base + 0x10    @ USART Status Register
.equ UART0_CLKDIV     , UART0_Base + 0x14    @ Clock Control Register
.equ UART0_RXDATAX    , UART0_Base + 0x18    @ RX Buffer Data Extended Register
.equ UART0_RXDATA     , UART0_Base + 0x1C    @ RX Buffer Data Register
.equ UART0_RXDOUBLEX  , UART0_Base + 0x20    @ RX Buffer Double Data Extended Register
.equ UART0_RXDOUBLE   , UART0_Base + 0x24    @ RX FIFO Double Data Register
.equ UART0_RXDATAXP   , UART0_Base + 0x28    @ RX Buffer Data Extended Peek Register
.equ UART0_RXDOUBLEXP , UART0_Base + 0x2C    @ RX Buffer Double Data Extended Peek Register
.equ UART0_TXDATAX    , UART0_Base + 0x30    @ TX Buffer Data Extended Register
.equ UART0_TXDATA     , UART0_Base + 0x34    @ TX Buffer Data Register
.equ UART0_TXDOUBLEX  , UART0_Base + 0x38    @ TX Buffer Double Data Extended Register
.equ UART0_TXDOUBLE   , UART0_Base + 0x3C    @ TX Buffer Double Data Register
.equ UART0_IF         , UART0_Base + 0x40    @ Interrupt Flag Register
.equ UART0_IFS        , UART0_Base + 0x44    @ Interrupt Flag Set Register
.equ UART0_IFC        , UART0_Base + 0x48    @ Interrupt Flag Clear Register
.equ UART0_IEN        , UART0_Base + 0x4C    @ Interrupt Enable Register
.equ UART0_IRCTRL     , UART0_Base + 0x50    @ IrDA Control Register
.equ UART0_ROUTE      , UART0_Base + 0x54    @ I/O Routing Register

@ Not in Datasheet, but in register include file:
.equ UART0_INPUT      , UART0_Base + 0x58    @ USART Input Register
.equ UART0_I2SCTRL    , UART0_Base + 0x5C    @ I2S Control Register


@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  ldr  r1, =BIT13 | BIT3 @ Enable clock for GPIO and UART0
  ldr  r0, =CMU_HFPERCLKEN0
  str  r1, [r0]

 @ ldr  r1, =0x4414 @ LEDs should be Push-Pull-Outputs, Terminal lines Push-Pull (TX) and Input (RX)
  movs r1, #0x14 @  Terminal lines Push-Pull (TX) and Input (RX)
  ldr  r0, =GPIO_PE_MODEL
  str  r1, [r0]

 @ movs r1, #0x0C @ LED pins should be set high
 @ ldr  r0, =GPIO_PE_DOUT
 @ str  r1, [r0]

  ldr r1, =1668          @ uart->CLKDIV = 256 * ((UART_PERCLK_FREQUENCY / (16 * UART_BAUDRATE)) - 1);
  ldr r0, =UART0_CLKDIV  @                256 * ( (14000000 / (16 * 115200)) - 1)
  str r1, [r0]

  ldr r1, =BIT11 | BIT10 @ CLEARRX, CLEARTX
  ldr r0, =UART0_CMD
  str r1, [r0]

  ldr r1, =BIT2 | BIT0 @ TXEN, RXEN
  ldr r0, =UART0_CMD
  str r1, [r0]

  ldr r1, =BIT8 | BIT1 | BIT0 @ Location 1, TXPEN, RXPEN
  ldr r0, =UART0_ROUTE
  str r1, [r0]

  ldr  r1, =0x40000000 @ Terminal enable line should be Push-Pull-Output
  ldr  r0, =GPIO_PF_MODEL
  str  r1, [r0]

  movs r1, #0x80 @ Terminal enable line high
  ldr  r0, =GPIO_PF_DOUT
  str  r1, [r0]

 @ movs r1, #0x08 @ Only one LED active
 @ ldr  r0, =GPIO_PE_DOUT
 @ str  r1, [r0]
  
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

   ldr r0, =UART0_TXDATA
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

   ldr r0, =UART0_RXDATA
   pushdatos
   ldr tos, [r0]

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0
   ldr r0, =UART0_STATUS
   ldr r1, [r0]
   movs r0, #BIT6 @ TXBL - TX Buffer Level
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
   ldr r0, =UART0_STATUS
   ldr r1, [r0]
   movs r0, #BIT7 @ RXDATAV - RX Data Valid
   ands r1, r0
   beq 1f
     mvns tos, tos
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
