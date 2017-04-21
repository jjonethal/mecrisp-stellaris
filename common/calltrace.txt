
\ -----------------------------------------------------------------------------
\  Trace of the return stack entries
\ -----------------------------------------------------------------------------

0 variable closest-found

: traceinside. ( Address -- )
  1 bic \ Thumb has LSB of address set.
  dup flashvar-here u>= if drop exit then \ Flash variables or peripheral registers cannot be resolved this way.
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

  closest-found @ ?dup if dup ." ( " 6 + skipstring dup hex. ." + " r@ swap - hex. ." ) " 6 + ctype then
  rdrop
;

\ Call trace on return stack.

\ Beware: This searches for the closest dictionary entry points to the addresses on the return stack
\         and may give random results for values that aren't return addresses.
\         I assume that users can decide from context which ones are correct.

: ct ( -- )
  cr
  rdepth 0 do
    i hex. i 2+ rpick dup hex. traceinside. cr
  loop
;

: ct-irq ( -- ) \ Try your very best to help tracing unhandled interrupt causes...
  cr cr
  unhandled
  cr
  h.s
  cr
  ." Calltrace:" ct
  begin again \ Trap execution
;

