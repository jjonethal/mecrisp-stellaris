\ =========================================================================
\  File: rtc-calib.fs for Mecrisp-Stellaris by Matthias Koch
\ 
\  Words to calibrate the RTC clock of STM32F051.
\ 
\  Words in this file use definitions in the source file rtc-init-set.fs.
\  
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.04.10
\ =========================================================================
compiletoflash

$40021000 constant RCC
  RCC $04 + constant RCC_CFGR
  RCC $14 + constant RCC_AHBENR

$48000000 constant GPIOA
  GPIOA $00 + constant GPIOA_MODER
  GPIOA $04 + constant GPIOA_OTYPER
  GPIOA $08 + constant GPIOA_OSPEEDR
  GPIOA $0C + constant GPIOA_PUPDR
  GPIOA $24 + constant GPIOA_AFRH

\ -------------------------------------------------------------------------
\  RTC clock calibration words
\ 
\  Note:  The use of these words for calibration of the RTC can disturb
\         the time and date settings.  After calibration is complete, the
\         date and time should be set again.
\ 
\ -------------------------------------------------------------------------
: rtc-lse->mco ( -- )
  \ Put RTC LSE on MCO pin (PA8)
  \ Use this word to measure the low speed oscillator frequency going into
  \ the RTC.  The measured frequency is used as input to rtc-cal-lse to
  \ set the "smooth calibration" of the RTC clock.
  \ Route RTC LSE to MCO
  RCC_CFGR @ %1111 24 lshift not and
  %0011 24 lshift or RCC_CFGR !
  \ Enable GPIOA peripheral clock and set pin PA8 for output and AF0
  %1 17 lshift RCC_AHBENR bis!
  GPIOA_MODER @ %11 16 lshift not and
  %10 16 lshift or GPIOA_MODER !
  %1 8 lshift GPIOA_OTYPER bic!     \ Reset default
  %11 16 lshift GPIOA_OSPEEDR bis!  \ Fast
  %11 16 lshift GPIOA_PUPDR bic!    \ Reset default
  %1111 GPIOA_AFRH bic!             \ AF0, reset default
;

: rtc-start-clk->out ( -- )
  \ Send RTC output to PC13
  \ Use this word so that RTC clock frequency can be checked after
  \ calibration is done.  With default reset values, the output will be a
  \ 1 Hz square wave.
  \ Disable outer layer of write protection
  rtc-reg-write
  rtc-unlock-write
  %1 23 lshift %1 19 lshift or RTC_CR bis!
  rtc-lock-write
;

: rtc-stop-clk->out ( -- )
  \ Remove RTC output from PC13
  \ Disable outer layer of write protection
  rtc-reg-write
  rtc-unlock-write
  %1 23 lshift %1 19 lshift or RTC_CR bic!
  rtc-lock-write
;

: rtc-wrt-cal ( cal-val -- ) ( s -- )
  \ Write cal-val to the RTC_CALR register
  \ Disable outer layer of write protection
  rtc-reg-write
  rtc-unlock-write
  \ Wait for RECALPF bit in RTC_ISR to clear
  begin %1 16 lshift RTC_ISR @ and 0= until
  \ Write value to register
  dup RTC_CALR !
  cr ." Hex value written to RTC_CALR: " hex . decimal
  rtc-lock-write
;

: rtc-save-cal ( -- )
  \ Save the calibration value in a battery domain register
  RTC_CALR @ RTC_BKP0R !
;

: rtc-get-np0 ( -- np0 ) ( -- n )
  \ Get the number of pulses added or removed for initial RTC calibration
  \ saved in battery domain register
  RTC_BKP0R @ dup 
  %1 15 lshift and 15 rshift 512 *    \ 512*CALP
  swap $1FF and -                     \ np0 = 512*CALP - CALM
;

: rtc-cal-lse ( freq -- ) ( df -- )
  \ This word sets values in the RTC_CALR register after the LSE frequency
  \ is measured on MCO.  If you are also using temperature compensation
  \ calibration on the fly (see below), the measurement of frequency
  \ for this word should be done at the turnover temperature T0 of the
  \ crystal being used.
  \ 
  \ *** This word is only for the default case where the LSE has nominal
  \ *** frequency 32768 Hz.
  \ 
  \ Input is the current measured frequency of RTC clock LSE in Hz,
  \ as an s31.32 fixed point value.  The number of pulses to be masked in
  \ the RTCCLK in a 32 second period is the negative of 32 times
  \ frequency error, that is,
  \ 
  \              np = -32*(freq - 32768)
  \ 
  \ If np is negative, pulses are inserted rather than masked.
  \ 
  \ Calculate np as s31.32, then round to single value
  32768,0 2swap d- 5 0 do dshl loop 0,5 d+ nip
  \ The number of pulses is set by the CALM and CALP bits in RTC_CALR
  \ with np = (512*CALP) - CALM, where CALP = 0 or 1 and CALM is between
  \ 0 and 511.  Thus np must be restricted to the range -511 to +512.
  dup 512 > if drop 512 then
  dup -511 < if drop -511 then
  \ Calculate the value for RTC_CALR
  dup 0 > if
    \ CALM = 512 - np, CALP = 1
    512 swap - %1 15 lshift or
  else
    \ CALM = -np, CALP = 0
    negate
  then
  \ Write to register
  rtc-wrt-cal
  \ Save for on-the-fly adjustments for temperature
  rtc-save-cal
;

\ -------------------------------------------------------------------------
\  Words to calculate and display RTC on-the-fly calibration adjustment
\  of pulses based on internal temperature sensor values
\ -------------------------------------------------------------------------
\  The following constants characterize the equation that gives
\  the dependence of the frequency of the clock crystal on temperature,
\  namely, the parabola given by
\ 
\       f = f0 * [1 - K*(T - T0)^2]
\ 
\  where
\       f0 = turnover frequency
\       T0 = turnover temperature
\       K = temperature coefficient (as a positive value)
\ 
\  The nominal values for a particular 5 ppm clock crystal are f0 = 32768, 
\  T0 = 25 deg C, and K = 0.034 ppm/deg C sqr.  These are used in this
\  demo program.
\ 
\  The number of additional (or removed in the negative case) timer pulses
\  NP represented by the CALP and CALM values in RTC_CALR used to adjust
\  the RTC frequency to 32768 Hz are calculated from the equation
\ 
\       NP = 32 * (32768 - f)
\ 
\  Substitution gives
\ 
\       NP = 32 * [32768 - f0 + f0*K*(T - T0)^2] 
\ 
\  If an initial calibration of the chip is done at T = T0 (assuming it is
\  known), we can measure f0 and then write
\ 
\       NP = NP0 + delta-NP = 32*(32768 - f0) + 32*f0*K*(T - T0)^2
\ 
\  where NP0 = 32*(32768 - f0) is the number of pulses for the initial
\  calibration and delta-NP = 32*f0*K*(T - T0)^2 = A*(T - T0)^2 is the 
\  adjustment for the temperature deviation from T0.  
\  
\  For best accuracy, the crystal frequency should be measured at enough
\  temperature values to estimate f0, T0, and K, as K can also vary from
\  unit to unit.
\  
\ -------------------------------------------------------------------------
\ Nominal datasheet turnover temperature
25,0 2constant rtc-Temp0
\ Nominal adjustment coefficient A = 32*f0*K using f0 = 32768 and K = 0.034
\ ppm/deg C sqr or 3.4 x 10^-8 from the datasheet
\ 0,035651584 2constant rtc-A

\ Value of A for f0 = 32769.2, K as above.  For this value of f0 we have
\ NP0 = $26 as the initial number of pulses.
0,03565289 2constant rtc-A

: rtc-delta-cal ( temp -- delta-np ) ( n -- n )
  \ Calculate change in RTC calibration pulses due to temperature
  \   delta-pulses = A * (T - T0)^2
  \ Input is current estimate of core temp in centideg C
  \ Output is change in number of pulses delta-np
  0 swap 100,0 f/   \ Convert temp input to s31.32 in deg C
  rtc-Temp0 d- 2dup f* rtc-A f*
  0,5 d+ nip                    \ Round to integer
;

: rtc-update-cal ( delta-np -- ) ( n -- )
  \ Modify current RTC calibration value by adding delta-np pulses
  \ The number of pulses is set by the CALM and CALP bits in RTC_CALR
  \ with np = (512*CALP) - CALM, where CALP = 0 or 1 (bit 15 in RTC_CALR)
  \ and CALM is between 0 and 511 (bits 8:0 in RTC_CALR).
  \ Get initial calibration np0 and add delta-np for new np
  rtc-get-np0 +
  \ np must be restricted to the range -511 to +512.
  dup 512 > if drop 512 then
  dup -511 < if drop -511 then
  \ Calculate the value for RTC_CALR
  dup 0 > if
    \ CALM = 512 - np, CALP = 1
    512 swap - %1 15 lshift or
  else
    \ CALM = -np, CALP = 0
    negate
  then
  \ Write to register
  rtc-wrt-cal  
;

\ -------------------------------------------------------------------------
compiletoram
