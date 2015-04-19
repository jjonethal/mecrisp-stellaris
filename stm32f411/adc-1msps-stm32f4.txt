
\ Analog-Digital-Converter samples with crystal stabilized 1Msps into circular buffer

compiletoram \ For RAM only. Interrupt handler is too slow for 1Msps in Flash with waitstates.



$40023800 constant RCC_Base
 
$40023C00 constant Flash_ACR \ Flash Access Control Register
$40004408 constant USART2_BRR

\ f (VCO clock) = f (PLL clock input) * (PLLN/PLLM)
\ f (PLL general clock output) = F (VCO clock) / PLLP
\ f (USB, RNG und andere) = f (VCO clock) / PLLQ

RCC_Base $00 + constant RCC_CR
  1 24 lshift constant PLLON
  1 25 lshift constant PLLRDY

RCC_Base $04 + constant RCC_PLLCRGR
   1 22 lshift constant PLLSRC

RCC_Base $08 + constant RCC_CFGR


: 120MHz ( -- )

  \ Set Flash waitstates !
  $103 Flash_ACR !   \ 3 Waitstates for 120 MHz with more than 2.7 V Vcc, Prefetch buffer enabled.

  PLLSRC          \ HSE clock as 8 MHz source

  8  0 lshift or  \ PLLM Division factor for main PLL and audio PLL input clock 
                  \ 8 MHz / 8 =  1 MHz. Divider before VCO. Frequency entering VCO to be between 1 and 2 MHz.

240  6 lshift or  \ PLLN Main PLL multiplication factor for VCO - between 192 and 432 MHz
                  \ 1 MHz * 240 = 240 MHz

  8 24 lshift or  \ PLLQ = 8, 240 MHz / 8 = 30 MHz

  0 16 lshift or  \ PLLP Division factor for main system clock
                  \ 0: /2  1: /4  2: /6  3: /8
                  \ 240 MHz / 2 = 120 MHz 
  RCC_PLLCRGR !

  PLLON RCC_CR bis!
    \ Wait for PLL to lock:
    begin PLLRDY RCC_CR bit@ until

  2                 \ Set PLL as clock source
  %101 10 lshift or \ APB  Low speed prescaler (APB1) - Max 42 MHz ! Here 120/4 MHz = 30 MHz.
  %101 13 lshift or \ APB High speed prescaler (APB2) - Max 84 MHz ! Here 120/4 MHz = 30 MHz.
  RCC_CFGR !

  $104 USART2_BRR ! \ Set Baud rate divider for 115200 Baud at 30 MHz.
;







$40023800 constant RCC_Base
RCC_Base $44 + constant RCC_APB2ENR

\ Bits for RCC_APB2ENR:
1  8 lshift constant ADC1EN
1  9 lshift constant ADC2EN
1 10 lshift constant ADC3EN


$40012000 constant ADC1_Base

ADC1_Base $00 + constant ADC1_SR
ADC1_Base $04 + constant ADC1_CR1
ADC1_Base $08 + constant ADC1_CR2
ADC1_Base $0C + constant ADC1_SMPR1
ADC1_Base $10 + constant ADC1_SMPR2
ADC1_Base $14 + constant ADC1_JOFR1
ADC1_Base $18 + constant ADC1_JOFR2
ADC1_Base $1C + constant ADC1_JOFR3
ADC1_Base $20 + constant ADC1_JOFR4
ADC1_Base $24 + constant ADC1_HTR
ADC1_Base $28 + constant ADC1_LTR
ADC1_Base $2C + constant ADC1_SQR1
ADC1_Base $30 + constant ADC1_SQR2
ADC1_Base $34 + constant ADC1_SQR3
ADC1_Base $38 + constant ADC1_JSQR
ADC1_Base $3C + constant ADC1_JDR1
ADC1_Base $40 + constant ADC1_JDR2
ADC1_Base $44 + constant ADC1_JDR3
ADC1_Base $48 + constant ADC1_JDR4
ADC1_Base $4C + constant ADC1_DR

\ Bits for ADC_SR:
  2 constant EOC
$10 constant OVR

\ Bits for ADC_CR2:
1           constant ADON
2           constant CONT
1 30 lshift constant SWSTART

ADC1_Base $300 + constant ADC_CSR
ADC1_Base $304 + constant ADC_CCR
  1 23 lshift constant TSVREFE  \ Temperature sensor and Vrefint enable
  1 22 lshift constant VBATE    \ Vbat enable



$E000E100 constant NVIC_EN0_R              \ IRQ 0 to 31 Set Enable Register
$00040000 constant NVIC_EN0_INT18          \ ADC Interrupt 18


$40020800 constant PORTC_Base
PORTC_BASE $00 + constant PORTC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
\ PC0 is AIN10
\ PC1 is AIN11


      0 variable buffer     \ Location of circular buffer
\   $1FF constant buffermask \ For  512 Samples
 $1FFF constant buffermask \ For 8192 Samples

: allot-buffer ( -- )
  compiletoram \ Buffer should always placed in RAM
  here         \ This place !
  buffermask 2* 1+ allot    \ Reserve space for the desired number of 16-Bit-Samples
  buffer !     \ If allot succeed, save the place
;

: release-buffer ( -- )
  \ Hopefully nothing has been compiled in between...
  0 buffer !   \ Clear Pointer
  buffermask 2* 1+ negate allot \ Release space
;

0 variable sample# \ Current offset into circular buffer

: process-sample ( Sample Nummer )  shl buffer @ + h! inline ; \ Sample# * 2 is Offset into Buffer.

: adc-handler ( -- ) \ For 1 Msps with 1 Sample/Interrupt

   sample# @           \ Current sample number
   ADC1_DR @           \ Current sample
   over process-sample \ Store sample
   1+ buffermask and   \ Increment sample number, handle circular buffer wrap over
   sample# !           \ Store number for next upcoming sample
;

: init-analog ( -- )  ADC1EN RCC_APB2ENR bis! ; \ Enable clock for ADC1

: analog-continuous-with-irq ( -- ) \ Set up ADC to sample AIN0 continuously with Interrupts every 8th sample

  init-analog \ Enable clock for ADC1
  %11 1 2* lshift portc_moder bis! \ Switch PC1 to analog mode

  ['] adc-handler irq-adc !  \ Hook for handler
  NVIC_EN0_INT18 NVIC_EN0_R ! \ Enable ADC Interrupt in global Interrupt Controller

  ADON ADC1_CR2 ! \ Enable ADC
   $20 ADC1_CR1 ! \ Enable EOCIE

  1 20 lshift ADC1_SQR1 ! \ One conversion for this sequence
  11 ADC1_SQR3 !           \ Select channel 11, PC1

  SWSTART CONT or ADC1_CR2 bis! \ Start continuous conversion
;


: capture ( -- ) \ Sets ADC to sample continuously into circular buffer,  
                 \ then stop on key press and print measurement results

  120MHz

   allot-buffer  \ Get memory for circular buffer
 \ $10000000 buffer ! \ Set buffer into 64k core coupled memory region

  0 sample# !   \ First sample is number zero
  analog-continuous-with-irq \ Record !

  \ You can include your favourite trigger here - 
  \ * do math on previous samples 
  \     (note that the most recent sample is always sample# @ 1- )
  \ * wait for a digital pin to toggle
  \ * get samples from another ADC to trigger
  \ * simply wait for a key press, what is done in this example

  cr
  ." Sampling: Wait for trigger - press a key"
  begin key? until

  0 ADC1_CR2 !      \ Disable ADC
  10000 0 do loop   \ Wait until current sampling is finished and Interrupts calmed down

  \ Print contents of circular buffer starting with oldest sample
  cr
  buffermask 1+ 0 
  do  
    i u. space 
    buffer @ i sample# @ + buffermask and shl + h@ u. cr
  loop

  release-buffer \ Release space for buffer
;

