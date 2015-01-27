\ Delay with Systick-Timer

$E000E010 constant NVIC_ST_CTRL_R
$E000E014 constant NVIC_ST_RELOAD_R      
$E000E018 constant NVIC_ST_CURRENT_R

: delay-init ( -- )
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

: delay-ticks ( ticks -- ) \  Tick = 1 / 96MHz = 10.4166667 ns
 NVIC_ST_RELOAD_R ! 	\ Store the number of ticks desired as the reload value 
 0 NVIC_ST_CURRENT_R ! 	\ restart the time from tick count
 begin
    $10000 NVIC_ST_CTRL_R bit@ 
  until
;

: us ( us -- ) 96 * delay-ticks ;
: ms ( ms -- ) 0 ?do 96000 delay-ticks loop ;
: hundredms ( hundredms -- ) 0 ?do 9600000 delay-ticks loop ;
: sec ( secs -- ) 10 * 1 do 1 hundredms loop ;

\ Example
: 10s-Pulse ( -- )
  delay-init \ Start Systick Timer
  10 sec
;

