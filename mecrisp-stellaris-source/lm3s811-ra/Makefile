
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-lm3s811.bin

mecrisp-stellaris-lm3s811.o : mecrisp-stellaris-lm3s811.s
	$(ARMGNU)-as mecrisp-stellaris-lm3s811.s -o mecrisp-stellaris-lm3s811.o

mecrisp-stellaris-lm3s811.bin : memmap mecrisp-stellaris-lm3s811.o
	$(ARMGNU)-ld -o mecrisp-stellaris-lm3s811.elf -T memmap mecrisp-stellaris-lm3s811.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-lm3s811.elf > mecrisp-stellaris-lm3s811.list
	$(ARMGNU)-objcopy mecrisp-stellaris-lm3s811.elf mecrisp-stellaris-lm3s811.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
