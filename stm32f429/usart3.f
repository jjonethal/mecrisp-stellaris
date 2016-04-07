\ stm32l152rb
\ usart3
\ pb10 - tx
\ pb11 - rx

\ REQUIRE st32l152.f
\ REQUIRE interrupts.f
\ REQUIRE delaytim2.f or other ms&us 

usart3 $0 + constant usart3_SR
usart3 $4 + constant usart3_DR
usart3 $8 + constant usart3_BRR
usart3 $C + constant usart3_CR1
GPIOB $8 + constant GPIOB_OSPEEDER

39 constant usart3_IRQn \ usart3 global Interrupt
256 constant ubufsize		\ User buffer size
ubufsize buffer: ubuf		\ user buffer
0 variable ubufc		\ user buffer counter
1024 constant ringsize		\ multiply 2 !!!
$104 constant ubrr		\ 115200 APB1 freq 30MHz 
ringsize 1- constant ringmask
ringsize buffer: (ring)		\ ring-buffer
0 variable idxin
0 variable idxout

\ Ring buffer words
: ring! ( n -- ) (ring) idxin @ + c! idxin @ 1+ ringmask and idxin ! ;
: ring@ ( -- n ) (ring) idxout @ + c@ idxout @ 1+ ringmask and idxout ! ;
: ring-count ( -- n )
idxin @ idxout @ >=
if idxin @ idxout @ - else ringsize idxout @ - idxin @ + then
;

: usart3irq
usart3_DR @ ring!
;

: usart3-init
usart3_IRQn nvic-enable
['] usart3irq irq-usart3 !
1 18 lshift RCC_APB1ENR bis! \ USART3 clock enable
1 21 lshift
1 23 lshift or GPIOB_MODER bis!	\ Set alternate function mode pb10&pb11
1 10 lshift GPIOB_OTYPER bic!
%10 20 lshift GPIOB_OSPEEDER @ or GPIOB_OSPEEDER !	\ pa2 medium speed
%10 22 lshift GPIOB_OSPEEDER @ or GPIOB_OSPEEDER !	\ pa3 medium speed
%1111 20 lshift GPIOB_PUPDR bic!	\ No pull-up, pull-down
7 8 lshift 7 12 lshift or GPIOB_AFRH bis!		\ Set alternate function 7 (usart)

\ USART

0
1 13 lshift or	\ Enable usart3
1 5 lshift or	\ Enable RXNE intrrupt	
8 or		\ transmitter enabled
4 or		\ recevier enabled
usart3_CR1 !
ubrr usart3_BRR ! \ Speed 
;



: usart3-read ( n -- adr n )
0 ubufc !
dup ubufsize > if drop ubufsize then	\ Overflow control
dup ring-count < if drop ring-count then 
	0 ?do ring@ ubuf i + c! 1 ubufc +! loop
	ubuf ubufc @
;



: usart3-emit ( n -- )
10
begin
1 ms
$40 usart3_SR bit@	\ Transmission complete?
1- 0= or		\ stupid timeout
until
$40 usart3_SR bit@ if usart3_DR ! else drop then
;

: usart3-cr $d usart3-emit $a usart3-emit ;
: usart3-write ( adr n -- )
over + swap ?do i c@ usart3-emit loop
;
: usart3-write-line ( adr n -- ) usart3-write usart3-cr ;


\ SAMPLE:
\ Simple terminal :-)
\ : gmr s" AT+GMR" usart3-write-line ;
 : main
 usart3-init
 cr ." Start!" cr
 begin
	ring-count if ring-count usart3-read type then
	key? if  key 27 = 
	if exit  
	else 
		cr ." Command:" ubuf 256 accept 
		ubuf swap usart3-write-line
	then
	then
 again
 ;
