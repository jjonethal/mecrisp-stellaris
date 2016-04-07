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

  .equ GPIOA_BASE      ,   0x40010800
  .equ GPIOA_CRL       ,   GPIOA_BASE + 0x00
  .equ GPIOA_CRH       ,   GPIOA_BASE + 0x04
  .equ GPIOA_IDR       ,   GPIOA_BASE + 0x08
  .equ GPIOA_ODR       ,   GPIOA_BASE + 0x0C
  .equ GPIOA_BSRR      ,   GPIOA_BASE + 0x10
  .equ GPIOA_BRR       ,   GPIOA_BASE + 0x14
  .equ GPIOA_LCKR      ,   GPIOA_BASE + 0x18

  .equ RCC_BASE        ,   0x40021000
  .equ RCC_APB2ENR     ,   RCC_BASE + 0x18

    .equ AFIOEN, 0x0001
    .equ IOPAEN, 0x0004
    .equ IOPBEN, 0x0008
    .equ IOPCEN, 0x0010
    .equ IOPDEN, 0x0020
    .equ IOPEEN, 0x0040
    .equ IOPFEN, 0x0080
    .equ IOPGEN, 0x0100
    .equ USART1EN, 0x4000

  .equ Terminal_USART_Base, 0x40013800 @ USART 1
  .include "../common/stm-terminal.s"  @ Common STM terminal code for emit, key and key?

@ -----------------------------------------------------------------------------
uart_init:
@ -----------------------------------------------------------------------------

  @ Most of the peripherals are connected to APB2.  Turn on the
  @ clocks for the interesting peripherals and all GPIOs.
  ldr r1, = RCC_APB2ENR
  ldr r0, = AFIOEN|IOPAEN|IOPBEN|IOPCEN|IOPDEN|USART1EN  @ |IOPEEN|IOPFEN|IOPGEN|
  str r0, [r1]

  @ Set PORTA pins in alternate function mode
  @ Put PA9  (TX) to alternate function output push-pull at 50 MHz
  @ Put PA10 (RX) to floating input
  ldr r1, = GPIOA_CRH
  ldr r0, = 0x000004B0
  str r0, [r1]

  Set_Terminal_USART_Baudrate

  bx lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
