: init
  fullspeed
  delay-init
  led-init
  ['] .fault irq-fault !
  ['] uart0e-isr irq-uart0e !
  uart0e-eint
\  ['] prompt hook-quit !
  ." Running at 96MHz" CR 
  cr
  Buddha
  cr
  ." An idea that is developed and put into action is more important"
  CR ." than an idea that exists only as an idea. " CR
;

