:: set PATH=C:\MinGW\bin;C:\MinGW\msys\1.0\bin;%PATH%
set PATH=C:\gccarm\4.7_2014q2\bin;C:\MinGW\bin;C:\MinGW\msys\1.0\bin;%PATH%
SET STLINK="C:\Program Files (x86)\STMicroelectronics\STM32 ST-LINK Utility\ST-LINK Utility\ST-LINK_CLI.exe"

mingw32-make.exe clean all

if ERRORLEVEL 0 (
  %STLINK% -P mecrisp-stellaris-stm32f411.bin 0x08000000
  %STLINK% -HardRst
) else (
	echo build error
)
pause
