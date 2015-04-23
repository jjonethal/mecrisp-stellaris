:: tt.cmd
for %%I in (adc.txt) do set F=%%~fI
echo CRReceive=CR+LF > macro.ttl
:: echo callmenu 50310 >> macro.ttl
echo sendfile '%F%' 0 >> macro.ttl

for %%I in (macro.ttl) do set M=%%~fI

pause

start C:\app\teraterm\ttermpro.exe /BAUD=115200 /C=16 /FD="%CD%" /M="%M%"
