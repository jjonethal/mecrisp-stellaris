\ Read the BASEPRI special register
: basepri@ ( -- x )
    dup \ Make the top of stack register available
    [
        ( MRS r6, BASEPRI )
        $f3ef8611 ><,
    ] ;

\ Write the BASEPRI special register (includes the required memory barrier).
: basepri! ( x -- )
    [
        ( MSR BASEPRI, r6 )
        $f3868011 ><,
        ( DSB             )
        $f3bf8f4f ><,
        ( ISB             )
        $f3bf8f6f ><,
    ] drop ;

\ Write the BASEPRI_MAX special register (includes the required memory barrier).
: basepri-max! ( x -- )
    [
        ( MSR BASEPRI_MAX, r6 )
        $f3868012 ><,
        ( DSB             )
        $f3bf8f4f ><,
        ( ISB             )
        $f3bf8f6f ><,
    ] drop ;

\ Raise base pri to basepri while executing xt.
: with-basepri ( xt basepri -- ) basepri@ >r basepri-max! execute r> basepri! ;