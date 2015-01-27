\ Requires "nvic.txt"

\ Byte registers for UART control
$4006A000 constant UART0_BDH
$4006A001 constant UART0_BDL
$4006A002 constant UART0_C1
$4006A003 constant UART0_C2
$4006A004 constant UART0_S1
$4006A005 constant UART0_S2
$4006A006 constant UART0_C3
$4006A007 constant UART0_D
$4006A008 constant UART0_MA1
$4006A009 constant UART0_MA2
$4006A00A constant UART0_C4
$4006A00B constant UART0_C5
$4006A00C constant UART0_ED
$4006A00D constant UART0_MODEM
$4006A00E constant UART0_IR
$4006A010 constant UART0_PFIFO
$4006A011 constant UART0_CFIFO
$4006A012 constant UART0_SFIFO
$4006A013 constant UART0_TWFIFO
$4006A014 constant UART0_TCFIFO
$4006A015 constant UART0_RWFIFO
$4006A016 constant UART0_RCFIFO

\ Mask constants
%00001100 constant UART0_RETE
%00000100 constant UART0_RE


: uart0e-status ( -- )
	\ This routine ignores ISO7816 errors
	\ The MK20DX256 error interrupt combines Receiver overrun, Noise flag, framing error, parity error, 
	\ transmitter buffer overflow, and Receiver buffer underflow
	UART0_S1 c@
	dup $08 and 0<> if ." Receiver overrun error" CR  then
	dup $04 and 0<> if ." Noise error" CR then
	dup $02 and 0<> if ." Framing error" CR then
	$01 and 0<> if ." Parity error" CR then
	UART0_SFIFO c@
        dup $04 and 0<> if ." Receiver buffer overflow error" CR then
        dup $02 and 0<> if ." Transmitter buffer overflow error" CR then
        $01 and 0<> if ." Receiver buffer underflow error" CR then
;

: uart0e-clear ( -- )
  \ Clear all uart0 errors.  Note:  data will be lost -- but it was unrecoverable anyway
  uart0_s1 c@ uart0_d c@ \ Read S! then D to clear overrun, noise, framing and parity errors
  %11000111 uart0_cfifo c! \ Flush TX and RX (make sure interrupts still enabled) 
  %00000111 uart0_sfifo c! \ Clear TX + RX overrun and RX underun condition
  46 irq-enable-mask-offset $E000E280 + !	\ Clear interrupt pending (I think only needed if triggered via software)
;
		

\ Routine to enable UART Error Interrupts
\ Requires irq-enable from "nvic.txt"
: uart0e-eint 
  %00101100  uart0_c2 c! \ Enable Receiver full interrupt (and be sure receiver/transmitter still enabled)
  %00001111  uart0_c3 c! \ Enable RX Overrun,  Noise Error, Framing Error, and  Parity Error interrupts
  %00000111  uart0_cfifo c! \ Enable RX+TX FIFIO overrun error + underrun
  46 irq-enable
;

 
: Uart0e-isr
  CR ." Recieved UART0 Error interupt:" CR
  uart0e-status
  uart0e-clear
;

: uart0-disable ( -- ) UART0_RETE UART0_C2 cbic! ;
: uart0-enable ( -- ) UART0_RETE UART0_C2 cbis! ;

\ ------------------------------------------------------------------------------------------
\ Some basic UART code to reset the FIFO watermark
\ ------------------------------------------------------------------------------------------
: uart0-re-disable ( -- )  UART0_RE UART0_C2 cbic! ;
: uart0-re-enable ( -- ) UART0_RE UART0_C2 cbis! ;
: uart0-fifo-size-set ( n -- ) uart0-re-disable uart0_rwfifo c! uart0-re-enable ;
