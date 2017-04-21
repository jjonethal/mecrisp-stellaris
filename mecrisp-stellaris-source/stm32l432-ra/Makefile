
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32l432.bin 

mecrisp-stellaris-stm32l432.o : mecrisp-stellaris-stm32l432.s
	$(ARMGNU)-as mecrisp-stellaris-stm32l432.s -g -o mecrisp-stellaris-stm32l432.o

mecrisp-stellaris-stm32l432.bin : memmap mecrisp-stellaris-stm32l432.o
	$(ARMGNU)-ld -g -o mecrisp-stellaris-stm32l432.elf -T memmap mecrisp-stellaris-stm32l432.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32l432.elf > mecrisp-stellaris-stm32l432.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32l432.elf mecrisp-stellaris-stm32l432.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
