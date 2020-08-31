
\ Cornerstone for flash sectors with variable length
\ Adapted for stm32f411 - just reduced the number of the sectors from 12 to 8

: sectorborder ( addr -- u )

  case
  
  \ --- 16 kb sectors --- sectors 0..3
  
    $04000  of   1  endof
    $08000  of   2  endof
    $0C000  of   3  endof
  
  \ --- 64 kb sector  --- sector 4
  
    $10000  of   4  endof
  
  \ --- 128 kb sectors --- sectors 5..7
  
    $20000  of   5  endof
    $40000  of   6  endof
    $60000  of   7  endof
      
  \ Not on a sector border

  0 swap 
  endcase
;

: cornerstone ( Name ) ( -- )
  <builds begin here sectorborder 0= while 0 h, repeat
  does>   begin dup  sectorborder 0= while 2+   repeat 
          sectorborder 8 swap ?do i eraseflashsector loop reset
;

