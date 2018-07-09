\ =========================================================================
\  File: rtc-init-set.fs for Mecrisp-Stellaris by Matthias Koch
\ 
\  Words to initialize and set time and date in RTC of STM32F051.
\  
\ -------------------------------------------------------------------------
\  Andrew Palm
\  2018.04.10
\ =========================================================================
compiletoflash

\ -------------------------------------------------------------------------
\  Misc. helper words, constants, and variables
\ -------------------------------------------------------------------------
\ Register addresses for STM32F051
$40021000 constant RCC
  RCC $1C + constant RCC_APB1ENR
  RCC $20 + constant RCC_BDCR

$40007000 constant PWR
  PWR $00 + constant PWR_CR
  PWR $04 + constant PWR_CSR

$40002800 constant RTC
  RTC $00 + constant RTC_TR 
  RTC $04 + constant RTC_DR 
  RTC $08 + constant RTC_CR 
  RTC $0C + constant RTC_ISR 
  RTC $10 + constant RTC_PRER 
  RTC $14 + constant RTC_WUTR 
  RTC $1C + constant RTC_ALRMAR 
  RTC $24 + constant RTC_WPR
  RTC $3C + constant RTC_CALR
  RTC $50 + constant RTC_BKP0R

\ -------------------------------------------------------------------------
\  Words for initializing the RTC and setting time and date
\ -------------------------------------------------------------------------
: rtc-hms! ( hh mm ss -- )
  \ Given single values for hour, minute, and seconds, write these values
  \ to the RTC_TR register (in BCD)
  \ Build BCD value for setting seconds, minutes, hours
  10 u/mod 4 lshift swap or
  ( hh mm bcd-ss )
  swap 10 u/mod 12 lshift swap 8 lshift or or 
  ( hh bcd-mmss )
  swap 10 u/mod 20 lshift swap 16 lshift or or
  ( bcd-hhmmss )
  RTC_TR !
;

: rtc-ymd! ( [yy]yy mm dd -- )
  \ Given single values for year, month, and day, write these values to the
  \ RTC_DT register (in BCD)
  \ Day of week set to non-zero value, assumed not used
  \ Build BCD value for setting day, month, and year
  10 u/mod 4 lshift swap or
  ( [yy]yy mm bcd-dd )
  swap 10 u/mod 12 lshift swap 8 lshift or or 
  ( [yy]yy bcd-mmdd )
  swap 100 u/mod drop 10 u/mod 20 lshift swap 16 lshift or or
  ( bcd-yymmdd )
  \ Set day of week to non-zero value (not used)
  %1 13 lshift or
  RTC_DR !
;

: rtc-reg-write ( -- )
  \ This word disables the outer layer of RTC register write protection.
  \ It should be part of the client's initialization if the client task
  \ needs to, say, clear the RTC alarm flag.
  \ Power interface clock enable
  %1 28 lshift RCC_APB1ENR bis!
  \ Enable RTC register writes
  %1 8 lshift PWR_CR bis!
  begin %1 8 lshift PWR_CR bit@ until
  \ Power interface clock disable
  %1 28 lshift RCC_APB1ENR bic!  
;

: rtc-unlock-write ( -- )
  \ Unlock write protection on RTC registers
  \ Unlock write protectionj
  $CA RTC_WPR c!
  $53 RTC_WPR c!
;

: rtc-lock-write
  \ Lock write protection on RTC registers
  $FF RTC_WPR c!
;

: rtc-init-lse ( -- )
  \ Set RTC clock source to LSE
  \ This word resets the backup domain, clearing date, time, and
  \ any calibration.  Do not call on a normal reset.
  \ Disable write outer protection
  rtc-reg-write
  \ Power interface clock enable
  %1 28 lshift RCC_APB1ENR bis!  
  \ Reset LSEON and LSEBYP bits
  %1 RCC_BDCR bic!
  %100 RCC_BDCR bic!
  \ Reset backup domain so RTC clock can be selected
  %1 16 lshift RCC_BDCR bis!
  %1 16 lshift RCC_BDCR bic!
  \ Set LSE drive level
  %11 3 lshift RCC_BDCR bic!
  %10 3 lshift RCC_BDCR bis!    \ Medium-low drive
  \ Turn on LSE oscillator and wait until it is stable
  %1 RCC_BDCR bis!
  begin %10 RCC_BDCR bit@ until
  \ Select LSE as RTC clock source
  %11 8 lshift RCC_BDCR bic!
  %1 8 lshift RCC_BDCR bis!
	\ Enable RTC clock
  %1 15 lshift RCC_BDCR bis!
  \ Power interface clock disable
  %1 28 lshift RCC_APB1ENR bic!
;

: rtc-set-t&d ( [yy]yy mm dd hh mm ss -- )
  \ This word sets the RTC time and date
  \ Disable write outer protection
  rtc-reg-write
  rtc-unlock-write
  \ Enter calendar initialization mode
  %1 7 lshift RTC_ISR bis!
  \ Wait until initialization ready
  begin %1 6 lshift RTC_ISR @ and 0<> until
  \ Set time and date
  rtc-hms!
  rtc-ymd!
  \ Set to 24-hour format
  %1 6 lshift RTC_CR bic!
  \ Exit initialization mode, start RTC
  %1 7 lshift RTC_ISR bic!
  rtc-lock-write
;

\ -------------------------------------------------------------------------
\  Alarm words
\ -------------------------------------------------------------------------
: rtc-clear-alarm-flag ( -- )
  \ Clear alarm flag
  %1 8 lshift RTC_ISR bic!
;

: rtc-alarm? ( -- flag )
  %1 8 lshift RTC_ISR @ and
;

: rtc-set-alarm-1min
  \ Set alarm to sampling interval of one minute
  \ Disable write outer protection
  rtc-reg-write
  \ Disable alarm
  %1 8 lshift RTC_CR bic!
  rtc-unlock-write  
  \ Set alarm mask for alarm at the beginning of every minute
  $FFFFFF00 RTC_ALRMAR !
  \ Clear alarm flag
  rtc-clear-alarm-flag
  \ Enable alarm interrupt
  \ %1 12 lshift RTC_CR bis!
  \ Enable alarm
  %1 8 lshift RTC_CR bis!  
  rtc-lock-write
;

\ -------------------------------------------------------------------------
\  Utility words for reading RTC date and time registers
\ -------------------------------------------------------------------------
: rtc-hms@ ( -- hh mm ss )
  \ Return hours, minutes, and seconds as single values from RTC
  RTC_TR @ dup %11 20 lshift and 20 rshift 10 *
  over %1111 16 lshift and 16 rshift + swap
  ( hh reg )
  dup %111 12 lshift and 12 rshift 10 *
  over %1111 8 lshift and 8 rshift + swap
  ( hh mm reg )
  dup %111 4 lshift and 4 rshift 10 *
  swap %1111 and +
  ( hh mm ss )
;

: rtc-ymd@ ( yyyyflag -- [yy]yy mm dd )
  \ Return year, month, and day as single values from RTC_DR.  If yyyyflag
  \ evaluates to true, 2000 is added to the two digit year value.
  RTC_DR @ dup %1111 20 lshift and 20 rshift 10 *
  over %1111 16 lshift and 16 rshift + swap
  ( yyyyflag yy reg )
  rot if swap 2000 + swap then
  ( [yy]yy reg )
  dup %1 12 lshift and 12 rshift 10 *
  over %1111 8 lshift and 8 rshift + swap
  ( [yy]yy mm reg )
  dup %11 4 lshift and 4 rshift 10 *
  swap %1111 and +
  ( [yy]yy mm dd )
;

\ -------------------------------------------------------------------------
compiletoram
