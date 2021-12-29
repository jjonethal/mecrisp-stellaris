:: File: ttupload.cmd
:: function: upload file to forth target
:: Usage: ttupload.cmd filename.ext
:: command helper for teraterm pro file uploader
:: 1. first we close down existing teraterm instance
::    so we can establish ttpmacro connection to teraterm
::    i've found no other way to connect ttpmacro to running instance
::    of teraterm. So for now we close down all running teraterm instances 
:: 2. launch new teraterm instance with upload_include.ttl macro with
::    upload file as parameter



:: comport number for connection
set COMPORT=5
:: tempoary macrco for closing down existing connection
set MACRO=%~dp0tempmac.ttl
:: Teraterm installation directory
set tt_dir=C:\app\teraterm


:: %tt_dir%\ttpmacro.exe "%~dp0upload.ttl" %*
:: goto :EOF

:: clean temporary macro
echo. > %MACRO%
echo connect '/C=%COMPORT%' >> %MACRO%
:: close all teraterm instances "exitAll"
echo callmenu 50200 >> %MACRO%
echo closett >> %MACRO%
%tt_dir%\ttpmacro.exe %MACRO%

:: open new teraterm connection to comport with macro link
echo connect '/C=%COMPORT%' > %MACRO%
echo include '%~dp0upload_include.ttl' >> %MACRO%
%tt_dir%\ttpmacro.exe %MACRO% %*

:: pause
:: get rid of temporary macro
del %MACRO%
