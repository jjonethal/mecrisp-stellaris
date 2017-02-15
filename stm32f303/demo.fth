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
\                T      CS SPC SDI SDO            
\ Idle           0      H   X   X   X
\ before start  +Thcs   H   H   X   X  
\ on start      +Thcs   L   H   X   X  setup SDI
\ c1 start      +Tsucs  L   L  DIH  X  setup SDI
\ wait-Tsu(cs)  CS - L SPC - H SDI-X SDO-X
\ after-Tsu(cs) CS - L SPC - L SDI-X SDO-X

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



\ Register definitions

$40005400 constant I2C1_BASE
$40005800 constant I2C2_BASE
$00 constant I2Cx_CR1             \ Control register 1
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
$1                     PE         \ Peripheral enable

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

$08 constant I2Cx_OAR1            \ Own address 1 register
 $1 #15 lshift constant OA1EN     \ Own Address 1 enable
 $1 #10 lshift constant OA1MODE   \ Own Address 1 10-bit mode
 $3  #8 lshift constant OA1[9:8]  \ Interface address
$7F  #1 lshift constant OA1[7:1]  \ Interface address
 $1            constant OA1[0]    \ Interface address
$3ff           constant OA1       \ Interface address [9:0]

$0C constant I2Cx_OAR2            \ Own address 2 register
 $1 #15 lshift constant OA2EN     \ Own Address 2 enable
 $7 #15 lshift constant OA2MSK    \ Own Address 2 masks
$7F #1  lshift constant OA2[7:1]  \ Interface address ( bits 7:1 of address )

$10 constant I2Cx_TIMINGR         \ Timing register
 $F #28 lshift constant	PRESC     \ Timing prescaler
 $F #20 lshift constant SCLDEL    \ Data setup time
 $F #16 lshift constant SDADEL    \ Data hold time
$FF  #8 lshift constant SCLH      \ SCL high period
$FF            constant SCLL      \ SCL low period
 
$14 constant I2Cx_TIMEOUTR
$18 constant I2Cx_ISR
$1C constant I2Cx_ICR
$20 constant I2Cx_PECR
$24 constant I2Cx_RXDR
$28 constant I2Cx_TXDR

$40022000 constant FLASH_BASE
$00 FLASH_BASE or constant FLASH_ACR
$1 #5 lshift constant PRFTBS
$1 #4 lshift constant PRFTBE
$1 #3 lshift constant HLFCYA
$7           constant LATENCY

$04 FLASH_BASE or constant FLASH_KEYR
$08 FLASH_BASE or constant FLASH_OPTKEYR
$0C FLASH_BASE or constant FLASH_SR
$10 FLASH_BASE or constant FLASH_CR
$14 FLASH_BASE or constant FLASH_AR
$1C FLASH_BASE or constant FLASH_OBR
$20 FLASH_BASE or constant FLASH_WRPR

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

$08 RCC_BASE or constant RCC_CIR
#1 #23 lshift  constant CSSC
#1 #20 lshift  constant PLLRDYC
#1 #19 lshift  constant HSERDYC
#1 #18 lshift  constant HSIRDYC
#1 #17 lshift  constant LSERDYC
#1 #16 lshift  constant LSIRDYC
#1 #12 lshift  constant PLLRDYIE
#1 #11 lshift  constant HSERDYIE
#1 #10 lshift  constant HSIRDYIE
#1  #9 lshift  constant LSERDYIE
#1  #8 lshift  constant LSIRDYIE
#1  #7 lshift  constant CSSF
#1  #4 lshift  constant PLLRDYF
#1  #3 lshift  constant HSERDYF
#1  #2 lshift  constant HSIRDYF
#1  #1 lshift  constant LSERDYF
#1             constant LSIRDYF

$0C RCC_BASE or constant RCC_APB2RSTR
#1 #18 lshift  constant TIM17RST
#1 #17 lshift  constant TIM16RST
#1 #16 lshift  constant TIM15RST
#1 #14 lshift  constant USART1RST
#1 #13 lshift  constant TIM8RST
#1 #12 lshift  constant SPI1RST
#1 #11 lshift  constant TIM1RST
#1             constant SYSCFGRST

$10 RCC_BASE or constant RCC_APB1RSTR
#1 #29 lshift  constant DAC1RST
#1 #28 lshift  constant PWRRST
#1 #26 lshift  constant DAC2RST
#1 #25 lshift  constant CANRST
#1 #23 lshift  constant USBRST
#1 #22 lshift  constant I2C2RST
#1 #21 lshift  constant I2C1RST
#1 #20 lshift  constant UART5RST
#1 #19 lshift  constant UART4RST
#1 #18 lshift  constant USART3RST
#1 #17 lshift  constant USART2RST
#1 #15 lshift  constant SPI3RST
#1 #14 lshift  constant SPI2RST
#1 #11 lshift  constant WWDGRST
#1 #5  lshift  constant TIM7RST
#1 #4  lshift  constant TIM6RST
#1 #2  lshift  constant TIM4RST
#1 #1  lshift  constant TIM3RST
#1 #0  lshift  constant TIM2RST

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

$18 RCC_BASE or constant RCC_APB2ENR
#1 #18 lshift  constant TIM17EN
#1 #17 lshift  constant TIM16EN
#1 #16 lshift  constant TIM15EN
#1 #14 lshift  constant USART1EN
#1 #13 lshift  constant TIM8EN
#1 #12 lshift  constant SPI1EN
#1 #11 lshift  constant TIM1EN
#1             constant SYSCFGEN

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

$20 RCC_BASE or constant RCC_BDCR
#1 #16 lshift  constant BDRST
#1 #15 lshift  constant RTCEN
#3  #8 lshift  constant RTCSEL
#3  #3 lshift  constant LSEDRV
#1  #2 lshift  constant LSEBYP
#1  #1 lshift  constant LSERDY
#1  #0 lshift  constant LSEON

$24 RCC_BASE or constant RCC_CSR
#1 #31 lshift  constant LPWRSTF
#1 #30 lshift  constant WWDGRSTF
#1 #29 lshift  constant IWDGRSTF
#1 #28 lshift  constant SFTRSTF
#1 #27 lshift  constant PORRSTF
#1 #26 lshift  constant PINRSTF
#1 #25 lshift  constant OBLRSTF
#1 #24 lshift  constant RMVF
#1  #1 lshift  constant LSIRDY
#1  #0 lshift  constant LSION

$28 RCC_BASE or constant RCC_AHBRSTR
#1 #29 lshift  constant ADC34RST
#1 #28 lshift  constant ADC12RST
#1 #24 lshift  constant TSCRST
#1 #22 lshift  constant IOPFRST
#1 #21 lshift  constant IOPERST
#1 #20 lshift  constant IOPDRST
#1 #19 lshift  constant IOPCRST
#1 #18 lshift  constant IOPBRST
#1 #17 lshift  constant IOPARST

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

\ utility functions 
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

\ flash functions
: flash-ws!  ( n -- )  LATENCY FLASH_ACR bits! ;
: flash-ws-mhz!  ( n -- )  #24 / flash-ws! ;
: flash-prefetch-on ( -- )  PRFTBE FLASH_ACR bis! ;

\ clock functions
: hse-on?  ( -- f )  hseon rcc_cr bit@ ;
: hse-rdy?  ( -- f )  HSERDY rcc_cr bit@ ;
: hsi-rdy?  ( -- f )  HSIRDY rcc_cr bit@ ;
: hsebyp-on!  ( -- )  hsebyp rcc_cr bis! ;
: hsebyp-on?  ( -- f )  hsebyp rcc_cr bit@ ;
: hse-on!  ( -- )  \ turn hse on with oscillator bypass external clock source
   hsebyp-on! hseon rcc_cr bis! ;
: hsi-on!  ( -- )  hsion rcc_cr bis! ;
: wait-hse  ( -- )  begin hse-on! hse-rdy? until ;
: wait-hsi  ( -- )  begin hsi-on! hsi-rdy? until ;
: pll-on!  ( -- )  PLLON RCC_CR bis! ;
: pll-on?  ( -- f )  PLLON RCC_CR bit@ ;
: pll-off! ( -- )  PLLON RCC_CR bic! ;
: pll-rdy?  ( -- f )  PLLRDY RCC_CR bit@ ;
: wait-pllrdy ( -- )  begin pll-on! pll-rdy? until ;
: pll-src-hse!  ( -- )  PLLSRC RCC_CFGR bis! ; 
: pll-src-hsi!  ( -- )  PLLSRC RCC_CFGR bic! ; 
: pll-src-hse?  ( -- f )  PLLSRC RCC_CFGR bit@ ; 
: pll-src-hsi?  ( -- f )  pll-src-hse? not ;
: prediv!  ( n -- )  PREDIV RCC_CFGR2 bits! ;
: pllmul!  ( n -- ) pllmul RCC_CFGR bits! ;
: hpre!  ( n -- )  hpre RCC_CFGR bits! ;
: ppre1!  ( n -- )  ppre1 RCC_CFGR bits! ;
: ppre2!  ( n -- )  ppre2 RCC_CFGR bits! ;
: ppre-bbb->div  ( u -- u )  \ ppre1,2 reg val to divider (1,2,4,8,16)
   dup #4 and shr swap #3 and lshift dup 0= 1 and or ;
: ppre-div->bbb  ( u -- u )  \ ppre1,2 reg val to divider (1,2,4,8,16)
   clz negate #31 + dup 0< #4 and or ;
: clk-src-hsi  ( -- )  wait-hsi SW RCC_CFGR bic! ;
: clk-src-hse  ( -- )  hse-on! $1 SW RCC_CFGR bits! ;
: clk-src-pll  ( -- )  $2 SW RCC_CFGR bits! ;
: clk-src?  ( -- u )  sws RCC_CFGR bits@ ;
: usart1-clksrc!  ( u -- )  USART1SW rcc_cfgr3 bits! ;
: clk-72M  ( -- )  wait-hsi clk-src-hsi pll-off!
   flash-prefetch-on #72 flash-ws-mhz!
   #3 usart1-clksrc! \ attach usart1 to hsi -> 8mhz
   0 ppre2! #4 ppre1! 0 hpre!
   0 prediv! #9 pllmul!
   wait-hse pll-src-hse!
   wait-pllrdy clk-src-pll ; 

\ gpio functions
: gpio-port  ( n -- adr )  \ base address of gpio port nr a:0 b:1 c:2 d:3 e:4 f:5
   #10 lshift $48000000 or 1-foldable ;
: gpio-rcc-ena-msk  ( n -- n )  \ port A:0 .. F:5
   #17 + 1 swap lshift $007e0000 and 1-foldable ;
: gpio-port-ena  ( n -- )  \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bis! ;
: gpio-port-dis  ( adr -- )  \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bic! ;
: gpio-mode!  ( mode pin port -- ) \ 00:input 01:output 10:alternate function 11:analog
   gpio-port >R #3 swap 2* lshift R> bits! ;
: gpio-bsrr  ( n -- adr )  gpio-port $18 + 1-foldable ; \ calc gpio_bsrr address
: gpio-odr  ( n -- adr )  gpio-port $14 + 1-foldable ; \ calc gpio_odr address
#4 gpio-port $20 + constant GPIOE_AFRL
#4 gpio-port       constant GPIOE_MODER
#4 gpio-odr        constant GPIOE_ODR

\ user leds
: led-init  ( -- )  #4 gpio-port-ena $5555 $ffff0000 4 gpio-port bits! ;
: led-on  ( n -- )  \ turn user led on 0..7
   #7 and #8 + 1 swap lshift #4 gpio-bsrr ! ;
: led-off  ( n -- )  \ turn user led off 0..7
   #7 and #24 + 1 swap lshift #4 gpio-bsrr ! ;
: led-test  ( -- )  led-init begin #8 0 do i dup led-off #3 + led-on #100000 0 do loop loop key? until ;
: leds-on  ( m -- )  \ turn on bitmask leds 
   $ff and #8 lshift #4 gpio-bsrr ! ;
: leds-off  ( m -- )  \ turn on bitmask leds 
   $ff and #24 lshift #4 gpio-bsrr ! ;
: leds-on-mask  ( n -- n )  \ led-on mask for gpioe_bsrr
   #7 and  #8 + 1 swap lshift 1-foldable ; 
: leds-off-mask  ( n -- n )  \ led-off mask for gpioe_bsrr
   #7 and #24 + 1 swap lshift 1-foldable ;
: leds-set-mask  ( n -- n )  \ led-on-off mask for gpioe_bsrr
   $FF and #8 lshift dup #16 lshift not $FF000000 and or 1-foldable ;
: leds-set  ( n -- )  \ set leds depending on bit position led0 - bit0 ... led7 - bit7
   leds-set-mask #4 gpio-bsrr ! ;
: leds-toggle  ( m -- )  \ toggle masked leds
   $ff and $8 lshift dup #16 lshift or \ expand mask ( -- $mm00mm00 )
   GPIOE_ODR @ $ff00 and dup #16 lshift
   swap not $ff00 and
   or and #4 gpio-bsrr ! ;
   
\ timer 16 system cycle counter
$40014400 constant TIM16_BASE
$40014400 constant TIM16_CR1
$40014800 constant TIM17_BASE
0             constant TIMx_CR1
#1 #11 lshift constant UIFREMAP               \ UIF status bit remapping to TIMxCNT[31]
#3  #8 lshift constant CKD                    \ Clock division ratio CK_INT and dead-time and sampling clock 00:/1 01:/2 10:/4 11:reserved
#1  #7 lshift constant ARPE                   \ Auto-reload preload enable
#1  #3 lshift constant OPM                    \ One pulse mode
#1  #2 lshift constant URS                    \ Update request source
1   #1 lshift constant UDIS                   \ Update disable
1             constant CEN                    \ Counter enable   
$24 TIM16_BASE + constant TIM16_CNT           \ TIM16 counter (TIMx_CNT)
$28 TIM16_BASE + constant TIM16_PSC           \ TIM16 prescaler (TIMx_PSC)
$2C TIM16_BASE + constant TIM16_ARR           \ TIM16 auto-reload register
$34 TIM16_BASE + constant TIM16_CCR1          \ TIM16 capture/compare register 1
0 0 2variable tim16-long-time                 \ accumulated time
0   variable  tim16-last-time
0 0 2variable tim16-trigger-time
0   variable  tim16-irq-org-handler

: tim16-off  ( -- ) 0 TIM16_BASE ! ;
: tim16-reset  ( -- )                         \ reset timer 16
   1 #17 lshift RCC_APB2RSTR bis! ;
: tim16-unreset  ( -- )                       \ unreset timer 16
   1 #17 lshift RCC_APB2RSTR bic! ;
: tim16-clk-ena  ( -- )                       \ enable clock for timer 16
   1 #17 lshift RCC_APB2ENR bis! ;
: tim16-clk-dis  ( -- )                       \ disable clock for timer 16
   1 #17 lshift RCC_APB2ENR bic! ;
: tim16-ena ( -- )
   1 tim16_cr1 bis! ;
: tim16-dis ( -- )
   1 tim16_cr1 bic! ;
: tim16-ccr-update ( -- )
: tim16-expire ( -- )
   tim16-trigger-time 2@ tim16-long-time 2@ d-
   0< 
: tim16-handler  ( -- )                       \ handle timer 16 interrupt
   TIM16_CNT @ dup tim16-last-time @ -        \ delta T
   dup 0< #65536 and +                        \ wrap around is 65536
   0 tim16-long-time 2@ d+ tim16-long-time 2! \ update long time
   dup tim16-last-time !                      \ store last counter value
   tim16-ccr-update ;                         \ set ccr forward 
: tim16-irq-dispatch ( -- )                   \ run int 20 on tim16-handler others on chain
   ipsr @ #20 = dup ['] tim16-handler and
   swap not tim16-irq-org-handler @ and or
   execute ;
: tim16-install-irq-handler  ( -- )
   ['] tim16-irq-dispatch irq-collection dup @ tim16-irq-org-handler ! ! ;

: timer16-init  ( -- )                        \ initialize timer 16
   tim16-reset
   tim16-clk-ena
   tim16-unreset
   #7200 TIM16_PSC !                          \ 10 khz timer resolution
   $FFFF TIM16_ARR !                          \ auto-reload value $ffff
   $7FFF TIM16_CCR1 !                         \ set capture interrupt to half of range
   tim16-ena ;
   
\ application variables
0 variable gyro-x
0 variable gyro-y
0 variable gyro-z
0 variable accel-x
0 variable accel-y
0 variable accel-z
0 variable compass-x
0 variable compass-y
0 variable compass-z

\ port definitions 
#0 gpio-port constant port-a
#1 gpio-port constant port-b
#2 gpio-port constant port-d
#3 gpio-port constant port-d
#4 gpio-port constant port-e

\ pin definitions
#5 port-a or constant PA5
#6 port-a or constant PA6
#7 port-a or constant PA7
#0 port-e or constant PE0
#1 port-e or constant PE1
#5 port-e or constant PE5
#6 port-e or constant PE6
#7 port-e or constant PE7

: display-draw-mask draw-border 
\  "          1         2         3         5      "
\  "01234567890123456789012345678901234567890123456"
\  "***********************************************"
\  "*  Accel X:##### Gyro X:##### Compass X:##### *"
\  "*  Accel Y:##### Gyro Y:##### Compass Y:##### *"
\  "*  Accel Z:##### Gyro Z:##### Compass Z:##### *"
\  "***********************************************"
   3 3 AT-YX ." Accel X:"
   3 3 AT-YX ." Accel Y:"
   3 3 AT-YX ." Accel Z:"
   ;
: display-draw-values ;
: display-draw-curve ;

\ *** pin functions  
\ **** pin = GPIOx_BASE + PinNr e.g.: Pin PE1 = $48001001 = $48001000(GPIOE) + 1(PIN1)
: pin-gpio-adr  ( pin -- gpio-base )  \ mask gpio base from pin-id    
   $F not and inline 1-foldable ;
: pin-af-adr ( pin -- gpio-af-adr ) \ alternate function reg adr
   dup $8 and 0<> $4 and swap pin-gpio-adr $20 + + 1-foldable ; \ TODO gpio-modereg-af
: pin-af!  ( af pin -- )  \ set alternate function for pin
   dup pin-af-adr >R  \ store AFRL/H
   $7 and $2 lshift $F swap lshift \ generate mask
   R> bits! ;
: pin-mode!  ( mode pin -- )  \ set pin mode 00:input 01:output 10:alternate function 11:analog
   dup $f and swap $f not and gpio-mode! ; 

\ *** gyro handler
: aquire-gyro-data  ( -- x y z )  0 0 0 ;

\ *** compass handler
: aquire-compass-data  ( -- x y z )  0 0 0 ;

\ *** acceleration handler
: aquire-accel-data  ( -- x y z )  0 0 0 ;

: init-i2c ;
: init-spi ;
: init-usb ;

: init-gyro-pins  ( -- )  \ initialize pins for gyro
   #3 PA5 pin-mode!	#5 PA5 pin-af! \ SPI1_SCK
   #3 PA6 pin-mode!	#5 PA6 pin-af! \ SPI1_MISO
   #3 PA7 pin-mode!	#5 PA7 pin-af! \ SPI1_MOSI
   #1 PE3 pin-mode!                \ cs-output
   #0 PE0 pin-mode!                \ MEMS_INT1
   #0 PE1 pin-mode! ;              \ MEMS_INT2
: init-gyro ( -- )
   init-gyro-pins
   init-spi1 ;
: init-accel ;
: init-compass ;
: init-timer ;
: init-clock ;

: main 
   init start-tasks ;
