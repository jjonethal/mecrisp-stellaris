\ led blinkenlights, Port b0+b7+b14

$40020400 Constant GPIOB_MODER
GPIOB_MODER $10 + Constant GPIOB_IDR
GPIOB_MODER $14 + Constant GPIOB_ODR
GPIOB_MODER $18 + Constant GPIOB_BSRR \ bit set/reset register

: portb-clr ( w -- )            GPIOB_BSRR ! ;
: portb-set ( w -- ) $10 lshift GPIOB_BSRR ! ;

: led-init ( -- ) $10004281 GPIOB_MODER ! ;

$0001 Constant led_g
$0080 Constant led_b
$4000 Constant led_r

: +g ( -- ) led_g portb-clr ;
: -g ( -- ) led_g portb-set ;
: +b ( -- ) led_b portb-clr ;
: -b ( -- ) led_b portb-set ;
: +r ( -- ) led_r portb-clr ;
: -r ( -- ) led_r portb-set ;

1000000 Constant delay
: wait ( -- ) delay 0 ?DO LOOP ;

: night-rider1 ( -- )
    +r wait +b wait +g -r wait -b wait +b wait +r -g wait -b ;

: night-rider ( -- )  led-init
    BEGIN  night-rider1  key?  UNTIL  key drop ;
