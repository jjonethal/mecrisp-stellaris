\ GPIOTE PWM example
\ blinky.txt must be loaded first

\ Timer
$40008000 constant nrf_timer0_base
$40009000 constant nrf_timer1_base
$4000A000 constant nrf_timer2_base
$4001F000 constant nrf_ppi_base
$40006000 constant nrf_gpiote_base

\ Timer structure
$0 constant tmr_tasks_start
$4 constant tmr_tasks_stop
$8 constant tmr_tasks_count
$c constant tmr_tasks_clear
$10 constant tmr_tasks_shutdown
$40 constant tmr_tasks_capture
$140 constant tmr_events_compare
$200 constant tmr_shorts
$304 constant tmr_intenset
$308 constant tmr_intenclr
$504 constant tmr_mode
$508 constant tmr_bitmode
$510 constant tmr_prescaler
$540 constant tmr_cc

$504 constant ppi_chenset
$510 constant ppi_ch0.eep
$514 constant ppi_ch0.tep

$0 constant gpiote_tasks_out
$510 constant gpiote_config

0 constant bitmode16
1 constant bitmode08
2 constant bitmode24
3 constant bitmode32

0 constant mode_timer
1 constant mode_counter

0 constant gpiote_config_mode_disabled
1 constant gpiote_config_mode_event
3 constant gpiote_config_mode_task
0 constant gpiote_config_polarity_None
1 constant gpiote_config_polarity_LoToHi
2 constant gpiote_config_polarity_HiToLo
3 constant gpiote_config_polarity_Toggle
0 constant gpiote_config_outinit_low
1 constant gpiote_config_outinit_high

1 constant tmr_shorts_compare_clear

0 constant pwm_gpiote_channel1
1 constant pwm_gpiote_channel2
0 constant pwm_ppi_channel_set1
1 constant pwm_ppi_channel_set2
2 constant pwm_ppi_channel_clr1
3 constant pwm_ppi_channel_clr2
16 constant  GPIOTE_CONFIG_POLARITY_Pos
0 constant  GPIOTE_CONFIG_MODE_Pos 
8 constant  GPIOTE_CONFIG_PSEL_Pos
20 constant GPIOTE_CONFIG_OUTINIT_Pos
0 constant PPI_CHEN_CH0_Pos
1 constant  PPI_CHEN_CH0_Enabled
$500 constant ppi_chen
0 constant TIMER_SHORTS_COMPARE0_CLEAR_Pos
1 constant TIMER_SHORTS_COMPARE1_CLEAR_Pos
2 constant TIMER_SHORTS_COMPARE2_CLEAR_Pos
3 constant TIMER_SHORTS_COMPARE3_CLEAR_Pos
19 constant TIMER_INTENSET_COMPARE3_Pos
$E000E100 constant NVIC_ISER0
1500 variable speed_motor1
1500 variable speed_motor2

: gpiote_init ( gpiote_channel gpio_gpiote_config_polarity output_pin_number -- )
\ Configure GPIOTE channel GPIOTE_CHANNEL_NUMBER to toggle the GPIO  pin state with input
\ Note that we can only connect a GPIOTE task to an output pin
  gpiote_config_mode_task GPIOTE_CONFIG_MODE_Pos lshift
  swap GPIOTE_CONFIG_PSEL_Pos lshift or \ gpio_output_pin_number
  swap GPIOTE_CONFIG_POLARITY_Pos lshift or \ gpiote_config_polarity
  gpiote_config_outinit_low GPIOTE_CONFIG_OUTINIT_Pos lshift or
   over cells nrf_gpiote_base + gpiote_config + ! \ gpiote_channel 
  \ Three NOPs are required to make sure configuration is written before setting tasks or getting events
  nop nop nop
  \ Launch the task to take the GPIOTE channel output to the desired level
  cells nrf_gpiote_base + gpiote_tasks_out + 1 swap !  \ gpiote_channel
;

: ppi_init ( gpiote_channel ppi_channel timer_ccnum -- )
  \ Configure PPI channel 0 to toggle GPIO_OUTPUT_PIN on every TIMER0 COMPARE[0] match, which is every 200 ms
   cells nrf_timer0_base + tmr_events_compare + \ timer_ccnum
   over 2 * cells nrf_ppi_base + ppi_ch0.eep + ! \ ppi_channel
   swap  cells nrf_gpiote_base + gpiote_tasks_out + \ gpiote_channel
   over 2 * cells nrf_ppi_base + ppi_ch0.tep + ! \ ppi_channel

  \ Enable PPI channel
  PPI_CHEN_CH0_Enabled swap lshift
  nrf_ppi_base ppi_chen + @ or
  nrf_ppi_base ppi_chen + !
;

: timer0_setcc ( milli cc -- )
  cells tmr_cc + nrf_timer0_base + !
;

: timer0_init ( -- )
  \ Clear TIMER0
  1 nrf_timer0_base tmr_tasks_clear + !
  \ Configure TIMER0 for compare[0] event every 200ms
  4 nrf_timer0_base tmr_prescaler + !
  \ 1 tick == 1 microsecond, multiply by 1000 to get number in milliseconds
  20000 0 timer0_setcc \ compare0 on, Timer clear
  1500 1 timer0_setcc \ compare1 off Motor 1
  1500 2 timer0_setcc \ compare2 off Motor 2
  10000 3 timer0_setcc \ Interrupt to change duty cycle, must be outside duty cycle
  mode_timer nrf_timer0_base tmr_mode + !
  bitmode16 nrf_timer0_base tmr_bitmode + !
  tmr_shorts_compare_clear TIMER_SHORTS_COMPARE0_CLEAR_Pos lshift nrf_timer0_base tmr_shorts + !
  1 TIMER_INTENSET_COMPARE3_Pos lshift nrf_timer0_base tmr_intenset + ! \ enable interrupt on compare 3
;

: set_duty_cycle
 \ clear compare 3 event
 0 nrf_timer0_base tmr_events_compare + 3 cells + !
 speed_motor1 @ 1 timer0_setcc
 speed_motor2 @ 2 timer0_setcc
;

 
: init-motors ( gpio_motor2 gpio_motor1 -- )
 \ configure motor1 pin as output
  dup cells gpio_cnf + $301 swap !
  pwm_gpiote_channel1 gpiote_config_polarity_Toggle rot
  gpiote_init \                  // Configure a GPIO to toggle on a GPIOTE task,
  pwm_gpiote_channel1 pwm_ppi_channel_set1 0
  ppi_init \                    // and using a PPI channel to connect the event to the task automatically;
  pwm_gpiote_channel1 pwm_ppi_channel_clr1 1
  ppi_init \                    // and using a PPI channel to connect the event to the task automatically;
 \ configure motor2 pin as output
  dup cells gpio_cnf + $301 swap !
  pwm_gpiote_channel2 gpiote_config_polarity_Toggle rot
  gpiote_init \                  // Configure a GPIO to toggle on a GPIOTE task,
  pwm_gpiote_channel2 pwm_ppi_channel_set2 0
  ppi_init \                    // and using a PPI channel to connect the event to the task automatically;
  pwm_gpiote_channel2 pwm_ppi_channel_clr2 2
  ppi_init \                    // and using a PPI channel to connect the event to the task automatically;
  timer0_init \                  // using TIMER0 to generate events every 200 ms

  \ after starting the event generation
  1 nrf_timer0_base tmr_tasks_start + ! 
  \ set interrupt vector
   ['] set_duty_cycle irq-tim0 !
  \ enable timer0 interrupt
  1 8 lshift NVIC_ISER0 bis!
;

: motor-demo ( -- )
 2 1 init-motors
 500 speed_motor1 !
 begin
   speed_motor1 @  1+ dup speed_motor1 !
   dup .
 2500 > until
 1500 speed_motor1 !
  500 speed_motor2 !
 begin
   speed_motor2 @  1+ dup speed_motor2 !
   dup .
 2500 > until
 1500 speed_motor2 !
;
