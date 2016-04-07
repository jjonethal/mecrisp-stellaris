\ This is free software under GNU General Public License v3.
\ STM32F303VCT6 F3Discovery Board demo
\ copyrights (c) 2015 by Jean Jonethal
\ Documents
\ ref man    "C:\Users\jeanjo\Downloads\stm\DM00043574 STM32F303xB_C STM32F303x6_8 STM32F328x8 and STM32F358xC advanced ARM-based 32-bit MCUs.pdf"
\ prog man   "C:\Users\jeanjo\Downloads\stm\DM00046982 STM32F3 and STM32F4 Series Cortex-M4 programming manual.pdf"
\ data sheet "C:\Users\jeanjo\Downloads\stm\DM00058181 STM32F303VC.pdf"
\ L3GD20     "C:\Users\jeanjo\Downloads\stm\DM00036465 L3GD20.pdf"
\ LSM303DLHC "C:\Users\jeanjo\Downloads\stm\DM00027543-LSM303DLHC.pdf"
\ i2c spec   "http://www.nxp.com/documents/user_manual/UM10204.pdf"
\ board man  "C:\Users\jeanjo\Downloads\stm\DM00063382 STM32F3DISCOVERY user manual.pdf"


\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 )
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5
\ INT1              - PE4
\ using interrupt


\ reset

\ ********** debugging support ***************
0 variable DEBUG                              \ debug flag
: DEBUG?  ( -- f)  DEBUG @ ;                  \ turn on debugging output ?
: .debug"  ( c-addr len -- )                  \ type text when debugging active
   DEBUG?
   if cr type ." sp " sp@ . ."  "
   else 2drop
   then ;

: .D" ( -- )                                  \ output debug text
   postpone s" postpone .debug" immediate ;
: .D DEBUG? if . else drop then ;
: debug-on -1 DEBUG ! ;
: dbg hex debug-on ;


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
#47            constant I2C1_EV               \ i2c event interrupd
#48            constant I2C1_ER               \ i2c error interrupd

$E000E100      constant NVIC_ISER0            \ Interrupt set-enable registers
$E000E180      constant NVIC_ICER0            \ Interrupt clear-enable registers
$E000E280      constant NVIC_ICPR0            \ Interrupt clear-pending registers
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

\ ********** long range defer ****************
: BX,  ( reg -- )                             \ compile branch exchange to [reg]
   $f and #3 lshift $4700 or h, ;
: defer  ( "name" )                           \ create place holder for jump (bx r0)
   (create) #10 allot smudge ;
: is  ( a -- ) ( "name" )                     \ create jump to address a at "name"
   '  here dup >R - allot                     \ backup here adjust here to place holder
   1 or                                       \ adjust jump target address to thumb mode !
   0 registerliteral,                         \ compile address to r0
   0 BX,                                      \ compile BX r0
   r> here - allot ;                          \ restore dictionary pointer

\ calculate nvic enable disable mask from ipsr number
\ ipsr "vector number" is
\ interrupt position + 16 or vector_address / 4
: nvic-mask  ( n -- n )                       \ calculate mask for nvic vector number
   #16 - $1f and 1 swap lshift 1-foldable ;
: nvic-offset  ( n -- n )                     \ nvic register offset depending on vector number
   #16 - #5 rshift #2 lshift 1-foldable ;
: nvic-enable-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ISER0 + ! ;
: nvic-disable-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ICER0 + ! ;
: nvic-clear-irq ( n -- )
   dup nvic-mask  swap nvic-offset NVIC_ICPR0 + ! ;

: gpiob-en  ( -- )                            \ enable clock for gpio port b
   1 #18 lshift RCC_AHBENR bis! ;
: i2c1-en  ( -- )                             \ enable clock for i2c1
   1 #21 lshift RCC_APB1ENR bis! ;
: pin-gpio-mode  ( -- )                       \ general-purpose output mode pb6 pb7
   $f000 gpiob bic!  $5000 gpiob bis! ;
: pin-af-mode  ( -- )                         \ select AF4 mode i2c pb6 and pb7
   $f000 gpiob bic!  $A000 gpiob bis!
   GPIOB_AFRL @ $FFFFFF and $44000000 or
   GPIOB_AFRL ! ;
: pin-opendrain  ( -- )                       \ select opendrain mode for pb6 and pb7
   $3 $6 lshift GPIOB_OTYPER ! ;
: sda1  ( -- )                                \ pb7=1
   1 7 lshift GPIOB_BSRR ! ;
: sda0  ( -- )                                \ pb7=0
   1 7 16 + lshift GPIOB_BSRR ! ;
: scl1  ( -- )                                \ pb6=1
   1 6 lshift GPIOB_BSRR ! ;
: scl0  ( -- )                                \ pb6=0
   1 6 16 + lshift GPIOB_BSRR ! ;
: scl@  ( -- f )                              \ pb6@
   1 6 lshift GPIOB_IDR bit@ ;
: sda@  ( -- f )                              \ pb7@
   1 7 lshift GPIOB_IDR bit@ ;
: scl.  ( -- )                                \ print scl state
   scl@ . ;
: sda.  ( -- )                                \ print sda state
   sda@ . ;
: i2c-timing  ( -- )                          \ 100 khz @ 8M : PRESC = 1 SCLL=0x13 SCLH=0xF SDADEL=0x2 SCLDEL=0x4
    #1 #28 lshift                             \ PRESC=1
    #4 #20 lshift or                          \ SCLDEL=0x4
    #2 #16 lshift or                          \ SDADEL=0x02
    $f  #8 lshift or                          \ SCLH=0xF
   $13            or                          \ SCLL=0x13
   I2C1_TIMINGR ! ;
: i2c-int-ena  ( -- )
   $66 i2c1 bis! I2C1_EV nvic-enable-irq ;
: i2c-int-dis  ( -- )
   $66 i2c1 bic! I2C1_EV nvic-disable-irq  ;
: i2c-nvic-dis  ( -- )
   I2C1_EV nvic-disable-irq  ;
: i2c-on  ( -- )  1 i2c1 bis! ;               \ PE 1
: i2c-off  ( -- )  1 i2c1 bic! ;              \ PE 0
: i2c-start  ( a n r/w -- )                   \ start i2c transfer : i2c address, number of bytes, read(1)/write(0)
   0<> 1 and #10 lshift                       \ r/w
   swap #16 lshift or                         \ number of bytes
   or                                         \ i2c address
   I2C1_CR2 !
   1 #13 lshift I2C1_CR2 bis! ;
: i2c-start-read  ( a n -- )  1 i2c-start ;   \ start i2c read transfer a:address n:count
: i2c-start-write  ( a n -- )  0 i2c-start ;  \ start i2c write transfer a:address n:count
: i2c-tx  ( n -- )  I2C1_TXDR c! ;            \ transmit a byte
: i2c-rx  ( -- n )  I2C1_RXDR c@ ;            \ receive a byte
: i2c-stat  ( -- n )  i2c1_isr @ ;            \ get i2c status
: i2c-stop  ( -- )  $1 #14 lshift i2c1_cr2 bis! ;
: i2c-init  ( -- )                            \ init ports mode i2c timing
   gpiob-en i2c1-en pin-opendrain pin-af-mode i2c-timing i2c-on ;


\ ********** i2c polling functions ***********
: i2c-wait  ( m -- )                          \ wait for masked i2c status flags
   begin dup i2c-stat and until i2c1_icr bis! ;
: i2c-set-reg-adr  ( reg a  -- )
   $FE and 1 0 i2c-start TXIS i2c-wait i2c-tx ;
: i2c-write-reg  ( v reg a  -- )              \ write a value to register at i2c-adress
   2 0 i2c-start TXIS i2c-wait i2c-tx TXIS
   i2c-wait i2c-tx TC i2c-wait ;
: i2c-read-reg  ( reg a  -- )                 \ read a value from register at i2c-adress
   tuck i2c-set-reg-adr 1 or 1 1 i2c-start
   RXNE i2c-wait i2c-rx i2c-stop ;
: i2c-read-2-reg  ( reg adr -- )              \ read 2 register values
   tuck i2c-set-reg-adr 1 or 2 1 i2c-start
   RXNE i2c-wait i2c-rx
   RXNE i2c-wait i2c-rx i2c-stop ;
: i2c-wait-rx  ( -- n )
   RXNE i2c-wait i2c-rx ;
: i2c-read-6-reg  ( reg adr -- )              \ read 6 register values
   tuck i2c-set-reg-adr 1 or 6 1 i2c-start
   i2c-wait-rx i2c-wait-rx i2c-wait-rx
   i2c-wait-rx i2c-wait-rx i2c-wait-rx
   i2c-stop ;

\ ********** accelerator functions ***********
: h>s  ( h -- s )
   #16 lshift #16 arshift 1-foldable ;
: 2c>h  ( cl ch -- h )  8 lshift or ;         \ combine 2 bytes to a word
: 2c>sh  ( cl ch -- h )  2c>h h>s ;           \ assemble signed word from 2 bytes
: accel-init  ( -- )                          \ initialize accel sensor
   i2c-init $67 $20 $32 i2c-write-reg         \ CTRL_REG1_A 200 Hz, Normal mode XYZ enable
                $20 $32 i2c-read-reg $67 =    \ read back init value
   if   ." accel initialized. "
   else ." accel failed. " then ;
: accel-xl  ( -- xl )  $28 $33 i2c-read-reg ; \ read xl
: accel-xh  ( -- xh )  $29 $33 i2c-read-reg ; \ read xh
\ multi register read LSM303DLHC : reg-adr $80 OR
: accel-x  ( -- x )
   $28 $80 or $33 i2c-read-2-reg 2c>sh ;
: accel-y  ( -- y )
   $2A $80 or $33 i2c-read-2-reg 2c>sh ;
: accel-z  ( -- z )
   $2C $80 or $33 i2c-read-2-reg 2c>sh ;
: accel-xyz ( -- x y z )                      \ read acceleration axes
   $28 $80 or $33 i2c-read-6-reg
   2c>sh >R 2c>sh >R 2c>sh R> R> ;
: accel.  ( n -- )  $33 i2c-read-reg . ;      \ read a register from acceleration sensor
: accel-highres  ( -- )                       \ enable 12 bit ADC resolution for accel sensor
   $08 $23 $32 i2c-write-reg ;
: accal-xyz. ( -- ) accel-xyz rot . swap . . ;

\ ********** magnetometer sensor *************
: mag-init ( -- )
   i2c-init $9C $00 $3C i2c-write-reg         \ CTRL_REG1_A 200 Hz, Normal mode XYZ enable
                $00 $3C i2c-read-reg $9C =    \ read back init value
   if   ." mag initialized. "
   else ." mag failed. " then ;
: mag-set ( v r -- f )
   2dup $3C i2c-write-reg
   $3C i2c-read-reg = ;
: mag-get ( r -- v )
   $3C i2c-read-reg ;
: mag-x ( -- )
   $03 $3C i2c-read-2-reg 2c>sh ;
: mag-y ( -- )
   $05 $3C i2c-read-2-reg 2c>sh ;
: mag-z ( -- )
   $07 $3C i2c-read-2-reg 2c>sh ;
: mag-xyz ( -- x y z )                      \ read acceleration axes
   $03 $3D i2c-read-6-reg
   2c>sh >R 2c>sh >R 2c>sh R> R> ;
: mag-xyz. ( -- ) mag-xyz rot . swap . . ;

\ ********** acceleration sensor variables ***
0   variable mx                               \ average x acceleration
0   variable my                               \ average y acceleration
0   variable mz                               \ average z acceleration
0   variable ax                               \ accel x
0   variable ay                               \ accel y
0   variable az                               \ accel z
0   variable aabs                             \ acceleration absolute value
0   variable mabs                             \ average acceleration absolute value
0   variable upd-count                        \ display update counter
0 0 2variable count                           \ current run

\ ********** square root calculation *********
: sqrt-step ( a xn -- a xn+1 )                \ perform one sqrt step x(n+1) = ( a/x(n) + x(n))/2
   2dup / + 2/ 2-foldable inline ;
: sqrt ( n -- sqrt )                          \ calc square root of signed positive number  0 <= n <= 2^31-1
   dup dup
   clz 32 - negate                            \ bitlog
   2/ rshift                                  \ first estimation
   sqrt-step sqrt-step sqrt-step              \ sqrt-step \ sqrt-step
   swap drop ;

: filter ( x a -- )                           \ averaging filter
   dup >R @ dup 500 + 1000 / - + R> ! ;
: filter2 ( x a -- ) tuck @ dup 500 + 1000 / - + swap ! ;
: filter2 tuck @ dup 500 + 1000 / - + swap ! ;

: test ." : filter2 tuck @ dup 500 + 1000 / - + swap ! ; " evaluate ;
: filter-xyz ( -- )
   ax @ mx filter ay @ my filter az @ mz filter ;
: abs-xyz ( -- )
   ax @ dup * ay @ dup * az @ dup * + +
   sqrt aabs ! ;
: filter-abs  ( -- )
   mabs @ dup 500 + 1000 / - aabs @ + mabs ! ;
: accel-dump-data ( -- )  #13 emit count 2@ d. mx @ . my @ . mz @ . aabs @ . mabs @ . ."       " ;
: accel-demo  ( -- )                          \ demo with i2c polling
   accel-init accel-highres
   accel-xyz az ! ay ! ax !
   az @ 1000 * mz ! ay @ 1000 * my ! ax @ 1000 * mx !
   begin accel-xyz    az ! ay ! ax !
     filter-xyz
     abs-xyz
     filter-abs
     count 2@ 1 s>d d+ count 2!
     upd-count @ 1- dup upd-count ! 0<
     if 999 upd-count ! accel-dump-data
     then key?
   until ;

\ ********** i2c interrupt driver ************
: ftab: ( -- )  ( name )                      \ create a function table
   <builds does> swap 2 lshift + @ execute ;
: enum ( n -- n + 1 ) ( "name" )              \ enumeration constant
   dup constant 1+ ;

\ ********** i2c driver variables ************
#16 constant i2c-def-buffer-size
i2c-def-buffer-size buffer:  i2c-def-buffer
0                   variable i2c-device-adr   \ address of i2c device
0                   variable i2c-device-reg   \ register of i2c device
i2c-def-buffer-size variable i2c-buffer$      \ size of i2c-buffer
i2c-def-buffer      variable i2c-buffer       \ pointer to transferbuffer
0                   variable i2c-buffer#      \ count received/transmitted bytes
0                   variable i2c-state        \ number of next state

: ->  ( -- )  i2c-state ! ;                   \ put state number to i2c-state
: i2c-buffer>  ( -- c )                       \ return next byte to transmit
   i2c-buffer# @ dup dup i2c-buffer$ @ <
   if i2c-buffer @ + c@                       \ get next character from buffer
    swap 1+ i2c-buffer# !                     \ update buffer index
   else 2drop -1 then ;
: >i2c-buffer ( c -- )                        \ store character to xfer buffer
   i2c-buffer# @ i2c-buffer$ @ <              \ get xfer-count
   if i2c-buffer# @ i2c-buffer @ + c!
   i2c-buffer# @ 1+ i2c-buffer# !             \ store c to buffer
   else drop then ;                           \ check and store i2c-xfer-count
: i2c-buffer-end? ( -- f )
   i2c-buffer$ @ i2c-buffer# @ = ;
: >test 20 0 do i >i2c-buffer loop ;
: test> 0 i2c-buffer# ! 20 0 do cr i . i2c-buffer> . i2c-buffer# @ . loop ;

\ ********** i2c state ids *******************
0 enum i2c-s-idle#
  enum i2c-s-tx-adr#
  enum i2c-s-tx-reg#
  enum i2c-s-tx-val#
  enum i2c-s-tx-stop#
  enum i2c-s-tx-finish#
  enum i2c-s-rx-sel-adr#
  enum i2c-s-rx-sel-reg#
  enum i2c-s-rx-adr#
  enum i2c-s-rx-data#
  enum i2c-s-rx-stop#
  enum i2c-s-rx-finish#
  constant i2c-states#

\ ********** i2c state words *****************
: i2c-s-idle  ( -- )                          \ default / idle state turn off i2c disable interrupts 
   i2c-off i2c-int-dis ;
: i2c-s-tx-adr  ( -- )                        \ transmit mode send device address
   i2c-on i2c-int-ena i2c-s-tx-reg# ->
   0 i2c-buffer# !
   i2c-device-adr @ i2c-buffer$ @ 1+
   i2c-start-write ;
: i2c-s-tx-reg  ( -- )                        \ transmit mode send register address
   i2c-device-reg @ i2c-tx i2c-s-tx-val# -> ;
: i2c-s-tx-val  ( -- )                        \ transmit mode send value
   i2c-stat case
     dup TC   and ?of i2c-stop  i2c-s-tx-finish# -> endof
     dup TXIS and ?of i2c-buffer> i2c-tx            endof 
   endcase ;
: i2c-s-tx-stop  ( -- )
   i2c-stop i2c-s-tx-finish# -> ;
: i2c-s-tx-finish  ( -- )
   $20 i2c1_icr ! . i2c-nvic-dis
   i2c-s-idle# -> ;
: i2c-s-rx-sel-adr ( -- )
   i2c-on i2c-int-ena i2c-s-rx-sel-regs# ->
   i2c-device-adr @ $FFE and \ write address 
   1 i2c-start-write ;
: i2c-s-rx-sel-reg  ( -- )  ;
   i2c-s-rx-adr# -> i2c-device-reg @ i2c-tx ;
: i2c-s-rx-adr ( -- )
   i2c-s-rx-data# ->
   0 i2c-buffer# !
   i2c-device-adr @ 1 or i2c-buffer$ @ i2c-start-read ;
: i2c-s-rx-data  ( -- )
   i2c-stat case
     dup RXNE and ?of i2c-rx    >i2c-buffer         endof
     dup TC   and ?of i2c-stop  i2c-s-rx-finish# -> endof
   end-case ;
: i2c-s-rx-stop  ( -- ) ;
: i2c-s-rx-finish  ( -- )
   i2c-off i2c-int-dis ;

\ ********** i2c function table **************
\ order in function table must be same as i2c state ids
\ i2c state id maps to entry in function table
ftab: i2c-sm
  ['] i2c-s-idle
  ['] i2c-s-tx-adr
  ['] i2c-s-tx-reg
  ['] i2c-s-tx-val
  ['] i2c-s-tx-stop
  ['] i2c-s-tx-finish
  ['] i2c-s-rx-sel-adr
  ['] i2c-s-rx-sel-reg
  ['] i2c-s-rx-adr
  ['] i2c-s-rx-data
  ['] i2c-s-rx-stop
  ['] i2c-s-rx-finish

: i2c-handler  ( -- )  i2c-state @ dup i2c-states# < and i2c-sm ;
: inthandler ( -- )
    cr ." ipsr " ipsr . ." i2c-stat " i2c-stat . i2c-handler I2C1_EV nvic-clear-irq ( i2c-nvic-dis ) ;
: install-handler ( -- ) ['] inthandler irq-collection ! ;
: it hex install-handler i2c-init i2c-int-ena i2c-s-tx-reg# ->  i2c-on $32 2 i2c-start-write ;
