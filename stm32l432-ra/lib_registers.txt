\
\ 	register definitions for STM32L432 
\
\		Ralph Sahli, 2016
\		

48000000 variable hclk	\ system clock: initial 48 MHz from HSI RC

: registers ( -- )
	0 ;				\ offset start

: reg 
    <builds 		( offset -- newoffset )
		dup , cell+	
    does>			( structure-base -- structure-member-address )  
		@ + ;

: regC
    <builds 		( offset -- newoffset )
		dup , cell+	
    does>			( structure-base channel -- structure-member-address )  
		@ swap 1- 20 * + + ;

: end-registers ( -- )
	drop ;			\ last offset

\ bit masks
: bit ( n -- n )
	1 swap lshift 1-foldable ;

$E000E100 constant NVIC

$40010400 constant EXTI
	registers
		reg _eIMR
		reg _eEMR
		reg _eRTSR
		reg _eFTSR
		reg _eSWIER
		reg _ePR
	end-registers

$40010000 constant SYSCFG
	registers
	end-registers


$40007000 constant PWR
	registers
		reg _wCR
		reg _wCSR
	end-registers
	
$40002800 constant RTC
	registers
		reg _cTR
		reg _cDR
		reg _cCR
		reg _cISR
		reg _cPRER
		reg _cWUTR
		drop $1C
		reg _cALRMAR
		reg _cALRMBR
		reg _cWPR
	end-registers
	
$40021000 constant RCC
	registers
		reg _rCR			\ Clock control register
		drop $08
		reg _rCFGR			\ Clock configuration register
		reg _rPLLCFGR		\PLL configuration register
		reg _rPLLSAI1CFGR	\ PLLSAI1 configuration register
		drop $48
		reg _rAHB1ENR		\ AHB1 peripheral clock enable register
		reg _rAHB2ENR		\ AHB3 peripheral clock enable register
		drop $58
		reg _rAPB1ENR1		\ APB11 peripheral clock enable register
		reg _rAPB1ENR2		\ APB12 peripheral clock enable register
		reg _rAPB2ENR		\ APB2 peripheral clock enable register
		drop $90
		reg _rBDCR			\ RCC Backup domain control register
		reg _rCSR			\ Control/status register
	end-registers

$40020000 constant DMA1
$40020400 constant DMA2
	registers
		reg _dISR		\ interrupt status register
		reg _dIFCR		\ interrupt flag clear register
		regC _dCCRx		\ channel x configuration register
		regC _dCNDTRx	\ channel x number of data register
		regC _dCPARx	\ channel x peripheral address register
		regC _dCMARx	\ channel x memory address register
	end-registers
	
$48000400 constant PORTB
$48000000 constant PORTA
	registers
		reg _pMODER   	\ Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
		reg _pOTYPER  	\ Port Output type register - (0) Push/Pull vs. (1) Open Drain
		reg _pOSPEEDR 	\ Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
		reg _pPUPDR		\ Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
		reg _pIDR		\ Input Data Register
		reg _pODR     	\ Output Data Register
		reg _pBSRR		\ port bit set/reset register
		reg _pLCKR		\ port configuration lock register		
		reg _pAFRL		\ Alternate function  low register
		reg _pAFRH		\ Alternate function high register
	end-registers

$40013000 constant SPI1
	registers
		reg _sCR1		\ SPI control register 1
		reg _sCR2		\ SPI control register 2
		reg _sSR		\ SPI status register
		reg _sDR		\ SPI data register
	end-registers

$40005400 constant I2C1
	registers
		reg _iCR1		\ control register 1
		reg _iCR2		\ control register 2
		reg _iOAR1		\ Own address 1 register
		reg _iOAR2		\ Own address 2 register
		reg _iTIMINGR	\ Timing register
		reg _iTIMEOUTR	\ Timeout register
		reg _iISR		\ Interrupt and status register
		reg _iICR		\ Interrupt clear register
		reg _iPECR		\ PEC register
		reg _iRXDR		\ Receive data register
		reg _iTXDR		\ Transmit data register
	end-registers

	
$40013800 constant USART1	
$40004400 constant USART2
	registers
		reg _uCR1		\ Control register 1
		reg _uCR2		\ Control register 2
		reg _uCR3		\ Control register 3
		reg _uBRR		\ Baud rate register
		reg _uGTPR		\ Guard time and prescaler register
		reg _uRTOR		\ Receiver timeout register
		reg _uRQR		\ Request register
		reg _uISR		\ Interrupt and status register
		reg _uICR		\ Interrupt flag clear register
		reg _uRDR		\ Receive data register
		reg _uTDR		\ Transmit data register
	end-registers

$40012C00 constant TIM1
$40000000 constant TIM2
$40000400 constant TIM3
$40001000 constant TIM6
$40001400 constant TIM7
$40014000 constant TIM15
$40014400 constant TIM16

	registers
		reg _tCR1		\ TIMx control register 1
		reg _tCR2		\ TIMx control register 2
		reg _tSMCR		\ TIMx slave mode control register
		reg _tDIER		\ TIMx DMA/Interrupt enable register
		reg _tSR		\ TIMx status register
		reg _tEGR		\ TIMx event generation register
		reg _tCCMR1		\ TIMx capture/compare mode register 1
		reg _tCCMR2		\ TIMx capture/compare mode register 2
		reg _tCCER		\ TIMx capture/compare enable register
		reg _tCNT		\ TIMx counter
		reg _tPSC		\ TIMx prescaler
		reg _tARR		\ TIMx auto-reload register
		reg _tRCR		\ TIM16/TIM17 repetition counter register
		reg _tCCR1		\ TIMx capture/compare register 1
		reg _tCCR2		\ TIMx capture/compare register 2
		reg _tCCR3		\ TIMx capture/compare register 3
		reg _tCCR4		\ TIMx capture/compare register 4
		reg _tBDTR		\ TIM16/TIM17 break and dead-time register
		reg _tDCR		\ TIMx DMA control register
		reg _tDMAR		\ TIMx DMA address for full transfer
	end-registers

\ Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
%00 constant MODE_Input  
%01 constant MODE_Output  
%10 constant MODE_Alternate  
%11 constant MODE_Analog
: set-moder ( mode pin# baseAddr -- )
	>R 2* %11 over lshift r@ _pMODER bic! 	\ clear ..
	lshift R> _pMODER bis!					\ .. set
;

\ Port Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
%00 constant SPEED_LOW 
%01 constant SPEED_MEDIUM
%10 constant SPEED_HIGH
%11 constant SPEED_VERYHIGH
: set-opspeed ( speed pin# baseAddr -- )
	>R 2* %11 over lshift r@ _pOSPEEDR bic!	\ clear ..
	lshift R> _pOSPEEDR bis!				\ .. set
;

\ Port alternate function
: set-alternate ( af# pin# baseAddr -- )
	>R dup 8 < if 
		4 * lshift R> _pAFRL
	else 
		8 - 4 * lshift R> _pAFRH 
	then
	bis!
;

\ Enable IRQn 0..80
: NVIC_EnableIRQ ( n -- )
	32 /mod NVIC + bis! ;

\ Disable IRQn 0..80
: NVIC_DisableIRQ ( n -- )
	32 /mod $80 + NVIC + bis! ;

\ Set priority for IRQn 0..80, priority 0..255	
: NVIC_SetPriority ( prio n -- )
	4 /mod cells $300 + NVIC + 	\ register offset
	-rot 8 * lshift				\ byte offset, register value
	swap bis! ;
	
\ set external interrupt configuration, port 0..7 (A..H), pin 0..15  
: SYSCFG_SetEXTI ( port pin -- )
	0 bit RCC _rAPB2ENR bis!	\ enable syscfg clock
	4 /mod cells SYSCFG + 8 +	\ register offset
	-rot 4 * lshift				\ 4-bit offset, register value
	swap bis! ;

\ calculate rounded baudrate 
: baud ( n -- reg-val )
	hclk @ over /mod -rot
	swap 2/ >= if 1+ then				\ round
;	


	