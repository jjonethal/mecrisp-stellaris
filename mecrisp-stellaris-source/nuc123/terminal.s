@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@@    Copyright (C) 2017,2018  juju2013@github

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


/*
NUC123 TRM PDF, Page 45 System Manager Control Registers
GCR Base Address:
GCR_BA = 0x5000_0000
PDID GCR_BA+0x00 R Part Device Identification Number Register 0x1001_23XX [1]
RSTSRC GCR_BA+0x04 R/W System Reset Source Register 0x0000_00XX
IPRSTC1 GCR_BA+0x08 R/W Peripheral Reset Control Register1 0x0000_0000
IPRSTC2 GCR_BA+0x0C R/W Peripheral Reset Control Register2 0x0000_0000
BODCR GCR_BA+0x18 R/W Brown-out Detector Control Register 0x0000_008X
PORCR GCR_BA+0x24 R/W Power-on-Reset Control Register 0x0000_XXXX
GPA_MFP GCR_BA+0x30 R/W GPIOA Multiple Function and Input Type Control Register 0x0000_0000
GPB_MFP GCR_BA+0x34 R/W GPIOB Multiple Function and Input Type Control Register 0x0000_0000
GPC_MFP GCR_BA+0x38 R/W GPIOC Multiple Function and Input Type Control Register 0x0000_0000
GPD_MFP GCR_BA+0x3C R/W GPIOD Multiple Function and Input Type Control Register 0x0000_0000
GPF_MFP GCR_BA+0x44 R/W GPIOF Multiple Function and Input Type Control Register 0x0000_000X
ALT_MFP GCR_BA+0x50 R/W Alternative Multiple Function Pin Control Register 0x0000_0000
ALT_MFP1 GCR_BA+0x54 R/W Alternative Multiple Function Pin Control Register 1 0x0000_0000
GPA_IOCR GCR_BA+0xC0 R/W GPIOA I/O Control Register 0x0000_0000
GPB_IOCR GCR_BA+0xC4 R/W GPIOB I/O Control Register 0x0000_0000
GPD_IOCR GCR_BA+0xCC R/W GPIOD I/O Control Register 0x0000_0000
REGWRPROT GCR_BA+0x100 R/W Register Write-Protection Control Register 0x0000_0000
GPA_MFPH GCR_BA+0x134 R/W 
GPB_MFPL GCR_BA+0x138 R/W 
GPB_MFPH GCR_BA+0x13C R/W 
GPC_MFPL GCR_BA+0x140 R/W 
GPC_MFPH GCR_BA+0x144 R/W 
GPD_MFPL GCR_BA+0x148 R/W 
GPD_MFPH GCR_BA+0x14C R/W
GPIOA Multiple Function High Byte Control Register
(NUC123xxxAEx Only)
GPIOB Multiple Function Low Byte Control Register
(NUC123xxxAEx Only)
GPIOB Multiple Function High Byte Control Register
(NUC123xxxAEx Only)
GPIOC Multiple Function Low Byte Control Register
(NUC123xxxAEx Only)
GPIOC Multiple Function High Byte Control Register
(NUC123xxxAEx Only)
GPIOD Multiple Function Low Byte Control Register
(NUC123xxxAEx Only)
GPIOD Multiple Function High Byte Control Register
(NUC123xxxAEx Only)
PDIDNUC123
GPF_MFPL
GCR_BA+0x158 R/W
GPIOF Multiple Function Low Byte Control Register
(NUC123xxxAEx Only)
0x0000_11XX
*/

    .equ GCR_BA     ,0x50000000
    .equ PDID       ,GCR_BA+0x00
    .equ RSTSRC     ,GCR_BA+0x04
    .equ IPRSTC1    ,GCR_BA+0x08
    .equ IPRSTC2    ,GCR_BA+0x0C
    .equ BODCR      ,GCR_BA+0x18
    .equ PORCR      ,GCR_BA+0x24
    .equ GPA_MFP    ,GCR_BA+0x30 
    .equ GPB_MFP    ,GCR_BA+0x34 
    .equ GPC_MFP    ,GCR_BA+0x38 
    .equ GPD_MFP    ,GCR_BA+0x3C 
    .equ GPF_MFP    ,GCR_BA+0x44 
    .equ ALT_MFP    ,GCR_BA+0x50 
    .equ ALT_MFP1   ,GCR_BA+0x54 
    .equ GPA_IOCR   ,GCR_BA+0xC0 
    .equ GPB_IOCR   ,GCR_BA+0xC4 
    .equ GPD_IOCR   ,GCR_BA+0xCC 
    .equ REGWRPROT  ,GCR_BA+0x100
    
    @ --- GPIOx Multiple Function High Byte Control Register(NUC123xxxAEx Only)
    .equ GPA_MFPH   ,GCR_BA+0x134
    .equ GPB_MFPL   ,GCR_BA+0x138
    .equ GPB_MFPH   ,GCR_BA+0x13C
    .equ GPC_MFPL   ,GCR_BA+0x140
    .equ GPC_MFPH   ,GCR_BA+0x144
    .equ GPD_MFPL   ,GCR_BA+0x148
    .equ GPD_MFPH   ,GCR_BA+0x14C
    .equ GPF_MFPL   ,GCR_BA+0x158

    .equ NVIC_ISER  ,0xE000E100


/*
Page 355 : UARTx Register map
UART Base Address :
UARTx_BA = 0x4005_0000 + (0x10_0000 * x)
x= 0,1
UARTx_BA+0x00 R UART Receive Buffer Register Undefined
UA_THR UARTx_BA+0x00 W UART Transmit Holding Register Undefined
UA_IER UARTx_BA+0x04 R/W UART Interrupt Enable Register 0x0000_0000
UA_FCR UARTx_BA+0x08 R/W UART FIFO Control Register 0x0000_0101
UA_LCR UARTx_BA+0x0C R/W UART Line Control Register 0x0000_0000
UA_MCR UARTx_BA+0x10 R/W UART Modem Control Register 0x0000_0200
UA_MSR UARTx_BA+0x14 R/W UART Modem Status Register 0x0000_0110
UA_FSR UARTx_BA+0x18 R/W UART FIFO Status Register 0x1040_4000
UA_ISR UARTx_BA+0x1C R/W UART Interrupt Status Register 0x0000_0002
UA_TOR UARTx_BA+0x20 R/W UART Time-out Register 0x0000_0000
UA_BAUD UARTx_BA+0x24 R/W UART Baud Rate Divider Register 0x0F00_0000
UA_IRCR UARTx_BA+0x28 R/W UART IrDA Control Register 0x0000_0040
UA_ALT_CSR UARTx_BA+0x2C R/W UART Alternate Control/Status Register 0x0000_0000
UA_FUN_SEL UARTx_BA+0x30 R/W UART Function Select Register 0x0000_0000
*/

    .equ UART0_BA   ,0x40050000 + (0x100000 * 0)
    .equ UA_RBR     ,UART0_BA+0x00
    .equ UA_THR     ,UART0_BA+0x00
    .equ UA_IER     ,UART0_BA+0x04
    .equ UA_FCR     ,UART0_BA+0x08
    .equ UA_LCR     ,UART0_BA+0x0C
    .equ UA_MCR     ,UART0_BA+0x10
    .equ UA_MSR     ,UART0_BA+0x14
    .equ UA_FSR     ,UART0_BA+0x18
    .equ UA_ISR     ,UART0_BA+0x1C
    .equ UA_TOR     ,UART0_BA+0x20
    .equ UA_BAUD    ,UART0_BA+0x24
    .equ UA_IRCR    ,UART0_BA+0x28
    .equ UA_ALT_CSR ,UART0_BA+0x2C
    .equ UA_FUN_SEL ,UART0_BA+0x30
    
    .equ UART0_INT  ,0x00000100


@ -----------------------------------------------------------------------------
uart_init:
@ -----------------------------------------------------------------------------


@ NUC123 TRM PDF page 343, basic configuration

    @--- Set default TX/RX pin
    movs  r0, #0
    ldr   r1, =GPB_MFP
    str   r0, [r1]
    movs  r0, #3    @ PB1/0 = TX/RX
    str   r0, [r1]
    movs  r0, #0x0f
    ldr   r1, =GPF_MFP
    str   r0, [r1]
    

    @--- Set Tx/Rx pin:
    @ --- test package type
    ldr   r1, =PDID
    ldr   r0, [r1]
    ldr   r1, =(BIT6+BIT5+BIT4) @ TRM page 47: 5,4: 33pin 3,2: 48pin 0,1:64pin
    ands  r0, r0, r1
    cmp   r0, #0x30
    bgt   33f
    cmp   r0, #0x10
    bgt   48f

64: @ --- for 64pin package: PB1/PB0 GPB_MFPL[6:4]=b001, GPB_MFPL[2:0]=b001
		ldr		r1, =GPB_MFP               
		ldr		r0, [r1]
    movs  r3, #0b011
    orrs  r0, r0, r3
    str   r0, [r1]
    b     33f

48: @ --- for 48pin package: PC4/PC5, using ALT
    movs  r0, #0
    ldr   r1, =GPB_MFP  
    str   r0, [r1]
    ldr   r0, =(BIT30+BIT29)
    ldr   r1, =ALT_MFP
    str   r0, [r1]
    movs  r0, #0x30
    ldr   r1, =GPC_MFP
    str   r0, [r1]
    
33: @ -- 33pin has no UART0, nop

    @--- reset UART module
    ldr   r1, =IPRSTC2
    ldr   r0, =BIT16
    str   r0, [r1]
    movs  r0, #0
    str   r0, [r1]

    
    @--- Use URAT mode: UA_FUN_SEL[1:0]=0b00
    ldr   r1, =UA_FUN_SEL             
    ldr   r0, [r1]
    movs  r3, #0b00000011
    bics  r0, r3
    str   r0, [r1]
    
    @--- Set baud rate: UA_BAUD = 0x0000_0001 (115200)
    ldr   r1, =UA_BAUD
    movs  r0, #0x0A
    str   r0, [r1]

    @--- Set 8N1: UA_LCR = 0x0003
    ldr   r1, =UA_LCR
    movs  r0, #0x03
    str   r0, [r1]
    
    @--- Disable cts/rts and interrupt: UA_IER = 0x0
    movs  r0, #0x0
    ldr   r1, =UA_IER
    str   r0, [r1]
    
    bx lr

.include "../common/terminalhooks.s"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push   {lr}

1: bl     serial_qemit
   cmp    tos, #0
   drop
   beq    1b

   ldr    r2, =UA_THR
   strb   tos,[r2]         @ Output the character
   drop

   pop    {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
  push    {lr}

1: bl     serial_qkey
  cmp     tos, #0
  drop
  beq    1b

  pushdatos
  ldr     r2,=UA_RBR
  ldrb    tos,[r2]         @ Fetch the character

  pop     {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
  push    {lr}
  bl      pause

  pushdaconst 0  @ False Flag
  ldr     r1, =UA_FSR
  ldr     r0,[r1]
  ldr     r2, =(1<<23)  @ BIT23 : 1=TX_FULL
  tst     r0, r2
  bne     1f
  mvns    tos, tos @ True Flag

1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
  push    {lr}
  bl      pause

  pushdaconst 0  @ False Flag
  ldr     r1, =UA_FSR
  ldr     r0,[r1]
  ldr     r2, =(1<<14)  @ BIT14 : 1=RX_EMPTY 
  tst     r0, r2
  bne     1f
  mvns    tos, tos @ True Flag

1: pop    {pc}



  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
