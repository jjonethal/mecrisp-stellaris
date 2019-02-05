
@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "2lshift"
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1}  @ r0 high, r1 low

  lsls r2, r1, r6
  str r2, [psp, #-4]!

  lsls r2, r0, r6

  rsbs r3, r6, #32
  lsrs r3, r1, r3
  orrs r2, r3

  subs r6, #32
  lsls r6, r1, r6
  orrs r6, r2

  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "2rshift"
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1}  @ r0 high, r1 low

  lsrs r2, r1, r6

  rsbs r3, r6, #32
  lsls r3, r0, r3
  orrs r2, r3

  subs r3, r6, #32
  lsrs r3, r0, r3
  orrs r2, r3

  str r2, [psp, #-4]!

  lsrs r6, r0, r6

  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "2arshift"
@------------------------------------------------------------------------------

  ldm psp!, {r0, r1}  @ r0 high, r1 low

  cmp r6, #32
  blo 1f
    subs r3, r6, #32
    asrs r2, r0, r3
    b 2f
1:
    lsrs r2, r1, r6
    rsbs r3, r6, #32
    lsls r3, r0, r3
    orrs r2, r3
2:
  str r2, [psp, #-4]! 

  asrs r6, r0, r6

  bx lr

 
