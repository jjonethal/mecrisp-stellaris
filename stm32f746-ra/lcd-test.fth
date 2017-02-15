#25 constant hse-clk-mhz
: sys-clk-200-mhz ( -- )
   #25 pll-m! #400 pll-n! 
: demo ( -- )
   sys-clk-200-mhz lcd-init draw-demo ;