setlocal

cd /D %~dp0
set MSYSTEM=MINGW64
set "PATH=%PATH%;C:\msys64\mingw64\bin;C:\msys64\usr\local\bin"
start "" "C:\Program Files\Microsoft VS Code\Code.exe" .
call "C:\msys64\msys2_shell.cmd" -here