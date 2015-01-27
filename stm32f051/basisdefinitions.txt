
compiletoflash

: Flamingo cr
."      _" cr
."     ^-)" cr
."      (.._          .._" cr
."       \`\\        (\`\\        (" cr
."        |>         ) |>        |)" cr
." ______/|________ (7 |` ______\|/_______a:f" cr
;

: init
  cr
  Flamingo
  cr
  ." Have a nice day !" cr
;

\ Cornerstone for 1 kb Flash pages

: cornerstone ( Name ) ( -- )
  <builds begin here $3FF and while 0 h, repeat
  does>   begin dup  $3FF and while 2+   repeat 
          eraseflashfrom
;
