
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f103.bin 

mecrisp-stellaris-stm32f103.o : mecrisp-stellaris-stm32f103.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f103.s -o mecrisp-stellaris-stm32f103.o

mecrisp-stellaris-stm32f103.bin : memmap mecrisp-stellaris-stm32f103.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f103.elf -T memmap mecrisp-stellaris-stm32f103.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f103.elf > mecrisp-stellaris-stm32f103.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f103.elf mecrisp-stellaris-stm32f103.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
