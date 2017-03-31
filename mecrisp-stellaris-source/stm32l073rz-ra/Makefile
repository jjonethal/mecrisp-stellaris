
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32l073rz.bin

mecrisp-stellaris-stm32l073rz.o : mecrisp-stellaris-stm32l073rz.s
	$(ARMGNU)-as mecrisp-stellaris-stm32l073rz.s -o mecrisp-stellaris-stm32l073rz.o

mecrisp-stellaris-stm32l073rz.bin : memmap mecrisp-stellaris-stm32l073rz.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32l073rz.elf -T memmap mecrisp-stellaris-stm32l073rz.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32l073rz.elf > mecrisp-stellaris-stm32l073rz.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32l073rz.elf mecrisp-stellaris-stm32l073rz.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
