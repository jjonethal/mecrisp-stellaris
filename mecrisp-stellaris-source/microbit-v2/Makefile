
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-microbit-v2.bin

mecrisp-stellaris-microbit-v2.o : mecrisp-stellaris-microbit-v2.s
	$(ARMGNU)-as mecrisp-stellaris-microbit-v2.s -o mecrisp-stellaris-microbit-v2.o

mecrisp-stellaris-microbit-v2.bin : memmap mecrisp-stellaris-microbit-v2.o
	$(ARMGNU)-ld -o mecrisp-stellaris-microbit-v2.elf -T memmap mecrisp-stellaris-microbit-v2.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-microbit-v2.elf > mecrisp-stellaris-microbit-v2.list
	$(ARMGNU)-objcopy mecrisp-stellaris-microbit-v2.elf mecrisp-stellaris-microbit-v2.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-microbit-v2.elf mecrisp-stellaris-microbit-v2.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
