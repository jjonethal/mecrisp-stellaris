
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32g071rb.bin 

mecrisp-stellaris-stm32g071rb.o : mecrisp-stellaris-stm32g071rb.s
	$(ARMGNU)-as mecrisp-stellaris-stm32g071rb.s -o mecrisp-stellaris-stm32g071rb.o

mecrisp-stellaris-stm32g071rb.bin : memmap mecrisp-stellaris-stm32g071rb.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32g071rb.elf -T memmap mecrisp-stellaris-stm32g071rb.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32g071rb.elf > mecrisp-stellaris-stm32g071rb.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32g071rb.elf mecrisp-stellaris-stm32g071rb.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
