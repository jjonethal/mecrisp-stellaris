
\ -----------------------------------------------------------------------------
\   Layer for ANS Forth compatibility and coverage
\ -----------------------------------------------------------------------------

\ Caveats, which cannot be rectified for technical reasons:

\   create does> is only possible for compilation into RAM memory.
\   Use <builds does> when compiling into Flash.
\   does> can be applied one time only.

\   Flags like IMMEDIATE need to be placed inside the definitions.
\   In RAM, applying flags is possible in a standard way afterwards,
\   but the RA cores automatically apply INLINE when appropriate. If you
\   also apply IMMEDIATE after the definition is already finalised with ;
\   then this becomes IMMEDIATE+INLINE, which means compile-only.

\   Using flash memory requires thinking twice sometimes.
\   Locations cannot be changed anymore, as many standard Forth tricks
\   are based on the assumption that all memory is writeable multiple times.

\ Caveats, which are not implemented:

\   '*' style numbers will not be recognised.

\ -----------------------------------------------------------------------------

true variable ansification?

: mecrisp-style  ( -- ) false ansification? ! ;
: standard-style ( -- ) true  ansification? ! ;

: variable!   ( n -- ) variable ;
: 2variable2! ( d -- ) 2variable ;

:  variable ( n -- ) ansification? @ if 0  then  variable ;
: 2variable ( d -- ) ansification? @ if 0. then 2variable ;

: invert ( x -- ~x ) not inline 1-foldable ;

: literal ( x -- ) literal, immediate ;

: char+ ( u -- u+1 ) 1+ inline 1-foldable ;
: chars ( u -- u ) inline 0-foldable ;

: >body ( addr -- addr* ) begin dup 2 - h@ $4780 <> while 2 + repeat 1-foldable ;

: .( ( -- ) [char] ) ['] ." $1E + call, parse string, immediate 0-foldable ;

: :noname ( -- addr ) 0 s" : (noname)" evaluate drop here 2 - ;

: 0> ( n -- ? ) 0 > 1-foldable ;

: compile, ( addr -- ) call, ;

: erase ( addr u -- ) 0 fill ;

256 buffer: PAD

: $" ( -- c-addr u ) [char] " parse ;

: sliteral ( c-addr u -- ) ( -- c-addr u ) ['] s" $4 + call, string, immediate ;

\ -----------------------------------------------------------------------------
\  Tools taken from Swapforth by James Bowman
\ -----------------------------------------------------------------------------

\ Divide d1 by n1, giving the symmetric quotient n3 and the remainder n2.
: sm/rem ( d1 n1 -- n2 n3 )
    2dup xor >r     \ combined sign, for quotient
    over >r         \ sign of dividend, for remainder
    abs >r dabs r>
    um/mod          ( remainder quotient )
    swap r> 0< if negate then     \ apply sign to remainder
    swap r> 0< if negate then     \ apply sign to quotient
3-foldable ; 

\ Divide d1 by n1, giving the floored quotient n3 and the remainder n2.
\ Adapted from hForth
: fm/mod ( d1 n1 -- n2 n3 )
    dup >r 2dup xor >r
    >r dabs r@ abs
    um/mod
    r> 0< if
        swap negate swap
    then
    r> 0< if
        negate         \ negative quotient
        over if
            r@ rot - swap 1-
        then
    then
    r> drop
3-foldable ; 

256 buffer: BUF0 \ At least 33 characters required

: word ( c -- c-addr )
    begin
        source >r >in @ + c@ over =
        r> >in @ xor and
    while
        1 >in +!
    repeat

    parse
    dup BUF0 c!
    BUF0 1+ swap move
    BUF0
;

: /string dup >r - swap r> + swap ;

: >number ( ud1 c-addr1 u1 -- ud2 c-addr2 u2 )
    begin
        dup
    while
        over c@ digit
        0= if drop exit then
        >r 2swap base @
        tuck * >r um* r> + \ Inlined Swapforth ud* ( ud1 u -- ud2 )
        r> s>d d+ 2swap
        1 /string
    repeat
;

: within ( n1|u1 n2|u2 n3|u3 -- ? ) over - >r - r> u< ;

: save-input ( -- xn ... x1 n )
    >in @ 1
;

: restore-input ( xn ... x1 n -- ? )
    drop >in !
    true
;

: d.r  ( d n -- )
    >r
    dup >r dabs <# #s r> sign #>
    r> over - spaces type
;

: .r  ( n1 n2 -- )
    >r s>d r> d.r
;

: u.r  ( u n -- )
    0 swap d.r
;

: bounds \ ( a u -- a+u a )
    over + swap
;

: cmove \ ( addr1 addr2 u -- )
    bounds rot >r
    begin
        2dup xor
    while
        r@ c@ over c!
        r> 1+ >r
        1+
    repeat
    r> drop 2drop
;

: cmove> \ ( addr1 addr2 u -- )
    begin
        dup
    while
        1- >r
        over r@ + c@
        over r@ + c!
        r>
    repeat
    drop 2drop
;

: same? ( c-addr1 c-addr2 u -- -1|0|1 )
    bounds ?do
        i c@ over c@ - ?dup if
            0> 2* 1+
            nip unloop exit
        then
        1+
    loop
    drop 0
;

: compare-flag ( caddr-1 len-1 c-addr-2 len-2 -- ? ) compare ;

: ans-compare ( caddr-1 len-1 c-addr-2 len-2 -- n )
    rot 2dup swap - >r          \ ca1 ca2 u2 u1  r: u1-u2
    min same? ?dup
    if r> drop exit then
    r> dup if 0< 2* 1+ then ;
    
: blank 
    bl fill 
;       

: -trailing
    begin   
        2dup + 1- c@ bl =
        over and
    while   
        1-  
    repeat  
;

\ Search the string specified by c-addr1 u1 for the string
\ specified by c-addr2 u2. If flag is true, a match was found
\ at c-addr3 with u3 characters remaining. If flag is false
\ there was no match and c-addr3 is c-addr1 and u3 is u1.

: search ( c-addr1 u1 c-addr2 u2 -- c-addr3 u3 flag )
    dup 0= if   \ special-case zero-length search
        2drop true exit
    then

    2>r 2dup
    begin
        dup
    while
        2dup 2r@            ( c-addr1 u1 c-addr2 u2 )
        rot over min -rot   ( c-addr1 min_u1_u2 c-addr2 u2 )
        compare 0= if
            2swap 2drop 2r> 2drop true exit
        then
        1 /string
    repeat
    2drop 2r> 2drop
    false
;

