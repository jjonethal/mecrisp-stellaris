\ Words for controlling the built-in LED on the Teensy 3.1
\ REQUIRES gpio.txt
\ REQUIRES delay.txt
\ REQUIRES timer.txt

: led-init
  $0100  5 4 * PORTC_PCR + ! \ Port C1 GPIO (Alternative 1)
  $20 GPIOC_PDDR ! \ Port C5 as output 
;

: led-on $20 GPIOC_PSOR bis! ;

: led-off $20 GPIOC_PCOR bis! ;

: blink ( n -- ) \ REQUIRES delay.txt
        led-init
        delay-init
        0 do led-on 3 hundredms led-off 3 hundredms loop
;

: led-toggle  ( -- )
        $20 GPIOC_PTOR bis! \ Toggle the on-board led
;

: led-pulse ( -- )  	\ Interrupt driven led blinker REQUIRES timer.txt
  led-init
  ['] led-toggle irq-systick !  \ Set the systick IRQ service routine to the tick word
  $FFFFFF systick-init          \ set the maximum tick value (~ .175 seconds)
;

