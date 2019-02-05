
\ --------------------------------------------------
\  Lowpower mode
\ --------------------------------------------------

: up-alone? ( -- ? ) \ Checks if all other tasks are currently in idle state
  next-task @ \ Current task is in UP. Start with the next one.
  begin
    dup up @ <> \ Scan the whole round-robin list until back to current task.
  while
    dup 1 cells + @ if drop false exit then \ Check state of this task and exit if it is active
    @ \ Next task in list
  repeat
  drop true
;

: sleep ( -- ) [ $BF30 h, ] inline ; \ WFI Opcode, Wait For Interrupt, enters sleep mode

task: lowpower-task

: lowpower& ( -- )
  lowpower-task activate
    begin
      eint? if \ Only enter sleep mode if interrupts have been enabled
        dint up-alone? if ."  Sleep " sleep then eint
      then
      pause
    again
;

\ --------------------------------------------------
\  Examples
\ --------------------------------------------------

compiletoram eint multitask

0 variable seconds
task: timetask

: time& ( -- )
  timetask background
    begin
      key? if boot-task wake then
      1 seconds +!
      seconds @ . cr
      stop
    again
;

time& lowpower& tasks

: tick ( -- ) timetask wake ;

 ' tick irq-systick !
 16000000 $E000E014 ! \ How many ticks between interrupts ?
        7 $E000E010 ! \ Enable the systick interrupt.

stop \ Idle the boot task

 
