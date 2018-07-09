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

@ Code generator for M0

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "registerliteral," @ ( x Register -- )
registerliteralkomma:  @ Compile code to put a literal constant into a register.
                       @ Shortest possible way.
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r4, r5, lr}

  @ Ist die gewünschte Konstante eine kleine negative Zahl ?
  @ Is desired constant a small negative number ?

  ldr r3, =0xFFFF0000
  ldr r0, [psp]
  ands r0, r3
  cmp r0, r3
  bne 1f

    ldr r0, [psp]
    mvns r0, r0   @ Invert constant
    str r0, [psp]

    push {tos} @ Save desired register

    bl registerliteralkomma_intern
    
    pushdaconstw 0x43C0 @ Opcode: mvns r0, r0
    pop {r0}
    orrs tos, r0
    lsls r0, #3
    orrs tos, r0
    bl hkomma
    pop {r0, r1, r2, r3, r4, r5, pc}

1:bl registerliteralkomma_intern
  pop {r0, r1, r2, r3, r4, r5, pc}

@ -----------------------------------------------------------------------------
registerliteralkomma_intern:
@ -----------------------------------------------------------------------------
  push {lr}

  @ TOS: Konstante
  @ r0:  Helferlein
  @ r1:  LSLS-Opcode, fertig vorbereitet für den gewünschten Zielregister, aber noch ohne Schubweite.
  @ r2:  Restschub
  @ r3:  $FF
  @ r4:  Aktueller Schub
  @ r5:  Opcode für movs oder adds

  popda r5 @ Hole die Registermaske  Fetch register mask

  @ Generate opcode for lsls target, target, #... 
  movs r1, r5
  lsls r1, #3
  orrs r1, r5

  @ Generate opcode for movs target, #...
  lsls r5, #8 @ Den Register um 8 Stellen schieben
  ldr r0, =0x2000 @ MOVS-Opcode für gewünschten Register
  orrs r5, r0
  
  movs r3, #0xFF  @ Maske für die Bits, die in die Opcodes kommen

  @ How far has constant to be shifted right so that it fits in the 8 lowest bits ?
  movs r2, #0  @ Restschub anfangs auf Null
1:movs r0, tos @ lsrs r0, tos, r2  
  lsrs r0, r2  @ Konstante schieben
  bics r0, r3  @ Maske anwenden
  beq 2f       @ Oberer Teil leer ?
    adds r2, #1  @ Ein Bit weiter schieben.
    b 1b

  @ Generate MOVS/ADDS opcode for the shifted highest 8 bits of constant.
2:movs r0, tos @ lsrs r0, tos, r2
  lsrs r0, r2  @ Konstante passend schieben
  ands r0, r3  @ 8 Bits für den Opcode maskieren
  orrs r0, r5  @ Opcode zusammensetzen
  pushda r0    @ Opcode schreiben
  bl hkomma
  ldr r0, =0x1000 @ 0x2r00 (MOVS) or 0x1000 = 0x3r00 (ADDS)
  orrs r5, r0     @ Switch to ADDS-Opcode für alle künftigen Durchläufe

  @ Remove the bits just processed from the given constant.
  movs r0, r3  @ lsls r0, r3, r2
  lsls r0, r2  @ Maske passend schieben
  bics tos, r0 @ Bearbeitete Bits in der Konstanten wegmaskieren
  beq 5f @ Wenn die Konstante dabei Null wird, ist die Aufgabe erledigt.

  @ How far have the remaining bits to be shifted so that they fit in the 8 lowest bits ?
  movs r4, #0  @ Aktueller Schub Null
3:movs r0, tos @ lsrs r0, tos, r4
  lsrs r0, r4  @ Konstante schieben
  bics r0, r3  @ Maske anwenden
  beq 4f       @ Oberer Teil leer ?
    adds r4, #1  @ Ein Bit weiter schieben.
    b 3b

  @ Generate a LSLS opcode to shift the already opcoded Bits towards their destination place.
  @ This is done in steps as more Bits are added "on the fly".
4:subs r0, r2, r4 @ Restschub - aktueller Schub muss in LSLS opcodiert werden.
  @ lsls-Opcode generieren, Schub in r0
  pushda r1 
  lsls r0, #6
  orrs tos, r0
  bl hkomma
  
  movs r2, r4
  b 2b

  @ Is there some shift left ? Generate a final LSLS opcode if necessary.
5:cmp r2, #0
  beq 6f
    @ lsls-Opcode generieren, Schub in r2
    pushda r1 
    lsls r2, #6
    orrs tos, r2
    bl hkomma

6:drop @ Konstante vergessen  Drop constant
  pop {pc}


@ -----------------------------------------------------------------------------
registerliteralkommalang:  @ Compile code to put a literal constant into a register.
                           @ Always on maximum length, needed for dodoes
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r4, lr}

  @ r0: Konstante       Constant
  @ r1: Zielregister    Target register 
  @ r2: Helferlein      Temporary
  @ r3: Helferlein      Temporary
  @ r4: lsls Opcode

  @ Sequenz generieren:
  @ Literal sei $ 76 54 32 10
  @ Kann dies lösen, indem ich adds und orrs benutze.

  @ Ewig lang ! Könnte einige der Stellen auch aussparen. Die brauchen dann keine adds-Paare.
  @ Zum ersten Ausprobieren jedoch noch keine tieferen Optimierungen.

  @ movs target, #76  @ 76

  @ lsls target, #4   @ 7600
  @ adds target, #54  @ 7654

  @ lsls target, #4   @ 765400
  @ adds target, #32  @ 765432

  @ lsls target, #4   @ 76543200
  @ adds target, #10  @ 76543210


  popda r1    @ Hole die Registermaske  Fetch register mask

  @ Generate opcode for lsls target, target, #8.
  ldr r4, =0x0200  @ Opcode lsls r0, r0, #8
  orrs r4, r1      @ lsls target, r0, #8
  lsls r1, #3
  orrs r4, r1      @ lsls target, target, #8

  lsls r1, #5 @ Den Register um 3+5=8 Stellen schieben   Shift register 5+3=8 places
  popda r0    @ Hole die Konstante                       Fetch constant

  @ -----------------------------------
  lsrs r2, r0, #24 @ 76
  movs r3, #0xFF
  ands r2, r3
  
  ldr r3, =0x2000  @ MOVS-Opcode
  orrs r3, r1      @ Target register
  orrs r3, r2

  pushda r3
  bl hkomma

  @ -----------------------------------
  pushda r4 @ lsls target, target, #8
  bl hkomma
  
  @ -----------------------------------
  lsrs r2, r0, #16 @ 54
  movs r3, #0xFF
  ands r2, r3
  
  ldr r3, =0x3000  @ ADDS-Opcode
  orrs r3, r1      @ Target register
  orrs r3, r2

  pushda r3
  bl hkomma

  @ -----------------------------------
  pushda r4 @ lsls target, target, #8
  bl hkomma

  @ -----------------------------------
  lsrs r2, r0, #8 @ 32
  movs r3, #0xFF
  ands r2, r3
  
  ldr r3, =0x3000  @ ADDS-Opcode
  orrs r3, r1      @ Target register
  orrs r3, r2

  pushda r3
  bl hkomma

  @ -----------------------------------
  pushda r4 @ lsls target, target, #8
  bl hkomma

  @ -----------------------------------
  @ lsrs r2, r0, #0  @ 10
  movs r2, r0
  movs r3, #0xFF   
  ands r2, r3
  
  ldr r3, =0x3000  @ ADDS-Opcode
  orrs r3, r1      @ Target register
  orrs r3, r2

  pushda r3
  bl hkomma

  pop {r0, r1, r2, r3, r4, pc}

@  f2e:	0236      	lsls	r6, r6, #8

@ 2000040C : 0000B500  >  push {lr}
@ 2000040E : 00003F04  2>  subs psp, #4
@ 20000410 : 0000603E  4>  str tos, [psp, #0]
@ 20000412 : 00000676  6>  76
@ 20000414 : 00000236  8>
@ 20000416 : 00000754  10>  54
@ 20000418 : 00000236  12>
@ 2000041A : 00000732  14>  32
@ 2000041C : 00000236  16>
@ 2000041E : 00000710  18>  10
@ 20000420 : 0000BD00  > pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "call," @ ( Zieladresse -- )
callkomma:  @ Versucht einen möglichst kurzen Aufruf einzukompilieren. 
            @ Write a call to destination with the shortest possible opcodes.
            @ Je nachdem: bl ...                            (4 Bytes)
            @             movw r0, ...              blx r0  (6 Bytes)
            @             movw r0, ... movt r0, ... blx r0 (10 Bytes)
@ ----------------------------------------------------------------------------

  push {r0, r1, r2, r3, lr}
  movs r3, tos @ Behalte Sprungziel auf dem Stack  Keep destination on stack
  @ ( Zieladresse )

  bl here
  popda r0 @ Adresse-der-Opcodelücke  Where the opcodes shall be inserted...
  
  subs r3, r0     @ Differenz aus Lücken-Adresse und Sprungziel bilden   Calculate relative jump offset
  subs r3, #4     @ Da der aktuelle Befehl noch läuft und es komischerweise andere Offsets beim ARM gibt.  Current instruction still running...

  @ 22 Bits für die Sprungweite mit Vorzeichen - 
  @ also habe ich 21 freie Bits, das oberste muss mit dem restlichen Vorzeichen übereinstimmen. 

  @ BL opcodes support 22 Bits jump range - one of that for sign.
  @ Check if BL range is enough to reach target:

  ldr r1, =0xFFC00001   @ 21 Bits frei
  ands r1, r3
  cmp r1, #0  @ Wenn dies Null ergibt, positive Distanz ok.
  beq 1f

  ldr r2, =0xFFC00000
  cmp r1, r2
  beq 1f      @ Wenn es gleich ist: Negative Distanz ok.

    @ bl callkommakurz @ Too far away - BL cannot reach that destination. Time for long distance opcodes :-)
        adds tos, #1 @ Ungerade Adresse für Thumb-Befehlssatz
        pushdaconst 0 @ Register r0
        bl registerliteralkomma
        pushdaconstw 0x4780 @ blx r0
        bl hkomma
    pop {r0, r1, r2, r3, pc}

1:

  @ Within reach of BL. Generate the opcode !

  @ ( Zieladresse )
  drop
  @ ( -- )
  @ BL: S | imm10 || imm11
  @ Also 22 Bits, wovon das oberste das Vorzeichen sein soll.

  @ r3 enthält die Distanz:

  lsrs r3, #1            @ Bottom bit ignored
    ldr r0, =0xF000F800  @ Opcode-Template

    ldr r1, =0x7FF       @ Bottom 11 bits of immediate
    ands r1, r3
    orrs r0, r1

  lsrs r3, #11

    ldr r1, =0x3FF       @ 10 more bits shifted to second half
    ands r1, r3
    lsls r1, #16
    orrs r0, r1

  lsrs r3, #10         

    @ands r1, r3, #1      @ Next bit, treated as sign, shifted into bit 26.
    movs r1, #1
    ands r1, r3
    lsls r1, #26
    orrs r0, r1

  @ Opcode fertig in r0
  pushda r0
  bl reversekomma  @ Write finished opcode into Dictionary.

  pop {r0, r1, r2, r3, pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "literal," @ ( x -- )
literalkomma: @ Save r1, r2 and r3 !
@ -----------------------------------------------------------------------------
  push {lr}

@     128:	3f04      	subs	r7, #4
@     12a:	603e      	str	r6, [r7, #0]

  pushdaconstw 0x3f04  @ subs psp, #4
  bl hkomma
  pushdaconstw 0x603e  @ str tos, [psp, #0]
  bl hkomma

  pushdaconst 6 @ Target register r6=tos
  bl registerliteralkomma

  pop {pc}


.ifdef m0core_start_offset
  .equ dodoesaddr, (dodoes - addresszero) + m0core_start_offset @ To circumvent address relocation issues
.else
  .equ dodoesaddr, dodoes - addresszero @ To circumvent address relocation issues
.endif

.equ dodoes_byte1, ((dodoesaddr + 1)>>24) & 255
.equ dodoes_byte2, ((dodoesaddr + 1)>>16) & 255
.equ dodoes_byte3, ((dodoesaddr + 1)>> 8) & 255
.equ dodoes_byte4,  (dodoesaddr + 1)      & 255

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "create" @ ANS-Create with default action.
@ -----------------------------------------------------------------------------
  push {lr}
  bl builds

  @ Copy of the inline-code of does>

  .ifdef does_above_64kb
    movs r0, #dodoes_byte1
    lsls r0, #8
    adds r0, #dodoes_byte2
    lsls r0, #8
    adds r0, #dodoes_byte3
    lsls r0, #8
    adds r0, #dodoes_byte4
  .else @ High word not needed as dodoes in core is in the lowest 64 kb.
    movs r0, #dodoes_byte3
    lsls r0, #8
    adds r0, #dodoes_byte4
  .endif

  blx r0 @ Den Aufruf mit absoluter Adresse einkompilieren. Perform this call with absolute addressing.

    @ Die Adresse ist hier nicht auf dem Stack, sondern in LR. LR ist sowas wie "TOS" des Returnstacks.
    @ Address is in LR which is something like "TOS in register" of return stack.

  pushdatos
  mov tos, lr
  subs tos, #1 @ Denn es ist normalerweise eine ungerade Adresse wegen des Thumb-Befehlssatzes.  Align address. It is uneven because of Thumb-instructionset bit set.
  
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "does>"
does: @ Gives freshly defined word a special action.
      @ Has to be used together with <builds !
@------------------------------------------------------------------------------
    @ At the place where does> is used, a jump to dodoes is inserted and
    @ after that a pushda lr to put the address of the definition entering the does>-part
    @ on datastack. This is a very special implementation !

  @ Universeller Sprung zu dodoes:  Universal jump to dodoes. There has already been a push {lr} before in the definition that calls does>.
  @ Davor ist in dem Wort, wo does> eingefügt wird schon ein push {lr} gewesen.
  @ movw r0, #:lower16:dodoes+1
  @  movt r0, #:upper16:dodoes+1   
  @ blx r0 @ Den Aufruf mit absoluter Adresse einkompilieren. Perform this call with absolute addressing.

  .ifdef does_above_64kb
    movs r0, #dodoes_byte1
    lsls r0, #8
    adds r0, #dodoes_byte2
    lsls r0, #8
    adds r0, #dodoes_byte3
    lsls r0, #8
    adds r0, #dodoes_byte4
  .else @ High word not needed as dodoes in core is in the lowest 64 kb.
    movs r0, #dodoes_byte3
    lsls r0, #8
    adds r0, #dodoes_byte4
  .endif

  blx r0 @ Den Aufruf mit absoluter Adresse einkompilieren. Perform this call with absolute addressing.

    @ Die Adresse ist hier nicht auf dem Stack, sondern in LR. LR ist sowas wie "TOS" des Returnstacks.
    @ Address is in LR which is something like "TOS in register" of return stack.

  pushdatos
  mov tos, lr
  subs tos, #1 @ Denn es ist normalerweise eine ungerade Adresse wegen des Thumb-Befehlssatzes.  Align address. It is uneven because of Thumb-instructionset bit set.

  @ Am Ende des Wortes wird ein pop {pc} stehen, und das kommt prima hin.
  @ At the end of the definition there will be a pop {pc}, that is fine.
  bx lr @ Very important as delimiter as does> itself is inline.


dodoes:
  @ Hier komme ich an. Die Adresse des Teils, der als Zieladresse für den Call-Befehl genutzt werden soll, befindet sich in LR.

  @ The call to dodoes never returns.
  @ Instead, it compiles a call to the part after its invocation into the dictionary
  @ and exits through two call layers.  

  @ Momentaner Zustand von Stacks und LR:  Current stack:
  @    ( -- )
  @ R: ( Rücksprung-des-Wortes-das-does>-enthält )    R:  ( Return-address-of-the-definition-that-contains-does> )
  @ LR Adresse von dem, was auf den does>-Teil folgt  LR: Address of the code following does>

  @ Muss einen Call-Befehl an die Stelle, die in LR steht einbauen.
  @ Generate a long call to the destination in LR that is inserted into the hole alloted by <builds.

  @ Präpariere die Einsprungadresse, die via callkomma eingefügt werden muss.
  @ Prepare the destination address

  pushdatos    @ Brauche den Link danach nicht mehr, weil ich über die in dem Wort das does> enthält gesicherte Adresse rückspringe
  mov tos, lr  @ We don't need this Link later because we return with the address saved by the definition that contains does>.
  subs tos, #1 @ Einen abziehen. Diese Adresse ist schon ungerade für Thumb-2, aber callkomma fügt nochmal eine 1 dazu. 
               @ Subtract one. Adress is already uneven for Thumb-instructionset, but callkomma will add one anyway.

    @ Dictionary-Pointer verbiegen:
      @ Dictionarypointer sichern
      ldr r2, =Dictionarypointer
      ldr r3, [r2] @ Alten Dictionarypointer auf jeden Fall bewahren  Save old Dictionarypointer.

  ldr r1, =Einsprungpunkt @ Get the address the long call has to be inserted.
  ldr r1, [r1] @ r1 enthält jetzt die Codestartadresse der aktuellen Definition.

  .ifdef flash8bytesblockwrite
    @ Special case with different alignment depending if compiling into Flash (8-even) or into RAM (4-even).

    ldr r0, =Backlinkgrenze
    cmp r3, r0
    bhs.n dodoes_ram

2:    movs r0, #7
      ands r0, r1
      cmp r0, #6
      beq 1f
        adds r1, #2
        b 2b

dodoes_ram:
  .endif

  .ifdef flash16bytesblockwrite
    @ Special case with different alignment depending if compiling into Flash (16-even) or into RAM (4-even).

    ldr r0, =Backlinkgrenze
    cmp r3, r0
    bhs.n dodoes_ram

2:    movs r0, #15
      ands r0, r1
      cmp r0, #14
      beq 1f
        adds r1, #2
        b 2b

dodoes_ram:
  .endif

  @ This is to align dictionary pointer to have does> target locations that are always 4-even
  movs r0, #2
  ands r0, r1
  bne 1f
    adds r1, #2
1:
  
  adds r1, #2  @ Am Anfang sollte das neudefinierte Wort ein push {lr} enthalten, richtig ?
               @ Skip the push {lr} opcode in that definition.

  @ Change the Dictionarypointer to insert the long call with the normal comma mechanism.
      str r1, [r2] @ Dictionarypointer umbiegen
      @  bl callkommalang @ Aufruf einfügen
               adds tos, #1 @ Ungerade Adresse für Thumb-Befehlssatz
               pushdaconst 0 @ Register r0
               bl registerliteralkommalang
               pushdaconstw 0x4780 @ blx r0
               bl hkomma

      str r3, [r2] @ Dictionarypointer wieder zurücksetzen.

  bl smudge
  pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "<builds"
builds: @ Beginnt ein Defining-Wort.  Start a defining definition.
        @ Dazu lege ich ein neues Wort an, lasse eine Lücke für den Call-Befehl. Create a new definition and leave space for inserting the does>-Call later.
        @ Keine Strukturkennung  No structure pattern matching here !
@ -----------------------------------------------------------------------------
  push {lr}
  bl create       @ Neues Wort wird erzeugt

  .ifdef flash8bytesblockwrite
    @ It is necessary when Flash writes are aligned on 8.
    @ So if we are compiling into Flash, we need to make sure that
    @ the block the user might write to later is properly aligned.
    ldr r0, =Dictionarypointer
    ldr r1, [r0]

    ldr r2, =Backlinkgrenze
    cmp r1, r2
    bhs.n builds_ram

      @ See where we are. The sequence written for <builds does> is 18 Bytes long on M0.
      @ So we need to advance to 8n + 6 so that the opcode sequence ends on a suitable border.

2:    bl here
      movs r0, #7
      ands tos, r0
      cmp tos, #6
      drop
      beq 1f
        pushdaconst 0x0036  @ nop = movs tos, tos
        bl hkomma
        b 2b

builds_ram:
  .endif

  .ifdef flash16bytesblockwrite
    @ It is necessary for LPC1114FN28 that Flash writes are aligned on 16.
    @ So if we are compiling into Flash, we need to make sure that
    @ the block the user might write to later is properly aligned.
    ldr r0, =Dictionarypointer
    ldr r1, [r0]

    ldr r2, =Backlinkgrenze
    cmp r1, r2
    bhs.n builds_ram

      @ See where we are. The sequence written for <builds does> is 18 Bytes long on M0.
      @ So we need to advance to 16n + 14 so that the opcode sequence ends on a suitable border.

2:    bl here
      movs r0, #15
      ands tos, r0
      cmp tos, #14
      drop
      beq 1f
        pushdaconst 0x0036  @ nop = movs tos, tos
        bl hkomma
        b 2b

builds_ram:
  .endif

  @ This is to align dictionary pointer to have does> target locations that are always 4-even
    bl here
    movs r0, #2
    ands tos, r0
    drop
    bne 1f
      pushdaconst 0x0036  @ nop = movs tos, tos
      bl hkomma
1:

  pushdaconstw 0xb500 @ Opcode für push {lr} schreiben  Write opcode for push {lr}
  bl hkomma

  pushdaconst 16  @ Hier kommt ein Call-Befehl hinein, aber ich weiß die Adresse noch nicht.
  bl allot        @ Lasse also eine passende Lücke frei !  Leave space for a long call opcode sequence.
  pop {pc}

  .ltorg @ Mal wieder Konstanten schreiben
