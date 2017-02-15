\ assembler

: b0 ( n -- n ) 1 and 1-foldable inline ;
: b3:0 ( n -- n ) $f and 1-foldable inline ;
: b7:0 ( n -- n ) $ff and 1-foldable inline ;


\ b15:0 b8 b7 b5 b3:0 hb15:12 hb11:8 hb7:0

\ u 1:+imm8 0:-imm8 p:0-[pn] p:1-[pn+/-imm8] rt=mem[adr] rt2=mem[adr+4]
: LDRD_IMM ( imm8 rt rt2 rn p u w -- ) \ A7.7.49 LDRD (immediate)
   $E850   swap         \ opcode
   b0 #5 lshift or      \ w
   swap b0 #7 lshift or \ u
   swap b0 #8 lshift or \ p 
   b3_0 or              \ rn
   h,
   b3_0 #8 lshift           \ rt2
   swap b3_0 #12 lshift or  \ rt
   swap b7_0 or             \ imm8
   h, ;  
