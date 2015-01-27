
\ Analog-Digital-Converter samples with crystal stabilized 1Msps into circular buffer
\   needs basisdefinitions.txt and pll.txt

compiletoram \ For RAM only. Interrupt handler is too slow for 1Msps in Flash with waitstates.


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
$40038014 constant ADC0_EMUX   \ Active Sample Sequencer
$40038044 constant ADC0_SSCTL0  \ Sample Sequence Control 0
$40038048 constant ADC0_SSFIFO0  \ Sample Sequence Result FIFO
$40038040 constant ADC0_SMUX0     \ Sample Sequence Input Multiplexer Select 0
$40038028 constant ADC0_PSSI       \ Processor Sample Sequence Initiate

$40038008 constant ADC0_IM  \ Interrupt mask
$4003800C constant ADC0_ISC  \ Interrupt status clear
$4003804C constant ADC0_SSFSTAT0 \ FIFO Status for Sample Sequencer 0
$40038FC4 constant ADC0_PC \ Peripheral Control - Sets Sample Rate

$E000E100 constant en0 ( Interrupt Set Enable )
$E000E104 constant en1 ( Interrupt Set Enable )
$E000E108 constant en2 ( Interrupt Set Enable )
$E000E10C constant en3 ( Interrupt Set Enable )



      0 variable buffer     \ Location of circular buffer
   $1FF constant buffermask \ For  512 Samples
\ $1FFF constant buffermask \ For 8192 Samples

: allot-buffer ( -- )
  compiletoram \ Buffer should always placed in RAM
  here         \ This place !
  buffermask 2* 1+ allot    \ Reserve space for the desired number of 16-Bit-Samples
  buffer !     \ If allot succeed, save the place
;

: release-buffer ( -- )
  \ Hopefully nothing has been compiled in between...
  0 buffer !   \ Clear Pointer
  buffermask 2* 1+ negate allot \ Release space
;

0 variable sample# \ Current offset into circular buffer

: process-sample ( Sample Nummer )  shl buffer @ + h! inline ; \ Sample# * 2 is Offset into Buffer.

: adc-handler ( -- ) \ For 1 Msps with 8 Samples/Interrupt
  1 ADC0_ISC ! \ Clear Interrupt-Flag
  
   sample# @         \ Current sample number

\ Sample 1
   ADC0_SSFIFO0 @      \ Fetch sample from FIFO
   over process-sample \ Store sample
   1+ buffermask and   \ Increment sample number, handle circular buffer wrap over

\ Sample 2
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

\ Sample 3
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

\ Sample 4
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

\ Sample 5
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

\ Sample 6
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

\ Sample 7
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

\ Sample 8
   ADC0_SSFIFO0 @
   over process-sample
   1+ buffermask and

   sample# !  \ Store number for next upcoming sample
;


: analog-continuous-with-irq ( -- ) \ Set up ADC to sample AIN0 continuously with Interrupts every 8th sample

  init-analog \ Enable Clock for AD-Converter
  init-ain0
  80MHz \ Fast clock necessary for this example !

  $4000 en0 bis! \ Enable ADC0-Sequencer-0 Interrupt in global Interrupt Controller

  ['] adc-handler irq-adc0seq0 ! \ Hook for handler
  1 ADC0_IM !                     \ Interrupt enable for Sequencer 0

  0 ADC0_CC !         \ Crystal stabilized PLL clock source
  0 ADC0_ACTSS !      \ Disable Sample Sequencers

\ 1 ADC0_PC ! \ Sample Rate 125 kbps
\ 3 ADC0_PC ! \ Sample Rate 250 ksps
\ 5 ADC0_PC ! \ Sample Rate 500 ksps
 7 ADC0_PC ! \ Sample Rate 1 Msps

  $00000000 ADC0_SMUX0 !   \ Select input channel for all eight samples to be AIN0 = PE3
  $60000000 ADC0_SSCTL0 !  \ 8 Samples for every Interrupt

  $F ADC0_EMUX !  \ SS0 trigger select = Continously sample (S 796) 
  1 ADC0_ACTSS !  \ Enable Sample Sequencer 0
;


: capture ( -- ) \ Sets ADC to sample continuously into circular buffer,  
                 \ then stop on key press and print measurement results

  allot-buffer  \ Get memory for circular buffer
  0 sample# !   \ First sample is number zero
  analog-continuous-with-irq \ Record !

  \ You can include your favourite trigger here - 
  \ * do math on previous samples 
  \     (note that the most recent sample is always sample# @ 1- )
  \ * wait for a digital pin to toggle
  \ * get samples from ADC1 to trigger
  \ * simply wait for a key press, what is done in this example

  cr
  ." Sampling: Wait for trigger - press a key"
  begin key? until

  0 ADC0_ACTSS !      \ Disable Sample Sequencers
  10000 0 do loop     \ Wait until current sampling is finished and Interrupts calmed down

  \ Print contents of circular buffer starting with oldest sample
  cr
  buffermask 1+ 0 
  do  
    i u. space 
    buffer @ i sample# @ + buffermask and shl + h@ u. cr
  loop

  release-buffer \ Release space for buffer
;
