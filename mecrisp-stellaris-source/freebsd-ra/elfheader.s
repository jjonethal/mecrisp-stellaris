@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2019  Robert Clausecker
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

@ ELF header
@ For hosted environments, Mecrisp maintains its own ELF header.
@ This allows us to patch the header with a larger initialised memory
@ image when we want to dump it back to disk.

  .section elfheader, "a"

imgorg: @ program image origin
	@ also, where the ELF header is found

@ -----------------------------------------------------------------------------
@ An ELF header, loaded to the beginning of the memory image
@ -----------------------------------------------------------------------------

  .byte 0x7f,'E','L','F'            @ ELF magic number
  .byte 1                           @ ELF class: 32 bit
  .byte 1                           @ byte order: little endian
  .byte 1                           @ ELF version: 1
@ .byte 3                           @ ABI: GNU/Linux
  .byte 9                           @ ABI: FreeBSD
  .byte 0                           @ ABI version: 0
  .space 7                          @ padding
  .short 2                          @ ELF type: executable
  .short 40                         @ architecture: ARM
  .int 1                            @ ELF version: 1 (again)
  .int _start                       @ entry point
  .int phdr-imgorg                  @ program header table offset
  .int shdr-imgorg                  @ section header table offset
  .int 0x5000200                    @ flags: ???
  .short 52                         @ ELF header length
  .short 32                         @ program header length
  .short 3                          @ number of program headers
  .short 40                         @ section header length
  .short 8                          @ number of section headers
  .short 6                          @ section string table offset

@ -----------------------------------------------------------------------------
@ ELF program header, describing how Mecrisp is loaded
@ -----------------------------------------------------------------------------

phdr:

  @ program header 0: Forth kernel (write protected)
  .int 1                            @ segment type: LOAD
  .int imgorg-imgorg                @ segment offset in image
  .int incipit                      @ virtual load address
  .int incipit                      @ physical load address
  .int kernsize                     @ segment length in image
  .int kernsize                     @ segment length in memory
  .int 5                            @ flags: R-X (read execute)
  .int 4096                         @ memory alignment

  @ program header 1: dictionaries (not protected)
  .int 1                            @ segment type: LOAD
  .int userdictionaryoffset         @ segment offset in image
  .int FlashDictionaryAnfang        @ virtual load address
  .int FlashDictionaryAnfang        @ physical load address
  .int 0                            @ segment length in image
  .int RamEnde-Kernschutzadresse    @ segment length in memory
  .int 7                            @ flags: RWX (read write execute)
  .int 4096                         @ memory alignment

  @ program header 2: note section
  .int 4                            @ segment type: NOTE
  .int noteorg-imgorg               @ segment offset in image
  .int noteorg                      @ virtual load address
  .int noteorg                      @ physical load address
  .int notelen                      @ segment length in image
  .int notelen                      @ segment length in memory
  .int 4                            @ flags: R (read)
  .int 4                            @ memory alignment

@ -----------------------------------------------------------------------------
@ ELF section headers, describing what makes up the image
@ -----------------------------------------------------------------------------

shdr:
  .space 40                         @ section header 0: empty (reserved)

                                    @ section header 1: the ELF headers themselves
                                    @ for easier debugging
  .int elfheaders_str-shstrtab      @ name: elfheaders
  .int 1                            @ type: PROGBITS (program bits)
  .int 2                            @ flags: ALLOC
  .int imgorg                       @ section begin in memory
  .int imgorg-imgorg                @ section begin in image
  .int elfheaders_end-imgorg        @ section length
  .int 0, 0                         @ section link and info (unused)
  .int 4096                         @ alignment
  .int 0                            @ element size: objects of differing size

                                    @ section header 2: Forth kernel
  .int mecrisp_str-shstrtab         @ name: kernel
  .int 1                            @ type: PROGBITS (program bits)
  .int 6                            @ flags: WRITE ALLOC EXECINSTR
  .int _start                       @ section begin in memory
  .int mecrispoffset                @ section begin in image
  .int Kernende-_start              @ section length
  .int 0, 0                         @ section link and info (unused)
  .int 4                            @ alignment
  .int 0                            @ element size: objects of differing sizes

                                    @ section header 3: allocated flash
  .int flashused_str-shstrtab       @ name: flash.used
  .int 1                            @ type: PROGBITS (program bits)
  .int 3                            @ flags: WRITE ALLOC (have size(1) treat this as data)
  .int FlashDictionaryAnfang        @ section begin in memory
  .int userdictionaryoffset         @ section begin in image
  .int 0                            @  section length
  .int 0, 0                         @ section link and info (unused)
  .int 4                            @ alignment
  .int 0                            @ element size: objects of differing sizes

                                    @ section header 4: free flash
  .int flashfree_str-shstrtab       @ name: flash.free
  .int 8                            @ type: NOBITS (no bits)
  .int 3                            @ flags: WRITE ALLOC (have size(1) treat this as bss)
  .int FlashDictionaryAnfang        @ section begin in memory
  .int userdictionaryoffset         @ section begin in image
  .int FlashDictionaryEnde-FlashDictionaryAnfang @  section length
  .int 0, 0                         @ section link and info (unused)
  .int 4                            @ alignment
  .int 0                            @ element size: objects of differing sizes

                                    @ section header 5: RAM dictionary
  .int ramdict_str-shstrtab         @ name: ramdict
  .int 8                            @ type: NOBITS (no bits)
  .int 3                            @ flags: WRITE ALLOC (have size(1) treat this as bss)
  .int RamAnfang                    @ section begin in memory
  .int userdictionaryoffset+(RamAnfang-FlashDictionaryAnfang) @ section begin in image
  .int RamEnde-RamAnfang            @  section length
  .int 0, 0                         @ section link and info (unused)
  .int 4                            @ alignment
  .int 0                            @ element size: objects of differing sizes

                                    @ section header 6: section names
                                    @ just to make objdump and size happy
  .int shstrtab_str-shstrtab        @ name: .shstrtab
  .int 3                            @ type: STRTAB (string table)
  .int 2                            @ flags: none
  .int shstrtab                     @ section begin in memory
  .int shstrtab-imgorg              @ section begin in image
  .int shstrtab_len                 @ section length
  .int 0, 0                         @ section link and info
  .int 1                            @ alignment
  .int 0                            @ element size: objects of differing size

                                    @ section header 7: note section
                                    @ for telling FreeBSD that we need W+X mappings
  .int note_str-shstrtab            @ name: .note
  .int 7                            @ type: NOTE (note)
  .int 2                            @ flags: none
  .int noteorg                      @ section begin in memory
  .int noteorg-imgorg               @ section begin in image
  .int notelen                      @ section length
  .int 0, 0                         @ section link and info
  .int 4                            @ alignment
  .int 0                            @ element size: objects of differing sizes

@ -----------------------------------------------------------------------------
@ ELF section string table, containing the names of sections
@ -----------------------------------------------------------------------------

shstrtab:
  .byte 0                           @ must begin with a NUL
elfheaders_str:
  .string "elfheaders"
mecrisp_str:
  .string "kernel"
flashused_str:
  .string "flash.used"
flashfree_str:
  .string "flash.free"
ramdict_str:
  .string "ramdict"
shstrtab_str:
  .string ".shstrtab"
note_str:
  .string ".note"
  .equ shstrtab_len,.-shstrtab

  .balign 4
noteorg:
  @ first note: tell FreeBSD which security features we are compatible with
  @ even if not needed, the presence of this note means that elfctl(1) can
  @ overwrite it later, permitting more flexibility for the user.
  @ We disable the PROTMAX feature (so protect/unprotect work) and WXNEEDED
  @ (so we can run code we compiled).
  .int 1f-0f                        @ name size
  .int 4                            @ description size
  .int 4                            @ NT_FREEBSD_FEATURE_CTL
0:.string "FreeBSD"                 @ name: FreeBSD
1:.balign 4
  .int 0x0000000a                   @ description: WXNEEDED, PROTMAX_DISABLE

 @ second note: tell FreeBSD which level of system calls we are compatible
 @ with.  I've set this one to FreeBSD 12 which is the oldest kernel version
 @ in support.
 .int 1f-0f                         @ name size
 .int 4                             @ description size
 .int 1                             @ NT_FREEBSD_ABI_TAG
0:.string "FreeBSD"                 @ name: FreeBSD
1:.balign 4
  .int 1200050                      @ description: FreeBSD 12 when armv7 was introduced
	.equ notelen, .-noteorg


elfheaders_end:                     @ all good things come to an end
