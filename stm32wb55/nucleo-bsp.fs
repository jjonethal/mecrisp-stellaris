: led-init ( -- ) 
\ enable clock PORTB AHB2ENR bit1
%00000010 RCC-AHB2ENR bis! 
\ output mode 01 for P0, P1, P5 GPIOB-MODER
%0000010000000101 GPIOB-MODER bis! 
\ reset LEDs
%00100011 GPIOB-BRR bis! 
;

: led1! ( on/off -- ) 
%00100000 swap
if GPIOB-BSRR else GPIOB-BRR then
bis! 
;

: led2! ( on/off -- ) 
%00000001 swap
if GPIOB-BSRR else GPIOB-BRR then
bis! 
;

: led3! ( on/off -- ) 
%00000010 swap
if GPIOB-BSRR else GPIOB-BRR then
bis! 
;

: switch-init ( -- ) 
\ enable clock PORTC and PORTD AHB2ENR bit3 and bit4
%00001100 RCC-AHB2ENR bis! 
\ input mode for P4 GPIOC-MODER
%0000000011000000 GPIOC-MODER bic! 
\ input mode for P0, P1 GPIOD-MODER
%0000000000001111 GPIOD-MODER bic! 
\ pullup mode 01 for P4 GPIOC-PUPDR
%0000000001000000 GPIOC-PUPDR bis! 
\ pullup mode 01 for P0, P1 GPIOD-PUPDR
%0000000000000101 GPIOD-PUPDR bis! 
;

: switch1@ ( -- open/close )
/ input PC4
%00001000 GPIOC-IDR bit@ 
if FALSE else TRUE then
;

: switch2@ ( -- open/close )
/ input PD0
%00000001 GPIOD-IDR bit@ 
if FALSE else TRUE then
;

: switch3@ ( -- open/close )
/ input PD1
%00000010 GPIOD-IDR bit@ 
if FALSE else TRUE then
;

: test-led ( -- ) 
begin
 switch1@ led1!
 switch2@ led2!
 switch3@ led3! 
 key?
until
;
