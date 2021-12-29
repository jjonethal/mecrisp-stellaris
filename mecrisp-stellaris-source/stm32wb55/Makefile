
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32wb55.bin 

mecrisp-stellaris-stm32wb55.o : mecrisp-stellaris-stm32wb55.s terminal.s turbo.s vectors.s flash.s interrupts.s STM32WBxx_CM4.svd.equates.s
	$(ARMGNU)-as mecrisp-stellaris-stm32wb55.s -g -o mecrisp-stellaris-stm32wb55.o

mecrisp-stellaris-stm32wb55.bin : memmap mecrisp-stellaris-stm32wb55.o
	$(ARMGNU)-ld -g -o mecrisp-stellaris-stm32wb55.elf -T memmap mecrisp-stellaris-stm32wb55.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32wb55.elf > mecrisp-stellaris-stm32wb55.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32wb55.elf mecrisp-stellaris-stm32wb55.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
