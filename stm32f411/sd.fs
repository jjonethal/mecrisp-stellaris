\
\ SD_CS	- PC8
\ SD_CLK - 	PB13
\ SD_DO -	PB14 
\ SD_DIN - 	PB15

SPI2 $8 + constant SPI2_SR
SPI2 $c + constant SPI2_DR
1 8 lshift constant SD_CS

: sd-sel   ( -- ) 1 24 lshift gpiob_bsrr bis! inline ;
: sd-unsel ( -- ) SD_CS           gpiob_bsrr bis! inline ;
: sd-sck0	( -- ) 1 29 lshift gpiob_bsrr bis! ;
: sd-sck1	( -- ) 1 13 lshift gpiob_bsrr bis! ;

: sd-gpio-init
1 16 lshift	gpiob bis!	\	SD_CS output

%10 13 2* lshift                    \ Set SCK pin as AF
%10 14 2* lshift or                   \ MISO AF
%10 15 2* lshift or gpiob_moder bis!  \ Set MOSI pin as AF

  GPIOB_AFRH @ $000fffff and GPIOB_AFRH !
  5 20 lshift 5 24 lshift 5 28 lshift or or 
  GPIOB_AFRH bis! \ Set AF5 mode from PB.13-15
sd-unsel
;




: spi2-init
sd-gpio-init
1 14 lshift RCC_APB1ENR bis! 	\ Enable SPI2

%101 3 lshift \ 25MHz/64=0,39
1 9 lshift or
1 8 lshift or
1 2 lshift or	\ master
SPI2 h!
1 6 lshift	SPI2 bis!	\ SPI enable
sd-unsel

;




: >spi2> ( c -- c ) 
\ true begin 1- dup 0= 2 SPI2_SR bit@ or until drop	\ Wait TX finish
 begin  2 SPI2_SR bit@ until
 SPI2_DR !
 
\ true begin 1- dup 0= 1 SPI2_SR bit@ or until drop	\ Wait RX finish  
 begin 1 SPI2_SR bit@ until 	\ Wait RX finish  
 SPI2_DR @
;
: >spi2 ( c -- ) >spi2> drop ;
: spi2> ( -- c ) $ff >spi2> ;

: >SD ( c -- ) >spi2 ;
: SD> ( -- c ) spi2> ;


512 buffer: sd.buf
8 buffer: sd.rc
: ?sd.rc 8 0 do sd> sd.rc i + c! loop ;
0 variable bn

: r3 ( -- n )
 sd> .
 sd> sd> . sd> . sd> . sd> .
;

: sd-cmd ( cmd arg -- n )
\ sd-sel
\ $ff >SD
swap
$40 or >SD	\ CMD
dup 24 rshift $ff and >SD
dup 16 rshift $ff and >SD
dup 8 rshift $ff and >SD
$ff and >SD 
$ff >SD	\ CRC
 $ff >SD
500 0 do SD> dup $80 and 0= if leave else drop then loop 
\ sd-unsel
\ 50 begin 1- SD> $80 and 0= over 0= or until  
\ begin SD> dup . $fe = until
;

: sd-read ( blk -- f )
sd-sel
17 swap sd-cmd dup
0= if
	begin sd> $fe = until	\ Ожидаем начало блока
	512 0 do sd> sd.buf i + c! loop
	then
	sd> sd> 2drop \ cr swap hex. hex. 
sd-unsel

;
: .sd.buf 0= if sd.buf 512 cr dump else cr ." Error" then ;

$b constant _SectSiz
$d constant _ClustSiz
$e constant _ResSecs
$10 constant _FatCnt
$24 constant _FATSz32

0 variable fat32-SectSiz
0 variable fat32-ClustSiz
0 variable fat32-ResSecs
0 variable fat32-FatCnt
0 variable fat32-FATSz32

: fat32-init
0 sd-read 0=
if
	sd.buf dup _SectSiz + h@ fat32-SectSiz ! 
	dup _ClustSiz + c@ fat32-ClustSiz ! 
	dup _ResSecs + h@ fat32-ResSecs ! 
	dup _FatCnt + c@ fat32-FatCnt ! 
	_FATSz32 + @ fat32-FATSz32 ! 
	cr ." fat init!"
then

;
: fat32-fat fat32-ResSecs @  ;

: fat32-rootdir
fat32-FATSz32 @ fat32-FatCnt @ * fat32-ResSecs @ +
;

: fat32-dataclust ( n -- n1 )
\ n - номер кластера
\ n1 - номер сектора
2 - 4096 * 512 / fat32-rootdir +
;

0
11 	-- DIR_Name
1	-- DIR_Attr
1	-- DIR_NTres
1	-- DIR_CrtTimeTenth
2	-- DIR_CrtTime
2	-- DIR_CrtDate
2	-- DIR_LstAccDate
2	-- DIR_FstClusHI
2	-- DIR_WrtTime
2	-- DIR_WrtDate
2	-- DIR_FstClusLo
4	-- DIR_FileSize
constant /DIR

: .dir ( adr -- )
dup DIR_Name 11 cr type
dup DIR_FstClusLo h@ space ." clust:" .
DIR_FileSize @ space ." Size:" .
;

\ Вычисляем адрес след. записи n DIR_Name в буфере 
: dirnameadr ( n -- adr ) /dir 2* * sd.buf + ;

: zagl0 drop ;
' zagl0 variable direxe

create fconfig c' CONFIG  CFG'
create fhelp c' HELP    TXT'
create fdat c' DATA    DAT'
create ftest c' RTC     FS '

\ Ищем файл c-adr в корневом каталоге. ind - индекс записи.
: file-search ( c-adr -- ind f )
1 arr![] 0
begin	
	dup dirnameadr 
	dup c@ 0<> swap
	11 1 arr@[] count compare 
	if false true 0 arr![] else true false 0 arr![] then
	and 
while
	1+
repeat
0 arr@[]
;

: foreachdir
0
begin	
	dup dirnameadr 
	dup c@ 0<> 
while
	direxe @ execute
	1+
repeat
2drop
;


\ ============= для проекта
20 buffer: ssid
20 buffer: pass
20 buffer: servip
20 buffer: servport

: get-line ( adr n - adr1 n1 )
2dup $a scan nip - 
;


: get-line1
nip 1+ /string 2dup  get-line
;

: read-config
fconfig file-search
if
	dirnameadr dup DIR_FstClusHI h@ 16 lshift swap DIR_FstClusLo h@ or
	fat32-dataclust sd-read 0=
	if
		cr ." read!"
		sd.buf 100 2dup get-line 2dup ssid place
		get-line1 2dup pass place
		get-line1 2dup servip place
		get-line1 servport place 
		2drop
		\ nip /string get-line 2dup space ." 2:" type
	else
		cr ." Not read!"
	then
else
	drop cr ." File not found!"
then

;

: read-help
fhelp file-search
if
	dirnameadr dup DIR_FstClusHI h@ 16 lshift swap DIR_FstClusLo h@ or
	fat32-dataclust sd-read 0=
	if


	else
		cr ." Not read!"
	then
else
	drop cr ." File not found!"
then


;

: test
spi2-init
5 ms
\ 10 0 do  $ff sd>slow> . loop sd-sel
10 0 do $ff >spi2 loop sd-sel
\ 5 ms
 $40 >SD 0 >SD 0 >SD 0 >SD 0 >SD $95 >SD	\ CMD0

 begin sd> 1 =
 until 

cr ." idle"
\  300 ms
 $48 >SD 0 >SD 0 >SD 1 >SD $aa >SD $87 >SD	\ CMD8
	r3 4 and 
 	if
 			cr ." CMD8 Error!" exit  
 	else
 		cr ." Ver.2"
 		begin
 		55 0 sd-cmd  drop 
		41 $40000000 sd-cmd 
 		0=
 		until
 		cr ." CMD41 Ok!"
 	then
 	sd-unsel
cr ." SD init"
fat32-init
fat32-rootdir sd-read drop
['] .dir direxe ! foreachdir
\ fconfig file-search cr . . 
read-config
\ 0= if
fat32-rootdir sd-read drop
read-help cr sd.buf 512 dump
\ then

\ 6 fat32-dataclust sd-read .sd.buf
\ 9 fat32-dataclust sd-read .sd.buf
\ $00 sd-read .sd.buf
\ sd.buf dup 
 \ ?sd.rc cr ." CMD8" cr sd.rc 8 dump  
cr ." The end!"
;

: t sd-read .sd.buf ;
