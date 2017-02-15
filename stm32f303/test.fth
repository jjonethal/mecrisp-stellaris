\ some concept

: words 2 * ;

3 words buffer: accel-data
3 words buffer: compass-data
3 words buffer: gyro-data



0 variable pos-x
0 variable pos-y
0 variable pos-z
0 variable v-x
0 variable v-y
0 variable v-z
0 variable a-x
0 variable a-y
0 variable a-z
0 variable phi-x
0 variable phi-y
0 variable phi-z
0 variable w-x
0 variable w-y
0 variable x-z
0 variable al-x
0 variable al-y
0 variable al-z

: midi-generator
;

: application
   button 

tasks:
  ' sensor-data-read 0 task 
  ' usb-update       1 task
  '

: main
init
