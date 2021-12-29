\
\ Small set of routines for playing around with the PiPico.
\ Inspired by a youtube video with secret code inside,
\ which has to be newly invented ;)
\
\ (c) Carsten Fulde 2021
\
\ pin constants are named from left top GP0 against the clock til GP29 (ADC_VREF) near right top in above view
\ most words expect this constant to do something useful with it
\
\ Not freely usable are: pin0, pin1 (both used for UART), pin29/ADC_VREF = ADC temperature;
\
\ Examples
\ pinX .pin -> prints out current status of the pin
\ pinX .pad   -> prints only Pad-Register information
\ pinX .inputs -> prints the status of all bits in half words binary, outputs are all 0 by default
\ pinX .outputs -> same for the outputs, inputs are all 0 by default
\ pinX input/output  -> sets pin to input or output
\ pinX high/low/toggle -> sets pin to output and sets the value afterwards
\ pinX 4 %1010 !outbits -> outputs value %1010 with width 4 bits from pinX (lsb) upwards
\ pinX 4 ?inbits -> reads the binary value from pinX (lsb) upwards with the width of 4 bits 
\
\ pinX SlewFast Schmitt 12mA or or padOn -> setting various Pad-Register (or'd) flags
\                                           If both PullUp + PullDown are set, PullDown has priority
\ pinX PullDown Schmitt or padOff        -> clears  various Pad-Register (or'd) flags
\
\ pinX/ADC0..ADC2 adcvalue -> initializes pin26..pin29 for Analog digital, queries the value between 0..4095
\ pinX/ADC0..ADC2 .adcvolt -> prints voltage at pin26..29 after querying the adc
\
\ Very useful, thanks to Matthias
\ pinX .pin 5 times -> repeats the input line 5 times, ie try it with blink16 at the end
\ pinX .pin many -> repeats the input line until keypress. Sinclair -> 4E4 :)
\

$40014000 constant IO_BANK0_BASE
$4001c000 constant PADS_BANK0_BASE
$d0000000 constant SIO_BASE

SIO_BASE $004 + constant GPIO_IN       \ Input value for GPIO pins
SIO_BASE $010 + constant GPIO_OUT      \ GPIO output value
SIO_BASE $014 + constant GPIO_OUT_SET  \ GPIO output value set
SIO_BASE $018 + constant GPIO_OUT_CLR  \ GPIO output value clear
SIO_BASE $01c + constant GPIO_OUT_XOR  \ GPIO output value XOR
SIO_BASE $020 + constant GPIO_OE       \ GPIO output enable
SIO_BASE $024 + constant GPIO_OE_SET   \ GPIO output enable set
SIO_BASE $028 + constant GPIO_OE_CLR   \ GPIO output enable clear
SIO_BASE $02c + constant GPIO_OE_XOR   \ GPIO output enable XOR

$4004c000       constant ADC_BASE   \ ADC base in SDK
ADC_BASE  $00 + constant ADC-CS     \ ADC Control and Status
ADC_BASE  $04 + constant ADC-RESULT \ Result of most recent ADC conversion
ADC_BASE  $08 + constant ADC-FCS    \ FIFO control and status
ADC_BASE  $0c + constant ADC-FIFO   \ Conversion result FIFO
ADC_BASE  $10 + constant ADC-DIV    \ Clock divider. If non-zero, CS_START_MANY will start conversions at regular intervals rather than back-to-back.
                                    \ The divider is reset when either of these fields are written. Total period is 1 + INT + FRAC / 256
ADC_BASE  $14 + constant ADC-INTR   \ Raw Interrupts
ADC_BASE  $18 + constant ADC-INTE   \ Interrupt Enable
ADC_BASE  $1c + constant ADC-INTF   \ Interrupt Force
ADC_BASE  $20 + constant ADC-INTS   \ Interrupt status after masking & forcing

: setbit 1 swap lshift ;  \ Calculates the value for bit 0 (LSB) to bit 31 (MSB)

\ Further parameter pinConst
0  setbit constant pin0
1  setbit constant pin1
2  setbit constant pin2
3  setbit constant pin3
4  setbit constant pin4
5  setbit constant pin5
6  setbit constant pin6
7  setbit constant pin7
8  setbit constant pin8
9  setbit constant pin9
10 setbit constant pin10
11 setbit constant pin11
12 setbit constant pin12
13 setbit constant pin13
14 setbit constant pin14
15 setbit constant pin15
16 setbit constant pin16
17 setbit constant pin17
18 setbit constant pin18
19 setbit constant pin19
20 setbit constant pin20
21 setbit constant pin21
22 setbit constant pin22
23 setbit constant pin23
24 setbit constant pin24
25 setbit constant pin25
26 setbit constant pin26
27 setbit constant pin27
28 setbit constant pin28
29 setbit constant pin29

pin26      constant ADC0
pin27      constant ADC1
pin28      constant ADC2
pin29      constant ADC_VREF

\ Pad control values
%00000001 constant SlewFast
%00000010 constant Schmitt
%00000100 constant PullDown
%00001000 constant PullUp
%01000000 constant IE
%10000000 constant OD
\ Special - Bit 8 set if strength has to be modified, highest given one is set
\ Trap: 4mA 8mA or = 12mA cause of bit logic
%100000000 constant 2mA
%100010000 constant 4mA
%100100000 constant 8mA
%100110000 constant 12mA

: pin2no ( pinConst -- pinNo )                \ results the position of the first true bit from LSB to MSB
  clz 31 swap - ;                             \ clz counts leading zeros, subtract it from 31

\ Pad-Bank control
: padRegister ( pinConst -- Address )         \ Calculates the PadsRegister address
  pin2no 2 lshift 4 +                         \ Starts at BASE + 4 with pin0, Base + 8 pin1 aso
  PADS_BANK0_BASE + ;

: .pad ( pinConst -- )                        \ prints out padRegister human readable
  ." ( "
  padRegister @
  dup SlewFast  and if ." SlewFast " else ." SlewSlow " then 
  dup Schmitt   and if ." Schmitt " then
  dup PullDown  and if ." PullDown " then
  dup PullUp    and if ." PullUp " then
  dup %00110000 and 
  case 
    %000000 of ." 2mA " endof
    %010000 of ." 4mA " endof
    %100000 of ." 8mA " endof
    %110000 of ." 12mA " endof
  endcase
  dup IE        and if ." IE " then
      OD        and if ." OD " then
  ." )"
  ;

\ Pad-Bank modifiers, * leave the rest as it is if not used *
\ Example: "pin17 Schmitt PullDown PullUp or or PadOn" (PullDown wins in this case)
\ Drive strength constants setting bit 8 to identify that it should be modified
\ and clearing existing bits %00xx0000 position before usage
: PadOn ( pinConst bitMask -- ) \ Turns the wanted bits on
  swap padRegister dup @        \ -- bitMask padAddress padValue
  rot                           \ -- padAddress padValue bitMask 
  dup $100 >=
  if \ have to store strength
    swap %11001111 and \ cleared padValue at strength position
    swap $100 -        \ remove flag in bitMask
  then
  \ PullDown should win over PullUp, does not make sense to set both together
  dup PullUp PullDown or and
  if 
    swap %11110011 and \ cleared Pull-Pins in padValue
    swap dup PullDown and 
    if   PullDown or PullUp   not and
    else PullUp   or PullDown not and
    then
  then
  or swap ! ;  
\ padoff Does not modify strength and if one of the two pull bits is set in bitMask both are turned off
: PadOff ( pinConst bitMask -- ) \ Turns the wanted bits off
  swap padRegister dup @ rot 
  dup PullUp PullDown or and  \ One of both set for padoff - turn pulling off
  if swap %11110011 and swap then    
  not and swap ! ;

: input  ( pinConst -- ) GPIO_OE_CLR ! ;
\ Usually called from high/low/toggle
: output ( pinConst -- ) GPIO_OE_SET ! ;

: high   ( pinConst -- ) dup output GPIO_OUT_SET ! ;
: low    ( pinConst -- ) dup output GPIO_OUT_CLR ! ;
: toggle ( pinConst -- ) dup output GPIO_OUT_XOR ! ;

: ?bitSet  ( value bitNo -- t/f )             \ results true, if bit position bitNo is set in value
  1 swap lshift and 0<> ;
: bitmask ( bitCount -- ) 1 swap lshift 1- ; \ Calculates all bitCount values set to 1


: .highlow ( t/f -- )                         \ Outputs (high) or (low) depending of stack value
  if ." HIGH " else ." low  " then ;

: .pin ( pinConst -- )                        \ Shows status of one pin (input/output, value and pad settings)
  cr dup dup ( for .pad ) pin2no ." pin" dup . 10 < if ."  " then ." = "
  dup GPIO_OE @ and 
  if 
    GPIO_OUT @ and .highlow
    ." Output " .pad
  else 
    GPIO_IN @ and .highlow
    ." Input  " .pad
  then ;

: .pins                                       \ Shows actual status of all pins, must be converted to one high bit at correct position
  cr 30 0 do 1 i lshift .pin loop ;

: ?input ( pinConst -- t/f )                  \ Determines the status of pin-Number pinNo, False if unset
   GPIO_IN @ and ;
: .input ( pinConst -- )                      \ Displays input port pinNo status in a human readable format
   dup pin2no ." pin" . ." = " ?input .highlow ;

0 variable bitstore
: !outbits ( minPinConst bitCount value -- ) \ outputs the bitCount lsb bits of value to minPinConst sequential upwards
                                              \ without using the pio functions, realized bitwise
  ( set high part ) rot pin2no dup -rot lshift dup swap bitstore ! high
  ( set low part )  swap 0 swap 1+ 0 do 1 i lshift + loop swap lshift ( shifted and mask with all bits)
                    bitstore @ not and low
;
: ?inbits ( minPinConst bitCount -- value)   \ reads bitCount bits from minPinConst sequential upwards into value
  bitmask swap 
  pin2no 2dup lshift GPIO_IN @ and \ mask shiftCount HighShiftedResult
  swap rshift swap drop            \ shift it back and drop the mask
;

: .halfbyte # # # # $20 hold ;                                     \ Shows 4 bits in binary
: .binword  binary <# 8 0 do .halfbyte loop #> type decimal drop ; \ Shows 8 x halfbytes

: .inputs  cr GPIO_IN @ GPIO_OE @ not and 0 ." Inputs =" .binword ;                 \ Shows the input status bitwise
: .outputs cr GPIO_OUT @ GPIO_OE @ and 0 ." Outputs=" .binword ; 

\ Small Analog/Digital routines 
: adcvalue ( pinConst -- u ) \ message and 0 if it is no ADC pin, otherwise value between 0..4095
  \ for pinConst only pin26..pin29 (ADC VRef) is allowed
  dup pin2no 26 - dup 0 < if ." Only >= pin26 are for ADC allowed" drop 0 exit then
  swap dup IE padoff OD padon  \ manual says turn digital input IE off and OD on, see 4.9.1. red note page 571
  %11 ADC-CS !                 \ Power on ADC, temperature sensor enabled
  begin $100 ADC-CS bit@ until \ Wait for READY flag
  12 lshift %111 or ADC-CS !   \ Start conversion on %00-%11
  begin $100 ADC-CS bit@ until \ Wait for READY flag
  ADC-RESULT @ ;               \ Fetch conversion result
\ Convert ADC result in voltage reading
\ ToDo: CF - read out the banks voltage, can also be 1.8V!
: adc>u ( u -- f ) 0 swap 3,3 4096,0 f/ f*  1-foldable ; 
: .adcvolt ( pinConst -- ) \ shows the current voltage for pin26..pin29
  adcvalue dup hex. ." : "
               adc>u 3 f.n ." V " cr ;

: many ( -- ) key? 0= if 0 >in ! then ; 

0 variable timescounter
: times ( u -- )
  timescounter @ 
  if drop -1 timescounter +!                  \ decrement by -1 and store in timescounter
  else dup 1 u>                               
    if 1- timescounter !                      \ if not > 1 -> store true as marker we have done all repetitions
    else drop 
    then                         
  then
  timescounter @ 
  if 0 >in ! then                             \ timescounter <> False (-1), then run input line (again)
;

\ A few small usage examples
\ LED anode with pre resistor at pin17, cathode to GND
: blink17 ( -- )
  pin17 high 250 ms
  pin17 low 250 ms ;

\ beeper at pin12 to GND, beeps for 1 second
: beep 500 0 do pin12 toggle 2 ms loop ;

\ combined usage
: flashsound pin17 toggle beep pin17 toggle beep ;
\ count the pins upwards pin17..pin20 in binary
: countit 16 0 do pin17 4 i !outbits 200 ms loop pin17 4 0 !outbits ;
