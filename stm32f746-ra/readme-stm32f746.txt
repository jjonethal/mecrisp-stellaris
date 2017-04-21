Mecrisp Stellaris Forth for STM32F746NG
---------------------------------------

Terminal settings for VCP via debug USB port
Baudrate 115200
VCP_TX - PA9 USART1 AF7 USART1_TX
VCP_RX - PB7 USART1 AF7 USART1_RX

other initialization
LED_BL - PK3 
lcd background illumination turned off via PK3

Specialities
------------

Flash starts from 0x00200000 so kernel space is reserved between
0x00200000.. 0x00207FFF. Be carefull with io register programming
due to out-of-order-execution of cortex-m7. For instance flash driver
needed some sync instructions. 


Demo
----
Demo contains some LCD and drawing stuff for stm32f746NGDisco board
Currently only some snippets usefull. Usable is some color cycling and line drawing
stuff. Font support / editor is work in progress.
Current color format is 8 bit indexed for making best of limited resources.

Framebuffer is located in internal sram for now due to lack of sdram support.

Demo code need major rework. Most things implemented quick'n dirty word naming
shall be unified.

CPU is switched to 200 MHz, display clock is 9.6 MHz. Only LCD layer 1 is used
at the moment.

some demo words:
 * demo                - initialize display and 200 MHz clock
 * sys-clk-200-mhz     - set system clock to 200 MHz, usart 115200 baud
 * test-genchar        - test some character generator functions
 * circle-palette-test - do some palette cycling tests
