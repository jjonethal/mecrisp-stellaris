\ =========================================================================
\  File: date-time-tests.fs for Mecrisp-Stellaris by Matthias Koch
\ 
\  This file contains these words to test words in date-time.fs.  See the
\  the comments in that file for more information.
\ 
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.04.10
\ =========================================================================

#include date-time.fs
compiletoflash

\ -------------------------------------------------------------------------
\  Test functions for date and time functons
\ -------------------------------------------------------------------------

\ Round s31.32 value to (approximately) 9 decimal places and display it
: f.r9 ( df -- )  2 0 2over d0< if d- else d+ then 9 f.n ;  
    
\ Same as above, but for 7 decimal places
: f.r7 ( df -- )  215 0 2over d0< if d- else d+ then 7 f.n ; 

: tab ( -- )  9 emit ;

: hms-hr-test1
  0 0 0 hms->hr
  cr cr ." Convert from HR to HMS and back to HR" cr 
  ." HR In" tab tab ." HR Out" cr
  32 0 do
    2dup f.r9 2dup hr->hms hms->hr tab f.r9 cr
    0 45 0 hms->hr d+
  loop
  cr
;

: hms-hr-test2
  cr cr ." Convert from HMS to HR and back to HMS" cr 
  ." HMS In" tab tab tab ." HMS Out" cr
  0 0 0 0 0 0         .hms hms->hr hr->hms tab tab tab .hms cr
  9 30 30 9 30 30     .hms hms->hr hr->hms tab tab .hms cr
  12 59 59 12 59 59   .hms hms->hr hr->hms tab tab .hms cr
  16 15 25 16 15 25   .hms hms->hr hr->hms tab tab .hms cr
  20 0 45 20 0 45     .hms hms->hr hr->hms tab tab .hms cr
  23 59 59 23 59 59   .hms hms->hr hr->hms tab tab .hms cr
  cr
;

: ymdhms-jd-test1
  2018 1 1 0 0 0 ymdhms->jd
  cr cr ." Convert from JD to YMD HMS back to JD" cr 
  ." JD In" tab tab ." JD Out" cr
  49 0 do
    2dup f.r9 2dup jd->ymdhms ymdhms->jd tab f.r9 cr
    15,25 d+  
  loop
  2drop cr
;

: ymdhms-jd-test2
  cr cr ." Convert from YMDHMS to JD and back to YMDHMS" cr 
  ." YMDHMS In" tab tab ." YMDHMS Out" cr
  2018 1 1 0 0 0 2018 1 1 0 0 0 .ymdhms ymdhms->jd jd->ymdhms
  tab tab .ymdhms cr
  2018 4 1 16 35 40 2018 4 1 16 35 40 .ymdhms ymdhms->jd jd->ymdhms
  tab .ymdhms cr
  2018 12 31 23 59 59 2018 12 31 23 59 59 .ymdhms ymdhms->jd jd->ymdhms
  tab .ymdhms cr  
  cr
;

: ymdhms-jd-test3
  cr cr ." Input YMDHMS" cr
  2018 12 31 23 59 59 2018 12 31 23 59 59 .ymdhms cr
  ymdhms->jd floor 0,499999999 d+ jd->ymdhms
  ." Output YMDHMS after round up tweek" cr
  .ymdhms cr
  cr
;

\ -------------------------------------------------------------------------
compiletoram
