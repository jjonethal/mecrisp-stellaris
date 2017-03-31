

$E000E010 constant STK_CTRL
$E000E014 constant STK_LOAD
$E000E018 constant STK_VAL
$E000E01c constant STK_CALIB

0 variable _millis
: mysystick 
1 _millis +!
;

: systick-init
0 _millis !
12500000 1001 / STK_LOAD !
['] mysystick irq-systick !
-1 nvic-enable 
3 STK_CTRL !
;

: millis _millis @ ;
: init systick-init init ;
