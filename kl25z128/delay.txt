
\ Delay with Systick-Timer

$E000E010 constant NVIC_ST_CTRL_R
$E000E014 constant NVIC_ST_RELOAD_R      
$E000E018 constant NVIC_ST_CURRENT_R

: init-delay ( -- )
    \ Start free running Systick Timer without Interrupts
  
    \ Disable SysTick during setup
    0 NVIC_ST_CTRL_R !

    \ Maximum reload value for 24 bit timer
    $00FFFFFF NVIC_ST_RELOAD_R !

    \ Any write to current clears it
    0 NVIC_ST_CURRENT_R !

    \ Enable SysTick with core clock
    %101 NVIC_ST_CTRL_R !
;

: delay-ticks ( ticks -- ) \  Tick = 1 / 20.97MHz = 47.7 ns
  NVIC_ST_CURRENT_R @ \ Get the starting time
  swap -              \ Subtract ticks to wait
  $00FFFFFF and       \ Handle possible counter roll over by converting to 24-bit subtraction
  ( finish )

  begin
    dup
    NVIC_ST_CURRENT_R @ \ Get current time
    ( finish finish current )
    u>= \ Systick counts backwards
  until
  drop
;

: us ( us -- ) 21 * delay-ticks ;
: ms ( ms -- ) 0 ?do 21000 delay-ticks loop ;

\ Example:

: 10s-Pulse ( -- )
  init-delay \ Start Systick Timer
  10000 ms
;

10s-Pulse
