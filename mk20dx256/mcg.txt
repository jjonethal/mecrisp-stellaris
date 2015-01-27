\ Clock setup for 16 MHz crystal and 96  MHz System Clock
\ Use "fullspeed" word to switch to 96MHz and readjust UART

\ -----------------------------------
\ Multipurpose Clock Generator Constants
\ -----------------------------------
$40064000 constant MCG_C1
$40064001 constant MCG_C2
$40064002 constant MCG_C3
$40064003 constant MCG_C4
$40064004 constant MCG_C5
$40064005 constant MCG_C6
$40064006 constant MCG_S
$40064008 constant MCG_SC
$40065000 constant OSC_CR
$40048044 constant SIM_CLKDIV1
$40048048 constant SIM_CLKDIV2
$40048034 constant SIM_SCGC4
$40048004 constant SIM_SOPT2

\ ------------------------
\ Helper words
\ ------------------------
: mcg-osc-ready? 2 MCG_S cbit@ ; 
: mcg-extref-refclock? $10 MCG_S cbit@ not ;
: mcg-extref-outclk? MCG_S c@ $0C and $8 = ;
: mcg-pll-lock? 64 MCG_S cbit@ ;
: mcg-pll-use-crystal? 32 MCG_S cbit@ ;

\ -----------------------
\ Main words
\ ------------------------
: MCG_96MHz ( -- ) 
\ Setup the oscillator
10 OSC_CR c! 	\ Set the capacitor load to 10 pF for the crystal
$24 MCG_C2 c!	\ enable osc, 8-32 MHz range, low power mode
2 6 lshift 4 3 lshift + MCG_C1 C! \ switch to crystal as clock source, FLL input = 16 MHz div 512

\ Wait for oscillator to begin, FLL to use it, MCGOUT to be based on oscillator
begin mcg-osc-ready? until  		\ wait for crystal oscillator to begin
begin mcg-extref-refclock? until	\ wait for reference clock to switch to external refernce
begin mcg-extref-outclk? until 		\ wait for MCGOUT to use external reference clock

\ Now we are in FBE mode
3 MCG_C5 c! 				\ config PLL input for 16 MHz Crystal / 4 = 4 MHz
1 6 lshift  MCG_C6 c!			\ config PLL and select multiplier of 24 (24x4=96MhHz)
begin mcg-pll-use-crystal? until	\ wait for PLL to start using xtal as its input	
begin mcg-pll-lock? until 		\ wait for PLL to lock 

\ Now we are in PBE mode
$01030000 SIM_CLKDIV1 !	\ config divisors: 96 MHz core, 48 MHz bus, 24 MHz flash
4 3 lshift MCG_C1 C! 		\ switch to PLL  as clock source, FLL input = 16 MHz div 512

begin MCG_S c@ $0C and $0C = until 	\ wait for PLL clock to be used
\ now we're in PEE mode
;

\ ---------------------------------
\ For setting clock for peripherals
\ ---------------------------------
$4006A000 constant UART0_BASE
$4006A015 constant UART0_RWFIFO


: UART_96MHz_115200 ( -- )
  0 UART0_BASE c!
  52 [ UART0_BASE 1 + literal, ] c!
  3 [ UART0_BASE $A + literal, ] c!
;

: USB_96MHz_48MHZ ( -- )
  2 SIM_CLKDIV2 ! \  SET DIVISOR TO BE 2 (USBDIV=1, USBCLK = MCGPLL / (1 + 1)
  $510C0 SIM_SOPT2 ! \ SIM_SOPT2_USBSRC, SIM_SOPT2_PLLFLLSEL, SIM_SOPT2_TRACECLKSEL, SIM_SOPT2_CLKOUTSEL(6)
;


: fullspeed 0 uart0_rwfifo c! MCG_96MHz UART_96MHz_115200 6 uart0_rwfifo c! ;
\ Note:  technically, you are supposed to disable the receiver before changing the watermark
\ but this responds more quickly and seems to work.

