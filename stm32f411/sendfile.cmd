:: sendfile.cmd
:: send a forth source file using teraterm
:: sendfile file1.txt file2.txt file3.txt 
:: without parameter start teraterm on COMPORT
:: select comport
set COMPORT=15
set TERA_TERM_DIR=C:\app\teraterm

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
echo.   > macro.ttl
echo connect '/C=%COMPORT%' >> macro.ttl
echo timeout=10 >> macro.ttl
echo callmenu 50200 >> macro.ttl
echo wait #10 #13 >> macro.ttl
echo closett >> macro.ttl
for %%I in (macro.ttl) do set M=%%~fI
for %%I in (tt_txcrlf.ini) do set INI=%%~fI
%TERA_TERM_DIR%\ttpmacro.exe "%M%"

:: echo callmenu 50310 >> macro.ttl
echo. > macro.ttl
echo sendln 'reset' >> macro.ttl
echo sendfile '%F%' 0 >> macro.ttl
:: echo setsync 1 >> macro.ttl
echo timeout=2 >> macro.ttl
echo do >> macro.ttl
echo   result=0 >> macro.ttl
echo   wait #10 #13 >> macro.ttl
echo loop while result ^> 0 >> macro.ttl
echo dispstr "finished" >> macro.ttl
echo closett >> macro.ttl
echo. >> macro.ttl

for %%I in (macro.ttl) do set M=%%~fI
for %%I in (tt_txcrlf.ini) do set INI=%%~fI

%TERA_TERM_DIR%\ttermpro.exe /BAUD=115200 /C=%COMPORT% /FD="%CD%" /M="%M%" /F="%INI%"
goto :EOF
