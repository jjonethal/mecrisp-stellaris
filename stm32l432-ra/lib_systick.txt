\
\ 	timing functions with Systick-Timer
\
\		Ralph Sahli, 2016
\		
\		resources used:
\			sysem timer
\	
\		REQUIRES: lib_registers.txt
\		REQUIRES: lib_dump.txt


$E000E010 constant STK_CTRL
$E000E014 constant STK_RELOAD    
$E000E018 constant STK_CURRENT

0 variable tick#							\ tick counter of 1 ms ticks

: systimer-irq-handler
	1 tick# +!
;

: disableSystimer ( -- )
    0 STK_CTRL ! 							\ Disable SysTick 	
;

: init-Systimer ( -- )
    disableSystimer 						\ Disable SysTick during setup
	hclk @ 8 / 1000 /						\ 1 ms @ HCLK
    1- STK_RELOAD !	    					\ reload value for 24 bit timer
    0 STK_CURRENT !							\ Any write to current clears it
    %001 STK_CTRL ! 						\ Enable SysTick with HCLK/8 MHz clock
	['] systimer-irq-handler irq-systick !  \ Hook for handler
	%010 STK_CTRL bis!						\ interrupt enabled
;

: start-timer ( ms -- ms )
	tick# @ + ;

: elapsed? ( ms -- ms flag )
	tick# @ over >= ;

: delay-ms ( ms -- )
	start-timer 
	begin
		pause
		elapsed? 
	until drop 
;

: delayTest ( -- )
	init-Systimer	
	begin
		tick# @ .
		1000 delay-ms
		key? 
	until
;

