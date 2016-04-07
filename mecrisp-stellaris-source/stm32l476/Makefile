
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32l476.bin 

mecrisp-stellaris-stm32l476.o : mecrisp-stellaris-stm32l476.s
	$(ARMGNU)-as mecrisp-stellaris-stm32l476.s -g -o mecrisp-stellaris-stm32l476.o

mecrisp-stellaris-stm32l476.bin : memmap mecrisp-stellaris-stm32l476.o
	$(ARMGNU)-ld -g -o mecrisp-stellaris-stm32l476.elf -T memmap mecrisp-stellaris-stm32l476.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32l476.elf > mecrisp-stellaris-stm32l476.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32l476.elf mecrisp-stellaris-stm32l476.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
