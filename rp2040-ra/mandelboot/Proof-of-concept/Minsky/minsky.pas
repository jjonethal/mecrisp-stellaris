
const outshift    =       13;
      minskyshift =       17;

var   x : longint = 1 shl 19;
      y : longint = 1 shl 0;

      xmin : longint = 0;
      xmax : longint = 0;
      ymin : longint = 0;
      ymax : longint = 0;

      i : longint;

begin
  for i := 0 to 1000000 do
  begin

    if (x and $80000000) = 0 then begin if x > xmax then xmax := x; end
                             else begin if x < xmin then xmin := x; end;

    if (y and $80000000) = 0 then begin if y > ymax then ymax := y; end
                             else begin if y < ymin then ymin := y; end;

     writeln(x, ' ', y, ' ', x*x+y*y, ' ', sarlongint(x, outshift), ' ', sarlongint(y, outshift));

  // Improved algorithm, needs more opcodes...
  //  x := x - sarlongint(y, minskyshift + 1);
  //  y := y + sarlongint(x, minskyshift);
  //  x := x - sarlongint(y, minskyshift + 1);

  // Simple Minsky algorithm
    x := x - sarlongint(y, minskyshift);
    y := y + sarlongint(x, minskyshift);

  end;

  writeln('# ', xmin, ' ', xmax, ' ', ymin, ' ', ymax, ' : ',
                sarlongint(xmin, outshift), ' ', sarlongint(xmax, outshift), ' ', sarlongint(ymin, outshift), ' ', sarlongint(ymax, outshift),

                ' : -II ', sarlongint(xmax, outshift-2) - sarlongint(xmin, outshift-2), ' ', sarlongint(ymax, outshift-2) - sarlongint(ymin, outshift-2),
                ' : -I ',  sarlongint(xmax, outshift-1) - sarlongint(xmin, outshift-1), ' ', sarlongint(ymax, outshift-1) - sarlongint(ymin, outshift-1),
                ' : ',     sarlongint(xmax, outshift  ) - sarlongint(xmin, outshift  ), ' ', sarlongint(ymax, outshift  ) - sarlongint(ymin, outshift  ),
                ' : +I ',  sarlongint(xmax, outshift+1) - sarlongint(xmin, outshift+1), ' ', sarlongint(ymax, outshift+1) - sarlongint(ymin, outshift+1),
                ' : +II ', sarlongint(xmax, outshift+2) - sarlongint(xmin, outshift+2), ' ', sarlongint(ymax, outshift+2) - sarlongint(ymin, outshift+2)
         );
end.
