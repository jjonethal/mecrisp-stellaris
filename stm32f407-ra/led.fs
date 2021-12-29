: init-led ( -- )
	$FF000000 GPIOD_MODER   bic! \ Restore to input mode
	$0000F000 GPIOD_OTYPER  bic! \ Set type to push-pull
	$FF000000 GPIOD_OSPEEDR bic! \ Low speed is good enough for LEDs
	$FF000000 GPIOD_PUPDR   bic! \ Disable pull ups and downs
	$F0000000 GPIOD_BSRR    !    \ LEDs are off by default
	$55000000 GPIOD_MODER   bis! \ Turn the LED pins into outputs
	;

: >off ( mask -- mask ) $FFFF0000 and ;
: >on  ( mask -- mask ) dup 16 rshift or ;
: led+ ( mask led -- mask ) or ;
: led- ( mask led -- mask ) >on bic ;
: led! ( mask -- ) GPIOD_BSRR ! ;

12 bit dup 16 lshift or constant green
13 bit dup 16 lshift or constant orange
14 bit dup 16 lshift or constant red
15 bit dup 16 lshift or constant blue
red blue led+ constant violet
red blue led+ green led+ constant white

green orange led+ red led+ blue led+ >off constant dark
green orange led+ red led+ blue led+  constant light
