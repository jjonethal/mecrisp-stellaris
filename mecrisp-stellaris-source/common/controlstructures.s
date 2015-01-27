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
  Wortbirne Flag_immediate_compileonly, "then"
  @ ( Adresse-für-Sprung 2 | Adresse-für-Sprung 5 -- )
  @ ( Address-for-Jump 2 | Address-for-Jump 5 --)
@------------------------------------------------------------------------------
  cmp tos, #5 @ Kommend aus Else-Zweig
  bne 1f
    drop @ ( Sprunglücke )    
    b.n v_branch @ Abschluss unbedingter Vorwärtssprung  Fill in unconditional forward jummp

1:cmp tos, #2 @ Kommend aus IF-Zweig
  bne.n strukturen_passen_nicht
    drop @ ( Sprunglücke )
    b.n v_nullbranch @ Abschluss bedingter Vorwärtssprung v_nullbranch  Fill in conditional forward jump

strukturen_passen_nicht:
  Fehler_Quit "Structures don't match"

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "else"
  @ ( Adresse-für-Sprung 2 -- Adresse-für-Sprung 5 )
  @ ( Address-for-Jump 2 -- Address-for-Jump 5 )
@------------------------------------------------------------------------------
  push {lr}
  cmp tos, #2
  bne strukturen_passen_nicht
  drop

  @ ( Bedingter-Sprung )  ( Conditional-Jump )
  bl branch_v
  @ ( Bedingter-Sprung Unbedingter-Sprung )  ( Conditional-Jump Unconditional-Jump )
  swap
  @ ( Unbedingter-Sprung Bedingter-Sprung )  ( Unconditional-Jump Conditional-Jump )
  bl v_nullbranch  @ Fill in conditional forward jump
  @ ( Unbedingter Sprung )  ( Unconditional-Jump )
  pushdaconst 5 @ Strukturerkennung bereitlegen  Structure matching
  @ ( Unbedingter Sprung 5 )  ( Unconditional-Jump 5 )
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "if"
struktur_if: @ ( -- Adresse-für-Sprung 2 )   ( -- Address-for-Jump 2 )
@------------------------------------------------------------------------------
  push {lr}
  bl nullbranch_v
  pushdaconst 2           @ Strukturerkennung  Structure matching
  pop {pc}

@ : schleife begin key 27 <> while ." Moin" repeat ;

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "repeat"  @ Wie das Pascal-While-Konstrukt.
  @ ( Sprungziel Adresse-für-Sprung 4 -- )
  @ ( Target Address-for-Jump 4 -- )
@------------------------------------------------------------------------------
  @ begin (Bedingung) while (Agenda) repeat (Folgendes).
  @ begin (Flag) while (To Do) repeat
 
  @ In Pascal: while (true) do Agenda;
  @ ( Sprungziel-zurück-an-Anfang Adresse-für-Sprung-ans-Ende 4 )
  cmp tos, #4
  bne.n strukturen_passen_nicht
  drop
  @ ( Sprungziel-zurück-an-Anfang  Adresse-für-Sprung-ans-Ende )
  @ ( Target-Beginning  Address-for-jump-to-End )
  swap
  @ ( Adresse-für-Sprung-ans-Ende Sprungziel-zurück-an-Anfang )
  @ ( Address-for-jump-to-End Target-Beginning )
  push {lr}
  bl r_branch @ Rücksprung an den Anfang, falls ich normal einlaufe   Write jump back to beginning
  @ ( Adresse-für-Sprung-ans-Ende )
  @ ( Address-for-jump-to-End )
  bl v_nullbranch @ Raussprung aus dem Konstrukt. Write exit of structure into dictionary.
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "while"  @ Wie das Pascal-While-Konstrukt.
  @ ( Sprungziel 1 -- Sprungziel Adresse-Für-Sprung 4 )
  @ ( Target 1 -- Target Address-for-Jump 4 )
@------------------------------------------------------------------------------
  @ begin (Bedingung) while (Agenda) repeat (Folgendes).
  @ begin (Flag) while (To Do) repeat

  @ In Pascal: while (true) do Agenda;
  cmp tos, #1
  bne.n strukturen_passen_nicht
  drop
  @ ( Sprungziel ) wird für den späteren Rücksprung benutzt.  Used for jump back later
  push {lr}
  bl struktur_if @ Benutze einfach mal If.  Use IF to generate the code
  @ ( Sprungziel Adresse-Für-Sprung 2 ) ( Target Address-for-Jump )
  adds tos, #2 @ Structure matching 2+2 = 4
  @ ( Sprungziel Adresse-Für-Sprung 4 ) Strukturkennung 4 !
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "until"  @ Bedingte Schleife
  @ ( Sprungziel 1 -- )                          @ Conditional loop
@------------------------------------------------------------------------------
  cmp tos, #1
  bne.n strukturen_passen_nicht
  drop
  b.n r_nullbranch  @ Write conditional jump

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "again"  @ Endlosschleife
  @ ( Sprungziel 1 -- )                          @ Unconditional loop
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
