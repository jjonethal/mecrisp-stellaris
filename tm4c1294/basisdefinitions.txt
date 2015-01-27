
compiletoflash

: Flamingo cr
."      _" cr
."     ^-)" cr
."      (.._          .._" cr
."       \`\\        (\`\\        (" cr
."        |>         ) |>        |)" cr
." ______/|________ (7 |` ______\|/_______a:f" cr
;


\ Port definitions for Tiva TM4C1294

$40058000 constant PORTA_BASE
$40059000 constant PORTB_BASE
$4005A000 constant PORTC_BASE
$4005B000 constant PORTD_BASE
$4005C000 constant PORTE_BASE
$4005D000 constant PORTF_BASE
$4005E000 constant PORTG_BASE
$4005F000 constant PORTH_BASE
$40060000 constant PORTJ_BASE
$40061000 constant PORTK_BASE
$40062000 constant PORTL_BASE
$40063000 constant PORTM_BASE
$40064000 constant PORTN_BASE
$40065000 constant PORTP_BASE
$40066000 constant PORTQ_BASE

PORTF_BASE $3FC + constant PORTF_DATA ( IO Data Register, all bits selected )
PORTF_BASE $400 + constant PORTF_DIR  ( Pin Direction )
PORTF_BASE $500 + constant PORTF_DR2R ( 2 mA drive current )
PORTF_BASE $504 + constant PORTF_DR4R ( 4 mA )
PORTF_BASE $508 + constant PORTF_DR8R ( 8 mA )
PORTF_BASE $53C + constant PORTF_DR12R ( 12 mA )
PORTF_BASE $50C + constant PORTF_ODR  ( Open Drain )
PORTF_BASE $510 + constant PORTF_PUR  ( Pullup Resistor )
PORTF_BASE $514 + constant PORTF_PDR  ( Pulldown Resistor )
PORTF_BASE $518 + constant PORTF_SLR  ( Slew Rate )
PORTF_BASE $51C + constant PORTF_DEN  ( Digital Enable )

PORTJ_BASE $3FC + constant PORTJ_DATA ( IO Data Register, all bits selected )
PORTJ_BASE $400 + constant PORTJ_DIR  ( Pin Direction )
PORTJ_BASE $500 + constant PORTJ_DR2R ( 2 mA drive current )
PORTJ_BASE $504 + constant PORTJ_DR4R ( 4 mA )
PORTJ_BASE $508 + constant PORTJ_DR8R ( 8 mA )
PORTJ_BASE $53C + constant PORTJ_DR12R ( 12 mA )
PORTJ_BASE $50C + constant PORTJ_ODR  ( Open Drain )
PORTJ_BASE $510 + constant PORTJ_PUR  ( Pullup Resistor )
PORTJ_BASE $514 + constant PORTJ_PDR  ( Pulldown Resistor )
PORTJ_BASE $518 + constant PORTJ_SLR  ( Slew Rate )
PORTJ_BASE $51C + constant PORTJ_DEN  ( Digital Enable )

PORTN_BASE $3FC + constant PORTN_DATA ( IO Data Register, all bits selected )
PORTN_BASE $400 + constant PORTN_DIR  ( Pin Direction )
PORTN_BASE $500 + constant PORTN_DR2R ( 2 mA drive current )
PORTN_BASE $504 + constant PORTN_DR4R ( 4 mA )
PORTN_BASE $508 + constant PORTN_DR8R ( 8 mA )
PORTN_BASE $53C + constant PORTN_DR12R ( 12 mA )
PORTN_BASE $50C + constant PORTN_ODR  ( Open Drain )
PORTN_BASE $510 + constant PORTN_PUR  ( Pullup Resistor )
PORTN_BASE $514 + constant PORTN_PDR  ( Pulldown Resistor )
PORTN_BASE $518 + constant PORTN_SLR  ( Slew Rate )
PORTN_BASE $51C + constant PORTN_DEN  ( Digital Enable )

\  Interrupt controller tools

$E000E100 constant en0 ( Interrupt Set Enable  0-31  )
$E000E104 constant en1 ( Interrupt Set Enable 32-63  )
$E000E108 constant en2 ( Interrupt Set Enable 64-95  )
$E000E10C constant en3 ( Interrupt Set Enable 96-127 )

$E000E180 constant dis0 ( Interrupt Clear Enable  0-31  )
$E000E184 constant dis1 ( Interrupt Clear Enable 32-63  )
$E000E188 constant dis2 ( Interrupt Clear Enable 64-95  )
$E000E18C constant dis3 ( Interrupt Clear Enable 96-127 )

: nvic-enable ( irq# -- )
  16 - \ Cortex Core Vectors
  dup 32 u< if      1 swap lshift en0 ! exit then
  dup 64 u< if 32 - 1 swap lshift en1 ! exit then
  dup 96 u< if 64 - 1 swap lshift en2 ! exit then
               96 - 1 swap lshift en3 !
;

: nvic-disable ( irq# -- )
  16 - \ Cortex Core Vectors
  dup 32 u< if      1 swap lshift dis0 ! exit then
  dup 64 u< if 32 - 1 swap lshift dis1 ! exit then
  dup 96 u< if 64 - 1 swap lshift dis2 ! exit then
               96 - 1 swap lshift dis3 !
;
 
: nvic-priority ( priority irq# -- )
  $E000E400 + c!
;
 
\ Hardware definitions for Tiva Connected Launchpad

1 1 lshift  constant led-1 \ On Port N Bit 1
1 0 lshift  constant led-2 \ On Port N Bit 0
1 4 lshift  constant led-3 \ On Port F Bit 4
1 0 lshift  constant led-4 \ On Port F Bit 0

1 0 lshift  constant switch-1 \ On Port J Bit 0
1 1 lshift  constant switch-2 \ On Port J Bit 1

: init ( -- )

  \ Set wires for LEDs
  led-1 led-2 or portn_den !  \ LED 1&2 connections as digital lines
  led-1 led-2 or portn_dir !  \ LED 1&2 connections should be outputs
  led-3 led-4 or portf_den !  \ LED 3&4 connections as digital lines
  led-3 led-4 or portf_dir !  \ LED 3&4 connections should be outputs

  \ Set wires for switches
  switch-1 switch-2 or portj_den ! \ Switch connections as digital lines, inputs
  switch-1 switch-2 or portj_pur ! \ Activate pullup resistors for switches

  cr
  Flamingo
  cr
  ." Have a nice day !" cr
;

: switch1? ( -- ? ) switch-1 portj_data bit@ not ;
: switch2? ( -- ? ) switch-2 portj_data bit@ not ;

: switches begin ." Switch 1: " switch1? . ."  Switch 2: " switch2? . cr key? until ;

: leds ( -- )
  begin
    key
    dup
    case
      [char] 1 of led-1 portn_data xor! endof
      [char] 2 of led-2 portn_data xor! endof
      [char] 3 of led-3 portf_data xor! endof
      [char] 4 of led-4 portf_data xor! endof
    endcase
    27 =
  until
;

: systick ( ticks -- )
    $E000E014 ! \ How many ticks between interrupts ?
  7 $E000E010 ! \ Enable the systick interrupt.
;

: systick-1Hz ( -- ) 16000000 systick ; \ Tick every second with 16 MHz clock

: cornerstone ( Name ) ( -- )
  <builds begin here $3FFF and while 0 h, repeat
  does>   begin dup  $3FFF and while 2+   repeat 
          eraseflashfrom
;

\ If you want to go back to this dictionary state later, type:
\ cornerstone Rewind-to-Basis

compiletoram
init

: tick  ( -- ) ." Tick" cr ;

: clock ( -- ) 
  ['] tick irq-systick !
  systick-1Hz
  eint
;
