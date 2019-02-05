\ ws2812 animation
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE

compiletoram

include embello/hexdump.fs

include lib/io.fs
include lib/nvic.fs
include lib/timer.fs
include lib/i2s.fs
include lib/rng.fs

  1 constant PIN.lrck
  0 constant PIN.sck
  7 constant PIN.ws
256 constant nbleds
include lib/ws2812.fs

: wait
  500 0 do nop loop
;


0 variable pixel 
: rcolor
 3 0 do rng@ wait 32 mod loop
;

\ random pixel animation
: rtest
  begin
    0 0 0 ws.fill
    rcolor wait rng@ ws.pixel
    rcolor wait rng@ ws.pixel
    rcolor wait rng@ ws.pixel
    rcolor wait rng@ ws.pixel
    ws.display
    1024 0 do wait loop
  key? until
  0 0 0 ws.fill ws.display
  ws.deinit
;


: init ws.init rng.init rtest ;

init
