
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-xmc1100.bin 

mecrisp-stellaris-xmc1100.o : mecrisp-stellaris-xmc1100.s
	$(ARMGNU)-as mecrisp-stellaris-xmc1100.s -o mecrisp-stellaris-xmc1100.o

mecrisp-stellaris-xmc1100.bin : memmap mecrisp-stellaris-xmc1100.o
	$(ARMGNU)-ld -o mecrisp-stellaris-xmc1100.elf -T memmap mecrisp-stellaris-xmc1100.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-xmc1100.elf > mecrisp-stellaris-xmc1100.list
	$(ARMGNU)-objcopy mecrisp-stellaris-xmc1100.elf mecrisp-stellaris-xmc1100.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-xmc1100.elf mecrisp-stellaris-xmc1100.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
