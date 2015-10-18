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

@ Forth Core. This file sets up dictionary structure and includes all definitions.


@ -----------------------------------------------------------------------------
@ Festverdrahtete Kernvariablen, Puffer und Stacks zu Begin des RAMs
@ Hardwired core variables, buffers and stacks at the begin of RAM
@ -----------------------------------------------------------------------------

.set rampointer, RamAnfang  @ Ram-Anfang setzen  Set location for core variables.

@ Variablen des Kerns  Variables of core that are not visible

ramallot Dictionarypointer, 4
ramallot Fadenende, 4
ramallot konstantenfaltungszeiger, 4
ramallot leavepointer, 4
ramallot Datenstacksicherung, 4
ramallot Einsprungpunkt, 4

@ Variablen für das Flashdictionary  Variables for Flash management

ramallot ZweitDictionaryPointer, 4
ramallot ZweitFadenende, 4
ramallot FlashFlags, 4
ramallot VariablenPointer, 4

@ Jetzt kommen Puffer und Stacks:  Buffers and Stacks

.equ Zahlenpufferlaenge, 63 @ Zahlenpufferlänge+1 sollte durch 4 teilbar sein !      Number buffer (Length+1 mod 4 = 0)
ramallot Zahlenpuffer, Zahlenpufferlaenge+1 @ Reserviere mal großzügig 64 Bytes RAM für den Zahlenpuffer

.equ Maximaleeingabe,    200             @ Input buffer for an Address-Length string
ramallot Eingabepuffer, Maximaleeingabe  @ Eingabepuffer wird einen Adresse-Länge String enthalten


.ifdef flash16bytesblockwrite
ramallot datenstackende, 512  @ Larger data stack because it will be used for buffering a 256 byte block
ramallot datenstackanfang, 0  @ during Flash write on LPC1114FN28
.else
ramallot datenstackende, 256  @ Data stack
ramallot datenstackanfang, 0
.endif

ramallot returnstackende, 256  @ Return stack
ramallot returnstackanfang, 0

.ifdef emulated16bitflashwrites
  .equ Sammelstellen, 32 @ 32 * 6 = 192 Bytes.
  ramallot Sammeltabelle, Sammelstellen * 6 @ 16-Bit Flash write emulation collection buffer
.endif

.ifdef flash16bytesblockwrite
  .equ Sammelstellen, 32 @ 32 * (16 + 4) = 640 Bytes
  ramallot Sammeltabelle, Sammelstellen * 20 @ Buffer 16 blocks of 16 bytes each for ECC constrained Flash write

  ramallot iap_command, 5*4
  ramallot iap_reply, 4*4
.endif

.equ RamDictionaryAnfang, rampointer @ Ende der Puffer und Variablen ist Anfang des Ram-Dictionary.  Start of RAM dictionary
.equ RamDictionaryEnde,   RamEnde    @ Das Ende vom Dictionary ist auch das Ende vom gesamten Ram.   End of RAM dictionary = End of RAM


@ -----------------------------------------------------------------------------
@ Vorbereitung der Dictionarystruktur
@ Preparations for dictionary structure
@ -----------------------------------------------------------------------------

CoreDictionaryAnfang: @ Dictionary-Einsprungpunkt setzen 
                      @ Set entry point for Dictionary

.set CoreVariablenPointer, RamDictionaryEnde @ Im Flash definierte Variablen kommen ans RAM-Ende
                                             @ Variables defined in Flash are placed at the end of RAM

  Wortbirne Flag_invisible, "--- Mecrisp-Stellaris Core ---"

@ -----------------------------------------------------------------------------
@ Include the complete Mecrisp-Stellaris core
@ -----------------------------------------------------------------------------

  .include "../common/double.s"
  .include "../common/stackjugglers.s" 
  .include "../common/logic.s"
  .include "../common/comparisions.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .include "../common/memory.s"
  .include "flash.s"
  .ltorg @ Mal wieder Konstanten schreiben

  .ifdef emulated16bitflashwrites
  .include "../common/hflashstoreemulation.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .endif

  .ifdef flash16bytesblockwrite
  .include "../common/flash16bytesblockwrite.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .endif
  
  .include "../common/calculations.s"
  .include "terminal.s"
  .include "../common/query.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .include "../common/strings.s"
  .include "../common/deepinsight.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .include "../common/compiler.s"
  .include "../common/compiler-flash.s"
  .include "../common/controlstructures.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .include "../common/doloop.s"
  .include "../common/case.s"
  .include "../common/token.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .include "../common/numberstrings.s"
  .ltorg @ Mal wieder Konstanten schreiben
  .include "../common/interpreter.s"
  .ltorg @ Mal wieder Konstanten schreiben

  .ifndef within_os
  .include "../common/interrupts-common.s"
  .include "interrupts.s" @ You have to change interrupt handlers for Porting !
  .endif

@ -----------------------------------------------------------------------------
@ Schließen der Dictionarystruktur und Zeiger ins Flash-Dictionary
@ Finalize the dictionary structure and put a pointer into changeable Flash-Dictionary
@ -----------------------------------------------------------------------------

  Wortbirne_Kernende Flag_invisible, "--- Flash Dictionary ---"

@ -----------------------------------------------------------------------------
@  End of Dictionary
@ -----------------------------------------------------------------------------
