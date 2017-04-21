\ stm32l152rb
\ usart1
\ pa9 - tx
\ pa10 - rx

\ REQUIRE st32l152.f
\ REQUIRE interrupts.f
\ REQUIRE delaytim2.f or other ms&us 

256 constant ubufsize		\ User buffer size
ubufsize buffer: ubuf		\ user buffer
0 variable ubufc		\ user buffer counter
1024 constant ringsize		\ multiply 2 !!!
$8b constant ubrr		\ 115200 
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

: usart1irq
USART1_DR @ ring!
;

: usart1-init
USART1_IRQn nvic-enable
['] usart1irq irq-usart1 !
1 14 lshift RCC_APB2ENR bis!
1 19 lshift
1 21 lshift or GPIOA_MODER bis!	\ Set alternate function mode pa9&pa10
1 9 lshift GPIOA_OTYPER bic!
%10 18 lshift GPIOA_OSPEEDER @ or GPIOA_OSPEEDER !	\ pa9 medium speed
%10 20 lshift GPIOA_OSPEEDER @ or GPIOA_OSPEEDER !	\ pa10 medium speed
$ff 18 lshift GPIOA_PUPDR bic!	\ No pull-up, pull-down
7 4 lshift 7 8 lshift or GPIOA_AFRH bis!		\ Set alternate function 7 (usart)

\ USART

0
1 13 lshift or	\ Enable usart1
1 5 lshift or	\ Enable RXNE intrrupt	
8 or		\ transmitter enabled
4 or		\ recevier enabled
USART1_CR1 !
ubrr USART1_BRR ! \ Speed 
;



: usart1-read ( n -- adr n )
0 ubufc !
dup ubufsize > if drop ubufsize then	\ Overflow control
dup ring-count < if drop ring-count then 
	0 ?do ring@ ubuf i + c! 1 ubufc +! loop
	ubuf ubufc @
;



: usart1-emit ( n -- )
10
begin
1 ms
$40 USART1_SR bit@	\ Transmission complete?
1- 0= or		\ stupid timeout
until
$40 USART1_SR bit@ if USART1_DR ! else drop then
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
\	ring-count if ring-count usart1-read type then
\	key? if  key 27 = 
\	if exit  
\	else 
\		cr ." Command:" ubuf 256 accept 
\		ubuf swap usart1-write-line
\	then
\	then
\ again
\ ;
