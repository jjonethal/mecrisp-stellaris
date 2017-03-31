
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f303re.bin 

mecrisp-stellaris-stm32f303re.o : mecrisp-stellaris-stm32f303re.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f303re.s -o mecrisp-stellaris-stm32f303re.o

mecrisp-stellaris-stm32f303re.bin : memmap mecrisp-stellaris-stm32f303re.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f303re.elf -T memmap mecrisp-stellaris-stm32f303re.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f303re.elf > mecrisp-stellaris-stm32f303re.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f303re.elf mecrisp-stellaris-stm32f303re.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
