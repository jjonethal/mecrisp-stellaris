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
  push {lr}

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
  bl konstantenfaltungszeiger_setzen
@ -----------------------------------------------------------------------------

  bl token
  @ ( Address Length )

  @ Prüfe, ob der String leer ist  Check if token is empty - that designates an empty input buffer.
  cmp tos, #0
  bne.n 2f
    ddrop
    pop {pc}
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

  cmp r2, #0
  bne.n .interpret_token_found
    @ Nicht gefunden. Ein Fall für Number.
    @ Entry-Address is zero if not found ! Note that Flags have very special meanings in Mecrisp !

    ldr r0, [psp] @ Den String für die not-found Meldung vermerken.
    movs r1, tos

    bl sprungschreiber_flaggenerator @ Wenn noch mehr Faltkonstanten kommen, müssen die Ergebnisse von Vergleichen vorher geschrieben werden.

    bl number

  @ Number gives back ( 0 ) or ( x 1 ) or ( x y 2 ).
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
.interpret_token_found:
  @ Token im Dictionary gefunden. Found token in dictionary. Decide what to do.

  @ ( Token-Addr Token-Length )

  @ Registerkarte:
  @  r1: Flags                                  Flags
  @  r2: Einsprungadresse                       Code entry point

  ldr r3, =state
  ldr r3, [r3]
  cmp r3, #0
  bne.n 5f
    @ Im Ausführzustand.  Execute.
    bl konstantenfaltungszeiger_loeschen

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
    b.n 1b @ Interpretschleife fortsetzen.  Finished.

  @ Registerkarte:
  @  r1: Flags
  @  r2: Einsprungadresse                        Code entry point

@ -----------------------------------------------------------------------------
5:@ Im Kompilierzustand.  In compile state.
    ddrop

    pushda r2 @ Einsprungadresse
    pushda r1 @ Flags

    bl kompilator
    b.n 1b @ Interpretschleife weitermachen     Finished.


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

   @ Clear 16-Bit Flash write emulation value-and-location collection table
  .ifdef emulated16bitflashwrites
   bl sammeltabelleleeren
  .endif

  .ifdef universalflashinforth
  bl initflash
  .endif

  .ifdef flash16bytesblockwrite
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

  bl init_register_allocator

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
