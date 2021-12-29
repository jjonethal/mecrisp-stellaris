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
  .equ RCC_APB1ENR     ,   RCC_BASE + 0x40

  .equ HSERDY          ,   BIT17
  .equ HSEON           ,   BIT16

  .equ Terminal_USART_Base, 0x40004400 @ USART 2
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

        @ Enable GPIO peripheral clock Port A
        ldr r1, = RCC_AHB1ENR
        ldr r0, [r1]
        and r0, 0xFFFFFFFE
        orrs r0, 1              @ GPIOAEN
        str r0, [r1]

        @ Set PORTA pins in alternate function mode
        ldr r1, = GPIOA_MODER
        ldr r0, [r1]
        and r0, 0xFFFFFF0F      @ Zero the bits 4-7 config for nucleo
        orrs r0, #0xA0
        str r0, [r1]

        @ Activate the internal PULL-UP in PORTA pin 3 (RxD)
        ldr r1, = GPIOA_PUPDR
        ldr r0, [r1]
        orrs r0, #0x40 @ PUPDR3[1:0] = 01b
        str r0, [r1] 

        @ Set alternate function 7 to enable USART2 pins on Port A
        ldr  r1, = GPIOA_AFRL
        and  r0, 0xFFFF00FF      @ Zero the bits 8-15
        orrs r0, #0x7700         @ Alternate function 7 for TX and RX pins of USART2 on PORTA(2,3)
        str  r0, [r1]

        @ Enable the USART2 peripheral clock by setting bit 17
        ldr r1, = RCC_APB1ENR
        ldr r0, = BIT17
        str r0, [r1]

        @Set_Terminal_USART_Baudrate

        @ Configure BRR by deviding the bus clock with the baud rate

        ldr r1, =Terminal_USART_BRR
        movs r0, #0x8B  @ 115200 bps / 16 MHz HSI
        str r0, [r1]

        @ Enable the USART, TX, and RX circuit
        ldr r1, =Terminal_USART_CR1
        ldr r0, =BIT13+BIT3+BIT2 @ USART_CR1_UE | USART_CR1_TE | USART_CR1_RE
        str r0, [r1]

        bx lr

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------
  push {lr}

@  bl Setup_Clocks @ may be uncommented for MB 1136 C-02 or external 8 mhz clock source 
  bl Setup_UART

  pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
