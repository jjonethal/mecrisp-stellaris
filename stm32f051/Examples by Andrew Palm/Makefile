#--------------------------------------------------------------------------
# Makefile for loading Forth into STM32F051x8
#
#	Andrew Palm
# 2018.02.02
#--------------------------------------------------------------------------
#

FLASHSTART = 0x08000000

BIN = mecrisp-stellaris-stm32f051x8.bin

flash: 
	st-flash erase
	st-flash write $(BIN) $(FLASHSTART)

bootload:
	python2 stm32loader.py -p /dev/ttyUSB0 -evw $(BIN)

connect:
# Uncomment one of the next two lines to connect a serial terminal to the mcu
#	xfce4-terminal -e 'picocom -b 115200 /dev/ttyUSB0 --imap lfcrlf,crcrlf --omap delbs,crlf --send-cmd "ascii-xfr -s -l200"'
	xfce4-terminal -e '/opt/e4thcom-0.6.1/e4thcom-0.6.1 -b B115200 -d ttyUSB0 -t mecrisp-st'
	
