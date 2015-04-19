\ Conversion of the 'fizz' sample from the
\ "Gameduino 2: Tutorial, Reference and Cookbook"
\

\ requires gd2.fs

: rr ( u0 -- u1 ) NVIC_ST_CURRENT_R @ swap u/mod drop ; \ u1 is a random number less than u0

: fizz ( -- )
    GD.init

    \ Start free running Systick timer for random number generation
    0 NVIC_ST_CTRL_R !
    $00FFFFFF NVIC_ST_RELOAD_R !
    0 NVIC_ST_CURRENT_R !
    %101 NVIC_ST_CTRL_R !

    begin
        GD.Clear
        GD.POINTS GD.Begin
        100 0 do
            16 50 * rr GD.PointSize
            256 rr 256 rr 256 rr GD.ColorRGB
            256 rr GD.ColorA
            480 rr 272 rr 0 0 GD.Vertex2ii
        loop
        GD.swap
    key? until
;
