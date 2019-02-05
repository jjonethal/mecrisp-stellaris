
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-cy8c4245axi.bin 

mecrisp-stellaris-cy8c4245axi.o : mecrisp-stellaris-cy8c4245axi.s
	$(ARMGNU)-as mecrisp-stellaris-cy8c4245axi.s -o mecrisp-stellaris-cy8c4245axi.o

mecrisp-stellaris-cy8c4245axi.bin : memmap mecrisp-stellaris-cy8c4245axi.o
	$(ARMGNU)-ld -o mecrisp-stellaris-cy8c4245axi.elf -T memmap mecrisp-stellaris-cy8c4245axi.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-cy8c4245axi.elf > mecrisp-stellaris-cy8c4245axi.list
	$(ARMGNU)-objcopy mecrisp-stellaris-cy8c4245axi.elf mecrisp-stellaris-cy8c4245axi.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-cy8c4245axi.elf mecrisp-stellaris-cy8c4245axi.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.hex
	rm -f *.o
	rm -f *.elf
	rm -f *.list
