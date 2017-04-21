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

@ Double number support

@------------------------------------------------------------------------------
@ --- Double stack jugglers ---
@------------------------------------------------------------------------------

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "2dup" @ ( 2 1 -- 2 1 2 1 )
@ -----------------------------------------------------------------------------
  ldr r0, [psp]
  pushdatos
  subs psp, #4
  str r0, [psp]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "2drop" @ ( 2 1 -- )
ddrop_vektor:
@ -----------------------------------------------------------------------------
  adds psp, #4
  drop
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_4, "2swap" @ ( 4 3 2 1 -- 2 1 4 3 )
dswap:
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}
  subs psp, #4
  str r0, [psp]
  pushdatos
  subs psp, #4
  str r2, [psp]
  movs tos, r1
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "2nip" @ ( 4 3 2 1 -- 2 1 )
dnip:
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}
  subs psp, #4
  str r0, [psp]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_4, "2over" @ ( 4 3 2 1 -- 4 3 2 1 4 3 )
@ -----------------------------------------------------------------------------
  ldr r0, [psp, #8]
  pushdatos
  subs psp, #4
  str r0, [psp]
  ldr tos, [psp, #12]  
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_4, "2tuck" @ ( 4 3 2 1 -- 2 1 4 3 2 1 )
@ -----------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2} @ w=2 x=3 y=4
  subs psp, #4
  str r0, [psp]
  pushdatos
  subs psp, #4
  str r2, [psp]
  subs psp, #4
  str r1, [psp]
  subs psp, #4
  str r0, [psp]
  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_6, "2rot" @ ( 6  5 4 3 2 1  -- 4  3 2 1 6 5 ) ( x w y -- w y x )
                                    @  16 12 8 4 0 tos  16 12 8 4 0 tos
@ -----------------------------------------------------------------------------
  ldr r0, [psp]
  ldr r1, [psp, #8]
  ldr r2, [psp, #16]

  str r0, [psp, #8]
  str r1, [psp, #16]
  str r2, [psp]

  ldr r1, [psp, #4]
  str tos, [psp, #4]
  ldr tos, [psp, #12]
  str r1, [psp, #12]

  bx lr

@ -----------------------------------------------------------------------------
  Wortbirne Flag_foldable_6, "2-rot" @ ( 6  5 4 3 2 1 --  2  1 6 5 4 3 ( x w y -- y x w )
                                     @  16 12 8 4 0 tos  16 12 8 4 0 tos
@ -----------------------------------------------------------------------------
  ldr r0, [psp]
  ldr r1, [psp, #8]
  ldr r2, [psp, #16]

  str r0, [psp, #16]
  str r1, [psp]
  str r2, [psp, #8]

  ldr r1, [psp, #12]
  str tos, [psp, #12]
  ldr tos, [psp, #4]
  str r1, [psp, #4]

  bx lr


@------------------------------------------------------------------------------
@ --- Double return stack jugglers ---
@------------------------------------------------------------------------------

@  : p 3 4 .s 2>r .s 2r@ .s . . 2r> .s 2drop .s ; 
@  : 2>r swap >r >r inline ;
@  : 2r> r> r> swap inline ;

@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "2>r" @ Puts the two top elements of stack on returnstack.
                               @ Equal to swap >r >r 
@------------------------------------------------------------------------------
  ldm psp!, {r0}
  push {r0}
  push {tos}
  ldm psp!, {tos}
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "2r>" @ Fetches back two elements of returnstack.
                               @ Equal to r> r> swap
@------------------------------------------------------------------------------
  pushdatos
  pop {tos}
  pop {r0}
  subs psp, #4
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "2r@" @ Copies the two top elements of returnsteack
@------------------------------------------------------------------------------  
  pushdatos
  ldr tos, [sp, #4]
  pushdatos
  ldr tos, [sp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_inline, "2rdrop" @ Entfernt die obersten beiden Element des Returnstacks
@------------------------------------------------------------------------------
  add sp, #8
  bx lr


@------------------------------------------------------------------------------
@ --- Double calculations ---
@------------------------------------------------------------------------------

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_2, "d2/"
@------------------------------------------------------------------------------
  ldr r0, [psp]
  lsls r1, tos, #31 @ Prepare Carry
  asrs tos, #1     @ Shift signed high part right
  lsrs r0, #1       @ Shift low part
  orrs r0, r1
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2, "d2*"
@------------------------------------------------------------------------------
  ldr r0, [psp]
  adds r0, r0
  adcs tos, tos
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_2, "dshr"
@------------------------------------------------------------------------------
  ldr r0, [psp]
  lsls r1, tos, #31 @ Prepare Carry
  lsrs tos, #1     @ Shift unsigned high part right
  lsrs r0, #1       @ Shift low part
  orrs r0, r1
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2, "dshl"
@------------------------------------------------------------------------------
  ldr r0, [psp]
  adds r0, r0
  adcs tos, tos
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_2, "dabs"
@------------------------------------------------------------------------------
dabs:
  cmp tos, #0   @ Check sign in high-part
  bmi.n dnegate @ Not negative ? Nothing to do !
  bx lr

@------------------------------------------------------------------------------
@  Wortbirne Flag_foldable_3, "?dnegate" @ Negate a double number if top element on stack is negative.
@------------------------------------------------------------------------------
@   popda r0
@   cmp r0, #0
@   bmi.n dnegate
@   bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_foldable_2, "dnegate"
@------------------------------------------------------------------------------
dnegate:
  ldr r0, [psp]
  movs r1, #0
  mvns r0, r0
  mvns tos, tos
  adds r0, #1
  adcs tos, r1
  str r0, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_4, "d-" @ ( 1L 1H 2L 2H )
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}
  subs r2, r0     @  Low-part first
  sbcs r1, tos   @ High-part with carry
  movs tos, r1

  subs psp, #4
  str r2, [psp]
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_4, "d+" @ ( 1L 1H 2L 2H )
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}
  adds r2, r0
  adcs tos, r1
  subs psp, #4
  str r2, [psp]
  bx lr
  
@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_1, "s>d" @ ( n - dl dh ) Single --> Double conversion
@------------------------------------------------------------------------------
  pushdatos
  movs tos, tos, asr #31    @ Turn MSB into 0xffffffff or 0x00000000
  bx lr

@------------------------------------------------------------------------------
@ --- Double star and slash ---
@------------------------------------------------------------------------------


  .ifdef m0core

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_2, "um*"
  @ Multiply unsigned 32*32 = 64
  @ ( u u -- ud )
um_star:
@------------------------------------------------------------------------------
    ldr r0, [psp]  @ To be calculated: Tos * r0

    @ Calculate low part in hardware:
    movs r3, r0    @ Save the low part for later
    muls r3, tos   @ Gives complete low-part of result
    str r3, [psp]  @ Store low part

    @ Calculate high part:
    lsrs r1, r0,  #16 @ Shifted half
    lsrs r2, tos, #16 @ Shifted half

    movs r3, r1  @ High-High
    muls r3, r2

    @ Low-High and High-Low
    uxth tos, tos
    uxth r0, r0

    muls tos, r1
    muls r0, r2
    adds tos, r0

    lsrs tos, #16 @ Shift accordingly
    adds tos, r3  @ Add together
    bx lr
   
  .else

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2, "um*"
  @ Multiply unsigned 32*32 = 64
  @ ( u u -- ud )
um_star:
@------------------------------------------------------------------------------

    ldr r0, [psp]
    umull r0, tos, r0, tos @ Unsigned long multiply 32*32=64
    str r0, [psp]
    bx lr

  .endif


  .ifdef m0core

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_2, "m*"
  @ Multiply signed 32*32 = 64
  @ ( n n -- d )
m_star:
@------------------------------------------------------------------------------

    ldr r0, [psp]
    movs r1, r0, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq 1f
    @ - * ?
      rsbs r0, r0, #0
      str r0, [psp]

      movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
      beq 2f @ - * +

      @ - * -
      rsbs tos, tos, #0
      b.n um_star

1:  @ + * ?
    movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq.n um_star @ + * +
    @ + * -
    rsbs tos, tos, #0

    @ - * + or + * -
2:  push {lr}
    bl um_star
    bl dnegate
    pop {pc}

  .else

@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2, "m*"
  @ Multiply signed 32*32 = 64
  @ ( n n -- d )
m_star:
@------------------------------------------------------------------------------

    ldr r0, [psp]
    smull r0, tos, r0, tos @ Signed long multiply 32*32=64
    str r0, [psp]
    bx lr

  .endif

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "ud*"
ud_short_star:
         @ Unsigned multiply 64*64 = 64
         @ ( ud1 ud2 -- ud )
@------------------------------------------------------------------------------
  @ Multiply r1:r0 and r3:r2 and return the product in r1:r0
  @          tos w      x y  

@ r1:r0  r3:r2 -->  r1:r0
@ tos r0 r1 r2 -->  tos r0

        ldm psp!, {r0, r1, r2}

	muls	tos, r2        @ High-1 * Low-2 --> tos
	muls	r1, r0         @ High-2 * Low-1 --> r1
	adds	tos, r1        @                    Sum into tos
	
	lsrs	r1, r0, #16
	lsrs	r3, r2, #16
	muls	r1, r3
	adds	tos, r1

	lsrs	r1, r0, #16
	uxth	r0, r0
	uxth	r2, r2
	muls	r1, r2
	muls	r3, r0
	muls	r0, r2
	
	movs	r2, #0
	adds	r1, r3
	adcs	r2, r2
	lsls	r2, #16
	adds	tos, r2
	
	lsls	r2, r1, #16
	lsrs	r1, #16
	adds	r0, r2
	adcs	tos, r1

        subs psp, #4
        str r0, [psp]

        bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "udm*"
ud_star: @ Unsigned multiply 64*64 = 128
         @ ( ud1 ud2 -- udl udh )
@------------------------------------------------------------------------------
  @ Auf dem Datenstack: ( 1L 1H 2L 2H -- LL  L  H HH )
  @                       12  8  4  0 nach pushdatos
  @                        d  c  b  a    r0 r1 r2 r3
  @ Benötige einen langen Ergebnisregister !

  push {r4, lr}
  movs r4, #0 @ For Carry addition

  @ ( d c b a )
  pushdatos
  ldr tos, [psp, #4]    @ b
  pushdatos
  ldr tos, [psp, #12+4] @ d
  bl um_star
  @ ( d c b a  b*d-Low b*d-High )
  popda r1 @ b*d-High
  popda r0 @ b*d-Low, finished value

  @ ( d c b a )

  pushdatos
  ldr tos, [psp, #0]   @ a
  pushdatos
  ldr tos, [psp, #8+4] @ c
  push {r0, r1}
    bl um_star
  pop {r0, r1}
  @ ( d c b a  a*c-Low a*c-High )
  popda r3 @ a*c-High
  popda r2 @ a*c-Low

  @ ( d c b a )

  pushdatos
  ldr tos, [psp, #0]    @ a
  pushdatos
  ldr tos, [psp, #12+4] @ d

  push {r0, r1, r2, r3}
    bl um_star
  pop {r0, r1, r2, r3}
  @ ( d c b a  a*d-Low a*d-High )

  adds r2, tos @ a*c-Low + a*d-High
  adcs r3, r4  @ Carry
  drop

  adds r1, tos @ a*d-Low + b*d-High
  adcs r2, r4  @ Carry
  adcs r3, r4  @ Carry
  drop

  @ ( d c b a )

  pushdatos
  ldr tos, [psp, #4]    @ b
  pushdatos
  ldr tos, [psp, #8+4]  @ c

  push {r0, r1, r2, r3}
    bl um_star
  pop {r0, r1, r2, r3}
  @ ( d c b a  b*c-Low b*c-High )

  adds r2, tos @ a*c-Low + b*c-High + a*d-High
  adcs r3, r4  @ Carry
  drop

  adds r1, tos @ b*c-Low + a*d-Low + b*d-High
  adcs r2, r4  @ Carry
  adcs r3, r4  @ Carry
  drop

  @ ( d c b tos: a )
  movs tos, r3
  str r2, [psp, #0]
  str r1, [psp, #4]
  str r0, [psp, #8]

  pop {r4, pc}


@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "*/" @ Signed scalar
  @ ( u1 u2 u3 -- u1*u2/u3 ) With double length intermediate result
@------------------------------------------------------------------------------
  push {lr}
  to_r
  bl m_star
  r_from
  bl m_slash_mod
  nip
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "*/mod" @ Signed scalar
  @ ( u1 u2 u3 -- u1*u2/u3 ) With double length intermediate result
@------------------------------------------------------------------------------
  push {lr}
  to_r
  bl m_star
  r_from
  bl m_slash_mod
  pop {pc}

@ : u*/  ( u1 u2 u3 -- u1 * u2 / u3 )  >r um* r> um/mod nip 3-foldable ;
@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "u*/" @ Unsigned scalar
  @ ( u1 u2 u3 -- u1*u2/u3 ) With double length intermediate result
@------------------------------------------------------------------------------
  push {lr}
  to_r
  bl um_star
  r_from
  bl um_slash_mod
  nip
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "u*/mod" @ Unsigned scalar
  @ ( u1 u2 u3 -- u1*u2/u3 ) With double length intermediate result
@------------------------------------------------------------------------------
  push {lr}
  to_r
  bl um_star
  r_from
  bl um_slash_mod
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "um/mod"
um_slash_mod: @ ( ud u -- u u ) Dividend Divisor -- Rest Ergebnis
             @ 64/32 = 32 Rest 32
@------------------------------------------------------------------------------
  push {lr}
  pushdaconst 0
  bl ud_slash_mod
  drop
  nip
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_3, "m/mod"
              @ Signed symmetric divide 64/32 = 32 remainder 32
m_slash_mod:  @ ( d n -- n n )
@------------------------------------------------------------------------------
  push {lr}
  pushdatos                 @ s>d
  movs tos, tos, asr #31    @ Turn MSB into 0xffffffff or 0x00000000
  bl d_slash_mod
  drop
  nip
  pop {pc}

@------------------------------------------------------------------------------
@ Tool for ud/mod
@------------------------------------------------------------------------------

  .macro division_step
    @ Shift the long chain of four registers.
    lsls r0, #1
    adcs r1, r1
    adcs r2, r2
    adcs r3, r3

    @ Compare Divisor with top two registers
    cmp r3, r5 @ Check high part first
    bhi 1f
    blo 2f

    cmp r2, r4 @ High part is identical. Low part decides.
    blo 2f

    @ Subtract Divisor from two top registers
1:  subs r2, r4 @ Subtract low part
    sbcs r3, r5 @ Subtract high part with carry

    @ Insert a bit into Result which is inside LSB of the long register.
    adds r0, #1
2:
  .endm

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "ud/mod"
         @ Unsigned divide 64/64 = 64 remainder 64
         @ ( ud1 ud2 -- ud ud)
         @ ( 1L 1H 2L tos: 2H -- Rem-L Rem-H Quot-L tos: Quot-H )
@------------------------------------------------------------------------------
ud_slash_mod:
   push {r4, r5}

   @ ( DividendL DividendH DivisorL DivisorH -- RemainderL RemainderH ResultL ResultH )
   @   8         4         0        tos      -- 8          4          0       tos


   @ Shift-High Shift-Low Dividend-High Dividend-Low
   @         r3        r2            r1           r0

   movs r3, #0
   movs r2, #0
   ldr  r1, [psp, #4]
   ldr  r0, [psp, #8]

   @ Divisor-High Divisor-Low
   @          r5           r4

ud_slash_mod_internal:
   movs r5, tos
   ldr  r4, [psp, #0]

   @ For this long division, we need 64 individual division steps.
   movs tos, #64

3: division_step
   subs tos, #1
   bne 3b

   @ Now place all values to their destination.
   movs tos, r1       @ Result-High
   str  r0, [psp, #0] @ Result-Low
   str  r3, [psp, #4] @ Remainder-High
   str  r2, [psp, #8] @ Remainder-Low

   pop {r4, r5}
   bx lr

@------------------------------------------------------------------------------
@  Wortbirne Flag_visible|Flag_foldable_4, "uf/mod" @ Internal helper only.
uf_slash_mod: @ Divide 64/64 = 64 Remainder 64. Puts decimal point in the middle. Overflow possible.
         @ ( ud1 ud2 -- ud ud)
         @ ( 1L 1H 2L tos: 2H -- Rem-L Rem-H Quot-L tos: Quot-H )
@------------------------------------------------------------------------------
   push {r4, r5}

   movs r3, #0
   ldr  r2, [psp, #4]
   ldr  r1, [psp, #8]
   movs r0, #0

   b.n ud_slash_mod_internal

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "d/mod"
              @ Signed symmetric divide 64/64 = 64 remainder 64
              @ ( d1 d2 -- d d )
d_slash_mod:  @ ( 1L 1H 2L tos: 2H -- Rem-L Rem-H Quot-L tos: Quot-H )
@------------------------------------------------------------------------------
  @ Check Divisor
  push {lr}
  movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
  beq 2f
    @ ? / -
    bl dnegate
    bl dswap
    movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq 1f
    @ - / -
    bl dnegate
    bl dswap
    bl ud_slash_mod

    bl dswap
    bl dnegate @ Negative remainder
    bl dswap
    pop {pc}

1:  @ + / -
    bl dswap
    bl ud_slash_mod
    bl dnegate  @ Negative result
    pop {pc}

2:  @ ? / +
    bl dswap
    movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq 3f
    @ - / +
    bl dnegate
    bl dswap

    bl ud_slash_mod

    bl dnegate @ Negative result
    bl dswap
    bl dnegate @ Negative remainder
    bl dswap
    pop {pc}

3:  @ + / +
    bl dswap
    bl ud_slash_mod
    pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "d/"
@------------------------------------------------------------------------------
  push {lr}
  bl d_slash_mod
  bl dnip
  pop {pc}

@------------------------------------------------------------------------------
@ --- s31.32 calculations ---
@------------------------------------------------------------------------------


@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "f*"
f_star: @ Signed multiply s31.32
        @ ( fi fi -- fi )
        @ Overflow possible. Sign wrong in this case.
@------------------------------------------------------------------------------
  push {lr}
  movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
  beq 1f
  @ - * ?
    bl dnegate
    bl dswap
    movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq 2f @ - * +

    @ - * -
    bl dnegate

3:  @ + * +, - * -
    bl ud_star
    @ ( LL L H HH )
    drop
    ldmia psp!, {r0}
    str r0, [psp]
    @ ( L H )
    pop {pc}

1:@ + * ?
    bl dswap
    movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq 3b @ + * +  

    bl dnegate

    @ - * + or + * -
2:  bl ud_star
    @ ( LL L H HH )
    drop
    ldmia psp!, {r0}
    str r0, [psp]
    @ ( L H )
    bl dnegate
  pop {pc}

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "f/"
  @ Signed divide for s31.32. Overflow possible. Sign wrong in this case.
@------------------------------------------------------------------------------
  @ Take care of sign ! ( 1L 1H 2L 2H - EL EH )
  push {lr}
  movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
  beq 2f
  @ ? / -
    bl dnegate
    bl dswap
    movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
    beq 3f @ + / -

    @ - / -
    bl dnegate
1:  bl dswap @ - / - or + / +
    bl uf_slash_mod
    bl dnip
    pop {pc}

2:@ ? / +
  bl dswap
  movs r0, tos, asr #31 @ Turn MSB into 0xffffffff or 0x00000000
  beq 1b @ + / +

  @ - / +
  bl dnegate
3:bl dswap @ - / + or + / -
  bl uf_slash_mod
  bl dnegate
  bl dnip
  pop {pc}


@------------------------------------------------------------------------------
@ --- Double memory ---
@------------------------------------------------------------------------------

@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "2!" @ Store ( d addr -- )
@------------------------------------------------------------------------------
  ldmia psp!, {r1, r2}
  str r1, [tos]
  str r2, [tos, #4]
  drop
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_inline, "2@" @ Fetch ( addr -- d )
@------------------------------------------------------------------------------
  subs psp, #4
  ldr r0, [tos, #4]
  str r0, [psp]
  ldr tos, [tos]
  bx lr

@------------------------------------------------------------------------------
@ --- Double comparisions ---
@------------------------------------------------------------------------------

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "du<"
  @ ( 2L 2H 1L 1H -- Flag )
  @   8y 4x 0w tos
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}

  @ Check High:
  cmp tos, r1
  bhi 2f @ True
  bne 1f @ False - Not bigger, not equal --> Lower.
  @ Fall through if high part is equal

  @ Check Low:
  cmp r0, r2
  bhi 2f

@ False:
1:movs tos, #0
  bx lr

@ True
2:movs tos, #0
  mvns tos, tos
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "du>"
  @ ( 2L 2H 1L 1H -- Flag )
  @   8y 4x 0w tos
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}

  @ Check High:
  cmp r1, tos
  bhi 2f @ True
  bne 1f @ False - Not bigger, not equal --> Lower.
  @ Fall through if high part is equal

  @ Check Low:
  cmp r2, r0
  bhi 2f

@ False:
1:movs tos, #0
  bx lr

@ True
2:movs tos, #0
  mvns tos, tos
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "d<"
  @ ( 2L 2H 1L 1H -- Flag )
  @   8y 4x 0w tos
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}

  @ Check High:
  cmp tos, r1
  bgt 2f @ True
  bne 1f @ False - Not bigger, not equal --> Lower.
  @ Fall through if high part is equal

  @ Check Low:
  cmp r0, r2
  bgt 2f

@ False:
1:movs tos, #0
  bx lr

@ True
2:movs tos, #0
  mvns tos, tos
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_visible|Flag_foldable_4, "d>"
  @ ( 2L 2H 1L 1H -- Flag )
  @   8y 4x 0w tos
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}

  @ Check High:
  cmp r1, tos
  bgt 2f @ True
  bne 1f @ False - Not bigger, not equal --> Lower.
  @ Fall through if high part is equal

  @ Check Low:
  cmp r2, r0
  bgt 2f

@ False:
1:movs tos, #0
  bx lr

@ True
2:movs tos, #0
  mvns tos, tos
  bx lr


@------------------------------------------------------------------------------
  Wortbirne Flag_inline|Flag_foldable_2, "d0<" @ ( 1L 1H -- Flag ) Is double number negative ?
@------------------------------------------------------------------------------
  adds psp, #4
  movs TOS, TOS, asr #31    @ Turn MSB into 0xffffffff or 0x00000000
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_foldable_2|Flag_inline, "d0=" @ ( 1L 1H -- Flag )
@------------------------------------------------------------------------------
  ldm psp!, {r0}
  orrs tos, r0
  subs tos, #1
  sbcs tos, tos
  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_foldable_4, "d<>" @ ( 1L 1H 2L 2H -- Flag )
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}

  eors r0, r2
  eors tos, r1
  orrs tos, r0

  subs tos, #1
  sbcs tos, tos
  mvns tos, tos

  bx lr

@------------------------------------------------------------------------------
  Wortbirne Flag_foldable_4, "d=" @ ( 1L 1H 2L 2H -- Flag )
@------------------------------------------------------------------------------
  ldm psp!, {r0, r1, r2}

  eors r0, r2
  eors tos, r1
  orrs tos, r0

  subs tos, #1
  sbcs tos, tos

  bx lr

