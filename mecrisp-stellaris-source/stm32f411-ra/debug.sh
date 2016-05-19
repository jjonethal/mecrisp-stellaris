# simple debug script
DBG_ELF=mecrisp-stellaris-stm32f411.elf

P=/e/stm/openocd/openocd-0.9.0-dev-150204220259/openocd-0.9.0-dev-150204220259
OPEN_OCD_PATH=$P
P=/e/gcc/4.6_2012q4/bin
GNU_ARM_BIN=$P

OPEN_OCD_EXE=openocd-x64-0.9.0-dev-150204220259
OPEN_OCD_CMD=$OPEN_OCD_PATH/bin-x64/$OPEN_OCD_EXE


export PATH=$GNU_ARM_BIN:$PATH
$OPEN_OCD_CMD -f $OPEN_OCD_PATH/scripts/board/st_nucleo_f4.cfg &
arm-none-eabi-gdb $DBG_ELF -x .gdbinit
:: shutdown ocd
arm-none-eabi-gdb < ocdshutdown.gdb
:: pause
