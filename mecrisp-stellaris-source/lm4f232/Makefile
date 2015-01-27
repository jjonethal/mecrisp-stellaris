
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-lm4f232.bin 

mecrisp-stellaris-lm4f232.o : mecrisp-stellaris-lm4f232.s
	$(ARMGNU)-as mecrisp-stellaris-lm4f232.s -o mecrisp-stellaris-lm4f232.o

mecrisp-stellaris-lm4f232.bin : memmap mecrisp-stellaris-lm4f232.o
	$(ARMGNU)-ld -o mecrisp-stellaris-lm4f232.elf -T memmap mecrisp-stellaris-lm4f232.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-lm4f232.elf > mecrisp-stellaris-lm4f232.list
	$(ARMGNU)-objcopy mecrisp-stellaris-lm4f232.elf mecrisp-stellaris-lm4f232.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
