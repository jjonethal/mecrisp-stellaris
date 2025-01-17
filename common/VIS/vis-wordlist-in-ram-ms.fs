\    Filename: vis-wordlist-in-ram-ms.fs
\     Purpose: Display all RAM words of a given wordlist.
\    Required: Mecrisp-Stellaris RA 2.3.8 or later by Matthias Koch.
\              vis-0.8.4-mecrisp-stellaris.fs      by Manfred Mahlow
\         MCU: *
\       Board: * , tested with TI StellarisLaunchPad 
\ Recommended: e4thcom Terminal
\      Author: Manfred Mahlow          manfred.mahlow@forth-ev.de
\    Based on: -
\     Licence: GPLv3
\   Changelog: 2021-04-07 derived from VIS for Mecrisp Quintus

inside
#ifndef traverse-wordlist  #include vis-traverse-wordlist-ms.fs

inside definitions  decimal

voc wordlist-in-ram  @voc wordlist-in-ram definitions

: \?id ( lfa -- tf )
  inside also
  dup smudged? if space .id else drop then true 
  previous
;

: words ( wid )
\ Display all RAM words of the wordlist wid.
  inside also
  @voc ['] \?id swap ( xt wid ) traverse-wordlist-in-ram
  previous
;

forth definitions


