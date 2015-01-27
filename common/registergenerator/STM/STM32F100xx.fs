$A0000000 constant FSMC  
       FSMC $0 + constant FSMC_BCR1
       FSMC $4 + constant FSMC_BTR1
       FSMC $8 + constant FSMC_BCR2
       FSMC $C + constant FSMC_BTR2
       FSMC $10 + constant FSMC_BCR3
       FSMC $14 + constant FSMC_BTR3
       FSMC $18 + constant FSMC_BCR4
       FSMC $1C + constant FSMC_BTR4
       FSMC $104 + constant FSMC_BWTR1
       FSMC $10C + constant FSMC_BWTR2
       FSMC $114 + constant FSMC_BWTR3
       FSMC $11C + constant FSMC_BWTR4
        
	
     $40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
     $40021000 constant RCC  
       RCC $0 + constant RCC_CR
       RCC $4 + constant RCC_CFGR
       RCC $8 + constant RCC_CIR
       RCC $C + constant RCC_APB2RSTR
       RCC $10 + constant RCC_APB1RSTR
       RCC $14 + constant RCC_AHBENR
       RCC $18 + constant RCC_APB2ENR
       RCC $1C + constant RCC_APB1ENR
       RCC $20 + constant RCC_BDCR
       RCC $24 + constant RCC_CSR
       RCC $2C + constant RCC_CFGR2
        
	
     $40010800 constant GPIOA  
       GPIOA $0 + constant GPIOA_CRL
       GPIOA $4 + constant GPIOA_CRH
       GPIOA $8 + constant GPIOA_IDR
       GPIOA $C + constant GPIOA_ODR
       GPIOA $10 + constant GPIOA_BSRR
       GPIOA $14 + constant GPIOA_BRR
       GPIOA $18 + constant GPIOA_LCKR
        
	
     $40010C00 constant GPIOB  
        
	
     $40011000 constant GPIOC  
        
	
     $40011400 constant GPIOD  
        
	
     $40011800 constant GPIOE  
        
	
     $40011C00 constant GPIOF  
        
	
     $40012000 constant GPIOG  
        
	
     $40010000 constant AFIO  
       AFIO $0 + constant AFIO_EVCR
       AFIO $4 + constant AFIO_MAPR
       AFIO $8 + constant AFIO_EXTICR1
       AFIO $C + constant AFIO_EXTICR2
       AFIO $10 + constant AFIO_EXTICR3
       AFIO $14 + constant AFIO_EXTICR4
       AFIO $1C + constant AFIO_MAPR2
        
	
     $40010400 constant EXTI  
       EXTI $0 + constant EXTI_IMR
       EXTI $4 + constant EXTI_EMR
       EXTI $8 + constant EXTI_RTSR
       EXTI $C + constant EXTI_FTSR
       EXTI $10 + constant EXTI_SWIER
       EXTI $14 + constant EXTI_PR
        
	
     $40020000 constant DMA1  
       DMA1 $0 + constant DMA1_ISR
       DMA1 $4 + constant DMA1_IFCR
       DMA1 $8 + constant DMA1_CCR1
       DMA1 $C + constant DMA1_CNDTR1
       DMA1 $10 + constant DMA1_CPAR1
       DMA1 $14 + constant DMA1_CMAR1
       DMA1 $1C + constant DMA1_CCR2
       DMA1 $20 + constant DMA1_CNDTR2
       DMA1 $24 + constant DMA1_CPAR2
       DMA1 $28 + constant DMA1_CMAR2
       DMA1 $30 + constant DMA1_CCR3
       DMA1 $34 + constant DMA1_CNDTR3
       DMA1 $38 + constant DMA1_CPAR3
       DMA1 $3C + constant DMA1_CMAR3
       DMA1 $44 + constant DMA1_CCR4
       DMA1 $48 + constant DMA1_CNDTR4
       DMA1 $4C + constant DMA1_CPAR4
       DMA1 $50 + constant DMA1_CMAR4
       DMA1 $58 + constant DMA1_CCR5
       DMA1 $5C + constant DMA1_CNDTR5
       DMA1 $60 + constant DMA1_CPAR5
       DMA1 $64 + constant DMA1_CMAR5
       DMA1 $6C + constant DMA1_CCR6
       DMA1 $70 + constant DMA1_CNDTR6
       DMA1 $74 + constant DMA1_CPAR6
       DMA1 $78 + constant DMA1_CMAR6
       DMA1 $80 + constant DMA1_CCR7
       DMA1 $84 + constant DMA1_CNDTR7
       DMA1 $88 + constant DMA1_CPAR7
       DMA1 $8C + constant DMA1_CMAR7
        
	
     $40020400 constant DMA2  
        
	
     $40002800 constant RTC  
       RTC $0 + constant RTC_CRH
       RTC $4 + constant RTC_CRL
       RTC $8 + constant RTC_PRLH
       RTC $C + constant RTC_PRLL
       RTC $10 + constant RTC_DIVH
       RTC $14 + constant RTC_DIVL
       RTC $18 + constant RTC_CNTH
       RTC $1C + constant RTC_CNTL
       RTC $20 + constant RTC_ALRH
       RTC $24 + constant RTC_ALRL
        
	
     $40006C04 constant BKP  
       BKP $0 + constant BKP_DR1
       BKP $4 + constant BKP_DR2
       BKP $8 + constant BKP_DR3
       BKP $C + constant BKP_DR4
       BKP $10 + constant BKP_DR5
       BKP $14 + constant BKP_DR6
       BKP $18 + constant BKP_DR7
       BKP $1C + constant BKP_DR8
       BKP $20 + constant BKP_DR9
       BKP $24 + constant BKP_DR10
       BKP $3C + constant BKP_DR11
       BKP $40 + constant BKP_DR12
       BKP $44 + constant BKP_DR13
       BKP $48 + constant BKP_DR14
       BKP $4C + constant BKP_DR15
       BKP $50 + constant BKP_DR16
       BKP $54 + constant BKP_DR17
       BKP $58 + constant BKP_DR18
       BKP $5C + constant BKP_DR19
       BKP $60 + constant BKP_DR20
       BKP $64 + constant BKP_DR21
       BKP $68 + constant BKP_DR22
       BKP $6C + constant BKP_DR23
       BKP $70 + constant BKP_DR24
       BKP $74 + constant BKP_DR25
       BKP $78 + constant BKP_DR26
       BKP $7C + constant BKP_DR27
       BKP $80 + constant BKP_DR28
       BKP $84 + constant BKP_DR29
       BKP $88 + constant BKP_DR30
       BKP $8C + constant BKP_DR31
       BKP $90 + constant BKP_DR32
       BKP $94 + constant BKP_DR33
       BKP $98 + constant BKP_DR34
       BKP $9C + constant BKP_DR35
       BKP $A0 + constant BKP_DR36
       BKP $A4 + constant BKP_DR37
       BKP $A8 + constant BKP_DR38
       BKP $AC + constant BKP_DR39
       BKP $B0 + constant BKP_DR40
       BKP $B4 + constant BKP_DR41
       BKP $B8 + constant BKP_DR42
       BKP $28 + constant BKP_RTCCR
       BKP $2C + constant BKP_CR
       BKP $30 + constant BKP_CSR
        
	
     $40003000 constant IWDG  
       IWDG $0 + constant IWDG_KR
       IWDG $4 + constant IWDG_PR
       IWDG $8 + constant IWDG_RLR
       IWDG $C + constant IWDG_SR
        
	
     $40002C00 constant WWDG  
       WWDG $0 + constant WWDG_CR
       WWDG $4 + constant WWDG_CFR
       WWDG $8 + constant WWDG_SR
        
	
     $40012C00 constant TIM1  
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
        
	
     $40000400 constant TIM3  
        
	
     $40000800 constant TIM4  
        
	
     $40000C00 constant TIM5  
        
	
     $40001800 constant TIM12  
       TIM12 $0 + constant TIM12_CR1
       TIM12 $4 + constant TIM12_CR2
       TIM12 $8 + constant TIM12_SMCR
       TIM12 $C + constant TIM12_DIER
       TIM12 $10 + constant TIM12_SR
       TIM12 $14 + constant TIM12_EGR
       TIM12 $18 + constant TIM12_CCMR1_Output
       TIM12 $18 + constant TIM12_CCMR1_Input
       TIM12 $20 + constant TIM12_CCER
       TIM12 $24 + constant TIM12_CNT
       TIM12 $28 + constant TIM12_PSC
       TIM12 $2C + constant TIM12_ARR
       TIM12 $34 + constant TIM12_CCR1
       TIM12 $38 + constant TIM12_CCR2
        
	
     $40001C00 constant TIM13  
       TIM13 $0 + constant TIM13_CR1
       TIM13 $C + constant TIM13_DIER
       TIM13 $10 + constant TIM13_SR
       TIM13 $14 + constant TIM13_EGR
       TIM13 $18 + constant TIM13_CCMR1_Output
       TIM13 $18 + constant TIM13_CCMR1_Input
       TIM13 $20 + constant TIM13_CCER
       TIM13 $24 + constant TIM13_CNT
       TIM13 $28 + constant TIM13_PSC
       TIM13 $2C + constant TIM13_ARR
       TIM13 $34 + constant TIM13_CCR1
        
	
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
        
	
     $40005400 constant I2C1  
       I2C1 $0 + constant I2C1_CR1
       I2C1 $4 + constant I2C1_CR2
       I2C1 $8 + constant I2C1_OAR1
       I2C1 $C + constant I2C1_OAR2
       I2C1 $10 + constant I2C1_DR
       I2C1 $14 + constant I2C1_SR1
       I2C1 $18 + constant I2C1_SR2
       I2C1 $1C + constant I2C1_CCR
       I2C1 $20 + constant I2C1_TRISE
        
	
     $40005800 constant I2C2  
        
	
     $40013000 constant SPI1  
       SPI1 $0 + constant SPI1_CR1
       SPI1 $4 + constant SPI1_CR2
       SPI1 $8 + constant SPI1_SR
       SPI1 $C + constant SPI1_DR
       SPI1 $10 + constant SPI1_CRCPR
       SPI1 $14 + constant SPI1_RXCRCR
       SPI1 $18 + constant SPI1_TXCRCR
        
	
     $40003800 constant SPI2  
        
	
     $40003C00 constant SPI3  
        
	
     $40013800 constant USART1  
       USART1 $0 + constant USART1_SR
       USART1 $4 + constant USART1_DR
       USART1 $8 + constant USART1_BRR
       USART1 $C + constant USART1_CR1
       USART1 $10 + constant USART1_CR2
       USART1 $14 + constant USART1_CR3
       USART1 $18 + constant USART1_GTPR
        
	
     $40004400 constant USART2  
        
	
     $40004800 constant USART3  
        
	
     $40012400 constant ADC1  
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
        
	
     $E0042000 constant DBG  
       DBG $0 + constant DBG_IDCODE
       DBG $4 + constant DBG_CR
        
	
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
        
	
     $40023000 constant CRC  
       CRC $0 + constant CRC_DR
       CRC $4 + constant CRC_IDR
       CRC $8 + constant CRC_CR
        
	
     $40022000 constant FLASH  
       FLASH $0 + constant FLASH_ACR
       FLASH $4 + constant FLASH_KEYR
       FLASH $8 + constant FLASH_OPTKEYR
       FLASH $C + constant FLASH_SR
       FLASH $10 + constant FLASH_CR
       FLASH $14 + constant FLASH_AR
       FLASH $1C + constant FLASH_OBR
       FLASH $20 + constant FLASH_WRPR
        
	
     $40014000 constant TIM15  
       TIM15 $0 + constant TIM15_CR1
       TIM15 $4 + constant TIM15_CR2
       TIM15 $8 + constant TIM15_SMCR
       TIM15 $C + constant TIM15_DIER
       TIM15 $10 + constant TIM15_SR
       TIM15 $14 + constant TIM15_EGR
       TIM15 $18 + constant TIM15_CCMR1_Output
       TIM15 $18 + constant TIM15_CCMR1_Input
       TIM15 $20 + constant TIM15_CCER
       TIM15 $24 + constant TIM15_CNT
       TIM15 $28 + constant TIM15_PSC
       TIM15 $2C + constant TIM15_ARR
       TIM15 $30 + constant TIM15_RCR
       TIM15 $34 + constant TIM15_CCR1
       TIM15 $38 + constant TIM15_CCR2
       TIM15 $44 + constant TIM15_BDTR
       TIM15 $48 + constant TIM15_DCR
       TIM15 $4C + constant TIM15_DMAR
        
	
     $40014400 constant TIM16  
       TIM16 $0 + constant TIM16_CR1
       TIM16 $4 + constant TIM16_CR2
       TIM16 $C + constant TIM16_DIER
       TIM16 $10 + constant TIM16_SR
       TIM16 $14 + constant TIM16_EGR
       TIM16 $18 + constant TIM16_CCMR1_Output
       TIM16 $18 + constant TIM16_CCMR1_Input
       TIM16 $20 + constant TIM16_CCER
       TIM16 $24 + constant TIM16_CNT
       TIM16 $28 + constant TIM16_PSC
       TIM16 $2C + constant TIM16_ARR
       TIM16 $30 + constant TIM16_RCR
       TIM16 $34 + constant TIM16_CCR1
       TIM16 $44 + constant TIM16_BDTR
       TIM16 $48 + constant TIM16_DCR
       TIM16 $4C + constant TIM16_DMAR
        
	
     $40014800 constant TIM17  
        
	
     $40007800 constant CEC  
       CEC $0 + constant CEC_CFGR
       CEC $4 + constant CEC_OAR
       CEC $8 + constant CEC_PRES
       CEC $C + constant CEC_ESR
       CEC $10 + constant CEC_CSR
       CEC $14 + constant CEC_TXD
       CEC $18 + constant CEC_RXD
        
	
     $E000E000 constant NVIC  
       NVIC $4 + constant NVIC_ICTR
       NVIC $F00 + constant NVIC_STIR
       NVIC $100 + constant NVIC_ISER0
       NVIC $104 + constant NVIC_ISER1
       NVIC $180 + constant NVIC_ICER0
       NVIC $184 + constant NVIC_ICER1
       NVIC $200 + constant NVIC_ISPR0
       NVIC $204 + constant NVIC_ISPR1
       NVIC $280 + constant NVIC_ICPR0
       NVIC $284 + constant NVIC_ICPR1
       NVIC $300 + constant NVIC_IABR0
       NVIC $304 + constant NVIC_IABR1
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
        
	
     