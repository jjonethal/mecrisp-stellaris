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

@ Besondere Teile des Compilers, die mit der Dictionarystruktur im Flash zu tun haben.
@ Special parts of compiler tightly linked with generating code for Flash memory.


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "smudge" @ ( -- )
smudge:
@ -----------------------------------------------------------------------------
  push {lr}

  ldr r0, =Dictionarypointer @ Check Dictionarypointer to decide if we are currently compiling for Flash or for RAM.
  ldr r1, [r0]

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n smudge_ram @ Befinde mich im Ram. Schalte um !

  @ -----------------------------------------------------------------------------
  @ Smudge for Flash

    @ Prüfe, ob am Ende des Wortes ein $FFFF steht. Das darf nicht sein !
    @ Es würde als freie Stelle erkannt und später überschrieben werden.
    @ Deshalb wird in diesem Fall hier am Ende eine 0 ans Dictionary angehängt.

    @ Check if there is $FFFF at the end of the definition.
    @ That must not be ! It would be detected as free space on next Reset and simply overwritten.
    @ To prevent it a zero is applied at the end in this case.

    @ r1 enthält den DictionaryPointer.  r1 already contains Dictionarypointer
    subs r1, #2
    ldrh r2, [r1]
    ldr r3, =erasedhalfword
    cmp r2, r3
    bne 1f
      @ writeln "Füge in Smudge eine Enderkennungs-Null ein."
      pushdatos
      ldr tos, =writtenhalfword
      bl hkomma
1:  @ Okay, Ende gut, alles gut. Fine :-)

    bl align4komma @ Align on 4 to make sure the last opcode is actually written to Flash and to fullfill ANS requirement.

    .ifdef flash16bytesblockwrite
      bl align16komma
    .endif

    @ Brenne die gesammelten Flags:  Flash in the collected Flags:
    ldr r0, =FlashFlags
    ldr r0, [r0]
    pushda r0

    ldr r1, =Fadenende
    ldr r1, [r1]
    adds r1, #4 @ Skip Link field

    @ Dictionary-Pointer verbiegen:  Change Dictionarypointer for flashing Flags in (saves code size)
      @ Dictionarypointer sichern
      ldr r2, =Dictionarypointer
      ldr r3, [r2] @ Alten Dictionarypointer auf jeden Fall bewahren  Keep old pointer !

      str r1, [r2] @ Dictionarypointer umbiegen  Change pointer
      bl hkomma    @ Flags einfügen              Insert Flags
      str r3, [r2] @ Dictionarypointer wieder zurücksetzen.

    .ifdef emulated16bitflashwrites
      bl sammeltabelleleerprobe @ Did all 16-Bit Flash writes found their address pair value ?
    .endif                      @ This check is included just to be sure.

    .ifdef universalflashinforth
    bl flushflash
    .endif

    .ifdef flash16bytesblockwrite
      bl flushflash
    .endif

    pop {pc}

  @ -----------------------------------------------------------------------------
  @ Smudge for RAM
smudge_ram:
  bl align4komma @ Align on 4 to fullfill ANS requirement.

  .ifdef erasedflashcontainszero
    .ifdef m0core
      pushdatos
      ldr tos, =Flag_visible
    .else
      pushdaconst Flag_visible
    .endif
  .else
    pushdaconst Flag_visible
  .endif

  b.n setflags_intern

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "setflags" @ ( x -- )
setflags: @ Setflags collects the Flags if compiling for Flash, because we can write Flash field only once.
          @ For RAM, the bits are simply set directly.
@ -----------------------------------------------------------------------------
  push {lr}

setflags_intern:
  ldr r0, =Dictionarypointer
  ldr r1, [r0]

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n setflags_ram @ Befinde mich im Ram. Schalte um !

  @ -----------------------------------------------------------------------------
  @ Setflags for Flash
  ldr r0, =FlashFlags
  ldr r1, [r0]
  orrs r1, tos  @ Flashflags beginnt von create aus immer mit "Sichtbar" = 0.
  str r1, [r0]
  drop
  pop {pc}

  @ -----------------------------------------------------------------------------
  @ Setflags for RAM
setflags_ram:

  @ Eigentlich ganz einfach im Ram:
  popda r2
  @ Hole die Flags des aktuellen Wortes   Fetch flags of current definition
  ldr r0, =Fadenende @ Current definition
  ldr r0, [r0]
  adds r0, #4 @ Skip Link field

  ldrh r1, [r0] @ Flags des zuletzt definierten Wortes holen  Fetch its Flags
  ldr r3, =0xFFFF
  cmp r1, r3

  bne 1f
  movs r1, r2 @ Direkt setzen, falls an der Stelle noch -1 steht  Set directly, if there are no Flags before
  b 2f
1:orrs r1, r2 @ Hinzuverodern, falls schon Flags da sind          If there already are Flags, OR them together.
2:

  strh r1, [r0]
  pop {pc}

 .ltorg

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_1, "aligned" @ ( c-addr -- a-addr )
@ -----------------------------------------------------------------------------
  movs r0, #1
  ands r0, tos
  adds tos, r0

  movs r0, #2
  ands r0, tos
  adds tos, r0
  bx lr

@ If your particular Flash controller doesn't support byte write access,
@ you can remove align, and c, without breaking anything.
@ They are available for the joy of the user, the core only depends on even aligned 16-Bit Flash writes.

  .ifdef charkommaavailable
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "halign" @ ( -- )
alignkomma: @ Macht den Dictionarypointer gerade
@ -----------------------------------------------------------------------------
  ldr r0, =Dictionarypointer
  ldr r1, [r0] @ Hole den Dictionarypointer

  movs r0, #1
  ands r1, r0
  beq 1f

  pushdaconst 0
  b.n ckomma

1: @ Fertig.
  bx lr
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "align" @ ( -- )
align4komma: @ Macht den Dictionarypointer auf 4 gerade
@ -----------------------------------------------------------------------------
  push {lr}

  .ifdef charkommaavailable
  bl alignkomma
  .endif

  ldr r0, =Dictionarypointer
  ldr r1, [r0] @ Hole den Dictionarypointer

  movs r0, #2
  ands r1, r0

  beq 1f

  .ifdef erasedflashcontainszero
    pushdatos
    .ifdef m0core
    ldr tos, =writtenhalfword
    .else
    movw tos, #writtenhalfword
    .endif
    bl hkomma
  .else
    pushdaconst 0
    bl hkomma
  .endif

1: @ Fertig.
  pop {pc}


  .ifdef flash16bytesblockwrite @ Needed for LPC1114FN28...
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "align16," @ ( -- )
align16komma: @ Macht den Dictionarypointer auf 16 gerade
@ -----------------------------------------------------------------------------
  push {lr}

1:ldr r0, =Dictionarypointer
  ldr r1, [r0] @ Hole den Dictionarypointer

  movs r0, #15
  ands r1, r0
  beq 2f

    pushdaconst 0
    bl hkomma
    b 1b

2:pop {pc}
  .endif


  .ifdef charkommaavailable
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "c," @ ( x -- )
ckomma:  @ Fügt 8 Bits an das Dictionary an.
@ -----------------------------------------------------------------------------
  push {lr}
  ldr r0, =Dictionarypointer
  ldr r1, [r0] @ Hole den Dictionarypointer

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n ckomma_ram @ Befinde mich im Ram. Schalte um !

  @ ckomma for Flash:
  pushda r1 @ Adresse auch auf den Stack
  bl c_flashkomma
  b.n ckomma_fertig

ckomma_ram:
  popda r2 @ Inhalt holen
  strb r2, [r1] @ Schreibe das Halbword in das Dictionary

ckomma_fertig:
  pushdaconst 1
  bl allot
  pop {pc}
  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "h," @ ( x -- )
hkomma: @ Fügt 16 Bits an das Dictionary an.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
  uxth tos, tos @ Mask low 16 Bits, just in case.

  @ dup
  @ bl hexdot

  .ifdef registerallocator
    @ Schon geschriebene Opcodes zählen !
    ldr r0, =state
    ldr r1, [r0]
    cmp r1, #0        @ Nicht aus dem Execute-Zustand herausschalten
    beq 1f
    adds r1, #1
    beq 1f            @ Das normale True-Flag nicht erhöhen :-)
      str r1, [r0]
1:
  .endif

  ldr r0, =Dictionarypointer @ Fetch Dictionarypointer to decide if compiling for RAM or for Flash
  ldr r1, [r0] @ Hole den Dictionarypointer

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n hkomma_ram @ Befinde mich im Ram. Schalte um !

  @ hkomma for Flash:
  pushda r1 @ Adresse auch auf den Stack  Put target address on datastack, too !
  bl h_flashkomma

  b.n hkomma_fertig

hkomma_ram: @ Simply write directly if compiling for RAM.
  popda r2 @ Inhalt holen
  strh r2, [r1] @ Schreibe das Halbword in das Dictionary

hkomma_fertig:
  pushdaconst 2
  bl allot

  .ifdef within_os
  bl cacheflush
  .endif

  pop {r0, r1, r2, r3, pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "," @ ( x -- )
komma: @ Fügt 32 Bits an das Dictionary an  Write 32 bits in Dictionary using 16 bit write access only.
@ -----------------------------------------------------------------------------
  push {lr}
  dup
  bl hkomma @ Low-Teil zuerst - Little Endian ! Außerdem stimmen so die Linkfelder.

  lsrs tos, #16 @ High-Teil danach
  bl hkomma
  pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "><," @ ( x -- )
reversekomma: @ Fügt 32 Bits an das Dictionary an   Write 32 bits in Dictionary using 16 bit write access only, but reverse high and low order before.
@ -----------------------------------------------------------------------------
  push {lr}
  dup
  lsrs tos, #16 @ High-Teil danach
  bl hkomma

  bl hkomma @ Low-Teil zuerst - Little Endian ! Außerdem stimmen so die Linkfelder.
  pop {pc}



@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "string," @ ( c-addr length -- )
stringkomma: @ Fügt ein String an das Dictionary an  Write a string in Dictionary.
@ -----------------------------------------------------------------------------
   push {r0, r1, r2, lr}
   @ Schreibt einen String in 16-Bit-Happen ins Dictionary
   @ Write a string in 16-Bit chunks.
   @ write "string, : >"
   @ ddup
   @ bl stype
   @ writeln "<"

   movs r1, #0xFF @ Maximum counted string length
   ands r1, tos   @ Fetch string length
   drop
   popda r0 @ Fetch string address

   cmp r1, #0 @ Zero length string ?
   bne 1f

     pushdaconst 0
     bl hkomma
     pop {r0, r1, r2, pc}

1: @ Write length byte and the first character.
   pushdatos
   ldrb tos, [r0]
   lsls tos, #8
   orrs tos, r1
   bl hkomma
   adds r0, #1 @ Advance pointer
   subs r1, #1 @ One character less left

2: cmp r1, #2 @ Two or more characters left ?
   blo 3f
   @ Write two characters.
   pushdatos
   ldrb tos, [r0, #1]
   lsls tos, #8
   ldrb r2, [r0]
   orrs tos, r2
   bl hkomma
   adds r0, #2 @ Advance pointer
   subs r1, #2 @ One character less left
   b 2b

3: @ One or zero characters left.
   cmp r1, #0
   bne 4f
     pop {r0, r1, r2, pc}

4: @ One character left
   pushdatos
   ldrb tos, [r0]
   bl hkomma
   pop {r0, r1, r2, pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "allot" @ Erhöht den Dictionaryzeiger, schafft Platz !  Advance Dictionarypointer and check if there is enough space left for the requested amount.
allot:  @ Überprüft auch gleich, ob ich mich noch im Ram befinde.
        @ Ansonsten verweigtert Allot seinen Dienst.
@------------------------------------------------------------------------------
  ldr r0, =Dictionarypointer
  ldr r1, [r0]

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n allot_ram @ Befinde mich im Ram. Schalte um !

  @ Allot-Flash:
  popda r2    @ Gewünschte Länge
  adds r1, r2  @ Pointer vorrücken

  ldr r2, =FlashDictionaryEnde

  cmp r1, r2
  blo.n allot_ok
    Fehler_Quit "Flash full"

  @ Allot-Ram:
allot_ram:
  popda r2    @ Gewünschte Länge
  adds r1, r2  @ Pointer vorrücken

@ ldr r2, =RamDictionaryEnde
  ldr r2, =VariablenPointer  @ Am Ende des RAMs liegen die Variablen. Diese sind die Ram-Voll-Grenze...
  ldr r2, [r2]               @ There are variables defined in Flash at the end of RAM. Don't overwrite them !

  cmp r1, r2
  blo.n allot_ok
    Fehler_Quit "Ram full"

allot_ok: @ Alles paletti, es ist noch Platz da !  Everything is fine, just allot it !
  str r1, [r0]
  bx lr


@ There are two sets of Pointers: One set for RAM, one set for Flash Dictionary.
@ They are exchanged if you want to write to the "other" memory type.
@ A small check takes care of the case if you are already in the memory you request.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "compiletoram?"
@ -----------------------------------------------------------------------------
  pushdaconst 0

  @ Prüfe, ob der Dictionarypointer im Ram oder im Flash ist:
  ldr r0, =Dictionarypointer
  ldr r0, [r0]

  ldr r1, =Backlinkgrenze
  cmp r0, r1
  blo.n 1f @ Befinde mich im Flash --> False
    mvns tos, tos @ Im Ram --> True
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "compiletoram"
compiletoram:
@ -----------------------------------------------------------------------------
  @ Prüfe, ob der Dictionarypointer im Ram oder im Flash ist:
  ldr r0, =Dictionarypointer
  ldr r0, [r0]

  ldr r1, =Backlinkgrenze
  cmp r0, r1
  blo.n Zweitpointertausch @ Befinde mich im Flash. Schalte um !
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "compiletoflash"
compiletoflash:
@ -----------------------------------------------------------------------------
  @ Prüfe, ob der Dictionarypointer im Ram oder im Flash ist:
  ldr r0, =Dictionarypointer
  ldr r0, [r0]

  ldr r1, =Backlinkgrenze
  cmp r0, r1
  bhs.n Zweitpointertausch @ Befinde mich im Ram. Schalte um !
  bx lr


Zweitpointertausch:
  ldr r0, =Fadenende
  ldr r1, =ZweitFadenende
  ldr r2, [r0]
  ldr r3, [r1]
  str r2, [r1]
  str r3, [r0]

  ldr r0, =Dictionarypointer
  ldr r1, =ZweitDictionaryPointer
  ldr r2, [r0]
  ldr r3, [r1]
  str r2, [r1]
  str r3, [r0]

  @ In R3 ist nun der aktuelle DictionaryPointer.
  @ Der muss immer unterhalb des VariablenPointers sein !
  @ Compare Dictionarypointer to Variablepointer and give warning if they collide.
  @ That happens if your already have a lot of definitions in RAM,
  @ then define a lot of variables in Flash and then switch back for compiling to RAM.

  ldr r0, =VariablenPointer
  ldr r0, [r0]
  cmp r3, r0
  blo 1f
   push {lr}
   writeln " Variables collide with dictionary"
   pop {pc}

1:bx lr

  .ltorg

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "(create)"
create: @ Nimmt das nächste Token aus dem Puffer,
        @ erstellt einen neuen Kopf im Dictionary und verlinkt ihn.
        @ Fetch new token from buffer, create a new dictionary header and take care of links.
        @ Links are very different for RAM and Flash !
        @ As we can write Flash only once, freshly created definitions have no code at all.
@ -----------------------------------------------------------------------------
  push {lr}
  bl token @ Hole den Namen der neuen Definition.  Fetch name for new definition.
  @ ( Tokenadresse Länge )

  cmp tos, #0     @ Check if token is empty. That happens if input buffer is empty after create.
  bne 1f
    @ Token ist leer. Brauche Stacks nicht zu putzen.
    Fehler_Quit " Create needs name !"

1:@ Tokenname ist okay.               Name is ok.
  @ Prüfe, ob er schon existiert.     Check if it already exists.
  ddup
  @ ( Tokenadresse Länge Tokenadresse Länge )
  bl find
  @ ( Tokenadresse Länge Einsprungadresse Flags )
  drop @ Benötige die Flags hier nicht. Möchte doch nur schauen, ob es das Wort schon gibt.  No need for the Flags...
  @ ( Tokenadresse Länge Einsprungadresse )

  @ Prüfe, ob die Suche erfolgreich gewesen ist.  Do we have a search result ?
  cmp tos, #0
  drop
  @ ( Tokenadresse Länge )
  beq 2f
    ddup
    write "Redefine "
    bl stype @ Den neuen Tokennamen nochmal ausgeben
    write ". "

2:@ ( -- )

  .ifdef charkommaavailable
  bl alignkomma @ Auf zwei gerade machen    Align, just in case. Can be removed if there is no c, available. Add a check for uneven allots instead !
  .endif

  bl align4komma
  .ifndef flash16bytesblockwrite
  bl here @ Das wird die neue Linkadresse
  .endif

  @ ( Tokenadresse Länge Neue-Linkadresse )

  @ Prüfe, ob der Dictionarypointer im Ram oder im Flash ist:
  ldr r0, =Dictionarypointer
  ldr r0, [r0]

  ldr r1, =Backlinkgrenze
  cmp r0, r1
  bhs.n create_ram @ Befinde mich im Ram. Schalte um !

  @ -----------------------------------------------------------------------------
  @ Create for Flash
  @ ( Tokenadresse Länge Neue-Linkadresse )

  ldr r0, =FlashFlags
  .ifdef erasedflashcontainszero
    .ifdef m0core
      ldr r1, =Flag_visible
    .else
      movs r1, #Flag_visible
    .endif
  .else
    movs r1, #Flag_visible
  .endif
  str r1, [r0]  @ Flags vorbereiten  Prepare Flags for collecting

  .ifdef flash16bytesblockwrite
    bl align16komma @ Vorrücken auf die nächste passende Schreibstelle
    pushdaconst 12  @ Es muss ein kompletter 16-Byte-Block für das Linkfeld reserviert werden
    bl allot        @ damit dies später noch nachträglich eingefügt werden kann.

    bl here @ Das wird die neue Linkadresse
  .endif

  pushdaconst 6 @ Lücke für die Flags und Link lassen  Leave space for Flags and Link - they are not known yet at this time.
  bl allot

  bl minusrot
  bl stringkomma @ Den Namen einfügen  Insert Name
  @ ( Neue-Linkadresse )

  @ Jetzt den aktuellen Link an die passende Stelle im letzten Wort einfügen,
  @ falls dort FFFF FFFF steht:
  @ Insert Link to fresh definition into old latest if there is still -1 in its Link field:

  ldr r0, =Fadenende @ Hole das aktuelle Fadenende  Fetch old latest
  ldr r1, [r0]

  ldr r2, [r1] @ Inhalt des Link-Feldes holen  Check if Link is set

  ldr r3, =erasedword
  cmp r2, r3 @ Ist der Link ungesetzt ?      Isn't it ?
  bne 1f

  @ Neuen Link einfügen: Im Prinzip str tos, [r1] über Komma.
  @ Insert new Link. This is str tos, [r1] rerouted over comma because Flash has to be written.
    @ Dictionary-Pointer verbiegen:
      @ Dictionarypointer sichern
      ldr r2, =Dictionarypointer
      ldr r3, [r2] @ Alten Dictionarypointer auf jeden Fall bewahren
      str r1, [r2] @ Dictionarypointer umbiegen
      dup @ ( Neue-Linkadresse Neue-Linkadresse )
      bl komma     @ Link einfügen
      str r3, [r2] @ Dictionarypointer wieder zurücksetzen.

1:@ Backlink fertig gesetzt.  Finished Backlinking.
  @ Fadenende aktualisieren:  Set fresh latest.
  str tos, [r0] @ Neues-Fadenende in die Fadenende-Variable legen
  drop

  b.n create_ende

  @ -----------------------------------------------------------------------------
  @ Create for RAM
create_ram:

  .ifdef flash16bytesblockwrite
    bl here @ Das wird die neue Linkadresse
  .endif

  @ ( Tokenadresse Länge Neue-Linkadresse )

  @ Link setzen  Write Link
  ldr r0, =Fadenende
  pushdatos
  ldr tos, [r0] @ Das alte Fadenende hinein   Old latest
  bl komma

  @ Flags setzen  Set initial Flags to Invisible.
  pushdatos
  ldr tos, =Flag_invisible
  bl hkomma

  @ Das Fadenende aktualisieren  Set new latest
  ldr r0, =Fadenende
  popda r1
  str r1, [r0]

  @ Den Namen schreiben  Write Name
  bl stringkomma


create_ende: @ Save code entry point of current definition for recurse and dodoes
  ldr r0, =Dictionarypointer
  ldr r1, [r0]
  ldr r0, =Einsprungpunkt
  str r1, [r0]

  @ Fertig :-)  Finished :-)
  pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "variable" @ ( n -- )
@ -----------------------------------------------------------------------------
  pushdaconst 1
  b.n nvariable

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "2variable" @ ( d -- )
@ -----------------------------------------------------------------------------
  pushdaconst 2
  b.n nvariable

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "nvariable" @ ( Init-Values Length -- )
nvariable: @ Creates an initialised variable of given length.
@------------------------------------------------------------------------------

  push {lr}
  bl create

  ldr r0, =Dictionarypointer
  ldr r1, [r0]

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n variable_ram @ Befinde mich im Ram. Schalte um !

  @ -----------------------------------------------------------------------------
  @ Variable Flash

  @ Variablenpointer erniedrigen und zurückschreiben
  @ Stelle initialisieren
  @ Code für diese Stelle schreiben

  @ Decrement variable pointer and write back
  @ Initialise allocated location
  @ Write code into Flash for that location - it is ensured that catchflashpointers will
  @ initialise exactly that physical address again on next Reset.
  @ Order of instructions carefully choosen to not corrupt RAM management in any case.

      @ Eine echte Flash-Variable entsteht so, dass Platz im Ram angefordert wird.
      @ Prüfe hier, ob genug Ram da ist !?
      @ Maybe check in future if there is enough RAM left ?

  movs r0, #0x0F @ Maximum length for flash variables !
  ands tos, r0   @ Limit is important to not break Flags for catchflashpointers.

  @ Variablenpointer erniedrigen und zurückschreiben   Decrement variable pointer

  lsls r2, tos, #2 @ Multiply number of elements with 4 to get byte count

  ldr r0, =VariablenPointer
  ldr r1, [r0]
  subs r1, r2  @ Ram voll ?  Maybe insert a check for enough RAM left ?
    ldr r2, =RamDictionaryAnfang
    cmp r1, r2
    bhs 1f
      Fehler_quit "Not enough RAM"
1:str r1, [r0]

  @ Code schreiben:  Write code
  pushda r1
  bl literalkomma    @ Adresse im Ram immer mit movt --> 12 Bytes
  pushdaconstw 0x4770 @ Opcode für bx lr --> 2 Bytes
  bl hkomma

  @ Amount of elements to write is in TOS.
  @ Write code and initialise elements.
  @ r1 is target location in RAM.

  popda r0   @ Fetch amount of cells
  movs r2, r0 @ Save the value for generating flags for catchflashpointers later
  cmp r0, #0 @ If nvariable is called with length zero... Maybe this could be useful sometimes.
  beq 2f

1:str tos, [r1] @ Initialize RAM location
  adds r1, #4
  bl komma      @ Put initialisation value for catchflashpointers in place.
  subs r0, #1
  bne 1b

2:@ Finished.

  pushdaconst Flag_ramallot & ~Flag_visible @ Finally (!) set Flags for RAM usage.
  orrs tos, r2               @ Or together with desired amount of cells.
  bl setflags
  bl smudge
  pop {pc}

  @ -----------------------------------------------------------------------------
  @ Variable RAM
variable_ram:
  @ This is simple: Write code, write value, a classic Forth variable.

  @ pushdatos
  @ mov tos, pc
  @ adds tos, #2
  @ bx lr
  @ Value for Variable

@  pushdaconstw 0x3f04  @ subs    r7, #4
@  bl hkomma
@  pushdaconstw 0x603e  @ str     r6, [r7, #0]
@  bl hkomma
@  pushdaconstw 0x467e  @ mov     r6, pc
@  bl hkomma
@  pushdaconstw 0x3602  @ adds    r6, #2
@  bl hkomma
@  pushdaconstw 0x4770 @ Opcode für bx lr --> 2 Bytes
@  bl hkomma

  @ This is to align dictionary pointer to have variable locations that are always 4-even
    bl here
    movs r0, #2
    ands tos, r0
    drop
    bne 1f
      pushdaconst 0x0036  @ nop = movs tos, tos
      bl hkomma
1:

  pushdatos
  ldr tos, =0x3f04603e @ subs r7, #4    str r6, [r7, #0]
  bl reversekomma
  pushdatos
  ldr tos, =0x467e3602 @ mov r6, pc     adds r6, #2
  bl reversekomma
  pushdaconstw 0x4770  @ bx lr
  bl hkomma

  @ Amount of elements to write is in TOS.

  popda r0   @ Fetch amount of cells
  cmp r0, #0 @ If nvariable is called with length zero... Maybe this could be useful sometimes.
  beq 2f

1:bl komma
  subs r0, #1
  bne 1b

2:@ Finished.

  bl setze_faltbarflag @ Variables always are 0-foldable as their address never changes.
  bl smudge
  pop {pc}


@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "buffer:" @ ( Length -- )
  @ Creates an uninitialised buffer of given bytes length.
@------------------------------------------------------------------------------

  push {lr}
  bl create

  @ Round requested buffer length to next 4-Byte boundary to ensure alignment
  movs r0, #1
  ands r0, tos
  adds tos, r0

  movs r0, #2
  ands r0, tos
  adds tos, r0

  ldr r0, =Dictionarypointer
  ldr r1, [r0]

  ldr r2, =Backlinkgrenze
  cmp r1, r2
  bhs.n rambuffer_ram @ Befinde mich im Ram. Schalte um !

  @ -----------------------------------------------------------------------------
  @ Buffer Flash

  @ Variablenpointer erniedrigen und zurückschreiben   Decrement variable pointer

  ldr r0, =VariablenPointer
  ldr r1, [r0]
  subs r1, tos  @ Ram voll ?  Check for enough RAM left ?
    ldr r2, =RamDictionaryAnfang
    cmp r1, r2
    bhs 1f
      Fehler_quit "Not enough RAM"
1:str r1, [r0]

  @ Code schreiben:  Write code
  pushda r1
  bl literalkomma    @ Adresse im Ram immer mit movt --> 12 Bytes
  pushdaconstw 0x4770 @ Opcode für bx lr --> 2 Bytes
  bl hkomma

  @ Write desired size of buffer at the end of the definition
  bl komma

  @ Finished
  pushdaconstw Flag_buffer_foldable  @ Finally (!) set Flags for buffer usage.
  bl setflags
  bl smudge
  pop {pc}

  @ -----------------------------------------------------------------------------
  @ Buffer RAM
rambuffer_ram:
  @ This is simple: Write code, allot space, a classic Forth buffer.

  @ This is to align dictionary pointer to have variable locations that are always 4-even
    bl here
    movs r0, #2
    ands tos, r0
    drop
    bne 1f
      pushdaconst 0x0036  @ nop = movs tos, tos
      bl hkomma
1:

  pushdatos
  ldr tos, =0x3f04603e @ subs r7, #4    str r6, [r7, #0]
  bl reversekomma
  pushdatos
  ldr tos, =0x467e3602 @ mov r6, pc     adds r6, #2
  bl reversekomma
  pushdaconstw 0x4770  @ bx lr
  bl hkomma

  bl allot @ Reserve space. Allot checks for itself if there is enough RAM left.

  bl setze_faltbarflag @ Buffers always are 0-foldable as their address never changes.
  bl smudge
  pop {pc}


  .ltorg @ Mal wieder Konstanten schreiben


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dictionarystart"
dictionarystart: @ ( -- Startadresse des aktuellen Dictionaryfadens )
                 @ Da dies je nach Ram oder Flash unterschiedlich ist...
                 @ Einmal so ausgelagert.
                 @ Entry point for dictionary searches.
                 @ This is different for RAM and for Flash and it changes with new definitions.
@ -----------------------------------------------------------------------------

  @ Prüfe, ob der Dictionarypointer im Ram oder im Flash ist:  Are we compiling into RAM or into Flash ?
  ldr r0, =Dictionarypointer
  ldr r0, [r0]

  ldr r1, =Backlinkgrenze
  pushdatos
  cmp r0, r1
  bhs 1f
  ldr tos, =CoreDictionaryAnfang @ Befinde mich im Flash mit Backlinks. Muss beim CoreDictionary anfangen:        In Flash: Start with core dictionary.
  bx lr

1:ldr tos, =Fadenende
  ldr tos, [tos]                   @ Oberhalb der Backlinkgrenze bin ich im Ram, kann mit dem Fadenende beginnen.   In RAM:   Start with latest definition.
  bx lr


@  ite lo
@    ldrlo r2, =CoreDictionaryAnfang @ Befinde mich im Flash mit Backlinks. Muss beim CoreDictionary anfangen:        In Flash: Start with core dictionary.
@    movhs r2, r3                    @ Oberhalb der Backlinkgrenze bin ich im Ram, kann mit dem Fadenende beginnen.   In RAM:   Start with latest definition.
@  pushda r2
@  bx lr


  @ Zwei Möglichkeiten: Vorwärtslink ist $FFFFFFFF --> Ende gefunden
  @ Oder Vorwärtslink gesetzt, aber an der Stelle der Namenslänge liegt $FF. Dann ist das Ende auch da.
  @ Diese Variante tritt auf, wenn nichts hinzugetan wurde, denn im festen Teil ist der Vorwärtslink
  @ immer gesetzt und zeigt auf den Anfang des Schreib/Löschbaren Teils.

  @ There are two possibilities to detect end of dictionary:
  @ - Link is $FFFFFFFF
  @ - Link is set, but points to memory that contains $FF in name length.
  @ Last case happens if nothing is compiled yet, as the latest link in core always
  @ points to the beginning of user writeable/eraseable part of dictionary space.

  @ Dictionary entry structure:
  @ 4 Bytes Link ( 2-aligned on M3, 4-aligned on M0 )
  @ 2 Bytes Flags
  @ 1 Byte  Name length
  @         Counted Name string and sometimes a padding zero to realign.
  @         Code.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dictionarynext" @ ( address -- address flag )
dictionarynext: @ Scans dictionary chain and returns true if end is reached.
@ -----------------------------------------------------------------------------
  push {r0, r1, lr}
  ldr r1, [tos]
  ldr r0, =erasedword
  cmp r1, r0
  beq 1f
    ldrb r0, [r1, #6]
    cmp r0, #erasedbyte
    beq 1f
      movs tos, r1
      pushdaconst 0
      pop {r0, r1, pc}

1:pushdatos
  movs tos, #0
  mvns tos, tos
  pop {r0, r1, pc}

@ : dictionarynext ( address -- address flag )
@     @ dup $FFFFFFFF =                \ Check if link points to another definition or into free space.
@     if -1 else dup 6 + c@ $FF = then \ $FF instead of Name length denotes end of dictionary in Flash, too.
@ ;


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "skipstring"
@ -----------------------------------------------------------------------------
    @ String überlesen und Pointer gerade machen
    ldrb r1, [tos] @ Länge des Strings holen      Fetch length
    adds r1, #1   @ Plus 1 Byte für die Länge   One more for length byte

    movs r2, #1  @ Wenn es ungerade ist, noch einen mehr:   Maybe one more for aligning.
    ands r2, r1

    adds r1, r2
    adds tos, r1
    bx lr

@ -----------------------------------------------------------------------------
skipstring: @ Überspringt einen String, dessen Adresse in r0 liegt.  Skip string which address is in r0.
@ -----------------------------------------------------------------------------
  push {r1, r2}
    @ String überlesen und Pointer gerade machen
    ldrb r1, [r0] @ Länge des Strings holen      Fetch length
    adds r1, #1   @ Plus 1 Byte für die Länge   One more for length byte

    movs r2, #1  @ Wenn es ungerade ist, noch einen mehr:   Maybe one more for aligning.
    ands r2, r1

    adds r1, r2
    adds r0, r1
  pop {r1, r2}
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "find"
find: @ ( address length -- Code-Adresse Flags )
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r4, r5, lr}

  @ r0  Helferlein      Scratch
  @ r1  Flags           Flags

  @ r2  Zieladresse     Destination Address
  @ r3  Zielflags       Destination Flags

  @ r4  Adresse des zu suchenden Strings  Address of string that is searched for
  @ r5  Dessen Länge                      Length

  @ TOS Hangelpointer   Pointer for crawl the dictionary

  movs r2, #0  @ Noch keinen Treffer          No hits yet
  movs r3, #0  @ Und noch keine Trefferflags  No hits have no Flags

  popda r5 @ Fetch string length
  popda r4 @ Fetch string address

  bl dictionarystart

1:@ Loop through the dictionary
  ldr r0, =Flag_invisible
  ldrh r1, [tos, #4] @ Fetch Flags to see if this definition is visible.
  cmp r0, r1         @ Skip this definition if invisible
  beq 2f

  @ Definition is visible. Compare the name !
  dup
  adds tos, #6 @ Skip Link and Flags
  bl count     @ Prepare an address-length string

  pushda r4
  pushda r5
  bl compare

  cmp tos, #0 @ Flag vom Vergleich prüfen  Ckeck for Flag from string comparision
  drop
  beq 2f

    @ Gefunden ! Found !
    @ String überlesen und Pointer gerade machen   Skip name string
    adds r0, tos, #6
    bl skipstring

    movs r2, r0 @ Codestartadresse  Note Code start address
    movs r3, r1 @ Flags             Note Flags

    @ Prüfe, ob ich mich im Flash oder im Ram befinde.  Check if in RAM or in Flash.
    ldr r0, =Backlinkgrenze
    cmp r2, r0
    bhs 3f @ Im Ram beim ersten Treffer ausspringen. Search is over in RAM with first hit.
           @ Im Flash wird weitergesucht, ob es noch eine neuere Definition mit dem Namen gibt.
           @ If in Flash, whole dictionary has to be searched because of backwards link dictionary structure.

2:@ Weiterhangeln  Continue crawl.
  bl dictionarynext
  popda r0
  beq 1b


3:@ Durchgehangelt. Habe ich etwas gefunden ?  Finished. Found something ?
  @ Zieladresse gesetzt, also nicht Null bedeutet: Etwas gefunden !    Destination address <> 0 means successfully found.
  movs tos, r2  @ Zieladresse    oder 0, falls nichts gefunden            Address = 0 means: Not found. Check for that !
  pushda r3     @ Zielflags      oder 0  --> @ ( 0 0 - Nicht gefunden )   Push Flags on Stack. ( Destination-Code Flags ) or ( 0 0 ).

  pop {r0, r1, r2, r3, r4, r5, pc}

@ -----------------------------------------------------------------------------
find_not_found: @ Internal use. Gives "not found." message if find is not successful.
@ -----------------------------------------------------------------------------
  push {lr}

  movs r1, tos  @ Save string address for later use
  ldr r0, [psp]

  bl find
  ldr r2, [psp] @ Probe entry address
  cmp r2, #0
  bne 1f
    bl not_found_addr_r0_len_r1
1:pop {pc}
