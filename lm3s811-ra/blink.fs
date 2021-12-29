
: led_init ( -- )
	4 $400FE108 !
	$400FE108 @ drop \ small delay
	$40006400 dup @ $20 or swap !
	$4000651C dup @ $20 or swap !
;

\ Turn on the LED. GPIO_PORTC_DATA_R |= 0x20;
: led_on ( -- )
	$400063FC dup @ $20 or swap !
;

\  Turn off the LED. GPIO_PORTC_DATA_R &= ~(0x20);
: led_off ( -- )
	$400063FC dup @ $20 not and swap !
;

: led_pause ( -- ) 200000 0 do loop ; 

: led_blink ( -- )
	led_init
	begin 
		led_on led_pause
		led_off led_pause
	key? until
;

