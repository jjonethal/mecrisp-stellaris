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

.syntax unified
.cpu cortex-m0
.thumb
 
@ -----------------------------------------------------------------------------
@ Swiches for capabilities of this chip
@ -----------------------------------------------------------------------------

.equ m0core, 1
@ Not available: .equ charkommaavailable, 1

@ -----------------------------------------------------------------------------
@ Start with some essential macro definitions
@ -----------------------------------------------------------------------------

.include "../common/datastackandmacros.s"

@ -----------------------------------------------------------------------------
@ Speicherkarte für Flash und RAM
@ Memory map for Flash and RAM
@ -----------------------------------------------------------------------------

@ Constants for the size of the RAM memory

.equ RamAnfang, 0x20000000 @ Start of RAM           Porting: Change this !
.equ RamEnde,   0x20005000 @ End   of RAM.   20 kb. Porting: Change this !

@ Constants for the size and layout of the flash memory

.equ Kernschutzadresse,     0x00004000 @ Darunter wird niemals etwas geschrieben ! Mecrisp core never writes flash below this address.
.equ FlashDictionaryAnfang, 0x00004000 @ 16 kb für den Kern reserviert...           16 kb Flash reserved for core.
.equ FlashDictionaryEnde,   0x00010000 @ 64 kb Platz für das Flash-Dictionary       64 kb Flash available. Porting: Change this
.equ Backlinkgrenze,        RamAnfang  @ Ab dem Ram-Start.

@ -----------------------------------------------------------------------------
@ Anfang im Flash - Interruptvektortabelle ganz zu Beginn
@ Flash start - Vector table has to be placed here
@ -----------------------------------------------------------------------------
.text    @ Hier beginnt das Vergnügen mit der Stackadresse und der Einsprungadresse
.include "vectors.s" @ You have to change vectors for Porting !

@ -----------------------------------------------------------------------------
@ Include the Forth core of Mecrisp-Stellaris
@ -----------------------------------------------------------------------------
 
.include "../common/forth-core.s"



@ -----------------------------------------------------------------------------
@ NUC123 Power & clock
@ -----------------------------------------------------------------------------
    .equ CLK_BA     ,0x50000200
    .equ PWRCON     ,CLK_BA+0x00    @ R/W System Power-down Control Register 0x0000_001X 
    .equ AHBCLK     ,CLK_BA+0x04    @  R/W AHB Devices Clock Enable Control Register 0x0000_0004 
    .equ APBCLK     ,CLK_BA+0x08    @  R/W APB Devices Clock Enable Control Register 0x0000_000X 
    .equ CLKSTATUS  ,CLK_BA+0x0C    @  R/W Clock Status Monitor Register 0x0000_00XX 
    .equ CLKSEL0    ,CLK_BA+0x10    @  R/W Clock Source Select Control Register 0 0x0000_003X 
    .equ CLKSEL1    ,CLK_BA+0x14    @  R/W Clock Source Select Control Register 1 0xFFFF_FFFF 
    .equ CLKSEL2    ,CLK_BA+0x1C    @  R/W Clock Source Select Control Register 2 0x0002_00FF 
    .equ CLKDIV     ,CLK_BA+0x18    @  R/W Clock Divider Number Register 0x0000_0000 
    .equ PLLCON     ,CLK_BA+0x20    @  R/W PLL Control Register 0x0005_C22E 
    .equ FRQDIV     ,CLK_BA+0x24    @  R/W Frequency Divider Control Register 0x0000_0000 
    .equ APBDIV     ,CLK_BA+0x2C    @  R/W APB Divider Control Register 0x0000_0000


@ -----------------------------------------------------------------------------
Reset: @ Einsprung zu Beginn
@ -----------------------------------------------------------------------------
Nuc123_init:

    nop
    @--- various board init
    bl      Board_init

    @ Initialisierungen der Hardware, habe und brauche noch keinen Datenstack dafür
    @ Initialisations for Terminal hardware, without Datastack.
    bl uart_init

    @ Catch the pointers for Flash dictionary
    .include "../common/catchflashpointers.s"

    welcome " with M0 core by Matthias Koch"
    writeln "  modified for NUC123 by juju2013"
    writeln ""

    @ Ready to fly ! 
    .include "../common/boot.s"

@ -----------------------------------------------------------------------------
Board_init: @ Initialize the board
@ -----------------------------------------------------------------------------
  push {lr}

  bl      sys_unlock
  
  @--- init POR (TRM, page 55)
  ldr     r1, =0x05AA5
  ldr     r2, =PORCR
  str     r1, [r2]
  
  ldr     r4, =PWRCON
  @--- Internal 22Mhz clock
  movs    r0, #0b01101 @ enable Internal 22M,10k & external crystal clock
  ldr     r1, [r4]
  orrs    r1, r0
  movs    r1, #0x1C @ RE main.c
  str     r1, [r4]
  
  @--- wait till clock stabilize
  movs    r0, #BIT4
  bl      Wait_clock
  movs    r0, #BIT3
  bl      Wait_clock
  movs    r0, #BIT0
  bl      Wait_clock
  
  @--- HCLK clock source selection
  ldr     r4, =CLKSEL0
  ldr     r1, [r4]
  movs    r0, #0b0111
  orrs    r1, r1, r0  @should be 0x3F
  str     r1, [r4]

  @--- HCLK clock frequence division
  ldr     r4, =CLKDIV
  movs    r0, #0
  str     r0, [r4]
  
  @--- UART0 clock enable
  ldr     r4, =APBCLK
  ldr     r1, =BIT16
  str     r1, [r4]
  
  bl      sys_lock

  pop {pc}

@ -----------------------------------------------------------------------------
Wait_clock: @wait clock to stabilize or timeout
@ r0 = wait mask
@ -----------------------------------------------------------------------------
  ldr     r3, =2160000    @ approx. 300ms
  ldr     r1, =CLKSTATUS
1: subs    r3, r3, #1
  beq     2f
  
  ldr     r2, [r1]
  ands    r2, r0
  beq     1b
  
2:bx lr

