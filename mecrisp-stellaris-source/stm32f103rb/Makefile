
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f103rb.bin

mecrisp-stellaris-stm32f103rb.o : mecrisp-stellaris-stm32f103rb.s
	$(ARMGNU)-as mecrisp-stellaris-stm32f103rb.s -o mecrisp-stellaris-stm32f103rb.o

mecrisp-stellaris-stm32f103rb.bin : memmap mecrisp-stellaris-stm32f103rb.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f103rb.elf -T memmap mecrisp-stellaris-stm32f103rb.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f103rb.elf > mecrisp-stellaris-stm32f103rb.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f103rb.elf mecrisp-stellaris-stm32f103rb.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
