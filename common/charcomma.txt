
\ Emulate c, which is not available in hardware on some chips.

0 variable c,collection

: c, ( c -- )
  c,collection @ ?dup if $FF and swap 8 lshift or h,
                         0 c,collection !
                      else $100 or c,collection ! then ;

: calign ( -- )
  c,collection @ if 0 c, then ;


( Roman numerals taken from Leo Brodies "Thinking Forth" )

create romans
  (      ones ) char I c,  char V c,
  (      tens ) char X c,  char L c,
  (  hundreds ) char C c,  char D c,
  ( thousands ) char M c,  
  calign

  align   \ In this chip 16 bit writes are emulated internally, too, 
          \ as its Flash controller has 32-bits-at-once write access only.
          \ Aligning on 4 ensures that this is actually written.

0 variable column# ( current_offset )
: ones      0 column# ! ;
: tens      2 column# ! ;
: hundreds  4 column# ! ;
: thousands 6 column# ! ;

: column ( -- address-of-column ) romans column# @ + ;

: .symbol ( offset -- ) column + c@ emit ;
: oner  0 .symbol ;
: fiver 1 .symbol ;
: tener 2 .symbol ;

: oners ( #-of-oners )
  ?dup if 0 do oner loop then ;

: almost ( quotient-of-5 -- )
  oner if tener else fiver then ;

: romandigit ( digit -- )
  5 /mod over 4 = if almost drop else if fiver then oners then ;

: roman ( number -- )
  1000 /mod thousands romandigit
   100 /mod  hundreds romandigit
    10 /mod      tens romandigit
                 ones romandigit ;

: mealtime   19 u<= if
                      ." Fruit salad "
                    else
                      ." Green salad "
                    then
                    ." would be nice !" ;

: mealsforwholeday cr 25 6 do i dup roman ." : " mealtime cr 2 +loop cr ;
mealsforwholeday
