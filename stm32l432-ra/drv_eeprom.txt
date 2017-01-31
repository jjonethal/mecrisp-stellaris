\
\ 	EEPROM driver for 24LC256 ...
\
\		Ralph Sahli, 2016
\		
\		resources used: 
\			- I2C  
\
\		REQUIRES: drv_i2c.txt
\		REQUIRES: lib_dump.txt


$A0 constant EE_DEVICE_ADDR
$100 buffer: eepromBuff

: eeBuff.
	eepromBuff $100 b-dump ;
	
: eeClr
	eepromBuff $100 0 fill ;

: eeprom-Init ( -- )
	i2c-Init							\ I2C1 initialize
	eeClr
;

\ combine device address and number of bytes to process
\ ( for compatibility with stm32F3 and stm32L4 series )
: eeDeviceLenAddr ( len -- n )
	16 lshift
	EE_DEVICE_ADDR or 1-foldable
;

\ send eeprom address and len bytes to process
: >eeAddress ( addr len -- )
	eeDeviceLenAddr
	begin
		dup i2c-tx not						\ wait until not NAK (busy write)
	until drop		
	dup 8 rshift i2c!						\ MSB from addr
	$FF and i2c!							\ LSB from addr
;

\ write a byte to eeprom @ addr
: >eeprom ( c addr -- )
	3 >eeAddress
	>i2cData
;

\ write n bytes from memory srcAddr  to flash @ destAddr
\ n <= 64 bytes = 1 page
\ don't cross page boundary: destAddr + n 
: >>eeprom ( scr n dest -- )
	over $40 > if cr ." max n = 64 bytes = 1 page to write !" exit then
	over 2+ >eeAddress
	>>i2cData
;

\ read a byte from eeprom @ addr
: eeprom> ( addr -- c )
	2 >eeAddress
	1 eeDeviceLenAddr i2c-rx drop
	i2cData>
;

\ read n bytes to memory destAddr from eeprom @ srcAddr
\ max n = 255 
: eeprom>> ( destAddr n srcAddr -- ) 
	over $FF > if cr ." max n = 255 bytes to read !" exit then
	2 >eeAddress
	dup eeDeviceLenAddr i2c-rx drop
	i2cData>>
;
	
: eeTest ( -- )
	eeprom-Init
	0 eeprom> hex.
	$AA 0 >eeprom
	eeClr
	eepromBuff $80 0 eeprom>>
	eeBuff.
;

: eeWr ( -- )
	$40 0 do i eepromBuff i + c! loop
	eepromBuff $40 $40 >>eeprom
	eeBuff.
;