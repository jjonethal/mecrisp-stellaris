TARGET ?= mecrisp-stellaris-stm32f030r8

ARMGNU ?= arm-none-eabi

COPS = -Wall  -Os -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

.PHONY: clean all install

all : $(TARGET).bin 

$(TARGET).o : $(TARGET).s
	$(ARMGNU)-as $(TARGET).s -o $@

$(TARGET).bin : memmap $(TARGET).o
	$(ARMGNU)-ld -o $(TARGET).elf -T memmap $(TARGET).o -Map=$(TARGET).map
	$(ARMGNU)-objdump -D $(TARGET).elf > $(TARGET).list
	$(ARMGNU)-objcopy $(TARGET).elf $@ -O binary
	$(ARMGNU)-size $(TARGET).elf

clean:
	rm -f *.bin
	rm -f *.elf
	rm -f *.list
	rm -f *.map
	rm -f *.o

install: $(TARGET).bin
	openocd -f interface/stlink.cfg -f target/stm32f0x.cfg -c 'init; halt; stm32f1x mass_erase 0; exit'
	openocd -f interface/stlink.cfg -f target/stm32f0x.cfg -c 'program $< verify reset exit 0x08000000'

# vim: set ts=4 sw=4 noexpandtab :

