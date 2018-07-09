\ =========================================================================
\  File: trig-sqrt.fs for Mecrisp-Stellaris by Matthias Koch
\
\  This file contains these functions for s31.32 fixed point numbers:
\ 
\           sqrt, sin, cos, tan, asin, acos, atan
\
\  All angles are in degrees.
\ 
\  Accuracy is good rounded to 7 significan digits or better, with some
\  exceptions.  In particular, the asin and acos functions have reduced
\  accuracy near the endpoints of the range of their inputs (+/-1) due
\  to their very large slopes there.  See the tests at the end of this
\  file.
\ 
\  The trig functions are based on a Maclaurin series for sin over the
\  first quadrant with 12 terms evaluated as a polynomial with the Horner
\  method.  This is extended to all angles using (anti)symmetry.  Cos is
\  calculated from sin with cos(x) = sin(x+90), and tan is calculated as
\  sin/cos.   
\ 
\  Atan is based on the first 7 terms of its Euler series over the
\  interval [0, 1/8].  It is extended to [0, 1] using the identity
\ 
\   atan(x) = atan(c) + atan((x-c)/(1+x*c)), c = 1/8, 2/8, ..., 7/8, 1.
\ 
\  For x>1 we use atan(x) = 90 - atan(1/x).  Negative arguments are handled
\  by antisymmetry.  Asin and acos are calculated using the formulas
\ 
\    asin(x) = atan(x / sqrt(1 - x^2)),  x^2 <= 1/2 
\ 
\    asin(x) = 90 - atan(sqrt(1 - x^2) / x),  x^2 > 1/2
\
\    acos(x) = 90 - asin(x) 
\
\  The square root is calculted bitwise with a standard algorithm over
\  the interval [0, 1] and is extended to all positive x by division by 4
\  until the quotient is in [0, 1].
\
\  Note:  Some s31.32 constant values were rounded from theoretical values
\         and entered below as (comma-part) integers rather calculating
\         them using Forth conversions, which trucate.
\
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.02.18
\ =========================================================================

compiletoflash

\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\ Round s31.32 value to (approximately) 9 decimal places and display it
: f.r9 ( df -- )  2 0 2over d0< if d- else d+ then 9 f.n ;  
    
\ Same as above, but for 7 decimal places
: f.r7 ( df -- )  215 0 2over d0< if d- else d+ then 7 f.n ; 

: tab ( -- )  9 emit ;

: d>= ( d1 d2 -- flag ) 2over 2over d> dup 2rot 2rot d= or swap drop ;

\ From common directory of Mecrisp-Stellaris Forth 2.4.0
: numbertable <builds does> swap 2 lshift + @ ;

\ -------------------------------------------------------------------------
\  Square root functions
\ -------------------------------------------------------------------------
: 0to1sqrt ( x -- sqrtx )
  \ Take square root of s31.32 number x with x in interval [0, 1]
  \ Special cases x = 0 and x = 1
  2dup d0= if exit then
  2dup 1,0 d= if exit then
  
  swap    \ Put x in MSW of unsigned 64-bit integer u
  
  \ Find square root of u as 64-bit unsigned int
  0,0 2swap 1,0 30 lshift  \ Stack: ( res  u  bit )
  \ Start value of bit is highest power of 4 <= u
  begin 2over 2over du< while dshr dshr repeat
  
  \ Do while bit not zero
  begin 2dup 0,0 d<> while
    2rot 2over 2over d+ 7 pick 7 pick du> not if  \ u >= res+bit ?
      2rot 2over d- 2rot 2dup 2-rot d-    \ u = u - res - bit
      2swap 2rot dshr 2over d+            \ res = (res >> 1) + bit
    else
      dshr    \ res = res >> 1
    then
    2-rot       \ Return stack to ( res u bit )
    dshr dshr   \ bit = bit >> 2
  repeat

  \ Drop u and bit, res is s31.32 square root of x
  2drop 2drop
;

: sqrt ( x -- sqrtx )
  \ Find square root of non-negative s31.32 number x
  \ If x in interval [0, 1], use 0to1sqrt
  2dup 1,0 d> not if
    0to1sqrt
  else
    \ Divide x by 4 until result is in interval [0, 1]
    0,0 2swap   \ Init count of divides ndiv (use double for convenience)
    begin 2dup 1,0 d> while
      2swap 1,0 d+ 2swap    \ Incr count
      dshr dshr             \ Divide by 4
    repeat 
    0to1sqrt
    2swap swap drop 0 do    \ ndiv consumed
      dshl                  \ Multiply by 2 ndiv times
    loop 
  then
;

\ -------------------------------------------------------------------------
\  Helpers and constants for trig functions
\ -------------------------------------------------------------------------
: deg2rad ( deg -- rad )
  \ Convert s31.32 in degress to s31.32 in radians
  74961321 0 f*
;

: rad2deg ( rad -- deg )
  \ Convert s31.32 in radians to s31.32 in degrees
  1270363336 57 f*
;

\ pi/2 as s31.32 number (whole part first so can retrieve with 2@)
create pi/2   1 , 2451551556 ,

\ s31.32 comma parts of coefficients in Horner expression of 12-term series
\ expansion of sine after an x is factored out.  The whole parts are 0 and
\ are supplied in code.
numbertable sin-coef
    8488078 ,   \  1/(22*23)
   10226113 ,   \  1/(20*21)
   12558384 ,   \  1/(18*19)
   15790321 ,   \  1/(16*17)
   20452225 ,   \  1/(14*15)
   27531842 ,   \  1/(12*13)
   39045157 ,   \  1/(10*11)
   59652324 ,   \  1/(8*9)
  102261126 ,   \  1/(6*7)
  214748365 ,   \  1/(4*5)
  715827883 ,   \  1/(2*3)

: q1-sin-rad  ( x -- sinx )
  \ Sin(x) for x in first quadrant Q1 and its negative 
  \ x is a s31.32 angle in radians between -pi/2 and pi/2, i.e., 
  \ (-2451551556 , -1) and (2451551556 , 1)
  2dup 2dup f*          \  x and x^2 on stack as dfs
  \ Calculate Horner terms
  -1,0   \ Starting Horner term is -1 (in 12-term expansion)
  11 0 do
    \ Multiply last term by x^2 and coefficient, then add +1 or -1 to get
    \ new term
    \ 2over f* sin-coef i 2 lshift + @ 0 f* 0 1
    2over f* i sin-coef 0 f* 0 1
    i 2 mod 0= if d+ else d- then
  loop
  \ Last term is multiplied by x
  2swap 2drop f*
  \ Apply max/min limits
  2dup 1,0 d> if 2drop 1,0 exit then
  2dup -1,0 d< if 2drop -1,0 exit then
;

: q1toq4-sin ( x -- sinx )
  \ Sin(x) for x in quadrants Q1 through Q4
  \ x is a s31.32 angle in degrees between 0 and 360
  2dup 270,0 d> if
    360,0 d- deg2rad q1-sin-rad
  else 2dup 90,0 d> if
    180,0 d- deg2rad q1-sin-rad dnegate
  else
    deg2rad q1-sin-rad
  then then
;

\ s31.32 comma parts of coefficients in Horner expression of 6-term Euler
\ expansion of atan after x/(x^2+1) is factored out.  The whole parts are
\ 0 and are supplied in code.  The series variable is y = (x^2)/(x^2+1).
numbertable atan-coef  
  3964585196 ,    \   12/13
  3904515724 ,    \   10/11
  3817748708 ,    \   8/9
  3681400539 ,    \   6/7
  3435973837 ,    \   4/5
  2863311531 ,    \   2/3

: base-ivl-atan ( x -- atanx )
  \ Calc atan for s32.31 x in base interval 0 to 1/8.
  2dup 2dup f* 2dup 1,0 d+     \ Stack: ( x  x^2  x^2+1 )
  2rot 2swap f/                \ Stack: ( x^2  x/(x^2+1) )
  2swap 2dup 1,0 d+ f/         \ Stack: ( x/(x^2+1)  (x^2)/(x^2+1) )
  \ Calc Horner terms for powers of y = (x^2)/(x^2+1)
  1,0   \ Starting Horner term is 1
  6 0 do
    \ Multiply last term by y and coefficient, then add 1 to get new term
    2over f* i atan-coef 0 f* 1,0 d+
  loop
  \ Last term is multiplied by x/(x^2+1)
  2swap 2drop f*
;

\ Table of atan(i/8), i = 0, 1, ..., 8, values in radians
\ Only comma parts given, all whole parts are 0. 
numbertable atan-table            
           0 ,
   534100635 ,
  1052175346 ,
  1540908296 ,
  1991351318 ,
  2399165791 ,
  2763816217 ,
  3087351340 ,
  3373259426 ,

: 0to1-atan ( x -- atanx )
  \ Calc atan for s31.32 x in interval [0, 1]
  2dup 1,0 d= if
    2drop
    8 atan-table 0
  else
    \ Find interval [i/8, (i+1)/8) containing x, then use formula
    \ atan(x) = atan(i/8) + atan((x - (i/8))/(1 + (x*i/8))) where
    \ the argument in the second term is in [0, 1/8].
    0 7 do
      0 i 8,0 f/ 2over 2over d>= if
        2over 2over d-
        2-rot f* 1,0 d+
        f/ base-ivl-atan
        i atan-table 0 d+
        leave
      else
        2drop
      then
    -1 +loop
  then
;

\ -------------------------------------------------------------------------
\  Trig functions
\ -------------------------------------------------------------------------
: sin ( x -- sinx )
  \ x is any s31.32 angle in degrees
  2dup 2dup d0< if dabs then
  \ Stack is ( x |x| )
  begin 2dup 360,0 d> while
    360,0 d-
  repeat
  q1toq4-sin    \ sin|x|
  \ Negate if x is negative
  2swap d0< if dnegate then
;

: cos ( x -- cosx )
  \ x is any s31.32 angle in degrees
  90,0 d+ sin
;

: tan ( x -- tanx )
  \ x is any s31.32 angle in degrees
  2dup sin 2swap cos f/
;

: atan ( x -- atanx )
  \ Calc atan for s31.32 x, return result in degrees
  2dup 2dup d0< if dabs then   \ Stack: ( x |x| ) 
  \ Find atan(|x|)
  2dup 1,0 d> if
    \ |x| > 1, use atan(|x|) = (pi/2) - atan(1/|x|) with 1/|x| in [0, 1]
    1,0 2swap f/ 0to1-atan pi/2 2@ 2swap d- 
  else
    \ |x| <= 1
    0to1-atan
  then
  \ Negate if x is negative
  2swap d0< if dnegate then
  rad2deg
;

: asin ( x -- asinx )
  \ Calc asin for s31.32 x in interval [-1, 1], return result in degrees
  2dup 2dup d0< if dabs then
  \ Stack is ( x |x| )
  2dup 1,0 d> if drop exit then     \ Exit if |x|>1 with x on stack
  2dup 2dup f* 1,0 2swap d- 0to1sqrt    \ Stack: ( x  |x|  sqrt(1-x^2) )
  2over 2dup f* 0,5 d> if           \ x^2 > (1/2) ?
    2swap f/ atan 90,0 2swap d-
  else
    f/ atan
  then
  \ Negate if x is negative
  2swap d0< if dnegate then
;

: acos ( x -- acosx )
  \ Calc acos for s31.32 x in interval [-1, 1], return result in degrees
  90,0 2swap asin d-
;

\ -------------------------------------------------------------------------
\  Tests
\ -------------------------------------------------------------------------
: sqrt-test1
  cr cr ." x" tab tab ." sqrt(x)^2"
  cr 0 0 2dup f.r7 sqrt 2dup f* tab f.r7
  32 1 do
    cr 0,03125 0 i f* 2dup f.r7 sqrt 2dup f* tab f.r7
  loop
  cr 0 1 2dup f.r7 sqrt 2dup f* tab f.r7
  51 1 do
    cr 2,0 0 i f* 2dup f.r7 sqrt 2dup f* tab f.r7
  loop
  cr 
;

: sqrt-test2
  cr cr ." x" tab tab ." sqrt(x^2)"
  cr 0 0 2dup f.r7 2dup f* sqrt tab f.r7
  32 1 do
    cr 0,03125 0 i f* 2dup f.r7 2dup f* sqrt tab f.r7
  loop
  cr 0 1 2dup f.r7 2dup f* sqrt tab f.r7
  51 1 do
    cr 2,0 0 i f* 2dup f.r7 2dup f* sqrt tab f.r7
  loop
  cr 
;

: trig-test1
  cr cr ." x" tab ." sin^2 x + cos^2 x"
  91 0 do
    0 i sin 2dup f*
    0 i cos 2dup f* d+
    i cr . tab f.r7
  loop
  cr
;

: trig-test2
  cr cr ." x" tab tab ." atan(tan(x))"
  -89,999999 2dup tan atan cr f.r7 tab f.r7   
  -89,9 2dup tan atan cr f.r7 tab f.r7   
  90 -89 do
    0 i tan atan
    i cr . tab tab f.r7
  loop
  89,9 2dup tan atan cr f.r7 tab f.r7   
  89,999999 2dup tan atan cr f.r7 tab f.r7   
  cr
;

: trig-test3
  cr cr ." x" tab ." asin(sin(x))"
  91 -90 do
    0 i sin asin
    i cr . tab f.r7
  2 +loop
  cr
;

: trig-test4
  cr cr ." x" tab tab ." sin(asin(x))"
  cr 0,0 2dup f.r7 asin sin tab f.r7
  32 1 do
    cr 0,03125 0 i f* 2dup f.r7 asin sin tab f.r7
  loop
  cr 1,0 2dup f.r7 asin sin tab f.r7
  cr
;

: trig-test5
  cr cr ." x" tab ." acos(cos(x))"
  181 0 do
    0 i cos acos
    i cr . tab f.r7
  2 +loop
  cr
;

: trig-test6
  cr cr ." x" tab tab ." cos(acos(x))"
  cr 0,0 2dup f.r7 acos cos tab f.r7
  32 1 do
    cr 0,03125 0 i f* 2dup f.r7 acos cos tab f.r7
  loop
  cr 1,0 2dup f.r7 acos cos tab f.r7
  cr
;

\ -------------------------------------------------------------------------
compiletoram
