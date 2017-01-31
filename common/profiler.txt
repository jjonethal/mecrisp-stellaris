
\ A profiler to count calls to all colon definitions compiled after this code.

: codestart>link ( addr -- addr* )
  >r
  
  dictionarystart 
  begin
    dup 6 + count + even r@ = if rdrop exit then
    dictionarynext
  until
  drop
    
  r> \ Not found ? Then give back the address which we had searched for.
  ."  Could not find header for code start address " hex. ." in dictionary." cr quit
;

: link>codestart ( addr -- addr* )
  6 + count + even
;


  \ Link is -1 or 0 ? This is end of dictionary.  
  \ Link is higher than current address ? Flash.
  \ Link is lower  than current address ? RAM.    
  
: dictionarybefore ( addr -- addr* ) \ Get one older definition, if possible. Complicated, as link may be set in both ways.
  
  dup dictionarynext nip 0= \ Check if end of link chain is reached to not break idea of u>. Unset links can have different values depending on target !
  if     
    dup dup @ ( Current Current Next ) u> if @ exit then \ RAM
  then
  
  >r \ Flash.
  dictionarystart 
  begin    
    r@ over dictionarynext drop = if rdrop exit then \ Found ? Give back the definition before.
    dictionarynext
  until
  drop    
  r> \ Not found ? Then give back the address which we had searched for. 
;

: .p ( -- ) \ Parses name, and tries to find counter variable associated to it.
  ' codestart>link dictionarybefore      
  dup 6 + count s" (cnt)" compare if link>codestart execute @ u. else drop ." No counter for this definition" then 
  cr
;

: profile ( -- ) \ Print a complete profile. Check all definitions available if they have a counter.
  cr
  dictionarystart 
  begin
  
    dup dictionarybefore dup 6 + count s" (cnt)" compare
    if
      over hex.
      link>codestart execute @ hex.
      dup 6 + ctype space
      cr
    else 
      drop
    then

    dictionarynext
  until
  drop
;

\ A new colon:

: : ( -- )
  s" 0 variable (cnt)" evaluate  \ Create a counter variable for each new colon definition
  :                               \ Start a new definition, switch to compile state
  s" 1 (cnt) +!" evaluate          \ Postpone the increment of the freshly created variable
;

\ Profile data for all definitions from now on will be collected.

