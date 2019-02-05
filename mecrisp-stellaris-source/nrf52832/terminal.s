@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@    Copyright (C) 2018  juju2013@github
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

  @--- GPIO related registers
  .equ NRF_GPIO               ,	0x50000000
  .equ NRF_GPIO_PIN_CNF       ,	NRF_GPIO + 0x700
  .equ NRF_GPIO_OUTSET        ,	NRF_GPIO + 0x508

  @--- UART related registers
  .equ UART                   , 0x40002000
  .equ UART_TASK_STARTRX      ,	UART + 0x000
  .equ UART_TASK_STOPRX       ,	UART + 0x004
  .equ UART_TASK_STARTTX      ,	UART + 0x008
  .equ UART_TASK_STOPTX       ,	UART + 0x008
  .equ UART_EVENT_RXDRDY      ,	UART + 0x108
  .equ UART_EVENT_TXDRDY      ,	UART + 0x11C
  .equ UART_ENABLE            ,	UART + 0x500
  .equ UART_PSELTXD           ,	UART + 0x50C
  .equ UART_PSELRXD           ,	UART + 0x514
  .equ UART_RXD               ,	UART + 0x518
  .equ UART_TXD               ,	UART + 0x51C
  .equ UART_BAUDRATE          ,	UART + 0x524
  .equ UART_CONFIG            ,	UART + 0x56C

  @--- constants
  .equ BAUD115200             ,	0x01D7E000
  .equ RX_PIN_NUMBER          ,	3
  .equ TX_PIN_NUMBER          ,	2


@ -----------------------------------------------------------------------------
uart_init:
@ -----------------------------------------------------------------------------

    push {lr}


  @ nrf_gpio_cfg_output(txd_pin_number);

  @----------------------- setup UART IO PIN ---------------------------
  ldr   r1, =UART_ENABLE
  movs  r0, #0
  str   r0, [r1]                    @ disable UART before configuration
  
  @--- TX PIN
  ldr   r1, =NRF_GPIO_OUTSET
  ldr   r0, =(1<<TX_PIN_NUMBER)
  str   r0, [r1]
  ldr   r1, =NRF_GPIO_PIN_CNF+4*TX_PIN_NUMBER
  movs  r0, #1
  str   r0, [r1]                    @ as output

  ldr   r1, =UART_PSELTXD
  movs  r0, #TX_PIN_NUMBER
  str   r0, [r1]                    @ set TX PIN
  

  @--- TX PIN
  ldr   r1, =NRF_GPIO_PIN_CNF+4*RX_PIN_NUMBER
  movs  r0, #0xC                    @ PULL UP
  str   r0, [r1]

  ldr   r1, =UART_PSELRXD
  movs  r0, #RX_PIN_NUMBER
  str   r0, [r1]                    @ set RX PIN

  @--- BAUD rate  
  ldr r1, =UART_BAUDRATE
  ldr r0, =BAUD115200
  str r0, [r1]
  
  @--- Enable UART
  ldr   r1, =UART_ENABLE
  movs  r0, #4
  str   r0, [r1]

  @--- start TX and RX tasks  
  movs  r0, #1
  ldr   r1, =UART_TASK_STARTTX
  str   r0, [r1]
    ldr   r1, =UART_TASK_STARTRX
  str   r0, [r1]

  @--- clear RX flag
  movs  r0, #0
  ldr   r1, =UART_EVENT_RXDRDY
  str   r0, [r1]  
  @NRF_UART0->EVENTS_RXDRDY    = 0;

  @--- DEBUG
  ldr   r1, =UART_TXD
  
  movs  r0, #68               @ D
  str r0, [r1]
  movs  r0, #69               @ E
  str r0, [r1]
  movs  r0, #66               @ B
  str r0, [r1]
  movs  r0, #85               @ U
  str r0, [r1]
  movs  r0, #71               @ G
  str r0, [r1]

   pop {pc}

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

@ Clear event flag first

   ldr r2, =UART_EVENT_TXDRDY
   movs r0, #0
   str r0, [r2]
   
   ldr r2, =UART_TXD
   strb tos, [r2]         @ Output the character
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

@ Clear event flag first

   ldr r2, =UART_EVENT_RXDRDY
   movs r0, #0
   str r0, [r2]

   pushdatos
   ldr r2, =UART_RXD
   ldrb tos, [r2]         @ Fetch the character

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0  @ False Flag
   ldr r2, =UART_EVENT_TXDRDY
   ldr r1, [r2]     @ Fetch status
   movs r0, #1
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
   ldr r2, =UART_EVENT_RXDRDY
   ldr r1, [r2]     @ Fetch status
   movs r0, #1
   ands r1, r0
   beq 1f
   mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
