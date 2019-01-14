\ sdram.fth


\ C:\Users\jeanjo\Downloads\doc\128mb_x32_sdram.pdf

:pindef 
FMC_A0          PF0       AF12
FMC_A1          PF1       AF12
FMC_A2          PF2       AF12
FMC_A3          PF3       AF12
FMC_A4          PF4       AF12
FMC_A5          PF5       AF12
FMC_A6          PF12      AF12
FMC_A7          PF13      AF12
FMC_A8          PF14      AF12
FMC_A9          PF15      AF12
FMC_A10         PG0       AF12
FMC_A11         PG1       AF12
FMC_A14_BA0     PG4       AF12
FMC_A15_BA1     PG5       AF12
FMC_D0_DA0      PD14      AF12
FMC_D1_DA1      PD15      AF12
FMC_D11_DA11    PE14      AF12
FMC_D13_DA13    PD8       AF12
FMC_D14_DA14    PD9       AF12
FMC_D15_DA15    PD10      AF12
FMC_D2_DA2      PD0       AF12
FMC_D3_DA3      PD1       AF12
FMC_D4_DA4      PE7       AF12
FMC_D5_DA5      PE8       AF12
FMC_D6_DA6      PE9       AF12
FMC_D7_DA7      PE10      AF12
FMC_D8_DA8      PE11      AF12
FMC_NBL0        PE0       AF12
FMC_NBL1        PE1       AF12
FMC_SDCKE0      PC3       AF12
FMC_SDCLK       PG8       AF12
FMC_SDNCAS      PG15      AF12
FMC_SDNE0       PH3       AF12
FMC_SDNRAS      PF11      AF12
FMC_SDNWE       PH5       AF12
pindef;

$A0000000 constant FMC_BASE
0x00  FMC_BASE + constant FMC_BCR1   
0x08  FMC_BASE + constant FMC_BCR2   
0x10  FMC_BASE + constant FMC_BCR3   
0x18  FMC_BASE + constant FMC_BCR4   
0x04  FMC_BASE + constant FMC_BTR1   
0x0C  FMC_BASE + constant FMC_BTR2   
0x14  FMC_BASE + constant FMC_BTR3   
0x1C  FMC_BASE + constant FMC_BTR4   
0x104 FMC_BASE + constant FMC_BWTR1  
0x10C FMC_BASE + constant FMC_BWTR2  
0x114 FMC_BASE + constant FMC_BWTR3  
0x11C FMC_BASE + constant FMC_BWTR4  
0x80  FMC_BASE + constant FMC_PCR    
0x84  FMC_BASE + constant FMC_SR     
0x88  FMC_BASE + constant FMC_PMEM   
0x8C  FMC_BASE + constant FMC_PATT   
0x94  FMC_BASE + constant FMC_ECCR   
0x140 FMC_BASE + constant FMC_SDCR1  
0x144 FMC_BASE + constant FMC_SDCR2  
0x148 FMC_BASE + constant FMC_SDTR1  
0x14C FMC_BASE + constant FMC_SDTR2  
0x150 FMC_BASE + constant FMC_SDCMR  
0x154 FMC_BASE + constant FMC_SDRTR  
0x158 FMC_BASE + constant FMC_SDSR   

$E000E000 constant SCS_BASE


: SCB_EnableICache DSB ISB 0 SCB->ICIALLU ! SCB_CCR_IC_Msk SCB->CCR bis!
   DSB ISB ;
   
\ ...\Downloads\stm\stm32cubef3\STM32Cube_FW_F7_V1.8.0\Drivers\CMSIS\Include\core_cm7.h:2123

5                             constant SCB_DCISW_SET_Pos
$1FF SCB_DCISW_SET_Pos lshift constant SCB_DCISW_SET_Msk

0 variable ccsidr
0 variable sets
0 variable ways

: SCB_EnableDCache 0 ! SCB->CSSELR
  DSB
  SCB->CCSIDR ccsidr !
  ccsidr CCSIDR_SETS sets !
  ccsidr CCSIDR_WAYS ways !

: hal_init ;
: CPU_CACHE_Enable ;
: SystemClock_Config ;
: BSP_LED_Init ( led -- ) ;
