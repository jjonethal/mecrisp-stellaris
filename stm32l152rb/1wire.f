\ 1-wire
\ Based on source code:
\ - Tachyon Forth for the Parallax Propeller P8X32A (1WIRE.FTH)
\ - amForth, SPF4
\ Connection: PA5 - dq
\ us & ms words required !!!

9 buffer: scratchpad

: 1w.init %11 5 2* lshift gpioa_pupdr bic! ;
: 1w.output %01 5 2* lshift gpioa_moder bis! ;
: 1w.input %01 5 2* lshift gpioa_moder bic! ;
: 1w.out0 32 16 lshift gpioa_bsrr bis! ;
: 1w.out1 32 gpioa_bsrr bis! ;
: 1w.in 32 gpioa_idr bit@ ;

: 1w.reset ( -- f )
	1w.init
	1w.output 1w.out0 470 us 1w.out1
	1w.input  60 us
	1w.in 0=  400 us
;

: 1w.bitwr ( bit -- )
	1w.output 1w.out1 1w.out0 1 us
	%1 and 
	if 
		 6 us 1w.out1 64 us   
	else 
		64 us 1w.out0 6 us  
	then
	( 1 us)  1w.output 1w.out1 1w.input
;

: 1w.bitrd ( -- bit )
	1w.output 1w.out0 1 us 1w.out1 1w.input
	1 us  1w.in
	20 us  1w.output 1w.out1
;

: 1w! ( c -- )
	8 0 do dup 1w.bitwr 1 rshift loop
	drop
;

: 1w@ ( -- c )
	0 8 0 do 1 rshift 1w.bitrd if $80 or then loop
;

: .1w ( n -- ) 0 ?do 1w@ hex . decimal space loop ;

: readrom $33 1w! ;
: skiprom $cc 1w! ;
: matchrom $55 1w! ;
: convertt $44 1w! ;
: readscr $be 1w! ;
: 1wscmd 1w.reset drop skiprom ;
: rdromh 1w.reset drop readrom 8 .1w ;
\ : rdscrh 1wscmd readscr 9 0 do 1w@ scratchpad i + c! loop ;
: rdscrh readscr 9 0 do 1w@ scratchpad i + c! loop ;

\ ********************* crc8 **********************
$0      variable    msb#
$01     constant lsb#
$18     constant poly-8     \ x**8  + x**5  + x**4 + 1
$0	variable	polynom

: lsb  lsb# and ;
 
: crc8! poly-8  polynom ! $80 msb# ! ;
              

        : crc   ( 's c  --- crc )
          8 0
            do
               over over xor lsb 
               if swap 
               polynom @ xor 1 rshift  msb# @ or
               else   swap 1 rshift
               then   swap 1 rshift
            loop 
            drop
            ;
: $crc   ( a # --- crc )
 crc8!
            0 -rot over + swap
            do   i c@ crc loop
            ;


0 variable 1W.lastdisc        \ used as byte variable to hold last discrepancy
0 variable 1W.doneflag   
0 variable 1W.rombit            \ used as byte variable, 1..64
0 variable 1W.discmark

: bit! if cbis! else cbic! then ;

: mask 1 swap lshift ;

8 buffer: 1W.romid
320 buffer: 1Wdevs
0 variable 1Wcnt

\ set the bit 1..32 given by 1W.rombit in buffer 1W.romid to flag value f
: 1W.!rombit ( f -- )
    1W.rombit @ 1- 8 U/MOD ( -- f bit# byte# )
    1W.romid + ( f bit# addr )
	swap mask swap  ( f  bitmask addr )
    rot bit!
;

\ fetch the bit 1..32 given by 1W.rombit from buffer 1W.romid to flag f
: 1W.@rombit ( -- f \ f is 0 or non-0 not necc. 1 )
    1W.rombit @ 1- 8  U/MOD ( -- bit# byte# )
    1W.romid + c@ ( -- bit# byte )
    swap mask ( -- byte bitmask )
    and
;

\ single bit operations to read and write 1-wire bus
: 1W.BIT@ ( -- bit )    1w.bitrd 0<> 1 and  ; \ gives bit as 0 or 1
: 1W.BIT! ( bit -- )    0<> 1w.bitwr ;  \ takes bit as 0 or 1

\ --- SEARCH ROM ROUTINES ---

: erase 0 fill ;


0 variable 1Waddrs

\ --- clear variables used in search
: 1W.NEWSEARCH ( --  )   
  0 1W.lastdisc !
  0 1W.doneflag !    
  1 1W.rombit !
    1W.romid 8 erase
    1Wdevs 320 erase
   0 1Wcnt !
;
: _srp1 
 ?DUP 0=             ( 0 BA false  |  0 true )
IF ( bitA = bitB = 0?)                ( 0 )
	1W.rombit @ 1W.lastdisc @ =   ( 0 flag )
	IF  1 1W.!rombit                ( 0 )
	ELSE 1W.rombit @ 1W.lastdisc @ >  ( 0 flag )
                        IF  0 1W.!rombit
                            1W.rombit @ 1W.discmark !  ( 0 )
                        ELSE 1W.@rombit 0= IF 1W.rombit @ 1W.discmark ! THEN  ( 0 )
                        THEN   ( 0 )
	THEN    ( 0 )
ELSE        ( 0 BA )
	1 AND 
	1W.!rombit    ( 0 )
THEN
;

\ --- search for one additional device. Returns 0 if done or 1 if more to come. see 1W.SCAN
: 1w.searchrom ( -- f  )
    0 \ default return value  0 
    1W.doneflag @ IF 0 1W.doneflag ! EXIT THEN    ( leaves 0 )
    1W.RESET IF                            \ presence signal detected?
        1 1W.rombit !                        \ yes: set ROM bit index to 1
        0 1W.discmark !                        \ set discrepancy marker to 0
        $F0 1W!                            \ send search command on bus
        BEGIN
            1W.BIT@ 1W.BIT@ 2* +    ( 0 BA )            \ 2 bits A & B  in bit pos 0 AND 1         
            DUP 3 =               ( 0 BA flag )
            IF ( bitA = bitB = 1?)            
                DROP
                0 1W.lastdisc !                    \ clear
                EXIT                ( leaves 0 )
            ELSE                    ( 0 BA )
               _srp1
            THEN    ( 0 )
            1W.@rombit     \ gives 0 or 1 as logical values instead of 0 -1        
            1W.BIT!        ( send ROM bit to bus )
            1W.rombit @
            1+ DUP
            1W.rombit !   \ increment 1W.rombit index
        64 > UNTIL   \ check > 64      ( 0 )
        1W.discmark @
        DUP 1W.lastdisc !        ( 0 discmark  )
        if
         1+  
         else 
         1 1W.doneflag ! 
         then     ( 0 )
    ELSE ( no presence signal )
        0 1W.lastdisc !   \ set 0
    THEN
;



\ --- scan for any devices on 1-wire bus and store them in table 1Wdevs
: 1w.scan ( -- )  
   1w.newsearch
   1Wdevs 1Waddrs  !                    \ begin at start of  table
   BEGIN
    1w.searchrom ( -- flg )
      \ 1W.romid 8 CRC8 IF CR ." CRC mismatch above" THEN
	1W.romid 1Waddrs @ 8 move               
	1 1Wcnt +!
      8 1Waddrs +!                       \ increment the address to store by 8 bytes
   0= UNTIL
;

: .scr cr 9 0 do scratchpad i + c@ hex . decimal loop ;
: 1w.dev@ ( n -- adr n ) 8 * 1Wdevs + 8 ;

: 1w.match ( n -- ) 
\ n - number devices in table 1Wdevs
1w.reset drop matchrom 
1w.dev@  
over + swap ?do i c@ 1w! loop
;

: 1w.skip 1w.reset drop skiprom ;


: 1w.gettemp ( n -- f )
\ n - number devices in table 1Wdevs
\ f - flag (false|true)
scratchpad 9 erase
dup 1w.match convertt 
\ 750 ms	
1w.input begin 1w.in until \ Only externally powered DS18B20s
1w.match rdscrh
scratchpad 8 $crc scratchpad 8 + c@ = if true else false then
;

: ds>dec 
dup 2/ 2/ 2/ 2/ 10 *
swap $f and 625 * 1000 / +
;

: temp>pad ( n -- adr n )
ds>dec
s>d swap over dabs <# # [char] . hold #s rot sign #>
;

\ Sample:
\ : 1winit 1w.scan cr ." Devices:" 1wcnt @ . ;
\ : .temp scratchpad @ $ffff and temp>pad cr type ;
\ : t1 0 1w.gettemp .temp ;
\ : t2 1 1w.gettemp .temp ;
