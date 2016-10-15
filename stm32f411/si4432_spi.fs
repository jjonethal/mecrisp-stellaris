\ si4432.fs
\ Ilya Abdrahimov ilya73@inbox.ru
\ PA5 - SPI1_SCK
\ PA6 - SPI1_MISO
\ PA7 - SPI1_MOSI
\ PA4 - nSEL
\ PD2 - nIRQ
SPI1 $8 + constant SPI1_SR
SPI1 $c + constant SPI1_DR
GPIOD $C + constant GPIOD_PUPDR
GPIOD $10 + constant GPIOD_IDR

40 buffer: si4432-rxbuf
0 variable si4432_pkt_len	\ Длина принятого пакета
\ 0 variable si4432-pkt-flg	\ Флаг
2 constant SI4432_RF_PACKET_RECEIVED
5 constant SI4432_RF_NO_PACKET
6 constant SI4432_RF_CRC_ERROR
0 variable SI4432_status

\ Primitives for SPI bit-banging

1 4 lshift constant si4432-select
1 2 lshift constant si4432-nirq
: si4432-sel   ( -- ) si4432-select 16 lshift gpioa_bsrr ! inline ;
: si4432-unsel ( -- ) si4432-select           gpioa_bsrr ! inline ;

: nIRQ? ( -- ? ) si4432-nirq gpiod_idr bit@ 0= inline ;

: si4432-gpio-init ( -- )

  \ Select pins as outputs and deselect
  %01 4 2* lshift gpioa_moder bis!  \ Set select pin as output
  si4432-unsel
\ %01 2 2* lshift gpiod_pupdr bis!	\ nIRQ pull-up
  \ Do line initialisation for SPI bit-banging
                                      
  %10 5 2* lshift                    \ Set SCK pin as AF
  %10 6 2* lshift or                   \ MISO AF
  %10 7 2* lshift or gpioa_moder bis!  \ Set MOSI pin as AF
  GPIOA_AFRL @ $000fffff and GPIOA_AFRL !
  5 20 lshift 5 24 lshift 5 28 lshift or or 
  GPIOA_AFRL bis! \ Set AF5 mode from PA.5-7
  1 12 lshift RCC_APB2ENR bis! 	\ Enable SPI1
  
  %010 3 lshift \ 50MHz/8=6,25
1 9 lshift or
1 8 lshift or
1 2 lshift or	\ master
SPI1 h!
1 6 lshift	SPI1 bis!	\ SPI enable
  \ sck-low                          

  \ Finished.
;

: >spi1> ( c -- c ) 
 SPI1_DR !
 true begin 1- dup 0= 2 SPI1_SR bit@ or until drop	\ Wait TX finish 
 true begin 1- dup 0= 1 SPI1_SR bit@ or until drop	\ Wait RX finish  
 SPI1_DR @
;
: >spi1 ( c -- ) >spi1> drop ;
: spi1> ( -- c ) 0 >spi1> ;

: si4432-read
spi1>
;

: si4432-write
>spi1
;


: SI4432> ( adr -- n)
si4432-sel
si4432-write
si4432-read
si4432-unsel
;

: >SI4432 ( adr n -- )
 si4432-sel
swap $80 or
si4432-write
si4432-write
 si4432-unsel
;



: si4432-rdintst  ( -- n n1 ) 3 SI4432> 4 SI4432> ;

: SI4432-init
si4432-gpio-init
100 ms
\ read interrupt status
si4432-rdintst 2drop
\ SW reset -> wait for POR interrupt
7 $80 >SI4432
100 ms
\ read interrupt status
3 SI4432> drop
\
7 0 >SI4432
$65 $a1 >SI4432
\ disable all ITs, except 'ichiprdy'
5 0 >SI4432
6 2 >SI4432
si4432-rdintst 2drop
\ set the non-default Si4432 registers
\ set TX Power +11dBm
$6d 0 >SI4432
\ set VCO
$5a $7f >SI4432
$59 $40 >SI4432
\ set the AGC
$6a $b >SI4432
\ set ADC reference voltage to 0.9V
$68 $4 >SI4432
\ set cap. bank
$9 $7f >SI4432
\ reset digital testbus, disable scan test
$51 41 >SI4432	\ ?
\ select nothing to the Analog Testbus
$50 $b >SI4432
\ set frequency
$75 $53 >SI4432
$76 $64 >SI4432
$77 $00 >SI4432
\ disable RX-TX headers
\ $32 0 >SI4432
\ $33 2 >SI4432
$32 $ff >si4432
$33 $42 >si4432
\ Transmit header
$3a [char] c >si4432
$3b [char] l >si4432
$3c [char] i >si4432
$3d [char] 1 >si4432
\ Check header
$3f [char] s >si4432
$40 [char] e >si4432
$41 [char] r >si4432
$42 [char] 1 >si4432

\ set the sync word
$36 $2d >SI4432
$37 $d4 >SI4432
\ set GPIO0 to MCLK
$b $12 >SI4432
$c $15 >SI4432
\ set modem and RF parameters according to the selected DATA rate
\ setup the internal digital modem according the selected RF settings (data rate)
$1c $4 >SI4432
$20 $41 >SI4432
$21 $60 >SI4432
$22 $27 >SI4432
$23 $52 >SI4432
$24 $00 >SI4432
$25 $0a >SI4432
$6e $27 >SI4432
$6f $52 >SI4432
$70 $20 >SI4432
$72 $48 >SI4432
$1d $40 >SI4432
$58 $80 >SI4432
\ enable packet handler & CRC16
$30 $8d >SI4432
$71 $63 >SI4432
\ set preamble length & detection threshold
$34 $4 1 lshift >SI4432
$35 $2 4 lshift >SI4432
$1f $3 >SI4432
\ reset digital testbus, disable scan test
$51 $0 >SI4432
\ select nothing to the Analog Testbus
$50 $b >SI4432
;

: SI4432-Transmit ( adr n -- )
\ set packet length
$3e over >SI4432
over + swap
?do
	$7f i c@ >SI4432 
loop
\ errata
$65 $a1 >SI4432 5 ms
\ enable transmitter
$7 $9 >SI4432 5 ms
\ enable the packet sent interrupt only
$5 $4 >SI4432
\ read interrupt status registers
si4432-rdintst 2drop
\ wait for the packet sent interrupt
true begin 1- dup 0= nIRQ? or until drop
si4432-rdintst drop SI4432_status !
;

: SI4432-Receive
\ errata
$65 $a1 >SI4432 5 ms
\ enable receiver chain
$7 $5 >SI4432 5 ms
\ enable the wanted ITs
$5 $12 >SI4432	\ RX FIFO full & valid packet received
$6 $00 >SI4432
\ read interrupt status registers
\ si4432-rdintst 2drop
;



: SI4432-Packet-Recived ( -- )
		\ check what caused the interrupt 
		\ read out IT status register
		\ si4432-rdintst drop dup SI4432_status ! 
		\ packet received interrupt occurred
		\ 2 and if
			$4b SI4432> 	\ packet lenght
			si4432-rxbuf over over + swap
			?do $7f SI4432> i c! loop
			si4432_pkt_len !
		\ then
;

\ 8 constant EXTI2_IRQn  \ EXTI Line2 Interrupt
\ : si4432-irq
\ si4432-rdintst drop dup SI4432_status ! dup cr ." irq:" hex.
\ 2 and 	if		\	Приняли пакет
\			SI4432-Packet-Recived 
\	 	then	
\ SI4432-Receive
\ 1 2 lshift exti_pr bis!
\ ;

: si4432-start
si4432-init
SI4432-Receive
\ ['] si4432-irq irq-exti2 !
\ 1 14 lshift rcc_apb2enr bis!	\ Enable syscfg registr 
\ %11 8 lshift syscfg_exticr1 bis!	\ select PD.2 ext interrupt
\ 1 2 lshift exti_rtsr bic!
\ 1 2 lshift exti_ftsr bis!
\ EXTI2_IRQn nvic-enable
\ 1 2 lshift exti_imr bis!	\ Enable 2 ext interrupt 
;
\ compiletoram
