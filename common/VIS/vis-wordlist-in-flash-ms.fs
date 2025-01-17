\    Filename: vis-wordlist-in-flash-ms.fs
\     Purpose: Display all FLASH words of a given wordlist.
\    Required: Mecrisp-Stellaris RA 2.3.8 or later by Matthias Koch.
\              vis-0.8.4-mecrisp-stellaris.fs      by Manfred Mahlow
\         MCU: *
\       Board: * , tested with TI StellarisLaunchPad 
\ Recommended: e4thcom Terminal
\      Author: Manfred Mahlow          manfred.mahlow@forth-ev.de
\    Based on: -
\     Licence: GPLv3
\   Changelog: 2021-04-07 derived from VIS for Mecrisp Quitntus

inside
#ifndef traverse-wordlist  #include vis-traverse-wordlist-ms.fs

inside definitions decimal

voc wordlist-in-flash  @voc wordlist-in-flash definitions

voc reversed  @voc reversed also definitions

\ 10 constant size  \ faster
   2 constant size  \ slowest

  0 variable cnt
 -1 variable stop

  size cells buffer: buffer  \ to store FLASH words in reverse order

: show ( -- )
  buffer size cnt @ min cells + buffer
  ?do i @  inside .id space  1 cells +loop  0 cnt !
;

: append ( lfa -- )
  size 2 - buffer over cells + 
  begin 
    dup @ over cell+ ! over 
  while
    4 - swap 1- swap 
  repeat
  2drop  buffer !
  1 cnt +!
;

: ?id+ ( lfa -- f )
  dup stop @ = if drop 0 exit then
  dup inside smudged? if ( dup .) append -1 else drop -1 then
;

inside wordlist-in-flash definitions

: words ( wid -- ) 
\ Display all FLASH words of the wordlist wid.
  >r -1 stop !
  begin
    0 cnt !
    ['] ?id+ r@ inside traverse-wordlist-in-flash
    cnt @ 0<> key? if key drop ." ..."  0 else -1 then and
  while
    cnt @ size min 1- 0 max cells buffer + @ stop !
    show
  repeat
  r> drop
;

previous

forth definitions

\ EOF

