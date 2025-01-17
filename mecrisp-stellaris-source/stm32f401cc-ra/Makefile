
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f401cc.bin 

mecrisp-stellaris-stm32f401cc.o : mecrisp-stellaris-stm32f401cc.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f401cc.s -o mecrisp-stellaris-stm32f401cc.o

mecrisp-stellaris-stm32f401cc.bin : memmap mecrisp-stellaris-stm32f401cc.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f401cc.elf -T memmap mecrisp-stellaris-stm32f401cc.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f401cc.elf > mecrisp-stellaris-stm32f401cc.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f401cc.elf mecrisp-stellaris-stm32f401cc.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
