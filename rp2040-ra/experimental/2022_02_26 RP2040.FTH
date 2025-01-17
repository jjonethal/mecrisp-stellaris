compiletoflash
\ #############################################################
\ #############################################################
\		TACHYON EXTENSIONS for Mecrisp RP2040
\ #############################################################
\ #############################################################

: *TACHYON*		." TACHYON Mecrisp extensions 211230-0900 " ;

\ simple block comment
: {  		BEGIN KEY $7D = UNTIL ; immediate \ }
{
README:
Try to use my 921600bd UF2 Mecrisp mod
and try not to change the source code either because all the pinouts
are runtime configurable for all devices including SD card etc.
save original clean kernel with 1 SAVE# - send/paste then type SAVE
If you want to update an old version of this, type 1 LOAD# for original kernel then paste.

!!! To customize try to keep all changes to INIT (Read the INIT header at the end )
I have also isolated the Maker Pi Pico settings from INIT itself
type MAKERPI to setup the board manually or make a new INIT in Flash.
I am also including other board configurations such as Pico etc

Linux systems can use ASCII-XFR along with the FL.FTH file for
super fast 0 delay loads - less than 1.5sec for this file from go to whoa.
I use this script in Linux which I name fl
# transfer text file
# usage: ./fl RP2040 0
ascii-xfr -sn -l 5 Forth/FL.FTH > /dev/ttyUSB$2
ascii-xfr -sn Forth/$1.FTH > /dev/ttyUSB$2

CHANGELOG:
211220	Added ESP module support for Maker Pi Pico
211214
211201	Standardize pin assignments and setup pcb specific handlers
	- I2C bus on 2&3 may use I2C h/w in future
	- User INIT can now simply call !TACHYON and then user inits

211130	Fixed compile report to list new defintions during block load
211129	Changed I2C SCL to pulse high then float to PU
	I2C now waits for SCL high with 200us timeout (clock stretching)
211126	Rename signed << and >> to <<< and >>>
	recreate simple << and >>
211124	Make SD configuration manual (inc MAKERPI )
	SD? returns false if not configured
211122	Added TIMEOUT words
211119  Tweaked SD read speeds - loads bmp in half the time
211118	Add lap timing to MECRISP *END* reports
211117	Remove CON from TACHYON QUIT loop

211113	Fixed neopixel timing
	added revectorable query - later set to bold for user input
	added .CTRLS linked to ^? to list control keys
211111	Make RTC address user settable
211110	Added I2C and RTC
211024	Added polling via QKEY
}



	( Some basic Tachyon compatible extensions )


: pre		['] : execute ['] IMMEDIATE execute ;
pre pub 	['] : execute ;
pre pri 	['] : execute ;
pre ---		['] \ execute ;
pre } ;

	( CLEARTYPE WORDS )

\ cleartype words are aliases that stand out from single Forth symbols in source code

pub PRINT	. ;
pre PRINT"	['] ." execute ;

		( create vector table )

: VECTORS ( cnt -- ) ( index -- adr )
	<BUILDS CELLS HERE OVER ALLOT SWAP 0 FILL
	DOES> SWAP CELLS +
;

: .RSTACK
    CR PRINT" RETURN STACK: " HEX
    RP@ 32 OVER + SWAP DO I @ . SPACE 4 +LOOP CR
;

	( simple fault handler - resets rather than repeats )

: FAULT
    PRINT"    !address fault! "
    .RSTACK
    RESET
 ;
: !FAULT	['] FAULT irq-fault ! ;
!FAULT


	( hook control )

: QUIT!		hook-quit ! ;
: QUIT: 	'   QUIT! QUIT ;

: EMIT!		hook-emit ! ;
: KEY!		hook-key ! ;
: CON		['] serial-emit EMIT! ;
: MUTED		['] DROP EMIT!  ;
\ Init Stack Pointer
: !SP		SP@ DEPTH 1- CELLS + SP! ;

	( *** TIMING TOOLS *** )

0 variable lap1
0 variable lap2
: LAP 			lap1 @ lap2 ! cycles lap1 ! ;
: LAP@			lap1 @ lap2 @ - LAP LAP lap1 @ lap2 @ - - ;

	( Terminal source code loader mode )

0 variable ~m
: mecrisp	HERE ~m ! !SP CR LAP ;


0 variable ~p
\ TO DO: does not work in compiletoflash mode
: ?REPORT
    (latest) @ ~p @ <>
    IF CR PRINT" --- "
      (latest) @ DUP ~p !
      6 + DUP 1+ SWAP C@ TYPE
    THEN
;

\ : CLS			$0C EMIT ;
: EMITS	( ch cnt -- )	0 do dup emit loop drop ;
: EMITD ( 0...9 -- )	9 MIN $30 + EMIT ;

: <CR>		$0D EMIT ;
: TAB		9 EMIT ;
: TABS		9 SWAP EMITS ;
: INDENT	<CR> TABS ;


	( CONSOLE CONTROL KEYS )

\ create a table of vectors for the 32 control keys
32 VECTORS ctrls
\ default is do nothing
0 ctrls 128 0 FILL

\ Set vector of control key n with cfa
: CTRL! ( cfa n -- )  	ctrls ! ;

\ USER DEBUG HOOK
\ 0 variable 'debug
\ : DEBUG		'debug @ ?DUP IF execute THEN $0D ;

0 variable ~k
\ re-execute last entry
: REX		~k C@ rp@ 16 + ! ;

\ discard and reset the CLI
: DISCARD	2DUP $20 FILL $0D EMIT $2D 80 EMITS ;

\ setup some control keys so far
' RESET 3 CTRL!
' REX	$18 CTRL!
' DISCARD $1B CTRL!


\ create a background polling method while waiting for input

16 buffer: ~polls
: !POLLS			~polls 16 0 FILL ;
!POLLS
: @POLL ( index -- addr )	CELLS ~polls + ;
: POLLS
	4 0 DO I @POLL @ ?DUP IF EXECUTE THEN LOOP
;
: +POLL ( cfa -- )
	4 0 DO I @POLL @ 0= IF DUP I @POLL ! LEAVE THEN LOOP DROP
;
{
R00# 0 variable x1 ---
R00# : POLL1 x1 ++ ; ---
R00# ' poll1 +poll ---
R00# x1 @ . --- 2850947
R00# X1 @ . --- 5563090
}



: QKEY
    BEGIN serial-key? 0= WHILE POLLS REPEAT
    serial-key DUP $20 <
    IF DUP ctrls @ ?DUP IF NIP EXECUTE $0D THEN THEN
;

0 variable ~defers  ( note: just a single deferred execution vector for now)
0 variable ~depth
--- execute deferred words at the end of the line
: defers
	~defers @ ?DUP IF 0 ~defers ! execute THEN

;
--- defer the exection of this word until the end of the line
: ->	R> ~defers ! DEPTH ~depth C! ;

--- Print radix base prompt symbol
: .base
      base @					\ change prompt to indicate base
      case \ show base.
	#10 of ." #" endof			\ # decimal
	#16 of ." $" endof			\ $ hex
	#2  of ." %" endof			\ % binary
	." ?"					\ other base
      endcase
;
: .depth	depth 10 /MOD EMITD EMITD ;
: .mode		compiletoram? if ." R" else ." F" then ;

--- placeholder for compex magic - maybe
: COMPEX

;

' query variable ~query

		( USER PROMPT )

: TACHYON ( -- )
  $BF00 ['] QUIT 4 + H!				\ DISABLE STACK RESET
  !FAULT					\ Simple report and reset handler
  (latest) @ ~p !				\ dictionary match register
  begin
    depth 0< IF !SP THEN
\    CON
    ~m @					\ user or source mode?
    IF
      MUTED QUERY 	 			\ don't echo input
      CON ?REPORT				\ but report new defs
      SPACE INTERPRET				\ and interpret/compile
    ELSE					\ else console mode
      cr .mode .depth .base space
      hook-key @ ['] serial-key =
      IF
        ['] QKEY KEY!				\ Use control key manager
        ~query @ execute PRINT" --- "		\ get input and --- separate from response
        ['] serial-key KEY!			\ switch back to standard key input
      ELSE
	~query @ execute PRINT" --- "		\ get input and --- separate from response
      THEN
      current-source @ ~k !			\ remember position for ^X re-execute
      interpret					\ interpret/compile
      defers
    THEN
  again
;

MECRISP
QUIT: TACHYON






( ************************************************************************ )


	( data space variables - unitialized )

$20030000 constant DATA			\ base for all data and buffers

0 variable @org				\ data space pointer

: org		@org ! ;
: org@		@org @ DATA + ;
( reserve bytes but do not assign a name )
pre res		@org +! ['] \ execute ;
pri (bytes)	org@ ['] constant execute @org +! ;
pre bytes	(bytes) ;
pre byte	1 (bytes) ;
: alorg		1- @org @ OVER + SWAP NOT AND org ;
pri (longs)	4 alorg 2* 2* (bytes) ;
pre longs	(longs) ;
pre long	1 (longs) ;


	( some Tachyon like utility words )

: shift ( n +/-cnt -- )	DUP 0< IF NEGATE rshift ELSE lshift THEN ;
\ : >>>			DUP 0< IF NEGATE lshift ELSE rshift THEN ;

: >>			rshift ;
: <<			lshift ;

: >N			$0F AND ;
: >B			$FF AND ;
: >W 			16 << 16 >> ;
\ : >W			$FFFF AND ;
: bit ( bit -- mask )	1 SWAP << ;
: ~			0 SWAP ! ;
: ~~			-1 SWAP ! ;
: C~~ ( addr -- )	-1 SWAP C! ;
: C~ ( addr -- )	0 SWAP C! ;
: ++			1 SWAP +! ;
: C++			1 SWAP C+! ;
: B++			SWAP 1+ SWAP ;
: C@++			DUP 1+ SWAP C@ ;

: W>B			DUP $FF AND SWAP 8 >> ;
: L>W ( long -- lw hw )	DUP $FFFF AND SWAP 16 >> ;
: 3RD			2 PICK ;
: 4TH			3 PICK ;

: BOUNDS		OVER + SWAP ;
: ERASE			0 FILL ;

: U/			1 SWAP U*/MOD NIP ;

: HMS ( #xxyyzz -- zz yy xx ) 100 U/MOD 100 U/MOD ;


1 constant ON
0 constant OFF

	( unit multipliers )

\ unit multipliers
: KB		10 << ;
: MB		20 << ;
\ seconds
: s		1000 * ms ;

	( simple conditional EXIT words )

\ Exit if zero
: 0EXIT		0= IF R> DROP THEN ;
\ Exit if true
: ?EXIT		IF R> DROP THEN ;



\	--- UNALIGNED LONGS ---
0 variable ~u
: U@		~u 4 MOVE ~u @ ;
: U!		SWAP ~u ! ~u SWAP 4 MOVE ;



	( bit on byte flags ops )
: SET ( mask adr -- )	DUP C@ ROT OR SWAP C! ;
: CLR ( mask adr -- )	DUP C@ ROT NOT AND SWAP C! ;
: SET? 			C@ AND ;

 	( null terminated strings )

--- store nullterm string
pub $! ( src dst -- )	BEGIN OVER C@ OVER C! OVER C@ WHILE B++ 1+ REPEAT 2DROP ;
--- Find length of nullterm string
pub LEN$ ( str -- len )	0 SWAP BEGIN DUP C@ WHILE B++ 1+ REPEAT DROP ;
--- print nullterm string
pub PRINT$ ( str -- )	BEGIN DUP C@ WHILE DUP C@ EMIT 1+ REPEAT DROP ;
--- convert lower-case to upper-case
pub a>A ( ch -- ch )	DUP $60 > OVER $7B < AND IF $20 - THEN ;


	( ANSI )
7 variable ~pen
0 variable ~paper
pub PEN@	~pen @ ;
pub PAPER@	~paper @ ;


--- ANSI COLORS
0	constant black
1	constant red
2	constant green
3	constant yellow
4	constant blue
5	constant magenta
6	constant cyan
7	constant white


pub ESC ( ch -- )		$1B EMIT EMIT ;

pri ESCB ( ch -- )		[CHAR] [ ESC EMIT ;
pub HOME			[CHAR] H ESCB ;

pri COL ( col fg/bg -- )	ESCB [CHAR] 0 + EMIT [CHAR] m EMIT ;
pub PEN ( col -- )		dup ~pen ! 7 AND [CHAR] 3 COL ;
pub PAPER ( col -- )		dup ~paper ! [CHAR] 4 COL ;


pri .PAR			SWAP 0 <# #S #> TYPE EMIT ;
pri CUR ( cmd n -- )	    	[CHAR] [ ESC SWAP .PAR ;
pub XY ( x y -- )		[CHAR] ; SWAP CUR [CHAR] H .PAR ;


--- Erase the screen from the current location
pub ERSCN			[CHAR] 2 ESCB [CHAR] J EMIT ;
--- Erase the current line
pub ERLINE			[CHAR] 2 ESCB [CHAR] K EMIT ;
pub CLS 			ERSCN HOME ; \ $0C EMIT ;


pri asw				IF [CHAR] h ELSE [CHAR] l THEN EMIT ;
pub CURSOR ( on/off -- )	[CHAR] ? ESCB 25 PRINT asw ;

--- 0 plain 1 bold 2 dim 3 rev 4 uline
pri ATR ( ch -- )		ESCB [CHAR] m EMIT ;
pub PLAIN			[CHAR] 0 ATR white ~pen ! ~paper ~ ;
pub REVERSE			[CHAR] 7 ATR ;
pub BOLD			[CHAR] 1 ATR ;
pub UL				[CHAR] 4 ATR ;
pub BLINK			[CHAR] 5 ATR ;

pub WRAP ( on/off -- )		[CHAR] ? ESCB [CHAR] 7 EMIT asw ;

\ pub %MARGINS ( top bottom -- )	'[' ESC SWAP ':' .PAR 'r' .PAR ;





	( *** PRINT HEX & BINARY *** )


: .HEX ( n cnt -- ) HEX <# 0 DO # LOOP #> TYPE DECIMAL ;
: .B		0 2 .HEX ;
: .H		0 4 .HEX ;
: .L	   	0 8 .HEX ;
: .BIN		32 0 DO I IF I 3 AND 0= IF $5F EMIT THEN  THEN ROL DUP 1 AND EMITD LOOP DROP ;

	( *** PRINT DECIMAL NUMBER *** )

$20 variable ~z --- leading character

\ unsigned double right justify to cnt places with leading spaces as default
: D.R ( d. cnt -- )
	<# 0 DO 2DUP OR IF # ELSE I 0= IF $30 ELSE ~z C@ THEN HOLD THEN LOOP #> TYPE
---	reset default leading character
	$20 ~z C!
;
\ unsigned right justify to cnt places with leading spaces as default
: U.R ( u cnt -- )	0 SWAP D.R ;
\ use leading zeros for next print
: Z			$30 ~z C! ;

\ print wihh commas in western decimal format
: D.DEC		DECIMAL <# BEGIN 2DUP 999. D> WHILE # # # $2C HOLD REPEAT #S #> TYPE ;
: .DEC		0 D.DEC ;
: .DEC2		DECIMAL 0 <# # # #> TYPE ;
: .DEC4		DECIMAL 0 <# # # # # #> TYPE ;


0 VARIABLE ~d
\ Print comma decimal number over cnt places including commas used
: D.DECS ( d. cnt -- )
	~d 1+ C! ~d C~ DECIMAL
	<# 2DUP OR
	   IF
	     BEGIN 2DUP 999. D> WHILE # # # $2C HOLD 4 ~d C+! REPEAT
	     BEGIN 2DUP OR WHILE # ~d C++ REPEAT
	   ELSE # ~d C++
	   THEN
	#>
	~d 1+ C@ ~d C@ - SPACES TYPE ;
: .DECS ( n cnt -- )	0 SWAP D.DECS ;



	( TIMING REPORTING TOOLS )

: .LAP			LAP@ .DEC PRINT" us" ;
: .LAPS ( n -- )	LAP@ 1000 ROT */ .DEC PRINT" ns" ;

: *END*
	lap
	CR PRINT" End of load - "
	HERE ~m @ - . PRINT"  bytes used in "
	.LAP
	CR PRINT" !!! Type SAVE to backup to Flash as default"
	!SP 	0 ~m !
;



	( ANY ADDREESS DUMP )

\ !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~
\ Emit character but substiture if non-printing.
: AEMIT ( ch sub --)	SWAP DUP $20 < OVER $7E > OR IF DROP ELSE NIP THEN EMIT ;

	( DEVICE MEMORY OPERATORS )


' @ variable ~dm
' H@ variable ~dmh
' C@ variable ~dmc

           ( DUMP MEMORY OPERATORS )
: DMC@		~dmc @ EXECUTE ;
: DMH@		~dmh @ EXECUTE ;
: DM@		~dm @ EXECUTE ;

( @ H@ C@ -- ) ( SET DUMP MEMORY OPERATORS )
: DUMP!		~dm ! ~dmh ! ~dmc ! ;
: MEM		['] C@ ['] H@ ['] @ DUMP! ;
: PRINT:	PRINT" : " ;
: .ADDR		CR .L PRINT: ;
: (DUMPA)	BOUNDS DO I DMC@ $20 AEMIT LOOP ;
: .BYTES	BOUNDS DO I DMC@ .B SPACE LOOP ;
: DUMP
      ~dmc @ 0= IF MEM THEN
       BOUNDS DO
         I .ADDR
         I 8 .BYTES SPACE I 8 + 8 .BYTES
         ." | "
         I 16 (DUMPA)
         ." | "
       16 +LOOP
       MEM
       ;
: DUMPA		BOUNDS DO I .ADDR I 64 (DUMPA) 64 +LOOP	MEM ;
: DUMPAW	BOUNDS DO I .ADDR I 128 (DUMPA) 128 +LOOP MEM ;
: DUMPL
	BOUNDS DO I .ADDR
	  I 32 BOUNDS DO I DM@ .L SPACE 4 +LOOP
	32 +LOOP MEM ;
: DUMPH
	BOUNDS DO I .ADDR
	  I 32 BOUNDS DO I DMH@ .H SPACE 2 +LOOP
	32 +LOOP MEM ;

\ QUICK DUMP
: QD	$40 DUMP ;

{

: MAP 	BOUNDS DO I $7FFF AND 0= IF I .ADDR THEN  0 I 1024 BOUNDS DO I C@ + LOOP .B SPACE 1024 +LOOP ;

}


	( BETTER STACK LIST )

: .S	DEPTH ?DUP
	IF 64 UMIN
	  0 DO CR I PRINT PRINT:
	  I PICK $FF AND $20 AEMIT SPACE
	  I PICK PRINT" $" .L 3 SPACES I PICK .DEC LOOP
	ELSE PRINT" EMPTY "
	THEN
	;


: >NFA		1- BEGIN 2- DUP C@ $20 < UNTIL 1+ ;
: >LFA     	 >NFA 6 - ;

: NFA'		' >NFA ;
\ RENAME A WORD IN THE DICTIONARY WITH A ANOTHER WORD - MUST MATCH LENGTHS.
\ : RENAME:	' >NFA DUP C@ TOKEN 2 PICK =  IF ROT 1+ ROT MOVE ELSE DROP 2DROP THEN ;

\ rename: words lists

	( Simple names only dictionary listing )
{
Use qw to list the last 20 words, or swords for a short names only words listing
or <count> nwords

}
\ link(4) atr?(2) CNT NAME
0 variable ~n
80 variable tw

: HIGHLIGHT
    plain
    DUP 4 + H@ CASE
      $40 OF magenta pen ENDOF
      8 OF cyan pen ENDOF
      0 OF plain ENDOF
      DUP $10 AND
      IF red pen ELSE
      green pen THEN
    ENDCASE
;
: nwords ( max -- )
	0 ~n !
	dictionarystart
	BEGIN
	  OVER 0<> OVER -1 <> AND KEY? 0= AND
	WHILE
\        skip hidden words marked with a preceding ~
\	  DUP 7 + DUP C@ $7E = SWAP 1+ C@ $7E <> AND NOT
\	  IF
	  HIGHLIGHT
	  DUP 4 + H@ $FFFF <>
	  IF
	    DUP 6 + DUP 1+ SWAP C@ ( dict name cnt )
	\ wrap before it prints over 80 columns
	    DUP 1+ ~n +! ~n @ tw C@ > IF CR DUP 1+ ~n ! THEN
	    TYPE SPACE plain
	  THEN
\	  THEN
	  @ SWAP 1- SWAP

	REPEAT 2DROP
;
: qw		20 nwords ;
: words		-1 nwords ;




	( ENHAHCE SEE TO DISPLAY HEADER )

: .HEAD
    CR DUP >LFA DUP .L PRINT: @
    $5B EMIT .L ." ] {"
    DUP >NFA 2- H@ .H ." } "
    >NFA DUP C@ 1+
    BOUNDS DO SPACE I C@ .B LOOP
    CR PRINT" CODE:"
;
: SEE		>IN C@ ' .HEAD >IN C! SEE ;
: CSEE ( CODE -- )   disasm-$ ! seec ;




125000000 constant clkfreq


$40008040 constant clksysdiv
: clk! 		8 << clksysdiv ! ;

$40024000 constant xosc

$40028000 constant pllsys



\ #############################################################
\ #############################################################
\		I/O WORDS & NEOPIXEL
\ #############################################################
\ #############################################################





\ Already configured in core for SIO (Software IO), function 5:

	( ADDRESS MAP CONSTANTS )

$00000000 constant ROM
$10000000 constant XIP
$20000000 constant RAM
$40000000 constant APB
$40014000 constant IO0
$4001c000 constant PADS0	--- 2.19.6.3. Pad Control - User Bank
$4000c000 constant RESETS
$50000000 constant AHB
$E0000000 constant M0


$40028000 constant PLLSYS
0 constant PLLCS
4 constant PLLPWR
8 constant PLLDIV




( SIO REGISTERS )

: SIO	$D0000000 + ;

$004 constant IOIN
$010 constant IOOUT
$014 constant IOSET  \ GPIO output value set
$018 constant IOCLR  \ GPIO output value clear
$01C constant IOXOR
$020 constant IOOE
$024 constant OESET   \ GPIO output enable set
$028 constant OECLR
$02C constant OEXOR

	( GPIO )
--- GPIO STATUS
: GPSR ( pin -- )	3 << $40014000 + ;
--- GPIO CONTROL
: GPCR ( pin -- )	3 << $40014004 + ;


: MASK! ( flg adr mask -- )	 ROT IF OVER @ OR ELSE OVER @ SWAP BIC THEN SWAP ! ;

{
	PADS

2.19.6.3. Pad Control - User Bank

31:8 Reserved. - - -
7 OD Output disable. Has priority over output enable from RW 0x0
peripherals
6 IE Input enable RW 0x1
5:4 DRIVE Drive strength. RW 0x1
0x0 → 2mA
0x1 → 4mA
0x2 → 8mA
0x3 → 12mA
3 PUE Pull up enable RW 0x0
2 PDE Pull down enable RW 0x1
1 SCHMITT Enable schmitt trigger RW 0x1
0 SLEWFAST Slew rate control. 1 = Fast, 0 = Slow RW 0x0
}

--- PADS_BANK0: VOLTAGE_SELECT Register
: PADS1V8 			1 PADS0 ! ;
: PADS3V3 			0 PADS0 ! ;

\ $4001c000 constant PADS0
: @PAD ( pin -- adr )		1+ 2* 2* PADS0 + ;
: PAD@ ( pin -- val )		@PAD @ ;
: PAD! ( val pin -- )		@PAD ! ;

--- enable pullup (and disable pulldown)
: PU ( pin -- )			@PAD DUP @ 8 OR 4 BIC SWAP ! ;
--- enable pulldown (and disable pullup)
: PD ( pin -- )			@PAD DUP @ 4 OR 8 BIC SWAP ! ;

--- select schmitt input
\ : SCHMITT ( on/off pin -- )	@PAD DUP @ ROT IF 2 OR ELSE 2 BIC THEN SWAP ! ;
: SCHMITT ( on/off pin -- )	@PAD 2 MASK! ;
--- set slewrate  1=fast 0=slow (default)
\ : SLEW ( 1=fast pin -- )	@PAD DUP @ ROT IF 1 OR ELSE 1 BIC THEN SWAP ! ;
: SLEW ( 1=fast pin -- )	@PAD 1 MASK! ;

{

	$CA SDDO PAD!
	$53 SDCK PAD!
	$5B SDDI PAD!
	$62 SDCS PAD!
}



{
29:28	IRQOVER
17:16	INOVER
13:12	OEOVER
9:8	OUTOVER
4:0	FNC
1		2		3		4		5	6	7	8	9
SPI0	RX 	UART0	TX	I2C0	SDA	PWM0	A	SIO	PIO0	PIO1		USB	OVCURIN
SPIO0	CS	UART0	RX	I2C0	SCL	PWM0	B	SIO	PIO0	PIO1		USB	VBUSIN
SPIO0	CK	UART0	CTS	I2C1	SDA	PWM1	A	SIO	PIO0	PIO1		USB	VBUSEN
SPIO0	TX	UART0	RTS	I2C1	SCL	PWM1	B	SIO	PIO0	PIO1
SPI0	RX 	UART1	TX	I2C0	SDA	PWM2	A	SIO	PIO0	PIO1
SPIO0	CS	UART1	RX	I2C0	SCL	PWM2	B	SIO	PIO0	PIO1
SPIO0	CK	UART1	CTS	I2C1	SDA	PWM3	A	SIO	PIO0	PIO1
SPIO0	TX	UART1	RTS	I2C1	SCL	PWM3	B	SIO	PIO0	PIO1

}

	( PIN FUNCTION SELECT )

: FNC ( pin fnc -- )	SWAP GPCR ! ;
: #SPI		1 FNC ;
: #UART		2 FNC ;
: #I2C		3 FNC ;
: #PWM		4 FNC ;
: #SIO		5 FNC ;
: #PIO0		6 FNC ;
: #PIO1		7 FNC ;
: #USB		9 FNC ;





	( SIMPLE IO WORDS )

: SIO! ( val reg -- )	SIO ! ;
: SIO@ 			SIO @ ;
: FLOAT ( pin -- )	bit OECLR SIO! ;
: PIN@	( pin -- bit )	IOIN SIO@ SWAP >> 1 AND ;
: PIN? ( pin -- pin bit ) IOIN SIO@ OVER >> 1 AND ;
: HIGH ( pin -- )	bit DUP IOSET SIO! OESET SIO! ;
: LOW ( pin -- )	bit DUP IOCLR SIO! OESET SIO! ;
: PIN! ( b0 pin -- )	SWAP 1 AND IF HIGH ELSE LOW THEN ;

: WAITHI ( pin -- )		BEGIN PIN? UNTIL LAP DROP ;
: WAITLO  ( pin -- )		BEGIN PIN? 0= UNTIL LAP DROP ;


: lsio
    30 0 DO
      CR I .DEC2
      SPACE I bit IOOE @ AND IF ." OUT " ELSE ." INP " THEN
      SPACE I PIN@ IF [CHAR] H ELSE [CHAR] L THEN EMIT
      SPACE I GPSR @ .L
      SPACE I GPCR @ .L
    LOOP
;

' lsio $0C CTRL!


	( *** PWM *** )

$40050000 variable ~pwm \ base address of PWM
0 variable pwmpin

: @PWM				~pwm @ + ;
\ find address of register of currently selected PWM pin
: PWMCSR			0 @PWM ;
: PWMDIV			4 @PWM ;
: PWMCTR			8 @PWM ;
: PWMCC				12 @PWM ;
: PWMTOP			16 @PWM ;
: PWMCC!			pwmpin C@ 1 AND IF 16 << PWMCC @ $FFFF AND OR ELSE PWMCC @ $FFFF0000 AND OR THEN PWMCC ! ;

\ Setup PWM base to be used for this pin
: PWMCH ( pin -- )  		DUP pwmpin C! DUP #PWM 2/ 7 AND 20 * $40050000 + ~pwm ! ;
\ setup pin for 8-bit pwm preset to 50% at highest freq.
\ : PWMPIN ( pin -- )		DUP #PWM PWMCH 1 PWMCSR ! $10 PWMDIV ! $100 PWMTOP ! $80 PWMCC ! ;


: DUTY ( on off -- )		PWMTOP ! PWMCC! 1 PWMCSR ! ;
: PWM  ( on off div pin -- ) 	PWMCH PWMDIV ! DUTY ;
\ : PWMHZ! ( off freq -- off )	clkfreq 3rd / OVER /MOD 4 << SWAP 4 << ROT / OR PWMDIV ! ;
: PWMHZ! ( freq -- )		clkfreq PWMTOP @ / OVER /MOD 4 << SWAP 4 << ROT / OR PWMDIV ! ;
: PWMHZ ( on off freq pin -- )	PWMCH -ROT DUTY PWMHZ! ;

\ setup pin and set duty cycle to percentage - @1kHz
: PWM% ( n pin -- )		100 SWAP 1000 SWAP PWMHZ ;
\ : PWM% ( n pin -- )		PWMPIN 100 PWMTOP ! PWMCC ! ;

--- output RC servo pulse of 1ms to 2ms on pin @50Hz (0..100%)
\ : SERVO ( 0..100% pin -- )	SWAP 10 * 1000 + SWAP 20000 $7D0 ROT PWM ;
: SERVO ( 0..100% pin -- ) 	PWMCH  $7D0 PWMDIV !  10 * 1000 + 20000 DUTY ;
\  : SERVO			PWMCH 100 50 PWMHZ! DUTY ;

: HZ ( freq pin -- )		PWMCH 1 2 DUTY PWMHZ!  ;



	( SIMPLE NEOPIXEL DRIVER )

( !!!!!!!!!!!!!! IT WAS WORKING BUT NEED TO FIX UP TIMING AGAIN !!!!!! )
\ : HIGH ( pin -- )	bit DUP IOSET SIO! OESET SIO! ;

28 bit variable _neopin
\ Specify the NEOPIXEL to use
: NEOPIN ( n -- )	bit _neopin ! ;
: pixdly		1 0 do loop ;
: pix1			_neopin @ IOSET SIO!  ;
: pix0			_neopin @ IOCLR SIO!  ;
: pix!			pix1 pixdly IF pix1 ELSE pix0 THEN pixdly pix0 pix0 ;
	( write to a single neopixel )
: NEO! ( $ggrrbb -- )	_neopin @ OESET SIO! 8 << 24 0 DO ROL DUP 1 AND pix! LOOP pixdly DROP ;

\ : CHECK		LAP $1000 NEO! LAP .LAP ; CHECK


	( wrtie buffer @ 4 bytes/neo to neopixel array )
: NEOS! ( buffer neocnt -- )
	2 << BOUNDS DO I @ NEO! 4 +LOOP
	50 us
	;

: RGB ( red green blue -- ) 	SWAP 16 << + SWAP 8 << + NEO! ;

	( some demo neo colors )

\ : hot			$10A000 NEO! ;
: white!		-1 NEO! ;
: blank!		0 NEO! ;
: blue! ( n  -- ) 	NEO! ;
: red! ( n -- )		8 << NEO! ;
: green! ( n -- )	16 << NEO! ;

 \ : DEMO 		0 $1000 BOUNDS DO I 8 NEOS! 100 ms 4 +LOOP ;



	( UARTS )

0 variable ~uart
\ UART selectors
: UART0  	$40034000 ~uart ! ;
: UART1  	$40038000 ~uart ! ;
UART0

\ Add in selected uart base
: UART		~uart @ + ;

	( UART REGISTERS )

: UDR		0 UART ;
: UFR		$18 UART ;
: IBRD		$24 UART ;
: FBRD		$28 UART ;
: LCR		$2C UART ;
: UCR		$30 UART ;

115200 variable ~baud

\ Setup the current selected UART and set its baud rate
\ If baud < 300 then use this as a direct divisor inc 4-bit fractional
pub BAUD ( baud -- )
    DUP ~baud !
    DUP 299 > IF clkfreq  SWAP / THEN
    DUP 4 >> IBRD !  $0F AND 2 << FBRD !
    $301 UCR !
    $70 LCR !
;

--- change console baud rate
pub CONBAUD	UART0 BAUD ;
{
$669E, $66A2
921600	$08 $1C

}

--- simple receive routine using select channel
: RX ( -- ch )	BEGIN UFR @ $10 AND 0= UNTIL UDR @ ;
: TX ( ch -- )	BEGIN UFR @ $20 AND 0= UNTIL UDR ! ;



	( EXPERIMENTAL INTERACTIVE  PIO REGISTER METHODS - WIP )

 \ Syntax - PIO0 SM3

0 variable ~pio
\ Select PIO
: PIO0	$50200000 ~pio ! ;
: PIO1	$50300000 ~pio ! ;

: @PIO	~pio @ + ;

0 variable sm
0 variable ch
\ Select state machine within current PIO
: SM0	$0C8 @PIO sm ! 0 ch ! ;
: SM1	$0E0 @PIO sm ! 4 ch ! ;
: SM2	$0F8 @PIO sm ! 8 ch ! ;
: SM3	$110 @PIO sm ! 12 ch ! ;
: @SM	sm @ + ;


\ get address of register within current PIO
: FCTRL		$00 @PIO ;
: FSTAT		$04 @PIO ;
: FDEBUG	$08 @PIO ;
: FLEVEL	$0C @PIO ;
\ get address of FIFO with current state machine and PIO
: TXFIFO	ch @ $10 + @PIO ;
: RXFIFO	ch @ $20 + @PIO ;


: IRQ		$30 @PIO ;
: IRQ_FORCE	$34 @PIO ;
: INSYN		$38 @PIO ;	\ INPUT_SYNC_BYPASS
: DBG_PADOUT	$3C @PIO ;
: DBG_PADOE	$30 @PIO ;
: DBG_CFGINFO	$44 @PIO ;

\ Usage: PIO0 SM1 $10 PIOMEM
: PIOMEM	2* 2* $48 + @PIO ;	\ 32 REGISTERS

\ STATE MACHINE REGISTERS
\ Usage: PIO1 SM3 INSTR @
: CLKDIV	00 @SM ;
: EXECCTRL	04 @SM ;
: SHIFTCTRL	08 @SM ;
: ADDR		12 @SM ;
: INSTR		16 @SM ;
: PINCTRL	20 @SM ;


: INTR		$128 @PIO ;
: IRQE0		$12C @PIO ;
: IRQF0		$130 @PIO ;
: IRQS0		$134 @PIO ;



	( HC-SR04 PIN SENSOR )

--- PING ( echo trig -- mm ) trigger ping and return with result in mm (less the effective transducer depth)
: PING		DUP LOW 2 us DUP HIGH 10 us LOW DUP FLOAT DUP WAITHI WAITLO LAP@ 170145 1000000 */ 6 - ;

	( GROVE ULTRASONIC RANGER )

: RANGER ( pin -- mm )
	DUP LOW 2 us DUP HIGH 5 us DUP LOW
	DUP FLOAT DUP WAITHI WAITLO LAP@
---	speed m/s @sea     offset
	170145 1000000 */   6 -
;



\ #############################################################
\ #############################################################
\		ANALOG INPUtS + TEMP + VOLTAGE
\ #############################################################
\ #############################################################


: ADC		$4004c000 + ;
: ADC-CS	0 ADC ;		--- CS ADC Control and Status
: ADC-RES	4 ADC ; 	--- Result of most recent ADC conversion
: ADC-FCS	8 ADC ; 	--- FIFO control and status
: ADC-FIFO	$0C ADC ; 	--- Conversion result FIFO
: ADC-DIV	$10 ADC ; 	--- Clock divider
: ADC-INTR	$14 ADC ; 	--- Raw Interrupts
: ADC-INTE	$18 ADC ;	--- Interrupt Enable
: ADC-INTF	$1C ADC ;	--- Interrupt Force
: ADC-INTS	$20 ADC ;	--- Interrupt status after masking & forcing
{
	If non-zero, CS_START_MANY will start conversions
at regular intervals rather than back-to-back.
The divider is reset when either of these fields are written.
Total period is 1 + INT + FRAC / 256

0	P26
1	P27
2	P28
3	P29
5	TEMP SENSOR

MEASURED
ADCREF  3.24V
}

\ 20 BUFFER: adcbuf
: ADC@ ( n -- val )	( 0 ADC-DIV ! )
	\ DUP
	12 << %0111 + ADC-CS !
	  BEGIN $100 ADC-CS BIT@ UNTIL
	ADC-RES @ \ DUP ROT 2* 2* adcbuf + H!
;
{
	!!!! just checking this now ---
VSYS = 536 to 542 = 5.1V
}
\ convert 12-bit ADC reading into microvolts
3260000 variable vref
: >uV		vref @ 4096 */ ;
: >mV		>uV 1000 / ;
: .mV		4 U.R PRINT" mV" ;
: .VSYS		3 ADC@ 3 * >mV .mV ;
{
Pico Sensor Vbe = 0.706V at 27 degrees C, with a slope of -1.721mV/'C
RPi forumula is T = 27 - (ADC_voltage - 0.706)/0.001721
datasheet says 891 would correspond to 20.1°C

894 = 707.167mV -> 751.257 - 707.167 = 44.090mv * 1.721 = 25.618'C

}
: >TEMP		>uv 706000 - 1000000 1721 */ 27000000 SWAP - 100000 / ;
\ : >TEMP		>uv 751257 SWAP - 1000 1721 */ 100 / 0 MAX ;
: TEMP@		4 ADC@  >TEMP  ;
: .TEMP		TEMP@ 0 <# # $2E HOLD #S #> TYPE PRINT" 'C " ;

: .ADCS		5 0 DO CR I . PRINT: I ADC@ DUP 5 U.R PRINT"  = " >mV .mV LOOP  ;
: !ADC		%11 ADC-CS ! 0 ADC@ DROP ( adcbuf 20 ERASE ) ;





\ #############################################################
\ #############################################################
\		SIMPLE SOUNDS
\ #############################################################
\ #############################################################

0 variable spkr

: TONE ( hz ms -- )
    spkr C@
    IF
    1000 * cycles + 1000000 ROT / 2/
    BEGIN
      spkr C@ HIGH DUP us
      spkr C@ LOW DUP us OVER cycles <
    UNTIL
    THEN
    2DROP
;
: CLICK      		spkr C@ ?DUP IF DUP HIGH 100 us LOW THEN ;
: BIP    		3000 50 TONE ;
: BEEP  		3000 150 TONE ;
: BEEPS			0 DO BEEP 50 ms LOOP ;
: WARBLE ( hz1 hz2 ms -- )    3 0 DO 3RD OVER TONE 2DUP TONE LOOP DROP 2DROP ;
: SIREN			400 550 400 WARBLE ;
: ~R 			500 600 40 WARBLE ;
: RING 			~R 200 ms ~R ;
: RINGS ( rings -- )  	0 DO RING 1000 ms LOOP ;

: ZAP			3000 100 DO I 15 I 300 / - TONE 200 +LOOP ;
: ZAPS ( cnt -- )	0 DO ZAP 50 ms LOOP ;
: SAUCER		10 0 DO 600 50 TONE 580 50 TONE LOOP ;

\ SAUCER ZAP SAUCER 3 ZAPS SIREN
{
: CYLON ( from -- )
	BEGIN
	  16 0 DO I DUP 7 > IF $0F XOR THEN OVER + DUP HIGH 100 ms LOW LOOP
	KEY?
	UNTIL
	;
}
\ led flasher
: FLASHES ( cnt led -- )	SWAP 0 DO DUP HIGH 100 ms DUP LOW 100 ms LOOP DROP ;





\ #############################################################
\ #############################################################
\		SD CARD SPI DRIVERS
\ #############################################################
\ #############################################################

0 variable ~sdpins
0 variable &sdck
pub SDCK	~sdpins C@ ;
pub SDDI	~sdpins 1+ C@ ;
pub SDDO	~sdpins 2+ C@ ;
pub SDCS	~sdpins 3 + C@ ;

pub SDPINS ( csdodick -- ) ~sdpins ! SDCK bit &sdck ! ;

\ : SPICLK	SDCK HIGH SDCK LOW ;


: SPICLK	&sdck @ IOSET SIO! &sdck @ IOCLR SIO! ;

\ : SPICLKS	0 DO &sdck @ IOSET SIO! &sdck @ IOCLR SIO! LOOP ;

: SPICLKS	&sdck @ SWAP 0 DO DUP IOSET SIO! DUP IOCLR SIO! LOOP DROP ;

( aabbccdd -- bbccddaa ) --- write ms byte to SPI bus and rotate result
: SPIWR		8 0 do ROL DUP SDDI PIN! SPICLK LOOP ;
\ : SPIWR		8 0 do ROL DUP 1 AND IF SDDI HIGH ELSE SDDI LOW THEN SPICLK LOOP ;
( byte -- ) --- write byte to SPI bus
: SPIWB		24 << SPIWR DROP ;
( cmd -- ) --- format as SD command and write
: SPIWC		$3f AND $40 OR SPIWB ;
( long -- ) --- write long to SPI
: SPIWL		SPIWR SPIWR SPIWR SPIWR DROP ;

\ read another byte from SPI and append to lsb of input
: SPIRD ( input -- output )
	SDDI HIGH &sdck @ SWAP
	8 0 DO 2* SDDO PIN@ OR
	OVER IOSET SIO! OVER IOCLR SIO! \ SPICLK
	LOOP NIP
	;

: SPIRDS ( &clk input -- &clk output )
	SDDI HIGH
	8 0 DO 2* SDDO PIN@ OR
	OVER IOSET SIO! OVER IOCLR SIO! \ SPICLK
	LOOP
	;

\ SPI read 4 byte as a 32-bit long
: SPIRL			0 SPIRD SPIRD SPIRD SPIRD ;
: SPIRX ( dst cnt -- )	&sdck @ ROT ROT BOUNDS DO  0 SPIRDS I C! LOOP DROP ;
: SPITX ( src cnt -- )	BOUNDS DO I C@ SPIWB LOOP ;


: SDCLK		8 SPICLKS ;
: SDCLKS	0 DO SDCLK LOOP ;



	( SD FUNCTIONS )


0	org
512 4 *	bytes 	SDBUF		--- allocate sectors for up to 4 files
128 	bytes	DIRBUF

\ org@	org ( marks start of           block for DATLEN )
0	bytes	sdvars		--- mark start of variables array
1	longs	ocr		--- operating conditions registers
16	bytes	cid		--- card ID
16	bytes	csd		--- card specific data
\ 32 	bytes 	cfnc

1	longs	sdsize		--- numbero of sectors
1	longs	@sdrd
1	longs	@sdwr
1	longs	sdsum		--- checksum of sector contents
1	longs	seccrc		--- sector crc

1	longs	readsect	--- current buffered sector
1	longs	filesect	--- starting sector of current file ( could be a directory)'
1	longs	opensect	--- starting sector of open file'

1	longs	_fread
1	longs	_fwrite
1	longs	mntd		--- serial number of mounted device
2	bytes	_fkey

1	bytes	_sdcmd
1	bytes	_sdres
1	bytes	wrflg		--- true if sector has been modified
1	bytes	wrens		--- write enables
1	bytes	file#
1	bytes	fq		--- listing counter
1	bytes	sdhc
1	bytes	blklen
16 	bytes	bitbuf

\	*** PARITION RECORDS ***

--- 4 primary partitions
16	longs	parts		--- STATE,[HEAD,[SECT(2),TYPE,HEAD],SECT(2)],1STSECT(4),PARTSEC(4)
						---  00    82    03 00   0B   50    CA C6     $2000  $00ECC000
2	bytes	parsig


\	*** FAT32 BOOT RECORD ***

0	longs	fat32
3   	res			--- jump code +nop
8	bytes	oemname		--- MSWIN4.1
2	bytes	b/s		--- 0200 = 512B (bytes/sector)
1	bytes	s/c		--- 40 = 32kB clusters (sectors/cluster)
2	bytes	rsvd		--- 32 reserved sectors from boot record until first fat table

1	bytes	fats		--- 02
2	res			--- Maximum Root Directory Entries (non-FAT32)
2	res			--- Number of Sectors inPartition Smaller than 32MB (non-FAT32)
1	bytes	media		--- F8 hard disk  (IBM defined as 11111red, where r is removable, e is eight sectors/track, d is double sided. )
2	res			--- Sectors Per FAT in Older FATSystems (N/A for FAT32)
2	res			--- Sectors Per Track --- 3F 00
2	res			--- Number of Heads --- FF 00

4	bytes	hidden		--- Number of Hidden Sectors before Partition --- 00 20 00 00
( 32 )
4	bytes	s/p		--- $00EC_C000  Number of sectors * byte/sect (512) = capacity'
4	bytes	s/f		--- $0000_0766 Number of sectors per FAT table'
2	bytes	fat?		--- 0000 fat flags (b3..0 = active fat copy, b7=mirroring)
2	res	fatver		--- 0000 fat version MAJOR.MINOR
( 44 )
4	bytes	rootcl		--- $0000_0002 Cluster Number of the Start of the Root Directory'
2	bytes	infosect	--- 0001 info = Sector Number of the FileSystem Information Sector  (from part start)
2	bytes	bbsect		--- 0006 boot = Sector Number of the Backup Boot Sector (from part start)
12	res				--- 00s
( 64 )
1	bytes	ldn		--- 80 logical drive number of partition
1	res	ldnh		--- 01 unused or high byte of ldn
1	bytes	extsig		--- 29 extended sig
4	bytes	serial		--- $63FE_C331 serial number of partition
11	bytes	volname		--- volume name
8	res	fatname		--- "FAT32   " always FAT32 - (don't trust)
2	res			--- align to a long for FREAD
( 90 )

--- --- --- --- --- --- --- --- --- --- --- --- --- ---

1	longs freeclusters	--- Read from info sector
1	longs lastcluster	--- Read from info sector
---	calculated from scan at mount
1	longs usedcl		--- Used Clusters
1	longs freecl		--- Free Clusters
1	longs used%		--- percentage used *100


1	longs mksiz		--- size used to create a file if file not found - 0 = none

--- --- --- --- --- --- --- --- --- --- --- --- --- ---
--- create room for some system variables in this table

1	longs	rootdir		--- sector address of root directory (MBR,GAP,BOOT,INFO,BACKUP,FAT1,FAT,ROOT)
1	longs	cwdir
1	longs	_fat1
1	longs	_fat2
1	longs	cwdsect
org@ sdvars -	constant sdsz	--- size of array used to hold all raw SD card related values + FAT etc

14	bytes cwd$



: SDIO
    $CA SDDO PAD!
    $53 SDCK PAD!
    $5B SDDI PAD!
    $62 SDCS PAD!
    $5A 13 PAD!
    $5A 14 PAD!
    SDCS LOW   SDCK LOW   SDDI HIGH  SDCS HIGH
;

: RELEASE 	SDCLK SDIO 0 SPIRD DROP  ;

( CHECK FOFR SD CARD INTERNAL WEAK PULLUP ON SDCS )
: SD? ( -- card )
    ~sdpins @ DUP IF DROP SDIO SDCS LOW SDCS FLOAT 10 us SDCS PIN@ THEN
;

\ CNT res
: SDRES ( -- response )
\	  retries for read until <> $FF
    50000 BEGIN DUP 0 SPIRD $FF AND DUP $FF = ROT 0<> AND WHILE DROP 1- REPEAT NIP
    DUP _sdres C!
;

: CMD ( data cmd -- res )
    SDCS LOW
    DUP _sdcmd C! SDCLK
\   write cmd and 32-bits of data
    SPIWC SPIWL
\  send a crc of CMD8 or CMD0 - others ignore value
    _sdcmd C@ IF $87 ELSE $95 THEN SPIWB
    SDRES
;

: ACMD ( data acmd -- res )
    0 55 CMD DROP CMD
;

: SDTOKEN ( marker -- flgX )
    SDDI HIGH
    10000
      BEGIN OVER 0 SPIRD <>
      WHILE 100 us 1- DUP 0= IF NIP EXIT THEN
      REPEAT
    2DROP TRUE
;

: DAT?			SDRES $FE = ;

: SDSTAT ( -- stat )	2 SDCLKS 0 13 CMD SDRES 8 << OR ;

: SDDAT! ( adr cnt -- ) \ read info into memory
	$FE SDTOKEN IF BOUNDS DO 0 SPIRD I C! LOOP 3 SDCLKS ELSE 2DROP THEN
	;



: CMD0		5 0 DO 0 0 CMD 1 = IF LEAVE THEN LOOP _sdres C@ ;
: CMD8		5 0 DO $1AA 8 CMD 1 = IF LEAVE THEN LOOP _sdres C@ ;
: CMD8?		SPIRL $1AA = ;


: ACMD41	30 bit 41 ACMD ;
: SLOWCLK	SDDI HIGH 200 0 DO SDCK HIGH 2 us SDCK LOW 2 us LOOP ;
: ACMD41?	0 1000 0 DO ACMD41 IF SLOWCLK ELSE 1+ LEAVE THEN LOOP ;

: !SD!
	SDIO 0 ocr ! cid 16 ERASE csd 16 ERASE
	CMD0 0EXIT
	CMD8  0EXIT
	CMD8? 0EXIT
	ACMD41? 0EXIT
\	operation conditions (voltages) note:
\ 	spec says do this before acmd41 but does not work
	0 58 CMD ?EXIT SPIRL DUP ocr ! 0EXIT
\	card information  FE - 03 53 44 53 43 36 34 47 80 84 F6 18 02 01 2A 79 - 53 DF FF FF
	0 10 CMD ?EXIT cid 16 SDDAT!
\	card specific data
	0 9 CMD ?EXIT csd 16 SDDAT!
	;


 ( CSD BIT FIELDS )

: XSHR
	0 DO
	0 bitbuf 16 BOUNDS
	  DO I C@ DUP 2/ ROT OR I C!
	    1 AND IF $80 ELSE 0 THEN
	  LOOP
	 DROP
 	LOOP
	;

\ read bitfield range from CSD register
: CSD@ ( bith bitl -- dat )
	csd
\ pri BITS@	( bith bitl adr -- dat )
	bitbuf 16 MOVE
 	DUP XSHR - 1+ bit
	1-
	0 bitbuf 12 + 4 BOUNDS DO 8 << I C@ OR LOOP
	AND
	;



--- Print the CID information in verbose REPORT format
: .MFG	PRINT" MFG= " .B ;

: .CARD
	PRINT"  CARD: "
	cid C@ .MFG
	SPACE cid 1+ 2 TYPE
	SPACE cid 3 + 5 TYPE
	PRINT"  REV" cid 8 + C@ .B
	PRINT"  #" cid 9 + U@ U.
	PRINT"  DATE:" cid 14 + C@ cid 13 + C@ >N 8 << + DUP 4 >>  2000 + PRINT >N PRINT" /" PRINT
	sdsize @ 2/ PRINT"  SIZE= " .DEC PRINT" kB "
	cid 15 + C@ 1 AND ?EXIT
	PRINT"  BAD CID "
	;

\ Initialise the SD card in SPI mode and return with the OCR
\ pub !SD ( -- ocr|false )
: !SD ( --- ocr|false )
	sdvars sdsz ERASE readsect ~~
	SDBUF $400 ERASE
	SD? IF
	  3 SDCLKS 20 0 DO
\	    attempt init and check if last operation was 9
	    !SD! _sdcmd C@ 9 =  IF LEAVE ELSE 512 SDCLKS THEN
	  LOOP SDIO 100 SDCLKS
	  69 48 CSD@ 1+ 10 <<  sdsize !
	THEN
	$80FFFFF1 6 CMD 0= IF SDBUF 64 SDDAT! THEN
	ocr @
	;




--- FILE PERMISSIONS ---


pub RO		wrens C~ ;			--- Read only - write protected
pri wm		wrens SET ;
pub RW		1 wm ;		--- Read/Write access - write enabled
pub RWC		3 wm ;		--- Read/Write & create
pub RWS		7 wm ;		--- Read/Write/System permission
pri RW?		1 wrens SET? ;




\ : DAT?		SDRES $FE = ;
pub L>S ( n -- offset sect )	DUP $1FF AND SWAP 9 >> ;
pri B>S ( bytes -- sectors )	L>S SWAP IF 1+ THEN ;


: SDRDBLK ( dst -- crc/flg )
	512 SPIRX \ sdsum !
	0 SPIRD SPIRD 31 bit OR
	;

--- read sector into memory and update sector number
: SDRD ( sector dst --  )
	OVER readsect !
\ pub SDRDX ( sector dst -- ) \ read sector into memory silently
	SDCLK SWAP 17 CMD DUP 0=
	IF DROP DAT?
	  IF SDRDBLK ELSE SDSTAT 2DROP 0 THEN
	THEN
\	save crc as a flag  -- only lower 16-bits of seccrc = crc with flag in b31
	DUP @sdrd ! seccrc !
	RELEASE
	;



pri SDWR?	@sdwr @ ;

pub SDWR ( src sect --  )
	@sdwr ~
	\ never sector 0 or if write protected unless RWS used
	DUP 0<>	 RW? AND 4 wrens SET? OR
	IF
	\ sector write command
	 3 SDCLKS  24 CMD
	  IF DROP
	\ 	start token, data
	  ELSE 3 SDCLKS $FE SPIWB 512 SPITX
	\ read data response
	    0 SDTOKEN $FF SDTOKEN AND
	  THEN
	\ always reset any RWS permissions after op - set crc in sdwr
	  4 wrens CLR   @sdwr ! RELEASE
	ELSE
	\ else write protect fail
	  2DROP
	THEN
	;

\ SD WRTIE MULTIPLE SECTORS
pub SDWRS ( ram sector bytes -- )
	@sdwr ~ RW?
	IF
	  B>S \ convert bytes to sectors
	  BOUNDS DO
	    DUP I SDWR 512 + SDWR? 0= IF LEAVE THEN
	  LOOP
	  RELEASE
	ELSE 2DROP THEN
	DROP
	;

\ Write contents of sector buffer to SD & clear flag
pub FLUSH	SDBUF readsect @ SDWR    wrflg C~ ;

\ only flush sector if it has been written to
pub ?FLUSH	wrflg C@ 0EXIT FLUSH ;


: SECTORF ( sect -- buf ) 	?FLUSH SDBUF SDRD SDBUF ;

--- read 1k at a time
: SECTORF2 ( sect -- buf )
	?FLUSH DUP SDBUF SDRD
	1+ SDBUF $200 + SDRD
	-1 readsect +!
	;

: SECTOR ( sect -- sdbuf )
	DUP readsect @ <> IF SECTORF ELSE DROP SDBUF THEN
	;

: .BUF		SDBUF $200 DUMP ;
: .SECTOR	CR PRINT" SECTOR #" I .L SECTOR $200 DUMP	 ;
: .SECTORS	BOUNDS DO I .SECTOR LOOP ;



--- return starting sector at current FILE
pub @FILE ( -- sector )			filesect @ ;

pub @OPEN ( -- sector )			opensect @ ;

--- Set the starting sector for file access
pub OPEN-SECTOR ( sector -- )		_fread ~ filesect ! ;








	( virtual memory )


--- Convert SD file address to hub ram address where file is buffered (897 cycles= 4,485ns @200MHz)
pub SDADR ( sdadr -- ramadr )	L>S @FILE + SECTOR + ;

--- fetch long from SD virtual memory in current file
pub SD@ ( xaddr -- long )	SDADR @ ;
pub SDH@			SDADR H@ ;
pub SDC@ ( sdaddr -- byte )	SDADR C@ ;


--- store long to SD virtual memory in current file
pub SD! ( data xaddr -- )	SDADR ! wrflg C~~ ;
pub SDC!			SDADR C! wrflg C~~ ;

--- select SD for DUMP method : use: 0 $200 SD DUMP
pub SD				['] SDC@ ['] SDH@ ['] SD@ DUMP! ;


\ #############################################################
\ #############################################################
\			FAT32
\ #############################################################
\ #############################################################


--- at ROOT sector
pub @ROOT ( -- sector )		rootdir @ ;
pub @CWD			cwdir @ ;
pub CWD!			cwdir ! ;

--- at BOOT sector
pub @BOOT ( -- sector )		parts 8 + @ ;
pri @FAT ( fat# -- sector )	s/f @ * @BOOT rsvd H@ + + ;

pri FATSZ ( -- fatsz )		sdsize @ @BOOT - ;



--- open directory sector as a file

--- open the current working dir as if it were a file
pub CWD			@CWD OPEN-SECTOR ;

--- Open the root folder as a file
pub ROOT		( " /" cwd$ $! ) @ROOT CWD! CWD ;

--- Use the MBR as a file
pub MBR 		0 OPEN-SECTOR ;

--- access FAT1 or FAT2 as a file
pub FAT1		_fat1 @ OPEN-SECTOR ;
pub FAT2		_fat2 @ OPEN-SECTOR ;


--- change current working directory
pub CD# ( sect -- )	cwdsect ! ;


--- Close file by flushing, switching to read-only and use sector 0
pub FCLOSE		?FLUSH RO MBR readsect ~~ ;
\ pub CLOSE-FILE




\ *** DIRECTORY STRUCTURE ***

\ public --- 8.3 directory entry structure
0 longs dirrcd
\ private
8 bytes fname
3 bytes fext
1 bytes fatr		---  (0:read-only, 1:hidden, 2:system, 3:volume label, 4:directory, 5:archive, 6-7: undefined)
1 res 0
1 bytes fcms		--- file creation time - milliseconds
2 bytes fctime
2 bytes fcdate
2 bytes fadate
2 bytes fclsth
2 bytes ftime
2 bytes fdate
2 bytes fclstl
4 bytes fsize

\ public
2 bytes	diridx		--- directory index
16 bytes file$



pub FSIZE@	fsize @ ;


		( *** CLUSTERS *** )


{
	CLUSTER CHAIN CODES
If value => $0FFF.FFF8 then there are no more clusters in this chain.
$0FFF.FFF7 = bad
0 = free

}
pri @CLUSTER ( index -- xadr )
    FAT1 2* 2*
;

pri CLUSTER@ ( index -- cluster )
    @CLUSTER SD@
;

pri FreeClusters? ( size -- #clusters clust1 )
\ calculate clusters required
     B>S s/c C@ U/ ( clusters )
      0
     BEGIN
\       --- find a free cluster
       BEGIN DUP CLUSTER@ WHILE 1+ REPEAT
\       --- check for sufficient contiguous clusters ( clusters index )
       0 OVER 2 PICK BOUNDS DO I @CLUSTER SD@ OR DUP IF NIP I SWAP LEAVE THEN LOOP
       ( clusters chain flag )
     WHILE
       1+
     REPEAT
;




--- count number of clusters allocated from start cluster
pub CLUSTERS? 	( cluster# -- clusters )
\ scan through fat1 as a file
 	filesect @ SWAP
	0 SWAP  ( cnt sect -- )
	BEGIN B++ CLUSTER@ DUP $0FFFFFF8 >= UNTIL DROP
	SWAP filesect !
	;

--- Convert Directory address to first cluster
pub FCLUSTER ( -- cluster#0 )
\	cluster low and cluster high combined
	fclstl H@ fclsth H@ 16 << +
	;

pri C>S2
	s/c C@ * @ROOT +
	;

--- Convert Cluster to sector
pub C>S ( clust# -- sector )
	rootcl @ - C>S2
	;

--- read Directory cluster and convert to starting sector
pub FSECTOR ( -- sector )
	FCLUSTER C>S
	;

--- convert a sector to a cluster ( result 0 = out of range  ; 2 = 1st )
pub SECT>CLST ( sector -- cluster )
	@CWD - s/c C@ U/ 2+
	;

--- convert sector to total allocated clusters
pri SECT>CLST# ( sector -- clusters )
	SECT>CLST CLUSTERS? s/c C@ * 9 <<
	;




pri ?FREE \	Calculate used/unused
    0 0 usedcl 12 ERASE
    sdsize @ @ROOT - ( data-sectors )
    s/c C@ U/ ( data-clusters ) 2+ ( where root is cluster 2 )
    2 DO I CLUSTER@ IF B++ ELSE 1+ THEN LOOP
    2DUP + 2 PICK 10000 * SWAP U/
    used% ! freecl ! usedcl !
;



pub GETFAT
\	read fat32 as a byte array
	@BOOT SECTORF fat32 90 MOVE
\	sectors rsvd to fat1  ... size of fat tables
	rsvd H@                s/f @ fats C@ *  + ( offset from fat boot )
\	rootcl @ 2- C>S2
	hidden @ + 	rootdir !
\	'' save time by precalculating FAT table addresses@
	0 @FAT _fat1 ! 1 @FAT _fat2 !
	\ ?FREE
\	Open info sector
	@BOOT infosect H@ + OPEN-SECTOR
	$1E8 SD@ freeclusters !
	$1EC SD@ lastcluster !
	;



\ find total allocated cluster bytes for this byte
pub FMAX ( -- bytes )		FCLUSTER CLUSTERS? s/c C@ * 9 << ;

pub GETPART
	0 SECTORF $1FE + H@ $AA55 <> IF PRINT" INVALID PARTITION" THEN
	$1BE SDBUF + parts 66 MOVE
	;

pub !MOUNT
	!FAULT
	SD? 0EXIT \ ( !SD DROP !SD DROP ) !SD 0EXIT
	!SD 0EXIT
	1 SECTORF DROP
	!SD 0EXIT
	fat32 cwdsect fat32 - ERASE
	RO \ disable sector sdwr
	GETPART
	GETFAT
	ROOT
	serial U@ mntd !
	1 MB mksiz !
	;

pub MOUNT
	!MOUNT SD? IF .CARD THEN
	;


\	MOUNT FAT32 if not already mounted
pub ?MOUNT
	SD? serial U@ mntd @ = AND mntd @ 0<> AND 0=
	  IF 10 ms !MOUNT ( $0D KEY! ) ELSE SD? 0= IF mntd ~ THEN THEN
	;

pub MOUNTED?
	?MOUNT mntd @
	;








		( DIR.FTH  )


              ( *** DIRECTORY *** )
pub >DIR		diridx H@ CWD 5 << SDADR ;

\ reads relevant dir sector in using index
\       returns with the address in the buffer

pub IDX>DIR ( Index -- diradr )	diridx H! >DIR ;

\ read the nth directory entry into the dir buffer (index saved in diridx)
pub GETDIR ( index -- )	IDX>DIR fname 32 MOVE ;
pub SAVEDIR		fname >DIR 32 MOVE RW FLUSH RO ;
pub OPENDIR		FSECTOR OPEN-SECTOR ;
pri FTYPE ( src cnt subs -- ) -ROT BOUNDS DO I C@ OVER AEMIT LOOP DROP ;

\ Print the file name of the current dirbuf
pub .FNAME
\ skip invalid index/entry
   fname C@ $20 >
   IF
     $10 fatr SET? IF $5B EMIT ELSE SPACE THEN
     fname 8 $20 FTYPE
     fext C@ $20 > IF $2E EMIT fext 3 $20 FTYPE  ELSE 4 SPACES THEN
     $10 fatr SET? IF $5D EMIT ELSE SPACE THEN
   THEN
;

\ update file modification/create time in dir buf
\ Time (5/6/5 bits, for hour/minutes/doubleseconds)
pub FTIME! ( #hhmmss field -- )
    SWAP HMS 11 << SWAP 5 << + SWAP 2/ +
    SWAP H!
;

\ update file modification/create date in dir buf
\ Date (7/4/5 bits, for year-since-1980/month/day)
pub FDATE! ( #yymmdd field -- )
    \ arrange as decimal YYMMDD from 1980 ( 2000.0000 + 1980.0000 - )
    SWAP DUP 20000000 < IF 200000 + THEN
    HMS 9 << SWAP 5 << + +
    SWAP H!
;

\ DATE TIME STAMPING \
{
\ Update the modified time and date of the current file
pub MODIFIED ( -- )
      TIME@ ftime FTIME!
      DATE@ fdate FDATE!
      SAVEDIR
      ;
pub CREATED ( -- )
      TIME@ fctime FTIME!
      DATE@ fcdate FDATE!
      SAVEDIR
      ;
}

\ diagnostic directory entry dump
pub .DIRHEX		GETDIR fname $20 DUMP ;

\ check sector for any non-zero data - something
pri ACTIVE? ( -- flg )	seccrc @ $80000000 <> ;

\ Print dir entry according to method set in ~dir
0 variable ~dir
pri .DIR		~dir @ ?DUP IF execute THEN ;

pri DODIR
    fq C~   FCLOSE
    s/c C@ 4 << 0
    DO \ continue if the whole sector has entries
      I GETDIR ACTIVE?
        \ valid entries  not msb set         nor deleted
      IF fatr C@ $0F >   fname C@ $80 < AND  fname C@ $3F <> AND
        IF .DIR THEN  ELSE LEAVE  THEN
    LOOP
;

pub LIST: ( method -- )	~dir ! DODIR ;
pri DIR: ( method -- )	?MOUNT CR volname 11 TYPE LIST: ;

1 bytes ~x

pri DODIRX		fq C@ ~x C@ MOD 0= IF CR THEN .FNAME 4 SPACES fq C++ ;
pub DIRX ( n -- )  	~x C! ['] DODIRX DIR:  ;

pub DIRW		6 DIRX ;
pub DIRN		1 DIRX ;

    ( DIRECTORY LIST FORMATTING )

pri .ASMONTH ( index -- )    >N 1- 3 * S" JanFebMarAprMayJunJulAugSepOctNovDec" DROP + 3 TYPE  ;

\ print date in Unix format
pri .ASDATE ( fdate -- )    DUP 5 >> .ASMONTH   $1F AND 3 .DECS ;


pri .ASTIME ( ftime -- )    DUP 11 >> .DEC2 $3A EMIT   5 >> $3F AND .DEC2 ;
\ print as year/month/day
pri .ASYMD		DUP 9 >> 1980 + .DEC4  DUP 5 >> >N $2D EMIT .DEC2 $1F AND $2D EMIT .DEC2 ;

\ print the file date from 1980
pub .FDATE		fdate H@ .ASYMD  ftime H@ .ASTIME ;


pri .DHD		CR PRINT"      NAME...........ATR.1ST.SECTOR...MODIFIED.............FILE.SIZE.......MAX.SIZE.....HEADER" ;

pub ASDIR
    CR diridx H@ 3 .DECS SPACE .FNAME  4 SPACES
    \ print atr
    fatr C@ DUP .B SPACE 8 AND 0=
    IF \ not a directory - so list file info
      \  $0000_9678   2018-12-24 02:56
      FSECTOR .L     3 SPACES       fdate H@ .ASYMD  SPACE ftime H@ .ASTIME
      \  display file size
      SPACE FSIZE@ 14 .DECS
    THEN
;
pub DIR			.DHD ['] ASDIR DIR: ;

\ print the first 20 bytes of the file
pri .HEADER		3 SPACES FSECTOR SECTOR 20 $2E FTYPE ;
\         print total allocated memory via assigned cluster count
pri .ASIZE		FSIZE@ 27 >> NOT IF  ." /" FMAX 14 .DECS THEN ;

pri DODIR++
      ASDIR SPACE PRINT" - created "
      fcdate H@ .ASYMD SPACE
      fctime H@ .ASTIME
      fcms C@ $2E EMIT 3 .DECS PRINT" - accessed "
      fcdate H@ .ASDATE
;
pub DIR++			.DHD ['] DODIR++ DIR: ;

pri DODIR+		ASDIR .ASIZE .HEADER ;
pub DIR+		.DHD ['] DODIR+ DIR: ;

--- open a file using the directory name index
pub FOPEN# ( index -- )	GETDIR OPENDIR 	;



16 bytes G$
pub GET$ ( -- adr )
	G$ 16 ERASE
	TOKEN ?DUP IF 0 DO I OVER + C@ G$ I + C! LOOP THEN DROP
	G$
;

\ : GET	$20004142 C! GET$ $20 $20004142 C! ;

--- compare strings for len bytes
pub C$= ( adr1 adr2 len -- flg )
	BOUNDS DO C@++ I C@ <> IF 0= LEAVE THEN LOOP
	  0<>
	;

: CREATED ;
: MODIFIED ;



\ convert file$ to 8.3 format in dirbuf
pub AS8.3 ( nstr -- )
	fname 11 $20 FILL
	fname OVER LEN$ 0
	DO ( file$ fname )
	  OVER I + C@ a>A
	  DUP $2E = IF 2DROP fext ELSE OVER C! 1+ THEN
	LOOP
	2DROP
	;



12 bytes f83$
\ find current f83 name index+1 to directory entry
pri FIND-FILE ( str -- index+1 )
    DUP C@ $2F = IF 1+ ROOT THEN
\   convert and save in X$ for comparisons
    AS8.3 fname f83$ 11 MOVE
    0  s/c C@ 4 << 0
    DO
\     buffer dir enty into memory and check
      I GETDIR fname f83$ 11 C$=
        IF DROP I 1+ LEAVE THEN
    LOOP
;




\ Find the next free directory entry (just looks for a null but could do more)
\ no range checking just to keep it simple for now
\ dir index in diridx and entry in fname
pub FREEDIR
---
    s/c C@ 4 << 0 DO I GETDIR fname C@ 0= IF LEAVE THEN LOOP
;

pri ClaimClusters ( for from -- from )
     FAT1 \ RW
     \ link clusters
     DUP 3RD BOUNDS DO 1 I + I @CLUSTER SD! LOOP
     ( #clusters clust1 ) \ mark end cluster
     SWAP OVER + 1- $0FFFFFFF SWAP @CLUSTER SD!
     FLUSH
     ;




\ Create a new file by name but if it already exists then delete the old one and reuse the dir entry.
\ if size = 0 then max = 4GB

pub FCREATE$ ( size namestr --  )
	FREEDIR
	\ as 8.3 and write the name of the file to the directory buffer
	fname 32 ERASE AS8.3  $20 fatr C!
	\ Set size of file to maximum & preallocate clusters
	DUP fsize ! FreeClusters? ClaimClusters ( from )
	\ write first cluster
	CWD L>W fclsth H! fclstl H!
	\ add directory record to directory
	CREATED MODIFIED SAVEDIR
    ;

: FCREATE ( size <name> -- )  GET$ FCREATE$ ;

: COPY ;
: PASTE ;

: FSAVE ( src bytes -- )
    @FILE
    IF
      @FILE SWAP SDWRS
    ELSE
      2DROP PRINT" No file "
    THEN
    DROP
;


\ Force file to open  - create to size if not found
pub FSIZE! ( size -- )	mksiz ! RWC ;


\ pub OPEN-FISLE$
pub FOPEN$ ( str -- flg )
	DUP file$ $!
\	check mount and find 8.3 file name
	?MOUNT FIND-FILE
\	if found then convert directory entry to starting sector
	IF FSECTOR
	ELSE \ if create flag set then create a preallocated size file  - else fail
	  2 wrens SET? IF mksiz @ file$ FCREATE$ FSECTOR  ELSE 0 THEN
	THEN
\	open the sector although 0 = fail (mbr sector 0 is protected anyway)
	OPEN-SECTOR  @FILE DUP opensect !
	;

pub REOPEN-FILE		file$ FOPEN$ ;


\ Get the file name and try to open it, return with sector
pri OPEN-FILE ( <name> -- filesect )	GET$ SPACE FOPEN$ ;

pub FOPEN ( <name> -- )
\ grab parameters and permissions then open-file
	OPEN-FILE ?DUP
	IF PRINT" Opened @ " .L
	ELSE PRINT" - File not found! " THEN
	;

pub CD$		@FILE CWD!  file$ cwd$ $! ;

pub CD		FOPEN CD$ ;


( TRIED THIS FIRST SINCE i HAD A CARD WITH A CORRUPTED SECTOR 0 )
\ NOTE! Issue RWS permissions before using (safety)
pub FORMAT.MBR
	SDBUF 512 ERASE
\	copy boot config table for reference in unused area at start
\	0 SDBUF $100 CMOVE
\	MBR NAME OF FORMAT TOOL
	S" Mecrisp FLAT32" SDBUF 3 + SWAP MOVE
\ 1023, 254, 63
	parts 66 ERASE
\	valid partition flags
	$AA55 parsig H!

\	$80 parts C!
\	fs+CHS
	$0CFFFFFE parts 1+ U!
\ This sets up 4MB hiddenbefore parition according to SD compliance (But >32GB 16MB)
	sdsize @ 70000000 U> IF $8000 ELSE $2000 THEN  parts 8 + !
\	TOTAL SECTORS = SDSIZE-<hidden>
	FATSZ parts 12 + !
\	copy parts to buffer
	parts $1BE SDBUF + 66 MOVE
\	Write MBR
	SDBUF 0 SDWR
	;



	( MORE SHORTCUTS )

: ?QS		>R >R .S R> R> ;
: !QS		>R !SP R> 0 ?QS ;
' ?QS	$11 CTRL!
' !QS	$13 CTRL!
' WORDS $17 CTRL!


: DEBUG
	DEPTH 0< IF !SP ELSE .S THEN
	.RSTACK
	." TIB"
	TIB $50 DUMP
	;
: ?DEBUG	>R >R DEBUG R> R> ;
' ?DEBUG $04 CTRL!

: .CTRLS		32 0 do i ctrls @ ?DUP IF CR I .B  ."  ^" i $40 + emit space >NFA CTYPE THEN loop ;
' .CTRLS $1F CTRL!



	( *** I2C BUS *** )

{
	I2C & RTC DRIVE
Simple bit-bashed interface for RP2040
Also includes RTC driver for RV-3028 I2C RTC and UB3 bridge
TO DO: use I2C hardware (but keep this as reference)
}


byte acks	--- acks flags
byte i2cdev	--- I2C DEVICE ADDRESS
byte ~sda	--- SDA PIN
byte ~scl	--- SCL PIN

25 variable ~idly	--- I2C bit timing delay

pub *SDA	~sda C@ ;
pub *SCL	~scl C@ ;

pub I2CPINS ( scl sda -- ) ~sda C! ~scl C! ;
--- setup I2C pins with internal pullups and float them
pri !I2C		*SDA PU *SCL PU *SCL FLOAT *SDA FLOAT ;
pub I2C.DLY		~idly H@ 0 DO LOOP ;

\ pub I2C.CLK		*SCL HIGH *SCL FLOAT BEGIN *SCL PIN@ UNTIL I2C.DLY *SCL LOW I2C.DLY ;
\ pub I2C.CLK?		*SDA PIN@ I2C.CLK ;
( Patch for CCS811 clock stretching - Pete Foden )

pri I2C.CLKH		I2C.DLY *SCL HIGH *SCL FLOAT BEGIN I2C.DLY *SCL PIN@ UNTIL ;
pri I2C.CLKL		I2C.DLY *SCL LOW I2C.DLY ;
pub I2C.CLK? ( -- sda )	I2C.CLKH	*SDA PIN@ *SDA FLOAT 	I2C.CLKL ;
pub I2C.CLK  		I2C.CLKH				I2C.CLKL ;

--- patch: allow for clock stretch
pub I2C.STOP		!I2C *SDA LOW I2C.CLKH *SDA FLOAT  I2C.DLY ;
pub I2C.START		!I2C acks C~  *SCL HIGH *SCL FLOAT  I2C.DLY *SDA LOW  I2C.DLY *SCL LOW  I2C.DLY ;
--- I2C RESTART - ensure bus is idle then restart
pub <I2C>		*SDA PIN@ 0= IF I2C.STOP THEN I2C.START ;

{
( TAQOZ METHOD )
I2C.CLOCK   waitx   i2cdly
            drvh    sclpin
            flth    sclpin      ' then float to let the pullup work'
I2C.CNTN    waitx   i2cdly
            testp   sclpin wc   ' wait while scl is low'
            if_nc   jmp #I2C.CNTN
            testp   sdapin wc   ' read SDA into wc'
            waitx   i2cdly
            drvl    sclpin
    ret_    waitx   i2cdly
}

--- default I2C device address
\ $A4 variable i2cdev
pub I2CPUT ( data -- ack )
    8 0 DO
    DUP 7 >> *SDA PIN! I2C.CLK 2* LOOP
    *SDA FLOAT
    DROP *SDA PIN@ I2C.CLK
;
pub I2CGET ( ack -- data )
    *SDA FLOAT
    0 8 0 DO 2* I2C.CLK? OR LOOP
    SWAP 1 AND *SDA PIN! I2C.CLK
;

pub I2CRD? ( adr -- ack )	I2C.STOP 1 OR I2C.START I2CPUT 0= ;
pub I2CRD ( adr -- )		I2CRD? DROP ;
pub I2CWR ( adr -- ) 		I2C.STOP $FE AND I2C.START I2CPUT DROP ;
pub I2C! ( data -- )		I2CPUT 0= 1 AND acks C+! ;
pub I2C@ 			0 I2CGET ;
pub nakI2C@			TRUE I2CGET ;

pub I2CRDREG ( dev reg -- )	OVER I2CWR I2C! I2CRD ;

	( I2C DUMP SUPPORT )

pub I2CC@ ( reg -- dat )	i2cdev C@ I2CWR I2C!    i2cdev C@ I2CRD 0 I2CGET ;
--- Switch DUMP source to selected I2C device (use 8-bit addresses)
pub I2C ( dev -- )		i2cdev C! ['] I2CC@ DUP DUP DUMP! ;

	( I2C DEVICE SCAN )

pub lsi2c	$100 0 DO I I2CRD? IF I ."  $" .B THEN 2 +LOOP ;



	( *** RTC *** )

--- these two may be combined with current bms to derive the time without reading rtc
long bdate	--- data at reset
long btime	--- time at reset
long bms	--- ms time at reset

byte ~rtc
--- rtc buffer
byte @sec
byte @min
byte @hour
byte @day
byte @date
byte @month
byte @year


	( *** RV-3028-C7 RTC *** )

( Changed @RTC to use a variable instead to allow for other RTC chips)
\ $A4 variable ~rtc
pub @RTC			~rtc C@ ;
pub RTC? ( -- flg )		@RTC I2CRD? I2C.STOP ;

--- fetch reg from 8-bit reg	    ADDR      REG   ADDR  DATA
pub I2CREG@ ( reg dev -- dat )	DUP I2CWR SWAP I2C! I2CRD nakI2C@ I2C.STOP ;
pub RTC@ ( reg -- byte )	@RTC I2CREG@ ;

pub I2CREG! ( dat reg dev -- )	I2CWR I2C! I2C! I2C.STOP ;
pub RTC! ( byte reg -- )	@RTC I2CREG! ;
--- RTC BCD STORE - store byte as BCD in RTC register
pub RTCB! ( bcd reg -- )	SWAP 10 U/MOD 4 << OR SWAP RTC! ;

	( RTC DUMP )
pub RTC				['] RTC@ DUP DUP DUMP! ;

	( *** HIGH LEVEL TIME KEEPING RTC INTERFACE *** )

--- fast sequential read of first 7 time keeping registers
pub RDRTC
	@sec 7 ERASE
	@RTC 0EXIT
--- start from reg 0
	I2C.START @RTC I2CPUT ?EXIT  0 I2C!
	<I2C> @RTC 1+ I2C!    @sec 6 BOUNDS DO I2C@ I C! LOOP
	nakI2C@ @year C! I2C.STOP
	;

\ Init RTC configs etc ( not time ) on boot
pri !RTC
	@RTC $D0 = IF $B4 $37 RTC! 0 $10 RTC! 0 $0F RTC! THEN
;

\ checks for different RTC chips and sets them up
pri ?RTC
	~rtc C~
	@sec 7 ERASE
	$D0 I2CRD? IF $D0 ~rtc C! EXIT THEN
	$A4 I2CRD? IF $A4 ~rtc C! EXIT THEN
;


pub >HMS ( s m h -- hhmmss )	100 * + 100 * + ;
pub BCDS ( bcds -- dec rem ) 	DUP >N OVER 4 >> >N 10 * + SWAP 8 >> ;
pub BCD>DEC ( bcds -- val )	BCDS BCDS BCDS DROP >HMS ;

\ RV-3028 supports UNIX time in seconds from 1970
pub UTIME@ ( -- secs )		0 27 4 BOUNDS DO I RTC@ OR 8 >> LOOP ;
pub UTIME! ( secs -- )		27 4 BOUNDS DO DUP I RTC! 8 >> LOOP DROP ;

pub TIME! ( hhmmss -- )		!RTC 100 U/MOD SWAP 0 RTCB! 100 U/MOD SWAP 1 RTCB! 2 RTCB! ;
pub DAY!			7 AND 3 RTC! ;
pub DATE! ( yymmdd -- )		!RTC 100 U/MOD SWAP 4 RTCB! 100 U/MOD SWAP 5 RTCB! 6 RTCB! ;

--- read bcd fields and mask before converting to decimal
pub TIME@			RDRTC @sec U@ $3F7F7F AND BCD>DEC ;
pub DATE@			RDRTC @date U@ $FF1F3F AND BCD>DEC ;
pub DAY@			@day C@ 7 AND 1 MAX ;

pub .DT				DATE@ 6 U.R $2D EMIT TIME@ 6 Z U.R ;

pub .HMS ( n ch -- )		>R HMS 2 Z U.R R@ EMIT 2 Z U.R R> EMIT 2 Z U.R ;
pub .DATE			DATE@ ." 20" $2F .HMS ;   \ ".AS" 20##/##/## "  ;
pub .DAY			DAY@ 1- 3 * s" MONTUEWEDTHUFRISATSUN" DROP + 3 TYPE ;
pub .TIME			TIME@ $3A .HMS ;
pub .FDT			.DATE SPACE .DAY SPACE .TIME ;

' .FDT $14 CTRL!




	( *** TIMERS *** )


{
timer: mytimer
100000 mytimer TIMEOUT	--- timeout in 100ms using mytimer
mytimer TIMEOUT?	--- check timeout status

}
pre TIMER:			2 (longs) ;

pub TIMEOUT ( us timer -- )	cycles OVER ! 4 + ! ;
pub TIMEOUT? ( timer -- flg )	2@ SWAP cycles - ABS < ;






: UQUERY	yellow pen bold query plain ;


\ #############################################################
\ #############################################################
\		INIT
\ #############################################################
\ #############################################################


: !TACHYON
	!FAULT DATA $400 ERASE !POLLS
	['] uquery ~query !
	['] TACHYON QUIT!
	bold yellow pen CR *TACHYON* CR
;

	( PICO PINS )

25 constant PICOLED
23 constant PS		\ Pico pwm/pfm regulaotr mode


	( *** PCB SPECIFIC INIT *** )


32 BUFFER: pcb
: .PCB		green PEN PRINT" PCB: " pcb C@ IF pcb 1+ PRINT$ ELSE ." UNKNOWN" THEN ;
: PCB!		pcb 32 ERASE pcb 1+ SWAP MOVE pcb C! ;

: !PICO
	PS HIGH !ADC $50 29 PAD!
	3 PICOLED FLASHES
	PRINT" VSYS = " .VSYS  PRINT"  @" .TEMP
;


{
	( MAKER PI RP2040 )
18 	constant NEOPIXEL
8	constant M1A
9	constant M1B
20	constant BTN1
21	constant BTN2
22	constant BUZZER
}
: MAKERPI
	100 ms !TACHYON
\	$0F0C0B0A SDPINS ( &15.12.11.10 )
	22 spkr C!
	18 NEOPIN $200000 NEO!
	%101 S" MAKER PI RP2040" PCB! ( b0 = Pico )
	3 2 I2CPINS ?RTC ~rtc C@ IF CR .FDT THEN
	!PICO BEEP
	CR .PCB plain
;



{
	( MAKER PI PICO )
16 constant ESP.8
17 constant ESP.1

18 constant BUZZER
18 constant LA
19 constant RA
20 constant SW20
21 constant SW21
22 constant SW22
23 constant PS		\ Pico pwm/pfm regulaotr mode
25 constant PICOLED
28 constant NEOPIXEL
}
 ( microSD SPI mode )
{
10 constant SDCK
11 constant SDDI	--- CMD
12 constant SDDO	--- SDDAT0
15 constant SDCS	--- SDDAT3
13 constant SDDAT1
14 constant SDDAT2
: INIT
	100 ms !TACHYON
	%10000011 S" GMIS SOLAR REGULATOR" PCB!
	3 2 I2CPINS  PICO CR .PCB plain
;
}

pub MAKERPICO
	100 ms !TACHYON
	$0F0C0B0A SDPINS ( &15.12.11.10 )
	18 spkr C!
	28 NEOPIN $200000 NEO!
	%11 S" MAKER PI PICO" PCB! ( b0 = Pico )
	SD? IF cyan pen CR PRINT" MOUNTING " MOUNT THEN
	3 2 I2CPINS ?RTC ~rtc C@ IF CR .FDT THEN
	CR !PICO BEEP
	CR .PCB plain
;

--- divert console to the ESP01 on 16 and 17
pub ESPCON	0 0 FNC  1 0 FNC  16 #UART 17 #UART  ( UART0 115200 BAUD ) ;
pub SERCON	16 0 FNC 17 0 FNC 0 #UART 1 #UART ;

256 bytes chats

pri TKEY? ( us -- )	cycles BEGIN 2DUP cycles - ABS  < KEY? OR UNTIL 2DROP KEY? ;

pri ESPCOM
     5 ms ESPCON 115200 BAUD chats SWAP TYPE $0D EMIT
     chats BEGIN 20000 TKEY? WHILE KEY OVER C! 1+ 0 OVER C! REPEAT
     DROP 5 ms SERCON 921600 BAUD chats PRINT$
;
pub ESPCHAT
   BEGIN
     UART0 921600 BAUD chats 64 ACCEPT ?DUP
   WHILE
     ESPCOM
   REPEAT
;

--- Single line ESP command and response
pub AT	  $41 chats C! $54 chats 1+ C! chats 2+ 66 ACCEPT ?DUP IF 2+ ESPCOM THEN ;


( AT+CWJAP=<ssid>,<pwd>[,<bssid>] )


pub PICO
	100 ms !TACHYON
	%01 S" RASPBERRY PI PICO" PCB!
	CR !PICO
	CR .PCB plain
;

{
	*** MAIN INIT ***
Include your board specific inits here (or call this from your INIT)
Most drivers are runtime configurable so there is no need to modify the
source code other than this INIT, your INIT, or your INIT that calls this INIT

}


\ : INIT		MAKERPICO ;
\ : INIT		MAKERPI ;

: INIT		PICO ;

{
README: USER INITS
For user specific inits just create a new INIT and
call !TACHYON first up, then any specific inits

OR SIMPLY ase a predefined INIT after loading the source:
compiletoflash
: INIT  MAKERPICO ;
compiletoram
SAVE

}


compiletoram
*END*
