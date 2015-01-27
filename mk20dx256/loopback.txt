\ Miscellanous words used when testing flowcontrol and uart 
  
\ Loopback is just a simple loopback program for testing flow control.  Use ^D to exit.
: loopback begin key dup $04 <> while emit repeat drop ;

\ plb - paused loopback.  Useful to try and force overflow conditions
: plb  ( delay_in_ms -- ) 
  begin key dup $04 <> while emit dup ms repeat 
  drop drop ;
