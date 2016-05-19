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

@ Flash handling for LPC1114FN28.
@ This one has a beasty hardware ECC which operates on 16 byte blocks and cannot be disabled.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "flash-khz" @ ( -- addr )
  CoreVariable core_khz
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =core_khz
  bx lr
  .word 12000 @ 12 000 kHz


hexflashstore_fehler:
  Fehler_Quit "Flash cannot be written twice"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "16flash!" @ Writes 16 Bytes at once into Flash.
hexflashstore: @ ( x1 x2 x3 x4 addr -- ) x1 contains LSB of those 128 bits.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r4, r5, lr}
  @ Check if this goes into core - don't allow that ! No need to check for because of the second check.
  @ Perform write only if desired destination is in erased state...

  movs r0, #15
  ands r0, tos
  beq 1f
    Fehler_Quit "16flash! needs 16-aligned address"

1:ldr r0, [tos]
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #4]
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #8]
  adds r0, #1
  bne hexflashstore_fehler

  ldr r0, [tos, #12]
  adds r0, #1
  bne hexflashstore_fehler

  bl preparesectors   @ Prepare write access
  ldmia psp!, {r3}    @ Fetch data to be written
  ldmia psp!, {r2}
  ldmia psp!, {r1}
  ldmia psp!, {r0}

  @ Reserve 256 Bytes on datastack for the write buffer
  subs psp, #128
  subs psp, #128

  @ Fill reserved space with $FFFFFFFF

  push {r0}

  movs r0, psp @ Start address of area to be filled
  movs r4, #64 @ 4 * 64 = 256 Bytes.
  ldr r5, =0xFFFFFFFF

1:stmia r0!, {r5}
  subs r4, #1
  bne 1b

  pop {r0}

  @ Fill in the desired bytes at their correct location in buffer
  movs r4, #0xFF
  ands r4, tos   @ Mask the low bits of the destination address as offset into the buffer
  adds r4, psp   @ Add the address of the reserved area
  stmia r4!, {r0, r1, r2, r3}

  @ Calculate start address of destination
  movs r5, #0xFF
  bics tos, r5 @ Remove low bits to get the destination aligned to 256 bytes

  @ Prepare IAP entry

  ldr r0, =iap_command

  movs r1, #51 @ Command to write flash
  str r1, [r0]

  str tos, [r0, #4] @ Destination

  str psp, [r0, #8] @ Source

  movs r1, #128
  adds r1, #128 @ Prepare constant 256
  str r1, [r0, #12] @ Set block size to write

  ldr r1, =core_khz
  ldr r1, [r1]
  str r1, [r0, #16] @ Set current clock

  ldr r1, =iap_reply

  ldr r2, =0x1FFF1FF1
  blx r2

  @ Free reserved space on datastack
  adds psp, #128
  adds psp, #128

  drop @ Forget destination address
  pop {r0, r1, r2, r3, r4, r5, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "eraseflash" @ Erases user writeable parts of dictionary
@ -----------------------------------------------------------------------------
  @ No need to save LR as this never returns.
  cpsid i @ Disable interrupts
  bl preparesectors
  bl erasesectors
  writeln "Finished erasing. Reset !"
  bl Restart

@ -----------------------------------------------------------------------------
preparesectors:
  push {lr}
  movs r1, #50 @ Prepare sector for write or erase
  b 1f

@ -----------------------------------------------------------------------------
erasesectors:

  push {lr}
  movs r1, #52 @ Command to erase sectors

1:ldr r0, =iap_command
  str r1, [r0]

  movs r1, #4  @ Start with sector 4  
  str r1, [r0, #4]

  movs r1, #7  @   End with sector 7
  str r1, [r0, #8]

  @ Set system clock - needed for erase.

  ldr r1, =core_khz
  ldr r1, [r1]
  str r1, [r0, #12] @ Set current clock

  ldr r1, =iap_reply

  ldr r2, =0x1FFF1FF1
  blx r2
  pop {pc}
