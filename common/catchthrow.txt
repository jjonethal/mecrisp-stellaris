
\ -----------------------------------------------------------------------------
\  Catch & Throw without multitasking framework
\ -----------------------------------------------------------------------------

0 variable handler

: catch ( x1 .. xn xt -- y1 .. yn throwcode / z1 .. zm 0 )
    [ $B430 h, ]  \ push { r4  r5 } to save I and I'
    sp@ >r handler @ >r rp@ handler !  execute
    r> handler !  rdrop  0 unloop ;

: throw ( throwcode -- )  dup IF
    \ handler @ 0= IF false task-state ! THEN \ unhandled error: stop task
    handler @ rp! r> handler ! r> swap >r sp! drop r>
    UNLOOP  EXIT
    ELSE  drop  THEN ;


\ -----------------------------------------------------------------------------
\  Example from https://www.taygeta.com/forth/dpansa9.htm#A.9.6.1.2275
\ -----------------------------------------------------------------------------

: could-fail ( -- char )
    KEY DUP [CHAR] Q =  IF  1 THROW THEN ;

: do-it ( a b -- c)   2DROP could-fail ;

: try-it ( --)
    1 2 ['] do-it  CATCH  IF ( x1 x2 )
        2DROP ." There was an exception" CR
    ELSE ." The character was " EMIT CR
    THEN
;

: retry-it ( -- )
    BEGIN  1 2 ['] do-it CATCH  WHILE
       ( x1 x2) 2DROP  ." Exception, keep trying" CR
    REPEAT ( char )
    ." The character was " EMIT CR
;

