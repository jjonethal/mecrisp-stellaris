
$40023800 constant RCC_Base
 
$40023C00 constant Flash_ACR \ Flash Access Control Register
$40004408 constant USART2_BRR

\ f (VCO clock) = f (PLL clock input) * (PLLN/PLLM)
\ f (PLL general clock output) = F (VCO clock) / PLLP
\ f (USB, RNG und andere) = f (VCO clock) / PLLQ

RCC_Base $00 + constant RCC_CR
  1 24 lshift constant PLLON
  1 25 lshift constant PLLRDY

RCC_Base $04 + constant RCC_PLLCRGR
   1 22 lshift constant PLLSRC

RCC_Base $08 + constant RCC_CFGR


: 30MHz ( -- )

  \ Set Flash waitstates !
  0 Flash_ACR !   \ No wait states for 30 MHz

  PLLSRC          \ HSE clock as 8 MHz source

  8  0 lshift or  \ PLLM Division factor for main PLL and audio PLL input clock 
                  \ 8 MHz / 8 =  1 MHz. Divider before VCO. Frequency entering VCO to be between 1 and 2 MHz.

240  6 lshift or  \ PLLN Main PLL multiplication factor for VCO - between 192 and 432 MHz
                  \ 1 MHz * 240 = 240 MHz

  8 24 lshift or  \ PLLQ = 8, 240 MHz / 8 = 30 MHz

  3 16 lshift or  \ PLLP Division factor for main system clock
                  \ 0: /2  1: /4  2: /6  3: /8
                  \ 240 MHz / 8 = 30 MHz 
  RCC_PLLCRGR !

  PLLON RCC_CR bis!
    \ Wait for PLL to lock:
    begin PLLRDY RCC_CR bit@ until

  2 RCC_CFGR !  \ Set PLL as clock source

  $104 USART2_BRR ! \ Set Baud rate divider for 115200 Baud at 30 MHz.
;
