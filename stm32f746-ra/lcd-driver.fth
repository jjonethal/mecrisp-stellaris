\ lcd-driver.fth
\ context
\  current-color
\  color-mode
: mask-mode ( a nr -- )
   
: GPIO-AF14 ( a nr -- ) 
   over @ over 2* tuck #3 swap lshift not rot and   
: lcd-gpio-init ( -- )
   PE4 GPIO-AF14
: lcd-init
: draw-line
: draw-rect
: move-to
: line-to
: fill-rect
: fill-area
: fill-triangle
: flip-buffer
: draw-string
: set-font
: set-color
