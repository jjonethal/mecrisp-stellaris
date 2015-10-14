for /F " usebackq delims==" %%i in (`luajit -e "a=math.floor(math.sqrt(%~z1*8)) print(a..""x""..a)"`) do set SIZE=%%i
echo size: %SIZE%
"C:\Program Files\ImageMagick-6.9.1-Q16\convert" -size %SIZE% mono:%1 %1.bmp
for /F " usebackq delims==" %%i in (`luajit -e "a=math.floor(math.sqrt(%~z1)) print(a..""x""..a)"`) do set SIZE=%%i
echo size: %SIZE%
"C:\Program Files\ImageMagick-6.9.1-Q16\convert" -depth 8 -size %SIZE% gray:%1 %1.gr.bmp

echo size: %SIZE%
::convert -depth 1 -size 148x148 mono:%1 %1.pgm
