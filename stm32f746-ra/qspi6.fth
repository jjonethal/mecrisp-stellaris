\ qspi6.fth

include util.fth
require gpio.fth

\ QSPI_NCS - PB6  - AF10                 \ chip select
\ QSPI_CLK - PB2  - AF9                  \ clock 
\ QSPI_D0  - PD11 - AF9                  \ data 0
\ QSPI_D1  - PD12 - AF9                  \ data 1
\ QSPI_D2  - PE2  - AF9                  \ data 2
\ QSPI_D3  - PD13 - AF9                  \ data 3


1 gpio   6 + constant QS  \ QSPI_NCS
1 gpio   2 + constant QC  \ QSPI_CLK
3 gpio #11 + constant qd0 \ QSPI_D0
3 gpio #12 + constant qd1 \ QSPI_D1
3 gpio #13 + constant qd3 \ QSPI_D3
4 gpio   2 + constant qd2 \ QSPI_D2

: qspi-gpio-clk-on ( -- )                 \ turn on gpio clock
   1 qs gpio-clk! 1 qd0 gpio-clk! 1 qd2 gpio-clk! ;
: qspi-gpio-init-sw ( -- )                \ qspi bitbang
   qspi-gpio-clk-on qs  1 gpio-mode! qc  1 gpio-mode! 
   qs gpio-output qc gpio-output qd0 1 gpio-mode!
   qd1 1 gpio-mode! qd2 1 gpio-mode! qd3 1 gpio-mode! ;
: q1<>  ( -- ) qd0  gpio-output qd1  gpio-input ;  \ single mode data io
: q2>   ( -- ) qd0  gpio-output qd1  gpio-output ; \ dual output
: q2<   ( -- ) qd0  gpio-input  qd1  gpio-input ;  \ dual input
: q4>   ( -- ) qd3  gpio-output qd2  gpio-output q2> ; \ quad out
: q4<   ( -- ) qd3  gpio-input  qd3  gpio-input q2< ;  \ quad in

: pin! ( f pin -- )                       \ output flag to pin
   swap 0<> #16 and over bsrr-off rshift swap gpio-bsrr ! ;
: pin!<< ( n pin -- n )                   \ output bit 31 to pin and << value
   over 0< swap pin! 2* ;
: qd0! ( n -- n ) qd0 pin!<< ;            \ set pin QD0
: qd1! ( n -- n ) qd1 pin!<< ;            \ set pin QD1
: qd2! ( n -- n ) qd2 pin!<< ;            \ set pin QD2
: qd3! ( n -- n ) qd3 pin!<< ;            \ set pin QD3
: qc!  ( n -- n ) qc  pin! ;              \ set pin qc
: qs!  ( n -- n ) qs  pin! ;              \ set pin qs to b31
: qc0  ( -- ) qc bsrr-off qc gpio-bsrr ! ; \ set qc 0
: qc1  ( -- ) qc bsrr-on qc gpio-bsrr ! ;  \ set qc 1
: qs0  ( -- ) qs bsrr-off qs gpio-bsrr ! ; \ set qs 0
: qs1  ( -- ) qs bsrr-on qs gpio-bsrr ! ;  \ set qs 1

: q-init ( -- )                           \ initialize qspi 
   qspi-gpio-init-sw q4> -1 qd0! qd1! qd2! qd3! drop qc1 qs1 ;
: pin@ ( pin -- f )                       \ get pin value
   dup gpio-idr swap gpio-in# bit@ ;
: pin@<< ( n pin -- n )                   \ shift in pin value
   pin@ 1 and swap 2* or ; 

\ output bit shifting
: q1b1!  ( n -- n ) qc0 qd0! qc1 ;        \ single mode shifting out highest bit
: q1b2!  ( n -- n ) q1b1! q1b1! ;
: q1b4!  ( n -- n ) q1b2! q1b2! ;         \ single mode shifting out highest 4 bit s
: q1b8!  ( n -- n ) q1b4! q1b4! ;         \ single mode shifting out highest 8 bit s
: q2b2!  ( n -- n ) qc0 qd1! qd0! qc1 ;   \ dual mode shifting 2 highest bits
: q2b4!  ( n -- n ) q2b2! q2b2! ;         \ dual mode shifting 4 highest bits
: q2b8!  ( n -- n ) q2b4! q2b4! ;         \ dual mode shifting 8 highest bits
: q4b4!  ( n -- n )                       \ dual mode shifting 4 highest bits
   qc0 qd3! qd2! qd1! qd0! qc1 ;
: q4b8!  ( n -- n ) q4b4! q4b4! ;         \ quad mode shifting 8 highest bits
: qd0<< ( n -- n ) qd0 pin@<< ;
: qd1<< ( n -- n ) qd1 pin@<< ;
: qd2<< ( n -- n ) qd2 pin@<< ;
: qd4<< ( n -- n ) qd4 pin@<< ;
\ input bit shifting
: q1b1<< ( n -- n ) qc0 qc1 qd1<< ;       \ single shifting in 1 bit from spi
: q1b2<< ( n -- n ) q1b1@ q1b1@ ;         \ single shifting in 2 bit from spi
: q1b4<< ( n -- n ) q1b2@ q1b2@ ;         \ single shifting in 4 bit from spi
: q1b8<< ( n -- n ) q1b4@ q1b4@ ;         \ single shifting in 8 bit from spi
: q2b2<< ( n -- n ) qc0 qc1 qd1<< qd0<< ; \ dual shifting in 2 bit from spi
: q2b4<< ( n -- n ) q2b2@ q2b2@ ;         \ dual shifting in 4 bit from spi
: q2b8<< ( n -- n ) q2b4@ q2b4@ ;         \ dual shifting in 8 bit from spi
: q4b4<< ( n -- n ) qc0 qc1               \ quad shifting in 4 bit from spi
   qd3<< qd2<< qd1<< qd0<< ;
: q4b8<< ( n -- n ) q4b4@ q4b4@ ;         \ quad shifting in 8 bit from spi
