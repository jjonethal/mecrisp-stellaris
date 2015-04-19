\ Fill the screen with random 'snow'
\ requires gd2.fs

: randrange ( u0 -- u1 ) NVIC_ST_CURRENT_R @ swap u/mod drop ; \ u1 is a random number less than u0
: random ( -- x ) NVIC_ST_CURRENT_R @ $FFFF and NVIC_ST_CURRENT_R @ 16 lshift or ;

: snow ( -- )
    GD.init

    \ Start free running Systick timer for random number generation
    0 NVIC_ST_CTRL_R !
    $00FFFFFF NVIC_ST_RELOAD_R !
    0 NVIC_ST_CURRENT_R !
    %101 NVIC_ST_CTRL_R !

    GD.L8 480 272 GD.BitmapLayout
    GD.NEAREST GD.BORDER GD.BORDER 0 0 GD.BitmapSize

    0 $40000 GD.cmd_memwrite
    $10000 0 do
        random GD.c
    loop

    begin
        $40000 480 272 * - randrange GD.BitmapSource
        GD.Clear
        GD.BITMAPS GD.Begin
        0 0 0 0 GD.Vertex2ii
        240 136 31 GD.OPT_CENTER s" snow" GD.cmd_text
        GD.swap
    key? until
;
