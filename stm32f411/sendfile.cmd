:: sendfile.cmd
:: send a forth source file using teraterm
:: sendfile file1.txt file2.txt file3.txt 
:: without parameter start teraterm on COMPORT
:: select comport
set COMPORT=16
set TERA_TERM_DIR=C:\app\teraterm
set MACRO=%~dp0macro.ttl

:: loop over file list ignore non-txt files
:scanfiles
if "%1" == "" goto ttstart
if "%~sx1" == ".txt" call :send %1
if "%~sx1" == ".TXT" call :send %1
shift
goto scanfiles

:: no (more) parameters start teraterm
:ttstart
start %TERA_TERM_DIR%\ttermpro.exe /BAUD=115200 /C=%COMPORT%
goto :EOF

:send
echo sending %1
:: for %%I in (adc.txt) do set F=%%~fI
if not "%1" == "" set F=%~f1
echo.   > %MACRO%
echo connect '/C=%COMPORT%' >> %MACRO%
echo timeout=10 >> %MACRO%
echo callmenu 50200 >> %MACRO%
echo wait #10 #13 >> %MACRO%
echo closett >> %MACRO%
for %%I in (%MACRO%) do set M=%%~fI
for %%I in (%~dp0tt_txcrlf.ini) do set INI=%%~fI
%TERA_TERM_DIR%\ttpmacro.exe "%M%"

:: echo callmenu 50310 >> macro.ttl
echo. > %MACRO%
:: echo sendln 'reset' >> %MACRO%
echo sendfile '%F%' 0 >> %MACRO%
:: echo setsync 1 >> %MACRO%
echo timeout=2 >> %MACRO%
echo do >> %MACRO%
echo   result=0 >> %MACRO%
echo   wait #10 #13 >> %MACRO%
echo loop while result ^> 0 >> %MACRO%
echo dispstr "finished" >> %MACRO%
echo closett >> %MACRO%
echo. >> %MACRO%

for %%I in (%MACRO%) do set M=%%~fI
for %%I in (%~dp0tt_txcrlf.ini) do set INI=%%~fI

%TERA_TERM_DIR%\ttermpro.exe /BAUD=115200 /C=%COMPORT% /FD="%CD%" /M="%M%" /F="%INI%"
del macro.ttl
goto :EOF
