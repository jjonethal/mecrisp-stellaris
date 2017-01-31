\
\ 		driver for HTU21D(F) 
\		Digital Relative Humidity sensor with Temperature output
\
\		Ralph Sahli, 2016
\		
\		resources used: 
\			- I2C  
\
\		REQUIRES: drv_i2c.txt
\		REQUIRES: lib_systick.txt

$80 constant HTU_DEVICE_ADDR
0 variable htuValue

: htu-Init ( -- )
	i2c-init						\ I2C1 initialize
;

\ combine device address and number of bytes to process
\ ( for compatibility with stm32F3 and stm32L4 series )
: htuDeviceLenAddr ( len -- n )
	16 lshift
	HTU_DEVICE_ADDR or 1-foldable
;

\ soft reset HTU
: >htuReset ( -- )
	1 htuDeviceLenAddr i2c-tx drop
	$FE >i2cData					\ soft reset command
;

\ write command
: >htuCmd ( cmd len -- )
	htuDeviceLenAddr i2c-tx drop
	i2c!							\ command
;

\ read 3 bytes temperature / humidity  from HTU
: htu>> ( cmd -- value ) 
	1 >htuCmd
	3 htuDeviceLenAddr i2c-rx drop
	htuValue 3 i2cData>>			\ read register content & CRC
	htuValue c@ 8 lshift
	htuValue 1+ c@ +
;

\ read user register
: htuUserReg> ( -- c )
	$E7 1 >htuCmd					\ read user register command
	1 htuDeviceLenAddr i2c-rx drop
	i2cData>						\ read register content
;

\ write user register
: >htuUserReg> ( c -- )
	$E6 2 >htuCmd					\ write user register command
	>i2cData						\ write register content
;

\ read temperatur in 1/10 °Celsius
: htuTemperatur ( -- n )
	$E3	htu>>						\ read temperature
	1757 *
	16 rshift
	469 -	
;

\ read humidity in 1/10 %
: htuHumidity ( -- n )
	$E5 htu>>						\ read humidity
	1250 *
	16 rshift
	60 -
;	

: ##.# ( n -- )
	0 <# # [char] . hold # # #>
;

: htuTest ( -- )
	htu-Init
	>htuReset
	cr ." status: " htuUserReg> .
	cr
	begin 
		htuTemperatur ##.# TYPE space [char] C emit
		3 spaces
		htuHumidity ##.# TYPE space [char] % emit cr
		1000 delay-ms
\		$1b emit $5b emit [char] A emit		\ VT100: cursor up
		key?
	until
;

