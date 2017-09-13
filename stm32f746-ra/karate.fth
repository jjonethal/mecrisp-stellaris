

 +-B----------+
 |            |
 |            |
 |            |
 +------------+
 
\ ********* Sprite editor ****************

Animated Sprite 2D :
SpriteName:
SpriteFrame:

SpriteImage:
Sprite Image Format X,Y , W,H
FigureSprite
32 constant SpriteHeight
32 constant SpriteWidth

272 constant ScreenHeight
480 constant ScreenWidth
SpriteHight 272 3 /

10 constant ground \ ground pixel
40 constant top

Input:ArcadeStick
     Joystick    4-Switch Possible directions : N NO O SO S SW W NW
     6 buttons A,B,C,D , Start, Select


4096 constant sprite-size
SystemClock 200.000.000 
Frame Rate 30 fps
Ops/ Frame = 6.666.666

Ops/Sprite= 1024*2 = 2048
Max Sprites/Frame = 3255 ohne sound
1MB 512KB

Punches
normal light 3, hard 5
crouch light 3, hard 5
aerial light 5, hard 7
     
Kicks
normal light 3, hard 5
crouch light 3, hard 5
aerial light 5, hard 7

Action Fighting
48 Animation Frames / Sprite
512kb / 1024 Bytes/spriteframe = 512 Sprite frames in 512 KB Flash bei 32x32x8 Sprites

            1         2         3
   12345678901234567890123456789012
  1                               
  2         ****                   
  3     *        *                 
  4
  5
  6
  7
  8
  9
 10
 11
 12
 13
 14
 15
 16
 17
 18
 19
 20
 21
 22
 23
 24
 25
 26
 27
 28
 29
 30
 31
 32
