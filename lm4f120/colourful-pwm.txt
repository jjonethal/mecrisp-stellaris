
\ Timer usage for colourful PWM generation 
\   needs basisdefinitions.txt

$400FE604 constant RCGCTIMER

$40030000 constant GPTM0_CFG \ GPTM Configuration
$40031000 constant GPTM1_CFG

$40030004 constant GPTM0_TAMR \ GPTM Timer A Mode
$40031004 constant GPTM1_TAMR

$40030008 constant GPTM0_TBMR \ GPTM Timer B Mode
$40031008 constant GPTM1_TBMR

$4003000C constant GPTM0_CTL \ GPTM Control
$4003100C constant GPTM1_CTL

$40030028 constant GPTM0_TAILR \ GPTM Timer A Interval Load
$40031028 constant GPTM1_TAILR
$4003002C constant GPTM0_TBILR \ GPTM Timer B Interval Load
$4003102C constant GPTM1_TBILR

$40030030 constant GPTM0_TAMATCHR \ GPTM Timer A Match
$40031030 constant GPTM1_TAMATCHR

$40030034 constant GPTM0_TBMATCHR \ GPTM Timer B Match
$40031034 constant GPTM1_TBMATCHR

$4002552C constant PORTF_PCTL  ( Pin Control )
$40025420 constant PORTF_AFSEL ( Alternate function select )

\ PF1: Red   LED  T0CCP1
\ PF2: Blue  LED  T1CCP0
\ PF3: Green LED  T1CCP1


: rgb ( r g b -- )
  1- GPTM1_TAMATCHR ! \ Duty cycle for Blue
  1- GPTM1_TBMATCHR ! \        ... for Green
  1- GPTM0_TBMATCHR ! \        ... for Red
;

: init-rgb ( PWM-steps -- )
  %11 RCGCTIMER ! \ Enable Clock for Timer 0 und 1
  50 0 do loop    \ Wait a bit

  0 GPTM0_CTL ! \ Stop Timer
  0 GPTM1_CTL !
  
  4 GPTM0_CFG ! \ 16-Bit-Timer Mode
  4 GPTM1_CFG !

  %1010 GPTM0_TBMR ! \ PWM, periodic, for Red
  %1010 GPTM1_TAMR ! \ PWM, periodic, for Blue
  %1010 GPTM1_TBMR ! \ PWM, periodic, for Green

  0 0 0 rgb \ Darkness

  dup GPTM0_TBILR ! \ Set PWM steps
  dup GPTM1_TAILR !
      GPTM1_TBILR !

  $4100 GPTM0_CTL ! \ Inverted Output,  Enable Timer for Red
  $4141 GPTM1_CTL ! \ Inverted Outputs, Enable Timers for Green and Blue
 
  \ Setup Pins on Port F
  %11111 portf_den !   \ LEDs and Buttons are digital Pins
  %01110 portf_dir !   \ LEDs are outputs
  %01110 portf_afsel ! \ Alternative functions for LED pins
  $07770 portf_pctl !  \ Choose Timer-PWM for LED pins
;

512 init-rgb \ Init 512 PWM steps
5 0 14 rgb   \ Violet
