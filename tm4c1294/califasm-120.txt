 
\ Fine tuning clock calibration for a precise frequency source
\ done in assembly for 1 MHz frequency output
\   needs basisdefinitions.txt and pll.txt

: led-on ( -- ) led-1 portn_data ! inline ;
: led-off ( -- )    0 portn_data ! inline ;

$E000E010 constant Systick-CTRL
$E000E014 constant Systick-RELOAD
$E000E018 constant Systick-CURRENT

118 constant ticks-slow
119 constant ticks-exact
120 constant ticks-fast


hex

: tack@ ( -- tack )
  [ 
     f847 h, 6d04 h,  \  str.w   r6, [r7, #-4]!
     ea5f h, 060b h,  \  movs.w  r6, fp
  ]
inline ;

: tack! ( tack -- )
  [ 
     ea5f h, 0b06 h,  \  movs.w  fp, r6
     cf40 h,          \  ldmia   r7!, {r6}
  ]
inline ;


: exact-crystal-handler ( -- )
  led-on
  [
     f51b h, 3b80 h,                 \  adds.w  fp, fp, #65536  ; 0x10000
     ebbb h, 4f0b h,                 \  cmp.w   fp, fp, lsl #16
     bf26 h,                         \  itte    cs
     f05f h, 0200 ticks-exact or h,  \  movscs.w        r2, #58 ; 0x3a
     fa1f h, fb8b h,                 \  uxthcs.w        fp, fp
     f05f h, 0200 ticks-exact or h,  \  movscc.w        r2, #59 ; 0x3b

     Systick-Reload 0 registerliteral,
     6002 h,                         \  str     r2, [r0, #0]    ; 0x00
  ]
  led-off
;

: slow-crystal-handler ( -- )
  led-on
  [
     f51b h, 3b80 h,                 \  adds.w  fp, fp, #65536  ; 0x10000
     ebbb h, 4f0b h,                 \  cmp.w   fp, fp, lsl #16
     bf26 h,                         \  itte    cs
     f05f h, 0200 ticks-slow  or h,  \  movscs.w        r2, #58 ; 0x3a
     fa1f h, fb8b h,                 \  uxthcs.w        fp, fp
     f05f h, 0200 ticks-exact or h,  \  movscc.w        r2, #59 ; 0x3b

     Systick-Reload 0 registerliteral,
     6002 h,                         \  str     r2, [r0, #0]    ; 0x00
  ]
  led-off
;

: fast-crystal-handler ( -- )
  led-on
  [
     f51b h, 3b80 h,                 \  adds.w  fp, fp, #65536  ; 0x10000
     ebbb h, 4f0b h,                 \  cmp.w   fp, fp, lsl #16
     bf26 h,                         \  itte    cs
     f05f h, 0200 ticks-fast  or h,  \  movscs.w        r2, #58 ; 0x3a
     fa1f h, fb8b h,                 \  uxthcs.w        fp, fp
     f05f h, 0200 ticks-exact or h,  \  movscc.w        r2, #59 ; 0x3b

     Systick-Reload 0 registerliteral,
     6002 h,                         \  str     r2, [r0, #0]    ; 0x00
  ]
  led-off
;

decimal


: exact-xtal ( -- ) ['] exact-crystal-handler irq-systick ! ticks-exact Systick-RELOAD !  ;
: slow-xtal  ( -- ) [']  slow-crystal-handler irq-systick ! ;
: fast-xtal  ( -- ) [']  fast-crystal-handler irq-systick ! ;

: t ( u -- ) tack! ; \ For quick clock adjustments


1000,00 2constant centerfrequency \ in kHz
 120,00 2constant tickcount

: khz ( f -- ) \ Uses measurement with exact-crystal handler to determine tack value

  centerfrequency f/ 1,0 d-  
  2dup dabs 0,0000003 d< 
  if 2drop ." Crystal almost perfect" exact-xtal
  else

  tickcount f* 1,0 2swap f/
  
  nip \ Signed Tack on Stack.

  dup 0< if   ." Crystal too slow, Tack: " slow-xtal abs dup tack! u. ( 0 tick ! )
         else ." Crystal too fast, Tack: " fast-xtal abs dup tack! u. ( 0 tick ! )
         then 
  then
  cr
;


: startf ( -- )

  120mhz \ Crystal & PLL clock source

  ['] exact-crystal-handler irq-systick !
  0 tack!
  eint

            0 Systick-CURRENT ! \ Clear Systick counter
  ticks-exact Systick-RELOAD !   \ Divider for clock
            7 Systick-CTRL !      \ System Clock, Interrupt enable, Systick enable
;

