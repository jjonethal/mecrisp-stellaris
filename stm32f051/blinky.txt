
\ LEDs and button

$48000000 constant PORTA_Base
$48000400 constant PORTB_Base
$48000800 constant PORTC_Base
$48000C00 constant PORTD_Base
$48001400 constant PORTF_Base

PORTA_BASE $00 + constant PORTA_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTA_BASE $04 + constant PORTA_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTA_BASE $08 + constant PORTA_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTA_BASE $0C + constant PORTA_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTA_BASE $10 + constant PORTA_IDR      \ RO      Input Data Register
PORTA_BASE $14 + constant PORTA_ODR      \ Reset 0 Output Data Register
PORTA_BASE $18 + constant PORTA_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTA_BASE $20 + constant PORTA_AFRL     \ Reset 0 Alternate function  low register
PORTA_BASE $24 + constant PORTA_AFRH     \ Reset 0 Alternate function high register
PORTA_BASE $28 + constant PORTA_BRR      \ Reset 0 Bit Reset Register


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
PORTB_BASE $28 + constant PORTB_BRR      \ Reset 0 Bit Reset Register


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
PORTC_BASE $28 + constant PORTC_BRR      \ Reset 0 Bit Reset Register

\ LEDs and Button examples by Terry Porter:

: LD3ON   1 9 lshift PORTC_BSRR ! ; \ turn LD3 on  
: LD4ON   1 8 lshift PORTC_BSRR ! ; 
: LD3OFF  1 9 lshift PORTC_BRR ! ;
: LD4OFF  1 8 lshift PORTC_BRR ! ; \ turn LD4 off

: button? ( -- ? ) 1 0 lshift PORTA_IDR bit@ ; \ 0 if not pressed

: leds ( -- )
  %01 8 2* lshift 
  %01 9 2* lshift or PORTC_MODER bis! \ set PC8 and PC9 as output
  begin 
    button? if ld3on ld4off else ld3off ld4on then 
  key? until \ loop until reset or keyboard key pressed
  ld3off ld4off 
;
