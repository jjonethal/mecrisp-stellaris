\ newqspi.fth
\ require gpio.fth

\ ***** commonly used utility ***********
: swap-bytes ( w -- w )                  \ swap byte order ( 1234 -- 4321 )
   dup #24 rshift $ff and                \ b3
   over #8 rshift $ff00 and or           \ b2,b3
   over $ff00 and #8 lshift or           \ b1,b2,b3
   swap $ff and #24 lshift or ;          \ b0,b1,b2,b3
: gpio-<#a ( pin -- m a )                \ return gpio input mask and address
   pin# 2^ swap
   port-base $10 or 1-foldable ;
: hh/l# ( f -- m ) 0= $FFFF xor          \ Mask high/low half word low 0:$ffff0000 1:0000FFFF
   1-foldable ;
: pin-10# ( pin -- m )                   \ pin on / off mask
   bsrr-on dup 16 lshift or 1-foldable ;
: msb<< ( w -- w f )                     \ get msb bit and shift left word by 1 bit
   dup 2* swap 0< 1-foldable ;

PB6  constant QSPI_NCS 
PB2  constant QSPI_CLK 
PD11 constant QSPI_D0
PD12 constant QSPI_D1
PE2  constant QSPI_D2
PD13 constant QSPI_D3

\ ***** single line bit set/reset *******
: q-cs-0  ( -- )  QSPI_NCS pin-off ! ;   \ qspi chip select 0
: q-cs-1  ( -- )  QSPI_NCS pin-on  ! ;   \ qspi chip select 1
: q-ck-0  ( -- )  QSPI_CLK pin-off ! ;   \ qspi clock line 0
: q-ck-1  ( -- )  QSPI_CLK pin-on  ! ;   \ qspi clock line 1
: q-d0-0  ( -- )  QSPI_D0  pin-off ! ;   \ qspi D0 line 0
: q-d0-1  ( -- )  QSPI_D0  pin-on  ! ;   \ qspi D0 line 1
: q-d1-0  ( -- )  QSPI_D1  pin-off ! ;   \ qspi D1 line 0
: q-d1-1  ( -- )  QSPI_D1  pin-on  ! ;   \ qspi D1 line 1
: q-d2-0  ( -- )  QSPI_D2  pin-off ! ;   \ qspi D2 line 0
: q-d2-1  ( -- )  QSPI_D2  pin-on  ! ;   \ qspi D2 line 1
: q-d3-0  ( -- )  QSPI_D3  pin-off ! ;   \ qspi D3 line 0
: q-d3-1  ( -- )  QSPI_D3  pin-on  ! ;   \ qspi D3 line 1

\ ***** query qspi pins *****************
: q-cs@  ( -- f )                        \ get qspi chip select
   QSPI_NCS gpio-<#a bit@ ;
: q-ck@  ( -- f )                        \ get qspi clock line
   QSPI_CLK gpio-<#a bit@ ;
: q-d0@  ( -- f )                        \ get qspi D0 line
   QSPI_D0  gpio-<#a bit@ ;
: q-d1@  ( -- f )                        \ get qspi D1 line
   QSPI_D1  gpio-<#a bit@ ;
: q-d2@  ( -- f )                        \ get qspi D2 line
   QSPI_D2  gpio-<#a bit@ ;
: q-d3@  ( -- f )                        \ get qspi D3 line
   QSPI_D3  gpio-<#a bit@ ;

\ ***** set qspi pins *******************
: q-d0!  ( f -- )                        \ set qspi d0 line
   hh/l# QSPI_D0 pin-10# and QSPI_D0 gpio-bsrr !  ;
: q-d1!  ( f -- )                        \ set qspi d1 line
   hh/l# QSPI_D1 pin-10# and QSPI_D1 gpio-bsrr !  ;
: q-d2!  ( f -- )                        \ set qspi d2 line
   hh/l# QSPI_D2 pin-10# and QSPI_D2 gpio-bsrr !  ;
: q-d3!  ( f -- )                        \ set qspi d3 line
   hh/l# QSPI_D3 pin-10# and QSPI_D3 gpio-bsrr !  ;

\ ***** qspi mode hooks *****************
0 variable 'qc>                          \ '( w -- w ) hook - send 8 bit msb over qspi 
0 variable 'qc<                          \ '( w -- w ) hook - receive 8 bit over qspi


\ ********** single mode spi ************
: q1b> ( w -- w )                        \ shift out one bit single mode
  q-ck-0 msb<< q-d0!                     \ c shift left by one
  q-delay q-ck-1 q-delay ;               \ leave qck high
: q1b< ( w -- w )                        \ shift in one bit single mode
  q-ck-0 2* q-delay q-d1@ 1 and or       \ w shift left by one
  q-ck-1 q-delay 2* ;                    \ leave qck high
: q1-c> ( w -- w )                       \ shift out one byte msb first single mode
   q1b> q1b> q1b> q1b>
   q1b> q1b> q1b> q1b> ;

\ ********** dual mode spi d0/d1 ********
: q2b> ( w -- w )                        \ shift out 2 bit dual mode
  q-ck-0
  msb<< q-d1! msb<< q-d0!                \ msb lsb
  q-delay        
  q-ck-1 q-delay ;                       \ leave qck high
: q2b< ( w -- w )                        \ shift in 2 bit dual mode
  qck-0  q-delay
  2* q-d1-@ 1 and or                     \ w shift left by one
  2* q-d0-@ 1 and or                     \ w shift left by one
  qck-1 q-delay ;                        \ leave qck high
: q2-c> ( w -- w )                       \ shift out one byte msb first dual mode
   q2b> q2b> q2b> q2b> ;

\ ********** quad mode spi d3..d0 *******
: q4b> ( w -- w )                        \ shift out 4 bit quad mode
  q-ck-0
  msb<< q-d3! msb<< q-d2!                \ msb lsb
  msb<< q-d1! msb<< q-d0!                \ msb lsb
  q-delay        
  q-ck-1 q-delay ;                       \ leave qck high
: q4b< ( w -- w )                        \ shift in 4 bit quad mode
  qck-0  q-delay
  2* q-d3-@ 1 and or                     \ w shift left by one
  2* q-d2-@ 1 and or                     \ w shift left by one
  2* q-d1-@ 1 and or                     \ w shift left by one
  2* q-d0-@ 1 and or                     \ w shift left by one
  qck-1 q-delay ;                        \ leave qck high
: q4-c> ( w -- w )                       \ shift out one byte msb first quad mode
   q4b> q4b> ;

\ ***** qspi common words ***************
: q-start ( -- )  q-cs-0 ;               \ start qspi transfer
: q-stop  ( -- )  q-cs-1 ;               \ end of qspi transfer
: q-c> ( w -- w )                        \ send msb byte over spi 
   'qc> @ execute ;
: q-c! ( c -- )                          \ send single byte
  #24 lshift q-c> drop ;
: q-a>  ( a -- )                         \ send 24 bit address msb first
   #8 lshift q-c> q-c> q-c> drop ;
: q-wr-ena ( -- )
   q-start $6 q-c! q-stop ;
: q! ( n a -- )                          \ write a value to qspi memory
   q-idle-wait
   q-wr-ena
   q-start $02 q-c! q-a>
   swap-bytes                            \ reverse byte order of n 
   q-c> q-c> q-c> q-c> drop q-stop ;  
: q@ ( a -- n )                          \ retrieve a value from qspi memory
   ;
: q1 ( -- )                              \ single mode
  ;
: q2 ( -- )                              \ dual mode
  ;
: q4 ( -- )                              \ quad mode