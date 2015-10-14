\ swd protocol
\ 72 Mhz
\ host send on falling edge
\ target read on rising edge
\ fe - falling edge
\ re - rising edge

: ch ; \ clock high
: cl ; \ clock low
: dh ; \ data high
: dl ; \ data low

\ parity 1 even(APnDP, RnW, Addr2,Addr3)
: sendRead
\
ch dl    \ init         0
cl dh    \ start fe     1L
ch dh    \ start read   1H
cl APnDP \ APnDP fe     2L
ch APnDP \ APnDP re     2H
cl RnW   \ RnW   fe     3L
ch RnW   \ RnW   re     3H

