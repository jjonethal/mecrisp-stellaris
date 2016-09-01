: hsi-on ;
: clock-system-hsi  ( -- )               \ set system clock to hsi
   hsi-on hsi-wait-stable 
: clock-192-mhz ( -- )
   clock-system-hsi  pll-off pll-source-hse pll-192-mhz pll-on
   flash-ws-192-mhz cache-activate clock-system-pll uart-baud-update ;
: clock-init clock-192-mhz ;         \ let the system run on 200 MHz

0 variable cursor-y
0 variable cursor-x
: edit-key-up ( -- )
   cursor-y 0= if scroll-up 
   else -1 cursor-y +! ;
: edit-key-left ( -- )
   cursor-x 0= if scroll-left 
   else -1 cursor-x +! ;
: edit ( -- )                            \ window editor
   edit-key-up
   edit-key-down
   edit-key-left
   edit-key-right
   edit-key-enter
   ;

: draw-keyboard-shifted ( -- )
    s" °!"§$%&/()=?`" draw-key-line
    s" QWERTZUIOPÜ*" draw-key-line
    s" ASDFGHJKLÖÄ'" draw-key-line
    s" >YXCVBNM;:_"  draw-key-line ;

: draw-keyboard-unshifted ( -- )
   ;
: qspi-init ( -- )
   qspi-gpio-init
   qspi-memory-mapped-mode ;   

: demo-start ( -- )
   start-timer
   start-music
   start-graphics ;
\ sine-buffer
\ sine-buffer-adr
\ sine-freq
\ sine-ampl
\ range 0-65535
\ 
: snd-sine ( -- ) 
   sineGenPhase ;

\ ********** square wave gen ************
0  constant gen-sqr-phase                \ phase register
4  constant gen-sqr-reload               \ reload register
8  constant gen-sqr-out                  \ generator output
12 constant gen-sqr-size                 \ generator size
: sqr-phase++ ( a -- a ) -1 over +! ;
: sqr-phase>=sqr-phase-end? ( a -- a f )
  dup @ over gen-sqr-reload + @ >= ;
: sqr-phase-reset ( a -- a ) dup 0 ! ;
: sqr-toggle-out ( a -- a ) dup gen-sqr-out + dup @ negate swap ! ; 
: gen-sqr ( a -- a )
   sqr-phase>=sqr-phase-end 
   if sqr-phase-reset sqr-toggle-out 
   else sqr-phase++ then ;

: gen-mix ( -- )   
: demo ( -- )
   clock-init sdram-init qspi-init sound-init
   display-init touch-init sd-card-init demo-start ;
