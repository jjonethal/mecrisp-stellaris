
if "%COMPUTERNAME%" == "BCHF6KOC" (
	set OPEN_OCD_PATH=E:\stm\openocd\openocd-0.9.0-dev-150204220259\openocd-0.9.0-dev-150204220259
	set GNU_ARM_BIN=E:\gcc\4.6_2012q4\bin
) else (
	set OPEN_OCD_PATH=C:\app\openocd
	set GNU_ARM_BIN=C:\app\gcc\4.9_2014q4\bin
)

if "%COMPUTERNAME%" == "GJ-PC" (
	set OPEN_OCD_PATH=C:\app\openocd
	set GNU_ARM_BIN=C:\gccarm\4.7_2014q2\bin
)

set OPEN_OCD_EXE=openocd-x64-0.9.0-dev-150204220259.exe
set OPEN_OCD_CMD=%OPEN_OCD_PATH%\bin-x64\%OPEN_OCD_EXE%


set PATH=%GNU_ARM_BIN%;%PATH%
start %OPEN_OCD_CMD% -f %OPEN_OCD_PATH%\scripts\board\st_nucleo_f4.cfg
arm-none-eabi-gdb mecrisp-stellaris-stm32f411.elf -x .gdbinit
pause
