:: E:\stm\openocd\openocd-0.9.0-dev-150204220259\openocd-0.9.0-dev-150204220259\scripts\
set PATH=C:\app\gcc\4.9_2014q4\bin;%PATH%
start C:\app\openocd\bin-x64\openocd-x64-0.9.0-dev-150204220259.exe -f C:\app\openocd\scripts\board\st_nucleo_f4.cfg
arm-none-eabi-gdb mecrisp-stellaris-stm32f411.elf -x .gdbinit
pause
