\ THIS IS WORK IN PROGRESS ... NOTHINGING REALLY WORKS
\ DO NOT USE
\ YOU HAVE BEEN WARNED

$40020000 constant FTFL_FSTAT \ Flash Status Register
$40020006 constant FTFL_FCCOB1 \ Flash Common Command Object Registers 
$40020007 constant FTFL_FCCOB0 \ Flash Common Command Object Registers
$40020008 constant FTFL_FCCOB7 \ Flash Common Command Object Registers (note 6,5,4 follow in memory)
$40048034 constant SIM_SCGC4
$4007209C constant USB0_BDTPAGE1
$400720B0 constant USB0_BDTPAGE2
$400720B4 constant USB0_BDTPAGE3
$40072080 constant USB0_ISTAT \ Interrupt Status register 
$40072088 constant USB0_ERRSTAT \ Error Interrupt Status register 
$40072010 constant USB0_OTGiSTAT \ OTG Interrupt Status register (
$4007210C constant USB0_USBTRC0 \ USB Transceiver Control Register 0 
$40072094 constant USB0_CTL \ Control register (USB0_CTL)
$40072100 constant USB0_USBCTRL \ USB Control register
$40072084 constant USB0_INTEN \ Interrupt Enable register
$40072108 constant USB0_CONTROL \ USB OTG Control register  

[struct
	0 field wRequestAndType
	1 field bmRequestType
	1 field bRequest
	2 field wValue
	2 field  wIndex
	2 field wLength
	4 field word1
	4 field word2
struct] setup_t 

create setup setup_t allot

\ -----------------------
\ Buffer descriptor table
\ -----------------------

[struct
	4 field desc
	4 field addr
struct] bdt_t

: aligned-512 ( addr -- even-on-512 )
  dup $1FF and if $1FF bic $200 + then
  1-foldable
;

: bdt-array				  \ ( #elements -- ) ; ( element# -- address )
  <builds here 4 + dup	 	      	  \ Skip 4 bytes to store the offset to the 512 byte boundary
  	  aligned-512 swap - dup 	  \ Calculate required offset
	  	      4 + ,		  \ Store offset (account for 4-bytes used for holding offset)
		      allot  		  \ Allocate space to get to boundary
	  bdt_t * allot	     	   	  \ Create space for an n-element buffer descriptor table
  does>  dup @ + 	     		  \ Get to even 512 boundary by reading offset and adding to base
  	 swap bdt_t * +	     		  \ get to n-th element
;

5 bdt-array bdt  \ create a 5 element buffer descriptor table

: bdt-clear ( 512-a-addr numelements -- )
  0 do 
    0 i bdt desc !
    0 i bdt addr !
  loop 
;


\ -------------
\ USB Serial ID  	  
\ -------------
0 variable usb-serial#
\ Note:  on my develop system the serial number is 0x00007B83 or 31619
: usb-get-serial# ( -- n ) 
  dint
  %01110000 FTFL_FSTAT c! \ clear flash memory erros
  $41 FTFL_FCCOB0 c!      \ Read 4 bytes of a dedicated 64 byte field in the program flash IFR
  15 FTFL_FCCOB1 c!       \ Last 4-byte segment of the program once
     		          \ field within the IFR - holds serial number
  $80 FTFL_FSTAT c!       \ launch the command
  begin $80 FTFL_FSTAT cbit@ until  \ Wait for CCIF to toggle back to 1
  FTFL_FCCOB7 @	       \ Get the result
  eint
;


  
: usb-clock-enable ( -- ) 1 18 lshift SIM_SCGC4 bis! ;

: usb-reset ( -- )
  $80 USB0_USBTRC0 c!
  begin $80 USB0_USBTRC0 cbit@ not until  \ Wait for reset to end
;

: usb-bdt-page-set ( 512a-addr -- )
  dup  8 rshift USB0_BDTPAGE1 c!
  dup 16 rshift USB0_BDTPAGE2 c!
      24 rshift USB0_BDTPAGE3 c!
;

: usb-init ( -- )
  
  usb-get-serial# usb-serial# !
  5 bdt-clear

  \ this basically follows the flowchart in the Kinetis
  \ Quick Reference User Guide, 1. Rev, 03/2012, page 141

  usb-clock-enable
  usb-reset 
  usb-bdt-page-set

  \ set desc table base addr

\ clear all ISR flags


	$FF USB0_ISTAT c!
	$FF USB0_ERRSTAT c!
	$FF USB0_OTGISTAT c!

	$40 USB0_USBTRC0 CBIT! \ undocumented bit NO IDEA WHY

	\ enable USB
	1 USB0_CTL c!
	0 USB0_USBCTRL c!

	\ enable reset interrupt
	1 USB0_INTEN c!

	\ enable interrupt in NVIC...
\ STILL NEED TO IMPLEMENT PRIUORITIES	NVIC_SET_PRIORITY(IRQ_USBOTG, 112);
	73 irq-enable

	\ enable d+ pullup
	$10 USB0_CONTROL c!
;
 
: usb-isr
