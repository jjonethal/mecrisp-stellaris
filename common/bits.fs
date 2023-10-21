\ Expand x1 to into bitfield [high:low]
: >bits ( x1 high low -- x2 )
    tuck - 1+ -1 swap lshift rot swap bic swap lshift 3-foldable ;

\ Expand x2 into bitfield [high:low] and combine with x1 through bitwise or
: +bits ( x1 x2 high low -- x3 ) >bits or 4-foldable ;

