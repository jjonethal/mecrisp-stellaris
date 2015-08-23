\ demo.fth
\ STM32F303VCT6 F3Discovery Board demo

\ Documents
\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"
\ L3GD20     "C:\Users\jeanjo\Downloads\stm\DM00036465 L3GD20.pdf"
\ LSM303DLHC "C:\Users\jeanjo\Downloads\stm\DM00027543-LSM303DLHC.pdf"
\ i2c spec   "http://www.nxp.com/documents/user_manual/UM10204.pdf"


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
\ CS_I2C_SPI        - PE3
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

\ Register definitions

$40005400 constant I2C1_BASE
$40005800 constant I2C2_BASE
$00 constant I2Cx_CR1            \ Control register 1
$1 #23 lshift constant PECEN     \ PEC enable
$1 #22 lshift constant ALERTEN   \ SMBus alert enable
$1 #21 lshift constant SMBDEN    \ SMBus Device Default address enable
$1 #20 lshift constant SMBHEN    \ SMBus Host address enable
$1 #19 lshift constant GCEN      \ General call enable
$1 #18 lshift constant WUPEN     \ Wakeup from Stop mode enable
$1 #17 lshift constant NOSTRETCH \ Clock stretching disable
$1 #16 lshift constant SBC       \ Slave byte control
$1 #15 lshift constant RXDMAEN   \ DMA reception requests enable
$1 #14 lshift constant TXDMAEN   \ DMA transmission requests enable
$1 #12 lshift constant ANFOFF    \ Analog noise filter OFF
$f  #8 lshift constant DNF       \ Digital noise filter
$1  #7 lshift constant ERRIE     \ Error interrupts enable
$1  #6 lshift constant TCIE      \ Transfer Complete interrupt enable
$1  #5 lshift constant STOPIE    \ STOP detection Interrupt enable
$1  #4 lshift constant NACKIE    \ Not acknowledge received Interrupt enable
$1  #3 lshift constant ADDRIE    \ Address match Interrupt enable ( slave only )
$1  #2 lshift constant RXIE      \ RX Interrupt enable
$1  #1 lshift constant TXIE      \ TX Interrupt enable
$1                     PE        \ Peripheral enable

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
$14 constant I2Cx_TIMEOUTR
$18 constant I2Cx_ISR
$1C constant I2Cx_ICR
$20 constant I2Cx_PECR
$24 constant I2Cx_RXDR
$28 constant I2Cx_TXDR

$40022000 constant FLASH_BASE
$00 FLASH_BASE or constant FLASH_ACR
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
#1 #16 lshift  constant PLLSRC
#7 #11 lshift  constant PPRE2
#7  #8 lshift  constant PPRE1
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
#3 #22 lshift  constant UART5SW
#3 #20 lshift  constant UART4SW
#3 #18 lshift  constant USART3SW
#3 #16 lshift  constant USART2SW
#1  #9 lshift  constant TIM8SW
#1  #8 lshift  constant TIM1SW
#1  #5 lshift  constant I2C2SW
#1  #4 lshift  constant I2C1SW
#3  #0 lshift  constant USART1SW

\ utility functions 
: cnt0   ( m -- b )          \ count trailing zeros with hw support
   dup negate and 1-
   clz negate #32 + ;
: bits@  ( m adr -- b )      \ get bits a masked position
   @ over and swap cnt0 rshift ;
: bits!  ( n m adr -- )      \ set masked bits at position
   >R dup >R cnt0 lshift     \ shift value to proper pos
   R@ and                    \ mask out unrelated bits
   R> not R@ @ and           \ invert bitmask and makout new bits
   or r> ! ;                 \ apply value and store back
: 

