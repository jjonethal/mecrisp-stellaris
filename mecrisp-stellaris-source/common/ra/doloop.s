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

@ Die zählenden Schleifen
@ Counting loops

rloopindex .req r4
rlooplimit .req r5

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "k" @ Kopiert den drittobersten Schleifenindex  Third loop index
@------------------------------------------------------------------------------
  @ Returnstack ( Limit Index Limit Index )
  pushdatos
  ldr tos, [sp, #8]
  bx lr
@------------------------------------------------------------------------------
  pushdaconstw 0x9802
  b.n loop_j_allocator

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "j" @ Kopiert den zweitobersten Schleifenindex  Second loop index
@------------------------------------------------------------------------------
  @ Returnstack ( Limit Index )
  pushdatos
  ldr tos, [sp]
  bx lr
@------------------------------------------------------------------------------

rfetch_allocator:
  pushdaconstw 0x9800
loop_j_allocator:
  push {lr}
  bl befreie_tos
  bl get_free_register
  str r3, [r0, #offset_state_tos]
  lsls r3, #8
  orrs tos, r3
  bl hkomma
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_allocator, "i" @ Kopiert den obersten Schleifenindex       Innermost loop index
@------------------------------------------------------------------------------
  @ Returnstack ( )
  pushda rloopindex @ Ist immer im Register.
  bx lr
@------------------------------------------------------------------------------
  push {lr}
  pushdaconstw 0x0020
  bl befreie_tos
  bl get_free_register
  str r3, [r0, #offset_state_tos]
  orrs tos, r3
  bl hkomma
  pop {pc}


/* Ein paar Testfälle  Some tests

: table   cr 11 1 do
                    i 8 = if leave then
                    11 1 do
                           i j * . space
                           j 5 = if leave then
                           j 2 = if leave then
                         loop
                    cr
                  loop ;

: stars 0 ?do [char] * emit loop ;
: stars5 0 ?do [char] * emit   i 5 = if leave then loop ;

: table   cr 11 1 do 11 1 do i j * . space loop cr loop ;
: table   cr 11 1 do [ .s ] 11 1 do [ .s ] i j * . space loop [ .s ] cr loop [ .s ] ;
: table  cr 11 1 do i 8 = if leave then 11 1 do  i j * . space j 5 = if leave then  j 2 = if leave then loop cr loop ;

*/

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "leave" @ Beendet die Schleife sofort.  Terminates loop immediately.
  @ ( ... AlterLeavePointer 0 Sprungziel 3 ... )
  @ --
  @ ( ... AlterLeavePointer Vorwärtssprungziel{or-1-JZ} Sprungziel 3 ... )

  @ ( ... OldLeavePointer 0 Target 3 ... )
  @ --
  @ ( ... OldLeavePointer Forward-Jump-Target{or-1-JZ} NumberofJumps Target 3 ... )
@------------------------------------------------------------------------------
  @ Der LeavePointer zeigt an die Stelle, wo steht, wie viele Spezialsprünge noch abzuarbeiten sind.
  @ Alle Stackelemente weiterschieben, Sprungadresse einfügen, Zähler erhöhen, Lücke anlegen.

  @ LeavePointer points to the location which counts the number of jumps that have to be inserted later.
  @ Leave moves all elements of stack further, inserts address for jump opcode, increments counter and allots space.

  push {lr}

  @ Agenda:
  @ An dieser Stelle eine Vorwärtssprunglücke präparieren:
  @ TOS bleibt TOS
  @ Muss eine Lücke im Stack schaffen, alles NACH der Position des leavepointers muss weiterrücken.

  @ Make a hole in datastack at the lcoation the leavepointer points to for inserting the new location a jump opcode has to be patched in later
  @ by moving all other elements further one place in datastack.

  ldr r0, =leavepointer
  ldr r1, [r0] @ Die Stelle, wohin er zeigt = Inhalt der Variable Leavepointer

  movs r3, psp @ Alter Stackpointer  Old stackpointer
  subs psp, #4 @ Ein Element mehr auf dem Stack  One more element on stack after this

1:@ Lückenschiebeschleife
  ldr r2, [r3]  @ mov @r10, -2(r10)
  subs r3, #4
  str r2, [r3]
@  adds r3, #4

  adds r3, #8
  cmp r3, r1 @ r1 enthält die Stelle am Ende
  bne 1b

  @ Muss jetzt die Stelle auf dem Stack, wo die Sprünge gezählt werden um Eins erhöhen
  @ und an der freigewordenen Stelle die Lückenadresse einfügen.
  @ Increment the number of jumps to be filled in later

  push {r0, r1}
  bl branch_v
  pop {r0, r1}

  popda r3 @ Die Lückenadresse

  @ Insert the address of location for jump opcode in datastack
  subs r1, #4  @ Weiter in Richtung Spitze des Stacks wandern
  str r3, [r1] @ Lückenadresse einfügen

  @ Den neuen Leavepointer vermerken  Update leavepointer
  str r1, [r0]

  @ Increment counter for number of jumps to be generated later
  subs r1, #4   @ Weiter in Richtung Spitze des Stacks wandern
  ldr r2, [r1]  @ Sprungzähler aus dem Stack kopieren

  adds r2, #1   @ Den Sprungzähler um eins erhöhen
  str r2, [r1]  @ und zurückschreiben.

  pop {pc}


@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "unloop" @ Wirft die Schleifenstruktur vom Returnstack
unloop:                           @ Remove loop structure from returnstack
@------------------------------------------------------------------------------
  pop {rloopindex, rlooplimit}  @ Hole die alten Schleifenwerte zurück  Fetch back old loop values
  bx lr

@ Some tests:
@ : mealsforwholeday cr 25 6 do i dup roman ." : " mealtime cr 2 +loop cr ;
@ : ml+ cr 25 6 do i . space 2 +loop ;

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "+loop" @ Es wird benutzt mit ( Increment -- ).
  @ ( AlterLeavePointer ... ZahlderAdressen Sprungziel 3 -- )

  @ Usage: ( Increment -- ).
  @ ( OldLeavePointer ... NumberofJumps Target 3 -- )
  @------------------------------------------------------------------------------
  cmp tos, #3 @ Structure matching
  beq 1f
  b.n strukturen_passen_nicht
1:drop

  push {lr}
  pushdatos
  ldr tos, =struktur_plusloop
  bl inlinekomma  @ Inline the code needed for +loop
  bl r_branch_jvc @ +loop entscheidet mit dem arithmetrischen Überlauf
                  @ Insert a jump on overflow for +loop logic

  b.n loop_intern

  .ifdef m0core

struktur_plusloop:
  movs r0, #0x80
  lsls r0, #24 @ #0x80 --> #0x80 000000  6*4=24 Stellen schieben.
  adds r0, rloopindex
  adds rloopindex, tos
  subs r0, rlooplimit
  adds r0, tos  @ Flags are set here, Overflow means: Terminate loop.
  drop
  bx lr

  .else

struktur_plusloop:
  adds rloopindex, #0x80000000  @ Index + $8000
  subs rloopindex, rlooplimit   @ Index + $8000 - Limit

  adds rloopindex, tos         @ Index + $8000 - Limit + Schritt  Hier werden die Flags gesetzt. Überlauf bedeutet: Schleife beenden.
                               @ Flags are set here, Overflow means: Terminate loop.
  drop                         @ Runterwerfen, dabei Flags nicht verändern  Drop, but don't change Flags anymore.

  add rloopindex, rlooplimit   @ Index + $8000 + Schritt   Flags nicht verändern !
  sub rloopindex, #0x80000000  @ Index + Schritt           Flags nicht verändern !
  bx lr

  .endif

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "loop" @ Es wird benutzt mit ( -- ).
  @ ( AlterLeavePointer ... ZahlderAdressen Sprungziel 3 -- )

  @ Usage: ( -- ).
  @ ( OldLeavePointer ... NumberofJumps Target 3 -- )
@------------------------------------------------------------------------------
  cmp tos, #3 @ Structure matching
  beq 1f
  b.n strukturen_passen_nicht
1:drop

  push {lr}
  pushdatos
  ldr tos, =struktur_loop
  bl inlinekomma  @ Inline the code needed for +loop
  bl r_branch_jne @ Jump if Limit and Index are not equal this time

loop_intern:
  bl spruenge_einpflegen @ Die gleiche Routine ist in Endcase am Werk
                         @ Code to fill in jump opcodes is the same as in endcase.
  ldr r0, =leavepointer
  popda r1               @ Zurückholen für die nächste Schleifenebene
  str r1, [r0]           @ Fetch back old leavepointer for next loop layer.

  pushdatos
  ldr tos, =unloop      @ Inline unloop code
  bl inlinekomma
  pop {pc}

struktur_loop:
  adds rloopindex, #1          @ Index erhöhen           Increment Index
  cmp rloopindex, rlooplimit   @ Mit Limit vergleichen   Compare with Limit
  bx lr @ Ende für inline,   End marker for inline,

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly|Flag_allocator, "do"
  @ Es wird benutzt mit ( Limit Index -- ).
  @ ( -- AlterLeavePointer 0 Sprungziel 3 )

  @ Usage: ( Limit Index -- ).
  @ ( -- OldLeavePointer 0 Target 3 )
@------------------------------------------------------------------------------
  push {lr}

  pushdatos
  ldr tos, =struktur_do  @ Inline opcodes for do
  bl inlinekomma

do_rest_der_schleifenstruktur:
  ldr r0, =leavepointer
  ldr r1, [r0]
  pushda r1     @ Alten Leavepointer sichern  Save old leavepointer
  pushdaconst 0
  str psp, [r0] @ Aktuelle Position im Stack sichern  Save current position on datastack

  bl branch_r    @ Schleifen-Rücksprung vorbereiten  Prepare loop jump back to the beginning
  pushdaconst 3  @ Strukturerkennung  Structure matching
@  writeln "do-Struktur"
@  bl hexdots
  pop {pc}

@------------------------------------------------------------------------------
  @ Opcodable optimisations enter here. At least one folding constant available.
  push {lr}
  bl gemeinsame_schleifenoptimierung
  b.n do_rest_der_schleifenstruktur

struktur_do:
  push {rloopindex, rlooplimit}
  popda rloopindex
  popda rlooplimit
  bx lr @ Ende für inline,  End for inline,


@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly|Flag_allocator, "?do"
  @ Es wird benutzt mit ( Limit Index -- ).
  @ ( -- AlterLeavePointer Vorsprungadresse 1 Sprungziel 3 )
  @ Diese Schleife springt sofort ans Ende, wenn Limit=Index.

  @ Usage: ( Limit Index -- ).
  @ ( -- OldLeavePointer Forward-Jump-Target 1 Target 3 )
  @ This loop terminates immediately if Limit=Index.
@------------------------------------------------------------------------------
  push {lr}
  pushdatos
  ldr tos, =struktur_do  @ Inline opcodes for do
  bl inlinekomma

qdo_rest_der_schleifenstruktur:
  pushdaconstw 0x42AC @ cmp rloopindex, rlooplimit @ Vergleiche die beiden Schleifenparameter  Compare both loop registers
  bl hkomma

  ldr r0, =leavepointer
  ldr r1, [r0]
  pushda r1     @ Alten Leavepointer sichern  Save old leavepointer

  @ An diese Stelle nun die Vorwärtssprunglücke einfügen:
  @ Allot an hole in which a forward jump is inserted later.
  bl branch_v    @ here 2 allot
  adds tos, #1   @ Markierung anbringen, dass ich mir einen bedingten Sprung wünsche
                 @ This bit indicates that we need a conditional jump to be filled in here later.

  pushdaconst 1
  ldr r0, =leavepointer
  str psp, [r0] @ Aktuelle Position im Stack sichern  Save current position on datastack

  bl branch_r    @ Schleifen-Rücksprung vorbereiten  Prepare loop jump back to the beginning
  pushdaconst 3  @ Strukturerkennung  Structure matching
  pop {pc}

@------------------------------------------------------------------------------
  @ Opcodable optimisations enter here. At least one folding constant available.
  push {lr}
  bl gemeinsame_schleifenoptimierung
  b.n qdo_rest_der_schleifenstruktur


@------------------------------------------------------------------------------
gemeinsame_schleifenoptimierung: @ This is a common part for opcoding optimized do and ?do
@------------------------------------------------------------------------------
  push {lr}
  bl push_lr_nachholen
  bl expect_two_elements

  bl tidyup_register_allocator_5os
  bl tidyup_register_allocator_4os
  bl tidyup_register_allocator_3os

  pushdaconstw 0xB430 @ push {rloopindex, rlooplimit}
  bl hkomma

  ldr r1, [r0, #offset_state_tos]
  cmp r1, #constant
  beq 1f
    @ TOS, the Index, is in a Register.
    pushdaconstw 0x0004
    lsls r1, #3
    orrs tos, r1
    bl hkomma
    b 2f
1:  @ TOS is a constant.
    pushdatos
    ldr tos, [r0, #offset_constant_tos]
    pushdaconst 4
    bl registerliteralkomma
2:



  ldr r1, [r0, #offset_state_nos]
  cmp r1, #constant
  beq 1f
    @ NOS, the Limit, is in a Register.
    pushdaconstw 0x0005
    lsls r1, #3
    orrs tos, r1
    bl hkomma
    b 2f
1:  @ NOS is a constant.
    pushdatos
    ldr tos, [r0, #offset_constant_nos]
    pushdaconst 5
    bl registerliteralkomma
2:

  bl eliminiere_tos
  bl eliminiere_tos

  bl tidyup_register_allocator_tos @ TOS wieder in einen blitzeblanken Zustand versetzen !

    @ writeln "Schleifenoptimierung fertig"
    @ bl hexdots
  pop {pc}

  .ltorg

