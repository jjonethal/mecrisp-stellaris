
\ --------------------
\  Trigger on signal
\ --------------------

\  needs oscilloscope.txt, plotbuffer.txt, delay.txt

buffermask 2/ variable triggerposition  \ For centered trigger
1024          variable triggerlevel-ch1  \  ADC level to cross for Channel 1

\ Replace "ch1" with "ch2" in this file for the other channel

: risingedge-ch1 ( -- ? )
  sample# @  \ Current position in measurement
  triggerposition @ - \ Some samples ago for centering of detected edge
  ( Center-sample-for-trigger ) >r

  \ Fetch a sample 10 steps before this position and the current one:
  r@ 10 - fetchsample-ch1   triggerlevel-ch1 @ u<=       \ Older sample smaller or equal
  r>      fetchsample-ch1   triggerlevel-ch1 @ u>  and   \ Newer sample greater than level --> Rising edge !
;

: fallingedge-ch1 ( -- ? )
  sample# @  \ Current position in measurement
  triggerposition @ - \ Some samples ago for centering of detected edge
  ( Center-sample-for-trigger ) >r

  \ Fetch a sample 10 steps before this position and the current one:
  r@ 10 - fetchsample-ch1   triggerlevel-ch1 @ u>=       \ Older sample greater or equal
  r>      fetchsample-ch1   triggerlevel-ch1 @ u<  and   \ Newer sample smaller than level --> Falling edge !
;


: rising-ch1 ( -- )
  init-capture
  init-delay
  begin    
    start
      100 ms \ Wait for the buffer to be filled with samples
      begin risingedge-ch1 until
    stop
    plotwave cr
  key? until

  close-capture
;

: falling-ch1 ( -- )
  init-capture
  init-delay
  begin    
    start
      100 ms \ Wait for the buffer to be filled with samples
      begin fallingedge-ch1 until
    stop
    plotwave cr
  key? until

  close-capture
;
