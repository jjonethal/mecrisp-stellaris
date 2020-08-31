
\ LED example

$40010800 constant GPIO-BASE

GPIO-BASE $00 + constant GPIO.CRL   \ reset $44444444 port Conf Register Low
GPIO-BASE $04 + constant GPIO.CRH   \ reset $44444444 port Conf Register High
GPIO-BASE $08 + constant GPIO.IDR   \ RO              Input Data Register
GPIO-BASE $0C + constant GPIO.ODR   \ reset 0         Output Data Register
GPIO-BASE $10 + constant GPIO.BSRR  \ reset 0         port Bit Set/Reset Reg
GPIO-BASE $14 + constant GPIO.BRR   \ reset 0         port Bit Reset Register

: io-mode! ( mode pin -- )
  4 * dup
  $F swap lshift not GPIO.CRL @ and
  -rot lshift or GPIO.CRL !
;

\ User LD2: the green LED is a user LED connected to Arduino signal D13 corresponding to
\ MCU I/O PA5 (pin 21) or PB13 (pin 34) depending on the STM32 target.
\ On the Nucleo F103RB, this is PA5.

: blinky ( -- )

  %01 5 io-mode! \ Set LED Pin mode to output

  begin
    1 5 lshift GPIO.ODR xor!
    500000 0 do loop
  key? until
;
