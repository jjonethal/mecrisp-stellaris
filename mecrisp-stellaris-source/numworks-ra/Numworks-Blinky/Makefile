
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : numworks-blinky.bin 

numworks-blinky.o : numworks-blinky.s
	$(ARMGNU)-as numworks-blinky.s -o numworks-blinky.o

numworks-blinky.bin : memmap numworks-blinky.o
	$(ARMGNU)-ld -o numworks-blinky.elf -T memmap numworks-blinky.o
	$(ARMGNU)-objdump -D numworks-blinky.elf > numworks-blinky.list
	$(ARMGNU)-objcopy numworks-blinky.elf numworks-blinky.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
