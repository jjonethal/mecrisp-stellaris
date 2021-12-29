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

@ Terminal interface for stm32h743 Nucleo @ 480 MHz via debug virtual comport
@ VCP_TX - PD8 USART3 AF7 USART1_TX
@ VCP_RX - PD9 USART3 AF7 USART1_RX


@ Terminalroutinen
@ Terminal code and initialisations.
@ Porting: Rewrite this !

@ GPIO registers
  .equ GPIOA_BASE      ,   0x58020000
  .equ GPIOA_MODER     ,   GPIOA_BASE + 0x00
  .equ GPIOA_OTYPER    ,   GPIOA_BASE + 0x04
  .equ GPIOA_OSPEEDR   ,   GPIOA_BASE + 0x08
  .equ GPIOA_PUPDR     ,   GPIOA_BASE + 0x0C
  .equ GPIOA_IDR       ,   GPIOA_BASE + 0x10
  .equ GPIOA_ODR       ,   GPIOA_BASE + 0x14
  .equ GPIOA_BSRR      ,   GPIOA_BASE + 0x18
  .equ GPIOA_LCKR      ,   GPIOA_BASE + 0x1C
  .equ GPIOA_AFRL      ,   GPIOA_BASE + 0x20
  .equ GPIOA_AFRH      ,   GPIOA_BASE + 0x24

  .equ GPIOB_BASE      ,   (GPIOA_BASE + (1*0x400))
  .equ GPIOB_MODER     ,   GPIOB_BASE + 0x00
  .equ GPIOB_OTYPER    ,   GPIOB_BASE + 0x04
  .equ GPIOB_OSPEEDR   ,   GPIOB_BASE + 0x08
  .equ GPIOB_PUPDR     ,   GPIOB_BASE + 0x0C
  .equ GPIOB_IDR       ,   GPIOB_BASE + 0x10
  .equ GPIOB_ODR       ,   GPIOB_BASE + 0x14
  .equ GPIOB_BSRR      ,   GPIOB_BASE + 0x18
  .equ GPIOB_LCKR      ,   GPIOB_BASE + 0x1C
  .equ GPIOB_AFRL      ,   GPIOB_BASE + 0x20
  .equ GPIOB_AFRH      ,   GPIOB_BASE + 0x24
  
  .equ GPIOC_BASE      ,   (GPIOA_BASE + (2*0x400))

  .equ GPIOD_BASE      ,   (GPIOA_BASE + (3*0x400))
  .equ GPIOD_MODER     ,   GPIOD_BASE + 0x00
  .equ GPIOD_AFRH      ,   GPIOD_BASE + 0x24

  .equ GPIOK_MODER     ,   (GPIOA_BASE + (10*0x400))

@ Cache definitions
  .equ ICIALLU                      ,   0xE000EF50
  .equ CCR                          ,   0xE000ED14
  .equ CSSELR                       ,   0xE000ED84
  .equ CCSIDR                       ,   0xE000ED80
  .equ DCISW                        ,   0xE000EF60
  .equ SCB_CCR_IC                   ,   BIT17

@ Flash registers
  .equ FLASH_BASE                   ,   0x52002000
  .equ FLASH_ACR                    ,   FLASH_BASE + 0x00
@ Flash definitions
  .equ FLASH_LATENCY_4              ,   4
  .equ FLASH_ACR_LATENCY_Msk		, 	0xF

@ Voltage scaling register
  .equ PWR_BASE                     ,   0x58024800
  .equ PWR_CR3                      ,   PWR_BASE + 0x0C
  .equ PWR_D3CR                     ,   PWR_BASE + 0x18
@ Voltage scaling definitions
  .equ PWR_CR3_BYPASS				, 	BIT0
  .equ PWR_CR3_LDOEN				,   BIT1
  .equ PWR_CR3_SCUEN				,	BIT2
  .equ PWR_REGU_VOLTAGE_SCALE0      ,   3 << 14
  .equ PWR_D3CR_VOS_Msk				,	3 << 14

@ RCC registers
  .equ RCC_BASE                     ,   0x58024400
  .equ RCC_CR                       ,   RCC_BASE + 0x00
  .equ RCC_CFGR                     ,   RCC_BASE + 0x10
  .equ RCC_D1CFGR                   ,   RCC_BASE + 0x18
  .equ RCC_D2CFGR                   ,   RCC_BASE + 0x1C
  .equ RCC_D3CFGR                   ,   RCC_BASE + 0x20
  .equ RCC_PLLCKSELR                ,   RCC_BASE + 0x28
  .equ RCC_PLLCFGR                  ,   RCC_BASE + 0x2C
  .equ RCC_PLL1DIVR                 ,   RCC_BASE + 0x30
  .equ RCC_D2CCIP2R                 ,   RCC_BASE + 0x54
  .equ RCC_AHB4ENR                  ,   RCC_BASE + 0xE0
  .equ RCC_APB1ENR                  ,   RCC_BASE + 0xE8
  .equ RCC_APB2ENR                  ,   RCC_BASE + 0xF0
@ RCC definitions
  .equ RCC_CR_HSEON                 ,   BIT16
  .equ RCC_CR_HSERDY                ,   BIT17
  .equ RCC_CR_HSEBYP                ,   BIT18
  .equ RCC_CR_PLL1ON                ,   BIT24
  .equ RCC_CR_PLL1RDY               ,   BIT25
  .equ RCC_CFGR_SW_Msk				,   0x7 << 0
  .equ RCC_SYS_CLKSOURCE_PLL1       ,   3
  .equ RCC_SYSCLK_DIV_1             ,   0 << 8  @ 480 MHz / 1 = 480 MHz sysclock
  .equ RCC_D1CFGR_HPRE_Msk			,   0xF << 0
  .equ RCC_AHB_DIV_2                ,   8 << 0  @ 480 MHz / 2 = 240 MHz AHB clock
  .equ RCC_D2CFGR_D2PPRE1_Msk       ,   0x7 << 4
  .equ RCC_APB1_DIV_2               ,   2 << 5  @ 240 MHz / 2 = 120 MHz APB1 clock
  .equ RCC_D2CFGR_D2PPRE2_Msk		,   0x7 << 8
  .equ RCC_APB2_DIV_2               ,   2 << 9  @ 240 MHz / 2 = 120 MHz APB2 clock
  .equ RCC_D1CFGR_D1PPRE_Msk		,	0x7 << 4
  .equ RCC_APB3_DIV_2               ,   2 << 5  @ 240 MHz / 2 = 120 MHz APB3 clock
  .equ RCC_D3CFGR_D3PPRE_Msk		,   0x7 << 4
  .equ RCC_APB4_DIV_2               ,   2 << 5  @ 240 MHz / 2 = 120 MHz APB4 clock
  .equ RCC_USART234578_CLKSOURCE_HSI,   3 << 0  @ 64 MHx HSI clock
@ PLL 480 MHz
  .equ RCC_PLLCKSELR_PLLSRC_Msk 	,   0x3
  .equ RCC_PLLSRC_HSE               ,   2
  .equ RCC_PLLCFGR_DIVP1EN          ,   BIT16
  .equ RCC_PLLCFGR_DIVR1EN          ,   BIT18
  .equ RCC_PLLCFGR_PLL1RGE_Msk		,	3 << 2
  .equ RCC_PLLINPUTRANGE_8_16       ,   3 << 2
  .equ RCC_PLLCFGR_PLL1VCOSEL		,   1 << 1
  .equ RCC_PLLVCORANGE_WIDE         ,   0 << 1
  .equ RCC_PLLCKSELR_DIVM1_Msk		,   0x3F << 4
  .equ RCC_PLLCKSELR_DIVM1          ,   1 << 4          @ 8 MHz input / 1 = 8 MHz
  .equ RCC_PLL1DIVR_N1_Msk			,	0xFF << 1
  .equ RCC_PLL1DIVR_N1              ,   (120 - 1) << 0  @ 8 MHz * 120  = 960 MHz
  .equ RCC_PLL1DIVR_P1_Msk			,   0x7F << 9
  .equ RCC_PLL1DIVR_P1              ,   (2 - 1) << 9    @ 960 MHz / 2 = 480 MHz
  .equ RCC_PLL1DIVR_Q1_Msk			,   0x7F << 16
  .equ RCC_PLL1DIVR_Q1              ,   (4 - 1) << 16   @ 960 MHz / 4 = 240 MHz
  .equ RCC_PLL1DIVR_R1_Msk			,   0x7F << 24
  .equ RCC_PLL1DIVR_R1              ,   (2 - 1) << 24   @ 960 MHz / 2 = 480 MHz

@ USART registers
  .equ Terminal_USART_Base, 0x40004800 @ USART 3
  .equ Terminal_CR1    ,   Terminal_USART_Base + 0x00
  .equ Terminal_CR2    ,   Terminal_USART_Base + 0x04
  .equ Terminal_CR3    ,   Terminal_USART_Base + 0x08
  .equ Terminal_BRR    ,   Terminal_USART_Base + 0x0C
  .equ Terminal_GTPR   ,   Terminal_USART_Base + 0x10
  .equ Terminal_RTOR   ,   Terminal_USART_Base + 0x14
  .equ Terminal_RQR    ,   Terminal_USART_Base + 0x18
  .equ Terminal_ISR    ,   Terminal_USART_Base + 0x1C
  .equ Terminal_ICR    ,   Terminal_USART_Base + 0x20
  .equ Terminal_RDR    ,   Terminal_USART_Base + 0x24
  .equ Terminal_TDR    ,   Terminal_USART_Base + 0x28
@ defs for USART_CR1 register
  .equ USART_CR1_UE    ,   BIT0
  .equ USART_CR1_TE    ,   BIT3
  .equ USART_CR1_RE    ,   BIT2
@ Flags for USART_ISR register:
  .equ RXNE            ,   BIT5
  .equ TC              ,   BIT6
  .equ TXE             ,   BIT7
@ Flag for USART_CR3
  .equ USART_CR3_OVRDIS ,  BIT12
  
.macro modify_reg reg, clearmask, setmask
  ldr   r1, = \reg
  ldr   r0, [r1]
  bic.w r0, \clearmask
  orr.w r0, \setmask
  str   r0, [r1]
.endm

.macro set_bit reg, bit
  ldr   r1, = \reg
  ldr   r0, [r1]
  orr.w r0, \bit
  str   r0, [r1]
.endm

enable_i_cache:
  dsb
  isb
  ldr   r1, = ICIALLU
  ldr   r0, = 0
  str   r0, [r1]
  dsb
  isb
  ldr   r1, = CCR
  ldr   r0, [r1]
  orr.w r0, SCB_CCR_IC
  str   r0, [r1]
  dsb
  isb
  bx    lr

enable_d_cache: @ TODO : p.240 prog man

  dsb

  dsb

  dsb
  isb
  bx   lr

set_flash_latency:
  modify_reg 	FLASH_ACR, 		FLASH_ACR_LATENCY_Msk, 		FLASH_LATENCY_4
1: ldr  r0, [r1]
  and.w r0, FLASH_ACR_LATENCY_Msk
  cmp   r0, FLASH_LATENCY_4
  bne   1b
  bx    lr

set_power_config:
  modify_reg 	PWR_CR3, (PWR_CR3_SCUEN | PWR_CR3_LDOEN | PWR_CR3_BYPASS), PWR_CR3_LDOEN
  bx    lr
  
set_voltage_scaling:
  modify_reg 	PWR_D3CR, 		PWR_D3CR_VOS_Msk, 			PWR_REGU_VOLTAGE_SCALE0
  bx    lr

enable_bypass_hse:
  set_bit RCC_CR, RCC_CR_HSEBYP
  set_bit RCC_CR, RCC_CR_HSEON
1: ldr  r0, [r1]
  ands  r0, RCC_CR_HSERDY
  beq   1b
  bx    lr

set_pll_480_mhz_sysclk:
  modify_reg 	RCC_PLLCKSELR, 	RCC_PLLCKSELR_PLLSRC_Msk, 	RCC_PLLSRC_HSE
  set_bit 		RCC_PLLCFGR, 	RCC_PLLCFGR_DIVP1EN
  set_bit 		RCC_PLLCFGR, 	RCC_PLLCFGR_DIVR1EN
  modify_reg 	RCC_PLLCFGR, 	RCC_PLLCFGR_PLL1RGE_Msk,	RCC_PLLINPUTRANGE_8_16
  modify_reg 	RCC_PLLCFGR, 	RCC_PLLCFGR_PLL1VCOSEL,		RCC_PLLVCORANGE_WIDE
  modify_reg 	RCC_PLLCKSELR, 	RCC_PLLCKSELR_DIVM1_Msk, 	RCC_PLLCKSELR_DIVM1
  modify_reg 	RCC_PLL1DIVR, 	RCC_PLL1DIVR_N1_Msk, 		RCC_PLL1DIVR_N1
  modify_reg 	RCC_PLL1DIVR, 	RCC_PLL1DIVR_P1_Msk, 		RCC_PLL1DIVR_P1
  modify_reg 	RCC_PLL1DIVR, 	RCC_PLL1DIVR_Q1_Msk, 		RCC_PLL1DIVR_Q1
  modify_reg 	RCC_PLL1DIVR, 	RCC_PLL1DIVR_R1_Msk, 		RCC_PLL1DIVR_R1
  bx    lr

enable_pll:
  set_bit		RCC_CR,			RCC_CR_PLL1ON
1: ldr  r0, [r1]
  ands  r0, RCC_CR_PLL1RDY
  beq   1b
  bx    lr

set_prescalers:
  modify_reg	RCC_D1CFGR,		RCC_D1CFGR_HPRE_Msk,		RCC_AHB_DIV_2
  modify_reg    RCC_CFGR,		RCC_CFGR_SW_Msk,			RCC_SYS_CLKSOURCE_PLL1
  modify_reg    RCC_D1CFGR,		RCC_D1CFGR_HPRE_Msk,		RCC_AHB_DIV_2
  modify_reg    RCC_D1CFGR,		RCC_D1CFGR_D1PPRE_Msk,		RCC_APB3_DIV_2
  modify_reg	RCC_D2CFGR,		RCC_D2CFGR_D2PPRE1_Msk,		RCC_APB1_DIV_2
  modify_reg	RCC_D2CFGR,		RCC_D2CFGR_D2PPRE2_Msk,		RCC_APB2_DIV_2
  modify_reg	RCC_D3CFGR,		RCC_D3CFGR_D3PPRE_Msk,		RCC_APB4_DIV_2
  bx    lr

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  push {lr}

  @ first enable caches and set highest CPU clock for performance
  bl enable_i_cache
  bl enable_d_cache
  bl set_flash_latency
  bl set_power_config
  bl set_voltage_scaling
  bl enable_bypass_hse
  bl set_pll_480_mhz_sysclk
  bl enable_pll
  bl set_prescalers

  @ Select HSI clock (64 MHz) for USART3
  ldr  r1, = RCC_D2CCIP2R
  ldr  r0, = RCC_USART234578_CLKSOURCE_HSI
  str  r0, [r1]

  @ Enable all GPIO peripheral clocks
  ldr  r1, = RCC_AHB4ENR
  ldr  r0, [r1]
  orrs r0, #0x00F
  orrs r0, #0x7F0
  str  r0, [r1]

  @ Set PORTD pins in alternate function mode
  ldr  r1, = GPIOD_MODER
  ldr  r0, [r1]
  and  r0, #0xFFFCFFFF     @ Zero the bits 16-17 config for PD8
  orrs r0, #0x00020000     @ AF mode for PD8
  str  r0, [r1]

  @ Set PORTD pins in alternate function mode
  ldr  r1, = GPIOD_MODER
  ldr  r0, [r1]
  and  r0, #0xFFF3FFFF     @ Zero the bits 18-19 config for PD9
  orrs r0, #0x00080000     @ AF mode for PD9
  str  r0, [r1]

  @ Set alternate function 7 to enable USART3 pins on Port PD8
  ldr  r1, = GPIOD_AFRH
  ldr  r0, [r1]
  and  r0, #0xFFFFFFF0     @ Zero the bits 0-3
  orrs r0, #0x07           @ Alternate function 7 for TX pin of USART3 on PD8
  str  r0, [r1]

  @ Set alternate function 7 to enable USART3 pins on Port PD9
  ldr  r1, = GPIOD_AFRH
  ldr  r0, [r1]
  and  r0, #0xFFFFFF0F    @ Zero the bits 4-7
  orrs r0, #0x70          @ Alternate function 7 for RX pin of USART3 on PD9
  str  r0, [r1]

  @ Enable the USART3 peripheral clock by setting bit 18 of APB1ENR
  ldr  r1, = RCC_APB1ENR
  ldr  r0, [r1]
  orrs r0, #0x00040000
  str  r0, [r1]

  @ Configure BRR by dividing the bus clock with the baud rate
  ldr  r1, =Terminal_BRR
  movs r0, #0x22C @#(64000000 + 115200 / 2) / 115200 @ 0x22C  -> 64 MHz HSI / 115200 baud
  str  r0, [r1]

  @ disable overrun detection before UE to avoid USART blocking on overflow
  ldr  r1, =Terminal_CR3
  ldr  r0, =USART_CR3_OVRDIS @ USART_CR3_OVRDIS
  str  r0, [r1]

  @ Enable the USART, TX, and RX circuit
  ldr  r1, =Terminal_CR1
  ldr  r0, =USART_CR1_UE + USART_CR1_TE + USART_CR1_RE
  str  r0, [r1]

  pop {lr}

  bx   lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !

@ Following code is the same as for STM32F051
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

   ldr r2, =Terminal_TDR
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

   pushdatos
   ldr r2, =Terminal_RDR
   ldrb tos, [r2]         @ Fetch the character

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0    @ False Flag
   ldr r0, =Terminal_ISR
   ldr r1, [r0]     @ Fetch status
   movs r0, #TXE
   ands r1, r0
   beq 1f
   mvns tos, tos    @ True Flag
1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0  @ False Flag
   ldr r0, =Terminal_ISR
   ldr r1, [r0]     @ Fetch status
   movs r0, #RXNE
   ands r1, r0
   beq 1f
   mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
