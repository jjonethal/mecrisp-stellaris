\ NRF52 basic io words
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE

\ turn a bit position into a single-bit mask
: bit ( u -- u )  
  1 swap lshift  1-foldable 
;

\ ------------------- GPIO
$50000000   constant gpio
gpio $504 + constant gpio.out
gpio $508 + constant gpio.outset
gpio $50c + constant gpio.outclr
gpio $700 + constant gpio.config

\ --- PIN mode
0 bit 3 bit + constant gpiom.outpd
0 bit         constant gpiom.outpu


\ set pin conf
: pin.cnf ( mode pin -- )
  2 lshift gpio.config + !
;

\ pin out
: ios ( pin -- )
  bit gpio.outset !
;

: ioc ( pin -- )
  bit gpio.outclr !
;

\ ------------------- GPIOTE module
$40006000 constant io.gpiote
io.gpiote $510  + constant io.gpiote.config0

1             constant    io.gpiote.event
3             constant    io.gpiote.task
1 16 lshift   constant    io.gpiote.L2H
2 16 lshift   constant    io.gpiote.H2L
3 16 lshift   constant    io.gpiote.TG
0             constant    io.gpiote.L
20 bit        constant    io.gpiote.H

\ configure gpiote
: io.gpiote.conf ( gpiote# pin event/task polarity outinit -- )
  + + swap 8 lshift + swap 2 lshift io.gpiote.config0 + !
;

: io.gpiote.unconf ( gpiote# -- )
  2 lshift io.gpiote.config0 + \ target register address
  0 swap !
;

\ task registers addr
: &io.task.set ( gpiote# -- addr )
  2 lshift $30 + io.gpiote + 1-foldable
;
: &io.task.clr ( gpiote# -- addr )
  2 lshift $60 + io.gpiote + 1-foldable
;
: &io.task.out ( gpiote# -- addr )
  2 lshift io.gpiote + 1-foldable
;

\ do task
: io.gpiote.set ( gpiote# -- )
  &io.task.set 1 swap  !
;
: io.gpiote.clr ( gpiote# -- )
  &io.task.clr 1 swap !
;
: io.gpiote.out ( gpiote# -- )
  &io.task.out 1 !
;


\ event register address
: &io.evt ( evt# -- addr )
  2 lshift io.gpiote + $100 + 1-foldable
;

\ trigger event
: io.gpiote.evt ( evt# -- )
  &io.evt 1 swap !
;

\ -------------------- Event Generator Unit
$40014000 constant io.EGU0

\ get EGU base
: &io.EGU ( group -- addr )
  12 lshift io.EGU0 + 1-foldable
;

\ trigger register's addr
: &io.EGU! ( event group -- addr ) 
  &io.EGU swap 2 lshift + 2-foldable
;

\ set trigger
: io.EGU! ( event group -- )
  &io.EGU! 1 swap !
;

\ event register's addr
: &io.EGU@ ( event group -- addr ) 
  &io.EGU! $100 + 2-foldable
;

\ get event 
: io.EGU@ ( event group -- flag )
  &io.EGU@ @ 
;

\ clear event 
: io.EGU.clr ( event group -- )
  &io.EGU@ 0 swap ! 
;

\ EGU interutps
: io.EGU.intset ( event group -- )
  swap bit swap &io.EGU $304 + !
;
: io.EGU.intclr ( event group -- )
  swap bit swap &io.EGU $308 + !
;


\ -------------------- PPI channel
$4001f000     constant    io.ppi

\ channel config
: io.chen.enable ( chen# -- )
  bit io.ppi $504 + !
;

: io.chen.disable ( chg# -- )
  bit io.ppi $508 + !
;

\ channels addr
: &io.eep ( chen# -- addr )
  3 lshift io.ppi + $510 + 1-foldable
;
: &io.tep ( chen# -- addr )
  3 lshift io.ppi + $514 + 1-foldable
;
: &io.ftep ( chen# -- addr )
  2 lshift io.ppi + $910 + 1-foldable
;

\ configure a ppi connection
: io.ppi! ( &evt &task chan# -- )
  dup >r &io.tep  !
  r> &io.eep !
;
