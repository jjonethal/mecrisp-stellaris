
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-tm4c1294.bin 

mecrisp-stellaris-tm4c1294.o : mecrisp-stellaris-tm4c1294.s
	$(ARMGNU)-as mecrisp-stellaris-tm4c1294.s -o mecrisp-stellaris-tm4c1294.o

mecrisp-stellaris-tm4c1294.bin : memmap mecrisp-stellaris-tm4c1294.o
	$(ARMGNU)-ld -o mecrisp-stellaris-tm4c1294.elf -T memmap mecrisp-stellaris-tm4c1294.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-tm4c1294.elf > mecrisp-stellaris-tm4c1294.list
	$(ARMGNU)-objcopy mecrisp-stellaris-tm4c1294.elf mecrisp-stellaris-tm4c1294.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
