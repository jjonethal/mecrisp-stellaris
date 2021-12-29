\ vim: set ts=2 sw=2 expandtab :

$40021000 constant RCC
  RCC $00 + constant RCC_CR
  RCC $04 + constant RCC_CFGR
  \ RCC $08 + constant RCC_CIR
  \ RCC $0C + constant RCC_APB2RSTR
  RCC $10 + constant RCC_APB1RSTR
  RCC $14 + constant RCC_AHBENR
  \ RCC $18 + constant RCC_APB2ENR
  RCC $1C + constant RCC_APB1ENR
  \ RCC $20 + constant RCC_BDCR
  \ RCC $24 + constant RCC_CSR
  \ RCC $28 + constant RCC_AHBRSTR
  \ RCC $2C + constant RCC_CFGR2
  RCC $30 + constant RCC_CFGR3
  \ RCC $34 + constant RCC_CR2

$40022000 constant FLASH
  FLASH $0 + constant FLASH_ACR

$48000000 constant GPIOA
  GPIOA $00 + constant GPIOA_MODER
  \ GPIOA $04 + constant GPIOA_OTYPER
  GPIOA $08 + constant GPIOA_OSPEEDR
  \ GPIOA $0C + constant GPIOA_PUPDR
  \ GPIOA $10 + constant GPIOA_IDR
  GPIOA $14 + constant GPIOA_ODR
  GPIOA $18 + constant GPIOA_BSRR
  GPIOA $20 + constant GPIOA_AFRL
  GPIOA $24 + constant GPIOA_AFRH
  GPIOA $28 + constant GPIOA_BRR

$40004400 constant USART2
  USART2 $C + constant USART2_BRR

\ set baud rate based on SYSCLK frequency
: +console_speed ( n -- )  115200 / USART2_BRR !  ; 

: flash_prefetch? ( -- )  %1 5 lshift FLASH_ACR bit@ ;
: +flash_ws0 0 FLASH_ACR ! ;
: +flash_ws0_prefetch %10000 FLASH_ACR ! ;
: +flash_ws1_prefetch %10001 FLASH_ACR ! ;

\ enable High Speed External Clock from Nucelo onboard stlink
: +hseon ( -- )
  %1 18 lshift RCC_CR bis!              \ set RCC_CR_HSEBYP
  %1 16 lshift RCC_CR bis!              \ set RCC_CR_HSEON
  begin %1 17 lshift RCC_CR bit@ until  \ wait for HSEON
  ;

\ disable RCC_CR_HSEON, RCC_CR_HSEBYP
: -rcc-hseon ( -- )
  %1 16 lshift RCC_CR bic!
  %1 18 lshift RCC_CR bic!
  ;

\ disable pll_clk
: -pll_clk %1 24 lshift RCC_CR bic! ;

\ rcc clk status - RCC_CFGR_SWS
: rcc-cfgr-sws ( -- f ) RCC_CFGR @ 2 rshift %11 and ;

\ high speed internal clock ready to use
: rcc-hsirdy? %1 1 lshift RCC_CR bit@ ;

\ is the sysclock running from hsi
: rcc-cfgr-sws-hsi? ( -- f )
  rcc-cfgr-sws %00 = 
  ;

\ is the sysclock running from hse
: rcc-cfgr-sws-hse? ( -- f )
  rcc-cfgr-sws %01 = 
  ;

\ is the sysclock running from pll
: rcc-cfgr-sws-pll? ( -- f )
  rcc-cfgr-sws %10 = 
  ;

\ enable RCC_CR_HSION
: +rcc-hsion ( -- )
  %1 RCC_CR bis!
  begin rcc-hsirdy? until   \ wait for HSIRDY
  ;

\ disable RCC_CR_HSION
: -rcc-hsion ( -- )   %1 RCC_CR bic! ;

\ change rcc_cfgr source to hsi
: +rcc-cfgr-sws-hsi ( -- )
  %11 RCC_CFGR bic!          \ switch to HSI 
  begin rcc-cfgr-sws-hsi? until
  ;

\ switch sysclk to run from the high speed internal 8MHz clock
: +sysclk-hsi ( -- )
  +rcc-hsion
  8000000 +console_speed
  +rcc-cfgr-sws-hsi
  -pll_clk                  \ disable PLLON
  -rcc-hseon
  +flash_ws0
  ;

\ switch sysclk to run from the high speed external clock
: +sysclk-hse
  %01 0 lshift RCC_CFGR bis!              \ Set RCC_CFGR_SW for HSE is system clock
  begin rcc-cfgr-sws-hse? until           \ wait for the sysclk to switch to hse
  ;

\ MCO SYSCLK out on PA8
: +sysclk-out ( -- )
  %1111 24 lshift RCC_CFGR bic!     \ turn off MCO output
  %0100 24 lshift RCC_CFGR bis!     \ SYSCLK output
  %10 16 lshift GPIOA_MODER bis!    \ PA8 Alternate Function 0 0b10
  %11 16 lshift GPIOA_OSPEEDR bis!  \ PA8 Fast 
  ;

\ configure sysclk to run from the pll
: +sysclk-pll ( n -- )
  %1    16 lshift RCC_CFGR bis! \ set RCC_CFGR_PLLSRC_HSE_PREDIV DIV/1
  %1111 18 lshift RCC_CFGR bic! \ clr RCC_CFGR_PLLMUL

  \ set pll multiplier
  ( pop ) case
  \ 16 of ( clearing it set it to 2 )    endof \ 8 * 2 = 16 MHz  
    24 of %0001 18 lshift  RCC_CFGR bis! endof \ 8 * 3 = 24 MHz
    48 of %0100 18 lshift  RCC_CFGR bis! endof \ 8 * 6 = 48 MHz
    \ all other
  endcase

  %1111 4 lshift RCC_CFGR bic!  \ HPRE DIV 1, HCLK = SYSCLK
  %111  8 lshift RCC_CFGR bic!  \ PPRE DIV 1, PCLK = HCLK

  %1 24 lshift RCC_CR bis!                \ set PLLON
  begin %1 25 lshift RCC_CR bit@ until    \ wait for PLLRDY

  %10 0 lshift RCC_CFGR bis!              \ Set RCC_CFGR_SW for PLL is system clock
  begin rcc-cfgr-sws-pll? until           \ wait for the sysclk to switch to pll
  ;

\ 8mhz using high speed internal xtal
: 8MHz-hsi      ( -- ) +sysclk-hsi ;

\ 8mhz using high speed external from stlink
: 8MHz-hsebyp  ( -- ) +sysclk-hsi +hseon +sysclk-hse ;

\ 16mhz using high speed external from stlink and pll
: 16MHz-hsebyp  ( -- )
  +sysclk-hsi +flash_ws0_prefetch +hseon 16 +sysclk-pll 16000000 +console_speed
  ;

\ 24mhz using high speed external from stlink and pll
: 24MHz-hsebyp  ( -- )
  +sysclk-hsi +flash_ws0_prefetch +hseon 24 +sysclk-pll 24000000 +console_speed
  ;

\ 48Mhz using high speed external from stlink and pll
: 48MHz-hsebyp  ( -- )
  +sysclk-hsi +flash_ws1_prefetch +hseon 48 +sysclk-pll 48000000 +console_speed
  ;

+sysclk-out

\ end mhz.fs words
