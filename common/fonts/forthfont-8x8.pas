
{ -----------------------------------------------------------------------------

  A small tool to extract 8x8 bitmap fonts from binary files
  to make nice character sets to use with Forth.

  Compile with the Freepascal Compiler, fpc forthfont.pas

  Usage: forthfont binary-file font-file start-address #characters-1 ascii-offset

  You might need to rearrange characters manually for final use.


  Two examples for usage are included:

  With Atari PC3 BIOS:

    ./forthfont AWARD_ATARI_PC_BIOS_3.08.img Atari-Font.txt 0x3160 255 0

  With Commodore 64 font ROM:

    This one has a different character mapping called PETSCII:

    ./forthfont Commodore-C64-Chargen.img Commodore-Font.txt 0 511 0

    Therefore, convert in chunks to get mapping to ASCII almost right:

    ./forthfont Commodore-C64-Chargen.img Commodore-Font-1.txt 0x900 31 32
    ./forthfont Commodore-C64-Chargen.img Commodore-Font-2.txt 0xA00 31 64
    ./forthfont Commodore-C64-Chargen.img Commodore-Font-3.txt 0x800 31 96

    cat Commodore-Font-* > Commodore-Font.txt

----------------------------------------------------------------------------- }

uses sysutils;

function byte2hex(zahl : byte) : string;
const
    hexa : array [0..15] of char = '0123456789ABCDEF';
begin
  byte2hex := hexa[zahl shr 4] + hexa[zahl and 15];
end;

function word2hex(zahl : word) : string;
begin
  word2hex := Byte2Hex((zahl and $FF00) shr 8) + Byte2Hex(zahl and $00FF);
end;

function byte2str(c : byte) : string;
var h : string = '';
var i : integer;
begin
  for i := 7 downto 0 do
  begin
    if (c shr i) and 1 = 1 then h := h + '*' else h := h + ' ';
  end;
  byte2str := h;
end;

var binary : file of byte;
    fontfile : text;
    i, k : integer;
    character : array[1..8] of byte;
    asciioffset : integer;

begin
  assign(binary, paramstr(1));
  reset(binary);

  assign(fontfile, paramstr(2));
  rewrite(fontfile);

  seek(binary, strtoint(paramstr(3)) );

  asciioffset := strtoint(paramstr(5));

  for k := 0 to strtoint(paramstr(4)) do
  begin

    // writeln(fontfile);

    for i := 1 to 8 do read(binary, character[i]);

    write(fontfile,
      word2hex(character[1] or character[2] shl 8), ' h, ',
      word2hex(character[3] or character[4] shl 8), ' h, ',
      word2hex(character[5] or character[6] shl 8), ' h, ',
      word2hex(character[7] or character[8] shl 8), ' h, ',
      '  \ ', k + asciioffset
    );

    if (32 <= k + asciioffset) and (k + asciioffset < 127) then writeln(fontfile, ' ', chr(k + asciioffset)) else writeln(fontfile);

//    for i := 1 to 8 do writeln(fontfile, '  \ ', byte2str(character[i]));

  end;

  close(fontfile);
  close(binary);
end.
