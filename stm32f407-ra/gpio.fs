$40020000 constant GPIOA
$40020400 constant GPIOB
$40020800 constant GPIOC
$40020C00 constant GPIOD
$40021000 constant GPIOE
$40021400 constant GPIOF
$40021800 constant GPIOG
$40021C00 constant GPIOH
$40022000 constant GPIOI

GPIOA $00 + constant GPIOA_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOA $04 + constant GPIOA_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOA $08 + constant GPIOA_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOA $0C + constant GPIOA_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOA $10 + constant GPIOA_IDR      \ RO      Input Data Register
GPIOA $14 + constant GPIOA_ODR      \ Reset 0 Output Data Register
GPIOA $18 + constant GPIOA_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOA $1C + constant GPIOA_LCKR     \ Reset 0 Port configuration lock register
GPIOA $20 + constant GPIOA_AFRL     \ Reset 0 Alternate function  low register
GPIOA $24 + constant GPIOA_AFRH     \ Reset 0 Alternate function high register

GPIOB $00 + constant GPIOB_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOB $04 + constant GPIOB_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOB $08 + constant GPIOB_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOB $0C + constant GPIOB_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOB $10 + constant GPIOB_IDR      \ RO      Input Data Register
GPIOB $14 + constant GPIOB_ODR      \ Reset 0 Output Data Register
GPIOB $18 + constant GPIOB_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOB $1C + constant GPIOB_LCKR     \ Reset 0 Port configuration lock register
GPIOB $20 + constant GPIOB_AFRL     \ Reset 0 Alternate function  low register
GPIOB $24 + constant GPIOB_AFRH     \ Reset 0 Alternate function high register

GPIOC $00 + constant GPIOC_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOC $04 + constant GPIOC_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOC $08 + constant GPIOC_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOC $0C + constant GPIOC_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOC $10 + constant GPIOC_IDR      \ RO      Input Data Register
GPIOC $14 + constant GPIOC_ODR      \ Reset 0 Output Data Register
GPIOC $18 + constant GPIOC_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOC $1C + constant GPIOC_LCKR     \ Reset 0 Port configuration lock register
GPIOC $20 + constant GPIOC_AFRL     \ Reset 0 Alternate function  low register
GPIOC $24 + constant GPIOC_AFRH     \ Reset 0 Alternate function high register

GPIOD $00 + constant GPIOD_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOD $04 + constant GPIOD_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOD $08 + constant GPIOD_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOD $0C + constant GPIOD_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOD $10 + constant GPIOD_IDR      \ RO      Input Data Register
GPIOD $14 + constant GPIOD_ODR      \ Reset 0 Output Data Register
GPIOD $18 + constant GPIOD_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOD $1C + constant GPIOD_LCKR     \ Reset 0 Port configuration lock register
GPIOD $20 + constant GPIOD_AFRL     \ Reset 0 Alternate function  low register
GPIOD $24 + constant GPIOD_AFRH     \ Reset 0 Alternate function high register

GPIOE $00 + constant GPIOE_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOE $04 + constant GPIOE_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOE $08 + constant GPIOE_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOE $0C + constant GPIOE_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOE $10 + constant GPIOE_IDR      \ RO      Input Data Register
GPIOE $14 + constant GPIOE_ODR      \ Reset 0 Output Data Register
GPIOE $18 + constant GPIOE_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOE $1C + constant GPIOE_LCKR     \ Reset 0 Port configuration lock register
GPIOE $20 + constant GPIOE_AFRL     \ Reset 0 Alternate function  low register
GPIOE $24 + constant GPIOE_AFRH     \ Reset 0 Alternate function high register

GPIOF $00 + constant GPIOF_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOF $04 + constant GPIOF_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOF $08 + constant GPIOF_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOF $0C + constant GPIOF_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOF $10 + constant GPIOF_IDR      \ RO      Input Data Register
GPIOF $14 + constant GPIOF_ODR      \ Reset 0 Output Data Register
GPIOF $18 + constant GPIOF_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOF $1C + constant GPIOF_LCKR     \ Reset 0 Port configuration lock register
GPIOF $20 + constant GPIOF_AFRL     \ Reset 0 Alternate function  low register
GPIOF $24 + constant GPIOF_AFRH     \ Reset 0 Alternate function high register

GPIOG $00 + constant GPIOG_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOG $04 + constant GPIOG_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOG $08 + constant GPIOG_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOG $0C + constant GPIOG_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOG $10 + constant GPIOG_IDR      \ RO      Input Data Register
GPIOG $14 + constant GPIOG_ODR      \ Reset 0 Output Data Register
GPIOG $18 + constant GPIOG_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOG $1C + constant GPIOG_LCKR     \ Reset 0 Port configuration lock register
GPIOG $20 + constant GPIOG_AFRL     \ Reset 0 Alternate function  low register
GPIOG $24 + constant GPIOG_AFRH     \ Reset 0 Alternate function high register

GPIOH $00 + constant GPIOH_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOH $04 + constant GPIOH_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOH $08 + constant GPIOH_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOH $0C + constant GPIOH_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOH $10 + constant GPIOH_IDR      \ RO      Input Data Register
GPIOH $14 + constant GPIOH_ODR      \ Reset 0 Output Data Register
GPIOH $18 + constant GPIOH_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOH $1C + constant GPIOH_LCKR     \ Reset 0 Port configuration lock register
GPIOH $20 + constant GPIOH_AFRL     \ Reset 0 Alternate function  low register
GPIOH $24 + constant GPIOH_AFRH     \ Reset 0 Alternate function high register

GPIOI $00 + constant GPIOI_MODER    \ Reset 0 Port Mode Register - 00=Input  01=Output  10=Alternate  11=Analog
GPIOI $04 + constant GPIOI_OTYPER   \ Reset 0 Port Output type register - (0) Push/Pull vs. (1) Open Drain
GPIOI $08 + constant GPIOI_OSPEEDR  \ Reset 0 Output Speed Register - 00=2 MHz  01=25 MHz  10=50 MHz  11=100 MHz
GPIOI $0C + constant GPIOI_PUPDR    \ Reset 0 Pullup / Pulldown - 00=none  01=Pullup  10=Pulldown
GPIOI $10 + constant GPIOI_IDR      \ RO      Input Data Register
GPIOI $14 + constant GPIOI_ODR      \ Reset 0 Output Data Register
GPIOI $18 + constant GPIOI_BSRR     \ WO      Bit set/reset register   31:16 Reset 15:0 Set
GPIOI $1C + constant GPIOI_LCKR     \ Reset 0 Port configuration lock register
GPIOI $20 + constant GPIOI_AFRL     \ Reset 0 Alternate function  low register
GPIOI $24 + constant GPIOI_AFRH     \ Reset 0 Alternate function high register
