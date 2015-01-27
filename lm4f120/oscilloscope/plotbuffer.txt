
\ --------------------------------------------
\  To plot an oscilloscope trace as ASCII art
\ --------------------------------------------

\  needs oscilloscope.txt

: buffermax ( -- u ) \ Search for maximum measurement in buffer
  0 fetchsample-ch1 0 fetchsample-ch2 umax
  buffermask 1+ 0 
  do
    i fetchsample-ch1 i fetchsample-ch2 umax
    umax
  loop
;

: buffermin ( -- u ) \ Search for minimum measurement in buffer
  0 fetchsample-ch1 0 fetchsample-ch2 umin
  buffermask 1+ 0 
  do
    i fetchsample-ch1 i fetchsample-ch2 umin
    umin
  loop
;


0 variable maximum
0 variable minimum

: plotline ( Channel1 Channel2 -- )

  minimum @ - 80 * maximum @ minimum @ -  \ 80 characters wide line plot
  /                                       \ Scale Channel 2

  swap
  minimum @ - 80 * maximum @ minimum @ -  \ Calculate position for character in line
  /                                       \ Scale Channel 1

  ( Pos2 Pos1 )
  2dup = if \ If both channels overlap, print an asterisk.
           drop
           spaces [char] * emit cr
         else
           2dup > if
                    2dup min spaces [char] 1 emit
                    - abs    spaces [char] 2 emit cr
                  else
                    2dup min spaces [char] 2 emit
                    - abs    spaces [char] 1 emit cr
                  then
         then
;


: plotwave ( -- )

  buffermin minimum !
  buffermax maximum !

  ." Minimum : " minimum @ . cr
  ." Maximum : " maximum @ . cr

  82 0 do [char] # emit loop cr

  buffermask 1+ 0 
  do  
    \ i u. space \ Sample number, if desired...
    i sample# @ + dup
    fetchsample-ch1 swap fetchsample-ch2
    ( Channel1 Channel2 ) plotline
  loop

  82 0 do [char] # emit loop cr
;
 
