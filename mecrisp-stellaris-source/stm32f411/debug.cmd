:: simple debug script
setlocal
:: set DBG_ELF=mecrisp-stellaris-stm32f411.elf
set DBG_ELF=%*

:: don't omit .exe
set GDB=arm-none-eabi-gdb.exe
::set OPEN_OCD_EXE=openocd-x64-0.9.0-dev-150204220259.exe
set OPEN_OCD_EXE=openocd.exe

SET P=E:\stm\openocd\openocd-0.9.0-dev-150204220259\openocd-0.9.0-dev-150204220259
if exist %P%\nul set OPEN_OCD_PATH=%P%
SET P=C:\app\openocd
if exist %P%\nul set OPEN_OCD_PATH=%P%

SET P=E:\gcc\4.6_2012q4\bin
if exist %P%\%GDB% set GNU_ARM_BIN=%P%
SET P=C:\gccarm\4.7_2014q2\bin
if exist %P%\%GDB% set GNU_ARM_BIN=%P%
SET P=C:\app\gcc\4.9_2014q4\bin
if exist %P%\%GDB% set GNU_ARM_BIN=%P%

set OPEN_OCD_CMD=%OPEN_OCD_PATH%\bin-x64\%OPEN_OCD_EXE%

set PATH=%GNU_ARM_BIN%;%PATH%

:: start ocd in separate window
start /MIN %OPEN_OCD_CMD% -f %OPEN_OCD_PATH%\scripts\board\st_nucleo_f4.cfg
:: launch and wait for gdb complete
arm-none-eabi-gdb %DBG_ELF% -x .gdbinit

:: shutdown ocd
(
@echo target remote localhost:3333
@echo monitor shutdown 
@echo quit
) | arm-none-eabi-gdb
endlocal

:: pause
