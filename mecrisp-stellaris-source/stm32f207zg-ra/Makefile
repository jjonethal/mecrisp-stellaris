
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f207zg.bin 

mecrisp-stellaris-stm32f207zg.o : mecrisp-stellaris-stm32f207zg.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f207zg.s -o mecrisp-stellaris-stm32f207zg.o

mecrisp-stellaris-stm32f207zg.bin : memmap mecrisp-stellaris-stm32f207zg.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f207zg.elf -T memmap mecrisp-stellaris-stm32f207zg.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f207zg.elf > mecrisp-stellaris-stm32f207zg.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f207zg.elf mecrisp-stellaris-stm32f207zg.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
