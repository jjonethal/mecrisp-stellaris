
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-mk20dx256.bin 

mecrisp-stellaris-mk20dx256.o : mecrisp-stellaris-mk20dx256.s
	$(ARMGNU)-as mecrisp-stellaris-mk20dx256.s -o mecrisp-stellaris-mk20dx256.o

mecrisp-stellaris-mk20dx256.bin : memmap mecrisp-stellaris-mk20dx256.o
	$(ARMGNU)-ld -o mecrisp-stellaris-mk20dx256.elf -T memmap mecrisp-stellaris-mk20dx256.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-mk20dx256.elf > mecrisp-stellaris-mk20dx256.list
	$(ARMGNU)-objcopy mecrisp-stellaris-mk20dx256.elf mecrisp-stellaris-mk20dx256.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-mk20dx256.elf mecrisp-stellaris-mk20dx256.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.hex
	rm -f *.o
	rm -f *.elf
	rm -f *.list
