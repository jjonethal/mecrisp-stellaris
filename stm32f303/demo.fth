\ demo.fth
\ STM32F303VCT6 F3Discovery Board demo

\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"

\ board Specification


\ processor STM32F303VCT6

\ IO allocation

\ LEDS
\ LD3  LED3  red    - PE9
\ LD4  LED4  blue   - PE8
\ LD5  LED5  orange - PE10
\ LD6  LED6  green  - PE15
\ LD7  LED7  green  - PE11
\ LD8  LED8  orange - PE14
\ LD9  LED9  blue   - PE12
\ LD10 LED10 red    - PE13

\ Buttons
\ B1   Button User  - PA0


\ L3GD20
\ SPI1_SCK          - PA5
\ SPI1_MOSI         - PA7
\ SPI1_MISO         - PA6
\ CS_I2C_SPI        - PE3
\ MEMS_INT2         - PE1
\ MEMS_INT1         - PE0   

: cnt0  ( m -- b )           \ count trailing zeros with hw support
   dup negate and 1-
   clz negate #32 + ;
: bits@  ( m adr -- b )
   @ over and swap cnt0 rshift ;

: bits!  ( n m adr -- )
  >R dup >R cnt0 lshift     \ shift value to proper pos
  R@ and                    \ mask out unrelated bits
  R> not R@ @ and           \ invert bitmask and makout new bits
  or r> !                   \ apply value and store back
  ;
