\ Mask and insert x1 to fit into the bitfield [high:low] 
: >bits ( x1 high low -- x2 )
    tuck - 1+ -1 swap lshift rot swap bic swap lshift 3-foldable ;

\ Bitwise or the bitfield x2 into [high:low] of x1
: +bits ( x1 x2 high low -- x3 ) >bits or 4-foldable ;

: pll-init ( -- )
\ PLL configuration register:
\   Reset value  : $24003010
\   Chosen value : $24401804 ( XXX Manually calculated XXX ) 
\ 
\   Name            Value   [High:Low]  Semantics
    ( Reserved )        2   31 28 >bits \ undefined
    ( PLLQ     )        4   27 24 +bits \ divide f_VCO by 4
    ( Reserved )        0   23 23 +bits \ undefined
    ( PLLSRC   )        1   22 22 +bits \ use HSE
    ( Reserved )        0   21 18 +bits \ undefined
    ( PLLP     )        0   17 16 +bits \ divide f_VCO by 2
    ( Reserved )        0   15 15 +bits \ undefined
    ( PLLN     )       96   14  6 +bits \ multiply source 96
    ( PLLM     )        4    5  0 +bits \ divide source by 4
    RCC_PLLCFGR ! ;

see pll-init
\ 20002B00: F643  movw r0 #3800
\ 20002B02: 0000
\ 20002B04: F2C4  movt r0 #4002
\ 20002B06: 0002
\ 20002B08: F641  movw r3 #1804
\ 20002B0A: 0304
\ 20002B0C: F2C2  movt r3 #2440
\ 20002B0E: 4340
\ 20002B10: 6043  str r3 [ r0 #4 ]
\ 20002B12: 4770  bx lr