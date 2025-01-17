
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32g031f6.bin

mecrisp-stellaris-stm32g031f6.o : mecrisp-stellaris-stm32g031f6.s
	$(ARMGNU)-as mecrisp-stellaris-stm32g031f6.s -o mecrisp-stellaris-stm32g031f6.o

mecrisp-stellaris-stm32g031f6.bin : memmap mecrisp-stellaris-stm32g031f6.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32g031f6.elf -T memmap mecrisp-stellaris-stm32g031f6.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32g031f6.elf > mecrisp-stellaris-stm32g031f6.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32g031f6.elf mecrisp-stellaris-stm32g031f6.bin -O binary
	$(ARMGNU)-objcopy --change-addresses 0x08000000 -I binary -O ihex mecrisp-stellaris-stm32g031f6.bin mecrisp-stellaris-stm32g031f6.hex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
