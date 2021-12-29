
\ -----------------------------------------------------------------------------
\  Floating point routines - not for interrupt usage
\ -----------------------------------------------------------------------------

hex

E000ED88 constant CPACR

E000EF34 constant FPCCR
E000EF38 constant FPCAR
E000EF3C constant FPDSCR
E000EF40 constant MVFR0
E000EF44 constant MVFR1

: fpu-init ( -- ) 00F00000 CPACR bis! ;

\ -----------------------------------------------------------------------------
\  Get and set floating point flags
\ -----------------------------------------------------------------------------

: vflags@ ( -- x )
[
  F847 h,  \ dup
  6D04 h,  \
  EEF1 h,  \ vmrs r6, FPSCR
  6A10 h,  \
] inline ;

: vflags! ( x -- )
[
  EEE1 h,  \ vmsr FPSCR, r6
  6A10 h,  \
  CF40 h,  \ drop
] inline ;

\ -----------------------------------------------------------------------------
\  Integer <-> Float conversions
\ -----------------------------------------------------------------------------

: u>v ( u -- v )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEB8 h,  \ vcvt.f32.u32 s0, s0
  0A40 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;

: n>v ( n -- v )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEB8 h,  \ vcvt.f32.s32 s0, s0
  0AC0 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;

: v>u ( v -- u )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEBC h,  \ vcvt.u32.f32 s0, s0
  0AC0 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;

: v>n ( v -- n )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEBD h,  \ vcvt.s32.f32 s0, s0
  0AC0 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;

\ -----------------------------------------------------------------------------
\  Single operand calculations
\ -----------------------------------------------------------------------------

: vabs ( v -- v* )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEB0 h,  \ vabs.f32 s0, s0
  0AC0 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;


: vneg ( v -- v* )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEB1 h,  \ vneg.f32 s0, s0
  0A40 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;


: vsqrt ( v -- v* )
[
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEB1 h,  \ vsqrt.f32 s0, s0
  0AC0 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 1-foldable ;

\ -----------------------------------------------------------------------------
\  Double operand calculations
\ -----------------------------------------------------------------------------

: vadd ( v1 v2 -- v )
[
  EE00 h,  \ vmov s1, r6
  6A90 h,  \
  CF40 h,  \ drop
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EE30 h,  \ vadd.f32 s0, s1
  0A20 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 2-foldable ;

: vcmp ( v1 v2 -- v )
[
  EE00 h,  \ vmov s1, r6
  6A90 h,  \
  CF40 h,  \ drop
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EEB4 h,  \ vcmp.f32 s0, s1
  0A60 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 2-foldable ;

: vsub ( v1 v2 -- v )
[
  EE00 h,  \ vmov s1, r6
  6A90 h,  \
  CF40 h,  \ drop
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EE30 h,  \ vsub.f32 s0, s1
  0A60 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 2-foldable ;


: vmul ( v1 v2 -- v )
[
  EE00 h,  \ vmov s1, r6
  6A90 h,  \
  CF40 h,  \ drop
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EE20 h,  \ vmul.f32 s0, s1
  0A20 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 2-foldable ;


: vdiv ( v1 v2 -- v )
[
  EE00 h,  \ vmov s1, r6
  6A90 h,  \
  CF40 h,  \ drop
  EE00 h,  \ vmov s0, r6
  6A10 h,  \
  EE80 h,  \ vdiv.f32 s0, s0, s1
  0A20 h,  \
  EE10 h,  \ vmov r6, s0
  6A10 h,  \
] inline 2-foldable ;

decimal

\ -----------------------------------------------------------------------------
\   s31.32 <-> Float conversions by Ivan Dimitrov
\ -----------------------------------------------------------------------------

: f>v ( df -- v )
    dup 1 31 lshift and -rot ( S L H )
    dabs u>v  swap u>v       ( S vh vl )
    $2f800000 vmul vadd      ( S v )
    or                       \ apply the sign
; 2-foldable

: v>f ( v -- df )
    dup 1 31 lshift and 0<> swap ( nf v )
    vabs
    dup v>n                      ( nf v h )
    swap over n>v                ( nf h vh )
    vsub $4f800000 vmul \ low part times 2^32
    v>u swap rot                 ( l h s )
    if dnegate then
; 1-foldable
