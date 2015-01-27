
compiletoflash

: Flamingo cr
."      _" cr
."     ^-)" cr
."      (.._          .._" cr
."       \`\\        (\`\\        (" cr
."        |>         ) |>        |)" cr
." ______/|________ (7 |` ______\|/_______a:f" cr
;

$48000000 constant PORTA_Base
$48000400 constant PORTB_Base
$48000800 constant PORTC_Base
$48000C00 constant PORTD_Base
$48001000 constant PORTE_Base
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


PORTE_BASE $00 + constant PORTE_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTE_BASE $04 + constant PORTE_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTE_BASE $08 + constant PORTE_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTE_BASE $0C + constant PORTE_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTE_BASE $10 + constant PORTE_IDR      \ RO      Input Data Register
PORTE_BASE $14 + constant PORTE_ODR      \ Reset 0 Output Data Register
PORTE_BASE $18 + constant PORTE_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTE_BASE $20 + constant PORTE_AFRL     \ Reset 0 Alternate function  low register
PORTE_BASE $24 + constant PORTE_AFRH     \ Reset 0 Alternate function high register


PORTF_BASE $00 + constant PORTF_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTF_BASE $04 + constant PORTF_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTF_BASE $08 + constant PORTF_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTF_BASE $0C + constant PORTF_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTF_BASE $10 + constant PORTF_IDR      \ RO      Input Data Register
PORTF_BASE $14 + constant PORTF_ODR      \ Reset 0 Output Data Register
PORTF_BASE $18 + constant PORTF_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTF_BASE $20 + constant PORTF_AFRL     \ Reset 0 Alternate function  low register
PORTF_BASE $24 + constant PORTF_AFRH     \ Reset 0 Alternate function high register


: init
  cr
  Flamingo
  cr
  ." Have a nice day !" cr
;

\ PA0: User Button
\ PE8-PE15: Blue, Red, Orange, Green, Blue, Red, Orange, Green

: button? ( -- ? ) 1 porta_idr bit@ ;
: buttonstate begin button? . cr key? until ;

: leds ( -- )
  $55550000 PORTE_MODER ! \ Outputs PE8-PE15

  begin
    key
    dup
    case
      [char] 1 of 1  8 lshift PORTE_ODR xor! endof
      [char] 2 of 1  9 lshift PORTE_ODR xor! endof
      [char] 3 of 1 10 lshift PORTE_ODR xor! endof
      [char] 4 of 1 11 lshift PORTE_ODR xor! endof
      [char] 5 of 1 12 lshift PORTE_ODR xor! endof
      [char] 6 of 1 13 lshift PORTE_ODR xor! endof
      [char] 7 of 1 14 lshift PORTE_ODR xor! endof
      [char] 8 of 1 15 lshift PORTE_ODR xor! endof
    endcase
    27 =
  until
;

\ Cornerstone for 2 kb Flash pages

: cornerstone ( Name ) ( -- )
  <builds begin here $7FF and while 0 h, repeat
  does>   begin dup  $7FF and while 2+   repeat 
          eraseflashfrom
;

