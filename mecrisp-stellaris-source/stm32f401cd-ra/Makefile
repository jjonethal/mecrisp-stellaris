
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f401cd.bin 

mecrisp-stellaris-stm32f401cd.o : mecrisp-stellaris-stm32f401cd.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f401cd.s -o mecrisp-stellaris-stm32f401cd.o

mecrisp-stellaris-stm32f401cd.bin : memmap mecrisp-stellaris-stm32f401cd.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f401cd.elf -T memmap mecrisp-stellaris-stm32f401cd.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f401cd.elf > mecrisp-stellaris-stm32f401cd.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f401cd.elf mecrisp-stellaris-stm32f401cd.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
