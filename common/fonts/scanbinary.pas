
{ -----------------------------------------------------------------------------

  A very simple tool to check if bitmap fonts are present in a binary file.

  Compile with the Freepascal Compiler, fpc scanbinary.pas

  Usage: scanbinary binary-file readable-file

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
    c : byte;
    address : word = 0;

begin
  assign(binary, paramstr(1));
  reset(binary);

  assign(fontfile, paramstr(2));
  rewrite(fontfile);

  while not eof(binary) do
  begin

    read(binary, c);
    write(fontfile, word2hex(address), ': ', byte2str(c));

    writeln(fontfile);
    inc(address);
  end;

  close(fontfile);
  close(binary);
end.
