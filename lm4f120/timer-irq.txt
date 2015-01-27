
\ Timer 0A in 16-bit-Mode with Interrupt
\   needs basisdefinitions.txt

$00080000 constant NVIC_EN0_INT19          \ Interrupt 19 enable
$E000E100 constant NVIC_EN0_R              \ IRQ 0 to 31 Set Enable Register
$E000E410 constant NVIC_PRI4_R             \ IRQ 16 to 19 Priority Register

$400FE604 constant RCGCTIMER

$40030000 constant TIMER0_CFG_R          
$00000004 constant TIMER_CFG_16_BIT        \ 16-bit timer configuration,
                                           \ function is controlled by bits
                                           \ 1:0 of GPTMTAMR and GPTMTBMR
$40030004 constant TIMER0_TAMR_R         
$00000002 constant TIMER_TAMR_TAMR_PERIOD  \ Periodic Timer mode
$4003000C constant TIMER0_CTL_R          
$00000001 constant TIMER_CTL_TAEN          \ GPTM TimerA Enable
$40030018 constant TIMER0_IMR_R          
$00000001 constant TIMER_IMR_TATOIM        \ GPTM TimerA Time-Out Interrupt Mask
$40030024 constant TIMER0_ICR_R          
$00000001 constant TIMER_ICR_TATOCINT      \ GPTM TimerA Time-Out Raw Interrupt
$40030028 constant TIMER0_TAILR_R        
$0000FFFF constant TIMER_TAILR_TAILRL_M    \ GPTM TimerA Interval Load Register Low
$40030038 constant TIMER0_TAPR_R         

 
\ Activate Timer0A interrupts to run user task periodically
\        Units of period are 1 us (assuming 16 MHz clock)
\        Maximum is 2^16-1
\        Minimum is determined by length of ISR

: Timer0A_Init ( us -- )

    \ 0) activate clock for Timer0
    %1 RCGCTIMER ! \ Enable Clock for Timer 0
    50 0 do loop    \ allow time to finish activating

    \ 1) disable timer0A during setup
    TIMER_CTL_TAEN TIMER0_CTL_R bic!

    \ 2) configure for 16-bit timer mode
    TIMER_CFG_16_BIT TIMER0_CFG_R !

    \ 3) configure for periodic mode
    TIMER_TAMR_TAMR_PERIOD TIMER0_TAMR_R !

    \ 4) reload value
    1- TIMER0_TAILR_R ! ( counts down from R0 to 0 )

    \ 5) 1us timer0A
    16 1- TIMER0_TAPR_R ! ( divide clock by 16 for 1 us time base )

    \ 6) clear timer0A timeout flag
    TIMER_ICR_TATOCINT TIMER0_ICR_R !

    \ 7) arm timeout interrupt
    TIMER_IMR_TATOIM TIMER0_IMR_R !

    \ 8) set NVIC interrupt 19 to priority 2
    NVIC_PRI4_R @
      $00FFFFFF and ( clear interrupt 19 priority )
      $40000000 or  ( interrupt 19 priority is in bits 31-29 )
    NVIC_PRI4_R !

    \ 9) enable interrupt 19 in NVIC
    NVIC_EN0_INT19 NVIC_EN0_R ! ( interrupt 19 enabled )

    \ 10) enable timer0A
    TIMER_CTL_TAEN TIMER0_CTL_R bis! ( set enable bit )
;


$40030024 constant TIMER0_ICR_R       
$00000001 constant TIMER_ICR_TATOCINT    \ GPTM TimerA Time-Out Raw Interrupt

: tick
  \ ." Tick" cr
  TIMER_ICR_TATOCINT  TIMER0_ICR_R !  \ Acknowledge timer0A timeout
  2 portf_data xor! \ toggle LED
;

' tick irq-timer0a !
50000 Timer0A_Init \ 50 ms
