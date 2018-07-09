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

@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

  /* nvic setup */
  ldr r0, =NVIC_APPLN_INTR
  ldr r1, =0x05FA0400
  str r1, [r0]

  ldr r0, =NVIC_CFG_CONTROL
  mov r1, #0x200
  str r1, [r0]

  cpsid i

  /* set flash cycles */
  ldr r0, =CACHE_CC_CTL
  mov r1, #1
  strb r1, [r0]

  /* clock setup */
  /* configure internal low freq oscillator (ilo) */
  ldr r0, =SLOWCLK_ILO_CR0
  mov r1, #0x06
  strb r1, [r0]
  
  /* configure internal main oscillator (imo) */
  ldr r0, =FASTCLK_IMO_CR
  mov r1, #0x52
  strb r1, [r0]
 
  ldr r0, =IMO_TR1
  ldr r1, =FLSHID_CUST_TABLES_IMO_USB
  ldrb r2, [r1]
  strb r2, [r0]
  
  /* Configure PLL */
  ldr r0, =FASTCLK_PLL_P
  ldr r1, =0x0818
  strh r1, [r0]
 
  ldr r0, =FASTCLK_PLL_CFG0
  ldr r1, =0x1251
  strh r1, [r0]
              
  /* Get PLL lock */
  mov r2, #25
  mov r1, #0
  3: 
  ldr r0, =FASTCLK_PLL_SR
  mov r3, r1
  ldrb r1, [r0]
  and r1, #1
  lsl r3, #1
  orr r1, r3
 
  /* delay based on 48MHz clock */
  movs r0, #480
  1:
  subs r0, #1
  bne 1b
  
  tst r2, #0
  beq 2f
  subs r2, #1
  tst r1, #0x03
  bne 3b
  2:

  /* Configure Master, Bus Clocks */
  ldr r0, =CLKDIST_MSTR0
  mov r1, #0x0100
  strh r1, [r0]

  /* Configure Master, Bus Clocks */
  ldr r0, =CLKDIST_MSTR0
  mov r1, #0x07
  strb r1, [r0]

  ldr r0, =CLKDIST_BCFG0
  mov r1, #0x00
  strb r1, [r0]

  ldr r0, =CLKDIST_BCFG2
  mov r1, #0x48
  strb r1, [r0]
 
  ldr r0, =CLKDIST_MSTR0
  mov r1, #0x00
  strb r1, [r0]

  /* Configure USB Clock based on settings from Clock DWR */
  ldr r0, =CLKDIST_UCFG
  mov r1, #0x00
  strb r1, [r0]

  ldr r0, =CLKDIST_LD
  mov r1, #0x02
  strb r1, [r0]
 
  /* set uart pin drive modes */
  /* module tx */
  ldr r0, =0x40005067
  mov r1,#0x0C
  strb r1,[r0]
  /* module rx */
  ldr r0, =0x40005066
  mov r1,#0x06
  strb r1,[r0]
@  /* module cts */
@  ldr r0, =0x40005065
@  mov r1,#0x06
@  strb r1,[r0]
@  /* module rts */
@  ldr r0, =0x40005064
@  mov r1,#0x0C
@  strb r1,[r0]

  bx lr

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
 
.include "../common/terminalhooks.s"

@ @ -----------------------------------------------------------------------------
@   Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ @ -----------------------------------------------------------------------------
  cpsid i

  popda r0
  push {lr}

  /* setup */
  ldr r2,=0x420A381C

  /* payload */
  mov r1,#1
  nop
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  nop

  mov r1,#0
  nop
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  nop

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,r0
  and r1,#1
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  lsr r0, #1

  mov r1,#1
  nop
  strb r1, [r2]
  movs r1, #370
  1:
  subs r1,#1
  bne 1b
  nop

  cpsie i

  pop {pc}


@ @ -----------------------------------------------------------------------------
@   Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ @ -----------------------------------------------------------------------------
  cpsid i
  push {lr}

  /* setup */
  ldr r2,=0x420A3838
  mov r3,#0

  /* sync */
  1:
  ldrb r1,[r2]
  tst r1,#1
  bne 1b

  /* start */
  mov r0,#0

  movs r1,#185
  1:
  subs r1,#1
  bne 1b

  movs r1,#370
  1:
  subs r1,#1
  bne 1b

  /* payload */
  2:  
  ldrb r1,[r2]
  lsl r1,r3
  orr r0,r1

  movs r1,#370
  1:
  subs r1,#1
  bne 1b

  adds r3,#1
  cmp r3,#8
  bne 2b

  /* stop */
  1:
  ldrb r1,[r2]
  tst r1,#0
  bne 1b

  movs r1,#370
  1:
  subs r1,#1
  bne 1b

  pushda r0

  cpsie i

  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   @ Always true for bitbang terminal.
   pushdaconst 0
   mvns tos, tos

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   @ Always true for bitbang terminal.
   pushdaconst 0
   mvns tos, tos

   pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
