\
\ 	Driver I2C-Bus LCD 3x12 Char
\
\		Ralph Sahli, 2016
\		
\		resources used: 
\			- I2C
\
\		REQUIRES: drv_i2c.txt

$74 constant LCD_DEVICE_ADDR

$80 constant LINE1
$A0 constant LINE2
$C0 constant LINE3

36 buffer: lcdBuff		\ 3 x 12 chars
24 variable lcdPos

\ combine device address and number of bytes to process
\ ( for compatibility with stm32F3 and stm32L4 series )
: lcdDeviceLenAddr ( len -- n )
	16 lshift
	LCD_DEVICE_ADDR or 1-foldable
;

: lcd-Init ( -- )
	lcdBuff 36 BL fill 				\ fill with spaces
	i2c-Init
	4 lcdDeviceLenAddr i2c-tx drop
	$00 i2c!						\ control 1
	$3E i2c!						\ display: shift right
	$0E i2c!						\ display control: display on, cursor on
	$06 >i2cData					\ entry mode: increment
;

: lcd-clr ( -- )	
	2 lcdDeviceLenAddr i2c-tx drop
	$00 i2c!						\ control 1
	$01 >i2cData					\ clear display
;

: >lcd ( addr n pos -- )
	over 3 + lcdDeviceLenAddr i2c-tx drop
	$80 i2c!						\ control 1
	i2c!							\ position $80, $A0, $C0 -> Line 1 2 3
	$40 i2c!						\ control 2
	1- 0 ?do
		dup c@ $80 or i2c!
		1+
	loop 
	c@ $80 or >i2cData
;

\ read BF busy flag & address counter
: lcd> ( -- c )
	1 lcdDeviceLenAddr i2c-tx drop
	$20 i2c!						\ control 1
	1 lcdDeviceLenAddr i2c-rx drop
	i2cData>						\ read register content
;


: lcdTest
	lcd-init
\	   123456789012
	s" LCD Line 1" LINE1 >lcd
	s" LCD Line 2" LINE2 1+ >lcd
	s" LCD Line 3" LINE3 2+ >lcd
;

: lcd-showbuff ( -- )
	lcdBuff      12 LINE1 >lcd
	lcdBuff 12 + 12 LINE2 >lcd
	lcdBuff 24 + 12 LINE3 >lcd
;

: lcd-newline ( -- )
		lcdBuff 12 + lcdBuff 12 move
		lcdBuff 24 + lcdBuff 12 + 12 move
		lcdBuff 24 + 12 BL fill
		24 lcdPos !
;

: lcd-emit? ( -- flag )
	lcd> 
;

: lcd-emit ( char -- ) 
	13 over = if 				\ cr received
		lcd-newline
		drop
	else							\ display char
		lcdBuff lcdPos @ + c! 1 lcdPos +!
		lcdPos @ 35 > if 
			lcd-newline
		then
	then
	lcd-showbuff
;

: serialToLCD ( -- )
	['] lcd-emit? hook-emit? !
	['] lcd-emit hook-emit !
;

: key>lcd 
	begin
		key 27 over = if 		\ esc pressed
			drop exit
		then
		lcd-emit
	again
;



