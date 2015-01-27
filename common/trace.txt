
\ --------------------------------------------------------
\  Trace tool to see call entries and stack contents
\  Needs to be compiled into the definitions to be traced
\ --------------------------------------------------------

false variable trace-state
    0 variable trace-depth
    0 variable latest-<builds

: tracename. ( Address -- ) \ If the address is Code-Start of a dictionary word, it gets named.
  1 bic \ Thumb has LSB of address set.

  >r
  dictionarystart
  begin
    dup   6 + dup skipstring r@ = if ." --> " ctype 2 spaces else drop then
    dictionarynext
  until
  drop
  rdrop 
;

0 variable closest-found

: traceinside. ( Address -- )
  1 bic \ Thumb has LSB of address set.
  0 closest-found ! \ Address zero (vector table) is more far away than all other addresses

  >r
  dictionarystart
  begin
    dup r@ u< \ No need for u<= because we are scanning dictionary headers here.
    if \ Is the address of this entry BEFORE the address which is to be found ?
      \ Distance to current   Latest best distance
      r@ over -               r@ closest-found @ -  <
      if dup closest-found ! then \ Is the current entry closer to the address which is to be found ?              
    then
    dictionarynext
  until
  drop
  rdrop

  closest-found @ ?dup if 6 + ctype 2 spaces then
;

: does-name. ( Address -- )
  begin
    2-
    dup h@ $B500 =           \ Scan back to push {lr} opcode
  until
  dup 2- h@ $0036 = if 2- then \ Skip optional alignment nop opcode
  tracename.
;

\ Call trace on return stack.

\ Beware: This searches for the closest dictionary entry points to the addresses on the return stack
\         and will give random results for values that aren't return addresses.
\         I assume that users can decide from context which ones are correct.

: ct ( -- )
  cr
  rdepth 0 do
    i 2+ rpick dup hex. traceinside. cr
  loop
;

: trace-on  ( -- ) true trace-state ! 0 trace-depth ! ;
: trace-off ( -- ) false trace-state ! ;

\ Redefine entry and exit points

: trace-entry-does ( -- ) trace-state @ if 1 trace-depth +!
                          ."    --> ( " base @ decimal trace-depth @ . base ! ." ) " 
                          dup does-name. ." --does-> " r@ traceinside. .s then ;

: trace-entry      ( -- ) trace-state @ if 1 trace-depth +! 
                          ."    --> ( " base @ decimal trace-depth @ . base ! ." ) " 
                          r@ 6 - tracename. .s then ;

: trace-exit       ( -- ) trace-state @ if                  
                          ."    <-- ( " base @ decimal trace-depth @ . base ! ." ) " 
                          -1 trace-depth +! .s then ;

: does>
  [ ' trace-exit 1+ 0 registerliteral, $4780 h, ] \ This is the exit point of <builds which needs to be traced properly, too.
  does>
  [ ' trace-entry-does 1+ 0 registerliteral, $4780 h, ] \ A direct call would be generated with a relative BL instruction and this needs to be relocatable.
inline ;

: exit ( -- )
  postpone trace-exit
  postpone exit
immediate ;

: ; ( -- )
  postpone trace-exit
  postpone ;
immediate [ ret, smudge

: : ( -- )
  :      
  postpone trace-entry
[ ret, smudge


\ Code to be traced comes here.

