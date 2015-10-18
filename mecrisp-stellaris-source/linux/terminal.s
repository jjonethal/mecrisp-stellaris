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

@ Terminalroutinen
@ Terminal code and initialisations.
@ Porting: Rewrite this !

.include "../common/terminalhooks.s"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "nop" @ ( -- ) @ Handler for unused hooks
nop_vektor:                    
@ ----------------------------------------------------------------------------- 
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
  push {lr}
  bl pause
 
  push {r0, r1, r2, r3, r4, r5, r7}
 
  push {r6}
  
  movs r0, #1   @ File descriptor 1: STDOUT
  mov  r1, sp   @ Pointer to Message
  movs r2, #1   @ 1 Byte
  movs r7, #4   @ Syscall 4: Write
  swi #0
  
  pop {r6}
 
  pop {r0, r1, r2, r3, r4, r5, r7}
  
  drop
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
  push {lr}
  bl pause
  pushdatos
  
  push {r0, r1, r2, r3, r4, r5, r7}
 
  push {r6}
  
  movs r0, #0   @ File descriptor 0: STDIN
  mov  r1, sp   @ Pointer to Message
  movs r2, #1   @ 1 Byte
  movs r7, #3   @ Syscall 3: Read
  swi #0
  
  pop {r6}
  
  pop {r0, r1, r2, r3, r4, r5, r7}
  
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause
   pushdaconst -1
   pop {pc}
   
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause
   pushdaconst -1
   pop {pc}

@ -----------------------------------------------------------------------------
 Wortbirne Flag_visible, "syscall" @ ( r0 r1 r2 r3 r4 r5 r6 Syscall# -- r0 )
@ -----------------------------------------------------------------------------
 push {lr}
 push {r4, r5, r7} @ Save registers !

 push {r6} @ Syscall number

 ldm psp!, {r6}
 ldm psp!, {r5}
 ldm psp!, {r4}
 ldm psp!, {r3}
 ldm psp!, {r2}
 ldm psp!, {r1}
 ldm psp!, {r0}

 pop {r7} @ into r7

 swi #0

 pop {r4, r5, r7}

 adds r7, #28 @ Drop 7 elements at once
 movs r6, r0 @ Syscall reply into TOS
 
 pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "bye"
@ -----------------------------------------------------------------------------
  movs r0, #0  @ Error code 0
  movs r7, #1  @ Syscall 1: Exit
  swi #0
   
  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
         @ Write the many special hardware locations now !
