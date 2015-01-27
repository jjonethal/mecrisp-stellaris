
\ ----------------------------
\  Interrupt controller tools
\ ----------------------------

$E000E100 constant en0 ( Interrupt Set Enable  0-31  )
$E000E104 constant en1 ( Interrupt Set Enable 32-63  )
$E000E108 constant en2 ( Interrupt Set Enable 64-95  )
$E000E10C constant en3 ( Interrupt Set Enable 96-127 )

$E000E180 constant dis0 ( Interrupt Clear Enable  0-31  )
$E000E184 constant dis1 ( Interrupt Clear Enable 32-63  )
$E000E188 constant dis2 ( Interrupt Clear Enable 64-95  )
$E000E18C constant dis3 ( Interrupt Clear Enable 96-127 )

: nvic-enable ( irq# -- )
  16 - \ Cortex Core Vectors
  dup 32 u< if      1 swap lshift en0 ! exit then
  dup 64 u< if 32 - 1 swap lshift en1 ! exit then
  dup 96 u< if 64 - 1 swap lshift en2 ! exit then
               96 - 1 swap lshift en3 !
;

: nvic-disable ( irq# -- )
  16 - \ Cortex Core Vectors
  dup 32 u< if      1 swap lshift dis0 ! exit then
  dup 64 u< if 32 - 1 swap lshift dis1 ! exit then
  dup 96 u< if 64 - 1 swap lshift dis2 ! exit then
               96 - 1 swap lshift dis3 !
;
 
: nvic-priority ( priority irq# -- )
  $E000E400 + c!
;
