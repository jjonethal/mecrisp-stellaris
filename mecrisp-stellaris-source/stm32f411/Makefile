
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-stm32f411.bin mecrisp-stellaris-stm32f411.hex

mecrisp-stellaris-stm32f411.o : flash.s interrupts.s mecrisp-stellaris-stm32f411.s terminal.s vectors.s
	$(ARMGNU)-as -g mecrisp-stellaris-stm32f411.s -o mecrisp-stellaris-stm32f411.o

# offset 0x08000000 to enable flash with st-link utility
mecrisp-stellaris-stm32f411.hex : mecrisp-stellaris-stm32f411.bin
	$(ARMGNU)-objcopy -I binary --change-addresses 0x08000000 mecrisp-stellaris-stm32f411.bin mecrisp-stellaris-stm32f411.hex  -O ihex 

mecrisp-stellaris-stm32f411.bin : memmap mecrisp-stellaris-stm32f411.o
	$(ARMGNU)-ld -o mecrisp-stellaris-stm32f411.elf -T memmap mecrisp-stellaris-stm32f411.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-stm32f411.elf > mecrisp-stellaris-stm32f411.list
	$(ARMGNU)-objcopy mecrisp-stellaris-stm32f411.elf mecrisp-stellaris-stm32f411.bin -O binary

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
