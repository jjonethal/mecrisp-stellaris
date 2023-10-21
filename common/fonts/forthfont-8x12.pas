
{ -----------------------------------------------------------------------------

  A small tool to extract 8x12 bitmap fonts from binary files
  to make nice character sets to use with Forth.

  Compile with the Freepascal Compiler, fpc forthfont-8x12.pas

  Usage: forthfont-8x12 binary-file font-file start-address #characters-1

----------------------------------------------------------------------------- }

{

This tool designed to extract the font data from the ROM contents of
a Datapoint 8600 machine. Font data is not directly mapped as a character
generator but is read by the "bios" of the machine and stored into the actual
character RAM area. The font is a 8x12 font, but only uppercase characters
were available, with the lowercase characters later loaded by the operating
system (RMS 2.8.J).

The font data is organised as nine bytes for each charater, with the MSB
of these data bytes always 0 for inter-character spacing. Therefore, data exists
for 7x9 bitmaps. Three empty lines are added when loading this font, one line on
top and two lines at the bottom which can be used for lowercase letters that may
be loaded later.

Bytes with MSB set denote the place in the character table (when masked with $7F).
Then nine bytes of graphics data follow.

When no place-in-the-character-table byte appears, continue with the next place.

}

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
    asciioffset : integer = 0;

begin
  assign(binary, paramstr(1));
  reset(binary);

  assign(fontfile, paramstr(2));
  rewrite(fontfile);

  seek(binary, strtoint(paramstr(3)) );

  for k := 0 to strtoint(paramstr(4)) do
  begin

    read(binary, character[1]);

    if (character[1] and $80) = $80 then
    begin
      writeln(fontfile);
      asciioffset := character[1] and $7F;
      read(binary, character[1]);
    end;

    for i := 2 to 9 do read(binary, character[i]);

    write(fontfile,
      word2hex(                 character[ 1] shl 8), ' h, ',
      word2hex(character[ 2] or character[ 3] shl 8), ' h, ',
      word2hex(character[ 4] or character[ 5] shl 8), ' h, ',
      word2hex(character[ 6] or character[ 7] shl 8), ' h, ',
      word2hex(character[ 8] or character[ 9] shl 8), ' h, ',
      word2hex(                                   0), ' h, ',
      '  \ ', asciioffset
    );

    if (32 <= asciioffset) and (asciioffset < 127) then writeln(fontfile, ' ', chr(asciioffset)) else writeln(fontfile);

  //  for i := 1 to 9 do writeln(fontfile, '  \ ', byte2str(character[i]));

    inc(asciioffset);

  end;

  close(fontfile);
  close(binary);
end.
