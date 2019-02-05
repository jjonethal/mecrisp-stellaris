\ =========================================================================
\  Program: rtc-temp-cal.fs
\ 
\  Test program to adjust the RTC LSC calibration based on the
\  temperature from the STM32F051 internal sensor.
\  
\  The source files rtc-init-set.fs, date-time.fs, and rtc-calib.fs should
\  be loaded before this file, as it uses definitions from them. 
\ 
\  Prior to running the main program init, the RTC should be set up using
\  rtc-init-lse and rtc-set-t&d.  Also, it would be best to run through
\  the static calibration procedure in calibration-method.txt that is
\  supported by the code in rtc-calib.fs.
\ 
\  Andrew Palm
\  2018.04.24
\ =========================================================================

compiletoflash
\ -------------------------------------------------------------------------
\  Core and peripheral registers
\  Unused registers are commented out
\ -------------------------------------------------------------------------
$E000E010 constant SysTick
  SysTick $00 + constant SysTick_CTRL
  SysTick $04 + constant SysTick_LOAD
  SysTick $08 + constant SysTick_VAL
  SysTick $0C + constant SysTick_CALIB

$E000ED00 constant SCB
  SCB $01C + constant SCB_SHPR2

$40021000 constant RCC
  \ RCC $00 + constant RCC_CR
  \ RCC $04 + constant RCC_CFGR
  \ RCC $08 + constant RCC_CIR
  \ RCC $0C + constant RCC_APB2RSTR
  \ RCC $10 + constant RCC_APB1RSTR
  \ RCC $14 + constant RCC_AHBENR
  RCC $18 + constant RCC_APB2ENR
  \ RCC $1C + constant RCC_APB1ENR
  \ RCC $20 + constant RCC_BDCR
  \ RCC $24 + constant RCC_CSR
  \ RCC $28 + constant RCC_AHBRSTR
  \ RCC $2C + constant RCC_CFGR2
  \ RCC $30 + constant RCC_CRGR3
  \ RCC $34 + constant RCC_CR2

$40012400 constant ADC
  ADC $00 + constant ADC_ISR
  ADC $04 + constant ADC_IER
  ADC $08 + constant ADC_CR
  ADC $0C + constant ADC_CFGR1
  ADC $10 + constant ADC_CFGR2
  ADC $14 + constant ADC_SMPR
  ADC $28 + constant ADC_CHSELR
  ADC $40 + constant ADC_DR
  ADC $308 + constant ADC_CCR


\ -------------------------------------------------------------------------
\ Pull in RTC and date-time words
\ -------------------------------------------------------------------------
\ #include rtc-init-set.fs
\ #include date-time.fs
\ #include rtc-calib.fs
compiletoflash

\ -------------------------------------------------------------------------
\  Set up SysTick for main loop 1 ms tick
\ -------------------------------------------------------------------------
1 constant MAIN_TICKS  \ Number of systicks for main loop repeat
MAIN_TICKS variable main-Tick-Cnt

3 constant SysTick_PRIORITY
-1 constant SysTick_IRQn

: systick-handler ( -- )
  main-Tick-Cnt @ if
    -1 main-Tick-Cnt +!
  then
;

: wait-for-tick ( -- )
  begin main-Tick-Cnt @ 0= until
  MAIN_TICKS main-Tick-Cnt !
;

: systick-init ( -- )
  %011 SysTick_CTRL bic!    \ Disable timer and interrupt
  8000 1 - SysTick_LOAD !  \ (SystemCoreClock/1000)-1 for 1 ms tick
  0 SysTick_VAL !
  %101 SysTick_CTRL bis!    \ Set CLKSOURCE, ENABLE bits

  \ Set SysTick interrupt priority
  SysTick_PRIORITY 6 lshift $FF and  \ Priority byte
  SysTick_IRQn %11 and 3 lshift      \ Bit shift
  lshift
  SysTick_IRQn %1111 and 8 - 2 rshift 2 lshift  \ Byte offset from SCB_SHPR2
  SCB_SHPR2 + bis!                    \ Write priority bits

  ['] systick-handler irq-systick !   \ Register systick-handler
  %010 SysTick_CTRL bis!    \ Enable system tick interrupt (bit TICKINT)
;

\ -------------------------------------------------------------------------
\  ADC driver words for conversion of internal temperature and VREFINT
\  using software trigger and discontinuous mode
\ -------------------------------------------------------------------------
: adc-enable ( -- )
  \ Enable ADC
  %1 ADC_ISR @ and if %1 ADC_ISR bis! then  \ Clear ADRDY
  %1 ADC_CR bis!   
  begin %1 ADC_ISR bit@ until      \ Wait until ADRDY set 
;

: adc-init-hw ( -- )
  \ Enable ADC peripheral clock
  %1 9 lshift RCC_APB2ENR bis!
  %1 ADC_CR bic!                    \ Disable ADC
  %10 30 lshift ADC_CFGR2 bis!      \ Use PCLK/4 for ADC clock
  \ Calibrate the ADC
  %1 31 lshift ADC_CR bis!          \ Set ADCAL
  begin %1 31 lshift ADC_CR bit@ not until  \ Wait for calibration to end
  \ Set up ADC
  adc-enable
  %1 5 lshift ADC_CFGR1 bic!        \ Align right
  %11 16 lshift ADC_CHSELR bis!     \ Channels 16 (temp) and 17 (vrefint)
  %1 2 lshift ADC_CFGR1 bic!        \ Scan channels in forward direction  
  %111 ADC_SMPR bis!                \ 239.5 ADC clock cycles
  %1 13 lshift ADC_CFGR1 bic!       \ Discontinuous mode
  %1 16 lshift ADC_CFGR1 bis!
  %11 10 lshift ADC_CFGR1 bic!      \ Convert when ADSTART set
  %1 2 lshift ADC_ISR bis!          \ Clear End of Conversion flag
  %1 3 lshift ADC_ISR bis!          \ Clear End of Sequence flag
  
  \ Enable VREFINT connection
  %1 22 lshift ADC_CCR bis!
  \ Enable temp sensor
  %1 23 lshift ADC_CCR bis!
;

: adc-start ( -- )  %1 2 lshift ADC_CR bis! ;
: adc-stop ( -- )  %1 4 lshift ADC_CR bis! ;
: adc-eoc? ( -- flag )  %1 2 lshift ADC_ISR bit@ ;  \ End of conversion?
: adc-eos? ( -- flag )  %1 3 lshift ADC_ISR bit@ ;  \ End of sequence?
: adc-get-data ( -- n )  ADC_DR @ ;
: adc-clear-eos ( -- ) %1 3 lshift ADC_ISR bic! ;

\ -------------------------------------------------------------------------
\  State machine to get internal sensor temperature in deg C
\ -------------------------------------------------------------------------
0 variable temp-Done-Flag
0 variable temp-Temp
0 variable temp-Vref
0 variable temp-Meas-Count
5 constant TEMP_NUM_MEAS
\ Calibration values for chip
$1FFFF7C2 h@ constant TEMP_110_CAL
$1FFFF7B8 h@ constant TEMP_30_CAL
$1FFFF7BA h@ constant VREFINT_CAL

\ State machine states
0 constant TEMP_IDLE
1 constant TEMP_START
2 constant TEMP_START_ADC
3 constant TEMP_GET_TEMP
4 constant TEMP_GET_VREF
5 constant TEMP_LOOP_TEST
6 constant TEMP_CALC_AVGS
7 constant TEMP_CALC_DEGC

\ State variable holds address of current state word
0 variable temp-State

\ State machine word
\ Takes TEMP_NUM_MEAS ADC readings of internal temp sensor and Vrefint,
\ averages them, then converts values into temp in centideg C and
\ VDD_APP in millivolts, corrected with internal calibration values.
\
: temp-exec-sm
  temp-State @ case
  
    TEMP_IDLE of
      nop
    endof

    TEMP_START of
      0 temp-Meas-Count !
      0 temp-Temp !
      0 temp-Vref !
      0 temp-Done-Flag !
      TEMP_START_ADC temp-State !
    endof

    TEMP_START_ADC of
      adc-start
      TEMP_GET_TEMP temp-State !
    endof

    TEMP_GET_TEMP of
      adc-eoc? if
        adc-get-data temp-Temp +!
        adc-start
        TEMP_GET_VREF temp-State !
      then
    endof

    TEMP_GET_VREF of
      adc-eoc? if
        adc-get-data temp-Vref +!
        adc-clear-eos
        TEMP_LOOP_TEST temp-State !
      then
    endof

    TEMP_LOOP_TEST of
      1 temp-Meas-Count +!
      temp-Meas-Count @ TEMP_NUM_MEAS < if
        TEMP_START_ADC temp-State ! 
      else
        TEMP_CALC_AVGS temp-State !
      then 
    endof

    TEMP_CALC_AVGS of
      \ Take averages, with rounding
      temp-Temp @ TEMP_NUM_MEAS u/mod 
      swap 1 lshift TEMP_NUM_MEAS < not if 1+ then
      temp-Temp !
      temp-Vref @ TEMP_NUM_MEAS u/mod
      swap 1 lshift TEMP_NUM_MEAS < not if 1+ then
      temp-Vref !
      TEMP_CALC_DEGC temp-State !
    endof

    TEMP_CALC_DEGC of
      \ Calculate temperature in centideg C
      temp-Temp @ VREFINT_CAL temp-Vref @ u*/ TEMP_30_CAL -
      11000 3000 - *
      TEMP_110_CAL TEMP_30_CAL - / 3000 +
      temp-Temp !
      \ Calculate VDD_APP in millivolts
      3300 VREFINT_CAL temp-Vref @ u*/
      temp-Vref !
      -1 temp-Done-Flag !
      TEMP_IDLE temp-State !
    endof

  endcase
;

\ -------------------------------------------------------------------------
\ Words for client task to initialize, start, and print results of
\ temperature state machine  

\ Initialize state machine by putting in idle state
: temp-init-sm ( -- )  TEMP_IDLE temp-State ! ;

\ Start the state machine
: temp-start-sm ( -- )  TEMP_START temp-State ! ;

\ Print temperature and VDDA from state machine  
: temp-print-sm ( -- )
  9 emit ." Temp: " temp-Temp @ 0 <# # # 46 hold #s #> type ."  C"
  9 emit ." VDDA: " temp-Vref @ 0 <# # # # 46 hold #s #> type ."  V"
;

\ -------------------------------------------------------------------------
\  Main program that starts on reset
\ -------------------------------------------------------------------------
: init ( -- )
  \ ---------------- Initialization ---------------------------------------
  \ Hardware
  dint            \ Global interrupt disable
  systick-init    \ Set system tick for 1 ms
  adc-init-hw     \ Initialize ADC
  rtc-reg-write   \ Enable RTC register writes (to clear alarm flag)
  eint            \ Global interrupt enable

  \ Tasks
  rtc-set-alarm-1min
  rtc-clear-alarm-flag
  temp-init-sm
  cr cr ." Printing time, date, temp, and VDDA at beginning of each minute"

  \ ---------------- Main loop --------------------------------------------
  begin wait-for-tick

    rtc-alarm? if
      rtc-clear-alarm-flag
      cr rtc-hms@ .HH:MM:SS 9 emit -1 rtc-ymd@ .YYYY.MM.DD
      temp-start-sm
    then
    
    temp-exec-sm
    temp-Done-Flag @ if
      temp-print-sm
      temp-Temp @ rtc-delta-cal
      dup 9 emit ." Delta NP: " .
      rtc-update-cal
      0 temp-Done-Flag !
    then
    
  key? until            \ Escape from main loop on key press
;

\ -------------------------------------------------------------------------
compiletoram
