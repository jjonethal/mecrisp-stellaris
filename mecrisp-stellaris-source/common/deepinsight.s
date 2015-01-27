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

@ Enthält Routinen, die einen Einblick in das Innenleben ermöglichen.
@ Tools for deep insight into Mecrisp and its Stacks.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hex." @ Print an unsigned number in Base 16, independent of number subsystem.
hexdot: @ ( u -- ) @ Funktioniert unabhängig vom restlichen Zahlensystem.
@ -----------------------------------------------------------------------------

  .ifdef m0core
  
        push    {r0, r1, r2, lr}
        popda r1 @ Zahl holen
        movs    r0, #32 @ Zahl der Bits, die noch zu bearbeiten sind  Number of Bits left
        movs r2, #15 @ Mask for one Nibble

1:      subs    r0, #4       @ 4 Bits weniger  4 Bits less to do
        pushdatos            @ Platz auf dem Stack schaffen  Make space on datastack

        movs tos, r1
        lsrs tos, r0         @ Schiebe den Wert passend   Shift accordingly

        ands    tos, r2      @ Eine Hex-Ziffer maskieren  Mask 4 Bits
        cmp     tos, #9      @ Ziffer oder Buchstabe ?    Number or letter ?
        bls 2f
          adds tos, #55 @ Passendes Zeichen konstruieren
          b 3f
2:        adds tos, #48 @ Calculate ASCII
3:

        bl      emit
        cmp     r0, #0
        bne     1b

        bl space
        pop     {r0, r1, r2, pc}

  .else
        push    {r0, r1, lr}
        popda r1 @ Zahl holen
        movs    r0, #32 @ Zahl der Bits, die noch zu bearbeiten sind  Number of Bits left

1:      subs    r0, #4       @ 4 Bits weniger  4 Bits less to do
        pushdatos            @ Platz auf dem Stack schaffen  Make space on datastack

        lsrs    tos, r1, r0   @ Schiebe den Wert passend   Shift accordingly
        ands    tos, #15      @ Eine Hex-Ziffer maskieren  Mask 4 Bits
        cmp     tos, #9       @ Ziffer oder Buchstabe ?    Number or letter ?
        ite     hi
          addhi   tos, #55 @ Passendes Zeichen konstruieren
          addls   tos, #48 @ Calculate ASCII
        bl      emit
        cmp     r0, #0
        bne     1b

        bl space
        pop     {r0, r1, pc}
  .endif


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "h.s"  @ Prints out data stack, uses unsigned hexadecimal snumbers. 
hexdots: @ Malt den Stackinhalt, diesmal verschönert !
@ -----------------------------------------------------------------------------
        push {r0, r1, r2, r3, r4, lr}
        ldr r4, =hexdot+1
        b.n 1f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "u.s"  @ Prints out data stack, uses unsigned numbers. 
udots: @ Malt den Stackinhalt, diesmal verschönert !
@ -----------------------------------------------------------------------------
        push {r0, r1, r2, r3, r4, lr}
        ldr r4, =udot+1
        b.n 1f

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, ".s"  @ Prints out data stack, uses signed numbers. 
dots: @ Malt den Stackinhalt, diesmal verschönert !
@ -----------------------------------------------------------------------------
        push {r0, r1, r2, r3, r4, lr}
        ldr r4, =dot+1

1:      @ Berechne den Stackfüllstand  Calculate number of elements on datastack
        ldr r1, =datenstackanfang @ Anfang laden
        subs r1, psp @ und aktuellen Stackpointer abziehen

        lsrs r1, #2 @ Durch 4 teilen  Divide by 4 Bytes/Element

  @ Basis sichern und auf Dezimal schalten  Save Base and switch to decimal for stack fill gauge
  ldr r2, =base
  ldr r0, [r2]
  push {r0, r1}

  movs r0, #10
  str r0, [r2]

        write "Stack: ["
        pushda r1
        bl dot  @ . bewahrt die Register nicht.  Doesn't save registers !
        write "] "

  @ Basis zurückholen  Restore Base
  pop {r0, r1}
  ldr r2, =base
  str r0, [r2]

        @ r1 enthält die Zahl der enthaltenen Elemente. r1 is number of elements
        cmp r1, #0 @ Bei einem leeren Stack ist nichts auszugeben.  Don't print elements for an empty stack
        beq 2f

        ldr r2, =datenstackanfang - 4 @ Anfang laden, wo ich beginne:  Start here !

1:      @ Hole das Stackelement !  Fetch stack element directly
        ldr r0, [r2]

        push {r1, r2}
        pushda r0
        blx r4 @ . bewahrt die Register nicht.  Doesn't save registers !
        pop {r1, r2}

        subs r2, #4
        subs r1, #1
        bne 1b

2:      @ TOS zeigen  Print TOS
        write " TOS: "
        pushda tos
        blx r4

        writeln " *>"
        pop {r0, r1, r2, r3, r4, pc}


  .ifdef debug
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dump" @ ( addr u -- ) Prints some memory locations beginning with given adress
dump:  @ Malt den Speicherinhalt beginnend ab der angegebenen Adresse
@ -----------------------------------------------------------------------------
  push {lr}
  popda r1 @ Zahl der Speicherstellen holen  Number of locations to print
  popda r0 @ Adresse holen  Fetch address

  writeln ""
1: @ Schleife
  pushda r0
  bl hexdot
  write ": "
  ldrh r2, [r0]
  pushda r2
  bl hexdot
  writeln " >"
  adds r0, #2
  subs r1, #1
  bne 1b

  writeln ""
  pop {pc}
  .endif


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "words" @ Print list of words with debug information
words: @ Malt den Dictionaryinhalt
@ -----------------------------------------------------------------------------
  push {lr}
  writeln "words"

  bl dictionarystart

1:@ Adresse:
  write "Address: "
  dup
  bl hexdot

  @ Link
  write "Link: "
  dup
  ldr tos, [tos]
  bl hexdot

  @ Flagfeld
  write "Flags: "
  dup
  ldrh tos, [tos, #4]
  bl hexdot

  @ Einsprungadresse
  write "Code: "
  adds r0, tos, #6 @ Current location +2 for skipping Flags +4 for skipping Link contains name string.
  bl skipstring
  pushda r0
  bl hexdot

  write "Name: "
  dup
  adds tos, #6 @ Current location +2 for skipping Flags +4 for skipping Link contains name string.
  bl type

  writeln ""

  bl dictionarynext
  popda r0
  beq 1b

  drop
  pop {pc}
