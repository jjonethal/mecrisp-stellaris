\ nrf62 random number generator words
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE

\ ----------------- register addresses
$4000D000  constant rng
rng        constant &rng.start
rng $004 + constant &rng.stop
rng $100 + constant &rng.valrdy
rng $200 + constant &rng.short
rng $304 + constant &rng.intset
rng $308 + constant &rng.intclr
rng $504 + constant &rng.config
rng $508 + constant &rng.value

: rng.init
  1 &rng.short ! \ generate only 1 value then stop
  1 &rng.start !
;

\ get a previously generated random number
\   make sur some delay between call this !
: rng@ ( -- c )
  &rng.value @ \ return previous value
  1 &rng.start !
;
