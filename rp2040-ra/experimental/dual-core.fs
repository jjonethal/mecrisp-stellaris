$D0000000 constant SIO_CPUID
$D0000004 constant SIO_GPIO_IN
$D0000008 constant SIO_GPIO_HI_IN
$D0000010 constant SIO_GPIO_OUT
$D0000014 constant SIO_GPIO_OUT_SET
$D0000018 constant SIO_GPIO_OUT_CLR
$D000001C constant SIO_GPIO_OUT_XOR
$D0000020 constant SIO_GPIO_OE
$D0000024 constant SIO_GPIO_OE_SET
$D0000028 constant SIO_GPIO_OE_CLR
$D000002C constant SIO_GPIO_OE_XOR
$D0000030 constant SIO_GPIO_HI_OUT
$D0000034 constant SIO_GPIO_HI_OUT_SET
$D0000038 constant SIO_GPIO_HI_OUT_CLR
$D000003C constant SIO_GPIO_HI_OUT_XOR
$D0000040 constant SIO_GPIO_HI_OE
$D0000044 constant SIO_GPIO_HI_OE_SET
$D0000048 constant SIO_GPIO_HI_OE_CLR
$D000004C constant SIO_GPIO_HI_OE_XOR
$D0000050 constant SIO_FIFO_ST
$D0000054 constant SIO_FIFO_WR
$D0000058 constant SIO_FIFO_RD
$D000005C constant SIO_SPINLOCK_ST
$D0000060 constant SIO_DIV_UDIVIDEND
$D0000064 constant SIO_DIV_UDIVISOR
$D0000068 constant SIO_DIV_SDIVIDEND
$D000006C constant SIO_DIV_SDIVISOR
$D0000070 constant SIO_DIV_QUOTIENT
$D0000074 constant SIO_DIV_REMAINDER
$D0000078 constant SIO_DIV_CSR
$D0000080 constant SIO_INTERP0_ACCUM0
$D0000084 constant SIO_INTERP0_ACCUM1
$D0000088 constant SIO_INTERP0_BASE0
$D000008C constant SIO_INTERP0_BASE1
$D0000090 constant SIO_INTERP0_BASE2
$D0000094 constant SIO_INTERP0_POP_LANE0
$D0000098 constant SIO_INTERP0_POP_LANE1
$D000009C constant SIO_INTERP0_POP_FULL
$D00000A0 constant SIO_INTERP0_PEEK_LANE0
$D00000A4 constant SIO_INTERP0_PEEK_LANE1
$D00000A8 constant SIO_INTERP0_PEEK_FULL
$D00000AC constant SIO_INTERP0_CTRL_LANE0
$D00000B0 constant SIO_INTERP0_CTRL_LANE1
$D00000B4 constant SIO_INTERP0_ACCUM0_ADD
$D00000B8 constant SIO_INTERP0_ACCUM1_ADD
$D00000BC constant SIO_INTERP0_BASE_1AND0
$D00000C0 constant SIO_INTERP1_ACCUM0
$D00000C4 constant SIO_INTERP1_ACCUM1
$D00000C8 constant SIO_INTERP1_BASE0
$D00000CC constant SIO_INTERP1_BASE1
$D00000D0 constant SIO_INTERP1_BASE2
$D00000D4 constant SIO_INTERP1_POP_LANE0
$D00000D8 constant SIO_INTERP1_POP_LANE1
$D00000DC constant SIO_INTERP1_POP_FULL
$D00000E0 constant SIO_INTERP1_PEEK_LANE0
$D00000E4 constant SIO_INTERP1_PEEK_LANE1
$D00000E8 constant SIO_INTERP1_PEEK_FULL
$D00000EC constant SIO_INTERP1_CTRL_LANE0
$D00000F0 constant SIO_INTERP1_CTRL_LANE1
$D00000F4 constant SIO_INTERP1_ACCUM0_ADD
$D00000F8 constant SIO_INTERP1_ACCUM1_ADD
$D00000FC constant SIO_INTERP1_BASE_1AND0
$D0000100 constant SIO_SPINLOCK0
$D0000104 constant SIO_SPINLOCK1
$D0000108 constant SIO_SPINLOCK2
$D000010C constant SIO_SPINLOCK3
$D0000110 constant SIO_SPINLOCK4
$D0000114 constant SIO_SPINLOCK5
$D0000118 constant SIO_SPINLOCK6
$D000011C constant SIO_SPINLOCK7
$D0000120 constant SIO_SPINLOCK8
$D0000124 constant SIO_SPINLOCK9
$D0000128 constant SIO_SPINLOCK10
$D000012C constant SIO_SPINLOCK11
$D0000130 constant SIO_SPINLOCK12
$D0000134 constant SIO_SPINLOCK13
$D0000138 constant SIO_SPINLOCK14
$D000013C constant SIO_SPINLOCK15
$D0000140 constant SIO_SPINLOCK16
$D0000144 constant SIO_SPINLOCK17
$D0000148 constant SIO_SPINLOCK18
$D000014C constant SIO_SPINLOCK19
$D0000150 constant SIO_SPINLOCK20
$D0000154 constant SIO_SPINLOCK21
$D0000158 constant SIO_SPINLOCK22
$D000015C constant SIO_SPINLOCK23
$D0000160 constant SIO_SPINLOCK24
$D0000164 constant SIO_SPINLOCK25
$D0000168 constant SIO_SPINLOCK26
$D000016C constant SIO_SPINLOCK27
$D0000170 constant SIO_SPINLOCK28
$D0000174 constant SIO_SPINLOCK29
$D0000178 constant SIO_SPINLOCK30
$D000017C constant SIO_SPINLOCK31

$E000ED08 constant VTOR

: sev ( -- ) [ $BF40 h, ] inline ;

: led-init ( -- ) 1 25 lshift SIO_GPIO_OE_SET ! ;
: led-toggle ( -- ) 1 25 lshift SIO_GPIO_OUT_XOR ! ;

: underflow? ( -- ? ) SIO_FIFO_ST @ 28 lshift 31 arshift ;
: overflow?  ( -- ? ) SIO_FIFO_ST @ 29 lshift 31 arshift ;
: ready?     ( -- ? ) SIO_FIFO_ST @ 30 lshift 31 arshift ;
: valid?     ( -- ? ) SIO_FIFO_ST @ 31 lshift 31 arshift ;

: >fifo ( x -- ) begin ready? until SIO_FIFO_WR ! sev ;
: fifo> ( -- x ) begin valid? until SIO_FIFO_RD @ ;
: >fifo> ( x -- x ) >fifo fifo> ;
: drain ( -- ) begin valid? while fifo> drop repeat sev ;

: init ( -- ) led-init ;

64 cells                 constant stackspace
stackspace               buffer:  core1-ds-lo
stackspace core1-ds-lo + constant core1-ds-hi
stackspace               buffer:  core1-rs-lo
stackspace core1-ds-lo + constant core1-rs-hi

: trampoline [ $BCC3 h, $468e h, $4687 h, ] ; \ POP {r0, r1, rTOS, rPSP}; MOV lr, r1; MOV pc, r0

: launch ( xt -- )
    \ Prepare the 2nd core's return stack
    \   -16 : r0/PC = function to launch
    \   -12 : r1/LR = reset the core on return
    \    -8 : TOS   = stack canary
    \    -4 : PSP   = 2nd core parameter stack pointer

    \ Tag the function pointers with Thumb mode
    1 or core1-rs-hi 4 cells - tuck ! cell+
    ['] reset 1 or over ! cell+
    23 over ! cell+
    core1-ds-hi swap !

    \ Reimplement the protocol spoken between the BootROM and C SDK
    6 0 DO
        i CASE
            cr i .
            0 OF drain 0               ENDOF
            1 OF drain 0               ENDOF
            2 OF 1                     ENDOF
            3 OF VTOR @                ENDOF
            \ Pass the second core its prepared return stack
            4 OF core1-rs-hi 4 cells - ENDOF
            \ Pass a pointer to the trampoline to provide a sane
            \ execution environment to the launched function skipping
            \ over the first PUSH lr instruction and setting the mode
            \ to Thumb.
            5 OF ['] trampoline 3 +    ENDOF
        ENDCASE ( command )
        dup hex.
        dup >fifo> ( xt command response )
        dup hex.
        \ Advance to the next state if the response matches the command
        \ retry from the beginning on missmatch.
        = IF 1 ELSE i negate THEN ( xt delta )
    +LOOP ;

led-init
' led-toggle launch

\ doesn't work yet
: wait ( -- ) BEGIN key? UNTIL key drop ;
: dots ( n -- ) [char] | emit 0 ?do i >fifo [char] . emit loop [char] | emit cr ;
: test ( -- ) BEGIN fifo> dup dots 0= UNTIL ." !!!!" cr ;
: test ( -- ) 0 >r 0 >r unloop fifo> dup dots >fifo ." !!!!" cr ;
\ char A >fifo char B >fifo char C >fifo 
