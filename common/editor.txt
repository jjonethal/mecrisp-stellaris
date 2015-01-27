\ Memory block editor for Mecrisp-Stellaris, Copyright (C) 2014  Matthias Koch
\ This is free software under GNU General Public License v3.

( Terminal handling routines )

: u.base10 ( u -- ) base @ decimal swap 0 <# #s #> type base ! ;
: ESC[ ( -- ) 27 emit 91 emit ;
: at-xy ( column row -- ) 1+ swap 1+ swap ESC[ u.base10 ." ;" u.base10 ." H" ;
: page ESC[ ." 2J" 0 0 at-xy ;

( Editor variables and settings )

64 constant columns  ( 64x16 is most common, 40x25 is found sometimes )
16 constant rows     ( You can set something like 128x1 for line editing )

0 variable editor-buffer
char i variable mode
0 variable x
0 variable y

( Small drawing helpers )

: border ( -- )
  0 1 at-xy
  columns 2+ 0 do [char] - emit loop cr
  rows 0 do ." |" columns spaces ." |" cr loop
  columns 2+ 0 do [char] - emit loop cr ;

: mode. columns 1- 0 at-xy mode @ emit ;
: memory. 0 0 at-xy ." Memory at: " editor-buffer @ hex. ;
: header ( -- ) memory. mode. ;

( Buffer manipulation helpers )

: where ( x y -- c-addr ) columns * + editor-buffer @ + ;
: where-cursor ( -- c-addr ) x @ y @ where ; \ Find buffer location for given x,y
: eol ( -- c-addr ) columns 1- y @ where ;

( Unicode helpers )

: count-%10-addr ( addr -- u ) \ How many %10... are in this line ?
  0 columns 0 do  over i + c@ %11000000 and %10000000 = if 1+ then loop nip ;

: count-%10-to-cursor ( -- u ) \ How many %10... are there up to the cursor position ?
  0 x @ 1+ 0 do  i y @ where c@ %11000000 and %10000000 = if 1+ then loop ;

: utf8-character-length ( c -- c u )
  dup %11000000 and %11000000 = if dup 24 lshift not clz else 1 then ;

: utf8-eol? ( -- ? ) x @ where-cursor c@ utf8-character-length nip +  columns >= ;

( Line writing helpers )

: row ( addr -- addr+columns ) dup columns type dup count-%10-addr spaces columns + ;
: character-x ( -- u ) x @ count-%10-to-cursor - ;
: cursor ( -- ) character-x 1+ y @ 2 + at-xy ;
: redraw-line ( -- ) 1 y @ 2+ at-xy 0 y @ where row drop cursor ;

( Editor Movements )

: boundX ( -- ) x @ 0 max x ! ; \ Cannot simply use columns-1 as bound for UTF-8
: boundY ( -- ) y @ 0 max rows 1- min y ! ;
: bounds ( -- ) boundX boundY ;
: left   ( -- ) begin -1 x +!  where-cursor c@ %11000000 and %10000000 <> until bounds ;
: right  ( -- ) utf8-eol? not if x @ where-cursor c@ utf8-character-length nip + x ! then ;
: up     ( -- ) character-x   -1 y +! bounds 0 x !   0 ?do right loop  ;
: down   ( -- ) character-x    1 y +! bounds 0 x !   0 ?do right loop  ;
: flushleft ( -- ) 0 x ! ;

: utf8-eol  ( -- ) flushleft begin right utf8-eol? until ;
: gotoeol   ( -- ) utf8-eol begin where-cursor c@ 32 = x @ 0 <> and while left repeat
                   where-cursor c@ 32 <> if right then ;

: previousline ( -- ) y @ 0<> if up utf8-eol then ;
: nextline ( -- ) y @ rows 1- < if flushleft down then ;
: next ( -- ) utf8-eol? if redraw-line nextline else right then ;

: left-wrap  ( -- ) x @ 0 = if previousline else left then ;
: right-wrap ( -- ) utf8-eol? if nextline else right then ;

( Editor Insert/Replace Text )

: openright ( -- )
  \ If there is an Unicode continuation byte, replace the complete trailing Unicode bytes sequence with spaces.
  columns 1- y @ where
  dup c@ %11000000 and %10000000 <>
  if drop
  else
    ( addr ) \ Save this and move address backward until the %11... byte appears.
    begin 32 over c! 1- dup c@ %11000000 and %11000000 = until 32 swap c!
 then
 where-cursor dup 1+ columns 1- x @ - move ;  \ Move the rest of the line right one character

: inserting? ( -- ? ) mode @ [char] i = ;
: togglemode ( -- ) inserting? if [char] o mode ! else [char] i mode ! then mode. ;

: character ( c -- )
    \ Drop Byte sequence if this is start of an Unicode character that won't fit anymore at current position.
  utf8-character-length x @ + columns 1+ >= if utf8-character-length 1- 0 ?do key drop loop drop exit then
    \ Open a gap for the whole Unicode byte sequence
  inserting? if utf8-character-length 0 do openRight loop then
    \ Insert the character or the complete Unicode byte sequence
  utf8-character-length 0 do i 0<> if key then where-cursor i + c! loop
  next ;

( Editor Backspace/Delete )

: del ( -- ) where-cursor dup 1+ swap columns 1- x @ - move ;
: delete ( -- ) where-cursor c@ utf8-character-length nip 0 do del 32 eol c! loop ;
: backspace ( -- ) x @ 0 > if left delete then ;

( Editor Return )

: return ( -- ) y @ rows 1- <> if ( inserting? if splitline then ) nextline cursor then ;

( Editor )

: editor ( Address -- )
  editor-buffer !                   \ Save address to edit
  page header border                \ Draw outline
  rows 0 do i y ! redraw-line loop  \ Print contents of the buffer
  0 x ! 0 y ! cursor                \ Show cursor and start to edit

  begin
    key
    dup 32 >=
    if character redraw-line
    else
      case \ Handle control characters
         8 of backspace redraw-line endof
         9 of 8 0 do right loop cursor endof \ Tab
        10 of return endof
        13 of return endof
        17 of 0 rows 3 + at-xy rdrop exit endof \ Ctrl+Q: Set cursor at the end of the editor window on exit.
        27 of
             key 91 = if \ Esc [ means CSI Sequence
                        key case
                              50 of key 126 = if togglemode then endof
                              51 of key 126 = if delete redraw-line then endof
                              65 of up endof
                              66 of down endof
                              67 of right-wrap endof
                              68 of left-wrap endof

                              70 of gotoeol endof \ End
                              72 of flushleft endof \ Pos 1
                            endcase
                        cursor
                      then
           endof
      endcase
    then
  again
;

( Testing )

columns rows * buffer: input
input columns rows * 32 fill \ Fill with Spaces
: sq ( -- ) input editor ;
