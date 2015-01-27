\ Memory mapping of Cortex-M4 Hardware
$E000E000 constant SCS_BASE                                      \ System Control Space Base Address
$E0000000  constant  ITM_BASE					 \ ITM Base Address
$E0001000  constant   DWT_BASE					  \ DWT Base Address
$E0040000   constant   TPI_BASE					  \  TPI Base Address
$E000EDF0 constant CoreDebug_BASE				  \ Core Debug Base Address
SCS_BASE +  $0010 constant SysTick_BASE				  \ SysTick Base Address
SCS_BASE +  $0100 constant  NVIC_BASE				  \ NVIC Base Address
SCS_BASE +  $0D00 constant SCB_BASE				  \  System Control Block Base Address 

