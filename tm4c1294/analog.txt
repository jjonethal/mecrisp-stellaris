
\ Analog-Digital-Converter
\   needs basisdefinitions.txt and pll.txt

\ PLL VCO has to be running on 480 MHz for this examples. 
\ Use 120MHz before.



$400FE638 constant RCGCADC

: init-analog ( -- ) 
  $1 RCGCADC ! \ Provide clock to AD-Converter
               \ PIOs already activated in Core
  50 0 do loop \ Wait a bit
;


\ Ports B, D, E, K carry analog inputs.

PORTB_BASE $420 + constant PORTB_AFSEL ( Alternate function select )
PORTB_BASE $51C + constant PORTB_DEN   ( Digital Enable )
PORTB_BASE $528 + constant PORTB_AMSEL ( Analog Mode Select )

PORTD_BASE $420 + constant PORTD_AFSEL ( Alternate function select )
PORTD_BASE $51C + constant PORTD_DEN   ( Digital Enable )
PORTD_BASE $528 + constant PORTD_AMSEL ( Analog Mode Select )

PORTE_BASE $420 + constant PORTE_AFSEL ( Alternate function select )
PORTE_BASE $51C + constant PORTE_DEN   ( Digital Enable )
PORTE_BASE $528 + constant PORTE_AMSEL ( Analog Mode Select )

PORTK_BASE $420 + constant PORTK_AFSEL ( Alternate function select )
PORTK_BASE $51C + constant PORTK_DEN   ( Digital Enable )
PORTK_BASE $528 + constant PORTK_AMSEL ( Analog Mode Select )


\ Analog channel  Pin  Port

\ AIN0   12  PE3
\ AIN1   13  PE2
\ AIN2   14  PE1
\ AIN3   15  PE0

\ AIN4  128  PD7
\ AIN5  127  PD6
\ AIN6  126  PD5
\ AIN7  125  PD4

\ AIN8  124  PE5
\ AIN9  123  PE4

\ AIN10 121  PB4
\ AIN11 120  PB5

\ AIN12   4  PD3
\ AIN13   3  PD2
\ AIN14   2  PD1
\ AIN15   1  PD0

\ AIN16  18  PK0
\ AIN17  19  PK1
\ AIN18  20  PK2
\ AIN19  21  PK3

\ See Datasheet Page 1048

: init-ain0  ( -- )  1 3 lshift PORTE_AFSEL bis!  1 3 lshift PORTE_DEN bic!  1 3 lshift PORTE_AMSEL bis! ;
: init-ain1  ( -- )  1 2 lshift PORTE_AFSEL bis!  1 2 lshift PORTE_DEN bic!  1 2 lshift PORTE_AMSEL bis! ;
: init-ain2  ( -- )  1 1 lshift PORTE_AFSEL bis!  1 1 lshift PORTE_DEN bic!  1 1 lshift PORTE_AMSEL bis! ;
: init-ain3  ( -- )  1 0 lshift PORTE_AFSEL bis!  1 0 lshift PORTE_DEN bic!  1 0 lshift PORTE_AMSEL bis! ;

: init-ain4  ( -- )  1 7 lshift PORTD_AFSEL bis!  1 7 lshift PORTD_DEN bic!  1 7 lshift PORTD_AMSEL bis! ;
: init-ain5  ( -- )  1 6 lshift PORTD_AFSEL bis!  1 6 lshift PORTD_DEN bic!  1 6 lshift PORTD_AMSEL bis! ;
: init-ain6  ( -- )  1 5 lshift PORTD_AFSEL bis!  1 5 lshift PORTD_DEN bic!  1 5 lshift PORTD_AMSEL bis! ;
: init-ain7  ( -- )  1 4 lshift PORTD_AFSEL bis!  1 4 lshift PORTD_DEN bic!  1 4 lshift PORTD_AMSEL bis! ;

: init-ain8  ( -- )  1 5 lshift PORTE_AFSEL bis!  1 5 lshift PORTE_DEN bic!  1 5 lshift PORTE_AMSEL bis! ;
: init-ain9  ( -- )  1 4 lshift PORTE_AFSEL bis!  1 4 lshift PORTE_DEN bic!  1 4 lshift PORTE_AMSEL bis! ;

: init-ain10 ( -- )  1 4 lshift PORTB_AFSEL bis!  1 4 lshift PORTB_DEN bic!  1 4 lshift PORTB_AMSEL bis! ;
: init-ain11 ( -- )  1 5 lshift PORTB_AFSEL bis!  1 5 lshift PORTB_DEN bic!  1 5 lshift PORTB_AMSEL bis! ;

: init-ain12 ( -- )  1 3 lshift PORTD_AFSEL bis!  1 3 lshift PORTD_DEN bic!  1 3 lshift PORTD_AMSEL bis! ;
: init-ain13 ( -- )  1 2 lshift PORTD_AFSEL bis!  1 2 lshift PORTD_DEN bic!  1 2 lshift PORTD_AMSEL bis! ;
: init-ain14 ( -- )  1 1 lshift PORTD_AFSEL bis!  1 1 lshift PORTD_DEN bic!  1 1 lshift PORTD_AMSEL bis! ;
: init-ain15 ( -- )  1 0 lshift PORTD_AFSEL bis!  1 0 lshift PORTD_DEN bic!  1 0 lshift PORTD_AMSEL bis! ;

: init-ain16 ( -- )  1 0 lshift PORTK_AFSEL bis!  1 0 lshift PORTK_DEN bic!  1 0 lshift PORTK_AMSEL bis! ;
: init-ain17 ( -- )  1 1 lshift PORTK_AFSEL bis!  1 1 lshift PORTK_DEN bic!  1 1 lshift PORTK_AMSEL bis! ;
: init-ain18 ( -- )  1 2 lshift PORTK_AFSEL bis!  1 2 lshift PORTK_DEN bic!  1 2 lshift PORTK_AMSEL bis! ;
: init-ain19 ( -- )  1 3 lshift PORTK_AFSEL bis!  1 3 lshift PORTK_DEN bic!  1 3 lshift PORTK_AMSEL bis! ;


$40038FC8 constant ADC0_CC   \ Clock configuration
$40038000 constant ADC0_ACTSS \ Active Sample Sequencer
$40038044 constant ADC0_SSCTL0 \ Sample Sequence Control 0
$40038048 constant ADC0_SSFIFO0 \ Sample Sequence Result FIFO
$40038040 constant ADC0_SSMUX0   \ Sample Sequence Input Multiplexer Select 0
$40038028 constant ADC0_PSSI      \ Processor Sample Sequence Initiate
$40038058 constant ADC0_SSEMUX0    \ Sample Sequence Extended Input Multiplexer Select 0
$40038FC4 constant ADC0_PC          \ Peripheral configuration
$40038FC8 constant ADC0_CC           \ Clock configuration

: analog ( Channel -- Measurement )

  14 4 lshift  ADC0_CC !      \ PLL VCO on 480 MHz / (14 + 1) = 32 MHz
  7 ADC0_PC !                  \ Full sample rate giving 2 Msps

  0 ADC0_ACTSS !                              \ Disable Sample Sequencers
  dup $10 and if 1 else 0 then ADC0_SSEMUX0 ! \ Extended bit of input channel.
  $F and ADC0_SSMUX0 !                        \ Select input channel for first sample
  2 ADC0_SSCTL0 !                             \ First Sample is End of Sequence

  1 ADC0_ACTSS !                              \ Enable Sample Sequencer 0
  1 ADC0_PSSI !                               \ Initiate sampling

  begin $10000 ADC0_ACTSS bit@ not until      \ Check busy Flag for ADC

  ADC0_SSFIFO0 @ \ Fetch measurement result
;

: temperature ( -- Measurement )

  14 4 lshift  ADC0_CC !      \ PLL VCO on 480 MHz / (14 + 1) = 32 MHz
  7 ADC0_PC !                  \ Full sample rate giving 2 Msps

  0 ADC0_ACTSS !   \ Disable Sample Sequencers
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

: randoms ( -- )
  120MHz init-analog
  5 0 do random hex. loop
;

: measure-a0 ( -- ) 120MHz init-analog init-ain0 begin 0 analog u. 5 spaces temperature u. cr key? until ;

: all-analogs ( -- )
  120MHz init-analog

  init-ain0  init-ain1  init-ain2  init-ain3  init-ain4  init-ain5  init-ain6  init-ain7  
  init-ain8  init-ain9  init-ain10 init-ain11 init-ain12 init-ain13 init-ain14 init-ain15
  init-ain16 init-ain17 init-ain18 init-ain19

  begin
    20 0 do i analog hex. loop cr
  key? until
;
