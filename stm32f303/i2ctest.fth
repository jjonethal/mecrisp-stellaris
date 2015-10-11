\ i2c test

\ configuration

\ LSM303DLHC 3D accelerometer and 3D magnetometer
\ SCL               - PB6 ( I2C1 AF4 ) 
\ SDA               - PB7 ( I2C1 AF4 )
\ INT2              - PE5 
\ INT1              - PE4
\ LA0               - PC10 \ logic analyzer pin 0
\ LA1               - PC11 \ logic analyzer pin 1              
$40021000       constant RCC_BASE
$14 RCC_BASE or constant RCC_AHBENR


: gpio-port-adr  ( n -- adr )  \ base address of gpio port nr a:0 b:1 c:2 d:3 e:4 f:5
   #10 lshift $48000000 or 1-foldable inline ;
: gpio-rcc-ena-msk  ( adr -- n )  \ port_a .. port_f
   gpio-port-nr #17 + 1 swap lshift 1-foldable ;
: gpio-port-ena  ( adr -- )  \ enable clock for port
   gpio-rcc-ena-msk RCC_AHBENR bis! ;
: gpio-mode!  ( mode pin -- )  \ 00:input 01:output 10:alternate function 11:analog
   dup gpio-port >R $f and 2* #3 swap lshift R> bits! ;
: gpio-af   ( pinAdr -- adr )  \ GPIO alternate function register for port pin 
   dup gpio-port $20 + swap $8 and shr + 1-foldable ; 
: gpio-af-msk  ( pinAdr -- m )  \  pin mask for alternate function
   $7 and $f swap lshift 1-foldable ;
: gpio-af!  ( afmode pin -- )  \ set alternate function
   dup gpio-af-msk swap gpio-af bits! ;
   
   
#1 gpio-port-adr      constant PORT_B
#2 gpio-port-adr      constant PORT_C
#4 gpio-port-adr      constant PORT_E

PORT_B          #6 or constant PB6
PORT_B          #7 or constant PB7
PORT_C         #10 or constant PC10
PORT_C         #11 or constant PC11
PORT_E          #4 or constant PE4
PORT_E          #5 or constant PE5
PORT_B $10 +          constant GPIOB_IDR 
PORT_C $10 +          constant GPIOC_IDR
 
: accel-port-init  ( -- )  \ initialize acceleration sensor
   PORT_B gpio-port-ena
   PORT_E gpio-port-ena                       \ port e enable
   #2 PB6 gpio-mode!                          \ PB6 af mode
   #2 PB7 gpio-mode!                          \ PB7 af mode
   #0 PE4 gpio-mode!                          \ PE4 input mode
   #0 PE5 gpio-mode!                          \ PE5 input mode
   #4 PB6 gpio-af!
   #4 PB7 gpio-af! ;

\ systick timer support
$E000E010       constant STK_BASE
STK_BASE        constant STK_CTRL
#1 #16 lshift   constant COUNTFLAG
#1  #2 lshift   constant CLKSOURCE
#1  #1 lshift   constant TICKINT
#1              constant ENABLE
STK_BASE $04 +  constant STK_LOAD
STK_BASE $08 +  constant STK_VAL
$00ffffff       constant STK_LOAD_VAL 
STK_LOAD_VAL 1+ constant STK_LOAD_PERIOD
0               variable stk-count 
: systick-irq-handler  ( -- )
   STK_CTRL @                                 \ mask COUNT_FLAG
   #16 rshift 1 and stk-count +! ;     
: systick-start  ( -- )
   0 STK_CTRL !                               \ stop counter
   0 STK_VAL !                                \ reset counter val
   0 stk-count !                              \ init stk-count
   $00ffffff STK_LOAD !                       \ max reload value
   ['] systick-irq-handler irq-systick !      \ install systick handler
   $7 STK_CTRL ! ;                            \ sysclk/1 + int + go
: systick/8  ( -- )                           \ sysclock/8
   CLKSOURCE STK_CTRL bic! ;  
: systick/1  ( -- )                           \ sysclock/1
   CLKSOURCE STK_CTRL bis! ;  
: time-stamp-d ( -- d )                       \ 64 bit timestamp
    STK_LOAD_VAL STK_VAL @ - 0                \ 
    stk-count @ STK_LOAD_PERIOD um* d+ inline ;
: time-stamp  ( -- n )                        \ 32 bit timestamp
    STK_VAL @ negate STK_LOAD_VAL +           \ 
    stk-count @ #24 lshift + inline ;
: test-time-stamp  ( -- )  time-stamp time-stamp - negate . ;
: tts ( -- )  test-time-stamp ;
: ts. time-stamp . ;

$40010000         constant SYSCFG_BASE 
$08 SYSCFG_BASE + constant SYSCFG_EXTICR1
$0c SYSCFG_BASE + constant SYSCFG_EXTICR2
$10 SYSCFG_BASE + constant SYSCFG_EXTICR3
$40010400         constant EXTI_BASE
EXTI_BASE         constant EXTI_IMR1
$08 EXTI_BASE +   constant EXTI_RTSR1
$0C EXTI_BASE +   constant EXTI_FTSR1
$14 EXTI_BASE +   constant EXTI_PR1
\ logic tester for i2c
0    variable logic-test-last-time            \ last timestamp
0    variable logic-test-#                    \ next write location in ring buffer
#512 constant logic-test-size                 \ ringbuffer 512 words
logic-test-size cells BUFFER: logic-test-buffer

0 variable log-test-old-irq
: logic-test-buffer! ( n -- )                 \ store item into buffer
   logic-test-# @
   dup 1+ dup logic-test-size - 0< and
   logic-test-# ! 2 lshift logic-test-buffer + ! ;
: logic-test-irq-handler  ( -- )
   EXTI_PR1 @ 
   1 #10 lshift 1 #11 lshift or and
   if
    STK_VAL @                                  \ 24 bit time stamp
    GPIOC_IDR @ #24 #10 - lshift               \ pc10->b24 , pc11->b25
    #3 #24 lshift and                          \ b24(pc10) and b25(pc11) only
    logic-test-buffer!
    1 #10 lshift 1 #11 lshift or EXTI_PR1 bis! \ clear pending interrupt
   then ;
: logic-test-start  ( -- )                     \ start logic tester
   log-test-old-irq 0=
   if irq-collection @ log-test-old-irq ! then
   PORT_C gpio-port-ena                           \ port c enable
   #0 PC10 gpio-mode!                             \ PC10 input mode
   #0 PC11 gpio-mode!                             \ PC11 input mode
   SYSCFG_EXTICR3 @ $FF00 not and $1100 or
   SYSCFG_EXTICR3 !                               \ PC10 -> EXTI10 PC11->EXTI11
   1 #10 lshift 1 #11 lshift or EXTI_IMR1  bis!   \ enable interrupt
   1 #10 lshift 1 #11 lshift or EXTI_RTSR1 bis!   \ enable rising edge
   1 #10 lshift 1 #11 lshift or EXTI_FTSR1 bis! ; \ enable falling edge
