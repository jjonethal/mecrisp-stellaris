\ hex output and dump utilities
\ adapted from mecrisp 2.0.2 (GPL3)

: .v ( ... -- ... )  \ view stack, this is a slightly cleaner version of .s
  depth 100 u< if
    ." Stack #" depth . ." < "
    \ -1 depth negate ?do sp@ i 2+ cells - @ . loop
    -1 depth negate ?do
      sp@ i 2+ cells - @
      dup $10000 u> if [char] $ emit hex. else . then
    loop
    ." >" cr
  else
    ." Stack underflow (" depth . ." )" cr
  then ;

: u.4 ( u -- ) 0 <# # # # # #> type ;
: u.2 ( u -- ) 0 <# # # #> type ;

: h.4 ( u -- ) base @ hex swap  u.4  base ! ;
: h.2 ( u -- ) base @ hex swap  u.2  base ! ;

$FF variable hex.empty  \ needs to be variable, some flash is zero when empty

: hexdump ( -- ) \ dumps entire flash as Intel hex
  cr
\ STM32F103x8: Complete: $FFFF $0000
\ STM32F103xB: 128 KB would need a somewhat different hex file format
  $FFFF $0000  \ Complete image with Dictionary
  do
    \ Check if this line is entirely empty:
    0                 \ Not worthy to print
    i #16 + i do      \ Scan data
      i c@ hex.empty @ <> or  \ Set flag if there is a non-empty byte
    loop

    if
      ." :10" i h.4 ." 00"  \ Write record-intro with 4 digits.
      $10           \ Begin checksum
      i          +  \ Sum the address bytes
      i 8 rshift +  \ separately into the checksum

      i #16 + i do
        i c@ h.2  \ Print data with 2 digits
        i c@ +    \ Sum it up for Checksum
      loop

      negate h.2  \ Write Checksum
      cr
    then

  #16 +loop
  ." :00000001FF" cr
;

\ adapted from mecrisp-stellaris 2.2.1a (GPL3)

: dump16 ( addr -- )  \ print 16 bytes memory
  $F bic
  dup hex. 2 spaces

  dup #16 + over do
    i c@ h.2 space  \ Print data with 2 digits
    i $F and 7 = if 2 spaces then
  loop

  2 spaces

  dup 16 + swap do
        i c@ $20 u>= i c@ $7F u< and if i c@ else [char] . then emit
        i $F and 7 = if space then
      loop

  cr
;

: dump ( addr len -- )  \ print a memory region
  cr
  over $F and if #16 + then  \ one more line if not aligned on 16
  begin
    swap ( len addr )
    dup dump16
    #16 + ( len addr+16 )
    swap #16 - ( addr+16 len-16 )
    dup 0 <=
  until
  2drop
;
