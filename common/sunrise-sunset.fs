\ ------------------------------------------------------------------------- 
\  sunrise-sunset-v2.fs for Mecrisp-Stellaris Forth by Matthias Koch
\ 
\  Source:
\ 	 Almanac for Computers, 1990
\ 	 published by Nautical Almanac Office
\ 	 United States Naval Observatory
\ 	 Washington, DC 20392
\ 
\  Inputs:
\   year, month, day:  date of sunrise/sunset (integers)
\ 	latitude, longitude:  location for sunrise/sunset (s31.32)
\   zenith: Sun's zenith for sunrise/sunset (see zenith code below)
\         offical      = 90 degrees 50' = 90,8333333333 degrees
\	        civil        = 96 degrees
\	        nautical     = 102 degrees
\	        astronomical = 108 degrees
\   Local time zone utc offset (integer)
\
\  Andrew Palm
\  2018.02.23
\ ------------------------------------------------------------------------- 
\ Include trig and square root functions
#include fixpt-math-lib.fs

compiletoflash
\ ------------------------------------------------------------------------- 
\  Helper words, constants, and variables
\ ------------------------------------------------------------------------- 
\ Calculate the floor of the s31.32 value fd, returned as signed integer.
\ The value mfloor(x) is the greatest integer less than or equal to x.
: mfloor ( fd -- n )  swap drop ;

\ Convert signed integer to s31.32
: s>df ( n -- df)  0 swap ;

\ Calculate the floor of the s31.32 value fd, returned as s31.32
\ The value floor(x) is the greatest integer less than or equal to x. 
: floor ( df -- df ) mfloor s>df ;

: hour0to24 ( df1 -- df2 )  24,0 d/mod 2drop 2dup d0< if 24,0 d+ then ;

: .hh:mm:ss ( df -- ) 
  0 <# # # [char] : hold< #> type
  0 60,0 f* 0 <# # # [char] : hold< #> type
  0 60,0 f* 0 <# # # hold< #> type space
;

\ ------------------------------------------------------------------------- 
\ The next word sets the zenith code for sunrise and sunset.
\ It should be executed prior to sunrise and sunset calculations.
0 variable zenith-code
  \     zenith-code       zenith(deg)      Description
  \         0           90,8333333333       Official
  \	        1                96           Civil Twilight
  \	        2               102          Nautical Twilight
  \	        3               108            Astronomical

: set-zenith-code ( n -- )  zenith-code ! ;

\ ------------------------------------------------------------------------- 
\ Words for calculating sunrise and sunset times given a latitude and
\ longitude and a date.
\ Times and angles are s31.32 values
0 variable N    \ Day of year

\ Calc day of year
: day-of-year ( yyyy mm dd -- )
  \ Given input yyyy = year, mm = month, and dd = day as integers, 
  \ store day of the year in N using the equations:
	\ N1 = floor(275 * month / 9)
	\ N2 = floor((month + 9) / 12)
	\ N3 = (1 + floor((year - 4 * floor(year / 4) + 2) / 3))
	\ N = N1 - (N2 * N3) + day - 30
  -rot dup 275 * s>df 9,0 f/ mfloor  \ Stack: (dd yyyy mm N1)
  swap 9 + s>df 12,0 f/ mfloor       \ Stack: (dd yyyy N1 N2)
  rot dup s>df 4,0 f/ mfloor 2 lshift - 2 + 
  s>df 3,0 f/ mfloor 1 +             \ Stack: (dd N1 N2 N3)
  * - + 30 - N !
; 

0,0 2variable lngHour
0,0 2variable t

: approx-time ( rise-flag longitude -- )
  \ Convert the s31.32 longitude to hour value and calculate approx time
  \ If rise-flag is true, calc sunrise, otherwise sunset
  \	lngHour = longitude / 15
  \	For t-rise = N + ((6 - lngHour) / 24)
  \	For t-set = N + ((18 - lngHour) / 24)
  15,0 f/ 2dup lngHour 2! 
  rot if 6,0 else 18,0 then
  2swap d- 24,0 f/ N @ s>df d+ t 2!
;

0,0 2variable M

: mean-anomaly ( -- )
  \ Calculate Sun's mean anomaly M
	\ M = (0.9856 * t) - 3.289
  t 2@ 0,9856 f* 3,289 d- deg0to360 M 2!
;

0,0 2variable L

: sun-true-long ( -- )
  \ Calculate the Sun's true longitude
	\ L = M + (1.916 * sin(M)) + (0.020 * sin(2 * M)) + 282.634
  M 2@ 2dup 2dup 2,0 f* sin 0,02 f* 282,634 d+
  2swap sin 1,916 f* d+ d+ deg0to360 L 2!
;

0,0 2variable RA
: sun-rt-ascension ( -- )
  \ Calculate Sun's right ascension
	\ RA = atan(0.91764 * tan(L))
  L 2@ tan 0,91764 f* atan deg0to360 RA 2!
  \ Right ascension value needs to be in the same quadrant as L
  \ Lquadrant  = (floor( L/90)) * 90
	\ RAquadrant = (floor(RA/90)) * 90
	\ RA = RA + (Lquadrant - RAquadrant)
  L 2@ 90,0 f/ floor 90,0 f*
  RA 2@ 90,0 f/ floor 90,0 f*
  d- RA 2@ d+ 
  \ Convert to hours
  15,0 f/ RA 2! 
;

0,0 2variable sinDec
0,0 2variable cosDec

: sun-dec ( -- )
  \ Calculate the Sun's declination
	\ sinDec = 0.39782 * sin(L)
	\ cosDec = cos(asin(sinDec))
  L 2@ sin 0,39782 f* 2dup sinDec 2!
  asin cos cosDec 2!
;

0,0 2variable H

: sun-loc-hr-ang ( rise-flag latitude -- )
  \ Calc sun's local hour angle from s31.32 latitude
	\ cosH = (cos(zenith)-(sinDec*sin(latitude)))/(cosDec*cos(latitude))
  zenith-code @ case
    0 of 90,8333333333  endof
    1 of 96,0           endof
    2 of 102,0          endof
    3 of 108,0          endof
  endcase
  cos 2over sin sinDec 2@ f* d- 2swap cos cosDec 2@ f* f/
  \ Stack: ( rise-flag cosH )
  2dup dabs 1,0 d> if
    cr ." *** cosH out of range, too near pole.  Ignore result." cr
    0,0 
  else
    rot if
      acos 360,0 2swap d-
    else
      acos
    then
  then
  \ Convert angle to hours
  15,0 f/ H 2!
;  

0,0 2variable UTC

: utc-mean-time ( -- )
  \ Calculate UTC of rising or setting
	\ UTC = H + RA - (0.06571 * t) - 6.622 - lngHour
  H 2@ RA 2@ d+ t 2@ 0,06571 f* d- 6,622 d- lngHour 2@ d- 
  hour0to24 UTC 2!
;

\ ------------------------------------------------------------------------- 
0,0 2variable utc-rise
0,0 2variable utc-set

: sunrise-sunset-utc ( lat long yyyy mm dd -- )
  \ Calculate sunrise and sunset times in UTC decimal hours at latitude
  \ lat and longitude long (s31.32 values) for date yyyy mm dd (integers). 
  \ The value of the variable zenith-code is used, and must be set prior
  \ to using this word with set-zenith-code.   
  day-of-year
  \ Sunrise time
  2over 2over
  -1 -rot approx-time mean-anomaly sun-true-long sun-rt-ascension
  sun-dec -1 -rot sun-loc-hr-ang utc-mean-time
  UTC 2@ utc-rise 2!
  \ Sunset time
  0 -rot approx-time mean-anomaly sun-true-long sun-rt-ascension
  sun-dec 0 -rot sun-loc-hr-ang utc-mean-time
  UTC 2@ utc-set 2!
;

\ ------------------------------------------------------------------------- 
\ Use this word only after sunrise and sunset times have been calculated
: show-local-times ( n -- )
  \ Display the local sunrise, sunset, solar noon, and hours of
  \ daylight in HH:MM:SS format.
  \ Note: If zenith code was set to 1 for sunrise-sunset-utc, this word 
  \       gives total hours of daylight plus civil twilight, for zenith
  \       code 2 the total hours of daylight plus nautical twilight.
  \ Input n is the local utc offset as a signed integer.
  dup dup dup
  s>df utc-rise 2@ d+ hour0to24 
  cr ." Sunrise: " .hh:mm:ss
  s>df utc-set 2@ d+ hour0to24 
  cr ." Sunset: " .hh:mm:ss
  s>df 2dup utc-set 2@ d+ hour0to24 
  2swap utc-rise 2@ d+ hour0to24 d-
  cr ." Daylight: " .hh:mm:ss
  s>df 2dup utc-set 2@ d+ hour0to24
  2swap utc-rise 2@ d+ hour0to24
  d+ 2,0 f/ 
  cr ." Solar noon: " .hh:mm:ss
  cr
;

compiletoram

\ How to calculate sunrise and sunset:

0 set-zenith-code
54,186926 7,885309  2018 04 01  sunrise-sunset-utc
2 show-local-times

