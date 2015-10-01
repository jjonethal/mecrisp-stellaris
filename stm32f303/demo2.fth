\ demo stm32f303vct6
\ file:demo.fth
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


\ board specification
\ processor STM32F303VCT6

\ components

\ LEDS
\ LD3  LED3  red    - PE9   ( N )
\ LD4  LED4  blue   - PE8   ( NW )
\ LD5  LED5  orange - PE10  ( NE )
\ LD6  LED6  green  - PE15  ( W )
\ LD7  LED7  green  - PE11  ( E )
\ LD8  LED8  orange - PE14  ( SW )
\ LD9  LED9  blue   - PE12  ( SE )
\ LD10 LED10 red    - PE13  ( S )

\ Buttons
\ B1   Button User  - PA0

\ L3GD20 three-axis digital output gyroscope
\ Manual "C:\Users\jeanjo\Downloads\stm\DM00036465 L3GD20.pdf"
\ SPI1_SCK          - PA5 ( SPI1 AF5 )
\ SPI1_MOSI         - PA7 ( SPI1 AF5 )
\ SPI1_MISO         - PA6 ( SPI1 AF5 )
\ CS_I2C_SPI        - PE3 0:spi mode 1:i2c mode
\ MEMS_INT2         - PE1
\ MEMS_INT1         - PE0

\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4

\ USB Interface
\ USB_DM            - PA11
\ USB_DP            - PA12

\ HSE 8 MHz clock from companion debug controller
\ HSI 8 MHz clock

\ 5 V tolerant U(S)ART ports
\ USART1_TX - PA9   ( Forth Terminal )
\ USART1_RX - PA10  ( Forth Terminal )
\ USART2_TX - PA14
\ USART2_RX - PA15
\ USART2_TX - PB3
\ USART2_RX - PB4
\ USART1_TX - PB6   ( LSM303DLHC SCL )
\ USART1_RX - PB7   ( LSM303DLHC SDA )
\ USART3_TX - PC10
\ USART4_TX - PC10
\ USART3_RX - PC11
\ USART4_RX - PC11
\ UART5_TX  - PC12
\ UART5_RX  - PD2
\ USART2_TX - PD5
\ USART2_RX - PD6
\ USART1_TX - PE0   ( MEMS_INT1 )
\ USART1_RX - PE1   ( MEMS_INT2 )


\ Cornerstone for 2 kb Flash pages grabbed from MK basisdeninitions.txt

: cornerstone ( Name ) ( -- )
  <builds begin here $7FF and while 0 h, repeat
  does>   begin dup  $7FF and while 2+   repeat 
          eraseflashfrom
;

\ utility functions for common use
: cnt0   ( m -- b )                           \ count trailing zeros with hw support
   dup negate and 1-
   clz negate #32 + 1-foldable ;
: bits@  ( m adr -- b )                       \ get bits a masked position
   @ over and swap cnt0 rshift ;
: bits!  ( n m adr -- )                       \ set masked bits at position
   >R dup >R cnt0 lshift                      \ shift value to proper pos
   R@ and                                     \ mask out unrelated bits
   R> not R@ @ and                            \ invert bitmask and makout new bits
   or r> ! ;                                  \ apply value and store back
: bit-mask! ( v m adr -- )                    \ set bit masked value at 
   >R dup >R and R> not R@ @ and or R> ! ; 

: enum  ( n -- n+1 ) dup constant 1+ ;        \ next enum id 

: struct{  ( -- 0 ) 0 ;                       \ start structure def
: field  ( n1 n2 -- n1+n2 )  ( token: name )  \ reserve n byte with constant name
   over constant + ;
: }struct  ( n -- ) ( token: name) constant ; \ end of structure, assign size of structure to constant
: ftab: ( "name" -- )                         \ build function table
   <BUILDS DOES> swap 2 lshift + @ execute ;
   
   
$40022000 constant FLASH_BASE
$00 FLASH_BASE or constant FLASH_ACR
$1 #5 lshift constant PRFTBS
$1 #4 lshift constant PRFTBE
$1 #3 lshift constant HLFCYA
$7           constant LATENCY


\ flash functions
: flash-ws!  ( n -- )  LATENCY FLASH_ACR bits! ;
: flash-ws-mhz!  ( n -- )  #24 / flash-ws! ;
: flash-prefetch-on  ( -- )  PRFTBE FLASH_ACR bis! ;

$40021000 constant RCC_BASE
$00 RCC_BASE or constant RCC_CR
$1 #25 lshift  constant PLLRDY
$1 #24 lshift  constant PLLON
$1 #19 lshift  constant CSSON
$1 #18 lshift  constant HSEBYP
$1 #17 lshift  constant HSERDY
$1 #16 lshift  constant HSEON
$FF #8 lshift  constant HSICAL
$1F #3 lshift  constant HSITRIM
$1  #1 lshift  constant HSIRDY
$1             constant HSION

$04 RCC_BASE or constant RCC_CFGR
#1 #31 lshift  constant PLLNODIV
#3 #29 lshift  constant MCOPRE
#1 #28 lshift  constant MCOF
#7 #24 lshift  constant MCO
#1 #23 lshift  constant I2SSRC
#1 #22 lshift  constant USBPRE
$F #18 lshift  constant PLLMUL
#1 #17 lshift  constant PLLXTPRE
#1 #16 lshift  constant PLLSRC                \ PLL entry clock source 0:HSI/2 1:HSE/PREDIV
#7 #11 lshift  constant PPRE2                 \ APB high-speed prescaler (APB2) 0xx:HCLK/1 100:HCLK/2 101:HCLK/4 110:HCLK/8 111:HCLK/16
#7  #8 lshift  constant PPRE1                 \ APB Low-speed prescaler (APB2) 0xx:HCLK/1 100:HCLK/2 101:HCLK/4 110:HCLK/8 111:HCLK/16
$f  #4 lshift  constant HPRE
#3  #2 lshift  constant SWS
#3             constant SW

$14 RCC_BASE or constant RCC_AHBENR
#1 #29 lshift  constant ADC34EN
#1 #28 lshift  constant ADC12EN
#1 #24 lshift  constant TSCEN
#1 #22 lshift  constant IOPFEN
#1 #21 lshift  constant IOPEEN
#1 #20 lshift  constant IOPDEN
#1 #19 lshift  constant IOPCEN
#1 #18 lshift  constant IOPBEN
#1 #17 lshift  constant IOPAEN
#1  #6 lshift  constant CRCEN
#1  #4 lshift  constant FLITFEN
#1  #2 lshift  constant SRAMEN
#1  #1 lshift  constant DMA2EN
#1  #0 lshift  constant DMA1EN

$1C RCC_BASE or constant RCC_APB1ENR
#1 #29 lshift  constant DAC1EN
#1 #28 lshift  constant PWREN
#1 #26 lshift  constant DAC2EN
#1 #25 lshift  constant CANEN
#1 #23 lshift  constant USBEN
#1 #22 lshift  constant I2C2EN
#1 #21 lshift  constant I2C1EN
#1 #20 lshift  constant UART5EN
#1 #19 lshift  constant UART4EN
#1 #18 lshift  constant USART3EN
#1 #17 lshift  constant USART2EN
#1 #15 lshift  constant SPI3EN
#1 #14 lshift  constant SPI2EN
#1 #11 lshift  constant WWDGEN
#1 #5  lshift  constant TIM7EN
#1 #4  lshift  constant TIM6EN
#1 #2  lshift  constant TIM4EN
#1 #1  lshift  constant TIM3EN
#1 #0  lshift  constant TIM2EN


$2C RCC_BASE or constant RCC_CFGR2
$1F #9 lshift  constant ADC34PRES
$1F #4 lshift  constant ADC12PRES
$F             constant PREDIV

$30 RCC_BASE or constant RCC_CFGR3
#3 #22 lshift  constant UART5SW               \ UART5 clock source selection 00:PCLK 01:SYSCLK 10:LSE 11:HSI
#3 #20 lshift  constant UART4SW               \ UART4 clock source selection 00:PCLK 01:SYSCLK 10:LSE 11:HSI
#3 #18 lshift  constant USART3SW              \ USART3 clock source selection 00:PCLK 01:SYSCLK 10:LSE 11:HSI
#3 #16 lshift  constant USART2SW              \ USART2 clock source selection 00:PCLK 01:SYSCLK 10:LSE 11:HSI
#1  #9 lshift  constant TIM8SW
#1  #8 lshift  constant TIM1SW
#1  #5 lshift  constant I2C2SW
#1  #4 lshift  constant I2C1SW
#3  #0 lshift  constant USART1SW



: hsebyp-on  ( -- )  HSEBYP RCC_CR bis! ;
: hse-on  ( -- )  \ turn hse on with oscillator bypass external clock source
   hsebyp-on hseon RCC_CR bis! ;
: hsi-on  ( -- )  HSION RCC_CR bis! ;
: hsi-rdy?  ( -- f )  HSIRDY RCC_CR bit@ ;
: pll-off ( -- )  PLLON RCC_CR bic! ;
: hse-on?  ( -- f )  HSEON RCC_CR bit@ ;
: hse-rdy?  ( -- f )  HSERDY RCC_CR bit@ ;
: wait-hse  ( -- )  begin hse-on hse-rdy? until ;
: wait-hsi  ( -- )  begin hsi-on hsi-rdy? until ;
: clk-src-hsi  ( -- )  wait-hsi SW RCC_CFGR bic! ;
: usart1-clksrc!  ( u -- )  USART1SW RCC_CFGR3 bits! ;
: usart1-clksrc-hsi  ( -- )  #3 USART1SW RCC_CFGR3 bits! ;
: ppre2!  ( n -- )  PPRE2 RCC_CFGR bits! ;
: ppre1!  ( n -- )  PPRE1 RCC_CFGR bits! ;
: hpre!  ( n -- )  HPRE RCC_CFGR bits! ;
: prediv!  ( n -- )  PREDIV RCC_CFGR2 bits! ;
: pllmul!  ( n -- ) PLLMUL RCC_CFGR bits! ;
: pll-on  ( -- )  PLLON RCC_CR bis! ;
: pll-src-hse  ( -- )  PLLSRC RCC_CFGR bis! ;
: pll-rdy?  ( -- f )  PLLRDY RCC_CR bit@ ;
: wait-pllrdy ( -- )  begin pll-on pll-rdy? until ;
: clk-src-pll  ( -- )  $2 SW RCC_CFGR bits! ;
: clk-72M  ( -- )  wait-hsi clk-src-hsi pll-off
   flash-prefetch-on #72 flash-ws-mhz!
   usart1-clksrc-hsi \ attach usart1 to hsi -> 8mhz
   0 ppre2! #4 ppre1! 0 hpre!
   0 prediv! #9 pllmul!
   wait-hse pll-src-hse
   wait-pllrdy clk-src-pll ; 

\ gpio functions
: gpio-port-adr  ( n -- adr )  \ base address of gpio port nr a:0 b:1 c:2 d:3 e:4 f:5
   #10 lshift $48000000 or 1-foldable inline ;
: port-nr ( pinAdr -- nr )  #10 rshift $7 and 1-foldable inline ;
: gpio-port  ( pin -- adr )  $f not and 1-foldable inline ;
: gpio-rcc-ena-msk  ( adr -- n )  \ port_a .. port_f
   port-nr #17 + 1 swap lshift 1-foldable ;
: gpio-port-ena  ( adr -- )  \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bis! ;
: gpio-port-dis  ( adr -- )  \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bic! ;
: gpio-mode!  ( mode pin -- ) \ 00:input 01:output 10:alternate function 11:analog
   dup gpio-port >R $f and 2* #3 swap lshift R> bits! ;
: gpio-bsrr  ( pinAdr -- adr )  gpio-port $18 + 1-foldable inline ; \ calc gpio_bsrr address
: gpio-odr  ( pinAdr -- adr )  gpio-port $14 + 1-foldable inline ; \ calc gpio_odr address
: gpio-af   ( pinAdr -- adr ) dup gpio-port $20 + swap $8 and shr + 1-foldable ; 
: gpio-af-msk  ( pinAdr -- m ) $7 and $f swap lshift 1-foldable ;
: gpio-af!  ( afmode pin -- )   dup gpio-af-msk swap gpio-af bits! ;

#4 gpio-port-adr $20 +    constant GPIOE_AFRL
#4 gpio-port-adr          constant GPIOE_MODER
#4 gpio-port-adr gpio-odr constant GPIOE_ODR
#4 gpio-port-adr          constant PORT_E   
#1 gpio-port-adr          constant PORT_B

\ user leds
: led-init  ( -- )  PORT_E gpio-port-ena $5555 $ffff0000 PORT_E bits! ;
: led-on  ( n -- )  \ turn user led on 0..7
   #7 and #8 + 1 swap lshift PORT_E gpio-bsrr ! ;
: led-off  ( n -- )  \ turn user led off 0..7
   #7 and #24 + 1 swap lshift PORT_E gpio-bsrr ! ;
: led-test  ( -- )  led-init begin #8 0 do i dup led-off #3 + led-on #100000 0 do loop loop key? until ;
: leds-on  ( m -- )  \ turn on bitmask leds 
   $ff and #8 lshift PORT_E gpio-bsrr ! ;
: leds-off  ( m -- )  \ turn on bitmask leds 
   $ff and #24 lshift PORT_E gpio-bsrr ! ;
: leds-on-mask  ( n -- n )  \ led-on mask for gpioe_bsrr
   #7 and  #8 + 1 swap lshift 1-foldable ; 
: leds-off-mask  ( n -- n )  \ led-off mask for gpioe_bsrr
   #7 and #24 + 1 swap lshift 1-foldable ;
: leds-set-mask  ( n -- n )  \ led-on-off mask for gpioe_bsrr
   $FF and #8 lshift dup #16 lshift not $FF000000 and or 1-foldable ;
: leds-set  ( n -- )  \ set leds depending on bit position led0 - bit0 ... led7 - bit7
   leds-set-mask PORT_E gpio-bsrr ! ;
: leds-toggle  ( m -- )  \ toggle masked leds
   $ff and $8 lshift dup #16 lshift or \ expand mask ( -- $mm00mm00 )
   GPIOE_ODR @ $ff00 and dup #16 lshift
   swap not $ff00 and
   or and PORT_E gpio-bsrr ! ;

cornerstone accelfunc
\  acceleration sensor on i2c1 
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4
#6 PORT_B + constant PB6
#7 PORT_B + constant PB7
#4 PORT_E + constant PE4
#5 PORT_E + constant PE5

\ i2c functions
\ interrupt ids for i2c1 and i2c2
#47       constant I2C1_EV                    \ i2c event interrupd
#48       constant I2C1_ER                    \ i2c error interrupd
#49       constant I2C2_EV                    \ i2c event interrupd
#50       constant I2C2_ER                    \ i2c error interrupd
$40005400 constant I2C1_BASE
$40005400 constant I2C1

\ i2c configuration
I2C1      constant I2C_BASE
I2C1SW    constant I2CSW
I2C1_EV constant I2C_EV
I2C1_ER constant I2C_ER

$00           constant I2Cx_CR1   \ Control register 1
$1 #23 lshift constant PECEN      \ PEC enable
$1 #22 lshift constant ALERTEN    \ SMBus alert enable
$1 #21 lshift constant SMBDEN     \ SMBus Device Default address enable
$1 #20 lshift constant SMBHEN     \ SMBus Host address enable
$1 #19 lshift constant GCEN       \ General call enable
$1 #18 lshift constant WUPEN      \ Wakeup from Stop mode enable
$1 #17 lshift constant NOSTRETCH  \ Clock stretching disable
$1 #16 lshift constant SBC        \ Slave byte control
$1 #15 lshift constant RXDMAEN    \ DMA reception requests enable
$1 #14 lshift constant TXDMAEN    \ DMA transmission requests enable
$1 #12 lshift constant ANFOFF     \ Analog noise filter OFF
$f  #8 lshift constant DNF        \ Digital noise filter
$1  #7 lshift constant ERRIE      \ Error interrupts enable
$1  #6 lshift constant TCIE       \ Transfer Complete interrupt enable
$1  #5 lshift constant STOPIE     \ STOP detection Interrupt enable
$1  #4 lshift constant NACKIE     \ Not acknowledge received Interrupt enable
$1  #3 lshift constant ADDRIE     \ Address match Interrupt enable ( slave only )
$1  #2 lshift constant RXIE       \ RX Interrupt enable
$1  #1 lshift constant TXIE       \ TX Interrupt enable
$1            constant PE         \ Peripheral enable

$04 constant I2Cx_CR2             \ Control register 2
 $1 #26 lshift constant PECBYTE   \ Packet error checking byte
 $1 #25 lshift constant AUTOEND   \ Automatic end mode
 $1 #24 lshift constant RELOAD    \ NBYTES reload mode
$FF #16 lshift constant NBYTES    \ Number of bytes
 $1 #15 lshift constant NACK      \ NACK generation ( slave mode )
 $1 #14 lshift constant STOP      \ Stop generation ( master mode )
 $1 #13 lshift constant START     \ Start generation
 $1 #12 lshift constant HEAD10R   \ 10-bit address header only read direction ( master receiver mode )
 $1 #11 lshift constant ADD10     \ 10-bit addressing mode ( master mode )
 $1 #10 lshift constant RD_WRN    \ Transfer direction ( master mode )
 $3 #8  lshift constant SADD[9:8] \ Slave address bit 9:8 ( master mode )
$7F #1  lshift constant SADD[7:1] \ Slave address bit 7:1 ( master mode )
 $1            constant SADD0     \ Slave address bit 0 ( master mode )
$3FF           constant SADD      \ Slave address bit 9:0 ( master mode )

$10 constant I2Cx_TIMINGR         \ Timing register
 $F #28 lshift constant	PRESC     \ Timing prescaler
 $F #20 lshift constant SCLDEL    \ Data setup time
 $F #16 lshift constant SDADEL    \ Data hold time
$FF  #8 lshift constant SCLH      \ SCL high period
$FF            constant SCLL      \ SCL low period

I2C I2Cx_TIMINGR or constant I2C_TIMINGR


\ i2c driver supports master write / read with subaddress and multibyte read/write support
\ i2c state constants
\ i2c state machine for send and receive
\ every i2c port needs one task structure
\ task structure contains i2c base address of task so state machine knows which 
\ port to handle
\ state ids for i2c driver
0 enum   i2c-state-id-idle                    \ nothing to do here
enum     i2c-state-id-master-tx-start         \ initiate i2c - send start adress
enum     i2c-state-id-master-tx-sub           \ adress started - now transmit sub adress
enum     i2c-state-id-master-tx-data          \ transmit data bytes
enum     i2c-state-id-master-tx-wait-idle     \ when arbitration lost wait for stop and retry 
enum     i2c-state-id-master-rx-start         \ initiate i2c - send start adress
constant i2c-state-num-states                 \ number of i2c states

\ i2c task structure in RAM
struct{
  #1 field i2c-task-state                     \ 1 byte for state
  #2 field i2c-task-slave-adr                 \ 2 byte for slave address
  #1 field i2c-task-sub-adr                   \ 1 byte for i2c sub address
  #1 field i2c-task-num-bytes                 \ 1 byte for number of bytes to transfer
 #32 field i2c-task-xfer-buffer               \ 32 byte transfer buffer 
}struct i2c-task-struct-size

\ ************ i2c variables **********************
0               variable i2c-old-int-handler
i2c-task-struct-size buffer:  i2c-task-struct \ task handler for i2c

: i2c-clk-hsi-100khz  ( -- )                  \ i2c timing for HSI @ 100 kHz
   I2CSW RCC_CFGR3 bic!                       \ i2c on hsi clock
   1 PRESC  I2C_TIMINGR bits!                 \ timings from DM00043574.pdf: 26.4.9  I2Cx_TIMINGR register configuration examples
   $13 SCLL I2C_TIMINGR bits!
   $0F SCLH I2C_TIMINGR bits!
   $02 SDADEL I2C_TIMINGR bits!
   $04 SCLDEL I2C_TIMINGR bits! ;
: i2c-set-slave-adr  ( -- )                   \ set i2c1 slave address
   i2c-task-struct i2c-task-slave-adr + h@ 
   SADD I2Cx_CR2 I2C + bits! ;
: i2c-adr-mode-7-bit ( -- )
   ADD10 I2Cx_CR2 I2C + bic! inline ;
: i2c-xfer-mode-write ( -- )
   RD_WRN I2Cx_CR2 I2C + bic! inline ;
: i2c-task-state!  ( n -- )
   i2c-task-struct i2c-task-state + ! inline ;
: i2c-set-start ( -- )
   PE I2C bis !
   START I2Cx_CR2 I2C + bit! inline ;
: i2c-state-idle ( -- ) ;                     \ i2c idle function
: i2c-state-master-tx-start  ( tadr -- tadr ) \ start write transfer
   i2c-adr-mode-7-bit
   i2c-xfer-mode-write
   i2c-set-slave-adr
   i2c-state-id-master-tx-sub i2c-task-state!
   i2c-set-start ;
: i2c-state-master-tx-wait-start ( -- ) ;     \ wait for start complete
: i2c-state-master-tx-wait-start ( -- ) ;     \ wait for start complete
: i2c-active-task-struct  ( -- a )            \ active i2c task-buffer or 0
   ipsr I2C_EV = ipsr I2C_ER = or             \ i2c1 event or error
   i2c-task-struct and   or ;
ftab: i2c-state-table                         \ state id to function translation
   ' i2c-state-idle ,                         \ nothing to do here
   ' i2c-state-master-tx-start ,              \ initiate i2c - send start adress
   ' i2c-state-master-tx-sub ,                \ adress started - now transmit sub adress
   ' i2c-state-master-tx-data ,               \ transmit data bytes
   ' i2c-state-master-tx-wait-idle ,          \ when arbitration lost wait for stop and retry 
   ' i2c-state-master-rx-start ,              \ initiate i2c - send start adress
: i2c-state-dispatch ( tadr -- )              \ dispatch to state
   i2c-task-state@
   dup i2c-state-num-states < and
   i2c-state-table ;
: i2c-irq-chain  ( -- )                       \ invoke original irq handler
    i2c-old-int-handler @
    dup 0<> if execute then ;
: i2c-irq-handler  ( -- )                     \ interrupt handler for i2c1 must not change stack
   i2c-active-task-struct dup 0<>             \ if valid interrupt
   if i2c-state-dispatch                      \ perform dispatch
   else drop i2c-irq-chain then ;             \ else leave isr
: i2c-irq-handler-install  ( -- )             \ install i2c irq handler
   irq-collection @ i2c-old-int-handler !     \ save old irq handler
   ['] i2c-irq-handler irq-collection ! ;     \ install i2c handler
: i2c1-init  ( -- )                           \ i2c 100 khz 8 Mhz HSI
   $200000 RCC_APB1ENR bis!                   \ enable i2c1
   i2c-clk-hsi-100khz
   i2c-irq-handler-install ;


: accel-init  ( -- )  \ initialize acceleration sensor
   PORT_B gpio-port-ena
   PORT_E gpio-port-ena                     \ port e enable
   #2 PB6 gpio-mode!                        \ PB6 af mode
   #2 PB7 gpio-mode!                        \ PB7 af mode
   #0 PE4 gpio-mode!                        \ PE4 input mode
   #0 PE5 gpio-mode!                        \ PB7 input mode
   #4 PB6 gpio-af!
   #4 PB7 gpio-af!
   ;
\ : accel-x  ( -- n )  \ return accel sensor x value
\   0 ; 
\ : accel-y  ( -- n )  \ return accel sensor y value
\   0 ; 
\ : accel-z  ( -- n )  \ return accel sensor z value
\   0 ; 

\ : read-accel  ( vadr -- )  \ store acceleration data to vector   
\   accel-x over ! accel-y over 4 + ! accel-z swap 8 + ! ;

: bits3! ( v m a -- )
   -rot swap
   over cnt0 lshift over and  ( -- a m vm )
   swap not ( -- a vm /m )
   2 pick @ and   ( -- )
   or swap ! ;
   
   

\ systick.update

\ state = ready
\ state = update_entry
\ read Count_flag
\ state = countflag_read
\ state = read timer val
\ read timer val
\ state write timer-val
\ write-timer
\ state = ready
