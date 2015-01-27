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

@ Zahlenzauber enthält die Routinen für die Umwandlung von Zahlen in Strings und umgekehrt.
@ Die Zahlenbasis kann maximal bis 36 gehen, danach fehlt einfach der Zeichensatz.
@ Input and Output of numbers. Maximum base is 36.


@ -----------------------------------------------------------------------------
@ Zahleneingabe - Number input
@ -----------------------------------------------------------------------------

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "digit" @ ( Zeichen -- false / Ziffer true )
digit:  @ ( c -- false / u true ) Converts a character into a digit.
@ -----------------------------------------------------------------------------
  ldr r3, =base
  ldr r3, [r3]
  
digit_base_r3:  @ Erwartet Base in r3  Base has to be in r3 if you enter here.
  subs tos, #48 @ "0" abziehen.  Subtract "0"
  blo 5f        @ negativ --> Zeichen war "unter Null"  Negative ? --> Invalid character.

  cmp tos, #10  @ Im Bereich bis "9" ?  In range up to "9" ?
  blo 4f        @ Ziffer korrekt erkannt.  Digit recognized properly.

  @ Nein: Also ist die Ziffer nicht in den Zahlen 0-9 enthalten gewesen.
  @ Prüfe Buchstaben.
  @ Character is a letter. 

  subs tos, #7  @ Anfang der Großbuchstaben, "A"   Beginning of capital letters "A"
  cmp tos, #10  @ Buchstabenwerte beginnen bei 10  Values of letters start with 10
  blo 5f        @ --> Zeichen war ein Sonderzeichen zwischen Ziffern und Großbuchstaben.
                @ --> Character has been a special one between numbers and capital letters.

  cmp tos, #36  @ Es gibt 26 Buchstaben.  26 letters available.
  blo 4f        @ In dem Bereich: Ziffer korrekt erkannt.  In this range ? Digit recognized properly.

  @ Für den Fall, dass die Ziffer immer noch nicht erkannt ist, probiere es mit den Kleinbuchstaben.
  @ Try to recognize small letters.

  subs tos, #32 @ Schiebe zum Anfang der Kleinbuchstaben, "a"  Beginning of small letters "a"
  cmp tos, #10  @ Buchstabenwerte beginnen bei 10  Values of letters start with 10
  blo 5f        @ --> Zeichen war ein Sonderzeichen zwischen Großbuchstaben und Kleinbuchstaben.
                @ --> Character has been a special one between small and capital letters.

  cmp tos, #36  @ Es gibt 26 Buchstaben.  26 letters available.
  blo 4f        @ In dem Bereich: Ziffer korrekt erkannt.  In this range ? Digit recognized properly.

  @ Immer noch nicht ? Dann ist das ein Sonderzeichen oberhalb der Kleinbuchstaben oder ein Unicode-Zeichen.
  @ Keine gültige Ziffer.
  @ Not yet recognized ? --> Character has been a special one above small letters or in Unicode.
  @ No valid digit then..


5: @ Aussprung mit Fehler  Error.
  movs tos, #0    @ False-Flag
  bx lr

4: @ Korrekt erkannt. Ziffer in tos 

  @ Prüfe nun noch, ob die Ziffer innerhalb der Basis liegt !
  @ Do not accept digits greater than current base
  cmp tos, r3 @ r3 enthält von number aus die Basis.
  bhs 5b     @ Außerhalb der Basis werden keine Buchstaben als Zahlen akzeptiert.

  pushdatos
  movs tos, #0
  mvns tos, tos @ True-Flag bereitlegen
  bx lr


@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "number" @ Number-Input.
  @ ( String Length -- 0 )    Not recognized
  @ ( String Length -- n 1 )  Single number
  @ ( String Length -- d 2 )  Double number or fixpoint s15.16

number: @ Tries to convert a string in one of the supported number formats.
@------------------------------------------------------------------------------

/*
    ; Sind noch Zeichen da ? Sonst fertig.
    ; Hole ein Zeichen von vorne.
    ; Prüfe, ob Digit das mag.
    ; Wenn ja: Zahl := Zahl * Basis + neue Ziffer. Zeichen abtrennen.
    ; Wenn nein: Fertig.
    ; Wiederholen.
*/

  @ r0: Pointer
  @ r1: Characters left
  @ r2: Character or helper
  @ r3: Base
  @ r4: Result-Low
  @ r5: Result-High

  push {r0, r1, r2, r3, r4, r5, lr}

  popda r1          @ Hole die Länge des Strings  Fetch length of string
  subs r0, tos, #1  @ Hole die Stringadresse      Fetch string address

  movs tos, #1  @ Single length result

  movs r2, #1   @ Positive Sign
  push {r2}

  ldr r3, =base
  ldr r3, [r3]

  movs r4, #0   @ Clear result low
  movs r5, #0   @              high

  @ ( Single R: Positive )


1: @ Sind noch Zeichen da ?  Any characters left ?
  cmp r1, #0
  beq 4f @ String ist leer, bin fertig !

  @ Hole ein Zeichen:  Fetch a character
  adds r0, #1 @ Pointer weiterrücken
  subs r1, #1 @ Länge um eins verringern
  ldrb r2, [r0] @ Zeichen holen.

  @ Vorzeichen und Basisvorsilben:  Sign and base prefixes:
  cmp r2, #45   @ Minus ?
  bne 2f
    add sp, #4   @ rdrop
    movs r2, #0
    mvns r2, r2   @ -1
    push {r2}
    b 1b

2:cmp r2, #35   @ # ?
  bne 2f
    movs r3, #10 @ Umschalten auf Dezimal
    b 1b

2:cmp r2, #36   @ $ ?
  bne 2f
    movs r3, #16 @ Umschalten auf Hexadezimal
    b 1b

2:cmp r2, #37   @ % ?
  bne 2f
    movs r3, #2  @ Umschalten auf Binär
    b 1b

2:cmp r2, #46   @ . ?
  bne 2f
    movs tos, #2   @ Double length result !
    b 1b

2:cmp r2, #44  @ , ?
  beq.n number_nachkommastellen


  @ Wandele das Zeichen  Convert character
  pushda r2
  bl digit_base_r3
  cmp tos, #0 @ Bei false mochte digit das Zeichen nicht.  Error ?
  drop        @ Flag runterwerfen  Drop the Flag from digit
    beq 5f      @ Aussprung mit Fehler.

  @ Zeichen wurde gemocht.  Character has been successfully converted to a digit.

  @ Multiply old result with base:
  pushda r4 @ Low
  pushda r5 @ High
  pushda r3 @ Base-Low
  pushdaconst 0 @ Base-High

  push {r0, r1, r2, r3}
    bl ud_short_star
  pop {r0, r1, r2, r3}

  popda r5 @ High
  popda r4 @ Low
  
  movs r2, #0 @ For addition with Carry
  adds r4, tos
  adcs r5, r2
  drop

  b 1b
  

4:@ String ist leer und wurde korrekt umgewandelt.  String is empty. Almost done...
  @ Vorzeichen beachten:  Take care of sign.
  pop {r2} @ Fetch back sign
  cmp r2, #0
  bpl 3f

    @ dnegate in Register:
    movs r2, #0
    mvns r4, r4
    mvns r5, r5
    adds r4, #1
    adcs r5, r2

3:movs r3, tos  @ Length of result:
  movs tos, r4  @ Low or single result
  cmp r3, #1
  beq 3f
    pushda r5   @ High result
3:pushda r3     @ Length on Stack

  pop {r0, r1, r2, r3, r4, r5, pc}


5: @ Digit mochte das Zeichen nicht. Return without success.
  add sp, #4   @ Forget sign
  movs tos, #0  @ No result
  pop {r0, r1, r2, r3, r4, r5, pc}



number_nachkommastellen: @ Digits after the decimal point.
  movs r5, r4   @ Low part is "high" part before comma now.
  movs r4, #0   @ Clear low part. To be filled with digits after comma.
  movs tos, #2  @ Double length result !

1: @ Sind noch Zeichen da ?  Any characters left ?
  cmp r1, #0
  beq 4b @ String ist leer, bin fertig !

  @ Fetch a character from end of string:
  ldrb r2, [r0, r1] @ Zeichen holen.
  subs r1, #1 @ Länge um eins verringern
  
  cmp r2, #46   @ . ?
  beq 1b        @ Accept more dots for clarity, already double result.


 @ Wandele das Zeichen  Convert character
  pushda r2
  bl digit_base_r3
  cmp tos, #0 @ Bei false mochte digit das Zeichen nicht.  Error ?
  drop        @ Flag runterwerfen  Drop the Flag from digit
    beq 5b      @ Aussprung mit Fehler.

  @ Zeichen wurde gemocht.  Character has been successfully converted to a digit.

  subs psp, #4
  str r4, [psp] @ Low-Old
  pushda r3 @ Base

  @ ( Old New-Digit Base )
  push {r0, r1, r2, r3}
  bl um_slash_mod @ ( Remainder New.. )
  pop {r0, r1, r2, r3}
  popda r4
  drop

  b 1b


@ -----------------------------------------------------------------------------
@ Zahlenausgabe - Number output
@ -----------------------------------------------------------------------------


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, ".digit" @ ( Ziffer -- Zeichen ) Wandelt eine Ziffer in ein Zeichen um.
               @ Wenn ein Zahlensystem größer 36 angestrebt wird,
               @ werden nicht druckbare Zeichen einfach mit # beschrieben.
digitausgeben: @ ( u -- c ) Converts a digit into a character.
               @ If base is bigger than 36, unprintable digits are written as #
@ -----------------------------------------------------------------------------
  .ifdef m0core
  cmp tos, #10   @ Von 0-9:
  bhs 1f
    adds tos, #48 @ Schiebe zum Anfang der Zahlen  Shift to beginning of ASCII numbers
    b 3f

1:cmp tos, #36   @ Von A-Z:
  bhs 2f 
    adds tos, #55 @ Alternative für Kleinbuchstaben: 87.                 For small letters: 87.
    b 3f

2:movs tos, #35 @ Zeichen #, falls diese Ziffer nicht darstellbar ist. Character #, if digit is not printable
3:bx lr

  .else
  cmp tos, #10   @ Von 0-9:
  itt lo
  addlo tos, #48 @ Schiebe zum Anfang der Zahlen  Shift to beginning of ASCII numbers
  blo 1f

  cmp tos, #36   @ Von A-Z:
  ite lo         @ Schiebe zum Anfang der Großbuchstaben - 10 = 55.     Shift to beginning of ASCII-capital-letters- 10 = 55.
  addlo tos, #55 @ Alternative für Kleinbuchstaben: 87.                 For small letters: 87.
  movhs tos, #35 @ Zeichen #, falls diese Ziffer nicht darstellbar ist. Character #, if digit is not printable

1:bx lr
  .endif


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "hold" @ Fügt dem Zahlenstring von vorne ein Zeichen hinzu.
hold: @ ( Zeichen -- )  Insert one character at the beginning of number buffer
@------------------------------------------------------------------------------

  @ Alter String:  | Länge     |     |
  @ Neuer String:  | Länge + 1 | Neu |

  @ Alter String:  | Länge     | I   | II  | III |     |
  @ Neuer String:  | Länge + 1 | Neu | I   | II  | III |

  @ Old String:  | Length     |     |
  @ New String:  | Length + 1 | New |

  @ Old String:  | Length     | I   | II  | III |     |
  @ New String:  | Length + 1 | New | I   | II  | III |

  popda r3 @ Das einzufügende Zeichen

  ldr r0, =Zahlenpuffer
  ldrb r1, [r0] @ Länge holen  

  cmp r1, #Zahlenpufferlaenge  @ Ist der Puffer voll ? Number buffer full ?
  bhs 3f                       @ Keine weiteren Zeichen mehr annehmen.  

  @ Länge des Puffers um 1 erhöhen  Increment length
  adds r1, #1
  strb r1, [r0] @ Aktualisierte Länge schreiben

  @ Am Ende anfangen:  Start moving with the end
  adds r0, r1 @ Zeiger an die freie Stelle für das neue Zeichen

  @ Ist die Länge jetzt genau 1 Zeichen ? Dann muss ich nichs schieben.
  cmp r1, #1  @ Check if at least one character has to be moved
  beq 2f

1:@ Schiebeschleife:  Move characters !
  subs r0, #1
  ldrb r2, [r0] @ Holen an der Stelle-1  Fetch from current location-1
  adds r0, #1
  strb r2, [r0] @ Schreiben an der Stelle  Write current location
  subs r0, #1 @ Weiterrücken  Advance Pointers

  subs r1, #1
  cmp r1, #1 @ Bis nur noch ein Zeichen bleibt. Das ist das Neue.
  bne 1b     @ Until there is only one character left - the new one.

2:@ Das neue Zeichen an seinen Platz legen
  strb r3, [r0] @ Insert new character

3:bx lr

@------------------------------------------------------------------------------
 Wortbirne Flag_visible, "hold<"
zahlanhaengen: @ ( Character -- ) Insert one character at the end of number buffer
@------------------------------------------------------------------------------
  popda r3 @ Das einzufügende Zeichen

  ldr r0, =Zahlenpuffer
  ldrb r1, [r0] @ Länge holen  

  cmp r1, #Zahlenpufferlaenge  @ Ist der Puffer voll ? Number buffer full ?
  bhs 3f                       @ Keine weiteren Zeichen mehr annehmen.  

    adds r1, #1 @ Ein Zeichen mehr
    strb r1, [r0] @ Neue Länge schreiben
    strb r3, [r0, r1] @ Neues Zeichen am Ende anhängen
3:bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "sign"
vorzeichen: @ ( Vorzeichen -- )
      @ Prüft die Zahl auf dem Stack auf ihr Vorzeichen hin und
      @ fügt bei Bedarf ein Minus an den Ziffernstring an.
      @ Checks flag of number on stack and adds a minus to number buffer if it is negative.
@------------------------------------------------------------------------------
  cmp tos, #0
  bmi 1f
  drop
  bx lr

1:movs tos, #45  @ Minuszeichen  ASCII for minus
  b.n hold         @ an den Zahlenpuffer anhängen  put it into number buffer

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "#>" @ ( ZahlenrestL (ZahlenrestH) -- Addr Len )
zifferstringende:  @ Schließt einen neuen Ziffernstring ab und gibt seine Adresse zurück.
                   @ Benutzt dafür einfach den Zahlenpuffer.
                   @ Finishes a number string and gives back its address.
@------------------------------------------------------------------------------
  ldr r0, =Zahlenpuffer
  ldrb tos, [r0]
  adds r0, #1
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "f#S"
falleziffern: @ ( u -- u=0 )
      @ Inserts all digits, at least one, into number buffer.
@------------------------------------------------------------------------------
  push {r4, lr}
  movs r4, #32
  
1:bl fziffer
  subs r4, #1
  bne 1b

  pop {r4, pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "f#"
fziffer: @ ( u -- u )
      @ Insert one more digit into number buffer
@------------------------------------------------------------------------------
  @ Handles parts after decimal point
  @ Idea: Multiply with base, next digit will be shifted into high-part of multiplication result.
  push {lr}
    pushdatos
    ldr tos, =base
    ldr tos, [tos] @ Base
    bl um_star     @ ( After-Decimal-Point Base -- Low High )
    bl digitausgeben @ ( Low=Still-after-decimal-point Character )
    bl zahlanhaengen @ Add character to number buffer
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "#S"
alleziffern: @ ( d-Zahl -- d-Zahl=0 )      
      @ Fügt alle Ziffern, jedoch mindestens eine,
      @ an den im Aufbau befindlichen String an.
      @ Inserts all digits, at least one, into number buffer.
@------------------------------------------------------------------------------
  push {lr}
1:bl ziffer
  cmp tos, #0
  bne 1b

  ldr r0, [psp]
  cmp r0, #0
  bne 1b
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "#"
ziffer: @ ( Zahl -- Zahl )
      @ Fügt eine weitere Ziffer hinzu, Rest entsprechend verkleinert.
      @ Insert one more digit into number buffer
@------------------------------------------------------------------------------
  @ Idea: Divide by base. Remainder is digit, Result is to be handled in next run.
  @ Idee dahinter: Teile durch die Basis.
  @ Bekomme einen Rest, und einen Teil, den ich im nächsten Durchlauf
  @ behandeln muss. Der Rest ist die Ziffer.
  push {lr}
    pushdatos
    ldr tos, =base
    ldr tos, [tos] @ Base-Low
    pushdaconst 0  @ Base-High
    @ ( uL uH BaseL BaseH )
    bl ud_slash_mod
    @ ( RemainderL RemainderH uL uH )
    bl dswap
    @ ( uL uH RemainderL RemainderH )
    drop
    @ ( uL uH RemainderL )
    bl digitausgeben
    @ ( uL uH digit )
    bl hold
    @ ( uL uH )
  pop {pc}


@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "<#" @ ( d-Zahl -- d-Zahl )
zifferstringanfang: @ Eröffnet einen neuen Ziffernstring.
                    @ Opens a number string
@------------------------------------------------------------------------------
  ldr r0, =Zahlenpuffer @ Länge löschen, bisherige Länge Null.
  movs r1, #0
  strb r1, [r0]
  bx lr  

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "f."
      @ ( Low High -- )
      @ Prints a s31.32 number
@------------------------------------------------------------------------------
  pushdaconst 32
  b.n fdotn

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "f.n"
      @ ( Low High n -- )
      @ Prints a s31.32 number with given number of fractional digits
fdotn:
@------------------------------------------------------------------------------
  push {lr}
  push {r4}
  popda r4

  @ ( Low High -- )
  bl tuck @ ( Sign Low High )
  bl dabs @ ( Sign uLow uHigh )

  pushdaconst 0  @ ( Sign After-decimal-point=uL Before-decimal-point-low=uH Before-decimal-point-high=0 )
  bl zifferstringanfang

  bl alleziffern @ Processing of high-part finished. ( Sign uL 0 0 )
  drop @ ( Sign uL 0 )

  movs tos, #44 @ Add a comma to number buffer ( Sign uL 44 )
  bl zahlanhaengen @ ( Sign uL )

  cmp r4, #0
  beq 2f

1:bl fziffer   @ Processing of fractional parts ( Sign 0 )
  subs r4, #1
  bne 1b

2:pop {r4}
  drop
  bl vorzeichen

  pushdatos @ Will be removed later
  pushdatos
  b.n abschluss_zahlenausgabe

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "ud." @ ( ud -- )
uddot:  @ Prints an unsigned double number
@------------------------------------------------------------------------------
  @ In Forth: <# #S #>
  push {lr}
  bl zifferstringanfang
  bl alleziffern
  b.n abschluss_zahlenausgabe

@------------------------------------------------------------------------------
  Wortbirne Flag_visible, "d." @ ( d -- )
ddot:   @ Prints a signed double number
@------------------------------------------------------------------------------
  push {lr}
  bl tuck
  bl dabs

  bl zifferstringanfang
  bl alleziffern @ ( Sign 0 0 )
  bl rot
  bl vorzeichen

abschluss_zahlenausgabe:
  bl zifferstringende
  bl stype
  bl space
  pop {pc}


@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "u."
      @ ( Zahl -- )
      @ Gibt eine vorzeichenlose Zahl aus.
      @ Prints an unsigned single number
@ -----------------------------------------------------------------------------
udot:
  pushdaconst 0 @ Convert to unsigned double
  b.n uddot

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "." @ ( Zahl -- )
     @ Gibt eine vorzeichenbehaftete Zahl aus.
     @ Prints a signed single number
@ -----------------------------------------------------------------------------
dot:
  pushdatos
  movs tos, tos, asr #31    @ s>d - Turn MSB into 0xffffffff or 0x00000000
  b.n ddot  
