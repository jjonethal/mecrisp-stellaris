
\ A 32 bit cycle counter available on most M3/M4/M7 targets

$E0001000 constant DWT_CONTROL
$E0001004 constant DWT_CYCCNT
$E0001FB0 constant DWT_LAR
$E000EDFC constant SCB_DEMCR

: init-cycles ( -- )

  $C5ACCE55 DWT_LAR !     \ Unlock
  $01000000 SCB_DEMCR !   \ Enable Data Watchpoint and Trace (DWT) module
          0 DWT_CYCCNT !  \ Reset the counter
          1 DWT_CONTROL ! \ Enable the counter

;

: cycles ( -- u ) DWT_CYCCNT @ ;

: delay-cycles ( cycles -- )
  cycles ( cycles start )
  begin
    pause
    2dup ( cycles start cycles start )
    cycles ( cycles start cycles start current )
    swap - ( cycles start cycles elapsed )
    u<=
  until
  2drop
;
