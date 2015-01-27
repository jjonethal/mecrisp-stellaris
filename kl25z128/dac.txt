
\ DAC Signal generation

$4004803C constant SIM_SCGC6

\ DAC registers - 8-Bits wide
$4003F000 constant DAC0_DAT0L \ DAC Data Low Register (DAC0_DAT0L)
$4003F001 constant DAC0_DAT0H \ DAC Data High Register (DAC0_DAT0H)
$4003F002 constant DAC0_DAT1L \ DAC Data Low Register (DAC0_DAT1L)
$4003F003 constant DAC0_DAT1H \ DAC Data High Register (DAC0_DAT1H)
$4003F020 constant DAC0_SR \ DAC Status Register (DAC0_SR)
$4003F021 constant DAC0_C0 \ DAC Control Register (DAC0_C0)
$4003F022 constant DAC0_C1 \ DAC Control Register 1 (DAC0_C1)
$4003F023 constant DAC0_C2 \ DAC Control Register 2 (DAC0_C2)

: dac ( u -- ) DAC0_DAT0L h! ; \ 0 - 4095

: init-dac ( -- )
  1 31 lshift sim_scgc6 bis! \ Enable clock for DAC

  $80 DAC0_C0 c! \ For Vcc as Reference VREFH (shortened to VDDA on Freedom board, about 3V)
  0 dac
;

