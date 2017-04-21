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

@ Case-Struktur
@ Case structure

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "case"
  @ ( -- 0 8 )
case:
@------------------------------------------------------------------------------
  push {lr}
  bl push_lr_nachholen
  pushdaconst 0 @ Zahl der Zweige    Current number of branches
  pushdaconst 8 @ Strukturerkennung  Structure pattern
  pop {pc}

@ Small test:
@ : wahl case 1 of ." Eins" endof 2 of ." Zwei" endof dup 3 = ?of ." Drei?" endof ." Andere" endcase ;

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "?of"
  @ ( ... #of 8 -- ... addr #of+1 9 )
  @ Nimmt einen Flag statt einer Konstanten entgegen.
  @ Kann so eigene Vergleiche aufbauen.
  @ Takes flag instead of constant to build your own comparisions.
@------------------------------------------------------------------------------
  ldr r0, =struktur_qof
  b.n of_inneneinsprung

struktur_qof: @ Will be inlined.
  subs tos, #1
  sbcs tos, tos
  drop
  @ bne... is generated here.
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly|Flag_allocator, "of"
  @ ( ... #of 8 -- ... addr #of+1 9 )
@------------------------------------------------------------------------------
  ldr r0, =struktur_of

of_inneneinsprung:
  cmp tos, #8                  @ Check for structure pattern: Give error message and quit if wrong.
  beq 1f
  b.n strukturen_passen_nicht
1:drop

  push {lr}

  pushda r0
  bl inlinekomma  @ Insert opcodes for structure

of_opcodiereinsprung:
  @ ( #of --> Addr #of+1)

  bl branch_v @ here 2 allot
  swap
  adds tos, #1 @ Eine Adresse mehr, die abzuarbeiten ist  One more location a branch opcode has to be written in later.

  pushdaconst 9 @ Strukturerkennung bereitlegen  Structure pattern

  pushdaconstw 0xcf40 @ Opcode for ldmia r7!, {r6}
  bl hkomma

  pop {pc}

@------------------------------------------------------------------------------

  cmp tos, #8                  @ Check for structure pattern: Give error message and quit if wrong.
  beq 1f
  b.n strukturen_passen_nicht
1:drop

  push {lr}

  @ Mich interessieren nur die beiden obersten Elemente, die verglichen werden sollen.  
  bl expect_two_elements @ Mindestens 2 Elemente

  bl tidyup_register_allocator_5os
  bl tidyup_register_allocator_4os
  bl tidyup_register_allocator_3os @ Maximal 2 Elemente, das dritte gleich in den Stack schieben.
  
  @ Jetzt habe ich genau zwei Elemente im Allokator.
  @ NOS bleibt im Falle von CASE eigentlich die ganze Zeit gleich - erwarte NOS also in jedem Fall in einem Register.

  pushdaconstw 0x4280 @ cmp r0, r0    
  bl expect_nos_in_register @ Dieser Register ist anschließend in r1.
  orrs tos, r1

  @ TOS könnte eine Konstante sein. Diese darf ich jetzt aber nicht über die beiden Konstantenregister generieren...
  ldr r2, [r0, #offset_state_tos]
  cmp r2, #constant
  bne 2f
    @ TOS ist eine Konstante.
    @ Kleine Konstanten direkt als cmp-opcode schreiben:
    ldr r2, [r0, #offset_constant_tos]
    cmp r2, #0xFF
    bhi 3f
      @ Kleine Konstante:
      drop
      pushdaconstw 0x2800
      orrs tos, r2
      lsls r1, #8
      orrs tos, r1
      b.n 4f 
    
3:  

.ifndef m0core
  @ TOS ist eine Konstante, aber zu groß für Imm8.
  @ Vielleicht passt sie in Imm12 ?

        pushdatos
        ldr tos, [r0, #offset_constant_tos]
        bl twelvebitencoding @ Hole sie und prüfe, ob sie als Imm12 darstellbar ist.
        ldmia psp!, {r2} @ Entweder die Bitmaske oder wieder die Konstante

        cmp tos, #0
        drop   @ Preserves Flags !
        beq 3f
          @ Die Konstante lässt sich als Imm12 darstellen - fein ! Bitmaske liegt in r1 bereit
          @ Prüfe nun den Opcode, und ersetze ihn, falls möglich.

          @ drop @ Den alten cmp r0, r0 Opcode vergessen
          @ pushdatos
          ldr tos, =0xF1B00F00 @ cmp r0, #Imm12 = cmp pc, r0, #Imm12
          orrs tos, r2

          orrs tos, tos, r1, lsl #16 @ Quellregister hinzufügen
          bl reversekomma
          b 5f
3:
.endif

    @ Konstante zu groß. Lade die Konstante in einen freien Register:

    bl expect_tos_in_register
    movs r2, r1
  
2:@ TOS ist auch ein Register.
  lsls r2, #3
  orrs tos, r2
    
4:bl hkomma
  
5:bl eliminiere_tos
  bl tidyup_register_allocator_tos @ Falls TOS <> r6 an diesem Moment... Falls es eine Konstante gewesen ist, wurde sie eben gerade schon generiert.
  
  b.n of_opcodiereinsprung @ Der klassische Abschluss  
  

struktur_of:
  popda r0
  cmp r0, tos
  bx lr

/* Simply a small disassembly section to see opcodes.
  popda r0
  cmp r0, tos
  bne.n .+4   @... Sprung falls ungleich
  drop

    1698:	4630      	mov	r0, r6
    169a:	cf40      	ldmia	r7!, {r6}
    169c:	42b0      	cmp	r0, r6
    169e:	d100      	bne.n	16a2 <strukturof+0xa>
    16a0:	cf40      	ldmia	r7!, {r6}

*/

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "endof"
  @ ( ... addr-jne #of 9 -- ... addr-jmp #of 8 )
strukturendof:
@------------------------------------------------------------------------------
  cmp tos, #9
  beq 1f
  b.n strukturen_passen_nicht
1:drop

  push {lr}
  to_r @ #of auf Returnstack  Move #of to Returnstack and out of the way

    bl branch_v @ here 2 allot
    swap @ ( here Addr-jne )
    bl v_casebranch @ Den aktuellen of-Block mit bne überspringen   Skip current of-block with a bne opcode

  r_from @ #of zurückholen fetch back of#
  pushdaconst 8
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate_compileonly, "endcase"
  @ ( ... addrs-jmp #of 8 -- )
strukturendcase:
@------------------------------------------------------------------------------
  cmp tos, #8
  beq 1f
  b.n strukturen_passen_nicht
1:drop

  push {lr}
  pushdaconstw 0xcf40 @ Opcode for ldmia r7!, {r6}
  bl hkomma

  bl spruenge_einpflegen
  pop {pc}


@------------------------------------------------------------------------------
spruenge_einpflegen: @ Internal use only.
@------------------------------------------------------------------------------
  push {lr}
  @ Einpflegen der gesammelten Sprünge
  @ Fill in collected jumps.
  popda r0 @ Zahl der einzupflegenden Sprünge holen Fetch number of jumps that need to be generated

1:cmp r0, #0 @ Sind noch Sprünge zu bearbeiten ? Any jumps left ?
  beq 2f
  
  push {r0, r1}
  movs r1, #1          @ Check if this shall be a conditional jump instead. Needed for ?do which reuses this code. 
  ands r1, tos         @ Prüfe, ob es ein bedingter Sprung werden soll - ?do benötigt solche.

  cmp r1, #0
  beq 3f
    subs tos, #1 @ Markierung für den bedingten Sprung entfernen  Remove temporary bit for this beeing a conditional jump
    bl v_nullbranch  @ Insert conditional jump
    b 4f
  
3:bl v_branch @ Unbedingten Sprung einpflegen  Insert unconditional jump

4:pop {r0, r1}

  subs r0, #1 @ Ein Sprung weniger übrig  One jump less to do.
  b 1b

2: pop {pc}
