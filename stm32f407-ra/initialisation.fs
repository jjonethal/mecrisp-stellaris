
\ -----------------------------------------------------------------------------
\   Calltrace
\ -----------------------------------------------------------------------------

: ct ( -- )
  cr
  rdepth 0 do
    i hex. i 2+ rpick dup hex. traceinside. cr
  loop
;

: calltrace-irq ( -- ) \ Try your very best to help tracing unhandled interrupt causes...
  cr cr
  unhandled
  cr
  h.s
  cr
  ." Calltrace:" ct
  begin usb-poll again \ Trap execution
;

\ -----------------------------------------------------------------------------
\   USB Initialisation
\ -----------------------------------------------------------------------------

: singletask ( -- ) ['] usb-poll hook-pause ! ;

task: usb-task

: usb-task&
  usb-task activate
  begin
    usb-poll
    pause
  again
;

: init ( -- )
  168mhz
  init-cycles
  init-rng
  ['] calltrace-irq irq-fault !
  usb-init
  multitask usb-task&
  \ singletask
  +usb
;

cornerstone eraseflash
