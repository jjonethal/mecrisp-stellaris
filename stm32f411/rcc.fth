\ stm32F411 rcc clock control
\ datasheet stm32f411 "E:\stm\DM00115249 STM32F411xC STM32F411xE.pdf"
\ progman "E:\stm\DM00046982 PM0214 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ ref man "E:\stm\DM00119316  RM0383 STM32F411xC_E advanced ARM-based 32-bit MCUs .pdf"

#8000000      constant hse-base-clock
#1 #18 lshift constant hse-byp-mode
#16000000     constant hsi-base-clock

$40023800 constant RCC_BASE
$00 RCC_BASE or constant RCC_CR
   $1 #27 lshift constant PLLI2SRDY
   $1 #26 lshift constant PLLI2SON
   $1 #25 lshift constant PLLRDY
   $1 #24 lshift constant PLLON
   $1 #19 lshift constant CSSON
   $1 #18 lshift constant HSEBYP
   $1 #17 lshift constant HSERDY
   $1 #16 lshift constant HSEON
  $FF  #8 lshift constant HSICAL
  $1F  #3 lshift constant HSITRIM
   $1  #1 lshift constant HSIRDY
   $1            constant HSION
  

$04 RCC_BASE or constant RCC_PLLCFGR
   $F #24 lshift constant PLLQ    \ 2.. 15
   $1 #22 lshift constant PLLSRC
   $3 #16 lshift constant PllP
 $1FF  #6 lshift constant PLLN
 $3F             constant PLLM
   

$08 RCC_BASE or constant RCC_CFGR
   $3 #30 lshift constant MC02    \ Microcontroller clock output 2 - 00: SYSCLK 01: PLLI2S 10: HSE 11: PLL
   $7 #27 lshift constant MCO2PRE \ MCO2 prescaler - 0xx: /1 100: /2 101: /3 110: /4 111: /5
   $7 #24 lshift constant MCO1PRE \ MCO1 prescaler - 0xx: /1 100: /2 101: /3 110: /4 111: /5
   $1 #23 lshift constant I2SSRC  \ I2S clock selection - 0: PLLI2S 1: External clock on the I2S_CKIN pin
   $3 #21 lshift constant MCO1    \ Microcontroller clock output 1 - 00: HSI 01: LSE 10: HSE 11: PLL
  $1F #16 lshift constant RTCPRE  \ HSE division factor for RTC clock 0,1: no clock, 2..31: /2../31
   $7 #13 lshift constant PPRE2   \ APB high-speed prescaler (APB2) 0xx: /1, 100: /2, 101: /4, 110: /8, 111: /16 <= 84Mhz
   $7 #10 lshift constant PPRE1   \ APB Low speed prescaler (APB1) 0xx: /1, 100: /2, 101: /4, 110: /8, 111: /16 <= 42Mhz
   $3  #8 lshift constant RCC_CFGR_RES \ reserved
   $F  #4 lshift constant HPRE    \ AHB prescaler 0-7:/1 8:/2 9:/4 10:/8 11:/16 12:/64 13:/128 14:/256 15:/512 (>=25 for Ethernet)
   #3  #2 lshift constant SWS     \ System clock switch status 0:HSI 1:HSE 2:PLL 3:not applicable
   #3            constant SW      \ System clock switch	  0:HSI 1:HSE 2:PLL 3:not allowed


: cnt0 ( m -- b )           \ count trailing zeros with hw support
  dup negate and 1- clz negate #32 +
;

: getbits ( m adr -- b )    \ get masked bits from adress and shift down to least significant bit
  @ over and swap cnt0 rshift
;

: setbits  ( v m adr -- )   \ set the bits at mask position e.g. m:%00|111|00 v: %11 adr@ = %10|100|10 -- adr@:%10|011|10
  >R dup >R cnt0 lshift     \ shift value to proper pos
  R@ and                    \ mask out unrelated bits of v
  R> not R@ @ and           \ invert bit mask and mask out new bits
  or r> !                   \ apply value and store back
;

: -1>=0! ( n -- 0|n-1 ) \ n-1 or 0 if negative
  1- dup 0< not and
;

: ws-2v1 ( mhz -- ws ) \ waitstates for 1.71-2.1V
  -1>=0! #4 rshift
;

: c18/ ( c -- c/18 ) \ divide a value by 18 for values 0..255
  #455 * #64 + #13 rshift
;

: ws-2v4 ( mhz -- ws ) \ waitstates for 2.1-2.4V
  -1>=0! c18/
;

: c24/ ( c -- c/24 ) \ divide a value by 24 for values 0..255
  #1365 * #128 + #15 rshift
;

: ws-2v7 ( mhz -- ws ) \ waitstates for 2.4-2.7V 1..100 mhz
  -1>=0! c24/
;

: ws-3v6 ( mhz -- ws ) \ waitstates for 2.7-3.6V
  dup      30 >
  swap dup 64 >
  swap     90 >
  + + negate
;

: ws-v-range ( mvolt -- r ) \ calc range from millivolt
  dup       2100 >
  swap dup  2400 >
  swap      2700 >
  + + negate 
;

: ftab: <BUILDS DOES> swap 2 lshift + @ execute ;

ftab: ws-ftab
' ws-2v1 ,
' ws-2v4 ,
' ws-2v7 ,
' ws-3v6 ,

: flash-ws ( mhz mvolt -- ws ) \ flash ws depending on Mhz and milliVolt
  ws-v-range ws-ftab
;

: RCC_CFGR.SWS@ ( -- clksrc ) \ System clock switch status #0:HSI #1:HSE #2:PLL #3:not used
  RCC_CFGR @ #2 rshift #3 and
;

: RCC_CFGR.SW! ( clksrc -- ) \ System clock switch #0:HSI #1:HSE #2:PLL #3:not used
  RCC_CFGR @ [ 3 not literal, ] and or RCC_CFGR !
;



: set-mask ( m adr -- ) dup >R @ or R> ! ;
: clr-mask ( m adr -- ) >R not R@ @ and R> ! ;


decimal


: hse-on!  ( -- ) HSEON RCC_CR bis! ;
: hse-off! ( -- ) HSEON RCC_CR bic! ;

: hse-on? ( -- f ) HSEON RCC_CR bit@ ;

: hse-ready? ( -- f ) HSERDY RCC_CR bit@ ;

: wait-hse-stable
  begin 
    hse-on!
    hse-ready?  
  until
;

: pll-off ( -- )
  clk-source?
;

: set-hse-clock ( -- ) \ set system clock source to hse
  hse-on? not if set-hse-on wait-hse-stable then
  1 sys-clk-set
  clk-pll-off
; 

: switch-clk-source-hse ( -- )
  current-mhz hse-base-clock < if hse-base-clock cfg-flash then
  clk-source-hse
  pll-off
;

: set-pll-hse ( mhz -- )
  
  dup cfg-flash
;

: set-pll-clk ( mhz -- )

;


