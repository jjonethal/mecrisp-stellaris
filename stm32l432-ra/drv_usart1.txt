\
\ 	USART1 driver 
\
\		Ralph Sahli, 2016
\		
\		resources used: 
\			- USART1  
\			- PA9 -> TX
\			- PA10 -> RX
\
\		REQUIRES: lib_registers.txt
\		REQUIRES: lib_dump.txt


: USART1Init ( -- )  
	17 bit RCC _rAHB2ENR bis!			\ IO port A clock enabled
    MODE_ALTERNATE 9 PORTA set-moder	\ PA9 -> Alternate function mode
    MODE_ALTERNATE 10 PORTA set-moder	\ PA10 -> Alternate function mode  
    7 9 PORTA set-alternate				\ PA9 -> Alternate function: %0111: AF7 (USART1) 
    7 10 PORTA set-alternate			\ PA10 -> Alternate function: %0111: AF7 (USART1) 

	14 bit RCC _rAPB2ENR bis! 			\ Enable clock for USART1
	2 bit USART1 _uCR1 bis!				\ Receiver enable 
	3 bit USART1 _uCR1 bis!             \ Transmitter enable 
	4800 baud USART1 _uBRR ! 			\ Set Baud rate divider for 4800 Baud at HCLK.
	12 bit USART1 _uCR3 bis!			\ disable Overrun 
	0 bit USART1 _uCR1 bis!             \ USART enable
;

: usart1Txe? ( -- f )
    pause 7 bit [ USART1 _uISR literal, ] bit@ 
;

: usart1Rxne? ( -- f )
    pause 5 bit [ USART1 _uISR literal, ] bit@ 
;

\ transmit a byte to USART
: >usart1 ( byte -- )
	begin usart1Txe? until				\ wait until transmit empty
	[ USART1 _uTDR literal, ] c!		\ send byte
;

\ read a byte from USART
: usart1> (  --  byte )
	begin usart1Rxne? until				\ wait until receive not empty
	[ USART1 _uRDR literal, ] c@		\ fetch data
;

: usart1. ( -- )
	usart1 $30 r-dump ;

	
\ gateway between forth-io and usart1, quit with ESC
: gateway ( -- )
	begin
		usart1Rxne? if 
			usart1> emit 
		then
		key? if 
			key 27 over = if 			\ esc pressed
				drop exit
			else
				>usart1
			then
		then	
	again
;

