\ usb.fth
\ usb interface
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
: set-mask!  ( v m a -- )
  tuck @ swap not and rot or swap ! ;
    


\ project specific value
#8000000 constant HSE_CLOCK_HZ \ provided from 
#8000000 constant HSI_CLOCK_HZ

\ ********** gpio functions ******************
\ pin = gpiox_base_adr + pinNr
\ gpio functions
$48000000 constant GPIO_BASE
: gpio-port-adr  ( n -- adr )                 \ base address of gpio port nr a:0 b:1 c:2 d:3 e:4 f:5
   #10 lshift GPIO_BASE or 1-foldable inline ;
: gpio-port-nr ( pinAdr -- nr )  #10 rshift $7 and 1-foldable inline ;
: gpio-port  ( pin -- adr )  $f not and 1-foldable inline ;
: gpio-rcc-ena-msk  ( adr -- n )              \ port_a .. port_f
   gpio-port-nr #17 + 1 swap lshift 1-foldable ;
: gpio-port-ena  ( adr -- )                   \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bis! ;
: gpio-port-dis  ( adr -- )                   \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bic! ;
: gpio-mode!  ( mode pin -- )                 \ 0:input 1:output 2:alternate function 3:analog
   dup gpio-port >R $f and 2* #3 swap lshift R> bits! ;
: gpio-otype!  ( mode pin -- )                \ set ouput type 0: push-pull 1:open drain
   dup gpio-port #4 + >R $f and #1 swap lshift R> bits! ;
: gpio-pupd!  ( mode pin -- )                 \ 0:no pupd 1:pu 2:pd 3:reserved
   dup gpio-port >R $f and 2* #3 swap lshift R> bits! ;
: gpio-bsrr  ( pinAdr -- adr )  gpio-port $18 + 1-foldable inline ; \ calc gpio_bsrr address
: gpio-bsrr-set ( pinAdr -- m ) $f and 1 swap lshift 1-foldable ;
: gpio-bsrr-clr ( pinAdr -- m ) $f and #16 + 1 swap lshift 1-foldable ;
: gpio-odr  ( pinAdr -- adr )  gpio-port $14 + 1-foldable inline ; \ calc gpio_odr address
: gpio-af   ( pinAdr -- adr ) dup gpio-port $20 + swap $8 and shr + 1-foldable ; 
: gpio-af-shift ( pinAdr -- sw ) $7 and 2 lshift 1-foldable inline ;
: gpio-af-msk  ( pinAdr -- m ) gpio-af-shift $f swap lshift 1-foldable ;
: gpio-af!  ( afmode pin -- )   dup gpio-af-msk swap gpio-af bits! ;


\ ********** flash functions *****************
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

\ ********** nvic registers ******************
$E000E100      constant NVIC_ISER0            \ Interrupt set-enable registers
$E000E180      constant NVIC_ICER0            \ Interrupt clear-enable registers
$E000E280      constant NVIC_ICPR0            \ Interrupt clear-pending registers
NVIC_ICPR0 4 + constant NVIC_ICPR1
NVIC_ICPR0 8 + constant NVIC_ICPR2
\ calculate nvic enable disable mask from ipsr number
\ ipsr "vector number" is
\ interrupt position + 16 or vector_address / 4
: nvic-mask  ( n -- n )                       \ calculate mask for nvic vector number
   #16 - $1f and 1 swap lshift 1-foldable ;
: nvic-offset  ( n -- n )                     \ nvic register offset depending on vector number
   #16 - #5 rshift #2 lshift 1-foldable ;
: nvic-enable-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ISER0 + ! ;
: nvic-disable-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ICER0 + ! ;
: nvic-clear-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ICPR0 + ! ;

\ ********** RCC handling ********************
$40021000 constant RCC_BASE
$00 RCC_BASE + constant RCC_CR
#1 #25 lshift  constant PLLRDY
#1 #24 lshift  constant PLLON
#1 #19 lshift  constant CSSON
#1 #18 lshift  constant HSEBYP
#1 #17 lshift  constant HSERDY
#1 #16 lshift  constant HSEON
$FF #8 lshift  constant HSICAL
$1F #3 lshift  constant HSITRIM
#1  #1 lshift  constant HSIRDY
#1             constant HSION

$04 RCC_BASE + constant RCC_CFGR
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

$08 RCC_BASE + constant RCC_CIR
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

$0C RCC_BASE + constant RCC_APB2RSTR
#1 #18 lshift  constant TIM17RST
#1 #17 lshift  constant TIM16RST
#1 #16 lshift  constant TIM15RST
#1 #14 lshift  constant USART1RST
#1 #13 lshift  constant TIM8RST
#1 #12 lshift  constant SPI1RST
#1 #11 lshift  constant TIM1RST
#1             constant SYSCFGRST

$10 RCC_BASE + constant RCC_APB1RSTR
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

$14 RCC_BASE + constant RCC_AHBENR
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

$18 RCC_BASE + constant RCC_APB2ENR
#1 #18 lshift  constant TIM17EN
#1 #17 lshift  constant TIM16EN
#1 #16 lshift  constant TIM15EN
#1 #14 lshift  constant USART1EN
#1 #13 lshift  constant TIM8EN
#1 #12 lshift  constant SPI1EN
#1 #11 lshift  constant TIM1EN
#1             constant SYSCFGEN

$1C RCC_BASE + constant RCC_APB1ENR
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

$20 RCC_BASE + constant RCC_BDCR
#1 #16 lshift  constant BDRST
#1 #15 lshift  constant RTCEN
#3  #8 lshift  constant RTCSEL
#3  #3 lshift  constant LSEDRV
#1  #2 lshift  constant LSEBYP
#1  #1 lshift  constant LSERDY
#1  #0 lshift  constant LSEON

$24 RCC_BASE + constant RCC_CSR
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

$28 RCC_BASE + constant RCC_AHBRSTR
#1 #29 lshift  constant ADC34RST
#1 #28 lshift  constant ADC12RST
#1 #24 lshift  constant TSCRST
#1 #22 lshift  constant IOPFRST
#1 #21 lshift  constant IOPERST
#1 #20 lshift  constant IOPDRST
#1 #19 lshift  constant IOPCRST
#1 #18 lshift  constant IOPBRST
#1 #17 lshift  constant IOPARST

$2C RCC_BASE + constant RCC_CFGR2
$1F #9 lshift  constant ADC34PRES
$1F #4 lshift  constant ADC12PRES
$F             constant PREDIV

$30 RCC_BASE + constant RCC_CFGR3
#3 #22 lshift  constant UART5SW
#3 #20 lshift  constant UART4SW
#3 #18 lshift  constant USART3SW
#3 #16 lshift  constant USART2SW
#1  #9 lshift  constant TIM8SW
#1  #8 lshift  constant TIM1SW
#1  #5 lshift  constant I2C2SW
#1  #4 lshift  constant I2C1SW
#3  #0 lshift  constant USART1SW


: pll-hse-72-mhz ( -- )
   72 8 / 2-  PLLMUL RCC_CFGR bits!           \ PLLMUL 9 
   PREDIV RCC_CFGR2 bic! ;                    \ prediv = /1
: APB2/1 ( -- )  PPRE2 RCC_CFGR bic! ;        \ APB2-clk = sysclk
: APB1/2 ( -- )  #4 PPRE1 RCC_CFGR bits! ;    \ APB2-clk = sysclk/2
: AHB/1  ( -- )   HPRE RCC_CFGR bic! ;        \ SYSCLk = PLL-CLK
: usb-pre-1.5  ( -- )  USBPRE RCC_CFGR bic! ; \ USB-CLK = PLL-CLK/1.5
: flash-setup-72-mhz  ( -- )                  \ prefetch on, latency 2, halfcycle off
  FLASH_ACR @
  PRFTBE HLFCYA or LATENCY or not and         \ clear bitmask
  PRFTBE 2 or FLASH_ACR ! ;
: hse-on       ( -- )
   HSEBYP RCC_CR bis! 
   HSEON RCC_CR bis! ;
: hse-on?      ( -- f ) HSERDY RCC_CR bit@ ;
: hse-on-wait  ( -- )   hse-on begin hse-on? until ;
: hsi-on       ( -- )   HSION RCC_CR bis! ;
: hsi-on?      ( -- f ) HSIRDY RCC_CR bit@ ;
: hsi-wait-on  ( -- )   hsi-on begin hsi-on? until ;
: pll-off      ( -- )   PLLON RCC_CR bic! ;
: pll-on       ( -- )   PLLON RCC_CR bis! ;
: pll-on?      ( -- f ) PLLRDY RCC_CR bit@ ;
: pll-on-wait  ( -- )   pll-on begin pll-on? until ;   
: pll-hse      ( -- )   PLLSRC RCC_CFGR bis! ;
: pll-hsi      ( -- )   PLLSRC RCC_CFGR bic! ;
: usart1-hsi   ( -- )   USART1SW RCC_CFGR3 bis! ;
: sys-clk-hsi  ( -- )   SW RCC_CFGR bic! ;
: sys-clk-hse  ( -- )   1 SW RCC_CFGR bits! ;
: sys-clk-pll  ( -- )   2 SW RCC_CFGR bits! ;
: sys-clk-72-mhz  ( -- )
   hsi-wait-on hse-on usart1-hsi sys-clk-hsi pll-off hse-on-wait pll-hse-72-mhz hse-on-wait pll-on
   usb-pre-1.5 flash-setup-72-mhz 
   AHB/1 APB1/2 APB2/1 pll-on-wait sys-clk-pll ;

\ ********** usart functions *****************
$40013800 constant USART1
$0C constant USART_BRR
: usart1-230400-baud  ( -- )
   #8000000 230400 2/ + 230400 / USART_BRR USART1 + ! ;
: usart1-460800-baud  ( -- )
   #8000000 460800 2/ + 460800 / USART_BRR USART1 + ! ;

\ ********** usb functions *******************
$40006000 USB_SRAM
$40005C00 USB_BASE
#11 0 gpio-port-adr + constant PA11
#12 0 gpio-port-adr + constant PA12
PA11                  constant USB_DM
PA12                  constant USB_DP
$00 USB_BASE + constant USB_EP0R
$04 USB_BASE + constant USB_EP1R
$08 USB_BASE + constant USB_EP2R
$0C USB_BASE + constant USB_EP3R
$10 USB_BASE + constant USB_EP4R
$14 USB_BASE + constant USB_EP5R
$18 USB_BASE + constant USB_EP6R
$1C USB_BASE + constant USB_EP7R
$1 #15 lshift  constant USB_EPR.CTR_RX        \  Correct Transfer for reception
$1 #14 lshift  constant USB_EPR.DTOG_RX       \  Data Toggle, for reception transfers
$3 #12 lshift  constant USB_EPR.STAT_RX       \  Status bits, for reception transfers
$1 #11 lshift  constant USB_EPR.SETUP         \  Setup transaction completed
$3  #9 lshift  constant USB_EPR.EP_TYPE       \  Endpoint type
$1  #8 lshift  constant USB_EPR.EP_KIND       \  Endpoint kind
$1  #7 lshift  constant USB_EPR.CTR_TX        \  Correct Transfer for transmission
$1  #6 lshift  constant USB_EPR.DTOG_TX       \  Data Toggle, for transmission transfers
$3  #4 lshift  constant USB_EPR.STAT_TX       \  Status bits, for transmission transfers
$F  #0 lshift  constant USB_EPR.EA            \  Endpoint address


$40 USB_BASE + constant USB_CNTR
$1  #15 lshift constant USB_CNTR.CTRM         \ Correct transfer interrupt mask
$1  #14 lshift constant USB_CNTR.PMAOVRM      \ Packet memory area over / underrun interrupt mask
$1  #13 lshift constant USB_CNTR.ERRM         \ Error interrupt mask
$1  #12 lshift constant USB_CNTR.WKUPM        \ Wakeup interrupt mask
$1  #11 lshift constant USB_CNTR.SUSPM        \ Suspend mode interrupt mask
$1  #10 lshift constant USB_CNTR.RESETM       \ USB reset interrupt mask
$1   #9 lshift constant USB_CNTR.SOFM         \ Start of frame interrupt mask
$1   #8 lshift constant USB_CNTR.EOFM         \ Expected start of frame interrupt mask
$1   #4 lshift constant USB_CNTR.RESUME       \ Resume request
$1   #3 lshift constant USB_CNTR.FSUSP        \ Force suspend
$1   #2 lshift constant USB_CNTR.LP_MODE      \ Low-power mode
$1   #1 lshift constant USB_CNTR.PDWN         \ Power down
$1   #0 lshift constant USB_CNTR.FRES         \ Force USB Reset

$44 USB_BASE + constant USB_ISTR
 $1 #15 lshift constant USB_ISTR.CTR          \ Correct transfer
 $1 #14 lshift constant USB_ISTR.PMAOVR       \  Packet memory area over / underrun
 $1 #13 lshift constant USB_ISTR.ERR          \ Error
 $1 #12 lshift constant USB_ISTR.WKUP         \ Wakeup
 $1 #11 lshift constant USB_ISTR.SUSP         \ Suspend mode request
 $1 #10 lshift constant USB_ISTR.RESET        \ USB reset request
 $1  #9 lshift constant USB_ISTR.SOF          \ Start of frame
 $1  #8 lshift constant USB_ISTR.ESOF         \ Expected start of frame
 $1  #4 lshift constant USB_ISTR.DIR          \ Direction of transaction
 $f  #0 lshift constant USB_ISTR.EP_ID        \ Endpoint Identifier

$48 USB_BASE + constant USB_FNR               \ USB frame number register
 $1 #15 lshift constant USB_FNR.RXDP          \ Receive data + line status
 $1 #14 lshift constant USB_FNR.RXDM          \ Receive data - line status
 $1 #13 lshift constant USB_FNR.LCK           \ Locked
 $3 #11 lshift constant USB_FNR.LSOF          \ Lost SOF
 $3FF 0 lshift constant USB_FNR.FN            \ Frame number

$4C USB_BASE + constant USB_DADDR             \ USB device address
 $1  #7 lshift constant USB_DADDR.EF          \ Enable function
 $7F  0 lshift constant USB_DADDR.ADD         \ Device address

$50 USB_BASE + constant USB_BTABLE
$1FFF #3 lshift constant USB_BTABLE.BTABLE    \ Buffer table

#74 #16 + constant USB_HP_INT                 \ ipsr USB high prio interrupt 74 is int position from spec
                                              \ 16 is int number offset in from IPSR
#75 #16 + constant USB_LP_INT                 \ IPSR USB low prio interrupt number offset 16 to position from spec
#76 #16 + constant USB_WAKEUP_INT             \ IPSR USB wakeup interrupt number offset 16 to position from spec

0 variable usb-org-irq-handler                \ original interrupt-handler

: usb-on  ( -- )                              \ apb1-clk shall be > 10 mhz
   USBEN RCC_APB1ENR bis!
\  USBRST RCC_APB1RSTR bis!
   USBRST RCC_APB1RSTR bic! ;
: usb-irq-ena  ( -- )
   USB_HP_INT nvic-enable-irq
   USB_LP_INT nvic-enable-irq
   USB_WAKEUP_INT nvic-enable-irq ;
: usb-irq-clear  ( -- )
   USB_HP_INT nvic-clear-irq
   USB_LP_INT nvic-clear-irq
   USB_WAKEUP_INT nvic-clear-irq ;
: usb-irq-dis  ( -- )
   USB_HP_INT nvic-disable-irq
   USB_LP_INT nvic-disable-irq
   USB_WAKEUP_INT nvic-disable-irq ;
: usb-disconnect ( -- )
   1 USB-DP gpio-mode! 
   USB-DP gpio-bsrr-clr USB-DP gpio-bsrr ! ;
: usb-connect  ( -- )
   #3 USB-DP gpio-mode!
   #3 USB-DM gpio-mode!
   #14 USB-DP gpio-af!
   #14 USB-DM gpio-af! ;
   
: usb-hp-int-handler  ( -- ) ;                \ handle usb high prio interrupt
: usb-lp-int-handler  ( -- ) ;                \ handle usb low prio interrupt
: usb-wakeup-int-handler  ( -- ) ;            \ handle usb wakeup interrupt

: usb-int-handler ( -- )                      \ handles incomming interrupts from irq-collection
   IPSR case USB_HP_INT     of usb-hp-int-handler     endof
             USB_LP_INT     of usb-lp-int-handler     endof
             USB_WAKEUP_INT of usb-wakeup-int-handler endof
             usb-org-irq-handler @ dup 0<>
             if execute else drop then
        endcase ;

: usb-install-irq-handler ( -- )              \ install usb interrupt handler
   usb-org-irq-handler @ 0=
   if irq-collection @ usb-org-irq-handler !
   then ['] usb-int-handler irq-collection ! ;
