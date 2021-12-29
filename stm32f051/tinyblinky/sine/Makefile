# Makefile for minimal assembly Blinky, using svd2gas and running on a STM32F0 Discovery board.

ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : tinyblinky.bin

tinyblinky.o : tinyblinky.s
	$(ARMGNU)-as -mthumb -g --gstabs+ tinyblinky.s -o tinyblinky.o

tinyblinky.bin : memmap tinyblinky.o
	$(ARMGNU)-ld -Ttext 0x0 -o tinyblinky.elf -T memmap tinyblinky.o
	$(ARMGNU)-objdump -D tinyblinky.elf > tinyblinky.list
	$(ARMGNU)-objcopy tinyblinky.elf tinyblinky.bin -O binary

erase:
	st-flash erase

flash:
	st-flash write tinyblinky.bin 0x08000000

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.lst
