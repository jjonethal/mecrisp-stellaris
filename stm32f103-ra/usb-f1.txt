
\ USB driver for STM32F103 by Jean-Claude Wippler, 
\   configured for Shenzhen LC Technology board with STM32F103C8T6.

\ The board specific code is in +usb and needs to be changed for other
\ ways to signal a new connection by pulling D+ low briefly.

\ Other configs are available here:
\ https://github.com/jeelabs/embello/tree/master/explore/1608-forth/suf

compiletoflash

\ -----------------------------------------------------------------------------
\  Small helpers
\ -----------------------------------------------------------------------------

: bit ( u -- u )  \ turn a bit position into a single-bit mask
  1 swap lshift  1-foldable ;

\ -----------------------------------------------------------------------------
\  Chip serial number
\ -----------------------------------------------------------------------------

: chipid ( -- u1 u2 u3 3 )  \ unique chip ID as N values on the stack
  $1FFFF7E8 @ $1FFFF7EC @ $1FFFF7F0 @ 3 ;
: hwid ( -- u )  \ a "fairly unique" hardware ID as single 32-bit int
  chipid 1 do xor loop ;

\ -----------------------------------------------------------------------------
\  IO Registers
\ -----------------------------------------------------------------------------

$40013800 constant USART1
   USART1 $8 + constant USART1-BRR

$40021000 constant RCC
     RCC $00 + constant RCC-CR
     RCC $04 + constant RCC-CFGR
     RCC $1C + constant RCC-APB1ENR

$40022000 constant FLASH
    FLASH $0 + constant FLASH-ACR

\ -----------------------------------------------------------------------------
\  Clock setup and timing
\ -----------------------------------------------------------------------------

\ adjusted for STM32F103 @ 72 MHz (original STM32F100 by Igor de om1zz, 2015)

: 72MHz ( -- )  \ set the main clock to 72 MHz, keep baud rate at 115200
  $12 FLASH-ACR !                 \ two flash mem wait states
  16 bit RCC-CR bis!              \ set HSEON
  begin 17 bit RCC-CR bit@ until  \ wait for HSERDY
  1 16 lshift                     \ HSE clock is 8 MHz Xtal source for PLL
  7 18 lshift or                  \ PLL factor: 8 MHz * 9 = 72 MHz = HCLK
  4  8 lshift or                  \ PCLK1 = HCLK/2
  2 14 lshift or                  \ ADCPRE = PCLK2/6
            2 or  RCC-CFGR !      \ PLL is the system clock
  24 bit RCC-CR bis!              \ set PLLON
  begin 25 bit RCC-CR bit@ until  \ wait for PLLRDY
  625 USART1-BRR !                \ fix console baud rate
;

\ -----------------------------------------------------------------------------
\   Flash tools
\ -----------------------------------------------------------------------------

\ emulate c, which is not available in hardware on some chips.
\ copied from Mecrisp's common/charcomma.txt
0 variable c,collection

: c, ( c -- )  \ emulate c, with h,
  c,collection @ ?dup if $FF and swap 8 lshift or h,
                         0 c,collection !
                      else $100 or c,collection ! then ;

: calign ( -- )  \ must be called to flush after odd number of c, calls
  c,collection @ if 0 c, then ;


: flash-kb ( -- u )  \ return size of flash memory in KB
  $1FFFF7E0 h@ ;
: flash-pagesize ( addr - u )  \ return size of flash page at given address
  drop flash-kb 128 <= if 1024 else 2048 then ;

: cornerstone ( "name" -- )  \ define a flash memory cornerstone
  <builds begin here dup flash-pagesize 1- and while 0 h, repeat
  does>   begin dup  dup flash-pagesize 1- and while 2+   repeat  cr
  eraseflashfrom ;

\ -----------------------------------------------------------------------------
\  Ring buffers
\ -----------------------------------------------------------------------------

\ ring buffers, for serial ports, etc - size must be 4..256 and power of 2
\ TODO setup is a bit messy right now, should put buffer: word inside init

\ each ring needs 4 extra bytes for internal housekeeping:
\   addr+0 = ring mask, i.e. N-1
\   addr+1 = put index: 0..255 (needs to be masked before use)
\   addr+2 = get index: 0..255 (needs to be masked before use)
\   addr+3 = spare
\   addr+4..addr+4+N-1 = actual ring buffer, N bytes
\ example:
\   16 4 + buffer: buf  buf 16 init-ring

: init-ring ( addr size -- )  \ initialise a ring buffer
  1- swap !  \ assumes little-endian so mask ends up in ring+0
;

: c++@ ( addr -- b addr+1 ) dup c@ swap 1+ ;  \ fetch and autoinc byte ptr

: ring-step ( ring 1/2 -- addr )  \ common code for saving and fetching
  over + ( ring ring-g/p ) dup c@ >r ( ring ring-g/p R: g/p )
  dup c@ 1+ swap c!  \ increment byte under ptr
  dup c@ r> and swap 4 + + ;

: ring# ( ring -- u )  \ return current number of bytes in the ring buffer
\ TODO could be turned into a single @ word access and made interrupt-safe
  c++@ c++@ c++@ drop - and ;
: ring? ( ring -- f )  \ true if the ring can accept more data
  dup ring# swap c@ < ;
: >ring ( b ring -- )  \ save byte to end of ring buffer
  1 ring-step c! ;
: ring> ( ring -- b )  \ fetch byte from start of ring buffer
  2 ring-step c@ ;

\ -----------------------------------------------------------------------------
\  USB Descriptors
\ -----------------------------------------------------------------------------

create usb:dev
  18 c,  \ bLength
  $01 c, \ USB_DEVICE_DESCRIPTOR_TYPE
  $00 c,
  $02 c, \ bcdUSB = 2.00
  $02 c, \ bDeviceClass: CDC
  $00 c, \ bDeviceSubClass
  $00 c, \ bDeviceProtocol
  $40 c, \ bMaxPacketSize0
  $83 c,
  $04 c, \ idVendor = 0x0483
  $40 c,
  $57 c, \ idProduct = 0x7540
  $00 c,
  $02 c, \ bcdDevice = 2.00
  1 c,     \ Index of string descriptor describing manufacturer
  2 c,     \ Index of string descriptor describing product
  3 c,     \ Index of string descriptor describing the device's serial number
  $01 c, \ bNumConfigurations
calign

create usb:conf  \ total length = 67 bytes
\ USB Configuration Descriptor
  9 c,   \ bLength: Configuration Descriptor size
  $02 c, \ USB_CONFIGURATION_DESCRIPTOR_TYPE
  67 c,  \ VIRTUAL_COM_PORT_SIZ_CONFIG_DESC
  0 c,
  2 c,   \ bNumInterfaces: 2 interface
  1 c,   \ bConfigurationValue
  0 c,   \ iConfiguration
  $C0 c, \ bmAttributes: self powered
  $32 c, \ MaxPower 0 mA
\ Interface Descriptor
  9 c,   \ bLength: Interface Descriptor size
  $04 c, \ USB_INTERFACE_DESCRIPTOR_TYPE
  $00 c, \ bInterfaceNumber: Number of Interface
  $00 c, \ bAlternateSetting: Alternate setting
  $01 c, \ bNumEndpoints: One endpoints used
  $02 c, \ bInterfaceClass: Communication Interface Class
  $02 c, \ bInterfaceSubClass: Abstract Control Model
  $01 c, \ bInterfaceProtocol: Common AT commands
  $00 c, \ iInterface:
\ Header Functional Descriptor
  5 c,   \ bLength: Endpoint Descriptor size
  $24 c, \ bDescriptorType: CS_INTERFACE
  $00 c, \ bDescriptorSubtype: Header Func Desc
  $10 c, \ bcdCDC: spec release number
  $01 c,
\ Call Management Functional Descriptor
  5 c,   \ bFunctionLength
  $24 c, \ bDescriptorType: CS_INTERFACE
  $01 c, \ bDescriptorSubtype: Call Management Func Desc
  $00 c, \ bmCapabilities: D0+D1
  $01 c, \ bDataInterface: 1
\ ACM Functional Descriptor
  4 c,   \ bFunctionLength
  $24 c, \ bDescriptorType: CS_INTERFACE
  $02 c, \ bDescriptorSubtype: Abstract Control Management desc
  $02 c, \ bmCapabilities
\ Union Functional Descriptor
  5 c,   \ bFunctionLength
  $24 c, \ bDescriptorType: CS_INTERFACE
  $06 c, \ bDescriptorSubtype: Union func desc
  $00 c, \ bMasterInterface: Communication class interface
  $01 c, \ bSlaveInterface0: Data Class Interface
\ Endpoint 2 Descriptor
  7 c,   \ bLength: Endpoint Descriptor size
  $05 c, \ USB_ENDPOINT_DESCRIPTOR_TYPE
  $82 c, \ bEndpointAddress: (IN2)
  $03 c, \ bmAttributes: Interrupt
  8 c,   \ VIRTUAL_COM_PORT_INT_SIZE
  0 c,
  $FF c, \ bInterval:
\ Data class interface descriptor
  9 c,   \ bLength: Endpoint Descriptor size
  $04 c, \ USB_INTERFACE_DESCRIPTOR_TYPE
  $01 c, \ bInterfaceNumber: Number of Interface
  $00 c, \ bAlternateSetting: Alternate setting
  $02 c, \ bNumEndpoints: Two endpoints used
  $0A c, \ bInterfaceClass: CDC
  $00 c, \ bInterfaceSubClass:
  $00 c, \ bInterfaceProtocol:
  $00 c, \ iInterface:
\ Endpoint 3 Descriptor
  7 c,   \ bLength: Endpoint Descriptor size
  $05 c, \ USB_ENDPOINT_DESCRIPTOR_TYPE
  $03 c, \ bEndpointAddress: (OUT3)
  $02 c, \ bmAttributes: Bulk
  64 c,  \ VIRTUAL_COM_PORT_DATA_SIZE
  0 c,
  $00 c, \ bInterval: ignore for Bulk transfer
\ Endpoint 1 Descriptor
  7 c,   \ bLength: Endpoint Descriptor size
  $05 c, \ USB_ENDPOINT_DESCRIPTOR_TYPE
  $81 c, \ bEndpointAddress: (IN1)
  $02 c, \ bmAttributes: Bulk
  64 c,  \ VIRTUAL_COM_PORT_DATA_SIZE
  0 c,
  $00 c, \ bInterval
calign

create usb:langid
  4 c, 3 c,  \ USB_STRING_DESCRIPTOR_TYPE,
  $0409 h, \ LangID = U.S. English

create usb:vendor
  40 c, 3 c,  \ USB_STRING_DESCRIPTOR_TYPE,
  char M h, char e h, char c h, char r h, char i h, char s h, char p h,
  bl     h, char ( h, char S h, char T h, char M h, char 3 h, char 2 h,
  char F h, char 1 h, char 0 h, char x h, char ) h,

create usb:product
  36 c, 3 c,  \ USB_STRING_DESCRIPTOR_TYPE,
  char F h, char o h, char r h, char t h, char h h, bl     h, char S h,
  char e h, char r h, char i h, char a h, char l h, bl     h, char P h,
  char o h, char r h, char t h,

create usb:line
  hex 00 c, C2 c, 01 c, 00 c, 01 c, 00 c, 08 c, 00 c, decimal

\ -----------------------------------------------------------------------------
\  USB module initialisation values
\ -----------------------------------------------------------------------------

create usb:init
hex
  0080 h,  \ ADDR0_TX   control - rx: 64b @ +040/080, tx: 64b @ +080/100
  0000 h,  \ COUNT0_TX
  0040 h,  \ ADDR0_RX
  8400 h,  \ COUNT0_RX
  00C0 h,  \ ADDR1_TX   bulk - tx: 64b @ +0C0/180
  0000 h,  \ COUNT1_TX
  0000 h,  \ ADDR1_RX
  0000 h,  \ COUNT1_RX
  0140 h,  \ ADDR2_TX   interrupt - tx: 8b @ +140/280
  0000 h,  \ COUNT2_TX
  0000 h,  \ ADDR2_RX
  0000 h,  \ COUNT2_RX
  0000 h,  \ ADDR3_TX   bulk - rx: 64b @ +100/200
  0000 h,  \ COUNT3_TX
  0100 h,  \ ADDR3_RX
  8400 h,  \ COUNT3_RX
decimal

$40005C00 constant USB
     USB $00 + constant USB-EP0R
     USB $40 + constant USB-CNTR
     USB $44 + constant USB-ISTR
     USB $48 + constant USB-FNR
     USB $4C + constant USB-DADDR
     USB $50 + constant USB-BTABLE
$40006000 constant USBMEM

\ -----------------------------------------------------------------------------
\  USB peripheral module handling
\ -----------------------------------------------------------------------------

: usb-pma ( pos -- addr ) dup 1 and negate swap 2* + USBMEM + ;
: usb-pma@ ( pos -- u ) usb-pma h@ ;
: usb-pma! ( u pos -- ) usb-pma h! ;

: ep-addr ( ep -- addr ) cells USB-EP0R + ;
: ep-reg ( ep n -- addr ) 2* swap 8 * + usb-pma ;

: rxstat! ( ep u -- )  \ set stat_rx without toggling/setting any other fields
  swap ep-addr >r
  12 lshift  r@ h@ tuck  xor
\  R^rrseekT^ttnnnn
\  5432109876543210
  %0011000000000000 and swap
  %0000111100001111 and
  %1000000010000000 or
  or r> h! ;

: txstat! ( ep u -- )  \ set stat_tx without toggling/setting any other fields
  swap ep-addr >r
  4 lshift  r@ h@ tuck  xor
\  R^rrseekT^ttnnnn
\  5432109876543210
  %0000000000110000 and swap
  %0000111100001111 and
  %1000000010000000 or
  or r> h! ;

: ep-reset-rx# ( ep -- ) $8400 over 3 ep-reg h! 3 rxstat! ;
: rxclear ( ep -- ) ep-addr dup h@ $7FFF and $8F8F and swap h! ;
: txclear ( ep -- ) ep-addr dup h@ $FF7F and $8F8F and swap h! ;

0 0 2variable usb-pend
18 buffer: usb-serial

: set-serial ( -- addr )  \ fill serial number in as UTF-16 descriptor
  base @ hex
  hwid 0 <# 8 0 do # loop #> ( base addr 8 )
  0 do dup c@ i 1+ 2* usb-serial + h! 1+ loop
  drop base !
  usb-serial $0312 over h! ;

: send-data ( addr n -- ) usb-pend 2! ;
: send-next ( -- )
  usb-pend 2@ 64 min $46 usb-pma@ min
  >r ( addr R: num )
  r@ even 0 ?do
    dup i + h@ $80 i + usb-pma!
  2 +loop drop
  r@ $02 usb-pma! 0 3 txstat!
  usb-pend 2@ r> dup negate d+ usb-pend 2! ;

: send-desc ( -- )
  $42 usb-pma@ case
    $0100 of usb:dev     18 endof
    $0200 of usb:conf    67 endof
    $0300 of usb:langid  4  endof
    $0301 of usb:vendor  40 endof
    $0302 of usb:product 36 endof
    $0303 of set-serial  18 endof
    true ?of 0           0  endof
  endcase send-data ;

: usb-reset ( -- )
  256 0 do  0 i 2* usb-pma! loop  0 USB-BTABLE h!
  usb:init  64 0 do
    dup h@  i USBMEM + h!
    2+
  4 +loop  drop
  $3210 0 ep-addr h!
  $0021 1 ep-addr h!
  $0622 2 ep-addr h!
  $3003 3 ep-addr h!
  $80 USB-DADDR h! ;

\ -----------------------------------------------------------------------------
\  USB packet handling
\ -----------------------------------------------------------------------------

create zero 0 ,

128 4 + buffer: usb-in-ring   \ RX ring buffer, ample for mecrisp input lines
 64 4 + buffer: usb-out-ring  \ TX ring buffer, for outbound bytes

: ep-setup ( ep -- )  \ setup packets, sent from host to config this device
  dup rxclear
  $41 usb-pma c@ case
    $00 of zero 2 send-data endof
    $06 of send-desc endof
    ( default ) 0 0 send-data
  endcase
  ep-reset-rx# send-next ;

0 variable tx.pend
0 variable usb.ticks

: usb-pma-c! ( b pos -- )  \ careful, can't write high bytes separately
  dup 1 and if
    1- dup usb-pma@ rot 8 lshift or swap
  then usb-pma! ;

: usb-fill ( -- )  \ fill the USB outbound buffer from the TX ring buffer
  usb-out-ring ring# ?dup if
    dup tx.pend !
    dup 0 do usb-out-ring ring> $C0 i + usb-pma-c!  loop
    1 1 ep-reg h! 1 3 txstat!
  then ;

: ep-out ( ep -- )  \ outgoing packets, sent from host to this device
\ dup 2 rxstat!  \ set RX state to NAK
  dup if  \ only pick up data for endpoint 3
    usb-in-ring ring# 60 > if drop exit then  \ reject if no room in ring
    dup 3 ep-reg h@ $7F and 0 ?do
      i $100 + usb-pma c@ usb-in-ring >ring
    loop
  then
  dup rxclear
  ep-reset-rx# ;

: ep-in ( ep -- )  \ incoming polls, sent from this device to host
  dup if
    0 usb.ticks !  0 tx.pend !  usb-fill
  else
    $41 usb-pma c@ $05 = if $42 usb-pma@ $80 or USB-DADDR h! then
    send-next
  then
  txclear ;

: usb-ctr ( istr -- )
  dup $07 and swap $10 and if 
    dup ep-addr h@ $800 and if ep-setup else ep-out then
  else ep-in then ;

: usb-flush
  usb-in-ring 128 init-ring
  usb-out-ring 64 init-ring ;

: usb-poll
  \ clear ring buffers if pending output is not getting sent to host
  tx.pend @ if
    1 usb.ticks +!
    usb.ticks @ 10000 u> if usb-flush then
  then
  \ main USB driver polling
  USB-ISTR h@
  dup $8000 and if dup usb-ctr                            then
  dup $0400 and if usb-reset            $FBFF USB-ISTR h! then
  dup $0800 and if %1100 USB-CNTR hbis! $F7FF USB-ISTR h! then
      $1000 and if %1000 USB-CNTR hbic! $EFFF USB-ISTR h! then ;

: usb-key? ( -- f )  pause usb-poll usb-in-ring ring# 0<> ;
: usb-key ( -- c )  begin usb-key? until  usb-in-ring ring> ;
: usb-emit? ( -- f )  usb-poll usb-out-ring ring? ;
: usb-emit ( c -- )  begin usb-emit? until  usb-out-ring >ring
                     tx.pend @ 0= if usb-fill then ;

: usb-io ( -- )  \ start up USB and switch console I/O to it
  23 bit RCC-APB1ENR bis!  \ USBEN
  $0001 USB-CNTR h! ( 10 us ) $0000 USB-CNTR h!  \ FRES
  usb-flush
  ['] usb-key? hook-key? !
  ['] usb-key hook-key !
  1000000 0 do usb-poll loop
  ['] usb-emit? hook-emit? !
  ['] usb-emit hook-emit !
  \ ['] usb-poll hook-pause !
;

\ -----------------------------------------------------------------------------
\  USB connect and disconnect, board specific !
\ -----------------------------------------------------------------------------

: +usb ( -- )  \ Init USB hardware and switch to USB terminal

  72MHz \ This is required for USB use

  \ Board-specific way to briefly pull USB-DP down

  $00050000 $40010804 ( PORTA_CRH ) bis!   \ PA12 Open-Drain Output, keep serial lines.
     12 bit $4001080C ( PORTA_ODR ) bic!
  1000 0 do loop                           \ approx 1ms delay
     12 bit $4001080C ( PORTA_ODR ) bis!

  usb-io
;

: -usb ( -- )  \ Deinit USB hardware, switch back to serial terminal
  1 23 lshift RCC-APB1ENR bic!  \ USBEN
  1 12 lshift $4001080C ( PORTA_ODR ) bic!

  ['] serial-key? hook-key? !
  ['] serial-key hook-key !
  ['] serial-emit? hook-emit? !
  ['] serial-emit hook-emit !
  \ ['] nop hook-pause !
;

\ -----------------------------------------------------------------------------

: init ( -- ) +usb ;

cornerstone eraseflash

