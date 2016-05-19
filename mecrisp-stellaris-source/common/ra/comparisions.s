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

@ Vergleichsoperatoren
@ Comparision operators

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "0=" @ ( x -- ? )
@ -----------------------------------------------------------------------------
@        subs TOS, TOS, #1       ; if zero, carry is set, else carry is clear
@        sbc TOS, TOS, TOS       ; subtracting r0 from itself leaves zero if
@                                ; carry was clear or -1 if carry was set.
  subs tos, #1
  sbcs tos, tos
  bx lr

allocator_equal_zero:
    push {lr}
      bl prepare_single_compare @ Beinhaltet expect_one_element.
      bl allocator_one_minus
      bl eliminiere_tos

      ldr r1, =0xD200
      str r1, [r0, #offset_sprungtrampolin] @ Daraus wird später der sbcs-Opcode zusammengesetzt, falls nötig.
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "0<>" @ ( x -- ? )
@ -----------------------------------------------------------------------------
  subs tos, #1
  sbcs tos, tos
  mvns tos, tos
  bx lr

allocator_unequal_zero:
    push {lr}
      bl prepare_single_compare @ Beinhaltet expect_one_element.
      bl allocator_one_minus
      bl eliminiere_tos

      ldr r1, =0xD300
      str r1, [r0, #offset_sprungtrampolin] @ Daraus wird später die sbcs/mvns-Opcodesequenz zusammengesetzt, falls nötig.
    pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_1|Flag_inline|Flag_allocator, "0<" @ ( n -- ? )
@ -----------------------------------------------------------------------------
  movs TOS, TOS, asr #31    @ Turn MSB into 0xffffffff or 0x00000000
  bx lr

alloc_nullkleiner:
    push {lr}
      bl prepare_single_compare @ Beinhaltet expect_one_element.

      pushdaconstw 0x17C0 @ asrs r0, r0, #31
      bl smalltworegisters

      ldr r1, =0xD500
      str r1, [r0, #offset_sprungtrampolin] @ Daraus wird später die sbcs/mvns-Opcodesequenz zusammengesetzt, falls nötig.
    pop {pc}

@ Wenn TOS Konstante ist, werden die 0-Vergleiche sowieso gefaltet.
@ Also ist TOS ohnehin ein Register.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_0|Flag_inline, "true" @ ( -- -1 )
@ -----------------------------------------------------------------------------
  pushdatos
generate_true:
  movs tos, #0
  mvns tos, tos
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_0|Flag_inline, "false" @ ( x -- 0 )
@ -----------------------------------------------------------------------------
  pushdatos
  movs tos, #0
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_allocator, ">=" @ ( x1 x2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get x1 into a register.
  cmp r0, tos         @ Is x2 less or equal ?
  bge.n generate_true
  movs tos, #0
  bx lr

    pushdaconstw 0xDB00 @ blt signed less
    pushdaconstw 0xDA00 @ signed greater or equal
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_allocator, "<=" @ ( x1 x2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get x1 into a register.
  cmp r0, tos        @ Is x2 greater or equal ?
  ble.n generate_true
  movs tos, #0
  bx lr

    pushdaconstw 0xDC00 @ bge signed greater
    pushdaconstw 0xDD00 @ ble signed less or equal
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_allocator, "<" @ ( x1 x2 -- ? )
                      @ Checks if x2 is less than x1.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get x1 into a register.
  cmp r0, tos        @ Is x2 less?
  blt.n generate_true
  movs tos, #0
  bx lr

    pushdaconstw 0xDA00 @ signed greater or equal
    pushdaconstw 0xDB00 @ blt signed less
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_allocator, ">" @ ( x1 x2 -- ? )
                      @ Checks if x2 is greater than x1.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get x1 into a register.
  cmp r0, tos        @ Is x2 greater?
  bgt.n generate_true
  movs tos, #0
  bx lr

    pushdaconstw 0xDD00 @ ble signed less or equal
    pushdaconstw 0xDC00 @ bge signed greater
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "u>=" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get u1 into a register.
  subs tos, r0, tos   @ subs tos, w, tos   @ TOS = a-b  -- carry set if a is less than b
  sbcs tos, tos
  mvns tos, tos
  bx lr

    pushdaconstw 0xD300 @ blo unsigned lower
    pushdaconstw 0xD200 @ bhs unsigned higher or same
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "u<=" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs tos, r0
  sbcs tos, tos
  mvns tos, tos
  bx lr

    pushdaconstw 0xD800 @ bhi unsigned higher
    pushdaconstw 0xD900 @ bls unsigned lower or same
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "u<" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}      @ Get u1 into a register.
  subs tos, r0, tos   @ subs tos, w, tos   @ TOS = a-b  -- carry set if a is less than b
  sbcs tos, tos
  bx lr

    pushdaconstw 0xD200 @ bhs unsigned higher or same
    pushdaconstw 0xD300 @ blo unsigned lower
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "u>" @ ( u1 u2 -- ? )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs tos, r0
  sbcs tos, tos
  bx lr

    pushdaconstw 0xD900 @ bls unsigned lower or same
    pushdaconstw 0xD800 @ bhi unsigned higher
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "<>" @ ( x1 x2 -- ? )
                       @ Compares the top two stack elements for inequality.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  subs  r1, r0, tos
  subs tos, tos, r0
  orrs tos, r1
  bx lr

    pushdaconstw 0xD000 @ Opcode: beq
    dup
    b.n prepare_compare

@ -----------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2|Flag_allocator, "=" @ ( x1 x2 -- ? )
                      @ Compares the top two stack elements for equality.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}     @ Get the next elt into a register.
  subs tos, r0       @ Z=equality; if equal, TOS=0

  subs tos, #1       @ Wenn es Null war, gibt es jetzt einen Überlauf
  sbcs tos, tos
  bx lr

    pushdaconstw 0xD100 @ Opcode: bne
    dup
    b.n prepare_compare

 .ltorg

@ -----------------------------------------------------------------------------
prepare_single_compare:
@ -----------------------------------------------------------------------------
  push {lr}
  bl expect_one_element

  @ Es gibt maximal fünf Elemente im RA. Eins wird am Ende rausfliegen, eins kann nachrutschen.
  @ Falls die anderen Elemente also Konstanten sind, müssen sie jetzt generiert werden.

    bl tidyup_register_allocator_5os
    bl tidyup_register_allocator_4os
    bl tidyup_register_allocator_3os
    bl expect_nos_in_register

  pop {pc}

@ -----------------------------------------------------------------------------
prepare_compare:
@ -----------------------------------------------------------------------------

    push {lr} @ So ähnlich wie die Optimierungen in Plus und Minus
    bl expect_two_elements @ Zwei Elemente, die NICHT verändert werden. Mindestens eins davon ist ein Register, sonst würde gefaltet werden.

    @ Es gibt maximal drei Elemente im RA. Zwei werden am Ende dieser Prozedur rausfliegen.
    @ Kontrollstrukturen, die ein Sprungopcode aufnehmen und über die Flags kommunizieren, müssen sowieso zurück zum kanonischen Stack.
    @ Das Schieben / Umladen ist Flag-Erhaltend, nur das Generieren von Konstanten täte weh.
    @ Wenn also 3OS hier eine Konstante ist, wird ein freier Register angefordert und sie hineingeladen, damit später das Zurück-zum-kanonischen-Stack funktioniert.


    @ Jetzt gibt es bis zu fünf Elemente. Zwei werden am Ende herausfliegen, eins kann direkt ins neue TOS nachrücken.
    @ Ich muss also die tieferen Elemente rausschreiben, bevor ich weitermache, weil im M0 das Rausschreiben Flags zerstört.

    bl tidyup_register_allocator_5os
    bl tidyup_register_allocator_4os
    bl expect_3os_in_register

    @ Ist in TOS oder in NOS eine kleine Konstante ?
    ldr r2, [r0, #offset_state_nos]
    cmp r2, #constant
    bne 1f
      bl swap_allocator @ Wenn NOS eine Konstante gewesen ist, war TOS es nicht (Vorherige Faltung !) und ich kann einfach umtauschen.
      swap @ Vertausche in diesem Fall auch die Sprungopcodes
1:  @ Fertig: Wenn eine Konstante da ist, ist sie jetzt in TOS.

    drop @ Vergiss den oberen Sprungopcode

    @ Ist jetzt TOS eine kleine Konstante ?

    ldr r1, [r0, #offset_state_tos]
    cmp r1, #constant
    bne 3f
      ldr r1, [r0, #offset_constant_tos]
      cmp r1, #0xff
      bhi 5f
        @ TOS ist eine kleine Konstante.
        pushdaconstw 0x2800 @ cmp r0, #imm8
        orrs tos, r1
        ldr r1, [r0, offset_state_nos] @ NOS dann der Faltung wegen unbedingt ein Register.
        lsls r1, #8
        b.n 4f
5:

.ifndef m0core
  @ TOS ist eine Konstante, aber zu groß für Imm8.
  @ Vielleicht passt sie in Imm12 ?

       pushdatos
        ldr tos, [r0, #offset_constant_tos]
        bl twelvebitencoding @ Hole sie und prüfe, ob sie als Imm12 darstellbar ist.
        ldmia psp!, {r1} @ Entweder die Bitmaske oder wieder die Konstante

        cmp tos, #0
        drop   @ Preserves Flags !
        beq 3f
          @ Die Konstante lässt sich als Imm12 darstellen - fein ! Bitmaske liegt in r1 bereit
          @ Prüfe nun den Opcode, und ersetze ihn, falls möglich.

          pushdatos
          ldr tos, =0xF1B00F00 @ cmp r0, #Imm12 = cmp pc, r0, #Imm12
          orrs tos, r1
          ldr r1, [r0, offset_state_nos] @ NOS dann der Faltung wegen unbedingt ein Register.
          orrs tos, tos, r1, lsl #16 @ Quellregister hinzufügen
          bl reversekomma
          b 5f

.endif


3:  @ Schritt eins: Die Konstante, falls TOS jetzt eine sein sollten, laden.
    @ NOS kann durch den Swap keine Konstante sein.
    bl expect_tos_in_register

    @ Beide Argumente sind jetzt in Registern.
    pushdaconstw 0x4280 @ cmp r0, r0
    @ Baue Quell- und "Ziel-" Register in den Opcode ein.

    lsls r1, #3  @ Erster Operand ist um 3 Stellen geschoben. Das muss mit dem oberen CMP-mit-Konstanten-Opcode übereinstimmen !

    @ Baue jetzt den Opcode zusammen:

    orrs tos, r2
4:  orrs tos, r1

    bl hkomma

    @ Vergiss die bisherige Registerzuordnung

5:  bl eliminiere_tos
    bl eliminiere_tos

    @ Das Ergebnis ist jetzt erstmal nur in den Flags - welche bei Bedarf von einem Flaggenerator geschrieben werden oder von einer Kontrollstruktur direkt geschluckt.

    str tos, [r0, #offset_sprungtrampolin]
    drop
    pop {pc}

@ -----------------------------------------------------------------------------
sprungschreiber_flaggenerator:
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
    @ writeln "Sprungschreiber"
    ldr r0, =allocator_base
    ldr r1, [r0, #offset_sprungtrampolin]
    cmp r1, #0
    beq 1f

      pushdatos
      ldr tos, [r0, #offset_sprungtrampolin]
        movs r1, #0
        str r1, [r0, #offset_sprungtrampolin]

    @ ( Sprungopcode -- )
    @ Kümmere mich um das Ergebnis !

    @ In diesen neuen Register muss ich nun abhängig von den Flags einen Wert generieren.

      @ Im Falle des Carry-Flags gibt es einen kürzeren Weg, ein Flag zusammenzubauen:
      lsrs r1, tos, #8 @ Sprungopcode so schieben, dass ich bequem vergleichen kann
@      pushda r1
@      bl hexdot

      cmp r1, #0xD5 @ Opcode bpl - der Minussprung. Er wird ausschließlich von 0< generiert.
      bne 2f
        @ Die Besonderheit: Dieses Flag ist schon fertig in einem Register. Muss nichts tun.
        drop
        pop {r0, r1, r2, r3, pc}
2:

    @ Alle anderen Fälle benötigen einen neuen Register, in dem das Flag generiert werden kann.
    bl befreie_tos
    bl get_free_register
    str r3, [r0, #offset_state_tos]

      cmp r1, #0xD2
      bne 2f
        ldr tos, =0x4180 @ sbcs r0, r0, #0
        bl smalltworegisters
        pop {r0, r1, r2, r3, pc}
2:

      cmp r1, #0xD3
      bne 2f
        ldr tos, =0x4180 @ sbcs r0, r0, #0
        bl smalltworegisters
        bl allocator_not
        pop {r0, r1, r2, r3, pc}
2:

    @ Dies ist der "normale" Flaggenerator, der immer und bei allen Flagkombinationen funktioniert.

    adds tos, #2 @ Flaggenerator_inverted benötigt einen Sprung drei Befehle weiter
    @ Bedingten Sprung schreiben, um Flag zu generieren
    bl hkomma

    pushdaconstw 0x2000 @ movs r0, #0
    bl smallplusminus
    bl allocator_not @ Generates: mvns r0, r0

    pushdaconstw 0xE000 @ b ein Befehl weiter
    bl hkomma
    pushdaconstw 0x2000 @ movs r0, #0
    bl smallplusminus

1:pop {r0, r1, r2, r3, pc}

smallplusminus:
    push {lr}
    bl expect_one_element @ Da nicht gefaltet worden ist, muss es sich um einen Register handeln.
    bl make_tos_changeable
    ldr r1, [r0, #offset_state_tos]
    lsls r1, #8
    orrs tos, r1
    bl hkomma
    pop {pc}

eliminiere_tos_wenn_bmi: @ Dies wird vor dem Einpflegen der Sprünge in eine Konstrollstruktur aufgerufen.
  push {lr}              @ 0< hat die Besonderheit, einen Forth-Flag in ein Register zu legen. Dieser muss entfernt werden, wenn der Sprungopcode benutzt wird.

    ldr r1, [r0, #offset_sprungtrampolin]
    lsrs r1, r1, #8
    cmp r1, #0xD5 @ BMI Opcode
    bne 1f
      bl eliminiere_tos
1:pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "min" @ ( x1 x2 -- x3 )
                        @ x3 is the lesser of x1 and x2.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  bgt 1f
  movs tos, r0
1:bx lr
    
    pushdaconstw 0xDB00 @ blt signed less
    b.n alloc_minmax

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "max" @ ( x1 x2 -- x3 )
                        @ x3 is the greater of x1 and x2.
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  blt 1f
  movs tos, r0
1:bx lr

    pushdaconstw 0xDC00 @ bgt signed greater
    b.n alloc_minmax

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "umax" @ ( u1 u2 -- u1|u2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  blo 1f
  movs tos, r0
1:bx lr

    pushdaconstw 0xD800 @ bhi unsigned higher
    b.n alloc_minmax

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline|Flag_allocator, "umin" @ ( u1 u2 -- u1|u2 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0}
  cmp r0, tos
  bhi 1f
  movs tos, r0
1:bx lr

    pushdaconstw 0xD300 @ blo unsigned lower

alloc_minmax:
    push {lr}
    bl expect_two_elements       @ Es kann nur eine Konstante geben

    ldr r1, [r0, #offset_state_tos]
    ldr r2, [r0, #offset_state_nos]
    cmp r1, r2
    bne 1f      
      drop @ Sollten es aus irgendwelchen Gründen identische Register sein - nichts generieren.
      bl eliminiere_nos
      pop {pc} @ Der Fall zweier Konstanten wird vorher weggefaltet.
1:  


    cmp r2, #reg6 @ Ist NOS gerade in r6 ? Wenn ja, dann wechseln ! Weniger hin- und her am Ende.
    bne 2f
      bl swap_allocator
2:

    @ Es ist praktischer, eine eventuelle Konstante in NOS zu haben... Dann kann die Konstante direkt aus r0/r1 geholt werden.
    @ Da durch die Faltung höchstens eine Konstante auftreten kann, ist alles kein Problem.
    ldr r1, [r0, #offset_state_tos]
    cmp r1, #constant @ Ist TOS also eine Konstante, welchsele ich.
    bne 2f
      bl swap_allocator
2:  @ Konstante, wenn vorhanden, in NOS !

    bl make_tos_changeable       @ Wenn nötig, eine Elementkopie anlegen
    bl expect_nos_in_register    @ Register kommt in r1 zurück


    @ r1: NOS
    lsls r1, #3

    @ r2: TOS
    ldr r2, [r0, #offset_state_tos]

    pushdaconstw 0x4280 @ cmp r0, r0
    orrs tos, r1
    orrs tos, r2
    bl hkomma
    bl hkomma @ Sprung einfügen
    pushdaconstw 0x4600 @ mov r0, r0
    orrs tos, r1
    orrs tos, r2
    bl hkomma

    bl eliminiere_nos
    pop {pc}

