\ joystick and led demo for STM32L476 Discovery board
\
\ LEDS
\ PB2 - user led red
\ PE8 - user led gren
\
\ Joystick
\ PA0 - center
\ PA1 - left
\ PA2 - right
\ PA3 - up
\ PA5 - down
compiletoflash 
\ Cornerstone for 2 kb Flash pages

: cornerstone ( Name ) ( -- )
  <builds begin here $7FF and while 0 h, repeat
  does>   begin dup  $7FF and while 2+   repeat 
          eraseflashfrom
;

: esc?  ( -- f )                              \ escape key on terminal pressed ?
   key? if key #27 = else 0 then ;


\ ********** register definitions ************
$40021000        constant RCC_BASE
$4C RCC_BASE or  constant RCC_AHB2ENR

\ ********** GPIO registers ******************
$48000000        constant GPIOA
: gpio-port  ( n -- a )                       \ calc gpio port adress from number A:0 ... h:7
   #10 lshift gpioa or 1-foldable ;

GPIOA   0 or     constant GPIOA_MODER
GPIOA $10 or     constant GPIOA_IDR
GPIOA  $C or     constant GPIOA_PUPD
1 gpio-port      constant GPIOB
4 gpio-port      constant GPIOE
$18 GPIOB or     constant GPIOB_BSRR
$18 GPIOE or     constant GPIOE_BSRR

\ ***** joystick directions and buttons ******
1                constant j-center
1 1 lshift       constant j-left
1 2 lshift       constant j-right
1 3 lshift       constant j-up
1 5 lshift       constant j-down

: joystick-init  ( -- )                       \ initialize joystick
   1 RCC_AHB2ENR bis!                         \ enable clock on gpio port A
   %110011111111 GPIOA_MODER bic!             \ input mode
   %110011111111 GPIOA_PUPD bic!              \ pull down mode
   %100010101010 GPIOA_PUPD bis! ;
: joystick? ( -- n )                          \ current joystick state
    GPIOA_IDR @ %101111 and ;
0 variable joy-state                          \ store last joystick state

\ LED demo program
: led-init  ( -- )                            \ initialize the leds
   1 1 lshift RCC_AHB2ENR bis!                \ enable clock on gpio port B
   1 4 lshift RCC_AHB2ENR bis!                \ enable clock on gpio port E
   3 4 lshift GPIOB bic!                      \ PB2 output
   1 4 lshift GPIOB bis!                      \ PB2 output
   3 16 lshift GPIOE bic!                     \ PE8 output
   1 16 lshift GPIOE bis! ;                   \ PE8 output
: led-red-on  ( -- )                          \ turn red led on
   1 2 lshift GPIOB_BSRR ! ;
: led-red-off  ( -- )                         \ turn red led off
   1 2 16 + lshift GPIOB_BSRR ! ;
: led-green-on  ( -- )                        \ turn green led on
   1 8 lshift GPIOE_BSRR ! ;
: led-green-off  ( -- )                       \ turn green led off
   1 8 16 + lshift GPIOE_BSRR ! ;
: wait  ( n -- )                              \ wait for n loops
   0 do loop ;
: long-wait  ( -- )                           \ wait for a while
   6000000 wait ;
: led-demo  ( -- )                            \ led demo exit with Escape key
   led-init
   begin
     led-green-on
     led-red-on
     long-wait
     led-green-off
     led-red-off
     long-wait
  esc? until ;

: joystick-actions ( -- f ) \ center ?
   joy-state @
   joystick? dup joy-state !
   tuck xor and
   dup j-center and if ." Center " led-green-off led-red-off cr then
   dup j-left   and if ." Left   " led-green-off cr then
   dup j-right  and if ." Right  " led-green-on cr then
   dup j-up     and if ." Up     " led-red-off cr then
   dup j-down   and if ." Down   " led-red-on cr then
   j-center and if 1 else 0 then ;

  
\ joystick demo
: joystick-demo ( -- )                        \ press Escape to exit demo
   led-init
   joystick-init
   begin
     joystick-actions
   until ;
: init joystick-demo ;
