
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-efm32hg322.bin 

mecrisp-stellaris-efm32hg322.o : mecrisp-stellaris-efm32hg322.s
	$(ARMGNU)-as mecrisp-stellaris-efm32hg322.s -o mecrisp-stellaris-efm32hg322.o

mecrisp-stellaris-efm32hg322.bin : memmap mecrisp-stellaris-efm32hg322.o
	$(ARMGNU)-ld -o mecrisp-stellaris-efm32hg322.elf -T memmap mecrisp-stellaris-efm32hg322.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-efm32hg322.elf > mecrisp-stellaris-efm32hg322.list
	$(ARMGNU)-objcopy mecrisp-stellaris-efm32hg322.elf mecrisp-stellaris-efm32hg322.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
