\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4

\ ********** debugging support ****************
0 variable DEBUG                               \ debug flag
: DEBUG? ( -- f) DEBUG @ ;                     \ turn on debugging output ?
: .debug" ( c-addr len -- )                    \ type text when debugging active
   DEBUG? if cr type ." sp " sp@ . ."  " else 2drop then cr ;

: .D" ( -- )                                   \ output debug text
   postpone s" postpone .debug" immediate ;
: .D DEBUG? if . else drop then ;
: debug-on -1 DEBUG ! ;
: dbg hex debug-on ;

\ ********** interrupt ids for i2c1 and i2c2 **
#47                 constant I2C1_EV           \ i2c event interrupd
#48                 constant I2C1_ER           \ i2c error interrupd
#49                 constant I2C2_EV           \ i2c event interrupd
#50                 constant I2C2_ER           \ i2c error interrupd
$40005400           constant I2C1_BASE
I2C1_BASE           constant I2C1
$E000E100           constant NVIC_ISER0
$E000E280           constant NVIC_ICPR0
NVIC_ICPR0 4 +      constant NVIC_ICPR1
NVIC_ICPR0 8 +      constant NVIC_ICPR2
$40021000           constant RCC_BASE
$14 RCC_BASE or     constant RCC_AHBENR
$1C RCC_BASE or     constant RCC_APB1ENR
$48000400           constant gpiob
gpiob               constant gpiob_moder
$04 gpiob or        constant gpiob_otyper
$10 gpiob or        constant gpiob_idr
$18 gpiob or        constant gpiob_bsrr
$20 gpiob or        constant gpiob_afrl


\ ********** i2c configuration ****************
I2C1                constant I2C_BASE
I2C1SW              constant I2CSW
I2C1_EV             constant I2C_EV
I2C1_ER             constant I2C_ER
I2C1                constant I2C
I2C1EN              constant I2CEN

1 6 lshift          constant i2c-scl
1 7 lshift          constant i2c-sda
$4                  constant I2C_CR2
$10                 constant I2Cx_TIMINGR      \ Timing register
 $F #28 lshift      constant PRESC             \ Timing prescaler
 $F #20 lshift      constant SCLDEL            \ Data setup time
 $F #16 lshift      constant SDADEL            \ Data hold time
$FF  #8 lshift      constant SCLH              \ SCL high period
$FF                 constant SCLL              \ SCL low period
I2C I2Cx_TIMINGR or constant I2C_TIMINGR
i2c                 constant i2c-cr1
i2c I2C_CR2 +       constant i2c-cr2
i2c $18     +       constant i2c-isr
i2c $28     +       constant i2c-txdr
i2c $24     +       constant i2c-rxdr

\ calculate nvic enable disable mask from ipsr number
\ ipsr "vector number" is interrupt position + 16 or vector_adress / 4 
: nvic-mask  ( n -- n )                        \ calculate mask for nvic 
   #16 - $1f and 1 swap lshift 1-foldable ;
: nvic-offset ( n -- n )                       \ nvic register offset depending on vector number
   #16 - #5 rshift #2 lshift 1-foldable ;
: nvic-enable-irq ( n -- )
   #16 - dup $1f and 1 swap lshift swap #5 rshift #2 lshift NVIC_ISER0 + bis! ;


: ftab: ( "name" -- )                          \ build function table head + handler
   <BUILDS  DOES> swap 2 lshift + @ execute ;

\ : i2c. .D" i2c_cr1 " i2c .D ;

: scl-h ( -- ) i2c-scl           gpiob_bsrr ! ;
: scl-l ( -- ) i2c-scl 16 lshift gpiob_bsrr ! ;
: sda-h ( -- ) i2c-sda           gpiob_bsrr ! ;
: sda-l ( -- ) i2c-sda 16 lshift gpiob_bsrr ! ;
: delay ( -- )  20 0 do loop inline ;
: scl-@ ( -- f ) delay i2c-scl gpiob_idr bit@ ;
: sda-@ ( -- f ) delay i2c-sda gpiob_idr bit@ ;
: i2c-clk-hsi-100khz  ( -- )                  \ i2c timing for HSI @ 100 kHz
   I2CSW RCC_CFGR3 bic!                       \ i2c on hsi clock
   1 PRESC  I2C_TIMINGR bits!                 \ timings from DM00043574.pdf: 26.4.9  I2Cx_TIMINGR register configuration examples
   $13 SCLL I2C_TIMINGR bits!
   $0F SCLH I2C_TIMINGR bits!
   $02 SDADEL I2C_TIMINGR bits!
   $04 SCLDEL I2C_TIMINGR bits! ;
  

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
  enum >i2c->accel-start
  enum >i2c->accel-xfer
  constant i2c->num-states

\ ********** variables ************************
>i2c->idle variable i2c-state
0          variable i2c-slave-adr
0          variable i2c-xfer-size
0          variable i2c-xfer-cnt
0          variable i2c-reg
0          variable i2c-on-tx-complete
0          variable i2c-on-rx-complete
4          BUFFER:  i2c-dbg-irq-nr
32         BUFFER:  i2c-xfer-buffer
0          variable irq-old-handler

: i2c-state! i2c-state ! inline ;
\ : ->' ( "state-id" )                         \ state-id i2c-state !
\    ' .s dup 0<>
\      if execute dup 0< not and dup i2c->num-states < and literal, postpone i2c-state!
\      else quit
\      then immediate ;
\ : test -> >i2c->tx-reg i2c-state @ . ;
\ test
: i2c-adr-mode7   ( -- )  #1 #11 lshift i2c-cr2 bic! ;
: i2c-slave-adr7  ( -- )  i2c-slave-adr @ $3FF  i2c-cr2 bits! ;
: i2c-rd          ( -- )  #1 #10 lshift i2c-cr2 bis! ;
: i2c-wr          ( -- )  #1 #10 lshift i2c-cr2 bic! ;
: i2c-stop        ( -- )  #1 #14 lshift i2c-cr2 bic! ;
: i2c-off         ( -- )  #1 i2c-cr1 bic! ;
: i2c-on          ( -- )  $7f i2c-cr1 bis! ;
: i2c-no-autoend  ( -- )  #1 #25 lshift i2c-cr2 bic! ;
: i2c-bytes       ( -- )  i2c-xfer-size @ $ff0000 i2c-cr2 bits! ;
: i2c-1byte       ( -- )  1 $ff0000 i2c-cr2 bits! ;
: i2c-start       ( -- )  #1 #13 lshift i2c-cr2 bis! ;
: i2c-tx-reg      ( -- )  i2c-reg @ .D"  i2c-reg " dup .d i2c-txdr c! ;
: i2c-tx-data     ( -- )  1 i2c-xfer-cnt dup @ i2c-xfer-buffer + c@ i2c-txdr c! +! ;
: i2c-rx-data     ( -- )  i2c-rxdr c@ i2c-xfer-cnt @ i2c-xfer-buffer + c! 1 i2c-xfer-cnt +! ;
: i2c-rxne?       ( -- f )  #1 #2 lshift i2c-isr bit@ ;
: i2c-txis?       ( -- f )  #1 #1 lshift i2c-isr bit@ ;
: i2c-nackf?      ( -- f )  #1 #4 lshift i2c-isr bit@ ;
: i2c-tc?         ( -- f )  #1 #6 lshift i2c-isr bit@ ;
: i2c-init  ( -- )                                       \ initialize i2c1
   1 #21 lshift RCC_APB1ENR bis!                         \ enable i2c1 modul
   1 #18 lshift RCC_AHBENR bis!                          \ enable portb
   gpiob_moder @ $f000 not and $A000 or gpiob_moder !    \ alternate function 
   i2c-scl i2c-sda or gpiob_otyper bis!                  \ open drain
   $FF000000 gpiob_afrl bic! $44000000 gpiob_afrl bis!   \ alternate function i2c mode
   i2c-clk-hsi-100khz                                    \ set i2c timing  
   i2c-on  ;                                             \ enable interrupts

: ->  ( n -- )  i2c-state ! inline ;                     \ set i2c-state
: accel-x     ( -- u ) i2c-xfer-buffer h@ ;
: accel-y     ( -- u ) i2c-xfer-buffer 2 + h@ ;
: accel-z     ( -- u ) i2c-xfer-buffer 4 + h@ ;
: accel-dump  ( -- )  cr ." x " accel-x . ." y " accel-y . ." z " accel-z . cr ;

\ ********** state machine ********************
: i2c->idle ;
: i2c->tx-start .D" i2c->tx-start " i2c-on i2c-adr-mode7 i2c-slave-adr7 i2c-wr i2c-no-autoend i2c-bytes i2c-start >i2c->tx-reg -> ;
: i2c->tx-reg .D" i2c->tx-reg " 0 case 
   i2c-txis?  ?of i2c-tx-reg                 >i2c->tx-data       -> .D" i2c-txis? "  endof
   i2c-nackf? ?of                            >i2c->abort         -> .D" i2c-nackf? " endof endcase ;
: i2c->tx-data .D" i2c->tx-data " 0 case 
   i2c-txis?  ?of i2c-tx-data                >i2c->tx-data       -> .D" i2c-txis? "   endof
   i2c-tc?    ?of i2c-stop                   >i2c->tx-complete   -> .D" i2c-tc? "     endof
   i2c-nackf? ?of                            >i2c->abort         -> .D" i2c-nackf? "  endof endcase ;
: i2c->tx-complete .D" i2c->tx-complete " i2c-off i2c-on-tx-complete @ dup if execute else drop then ;
: i2c->rx-start i2c-on i2c-adr-mode7 i2c-slave-adr7 i2c-wr i2c-no-autoend i2c-1byte i2c-start >i2c->rx-reg -> ;
: i2c->rx-reg .D" i2c->rx-reg " 0 case
   i2c-txis?  ?of i2c-tx-reg                 >i2c->rx-read-start -> .D" i2c-txis? " endof
   i2c-nackf? ?of                            >i2c->abort         -> endof endcase ;
: i2c->rx-read-start .D" i2c->rx-read-start " 0 case
   i2c-tc?    ?of i2c-bytes i2c-rd i2c-start >i2c->rx-data       -> .D" i2c-tc " endof
   i2c-nackf? ?of                            >i2c->abort         -> .D" nackf "  endof endcase ;
: i2c->rx-data 0 .D" i2c->rx-data " case
   i2c-rxne?  ?of i2c-rx-data                >i2c->rx-data       -> .D" i2c-rxne? " endof 
   i2c-tc?    ?of i2c-stop                   >i2c->rx-complete   -> .D" i2c-tc? "   endof endcase ;
: i2c->rx-complete i2c-stop i2c-off .D" i2c->rx-complete " i2c-isr .D 
   >i2c->abort -> i2c-on-rx-complete @ dup if execute else drop then ;
: i2c->abort i2c-off ;
: i2c->accel-xfer  ( -- )
   %00110011 i2c-slave-adr   ! 6   i2c-xfer-size !
   0         i2c-xfer-cnt    ! $28 i2c-reg       ! >i2c->rx-start i2c-state !
   ['] accel-dump i2c-on-rx-complete ! i2c->rx-start ;
: i2c->accel-start  ( -- ) 
   %00110011 i2c-slave-adr   !   1 i2c-xfer-size !
           0 i2c-xfer-cnt    ! $20 i2c-reg       !
         $67 i2c-xfer-buffer ! ['] i2c->accel-xfer i2c-on-tx-complete !
   i2c->tx-start ;
ftab: i2c-state-table
  ' i2c->idle , \ default state
  ' i2c->tx-start ,
  ' i2c->tx-reg ,
  ' i2c->tx-data ,
  ' i2c->tx-complete ,
  ' i2c->rx-start ,
  ' i2c->rx-reg ,
  ' i2c->rx-read-start ,
  ' i2c->rx-data ,
  ' i2c->rx-complete ,
  ' i2c->abort ,
  ' i2c->accel-start ,
  ' i2c->accel-xfer ,
: end ;                                        \ see catcher :-)
: i2c-handle ( -- ) i2c-state @ dup 0< not and dup i2c->num-states < and i2c-state-table ;
: i2c-isr-ack ( -- )                           \ acknowledge interrupt
   I2C_EV nvic-mask I2C_EV nvic-offset NVIC_ICPR0 + !
   I2C_ER nvic-mask I2C_ER nvic-offset NVIC_ICPR0 + ! ;
: i2c-irq-handle ( -- )                        \ default interrupt handler 
   ipsr case
     I2C_EV of i2c-handle endof
     I2C_ER of i2c-handle endof
     irq-old-handler @ execute                 \ invoke old handler
   endcase i2c-isr-ack ;     
: i2c-irq-init  ( -- ) 0 i2c-dbg-irq-nr ! irq-collection @  irq-old-handler ! ['] i2c-irq-handle irq-collection ! ;
: i2c-setup  ( -- )  i2c-irq-init i2c-init I2C_EV nvic-enable-irq I2C_ER nvic-enable-irq ;
: i2c-test  ( -- )  %00110011 i2c-slave-adr ! 6 i2c-xfer-size ! 0 i2c-xfer-cnt ! $28 i2c-reg ! >i2c->rx-start i2c-state !
   i2c-handle ;

: 2048 buffer: la-buffer
0 variable la-cnt
: la begin key? until ;

: accel-test  ( -- )  i2c-setup hex i2c->accel-start ;


