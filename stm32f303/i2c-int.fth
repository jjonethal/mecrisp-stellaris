\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4
\ using polling

$48000400      constant gpiob
$4 gpiob     + constant GPIOB_OTYPER
$10 gpiob    + constant GPIOB_IDR
$18 gpiob    + constant GPIOB_BSRR
$20 gpiob    + constant GPIOB_AFRL
$40021000      constant rcc
$14 rcc      + constant RCC_AHBENR
$1c rcc      + constant RCC_APB1ENR
$40005400      constant i2c1
$4 i2c1      + constant I2C1_CR2
$10 i2c1     + constant I2C1_TIMINGR
$18 i2c1     + constant I2C1_ISR
$1c i2c1     + constant i2c1_icr
$24 i2c1     + constant I2C1_RXDR
$28 i2c1     + constant I2C1_TXDR
#47            constant I2C1_EV    \ i2c event interrupd
#48            constant I2C1_ER    \ i2c error interrupd

$E000E100      constant NVIC_ISER0 \ Interrupt set-enable registers
$E000E180      constant NVIC_ICER0 \ Interrupt clear-enable registers
$E000E280      constant NVIC_ICPR0 \ Interrupt clear-pending registers
NVIC_ICPR0 4 + constant NVIC_ICPR1
NVIC_ICPR0 8 + constant NVIC_ICPR2

\ i2c status
1 #15 lshift constant BUSY
1 #13 lshift constant ALERT
1 #12 lshift constant TIMEOUT
1 #11 lshift constant PECERR
1 #10 lshift constant OVR
1  #9 lshift constant ARLO
1  #8 lshift constant BERR
1  #7 lshift constant TCR
1  #6 lshift constant TC
1  #5 lshift constant STOPF
1  #4 lshift constant NACKF
1  #3 lshift constant ADDR
1  #2 lshift constant RXNE
1  #1 lshift constant TXIS 
1            constant TXE

\ **** long range defer ***********************
: BX,  ( reg -- )                              \ compile branch exchange to [reg]
   $f and #3 lshift $4700 or h, ;
: defer  ( "name" )                            \ create place holder for jump (bx r0)
   (create) #10 allot smudge ;
: is  ( a -- ) ( "name" )                      \ create jump to address a at "name"
   '  here dup >R - allot                      \ adjust here to place holder
   1 or                                        \ adjust jump target address to thumb mode !
   0 registerliteral,                          \ compile address to r0
   0 BX,                                       \ compile BX r0
   r> here - allot ;                           \ restore dictionary pointer




\ calculate nvic enable disable mask from ipsr number
\ ipsr "vector number" is interrupt position + 16 or vector_adress / 4 
: nvic-mask  ( n -- n )                        \ calculate mask for nvic vector number
   #16 - $1f and 1 swap lshift 1-foldable ;
: nvic-offset ( n -- n )                       \ nvic register offset depending on vector number
   #16 - #5 rshift #2 lshift 1-foldable ;
: nvic-enable-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ISER0 + ! ;
: nvic-disable-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ICER0 + ! ;
: nvic-clear-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ICPR0 + ! ;

: gpiob-en ( -- ) 1 #18 lshift RCC_AHBENR bis! ;  \ enable clock for gpio port b
: i2c1-en ( -- ) 1 #21 lshift RCC_APB1ENR bis! ;  \ enable clock for i2c1
: pin-gpio-mode ( -- ) $f000 gpiob bic!  $5000 gpiob bis! ; \ general-purpose output mode
: pin-af-mode ( -- ) $f000 gpiob bic!  $A000 gpiob bis!  \ select af mode i2c pb6 and pb7
    GPIOB_AFRL @ $FFFFFF and $44000000 or GPIOB_AFRL ! ;
: pin-opendrain ( -- ) $3 $6 lshift GPIOB_OTYPER ! ; \ select opendrain mode for pb6 and pb7
: sda1  ( -- )  1 7 lshift GPIOB_BSRR ! ;           \ pb7=1
: sda0  ( -- )  1 7 16 + lshift GPIOB_BSRR ! ;      \ pb7=0
: scl1  ( -- )  1 6 lshift GPIOB_BSRR ! ;           \ pb6=1
: scl0  ( -- )  1 6 16 + lshift GPIOB_BSRR ! ;      \ pb6=0
: scl@  ( -- f )  1 6 lshift GPIOB_IDR bit@ ;       \ pb6@
: sda@  ( -- f )  1 7 lshift GPIOB_IDR bit@ ;       \ pb7@
: scl.  ( -- )  scl@ . ; \ print scl state
: sda.  ( -- )  sda@ . ; \ print sda state
: i2c-timing  ( -- ) \ 100 khz @ 8M : PRESC = 1 SCLL=0x13 SCLH=0xF SDADEL=0x2 SCLDEL=0x4
    #1 #28 lshift    \ PRESC=1
    #4 #20 lshift or \ SCLDEL=0x4
    #2 #16 lshift or \ SDADEL=0x02
    $f  #8 lshift or \ SCLH=0xF
   $13            or \ SCLL=0x13
   I2C1_TIMINGR ! ;
: i2c-int-ena  ( -- )  $66 i2c1 bis! I2C1_EV nvic-enable-irq ;
: i2c-int-dis  ( -- )  $66 i2c1 bic! I2C1_EV nvic-disable-irq  ;
: i2c-nvic-dis  ( -- )  I2C1_EV nvic-disable-irq  ;
: i2c-on  ( -- )  1 i2c1 bis! ;  \ PE 1 
: i2c-off  ( -- )  1 i2c1 bic! ; \ PE 0 
: i2c-start  ( a n r/w -- )  \ start i2c transfer : i2c address, number of bytes, read(1)/write(0)
   0<> 1 and #10 lshift \ r/w
   swap #16 lshift or   \ number of bytes 
   or                   \ i2c address
   I2C1_CR2 !
   1 #13 lshift I2C1_CR2 bis! ;
: i2c-tx  ( n -- )  I2C1_TXDR c! ; \ transmit a byte
: i2c-rx  ( -- n )  I2C1_RXDR c@ ; \ receive a byte
: i2c-stat  ( -- n )  i2c1_isr @ ; \ get i2c status
: i2c-stop  ( -- )  $1 #14 lshift i2c1_cr2 bis! ;
: i2c-init  ( -- )  gpiob-en i2c1-en pin-opendrain pin-af-mode i2c-timing i2c-on ;


\ polling functions
: i2c-wait  ( n -- )  begin dup i2c-stat and until i2c1_icr bis! ; \ wait for i2c status
: i2c-set-reg-adr ( reg a  -- ) $FE and 1 0 i2c-start TXIS i2c-wait i2c-tx ;
: i2c-write-reg ( v reg a  -- ) \ value register i2c-adress
   2 0 i2c-start TXIS i2c-wait i2c-tx TXIS i2c-wait i2c-tx TC i2c-wait ;
: i2c-read-reg ( reg a  -- ) \ value register i2c-adress
   tuck i2c-set-reg-adr 1 or 1 1 i2c-start RXNE i2c-wait i2c-rx i2c-stop ;
: i2c-read-2-reg ( reg adr -- ) \ read 2 register values
   tuck i2c-set-reg-adr 1 or 2 1 i2c-start RXNE i2c-wait i2c-rx RXNE i2c-wait i2c-rx i2c-stop ;
: i2c-wait-rx ( -- n ) RXNE i2c-wait i2c-rx ;
: i2c-read-6-reg ( reg adr -- ) \ read 6 register values
   tuck i2c-set-reg-adr 1 or 6 1 i2c-start
   i2c-wait-rx  i2c-wait-rx i2c-wait-rx  i2c-wait-rx i2c-wait-rx  i2c-wait-rx
   i2c-stop ;
: accel-init ( -- ) i2c-init $67 $20 $32 i2c-write-reg $20 $32 i2c-read-reg $67 = 
   if ." accel initialized. " else ." accel failed. " then ;
: accel-xl ( -- xl ) $28 $33 i2c-read-reg ;
: accel-xh ( -- xh ) $29 $33 i2c-read-reg ;
\ multi register read LSM303DLHC : reg-adr $80 OR 
: accel-x ( -- x ) $28 $80 or $33 i2c-read-2-reg 8 lshift or ;
: accel-y ( -- y ) $2A $80 or $33 i2c-read-2-reg 8 lshift or ;
: accel-z ( -- z ) $2C $80 or $33 i2c-read-2-reg 8 lshift or ;
: h>s  ( h -- s ) #16 lshift #16 arshift ;
: accel-xyz ( -- x y z ) $28 $80 or $33 i2c-read-6-reg
   8 lshift or h>s >R 8 lshift or h>s >R 8 lshift or h>s R> R> ;
: accel. ( n -- ) $33 i2c-read-reg . ;
: accel-hr ( -- ) $08 $23 $32 i2c-write-reg ;
: axyz. ( -- ) accel-xyz rot . swap . . ;
0 variable mx
0 variable my
0 variable mz
0 variable ax
0 variable ay
0 variable az
0 variable aabs
0 variable mabs

: filter ( x a -- )  \ averaging filter
   dup >R @ dup 500 + 1000 / - + R> ! ;
: filter-xyz ( -- )
   ax @ mx filter ay @ my filter az @ mz filter ;
: abs-xyz ( -- )
   ax @ dup * ay @ dup * az @ dup * + + 
   aabs ! ;
: accel-demo ( -- ) accel-init accel-hr
   az ! ay ! ax !
   az @ 1000 * mz ! ay @ 1000 * my ! ax @ 1000 * mx !
   begin accel-xyz    az ! ay ! ax !
     filter-xyz
     mx @ . my @ . mz @ .
     #13 emit key?
   until ;
: sqrt-step ( a xn -- a xn+1 )
   2dup / + 2/ 2-foldable inline ;
: sqrt ( n -- sqrt ) \ ( xn+1 = ( a/xn + xn ) / 2 )
   dup dup clz 32 - negate 2/ rshift
   ." initial val " dup .
   sqrt-step sqrt-step sqrt-step sqrt-step sqrt-step
   swap drop ;
   
0 variable i2c-state
: i2c-s-tx-finish ." i2c-s-tx-finish " $20 i2c1_icr ! ." i2c-stat " i2c-stat . ( i2c-nvic-dis ) ;
: i2c-s-tx-stop ." i2c-s-tx-stop " i2c-stop ." i2c-stat " i2c-stat . ['] i2c-s-tx-finish i2c-state !  ;
: i2c-s-tx-val $67 i2c-tx ." i2c-tx-val " ." i2c-stat " i2c-stat . ['] i2c-s-tx-stop i2c-state ! ;
: i2c-s-tx-reg $20 i2c-tx ." i2c-tx-reg " ." i2c-stat " i2c-stat . ['] i2c-s-tx-val i2c-state ! ;
: inthandler ( -- )
    cr ." ipsr " ipsr . ." i2c-stat " i2c-stat . i2c-state @ execute I2C1_EV nvic-clear-irq ( i2c-nvic-dis ) ;
: install-handler ( -- ) ['] inthandler irq-collection ! ;
: it hex install-handler i2c-init i2c-int-ena ['] i2c-s-tx-reg i2c-state ! i2c-on $32 2 0 i2c-start ;
