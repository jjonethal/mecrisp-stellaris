\ The blackpill board contains an active low user LED connected to PC13.
: init-led ( -- )
    1 2 RCC_AHB1ENR >bit-band ! \ Enable GPIO port C

    true 13 13 >bits GPIOC_OTYPER  bis!   \ Active low LEDs are best combined open drain pins
    true 13 13 >bits GPIOC_BSRR    bis!   \ Disable the LED
     %01 27 26 >bits GPIOC_MODER   bis!   \ Configure PC13 as output
    
    %1 16 16 >bits true 13 13 +bits GPIOC_LCKR !
    %0 16 16 >bits true 13 13 +bits GPIOC_LCKR !
    %1 16 16 >bits true 13 13 +bits GPIOC_LCKR !
    GPIOC_LCKR @ drop ;
    
\ Write/read user LED state
: led! ( ? -- )
    0=                                       \ to canonical boolean (all 1, all 0)
    13 bit 31 16 >bits 13 bit 15 0 +bits and \ keep only bits controlling PC13
    13 bit 31 16 >bits xor                   \ invert reset bit
    GPIOC_BSRR ! ;                           \ Write to bit set reset register

: led@ ( -- ? )
    GPIOC_ODR @    \ Read port output register
    31 13 - lshift \ Shift PC13 into MSB
    31 arshift     \ Expand into proper Forth boolean
    not ;          \ Negate because the LED ist active low
