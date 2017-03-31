\ tft.fs v1.0
\ From: stm32f4-discovery
\ Based on tft.txt :)
\ Ilya Abdrahimov

\ Added some words

\ ************** Graphics ********************* 
\ filledRect ( x1 y1 x2 y2 -- )

\ Draw horizontal line with foreground color
\ hLine ( x y len -- )

\ Draw vertical line with foreground color
\ vLine ( x y len -- )

\ Draw a rectangle with foreground color
\ rect			( x1 y1 x2 y2 --- )

\ Draw filled circle with foreground color
\ filledCircle		( x y radius --- ) 

\ Draw a circle with foreground color
\ circle		( x y radius --- )

\ Draw line with foreground color
\ line			( x1 y1 x2 y2 --- )

\ Draw a line to the given location from the position of the graphics cursor
\ then update the cursor's position with the new location
\ lineTo		( x y --- )

\ **************** Printing ******************
\ Warning !!! Before using the print word, you must set the current font word setFont !!!
\ Set current font
\ setFont ( adr -- ) \ adr 

\ Set the position for printing in accordance with the current font settings
\ setXY ( x y -- )

\ lcd-emit ( c -- )

\ lcd-type ( adr n -- )

\ 
\ All connected display wires on STM32F429 Discovery:

\   PA3  = G2         PD3  = G7
\   PA4  = VSYNC      PD6  = B2
\   PA6  = G2         PD13 = WRX (CMD/DATA)
\   PA11 = R4         PF7  = SPI_CLK
\   PA12 = R5         PF8  = SPI_MISO
\   PB0  = R3         PF9  = SPI_MOSI
\   PB1  = R6         PF10 = DE (Enable)
\   PB8  = B6         PG6  = R7
\   PB9  = B7         PG7  = CLK
\   PB10 = G4         PG10 = G3
\   PB11 = G5         PG11 = B3
\   PC2  = SPI_CS     PG12 = B4
\   PC6  = HSYNC
\   PC7  = G6
\   PC10 = R2

\ Wires actually in use for the simple 4 wire SPI based interface

\   PC2  = SPI_CS
\   PF7  = SPI_CLK
\   PF8  = SPI_MISO
\   PF9  = SPI_MOSI

\   PD13 = WRX (CMD/DATA)
\   PF10 = DE (Enable)



\ --
\  Port register definitions
\ --

$40020000 constant PORTA_Base
$40020400 constant PORTB_Base
$40020800 constant PORTC_Base
$40020C00 constant PORTD_Base
$40021000 constant PORTE_Base
$40021400 constant PORTF_Base
$40021800 constant PORTG_Base
$40021C00 constant PORTH_Base
$40022000 constant PORTI_Base

PORTC_BASE $00 + constant PORTC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTC_BASE $04 + constant PORTC_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTC_BASE $08 + constant PORTC_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTC_BASE $0C + constant PORTC_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTC_BASE $10 + constant PORTC_IDR      \ RO      Input Data Register
PORTC_BASE $14 + constant PORTC_ODR      \ Reset 0 Output Data Register
PORTC_BASE $18 + constant PORTC_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTC_BASE $20 + constant PORTC_AFRL     \ Reset 0 Alternate function  low register
PORTC_BASE $24 + constant PORTC_AFRH     \ Reset 0 Alternate function high register

PORTD_BASE $00 + constant PORTD_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTD_BASE $04 + constant PORTD_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTD_BASE $08 + constant PORTD_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTD_BASE $0C + constant PORTD_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTD_BASE $10 + constant PORTD_IDR      \ RO      Input Data Register
PORTD_BASE $14 + constant PORTD_ODR      \ Reset 0 Output Data Register
PORTD_BASE $18 + constant PORTD_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTD_BASE $20 + constant PORTD_AFRL     \ Reset 0 Alternate function  low register
PORTD_BASE $24 + constant PORTD_AFRH     \ Reset 0 Alternate function high register

PORTF_BASE $00 + constant PORTF_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTF_BASE $04 + constant PORTF_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTF_BASE $08 + constant PORTF_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTF_BASE $0C + constant PORTF_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTF_BASE $10 + constant PORTF_IDR      \ RO      Input Data Register
PORTF_BASE $14 + constant PORTF_ODR      \ Reset 0 Output Data Register
PORTF_BASE $18 + constant PORTF_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTF_BASE $20 + constant PORTF_AFRL     \ Reset 0 Alternate function  low register
PORTF_BASE $24 + constant PORTF_AFRH     \ Reset 0 Alternate function high register

\ ----
\  Bit-Bang SPI Implementation
\ ----

1 2 lshift constant lcd-select

: lcd-sel   ( -- ) lcd-select 16 lshift portc_bsrr ! inline ;
: lcd-unsel ( -- ) lcd-select           portc_bsrr ! inline ;

\ Primitives for SPI bit-banging

1 7 lshift constant spi-sck
1 8 lshift constant spi-miso
1 9 lshift constant spi-mosi

: sck-high  ( -- ) spi-sck            portf_bsrr ! inline ;
: sck-low   ( -- ) spi-sck  16 lshift portf_bsrr ! inline ;
: mosi-high ( -- ) spi-mosi           portf_bsrr ! inline ;
: mosi-low  ( -- ) spi-mosi 16 lshift portf_bsrr ! inline ;

: miso ( -- ? ) spi-miso portf_idr bit@ inline ;


: spi-init ( -- )

  \ Select pins as outputs and deselect
  %01 2 2* lshift portc_moder bis!  \ Set select pin as output
  %11 2 2* lshift portc_ospeedr bis! \ Set Very high speed
  lcd-unsel

  \ Do line initialisation for SPI bit-banging
                                      
  %01 7 2* lshift                    \ Set SCK pin as output
                                      \ MISO is input after Reset
  %01 9 2* lshift or portf_moder bis!  \ Set MOSI pin as output
  
  %11 7 2* lshift                    
  %11 9 2* lshift or portf_ospeedr bis!  \ Set Very high speed
  sck-low                          

  \ Finished.
;

: bit-spix ( ? -- ? )
  if mosi-high else mosi-low then 
  sck-high
  sck-low
  miso
  inline 
;

: spix ( x -- x ) $FF and

    dup 128 and bit-spix if 128 or else 128 bic then
    dup 64 and bit-spix if 64 or else 64 bic then
    dup 32 and bit-spix if 32 or else 32 bic then
    dup 16 and bit-spix if 16 or else 16 bic then

    dup 8 and bit-spix if 8 or else 8 bic then
    dup 4 and bit-spix if 4 or else 4 bic then
    dup 2 and bit-spix if 2 or else 2 bic then
    dup 1 and bit-spix if 1 or else 1 bic then
;

: >spi ( x -- ) spix drop ;
: spi> ( -- x ) 0 spix ; 


\ ----
\  Initialisations for LCD module
\ ----

: lcd-data    ( -- ) 1 13 lshift           portd_bsrr ! ; \ Set line high
: lcd-command ( -- ) 1 13 lshift 16 lshift portd_bsrr ! ; \ Set line low

: lcd-init ( -- )
 \ init-delay

  %01 13 2* lshift portd_moder bis! \  Set WRX-Pin as output
  %11 13 2* lshift portd_ospeedr bis! \ Set Very high speed
  %01 10 2* lshift portf_moder bis! \  Set  DE-Pin as output
  %11 10 2* lshift portf_ospeedr bis! \ Set Very high speed
  1 10 lshift portf_bsrr !          \      and high

  spi-init
;

: -- <builds over , + does> @ + ;

\ ----
\ TFT Communication Basics
\ ----

: sendcmd ( command -- )
  lcd-command
  lcd-sel
  >spi
  lcd-unsel
;

: writedata ( c -- )
  lcd-data
  lcd-sel
  >spi
  lcd-unsel
;

: writedata16 ( h -- )
  lcd-data
  lcd-sel
  dup 8 rshift >spi
  >spi
  lcd-unsel
;

: writebuffer ( c-addr count -- )
  lcd-data
  lcd-sel
  0 ?do dup 1+ c@ >spi \ High first
    dup  c@ >spi
    2+ loop drop
  lcd-unsel
;

\ ----
\ TFT Init and Pixel access
\ ----

: setcol  ( start end -- )
  $2A sendCMD
  swap writedata16
  writedata16
;

: setpage ( start end -- )
  $2B sendCMD
  swap writedata16
  writedata16
;

319 constant xmax
239 constant ymax

: setBounds ( x1 x2 y1 y2 -- )
setcol setpage
;

: clearBounds ( -- )
0 xmax 0 ymax setBounds
;

: clearscreen ( -- )
 clearBounds
  $2C sendCMD

  lcd-data
  lcd-sel
  153600 0 do 0 >spi loop \ 320 x 240 x 2 Bytes/Pixel
  lcd-unsel
;

: putpixel ( x y col -- )
  swap dup setcol
  swap dup setpage
  $2C sendCMD
  writedata16
;

: tft-init ( -- )

  lcd-init
  lcd-unsel
  lcd-data

  $01 sendCMD
  200 ms

  $CF sendCMD
  $00 writedata
  $8B writedata
  $30 writedata

  $ED sendCMD
  $67 writedata
  $03 writedata
  $12 writedata
  $81 writedata

  $E8 sendCMD
  $85 writedata
  $10 writedata
  $7A writedata

  $CB sendCMD
  $39 writedata
  $2C writedata
  $00 writedata
  $34 writedata
  $02 writedata

  $F7 sendCMD
  $20 writedata

  $EA sendCMD
  $00 writedata
  $00 writedata

  $C0 sendCMD                            \ Power control        
  $1B writedata                           \ VRH[5:0]           

  $C1 sendCMD                            \ Power control        
  $10 writedata                           \ SAP[2:0];BT[3:0]       

  $C5 sendCMD                            \ VCM control          
  $3F writedata
  $3C writedata

  $C7 sendCMD                            \ VCM control2         
  $B7 writedata

  $36 sendCMD                            \ Memory Access Control    
  $48 writedata
  $3A sendCMD
  $55 writedata

  $B1 sendCMD
  $00 writedata
  $1B writedata

  $B6 sendCMD                            \ Display Function Control   
  $0A writedata
  $A2 writedata


  $F2 sendCMD                            \ 3Gamma Function Disable    
  $00 writedata

  $26 sendCMD                            \ Gamma curve selected     
  $01 writedata

  $E0 sendCMD                            \ Set Gamma          
  $0F writedata
  $2A writedata
  $28 writedata
  $08 writedata
  $0E writedata
  $08 writedata
  $54 writedata
  $A9 writedata
  $43 writedata
  $0A writedata
  $0F writedata
  $00 writedata
  $00 writedata
  $00 writedata
  $00 writedata

  $E1 sendCMD                            \ Set Gamma          
  $00 writedata
  $15 writedata
  $17 writedata
  $07 writedata
  $11 writedata
  $06 writedata
  $2B writedata
  $56 writedata
  $3C writedata
  $05 writedata
  $10 writedata
  $0F writedata
  $3F writedata
  $3F writedata
  $0F writedata

  $11 sendcmd                            \ Exit Sleep           
  100 ms
  $29 sendcmd                            \ Display on
  100 ms           
;

\ ----
\ Graphics primitives
\ ----




\ ----
\ 16 Bit colour values (R5 G6 B5)
\ Red   (5bit) -> Bit15-Bit11
\ Green (6bit) -> Bit10-Bit5
\ Blue  (5bit) -> Bit4-Bit0
\ ----

$0000 constant BLACK  
$001F constant BLUE   
$07E0 constant GREEN  
$F800 constant RED    
$FFFF constant WHITE  

$07FF constant CYAN   
$F81F constant MAGENTA
$FFE0 constant YELLOW 

$F7DE constant GREY   

\ *********************** add Ilya *********************

$ffff variable fgcolor
0 variable bgcolor
0 variable _x1
0 variable _x2
0 variable _y1
0 variable _y2
0 variable _xt
0 variable _yt
0 variable _radius




: filledRect ( x1 y1 x2 y2 -- )
_y2 ! _x2 ! _y1 ! _x1 !
_x1 @ _x2 @ _y1 @ _y2 @ setBounds
$2c sendcmd
_x2 @ _x1 @ - abs 1+
_y2 @ _y1 @ - abs 1+
0 do dup
	0 do fgcolor @ writedata16 loop
	loop
drop
;

\ Draw horizontal line with foreground color
: hLine ( x y len -- )
	>r			( x y len -- x y )	
    over over		( x y -- x y x y )
    swap		( x y x y -- x y y x )
    r>			( x y y x -- x y y x len )
    +			( x y y x len -- x y y x+len )
    swap		( x y y x+len -- x y x+len y )
    filledRect
;

\ Draw vertical line with foreground color
: vLine		( x y len --- )
    2>r			( x y len --- x )
    dup			( x --- x x )
    2r>			( x x --- x x y len )
    over		( x x y len --- x x y len y )
    +			( x x y len y --- x x y y+len )
    rot			( x x y y+len --- x y y+len x )
    swap		( x y y+len x --- x y x y+len )
    filledRect
;

\ Draw a rectangle with foreground color
: rect			( x1 y1 x2 y2 --- )
  >r >r >r >r
	r@ 1 rpick 2 rpick r@ - abs hLine 
	r@ 3 rpick 2 rpick r@ - abs hLine
	r@ 1 rpick 3 rpick over - abs vLine
	3 rpick rdrop r> rdrop r> over - abs vLine
;

\ Draw filled circle with foreground color
: filledCircle		( x y radius --- ) 
    _radius ! _yt ! _xt !
    1 _radius @ negate
        do
            1 _radius @ negate
            do
                i i * j j * + _radius @ _radius @ * <
                if _xt @ i + _yt @ j + i negate 2* hLine
                   _xt @ i + _yt @ j - i negate 2* hLine
                   leave
                then
            loop
        loop
;

0 variable dx
0 variable dy
0 variable grerror

: pixel fgcolor @ putpixel ;

: _circle0
_xt @ dx @ - _yt @ dy @ - pixel
                _xt @ dy @ - _yt @ dx @ - pixel
                _xt @ dy @ + _yt @ dx @ - pixel
                _xt @ dx @ + _yt @ dy @ - pixel
                _xt @ dx @ - _yt @ dy @ + pixel
                _xt @ dy @ - _yt @ dx @ + pixel
                _xt @ dy @ + _yt @ dx @ + pixel
                _xt @ dx @ + _yt @ dy @ + pixel
0 grerror @ >
                if
                    grerror @ dx @ 4 * 6 + + grerror !
                else
                    grerror @ dx @ dy @ - 4 * 10 + + grerror !
                    dy @ 1- dy !
                then                
;

\ Draw a circle with foreground color
: circle		( x y radius --- )
    _radius ! _yt ! _xt !
    _radius @ 0 <>
    if
        0 dx !
        _radius @ dy !
        3 _radius @ 2 * - grerror !
            begin
            dy @ dx @ >
            while
                _circle0
                
                dx @ 1+ dx !
            repeat
    then
;

\ Swap the value of two variables
: swapVars		( v1addr v2addr --- )
    over over 		( v1addr v2addr --- v1addr v2addr v1addr v2addr )
    @                   ( v1addr v2addr v1addr v2addr --- v1addr v2addr v1addr v2 )
    swap @		( v1addr v2addr v1addr v2 --- v1addr v2addr v2 v1 )
    >r			( v1addr v2addr v2 v1 --- v1addr v2addr v2 )
    rot			( v1addr v2addr v2 --- v2addr v2 v1addr )
    !			( v2addr v2 v1addr --- v2addr )
    r>			( v2addr --- v2addr v1 ) 
    swap		( v2addr v1 --- v1 v2addr ) 
    !			( v1 v2addr --- )
;

0 variable steep
0 variable derror

\ Draw line with foreground color
: line			( x1 y1 x2 y2 --- )
    _y2 ! _x2 ! _y1 ! _x1 !
    _y2 @ _y1 @ - abs _x2 @ _x1 @ - abs > steep !
    steep @
    if
        _x1 _y1 swapVars
        _x2 _y2 swapVars
    then
    _x1 @ _x2 @ >
    if
        _x1 _x2 swapVars
        _y1 _y2 swapVars
    then
    _y2 @ _y1 @ - abs derror !
    _y1 @ _y2 @ >
    if
        -1 dy !
    else
         1 dy !
    then
    _x2 @ _x1 @ - dx !
    dx @ 1 rshift grerror !
    _y1 @ _yt !
    _x2 @ 1+ _x1 @ 
    do
        steep @
        if
           _yt @ i pixel
        else
            i _yt @ pixel
        then
        grerror @ derror @ - grerror !
        grerror @ 0<
        if
            dy @ _yt +!
            dx @ grerror +!
        then
    loop
;

\ Storage for graphics cursor
0 variable cursorX
0 variable cursorY

: moveCursor		( x y --- )
  cursorY !
  cursorX !
;

\ Draw a line to the given location from the position of the graphics cursor
\ then update the cursor's position with the new location
: lineTo		( x y --- )
    2>r
    cursorX @ cursorY @ 2r> 
    over over cursorY ! cursorX !
    line
;


\ Font structure
0
4 -- .fwidth
4 -- .fheight
4 -- .cellsperchar
4 -- .rowspercell
constant /font

    
0 variable FWIDTH
0 variable FHEIGHT
0 variable CELLSPERCHAR
0 variable ROWSPERCELL
0 variable FONT

: setFont ( adr -- ) \ adr 
dup FONT !
>r
r@ .fwidth @ FWIDTH !
r@ .fheight @ FHEIGHT !
r@ .cellsperchar @ CELLSPERCHAR !
r> .rowspercell @ ROWSPERCELL !
;


\ Return cell at offset into font specified on the stack
: font@				( offset --- cell ) 
   cells FONT @ /font + + @ 
;
\ Render a row of font data
: renderFontCol			( font_row_data --- )
    FHEIGHT ( FWIDTH) @ 0  	\ For all bits of font row data 
    do 
        dup			( font_row_data --- font_row_data font_row_data )
        \ Create bitmask for individual bit
        1 i lshift and
        if			\ If bit set
           fgcolor @ writedata16
        else		\ If bit not set
           bgColor @ writedata16
        then
    \    -1 
    loop
    drop
;

\ Print a character from the font
: _printChar			( c --- )
    \ Calculate start of char data in font
     $20 - CELLSPERCHAR @ *	( c --- offset )
    
    \ Set bounds around char
    cursorX @  dup FWIDTH @ \ 1-
 + cursorY @ dup FHEIGHT @  1- + setBounds
 $2c sendcmd
    CELLSPERCHAR @ 0 \ For all rows of font char data
    do
        dup			( offset --- offset offset )
	i  +			( offset offset --- offset offset+i ) 
        font@			( offset offset+i --- offset font_row_data )
        ROWSPERCELL @ 1 =		\ One row per cell ?
    if			\ Yes
            renderFontCol
	else			\ No
            dup 		( offset font_row_data --- offset font_row_data font_row_data )
            8 rshift renderFontCol
            $FF and  renderFontCol
	then
    loop drop
;

: setXY
FHEIGHT @ * cursorY !
FWIDTH  @ * cursorX !
;
\ Print a character from the font
: printChar			( c x y --- )
	setXY
        _printChar
;

: lcd-emit ( c -- )
_printChar
FWIDTH @ cursorX +!
;

: lcd-type ( adr n -- )
over + swap ?do i c@ lcd-emit loop
;


