\ Conversion of the 'widgets' sample from the
\ "Gameduino 2: Tutorial, Reference and Cookbook"
\

: v2   ( x y -- )
    0 0 GD.Vertex2ii
;

200 dup constant TAG_DIAL      
1+  dup constant TAG_SLIDER    
1+  dup constant TAG_TOGGLE    
1+  dup constant TAG_BUTTON1   
1+  dup constant TAG_BUTTON2   
drop

GD.OPT_FLAT variable options
15000       variable val

40 buffer: message

: msgadd ( c -- )    \ append c to the message buffer
    message 1+ message 39 move
    message 39 + c!
;

: widgets
    GD.init
    GD.calibrate
    message 40 [char] . fill

    0   \ keep previous key on stack
    begin
        GD.getinputs
        GD.inputs.track_tag TAG_DIAL TAG_TOGGLE 1+ within if
            GD.inputs.track_val val !
        then
        dup 0= GD.inputs.tag bl 127 within and if
            GD.inputs.tag msgadd
        then
        drop GD.inputs.tag
        dup case
            TAG_BUTTON1 of  GD.OPT_FLAT options ! endof
            TAG_BUTTON2 of  0 options !           endof
        endcase

        0 0 $404044 480 480 $606068 GD.cmd_gradient

        $707070 GD.ColorRGB#

        4 16 * GD.LineWidth
        GD.RECTS GD.Begin

        8 8 v2
        128 128 v2

        8 136 8 + v2
        128 136 128 + v2

        144 136 8 + v2
        472 136 128 + v2

        $ffffff GD.ColorRGB#

        TAG_DIAL GD.Tag
        68 68 50 options @ val @ GD.cmd_dial
        68 68 1 1 TAG_DIAL GD.cmd_track

        TAG_SLIDER GD.Tag
        16 199 104 10 TAG_SLIDER GD.cmd_track 
        16 199 104 10 options @ val @ 65535 GD.cmd_slider 

        TAG_TOGGLE GD.Tag
        360 62 80 29 options @ val @ s" that|this" GD.cmd_toggle
        360 62 80 20 TAG_TOGGLE GD.cmd_track

        255 GD.Tag
        68 136 30 GD.OPT_CENTER 5 or val @ GD.cmd_number 
       
        184 48 40 options @ GD.OPT_NOSECS or 0 0 val @ 0 GD.cmd_clock 
        280 48 40 options @ 4 3 val @ 65535 GD.cmd_gauge 
       
        TAG_BUTTON1 GD.Tag 
        352 12 40 30 28 options @ s" 2D" GD.cmd_button 
        TAG_BUTTON2 GD.Tag
        400 12 40 30 28 options @ s" 3D" GD.cmd_button 
       
        255 GD.Tag 
        144 100 320 10 options @ val @ 65535 GD.cmd_progress
        144 120 320 10 options @ val @ 2/ 32768 65535 GD.cmd_scrollbar 
       
        dup options @ or GD.OPT_CENTER or >r

        144 168 320 24 28 r@ s" qwertyuiop" GD.cmd_keys 
        144 168 26 + 320 24 28 r@ s" asdfghjkl" GD.cmd_keys 
        144 168 52 + 320 24 28 r@ s" zxcvbnm,." GD.cmd_keys 
        bl GD.Tag
        308 60 - 172 74 + 120 20 28 options @ s"  " GD.cmd_button 

        r> drop
       
        GD.SRC_ALPHA 0 GD.BlendFunc 
        149 146 18 0 message 40 GD.cmd_text

        GD.swap
    again
;
