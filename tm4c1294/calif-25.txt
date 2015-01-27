
\ Fine tuning clock calibration for a precise frequency source
\ done in Forth for 100 kHz frequency output
\   needs basisdefinitions.txt and pll.txt

: led-on ( -- ) led-1 portn_data ! inline ;
: led-off ( -- )    0 portn_data ! inline ;

$E000E010 constant Systick-CTRL
$E000E014 constant Systick-RELOAD
$E000E018 constant Systick-CURRENT

0 variable tick  \ Zähler
0 variable tack  \ Überlaufwert

248 constant ticks-slow
249 constant ticks-exact
250 constant ticks-fast


: exact-crystal-handler ( -- )
  led-on
  led-off
;

: slow-crystal-handler ( -- )
  led-on
  tick @
    1 +  \ One more
    dup tack @ u>= if
                     drop 0
                     ticks-slow  Systick-RELOAD !
                   else
                     ticks-exact Systick-RELOAD !
                   then
  tick !
  led-off
;

: fast-crystal-handler ( -- )
  led-on
  tick @
    1 +  \ One more
    dup tack @ u>= if
                     drop 0
                     ticks-fast  Systick-RELOAD !
                   else
                     ticks-exact Systick-RELOAD !
                   then
  tick !
  led-off
;


: exact-xtal ( -- ) ['] exact-crystal-handler irq-systick ! ticks-exact Systick-RELOAD !  ;
: slow-xtal  ( -- ) [']  slow-crystal-handler irq-systick ! ;
: fast-xtal  ( -- ) [']  fast-crystal-handler irq-systick ! ;

: t ( u -- ) tack ! ; \ For quick clock adjustments


100,00 2constant centerfrequency \ in kHz
250,00 2constant tickcount

: khz ( f -- ) \ Uses measurement with exact-crystal handler to determine tack value

  centerfrequency f/ 1,0 d-  
  2dup dabs 0,0000003 d< 
  if 2drop ." Crystal almost perfect" exact-xtal
  else

  tickcount f* 1,0 2swap f/
  
  nip \ Signed Tack on Stack.

  dup 0< if   ." Crystal too slow, Tack: " slow-xtal abs dup tack ! u. ( 0 tick ! )
         else ." Crystal too fast, Tack: " fast-xtal abs dup tack ! u. ( 0 tick ! )
         then 
  then
  cr
;


: startf ( -- )

  25mhz \ Crystal clock source

  ['] exact-crystal-handler irq-systick !
  0 tick !
  0 tack !
  eint

            0 Systick-CURRENT ! \ Clear Systick counter
  ticks-exact Systick-RELOAD !   \ Divider for clock
            7 Systick-CTRL !      \ System Clock, Interrupt enable, Systick enable
;

