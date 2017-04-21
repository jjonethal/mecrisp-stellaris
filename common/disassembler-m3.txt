
\ Partial ARM Cortex M3/M4 Disassembler, Copyright (C) 2013  Matthias Koch
\ This is free software under GNU General Public License v3.
\ Knows all M0 and some M3/M4 machine instructions, 
\ resolves call entry points, literal pools and handles inline strings.
\ Usage: Specify your target address in disasm-$ and give disasm-step some calls.

\ ------------------------
\  A quick list of words 
\ ------------------------

: list ( -- )
  cr
  dictionarystart 
  begin
    dup 6 + ctype space
    dictionarynext
  until
  drop
;

\ ---------------------------------------
\  Memory pointer and instruction fetch
\ ---------------------------------------

0 variable disasm-$   \ Current position for disassembling

: disasm-fetch        \ ( -- Data ) Fetches opcodes and operands, increments disasm-$
    disasm-$ @ h@     \             Holt Opcode oder Operand, incrementiert disasm-$
  2 disasm-$ +!   ;

\ --------------------------------------------------
\  Try to find address as code start in Dictionary 
\ --------------------------------------------------

: disasm-string ( -- ) \ Takes care of an inline string
  disasm-$ @ dup ctype skipstring disasm-$ !
;

: name. ( Address -- ) \ If the address is Code-Start of a dictionary word, it gets named.
  1 bic \ Thumb has LSB of address set.

  >r
  dictionarystart
  begin
    dup   6 + dup skipstring r@ = if ."   --> " ctype else drop then
    dictionarynext
  until
  drop
  r> 

  case \ Check for inline strings ! They are introduced by calls to ." or s" internals.
    ['] ." $1E + of ."   -->  .' " disasm-string ." '" endof \ It is ." runtime ?
    ['] s"  $4 + of ."   -->  s' " disasm-string ." '" endof \ It is .s runtime ?
    ['] c"  $4 + of ."   -->  c' " disasm-string ." '" endof \ It is .c runtime ?
  endcase
;

\ -------------------
\  Beautiful output
\ -------------------

: u.4  0 <# # # # # #> type ;
: u.8  0 <# # # # # # # # # #> type ;
: u.ns 0 <# #s #> type ;
: const. ."  #" u.ns ;
: addr. u.8 ;

: register. ( u -- )
  case 
    13 of ."  sp" endof
    14 of ."  lr" endof
    15 of ."  pc" endof
    dup ."  r" decimal u.ns hex 
  endcase ;

\ ----------------------------------------
\  Disassembler logic and opcode cutters
\ ----------------------------------------

: opcode? ( Opcode Bits Mask -- Opcode ? ) \ (Opcode and Mask) = Bits
  rot ( Bits Mask Opcode )
  tuck ( Bits Opcode Mask Opcode )
  and ( Bits Opcode Opcode* )
  rot ( Opcode Opcode* Bits )
  =
;

: reg.    ( Opcode Position -- Opcode ) over swap rshift  $7 and register. ;
: reg16.  ( Opcode Position -- Opcode ) over swap rshift  $F and register. ;
: reg16split. ( Opcode -- Opcode ) dup $0007 and over 4 rshift $0008 and or register. ;
: registerlist. ( Opcode -- Opcode ) 8 0 do dup 1 i lshift and if i register. space then loop ;

: imm3. ( Opcode Position -- Opcode ) over swap rshift  $7  and const. ;
: imm5. ( Opcode Position -- Opcode ) over swap rshift  $1F and const. ;
: imm8. ( Opcode Position -- Opcode ) over swap rshift  $FF and const. ;

: imm3<<1. ( Opcode Position -- Opcode ) over swap rshift  $7  and shl const. ;
: imm5<<1. ( Opcode Position -- Opcode ) over swap rshift  $1F and shl const. ;
: imm8<<1. ( Opcode Position -- Opcode ) over swap rshift  $FF and shl const. ;

: imm3<<2. ( Opcode Position -- Opcode ) over swap rshift  $7  and shl shl const. ;
: imm5<<2. ( Opcode Position -- Opcode ) over swap rshift  $1F and shl shl const. ;
: imm7<<2. ( Opcode Position -- Opcode ) over swap rshift  $7F and shl shl const. ;
: imm8<<2. ( Opcode Position -- Opcode ) over swap rshift  $FF and shl shl const. ;

: condition. ( Condition -- )
  case
    $0 of ." eq" endof  \ Z set
    $1 of ." ne" endof  \ Z clear
    $2 of ." cs" endof  \ C set
    $3 of ." cc" endof  \ C clear
                       
    $4 of ." mi" endof  \ N set
    $5 of ." pl" endof  \ N clear
    $6 of ." vs" endof  \ V set
    $7 of ." vc" endof  \ V clear
                       
    $8 of ." hi" endof  \ C set Z clear
    $9 of ." ls" endof  \ C clear or Z set
    $A of ." ge" endof  \ N == V
    $B of ." lt" endof  \ N != V
                       
    $C of ." gt" endof  \ Z==0 and N == V
    $D of ." le" endof  \ Z==1 or N != V
  endcase
;

: rotateleft  ( x u -- x ) 0 ?do rol loop ;
: rotateright ( x u -- x ) 0 ?do ror loop ;

: imm12. ( Opcode -- Opcode )
  dup $FF and                 \ Bits 0-7
  over  4 rshift $700 and or  \ Bits 8-10
  over 15 rshift $800 and or  \ Bit  11
  ( Opcode imm12 )
  dup 8 rshift
  case
    0 of $FF and                                  const. endof \ Plain 8 Bit Constant
    1 of $FF and                 dup 16 lshift or const. endof \ 0x00XY00XY
    2 of $FF and        8 lshift dup 16 lshift or const. endof \ 0xXY00XY00
    3 of $FF and dup 8 lshift or dup 16 lshift or const. endof \ 0xXYXYXYXY

    \ Shifted 8-Bit Constant
    swap
      \ Otherwise, the 32-bit constant is rotated left until the most significant bit is bit[7]. The size of the left
      \ rotation is encoded in bits[11:7], overwriting bit[7]. imm12 is bits[11:0] of the result.
      dup 7 rshift swap $7F and $80 or swap rotateright const.
  endcase
;

\ --------------------------------------
\  Name resolving for blx r0 sequences
\ --------------------------------------

0 variable destination-r0

\ ----------------------------------
\  Single instruction disassembler
\ ----------------------------------

: disasm-thumb-2 ( Opcode16 -- Opcode16 )
  dup 16 lshift disasm-fetch or ( Opcode16 Opcode32 )

  $F000D000 $F800D000 opcode? if  \ BL
                                ( Opcode )
                                ." bl  "
                                dup $7FF and ( Opcode DestinationL )
                                over ( Opcode DestinationL Opcode )
                                16 rshift $7FF and ( Opcode DestinationL DestinationH )
                                dup $400 and if $FFFFF800 or then ( Opcode DestinationL DestinationHsigned )
                                11 lshift or ( Opcode Destination )
                                shl 
                                disasm-$ @ +
                                dup addr. name. \ Try to resolve destination
                              then

  \ MOVW / MOVT
  \ 1111 0x10 t100 xxxx 0xxx dddd xxxx xxxx
  \ F    2    4    0    0    0    0    0
  \ F    B    7    0    8    0    0    0

  $F2400000 $FB708000 opcode? if \ MOVW / MOVT
                                ( Opcode )
                                dup $00800000 and if ." movt"
                                                  else ." movw"
                                                  then

                                8 reg16. \ Destination register

                                \ Extract 16 Bit constant from opcode:
                                dup        $FF and              ( Opcode Constant* )
                                over     $7000 and  4 rshift or ( Opcode Constant** )
                                over $04000000 and 15 rshift or ( Opcode Constant*** )
                                over $000F0000 and  4 rshift or ( Opcode Constant )
                                dup ."  #" u.4
                                ( Opcode Constant )
                                over $00800000 and if 16 lshift destination-r0 @ or destination-r0 !
                                                   else                             destination-r0 !
                                                   then
                              then

  \ 
  \ 1111 0i0x xxxs nnnn 0iii dddd iiii iiii
  \ F    0    0    0    0    0    0    0
  \ F    A    0    0    8    0    0    0

  $F0000000 $FA008000 opcode? not if else \ Data processing, modified 12-bit immediate
                                dup 21 rshift $F and
                                case
                                  %0000 of ." and" endof
                                  %0001 of ." bic" endof
                                  %0010 of ." orr" endof
                                  %0011 of ." orn" endof
                                  %0100 of ." eor" endof
                                  %1000 of ." add" endof
                                  %1010 of ." adc" endof
                                  %1011 of ." sbc" endof
                                  %1101 of ." sub" endof
                                  %1110 of ." rsb" endof
                                  ." ?"
                                endcase
                                dup 1 20 lshift and if ." s" then \ Set Flags ?
                                8 reg16. 16 reg16. \ Destionation and Source registers
                                imm12.
                              then

  case \ Decode remaining "singular" opcodes used in Mecrisp-Stellaris:

    $EA5F0676 of ." rors r6 r6 #1" endof

    $F8470D04 of ." str r0 [ r7 #-4 ]!" endof
    $F8471D04 of ." str r1 [ r7 #-4 ]!" endof
    $F8472D04 of ." str r2 [ r7 #-4 ]!" endof
    $F8473D04 of ." str r3 [ r7 #-4 ]!" endof
    $F8476D04 of ." str r6 [ r7 #-4 ]!" endof

    $F8576026 of ." ldr r6 [ r7 r6 lsl #2 ]" endof
    $F85D6C08 of ." ldr r6 [ sp #-8 ]" endof

    $FAB6F686 of ." clz r6 r6" endof

    $FB90F6F6 of ." sdiv r6 r0 r6" endof
    $FBB0F6F6 of ." udiv r6 r0 r6" endof
    $FBA00606 of ." umull r0 r6 r0 r6" endof
    $FBA00806 of ." smull r0 r6 r0 r6" endof

  endcase \ Case drops Opcode32
  ( Opcode16 )
;

: disasm ( -- ) \ Disassembles one machine instruction and advances disasm-$

disasm-fetch \ Instruction opcode on stack the whole time.

$4140 $FFC0 opcode? if ." adcs"  0 reg. 3 reg. then          \ ADC
$1C00 $FE00 opcode? if ." adds" 0 reg. 3 reg. 6 imm3. then   \ ADD(1) small immediate two registers
$3000 $F800 opcode? if ." adds" 8 reg. 0 imm8. then          \ ADD(2) big immediate one register
$1800 $FE00 opcode? if ." adds" 0 reg. 3 reg. 6 reg. then    \ ADD(3) three registers
$4400 $FF00 opcode? if ." add"  reg16split. 3 reg16. then    \ ADD(4) two registers one or both high no flags
$A000 $F800 opcode? if ." add"  8 reg. ."  pc " 0 imm8<<2. then  \ ADD(5) rd = pc plus immediate
$A800 $F800 opcode? if ." add"  8 reg. ."  sp " 0 imm8<<2. then  \ ADD(6) rd = sp plus immediate
$B000 $FF80 opcode? if ." add sp" 0 imm7<<2. then            \ ADD(7) sp plus immediate

$4000 $FFC0 opcode? if ." ands" 0 reg. 3 reg. then           \ AND
$1000 $F800 opcode? if ." asrs" 0 reg. 3 reg. 6 imm5. then   \ ASR(1) two register immediate
$4100 $FFC0 opcode? if ." asrs" 0 reg. 3 reg. then           \ ASR(2) two register
$D000 $F000 opcode? not if else dup $0F00 and 8 rshift       \ B(1) conditional branch
                       case
                         $00 of ." beq" endof  \ Z set
                         $01 of ." bne" endof  \ Z clear
                         $02 of ." bcs" endof  \ C set
                         $03 of ." bcc" endof  \ C clear
                       
                         $04 of ." bmi" endof  \ N set
                         $05 of ." bpl" endof  \ N clear
                         $06 of ." bvs" endof  \ V set
                         $07 of ." bvc" endof  \ V clear
                       
                         $08 of ." bhi" endof  \ C set Z clear
                         $09 of ." bls" endof  \ C clear or Z set
                         $0A of ." bge" endof  \ N == V
                         $0B of ." blt" endof  \ N != V
                       
                         $0C of ." bgt" endof  \ Z==0 and N == V
                         $0D of ." ble" endof  \ Z==1 or N != V
                         \ $0E: Undefined Instruction
                         \ $0F: SWI                       
                       endcase
                       space
                       dup $FF and dup $80 and if $FFFFFF00 or then
                       shl disasm-$ @ 1 bic + 2 + addr. 
                    then

$E000 $F800 opcode? if ." b"                                 \ B(2) unconditional branch
                      dup $7FF and shl
                      dup $800 and if $FFFFF000 or then
                      disasm-$ @ + 2+                     
                      space addr.
                    then

$4380 $FFC0 opcode? if ." bics" 0 reg. 3 reg. then           \ BIC
$BE00 $FF00 opcode? if ." bkpt" 0 imm8. then                 \ BKPT

\ BL/BLX handled as Thumb-2 instruction on M3/M4.

$4780 $FF87 opcode? if ." blx"  3 reg16. then                \ BLX(2)
$4700 $FF87 opcode? if ." bx"   3 reg16. then                \ BX
$42C0 $FFC0 opcode? if ." cmns" 0 reg. 3 reg. then           \ CMN
$2800 $F800 opcode? if ." cmp"  8 reg. 0 imm8. then          \ CMP(1) compare immediate
$4280 $FFC0 opcode? if ." cmp"  0 reg. 3 reg. then           \ CMP(2) compare register
$4500 $FF00 opcode? if ." cmp"  reg16split. 3 reg16. then    \ CMP(3) compare high register
$B660 $FFE8 opcode? if ." cps"  0 imm5. then                 \ CPS
$4040 $FFC0 opcode? if ." eors" 0 reg. 3 reg. then           \ EOR

$C800 $F800 opcode? if ." ldmia" 8 reg. ."  {" registerlist. ." }" then     \ LDMIA

$6800 $F800 opcode? if ." ldr" 0 reg. ."  [" 3 reg. 6 imm5<<2. ."  ]" then  \ LDR(1) two register immediate
$5800 $FE00 opcode? if ." ldr" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then      \ LDR(2) three register
$4800 $F800 opcode? if ." ldr" 8 reg. ."  [ pc" 0 imm8<<2. ."  ]  Literal " \ LDR(3) literal pool
                       dup $FF and shl shl ( Opcode Offset ) \ Offset for PC
                       disasm-$ @ 2+ 3 bic + ( Opcode Address )
                       dup addr. ." : " @ addr. then

$9800 $F800 opcode? if ." ldr"  8 reg. ."  [ sp" 0 imm8<<2. ."  ]" then     \ LDR(4)

$7800 $F800 opcode? if ." ldrb" 0 reg. ."  [" 3 reg. 6 imm5. ."  ]" then    \ LDRB(1) two register immediate
$5C00 $FE00 opcode? if ." ldrb" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ LDRB(2) three register

$8800 $F800 opcode? if ." ldrh" 0 reg. ."  [" 3 reg. 6 imm5<<1. ."  ]" then \ LDRH(1) two register immediate
$5A00 $FE00 opcode? if ." ldrh" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ LDRH(2) three register

$5600 $FE00 opcode? if ." ldrsb" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then    \ LDRSB
$5E00 $FE00 opcode? if ." ldrsh" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then    \ LDRSH

$0000 $F800 opcode? if ." lsls" 0 reg. 3 reg. 6 imm5. then   \ LSL(1)
$4080 $FFC0 opcode? if ." lsls" 0 reg. 3 reg. then           \ LSL(2) two register
$0800 $F800 opcode? if ." lsrs" 0 reg. 3 reg. 6 imm5. then   \ LSR(1) two register immediate
$40C0 $FFC0 opcode? if ." lsrs" 0 reg. 3 reg. then           \ LSR(2) two register
$2000 $F800 opcode? if ." movs" 8 reg. 0 imm8. then          \ MOV(1) immediate
$1C00 $FFC0 opcode? if ." movs" 0 reg. 3 reg. then           \ MOV(2) two low registers
$4600 $FF00 opcode? if ." mov" reg16split. 3 reg16. then     \ MOV(3)

$4340 $FFC0 opcode? if ." muls" 0 reg. 3 reg. then           \ MUL
$43C0 $FFC0 opcode? if ." mvns" 0 reg. 3 reg. then           \ MVN
$4240 $FFC0 opcode? if ." negs" 0 reg. 3 reg. then           \ NEG
$4300 $FFC0 opcode? if ." orrs" 0 reg. 3 reg. then           \ ORR

$BC00 $FE00 opcode? if ." pop {"  registerlist. dup $0100 and if ."  pc " then ." }" then \ POP
$B400 $FE00 opcode? if ." push {" registerlist. dup $0100 and if ."  lr " then ." }" then \ PUSH

$BA00 $FFC0 opcode? if ." rev"   0 reg. 3 reg. then         \ REV
$BA40 $FFC0 opcode? if ." rev16" 0 reg. 3 reg. then         \ REV16
$BAC0 $FFC0 opcode? if ." revsh" 0 reg. 3 reg. then         \ REVSH
$41C0 $FFC0 opcode? if ." rors"  0 reg. 3 reg. then         \ ROR
$4180 $FFC0 opcode? if ." sbcs"  0 reg. 3 reg. then         \ SBC
$B650 $FFF7 opcode? if ." setend" then                      \ SETEND

$C000 $F800 opcode? if ." stmia" 8 reg. ."  {" registerlist. ." }" then     \ STMIA

$6000 $F800 opcode? if ." str" 0 reg. ."  [" 3 reg. 6 imm5<<2. ."  ]" then  \ STR(1) two register immediate
$5000 $FE00 opcode? if ." str" 0 reg. ."  [" 3 reg. 6 reg. ."  ]" then      \ STR(2) three register
$9000 $F800 opcode? if ." str" 8 reg. ."  [ sp + " 0 imm8<<2. ."  ]" then   \ STR(3)

$7000 $F800 opcode? if ." strb" 0 reg. ."  [" 3 reg. 6 imm5. ."  ]" then    \ STRB(1) two register immediate
$5400 $FE00 opcode? if ." strb" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ STRB(2) three register

$8000 $F800 opcode? if ." strh" 0 reg. ."  [" 3 reg. 6 imm5<<1. ."  ]" then \ STRH(1) two register immediate
$5200 $FE00 opcode? if ." strh" 0 reg. ."  [" 3 reg. 6 reg.  ."  ]" then    \ STRH(2) three register

$1E00 $FE00 opcode? if ." subs" 0 reg. 3 reg. 6 imm3. then   \ SUB(1)
$3800 $F800 opcode? if ." subs" 8 reg. 0 imm8. then          \ SUB(2)
$1A00 $FE00 opcode? if ." subs" 0 reg. 3 reg. 6 reg. then    \ SUB(3)
$B080 $FF80 opcode? if ." sub sp" 0 imm7<<2. then            \ SUB(4)

$DF00 $FF00 opcode? if ." swi"  0 imm8. then                 \ SWI
$B240 $FFC0 opcode? if ." sxtb" 0 reg. 3 reg. then           \ SXTB
$B200 $FFC0 opcode? if ." sxth" 0 reg. 3 reg. then           \ SXTH
$4200 $FFC0 opcode? if ." tst"  0 reg. 3 reg. then           \ TST
$B2C0 $FFC0 opcode? if ." uxtb" 0 reg. 3 reg. then           \ UXTB
$B280 $FFC0 opcode? if ." uxth" 0 reg. 3 reg. then           \ UXTH


\ 16 Bit Thumb-2 instruction ?

$BF00 $FF00 opcode? not if else                              \ IT...
                      dup $000F and
                      case
                        $8 of ." it" endof

                        over $10 and if else $8 xor then
                        $C of ." itt" endof
                        $4 of ." ite" endof

                        over $10 and if else $4 xor then
                        $E of ." ittt" endof
                        $6 of ." itet" endof
                        $A of ." itte" endof
                        $2 of ." itee" endof

                        over $10 and if else $2 xor then
                        $F of ." itttt" endof
                        $7 of ." itett" endof
                        $B of ." ittet" endof
                        $3 of ." iteet" endof
                        $D of ." ittte" endof
                        $5 of ." itete" endof
                        $9 of ." ittee" endof
                        $1 of ." iteee" endof
                      endcase
                      space
                      dup $00F0 and 4 rshift condition.
                    then

\ 32 Bit Thumb-2 instruction ?

$E800 $F800 opcode? if disasm-thumb-2 then
$F000 $F000 opcode? if disasm-thumb-2 then


\ If nothing of the above hits: Invalid Instruction... They are not checked for.

\ Try name resolving for blx r0 sequences:

$2000 $FF00 opcode? if dup $FF and destination-r0  ! then \ movs r0, #...
$3000 $FF00 opcode? if dup $FF and destination-r0 +! then \ adds r0, #...
$0000 $F83F opcode? if destination-r0 @                   \ lsls r0, r0, #...
                         over $07C0 and 6 rshift lshift
                       destination-r0 ! then
dup $4780 =         if destination-r0 @ name. then        \ blx r0

drop \ Forget opcode
; \ disasm

\ ------------------------------
\  Single instruction printing
\ ------------------------------

: memstamp \ ( Addr -- ) Shows a memory location nicely
    dup u.8 ." : " h@ u.4 ."   " ;

: disasm-step ( -- )
    disasm-$ @                 \ Note current position
    dup memstamp disasm cr     \ Disassemble one instruction

    begin \ Write out all disassembled memory locations
      2+ dup disasm-$ @ <>
    while
      dup memstamp cr
    repeat
    drop
;

\ ------------------------------
\  Disassembler for definitions
\ ------------------------------

: seec ( -- ) \ Continues to see
  base @ hex cr

  begin
    disasm-$ @ h@           $4770 =  \ Flag: Loop terminates with bx lr
    disasm-$ @ h@ $FF00 and $BD00 =  \ Flag: Loop terminates with pop { ... pc }
    or
    disasm-step
  until

  base !
;

: see ( -- ) \ Takes name of definition and shows its contents from beginning to first ret
  ' disasm-$ !
  seec
;
