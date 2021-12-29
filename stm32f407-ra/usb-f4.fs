\ A polled buffered USB serial driver for STM32F4xx by Jan Bramkamp
\ Started of as C++ to Forth port of stm32f4-usb.h by Jean-Claude Wippler

\ Work in progress - additional descriptors and automatic
\ UART <-> USB switchover will be implemented soon.

\ Full word endian conversion
: rev ( x -- x' ) [ $ba36 h, ] inline 1-foldable ;
\ Half word endian conversion
: rev16 ( x -- x' ) [ $ba76 h, ] inline 1-foldable ;

\ A h, replacement with no alignment restrictions
: 2c, ( h -- ) dup c, 8 rshift c, ;

$50000000 constant usb-base
usb-base $008 + constant GAHBCFG   \ p.1275
usb-base $00C + constant GUSBCFG   \ p.1276
usb-base $014 + constant GINTSTS   \ p.1280
usb-base $020 + constant GRXSTSP   \ p.1287
usb-base $024 + constant GRXFSIZ   \ p.1288
usb-base $028 + constant DIEPTXF0  \ p.1289
usb-base $038 + constant GCCFG     \ p.1290
usb-base $104 + constant DIEPTXF1  \ p.1292
usb-base $800 + constant DCFG      \ p.1303
usb-base $808 + constant DSTS      \ p.1305
usb-base $900 + constant DIEPCTL0  \ p.1310
usb-base $910 + constant DIEPTSIZ0 \ p.1321
usb-base $918 + constant DTXFSTS0  \ p.1325
usb-base $B00 + constant DOEPCTL0  \ p.1316
usb-base $B10 + constant DOEPTSIZ0 \ p.1323
usb-base $B20 + constant DOEPCTL1
usb-base $B30 + constant DOEPTSIZ1
usb-base $B40 + constant DOEPCTL2
usb-base $B50 + constant DOEPTSIZ2
usb-base $920 + constant DIEPCTL1
usb-base $940 + constant DIEPCTL2
usb-base $938 + constant DTXFSTS1
usb-base $958 + constant DTXFSTS2
usb-base $930 + constant DIEPTSIZ1

create dev-data here
        \ length
        \ |    descriptor type (1 = device descriptor)
	\ |    |        usb specification number
	\ |    |        |     device class
	\ |    |        |     |    device subclass
	\ |    |        |     |    |    device protocol
	\ |    |        |     |    |    |
        \ |    |        |     |    |    |    max packet size
        \ |    |        |     |    |    |     |
        \ v    v        v     v    v    v     v
         18 c, 1 c, $0200 2c, 2 c, 0 c, 0 c, 64 c,
        \ vendor id
        $0483 2c,
        \ product id
        $5740 2c,
        \ device release number
        \   |     manufacturer string descriptor index (0 = none)
        \   |     |    product string descriptor index (0 = none)
	\   |     |    |    serial number string descriptor index (0 = none)
        \   |     |    |    |    number of possible configurations
        \   |     |    |    |    |
        \   v     v    v    v    v
        $0200 2c, 0 c, 0 c, 0 c, 1 c,
here align swap - constant dev-size

create cfg-data here
	\ device descriptor length
	\ |     descriptor type (2 = configuration descriptor)
	\ |     |      total length (for all descriptors)
	\ |     |      |      number of interfaces
	\ |     |      |      |     index for this configuration
	\ |     |      |      |     |     configuration string descriptor index (0 = none)
	\ |     |      |      |     |     |            attribute bitmap (bit 7 = bus powered, bit 6 = self powered) oxymoron?!?
        \ |     |      |      |     |     |            |      max power in steps of two mA
        \ |     |      |      |     |     |            |      |
        \ v     v      v      v     v     v            v      v
          9 c,  2 c,  67 2c,  2 c,  1 c,  0 c, %11000000 c, 100 2/ c, \ USB Configuration

        \ interface descriptor length
        \ |    descriptor type (4 = interface descriptor)
	\ |    |    interface number
	\ |    |    |    alternate setting
	\ |    |    |    |    number of endpoints
	\ |    |    |    |    |    class code
	\ |    |    |    |    |    |    subclass codde
	\ |    |    |    |    |    |    |    protocol code
	\ |    |    |    |    |    |    |    |    interface string descriptor index (0 = none)
	\ |    |    |    |    |    |    |    |    |
	\ v    v    v    v    v    v    v    v    v
	  9 c, 4 c, 0 c, 0 c, 1 c, 2 c, 2 c, 0 c, 0 c, \ Interface

	  5 c, 36 c, 0 c, 16 c, 1 c, \ Header Functional
	  5 c, 36 c, 1 c,  0 c, 1 c, \ Call Management Functional
	  4 c, 36 c, 2 c,  2 c,      \ ACM Functional
	  5 c, 36 c, 6 c,  0 c, 1 c, \ Union Functional

	\ endpoint descriptor length
	\ |    descriptor type (5 = endpoint descriptor)
	\ |    |      endpoint address (endpoint = 2, direction = IN)
	\ |    |      |    attributes (type = interrupt)
	\ |    |      |    |    max packet size
        \ |    |      |    |    |       polling interval in ms (slow?)
        \ |    |      |    |    |       |
        \ v    v      v    v    v       v
          7 c, 5 c, 130 c, 3 c, 8 2c, 255 c, \ Endpoint 2 IN

        \ interface descriptor length
        \ |    descriptor type (4 = interface descriptor)
	\ |    |    interface number
	\ |    |    |    alternate setting
	\ |    |    |    |    number of endpoints
	\ |    |    |    |    |     class code
	\ |    |    |    |    |     |    subclass codde
	\ |    |    |    |    |     |    |    protocol code
	\ |    |    |    |    |     |    |    |    interface string descriptor index (0 = none)
	\ |    |    |    |    |     |    |    |    |
	\ v    v    v    v    v     v    v    v    v
	  9 c, 4 c, 1 c, 0 c, 2 c, 10 c, 0 c, 0 c, 0 c, \ Data class interface
	\ endpoint descriptor length
	\ |    descriptor type (5 = endpoint descriptor)
	\ |    |    endpoint address (endpoint = 1, direction = OUT)
	\ |    |    |    attributes (type = bulk)
	\ |    |    |    |     max packet size
        \ |    |    |    |     |      polling interval (ignored)
        \ |    |    |    |     |      |
        \ v    v    v    v     v      v
          7 c, 5 c, 1 c, 2 c, 64 2c,  0 c, \ Endpoint 1 OUT

        \ endpoint descriptor length
        \ |    descriptor type (5 = endpoint descriptor)
	\ |    |      endpoint address (endpoint = 1, direction = IN)
	\ |    |      |    attributes (type = bulk)
	\ |    |      |    |     max packet size
        \ |    |      |    |     |     polling interval (ignored)
        \ |    |      |    |     |     |
        \ v    v      v    v     v     v
          7 c, 5 c, 129 c, 2 c, 64 2c, 0 c, \ Endpoint 1 IN
here align swap - constant cfg-size

: usb-on ( -- ) 7 bit RCC_AHB2ENR bis! ;

0 1+ $1000 * usb-base + constant fifo0
1 1+ $1000 * usb-base + constant fifo1

: usb-gpio ( -- )
	\ Pulse PA11 low as open drain for 3 ms
        %1111 11 2* lshift GPIOA_MODER   bic! \ Clear mode of PA11 and PA12
        %1111 11 2* lshift GPIOA_OSPEEDR bic! \ Clear drive strength
        %0101 11 2* lshift GPIOA_OSPEEDR bis! \ Set drive strength for 25 MHz

          12 bit 16 lshift GPIOA_BSRR       ! \ PA12 low
          %01 12 2* lshift GPIOA_MODER   bis! \ Set PA12 as output

        12 bit             GPIOA_OTYPER  bis! \ PA12 Open Drain
        3 ms
        12 bit             GPIOA_OTYPER  bic!

        %1111 11 2* lshift GPIOA_MODER   bic! \ Clear mode of PA11 and PA12

        $000FF000          GPIOA_AFRH    bic! \ Clear alternate function
        $000AA000          GPIOA_AFRH    bis! \ Set alternate function 10

        %1010 11 2* lshift GPIOA_MODER   bis! \ Set pins to alternate function mode
;

21 bit constant NOVBUSSENS
16 bit constant PWRDWN
30 bit constant FDMOD

\ Disable USB power supply sensing and enable the transceiver.
\ Voltage sensing isn't possible on a lot of STM32F4xx boards because the USB +5V pin is directly connected to
\ the board +5V supply leaving the unusuable voltage sensing pin available for other uses.
: usb-enable ( -- ) NOVBUSSENS PWRDWN or GCCFG bis! ;

\ Implementing a USB device is already bad enough.
: usb-force-device ( -- ) FDMOD GUSBCFG bis! ;

\ The only supported speed in device mode is full speed (12Mbps)
: usb-fullspeed ( -- ) %11 DCFG bis! ;

: usb-init ( -- )
	usb-on
	usb-gpio
	usb-force-device
	usb-enable
	usb-fullspeed ;

0 variable in-pending
0 variable in-ready
0 variable in-data
0 variable baud
0 variable dtr

13 bit constant ENUMDNE
: enum-done? ( irq -- ? ) ENUMDNE and 0<> 1-foldable inline ;

4 bit constant RXFLVL
: rx-fifo? ( irq -- ? ) RXFLVL and 0<> 1-foldable inline ;
: new-packet? ( irq -- ? ) rx-fifo? in-pending @ 0= and 1-foldable inline ;

%0001 constant type-out-nak
%0010 constant type-out
%0011 constant type-out-done
%0100 constant type-setup-done
%0110 constant type-setup

$88776655 $44332211 2variable usb-buf
usb-buf 1+  constant usb-req
usb-buf 2+  constant usb-val
usb-buf 6 + constant usb-len

: save-setup ( -- )
	fifo0 @ usb-buf !
	fifo0 @ usb-buf cell+ ! ;

: clear-nak ( status -- )
	$f and 5 lshift DOEPCTL0 + 26 bit swap bis! ;

: >ep    ( status -- ep    ) $f and inline 1-foldable ;
: ep0?   ( status -- ?     ) >ep 0 = inline 1-foldable ;
: ep1?   ( status -- ?     ) >ep 1 = inline 1-foldable ;
: >count ( status -- count ) 4 rshift $7ff and inline 1-foldable ;
: >type  ( status -- type  ) 17 rshift $f and inline 1-foldable ;


: data. ( data -- )
	base @ hex swap ( base data )
	rev 0 <# # # bl hold # # bl hold # # bl hold # # #> type ( base )
	base ! ( data ) ;

: usb-send0 ( addr len -- )
	\ truncate the packet to what the USB host ordered
	usb-len h@ min ( addr len )
	\ set the packet length
	dup DIEPTSIZ0 ! ( addr len )
	\ enable the endpoint 0 and clear NAK
	31 bit 26 bit or DIEPCTL0 bis! ( addr len )
	\ copy the packet into the fifo
	over + swap ?do i @ fifo0 ! 4 +loop ;
	\ 0 ?do ( addr )
	\ 	dup i + @ ( addr data )
	\ 	fifo0 ! ( addr )
	\ 4 +loop drop ;


: usb-irq@ ( -- irq ) GINTSTS @ dup GINTSTS ! ;


\ Print the bit indices of all active USB IRQs
: usb-irq. ( irq -- )
	dup $04008028 bic if ( irq )
		\ Start a new block of trace messages
		cr ." -------------------------------------------------------------------------------"
		cr ." USB: irqs = "
		32 0 do ( irq )
			i bit over and if ( irq )
				i . ( irq )
			then
		loop
	then drop ;

: fifo-setup ( -- )
	512 4 / GRXFSIZ !                          \ 512b for RX all
	128 4 / 16 lshift 512 or        DIEPTXF0 ! \ 128b for TX ep0
	512 4 / 16 lshift 512 or 128 or DIEPTXF1 ! \ 512b for TX ep1

	\ see p.1354
    \ Configure endpoint 1 IN:
    31 bit          \ enable endpoint
    26 bit or       \ clear NAK bit
	1 22 lshift or  \ use fifo 1
    2 18 lshift or  \ endpoint type = BULK
    15 bit or       \ activate endpoint
    64 or           \ max packet size
    DIEPCTL1 !

    \ Configure endpoint 2 IN:
	2 22 lshift     \ use fifo 2
    3 18 lshift or  \ endpoint type = INTERRUPT
    15 bit or       \ activate endpoint
    64 or           \ max packet size
    DIEPCTL2 !

    \ Configure endpoint 0 OUT:
	3 29 lshift     \ allow up to three setup packets
    64 or           \ transfer size
    DOEPTSIZ0 !
	31 bit          \ enable endpoint
    26 bit or       \ clear NAK bit
    15 bit or       \ activate endpoint
    DOEPCTL0 ! ;

: usb-status@ ( -- status ) GRXSTSP @ inline ;

\ Check for USB CDC class requests (from the SETUP packet)
: set-line-coding?        ( -- ? ) usb-req c@ $20 = inline ;
: get-line-coding?        ( -- ? ) usb-req c@ $21 = inline ;
: set-control-line-state? ( -- ? ) usb-req c@ $22 = inline ;

: baud? ( status -- ? ) ep0? set-line-coding? and i 0= and inline ;
: baud. ( baud -- )
    baud ! ;
: misc. ( data -- )
    drop ;
: usb-decode ( data status -- ) baud? if dup baud. baud ! else misc. then ;

: packet-done? ( n -- ? ) usb-len h@ swap - dup usb-len h! 0= ;

: usb-receive ( status -- )
	dup ep1? if ( status )
		\ This packet contains console input.
		>count in-pending ! ( )
	else ( status )
		\ Decode standard and class requests (only set baudrate implemented)
		dup >count 0 ?do ( status )
			fifo0 @ over usb-decode ( status )
		4 +loop ( status )

		\ Release endpoint 0 host to device FIFO if the packet is complete?
		dup ep0? if ( status )
			>count packet-done? if 0 0 usb-send0 then
		else ( status )
			drop
		then ( )
	then ;

: usb-addr! ( usb-addr -- )
    DCFG @ $ffff80f and DCFG ! ( usb-addr ) \ Clear address
    $7f and 4 lshift DCFG @ or DCFG ! ; ( ) \ Insert address

\ ERRATA:
\   Several STM32Fxxx chips have a documented hardware flaw. The DAD bitfield in the DCFG register doesn't read correctly.
: usb-addr@ ( -- usb-addr )
    DCFG @                \ load the device configuration
    21 lshift 25 rshift ; \ extract the device address

: set-addr ( -- )
	usb-val h@ ( usb-addr )                    \ the wValue from the SETUP packet contains the device address
    usb-addr! ; ( )

: get-desc ( addr len -- addr len )
	usb-val h@ case
		$100 of 2drop dev-data dev-size endof
                $200 of 2drop cfg-data cfg-size endof
        endcase ;

: set-conf ( -- )
        64 dup DOEPTSIZ1 ! \ up to 64 bytes

        15 bit or          \ activate endpoint
        %10 18 lshift or   \ transfer type = BULK
        26 bit or          \ clear NAK
        31 bit or          \ enable endpoint
        DOEPCTL1 ! ;

\ Extract the DTR line state
: set-line ( -- ) usb-val h@ 31 lshift 31 arshift dtr ! ;

: usb-respond ( -- )
        26 bit DOEPCTL0 bis! \ clear NAK bit
	\ Find out which USB request we're supposed to respond to
	0 0 usb-req c@ case ( addr len )
		$05 of set-addr endof
		$06 of get-desc endof
		$09 of set-conf endof
		$22 of set-line endof
	endcase ( addr len )
	usb-len h@ 0= $80 usb-buf cbit@ or ( addr len send? )
	if usb-send0 else 2drop then ( ) ;

: usb-dispatch ( status -- )
	dup >type case ( status )
		type-setup      of drop save-setup  endof
		type-out-done   of      clear-nak   endof
		type-out        of      usb-receive endof
                type-setup-done of drop usb-respond endof
        endcase ;

8                  constant emit-log2
1 emit-log2 lshift constant emit-size
emit-size 1-       constant emit-mask
0                  variable emit-read
0                  variable emit-write
emit-size cell+    buffer:  emit-ring

: emit-used ( -- n ) emit-write @ emit-read @ - inline ;
: emit-full? ( -- ? ) emit-used emit-size = inline ;
: emit-empty? ( -- ? ) emit-used 0= inline ;
: emit-push ( c -- )
    emit-full? if
        drop
    else
        emit-ring emit-write @ emit-mask and + c!
        1 emit-write +!
    then ;
: emit-pop ( -- c )
    emit-empty? if
        0
    else
        emit-ring emit-read @ emit-mask and + c@
        1 emit-read +!
    then ;

\ Because the Cortex M4 core lacks proper circular addressing
\ we have to help it by duplicating the first 32 bits of the ring
\ buffer to make use of the unaligned load hardware support.
: emit-fix ( -- ) emit-ring @ emit-ring emit-size + ! ;

\ You have to call emit-fix between emit-push and emit-pop4.
: emit-pop4 ( -- x )
    emit-empty? if
        0
    else
        emit-ring emit-read @ emit-mask and + @
        4 emit-used min emit-read +!
    then ;

: usb-space ( -- ? ) DTXFSTS1 @ $ffff and cells ;
: usb-idle? ( -- ? ) DTXFSTS1 @ $ffff and 128 = ;

0 variable max-batch
: usb-tx ( -- )
    emit-empty? not dtr @ and if
        usb-idle? if
            emit-used 512 min dup DIEPTSIZ1 !
            dup max-batch @ max max-batch !
            emit-fix 0 do emit-pop4 fifo1 ! 4 +loop
        then
    then ;

: usb-poll ( -- )
        \ Read and clear the USB interrupts
        usb-irq@ \ dup usb-irq. ( irq )

	\ Setup FIFOs after enumeration
	dup enum-done? if fifo-setup then ( irq )

	\ Dispatch the received USB packet if there is one
        new-packet? if
        usb-status@
        usb-dispatch
    then

    usb-tx ;

: usb-enum ( -- )
        usb-irq@ dup usb-irq. ( irq )
        enum-done? if fifo-setup then ;

: usb-key? ( -- ? ) usb-poll in-ready @ 0 > in-pending @ 0 > or ;

: (usb-key) ( -- c )
    in-ready @ 0= if ( )
        in-pending @ dup 4 min dup in-ready ! - in-pending !
        fifo1 @ in-data ! ( pending )
    then
    -1 in-ready +!
    in-data @ dup 8 rshift in-data ! $ff and ;

: usb-key ( -- c ) begin usb-key? until (usb-key) ;

: usb-emit? ( -- ? ) usb-poll emit-full? not dtr @ 0= or ;

: usb-emit ( c -- ) begin usb-emit? until emit-push ;

: +usb ( -- )
    ['] usb-key?  hook-key?  !
    ['] usb-key   hook-key   !
    ['] usb-emit? hook-emit? !
    ['] usb-emit  hook-emit  !
;

: -usb ( -- )
    ['] serial-key?  hook-key?  !
    ['] serial-key   hook-key   !
    ['] serial-emit? hook-emit? !
    ['] serial-emit  hook-emit  !
;
