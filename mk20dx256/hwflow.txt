\ This file has forth words for hardware flow control
\ These are now not needed as the mecrisp-stellaris-mk20dx256 core
\ is compiled with RTS initialized bny default. CTS is not enabled by
\ default so that users without hardware flow control can still use
\ the system

 
\ Two available options for configutring CTS/RTS pins on Teensy 3.1
\ This file sets up CTS/RTS on PTB2 / PTB3
\ |--------------+-------------+-----------------------+-------------------|
\ | K20 Pin Name | Teensy Name | Flow control Function | ALT Configuration |
\ |--------------+-------------+-----------------------+-------------------|
\ | PTB2         | IO 19 / A5  | RTS                   | Alt 3             |
\ | PTB3         | IO 18 / A4  | CTS                   | Alt 3             |
\ | PTD4         | IO 6        | RTS                   | Alt 3             |
\ | PTD5         | IO 20 / A6  | CTS                   | Alt3              |
\ |--------------+-------------+-----------------------+-------------------|


$4004A000 constant PORTB_PCR
$4006A015 constant UART0_RWFIFO

: ctsrts-pin-init ( -- ) \ Note: this is now done in the mecrisp core
  $0300  2 4 * PORTB_PCR + ! \ Port B GPIO (Alternative 3)
  $0300  3 4 * PORTB_PCR + ! \ Port B GPIO (Alternative 3)
;


: cts-enable   %1 uart0_modem cbis! ; 
: rts-enable %1000 uart0_modem cbis! ; \ Note:  this is now done mecrisp core

\ UART0_MODEM
\ Bit #3 RXRTSE
\ Receiver request-to-send enable
\ Allows the RTS output to control the CTS input of the transmitting device to prevent receiver overrun.
\ NOTE: Do not set both RXRTSE and TXRTSE.
\ 0 The receiver has no effect on RTS.
\ 1 RTS is deasserted if the number of characters in the receiver data register (FIFO) is equal to or greater than RWFIFO[RXWATER]. RTS is asserted when the number of characters in the receiver data register (FIFO) is less than RWFIFO[RXWATER].
	  

\ |--------+-----+----------------------------------------------------------------|
\ | Signal | I/O | Description                                                    |
\ |--------+-----+----------------------------------------------------------------|
\ | CTS    | I   | Clear to send. Indicates whether the UART can start            |
\ |        |     | transmitting data when flow control is enabled.                |
\ |        |     | State meaning                                                  |
\ |        |     | -- Asserted:Data transmission can start.                       |
\ |        |     | -- Negated—Data transmission cannot start.                     |
\ |        |     | Timing                                                         |
\ |        |     | -- Assertion—When transmitting device's RTS asserts.           |
\ |        |     | -- Negation—When transmitting device's RTS deasserts.          |
\ |--------+-----+----------------------------------------------------------------|
\ | RTS    | O   | Request to send. When driven by the receiver, indicates        |
\ |        |     | whether the UART is ready to receive data. When driven         |
\ |        |     | by the transmitter, can enable an external transceiver         |
\ |        |     | during transmission.                                           |
\ |        |     | State Meaning                                                  |
\ |        |     | -- Asserted — When driven by the receiver, ready to            |
\ |        |     | receive data. When driven by the transmitter, enable           |
\ |        |     | the external transmitter.                                      |
\ |        |     | -- Negated—When driven by the receiver, not ready to           |
\ |        |     | receive data. When driven by the transmitter, disable          |
\ |        |     | the external transmitter.                                      |
\ |        |     | Timing                                                         |
\ |        |     | -- Assertion—Can occur at any time; can assert asynchronously  |
\ |        |     | to the other input signals.                                    |
\ |        |     | -- Negation—Can occur at any time; can deassert asynchronously |
\ |        |     | to the other input signals.                                    |
\ |--------+-----+----------------------------------------------------------------|

 
