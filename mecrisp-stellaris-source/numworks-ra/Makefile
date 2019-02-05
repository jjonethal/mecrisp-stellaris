
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-numworks.bin 

mecrisp-stellaris-numworks.o : mecrisp-stellaris-numworks.s
	$(ARMGNU)-as mecrisp-stellaris-numworks.s -o mecrisp-stellaris-numworks.o

mecrisp-stellaris-numworks.bin : memmap mecrisp-stellaris-numworks.o
	$(ARMGNU)-ld -o mecrisp-stellaris-numworks.elf -T memmap mecrisp-stellaris-numworks.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-numworks.elf > mecrisp-stellaris-numworks.list
	$(ARMGNU)-objcopy mecrisp-stellaris-numworks.elf mecrisp-stellaris-numworks.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
