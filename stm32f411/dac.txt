
\ Analog output example
\ PA4: DAC1 out
\ PA5: DAC2 out

$40020000 constant PORTA_Base

PORTA_Base $00 + constant PORTA_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
PORTA_Base $10 + constant PORTA_IDR      \ RO      Input Data Register
PORTA_Base $14 + constant PORTA_ODR      \ Reset 0 Output Data Register

$40023800 constant RCC_Base
RCC_Base $40 + constant RCC_APB1ENR

1 29 lshift constant DACEN

$40007400 constant DAC_Base 
DAC_Base $00 + constant DAC_CR 
DAC_Base $08 + constant DAC_DHR12R1
DAC_Base $14 + constant DAC_DHR12R2
DAC_Base $20 + constant DAC_DHR12RD


: dacs ( Channel1 Channel2 -- )
  \ $FFF and DAC_DHR12R2 !
  \ $FFF and DAC_DHR12R1 !
  $FFF and 16 lshift
  swap
  $FFF and
  or
  DAC_DHR12RD !
;

: init-dac ( -- )
  DACEN RCC_APB1ENR bis! \ Enable clock for DAC
  10 0 do loop

  %11 4 2* lshift
  %11 5 2* lshift or PORTA_MODER bis! \ Set DAC Pins to analog mode

  $00010001 DAC_CR ! \ Enable Channel 1 and 2
  0 0 dacs
;

: dac1 ( Channel1 -- ) \ PA4
  $FFF and DAC_DHR12R1 !  
;

: dac2 ( Channel2 -- ) \ PA5
  $FFF and DAC_DHR12R2 !  
;

: triangle
  init-dac
  
  begin
    $1000 0 do  i          $FFF i - dacs loop
    $1000 0 do  $FFF i -   i        dacs loop
  key? until
;
