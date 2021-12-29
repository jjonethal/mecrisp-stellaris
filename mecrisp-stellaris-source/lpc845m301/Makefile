
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-lpc845m301.bin

mecrisp-stellaris-lpc845m301.o : mecrisp-stellaris-lpc845m301.s
	$(ARMGNU)-as mecrisp-stellaris-lpc845m301.s -o mecrisp-stellaris-lpc845m301.o

mecrisp-stellaris-lpc845m301.bin : memmap mecrisp-stellaris-lpc845m301.o
	$(ARMGNU)-ld -o mecrisp-stellaris-lpc845m301.elf -T memmap mecrisp-stellaris-lpc845m301.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-lpc845m301.elf > mecrisp-stellaris-lpc845m301.list
	$(ARMGNU)-objcopy mecrisp-stellaris-lpc845m301.elf mecrisp-stellaris-lpc845m301.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-lpc845m301.elf mecrisp-stellaris-lpc845m301.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
