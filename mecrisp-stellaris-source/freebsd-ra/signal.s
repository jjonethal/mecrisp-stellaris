@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2021  Robert Clausecker
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

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "signal" @ ( signo xt -- oldxt )
@ -----------------------------------------------------------------------------
signal:
  push {r4, lr}
  movs r0, r6			@ signal handler
  ldm psp!, {r6}		@ signal number
  cmp r6, #MAXSIG		@ signal in range?
  bls 0f			@ if not,
  movs r6, #0			@ report an error
  mvns r6, r6
  pop {r4, pc}			@ and return

0:cmp r0, #1			@ is this SIG_DFL or SIG_IGN?
  bhi 0f			@ if yes
  bl sigaction			@ set up signal handler
  movs r6, r0			@ old signal handler to TOS
  pop {r4, pc}			@ and return

  @ proper signal handler (not SIG_IGN or SIG_DFL)
0:ldr r3, =sighandlers		@ signal handler table
  lsls r2, r6, #2		@ at index signo
  ldr r4, [r2, r3]		@ fetch old signal handler
  str r0, [r2, r3]		@ install new signal handler
  ldr r0, =sigtramp+1		@ install trampoline for signo
  movs r1, r0			@ remember a copy
  bl sigaction
  cmp r0, r1			@ was the old signal handler our trampoline?
  bne 0f			@ if yes,
  movs r0, r4			@ return our old handler from sighandlers
0:movs r6, r0			@ else return whatever sigaction gave us
  pop {r4, pc}

  @ Call the sigaction system call to establish handler R0 for signal R6.
  @ The thumb bit must be set in R6 unless it's SIG_DFL or SIG_IGN.
  @ The old handler is returned in R0.  All other registers are preserved.
sigaction:
  push {r1, r2, r5, lr}

  @ build a sigaction structure on the stack
  movs r2, #0			@ signal mask (empty)
  movs r5, #0
  push {r2, r5}			@ push first half of signal mask

  movs r1, #2			@ SA_RESTART
  push {r0, r1, r2, r5}		@ push remaining sigaction structure

  movs r0, r6			@ the signal to handle
  mov r1, sp			@ new handler sigaction structure
  mov r2, sp			@ old handler sigaction structure
  ldr r6, =416			@ SYS_sigaction
  bl dosyscall

  ldr r0, [sp]			@ load old signal handler
  add sp, sp, #24		@ discard sigaction structure

  pop {r1, r2, r5, pc}		@ and return

  @ Signal handler trampoline
  @ On entry, R0 holds the signal number.  R7 is either the PSP or some
  @ random junk.  The OS saves all registers for us and returning
  @ returns from the signal.
sigtramp:
  push {r4, r5, r6, r7, lr}
  movs r6, #0			@ clear TOS for now

  @ first, fix up R7
  ldr r1, =pspversteck
  ldr r2, [r1]			@ fetch the stashed PSP
  cmp r2, #0			@ was there a PSP saved?
  beq 0f			@ if yes,
  movs r7, r2			@ retrieve it
  str r6, [r1]			@ and clear pspversteck

  @ then retrieve the signal handler
0:ldr r3, =sighandlers
  lsls r0, r0, #2
  ldr r0, [r3, r0]		@ signal handler address
  push {r1, r2}
  bl 1f				@ call signal handler
  pop {r1, r2}
  str r2, [r1]			@ restore pspversteck
  pop {r4, r5, r6, r7, pc}	@ and return from the signal handler
1:mov pc, r0			@ ignoring the thumb bit
