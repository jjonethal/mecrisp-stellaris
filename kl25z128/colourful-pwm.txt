
\ Timer usage for colourful PWM generation 

$4004803C constant SIM_SCGC6
$40048004 constant SIM_SOPT2

$4004A000 constant PORTB_PCR
$4004C000 constant PORTD_PCR

$40038000 constant TPM0_SC
$40038008 constant TPM0_MOD
$40038014 constant TPM0_C1SC
$40038018 constant TPM0_C1V

$4003A000 constant TPM2_SC
$4003A008 constant TPM2_MOD
$4003A00C constant TPM2_C0SC
$4003A010 constant TPM2_C0V
$4003A014 constant TPM2_C1SC
$4003A018 constant TPM2_C1V


: rgb ( r g b -- )
  TPM0_C1V ! \ Duty cycle for Blue
  TPM2_C1V ! \        ... for Green
  TPM2_C0V ! \        ... for Red
;

: init-rgb ( PWM-steps -- )
  $5000000 SIM_SCGC6 bis!    \ Enable clock for Timer 0 and Timer 2
  1 24 lshift SIM_SOPT2 bis! \ Select clock source for Timers

  $0300  18 4 * PORTB_PCR + ! \ TPM2_CH0 enable on PTB18 (red)
  $0300  19 4 * PORTB_PCR + ! \ TPM2_CH1 enable on PTB19 (green)
  $0400   1 4 * PORTD_PCR + ! \ TPM0_CH1 enable on PTD1  (blue)

  0 0 0 rgb \ Leds off.

  dup
      TPM0_MOD !
  $24 TPM0_C1SC !

      TPM2_MOD !
  $24 TPM2_C0SC !
  $24 TPM2_C1SC !

  1 3 lshift TPM0_SC !  \ Edge Aligned PWM running from BUSCLK / 1
  1 3 lshift TPM2_SC !  \ Edge Aligned PWM running from BUSCLK / 1
;

16 init-rgb \ Init 16 PWM steps
5 0 14 rgb   \ Violet
