
\ From Gerry Jackson on comp.lang.forth

: sm/rem ( d n -- r q ) m/mod inline 3-foldable ;

: fm/mod ( d n -- r q )
   dup >r 2dup xor 0< >r sm/rem
   over r> and if 1- swap r> + swap exit then r> drop
   inline 3-foldable
;
