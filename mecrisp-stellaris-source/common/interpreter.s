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

@ Interpreter und Optimierungen
@ Interpreter and optimisations

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "evaluate" @ ( -- )
@ -----------------------------------------------------------------------------
  push {lr}
  bl source             @ Save current source
  
  @ 2>r
  ldm psp!, {r0}
  push {r0}
  push {tos}
  ldm psp!, {tos}

  ldr r0, =Pufferstand  @ Save >in and set to zero
  ldr r1, [r0]
  push {r1}
  movs r1, #0
  str r1, [r0]

  bl setsource          @ Set new source
  bl interpret          @ Interpret

  ldr r0, =Pufferstand  @ Restore >in
  pop {r1}
  str r1, [r0]

  @ 2r>
  pushdatos
  pop {tos}
  pop {r0}
  subs psp, #4
  str r0, [psp]

  bl setsource          @ Restore old source

  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "interpret" @ ( -- )
interpret:
@ -----------------------------------------------------------------------------
  push {r4, r5, lr}

1:@ Bleibe solange in der Schleife, wie token noch etwas zurückliefert.
  @ Stay in loop as long token can fetch something from input buffer.

  @ Probe des Datenstackpointers.
  @ Check pointer for datastack.

  ldr r0, =datenstackanfang   @ Stacks fangen oben an und wachsen nach unten.
  cmp psp, r0                 @ Wenn die Adresse kleiner oder gleich der Anfangsadresse ist, ist alles okay.
  bls.n 2f
    Fehler_Quit_n "Stack underflow"

2:ldr r0, =datenstackende     @ Solange der Stackzeiger oberhalb des Endes liegt, ist alles okay.
  cmp psp, r0
  bhs.n 3f
    Fehler_Quit_N "Stack overflow"

3: @ Alles ok.  Stacks are fine.

@ -----------------------------------------------------------------------------

  @ Konstantenfaltungszeiger setzen, falls er das noch nicht ist.
  @ Set Constant-Folding-Pointer
  ldr r4, =konstantenfaltungszeiger
  ldr r5, [r4]
  cmp r5, #0
  bne.n 3f
    @ Konstantenfaltungszeiger setzen.
    @ If not set yet, set it now.
    movs r5, psp
    str r5, [r4]
3:

@ -----------------------------------------------------------------------------
  bl token
  @ ( Address Length )

  @ Prüfe, ob der String leer ist  Check if token is empty - that designates an empty input buffer.
  cmp tos, #0
  bne.n 2f
    ddrop
    pop {r4, r5, pc}
2:

@ -----------------------------------------------------------------------------
  @ String aus Token angekommen.  We have a string to interpret.
  @ ( Address Length )

  @ Registerkarte:
  @  r4: Adresse des Konstantenfaltungszeigers  Address of constant folding pointer
  @  r5: Konstantenfaltungszeiger               Constant folding pointer

  ddup
  bl find @ Probe, ob es sich um ein Wort aus dem Dictionary handelt:  Attemp to find token in dictionary.
  @ ( Token-Addr Token-Length Addr Flags )

  popda r1 @ Flags
  popda r2 @ Einsprungadresse

  @ ( Token-Addr Token-Length )

  @ Registerkarte:
  @  r1: Flags                                  Flags
  @  r2: Einsprungadresse                       Code entry point
  @  r4: Adresse des Konstantenfaltungszeigers  Address of constant folding pointer
  @  r5: Konstantenfaltungszeiger               Constant folding pointer

  cmp r2, #0
  bne.n 4f
    @ Nicht gefunden. Ein Fall für Number.
    @ Entry-Address is zero if not found ! Note that Flags have very special meanings in Mecrisp !

    ldr r0, [psp]
    movs r1, tos

    bl number

  @ Number gives back ( 0 ) or ( x 1 ).
  @ Zero means: Not recognized.
  @ Note that literals actually are not written/compiled here.
  @ They are simply placed on stack and constant folding takes care of them later.

    popda r2   @ Flag von Number holen
    cmp r2, #0 @ Did number recognize the string ?
    bne.n 1b   @ Zahl gefunden, alles gut. Interpretschleife fortsetzen.  Finished.

    @ Number mochte das Token auch nicht.
not_found_addr_r0_len_r1:
@    pushda r0
@    pushda r1
    bl stype_addr_r0_len_r1
    Fehler_Quit_n " not found."

@ -----------------------------------------------------------------------------
4:@ Token im Dictionary gefunden. Found token in dictionary. Decide what to do.

  @ ( Token-Addr Token-Length )

  @ Registerkarte:
  @  r1: Flags                                  Flags
  @  r2: Einsprungadresse                       Code entry point
  @  r4: Adresse des Konstantenfaltungszeigers  Address of constant folding pointer
  @  r5: Konstantenfaltungszeiger               Constant folding pointer

  ldr r3, =state
  ldr r3, [r3]
  cmp r3, #0
  bne.n 5f
    @ Im Ausführzustand.  Execute.
    movs r5, #0   @ Konstantenfaltungszeiger löschen  Clear constant folding pointer
    str r5, [r4]  @ Do not collect literals for folding in execute mode. They simply stay on stack.

    movs r3, #Flag_immediate_compileonly & ~Flag_visible
    ands r3, r1
    cmp r3, #Flag_immediate_compileonly & ~Flag_visible
    bne.n .ausfuehren
      bl stype
      Fehler_Quit_n " is compile-only."

.ausfuehren:
    ddrop
    pushda r2    @ Adresse zum Ausführen   Code entry point
    bl execute   @                         Execute it
    bl 1b @ Interpretschleife fortsetzen.  Finished.

  @ Registerkarte:
  @  r0: Stringadresse des Tokens, wird ab hier nicht mehr benötigt.  
  @      Wird danach für die Zahl der benötigten Konstanten für die Faltung genutzt.
  @      From now on, this is number of constants that would be needed for folding this definition
  @  r1: Flags
  @  r3: Temporärer Register, ab hier: Konstantenfüllstand  Constant fill gauge of Datastack
  @  r2: Einsprungadresse                        Code entry point
  @  r4: Adresse des Konstantenfaltungszeigers.  Address of constant folding pointer
  @  r5: Konstantenfaltungszeiger                Constant folding pointer

@ -----------------------------------------------------------------------------
5:@ Im Kompilierzustand.  In compile state.
    ddrop

    @ Prüfe das Ramallot-Flag, das automatisch 0-faltbar bedeutet:
    @ Ramallot-Words always are 0-foldable !
    @ Check this first, as Ramallot is set together with foldability,
    @ but the meaning of the lower 4 bits is different.

    movs r0, #Flag_ramallot & ~Flag_visible
    ands r0, r1 @ Flagfeld auf Faltbarkeit hin prüfen
    bne.n .interpret_faltoptimierung

    @ Bestimme die Anzahl der zur Faltung bereitliegenden Konstanten:
    @ Calculate number of folding constants available.

    subs r3, r5, psp @ Konstantenfüllstandszeiger - Aktuellen Stackpointer
    lsrs r3, #2      @ Durch 4 teilen  Divide by 4 to get number of stack elements.
    @ Number of folding constants now available in r3.

    @ Prüfe die Faltbarkeit des aktuellen Tokens:
    @ Check for foldability.
    
    movs r0, #Flag_foldable & ~Flag_visible
    ands r0, r1 @ Flagfeld auf Faltbarkeit hin prüfen
    beq.n .konstantenschleife

      @ Check for opcodability.
      movs r0, #Flag_opcodable & ~Flag_visible
      ands r0, r1
      beq.n .interpret_genugkonstanten @ Flag is set
      cmp r3, #0 @ And at least one constant is available for folding.
      beq.n .interpret_genugkonstanten
        b.n .interpret_opcodierbar
      
.interpret_genugkonstanten: @ Not opcodable. Maybe foldable.
      @ Prüfe, ob genug Konstanten da sind:
      @ How many constants are necessary to fold this word ?
      movs r0, #0x0F
      ands r0, r1 @ Zahl der benötigten Konstanten maskieren

      cmp r3, r0
      blo.n .konstantenschleife

.interpret_faltoptimierung:
        @ Do folding by running the definition. 
        @ Note that Constant-Folding-Pointer is already set to keep track of results calculated.
        pushda r2 @ Einsprungadresse bereitlegen  Code entry point
        bl execute @ Durch Ausführung falten      Fold by executing
        b.n 1b @ Interpretschleife weitermachen     Finished.

    @ No optimizations possible. Compile the normal way.
    @ Write all folding constants left into dictionary.

.konstantenschleife:
    bl konstantenschreiben

@ -----------------------------------------------------------------------------
  @ Classic compilation.
  pushda r2 @ Adresse zum klassischen Bearbeiten. Put code entry point on datastack.

  movs r2, #Flag_immediate & ~Flag_visible
  ands r2, r1
  beq.n 6f
    @ Es ist immediate. Immer ausführen. Always execute immediate definitions.
    bl execute @ Ausführen.
    b.n 1b @ Zurück in die Interpret-Schleife.  Finished.

6:movs r2, #Flag_inline & ~Flag_visible
  ands r2, r1
  beq.n 7f
  
  bl inlinekomma @ Direkt einfügen.        Inline the code
  b.n 1b @ Zurück in die Interpret-Schleife  Finished.

7:bl callkomma @ Klassisch einkompilieren  Simply compile a BL or Call.
  b.n 1b @ Zurück in die Interpret-Schleife  Finished.


@ -----------------------------------------------------------------------------
.interpret_opcodierbar: @ Special case: Opcodable !

  @ Flags of Definition in r1
  @ Entry-Point of Definition in r2
  @ Number of folding constants available in r3, at least one

  @ Decide on the different cases. As I don't return, I can change Flag register freely.  
  movs r0, #7 @ Mask for opcoding cases
  ands r1, r0

  @ Most opcodable cases have special opcodes at the end of the definition.
  @ Prepare this place to be available in r0
  movs r0, r2 @ Entry point
  bl suchedefinitionsende @ Search for end of Definition

  cmp r1, #1
  bne.n .interpret_opcodierbar_rechenlogik
    @------------------------------------------------------------------------------
    @ Plus and Minus
    @ Available as short Opcode on all Cores

    cmp r3, #1
    bne.n .interpret_faltoptimierung @ Opcode only with exactly one constant. Do folding with two constants or more in this case !
    @ Exactly one constant.

    @ Is constant small enough to fit in one Byte ?
    movs r1, #0xFF  @ Mask for 8 Bits
    ands r1, tos
    cmp r1, tos
    bne.n 2f
    @ Equal ? Constant fits in 8 Bits.

      ldrh r0, [r0, #2] @ Fetch Opcode, two more for Register-Opcode
      orrs tos, r0 @ Put constant into Opcode
      bl hkomma
      b.n 1b @ Finished.
      
2:  

    .ifndef m0core
      @ M3/M4 cores offer additional opcodes with 12-bit encoded constants.
      bl twelvebitencoding

      cmp tos, #0
      drop   @ Preserves Flags !
      beq 3f
        @ Encoding of constant within 12 bits is possible. Generate Opcode !
        ldr r0, [r0, #4] @ Fetch 32-Bit-Opcode, this is possible without alignment here,
                         @ Four more for M3/M4-Opcodes
        orrs tos, r0
        bl reversekomma
        b.n 1b @ Finished.
3:
    .endif

.interpret_opcodieren_ueber_r0:
    @ Large constant without short encoding possibility. Put it in register first.
    pushdaconst 0
    bl registerliteralkomma

    pushdatos
    ldrh tos, [r0] @ Fetch Opcode
    bl hkomma
    b.n 1b @ Finished.


.interpret_opcodierbar_rechenlogik:
  cmp r1, #2
  bne.n .interpret_opcodierbar_gleichungleich
    @------------------------------------------------------------------------------
    @ Calculus and Logic (Rechenlogik)
    @ M0 only supports logic with register operands.

    cmp r3, #1
    bne.n .interpret_faltoptimierung @ Opcode only with exactly one constant. Do folding with two constants or more in this case !
    @ Exactly one constant. M0 needs all constant sizes available in registers.
    b.n .interpret_opcodieren_ueber_r0 @ Simply reuse code as for plus and minus.


.interpret_opcodierbar_gleichungleich:
  cmp r1, #3
  bne.n .interpret_opcodierbar_schieben
    @------------------------------------------------------------------------------
    @ Equal and Unequal. 

    cmp r3, #1
    bne.n .interpret_faltoptimierung @ Opcode only with exactly one constant. Do folding with two constants or more in this case !
    @ Exactly one constant.

    @ Is constant small enough to fit in one Byte ?
    movs r1, #0xFF  @ Mask for 8 Bits
    ands r1, tos
    cmp r1, tos
    bne.n 2f
    @ Equal ? Constant fits in 8 Bits.

      ldr r1, =0x3E00 @ Opcode subs r6, #0
      orrs tos, r1
      bl hkomma

4:    adds r2, #4 @ Skip first two instructions of definition
      pushda r2
      bl inlinekomma
      b.n 1b @ Finished.
 
2:  

    .ifndef m0core
      @ M3/M4 cores offer additional opcodes with 12-bit encoded constants.
      bl twelvebitencoding

      cmp tos, #0
      drop   @ Preserves Flags !
      beq 3f
        @ Encoding of constant within 12 bits is possible.
        ldr r1, =0xF1B60600 @ Opcode subs tos, tos, #imm12
        orrs tos, r1
        bl reversekomma
        b.n 4b
3:
    .endif    

    @ Larger constant. Put it in register first.
    pushdaconst 0
    bl registerliteralkomma

    adds r2, #2 @ Skip first instruction of definition
    pushda r2
    bl inlinekomma
    b.n 1b @ Finished.


.interpret_opcodierbar_schieben:
  cmp r1, #4
  bne.n .interpret_opcodierbar_speicherschreiben
    @------------------------------------------------------------------------------
    @ Logical Shifts.

    cmp r3, #1
    bne.n .interpret_faltoptimierung @ Opcode only with exactly one constant. Do folding with two constants or more in this case !
    @ Exactly one constant.

    popda r3 @ Fetch constant
    cmp r3, #0
    bne.n 2f
    b.n 1b @ Shift by zero ? No Opcode to generate. Finished !

2:  movs r2, #0x1F @ 5 Bits
    ands r2, r3
    cmp r2, r3 @ Does shift fit in 5 Bits ?
    beq.n 3f
      @ Shift more than 31 Places - Zero out TOS or replace by an asrs tos, #31 opcode:
      pushdatos
      ldrh tos, [r0, #2] @ Fetch next opcode
      bl hkomma
      b.n 1b @ Finished.

3:  pushdatos
    ldrh tos, [r0] @ Fetch Opcode
    lsls r3, #6  @ Shift places accordingly
    orrs tos, r3  @ Build shift opcode
    bl hkomma
    b.n 1b @ Finished.


.interpret_opcodierbar_speicherschreiben:
  cmp r1, #5
  bne.n .interpret_opcodierbar_andere
    @------------------------------------------------------------------------------
    @ Write memory

    cmp r3, #1
    bne.n 2f @ Exactly one constant

    pushdaconst 0
    bl registerliteralkomma

    pushda r0
    bl inlinekomma

    @ Compile Drop-Opcode
    pushdaconstw 0xcf40 @ Opcode for ldmia r7!, {r6}
    bl hkomma
    b.n 1b @ Finished.

2:  @ Two or more constants.
    pushdaconst 0
    bl registerliteralkomma

    pushdaconst 1
    bl registerliteralkomma

    bl suchedefinitionsende

    pushda r0
    bl inlinekomma
    b.n 1b @ Finished.

.interpret_opcodierbar_andere:

  .ifndef m0core @ This is for M3/M4 only
  @------------------------------------------------------------------------------
  @ Check for architecture-specific special cases:

  cmp r1, #6
  bne.n 2f
    @------------------------------------------------------------------------------
    @ Logic with special opcodings available on M3/M4 only
    cmp r3, #1
    bne .interpret_faltoptimierung @ Opcode only with exactly one constant. Do folding with two constants or more in this case !

    @ Check if constant available can be encoded as 12-bit-bitmask
    bl twelvebitencoding

    cmp tos, #0
    drop   @ Preserves Flags !
    beq .interpret_opcodieren_ueber_r0 @ Simply reuse code as for plus and minus.

      @ 12-bit-encoding is possible. Generate the opcode :-)

      ldr r0, [r0, #2] @ Fetch 32-Bit Thumb-2 Opcode, this can be done on M3/M4 without alignment
                   @ Two more for the advanced M3-Opcode
      orrs tos, r0
      bl reversekomma
      b.n 1b @ Finished.
2:
  .endif

  @------------------------------------------------------------------------------
  @ Special cases that do not have their own handling in interpret.
  @ They have their own handlers at the end of definition that is called here.

  adds r0, #1 @ One more for Thumb
  blx r0
  b.n 1b @ Finished.  


@ -----------------------------------------------------------------------------
konstantenschreiben: @ Special internal entry point with register dependencies.
@ -----------------------------------------------------------------------------
    push {lr}
    cmp r3, #0   @ Null Konstanten liegen bereit ? Zero constants available ?
    beq.n 7f     @ Dann ist nichts zu tun.         Nothing to write.

.konstanteninnenschleife:
    @ Schleife über r5 :-)
    @ Loop for writing all folding constants left.
    subs r3, #1 @ Weil Pick das oberste Element mit Null addressiert.

    .ifdef m0core
    pushdatos
    lsls tos, r3, #2
    ldr tos, [psp, tos]    
    .else
    pushda r3
    ldr tos, [psp, tos, lsl #2] @ pick
    .endif

    bl literalkomma
   
    cmp r3, #0
    bne.n .konstanteninnenschleife
   
    @ Die geschriebenen Konstanten herunterwerfen.
    @ Drop constants written.
    subs r5, #4  @ TOS wurde beim drauflegen der Konstanten gesichert.
    movs psp, r5  @ Pointer zurückholen
    drop         @ Das alte TOS aus seinem Platz auf dem Stack zurückholen.

7:movs r5, #0   @ Konstantenfaltungszeiger löschen  Clear constant folding pointer.
  str r5, [r4]
  pop {pc}


@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "hook-quit" @ ( -- addr )
  CoreVariable hook_quit
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, =hook_quit
  bx lr
  .word quit_innenschleife  @ Simple loop for default

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "quit" @ ( -- )
quit:
@ -----------------------------------------------------------------------------
  @ Endlosschleife - muss LR nicht sichern.  No need for saving LR as this is an endless loop.
  @ Stacks zurücksetzen
  @ Clear stacks and tidy up.
  .ifdef m0core
  ldr r0, =returnstackanfang
  mov sp, r0
  .else
  ldr sp, =returnstackanfang
  .endif

  ldr psp, =datenstackanfang

  .ifdef initflash
   bl initflash
  .endif

  @ Base und State setzen

  ldr r0, =base
  movs r1, #10   @ Base decimal
  str r1, [r0]

  ldr r0, =state
  movs r1, #0    @ Execute mode
  str r1, [r0]

  ldr r0, =konstantenfaltungszeiger
  @ movs r1, #0  @ Clear constant folding pointer
  str r1, [r0]

  ldr r0, =Pufferstand
  @ movs r1, #0  @ Set >IN to 0
  str r1, [r0]

  ldr r0, =current_source 
  @ movs r1, #0  @ Empty TIB is source
  str r1, [r0]
  ldr r1, =Eingabepuffer
  str r1, [r0, #4]

quit_intern:
  ldr r0, =hook_quit
  ldr r0, [r0]
  mov pc, r0

quit_innenschleife:  @ Main loop of Forth system.
  bl query
  bl interpret
  writeln " ok."
  b.n quit_innenschleife
