$40023C00 constant FLASH ( FLASH ) 
FLASH $0 + constant FLASH_ACR (  )  \ Flash access control register
FLASH $4 + constant FLASH_KEYR ( write-only )  \ Flash key register
FLASH $8 + constant FLASH_OPTKEYR ( write-only )  \ Flash option key register
FLASH $C + constant FLASH_SR (  )  \ Status register
FLASH $10 + constant FLASH_CR ( read-write )  \ Control register
FLASH $14 + constant FLASH_OPTCR ( read-write )  \ Flash option control register
