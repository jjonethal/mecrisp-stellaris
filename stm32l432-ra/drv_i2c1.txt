\
\ 	I2C1 driver ( master )
\
\		Ralph Sahli, 2016
\		
\		resources used: 
\			- I2C1  
\			- PB6 -> SCL
\			- PB7 -> SDA
\
\		REQUIRES: lib_registers.txt
\		REQUIRES: lib_dump.txt

: i2c-Init ( -- )  
    MODE_ALTERNATE 6 PORTB set-moder		\ PB6 -> Alternate function mode
    MODE_ALTERNATE 7 PORTB set-moder		\ PB7 -> Alternate function mode
	6 bit PORTB _pOTYPER bis!				\ PB6 Open Drain
	7 bit PORTB _pOTYPER bis!				\ PB7 Open Drain
	SPEED_VERYHIGH 6 PORTB set-opspeed 		\ high speed PB6
	SPEED_VERYHIGH 7 PORTB set-opspeed 		\ high speed PB7
\	%01 6 2* lshift PORTA_PUPDR bis!		\ PB6 -> 01=Pullup
\	%01 7 2* lshift PORTC_PUPDR bis!		\ PB7 -> 01=Pullup
    4 6 PORTB set-alternate					\ PB6 -> Alternate function: %0100: AF4 (I2C1) 
    4 7 PORTB set-alternate              	\ PB7 -> Alternate function: %0100: AF4 (I2C1) 

	21 bit RCC _rAPB1ENR1 bis! 				\ Enable clock for I2C1
	
	\ timing: SM ( standard mode ) 100 kHz 
	hclk @ 8000000 = if
		$00201D2B I2C1 _iTIMINGR !			\ set timing @ HSI 8 MHz -> get value from tool
	else
		$10805E89 I2C1 _iTIMINGR !			\ set timing @ HSI 48 MHz -> get value from tool
	then

	0 bit I2C1 _iCR1 bis!                	\ I2C1 enable
;

: i2c-Start  ( -- f )
	0 bit [ I2C1 _iCR1 literal, ] bis!          \ I2C1 enable
	13 bit [ I2C1 _iCR2 literal, ] bis! 		\ set START bit  
	begin 
		pause 
		13 bit [ I2C1 _iCR2 literal, ] bit@ not \ start bit cleared ?
		4 bit [ I2C1 _iISR literal, ] bit@ or	\ or NACK ?
	until 
	4 bit [ I2C1 _iISR literal, ] bit@ 			\ flag -> NACK 
	4 bit [ I2C1 _iICR literal, ] bis!			\ clear NACK 
;

: i2c-Stop  ( -- )
	begin
		pause 
		6 bit [ I2C1 _iISR literal, ] bit@		\ tranfer complete ?
	until
	14 bit [ I2C1 _iCR2 literal, ] bis!			\ set STOP bit 
	begin 
		pause 
		5 bit [ I2C1 _iISR literal, ] bit@ 		\ STOP bit?
	until 
	5 bit [ I2C1 _iICR literal, ] bis!			\ clear STOP 
	0 bit [ I2C1 _iCR1 literal, ] bic!          \ I2C1 disable
;	

\ start and send device-address for read
: i2c-rx ( addr -- f )
	[ I2C1 _iCR2 literal, ] !					\ length + address
	10 bit [ I2C1 _iCR2 literal, ] bis!			\ Master requests a read transfer
	i2c-Start	
;

\ start and send device-address for write
: i2c-tx ( addr -- f )
	[ I2C1 _iCR2 literal, ] !					\ length + address
	i2c-Start
;

\ read 1 byte
: i2c@ ( -- c )
	begin 
		pause 
		2 bit [ I2C1 _iISR literal, ] bit@ 		\ wait for RxNE
	until										
	[ i2c1 _iRXDR literal, ] @
;

\ write 1 byte
: i2c! ( c -- )
	begin
		pause 
		1 bit [ I2C1 _iISR literal, ] bit@		\ wait for Txe
	until
	[ i2c1 _iTXDR literal, ] !
;

\ write 1 byte and stop
: >i2cData ( c -- )
	i2c! 
	i2c-Stop
;

\ write n bytes from cAddr and stop
: >>i2cData ( cAddr n -- )
	0 do
		dup c@ i2c! 1+ 							\ send n bytes from addr		
	loop drop
	i2c-Stop
;

\ read 1 byte and stop
: i2cData> ( -- c )
	i2c@ i2c-Stop
;

\ read n bytes to cAddr and stop
: i2cData>> ( cAddr n -- )
	0 do
		i2c@ over c! 1+
	loop drop
	i2c-Stop
;

: h.2 ( n -- )
	hex 2# decimal ;

\ scan and report all I2C devices on the bus
: i2cScan. ( -- ) 
	i2c-init
	128 0 do
		cr i h.2 ." :"
		16 0 do  space
		  i j + 2* dup i2c-tx if drop ." --" else i2c-Stop h.2  then
		loop
	16 +loop
;

: i2c. ( -- )
	I2C1 $30 r-dump
;

