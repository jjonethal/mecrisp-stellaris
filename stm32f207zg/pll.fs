\ Enable PLL

$40023800 Constant RCC_CR
RCC_CR $04 + Constant RCC_PLLCFGR
RCC_CR $08 + Constant RCC_CFGR
$40023C00 Constant FLASH_ACR

$40004800 Constant USART3_SR
USART3_SR $08 + Constant USART3_BRR

: small-delay ( -- )
    100 0 DO LOOP ; \ wait a bit

: pll-on ( -- )
    small-delay
    $303 FLASH_ACR !
    $05401E04 RCC_PLLCFGR !
    $0008940A RCC_CFGR !
    $010D0080 RCC_CR !
    BEGIN RCC_CR @ $02000000 and UNTIL \ wait for PLL to stabilize
    $104 USART3_BRR ! \ 115k2 with 30MHz
;

: pll-off ( -- )
    small-delay
    $00000000 RCC_CFGR !
    $00000083 RCC_CR !
    $24003010 RCC_PLLCFGR !
    $8B USART3_BRR ! \ 115k2 with 16MHz
    $000 FLASH_ACR ! ;
