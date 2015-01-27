
\ Blue button example

$40020000 constant PORTA_Base

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

: button? ( -- ? ) 1 porta_idr bit@ ;
: buttonstate begin button? . cr key? until ;
