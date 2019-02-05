\ =========================================================================
\  File: date-time.fs for Mecrisp-Stellaris by Matthias Koch
\ 
\  This file contains these words:
\ 
\    Convert between hours, minutes, seconds and decimal hours
\                   hms->hr, hr->hms
\ 
\    Convert between year, month, day, hours, minutes, seconds and
\    Julian Day
\                   ymdhms->jd, jd->ymdhms
\
\    Convert between Julian Day and Modified Julian Day Hours (which
\    is the Modified Julian Day converted to hours)
\                   mjdhr->jd, jd->mjdhr
\ 
\    Convert between Julian Day and Unix time hours (Unix time converted
\    to hours)
\                   uxhr->jd, jd->uxhr
\
\    Calculate day of year from year, month, and day
\                   ymd->dayofyear        
\ 
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.04.10
\ =========================================================================

compiletoflash

\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\ Most positive and negative s31.32 values possible
$FFFFFFFF $7FFFFFFF 2constant +inf  \ 2147483647,9999999999
$0 $80000000 2constant -inf         \ 2147483648,0

\ Unsigned single divide and mod
: u/ ( u u -- u ) u/mod nip 2-foldable ;
: umod ( u u -- u ) u/mod drop 2-foldable ;

\ Return the floor of an s31.32 value df
: floor ( df -- df ) nip 0 swap 2-foldable ;

\ Convert single value to s31.32
: s>df ( n -- df ) 0 swap 1-foldable ;

\ Convert a s31.32 value to single with rounding
: df>s ( df -- n ) 
  2dup +inf 1,0 d- d> not if
    0,5 d+ floor 
  else
    \ Within 0.5 of +inf, so truncate instead
    +inf
  then
  nip
  2-foldable
;

\ Simple print of year, month, day, hour, minute, second
: .ymdhms 2rot swap . . 2swap swap . . swap . . ;

\ Simple print of hour, minute, second
: .hms rot . swap . . ;

: .HH:MM:SS ( hh mm ss -- )
  \ Pretty print of hours, minutes, and seconds
  rot 
  0 <# # # [char] : hold< #> type
  swap
  0 <# # # [char] : hold< #> type
  0 <# # # #> type space
;

: .YYYY.MM.DD ( yyyy mm dd -- )
  \ Pretty print of year, month, and day (assumes 4 digit year)
  rot 
  0 <# # # # # [char] . hold< #> type
  swap
  0 <# # # [char] . hold< #> type
  0 <# # # #> type space
;

\ -------------------------------------------------------------------------
\  Time/date functions
\ -------------------------------------------------------------------------
: hms->hr ( hh mm ss -- dechr ) ( n n n -- df )
  \ Given single values for hour, minute, and second, return decimal hours
  \ as an s31.32 value.  It is assumed that 24-hour format is used.
  s>df 60,0 f/ rot s>df d+ 60,0 f/ rot s>df d+ 
  3-foldable
;

: hr->hms ( dechr -- hh mm ss ) ( df -- n n n )
  \ Convert an s31.32 decimal hours value to hour, minute, and second
  \ single values.  The second value is rounded, which may introduce
  \ complications if this version is used in combination with date
  \ conversion and the time rounds up to 24:00:00. 
  swap 0 60,0 f* swap 0 60,0 f* swap 0
  ( hh mm ss fractionalsec ) ( n n n df )
  0,5 d< not if 1 + then
  dup 60 = if
    drop 0
    swap 1 + 
    dup 60 = if
      drop 0
      rot 1 + -rot
    then
    swap
  then
  2-foldable
;

: ymdhms->jd ( yyyy mm dd hh mm ss -- jd ) ( n n n n n n -- df )
  \ Given single values for year, month, day, hour, minute, and second, 
  \ return Julian Day as s31,32 value.  The hour, minute, and 
  \ second are assumed to be in UTC with 24-hr format.
  hms->hr 24,0 f/ 1721013,5 d+ rot s>df d+   \ day + 1721013.5 + utc/24
  ( yyyy mm partialjd ) ( s s df )
  \ Add correction term and convert year and month to s31.32
  2swap 2dup swap 100 * + s>df 190002,5 d< if
    2swap 1,0 d+ 2swap
  then
  s>df rot s>df 2swap 2rot
  ( yyyy mm partialjd ) ( df df df )
  2over 275,0 f* 9,0 f/ floor d+    \ Add floor(275*mm/9) to partial jd
  2-rot 9,0 d+ 12,0 f/ floor
  ( partialjd yyyy floor[[mm+9]/12] )
  2over d+ 7,0 f* 4,0 f/ floor dnegate
  ( partialjd yyyy -floor[7*[yy + floor[[mm+9]/12]]/4] )
  2swap 367,0 f* d+ d+
  6-foldable
;

: jd->ymdhms ( jd -- yyyy mm dd hh mm ss ) ( df -- n n n n n n )
  \ Convert an s31,32 Julian Day to year, month, day, hour, minute, second
  \ as single values.  The hour, minute, and second are UTC in 24-hr format.
  \ During conversion, the second value is truncated, not rounded.
  \ Save copy of jd for time calculations later
  2dup
  \ floor(jd + 0.5) = Julian Day Number unsigned single
  0,5 d+ nip
  \ Next next set of calculations are done on unsigned singles
  \ so division truncates
  \ f = JDN + 1363 + [[(4*JDN + 274277)/146097]*3]/4  
  dup 1363 + swap 2 lshift 274277 + 146097 u/ 3 * 2 rshift +
  \ e = 4*f + 3
  2 lshift 3 +
  \ g = mod(e, 1461)/4, h = 5*g + 2
  dup 1461 umod 2 rshift 5 * 2 +
  ( jd e h )
  \ dd = mod(h, 153)/5 + 1
  dup 153 umod 5 u/ 1 + -rot
  ( jd dd e h )
  \ mm = mod(2 + (h/153), 12) + 1
  153 u/ 2 + 12 umod 1 + swap
  ( jd dd mm e )
  \ yyyy = (e/1461) - 4716 + ((14 - mm)/12)
  1461 u/ 4716 - over 14 swap - 12 u/ + swap rot
  ( jd yyyy mm dd )
  \ Retrieve copy of jd and calculate hh mm ss
  0 2rot rot drop
  ( yyyy mm dd jd )
  0,5 d+ drop 0 24,0 f*   \ utc hours = 24*frac(jd + 0.5)
  hr->hms
  ( yyyy mm dd hh mm ss )
  \ At this point we may have hh = 24 due to rounding in hr->hms
  \ in which case we must increment the yyyy mm dd values accordingly
  rot dup 24 = if
    drop 0 -rot
    ( yyyy mm dd 0 mm ss )
    \ Increment yyyy mm dd using conversion to Julian Day and back
    ymdhms->jd 1,0 d+ recurse
  else
    -rot
  then
  2-foldable
;

2400000,5 2constant mjdbase

: jd->mjdhr ( df -- df )
  \ Convert from Julian Day to Modified Julian Day Hours
  mjdbase d- 24,0 f*
  2-foldable
;

: mjdhr->jd ( df -- df )
  \ Convert from Modified Julian Day Hours to Julian Day
  24,0 f/ mjdbase d+
  2-foldable
;

2440587,5 2constant unixbase

: jd->uxhr ( julianday -- unixhrs ) ( df -- df )
  \ Convert Julian Day into Unix hours, which is Unix time divided by 3600.
  \ Input and output are s31.32
  unixbase d- 24,0 f* 
  2-foldable
;

: uxhr->jd ( unixhrs -- julianday ) ( df -- df )
  \ Convert Unix hours, which is Unix time divided by 3600, to Julian Day.
  \ Input and output are s31.32
  24,0 f/ unixbase d+
  2-foldable
;

: ymd->dayofyear ( yyyy mm dd -- n ) ( n n n -- n )
  \ Given year, month, and day, find day of year N given by
  \ N1 = floor(275 * Month / 9)
  \ N2 = floor((Month + 9) / 12)
  \ N3 = (1 + floor((Year - 4 * floor(Year / 4) + 2) / 3))
  \ N = N1 - (N2 * N3) + Day - 30
  \ We use unsigned integer arithmetic so division truncates
  \ n1 = (275*mm)/9
  over 275 * 9 u/ + 30 - -rot
  ( n1+dd-30 yyyy mm )
  \ n2 = (mm+9)/12
  9 + 12 u/ swap
  ( n1+dd-30 n2 yyyy )
  \ n3 = 1 + (yyyy - 4*(yyyy/4) + 2)/3
  dup 2 rshift 2 lshift - 2 + 3 u/ 1 +
  ( n1+dd-30 n2 n3 )
  * -
  3-foldable 
;

\ -------------------------------------------------------------------------
compiletoram
