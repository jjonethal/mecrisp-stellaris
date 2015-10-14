\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4

$40021000       constant RCC_BASE
$14 RCC_BASE or constant RCC_AHBENR
$1C RCC_BASE or constant RCC_APB1ENR
$48000400       constant gpiob
gpiob           constant gpiob_moder
$04 gpiob or    constant gpiob_otyper
$10 gpiob or    constant gpiob_idr
$18 gpiob or    constant gpiob_bsrr
$20 gpiob or    constant gpiob_afrl
1 6 lshift constant i2c-scl
1 7 lshift constant i2c-sda

: scl-h ( -- ) i2c-scl           gpiob_bsrr ! ;
: scl-l ( -- ) i2c-scl 16 lshift gpiob_bsrr ! ;
: sda-h ( -- ) i2c-sda           gpiob_bsrr ! ;
: sda-l ( -- ) i2c-sda 16 lshift gpiob_bsrr ! ;
: delay ( -- )  20 0 do loop inline ;
: scl-@ ( -- f ) delay i2c-scl gpiob_idr bit@ ;
: sda-@ ( -- f ) delay i2c-sda gpiob_idr bit@ ;

: i2c-init ( -- )
  1 #21 lshift RCC_APB1ENR bis! \ enable port b
  gpiob_moder @ $f000 not and $A000 or gpiob_moder ! \ alternate function 
  i2c-scl i2c-sda lshift or gpiob_otyper bis!      \ open drain
  $FF000000 gpiob_afrl bic! $44000000 gpiob_afrl bis! ; \ i2c mode 

: enum dup constant 1+ ;

0 enum >i2c->idle
  enum >i2c->tx-start
  enum >i2c->tx-reg
  enum >i2c->tx-data
  enum >i2c->tx-complete
  enum >i2c->rx-start
  enum >i2c->rx-reg
  enum >i2c->rx-read-start
  enum >i2c->rx-data
  enum >i2c->rx-complete
  enum >i2c->abort
  constant i2c->num-states
>i2c->idle variable  i2c-state
: i2c-state! i2c-state ! inline ;
: -> ( "state-id" )  \ state-id i2c-state !
   ' .s dup 0<>
     if execute dup 0< not and dup i2c->num-states < and literal, postpone i2c-state!
     else quit
     then immediate ;

: test -> >i2c->tx-reg i2c-state @ . ;
test
: i2c->idle ;
: i2c->tx-start i2c-adr-mode7 i2c-slave-adr7 i2c-wr i2c-no-autoend i2c-bytes i2c-start -> >i2c->tx-reg ;
: i2c->tx-reg 0 case 
   i2c-txis?  ?of i2c-tx-reg                 -> >i2c->tx-data       endof
   i2c-nackf? ?of                            -> >i2c->abort         endof endcase ;
: i2c->tx-data 0 case 
   i2c-txis?  ?of i2c-tx-data                -> >i2c->tx-data       endof
   i2c-tc?    ?of                            -> >i2c->tx-complete   endof
   i2c-nackf? ?of                            -> >i2c->abort         endof endcase ;
: i2c->rx-start i2c-adr-mode7 i2c-slave-adr7 i2c-wr i2c-no-autoend i2c-1byte i2c-start -> >i2c->rx-reg ;
: i2c->rx-reg 0 case
   i2c-txis?  ?of i2c-tx-reg                 -> >i2c->rx-read-start endof
   i2c-nackf? ?of                            -> >i2c->abort         endof endcase ;
: i2c->rx-read-start 0 case
   i2c-tc?    ?of i2c-bytes i2c-rd i2c-start -> >i2c->rx-data       endof
   i2c-nackf? ?of                            -> >i2c->abort         endof endcase ;
: i2c->rx-data 0 case
  i2c-rxne?   ?of i2c-rx-data                -> >i2c->rx-data       endof 
  i2c-tc?     ?of i2c-stop                   -> >i2c->rx-complete   endof endcase ;
  



