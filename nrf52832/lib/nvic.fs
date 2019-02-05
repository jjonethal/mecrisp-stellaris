\ nRF52 NVIC words
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE
\   standard cortex M NVIC

$E000E100 constant ISER
$E000E180 constant ICER
$E000E200 constant ISPR
$E000E280 constant ICPR
$E000E400 constant IPR0
$E000EF00 constant STIR

\ enable irq #
: irq.en ( # -- )
  dup 31 > if 
    32 - bit ISER 4 + ! 
  else
    bit ISER !
  then
;
\ disable irq #
: irq.den ( # -- )
  dup 31 > if 
    32 - bit ICER 4 + ! 
  else
    bit ICER !
  then
;

\ trigger irq #, how to clear interrupt status is this case ?
: irq ( # -- )
 STIR !
;
