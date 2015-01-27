
\ Analog signal input

$4004803C constant SIM_SCGC6

\ ADC registers - 32-Bits wide

$4003B000 constant ADC0_SC1A \ ADC Status and Control Registers 1 (ADC0_SC1A)
$4003B004 constant ADC0_SC1B \ ADC Status and Control Registers 1 (ADC0_SC1B)
$4003B008 constant ADC0_CFG1 \ ADC Configuration Register 1 (ADC0_CFG1)
$4003B00C constant ADC0_CFG2 \ ADC Configuration Register 2 (ADC0_CFG2)
$4003B010 constant ADC0_RA   \ ADC Data Result Register (ADC0_RA)
$4003B014 constant ADC0_RB   \ ADC Data Result Register (ADC0_RB)
$4003B018 constant ADC0_CV1  \ Compare Value Registers (ADC0_CV1)
$4003B01C constant ADC0_CV2  \ Compare Value Registers (ADC0_CV2)
$4003B020 constant ADC0_SC2  \ Status and Control Register 2 (ADC0_SC2)
$4003B024 constant ADC0_SC3  \ Status and Control Register 3 (ADC0_SC3)
$4003B028 constant ADC0_OFS  \ ADC Offset Correction Register (ADC0_OFS)
$4003B02C constant ADC0_PG   \ ADC Plus-Side Gain Register (ADC0_PG)
$4003B030 constant ADC0_MG   \ ADC Minus-Side Gain Register (ADC0_MG)


: init-adc ( -- )
  1 27 lshift sim_scgc6 bis! \ Enable clock for ADC

  3 5 lshift 
  3 2 lshift or ADC0_CFG1 ! \ 16 Bit Single Ended, Clock divider /8 --> 20.97 MHz / 8 = 2.62 MHz
  7             ADC0_SC3  ! \ Average 32 samples

  $80 ADC0_SC3 bis! \ Start calibration
  begin $80 ADC0_SC3 bit@ not until \ Wait for calibration to be completed
  $40 ADC0_SC3 bit@ if ." ADC calibration failed." then

  $4003B034 @
  $4003B038 @ +
  $4003B03C @ +
  $4003B040 @ +
  $4003B044 @ +
  $4003B048 @ +
  $4003B04C @ +  2/ $FFFF and $8000 or ADC0_PG !

  $4003B054 @
  $4003B058 @ +
  $4003B05C @ +
  $4003B060 @ +
  $4003B064 @ +
  $4003B068 @ +
  $4003B06C @ +  2/ $FFFF and $8000 or ADC0_MG !
;

: analog ( channel -- value )
  $1F and ADC0_SC1A ! \ Select channel
  begin $80 ADC0_SC1A bit@ until \ Wait for conversion completed
  ADC0_RA @ \ Read result
;
