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

@ Die Routinen, die nötig sind, um neue Definitionen zu kompilieren.
@ The compiler - parts that are the same for Flash and for Ram.

  .ifdef m0core
  .include "../common/codegenerator-m0.s"
  .else
  .include "../common/codegenerator-m3.s"
  .endif

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "[']" @ Sucht das nächste Wort im Eingabestrom  Searches the next token in input buffer and compiles its entry point as literal.
@------------------------------------------------------------------------------
  b.n tick @ So sah das mal aus: ['] ' immediate 0-foldable ;

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "'" @ Searches next token in unput buffer and gives back its code entry point.
tick: @ Nimmt das nächste Token aus dem Puffer, suche es und gibt den Einsprungpunkt zurück.
@ -----------------------------------------------------------------------------
  push {lr}
  bl token
  bl find_not_found
  popda r0 @ Drop Flags into r0 - used by postpone !
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "postpone" @ Sucht das nächste Wort im Eingabestrom  Search next token and fill it in Dictionary in a special way.
                                       @ und fügt es auf besondere Weise ein.
@------------------------------------------------------------------------------
  push {lr}

  bl tick @ Stores Flags into r0 !

  @ ( Einsprungadresse )  

  .ifdef registerallocator

  pushda r0
  swap
  bl literalkomma
  bl literalkomma
  pushdatos
  ldr tos, =kompilator
  bl callkomma
  pop {pc}

  .else

1:movs r1, #Flag_immediate & ~Flag_visible @ In case definition is immediate: Compile a call to its address.
  ands r1, r0
  bne 4f

2:movs r1, #Flag_inline & ~Flag_visible    @ In case definition is inline: Compile entry point as literal and a call to inline, afterwards.
  ands r1, r0
  beq 3f                             @ ( Einsprungadresse )
    bl literalkomma                  @ Einsprungadresse als Konstante einkompilieren
    pushdatos
    ldr tos, =inlinekomma
    b 4f                             @ zum Aufruf bereitlegen
    
3:@ Normal                     @ In case definition is normal: Compile entry point as literal and a call to call, afterwards.
    bl literalkomma
    pushdatos
    ldr tos, =callkomma
4:  bl callkomma
    pop {pc}

  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "inline," @ ( addr -- )
inlinekomma:
@ -----------------------------------------------------------------------------
  push {lr}
  @ Übernimmt eine Routine komplett und schreibt sie ins Dictionary.
  @ TOS enthält Adresse der Routine, die eingefügt werden soll.
  @ Copy the whole code of a definition into Dictionary.

  @ Es gibt drei besondere Opcodes:     There are three special opcodes:
  @  - push {lr} wird übersprungen        will be skipped
  @  - pop {pc} ist Ende                  is end of definition
  @  - bx lr ist auch eine Endezeichen.   is end often used in core.


  .ifdef m0core
  ldr r1, =0xb500 @ push {lr}
  ldr r2, =0xbd00 @ pop {pc}
  ldr r3, =0x4770 @ bx lr
  .else
  movw r1, #0xb500 @ push {lr}
  movw r2, #0xbd00 @ pop {pc}
  movw r3, #0x4770 @ bx lr
  .endif

1:ldrh r0, [tos] @ Hole die nächsten 16 Bits aus der Routine.  Fetch next opcode...
  cmp r0, r1 @ push {lr}
  beq 2f
  cmp r0, r2 @ pop {pc}
  beq 3f
  cmp r0, r3 @ bx lr
  beq 3f

  pushda r0
  bl hkomma @ Opcode einkompilieren  After checking is done, insert opcode into Dictionary.

2:adds tos, #2 @ Pointer weiterrücken  Advance pointer
  b 1b 

3:drop
  pop {pc}

@ An der ersten Stelle wird geprüft: Ist es eine Routine mit pop {pc} oder mit bx lr am Ende ?
@ -----------------------------------------------------------------------------
suchedefinitionsende: @ Rückt den Pointer in r0 ans Ende einer Definition vor.
                      @ Advance r0 to the end of code of current definition by searching for pop {pc} or bx lr opcodes.
@ -----------------------------------------------------------------------------
        @ Suche wie in inline, nach pop {pc} oder bx lr.
        push {r1, r2, r3}

         .ifdef m0core
         ldr r2, =0xbd00 @ pop {pc}
         ldr r3, =0x4770 @ bx lr
         .else
         movw r2, #0xbd00 @ pop {pc}
         movw r3, #0x4770 @ bx lr
         .endif


1:        ldrh r1, [r0]  @ Hole die nächsten 16 Bits aus der Routine.
          adds r0, #2    @ Pointer Weiterrücken

          cmp r1, r2  @ pop {pc}
          beq 2f
          cmp r1, r3  @ bx lr
          bne 1b

2:      pop {r1, r2, r3}
        bx lr


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "ret," @ ( -- )
retkomma: @ Write pop {pc} opcode
@ -----------------------------------------------------------------------------
  @ Mache das mit pop {pc}
  pushdaconstw 0xbd00 @ Opcode für pop {pc} schreiben
  b.n hkomma

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "exit" @ Kompiliert ein ret mitten in die Definition.
  @ Writes a ret opcode into current definition. Take care with inlining !
@------------------------------------------------------------------------------
  b.n retkomma

@ Some tests:
@  : fac ( n -- n! )   1 swap  1 max  1+ 2 ?do i * loop ;
@  : fac-rec ( acc n -- n! ) dup dup 1 = swap 0 = or if drop else dup 1 - rot rot * swap recurse then ; : facre ( n -- n! ) 1 swap fac-rec ;

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "recurse" @ Für Rekursion. Führt das gerade frische Wort aus. Execute freshly defined definition.
@------------------------------------------------------------------------------
  pushdatos
  ldr tos, =Einsprungpunkt
  ldr tos, [tos]
  b.n callkomma

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "state" @ ( -- addr )
  CoreVariable state
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =state
  bx lr
  .word 0

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "]" @ In den Compile-Modus übergehen  Switch to compile mode
@ -----------------------------------------------------------------------------
  ldr r0, =state
  movs r1, #0 @ true-Flag in State legen
  mvns r1, r1 @ -1
  str r1, [r0] 
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate, "[" @ In den Execute-Modus übergehen  Switch to execute mode
@ -----------------------------------------------------------------------------
  ldr r0, =state
  movs r1, #0 @ false-Flag in State legen.
  str r1, [r0]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, ":" @ ( -- )
@ -----------------------------------------------------------------------------
  push {lr}

  ldr r0, =Datenstacksicherung @ Setzt den Füllstand des Datenstacks zur Probe.
  str psp, [r0]                @ Save current datastack pointer to detect structure mismatch later.

  bl create


  .ifdef registerallocator

    ldr r0, =state
    movs r1, #1 @ So eine Art bx lx-Kompilierzustand-Flag in State legen
    str r1, [r0]

    @ Neue Definition: Auf jeden Fall den Inline-Cache frisch leeren !
    ldr r0, =inline_cache_count
    movs r1, #0
    str r1, [r0]  @ Inline Cache empty

  .else

  pushdaconstw 0xb500 @ Opcode für push {lr} schreiben  Write opcode for push {lr}
  bl hkomma

  ldr r0, =state
  movs r1, #0 @ true-Flag in State legen
  mvns r1, r1 @ -1
  str r1, [r0]

  .endif

  pop {pc}

@ -----------------------------------------------------------------------------
  .ifdef registerallocator
  Wortbirne Flag_immediate_compileonly|Flag_bxlr, ";" @ ( -- )
  .else
  Wortbirne Flag_immediate_compileonly, ";" @ ( -- )
  .endif
@ -----------------------------------------------------------------------------
  push {lr}

  ldr r0, =Datenstacksicherung @ Prüft den Füllstand des Datenstacks.
  ldr r1, [r0]                 @ Check fill level of datastack.
  cmp r1, psp
  beq 1f
    Fehler_Quit " Stack not balanced."
1: @ Stack balanced, ok


  .ifdef registerallocator
    @ Jetzt entweder bx lr oder pop {pc} schreiben.
     
     ldr r0, =state
     ldr r0, [r0]
     adds r1, r0, #1
     beq 3f
       cmp r0, #rawinlinelength + 1  @ Kurze Definitionen mit bis zu 5 Einfach-Opcodes (State zählt ab 1) werden direkt als inline markiert.
       bhi 2f         
         pushdaconstw (Flag_inline | Flag_bxlr ) & ~Flag_visible
         bl setflags
2:     pushdaconstw 0x4770 @ bx lr
       bl hkomma @ bx lr schreiben !

       @ Prinzipiell ist diese Definition Inline-tauglich, auch wenn sie vielleicht ein bisschen zu lang geworden sein könnte.
       @ An dieser Stelle ist es also sicher, aus dem Inline-Cache heraus den RA zu bemühen.
       @ Mal schauen, was daraus wird !

       bl inline_cache_schreiben
       b.n 4f
3:   @ Doch ein pop {pc} ? Dann war wohl etwas enthalten, was nicht durch inline laufen darf.
  .endif

  pushdaconstw 0xbd00 @ Opcode für pop {pc} schreiben  Write opcode for pop {pc}
  bl hkomma
  
4:bl smudge

  ldr r0, =state
  movs r1, #0 @ false-Flag in State legen.
  str r1, [r0]

  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "execute"
execute:
@ -----------------------------------------------------------------------------
  popda r0
  mov pc, r0

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate, "immediate" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_immediate & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "inline" @ ( -- )
setze_inlineflag:
@ -----------------------------------------------------------------------------
  pushdaconst Flag_inline & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate, "compileonly" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_immediate_compileonly & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "0-foldable" @ ( -- )
setze_faltbarflag:
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_0 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "1-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_1 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "2-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_2 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "3-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_3 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "4-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_4 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "5-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_5 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "6-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_6 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "7-foldable" @ ( -- )
@ -----------------------------------------------------------------------------
  pushdaconst Flag_foldable_7 & ~Flag_visible
  b.n setflags

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "constant" @ ( n -- )
@ -----------------------------------------------------------------------------
  push {lr}
  bl create
1:bl literalkomma
  pushdaconstw 0x4770 @ Opcode for bx lr
  bl hkomma
  bl setze_faltbarflag
  bl smudge
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "2constant" @ ( n -- )
@ -----------------------------------------------------------------------------
  push {lr}
  bl create
  swap
  bl literalkomma
  b.n 1b
