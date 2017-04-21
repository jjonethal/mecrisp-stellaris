
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-mk64fn1m0.bin

mecrisp-stellaris-mk64fn1m0.o : mecrisp-stellaris-mk64fn1m0.s
	$(ARMGNU)-as mecrisp-stellaris-mk64fn1m0.s -o mecrisp-stellaris-mk64fn1m0.o

mecrisp-stellaris-mk64fn1m0.bin : memmap mecrisp-stellaris-mk64fn1m0.o
	$(ARMGNU)-ld -o mecrisp-stellaris-mk64fn1m0.elf -T memmap mecrisp-stellaris-mk64fn1m0.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-mk64fn1m0.elf > mecrisp-stellaris-mk64fn1m0.list
	$(ARMGNU)-objcopy mecrisp-stellaris-mk64fn1m0.elf mecrisp-stellaris-mk64fn1m0.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-mk64fn1m0.elf mecrisp-stellaris-mk64fn1m0.srec -O srec

clean:
	rm -f *.bin
	rm -f *.srec
	rm -f *.o
	rm -f *.elf
	rm -f *.list
