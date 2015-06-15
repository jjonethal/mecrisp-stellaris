\ stm32F411 rcc clock control
\ 

#8000000      constant hse-base-clock
#1 #18 lshift constant hse-byp-mode
#16000000     constant hsi-base-clock

$40023800 constant RCC_BASE
$00 RCC_BASE or constant RCC_CR
   #1 #18 lshift constant HSEBYP
   #1 #17 lshift constant HSERDY
   #1 #16 lshift constant HSEON 

$08 RCC_BASE or constant RCC_CFGR
   #3 #30 lshift constant MC02    \ Microcontroller clock output 2 - 00: SYSCLK 01: PLLI2S 10: HSE 11: PLL
   #7 #27 lshift constant MCO2PRE \ MCO2 prescaler - 0xx: /1 100: /2 101: /3 110: /4 111: /5
   #7 #24 lshift constant MCO1PRE \ MCO1 prescaler - 0xx: /1 100: /2 101: /3 110: /4 111: /5
   #1 #23 lshift constant I2SSRC  \ I2S clock selection - 0: PLLI2S 1: External clock on the I2S_CKIN pin
   #3 #21 lshift constant MCO1    \ Microcontroller clock output 1 - 00: HSI 01: LSE 10: HSE 11: PLL
  #31 #16 lshift constant RTCPRE  \ HSE division factor for RTC clock 0,1: no clock, 2..31: /2../31
   #7 #13 lshift constant PPRE2   \ APB high-speed prescaler (APB2) 0xx: /1, 100: /2, 101: /4, 110: /8, 111: /16 <= 84Mhz
   #7 #10 lshift constant PPRE1   \ APB Low speed prescaler (APB1) 0xx: /1, 100: /2, 101: /4, 110: /8, 111: /16 <= 42Mhz
   #3  #8 lshift constant RCC_CFGR_RES \ reserved
  #15  #4 lshift constant HPRE    \ AHB prescaler 0-7:/1 8:/2 9:/4 10:/8 11:/16 12:/64 13:/128 14:/256 15:/512 (>=25 for Ethernet)
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

: get-ws-2v1 ( mhz -- ws ) \ waitstates for 1.71-2.1V
  dup #96 <=
  if 1- #4 rshift
  else drop #6
  then
;

: get-ws-2v4 ( mhz -- ws ) \ waitstates for 2.1-2.4V
  dup #90 <=
  if 1- #18 /
  else drop #5
  then
;

: get-ws-2v7 ( mhz -- ws ) \ waitstates for 2.4-2.7V
  dup #96 <=
  if 1- #24 /
  else drop #4
  then
;

: get-ws-3v6 ( mhz -- ws ) \ waitstates for 2.7-3.6V
  dup #30 <= if drop #0 exit then
  dup #64 <= if drop #1 exit then
      #90 <= if drop #2 exit then
  3 
;

: flash-ws ( mhz mvolt -- ws ) \ flash ws depending on Mhz and milliVolt
  dup #2100 <= if drop get-ws-2v1 exit then
  dup #2400 <= if drop get-ws-2v4 exit then
      #2700 <= if      get-ws-2v7
               else    get-ws-3v6      then
;

: sys-clk-get ( -- clksrc ) \ #0:HSI #1:HSE #2:PLL #3:not used
  RCC_CFGR @ #2 rshift #3 and
;

sys-clk-set ( clksrc -- ) \ #0:HSI #1:HSE #2:PLL #3:not used
  RCC_CFGR @ [ 3 not literal, ] and or RCC_CFGR !
:



: set-mask ( m adr -- ) dup >R @ or R> ! ;
: clr-mask ( m adr -- ) >R not R@ @ and R> ! ;


decimal


: set-hse-on  ( -- ) HSEON RCC_CR bis! ;
: set-hse-off ( -- ) HSEON RCC_CR bic! ;

: hse-on? ( -- f ) RCC_CR @ HSEON and 0<> ;

: hse-ready? ( -- f ) RCC_CR @ HSERDY and 0<> ;

: wait-hse-stable
  begin 
    set-hse-on
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

: switch-clk-source-hse 
  current-mhz hse-base-clock < if hse-base-clock cfg-flash then
  clk-source-hse
  pll-off
;

: set-pll-hse ( mhz -- )
  
  dup cfg-flash
;

: set-pll-clk ( mhz -- )

;


