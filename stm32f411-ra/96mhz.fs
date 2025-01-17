\ =============================================================================
\ =============================================================================
\ == Configure a STM32F411 to run at 96 MHz of a 25 MHz crystal oscillator   ==
\ =============================================================================
\ =============================================================================



\ =============================================================================
\ = Internal linear voltage regulator                                         =
\ =============================================================================

\ The STM32F411 has an internal linear regular. The default voltage scale 2
\ allows operation up to 84MHz. Changing the voltage scale requires
\ enabling the PWR peripheral.
: pwr-on ( -- ) true 28 28 >bits RCC_APB1ENR bis! ;

\ Raise the voltage scale to maximum of 3 enabling operation up to 100MHz.
\ The default after a reset is voltage scale 2 which is only
\ suitable for operation up to 84MHz.
: pwr-vos3 ( -- ) 3 15 14 >bits PWR_CR bis! ;



\ =============================================================================
\ = Flash latency, cacheing and prefetching                                   =
\ =============================================================================

\ On boot the internal flash is configured for reasonable performance with
\ the 16MHz HSI clock:
\   * no wait states
\   * no caching
\   * no prefetching
\ 
\ Running at 96MHz requires 3 wait states for correctness which would waste
\ most performance gained by increasing the M4 core clock. To allow
\ fast execution from the high latency internal flash it has a wide  
\ interface as well as a prefetcher feeding the instruction and data caches.
\ According to STMicro marketing this brings performance close to zero wait
\ states flash ... for loop heavy microbenchmarks.
: flash-96mhz ( -- )
\ Flash access control register:
\   Reset value  : $00000000
\   Chosen value : $00000703 ( XXX Keep in sync XXX )
\ 
\   Name            Value   [High:Low]  Semantics
    ( Reserved )        0   31 13 >bits \ undefined
    ( DCRST    )    false   12 12 +bits \ preserve data cache content
    ( ICRST    )    false   11 11 +bits \ preserve instruction cache content 
    ( DCEN     )     true   10 10 +bits \ enable the data cache
    ( ICEN     )     true    9  9 +bits \ enable the instruction cache
    ( PRFTEN   )     true    8  8 +bits \ enable flash prefetching
    ( Reserved )        0    7  4 +bits \ undefined
    ( LATENCY  )        3    3  0 +bits \ 3 wait states

    \ Configure flash read interface for 3 wait states, caching and prefetching
    dup FLASH_ACR !
    
    \ Wait until the desired configuration has taken effect
    begin dup FLASH_ACR @ = until drop ;




\ =============================================================================
\ = Main PLL setup on the STM32F411 WeAct Studio Black Pill board             =
\ =============================================================================

\ Block diagram of the internal and external components involved in system
\ clock generation.
\ 
\        +------------+
\        | 25MHz XTAL |
\        +------------+
\                  |
\ external         |
\                  v
\ ---------------------
\                  |
\ internal         |
\                  v
\  +-----+      +-----+
\  | HSI |      | HSE | internal and external high speed clocks
\  +-----+      +-----+
\     |            |
\     | 16MHz      | 25MHz
\     v            v
\  +-----+      +-----+
\   \     \____/     /  PLL source mux
\    \ PLLSRC = HSE /
\     +------------+
\              |
\           /M = 25
\              |
\              v
\ +--------------------+
\ |            | 1MHz  | Main PLL
\ | *N = 192 <-+       |
\ |    |               |
\ |    | VCO = 192MHz  |
\ |    |               |
\ |    +--> /P = 2 --->|--> 96MHz as PLLCLK to SYSCLOCK mux
\ |    |               |
\ |    +--> /Q = 4 --->|--> 48MHz for USB and SDIO
\ +--------------------+

\ The STM32F411 reference manual (ref man) is wrong about the maximum allowed
\ operation frequrencies for the APB2 and APB1 busses. Most likely the limits
\ have been copyed and pasted from the STM32F401 ref man ...
\ 
\ @STMicro: Do you guys even have a QA/QC department these days? If you I have
\   one please get in touch. I have a couple of questions about the supposedly
\   useable STM32H750VB crypt/hash units as well.
\ 
\ The correct limits can be found in STM32F411 *datasheet*.

\ The STM32F411 boots of the 16MHz High Speed Internal (HSI) oscillator.
\ Said HSI oscillator is factory calibrated to within ±1% which is precise
\ enough for an UART, but not within the ±0.25% tolerance required
\ of USB full speed devices.
\ On thise board the High Speed External (HSE) oscillator is connected
\ to a 25MHz crystal oscillator satisfying ±0.25% tolerance requirement.
: hse-on ( -- ) true 16 16 >bits RCC_CR bis! ;

\ The crystal oscillator requires awhile to stabilize. In theory this could
\ fail but because the USB CDC driver is expected to be the only console there
\ is no good way to log failure. This code would block aka deadlock on HSE
\ failure allowing the debugger to diagnose the failure.
: hse-ready? ( -- ? ) true 17 17 >bits RCC_CR bit@ ;
: hse-wait ( -- ) begin hse-ready? until ;

\ The PLL has to be disabled to configure it, because at the very least
\ changing its parameters while running would glitch the clock. Good luck
\ debugging the state corruption caused by careless clock glitching.
\ Leave me out of it should you the reader feel like fiddling around
\ with a running PLL used as system clock.
\ 
\ This word configures the main PLL as described in the ASCII art diagram
\ above to derive a 96MHz system clock and 48MHz peripheral clock for USB
\ from the 25MHz crystal oscillator.
: pll-init ( -- )
\ PLL configuration register:
\   Reset value  : $24003010
\   Chosen value : $24403019 ( XXX Keep in sync XXX )
\ 
\   Name            Value   [High:Low]  Semantics
    ( Reserved )        2   31 28 >bits \ undefined (not set to zero)
    ( PLLQ     )        4   27 24 +bits \ divide f_VCO by 4
    ( Reserved )        0   23 23 +bits \ undefined
    ( PLLSRC   )        1   22 22 +bits \ use HSE
    ( Reserved )        0   21 18 +bits \ undefined
    ( PLLP     )        0   17 16 +bits \ divide f_VCO by 2
    ( Reserved )        0   15 15 +bits \ undefined
    ( PLLN     )      192   14  6 +bits \ multiply source 192 
    ( PLLM     )       25    5  0 +bits \ divide source by 25 
    RCC_PLLCFGR ! ;

\ Starts the main PLL.
: pll-on ( -- ) true 24 24 >bits RCC_CR bis! ;

\ Just like the HSE clock the PLL has a start up delay.
: pll-ready? ( -- ? ) true 25 25 >bits RCC_CR bit@ ;
\ Block until the PLL has locked and indicated readiness or the
\ heat death of the universe whichever comes first.
: pll-wait ( -- ) begin pll-ready? until ;

\ The APB1 bus clock must be kept below 50MHz. Changes to the prescalers can
\ take up to 16 cycles to come into effect.  Schedule enough delay between
\ apb1-96mhz and pll-use to follow the ref man to the letter.
\ Other Mecrisp Stellaris ports to STM32F4xx chips ignore this
\ requirement in their clock setup.
: apb1-96mhz ( -- )
\ RCC clock configuration register:
\   Reset value  : $00000000
\   Chosen value : $07791000 ( XXX Keep in sync XXX )
\ 
\   Name        Value   [High:Low]  Semantics
    ( MCO2     )  %00   31 30 >bits \ Select SYSCLK as MCO2 source
    ( MCO2PRE  ) %000   29 27 +bits \ Don't divide the MCO2 output
    ( MCO1PRE  ) %111   26 24 +bits \ Divide the MCO1 output by 5
    ( I2SSRC   )   %0   23 23 +bits \ Use PLLI2S clock as source for I2S
    ( MCO1     )  %11   22 21 +bits \ Select PLL as MCO1 source
    ( RTCPRE   )   25   20 16 +bits \ Divide HSE by 25 to derive 1MHz RTC clock
    ( PPRE2    ) %000   15 13 +bits \ Run APB2 at undivided host clock of 96MHz 
    ( PPRE1    ) %100   12 10 +bits \ Run APB1 at half of host clock = 48MHz
    ( Reserved )  %00    9  8 +bits \ undefined
    ( HPRE     )    0    7  4 +bits \ Run host clock full SYSCLK = 96MHz
    ( SWS      )  %00    3  2 +bits \ READ ONLY (system clock source)
    ( SW       )  %00    1  0 +bits \ Use HSI as system clock
    RCC_CFGR ! ;

\ Switch the system clock to the main PLL.
\ The PLL has to already be initialized, enabled and ready for use.
: pll-use ( -- )
\ RCC clock configuration register:
\   Reset value  : $00000000
\   Chosen value : $07791001 ( XXX Keep in sync XXX )
\ 
\   Name        Value   [High:Low]  Semantics
    ( MCO2     )  %00   31 30 >bits \ Select SYSCLK as MCO2 source
    ( MCO2PRE  ) %111   29 27 +bits \ Divide MCO2 output by 5
    ( MCO1PRE  ) %111   26 24 +bits \ Divide MCO1 output by 5
    ( I2SSRC   )   %0   23 23 +bits \ Use PLLI2S clock as source for I2S
    ( MCO1     )  %11   22 21 +bits \ Select PLL as MCO1 source
    ( RTCPRE   )   25   20 16 +bits \ Divide HSE by 25 to derive 1MHz RTC clock
    ( PPRE2    ) %000   15 13 +bits \ Run APB2 at undivided host clock of 96MHz 
    ( PPRE1    ) %100   12 10 +bits \ Run APB1 at half of host clock = 48MHz
    ( Reserved )  %00    9  8 +bits \ undefined
    ( HPRE     )    0    7  4 +bits \ Run host clock full SYSCLK = 96MHz
    ( SWS      )  %00    3  2 +bits \ READ ONLY (system clock source)
    ( SW       )  %10    1  0 +bits \ Use PLL as system clock
    RCC_CFGR ! ;
    
: 96mhz ( -- )
    apb1-96mhz      \ Set the APB1 prescaler first because requires a delay
    pwr-on pwr-vos3 \ Increase the operating voltage to maximum as required 
    hse-on hse-wait \ Enable HSE and wait for it to stabilise
    flash-96mhz     \ Configure internal flash (wait states, cache, prefetch)
    pll-init pll-on pll-wait pll-use ; \ Switch system clock to 96MHz PLL

\ Put PA8 in alternate function mode. If the bitfields controlling pin 8 of 
\ GPIO port A are still at their reset values this enough
\ to output MCO1 on PA8.
\ : mco1 ( -- )
\     %1  0  0 >bits RCC_AHB1ENR bis!   \ Enable GPIO port A
\    %10 17 16 >bits GPIOA_MODER bis! ; \ Enable alternate function on PA8
\ 
\ : mco2 ( -- ) 
\    %1 2 2    >bits RCC_AHB1ENR bis!   \ Enable GPIO port C
\    %10 19 18 >bits GPIOA_MODER bis! ; \ Enable alternate function on PC9

96 1000 * 1000 * constant clock-hz
48 1000 * 1000 * constant usb-hz

\ : s ( n -- ) clock-hz * delay-cycles ;
\ : ms ( n -- ) clock-hz 1000 / * delay-cycles ;
\ : us ( n -- ) clock-hz 1000000 / * delay-cycles ;
