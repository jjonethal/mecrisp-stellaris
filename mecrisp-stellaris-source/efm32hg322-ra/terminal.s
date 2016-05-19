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
.equ GPIO_PA_Base, 0x40006000
.equ GPIO_PF_Base, 0x400060B4

.equ      GPIO_PA_CTRL      , GPIO_PA_Base + 0x00  @ RW  Port Control Register
.equ      GPIO_PA_MODEL     , GPIO_PA_Base + 0x04  @ RW  Port Pin Mode Low Register
.equ      GPIO_PA_MODEH     , GPIO_PA_Base + 0x08  @ RW  Port Pin Mode High Register
.equ      GPIO_PA_DOUT      , GPIO_PA_Base + 0x0C  @ RW  Port Data Out Register
.equ      GPIO_PA_DOUTSET   , GPIO_PA_Base + 0x10  @ W1  Port Data Out Set Register
.equ      GPIO_PA_DOUTCLR   , GPIO_PA_Base + 0x14  @ W1  Port Data Out Clear Register
.equ      GPIO_PA_DOUTTGL   , GPIO_PA_Base + 0x18  @ W1  Port Data Out Toggle Register
.equ      GPIO_PA_DIN       , GPIO_PA_Base + 0x1C  @ R   Port Data In Register
.equ      GPIO_PA_PINLOCKN  , GPIO_PA_Base + 0x20  @ RW  Port Unlocked Pins Register

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


@ PA0:  USART RX, US1_RX
@ PF2:  USART TX, US1_TX
@ PA9:  Terminal enable, set high for communication

@ PC9:  Button 0
@ PC10: Button 1

@ PF4:  LED 0
@ PF5:  LED 1

@ PF0:  SWDIO
@ PF1:  SWCLK

@ .equ USART0_Base, 0x4000C000
.equ USART1_Base, 0x4000C400

.equ USART1_CTRL       , USART1_Base + 0x00    @ Control Register
.equ USART1_FRAME      , USART1_Base + 0x04    @ USART Frame Format Register
.equ USART1_TRIGCTRL   , USART1_Base + 0x08    @ USART Trigger Control register
.equ USART1_CMD        , USART1_Base + 0x0C    @ Command Register
.equ USART1_STATUS     , USART1_Base + 0x10    @ USART Status Register
.equ USART1_CLKDIV     , USART1_Base + 0x14    @ Clock Control Register
.equ USART1_RXDATAX    , USART1_Base + 0x18    @ RX Buffer Data Extended Register
.equ USART1_RXDATA     , USART1_Base + 0x1C    @ RX Buffer Data Register
.equ USART1_RXDOUBLEX  , USART1_Base + 0x20    @ RX Buffer Double Data Extended Register
.equ USART1_RXDOUBLE   , USART1_Base + 0x24    @ RX FIFO Double Data Register
.equ USART1_RXDATAXP   , USART1_Base + 0x28    @ RX Buffer Data Extended Peek Register
.equ USART1_RXDOUBLEXP , USART1_Base + 0x2C    @ RX Buffer Double Data Extended Peek Register
.equ USART1_TXDATAX    , USART1_Base + 0x30    @ TX Buffer Data Extended Register
.equ USART1_TXDATA     , USART1_Base + 0x34    @ TX Buffer Data Register
.equ USART1_TXDOUBLEX  , USART1_Base + 0x38    @ TX Buffer Double Data Extended Register
.equ USART1_TXDOUBLE   , USART1_Base + 0x3C    @ TX Buffer Double Data Register
.equ USART1_IF         , USART1_Base + 0x40    @ Interrupt Flag Register
.equ USART1_IFS        , USART1_Base + 0x44    @ Interrupt Flag Set Register
.equ USART1_IFC        , USART1_Base + 0x48    @ Interrupt Flag Clear Register
.equ USART1_IEN        , USART1_Base + 0x4C    @ Interrupt Enable Register
.equ USART1_IRCTRL     , USART1_Base + 0x50    @ IrDA Control Register
.equ USART1_ROUTE      , USART1_Base + 0x54    @ I/O Routing Register
.equ USART1_INPUT      , USART1_Base + 0x58    @ USART Input Register
.equ USART1_I2SCTRL    , USART1_Base + 0x5C    @ I2S Control Register


@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  ldr  r1, =BIT8 | BIT4 @ Enable clock for GPIO and USART1
  ldr  r0, =CMU_HFPERCLKEN0
  str  r1, [r0]

  @ ldr  r1, =0x440400 @ LEDs of PF4 and PF5 should be Push-Pull-Outputs
  ldr  r1, =0x400 @  Terminal lines: Push-Pull (TX) on PF2...
  ldr  r0, =GPIO_PF_MODEL
  str  r1, [r0]

  @ movs r1, #BIT5|BIT4 @ LED pins should be set high
  @ ldr  r0, =GPIO_PF_DOUT
  @ str  r1, [r0]

  movs r1, #0x01 @  ... and Input (RX) on PA0.
  ldr  r0, =GPIO_PA_MODEL
  str  r1, [r0]

  ldr r1, =1668           @ uart->CLKDIV = 256 * ((UART_PERCLK_FREQUENCY / (16 * UART_BAUDRATE)) - 1);
  ldr r0, =USART1_CLKDIV  @                256 * ( (14000000 / (16 * 115200)) - 1)
  str r1, [r0]

  ldr r1, =BIT11 | BIT10 @ CLEARRX, CLEARTX
  ldr r0, =USART1_CMD
  str r1, [r0]

  ldr r1, =BIT2 | BIT0 @ TXEN, RXEN
  ldr r0, =USART1_CMD
  str r1, [r0]

  ldr r1, = 4 << 8 | BIT1 | BIT0 @ Location 4, TXPEN, RXPEN
  ldr r0, =USART1_ROUTE
  str r1, [r0]

  movs r1, #0x40 @ Terminal enable line PA9 should be Push-Pull-Output
  ldr  r0, =GPIO_PA_MODEH
  str  r1, [r0]

  ldr r1, =BIT9 @ Terminal enable line high
  ldr  r0, =GPIO_PA_DOUT
  str  r1, [r0]
  
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

   ldr r0, =USART1_TXDATA
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

   ldr r0, =USART1_RXDATA
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
   ldr r0, =USART1_STATUS
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
   ldr r0, =USART1_STATUS
   ldr r1, [r0]
   movs r0, #BIT7 @ RXDATAV - RX Data Valid
   ands r1, r0
   beq 1f
     mvns tos, tos
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
