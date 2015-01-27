
\ Transmit ADC samples as UDP packet stream over ethernet
\   needs basisdefinitions.txt and ethernet.txt

\ -----------------------------------------------------------------------------
\ Clock setup for 25 MHz crystal and 120 MHz PLL
\ -----------------------------------------------------------------------------

\ -----------------------------------
\ System Control registers (SYSCTL)
\ -----------------------------------

$400FE000 constant Sysctl-Base

Sysctl-Base $050 + constant RIS
Sysctl-Base $0B0 + constant RSCLKCFG
Sysctl-Base $0C0 + constant MEMTIM0
Sysctl-Base $07C + constant MOSCCTL

Sysctl-Base $138 + constant ALTCLKCFG

Sysctl-Base $160 + constant PLLFREQ0
Sysctl-Base $164 + constant PLLFREQ1
Sysctl-Base $168 + constant PLLSTAT

$400FDFC8 constant flashconf

\ Page 604:
\ If the prefetch buffers are enabled and application code branches to a location other than
\ flash memory, the prefetch tags need to be cleared upon returning to flash code execution.
\ Prefetch tags can be cleared by setting the CLRTV bit in the FLASHCONF register.

\ Geht das auch mit eingeschaltetem Prefetch-Puffer und ohne jedesmal CLRTV ?
\ Es scheint zumindest so, muss aber noch gründlich getestet werden.

\ ---------------------------------------------------
\ Choose the external 25 MHz crystal as system clock
\ ---------------------------------------------------

: 25MHz ( -- ) 

\  1 16 lshift                \ Force Prefetch buffers off (FPFOFF)
\  1 20 lshift or flashconf ! \ CLRTV Clear valid tags

  0 RSCLKCFG ! \ Oscsrc = PIOSC, PLL off, just in case this is called a second time.

  $10 ( OSCRNG ) MOSCCTL ! \ High range for MOSC crystal > 10 MHz.
  begin $00000100 ( MOSCPUPRIS ) RIS bit@ until  \ Wait for crystal to be running stable

   2 22 lshift     \ EEPROM clock high time
   1 16 lshift or  \ EEPROM 5 waitstates
   2  6 lshift or  \  Flash clock high time
   1  0 lshift or  \  Flash 5 waitstates
     $00100010 or  \ Two bits that must be one ?!
   MEMTIM0 !
  
  $80300000 RSCLKCFG ! \ MEMTIMU, undivided MOSC as oscillator source
;

\ ------------------------------------------------------------
 \ Fire up PLL for 120 MHz core frequency with 25 MHz crystal
\ ------------------------------------------------------------

: 120MHz ( -- )

\  1 16 lshift                \ Force Prefetch buffers off (FPFOFF)
\  1 20 lshift or flashconf ! \ CLRTV Clear valid tags

  \ 1. Once POR has completed, the PIOSC is acting as the system clock.

  0 RSCLKCFG ! \ Oscsrc = PIOSC, PLL off, just in case this is called a second time.

  \ 2. Power up the MOSC by clearing the NOXTAL bit in the MOSCCTL register.
  \ 3. If single-ended MOSC mode is required, the MOSC is ready to use. If crystal mode is required,
  \    clear the PWRDN bit and wait for the MOSCPUPRIS bit to be set in the Raw Interrupt Status
  \    (RIS), indicating MOSC crystal mode is ready.

  $10 ( OSCRNG ) MOSCCTL ! \ High range for MOSC crystal > 10 MHz.
  begin $00000100 ( MOSCPUPRIS ) RIS bit@ until  \ Wait for crystal to be running stable
  
  \ 4. Set the OSCSRC field to 0x3 in the RSCLKCFG register at offset 0x0B0.

  $03300000 RSCLKCFG ! \ MOSC as oscillator source, MOSC as input for PLL

  \ 5. If the application also requires the MOSC to be the deep-sleep clock source, then program the
  \    DSOSCSRC field in the DSCLKCFG register to 0x3.

  \ 6. Write the PLLFREQ0 and PLLFREQ1 registers with the values of Q, N, MINT, and MFRAC to
  \    the configure the desired VCO frequency setting.

      \ fvco    = fcrystal * (mint + mfrac / 1024) / (q+1)(n+1)
      \ 480 MHz = 25 Mhz   * (  96 +     0 / 1024) / (0+1)(4+1)

  1 23 lshift 96 or PLLFREQ0 !  \ PLLPWR enabled, Mint = 96
  4 PLLFREQ1 !                   \ N = (4+1), Q = (0+1)

  \ 7. Write the MEMTIM0 register to correspond to the new system clock setting.

   6 22 lshift     \ EEPROM clock high time
   5 16 lshift or  \ EEPROM 5 waitstates
   6  6 lshift or  \  Flash clock high time
   5  0 lshift or  \  Flash 5 waitstates
     $00100010 or  \ Two bits that must be one ?!
   MEMTIM0 !

  \ 8. Wait for the PLLSTAT register to indicate the PLL has reached lock at the new operating point
  \    (or that a timeout period has passed and lock has failed, in which case an error condition exists
  \    and this sequence is abandoned and error processing is initiated).

  begin 1 PLLSTAT bit@ until

  \ 9. Write the RSCLKCFG register's PSYSDIV value, set the USEPLL bit to enabled, and MEMTIMU bit.

  \ fsyclk = fVCO / (PSYSDIV + 1) With PLL on 480 MHz, this gives 120 MHz.
 
  $D3300000 \ MEMTIMU USEPLL NEWFREQ, MOSC as oscillator source, MOSC as input for PLL
  3      or  \  PLL/4 --> 120MHz
  RSCLKCFG !

\  1 16 lshift                \ Force Prefetch buffers off (FPFOFF)
\  1 20 lshift or flashconf ! \ CLRTV Clear valid tags
;

\ -----------------------------------------------------------------------------
\ -----------------------------------------------------------------------------

\ Analog-Digital converter basics

$400FE638 constant RCGCADC

: init-analog ( -- ) 
  $1 RCGCADC ! \ Provide clock to AD-Converter
               \ PIOs already activated in Core
  50 0 do loop \ Wait a bit
;


\ Ports B, D, E, K carry analog inputs.

PORTB_BASE $420 + constant PORTB_AFSEL ( Alternate function select )
PORTB_BASE $51C + constant PORTB_DEN   ( Digital Enable )
PORTB_BASE $528 + constant PORTB_AMSEL ( Analog Mode Select )

PORTD_BASE $420 + constant PORTD_AFSEL ( Alternate function select )
PORTD_BASE $51C + constant PORTD_DEN   ( Digital Enable )
PORTD_BASE $528 + constant PORTD_AMSEL ( Analog Mode Select )

PORTE_BASE $420 + constant PORTE_AFSEL ( Alternate function select )
PORTE_BASE $51C + constant PORTE_DEN   ( Digital Enable )
PORTE_BASE $528 + constant PORTE_AMSEL ( Analog Mode Select )

PORTK_BASE $420 + constant PORTK_AFSEL ( Alternate function select )
PORTK_BASE $51C + constant PORTK_DEN   ( Digital Enable )
PORTK_BASE $528 + constant PORTK_AMSEL ( Analog Mode Select )


\ Analog channel  Pin  Port

\ AIN0   12  PE3
\ AIN1   13  PE2
\ AIN2   14  PE1
\ AIN3   15  PE0

\ AIN4  128  PD7
\ AIN5  127  PD6
\ AIN6  126  PD5
\ AIN7  125  PD4

\ AIN8  124  PE5
\ AIN9  123  PE4

\ AIN10 121  PB4
\ AIN11 120  PB5

\ AIN12   4  PD3
\ AIN13   3  PD2
\ AIN14   2  PD1
\ AIN15   1  PD0

\ AIN16  18  PK0
\ AIN17  19  PK1
\ AIN18  20  PK2
\ AIN19  21  PK3

\ See Datasheet Page 1048

: init-ain0  ( -- )  1 3 lshift PORTE_AFSEL bis!  1 3 lshift PORTE_DEN bic!  1 3 lshift PORTE_AMSEL bis! ;
: init-ain1  ( -- )  1 2 lshift PORTE_AFSEL bis!  1 2 lshift PORTE_DEN bic!  1 2 lshift PORTE_AMSEL bis! ;
: init-ain2  ( -- )  1 1 lshift PORTE_AFSEL bis!  1 1 lshift PORTE_DEN bic!  1 1 lshift PORTE_AMSEL bis! ;
: init-ain3  ( -- )  1 0 lshift PORTE_AFSEL bis!  1 0 lshift PORTE_DEN bic!  1 0 lshift PORTE_AMSEL bis! ;

: init-ain4  ( -- )  1 7 lshift PORTD_AFSEL bis!  1 7 lshift PORTD_DEN bic!  1 7 lshift PORTD_AMSEL bis! ;
: init-ain5  ( -- )  1 6 lshift PORTD_AFSEL bis!  1 6 lshift PORTD_DEN bic!  1 6 lshift PORTD_AMSEL bis! ;
: init-ain6  ( -- )  1 5 lshift PORTD_AFSEL bis!  1 5 lshift PORTD_DEN bic!  1 5 lshift PORTD_AMSEL bis! ;
: init-ain7  ( -- )  1 4 lshift PORTD_AFSEL bis!  1 4 lshift PORTD_DEN bic!  1 4 lshift PORTD_AMSEL bis! ;

: init-ain8  ( -- )  1 5 lshift PORTE_AFSEL bis!  1 5 lshift PORTE_DEN bic!  1 5 lshift PORTE_AMSEL bis! ;
: init-ain9  ( -- )  1 4 lshift PORTE_AFSEL bis!  1 4 lshift PORTE_DEN bic!  1 4 lshift PORTE_AMSEL bis! ;

: init-ain10 ( -- )  1 4 lshift PORTB_AFSEL bis!  1 4 lshift PORTB_DEN bic!  1 4 lshift PORTB_AMSEL bis! ;
: init-ain11 ( -- )  1 5 lshift PORTB_AFSEL bis!  1 5 lshift PORTB_DEN bic!  1 5 lshift PORTB_AMSEL bis! ;

: init-ain12 ( -- )  1 3 lshift PORTD_AFSEL bis!  1 3 lshift PORTD_DEN bic!  1 3 lshift PORTD_AMSEL bis! ;
: init-ain13 ( -- )  1 2 lshift PORTD_AFSEL bis!  1 2 lshift PORTD_DEN bic!  1 2 lshift PORTD_AMSEL bis! ;
: init-ain14 ( -- )  1 1 lshift PORTD_AFSEL bis!  1 1 lshift PORTD_DEN bic!  1 1 lshift PORTD_AMSEL bis! ;
: init-ain15 ( -- )  1 0 lshift PORTD_AFSEL bis!  1 0 lshift PORTD_DEN bic!  1 0 lshift PORTD_AMSEL bis! ;

: init-ain16 ( -- )  1 0 lshift PORTK_AFSEL bis!  1 0 lshift PORTK_DEN bic!  1 0 lshift PORTK_AMSEL bis! ;
: init-ain17 ( -- )  1 1 lshift PORTK_AFSEL bis!  1 1 lshift PORTK_DEN bic!  1 1 lshift PORTK_AMSEL bis! ;
: init-ain18 ( -- )  1 2 lshift PORTK_AFSEL bis!  1 2 lshift PORTK_DEN bic!  1 2 lshift PORTK_AMSEL bis! ;
: init-ain19 ( -- )  1 3 lshift PORTK_AFSEL bis!  1 3 lshift PORTK_DEN bic!  1 3 lshift PORTK_AMSEL bis! ;


$40038FC8 constant ADC0_CC   \ Clock configuration
$40038000 constant ADC0_ACTSS \ Active Sample Sequencer
$40038044 constant ADC0_SSCTL0 \ Sample Sequence Control 0
$40038048 constant ADC0_SSFIFO0 \ Sample Sequence Result FIFO
$40038040 constant ADC0_SSMUX0   \ Sample Sequence Input Multiplexer Select 0
$40038028 constant ADC0_PSSI      \ Processor Sample Sequence Initiate
$40038058 constant ADC0_SSEMUX0    \ Sample Sequence Extended Input Multiplexer Select 0
$40038FC4 constant ADC0_PC          \ Peripheral configuration
$40038FC8 constant ADC0_CC           \ Clock configuration

: analog ( Channel -- Measurement )

  14 4 lshift  ADC0_CC !      \ PLL VCO on 480 MHz / (14 + 1) = 32 MHz
  7 ADC0_PC !                  \ Full sample rate giving 2 Msps

  0 ADC0_ACTSS !                              \ Disable Sample Sequencers
  dup $10 and if 1 else 0 then ADC0_SSEMUX0 ! \ Extended bit of input channel.
  $F and ADC0_SSMUX0 !                        \ Select input channel for first sample
  2 ADC0_SSCTL0 !                             \ First Sample is End of Sequence

  1 ADC0_ACTSS !                              \ Enable Sample Sequencer 0
  1 ADC0_PSSI !                               \ Initiate sampling

  begin $10000 ADC0_ACTSS bit@ not until      \ Check busy Flag for ADC

  ADC0_SSFIFO0 @ \ Fetch measurement result
;


\ -----------------------------------------------------------------------------
\ -----------------------------------------------------------------------------

\ Loran-C receiver basics

 
\ Fine tuning clock calibration for a precise frequency source
\ done in assembly for 1 MHz frequency output
\   needs basisdefinitions.txt and pll.txt

\ Atomic LED IO

: led-on  led-1 led-1 2 lshift PORTN_BASE or ! inline ;
: led-off     0 led-1 2 lshift PORTN_BASE or ! inline ;

: ledb-on  led-2 led-2 2 lshift PORTN_BASE or ! inline ;
: ledb-off     0 led-2 2 lshift PORTN_BASE or ! inline ;

$E000E010 constant Systick-CTRL
$E000E014 constant Systick-RELOAD
$E000E018 constant Systick-CURRENT

118 constant ticks-slow
119 constant ticks-exact
120 constant ticks-fast

99990 500 + 2* buffer: Circus  \ Maximum GRI + 500 samples convolution wraparound

: sample>address shl Circus + inline ;

hex

: samples@ ( -- samples )
  [ 
     f847 h, 6d04 h,  \  str.w   r6, [r7, #-4]!
     ea5f h, 0608 h,  \  movs.w  r6, r8
  ]
inline ;

: samples! ( samples -- )
  [ 
     ea5f h, 0806 h,  \  movs.w  r8, r6
     cf40 h,          \  ldmia   r7!, {r6}
  ]
inline ;

: sampleno@ ( -- sampleno )
  [ 
     f847 h, 6d04 h,  \  str.w   r6, [r7, #-4]!
     ea5f h, 0609 h,  \  movs.w  r6, r9
  ]
inline ;

: sampleno! ( sampleno -- )
  [ 
     ea5f h, 0906 h,  \  movs.w  r9, r6
     cf40 h,          \  ldmia   r7!, {r6}
  ]
inline ;

: offset@ ( -- offset )
  [ 
     f847 h, 6d04 h,  \  str.w   r6, [r7, #-4]!
     ea5f h, 060a h,  \  movs.w  r6, r10
  ]
inline ;

: offset! ( offset -- )
  [ 
     ea5f h, 0a06 h,  \  movs.w  r10, r6
     cf40 h,          \  ldmia   r7!, {r6}
  ]
inline ;

: tack@ ( -- tack )
  [ 
     f847 h, 6d04 h,  \  str.w   r6, [r7, #-4]!
     ea5f h, 060b h,  \  movs.w  r6, r11
  ]
inline ;

: tack! ( tack -- )
  [ 
     ea5f h, 0b06 h,  \  movs.w  r11, r6
     cf40 h,          \  ldmia   r7!, {r6}
  ]
inline ;

: gri@ ( -- gri )
  [ 
     f847 h, 6d04 h,  \  str.w   r6, [r7, #-4]!
     ea5f h, 060c h,  \  movs.w  r6, r12
  ]
inline ;

: gri! ( gri -- )
  [ 
     ea5f h, 0c06 h,  \  movs.w  r12, r6
     cf40 h,          \  ldmia   r7!, {r6}
  ]
inline ;


: exact-crystal-handler ( -- )

  led-on
  1 ADC0_PSSI !  \ Restart ADC

  [
    \ Fetch measurement result from FIFO
    ADC0_SSFIFO0 0 registerliteral,
    6800 h,                          \ ldr	r0, [r0, #0]

     \ Put circular buffer start address into r1
     Circus 1 registerliteral,

     \ Any samples to capture left ?
     f1b8 h, 0f00 h,                 \ cmp.w	r8, #0
     d00b h,                         \ beq.n	Increment circular sample pointer

     \ One sample less to capture     
     f1b8 h, 0801 h,                 \ subs.w	r8, r8, #1

     \ Subtract offset for wider dynamic range
     ebb0 h, 000a h,                 \ subs.w	r0, r0, sl

     \ Calculate buffer location
     eb11 h, 0109 h,                 \ adds.w	r1, r1, r9
     eb11 h, 0109 h,                 \ adds.w	r1, r1, r9

     \ Add measurement into buffer
     \ 880a h,                         \ ldrh	r2, [r1, #0]
     \ fa92 h, f210 h,                 \ qadd16	r2, r2, r0
     \ 800a h,                         \ strh	r2, [r1, #0]

     \ Store measurement
     8008 h,  \ strh r0, [r1, #0]

     \ Increment circular sample pointer:

     f119 h, 0901 h,                  \ adds.w	r9, r9, #1
     45e1 h,                          \ cmp	r9, ip
     bf28 h,                          \ it	cs
     f04f h, 0900 h,                  \ movcs.w	r9, #0
  ]


  \ Perform on-the-fly clock calibration.

  [
     f51b h, 3b80 h,                 \  adds.w  fp, fp, #65536  ; 0x10000
     ebbb h, 4f0b h,                 \  cmp.w   fp, fp, lsl #16
     bf26 h,                         \  itte    cs
     f05f h, 0200 ticks-exact or h,  \  movscs.w        r2, #58 ; 0x3a
     fa1f h, fb8b h,                 \  uxthcs.w        fp, fp
     f05f h, 0200 ticks-exact or h,  \  movscc.w        r2, #59 ; 0x3b

     Systick-Reload 0 registerliteral,
     6002 h,                         \  str     r2, [r0, #0]    ; 0x00
  ]
  led-off
;

: slow-crystal-handler ( -- )

  led-on
  1 ADC0_PSSI !  \ Restart ADC

  [
    \ Fetch measurement result from FIFO
    ADC0_SSFIFO0 0 registerliteral,
    6800 h,                          \ ldr	r0, [r0, #0]

     \ Put circular buffer start address into r1
     Circus 1 registerliteral,

     \ Any samples to capture left ?
     f1b8 h, 0f00 h,                 \ cmp.w	r8, #0
     d00b h,                         \ beq.n	Increment circular sample pointer

     \ One sample less to capture     
     f1b8 h, 0801 h,                 \ subs.w	r8, r8, #1

     \ Subtract offset for wider dynamic range
     ebb0 h, 000a h,                 \ subs.w	r0, r0, sl

     \ Calculate buffer location
     eb11 h, 0109 h,                 \ adds.w	r1, r1, r9
     eb11 h, 0109 h,                 \ adds.w	r1, r1, r9

     \ Add measurement into buffer
     \ 880a h,                         \ ldrh	r2, [r1, #0]
     \ fa92 h, f210 h,                 \ qadd16	r2, r2, r0
     \ 800a h,                         \ strh	r2, [r1, #0]

     \ Store measurement
     8008 h,  \ strh r0, [r1, #0]

     \ Increment circular sample pointer:

     f119 h, 0901 h,                  \ adds.w	r9, r9, #1
     45e1 h,                          \ cmp	r9, ip
     bf28 h,                          \ it	cs
     f04f h, 0900 h,                  \ movcs.w	r9, #0
  ]

  \ Perform on-the-fly clock calibration.

  [
     f51b h, 3b80 h,                 \  adds.w  fp, fp, #65536  ; 0x10000
     ebbb h, 4f0b h,                 \  cmp.w   fp, fp, lsl #16
     bf26 h,                         \  itte    cs
     f05f h, 0200 ticks-slow  or h,  \  movscs.w        r2, #58 ; 0x3a
     fa1f h, fb8b h,                 \  uxthcs.w        fp, fp
     f05f h, 0200 ticks-exact or h,  \  movscc.w        r2, #59 ; 0x3b

     Systick-Reload 0 registerliteral,
     6002 h,                         \  str     r2, [r0, #0]    ; 0x00
  ]
  led-off
;

: fast-crystal-handler ( -- )

  led-on
  1 ADC0_PSSI !  \ Restart ADC

  [
    \ Fetch measurement result from FIFO
    ADC0_SSFIFO0 0 registerliteral,
    6800 h,                          \ ldr	r0, [r0, #0]

     \ Put circular buffer start address into r1
     Circus 1 registerliteral,

     \ Any samples to capture left ?
     f1b8 h, 0f00 h,                 \ cmp.w	r8, #0
     d00b h,                         \ beq.n	Increment circular sample pointer

     \ One sample less to capture     
     f1b8 h, 0801 h,                 \ subs.w	r8, r8, #1

     \ Subtract offset for wider dynamic range
     ebb0 h, 000a h,                 \ subs.w	r0, r0, sl

     \ Calculate buffer location
     eb11 h, 0109 h,                 \ adds.w	r1, r1, r9
     eb11 h, 0109 h,                 \ adds.w	r1, r1, r9

     \ Add measurement into buffer
     \ 880a h,                         \ ldrh	r2, [r1, #0]
     \ fa92 h, f210 h,                 \ qadd16	r2, r2, r0
     \ 800a h,                         \ strh	r2, [r1, #0]

     \ Store measurement
     8008 h,  \ strh r0, [r1, #0]

     \ Increment circular sample pointer:

     f119 h, 0901 h,                  \ adds.w	r9, r9, #1
     45e1 h,                          \ cmp	r9, ip
     bf28 h,                          \ it	cs
     f04f h, 0900 h,                  \ movcs.w	r9, #0
  ]

  \ Perform on-the-fly clock calibration.

  [
     f51b h, 3b80 h,                 \  adds.w  fp, fp, #65536  ; 0x10000
     ebbb h, 4f0b h,                 \  cmp.w   fp, fp, lsl #16
     bf26 h,                         \  itte    cs
     f05f h, 0200 ticks-fast  or h,  \  movscs.w        r2, #58 ; 0x3a
     fa1f h, fb8b h,                 \  uxthcs.w        fp, fp
     f05f h, 0200 ticks-exact or h,  \  movscc.w        r2, #59 ; 0x3b

     Systick-Reload 0 registerliteral,
     6002 h,                         \  str     r2, [r0, #0]    ; 0x00
  ]
  led-off
;

decimal


: exact-xtal ( -- ) ['] exact-crystal-handler irq-systick ! ticks-exact Systick-RELOAD !  ;
: slow-xtal  ( -- ) [']  slow-crystal-handler irq-systick ! ;
: fast-xtal  ( -- ) [']  fast-crystal-handler irq-systick ! ;

: t ( u -- ) tack! ; \ For quick clock adjustments


1000,00 2constant centerfrequency \ in kHz
 120,00 2constant tickcount

: khz ( f -- ) \ Uses measurement with exact-crystal handler to determine tack value

  centerfrequency f/ 1,0 d-  
  2dup dabs 0,0000003 d< 
  if 2drop ." Crystal almost perfect" exact-xtal
  else

  tickcount f* 1,0 2swap f/
  
  nip \ Signed Tack on Stack.

  dup 0< if   ." Crystal too slow, Tack: " slow-xtal abs dup tack! u. ( 0 tick ! )
         else ." Crystal too fast, Tack: " fast-xtal abs dup tack! u. ( 0 tick ! )
         then 
  then
  cr
;


: init-stream ( -- )

  120mhz \ Crystal & PLL clock source

  \ Setup analog input channel and sequencer.
  init-analog 
  init-ain0
  0 analog drop \ To set sample sequencer... Forget result.

  \ Setup capture registers

  1024 gri!    \ 1024 Samples give 2048 Bytes which is a good size to be transmitted in two UDP packets.
  0 samples!
  0 sampleno!
  0 offset!

  \ Welcome message

  ." Analog stream over Ethernet for TM4C1294 by Matthias Koch" cr

  \ Setup Systick timer

  ['] exact-crystal-handler irq-systick !
  0 tack!
  eint

            0 Systick-CURRENT ! \ Clear Systick counter
  ticks-exact Systick-RELOAD !   \ Divider for clock
            7 Systick-CTRL !      \ System Clock, Interrupt enable, Systick enable
;


: capture ( Samples -- )
  0 sampleno! samples!   \ Start at the beginning of the buffer

  begin

    begin pause sampleno@ 512 u>= until \ Wait for the sample number to be in the second half of the buffer
    Circus 1024 data-hdr sendv    \ Transmit first half of the buffer

    begin pause sampleno@ 512 u< until  \ Wait for the sample number to be in the first half of the buffer
    Circus 1024 + 1024 data-hdr sendv  \ Transmit second half of the buffer

  samples@ 0= until \ Continue until all samples are transmitted.
;
