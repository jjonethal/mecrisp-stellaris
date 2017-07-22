\ mini-pc
\
\ main menu

\ variable conventions
\ n-... 1 word
\ d-... 2 word
\ s-... 2 words string adr + length

0 variable current-folder  \ current folder block number
0 variable current-block   

0 variable current-menu


60 60 12 * * constant hour-dial-units
60 60 *      constant minute-dial-units
60           constant second-dial-units

0 variable x-pos
0 variable y-pos

: draw-0 ( -- )
   "           "
   "    ++++   "
   "   +    +  "
   "  +    + + "
   "  +   +  + "
   "  +  +   + "
   "  + +    + "
   "   +    +  "
   "    ++++   "
   "           "
   "           "
   "           "

: draw-text ( c-str -- )  \ draw text at current position
   dup c@ swap 1+ tuck + ( -- a2 a1 )
   ?do i c@ draw-char loop ;

: clock-draw-hour-dial ( -- )
   hour 12 mod 30 * \ degree
   minute 2 / +     \ degree
   negate 90  +
   rotate fill-round-rect ;
: clock-update-dial ( -- )
   current-time-hour 15 * clock-draw-hour-dial
   current-time-minutes 6 * clock-draw-minute-dial
   current-time-seconds 6 * clock-draw-second-dial
;

:task clock parent app
  :state state-clock-off
	on-event ev-init clock-init
	  next-state state-clock-on
	end-event
  ;state
  :state state-clock-on
	on-event ev-timer    clock-update-dial end-event
	on-event ev-set-time clock-update-dial end-event
	on-event ev-redraw   clock-update-dial end-event
	on-event ev-suspend  clock-stop        end-event
	on-event ev-stop     clock-stop        end-event
  ;state
;



: main-menu ( -- )
   draw-buttons
      
  ;


: show-folder-pics ( )
   " folder-pics " block-read
   picture-block-from-folder-block block-read
   