\ NRF52 timer words
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE

$40008000 constant &timer0

\ timer base address
: &ti.base ( timer# -- addr )
  12 lshift &timer0 + 1-foldable
;

\ start, stop, count & clear timer
: ti.start ( timer# -- )
  &ti.base 1 swap !
;

: ti.stop ( timer# -- )
  &ti.base $4 + 1 swap !
;

: ti.count ( timer# -- )
  &ti.base $8 + 1 swap !
;

: ti.clear ( timer# -- )
  &ti.base $C + 1 swap !
;

\ errata http://infocenter.nordicsemi.com/topic/com.nordic.infocenter.nrf52832.Rev1.errata/anomaly_832_78.html#anomaly_832_78
: ti.shutdown ( timer# -- )
  &ti.base $10 + 1 swap !
;

: &ti.task_capture ( timer# reg# -- addr )
  2 lshift $40 + swap &ti.base + 2-foldable
;

: &ti.event_compare ( timer# reg# -- addr )
  2 lshift $140 + swap &ti.base + 2-foldable
;

\ short register, compare then clear/stop timer
: ti.c&c ( timer# reg# -- ) \ compare reg# and start over timer#
  bit swap ( val timer# ) &ti.base $200 + !
;
: ti.c&s ( timer# reg# -- ) \ compare reg# and stop timer#
  bit 8 lshift swap ( val timer# ) &ti.base $200 + !
;

\ enable/disable interrupts
: ti.intset ( timer# reg# -- )
  bit 16 lshift swap &ti.base $304 + !
;
: ti.intclr ( timer# reg# -- )
  bit 16 lshift swap &ti.base $308 + !
;

\ mode & bitmode
: ti.timer! ( timer# -- ) \ timer mode
  &ti.base $508 + 0 swap !
;
: ti.count! ( timer# -- ) \ count mode
  &ti.base $508 + 2 swap !
;

0 constant ti.16bit
1 constant ti.8bit
2 constant ti.24bit
3 constant ti.32bit
: ti.bitmode ( mode timer# -- )
  &ti.base 508 + !
;

\ prescaler
: ti.prescaler ( prescale tiemr# -- )
  &ti.base $510 + !
;

\ CC registers
: &ti.cc ( cc# timer# -- addr )
  &ti.base $540 + swap 2 lshift + 2-foldable
;
