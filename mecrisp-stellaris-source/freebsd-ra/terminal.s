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

@ syscall.s and signal.s are unusually long; dump literals here so we don't
@ exceed the maximum offset for ldr Rd, =...
.ltorg

.include "syscall.s"
.include "signal.s"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "nop" @ ( -- ) @ Handler for unused hooks
nop_vektor:                    
@ ----------------------------------------------------------------------------- 
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "stdin" @ ( -- u )
  CoreVariable stdin
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =stdin
  bx lr
  .word 0

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "stdout" @ ( -- addr )
  CoreVariable stdout
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =stdout
  bx lr
  .word 1

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
  push {lr}
  bl pause
 
  push {r5, r6}

  ldr r0, =stdout
  ldr r0, [r0]		@ write to stdout
  add r1, sp, #4	@ point r1 to the pushed r6
  movs r2, #1		@ write 1 byte
  movs r6, #4		@ SYS_WRITE
  bl dosyscall

  pop {r5, r6}
  drop
  pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause
   pushdatos
   movs tos, #0
   rsbs tos, tos, #0
   pop {pc}
   
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause
   pushdatos
   movs tos, #0
   rsbs tos, tos, #0
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
  push {lr}
  bl pause
  pushdaconst 0
  
  push {r5, r6}

  ldr r0, =stdin
  ldr r0, [r0]		@ read from stdin
  add r1, sp, #4	@ point r1 to the pushed r6
  movs r2, #1		@ read 1 byte
  movs r6, #3		@ SYS_READ
  bl dosyscall

  cmp r6, #0		@ read error?
  beq.n bye
  cmp r0, #0		@ EOF?
  beq.n bye

  pop {r5, r6}

  pop {pc}
     
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "cacheflush" @ ( addr len -- )
cacheflush:
@ -----------------------------------------------------------------------------
  mov r1, tos			@ Länge des zu sichernden Bereiches
  ldm psp!, {r0}		@ addr nach r0
  push {r0, r1, r5, lr}		@ arm_synch_icache_args (addr, len) auf den Stack
  movs r0, #0			@ ARM_SYNC_ICACHE
  mov r1, sp			@ Die soeben auf den Stack gelegte Struktur
  movs r6, #165			@ Syscall 165: sysarch()
  bl dosyscall			@ Systemaufruf: synchronisiere den icache
				@ also sysarch(ARM_SYNC_ICACHE, {addr, len})
  ldm psp!, {tos}		@ TOS wiederherstellen
  pop {r0, r1, r5, pc}		@ Stack aufräumen, Rücksprung

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_0, "arguments" @ ( -- a-addr )
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =arguments
  ldr tos, [tos]
  bx lr
  
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "reset"
@ -----------------------------------------------------------------------------
  bl Reset
 
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "bye"
bye:
@ -----------------------------------------------------------------------------
  bl uart_reset
  movs r0, #0  @ Error code 0
  movs r6, #1  @ Syscall 1: Exit
  bl dosyscall
   
@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "incipit"
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =incipit
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "explicit"
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =explicit
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "uart-init"
@ -----------------------------------------------------------------------------
uart_init:
  adr r2, termios_mecrisp
  b tcsetattr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "uart-reset"
@ -----------------------------------------------------------------------------
uart_reset:
  adr r2, termios_sane
  b tcsetattr

  .equ termios_len, 44	@ size of the termios structure
			@ the structure is laid out as such:
			@  0 c_iflag  -- input flags
			@  4 c_oflag  -- output flags
			@  8 c_cflag  -- control flags
			@ 12 c_lflag  -- local flags
			@ 16 c_cc     -- control characters (20 characters)
			@ 36 c_ispeed -- input speed (in Baud)
			@ 40 c_ospeed -- output speed (in Baud)

  @ fetch the termios structure for stdin into the buffer pointed to by R2.
  @ if stdin is a terminal, return 0.  Else, the contents of the buffer are
  @ not defined.  Preserves R4 to R7
@tcgetattr:
@  push {r5, lr}
@  bl savepsp
@  movs r6, #54			@ SYS_ioctl
@  movs r0, #0			@ STDIN_FILENO
@  ldr r1, =0x402c7413		@ TIOCGETA
@  bl dosyscall
@  pop {r5, pc}

  @ set the termios structure for stdin to the buffer pointed to by R2.
  @ if stdin is a terminal, return 0.  Else return some other value.
  @ Preserves R4 to R7.
tcsetattr:
  push {r5, lr}
  movs r6, #54			@ SYS_ioctl
  movs r0, #0			@ STDIN_FILENO
  ldr r1, =0x802c7414		@ TIOCSETA
  bl dosyscall
  pop {r5, pc}

  @ a termios structure with sane default values
  .align
termios_sane:
  .int 0x00002b02		@ c_iflag
  .int 0x00000003		@ c_oflag
  .int 0x00004b00		@ c_cflag
  .int 0x000005cb		@ c_lflag
  .byte 0x04, 0xff, 0xff, 0x7f	@ c_cc
  .byte 0x17, 0x15, 0x12, 0x08 
  .byte 0x03, 0x1c, 0x1a, 0x19
  .byte 0x11, 0x13, 0x16, 0x0f
  .byte 0x01, 0x00, 0x14, 0xff
  .int 0x00002580		@ c_ispeed
  .int 0x00002580		@ c_ospeed

  @ a termios structure with values appropriate for Mecrisp Stellaris
  @ same as termios_sane, but with ICANON and ECHO disabled.
termios_mecrisp:
  .int 0x00002b02		@ c_iflag
  .int 0x00000003		@ c_oflag
  .int 0x00004b00		@ c_cflag
  .int 0x000004c3		@ c_lflag
  .byte 0x04, 0xff, 0xff, 0x7f	@ c_cc
  .byte 0x17, 0x15, 0x12, 0x08 
  .byte 0x03, 0x1c, 0x1a, 0x19
  .byte 0x11, 0x13, 0x16, 0x0f
  .byte 0x01, 0x00, 0x14, 0xff
  .int 0x00002580		@ c_ispeed
  .int 0x00002580		@ c_ospeed

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
         @ Write the many special hardware locations now !
