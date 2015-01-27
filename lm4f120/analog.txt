
\ Analog-Digital-Converter
\   needs basisdefinitions.txt

$400FE638 constant RCGCADC

: init-analog ( -- ) 
  $1 RCGCADC ! \ Provide clock to AD-Converter
               \ PIOs already activated in Core
  50 0 do loop \ Wait a bit
;

$4000551C constant PORTB_DEN   ( Digital Enable )
$40005420 constant PORTB_AFSEL ( Alternate function select )
$40005528 constant PORTB_AMSEL ( Analog Mode Select )

$4000751C constant PORTD_DEN   ( Digital Enable )
$40007420 constant PORTD_AFSEL ( Alternate function select )
$40007528 constant PORTD_AMSEL ( Analog Mode Select )

$4002451C constant PORTE_DEN   ( Digital Enable )
$40024420 constant PORTE_AFSEL ( Alternate function select )
$40024528 constant PORTE_AMSEL ( Analog Mode Select )

\ Zuordnung der analogen Eingänge zur Pinnummer und zum entsprechenden digitalen Port
\ Analog channel  Pin  Port  Bitmask
\ AIN0  6   PE3    8
\ AIN1  7   PE2    4
\ AIN2  8   PE1    2
\ AIN3  9   PE0    1
\ AIN4  64    PD3    8
\ AIN5  63    PD2    4
\ AIN6  62    PD1    2
\ AIN7  61    PD0    1
\ AIN8  60  PE5    32
\ AIN9  59  PE4    16
\ AIN10 58    PB4    16
\ AIN11 57    PB5    32
\ See Datasheet Page 1142

: init-ain0  ( -- )  8 PORTE_AFSEL bis!  8 PORTE_DEN bic!  8 PORTE_AMSEL bis! ;
: init-ain1  ( -- )  4 PORTE_AFSEL bis!  4 PORTE_DEN bic!  4 PORTE_AMSEL bis! ;
: init-ain2  ( -- )  2 PORTE_AFSEL bis!  2 PORTE_DEN bic!  2 PORTE_AMSEL bis! ;
: init-ain3  ( -- )  1 PORTE_AFSEL bis!  1 PORTE_DEN bic!  1 PORTE_AMSEL bis! ;

: init-ain4  ( -- )  8 PORTD_AFSEL bis!  8 PORTD_DEN bic!  8 PORTD_AMSEL bis! ;
: init-ain5  ( -- )  4 PORTD_AFSEL bis!  4 PORTD_DEN bic!  4 PORTD_AMSEL bis! ;
: init-ain6  ( -- )  2 PORTD_AFSEL bis!  2 PORTD_DEN bic!  2 PORTD_AMSEL bis! ;
: init-ain7  ( -- )  1 PORTD_AFSEL bis!  1 PORTD_DEN bic!  1 PORTD_AMSEL bis! ;

: init-ain8  ( -- ) 32 PORTE_AFSEL bis! 32 PORTE_DEN bic! 32 PORTE_AMSEL bis! ;
: init-ain9  ( -- ) 16 PORTE_AFSEL bis! 16 PORTE_DEN bic! 16 PORTE_AMSEL bis! ;

: init-ain10 ( -- ) 16 PORTB_AFSEL bis! 16 PORTB_DEN bic! 16 PORTB_AMSEL bis! ;
: init-ain11 ( -- ) 32 PORTB_AFSEL bis! 32 PORTB_DEN bic! 32 PORTB_AMSEL bis! ;

$40038FC8 constant ADC0_CC   \ Clock configuration
$40038000 constant ADC0_ACTSS \ Active Sample Sequencer
$40038044 constant ADC0_SSCTL0 \ Sample Sequence Control 0
$40038048 constant ADC0_SSFIFO0 \ Sample Sequence Result FIFO
$40038040 constant ADC0_SMUX0    \ Sample Sequence Input Multiplexer Select 0
$40038028 constant ADC0_PSSI      \ Processor Sample Sequence Initiate

: analog ( Channel -- Measurement )
  1 ADC0_CC !         \ Select PIOSC
  0 ADC0_ACTSS !      \ Disable Sample Sequencers
  $F and ADC0_SMUX0 ! \ Select input channel for first sample
  2 ADC0_SSCTL0 !     \ First Sample is End of Sequence
  1 ADC0_ACTSS !      \ Enable Sample Sequencer 0
  1 ADC0_PSSI !       \ Initiate sampling

  begin $10000 ADC0_ACTSS bit@ not until \ Check busy Flag for ADC

  ADC0_SSFIFO0 @ \ Fetch measurement result
;

: temperature ( -- Measurement )
  1 ADC0_CC !      \ Select PIOSC
  0 ADC0_ACTSS !   \ Disable Sample Sequencers
  0 ADC0_SMUX0 !   \ Select input channel for first sample
 $A ADC0_SSCTL0 !  \ First Sample is from Temperature Sensor and End of Sequence
  1 ADC0_ACTSS !   \ Enable Sample Sequencer 0
  1 ADC0_PSSI !    \ Initiate sampling

  begin $10000 ADC0_ACTSS bit@ not until \ Check busy Flag for ADC

  ADC0_SSFIFO0 @ \ Fetch measurement result
;

: random ( -- u )
 ( Generiert Zufallszahlen mit dem Rauschen vom Temperatursensor am ADC )
 ( Random numbers with noise of temperature sensor on ADC )
   0
   32 0 do
     shl
    temperature 1 and
    xor
  loop
;


\ Examples

init-analog \ Enable Clock for AD-Converter

random hex.
random hex.
random hex.
random hex.
random hex.

: measure-a0 init-ain0 begin 0 analog u. 5 spaces temperature u. cr key? until ;

: all-analogs
  init-ain0  init-ain1  init-ain2  init-ain3  init-ain4  init-ain5  init-ain6  init-ain7  init-ain8  init-ain9  init-ain10  init-ain11

  begin
    0 analog hex.
    1 analog hex.
    2 analog hex.
    3 analog hex.
    4 analog hex.
    5 analog hex.
    6 analog hex.
    7 analog hex.
    8 analog hex.
    9 analog hex.
   10 analog hex.
   11 analog hex.
    cr
  key? until
;
