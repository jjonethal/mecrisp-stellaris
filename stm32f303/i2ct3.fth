\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4

$48000400   constant gpiob
$4 gpiob  + constant GPIOB_OTYPER
$10 gpiob + constant GPIOB_IDR
$18 gpiob + constant GPIOB_BSRR
$20 gpiob + constant GPIOB_AFRL
$40021000   constant rcc
$14 rcc   + constant RCC_AHBENR
$1c rcc   + constant RCC_APB1ENR
$40005400   constant i2c1
$4 i2c1   + constant I2C1_CR2
$10 i2c1  + constant I2C1_TIMINGR
$18 i2c1  + constant I2C1_ISR
$1c i2c1  + constant i2c1_icr
$24 i2c1  + constant I2C1_RXDR
$28 i2c1  + constant I2C1_TXDR


: gpiob-en ( -- ) 1 #18 lshift RCC_AHBENR bis! ;
: i2c1-en ( -- ) 1 #21 lshift RCC_APB1ENR bis! ;
: pin-gpio-mode ( -- ) $f000 gpiob bic!  $5000 gpiob bis! ; \ general-purpose output mode
: pin-af-mode ( -- ) $f000 gpiob bic!  $A000 gpiob bis!  \ select af mode i2c
    GPIOB_AFRL @ $FFFFFF and $44000000 or GPIOB_AFRL ! ;
: pin-opendrain ( -- ) $3 $6 lshift GPIOB_OTYPER ! ; \ select opendrain mode
: sda1 ( -- ) 1 7 lshift GPIOB_BSRR ! ;
: sda0 ( -- ) 1 7 16 + lshift GPIOB_BSRR ! ;
: scl1 ( -- ) 1 6 lshift GPIOB_BSRR ! ;
: scl0 ( -- ) 1 6 16 + lshift GPIOB_BSRR ! ;
: scl@ ( -- ) 1 6 lshift GPIOB_IDR bit@ ;
: sda@ ( -- ) 1 7 lshift GPIOB_IDR bit@ ;
: scl. scl@ . ;
: sda. sda@ . ;
: i2c-timing  ( -- ) \ 100 khz @ 8M : PRESC = 1 SCLL=0x13 SCLH=0xF SDADEL=0x2 SCLDEL=0x4
    #1 #28 lshift    \ PRESC=1
    #4 #20 lshift or \ SCLDEL=0x4
    #2 #16 lshift or \ SDADEL=0x02
    $f  #8 lshift or \ SCLH=0xF
   $13            or \ SCLL=0x13
   I2C1_TIMINGR ! ;
: i2c-on ( -- ) 1 i2c1 bis! ; \ PE 1 
: i2c-off ( -- ) 1 i2c1 bic! ; \ PE 1 
: i2c-start ( a n r/w -- ) \ number of bytes, address, read(1)/write(0)
   0<> 1 and #10 lshift \ r/w
   swap #16 lshift or   \ number of bytes 
   or                   \ i2c address
   I2C1_CR2 !
   1 #13 lshift I2C1_CR2 bis! ;
: i2c-tx  ( n -- )  I2C1_TXDR c! ;
: i2c-rx  ( -- n )  I2C1_RXDR c@ ;
: i2c-stat  ( -- n )  i2c1_isr @ ;
: i2c-stop  ( -- )  $1 #14 lshift i2c1_cr2 bis! ;
: accel-init gpiob-en i2c1-en pin-opendrain pin-af-mode i2c-timing i2c-on ;
: i2c-wait ( n -- ) begin dup i2c-stat and until drop ; 
: i2c-set-reg-adr ( reg a  -- ) 1 0 i2c-start 2 i2c-wait i2c-tx ;
: i2c-write-reg ( v reg a  -- ) \ value register i2c-adress
   2 0 i2c-start 2 i2c-wait i2c-tx 2 i2c-wait i2c-tx $40 i2c-wait ;
: i2c-read-reg ( reg a  -- ) \ value register i2c-adress
   tuck i2c-set-reg-adr 1 1 i2c-start $4 i2c-wait i2c-rx i2c-stop ;
