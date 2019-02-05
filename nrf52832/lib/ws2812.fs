\ nrf ws2812b driver with i2s
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE
\   original idea from https://electronut.in/nrf52-i2s-ws2812/
\   Need 4 words before inclusion of this driver :
\     PIN.ws PIN.lrck PIN.sck and nbleds
\   will use 3 pins but only PIN.ws is usefull to drive ws2812,
\   other pins are unused by required by I2S module
\   will also consume 12 bytes per pixel...

nbleds 3 * 2 + constant nbwords \ word 4 bytes

\ the frame buffer
nbwords cells buffer: ws.fb

\ internal variables
0 variable ws.r
0 variable ws.g
0 variable ws.b
0 variable ws.state

\ dump internal i2s states
: ws.debug.evt
 ." i2s.rxptrupd=$" &i2s.rxptrupd @ hex. cr
 ." i2s.stopped= $" &i2s.stopped @ hex. cr
 ." i2s.txptrupd=$" &i2s.txptrupd @ hex. cr
;

: ws.debug
 ." I2S internal:" cr
 ws.debug.evt
 ." i2s.start=   $" &i2s.start @ hex. cr
 ." i2s.stop=    $" &i2s.stop @ hex. cr
 ." i2s.inten=   $" &i2s.inten @ hex. cr
 ." i2s.en=      $" &i2s.en @ hex. cr
 ." i2s.rxen=    $" &i2s.rxen @ hex. cr
 ." i2s.txen=    $" &i2s.txen @ hex. cr
 ." i2s.mcken=   $" &i2s.mcken @ hex. cr
 ." i2s.ratio=   $" &i2s.ratio @ hex. cr
 ." i2s.rxd=     $" &i2s.rxd @ hex. cr
 ." i2s.txd=     $" &i2s.txd @ hex. cr
 ." i2s.maxcnt=  $" &i2s.maxcnt @ hex. cr
 ." ws.state=    " ws.state @ . cr
;

\  1 byte rgb color to 32 bits ws2812 style color code, %0 -> %1000,  %1=%1110
\  4 LSB + 4 MSB
: ws.32bcolor ( c -- cellC )
  0 0 3 do
    4 lshift
    over i bit and if %1110 else %1000 then or 
  -1 +loop
  4 7 do
    4 lshift
    over i bit and if %1110 else %1000 then or 
  -1 +loop
  swap drop
;
\ write GRB color code to frame-buffer @ addr...addr+11bytes 
: ws.rgb ( r g b addr -- addr+12 )
  swap ws.32bcolor over 8 + ! ( r g addr )
  swap ws.32bcolor over ! ( r addr )
  swap ws.32bcolor over 4 + ! ( add+4 )
  12 +
;

\ fill the frame buffer with a color
: ws.fill ( r g b -- )
  ws.b ! ws.g ! ws.r !
  ws.fb nbleds 0 do >r ws.r @ ws.g @ ws.b @ r> ws.rgb loop drop
;

\ clear all events, eg, clear all pending interrupts
: ws.evtclr
0 &i2s.txptrupd ! 0 &i2s.rxptrupd ! 0 &i2s.stopped ! 
;
\ force stop event while sending
: ws.stop 
  i2s.stop
  ws.evtclr
;

\ release all resources
: ws.deinit
  ws.stop
  37 irq.den
  ['] unhandled irq-NVIC37 !
  ." I2S released" cr
;

\ ISR, internal state machine to send only 1 full frame
: isr.ws
  ws.evtclr
  ws.state @ dup 2 = if 1 &i2s.stop ! then
  1+ ws.state !
;

\ Module initialization, acquire all resources
: ws.init
  0 0 1 ws.fill

  \ initialize i2s
  0 &i2s.en !
  0 &i2s.mcken !
  
  
  i2s.master
  3200 i2s.mckfreq
  16   i2s.width
  0    &i2s.ratio ! \ MCK/32
  \ The following 3 pins MUST be setted to different PINs
  \ otherwise I2S will NOT work at all
  \ only pin.ws is useful to drive ws2812
  pin.ws i2s.pin.sdout
  pin.lrck i2s.pin.lrck
  pin.sck i2s.pin.sck
  
  ws.fb &i2s.txd !
  nbwords &i2s.maxcnt !
  1 &i2s.mcken !
  1 &i2s.txen !
  ['] isr.ws irq-NVIC37 !
  i2s.int.tx i2s.intset
  37 irq.en   \ XXX: FIXME: less hardcoded way to do this ?
  ." ws2812 initialized" cr
;

\ set pixel color
: ws.pixel ( r g b led# -- )
  3 * cells ws.fb + ws.rgb drop
;

\ start send frame content
: ws.display
  0 ws.state !
  1 &i2s.en !
  i2s.start
;

