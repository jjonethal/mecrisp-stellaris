
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-kl25z128.bin 

mecrisp-stellaris-kl25z128.o : mecrisp-stellaris-kl25z128.s
	$(ARMGNU)-as mecrisp-stellaris-kl25z128.s -o mecrisp-stellaris-kl25z128.o

mecrisp-stellaris-kl25z128.bin : memmap mecrisp-stellaris-kl25z128.o
	$(ARMGNU)-ld -o mecrisp-stellaris-kl25z128.elf -T memmap mecrisp-stellaris-kl25z128.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-kl25z128.elf > mecrisp-stellaris-kl25z128.list
	$(ARMGNU)-objcopy mecrisp-stellaris-kl25z128.elf mecrisp-stellaris-kl25z128.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-kl25z128.elf mecrisp-stellaris-kl25z128.srec -O srec

clean:
	rm -f *.bin
	rm -f *.srec
	rm -f *.o
	rm -f *.elf
	rm -f *.list
