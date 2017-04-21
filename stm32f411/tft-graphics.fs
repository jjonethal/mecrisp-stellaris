\ TFT Nucleo STM32F411
\ tft-graphics.fs
\ v1.0
\ Индикатор
\ Модель: ITDB02-3.2WD
\ HX8352
\ Ilya Abdrahimov ilya73@inbox.ru



\ compiletoflash
: _wrtData LCD_CS gpioc-low $22 wrtCmd wrtData ;

\ Draw a pixel with the foreground color
: pixel		( x y --- )
    over over 		( x y --- x y x y)
    setBounds		( x y x y --- )
    fgColor @ _wrtData
    clearBounds
    LCD_CS gpioc-high
;

0 variable _y2
0 variable _x2 
0 variable _y1
0 variable _x1
0 variable radius

\ Draw a rectangle filled with foreground color
: filledRect		( x1 y1 x2 y2 --- )
    _y2 ! _x2 ! _y1 ! _x1 !
    _x1 @ _y1 @ _x2 @ _y2 @ setBounds
    fgColor @ _wrtData
    _x2 @ _x1 @ - abs 1+
    _y2 @ _y1 @ - abs 1+
    0 do dup
      0 do 
        LCD_WR gpioc-low LCD_WR gpioc-high 
        loop
    loop 
drop
LCD_CS gpioc-high
;


\ Draw horizontal line with foreground color
: hLine		( x y len --- )
    >r			( x y len --- x y )	
    over over		( x y --- x y x y )
    swap		( x y x y --- x y y x )
    r>			( x y y x --- x y y x len )
    +			( x y y x len --- x y y x+len )
    swap		( x y y x+len --- x y x+len y )
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

0 variable y2
0 variable x2 
0 variable y1
0 variable x1
\ Draw a rectangle with foreground color
: rect			( x1 y1 x2 y2 --- )
    y2 ! x2 ! y1 ! x1 !
        x1 @ y1 @ x2 @ x1 @ - abs hLine
        x1 @ y2 @ x2 @ x1 @ - abs hLine
        x1 @ y1 @ y2 @ y1 @ - abs vLine
        x2 @ y1 @ y2 @ y1 @ - abs vLine
;


\ Draw filled circle with foreground color
: filledCircle		( x y radius --- ) 
    radius ! y1 ! x1 !
    1 radius @ negate
        do
            1 radius @ negate
            do
                i i * j j * + radius @ radius @ * <
                if x1 @ i + y1 @ j + i negate 2* hLine
                   x1 @ i + y1 @ j - i negate 2* hLine
                   leave
                then
            loop
        loop
;

0 variable dx
0 variable dy
0 variable error

: _circle0 
x1 @ dx @ - y1 @ dy @ - pixel
                x1 @ dy @ - y1 @ dx @ - pixel
                x1 @ dy @ + y1 @ dx @ - pixel
                x1 @ dx @ + y1 @ dy @ - pixel
                x1 @ dx @ - y1 @ dy @ + pixel
                x1 @ dy @ - y1 @ dx @ + pixel
                x1 @ dy @ + y1 @ dx @ + pixel
                x1 @ dx @ + y1 @ dy @ + pixel
                 0 error @ >
                if
                    error @ dx @ 4 * 6 + + error !
                else
                    error @ dx @ dy @ - 4 * 10 + + error !
                    dy @ 1- dy !
                then
;
\ Draw a circle with foreground color
: circle		( x y radius --- )
    radius ! y1 ! x1 !
    radius @ 0 <>
    if
        0 dx !
        radius @ dy !
        3 radius @ 2 * - error !
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
    y2 ! x2 ! y1 ! x1 !
    y2 @ y1 @ - abs x2 @ x1 @ - abs > steep !
    steep @
    if
        x1 y1 swapVars
        x2 y2 swapVars
    then
    x1 @ x2 @ >
    if
        x1 x2 swapVars
        y1 y2 swapVars
    then
    y2 @ y1 @ - abs derror !
    y1 @ y2 @ >
    if
        -1 dy !
    else
         1 dy !
    then
    x2 @ x1 @ - dx !
    dx @ 1 rshift error !
    y1 @ _y1 !
    x2 @ 1+ x1 @ 
    do
        steep @
        if
            _y1 @ i pixel
        else
            i _y1 @ pixel
        then
        error @ derror @ - error !
        error @ 0<
        if
            dy @ _y1 +!
            dx @ error +!
        then
    loop
;



\ Storage for graphics cursor
0 variable cursorX
0 variable cursorY

\ Setup defaults
0 cursorX !
0 cursorY !

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

compiletoram
