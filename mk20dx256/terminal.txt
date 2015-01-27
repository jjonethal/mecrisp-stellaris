: clrscr $1B emit ." [2J" ;
: gronbl $1b emit ." [32" $3b emit ." 40m" ;

1 constant bright
2 constant dim
4 constant underscore
5 constant blink
7 constant reverse
8 constant hidden
30 constant fg-black
31 constant fg-red
32 constant fg-green
33 constant fg-yellow
34 constant fg-blue
35 constant fg-magenta
36 constant fg-cyan
37 constant fg-white
40 constant fg-black
41 constant bg-red
42 constant bg-green
43 constant bg-yellow
44 constant bg-blue
45 constant bg-magenta
46 constant bg-cyan
47 constant bg-white

: ansi-set $1b emit $5b emit <# #S #> type $6d emit ;
