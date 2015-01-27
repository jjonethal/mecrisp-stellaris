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

        @ GPIO register map is similiar to STM32F4 chips.
		
		.equ    NRF_POWER_RAMON_ADDRESS,            0x40000524
		.equ    NRF_POWER_RAMON_RAMxON_ONMODE_Msk,  0x3  

		.equ NRF_CLOCK,						0x40000000 		
		.equ NRF_CLOCK_EVENTS_HFCLKSTARTED, NRF_CLOCK + 0x100
		.equ NRF_CLOCK_TASKS_HFCLKSTART,	NRF_CLOCK + 0x000
		
		.equ NRF_GPIO,						0x50000000
		.equ NRF_GPIO_PIN_CNF,				NRF_GPIO + 0x700
		.equ NRF_GPIO_OUTSET,				NRF_GPIO + 0x508

		.equ UART,							0x40002000
		.equ UART_TASK_STARTRX,				UART + 0x000
		.equ UART_TASK_STARTTX,				UART + 0x008
		.equ UART_EVENT_RXDRDY,				UART + 0x108
		.equ UART_EVENT_TXDRDY,				UART + 0x11C
		.equ UART_ENABLE,					UART + 0x500
		.equ UART_PSELTXD,					UART + 0x50C
		.equ UART_PSELRXD,					UART + 0x514
		.equ UART_RXD,						UART + 0x518
		.equ UART_TXD,						UART + 0x51C
		.equ UART_BAUDRATE,					UART + 0x524
		.equ UART_CONFIG,					UART + 0x56C
		
		.equ BAUD115200,					0x01D7E000
		.equ RX_PIN_NUMBER,					16
		.equ TX_PIN_NUMBER,					17
				
        @ Flags for USART1_ISR register:
          .equ RXNE            ,   BIT5
          .equ TC              ,   BIT6
          .equ TXE             ,   BIT7


@ fix for PAN_026

Manual_Peripheral_Setup:
	ldr r0, =0x40000504
	ldr r1, =0xC007FFDF
	str r1, [r0]
	ldr r0, =0x40006C18
	ldr r1, =0x00008000
	str r1, [r0]
	bx lr

Check_Device:
	ldr r0,=0xF0000FE0
	ldr r0, [r0]
	ldr r1, =0x000000FF
	ands r0, r1
	cmp r0, #1
	bne 3f
	ldr r0,=0xF0000FE4
	ldr r0, [r0]
	ldr r1, =0x0000000F
	ands r0, r1
	bne 3f

	ldr r0,=0xF0000FEC
	ldr r0, [r0]
	ldr r1, =0x000000F0
	ands r0, r1
	bne 3f
	ldr r0,=0xF0000FE8
	ldr r0, [r0]
	ldr r1, =0x000000F0
	ands r0, r1
	bne 1f
	b Manual_Peripheral_Setup
1:
	ldr r0,=0xF0000FE8
	ldr r0, [r0]
	ldr r1, =0x000000F0
	ands r0, r1
	cmp r0, #0x10
	bne 2f
	b Manual_Peripheral_Setup
2:
	ldr r0,=0xF0000FE8
	ldr r0, [r0]
	ldr r1, =0x000000F0
	ands r0, r1
	cmp r0, #0x30
	bne 3f
	b Manual_Peripheral_Setup
3:  bx lr
	
@ -----------------------------------------------------------------------------
uart_init:
@ -----------------------------------------------------------------------------

    push {lr}

	bl Check_Device

/* Make sure ALL RAM banks are powered on */
    LDR     R0, =NRF_POWER_RAMON_ADDRESS
    LDR     R2, [R0]
    MOVS    R1, #NRF_POWER_RAMON_RAMxON_ONMODE_Msk
    ORRS    R2, R1
    STR     R2, [R0]

	@ Turn on the HF clock
 
  ldr r1, = NRF_CLOCK_EVENTS_HFCLKSTARTED
  movs r0, #0
  str r0, [r1]
  ldr r1, = NRF_CLOCK_TASKS_HFCLKSTART
  movs r0, #1
  str r0, [r1]
  ldr r1, = NRF_CLOCK_EVENTS_HFCLKSTARTED
1:    ldr r3, [r1]
      movs r0, #1
      ands r0, r3
      beq 1b

  @ nrf_gpio_cfg_output(txd_pin_number);
  
  ldr r1, =NRF_GPIO_OUTSET
  ldr r0, =(1<<TX_PIN_NUMBER)
  str r0, [r1]
  ldr r1, =NRF_GPIO_PIN_CNF+4*TX_PIN_NUMBER
  movs r0, #1
  str r0, [r1]
  
  @ nrf_gpio_cfg_input(rxd_pin_number, NRF_GPIO_PIN_PULLUP);  

  ldr r1, =NRF_GPIO_PIN_CNF+4*RX_PIN_NUMBER
  movs r0, #0xC
  str r0, [r1]
  
  @NRF_UART0->PSELTXD = txd_pin_number;

  ldr r1, =UART_PSELTXD
  movs r0, #TX_PIN_NUMBER
  str r0, [r1]
  
  @NRF_UART0->PSELRXD = rxd_pin_number;

  ldr r1, =UART_PSELRXD
  movs r0, #RX_PIN_NUMBER
  str r0, [r1]
  
  @NRF_UART0->BAUDRATE         = (UART_BAUDRATE_BAUDRATE_Baud38400 << UART_BAUDRATE_BAUDRATE_Pos);

  ldr r1, =UART_BAUDRATE
  ldr r0, =BAUD115200
  str r0, [r1]
  
  @NRF_UART0->ENABLE           = (UART_ENABLE_ENABLE_Enabled << UART_ENABLE_ENABLE_Pos);

  ldr r1, =UART_ENABLE
  movs r0, #4
  str r0, [r1]
  
  @NRF_UART0->TASKS_STARTTX    = 1;

  ldr r1, =UART_TASK_STARTTX
  movs r0, #1
  str r0, [r1]
  
  @NRF_UART0->TASKS_STARTRX    = 1;

  ldr r1, =UART_TASK_STARTRX
  movs r0, #1
  str r0, [r1]
  
  @NRF_UART0->EVENTS_RXDRDY    = 0;

  ldr r1, =UART_EVENT_RXDRDY
  movs r0, #0
  str r0, [r1]

  ldr r1, =UART_TXD
  movs r0, #20
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
