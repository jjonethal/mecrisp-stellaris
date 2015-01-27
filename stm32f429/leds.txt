
\ Blinking LEDs example

$E000E010 constant NVIC_ST_CTRL_R
$E000E014 constant NVIC_ST_RELOAD_R      
$E000E018 constant NVIC_ST_CURRENT_R

: init-delay ( -- )
    \ Start free running Systick Timer without Interrupts
  
    \ Disable SysTick during setup
    0 NVIC_ST_CTRL_R !

    \ Maximum reload value for 24 bit timer
    $00FFFFFF NVIC_ST_RELOAD_R !

    \ Any write to current clears it
    0 NVIC_ST_CURRENT_R !

    \ Enable SysTick with 8MHz clock
    %101 NVIC_ST_CTRL_R ! \ Use %101 instead for core clock
;

: delay-ticks ( ticks -- ) \  Tick = 1/4MHz = 250 ns
  NVIC_ST_CURRENT_R @ \ Get the starting time
  swap -              \ Subtract ticks to wait
  $00FFFFFF and       \ Handle possible counter roll over by converting to 24-bit subtraction
  ( finish )

  begin
    dup
    NVIC_ST_CURRENT_R @ \ Get current time
    ( finish finish current )
    u>= \ Systick counts backwards
  until
  drop
;

: us ( us -- ) 8 * delay-ticks ;
: ms ( ms -- ) 0 ?do 8000 delay-ticks loop ;



$40020000 constant PORTA_Base
$40020400 constant PORTB_Base
$40020800 constant PORTC_Base
$40020C00 constant PORTD_Base
$40021000 constant PORTE_Base
$40021400 constant PORTF_Base
$40021800 constant PORTG_Base
$40021C00 constant PORTH_Base
$40022000 constant PORTI_Base

PORTB_BASE $00 + constant PORTB_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTB_BASE $04 + constant PORTB_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTB_BASE $08 + constant PORTB_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTB_BASE $0C + constant PORTB_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTB_BASE $10 + constant PORTB_IDR      \ RO      Input Data Register
PORTB_BASE $14 + constant PORTB_ODR      \ Reset 0 Output Data Register
PORTB_BASE $18 + constant PORTB_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTB_BASE $20 + constant PORTB_AFRL     \ Reset 0 Alternate function  low register
PORTB_BASE $24 + constant PORTB_AFRH     \ Reset 0 Alternate function high register

PORTC_BASE $00 + constant PORTC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTC_BASE $04 + constant PORTC_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTC_BASE $08 + constant PORTC_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTC_BASE $0C + constant PORTC_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTC_BASE $10 + constant PORTC_IDR      \ RO      Input Data Register
PORTC_BASE $14 + constant PORTC_ODR      \ Reset 0 Output Data Register
PORTC_BASE $18 + constant PORTC_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTC_BASE $20 + constant PORTC_AFRL     \ Reset 0 Alternate function  low register
PORTC_BASE $24 + constant PORTC_AFRH     \ Reset 0 Alternate function high register

PORTG_BASE $00 + constant PORTG_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTG_BASE $04 + constant PORTG_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTG_BASE $08 + constant PORTG_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTG_BASE $0C + constant PORTG_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTG_BASE $10 + constant PORTG_IDR      \ RO      Input Data Register
PORTG_BASE $14 + constant PORTG_ODR      \ Reset 0 Output Data Register
PORTG_BASE $18 + constant PORTG_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTG_BASE $20 + constant PORTG_AFRL     \ Reset 0 Alternate function  low register
PORTG_BASE $24 + constant PORTG_AFRH     \ Reset 0 Alternate function high register

: init-leds ( -- ) \ Set LED pins as outputs

  %01  13 2*  lshift    portb_moder bis!  \ PB13
  %01   5 2*  lshift    portc_moder bis!  \ PC5
  %01  13 2*  lshift                      \ PG13
  %01  14 2*  lshift or portg_moder bis!  \ PG14
;

: led-green-bottom ( ? -- ) \ Green LED on PB13
  if 1 13 lshift else 1 13 lshift 16 lshift then portb_bsrr !
;

: led-red-bottom ( ? -- ) \ Red LED on PC5, inversed polarity
  if 1 5 lshift 16 lshift else 1 5 lshift then portc_bsrr !
;

: led-green-top ( ? -- ) \ Green LED on PG13
  if 1 13 lshift else 1 13 lshift 16 lshift then portg_bsrr ! 
;

: led-red-top ( ? -- ) \ Red LED on PG14
  if 1 14 lshift else 1 14 lshift 16 lshift then portg_bsrr ! 
;


: blink ( -- )
   init-leds
   init-delay

   begin

   true led-green-top
   200 ms
   true led-red-top
   200 ms
   true led-green-bottom
   200 ms
   true led-red-bottom
   200 ms

   false led-green-top
   200 ms
   false led-red-top
   200 ms
   false led-green-bottom
   200 ms
   false led-red-bottom
   200 ms

   key? until
;
