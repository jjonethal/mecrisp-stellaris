\
\ 	Driver NANO HORNET (ORG1411) for Nano GPS click module
\
\		Ralph Sahli, 2016
\		
\		resources used: 
\			- USART1 
\
\		REQUIRES: lib_dump.txt
\		REQUIRES: drv_usart1.txt



1 constant RMC_SCAN
2 constant COMMA_SCAN

RMC_SCAN variable gpsFunction

0 variable gpsPtr 				\ current char pointer
$80 buffer: gpsBuff				\ scan buffer: fixlength 10 char per RMC item
$80 buffer: gpsData				\ data buffer: fixlength 10 char per RMC item
gpsBuff variable offsetPtr		\ fixlength 10 char offset
false variable gpsData?			\ flag for new gpsData available

: gpsBuffInit ( -- )
	gpsBuff $80 0 fill ;

: gpsBuff.
	gpsBuff $80 b-dump 
	cr cr
	gpsData $80 b-dump 
;	
	
: gpsInit ( -- )
	usart1Init
	gpsBuffInit
;

	
: scanComma ( char -- )
	 [char] , over = if							\ comma received
			drop
			10 offsetPtr +! 
			offsetPtr @ gpsPtr !
	 else
			[char] * over = if 					\ * received -> end of protocol
				drop
				0 gpsPtr !
				RMC_SCAN gpsFunction !
				gpsBuff gpsData $80 move
				true gpsData? !
			else								\ data char received ->
				gpsPtr @ c!
				1 gpsPtr +!
			then
	 then
;

: scanRMC ( char -- )
	s" $GPRMC," drop 
	gpsPtr @ + c@ = if							\ test for $GPRMC, sequence
		1 gpsPtr +! 
		gpsPtr @ 7 = if 						\ $GPRMC, sequence received
			gpsBuffInit
			gpsBuff dup offsetPtr ! gpsPtr !
			COMMA_SCAN gpsFunction !
		then
	else										\ no sequence pattern
		0 gpsPtr !
	then
;


\ scan NMEA sentences
: gpsNMEAscan ( -- )
	usart1>
	gpsFunction @ case	
		RMC_SCAN of 
			scanRMC				
		endof
		COMMA_SCAN of 
			scanComma				
		endof
	endcase
;


\ ***************** Tests ******************

\ raw gps data to output
: gps>output ( -- )
	gpsInit
	begin
		usart1Txe? if
			usart1> emit
		then
		key?
	until
;

\ gps buffer data RMC items to output
: gpsTest ( -- )
	gpsInit
	begin
		usart1Txe? if
			gpsNMEAscan
		then
		gpsData? @ if			\ new data available ?
			." $GPRMC:" cr 
			12 0 do
				i 10 *			\ offset
				gpsData +		\ gps data buffer
				10 type cr
			loop
			false gpsData? !	\ mark as read
		then
		key?
	until
;

