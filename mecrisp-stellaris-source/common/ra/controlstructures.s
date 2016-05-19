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

@ Sprünge, Helferlein und Kontrollstrukturen
@ Jumps, Utilities and Control Structures

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "cjump," @ Fügt einen bedingten Sprung ein. Write a conditional jump into dictionary
cjumpgenerator: @ ( Adresse-der-Opcodelücke Sprungziel Bitmaske -- )
                @ ( Address-of-hole-for-jump Target Bitmask -- )
@------------------------------------------------------------------------------
  popda r2 @ Bitmaske    Bitmask for jump condition
  popda r1 @ Sprungziel  Target
  @ popda r0 @ Adresse-der-Opcodelücke - bleibt auf dem Stack  Hole to fill in opcode - keep that on stack

  @ Calculate jump offset.
  subs r3, r1, tos @ Differenz aus Lücken-Adresse und Sprungziel bilden  Calculate relative jump offset
  subs r3, #4      @ Da der aktuelle Befehl noch läuft und es komischerweise andere Offsets beim ARM gibt.  Current instruction still running...

  @ 8 Bits für die Sprungweite mit Vorzeichen -
  @ also habe ich 7 freie Bits, das oberste muss mit dem restlichen Vorzeichen übereinstimmen.

  @ Short conditional B.. opcodes support 8 Bits jump range - one of that for sign.
  @ Check if opcodable range is enough to reach target:

  ldr r1, =0xFFFFFF01   @ 7 Bits frei
  ands r1, r3
  cmp r1, #0  @ Wenn dies Null ergibt, positive Distanz ok.
  beq 1f

  ldr r0, =0xFFFFFF00
  cmp r1, r0
  beq 1f  @ Wenn es gleich ist: Negative Distanz ok.
    @ Ansonsten ist die Sprungdistanz einfach zu groß.
jump_too_far:
    Fehler_Quit "Jump too far"
1:

  @ Generate proper jump opcode:
  asrs r3, #1 @ Schieben, da die Sprünge immer auf geraden Adressen beginnen und enden.  Shift one bit out as jumps always have an even offset
  movs r1, #0xFF @ Genau 8 Bits Sprungmaske.  Exactly 8 Bits available -
  ands r3, r1    @ Ausschnitt anwenden          mask them to clip sign bits

  orrs r3, r2    @ Sprungbedingung und den Rest des Opcodes hinzufügen  Or together with jump condition
  movs r0, tos  @ Adresse-der-Opcodelücke in r0 holen                    Exchange registers
  movs tos, r3  @ Sprungopcode stattdessen hineinlegen

sprungbefehl_einfuegen: @ strh r3, [r0] over h, to handle Flash writes
  push {lr}
    @ Opcode auf dem Stack, Adresse in r0
    @ Dictionary-Pointer verbiegen:
      @ Dictionarypointer sichern
      ldr r2, =Dictionarypointer
      ldr r3, [r2] @ Alten Dictionarypointer auf jeden Fall bewahren

      str r0, [r2] @ Dictionarypointer umbiegen
      bl hkomma    @ Opcode einfügen
      str r3, [r2] @ Dictionarypointer wieder zurücksetzen.
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "jump," @ Fügt einen unbedingten Sprung ein.  Write an unconditional jump into dictionary
jumpgenerator: @ ( Adresse-der-Opcodelücke Sprungziel -- )
               @ ( Address-of-hole-for-jump Target -- )
@------------------------------------------------------------------------------
  popda r1 @ Sprungziel  Target
  popda r0 @ Adresse-der-Opcodelücke  Hole to fill in opcode

  subs r3, r1, r0 @ Differenz aus Lücken-Adresse und Sprungziel bilden  Calculate relative jump offset
  subs r3, #4     @ Da der aktuelle Befehl noch läuft und es komischerweise andere Offsets beim ARM gibt.   Current instruction still running...

  @ 11 Bits für die Sprungweiter mit Vorzeichen -
  @ also habe ich 10 freie Bits, das oberste muss mit dem restlichen Vorzeichen übereinstimmen.

  @ Short unconditional B opcodes support 11 Bits jump range - one of that for sign.
  @ Check if opcodable range is enough to reach target:

  ldr r1, =0xFFFFF801  @ 10 Bits frei
  ands r1, r3
  cmp r1, #0  @ Wenn dies Null ergibt, positive Distanz ok.
  beq 1f

  ldr r2, =0xFFFFF800
  cmp r1, r2
  bne.n jump_too_far @ Wenn es gleich ist: Negative Distanz ok.

1:

  asrs r3, #1 @ Schieben, da die Sprünge immer auf geraden Adressen beginnen und enden. Shift one bit out as jumps always have an even offset
  ldr r2, =0x7FF @ Genau 11 Bits Sprungmaske.  Exactly 11 Bits available -
  ands r3, r2     @ Ausschnitt anwenden          mask them to clip sign bits

  .ifdef m0core
    ldr r2, =0xE000
    orrs r3, r2
  .else
    orrs r3, 0xE000  @ Rest des Opcodes hinzufügen  Or together with B opcode
  .endif
  pushda r3
  b.n sprungbefehl_einfuegen @  Befehl einfügen. strh r3, [r0] over h, to handle Flash writes

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "here" @ ( -- addr ) Gives Dictionarypointer
here: @ Gibt den Dictionarypointer zurück
@ -----------------------------------------------------------------------------
  pushdatos    @ Platz auf dem Datenstack schaffen
  ldr tos, =Dictionarypointer
  ldr tos, [tos] @ Hole den Dictionarypointer
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "flashvar-here" @ ( -- a-addr ) Gives RAM management pointer
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =VariablenPointer
  ldr tos, [tos]
  bx lr

@------------------------------------------------------------------------------
@ Verschiedene Sprünge, die von den Kontrollstrukturen gebracht werden.
@ Some jump primitives that are useful for building control structures
@------------------------------------------------------------------------------

nullprobekomma: @ Write code for comparing TOS to zero.
  push {lr}
  pushdaconstw 0x2e00 @ cmp tos, #0
  bl hkomma
  pushdaconstw 0xcf40 @ drop
  bl hkomma
  pop {pc}

branch_r:     @ ( -- Sprungziel )  Einleitung bedingter und unbedingter Rückwärtssprung
    b.n here  @ ( -- Target )      Intro of conditional and unconditional backwards jump

r_branch_jne: @ ( Sprungziel -- )  Abschluss besonderer bedingter Rückwärtssprung für loop
  push {lr}   @ ( Target -- )      Finalisation of special conditional backwards jump for loop
  bl branch_v @ ( pushda Dictionaryinter und 2 allot )
  swap
  pushdaconstw 0xD100 @ Opcode für den bedingten Sprung bne  Opcode for conditional jump BNE
  bl cjumpgenerator
  pop {pc}

r_branch_jvc: @ ( Sprungziel -- )  Abschluss besonderer bedingter Rückwärtssprung bei Überlauf für +loop
  push {lr}   @ ( Target -- )      Finalisation of conditional backwards jump on overflow for +loop
  bl branch_v @ ( pushda Dictionaryinter und 2 allot )
  swap
  pushdaconstw 0xD700 @ Opcode für den bedingten Sprung bvc  Opcode for conditional jump BVC, used for +loop
  bl cjumpgenerator
  pop {pc}

r_nullbranch: @ ( Sprungziel -- )  Abschluss bedingter Rückwärtssprung
  push {lr}   @ ( Target -- )      Finalisation of conditional backwards jump
  bl nullprobekomma
  bl branch_v @ ( pushda Dictionaryinter und 2 allot )
  swap
  pushdaconstw 0xD000 @ Opcode für den bedingten Sprung beq  Opcode for conditional jump BEQ
  bl cjumpgenerator
  pop {pc}

r_branch:     @ ( Sprungziel -- )  Abschluss unbedingter Rückwärtssprung
  push {lr}   @ ( Target -- )      Finalisation of unconditional backwards jump
  bl branch_v @ ( pushda Dictionaryinter und 2 allot )
  swap
  bl jumpgenerator
  pop {pc}


nullbranch_v: @ ( -- Adresse-für-Sprungbefehl )  Einleitung bedingter Vorwärtssprung
  push {lr}   @ ( -- Address-for-Opcode )        Intro of conditional forward jump
  bl nullprobekomma
  bl here
  pushdaconst 2 @ Platz für die Opcodelücke schaffen  Allot space for filling in Opcode later
  bl allot
  pop {pc}

branch_v:     @ ( -- Adresse-für-Sprungbefehl )  Einleitung unbedingter Vorwärtssprung
  push {lr}   @ ( -- Address-for-Opcode )        Intro of unconditional forward jump
  bl here
  pushdaconst 2 @ Platz für die Opcodelücke schaffen  Allot space for filling in Opcode later
  bl allot
  pop {pc}


v_branch:      @ ( Adresse-für-Sprungbefehl -- ) Abschluss unbedingter Vorwärtssprung
  push {lr}    @ ( Address-for-Opcode -- )       Finalisation of unconditional forward jump
  bl here @ Sprungziel auf den Stack legen  Put target for jump on datastack
  bl jumpgenerator
  pop {pc}

v_nullbranch:  @ ( Adresse-für-Sprungbefehl -- ) Abschluss bedingter Vorwärtssprung
  push {lr}    @ ( Address-for-Opcode -- )       Finalisation of conditional forward jump
  bl here @ Sprungziel auf den Stack legen  Put target for jump on datastack
  pushdaconstw 0xD000 @ Opcode für den bedingten Sprung beq  Opcode for conditional jump BEQ
  bl cjumpgenerator
  pop {pc}

v_casebranch:  @ ( Adresse-für-Sprungbefehl -- ) Abschluss besonderer bedingter Vorwärtssprung für case
  push {lr}    @ ( Address-for-Opcode -- )       Finalisation of special conditional forward jump for case
  bl here @ Sprungziel auf den Stack legen  Put target for jump on datastack
  pushdaconstw 0xD100 @ Opcode für den bedingten Sprung bne  Opcode for conditional jump BNE
  bl cjumpgenerator
  pop {pc}


@------------------------------------------------------------------------------
allocator_nullsprungprobe:
@------------------------------------------------------------------------------
  push {lr}

      @ Der TOS-Register kann direkt untersucht und am Ende aus dem RA abgemeldet werden.
      @ Aufräumen am Ende, da wir zwei unterschiedliche Zweige anlegen werden.

      @ Benötige also zwei Elemente: Eins, um den Vergleich anzulegen und eins, welches nachrücken soll.

  bl expect_one_element @ Mindestens ein Element präparieren.

  bl tidyup_register_allocator_5os @ Alle anderen in Richtung des kanonischen Stacks putzen und aufräumen.
  bl tidyup_register_allocator_4os
  bl tidyup_register_allocator_3os

  ldr r1, [r0, #offset_state_nos]
  cmp r1, #constant
  bne 1f
    bl expect_nos_in_register @ Falls NOS eine Konstante ist, muss sie nun geladen werden
1:bl expect_tos_in_register @ TOS wird beprobt und muss im Register sein

  @ Vergleiche TOS mit Null - dafür muss eine Probe geschrieben werden !

  pushdaconstw 0x2800 @ cmp r0, #0
  lsls r1, #8 @ Register passend schieben
  orrs tos, r1
  bl hkomma

  bl eliminiere_tos @ Wirf das gerade verglichene Element fort.

  bl tidyup_register_allocator @ Das nachrückende Element ist bereits ein Register - so kann hier nur noch ein MOV-Opcode geschrieben werden, der die Flags erhält.

  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "then"
  @ ( Adresse-für-Sprung Opcode"0" | Adresse-für-Sprung 5 -- )
  @ ( Address-for-Jump   Opcode"0" | Address-for-Jump 5 --)
struktur_then:
@------------------------------------------------------------------------------
  cmp tos, #5 @ Unbedingten Vorwärtssprung einfügen
  bne 1f
    drop @ ( Sprunglücke )
    b.n v_branch @ Abschluss unbedingter Vorwärtssprung  Fill in unconditional forward jummp

1:uxtb r1, tos @ Das unterste Byte muss als Strukturerkennung 0 enthalten.
  cmp r1, #0 @ Bedingten Vorwärtssprung einfügen
  bne.n strukturen_passen_nicht
    @ ( Sprunglücke Opcode )
    push {lr}
    bl here @ Sprungziel auf den Stack legen  Put target for jump on datastack
    swap
    bl cjumpgenerator @ Abschluss bedingter Vorwärtssprung v_nullbranch  Fill in conditional forward jump
    pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "else"
@------------------------------------------------------------------------------
  push {lr}
  bl struktur_ahead
  bl dswap
  bl struktur_then
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly|Flag_allocator|Flag_Sprungschlucker, "if"
struktur_if: @ ( -- Adresse-für-Sprung Opcode"0" )
             @ ( -- Address-for-Jump   Opcode"0" )
@------------------------------------------------------------------------------
  push {lr}
  bl nullbranch_v
  pushdaconstw 0xD000 @ Opcode für den bedingten Sprung beq  Opcode for conditional jump BEQ
  pop {pc}            @ Strukturerkennung  Structure matching "0" already in opcode

struktur_if_allokator:
  push {lr} @ Spezialeinsprung des Registerallokators:

  bl push_lr_nachholen

  bl eliminiere_tos_wenn_bmi

  ldr r1, [r0, #offset_sprungtrampolin]
  cmp r1, #0
  beq 1f

    push {r1} @ Der Sprungopcode liegt schon bereit !
    bl tidyup_register_allocator @ Den kanonischen Stack wieder herstellen. In diesem Fall sind alle Elemente in Registern oder auf dem Stack, so dass dabei die Flags erhalten bleiben.
                                 @ Außerdem wird das Sprungtrampolin dabei gelöscht. Fein !

    bl branch_v   @ Sprunglücke erschaffen

    pushdatos     @ Opcode bereitlegen mit Strukturerkennung "0"
    pop {tos, pc}

1:bl allocator_nullsprungprobe
  bl here
  pushdaconst 2 @ Platz für die Opcodelücke schaffen  Allot space for filling in Opcode later
  bl allot

  pushdaconstw 0xD000 @ Opcode für den bedingten Sprung beq  Opcode for conditional jump BEQ mit Strukturerkennung "0"
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "ahead"
struktur_ahead: @ ( -- Adresse-für-Sprung 5 )   ( -- Address-for-Jump 5 )
@------------------------------------------------------------------------------
  push {lr}
  bl branch_v
  pushdaconst 5           @ Strukturerkennung  Structure matching
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "repeat"
@------------------------------------------------------------------------------
  push {lr}
  bl struktur_again
  bl struktur_then
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly|Flag_allocator|Flag_Sprungschlucker, "while"
@------------------------------------------------------------------------------
  push {lr}
  bl struktur_if
  bl dswap
  pop {pc}
  @------------------------------------------------------------
  push {lr}
  bl struktur_if_allokator
  bl dswap
  pop {pc}

@ An diese Stelle gelegt, damit die Sprungweiten hinkommen.
strukturen_passen_nicht:
  Fehler_Quit "Structures don't match"

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly|Flag_allocator|Flag_Sprungschlucker, "until"  @ Bedingte Schleife
  @ ( Sprungziel 1 -- )                                         @ Conditional loop
@------------------------------------------------------------------------------
  cmp tos, #1
  bne.n strukturen_passen_nicht
  drop
  b.n r_nullbranch  @ Write conditional jump
  bx lr @ Endmarkierung für den Allokatoreinsprung
@------------------------------------------------------------------------------
  cmp tos, #1
  bne.n strukturen_passen_nicht
  drop

  push {lr}
  bl eliminiere_tos_wenn_bmi

  ldr r1, [r0, #offset_sprungtrampolin]
  cmp r1, #0
  beq 1f

    push {r1} @ Der Sprungopcode liegt schon bereit !

    bl tidyup_register_allocator @ Den kanonischen Stack wieder herstellen. In diesem Fall sind alle Elemente in Registern oder auf dem Stack, so dass dabei die Flags erhalten bleiben.
                                 @ Außerdem wird das Sprungtrampolin dabei gelöscht. Fein !

    bl branch_v @ ( pushda Dictionarypointer und 2 allot )

    swap

    pushdatos
    pop {tos}

    bl cjumpgenerator
    pop {pc}

1:bl allocator_nullsprungprobe
  bl branch_v @ ( pushda Dictionarypointer und 2 allot )
  swap
  pushdaconstw 0xD000 @ Opcode für den bedingten Sprung beq  Opcode for conditional jump BEQ
  bl cjumpgenerator
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "again"  @ Endlosschleife
struktur_again:  @ ( Sprungziel 1 -- )           @ Unconditional loop
@------------------------------------------------------------------------------
  cmp tos, #1
  bne.n strukturen_passen_nicht
  drop
  b.n r_branch      @ Write unconditional jump

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "begin"
  @ ( -- Sprungziel 1 )  ( -- Jump-destination 1 )
@------------------------------------------------------------------------------
  push {lr}
  bl branch_r
  pushdaconst 1  @ Strukturerkennung  Structure matching
  pop {pc}
