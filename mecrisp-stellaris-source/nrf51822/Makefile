
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-nrf51822.bin 

mecrisp-stellaris-nrf51822.o : mecrisp-stellaris-nrf51822.s
	$(ARMGNU)-as mecrisp-stellaris-nrf51822.s -o mecrisp-stellaris-nrf51822.o

mecrisp-stellaris-nrf51822.bin : memmap mecrisp-stellaris-nrf51822.o
	$(ARMGNU)-ld -o mecrisp-stellaris-nrf51822.elf -T memmap mecrisp-stellaris-nrf51822.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-nrf51822.elf > mecrisp-stellaris-nrf51822.list
	$(ARMGNU)-objcopy mecrisp-stellaris-nrf51822.elf mecrisp-stellaris-nrf51822.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-nrf51822.elf mecrisp-stellaris-nrf51822.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
