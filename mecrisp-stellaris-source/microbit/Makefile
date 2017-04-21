
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-microbit.bin

mecrisp-stellaris-microbit.o : mecrisp-stellaris-microbit.s
	$(ARMGNU)-as mecrisp-stellaris-microbit.s -o mecrisp-stellaris-microbit.o

mecrisp-stellaris-microbit.bin : memmap mecrisp-stellaris-microbit.o
	$(ARMGNU)-ld -o mecrisp-stellaris-microbit.elf -T memmap mecrisp-stellaris-microbit.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-microbit.elf > mecrisp-stellaris-microbit.list
	$(ARMGNU)-objcopy mecrisp-stellaris-microbit.elf mecrisp-stellaris-microbit.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-microbit.elf mecrisp-stellaris-microbit.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
