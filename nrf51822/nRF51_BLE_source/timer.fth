#include constants.fth

compiletoflash

decimal

\ TIMER0 is setup for 24-bit, TIMER1&2 for 16-bit, all with 1uS resolution

: init_timer				( period_us, timer -- )
	1 over 4 + !			\ stop
	4 over $510 + !			\ set prescaler to 1uS
	dup $3000 and			\ check which timer
	if 1 else 2 then
	over $508 + !			\ T0=24-bit T1,T2=16-bit
	swap 1- over $540 + !	\ set CC0
	$10000 over $304 + !	\ enable CC0 interrupt
	1 over $200 + !			\ short CC0 -> CLEAR
	1 swap !				\ start
;

: clear_timer_CCE			( timer -- )
	0 SWAP $140 + !
;

: en_timer_CCi				( handler, timer -- )
	1 over 8 + !			\ clear counter
	dup clear_timer_CCE		\ clear CC event
	case
		TIMER0 of irq-tim0 $100 endof
		TIMER1 of irq-tim1 $200 endof
		TIMER2 of irq-tim2 $400 endof
	endcase
	NVIC_ISER bis!			\ enable interrupt, priority????
	!						\ store irq handler
;

: stop_timer 				( timer -- )
	1 swap 4 + !
;
