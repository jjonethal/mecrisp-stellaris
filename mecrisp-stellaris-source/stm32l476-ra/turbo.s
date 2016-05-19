@ Put license text here
@
@ enable 48 MHz mode for stm32L476
@ Flash - 2 wait states
@         prefetch enable
@ Vcore - voltage scale mode 1 - 1.2V
@ Clock - Set MSI range in RCC_CR to 11 - 48 MHz
@         switch MSI range config to RCC_CR

@ flash definitions 
  .equ FLASH_BASE        , 0x40022000
  .equ FLASH_ACR         , FLASH_ACR   + 0x00
  .equ FLASH_ACR_LATENCY , 0x07                @ flash waitstates

@ rcc registers
  .equ RCC_BASE          , 0x40021000
  .equ RCC_CR            , RCC_BASE    + 0x00
  .equ RCC_CR_MSION      ,    1 << 0
  .equ RCC_CR_MSIRDY     ,    1 << 1
  .equ RCC_CR_MSIPLLEN   ,    1 << 2
  .equ RCC_CR_MSIRGSEL   ,    1 << 3
  .equ RCC_CR_MSIRANGE   , 0x0f << 4

@ power management
  .equ PWR_BASE          , 0x40007000
  .equ PWR_CR1           , PWR_BASE    + 0x00
  .equ PWR_SR2           , PWR_BASE    + 0x14
  .equ PWR_CR1_VOS       , 3 << 9
  .equ PWR_SR2_VOSF      , 1 << 10


@ -----------------------------------------------------------------------------
clk_48mhz_msi:  @ set system clock to 48 mhz msi
@ -----------------------------------------------------------------------------
    ldr r0, =PWR_CR1         @ setup volage scale mode 1
    ldr r1, [r0]
    bic r1, #PWR_CR1_VOS     @ mask out voltage scale mode
    orr r1, #1 << 9          @ select voltage scale mode 1 (1.2V) for high speed op > 26 MHz
    str r1, [r0]

    ldr r0, =PWR_SR2         @ VOSF check
1:  ldr r1, [r0]             @ wait until voltage stable
    ands r1, #PWR_SR2_VOSF   @ voltage scale pending
    bne 1b

    @ adjust flash latency, enable prefetch
    ldr r0, =FLASH_ACR
    ldr r1, [r0]             @ load current settings
    bic r1, #FLASH_ACR_LATENCY
    orr r1, #2 | 1 << 8      @ 2 wait states for 48 MHz + prefetch enable
    str r1, [r0]             @ store new settings

    ldr r0, =RCC_CR          @ set new msi clock mode 
    ldr r1, [r0]             @ load current settings
    bic r1, #RCC_CR_MSIRANGE
    orr r1, #0xB << 4        @ msi range 48 MHz
    str r1, [r0]             @ write new range
    
    orr r1, #RCC_CR_MSIRGSEL @ switch to RCC_CR_MSIRANGE
    str r1, [r0]
    bx lr
.ltorg
