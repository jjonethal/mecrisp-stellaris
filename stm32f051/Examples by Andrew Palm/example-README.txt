---------------------------------------------------------------------------
This folder contains a set of examples using Mecrisp-Stellaris Forth by 
Matthias Koch.  They were written for an STM32F051K8T6 on a DIP conversion
PCB and components on a solderless breadboard.  They are listed here in
approximately increasing order of complexity.  

These examples were adapted from exercises developed while learning C 
programming for MSP430 and STM32F1/F0 chips using two primary sources:

  - "MSP430 State Machine Programming" by Tom Baugh, 2008
  - "Discovering the STM32 Microcontroller" by Geoffery Brown, 1992

Andrew Palm
February 2018

---------------------------------------------------------------------------
example-delay.fs - This is a relatively simple "blinky" example.  However,
it introduces code to set the system clock to 48 MHz using the PLL and
internal 8 MHz RC oscillator.  Blocking delays are used for an approximate
1 Hz blink rate, with the delay count values derived empirically.  Also 
introduced is the "init" word, which executes on a chip reset.  The main
program is set up inside this word's definition.  In order to make the
interpreter available after the program is started with a reset, the
bottom of the main loop has the "key? until" construct so that pushing
any key on the serial terminal will halt the loop.  A "reset" command will
restart the program. 

---------------------------------------------------------------------------
example-pb-poll.fs - This example is a significant jump up in complexity.
It uses the SysTick counter and interrupt to implement a main loop which 
repeats every 1 millisecond.  This provides a time base for program tasks 
so that blocking delays are not needed in the main loop.  Also introduced 
are "drivers" for a pushbutton and rotary encoder that control two leds. 
The tasks which directly control the leds "register" with these drivers 
so that the desired control happens.  Why introduce this complication? 
The reason is that in more complicated programs the functions of the 
pushbutton and rotary encoder can be changed "on the fly" by registering 
different "event sinks" or "actions" with them.  This is especially useful 
when implementing menus.  (See example-servo.fs below.)

The pushbutton driver allows for two actions, one for a short push and 
one for a long (> 1 sec) push.  In this example a short push turns on led2 
and a long push turns it off.  It also does software debouncing.  The
encoder driver assumes that its input connections are debounced in 
hardware and has cw and ccw actions.  In this example a cw turn of the 
encoder increases the flashing led1 duty cycle, and a ccw turn decreases 
the duty cycle.   

The comment header in the file gives details on the hardware connections. 
It also contains comments on making the hardware setup stand-alone.
Because of the "key? until" construct that allows escape from the main 
loop, if the terminal is disconnected, the program halts.  To defeat this, 
the USART RX connection on PA10 can be held at 3.3 volts by a jumper.

---------------------------------------------------------------------------
example-pb-int.fs - This is identical in hardware to the previous example, 
but the pushbutton now uses an external interrupt rather than polling.  
This introduces code which sets up an external interrupt and sets its 
priority.  This example also sets the priority of the SysTick interrupt. 

Note that control of the second led by the pushbutton now runs completely 
in the background, as the main loop does not contain a task for it.

---------------------------------------------------------------------------
example-servo.fs - This example adds a third led and a servo motor.  It
shows how to set up a timer to produce a pwm output, in this case to 
control the servo motor position.  (The servo motor is very small to avoid 
current draw beyond the breadboard power supply.)  The example also shows 
the advantage of using the pushbutton and rotary encoder driver 
registration, as described above, by having two "control modes."

When the pushbutton is given a long push the control mode is toggled.  
In "Mode 0" the encoder increases and decreases the duty cycle of the  
flashing led, and the pushbutton toggles the second led on and off with a 
short push.  In "Mode 1" the encoder controls the position of the servo 
motor, and a short push on the pushbutton centers the servo position.  The 
third led serves as a mode indicator, off in Mode 0 and on in Mode 1.  
The driver registrations for the two control modes are made using the task 
cntl-mode, which is registered with the pushbutton long push.

---------------------------------------------------------------------------
example-stepper.fs - This example is similar to the servo motor example, 
except that a 28BYJ-48 5V stepper motor with gear reduction and a ULN2003A 
darlington driver board is used instead (see eBay).  Another difference is 
when in "Mode 1" the pushbutton simply stops the motor in its current 
position rather than returning it to a neutral position.  The incremental 
motor steps are done every 5 ms (five main loop ticks), and half-stepping 
is used.

---------------------------------------------------------------------------
example-adc.fs - This example uses a third led and a 10 Kohm potentiometer 
in the hardware.  The wiper of the pot is input to the ADC, which does a 
conversion every 10 ms, triggered by a timer.  The third led is turned on 
when the pot wiper voltage is above one half the supply voltage.  

The control of the third led using the adc, like the pushbutton control of 
the second led, is completely in the background.

---------------------------------------------------------------------------
example-ultrasonic.fs - This example uses two timers to trigger and
measure the returned echo pulse from an ultrasonic distance sensor.  The
timer setup code is more complicated than in the previous example, esp. 
since the time processing the returned echo pulse must use two capture 
and compare channesl to measure the pulse width.  Although the sensor is 
triggered every 100 ms, the calculation and distance display task is run 
every 200 ms in the main loop to keep the terminal output reasonable.  
One could change the trigger period and do the calculation and display in 
the background.

---------------------------------------------------------------------------
example-nunchuk-i2c.fs - This example uses I2C to communicate with a Wii 
nunchuk, which contains two pushbuttons, a joystick, and an accelerometer. 
The raw data from the nunchuk are read over I2C and then converted to 
values for display on the serial terminal.  The I2C drivers can be 
configured for 100 kHz or 400 kHz communication and can send or receive 
up to 255 bytes with one call.  Error messages can be uncommented to help 
debug problems.

Another feature introduced with this example is the use of state machines 
to break up tasks into smaller parts.  The reason for this is that a task 
called from the main loop may take so long to execute that it could not be 
completed within the time allowed for a single loop, esp. when other tasks 
must also be completed in the loop time (in this case 1 ms).  This simple 
version of a state machine uses the forth "case" structure.  On each call 
of the task, one of the "of ... endof" pieces is executed.  A "state 
variable" value controls which piece is executed.  State machines are used 
for the tasks nchk-read and nchk-display.  
 
---------------------------------------------------------------------------
example-ssd1306.fs - Here we use I2C to write to a small 32x128 OLED 
display which is used as a 4 row by 21 column character display.  The 
drivers write text strings to the display in either non-scrolling or 
scrolling mode.  This example displays messages in scrolling mode when the 
leds are changed by the pushbutton or rotary encoder.  The task which 
draws the characters on the display is called in the main loop and uses a 
state machine which loops through the 84 character positions, drawing one 
character per loop.  With loop initialization, the display is updated 
completely every 85 ms.  

** Note: This example uses a second file named glcdfont.fs.  There is an 
         #include directive in the main file to pull the glcdfont.fs code 
         into the main file when it is downloaded via the serial terminal.
         This directive is for the e4thcom program.  I you do not use this 
         particular terminal program, you can cut and paste glcdfont.fs 
         into example-ssd1306.fs at the place where the directive is, or 
         modify the include directive for your setup.

---------------------------------------------------------------------------
example-st7735.fs - This is very similar to example-ssd1306.fs in
operation, but it uses an Adafruit 160x128 TFT display module connected
by SPI instead of I2C.  The display is color and graphical, but it is used
as a monochrome character display with 12 rows and 26 columns with a blue
background and yellow characters.  (The font and background colors are
easy to change.)  The SPI1 drivers in this example can be used for other 
devices, such as sensors.

---------------------------------------------------------------------------
Makefile - This is a script for the program make, which is usually used to 
organize the compiling and linking of programs.  Here it is a convenient 
way to invoke terminal commands to flash or bootload the forth kernel to  
the chip and to connect a serial terminal emulator program to the chip once 
forth is running.  

---------------------------------------------------------------------------
Final comments.  You can create your own examples by mix-and-matching 
parts of these examples.  For example, the servo motor example could be 
modified to include the ssd1306 display.  The display could show which 
control mode has been selected and show messages when a particular control 
action is made.

Due to the designed-in upward compatibility of STM32 mcu's, these examples 
should be easily adapted for larger chips in the STM32F0 family, and for 
the smaller STM32F030K6T6, which has an identical pinout to the K8T6.  Do 
note, however, that interrupt names should be checked for the forth kernel 
you are using.

If you use an external 8 MHz crystal instead of the internal oscillator, 
the 48MHz code must be changed.  Modifications would also be necessary for 
a Nucleo board whose clock is driven by an external source.

---------------------------------------------------------------------------
