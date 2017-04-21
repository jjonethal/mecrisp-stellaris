\ TFT Nucleo STM32F411
\
\ Индикатор
\ Модель: ITDB02-3.2WD
\ HX8352
\ Ilya Abdrahimov ilya73@inbox.ru

\ DB0-7  -- PB0-7
\ DB8-15 -- PC0-7
\ LCD_RS -- PC8
\ LCD_WR -- PC9
\ LCD_RD -- 3v3
\ LCD_CS -- PC10
\ LCD_RST -- PC11
\ Touch_CLK -- PH3
\ Touch_CS -- PE3
\ Touch_DIN -- PL1
\ Touch_DOUT -- PE5
\ Touch_IRQ -- PE4

\ compiletoflash
\ LCD definitions
400 constant DWIDTH
240 constant DHEIGHT

GPIOB $14 + constant LCD_DL
GPIOC $14 + constant LCD_DH
GPIOC $18 + constant GPIOC_BSRR
1 8 lshift constant LCD_RS \
1 9 lshift constant LCD_WR \
1 10 lshift constant LCD_CS \
1 11 lshift constant LCD_RST \

: gpioc-low ( n -- ) 16 lshift GPIOC_BSRR bis! ;
: gpioc-high ( n -- ) GPIOC_BSRR bis! ;

: lcd-gpio-init
3 RCC_AHB1ENR bis!	\ enable gpiob & gpioc
$5555 gpiob ! 
$555555 gpioc bis!	\ output
;



: lcd-write-bus ( nd -- )
dup $ff and
LCD_DL c!
$ff00 and 8 rshift
LCD_DH c!
LCD_WR gpioc-low LCD_WR gpioc-high
;

: wrtCmd ( n -- )
LCD_RS gpioc-low \ 
lcd-write-bus
;

: wrtData ( n -- )
LCD_RS gpioc-high \
lcd-write-bus
;

: lcd-write-comdata ( com data -- )
 LCD_CS gpioc-low swap wrtCmd wrtData LCD_CS gpioc-high 
;

: wrtCmdData ( data com -- )
LCD_CS gpioc-low wrtCmd wrtData LCD_CS gpioc-high
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

\  Сменить ориентацию LCD, портрет/альбом
: lcd-change-direction ( n -- )  \ n = 0 - портретная, 1 - альбомная
if $bc else $1c then
$16 wrtCmdData
;

: hip> $ff00 and 8 rshift ;

\ Set the bounds within the GDDRAM of where to write data
: setBounds 		( x1 y1 x2 y2 --- )

	dup hip> $8 wrtCmdData	\ y2
	$ff and  $9 wrtCmdData	

	dup hip> $4 wrtCmdData	\ x2
	$ff and  $5 wrtCmdData	

	dup hip> $6 wrtCmdData	\ y1
	$ff and  $7 wrtCmdData

	dup hip> $2 wrtCmdData	\ x1
	$ff and  $3 wrtCmdData	
    $22 wrtCmd
;

\ Clear the GDDRAM window
: clearBounds	( --- )
    0 0 DWIDTH 1- DHEIGHT 1- setBounds
;


: lcd-init
lcd-gpio-init


LCD_CS gpioc-high \ 
LCD_RS gpioc-high \ 
LCD_WR gpioc-high \ 

LCD_RS gpioc-high \ 
LCD_RST gpioc-high \
5 ms
LCD_RST gpioc-low \ 
15 ms
LCD_RST gpioc-high \
15 ms



\ LCD_Write_COM(0x83);           

\		LCD_Write_DATA(0x02);  //TESTM=1 
$83 $2 lcd-write-comdata
$85 $3 lcd-write-comdata
$8b $1 lcd-write-comdata
$8c $93 lcd-write-comdata
$91 $1 lcd-write-comdata
$83 $0 lcd-write-comdata
\		//Gamma Setting
$3e $b0 lcd-write-comdata
$3f $3 lcd-write-comdata
$40 $10 lcd-write-comdata
$41 $56 lcd-write-comdata
$42 $13 lcd-write-comdata
$43 $46 lcd-write-comdata
$44 $23 lcd-write-comdata
$45 $76 lcd-write-comdata
$46 $0 lcd-write-comdata
$47 $5e lcd-write-comdata
$48 $4f lcd-write-comdata
$49 $40 lcd-write-comdata
\		//**********Power On sequence************
        
$17 $91 lcd-write-comdata
$2b $f9 lcd-write-comdata

10 ms

$1b $14 lcd-write-comdata
$1a $11 lcd-write-comdata
$1c $6 lcd-write-comdata
$1f $42 lcd-write-comdata       

20 ms
        
$19 $a lcd-write-comdata
$19 $1a lcd-write-comdata

40 ms       
        
$19 $12 lcd-write-comdata

40 ms
        
$1e $27 lcd-write-comdata
100 ms
        
\		//**********DISPLAY ON SETTING***********
        

$24 $60 lcd-write-comdata
$3d $40 lcd-write-comdata
$34 $38 lcd-write-comdata
$35 $38 lcd-write-comdata
$24 $38 lcd-write-comdata

40 ms
        
$24 $3c lcd-write-comdata
$16 $1c lcd-write-comdata
$1 $6 lcd-write-comdata
$55 $0 lcd-write-comdata
$2 $0 lcd-write-comdata
$3 $0 lcd-write-comdata
$4 $0 lcd-write-comdata
$5 $ef lcd-write-comdata
$6 $0 lcd-write-comdata
$7 $0 lcd-write-comdata
$8 $1 lcd-write-comdata
$9 $8f lcd-write-comdata
$22 wrtCmd
1 lcd-change-direction
clearBounds
\ Set foreground and background colors to defaults
    255 255 255 pixelColor setFGColor	\ White
      0   0   0 pixelColor setBGColor	\ Black
LCD_CS gpioc-high
;


\ Fill the LCD screen with foreground color
: fillScn 		(  --- ) 
    \ Obtain exclusive access to all hardware I/O    
        clearBounds
LCD_CS gpioc-low
 $22 wrtCmd
         fgColor @ wrtData
        DHEIGHT 0 do
            DWIDTH 0 do 
			LCD_WR gpioc-low LCD_WR gpioc-high
            loop
        loop 
        LCD_CS gpioc-high
    \ Release exclusive access to all hardware I/O    
;

\ Clear the screen to background color
: clrScn		( --- )
    fgColor @ >r bgColor @ fgColor !
    fillScn
    r> fgColor !
;
\ ----
\ 16 Bit colour values (R5 G6 B5)
\ Red   (5bit) -> Bit15-Bit11
\ Green (6bit) -> Bit10-Bit5
\ Blue  (5bit) -> Bit4-Bit0
\ ----

$0000 constant BLACK  
$001F constant BLUE   
$07E0 constant GREEN  
$F400 constant RED    
$FFFF constant WHITE  

$07FF constant CYAN   
$F81F constant MAGENTA
$FFE0 constant YELLOW 
compiletoram
\ $F7DE constant GREY   
