
\ Calculate Bitlog and Bitexp - close relatives to logarithm and exponent to base 2.

: bitlog ( u -- u )

 \ Invented by Tom Lehman at Invivo Research, Inc., ca. 1990
 \ Gives an integer analog of the log function
 \ For large x, B(x) = 8*(log(base 2)(x) - 1)

  dup 8 u<= if 1 lshift 
            else 
              ( u )
              30 over clz - 3 lshift 
              ( u s1 )
              swap 
              ( s1 u ) 
              28 over clz - rshift 7 and
              ( s1 s2 ) + 
            then 

  1-foldable ;


: bitexp ( u -- u )
    
  \ Returns an integer value equivalent to
  \ the exponential. For numbers > 16,
  \ bitexp(x) approx = 2^(x/8 + 1)

  \ B(E(x)) = x for 16 <= x <= 247.

  dup 247 u>  \ Overflow ?
  if drop $F0000000
  else

    dup 16 u<= if 1 rshift
               else
                 dup ( u u )
                 7 and 8 or ( u b )
                 swap ( b u )
                 3 rshift 2 - lshift
               then

  then 

  1-foldable ;

