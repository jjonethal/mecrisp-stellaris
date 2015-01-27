\ Ethernet driver for TM4C1294 contributed by Bernd Paysan
\   needs basisdefinitions.txt

compiletoflash

\ -------------------------------------------
\  Compatibility layer for ANS standard code
\ -------------------------------------------

: variable> ( x -- ) variable ;  \ Initialised Variable
: variable  ( -- ) 0 variable ;   \ Uninitialised Variable

: 2variable> ( xd -- ) 2variable ;  \ Initialised Variable
: 2variable  ( -- ) 0. 2variable ;   \ Uninitialised Variable

\ -----------------------------------------------------------
\  Multitasking, Catch and Throw
\ -----------------------------------------------------------

\ field

: +field ( offset size "name" -- )  <builds over , + does> @ + ;
: cfield: ( u1 "name" -- u2 )  1 +field ;
: field: ( u1 "name" -- u2 )   aligned 1 cells +field ;

\ multitasker

0 0 flashvar-here 3 cells - 3 nvariable boot-task \ boot task has no extra stackspace
boot-task boot-task ! \ for compilation into RAM

boot-task variable> up \ user pointer
: next-task ( -- task )  up @ inline ;
: save-task ( -- save )  up @ cell+ inline ;
: handler ( -- handler ) up @ cell+ cell+ inline ;

: (pause) [ $B430 h, ]  \ push { r4  r5 } to save I and I'
    rp@ sp@ save-task ! \ save return stack and stack pointer
    next-task @ up ! eint \ switch to next task
    save-task @ sp! rp! \ restore pointers
    unloop ;            \ pop { r4  r5 } to restore the loop registers

128 cells Constant stackspace \ 128 stack elements for a background task

: task: ( "name" -- )  stackspace cell+ 2* cell+ buffer: ;

: active? ( task -- ? ) \ Checks if a task is currently inside of round-robin list
  next-task
  begin
    ( Task-Address )
    2dup = if 2drop true exit then
    @ dup next-task = \ Stop when end of circular list is reached
  until
  2drop false
;

: (wake) ( task -- ) \ wake a task
    dup active? IF  drop  exit  THEN
    next-task @ over ! next-task ! ;

: wake ( task -- ) dint (wake) eint ;

: activate ( task r:continue -- )
    r> swap >r 0 r@ cell+ cell+ ! \ no handler
    r@ stackspace cell+ cell+ + dup r@ cell+ !
    dup stackspace + tuck 2 cells - swap ! !
    r> wake ;

: multitask ( -- ) ['] (pause) hook-pause ! ;
: singletask ( -- ) ['] nop hook-pause ! ;

: prev-task ( -- addr )
  \ Find the task that has the currently running one in its next field
  next-task begin dup @ up @ <> while @ repeat ;

: sleep [ $BF30 h, ] inline ; \ WFI Opcode, Wait For Interrupt, enters sleep mode

task: lowpower-task

: lowpower& ( -- )
    lowpower-task activate
    begin
	dint next-task dup @ = if eint sleep then
	\ Is this task the only one remaining in round-robin list ?
	pause
    again
;

: stop ( -- ) \ Remove current task from round robin list
    \ Store the "next" of the current task into the "next" field of the previous task
    \ which short-circuits and unlinks the currently running one.
    dint next-task @ prev-task !

    \ Do final task switch out of the current task
    \ which is not linked in anymore in round-robin list.
    pause \ pause contains an eint
;

: kill ( task -- ) activate stop ;

\ --------------------------------------------------
\  Multitasking insight
\ --------------------------------------------------

: tasks ( -- ) \ Show tasks currently in round-robin list
  hook-pause @ singletask \ Stop multitasking as this list may be changed during printout.

  \ Start with current task.
  next-task cr

  begin
    ( Task-Address )
    dup             ." Task Address: " hex.
    dup           @ ." Next Task: " hex.
    dup 1 cells + @ ." Stack: " hex.
    dup 2 cells + @ ." Handler: " hex. cr

    @ dup next-task = \ Stop when end of circular list is reached
  until
  drop

  hook-pause ! \ Restore old state of multitasking
;

\ --------------------------------------------------
\  Exception handling
\ --------------------------------------------------

: catch ( x1 .. xn xt -- y1 .. yn throwcode / z1 .. zm 0 )
    [ $B430 h, ]  \ push { r4  r5 } to save I and I'
    sp@ >r handler @ >r rp@ handler !  execute
    r> handler !  rdrop  0 unloop ;
: throw ( throwcode -- )  dup IF
	handler @ 0= IF  stop  THEN \ unhandled error: stop task
	handler @ rp! r> handler ! r> swap >r sp! drop r>
	UNLOOP  EXIT
    ELSE  drop  THEN ;

' nop variable> flush-hook
: term-flush flush-hook @ execute ;
: quit-loop ( -- )  BEGIN  term-flush query interpret ."  ok" cr  AGAIN ;
: quit-catch ( -- )  BEGIN  ['] quit-loop catch
	dup IF  ." Throw: " . cr  ELSE  drop  THEN  AGAIN ;

: sysfault ( -- ) -9 throw ;

: init ( -- )
    init  multitask
    ['] quit-catch hook-quit !
    ['] sysfault irq-fault ! ;

init
quit \ Activate Multitasking and new Catch/Throw mechanism

\ --------------------------------------------------
\  Ethernet drivers
\ --------------------------------------------------

: bounds ( addr len -- end start ) over + swap inline 2-foldable ;

$400EC000 constant Ethernet-Base
$400FE000 constant USB-Base \ for unique device ID

USB-Base $F20 + Constant UNIQUEID0
USB-Base $F24 + Constant UNIQUEID1
USB-Base $F28 + Constant UNIQUEID2
USB-Base $F2C + Constant UNIQUEID3

\ Ethernet MAC (Ethernet Offset)
Ethernet-Base $000 + constant EMACCFG       \ RW $0000.8000 Ethernet MAC Configuration
Ethernet-Base $004 + constant EMACFRAMEFLTR \ RW $0000.0000 Ethernet MAC Frame Filter
Ethernet-Base $008 + constant EMACHASHTBLH  \ RW $0000.0000 Ethernet MAC Hash Table High
Ethernet-Base $00C + constant EMACHASHTBLL  \ RW $0000.0000 Ethernet MAC Hash Table Low
Ethernet-Base $010 + constant EMACMIIADDR   \ RW $0000.0000 Ethernet MAC MII Address
Ethernet-Base $014 + constant EMACMIIDATA   \ RW $0000.0000 Ethernet MAC MII Data Register
Ethernet-Base $018 + constant EMACFLOWCTL   \ RW $0000.0000 Ethernet MAC Flow Control
Ethernet-Base $01C + constant EMACVLANTG    \ RW $0000.0000 Ethernet MAC VLAN Tag
Ethernet-Base $024 + constant EMACSTATUS    \ RO $0000.0000 Ethernet MAC Status
Ethernet-Base $028 + constant EMACRWUFF     \ RW $0000.0000 Ethernet MAC Remote Wake-Up Frame Filter
Ethernet-Base $02C + constant EMACPMTCTLSTAT \ RW $0000.0000 Ethernet MAC PMT Control and Status Register

Ethernet-Base $038 + constant EMACRIS       \ RO $0000.0000 Ethernet MAC Raw Interrupt Status
Ethernet-Base $03C + constant EMACIM        \ RW $0000.0000 Ethernet MAC Interrupt Mask

Ethernet-Base $040 + constant EMACADDR0H    \ RW $8000.FFFF Ethernet MAC Address 0 High
Ethernet-Base $044 + constant EMACADDR0L    \ RW $FFFF.FFFF Ethernet MAC Address 0 Low Register
Ethernet-Base $048 + constant EMACADDR1H    \ RW $0000.FFFF Ethernet MAC Address 1 High
Ethernet-Base $04C + constant EMACADDR1L    \ RW $FFFF.FFFF Ethernet MAC Address 1 Low
Ethernet-Base $050 + constant EMACADDR2H    \ RW $0000.FFFF Ethernet MAC Address 2 High
Ethernet-Base $054 + constant EMACADDR2L    \ RW $FFFF.FFFF Ethernet MAC Address 2 Low
Ethernet-Base $058 + constant EMACADDR3H    \ RW $0000.FFFF Ethernet MAC Address 3 High
Ethernet-Base $05C + constant EMACADDR3L    \ RW $FFFF.FFFF Ethernet MAC Address 3 Low

Ethernet-Base $0DC + constant EMACWDOGTO    \ RW $0000.0000 Ethernet MAC Watchdog Timeout

Ethernet-Base $100 + constant EMACMMCCTRL   \ RW $0000.0000 Ethernet MAC MMC Control
Ethernet-Base $104 + constant EMACMMCRXRIS  \ RO $0000.0000 Ethernet MAC MMC Receive Raw Interrupt Status
Ethernet-Base $108 + constant EMACMMCTXRIS  \ R  $0000.0000 Ethernet MAC MMC Transmit Raw Interrupt Status
Ethernet-Base $10C + constant EMACMMCRXIM   \ RW $0000.0000 Ethernet MAC MMC Receive Interrupt Mask
Ethernet-Base $110 + constant EMACMMCTXIM   \ RW $0000.0000 Ethernet MAC MMC Transmit Interrupt Mask

Ethernet-Base $118 + constant EMACTXCNTGB   \ RO $0000.0000 Ethernet MAC Transmit Frame Count for Good and Bad Frames
Ethernet-Base $14C + constant EMACTXCNTSCOL \ RO $0000.0000 Ethernet MAC Transmit Frame Count for Frames Transmitted after Single Collision
Ethernet-Base $150 + constant EMACTXCNTMCOL \ RO $0000.0000 Ethernet MAC Transmit Frame Count for Frames Transmitted after Multiple Collisions
Ethernet-Base $164 + constant EMACTXOCTCNTG \ RO $0000.0000 Ethernet MAC Transmit Octet Count Good
                                    
Ethernet-Base $180 + constant EMACRXCNTGB      \ RO $0000.0000 Ethernet MAC Receive Frame Count for Good and Bad Frames
Ethernet-Base $194 + constant EMACRXCNTCRCERR  \ RO $0000.0000 Ethernet MAC Receive Frame Count for CRC Error Frames
Ethernet-Base $198 + constant EMACRXCNTALGNERR \ RO $0000.0000 Ethernet MAC Receive Frame Count for Alignment Error Frames
Ethernet-Base $1C4 + constant EMACRXCNTGUNI    \ RO $0000.0000 Ethernet MAC Receive Frame Count for Good Unicast Frames

Ethernet-Base $584 + constant EMACVLNINCREP   \ RW $0000.0000 Ethernet MAC VLAN Tag Inclusion or Replacement
Ethernet-Base $588 + constant EMACVLANHASH    \ RW $0000.0000 Ethernet MAC VLAN Hash Table
Ethernet-Base $700 + constant EMACTIMSTCTRL   \ RW $0000.2000 Ethernet MAC Timestamp Control
Ethernet-Base $704 + constant EMACSUBSECINC   \ RW $0000.0000 Ethernet MAC Sub-Second Increment

Ethernet-Base $708 + constant EMACTIMSEC      \ RO $0000.0000 Ethernet MAC System Time - Seconds
Ethernet-Base $70C + constant EMACTIMNANO     \ RO $0000.0000 Ethernet MAC System Time - Nanoseconds
Ethernet-Base $710 + constant EMACTIMSECU     \ RW $0000.0000 Ethernet MAC System Time - Seconds Update
Ethernet-Base $714 + constant EMACTIMNANOU    \ RW $0000.0000 Ethernet MAC System Time - Nanoseconds Update
Ethernet-Base $718 + constant EMACTIMADD      \ RW $0000.0000 Ethernet MAC Timestamp Addend
Ethernet-Base $71C + constant EMACTARGSEC     \ RW $0000.0000 Ethernet MAC Target Time Seconds
Ethernet-Base $720 + constant EMACTARGNANO    \ RW $0000.0000 Ethernet MAC Target Time Nanoseconds
Ethernet-Base $724 + constant EMACHWORDSEC    \ RW $0000.0000 Ethernet MAC System Time-Higher Word Seconds
Ethernet-Base $728 + constant EMACTIMSTAT     \ RO $0000.0000 Ethernet MAC Timestamp Status

Ethernet-Base $72C + constant EMACPPSCTRL     \ RW $0000.0000 Ethernet MAC PPS Control
Ethernet-Base $760 + constant EMACPPS0INTVL   \ RW $0000.0000 Ethernet MAC PPS0 Interval
Ethernet-Base $764 + constant EMACPPS0WIDTH   \ RW $0000.0000 Ethernet MAC PPS0 Width

Ethernet-Base $C00 + constant EMACDMABUSMOD   \ RW $0002.0101 Ethernet MAC DMA Bus Mode
Ethernet-Base $C04 + constant EMACTXPOLLD     \ WO $0000.0000 Ethernet MAC Transmit Poll Demand
Ethernet-Base $C08 + constant EMACRXPOLLD     \ WO $0000.0000 Ethernet MAC Receive Poll Demand
Ethernet-Base $C0C + constant EMACRXDLADDR    \ RW $0000.0000 Ethernet MAC Receive Descriptor List Address
Ethernet-Base $C10 + constant EMACTXDLADDR    \ RW $0000.0000 Ethernet MAC Transmit Descriptor List Address
Ethernet-Base $C14 + constant EMACDMARIS      \ RW $0000.0000 Ethernet MAC DMA Interrupt Status
Ethernet-Base $C18 + constant EMACDMAOPMODE   \ RW $0000.0000 Ethernet MAC DMA Operation Mode
Ethernet-Base $C1C + constant EMACDMAIM       \ RW $0000.0000 Ethernet MAC DMA Interrupt Mask Register
                                      
Ethernet-Base $C20 + constant EMACMFBOC     \ RO  $0000.0000 Ethernet MAC Missed Frame and Buffer Overflow Counter
Ethernet-Base $C24 + constant EMACRXINTWDT  \ RW  $0000.0000 Ethernet MAC Receive Interrupt Watchdog Timer
Ethernet-Base $C48 + constant EMACHOSTXDESC \  R  $0000.0000 Ethernet MAC Current Host Transmit Descriptor
Ethernet-Base $C4C + constant EMACHOSRXDESC \ RO  $0000.0000 Ethernet MAC Current Host Receive Descriptor
Ethernet-Base $C50 + constant EMACHOSTXBA   \  R  $0000.0000 Ethernet MAC Current Host Transmit Buffer Address
Ethernet-Base $C54 + constant EMACHOSRXBA   \  R  $0000.0000 Ethernet MAC Current Host Receive Buffer Address
Ethernet-Base $FC0 + constant EMACPP        \ RO  $0000.0103 Ethernet MAC Peripheral Property Register
Ethernet-Base $FC4 + constant EMACPC        \ RW  $0080.040E Ethernet MAC Peripheral Configuration Register
Ethernet-Base $FC8 + constant EMACCC        \ RO  $0000.0000 Ethernet MAC Clock Configuration Register
Ethernet-Base $FD0 + constant EPHYRIS       \ RO  $0000.0000 Ethernet PHY Raw Interrupt Status
Ethernet-Base $FD4 + constant EPHYIM        \ RW  $0000.0000 Ethernet PHY Interrupt Mask
Ethernet-Base $FD8 + constant EPHYMISC      \ RW  $0000.0000 Ethernet PHY Masked Interrupt Status and Clear

 
\ Constants for EMACDMAIM
1 16 lshift constant NIE
1  6 lshift constant RIE

\ Dies geht natürlich nur, während ins RAM kompiliert wird. Später Pufferinitialisationen für Flash entwickeln.

1 31 lshift constant own

1524 Constant ether-size \ aligned to 4

ether-size buffer: RX-Puffer-0
ether-size buffer: RX-Puffer-1
ether-size buffer: RX-Puffer-2
ether-size buffer: RX-Puffer-3
ether-size buffer: RX-Puffer-4
ether-size buffer: RX-Puffer-5
ether-size buffer: RX-Puffer-6
ether-size buffer: RX-Puffer-7
ether-size buffer: TX-Puffer
ether-size buffer: TX-Puffer-2

1 15 lshift constant RER

8 4 * Constant desc-size
8 Constant descs# \ reserve 8 descriptors
8 Constant txdescs# \ reserve 2 descriptors
desc-size descs# * 1- Constant descs-mask
desc-size txdescs# * 1- Constant txdescs-mask

1 30 lshift constant IC
1 29 lshift constant LS  \ Last Segment of Frame
1 28 lshift constant FS  \ First Segment of Frame
1 25 lshift constant TTSE \ time stamp enable
3 22 lshift constant CIC:cs \ IP header checksum insertion
1 21 lshift constant TER \ Transmit End of Ring
1 17 lshift constant TTSS \ time stamp status

LS FS or TTSE or CIC:cs or TTSS or Constant TDES0
TDES0 own or Constant TDES0:own

2 29 lshift constant SAIC:RS \ replace source

Variable rx-head \ descriptor to add new buffers
Variable rx-tail \ descriptor to receive buffers
Variable tx-head \ descriptor to send new buffers

desc-size descs# * buffer: RX-Descriptors
desc-size txdescs# * buffer: TX-Descriptors

: RX-Descriptor   RX-Descriptors rx-head @ + ;
: RX-Descriptor'  RX-Descriptors rx-tail @ + ;
: TX-Descriptor   TX-Descriptors tx-head @ + ;
: TX-Descriptor'  TX-Descriptors tx-head @ desc-size - txdescs-mask and + ;

\ ip header offsets

0
6 +field eth-dest
6 +field eth-src
2 +field eth-type
dup Constant ether-header#
1 +field ip-version
1 +field ip-tos
2 +field ip-len
2 +field ip-id
2 +field ip-frag
1 +field ip-ttl
1 +field ip-protocol
2 +field ip-hdrcs
4 +field ip-src
4 +field ip-dest
dup Constant ip-header#
2 +field udp-src
2 +field udp-dest
2 +field udp-len
2 +field udp-cs
Constant udp-header#
ip-header#
1 +field icmp-type
1 +field icmp-code
2 +field icmp-cs
Constant icmp-header#

\ dump a packet

: byte. ( u -- )
  base @ hex swap
  0 <# # # #> type
  base !
;

: word. ( u -- )
  base @ hex swap
  0 <# # # # # #> type
  base !
;

: mac. ( addr -- )
  dup     c@ byte. ." :"
  dup 1 + c@ byte. ." :"
  dup 2 + c@ byte. ." :"
  dup 3 + c@ byte. ." :"
  dup 4 + c@ byte. ." :"
      5 + c@ byte. space
;

: packetdump ( addr len )
  0 ?do ( addr )
      i $7 and 0= if space then \ Alle 8 Zeichen ein zusätzliches Leerzeichen
      i $F and 0= if cr then  \ Alle 16 Zeichen einen Zeilenumbruch
      dup i + c@ byte. space
    loop
  drop
  cr
;

: .packet ( addr len -- )
    singletask
    dup ." Länge " u.
    over eth-dest ." Ziel-MAC "  mac.
    over eth-src  ." Quell-MAC " mac.
    ." Ethertype " over eth-type dup c@ byte. 1+ c@ byte. cr
    
    ( length addr )
    packetdump
    multitask
;



1 5 lshift constant UNF \ Transmit Underflow
1 2 lshift constant TU \ Transmit Unavailabl

create mymac  
$00 c, 
$1A c, 
$B6 c, 
uniqueid0 @ dup c, 
8 rshift c, 
uniqueid3 3 + c@ c, 
$00 c, 
$80 c,  \ use unique ID

create myip   
10 c, 
0 c, 
0 c, 
mymac 5 + c@ c,

: tc, ( addr char -- addr' )  over c! 1+ ;
: tw, ( addr word -- addr' )  >r r@ 8 rshift tc, r> tc, ;
: tl, ( addr word -- addr' )  >r r@ $10 rshift tw, r> tw, ;
: t$, ( addr addr1 u1 -- addr' ) rot 2dup + >r swap move r> ;

: ffmac, ( addr -- addr' )   6 0 DO  $FF tc,  LOOP ;

: tx-buffer+ ( addr u -- )
    \ send this block
    SAIC:RS or TX-Descriptor cell+ 2! \ TDES1+2: Puffergröße+Addr und ein paar Flags
    TDES0:own
    tx-head @ desc-size + txdescs-mask u>= TER and or
    TX-Descriptor ! \ TDES0: Zum Abschicken an den DMA übergeben
    unf tu or emacdmaris !    \ Transmit Buffer Underflow löschen
    -1 EMACTXPOLLD ! \ polltx to tell TX logic to go on
    tx-head @ desc-size + txdescs-mask and tx-head !
;   \ Sendelogik anstuppsen

: tx-buffer+2 ( addrhdr uhdr addrdata udata -- )
    \ send these two blocks, one is a prefabbed header, the other dynamic data
    16 lshift rot or swap TX-Descriptor 3 cells + ! \ TDES3: Addr2
    tx-buffer+ ;

: rx-buffer+ ( addr u -- )
    ether-size min \ no more than 1522 bytes
    own RX-Descriptor !
    rx-head @ desc-size + descs-mask u>= RER and or
    RX-Descriptor cell+ 2!
    rx-head @ desc-size + descs-mask and rx-head !
    -1 EMACRXPOLLD ! ;

: .send ( -- ) singletask
     ." Losschicken: " cr
    ." EMACDMARIS: "  emacdmaris @ hex. cr
    TX-Descriptor' cell+ 2@ $3FFF and .packet
;

task: ethernet-task

: ethernet-handler ( -- )
    -1 EMACDMARIS ! ;

: rx-tail+ ( -- ) rx-tail @ desc-size + descs-mask and rx-tail ! ;

: desc@ ( desc -- addr u )
    >r r@ 8 + @ r> @ 16 rshift $3FFF and ;

: dump-rx ( desc -- ) desc@ .packet cr ;

: rx-ipv6 ( desc -- )
    ." IPv6 packet received" cr dump-rx ;

\ arp protocol: reply to requests (no caching and doing our own requests)

10 constant /arp
16 constant arp-cache#
/arp arp-cache# * buffer: arp-cache
Variable arp#
: arp-cache+ ( addr u -- )
    arp-cache arp# @ + swap move
    /arp arp# @ + dup /arp arp-cache# * u< and arp# ! ;
: ip>mac ( ip-addr -- macaddr/0 )  @
    arp-cache /arp arp-cache# * bounds DO
	dup i 6 + @ = IF  drop I  UNLOOP  EXIT  THEN
    /arp +LOOP  drop 0 ;

: >reply ( addr u -- addr u )
    over dup 6 + swap 6 move ;

: rx-arp ( desc -- ) desc@ over ether-header# + >r
    r@ 2@ $01000406 $00080100 d= \ is it an arp request?
    IF  myip @ r@ 24 + @ =       \ is it actually for our IP?
	IF \ arp request for us: do in-place reply
	    >reply  r> 7 + 2 tc,     \ set reply flag
	    dup dup 10 + 10 move     \ move request tuple to reply tuple
	    mymac 6 t$, myip 4 t$,   \ set my mac
	    2drop 42 tx-buffer+ EXIT \ reply it
	THEN
	rdrop 2drop EXIT \ not my IP
    THEN
    r@ 2@ $02000406 $00080100 d= \ is it an arp reply?
    IF
	2drop r> 8 + 10 arp-cache+  EXIT
    THEN
    ." ARP unknown packet received " r@ 2@ hex. hex. cr
    rdrop .packet cr ;

: fill-arp1 ( -- ) \ generic ARP request
    TX-Puffer
    \ Ziel-MAC-Adresse, Broadcast
    ffmac,
    \ Quell-MAC-Adresse, wird ersetzt
    ffmac,

    \ Ethertype: ARP
    $0806 tw,
    \ Rest im Puffer: ARP-Request, damit wir auch eine Antwort kriegen
    1 tw, $800 tw, $06040001 tl,
    \ my mac     my ip       my mac       my ip
    mymac 6 t$,  myip 4 t$, ;

: grat-arp ( -- ) \ Send Packet
    \ fill buffer with gratious arp information
    fill-arp1  mymac 6 t$,  myip 4 t$,  drop
    TX-Puffer 42 tx-buffer+ ;

: req-arp ( ip-addr -- ) >r
    fill-arp1  ffmac,  r> tl,  drop
    TX-Puffer 42 tx-buffer+ ;

\ IP header debugging

: be-w@ ( addr -- w )  count >r c@ r> 8 lshift or ;
: be-w! ( w addr -- )  over 8 rshift over c! 1+ c! ;
: be-l@ ( addr -- l )  count >r count >r count >r c@
    r> 8 lshift or  r> 16 lshift or r> 24 lshift or ;

: .iphdr ( addr len -- addr len )  singletask
    ." IP packet received" cr
    ." Ethernet length: " dup >r . cr
    ." IP length: " dup ip-len be-w@ . cr
    ." IP type: " dup ip-protocol c@ . cr
    r> ;

: .ippacket ( addr len -- )  .iphdr .packet cr ;

\ icmp

: ip-reply ( addr destaddr -- addr destaddr' )
    over eth-src over eth-dest 6 move eth-src ffmac,
    $800 tw, over ip-version over 10 move 10 + 0 tw, \ checksum 0
    myip over 4 move 4 +
    over ip-src  over 4 move 4 + ;

\ : >carries ( n -- n' )
\     dup 16 rshift swap $FFFF and + ;
\ : ip-cs ( addr u -- cs )
\     0 -rot bounds ?DO  I be-w@ +  2 +LOOP  >carries >carries
\     $FFFF xor ;

: icmp-rx ( addr len -- )
    over icmp-type c@ 8 = IF
	icmp-header# - 4 - >r TX-Puffer ip-reply
	0 tl, \ type 0, code 0, cs not set
	over icmp-header# + over r@ move \ copy rest
	2drop \ the engine calculates the header for us
	\ dup 4 - r@ 4 + ip-cs swap 2 - over hex. dup hex. cr be-w!
	TX-Puffer r> icmp-header# + tx-buffer+
    ELSE
	singletask
	." ICMP received" cr
	.ippacket
    THEN ;

\ udp

udp-header# aligned buffer: term-hdr
udp-header# aligned buffer: data-hdr

: udp-reply ( addr destaddr -- addr destaddr' )
    ip-reply
    over udp-dest be-w@ tw, \ swap dest/src
    over udp-src  be-w@ tw,
    0 tl, ; \ length+CS stub

: sendv ( addr u hdr -- ) >r
    dup 8 + r@ udp-len be-w!
    dup 28 + r@ ip-len be-w!
    r> udp-header# 2swap tx-buffer+2 ;

: udp-data ( addr u -- ) \ just setup the reply buffer
    drop data-hdr udp-reply 2drop ;

\ inject strings into terminal

: /string ( addr1 u1 n -- addr2 u2 )
    tuck - >r + r> ;

1472 Constant udp-max# \ 1518 maximum for non-VLAN packets

udp-max# buffer: inject-buffer
udp-max# buffer: emit-buffer
2Variable inject-keys
Variable emit-chars

: term-type ( addr u -- ) \ unbuffered type
    term-hdr @ IF  term-hdr sendv  ELSE  2drop  THEN ;
: (term-flush) ( -- )
    emit-chars @ IF  emit-buffer emit-chars @ term-type  0 emit-chars !  THEN ;

true variable> serial?
true variable> flush-key?

: udp-key? ( -- flag ) serial-key? inject-keys @ 0<> or ;
: udp-key ( -- key )
    flush-key? @ IF  term-flush  THEN
    BEGIN
	serial-key? IF  serial-key  EXIT  THEN
	inject-keys 2@ dup IF
	    over c@ >r 1 /string inject-keys 2!
	    r> dup 3 = IF  drop  true flush-key? !
	    ELSE  EXIT  THEN
	ELSE  2drop  THEN
    AGAIN ;

: udp-emit ( char -- ) serial? @ IF  dup serial-emit  THEN
    emit-buffer emit-chars @ + c!
    1 emit-chars +!  emit-chars @ udp-max# u>=  IF  term-flush  THEN ;

: udp-term ( addr u -- )
    over term-hdr udp-reply 2drop
    udp-header# - >r
    dup udp-len be-w@ 8 - r> umin >r \ careful: smaller limit wins!
    udp-header# + inject-buffer r@ move
    inject-buffer r> inject-keys 2! ;

: udp-io ( -- )
    ['] udp-emit hook-emit !
    ['] udp-key? hook-key? !
    ['] udp-key hook-key !
    ['] (term-flush) flush-hook ! ;

: include ( "name" -- )  false flush-key? !
    2 emit term-flush 1000 0 DO LOOP \ wait a bit
    token type term-flush ;

: .udphdr ( addr len -- )
    ." UDP src:  " over udp-src  be-w@ . cr
    ." UDP dest: " over udp-dest be-w@ . cr ;
: .udppacket ( addr len -- )  .iphdr .udphdr .packet cr ;

' .udppacket 0
' .udppacket 0
' .udppacket 0
' .udppacket 0
' .udppacket 0
' .udppacket 0
12 nvariable free-udpports

' udp-data 4202
' udp-term 4201
4 nvariable udpports

\ udp port dispatcher

: udp-rx ( addr u -- )
    over udp-dest be-w@
    udpports 16 cells bounds do
	dup i @ = if
	    drop  i cell+ @ execute  unloop  exit
	then
    2 cells  +loop  drop 2drop ;

\ ip handler

' .ippacket 0
' .ippacket 0
' .ippacket 0
' .ippacket 0
' .ippacket 0
' .ippacket 0
12 nvariable free-iptypes

' udp-rx 17
' icmp-rx 1
4 nvariable iptypes

: rx-ip ( desc -- ) desc@ over ip-protocol c@
    iptypes 16 cells bounds do
	dup i @ = if
	    drop  i cell+ @ execute  unloop  exit
	then
    2 cells  +loop  drop .ippacket ;

\ ethernet handler

' dump-rx 0
' dump-rx 0
' dump-rx 0
' dump-rx 0
' dump-rx 0
10 nvariable free-ethertypes

' rx-arp  $0806
' rx-ipv6 $86DD
' rx-ip   $0800
6 nvariable ethertypes

: rx-ethertype ( descriptor ethertype -- )
    ethertypes 16 cells bounds do
	dup i @ = if
	    drop  i cell+ @ execute  unloop  exit
	then
    2 cells  +loop  drop dump-rx ;

: handle-rx ( descriptor -- )
    dup 8 + @ eth-type be-w@ rx-ethertype ;	

: ether-loop ( -- )
    BEGIN
	BEGIN  pause  RX-Descriptor' @ own and 0=  UNTIL
	
	RX-Descriptor' dup >r handle-rx
	r> 8 + @ ether-size rx-buffer+
	rx-tail+
    AGAIN ;

: ethernet& ( -- )
    ethernet-task activate
    BEGIN  ['] ether-loop catch  drop  AGAIN
;


$400FE000 constant Sysctl-Base

Sysctl-Base $630 + constant RCGCEPHY
Sysctl-Base $69C + constant RCGCEMAC
Sysctl-Base $0B0 + constant RSCLKCFG
Sysctl-Base $07C + constant MOSCCTL
Sysctl-Base $930 + constant PCEPHY
Sysctl-Base $99C + constant PCEMAC

\ Constants for EMACDMABUSMOD

1 7 lshift constant ATDS

\ Constants for EMACCFG

1 14 lshift constant FES
1 11 lshift constant DUPM
1  3 lshift constant TE
1  2 lshift constant RE

\ Constants for MOSCCTL
1 4 lshift constant OSCRNG

PORTF_BASE $420 + constant PORTF_AFSEL  ( Alternate Function Select )
PORTF_BASE $52C + constant PORTF_PCTL   ( Pin Control )

: clocks-enable ( -- )
    \ Enable MOSC and use this as system clock:

    OSCRNG MOSCCTL ! \ High range for MOSC
    
    \ while we wait for the clock to stabilize...
    50 0 do  loop
    
    3 20 lshift RSCLKCFG ! \ MOSC as oscillator
    
    \ Enable clock for Ethernet:

    1 RCGCEMAC !  1 RCGCEPHY ! ;

: descs-setup ( -- )
    RX-Descriptors desc-size descs# * 0 fill
    TX-Descriptors desc-size txdescs# * 0 fill
    arp-cache /arp arp-cache# *       0 fill

    \ allow eight frames to be received
    rx-puffer-7 rx-puffer-0 do
	i ether-size rx-buffer+
    ether-size negate +loop ;

: enable-emac ( -- )
    1 PCEMAC ! \ Enable EMAC
    1 PCEPHY ! \ Enable EPHY
;

: reset-emac ( -- )
    \ Write to the Ethernet MAC DMA Bus Mode (EMACDMABUSMOD) register to set Host bus parameters.
    
    ." Reset Ethernet" cr
    1 EMACDMABUSMOD ! \ Reset MAC
    begin EMACDMABUSMOD @ 1 and not until \ Wait for Reset to complete
    ." Reset complete" cr
    EMACDMABUSMOD @ ATDS or EMACDMABUSMOD ! ;

: emac-leds ( -- )
  \ Set Ethernet LEDs on Port F:
     $11  PORTF_AFSEL !
  $50005 PORTF_PCTL ! ;

: emac-irqs ( -- )
  56 nvic-enable \ Enable ethernet vector in NVIC

  ['] ethernet-handler irq-ethernet !
  \ Write to the Ethernet MAC DMA Interrupt Mask Register (EMACDMAIM) register to mask unnecessary interrupt causes.

  RIE NIE or EMACDMAIM ! \ Interrupts: Receive and normal interrupt summary
;

: emac-init ( -- )
  mymac cell+ @ EMACADDR0H !
  mymac       @ EMACADDR0L !
  
  \ Create the transmit and receive descriptor lists and then write to the Ethernet MAC Receive
  \ Descriptor List Address (EMACRXDLADDR) register and the Ethernet MAC Transmit
  \ Descriptor List Address (EMACTXDLADDR) register providing the DMA with the starting
  \ address of each list.

  RX-Descriptors EMACRXDLADDR !
  TX-Descriptors EMACTXDLADDR !

  \ Write to the Ethernet MAC Frame Filter (EMACFRAMEFLTR) register, the Ethernet MAC
  \ Hash Table High (EMACHASHTBLH) and the Ethernet MAC Hash Table Low
  \ (EMACHASHTBLL) for desired filtering options.

  0 EMACFRAMEFLTR ! \ no filtering, normal mode

  \ Write to the Ethernet MAC Configuration Register (EMACCFG) to configure the operating
  \ mode and enable the transmit operation.

  3 28 lshift \ saddr=replace with addr0
  FES or  \ 100 Mbps
  DUPM or \ Full Duplex
  TE or   \ Transmitter Enable
  RE or   \ Receiver Enable
  EMACCFG !

  \ Program Bit 15 (PS) and Bit 11 (DM) of the EMACCFG register based on the line status received
  \ or read from the PHY status register after auto-negotiation.

  \ Hardwired to Full-Duplex, store&forward, 100 Mbps here.
  1 21 lshift 1 13 lshift or 2 or EMACDMAOPMODE ! ;

: init ( -- )
    init
    clocks-enable  descs-setup  enable-emac
    reset-emac  emac-leds  emac-irqs  emac-init
    \ start background task
    ethernet& udp-io
    ." Mecrisp-Stellaris ethernet terminal ready" cr
;

\ Die Link-OK LED (D3) leuchtet jetzt, und die TX/RX-Aktivitätsled (D4) blinkert bei Paketen auf der Leitung.

: netstat ( -- )
  ." Incoming frames: " EMACRXCNTGB @ u. cr
  ." Outgoing frames: " EMACTXCNTGB @ u. cr
;

: variable variable> ; \ Define variable back to initialised mode
: 2variable 2variable> ;

\ cornerstone rewind-to-ethernet
compiletoram
init
