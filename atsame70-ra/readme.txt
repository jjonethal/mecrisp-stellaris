This is a mecrisp-stellaris version for the atmel same70 controller
I've used the same70 x-plained board from atmel.
It's not so expensive , and has a lot of IO expansion headers
It also features a very fast 300Mhz core !

It works well , BUT :

Because the compiler doesn't always compile in ascending order in memory ,
only 'compiletoram' can be used.
Unfortunately 'compiletoflash' for writing to flash can't be used , since the flash has to be 
written in always ascending or descending order. It can not be mixed. (see datasheet)

Maybe one day Matthias will do a rebuild of the compiler (?)

I've included the blinky program , so you can do a small test of the board.
It blinks the onboard led about once per second.


How to connect to a terminal ? :

connect a serial to usb cable (3V3 version !)
to pb0 and pb1 located on J505
pb0 = rxd (input controller , so is txd from your cable) --> labeled 'DI5' on pcb
pb1 = txd (output controller so rxd from your cable)     --> labeled 'DI4' on pcb

ground can be connected to e.g. p19 on connector EXT2






Ronny Suy
