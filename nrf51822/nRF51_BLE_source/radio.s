	.equ RADIO,							0x40001000
	.equ RADIO_TXEN,					RADIO + 0x000
	.equ RADIO_RXEN,					RADIO + 0x004
	.equ RADIO_START,					RADIO + 0x008
	.equ RADIO_STOP,					RADIO + 0x00C
	.equ RADIO_DISABLE,					RADIO + 0x010
	.equ RADIO_READY,					RADIO + 0x100
	.equ RADIO_DISABLED,				RADIO + 0x110
	.equ RADIO_SHORTS,					RADIO + 0x200
	.equ RADIO_PACKETPTR,				RADIO + 0x504
	.equ RADIO_FREQUENCY,				RADIO + 0x508
	.equ RADIO_TXPOWER,					RADIO + 0x50C
	.equ RADIO_MODE,					RADIO + 0x510
	.equ RADIO_PCNF0,					RADIO + 0x514
	.equ RADIO_PCNF1,					RADIO + 0x518
	.equ RADIO_BASE0,					RADIO + 0x51C
	.equ RADIO_BASE1,					RADIO + 0x520
	.equ RADIO_PREFIX0,					RADIO + 0x524
	.equ RADIO_PREFIX1,					RADIO + 0x528
	.equ RADIO_TXADDRESS,				RADIO + 0x52C
	.equ RADIO_RXADDRESSES,				RADIO + 0x530
	.equ RADIO_CRCCNF,					RADIO + 0x534
	.equ RADIO_CRCPOLY,					RADIO + 0x538
	.equ RADIO_CRCINIT,					RADIO + 0x53C
	.equ RADIO_DATAWHITEIV,				RADIO + 0x554
	.equ RADIO_POWER,					RADIO + 0xFFC	
		
Wortbirne Flag_visible, "init_radio"
init_radio: @ (  -- ) 

@	0 RADIO_POWER !
  ldr r1, =RADIO_POWER
  movs r0, #0
  str r0, [r1]
@	1 RADIO_POWER !
  movs r0, #1
  str r0, [r1]
@	3 RADIO_MODE !
  ldr r1, =RADIO_MODE
  movs r0, #3
  str r0, [r1]
@	20106 RADIO_PCNF0 !
  ldr r1, =RADIO_PCNF0
  ldr r0, =0x20106
  str r0, [r1]
@	2030027 RADIO_PCNF1 !
  ldr r1, =RADIO_PCNF1
  ldr r0, =0x2030027
  str r0, [r1]
@	89BED600 dup RADIO_BASE0 ! RADIO_BASE1 !
  ldr r1, =RADIO_BASE0
  ldr r0, =0x89BED600
  str r0, [r1]
  ldr r1, =RADIO_BASE1
  str r0, [r1]
@	8E dup RADIO_PREFIX0 ! RADIO_PREFIX1 !
  ldr r1, =RADIO_PREFIX0
  movs r0, #0x8E
  str r0, [r1]
  ldr r1, =RADIO_PREFIX1
  str r0, [r1]
@	0 RADIO_TXADDRESS !
  ldr r1, =RADIO_TXADDRESS
  movs r0, #0
  str r0, [r1]
@	0 RADIO_RXADDRESSES !
  ldr r1, =RADIO_RXADDRESSES
  str r0, [r1]
@	103 RADIO_CRCCNF !
  ldr r1, =RADIO_CRCCNF
  ldr r0, =0x103
  str r0, [r1]
@	000065B RADIO_CRCPOLY !
  ldr r1, =RADIO_CRCPOLY
  ldr r0, =0x65B
  str r0, [r1]
@	555555 RADIO_CRCINIT !
  ldr r1, =RADIO_CRCINIT
  ldr r0, =0x555555
  str r0, [r1]
@	3 RADIO_SHORTS ! ( Ready -> Start & End -> Disable )
  ldr r1, =RADIO_SHORTS
  movs r0, #0x3
  str r0, [r1]
  bx lr

Wortbirne Flag_visible, "set_radio_power"
set_radio_power: @ ( F -- ) 

  ldr r1, =RADIO_TXPOWER
  popda r0
  str r0, [r1]
  bx lr
  
Wortbirne Flag_visible, "set_ble_chan"
set_ble_chan: @ ( C -- ) 
  
  ldr r1, =RADIO_DATAWHITEIV
  popda r0
  str r0, [r1]
@	case
@	  25 of 2 endof
  movs r1, #2
  cmp r0, #0x25
  beq 1f
@	  26 of 1A endof
  movs r1, #0x1A
  cmp r0, #0x26
  beq 1f
@	  27 of 50 endof
  movs r1, #0X50
  cmp r0, #0x27
  beq 1f
@	  dup dup A <= ?of 2* 4 + endof
  mov r1, r0
  add r1, r1
  movs r2, #4
  add r1, r2
  cmp r0, #0xA
  ble 1f
@	  dup 2* 6 + swap
  movs r2, #2
  add r1, r2
@	endcase
1:
@	RADIO_FREQUENCY !
  ldr r0, =RADIO_FREQUENCY
  str r1, [r0]	
   bx lr 
 
Wortbirne Flag_visible, "radio_send"
radio_send: @ ( le_ch, .pkt -- ) 
  push {lr}
@	RADIO_PACKETPTR !
  ldr r1, =RADIO_PACKETPTR
  popda r0
  str r0, [r1]

  bl set_ble_chan
  
@	0 RADIO_DISABLED !
  ldr r1, =RADIO_DISABLED
  movs r0, #0
  str r0, [r1]
@	1 RADIO_TXEN !
  ldr r1, =RADIO_TXEN
  movs r0, #1
  str r0, [r1]
@;
  pop {pc}

Wortbirne Flag_visible, "radio_receive"
radio_receive: @ ( le_ch, .pkt -- ) 
  push {lr}
@	RADIO_PACKETPTR !
  ldr r1, =RADIO_PACKETPTR
  popda r0
  str r0, [r1]

  bl set_ble_chan
  
@	0 RADIO_DISABLED !
  ldr r1, =RADIO_DISABLED
  movs r0, #0
  str r0, [r1]
@	1 RADIO_RXEN !
  ldr r1, =RADIO_RXEN
  movs r0, #1
  str r0, [r1]
@;
  pop {pc}

Wortbirne Flag_visible, "wait_radio_disabled"
wait_radio_disabled: @ (  -- ) 
  ldr r1, =RADIO_DISABLED
2:
  ldr r0, [r1]
  cmp r0, #0
  beq 2b
  movs r0, #0
  str r0, [r1]
  bx lr
Wortbirne Flag_visible, "radio_disable"
radio_disable: @ (  -- ) 
  ldr r1, =RADIO_DISABLE
  movs r0, #1
  str r0, [r1]
  bx lr
  
Wortbirne Flag_visible, "radio_stop"
radio_stop: @ (  -- ) 
  ldr r1, =RADIO_STOP
  movs r0, #1
  str r0, [r1]
  bx lr

Wortbirne Flag_visible, "clear_radio_event"
clear_radio_event: @ ( E# -- )
  popda r0
  add r0, r0
  add r0, r0
  ldr r1, =RADIO_READY
  add r1, r0
  movs r0, #0
  str r0, [r1]
  bx lr
  
Wortbirne Flag_visible, "get_radio_event"
radio_task: @ ( E# -- E )
  add tos, tos
  add tos, tos
  ldr r1, =RADIO_READY
  add r1, tos
  ldr tos, [r1]
  bx lr

.ltorg
 