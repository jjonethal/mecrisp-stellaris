\ GD library: FT800 Forth interface
\
\ Assumes a 32-bit ANS Forth plus the following:
\
\ gd2-spi-init  ( -- )  initialize SPI and GD select signal
\ gd2-sel               assert the GD2 SPI select signal
\ gd2-unsel             deassert the GD2 SPI select signal
\ spi>      ( x -- )    send a byte to SPI
\ >spi      ( -- x )    receive a byte from SPI
\ uw@       ( a -- x )  unsigned 16-bit fetch
\ w@        ( a -- n )  signed 16-bit fetch
\


\ -----------------------------------------------------------------------------
\   --- Some general additions to Mecrisp-Stellaris ---
\ -----------------------------------------------------------------------------

: reset ( -- ) $5FA0004 $E000ED0C ! ;

: sign16 ( s16 -- n ) [ $b236 h, ] inline ; \ sxth r6, r6 Opcode

: uw@ ( addr -- x ) h@ inline ;
:  w@ ( addr -- x ) h@ sign16 inline ;

\ Adjust the character string at c-addr1 by n characters. The resulting
\ character string, specified by c-addr2 u2, begins at c-addr1 plus 
\ n characters and is u1 minus n characters long. 

: /string ( c-addr1 u1 n -- c-addr2 u2 ) dup >r - swap r> + swap ;

: off ( a-addr -- ) 0 swap ! ;

: char+ 1 + inline 1-foldable ;

: within ( test low high -- flag ) over - >r - r>  u< ;

\ -----------------------------------------------------------------------------
\   --- Target specific parts ---
\ -----------------------------------------------------------------------------

\ Delay with Systick-Timer

$E000E010 constant NVIC_ST_CTRL_R
$E000E014 constant NVIC_ST_RELOAD_R      
$E000E018 constant NVIC_ST_CURRENT_R

: delay-ticks ( ticks -- ) \  Tick = 1 / 16 MHz = 62.5 ns
  %101 NVIC_ST_CTRL_R !     \ Enable SysTick with core clock
  NVIC_ST_RELOAD_R !         \ Store the number of ticks desired as the reload value 
  0 NVIC_ST_CURRENT_R !       \ restart the time from tick count
  begin $10000 NVIC_ST_CTRL_R bit@ until
;

: us ( us -- ) 16 * delay-ticks ;
: ms ( ms -- ) 0 ?do 16000 delay-ticks loop ;

\ --------------------------------------------------------------
\  Connections of Gameduino 2 to Pins of Nucleo STM32F401 board
\ --------------------------------------------------------------
\
\ Arduino Gameduino STM-Nucleo
\
\    D2        INT       PA10
\    D8    GPU SEL       PA9
\    D9     SD SEL       PC7
\   D11       MOSI       PA7 with AF05: SPI1_MOSI
\   D12       MISO       PA6 with AF05: SPI1_MISO
\   D13        SCK       PA5 with AF05: SPI1_SCK
\
\    A0     Accl X       PA0
\    A1     Accl Y       PA1
\    A2     Accl Z       PA4
\

\ --------------------------------------------------------------
\ Register definitions for STM
\ --------------------------------------------------------------

$40023800 constant RCC_BASE
RCC_BASE $44 + constant RCC_APB2ENR

$40020000 constant PORTA_Base
$40020800 constant PORTC_Base

PORTA_BASE $00 + constant PORTA_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTA_BASE $04 + constant PORTA_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTA_BASE $08 + constant PORTA_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTA_BASE $0C + constant PORTA_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTA_BASE $10 + constant PORTA_IDR      \ RO      Input Data Register
PORTA_BASE $14 + constant PORTA_ODR      \ Reset 0 Output Data Register
PORTA_BASE $18 + constant PORTA_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTA_BASE $20 + constant PORTA_AFRL     \ Reset 0 Alternate function  low register
PORTA_BASE $24 + constant PORTA_AFRH     \ Reset 0 Alternate function high register

PORTC_BASE $00 + constant PORTC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTC_BASE $04 + constant PORTC_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
PORTC_BASE $08 + constant PORTC_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
PORTC_BASE $0C + constant PORTC_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
PORTC_BASE $10 + constant PORTC_IDR      \ RO      Input Data Register
PORTC_BASE $14 + constant PORTC_ODR      \ Reset 0 Output Data Register
PORTC_BASE $18 + constant PORTC_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
        \ +$1C                                     ... is Lock Register, unused
PORTC_BASE $20 + constant PORTC_AFRL     \ Reset 0 Alternate function  low register
PORTC_BASE $24 + constant PORTC_AFRH     \ Reset 0 Alternate function high register

\ SPI hardware not in use.
\ $40013000 constant SPI1_Base \ On APB2
\ SPI1_Base $00 + constant SPI1_CR1
\ SPI1_Base $04 + constant SPI1_CR2
\ SPI1_Base $08 + constant SPI1_SR
\ SPI1_Base $0C + constant SPI1_DR
\ SPI1_Base $10 + constant SPI1_CRCPR
\ SPI1_Base $14 + constant SPI1_RXCRCR
\ SPI1_Base $18 + constant SPI1_TXCRCR
\ SPI1_Base $1C + constant SPI1_I2SCFGR
\ SPI1_Base $20 + constant SPI1_I2SPR

1 9 lshift constant gd2-select
1 7 lshift constant sd-select

: gd2-sel   ( -- ) gd2-select 16 lshift porta_bsrr ! ; \ Assuming positive logic
: gd2-unsel ( -- ) gd2-select           porta_bsrr ! ;

: sd-sel    ( -- ) sd-select  16 lshift portc_bsrr ! ;
: sd-unsel  ( -- ) sd-select            portc_bsrr ! ;

\ Primitives for SPI bit-banging

1 5 lshift constant spi-sck
1 6 lshift constant spi-miso
1 7 lshift constant spi-mosi

: sck-high  ( -- ) spi-sck            porta_bsrr ! ;
: sck-low   ( -- ) spi-sck  16 lshift porta_bsrr ! ;
: mosi-high ( -- ) spi-mosi           porta_bsrr ! ;
: mosi-low  ( -- ) spi-mosi 16 lshift porta_bsrr ! ;

: miso ( -- ? ) spi-miso porta_idr bit@ ;


: gd2-spi-init ( -- )
  \ 1 12 lshift RCC_APB2ENR bis! \ Enable clock for SPI1 module

  \ Select pins as outputs and deselect
  %01 9 2* lshift porta_moder bis!  \ Set GPU Select pin as output
  %01 7 2* lshift portc_moder bis!  \ Set SD  Select pin as output
  gd2-unsel sd-unsel

  \ Select alternate function of Pins for SPI
  \ $55500000 porta_afrl bis! \ Set Alternate Function 5 for all three SPI communication pins

  \ Configure the SPI peripheral - see Reference Manual and check for correct clock polarity !
 
  \ Do line initialisation for bit-bang instead.
  
  %01 5 2* lshift porta_moder bis!  \ Set SCK pin as output
  %01 7 2* lshift porta_moder bis!  \ Set MOSI pin as output
  sck-low                           \ MISO is input after Reset

  \ Finished.
;

: bit-spix ( ? -- ? )
  \ dup if ." h" else ." l" then
  if mosi-high else mosi-low then 
  sck-high
  miso
  sck-low  
  \ dup if ." H" else ." L" then
;

: spix ( x -- x ) $FF and

    dup 128 and bit-spix if 128 or else 128 bic then
    dup 64 and bit-spix if 64 or else 64 bic then
    dup 32 and bit-spix if 32 or else 32 bic then
    dup 16 and bit-spix if 16 or else 16 bic then

    dup 8 and bit-spix if 8 or else 8 bic then
    dup 4 and bit-spix if 4 or else 4 bic then
    dup 2 and bit-spix if 2 or else 2 bic then
    dup 1 and bit-spix if 1 or else 1 bic then
;

: >spi ( x -- ) spix drop ;
: spi> ( -- x ) 0 spix ;

\ -----------------------------------------------------------------------------
\   --- Gameduino 2 Library ---
\ -----------------------------------------------------------------------------

\ Board-configuration options
\ ---------------------------
\
\ PCB_CRYSTAL is true if the FT800 is using an external
\ crystal.
\ PCB_SWIZZLE specifies the RGB signal swapping.
\
\ For a Gameduino2 use:
\
\ 0 constant PCB_CRYSTAL
\ 3 constant PCB_SWIZZLE
\
\ For other FT800/801 boards (e.g. FTDI's modules) use:
\
\ 1 constant PCB_CRYSTAL
\ 0 constant PCB_SWIZZLE
\

0 constant PCB_CRYSTAL
3 constant PCB_SWIZZLE

hex

\ FT800 is an SPI peripheral controlled by reads and writes
\ into its internal 24-bit address space.

\ Hardware registers

00102400 constant GD.REG_ID
00102404 constant GD.REG_FRAMES
00102408 constant GD.REG_CLOCK
0010240c constant GD.REG_FREQUENCY
0010241c constant GD.REG_CPURESET
00102428 constant GD.REG_HCYCLE
0010242c constant GD.REG_HOFFSET
00102430 constant GD.REG_HSIZE
00102434 constant GD.REG_HSYNC0
00102438 constant GD.REG_HSYNC1
0010243c constant GD.REG_VCYCLE
00102440 constant GD.REG_VOFFSET
00102444 constant GD.REG_VSIZE
00102448 constant GD.REG_VSYNC0
0010244c constant GD.REG_VSYNC1
00102450 constant GD.REG_DLSWAP
00102454 constant GD.REG_ROTATE
00102458 constant GD.REG_OUTBITS
0010245c constant GD.REG_DITHER
00102460 constant GD.REG_SWIZZLE
00102464 constant GD.REG_CSPREAD
00102468 constant GD.REG_PCLK_POL
0010246c constant GD.REG_PCLK
00102470 constant GD.REG_TAG_X
00102474 constant GD.REG_TAG_Y
00102478 constant GD.REG_TAG
0010247c constant GD.REG_VOL_PB
00102480 constant GD.REG_VOL_SOUND
00102484 constant GD.REG_SOUND
00102488 constant GD.REG_PLAY
0010248c constant GD.REG_GPIO_DIR
00102490 constant GD.REG_GPIO
00102498 constant GD.REG_INT_FLAGS
0010249c constant GD.REG_INT_EN
001024a0 constant GD.REG_INT_MASK
001024a4 constant GD.REG_PLAYBACK_START
001024a8 constant GD.REG_PLAYBACK_LENGTH
001024ac constant GD.REG_PLAYBACK_READPTR
001024b0 constant GD.REG_PLAYBACK_FREQ
001024b4 constant GD.REG_PLAYBACK_FORMAT
001024b8 constant GD.REG_PLAYBACK_LOOP
001024bc constant GD.REG_PLAYBACK_PLAY
001024c0 constant GD.REG_PWM_HZ
001024c4 constant GD.REG_PWM_DUTY
001024c8 constant GD.REG_MACRO_0
001024cc constant GD.REG_MACRO_1
001024e4 constant GD.REG_CMD_READ
001024e8 constant GD.REG_CMD_WRITE
001024ec constant GD.REG_CMD_DL
001024f0 constant GD.REG_TOUCH_MODE
001024f4 constant GD.REG_TOUCH_ADC_MODE
001024f8 constant GD.REG_TOUCH_CHARGE
001024fc constant GD.REG_TOUCH_SETTLE
00102500 constant GD.REG_TOUCH_OVERSAMPLE
00102504 constant GD.REG_TOUCH_RZTHRESH
00102508 constant GD.REG_TOUCH_RAW_XY
0010250c constant GD.REG_TOUCH_RZ
00102510 constant GD.REG_TOUCH_SCREEN_XY
00102514 constant GD.REG_TOUCH_TAG_XY
00102518 constant GD.REG_TOUCH_TAG
0010251c constant GD.REG_TOUCH_TRANSFORM_A
0010256c constant GD.REG_TRIM
00102574 constant GD.REG_TOUCH_DIRECT_XY
00102578 constant GD.REG_TOUCH_DIRECT_Z1Z2
00109000 constant GD.REG_TRACKER

\ Graphics definitions

00000001 constant GD.BITMAPS
00000002 constant GD.POINTS
00000003 constant GD.LINES
00000004 constant GD.LINE_STRIP
00000005 constant GD.EDGE_STRIP_R
00000006 constant GD.EDGE_STRIP_L
00000007 constant GD.EDGE_STRIP_A
00000008 constant GD.EDGE_STRIP_B
00000009 constant GD.RECTS

00000000 constant GD.NEVER
00000001 constant GD.LESS
00000002 constant GD.LEQUAL
00000003 constant GD.GREATER
00000004 constant GD.GEQUAL
00000005 constant GD.EQUAL
00000006 constant GD.NOTEQUAL
00000007 constant GD.ALWAYS

00000000 constant GD.NEAREST
00000001 constant GD.BILINEAR

00000000 constant GD.BORDER
00000001 constant GD.REPEAT

00000000 constant GD.ARGB1555
00000001 constant GD.L1
00000002 constant GD.L4
00000003 constant GD.L8
00000004 constant GD.RGB332
00000005 constant GD.ARGB2
00000006 constant GD.ARGB4
00000007 constant GD.RGB565
00000008 constant GD.PALETTED
00000009 constant GD.TEXT8X8
0000000a constant GD.TEXTVGA
0000000b constant GD.BARGRAPH

00000002 constant GD.SRC_ALPHA
00000003 constant GD.DST_ALPHA
00000004 constant GD.ONE_MINUS_SRC_ALPHA
00000005 constant GD.ONE_MINUS_DST_ALPHA

00000000 constant GD.ADC_SINGLE_ENDED
00000001 constant GD.ADC_DIFFERENTIAL

\ 00000000 constant GD.DLSWAP_DONE
\ 00000001 constant GD.DLSWAP_LINE
\ 00000002 constant GD.DLSWAP_FRAME

\ 00000020 constant GD.INT_CMDEMPTY
\ 00000040 constant GD.INT_CMDFLAG
\ 00000080 constant GD.INT_CONVCOMPLETE
\ 00000010 constant GD.INT_PLAYBACK
\ 00000008 constant GD.INT_SOUND
\ 00000001 constant GD.INT_SWAP
\ 00000004 constant GD.INT_TAG
\ 00000002 constant GD.INT_TOUCH

00000001 constant GD.KEEP
00000002 constant GD.REPLACE
00000003 constant GD.INCR
00000004 constant GD.DECR
00000005 constant GD.INVERT

\ System register values
00000000 constant GD.LINEAR_SAMPLES
00000001 constant GD.ULAW_SAMPLES
00000002 constant GD.ADPCM_SAMPLES

\ Options for commands
0600 constant GD.OPT_CENTER
0200 constant GD.OPT_CENTERX
0400 constant GD.OPT_CENTERY
0100 constant GD.OPT_FLAT
0001 constant GD.OPT_MONO
1000 constant GD.OPT_NOBACK
0002 constant GD.OPT_NODL
c000 constant GD.OPT_NOHANDS
4000 constant GD.OPT_NOHM
4000 constant GD.OPT_NOPOINTER
8000 constant GD.OPT_NOSECS
2000 constant GD.OPT_NOTICKS
0800 constant GD.OPT_RIGHTX
0100 constant GD.OPT_SIGNED

\ 'instrument' argument to GD.play

00 constant GD.SILENCE              
01 constant GD.SQUAREWAVE           
02 constant GD.SINEWAVE             
03 constant GD.SAWTOOTH             
04 constant GD.TRIANGLE             
05 constant GD.BEEPING              
06 constant GD.ALARM                
07 constant GD.WARBLE               
08 constant GD.CAROUSEL             
40 constant GD.HARP                 
41 constant GD.XYLOPHONE            
42 constant GD.TUBA                 
43 constant GD.GLOCKENSPIEL         
44 constant GD.ORGAN                
45 constant GD.TRUMPET              
46 constant GD.PIANO                
47 constant GD.CHIMES               
48 constant GD.MUSICBOX             
49 constant GD.BELL                 
50 constant GD.CLICK                
51 constant GD.SWITCH               
52 constant GD.COWBELL              
53 constant GD.NOTCH                
54 constant GD.HIHAT                
55 constant GD.KICKDRUM             
56 constant GD.POP                  
57 constant GD.CLACK                
58 constant GD.CHACK                
60 constant GD.MUTE                 
61 constant GD.UNMUTE               
: GD.PIPS 0f + ;

00108000 constant GD.RAM_CMD
00100000 constant GD.RAM_DL
00102000 constant GD.RAM_PAL

00000000 constant GD.TOUCHMODE_OFF
00000001 constant GD.TOUCHMODE_ONESHOT
00000002 constant GD.TOUCHMODE_FRAME
00000003 constant GD.TOUCHMODE_CONTINUOUS

decimal

\ #######   INTERFACE   #######################################

: GD.a  ( a -- ) \ start SPI read transaction, 24-bit address a
    gd2-sel
    dup 16 rshift >spi
    dup 8 rshift >spi
    dup >spi
    >spi      \ dummy
;

: GD.wa  ( a -- ) \ SPI write transaction, 24-bit address a
    gd2-sel
    dup 16 rshift 128 or >spi
    dup 8 rshift >spi
    >spi
;

\ Low-level FT800 memory access words
: GD.c@ ( addr -- x )
    GD.a
    spi>
    gd2-unsel
;

: GD.@ ( addr -- x )
    GD.a
    spi>
    spi> 8 lshift or
    spi> 16 lshift or
    spi> 24 lshift or
    gd2-unsel
;

: GD.move   ( caddr u a -- ) \ copy u bytes to caddr from GD memory a
    GD.a
    over + swap do
        spi> i c!
    loop
    gd2-unsel
;

: GD.c! ( addr -- x )
    GD.wa
    >spi
    gd2-unsel
;

: GD.! ( addr -- x )
    GD.wa
    4 0 do
        dup >spi
        8 rshift
    loop
    drop
    gd2-unsel
;

: hostcmd ( u -- )
    gd2-sel
        >spi
    00 >spi
    00 >spi
    gd2-unsel
    60 ms
;

: measureF ( -- u ) \ measure FT800's actual clock frequency
    1 ms
    GD.REG_CLOCK GD.@
    10 ms
    GD.REG_CLOCK GD.@
    swap - 100 *
;

47040000 constant LOW_FREQ_BOUND

: tune ( -- ) \ adjust the clock trim to get close to 48 MHz
    0 \ keep last-measured frequency on the stack
    32 0 do
        i GD.REG_TRIM GD.c!
        drop measureF dup LOW_FREQ_BOUND > if
            leave
        then
    loop
    GD.REG_FREQUENCY GD.!
;

0 variable wp             \ write pointer 0-4095
0 variable room           \ how much space is in the command FIFO
18 buffer: inputs         \ sampled touch inputs

: mod4K
    4095 and
;
    
: getspace  ( -- u )    \ u is the space in the command FIFO
    4092
    wp @ GD.REG_CMD_READ GD.@ -
    mod4K -
;

: gostream
    GD.ram_cmd wp @ mod4K +
    GD.wa
;

: unstream
    gd2-unsel
    wp @ GD.REG_CMD_WRITE GD.!
;

: >gd       ( x -- )    \ write x to the command stream
    room  @
    begin
        dup 0=
    while
        drop
        unstream
        getspace
        gostream
    repeat
    4 - room  !
    dup             >spi
    dup 8 rshift    >spi
    dup 16 rshift   >spi
    24 rshift       >spi
    4 wp +!
;

: stream
    getspace room  !
    gostream
;

\ Serialization helper words, mostly named
\ after the type that they serialize:
\ h     16-bit
\ i     32-bit

: cmd   ( x -- )
    -256 or >gd
;

: hh    ( h0 h1 -- )
    16 lshift or >gd
;

: hhhh ( h0 h1 h2 h3 -- )
    2swap hh hh
;

: hhhhhh ( h0 h1 h2 h3 h4 h5 -- )
    2>r hhhh
    2r> hh
;

: hhhhhhhh ( h0 h1 h2 h3 h4 h5 h6 h7 -- )
    2>r 2>r hhhh
    2r> 2r> hhhh
;

: ii   ( x0 x1 -- )
    swap >gd >gd
;

: iii   ( x0 x1 x2 -- )
    >r ii r> >gd
;

\ s>gd appends a string to the command buffer, appends a
\ zero byte, and pads to the next 32-bit boundary.  It
\ iterates through the string, ORing the characters into the
\ 32-bit accumulator on top-of-stack. Every fourth character,
\ it sends the word to the hardware, and clears the
\ accumulator. After the loop, it flushes the partially-filled
\ accumulator to the hardware.

: s>gd   ( caddr u -- ) \ send string to the command buffer
     0 swap 0           ( caddr 0 u 0 )
     ?do
                        ( caddr u32 )
        i 3 and >r
        over i + c@     ( caddr u32 byte )
        r@ 3 lshift lshift or
        r> 3 = if
            >gd
            0
        then
    loop
    >gd                 ( caddr )
    drop
;

\ #######   DRAWING COMMANDS   ################################

: GD.VERTEX2F
    1 30 lshift
\ y
    swap 32767 and
    or
\ x
    swap 32767 and
    15 lshift
    or
    >gd
;
: GD.VERTEX2II
    2 30 lshift
\ cell
    swap 127 and
    or
\ handle
    swap 31 and
    7 lshift
    or
\ y
    swap 511 and
    12 lshift
    or
\ x
    swap 511 and
    21 lshift
    or
    >gd
;
: GD.BITMAPSOURCE
    1 24 lshift
\ addr
    swap 1048575 and
    or
    >gd
;
: GD.CLEARCOLORRGB
    2 24 lshift
\ blue
    swap 255 and
    or
\ green
    swap 255 and
    8 lshift
    or
\ red
    swap 255 and
    16 lshift
    or
    >gd
;
: GD.TAG
    3 24 lshift
\ s
    swap 255 and
    or
    >gd
;
: GD.COLORRGB
    4 24 lshift
\ blue
    swap 255 and
    or
\ green
    swap 255 and
    8 lshift
    or
\ red
    swap 255 and
    16 lshift
    or
    >gd
;
: GD.BITMAPHANDLE
    5 24 lshift
\ handle
    swap 31 and
    or
    >gd
;
: GD.CELL
    6 24 lshift
\ cell
    swap 127 and
    or
    >gd
;
: GD.BITMAPLAYOUT
    7 24 lshift
\ height
    swap 511 and
    or
\ linestride
    swap 1023 and
    9 lshift
    or
\ format
    swap 31 and
    19 lshift
    or
    >gd
;
: GD.BITMAPSIZE
    8 24 lshift
\ height
    swap 511 and
    or
\ width
    swap 511 and
    9 lshift
    or
\ wrapy
    swap 1 and
    18 lshift
    or
\ wrapx
    swap 1 and
    19 lshift
    or
\ filter
    swap 1 and
    20 lshift
    or
    >gd
;
: GD.ALPHAFUNC
    9 24 lshift
\ ref
    swap 255 and
    or
\ func
    swap 7 and
    8 lshift
    or
    >gd
;
: GD.STENCILFUNC
    10 24 lshift
\ mask
    swap 255 and
    or
\ ref
    swap 255 and
    8 lshift
    or
\ func
    swap 7 and
    16 lshift
    or
    >gd
;
: GD.BLENDFUNC
    11 24 lshift
\ dst
    swap 7 and
    or
\ src
    swap 7 and
    3 lshift
    or
    >gd
;
: GD.STENCILOP
    12 24 lshift
\ spass
    swap 7 and
    or
\ sfail
    swap 7 and
    3 lshift
    or
    >gd
;
: GD.POINTSIZE
    13 24 lshift
\ size
    swap 8191 and
    or
    >gd
;
: GD.LINEWIDTH
    14 24 lshift
\ width
    swap 4095 and
    or
    >gd
;
: GD.CLEARCOLORA
    15 24 lshift
\ alpha
    swap 255 and
    or
    >gd
;
: GD.COLORA
    16 24 lshift
\ alpha
    swap 255 and
    or
    >gd
;
: GD.CLEARSTENCIL
    17 24 lshift
\ s
    swap 255 and
    or
    >gd
;
: GD.CLEARTAG
    18 24 lshift
\ s
    swap 255 and
    or
    >gd
;
: GD.STENCILMASK
    19 24 lshift
\ mask
    swap 255 and
    or
    >gd
;
: GD.TAGMASK
    20 24 lshift
\ mask
    swap 1 and
    or
    >gd
;
: GD.BITMAPTRANSFORMA
    21 24 lshift
\ a
    swap 131071 and
    or
    >gd
;
: GD.BITMAPTRANSFORMB
    22 24 lshift
\ b
    swap 131071 and
    or
    >gd
;
: GD.BITMAPTRANSFORMC
    23 24 lshift
\ c
    swap 16777215 and
    or
    >gd
;
: GD.BITMAPTRANSFORMD
    24 24 lshift
\ d
    swap 131071 and
    or
    >gd
;
: GD.BITMAPTRANSFORME
    25 24 lshift
\ e
    swap 131071 and
    or
    >gd
;
: GD.BITMAPTRANSFORMF
    26 24 lshift
\ f
    swap 16777215 and
    or
    >gd
;
: GD.SCISSORXY
    27 24 lshift
\ y
    swap 511 and
    or
\ x
    swap 511 and
    9 lshift
    or
    >gd
;
: GD.SCISSORSIZE
    28 24 lshift
\ height
    swap 1023 and
    or
\ width
    swap 1023 and
    10 lshift
    or
    >gd
;
: GD.CALL
    29 24 lshift
\ dest
    swap 65535 and
    or
    >gd
;
: GD.JUMP
    30 24 lshift
\ dest
    swap 65535 and
    or
    >gd
;
: GD.BEGIN
    31 24 lshift
\ prim
    swap 15 and
    or
    >gd
;
: GD.COLORMASK
    32 24 lshift
\ a
    swap 1 and
    or
\ b
    swap 1 and
    1 lshift
    or
\ g
    swap 1 and
    2 lshift
    or
\ r
    swap 1 and
    3 lshift
    or
    >gd
;
: GD.CLEARtsc
    38 24 lshift
\ t
    swap 1 and
    or
\ s
    swap 1 and
    1 lshift
    or
\ c
    swap 1 and
    2 lshift
    or
    >gd
;
: GD.CLEAR
    38 24 lshift
    7 or
    >gd
;
: GD.END
    33 24 lshift
    >gd
;
: GD.SAVECONTEXT
    34 24 lshift
    >gd
;
: GD.RESTORECONTEXT
    35 24 lshift
    >gd
;
: GD.RETURN
    36 24 lshift
    >gd
;
: GD.MACRO
    37 24 lshift
\ m
    swap 1 and
    or
    >gd
;
: GD.DISPLAY
    0
    >gd
;

: GD.COLORRGB#  ( x -- )
    16777215 and
    4 24 lshift
    or
    >gd
;

: GD.CLEARCOLORRGB#  ( x -- )
    16777215 and
    2 24 lshift
    or
    >gd
;

\ #######   COPROCESSOR COMMANDS   ############################
\
\ These are higher-level FT800 commands, for drawing widgets etc.

hex

: GD.cmd_append  ( ptr num -- )
    01e cmd
    ii
;

: GD.cmd_bgcolor  ( c -- )
    009 cmd
    >gd
;

: GD.cmd_button  ( x y w h font options s -- )
    00d cmd
    2>r hhhhhh
    2r> s>gd
;

: GD.cmd_calibrate  ( -- )
    015 cmd
    0 >gd
;

: GD.cmd_clock  ( x y r options h m s ms -- )
    014 cmd
    hhhhhhhh
;

: GD.cmd_coldstart  ( -- )
    032 cmd
;

: GD.cmd_dial  ( x y r options val -- )
    02d cmd
    >r hhhh r> >gd
;

: GD.cmd_dlstart
    000 cmd
;

: GD.cmd_fgcolor  ( c -- )
    00a cmd
    >gd
;

: GD.cmd_gauge  ( x y r options major minor val range -- )
    013 cmd
    hhhhhhhh
;

: GD.cmd_getmatrix  ( -- )
    033 cmd
;

\ : GD.cmd_getprops  ( ptr w h -- )
\     025 cmd
\ ;

\ : GD.cmd_getptr  ( -- )
\     023 cmd
\ ;

: GD.cmd_gradcolor  ( c -- )
    034 cmd
    >gd
;

: GD.cmd_gradient  ( x0 y0 rgb0 x1 y1 rgb1 -- )
    00b cmd
    >r 2>r
    >r
    hh
    r> >gd
    2r> hh
    r> >gd
;

: GD.cmd_inflate  ( ptr -- )
    022 cmd
    >gd
;

: GD.cmd_interrupt  ( ms -- )
    002 cmd
    >gd
;

: GD.cmd_keys  ( x y w h font options s -- )
    00e cmd
    2>r
    hhhhhh
    2r> s>gd
;

: GD.cmd_loadidentity  ( -- )
    026 cmd
;

: GD.cmd_loadimage  ( ptr options -- )
    024 cmd
    ii
;

: GD.cmd_memcpy  ( dest src num -- )
    01d cmd
    iii
;

: GD.cmd_memset  ( ptr value num -- )
    01b cmd
    iii
;

: GD.cmd_memzero  ( ptr num -- )
    01c cmd
    ii
;

: GD.cmd_memwrite  ( ptr num -- )
    01a cmd
    ii
;

: GD.cmd_regwrite  ( ptr val -- )
    01a cmd
    swap >gd
    4 >gd
    >gd
;

: GD.cmd_number  ( x y font options n -- )
    02e cmd
    >r hhhh
    r> >gd
;

: GD.cmd_progress  ( x y w h options val range -- )
    00f cmd
    0 hhhhhhhh
;

\ : GD.cmd_regread  ( ptr -- )
\     $19 cmd
\ ;

: GD.cmd_rotate  ( a -- )
    029 cmd
    >gd
;

: GD.cmd_scale  ( sx sy -- )
    028 cmd
    ii
;

: GD.cmd_screensaver  ( -- )
    02f cmd
;

: GD.cmd_scrollbar  ( x y w h options val size range -- )
    011 cmd
    hhhhhhhh
;

: GD.cmd_setfont  ( font ptr -- )
    02b cmd
    ii
;

: GD.cmd_setmatrix  ( -- )
    02a cmd
;

: GD.cmd_sketch  ( x y w h ptr format -- )
    030 cmd
    2>r
    hhhh
    2r> ii
;

: GD.cmd_slider  ( x y w h options val range -- )
    010 cmd
    0 hhhhhhhh
;

: GD.cmd_snapshot  ( ptr -- )
    01f cmd
    >gd
;

: GD.cmd_spinner  ( x y style scale -- )
    016 cmd
    hhhh
;

: GD.cmd_stop  ( -- )
    017 cmd
;

: GD.cmd_text  ( x y font options s -- )
    00c cmd
    2>r hhhh
    2r>
    s>gd
;

: GD.cmd_toggle  ( x y w font options state s -- )
    012 cmd
    2>r
    hhhhhh
    2r> s>gd
;

: GD.cmd_track  ( x y w h tag -- )
    02c cmd
    0 hhhhhh
;

: GD.cmd_translate  ( tx ty -- )
    027 cmd
    ii
;
decimal

\ #######   TOP-LEVEL COMMANDS   ##############################

: GD.flush  \ Sends all pending commands to the FT800
    unstream
    stream
;

: GD.finish  \ Wait for all pending commands to complete
    unstream
    begin
        getspace 4092 =
    until
    stream
;

: GD.calibrate  \ run the FT800's interactive calibration procedure
    GD.Clear
    240 100 30 GD.OPT_CENTERX s" please tap on the dot" GD.cmd_text 
    GD.cmd_calibrate
    GD.finish
    GD.cmd_dlstart
;

: GD.swap  \ swaps the working and displayed images
    GD.display
    01 cmd             \ cmd_swap
    GD.flush
    GD.cmd_dlstart
;

: GD.getinputs  \ collects touch input
    GD.finish
    unstream
    inputs      4  GD.REG_TRACKER GD.move 
    inputs 4 +  13 GD.REG_TOUCH_RZ GD.move
    inputs 17 + 1  GD.REG_TAG GD.move
    stream
;

\ accessors for the values collected by GD.getinputs
: GD.inputs.track_tag   inputs 0 + uw@ ;
: GD.inputs.track_val   inputs 2 + uw@ ;
: GD.inputs.rz          inputs 4 + uw@ ;
: GD.inputs.y           inputs 8 + w@ ;
: GD.inputs.x           inputs 10 + w@ ;
: GD.inputs.tag_y       inputs 12 + w@ ;
: GD.inputs.tag_x       inputs 14 + w@ ;
: GD.inputs.tag         inputs 16 + c@ ;
: GD.inputs.ptag        inputs 17 + c@ ;

hex
: GD.init  \ initialize the device
    gd2-spi-init
    gd2-unsel

    000 hostcmd     \ ACTIVE
    PCB_CRYSTAL if
        044 hostcmd     \ CLKEXT
    else
        062 hostcmd     \ CLK48M used for no-crystal parts like Gameduino2
    then
    068 hostcmd     \ CORERST

    PCB_CRYSTAL 0= if
        tune
    then

    0 wp !
    stream

    GD.cmd_dlstart
    GD.Clear

    GD.swap
    unstream

    1 GD.REG_PCLK_POL       GD.c!
    5 GD.REG_PCLK           GD.c!

    PCB_SWIZZLE GD.REG_SWIZZLE  GD.c!
    1 GD.REG_ROTATE         GD.c!

    083 GD.REG_GPIO_DIR     GD.c!
    080 GD.REG_GPIO         GD.c!

    stream
;

decimal

: GD.c  ( x -- ) \ send x to the command buffer
    >gd
;

: GD.s  ( caddr u -- ) \ send buffer to the command buffer
    s>gd
;

: GD.suspend  \ suspend the current SPI stream transaction
    unstream
;

: GD.resume  \ resume the SPI stream transaction
    stream
;

\ FT800 memory access
: GD.c!     unstream GD.c! stream ;
: GD.c@     unstream GD.c@ stream ;
: GD.@      unstream GD.@ stream ;
: GD.!      unstream GD.! stream ;

: GD.play  ( instrument note -- ) \ play a sound
    8 lshift or
    GD.REG_SOUND GD.!
    1 GD.REG_PLAY GD.!
;

: GD.dump.internal
            cr dup dup 
            0 <# # # # # # # #> type 
            space space
            16 0 do
                dup GD.c@ 0 <# # # #> 
                type space char+
            loop
            space swap
            16 0 do
                dup GD.c@ 127 and dup 0 bl within
                over 127 = or
                if drop [char] . then
                emit char+
            loop
            drop
;

: GD.dump  ( a u -- ) \ dump GD memory
    ?dup if
        base @ >r hex
        1- 16 / 1+
        0 do
          gd.dump.internal
        loop
        r> base !
    then
    drop
;

