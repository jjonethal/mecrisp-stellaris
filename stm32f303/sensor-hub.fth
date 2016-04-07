\ sensorhub
\ This is free software under GNU General Public License v3.
\ STM32F303VCT6 F3Discovery Board demo
\ copyrights (c) 2015 by Jean Jonethal
\ Documents
\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"
\ L3GD20     "C:\Users\jeanjo\Downloads\stm\DM00036465 L3GD20.pdf"
\ LSM303DLHC "C:\Users\jeanjo\Downloads\stm\DM00027543-LSM303DLHC.pdf"
\ i2c spec   "http://www.nxp.com/documents/user_manual/UM10204.pdf"
\ board man  "C:\Users\jeanjo\Downloads\stm\DM00063382 STM32F3DISCOVERY user manual.pdf"


\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 )
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5
\ INT1              - PE4
\ using interrupt
0 variable v-mag-x
0 variable v-mag-y
0 variable v-mag-z
0 variable v-acc-x
0 variable v-acc-y
0 variable v-acc-z
0 variable v-gyr-x
0 variable v-gyr-y
0 variable v-gyr-z
0 variable t-celsi

0 variable pos-x
0 variable pos-y
0 variable pos-z
0 variable v-x
0 variable v-y
0 variable v-z
0 variable a-x
0 variable a-y
0 variable a-z

0 variable phi-x
0 variable phi-y
0 variable phi-z
0 variable omega-x
0 variable omega-y
0 variable omega-z
0 variable alpha-x
0 variable alpha-y
0 variable alpha-z

: timer-handler ;
: usb-handler ;
\ ********** i2c section *********************
0   variable i2c-adr
0   variable i2c-reg
0   variable i2c-xfer-num
0   variable i2c-xfer-count
0   variable i2c-state
0   variable i2c-callback
#32 buffer:  i2c-buffer
: i2c-tx-start  ( -- )  i2c-adr@ i2c-xfer-num@ i2c-start-write ;
: i2c-s-idle  ( -- )  i2c-off i2c-int-dis ;
: i2c-tx-adr  ( -- )  i2c-init i2c-tx-start i2c-tx-reg# -> ;
: i2c-tx-reg  ( -- )  
   i2c-isr case dup TXIE and ?of i2c-reg @ i2c-tx  i2c-tx-data# -> endof
                dup TC   and ?of i2c-stop          i2c-tx-end#  -> endof endcase ;
: i2c-tx-data  ( -- )
    i2c-isr case dup TXIE and ?of i2c-tx i2c-buffer@ i2c-tx i2c-tx-data# -> endof
                 dup TC   and ?of i2c-stop                  i2c-tx-end#  -> endof endcase ;
: i2c-tx-end  ( -- )  i2c-off i2c-int-dis i2c-notify ;
: i2c-rx-sel-adr  ( -- )  i2c-init i2c
: i2c-handler ;

: spi-handler ;
: accel-handler ;
: mag-handler ;
: gyro-handler ;
: app-s-init ;
: app-s-calibrate ;
: usb-init ;
: app ( -- )
   board-init
   timer-init
   app-init ;
