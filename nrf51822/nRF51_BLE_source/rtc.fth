#include lf_clock.fth

decimal

: SEV immediate _SEV h, ;
: WFE immediate _WFE h, ;

: init_RTC				( secs*10 -- )
	1 RTC_STOP !		\ stop
	32768 * 10 / 1-
	RTC_CC0 !			\ set CC0
	$10000 RTC_INTSET !	\ enable CC0 interrupt
	1 RTC_START !		\ start
;

: en_RTC_CCi			( h -- )
	1 RTC_CLEAR !		\ clear counter
	0 RTC_CC0E !		\ clear CC event
	$800 NVIC_ISER bis!	\ enable interrupt, priority????
	irq-rtc0 !
;

: wait_RTC						( secs*10 -- )
	32768 * 10 / 1-
	RTC_CC0 !					\ set CC0
	1 RTC_CLEAR !
	0 RTC_CC0E !
	$10000 RTC_INTSET !			\ enable CC0 interrupt
	$800 NVIC_ICPR !			\ clear pending irq
	SCB_SCB @ 16 or SCB_SCB !	\ set event on pending
	1 RTC_START !
	WFE
	RTC_CC0E @ . cr
	0 RTC_CC0E !
;

\ start_lf_clock

\ 100 wait_RTC	
	