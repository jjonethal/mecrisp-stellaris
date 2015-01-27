
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-lm4f120.bin 

mecrisp-stellaris-lm4f120.o : mecrisp-stellaris-lm4f120.s
	$(ARMGNU)-as mecrisp-stellaris-lm4f120.s -o mecrisp-stellaris-lm4f120.o

mecrisp-stellaris-lm4f120.bin : memmap mecrisp-stellaris-lm4f120.o
	$(ARMGNU)-ld -o mecrisp-stellaris-lm4f120.elf -T memmap mecrisp-stellaris-lm4f120.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-lm4f120.elf > mecrisp-stellaris-lm4f120.list
	$(ARMGNU)-objcopy mecrisp-stellaris-lm4f120.elf mecrisp-stellaris-lm4f120.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
