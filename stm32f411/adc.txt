
\ Analog input example

$40023800 constant RCC_Base
RCC_Base $44 + constant RCC_APB2ENR

\ Bits for RCC_APB2ENR:
1  8 lshift constant ADC1EN


$40012000 constant ADC1_Base

ADC1_Base $00 + constant ADC1_SR
ADC1_Base $04 + constant ADC1_CR1
ADC1_Base $08 + constant ADC1_CR2
ADC1_Base $0C + constant ADC1_SMPR1
ADC1_Base $10 + constant ADC1_SMPR2
ADC1_Base $14 + constant ADC1_JOFR1
ADC1_Base $18 + constant ADC1_JOFR2
ADC1_Base $1C + constant ADC1_JOFR3
ADC1_Base $20 + constant ADC1_JOFR4
ADC1_Base $24 + constant ADC1_HTR
ADC1_Base $28 + constant ADC1_LTR
ADC1_Base $2C + constant ADC1_SQR1
ADC1_Base $30 + constant ADC1_SQR2
ADC1_Base $34 + constant ADC1_SQR3
ADC1_Base $38 + constant ADC1_JSQR
ADC1_Base $3C + constant ADC1_JDR1
ADC1_Base $40 + constant ADC1_JDR2
ADC1_Base $44 + constant ADC1_JDR3
ADC1_Base $48 + constant ADC1_JDR4
ADC1_Base $4C + constant ADC1_DR

\ Bits for ADC_SR:
  2 constant EOC
$10 constant STRT

\ Bits for ADC_CR2:
1           constant ADON
2           constant CONT
1 30 lshift constant SWSTART

ADC1_Base $304 + constant ADC_CCR
  1 23 lshift constant TSVREFE  \ Temperature sensor and Vrefint enable
  1 22 lshift constant VBATE    \ Vbat enable

: init-analog ( -- )  ADC1EN RCC_APB2ENR bis! ; \ Enable clock for ADC1

: analog ( channel -- u )
     0 ADC1_CR1 !
  ADON ADC1_CR2 ! \ Enable ADC

  1 20 lshift ADC1_SQR1 ! \ One conversion for this sequence
  ADC1_SQR3 !             \ Select channel

  SWSTART ADC1_CR2 bis! \ Start conversion

  \ Wait for conversion to finish:
  begin EOC ADC1_SR bit@ until

  ADC1_DR @ \ Fetch measurement

  0 ADC1_CR2 ! \ Disable ADC
;


$40020800 constant PORTC_Base
PORTC_BASE $00 + constant PORTC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
\ PC0 is AIN10
\ PC1 is AIN11

: sample-pc1 ( -- )
  init-analog \ Enable clock for ADC1
  %11 1 2* lshift portc_moder bis! \ Switch PC1 to analog mode
  begin
    11 analog u. cr
  key? until
;

\ temperature measurement

$1FFF7A2A  constant VREFIN_CAL \ reference Voltage reading at 3.3V 30 C
$1FFF7A2C  constant TS_CAL_30  \ temperature reading at 30 C 3.3V
$1FFF7A2E  constant TS_CAL_110 \ temperature reading at 110 C 3.3V

: VREFIN_CAL_VAL VREFIN_CAL @ $FFF and ; \ return value of calibration
: TS_CAL_30_VAL  TS_CAL_30  @ $FFF and ; \ return value of calibration
: TS_CAL_110_VAL TS_CAL_110 @ $FFF and ; \ return value of calibration


: temp-sensor ( -- )           \ temperature sensor readout demo
  init-analog
  TSVREFE ADC_CCR bis!
  begin
	18 analog u. cr
  key? until ;

: VREF-INT-VAL ( -- u )       \ read current vrefint value
	init-analog
	TSVREFE ADC_CCR bis!
	17 analog ;

: temp-sensor-on ( -- )       \ turn on temperature sensor
  init-analog
  TSVREFE ADC_CCR bis! ;

: temp-sensor-off ( -- )       \ turn off temperature sensor
  TSVREFE ADC_CCR bic! ;


: adc-temp ( -- u )
  init-analog
  TSVREFE ADC_CCR bis!
  18 analog ;


: adc-scale-fix ( u -- u ) \ correct ADC reading scale to 3v3 actual voltage may differ
  VREFIN_CAL @ $FFF and    \ fetch and mask calibration value
  VREF-INT-VAL */ ;        \ apply scale to value u

: adc-temp-scale ( -- u )  \ scale adc temperature val to 3.3V
  adc-temp adc-scale-fix ;

: temp-cal ( -- w )        \ display temperature in C/100
  adc-temp-scale TS_CAL_30_VAL - 8000 TS_CAL_110_VAL TS_CAL_30_VAL - */
  3000 + ;

0 variable temp-filt       \ filter for testing

: temp-sensor-cal ( -- )
  init-analog
  temp-sensor-on
  begin
	temp-cal temp-filt @ 127 * + 64 + 7 arshift dup temp-filt ! . cr
  key? until ;
