\ Small examples for all targets

: invert  not  inline 1-foldable ;
: octal 8 base ! ;
: sqr ( n -- n^2 ) dup * 1-foldable ;
: star 42 emit ; 

: table   cr 11 1 do
                    11 1 do i j * . loop
                    cr
                  loop ;
table
