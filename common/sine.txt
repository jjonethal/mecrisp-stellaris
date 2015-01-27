
compiletoflash

\ Sine and Cosine with Cordic algorithm

: numbertable <builds does> swap 2 lshift + @ ;

hex
numbertable e^ka

C90FDAA2 ,
76B19C15 ,
3EB6EBF2 ,
1FD5BA9A ,
0FFAADDB ,
07FF556E ,
03FFEAAB ,
01FFFD55 ,

00FFFFAA ,
007FFFF5 ,
003FFFFE ,
001FFFFF ,
000FFFFF ,
0007FFFF ,
0003FFFF ,
0001FFFF ,

0000FFFF ,
00007FFF ,
00003FFF ,
00001FFF ,
00000FFF ,
000007FF ,
000003FF ,
000001FF ,

000000FF ,
0000007F ,
0000003F ,
0000001F ,
0000000F ,
00000007 ,
00000003 ,
00000001 ,

decimal

: 2rshift 0 ?do d2/ loop ;

: cordic ( f-angle -- f-error f-sine f-cosine )
         ( Angle between -Pi/2 and +Pi/2 ! )
  0 0 $9B74EDA8 0
  32 0 do
    2rot dup 0<
    if
      i e^ka 0 d+ 2rot 2rot
            2over i 2rshift 2rot 2rot
      2swap 2over i 2rshift
      d- 2rot 2rot d+
    else
      i e^ka 0 d- 2rot 2rot
            2over i 2rshift 2rot 2rot
      2swap 2over i 2rshift
      d+ 2rot 2rot 2swap d-
    then
  loop
2-foldable ;

: sine   ( f-angle -- f-sine )   cordic 2drop 2nip   2-foldable ;
: cosine ( f-angle -- f-cosine ) cordic 2nip  2nip   2-foldable ;

3,141592653589793  2constant pi
pi 2,0 f/ 2constant pi/2
pi 4,0 f/ cosine f. \ Displays cos(Pi/4)

: widecosine ( f-angle -- f-cosine )
  dabs
  pi/2 ud/mod drop 3 and ( Quadrant f-angle )

  case
    0 of                 cosine         endof
    1 of dnegate pi/2 d+ cosine dnegate endof
    2 of                 cosine dnegate endof
    3 of dnegate pi/2 d+ cosine         endof
  endcase

  2-foldable ;

: widesine ( f-angle -- f-sine )
  dup >r \ Save sign
  dabs
  pi/2 ud/mod drop 3 and ( Quadrant f-angle )

  case
    0 of                 sine          endof
    1 of dnegate pi/2 d+ sine          endof
    2 of                 sine  dnegate endof
    3 of dnegate pi/2 d+ sine  dnegate endof
  endcase

  r> ?dnegate
  2-foldable ;
