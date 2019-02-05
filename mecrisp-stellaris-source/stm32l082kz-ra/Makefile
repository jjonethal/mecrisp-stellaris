
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32l082kz.bin 

mecrisp-stellaris-stm32l082kz.o : mecrisp-stellaris-stm32l082kz.s
	$(ARMGNU)-as mecrisp-stellaris-stm32l082kz.s -o mecrisp-stellaris-stm32l082kz.o

mecrisp-stellaris-stm32l082kz.bin : memmap mecrisp-stellaris-stm32l082kz.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32l082kz.elf -T memmap mecrisp-stellaris-stm32l082kz.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32l082kz.elf > mecrisp-stellaris-stm32l082kz.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32l082kz.elf mecrisp-stellaris-stm32l082kz.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
