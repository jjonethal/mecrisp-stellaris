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

@ Common interrupt helpers

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "eint" @ ( -- ) Aktiviert Interrupts  Enables Interrupts
@ ----------------------------------------------------------------------------- 
  cpsie i @ Interrupt-Handler
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "dint" @ ( -- ) Deaktiviert Interrupts  Disables Interrupts
@ ----------------------------------------------------------------------------- 
  cpsid i @ Interrupt-Handler
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline, "ipsr" @ ( -- int ) Read IPSR by Mark Schweizer
@ ----------------------------------------------------------------------------- 
  pushdatos
  mrs tos, ipsr
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "nop" @ ( -- ) @ Handler for unused hooks
nop_vektor:                    
@ ----------------------------------------------------------------------------- 
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "unhandled" @ Message for wild interrupts
unhandled:                            @   and handler for unused interrupts
@ -----------------------------------------------------------------------------
  push {lr} 
  @ writeln "Unhandled Interrupt !"
  write "Unhandled Interrupt "
  pushdatos
  mrs tos, ipsr
  bl hexdot
  writeln "!"
  pop {pc}

@ -----------------------------------------------------------------------------
@ Interrupt handler trampoline macro
@ -----------------------------------------------------------------------------

.macro interrupt Name

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "irq-\Name" @ ( -- addr )
  CoreVariable irq_hook_\Name
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =irq_hook_\Name
  bx lr
  .word unhandled  @ Startwert für unbelegte Interrupts   Start value for unused interrupts

irq_vektor_\Name:
  .ifdef m0core
    ldr r0, =irq_hook_\Name
  .else
    movw r0, #:lower16:irq_hook_\Name
    movt r0, #:upper16:irq_hook_\Name
  .endif

  ldr r0, [r0]  @ Cannot ldr to PC directly, as this would require bit 0 to be set accordingly.
  mov pc, r0    @ No need to make bit[0] uneven as 16-bit Thumb "mov" to PC ignores bit 0.
  @ Angesprungene Routine kehrt von selbst zurück...   Code returns itself

@ 3.6.1 ARM-Thumb interworking
@       Thumb interworking uses bit[0] on a write to the PC to determine the CPSR T bit. For 16-bit instructions,
@       interworking behavior is as follows:
@       *     ADD (4) and MOV (3) branch within Thumb state ignoring bit[0].

@       For 32-bit instructions, interworking behavior is as follows:
@       *     LDM and LDR support interworking using the value written to the PC.

.endm


.macro initinterrupt Name, Asmname, Routine

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "irq-\Name" @ ( -- addr )
  CoreVariable irq_hook_\Name
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =irq_hook_\Name
  bx lr
  .word \Routine  @ Startwert für unbelegte Interrupts   Start value for unused interrupts

\Asmname:
  .ifdef m0core
    ldr r0, =irq_hook_\Name
  .else
    movw r0, #:lower16:irq_hook_\Name
    movt r0, #:upper16:irq_hook_\Name
  .endif

  ldr r0, [r0]  @ Cannot ldr to PC directly, as this would require bit 0 to be set accordingly.
  mov pc, r0    @ No need to make bit[0] uneven as 16-bit Thumb "mov" to PC ignores bit 0.
  @ Angesprungene Routine kehrt von selbst zurück...   Code returns itself

.endm

@ -----------------------------------------------------------------------------
@ Common interrupt handlers for all targets
@ -----------------------------------------------------------------------------

interrupt systick
initinterrupt fault, faulthandler, unhandled
initinterrupt collection, nullhandler, unhandled

@ -----------------------------------------------------------------------------
@ Register map for reference purposes
@ -----------------------------------------------------------------------------

@  Zu den Registern, die gesichert werden müssen:  Register map and interrupt entry push sequence:
@  r 0  Wird von IRQ-Einsprung gesichert  Saved by IRQ entry
@  r 1  Wird von IRQ-Einsprung gesichert  Saved by IRQ entry
@  r 2  Wird von IRQ-Einsprung gesichert  Saved by IRQ entry
@  r 3  Wird von IRQ-Einsprung gesichert  Saved by IRQ entry
@
@  r 4    Schleifenindex und Arbeitsregister, wird vor Benutzung gesichert  Is saved by code for every usage
@  r 5    Schleifenlimit und Arbeitsregister, wird vor Benutzung gesichert  Is saved by code for every usage
@  r 6  TOS - müsste eigentlich von sich aus funktionieren                  No need to save TOS
@  r 7  PSP - müsste eigentlich von sich aus funktionieren                  No need to save PSP
@
@  r 8  Unbenutzt  Unused
@  r 9  Unbenutzt  Unused
@  r 10 Unbenutzt  Unused
@  r 11 Unbenutzt  Unused
@  r 12 Unbenutzt, wird von IRQ-Einsprung gesichert  Unused, but saved by IRQ entry
@
@  r 13 = sp
@  r 14 = lr
@  r 15 = pc
