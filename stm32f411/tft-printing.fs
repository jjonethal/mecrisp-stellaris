

\ compiletoflash
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
: renderFontRow			( font_row_data --- )
   0 FWIDTH @ 1-			\ For all bits of font row data 
    do
        dup			( font_row_data --- font_row_data font_row_data )
        \ Create bitmask for individual bit
        1 i lshift and 
        if			\ If bit set
            fgColor @ _wrtData
        else		\ If bit not set
            bgColor @ _wrtData
        then
        -1
    +loop
    drop
;

\ Print a character from the font
\ This function assumes it will be nested within hwAccess functions
: lcd-emitChar			( c --- )
\ LCD_CS gpioc-low 
    \ Calculate start of char data in font
    $20 - CELLSPERCHAR @ *	( c --- offset )
    
    \ Set bounds around char
    cursorX @ cursorY @ cursorX @ FWIDTH @ 1-
 + cursorY @ FHEIGHT @ 1-  + setBounds
\ $22 wrtCmd
    CELLSPERCHAR @  0 		\ For all rows of font char data
    do
        dup			( offset --- offset offset )
		i +			( offset offset --- offset offset+i ) 
        font@			( offset offset+i --- offset font_row_data )
        ROWSPERCELL @ 1 =		\ One row per cell ?
        if			\ Yes
            renderFontRow
		else			\ No
            dup 		( offset font_row_data --- offset font_row_data font_row_data )
            8 rshift renderFontRow
            $FF and  renderFontRow
		then
    loop drop
LCD_CS gpioc-high
;

: setXY
FHEIGHT @ * cursorY !
FWIDTH @ * cursorX !
;

\ Print a character from the font
\ This function obtains hwAccess
: lcd-printChar			( c x y --- )
	setXY
   lcd-emitChar
;

: lcd-emit ( c -- )
lcd-emitChar
FWIDTH @ cursorX +!
;

: lcd-type ( adr n -- )
over + swap ?do i c@ lcd-emit loop
;
: lcd-ud.r ( n1 n -- ) >r n>s r> over - 0 ?do #32 lcd-emit loop lcd-type ;
\ : lcd-init lcd-init font16x30 setfont ;
: clrScn 0 dup cursorX ! cursorY ! clrScn ;
compiletoram
\ font20x20 setfont

\ : te s" Абдрахимов Илья" lcd-type ; 
\ : te1 20 over + swap do i lcd-emit loop ;
