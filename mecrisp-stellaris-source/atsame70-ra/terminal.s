@
@    Mecrisp-Stellaris - A native code Forth implementation for ARM-Cortex M microcontrollers
@    Copyright (C) 2013  Matthias Koch
@
@    This program is free software: you can redistribute it and/or modify
@    it under the terms of the GNU General Public License as published by
@    the Free Software Foundation, either version 3 of the License, or
@    (at your option) any later version.
@
@    This program is distributed in the hope that it will be useful,
@    but WITHOUT ANY WARRANTY; without even the implied warranty of
@    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
@    GNU General Public License for more details.
@
@    You should have received a copy of the GNU General Public License
@    along with this program.  If not, see <http://www.gnu.org/licenses/>.
@

@ Terminal interface for same70q21 xplained via usart1 (CDC channel through usb connection)
@ PB4 = TXD
@ PA21= RXD


@ Terminalroutinen
@ Terminal code and initialisations.
@ Porting: Rewrite this !

//	*-*-*-*-*-*-*-*-
//	REGISTERS SAME70
//	*-*-*-*-*-*-*-*-
//	PMC REGISTERS

.equ    PMC_SCER                ,0x400e0600
.equ    PMC_SCDR                ,0x400e0604
.equ    PMC_SCSR                ,0x400e0608
.equ    PMC_PCER0               ,0x400e0610 
.equ    PMC_PCDR0               ,0x400e0614 
.equ    PMC_PCSR0               ,0x400e0618 
.equ    CKGR_UCKR               ,0x400e061C 
.equ    CKGR_MOR                ,0x400e0620 
.equ    CKGR_MCFR               ,0x400e0624 
.equ    CKGR_PLLAR              ,0x400e0628 
.equ    PMC_MCKR                ,0x400e0630 
.equ    PMC_USB                 ,0x400e0638 
.equ    PMC_PCK0                ,0x400e0640 
.equ    PMC_PCK1                ,0x400e0644 
.equ    PMC_PCK2                ,0x400e0648 
.equ    PMC_IER                 ,0x400e0660 
.equ    PMC_IDR                 ,0x400e0664 
.equ    PMC_SR                  ,0x400e0668 
.equ    PMC_IMR                 ,0x400e066C 
.equ    PMC_FSMR                ,0x400e0670 
.equ    PMC_FSPR                ,0x400e0674 
.equ    PMC_FOCR                ,0x400e0678 
.equ    PMC_WPMR                ,0x400e06E4 
.equ    PMC_WPSR                ,0x400e06E8 
.equ    PMC_PCER1               ,0x400e0700 
.equ    PMC_PCDR1               ,0x400e0704 
.equ    PMC_PCSR1               ,0x400e0708 
.equ    PMC_PCR                 ,0x400e070C


//      MATRIX

.equ    CCFG_SYSIO              ,0x40088114



//      PIOA

.equ    PIOA_PER                 ,0x400e0e00 
.equ    PIOA_PDR                 ,0x400e0e04 
.equ    PIOA_PSR                 ,0x400e0e08 
.equ    PIOA_OER                 ,0x400e0e10 
.equ    PIOA_ODR                 ,0x400e0e14 
.equ    PIOA_OSR                 ,0x400e0e18 
.equ    PIOA_IFER                ,0x400e0e20   
.equ    PIOA_IFDR                ,0x400e0e24   
.equ    PIOA_IFSR                ,0x400e0e28   
.equ    PIOA_SODR                ,0x400e0e30   
.equ    PIOA_CODR                ,0x400e0e34  
.equ    PIOA_ODSR                ,0x400e0e38 
.equ    PIOA_PDSR                ,0x400e0e3C   
.equ    PIOA_IER                 ,0x400e0e40   
.equ    PIOA_IDR                 ,0x400e0e44   
.equ    PIOA_IMR                 ,0x400e0e48   
.equ    PIOA_ISR                 ,0x400e0e4C   
.equ    PIOA_MDER                ,0x400e0e50   
.equ    PIOA_MDDR                ,0x400e0e54   
.equ    PIOA_MDSR                ,0x400e0e58   
.equ    PIOA_PUDR                ,0x400e0e60 
.equ    PIOA_PUER                ,0x400e0e64   
.equ    PIOA_PUSR                ,0x400e0e68 
.equ    PIOA_ABCDSR1             ,0x400e0e70
.equ    PIOA_ABCDSR2             ,0x400e0e74
.equ    PIOA_SCIFSR              ,0x400e0e80  
.equ    PIOA_DIFSR               ,0x400e0e84   
.equ    PIOA_IFDGSR              ,0x400e0e88   
.equ    PIOA_SCDR                ,0x400e0e8C   
.equ    PIOA_OWER                ,0x400e0eA0   
.equ    PIOA_OWDR                ,0x400e0eA4   
.equ    PIOA_OWSR                ,0x400e0eA8   
.equ    PIOA_AIMER               ,0x400e0eB0   
.equ    PIOA_AIMDR               ,0x400e0eB4   
.equ    PIOA_AIMMR               ,0x400e0eB8   
.equ    PIOA_ESR                 ,0x400e0eC0   
.equ    PIOA_LSR                 ,0x400e0eC4   
.equ    PIOA_ELSR                ,0x400e0eC8   
.equ    PIOA_FELLSR              ,0x400e0eD0   
.equ    PIOA_REHLSR              ,0x400e0eD4   
.equ    PIOA_FRLHSR              ,0x400e0eD8   
.equ    PIOA_LOCKSR              ,0x400e0eE0   
.equ    PIOA_WPMR                ,0x400e0eE4   
.equ    PIOA_WPSR                ,0x400e0eE8 




//      PIOB

.equ    PIOB_PER                 ,0x400e1000 
.equ    PIOB_PDR                 ,0x400e1004 
.equ    PIOB_PSR                 ,0x400e1008 
.equ    PIOB_OER                 ,0x400e1010 
.equ    PIOB_ODR                 ,0x400e1014 
.equ    PIOB_OSR                 ,0x400e1018 
.equ    PIOB_IFER                ,0x400e1020   
.equ    PIOB_IFDR                ,0x400e1024   
.equ    PIOB_IFSR                ,0x400e1028   
.equ    PIOB_SODR                ,0x400e1030   
.equ    PIOB_CODR                ,0x400e1034  
.equ    PIOB_ODSR                ,0x400e1038 
.equ    PIOB_PDSR                ,0x400e103C   
.equ    PIOB_IER                 ,0x400e1040   
.equ    PIOB_IDR                 ,0x400e1044   
.equ    PIOB_IMR                 ,0x400e1048   
.equ    PIOB_ISR                 ,0x400e104C   
.equ    PIOB_MDER                ,0x400e1050   
.equ    PIOB_MDDR                ,0x400e1054   
.equ    PIOB_MDSR                ,0x400e1058   
.equ    PIOB_PUDR                ,0x400e1060 
.equ    PIOB_PUER                ,0x400e1064   
.equ    PIOB_PUSR                ,0x400e1068 
.equ    PIOB_ABCDSR1             ,0x400e1070   
.equ    PIOB_ABCDSR2             ,0x400e1074   
.equ    PIOB_SCIFSR              ,0x400e1080  
.equ    PIOB_DIFSR               ,0x400e1084   
.equ    PIOB_IFDGSR              ,0x400e1088   
.equ    PIOB_SCDR                ,0x400e108C   
.equ    PIOB_OWER                ,0x400e10A0   
.equ    PIOB_OWDR                ,0x400e10A4   
.equ    PIOB_OWSR                ,0x400e10A8   
.equ    PIOB_AIMER               ,0x400e10B0   
.equ    PIOB_AIMDR               ,0x400e10B4   
.equ    PIOB_AIMMR               ,0x400e10B8   
.equ    PIOB_ESR                 ,0x400e10C0   
.equ    PIOB_LSR                 ,0x400e10C4   
.equ    PIOB_ELSR                ,0x400e10C8   
.equ    PIOB_FELLSR              ,0x400e10D0   
.equ    PIOB_REHLSR              ,0x400e10D4   
.equ    PIOB_FRLHSR              ,0x400e10D8   
.equ    PIOB_LOCKSR              ,0x400e10E0   
.equ    PIOB_WPMR                ,0x400e10E4   
.equ    PIOB_WPSR                ,0x400e10E8 



//      PIOC

.equ    PIOC_PER                 ,0x400e1200 
.equ    PIOC_PDR                 ,0x400e1204 
.equ    PIOC_PSR                 ,0x400e1208 
.equ    PIOC_OER                 ,0x400e1210 
.equ    PIOC_ODR                 ,0x400e1214 
.equ    PIOC_OSR                 ,0x400e1218 
.equ    PIOC_IFER                ,0x400e1220   
.equ    PIOC_IFDR                ,0x400e1224   
.equ    PIOC_IFSR                ,0x400e1228   
.equ    PIOC_SODR                ,0x400e1230   
.equ    PIOC_CODR                ,0x400e1234  
.equ    PIOC_ODSR                ,0x400e1238 
.equ    PIOC_PDSR                ,0x400e123C   
.equ    PIOC_IER                 ,0x400e1240   
.equ    PIOC_IDR                 ,0x400e1244   
.equ    PIOC_IMR                 ,0x400e1248   
.equ    PIOC_ISR                 ,0x400e124C   
.equ    PIOC_MDER                ,0x400e1250   
.equ    PIOC_MDDR                ,0x400e1254   
.equ    PIOC_MDSR                ,0x400e1258   
.equ    PIOC_PUDR                ,0x400e1260 
.equ    PIOC_PUER                ,0x400e1264   
.equ    PIOC_PUSR                ,0x400e1268 
.equ    PIOC_ABSR                ,0x400e1270   
.equ    PIOC_SCIFSR              ,0x400e1280  
.equ    PIOC_DIFSR               ,0x400e1284   
.equ    PIOC_IFDGSR              ,0x400e1288   
.equ    PIOC_SCDR                ,0x400e128C   
.equ    PIOC_OWER                ,0x400e12A0   
.equ    PIOC_OWDR                ,0x400e12A4   
.equ    PIOC_OWSR                ,0x400e12A8   
.equ    PIOC_AIMER               ,0x400e12B0   
.equ    PIOC_AIMDR               ,0x400e12B4   
.equ    PIOC_AIMMR               ,0x400e12B8   
.equ    PIOC_ESR                 ,0x400e12C0   
.equ    PIOC_LSR                 ,0x400e12C4   
.equ    PIOC_ELSR                ,0x400e12C8   
.equ    PIOC_FELLSR              ,0x400e12D0   
.equ    PIOC_REHLSR              ,0x400e12D4   
.equ    PIOC_FRLHSR              ,0x400e12D8   
.equ    PIOC_LOCKSR              ,0x400e12E0   
.equ    PIOC_WPMR                ,0x400e12E4   
.equ    PIOC_WPSR                ,0x400e12E8 


//      PIOD

.equ    PIOD_PER                 ,0x400e1400 
.equ    PIOD_PDR                 ,0x400e1404 
.equ    PIOD_PSR                 ,0x400e1408 
.equ    PIOD_OER                 ,0x400e1410 
.equ    PIOD_ODR                 ,0x400e1414 
.equ    PIOD_OSR                 ,0x400e1418 
.equ    PIOD_IFER                ,0x400e1420   
.equ    PIOD_IFDR                ,0x400e1424   
.equ    PIOD_IFSR                ,0x400e1428   
.equ    PIOD_SODR                ,0x400e1430   
.equ    PIOD_CODR                ,0x400e1434  
.equ    PIOD_ODSR                ,0x400e1438 
.equ    PIOD_PDSR                ,0x400e143C   
.equ    PIOD_IER                 ,0x400e1440   
.equ    PIOD_IDR                 ,0x400e1444   
.equ    PIOD_IMR                 ,0x400e1448   
.equ    PIOD_ISR                 ,0x400e144C   
.equ    PIOD_MDER                ,0x400e1450   
.equ    PIOD_MDDR                ,0x400e1454   
.equ    PIOD_MDSR                ,0x400e1458   
.equ    PIOD_PUDR                ,0x400e1460 
.equ    PIOD_PUER                ,0x400e1464   
.equ    PIOD_PUSR                ,0x400e1468 
.equ    PIOD_ABCDSR1             ,0x400e1470
.equ    PIOD_ABCDSR2             ,0x400e1474
.equ    PIOD_SCIFSR              ,0x400e1480  
.equ    PIOD_DIFSR               ,0x400e1484   
.equ    PIOD_IFDGSR              ,0x400e1488   
.equ    PIOD_SCDR                ,0x400e148C   
.equ    PIOD_OWER                ,0x400e14A0   
.equ    PIOD_OWDR                ,0x400e14A4   
.equ    PIOD_OWSR                ,0x400e14A8   
.equ    PIOD_AIMER               ,0x400e14B0   
.equ    PIOD_AIMDR               ,0x400e14B4   
.equ    PIOD_AIMMR               ,0x400e14B8   
.equ    PIOD_ESR                 ,0x400e14C0   
.equ    PIOD_LSR                 ,0x400e14C4   
.equ    PIOD_ELSR                ,0x400e14C8   
.equ    PIOD_FELLSR              ,0x400e14D0   
.equ    PIOD_REHLSR              ,0x400e14D4   
.equ    PIOD_FRLHSR              ,0x400e14D8   
.equ    PIOD_LOCKSR              ,0x400e14E0   
.equ    PIOD_WPMR                ,0x400e14E4   
.equ    PIOD_WPSR                ,0x400e14E8 

//      PIOE

.equ    PIOE_PER                 ,0x400e1600 
.equ    PIOE_PDR                 ,0x400e1604 
.equ    PIOE_PSR                 ,0x400e1608 
.equ    PIOE_OER                 ,0x400e1610 
.equ    PIOE_ODR                 ,0x400e1614 
.equ    PIOE_OSR                 ,0x400e1618 
.equ    PIOE_IFER                ,0x400e1620   
.equ    PIOE_IFDR                ,0x400e1624   
.equ    PIOE_IFSR                ,0x400e1628   
.equ    PIOE_SODR                ,0x400e1630   
.equ    PIOE_CODR                ,0x400e1634  
.equ    PIOE_ODSR                ,0x400e1638 
.equ    PIOE_PDSR                ,0x400e163C   
.equ    PIOE_IER                 ,0x400e1640   
.equ    PIOE_IDR                 ,0x400e1644   
.equ    PIOE_IMR                 ,0x400e1648   
.equ    PIOE_ISR                 ,0x400e164C   
.equ    PIOE_MDER                ,0x400e1650   
.equ    PIOE_MDDR                ,0x400e1654   
.equ    PIOE_MDSR                ,0x400e1658   
.equ    PIOE_PUDR                ,0x400e1660 
.equ    PIOE_PUER                ,0x400e1664   
.equ    PIOE_PUSR                ,0x400e1668 
.equ    PIOE_ABSR                ,0x400e1670   
.equ    PIOE_SCIFSR              ,0x400e1680  
.equ    PIOE_DIFSR               ,0x400e1684   
.equ    PIOE_IFDGSR              ,0x400e1688   
.equ    PIOE_SCDR                ,0x400e168C   
.equ    PIOE_OWER                ,0x400e16A0   
.equ    PIOE_OWDR                ,0x400e16A4   
.equ    PIOE_OWSR                ,0x400e16A8   
.equ    PIOE_AIMER               ,0x400e16B0   
.equ    PIOE_AIMDR               ,0x400e16B4   
.equ    PIOE_AIMMR               ,0x400e16B8   
.equ    PIOE_ESR                 ,0x400e16C0   
.equ    PIOE_LSR                 ,0x400e16C4   
.equ    PIOE_ELSR                ,0x400e16C8   
.equ    PIOE_FELLSR              ,0x400e16D0   
.equ    PIOE_REHLSR              ,0x400e16D4   
.equ    PIOE_FRLHSR              ,0x400e16D8   
.equ    PIOE_LOCKSR              ,0x400e16E0   
.equ    PIOE_WPMR                ,0x400e16E4   
.equ    PIOE_WPSR                ,0x400e16E8 


//      ENHANCED EMBEDDED FLASH CONTROLLER


.equ    EEFC_FMR                ,0x400e0c00
.equ    EEFC_FCR                ,0x400e0c04
.equ    EEFC_FSR                ,0x400e0c08
.equ    EEFC_FRR                ,0x400e0c0c



//      USART0

.equ    USART0_CR                 ,0x40024000
.equ    USART0_MR                 ,0x40024004
.equ    USART0_IER                ,0x40024008 
.equ    USART0_IDR                ,0x4002400C 
.equ    USART0_IMR                ,0x40024010 
.equ    USART0_CSR                ,0x40024014 
.equ    USART0_RHR                ,0x40024018 
.equ    USART0_THR                ,0x4002401C 
.equ    USART0_BRGR               ,0x40024020 



//      USART1

.equ    USART1_CR                 ,0x40028000
.equ    USART1_MR                 ,0x40028004
.equ    USART1_IER                ,0x40028008 
.equ    USART1_IDR                ,0x4002800C 
.equ    USART1_IMR                ,0x40028010 
.equ    USART1_CSR                ,0x40028014 
.equ    USART1_RHR                ,0x40028018 
.equ    USART1_THR                ,0x4002801C 
.equ    USART1_BRGR               ,0x40028020 






//	WATCHDOG TIMER

.equ	WDT_MR			,0x400e1854



//	TIMER COUNTER0 [0]

.equ	TC0_CCR0		,0x4000c000
.equ	TC0_CMR0		,0x4000c004
.equ	TC0_CV0			,0x4000c010
.equ	TC0_SR0			,0x4000c020


//      TWI2

.equ    TWI2_CR                 ,0x40060000
.equ    TWI2_MMR                ,0x40060004
.equ    TWI2_SMR                ,0x40060008
.equ    TWI2_IADR               ,0x4006000C
.equ    TWI2_CWGR               ,0x40060010
.equ    TWI2_SR                 ,0x40060020
.equ    TWI2_RHR                ,0x40060030
.equ    TWI2_THR                ,0x40060034




//      SPI0

.equ    SPI_CR                  ,0x40008000
.equ    SPI_MR                  ,0x40008004
.equ    SPI_RDR                 ,0x40008008
.equ    SPI_TDR                 ,0x4000800C
.equ    SPI_SR                  ,0x40008010
.equ    SPI_IER                 ,0x40008014
.equ    SPI_IDR                 ,0x40008018
.equ    SPI_IMR                 ,0x4000801C
.equ    SPI_CSR0                ,0x40008030
.equ    SPI_CSR1                ,0x40008034
.equ    SPI_CSR2                ,0x40008038
.equ    SPI_CSR3                ,0x4000803C


//      CHIPID

.equ    CHIPID_CIDR             ,0x400e0940
.equ    CHIPID_EXID             ,0x400e0944


//      PWM0C0

.equ    PWM0C0_CLK              ,0x40020000
.equ    PWM0C0_ENA              ,0x40020004
.equ    PWM0C0_CDTY0            ,0x40020204
.equ    PWM0C0_CPRD0            ,0x4002020c

//      TRNG

.equ    TRNG_CR                 ,0x40070000
.equ    TRNG_ISR                ,0x4007001c
.equ    TRNG_ODATA              ,0x40070050

//	CACHE

.equ	CCSIDR			,0xE000ED80          // Cache size ID register address
.equ	CSSELR			,0xE000ED84          // Cache size selection register address
.equ	DCISW			,0xE000EF60          // Cache maintenance op address: data cache clean and invalidate by set/way
.equ	ICIALLU			,0xE000EF50
.equ	CCR			,0xE000ED14


//      AFEC0

.equ    AFEC0_CR                 ,0x4003c000
.equ    AFEC0_MR                 ,0x4003c004
.equ    AFEC0_EMR                ,0x4003c008
.equ    AFEC0_SEQ1R              ,0x4003c00c
.equ    AFEC0_SEQ2R              ,0x4003c010
.equ    AFEC0_CHER               ,0x4003c014
.equ    AFEC0_CHDR               ,0x4003c018
.equ    AFEC0_CHSR               ,0x4003c01c
.equ    AFEC0_LCDR               ,0x4003c020
.equ    AFEC0_IER                ,0x4003c024
.equ    AFEC0_IDR                ,0x4003c028
.equ    AFEC0_IMR                ,0x4003c02c
.equ    AFEC0_ISR                ,0x4003c030
.equ    AFEC0_OVER               ,0x4003c04c
.equ    AFEC0_CWR                ,0x4003c050
.equ    AFEC0_CGR                ,0x4003c054
.equ    AFEC0_DIFFR              ,0x4003c060
.equ    AFEC0_CSELR              ,0x4003c064
.equ    AFEC0_CDR                ,0x4003c068
.equ    AFEC0_COCR               ,0x4003c06c
.equ    AFEC0_TEMPMR             ,0x4003c070
.equ    AFEC0_TEMPCWR            ,0x4003c074
.equ    AFEC0_ACR                ,0x4003c094
.equ    AFEC0_SHMR               ,0x4003c0a0
.equ    AFEC0_COSR               ,0x4003c0d0
.equ    AFEC0_CVR                ,0x4003c0d4
.equ    AFEC0_CECR               ,0x4003c0d8
.equ    AFEC0_WPMR               ,0x4003c0e4
.equ    AFEC0_WPSR               ,0x4003c0e8



@ -----------------------------------------------------------------------------
uart_init: @ ( -- )
@ -----------------------------------------------------------------------------

// 		This is infact a complete cpu and usart1 setup

reset_handler:	//disable watchdog
		ldr	r0,=WDT_MR
		ldr	r1,=0x3fffafff
		str	r1,[r0]
		//get GPNVM bits to see if booting from flash is enabled
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a00010d
		str	r1,[r0]
		ldr	r0,=EEFC_FSR
waitgpnvm:	ldr	r1,[r0]
		tst	r1,#1
		beq	waitgpnvm
		ldr	r1,=EEFC_FRR
		ldr	r0,[r1]
		and	r0,r0,#0x00000002
		bne	pioclkson	//flash booting is enabled
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//set bit 1 of the GPNVM bits , to boot from flash !!!
		//otherwise an erase through the erase pin resets this bit
		//so that after every reset the ROM boot program is started
		//it looks then like the controller is dead , but its executing the 
		//samba monitor instead
		//this took me a long time to find !!!!!!!
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		ldr	r0,=EEFC_FCR
		ldr	r1,=0x5a00010b
		str	r1,[r0]
		ldr	r0,=EEFC_FSR
waitgpnvm2:	ldr	r1,[r0]
		tst	r1,#1
		beq	waitgpnvm2
		//turn on clk pioa..pioe
pioclkson:      ldr     r0,=PMC_PCER0
                mov     r1,#0x00031c00
                str     r1,[r0]
                //enable xtal osc
                ldr     r0,=CKGR_MOR
                ldr     r1,=0x0037ff09
                str     r1,[r0]
                //wait for xtal ready
                ldr     r0,=PMC_SR
waitxtal:       ldr     r1,[r0]
                tst     r1,#1
                beq     waitxtal
                //switch to xtal osc
                ldr     r0,=CKGR_MOR
                ldr     r1,=0x0137ff09
                str     r1,[r0]
               //wait for mckrdy
                ldr     r0,=PMC_SR
waitmckrdy4:    ldr     r1,[r0]
                tst     r1,#8
                beq     waitmckrdy4
                //set master clock to main clock
		ldr     r0,=PMC_MCKR
                ldr     r1,=0x00000001
                str     r1,[r0]
                //wait for mckrdy
                ldr     r0,=PMC_SR
waitmckrdy2:    ldr     r1,[r0]
                tst     r1,#8
                beq     waitmckrdy2
                //disable the RC oscillator
                ldr     r0,=CKGR_MOR
                ldr     r1,=0x0137ff01
                str     r1,[r0]

                //set 12 waitstates for flash , needed when switching to pll frequency of 300MHz
                ldr     r0,=EEFC_FMR
                ldr     r1,=0x04000c00
                str     r1,[r0]
                ldr     r0,=EEFC_FMR
                str     r1,[r0]
                
                //init the pll
                //set pll to 300 Mhz (*25/1)
                //set mck to 150 Mhz
                ldr     r0,=CKGR_PLLAR
                ldr     r1,=0x20183f01
                str     r1,[r0]
                //wait for lock
                ldr     r0,=PMC_SR
waitplla:       ldr     r1,[r0]
                tst     r1,#2
                beq     waitplla
                //select plla is master clock
                ldr     r0,=PMC_MCKR
                ldr     r1,=0x00000002
                str     r1,[r0]
                //wait for mckrdy
                ldr     r0,=PMC_SR
waitmckrdy3:    ldr     r1,[r0]
                tst     r1,#8
                beq     waitmckrdy3
                //set mck as cpuclk/2
                //select plla as master clock
                ldr     r0,=PMC_MCKR
                ldr     r1,=0x00000102
                str     r1,[r0]
                //wait for mckrdy
                ldr     r0,=PMC_SR
waitmckrdy5:    ldr     r1,[r0]
                tst     r1,#8
                beq     waitmckrdy5
           
                //program pck1 on pa17 to output a clock
                //disable pa17 from pio
                ldr     r0,=PIOA_PDR
                mov     r1,#0x00020000
                str     r1,[r0]
                //set pa17 as AF B
                ldr     r0,=PIOA_ABCDSR1
                ldr     r1,[r0]
                orr     r1,r1,#0x00020000
                str     r1,[r0]
                //set clock on pck1 -> mck/100 = 150/100 = 1.5MHz
                ldr     r0,=PMC_PCK1
                ldr     r1,=0x634
                str     r1,[r0]
                ldr     r0,=PMC_SCER
                mov     r1,#0x00000200
                str     r1,[r0]

                //init usart0 (pb0,pb1) and set for 115200,n,8,1
                //pb0,pb1 = AF C
                //pb0 = rxd0 , pb1 = txd0
                //disable pb0,1 from pio
                ldr     r0,=PIOB_PDR
                mov     r1,#0x00000003
                str     r1,[r0]
                //set pb0,1 as AF C
                ldr     r0,=PIOB_ABCDSR2
                ldr     r1,[r0]
                orr     r1,r1,#0x00000003
                str     r1,[r0]
                //enable clock usart0 & select master clock as source
                ldr	r0,=PMC_PCER0
		ldr	r1,=0x00002000
		str	r1,[r0]
		//ldr     r0,=PMC_PCR -> this also works
                //ldr     r1,=0x1000140e
                //str     r1,[r0]
                //init usart0
		ldr	r0,=USART0_MR
		mov	r1,#0x000008c0
		str	r1,[r0]
		ldr	r0,=USART0_BRGR
		mov	r1,#81          //--> effective baud = 115740 but that's ok 
		str	r1,[r0]
		ldr	r0,=USART0_CR
		mov	r1,#0x00000050
		str	r1,[r0]

/*
		FOR UNKNOWN REASONS THIS DOESN'T WORK		
		//init usart1 connected to the CDC channel
		//pb4 = CDC_USART1_TXD
		//pa21= CDC_USART1_RXD
		//disable pb4 from pio
                ldr     r0,=PIOB_PDR
                mov     r1,#0x00000010
                str     r1,[r0]
		//disable pa21 from pio
		ldr     r0,=PIOA_PDR
                mov     r1,#0x00200000
                str     r1,[r0]
		//set pb4 as AF D
                ldr     r0,=PIOB_ABCDSR2
                ldr     r1,[r0]
                orr     r1,r1,#0x00000010
                str     r1,[r0]
		ldr     r0,=PIOB_ABCDSR1
                ldr     r1,[r0]
                orr     r1,r1,#0x00000010
                str     r1,[r0]
		//set pa21 as AF A
		//should be so by default after reset
		
                //enable clock usart1 & select master clock as source
                ldr	r0,=PMC_PCER0
		ldr	r1,=0x00004000
		str	r1,[r0]
		//ldr     r0,=PMC_PCR	@ -> this also works
                //ldr     r1,=0x1000140e
                //str     r1,[r0]
		//init usart1
		ldr	r0,=USART1_MR
		mov	r1,#0x000008c0
		str	r1,[r0]
		ldr	r0,=USART1_BRGR
		mov	r1,#81          //--> effective baud = 115740 but that's ok 
		str	r1,[r0]
		ldr	r0,=USART1_CR
		mov	r1,#0x00000050
		str	r1,[r0]

test:		ldr	r0,=USART1_THR
		mov	r1,#0x2a
		str	r1,[r0]
		b	test
		
*/
		//set pc8 as output for the led and switch it on
		ldr	r0,=PIOC_PER
		mov	r1,#0x00000100
		str	r1,[r0]
		ldr	r0,=PIOC_OER
		str	r1,[r0]
		mov	r1,#0x00000100
		ldr	r0,=PIOC_CODR		//turn led on
		str	r1,[r0]



	bx	lr  	

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !

@ Following code is the same as for STM32F051
.include "../common/terminalhooks.s"

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit"
serial_emit: @ ( c -- ) Emit one character
@ -----------------------------------------------------------------------------
   push {lr}

1: bl serial_qemit
   cmp tos, #0
   drop
   beq 1b

   ldr r2, =USART0_THR
   strb tos, [r2]         @ Output the character
   drop

   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key"
serial_key: @ ( -- c ) Receive one character
@ -----------------------------------------------------------------------------
   push {lr}

		

1: bl serial_qkey
   cmp tos, #0
   drop
   beq 1b

   pushdatos
   ldr r2, =USART0_RHR
   ldrb tos, [r2]         @ Fetch the character
   pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-emit?"
serial_qemit:  @ ( -- ? ) Ready to send a character ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0    @ False Flag
   ldr r0, =USART0_CSR
   ldr r1, [r0]     @ Fetch status
   tst	r1,#2
   beq 1f
   mvns tos, tos    @ True Flag
1: pop {pc}

@ -----------------------------------------------------------------------------
  Wortbirne Flag_visible, "serial-key?"
serial_qkey:  @ ( -- ? ) Is there a key press ?
@ -----------------------------------------------------------------------------
   push {lr}
   bl pause

   pushdaconst 0  @ False Flag
   ldr r0, =USART0_CSR
   ldr r1, [r0]     @ Fetch status
   tst  r1,#1
   beq 1f
   mvns tos, tos @ True Flag
1: pop {pc}

  .ltorg @ Hier werden viele spezielle Hardwarestellenkonstanten gebraucht, schreibe sie gleich !
