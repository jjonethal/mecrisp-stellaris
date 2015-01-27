
\ Interrupt on Switch 1
\   needs basisdefinitions.txt

$40025404 constant PORTF_IS  ( Interrupt Sense )
$40025408 constant PORTF_IBE ( Interrupt Both Edges )
$4002540C constant PORTF_IEV ( Interrupe Event )
$40025410 constant PORTF_IM  ( Interrupt Mask )
$40025414 constant PORTF_RIS ( Raw Interrupt Status )
$40025418 constant PORTF_MIS ( Masked Interrupt Status )
$4002541C constant PORTF_ICR ( Interrupt Clear )

$E000E100 constant en0 ( Interrupt Set Enable )
$E000E104 constant en1 ( Interrupt Set Enable )
$E000E108 constant en2 ( Interrupt Set Enable )
$E000E10C constant en3 ( Interrupt Set Enable )


: switchdown ( -- )
  $FF PORTF_ICR ! ( Clear Interrupt-Flags )
  cr ." Switch pressed" cr 
;

: init-switch ( -- )
  ['] switchdown irq-portf ! ( Set Interrupt Handler )
  knopf1 portf_im !  ( Enable Interrupt for Switch 1 Pin )
  $40000000 en0 bis! ( Enable Port F Interrupt in NVIC )
;

init-switch
