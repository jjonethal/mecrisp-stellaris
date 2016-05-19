
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-kl46z256.bin 

mecrisp-stellaris-kl46z256.o : mecrisp-stellaris-kl46z256.s
	$(ARMGNU)-as mecrisp-stellaris-kl46z256.s -o mecrisp-stellaris-kl46z256.o

mecrisp-stellaris-kl46z256.bin : memmap mecrisp-stellaris-kl46z256.o
	$(ARMGNU)-ld -o mecrisp-stellaris-kl46z256.elf -T memmap mecrisp-stellaris-kl46z256.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-kl46z256.elf > mecrisp-stellaris-kl46z256.list
	$(ARMGNU)-objcopy mecrisp-stellaris-kl46z256.elf mecrisp-stellaris-kl46z256.bin -O binary
	$(ARMGNU)-objcopy mecrisp-stellaris-kl46z256.elf mecrisp-stellaris-kl46z256.srec -O srec

clean:
	rm -f *.bin
	rm -f *.srec
	rm -f *.o
	rm -f *.elf
	rm -f *.list
