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

@------------------------------------------------------------------------------
konstantenfaltungszeiger_setzen:
@------------------------------------------------------------------------------
  push {r4, r5, lr}

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

3:pop {r4, r5, pc}

@------------------------------------------------------------------------------
konstantenfaltungszeiger_neusetzen:
@------------------------------------------------------------------------------
  push {r4, r5, lr}
  ldr r4, =konstantenfaltungszeiger
  movs r5, psp
  str r5, [r4]
  pop {r4, r5, pc}

@------------------------------------------------------------------------------
konstantenfaltungszeiger_loeschen:
@------------------------------------------------------------------------------
  push {r4, r5, lr}
  ldr r4, =konstantenfaltungszeiger
  movs r5, #0
  str r5, [r4]
  pop {r4, r5, pc}

@------------------------------------------------------------------------------
wievielefaltkonstanten:
@------------------------------------------------------------------------------
  ldr r3, =konstantenfaltungszeiger
  ldr r3, [r3]
  subs r3, psp  @ Konstantenfüllstandszeiger - Aktuellen Stackpointer
  lsrs r3, #2   @ Durch 4 teilen  Divide by 4 to get number of stack elements.
  bx lr

@------------------------------------------------------------------------------
kompilator:
@------------------------------------------------------------------------------
  push {lr}
  popda r1 @ Flags

    ldr r0, =Flag_inlinecache & ~Flag_visible
    ands r0, r1
    beq 4f
      bl inline_cache_parser
      pop {pc} @ Fertig.
4:

    ldr r0, =Flag_Sprungschlucker & ~Flag_visible
    ands r0, r1
    bne 4f
      bl sprungschreiber_flaggenerator
4:
    @ Jetzt dürfen keine Sprünge mehr im Sprungtrampolin warten, falls sie nicht vom Allokator später eingebaut werden.

  popda r2 @ Einsprungadresse
  bl konstantenfaltungszeiger_setzen

    @ Für die Konstanten, die über den Inline-Cache eintrudeln !
    ldr r0, =Flag_Literator & ~Flag_visible  
    ands r0, r1
    beq 4f
      pushda r2 @ Einfach wieder auf den jetzt der Faltung zugänglichen Stack bereitlegen.
      pop {pc}
4:

  bl wievielefaltkonstanten @ Number of folding constants now available in r3.

  @ Registerkarte:
  @  r1: Flags                                  Flags
  @  r2: Einsprungadresse                       Code entry point
  @  r3: Zahl der vorhandenen Faltkonstanten    Number of folding constants available

    @ Prüfe das Ramallot-Flag, das automatisch 0-faltbar bedeutet:
    @ Ramallot-Words always are 0-foldable !
    @ Check this first, as Ramallot is set together with foldability,
    @ but the meaning of the lower 4 bits is different.

    movs r0, #Flag_ramallot & ~Flag_visible
    ands r0, r1 @ Flagfeld auf Faltbarkeit hin prüfen
    bne.n .interpret_faltoptimierung

    @ Prüfe die Faltbarkeit des aktuellen Tokens:
    @ Check for foldability.

    movs r0, #Flag_foldable & ~Flag_visible
    ands r0, r1 @ Flagfeld auf Faltbarkeit hin prüfen
    beq.n .interpret_allocator @ Not foldable, but maybe the allocator can handle this.

.interpret_genugkonstanten: @ Not opcodable. Maybe foldable.
      @ Prüfe, ob genug Konstanten da sind:
      @ How many constants are necessary to fold this word ?
      movs r0, #0x0F
      ands r0, r1 @ Zahl der benötigten Konstanten maskieren

      cmp r3, r0
      blo.n .interpret_allocator @ Not enough folding constants available, but maybe the allocator can handle this.

.interpret_faltoptimierung:
        @ Do folding by running the definition.
        @ Note that Constant-Folding-Pointer is already set to keep track of results calculated.
        pushda r2 @ Einsprungadresse bereitlegen  Code entry point
        bl execute @ Durch Ausführung falten      Fold by executing
        pop {pc} @ Interpretschleife weitermachen     Finished.



.interpret_allocator:

  @ All foldable cases are finished now.

  @ Flags of Definition in r1
  @ Entry-Point of Definition in r2
  @ Number of folding constants available in r3

  @ Ab hier wird begonnen, wirklich Code zu generieren.
  @ Was hier vorbei kommt, muss vererbt werden.

  ldr r0, =Flag_allocator & ~Flag_visible
  ands r0, r1
  beq.n .interpret_allocator_finished

    bl nflush_faltkonstanten @ Jetzt werden die restlichen Faltkonstanten in den RA-Cache geschoben.
    @ Dies kommt einem partiellen Konstantenschreiben gleich, wobei allerdings die fünf obersten Stackelemente
    @ im RA-Cache hängenbleiben. Dabei werden nur vielleicht Opcodes generiert, falls der RA-Cache zu klein ist, alle zu fassen.

      @ Erst wurden alle Konstanten weitervererbt, jetzt kommt die darauf wirkende Operation.
      pushda r2
      pushda r1
      bl add_to_inline_cache

    @ Der Allokatoreinsprung ist am Ende der Definition
    movs r0, r2
    bl suchedefinitionsende
    adds r2, r0, #1 @ One more for Thumb

    ldr r0, =allocator_base
    blx r2

    @ Keine Konstantenfaltung über den Allokator hinweg - sonst würde z.B. do/loop die Struktur nicht auf dem Stack lagern können.
    @ Vor dem Aufschwimmen lassen den Konstantenfaltungszeiger neu setzen.
    bl konstantenfaltungszeiger_neusetzen
    
    bl nfaltkonstanten_aufschwimmen @ Sollten am Ende noch Faltkonstanten im Cache liegen, lasse sie aufschwimmen
    pop {pc} @ Interpretschleife weitermachen     Finished.

.interpret_allocator_finished:

  @ No optimizations possible. Go back to canonical stack for classic compilation.
  @ Write all folding constants left into dictionary.

  bl nflush_faltkonstanten     @ Vorhandene Faltkonstanten, soweit möglich, erstmal in den Registerallokator laden.

      pushda r2
      pushda r1
      bl add_to_inline_cache

  bl tidyup_register_allocator @ Alle Registerbewegungen opcodieren
  bl konstantenfaltungszeiger_loeschen

@ -----------------------------------------------------------------------------
  @ Write push {lr} if this definition still is in bx lr mode.

  ldr r0, =Flag_bxlr & ~Flag_visible
  ands r0, r1
  bne.n .prepared_for_classic
    bl push_lr_nachholen
.prepared_for_classic:

@ -----------------------------------------------------------------------------
  @ Classic compilation.
  pushda r2 @ Adresse zum klassischen Bearbeiten. Put code entry point on datastack.

  movs r2, #Flag_immediate & ~Flag_visible
  ands r2, r1
  beq.n 6f
    @ Es ist immediate. Immer ausführen. Always execute immediate definitions.
    bl execute @ Ausführen.
    pop {pc} @ Zurück in die Interpret-Schleife.  Finished.

6:movs r2, #Flag_inline & ~Flag_visible
  ands r2, r1
  beq.n 7f

  bl inlinekomma @ Direkt einfügen.        Inline the code
  pop {pc} @ Zurück in die Interpret-Schleife  Finished.

7:bl callkomma @ Klassisch einkompilieren  Simply compile a BL or Call.
  pop {pc} @ Zurück in die Interpret-Schleife  Finished.
