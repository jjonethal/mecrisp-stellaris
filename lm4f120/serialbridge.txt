
\ Terminal bridge to UART3

\ U3Rx 14 PC6 I TTL UART module 3 receive.
\ U3Tx 13 PC7 O TTL UART module 3 transmit.

decimal

$400FE618 constant RCGCUART
$40006420 constant PORTC_AFSEL ( Analog function select )
$4000651C constant PORTC_DEN   ( Digital Enable )
$4000652C constant PORTC_PCTL  ( Port Control )

$4000F000 constant UART3_BASE
$4000F000 constant UART3DR
$4000F018 constant UART3FR
$4000F024 constant UART3IBRD
$4000F028 constant UART3FBRD
$4000F02C constant UART3LCRH
$4000F030 constant UART3CTL
$4000FFC8 constant UART3CC


\ Werte für den UARTFR-Register
$10 constant RXFE \ Receive  FIFO empty
$20 constant TXFF \ Transmit FIFO full

:  key?-terminal ( -- flag ) RXFE UART3FR bit@ not ;
: emit?-terminal ( -- flag ) TXFF UART3FR bit@ not ;

:  key-terminal  ( -- c )    begin  key?-terminal until UART3DR @ ;
: emit-terminal  ( c -- )    begin emit?-terminal until UART3DR ! ;

: init-terminal ( -- )
  8 RCGCUART bis! \ Enable clock for UART3

  100 0 do loop

  \ Leitungen vorbereiten
  $11000000 portc_pctl ! \ Select UART3 as Peripheral Module

  $C0 portc_afsel bis! \ PC6 und PC7 auf UART-Sonderfunktion schalten
  $C0 portc_den   bis! \ PC6 und PC7 als digitale Leitungen aktivieren

  \ UART-Einstellungen vornehmen
  0 UART3CTL !  \ UART anhalten

  \ Baud rate generation:
  \ 16000000 / (16 * 115200 ) = 1000000 / 115200 = 8.6805
  \ 0.6805... * 64 = 43.5   ~ 44
  \ use 8 and 44

    8 UART3IBRD !
   44 UART3FBRD !

  $70 UART3LCRH ! \ 8N1, FIFOs an !

    5 UART3CC !   \ PIOSC wählen
    0 UART3FR !
 $301 UART3CTL !  \ UART starten

;

: terminal ( -- )
  cr init-terminal

  false
  begin
    key?-terminal if key-terminal emit then
    key?          if drop key dup emit-terminal then
  dup 3 = until
  drop

  cr ." Return to Stellaris" cr
;

