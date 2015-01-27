
\ Clock setup for 25 MHz crystal and 120 MHz PLL

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
