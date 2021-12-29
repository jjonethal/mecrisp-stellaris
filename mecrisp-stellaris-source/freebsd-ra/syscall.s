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

@ When a signal is delivered, we need to find the data and return stacks
@ to enter the user's signal handler.  Finding the return stack pointer
@ is easy (it's SP), but there is a problem with the data stack pointer.
@ While it usually resides in R7, we might temporarily need to use R7
@ for the syscall number when doing a system call.  To make it possible
@ to still find the data stack even when a system call is in progress,
@ we tuck away a copy of the original PSP into pspversteck before a
@ syscall is made.  Once the syscall is done, the PSP is restored and
@ pspversteck is cleared.  This way, we can always find the correct PSP
@ to use in a signal handler.

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_variable, "pspversteck" @ ( -- addr )
  CoreVariable pspversteck
@ -----------------------------------------------------------------------------
  pushdatos
  ldr tos, =pspversteck
  bx lr
  .word 0

@ Do a system call, taking care of the PSP.  Expects the syscall number
@ in R6 and arguments in R0--R3 as well as possibly on the stack.  R5
@ and R6 will be overwritten by this procedure.  On return, R0 and R1
@ will contain the result.  R6 will hold -1 if the system call
@ succeeded or 0 if not (in this case, R0 holds the error number).
@ R2 and R3 will be trashed.
dosyscall:
  ldr r5, =pspversteck
  str r7, [r5]			@ tuck away the psp
  movs r7, r6			@ load syscall number
  svc #0
  sbcs r6, r6			@ R6 = -1 on success, 0 on error
  ldr r7, [r5]
  movs r2, #0
  str r2, [r5]			@ mark psp as not tucked away
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dsyscall0?" @ ( no -- val0 val1 ok )
@ -----------------------------------------------------------------------------
  push {r5, lr}
  bl dosyscall
  subs psp, #8
  str r0, [psp, #4]
  str r1, [psp]
  pop {r5, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dsyscall1?" @ ( arg1 no -- val0 val1 ok )
@ -----------------------------------------------------------------------------
  push {r5, lr}
  ldr r0, [psp]
  bl dosyscall
  subs psp, #4
  str r0, [psp, #4]
  str r1, [psp]
  pop {r5, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dsyscall2?" @ ( arg1 arg2 no -- val0 val1 ok )
@ -----------------------------------------------------------------------------
  push {r5, lr}
  ldr r0, [psp, #4]
  ldr r1, [psp]
  bl dosyscall
  str r0, [psp, #4]
  str r1, [psp]
  pop {r5, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dsyscall3?" @ ( arg1 arg2 arg3 no -- val0 val1 ok )
@ -----------------------------------------------------------------------------
  push {r5, lr}
  ldm psp!, {r2}
  ldr r0, [psp, #4]
  ldr r1, [psp]
  bl dosyscall
  str r0, [psp, #4]
  str r1, [psp]
  pop {r5, pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "dsyscall4?" @ ( arg1 arg2 arg3 arg4 no -- val0 val1 ok )
@ -----------------------------------------------------------------------------
  push {r5, lr}
  ldm psp!, {r3}
  ldm psp!, {r2}
  ldr r0, [psp, #4]
  ldr r1, [psp]
  bl dosyscall
  str r0, [psp, #4]
  str r1, [psp]
  pop {r5, pc}

@ -----------------------------------------------------------------------------
@ ( arg1 arg2 arg3 arg4 no -- val0 val1 ok | R: argn .. arg4 -- argn .. arg4 )
  Wortbirne Flag_visible, "dsyscall+?"
@ -----------------------------------------------------------------------------
  ldm psp!, {r3}
  ldm psp!, {r2}
  ldr r1, [psp, #4]
  mov r0, lr			@ because the return stack holds our arguments
  str r0, [psp, #4]		@ we can't just push r5 and lr on the stack
  ldr r0, [psp]			@ so stash them onto the data stack instead
  str r5, [psp]
  bl dosyscall
  ldr r5, [psp]			@ restore R5 from the data stack
  ldr r2, [psp, #4]		@ restore LR from the data stack
  str r0, [psp, #4]
  str r1, [psp]
  bx r2				@ return to the caller

@ -----------------------------------------------------------------------------
@ ( arg1 arg2 arg3 no -- val ok | R: argn .. arg4 -- arn .. arg4 )
  Wortbirne Flag_visible, "syscall+?"
@ -----------------------------------------------------------------------------
  ldm psp!, {r3}
  ldm psp!, {r2}
  ldr r1, [psp, #4]
  mov r0, lr			@ because the return stack holds our arguments
  str r0, [psp, #4]		@ we can't just push r5 and lr on the stack
  ldr r0, [psp]			@ so stash them onto the data stack instead
  str r5, [psp]
  bl dosyscall
  ldm psp!, {r5}		@ restore R5 from the data stack
  ldr r2, [psp]			@ restore LR from the data stack
  str r0, [psp]
  bx r2				@ return to the caller

@ -----------------------------------------------------------------------------
@ ( arg1 arg2 arg3 arg4 no -- val0 val1 | R: argn .. arg4 -- argn .. arg4 )
  Wortbirne Flag_visible, "dsyscall+"
@ -----------------------------------------------------------------------------
  ldm psp!, {r3}
  ldm psp!, {r2}
  ldr r1, [psp, #4]
  mov r0, lr			@ because the return stack holds our arguments
  str r0, [psp, #4]		@ we can't just push r5 and lr on the stack
  ldr r0, [psp]			@ so stash them onto the data stack instead
  str r5, [psp]
  bl dosyscall
  ldm psp!, {r5}		@ restore R5 from the data stack
  ldr r2, [psp]			@ restore LR from the data stack
  str r0, [psp]
  movs r6, r1
  bx r2				@ return to the caller

@ -----------------------------------------------------------------------------
@ ( arg1 arg2 arg3 no -- val | R: argn .. arg4 -- arn .. arg4 )
  Wortbirne Flag_visible, "syscall+"
@ -----------------------------------------------------------------------------
  ldm psp!, {r3}
  ldm psp!, {r2}
  ldr r1, [psp, #4]
  mov r0, lr			@ because the return stack holds our arguments
  str r0, [psp, #4]		@ we can't just push r5 and lr on the stack
  ldr r0, [psp]			@ so stash them onto the data stack instead
  str r5, [psp]
  bl dosyscall
  ldm psp!, {r5}		@ restore R5 from the data stack
  ldm psp!, {r2}		@ restore LR from the data stack
  movs r6, r0
  bx r2				@ return to the caller

  .ltorg
