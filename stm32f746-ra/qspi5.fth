\ file qspi5.fth
\ author jean jonetahl
\ qspi flash part N25Q128A13EF840E
\ qspi flash datasheet "C:\Users\jeanjo\Downloads\stm\n25q_128mb_3v_65nm.pdf"
\ stm32f746 user manual "C:\Users\jeanjo\Downloads\stm\DM00124865 RM0385 STM32F75xxx and STM32F74xxx advanced ARM®-based 32-bit MCUs.pdf"

\ include util.fth
\ include gpio.fth

\ QSPI_NCS - PB6  - AF10
\ QSPI_CLK - PB2  - AF9
\ QSPI_D0  - PD11 - AF9
\ QSPI_D1  - PD12 - AF9
\ QSPI_D2  - PE2  - AF9
\ QSPI_D3  - PD13 - AF9

\ ********** qspi driver io ports *******   
 #1 GPIO    constant GPIOB
 #3 GPIO    constant GPIOD
 #4 GPIO    constant GPIOE
 #2 GPIOB + constant PB2
 #6 GPIOB + constant PB6
#11 GPIOD + constant PD11
#12 GPIOD + constant PD12
#13 GPIOD + constant PD13
 #2 GPIOE + constant PE2

PB6  constant QSPI_NCS 
PB2  constant QSPI_CLK 
PD11 constant QSPI_D0
PD12 constant QSPI_D1
PE2  constant QSPI_D2
PD13 constant QSPI_D3

#10 constant AF10
 #9 constant AF9

\ ********** qspi helper functions ******
: hh/l# ( f -- m ) 0= $FFFF xor          \ Mask high/low half word low 0:$ffff0000 1:0000FFFF
   1-foldable ;
: pin-10# ( pin -- m )                   \ pin on / off mask
   bsrr-on dup 16 lshift or 1-foldable ;
 
 
\ ********** qspi registers *********************
$A0001000 constant QSPI_BASE

: qspi-gpio-init-hw ( -- )                       \ use qspi hardware block
   AF10 QSPI_NCS gpio-mode-af! 
   AF9  QSPI_CLK gpio-mode-af!
   AF9  QSPI_D0  gpio-mode-af!
   AF9  QSPI_D1  gpio-mode-af!
   AF9  QSPI_D2  gpio-mode-af!
   AF9  QSPI_D3  gpio-mode-af! ;

: qspi-gpio-clk-on ( -- )                        \ turn on gpio clock
   1 GPIOB gpio-clk!
   1 GPIOD gpio-clk!
   1 GPIOE gpio-clk! ;

: qspi-gpio-init-sw ( -- )                       \ qspi bitbang
   qspi-gpio-clk-on
   QSPI_NCS 1 gpio-mode!
   QSPI_CLK 1 gpio-mode!
   QSPI_D0  1 gpio-mode!
   QSPI_D1  1 gpio-mode! 
   QSPI_D2  1 gpio-mode!
   QSPI_D3  1 gpio-mode! ;

\ input pins
: qd0@ QSPI_D0  gpio-in# QSPI_D0  gpio-idr bit@ ;
: qd1@ QSPI_D1  gpio-in# QSPI_D1  gpio-idr bit@ ;
: qd2@ QSPI_D2  gpio-in# QSPI_D2  gpio-idr bit@ ;
: qd3@ QSPI_D3  gpio-in# QSPI_D3  gpio-idr bit@ ;
: qcs@ QSPI_NCS gpio-in# QSPI_NCS gpio-idr bit@ ;
: qck@ QSPI_CLK gpio-in# QSPI_CLK gpio-idr bit@ ;

: qd0-1 QSPI_D0  pin-on ! ;
: qd1-1 QSPI_D1  pin-on ! ;
: qd2-1 QSPI_D2  pin-on ! ;
: qd3-1 QSPI_D3  pin-on ! ;
: qcs-1 QSPI_NCS pin-on ! ;
: qck-1 QSPI_CLK pin-on ! ;

: qd0-0 QSPI_D0  pin-off ! ;
: qd1-0 QSPI_D1  pin-off ! ;
: qd2-0 QSPI_D2  pin-off ! ;
: qd3-0 QSPI_D3  pin-off ! ;
: qcs-0 QSPI_NCS pin-off ! ;
: qck-0 QSPI_CLK pin-off ! ;

: qd0! 0= #16 and QSPI_D0  bsrr-on swap lshift QSPI_D0  gpio-bsrr ! ;
: qd1! 0= #16 and QSPI_D1  bsrr-on swap lshift QSPI_D1  gpio-bsrr ! ;
: qd2! 0= #16 and QSPI_D2  bsrr-on swap lshift QSPI_D2  gpio-bsrr ! ;
: qd3! 0= #16 and QSPI_D3  bsrr-on swap lshift QSPI_D3  gpio-bsrr ! ;
: qcs! 0= #16 and QSPI_NCS bsrr-on swap lshift QSPI_NCS gpio-bsrr ! ;
: qck! 0= #16 and QSPI_CLK bsrr-on swap lshift QSPI_CLK gpio-bsrr ! ;

