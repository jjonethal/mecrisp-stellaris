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

@ Bootrom wrappers are written by Jan Bramkamp.

@ As flash dictionary is mirrored in RAM on Raspberry Pico, directly write to the locations.

@ -----------------------------------------------------------------------------
   Wortbirne Flag_visible, "cflash!" @ ( x Addr -- )
c_flashkomma:
@ -----------------------------------------------------------------------------
  b.n cstore

@ -----------------------------------------------------------------------------
   Wortbirne Flag_visible, "hflash!" @ ( x Addr -- )
h_flashkomma:
@ -----------------------------------------------------------------------------
  b.n hstore

@ -----------------------------------------------------------------------------
   Wortbirne Flag_visible, "rom-code" @ ( code -- addr )
rom_code:
@ -----------------------------------------------------------------------------
   push {r0, r1, r2, r3, lr}

   movs r2, #0x00000000  @ All fields are within reach from 0x0000
   ldrh r0, [r2, #0x14]  @ Pass the ROM table as first argument
   movs r1, tos          @ and the code as second argument
   ldrh r2, [r2, #0x18]  @ Call the table lookup function from the rom
   blx  r2
   movs tos, r0

   pop {r0, r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "rom-data" @ ( code -- addr )
@ -----------------------------------------------------------------------------
   push {lr}

   movs r2, #0x00000000  @ All fields are within reach from 0x0000
   ldrh r0, [r2, #0x16]  @ Pass the ROM table as first argument
   movs r1, tos          @ and the code as second argument
   ldrh r2, [r2, #0x18]  @ Call the table lookup function from the rom
   blx  r2
   movs tos, r0

   pop {pc}

@------------------------------------------------------------------------------
@ Restore all QSPI pad controls to their default state,
@ and connect the SSI to the QSPI pads.

   Wortbirne Flag_visible, "connect-flash" @ ( -- )
connect_flash:
@------------------------------------------------------------------------------
   push {tos, lr}
   ldr          tos, ='I+('F<<8)
   bl           rom_code
   blx          tos
   pop {tos, pc}

@------------------------------------------------------------------------------
@ Configure the SSI to generate a standard 03h serial read command,
@ with 24 address bits, upon each XIP access. This is a very slow XIP
@ configuration, but is very widely supported.
@ Mecrisp-Stellaris doesn't suffer too badly from this because it copies
@ the flash into SRAM.

   Wortbirne Flag_visible, "enter-xip" @ ( -- )
enter_xip:
@------------------------------------------------------------------------------
   push {tos, lr}
   ldr          tos, ='C+('X<<8)
   bl           rom_code
   blx          tos
   pop {tos, pc}

@------------------------------------------------------------------------------
@ First set up the SSI for serial-mode operations, then issue the fixed XIP
@ exit sequence described in Section 2.8.2.2 of the RP2040 datasheet.
@ Note that the BootROM code uses the IO forcing logic to drive the CS pin,
@ which must be cleared before returning the SSI to XIP mode
@ (e.g. by a call to flush-cache).

   Wortbirne Flag_visible, "exit-xip" @ ( -- )
exit_xip:
@------------------------------------------------------------------------------
   push {tos, lr}
   ldr          tos, ='E+('X<<8)
   bl           rom_code
   blx          tos
   pop {tos, pc}

@------------------------------------------------------------------------------
@ Erase a count bytes, starting at addr (offset from start of flash).
@ Optionally, pass a block erase command e.g. D8h block erase, and the size of
@ the block erased by this command - this function will use the larger block
@ erase where possible, for much higher erase speed.
@ The address must be aligned to a 4096-byte sector,
@ and count must be a multiple of 4096 bytes
@
@ Example:
@   connect-flash exit-xip
@   $10000 $1000 $10000 $d8 erase-range
@   flush-cache enter-xip

   Wortbirne Flag_visible, "erase-range" @ ( addr count size cmd -- )
erase_range:
@------------------------------------------------------------------------------
   push {lr}

   movs r3, tos    @ block command              ( addr count size cmd )
   ldm  psp!, {r2} @ block size                 ( addr count cmd )
   ldm  psp!, {r1} @ byte count                 ( addr cmd )
   ldm  psp!, {r0} @ offset from start of flash ( cmd )

   ldr          tos, ='R+('E<<8)
   bl           rom_code
   blx          tos

   drop
   pop  {pc}

@------------------------------------------------------------------------------
@ Program data to a range of flash addresses starting at addr
@ (offset from the start of flash) and count bytes in size.
@ addr must be aligned to a 256-byte boundary,
@ and count must be a multiple of 256
@
@ Example:
@   connect-flash exit-xip
@   $10000 here 256 program-range
@   flush-cache enter-xip

   Wortbirne Flag_visible, "program-range" @ ( addr data count -- )
program_range:
@------------------------------------------------------------------------------
   push {lr}

   movs r2, tos    @ count
   ldm  psp!, {r1} @ data
   ldm  psp!, {r0} @ addr

   ldr          tos, ='R+('P<<8)
   bl           rom_code
   blx          tos

   drop
   pop  {pc}

@------------------------------------------------------------------------------
@ Flush and enable the XIP cache. Also clears the IO forcing on QSPI CSn,
@ so that the SSI can drive the flash chip select as normal

   Wortbirne Flag_visible, "flush-cache" @ ( -- )
flush_cache:
@------------------------------------------------------------------------------
   push {tos, lr}
   ldr          tos, ='F+('C<<8)
   bl           rom_code
   blx          tos
   pop {tos, pc}

@ @------------------------------------------------------------------------------
@ @ Reboots into the USB bootloader with both protocols enabled
@ @ and USB activity indication on PIN25 (the user LED)
@ @
@ @ Works on macOS Catalina, but reported to be unusable on Linux.
@ @ Uncomment to try.
@
@    Wortbirne Flag_visible, "usb-boot" @ ( -- )
@ usb_boot:
@ @------------------------------------------------------------------------------
@    ldr  r6, ='U+('B<<8)
@    bl   rom_code
@    movs r0, #1
@    lsls r0, #25
@    movs r1, #0
@    mov  pc, r6

@------------------------------------------------------------------------------
   Wortbirne Flag_foldable_1, "image>spi-offset" @ ( u -- addr )
image2spioffset:                                 @ Calculate start address for image in SPI flash
@------------------------------------------------------------------------------

  ldr r0, =0x1B000 @ Every image is $1B000 bytes in size
  ldr r1, =0x6000 @ and follows after the Forth core, which is from $1000 to $6000 in SPI flash.
  muls tos, r0    @ Remember: The first 4 kb contain the boot block and padding.
  adds tos, r1

  bx lr

@------------------------------------------------------------------------------
   Wortbirne Flag_visible, "erase#" @ ( u -- )
eraseimage:                         @ Erase an image from the SPI flash
@------------------------------------------------------------------------------
  push {lr}

  bl connect_flash
  bl exit_xip

  bl image2spioffset
  pushdaconstw 0x1B000
  pushdaconstw 0x1000
  pushdaconst  0x20
  bl erase_range

  b.n restore_xip_intern

@------------------------------------------------------------------------------
   Wortbirne Flag_visible, "save#" @ ( u -- )
save:                              @ Save current dictionary contents into SPI flash image
@------------------------------------------------------------------------------

  push {lr}

  dup
  bl eraseimage

  bl connect_flash
  bl exit_xip

  bl image2spioffset         @ Source address
  pushdaconstw 0x20005000     @ Destination address
  pushdaconstw 0x1B000          @ 108 kb
  bl program_range

restore_xip_intern:
  bl flush_cache
  bl enter_xip

  pop {pc}

@------------------------------------------------------------------------------
   Wortbirne Flag_visible, "load#" @ ( u -- )
                                   @ Load dictionary image from SPI flash
@------------------------------------------------------------------------------

  @ No need to push lr, as this never returns.

  bl image2spioffset
  ldr r0, =0x10000000
  adds tos, r0               @ Source address
  pushdaconstw 0x20005000     @ Destination address
  pushdaconstw 0x1B000          @ 108 kb
  bl move

  bl Reset

@------------------------------------------------------------------------------
   Wortbirne Flag_visible, "save" @ ( -- )
                                  @ Save current dictionary contents in image 0 which is loaded automatically on boot
@------------------------------------------------------------------------------
  pushdaconst 0
  b.n save

@------------------------------------------------------------------------------
   Wortbirne Flag_visible, "new" @ ( -- )
                                 @ Clear the dictionary and restart
@------------------------------------------------------------------------------
  @ No need to push lr, as this never returns.

  ldr r0, =0x20005000
  ldr r1, =0x1B000
  ldr r2, =0xFFFFFFFF

1:subs r1, #4
  str r2, [r0, r1]
  bne 1b

  bl Reset

@------------------------------------------------------------------------------
   Wortbirne Flag_visible, "restart" @ ( -- )
@------------------------------------------------------------------------------
   bl Reset
