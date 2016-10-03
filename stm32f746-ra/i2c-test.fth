\ i2c-driver
: i2c-init
   i2c-gpio-cfg
   i2c-clk-on
   i2c-reset ;
: sys-clock-handler ;

: demo-control ;
: demo-init ;


: sound-control-init ;
: sound-control-fade-in ;
: sine 440 hz 50 ms tonegen1 ;
: drum white noise ;
: next-sample ( -- ) ;   \ execute on each sample
\ filter structure biquad filter
\ biq-in-ptr
\ biq-out
\ biq-gain-in-pre
\ biq-gain-out
\ biq-c0
\ biq-c1
\ biq-c2
\ biq-c3
\ biq-y1
\ biq-y2
\ biq-y3
\ biq-y4
: biquad ( a -- ) ;
: