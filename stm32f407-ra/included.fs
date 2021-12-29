
: (* ( -- ) \ Long comment

begin
  token  \ Get next token
  dup 0= if 2drop cr query token then  \ If length of token is zero, end of line is reached. Fetch new line. Fetch new token.
  s" *)" compare  \ Search for *)
until

immediate 0-foldable ; 
\ -----------------------------------------------------------------------------
\   Conditional compilation
\ -----------------------------------------------------------------------------
\ ."  ok." added to nexttoken (for e4thcom compatibility) MM-201227

\ Idea similar to http://lars.nocrew.org/dpans/dpansa15.htm#A.15.6.2.2532

: nexttoken ( -- addr len )
  begin
    token          \ Fetch new token.
  dup 0= while      \ If length of token is zero, end of line is reached.
\   2drop cr query   \ Fetch new line.
    2drop ."  ok." cr query  \ Tell the terminal or user to send a next line.
  repeat
;

: [else] ( -- )
  1 \ Initial level of nesting
  begin
    nexttoken ( level addr len )

    2dup s" [if]"     compare
 >r 2dup s" [ifdef]"  compare r> or
 >r 2dup s" [ifndef]" compare r> or

    if
      2drop 1+  \ One more level of nesting
    else
      2dup s" [else]" compare
      if
        2drop 1- dup if 1+ then  \ Finished if [else] is reached in level 1. Skip [else] branch otherwise.
      else
        s" [then]" compare if 1- then  \ Level completed.
      then
    then

    ?dup 0=
  until

  immediate 0-foldable
;

: [then] ( -- ) immediate 0-foldable ;

: [if]   ( ? -- )                 0=  if postpone [else] then immediate 1-foldable ;
: [ifdef]  ( -- ) token find drop 0=  if postpone [else] then immediate 0-foldable ;
: [ifndef] ( -- ) token find drop 0<> if postpone [else] then immediate 0-foldable ;


\ A convenient memory dump helper

: u.4 ( u -- ) 0 <# # # # # #> type ;
: u.2 ( u -- ) 0 <# # # #> type ;

: dump16 ( addr -- ) \ Print 16 bytes memory
  base @ >r hex
  $F bic
  dup hex. ." :  "

  dup 16 + over do
    i c@ u.2 space \ Print data with 2 digits
    i $F and 7 = if 2 spaces then
  loop

  ."  | "

  dup 16 + swap do
        i c@ 32 u>= i c@ 127 u< and if i c@ emit else [char] . emit then
        i $F and 7 = if 2 spaces then
      loop

  ."  |" cr
  r> base !
;

: dump ( addr len -- ) \ Print a memory region
  cr
  over 15 and if 16 + then \ One more line if not aligned on 16
  begin
    swap ( len addr )
    dup dump16
    16 + ( len addr+16 )
    swap 16 - ( addr+16 len-16 )
    dup 0<
  until
  2drop
;
\ =========================================================================
\  File: fixpt-math-lib.fs for Mecrisp-Stellaris by Matthias Koch
\
\  This file contains these functions for s31.32 fixed point numbers:
\
\           sqrt, sin, cos, tan, asin, acos, atan
\           log2, log10, ln, pow2, pow10, exp
\
\ ------------- Comments on sqrt and trig functions -----------------------
\
\  All angles are in degrees.
\
\  Accuracy is good rounded to 7 significant digits, with some exceptions.
\  In particular, the asin and acos functions have reduced accuracy
\  near the endpoints of the range of their inputs (+/-1) due to their
\  very large slopes there.  See the tests in fixpt-mat-lib-tests.fs.
\
\  The sin function is based on Maclaurin series for sin and cos over
\  the interval [0, pi/4], evaluated as polynomials with the Horner
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
\  The square root is calculated bitwise with a standard algorithm over
\  the interval [0, 1] and is extended to all positive x by division by 4
\  until the quotient is in [0, 1].
\
\ ------------- Comments on the log and power functions -------------------
\
\  The user can check for accuracy by running the test functions in the
\  file fixpt-math-lib-tests.fs, or by running tests tailored to their use.
\  Generally the functions are accurate when rounded to about 7 significant
\  digits.  However, the user should not expect good accuracy when dealing
\  with very small fractional values due to the limitations of fixed
\  point.  In particular, this affects the values of the power and
\  exponential functions for larger negative inputs, when the relative
\  accuracy decreases significantly.
\
\  If the argument to a log function is non-positive, the function returns
\  "minus infinity," the largest negative s31.32 value.  This is the only
\  signal that an invalid input has been used.  Large negative inputs
\  to the power and exponential functions will return zero.  Large positive
\  inputs will return "plus infinity," the largest positive s31.32 value.
\  The code shows the specific values used to determine "large" in each
\  case.
\
\  The algorithm for calculating the base 2 log is taken from pseudocode
\  in the Wikipedia article "Binary logarithm" which is based on:
\
\     Majithia, J. C.; Levan, D. (1973), "A note on base-2 logarithm
\     computations", Proceedings of the IEEE, 61 (10): 1519–1520,
\     doi:10.1109/PROC.1973.9318
\
\  The log10(x) and natural logarithm ln(x) make use of the identities
\
\     log10(x) = log10(2)*log2(x), ln(x) = ln(2)*log2(x)
\
\  where log10(2) and ln(2) are given constants.
\
\  The pow2(x) = 2^x function is calculated as 2^x = (2^z)*(2^n) where
\  x = z + n, n is an integer with n <= x < n+1, and 0 <= z < 1.  The
\  factor 2^z is calculated by the identity 2^z = exp(ln(2)*z) where
\  exp(y) is calculated using its Maclaurin series.  The other factor
\  is accounted for by shifting 2^z n times (shift left for n > 0, shift
\  right for n < 0).
\
\  The pow10(x) = 10^x function is calculated using the identity
\
\               10^x = 2^(x*ln(10)/ln(2))
\
\  except for positive integer values of x, where simple multiplication
\  is used.
\
\  The exp(y) function is calculated using the series above if y is
\  between -0.36 and +0.36.  Otherwise it is calculated from pow2 using the
\  identity exp(y) = pow2(y/ln(2)).
\
\ -------------------------------------------------------------------------
\  Note:  Some s31.32 constant values were rounded from theoretical values
\         and entered below as (comma-part) integers rather calculating
\         them using Forth conversions, which trucate.
\
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.04.09
\ =========================================================================


\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\ Most positive and negative s31.32 values possible
$FFFFFFFF $7FFFFFFF 2constant +inf  \ 2147483647,9999999999
$0 $80000000 2constant -inf         \ 2147483648,0

\ Return the floor of an s31.32 value df
: floor ( df -- df ) nip 0 swap 2-foldable ;

\ Convert an s31.32 angle df1 in degrees to an angle df2 in [0, 360)
\ such that df1 = df2 + n*360 where n is an integer
: deg0to360 ( df1 -- df2 )  360,0 d/mod 2drop 2dup d0< if 360,0 d+ then
  2-foldable
;

\ Convert an s31.32 angle df1 in degrees to an angle df2 in [-90, 90)
\ such that df1 = df2 + n*180 where n is an integer.  (For tan only.)
: deg-90to90 ( df1 -- df2 )
  180,0 d/mod 2drop
  2dup 90,0 d< not if
    180,0 d-
  else
    2dup -90,0 d< if
      180,0 d+
    then
  then
  2-foldable
;

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
      2rot 2over d- 2rot 2tuck d-    \ u = u - res - bit
      2swap 2rot dshr 2over d+            \ res = (res >> 1) + bit
    else
      dshr    \ res = res >> 1
    then
    2-rot       \ Return stack to ( res u bit )
    dshr dshr   \ bit = bit >> 2
  repeat

  \ Drop u and bit, res is s31.32 square root of x
  2drop 2drop
  2-foldable
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
    2swap nip 0 do    \ ndiv consumed
      dshl                  \ Multiply by 2 ndiv times
    loop
  then
  2-foldable
;

\ -------------------------------------------------------------------------
\  Helpers and constants for trig functions
\ -------------------------------------------------------------------------
: deg2rad ( deg -- rad )
  \ Convert s31.32 in degress to s31.32 in radians
  74961321 0 f*
  2-foldable
;

: rad2deg ( rad -- deg )
  \ Convert s31.32 in radians to s31.32 in degrees
  1270363336 57 f*
  2-foldable
;

\ pi/2 and pi/4 as s31.32 numbers (whole part first for retrieval with 2@)
2451551556 1 2constant pi/2
3373259426 0 2constant pi/4

\ s31.32 comma parts of coefficients in Horner expression of 7-term series
\ expansion of sine after an x is factored out.  The whole parts are 0 and
\ are supplied in code.
numbertable sin-coef
   20452225 ,   \  1/(14*15)
   27531842 ,   \  1/(12*13)
   39045157 ,   \  1/(10*11)
   59652324 ,   \  1/(8*9)
  102261126 ,   \  1/(6*7)
  214748365 ,   \  1/(4*5)
  715827883 ,   \  1/(2*3)

: half-q1-sin-rad  ( x -- sinx )
  \ Sin(x) for x in first half of first quadrant Q1 and its negative
  \ x is a s31.32 angle in radians between -pi/4 and pi/4
  2dup 2dup f*          \  x and x^2 on stack as dfs
  \ Calculate Horner terms
  -1,0   \ Starting Horner term is -1
  7 0 do
    \ Multiply last term by x^2 and coefficient, then add +1 or -1 to get
    \ new term
    2over f* i sin-coef 0 f* 0 1
    i 2 mod 0= if d+ else d- then
  loop
  \ Last term is multiplied by x
  2nip f*
  2-foldable
;

\ s31.32 comma parts of coefficients in Horner expression of 8-term series
\ expansion of cosine.  The whole parts are 0 and are supplied in code.
numbertable cos-coef
   17895697 ,   \  1/(15*16)
   23598721 ,   \  1/(13*14)
   32537631 ,   \  1/(11*12)
   47721859 ,   \  1/(9*10)
   76695845 ,   \  1/(7*8)
  143165577 ,   \  1/(5*6)
  357913941 ,   \  1/(3*4)
 2147483648 ,   \  1/2

: half-q1-cos-rad  ( x -- cosx )
  \ Cos(x) for x in first half of first quadrant Q1 and its negative
  \ x is a s31.32 angle in radians between -pi/4 and pi/4
  2dup f*          \  x^2 on stack
  \ Calculate Horner terms
  1,0   \ Starting Horner term is 1
  8 0 do
    \ Multiply last term by x^2 and coefficient, then add +1 or -1 to get
    \ new term
    2over f* i cos-coef 0 f* 0 1
    i 2 mod 0= if d- else d+ then
  loop
  2nip
  2-foldable
;

: q1-sin-rad ( x -- sinx )
  \ Sin(x) for x in first quadrant Q1 and its negative
  \ x is a s31.32 angle in radians between -pi/2 and pi/2
  2dup pi/4 d< if
    half-q1-sin-rad
  else
    pi/2 2swap d- half-q1-cos-rad
  then
  \ Apply max/min limits
  \ 2dup 1,0 d> if 2drop 1,0 exit then
  \ 2dup -1,0 d< if 2drop -1,0 exit then
  2-foldable
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
  2-foldable
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
  2nip f*
  2-foldable
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
      0 i 8,0 f/ 2over 2over d< not if
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
  2-foldable
;

\ -------------------------------------------------------------------------
\  Trig functions
\ -------------------------------------------------------------------------
: sin ( x -- sinx )
  \ x is any s31.32 angle in degrees
  2dup 2dup d0< if dabs then
  \ Stack is ( x |x| )
  360,0 ud/mod 2drop
  q1toq4-sin    \ sin|x|
  \ Negate if x is negative
  2swap d0< if dnegate then
  2-foldable
;

: cos ( x -- cosx )
  \ x is any s31.32 angle in degrees
  90,0 d+ sin
  2-foldable
;

: tan ( x -- tanx )
  \ x is any s31.32 angle in degrees
  \ Move x to equivalent value in [-90, 90)
  deg-90to90
  \ If |x| > 89,9 deg, use approximation sgn(x)(180/pi)/(90-|x|)
  2dup dabs 2dup 89,8 d> if
    90,0 2swap d- 608135817 3 f* 180,0 2swap f/
    2swap d0< if dnegate then
  else
    2drop 2dup sin 2swap cos f/
  then
  2-foldable
;

: atan ( x -- atanx )
  \ Calc atan for s31.32 x, return result in degrees
  2dup 2dup d0< if dabs then   \ Stack: ( x |x| )
  \ Find atan(|x|)
  2dup 1,0 d> if
    \ |x| > 1, use atan(|x|) = (pi/2) - atan(1/|x|) with 1/|x| in [0, 1]
    1,0 2swap f/ 0to1-atan pi/2 2swap d-
  else
    \ |x| <= 1
    0to1-atan
  then
  \ Negate if x is negative
  2swap d0< if dnegate then
  rad2deg
  2-foldable
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
  2-foldable
;

: acos ( x -- acosx )
  \ Calc acos for s31.32 x in interval [-1, 1], return result in degrees
  90,0 2swap asin d-
  2-foldable
;

\ -------------------------------------------------------------------------
\  Helper for logarithmic functions
\ -------------------------------------------------------------------------
: log2-1to2 ( y -- log2y )
  \ Helper function that requires y is s31.32 value with 1 <= y < 2
  0 0 2swap 0
  ( retval y cum_m )
  \ while((cum_m < 33) && (y > 1))
  begin dup 2over
    ( retval y cum_m cum_m y )
    1,0 d> swap 33 < and while
    ( retval y cum_m )
    rot rot 0 -rot        \ m = 0, z = y
    ( retval cum_m m z)
    \ Do z = z*z, m = m+1 until 2 <= z.  We also get z < 4
    begin
      2dup f* rot 1 + -rot
      ( retval cum_m m z )
      2dup 2,0 d< not
    until
    \ At this point z = y^(2^m) so that log2(y) = (2^(-m))*log2(z)
    \ = (2^(-m))*(1 + log2(z/2)) and 1 <= z/2 < 2
    \ We will add m to cum_m and add 2*(-cum_m) to the returned value,
    \ then iterate with a new y = z/2
    ( retval cum_m m z )
    2swap + -rot dshr 2>r   \ cum_m = cum_m + m, y = z/2
    ( retval cum_m ) ( R: y=z/2 )
    \ retval = retval + 2^-cum_m
    1,0 2 pick 0 do dshr loop
    ( retval cum_m 2^-cum_m )
    rot >r d+
    ( retval ) ( R: y cum_m )
    r> 2r> rot
    ( retval y cum_m )
  repeat
  drop 2drop
  2-foldable
;

\ -------------------------------------------------------------------------
\  Logarithmic functions
\ -------------------------------------------------------------------------
: log2 ( x -- log2x )
  \ Calculates base 2 logarithm of positive s31.32 value x

  \ Treat error and special cases
  \ Check that x > 0.  If not, return "minus infinity"
  2dup 0,0 d> not if 2drop -inf exit then
  \ If x = 1, return 0
  2dup 1,0 d= if 2drop 0,0 exit then

  \ Find the n such that 1 <= (2^(-n))*x < 2
  \ This n is the integer part (characteristic) of log2(x)
  0 -rot
  ( n=0 y=x )
  2dup 1,0 d> if
    \ Do n = n+1, y = y/2 while (y >= 2)
    begin 2dup 2,0 d< not while
      ( n y )
      dshr rot 1 + -rot
    repeat
  else
    \ Do n = n-1, y = 2*y while (y < 1)
    begin 2dup 1,0 d< while
      ( n y )
      dshl rot 1 - -rot
    repeat
  then

  \ Now y = (2^(-n))*x so log2(x) = n + log2(y) and we use the
  \ helper function to get log2(y) since 1 <= y < 2
  log2-1to2 rot 0 swap d+
  ( log2x )
  2-foldable
;

1292913986 0 2constant log10of2

: log10 ( x -- log10x )
  \ Calculates base 10 logarithm of positive s31.32 value x

  \ Treat error and special cases
  \ Check that x > 0.  If not, return "minus infinity"
  2dup 0,0 d> not if 2drop -inf exit then
  \ If x = 1, return 0
  2dup 1,0 d= if 2drop 0,0 exit then

  \ Find the n such that 1 <= (10^(-n))*x < 10
  \ This n is the integer part (characteristic) of log2(x)
  0 -rot
  ( n=0 y=x )
  2dup 1,0 d> if
    \ Do n = n+1, y = y/10 while (y >= 10)
    begin 2dup 10,0 d< not while
      ( n y )
      10,0 f/ rot 1 + -rot
    repeat
  else
    \ Do n = n-1, y = 10*y while (y < 1)
    begin 2dup 1,0 d<  while
      ( n y )
      10,0 f* rot 1 - -rot
    repeat
  then

  \ Now y = (10^(-n))*x so log10(x) = n + log10(y) and we use the
  \ identity log10(y) = log10(2)*log2(y)
  log2 log10of2 f* rot 0 swap d+
  ( log10x )
  2-foldable
;

2977044472 0 2constant lnof2

: ln ( x -- lnx )
  \ Return the natural logarithm of a postive s31.32 value x

  \ Treat error and special cases
  \ Check that x > 0.  If not, return "minus infinity"
  2dup 0,0 d> not if 2drop -inf exit then
  \ If x = 1, return 0
  2dup 1,0 d= if 2drop 0,0 exit then

  log2 lnof2 f*
  2-foldable
;

\ -------------------------------------------------------------------------
\  Power functions
\ -------------------------------------------------------------------------
\ s31.32 comma parts of all but first coefficient in Horner expansion of
\ a partial sum of the series expansion of exp(x).  The whole parts are 0
\ and are supplied in code.
numbertable exp-coef
   390451572 ,   \  1/11
   429496730 ,   \  1/10
   477218588 ,   \  1/9
   536870912 ,   \  1/8
   615366757 ,   \  1/7
   715827883 ,   \  1/6
   858993459 ,   \  1/5
  1073741824 ,   \  1/4
  1431655765 ,   \  1/3
  2147483648 ,   \  1/2

: exp-1to1 ( x -- expx )
  \ Calculate exp(x) for x an s31.32 value.  Values are correct when
  \ when rounded to six decimal places when x is between +/-0.7.  Uses an
  \ 11-term partial sum evaluated using Horner's method.
  \ Calculate Horner terms
  1,0   \ Starting Horner term is 1
  10 0 do
    \ Multiply last term by x and coefficient, then add to get new term
    2over f* i exp-coef 0 f* 0 1 d+
  loop
  \ Last part of expansion
  2over f* 0 1 d+
  2nip
  2-foldable
;

: pow2 ( x -- 2^x )
  \ Return 2 raised to the power x where x is s31.32
  \ If x is 0, return 1
  2dup 0,0 d= if 2drop 1,0 exit then
  \ If x < -32, 0 is returned.  If x >= 31, returns s31.32 ceiling
  2dup -32,0 d< if 2drop 0,0 exit then
  2dup 31,0 d< not if 2drop +inf exit then
  \ Get largest integer n such that n <= x so x = z + n, 0 <= z < 1
  2dup floor 2swap 2over d-
  ( n z )
  \ Get exp(z*ln2) = 2^z, then shift n times to get 2^x = (2^n)*(2^z)
  lnof2 f* exp-1to1 2swap nip
  ( 2^z n )  \ n now a single
  dup 0= if
    drop
  else
    dup 0< if
      negate 0 do dshr loop
    else
      0 do dshl loop
    then
  then
  2-foldable
;

1901360723 1 2constant 1overlnof2

: exp ( x -- expx )
  \ Return the exponential e^x of the s31.32 value x
  \ If x is 0, return 1
  2dup 0,0 d= if 2drop 1,0 exit then
  \ Return s31.32 ceiling for large pos. exponents, 0 for large neg.
  2dup 21,5 d> if 2drop +inf exit then
  2dup -22,2 d< if 2drop 0,0 exit then
  \ If |x| < 0.36, use exponential series approximation
  \ Otherwise, use exp(x) = pow2(x/ln(2))
  2dup dabs 0,36 d< if
    exp-1to1
  else
    1overlnof2 f* pow2
  then
  2-foldable
;

1382670639 3 2constant ln10overln2

: pow10 ( x -- 10^x )
  \ Return 10 raised to the power x where x is s31.32
  \ If x is 0, return 1
  2dup 0,0 d= if 2drop 1,0 exit then
  \ Return s31.32 ceiling for large pos. exponents, 0 for large neg.
  2dup 9,35 d> if 2drop +inf exit then
  2dup -9,64 d< if 2drop 0,0 exit then
  \ If x is a positive integer generate powers of 10 with multiplications
  \ Otherwise use 10^x = 2^(x*ln(10)/ln(2))
  2dup 2dup floor d= if
    2dup 0,0 d> if
      1,0 2swap nip
      0 do 10,0 f* loop
    else
      ln10overln2 f* pow2
    then
  else
    ln10overln2 f* pow2
  then
  2-foldable
;

\ -------------------------------------------------------------------------

: s>f ( n -- f ) 0 swap  1-foldable ; \ Signed integer --> Fixpoint s31.32
: f>s ( f -- n ) nip     2-foldable ; \ Fixpoint s31.32 --> Signed integer

\ Partial ARM Cortex M3/M4 Disassembler, Copyright (C) 2013  Matthias Koch
\ This is free software under GNU General Public License v3.
\ Knows all M0 and some M3/M4 machine instructions,
\ resolves call entry points, literal pools and handles inline strings.
\ Usage: Specify your target address in disasm-$ and give disasm-step some calls.

\ ------------------------
\  A quick list of words
\ ------------------------

: list ( -- )
  cr
  dictionarystart
  begin
    dup 6 + ctype space
    dictionarynext
  until
  drop
;

\ ---------------------------------------
\  Memory pointer and instruction fetch
\ ---------------------------------------

0 variable disasm-$   \ Current position for disassembling

: disasm-fetch        \ ( -- Data ) Fetches opcodes and operands, increments disasm-$
    disasm-$ @ h@     \             Holt Opcode oder Operand, incrementiert disasm-$
  2 disasm-$ +!   ;

\ --------------------------------------------------
\  Try to find address as code start in Dictionary
\ --------------------------------------------------

: disasm-string ( -- ) \ Takes care of an inline string
  disasm-$ @ dup ctype skipstring disasm-$ !
;

: name. ( Address -- ) \ If the address is Code-Start of a dictionary word, it gets named.
  1 bic \ Thumb has LSB of address set.

  >r
  dictionarystart
  begin
    dup   6 + dup skipstring r@ = if ."   --> " ctype else drop then
    dictionarynext
  until
  drop
  r>

  case \ Check for inline strings ! They are introduced by calls to ." or s" internals.
    ['] ." $1E + of ."   -->  .' " disasm-string ." '" endof \ It is ." runtime ?
    ['] s"  $4 + of ."   -->  s' " disasm-string ." '" endof \ It is .s runtime ?
    ['] c"  $4 + of ."   -->  c' " disasm-string ." '" endof \ It is .c runtime ?
  endcase
;

\ -------------------
\  Beautiful output
\ -------------------

: u.4  0 <# # # # # #> type ;
: u.8  0 <# # # # # # # # # #> type ;
: u.ns 0 <# #s #> type ;
: const. ."  #" u.ns ;
: addr. u.8 ;

: register. ( u -- )
  case
    13 of ."  sp" endof
    14 of ."  lr" endof
    15 of ."  pc" endof
    dup ."  r" decimal u.ns hex
  endcase ;

\ ----------------------------------------
\  Disassembler logic and opcode cutters
\ ----------------------------------------

: opcode? ( Opcode Bits Mask -- Opcode ? ) \ (Opcode and Mask) = Bits
  rot ( Bits Mask Opcode )
  tuck ( Bits Opcode Mask Opcode )
  and ( Bits Opcode Opcode* )
  rot ( Opcode Opcode* Bits )
  =
;

: reg.    ( Opcode Position -- Opcode ) over swap rshift  $7 and register. ;
: reg16.  ( Opcode Position -- Opcode ) over swap rshift  $F and register. ;
: reg16split. ( Opcode -- Opcode ) dup $0007 and over 4 rshift $0008 and or register. ;
: registerlist. ( Opcode -- Opcode ) 8 0 do dup 1 i lshift and if i register. space then loop ;

: imm3. ( Opcode Position -- Opcode ) over swap rshift  $7  and const. ;
: imm5. ( Opcode Position -- Opcode ) over swap rshift  $1F and const. ;
: imm8. ( Opcode Position -- Opcode ) over swap rshift  $FF and const. ;

: imm3<<1. ( Opcode Position -- Opcode ) over swap rshift  $7  and shl const. ;
: imm5<<1. ( Opcode Position -- Opcode ) over swap rshift  $1F and shl const. ;
: imm8<<1. ( Opcode Position -- Opcode ) over swap rshift  $FF and shl const. ;

: imm3<<2. ( Opcode Position -- Opcode ) over swap rshift  $7  and shl shl const. ;
: imm5<<2. ( Opcode Position -- Opcode ) over swap rshift  $1F and shl shl const. ;
: imm7<<2. ( Opcode Position -- Opcode ) over swap rshift  $7F and shl shl const. ;
: imm8<<2. ( Opcode Position -- Opcode ) over swap rshift  $FF and shl shl const. ;

: condition. ( Condition -- )
  case
    $0 of ." eq" endof  \ Z set
    $1 of ." ne" endof  \ Z clear
    $2 of ." cs" endof  \ C set
    $3 of ." cc" endof  \ C clear

    $4 of ." mi" endof  \ N set
    $5 of ." pl" endof  \ N clear
    $6 of ." vs" endof  \ V set
    $7 of ." vc" endof  \ V clear

    $8 of ." hi" endof  \ C set Z clear
    $9 of ." ls" endof  \ C clear or Z set
    $A of ." ge" endof  \ N == V
    $B of ." lt" endof  \ N != V

    $C of ." gt" endof  \ Z==0 and N == V
    $D of ." le" endof  \ Z==1 or N != V
  endcase
;

: imm12. ( Opcode -- Opcode )
  dup $FF and                 \ Bits 0-7
  over  4 rshift $700 and or  \ Bits 8-10
  over 15 rshift $800 and or  \ Bit  11
  ( Opcode imm12 )
  dup 8 rshift
  case
    0 of $FF and                                  const. endof \ Plain 8 Bit Constant
    1 of $FF and                 dup 16 lshift or const. endof \ 0x00XY00XY
    2 of $FF and        8 lshift dup 16 lshift or const. endof \ 0xXY00XY00
    3 of $FF and dup 8 lshift or dup 16 lshift or const. endof \ 0xXYXYXYXY

    \ Shifted 8-Bit Constant
    swap
      \ Otherwise, the 32-bit constant is rotated left until the most significant bit is bit[7]. The size of the left
      \ rotation is encoded in bits[11:7], overwriting bit[7]. imm12 is bits[11:0] of the result.
      dup 7 rshift swap $7F and $80 or swap rrotate const.
  endcase
;

\ --------------------------------------
\  Name resolving for blx r0 sequences
\ --------------------------------------

0 variable destination-r0

\ ----------------------------------
\  Single instruction disassembler
\ ----------------------------------

: disasm-thumb-2 ( Opcode16 -- Opcode16 )
  dup 16 lshift disasm-fetch or ( Opcode16 Opcode32 )

  $F000D000 $F800D000 opcode? if  \ BL
                                ( Opcode )
                                ." bl  "
                                dup $7FF and ( Opcode DestinationL )
                                over ( Opcode DestinationL Opcode )
                                16 rshift $7FF and ( Opcode DestinationL DestinationH )
                                dup $400 and if $FFFFF800 or then ( Opcode DestinationL DestinationHsigned )
                                11 lshift or ( Opcode Destination )
                                shl
                                disasm-$ @ +
                                dup addr. name. \ Try to resolve destination
                              then

  \ MOVW / MOVT
  \ 1111 0x10 t100 xxxx 0xxx dddd xxxx xxxx
  \ F    2    4    0    0    0    0    0
  \ F    B    7    0    8    0    0    0

  $F2400000 $FB708000 opcode? if \ MOVW / MOVT
                                ( Opcode )
                                dup $00800000 and if ." movt"
                                                  else ." movw"
                                                  then

                                8 reg16. \ Destination register

                                \ Extract 16 Bit constant from opcode:
                                dup        $FF and              ( Opcode Constant* )
                                over     $7000 and  4 rshift or ( Opcode Constant** )
                                over $04000000 and 15 rshift or ( Opcode Constant*** )
                                over $000F0000 and  4 rshift or ( Opcode Constant )
                                dup ."  #" u.4
                                ( Opcode Constant )
                                over $00800000 and if 16 lshift destination-r0 @ or destination-r0 !
                                                   else                             destination-r0 !
                                                   then
                              then

  \
  \ 1111 0i0x xxxs nnnn 0iii dddd iiii iiii
  \ F    0    0    0    0    0    0    0
  \ F    A    0    0    8    0    0    0

  $F0000000 $FA008000 opcode? not if else \ Data processing, modified 12-bit immediate
                                dup 21 rshift $F and
                                case
                                  %0000 of ." and" endof
                                  %0001 of ." bic" endof
                                  %0010 of ." orr" endof
                                  %0011 of ." orn" endof
                                  %0100 of ." eor" endof
                                  %1000 of ." add" endof
                                  %1010 of ." adc" endof
                                  %1011 of ." sbc" endof
                                  %1101 of ." sub" endof
                                  %1110 of ." rsb" endof
                                  ." ?"
                                endcase
                                dup 1 20 lshift and if ." s" then \ Set Flags ?
                                8 reg16. 16 reg16. \ Destionation and Source registers
                                imm12.
                              then

  case \ Decode remaining "singular" opcodes used in Mecrisp-Stellaris:

    $F8470D04 of ." str r0 [ r7 #-4 ]!" endof
    $F8471D04 of ." str r1 [ r7 #-4 ]!" endof
    $F8472D04 of ." str r2 [ r7 #-4 ]!" endof
    $F8473D04 of ." str r3 [ r7 #-4 ]!" endof
    $F8476D04 of ." str r6 [ r7 #-4 ]!" endof

    $F8576026 of ." ldr r6 [ r7 r6 lsl #2 ]" endof
    $F85D6C08 of ." ldr r6 [ sp #-8 ]" endof

    $FAB6F686 of ." clz r6 r6" endof

    $FB90F6F6 of ." sdiv r6 r0 r6" endof
    $FBB0F6F6 of ." udiv r6 r0 r6" endof
    $FBA00606 of ." umull r0 r6 r0 r6" endof
    $FBA00806 of ." smull r0 r6 r0 r6" endof

  endcase \ Case drops Opcode32
  ( Opcode16 )
;

: disasm ( -- ) \ Disassembles one machine instruction and advances disasm-$

disasm-fetch \ Instruction opcode on stack the whole time.

$4140 $FFC0 opcode? if ." adcs"  0 reg. 3 reg. then          \ ADC
$1C00 $FE00 opcode? if ." adds" 0 reg. 3 reg. 6 imm3. then   \ ADD(1) small immediate two registers
$3000 $F800 opcode? if ." adds" 8 reg. 0 imm8. then          \ ADD(2) big immediate one register
$1800 $FE00 opcode? if ." adds" 0 reg. 3 reg. 6 reg. then    \ ADD(3) three registers
$4400 $FF00 opcode? if ." add"  reg16split. 3 reg16. then    \ ADD(4) two registers one or both high no flags
$A000 $F800 opcode? if ." add"  8 reg. ."  pc " 0 imm8<<2. then  \ ADD(5) rd = pc plus immediate
$A800 $F800 opcode? if ." add"  8 reg. ."  sp " 0 imm8<<2. then  \ ADD(6) rd = sp plus immediate
$B000 $FF80 opcode? if ." add sp" 0 imm7<<2. then            \ ADD(7) sp plus immediate

$4000 $FFC0 opcode? if ." ands" 0 reg. 3 reg. then           \ AND
$1000 $F800 opcode? if ." asrs" 0 reg. 3 reg. 6 imm5. then   \ ASR(1) two register immediate
$4100 $FFC0 opcode? if ." asrs" 0 reg. 3 reg. then           \ ASR(2) two register
$D000 $F000 opcode? not if else dup $0F00 and 8 rshift       \ B(1) conditional branch
                       case
                         $00 of ." beq" endof  \ Z set
                         $01 of ." bne" endof  \ Z clear
                         $02 of ." bcs" endof  \ C set
                         $03 of ." bcc" endof  \ C clear

                         $04 of ." bmi" endof  \ N set
                         $05 of ." bpl" endof  \ N clear
                         $06 of ." bvs" endof  \ V set
                         $07 of ." bvc" endof  \ V clear

                         $08 of ." bhi" endof  \ C set Z clear
                         $09 of ." bls" endof  \ C clear or Z set
                         $0A of ." bge" endof  \ N == V
                         $0B of ." blt" endof  \ N != V

                         $0C of ." bgt" endof  \ Z==0 and N == V
                         $0D of ." ble" endof  \ Z==1 or N != V
                         \ $0E: Undefined Instruction
                         $0F of ." swi"  0 imm8.   drop exit endof
                       endcase
                       space
                       dup $FF and dup $80 and if $FFFFFF00 or then
                       shl disasm-$ @ 1 bic + 2 + addr.
                    then

$E000 $F800 opcode? if ." b"                                 \ B(2) unconditional branch
                      dup $7FF and shl
                      dup $800 and if $FFFFF000 or then
                      disasm-$ @ + 2+
                      space addr.
                    then

$4380 $FFC0 opcode? if ." bics" 0 reg. 3 reg. then           \ BIC
$BE00 $FF00 opcode? if ." bkpt" 0 imm8. then                 \ BKPT

\ BL/BLX handled as Thumb-2 instruction on M3/M4.

$4780 $FF87 opcode? if ." blx"  3 reg16. then                \ BLX(2)
$4700 $FF87 opcode? if ." bx"   3 reg16. then                \ BX
$42C0 $FFC0 opcode? if ." cmns" 0 reg. 3 reg. then           \ CMN
$2800 $F800 opcode? if ." cmp"  8 reg. 0 imm8. then          \ CMP(1) compare immediate
$4280 $FFC0 opcode? if ." cmp"  0 reg. 3 reg. then           \ CMP(2) compare register
$4500 $FF00 opcode? if ." cmp"  reg16split. 3 reg16. then    \ CMP(3) compare high register
$B660 $FFE8 opcode? if ." cps"  0 imm5. then                 \ CPS
$4040 $FFC0 opcode? if ." eors" 0 reg. 3 reg. then           \ EOR

$C800 $F800 opcode? if ." ldmia" 8 reg. ."  {" registerlist. ." }" then     \ LDMIA

$6800 $F800 opcode? if ." ldr" 0 reg. ."  [" 3 reg. 6 imm5<<2. ."  ]" then  \ LDR(1) two register immediate
$5800 $FE00 opcode? if ." ldr" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then      \ LDR(2) three register
$4800 $F800 opcode? if ." ldr" 8 reg. ."  [ pc" 0 imm8<<2. ."  ]  Literal " \ LDR(3) literal pool
                       dup $FF and shl shl ( Opcode Offset ) \ Offset for PC
                       disasm-$ @ 2+ 3 bic + ( Opcode Address )
                       dup addr. ." : " @ addr. then

$9800 $F800 opcode? if ." ldr"  8 reg. ."  [ sp" 0 imm8<<2. ."  ]" then     \ LDR(4)

$7800 $F800 opcode? if ." ldrb" 0 reg. ."  [" 3 reg. 6 imm5. ."  ]" then    \ LDRB(1) two register immediate
$5C00 $FE00 opcode? if ." ldrb" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ LDRB(2) three register

$8800 $F800 opcode? if ." ldrh" 0 reg. ."  [" 3 reg. 6 imm5<<1. ."  ]" then \ LDRH(1) two register immediate
$5A00 $FE00 opcode? if ." ldrh" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ LDRH(2) three register

$5600 $FE00 opcode? if ." ldrsb" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then    \ LDRSB
$5E00 $FE00 opcode? if ." ldrsh" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then    \ LDRSH

$0000 $F800 opcode? if ." lsls" 0 reg. 3 reg. 6 imm5. then   \ LSL(1)
$4080 $FFC0 opcode? if ." lsls" 0 reg. 3 reg. then           \ LSL(2) two register
$0800 $F800 opcode? if ." lsrs" 0 reg. 3 reg. 6 imm5. then   \ LSR(1) two register immediate
$40C0 $FFC0 opcode? if ." lsrs" 0 reg. 3 reg. then           \ LSR(2) two register
$2000 $F800 opcode? if ." movs" 8 reg. 0 imm8. then          \ MOV(1) immediate
$4600 $FF00 opcode? if ." mov" reg16split. 3 reg16. then     \ MOV(3)

$4340 $FFC0 opcode? if ." muls" 0 reg. 3 reg. then           \ MUL
$43C0 $FFC0 opcode? if ." mvns" 0 reg. 3 reg. then           \ MVN
$4240 $FFC0 opcode? if ." negs" 0 reg. 3 reg. then           \ NEG
$4300 $FFC0 opcode? if ." orrs" 0 reg. 3 reg. then           \ ORR

$BC00 $FE00 opcode? if ." pop {"  registerlist. dup $0100 and if ."  pc " then ." }" then \ POP
$B400 $FE00 opcode? if ." push {" registerlist. dup $0100 and if ."  lr " then ." }" then \ PUSH

$BA00 $FFC0 opcode? if ." rev"   0 reg. 3 reg. then         \ REV
$BA40 $FFC0 opcode? if ." rev16" 0 reg. 3 reg. then         \ REV16
$BAC0 $FFC0 opcode? if ." revsh" 0 reg. 3 reg. then         \ REVSH
$41C0 $FFC0 opcode? if ." rors"  0 reg. 3 reg. then         \ ROR
$4180 $FFC0 opcode? if ." sbcs"  0 reg. 3 reg. then         \ SBC

$C000 $F800 opcode? if ." stmia" 8 reg. ."  {" registerlist. ." }" then     \ STMIA

$6000 $F800 opcode? if ." str" 0 reg. ."  [" 3 reg. 6 imm5<<2. ."  ]" then  \ STR(1) two register immediate
$5000 $FE00 opcode? if ." str" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then      \ STR(2) three register
$9000 $F800 opcode? if ." str" 8 reg. ."  [ sp + " 0 imm8<<2. ."  ]" then   \ STR(3)

$7000 $F800 opcode? if ." strb" 0 reg. ."  [" 3 reg. 6 imm5. ."  ]" then    \ STRB(1) two register immediate
$5400 $FE00 opcode? if ." strb" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ STRB(2) three register

$8000 $F800 opcode? if ." strh" 0 reg. ."  [" 3 reg. 6 imm5<<1. ."  ]" then \ STRH(1) two register immediate
$5200 $FE00 opcode? if ." strh" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ STRH(2) three register

$1E00 $FE00 opcode? if ." subs" 0 reg. 3 reg. 6 imm3. then   \ SUB(1)
$3800 $F800 opcode? if ." subs" 8 reg. 0 imm8. then          \ SUB(2)
$1A00 $FE00 opcode? if ." subs" 0 reg. 3 reg. 6 reg. then    \ SUB(3)
$B080 $FF80 opcode? if ." sub sp" 0 imm7<<2. then            \ SUB(4)

$B240 $FFC0 opcode? if ." sxtb" 0 reg. 3 reg. then           \ SXTB
$B200 $FFC0 opcode? if ." sxth" 0 reg. 3 reg. then           \ SXTH
$4200 $FFC0 opcode? if ." tst"  0 reg. 3 reg. then           \ TST
$B2C0 $FFC0 opcode? if ." uxtb" 0 reg. 3 reg. then           \ UXTB
$B280 $FFC0 opcode? if ." uxth" 0 reg. 3 reg. then           \ UXTH


\ 16 Bit Thumb-2 instruction ?

$BF00 $FF00 opcode? not if else                              \ IT...
                      dup $000F and
                      case
                        $8 of ." it" endof

                        over $10 and if else $8 xor then
                        $C of ." itt" endof
                        $4 of ." ite" endof

                        over $10 and if else $4 xor then
                        $E of ." ittt" endof
                        $6 of ." itet" endof
                        $A of ." itte" endof
                        $2 of ." itee" endof

                        over $10 and if else $2 xor then
                        $F of ." itttt" endof
                        $7 of ." itett" endof
                        $B of ." ittet" endof
                        $3 of ." iteet" endof
                        $D of ." ittte" endof
                        $5 of ." itete" endof
                        $9 of ." ittee" endof
                        $1 of ." iteee" endof
                      endcase
                      space
                      dup $00F0 and 4 rshift condition.
                    then

\ 32 Bit Thumb-2 instruction ?

$E800 $F800 opcode? if disasm-thumb-2 then
$F000 $F000 opcode? if disasm-thumb-2 then


\ If nothing of the above hits: Invalid Instruction... They are not checked for.

\ Try name resolving for blx r0 sequences:

$2000 $FF00 opcode? if dup $FF and destination-r0  ! then \ movs r0, #...
$3000 $FF00 opcode? if dup $FF and destination-r0 +! then \ adds r0, #...
$0000 $F83F opcode? if destination-r0 @                   \ lsls r0, r0, #...
                         over $07C0 and 6 rshift lshift
                       destination-r0 ! then
dup $4780 =         if destination-r0 @ name. then        \ blx r0

drop \ Forget opcode
; \ disasm

\ ------------------------------
\  Single instruction printing
\ ------------------------------

: memstamp \ ( Addr -- ) Shows a memory location nicely
    dup u.8 ." : " h@ u.4 ."   " ;

: disasm-step ( -- )
    disasm-$ @                 \ Note current position
    dup memstamp disasm cr     \ Disassemble one instruction

    begin \ Write out all disassembled memory locations
      2+ dup disasm-$ @ <>
    while
      dup memstamp cr
    repeat
    drop
;

\ ------------------------------
\  Disassembler for definitions
\ ------------------------------

: seec ( -- ) \ Continues to see
  base @ hex cr

  begin
    disasm-$ @ h@           $4770 =  \ Flag: Loop terminates with bx lr
    disasm-$ @ h@ $FF00 and $BD00 =  \ Flag: Loop terminates with pop { ... pc }
    or
    disasm-step
  until

  base !
;

: see ( -- ) \ Takes name of definition and shows its contents from beginning to first ret
  ' disasm-$ !
  seec
;

\ -----------------------------------------------------------------------------
\   A few tools for dictionary wizardy
\ -----------------------------------------------------------------------------

: executablelocation? ( addr -- ? )
  dup  addrinram?              \ In RAM
  over flashvar-here u< and     \ and below the variables and buffers
  swap addrinflash? or           \ or in flash ?
;

: link>flags ( addr -- addr* ) 4 + 1-foldable ;
: link>name  ( addr -- addr* ) 6 + 1-foldable ;
: link>code  ( addr -- addr* ) 6 + skipstring ;

0 variable searching-for
0 variable closest-found

: code>link  ( entrypoint -- addr | 0 ) \ Try to find this code start address in dictionary

    searching-for !
  0 closest-found !

  compiletoram? 0= >r  \ Save current compile mode
  compiletoram          \ Always scan in compiletoram mode, in order to also find definitions in RAM.

  dictionarystart
  begin
    dup link>code searching-for @ = if dup closest-found ! then
    dictionarynext
  until
  drop

  r> if compiletoflash then \ Restore compile mode

  closest-found @
;

: inside-code>link ( addr-inside -- addr | 0 ) \ Try to find this address inside of a definition

  dup executablelocation? not if drop 0 exit then  \ Do not try to find locations which are not executable

    searching-for !
  0 closest-found !

  compiletoram? 0= >r  \ Save current compile mode
  compiletoram          \ Always scan in compiletoram mode, in order to also find definitions in RAM.

  dictionarystart
  begin

    dup link>code searching-for @ u<=
    if \ Is the address of this entry BEFORE the address which is to be found ?
      \ Distance to current   Latest best distance
      searching-for @ over -  searching-for @ closest-found @ -  <
      if dup closest-found ! then \ Is the current entry closer to the address which is to be found ?
    then

    dictionarynext
  until
  drop

  r> if compiletoflash then \ Restore compile mode

  \ Do not cross RAM/Flash borders:

  searching-for @ addrinflash?
  closest-found @ addrinflash? xor if 0 else closest-found @ then
;

: traceinside. ( addr -- )
  inside-code>link if
  ." ( "                 closest-found @ link>code   hex.
  ." + " searching-for @ closest-found @ link>code - hex.
  ." ) "
  closest-found @ link>name ctype
  then
;

: variable>link  ( location -- addr | 0 ) \ Try to find this variable or buffer in flash dictionary

    searching-for !
  0 closest-found !

  compiletoram? 0= >r  \ Save current compile mode
  compiletoram          \ Always scan in compiletoram mode, in order to also find definitions in RAM.

  dictionarystart
  begin

    dup link>flags h@   \ Fetch Flags of current definition
    $7FF0 and            \ Snip off visibility bit and reserved length
    dup          $140 =   \ Variables and buffers are either initialised variables or
    swap          $80 = or \ "0-foldable and reserves uninitialised memory" when defined in flash memory.
                            \ Take care: You cannot easily use $40 bit "0-foldable" to check for variables and buffers in RAM.
    if
      dup link>code execute searching-for @ = if dup closest-found ! then
    then

    dictionarynext
  until
  drop

  r> if compiletoflash then \ Restore compile mode

  closest-found @
;

: variable-name. ( addr -- ) \ Print the name of this variable or buffer, if possible
  dup flashvar-here u< if inside-code>link else variable>link then
  ?dup if link>name ctype then
;

\ Requires dictionary-tools.txt

: forget ( -- ) \ Usage: forget name, but it will work on definitions in RAM only.
  ' code>link dup addrinram?
  if
    dup @ (latest) !
    (dp) !
  else drop then
;

: del ( -- ) \ Remove the latest definition in RAM.
  (latest) @ addrinram?
  if
    (latest) @ (dp) !
    (latest) @ @ (latest) !
  then
;
\ -----------------------------------------------------------
\   Cooperative Multitasking
\ -----------------------------------------------------------

\ Configuration:

128 cells constant stackspace \ 128 stack elements for every task

\ Internal stucture of task memory:
\  0: Pointer to next task
\  4: Task currently active ?
\  8: Saved stack pointer
\ 12: Handler for Catch/Throw
\  Parameter stack space
\  Return    stack space

false 0 true flashvar-here 4 cells - 4 nvariable boot-task \ Boot task is active, without handler and has no extra stackspace.
boot-task boot-task ! \ For compilation into RAM only

boot-task variable up \ User Pointer
: next-task  ( -- task )    up @ inline ;
: task-state ( -- state )   up @ 1 cells + inline ;
: save-task  ( -- save )    up @ 2 cells + inline ;
: handler    ( -- handler ) up @ 3 cells + inline ;

: (pause) ( stacks fly around )
    [ $B430 h, ]        \ push { r4  r5 } to save I and I'
    rp@ sp@ save-task !  \ save return stack and stack pointer
    begin
      next-task @ up !     \ switch to next running task
    task-state @ until
    save-task @ sp! rp!  \ restore pointers
    unloop ;              \ pop { r4  r5 } to restore the loop registers

: wake ( task -- ) 1 cells +  true swap ! ; \ Wake a random task (IRQ save)
: idle ( task -- ) 1 cells + false swap ! ;  \ Idle a random task (IRQ save)

\ -------------------------------------------------------
\  Round-robin list task handling - do not use in IRQ !
\ -------------------------------------------------------

: stop ( -- ) false task-state ! pause ; \ Stop current task
: multitask  ( -- ) ['] (pause) hook-pause ! ;
: singletask ( -- ) [']  nop    hook-pause ! ;

: task-in-list? ( task -- ? ) \ Checks if a task is currently inside of round-robin list (do not use in IRQ)
  next-task
  begin
    ( Task-Address )
    2dup = if 2drop true exit then
    @ dup next-task = \ Stop when end of circular list is reached
  until
  2drop false
;

: previous ( task -- addr-of-task-before )
  \ Find the task that has the desired one in its next field
  >r next-task begin dup @ r@ <> while @ repeat rdrop
;

: insert ( task -- ) \ Insert a task into the round-robin list
  dup task-in-list?  \ Is the desired task currently linked into ?
  if drop else next-task @ over ! next-task ! then
;

: remove ( task -- ) \ Remove a task from the round-robin list
  dup task-in-list?  \ Is the desired task currently linked into ?
  if dup @ ( task next )
     swap previous ( next previous ) !
  else drop then
;

\ -----------------------------------------
\ Create a new task - do not use in IRQ !
\ -----------------------------------------

: task: ( "name" -- )  stackspace cell+ 2*  4 cells +  buffer: ;

: preparetask ( task continue -- )
  swap >r ( continue R: task )

    \ true  r@ 1 cells + ! \ Currently running
      false r@ 3 cells + ! \ No handler

    r@ 4 cells + stackspace + ( continue start-of-parameter-stack )
      dup   r@ 2 cells + ! \ Start of parameter stack

    dup stackspace + ( continue start-of-parameter-stack start-of-return-stack )
    tuck      ( continue start-of-return-stack start-of-parameter-stack start-of-return-stack )
    2 cells - ( continue start-of-return-stack start-of-parameter-stack start-of-return-stack* ) \ Adjust for saved loop index and limit
    swap  !   ( continue start-of-return-stack ) \ Store the adjusted return stack pointer into the parameter stack
    !         \ Store the desired entry address at top of the tasks return stack

  r> insert
;

: activate ( task --   R: continue -- )
  true over 1 cells + ! \ Currently running
  r> preparetask
;

: background ( task --   R: continue -- )
  false over 1 cells + ! \ Currently idling
  r> preparetask
;

\ --------------------------------------------------
\  Multitasking insight
\ --------------------------------------------------

: tasks ( -- ) \ Show tasks currently in round-robin list
  hook-pause @ singletask \ Stop multitasking as this list may be changed during printout.

  \ Start with current task.
  next-task cr

  begin
    ( Task-Address )
    dup             ." Task Address: " hex.
    dup           @ ." Next Task: " hex.
    dup 1 cells + @ ." State: " hex.
    dup 2 cells + @ ." Stack: " hex.
    dup 3 cells + @ ." Handler: " hex. cr

    @ dup next-task = \ Stop when end of circular list is reached
  until
  drop

  hook-pause ! \ Restore old state of multitasking
;

\ --------------------------------------------------
\  Exception handling
\ --------------------------------------------------

: catch ( x1 .. xn xt -- y1 .. yn throwcode / z1 .. zm 0 )
    [ $B430 h, ]  \ push { r4  r5 } to save I and I'
    sp@ >r handler @ >r rp@ handler !  execute
    r> handler !  rdrop  0 unloop ;

: throw ( throwcode -- )  dup IF
	handler @ 0= IF false task-state ! THEN \ unhandled error: stop task
	handler @ rp! r> handler ! r> swap >r sp! drop r>
	UNLOOP  EXIT
    ELSE  drop  THEN ;

\ Requires dictionary-tools.txt

\ --------------------------------------------------
\  Multitasking insight
\ --------------------------------------------------

: tasks ( -- ) \ Show tasks currently in round-robin list
  hook-pause @ singletask \ Stop multitasking as this list may be changed during printout.

  \ Start with current task.
  next-task cr

  begin
    ( Task-Address )
    dup             ." Task Address: " hex.
    dup           @ ." Next Task: " hex.
    dup 1 cells + @ ." State: " hex.
    dup 2 cells + @ ." Stack: " hex.
    dup 3 cells + @ ." Handler: " hex.
    dup             ." Name: " variable-name. cr

    @ dup next-task = \ Stop when end of circular list is reached
  until
  drop

  hook-pause ! \ Restore old state of multitasking
;

\ --------------------------------------------------
\  Multitasking debug tools
\ --------------------------------------------------

:  depth ( -- n ) up @ boot-task = if  depth    else up @ 4 cells stackspace    + + sp@ - 2 arshift then ;
: rdepth ( -- n ) up @ boot-task = if rdepth 1- else up @ 4 cells stackspace 2* + + rp@ - 2 arshift then ;

: .s ( -- )
  base @ >r decimal depth ." Stack: [" . ." ] " r> base !
  depth >r
  begin
    r@ 0 >
  while
    r@ pick .
    r> 1- >r
  repeat
  rdrop
  ."  TOS: " dup . ."  *>" cr
;

: u.s ( -- )
  base @ >r decimal depth ." Stack: [" . ." ] " r> base !
  depth >r
  begin
    r@ 0 >
  while
    r@ pick u.
    r> 1- >r
  repeat
  rdrop
  ."  TOS: " dup u. ."  *>" cr
;

: h.s ( -- )
  base @ >r decimal depth ." Stack: [" . ." ] " r> base !
  depth >r
  begin
    r@ 0 >
  while
    r@ pick hex.
    r> 1- >r
  repeat
  rdrop
  ."  TOS: " dup hex. ."  *>" cr
;

\ A 32 bit cycle counter available on most M3/M4/M7 targets

$E0001000 constant DWT_CONTROL
$E0001004 constant DWT_CYCCNT
$E0001FB0 constant DWT_LAR
$E000EDFC constant SCB_DEMCR

: init-cycles ( -- )

  $C5ACCE55 DWT_LAR !     \ Unlock
  $01000000 SCB_DEMCR !   \ Enable Data Watchpoint and Trace (DWT) module
          0 DWT_CYCCNT !  \ Reset the counter
          1 DWT_CONTROL ! \ Enable the counter

;

: cycles ( -- u ) DWT_CYCCNT @ ;

: delay-cycles ( cycles -- )
  cycles ( cycles start )
  begin
    pause
    2dup ( cycles start cycles start )
    cycles ( cycles start cycles start current )
    swap - ( cycles start cycles elapsed )
    u<=
  until
  2drop
;

\ Cornerstone for flash sectors with variable length

: sectorborder ( addr -- u )

  case
  
  \ --- 16 kb sectors ---
  
    $04000  of   1  endof
    $08000  of   2  endof
    $0C000  of   3  endof
  
  \ --- 64 kb sector  ---
  
    $10000  of   4  endof
  
  \ --- 128 kb sectors ---
  
    $20000  of   5  endof
    $40000  of   6  endof
    $60000  of   7  endof
    $80000  of   8  endof
    $A0000  of   9  endof
    $C0000  of  10  endof
    $E0000  of  11  endof
      
  \ Not on a sector border

  0 swap 
  endcase
;

: cornerstone ( Name ) ( -- )
  <builds begin here sectorborder 0= while 0 h, repeat
  does>   begin dup  sectorborder 0= while 2+   repeat 
          sectorborder 12 swap ?do i eraseflashsector loop reset
;

$40020000 constant GPIOA
$40020400 constant GPIOB
$40020800 constant GPIOC
$40020C00 constant GPIOD
$40021000 constant GPIOE
$40021400 constant GPIOF
$40021800 constant GPIOG
$40021C00 constant GPIOH
$40022000 constant GPIOI

GPIOA $00 + constant GPIOA_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOA $04 + constant GPIOA_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOA $08 + constant GPIOA_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOA $0C + constant GPIOA_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOA $10 + constant GPIOA_IDR      \ RO      Input Data Register
GPIOA $14 + constant GPIOA_ODR      \ Reset 0 Output Data Register
GPIOA $18 + constant GPIOA_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOA $1C + constant GPIOA_LCKR     \ Reset 0 Port configuration lock register
GPIOA $20 + constant GPIOA_AFRL     \ Reset 0 Alternate function  low register
GPIOA $24 + constant GPIOA_AFRH     \ Reset 0 Alternate function high register

GPIOB $00 + constant GPIOB_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOB $04 + constant GPIOB_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOB $08 + constant GPIOB_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOB $0C + constant GPIOB_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOB $10 + constant GPIOB_IDR      \ RO      Input Data Register
GPIOB $14 + constant GPIOB_ODR      \ Reset 0 Output Data Register
GPIOB $18 + constant GPIOB_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOB $1C + constant GPIOB_LCKR     \ Reset 0 Port configuration lock register
GPIOB $20 + constant GPIOB_AFRL     \ Reset 0 Alternate function  low register
GPIOB $24 + constant GPIOB_AFRH     \ Reset 0 Alternate function high register

GPIOC $00 + constant GPIOC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOC $04 + constant GPIOC_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOC $08 + constant GPIOC_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOC $0C + constant GPIOC_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOC $10 + constant GPIOC_IDR      \ RO      Input Data Register
GPIOC $14 + constant GPIOC_ODR      \ Reset 0 Output Data Register
GPIOC $18 + constant GPIOC_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOC $1C + constant GPIOC_LCKR     \ Reset 0 Port configuration lock register
GPIOC $20 + constant GPIOC_AFRL     \ Reset 0 Alternate function  low register
GPIOC $24 + constant GPIOC_AFRH     \ Reset 0 Alternate function high register

GPIOD $00 + constant GPIOD_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOD $04 + constant GPIOD_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOD $08 + constant GPIOD_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOD $0C + constant GPIOD_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOD $10 + constant GPIOD_IDR      \ RO      Input Data Register
GPIOD $14 + constant GPIOD_ODR      \ Reset 0 Output Data Register
GPIOD $18 + constant GPIOD_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOD $1C + constant GPIOD_LCKR     \ Reset 0 Port configuration lock register
GPIOD $20 + constant GPIOD_AFRL     \ Reset 0 Alternate function  low register
GPIOD $24 + constant GPIOD_AFRH     \ Reset 0 Alternate function high register

GPIOE $00 + constant GPIOE_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOE $04 + constant GPIOE_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOE $08 + constant GPIOE_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOE $0C + constant GPIOE_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOE $10 + constant GPIOE_IDR      \ RO      Input Data Register
GPIOE $14 + constant GPIOE_ODR      \ Reset 0 Output Data Register
GPIOE $18 + constant GPIOE_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOE $1C + constant GPIOE_LCKR     \ Reset 0 Port configuration lock register
GPIOE $20 + constant GPIOE_AFRL     \ Reset 0 Alternate function  low register
GPIOE $24 + constant GPIOE_AFRH     \ Reset 0 Alternate function high register

GPIOF $00 + constant GPIOF_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOF $04 + constant GPIOF_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOF $08 + constant GPIOF_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOF $0C + constant GPIOF_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOF $10 + constant GPIOF_IDR      \ RO      Input Data Register
GPIOF $14 + constant GPIOF_ODR      \ Reset 0 Output Data Register
GPIOF $18 + constant GPIOF_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOF $1C + constant GPIOF_LCKR     \ Reset 0 Port configuration lock register
GPIOF $20 + constant GPIOF_AFRL     \ Reset 0 Alternate function  low register
GPIOF $24 + constant GPIOF_AFRH     \ Reset 0 Alternate function high register

GPIOG $00 + constant GPIOG_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOG $04 + constant GPIOG_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOG $08 + constant GPIOG_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOG $0C + constant GPIOG_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOG $10 + constant GPIOG_IDR      \ RO      Input Data Register
GPIOG $14 + constant GPIOG_ODR      \ Reset 0 Output Data Register
GPIOG $18 + constant GPIOG_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOG $1C + constant GPIOG_LCKR     \ Reset 0 Port configuration lock register
GPIOG $20 + constant GPIOG_AFRL     \ Reset 0 Alternate function  low register
GPIOG $24 + constant GPIOG_AFRH     \ Reset 0 Alternate function high register

GPIOH $00 + constant GPIOH_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOH $04 + constant GPIOH_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOH $08 + constant GPIOH_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOH $0C + constant GPIOH_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOH $10 + constant GPIOH_IDR      \ RO      Input Data Register
GPIOH $14 + constant GPIOH_ODR      \ Reset 0 Output Data Register
GPIOH $18 + constant GPIOH_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOH $1C + constant GPIOH_LCKR     \ Reset 0 Port configuration lock register
GPIOH $20 + constant GPIOH_AFRL     \ Reset 0 Alternate function  low register
GPIOH $24 + constant GPIOH_AFRH     \ Reset 0 Alternate function high register

GPIOI $00 + constant GPIOI_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOI $04 + constant GPIOI_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOI $08 + constant GPIOI_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOI $0C + constant GPIOI_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOI $10 + constant GPIOI_IDR      \ RO      Input Data Register
GPIOI $14 + constant GPIOI_ODR      \ Reset 0 Output Data Register
GPIOI $18 + constant GPIOI_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOI $1C + constant GPIOI_LCKR     \ Reset 0 Port configuration lock register
GPIOI $20 + constant GPIOI_AFRL     \ Reset 0 Alternate function  low register
GPIOI $24 + constant GPIOI_AFRH     \ Reset 0 Alternate function high register
: bit ( n -- mask ) 1 swap lshift 1-foldable inline ;

\ FLASH
$40023C00 constant FLASH ( FLASH )
FLASH $0 + constant FLASH_ACR (  )  \ Flash access control register
FLASH $4 + constant FLASH_KEYR ( write-only )  \ Flash key register
FLASH $8 + constant FLASH_OPTKEYR ( write-only )  \ Flash option key register
FLASH $C + constant FLASH_SR (  )  \ Status register
FLASH $10 + constant FLASH_CR ( read-write )  \ Control register
FLASH $14 + constant FLASH_OPTCR ( read-write )  \ Flash option control register

\ RNG
$50060800 constant RNG ( Random number generator )
RNG $0 + constant RNG_CR ( read-write )  \ control register
RNG $4 + constant RNG_SR (  )  \ status register
RNG $8 + constant RNG_DR ( read-only )  \ data register

\ RCC
$40023800 constant RCC ( Reset and clock control )
RCC $00 + constant RCC_CR (  )  \ clock control register
RCC $04 + constant RCC_PLLCFGR ( read-write )  \ PLL configuration register
RCC $08 + constant RCC_CFGR (  )  \ clock configuration register
RCC $0C + constant RCC_CIR (  )  \ clock interrupt register
RCC $10 + constant RCC_AHB1RSTR ( read-write )  \ AHB1 peripheral reset register
RCC $14 + constant RCC_AHB2RSTR ( read-write )  \ AHB2 peripheral reset register
RCC $18 + constant RCC_AHB3RSTR ( read-write )  \ AHB3 peripheral reset register
RCC $20 + constant RCC_APB1RSTR ( read-write )  \ APB1 peripheral reset register
RCC $24 + constant RCC_APB2RSTR ( read-write )  \ APB2 peripheral reset register
RCC $30 + constant RCC_AHB1ENR ( read-write )  \ AHB1 peripheral clock register
RCC $34 + constant RCC_AHB2ENR ( read-write )  \ AHB2 peripheral clock enable  register
RCC $38 + constant RCC_AHB3ENR ( read-write )  \ AHB3 peripheral clock enable  register
RCC $40 + constant RCC_APB1ENR ( read-write )  \ APB1 peripheral clock enable  register
RCC $44 + constant RCC_APB2ENR ( read-write )  \ APB2 peripheral clock enable  register
RCC $50 + constant RCC_AHB1LPENR ( read-write )  \ AHB1 peripheral clock enable in low power  mode register
RCC $54 + constant RCC_AHB2LPENR ( read-write )  \ AHB2 peripheral clock enable in low power  mode register
RCC $58 + constant RCC_AHB3LPENR ( read-write )  \ AHB3 peripheral clock enable in low power  mode register
RCC $60 + constant RCC_APB1LPENR ( read-write )  \ APB1 peripheral clock enable in low power  mode register
RCC $64 + constant RCC_APB2LPENR ( read-write )  \ APB2 peripheral clock enabled in low power  mode register
RCC $70 + constant RCC_BDCR (  )  \ Backup domain control register
RCC $74 + constant RCC_CSR (  )  \ clock control & status  register
RCC $80 + constant RCC_SSCGR ( read-write )  \ spread spectrum clock generation  register
RCC $84 + constant RCC_PLLI2SCFGR ( read-write )  \ PLLI2S configuration register

\ USART
$40004408 constant USART2_BRR

\ Bits in RCC_CR
16 bit constant HSEON
17 bit constant HSERDY
24 bit constant PLLON
25 bit constant PLLRDY

$705 constant ART-5WS \ Enable data cache, instruction and prefetching, 5 wait states

7 24 lshift    \ PLLQ = 7
22 bit +       \ PLLSRC = HSE, PLLP = 0
336 6 lshift + \ PLLN = 336
8 +            \ PLLM = 8
constant pll-8>168

4 13 lshift   \ PPRE2 = /2 (APB2 = 84MHz)
5 10 lshift + \ PPRE1 = /4 (APB1 = 42MHz)
2 +           \ SW = PLL
constant cfg-pll

: hse-on ( -- ) HSEON RCC_CR bis! begin HSERDY RCC_CR bit@ until ;
: pll-on ( -- ) PLLON RCC_CR bis! begin PLLRDY RCC_CR bit@ until ;
: pll-168MHz ( -- ) pll-8>168 RCC_PLLCFGR ! ;
: flash-168MHz ( -- ) ART-5WS FLASH_ACR ! ;
: use-pll ( -- ) cfg-pll RCC_CFGR ! ;
: baud-168MHz ( -- ) $16d USART2_BRR ! ; \ Set Baud rate divider for 115200 Baud at 42 MHz. 22.786
: 168MHz ( -- ) hse-on flash-168MHz pll-168MHz pll-on use-pll baud-168MHz ;

168000000 constant clock-hz

: us ( n -- ) clock-hz 1000000 / * delay-cycles ;
: ms ( n -- ) clock-hz 1000 / * delay-cycles ;

: init-rng ( -- )
	6 bit RCC_AHB2ENR bis!
	2 bit RNG_CR bis! ;

: rng-ready? ( -- ? ) 0 bit RNG_SR bit@ inline ;

: random ( -- x )
	begin rng-ready? until RNG_DR @ ;
\ A polled buffered USB serial driver for STM32F4xx by Jan Bramkamp
\ Started of as C++ to Forth port of stm32f4-usb.h by Jean-Claude Wippler

\ Work in progress - additional descriptors and automatic
\ UART <-> USB switchover will be implemented soon.

\ Full word endian conversion
: rev ( x -- x' ) [ $ba36 h, ] inline 1-foldable ;
\ Half word endian conversion
: rev16 ( x -- x' ) [ $ba76 h, ] inline 1-foldable ;

\ A h, replacement with no alignment restrictions
: 2c, ( h -- ) dup c, 8 rshift c, ;

$50000000 constant usb-base
usb-base $008 + constant GAHBCFG   \ p.1275
usb-base $00C + constant GUSBCFG   \ p.1276
usb-base $014 + constant GINTSTS   \ p.1280
usb-base $020 + constant GRXSTSP   \ p.1287
usb-base $024 + constant GRXFSIZ   \ p.1288
usb-base $028 + constant DIEPTXF0  \ p.1289
usb-base $038 + constant GCCFG     \ p.1290
usb-base $104 + constant DIEPTXF1  \ p.1292
usb-base $800 + constant DCFG      \ p.1303
usb-base $808 + constant DSTS      \ p.1305
usb-base $900 + constant DIEPCTL0  \ p.1310
usb-base $910 + constant DIEPTSIZ0 \ p.1321
usb-base $918 + constant DTXFSTS0  \ p.1325
usb-base $B00 + constant DOEPCTL0  \ p.1316
usb-base $B10 + constant DOEPTSIZ0 \ p.1323
usb-base $B20 + constant DOEPCTL1
usb-base $B30 + constant DOEPTSIZ1
usb-base $B40 + constant DOEPCTL2
usb-base $B50 + constant DOEPTSIZ2
usb-base $920 + constant DIEPCTL1
usb-base $940 + constant DIEPCTL2
usb-base $938 + constant DTXFSTS1
usb-base $958 + constant DTXFSTS2
usb-base $930 + constant DIEPTSIZ1

create dev-data here
        \ length
        \ |    descriptor type (1 = device descriptor)
	\ |    |        usb specification number
	\ |    |        |     device class
	\ |    |        |     |    device subclass
	\ |    |        |     |    |    device protocol
	\ |    |        |     |    |    |
        \ |    |        |     |    |    |    max packet size
        \ |    |        |     |    |    |     |
        \ v    v        v     v    v    v     v
         18 c, 1 c, $0200 2c, 2 c, 0 c, 0 c, 64 c,
        \ vendor id
        $0483 2c,
        \ product id
        $5740 2c,
        \ device release number
        \   |     manufacturer string descriptor index (0 = none)
        \   |     |    product string descriptor index (0 = none)
	\   |     |    |    serial number string descriptor index (0 = none)
        \   |     |    |    |    number of possible configurations
        \   |     |    |    |    |
        \   v     v    v    v    v
        $0200 2c, 0 c, 0 c, 0 c, 1 c,
here align swap - constant dev-size

create cfg-data here
	\ device descriptor length
	\ |     descriptor type (2 = configuration descriptor)
	\ |     |      total length (for all descriptors)
	\ |     |      |      number of interfaces
	\ |     |      |      |     index for this configuration
	\ |     |      |      |     |     configuration string descriptor index (0 = none)
	\ |     |      |      |     |     |            attribute bitmap (bit 7 = bus powered, bit 6 = self powered) oxymoron?!?
        \ |     |      |      |     |     |            |      max power in steps of two mA
        \ |     |      |      |     |     |            |      |
        \ v     v      v      v     v     v            v      v
          9 c,  2 c,  67 2c,  2 c,  1 c,  0 c, %11000000 c, 100 2/ c, \ USB Configuration

        \ interface descriptor length
        \ |    descriptor type (4 = interface descriptor)
	\ |    |    interface number
	\ |    |    |    alternate setting
	\ |    |    |    |    number of endpoints
	\ |    |    |    |    |    class code
	\ |    |    |    |    |    |    subclass codde
	\ |    |    |    |    |    |    |    protocol code
	\ |    |    |    |    |    |    |    |    interface string descriptor index (0 = none)
	\ |    |    |    |    |    |    |    |    |
	\ v    v    v    v    v    v    v    v    v
	  9 c, 4 c, 0 c, 0 c, 1 c, 2 c, 2 c, 0 c, 0 c, \ Interface

	  5 c, 36 c, 0 c, 16 c, 1 c, \ Header Functional
	  5 c, 36 c, 1 c,  0 c, 1 c, \ Call Management Functional
	  4 c, 36 c, 2 c,  2 c,      \ ACM Functional
	  5 c, 36 c, 6 c,  0 c, 1 c, \ Union Functional

	\ endpoint descriptor length
	\ |    descriptor type (5 = endpoint descriptor)
	\ |    |      endpoint address (endpoint = 2, direction = IN)
	\ |    |      |    attributes (type = interrupt)
	\ |    |      |    |    max packet size
        \ |    |      |    |    |       polling interval in ms (slow?)
        \ |    |      |    |    |       |
        \ v    v      v    v    v       v
          7 c, 5 c, 130 c, 3 c, 8 2c, 255 c, \ Endpoint 2 IN

        \ interface descriptor length
        \ |    descriptor type (4 = interface descriptor)
	\ |    |    interface number
	\ |    |    |    alternate setting
	\ |    |    |    |    number of endpoints
	\ |    |    |    |    |     class code
	\ |    |    |    |    |     |    subclass codde
	\ |    |    |    |    |     |    |    protocol code
	\ |    |    |    |    |     |    |    |    interface string descriptor index (0 = none)
	\ |    |    |    |    |     |    |    |    |
	\ v    v    v    v    v     v    v    v    v
	  9 c, 4 c, 1 c, 0 c, 2 c, 10 c, 0 c, 0 c, 0 c, \ Data class interface
	\ endpoint descriptor length
	\ |    descriptor type (5 = endpoint descriptor)
	\ |    |    endpoint address (endpoint = 1, direction = OUT)
	\ |    |    |    attributes (type = bulk)
	\ |    |    |    |     max packet size
        \ |    |    |    |     |      polling interval (ignored)
        \ |    |    |    |     |      |
        \ v    v    v    v     v      v
          7 c, 5 c, 1 c, 2 c, 64 2c,  0 c, \ Endpoint 1 OUT

        \ endpoint descriptor length
        \ |    descriptor type (5 = endpoint descriptor)
	\ |    |      endpoint address (endpoint = 1, direction = IN)
	\ |    |      |    attributes (type = bulk)
	\ |    |      |    |     max packet size
        \ |    |      |    |     |     polling interval (ignored)
        \ |    |      |    |     |     |
        \ v    v      v    v     v     v
          7 c, 5 c, 129 c, 2 c, 64 2c, 0 c, \ Endpoint 1 IN
here align swap - constant cfg-size

: usb-on ( -- ) 7 bit RCC_AHB2ENR bis! ;

0 1+ $1000 * usb-base + constant fifo0
1 1+ $1000 * usb-base + constant fifo1

: usb-gpio ( -- )
	\ Pulse PA11 low as open drain for 3 ms
        %1111 11 2* lshift GPIOA_MODER   bic! \ Clear mode of PA11 and PA12
        %1111 11 2* lshift GPIOA_OSPEEDR bic! \ Clear drive strength
        %0101 11 2* lshift GPIOA_OSPEEDR bis! \ Set drive strength for 25 MHz

          12 bit 16 lshift GPIOA_BSRR       ! \ PA12 low
          %01 12 2* lshift GPIOA_MODER   bis! \ Set PA12 as output

        12 bit             GPIOA_OTYPER  bis! \ PA12 Open Drain
        3 ms
        12 bit             GPIOA_OTYPER  bic!

        %1111 11 2* lshift GPIOA_MODER   bic! \ Clear mode of PA11 and PA12

        $000FF000          GPIOA_AFRH    bic! \ Clear alternate function
        $000AA000          GPIOA_AFRH    bis! \ Set alternate function 10

        %1010 11 2* lshift GPIOA_MODER   bis! \ Set pins to alternate function mode
;

21 bit constant NOVBUSSENS
16 bit constant PWRDWN
30 bit constant FDMOD

\ Disable USB power supply sensing and enable the transceiver.
\ Voltage sensing isn't possible on a lot of STM32F4xx boards because the USB +5V pin is directly connected to
\ the board +5V supply leaving the unusuable voltage sensing pin available for other uses.
: usb-enable ( -- ) NOVBUSSENS PWRDWN or GCCFG bis! ;

\ Implementing a USB device is already bad enough.
: usb-force-device ( -- ) FDMOD GUSBCFG bis! ;

\ The only supported speed in device mode is full speed (12Mbps)
: usb-fullspeed ( -- ) %11 DCFG bis! ;

: usb-init ( -- )
	usb-on
	usb-gpio
	usb-force-device
	usb-enable
	usb-fullspeed ;

0 variable in-pending
0 variable in-ready
0 variable in-data
0 variable baud
0 variable dtr

13 bit constant ENUMDNE
: enum-done? ( irq -- ? ) ENUMDNE and 0<> 1-foldable inline ;

4 bit constant RXFLVL
: rx-fifo? ( irq -- ? ) RXFLVL and 0<> 1-foldable inline ;
: new-packet? ( irq -- ? ) rx-fifo? in-pending @ 0= and 1-foldable inline ;

%0001 constant type-out-nak
%0010 constant type-out
%0011 constant type-out-done
%0100 constant type-setup-done
%0110 constant type-setup

$88776655 $44332211 2variable usb-buf
usb-buf 1+  constant usb-req
usb-buf 2+  constant usb-val
usb-buf 6 + constant usb-len

: save-setup ( -- )
	fifo0 @ usb-buf !
	fifo0 @ usb-buf cell+ ! ;

: clear-nak ( status -- )
	$f and 5 lshift DOEPCTL0 + 26 bit swap bis! ;

: >ep    ( status -- ep    ) $f and inline 1-foldable ;
: ep0?   ( status -- ?     ) >ep 0 = inline 1-foldable ;
: ep1?   ( status -- ?     ) >ep 1 = inline 1-foldable ;
: >count ( status -- count ) 4 rshift $7ff and inline 1-foldable ;
: >type  ( status -- type  ) 17 rshift $f and inline 1-foldable ;


: data. ( data -- )
	base @ hex swap ( base data )
	rev 0 <# # # bl hold # # bl hold # # bl hold # # #> type ( base )
	base ! ( data ) ;

: usb-send0 ( addr len -- )
	\ truncate the packet to what the USB host ordered
	usb-len h@ min ( addr len )
	\ set the packet length
	dup DIEPTSIZ0 ! ( addr len )
	\ enable the endpoint 0 and clear NAK
	31 bit 26 bit or DIEPCTL0 bis! ( addr len )
	\ copy the packet into the fifo
	over + swap ?do i @ fifo0 ! 4 +loop ;
	\ 0 ?do ( addr )
	\ 	dup i + @ ( addr data )
	\ 	fifo0 ! ( addr )
	\ 4 +loop drop ;


: usb-irq@ ( -- irq ) GINTSTS @ dup GINTSTS ! ;


\ Print the bit indices of all active USB IRQs
: usb-irq. ( irq -- )
	dup $04008028 bic if ( irq )
		\ Start a new block of trace messages
		cr ." -------------------------------------------------------------------------------"
		cr ." USB: irqs = "
		32 0 do ( irq )
			i bit over and if ( irq )
				i . ( irq )
			then
		loop
	then drop ;

: fifo-setup ( -- )
	512 4 / GRXFSIZ !                          \ 512b for RX all
	128 4 / 16 lshift 512 or        DIEPTXF0 ! \ 128b for TX ep0
	512 4 / 16 lshift 512 or 128 or DIEPTXF1 ! \ 512b for TX ep1

	\ see p.1354
    \ Configure endpoint 1 IN:
    31 bit          \ enable endpoint
    26 bit or       \ clear NAK bit
	1 22 lshift or  \ use fifo 1
    2 18 lshift or  \ endpoint type = BULK
    15 bit or       \ activate endpoint
    64 or           \ max packet size
    DIEPCTL1 !

    \ Configure endpoint 2 IN:
	2 22 lshift     \ use fifo 2
    3 18 lshift or  \ endpoint type = INTERRUPT
    15 bit or       \ activate endpoint
    64 or           \ max packet size
    DIEPCTL2 !

    \ Configure endpoint 0 OUT:
	3 29 lshift     \ allow up to three setup packets
    64 or           \ transfer size
    DOEPTSIZ0 !
	31 bit          \ enable endpoint
    26 bit or       \ clear NAK bit
    15 bit or       \ activate endpoint
    DOEPCTL0 ! ;

: usb-status@ ( -- status ) GRXSTSP @ inline ;

\ Check for USB CDC class requests (from the SETUP packet)
: set-line-coding?        ( -- ? ) usb-req c@ $20 = inline ;
: get-line-coding?        ( -- ? ) usb-req c@ $21 = inline ;
: set-control-line-state? ( -- ? ) usb-req c@ $22 = inline ;

: baud? ( status -- ? ) ep0? set-line-coding? and i 0= and inline ;
: baud. ( baud -- )
    baud ! ;
: misc. ( data -- )
    drop ;
: usb-decode ( data status -- ) baud? if dup baud. baud ! else misc. then ;

: packet-done? ( n -- ? ) usb-len h@ swap - dup usb-len h! 0= ;

: usb-receive ( status -- )
	dup ep1? if ( status )
		\ This packet contains console input.
		>count in-pending ! ( )
	else ( status )
		\ Decode standard and class requests (only set baudrate implemented)
		dup >count 0 ?do ( status )
			fifo0 @ over usb-decode ( status )
		4 +loop ( status )

		\ Release endpoint 0 host to device FIFO if the packet is complete?
		dup ep0? if ( status )
			>count packet-done? if 0 0 usb-send0 then
		else ( status )
			drop
		then ( )
	then ;

: usb-addr! ( usb-addr -- )
    DCFG @ $ffff80f and DCFG ! ( usb-addr ) \ Clear address
    $7f and 4 lshift DCFG @ or DCFG ! ; ( ) \ Insert address

\ ERRATA:
\   Several STM32Fxxx chips have a documented hardware flaw. The DAD bitfield in the DCFG register doesn't read correctly.
: usb-addr@ ( -- usb-addr )
    DCFG @                \ load the device configuration
    21 lshift 25 rshift ; \ extract the device address

: set-addr ( -- )
	usb-val h@ ( usb-addr )                    \ the wValue from the SETUP packet contains the device address
    usb-addr! ; ( )

: get-desc ( addr len -- addr len )
	usb-val h@ case
		$100 of 2drop dev-data dev-size endof
                $200 of 2drop cfg-data cfg-size endof
        endcase ;

: set-conf ( -- )
        64 dup DOEPTSIZ1 ! \ up to 64 bytes

        15 bit or          \ activate endpoint
        %10 18 lshift or   \ transfer type = BULK
        26 bit or          \ clear NAK
        31 bit or          \ enable endpoint
        DOEPCTL1 ! ;

\ Extract the DTR line state
: set-line ( -- ) usb-val h@ 31 lshift 31 arshift dtr ! ;

: usb-respond ( -- )
        26 bit DOEPCTL0 bis! \ clear NAK bit
	\ Find out which USB request we're supposed to respond to
	0 0 usb-req c@ case ( addr len )
		$05 of set-addr endof
		$06 of get-desc endof
		$09 of set-conf endof
		$22 of set-line endof
	endcase ( addr len )
	usb-len h@ 0= $80 usb-buf cbit@ or ( addr len send? )
	if usb-send0 else 2drop then ( ) ;

: usb-dispatch ( status -- )
	dup >type case ( status )
		type-setup      of drop save-setup  endof
		type-out-done   of      clear-nak   endof
		type-out        of      usb-receive endof
                type-setup-done of drop usb-respond endof
        endcase ;

8                  constant emit-log2
1 emit-log2 lshift constant emit-size
emit-size 1-       constant emit-mask
0                  variable emit-read
0                  variable emit-write
emit-size cell+    buffer:  emit-ring

: emit-used ( -- n ) emit-write @ emit-read @ - inline ;
: emit-full? ( -- ? ) emit-used emit-size = inline ;
: emit-empty? ( -- ? ) emit-used 0= inline ;
: emit-push ( c -- )
    emit-full? if
        drop
    else
        emit-ring emit-write @ emit-mask and + c!
        1 emit-write +!
    then ;
: emit-pop ( -- c )
    emit-empty? if
        0
    else
        emit-ring emit-read @ emit-mask and + c@
        1 emit-read +!
    then ;

\ Because the Cortex M4 core lacks proper circular addressing
\ we have to help it by duplicating the first 32 bits of the ring
\ buffer to make use of the unaligned load hardware support.
: emit-fix ( -- ) emit-ring @ emit-ring emit-size + ! ;

\ You have to call emit-fix between emit-push and emit-pop4.
: emit-pop4 ( -- x )
    emit-empty? if
        0
    else
        emit-ring emit-read @ emit-mask and + @
        4 emit-used min emit-read +!
    then ;

: usb-space ( -- ? ) DTXFSTS1 @ $ffff and cells ;
: usb-idle? ( -- ? ) DTXFSTS1 @ $ffff and 128 = ;

0 variable max-batch
: usb-tx ( -- )
    emit-empty? not dtr @ and if
        usb-idle? if
            emit-used 512 min dup DIEPTSIZ1 !
            dup max-batch @ max max-batch !
            emit-fix 0 do emit-pop4 fifo1 ! 4 +loop
        then
    then ;

: usb-poll ( -- )
        \ Read and clear the USB interrupts
        usb-irq@ \ dup usb-irq. ( irq )

	\ Setup FIFOs after enumeration
	dup enum-done? if fifo-setup then ( irq )

	\ Dispatch the received USB packet if there is one
        new-packet? if
        usb-status@
        usb-dispatch
    then

    usb-tx ;

: usb-enum ( -- )
        usb-irq@ dup usb-irq. ( irq )
        enum-done? if fifo-setup then ;

: usb-key? ( -- ? ) usb-poll in-ready @ 0 > in-pending @ 0 > or ;

: (usb-key) ( -- c )
    in-ready @ 0= if ( )
        in-pending @ dup 4 min dup in-ready ! - in-pending !
        fifo1 @ in-data ! ( pending )
    then
    -1 in-ready +!
    in-data @ dup 8 rshift in-data ! $ff and ;

: usb-key ( -- c ) begin usb-key? until (usb-key) ;

: usb-emit? ( -- ? ) usb-poll emit-full? not dtr @ 0= or ;

: usb-emit ( c -- ) begin usb-emit? until emit-push ;

: +usb ( -- )
    ['] usb-key?  hook-key?  !
    ['] usb-key   hook-key   !
    ['] usb-emit? hook-emit? !
    ['] usb-emit  hook-emit  !
;

: -usb ( -- )
    ['] serial-key?  hook-key?  !
    ['] serial-key   hook-key   !
    ['] serial-emit? hook-emit? !
    ['] serial-emit  hook-emit  !
;

\ -----------------------------------------------------------------------------
\   Calltrace
\ -----------------------------------------------------------------------------

: ct ( -- )
  cr
  rdepth 0 do
    i hex. i 2+ rpick dup hex. traceinside. cr
  loop
;

: calltrace-irq ( -- ) \ Try your very best to help tracing unhandled interrupt causes...
  cr cr
  unhandled
  cr
  h.s
  cr
  ." Calltrace:" ct
  begin usb-poll again \ Trap execution
;

\ -----------------------------------------------------------------------------
\   USB Initialisation
\ -----------------------------------------------------------------------------

: singletask ( -- ) ['] usb-poll hook-pause ! ;

task: usb-task

: usb-task&
  usb-task activate
  begin
    usb-poll
    pause
  again
;

: init ( -- )
  168mhz
  init-cycles
  init-rng
  ['] calltrace-irq irq-fault !
  usb-init
  multitask usb-task&
  \ singletask
  +usb
;

cornerstone eraseflash
