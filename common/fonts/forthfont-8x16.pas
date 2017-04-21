
{ -----------------------------------------------------------------------------

  A small tool to extract 8x16 bitmap fonts from binary files
  to make nice character sets to use with Forth.

  Compile with the Freepascal Compiler, fpc forthfont.pas

  Usage: forthfont-8x16 binary-file font-file start-address #characters-1 ascii-offset

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
    character : array[1..16] of byte;
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

    for i := 1 to 16 do read(binary, character[i]);

    write(fontfile,
      word2hex(character[ 1] or character[ 2] shl 8), ' h, ',
      word2hex(character[ 3] or character[ 4] shl 8), ' h, ',
      word2hex(character[ 5] or character[ 6] shl 8), ' h, ',
      word2hex(character[ 7] or character[ 8] shl 8), ' h, ',
      word2hex(character[ 9] or character[10] shl 8), ' h, ',
      word2hex(character[11] or character[12] shl 8), ' h, ',
      word2hex(character[13] or character[14] shl 8), ' h, ',
      word2hex(character[15] or character[16] shl 8), ' h, ',
      '  \ ', k + asciioffset
    );

    if (32 <= k + asciioffset) and (k + asciioffset < 127) then writeln(fontfile, ' ', chr(k + asciioffset)) else writeln(fontfile);

    // for i := 1 to 16 do writeln(fontfile, '  \ ', byte2str(character[i]));

  end;

  close(fontfile);
  close(binary);
end.
