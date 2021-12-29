\ Edge follower for Elecfreaks Ring:bit 
\ Dark left, Bright right
\ Button A to start, Button B to stop
\ blinky.txt, analog.txt and dual-pwm.fs must be loaded first



%00100.01110.10101.00100.00100 drop constant ^|
%00100.00100.10101.01110.00100 drop constant v|
%00100.01000.11111.01000.00100 drop constant <-
%00100.00010.11111.00010.00100 drop constant ->



: ahead
  500 speed_motor1 !
  2500 speed_motor2 !
;

: back
  2500 speed_motor1 !
  500 speed_motor2 !
;

: left
  500 speed_motor1 !
  1500 speed_motor2 !
;

: right
  1500 speed_motor1 !
  2500 speed_motor2 !
;

: stop
  1500 speed_motor1 !
  1500 speed_motor2 !
;

: a_to_dir ( analog -- direction )
    dup 400 < if
      1
    else
    dup 700 < if
      2
    else
    dup 900 < if
      3
    else
      4
      then
      then
      then
    swap drop
;

0 variable onoff

: follower ( -- )
  begin
    onoff @ 0<>
    if
      3 analog a_to_dir
      case
       1 of -> right endof
       2 of v| ahead endof
       3 of ^| back endof
       4 of <- left endof
     endcase
     buttonb 
     if
       drop :-)
       0 onoff !
       stop
     then
     matrix
    then
    buttona
    if
     1 onoff !
    then
  key? until
;

: init
  init-matrix
  matrix-on
  :-) matrix
   init-analog
  2 1 init-motors
  follower
;
