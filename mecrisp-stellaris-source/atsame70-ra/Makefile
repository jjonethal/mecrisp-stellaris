
ARMGNU?=arm-none-eabi

COPS = -Wall  -Og -nostdlib -nostartfiles -ffreestanding -save-temps
AOPS = --warn --fatal-warnings

TARGET = atsame70q21
PROJECT = mecrisp-stellaris-$(TARGET)

all : $(PROJECT).bin $(PROJECT).hex

$(PROJECT).o : flash.s interrupts.s $(PROJECT).s terminal.s vectors.s
	$(ARMGNU)-as -g $(PROJECT).s -o $(PROJECT).o

# offset 0x08000000 to enable flash with st-link utility
# offset removed for same70
$(PROJECT).hex : $(PROJECT).bin
	$(ARMGNU)-objcopy -I binary -O ihex $(PROJECT).bin $(PROJECT).hex

$(PROJECT).bin : memmap $(PROJECT).o
	$(ARMGNU)-ld -g -o $(PROJECT).elf -T memmap $(PROJECT).o
	$(ARMGNU)-objdump -D $(PROJECT).elf > $(PROJECT).list
	$(ARMGNU)-objcopy $(PROJECT).elf $(PROJECT).bin -O binary
	$(ARMGNU)-objdump --source --all-headers --demangle --line-numbers --wide $(PROJECT).elf > $(PROJECT).lst

clean:
	rm -f *.bin
	rm -f *.o
	rm -f *.elf
	rm -f *.list
	rm -f *.lst
	rm -f *.hex

