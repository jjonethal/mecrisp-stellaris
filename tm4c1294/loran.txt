
\
\    Loran-C - A software defined longwave navigation receiver
\    Copyright (C) 2014  Matthias Koch
\
\    This program is free software: you can redistribute it and/or modify
\    it under the terms of the GNU General Public License as published by
\    the Free Software Foundation, either version 3 of the License, or
\    (at your option) any later version.
\
\    This program is distributed in the hope that it will be useful,
\    but WITHOUT ANY WARRANTY; without even the implied warranty of
\    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\    GNU General Public License for more details.
\
\    You should have received a copy of the GNU General Public License
\    along with this program.  If not, see <http://www.gnu.org/licenses/>.
\

compiletoflash

\ -----------------------------------------------------------------------------
\ Basisdefinitions
\ -----------------------------------------------------------------------------

: Flamingo cr
."      _" cr
."     ^-)" cr
."      (.._          .._" cr
."       \`\\        (\`\\        (" cr
."        |>         ) |>        |)" cr
." ______/|________ (7 |` ______\|/_______a:f" cr
;


\ Port definitions for Tiva TM4C1294

$40058000 constant PORTA_BASE
$40059000 constant PORTB_BASE
$4005A000 constant PORTC_BASE
$4005B000 constant PORTD_BASE
$4005C000 constant PORTE_BASE
$4005D000 constant PORTF_BASE
$4005E000 constant PORTG_BASE
$4005F000 constant PORTH_BASE
$40060000 constant PORTJ_BASE
$40061000 constant PORTK_BASE
$40062000 constant PORTL_BASE
$40063000 constant PORTM_BASE
$40064000 constant PORTN_BASE
$40065000 constant PORTP_BASE
$40066000 constant PORTQ_BASE

PORTF_BASE $3FC + constant PORTF_DATA ( IO Data Register, all bits selected )
PORTF_BASE $400 + constant PORTF_DIR  ( Pin Direction )
PORTF_BASE $500 + constant PORTF_DR2R ( 2 mA drive current )
PORTF_BASE $504 + constant PORTF_DR4R ( 4 mA )
PORTF_BASE $508 + constant PORTF_DR8R ( 8 mA )
PORTF_BASE $53C + constant PORTF_DR12R ( 12 mA )
PORTF_BASE $50C + constant PORTF_ODR  ( Open Drain )
PORTF_BASE $510 + constant PORTF_PUR  ( Pullup Resistor )
PORTF_BASE $514 + constant PORTF_PDR  ( Pulldown Resistor )
PORTF_BASE $518 + constant PORTF_SLR  ( Slew Rate )
PORTF_BASE $51C + constant PORTF_DEN  ( Digital Enable )

PORTJ_BASE $3FC + constant PORTJ_DATA ( IO Data Register, all bits selected )
PORTJ_BASE $400 + constant PORTJ_DIR  ( Pin Direction )
PORTJ_BASE $500 + constant PORTJ_DR2R ( 2 mA drive current )
PORTJ_BASE $504 + constant PORTJ_DR4R ( 4 mA )
PORTJ_BASE $508 + constant PORTJ_DR8R ( 8 mA )
PORTJ_BASE $53C + constant PORTJ_DR12R ( 12 mA )
PORTJ_BASE $50C + constant PORTJ_ODR  ( Open Drain )
PORTJ_BASE $510 + constant PORTJ_PUR  ( Pullup Resistor )
PORTJ_BASE $514 + constant PORTJ_PDR  ( Pulldown Resistor )
PORTJ_BASE $518 + constant PORTJ_SLR  ( Slew Rate )
PORTJ_BASE $51C + constant PORTJ_DEN  ( Digital Enable )

PORTN_BASE $3FC + constant PORTN_DATA ( IO Data Register, all bits selected )
PORTN_BASE $400 + constant PORTN_DIR  ( Pin Direction )
PORTN_BASE $500 + constant PORTN_DR2R ( 2 mA drive current )
PORTN_BASE $504 + constant PORTN_DR4R ( 4 mA )
PORTN_BASE $508 + constant PORTN_DR8R ( 8 mA )
PORTN_BASE $53C + constant PORTN_DR12R ( 12 mA )
PORTN_BASE $50C + constant PORTN_ODR  ( Open Drain )
PORTN_BASE $510 + constant PORTN_PUR  ( Pullup Resistor )
PORTN_BASE $514 + constant PORTN_PDR  ( Pulldown Resistor )
PORTN_BASE $518 + constant PORTN_SLR  ( Slew Rate )
PORTN_BASE $51C + constant PORTN_DEN  ( Digital Enable )

\ Hardware definitions for Tiva Connected Launchpad

1 1 lshift  constant led-1 \ On Port N Bit 1
1 0 lshift  constant led-2 \ On Port N Bit 0
1 4 lshift  constant led-3 \ On Port F Bit 4
1 0 lshift  constant led-4 \ On Port F Bit 0

1 0 lshift  constant switch-1 \ On Port J Bit 0
1 1 lshift  constant switch-2 \ On Port J Bit 1

: init ( -- )

  \ Set wires for LEDs
  led-1 led-2 or portn_den !  \ LED 1&2 connections as digital lines
  led-1 led-2 or portn_dir !  \ LED 1&2 connections should be outputs
  led-3 led-4 or portf_den !  \ LED 3&4 connections as digital lines
  led-3 led-4 or portf_dir !  \ LED 3&4 connections should be outputs

  \ Set wires for switches
  switch-1 switch-2 or portj_den ! \ Switch connections as digital lines, inputs
  switch-1 switch-2 or portj_pur ! \ Activate pullup resistors for switches

  cr
  Flamingo
  cr
  ." Have a nice day !" cr
;

: switch1? ( -- ? ) switch-1 portj_data bit@ not ;
: switch2? ( -- ? ) switch-2 portj_data bit@ not ;

: switches begin ." Switch 1: " switch1? . ."  Switch 2: " switch2? . cr key? until ;

: leds ( -- )
  begin
    key
    dup
    case
      [char] 1 of led-1 portn_data xor! endof
      [char] 2 of led-2 portn_data xor! endof
      [char] 3 of led-3 portf_data xor! endof
      [char] 4 of led-4 portf_data xor! endof
    endcase
    27 =
  until
;

: cornerstone ( Name ) ( -- )
  <builds begin here $3FFF and while 0 h, repeat
  does>   begin dup  $3FFF and while 2+   repeat 
          eraseflashfrom
;


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
     880a h,                         \ ldrh	r2, [r1, #0]
     fa92 h, f210 h,                 \ qadd16	r2, r2, r0
     800a h,                         \ strh	r2, [r1, #0]

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
     880a h,                         \ ldrh	r2, [r1, #0]
     fa92 h, f210 h,                 \ qadd16	r2, r2, r0
     800a h,                         \ strh	r2, [r1, #0]

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
     880a h,                         \ ldrh	r2, [r1, #0]
     fa92 h, f210 h,                 \ qadd16	r2, r2, r0
     800a h,                         \ strh	r2, [r1, #0]

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


: loran ( -- )

  120mhz \ Crystal & PLL clock source

  \ Setup analog input channel and sequencer.
  init-analog 
  init-ain0
  0 analog drop \ To set sample sequencer... Forget result.

  \ Setup capture registers

  74990 gri!
  0 samples!
  0 sampleno!
  0 offset!

  \ Welcome message

  ." Loran-C receiver for TM4C1294 by Matthias Koch" cr

  \ Setup Systick timer

  ['] exact-crystal-handler irq-systick !
  0 tack!
  eint

            0 Systick-CURRENT ! \ Clear Systick counter
  ticks-exact Systick-RELOAD !   \ Divider for clock
            7 Systick-CTRL !      \ System Clock, Interrupt enable, Systick enable
;



  \ ---------------------------------------------------------------------------
  \ Code for signal capture - Routinen für den Empfang
  \ ---------------------------------------------------------------------------


: sign16 ( s16 -- n ) [ $b236 h, ] inline ; \ sxth r6, r6 Opcode

: clearbuffer ( -- ) \ Löscht den Puffer
  gri@ 0 do 0 i sample>address h! loop \ Puffer löschen 
;

0 variable latestgris

: samplegris ( n -- ) \  Liest Signal ein
  ledb-on
  dup latestgris !
  clearbuffer              \  Puffer löschen
  gri@ * samples!          \  Aufnahme starten mit der gewünschten Zahl von Samples
  begin samples@ 0= until  \  Abwarten, bis alle Samples aufgenommen worden sind
  ledb-off
;

: getsample ( sample# -- n ) sample>address h@ sign16 ;

: puffermaximum ( -- n ) \ Sucht nach dem größten Absolutwert im Puffer.
  0 \ Am Anfang ist der maximale Wert 0.
  gri@ 0 do 
           i getsample abs max  \ Ist der aktuelle Absolutwert größer ?
         loop
;

: printbuffer ( -- ) \ Gibt alle Messwerte aus
  dint \ So geht es viel schneller !
  \ Print contents of circular buffer
  cr cr
  gri@ 0 do 
           i u. space
           5000 0 do loop \ Wait a little bit...
           i getsample . cr
           5000 0 do loop \ Wait a little bit for upstream communication buffers
           key? if unloop eint exit then
         loop
  eint
;

: offsetmeasurement ( -- ) \ Determine current signal offset

  0 offset!  
  2 samplegris

  0 \ Startwert für den Offset

  gri@ 0 do 
           i getsample   +  \ Alle Samples aufsummieren
         loop

  gri@ 2 *   /    \ Teilen durch die Zahl der Messwerte

  offset!
;

64 variable griscapture      \ How many GRIs for a signal capture ?
32 variable griscalibration  \ How many for clock calibration ?

: coarse ( -- )
  cr \ Try to coarsely determine crystal frequency in -100 ppm to +100 ppm range.
  offsetmeasurement

  101 -100 do
    i . ." ppm "  0 i  0,001 f* 1000,0 d+ ( 2dup f. ) khz
    griscalibration @ samplegris
    puffermaximum ."  Maximum: " . cr
  loop
  cr
;


\ On-the-fly fine frequency calibration and tracking. 
\ This needs a good SNR because it uses maximum signal amplitude as reference point.
\ You have to do coarse calibration before, as this searches for 
\ local intensity maximum in narrow frequency offset range only and it
\ cannot switch from too-fast crystal handler to too-slow crystal handler and vice versa.
\ But as crystals tend to be "bad enough", it is unlikely to cross the +-0 ppm border.

0  variable calibrationtack
0  variable calibrationamplitude
20 variable calibrationrange

: calfreq ( -- ) \ Taktkalibration anhand des Signals.
  cr             \ Fine tune clock with signal.
  offsetmeasurement
  ." Old Tack: " tack@ $FFFF and u. cr

  0 calibrationamplitude !

  tack@ $FFFF and calibrationrange @ + 1+
  tack@ $FFFF and calibrationrange @ - 
  do
    cr ." Tack: " i .
    i tack! 
    griscalibration @ samplegris
    puffermaximum
    dup ."  Maximum: " .
    dup calibrationamplitude @ >= if calibrationamplitude ! i calibrationtack ! else drop then    
  loop
  cr
  calibrationtack @ tack!
  ." Current Tack: " tack@ $FFFF and u. cr
;


: capture ( -- ) \ Capture Loran-C Signal
  cr
  offsetmeasurement
  offset@ ." # Offset: " . cr
  griscapture @ samplegris
  ." # Absolute Maximum: " puffermaximum . cr
  ." # GRI: " gri@ . cr
;

\ -----------------------------------------------------------------------------
\ -----------------------------------------------------------------------------

\ Convolution filter for Loran-C pulse prototype

  \ Tools to generate a convolution filter out of a list of filter points.
  \ Final filters have this stack effect: ( sample# -- intensity )

-1 variable previousfilterpoint

: filterdesign-start ( -- ) \ With name for fresh filter
  (create)
  -1 previousfilterpoint ! \ This never happens with 16 bit coefficients.
  postpone sample>address
  $2000 h, \ movs r0, #0  Clear result low
  $2100 h, \ movs r1, #0  Clear result high
;

: filterpoint ( sample coefficient -- )

  ?dup if \ Only generate code for coefficients <> 0
    swap 

    \ Generate code to fetch sample into r2 first:
    dup 32 u< 
    if   \ Short ldrh r2, [r6, #...] Opcode
      6 lshift $8832 or h,
    else \ Long  ldrh r2, [r6, #...] Opcode
      shl $F8B62000 or ><,
    then

    \ Generate code to put coefficient into r3:
    $FFFF and \ 16 Bit coefficients
    dup previousfilterpoint @ <>
    if \ Coefficient is different from the one before.
      dup previousfilterpoint !
      3 registerliteral,
    else drop then

    \ Generate smlalbb r0, r1, r2, r3 Opcode
    $FBC20183 ><,

  else drop then
;

: filterdesign-finish ( -- )
  $0006 h, \ movs tos, r0 @ Return low part of result
  $4770 h, \ bx lr
  smudge
;


\
\ Loran-C pulse prototype coefficients generated with this Pascal snipplet:
\
\ function loranpuls(i : longint) : single;
\ const k : single = 1/65e-6;
\       f : single = 100000;
\ 
\ var t : single;
\ begin
\   if i < 0 then loranpuls := 0
\   else
\   begin
\     t := 0.000001 * i; // Sample rate 1 us.
\     loranpuls := k*k*t*t * exp (-2*(k*t-1)) * sin(2*pi*f*t);
\   end;
\ end;
\
\ puls[i] := round(886 * loranpuls(i) ); // For 1/65us pulse envelope
\


filterdesign-start pulseconvolution

0 0      filterpoint
1 1      filterpoint
2 6      filterpoint
3 12     filterpoint
4 13     filterpoint
5 0      filterpoint
6 -27    filterpoint
7 -58    filterpoint
8 -74    filterpoint
9 -56    filterpoint
10 0     filterpoint
11 79    filterpoint
12 147   filterpoint
13 167   filterpoint
14 116   filterpoint
15 0     filterpoint
16 -143  filterpoint
17 -252  filterpoint
18 -274  filterpoint
19 -183  filterpoint
20 0     filterpoint
21 210   filterpoint
22 362   filterpoint
23 384   filterpoint
24 251   filterpoint
25 0     filterpoint
26 -277  filterpoint
27 -468  filterpoint
28 -488  filterpoint
29 -314  filterpoint
30 0     filterpoint
31 337   filterpoint
32 564   filterpoint
33 581   filterpoint
34 370   filterpoint
35 0     filterpoint
36 -390  filterpoint
37 -646  filterpoint
38 -661  filterpoint
39 -417  filterpoint
40 0     filterpoint
41 434   filterpoint
42 714   filterpoint
43 726   filterpoint
44 455   filterpoint
45 0     filterpoint
46 -468  filterpoint
47 -767  filterpoint
48 -775  filterpoint
49 -484  filterpoint
50 0     filterpoint
51 493   filterpoint
52 805   filterpoint
53 810   filterpoint
54 504   filterpoint
55 0     filterpoint
56 -510  filterpoint
57 -829  filterpoint
58 -832  filterpoint
59 -516  filterpoint
60 0     filterpoint
61 519   filterpoint
62 841   filterpoint
63 842   filterpoint
64 521   filterpoint
65 0     filterpoint
66 -521  filterpoint
67 -842  filterpoint
68 -841  filterpoint
69 -519  filterpoint
70 0     filterpoint
71 517   filterpoint
72 834   filterpoint
73 831   filterpoint
74 512   filterpoint
75 0     filterpoint
76 -508  filterpoint
77 -817  filterpoint
78 -813  filterpoint
79 -500  filterpoint
80 0     filterpoint
81 494   filterpoint
82 795   filterpoint
83 790   filterpoint
84 485   filterpoint
85 0     filterpoint
86 -478  filterpoint
87 -767  filterpoint
88 -761  filterpoint
89 -467  filterpoint
90 0     filterpoint
91 459   filterpoint
92 736   filterpoint
93 729   filterpoint
94 446   filterpoint
95 0     filterpoint
96 -438  filterpoint
97 -701  filterpoint
98 -694  filterpoint
99 -424  filterpoint
100 0    filterpoint
101 415  filterpoint
102 665  filterpoint
103 657  filterpoint
104 402  filterpoint
105 0    filterpoint
106 -392 filterpoint
107 -627 filterpoint
108 -620 filterpoint
109 -378 filterpoint
110 0    filterpoint
111 369  filterpoint
112 589  filterpoint
113 582  filterpoint
114 355  filterpoint
115 0    filterpoint
116 -345 filterpoint
117 -551 filterpoint
118 -544 filterpoint
119 -331 filterpoint
120 0    filterpoint
121 322  filterpoint
122 514  filterpoint
123 506  filterpoint
124 309  filterpoint
125 0    filterpoint
126 -300 filterpoint
127 -477 filterpoint
128 -470 filterpoint
129 -286 filterpoint
130 0    filterpoint
131 278  filterpoint
132 442  filterpoint
133 435  filterpoint
134 265  filterpoint
135 0    filterpoint
136 -257 filterpoint
137 -408 filterpoint
138 -402 filterpoint
139 -244 filterpoint
140 0    filterpoint
141 236  filterpoint
142 376  filterpoint
143 370  filterpoint
144 225  filterpoint
145 0    filterpoint
146 -217 filterpoint
147 -346 filterpoint
148 -340 filterpoint
149 -206 filterpoint
150 0    filterpoint
151 199  filterpoint
152 317  filterpoint
153 311  filterpoint
154 189  filterpoint
155 0    filterpoint
156 -182 filterpoint
157 -290 filterpoint
158 -285 filterpoint
159 -173 filterpoint
160 0    filterpoint
161 167  filterpoint
162 265  filterpoint
163 260  filterpoint
164 158  filterpoint
165 0    filterpoint
166 -152 filterpoint
167 -241 filterpoint
168 -237 filterpoint
169 -144 filterpoint
170 0    filterpoint
171 138  filterpoint
172 219  filterpoint
173 215  filterpoint
174 130  filterpoint
175 0    filterpoint
176 -125 filterpoint
177 -199 filterpoint
178 -195 filterpoint
179 -118 filterpoint
180 0    filterpoint
181 114  filterpoint
182 181  filterpoint
183 177  filterpoint
184 107  filterpoint
185 0    filterpoint
186 -103 filterpoint
187 -163 filterpoint
188 -160 filterpoint
189 -97  filterpoint
190 0    filterpoint
191 93   filterpoint
192 148  filterpoint
193 145  filterpoint
194 88   filterpoint
195 0    filterpoint
196 -84  filterpoint
197 -133 filterpoint
198 -131 filterpoint
199 -79  filterpoint
200 0    filterpoint
201 76   filterpoint
202 120  filterpoint
203 118  filterpoint
204 71   filterpoint
205 0    filterpoint
206 -68  filterpoint
207 -108 filterpoint
208 -106 filterpoint
209 -64  filterpoint
210 0    filterpoint
211 61   filterpoint
212 97   filterpoint
213 95   filterpoint
214 58   filterpoint
215 0    filterpoint
216 -55  filterpoint
217 -87  filterpoint
218 -86  filterpoint
219 -52  filterpoint
220 0    filterpoint
221 50   filterpoint
222 78   filterpoint
223 77   filterpoint
224 46   filterpoint
225 0    filterpoint
226 -44  filterpoint
227 -70  filterpoint
228 -69  filterpoint
229 -42  filterpoint
230 0    filterpoint
231 40   filterpoint
232 63   filterpoint
233 62   filterpoint
234 37   filterpoint
235 0    filterpoint
236 -36  filterpoint
237 -56  filterpoint
238 -55  filterpoint
239 -33  filterpoint
240 0    filterpoint
241 32   filterpoint
242 50   filterpoint
243 49   filterpoint
244 30   filterpoint
245 0    filterpoint
246 -28  filterpoint
247 -45  filterpoint
248 -44  filterpoint
249 -27  filterpoint
250 0    filterpoint
251 25   filterpoint
252 40   filterpoint
253 39   filterpoint
254 24   filterpoint
255 0    filterpoint
256 -23  filterpoint
257 -36  filterpoint
258 -35  filterpoint
259 -21  filterpoint
260 0    filterpoint
261 20   filterpoint
262 32   filterpoint
263 31   filterpoint
264 19   filterpoint
265 0    filterpoint
266 -18  filterpoint
267 -28  filterpoint
268 -28  filterpoint
269 -17  filterpoint
270 0    filterpoint
271 16   filterpoint
272 25   filterpoint
273 25   filterpoint
274 15   filterpoint
275 0    filterpoint
276 -14  filterpoint
277 -22  filterpoint
278 -22  filterpoint
279 -13  filterpoint
280 0    filterpoint
281 13   filterpoint
282 20   filterpoint
283 20   filterpoint
284 12   filterpoint
285 0    filterpoint
286 -11  filterpoint
287 -18  filterpoint
288 -17  filterpoint
289 -10  filterpoint
290 0    filterpoint
291 10   filterpoint
292 16   filterpoint
293 15   filterpoint
294 9    filterpoint
295 0    filterpoint
296 -9   filterpoint
297 -14  filterpoint
298 -14  filterpoint
299 -8   filterpoint
300 0    filterpoint
301 8    filterpoint
302 12   filterpoint
303 12   filterpoint
304 7    filterpoint
305 0    filterpoint
306 -7   filterpoint
307 -11  filterpoint
308 -11  filterpoint
309 -6   filterpoint
310 0    filterpoint
311 6    filterpoint
312 10   filterpoint
313 9    filterpoint
314 6    filterpoint
315 0    filterpoint
316 -5   filterpoint
317 -9   filterpoint
318 -8   filterpoint
319 -5   filterpoint
320 0    filterpoint
321 5    filterpoint
322 8    filterpoint
323 7    filterpoint
324 4    filterpoint
325 0    filterpoint
326 -4   filterpoint
327 -7   filterpoint
328 -7   filterpoint
329 -4   filterpoint
330 0    filterpoint
331 4    filterpoint
332 6    filterpoint
333 6    filterpoint
334 3    filterpoint
335 0    filterpoint
336 -3   filterpoint
337 -5   filterpoint
338 -5   filterpoint
339 -3   filterpoint
340 0    filterpoint
341 3    filterpoint
342 5    filterpoint
343 5    filterpoint
344 3    filterpoint
345 0    filterpoint
346 -3   filterpoint
347 -4   filterpoint
348 -4   filterpoint
349 -2   filterpoint
350 0    filterpoint
351 2    filterpoint
352 4    filterpoint
353 4    filterpoint
354 2    filterpoint
355 0    filterpoint
356 -2   filterpoint
357 -3   filterpoint
358 -3   filterpoint
359 -2   filterpoint
360 0    filterpoint
361 2    filterpoint
362 3    filterpoint
363 3    filterpoint
364 2    filterpoint
365 0    filterpoint
366 -2   filterpoint
367 -2   filterpoint
368 -2   filterpoint
369 -1   filterpoint
370 0    filterpoint
371 1    filterpoint
372 2    filterpoint
373 2    filterpoint
374 1    filterpoint
375 0    filterpoint
376 -1   filterpoint
377 -2   filterpoint
378 -2   filterpoint
379 -1   filterpoint
380 0    filterpoint
381 1    filterpoint
382 2    filterpoint
383 2    filterpoint
384 1    filterpoint
385 0    filterpoint
386 -1   filterpoint
387 -1   filterpoint
388 -1   filterpoint
389 -1   filterpoint
390 0    filterpoint
391 1    filterpoint
392 1    filterpoint
393 1    filterpoint
394 1    filterpoint
395 0    filterpoint
396 -1   filterpoint
397 -1   filterpoint
398 -1   filterpoint
399 -1   filterpoint
400 0    filterpoint
401 1    filterpoint
402 1    filterpoint
403 1    filterpoint
404 1    filterpoint
405 0    filterpoint
406 -1   filterpoint
407 -1   filterpoint
408 -1   filterpoint
409 -1   filterpoint
410 0    filterpoint
411 0    filterpoint
412 1    filterpoint
413 1    filterpoint
414 0    filterpoint
415 0    filterpoint
416 0    filterpoint
417 -1   filterpoint
418 -1   filterpoint
419 0    filterpoint
420 0    filterpoint
421 0    filterpoint
422 1    filterpoint
423 1    filterpoint
424 0    filterpoint
425 0    filterpoint
426 0    filterpoint
427 -1   filterpoint
428 -1   filterpoint

\ Sum of coefficients: -1 Sum of absolute coefficients: 65473 Number of coefficients <> 0: 336

filterdesign-finish

\ -----------------------------------------------------------------------------
\ -----------------------------------------------------------------------------

\ Signal processing tools


\ Signal processing for buffered Loran-C samples
\ This includes all the logic for a navigation receiver
\  - Signal quality report
\  - Convolution with pulse share filter
\  - Quest for Master and Slave pulse trains
\  - Calculation of Time Delays

\ -----------------------------------------------------------------------------
\  Calculate ADC voltages
\ -----------------------------------------------------------------------------

3,0 2variable vcc \ You can adjust value on the fly

: voltage. ( u -- )
  0 swap vcc 2@ 4096,0 f/ f*  4 f.n ." V "
;

: adc+voltage. ( u -- )
  dup . ." = " voltage.
;

\ -----------------------------------------------------------------------------
\  Get signal quality estimations
\ -----------------------------------------------------------------------------

: offset-double ( -- Offset )  
  0. gri@ 0 do i getsample s>d d+ loop \ Calculate offset with double intermediate result
  gri@ 0 d/ drop
;

: signedmax ( -- n ) \ Search for maximum value in buffer
  0 getsample
  gri@ 1 do i getsample max loop
;

: signedmin ( -- n ) \ Search for minimum value in buffer
  0 getsample
  gri@ 1 do i getsample min loop
;

0 variable noiseoffset

: noiselevel ( -- amplitude )
  \ Sum absolute differences to offset with double intermediate result
  0. gri@ 0 do i getsample noiseoffset @ - abs 0 d+ loop
  gri@ 0 d/ drop
;

: signalquality ( -- ) \ Prints current signal specifications
  offset-double dup noiseoffset ! 
  ." Offset " dup . ." ADC: " latestgris @ /  offset@ + voltage. cr
  noiselevel ." Noise amplitude " dup . ." ADC: " latestgris @ / voltage. cr
  signedmin ." Miminum value " dup . ." ADC: " latestgris @ / offset@ +  voltage. cr
  signedmax ." Maximum value " dup . ." ADC: " latestgris @ / offset@ +  voltage. cr
;

\ -----------------------------------------------------------------------------
\  Convolve the buffer contents with Loran-C pulse shape
\ -----------------------------------------------------------------------------

: offsetcorrection ( -- )
  \ Offset correction necessary because absolute values of negative and positive amplitudes will be compared later
  offset-double negate noiseoffset ! 
  gri@ 0 do noiseoffset @ i sample>address h+! loop
;

: convolution ( -- )
  \ led-blue portd-set h!
  offsetcorrection
  0 sample>address  gri@ sample>address  450 2* move    \ Copy the first samples at the end of the buffer for convolution to wrap over
  gri@ 0 do i pulseconvolution 16 rshift i sample>address h! loop  \ Apply convolution on whole buffer.
  \ led-blue portd-reset h!
;

\ -----------------------------------------------------------------------------
\  Find pulse trains and calculate TDs
\ -----------------------------------------------------------------------------

: wrap-sample>address ( sample# -- address )
  dup gri@ u>= if gri@ - then
  sample>address
;

: getmastertrain ( sample -- value ) \ Pulse Polarity: + - + +
  >r
  r@             sample>address h@ sign16
  r@ 2000 + wrap-sample>address h@ sign16 -
  r@ 4000 + wrap-sample>address h@ sign16 +
  r> 6000 + wrap-sample>address h@ sign16 +
  abs
;

: getslavetrain ( sample -- value ) \ Pulse Polarity: + + + -
  >r
  r@             sample>address h@ sign16
  r@ 2000 + wrap-sample>address h@ sign16 +
  r@ 4000 + wrap-sample>address h@ sign16 +
  r> 6000 + wrap-sample>address h@ sign16 -
  abs
;

: inside ( x low high -- flag ) over - >r - r>  u<= ;

: notinenvironment ( x location -- flag )
  \ Different pulse trains are at least 9900 us apart.
  \ Convolution envelope needs a "blanking out" of at least 6500 us
  \ in both directions. 7000 us seem to be a good value.

  dup ( x location location )
  7000 - dup 0< if gri@ + then \ Prepare lower limit
  ( x location low )
  swap
  ( x low location )
  7000 + dup gri@ >= if gri@ - then \ Prepare upper limit
  ( x low high )
  inside not
;

3 variable stations  \ 3 stations M, X, Y as for Sylt chain. 
                     \ Change to 4 for Lessay chain which has M, X, Y, Z.

0     variable location1
0     variable amplitude1
false variable type1

0     variable location2
0     variable amplitude2
false variable type2

0     variable location3
0     variable amplitude3
false variable type3

0     variable location4
0     variable amplitude4
false variable type4


: findpulsetrains ( -- )

  \ -----------------------------------------------------------------------------
  \ Search for most intense pulse train

  0 location1 !  0 amplitude1 !
  gri@ 0 do
    i getmastertrain i getslavetrain umax
    dup amplitude1 @ u> if i location1 ! amplitude1 ! else drop then
  loop

  \ Check type of most intense pulse train
  location1 @ getmastertrain
  location1 @ getslavetrain u>= 
  dup type1 ! \ True for Master pulse chain
  if ." Master " else ." Slave  " then ." pulse train at " location1 @ u. ." us with intensity " amplitude1 @ u. ." found." cr

  \ -----------------------------------------------------------------------------
  \ Search for second most intense pulse train
  0 location2 !  0 amplitude2 !
  gri@ 0 do
    i location1 @ notinenvironment
    if
      i getmastertrain i getslavetrain umax
      dup amplitude2 @ u> if i location2 ! amplitude2 ! else drop then
    then
  loop
  
  \ Check type of second most intense pulse train
  location2 @ getmastertrain
  location2 @ getslavetrain u>= 
  dup type2 ! \ True for Master pulse chain
  if ." Master " else ." Slave  " then ." pulse train at " location2 @ u. ." us with intensity " amplitude2 @ u. ." found." cr

  stations @ 2 <= if exit then \ Save calculation time if three stations are available only

  \ -----------------------------------------------------------------------------
  \ Search for third most intense pulse train

  0 location3 !  0 amplitude3 !
  gri@ 0 do
    i location1 @ notinenvironment
    i location2 @ notinenvironment and
    if
      i getmastertrain i getslavetrain umax
      dup amplitude3 @ u> if i location3 ! amplitude3 ! else drop then
    then
  loop
  
  \ Check type of second most intense pulse train
  location3 @ getmastertrain
  location3 @ getslavetrain u>= 
  dup type3 ! \ True for Master pulse chain
  if ." Master " else ." Slave  " then ." pulse train at " location3 @ u. ." us with intensity " amplitude3 @ u. ." found." cr

  stations @ 3 <= if exit then \ Save calculation time if three stations are available only

  \ -----------------------------------------------------------------------------
  \ Search for fourth most intense pulse train

  0 location4 !  0 amplitude4 !
  gri@ 0 do
    i location1 @ notinenvironment
    i location2 @ notinenvironment and
    i location3 @ notinenvironment and
    if
      i getmastertrain i getslavetrain umax
      dup amplitude4 @ u> if i location4 ! amplitude4 ! else drop then
    then
  loop
  
  \ Check type of second most intense pulse train
  location4 @ getmastertrain
  location4 @ getslavetrain u>= 
  dup type4 ! \ True for Master pulse chain
  if ." Master " else ." Slave  " then ." pulse train at " location4 @ u. ." us with intensity " amplitude4 @ u. ." found." cr

; \ -----------------------------------------------------------------------------

: timedelay ( master slave -- td ) \ Calculate delay with GRI wrap over

  2dup <= if swap - else gri@ + swap - then

  \    if a <= b then distance := b - a
  \              else distance := gri - a + b;
;

: calculatetds ( -- ) \ Calculate Time Delays with given pulse trains.
  ." TDs: "           \ They are given in pulse decreasing train intensity order.

  type1 @ if           location1 @ location2 @ timedelay u.
    stations @ 3 >= if location1 @ location3 @ timedelay u. then
    stations @ 4 >= if location1 @ location4 @ timedelay u. then
    cr
  then

  type2 @ if           location2 @ location1 @ timedelay u.
    stations @ 3 >= if location2 @ location3 @ timedelay u. then
    stations @ 4 >= if location2 @ location4 @ timedelay u. then
    cr
  then

  stations @ 2 <= if exit then

  type3 @ if           location3 @ location1 @ timedelay u.
                       location3 @ location2 @ timedelay u.
    stations @ 4 >= if location3 @ location4 @ timedelay u. then
    cr
  then

  stations @ 3 <= if exit then

  type4 @ if           location4 @ location1 @ timedelay u.
                       location4 @ location2 @ timedelay u.
                       location4 @ location3 @ timedelay u.
    cr
  then
;

\ -----------------------------------------------------------------------------
\  Finally: Where am I ? One complete measurement.
\  Frequency calibration has to be done before running this.
\ -----------------------------------------------------------------------------

: capture-advanced ( -- )
  offsetmeasurement
  offset@ ." Analog DC offset: " adc+voltage. cr
  griscapture @ samplegris
  signalquality
;

: locate ( -- )
  \ Switch off interrupt handler during calculations for speed
  \ No need to keep in sync meanwhile
  dint
  convolution
  findpulsetrains
  calculatetds
  eint
;

: l ( -- )
  capture-advanced
  locate
;


\ -----------------------------------------------------------------------------
\ -----------------------------------------------------------------------------

\ Convolution based fine frequency tuning

\ This calibration algorithm is faster than calfreq
\ and runs with much smaller signal to noise ratios.
\ It depends on an already coarsely pre-calibrated frequency.

\ -----------------------------------------------------------------------------
\ A quick run to find the strongest pulse train location only
\ -----------------------------------------------------------------------------

0 variable location-max
0 variable amplitude-max
0 variable calibration-location

: findstrongestpulsetrain ( -- location )

  convolution \ Do this with enabled interrupts to keep in sync with signal !

  0 location-max !  0 amplitude-max !
  gri@ 0 do
    i getmastertrain i getslavetrain umax
    dup amplitude-max @ u>= if i location-max ! amplitude-max ! else drop then
  loop

  location-max @
    dup calibration-location !
;

\ Search within 1500 us of old capture to not mix up different pulse trains

: insearchrange ( x location -- flag )
  dup ( x location location )
  1500 - dup 0< if gri@ + then \ Prepare lower limit
  ( x location low )
  swap
  ( x low location )
  1500 + dup gri@ >= if gri@ - then \ Prepare upper limit
  ( x low high )
  inside
;

: findagain-strongestpulsetrain ( -- location )

  convolution

  calibration-location @ location-max !  0 amplitude-max !
  gri@ 0 do
    i calibration-location @ insearchrange
    if 
      i getmastertrain i getslavetrain umax
      dup amplitude-max @ u>= if i location-max ! amplitude-max ! else drop then
    then
  loop

  location-max @
;

\ -----------------------------------------------------------------------------
\ A small 32 Bit stopwatch running at system clock
\ -----------------------------------------------------------------------------

$400FE604 constant RCGCTIMER

$40030000 constant GPTM0_CFG   \ GPTM Configuration
$40030004 constant GPTM0_TAMR  \ GPTM Timer A Mode
$4003000C constant GPTM0_CTL   \ GPTM Control
$40030028 constant GPTM0_TAILR \ GPTM Timer A Interval Load
$40030028 constant GPTM0_TAPR  \ GPTM Timer A Prescaler
$40030050 constant GPTM0_TAV   \ GPTM Timer A Value


: init-counting ( -- ) \ Prepare Timer 0 for stop watch function
  1 RCGCTIMER ! \ Enable Clock for Timer 0
  100 0 do loop    \ Wait a bit
;

: start-clock ( -- )
       0 GPTM0_CTL ! \ Stop Timer
       0 GPTM0_CFG !  \ 32-Bit-Timer Mode
  %10010 GPTM0_TAMR !  \ Counting up, periodic mode
       0 GPTM0_TAV !    \ Clear start value
      -1 GPTM0_TAILR !   \ Maximum possible overflow value       
       1 GPTM0_CTL !      \ Start Timer
;

: read-clock ( -- elapsedcycles )
  GPTM0_TAV @   \ Fetch elapsed time
;

: stop-clock ( -- d-elapsedcycles )
  0 GPTM0_CTL ! \ Stop Timer
  GPTM0_TAV @   \ Fetch elapsed time
; 

\ -----------------------------------------------------------------------------
\ Frequency calculation helpers
\ -----------------------------------------------------------------------------

: s>f ( n -- f ) 0 swap ; \ Single to Fixpoint conversion

: getsignedtack ( -- n ) \ Fetch current tack with sign for frequency calculations
  irq-systick @
  case
    [']  fast-crystal-handler of tack@ $FFFF and        endof
    ['] exact-crystal-handler of 0                      endof
    [']  slow-crystal-handler of tack@ $FFFF and negate endof
  endcase
;

: readkhz ( -- f ) \ Determine which frequency for crystal is currently in use.
  1000,
  getsignedtack if 1000, 120, getsignedtack s>f f* f/ d+ then
;

: shift-in-time-to-frequency-offset ( u-elapsedcycles n-timedifference -- f-frequencyoffset )

  s>f ( u-elapsed f-timedifference )
  \  ." Time difference in samples: " 2dup f.
  120,0 1000,0 f*   f*  \ To get elapsed time in microseconds for 120 MHz timer frequency

  rot ( f-timedifference u-elapsedcycles )
  s>f ( f-timedifference f-elapsedcycles )
  f/

  \ timedifference is measured with tacked f, elapsedcycles is measured with plain q.
  \ To be mathematically correct, a tack-correction should be applied, 
  \ but in practise, its effect is less than 0,00001 khz, so it can be omitted.
;

: timeshift ( location-old location-new -- n-timeshift ) \ Gives the signed time shift between two locations in buffer.
  2dup - abs  gri@ 2/ u<=  \ If distance is less then GRI/2, a wrap-over is unlikely to have happened.
  if
    swap -
  else
    2dup > if swap - gri@ +
           else    - gri@ + negate then
  then
;

13000000 variable adjustmentdelay \ Wait at least 13.000.000 us between adjustment samples for a more accurate result.

32 variable grisconvolutionadjust

: convolution-adjust ( -- ) \ Calibrate frequency by position shift of strongest pulse train
                            \ Possible with low Signal to Noise ratio, but needs a coarse frequency calibration done before.
  init-counting             \ Much faster than calfreq.
  ." Current q in use: " readkhz 5 f.n ." kHz" cr
  offsetmeasurement
  ( -- )
  grisconvolutionadjust @ samplegris             \ Do the first sample run.
  start-clock                                    \ Start a clock...
  findstrongestpulsetrain                        \ Find location of strongest pulse train in buffer
  ( location-old )                               \ This calculation needs a few seconds as interrupts eat a lot of CPU cycles meanwhile.

  begin read-clock adjustmentdelay @ 120 * u> until   \ Wait at least 13 seconds between captures ! Microseconds * 120 cycles/us in Timer.

  grisconvolutionadjust @ samplegris             \ Do the second sample run.
  stop-clock                                     \ ... Stop the clock to see how many time elapsed while doing calculations and resampling.
    dup 120 / ." Time elapsed: " . ." us" cr

  ( location-old elapsedcycles )                 \ Sampling takes exactly the same time for first and second run, so it is ok to get time after each sampling runs.
  dint findagain-strongestpulsetrain eint        \ Find out where the strongest pulse train is now. No need to keep in sync, disable interrupts.
  ( location-old elapsedcycles location-new )
  rot
  ( elapsedcycles location-new location-old )
  swap
  ( elapsedcycles location-old location-new )
  timeshift                                       \ How many microseconds shift has accumulated over the elapsed time ?
    dup ." Shift: " . ." samples" cr
  ( elapsedcycles timedifference )
  shift-in-time-to-frequency-offset               \ Calculate the actual crystal frequency on these values.
  ( f-crystalfrequency )  
  2dup ." Frequency Offset: " 5 f.n ." kHz" cr
  readkhz d+ 
  2dup ." New q in use: " 5 f.n ." kHz" cr
  khz                                             \ Set freshly calculated "exact untacked crystal frequency" into tack corrections.
;

: cold-ca ( -- )
  grisconvolutionadjust @ 
    4 grisconvolutionadjust ! 
    convolution-adjust 
  grisconvolutionadjust !
;

: ca ( -- ) convolution-adjust ;

: measure-convolution ( -- )
  cr
  cold-ca
  begin
    convolution-adjust
    capture-advanced
    locate
    cr
  key? until
;

\ -----------------------------------------------------------------------------
\ -----------------------------------------------------------------------------

compiletoram \ Finished ! Have fun !
