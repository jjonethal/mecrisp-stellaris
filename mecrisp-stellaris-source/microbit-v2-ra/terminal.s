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

  /* nRF52833 UARTE - Universal asynchronous receiver/transmitter with EasyDMA
  * - GPIOs for each UART interface can be chosen from any GPIO on the device and are
  *   independently configurable. On the Microbit, the UART_INT_RX is connected to P0.06
  *   and UART_INT_TX is connected to P1.08
  * - TXD.PTR and RXD.PTR must point to the Data RAM region, otherwise a HardFault or RAM corruption
  * will occur.
  * - .PTR and .MAXCNT are double buffered. They can be updated immediately after receiving the
  *   RXSTARTED/TXSTARTED event
  * - ENDRX/ENDTX - indicate the EasyDMA is finished accessing the RX or TX buffer in RAM
  *
  * Transmission
  * ------------
  * Store the butes in the transmit buffer, and configure EasyDMA
  * - Write the initial address pointer to TXD.PTR, and the number of bytes in the RAM buffer to
  *   TXD.MAXCNT. The UARTE transmission is triggered by the STARTTX task
  * - After each byte has been sent, a TXDRDY event will be generated
  * - When all bytes 
  * Reception
  * ---------
  * 
  */


  @@------------------------------------------------------------------------------------------
  @@ NVMC - Non volatile memory controller
  @@------------------------------------------------------------------------------------------
  .equ NVMC                              , 0x4001E000      @ Non-volatile memory controller address

  .equ NVMC_READY                        , NVMC + 0x400    @ Ready flag
  .equ NVMC_CONFIG                       , NVMC + 0x504    @ Configuration register
  .equ NVMC_ICACHECNF                    , NVME + 0x548    @ I-code cache configuration register
  .equ NVMC_ICACHECNF_CACHEEN            , 0x0             @ Bit offset for CACHEEN
  .equ NVMC_ICACHECNF_CACHEEN_Disabled   , 0b0 << NVMC_ICACHECNF_CACHEEN
  .equ NVMC_ICACHECNF_CACHEEN_Enabled    , 0b1 << NVMC_ICACHECNF_CACHEEN

  @ Access modes for flash memory
  .equ NVMC_CONFIG_Ren                   , 0               @ Read only
  .equ NVMC_CONFIG_Wen                   , 1               @ Write Enabled
  .equ NVMC_CONFIG_Een                   , 2               @ Erase Enabled
   
  @@------------------------------------------------------------------------------------------ 
  @@ UART
  @@------------------------------------------------------------------------------------------   
  .equ UART                        , 0x40002000      @ Address of UART

  .equ UART_TASKS_STARTRX          , UART + 0x000    @ Start UART Receiver
  .equ UART_TASKS_STARTTX          , UART + 0x008    @ Start UART Transmitter
  .equ UART_EVENT_RXDRDY           , UART + 0x108    @ Data received in RXD
  .equ UART_EVENT_TXDRDY           , UART + 0x11C    @ Data sent from TXD
  .equ UART_INTENSET               , UART + 0x304    @ Enable Interrupt
  .equ UART_INTENCLR               , UART + 0x308    @ Disable Interrupt
  .equ UART_ENABLE                 , UART + 0x500    @ Enable UART with value of 0x4
  .equ UART_PSEL.TXD               , UART + 0x50C    @ Pin select for TXD
  .equ UART_PSEL.RXD               , UART + 0x514    @ Pin select for RXD
  .equ UART_RXD                    , UART + 0x518    @ RXD Register. 
  /* Register is cleared on read and the double buffered byte will be moved to RXD if it exists */
  .equ UART_TXD                    , UART + 0x51C    @ TXD Register
  .equ UART_BAUDRATE               , UART + 0x524    @ Baud rate. Accuracy depends on HFCLK source selected
  .equ UART_CONFIG                 , UART + 0x56C    @ Configuration of parity and hardware flow control

  .equ BAUD115200                  , 0x01D7E000      @ Mike Spivey - 0x01D60000??
  .equ BAUD9600                    , 0x00275000
  .equ UART_ENABLE_Enabled         , 0x4             @ Enable UART
  .equ UART_ENABLE_Disabled        , 0               @ Disable UART
  .equ UART_TASKS_STARTTX_Trigger  , 1               @ Trigger the STARTTX task
  .equ UART_TASKS_STARTRX_Trigger  , 1               @ Trigger the STARTRX task

  .equ UART_CONFIG_HWFC            , 0               @ Bit offset for HWFC
  .equ UART_CONFIG_PARITY          , 1               @ Bit offset for Parity
  .equ UART_CONFIG_STOP            , 4               @ Bit offset for STOP bit setting
  .equ UART_CONFIG_PARITYTYPE      , 8               @ Bit offset for PARITYTYPE

  @ Settings for the UART config register
  .equ UART_CONFIG_HWFC_Disabled   , 0   << UART_CONFIG_HWFC
  .equ UART_CONFIG_HWFC_Enabled    , 1   << UART_CONFIG_HWFC
  .equ UART_CONFIG_PARITY_Excluded , 0x0 << UART_CONFIG_PARITY
  .equ UART_CONFIG_PARITY_Included , 0x7 << UART_CONFIG_PARITY
  .equ UART_CONFIG_STOP_One        , 0   << UART_CONFIG_STOP
  .equ UART_CONFIG_STOP_Two        , 1   << UART_CONFIG_STOP
  .equ UART_CONFIG_PARITYTYPE_Even , 0   << UART_CONFIG_PARITYTYPE
  .equ UART_CONFIG_PARITYTYPE_Odd  , 1   << UART_CONFIG_PARITYTYPE

  @ Interrupts
  .equ UART_INT_RXDRDY             , 2               @ Bit offset
  .equ UART_INT_TXDRDY             , 7               @ Bit offset

  @--------------------------------------------------------------------------------------
  @ UICR - User information Configuration Registers
  @--------------------------------------------------------------------------------------

  .equ UICR                        , 0x10001000

  .equ UICR_NRFFW                  , UICR + 0x014
  .equ UICR_NRFHW                  , UICR + 0x050
  .equ UICR_CUSTOMER               , UICR + 0x080
  .equ UICR_PSELRESET              , UICR + 0x200
  .equ UICR_APPROTECT              , UICR + 0x208
  .equ UICR_NFCPINS                , UICR + 0x210
  .equ UICR_DEBUGCTRL              , UICR + 0x210
  .equ UICR_REGOUT0                , UICR + 0x304
   
   
  @--------------------------------------------------------------------------------------
  @ Pin configurations for Micro:Bit v2.21. Note: v1.x have a different configuration
  @--------------------------------------------------------------------------------------
  .equ RX_PORT_NUM                 , 0x1             @ Port 1, 
  .equ RX_PIN_NUM                  , 0x8             @......., GPIO 8
  .equ TX_PORT_NUM                 , 0x0             @ Port 0,
  .equ TX_PIN_NUM                  , 0x6             @......., GPIO 6
  .equ P1_PORT_INDEX               , 1 << 5          @ Set bit 5 for Port 1

  @======================================================================================
  @ nRF clock setup - Page 156
  .equ CLOCK                       , 0x40000000      @ Clock control
  .equ CLOCK_TASKS_HFCLKSTART      , CLOCK + 0x000   @ Start HFXO crystal oscillator
  .equ CLOCK_EVENTS_HFCLKSTARTED   , CLOCK + 0x100   @ HXFO crustal oscillator started

  @======================================================================================
  @ GPIO Setup
  .equ GPIO_P0                     , 0x50000000           @ GPIO, Port 0
  .equ P1_OFFSET                   , 0x300                @ Port offset
  .equ GPIO_P1                     , GPIO_P0 + P1_OFFSET  @ GPIO, Port 1

  .equ PIN_DIR                     , 0x514
  .equ PIN_CNF                     , 0x700           @ Base address of GPIO Pin configuration array

  @ Pin function
  .equ PIN_CNF_DIR_Input           , 0x0             @ Configure pin as input
  .equ PIN_CNF_DIR_Output          , 0x1             @ Configure pin as output
  @ Pin Pull up
  .equ PIN_CNF_Pull_Disabled       , 0b00 << 2
  .equ PIN_CNF_Pulldown            , 0b01 << 2
  .equ PIN_CNF_Pullup              , 0b11 << 2

  .equ OUT                         , 0x504
  .equ OUTSET                      , 0x508           @ Set individual bits in GPIO port:

  @ Shared resources - These must be disabled to ensure correct UART operation
  .equ UARTE0                      , 0x40002000      @ Address of UARTE0
  .equ UARTE0_ENABLE               , UARTE0 + 0x500  @ Clear to disable UARTE0
  .equ UARTE0_ENABLE_Enabled       , 0x8             @ Enable UARTE0 value
  .equ UARTE0_ENABLE_Disabled      , 0
   
@-----------------------------------------------------------------------------------------
uart_init:        @ Configure the UART device
@-----------------------------------------------------------------------------------------

  @ Save return address 
  push {lr}
   
  @--------------------------------------------------------------------------------------
  @ Disable other peripherals which use the shared registers
  ldr r1, =UARTE0_ENABLE
  mov r0, #UARTE0_ENABLE_Disabled
  str r0, [r1]   @ Clear UARTE0_ENABLE
  
  @--------------------------------------------------------------------------------------
  @ Set up the HFCLOCK. If it isn't specifically setup, it will enter a power save mode.
  ldr r1, =CLOCK_EVENTS_HFCLKSTARTED
  mov r0, #0
  str r0, [r1]   @ Clear the event started flag
  ldr r1, =CLOCK_TASKS_HFCLKSTART
  mov r0, #1
  str r0, [r1]   @ Start the clock
  ldr r1, =CLOCK_EVENTS_HFCLKSTARTED
1:
  ldr r3, [r1]   @...get the clock event status
  cmp r3, #1     @...once started, the event status is equal to 1
  bne 1b
   
  @--------------------------------------------------------------------------------------
  @ Configure the pins
  @...Set up the GPIO pins
  @....TX pin
  @.....Set pin driver high 
  ldr r1, =(TX_PORT_NUM * P1_OFFSET) + GPIO_P0 + OUTSET
  ldr r2, [r1]                     @ Get the current OUTSET status
  ldr r0, =(1 << TX_PIN_NUM)       @ Set mask for current pin
  orr r2, r2, r0                   @ Turn TX_PIN setting to high
  str r2, [r1]                     @ Save back to register
   
  @.....Configure as output
  ldr r1, =(TX_PORT_NUM * P1_OFFSET) + GPIO_P0 + PIN_CNF + (4 * TX_PIN_NUM)
  mov r0, #PIN_CNF_DIR_Output
  str r0, [r1]

  @....RX Pin
  @.....Configure as input with pullup

  ldr r1, =(RX_PORT_NUM * P1_OFFSET) + GPIO_P0 + PIN_CNF + (4 * RX_PIN_NUM)
  mov r0, # (PIN_CNF_DIR_Input | PIN_CNF_Pullup)
  str r0, [r1]
   
  @--------------------------------------------------------------------------------------
  @ Configure UART
  @...Assign the pins to the UART
  @....TX pin
1:
  ldr r1, =UART_PSEL.TXD
  mov r0, # (TX_PORT_NUM * P1_PORT_INDEX) + TX_PIN_NUM
  str r0, [r1]

  @....RX pin
  ldr r1, =UART_PSEL.RXD
  mov r0, # (RX_PORT_NUM * P1_PORT_INDEX) + RX_PIN_NUM
  str r0, [r1]

  @...Set the Baudrate
  ldr r1, =UART_BAUDRATE
  ldr r0, =BAUD115200
  str r0, [r1]            @ Set the baud rate to 115200

  @...Set the communication parameters
  ldr r1, =UART_CONFIG
  mov r0, #( UART_CONFIG_HWFC_Disabled | UART_CONFIG_PARITY_Excluded | UART_CONFIG_STOP_One )
  str r0, [r1]

  @ Settings complete - enable the UART
  ldr r1, =UART_ENABLE
  mov r0, #UART_ENABLE_Enabled
  str r0, [r1]

  @ Clear the TXDRDY event flag
  ldr r1, =UART_EVENT_TXDRDY
  mov r0, #0
  str r0, [r1]
   
  @ Start the transmission and receiving tasks
  ldr r1, =UART_TASKS_STARTTX
  mov r0, #UART_TASKS_STARTTX_Trigger
  str r0, [r1]

  ldr r1, =UART_TASKS_STARTRX
  mov r0, #UART_TASKS_STARTRX_Trigger
  str r0, [r1]

  @@ Clear the RXDRDY event
  ldr r1, =UART_EVENT_RXDRDY
  mov r0, #0
  str r0, [r1]

  ldr r1, =UART_TXD
  mov r0, #20  @ Space character?
  str r0,[r1]
   
  pop {pc}
   
.include "../common/terminalhooks.s"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
  push {lr}

1:
  bl serial_qemit
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
1:
  pop {pc}

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
1:
  pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
