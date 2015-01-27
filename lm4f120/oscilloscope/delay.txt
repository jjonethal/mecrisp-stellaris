
\ Delay with Systick-Timer
\   needs basisdefinitions.txt

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

    \ Enable SysTick with PIOSC/4 = 4MHz clock
    1 NVIC_ST_CTRL_R ! \ Use %101 instead for core clock
;

: delay-ticks ( ticks -- ) \  Tick = 1/4MHz = 250 ns
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

: us ( us -- ) 4 * delay-ticks ;
: ms ( ms -- ) 0 ?do 4000 delay-ticks loop ;
