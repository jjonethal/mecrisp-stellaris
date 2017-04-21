

\
\ Контроллер: ST7735S

\ STM	LCD

\ PA.2	RESET
\ PA.3	C/D
\ PA.4	CS
\ PA.5	SCK
\ PA.7	SDA
\ LCD definitions
160 constant DWIDTH
128 constant DHEIGHT

1 4 lshift constant lcd-cs
1 2 lshift constant lcd-res
1 3 lshift constant lcd-cd
1 5 lshift constant spi-sck
1 7 lshift constant spi-mosi
: spi-busy? begin $80 SPI1_SR bit@ 0= until ;
: lcd-sel  ( -- ) lcd-cs 16 lshift gpioa_bsrr bis! inline ;
: lcd-unsel ( -- ) lcd-cs           gpioa_bsrr bis! inline ;
: lcd-res0  ( -- ) lcd-res 16 lshift gpioa_bsrr bis! inline ;
: lcd-res1 ( -- ) lcd-res           gpioa_bsrr bis! inline ;
: lcd-cd0  ( -- ) spi-busy? lcd-cd 16 lshift gpioa_bsrr bis!  ;	\ 0 - command, 1 - data
: lcd-cd1 ( -- ) spi-busy? lcd-cd           gpioa_bsrr bis!  ;

: init-gpio
GPIOA @ $000000ff and GPIOA !
%0001 2 4 * lshift 		\ PA.2 output/push-pool
%0001 3 4 * lshift or	\ PA.3 output/push-pool
%0001 4 4 * lshift or	\ PA.4 AF
%1001 5 4 * lshift or	\ PA.5 AF
%1001 7 4 * lshift or	\ PA.7 AF
\ %1001 6 4 * lshift or	\ PA.6 AF
\ GPIOA @ or
GPIOA bis!
lcd-unsel lcd-res1 lcd-cd0
1 12 lshift RCC_APB2ENR bis!	\ enable SPI1
%001 3 lshift \ /4
 1 15 lshift or		\ BIDIMODE on
 1 14 lshift or		\ Tx only
 \ 1 11 lshift or
 1 2 lshift or	\ master
 1 9 lshift or
 1 8 lshift or
\ 1 1 lshift or	\ CPOL=1
\ 1 or
SPI1_CR1 h!
1 6 lshift	SPI1_CR1 bis!	\ SPI enable
; 


: >spi> ( c -- c ) 
 true begin 1- dup 0=  2 SPI1_SR bit@ or until drop	\ Wait TX finish 
 SPI1_DR !  
 SPI1_DR @
;
: >spi ( c -- ) >spi> drop ;
: spi> ( -- c ) 0 >spi> ;
: c>lcd lcd-cd0 >spi ;
: d>lcd  >spi ;
: d16>lcd ( h -- )
 \ lcd-cd1
   dup 8 rshift d>lcd
   d>lcd
	
;

\ Calculate pixel's color from red, green and blue components
\ Packed color is of the form: rrrrrggggggbbbbb
: pixelColor		( blue green red --- pixelColor)
    >r >r		( blue green red -- blue )
    $F8 and 3 rshift r>
    $FC and 3 lshift or r>
    $F8 and 8 lshift or
;


0 variable fgColor
0 variable bgColor

\ Store foreground color
: setRGBFGColor		( blue green red --- )
    pixelColor fgColor !
;

\ Store background color
: setRGBBGColor		( blue green red --- )
    pixelColor bgColor !
;

\ Store foreground color
: setFGColor		( color --- )
    fgColor !
;

\ Store background color
: setBGColor		( color --- )
    bgColor !
;

: lcd-init
init-gpio
lcd-sel
lcd-res0 15 ms lcd-res1
15 ms
\ SETEXTC
$01 c>lcd
  200 ms
 $11 c>lcd                            \ Exit Sleep    
	$3a c>lcd		\ Режим цвета
	lcd-cd1
	$5 d>lcd		\ 16 bit
  $36 c>lcd                            \ Memory Access Control    
  lcd-cd1
  $40 d>lcd
\	14 d>lcd  
        
  100 ms
  $29 c>lcd                            \ Display on
  100 ms           
  \ Set foreground and background colors to defaults
    255 255 255 pixelColor setFGColor	\ White
      0   0   0 pixelColor setBGColor	\ Black
lcd-unsel
;

\ ----
\ TFT Init and Pixel access
\ ----

: setcol  ( start end -- )
  $2A c>lcd
   swap lcd-cd1 d16>lcd
   d16>lcd
;

: setpage ( start end -- )
  $2B c>lcd
   swap lcd-cd1 d16>lcd
   d16>lcd
;



: setBounds ( x1 x2 y1 y2 -- )
setcol setpage
;

: clearBounds ( -- )
0 DWIDTH 1- 0 DHEIGHT 1- setBounds
;


: fillScn
lcd-sel
$2C c>lcd lcd-cd1
  fgcolor @ 40960 0 do dup  d16>lcd loop \ 160 x 128 x 2 Bytes/Pixel
  drop
lcd-unsel
;


\ Clear the screen to background color
: clrScn		( --- )
lcd-sel clearBounds
    fgColor @ >r bgColor @ fgColor !
    fillScn
    r> fgColor !
;

$0000 constant BLACK  
$001F constant BLUE   
$07E0 constant GREEN  
$F800 constant RED    
$FFFF constant WHITE  

$07FF constant CYAN   
$F81F constant MAGENTA
$FFE0 constant YELLOW 

