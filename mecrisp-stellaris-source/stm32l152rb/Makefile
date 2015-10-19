
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32l152rb.bin 

mecrisp-stellaris-stm32l152rb.o : mecrisp-stellaris-stm32l152rb.s
	$(ARMGNU)-as mecrisp-stellaris-stm32l152rb.s -o mecrisp-stellaris-stm32l152rb.o

mecrisp-stellaris-stm32l152rb.bin : memmap mecrisp-stellaris-stm32l152rb.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32l152rb.elf -T memmap mecrisp-stellaris-stm32l152rb.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32l152rb.elf > mecrisp-stellaris-stm32l152rb.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32l152rb.elf mecrisp-stellaris-stm32l152rb.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
