\ gpio.fth
\ gpio driver for stm32f746
\ require utils.fth

$40023800      constant RCC_BASE         \ RCC base address
$30 RCC_BASE + constant RCC_AHB1ENR      \ AHB1 peripheral clock register

\ ********** GPIO constants *************
$40020000 constant GPIO-BASE             \ base address for gpio ports
$00         constant GPIO_MODER
$04         constant GPIO_OTYPER
$08         constant GPIO_OSPEEDR
$0C         constant GPIO_PUPDR
$10         constant GPIO_IDR
$14         constant GPIO_ODR
$18         constant GPIO_BSRR
$1C         constant GPIO_LCKR
$20         constant GPIO_AFRL
$24         constant GPIO_AFRH

\ pin is an identifier for io pin consisting of gpio bank base address ored with 
\ pin number. Bank base address is obtained masking out lowest 4 bits.
\ PA3 : pin id for port A bank base + 3 for pin number $40020003

: gpio ( n -- adr )                      \ calculate base address for port bank n: 0:A, 1:B, 2:C, ...
   $f and #10 lshift GPIO-BASE or 1-foldable ;
: pin#  ( pin -- nr )                    \ get pin number from pin
   $f and 1-foldable ;
: port# ( pin -- n )                     \ return gpio port number A:0 .. K:10
   #10 rshift $f and 1-foldable ;
: port-base  ( pin -- adr )              \ get port base from pin
   $f bic 1-foldable ;
: gpio-mode-mask ( pin -- m )            \ mode mask for pin
   pin# 2* #3 swap lshift 1-foldable ;
: gpio-mode! ( mode pin -- )             \ set gpio mode 0-in 1-out 2-af
   dup gpio-mode-mask swap port-base bits! ;
: af-mask  ( pin -- mask )               \ alternate function bitmask
   $7 and #2 lshift $f swap lshift 1-foldable ;
: af-reg  ( pin -- adr )                 \ alternate function register address for pin
   dup $8 and 2/ swap
   port-base GPIO_AFRL + + 1-foldable ;
: gpio-af! ( af pin --  )                \ set alternate function reg
   dup af-mask swap af-reg bits! ;
: gpio-mode-af! ( af pin -- )            \ set gpio mode and alternate function
   $2 over gpio-mode! gpio-af! ;
: gpio-speed! ( n pin -- )               \ set gpio speed 0-low 1-med 2-fast 3-high
   dup gpio-mode-mask
   swap port-base GPIO_OSPEEDR + bits! ;
: gpio-otype! ( n pin -- )               \ set gpio output type
   dup pin# 2^ swap port-base
   GPIO_OTYPER + bits! ;
: gpio-pupd! ( mode pin -- )             \ set gpio pull/up/down 0-no,1-pull up, 2 pull-down
   dup gpio-mode-mask
   swap port-base GPIO_PUPDR + bits! ;
: gpio-bsrr ( pin -- adr )               \ address of bsrr reg
   port-base GPIO_BSRR + 1-foldable ;
: gpio-idr ( pin -- adr )                \ address of idr reg
   port-base GPIO_IDR + 1-foldable ;
: gpio-odr ( pin -- adr )                \ address of odr reg
   port-base GPIO_ODR + 1-foldable ;
\  gpio-rcc-clk! might get moved to rcc.fth
: gpio-clk! ( f pin -- )                 \ enable/disable gpio port clock
   swap 0<> swap                         \ make f a flag
   port# 2^ RCC_AHB1ENR bits! ;
: bsrr-on  ( pin -- v )                  \ gpio_bsrr mask pin on
   pin# 1 swap lshift 1-foldable ;
: gpio-in#  ( pin -- v )                 \ gpio input mask e.g. PB3 -> %1000 (2^3)
   bsrr-on 1-foldable inline ;
: bsrr-off  ( pin -- v )                 \ gpio_bsrr mask pin off
   pin# #16 + 1 swap lshift 1-foldable ;
: gpio-input ( pin -- )                  \ set pin to input mode
   0 swap gpio-mode! ;
: gpio-output ( pin -- )                 \ set pin to output mode
   1 swap gpio-mode! ;
: pin-off  ( pin -- m a )                \ generate pin of mask and bsrr address
   dup bsrr-off swap gpio-bsrr 1-foldable ;
: pin-on  ( pin -- m a )                 \ generate pin of mask and bsrr address
   dup bsrr-on swap gpio-bsrr 1-foldable ;

