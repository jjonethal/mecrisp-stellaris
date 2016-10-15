\ stm32lf411
\ tft-touch.fs
\ Ilya Abdrahimov ilya73@inbox.ru
\ Controller: ADS7843/TSC2046
\ Touch_CLK -- PA13
\ Touch_CS -- PA14
\ Touch_DIN -- PA15
\ Touch_DOUT -- PA11
\ Touch_IRQ -- PD2


1 13 lshift constant T_CLK \
1 14 lshift constant T_CS \
1 15 lshift constant T_DIN \
1 11 lshift constant T_DOUT \
1 2  lshift constant T_IRQ \

: gpioa-low ( n -- ) 16 lshift GPIOA_BSRR bis! ;
: gpioa-high ( n -- ) GPIOA_BSRR bis! ;

\ There are touch ?
0 variable touch?
0 variable touch_x
0 variable touch_y

\ Посылаем байт в индикатор
\ Submitting byte indicator
: wr-touch ( c -- )
8 0 do
T_CLK gpioa-high 1 us
dup i lshift $80 and 
	if T_DIN gpioa-high 
	else T_DIN gpioa-low
	then
T_CLK gpioa-low 1 us
loop
drop
;

\ Принимаем данные (12 бит) из индикатора
\ Receiving data (12 bits) from the indicator
: rd-touch ( -- n )
0
12 0 do
	T_CLK gpioa-high 1 us 
	1 lshift
	T_DOUT gpioa $10 + bit@ if  1 or then
	T_CLK gpioa-low 1 us
loop
;

: _read-touch ( c -- n )
T_CS gpioa-low
wr-touch
5 ms
rd-touch
T_CS gpioa-high
;


 : av-init ( n3 n2 n1 -- ) 0 arr![]  1 arr![] 2 arr![] ;
 : bad-value! 6 arr![] ;
 : bad-value \ Максимальное из 3-х
 3 arr@[] 4 arr@[] >= 
 if 3 arr@[] 0 bad-value! 
 else 4 arr@[] 1 bad-value!
 then  5 arr@[] 
 < if 2 bad-value! then ; 

: calc-delta
 0 arr@[] 1 arr@[] 2 arr@[] + + 3 /	\ Aver
 dup >r 0 arr@[] - abs 3 arr![]
 r@ 1 arr@[] - abs 4 arr![]
 r> 2 arr@[] - abs 5 arr![] 
;
: average-val 
av-init
calc-delta
bad-value
0
3 0 do
	6 arr@[] i <> if i arr@[] + then
	loop 2/
; 

: _get-touch-xy ( -- x y z )
$98 _read-touch	\ читаем x
\ $98 _read-touch	\ читаем x
\ $98 _read-touch	\ читаем x
\ average-val
\ 3942 - 399 * 222 3942 - /
$d8 _read-touch \ читаем y
\ $d8 _read-touch \ читаем y
\ $d8 _read-touch \ читаем y
\ average-val
\ 222 - 239 * 3942 222 - /
 $b8 _read-touch	\ z1
;

: init-touch-gpio
\ 1 7 lshift RCC_AHB1ENR bis!	\ enable GPIOH
\ $15000000 gpioa bis!	\ output
$ff000000 gpioa bic! 
$54000000 gpioa bis!
1 T_IRQ lshift gpiod $c + bis! \ T_IRQ pull-up
;

: scale-x
970 - 399 * 40 970 - /
;

: scale-y
95 - 239 * 956 95 - /
;

: irq-touch 
_get-touch-xy 0 > if scale-y touch_y ! scale-x touch_x ! true touch? ! else 2drop false touch? ! then

1 2 lshift EXTI_PR bis!
;

: get-touch-xy touch_x @ touch_y @ false touch? ! ;

: init-touch
['] irq-touch irq-exti2 !

1 14 lshift RCC_APB2ENR bis! 	\ Syscfg enable
 %011 8 lshift SYSCFG_EXTICR1 bis!	\ EXTI2
 1 2 lshift EXTI_FTSR bis!	\ прерывание по спаду
 8 nvic-enable		\ EXTI2
1 2 lshift EXTI_IMR bis!	\ EXTI2 enable
init-touch-gpio
T_CS gpioa-low
T_CLK gpioa-high
T_CLK gpioa-low
$d8 wr-touch
\ 2 touch-delay !


\ get-touch-xy 2drop
;

\ : lcd-ud.r ( n1 n -- ) >r n>s r> over - 0 ?do #32 lcd-emit loop lcd-type ;
\ Sample
\ : .xy 
\ get-touch-xy ( 2dup)  pixel 
\ 3 3 setxy swap 3 lcd-ud.r 32 lcd-emit 3 lcd-ud.r
\ ;
 : .xy get-touch-xy 2dup pixel cr swap ." x=" . ." y=" . ;

\ 10 variable per
 : test
 lcd-init clrscn green fgcolor !
 init-touch
 begin
	\ per @  ms
	touch? @ if .xy then 
 key?
 until
 ;

