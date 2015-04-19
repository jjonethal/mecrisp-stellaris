\ #######   RANDOM   ##########################################

\ setseed   sets the random number seed
\ random    returns a random 32-bit number
\
\ based on "Xorshift RNGs" by George Marsaglia
\ http://www.jstatsoft.org/v08/i14/paper

$7a92764b variable seed

: setseed   ( u -- )
    dup 0= or       \ map 0 to -1
    seed !
;

: random    ( -- u )
    seed @
    dup 13 lshift xor
    dup 17 rshift xor
    dup 5  lshift xor
    dup seed !
    57947 *
;

: randrange  ( u0 -- u1 ) \ u1 is a random number less than u0
    random um* nip
;

 
