UF2CONVERT:=picotool/uf2conv.py
UF2FLAGS:=--family 0xe48bff5b --base 0x10000000
OBJCOPY:=arm-none-eabi-objcopy
OBJDUMP:=arm-none-eabi-objdump
AS:=arm-none-eabi-as
LD:=arm-none-eabi-ld
platform_env:=$(if $(filter %/sh,$(SHELL)),posix,$(if $(filter %\cmd.exe,$(SHELL)),windows,unknown))
RM.windows:=del /Q
RM.posix:=rm -f
RM.unknown:=rm -f
RM:=$(RM.$(platform_env))
sep.windows=$(subst \,/,$(1))
sep.posix=$(subst \,/,$(1))
sep.unknown=$(subst \,/,$(1))
sep=$(call sep.$(platform_env),$1)
spawn.windows=start /B "" $(1)
spawn.posix=$(1) &
spawn.unknown=$(1) &
spawn=$(call spawn.$(platform_env),$1)

monitor-file.posix=tail -n +1 $(1) | grep $2 --line-buffered
monitor-file.windows=powershell -Command "Get-Content -Path '$(1)' -Wait | Select-String -Pattern '$(2)'"
monitor-file.unknown=tail -n +1 $(1) | grep $2 --line-buffered
monitor-file=$(call monitor-file.$(platform_env),$1,$2)

BUILD_FILES := mecrisp-stellaris-pico2-core.o
BUILD_FILES += mecrisp-stellaris-pico2-core.elf
BUILD_FILES += mecrisp-stellaris-pico2-core.map 
BUILD_FILES += mecrisp-stellaris-pico2-core.list 
BUILD_FILES += mecrisp-stellaris-pico2-core.bin
BUILD_FILES += mecrisp-stellaris-pico2-core.uf2

.PHONY: all
all: $(BUILD_FILES)

-include mecrisp-stellaris-pico2-core.o.d

mecrisp-stellaris-pico2-core.o.d: mecrisp-stellaris-pico2-core.o

mecrisp-stellaris-pico2-core.o.lst: mecrisp-stellaris-pico2-core.o

mecrisp-stellaris-pico2-core.o: mecrisp-stellaris-pico2-core.s Makefile
	$(AS) -mcpu=cortex-m3 -agmshl=$@.lst -MD $@.d -g -o $@ $<

mecrisp-stellaris-pico2-core.elf: mecrisp-stellaris-pico2-core.o memmap
	$(LD) -g -o $@ --cref --print-map-locals -Map=$(patsubst %.elf,%.map,$@) -g -T memmap $<

mecrisp-stellaris-pico2-core.map: mecrisp-stellaris-pico2-core.elf

mecrisp-stellaris-pico2-core.list: mecrisp-stellaris-pico2-core.elf
	$(OBJDUMP) -g -S -D $< > $@

mecrisp-stellaris-pico2-core.bin: mecrisp-stellaris-pico2-core.elf
	$(OBJCOPY) -O binary $< $@

mecrisp-stellaris-pico2-core.uf2: mecrisp-stellaris-pico2-core.bin
	which python
	$(UF2CONVERT) --convert  $(UF2FLAGS) --output $@ $<
clean:
	$(RM) $(call sep,$(BUILD_FILES))
.PHONY: clean test-shell

test-shell:
	@echo "Hallo, Welt!"
	@set

run-openocd-mecrisp:
	$(call spawn,openocd -f openocd.cfg > openocd.log 2>&1)

wait-openocd:
	$(call monitor-file,openocd.log,"Listening on port 3333")

.PHONY: baud
baud: baud.o
	@echo "Assembled baud.o"
	 arm-none-eabi-as -g -o baud.o -agmshl=baud.o.lst baud.s
	 npp baud.o.lst

dump-%:
	$(info $* = $($*))