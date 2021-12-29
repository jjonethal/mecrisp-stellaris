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

@ Terminalroutinen
@ Terminal code and initialisations.
@ Porting: Rewrite this !


@ GPIO register map is similiar to STM32F4 chips.
@ -> register boundary address  pp. 65 in DM00031020.pdf

  .equ GPIOE_BASE      ,   0x40021000

  .equ GPIOE_MODER     ,   GPIOE_BASE + 0x00 @ pp. 287 of DM00031020.pdf
  .equ GPIOE_OTYPER    ,   GPIOE_BASE + 0x04
  .equ GPIOE_ODR       ,   GPIOE_BASE + 0x14

  .equ GPIOB_BASE, 0x40020400

  .equ GPIOB_MODER     ,   GPIOB_BASE + 0x00
  .equ GPIOB_AFRL      ,   GPIOB_BASE + 0x20
  .equ GPIOB_AFRH      ,   GPIOB_BASE + 0x24

  .equ GPIOA_BASE      ,   0x40020000
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

  .equ RCC_BASE        ,   0x40023800
  .equ RCC_CR          ,   RCC_BASE + 0x00
  .equ RCC_CFGR        ,   RCC_BASE + 0x08
  .equ RCC_AHB1ENR     ,   RCC_BASE + 0x30
  .equ RCC_AHB2ENR     ,   RCC_BASE + 0x34
  .equ RCC_APB1ENR     ,   RCC_BASE + 0x40
  .equ RCC_APB2ENR     ,   RCC_BASE + 0x44

    .equ HSERDY        ,   BIT17
    .equ HSEON         ,   BIT16

@ USART1 on STM32F1/STM32F4 chips: pp. 1018 in RM0090 (dm00031020-stm*.pdf)
        .equ USART1_BASE    ,   0x40011000
        .equ USART1_SR      ,   USART1_BASE + 0x00
        .equ USART1_DR      ,   USART1_BASE + 0x04
        .equ USART1_BRR     ,   USART1_BASE + 0x08
        .equ USART1_CR1     ,   USART1_BASE + 0x0C
        .equ USART1_CR2     ,   USART1_BASE + 0x10
        .equ USART1_CR3     ,   USART1_BASE + 0x14
        .equ USART1_GPTR    ,   USART1_BASE + 0x18

.equ USART_CR1_UE,BIT13
.equ USART_CR1_TE,BIT3
.equ USART_CR1_RE,BIT2

.equ  Terminal_USART_Base, USART1_BASE
.include "../common/stm-terminal.s"  @ Common STM terminal code for emit, key and key?

@ -----------------------------------------------------------------------------
Setup_Clocks:
@ -----------------------------------------------------------------------------
        @ Initialize STM32 Clocks

        @ Ideally, we would just take the defaults to begin with and
        @ do nothing.  Because it is possible that HSI is not
        @ accurate enough for the serial communication (USART2), we
        @ will switch from the internal 8 MHz clock (HSI) to the
        @ external 8 MHz clock (HSE).

        ldr r1, = RCC_CR
        mov r0, HSEON
        str r0, [r1]            @ turn on the external clock

awaitHSE:
        ldr r0, [r1]
        ands r0, #HSERDY
        beq.n awaitHSE            @ hang here until external clock is stable

        @ at this point, the HSE is running and stable but I suppose we have not yet
        @ switched Sysclk to use it.

        ldr r1, = RCC_CFGR
        mov r0, # 1
        str r0, [r1]            @ switch to the external clock
        
        @ Turn off the HSION bit
        ldr r1, = RCC_CR
        ldr r0, [r1]
        and r0, 0xFFFFFFFE      @ Zero the 0th bit
        str r0, [r1]

        bx lr

@ -----------------------------------------------------------------------------
Setup_UART:
@ -----------------------------------------------------------------------------
@ Turn on the clocks for all GPIOs.
  ldr r1, = RCC_AHB1ENR   @ p. 242 und p. 266 manual RM00090 (Rev 18)
                          @ dm00031020-stm32f405-415-stm32f407......pdf
  ldr r0, = BIT20+0x1f   @ Enable Port A,B,C,D,E
  str r0, [r1]

@ Set PORTA pins 9 and 10 in alternate function mode
  ldr r1, = GPIOA_MODER
  ldr r0, = 0xA8280000 @ A8000000  is Reset value for Port A, and
                       @ switch PA9 and PA10 to alternate function
  str r0, [r1]

@ Set alternate function 1 to enable USART1 pins on Port A
  ldr r1, = GPIOA_AFRH
  ldr r0, = 0x00000770 @ Alternate function 1 for TX and RX pins of
                       @ USART1 on PORTA  PA09 PA10 (pp. 272)
  str r0, [r1]


@ Turn on the clock for USART1.
  ldr r1, = RCC_APB2ENR
  movs r0, #0x10 @ USART1EN
  str r0, [r1]

  @ Configure BRR by deviding the bus clock with the baud rate
  ldr r1, = USART1_BRR
  movs r0, #0x46  @ 115200 bps, ein ganz kleines bisschen langsamer...
  str r0, [r1]

  @ Enable the USART, TX, and RX circuit
  ldr r1, =USART1_CR1
  ldr r0, =USART_CR1_UE+USART_CR1_TE+USART_CR1_RE @ 
  str r0, [r1]

  @ Enable PE0 (User Led) to sink mode output and switch on

  ldr r1, = GPIOE_MODER
  ldr r0, = 0x01      @ bit PE0 to GP Output
  str r0,[r1]

  ldr r1,= GPIOE_OTYPER  @ p. 281
  ldr r0, = 0x01           @ open-drain
  str r0,[r1]

  ldr r1,= GPIOE_ODR     @ LED ON
  ldr r0, = 0x0
  str r0,[r1]

  bx lr


@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------
  push {lr}

  bl Setup_Clocks
  bl Setup_UART
  
  pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
