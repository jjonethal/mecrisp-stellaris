\ Words for enabling interrupts

: irq-enable-mask-offset ( IRQ -- mask offset)
   dup $1F and 1 swap lshift   	  \ calculate bitfield mask
   swap $E0 and 3 rshift	  \ Divide by 32 to figure out the register number, multiply by four bytes per reg -> 3 shift
;

: irq-enable ( IRQ -- )
  irq-enable-mask-offset
  $E000E100 + !
;

: irq-disable ( IRQ -- ) 
  irq-enable-mask-offset
  $E000E180 + !
;

: irq-trigger ( IRQ -- )
  $E000EF00 !
;
