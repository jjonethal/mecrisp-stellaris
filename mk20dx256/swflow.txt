\ This file sets up software flow control
\ NOTE:  In my setup, with a PL2303 based USB-to-serial adapter and
\ NoZap drivers, I cannot get software flow control to reliably work
\ I have swtiched to CTS/RTS (see hwflowcontrol.txt).  It works great!

: Xon $11 emit ;
: Xoff $13 emit ;

\ This version flashes the led which is handy to ensure buffered IO is
\ still flowing, but requires that the led.txt file is already compiled
\ : prompt ( -- ) begin led-off xon query xoff led-on interpret ." ok." cr again ; 

: prompt ( -- ) begin xon query xoff interpret ." ok." cr again ; 
: flowcontrol  ['] prompt hook-quit ! quit ;


\ --------------
\ Testing words
\ --------------
\ The following setups an approximate 5 sec (if running at 96 MHz) 
\ toggling of xon/xoff for testing software flowcontrol

0 variable tickcount
1 variable xonstate
28 variable maxtick

: setxoff 0 xonstate ! xoff led-on ;
: setxon 1 xonstate ! xon led-off ;

: x-isr
  tickcount @
  maxtick @ = if 0 tickcount ! xonstate @ 0 = if setxon else setxoff then
  else 1 tickcount +! then
;

' x-isr irq-systick ! 
$FFFFFF systick-init


