
ARMGNU?=arm-none-eabi

# debug build
COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-nuc123.bin 

mecrisp-stellaris-nuc123.o : mecrisp-stellaris-nuc123.s
	$(ARMGNU)-as ${AOPS} mecrisp-stellaris-nuc123.s -o mecrisp-stellaris-nuc123.o

mecrisp-stellaris-nuc123.bin : memmap mecrisp-stellaris-nuc123.o
	$(ARMGNU)-ld -o mecrisp-stellaris-nuc123.elf -T memmap mecrisp-stellaris-nuc123.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-nuc123.elf > mecrisp-stellaris-nuc123.list
	$(ARMGNU)-objcopy mecrisp-stellaris-nuc123.elf mecrisp-stellaris-nuc123.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-nuc123.elf mecrisp-stellaris-nuc123.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
