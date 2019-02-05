
ARMGNU?=arm-none-eabi

COPS = -Wall  -O0 -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings -g

all : mecrisp-stellaris-nrf52832.bin 

mecrisp-stellaris-nrf52832.o : mecrisp-stellaris-nrf52832.s
	$(ARMGNU)-as ${AOPS} mecrisp-stellaris-nrf52832.s -o mecrisp-stellaris-nrf52832.o

mecrisp-stellaris-nrf52832.bin : memmap mecrisp-stellaris-nrf52832.o
	$(ARMGNU)-ld -o mecrisp-stellaris-nrf52832.elf -T memmap mecrisp-stellaris-nrf52832.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-nrf52832.elf > mecrisp-stellaris-nrf52832.list
	$(ARMGNU)-objcopy mecrisp-stellaris-nrf52832.elf mecrisp-stellaris-nrf52832.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-nrf52832.elf mecrisp-stellaris-nrf52832.hex -O ihex

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.hex
