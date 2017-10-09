setlocal
set LUA_DIR=C:\Users\jeanjo\work\lua\x64
set LUA_CPATH=%LUA_DIR%\bin\?.dll;%LUA_DIR%\?.dll;.\?.dll;%LUA_DIR%\loadall.dll
set LUA_PATH=%LUA_DIR%\lib\?.lua;.\?.lua
::call C:\app\luapower\luajit32.cmd %*
%LUA_DIR%\luajit %*