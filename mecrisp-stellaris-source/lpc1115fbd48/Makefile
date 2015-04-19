
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-lpc1115fbd48.bin 

mecrisp-stellaris-lpc1115fbd48.o : mecrisp-stellaris-lpc1115fbd48.s
	$(ARMGNU)-as mecrisp-stellaris-lpc1115fbd48.s -o mecrisp-stellaris-lpc1115fbd48.o

mecrisp-stellaris-lpc1115fbd48.bin : memmap mecrisp-stellaris-lpc1115fbd48.o
	$(ARMGNU)-ld -o mecrisp-stellaris-lpc1115fbd48.elf -T memmap mecrisp-stellaris-lpc1115fbd48.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-lpc1115fbd48.elf > mecrisp-stellaris-lpc1115fbd48.list
	$(ARMGNU)-objcopy mecrisp-stellaris-lpc1115fbd48.elf mecrisp-stellaris-lpc1115fbd48.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-lpc1115fbd48.elf mecrisp-stellaris-lpc1115fbd48.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
