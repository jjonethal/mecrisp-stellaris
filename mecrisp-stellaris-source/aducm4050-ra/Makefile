
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-aducm4050.bin 

mecrisp-stellaris-aducm4050.o : mecrisp-stellaris-aducm4050.s
	$(ARMGNU)-as mecrisp-stellaris-aducm4050.s -o mecrisp-stellaris-aducm4050.o

mecrisp-stellaris-aducm4050.bin : memmap mecrisp-stellaris-aducm4050.o
	$(ARMGNU)-ld -o mecrisp-stellaris-aducm4050.elf -T memmap mecrisp-stellaris-aducm4050.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-aducm4050.elf > mecrisp-stellaris-aducm4050.list
	$(ARMGNU)-objcopy mecrisp-stellaris-aducm4050.elf mecrisp-stellaris-aducm4050.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
