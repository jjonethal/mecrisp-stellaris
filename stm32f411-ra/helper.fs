: mask! ( value mask addr -- ) -rot tuck and swap rot tuck @ swap not and rot or swap ! ;

\ Generate a bitmask with just the $n-th bit set
: bit ( n -- mask ) 1 swap lshift 1-foldable ;

\ Check if a specific bit is set
: bit? ( value bit -- ? ) rshift 1 and negate 2-foldable inline ;

\ Reverse the bit order (not the byte order)
: rbit ( x -- x' ) [ $f6a6fa96 , ] 1-foldable inline ; \ RBIT rTOS, rTOS

\ Helper to convert a bit index and word address to the corresponding bit banding address.
: >bit-band ( bit word-addr -- bit-addr ) dup $F0000000 and $2000000 + swap $FFFFF and 5 lshift + swap cells + 2-foldable ;

\ Expand x1 to into bitfield [high:low]
: >bits ( x1 high low -- x2 )
    swap 31 and swap 31 and
    tuck - 1+ -1 swap lshift rot swap bic swap lshift 3-foldable ;

\ Expand x2 into bitfield [high:low] and combine with x1 through bitwise or
: +bits ( x1 x2 high low -- x3 ) >bits or 4-foldable ;
