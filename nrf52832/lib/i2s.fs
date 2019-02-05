\ nrf52 i2S words
\    Copyright (C) 2018  juju2013@github
\    BSD licensed, See LICENSE

\ -------------------- register address
$40025000 constant &I2S
&i2s     $0 + constant &i2s.start
&i2s     $4 + constant &i2s.stop
&i2s   $104 + constant &i2s.rxptrupd
&i2s   $108 + constant &i2s.stopped
&i2s   $114 + constant &i2s.txptrupd
&i2s   $300 + constant &i2s.inten
&i2s   $500 + constant &i2s.en
&i2s   $508 + constant &i2s.rxen
&i2s   $50c + constant &i2s.txen
&i2s   $510 + constant &i2s.mcken
&i2s   $518 + constant &i2s.ratio
&i2s   $538 + constant &i2s.rxd
&i2s   $540 + constant &i2s.txd
&i2s   $550 + constant &i2s.maxcnt

\ --- flags for inten(set/clr)
1 bit  constant i2s.int.rx
2 bit  constant i2s.int.stop
5 bit  constant i2s.int.tx

\ --- Frequence constant
0 constant MCK/32
2 constant MCK/64
8 constant MCK/512

: i2s.start ( -- ) 1 &I2S.start ! 0-foldable ;
: i2s.stop  ( -- ) 1 &I2S.stop ! 0-foldable ;

\ configure interrupt mode
: i2s.intset ( mode -- )
  &i2s $304 + !
;
: i2s.intclr ( mode -- )
  &i2s $308 + !
;

: i2s.master ( ) 0 &i2s $504 + ! ;
: i2s.slave ( ) 1 &i2s $504 + ! ;

\ set master clock frequence, not all frequencies listed, see production manual
: i2s.mckfreq ( freq -- )   \ freq in khz
  dup 16000 = if $80000000 else
  dup  3200 = if $18000000 else
  dup  1032 = if $08400000 else
  dup  1000 = if $08000000 else
  dup   761 = if $06000000 else
  then then then then then swap drop
  &i2s $514 + !
;

\ set i2s width, not all width listed, see production manual
: i2s.width ( width -- )   \ width = 8 16 or 24
  dup  8 = if 0 else
  dup 16 = if 1 else
              2
  then then swap drop
  &i2s $51C + !
;

\ seleciton of MCK pin
: i2s.pin.mck ( pin -- )   \ 0 = disable
  dup 0 = if 31 bit else dup then drop &i2s $560 + !
;

\ seleciton of SCK pin
: i2s.pin.sck ( pin -- )   \ 0 = disable
  dup 0 = if 31 bit else dup then drop &i2s $564 + !
;

\ seleciton of LRCK pin
: i2s.pin.lrck ( pin -- )   \ 0 = disable
  dup 0 = if 31 bit else dup then drop &i2s $568 + !
;

\ seleciton of SDIN pin
: i2s.pin.sdin ( pin -- )   \ 0 = disable
  dup 0 = if 31 bit else dup then drop &i2s $56c + !
;

\ seleciton of SDOUT pin
: i2s.pin.sdout ( pin -- )   \ 0 = disable
  dup 0 = if 31 bit else dup then drop &i2s $570 + !
;

