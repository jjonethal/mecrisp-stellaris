\ i2c driver
\ file i2c.fth
\ 2016sep5jjo initial version, add docs
\
\ C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf
\ C:\Users\jeanjo\Downloads\stm\DM00166116 STM32F746NG datasheet.pdf
\ require utils.fth
\ require gpio.fth
\ require rcc.fth


\ I2C_SDA (PB9)  package pin (D14) 
\ I2C_SCL (PB8)  package pin (D14) I2C1_SCL

\ PH7 - LCD_SCL / AUDIO_SCL / I2C3_SCL
\ PH8 - LCD_SDA / AUDIO_SDA / I2C3_SDA

\ ********** i2c global states **********
0 variable i2c-1-state 
0 variable i2c-2-state 
0 variable i2c-3-state 
0 variable i2c-4-state 

\ ********** i2c interface functions ****
: i2c-init ( p -- ) ;
: i2c-stop ( p -- ) ;
: i2c-rcc-on ( p -- ) ;
: i2c-gpio-ena ( p -- ) ;
: i2c-int-ena ( p -- ) ;
: i2c-int-dis ( p -- ) ;
: i2c-int-handler ( -- ) ;

: i2c-state-init ( -- ) ;
