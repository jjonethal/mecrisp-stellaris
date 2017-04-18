\ mini-pc
\
\ main menu

\ variable conventions
\ n-... 1 word
\ d-... 2 word
\ s-... 2 words string adr + length

0 variable current-folder  \ current folder block number
0 variable current-block   

: main-menu ( -- )
: show-folder-pics ( )
   " folder-pics " block-read
   picture-block-from-folder-block block-read
   