
program asciimandel;
                    //     1234567890123456
const colormap : string = ' .,:;*vnm%8O0@+ ';

var
  xs, ys, iter : integer;
  xc, yc, x, y, x0 : single;

begin
  for ys := 23 downto -23 do
  begin
    yc := ys / 16;
    for xs := 0 to 127 do
    begin
      xc := xs / 32 - 2.5;
      x := xc; y := yc; iter := -1;
      repeat
        x0 := x;
        x  := sqr(x) - sqr(y) + xc;
        y  := 2 * x0 * y + yc;
        inc(iter)
      until ((sqr(x) + sqr(y) > 4) or (iter = 256));
      write(colormap[iter and $F + 1]);
    end;
    writeln;
  end;
end.
