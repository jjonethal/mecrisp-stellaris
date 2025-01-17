
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32g431kb.bin 

mecrisp-stellaris-stm32g431kb.o : mecrisp-stellaris-stm32g431kb.s
	$(ARMGNU)-as mecrisp-stellaris-stm32g431kb.s -o mecrisp-stellaris-stm32g431kb.o

mecrisp-stellaris-stm32g431kb.bin : memmap mecrisp-stellaris-stm32g431kb.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32g431kb.elf -T memmap mecrisp-stellaris-stm32g431kb.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32g431kb.elf > mecrisp-stellaris-stm32g431kb.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32g431kb.elf mecrisp-stellaris-stm32g431kb.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
