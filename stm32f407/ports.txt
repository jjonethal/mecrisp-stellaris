
\ Colourful LEDs example

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

PORTD_BASE $00 + constant PORTD_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTD_BASE $04 + constant PORTD_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTD_BASE $08 + constant PORTD_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTD_BASE $0C + constant PORTD_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTD_BASE $10 + constant PORTD_IDR      \ RO      Input Data Register
PORTD_BASE $14 + constant PORTD_ODR      \ Reset 0 Output Data Register
PORTD_BASE $18 + constant PORTD_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTD_BASE $20 + constant PORTD_AFRL     \ Reset 0 Alternate function  low register
PORTD_BASE $24 + constant PORTD_AFRH     \ Reset 0 Alternate function high register

$1000 constant led-green
$2000 constant led-orange
$4000 constant led-red
$8000 constant led-blue

: colours ( -- )
   init-delay
   $55000000 PORTD_MODER ! \ Outputs PD12, PD13, PD14, PD15
   led-green PORTD_ODR !
   500 ms
   led-orange PORTD_ODR !
   500 ms
   led-red PORTD_ODR !
   500 ms
   led-blue PORTD_ODR !
   500 ms
   0 PORTD_ODR !
;
