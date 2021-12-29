
@ -----------------------------------------------------------------------------
emit: @ ( c -- ) Emit one character from r4
@ -----------------------------------------------------------------------------

  push {r0, r1, r2, r3, r5, r6, r7, lr}

  push {r4}

  movs r0, #1   @ File descriptor 1: STDOUT
  mov  r1, sp   @ Pointer to Message
  movs r2, #1   @ 1 Byte
  movs r7, #4   @ Syscall 4: Write
  swi #0

  pop {r4}

  pop {r0, r1, r2, r3, r5, r6, r7, pc}

@ -----------------------------------------------------------------------------
key: @ ( -- c ) Receive one character into r4
@ -----------------------------------------------------------------------------
  push {r0, r1, r2, r3, r5, r6, r7, lr}

  push {r4}

  movs r0, #0   @ File descriptor 0: STDIN
  mov  r1, sp   @ Pointer to Message
  movs r2, #1   @ 1 Byte
  movs r7, #3   @ Syscall 3: Read
  swi #0

  pop {r4}

  pop {r0, r1, r2, r3, r5, r6, r7}

  cmp r4, #4 @ Ctrl-D
  beq.n bye

  pop {pc}

@ -----------------------------------------------------------------------------
bye: @ ( -- ) Quit this program.
@ -----------------------------------------------------------------------------
  movs r0, #0  @ Error code 0
  movs r7, #1  @ Syscall 1: Exit
  swi #0
