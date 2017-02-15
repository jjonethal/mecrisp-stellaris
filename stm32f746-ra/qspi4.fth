
: swap-bytes ( w -- w )                  \ swap byte order ( 1234 -- 4321 )
   dup #24 rshift $ff and                \ b3
   over #8 rshift $ff00 and or           \ b2,b3
   over $ff00 and #8 lshift or           \ b1,b2,b3
   swap $ff and #24 lshift or ;          \ b0,b1,b2,b3

: qc>! ( c -- )                          \ output 8 bit on qspi 
   #24 lshift qc> drop ;
: qa>! ( a24 -- )                        \ output 24 bit address on qspi 
   #8 lshift qc> qc> qc> drop ;
: qc<@ ( -- c )                          \ read 1 byte from qspi
   0 qc< ;
: q<@  ( -- w )                          \ read 1 word from qspi
   0 qc< qc< qc< qc< ;
: q-read ( n da qa -- )                  \ read n bytes to destination da from qspi address qa
   q-start $03 qc>! qa>!
   q<<
   tuck + swap ?do qc<@ i ! loop
   q-stop q>> ;
: qc@  ( qa -- c )                       \ read 8 bit from qspi
   q-start $03 qc>! qa>!
   q<< qc<@ q-stop q>> ;
: qc!  ( c qa -- )                       \ write 8 bit to qspi
   q-idle-wait
   q-write-ena
   q-start $02 qc>! qa>!
   qc>! q-stop ;
: q@  ( qa -- w )                        \ read 1 word from qspi
   q-start $03 qc>! qa>!
   q<< q<@ q-stop q>> ;
: q!  ( w qa -- w )                      \ write 1 word to qspi
   q-idle-wait
   q-write-ena
   q-start $02 qc>! qa>!
   qc> qc> qc> qc> drop q-stop ;

\ s c s a s nw - single mode command , single mode address , single mode n byte write
\ d c d a d nr - dual   mode command , dual   mode address , dual   mode n byte read
\ s c s p      - single mode command , single mode param 

