
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f072rb.bin

mecrisp-stellaris-stm32f072rb.o : mecrisp-stellaris-stm32f072rb.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f072rb.s -o mecrisp-stellaris-stm32f072rb.o

mecrisp-stellaris-stm32f072rb.bin : memmap mecrisp-stellaris-stm32f072rb.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f072rb.elf -T memmap mecrisp-stellaris-stm32f072rb.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f072rb.elf > mecrisp-stellaris-stm32f072rb.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f072rb.elf mecrisp-stellaris-stm32f072rb.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
