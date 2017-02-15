:: mingw from       http://sourceforge.net/projects/mingw/files/latest/download?source=files
:: stlink util from http://www.st.com/web/en/catalog/tools/PF258168

call rebuild.cmd

:: flashing
if not ERRORLEVEL 1 (
  %STLINK% -P mecrisp-stellaris-stm32f303.bin 0x08000000
  %STLINK% -HardRst
  @ping -n 3 127.0.0.1 > nul:
) else (
	echo build error
	pause
)
