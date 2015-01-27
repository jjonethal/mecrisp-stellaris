decimal

#include constants.fth

: start_HF_clock			( -- )
	0 CLK_HFCLKSTARTED !	\ clear HF clock started
	1 CLK_HFCLKSTART !		\ start HF clock
	begin					\ wait HF clock started
		CLK_HFCLKSTARTED @	
	until
;

: stop_HF_clock				( -- )
	1 CLK_HFCLKSTOP !
;
