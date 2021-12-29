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

  .section elfheader, "awx"

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
  .short 1                          @ number of program headers
  .short 40                         @ section header length
  .short 5                          @ number of section headers
  .short 4                          @ section string table offset

@ -----------------------------------------------------------------------------
@ ELF program header, describing how Mecrisp is loaded
@ -----------------------------------------------------------------------------

phdr:
  .int 1                            @ segment type: LOAD
  .int imgorg-imgorg                @ segment offset in image
  .int incipit                      @ virtual load address
  .int incipit                      @ physical load address
  .int datasize                     @ segment length in image
  .int totalsize                    @ segment length in memory
  .int 7                            @ flags: RWX (read write execute)
  .int 65536                        @ memory alignment

@ -----------------------------------------------------------------------------
@ ELF section headers, describing what makes up the image
@ -----------------------------------------------------------------------------

shdr:
  .space 40                         @ section header 0: empty (reserved)

                                    @ section header 1: the ELF headers themselves
                                    @ for easier debugging
  .int elfheaders_str-shstrtab      @ name: elfheaders
  .int 1                            @ type: PROGBITS (program bits)
  .int 3                            @ flags: WRITE ALLOC
  .int imgorg                       @ section begin in memory
  .int imgorg-imgorg                @ section begin in image
  .int elfheaders_end-imgorg        @ section length
  .int 0, 0                         @ section link and info (unused)
  .int 4096                         @ alignment
  .int 0                            @ element size: objects of differing size

                                    @ section header 2: initialised data
  .int mecrisp_str-shstrtab         @ name: mecrisp
  .int 1                            @ type: PROGBITS (program bits)
  .int 7                            @ flags: WRITE ALLOC EXECINSTR
  .int _start                       @ section begin in memory
  .int mecrispoffset                @ section begin in image
  .int Kernschutzadresse-_start     @ section length
  .int 0, 0                         @ section link and info (unused)
  .int 16                           @ alignment
  .int 0                            @ element size: objects of differing sizes

                                    @ section header 3: zeroes
  .int userdictionary_str-shstrtab  @ name: userdictionary
  .int 8                            @ type: NOBITS (no bits)
  .int 3                            @ flags: WRITE ALLOC (keep size(1) happy)
  .int FlashDictionaryAnfang        @ section begin in memory
  .int userdictionaryoffset         @ section begin in image
  .int RamEnde-FlashDictionaryAnfang @  section length
  .int 0, 0                         @ section link and info (unused)
  .int 4                            @ alignment
  .int 0                            @ element size: objects of differing sizes

                                    @ section header 4: section names
                                    @ just to make objdump and size happy
  .int shstrtab_str-shstrtab        @ name: .shtrtab
  .int 3                            @ type: STRTAB (string table)
  .int 0                            @ flags: none
  .int 0                            @ section begin in memory (unused)
  .int shstrtab-imgorg              @ section begin in image
  .int shstrtab_len                 @ section length
  .int 0, 0                         @ section link and info (unused)
  .int 1                            @ alignment
  .int 0                            @ element size: objects of differing size

@ -----------------------------------------------------------------------------
@ ELF section string table, containing the names of sections
@ -----------------------------------------------------------------------------

shstrtab:
  .byte 0                           @ must begin with a NUL
mecrisp_str:
  .string "mecrisp"
userdictionary_str:
  .string "userdictionary"
shstrtab_str:
  .string ".shstrtab"
elfheaders_str:
  .string "elfheaders"

  .equ shstrtab_len,.-shstrtab

  .p2align 4
elfheaders_end:                     @ all good things come to an end
