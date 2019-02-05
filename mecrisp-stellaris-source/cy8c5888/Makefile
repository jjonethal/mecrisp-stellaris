
ARMGNU?=arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

all : mecrisp-stellaris-cy8c5888.bin 

mecrisp-stellaris-cy8c5888.o : mecrisp-stellaris-cy8c5888.s
	$(ARMGNU)-as -ggdb mecrisp-stellaris-cy8c5888.s -o mecrisp-stellaris-cy8c5888.o

mecrisp-stellaris-cy8c5888.bin : memmap mecrisp-stellaris-cy8c5888.o
	$(ARMGNU)-ld -o mecrisp-stellaris-cy8c5888.elf -T memmap mecrisp-stellaris-cy8c5888.o
	$(ARMGNU)-objdump -D mecrisp-stellaris-cy8c5888.elf > mecrisp-stellaris-cy8c5888.list
	$(ARMGNU)-objcopy mecrisp-stellaris-cy8c5888.elf mecrisp-stellaris-cy8c5888.bin -O binary

upload:
	openocd -c "interface kitprog; kitprog_init_acquire_psoc" -f target/psoc5lp.cfg -c "init; halt; psoc5lp mass_erase 0; program mecrisp-stellaris-cy8c5888.bin 0x0 verify reset exit"

debug:
	$(ARMGNU)-gdb -x gdbinit

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
