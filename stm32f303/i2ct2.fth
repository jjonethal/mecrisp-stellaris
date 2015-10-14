\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4


\ interrupt ids for i2c1 and i2c2
#47       constant I2C1_EV                    \ i2c event interrupd
#48       constant I2C1_ER                    \ i2c error interrupd
#49       constant I2C2_EV                    \ i2c event interrupd
#50       constant I2C2_ER                    \ i2c error interrupd
$40005400 constant I2C1_BASE
$40005400 constant I2C1
$E000E100 constant NVIC_ISER0
\ following definitions my be used for defining driver usage for port 1 or 2
\ when both ports shall be supported the driver might be double included for both ports
\ support interrupt handling has to be adapted for dual port support

: nvic-enable-irq ( n -- )
   dup $1f and 1 swap lshift swap 5 rshift 2 lshift NVIC_ISER0 + bis! ;


\ i2c configuration
I2C1      constant I2C_BASE
I2C1SW    constant I2CSW
I2C1_EV   constant I2C_EV
I2C1_ER   constant I2C_ER
I2C1      constant I2C
I2C1EN    constant I2CEN

$40021000           constant RCC_BASE
$14 RCC_BASE or     constant RCC_AHBENR
$1C RCC_BASE or     constant RCC_APB1ENR
$48000400           constant gpiob
gpiob               constant gpiob_moder
$04 gpiob or        constant gpiob_otyper
$10 gpiob or        constant gpiob_idr
$18 gpiob or        constant gpiob_bsrr
$20 gpiob or        constant gpiob_afrl
1 6 lshift          constant i2c-scl
1 7 lshift          constant i2c-sda
$4                  constant I2C_CR2
$10                 constant I2Cx_TIMINGR         \ Timing register
 $F #28 lshift      constant PRESC     \ Timing prescaler
 $F #20 lshift      constant SCLDEL    \ Data setup time
 $F #16 lshift      constant SDADEL    \ Data hold time
$FF  #8 lshift      constant SCLH      \ SCL high period
$FF                 constant SCLL      \ SCL low period
I2C I2Cx_TIMINGR or constant I2C_TIMINGR

: ftab: ( "name" -- )                         \ build function table
   <BUILDS  DOES> swap 2 lshift + @ execute ;


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
: i2c-init ( -- )                                       \ initialize i2c1
  1 #21 lshift RCC_APB1ENR bis!                         \ enable i2c1 modul
  1 #18 lshift RCC_AHBENR bis!                          \ enable portb
  gpiob_moder @ $f000 not and $A000 or gpiob_moder !    \ alternate function 
  i2c-scl i2c-sda or gpiob_otyper bis!                  \ open drain
  $FF000000 gpiob_afrl bic! $44000000 gpiob_afrl bis!   \ i2c mode
  i2c-clk-hsi-100khz                                    \ set i2c timing  
  $7f i2c bis! ;                                        \ enable interrupts
  

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
  
>i2c->idle variable i2c-state
0          variable i2c-slave-adr
0          variable i2c-xfer-size
0          variable i2c-xfer-cnt
0          variable i2c-reg
0          variable i2c-dbg-irq-nr
32         BUFFER:  i2c-xfer-buffer

: i2c-state! i2c-state ! inline ;
\ : ->' ( "state-id" )  \ state-id i2c-state !
\    ' .s dup 0<>
\      if execute dup 0< not and dup i2c->num-states < and literal, postpone i2c-state!
\      else quit
\      then immediate ;
\ : test -> >i2c->tx-reg i2c-state @ . ;
\ test
i2c I2C_CR2 + constant i2c-cr2
i2c $18     + constant i2c-isr
i2c $28     + constant i2c-txdr
i2c $24     + constant i2c-rxdr

: i2c-adr-mode7 ( -- )  #1 #11 lshift i2c-cr2 bic! ;
: i2c-slave-adr7 ( -- )  i2c-slave-adr @ $3FF  i2c-cr2 bits! ;
: i2c-rd  ( -- )  #1 #10 lshift i2c-cr2 bis! ;
: i2c-wr  ( -- )  #1 #10 lshift i2c-cr2 bic! ;
: i2c-stop  ( -- )  #1 #14 lshift i2c-cr2 bic! ;
: i2c-no-autoend  ( -- ) #1 #25 lshift i2c-cr2 bic! ;
: i2c-bytes ( -- ) i2c-xfer-size @ $ff0000 i2c-cr2 bits! ;
: i2c-1byte  ( -- )  1 $ff0000 i2c-cr2 bits! ;
: i2c-start  ( -- )  #1 #13 lshift i2c-cr2 bis! ;
: i2c-tx-reg  ( -- ) i2c-reg @ i2c-txdr c! ;
: i2c-tx-data ( -- )  1 i2c-xfer-cnt dup @ i2c-xfer-buffer + c@ i2c-txdr c! +! ;
: i2c-rx-data ( -- )  i2c-rxdr c@ i2c-xfer-cnt @ i2c-xfer-buffer + c! 1 i2c-xfer-cnt +! ;
: i2c-rxne?  ( -- f )  #1 #2 lshift i2c-isr bit@ ;
: i2c-txis?  ( -- f )  #1 #1 lshift i2c-isr bit@ ;
: i2c-nackf?  ( -- f )  #1 #4 lshift i2c-isr bit@ ;
: i2c-tc?  ( -- f )  #1 #6 lshift i2c-isr bit@ ;
: -> i2c-state ! inline ;
: i2c->idle ;
: i2c->tx-start i2c-adr-mode7 i2c-slave-adr7 i2c-wr i2c-no-autoend i2c-bytes i2c-start >i2c->tx-reg -> ;
: i2c->tx-reg 0 case 
   i2c-txis?  ?of i2c-tx-reg                 >i2c->tx-data       -> endof
   i2c-nackf? ?of                            >i2c->abort         -> endof endcase ;
: i2c->tx-data 0 case 
   i2c-txis?  ?of i2c-tx-data                >i2c->tx-data       -> endof
   i2c-tc?    ?of i2c-stop                   >i2c->tx-complete   -> endof
   i2c-nackf? ?of                            >i2c->abort         -> endof endcase ;
: i2c->tx-complete ;
: i2c->rx-start i2c-adr-mode7 i2c-slave-adr7 i2c-wr i2c-no-autoend i2c-1byte i2c-start >i2c->rx-reg -> ;
: i2c->rx-reg 0 case
   i2c-txis?  ?of i2c-tx-reg                 >i2c->rx-read-start -> endof
   i2c-nackf? ?of                            >i2c->abort         -> endof endcase ;
: i2c->rx-read-start 0 case
   i2c-tc?    ?of i2c-bytes i2c-rd i2c-start >i2c->rx-data       -> endof
   i2c-nackf? ?of                            >i2c->abort         -> endof endcase ;
: i2c->rx-data 0 case
   i2c-rxne?  ?of i2c-rx-data                >i2c->rx-data       -> endof 
   i2c-tc?    ?of i2c-stop                   >i2c->rx-complete   -> endof endcase ;
: i2c->rx-complete ;
: i2c->abort ;

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
: end ;
: i2c-handle ( -- ) i2c-state @ dup 0< not and dup i2c->num-states < and i2c-state-table ;
0 variable irq-old-handler
: i2c-irq-handle ( -- ) 
   ipsr dup i2c-dbg-irq-nr ! case
     I2C_EV of i2c-handle endof
     I2C_ER of i2c-handle endof
     irq-old-handler @ execute
   endcase ;     
: i2c-irq-init  ( -- )  irq-collection @  irq-old-handler ! ['] i2c-irq-handle irq-collection ! ;
: i2c-setup  ( -- )  i2c-irq-init i2c-init I2C_EV nvic-enable-irq I2C_ER nvic-enable-irq ;
: i2c-test  ( -- )  %00110011 i2c-slave-adr ! 6 i2c-xfer-size ! 0 i2c-xfer-cnt ! $28 i2c-reg ! >i2c->rx-start i2c-state !
   i2c-handle ;



