:: tt.cmd
:: select comport
set COMPORT=16

:scanfiles
if "%1" == "" goto ttstart
if "%~sx1" == ".txt" call :send %1
shift
goto scanfiles

:ttstart
start C:\app\teraterm\ttermpro.exe /BAUD=115200 /C=%COMPORT%
goto :EOF

:send
echo sending %1
:: for %%I in (adc.txt) do set F=%%~fI
if not "%1" == "" set F=%~f1
echo.   > macro.ttl
echo connect '/C=16' >> macro.ttl
echo timeout=2 >> macro.ttl
echo callmenu 50200 >> macro.ttl
echo wait #10 #13 >> macro.ttl
echo closett >> macro.ttl
for %%I in (macro.ttl) do set M=%%~fI
for %%I in (tt_txcrlf.ini) do set INI=%%~fI
C:\app\teraterm\ttpmacro.exe "%M%"


:: echo callmenu 50310 >> macro.ttl
echo sendln 'reset' > macro.ttl
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

C:\app\teraterm\ttermpro.exe /BAUD=115200 /C=%COMPORT% /FD="%CD%" /M="%M%" /F="%INI%"
goto :EOF
