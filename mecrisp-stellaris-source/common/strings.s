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

@ Routinen, um mit Strings umzugehen, die aus einem Längenbyte und den folgenden Zeichen bestehen.
@ Routines for counted strings.


  .ifdef m0core

.macro lowercase Register @ Ein Zeichen in einem Register wird auf Lowercase umgestellt. Convert to lowercase.
  @    Hex Dec  Hex Dec
  @ A  41  65   61  97  a
  @ Z  5A  90   7A  122 z
  cmp \Register, #0x41
  blo 5f
  cmp \Register, #0x5B
  bhs 5f
  adds \Register, #0x20
5:  
.endm

  .else

.macro lowercase Register @ Ein Zeichen in einem Register wird auf Lowercase umgestellt.
  @    Hex Dec  Hex Dec
  @ A  41  65   61  97  a
  @ Z  5A  90   7A  122 z
  cmp \Register, #0x41
  blo 5f
  cmp \Register, #0x5B
  it lo
  addlo \Register, #0x20
5:  
.endm

  .endif

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "compare"  @ Vergleicht zwei Strings  Compare two strings
compare:                             @ ( c-addr1 len-1 c-addr2 len-2 -- f )
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}

  popda r1        @ Length of second string
  ldm psp!, {r0}  @ Length of first  string
  cmp r0, r1
  beq 1f

    drop
    movs tos, #0
    pop {r0, r1, r2, r3, pc}

1: @ Lengths are equal. Compare characters.
   ldm psp!, {r1}  @ Address of first string.
                   @ TOS contains address of second string.

   @ How many characters to compare left ?
2: cmp r0, #0
   beq 3f

     subs r0, #1
     ldrb r2, [r1, r0]
     ldrb r3, [tos, r0]

     @ Beide Zeichen in Kleinbuchstaben verwandeln.  Convert booth to lowercase.
     lowercase r2
     lowercase r3

     cmp r2, r3
     beq 2b

     @ Unequal
     movs tos, #0
     pop {r0, r1, r2, r3, pc}

3: @ Equal !
   movs tos, #0
   mvns tos, tos
   pop {r0, r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cr" @ Zeilenumbruch
@ -----------------------------------------------------------------------------
  push {lr}
  writeln ""
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "bl" @ Leerzeichen-code
@ -----------------------------------------------------------------------------
  pushdaconst 32
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "space"
space:
@ -----------------------------------------------------------------------------
  pushdaconst 32
  b.n emit

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "spaces"
@ -----------------------------------------------------------------------------
  push {lr}
  cmp tos, #0
  ble 2f
  
1:bl space
  subs tos, #1
  bne 1b

2:drop
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0, "[char]" @ ( -- )  Get character from input stream and compile it as literal
  @ Holt ein Zeichen aus dem Eingabestrom und fügt es als Literal ein.
@------------------------------------------------------------------------------
  b.n holechar

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "char" @ Holt ein Zeichen aus dem Eingabestrom  Get character from input stream
holechar: @ ( -- Zeichen )
@------------------------------------------------------------------------------
  push {lr}
  bl token        @ Fetch token
  drop            @ Drop length  
  ldrb tos, [tos] @ Read character
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0|Flag_Sprungschlucker, "(" @ Der Kommentar
@ -----------------------------------------------------------------------------
  pushdaconst 41 @ Die Klammer )
  b 1f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate|Flag_foldable_0|Flag_Sprungschlucker, "\\" @ Der lange Kommentar
@ -----------------------------------------------------------------------------
  pushdaconst 0 @ Gibt es nicht - immer bis zum Zeilenende. Zero never occours - always catches whole line.

1:push {lr}
  bl parse
  ddrop
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate, ".\"" @ Fügt eine Meldung ein  Print a message
@ -----------------------------------------------------------------------------
  ldr r0, =dotgaensefuesschen

1:push {lr}
  pushda r0
  bl callkomma

  pushdaconst 34 @ Das Gänsefüßchen "
  bl parse
  bl stringkomma
  pop {pc}

@ -----------------------------------------------------------------------------
dotgaensefuesschen: @ Gibt den inline folgenden String aus und überspringt ihn
                    @ Print the string following inline and skip it
@ -----------------------------------------------------------------------------
  push {r1, r3}  @ Messages are used everywhere, save the registers !

  pushdatos
  mov tos, lr    @ In lr ist nun die Stringadresse.  LR contains string address
  subs tos, #1   @ Die Stringanfangsadresse für type - PC ist ungerade im Thumb-Modus ! One less because of Thumb-instruction set marker bit
  ldrb r3, [tos] @ Länge des Strings holen  Fetch length of string

  @ Skip the string.

  movs r1, #1
  adds r3, #1     @ Plus 1 Byte für die Länge  One more for length byte
  ands r1, r3     @ Wenn es ungerade ist, noch einen mehr:  Maybe one more for aligning
  adds r3, r1

  .ifdef m0core
    mov r1, lr
    adds r1, r3
    mov lr, r1
  .else
    adds lr, r3
  .endif

  pop {r1, r3}
  b.n type   @ Print it !

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate, "c\"" @ Fügt einen String ein  Insert a string-literal
@ -----------------------------------------------------------------------------
  ldr r0, =dotcfuesschen
  b 1b

@ -----------------------------------------------------------------------------
dotcfuesschen: @ Legt den inline folgenden String auf den Stack und überspringt ihn
              @ Put address of the string following inline on datastack and skip string.
@ -----------------------------------------------------------------------------
  pushdatos
  mov tos, lr    @ In lr ist nun die Stringadresse.  LR contains string address
  subs tos, #1   @ Die Stringanfangsadresse für type - PC ist ungerade im Thumb-Modus ! One less because of Thumb-instruction set marker bit
  ldrb r3, [tos] @ Länge des Strings holen  Fetch length of string

  @ Skip the string.

  movs r1, #1
  adds r3, #1     @ Plus 1 Byte für die Länge  One more for length byte
  ands r1, r3     @ Wenn es ungerade ist, noch einen mehr:  Maybe one more for aligning
  adds r3, r1

  .ifdef m0core
    mov r1, lr
    adds r1, r3
    mov lr, r1
  .else
    adds lr, r3
  .endif

  bx lr  @ Leave string address on datastack.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_immediate, "s\"" @ Fügt einen String ein  Insert a string-literal
@ -----------------------------------------------------------------------------
  ldr r0, =dotsfuesschen
  b 1b

@ -----------------------------------------------------------------------------
dotsfuesschen: @ Legt den inline folgenden String auf den Stack und überspringt ihn
              @ Put address of the string following inline on datastack and skip string.
@ -----------------------------------------------------------------------------
  pushdatos
  mov tos, lr    @ In lr ist nun die Stringadresse.  LR contains string address
  dup
  subs tos, #1   @ Die Stringanfangsadresse für type - PC ist ungerade im Thumb-Modus ! One less because of Thumb-instruction set marker bit
  ldrb tos, [tos] @ Länge des Strings holen  Fetch length of string

  @ Skip the string.

  movs r1, #1
  adds r3, tos, #1 @ Plus 1 Byte für die Länge  One more for length byte
  ands r1, r3      @ Wenn es ungerade ist, noch einen mehr:  Maybe one more for aligning
  adds r3, r1

  .ifdef m0core
    mov r1, lr
    adds r1, r3
    mov lr, r1
  .else
    adds lr, r3
  .endif

  bx lr  @ Leave string address and length on datastack.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "count"
count: @ ( str -- ) Gibt einen String aus  Print a counted string
@ -----------------------------------------------------------------------------
  @ Count soll die Adresse um eine Stelle weiterschieben und die Länge holen.
  adds tos, #1 @ Adresse + 1
  dup
  subs tos, #1 @ Zurück zum Längenbyte
  ldrb tos, [tos] @ Längenbyte holen
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "ctype"
type: @ ( str -- ) Gibt einen String aus  Print a counted string
@ -----------------------------------------------------------------------------
   push {r0, lr}
   ldrb r0, [tos] @ Hole die auszugebende Länge in r0  Fetch length to type

   cmp r0, #0     @ Wenn nichts da ist, bin ich fertig.  Any characters left ?
   beq 2f

   @ Es ist etwas zum Tippen da !  Something available for typing !
1: adds tos, #1    @ Adresse um eins erhöhen  Advance pointer
   dup
   ldrb tos, [tos] @ Zeichen holen            Put character on datastack
   bl emit         @ Zeichen senden           Emit character     
   subs r0, #1     @ Ein Zeichen weniger      One character less
   bne 1b

2: drop
   pop {r0, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "type"
stype:  @ ( addr len -- ) Gibt einen String aus  Print a string
@ -----------------------------------------------------------------------------
   popda r1    @ Length to type
   popda r0    @ Address of string

stype_addr_r0_len_r1:

   push {lr}

   cmp r1, #0  @ Zero characters ?
   beq 2f

   movs r2, #0 @ No characters printed yet.

1:   pushdatos
     ldrb tos, [r0, r2]
     bl emit

     adds r2, #1
     cmp r1, r2   @ Any characters left ?
     bne 1b
     
2: pop {pc}
