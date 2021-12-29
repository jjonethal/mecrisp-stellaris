
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-palanqin.bin

mecrisp-stellaris-palanqin.o : mecrisp-stellaris-palanqin.s
	$(ARMGNU)-as mecrisp-stellaris-palanqin.s -o mecrisp-stellaris-palanqin.o

mecrisp-stellaris-palanqin.bin : memmap mecrisp-stellaris-palanqin.o
	$(ARMGNU)-ld -o mecrisp-stellaris-palanqin.elf -T memmap mecrisp-stellaris-palanqin.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-palanqin.elf > mecrisp-stellaris-palanqin.list
	$(ARMGNU)-objcopy mecrisp-stellaris-palanqin.elf mecrisp-stellaris-palanqin.bin -O binary

clean:
	rm -f mecrisp-stellaris-palanqin.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
