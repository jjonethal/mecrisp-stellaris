
compiletoflash

: Flamingo cr
."      _" cr
."     ^-)" cr
."      (.._          .._" cr
."       \`\\        (\`\\        (" cr
."        |>         ) |>        |)" cr
." ______/|________ (7 |` ______\|/_______a:f" cr
;


$40010800 constant PORTA_Base
$40010C00 constant PORTB_Base
$40011000 constant PORTC_Base
$40011400 constant PORTD_Base

PORTA_BASE $08 + constant PORTA_IDR   \ RO              Input Data Register

PORTC_BASE $00 + constant PORTC_CRL   \ Reset $44444444 Port Configuration Register Low
PORTC_BASE $04 + constant PORTC_CRH   \ Reset $44444444 Port Configuration Register High
PORTC_BASE $08 + constant PORTC_IDR   \ RO              Input Data Register
PORTC_BASE $0C + constant PORTC_ODR   \ Reset 0         Output Data Register
PORTC_BASE $10 + constant PORTC_BSRR  \ Reset 0         Port Bit Set/Reset Register
PORTC_BASE $14 + constant PORTC_BRR   \ Reset 0         Port Bit Reset Register
PORTC_BASE $18 + constant PORTC_LCKR  \ Reset 0         Port Configuration Lock Register

1          constant button    \ User button on PA0
1 8 lshift constant led-blue  \ Blue  LED on PC8
1 9 lshift constant led-green \ Green LED on PC9

: init
  $11 PORTC_CRH ! \ Set LEDs as push-pull outputs
  cr
  Flamingo
  cr
  ." Have a nice day !" cr
;

: colours ( -- )
  begin
    key
    dup
    case
      [char] g of led-green portc_odr xor! endof
      [char] b of led-blue  portc_odr xor! endof
    endcase
    27 =
  until
;

\ Systick-Interrupt

: systick ( ticks -- )
    $E000E014 ! \ How many ticks between interrupts ?
  7 $E000E010 ! \ Enable the systick interrupt.
;

: systick-1Hz ( -- ) 8000000 systick ; \ Tick every second with 8 MHz clock


\ Delay with Systick-Timer

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

: delay-ticks ( ticks -- ) \  Tick = 1/8MHz = 125 ns
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


: button? ( -- ? ) button porta_idr bit@ ;

: cornerstone ( Name ) ( -- )
  <builds begin here $3FF and while 0 h, repeat
  does>   begin dup  $3FF and while 2+   repeat 
          eraseflashfrom
;

cornerstone Rewind-to-Basis

compiletoram
init

: readbutton ( -- ) init-delay begin button? . cr 200 ms key? until ;

: tick  ( -- ) ." Tick" cr ;

: clock ( -- ) 
  ['] tick irq-systick !
  systick-1Hz
  eint
;
