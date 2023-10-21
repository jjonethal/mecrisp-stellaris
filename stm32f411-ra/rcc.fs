$40023800 constant RCC ( Reset and clock control ) 
RCC $0 + constant RCC_CR (  )  \ clock control register
RCC $4 + constant RCC_PLLCFGR ( read-write )  \ PLL configuration register
RCC $8 + constant RCC_CFGR (  )  \ clock configuration register
RCC $C + constant RCC_CIR (  )  \ clock interrupt register
RCC $10 + constant RCC_AHB1RSTR ( read-write )  \ AHB1 peripheral reset register
RCC $14 + constant RCC_AHB2RSTR ( read-write )  \ AHB2 peripheral reset register
RCC $20 + constant RCC_APB1RSTR ( read-write )  \ APB1 peripheral reset register
RCC $24 + constant RCC_APB2RSTR ( read-write )  \ APB2 peripheral reset register
RCC $30 + constant RCC_AHB1ENR ( read-write )  \ AHB1 peripheral clock register
RCC $34 + constant RCC_AHB2ENR ( read-write )  \ AHB2 peripheral clock enable  register
RCC $40 + constant RCC_APB1ENR ( read-write )  \ APB1 peripheral clock enable  register
RCC $44 + constant RCC_APB2ENR ( read-write )  \ APB2 peripheral clock enable  register
RCC $50 + constant RCC_AHB1LPENR ( read-write )  \ AHB1 peripheral clock enable in low power  mode register
RCC $54 + constant RCC_AHB2LPENR ( read-write )  \ AHB2 peripheral clock enable in low power  mode register
RCC $60 + constant RCC_APB1LPENR ( read-write )  \ APB1 peripheral clock enable in low power  mode register
RCC $64 + constant RCC_APB2LPENR ( read-write )  \ APB2 peripheral clock enabled in low power  mode register
RCC $70 + constant RCC_BDCR (  )  \ Backup domain control register
RCC $74 + constant RCC_CSR (  )  \ clock control & status  register
RCC $80 + constant RCC_SSCGR ( read-write )  \ spread spectrum clock generation  register
RCC $84 + constant RCC_PLLI2SCFGR ( read-write )  \ PLLI2S configuration register
