
compiletoflash

: Flamingo cr
."      _" cr
."     ^-)" cr
."      (.._          .._" cr
."       \`\\        (\`\\        (" cr
."        |>         ) |>        |)" cr
." ______/|________ (7 |` ______\|/_______a:f" cr
;

\ Jetzt geht es mal an die richtig frischen Neuigkeiten auf dem Stellaris:
\ Leitungen wackeln !

$400253FC constant PORTF_DATA ( Ein- und Ausgaberegister )  
$40025400 constant PORTF_DIR  ( Soll der Pin Eingang oder Ausgang sein ? )
$40025500 constant PORTF_DR2R ( 2 mA Treiber )
$40025504 constant PORTF_DR4R ( 4 mA )
$40025508 constant PORTF_DR8R ( 8 mA )
$4002550C constant PORTF_ODR  ( Open Drain )
$40025510 constant PORTF_PUR  ( Pullup Resistor )
$40025514 constant PORTF_PDR  ( Pulldown Resistor )
$40025518 constant PORTF_SLR  ( Slew Rate )
$4002551C constant PORTF_DEN  ( Digital Enable )

decimal

2 constant led-rot
8 constant led-grün
4 constant led-blau

16 constant Knopf1
1  constant Knopf2

: init
  \ PF0 ist auch der NMI-Eingang. Benötige also eine besondere Sequenz, um ihn für den Taster freizuschalten.
  $4C4F434B $40025520 !    ( PORTF_LOCK )
          1 $40025524 bis! ( PORTF_CR )
          0 $40025520 !    ( PORTF_LOCK )

  %11111 portf_den ! \ Alle Leitungen an Port F seien digitale Pins
  %01110 portf_dir ! \ Die Leuchtdiodenanschlüsse seien Ausgänge
  %10001 portf_pur ! \ Hochziehwiderstände für die Taster aktivieren

  cr
  Flamingo
  cr
  ." Have a nice day !" cr
;

: Knopf1? knopf1 portf_data bit@ not ;
: Knopf2? knopf2 portf_data bit@ not ;

: Zustand begin ." Knopf1: " knopf1? . ."  Knopf2: " knopf2? . cr key? until ;

: Bunt
  begin
    key
    dup
    case
      [char] r of led-rot  portf_data xor! endof
      [char] g of led-grün portf_data xor! endof
      [char] b of led-blau portf_data xor! endof
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
  <builds begin here $3FF and while 0 h, repeat
  does>   begin dup  $3FF and while 2+   repeat 
          eraseflashfrom
;

cornerstone Rewind-to-Basis

compiletoram
init

: tick  ( -- ) ." Tick" cr ;

: clock ( -- ) 
  ['] tick irq-systick !
  systick-1Hz
  eint
;
