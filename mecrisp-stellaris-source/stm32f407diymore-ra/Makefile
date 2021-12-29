
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f407diymore.bin

mecrisp-stellaris-stm32f407diymore.o : mecrisp-stellaris-stm32f407diymore.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f407diymore.s -o mecrisp-stellaris-stm32f407diymore.o

mecrisp-stellaris-stm32f407diymore.bin : memmap mecrisp-stellaris-stm32f407diymore.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f407diymore.elf -T memmap mecrisp-stellaris-stm32f407diymore.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f407diymore.elf > mecrisp-stellaris-stm32f407diymore.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f407diymore.elf mecrisp-stellaris-stm32f407diymore.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
