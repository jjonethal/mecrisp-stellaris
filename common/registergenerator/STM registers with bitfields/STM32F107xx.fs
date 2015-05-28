\  STM32F107xx ARM CMSIS-SVD register file for Mecrisp-Stellaris Forth by Matthias Koch
	\  x = 0 or 1 below in the Register Field bit positions 
	 

    $40007000 constant PWR  
	 PWR $0 + constant PWR_CR	\ read-write		\  : RESET_PWR_CR $00000000 
        \ %x  0 lshift PWR_CR        \ PWR_LPDS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_CR        \ PWR_PDDS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_CR        \ PWR_CWUF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_CR        \ PWR_CSBF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_CR        \ PWR_PVDE	Bit Offset:4	Bit Width:1
        \ %xxx  5 lshift PWR_CR        \ PWR_PLS	Bit Offset:5	Bit Width:3
        \ %x  8 lshift PWR_CR        \ PWR_DBP	Bit Offset:8	Bit Width:1
        
        PWR $4 + constant PWR_CSR	\ 		\  : RESET_PWR_CSR $00000000 
        \ %x  0 lshift PWR_CSR        \ PWR_WUF	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_CSR        \ PWR_SBF	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_CSR        \ PWR_PVDO	Bit Offset:2	Bit Width:1
        \ %x  8 lshift PWR_CSR        \ PWR_EWUP	Bit Offset:8	Bit Width:1
        
         
	
     $40021000 constant RCC  
	 RCC $0 + constant RCC_CR	\ 		\  : RESET_RCC_CR $00000083 
        \ %x  0 lshift RCC_CR        \ RCC_HSION	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_CR        \ RCC_HSIRDY	Bit Offset:1	Bit Width:1
        \ %xxxxx  3 lshift RCC_CR        \ RCC_HSITRIM	Bit Offset:3	Bit Width:5
        \ %xxxxxxxx  8 lshift RCC_CR        \ RCC_HSICAL	Bit Offset:8	Bit Width:8
        \ %x  16 lshift RCC_CR        \ RCC_HSEON	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_CR        \ RCC_HSERDY	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_CR        \ RCC_HSEBYP	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_CR        \ RCC_CSSON	Bit Offset:19	Bit Width:1
        \ %x  24 lshift RCC_CR        \ RCC_PLLON	Bit Offset:24	Bit Width:1
        \ %x  25 lshift RCC_CR        \ RCC_PLLRDY	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_CR        \ RCC_PLL2ON	Bit Offset:26	Bit Width:1
        \ %x  27 lshift RCC_CR        \ RCC_PLL2RDY	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_CR        \ RCC_PLL3ON	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_CR        \ RCC_PLL3RDY	Bit Offset:29	Bit Width:1
        
        RCC $4 + constant RCC_CFGR	\ 		\  : RESET_RCC_CFGR $00000000 
        \ %xx  0 lshift RCC_CFGR        \ RCC_SW	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift RCC_CFGR        \ RCC_SWS	Bit Offset:2	Bit Width:2
        \ %xxxx  4 lshift RCC_CFGR        \ RCC_HPRE	Bit Offset:4	Bit Width:4
        \ %xxx  8 lshift RCC_CFGR        \ RCC_PPRE1	Bit Offset:8	Bit Width:3
        \ %xxx  11 lshift RCC_CFGR        \ RCC_PPRE2	Bit Offset:11	Bit Width:3
        \ %xx  14 lshift RCC_CFGR        \ RCC_ADCPRE	Bit Offset:14	Bit Width:2
        \ %x  16 lshift RCC_CFGR        \ RCC_PLLSRC	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_CFGR        \ RCC_PLLXTPRE	Bit Offset:17	Bit Width:1
        \ %xxxx  18 lshift RCC_CFGR        \ RCC_PLLMUL	Bit Offset:18	Bit Width:4
        \ %x  22 lshift RCC_CFGR        \ RCC_OTGFSPRE	Bit Offset:22	Bit Width:1
        \ %xxxx  24 lshift RCC_CFGR        \ RCC_MCO	Bit Offset:24	Bit Width:4
        
        RCC $8 + constant RCC_CIR	\ 		\  : RESET_RCC_CIR $00000000 
        \ %x  0 lshift RCC_CIR        \ RCC_LSIRDYF	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_CIR        \ RCC_LSERDYF	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_CIR        \ RCC_HSIRDYF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_CIR        \ RCC_HSERDYF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_CIR        \ RCC_PLLRDYF	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_CIR        \ RCC_PLL2RDYF	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_CIR        \ RCC_PLL3RDYF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_CIR        \ RCC_CSSF	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_CIR        \ RCC_LSIRDYIE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RCC_CIR        \ RCC_LSERDYIE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RCC_CIR        \ RCC_HSIRDYIE	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RCC_CIR        \ RCC_HSERDYIE	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_CIR        \ RCC_PLLRDYIE	Bit Offset:12	Bit Width:1
        \ %x  13 lshift RCC_CIR        \ RCC_PLL2RDYIE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift RCC_CIR        \ RCC_PLL3RDYIE	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RCC_CIR        \ RCC_LSIRDYC	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_CIR        \ RCC_LSERDYC	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_CIR        \ RCC_HSIRDYC	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_CIR        \ RCC_HSERDYC	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_CIR        \ RCC_PLLRDYC	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_CIR        \ RCC_PLL2RDYC	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_CIR        \ RCC_PLL3RDYC	Bit Offset:22	Bit Width:1
        \ %x  23 lshift RCC_CIR        \ RCC_CSSC	Bit Offset:23	Bit Width:1
        
        RCC $C + constant RCC_APB2RSTR	\ read-write		\  : RESET_RCC_APB2RSTR $000000000 
        \ %x  0 lshift RCC_APB2RSTR        \ RCC_AFIORST	Bit Offset:0	Bit Width:1
        \ %x  2 lshift RCC_APB2RSTR        \ RCC_IOPARST	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB2RSTR        \ RCC_IOPBRST	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB2RSTR        \ RCC_IOPCRST	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2RSTR        \ RCC_IOPDRST	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB2RSTR        \ RCC_IOPERST	Bit Offset:6	Bit Width:1
        \ %x  9 lshift RCC_APB2RSTR        \ RCC_ADC1RST	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RCC_APB2RSTR        \ RCC_ADC2RST	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RCC_APB2RSTR        \ RCC_TIM1RST	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2RSTR        \ RCC_SPI1RST	Bit Offset:12	Bit Width:1
        \ %x  14 lshift RCC_APB2RSTR        \ RCC_USART1RST	Bit Offset:14	Bit Width:1
        
        RCC $10 + constant RCC_APB1RSTR	\ read-write		\  : RESET_RCC_APB1RSTR $00000000 
        \ %x  0 lshift RCC_APB1RSTR        \ RCC_TIM2RST	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB1RSTR        \ RCC_TIM3RST	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_APB1RSTR        \ RCC_TIM4RST	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB1RSTR        \ RCC_TIM5RST	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB1RSTR        \ RCC_TIM6RST	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB1RSTR        \ RCC_TIM7RST	Bit Offset:5	Bit Width:1
        \ %x  11 lshift RCC_APB1RSTR        \ RCC_WWDGRST	Bit Offset:11	Bit Width:1
        \ %x  14 lshift RCC_APB1RSTR        \ RCC_SPI2RST	Bit Offset:14	Bit Width:1
        \ %x  15 lshift RCC_APB1RSTR        \ RCC_SPI3RST	Bit Offset:15	Bit Width:1
        \ %x  17 lshift RCC_APB1RSTR        \ RCC_USART2RST	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB1RSTR        \ RCC_USART3RST	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_APB1RSTR        \ RCC_USART4RST	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_APB1RSTR        \ RCC_USART5RST	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB1RSTR        \ RCC_I2C1RST	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_APB1RSTR        \ RCC_I2C2RST	Bit Offset:22	Bit Width:1
        \ %x  25 lshift RCC_APB1RSTR        \ RCC_CAN1RST	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_APB1RSTR        \ RCC_CAN2RST	Bit Offset:26	Bit Width:1
        \ %x  27 lshift RCC_APB1RSTR        \ RCC_BKPRST	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_APB1RSTR        \ RCC_PWRRST	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1RSTR        \ RCC_DACRST	Bit Offset:29	Bit Width:1
        
        RCC $14 + constant RCC_AHBENR	\ read-write		\  : RESET_RCC_AHBENR $00000014 
        \ %x  0 lshift RCC_AHBENR        \ RCC_DMA1EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_AHBENR        \ RCC_DMA2EN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_AHBENR        \ RCC_SRAMEN	Bit Offset:2	Bit Width:1
        \ %x  4 lshift RCC_AHBENR        \ RCC_FLITFEN	Bit Offset:4	Bit Width:1
        \ %x  6 lshift RCC_AHBENR        \ RCC_CRCEN	Bit Offset:6	Bit Width:1
        \ %x  12 lshift RCC_AHBENR        \ RCC_OTGFSEN	Bit Offset:12	Bit Width:1
        \ %x  14 lshift RCC_AHBENR        \ RCC_ETHMACEN	Bit Offset:14	Bit Width:1
        \ %x  15 lshift RCC_AHBENR        \ RCC_ETHMACTXEN	Bit Offset:15	Bit Width:1
        \ %x  16 lshift RCC_AHBENR        \ RCC_ETHMACRXEN	Bit Offset:16	Bit Width:1
        
        RCC $18 + constant RCC_APB2ENR	\ read-write		\  : RESET_RCC_APB2ENR $00000000 
        \ %x  0 lshift RCC_APB2ENR        \ RCC_AFIOEN	Bit Offset:0	Bit Width:1
        \ %x  2 lshift RCC_APB2ENR        \ RCC_IOPAEN	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB2ENR        \ RCC_IOPBEN	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB2ENR        \ RCC_IOPCEN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2ENR        \ RCC_IOPDEN	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB2ENR        \ RCC_IOPEEN	Bit Offset:6	Bit Width:1
        \ %x  9 lshift RCC_APB2ENR        \ RCC_ADC1EN	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RCC_APB2ENR        \ RCC_ADC2EN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RCC_APB2ENR        \ RCC_TIM1EN	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2ENR        \ RCC_SPI1EN	Bit Offset:12	Bit Width:1
        \ %x  14 lshift RCC_APB2ENR        \ RCC_USART1EN	Bit Offset:14	Bit Width:1
        
        RCC $1C + constant RCC_APB1ENR	\ read-write		\  : RESET_RCC_APB1ENR $00000000 
        \ %x  0 lshift RCC_APB1ENR        \ RCC_TIM2EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB1ENR        \ RCC_TIM3EN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_APB1ENR        \ RCC_TIM4EN	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB1ENR        \ RCC_TIM5EN	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB1ENR        \ RCC_TIM6EN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB1ENR        \ RCC_TIM7EN	Bit Offset:5	Bit Width:1
        \ %x  11 lshift RCC_APB1ENR        \ RCC_WWDGEN	Bit Offset:11	Bit Width:1
        \ %x  14 lshift RCC_APB1ENR        \ RCC_SPI2EN	Bit Offset:14	Bit Width:1
        \ %x  15 lshift RCC_APB1ENR        \ RCC_SPI3EN	Bit Offset:15	Bit Width:1
        \ %x  17 lshift RCC_APB1ENR        \ RCC_USART2EN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB1ENR        \ RCC_USART3EN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_APB1ENR        \ RCC_UART4EN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_APB1ENR        \ RCC_UART5EN	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB1ENR        \ RCC_I2C1EN	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_APB1ENR        \ RCC_I2C2EN	Bit Offset:22	Bit Width:1
        \ %x  25 lshift RCC_APB1ENR        \ RCC_CAN1EN	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_APB1ENR        \ RCC_CAN2EN	Bit Offset:26	Bit Width:1
        \ %x  27 lshift RCC_APB1ENR        \ RCC_BKPEN	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_APB1ENR        \ RCC_PWREN	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1ENR        \ RCC_DACEN	Bit Offset:29	Bit Width:1
        
        RCC $20 + constant RCC_BDCR	\ 		\  : RESET_RCC_BDCR $00000000 
        \ %x  0 lshift RCC_BDCR        \ RCC_LSEON	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_BDCR        \ RCC_LSERDY	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_BDCR        \ RCC_LSEBYP	Bit Offset:2	Bit Width:1
        \ %xx  8 lshift RCC_BDCR        \ RCC_RTCSEL	Bit Offset:8	Bit Width:2
        \ %x  15 lshift RCC_BDCR        \ RCC_RTCEN	Bit Offset:15	Bit Width:1
        \ %x  16 lshift RCC_BDCR        \ RCC_BDRST	Bit Offset:16	Bit Width:1
        
        RCC $24 + constant RCC_CSR	\ 		\  : RESET_RCC_CSR $0C000000 
        \ %x  0 lshift RCC_CSR        \ RCC_LSION	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_CSR        \ RCC_LSIRDY	Bit Offset:1	Bit Width:1
        \ %x  24 lshift RCC_CSR        \ RCC_RMVF	Bit Offset:24	Bit Width:1
        \ %x  26 lshift RCC_CSR        \ RCC_PINRSTF	Bit Offset:26	Bit Width:1
        \ %x  27 lshift RCC_CSR        \ RCC_PORRSTF	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_CSR        \ RCC_SFTRSTF	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_CSR        \ RCC_IWDGRSTF	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_CSR        \ RCC_WWDGRSTF	Bit Offset:30	Bit Width:1
        \ %x  31 lshift RCC_CSR        \ RCC_LPWRRSTF	Bit Offset:31	Bit Width:1
        
        RCC $28 + constant RCC_AHBRSTR	\ read-write		\  : RESET_RCC_AHBRSTR $00000000 
        \ %x  12 lshift RCC_AHBRSTR        \ RCC_OTGFSRST	Bit Offset:12	Bit Width:1
        \ %x  14 lshift RCC_AHBRSTR        \ RCC_ETHMACRST	Bit Offset:14	Bit Width:1
        
        RCC $2C + constant RCC_CFGR2	\ read-write		\  : RESET_RCC_CFGR2 $00000000 
        \ %xxxx  0 lshift RCC_CFGR2        \ RCC_PREDIV1	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift RCC_CFGR2        \ RCC_PREDIV2	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift RCC_CFGR2        \ RCC_PLL2MUL	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift RCC_CFGR2        \ RCC_PLL3MUL	Bit Offset:12	Bit Width:4
        \ %x  16 lshift RCC_CFGR2        \ RCC_PREDIV1SRC	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_CFGR2        \ RCC_I2S2SRC	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_CFGR2        \ RCC_I2S3SRC	Bit Offset:18	Bit Width:1
        
         
	
     $40010800 constant GPIOA  
	 GPIOA $0 + constant GPIOA_CRL	\ read-write		\  : RESET_GPIOA_CRL $44444444 
        \ %xx  0 lshift GPIOA_CRL        \ GPIOA_MODE0	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift GPIOA_CRL        \ GPIOA_CNF0	Bit Offset:2	Bit Width:2
        \ %xx  4 lshift GPIOA_CRL        \ GPIOA_MODE1	Bit Offset:4	Bit Width:2
        \ %xx  6 lshift GPIOA_CRL        \ GPIOA_CNF1	Bit Offset:6	Bit Width:2
        \ %xx  8 lshift GPIOA_CRL        \ GPIOA_MODE2	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift GPIOA_CRL        \ GPIOA_CNF2	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift GPIOA_CRL        \ GPIOA_MODE3	Bit Offset:12	Bit Width:2
        \ %xx  14 lshift GPIOA_CRL        \ GPIOA_CNF3	Bit Offset:14	Bit Width:2
        \ %xx  16 lshift GPIOA_CRL        \ GPIOA_MODE4	Bit Offset:16	Bit Width:2
        \ %xx  18 lshift GPIOA_CRL        \ GPIOA_CNF4	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift GPIOA_CRL        \ GPIOA_MODE5	Bit Offset:20	Bit Width:2
        \ %xx  22 lshift GPIOA_CRL        \ GPIOA_CNF5	Bit Offset:22	Bit Width:2
        \ %xx  24 lshift GPIOA_CRL        \ GPIOA_MODE6	Bit Offset:24	Bit Width:2
        \ %xx  26 lshift GPIOA_CRL        \ GPIOA_CNF6	Bit Offset:26	Bit Width:2
        \ %xx  28 lshift GPIOA_CRL        \ GPIOA_MODE7	Bit Offset:28	Bit Width:2
        \ %xx  30 lshift GPIOA_CRL        \ GPIOA_CNF7	Bit Offset:30	Bit Width:2
        
        GPIOA $4 + constant GPIOA_CRH	\ read-write		\  : RESET_GPIOA_CRH $44444444 
        \ %xx  0 lshift GPIOA_CRH        \ GPIOA_MODE8	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift GPIOA_CRH        \ GPIOA_CNF8	Bit Offset:2	Bit Width:2
        \ %xx  4 lshift GPIOA_CRH        \ GPIOA_MODE9	Bit Offset:4	Bit Width:2
        \ %xx  6 lshift GPIOA_CRH        \ GPIOA_CNF9	Bit Offset:6	Bit Width:2
        \ %xx  8 lshift GPIOA_CRH        \ GPIOA_MODE10	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift GPIOA_CRH        \ GPIOA_CNF10	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift GPIOA_CRH        \ GPIOA_MODE11	Bit Offset:12	Bit Width:2
        \ %xx  14 lshift GPIOA_CRH        \ GPIOA_CNF11	Bit Offset:14	Bit Width:2
        \ %xx  16 lshift GPIOA_CRH        \ GPIOA_MODE12	Bit Offset:16	Bit Width:2
        \ %xx  18 lshift GPIOA_CRH        \ GPIOA_CNF12	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift GPIOA_CRH        \ GPIOA_MODE13	Bit Offset:20	Bit Width:2
        \ %xx  22 lshift GPIOA_CRH        \ GPIOA_CNF13	Bit Offset:22	Bit Width:2
        \ %xx  24 lshift GPIOA_CRH        \ GPIOA_MODE14	Bit Offset:24	Bit Width:2
        \ %xx  26 lshift GPIOA_CRH        \ GPIOA_CNF14	Bit Offset:26	Bit Width:2
        \ %xx  28 lshift GPIOA_CRH        \ GPIOA_MODE15	Bit Offset:28	Bit Width:2
        \ %xx  30 lshift GPIOA_CRH        \ GPIOA_CNF15	Bit Offset:30	Bit Width:2
        
        GPIOA $8 + constant GPIOA_IDR	\ read-only		\  : RESET_GPIOA_IDR $00000000 
        \ %x  0 lshift GPIOA_IDR        \ GPIOA_IDR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift GPIOA_IDR        \ GPIOA_IDR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift GPIOA_IDR        \ GPIOA_IDR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift GPIOA_IDR        \ GPIOA_IDR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift GPIOA_IDR        \ GPIOA_IDR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift GPIOA_IDR        \ GPIOA_IDR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift GPIOA_IDR        \ GPIOA_IDR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift GPIOA_IDR        \ GPIOA_IDR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift GPIOA_IDR        \ GPIOA_IDR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift GPIOA_IDR        \ GPIOA_IDR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift GPIOA_IDR        \ GPIOA_IDR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift GPIOA_IDR        \ GPIOA_IDR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift GPIOA_IDR        \ GPIOA_IDR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift GPIOA_IDR        \ GPIOA_IDR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift GPIOA_IDR        \ GPIOA_IDR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift GPIOA_IDR        \ GPIOA_IDR15	Bit Offset:15	Bit Width:1
        
        GPIOA $C + constant GPIOA_ODR	\ read-write		\  : RESET_GPIOA_ODR $00000000 
        \ %x  0 lshift GPIOA_ODR        \ GPIOA_ODR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift GPIOA_ODR        \ GPIOA_ODR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift GPIOA_ODR        \ GPIOA_ODR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift GPIOA_ODR        \ GPIOA_ODR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift GPIOA_ODR        \ GPIOA_ODR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift GPIOA_ODR        \ GPIOA_ODR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift GPIOA_ODR        \ GPIOA_ODR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift GPIOA_ODR        \ GPIOA_ODR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift GPIOA_ODR        \ GPIOA_ODR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift GPIOA_ODR        \ GPIOA_ODR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift GPIOA_ODR        \ GPIOA_ODR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift GPIOA_ODR        \ GPIOA_ODR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift GPIOA_ODR        \ GPIOA_ODR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift GPIOA_ODR        \ GPIOA_ODR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift GPIOA_ODR        \ GPIOA_ODR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift GPIOA_ODR        \ GPIOA_ODR15	Bit Offset:15	Bit Width:1
        
        GPIOA $10 + constant GPIOA_BSRR	\ write-only		\  : RESET_GPIOA_BSRR $00000000 
        \ %x  0 lshift GPIOA_BSRR        \ GPIOA_BS0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift GPIOA_BSRR        \ GPIOA_BS1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift GPIOA_BSRR        \ GPIOA_BS2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift GPIOA_BSRR        \ GPIOA_BS3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift GPIOA_BSRR        \ GPIOA_BS4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift GPIOA_BSRR        \ GPIOA_BS5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift GPIOA_BSRR        \ GPIOA_BS6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift GPIOA_BSRR        \ GPIOA_BS7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift GPIOA_BSRR        \ GPIOA_BS8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift GPIOA_BSRR        \ GPIOA_BS9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift GPIOA_BSRR        \ GPIOA_BS10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift GPIOA_BSRR        \ GPIOA_BS11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift GPIOA_BSRR        \ GPIOA_BS12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift GPIOA_BSRR        \ GPIOA_BS13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift GPIOA_BSRR        \ GPIOA_BS14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift GPIOA_BSRR        \ GPIOA_BS15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift GPIOA_BSRR        \ GPIOA_BR0	Bit Offset:16	Bit Width:1
        \ %x  17 lshift GPIOA_BSRR        \ GPIOA_BR1	Bit Offset:17	Bit Width:1
        \ %x  18 lshift GPIOA_BSRR        \ GPIOA_BR2	Bit Offset:18	Bit Width:1
        \ %x  19 lshift GPIOA_BSRR        \ GPIOA_BR3	Bit Offset:19	Bit Width:1
        \ %x  20 lshift GPIOA_BSRR        \ GPIOA_BR4	Bit Offset:20	Bit Width:1
        \ %x  21 lshift GPIOA_BSRR        \ GPIOA_BR5	Bit Offset:21	Bit Width:1
        \ %x  22 lshift GPIOA_BSRR        \ GPIOA_BR6	Bit Offset:22	Bit Width:1
        \ %x  23 lshift GPIOA_BSRR        \ GPIOA_BR7	Bit Offset:23	Bit Width:1
        \ %x  24 lshift GPIOA_BSRR        \ GPIOA_BR8	Bit Offset:24	Bit Width:1
        \ %x  25 lshift GPIOA_BSRR        \ GPIOA_BR9	Bit Offset:25	Bit Width:1
        \ %x  26 lshift GPIOA_BSRR        \ GPIOA_BR10	Bit Offset:26	Bit Width:1
        \ %x  27 lshift GPIOA_BSRR        \ GPIOA_BR11	Bit Offset:27	Bit Width:1
        \ %x  28 lshift GPIOA_BSRR        \ GPIOA_BR12	Bit Offset:28	Bit Width:1
        \ %x  29 lshift GPIOA_BSRR        \ GPIOA_BR13	Bit Offset:29	Bit Width:1
        \ %x  30 lshift GPIOA_BSRR        \ GPIOA_BR14	Bit Offset:30	Bit Width:1
        \ %x  31 lshift GPIOA_BSRR        \ GPIOA_BR15	Bit Offset:31	Bit Width:1
        
        GPIOA $14 + constant GPIOA_BRR	\ write-only		\  : RESET_GPIOA_BRR $00000000 
        \ %x  0 lshift GPIOA_BRR        \ GPIOA_BR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift GPIOA_BRR        \ GPIOA_BR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift GPIOA_BRR        \ GPIOA_BR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift GPIOA_BRR        \ GPIOA_BR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift GPIOA_BRR        \ GPIOA_BR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift GPIOA_BRR        \ GPIOA_BR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift GPIOA_BRR        \ GPIOA_BR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift GPIOA_BRR        \ GPIOA_BR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift GPIOA_BRR        \ GPIOA_BR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift GPIOA_BRR        \ GPIOA_BR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift GPIOA_BRR        \ GPIOA_BR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift GPIOA_BRR        \ GPIOA_BR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift GPIOA_BRR        \ GPIOA_BR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift GPIOA_BRR        \ GPIOA_BR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift GPIOA_BRR        \ GPIOA_BR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift GPIOA_BRR        \ GPIOA_BR15	Bit Offset:15	Bit Width:1
        
        GPIOA $18 + constant GPIOA_LCKR	\ read-write		\  : RESET_GPIOA_LCKR $00000000 
        \ %x  0 lshift GPIOA_LCKR        \ GPIOA_LCK0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift GPIOA_LCKR        \ GPIOA_LCK1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift GPIOA_LCKR        \ GPIOA_LCK2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift GPIOA_LCKR        \ GPIOA_LCK3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift GPIOA_LCKR        \ GPIOA_LCK4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift GPIOA_LCKR        \ GPIOA_LCK5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift GPIOA_LCKR        \ GPIOA_LCK6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift GPIOA_LCKR        \ GPIOA_LCK7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift GPIOA_LCKR        \ GPIOA_LCK8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift GPIOA_LCKR        \ GPIOA_LCK9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift GPIOA_LCKR        \ GPIOA_LCK10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift GPIOA_LCKR        \ GPIOA_LCK11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift GPIOA_LCKR        \ GPIOA_LCK12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift GPIOA_LCKR        \ GPIOA_LCK13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift GPIOA_LCKR        \ GPIOA_LCK14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift GPIOA_LCKR        \ GPIOA_LCK15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift GPIOA_LCKR        \ GPIOA_LCKK	Bit Offset:16	Bit Width:1
        
         
	
     $40010C00 constant GPIOB  
	  
	
     $40011000 constant GPIOC  
	  
	
     $40011400 constant GPIOD  
	  
	
     $40011800 constant GPIOE  
	  
	
     $40010000 constant AFIO  
	 AFIO $0 + constant AFIO_EVCR	\ read-write		\  : RESET_AFIO_EVCR $00000000 
        \ %xxxx  0 lshift AFIO_EVCR        \ AFIO_PIN	Bit Offset:0	Bit Width:4
        \ %xxx  4 lshift AFIO_EVCR        \ AFIO_PORT	Bit Offset:4	Bit Width:3
        \ %x  7 lshift AFIO_EVCR        \ AFIO_EVOE	Bit Offset:7	Bit Width:1
        
        AFIO $4 + constant AFIO_MAPR	\ 		\  : RESET_AFIO_MAPR $00000000 
        \ %x  0 lshift AFIO_MAPR        \ AFIO_SPI1_REMAP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift AFIO_MAPR        \ AFIO_I2C1_REMAP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift AFIO_MAPR        \ AFIO_USART1_REMAP	Bit Offset:2	Bit Width:1
        \ %x  3 lshift AFIO_MAPR        \ AFIO_USART2_REMAP	Bit Offset:3	Bit Width:1
        \ %xx  4 lshift AFIO_MAPR        \ AFIO_USART3_REMAP	Bit Offset:4	Bit Width:2
        \ %xx  6 lshift AFIO_MAPR        \ AFIO_TIM1_REMAP	Bit Offset:6	Bit Width:2
        \ %xx  8 lshift AFIO_MAPR        \ AFIO_TIM2_REMAP	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift AFIO_MAPR        \ AFIO_TIM3_REMAP	Bit Offset:10	Bit Width:2
        \ %x  12 lshift AFIO_MAPR        \ AFIO_TIM4_REMAP	Bit Offset:12	Bit Width:1
        \ %xx  13 lshift AFIO_MAPR        \ AFIO_CAN1_REMAP	Bit Offset:13	Bit Width:2
        \ %x  15 lshift AFIO_MAPR        \ AFIO_PD01_REMAP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift AFIO_MAPR        \ AFIO_TIM5CH4_IREMAP	Bit Offset:16	Bit Width:1
        \ %x  21 lshift AFIO_MAPR        \ AFIO_ETH_REMAP	Bit Offset:21	Bit Width:1
        \ %x  22 lshift AFIO_MAPR        \ AFIO_CAN2_REMAP	Bit Offset:22	Bit Width:1
        \ %x  23 lshift AFIO_MAPR        \ AFIO_MII_RMII_SEL	Bit Offset:23	Bit Width:1
        \ %xxx  24 lshift AFIO_MAPR        \ AFIO_SWJ_CFG	Bit Offset:24	Bit Width:3
        \ %x  28 lshift AFIO_MAPR        \ AFIO_SPI3_REMAP	Bit Offset:28	Bit Width:1
        \ %x  29 lshift AFIO_MAPR        \ AFIO_TIM2ITR1_IREMAP	Bit Offset:29	Bit Width:1
        \ %x  30 lshift AFIO_MAPR        \ AFIO_PTP_PPS_REMAP	Bit Offset:30	Bit Width:1
        
        AFIO $8 + constant AFIO_EXTICR1	\ read-write		\  : RESET_AFIO_EXTICR1 $00000000 
        \ %xxxx  0 lshift AFIO_EXTICR1        \ AFIO_EXTI0	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift AFIO_EXTICR1        \ AFIO_EXTI1	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift AFIO_EXTICR1        \ AFIO_EXTI2	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift AFIO_EXTICR1        \ AFIO_EXTI3	Bit Offset:12	Bit Width:4
        
        AFIO $C + constant AFIO_EXTICR2	\ read-write		\  : RESET_AFIO_EXTICR2 $00000000 
        \ %xxxx  0 lshift AFIO_EXTICR2        \ AFIO_EXTI4	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift AFIO_EXTICR2        \ AFIO_EXTI5	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift AFIO_EXTICR2        \ AFIO_EXTI6	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift AFIO_EXTICR2        \ AFIO_EXTI7	Bit Offset:12	Bit Width:4
        
        AFIO $10 + constant AFIO_EXTICR3	\ read-write		\  : RESET_AFIO_EXTICR3 $00000000 
        \ %xxxx  0 lshift AFIO_EXTICR3        \ AFIO_EXTI8	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift AFIO_EXTICR3        \ AFIO_EXTI9	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift AFIO_EXTICR3        \ AFIO_EXTI10	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift AFIO_EXTICR3        \ AFIO_EXTI11	Bit Offset:12	Bit Width:4
        
        AFIO $14 + constant AFIO_EXTICR4	\ read-write		\  : RESET_AFIO_EXTICR4 $00000000 
        \ %xxxx  0 lshift AFIO_EXTICR4        \ AFIO_EXTI12	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift AFIO_EXTICR4        \ AFIO_EXTI13	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift AFIO_EXTICR4        \ AFIO_EXTI14	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift AFIO_EXTICR4        \ AFIO_EXTI15	Bit Offset:12	Bit Width:4
        
        AFIO $1C + constant AFIO_MAPR2	\ read-write		\  : RESET_AFIO_MAPR2 $00000000 
        \ %x  5 lshift AFIO_MAPR2        \ AFIO_TIM9_REMAP	Bit Offset:5	Bit Width:1
        \ %x  6 lshift AFIO_MAPR2        \ AFIO_TIM10_REMAP	Bit Offset:6	Bit Width:1
        \ %x  7 lshift AFIO_MAPR2        \ AFIO_TIM11_REMAP	Bit Offset:7	Bit Width:1
        \ %x  8 lshift AFIO_MAPR2        \ AFIO_TIM13_REMAP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift AFIO_MAPR2        \ AFIO_TIM14_REMAP	Bit Offset:9	Bit Width:1
        \ %x  10 lshift AFIO_MAPR2        \ AFIO_FSMC_NADV	Bit Offset:10	Bit Width:1
        
         
	
     $40010400 constant EXTI  
	 EXTI $0 + constant EXTI_IMR	\ read-write		\  : RESET_EXTI_IMR $00000000 
        \ %x  0 lshift EXTI_IMR        \ EXTI_MR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift EXTI_IMR        \ EXTI_MR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift EXTI_IMR        \ EXTI_MR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift EXTI_IMR        \ EXTI_MR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift EXTI_IMR        \ EXTI_MR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift EXTI_IMR        \ EXTI_MR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift EXTI_IMR        \ EXTI_MR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift EXTI_IMR        \ EXTI_MR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift EXTI_IMR        \ EXTI_MR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift EXTI_IMR        \ EXTI_MR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift EXTI_IMR        \ EXTI_MR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift EXTI_IMR        \ EXTI_MR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift EXTI_IMR        \ EXTI_MR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift EXTI_IMR        \ EXTI_MR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift EXTI_IMR        \ EXTI_MR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift EXTI_IMR        \ EXTI_MR15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift EXTI_IMR        \ EXTI_MR16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift EXTI_IMR        \ EXTI_MR17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift EXTI_IMR        \ EXTI_MR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_IMR        \ EXTI_MR19	Bit Offset:19	Bit Width:1
        
        EXTI $4 + constant EXTI_EMR	\ read-write		\  : RESET_EXTI_EMR $00000000 
        \ %x  0 lshift EXTI_EMR        \ EXTI_MR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift EXTI_EMR        \ EXTI_MR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift EXTI_EMR        \ EXTI_MR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift EXTI_EMR        \ EXTI_MR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift EXTI_EMR        \ EXTI_MR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift EXTI_EMR        \ EXTI_MR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift EXTI_EMR        \ EXTI_MR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift EXTI_EMR        \ EXTI_MR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift EXTI_EMR        \ EXTI_MR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift EXTI_EMR        \ EXTI_MR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift EXTI_EMR        \ EXTI_MR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift EXTI_EMR        \ EXTI_MR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift EXTI_EMR        \ EXTI_MR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift EXTI_EMR        \ EXTI_MR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift EXTI_EMR        \ EXTI_MR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift EXTI_EMR        \ EXTI_MR15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift EXTI_EMR        \ EXTI_MR16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift EXTI_EMR        \ EXTI_MR17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift EXTI_EMR        \ EXTI_MR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_EMR        \ EXTI_MR19	Bit Offset:19	Bit Width:1
        
        EXTI $8 + constant EXTI_RTSR	\ read-write		\  : RESET_EXTI_RTSR $00000000 
        \ %x  0 lshift EXTI_RTSR        \ EXTI_TR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift EXTI_RTSR        \ EXTI_TR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift EXTI_RTSR        \ EXTI_TR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift EXTI_RTSR        \ EXTI_TR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift EXTI_RTSR        \ EXTI_TR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift EXTI_RTSR        \ EXTI_TR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift EXTI_RTSR        \ EXTI_TR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift EXTI_RTSR        \ EXTI_TR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift EXTI_RTSR        \ EXTI_TR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift EXTI_RTSR        \ EXTI_TR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift EXTI_RTSR        \ EXTI_TR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift EXTI_RTSR        \ EXTI_TR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift EXTI_RTSR        \ EXTI_TR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift EXTI_RTSR        \ EXTI_TR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift EXTI_RTSR        \ EXTI_TR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift EXTI_RTSR        \ EXTI_TR15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift EXTI_RTSR        \ EXTI_TR16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift EXTI_RTSR        \ EXTI_TR17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift EXTI_RTSR        \ EXTI_TR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_RTSR        \ EXTI_TR19	Bit Offset:19	Bit Width:1
        
        EXTI $C + constant EXTI_FTSR	\ read-write		\  : RESET_EXTI_FTSR $00000000 
        \ %x  0 lshift EXTI_FTSR        \ EXTI_TR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift EXTI_FTSR        \ EXTI_TR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift EXTI_FTSR        \ EXTI_TR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift EXTI_FTSR        \ EXTI_TR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift EXTI_FTSR        \ EXTI_TR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift EXTI_FTSR        \ EXTI_TR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift EXTI_FTSR        \ EXTI_TR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift EXTI_FTSR        \ EXTI_TR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift EXTI_FTSR        \ EXTI_TR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift EXTI_FTSR        \ EXTI_TR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift EXTI_FTSR        \ EXTI_TR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift EXTI_FTSR        \ EXTI_TR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift EXTI_FTSR        \ EXTI_TR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift EXTI_FTSR        \ EXTI_TR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift EXTI_FTSR        \ EXTI_TR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift EXTI_FTSR        \ EXTI_TR15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift EXTI_FTSR        \ EXTI_TR16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift EXTI_FTSR        \ EXTI_TR17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift EXTI_FTSR        \ EXTI_TR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_FTSR        \ EXTI_TR19	Bit Offset:19	Bit Width:1
        
        EXTI $10 + constant EXTI_SWIER	\ read-write		\  : RESET_EXTI_SWIER $00000000 
        \ %x  0 lshift EXTI_SWIER        \ EXTI_SWIER0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift EXTI_SWIER        \ EXTI_SWIER1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift EXTI_SWIER        \ EXTI_SWIER2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift EXTI_SWIER        \ EXTI_SWIER3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift EXTI_SWIER        \ EXTI_SWIER4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift EXTI_SWIER        \ EXTI_SWIER5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift EXTI_SWIER        \ EXTI_SWIER6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift EXTI_SWIER        \ EXTI_SWIER7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift EXTI_SWIER        \ EXTI_SWIER8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift EXTI_SWIER        \ EXTI_SWIER9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift EXTI_SWIER        \ EXTI_SWIER10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift EXTI_SWIER        \ EXTI_SWIER11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift EXTI_SWIER        \ EXTI_SWIER12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift EXTI_SWIER        \ EXTI_SWIER13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift EXTI_SWIER        \ EXTI_SWIER14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift EXTI_SWIER        \ EXTI_SWIER15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift EXTI_SWIER        \ EXTI_SWIER16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift EXTI_SWIER        \ EXTI_SWIER17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift EXTI_SWIER        \ EXTI_SWIER18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_SWIER        \ EXTI_SWIER19	Bit Offset:19	Bit Width:1
        
        EXTI $14 + constant EXTI_PR	\ read-write		\  : RESET_EXTI_PR $00000000 
        \ %x  0 lshift EXTI_PR        \ EXTI_PR0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift EXTI_PR        \ EXTI_PR1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift EXTI_PR        \ EXTI_PR2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift EXTI_PR        \ EXTI_PR3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift EXTI_PR        \ EXTI_PR4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift EXTI_PR        \ EXTI_PR5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift EXTI_PR        \ EXTI_PR6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift EXTI_PR        \ EXTI_PR7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift EXTI_PR        \ EXTI_PR8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift EXTI_PR        \ EXTI_PR9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift EXTI_PR        \ EXTI_PR10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift EXTI_PR        \ EXTI_PR11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift EXTI_PR        \ EXTI_PR12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift EXTI_PR        \ EXTI_PR13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift EXTI_PR        \ EXTI_PR14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift EXTI_PR        \ EXTI_PR15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift EXTI_PR        \ EXTI_PR16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift EXTI_PR        \ EXTI_PR17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift EXTI_PR        \ EXTI_PR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_PR        \ EXTI_PR19	Bit Offset:19	Bit Width:1
        
         
	
     $40020000 constant DMA1  
	 DMA1 $0 + constant DMA1_ISR	\ read-only		\  : RESET_DMA1_ISR $00000000 
        \ %x  0 lshift DMA1_ISR        \ DMA1_GIF1	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_ISR        \ DMA1_TCIF1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_ISR        \ DMA1_HTIF1	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_ISR        \ DMA1_TEIF1	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_ISR        \ DMA1_GIF2	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_ISR        \ DMA1_TCIF2	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_ISR        \ DMA1_HTIF2	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_ISR        \ DMA1_TEIF2	Bit Offset:7	Bit Width:1
        \ %x  8 lshift DMA1_ISR        \ DMA1_GIF3	Bit Offset:8	Bit Width:1
        \ %x  9 lshift DMA1_ISR        \ DMA1_TCIF3	Bit Offset:9	Bit Width:1
        \ %x  10 lshift DMA1_ISR        \ DMA1_HTIF3	Bit Offset:10	Bit Width:1
        \ %x  11 lshift DMA1_ISR        \ DMA1_TEIF3	Bit Offset:11	Bit Width:1
        \ %x  12 lshift DMA1_ISR        \ DMA1_GIF4	Bit Offset:12	Bit Width:1
        \ %x  13 lshift DMA1_ISR        \ DMA1_TCIF4	Bit Offset:13	Bit Width:1
        \ %x  14 lshift DMA1_ISR        \ DMA1_HTIF4	Bit Offset:14	Bit Width:1
        \ %x  15 lshift DMA1_ISR        \ DMA1_TEIF4	Bit Offset:15	Bit Width:1
        \ %x  16 lshift DMA1_ISR        \ DMA1_GIF5	Bit Offset:16	Bit Width:1
        \ %x  17 lshift DMA1_ISR        \ DMA1_TCIF5	Bit Offset:17	Bit Width:1
        \ %x  18 lshift DMA1_ISR        \ DMA1_HTIF5	Bit Offset:18	Bit Width:1
        \ %x  19 lshift DMA1_ISR        \ DMA1_TEIF5	Bit Offset:19	Bit Width:1
        \ %x  20 lshift DMA1_ISR        \ DMA1_GIF6	Bit Offset:20	Bit Width:1
        \ %x  21 lshift DMA1_ISR        \ DMA1_TCIF6	Bit Offset:21	Bit Width:1
        \ %x  22 lshift DMA1_ISR        \ DMA1_HTIF6	Bit Offset:22	Bit Width:1
        \ %x  23 lshift DMA1_ISR        \ DMA1_TEIF6	Bit Offset:23	Bit Width:1
        \ %x  24 lshift DMA1_ISR        \ DMA1_GIF7	Bit Offset:24	Bit Width:1
        \ %x  25 lshift DMA1_ISR        \ DMA1_TCIF7	Bit Offset:25	Bit Width:1
        \ %x  26 lshift DMA1_ISR        \ DMA1_HTIF7	Bit Offset:26	Bit Width:1
        \ %x  27 lshift DMA1_ISR        \ DMA1_TEIF7	Bit Offset:27	Bit Width:1
        
        DMA1 $4 + constant DMA1_IFCR	\ write-only		\  : RESET_DMA1_IFCR $00000000 
        \ %x  0 lshift DMA1_IFCR        \ DMA1_CGIF1	Bit Offset:0	Bit Width:1
        \ %x  4 lshift DMA1_IFCR        \ DMA1_CGIF2	Bit Offset:4	Bit Width:1
        \ %x  8 lshift DMA1_IFCR        \ DMA1_CGIF3	Bit Offset:8	Bit Width:1
        \ %x  12 lshift DMA1_IFCR        \ DMA1_CGIF4	Bit Offset:12	Bit Width:1
        \ %x  16 lshift DMA1_IFCR        \ DMA1_CGIF5	Bit Offset:16	Bit Width:1
        \ %x  20 lshift DMA1_IFCR        \ DMA1_CGIF6	Bit Offset:20	Bit Width:1
        \ %x  24 lshift DMA1_IFCR        \ DMA1_CGIF7	Bit Offset:24	Bit Width:1
        \ %x  1 lshift DMA1_IFCR        \ DMA1_CTCIF1	Bit Offset:1	Bit Width:1
        \ %x  5 lshift DMA1_IFCR        \ DMA1_CTCIF2	Bit Offset:5	Bit Width:1
        \ %x  9 lshift DMA1_IFCR        \ DMA1_CTCIF3	Bit Offset:9	Bit Width:1
        \ %x  13 lshift DMA1_IFCR        \ DMA1_CTCIF4	Bit Offset:13	Bit Width:1
        \ %x  17 lshift DMA1_IFCR        \ DMA1_CTCIF5	Bit Offset:17	Bit Width:1
        \ %x  21 lshift DMA1_IFCR        \ DMA1_CTCIF6	Bit Offset:21	Bit Width:1
        \ %x  25 lshift DMA1_IFCR        \ DMA1_CTCIF7	Bit Offset:25	Bit Width:1
        \ %x  2 lshift DMA1_IFCR        \ DMA1_CHTIF1	Bit Offset:2	Bit Width:1
        \ %x  6 lshift DMA1_IFCR        \ DMA1_CHTIF2	Bit Offset:6	Bit Width:1
        \ %x  10 lshift DMA1_IFCR        \ DMA1_CHTIF3	Bit Offset:10	Bit Width:1
        \ %x  14 lshift DMA1_IFCR        \ DMA1_CHTIF4	Bit Offset:14	Bit Width:1
        \ %x  18 lshift DMA1_IFCR        \ DMA1_CHTIF5	Bit Offset:18	Bit Width:1
        \ %x  22 lshift DMA1_IFCR        \ DMA1_CHTIF6	Bit Offset:22	Bit Width:1
        \ %x  26 lshift DMA1_IFCR        \ DMA1_CHTIF7	Bit Offset:26	Bit Width:1
        \ %x  3 lshift DMA1_IFCR        \ DMA1_CTEIF1	Bit Offset:3	Bit Width:1
        \ %x  7 lshift DMA1_IFCR        \ DMA1_CTEIF2	Bit Offset:7	Bit Width:1
        \ %x  11 lshift DMA1_IFCR        \ DMA1_CTEIF3	Bit Offset:11	Bit Width:1
        \ %x  15 lshift DMA1_IFCR        \ DMA1_CTEIF4	Bit Offset:15	Bit Width:1
        \ %x  19 lshift DMA1_IFCR        \ DMA1_CTEIF5	Bit Offset:19	Bit Width:1
        \ %x  23 lshift DMA1_IFCR        \ DMA1_CTEIF6	Bit Offset:23	Bit Width:1
        \ %x  27 lshift DMA1_IFCR        \ DMA1_CTEIF7	Bit Offset:27	Bit Width:1
        
        DMA1 $8 + constant DMA1_CCR1	\ read-write		\  : RESET_DMA1_CCR1 $00000000 
        \ %x  0 lshift DMA1_CCR1        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR1        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR1        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR1        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR1        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR1        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR1        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR1        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR1        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR1        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR1        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR1        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $C + constant DMA1_CNDTR1	\ read-write		\  : RESET_DMA1_CNDTR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR1        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $10 + constant DMA1_CPAR1	\ read-write		\  : RESET_DMA1_CPAR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR1        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $14 + constant DMA1_CMAR1	\ read-write		\  : RESET_DMA1_CMAR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR1        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $1C + constant DMA1_CCR2	\ read-write		\  : RESET_DMA1_CCR2 $00000000 
        \ %x  0 lshift DMA1_CCR2        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR2        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR2        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR2        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR2        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR2        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR2        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR2        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR2        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR2        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR2        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR2        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $20 + constant DMA1_CNDTR2	\ read-write		\  : RESET_DMA1_CNDTR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR2        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $24 + constant DMA1_CPAR2	\ read-write		\  : RESET_DMA1_CPAR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR2        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $28 + constant DMA1_CMAR2	\ read-write		\  : RESET_DMA1_CMAR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR2        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $30 + constant DMA1_CCR3	\ read-write		\  : RESET_DMA1_CCR3 $00000000 
        \ %x  0 lshift DMA1_CCR3        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR3        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR3        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR3        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR3        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR3        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR3        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR3        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR3        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR3        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR3        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR3        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $34 + constant DMA1_CNDTR3	\ read-write		\  : RESET_DMA1_CNDTR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR3        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $38 + constant DMA1_CPAR3	\ read-write		\  : RESET_DMA1_CPAR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR3        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $3C + constant DMA1_CMAR3	\ read-write		\  : RESET_DMA1_CMAR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR3        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $44 + constant DMA1_CCR4	\ read-write		\  : RESET_DMA1_CCR4 $00000000 
        \ %x  0 lshift DMA1_CCR4        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR4        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR4        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR4        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR4        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR4        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR4        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR4        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR4        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR4        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR4        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR4        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $48 + constant DMA1_CNDTR4	\ read-write		\  : RESET_DMA1_CNDTR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR4        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $4C + constant DMA1_CPAR4	\ read-write		\  : RESET_DMA1_CPAR4 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR4        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $50 + constant DMA1_CMAR4	\ read-write		\  : RESET_DMA1_CMAR4 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR4        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $58 + constant DMA1_CCR5	\ read-write		\  : RESET_DMA1_CCR5 $00000000 
        \ %x  0 lshift DMA1_CCR5        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR5        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR5        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR5        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR5        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR5        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR5        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR5        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR5        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR5        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR5        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR5        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $5C + constant DMA1_CNDTR5	\ read-write		\  : RESET_DMA1_CNDTR5 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR5        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $60 + constant DMA1_CPAR5	\ read-write		\  : RESET_DMA1_CPAR5 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR5        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $64 + constant DMA1_CMAR5	\ read-write		\  : RESET_DMA1_CMAR5 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR5        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $6C + constant DMA1_CCR6	\ read-write		\  : RESET_DMA1_CCR6 $00000000 
        \ %x  0 lshift DMA1_CCR6        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR6        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR6        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR6        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR6        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR6        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR6        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR6        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR6        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR6        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR6        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR6        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $70 + constant DMA1_CNDTR6	\ read-write		\  : RESET_DMA1_CNDTR6 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR6        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $74 + constant DMA1_CPAR6	\ read-write		\  : RESET_DMA1_CPAR6 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR6        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $78 + constant DMA1_CMAR6	\ read-write		\  : RESET_DMA1_CMAR6 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR6        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $80 + constant DMA1_CCR7	\ read-write		\  : RESET_DMA1_CCR7 $00000000 
        \ %x  0 lshift DMA1_CCR7        \ DMA1_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DMA1_CCR7        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DMA1_CCR7        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DMA1_CCR7        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DMA1_CCR7        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DMA1_CCR7        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DMA1_CCR7        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DMA1_CCR7        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift DMA1_CCR7        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift DMA1_CCR7        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift DMA1_CCR7        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %x  14 lshift DMA1_CCR7        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        
        DMA1 $84 + constant DMA1_CNDTR7	\ read-write		\  : RESET_DMA1_CNDTR7 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR7        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $88 + constant DMA1_CPAR7	\ read-write		\  : RESET_DMA1_CPAR7 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR7        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $8C + constant DMA1_CMAR7	\ read-write		\  : RESET_DMA1_CMAR7 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR7        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
         
	
     $40020400 constant DMA2  
	  
	
     $40002800 constant RTC  
	 RTC $0 + constant RTC_CRH	\ read-write		\  : RESET_RTC_CRH $00000000 
        \ %x  0 lshift RTC_CRH        \ RTC_SECIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RTC_CRH        \ RTC_ALRIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RTC_CRH        \ RTC_OWIE	Bit Offset:2	Bit Width:1
        
        RTC $4 + constant RTC_CRL	\ 		\  : RESET_RTC_CRL $00000020 
        \ %x  0 lshift RTC_CRL        \ RTC_SECF	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RTC_CRL        \ RTC_ALRF	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RTC_CRL        \ RTC_OWF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RTC_CRL        \ RTC_RSF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RTC_CRL        \ RTC_CNF	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RTC_CRL        \ RTC_RTOFF	Bit Offset:5	Bit Width:1
        
        RTC $8 + constant RTC_PRLH	\ write-only		\  : RESET_RTC_PRLH $00000000 
        \ %xxxx  0 lshift RTC_PRLH        \ RTC_PRLH	Bit Offset:0	Bit Width:4
        
        RTC $C + constant RTC_PRLL	\ write-only		\  : RESET_RTC_PRLL $8000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_PRLL        \ RTC_PRLL	Bit Offset:0	Bit Width:16
        
        RTC $10 + constant RTC_DIVH	\ read-only		\  : RESET_RTC_DIVH $00000000 
        \ %xxxx  0 lshift RTC_DIVH        \ RTC_DIVH	Bit Offset:0	Bit Width:4
        
        RTC $14 + constant RTC_DIVL	\ read-only		\  : RESET_RTC_DIVL $8000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_DIVL        \ RTC_DIVL	Bit Offset:0	Bit Width:16
        
        RTC $18 + constant RTC_CNTH	\ read-write		\  : RESET_RTC_CNTH $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_CNTH        \ RTC_CNTH	Bit Offset:0	Bit Width:16
        
        RTC $1C + constant RTC_CNTL	\ read-write		\  : RESET_RTC_CNTL $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_CNTL        \ RTC_CNTL	Bit Offset:0	Bit Width:16
        
        RTC $20 + constant RTC_ALRH	\ write-only		\  : RESET_RTC_ALRH $FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_ALRH        \ RTC_ALRH	Bit Offset:0	Bit Width:16
        
        RTC $24 + constant RTC_ALRL	\ write-only		\  : RESET_RTC_ALRL $FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_ALRL        \ RTC_ALRL	Bit Offset:0	Bit Width:16
        
         
	
     $40006C04 constant BKP  
	 BKP $0 + constant BKP_DR1	\ read-write		\  : RESET_BKP_DR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR1        \ BKP_D1	Bit Offset:0	Bit Width:16
        
        BKP $4 + constant BKP_DR2	\ read-write		\  : RESET_BKP_DR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR2        \ BKP_D2	Bit Offset:0	Bit Width:16
        
        BKP $8 + constant BKP_DR3	\ read-write		\  : RESET_BKP_DR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR3        \ BKP_D3	Bit Offset:0	Bit Width:16
        
        BKP $C + constant BKP_DR4	\ read-write		\  : RESET_BKP_DR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR4        \ BKP_D4	Bit Offset:0	Bit Width:16
        
        BKP $10 + constant BKP_DR5	\ read-write		\  : RESET_BKP_DR5 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR5        \ BKP_D5	Bit Offset:0	Bit Width:16
        
        BKP $14 + constant BKP_DR6	\ read-write		\  : RESET_BKP_DR6 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR6        \ BKP_D6	Bit Offset:0	Bit Width:16
        
        BKP $18 + constant BKP_DR7	\ read-write		\  : RESET_BKP_DR7 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR7        \ BKP_D7	Bit Offset:0	Bit Width:16
        
        BKP $1C + constant BKP_DR8	\ read-write		\  : RESET_BKP_DR8 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR8        \ BKP_D8	Bit Offset:0	Bit Width:16
        
        BKP $20 + constant BKP_DR9	\ read-write		\  : RESET_BKP_DR9 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR9        \ BKP_D9	Bit Offset:0	Bit Width:16
        
        BKP $24 + constant BKP_DR10	\ read-write		\  : RESET_BKP_DR10 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR10        \ BKP_D10	Bit Offset:0	Bit Width:16
        
        BKP $3C + constant BKP_DR11	\ read-write		\  : RESET_BKP_DR11 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR11        \ BKP_DR11	Bit Offset:0	Bit Width:16
        
        BKP $40 + constant BKP_DR12	\ read-write		\  : RESET_BKP_DR12 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR12        \ BKP_DR12	Bit Offset:0	Bit Width:16
        
        BKP $44 + constant BKP_DR13	\ read-write		\  : RESET_BKP_DR13 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR13        \ BKP_DR13	Bit Offset:0	Bit Width:16
        
        BKP $48 + constant BKP_DR14	\ read-write		\  : RESET_BKP_DR14 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR14        \ BKP_D14	Bit Offset:0	Bit Width:16
        
        BKP $4C + constant BKP_DR15	\ read-write		\  : RESET_BKP_DR15 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR15        \ BKP_D15	Bit Offset:0	Bit Width:16
        
        BKP $50 + constant BKP_DR16	\ read-write		\  : RESET_BKP_DR16 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR16        \ BKP_D16	Bit Offset:0	Bit Width:16
        
        BKP $54 + constant BKP_DR17	\ read-write		\  : RESET_BKP_DR17 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR17        \ BKP_D17	Bit Offset:0	Bit Width:16
        
        BKP $58 + constant BKP_DR18	\ read-write		\  : RESET_BKP_DR18 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR18        \ BKP_D18	Bit Offset:0	Bit Width:16
        
        BKP $5C + constant BKP_DR19	\ read-write		\  : RESET_BKP_DR19 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR19        \ BKP_D19	Bit Offset:0	Bit Width:16
        
        BKP $60 + constant BKP_DR20	\ read-write		\  : RESET_BKP_DR20 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR20        \ BKP_D20	Bit Offset:0	Bit Width:16
        
        BKP $64 + constant BKP_DR21	\ read-write		\  : RESET_BKP_DR21 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR21        \ BKP_D21	Bit Offset:0	Bit Width:16
        
        BKP $68 + constant BKP_DR22	\ read-write		\  : RESET_BKP_DR22 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR22        \ BKP_D22	Bit Offset:0	Bit Width:16
        
        BKP $6C + constant BKP_DR23	\ read-write		\  : RESET_BKP_DR23 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR23        \ BKP_D23	Bit Offset:0	Bit Width:16
        
        BKP $70 + constant BKP_DR24	\ read-write		\  : RESET_BKP_DR24 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR24        \ BKP_D24	Bit Offset:0	Bit Width:16
        
        BKP $74 + constant BKP_DR25	\ read-write		\  : RESET_BKP_DR25 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR25        \ BKP_D25	Bit Offset:0	Bit Width:16
        
        BKP $78 + constant BKP_DR26	\ read-write		\  : RESET_BKP_DR26 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR26        \ BKP_D26	Bit Offset:0	Bit Width:16
        
        BKP $7C + constant BKP_DR27	\ read-write		\  : RESET_BKP_DR27 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR27        \ BKP_D27	Bit Offset:0	Bit Width:16
        
        BKP $80 + constant BKP_DR28	\ read-write		\  : RESET_BKP_DR28 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR28        \ BKP_D28	Bit Offset:0	Bit Width:16
        
        BKP $84 + constant BKP_DR29	\ read-write		\  : RESET_BKP_DR29 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR29        \ BKP_D29	Bit Offset:0	Bit Width:16
        
        BKP $88 + constant BKP_DR30	\ read-write		\  : RESET_BKP_DR30 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR30        \ BKP_D30	Bit Offset:0	Bit Width:16
        
        BKP $8C + constant BKP_DR31	\ read-write		\  : RESET_BKP_DR31 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR31        \ BKP_D31	Bit Offset:0	Bit Width:16
        
        BKP $90 + constant BKP_DR32	\ read-write		\  : RESET_BKP_DR32 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR32        \ BKP_D32	Bit Offset:0	Bit Width:16
        
        BKP $94 + constant BKP_DR33	\ read-write		\  : RESET_BKP_DR33 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR33        \ BKP_D33	Bit Offset:0	Bit Width:16
        
        BKP $98 + constant BKP_DR34	\ read-write		\  : RESET_BKP_DR34 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR34        \ BKP_D34	Bit Offset:0	Bit Width:16
        
        BKP $9C + constant BKP_DR35	\ read-write		\  : RESET_BKP_DR35 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR35        \ BKP_D35	Bit Offset:0	Bit Width:16
        
        BKP $A0 + constant BKP_DR36	\ read-write		\  : RESET_BKP_DR36 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR36        \ BKP_D36	Bit Offset:0	Bit Width:16
        
        BKP $A4 + constant BKP_DR37	\ read-write		\  : RESET_BKP_DR37 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR37        \ BKP_D37	Bit Offset:0	Bit Width:16
        
        BKP $A8 + constant BKP_DR38	\ read-write		\  : RESET_BKP_DR38 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR38        \ BKP_D38	Bit Offset:0	Bit Width:16
        
        BKP $AC + constant BKP_DR39	\ read-write		\  : RESET_BKP_DR39 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR39        \ BKP_D39	Bit Offset:0	Bit Width:16
        
        BKP $B0 + constant BKP_DR40	\ read-write		\  : RESET_BKP_DR40 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR40        \ BKP_D40	Bit Offset:0	Bit Width:16
        
        BKP $B4 + constant BKP_DR41	\ read-write		\  : RESET_BKP_DR41 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR41        \ BKP_D41	Bit Offset:0	Bit Width:16
        
        BKP $B8 + constant BKP_DR42	\ read-write		\  : RESET_BKP_DR42 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift BKP_DR42        \ BKP_D42	Bit Offset:0	Bit Width:16
        
        BKP $28 + constant BKP_RTCCR	\ read-write		\  : RESET_BKP_RTCCR $00000000 
        \ %xxxxxxx  0 lshift BKP_RTCCR        \ BKP_CAL	Bit Offset:0	Bit Width:7
        \ %x  7 lshift BKP_RTCCR        \ BKP_CCO	Bit Offset:7	Bit Width:1
        \ %x  8 lshift BKP_RTCCR        \ BKP_ASOE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift BKP_RTCCR        \ BKP_ASOS	Bit Offset:9	Bit Width:1
        
        BKP $2C + constant BKP_CR	\ read-write		\  : RESET_BKP_CR $00000000 
        \ %x  0 lshift BKP_CR        \ BKP_TPE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift BKP_CR        \ BKP_TPAL	Bit Offset:1	Bit Width:1
        
        BKP $30 + constant BKP_CSR	\ 		\  : RESET_BKP_CSR $00000000 
        \ %x  0 lshift BKP_CSR        \ BKP_CTE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift BKP_CSR        \ BKP_CTI	Bit Offset:1	Bit Width:1
        \ %x  2 lshift BKP_CSR        \ BKP_TPIE	Bit Offset:2	Bit Width:1
        \ %x  8 lshift BKP_CSR        \ BKP_TEF	Bit Offset:8	Bit Width:1
        \ %x  9 lshift BKP_CSR        \ BKP_TIF	Bit Offset:9	Bit Width:1
        
         
	
     $40003000 constant IWDG  
	 IWDG $0 + constant IWDG_KR	\ write-only		\  : RESET_IWDG_KR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift IWDG_KR        \ IWDG_KEY	Bit Offset:0	Bit Width:16
        
        IWDG $4 + constant IWDG_PR	\ read-write		\  : RESET_IWDG_PR $00000000 
        \ %xxx  0 lshift IWDG_PR        \ IWDG_PR	Bit Offset:0	Bit Width:3
        
        IWDG $8 + constant IWDG_RLR	\ read-write		\  : RESET_IWDG_RLR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift IWDG_RLR        \ IWDG_RL	Bit Offset:0	Bit Width:12
        
        IWDG $C + constant IWDG_SR	\ read-only		\  : RESET_IWDG_SR $00000000 
        \ %x  0 lshift IWDG_SR        \ IWDG_PVU	Bit Offset:0	Bit Width:1
        \ %x  1 lshift IWDG_SR        \ IWDG_RVU	Bit Offset:1	Bit Width:1
        
         
	
     $40002C00 constant WWDG  
	 WWDG $0 + constant WWDG_CR	\ read-write		\  : RESET_WWDG_CR $0000007F 
        \ %xxxxxxx  0 lshift WWDG_CR        \ WWDG_T	Bit Offset:0	Bit Width:7
        \ %x  7 lshift WWDG_CR        \ WWDG_WDGA	Bit Offset:7	Bit Width:1
        
        WWDG $4 + constant WWDG_CFR	\ read-write		\  : RESET_WWDG_CFR $0000007F 
        \ %xxxxxxx  0 lshift WWDG_CFR        \ WWDG_W	Bit Offset:0	Bit Width:7
        \ %xx  7 lshift WWDG_CFR        \ WWDG_WDGTB	Bit Offset:7	Bit Width:2
        \ %x  9 lshift WWDG_CFR        \ WWDG_EWI	Bit Offset:9	Bit Width:1
        
        WWDG $8 + constant WWDG_SR	\ read-write		\  : RESET_WWDG_SR $00000000 
        \ %x  0 lshift WWDG_SR        \ WWDG_EWI	Bit Offset:0	Bit Width:1
        
         
	
     $40012C00 constant TIM1  
	 TIM1 $0 + constant TIM1_CR1	\ read-write		\  : RESET_TIM1_CR1 $0000 
        \ %xx  8 lshift TIM1_CR1        \ TIM1_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM1_CR1        \ TIM1_ARPE	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift TIM1_CR1        \ TIM1_CMS	Bit Offset:5	Bit Width:2
        \ %x  4 lshift TIM1_CR1        \ TIM1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_CR1        \ TIM1_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_CR1        \ TIM1_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_CR1        \ TIM1_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_CR1        \ TIM1_CEN	Bit Offset:0	Bit Width:1
        
        TIM1 $4 + constant TIM1_CR2	\ read-write		\  : RESET_TIM1_CR2 $0000 
        \ %x  14 lshift TIM1_CR2        \ TIM1_OIS4	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TIM1_CR2        \ TIM1_OIS3N	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM1_CR2        \ TIM1_OIS3	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_CR2        \ TIM1_OIS2N	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_CR2        \ TIM1_OIS2	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM1_CR2        \ TIM1_OIS1N	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM1_CR2        \ TIM1_OIS1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM1_CR2        \ TIM1_TI1S	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM1_CR2        \ TIM1_MMS	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM1_CR2        \ TIM1_CCDS	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_CR2        \ TIM1_CCUS	Bit Offset:2	Bit Width:1
        \ %x  0 lshift TIM1_CR2        \ TIM1_CCPC	Bit Offset:0	Bit Width:1
        
        TIM1 $8 + constant TIM1_SMCR	\ read-write		\  : RESET_TIM1_SMCR $0000 
        \ %x  15 lshift TIM1_SMCR        \ TIM1_ETP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM1_SMCR        \ TIM1_ECE	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift TIM1_SMCR        \ TIM1_ETPS	Bit Offset:12	Bit Width:2
        \ %xxxx  8 lshift TIM1_SMCR        \ TIM1_ETF	Bit Offset:8	Bit Width:4
        \ %x  7 lshift TIM1_SMCR        \ TIM1_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM1_SMCR        \ TIM1_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM1_SMCR        \ TIM1_SMS	Bit Offset:0	Bit Width:3
        
        TIM1 $C + constant TIM1_DIER	\ read-write		\  : RESET_TIM1_DIER $0000 
        \ %x  14 lshift TIM1_DIER        \ TIM1_TDE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TIM1_DIER        \ TIM1_COMDE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM1_DIER        \ TIM1_CC4DE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_DIER        \ TIM1_CC3DE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_DIER        \ TIM1_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM1_DIER        \ TIM1_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM1_DIER        \ TIM1_UDE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift TIM1_DIER        \ TIM1_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM1_DIER        \ TIM1_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_DIER        \ TIM1_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_DIER        \ TIM1_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_DIER        \ TIM1_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_DIER        \ TIM1_UIE	Bit Offset:0	Bit Width:1
        \ %x  7 lshift TIM1_DIER        \ TIM1_BIE	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM1_DIER        \ TIM1_COMIE	Bit Offset:5	Bit Width:1
        
        TIM1 $10 + constant TIM1_SR	\ read-write		\  : RESET_TIM1_SR $0000 
        \ %x  12 lshift TIM1_SR        \ TIM1_CC4OF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_SR        \ TIM1_CC3OF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_SR        \ TIM1_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM1_SR        \ TIM1_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  7 lshift TIM1_SR        \ TIM1_BIF	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM1_SR        \ TIM1_TIF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM1_SR        \ TIM1_COMIF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM1_SR        \ TIM1_CC4IF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_SR        \ TIM1_CC3IF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_SR        \ TIM1_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_SR        \ TIM1_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_SR        \ TIM1_UIF	Bit Offset:0	Bit Width:1
        
        TIM1 $14 + constant TIM1_EGR	\ write-only		\  : RESET_TIM1_EGR $0000 
        \ %x  7 lshift TIM1_EGR        \ TIM1_BG	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM1_EGR        \ TIM1_TG	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM1_EGR        \ TIM1_COMG	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM1_EGR        \ TIM1_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_EGR        \ TIM1_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_EGR        \ TIM1_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_EGR        \ TIM1_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_EGR        \ TIM1_UG	Bit Offset:0	Bit Width:1
        
        TIM1 $18 + constant TIM1_CCMR1_Output	\ read-write		\  : RESET_TIM1_CCMR1_Output $00000000 
        \ %x  15 lshift TIM1_CCMR1_Output        \ TIM1_OC2CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM1_CCMR1_Output        \ TIM1_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM1_CCMR1_Output        \ TIM1_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_CCMR1_Output        \ TIM1_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM1_CCMR1_Output        \ TIM1_CC2S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM1_CCMR1_Output        \ TIM1_OC1CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM1_CCMR1_Output        \ TIM1_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM1_CCMR1_Output        \ TIM1_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_CCMR1_Output        \ TIM1_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM1_CCMR1_Output        \ TIM1_CC1S	Bit Offset:0	Bit Width:2
        
        TIM1 $18 + constant TIM1_CCMR1_Input	\ read-write		\  : RESET_TIM1_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM1_CCMR1_Input        \ TIM1_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM1_CCMR1_Input        \ TIM1_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM1_CCMR1_Input        \ TIM1_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM1_CCMR1_Input        \ TIM1_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM1_CCMR1_Input        \ TIM1_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM1_CCMR1_Input        \ TIM1_CC1S	Bit Offset:0	Bit Width:2
        
        TIM1 $1C + constant TIM1_CCMR2_Output	\ read-write		\  : RESET_TIM1_CCMR2_Output $00000000 
        \ %x  15 lshift TIM1_CCMR2_Output        \ TIM1_OC4CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM1_CCMR2_Output        \ TIM1_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM1_CCMR2_Output        \ TIM1_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_CCMR2_Output        \ TIM1_OC4FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM1_CCMR2_Output        \ TIM1_CC4S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM1_CCMR2_Output        \ TIM1_OC3CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM1_CCMR2_Output        \ TIM1_OC3M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM1_CCMR2_Output        \ TIM1_OC3PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_CCMR2_Output        \ TIM1_OC3FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM1_CCMR2_Output        \ TIM1_CC3S	Bit Offset:0	Bit Width:2
        
        TIM1 $1C + constant TIM1_CCMR2_Input	\ read-write		\  : RESET_TIM1_CCMR2_Input $00000000 
        \ %xxxx  12 lshift TIM1_CCMR2_Input        \ TIM1_IC4F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM1_CCMR2_Input        \ TIM1_IC4PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM1_CCMR2_Input        \ TIM1_CC4S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM1_CCMR2_Input        \ TIM1_IC3F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM1_CCMR2_Input        \ TIM1_IC3PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM1_CCMR2_Input        \ TIM1_CC3S	Bit Offset:0	Bit Width:2
        
        TIM1 $20 + constant TIM1_CCER	\ read-write		\  : RESET_TIM1_CCER $0000 
        \ %x  13 lshift TIM1_CCER        \ TIM1_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM1_CCER        \ TIM1_CC4E	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_CCER        \ TIM1_CC3NP	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_CCER        \ TIM1_CC3NE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM1_CCER        \ TIM1_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM1_CCER        \ TIM1_CC3E	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM1_CCER        \ TIM1_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM1_CCER        \ TIM1_CC2NE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM1_CCER        \ TIM1_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM1_CCER        \ TIM1_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_CCER        \ TIM1_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_CCER        \ TIM1_CC1NE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_CCER        \ TIM1_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_CCER        \ TIM1_CC1E	Bit Offset:0	Bit Width:1
        
        TIM1 $24 + constant TIM1_CNT	\ read-write		\  : RESET_TIM1_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_CNT        \ TIM1_CNT	Bit Offset:0	Bit Width:16
        
        TIM1 $28 + constant TIM1_PSC	\ read-write		\  : RESET_TIM1_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_PSC        \ TIM1_PSC	Bit Offset:0	Bit Width:16
        
        TIM1 $2C + constant TIM1_ARR	\ read-write		\  : RESET_TIM1_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_ARR        \ TIM1_ARR	Bit Offset:0	Bit Width:16
        
        TIM1 $34 + constant TIM1_CCR1	\ read-write		\  : RESET_TIM1_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_CCR1        \ TIM1_CCR1	Bit Offset:0	Bit Width:16
        
        TIM1 $38 + constant TIM1_CCR2	\ read-write		\  : RESET_TIM1_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_CCR2        \ TIM1_CCR2	Bit Offset:0	Bit Width:16
        
        TIM1 $3C + constant TIM1_CCR3	\ read-write		\  : RESET_TIM1_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_CCR3        \ TIM1_CCR3	Bit Offset:0	Bit Width:16
        
        TIM1 $40 + constant TIM1_CCR4	\ read-write		\  : RESET_TIM1_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_CCR4        \ TIM1_CCR4	Bit Offset:0	Bit Width:16
        
        TIM1 $48 + constant TIM1_DCR	\ read-write		\  : RESET_TIM1_DCR $0000 
        \ %xxxxx  8 lshift TIM1_DCR        \ TIM1_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM1_DCR        \ TIM1_DBA	Bit Offset:0	Bit Width:5
        
        TIM1 $4C + constant TIM1_DMAR	\ read-write		\  : RESET_TIM1_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_DMAR        \ TIM1_DMAB	Bit Offset:0	Bit Width:16
        
        TIM1 $30 + constant TIM1_RCR	\ read-write		\  : RESET_TIM1_RCR $0000 
        \ %xxxxxxxx  0 lshift TIM1_RCR        \ TIM1_REP	Bit Offset:0	Bit Width:8
        
        TIM1 $44 + constant TIM1_BDTR	\ read-write		\  : RESET_TIM1_BDTR $0000 
        \ %x  15 lshift TIM1_BDTR        \ TIM1_MOE	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM1_BDTR        \ TIM1_AOE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TIM1_BDTR        \ TIM1_BKP	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM1_BDTR        \ TIM1_BKE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_BDTR        \ TIM1_OSSR	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_BDTR        \ TIM1_OSSI	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM1_BDTR        \ TIM1_LOCK	Bit Offset:8	Bit Width:2
        \ %xxxxxxxx  0 lshift TIM1_BDTR        \ TIM1_DTG	Bit Offset:0	Bit Width:8
        
         
	
     $40000000 constant TIM2  
	 TIM2 $0 + constant TIM2_CR1	\ read-write		\  : RESET_TIM2_CR1 $0000 
        \ %xx  8 lshift TIM2_CR1        \ TIM2_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM2_CR1        \ TIM2_ARPE	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift TIM2_CR1        \ TIM2_CMS	Bit Offset:5	Bit Width:2
        \ %x  4 lshift TIM2_CR1        \ TIM2_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_CR1        \ TIM2_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_CR1        \ TIM2_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_CR1        \ TIM2_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_CR1        \ TIM2_CEN	Bit Offset:0	Bit Width:1
        
        TIM2 $4 + constant TIM2_CR2	\ read-write		\  : RESET_TIM2_CR2 $0000 
        \ %x  7 lshift TIM2_CR2        \ TIM2_TI1S	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_CR2        \ TIM2_MMS	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM2_CR2        \ TIM2_CCDS	Bit Offset:3	Bit Width:1
        
        TIM2 $8 + constant TIM2_SMCR	\ read-write		\  : RESET_TIM2_SMCR $0000 
        \ %x  15 lshift TIM2_SMCR        \ TIM2_ETP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM2_SMCR        \ TIM2_ECE	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift TIM2_SMCR        \ TIM2_ETPS	Bit Offset:12	Bit Width:2
        \ %xxxx  8 lshift TIM2_SMCR        \ TIM2_ETF	Bit Offset:8	Bit Width:4
        \ %x  7 lshift TIM2_SMCR        \ TIM2_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_SMCR        \ TIM2_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM2_SMCR        \ TIM2_SMS	Bit Offset:0	Bit Width:3
        
        TIM2 $C + constant TIM2_DIER	\ read-write		\  : RESET_TIM2_DIER $0000 
        \ %x  14 lshift TIM2_DIER        \ TIM2_TDE	Bit Offset:14	Bit Width:1
        \ %x  12 lshift TIM2_DIER        \ TIM2_CC4DE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM2_DIER        \ TIM2_CC3DE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_DIER        \ TIM2_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM2_DIER        \ TIM2_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM2_DIER        \ TIM2_UDE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift TIM2_DIER        \ TIM2_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_DIER        \ TIM2_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_DIER        \ TIM2_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_DIER        \ TIM2_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_DIER        \ TIM2_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_DIER        \ TIM2_UIE	Bit Offset:0	Bit Width:1
        
        TIM2 $10 + constant TIM2_SR	\ read-write		\  : RESET_TIM2_SR $0000 
        \ %x  12 lshift TIM2_SR        \ TIM2_CC4OF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM2_SR        \ TIM2_CC3OF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_SR        \ TIM2_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM2_SR        \ TIM2_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM2_SR        \ TIM2_TIF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_SR        \ TIM2_CC4IF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_SR        \ TIM2_CC3IF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_SR        \ TIM2_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_SR        \ TIM2_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_SR        \ TIM2_UIF	Bit Offset:0	Bit Width:1
        
        TIM2 $14 + constant TIM2_EGR	\ write-only		\  : RESET_TIM2_EGR $0000 
        \ %x  6 lshift TIM2_EGR        \ TIM2_TG	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_EGR        \ TIM2_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_EGR        \ TIM2_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_EGR        \ TIM2_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_EGR        \ TIM2_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_EGR        \ TIM2_UG	Bit Offset:0	Bit Width:1
        
        TIM2 $18 + constant TIM2_CCMR1_Output	\ read-write		\  : RESET_TIM2_CCMR1_Output $00000000 
        \ %x  15 lshift TIM2_CCMR1_Output        \ TIM2_OC2CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM2_CCMR1_Output        \ TIM2_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM2_CCMR1_Output        \ TIM2_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_CCMR1_Output        \ TIM2_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM2_CCMR1_Output        \ TIM2_CC2S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM2_CCMR1_Output        \ TIM2_OC1CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_CCMR1_Output        \ TIM2_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM2_CCMR1_Output        \ TIM2_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_CCMR1_Output        \ TIM2_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM2_CCMR1_Output        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        
        TIM2 $18 + constant TIM2_CCMR1_Input	\ read-write		\  : RESET_TIM2_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM2_CCMR1_Input        \ TIM2_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM2_CCMR1_Input        \ TIM2_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM2_CCMR1_Input        \ TIM2_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM2_CCMR1_Input        \ TIM2_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM2_CCMR1_Input        \ TIM2_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM2_CCMR1_Input        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        
        TIM2 $1C + constant TIM2_CCMR2_Output	\ read-write		\  : RESET_TIM2_CCMR2_Output $00000000 
        \ %x  15 lshift TIM2_CCMR2_Output        \ TIM2_OC4CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM2_CCMR2_Output        \ TIM2_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM2_CCMR2_Output        \ TIM2_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_CCMR2_Output        \ TIM2_OC4FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM2_CCMR2_Output        \ TIM2_CC4S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM2_CCMR2_Output        \ TIM2_OC3CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_CCMR2_Output        \ TIM2_OC3M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM2_CCMR2_Output        \ TIM2_OC3PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_CCMR2_Output        \ TIM2_OC3FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM2_CCMR2_Output        \ TIM2_CC3S	Bit Offset:0	Bit Width:2
        
        TIM2 $1C + constant TIM2_CCMR2_Input	\ read-write		\  : RESET_TIM2_CCMR2_Input $00000000 
        \ %xxxx  12 lshift TIM2_CCMR2_Input        \ TIM2_IC4F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM2_CCMR2_Input        \ TIM2_IC4PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM2_CCMR2_Input        \ TIM2_CC4S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM2_CCMR2_Input        \ TIM2_IC3F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM2_CCMR2_Input        \ TIM2_IC3PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM2_CCMR2_Input        \ TIM2_CC3S	Bit Offset:0	Bit Width:2
        
        TIM2 $20 + constant TIM2_CCER	\ read-write		\  : RESET_TIM2_CCER $0000 
        \ %x  13 lshift TIM2_CCER        \ TIM2_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM2_CCER        \ TIM2_CC4E	Bit Offset:12	Bit Width:1
        \ %x  9 lshift TIM2_CCER        \ TIM2_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM2_CCER        \ TIM2_CC3E	Bit Offset:8	Bit Width:1
        \ %x  5 lshift TIM2_CCER        \ TIM2_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM2_CCER        \ TIM2_CC2E	Bit Offset:4	Bit Width:1
        \ %x  1 lshift TIM2_CCER        \ TIM2_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_CCER        \ TIM2_CC1E	Bit Offset:0	Bit Width:1
        
        TIM2 $24 + constant TIM2_CNT	\ read-write		\  : RESET_TIM2_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CNT        \ TIM2_CNT	Bit Offset:0	Bit Width:16
        
        TIM2 $28 + constant TIM2_PSC	\ read-write		\  : RESET_TIM2_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_PSC        \ TIM2_PSC	Bit Offset:0	Bit Width:16
        
        TIM2 $2C + constant TIM2_ARR	\ read-write		\  : RESET_TIM2_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_ARR        \ TIM2_ARR	Bit Offset:0	Bit Width:16
        
        TIM2 $34 + constant TIM2_CCR1	\ read-write		\  : RESET_TIM2_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR1        \ TIM2_CCR1	Bit Offset:0	Bit Width:16
        
        TIM2 $38 + constant TIM2_CCR2	\ read-write		\  : RESET_TIM2_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR2        \ TIM2_CCR2	Bit Offset:0	Bit Width:16
        
        TIM2 $3C + constant TIM2_CCR3	\ read-write		\  : RESET_TIM2_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR3        \ TIM2_CCR3	Bit Offset:0	Bit Width:16
        
        TIM2 $40 + constant TIM2_CCR4	\ read-write		\  : RESET_TIM2_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR4        \ TIM2_CCR4	Bit Offset:0	Bit Width:16
        
        TIM2 $48 + constant TIM2_DCR	\ read-write		\  : RESET_TIM2_DCR $0000 
        \ %xxxxx  8 lshift TIM2_DCR        \ TIM2_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM2_DCR        \ TIM2_DBA	Bit Offset:0	Bit Width:5
        
        TIM2 $4C + constant TIM2_DMAR	\ read-write		\  : RESET_TIM2_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_DMAR        \ TIM2_DMAB	Bit Offset:0	Bit Width:16
        
         
	
     $40000400 constant TIM3  
	  
	
     $40000800 constant TIM4  
	  
	
     $40000C00 constant TIM5  
	  
	
     $40001000 constant TIM6  
	 TIM6 $0 + constant TIM6_CR1	\ read-write		\  : RESET_TIM6_CR1 $0000 
        \ %x  7 lshift TIM6_CR1        \ TIM6_ARPE	Bit Offset:7	Bit Width:1
        \ %x  3 lshift TIM6_CR1        \ TIM6_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM6_CR1        \ TIM6_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM6_CR1        \ TIM6_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM6_CR1        \ TIM6_CEN	Bit Offset:0	Bit Width:1
        
        TIM6 $4 + constant TIM6_CR2	\ read-write		\  : RESET_TIM6_CR2 $0000 
        \ %xxx  4 lshift TIM6_CR2        \ TIM6_MMS	Bit Offset:4	Bit Width:3
        
        TIM6 $C + constant TIM6_DIER	\ read-write		\  : RESET_TIM6_DIER $0000 
        \ %x  8 lshift TIM6_DIER        \ TIM6_UDE	Bit Offset:8	Bit Width:1
        \ %x  0 lshift TIM6_DIER        \ TIM6_UIE	Bit Offset:0	Bit Width:1
        
        TIM6 $10 + constant TIM6_SR	\ read-write		\  : RESET_TIM6_SR $0000 
        \ %x  0 lshift TIM6_SR        \ TIM6_UIF	Bit Offset:0	Bit Width:1
        
        TIM6 $14 + constant TIM6_EGR	\ write-only		\  : RESET_TIM6_EGR $0000 
        \ %x  0 lshift TIM6_EGR        \ TIM6_UG	Bit Offset:0	Bit Width:1
        
        TIM6 $24 + constant TIM6_CNT	\ read-write		\  : RESET_TIM6_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM6_CNT        \ TIM6_CNT	Bit Offset:0	Bit Width:16
        
        TIM6 $28 + constant TIM6_PSC	\ read-write		\  : RESET_TIM6_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM6_PSC        \ TIM6_PSC	Bit Offset:0	Bit Width:16
        
        TIM6 $2C + constant TIM6_ARR	\ read-write		\  : RESET_TIM6_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM6_ARR        \ TIM6_ARR	Bit Offset:0	Bit Width:16
        
         
	
     $40001400 constant TIM7  
	  
	
     $40005400 constant I2C1  
	 I2C1 $0 + constant I2C1_CR1	\ read-write		\  : RESET_I2C1_CR1 $0000 
        \ %x  15 lshift I2C1_CR1        \ I2C1_SWRST	Bit Offset:15	Bit Width:1
        \ %x  13 lshift I2C1_CR1        \ I2C1_ALERT	Bit Offset:13	Bit Width:1
        \ %x  12 lshift I2C1_CR1        \ I2C1_PEC	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C1_CR1        \ I2C1_POS	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C1_CR1        \ I2C1_ACK	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C1_CR1        \ I2C1_STOP	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C1_CR1        \ I2C1_START	Bit Offset:8	Bit Width:1
        \ %x  7 lshift I2C1_CR1        \ I2C1_NOSTRETCH	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C1_CR1        \ I2C1_ENGC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift I2C1_CR1        \ I2C1_ENPEC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift I2C1_CR1        \ I2C1_ENARP	Bit Offset:4	Bit Width:1
        \ %x  3 lshift I2C1_CR1        \ I2C1_SMBTYPE	Bit Offset:3	Bit Width:1
        \ %x  1 lshift I2C1_CR1        \ I2C1_SMBUS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C1_CR1        \ I2C1_PE	Bit Offset:0	Bit Width:1
        
        I2C1 $4 + constant I2C1_CR2	\ read-write		\  : RESET_I2C1_CR2 $0000 
        \ %x  12 lshift I2C1_CR2        \ I2C1_LAST	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C1_CR2        \ I2C1_DMAEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C1_CR2        \ I2C1_ITBUFEN	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C1_CR2        \ I2C1_ITEVTEN	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C1_CR2        \ I2C1_ITERREN	Bit Offset:8	Bit Width:1
        \ %xxxxxx  0 lshift I2C1_CR2        \ I2C1_FREQ	Bit Offset:0	Bit Width:6
        
        I2C1 $8 + constant I2C1_OAR1	\ read-write		\  : RESET_I2C1_OAR1 $0000 
        \ %x  15 lshift I2C1_OAR1        \ I2C1_ADDMODE	Bit Offset:15	Bit Width:1
        \ %xx  8 lshift I2C1_OAR1        \ I2C1_ADD10	Bit Offset:8	Bit Width:2
        \ %xxxxxxx  1 lshift I2C1_OAR1        \ I2C1_ADD7	Bit Offset:1	Bit Width:7
        \ %x  0 lshift I2C1_OAR1        \ I2C1_ADD0	Bit Offset:0	Bit Width:1
        
        I2C1 $C + constant I2C1_OAR2	\ read-write		\  : RESET_I2C1_OAR2 $0000 
        \ %xxxxxxx  1 lshift I2C1_OAR2        \ I2C1_ADD2	Bit Offset:1	Bit Width:7
        \ %x  0 lshift I2C1_OAR2        \ I2C1_ENDUAL	Bit Offset:0	Bit Width:1
        
        I2C1 $10 + constant I2C1_DR	\ read-write		\  : RESET_I2C1_DR $0000 
        \ %xxxxxxxx  0 lshift I2C1_DR        \ I2C1_DR	Bit Offset:0	Bit Width:8
        
        I2C1 $14 + constant I2C1_SR1	\ 		\  : RESET_I2C1_SR1 $0000 
        \ %x  15 lshift I2C1_SR1        \ I2C1_SMBALERT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift I2C1_SR1        \ I2C1_TIMEOUT	Bit Offset:14	Bit Width:1
        \ %x  12 lshift I2C1_SR1        \ I2C1_PECERR	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C1_SR1        \ I2C1_OVR	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C1_SR1        \ I2C1_AF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C1_SR1        \ I2C1_ARLO	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C1_SR1        \ I2C1_BERR	Bit Offset:8	Bit Width:1
        \ %x  7 lshift I2C1_SR1        \ I2C1_TxE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C1_SR1        \ I2C1_RxNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift I2C1_SR1        \ I2C1_STOPF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift I2C1_SR1        \ I2C1_ADD10	Bit Offset:3	Bit Width:1
        \ %x  2 lshift I2C1_SR1        \ I2C1_BTF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift I2C1_SR1        \ I2C1_ADDR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C1_SR1        \ I2C1_SB	Bit Offset:0	Bit Width:1
        
        I2C1 $18 + constant I2C1_SR2	\ read-only		\  : RESET_I2C1_SR2 $0000 
        \ %xxxxxxxx  8 lshift I2C1_SR2        \ I2C1_PEC	Bit Offset:8	Bit Width:8
        \ %x  7 lshift I2C1_SR2        \ I2C1_DUALF	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C1_SR2        \ I2C1_SMBHOST	Bit Offset:6	Bit Width:1
        \ %x  5 lshift I2C1_SR2        \ I2C1_SMBDEFAULT	Bit Offset:5	Bit Width:1
        \ %x  4 lshift I2C1_SR2        \ I2C1_GENCALL	Bit Offset:4	Bit Width:1
        \ %x  2 lshift I2C1_SR2        \ I2C1_TRA	Bit Offset:2	Bit Width:1
        \ %x  1 lshift I2C1_SR2        \ I2C1_BUSY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C1_SR2        \ I2C1_MSL	Bit Offset:0	Bit Width:1
        
        I2C1 $1C + constant I2C1_CCR	\ read-write		\  : RESET_I2C1_CCR $0000 
        \ %x  15 lshift I2C1_CCR        \ I2C1_F_S	Bit Offset:15	Bit Width:1
        \ %x  14 lshift I2C1_CCR        \ I2C1_DUTY	Bit Offset:14	Bit Width:1
        \ %xxxxxxxxxxxx  0 lshift I2C1_CCR        \ I2C1_CCR	Bit Offset:0	Bit Width:12
        
        I2C1 $20 + constant I2C1_TRISE	\ read-write		\  : RESET_I2C1_TRISE $0002 
        \ %xxxxxx  0 lshift I2C1_TRISE        \ I2C1_TRISE	Bit Offset:0	Bit Width:6
        
         
	
     $40005800 constant I2C2  
	  
	
     $40013000 constant SPI1  
	 SPI1 $0 + constant SPI1_CR1	\ read-write		\  : RESET_SPI1_CR1 $0000 
        \ %x  15 lshift SPI1_CR1        \ SPI1_BIDIMODE	Bit Offset:15	Bit Width:1
        \ %x  14 lshift SPI1_CR1        \ SPI1_BIDIOE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SPI1_CR1        \ SPI1_CRCEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SPI1_CR1        \ SPI1_CRCNEXT	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SPI1_CR1        \ SPI1_DFF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SPI1_CR1        \ SPI1_RXONLY	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SPI1_CR1        \ SPI1_SSM	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SPI1_CR1        \ SPI1_SSI	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SPI1_CR1        \ SPI1_LSBFIRST	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SPI1_CR1        \ SPI1_SPE	Bit Offset:6	Bit Width:1
        \ %xxx  3 lshift SPI1_CR1        \ SPI1_BR	Bit Offset:3	Bit Width:3
        \ %x  2 lshift SPI1_CR1        \ SPI1_MSTR	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SPI1_CR1        \ SPI1_CPOL	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SPI1_CR1        \ SPI1_CPHA	Bit Offset:0	Bit Width:1
        
        SPI1 $4 + constant SPI1_CR2	\ read-write		\  : RESET_SPI1_CR2 $0000 
        \ %x  7 lshift SPI1_CR2        \ SPI1_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SPI1_CR2        \ SPI1_RXNEIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SPI1_CR2        \ SPI1_ERRIE	Bit Offset:5	Bit Width:1
        \ %x  2 lshift SPI1_CR2        \ SPI1_SSOE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SPI1_CR2        \ SPI1_TXDMAEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SPI1_CR2        \ SPI1_RXDMAEN	Bit Offset:0	Bit Width:1
        
        SPI1 $8 + constant SPI1_SR	\ 		\  : RESET_SPI1_SR $0002 
        \ %x  7 lshift SPI1_SR        \ SPI1_BSY	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SPI1_SR        \ SPI1_OVR	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SPI1_SR        \ SPI1_MODF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SPI1_SR        \ SPI1_CRCERR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SPI1_SR        \ SPI1_UDR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SPI1_SR        \ SPI1_CHSIDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SPI1_SR        \ SPI1_TXE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SPI1_SR        \ SPI1_RXNE	Bit Offset:0	Bit Width:1
        
        SPI1 $C + constant SPI1_DR	\ read-write		\  : RESET_SPI1_DR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift SPI1_DR        \ SPI1_DR	Bit Offset:0	Bit Width:16
        
        SPI1 $10 + constant SPI1_CRCPR	\ read-write		\  : RESET_SPI1_CRCPR $0007 
        \ %xxxxxxxxxxxxxxxx  0 lshift SPI1_CRCPR        \ SPI1_CRCPOLY	Bit Offset:0	Bit Width:16
        
        SPI1 $14 + constant SPI1_RXCRCR	\ read-only		\  : RESET_SPI1_RXCRCR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift SPI1_RXCRCR        \ SPI1_RxCRC	Bit Offset:0	Bit Width:16
        
        SPI1 $18 + constant SPI1_TXCRCR	\ read-only		\  : RESET_SPI1_TXCRCR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift SPI1_TXCRCR        \ SPI1_TxCRC	Bit Offset:0	Bit Width:16
        
        SPI1 $1C + constant SPI1_I2SCFGR	\ read-write		\  : RESET_SPI1_I2SCFGR $0000 
        \ %x  11 lshift SPI1_I2SCFGR        \ SPI1_I2SMOD	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SPI1_I2SCFGR        \ SPI1_I2SE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift SPI1_I2SCFGR        \ SPI1_I2SCFG	Bit Offset:8	Bit Width:2
        \ %x  7 lshift SPI1_I2SCFGR        \ SPI1_PCMSYNC	Bit Offset:7	Bit Width:1
        \ %xx  4 lshift SPI1_I2SCFGR        \ SPI1_I2SSTD	Bit Offset:4	Bit Width:2
        \ %x  3 lshift SPI1_I2SCFGR        \ SPI1_CKPOL	Bit Offset:3	Bit Width:1
        \ %xx  1 lshift SPI1_I2SCFGR        \ SPI1_DATLEN	Bit Offset:1	Bit Width:2
        \ %x  0 lshift SPI1_I2SCFGR        \ SPI1_CHLEN	Bit Offset:0	Bit Width:1
        
        SPI1 $20 + constant SPI1_I2SPR	\ read-write		\  : RESET_SPI1_I2SPR 00000010 
        \ %x  9 lshift SPI1_I2SPR        \ SPI1_MCKOE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SPI1_I2SPR        \ SPI1_ODD	Bit Offset:8	Bit Width:1
        \ %xxxxxxxx  0 lshift SPI1_I2SPR        \ SPI1_I2SDIV	Bit Offset:0	Bit Width:8
        
         
	
     $40003800 constant SPI2  
	  
	
     $40003C00 constant SPI3  
	  
	
     $40013800 constant USART1  
	 USART1 $0 + constant USART1_SR	\ 		\  : RESET_USART1_SR $00C0 
        \ %x  9 lshift USART1_SR        \ USART1_CTS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_SR        \ USART1_LBD	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART1_SR        \ USART1_TXE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART1_SR        \ USART1_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_SR        \ USART1_RXNE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART1_SR        \ USART1_IDLE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_SR        \ USART1_ORE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_SR        \ USART1_NE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_SR        \ USART1_FE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_SR        \ USART1_PE	Bit Offset:0	Bit Width:1
        
        USART1 $4 + constant USART1_DR	\ read-write		\  : RESET_USART1_DR $00000000 
        \ %xxxxxxxxx  0 lshift USART1_DR        \ USART1_DR	Bit Offset:0	Bit Width:9
        
        USART1 $8 + constant USART1_BRR	\ read-write		\  : RESET_USART1_BRR $0000 
        \ %xxxxxxxxxxxx  4 lshift USART1_BRR        \ USART1_DIV_Mantissa	Bit Offset:4	Bit Width:12
        \ %xxxx  0 lshift USART1_BRR        \ USART1_DIV_Fraction	Bit Offset:0	Bit Width:4
        
        USART1 $C + constant USART1_CR1	\ read-write		\  : RESET_USART1_CR1 $0000 
        \ %x  13 lshift USART1_CR1        \ USART1_UE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift USART1_CR1        \ USART1_M	Bit Offset:12	Bit Width:1
        \ %x  11 lshift USART1_CR1        \ USART1_WAKE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART1_CR1        \ USART1_PCE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART1_CR1        \ USART1_PS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_CR1        \ USART1_PEIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART1_CR1        \ USART1_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART1_CR1        \ USART1_TCIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_CR1        \ USART1_RXNEIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART1_CR1        \ USART1_IDLEIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_CR1        \ USART1_TE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_CR1        \ USART1_RE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_CR1        \ USART1_RWU	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_CR1        \ USART1_SBK	Bit Offset:0	Bit Width:1
        
        USART1 $10 + constant USART1_CR2	\ read-write		\  : RESET_USART1_CR2 $0000 
        \ %x  14 lshift USART1_CR2        \ USART1_LINEN	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USART1_CR2        \ USART1_STOP	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USART1_CR2        \ USART1_CLKEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART1_CR2        \ USART1_CPOL	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART1_CR2        \ USART1_CPHA	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_CR2        \ USART1_LBCL	Bit Offset:8	Bit Width:1
        \ %x  6 lshift USART1_CR2        \ USART1_LBDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_CR2        \ USART1_LBDL	Bit Offset:5	Bit Width:1
        \ %xxxx  0 lshift USART1_CR2        \ USART1_ADD	Bit Offset:0	Bit Width:4
        
        USART1 $14 + constant USART1_CR3	\ read-write		\  : RESET_USART1_CR3 $0000 
        \ %x  10 lshift USART1_CR3        \ USART1_CTSIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART1_CR3        \ USART1_CTSE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_CR3        \ USART1_RTSE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART1_CR3        \ USART1_DMAT	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART1_CR3        \ USART1_DMAR	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_CR3        \ USART1_SCEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART1_CR3        \ USART1_NACK	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_CR3        \ USART1_HDSEL	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_CR3        \ USART1_IRLP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_CR3        \ USART1_IREN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_CR3        \ USART1_EIE	Bit Offset:0	Bit Width:1
        
        USART1 $18 + constant USART1_GTPR	\ read-write		\  : RESET_USART1_GTPR $0000 
        \ %xxxxxxxx  8 lshift USART1_GTPR        \ USART1_GT	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift USART1_GTPR        \ USART1_PSC	Bit Offset:0	Bit Width:8
        
         
	
     $40004400 constant USART2  
	  
	
     $40004800 constant USART3  
	  
	
     $40012400 constant ADC1  
	 ADC1 $0 + constant ADC1_SR	\ read-write		\  : RESET_ADC1_SR $00000000 
        \ %x  4 lshift ADC1_SR        \ ADC1_STRT	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC1_SR        \ ADC1_JSTRT	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC1_SR        \ ADC1_JEOC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC1_SR        \ ADC1_EOC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC1_SR        \ ADC1_AWD	Bit Offset:0	Bit Width:1
        
        ADC1 $4 + constant ADC1_CR1	\ read-write		\  : RESET_ADC1_CR1 $00000000 
        \ %x  23 lshift ADC1_CR1        \ ADC1_AWDEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift ADC1_CR1        \ ADC1_JAWDEN	Bit Offset:22	Bit Width:1
        \ %xxxx  16 lshift ADC1_CR1        \ ADC1_DUALMOD	Bit Offset:16	Bit Width:4
        \ %xxx  13 lshift ADC1_CR1        \ ADC1_DISCNUM	Bit Offset:13	Bit Width:3
        \ %x  12 lshift ADC1_CR1        \ ADC1_JDISCEN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift ADC1_CR1        \ ADC1_DISCEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift ADC1_CR1        \ ADC1_JAUTO	Bit Offset:10	Bit Width:1
        \ %x  9 lshift ADC1_CR1        \ ADC1_AWDSGL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC1_CR1        \ ADC1_SCAN	Bit Offset:8	Bit Width:1
        \ %x  7 lshift ADC1_CR1        \ ADC1_JEOCIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift ADC1_CR1        \ ADC1_AWDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift ADC1_CR1        \ ADC1_EOCIE	Bit Offset:5	Bit Width:1
        \ %xxxxx  0 lshift ADC1_CR1        \ ADC1_AWDCH	Bit Offset:0	Bit Width:5
        
        ADC1 $8 + constant ADC1_CR2	\ read-write		\  : RESET_ADC1_CR2 $00000000 
        \ %x  23 lshift ADC1_CR2        \ ADC1_TSVREFE	Bit Offset:23	Bit Width:1
        \ %x  22 lshift ADC1_CR2        \ ADC1_SWSTART	Bit Offset:22	Bit Width:1
        \ %x  21 lshift ADC1_CR2        \ ADC1_JSWSTART	Bit Offset:21	Bit Width:1
        \ %x  20 lshift ADC1_CR2        \ ADC1_EXTTRIG	Bit Offset:20	Bit Width:1
        \ %xxx  17 lshift ADC1_CR2        \ ADC1_EXTSEL	Bit Offset:17	Bit Width:3
        \ %x  15 lshift ADC1_CR2        \ ADC1_JEXTTRIG	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift ADC1_CR2        \ ADC1_JEXTSEL	Bit Offset:12	Bit Width:3
        \ %x  11 lshift ADC1_CR2        \ ADC1_ALIGN	Bit Offset:11	Bit Width:1
        \ %x  8 lshift ADC1_CR2        \ ADC1_DMA	Bit Offset:8	Bit Width:1
        \ %x  3 lshift ADC1_CR2        \ ADC1_RSTCAL	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC1_CR2        \ ADC1_CAL	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC1_CR2        \ ADC1_CONT	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC1_CR2        \ ADC1_ADON	Bit Offset:0	Bit Width:1
        
        ADC1 $C + constant ADC1_SMPR1	\ read-write		\  : RESET_ADC1_SMPR1 $00000000 
        \ %xxx  0 lshift ADC1_SMPR1        \ ADC1_SMP10	Bit Offset:0	Bit Width:3
        \ %xxx  3 lshift ADC1_SMPR1        \ ADC1_SMP11	Bit Offset:3	Bit Width:3
        \ %xxx  6 lshift ADC1_SMPR1        \ ADC1_SMP12	Bit Offset:6	Bit Width:3
        \ %xxx  9 lshift ADC1_SMPR1        \ ADC1_SMP13	Bit Offset:9	Bit Width:3
        \ %xxx  12 lshift ADC1_SMPR1        \ ADC1_SMP14	Bit Offset:12	Bit Width:3
        \ %xxx  15 lshift ADC1_SMPR1        \ ADC1_SMP15	Bit Offset:15	Bit Width:3
        \ %xxx  18 lshift ADC1_SMPR1        \ ADC1_SMP16	Bit Offset:18	Bit Width:3
        \ %xxx  21 lshift ADC1_SMPR1        \ ADC1_SMP17	Bit Offset:21	Bit Width:3
        
        ADC1 $10 + constant ADC1_SMPR2	\ read-write		\  : RESET_ADC1_SMPR2 $00000000 
        \ %xxx  0 lshift ADC1_SMPR2        \ ADC1_SMP0	Bit Offset:0	Bit Width:3
        \ %xxx  3 lshift ADC1_SMPR2        \ ADC1_SMP1	Bit Offset:3	Bit Width:3
        \ %xxx  6 lshift ADC1_SMPR2        \ ADC1_SMP2	Bit Offset:6	Bit Width:3
        \ %xxx  9 lshift ADC1_SMPR2        \ ADC1_SMP3	Bit Offset:9	Bit Width:3
        \ %xxx  12 lshift ADC1_SMPR2        \ ADC1_SMP4	Bit Offset:12	Bit Width:3
        \ %xxx  15 lshift ADC1_SMPR2        \ ADC1_SMP5	Bit Offset:15	Bit Width:3
        \ %xxx  18 lshift ADC1_SMPR2        \ ADC1_SMP6	Bit Offset:18	Bit Width:3
        \ %xxx  21 lshift ADC1_SMPR2        \ ADC1_SMP7	Bit Offset:21	Bit Width:3
        \ %xxx  24 lshift ADC1_SMPR2        \ ADC1_SMP8	Bit Offset:24	Bit Width:3
        \ %xxx  27 lshift ADC1_SMPR2        \ ADC1_SMP9	Bit Offset:27	Bit Width:3
        
        ADC1 $14 + constant ADC1_JOFR1	\ read-write		\  : RESET_ADC1_JOFR1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC1_JOFR1        \ ADC1_JOFFSET1	Bit Offset:0	Bit Width:12
        
        ADC1 $18 + constant ADC1_JOFR2	\ read-write		\  : RESET_ADC1_JOFR2 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC1_JOFR2        \ ADC1_JOFFSET2	Bit Offset:0	Bit Width:12
        
        ADC1 $1C + constant ADC1_JOFR3	\ read-write		\  : RESET_ADC1_JOFR3 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC1_JOFR3        \ ADC1_JOFFSET3	Bit Offset:0	Bit Width:12
        
        ADC1 $20 + constant ADC1_JOFR4	\ read-write		\  : RESET_ADC1_JOFR4 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC1_JOFR4        \ ADC1_JOFFSET4	Bit Offset:0	Bit Width:12
        
        ADC1 $24 + constant ADC1_HTR	\ read-write		\  : RESET_ADC1_HTR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift ADC1_HTR        \ ADC1_HT	Bit Offset:0	Bit Width:12
        
        ADC1 $28 + constant ADC1_LTR	\ read-write		\  : RESET_ADC1_LTR $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC1_LTR        \ ADC1_LT	Bit Offset:0	Bit Width:12
        
        ADC1 $2C + constant ADC1_SQR1	\ read-write		\  : RESET_ADC1_SQR1 $00000000 
        \ %xxxx  20 lshift ADC1_SQR1        \ ADC1_L	Bit Offset:20	Bit Width:4
        \ %xxxxx  15 lshift ADC1_SQR1        \ ADC1_SQ16	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC1_SQR1        \ ADC1_SQ15	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC1_SQR1        \ ADC1_SQ14	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC1_SQR1        \ ADC1_SQ13	Bit Offset:0	Bit Width:5
        
        ADC1 $30 + constant ADC1_SQR2	\ read-write		\  : RESET_ADC1_SQR2 $00000000 
        \ %xxxxx  25 lshift ADC1_SQR2        \ ADC1_SQ12	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC1_SQR2        \ ADC1_SQ11	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC1_SQR2        \ ADC1_SQ10	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC1_SQR2        \ ADC1_SQ9	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC1_SQR2        \ ADC1_SQ8	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC1_SQR2        \ ADC1_SQ7	Bit Offset:0	Bit Width:5
        
        ADC1 $34 + constant ADC1_SQR3	\ read-write		\  : RESET_ADC1_SQR3 $00000000 
        \ %xxxxx  25 lshift ADC1_SQR3        \ ADC1_SQ6	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC1_SQR3        \ ADC1_SQ5	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC1_SQR3        \ ADC1_SQ4	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC1_SQR3        \ ADC1_SQ3	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC1_SQR3        \ ADC1_SQ2	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC1_SQR3        \ ADC1_SQ1	Bit Offset:0	Bit Width:5
        
        ADC1 $38 + constant ADC1_JSQR	\ read-write		\  : RESET_ADC1_JSQR $00000000 
        \ %xx  20 lshift ADC1_JSQR        \ ADC1_JL	Bit Offset:20	Bit Width:2
        \ %xxxxx  15 lshift ADC1_JSQR        \ ADC1_JSQ4	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC1_JSQR        \ ADC1_JSQ3	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC1_JSQR        \ ADC1_JSQ2	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC1_JSQR        \ ADC1_JSQ1	Bit Offset:0	Bit Width:5
        
        ADC1 $3C + constant ADC1_JDR1	\ read-only		\  : RESET_ADC1_JDR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC1_JDR1        \ ADC1_JDATA	Bit Offset:0	Bit Width:16
        
        ADC1 $40 + constant ADC1_JDR2	\ read-only		\  : RESET_ADC1_JDR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC1_JDR2        \ ADC1_JDATA	Bit Offset:0	Bit Width:16
        
        ADC1 $44 + constant ADC1_JDR3	\ read-only		\  : RESET_ADC1_JDR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC1_JDR3        \ ADC1_JDATA	Bit Offset:0	Bit Width:16
        
        ADC1 $48 + constant ADC1_JDR4	\ read-only		\  : RESET_ADC1_JDR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC1_JDR4        \ ADC1_JDATA	Bit Offset:0	Bit Width:16
        
        ADC1 $4C + constant ADC1_DR	\ read-only		\  : RESET_ADC1_DR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC1_DR        \ ADC1_DATA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift ADC1_DR        \ ADC1_ADC2DATA	Bit Offset:16	Bit Width:16
        
         
	
     $40012800 constant ADC2  
	 ADC2 $0 + constant ADC2_SR	\ read-write		\  : RESET_ADC2_SR $00000000 
        \ %x  4 lshift ADC2_SR        \ ADC2_STRT	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC2_SR        \ ADC2_JSTRT	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC2_SR        \ ADC2_JEOC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC2_SR        \ ADC2_EOC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC2_SR        \ ADC2_AWD	Bit Offset:0	Bit Width:1
        
        ADC2 $4 + constant ADC2_CR1	\ read-write		\  : RESET_ADC2_CR1 $00000000 
        \ %x  23 lshift ADC2_CR1        \ ADC2_AWDEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift ADC2_CR1        \ ADC2_JAWDEN	Bit Offset:22	Bit Width:1
        \ %xxx  13 lshift ADC2_CR1        \ ADC2_DISCNUM	Bit Offset:13	Bit Width:3
        \ %x  12 lshift ADC2_CR1        \ ADC2_JDISCEN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift ADC2_CR1        \ ADC2_DISCEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift ADC2_CR1        \ ADC2_JAUTO	Bit Offset:10	Bit Width:1
        \ %x  9 lshift ADC2_CR1        \ ADC2_AWDSGL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC2_CR1        \ ADC2_SCAN	Bit Offset:8	Bit Width:1
        \ %x  7 lshift ADC2_CR1        \ ADC2_JEOCIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift ADC2_CR1        \ ADC2_AWDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift ADC2_CR1        \ ADC2_EOCIE	Bit Offset:5	Bit Width:1
        \ %xxxxx  0 lshift ADC2_CR1        \ ADC2_AWDCH	Bit Offset:0	Bit Width:5
        
        ADC2 $8 + constant ADC2_CR2	\ read-write		\  : RESET_ADC2_CR2 $00000000 
        \ %x  23 lshift ADC2_CR2        \ ADC2_TSVREFE	Bit Offset:23	Bit Width:1
        \ %x  22 lshift ADC2_CR2        \ ADC2_SWSTART	Bit Offset:22	Bit Width:1
        \ %x  21 lshift ADC2_CR2        \ ADC2_JSWSTART	Bit Offset:21	Bit Width:1
        \ %x  20 lshift ADC2_CR2        \ ADC2_EXTTRIG	Bit Offset:20	Bit Width:1
        \ %xxx  17 lshift ADC2_CR2        \ ADC2_EXTSEL	Bit Offset:17	Bit Width:3
        \ %x  15 lshift ADC2_CR2        \ ADC2_JEXTTRIG	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift ADC2_CR2        \ ADC2_JEXTSEL	Bit Offset:12	Bit Width:3
        \ %x  11 lshift ADC2_CR2        \ ADC2_ALIGN	Bit Offset:11	Bit Width:1
        \ %x  8 lshift ADC2_CR2        \ ADC2_DMA	Bit Offset:8	Bit Width:1
        \ %x  3 lshift ADC2_CR2        \ ADC2_RSTCAL	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC2_CR2        \ ADC2_CAL	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC2_CR2        \ ADC2_CONT	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC2_CR2        \ ADC2_ADON	Bit Offset:0	Bit Width:1
        
        ADC2 $C + constant ADC2_SMPR1	\ read-write		\  : RESET_ADC2_SMPR1 $00000000 
        \ %xxx  0 lshift ADC2_SMPR1        \ ADC2_SMP10	Bit Offset:0	Bit Width:3
        \ %xxx  3 lshift ADC2_SMPR1        \ ADC2_SMP11	Bit Offset:3	Bit Width:3
        \ %xxx  6 lshift ADC2_SMPR1        \ ADC2_SMP12	Bit Offset:6	Bit Width:3
        \ %xxx  9 lshift ADC2_SMPR1        \ ADC2_SMP13	Bit Offset:9	Bit Width:3
        \ %xxx  12 lshift ADC2_SMPR1        \ ADC2_SMP14	Bit Offset:12	Bit Width:3
        \ %xxx  15 lshift ADC2_SMPR1        \ ADC2_SMP15	Bit Offset:15	Bit Width:3
        \ %xxx  18 lshift ADC2_SMPR1        \ ADC2_SMP16	Bit Offset:18	Bit Width:3
        \ %xxx  21 lshift ADC2_SMPR1        \ ADC2_SMP17	Bit Offset:21	Bit Width:3
        
        ADC2 $10 + constant ADC2_SMPR2	\ read-write		\  : RESET_ADC2_SMPR2 $00000000 
        \ %xxx  0 lshift ADC2_SMPR2        \ ADC2_SMP0	Bit Offset:0	Bit Width:3
        \ %xxx  3 lshift ADC2_SMPR2        \ ADC2_SMP1	Bit Offset:3	Bit Width:3
        \ %xxx  6 lshift ADC2_SMPR2        \ ADC2_SMP2	Bit Offset:6	Bit Width:3
        \ %xxx  9 lshift ADC2_SMPR2        \ ADC2_SMP3	Bit Offset:9	Bit Width:3
        \ %xxx  12 lshift ADC2_SMPR2        \ ADC2_SMP4	Bit Offset:12	Bit Width:3
        \ %xxx  15 lshift ADC2_SMPR2        \ ADC2_SMP5	Bit Offset:15	Bit Width:3
        \ %xxx  18 lshift ADC2_SMPR2        \ ADC2_SMP6	Bit Offset:18	Bit Width:3
        \ %xxx  21 lshift ADC2_SMPR2        \ ADC2_SMP7	Bit Offset:21	Bit Width:3
        \ %xxx  24 lshift ADC2_SMPR2        \ ADC2_SMP8	Bit Offset:24	Bit Width:3
        \ %xxx  27 lshift ADC2_SMPR2        \ ADC2_SMP9	Bit Offset:27	Bit Width:3
        
        ADC2 $14 + constant ADC2_JOFR1	\ read-write		\  : RESET_ADC2_JOFR1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC2_JOFR1        \ ADC2_JOFFSET1	Bit Offset:0	Bit Width:12
        
        ADC2 $18 + constant ADC2_JOFR2	\ read-write		\  : RESET_ADC2_JOFR2 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC2_JOFR2        \ ADC2_JOFFSET2	Bit Offset:0	Bit Width:12
        
        ADC2 $1C + constant ADC2_JOFR3	\ read-write		\  : RESET_ADC2_JOFR3 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC2_JOFR3        \ ADC2_JOFFSET3	Bit Offset:0	Bit Width:12
        
        ADC2 $20 + constant ADC2_JOFR4	\ read-write		\  : RESET_ADC2_JOFR4 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC2_JOFR4        \ ADC2_JOFFSET4	Bit Offset:0	Bit Width:12
        
        ADC2 $24 + constant ADC2_HTR	\ read-write		\  : RESET_ADC2_HTR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift ADC2_HTR        \ ADC2_HT	Bit Offset:0	Bit Width:12
        
        ADC2 $28 + constant ADC2_LTR	\ read-write		\  : RESET_ADC2_LTR $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC2_LTR        \ ADC2_LT	Bit Offset:0	Bit Width:12
        
        ADC2 $2C + constant ADC2_SQR1	\ read-write		\  : RESET_ADC2_SQR1 $00000000 
        \ %xxxx  20 lshift ADC2_SQR1        \ ADC2_L	Bit Offset:20	Bit Width:4
        \ %xxxxx  15 lshift ADC2_SQR1        \ ADC2_SQ16	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC2_SQR1        \ ADC2_SQ15	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC2_SQR1        \ ADC2_SQ14	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC2_SQR1        \ ADC2_SQ13	Bit Offset:0	Bit Width:5
        
        ADC2 $30 + constant ADC2_SQR2	\ read-write		\  : RESET_ADC2_SQR2 $00000000 
        \ %xxxxx  25 lshift ADC2_SQR2        \ ADC2_SQ12	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC2_SQR2        \ ADC2_SQ11	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC2_SQR2        \ ADC2_SQ10	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC2_SQR2        \ ADC2_SQ9	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC2_SQR2        \ ADC2_SQ8	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC2_SQR2        \ ADC2_SQ7	Bit Offset:0	Bit Width:5
        
        ADC2 $34 + constant ADC2_SQR3	\ read-write		\  : RESET_ADC2_SQR3 $00000000 
        \ %xxxxx  25 lshift ADC2_SQR3        \ ADC2_SQ6	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC2_SQR3        \ ADC2_SQ5	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC2_SQR3        \ ADC2_SQ4	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC2_SQR3        \ ADC2_SQ3	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC2_SQR3        \ ADC2_SQ2	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC2_SQR3        \ ADC2_SQ1	Bit Offset:0	Bit Width:5
        
        ADC2 $38 + constant ADC2_JSQR	\ read-write		\  : RESET_ADC2_JSQR $00000000 
        \ %xx  20 lshift ADC2_JSQR        \ ADC2_JL	Bit Offset:20	Bit Width:2
        \ %xxxxx  15 lshift ADC2_JSQR        \ ADC2_JSQ4	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC2_JSQR        \ ADC2_JSQ3	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC2_JSQR        \ ADC2_JSQ2	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC2_JSQR        \ ADC2_JSQ1	Bit Offset:0	Bit Width:5
        
        ADC2 $3C + constant ADC2_JDR1	\ read-only		\  : RESET_ADC2_JDR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC2_JDR1        \ ADC2_JDATA	Bit Offset:0	Bit Width:16
        
        ADC2 $40 + constant ADC2_JDR2	\ read-only		\  : RESET_ADC2_JDR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC2_JDR2        \ ADC2_JDATA	Bit Offset:0	Bit Width:16
        
        ADC2 $44 + constant ADC2_JDR3	\ read-only		\  : RESET_ADC2_JDR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC2_JDR3        \ ADC2_JDATA	Bit Offset:0	Bit Width:16
        
        ADC2 $48 + constant ADC2_JDR4	\ read-only		\  : RESET_ADC2_JDR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC2_JDR4        \ ADC2_JDATA	Bit Offset:0	Bit Width:16
        
        ADC2 $4C + constant ADC2_DR	\ read-only		\  : RESET_ADC2_DR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC2_DR        \ ADC2_DATA	Bit Offset:0	Bit Width:16
        
         
	
     $40006800 constant CAN2  
	 CAN2 $0 + constant CAN2_CAN_MCR	\ read-write		\  : RESET_CAN2_CAN_MCR $00000000 
        \ %x  16 lshift CAN2_CAN_MCR        \ CAN2_DBF	Bit Offset:16	Bit Width:1
        \ %x  15 lshift CAN2_CAN_MCR        \ CAN2_RESET	Bit Offset:15	Bit Width:1
        \ %x  7 lshift CAN2_CAN_MCR        \ CAN2_TTCM	Bit Offset:7	Bit Width:1
        \ %x  6 lshift CAN2_CAN_MCR        \ CAN2_ABOM	Bit Offset:6	Bit Width:1
        \ %x  5 lshift CAN2_CAN_MCR        \ CAN2_AWUM	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN2_CAN_MCR        \ CAN2_NART	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN2_CAN_MCR        \ CAN2_RFLM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN2_CAN_MCR        \ CAN2_TXFP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_MCR        \ CAN2_SLEEP	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_MCR        \ CAN2_INRQ	Bit Offset:0	Bit Width:1
        
        CAN2 $4 + constant CAN2_CAN_MSR	\ 		\  : RESET_CAN2_CAN_MSR $00000000 
        \ %x  11 lshift CAN2_CAN_MSR        \ CAN2_RX	Bit Offset:11	Bit Width:1
        \ %x  10 lshift CAN2_CAN_MSR        \ CAN2_SAMP	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CAN2_CAN_MSR        \ CAN2_RXM	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CAN2_CAN_MSR        \ CAN2_TXM	Bit Offset:8	Bit Width:1
        \ %x  4 lshift CAN2_CAN_MSR        \ CAN2_SLAKI	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN2_CAN_MSR        \ CAN2_WKUI	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN2_CAN_MSR        \ CAN2_ERRI	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_MSR        \ CAN2_SLAK	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_MSR        \ CAN2_INAK	Bit Offset:0	Bit Width:1
        
        CAN2 $8 + constant CAN2_CAN_TSR	\ 		\  : RESET_CAN2_CAN_TSR $00000000 
        \ %x  31 lshift CAN2_CAN_TSR        \ CAN2_LOW2	Bit Offset:31	Bit Width:1
        \ %x  30 lshift CAN2_CAN_TSR        \ CAN2_LOW1	Bit Offset:30	Bit Width:1
        \ %x  29 lshift CAN2_CAN_TSR        \ CAN2_LOW0	Bit Offset:29	Bit Width:1
        \ %x  28 lshift CAN2_CAN_TSR        \ CAN2_TME2	Bit Offset:28	Bit Width:1
        \ %x  27 lshift CAN2_CAN_TSR        \ CAN2_TME1	Bit Offset:27	Bit Width:1
        \ %x  26 lshift CAN2_CAN_TSR        \ CAN2_TME0	Bit Offset:26	Bit Width:1
        \ %xx  24 lshift CAN2_CAN_TSR        \ CAN2_CODE	Bit Offset:24	Bit Width:2
        \ %x  23 lshift CAN2_CAN_TSR        \ CAN2_ABRQ2	Bit Offset:23	Bit Width:1
        \ %x  19 lshift CAN2_CAN_TSR        \ CAN2_TERR2	Bit Offset:19	Bit Width:1
        \ %x  18 lshift CAN2_CAN_TSR        \ CAN2_ALST2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift CAN2_CAN_TSR        \ CAN2_TXOK2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift CAN2_CAN_TSR        \ CAN2_RQCP2	Bit Offset:16	Bit Width:1
        \ %x  15 lshift CAN2_CAN_TSR        \ CAN2_ABRQ1	Bit Offset:15	Bit Width:1
        \ %x  11 lshift CAN2_CAN_TSR        \ CAN2_TERR1	Bit Offset:11	Bit Width:1
        \ %x  10 lshift CAN2_CAN_TSR        \ CAN2_ALST1	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CAN2_CAN_TSR        \ CAN2_TXOK1	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CAN2_CAN_TSR        \ CAN2_RQCP1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift CAN2_CAN_TSR        \ CAN2_ABRQ0	Bit Offset:7	Bit Width:1
        \ %x  3 lshift CAN2_CAN_TSR        \ CAN2_TERR0	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN2_CAN_TSR        \ CAN2_ALST0	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_TSR        \ CAN2_TXOK0	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_TSR        \ CAN2_RQCP0	Bit Offset:0	Bit Width:1
        
        CAN2 $C + constant CAN2_CAN_RF0R	\ 		\  : RESET_CAN2_CAN_RF0R $00000000 
        \ %x  5 lshift CAN2_CAN_RF0R        \ CAN2_RFOM0	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN2_CAN_RF0R        \ CAN2_FOVR0	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN2_CAN_RF0R        \ CAN2_FULL0	Bit Offset:3	Bit Width:1
        \ %xx  0 lshift CAN2_CAN_RF0R        \ CAN2_FMP0	Bit Offset:0	Bit Width:2
        
        CAN2 $10 + constant CAN2_CAN_RF1R	\ 		\  : RESET_CAN2_CAN_RF1R $00000000 
        \ %x  5 lshift CAN2_CAN_RF1R        \ CAN2_RFOM1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN2_CAN_RF1R        \ CAN2_FOVR1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN2_CAN_RF1R        \ CAN2_FULL1	Bit Offset:3	Bit Width:1
        \ %xx  0 lshift CAN2_CAN_RF1R        \ CAN2_FMP1	Bit Offset:0	Bit Width:2
        
        CAN2 $14 + constant CAN2_CAN_IER	\ read-write		\  : RESET_CAN2_CAN_IER $00000000 
        \ %x  17 lshift CAN2_CAN_IER        \ CAN2_SLKIE	Bit Offset:17	Bit Width:1
        \ %x  16 lshift CAN2_CAN_IER        \ CAN2_WKUIE	Bit Offset:16	Bit Width:1
        \ %x  15 lshift CAN2_CAN_IER        \ CAN2_ERRIE	Bit Offset:15	Bit Width:1
        \ %x  11 lshift CAN2_CAN_IER        \ CAN2_LECIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift CAN2_CAN_IER        \ CAN2_BOFIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CAN2_CAN_IER        \ CAN2_EPVIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CAN2_CAN_IER        \ CAN2_EWGIE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift CAN2_CAN_IER        \ CAN2_FOVIE1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift CAN2_CAN_IER        \ CAN2_FFIE1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN2_CAN_IER        \ CAN2_FMPIE1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN2_CAN_IER        \ CAN2_FOVIE0	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN2_CAN_IER        \ CAN2_FFIE0	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_IER        \ CAN2_FMPIE0	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_IER        \ CAN2_TMEIE	Bit Offset:0	Bit Width:1
        
        CAN2 $18 + constant CAN2_CAN_ESR	\ 		\  : RESET_CAN2_CAN_ESR $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_ESR        \ CAN2_REC	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_ESR        \ CAN2_TEC	Bit Offset:16	Bit Width:8
        \ %xxx  4 lshift CAN2_CAN_ESR        \ CAN2_LEC	Bit Offset:4	Bit Width:3
        \ %x  2 lshift CAN2_CAN_ESR        \ CAN2_BOFF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_ESR        \ CAN2_EPVF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_ESR        \ CAN2_EWGF	Bit Offset:0	Bit Width:1
        
        CAN2 $1C + constant CAN2_CAN_BTR	\ read-write		\  : RESET_CAN2_CAN_BTR $00000000 
        \ %x  31 lshift CAN2_CAN_BTR        \ CAN2_SILM	Bit Offset:31	Bit Width:1
        \ %x  30 lshift CAN2_CAN_BTR        \ CAN2_LBKM	Bit Offset:30	Bit Width:1
        \ %xx  24 lshift CAN2_CAN_BTR        \ CAN2_SJW	Bit Offset:24	Bit Width:2
        \ %xxx  20 lshift CAN2_CAN_BTR        \ CAN2_TS2	Bit Offset:20	Bit Width:3
        \ %xxxx  16 lshift CAN2_CAN_BTR        \ CAN2_TS1	Bit Offset:16	Bit Width:4
        \ % 0 lshift CAN2_CAN_BTR        \ CAN2_BRP	Bit Offset:0	Bit Width:10
        
        CAN2 $180 + constant CAN2_CAN_TI0R	\ read-write		\  : RESET_CAN2_CAN_TI0R $00000000 
        \ % 21 lshift CAN2_CAN_TI0R        \ CAN2_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN2_CAN_TI0R        \ CAN2_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN2_CAN_TI0R        \ CAN2_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_TI0R        \ CAN2_RTR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_TI0R        \ CAN2_TXRQ	Bit Offset:0	Bit Width:1
        
        CAN2 $184 + constant CAN2_CAN_TDT0R	\ read-write		\  : RESET_CAN2_CAN_TDT0R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN2_CAN_TDT0R        \ CAN2_TIME	Bit Offset:16	Bit Width:16
        \ %x  8 lshift CAN2_CAN_TDT0R        \ CAN2_TGT	Bit Offset:8	Bit Width:1
        \ %xxxx  0 lshift CAN2_CAN_TDT0R        \ CAN2_DLC	Bit Offset:0	Bit Width:4
        
        CAN2 $188 + constant CAN2_CAN_TDL0R	\ read-write		\  : RESET_CAN2_CAN_TDL0R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_TDL0R        \ CAN2_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_TDL0R        \ CAN2_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_TDL0R        \ CAN2_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_TDL0R        \ CAN2_DATA0	Bit Offset:0	Bit Width:8
        
        CAN2 $18C + constant CAN2_CAN_TDH0R	\ read-write		\  : RESET_CAN2_CAN_TDH0R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_TDH0R        \ CAN2_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_TDH0R        \ CAN2_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_TDH0R        \ CAN2_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_TDH0R        \ CAN2_DATA4	Bit Offset:0	Bit Width:8
        
        CAN2 $190 + constant CAN2_CAN_TI1R	\ read-write		\  : RESET_CAN2_CAN_TI1R $00000000 
        \ % 21 lshift CAN2_CAN_TI1R        \ CAN2_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN2_CAN_TI1R        \ CAN2_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN2_CAN_TI1R        \ CAN2_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_TI1R        \ CAN2_RTR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_TI1R        \ CAN2_TXRQ	Bit Offset:0	Bit Width:1
        
        CAN2 $194 + constant CAN2_CAN_TDT1R	\ read-write		\  : RESET_CAN2_CAN_TDT1R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN2_CAN_TDT1R        \ CAN2_TIME	Bit Offset:16	Bit Width:16
        \ %x  8 lshift CAN2_CAN_TDT1R        \ CAN2_TGT	Bit Offset:8	Bit Width:1
        \ %xxxx  0 lshift CAN2_CAN_TDT1R        \ CAN2_DLC	Bit Offset:0	Bit Width:4
        
        CAN2 $198 + constant CAN2_CAN_TDL1R	\ read-write		\  : RESET_CAN2_CAN_TDL1R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_TDL1R        \ CAN2_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_TDL1R        \ CAN2_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_TDL1R        \ CAN2_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_TDL1R        \ CAN2_DATA0	Bit Offset:0	Bit Width:8
        
        CAN2 $19C + constant CAN2_CAN_TDH1R	\ read-write		\  : RESET_CAN2_CAN_TDH1R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_TDH1R        \ CAN2_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_TDH1R        \ CAN2_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_TDH1R        \ CAN2_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_TDH1R        \ CAN2_DATA4	Bit Offset:0	Bit Width:8
        
        CAN2 $1A0 + constant CAN2_CAN_TI2R	\ read-write		\  : RESET_CAN2_CAN_TI2R $00000000 
        \ % 21 lshift CAN2_CAN_TI2R        \ CAN2_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN2_CAN_TI2R        \ CAN2_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN2_CAN_TI2R        \ CAN2_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_TI2R        \ CAN2_RTR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN2_CAN_TI2R        \ CAN2_TXRQ	Bit Offset:0	Bit Width:1
        
        CAN2 $1A4 + constant CAN2_CAN_TDT2R	\ read-write		\  : RESET_CAN2_CAN_TDT2R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN2_CAN_TDT2R        \ CAN2_TIME	Bit Offset:16	Bit Width:16
        \ %x  8 lshift CAN2_CAN_TDT2R        \ CAN2_TGT	Bit Offset:8	Bit Width:1
        \ %xxxx  0 lshift CAN2_CAN_TDT2R        \ CAN2_DLC	Bit Offset:0	Bit Width:4
        
        CAN2 $1A8 + constant CAN2_CAN_TDL2R	\ read-write		\  : RESET_CAN2_CAN_TDL2R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_TDL2R        \ CAN2_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_TDL2R        \ CAN2_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_TDL2R        \ CAN2_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_TDL2R        \ CAN2_DATA0	Bit Offset:0	Bit Width:8
        
        CAN2 $1AC + constant CAN2_CAN_TDH2R	\ read-write		\  : RESET_CAN2_CAN_TDH2R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_TDH2R        \ CAN2_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_TDH2R        \ CAN2_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_TDH2R        \ CAN2_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_TDH2R        \ CAN2_DATA4	Bit Offset:0	Bit Width:8
        
        CAN2 $1B0 + constant CAN2_CAN_RI0R	\ read-only		\  : RESET_CAN2_CAN_RI0R $00000000 
        \ % 21 lshift CAN2_CAN_RI0R        \ CAN2_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN2_CAN_RI0R        \ CAN2_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN2_CAN_RI0R        \ CAN2_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_RI0R        \ CAN2_RTR	Bit Offset:1	Bit Width:1
        
        CAN2 $1B4 + constant CAN2_CAN_RDT0R	\ read-only		\  : RESET_CAN2_CAN_RDT0R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN2_CAN_RDT0R        \ CAN2_TIME	Bit Offset:16	Bit Width:16
        \ %xxxxxxxx  8 lshift CAN2_CAN_RDT0R        \ CAN2_FMI	Bit Offset:8	Bit Width:8
        \ %xxxx  0 lshift CAN2_CAN_RDT0R        \ CAN2_DLC	Bit Offset:0	Bit Width:4
        
        CAN2 $1B8 + constant CAN2_CAN_RDL0R	\ read-only		\  : RESET_CAN2_CAN_RDL0R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_RDL0R        \ CAN2_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_RDL0R        \ CAN2_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_RDL0R        \ CAN2_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_RDL0R        \ CAN2_DATA0	Bit Offset:0	Bit Width:8
        
        CAN2 $1BC + constant CAN2_CAN_RDH0R	\ read-only		\  : RESET_CAN2_CAN_RDH0R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_RDH0R        \ CAN2_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_RDH0R        \ CAN2_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_RDH0R        \ CAN2_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_RDH0R        \ CAN2_DATA4	Bit Offset:0	Bit Width:8
        
        CAN2 $1C0 + constant CAN2_CAN_RI1R	\ read-only		\  : RESET_CAN2_CAN_RI1R $00000000 
        \ % 21 lshift CAN2_CAN_RI1R        \ CAN2_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN2_CAN_RI1R        \ CAN2_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN2_CAN_RI1R        \ CAN2_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN2_CAN_RI1R        \ CAN2_RTR	Bit Offset:1	Bit Width:1
        
        CAN2 $1C4 + constant CAN2_CAN_RDT1R	\ read-only		\  : RESET_CAN2_CAN_RDT1R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN2_CAN_RDT1R        \ CAN2_TIME	Bit Offset:16	Bit Width:16
        \ %xxxxxxxx  8 lshift CAN2_CAN_RDT1R        \ CAN2_FMI	Bit Offset:8	Bit Width:8
        \ %xxxx  0 lshift CAN2_CAN_RDT1R        \ CAN2_DLC	Bit Offset:0	Bit Width:4
        
        CAN2 $1C8 + constant CAN2_CAN_RDL1R	\ read-only		\  : RESET_CAN2_CAN_RDL1R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_RDL1R        \ CAN2_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_RDL1R        \ CAN2_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_RDL1R        \ CAN2_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_RDL1R        \ CAN2_DATA0	Bit Offset:0	Bit Width:8
        
        CAN2 $1CC + constant CAN2_CAN_RDH1R	\ read-only		\  : RESET_CAN2_CAN_RDH1R $00000000 
        \ %xxxxxxxx  24 lshift CAN2_CAN_RDH1R        \ CAN2_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN2_CAN_RDH1R        \ CAN2_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN2_CAN_RDH1R        \ CAN2_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN2_CAN_RDH1R        \ CAN2_DATA4	Bit Offset:0	Bit Width:8
        
        CAN2 $200 + constant CAN2_CAN_FMR	\ read-write		\  : RESET_CAN2_CAN_FMR $00000000 
        \ %xxxxxx  8 lshift CAN2_CAN_FMR        \ CAN2_CAN2SB	Bit Offset:8	Bit Width:6
        \ %x  0 lshift CAN2_CAN_FMR        \ CAN2_FINIT	Bit Offset:0	Bit Width:1
        
        CAN2 $204 + constant CAN2_CAN_FM1R	\ read-write		\  : RESET_CAN2_CAN_FM1R $00000000 
        \ %x  0 lshift CAN2_CAN_FM1R        \ CAN2_FBM0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_CAN_FM1R        \ CAN2_FBM1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_CAN_FM1R        \ CAN2_FBM2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_CAN_FM1R        \ CAN2_FBM3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_CAN_FM1R        \ CAN2_FBM4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_CAN_FM1R        \ CAN2_FBM5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_CAN_FM1R        \ CAN2_FBM6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_CAN_FM1R        \ CAN2_FBM7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_CAN_FM1R        \ CAN2_FBM8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_CAN_FM1R        \ CAN2_FBM9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_CAN_FM1R        \ CAN2_FBM10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_CAN_FM1R        \ CAN2_FBM11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_CAN_FM1R        \ CAN2_FBM12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_CAN_FM1R        \ CAN2_FBM13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_CAN_FM1R        \ CAN2_FBM14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_CAN_FM1R        \ CAN2_FBM15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_CAN_FM1R        \ CAN2_FBM16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_CAN_FM1R        \ CAN2_FBM17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_CAN_FM1R        \ CAN2_FBM18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_CAN_FM1R        \ CAN2_FBM19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_CAN_FM1R        \ CAN2_FBM20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_CAN_FM1R        \ CAN2_FBM21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_CAN_FM1R        \ CAN2_FBM22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_CAN_FM1R        \ CAN2_FBM23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_CAN_FM1R        \ CAN2_FBM24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_CAN_FM1R        \ CAN2_FBM25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_CAN_FM1R        \ CAN2_FBM26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_CAN_FM1R        \ CAN2_FBM27	Bit Offset:27	Bit Width:1
        
        CAN2 $20C + constant CAN2_CAN_FS1R	\ read-write		\  : RESET_CAN2_CAN_FS1R $00000000 
        \ %x  0 lshift CAN2_CAN_FS1R        \ CAN2_FSC0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_CAN_FS1R        \ CAN2_FSC1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_CAN_FS1R        \ CAN2_FSC2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_CAN_FS1R        \ CAN2_FSC3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_CAN_FS1R        \ CAN2_FSC4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_CAN_FS1R        \ CAN2_FSC5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_CAN_FS1R        \ CAN2_FSC6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_CAN_FS1R        \ CAN2_FSC7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_CAN_FS1R        \ CAN2_FSC8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_CAN_FS1R        \ CAN2_FSC9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_CAN_FS1R        \ CAN2_FSC10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_CAN_FS1R        \ CAN2_FSC11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_CAN_FS1R        \ CAN2_FSC12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_CAN_FS1R        \ CAN2_FSC13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_CAN_FS1R        \ CAN2_FSC14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_CAN_FS1R        \ CAN2_FSC15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_CAN_FS1R        \ CAN2_FSC16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_CAN_FS1R        \ CAN2_FSC17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_CAN_FS1R        \ CAN2_FSC18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_CAN_FS1R        \ CAN2_FSC19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_CAN_FS1R        \ CAN2_FSC20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_CAN_FS1R        \ CAN2_FSC21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_CAN_FS1R        \ CAN2_FSC22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_CAN_FS1R        \ CAN2_FSC23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_CAN_FS1R        \ CAN2_FSC24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_CAN_FS1R        \ CAN2_FSC25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_CAN_FS1R        \ CAN2_FSC26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_CAN_FS1R        \ CAN2_FSC27	Bit Offset:27	Bit Width:1
        
        CAN2 $214 + constant CAN2_CAN_FFA1R	\ read-write		\  : RESET_CAN2_CAN_FFA1R $00000000 
        \ %x  0 lshift CAN2_CAN_FFA1R        \ CAN2_FFA0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_CAN_FFA1R        \ CAN2_FFA1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_CAN_FFA1R        \ CAN2_FFA2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_CAN_FFA1R        \ CAN2_FFA3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_CAN_FFA1R        \ CAN2_FFA4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_CAN_FFA1R        \ CAN2_FFA5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_CAN_FFA1R        \ CAN2_FFA6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_CAN_FFA1R        \ CAN2_FFA7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_CAN_FFA1R        \ CAN2_FFA8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_CAN_FFA1R        \ CAN2_FFA9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_CAN_FFA1R        \ CAN2_FFA10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_CAN_FFA1R        \ CAN2_FFA11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_CAN_FFA1R        \ CAN2_FFA12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_CAN_FFA1R        \ CAN2_FFA13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_CAN_FFA1R        \ CAN2_FFA14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_CAN_FFA1R        \ CAN2_FFA15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_CAN_FFA1R        \ CAN2_FFA16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_CAN_FFA1R        \ CAN2_FFA17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_CAN_FFA1R        \ CAN2_FFA18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_CAN_FFA1R        \ CAN2_FFA19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_CAN_FFA1R        \ CAN2_FFA20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_CAN_FFA1R        \ CAN2_FFA21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_CAN_FFA1R        \ CAN2_FFA22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_CAN_FFA1R        \ CAN2_FFA23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_CAN_FFA1R        \ CAN2_FFA24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_CAN_FFA1R        \ CAN2_FFA25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_CAN_FFA1R        \ CAN2_FFA26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_CAN_FFA1R        \ CAN2_FFA27	Bit Offset:27	Bit Width:1
        
        CAN2 $21C + constant CAN2_CAN_FA1R	\ read-write		\  : RESET_CAN2_CAN_FA1R $00000000 
        \ %x  0 lshift CAN2_CAN_FA1R        \ CAN2_FACT0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_CAN_FA1R        \ CAN2_FACT1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_CAN_FA1R        \ CAN2_FACT2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_CAN_FA1R        \ CAN2_FACT3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_CAN_FA1R        \ CAN2_FACT4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_CAN_FA1R        \ CAN2_FACT5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_CAN_FA1R        \ CAN2_FACT6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_CAN_FA1R        \ CAN2_FACT7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_CAN_FA1R        \ CAN2_FACT8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_CAN_FA1R        \ CAN2_FACT9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_CAN_FA1R        \ CAN2_FACT10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_CAN_FA1R        \ CAN2_FACT11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_CAN_FA1R        \ CAN2_FACT12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_CAN_FA1R        \ CAN2_FACT13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_CAN_FA1R        \ CAN2_FACT14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_CAN_FA1R        \ CAN2_FACT15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_CAN_FA1R        \ CAN2_FACT16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_CAN_FA1R        \ CAN2_FACT17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_CAN_FA1R        \ CAN2_FACT18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_CAN_FA1R        \ CAN2_FACT19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_CAN_FA1R        \ CAN2_FACT20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_CAN_FA1R        \ CAN2_FACT21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_CAN_FA1R        \ CAN2_FACT22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_CAN_FA1R        \ CAN2_FACT23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_CAN_FA1R        \ CAN2_FACT24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_CAN_FA1R        \ CAN2_FACT25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_CAN_FA1R        \ CAN2_FACT26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_CAN_FA1R        \ CAN2_FACT27	Bit Offset:27	Bit Width:1
        
        CAN2 $240 + constant CAN2_F0R1	\ read-write		\  : RESET_CAN2_F0R1 $00000000 
        \ %x  0 lshift CAN2_F0R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F0R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F0R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F0R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F0R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F0R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F0R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F0R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F0R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F0R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F0R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F0R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F0R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F0R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F0R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F0R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F0R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F0R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F0R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F0R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F0R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F0R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F0R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F0R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F0R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F0R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F0R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F0R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F0R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F0R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F0R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F0R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $244 + constant CAN2_F0R2	\ read-write		\  : RESET_CAN2_F0R2 $00000000 
        \ %x  0 lshift CAN2_F0R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F0R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F0R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F0R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F0R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F0R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F0R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F0R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F0R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F0R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F0R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F0R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F0R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F0R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F0R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F0R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F0R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F0R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F0R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F0R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F0R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F0R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F0R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F0R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F0R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F0R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F0R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F0R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F0R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F0R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F0R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F0R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $248 + constant CAN2_F1R1	\ read-write		\  : RESET_CAN2_F1R1 $00000000 
        \ %x  0 lshift CAN2_F1R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F1R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F1R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F1R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F1R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F1R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F1R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F1R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F1R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F1R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F1R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F1R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F1R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F1R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F1R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F1R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F1R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F1R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F1R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F1R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F1R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F1R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F1R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F1R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F1R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F1R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F1R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F1R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F1R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F1R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F1R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F1R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $24C + constant CAN2_F1R2	\ read-write		\  : RESET_CAN2_F1R2 $00000000 
        \ %x  0 lshift CAN2_F1R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F1R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F1R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F1R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F1R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F1R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F1R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F1R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F1R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F1R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F1R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F1R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F1R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F1R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F1R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F1R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F1R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F1R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F1R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F1R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F1R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F1R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F1R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F1R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F1R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F1R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F1R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F1R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F1R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F1R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F1R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F1R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $250 + constant CAN2_F2R1	\ read-write		\  : RESET_CAN2_F2R1 $00000000 
        \ %x  0 lshift CAN2_F2R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F2R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F2R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F2R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F2R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F2R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F2R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F2R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F2R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F2R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F2R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F2R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F2R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F2R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F2R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F2R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F2R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F2R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F2R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F2R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F2R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F2R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F2R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F2R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F2R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F2R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F2R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F2R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F2R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F2R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F2R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F2R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $254 + constant CAN2_F2R2	\ read-write		\  : RESET_CAN2_F2R2 $00000000 
        \ %x  0 lshift CAN2_F2R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F2R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F2R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F2R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F2R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F2R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F2R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F2R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F2R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F2R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F2R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F2R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F2R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F2R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F2R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F2R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F2R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F2R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F2R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F2R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F2R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F2R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F2R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F2R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F2R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F2R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F2R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F2R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F2R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F2R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F2R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F2R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $258 + constant CAN2_F3R1	\ read-write		\  : RESET_CAN2_F3R1 $00000000 
        \ %x  0 lshift CAN2_F3R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F3R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F3R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F3R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F3R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F3R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F3R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F3R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F3R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F3R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F3R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F3R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F3R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F3R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F3R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F3R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F3R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F3R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F3R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F3R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F3R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F3R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F3R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F3R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F3R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F3R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F3R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F3R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F3R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F3R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F3R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F3R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $25C + constant CAN2_F3R2	\ read-write		\  : RESET_CAN2_F3R2 $00000000 
        \ %x  0 lshift CAN2_F3R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F3R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F3R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F3R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F3R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F3R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F3R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F3R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F3R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F3R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F3R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F3R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F3R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F3R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F3R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F3R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F3R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F3R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F3R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F3R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F3R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F3R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F3R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F3R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F3R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F3R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F3R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F3R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F3R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F3R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F3R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F3R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $260 + constant CAN2_F4R1	\ read-write		\  : RESET_CAN2_F4R1 $00000000 
        \ %x  0 lshift CAN2_F4R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F4R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F4R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F4R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F4R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F4R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F4R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F4R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F4R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F4R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F4R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F4R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F4R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F4R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F4R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F4R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F4R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F4R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F4R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F4R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F4R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F4R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F4R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F4R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F4R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F4R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F4R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F4R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F4R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F4R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F4R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F4R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $264 + constant CAN2_F4R2	\ read-write		\  : RESET_CAN2_F4R2 $00000000 
        \ %x  0 lshift CAN2_F4R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F4R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F4R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F4R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F4R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F4R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F4R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F4R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F4R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F4R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F4R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F4R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F4R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F4R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F4R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F4R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F4R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F4R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F4R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F4R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F4R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F4R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F4R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F4R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F4R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F4R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F4R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F4R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F4R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F4R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F4R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F4R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $268 + constant CAN2_F5R1	\ read-write		\  : RESET_CAN2_F5R1 $00000000 
        \ %x  0 lshift CAN2_F5R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F5R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F5R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F5R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F5R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F5R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F5R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F5R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F5R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F5R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F5R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F5R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F5R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F5R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F5R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F5R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F5R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F5R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F5R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F5R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F5R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F5R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F5R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F5R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F5R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F5R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F5R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F5R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F5R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F5R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F5R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F5R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $26C + constant CAN2_F5R2	\ read-write		\  : RESET_CAN2_F5R2 $00000000 
        \ %x  0 lshift CAN2_F5R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F5R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F5R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F5R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F5R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F5R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F5R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F5R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F5R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F5R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F5R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F5R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F5R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F5R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F5R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F5R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F5R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F5R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F5R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F5R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F5R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F5R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F5R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F5R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F5R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F5R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F5R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F5R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F5R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F5R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F5R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F5R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $270 + constant CAN2_F6R1	\ read-write		\  : RESET_CAN2_F6R1 $00000000 
        \ %x  0 lshift CAN2_F6R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F6R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F6R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F6R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F6R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F6R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F6R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F6R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F6R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F6R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F6R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F6R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F6R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F6R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F6R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F6R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F6R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F6R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F6R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F6R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F6R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F6R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F6R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F6R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F6R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F6R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F6R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F6R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F6R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F6R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F6R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F6R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $274 + constant CAN2_F6R2	\ read-write		\  : RESET_CAN2_F6R2 $00000000 
        \ %x  0 lshift CAN2_F6R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F6R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F6R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F6R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F6R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F6R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F6R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F6R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F6R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F6R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F6R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F6R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F6R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F6R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F6R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F6R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F6R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F6R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F6R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F6R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F6R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F6R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F6R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F6R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F6R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F6R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F6R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F6R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F6R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F6R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F6R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F6R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $278 + constant CAN2_F7R1	\ read-write		\  : RESET_CAN2_F7R1 $00000000 
        \ %x  0 lshift CAN2_F7R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F7R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F7R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F7R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F7R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F7R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F7R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F7R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F7R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F7R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F7R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F7R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F7R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F7R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F7R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F7R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F7R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F7R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F7R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F7R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F7R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F7R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F7R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F7R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F7R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F7R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F7R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F7R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F7R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F7R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F7R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F7R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $27C + constant CAN2_F7R2	\ read-write		\  : RESET_CAN2_F7R2 $00000000 
        \ %x  0 lshift CAN2_F7R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F7R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F7R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F7R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F7R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F7R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F7R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F7R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F7R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F7R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F7R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F7R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F7R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F7R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F7R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F7R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F7R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F7R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F7R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F7R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F7R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F7R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F7R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F7R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F7R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F7R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F7R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F7R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F7R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F7R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F7R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F7R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $280 + constant CAN2_F8R1	\ read-write		\  : RESET_CAN2_F8R1 $00000000 
        \ %x  0 lshift CAN2_F8R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F8R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F8R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F8R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F8R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F8R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F8R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F8R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F8R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F8R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F8R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F8R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F8R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F8R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F8R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F8R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F8R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F8R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F8R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F8R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F8R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F8R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F8R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F8R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F8R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F8R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F8R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F8R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F8R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F8R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F8R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F8R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $284 + constant CAN2_F8R2	\ read-write		\  : RESET_CAN2_F8R2 $00000000 
        \ %x  0 lshift CAN2_F8R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F8R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F8R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F8R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F8R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F8R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F8R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F8R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F8R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F8R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F8R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F8R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F8R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F8R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F8R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F8R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F8R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F8R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F8R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F8R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F8R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F8R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F8R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F8R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F8R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F8R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F8R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F8R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F8R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F8R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F8R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F8R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $288 + constant CAN2_F9R1	\ read-write		\  : RESET_CAN2_F9R1 $00000000 
        \ %x  0 lshift CAN2_F9R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F9R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F9R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F9R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F9R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F9R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F9R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F9R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F9R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F9R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F9R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F9R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F9R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F9R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F9R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F9R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F9R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F9R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F9R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F9R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F9R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F9R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F9R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F9R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F9R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F9R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F9R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F9R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F9R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F9R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F9R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F9R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $28C + constant CAN2_F9R2	\ read-write		\  : RESET_CAN2_F9R2 $00000000 
        \ %x  0 lshift CAN2_F9R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F9R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F9R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F9R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F9R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F9R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F9R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F9R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F9R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F9R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F9R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F9R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F9R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F9R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F9R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F9R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F9R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F9R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F9R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F9R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F9R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F9R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F9R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F9R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F9R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F9R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F9R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F9R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F9R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F9R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F9R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F9R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $290 + constant CAN2_F10R1	\ read-write		\  : RESET_CAN2_F10R1 $00000000 
        \ %x  0 lshift CAN2_F10R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F10R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F10R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F10R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F10R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F10R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F10R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F10R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F10R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F10R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F10R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F10R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F10R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F10R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F10R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F10R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F10R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F10R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F10R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F10R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F10R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F10R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F10R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F10R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F10R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F10R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F10R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F10R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F10R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F10R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F10R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F10R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $294 + constant CAN2_F10R2	\ read-write		\  : RESET_CAN2_F10R2 $00000000 
        \ %x  0 lshift CAN2_F10R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F10R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F10R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F10R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F10R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F10R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F10R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F10R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F10R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F10R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F10R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F10R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F10R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F10R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F10R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F10R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F10R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F10R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F10R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F10R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F10R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F10R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F10R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F10R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F10R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F10R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F10R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F10R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F10R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F10R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F10R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F10R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $298 + constant CAN2_F11R1	\ read-write		\  : RESET_CAN2_F11R1 $00000000 
        \ %x  0 lshift CAN2_F11R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F11R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F11R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F11R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F11R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F11R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F11R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F11R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F11R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F11R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F11R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F11R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F11R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F11R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F11R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F11R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F11R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F11R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F11R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F11R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F11R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F11R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F11R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F11R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F11R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F11R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F11R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F11R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F11R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F11R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F11R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F11R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $29C + constant CAN2_F11R2	\ read-write		\  : RESET_CAN2_F11R2 $00000000 
        \ %x  0 lshift CAN2_F11R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F11R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F11R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F11R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F11R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F11R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F11R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F11R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F11R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F11R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F11R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F11R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F11R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F11R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F11R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F11R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F11R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F11R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F11R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F11R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F11R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F11R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F11R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F11R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F11R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F11R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F11R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F11R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F11R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F11R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F11R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F11R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2A0 + constant CAN2_F12R1	\ read-write		\  : RESET_CAN2_F12R1 $00000000 
        \ %x  0 lshift CAN2_F12R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F12R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F12R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F12R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F12R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F12R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F12R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F12R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F12R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F12R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F12R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F12R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F12R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F12R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F12R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F12R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F12R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F12R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F12R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F12R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F12R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F12R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F12R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F12R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F12R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F12R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F12R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F12R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F12R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F12R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F12R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F12R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2A4 + constant CAN2_F12R2	\ read-write		\  : RESET_CAN2_F12R2 $00000000 
        \ %x  0 lshift CAN2_F12R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F12R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F12R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F12R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F12R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F12R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F12R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F12R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F12R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F12R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F12R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F12R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F12R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F12R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F12R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F12R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F12R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F12R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F12R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F12R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F12R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F12R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F12R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F12R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F12R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F12R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F12R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F12R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F12R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F12R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F12R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F12R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2A8 + constant CAN2_F13R1	\ read-write		\  : RESET_CAN2_F13R1 $00000000 
        \ %x  0 lshift CAN2_F13R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F13R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F13R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F13R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F13R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F13R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F13R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F13R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F13R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F13R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F13R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F13R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F13R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F13R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F13R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F13R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F13R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F13R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F13R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F13R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F13R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F13R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F13R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F13R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F13R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F13R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F13R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F13R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F13R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F13R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F13R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F13R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2AC + constant CAN2_F13R2	\ read-write		\  : RESET_CAN2_F13R2 $00000000 
        \ %x  0 lshift CAN2_F13R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F13R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F13R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F13R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F13R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F13R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F13R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F13R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F13R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F13R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F13R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F13R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F13R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F13R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F13R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F13R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F13R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F13R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F13R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F13R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F13R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F13R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F13R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F13R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F13R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F13R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F13R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F13R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F13R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F13R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F13R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F13R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2B0 + constant CAN2_F14R1	\ read-write		\  : RESET_CAN2_F14R1 $00000000 
        \ %x  0 lshift CAN2_F14R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F14R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F14R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F14R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F14R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F14R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F14R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F14R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F14R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F14R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F14R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F14R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F14R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F14R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F14R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F14R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F14R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F14R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F14R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F14R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F14R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F14R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F14R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F14R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F14R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F14R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F14R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F14R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F14R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F14R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F14R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F14R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2B4 + constant CAN2_F14R2	\ read-write		\  : RESET_CAN2_F14R2 $00000000 
        \ %x  0 lshift CAN2_F14R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F14R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F14R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F14R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F14R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F14R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F14R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F14R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F14R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F14R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F14R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F14R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F14R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F14R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F14R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F14R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F14R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F14R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F14R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F14R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F14R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F14R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F14R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F14R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F14R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F14R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F14R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F14R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F14R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F14R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F14R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F14R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2B8 + constant CAN2_F15R1	\ read-write		\  : RESET_CAN2_F15R1 $00000000 
        \ %x  0 lshift CAN2_F15R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F15R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F15R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F15R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F15R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F15R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F15R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F15R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F15R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F15R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F15R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F15R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F15R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F15R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F15R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F15R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F15R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F15R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F15R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F15R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F15R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F15R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F15R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F15R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F15R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F15R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F15R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F15R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F15R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F15R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F15R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F15R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2BC + constant CAN2_F15R2	\ read-write		\  : RESET_CAN2_F15R2 $00000000 
        \ %x  0 lshift CAN2_F15R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F15R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F15R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F15R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F15R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F15R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F15R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F15R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F15R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F15R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F15R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F15R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F15R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F15R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F15R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F15R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F15R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F15R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F15R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F15R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F15R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F15R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F15R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F15R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F15R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F15R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F15R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F15R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F15R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F15R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F15R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F15R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2C0 + constant CAN2_F16R1	\ read-write		\  : RESET_CAN2_F16R1 $00000000 
        \ %x  0 lshift CAN2_F16R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F16R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F16R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F16R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F16R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F16R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F16R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F16R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F16R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F16R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F16R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F16R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F16R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F16R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F16R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F16R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F16R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F16R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F16R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F16R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F16R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F16R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F16R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F16R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F16R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F16R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F16R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F16R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F16R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F16R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F16R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F16R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2C4 + constant CAN2_F16R2	\ read-write		\  : RESET_CAN2_F16R2 $00000000 
        \ %x  0 lshift CAN2_F16R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F16R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F16R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F16R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F16R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F16R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F16R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F16R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F16R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F16R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F16R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F16R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F16R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F16R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F16R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F16R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F16R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F16R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F16R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F16R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F16R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F16R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F16R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F16R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F16R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F16R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F16R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F16R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F16R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F16R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F16R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F16R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2C8 + constant CAN2_F17R1	\ read-write		\  : RESET_CAN2_F17R1 $00000000 
        \ %x  0 lshift CAN2_F17R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F17R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F17R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F17R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F17R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F17R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F17R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F17R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F17R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F17R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F17R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F17R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F17R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F17R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F17R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F17R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F17R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F17R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F17R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F17R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F17R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F17R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F17R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F17R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F17R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F17R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F17R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F17R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F17R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F17R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F17R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F17R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2CC + constant CAN2_F17R2	\ read-write		\  : RESET_CAN2_F17R2 $00000000 
        \ %x  0 lshift CAN2_F17R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F17R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F17R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F17R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F17R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F17R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F17R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F17R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F17R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F17R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F17R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F17R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F17R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F17R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F17R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F17R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F17R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F17R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F17R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F17R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F17R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F17R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F17R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F17R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F17R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F17R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F17R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F17R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F17R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F17R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F17R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F17R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2D0 + constant CAN2_F18R1	\ read-write		\  : RESET_CAN2_F18R1 $00000000 
        \ %x  0 lshift CAN2_F18R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F18R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F18R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F18R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F18R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F18R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F18R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F18R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F18R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F18R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F18R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F18R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F18R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F18R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F18R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F18R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F18R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F18R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F18R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F18R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F18R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F18R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F18R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F18R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F18R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F18R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F18R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F18R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F18R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F18R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F18R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F18R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2D4 + constant CAN2_F18R2	\ read-write		\  : RESET_CAN2_F18R2 $00000000 
        \ %x  0 lshift CAN2_F18R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F18R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F18R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F18R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F18R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F18R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F18R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F18R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F18R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F18R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F18R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F18R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F18R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F18R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F18R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F18R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F18R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F18R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F18R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F18R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F18R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F18R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F18R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F18R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F18R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F18R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F18R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F18R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F18R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F18R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F18R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F18R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2D8 + constant CAN2_F19R1	\ read-write		\  : RESET_CAN2_F19R1 $00000000 
        \ %x  0 lshift CAN2_F19R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F19R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F19R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F19R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F19R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F19R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F19R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F19R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F19R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F19R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F19R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F19R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F19R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F19R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F19R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F19R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F19R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F19R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F19R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F19R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F19R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F19R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F19R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F19R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F19R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F19R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F19R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F19R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F19R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F19R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F19R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F19R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2DC + constant CAN2_F19R2	\ read-write		\  : RESET_CAN2_F19R2 $00000000 
        \ %x  0 lshift CAN2_F19R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F19R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F19R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F19R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F19R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F19R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F19R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F19R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F19R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F19R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F19R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F19R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F19R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F19R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F19R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F19R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F19R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F19R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F19R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F19R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F19R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F19R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F19R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F19R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F19R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F19R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F19R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F19R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F19R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F19R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F19R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F19R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2E0 + constant CAN2_F20R1	\ read-write		\  : RESET_CAN2_F20R1 $00000000 
        \ %x  0 lshift CAN2_F20R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F20R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F20R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F20R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F20R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F20R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F20R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F20R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F20R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F20R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F20R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F20R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F20R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F20R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F20R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F20R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F20R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F20R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F20R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F20R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F20R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F20R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F20R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F20R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F20R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F20R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F20R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F20R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F20R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F20R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F20R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F20R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2E4 + constant CAN2_F20R2	\ read-write		\  : RESET_CAN2_F20R2 $00000000 
        \ %x  0 lshift CAN2_F20R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F20R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F20R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F20R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F20R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F20R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F20R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F20R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F20R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F20R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F20R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F20R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F20R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F20R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F20R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F20R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F20R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F20R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F20R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F20R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F20R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F20R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F20R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F20R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F20R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F20R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F20R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F20R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F20R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F20R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F20R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F20R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2E8 + constant CAN2_F21R1	\ read-write		\  : RESET_CAN2_F21R1 $00000000 
        \ %x  0 lshift CAN2_F21R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F21R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F21R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F21R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F21R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F21R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F21R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F21R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F21R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F21R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F21R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F21R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F21R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F21R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F21R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F21R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F21R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F21R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F21R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F21R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F21R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F21R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F21R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F21R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F21R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F21R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F21R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F21R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F21R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F21R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F21R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F21R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2EC + constant CAN2_F21R2	\ read-write		\  : RESET_CAN2_F21R2 $00000000 
        \ %x  0 lshift CAN2_F21R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F21R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F21R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F21R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F21R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F21R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F21R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F21R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F21R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F21R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F21R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F21R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F21R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F21R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F21R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F21R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F21R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F21R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F21R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F21R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F21R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F21R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F21R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F21R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F21R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F21R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F21R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F21R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F21R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F21R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F21R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F21R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2F0 + constant CAN2_F22R1	\ read-write		\  : RESET_CAN2_F22R1 $00000000 
        \ %x  0 lshift CAN2_F22R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F22R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F22R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F22R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F22R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F22R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F22R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F22R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F22R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F22R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F22R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F22R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F22R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F22R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F22R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F22R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F22R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F22R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F22R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F22R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F22R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F22R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F22R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F22R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F22R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F22R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F22R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F22R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F22R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F22R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F22R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F22R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2F4 + constant CAN2_F22R2	\ read-write		\  : RESET_CAN2_F22R2 $00000000 
        \ %x  0 lshift CAN2_F22R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F22R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F22R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F22R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F22R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F22R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F22R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F22R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F22R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F22R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F22R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F22R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F22R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F22R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F22R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F22R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F22R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F22R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F22R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F22R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F22R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F22R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F22R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F22R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F22R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F22R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F22R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F22R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F22R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F22R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F22R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F22R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2F8 + constant CAN2_F23R1	\ read-write		\  : RESET_CAN2_F23R1 $00000000 
        \ %x  0 lshift CAN2_F23R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F23R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F23R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F23R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F23R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F23R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F23R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F23R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F23R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F23R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F23R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F23R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F23R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F23R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F23R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F23R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F23R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F23R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F23R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F23R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F23R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F23R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F23R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F23R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F23R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F23R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F23R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F23R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F23R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F23R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F23R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F23R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $2FC + constant CAN2_F23R2	\ read-write		\  : RESET_CAN2_F23R2 $00000000 
        \ %x  0 lshift CAN2_F23R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F23R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F23R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F23R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F23R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F23R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F23R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F23R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F23R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F23R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F23R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F23R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F23R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F23R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F23R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F23R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F23R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F23R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F23R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F23R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F23R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F23R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F23R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F23R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F23R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F23R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F23R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F23R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F23R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F23R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F23R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F23R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $300 + constant CAN2_F24R1	\ read-write		\  : RESET_CAN2_F24R1 $00000000 
        \ %x  0 lshift CAN2_F24R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F24R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F24R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F24R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F24R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F24R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F24R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F24R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F24R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F24R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F24R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F24R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F24R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F24R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F24R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F24R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F24R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F24R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F24R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F24R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F24R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F24R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F24R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F24R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F24R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F24R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F24R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F24R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F24R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F24R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F24R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F24R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $304 + constant CAN2_F24R2	\ read-write		\  : RESET_CAN2_F24R2 $00000000 
        \ %x  0 lshift CAN2_F24R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F24R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F24R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F24R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F24R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F24R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F24R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F24R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F24R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F24R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F24R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F24R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F24R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F24R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F24R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F24R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F24R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F24R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F24R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F24R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F24R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F24R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F24R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F24R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F24R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F24R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F24R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F24R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F24R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F24R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F24R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F24R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $308 + constant CAN2_F25R1	\ read-write		\  : RESET_CAN2_F25R1 $00000000 
        \ %x  0 lshift CAN2_F25R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F25R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F25R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F25R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F25R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F25R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F25R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F25R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F25R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F25R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F25R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F25R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F25R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F25R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F25R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F25R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F25R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F25R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F25R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F25R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F25R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F25R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F25R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F25R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F25R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F25R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F25R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F25R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F25R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F25R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F25R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F25R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $30C + constant CAN2_F25R2	\ read-write		\  : RESET_CAN2_F25R2 $00000000 
        \ %x  0 lshift CAN2_F25R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F25R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F25R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F25R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F25R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F25R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F25R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F25R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F25R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F25R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F25R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F25R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F25R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F25R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F25R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F25R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F25R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F25R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F25R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F25R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F25R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F25R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F25R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F25R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F25R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F25R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F25R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F25R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F25R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F25R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F25R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F25R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $310 + constant CAN2_F26R1	\ read-write		\  : RESET_CAN2_F26R1 $00000000 
        \ %x  0 lshift CAN2_F26R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F26R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F26R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F26R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F26R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F26R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F26R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F26R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F26R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F26R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F26R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F26R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F26R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F26R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F26R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F26R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F26R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F26R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F26R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F26R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F26R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F26R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F26R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F26R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F26R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F26R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F26R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F26R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F26R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F26R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F26R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F26R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $314 + constant CAN2_F26R2	\ read-write		\  : RESET_CAN2_F26R2 $00000000 
        \ %x  0 lshift CAN2_F26R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F26R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F26R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F26R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F26R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F26R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F26R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F26R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F26R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F26R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F26R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F26R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F26R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F26R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F26R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F26R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F26R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F26R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F26R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F26R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F26R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F26R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F26R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F26R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F26R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F26R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F26R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F26R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F26R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F26R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F26R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F26R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $318 + constant CAN2_F27R1	\ read-write		\  : RESET_CAN2_F27R1 $00000000 
        \ %x  0 lshift CAN2_F27R1        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F27R1        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F27R1        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F27R1        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F27R1        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F27R1        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F27R1        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F27R1        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F27R1        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F27R1        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F27R1        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F27R1        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F27R1        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F27R1        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F27R1        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F27R1        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F27R1        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F27R1        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F27R1        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F27R1        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F27R1        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F27R1        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F27R1        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F27R1        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F27R1        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F27R1        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F27R1        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F27R1        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F27R1        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F27R1        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F27R1        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F27R1        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
        CAN2 $31C + constant CAN2_F27R2	\ read-write		\  : RESET_CAN2_F27R2 $00000000 
        \ %x  0 lshift CAN2_F27R2        \ CAN2_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN2_F27R2        \ CAN2_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN2_F27R2        \ CAN2_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN2_F27R2        \ CAN2_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN2_F27R2        \ CAN2_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN2_F27R2        \ CAN2_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN2_F27R2        \ CAN2_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN2_F27R2        \ CAN2_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN2_F27R2        \ CAN2_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN2_F27R2        \ CAN2_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN2_F27R2        \ CAN2_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN2_F27R2        \ CAN2_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN2_F27R2        \ CAN2_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN2_F27R2        \ CAN2_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN2_F27R2        \ CAN2_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN2_F27R2        \ CAN2_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN2_F27R2        \ CAN2_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN2_F27R2        \ CAN2_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN2_F27R2        \ CAN2_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN2_F27R2        \ CAN2_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN2_F27R2        \ CAN2_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN2_F27R2        \ CAN2_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN2_F27R2        \ CAN2_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN2_F27R2        \ CAN2_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN2_F27R2        \ CAN2_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN2_F27R2        \ CAN2_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN2_F27R2        \ CAN2_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN2_F27R2        \ CAN2_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN2_F27R2        \ CAN2_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN2_F27R2        \ CAN2_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN2_F27R2        \ CAN2_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN2_F27R2        \ CAN2_FB31	Bit Offset:31	Bit Width:1
        
         
	
     $40006400 constant CAN1  
	  
	
     $40028000 constant ETHERNET_MAC  
	 ETHERNET_MAC $0 + constant ETHERNET_MAC_MACCR	\ read-write		\  : RESET_ETHERNET_MAC_MACCR $00008000 
        \ %x  2 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_RE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_TE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_DC	Bit Offset:4	Bit Width:1
        \ %xx  5 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_BL	Bit Offset:5	Bit Width:2
        \ %x  7 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_APCS	Bit Offset:7	Bit Width:1
        \ %x  9 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_RD	Bit Offset:9	Bit Width:1
        \ %x  10 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_IPCO	Bit Offset:10	Bit Width:1
        \ %x  11 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_DM	Bit Offset:11	Bit Width:1
        \ %x  12 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_LM	Bit Offset:12	Bit Width:1
        \ %x  13 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_ROD	Bit Offset:13	Bit Width:1
        \ %x  14 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_FES	Bit Offset:14	Bit Width:1
        \ %x  16 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_CSD	Bit Offset:16	Bit Width:1
        \ %xxx  17 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_IFG	Bit Offset:17	Bit Width:3
        \ %x  22 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_JD	Bit Offset:22	Bit Width:1
        \ %x  23 lshift ETHERNET_MAC_MACCR        \ ETHERNET_MAC_WD	Bit Offset:23	Bit Width:1
        
        ETHERNET_MAC $4 + constant ETHERNET_MAC_MACFFR	\ read-write		\  : RESET_ETHERNET_MAC_MACFFR $00000000 
        \ %x  0 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_PM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_HU	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_HM	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_DAIF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_PAM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_BFD	Bit Offset:5	Bit Width:1
        \ %xx  6 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_PCF	Bit Offset:6	Bit Width:2
        \ %x  8 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_SAIF	Bit Offset:8	Bit Width:1
        \ %x  9 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_SAF	Bit Offset:9	Bit Width:1
        \ %x  10 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_HPF	Bit Offset:10	Bit Width:1
        \ %x  31 lshift ETHERNET_MAC_MACFFR        \ ETHERNET_MAC_RA	Bit Offset:31	Bit Width:1
        
        ETHERNET_MAC $8 + constant ETHERNET_MAC_MACHTHR	\ read-write		\  : RESET_ETHERNET_MAC_MACHTHR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACHTHR        \ ETHERNET_MAC_HTH	Bit Offset:0	Bit Width:32
        
        ETHERNET_MAC $C + constant ETHERNET_MAC_MACHTLR	\ read-write		\  : RESET_ETHERNET_MAC_MACHTLR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACHTLR        \ ETHERNET_MAC_HTL	Bit Offset:0	Bit Width:32
        
        ETHERNET_MAC $10 + constant ETHERNET_MAC_MACMIIAR	\ read-write		\  : RESET_ETHERNET_MAC_MACMIIAR $00000000 
        \ %x  0 lshift ETHERNET_MAC_MACMIIAR        \ ETHERNET_MAC_MB	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_MAC_MACMIIAR        \ ETHERNET_MAC_MW	Bit Offset:1	Bit Width:1
        \ %xxx  2 lshift ETHERNET_MAC_MACMIIAR        \ ETHERNET_MAC_CR	Bit Offset:2	Bit Width:3
        \ %xxxxx  6 lshift ETHERNET_MAC_MACMIIAR        \ ETHERNET_MAC_MR	Bit Offset:6	Bit Width:5
        \ %xxxxx  11 lshift ETHERNET_MAC_MACMIIAR        \ ETHERNET_MAC_PA	Bit Offset:11	Bit Width:5
        
        ETHERNET_MAC $14 + constant ETHERNET_MAC_MACMIIDR	\ read-write		\  : RESET_ETHERNET_MAC_MACMIIDR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACMIIDR        \ ETHERNET_MAC_MD	Bit Offset:0	Bit Width:16
        
        ETHERNET_MAC $18 + constant ETHERNET_MAC_MACFCR	\ read-write		\  : RESET_ETHERNET_MAC_MACFCR $00000000 
        \ %x  0 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_FCB_BPA	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_TFCE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_RFCE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_UPFD	Bit Offset:3	Bit Width:1
        \ %xx  4 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_PLT	Bit Offset:4	Bit Width:2
        \ %x  7 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_ZQPD	Bit Offset:7	Bit Width:1
        \ %xxxxxxxxxxxxxxxx  16 lshift ETHERNET_MAC_MACFCR        \ ETHERNET_MAC_PT	Bit Offset:16	Bit Width:16
        
        ETHERNET_MAC $1C + constant ETHERNET_MAC_MACVLANTR	\ read-write		\  : RESET_ETHERNET_MAC_MACVLANTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACVLANTR        \ ETHERNET_MAC_VLANTI	Bit Offset:0	Bit Width:16
        \ %x  16 lshift ETHERNET_MAC_MACVLANTR        \ ETHERNET_MAC_VLANTC	Bit Offset:16	Bit Width:1
        
        ETHERNET_MAC $28 + constant ETHERNET_MAC_MACRWUFFR	\ read-write		\  : RESET_ETHERNET_MAC_MACRWUFFR $00000000 
        
        ETHERNET_MAC $2C + constant ETHERNET_MAC_MACPMTCSR	\ read-write		\  : RESET_ETHERNET_MAC_MACPMTCSR $00000000 
        \ %x  0 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_PD	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_MPE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_WFE	Bit Offset:2	Bit Width:1
        \ %x  5 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_MPR	Bit Offset:5	Bit Width:1
        \ %x  6 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_WFR	Bit Offset:6	Bit Width:1
        \ %x  9 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_GU	Bit Offset:9	Bit Width:1
        \ %x  31 lshift ETHERNET_MAC_MACPMTCSR        \ ETHERNET_MAC_WFFRPR	Bit Offset:31	Bit Width:1
        
        ETHERNET_MAC $38 + constant ETHERNET_MAC_MACSR	\ read-write		\  : RESET_ETHERNET_MAC_MACSR $00000000 
        \ %x  3 lshift ETHERNET_MAC_MACSR        \ ETHERNET_MAC_PMTS	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ETHERNET_MAC_MACSR        \ ETHERNET_MAC_MMCS	Bit Offset:4	Bit Width:1
        \ %x  5 lshift ETHERNET_MAC_MACSR        \ ETHERNET_MAC_MMCRS	Bit Offset:5	Bit Width:1
        \ %x  6 lshift ETHERNET_MAC_MACSR        \ ETHERNET_MAC_MMCTS	Bit Offset:6	Bit Width:1
        \ %x  9 lshift ETHERNET_MAC_MACSR        \ ETHERNET_MAC_TSTS	Bit Offset:9	Bit Width:1
        
        ETHERNET_MAC $3C + constant ETHERNET_MAC_MACIMR	\ read-write		\  : RESET_ETHERNET_MAC_MACIMR $00000000 
        \ %x  3 lshift ETHERNET_MAC_MACIMR        \ ETHERNET_MAC_PMTIM	Bit Offset:3	Bit Width:1
        \ %x  9 lshift ETHERNET_MAC_MACIMR        \ ETHERNET_MAC_TSTIM	Bit Offset:9	Bit Width:1
        
        ETHERNET_MAC $40 + constant ETHERNET_MAC_MACA0HR	\ 		\  : RESET_ETHERNET_MAC_MACA0HR $0010FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA0HR        \ ETHERNET_MAC_MACA0H	Bit Offset:0	Bit Width:16
        \ %x  31 lshift ETHERNET_MAC_MACA0HR        \ ETHERNET_MAC_MO	Bit Offset:31	Bit Width:1
        
        ETHERNET_MAC $44 + constant ETHERNET_MAC_MACA0LR	\ read-write		\  : RESET_ETHERNET_MAC_MACA0LR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA0LR        \ ETHERNET_MAC_MACA0L	Bit Offset:0	Bit Width:32
        
        ETHERNET_MAC $48 + constant ETHERNET_MAC_MACA1HR	\ read-write		\  : RESET_ETHERNET_MAC_MACA1HR $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA1HR        \ ETHERNET_MAC_MACA1H	Bit Offset:0	Bit Width:16
        \ %xxxxxx  24 lshift ETHERNET_MAC_MACA1HR        \ ETHERNET_MAC_MBC	Bit Offset:24	Bit Width:6
        \ %x  30 lshift ETHERNET_MAC_MACA1HR        \ ETHERNET_MAC_SA	Bit Offset:30	Bit Width:1
        \ %x  31 lshift ETHERNET_MAC_MACA1HR        \ ETHERNET_MAC_AE	Bit Offset:31	Bit Width:1
        
        ETHERNET_MAC $4C + constant ETHERNET_MAC_MACA1LR	\ read-write		\  : RESET_ETHERNET_MAC_MACA1LR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA1LR        \ ETHERNET_MAC_MACA1L	Bit Offset:0	Bit Width:32
        
        ETHERNET_MAC $50 + constant ETHERNET_MAC_MACA2HR	\ read-write		\  : RESET_ETHERNET_MAC_MACA2HR $0050 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA2HR        \ ETHERNET_MAC_ETH_MACA2HR	Bit Offset:0	Bit Width:16
        \ %xxxxxx  24 lshift ETHERNET_MAC_MACA2HR        \ ETHERNET_MAC_MBC	Bit Offset:24	Bit Width:6
        \ %x  30 lshift ETHERNET_MAC_MACA2HR        \ ETHERNET_MAC_SA	Bit Offset:30	Bit Width:1
        \ %x  31 lshift ETHERNET_MAC_MACA2HR        \ ETHERNET_MAC_AE	Bit Offset:31	Bit Width:1
        
        ETHERNET_MAC $54 + constant ETHERNET_MAC_MACA2LR	\ read-write		\  : RESET_ETHERNET_MAC_MACA2LR $FFFFFFFF 
        \ % 0 lshift ETHERNET_MAC_MACA2LR        \ ETHERNET_MAC_MACA2L	Bit Offset:0	Bit Width:31
        
        ETHERNET_MAC $58 + constant ETHERNET_MAC_MACA3HR	\ read-write		\  : RESET_ETHERNET_MAC_MACA3HR $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA3HR        \ ETHERNET_MAC_MACA3H	Bit Offset:0	Bit Width:16
        \ %xxxxxx  24 lshift ETHERNET_MAC_MACA3HR        \ ETHERNET_MAC_MBC	Bit Offset:24	Bit Width:6
        \ %x  30 lshift ETHERNET_MAC_MACA3HR        \ ETHERNET_MAC_SA	Bit Offset:30	Bit Width:1
        \ %x  31 lshift ETHERNET_MAC_MACA3HR        \ ETHERNET_MAC_AE	Bit Offset:31	Bit Width:1
        
        ETHERNET_MAC $5C + constant ETHERNET_MAC_MACA3LR	\ read-write		\  : RESET_ETHERNET_MAC_MACA3LR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MAC_MACA3LR        \ ETHERNET_MAC_MBCA3L	Bit Offset:0	Bit Width:32
        
         
	
     $40028100 constant ETHERNET_MMC  
	 ETHERNET_MMC $0 + constant ETHERNET_MMC_MMCCR	\ read-write		\  : RESET_ETHERNET_MMC_MMCCR $00000000 
        \ %x  0 lshift ETHERNET_MMC_MMCCR        \ ETHERNET_MMC_CR	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_MMC_MMCCR        \ ETHERNET_MMC_CSR	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_MMC_MMCCR        \ ETHERNET_MMC_ROR	Bit Offset:2	Bit Width:1
        \ %x  31 lshift ETHERNET_MMC_MMCCR        \ ETHERNET_MMC_MCF	Bit Offset:31	Bit Width:1
        
        ETHERNET_MMC $4 + constant ETHERNET_MMC_MMCRIR	\ read-write		\  : RESET_ETHERNET_MMC_MMCRIR $00000000 
        \ %x  5 lshift ETHERNET_MMC_MMCRIR        \ ETHERNET_MMC_RFCES	Bit Offset:5	Bit Width:1
        \ %x  6 lshift ETHERNET_MMC_MMCRIR        \ ETHERNET_MMC_RFAES	Bit Offset:6	Bit Width:1
        \ %x  17 lshift ETHERNET_MMC_MMCRIR        \ ETHERNET_MMC_RGUFS	Bit Offset:17	Bit Width:1
        
        ETHERNET_MMC $8 + constant ETHERNET_MMC_MMCTIR	\ read-write		\  : RESET_ETHERNET_MMC_MMCTIR $00000000 
        \ %x  14 lshift ETHERNET_MMC_MMCTIR        \ ETHERNET_MMC_TGFSCS	Bit Offset:14	Bit Width:1
        \ %x  15 lshift ETHERNET_MMC_MMCTIR        \ ETHERNET_MMC_TGFMSCS	Bit Offset:15	Bit Width:1
        \ %x  21 lshift ETHERNET_MMC_MMCTIR        \ ETHERNET_MMC_TGFS	Bit Offset:21	Bit Width:1
        
        ETHERNET_MMC $C + constant ETHERNET_MMC_MMCRIMR	\ read-write		\  : RESET_ETHERNET_MMC_MMCRIMR $00000000 
        \ %x  5 lshift ETHERNET_MMC_MMCRIMR        \ ETHERNET_MMC_RFCEM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift ETHERNET_MMC_MMCRIMR        \ ETHERNET_MMC_RFAEM	Bit Offset:6	Bit Width:1
        \ %x  17 lshift ETHERNET_MMC_MMCRIMR        \ ETHERNET_MMC_RGUFM	Bit Offset:17	Bit Width:1
        
        ETHERNET_MMC $10 + constant ETHERNET_MMC_MMCTIMR	\ read-write		\  : RESET_ETHERNET_MMC_MMCTIMR $00000000 
        \ %x  14 lshift ETHERNET_MMC_MMCTIMR        \ ETHERNET_MMC_TGFSCM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift ETHERNET_MMC_MMCTIMR        \ ETHERNET_MMC_TGFMSCM	Bit Offset:15	Bit Width:1
        \ %x  21 lshift ETHERNET_MMC_MMCTIMR        \ ETHERNET_MMC_TGFM	Bit Offset:21	Bit Width:1
        
        ETHERNET_MMC $4C + constant ETHERNET_MMC_MMCTGFSCCR	\ read-only		\  : RESET_ETHERNET_MMC_MMCTGFSCCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MMC_MMCTGFSCCR        \ ETHERNET_MMC_TGFSCC	Bit Offset:0	Bit Width:32
        
        ETHERNET_MMC $50 + constant ETHERNET_MMC_MMCTGFMSCCR	\ read-only		\  : RESET_ETHERNET_MMC_MMCTGFMSCCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MMC_MMCTGFMSCCR        \ ETHERNET_MMC_TGFMSCC	Bit Offset:0	Bit Width:32
        
        ETHERNET_MMC $68 + constant ETHERNET_MMC_MMCTGFCR	\ read-only		\  : RESET_ETHERNET_MMC_MMCTGFCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MMC_MMCTGFCR        \ ETHERNET_MMC_TGFC	Bit Offset:0	Bit Width:32
        
        ETHERNET_MMC $94 + constant ETHERNET_MMC_MMCRFCECR	\ read-only		\  : RESET_ETHERNET_MMC_MMCRFCECR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MMC_MMCRFCECR        \ ETHERNET_MMC_RFCFC	Bit Offset:0	Bit Width:32
        
        ETHERNET_MMC $98 + constant ETHERNET_MMC_MMCRFAECR	\ read-only		\  : RESET_ETHERNET_MMC_MMCRFAECR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MMC_MMCRFAECR        \ ETHERNET_MMC_RFAEC	Bit Offset:0	Bit Width:32
        
        ETHERNET_MMC $C4 + constant ETHERNET_MMC_MMCRGUFCR	\ read-only		\  : RESET_ETHERNET_MMC_MMCRGUFCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_MMC_MMCRGUFCR        \ ETHERNET_MMC_RGUFC	Bit Offset:0	Bit Width:32
        
         
	
     $40028700 constant ETHERNET_PTP  
	 ETHERNET_PTP $0 + constant ETHERNET_PTP_PTPTSCR	\ read-write		\  : RESET_ETHERNET_PTP_PTPTSCR $00000000 
        \ %x  0 lshift ETHERNET_PTP_PTPTSCR        \ ETHERNET_PTP_TSE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_PTP_PTPTSCR        \ ETHERNET_PTP_TSFCU	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_PTP_PTPTSCR        \ ETHERNET_PTP_TSSTI	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ETHERNET_PTP_PTPTSCR        \ ETHERNET_PTP_TSSTU	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ETHERNET_PTP_PTPTSCR        \ ETHERNET_PTP_TSITE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift ETHERNET_PTP_PTPTSCR        \ ETHERNET_PTP_TSARU	Bit Offset:5	Bit Width:1
        
        ETHERNET_PTP $4 + constant ETHERNET_PTP_PTPSSIR	\ read-write		\  : RESET_ETHERNET_PTP_PTPSSIR $00000000 
        \ %xxxxxxxx  0 lshift ETHERNET_PTP_PTPSSIR        \ ETHERNET_PTP_STSSI	Bit Offset:0	Bit Width:8
        
        ETHERNET_PTP $8 + constant ETHERNET_PTP_PTPTSHR	\ read-only		\  : RESET_ETHERNET_PTP_PTPTSHR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_PTP_PTPTSHR        \ ETHERNET_PTP_STS	Bit Offset:0	Bit Width:32
        
        ETHERNET_PTP $C + constant ETHERNET_PTP_PTPTSLR	\ read-only		\  : RESET_ETHERNET_PTP_PTPTSLR $00000000 
        \ % 0 lshift ETHERNET_PTP_PTPTSLR        \ ETHERNET_PTP_STSS	Bit Offset:0	Bit Width:31
        \ %x  31 lshift ETHERNET_PTP_PTPTSLR        \ ETHERNET_PTP_STPNS	Bit Offset:31	Bit Width:1
        
        ETHERNET_PTP $10 + constant ETHERNET_PTP_PTPTSHUR	\ read-write		\  : RESET_ETHERNET_PTP_PTPTSHUR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_PTP_PTPTSHUR        \ ETHERNET_PTP_TSUS	Bit Offset:0	Bit Width:32
        
        ETHERNET_PTP $14 + constant ETHERNET_PTP_PTPTSLUR	\ read-write		\  : RESET_ETHERNET_PTP_PTPTSLUR $00000000 
        \ % 0 lshift ETHERNET_PTP_PTPTSLUR        \ ETHERNET_PTP_TSUSS	Bit Offset:0	Bit Width:31
        \ %x  31 lshift ETHERNET_PTP_PTPTSLUR        \ ETHERNET_PTP_TSUPNS	Bit Offset:31	Bit Width:1
        
        ETHERNET_PTP $18 + constant ETHERNET_PTP_PTPTSAR	\ read-write		\  : RESET_ETHERNET_PTP_PTPTSAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_PTP_PTPTSAR        \ ETHERNET_PTP_TSA	Bit Offset:0	Bit Width:32
        
        ETHERNET_PTP $1C + constant ETHERNET_PTP_PTPTTHR	\ read-write		\  : RESET_ETHERNET_PTP_PTPTTHR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_PTP_PTPTTHR        \ ETHERNET_PTP_TTSH	Bit Offset:0	Bit Width:32
        
        ETHERNET_PTP $20 + constant ETHERNET_PTP_PTPTTLR	\ read-write		\  : RESET_ETHERNET_PTP_PTPTTLR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_PTP_PTPTTLR        \ ETHERNET_PTP_TTSL	Bit Offset:0	Bit Width:32
        
         
	
     $40029000 constant ETHERNET_DMA  
	 ETHERNET_DMA $0 + constant ETHERNET_DMA_DMABMR	\ read-write		\  : RESET_ETHERNET_DMA_DMABMR $20101 
        \ %x  0 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_SR	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_DA	Bit Offset:1	Bit Width:1
        \ %xxxxx  2 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_DSL	Bit Offset:2	Bit Width:5
        \ %xxxxxx  8 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_PBL	Bit Offset:8	Bit Width:6
        \ %xx  14 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_RTPR	Bit Offset:14	Bit Width:2
        \ %x  16 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_FB	Bit Offset:16	Bit Width:1
        \ %xxxxxx  17 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_RDP	Bit Offset:17	Bit Width:6
        \ %x  23 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_USP	Bit Offset:23	Bit Width:1
        \ %x  24 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_FPM	Bit Offset:24	Bit Width:1
        \ %x  25 lshift ETHERNET_DMA_DMABMR        \ ETHERNET_DMA_AAB	Bit Offset:25	Bit Width:1
        
        ETHERNET_DMA $4 + constant ETHERNET_DMA_DMATPDR	\ read-write		\  : RESET_ETHERNET_DMA_DMATPDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMATPDR        \ ETHERNET_DMA_TPD	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $8 + constant ETHERNET_DMA_DMARPDR	\ read-write		\  : RESET_ETHERNET_DMA_DMARPDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMARPDR        \ ETHERNET_DMA_RPD	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $C + constant ETHERNET_DMA_DMARDLAR	\ read-write		\  : RESET_ETHERNET_DMA_DMARDLAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMARDLAR        \ ETHERNET_DMA_SRL	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $10 + constant ETHERNET_DMA_DMATDLAR	\ read-write		\  : RESET_ETHERNET_DMA_DMATDLAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMATDLAR        \ ETHERNET_DMA_STL	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $14 + constant ETHERNET_DMA_DMASR	\ 		\  : RESET_ETHERNET_DMA_DMASR $00000000 
        \ %x  0 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TPSS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TBUS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TJTS	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_ROS	Bit Offset:4	Bit Width:1
        \ %x  5 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TUS	Bit Offset:5	Bit Width:1
        \ %x  6 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_RS	Bit Offset:6	Bit Width:1
        \ %x  7 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_RBUS	Bit Offset:7	Bit Width:1
        \ %x  8 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_RPSS	Bit Offset:8	Bit Width:1
        \ %x  9 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_PWTS	Bit Offset:9	Bit Width:1
        \ %x  10 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_ETS	Bit Offset:10	Bit Width:1
        \ %x  13 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_FBES	Bit Offset:13	Bit Width:1
        \ %x  14 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_ERS	Bit Offset:14	Bit Width:1
        \ %x  15 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_AIS	Bit Offset:15	Bit Width:1
        \ %x  16 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_NIS	Bit Offset:16	Bit Width:1
        \ %xxx  17 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_RPS	Bit Offset:17	Bit Width:3
        \ %xxx  20 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TPS	Bit Offset:20	Bit Width:3
        \ %xxx  23 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_EBS	Bit Offset:23	Bit Width:3
        \ %x  27 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_MMCS	Bit Offset:27	Bit Width:1
        \ %x  28 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_PMTS	Bit Offset:28	Bit Width:1
        \ %x  29 lshift ETHERNET_DMA_DMASR        \ ETHERNET_DMA_TSTS	Bit Offset:29	Bit Width:1
        
        ETHERNET_DMA $18 + constant ETHERNET_DMA_DMAOMR	\ read-write		\  : RESET_ETHERNET_DMA_DMAOMR $00000000 
        \ %x  1 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_SR	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_OSF	Bit Offset:2	Bit Width:1
        \ %xx  3 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_RTC	Bit Offset:3	Bit Width:2
        \ %x  6 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_FUGF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_FEF	Bit Offset:7	Bit Width:1
        \ %x  13 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_ST	Bit Offset:13	Bit Width:1
        \ %xxx  14 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_TTC	Bit Offset:14	Bit Width:3
        \ %x  20 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_FTF	Bit Offset:20	Bit Width:1
        \ %x  21 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_TSF	Bit Offset:21	Bit Width:1
        \ %x  24 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_DFRF	Bit Offset:24	Bit Width:1
        \ %x  25 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_RSF	Bit Offset:25	Bit Width:1
        \ %x  26 lshift ETHERNET_DMA_DMAOMR        \ ETHERNET_DMA_DTCEFD	Bit Offset:26	Bit Width:1
        
        ETHERNET_DMA $1C + constant ETHERNET_DMA_DMAIER	\ read-write		\  : RESET_ETHERNET_DMA_DMAIER $00000000 
        \ %x  0 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_TIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_TPSIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_TBUIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_TJTIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_ROIE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_TUIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_RIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_RBUIE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_RPSIE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_RWTIE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_ETIE	Bit Offset:10	Bit Width:1
        \ %x  13 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_FBEIE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_ERIE	Bit Offset:14	Bit Width:1
        \ %x  15 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_AISE	Bit Offset:15	Bit Width:1
        \ %x  16 lshift ETHERNET_DMA_DMAIER        \ ETHERNET_DMA_NISE	Bit Offset:16	Bit Width:1
        
        ETHERNET_DMA $20 + constant ETHERNET_DMA_DMAMFBOCR	\ read-only		\  : RESET_ETHERNET_DMA_DMAMFBOCR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMAMFBOCR        \ ETHERNET_DMA_MFC	Bit Offset:0	Bit Width:16
        \ %x  16 lshift ETHERNET_DMA_DMAMFBOCR        \ ETHERNET_DMA_OMFC	Bit Offset:16	Bit Width:1
        \ % 17 lshift ETHERNET_DMA_DMAMFBOCR        \ ETHERNET_DMA_MFA	Bit Offset:17	Bit Width:11
        \ %x  28 lshift ETHERNET_DMA_DMAMFBOCR        \ ETHERNET_DMA_OFOC	Bit Offset:28	Bit Width:1
        
        ETHERNET_DMA $48 + constant ETHERNET_DMA_DMACHTDR	\ read-only		\  : RESET_ETHERNET_DMA_DMACHTDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMACHTDR        \ ETHERNET_DMA_HTDAP	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $4C + constant ETHERNET_DMA_DMACHRDR	\ read-only		\  : RESET_ETHERNET_DMA_DMACHRDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMACHRDR        \ ETHERNET_DMA_HRDAP	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $50 + constant ETHERNET_DMA_DMACHTBAR	\ read-only		\  : RESET_ETHERNET_DMA_DMACHTBAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMACHTBAR        \ ETHERNET_DMA_HTBAP	Bit Offset:0	Bit Width:32
        
        ETHERNET_DMA $54 + constant ETHERNET_DMA_DMACHRBAR	\ read-only		\  : RESET_ETHERNET_DMA_DMACHRBAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ETHERNET_DMA_DMACHRBAR        \ ETHERNET_DMA_HRBAP	Bit Offset:0	Bit Width:32
        
         
	
     $50000000 constant USB_OTG_GLOBAL  
	 USB_OTG_GLOBAL $0 + constant USB_OTG_GLOBAL_FS_GOTGCTL	\ 		\  : RESET_USB_OTG_GLOBAL_FS_GOTGCTL $00000800 
        \ %x  0 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_SRQSCS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_SRQ	Bit Offset:1	Bit Width:1
        \ %x  8 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_HNGSCS	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_HNPRQ	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_HSHNPEN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_DHNPEN	Bit Offset:11	Bit Width:1
        \ %x  16 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_CIDSTS	Bit Offset:16	Bit Width:1
        \ %x  17 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_DBCT	Bit Offset:17	Bit Width:1
        \ %x  18 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_ASVLD	Bit Offset:18	Bit Width:1
        \ %x  19 lshift USB_OTG_GLOBAL_FS_GOTGCTL        \ USB_OTG_GLOBAL_BSVLD	Bit Offset:19	Bit Width:1
        
        USB_OTG_GLOBAL $4 + constant USB_OTG_GLOBAL_FS_GOTGINT	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_GOTGINT $00000000 
        \ %x  2 lshift USB_OTG_GLOBAL_FS_GOTGINT        \ USB_OTG_GLOBAL_SEDET	Bit Offset:2	Bit Width:1
        \ %x  8 lshift USB_OTG_GLOBAL_FS_GOTGINT        \ USB_OTG_GLOBAL_SRSSCHG	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_GLOBAL_FS_GOTGINT        \ USB_OTG_GLOBAL_HNSSCHG	Bit Offset:9	Bit Width:1
        \ %x  17 lshift USB_OTG_GLOBAL_FS_GOTGINT        \ USB_OTG_GLOBAL_HNGDET	Bit Offset:17	Bit Width:1
        \ %x  18 lshift USB_OTG_GLOBAL_FS_GOTGINT        \ USB_OTG_GLOBAL_ADTOCHG	Bit Offset:18	Bit Width:1
        \ %x  19 lshift USB_OTG_GLOBAL_FS_GOTGINT        \ USB_OTG_GLOBAL_DBCDNE	Bit Offset:19	Bit Width:1
        
        USB_OTG_GLOBAL $8 + constant USB_OTG_GLOBAL_FS_GAHBCFG	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_GAHBCFG $00000000 
        \ %x  0 lshift USB_OTG_GLOBAL_FS_GAHBCFG        \ USB_OTG_GLOBAL_GINT	Bit Offset:0	Bit Width:1
        \ %x  7 lshift USB_OTG_GLOBAL_FS_GAHBCFG        \ USB_OTG_GLOBAL_TXFELVL	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_GLOBAL_FS_GAHBCFG        \ USB_OTG_GLOBAL_PTXFELVL	Bit Offset:8	Bit Width:1
        
        USB_OTG_GLOBAL $C + constant USB_OTG_GLOBAL_FS_GUSBCFG	\ 		\  : RESET_USB_OTG_GLOBAL_FS_GUSBCFG $00000A00 
        \ %xxx  0 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_TOCAL	Bit Offset:0	Bit Width:3
        \ %x  7 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_PHYSEL	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_SRPCAP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_HNPCAP	Bit Offset:9	Bit Width:1
        \ %xxxx  10 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_TRDT	Bit Offset:10	Bit Width:4
        \ %x  29 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_FHMOD	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_FDMOD	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_GLOBAL_FS_GUSBCFG        \ USB_OTG_GLOBAL_CTXPKT	Bit Offset:31	Bit Width:1
        
        USB_OTG_GLOBAL $10 + constant USB_OTG_GLOBAL_FS_GRSTCTL	\ 		\  : RESET_USB_OTG_GLOBAL_FS_GRSTCTL $20000000 
        \ %x  0 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_CSRST	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_HSRST	Bit Offset:1	Bit Width:1
        \ %x  2 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_FCRST	Bit Offset:2	Bit Width:1
        \ %x  4 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_RXFFLSH	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_TXFFLSH	Bit Offset:5	Bit Width:1
        \ %xxxxx  6 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_TXFNUM	Bit Offset:6	Bit Width:5
        \ %x  31 lshift USB_OTG_GLOBAL_FS_GRSTCTL        \ USB_OTG_GLOBAL_AHBIDL	Bit Offset:31	Bit Width:1
        
        USB_OTG_GLOBAL $14 + constant USB_OTG_GLOBAL_FS_GINTSTS	\ 		\  : RESET_USB_OTG_GLOBAL_FS_GINTSTS $04000020 
        \ %x  0 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_CMOD	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_MMIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_OTGINT	Bit Offset:2	Bit Width:1
        \ %x  3 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_SOF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_RXFLVL	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_NPTXFE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_GINAKEFF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_GOUTNAKEFF	Bit Offset:7	Bit Width:1
        \ %x  10 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_ESUSP	Bit Offset:10	Bit Width:1
        \ %x  11 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_USBSUSP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_USBRST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_ENUMDNE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_ISOODRP	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_EOPF	Bit Offset:15	Bit Width:1
        \ %x  18 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_IEPINT	Bit Offset:18	Bit Width:1
        \ %x  19 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_OEPINT	Bit Offset:19	Bit Width:1
        \ %x  20 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_IISOIXFR	Bit Offset:20	Bit Width:1
        \ %x  21 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_IPXFR_INCOMPISOOUT	Bit Offset:21	Bit Width:1
        \ %x  24 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_HPRTINT	Bit Offset:24	Bit Width:1
        \ %x  25 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_HCINT	Bit Offset:25	Bit Width:1
        \ %x  26 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_PTXFE	Bit Offset:26	Bit Width:1
        \ %x  28 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_CIDSCHG	Bit Offset:28	Bit Width:1
        \ %x  29 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_DISCINT	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_SRQINT	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_GLOBAL_FS_GINTSTS        \ USB_OTG_GLOBAL_WKUPINT	Bit Offset:31	Bit Width:1
        
        USB_OTG_GLOBAL $18 + constant USB_OTG_GLOBAL_FS_GINTMSK	\ 		\  : RESET_USB_OTG_GLOBAL_FS_GINTMSK $00000000 
        \ %x  1 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_MMISM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_OTGINT	Bit Offset:2	Bit Width:1
        \ %x  3 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_SOFM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_RXFLVLM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_NPTXFEM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_GINAKEFFM	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_GONAKEFFM	Bit Offset:7	Bit Width:1
        \ %x  10 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_ESUSPM	Bit Offset:10	Bit Width:1
        \ %x  11 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_USBSUSPM	Bit Offset:11	Bit Width:1
        \ %x  12 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_USBRST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_ENUMDNEM	Bit Offset:13	Bit Width:1
        \ %x  14 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_ISOODRPM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_EOPFM	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_EPMISM	Bit Offset:17	Bit Width:1
        \ %x  18 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_IEPINT	Bit Offset:18	Bit Width:1
        \ %x  19 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_OEPINT	Bit Offset:19	Bit Width:1
        \ %x  20 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_IISOIXFRM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_IPXFRM_IISOOXFRM	Bit Offset:21	Bit Width:1
        \ %x  24 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_PRTIM	Bit Offset:24	Bit Width:1
        \ %x  25 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_HCIM	Bit Offset:25	Bit Width:1
        \ %x  26 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_PTXFEM	Bit Offset:26	Bit Width:1
        \ %x  28 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_CIDSCHGM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_DISCINT	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_SRQIM	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_GLOBAL_FS_GINTMSK        \ USB_OTG_GLOBAL_WUIM	Bit Offset:31	Bit Width:1
        
        USB_OTG_GLOBAL $1C + constant USB_OTG_GLOBAL_FS_GRXSTSR_Device	\ read-only		\  : RESET_USB_OTG_GLOBAL_FS_GRXSTSR_Device $00000000 
        \ %xxxx  0 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Device        \ USB_OTG_GLOBAL_EPNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Device        \ USB_OTG_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Device        \ USB_OTG_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Device        \ USB_OTG_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        \ %xxxx  21 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Device        \ USB_OTG_GLOBAL_FRMNUM	Bit Offset:21	Bit Width:4
        
        USB_OTG_GLOBAL $1C + constant USB_OTG_GLOBAL_FS_GRXSTSR_Host	\ read-only		\  : RESET_USB_OTG_GLOBAL_FS_GRXSTSR_Host $00000000 
        \ %xxxx  0 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Host        \ USB_OTG_GLOBAL_EPNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Host        \ USB_OTG_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Host        \ USB_OTG_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Host        \ USB_OTG_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        \ %xxxx  21 lshift USB_OTG_GLOBAL_FS_GRXSTSR_Host        \ USB_OTG_GLOBAL_FRMNUM	Bit Offset:21	Bit Width:4
        
        USB_OTG_GLOBAL $24 + constant USB_OTG_GLOBAL_FS_GRXFSIZ	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_GRXFSIZ $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_GRXFSIZ        \ USB_OTG_GLOBAL_RXFD	Bit Offset:0	Bit Width:16
        
        USB_OTG_GLOBAL $28 + constant USB_OTG_GLOBAL_FS_GNPTXFSIZ_Device	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_GNPTXFSIZ_Device $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_GNPTXFSIZ_Device        \ USB_OTG_GLOBAL_TX0FSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_GNPTXFSIZ_Device        \ USB_OTG_GLOBAL_TX0FD	Bit Offset:16	Bit Width:16
        
        USB_OTG_GLOBAL $28 + constant USB_OTG_GLOBAL_FS_GNPTXFSIZ_Host	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_GNPTXFSIZ_Host $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_GNPTXFSIZ_Host        \ USB_OTG_GLOBAL_NPTXFSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_GNPTXFSIZ_Host        \ USB_OTG_GLOBAL_NPTXFD	Bit Offset:16	Bit Width:16
        
        USB_OTG_GLOBAL $2C + constant USB_OTG_GLOBAL_FS_GNPTXSTS	\ read-only		\  : RESET_USB_OTG_GLOBAL_FS_GNPTXSTS $00080200 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_GNPTXSTS        \ USB_OTG_GLOBAL_NPTXFSAV	Bit Offset:0	Bit Width:16
        \ %xxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_GNPTXSTS        \ USB_OTG_GLOBAL_NPTQXSAV	Bit Offset:16	Bit Width:8
        \ %xxxxxxx  24 lshift USB_OTG_GLOBAL_FS_GNPTXSTS        \ USB_OTG_GLOBAL_NPTXQTOP	Bit Offset:24	Bit Width:7
        
        USB_OTG_GLOBAL $38 + constant USB_OTG_GLOBAL_FS_GCCFG	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_GCCFG $00000000 
        \ %x  16 lshift USB_OTG_GLOBAL_FS_GCCFG        \ USB_OTG_GLOBAL_PWRDWN	Bit Offset:16	Bit Width:1
        \ %x  18 lshift USB_OTG_GLOBAL_FS_GCCFG        \ USB_OTG_GLOBAL_VBUSASEN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift USB_OTG_GLOBAL_FS_GCCFG        \ USB_OTG_GLOBAL_VBUSBSEN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift USB_OTG_GLOBAL_FS_GCCFG        \ USB_OTG_GLOBAL_SOFOUTEN	Bit Offset:20	Bit Width:1
        
        USB_OTG_GLOBAL $3C + constant USB_OTG_GLOBAL_FS_CID	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_CID $00001000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_CID        \ USB_OTG_GLOBAL_PRODUCT_ID	Bit Offset:0	Bit Width:32
        
        USB_OTG_GLOBAL $100 + constant USB_OTG_GLOBAL_FS_HPTXFSIZ	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_HPTXFSIZ $02000600 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_HPTXFSIZ        \ USB_OTG_GLOBAL_PTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_HPTXFSIZ        \ USB_OTG_GLOBAL_PTXFSIZ	Bit Offset:16	Bit Width:16
        
        USB_OTG_GLOBAL $104 + constant USB_OTG_GLOBAL_FS_DIEPTXF1	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_DIEPTXF1 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_DIEPTXF1        \ USB_OTG_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_DIEPTXF1        \ USB_OTG_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        USB_OTG_GLOBAL $108 + constant USB_OTG_GLOBAL_FS_DIEPTXF2	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_DIEPTXF2 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_DIEPTXF2        \ USB_OTG_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_DIEPTXF2        \ USB_OTG_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        USB_OTG_GLOBAL $10C + constant USB_OTG_GLOBAL_FS_DIEPTXF3	\ read-write		\  : RESET_USB_OTG_GLOBAL_FS_DIEPTXF3 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_GLOBAL_FS_DIEPTXF3        \ USB_OTG_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_GLOBAL_FS_DIEPTXF3        \ USB_OTG_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
         
	
     $50000400 constant USB_OTG_HOST  
	 USB_OTG_HOST $0 + constant USB_OTG_HOST_FS_HCFG	\ 		\  : RESET_USB_OTG_HOST_FS_HCFG $00000000 
        \ %xx  0 lshift USB_OTG_HOST_FS_HCFG        \ USB_OTG_HOST_FSLSPCS	Bit Offset:0	Bit Width:2
        \ %x  2 lshift USB_OTG_HOST_FS_HCFG        \ USB_OTG_HOST_FSLSS	Bit Offset:2	Bit Width:1
        
        USB_OTG_HOST $4 + constant USB_OTG_HOST_HFIR	\ read-write		\  : RESET_USB_OTG_HOST_HFIR $0000EA60 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_HOST_HFIR        \ USB_OTG_HOST_FRIVL	Bit Offset:0	Bit Width:16
        
        USB_OTG_HOST $8 + constant USB_OTG_HOST_FS_HFNUM	\ read-only		\  : RESET_USB_OTG_HOST_FS_HFNUM $00003FFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_HOST_FS_HFNUM        \ USB_OTG_HOST_FRNUM	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_HOST_FS_HFNUM        \ USB_OTG_HOST_FTREM	Bit Offset:16	Bit Width:16
        
        USB_OTG_HOST $10 + constant USB_OTG_HOST_FS_HPTXSTS	\ 		\  : RESET_USB_OTG_HOST_FS_HPTXSTS $00080100 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_HOST_FS_HPTXSTS        \ USB_OTG_HOST_PTXFSAVL	Bit Offset:0	Bit Width:16
        \ %xxxxxxxx  16 lshift USB_OTG_HOST_FS_HPTXSTS        \ USB_OTG_HOST_PTXQSAV	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift USB_OTG_HOST_FS_HPTXSTS        \ USB_OTG_HOST_PTXQTOP	Bit Offset:24	Bit Width:8
        
        USB_OTG_HOST $14 + constant USB_OTG_HOST_HAINT	\ read-only		\  : RESET_USB_OTG_HOST_HAINT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_HOST_HAINT        \ USB_OTG_HOST_HAINT	Bit Offset:0	Bit Width:16
        
        USB_OTG_HOST $18 + constant USB_OTG_HOST_HAINTMSK	\ read-write		\  : RESET_USB_OTG_HOST_HAINTMSK $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_HOST_HAINTMSK        \ USB_OTG_HOST_HAINTM	Bit Offset:0	Bit Width:16
        
        USB_OTG_HOST $40 + constant USB_OTG_HOST_FS_HPRT	\ 		\  : RESET_USB_OTG_HOST_FS_HPRT $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PCSTS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PCDET	Bit Offset:1	Bit Width:1
        \ %x  2 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PENA	Bit Offset:2	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PENCHNG	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_POCA	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_POCCHNG	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PRES	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PSUSP	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PRST	Bit Offset:8	Bit Width:1
        \ %xx  10 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PLSTS	Bit Offset:10	Bit Width:2
        \ %x  12 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PPWR	Bit Offset:12	Bit Width:1
        \ %xxxx  13 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PTCTL	Bit Offset:13	Bit Width:4
        \ %xx  17 lshift USB_OTG_HOST_FS_HPRT        \ USB_OTG_HOST_PSPD	Bit Offset:17	Bit Width:2
        
        USB_OTG_HOST $100 + constant USB_OTG_HOST_FS_HCCHAR0	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR0 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR0        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $120 + constant USB_OTG_HOST_FS_HCCHAR1	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR1 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR1        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $140 + constant USB_OTG_HOST_FS_HCCHAR2	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR2 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR2        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $160 + constant USB_OTG_HOST_FS_HCCHAR3	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR3 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR3        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $180 + constant USB_OTG_HOST_FS_HCCHAR4	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR4 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR4        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $1A0 + constant USB_OTG_HOST_FS_HCCHAR5	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR5 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR5        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $1C0 + constant USB_OTG_HOST_FS_HCCHAR6	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR6 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR6        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $1E0 + constant USB_OTG_HOST_FS_HCCHAR7	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCCHAR7 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_HOST_FS_HCCHAR7        \ USB_OTG_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_HOST $108 + constant USB_OTG_HOST_FS_HCINT0	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT0 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT0        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $128 + constant USB_OTG_HOST_FS_HCINT1	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT1 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT1        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $148 + constant USB_OTG_HOST_FS_HCINT2	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT2 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT2        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $168 + constant USB_OTG_HOST_FS_HCINT3	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT3 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT3        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $188 + constant USB_OTG_HOST_FS_HCINT4	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT4 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT4        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $1A8 + constant USB_OTG_HOST_FS_HCINT5	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT5 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT5        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $1C8 + constant USB_OTG_HOST_FS_HCINT6	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT6 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT6        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $1E8 + constant USB_OTG_HOST_FS_HCINT7	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINT7 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINT7        \ USB_OTG_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $10C + constant USB_OTG_HOST_FS_HCINTMSK0	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK0 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK0        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $12C + constant USB_OTG_HOST_FS_HCINTMSK1	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK1 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK1        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $14C + constant USB_OTG_HOST_FS_HCINTMSK2	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK2 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK2        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $16C + constant USB_OTG_HOST_FS_HCINTMSK3	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK3 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK3        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $18C + constant USB_OTG_HOST_FS_HCINTMSK4	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK4 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK4        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $1AC + constant USB_OTG_HOST_FS_HCINTMSK5	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK5 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK5        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $1CC + constant USB_OTG_HOST_FS_HCINTMSK6	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK6 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK6        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $1EC + constant USB_OTG_HOST_FS_HCINTMSK7	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCINTMSK7 $00000000 
        \ %x  0 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_HOST_FS_HCINTMSK7        \ USB_OTG_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        USB_OTG_HOST $110 + constant USB_OTG_HOST_FS_HCTSIZ0	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ0 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ0        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ0        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ0        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $130 + constant USB_OTG_HOST_FS_HCTSIZ1	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ1 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ1        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ1        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ1        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $150 + constant USB_OTG_HOST_FS_HCTSIZ2	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ2 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ2        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ2        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ2        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $170 + constant USB_OTG_HOST_FS_HCTSIZ3	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ3 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ3        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ3        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ3        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $190 + constant USB_OTG_HOST_FS_HCTSIZ4	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ4 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ4        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ4        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ4        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $1B0 + constant USB_OTG_HOST_FS_HCTSIZ5	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ5 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ5        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ5        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ5        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $1D0 + constant USB_OTG_HOST_FS_HCTSIZ6	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ6 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ6        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ6        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ6        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
        USB_OTG_HOST $1F0 + constant USB_OTG_HOST_FS_HCTSIZ7	\ read-write		\  : RESET_USB_OTG_HOST_FS_HCTSIZ7 $00000000 
        \ % 0 lshift USB_OTG_HOST_FS_HCTSIZ7        \ USB_OTG_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift USB_OTG_HOST_FS_HCTSIZ7        \ USB_OTG_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift USB_OTG_HOST_FS_HCTSIZ7        \ USB_OTG_HOST_DPID	Bit Offset:29	Bit Width:2
        
         
	
     $50000800 constant USB_OTG_DEVICE  
	 USB_OTG_DEVICE $0 + constant USB_OTG_DEVICE_FS_DCFG	\ read-write		\  : RESET_USB_OTG_DEVICE_FS_DCFG $02200000 
        \ %xx  0 lshift USB_OTG_DEVICE_FS_DCFG        \ USB_OTG_DEVICE_DSPD	Bit Offset:0	Bit Width:2
        \ %x  2 lshift USB_OTG_DEVICE_FS_DCFG        \ USB_OTG_DEVICE_NZLSOHSK	Bit Offset:2	Bit Width:1
        \ %xxxxxxx  4 lshift USB_OTG_DEVICE_FS_DCFG        \ USB_OTG_DEVICE_DAD	Bit Offset:4	Bit Width:7
        \ %xx  11 lshift USB_OTG_DEVICE_FS_DCFG        \ USB_OTG_DEVICE_PFIVL	Bit Offset:11	Bit Width:2
        
        USB_OTG_DEVICE $4 + constant USB_OTG_DEVICE_FS_DCTL	\ 		\  : RESET_USB_OTG_DEVICE_FS_DCTL $00000000 
        \ %x  0 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_RWUSIG	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_SDIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_GINSTS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_GONSTS	Bit Offset:3	Bit Width:1
        \ %xxx  4 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_TCTL	Bit Offset:4	Bit Width:3
        \ %x  7 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_SGINAK	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_CGINAK	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_SGONAK	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_CGONAK	Bit Offset:10	Bit Width:1
        \ %x  11 lshift USB_OTG_DEVICE_FS_DCTL        \ USB_OTG_DEVICE_POPRGDNE	Bit Offset:11	Bit Width:1
        
        USB_OTG_DEVICE $8 + constant USB_OTG_DEVICE_FS_DSTS	\ read-only		\  : RESET_USB_OTG_DEVICE_FS_DSTS $00000010 
        \ %x  0 lshift USB_OTG_DEVICE_FS_DSTS        \ USB_OTG_DEVICE_SUSPSTS	Bit Offset:0	Bit Width:1
        \ %xx  1 lshift USB_OTG_DEVICE_FS_DSTS        \ USB_OTG_DEVICE_ENUMSPD	Bit Offset:1	Bit Width:2
        \ %x  3 lshift USB_OTG_DEVICE_FS_DSTS        \ USB_OTG_DEVICE_EERR	Bit Offset:3	Bit Width:1
        \ %xxxxxxxxxxxxxx  8 lshift USB_OTG_DEVICE_FS_DSTS        \ USB_OTG_DEVICE_FNSOF	Bit Offset:8	Bit Width:14
        
        USB_OTG_DEVICE $10 + constant USB_OTG_DEVICE_FS_DIEPMSK	\ read-write		\  : RESET_USB_OTG_DEVICE_FS_DIEPMSK $00000000 
        \ %x  0 lshift USB_OTG_DEVICE_FS_DIEPMSK        \ USB_OTG_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_FS_DIEPMSK        \ USB_OTG_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_FS_DIEPMSK        \ USB_OTG_DEVICE_TOM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_FS_DIEPMSK        \ USB_OTG_DEVICE_ITTXFEMSK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift USB_OTG_DEVICE_FS_DIEPMSK        \ USB_OTG_DEVICE_INEPNMM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift USB_OTG_DEVICE_FS_DIEPMSK        \ USB_OTG_DEVICE_INEPNEM	Bit Offset:6	Bit Width:1
        
        USB_OTG_DEVICE $14 + constant USB_OTG_DEVICE_FS_DOEPMSK	\ read-write		\  : RESET_USB_OTG_DEVICE_FS_DOEPMSK $00000000 
        \ %x  0 lshift USB_OTG_DEVICE_FS_DOEPMSK        \ USB_OTG_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_FS_DOEPMSK        \ USB_OTG_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_FS_DOEPMSK        \ USB_OTG_DEVICE_STUPM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_FS_DOEPMSK        \ USB_OTG_DEVICE_OTEPDM	Bit Offset:4	Bit Width:1
        
        USB_OTG_DEVICE $18 + constant USB_OTG_DEVICE_FS_DAINT	\ read-only		\  : RESET_USB_OTG_DEVICE_FS_DAINT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_FS_DAINT        \ USB_OTG_DEVICE_IEPINT	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_DEVICE_FS_DAINT        \ USB_OTG_DEVICE_OEPINT	Bit Offset:16	Bit Width:16
        
        USB_OTG_DEVICE $1C + constant USB_OTG_DEVICE_FS_DAINTMSK	\ read-write		\  : RESET_USB_OTG_DEVICE_FS_DAINTMSK $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_FS_DAINTMSK        \ USB_OTG_DEVICE_IEPM	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift USB_OTG_DEVICE_FS_DAINTMSK        \ USB_OTG_DEVICE_OEPINT	Bit Offset:16	Bit Width:16
        
        USB_OTG_DEVICE $28 + constant USB_OTG_DEVICE_DVBUSDIS	\ read-write		\  : RESET_USB_OTG_DEVICE_DVBUSDIS $000017D7 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DVBUSDIS        \ USB_OTG_DEVICE_VBUSDT	Bit Offset:0	Bit Width:16
        
        USB_OTG_DEVICE $2C + constant USB_OTG_DEVICE_DVBUSPULSE	\ read-write		\  : RESET_USB_OTG_DEVICE_DVBUSPULSE $000005B8 
        \ %xxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DVBUSPULSE        \ USB_OTG_DEVICE_DVBUSP	Bit Offset:0	Bit Width:12
        
        USB_OTG_DEVICE $34 + constant USB_OTG_DEVICE_DIEPEMPMSK	\ read-write		\  : RESET_USB_OTG_DEVICE_DIEPEMPMSK $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DIEPEMPMSK        \ USB_OTG_DEVICE_INEPTXFEM	Bit Offset:0	Bit Width:16
        
        USB_OTG_DEVICE $100 + constant USB_OTG_DEVICE_FS_DIEPCTL0	\ 		\  : RESET_USB_OTG_DEVICE_FS_DIEPCTL0 $00000000 
        \ %xx  0 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:2
        \ %x  15 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  17 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_STALL	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift USB_OTG_DEVICE_FS_DIEPCTL0        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        USB_OTG_DEVICE $120 + constant USB_OTG_DEVICE_DIEPCTL1	\ 		\  : RESET_USB_OTG_DEVICE_DIEPCTL1 $00000000 
        \ %x  31 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_SODDFRM_SD1PID	Bit Offset:29	Bit Width:1
        \ %x  28 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %xxxx  22 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  21 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift USB_OTG_DEVICE_DIEPCTL1        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        USB_OTG_DEVICE $140 + constant USB_OTG_DEVICE_DIEPCTL2	\ 		\  : RESET_USB_OTG_DEVICE_DIEPCTL2 $00000000 
        \ %x  31 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %xxxx  22 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  21 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift USB_OTG_DEVICE_DIEPCTL2        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        USB_OTG_DEVICE $160 + constant USB_OTG_DEVICE_DIEPCTL3	\ 		\  : RESET_USB_OTG_DEVICE_DIEPCTL3 $00000000 
        \ %x  31 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %xxxx  22 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  21 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift USB_OTG_DEVICE_DIEPCTL3        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        USB_OTG_DEVICE $300 + constant USB_OTG_DEVICE_DOEPCTL0	\ 		\  : RESET_USB_OTG_DEVICE_DOEPCTL0 $00008000 
        \ %x  31 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %xx  0 lshift USB_OTG_DEVICE_DOEPCTL0        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:2
        
        USB_OTG_DEVICE $320 + constant USB_OTG_DEVICE_DOEPCTL1	\ 		\  : RESET_USB_OTG_DEVICE_DOEPCTL1 $00000000 
        \ %x  31 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift USB_OTG_DEVICE_DOEPCTL1        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        USB_OTG_DEVICE $340 + constant USB_OTG_DEVICE_DOEPCTL2	\ 		\  : RESET_USB_OTG_DEVICE_DOEPCTL2 $00000000 
        \ %x  31 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift USB_OTG_DEVICE_DOEPCTL2        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        USB_OTG_DEVICE $360 + constant USB_OTG_DEVICE_DOEPCTL3	\ 		\  : RESET_USB_OTG_DEVICE_DOEPCTL3 $00000000 
        \ %x  31 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift USB_OTG_DEVICE_DOEPCTL3        \ USB_OTG_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        USB_OTG_DEVICE $108 + constant USB_OTG_DEVICE_DIEPINT0	\ 		\  : RESET_USB_OTG_DEVICE_DIEPINT0 $00000080 
        \ %x  7 lshift USB_OTG_DEVICE_DIEPINT0        \ USB_OTG_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_OTG_DEVICE_DIEPINT0        \ USB_OTG_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DIEPINT0        \ USB_OTG_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DIEPINT0        \ USB_OTG_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DIEPINT0        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DIEPINT0        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $128 + constant USB_OTG_DEVICE_DIEPINT1	\ 		\  : RESET_USB_OTG_DEVICE_DIEPINT1 $00000080 
        \ %x  7 lshift USB_OTG_DEVICE_DIEPINT1        \ USB_OTG_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_OTG_DEVICE_DIEPINT1        \ USB_OTG_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DIEPINT1        \ USB_OTG_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DIEPINT1        \ USB_OTG_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DIEPINT1        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DIEPINT1        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $148 + constant USB_OTG_DEVICE_DIEPINT2	\ 		\  : RESET_USB_OTG_DEVICE_DIEPINT2 $00000080 
        \ %x  7 lshift USB_OTG_DEVICE_DIEPINT2        \ USB_OTG_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_OTG_DEVICE_DIEPINT2        \ USB_OTG_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DIEPINT2        \ USB_OTG_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DIEPINT2        \ USB_OTG_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DIEPINT2        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DIEPINT2        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $168 + constant USB_OTG_DEVICE_DIEPINT3	\ 		\  : RESET_USB_OTG_DEVICE_DIEPINT3 $00000080 
        \ %x  7 lshift USB_OTG_DEVICE_DIEPINT3        \ USB_OTG_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_OTG_DEVICE_DIEPINT3        \ USB_OTG_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DIEPINT3        \ USB_OTG_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DIEPINT3        \ USB_OTG_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DIEPINT3        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DIEPINT3        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $308 + constant USB_OTG_DEVICE_DOEPINT0	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPINT0 $00000080 
        \ %x  6 lshift USB_OTG_DEVICE_DOEPINT0        \ USB_OTG_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DOEPINT0        \ USB_OTG_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DOEPINT0        \ USB_OTG_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DOEPINT0        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DOEPINT0        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $328 + constant USB_OTG_DEVICE_DOEPINT1	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPINT1 $00000080 
        \ %x  6 lshift USB_OTG_DEVICE_DOEPINT1        \ USB_OTG_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DOEPINT1        \ USB_OTG_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DOEPINT1        \ USB_OTG_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DOEPINT1        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DOEPINT1        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $348 + constant USB_OTG_DEVICE_DOEPINT2	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPINT2 $00000080 
        \ %x  6 lshift USB_OTG_DEVICE_DOEPINT2        \ USB_OTG_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DOEPINT2        \ USB_OTG_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DOEPINT2        \ USB_OTG_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DOEPINT2        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DOEPINT2        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $368 + constant USB_OTG_DEVICE_DOEPINT3	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPINT3 $00000080 
        \ %x  6 lshift USB_OTG_DEVICE_DOEPINT3        \ USB_OTG_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USB_OTG_DEVICE_DOEPINT3        \ USB_OTG_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_OTG_DEVICE_DOEPINT3        \ USB_OTG_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_OTG_DEVICE_DOEPINT3        \ USB_OTG_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_OTG_DEVICE_DOEPINT3        \ USB_OTG_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        USB_OTG_DEVICE $110 + constant USB_OTG_DEVICE_DIEPTSIZ0	\ read-write		\  : RESET_USB_OTG_DEVICE_DIEPTSIZ0 $00000000 
        \ %xx  19 lshift USB_OTG_DEVICE_DIEPTSIZ0        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:2
        \ %xxxxxxx  0 lshift USB_OTG_DEVICE_DIEPTSIZ0        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:7
        
        USB_OTG_DEVICE $310 + constant USB_OTG_DEVICE_DOEPTSIZ0	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPTSIZ0 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DOEPTSIZ0        \ USB_OTG_DEVICE_STUPCNT	Bit Offset:29	Bit Width:2
        \ %x  19 lshift USB_OTG_DEVICE_DOEPTSIZ0        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:1
        \ %xxxxxxx  0 lshift USB_OTG_DEVICE_DOEPTSIZ0        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:7
        
        USB_OTG_DEVICE $130 + constant USB_OTG_DEVICE_DIEPTSIZ1	\ read-write		\  : RESET_USB_OTG_DEVICE_DIEPTSIZ1 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DIEPTSIZ1        \ USB_OTG_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift USB_OTG_DEVICE_DIEPTSIZ1        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift USB_OTG_DEVICE_DIEPTSIZ1        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        USB_OTG_DEVICE $150 + constant USB_OTG_DEVICE_DIEPTSIZ2	\ read-write		\  : RESET_USB_OTG_DEVICE_DIEPTSIZ2 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DIEPTSIZ2        \ USB_OTG_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift USB_OTG_DEVICE_DIEPTSIZ2        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift USB_OTG_DEVICE_DIEPTSIZ2        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        USB_OTG_DEVICE $170 + constant USB_OTG_DEVICE_DIEPTSIZ3	\ read-write		\  : RESET_USB_OTG_DEVICE_DIEPTSIZ3 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DIEPTSIZ3        \ USB_OTG_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift USB_OTG_DEVICE_DIEPTSIZ3        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift USB_OTG_DEVICE_DIEPTSIZ3        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        USB_OTG_DEVICE $118 + constant USB_OTG_DEVICE_DTXFSTS0	\ read-only		\  : RESET_USB_OTG_DEVICE_DTXFSTS0 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DTXFSTS0        \ USB_OTG_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        USB_OTG_DEVICE $138 + constant USB_OTG_DEVICE_DTXFSTS1	\ read-only		\  : RESET_USB_OTG_DEVICE_DTXFSTS1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DTXFSTS1        \ USB_OTG_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        USB_OTG_DEVICE $158 + constant USB_OTG_DEVICE_DTXFSTS2	\ read-only		\  : RESET_USB_OTG_DEVICE_DTXFSTS2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DTXFSTS2        \ USB_OTG_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        USB_OTG_DEVICE $178 + constant USB_OTG_DEVICE_DTXFSTS3	\ read-only		\  : RESET_USB_OTG_DEVICE_DTXFSTS3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift USB_OTG_DEVICE_DTXFSTS3        \ USB_OTG_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        USB_OTG_DEVICE $330 + constant USB_OTG_DEVICE_DOEPTSIZ1	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPTSIZ1 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DOEPTSIZ1        \ USB_OTG_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift USB_OTG_DEVICE_DOEPTSIZ1        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift USB_OTG_DEVICE_DOEPTSIZ1        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        USB_OTG_DEVICE $350 + constant USB_OTG_DEVICE_DOEPTSIZ2	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPTSIZ2 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DOEPTSIZ2        \ USB_OTG_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift USB_OTG_DEVICE_DOEPTSIZ2        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift USB_OTG_DEVICE_DOEPTSIZ2        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        USB_OTG_DEVICE $370 + constant USB_OTG_DEVICE_DOEPTSIZ3	\ read-write		\  : RESET_USB_OTG_DEVICE_DOEPTSIZ3 $00000000 
        \ %xx  29 lshift USB_OTG_DEVICE_DOEPTSIZ3        \ USB_OTG_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift USB_OTG_DEVICE_DOEPTSIZ3        \ USB_OTG_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift USB_OTG_DEVICE_DOEPTSIZ3        \ USB_OTG_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
         
	
     $50000E00 constant USB_OTG_PWRCLK  
	 USB_OTG_PWRCLK $0 + constant USB_OTG_PWRCLK_FS_PCGCCTL	\ read-write		\  : RESET_USB_OTG_PWRCLK_FS_PCGCCTL $00000000 
        \ %x  0 lshift USB_OTG_PWRCLK_FS_PCGCCTL        \ USB_OTG_PWRCLK_STPPCLK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_OTG_PWRCLK_FS_PCGCCTL        \ USB_OTG_PWRCLK_GATEHCLK	Bit Offset:1	Bit Width:1
        \ %x  4 lshift USB_OTG_PWRCLK_FS_PCGCCTL        \ USB_OTG_PWRCLK_PHYSUSP	Bit Offset:4	Bit Width:1
        
         
	
     $40007400 constant DAC  
	 DAC $0 + constant DAC_CR	\ read-write		\  : RESET_DAC_CR $00000000 
        \ %x  0 lshift DAC_CR        \ DAC_EN1	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DAC_CR        \ DAC_BOFF1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DAC_CR        \ DAC_TEN1	Bit Offset:2	Bit Width:1
        \ %xxx  3 lshift DAC_CR        \ DAC_TSEL1	Bit Offset:3	Bit Width:3
        \ %xx  6 lshift DAC_CR        \ DAC_WAVE1	Bit Offset:6	Bit Width:2
        \ %xxxx  8 lshift DAC_CR        \ DAC_MAMP1	Bit Offset:8	Bit Width:4
        \ %x  12 lshift DAC_CR        \ DAC_DMAEN1	Bit Offset:12	Bit Width:1
        \ %x  16 lshift DAC_CR        \ DAC_EN2	Bit Offset:16	Bit Width:1
        \ %x  17 lshift DAC_CR        \ DAC_BOFF2	Bit Offset:17	Bit Width:1
        \ %x  18 lshift DAC_CR        \ DAC_TEN2	Bit Offset:18	Bit Width:1
        \ %xxx  19 lshift DAC_CR        \ DAC_TSEL2	Bit Offset:19	Bit Width:3
        \ %xx  22 lshift DAC_CR        \ DAC_WAVE2	Bit Offset:22	Bit Width:2
        \ %xxxx  24 lshift DAC_CR        \ DAC_MAMP2	Bit Offset:24	Bit Width:4
        \ %x  28 lshift DAC_CR        \ DAC_DMAEN2	Bit Offset:28	Bit Width:1
        
        DAC $4 + constant DAC_SWTRIGR	\ write-only		\  : RESET_DAC_SWTRIGR $00000000 
        \ %x  0 lshift DAC_SWTRIGR        \ DAC_SWTRIG1	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DAC_SWTRIGR        \ DAC_SWTRIG2	Bit Offset:1	Bit Width:1
        
        DAC $8 + constant DAC_DHR12R1	\ read-write		\  : RESET_DAC_DHR12R1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DHR12R1        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:12
        
        DAC $C + constant DAC_DHR12L1	\ read-write		\  : RESET_DAC_DHR12L1 $00000000 
        \ %xxxxxxxxxxxx  4 lshift DAC_DHR12L1        \ DAC_DACC1DHR	Bit Offset:4	Bit Width:12
        
        DAC $10 + constant DAC_DHR8R1	\ read-write		\  : RESET_DAC_DHR8R1 $00000000 
        \ %xxxxxxxx  0 lshift DAC_DHR8R1        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:8
        
        DAC $14 + constant DAC_DHR12R2	\ read-write		\  : RESET_DAC_DHR12R2 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DHR12R2        \ DAC_DACC2DHR	Bit Offset:0	Bit Width:12
        
        DAC $18 + constant DAC_DHR12L2	\ read-write		\  : RESET_DAC_DHR12L2 $00000000 
        \ %xxxxxxxxxxxx  4 lshift DAC_DHR12L2        \ DAC_DACC2DHR	Bit Offset:4	Bit Width:12
        
        DAC $1C + constant DAC_DHR8R2	\ read-write		\  : RESET_DAC_DHR8R2 $00000000 
        \ %xxxxxxxx  0 lshift DAC_DHR8R2        \ DAC_DACC2DHR	Bit Offset:0	Bit Width:8
        
        DAC $20 + constant DAC_DHR12RD	\ read-write		\  : RESET_DAC_DHR12RD $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DHR12RD        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:12
        \ %xxxxxxxxxxxx  16 lshift DAC_DHR12RD        \ DAC_DACC2DHR	Bit Offset:16	Bit Width:12
        
        DAC $24 + constant DAC_DHR12LD	\ read-write		\  : RESET_DAC_DHR12LD $00000000 
        \ %xxxxxxxxxxxx  4 lshift DAC_DHR12LD        \ DAC_DACC1DHR	Bit Offset:4	Bit Width:12
        \ %xxxxxxxxxxxx  20 lshift DAC_DHR12LD        \ DAC_DACC2DHR	Bit Offset:20	Bit Width:12
        
        DAC $28 + constant DAC_DHR8RD	\ read-write		\  : RESET_DAC_DHR8RD $00000000 
        \ %xxxxxxxx  0 lshift DAC_DHR8RD        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift DAC_DHR8RD        \ DAC_DACC2DHR	Bit Offset:8	Bit Width:8
        
        DAC $2C + constant DAC_DOR1	\ read-only		\  : RESET_DAC_DOR1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DOR1        \ DAC_DACC1DOR	Bit Offset:0	Bit Width:12
        
        DAC $30 + constant DAC_DOR2	\ read-only		\  : RESET_DAC_DOR2 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DOR2        \ DAC_DACC2DOR	Bit Offset:0	Bit Width:12
        
         
	
     $E0042000 constant DBG  
	 DBG $0 + constant DBG_IDCODE	\ read-only		\  : RESET_DBG_IDCODE $0 
        \ %xxxxxxxxxxxx  0 lshift DBG_IDCODE        \ DBG_DEV_ID	Bit Offset:0	Bit Width:12
        \ %xxxxxxxxxxxxxxxx  16 lshift DBG_IDCODE        \ DBG_REV_ID	Bit Offset:16	Bit Width:16
        
        DBG $4 + constant DBG_CR	\ read-write		\  : RESET_DBG_CR $0 
        \ %x  0 lshift DBG_CR        \ DBG_DBG_SLEEP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DBG_CR        \ DBG_DBG_STOP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DBG_CR        \ DBG_DBG_STANDBY	Bit Offset:2	Bit Width:1
        \ %x  5 lshift DBG_CR        \ DBG_TRACE_IOEN	Bit Offset:5	Bit Width:1
        \ %xx  6 lshift DBG_CR        \ DBG_TRACE_MODE	Bit Offset:6	Bit Width:2
        \ %x  8 lshift DBG_CR        \ DBG_DBG_IWDG_STOP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift DBG_CR        \ DBG_DBG_WWDG_STOP	Bit Offset:9	Bit Width:1
        \ %x  10 lshift DBG_CR        \ DBG_DBG_TIM1_STOP	Bit Offset:10	Bit Width:1
        \ %x  11 lshift DBG_CR        \ DBG_DBG_TIM2_STOP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift DBG_CR        \ DBG_DBG_TIM3_STOP	Bit Offset:12	Bit Width:1
        \ %x  13 lshift DBG_CR        \ DBG_DBG_TIM4_STOP	Bit Offset:13	Bit Width:1
        \ %x  14 lshift DBG_CR        \ DBG_DBG_CAN1_STOP	Bit Offset:14	Bit Width:1
        \ %x  15 lshift DBG_CR        \ DBG_DBG_I2C1_SMBUS_TIMEOUT	Bit Offset:15	Bit Width:1
        \ %x  16 lshift DBG_CR        \ DBG_DBG_I2C2_SMBUS_TIMEOUT	Bit Offset:16	Bit Width:1
        \ %x  18 lshift DBG_CR        \ DBG_DBG_TIM5_STOP	Bit Offset:18	Bit Width:1
        \ %x  19 lshift DBG_CR        \ DBG_DBG_TIM6_STOP	Bit Offset:19	Bit Width:1
        \ %x  20 lshift DBG_CR        \ DBG_DBG_TIM7_STOP	Bit Offset:20	Bit Width:1
        \ %x  21 lshift DBG_CR        \ DBG_DBG_CAN2_STOP	Bit Offset:21	Bit Width:1
        
         
	
     $40004C00 constant UART4  
	 UART4 $0 + constant UART4_SR	\ 		\  : RESET_UART4_SR $0 
        \ %x  0 lshift UART4_SR        \ UART4_PE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift UART4_SR        \ UART4_FE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift UART4_SR        \ UART4_NE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift UART4_SR        \ UART4_ORE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift UART4_SR        \ UART4_IDLE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift UART4_SR        \ UART4_RXNE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift UART4_SR        \ UART4_TC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift UART4_SR        \ UART4_TXE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift UART4_SR        \ UART4_LBD	Bit Offset:8	Bit Width:1
        
        UART4 $4 + constant UART4_DR	\ read-write		\  : RESET_UART4_DR $0 
        \ %xxxxxxxxx  0 lshift UART4_DR        \ UART4_DR	Bit Offset:0	Bit Width:9
        
        UART4 $8 + constant UART4_BRR	\ read-write		\  : RESET_UART4_BRR $0 
        \ %xxxx  0 lshift UART4_BRR        \ UART4_DIV_Fraction	Bit Offset:0	Bit Width:4
        \ %xxxxxxxxxxxx  4 lshift UART4_BRR        \ UART4_DIV_Mantissa	Bit Offset:4	Bit Width:12
        
        UART4 $C + constant UART4_CR1	\ read-write		\  : RESET_UART4_CR1 $0 
        \ %x  0 lshift UART4_CR1        \ UART4_SBK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift UART4_CR1        \ UART4_RWU	Bit Offset:1	Bit Width:1
        \ %x  2 lshift UART4_CR1        \ UART4_RE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift UART4_CR1        \ UART4_TE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift UART4_CR1        \ UART4_IDLEIE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift UART4_CR1        \ UART4_RXNEIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift UART4_CR1        \ UART4_TCIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift UART4_CR1        \ UART4_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift UART4_CR1        \ UART4_PEIE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift UART4_CR1        \ UART4_PS	Bit Offset:9	Bit Width:1
        \ %x  10 lshift UART4_CR1        \ UART4_PCE	Bit Offset:10	Bit Width:1
        \ %x  11 lshift UART4_CR1        \ UART4_WAKE	Bit Offset:11	Bit Width:1
        \ %x  12 lshift UART4_CR1        \ UART4_M	Bit Offset:12	Bit Width:1
        \ %x  13 lshift UART4_CR1        \ UART4_UE	Bit Offset:13	Bit Width:1
        
        UART4 $10 + constant UART4_CR2	\ read-write		\  : RESET_UART4_CR2 $0 
        \ %xxxx  0 lshift UART4_CR2        \ UART4_ADD	Bit Offset:0	Bit Width:4
        \ %x  5 lshift UART4_CR2        \ UART4_LBDL	Bit Offset:5	Bit Width:1
        \ %x  6 lshift UART4_CR2        \ UART4_LBDIE	Bit Offset:6	Bit Width:1
        \ %xx  12 lshift UART4_CR2        \ UART4_STOP	Bit Offset:12	Bit Width:2
        \ %x  14 lshift UART4_CR2        \ UART4_LINEN	Bit Offset:14	Bit Width:1
        
        UART4 $14 + constant UART4_CR3	\ read-write		\  : RESET_UART4_CR3 $0 
        \ %x  0 lshift UART4_CR3        \ UART4_EIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift UART4_CR3        \ UART4_IREN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift UART4_CR3        \ UART4_IRLP	Bit Offset:2	Bit Width:1
        \ %x  3 lshift UART4_CR3        \ UART4_HDSEL	Bit Offset:3	Bit Width:1
        \ %x  6 lshift UART4_CR3        \ UART4_DMAR	Bit Offset:6	Bit Width:1
        \ %x  7 lshift UART4_CR3        \ UART4_DMAT	Bit Offset:7	Bit Width:1
        
         
	
     $40005000 constant UART5  
	 UART5 $0 + constant UART5_SR	\ 		\  : RESET_UART5_SR $0 
        \ %x  0 lshift UART5_SR        \ UART5_PE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift UART5_SR        \ UART5_FE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift UART5_SR        \ UART5_NE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift UART5_SR        \ UART5_ORE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift UART5_SR        \ UART5_IDLE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift UART5_SR        \ UART5_RXNE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift UART5_SR        \ UART5_TC	Bit Offset:6	Bit Width:1
        \ %x  7 lshift UART5_SR        \ UART5_TXE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift UART5_SR        \ UART5_LBD	Bit Offset:8	Bit Width:1
        
        UART5 $4 + constant UART5_DR	\ read-write		\  : RESET_UART5_DR $0 
        \ %xxxxxxxxx  0 lshift UART5_DR        \ UART5_DR	Bit Offset:0	Bit Width:9
        
        UART5 $8 + constant UART5_BRR	\ read-write		\  : RESET_UART5_BRR $0 
        \ %xxxx  0 lshift UART5_BRR        \ UART5_DIV_Fraction	Bit Offset:0	Bit Width:4
        \ %xxxxxxxxxxxx  4 lshift UART5_BRR        \ UART5_DIV_Mantissa	Bit Offset:4	Bit Width:12
        
        UART5 $C + constant UART5_CR1	\ read-write		\  : RESET_UART5_CR1 $0 
        \ %x  0 lshift UART5_CR1        \ UART5_SBK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift UART5_CR1        \ UART5_RWU	Bit Offset:1	Bit Width:1
        \ %x  2 lshift UART5_CR1        \ UART5_RE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift UART5_CR1        \ UART5_TE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift UART5_CR1        \ UART5_IDLEIE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift UART5_CR1        \ UART5_RXNEIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift UART5_CR1        \ UART5_TCIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift UART5_CR1        \ UART5_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift UART5_CR1        \ UART5_PEIE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift UART5_CR1        \ UART5_PS	Bit Offset:9	Bit Width:1
        \ %x  10 lshift UART5_CR1        \ UART5_PCE	Bit Offset:10	Bit Width:1
        \ %x  11 lshift UART5_CR1        \ UART5_WAKE	Bit Offset:11	Bit Width:1
        \ %x  12 lshift UART5_CR1        \ UART5_M	Bit Offset:12	Bit Width:1
        \ %x  13 lshift UART5_CR1        \ UART5_UE	Bit Offset:13	Bit Width:1
        
        UART5 $10 + constant UART5_CR2	\ read-write		\  : RESET_UART5_CR2 $0 
        \ %xxxx  0 lshift UART5_CR2        \ UART5_ADD	Bit Offset:0	Bit Width:4
        \ %x  5 lshift UART5_CR2        \ UART5_LBDL	Bit Offset:5	Bit Width:1
        \ %x  6 lshift UART5_CR2        \ UART5_LBDIE	Bit Offset:6	Bit Width:1
        \ %xx  12 lshift UART5_CR2        \ UART5_STOP	Bit Offset:12	Bit Width:2
        \ %x  14 lshift UART5_CR2        \ UART5_LINEN	Bit Offset:14	Bit Width:1
        
        UART5 $14 + constant UART5_CR3	\ read-write		\  : RESET_UART5_CR3 $0 
        \ %x  0 lshift UART5_CR3        \ UART5_EIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift UART5_CR3        \ UART5_IREN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift UART5_CR3        \ UART5_IRLP	Bit Offset:2	Bit Width:1
        \ %x  3 lshift UART5_CR3        \ UART5_HDSEL	Bit Offset:3	Bit Width:1
        \ %x  7 lshift UART5_CR3        \ UART5_DMAT	Bit Offset:7	Bit Width:1
        
         
	
     $40023000 constant CRC  
	 CRC $0 + constant CRC_DR	\ read-write		\  : RESET_CRC_DR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift CRC_DR        \ CRC_DR	Bit Offset:0	Bit Width:32
        
        CRC $4 + constant CRC_IDR	\ read-write		\  : RESET_CRC_IDR $00000000 
        \ %xxxxxxxx  0 lshift CRC_IDR        \ CRC_IDR	Bit Offset:0	Bit Width:8
        
        CRC $8 + constant CRC_CR	\ write-only		\  : RESET_CRC_CR $00000000 
        \ %x  0 lshift CRC_CR        \ CRC_RESET	Bit Offset:0	Bit Width:1
        
         
	
     $40022000 constant FLASH  
	 FLASH $0 + constant FLASH_ACR	\ 		\  : RESET_FLASH_ACR $00000030 
        \ %xxx  0 lshift FLASH_ACR        \ FLASH_LATENCY	Bit Offset:0	Bit Width:3
        \ %x  3 lshift FLASH_ACR        \ FLASH_HLFCYA	Bit Offset:3	Bit Width:1
        \ %x  4 lshift FLASH_ACR        \ FLASH_PRFTBE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift FLASH_ACR        \ FLASH_PRFTBS	Bit Offset:5	Bit Width:1
        
        FLASH $4 + constant FLASH_KEYR	\ write-only		\  : RESET_FLASH_KEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_KEYR        \ FLASH_KEY	Bit Offset:0	Bit Width:32
        
        FLASH $8 + constant FLASH_OPTKEYR	\ write-only		\  : RESET_FLASH_OPTKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_OPTKEYR        \ FLASH_OPTKEY	Bit Offset:0	Bit Width:32
        
        FLASH $C + constant FLASH_SR	\ 		\  : RESET_FLASH_SR $00000000 
        \ %x  5 lshift FLASH_SR        \ FLASH_EOP	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FLASH_SR        \ FLASH_WRPRTERR	Bit Offset:4	Bit Width:1
        \ %x  2 lshift FLASH_SR        \ FLASH_PGERR	Bit Offset:2	Bit Width:1
        \ %x  0 lshift FLASH_SR        \ FLASH_BSY	Bit Offset:0	Bit Width:1
        
        FLASH $10 + constant FLASH_CR	\ read-write		\  : RESET_FLASH_CR $00000080 
        \ %x  0 lshift FLASH_CR        \ FLASH_PG	Bit Offset:0	Bit Width:1
        \ %x  1 lshift FLASH_CR        \ FLASH_PER	Bit Offset:1	Bit Width:1
        \ %x  2 lshift FLASH_CR        \ FLASH_MER	Bit Offset:2	Bit Width:1
        \ %x  4 lshift FLASH_CR        \ FLASH_OPTPG	Bit Offset:4	Bit Width:1
        \ %x  5 lshift FLASH_CR        \ FLASH_OPTER	Bit Offset:5	Bit Width:1
        \ %x  6 lshift FLASH_CR        \ FLASH_STRT	Bit Offset:6	Bit Width:1
        \ %x  7 lshift FLASH_CR        \ FLASH_LOCK	Bit Offset:7	Bit Width:1
        \ %x  9 lshift FLASH_CR        \ FLASH_OPTWRE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift FLASH_CR        \ FLASH_ERRIE	Bit Offset:10	Bit Width:1
        \ %x  12 lshift FLASH_CR        \ FLASH_EOPIE	Bit Offset:12	Bit Width:1
        
        FLASH $14 + constant FLASH_AR	\ write-only		\  : RESET_FLASH_AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_AR        \ FLASH_FAR	Bit Offset:0	Bit Width:32
        
        FLASH $1C + constant FLASH_OBR	\ read-only		\  : RESET_FLASH_OBR $03FFFFFC 
        \ %x  0 lshift FLASH_OBR        \ FLASH_OPTERR	Bit Offset:0	Bit Width:1
        \ %x  1 lshift FLASH_OBR        \ FLASH_RDPRT	Bit Offset:1	Bit Width:1
        \ %x  2 lshift FLASH_OBR        \ FLASH_WDG_SW	Bit Offset:2	Bit Width:1
        \ %x  3 lshift FLASH_OBR        \ FLASH_nRST_STOP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift FLASH_OBR        \ FLASH_nRST_STDBY	Bit Offset:4	Bit Width:1
        \ %xxxxxxxx  10 lshift FLASH_OBR        \ FLASH_Data0	Bit Offset:10	Bit Width:8
        \ %xxxxxxxx  18 lshift FLASH_OBR        \ FLASH_Data1	Bit Offset:18	Bit Width:8
        
        FLASH $20 + constant FLASH_WRPR	\ read-only		\  : RESET_FLASH_WRPR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_WRPR        \ FLASH_WRP	Bit Offset:0	Bit Width:32
        
         
	
     $E000E000 constant NVIC  
	 NVIC $4 + constant NVIC_ICTR	\ read-only		\  : RESET_NVIC_ICTR $00000000 
        \ %xxxx  0 lshift NVIC_ICTR        \ NVIC_INTLINESNUM	Bit Offset:0	Bit Width:4
        
        NVIC $F00 + constant NVIC_STIR	\ write-only		\  : RESET_NVIC_STIR $00000000 
        \ %xxxxxxxxx  0 lshift NVIC_STIR        \ NVIC_INTID	Bit Offset:0	Bit Width:9
        
        NVIC $100 + constant NVIC_ISER0	\ read-write		\  : RESET_NVIC_ISER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER0        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $104 + constant NVIC_ISER1	\ read-write		\  : RESET_NVIC_ISER1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER1        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $108 + constant NVIC_ISER2	\ read-write		\  : RESET_NVIC_ISER2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER2        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $180 + constant NVIC_ICER0	\ read-write		\  : RESET_NVIC_ICER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER0        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $184 + constant NVIC_ICER1	\ read-write		\  : RESET_NVIC_ICER1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER1        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $188 + constant NVIC_ICER2	\ read-write		\  : RESET_NVIC_ICER2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER2        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $200 + constant NVIC_ISPR0	\ read-write		\  : RESET_NVIC_ISPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR0        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $204 + constant NVIC_ISPR1	\ read-write		\  : RESET_NVIC_ISPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR1        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $208 + constant NVIC_ISPR2	\ read-write		\  : RESET_NVIC_ISPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR2        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $280 + constant NVIC_ICPR0	\ read-write		\  : RESET_NVIC_ICPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR0        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $284 + constant NVIC_ICPR1	\ read-write		\  : RESET_NVIC_ICPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR1        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $288 + constant NVIC_ICPR2	\ read-write		\  : RESET_NVIC_ICPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR2        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $300 + constant NVIC_IABR0	\ read-only		\  : RESET_NVIC_IABR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR0        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
        NVIC $304 + constant NVIC_IABR1	\ read-only		\  : RESET_NVIC_IABR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR1        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
        NVIC $308 + constant NVIC_IABR2	\ read-only		\  : RESET_NVIC_IABR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR2        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
        NVIC $400 + constant NVIC_IPR0	\ read-write		\  : RESET_NVIC_IPR0 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR0        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR0        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR0        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR0        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $404 + constant NVIC_IPR1	\ read-write		\  : RESET_NVIC_IPR1 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR1        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR1        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR1        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR1        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $408 + constant NVIC_IPR2	\ read-write		\  : RESET_NVIC_IPR2 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR2        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR2        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR2        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR2        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $40C + constant NVIC_IPR3	\ read-write		\  : RESET_NVIC_IPR3 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR3        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR3        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR3        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR3        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $410 + constant NVIC_IPR4	\ read-write		\  : RESET_NVIC_IPR4 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR4        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR4        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR4        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR4        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $414 + constant NVIC_IPR5	\ read-write		\  : RESET_NVIC_IPR5 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR5        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR5        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR5        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR5        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $418 + constant NVIC_IPR6	\ read-write		\  : RESET_NVIC_IPR6 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR6        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR6        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR6        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR6        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $41C + constant NVIC_IPR7	\ read-write		\  : RESET_NVIC_IPR7 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR7        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR7        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR7        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR7        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $420 + constant NVIC_IPR8	\ read-write		\  : RESET_NVIC_IPR8 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR8        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR8        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR8        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR8        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $424 + constant NVIC_IPR9	\ read-write		\  : RESET_NVIC_IPR9 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR9        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR9        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR9        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR9        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $428 + constant NVIC_IPR10	\ read-write		\  : RESET_NVIC_IPR10 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR10        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR10        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR10        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR10        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $42C + constant NVIC_IPR11	\ read-write		\  : RESET_NVIC_IPR11 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR11        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR11        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR11        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR11        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $430 + constant NVIC_IPR12	\ read-write		\  : RESET_NVIC_IPR12 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR12        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR12        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR12        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR12        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $434 + constant NVIC_IPR13	\ read-write		\  : RESET_NVIC_IPR13 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR13        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR13        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR13        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR13        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $438 + constant NVIC_IPR14	\ read-write		\  : RESET_NVIC_IPR14 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR14        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR14        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR14        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR14        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $43C + constant NVIC_IPR15	\ read-write		\  : RESET_NVIC_IPR15 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR15        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR15        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR15        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR15        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $440 + constant NVIC_IPR16	\ read-write		\  : RESET_NVIC_IPR16 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR16        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR16        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR16        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR16        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
         
	
     