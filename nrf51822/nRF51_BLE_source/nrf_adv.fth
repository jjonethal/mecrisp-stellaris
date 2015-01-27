#include constants.fth
#include hf_clock.fth
#include rtc.fth

decimal

( random MAC = 46C44BB86E82 )

$AA55AA55
$5A5A5A5A
$00000000 ( MAN DATA )
$333231FF ( MSB_MANUF=FF )
$FFFF1231 ( LSB_MANUF=FF, MAN_SD=FF, LEN=12, '1' )
$30303046 ( "000F"
$526E0908 ( 'R', 'n', NAME=09, LEN=08 )
$02010246 ( LE_GEN_DM=02, FLAGS=01, LEN=02, MAC[5]=46 )
$C44BB86E ( MAC[4..1] )
$82002542 ( MAC[0]=82, S1=0, TOTAL_LEN=25, PDUTYPE/TXADD=42 ) 
10 nvariable .adv_pdu

.adv_pdu 1+ constant .pdu_len
.adv_pdu 9 + constant .pdu_data
.adv_pdu 28 + constant .pdu_md

0 variable .adv_state
		
: adv_send				( channel -- )
	dup .adv_state !
	.adv_pdu radio_send	
;

: radio_dis_irq
	0 NRF_RADIO_DISABLED !		( clear disabled event )
	250 TIMER2 init_timer
;

: timer2_cc_irq
	TIMER2 dup clear_timer_CCE stop_timer
	.adv_state @
	case
		0  of 37 adv_send endof
		37 of 38 adv_send endof
		38 of 39 adv_send endof
\		39 of
\			TIMER2 stop_timer
\			0 NRF_RADIO_POWER !
\		endof
		58 of
			50000 TIMER2 init_timer
			0 .adv_state !
			.pdu_md @ 4030201 + .pdu_md !
			\ 30 emit cr
		endof
		50000 TIMER2 init_timer
		1 .adv_state +!
	endcase
;

#const NRF_RADIO_INTSET $40001304

: rt
	init_radio
	['] radio_dis_irq irq-radio !
	$10 NRF_RADIO_INTSET !			\ Set interrupt enable on radio disable
	2 NVIC_ISER bis!				\ Enable Radio Interrupt in global Interrupt Controller
	['] timer2_cc_irq TIMER2 en_timer_CCi
	timer2_cc_irq					\ Kickstart radio		
;
