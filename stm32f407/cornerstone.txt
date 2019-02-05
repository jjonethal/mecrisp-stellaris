
\ Cornerstone for flash sectors with variable length

: sectorborder ( addr -- u )

  case
  
  \ --- 16 kb sectors ---
  
    $04000  of   1  endof
    $08000  of   2  endof
    $0C000  of   3  endof
  
  \ --- 64 kb sector  ---
  
    $10000  of   4  endof
  
  \ --- 128 kb sectors ---
  
    $20000  of   5  endof
    $40000  of   6  endof
    $60000  of   7  endof
    $80000  of   8  endof
    $A0000  of   9  endof
    $C0000  of  10  endof
    $E0000  of  11  endof
      
  \ Not on a sector border

  0 swap 
  endcase
;

: cornerstone ( Name ) ( -- )
  <builds begin here sectorborder 0= while 0 h, repeat
  does>   begin dup  sectorborder 0= while 2+   repeat 
          sectorborder 12 swap ?do i eraseflashsector loop reset
;

