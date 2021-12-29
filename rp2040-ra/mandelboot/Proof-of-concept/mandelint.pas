
program mandelint;
                    //     1234567890123456
const colormap : string = ' .,:;*vnm%8O0@+ ';

  mandel_shift = 12;

  xmin         = -3 * (1 shl mandel_shift);
  xmax         =  3 * (1 shl mandel_shift);
  ymin         = -2 * (1 shl mandel_shift);
  ymax         =  2 * (1 shl mandel_shift);

  dx           = (xmax-xmin) div 192;
  dy           = (ymax-ymin) div 64;

  norm_max     = 4 shl mandel_shift;

var
  cr, ci : longint;
  zr, zi : longint;
  zrr, z2ri, zii : longint;
  iter : longint;

begin
  ci := ymin;
  repeat
    cr := xmin;
    repeat

      zr := cr;
      zi := ci;
      iter := -1;

      repeat
        zrr  :=            (zr * zr) shr mandel_shift;
        z2ri := sarlongint((zr * zi), mandel_shift - 1);
        zii  :=            (zi * zi) shr mandel_shift;

        zr := zrr - zii + cr;
        zi :=    z2ri   + ci;

        inc(iter);
      until (zrr + zii > norm_max) or (iter = 64);

      write(colormap[iter and $F + 1]);
      inc(cr, dx);
    until cr > xmax;
    // write(ci);
    writeln;
    inc(ci, dy);
  until ci > ymax;


  // writeln('mandel_shift   : ', mandel_shift);
  // writeln('  xmin         : ', xmin        );
  // writeln('  xmax         : ', xmax        );
  // writeln('  ymin         : ', ymin        );
  // writeln('  ymax         : ', ymax        );
  // writeln('  dx           : ', dx          );
  // writeln('  dy           : ', dy          );
  // writeln('  norm_max     : ', norm_max    );
end.
