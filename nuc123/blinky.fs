\ example of using GPIO on nuc123
\   to be used on nutiny-sdk-nuc123 evaluation board
\   pin10 (PB4) connected to the red LED/VCC

compiletoflash

\ GPIO Register addresses
$50000000    constant GCR_BA
$30 GCR_BA + constant GPA_MFP
$34 GCR_BA + constant GPB_MFP
$38 GCR_BA + constant GPC_MFP
$3C GCR_BA + constant GPD_MFP
$44 GCR_BA + constant GPF_MFP
$50 GCR_BA + constant ALT_MFP
$54 GCR_BA + constant ALT_MFP1

$50004000    constant GP_BA
     GP_BA   constant GPIOA_PMD
$40  GP_BA + constant GPIOB_PMD
$80  GP_BA + constant GPIOC_PMD
$C0  GP_BA + constant GPIOD_PMD
$140 GP_BA + constant GPIOF_PMD

$008 GP_BA + constant GPIOA_DOUT
$048 GP_BA + constant GPIOB_DOUT
$088 GP_BA + constant GPIOC_DOUT
$0C8 GP_BA + constant GPIOD_DOUT
$148 GP_BA + constant GPIOF_DOUT

binary
00 constant PMODE-IN      \ INPUT
01 constant PMODE-PP      \ PUSH-PULL
10 constant PMODE-OD      \ Open drain
11 constant PMODE-QD      \ Quasi dual
decimal

: bit ( u -- u )  \ turn a bit position into a single-bit mask
  1 swap lshift  1-foldable ;

: pb4-init ( -- )
  15 bit ALT_MFP bic!
  4 bit GPB_MFP bic! \ enable pin
  PMODE-PP 4 dup + lshift GPIOB_PMD ! \ set pin output mode
;

: ledon ( -- )
  4 bit GPIOB_DOUT bic!
;

: ledoff ( -- )
  4 bit GPIOB_DOUT bis!
;

: wait 800000 0 do loop ;

: blinky
  pb4-init
  cr ." Press any key to stop"
  begin
    ledon wait ledoff wait
  key? until
  ledoff
;
 
