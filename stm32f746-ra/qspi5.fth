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
: qspi-gpio-init-hw ( -- )               \ use qspi hardware block
   AF10 QSPI_NCS gpio-mode-af! 
   AF9  QSPI_CLK gpio-mode-af!
   AF9  QSPI_D0  gpio-mode-af!
   AF9  QSPI_D1  gpio-mode-af!
   AF9  QSPI_D2  gpio-mode-af!
   AF9  QSPI_D3  gpio-mode-af! ;

: qspi-gpio-init-sw ( -- )               \ qspi bitbang
   QSPI_NCS 1 gpio-mode!
   QSPI_CLK 1 gpio-mode!
   QSPI_D0  1 gpio-mode!
   QSPI_D1  1 gpio-mode! 
   QSPI_D2  1 gpio-mode!
   QSPI_D3  1 gpio-mode! ;


:gpio-mode-list qspi-4-send qd0 qd1 qd2 qd3 gcs qck
: qspi-4-send ( -- ) qd0 qd1 qd2 qd3 gcs qck 6 gpio-ports-output ;
: qspi-gpio-init ( -- ) qd0 gpio-output qd1 gpio