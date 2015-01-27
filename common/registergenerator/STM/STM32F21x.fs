$50060800 constant RNG  
       RNG $0 + constant RNG_CR
       RNG $4 + constant RNG_SR
       RNG $8 + constant RNG_DR
        
	
     $40023000 constant CRC  
       CRC $0 + constant CRC_DR
       CRC $4 + constant CRC_IDR
       CRC $8 + constant CRC_CR
        
	
     $50050000 constant DCMI  
       DCMI $0 + constant DCMI_CR
       DCMI $4 + constant DCMI_SR
       DCMI $8 + constant DCMI_RIS
       DCMI $C + constant DCMI_IER
       DCMI $10 + constant DCMI_MIS
       DCMI $14 + constant DCMI_ICR
       DCMI $18 + constant DCMI_ESCR
       DCMI $1C + constant DCMI_ESUR
       DCMI $20 + constant DCMI_CWSTRT
       DCMI $24 + constant DCMI_CWSIZE
       DCMI $28 + constant DCMI_DR
        
	
     $A0000000 constant FSMC  
       FSMC $0 + constant FSMC_BCR1
       FSMC $4 + constant FSMC_BTR1
       FSMC $8 + constant FSMC_BCR2
       FSMC $C + constant FSMC_BTR2
       FSMC $10 + constant FSMC_BCR3
       FSMC $14 + constant FSMC_BTR3
       FSMC $18 + constant FSMC_BCR4
       FSMC $1C + constant FSMC_BTR4
       FSMC $60 + constant FSMC_PCR2
       FSMC $64 + constant FSMC_SR2
       FSMC $68 + constant FSMC_PMEM2
       FSMC $6C + constant FSMC_PATT2
       FSMC $74 + constant FSMC_ECCR2
       FSMC $80 + constant FSMC_PCR3
       FSMC $84 + constant FSMC_SR3
       FSMC $88 + constant FSMC_PMEM3
       FSMC $8C + constant FSMC_PATT3
       FSMC $94 + constant FSMC_ECCR3
       FSMC $A0 + constant FSMC_PCR4
       FSMC $A4 + constant FSMC_SR4
       FSMC $A8 + constant FSMC_PMEM4
       FSMC $AC + constant FSMC_PATT4
       FSMC $B0 + constant FSMC_PIO4
       FSMC $104 + constant FSMC_BWTR1
       FSMC $10C + constant FSMC_BWTR2
       FSMC $114 + constant FSMC_BWTR3
       FSMC $11C + constant FSMC_BWTR4
        
	
     $E0042000 constant DBG  
       DBG $0 + constant DBG_DBGMCU_IDCODE
       DBG $4 + constant DBG_DBGMCU_CR
       DBG $8 + constant DBG_DBGMCU_APB1_FZ
       DBG $C + constant DBG_DBGMCU_APB2_FZ
        
	
     $40026400 constant DMA2  
       DMA2 $0 + constant DMA2_LISR
       DMA2 $4 + constant DMA2_HISR
       DMA2 $8 + constant DMA2_LIFCR
       DMA2 $C + constant DMA2_HIFCR
       DMA2 $10 + constant DMA2_S0CR
       DMA2 $14 + constant DMA2_S0NDTR
       DMA2 $18 + constant DMA2_S0PAR
       DMA2 $1C + constant DMA2_S0M0AR
       DMA2 $20 + constant DMA2_S0M1AR
       DMA2 $24 + constant DMA2_S0FCR
       DMA2 $28 + constant DMA2_S1CR
       DMA2 $2C + constant DMA2_S1NDTR
       DMA2 $30 + constant DMA2_S1PAR
       DMA2 $34 + constant DMA2_S1M0AR
       DMA2 $38 + constant DMA2_S1M1AR
       DMA2 $3C + constant DMA2_S1FCR
       DMA2 $40 + constant DMA2_S2CR
       DMA2 $44 + constant DMA2_S2NDTR
       DMA2 $48 + constant DMA2_S2PAR
       DMA2 $4C + constant DMA2_S2M0AR
       DMA2 $50 + constant DMA2_S2M1AR
       DMA2 $54 + constant DMA2_S2FCR
       DMA2 $58 + constant DMA2_S3CR
       DMA2 $5C + constant DMA2_S3NDTR
       DMA2 $60 + constant DMA2_S3PAR
       DMA2 $64 + constant DMA2_S3M0AR
       DMA2 $68 + constant DMA2_S3M1AR
       DMA2 $6C + constant DMA2_S3FCR
       DMA2 $70 + constant DMA2_S4CR
       DMA2 $74 + constant DMA2_S4NDTR
       DMA2 $78 + constant DMA2_S4PAR
       DMA2 $7C + constant DMA2_S4M0AR
       DMA2 $80 + constant DMA2_S4M1AR
       DMA2 $84 + constant DMA2_S4FCR
       DMA2 $88 + constant DMA2_S5CR
       DMA2 $8C + constant DMA2_S5NDTR
       DMA2 $90 + constant DMA2_S5PAR
       DMA2 $94 + constant DMA2_S5M0AR
       DMA2 $98 + constant DMA2_S5M1AR
       DMA2 $9C + constant DMA2_S5FCR
       DMA2 $A0 + constant DMA2_S6CR
       DMA2 $A4 + constant DMA2_S6NDTR
       DMA2 $A8 + constant DMA2_S6PAR
       DMA2 $AC + constant DMA2_S6M0AR
       DMA2 $B0 + constant DMA2_S6M1AR
       DMA2 $B4 + constant DMA2_S6FCR
       DMA2 $B8 + constant DMA2_S7CR
       DMA2 $BC + constant DMA2_S7NDTR
       DMA2 $C0 + constant DMA2_S7PAR
       DMA2 $C4 + constant DMA2_S7M0AR
       DMA2 $C8 + constant DMA2_S7M1AR
       DMA2 $CC + constant DMA2_S7FCR
        
	
     $40026000 constant DMA1  
        
	
     $40023800 constant RCC  
       RCC $0 + constant RCC_CR
       RCC $4 + constant RCC_PLLCFGR
       RCC $8 + constant RCC_CFGR
       RCC $C + constant RCC_CIR
       RCC $10 + constant RCC_AHB1RSTR
       RCC $14 + constant RCC_AHB2RSTR
       RCC $18 + constant RCC_AHB3RSTR
       RCC $20 + constant RCC_APB1RSTR
       RCC $24 + constant RCC_APB2RSTR
       RCC $30 + constant RCC_AHB1ENR
       RCC $34 + constant RCC_AHB2ENR
       RCC $38 + constant RCC_AHB3ENR
       RCC $40 + constant RCC_APB1ENR
       RCC $44 + constant RCC_APB2ENR
       RCC $50 + constant RCC_AHB1LPENR
       RCC $54 + constant RCC_AHB2LPENR
       RCC $58 + constant RCC_AHB3LPENR
       RCC $60 + constant RCC_APB1LPENR
       RCC $64 + constant RCC_APB2LPENR
       RCC $70 + constant RCC_BDCR
       RCC $74 + constant RCC_CSR
       RCC $80 + constant RCC_SSCGR
       RCC $84 + constant RCC_PLLI2SCFGR
        
	
     $40022000 constant GPIOI  
       GPIOI $0 + constant GPIOI_MODER
       GPIOI $4 + constant GPIOI_OTYPER
       GPIOI $8 + constant GPIOI_OSPEEDR
       GPIOI $C + constant GPIOI_PUPDR
       GPIOI $10 + constant GPIOI_IDR
       GPIOI $14 + constant GPIOI_ODR
       GPIOI $18 + constant GPIOI_BSRR
       GPIOI $1C + constant GPIOI_LCKR
       GPIOI $20 + constant GPIOI_AFRL
       GPIOI $24 + constant GPIOI_AFRH
        
	
     $40021C00 constant GPIOH  
        
	
     $40021800 constant GPIOG  
        
	
     $40021400 constant GPIOF  
        
	
     $40021000 constant GPIOE  
        
	
     $40020C00 constant GPIOD  
        
	
     $40020800 constant GPIOC  
        
	
     $40020400 constant GPIOB  
       GPIOB $0 + constant GPIOB_MODER
       GPIOB $4 + constant GPIOB_OTYPER
       GPIOB $8 + constant GPIOB_OSPEEDR
       GPIOB $C + constant GPIOB_PUPDR
       GPIOB $10 + constant GPIOB_IDR
       GPIOB $14 + constant GPIOB_ODR
       GPIOB $18 + constant GPIOB_BSRR
       GPIOB $1C + constant GPIOB_LCKR
       GPIOB $20 + constant GPIOB_AFRL
       GPIOB $24 + constant GPIOB_AFRH
        
	
     $40020000 constant GPIOA  
       GPIOA $0 + constant GPIOA_MODER
       GPIOA $4 + constant GPIOA_OTYPER
       GPIOA $8 + constant GPIOA_OSPEEDR
       GPIOA $C + constant GPIOA_PUPDR
       GPIOA $10 + constant GPIOA_IDR
       GPIOA $14 + constant GPIOA_ODR
       GPIOA $18 + constant GPIOA_BSRR
       GPIOA $1C + constant GPIOA_LCKR
       GPIOA $20 + constant GPIOA_AFRL
       GPIOA $24 + constant GPIOA_AFRH
        
	
     $40013800 constant SYSCFG  
       SYSCFG $0 + constant SYSCFG_MEMRM
       SYSCFG $4 + constant SYSCFG_PMC
       SYSCFG $8 + constant SYSCFG_EXTICR1
       SYSCFG $C + constant SYSCFG_EXTICR2
       SYSCFG $10 + constant SYSCFG_EXTICR3
       SYSCFG $14 + constant SYSCFG_EXTICR4
       SYSCFG $20 + constant SYSCFG_CMPCR
        
	
     $40013000 constant SPI1  
       SPI1 $0 + constant SPI1_CR1
       SPI1 $4 + constant SPI1_CR2
       SPI1 $8 + constant SPI1_SR
       SPI1 $C + constant SPI1_DR
       SPI1 $10 + constant SPI1_CRCPR
       SPI1 $14 + constant SPI1_RXCRCR
       SPI1 $18 + constant SPI1_TXCRCR
       SPI1 $1C + constant SPI1_I2SCFGR
       SPI1 $20 + constant SPI1_I2SPR
        
	
     $40003C00 constant SPI3  
        
	
     $40003800 constant SPI2  
        
	
     $40012C00 constant SDIO  
       SDIO $0 + constant SDIO_POWER
       SDIO $4 + constant SDIO_CLKCR
       SDIO $8 + constant SDIO_ARG
       SDIO $C + constant SDIO_CMD
       SDIO $10 + constant SDIO_RESPCMD
       SDIO $14 + constant SDIO_RESP1
       SDIO $18 + constant SDIO_RESP2
       SDIO $1C + constant SDIO_RESP3
       SDIO $20 + constant SDIO_RESP4
       SDIO $24 + constant SDIO_DTIMER
       SDIO $28 + constant SDIO_DLEN
       SDIO $2C + constant SDIO_DCTRL
       SDIO $30 + constant SDIO_DCOUNT
       SDIO $34 + constant SDIO_STA
       SDIO $38 + constant SDIO_ICR
       SDIO $3C + constant SDIO_MASK
       SDIO $48 + constant SDIO_FIFOCNT
       SDIO $80 + constant SDIO_FIFO
        
	
     $40012000 constant ADC1  
       ADC1 $0 + constant ADC1_SR
       ADC1 $4 + constant ADC1_CR1
       ADC1 $8 + constant ADC1_CR2
       ADC1 $C + constant ADC1_SMPR1
       ADC1 $10 + constant ADC1_SMPR2
       ADC1 $14 + constant ADC1_JOFR1
       ADC1 $18 + constant ADC1_JOFR2
       ADC1 $1C + constant ADC1_JOFR3
       ADC1 $20 + constant ADC1_JOFR4
       ADC1 $24 + constant ADC1_HTR
       ADC1 $28 + constant ADC1_LTR
       ADC1 $2C + constant ADC1_SQR1
       ADC1 $30 + constant ADC1_SQR2
       ADC1 $34 + constant ADC1_SQR3
       ADC1 $38 + constant ADC1_JSQR
       ADC1 $3C + constant ADC1_JDR1
       ADC1 $40 + constant ADC1_JDR2
       ADC1 $44 + constant ADC1_JDR3
       ADC1 $48 + constant ADC1_JDR4
       ADC1 $4C + constant ADC1_DR
        
	
     $40012100 constant ADC2  
        
	
     $40012200 constant ADC3  
        
	
     $40011400 constant USART6  
       USART6 $0 + constant USART6_SR
       USART6 $4 + constant USART6_DR
       USART6 $8 + constant USART6_BRR
       USART6 $C + constant USART6_CR1
       USART6 $10 + constant USART6_CR2
       USART6 $14 + constant USART6_CR3
       USART6 $18 + constant USART6_GTPR
        
	
     $40011000 constant USART1  
        
	
     $40004400 constant USART2  
        
	
     $40004800 constant USART3  
        
	
     $40007400 constant DAC  
       DAC $0 + constant DAC_CR
       DAC $4 + constant DAC_SWTRIGR
       DAC $8 + constant DAC_DHR12R1
       DAC $C + constant DAC_DHR12L1
       DAC $10 + constant DAC_DHR8R1
       DAC $14 + constant DAC_DHR12R2
       DAC $18 + constant DAC_DHR12L2
       DAC $1C + constant DAC_DHR8R2
       DAC $20 + constant DAC_DHR12RD
       DAC $24 + constant DAC_DHR12LD
       DAC $28 + constant DAC_DHR8RD
       DAC $2C + constant DAC_DOR1
       DAC $30 + constant DAC_DOR2
       DAC $34 + constant DAC_SR
        
	
     $40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
     $40006800 constant CAN2  
       CAN2 $0 + constant CAN2_MCR
       CAN2 $4 + constant CAN2_MSR
       CAN2 $8 + constant CAN2_TSR
       CAN2 $C + constant CAN2_RF0R
       CAN2 $10 + constant CAN2_RF1R
       CAN2 $14 + constant CAN2_IER
       CAN2 $18 + constant CAN2_ESR
       CAN2 $1C + constant CAN2_BTR
       CAN2 $180 + constant CAN2_TI0R
       CAN2 $184 + constant CAN2_TDT0R
       CAN2 $188 + constant CAN2_TDL0R
       CAN2 $18C + constant CAN2_TDH0R
       CAN2 $190 + constant CAN2_TI1R
       CAN2 $194 + constant CAN2_TDT1R
       CAN2 $198 + constant CAN2_TDL1R
       CAN2 $19C + constant CAN2_TDH1R
       CAN2 $1A0 + constant CAN2_TI2R
       CAN2 $1A4 + constant CAN2_TDT2R
       CAN2 $1A8 + constant CAN2_TDL2R
       CAN2 $1AC + constant CAN2_TDH2R
       CAN2 $1B0 + constant CAN2_RI0R
       CAN2 $1B4 + constant CAN2_RDT0R
       CAN2 $1B8 + constant CAN2_RDL0R
       CAN2 $1BC + constant CAN2_RDH0R
       CAN2 $1C0 + constant CAN2_RI1R
       CAN2 $1C4 + constant CAN2_RDT1R
       CAN2 $1C8 + constant CAN2_RDL1R
       CAN2 $1CC + constant CAN2_RDH1R
       CAN2 $200 + constant CAN2_FMR
       CAN2 $204 + constant CAN2_FM1R
       CAN2 $20C + constant CAN2_FS1R
       CAN2 $214 + constant CAN2_FFA1R
       CAN2 $21C + constant CAN2_FA1R
       CAN2 $240 + constant CAN2_F0R1
       CAN2 $244 + constant CAN2_F0R2
       CAN2 $248 + constant CAN2_F1R1
       CAN2 $24C + constant CAN2_F1R2
       CAN2 $250 + constant CAN2_F2R1
       CAN2 $254 + constant CAN2_F2R2
       CAN2 $258 + constant CAN2_F3R1
       CAN2 $25C + constant CAN2_F3R2
       CAN2 $260 + constant CAN2_F4R1
       CAN2 $264 + constant CAN2_F4R2
       CAN2 $268 + constant CAN2_F5R1
       CAN2 $26C + constant CAN2_F5R2
       CAN2 $270 + constant CAN2_F6R1
       CAN2 $274 + constant CAN2_F6R2
       CAN2 $278 + constant CAN2_F7R1
       CAN2 $27C + constant CAN2_F7R2
       CAN2 $280 + constant CAN2_F8R1
       CAN2 $284 + constant CAN2_F8R2
       CAN2 $288 + constant CAN2_F9R1
       CAN2 $28C + constant CAN2_F9R2
       CAN2 $290 + constant CAN2_F10R1
       CAN2 $294 + constant CAN2_F10R2
       CAN2 $298 + constant CAN2_F11R1
       CAN2 $29C + constant CAN2_F11R2
       CAN2 $2A0 + constant CAN2_F12R1
       CAN2 $2A4 + constant CAN2_F12R2
       CAN2 $2A8 + constant CAN2_F13R1
       CAN2 $2AC + constant CAN2_F13R2
       CAN2 $2B0 + constant CAN2_F14R1
       CAN2 $2B4 + constant CAN2_F14R2
       CAN2 $2B8 + constant CAN2_F15R1
       CAN2 $2BC + constant CAN2_F15R2
       CAN2 $2C0 + constant CAN2_F16R1
       CAN2 $2C4 + constant CAN2_F16R2
       CAN2 $2C8 + constant CAN2_F17R1
       CAN2 $2CC + constant CAN2_F17R2
       CAN2 $2D0 + constant CAN2_F18R1
       CAN2 $2D4 + constant CAN2_F18R2
       CAN2 $2D8 + constant CAN2_F19R1
       CAN2 $2DC + constant CAN2_F19R2
       CAN2 $2E0 + constant CAN2_F20R1
       CAN2 $2E4 + constant CAN2_F20R2
       CAN2 $2E8 + constant CAN2_F21R1
       CAN2 $2EC + constant CAN2_F21R2
       CAN2 $2F0 + constant CAN2_F22R1
       CAN2 $2F4 + constant CAN2_F22R2
       CAN2 $2F8 + constant CAN2_F23R1
       CAN2 $2FC + constant CAN2_F23R2
       CAN2 $300 + constant CAN2_F24R1
       CAN2 $304 + constant CAN2_F24R2
       CAN2 $308 + constant CAN2_F25R1
       CAN2 $30C + constant CAN2_F25R2
       CAN2 $310 + constant CAN2_F26R1
       CAN2 $314 + constant CAN2_F26R2
       CAN2 $318 + constant CAN2_F27R1
       CAN2 $31C + constant CAN2_F27R2
        
	
     $40006400 constant CAN1  
        
	
     $40005C00 constant I2C3  
       I2C3 $0 + constant I2C3_CR1
       I2C3 $4 + constant I2C3_CR2
       I2C3 $8 + constant I2C3_OAR1
       I2C3 $C + constant I2C3_OAR2
       I2C3 $10 + constant I2C3_DR
       I2C3 $14 + constant I2C3_SR1
       I2C3 $18 + constant I2C3_SR2
       I2C3 $1C + constant I2C3_CCR
       I2C3 $20 + constant I2C3_TRISE
        
	
     $40005800 constant I2C2  
        
	
     $40005400 constant I2C1  
        
	
     $40003000 constant IWDG  
       IWDG $0 + constant IWDG_KR
       IWDG $4 + constant IWDG_PR
       IWDG $8 + constant IWDG_RLR
       IWDG $C + constant IWDG_SR
        
	
     $40002C00 constant WWDG  
       WWDG $0 + constant WWDG_CR
       WWDG $4 + constant WWDG_CFR
       WWDG $8 + constant WWDG_SR
        
	
     $40002800 constant RTC  
       RTC $0 + constant RTC_TR
       RTC $4 + constant RTC_DR
       RTC $8 + constant RTC_CR
       RTC $C + constant RTC_ISR
       RTC $10 + constant RTC_PRER
       RTC $14 + constant RTC_WUTR
       RTC $18 + constant RTC_CALIBR
       RTC $1C + constant RTC_ALRMAR
       RTC $20 + constant RTC_ALRMBR
       RTC $24 + constant RTC_WPR
       RTC $30 + constant RTC_TSTR
       RTC $34 + constant RTC_TSDR
       RTC $40 + constant RTC_TAFCR
       RTC $50 + constant RTC_BKP0R
       RTC $54 + constant RTC_BKP1R
       RTC $58 + constant RTC_BKP2R
       RTC $5C + constant RTC_BKP3R
       RTC $60 + constant RTC_BKP4R
       RTC $64 + constant RTC_BKP5R
       RTC $68 + constant RTC_BKP6R
       RTC $6C + constant RTC_BKP7R
       RTC $70 + constant RTC_BKP8R
       RTC $74 + constant RTC_BKP9R
       RTC $78 + constant RTC_BKP10R
       RTC $7C + constant RTC_BKP11R
       RTC $80 + constant RTC_BKP12R
       RTC $84 + constant RTC_BKP13R
       RTC $88 + constant RTC_BKP14R
       RTC $8C + constant RTC_BKP15R
       RTC $90 + constant RTC_BKP16R
       RTC $94 + constant RTC_BKP17R
       RTC $98 + constant RTC_BKP18R
       RTC $9C + constant RTC_BKP19R
        
	
     $40004C00 constant UART4  
       UART4 $0 + constant UART4_SR
       UART4 $4 + constant UART4_DR
       UART4 $8 + constant UART4_BRR
       UART4 $C + constant UART4_CR1
       UART4 $10 + constant UART4_CR2
       UART4 $14 + constant UART4_CR3
        
	
     $40005000 constant UART5  
       UART5 $0 + constant UART5_SR
       UART5 $4 + constant UART5_DR
       UART5 $8 + constant UART5_BRR
       UART5 $C + constant UART5_CR1
       UART5 $10 + constant UART5_CR2
       UART5 $14 + constant UART5_CR3
        
	
     $40012300 constant ADC_Common  
       ADC_Common $0 + constant ADC_Common_CSR
       ADC_Common $4 + constant ADC_Common_CCR
       ADC_Common $8 + constant ADC_Common_CDR
        
	
     $40010000 constant TIM1  
       TIM1 $0 + constant TIM1_CR1
       TIM1 $4 + constant TIM1_CR2
       TIM1 $8 + constant TIM1_SMCR
       TIM1 $C + constant TIM1_DIER
       TIM1 $10 + constant TIM1_SR
       TIM1 $14 + constant TIM1_EGR
       TIM1 $18 + constant TIM1_CCMR1_Output
       TIM1 $18 + constant TIM1_CCMR1_Input
       TIM1 $1C + constant TIM1_CCMR2_Output
       TIM1 $1C + constant TIM1_CCMR2_Input
       TIM1 $20 + constant TIM1_CCER
       TIM1 $24 + constant TIM1_CNT
       TIM1 $28 + constant TIM1_PSC
       TIM1 $2C + constant TIM1_ARR
       TIM1 $34 + constant TIM1_CCR1
       TIM1 $38 + constant TIM1_CCR2
       TIM1 $3C + constant TIM1_CCR3
       TIM1 $40 + constant TIM1_CCR4
       TIM1 $48 + constant TIM1_DCR
       TIM1 $4C + constant TIM1_DMAR
       TIM1 $30 + constant TIM1_RCR
       TIM1 $44 + constant TIM1_BDTR
        
	
     $40010400 constant TIM8  
        
	
     $40000000 constant TIM2  
       TIM2 $0 + constant TIM2_CR1
       TIM2 $4 + constant TIM2_CR2
       TIM2 $8 + constant TIM2_SMCR
       TIM2 $C + constant TIM2_DIER
       TIM2 $10 + constant TIM2_SR
       TIM2 $14 + constant TIM2_EGR
       TIM2 $18 + constant TIM2_CCMR1_Output
       TIM2 $18 + constant TIM2_CCMR1_Input
       TIM2 $1C + constant TIM2_CCMR2_Output
       TIM2 $1C + constant TIM2_CCMR2_Input
       TIM2 $20 + constant TIM2_CCER
       TIM2 $24 + constant TIM2_CNT
       TIM2 $28 + constant TIM2_PSC
       TIM2 $2C + constant TIM2_ARR
       TIM2 $34 + constant TIM2_CCR1
       TIM2 $38 + constant TIM2_CCR2
       TIM2 $3C + constant TIM2_CCR3
       TIM2 $40 + constant TIM2_CCR4
       TIM2 $48 + constant TIM2_DCR
       TIM2 $4C + constant TIM2_DMAR
       TIM2 $50 + constant TIM2_TIM2_OR
        
	
     $40000400 constant TIM3  
       TIM3 $0 + constant TIM3_CR1
       TIM3 $4 + constant TIM3_CR2
       TIM3 $8 + constant TIM3_SMCR
       TIM3 $C + constant TIM3_DIER
       TIM3 $10 + constant TIM3_SR
       TIM3 $14 + constant TIM3_EGR
       TIM3 $18 + constant TIM3_CCMR1_Output
       TIM3 $18 + constant TIM3_CCMR1_Input
       TIM3 $1C + constant TIM3_CCMR2_Output
       TIM3 $1C + constant TIM3_CCMR2_Input
       TIM3 $20 + constant TIM3_CCER
       TIM3 $24 + constant TIM3_CNT
       TIM3 $28 + constant TIM3_PSC
       TIM3 $2C + constant TIM3_ARR
       TIM3 $34 + constant TIM3_CCR1
       TIM3 $38 + constant TIM3_CCR2
       TIM3 $3C + constant TIM3_CCR3
       TIM3 $40 + constant TIM3_CCR4
       TIM3 $48 + constant TIM3_DCR
       TIM3 $4C + constant TIM3_DMAR
        
	
     $40000800 constant TIM4  
        
	
     $40000C00 constant TIM5  
       TIM5 $0 + constant TIM5_CR1
       TIM5 $4 + constant TIM5_CR2
       TIM5 $8 + constant TIM5_SMCR
       TIM5 $C + constant TIM5_DIER
       TIM5 $10 + constant TIM5_SR
       TIM5 $14 + constant TIM5_EGR
       TIM5 $18 + constant TIM5_CCMR1_Output
       TIM5 $18 + constant TIM5_CCMR1_Input
       TIM5 $1C + constant TIM5_CCMR2_Output
       TIM5 $1C + constant TIM5_CCMR2_Input
       TIM5 $20 + constant TIM5_CCER
       TIM5 $24 + constant TIM5_CNT
       TIM5 $28 + constant TIM5_PSC
       TIM5 $2C + constant TIM5_ARR
       TIM5 $34 + constant TIM5_CCR1
       TIM5 $38 + constant TIM5_CCR2
       TIM5 $3C + constant TIM5_CCR3
       TIM5 $40 + constant TIM5_CCR4
       TIM5 $48 + constant TIM5_DCR
       TIM5 $4C + constant TIM5_DMAR
       TIM5 $50 + constant TIM5_TIM5_OR
        
	
     $40014000 constant TIM9  
       TIM9 $0 + constant TIM9_CR1
       TIM9 $4 + constant TIM9_CR2
       TIM9 $8 + constant TIM9_SMCR
       TIM9 $C + constant TIM9_DIER
       TIM9 $10 + constant TIM9_SR
       TIM9 $14 + constant TIM9_EGR
       TIM9 $18 + constant TIM9_CCMR1_Output
       TIM9 $18 + constant TIM9_CCMR1_Input
       TIM9 $20 + constant TIM9_CCER
       TIM9 $24 + constant TIM9_CNT
       TIM9 $28 + constant TIM9_PSC
       TIM9 $2C + constant TIM9_ARR
       TIM9 $34 + constant TIM9_CCR1
       TIM9 $38 + constant TIM9_CCR2
        
	
     $40001800 constant TIM12  
        
	
     $40014400 constant TIM10  
       TIM10 $0 + constant TIM10_CR1
       TIM10 $C + constant TIM10_DIER
       TIM10 $10 + constant TIM10_SR
       TIM10 $14 + constant TIM10_EGR
       TIM10 $18 + constant TIM10_CCMR1_Output
       TIM10 $18 + constant TIM10_CCMR1_Input
       TIM10 $20 + constant TIM10_CCER
       TIM10 $24 + constant TIM10_CNT
       TIM10 $28 + constant TIM10_PSC
       TIM10 $2C + constant TIM10_ARR
       TIM10 $34 + constant TIM10_CCR1
       TIM10 $50 + constant TIM10_OR
        
	
     $40014800 constant TIM11  
        
	
     $40001C00 constant TIM13  
        
	
     $40002000 constant TIM14  
        
	
     $40001000 constant TIM6  
       TIM6 $0 + constant TIM6_CR1
       TIM6 $4 + constant TIM6_CR2
       TIM6 $C + constant TIM6_DIER
       TIM6 $10 + constant TIM6_SR
       TIM6 $14 + constant TIM6_EGR
       TIM6 $24 + constant TIM6_CNT
       TIM6 $28 + constant TIM6_PSC
       TIM6 $2C + constant TIM6_ARR
        
	
     $40001400 constant TIM7  
        
	
     $40028000 constant Ethernet_MAC  
       Ethernet_MAC $0 + constant Ethernet_MAC_MACCR
       Ethernet_MAC $4 + constant Ethernet_MAC_MACFFR
       Ethernet_MAC $8 + constant Ethernet_MAC_MACHTHR
       Ethernet_MAC $C + constant Ethernet_MAC_MACHTLR
       Ethernet_MAC $10 + constant Ethernet_MAC_MACMIIAR
       Ethernet_MAC $14 + constant Ethernet_MAC_MACMIIDR
       Ethernet_MAC $18 + constant Ethernet_MAC_MACFCR
       Ethernet_MAC $1C + constant Ethernet_MAC_MACVLANTR
       Ethernet_MAC $2C + constant Ethernet_MAC_MACPMTCSR
       Ethernet_MAC $34 + constant Ethernet_MAC_MACDBGR
       Ethernet_MAC $38 + constant Ethernet_MAC_MACSR
       Ethernet_MAC $3C + constant Ethernet_MAC_MACIMR
       Ethernet_MAC $40 + constant Ethernet_MAC_MACA0HR
       Ethernet_MAC $44 + constant Ethernet_MAC_MACA0LR
       Ethernet_MAC $48 + constant Ethernet_MAC_MACA1HR
       Ethernet_MAC $4C + constant Ethernet_MAC_MACA1LR
       Ethernet_MAC $50 + constant Ethernet_MAC_MACA2HR
       Ethernet_MAC $54 + constant Ethernet_MAC_MACA2LR
       Ethernet_MAC $58 + constant Ethernet_MAC_MACA3HR
       Ethernet_MAC $5C + constant Ethernet_MAC_MACA3LR
       Ethernet_MAC $28 + constant Ethernet_MAC_MACRWUFFR
        
	
     $40028100 constant Ethernet_MMC  
       Ethernet_MMC $0 + constant Ethernet_MMC_MMCCR
       Ethernet_MMC $4 + constant Ethernet_MMC_MMCRIR
       Ethernet_MMC $8 + constant Ethernet_MMC_MMCTIR
       Ethernet_MMC $C + constant Ethernet_MMC_MMCRIMR
       Ethernet_MMC $10 + constant Ethernet_MMC_MMCTIMR
       Ethernet_MMC $4C + constant Ethernet_MMC_MMCTGFSCCR
       Ethernet_MMC $50 + constant Ethernet_MMC_MMCTGFMSCCR
       Ethernet_MMC $68 + constant Ethernet_MMC_MMCTGFCR
       Ethernet_MMC $94 + constant Ethernet_MMC_MMCRFCECR
       Ethernet_MMC $98 + constant Ethernet_MMC_MMCRFAECR
       Ethernet_MMC $C4 + constant Ethernet_MMC_MMCRGUFCR
        
	
     $40028700 constant Ethernet_PTP  
       Ethernet_PTP $0 + constant Ethernet_PTP_PTPTSCR
       Ethernet_PTP $4 + constant Ethernet_PTP_PTPSSIR
       Ethernet_PTP $8 + constant Ethernet_PTP_PTPTSHR
       Ethernet_PTP $C + constant Ethernet_PTP_PTPTSLR
       Ethernet_PTP $10 + constant Ethernet_PTP_PTPTSHUR
       Ethernet_PTP $14 + constant Ethernet_PTP_PTPTSLUR
       Ethernet_PTP $18 + constant Ethernet_PTP_PTPTSAR
       Ethernet_PTP $1C + constant Ethernet_PTP_PTPTTHR
       Ethernet_PTP $20 + constant Ethernet_PTP_PTPTTLR
       Ethernet_PTP $28 + constant Ethernet_PTP_PTPTSSR
       Ethernet_PTP $2C + constant Ethernet_PTP_PTPPPSCR
        
	
     $40029000 constant Ethernet_DMA  
       Ethernet_DMA $0 + constant Ethernet_DMA_DMABMR
       Ethernet_DMA $4 + constant Ethernet_DMA_DMATPDR
       Ethernet_DMA $8 + constant Ethernet_DMA_DMARPDR
       Ethernet_DMA $C + constant Ethernet_DMA_DMARDLAR
       Ethernet_DMA $10 + constant Ethernet_DMA_DMATDLAR
       Ethernet_DMA $14 + constant Ethernet_DMA_DMASR
       Ethernet_DMA $18 + constant Ethernet_DMA_DMAOMR
       Ethernet_DMA $1C + constant Ethernet_DMA_DMAIER
       Ethernet_DMA $20 + constant Ethernet_DMA_DMAMFBOCR
       Ethernet_DMA $24 + constant Ethernet_DMA_DMARSWTR
       Ethernet_DMA $48 + constant Ethernet_DMA_DMACHTDR
       Ethernet_DMA $4C + constant Ethernet_DMA_DMACHRDR
       Ethernet_DMA $50 + constant Ethernet_DMA_DMACHTBAR
       Ethernet_DMA $54 + constant Ethernet_DMA_DMACHRBAR
        
	
     $50000000 constant OTG_FS_GLOBAL  
       OTG_FS_GLOBAL $0 + constant OTG_FS_GLOBAL_FS_GOTGCTL
       OTG_FS_GLOBAL $4 + constant OTG_FS_GLOBAL_FS_GOTGINT
       OTG_FS_GLOBAL $8 + constant OTG_FS_GLOBAL_FS_GAHBCFG
       OTG_FS_GLOBAL $C + constant OTG_FS_GLOBAL_FS_GUSBCFG
       OTG_FS_GLOBAL $10 + constant OTG_FS_GLOBAL_FS_GRSTCTL
       OTG_FS_GLOBAL $14 + constant OTG_FS_GLOBAL_FS_GINTSTS
       OTG_FS_GLOBAL $18 + constant OTG_FS_GLOBAL_FS_GINTMSK
       OTG_FS_GLOBAL $1C + constant OTG_FS_GLOBAL_FS_GRXSTSR_Device
       OTG_FS_GLOBAL $1C + constant OTG_FS_GLOBAL_FS_GRXSTSR_Host
       OTG_FS_GLOBAL $24 + constant OTG_FS_GLOBAL_FS_GRXFSIZ
       OTG_FS_GLOBAL $28 + constant OTG_FS_GLOBAL_FS_GNPTXFSIZ_Device
       OTG_FS_GLOBAL $28 + constant OTG_FS_GLOBAL_FS_GNPTXFSIZ_Host
       OTG_FS_GLOBAL $2C + constant OTG_FS_GLOBAL_FS_GNPTXSTS
       OTG_FS_GLOBAL $38 + constant OTG_FS_GLOBAL_FS_GCCFG
       OTG_FS_GLOBAL $3C + constant OTG_FS_GLOBAL_FS_CID
       OTG_FS_GLOBAL $100 + constant OTG_FS_GLOBAL_FS_HPTXFSIZ
       OTG_FS_GLOBAL $104 + constant OTG_FS_GLOBAL_FS_DIEPTXF1
       OTG_FS_GLOBAL $108 + constant OTG_FS_GLOBAL_FS_DIEPTXF2
       OTG_FS_GLOBAL $10C + constant OTG_FS_GLOBAL_FS_DIEPTXF3
        
	
     $50000400 constant OTG_FS_HOST  
       OTG_FS_HOST $0 + constant OTG_FS_HOST_FS_HCFG
       OTG_FS_HOST $4 + constant OTG_FS_HOST_HFIR
       OTG_FS_HOST $8 + constant OTG_FS_HOST_FS_HFNUM
       OTG_FS_HOST $10 + constant OTG_FS_HOST_FS_HPTXSTS
       OTG_FS_HOST $14 + constant OTG_FS_HOST_HAINT
       OTG_FS_HOST $18 + constant OTG_FS_HOST_HAINTMSK
       OTG_FS_HOST $40 + constant OTG_FS_HOST_FS_HPRT
       OTG_FS_HOST $100 + constant OTG_FS_HOST_FS_HCCHAR0
       OTG_FS_HOST $120 + constant OTG_FS_HOST_FS_HCCHAR1
       OTG_FS_HOST $140 + constant OTG_FS_HOST_FS_HCCHAR2
       OTG_FS_HOST $160 + constant OTG_FS_HOST_FS_HCCHAR3
       OTG_FS_HOST $180 + constant OTG_FS_HOST_FS_HCCHAR4
       OTG_FS_HOST $1A0 + constant OTG_FS_HOST_FS_HCCHAR5
       OTG_FS_HOST $1C0 + constant OTG_FS_HOST_FS_HCCHAR6
       OTG_FS_HOST $1E0 + constant OTG_FS_HOST_FS_HCCHAR7
       OTG_FS_HOST $108 + constant OTG_FS_HOST_FS_HCINT0
       OTG_FS_HOST $128 + constant OTG_FS_HOST_FS_HCINT1
       OTG_FS_HOST $148 + constant OTG_FS_HOST_FS_HCINT2
       OTG_FS_HOST $168 + constant OTG_FS_HOST_FS_HCINT3
       OTG_FS_HOST $188 + constant OTG_FS_HOST_FS_HCINT4
       OTG_FS_HOST $1A8 + constant OTG_FS_HOST_FS_HCINT5
       OTG_FS_HOST $1C8 + constant OTG_FS_HOST_FS_HCINT6
       OTG_FS_HOST $1E8 + constant OTG_FS_HOST_FS_HCINT7
       OTG_FS_HOST $10C + constant OTG_FS_HOST_FS_HCINTMSK0
       OTG_FS_HOST $12C + constant OTG_FS_HOST_FS_HCINTMSK1
       OTG_FS_HOST $14C + constant OTG_FS_HOST_FS_HCINTMSK2
       OTG_FS_HOST $16C + constant OTG_FS_HOST_FS_HCINTMSK3
       OTG_FS_HOST $18C + constant OTG_FS_HOST_FS_HCINTMSK4
       OTG_FS_HOST $1AC + constant OTG_FS_HOST_FS_HCINTMSK5
       OTG_FS_HOST $1CC + constant OTG_FS_HOST_FS_HCINTMSK6
       OTG_FS_HOST $1EC + constant OTG_FS_HOST_FS_HCINTMSK7
       OTG_FS_HOST $110 + constant OTG_FS_HOST_FS_HCTSIZ0
       OTG_FS_HOST $130 + constant OTG_FS_HOST_FS_HCTSIZ1
       OTG_FS_HOST $150 + constant OTG_FS_HOST_FS_HCTSIZ2
       OTG_FS_HOST $170 + constant OTG_FS_HOST_FS_HCTSIZ3
       OTG_FS_HOST $190 + constant OTG_FS_HOST_FS_HCTSIZ4
       OTG_FS_HOST $1B0 + constant OTG_FS_HOST_FS_HCTSIZ5
       OTG_FS_HOST $1D0 + constant OTG_FS_HOST_FS_HCTSIZ6
       OTG_FS_HOST $1F0 + constant OTG_FS_HOST_FS_HCTSIZ7
        
	
     $50000800 constant OTG_FS_DEVICE  
       OTG_FS_DEVICE $0 + constant OTG_FS_DEVICE_FS_DCFG
       OTG_FS_DEVICE $4 + constant OTG_FS_DEVICE_FS_DCTL
       OTG_FS_DEVICE $8 + constant OTG_FS_DEVICE_FS_DSTS
       OTG_FS_DEVICE $10 + constant OTG_FS_DEVICE_FS_DIEPMSK
       OTG_FS_DEVICE $14 + constant OTG_FS_DEVICE_FS_DOEPMSK
       OTG_FS_DEVICE $18 + constant OTG_FS_DEVICE_FS_DAINT
       OTG_FS_DEVICE $1C + constant OTG_FS_DEVICE_FS_DAINTMSK
       OTG_FS_DEVICE $28 + constant OTG_FS_DEVICE_DVBUSDIS
       OTG_FS_DEVICE $2C + constant OTG_FS_DEVICE_DVBUSPULSE
       OTG_FS_DEVICE $34 + constant OTG_FS_DEVICE_DIEPEMPMSK
       OTG_FS_DEVICE $100 + constant OTG_FS_DEVICE_FS_DIEPCTL0
       OTG_FS_DEVICE $120 + constant OTG_FS_DEVICE_DIEPCTL1
       OTG_FS_DEVICE $140 + constant OTG_FS_DEVICE_DIEPCTL2
       OTG_FS_DEVICE $160 + constant OTG_FS_DEVICE_DIEPCTL3
       OTG_FS_DEVICE $300 + constant OTG_FS_DEVICE_DOEPCTL0
       OTG_FS_DEVICE $320 + constant OTG_FS_DEVICE_DOEPCTL1
       OTG_FS_DEVICE $340 + constant OTG_FS_DEVICE_DOEPCTL2
       OTG_FS_DEVICE $360 + constant OTG_FS_DEVICE_DOEPCTL3
       OTG_FS_DEVICE $108 + constant OTG_FS_DEVICE_DIEPINT0
       OTG_FS_DEVICE $128 + constant OTG_FS_DEVICE_DIEPINT1
       OTG_FS_DEVICE $148 + constant OTG_FS_DEVICE_DIEPINT2
       OTG_FS_DEVICE $168 + constant OTG_FS_DEVICE_DIEPINT3
       OTG_FS_DEVICE $308 + constant OTG_FS_DEVICE_DOEPINT0
       OTG_FS_DEVICE $328 + constant OTG_FS_DEVICE_DOEPINT1
       OTG_FS_DEVICE $348 + constant OTG_FS_DEVICE_DOEPINT2
       OTG_FS_DEVICE $368 + constant OTG_FS_DEVICE_DOEPINT3
       OTG_FS_DEVICE $110 + constant OTG_FS_DEVICE_DIEPTSIZ0
       OTG_FS_DEVICE $310 + constant OTG_FS_DEVICE_DOEPTSIZ0
       OTG_FS_DEVICE $130 + constant OTG_FS_DEVICE_DIEPTSIZ1
       OTG_FS_DEVICE $150 + constant OTG_FS_DEVICE_DIEPTSIZ2
       OTG_FS_DEVICE $170 + constant OTG_FS_DEVICE_DIEPTSIZ3
       OTG_FS_DEVICE $118 + constant OTG_FS_DEVICE_DTXFSTS0
       OTG_FS_DEVICE $138 + constant OTG_FS_DEVICE_DTXFSTS1
       OTG_FS_DEVICE $158 + constant OTG_FS_DEVICE_DTXFSTS2
       OTG_FS_DEVICE $178 + constant OTG_FS_DEVICE_DTXFSTS3
       OTG_FS_DEVICE $330 + constant OTG_FS_DEVICE_DOEPTSIZ1
       OTG_FS_DEVICE $350 + constant OTG_FS_DEVICE_DOEPTSIZ2
       OTG_FS_DEVICE $370 + constant OTG_FS_DEVICE_DOEPTSIZ3
        
	
     $50000E00 constant OTG_FS_PWRCLK  
       OTG_FS_PWRCLK $0 + constant OTG_FS_PWRCLK_FS_PCGCCTL
        
	
     $40013C00 constant EXTI  
       EXTI $0 + constant EXTI_IMR
       EXTI $4 + constant EXTI_EMR
       EXTI $8 + constant EXTI_RTSR
       EXTI $C + constant EXTI_FTSR
       EXTI $10 + constant EXTI_SWIER
       EXTI $14 + constant EXTI_PR
        
	
     $40023C00 constant FLASH  
       FLASH $0 + constant FLASH_ACR
       FLASH $4 + constant FLASH_KEYR
       FLASH $8 + constant FLASH_OPTKEYR
       FLASH $C + constant FLASH_SR
       FLASH $10 + constant FLASH_CR
       FLASH $14 + constant FLASH_OPTCR
        
	
     $50060400 constant HASH  
       HASH $0 + constant HASH_CR
       HASH $4 + constant HASH_DIN
       HASH $8 + constant HASH_STR
       HASH $C + constant HASH_HR0
       HASH $10 + constant HASH_HR1
       HASH $14 + constant HASH_HR2
       HASH $18 + constant HASH_HR3
       HASH $1C + constant HASH_HR4
       HASH $20 + constant HASH_IMR
       HASH $24 + constant HASH_SR
       HASH $F8 + constant HASH_CSR0
       HASH $FC + constant HASH_CSR1
       HASH $100 + constant HASH_CSR2
       HASH $104 + constant HASH_CSR3
       HASH $108 + constant HASH_CSR4
       HASH $10C + constant HASH_CSR5
       HASH $110 + constant HASH_CSR6
       HASH $114 + constant HASH_CSR7
       HASH $118 + constant HASH_CSR8
       HASH $11C + constant HASH_CSR9
       HASH $120 + constant HASH_CSR10
       HASH $124 + constant HASH_CSR11
       HASH $128 + constant HASH_CSR12
       HASH $12C + constant HASH_CSR13
       HASH $130 + constant HASH_CSR14
       HASH $134 + constant HASH_CSR15
       HASH $138 + constant HASH_CSR16
       HASH $13C + constant HASH_CSR17
       HASH $140 + constant HASH_CSR18
       HASH $144 + constant HASH_CSR19
       HASH $148 + constant HASH_CSR20
       HASH $14C + constant HASH_CSR21
       HASH $150 + constant HASH_CSR22
       HASH $154 + constant HASH_CSR23
       HASH $158 + constant HASH_CSR24
       HASH $15C + constant HASH_CSR25
       HASH $160 + constant HASH_CSR26
       HASH $164 + constant HASH_CSR27
       HASH $168 + constant HASH_CSR28
       HASH $16C + constant HASH_CSR29
       HASH $170 + constant HASH_CSR30
       HASH $174 + constant HASH_CSR31
       HASH $178 + constant HASH_CSR32
       HASH $17C + constant HASH_CSR33
       HASH $180 + constant HASH_CSR34
       HASH $184 + constant HASH_CSR35
       HASH $188 + constant HASH_CSR36
       HASH $18C + constant HASH_CSR37
       HASH $190 + constant HASH_CSR38
       HASH $194 + constant HASH_CSR39
       HASH $198 + constant HASH_CSR40
       HASH $19C + constant HASH_CSR41
       HASH $1A0 + constant HASH_CSR42
       HASH $1A4 + constant HASH_CSR43
       HASH $1A8 + constant HASH_CSR44
       HASH $1AC + constant HASH_CSR45
       HASH $1B0 + constant HASH_CSR46
       HASH $1B4 + constant HASH_CSR47
       HASH $1B8 + constant HASH_CSR48
       HASH $1BC + constant HASH_CSR49
       HASH $1C0 + constant HASH_CSR50
        
	
     $50060000 constant CRYP  
       CRYP $0 + constant CRYP_CR
       CRYP $4 + constant CRYP_SR
       CRYP $8 + constant CRYP_DIN
       CRYP $C + constant CRYP_DOUT
       CRYP $10 + constant CRYP_DMACR
       CRYP $14 + constant CRYP_IMSCR
       CRYP $18 + constant CRYP_RISR
       CRYP $1C + constant CRYP_MISR
       CRYP $20 + constant CRYP_K0LR
       CRYP $24 + constant CRYP_K0RR
       CRYP $28 + constant CRYP_K1LR
       CRYP $2C + constant CRYP_K1RR
       CRYP $30 + constant CRYP_K2LR
       CRYP $34 + constant CRYP_K2RR
       CRYP $38 + constant CRYP_K3LR
       CRYP $3C + constant CRYP_K3RR
       CRYP $40 + constant CRYP_IV0LR
       CRYP $44 + constant CRYP_IV0RR
       CRYP $48 + constant CRYP_IV1LR
       CRYP $4C + constant CRYP_IV1RR
        
	
     $40040000 constant OTG_HS_GLOBAL  
       OTG_HS_GLOBAL $0 + constant OTG_HS_GLOBAL_OTG_HS_GOTGCTL
       OTG_HS_GLOBAL $4 + constant OTG_HS_GLOBAL_OTG_HS_GOTGINT
       OTG_HS_GLOBAL $8 + constant OTG_HS_GLOBAL_OTG_HS_GAHBCFG
       OTG_HS_GLOBAL $C + constant OTG_HS_GLOBAL_OTG_HS_GUSBCFG
       OTG_HS_GLOBAL $10 + constant OTG_HS_GLOBAL_OTG_HS_GRSTCTL
       OTG_HS_GLOBAL $14 + constant OTG_HS_GLOBAL_OTG_HS_GINTSTS
       OTG_HS_GLOBAL $18 + constant OTG_HS_GLOBAL_OTG_HS_GINTMSK
       OTG_HS_GLOBAL $1C + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host
       OTG_HS_GLOBAL $20 + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host
       OTG_HS_GLOBAL $24 + constant OTG_HS_GLOBAL_OTG_HS_GRXFSIZ
       OTG_HS_GLOBAL $28 + constant OTG_HS_GLOBAL_OTG_HS_GNPTXFSIZ_Host
       OTG_HS_GLOBAL $28 + constant OTG_HS_GLOBAL_OTG_HS_TX0FSIZ_Peripheral
       OTG_HS_GLOBAL $2C + constant OTG_HS_GLOBAL_OTG_HS_GNPTXSTS
       OTG_HS_GLOBAL $38 + constant OTG_HS_GLOBAL_OTG_HS_GCCFG
       OTG_HS_GLOBAL $3C + constant OTG_HS_GLOBAL_OTG_HS_CID
       OTG_HS_GLOBAL $100 + constant OTG_HS_GLOBAL_OTG_HS_HPTXFSIZ
       OTG_HS_GLOBAL $104 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF1
       OTG_HS_GLOBAL $108 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF2
       OTG_HS_GLOBAL $11C + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF3
       OTG_HS_GLOBAL $120 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF4
       OTG_HS_GLOBAL $124 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF5
       OTG_HS_GLOBAL $128 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF6
       OTG_HS_GLOBAL $12C + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF7
       OTG_HS_GLOBAL $1C + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral
       OTG_HS_GLOBAL $20 + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral
        
	
     $40040400 constant OTG_HS_HOST  
       OTG_HS_HOST $0 + constant OTG_HS_HOST_OTG_HS_HCFG
       OTG_HS_HOST $4 + constant OTG_HS_HOST_OTG_HS_HFIR
       OTG_HS_HOST $8 + constant OTG_HS_HOST_OTG_HS_HFNUM
       OTG_HS_HOST $10 + constant OTG_HS_HOST_OTG_HS_HPTXSTS
       OTG_HS_HOST $14 + constant OTG_HS_HOST_OTG_HS_HAINT
       OTG_HS_HOST $18 + constant OTG_HS_HOST_OTG_HS_HAINTMSK
       OTG_HS_HOST $40 + constant OTG_HS_HOST_OTG_HS_HPRT
       OTG_HS_HOST $100 + constant OTG_HS_HOST_OTG_HS_HCCHAR0
       OTG_HS_HOST $120 + constant OTG_HS_HOST_OTG_HS_HCCHAR1
       OTG_HS_HOST $140 + constant OTG_HS_HOST_OTG_HS_HCCHAR2
       OTG_HS_HOST $160 + constant OTG_HS_HOST_OTG_HS_HCCHAR3
       OTG_HS_HOST $180 + constant OTG_HS_HOST_OTG_HS_HCCHAR4
       OTG_HS_HOST $1A0 + constant OTG_HS_HOST_OTG_HS_HCCHAR5
       OTG_HS_HOST $1C0 + constant OTG_HS_HOST_OTG_HS_HCCHAR6
       OTG_HS_HOST $1E0 + constant OTG_HS_HOST_OTG_HS_HCCHAR7
       OTG_HS_HOST $200 + constant OTG_HS_HOST_OTG_HS_HCCHAR8
       OTG_HS_HOST $220 + constant OTG_HS_HOST_OTG_HS_HCCHAR9
       OTG_HS_HOST $240 + constant OTG_HS_HOST_OTG_HS_HCCHAR10
       OTG_HS_HOST $260 + constant OTG_HS_HOST_OTG_HS_HCCHAR11
       OTG_HS_HOST $104 + constant OTG_HS_HOST_OTG_HS_HCSPLT0
       OTG_HS_HOST $124 + constant OTG_HS_HOST_OTG_HS_HCSPLT1
       OTG_HS_HOST $144 + constant OTG_HS_HOST_OTG_HS_HCSPLT2
       OTG_HS_HOST $164 + constant OTG_HS_HOST_OTG_HS_HCSPLT3
       OTG_HS_HOST $184 + constant OTG_HS_HOST_OTG_HS_HCSPLT4
       OTG_HS_HOST $1A4 + constant OTG_HS_HOST_OTG_HS_HCSPLT5
       OTG_HS_HOST $1C4 + constant OTG_HS_HOST_OTG_HS_HCSPLT6
       OTG_HS_HOST $1E4 + constant OTG_HS_HOST_OTG_HS_HCSPLT7
       OTG_HS_HOST $204 + constant OTG_HS_HOST_OTG_HS_HCSPLT8
       OTG_HS_HOST $224 + constant OTG_HS_HOST_OTG_HS_HCSPLT9
       OTG_HS_HOST $244 + constant OTG_HS_HOST_OTG_HS_HCSPLT10
       OTG_HS_HOST $264 + constant OTG_HS_HOST_OTG_HS_HCSPLT11
       OTG_HS_HOST $108 + constant OTG_HS_HOST_OTG_HS_HCINT0
       OTG_HS_HOST $128 + constant OTG_HS_HOST_OTG_HS_HCINT1
       OTG_HS_HOST $148 + constant OTG_HS_HOST_OTG_HS_HCINT2
       OTG_HS_HOST $168 + constant OTG_HS_HOST_OTG_HS_HCINT3
       OTG_HS_HOST $188 + constant OTG_HS_HOST_OTG_HS_HCINT4
       OTG_HS_HOST $1A8 + constant OTG_HS_HOST_OTG_HS_HCINT5
       OTG_HS_HOST $1C8 + constant OTG_HS_HOST_OTG_HS_HCINT6
       OTG_HS_HOST $1E8 + constant OTG_HS_HOST_OTG_HS_HCINT7
       OTG_HS_HOST $208 + constant OTG_HS_HOST_OTG_HS_HCINT8
       OTG_HS_HOST $228 + constant OTG_HS_HOST_OTG_HS_HCINT9
       OTG_HS_HOST $248 + constant OTG_HS_HOST_OTG_HS_HCINT10
       OTG_HS_HOST $268 + constant OTG_HS_HOST_OTG_HS_HCINT11
       OTG_HS_HOST $10C + constant OTG_HS_HOST_OTG_HS_HCINTMSK0
       OTG_HS_HOST $12C + constant OTG_HS_HOST_OTG_HS_HCINTMSK1
       OTG_HS_HOST $14C + constant OTG_HS_HOST_OTG_HS_HCINTMSK2
       OTG_HS_HOST $16C + constant OTG_HS_HOST_OTG_HS_HCINTMSK3
       OTG_HS_HOST $18C + constant OTG_HS_HOST_OTG_HS_HCINTMSK4
       OTG_HS_HOST $1AC + constant OTG_HS_HOST_OTG_HS_HCINTMSK5
       OTG_HS_HOST $1CC + constant OTG_HS_HOST_OTG_HS_HCINTMSK6
       OTG_HS_HOST $1EC + constant OTG_HS_HOST_OTG_HS_HCINTMSK7
       OTG_HS_HOST $20C + constant OTG_HS_HOST_OTG_HS_HCINTMSK8
       OTG_HS_HOST $22C + constant OTG_HS_HOST_OTG_HS_HCINTMSK9
       OTG_HS_HOST $24C + constant OTG_HS_HOST_OTG_HS_HCINTMSK10
       OTG_HS_HOST $26C + constant OTG_HS_HOST_OTG_HS_HCINTMSK11
       OTG_HS_HOST $110 + constant OTG_HS_HOST_OTG_HS_HCTSIZ0
       OTG_HS_HOST $130 + constant OTG_HS_HOST_OTG_HS_HCTSIZ1
       OTG_HS_HOST $150 + constant OTG_HS_HOST_OTG_HS_HCTSIZ2
       OTG_HS_HOST $170 + constant OTG_HS_HOST_OTG_HS_HCTSIZ3
       OTG_HS_HOST $190 + constant OTG_HS_HOST_OTG_HS_HCTSIZ4
       OTG_HS_HOST $1B0 + constant OTG_HS_HOST_OTG_HS_HCTSIZ5
       OTG_HS_HOST $1D0 + constant OTG_HS_HOST_OTG_HS_HCTSIZ6
       OTG_HS_HOST $1F0 + constant OTG_HS_HOST_OTG_HS_HCTSIZ7
       OTG_HS_HOST $210 + constant OTG_HS_HOST_OTG_HS_HCTSIZ8
       OTG_HS_HOST $230 + constant OTG_HS_HOST_OTG_HS_HCTSIZ9
       OTG_HS_HOST $250 + constant OTG_HS_HOST_OTG_HS_HCTSIZ10
       OTG_HS_HOST $270 + constant OTG_HS_HOST_OTG_HS_HCTSIZ11
       OTG_HS_HOST $114 + constant OTG_HS_HOST_OTG_HS_HCDMA0
       OTG_HS_HOST $134 + constant OTG_HS_HOST_OTG_HS_HCDMA1
       OTG_HS_HOST $154 + constant OTG_HS_HOST_OTG_HS_HCDMA2
       OTG_HS_HOST $174 + constant OTG_HS_HOST_OTG_HS_HCDMA3
       OTG_HS_HOST $194 + constant OTG_HS_HOST_OTG_HS_HCDMA4
       OTG_HS_HOST $1B4 + constant OTG_HS_HOST_OTG_HS_HCDMA5
       OTG_HS_HOST $1D4 + constant OTG_HS_HOST_OTG_HS_HCDMA6
       OTG_HS_HOST $1F4 + constant OTG_HS_HOST_OTG_HS_HCDMA7
       OTG_HS_HOST $214 + constant OTG_HS_HOST_OTG_HS_HCDMA8
       OTG_HS_HOST $234 + constant OTG_HS_HOST_OTG_HS_HCDMA9
       OTG_HS_HOST $254 + constant OTG_HS_HOST_OTG_HS_HCDMA10
       OTG_HS_HOST $274 + constant OTG_HS_HOST_OTG_HS_HCDMA11
        
	
     $40040800 constant OTG_HS_DEVICE  
       OTG_HS_DEVICE $0 + constant OTG_HS_DEVICE_OTG_HS_DCFG
       OTG_HS_DEVICE $4 + constant OTG_HS_DEVICE_OTG_HS_DCTL
       OTG_HS_DEVICE $8 + constant OTG_HS_DEVICE_OTG_HS_DSTS
       OTG_HS_DEVICE $10 + constant OTG_HS_DEVICE_OTG_HS_DIEPMSK
       OTG_HS_DEVICE $14 + constant OTG_HS_DEVICE_OTG_HS_DOEPMSK
       OTG_HS_DEVICE $18 + constant OTG_HS_DEVICE_OTG_HS_DAINT
       OTG_HS_DEVICE $1C + constant OTG_HS_DEVICE_OTG_HS_DAINTMSK
       OTG_HS_DEVICE $28 + constant OTG_HS_DEVICE_OTG_HS_DVBUSDIS
       OTG_HS_DEVICE $2C + constant OTG_HS_DEVICE_OTG_HS_DVBUSPULSE
       OTG_HS_DEVICE $30 + constant OTG_HS_DEVICE_OTG_HS_DTHRCTL
       OTG_HS_DEVICE $34 + constant OTG_HS_DEVICE_OTG_HS_DIEPEMPMSK
       OTG_HS_DEVICE $38 + constant OTG_HS_DEVICE_OTG_HS_DEACHINT
       OTG_HS_DEVICE $3C + constant OTG_HS_DEVICE_OTG_HS_DEACHINTMSK
       OTG_HS_DEVICE $40 + constant OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1
       OTG_HS_DEVICE $80 + constant OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1
       OTG_HS_DEVICE $100 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL0
       OTG_HS_DEVICE $120 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL1
       OTG_HS_DEVICE $140 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL2
       OTG_HS_DEVICE $160 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL3
       OTG_HS_DEVICE $180 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL4
       OTG_HS_DEVICE $1A0 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL5
       OTG_HS_DEVICE $1C0 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL6
       OTG_HS_DEVICE $1E0 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL7
       OTG_HS_DEVICE $108 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT0
       OTG_HS_DEVICE $128 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT1
       OTG_HS_DEVICE $148 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT2
       OTG_HS_DEVICE $168 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT3
       OTG_HS_DEVICE $188 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT4
       OTG_HS_DEVICE $1A8 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT5
       OTG_HS_DEVICE $1C8 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT6
       OTG_HS_DEVICE $1E8 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT7
       OTG_HS_DEVICE $110 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ0
       OTG_HS_DEVICE $114 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA1
       OTG_HS_DEVICE $134 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA2
       OTG_HS_DEVICE $154 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA3
       OTG_HS_DEVICE $174 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA4
       OTG_HS_DEVICE $194 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA5
       OTG_HS_DEVICE $118 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS0
       OTG_HS_DEVICE $138 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS1
       OTG_HS_DEVICE $158 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS2
       OTG_HS_DEVICE $178 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS3
       OTG_HS_DEVICE $198 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS4
       OTG_HS_DEVICE $1B8 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS5
       OTG_HS_DEVICE $130 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ1
       OTG_HS_DEVICE $150 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ2
       OTG_HS_DEVICE $170 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ3
       OTG_HS_DEVICE $190 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ4
       OTG_HS_DEVICE $1B0 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ5
       OTG_HS_DEVICE $300 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL0
       OTG_HS_DEVICE $320 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL1
       OTG_HS_DEVICE $340 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL2
       OTG_HS_DEVICE $360 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL3
       OTG_HS_DEVICE $308 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT0
       OTG_HS_DEVICE $328 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT1
       OTG_HS_DEVICE $348 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT2
       OTG_HS_DEVICE $368 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT3
       OTG_HS_DEVICE $388 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT4
       OTG_HS_DEVICE $3A8 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT5
       OTG_HS_DEVICE $3C8 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT6
       OTG_HS_DEVICE $3E8 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT7
       OTG_HS_DEVICE $310 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ0
       OTG_HS_DEVICE $330 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ1
       OTG_HS_DEVICE $350 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ2
       OTG_HS_DEVICE $370 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ3
       OTG_HS_DEVICE $390 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ4
        
	
     $40040E00 constant OTG_HS_PWRCLK  
       OTG_HS_PWRCLK $0 + constant OTG_HS_PWRCLK_OTG_HS_PCGCR
        
	
     $E000E000 constant NVIC  
       NVIC $4 + constant NVIC_ICTR
       NVIC $F00 + constant NVIC_STIR
       NVIC $100 + constant NVIC_ISER0
       NVIC $104 + constant NVIC_ISER1
       NVIC $108 + constant NVIC_ISER2
       NVIC $180 + constant NVIC_ICER0
       NVIC $184 + constant NVIC_ICER1
       NVIC $188 + constant NVIC_ICER2
       NVIC $200 + constant NVIC_ISPR0
       NVIC $204 + constant NVIC_ISPR1
       NVIC $208 + constant NVIC_ISPR2
       NVIC $280 + constant NVIC_ICPR0
       NVIC $284 + constant NVIC_ICPR1
       NVIC $288 + constant NVIC_ICPR2
       NVIC $300 + constant NVIC_IABR0
       NVIC $304 + constant NVIC_IABR1
       NVIC $308 + constant NVIC_IABR2
       NVIC $400 + constant NVIC_IPR0
       NVIC $404 + constant NVIC_IPR1
       NVIC $408 + constant NVIC_IPR2
       NVIC $40C + constant NVIC_IPR3
       NVIC $410 + constant NVIC_IPR4
       NVIC $414 + constant NVIC_IPR5
       NVIC $418 + constant NVIC_IPR6
       NVIC $41C + constant NVIC_IPR7
       NVIC $420 + constant NVIC_IPR8
       NVIC $424 + constant NVIC_IPR9
       NVIC $428 + constant NVIC_IPR10
       NVIC $42C + constant NVIC_IPR11
       NVIC $430 + constant NVIC_IPR12
       NVIC $434 + constant NVIC_IPR13
       NVIC $438 + constant NVIC_IPR14
       NVIC $43C + constant NVIC_IPR15
       NVIC $440 + constant NVIC_IPR16
       NVIC $444 + constant NVIC_IPR17
       NVIC $448 + constant NVIC_IPR18
       NVIC $44C + constant NVIC_IPR19
       NVIC $450 + constant NVIC_IPR20
        
	
     