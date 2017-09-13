\ sprite editor
\ +-------------+
\ | prev Sprite |
\ +-------------+
\ 
\ +-------------+
\ | next Sprite |
\ +-------------+
\
\ +-------------+
\ | prev Frame  |
\ +-------------+
\
\ +-------------+
\ | next Frame  |
\ +-------------+
\
\ +-------------+
\ | next Frame  |
\ +-------------+


: input-box ( a n -- )                    \ create an input box of len n 
   ;

: border-space ( -- n )                   \ border-width + frame-text-space * 2
   frame-text-space @ border-width @ + 2 * ;
: draw-button-h-line ( -- )
   x @ text-len font-width * 
   frame-text-space @ border-width @ + 2 * +
   h-line x ! ;
: draw-button-top-line ( -- )
   draw-button-h-line ;
: draw-button-bottom-line ( -- )
   y @ 
   border-space font-height +
   y ! draw-button-h-line y !  ;

: draw-button ( a -- )
   draw-button-top-line
   draw-button-buttom-line
   draw-button-left-line
   draw-button-right-line
   draw-button-text ;
: button ( s a -- )                       \ create a text button 
   ' handleButton gui-append
   gui-append
   gui-append
  ;
: nl ( -- )  ;                            \ graphics pos to next line 
: draw-grid ( ) ;
: top-left ( x y -- ) ;                   \ Top left corner
: font ( a -- ) ;                         \ set current font address 
: main ( )                                \ builds sprite editor dialog
  dialog-clear                            \ new dialog
  1 frame-text-space !                    \ 1 pixel distance from text to frame
  2 border-width !                        \ width of border 2 pixel
  2 4 + 1 + 16 + row-height !             \ 2x1 text<->border, 2x2 border 1 space 16 font
  font-mono-16x16 font !
  color-black bg !
  color-white font-color !  
  10 10 top-left
  s" Sprite Editor" dup text-h-center    label  nl
  s" prev Sprite" ' sprite-prev          button nl
  s" next Sprite" ' sprite-next          button nl
  s" prev Frame " ' sprite-frame-prev    button nl
  s" next Frame " ' sprite-frame-next    button nl
  s" Name       " label ' sprite-name-input 20 input-box nl
;