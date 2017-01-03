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

@ -----------------------------------------------------------------------------
@ Bit-position equates (for setting or clearing a single bit)
@ -----------------------------------------------------------------------------

  .equ  BIT0,    0x00000001
  .equ  BIT1,    0x00000002
  .equ  BIT2,    0x00000004
  .equ  BIT3,    0x00000008
  .equ  BIT4,    0x00000010
  .equ  BIT5,    0x00000020
  .equ  BIT6,    0x00000040
  .equ  BIT7,    0x00000080
  .equ  BIT8,    0x00000100
  .equ  BIT9,    0x00000200
  .equ  BIT10,   0x00000400
  .equ  BIT11,   0x00000800
  .equ  BIT12,   0x00001000
  .equ  BIT13,   0x00002000
  .equ  BIT14,   0x00004000
  .equ  BIT15,   0x00008000
  .equ  BIT16,   0x00010000
  .equ  BIT17,   0x00020000
  .equ  BIT18,   0x00040000
  .equ  BIT19,   0x00080000
  .equ  BIT20,   0x00100000
  .equ  BIT21,   0x00200000
  .equ  BIT22,   0x00400000
  .equ  BIT23,   0x00800000
  .equ  BIT24,   0x01000000
  .equ  BIT25,   0x02000000
  .equ  BIT26,   0x04000000
  .equ  BIT27,   0x08000000
  .equ  BIT28,   0x10000000
  .equ  BIT29,   0x20000000
  .equ  BIT30,   0x40000000
  .equ  BIT31,   0x80000000

@ -----------------------------------------------------------------------------
@ Registerdefinitionen
@ Register definitions
@ -----------------------------------------------------------------------------

@ Datenstack mit TOS im Register.
@ Achtung: Diese Register sind recht fest eingebaut, nicht versuchen, diese auszustauschen.
@ Datastack with TOS in register.
@ Never change this registers as they are hardwired in some places.

tos .req r6
psp .req r7

@ -----------------------------------------------------------------------------
@ Datenstack-Makros
@ Macros for Datastack
@ -----------------------------------------------------------------------------

.macro pushdatos @ Push TOS on Datastack - a common, often used factor.

  .ifdef m0core
    subs psp, #4
    str tos, [psp]
  .else
    str tos, [psp, #-4]!
  .endif

.endm

.macro pushdaconst zahl @ Push small constant on Datastack
  pushdatos
  movs tos, #\zahl
.endm

.macro pushdaconstw zahl @ Push medium constant on Datastack
  .ifdef m0core
  pushdatos
  ldr tos, =\zahl
  .else
  pushdatos
  movw tos, #\zahl
  .endif
.endm

.macro pushda register @ Push register on Datastack
  pushdatos
  movs tos, \register
.endm

.macro popda register @ Pop register from Datastack
  movs \register, tos
  ldm psp!, {tos}
.endm

.macro drop
  ldm psp!, {tos}
.endm

.macro nip
  adds psp, #4 @ Move SP to eliminate next element.
.endm

.macro dup
  pushdatos
.endm

.macro swap
  ldr r1,  [psp] @ Load r0 from the stack, no SP change.
  str tos, [psp] @ Replace it with TOS.
  mov tos, r1    @ And vice versa.
.endm

.macro to_r
  push {tos}
  ldm psp!, {tos} @ drop
.endm

.macro r_from
  pushdatos
  pop {tos}
.endm

.macro ddup
  ldr r0, [psp]
  pushdatos
  subs psp, #4
  str r0, [psp]
.endm

.macro ddrop
  adds psp, #4
  drop
.endm

  .ifdef erasedflashcontainszero
    .equ erasedbyte, 0
    .equ erasedhalfword, 0
    .equ erasedword, 0

    .equ writtenhalfword, 0xFFFF
  .else
    .equ erasedbyte,     0xFF
    .equ erasedhalfword, 0xFFFF
    .equ erasedword,     0xFFFFFFFF

    .equ writtenhalfword, 0
  .endif

@ -----------------------------------------------------------------------------
@ Flagdefinitionen
@ Flag definitions
@ -----------------------------------------------------------------------------

.ifdef erasedflashcontainszero
  .equ Flag_invisible,  0x0000  @ Erased Flash needs to give invisible Flags.
  .equ Flag_visible,    0x8000
.else
  .equ Flag_invisible,  0xFFFF
  .equ Flag_visible,    0x0000
.endif

.equ Flag_immediate,  Flag_visible | 0x0010
.equ Flag_inline,     Flag_visible | 0x0020
.equ Flag_immediate_compileonly, Flag_visible | 0x0030 @ Immediate + Inline

.equ Flag_ramallot,   Flag_visible | 0x0080      @ Ramallot means that RAM is reserved and initialised by catchflashpointers for this definition on startup
.equ Flag_variable,   Flag_ramallot|1 @ How many 32 bit locations shall be reserved ?
.equ Flag_2variable,  Flag_ramallot|2

.equ Flag_foldable,   Flag_visible | 0x0040 @ Foldable when given number of constants are available.
.equ Flag_foldable_0, Flag_visible | 0x0040
.equ Flag_foldable_1, Flag_visible | 0x0041
.equ Flag_foldable_2, Flag_visible | 0x0042
.equ Flag_foldable_3, Flag_visible | 0x0043
.equ Flag_foldable_4, Flag_visible | 0x0044
.equ Flag_foldable_5, Flag_visible | 0x0045
.equ Flag_foldable_6, Flag_visible | 0x0046
.equ Flag_foldable_7, Flag_visible | 0x0047

.equ Flag_buffer, Flag_visible | 0x0100
.equ Flag_buffer_foldable, Flag_buffer|Flag_foldable



.ifdef registerallocator

.equ Flag_allocator, Flag_visible | 0x200
.equ Flag_Sprungschlucker, Flag_visible | 0x400
.equ Flag_bxlr, Flag_visible | 0x800
.equ Flag_inlinecache, Flag_visible | 0x1000
.equ Flag_Literator, Flag_visible | 0x2000  @ Tritt nur im Cache für die RA-Vererbung auf !

.else

.equ Flag_Sprungschlucker, 0 @ Deactivated, just to unify source code for both variants.
.equ Flag_bxlr, 0

.equ Flag_opcodable,  Flag_visible | 0x0008

@ Of course, some of those cases are not foldable at all. But this way their bitmask is constructed.

.equ Flag_opcodierbar_Plusminus,         Flag_foldable|Flag_opcodable|1
.equ Flag_opcodierbar_Rechenlogik,       Flag_foldable|Flag_opcodable|2
.equ Flag_opcodierbar_GleichUngleich,    Flag_foldable|Flag_opcodable|3
.equ Flag_opcodierbar_Schieben,          Flag_foldable|Flag_opcodable|4
.equ Flag_opcodierbar_Speicherschreiben, Flag_foldable|Flag_opcodable|5
.equ Flag_opcodierbar_Spezialfall,       Flag_foldable|Flag_opcodable|0

  .ifdef m0core @ No special handling of this on M0
.equ Flag_opcodierbar_Rechenlogik_M3,    Flag_opcodierbar_Rechenlogik
  .else         @ Additional optimisations only available on M3/M4
.equ Flag_opcodierbar_Rechenlogik_M3,    Flag_foldable|Flag_opcodable|6
  .endif

.endif

@ -----------------------------------------------------------------------------
@ Makros zum Bauen des Dictionary
@ Macros for building dictionary
@ -----------------------------------------------------------------------------

@ Für initialisierte Variablen am Ende des RAM-Dictionary
@ For initialised variables at the end of RAM-Dictioanary that are recognized by catchflashpointers
.macro CoreVariable, Name @  Benutze den Mechanismus, um initialisierte Variablen zu erhalten.
  .set CoreVariablenPointer, CoreVariablenPointer - 4
  .equ \Name, CoreVariablenPointer
.endm

.macro DoubleCoreVariable, Name @  Benutze den Mechanismus, um initialisierte Variablen zu erhalten.
  .set CoreVariablenPointer, CoreVariablenPointer - 8
  .equ \Name, CoreVariablenPointer
.endm

@ Für uninitialisierte Variablen am Anfang des RAMs
@ Makro für die gemütliche Speicherreservierung
@ For uninitialised variables at the beginning of RAM.
@ Those are hardwired and not recognized by catchflashpointers, simply to not have to type their RAM addresses manually.
.macro ramallot Name, Menge         @ Für Variablen und Puffer zu Beginn des Rams, die im Kern verwendet werden sollen.
  .equ \Name, rampointer            @ Uninitialisiert.
  .set rampointer, rampointer + \Menge
.endm

@ Makros zum Aufbau des Dictionarykette.
@ Macros for building dictionary chain.
.macro Wortbirne Flags, Name

      .ifdef m0core
        .p2align 2        @ Auf 4 gerade Adressen ausrichten  Align to 4-even locations
      .else
        .p2align 1        @ Auf gerade Adressen ausrichten  Align to even locations
      .endif

      .equ Dictionary_\@, .  @ Labels for a more readable assembler listing only

9:      .word 9f          @ Link einfügen  Insert Link
        .hword \Flags     @ Flags setzen, diesmal 2 Bytes ! Wir haben Platz und Ideen :-)  Flag field, 2 bytes, space for ideas left !

        .byte 8f - 7f     @ Länge des Namensfeldes berechnen  Calculate length of name field
7:      .ascii "\Name"    @ Namen anfügen  Insert name string
8:      .p2align 1        @ 1 Bit 0 - Wieder gerade machen  Realign

      .equ Code_\@, .        @ Labels for a more readable assembler listing only
.endm

@ This one sets the link into user changeable Flash dictionary.
.macro Wortbirne_Kernende Flags, Name

      .ifdef m0core
        .p2align 2        @ Auf 4 gerade Adressen ausrichten  Align to 4-even locations
      .else
        .p2align 1        @ Auf gerade Adressen ausrichten  Align to even locations
      .endif

      .equ Dictionary_\@, .  @ Labels for a more readable assembler listing only

   .ifdef flash16bytesblockwrite
9:      .word FlashDictionaryAnfang + 0x0C @ Insert Link with offset because of alignment issues in LPC1114FN28.
   .else
9:      .word FlashDictionaryAnfang  @ Link einfügen  Insert Link
   .endif
        .hword \Flags     @ Flags setzen, diesmal 2 Bytes ! Wir haben Platz und Ideen :-)  Flag field, 2 bytes, space for ideas left !

        .byte 8f - 7f     @ Länge des Namensfeldes berechnen  Calculate length of name field
7:      .ascii "\Name"    @ Namen anfügen  Insert name string
8:      .p2align 1        @ 1 Bit 0 - Wieder gerade machen  Realign

      .equ Code_\@, .        @ Labels for a more readable assembler listing only
.endm


@ -----------------------------------------------------------------------------
@ Meldungen, hier definiert, damit das Zeilenende leicht geändert werden kann
@ Messages are defined here for simple exchange of line endings.
@ -----------------------------------------------------------------------------

.macro write Meldung
  bl dotgaensefuesschen
        .byte 8f - 7f         @ Compute length of name field.
7:      .ascii "\Meldung"
8:      .p2align 1
.endm

.macro writeln Meldung
  bl dotgaensefuesschen
        .byte 8f - 7f         @ Compute length of name field.
7:      .ascii "\Meldung\n"
8:      .p2align 1
.endm


.ifdef registerallocator

.macro welcome Meldung
  bl dotgaensefuesschen
        .byte 8f - 7f         @ Compute length of name field.
7:      .ascii "Mecrisp-Stellaris RA 2.3.2"
        .ascii "\Meldung\n"
8:      .p2align 1
.endm

.else

.macro welcome Meldung
  bl dotgaensefuesschen
        .byte 8f - 7f         @ Compute length of name field.
7:      .ascii "Mecrisp-Stellaris 2.3.2"
        .ascii "\Meldung\n"
8:      .p2align 1
.endm

.endif

.macro Fehler_Quit Meldung
  bl dotgaensefuesschen
        .byte 8f - 7f         @ Compute length of name field.
7:      .ascii "\Meldung\n"
8:      .p2align 1

  .ifdef m0core
    bl quit
  .else
    b quit
  .endif
.endm

.macro Fehler_Quit_n Meldung
  bl dotgaensefuesschen
        .byte 8f - 7f         @ Compute length of name field.
7:      .ascii "\Meldung\n"
8:      .p2align 1

  b.n quit
.endm
