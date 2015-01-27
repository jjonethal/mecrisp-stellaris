
\ PLL initialisation code for 80 MHz.
\ You can choose and include your favourite speed from pll-values.txt

$400FE050 constant SYSCTL_RIS_R           
$00000040 constant SYSCTL_RIS_PLLLRIS       \  PLL Lock Raw Interrupt Status
$400FE060 constant SYSCTL_RCC_R           
$000003C0 constant SYSCTL_RCC_XTAL_M        \  Crystal Value
$000002C0 constant SYSCTL_RCC_XTAL_6MHZ     \  6 MHz Crystal
$00000380 constant SYSCTL_RCC_XTAL_8MHZ     \  8 MHz Crystal
$00000540 constant SYSCTL_RCC_XTAL_16MHZ    \  16 MHz Crystal
$400FE070 constant SYSCTL_RCC2_R          
$80000000 constant SYSCTL_RCC2_USERCC2      \  Use RCC2
$40000000 constant SYSCTL_RCC2_DIV400       \  Divide PLL as 400 MHz vs. 200 MHz
$1F800000 constant SYSCTL_RCC2_SYSDIV2_M    \  System Clock Divisor 2
$00400000 constant SYSCTL_RCC2_SYSDIV2LSB   \  Additional LSB for SYSDIV2
$00002000 constant SYSCTL_RCC2_PWRDN2       \  Power-Down PLL 2
$00000800 constant SYSCTL_RCC2_BYPASS2      \  PLL Bypass 2
$00000070 constant SYSCTL_RCC2_OSCSRC2_M    \  Oscillator Source 2
$00000000 constant SYSCTL_RCC2_OSCSRC2_MO   \  MOSC

: 80MHz ( -- )

  \ 1) configure the system to use RCC2 for advanced features
  \    such as 400 MHz PLL and non-integer System Clock Divisor
    SYSCTL_RCC2_USERCC2  SYSCTL_RCC2_R  bis!

  \ 2) bypass PLL while initializing
    SYSCTL_RCC2_BYPASS2  SYSCTL_RCC2_R  bis!

  \ 3) select the crystal value and oscillator source
    SYSCTL_RCC_R @
      SYSCTL_RCC_XTAL_M      bic
      SYSCTL_RCC_XTAL_16MHZ  or
    SYSCTL_RCC_R !


    SYSCTL_RCC2_R @
      SYSCTL_RCC2_OSCSRC2_M  bic
      SYSCTL_RCC2_OSCSRC2_MO or

      \ 4) activate PLL by clearing PWRDN
      SYSCTL_RCC2_PWRDN2  bic

      \ 5) use 400 MHz PLL
      SYSCTL_RCC2_DIV400  or

      \ 6) set the desired system divider and the system divider least significant bit
      SYSCTL_RCC2_SYSDIV2_M  bic ( clear system clock divider field )
      SYSCTL_RCC2_SYSDIV2LSB bic ( clear bit SYSDIV2LSB )

      2 ( Sysdiv ) 23 lshift or ( configure SYSDIV2    field in RCC2 )
      0 ( LSB    ) 22 lshift or ( configure SYSDIV2LSB field in RCC2 )
    SYSCTL_RCC2_R !


  \  7) wait for the PLL to lock by polling PLLLRIS
    begin SYSCTL_RIS_PLLLRIS SYSCTL_RIS_R bit@ until

  \  8) enable use of PLL by clearing BYPASS
    SYSCTL_RCC2_BYPASS2 SYSCTL_RCC2_R bic!
;

