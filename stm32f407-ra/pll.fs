: bit ( n -- mask ) 1 swap lshift 1-foldable inline ;

\ FLASH
$40023C00 constant FLASH ( FLASH )
FLASH $0 + constant FLASH_ACR (  )  \ Flash access control register
FLASH $4 + constant FLASH_KEYR ( write-only )  \ Flash key register
FLASH $8 + constant FLASH_OPTKEYR ( write-only )  \ Flash option key register
FLASH $C + constant FLASH_SR (  )  \ Status register
FLASH $10 + constant FLASH_CR ( read-write )  \ Control register
FLASH $14 + constant FLASH_OPTCR ( read-write )  \ Flash option control register

\ RNG
$50060800 constant RNG ( Random number generator )
RNG $0 + constant RNG_CR ( read-write )  \ control register
RNG $4 + constant RNG_SR (  )  \ status register
RNG $8 + constant RNG_DR ( read-only )  \ data register

\ RCC
$40023800 constant RCC ( Reset and clock control )
RCC $00 + constant RCC_CR (  )  \ clock control register
RCC $04 + constant RCC_PLLCFGR ( read-write )  \ PLL configuration register
RCC $08 + constant RCC_CFGR (  )  \ clock configuration register
RCC $0C + constant RCC_CIR (  )  \ clock interrupt register
RCC $10 + constant RCC_AHB1RSTR ( read-write )  \ AHB1 peripheral reset register
RCC $14 + constant RCC_AHB2RSTR ( read-write )  \ AHB2 peripheral reset register
RCC $18 + constant RCC_AHB3RSTR ( read-write )  \ AHB3 peripheral reset register
RCC $20 + constant RCC_APB1RSTR ( read-write )  \ APB1 peripheral reset register
RCC $24 + constant RCC_APB2RSTR ( read-write )  \ APB2 peripheral reset register
RCC $30 + constant RCC_AHB1ENR ( read-write )  \ AHB1 peripheral clock register
RCC $34 + constant RCC_AHB2ENR ( read-write )  \ AHB2 peripheral clock enable  register
RCC $38 + constant RCC_AHB3ENR ( read-write )  \ AHB3 peripheral clock enable  register
RCC $40 + constant RCC_APB1ENR ( read-write )  \ APB1 peripheral clock enable  register
RCC $44 + constant RCC_APB2ENR ( read-write )  \ APB2 peripheral clock enable  register
RCC $50 + constant RCC_AHB1LPENR ( read-write )  \ AHB1 peripheral clock enable in low power  mode register
RCC $54 + constant RCC_AHB2LPENR ( read-write )  \ AHB2 peripheral clock enable in low power  mode register
RCC $58 + constant RCC_AHB3LPENR ( read-write )  \ AHB3 peripheral clock enable in low power  mode register
RCC $60 + constant RCC_APB1LPENR ( read-write )  \ APB1 peripheral clock enable in low power  mode register
RCC $64 + constant RCC_APB2LPENR ( read-write )  \ APB2 peripheral clock enabled in low power  mode register
RCC $70 + constant RCC_BDCR (  )  \ Backup domain control register
RCC $74 + constant RCC_CSR (  )  \ clock control & status  register
RCC $80 + constant RCC_SSCGR ( read-write )  \ spread spectrum clock generation  register
RCC $84 + constant RCC_PLLI2SCFGR ( read-write )  \ PLLI2S configuration register

\ USART
$40004408 constant USART2_BRR

\ Bits in RCC_CR
16 bit constant HSEON
17 bit constant HSERDY
24 bit constant PLLON
25 bit constant PLLRDY

$705 constant ART-5WS \ Enable data cache, instruction and prefetching, 5 wait states

7 24 lshift    \ PLLQ = 7
22 bit +       \ PLLSRC = HSE, PLLP = 0
336 6 lshift + \ PLLN = 336
8 +            \ PLLM = 8
constant pll-8>168

4 13 lshift   \ PPRE2 = /2 (APB2 = 84MHz)
5 10 lshift + \ PPRE1 = /4 (APB1 = 42MHz)
2 +           \ SW = PLL
constant cfg-pll

: hse-on ( -- ) HSEON RCC_CR bis! begin HSERDY RCC_CR bit@ until ;
: pll-on ( -- ) PLLON RCC_CR bis! begin PLLRDY RCC_CR bit@ until ;
: pll-168MHz ( -- ) pll-8>168 RCC_PLLCFGR ! ;
: flash-168MHz ( -- ) ART-5WS FLASH_ACR ! ;
: use-pll ( -- ) cfg-pll RCC_CFGR ! ;
: baud-168MHz ( -- ) $16d USART2_BRR ! ; \ Set Baud rate divider for 115200 Baud at 42 MHz. 22.786
: 168MHz ( -- ) hse-on flash-168MHz pll-168MHz pll-on use-pll baud-168MHz ;

168000000 constant clock-hz

: us ( n -- ) clock-hz 1000000 / * delay-cycles ;
: ms ( n -- ) clock-hz 1000 / * delay-cycles ;

: init-rng ( -- )
	6 bit RCC_AHB2ENR bis!
	2 bit RNG_CR bis! ;

: rng-ready? ( -- ? ) 0 bit RNG_SR bit@ inline ;

: random ( -- x )
	begin rng-ready? until RNG_DR @ ;
