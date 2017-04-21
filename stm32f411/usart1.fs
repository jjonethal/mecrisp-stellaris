\ stm32lf411
\ usart1
\ Ilya Abdrahimov ilya73@inbox.ru
\ pa9 - tx
\ pa10 - rx

\ REQUIRE st32f411.fs
\ REQUIRE interrupts.fs
\ REQUIRE delaytim2.fs or other ms&us 

\ usart1 $0 + constant usart1_SR
\ usart1 $4 + constant usart1_DR
\ usart1 $8 + constant usart1_BRR
\ usart1 $C + constant usart1_CR1
GPIOA $8 + constant GPIOA_OSPEEDER

37 constant usart1_IRQn \ usart1 global Interrupt
256 constant ubuf1size		\ User buffer size
ubuf1size buffer: ubuf1		\ user buffer
0 variable ubuf1c		\ user buffer counter
1024 constant ring1size		\ multiply 2 !!!
$1b2 constant ubrr		\ 115200 APB1 freq 50MHz 
ring1size 1- constant ring1mask
ring1size buffer: (ring1)		\ ring1-buffer
0 variable idx1in
0 variable idx1out

\ ring1 buffer words
: ring1! ( n -- ) (ring1) idx1in @ + c! idx1in @ 1+ ring1mask and idx1in ! ;
: ring1@ ( -- n ) (ring1) idx1out @ + c@ idx1out @ 1+ ring1mask and idx1out ! ;
: ring1-count ( -- n )
idx1in @ idx1out @ >=
if idx1in @ idx1out @ - else ring1size idx1out @ - idx1in @ + then
;

: usart1irq
usart1_DR @ ring1!
;

: usart1-init
usart1_IRQn nvic-enable
['] usart1irq irq-usart1 !
1 4 lshift RCC_APB2ENR bis! \ usart1 clock enable
%10 18 lshift
%10 20 lshift or GPIOA_MODER bis!	\ Set alternate function mode pb10&pb11
1 9 lshift GPIOA_OTYPER bic!
%10 18 lshift GPIOA_OSPEEDER @ or GPIOA_OSPEEDER !	\ pa9 medium speed
%10 20 lshift GPIOA_OSPEEDER @ or GPIOA_OSPEEDER !	\ pa10 medium speed
%1111 18 lshift GPIOA_PUPDR bic!	\ No pull-up, pull-down
7 4 lshift 7 8 lshift or GPIOA_AFRH bis!		\ Set alternate function 7 (usart)

\ USART

0
1 13 lshift or	\ Enable usart1
1 5 lshift or	\ Enable RXNE intrrupt	
8 or		\ transmitter enabled
4 or		\ recevier enabled
usart1_CR1 !
ubrr usart1_BRR ! \ Speed 
;



: usart1-read ( n -- adr n )
0 ubuf1c !
dup ubuf1size > if drop ubuf1size then	\ Overflow control
dup ring1-count < if drop ring1-count then 
	0 ?do ring1@ ubuf1 i + c! 1 ubuf1c +! loop
	ubuf1 ubuf1c @
;



: usart1-emit ( n -- )
10
begin
1- dup 0=
1 ms
$40 usart1_SR bit@	\ Transmission complete?
or		\ stupid timeout
until drop
$40 usart1_SR bit@ if usart1_DR ! else drop then
;

: usart1-cr $d usart1-emit $a usart1-emit ;
: usart1-write ( adr n -- )
over + swap ?do i c@ usart1-emit loop
;
: usart1-write-line ( adr n -- ) usart1-write usart1-cr ;


\ SAMPLE:
\ Simple terminal :-)
\ : gmr s" AT+GMR" usart1-write-line ;
\ : main
\ usart1-init
\ cr ." Start!" cr
\ begin
\	ring1-count if ring1-count usart1-read type then
\	key? if  key 27 = 
\	if exit  
\	else 
\		cr ." Command:" ubuf1 256 accept 
\		ubuf1 swap usart1-write-line
\	then
\	then
\ again
\ ;
