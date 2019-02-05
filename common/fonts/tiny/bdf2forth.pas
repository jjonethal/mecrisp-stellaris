
uses sysutils;

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



var eingabe, ausgabe : text;
    zeile : string;

function skipto(marke : string) : boolean;
begin
  zeile := '';
  while (copy(zeile, 1, length(marke)) <> marke) and not eof(eingabe) do readln(eingabe, zeile);
  skipto := eof(eingabe);
end;

function token : string;
begin
  if pos(' ', zeile) <> 0 then
  begin
    token := copy(zeile, 1, pos(' ', zeile) - 1);
    delete(zeile, 1, pos(' ', zeile));
  end
  else
  begin
    token := zeile;
  end;
                            
end;

const asciioffset = 0;

var character : array[1..6] of byte;
    row, encoding, i, index, x, y, offsetx, offsety : word;

    
{

  Das Zeichen ist y Zeilen hoch. Und es ist von der Unterkante aus offsety Zeilen nach oben verschoben.
  Die Daten beginnen aber oben.

  Wie berechne ich nun den passenden Index ?
  
  Array:  Offsety:    y=Zahl der Zeilen
  1
  2       4
  3       3
  4       2             
  5       1             
  6       0
  
  index   - offsety - y 
  
  
  
  
  61 , 3 , 3 , 0 , 1 , E0 00 E0  =
  \ ***     
  \         
  \ ***     
  \         
  \         
  \   
  
  3 Zeilen kommen. Verschiebung = (6 - 3 - 1)
  
  
}
    
    
function nibble2hex(zahl : byte) : string;
const hexa : array [0..15] of char = '0123456789ABCDEF';
begin
  nibble2hex := hexa[zahl and 15];
end;

procedure scanfont;
begin
  repeat  
    if skipto('ENCODING') then exit;
    delete(zeile, 1, 9);
    
    encoding := strtoint(zeile);
    
    write(ausgabe, encoding, ' h, ');
    
    
    skipto('BBX');
    delete(zeile, 1, 4);
        
    x := strtoint(token);
    y := strtoint(token);
    offsetx := strtoint(token);
    offsety := strtoint(token);
        
//    write(ausgabe, x, ' , ');
//    write(ausgabe, y, ' , ');
//    write(ausgabe, offsetx, ' , ');
//    write(ausgabe, offsety, ' , ');    

    index := 0;
    fillchar(character, sizeof(character), 0);
    
    skipto('BITMAP');    
    readln(eingabe, zeile);    
    while zeile <> 'ENDCHAR' do
    begin
      row := index + (6-y-offsety);    
      character[row] := strtoint('$'+zeile) shr offsetx;        
//    write(ausgabe, row, ' ');
//    write(ausgabe, byte2hex(character[row]), ' ');
      inc(index);  
      readln(eingabe, zeile);
    end;
    
    write(ausgabe, ' $'); for i := 1 to 8 do write(ausgabe, nibble2hex(character[i] shr 4)); write(ausgabe, ' , ');
    
    
    if (32 <= encoding + asciioffset) and (encoding + asciioffset < 256) then writeln(ausgabe, '  \ ', chr(encoding + asciioffset)) else writeln(ausgabe);
        
    for i := 1 to 6 do writeln(ausgabe, '  \ ', byte2str(character[i] shr offsetx)); writeln(ausgabe);
  until false;
end;
    
begin
  assign(eingabe, paramstr(1));
  assign(ausgabe, paramstr(2));
  reset(eingabe);
  rewrite(ausgabe);
  
  scanfont;
  
  close(eingabe);
  close(ausgabe);
end.
  
