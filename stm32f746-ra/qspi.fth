\ qspi.fth
\ N25Q128A13EF840E

\ require util.fth
\ require gpio.fth

\ QSPI_NCS - PB6  - AF10
\ QSPI_CLK - PB2  - AF9
\ QSPI_D0  - PD11 - AF9
\ QSPI_D1  - PD12 - AF9
\ QSPI_D2  - PE2  - AF9
\ QSPI_D3  - PD13 - AF9

\ ********** qspi driver io ports *******   
 #1 GPIO    constant GPIOB
 #3 GPIO    constant GPIOD
 #4 GPIO    constant GPIOE
 #2 GPIOB + constant PB2
 #6 GPIOB + constant PB6
#11 GPIOD + constant PD11
#12 GPIOD + constant PD12
#13 GPIOD + constant PD13
 #2 GPIOE + constant PE2

PB6  constant QSPI_NCS 
PB2  constant QSPI_CLK 
PD11 constant QSPI_D0
PD12 constant QSPI_D1
PE2  constant QSPI_D2
PD13 constant QSPI_D3

#10 constant AF10
 #9 constant AF9
: qspi-gpio-init-hw ( -- )
   AF10 QSPI_NCS gpio-mode-af! 
   AF9  QSPI_CLK gpio-mode-af!
   AF9  QSPI_D0  gpio-mode-af!
   AF9  QSPI_D1  gpio-mode-af!
   AF9  QSPI_D2  gpio-mode-af!
   AF9  QSPI_D3  gpio-mode-af! ;
: qspi-gpio-init-sw ( -- )
   QSPI_NCS 1 gpio-mode!
   QSPI_CLK 1 gpio-mode!
   QSPI_D0  1 gpio-mode!
   QSPI_D1  1 gpio-mode! 
   QSPI_D2  1 gpio-mode!
   QSPI_D3  1 gpio-mode! ;
: pin-off  ( pin -- m a )                \ generate pin of mask and bsrr address
   dup bsrr-off swap gpio-bsrr 1-foldable ;
: pin-on  ( pin -- m a )                 \ generate pin of mask and bsrr address
   dup bsrr-on swap gpio-bsrr 1-foldable ;
: pin-onff  ( pin -- m )                 \ pin-on but address and mask swapped
   bsrr-on dup #16 lshift or 1-foldable ;
: pin-in  ( pin -- m a )                 \ generate pin input mask and address
   dup pin# 2^ swap gpio-idr ;
: on-off ( f -- n ) 0= #16 and 1-foldable inline ;
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

: q-cs@  ( -- f )                        \ get qspi chip select
   QSPI_NCS pin# 2^ QSPI_NCS gpio-idr bit@ ;
: q-ck@  ( -- f )                        \ get qspi clock line
   QSPI_CLK pin# 2^ QSPI_CLK gpio-idr bit@ ;
: q-d0@  ( -- f )                        \ get qspi D0 line
   QSPI_D0 pin# 2^ QSPI_D0 gpio-idr bit@ ;
: q-d1@  ( -- f )                        \ get qspi D1 line
   QSPI_D1 pin# 2^ QSPI_D1 gpio-idr bit@ ;
: q-d2@  ( -- f )                        \ get qspi D2 line
   QSPI_D2 pin# 2^ QSPI_D2 gpio-idr bit@ ;
: q-d3@  ( -- f )                        \ get qspi D3 line
   QSPI_D3 pin# 2^ QSPI_D3 gpio-idr bit@ ;

: q-cs!  ( f -- )                        \ set qspi chip select
   0= $FFFF xor QSPI_NCS pin-onff and QSPI_NCS gpio-bsrr ! ;
: q-ck!  ( f -- )                        \ set qspi clock line
   0= $FFFF xor QSPI_CLK pin-onff and QSPI_CLK gpio-bsrr ! ;
: q-d0!  ( f -- )                        \ set qspi D0 line
   0= $FFFF xor QSPI_D0 pin-onff and QSPI_D0 gpio-bsrr ! ;
: q-d1!  ( f -- )                        \ set qspi D1 line
   0= $FFFF xor QSPI_D1 pin-onff and QSPI_D1 gpio-bsrr ! ;
: q-d2!  ( f -- )                        \ set qspi D2 line
   0= $FFFF xor QSPI_D2 pin-onff and QSPI_D2 gpio-bsrr ! ;
: q-d3!  ( f -- )                        \ set qspi D3 line
   0= $FFFF xor QSPI_D3 pin-onff and QSPI_D3 gpio-bsrr ! ;

: q-set-mode-bb1  ( -- )                 \ setup gpio ports for one wire bit bang spi mode
   q-cs-1 QSPI_NCS gpio-output
   q-ck-0 QSPI_CLK gpio-output
   q-d0-0 QSPI_D0  gpio-output 
   q-d1-1 QSPI_D1  gpio-input
   q-d2-1 QSPI_D2  gpio-output           \  /W    - no write protect
   q-d3-1 QSPI_D3  gpio-output ;         \  /HOLD - no hold 
: q-set-mode-bb2-input ( -- )            \ dual input mode
   QSPI_D0  gpio-input
   QSPI_D1  gpio-input
   q-d2-1 QSPI_D2  gpio-output           \  /W    - no write protect
   q-d3-1 QSPI_D3  gpio-output ;         \  /HOLD - no hold 
: q-set-mode-bb2-output ( -- )           \ dual output mode
   QSPI_D0  gpio-output
   QSPI_D1  gpio-output
   q-d2-1 QSPI_D2  gpio-output           \  /W    - no write protect
   q-d3-1 QSPI_D3  gpio-output ;         \  /HOLD - no hold 
: q-set-mode-bb2-init ( -- )             \ dual init output mode
   q-cs-1 QSPI_NCS gpio-output
   q-ck-0 QSPI_CLK gpio-output
   q-d0-0 q-d1-0
   q-set-mode-bb2-output ;               \  /HOLD - no hold 
: q-set-mode-bb4-input ( -- )            \ quad input mode
   QSPI_D0  gpio-input
   QSPI_D1  gpio-input
   QSPI_D2  gpio-input
   QSPI_D3  gpio-input ;
: q-set-mode-bb4-output ( -- )           \ quad output mode
   QSPI_D0  gpio-output
   QSPI_D1  gpio-output
   QSPI_D2  gpio-output
   QSPI_D3  gpio-output ;
: q-set-mode-bb4-init ( -- )             \ quad init mode
   q-cs-1 QSPI_NCS gpio-output
   q-ck-0 QSPI_CLK gpio-output
   q-d0-0 q-d1-0 q-d2-0 q-d3-0
   q-set-mode-bb4-output ;
: q-bb1-idle ( -- )                      \ set bit bang spi protocol to idle 
   q-cs-1 q-ck-0 q-d0-0 q-d1-1
   q-d2-1 q-d3-1 ;
: q-bb1-delay  ( ) ;                     \ add some delay to garanty clock timing
: q-bb1-f! ( c -- c )                    \ send a bit 
   q-ck-0 dup $80 and q-d0! q-bb1-delay
   q-ck-1 q-bb1-delay 2* ;
: q-bb1-f@ ( c -- c )                    \ receive bit shift in a bit into a character
   q-ck-0 q-bb1-delay 2* q-d1@ 1 and or
   q-bb1-delay q-ck-1 ;
: q-bb1-c! ( c -- )                      \ transmit 1 byte in spi mode
   q-bb1-f! q-bb1-f! q-bb1-f! q-bb1-f!
   q-bb1-f! q-bb1-f! q-bb1-f! q-bb1-f!
   drop ;
: q-bb1-c@ ( c -- )                      \ receive 1 byte in spi mode
   0 q-bb1-f@ q-bb1-f@ q-bb1-f@ q-bb1-f@
   q-bb1-f@ q-bb1-f@ q-bb1-f@ q-bb1-f@ ;
: q-bb2-ff! ( c -- c )                   \ write 2 flags in dual mode shift tos by 2 
   q-ck-0
   dup $80 and q-d1!
   dup $40 and q-d0! q-bb1-delay
   q-ck-1 q-bb1-delay 2 lshift ;
: q-bb2-ff@  ( c -- c )                  \ read 2 bits via dual bitbang
   q-ck-0 q-bb1-delay 2 lshift
   q-d1@ 2 and or
   q-d0@ 1 and or
   q-bb1-delay q-ck-1 ;
: q-bb2-c! ( c -- )                      \ write character as bitbang dual mode
   q-bb2-ff! q-bb2-ff!
   q-bb2-ff! q-bb2-ff! drop ;
: q-bb2-c@ ( -- c )                      \ read character as bitbang dual mode
   0
   q-bb2-ff@ q-bb2-ff@
   q-bb2-ff@ q-bb2-ff@ ;
: q-bb4-ffff! ( c -- c )                 \ write 4 flags in quad mode shift tos left by 4 
   q-ck-0
   dup $80 and q-d3!
   dup $40 and q-d2!
   dup $20 and q-d1!
   dup $10 and q-d0!
   q-bb1-delay
   q-ck-1 q-bb1-delay #4 lshift ;
: q-bb4-ffff@  ( c -- c )                \ read 2 bits via dual bitbang
   q-ck-0 q-bb1-delay #4 lshift
   q-d3@ 8 and or
   q-d2@ 4 and or
   q-d1@ 2 and or
   q-d0@ 1 and or
   q-bb1-delay q-ck-1 ;
: q-bb4-c! ( c -- )                      \ write character as bitbang dual mode
   q-bb4-ffff! q-bb4-ffff! drop ;
: q-bb4-c@ ( -- c )                      \ read character as bitbang dual mode
   0
   q-bb4-ffff@ q-bb4-ffff@ ;
: q-bb1-start  ( -- )                    \ start spi transfer
   q-set-mode-bb1 q-cs-0 ;
: q-bb1-read-id  ( -- )                  \ output device id to terminal
   q-bb1-start $9E q-bb1-c!
   #20 0 do q-bb1-c@ x.2 space loop q-cs-1 ;
: q-bb1-adr!  ( a -- )                   \ send 24 bit address
   dup #16 lshift q-bb1-c!
   dup  #8 lshift q-bb1-c!
                  q-bb1-c! ;   
: q-bb1-@  ( a -- n )                    \ read a word from qspi memory from address a
   q-bb1-start $03 q-bb1-c!
   q-bb1-adr! q-bb1-c@ q-bb1-c@ #8 lshift or 
   q-bb1-c@ #16 lshift or q-bb1-c@ #24 lshift or q-cs-1 ;
: q-bb1-read ( l a qa -- )               \ read memory block length l from qspi address qa to destination ram a
   q-bb1-start $03 q-bb1-c!
   q-bb1-adr! tuck + swap
   ?do q-bb1-c@ i c! loop q-cs-1 ;
: q-bb1-write-enable ( -- )              \ send write enable
   q-bb1-start $06 q-bb1-c! q-cs-1 ;
: q-bb1-erase-sub-sector ( a -- )        \ erase subsector at qspi adr a , write enable must vbe sent before
   q-bb1-start $20 q-bb1-c!
   q-bb1-adr! q-cs-1 ;
: q-bb1-write ( l a qa -- )              \ write memory block length l from qspi address qa to destination ram a
   q-bb1-start $02 q-bb1-c!              \ write enable must be sent before
   q-bb1-adr! tuck + swap
   ?do i c@ q-bb1-c! loop q-cs-1 ;
: q-dummy ( -- ) dup drop ;              \ dummy place holder
' q-bb1-c@ variable q-c@-hook            \ read char from qspi hook
' q-bb1-c! variable q-c!-hook            \ write char to qspi hook
' q-bb1-c@ variable q->-hook             \ qspi ouput mode hook
' q-bb1-c! variable q-<-hook             \ qspi input mode hook
' q-bb1-c! variable q-start-hook         \ qspi start hook
' q-bb1-c! variable q-stop-hook          \ qspi stop hook
' q-set-mode-bb1-output variable q-init-hook          \ qspi init hook
: q-bb1-# ( -- )                         \ set bitbang single mode
  ['] q-bb1-c!              q-c!-hook !
  ['] q-bb1-c@              q-c@-hook !
  ['] q-cs-0                q-start-hook ! 
  ['] q-cs-1                q-stop-hook ! 
  ['] q-dummy               q-<-hook ! 
  ['] q-dummy               q->-hook ! 
  ['] q-set-mode-bb1-output q-init-hook ! ;
: q-bb2-# ( -- )                         \ set bitbang dual mode
  ['] q-bb2-c!              q-c!-hook !
  ['] q-bb2-c@              q-c@-hook !
  ['] q-cs-0                q-start-hook ! 
  ['] q-cs-1                q-stop-hook ! 
  ['] q-set-mode-bb2-input  q-<-hook ! 
  ['] q-set-mode-bb2-output q->-hook ! 
  ['] q-set-mode-bb2-init   q-init-hook ! ;
: q-bb4-# ( -- )                         \ set bitbang quad mode
  ['] q-bb4-c!              q-c!-hook !
  ['] q-bb4-c@              q-c@-hook !
  ['] q-cs-0                q-start-hook ! 
  ['] q-cs-1                q-stop-hook ! 
  ['] q-set-mode-bb4-input  q-<-hook ! 
  ['] q-set-mode-bb4-output q->-hook ! 
  ['] q-set-mode-bb4-init   q-init-hook ! ;

  
: q-bb1< ( -- )                          \ set bitbang single mode input
   q-set-mode-bb1-input ;
: q-bb2> ( -- )                          \ set bitbang dual mode output
   ['] q-bb2-c! q-c!-hook !
   q-set-mode-bb2-output ;
: q-bb2< ( -- )                          \ set bitbang dual mode input
   ['] q-bb2-c@ q-c@-hook !
   q-set-mode-bb2-input ;
: q-bb4> ( -- )                          \ set bitbang quad mode output
   ['] q-bb4-c! q-c!-hook !
   q-set-mode-bb4-output ;
: q-bb4< ( -- )                          \ set bitbang quad mode input
   ['] q-bb4-c@ q-c@-hook !
   q-set-mode-bb4-input ;
: q-c@ ( -- c )                          \ read character from qspi bus
   q-c@-hook @ execute ;
: q-c! ( c -- )                          \ write character to qspi bus
   q-c!-hook @ execute ;
: q-start ( -- )                         \ initiate qspi transfer start
   q-start-hook @ execute ;
: q-stop ( -- )                          \ initiate qspi transfer start
   q-stop-hook @ execute ;
: q->  ( -- )                            \ output-mode
   q->-hook @ execute ;
: q-<  ( -- )                            \ input-mode
   q-<-hook @ execute ;
: q-init  ( -- )                         \ initialize ports
   q-init-hook @ execute ;
: q-adr!  ( a -- )                       \ send 24 bit address
   dup #16 lshift q-c!
   dup  #8 lshift q-c!
                  q-c! ;   

: q-@ ( a -- n )                         \ mode must be set to output before
   q-init q-start $03 q-c!
   q-adr! q-< q-c@ q-c@ #8 lshift or 
   q-c@ #16 lshift or q-c@ #24 lshift or q-stop q-> ;
: q-read ( l a qa -- )                   \ read memory block length l from qspi address qa to destination ram a
   q-init q-start $03 q-c!
   q-adr! q-< tuck + swap
   ?do q-c@ i c! loop q-stop q-> ;
: q-send-cmd ( c -- )                    \ send single byte command
   q-init q-start q-c! q-stop q-> ;
: q-write-enable ( -- )                  \ send write enable
   $06 q-send-cmd ;
: q-write-disable ( -- )                 \ send write disable
   $04 q-send-cmd ;
: q-erase-sub-sector ( a -- )            \ erase subsector at qspi adr a , write enable must vbe sent before
   q-init q-start $20 q-c!
   q-adr! q-stop q-> ;
: q-write ( l a qa -- )                  \ write memory block length l from qspi address qa to destination ram a
   q-init q-start $02 q-c!               \ write enable must be sent before
   q-adr! tuck + swap
   ?do i c@ q-c! loop q-stop q-> ;
