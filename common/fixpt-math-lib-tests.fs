\ =========================================================================
\  File: fixpt-math-lib-tests.fs for Mecrisp-Stellaris by Matthias Koch
\
\  This file contains test functions for the sqrt, trig, log, and power
\  functions in the s31.32 fixed point math library fixpt-math-lib.fs.  See
\  the header in that file for further comments.
\ 
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.04.09
\ =========================================================================

\ #include fixpt-math-lib.fs

\ -------------------------------------------------------------------------
\  Helpers
\ -------------------------------------------------------------------------
\ Round s31.32 value to (approximately) 9 decimal places and display it
: f.r9 ( df -- )  2 0 2over d0< if d- else d+ then 9 f.n ;  
    
\ Same as above, but for 7 decimal places
: f.r7 ( df -- )  215 0 2over d0< if d- else d+ then 7 f.n ; 

: tab ( -- )  9 emit ;

\ -------------------------------------------------------------------------
\  Square root and trig tests
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
  cr -270,000001 2dup f.r7 tan atan tab f.r7   
  cr -269,999999 2dup f.r7 tan atan tab f.r7   
  cr -269,9 2dup f.r7 tan atan tab f.r7   
  cr -180,0 2dup f.r7 tan atan tab f.r7   
  cr -91,0 2dup f.r7 tan atan tab f.r7   
  cr -90,1 2dup f.r7 tan atan tab f.r7   
  cr -90,000001 2dup f.r7 tan atan tab f.r7   
  cr -89,999999 2dup f.r7 tan atan tab f.r7   
  cr -89,9 2dup f.r7 tan atan tab f.r7   
  90 -88 do
    0 i tan atan
    i cr . tab tab f.r7
  2 +loop
  cr 89,9 2dup f.r7 tan atan tab f.r7   
  cr 89,999999 2dup f.r7 tan atan tab f.r7   
  cr 90,000001 2dup f.r7 tan atan tab f.r7   
  cr 90,1 2dup f.r7 tan atan tab f.r7   
  cr 91,0 2dup f.r7 tan atan tab f.r7   
  cr 180,0 2dup f.r7 tan atan tab f.r7   
  cr 269,9 2dup f.r7 tan atan tab f.r7   
  cr 269,999999 2dup f.r7 tan atan tab f.r7   
  cr 270,000001 2dup f.r7 tan atan tab f.r7   
  cr
;

: trig-test3
  cr cr ." x" tab tab ." tan(atan(x))"
  51 0 do
    cr 0 i 2dup f.r7 atan tan tab f.r7
  loop
  1270363336 57
  cr 2dup f.r7 2dup atan tan tab f.r7
  4 0 do
    cr 10,0 f* 2dup f.r7 2dup atan tan tab f.r7
  loop
  2drop
  cr
;

: trig-test4
  cr cr ." x" tab ." asin(sin(x))"
  91 -90 do
    0 i sin asin
    i cr . tab f.r7
  loop
  cr
;

: trig-test5
  cr cr ." x" tab tab ." sin(asin(x))"
  cr 0,0 2dup f.r7 asin sin tab f.r7
  32 1 do
    cr 0,03125 0 i f* 2dup f.r7 asin sin tab f.r7
  loop
  cr 1,0 2dup f.r7 asin sin tab f.r7
  cr
;

: trig-test6
  cr cr ." x" tab ." acos(cos(x))"
  181 0 do
    0 i cos acos
    i cr . tab f.r7
  loop
  cr
;

: trig-test7
  cr cr ." x" tab tab ." cos(acos(x))"
  cr 0,0 2dup f.r7 acos cos tab f.r7
  32 1 do
    cr 0,03125 0 i f* 2dup f.r7 acos cos tab f.r7
  loop
  cr 1,0 2dup f.r7 acos cos tab f.r7
  cr
;

\ -------------------------------------------------------------------------
\  Log and power test functions
\ -------------------------------------------------------------------------
: log2-test1
  cr cr ." x a power of 2" tab tab tab tab tab ." log2(x)"
  0,5
  31 0 do
    dshl 2dup cr f. tab tab 2dup log2 f.r9 
  loop
  1,0
  32 0 do
    dshr 2dup cr f. tab tab 2dup log2 f.r9 
  loop
  cr
;

: log10-test1
  cr cr ." x a power of 10" tab tab tab tab tab ." log10(x)"
  1,0
  2dup cr f. tab tab 2dup log10 f.r9
  9 0 do
    10,0 f* 2dup cr f. tab tab 2dup log10 f.r9 
  loop
  0,1 2dup cr f. tab tab log10 f.r9
  0,01 2dup cr f. tab tab log10 f.r9
  0,001 2dup cr f. tab tab log10 f.r9
  0,0001 2dup cr f. tab tab log10 f.r9
  0,00001 2dup cr f. tab tab log10 f.r9
  0,000001 2dup cr f. tab tab log10 f.r9
  0,0000001 2dup cr f. tab tab log10 f.r9
  0,00000001 2dup cr f. tab tab log10 f.r9
  0,000000001 2dup cr f. tab tab log10 f.r9
  cr
;

: ln-test1
  cr cr ." x a power of 10" tab tab tab tab tab ." ln(x)"
  1,0
  2dup cr f. tab tab 2dup ln f.r9
  9 0 do
    10,0 f* 2dup cr f. tab tab 2dup ln f.r9 
  loop
  0,1 2dup cr f. tab tab ln f.r9
  0,01 2dup cr f. tab tab ln f.r9
  0,001 2dup cr f. tab tab ln f.r9
  0,0001 2dup cr f. tab tab ln f.r9
  0,00001 2dup cr f. tab tab ln f.r9
  0,000001 2dup cr f. tab tab ln f.r9
  0,0000001 2dup cr f. tab tab ln f.r9
  0,00000001 2dup cr f. tab tab ln f.r9
  0,000000001 2dup cr f. tab tab ln f.r9
  cr
;

: pow2-test1
  cr cr ." x " tab tab ." pow2(x)"
  31 -31 do
    0 i 2dup cr f.r9 pow2 f.
    0 i 0,5 d+ 2dup cr f.r9 pow2 f.
  loop
  cr
;

: exp-test1
  cr cr ." x " tab tab ." exp(x)"
  22 -22 do
    0 i 2dup cr f.r9 exp f.
    0 i 0,5 d+ 2dup cr f.r9 exp f.
  loop
  cr
;

: pow10-test1
  cr cr ." x " tab tab ." pow10(x)"
  10 -9 do
    0 i 2dup cr f.r9 pow10 f.
    0 i 0,5 d+ 2dup cr f.r9 pow10 f.
  loop
  cr
;

: pow2oflog2-test1
  cr cr ." x a power of 2" tab tab tab ." 2^(log2(x))"
  0,5
  31 0 do
    dshl 2dup cr f.r9 tab tab 2dup log2 pow2 f.r9 
  loop
  1,0
  32 0 do
    dshr 2dup cr f. tab tab 2dup log2 pow2 f. 
  loop
  cr
;

: log2ofpow2-test1
  cr cr ." x" tab tab ." log2(2^x)"
  -31,999 2dup cr f.r9 tab pow2 log2 f.r9
  31 -31 do
    0 i 2dup cr f.r9 tab pow2 log2 f.r9
    0 i 0,5 d+ 2dup cr f.r9 tab pow2 log2 f.r9
  loop
  30,999 2dup cr f.r9 tab pow2 log2 f.r9
  cr
;

: pow10oflog10-test1
  cr cr ." x a power of 10" tab tab tab tab tab ." 10^(log10(x))"
  1,0
  2dup cr f. tab tab 2dup log10 pow10 f.r9
  9 0 do
    10,0 f* 2dup cr f. tab tab 2dup log10 pow10 f.r9 
  loop
  0,1 2dup cr f. tab tab log10 pow10 f.
  0,01 2dup cr f. tab tab log10 pow10 f.
  0,001 2dup cr f. tab tab log10 pow10 f.
  0,0001 2dup cr f. tab tab log10 pow10 f.
  0,00001 2dup cr f. tab tab log10 pow10 f.
  0,000001 2dup cr f. tab tab log10 pow10 f.
  0,0000001 2dup cr f. tab tab log10 pow10 f.
  0,00000001 2dup cr f. tab tab log10 pow10 f.
  0,000000001 2dup cr f. tab tab log10 pow10 f.
  cr
;

: log10ofpow10-test1
  cr cr ." x" tab tab ." log10(10^x)"
  9 -9 do
    0 i 2dup cr f.r9 tab pow10 log10 f.r9
    0 i 0,25 d+ 2dup cr f.r9 tab pow10 log10 f.r9
  loop
  cr
;

: expofln-test1
  cr cr ." x a power of 2" tab tab tab ." exp(ln(x))"
  0,5
  31 0 do
    dshl 2dup cr f.r9 tab tab 2dup ln exp f.r9 
  loop
  1,0
  32 0 do
    dshr 2dup cr f. tab tab 2dup ln exp f. 
  loop
  cr
;

: expofln-test2
  cr cr ." x a power of 10" tab tab tab tab tab ." exp(ln(x))"
  1,0
  2dup cr f. tab tab 2dup ln exp f.r9
  9 0 do
    10,0 f* 2dup cr f. tab tab 2dup ln exp f.r9 
  loop
  0,1 2dup cr f. tab tab ln exp f.
  0,01 2dup cr f. tab tab ln exp f.
  0,001 2dup cr f. tab tab ln exp f.
  0,0001 2dup cr f. tab tab ln exp f.
  0,00001 2dup cr f. tab tab ln exp f.
  0,000001 2dup cr f. tab tab ln exp f.
  0,0000001 2dup cr f. tab tab ln exp f.
  0,00000001 2dup cr f. tab tab ln exp f.
  0,000000001 2dup cr f. tab tab ln exp f.
  cr
;

: lnofexp-test1
  cr cr ." x" tab tab ." ln(exp(x))"
  20 -22 do
    0 i 2dup cr f.r9 tab exp ln f.r9
    0 i 0,5 d+ 2dup cr f.r9 tab exp ln f.r9
  loop
  cr
;

\ -------------------------------------------------------------------------


