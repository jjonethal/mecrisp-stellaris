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

@ Routinen für die Interrupthandler, die zur Laufzeit neu gesetzt werden können.
@ Code for interrupt handlers that are exchangeable on the fly

@------------------------------------------------------------------------------
@ Quite uncommon way to handle interrupts in this chip !
@------------------------------------------------------------------------------

  .ltorg            @ Write out all pending constants left
  .p2align 2        @ Align to 4-even location

.equ vector_table_start, .

irq_entry:
  ldr r0, [r0]  @ Cannot ldr to PC directly, as this would require bit 0 to 
  mov pc, r0    @ No need to make bit[0] uneven as 16-bit Thumb "mov" to PC 
  @ Angesprungene Routine kehrt von selbst zurück...   Code returns itself

  @ Instead of the unused locations, I inserted the two opcodes of irq_entry at the beginning of the vector table to save space.

  @ nop                     @ 2000 0000: (Initial return stack pointer, actually in flash)
  @ nop                     @      0002
  nop                       @ 2000 0004: (Reset vector, actually in flash)
  nop                       @      0006
  nop                       @ 2000 0008:
  nop                       @      000A
  ldr r0, =irq_hook_fault   @ 2000 000C: Hardfault
  b.n irq_entry             @      000E

  .ltorg @ Save four bytes space by writing out the constant now.

  @ nop                     @ 2000 0010:
  @ nop                     @      0012
  nop                       @ 2000 0014:
  nop                       @      0016
  nop                       @ 2000 0018:
  nop                       @      001A
  nop                       @ 2000 001C:
  nop                       @      001E

  nop                       @ 2000 0020:
  nop                       @      0022
  nop                       @ 2000 0024:
  nop                       @      0026
  nop                       @ 2000 0028:
  nop                       @      002A
  ldr r0, =irq_hook_collection  @  002C: SVCall
  b.n irq_entry             @      002E

  nop                       @ 2000 0030:
  nop                       @      0032
  nop                       @ 2000 0034:
  nop                       @      0036
  ldr r0, =irq_hook_collection  @  0038: PendSV
  b.n irq_entry             @      003A
  ldr r0, =irq_hook_systick @ 2000 003C: Systick
  b.n irq_entry             @      003E


  ldr r0, =irq_hook_scu0    @ 2000 0040: 0  irq-scu0
  b.n irq_entry             @      0042
  ldr r0, =irq_hook_scu1    @ 2000 0044: 1  irq-scu1
  b.n irq_entry             @      0046
  nop                       @ 2000 0048: 2  nc
  nop                       @      004A
  ldr r0, =irq_hook_eru0    @ 2000 004C: 3  irq-eru0
  b.n irq_entry             @      004E

  ldr r0, =irq_hook_eru1    @ 2000 0050: 4  irq-eru1
  b.n irq_entry             @      0052
  ldr r0, =irq_hook_eru2    @ 2000 0054: 5  irq-eru2
  b.n irq_entry             @      0056
  ldr r0, =irq_hook_eru3    @ 2000 0058: 6  irq-eru3
  b.n irq_entry             @      005A
  nop                       @ 2000 005C: 7  nc
  nop                       @      005E

  nop                       @ 2000 0060: 8  nc
  nop                       @      0062
  ldr r0, =irq_hook_usi0    @ 2000 0064: 9  irq-usi0
  b.n irq_entry             @      0066
  ldr r0, =irq_hook_usi1    @ 2000 0068:10  irq-usi1
  b.n irq_entry             @      006A
  ldr r0, =irq_hook_usi2    @ 2000 006C:11  irq-usi2
  b.n irq_entry             @      006E

  ldr r0, =irq_hook_usi3    @ 2000 0070:12  irq-usi3
  b.n irq_entry             @      0072
  ldr r0, =irq_hook_usi4    @ 2000 0074:13  irq-usi4
  b.n irq_entry             @      0076
  ldr r0, =irq_hook_usi5    @ 2000 0078:14  irq-usi5
  b.n irq_entry             @      007A
  ldr r0, =irq_hook_adc0    @ 2000 007C:15  irq-adc0
  b.n irq_entry             @      007E

  ldr r0, =irq_hook_adc1    @ 2000 0080:16  irq-adc1
  b.n irq_entry             @      0082
  nop                       @ 2000 0084:17  nc
  nop                       @      0086
  nop                       @ 2000 0088:18  nc
  nop                       @      008A
  nop                       @ 2000 008C:19  nc
  nop                       @      008E

  nop                       @ 2000 0090:20  nc
  nop                       @      0092
  ldr r0, =irq_hook_ccu0    @ 2000 0094:21  irq-ccu0
  b.n irq_entry             @      0096
  ldr r0, =irq_hook_ccu1    @ 2000 0098:22  irq-ccu1
  b.n irq_entry             @      009A
  ldr r0, =irq_hook_ccu2    @ 2000 009C:23  irq-ccu2
  b.n irq_entry             @      009E

  ldr r0, =irq_hook_ccu3    @ 2000 00A0:24  irq-ccu3
  b.n irq_entry             @      00A2
                            @ 2000 00A4:25  nc
                            @      00A6
                            @ 2000 00A8:26  nc
                            @      00AA
                            @ 2000 00AC:27  nc
                            @      00AE

                            @ 2000 00B0:28  nc
                            @      00B2
                            @ 2000 00B4:29  nc
                            @      00B6
                            @ 2000 00B8:30  nc
                            @      00BA
                            @ 2000 00BC:31  nc
                            @      00BE

  .ltorg @ Write out all constants necessary for the "vector table" which is to be copied into RAM

.equ vector_table_end, .

.equ vector_table_length, vector_table_end - vector_table_start

@ Define the usual Forth hooks for all the interrupts in the table.

interrupt scu0
interrupt scu1
interrupt eru0
interrupt eru1
interrupt eru2
interrupt eru3
interrupt usi0
interrupt usi1
interrupt usi2
interrupt usi3
interrupt usi4
interrupt usi5
interrupt adc0
interrupt adc1
interrupt ccu0
interrupt ccu1
interrupt ccu2
interrupt ccu3

@------------------------------------------------------------------------------
