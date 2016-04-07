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

@ Inline-Cache for Optimisation across the inlined definitions

@ -----------------------------------------------------------------------------
add_to_inline_cache: @ ( Address|Literal Flag -- )
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr} @ Sollte noch Platz im Inline-Cache sein, füge dieses Paar hinzu. Ansonsten markiere die Definition als zu lang, um sie einfügen zu können.

  popda r2 @ Flag
  popda r3 @ Address|Literal

  ldr r0, =inline_cache_count
  ldr r1, [r0]

  cmp r1, #inline_cache_length
  bhs 1f

    @ Fein. Ein neues Element kommt in den Cache hinein !
    movs r0, #6 @ Jedes Element benötigt 6 Bytes
    muls r1, r0    

    ldr r0, =inline_cache @ Startadresse des Caches
    adds r0, r1           @ Elementoffser dazuaddieren

    @ Zuerst die Adresse:
    strh r3, [r0, #0] @ Low
    lsrs r3, #16
    strh r3, [r0, #2] @ High
    @ Dann die Flags
    strh r2, [r0, #4]

1:@ Zu lang ! Es passt nichts mehr in den Cache hinein. 

  ldr r0, =inline_cache_count
  ldr r1, [r0]  
  adds r1, #1  @ Die Anzahl von Elementen im Inline-Cache aktualisieren
  str r1, [r0]

  pop {r0, r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
inline_cache_schreiben:
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, lr}
@  writeln "Inline-Cache-Schreiben"
  ldr r0, =inline_cache_count
  ldr r1, [r0]

  cmp r1, #inline_cache_length
  bhi 3f @ Ein Element mehr zulassen als bei add_to_inline_cache - da das letzte Element stets ; ist.
    @ Fein. Der Inline-Cache enthält die komplette Kompilationssequenz zum Vererben der Optimierungen !

    @ Jetzt den Inhalt des Inline-Caches fein säuberlich einkompilieren :-)
    ldr r0, =inline_cache @ r1 enthält die Anzahl von Elementen.
    subs r1, #1 @ Insgesamt ein Element weniger, weil ; auch mit in den Inline-Cache kommt.
    beq 4f @ Sonst nichts vorhanden ? Bei einer leeren Definition kann diese als 0-faltbar markiert und komplett wegoptimiert werden.

    pushda r1 @ Zahl der Elemente schreiben
    bl hkomma

1:  @ Ein Element einkompilieren:
    pushdatos
    ldrh tos, [r0, #0] @ Adresse low
    bl hkomma

    pushdatos
    ldrh tos, [r0, #2] @ Adresse high
    bl hkomma

    pushdatos
    ldrh tos, [r0, #4] @ Flags zuletzt, damit dieses Flag nie als leerer Flash erkannt wird !
    bl hkomma

    adds r0, #6
    subs r1, #1
    bne 1b @ Noch ein Element ?

2:  @ Flag für den jetzt vorhandenen RA-Optimierungsteil setzen !
    pushdaconstw Flag_inlinecache & ~Flag_visible
    bl setflags

3:@ Zu lang, nicht komplett erfasst ! Kann leider keine Optimiervererbungssequenz schreiben.
  pop {r0, r1, r2, r3, pc}

4:@ Leere Definition. als 0-faltbar markieren, damit sie komplett wegoptimiert werden kann.
  pushdaconst Flag_foldable_0 & ~Flag_visible
  bl setflags
  pop {r0, r1, r2, r3, pc}

@ -----------------------------------------------------------------------------
inline_cache_parser: @ ( Einsprungadresse -- )
@ -----------------------------------------------------------------------------
  push {lr} @ Wenn die Optimiersequenz geschrieben worden ist, ist auch mindestens ein Element darin vorhanden.

  popda r0
  bl suchedefinitionsende
  ldrh r1, [r0] @ Länge der Sequenz abholen
  adds r0, #2

1:@ Hole das nächste Element !

  pushdatos
  ldrh tos, [r0, #0] @ Adresse low
  ldrh r2,  [r0, #2] @ Adresse high
  lsls r2, #16
  orrs tos, r2

  pushdatos
  ldrh tos, [r0, #4] @ Flags

  push {r0, r1}
  bl kompilator
  pop {r0, r1}
  adds r0, #6
  subs r1, #1
  bne 1b

  pop {pc}
