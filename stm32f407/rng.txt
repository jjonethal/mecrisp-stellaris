
\ random number generator interface
\ contact: sstasiak@gmail.com
\ note: ensure that pll48clk is up and running

$50060800      constant rng-base
rng-base $00 + constant rng-cr
rng-base $04 + constant rng-sr
rng-base $08 + constant rng-dr

%0100 constant RNGEN
%0001 constant DRDY

$40023800      constant rcc-base
rcc-base $14 + constant rcc-ahb2rstr
rcc-base $34 + constant rcc-ahb2enr

%01000000 constant RNGCLKEN
%01000000 constant RNGRST

: rng-on ( -- )
    RNGCLKEN rcc-ahb2enr bis!       \ route clk to rng
    RNGRST rcc-ahb2rstr bic!        \ deassert rng reset
;

: rng-off ( -- )
    RNGRST rcc-ahb2rstr bis!        \ assert rng reset
;

: ?rnd ( -- flag )
    DRDY rng-sr bit@                \ rnd ready?
;

: rng-init ( -- )
    rng-on
    RNGEN rng-cr bis!               \ enable rng
;

: rng-reset ( -- )
    rng-off
    rng-init
;

: rnd ( -- rnd_num )
    begin ?rnd until                \ block until ready
    rng-dr @                        \ return rnd number
;

\ simple usage:
\   rng-init (or rng-reset)
\   rnd
