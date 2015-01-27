\ Miscellaneous nuggets

: spaces 0 ?do space loop ;
: invert  not  inline 1-foldable ;

: count dup c@ ; ( cstr-addr -- cstr-addr count )

: octal 8 base ! ;
: sqr ( n -- n^2 ) dup * 1-foldable ;
: star 42 emit ;


