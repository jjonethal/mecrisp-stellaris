$48000000 constant GPIOA  
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
       GPIOA $28 + constant GPIOA_BRR
        
	
     $48000400 constant GPIOB  
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
       GPIOB $28 + constant GPIOB_BRR
        
	
     $48000C00 constant GPIOD  
        
	
     $48000800 constant GPIOC  
       GPIOC $0 + constant GPIOC_MODER
       GPIOC $4 + constant GPIOC_OTYPER
       GPIOC $8 + constant GPIOC_OSPEEDR
       GPIOC $C + constant GPIOC_PUPDR
       GPIOC $10 + constant GPIOC_IDR
       GPIOC $14 + constant GPIOC_ODR
       GPIOC $18 + constant GPIOC_BSRR
       GPIOC $20 + constant GPIOC_AFRL
       GPIOC $24 + constant GPIOC_AFRH
       GPIOC $28 + constant GPIOC_BRR
        
	
     $48001000 constant GPIOE  
        
	
     $48001400 constant GPIOF  
        
	
     $40024000 constant TSC  
       TSC $0 + constant TSC_CR
       TSC $4 + constant TSC_IER
       TSC $8 + constant TSC_ICR
       TSC $C + constant TSC_ISR
       TSC $10 + constant TSC_IOHCR
       TSC $18 + constant TSC_IOASCR
       TSC $20 + constant TSC_IOSCR
       TSC $28 + constant TSC_IOCCR
       TSC $30 + constant TSC_IOGCSR
       TSC $34 + constant TSC_IOG1CR
       TSC $38 + constant TSC_IOG2CR
       TSC $3C + constant TSC_IOG3CR
       TSC $40 + constant TSC_IOG4CR
       TSC $44 + constant TSC_IOG5CR
       TSC $48 + constant TSC_IOG6CR
       TSC $4C + constant TSC_IOG7CR
       TSC $50 + constant TSC_IOG8CR
        
	
     $40023000 constant CRC  
       CRC $0 + constant CRC_DR
       CRC $4 + constant CRC_IDR
       CRC $8 + constant CRC_CR
       CRC $10 + constant CRC_INIT
       CRC $14 + constant CRC_POL
        
	
     $40022000 constant Flash  
       Flash $0 + constant Flash_ACR
       Flash $4 + constant Flash_KEYR
       Flash $8 + constant Flash_OPTKEYR
       Flash $C + constant Flash_SR
       Flash $10 + constant Flash_CR
       Flash $14 + constant Flash_AR
       Flash $1C + constant Flash_OBR
       Flash $20 + constant Flash_WRPR
        
	
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
       RCC $28 + constant RCC_AHBRSTR
       RCC $2C + constant RCC_CFGR2
       RCC $30 + constant RCC_CFGR3
        
	
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
       TIM2 $50 + constant TIM2_OR
        
	
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
       TIM5 $50 + constant TIM5_OR
        
	
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
        
	
     $40015C00 constant TIM19  
        
	
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
        
	
     $40013800 constant USART1  
       USART1 $0 + constant USART1_CR1
       USART1 $4 + constant USART1_CR2
       USART1 $8 + constant USART1_CR3
       USART1 $C + constant USART1_BRR
       USART1 $10 + constant USART1_GTPR
       USART1 $14 + constant USART1_RTOR
       USART1 $18 + constant USART1_RQR
       USART1 $1C + constant USART1_ISR
       USART1 $20 + constant USART1_ICR
       USART1 $24 + constant USART1_RDR
       USART1 $28 + constant USART1_TDR
        
	
     $40004400 constant USART2  
        
	
     $40004800 constant USART3  
        
	
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
        
	
     $40003800 constant SPI2  
        
	
     $40003C00 constant SPI3  
        
	
     $40003400 constant I2S2ext  
        
	
     $40004000 constant I2S3ext  
        
	
     $40012400 constant ADC  
       ADC $0 + constant ADC_SR
       ADC $4 + constant ADC_CR1
       ADC $8 + constant ADC_CR2
       ADC $C + constant ADC_SMPR1
       ADC $10 + constant ADC_SMPR2
       ADC $14 + constant ADC_JOFR1
       ADC $18 + constant ADC_JOFR2
       ADC $1C + constant ADC_JOFR3
       ADC $20 + constant ADC_JOFR4
       ADC $24 + constant ADC_HTR
       ADC $28 + constant ADC_LTR
       ADC $2C + constant ADC_SQR1
       ADC $30 + constant ADC_SQR2
       ADC $34 + constant ADC_SQR3
       ADC $38 + constant ADC_JSQR
       ADC $3C + constant ADC_JDR1
       ADC $40 + constant ADC_JDR2
       ADC $44 + constant ADC_JDR3
       ADC $48 + constant ADC_JDR4
       ADC $4C + constant ADC_DR
        
	
     $40010400 constant EXTI  
       EXTI $0 + constant EXTI_IMR
       EXTI $4 + constant EXTI_EMR
       EXTI $8 + constant EXTI_RTSR
       EXTI $C + constant EXTI_FTSR
       EXTI $10 + constant EXTI_SWIER
       EXTI $14 + constant EXTI_PR
        
	
     $40010000 constant SYSCFG  
       SYSCFG $0 + constant SYSCFG_CFGR1
       SYSCFG $8 + constant SYSCFG_EXTICR1
       SYSCFG $C + constant SYSCFG_EXTICR2
       SYSCFG $10 + constant SYSCFG_EXTICR3
       SYSCFG $14 + constant SYSCFG_EXTICR4
       SYSCFG $18 + constant SYSCFG_CFGR2
        
	
     $40007C00 constant COMP  
       COMP $1C + constant COMP_CSR
        
	
     $40007800 constant CEC  
       CEC $0 + constant CEC_CR
       CEC $4 + constant CEC_CFGR
       CEC $8 + constant CEC_TXDR
       CEC $C + constant CEC_RXDR
       CEC $10 + constant CEC_ISR
       CEC $14 + constant CEC_IER
        
	
     $40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
     $40006400 constant CAN  
       CAN $0 + constant CAN_MCR
       CAN $4 + constant CAN_MSR
       CAN $8 + constant CAN_TSR
       CAN $C + constant CAN_RF0R
       CAN $10 + constant CAN_RF1R
       CAN $14 + constant CAN_IER
       CAN $18 + constant CAN_ESR
       CAN $1C + constant CAN_BTR
       CAN $180 + constant CAN_TI0R
       CAN $184 + constant CAN_TDT0R
       CAN $188 + constant CAN_TDL0R
       CAN $18C + constant CAN_TDH0R
       CAN $190 + constant CAN_TI1R
       CAN $194 + constant CAN_TDT1R
       CAN $198 + constant CAN_TDL1R
       CAN $19C + constant CAN_TDH1R
       CAN $1A0 + constant CAN_TI2R
       CAN $1A4 + constant CAN_TDT2R
       CAN $1A8 + constant CAN_TDL2R
       CAN $1AC + constant CAN_TDH2R
       CAN $1B0 + constant CAN_RI0R
       CAN $1B4 + constant CAN_RDT0R
       CAN $1B8 + constant CAN_RDL0R
       CAN $1BC + constant CAN_RDH0R
       CAN $1C0 + constant CAN_RI1R
       CAN $1C4 + constant CAN_RDT1R
       CAN $1C8 + constant CAN_RDL1R
       CAN $1CC + constant CAN_RDH1R
       CAN $200 + constant CAN_FMR
       CAN $204 + constant CAN_FM1R
       CAN $20C + constant CAN_FS1R
       CAN $214 + constant CAN_FFA1R
       CAN $21C + constant CAN_FA1R
       CAN $240 + constant CAN_F0R1
       CAN $244 + constant CAN_F0R2
       CAN $248 + constant CAN_F1R1
       CAN $24C + constant CAN_F1R2
       CAN $250 + constant CAN_F2R1
       CAN $254 + constant CAN_F2R2
       CAN $258 + constant CAN_F3R1
       CAN $25C + constant CAN_F3R2
       CAN $260 + constant CAN_F4R1
       CAN $264 + constant CAN_F4R2
       CAN $268 + constant CAN_F5R1
       CAN $26C + constant CAN_F5R2
       CAN $270 + constant CAN_F6R1
       CAN $274 + constant CAN_F6R2
       CAN $278 + constant CAN_F7R1
       CAN $27C + constant CAN_F7R2
       CAN $280 + constant CAN_F8R1
       CAN $284 + constant CAN_F8R2
       CAN $288 + constant CAN_F9R1
       CAN $28C + constant CAN_F9R2
       CAN $290 + constant CAN_F10R1
       CAN $294 + constant CAN_F10R2
       CAN $298 + constant CAN_F11R1
       CAN $29C + constant CAN_F11R2
       CAN $2A0 + constant CAN_F12R1
       CAN $2A4 + constant CAN_F12R2
       CAN $2A8 + constant CAN_F13R1
       CAN $2AC + constant CAN_F13R2
       CAN $2B0 + constant CAN_F14R1
       CAN $2B4 + constant CAN_F14R2
       CAN $2B8 + constant CAN_F15R1
       CAN $2BC + constant CAN_F15R2
       CAN $2C0 + constant CAN_F16R1
       CAN $2C4 + constant CAN_F16R2
       CAN $2C8 + constant CAN_F17R1
       CAN $2CC + constant CAN_F17R2
       CAN $2D0 + constant CAN_F18R1
       CAN $2D4 + constant CAN_F18R2
       CAN $2D8 + constant CAN_F19R1
       CAN $2DC + constant CAN_F19R2
       CAN $2E0 + constant CAN_F20R1
       CAN $2E4 + constant CAN_F20R2
       CAN $2E8 + constant CAN_F21R1
       CAN $2EC + constant CAN_F21R2
       CAN $2F0 + constant CAN_F22R1
       CAN $2F4 + constant CAN_F22R2
       CAN $2F8 + constant CAN_F23R1
       CAN $2FC + constant CAN_F23R2
       CAN $300 + constant CAN_F24R1
       CAN $304 + constant CAN_F24R2
       CAN $308 + constant CAN_F25R1
       CAN $30C + constant CAN_F25R2
       CAN $310 + constant CAN_F26R1
       CAN $314 + constant CAN_F26R2
       CAN $318 + constant CAN_F27R1
       CAN $31C + constant CAN_F27R2
        
	
     $40005C00 constant USB  
       USB $0 + constant USB_USB_EP0R
       USB $4 + constant USB_USB_EP1R
       USB $8 + constant USB_USB_EP2R
       USB $C + constant USB_USB_EP3R
       USB $10 + constant USB_USB_EP4R
       USB $14 + constant USB_USB_EP5R
       USB $18 + constant USB_USB_EP6R
       USB $1C + constant USB_USB_EP7R
       USB $40 + constant USB_USB_CNTR
       USB $44 + constant USB_ISTR
       USB $48 + constant USB_FNR
       USB $4C + constant USB_DADDR
       USB $50 + constant USB_BTABLE
        
	
     $40005400 constant I2C1  
       I2C1 $0 + constant I2C1_CR1
       I2C1 $4 + constant I2C1_CR2
       I2C1 $8 + constant I2C1_OAR1
       I2C1 $C + constant I2C1_OAR2
       I2C1 $10 + constant I2C1_TIMINGR
       I2C1 $14 + constant I2C1_TIMEOUTR
       I2C1 $18 + constant I2C1_ISR
       I2C1 $1C + constant I2C1_ICR
       I2C1 $20 + constant I2C1_PECR
       I2C1 $24 + constant I2C1_RXDR
       I2C1 $28 + constant I2C1_TXDR
        
	
     $40005800 constant I2C2  
        
	
     $40003000 constant IWDG  
       IWDG $0 + constant IWDG_KR
       IWDG $4 + constant IWDG_PR
       IWDG $8 + constant IWDG_RLR
       IWDG $C + constant IWDG_SR
       IWDG $10 + constant IWDG_WINR
        
	
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
       RTC $1C + constant RTC_ALRMAR
       RTC $20 + constant RTC_ALRMBR
       RTC $24 + constant RTC_WPR
       RTC $28 + constant RTC_SSR
       RTC $2C + constant RTC_SHIFTR
       RTC $30 + constant RTC_TSTR
       RTC $34 + constant RTC_TSDR
       RTC $38 + constant RTC_TSSSR
       RTC $3C + constant RTC_CALR
       RTC $40 + constant RTC_TAFCR
       RTC $44 + constant RTC_ALRMASSR
       RTC $48 + constant RTC_ALRMBSSR
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
       RTC $A0 + constant RTC_BKP20R
       RTC $A4 + constant RTC_BKP21R
       RTC $A8 + constant RTC_BKP22R
       RTC $AC + constant RTC_BKP23R
       RTC $B0 + constant RTC_BKP24R
       RTC $B4 + constant RTC_BKP25R
       RTC $B8 + constant RTC_BKP26R
       RTC $BC + constant RTC_BKP27R
       RTC $C0 + constant RTC_BKP28R
       RTC $C4 + constant RTC_BKP29R
       RTC $C8 + constant RTC_BKP30R
       RTC $CC + constant RTC_BKP31R
        
	
     $40016000 constant SDADC1  
       SDADC1 $0 + constant SDADC1_CR1
       SDADC1 $4 + constant SDADC1_CR2
       SDADC1 $8 + constant SDADC1_ISR
       SDADC1 $C + constant SDADC1_CLRISR
       SDADC1 $14 + constant SDADC1_JCHGR
       SDADC1 $20 + constant SDADC1_CONF0R
       SDADC1 $24 + constant SDADC1_CONF1R
       SDADC1 $28 + constant SDADC1_CONF2R
       SDADC1 $40 + constant SDADC1_CONFCHR1
       SDADC1 $44 + constant SDADC1_CONFCHR2
       SDADC1 $60 + constant SDADC1_JDATAR
       SDADC1 $64 + constant SDADC1_RDATAR
       SDADC1 $70 + constant SDADC1_JDATA12R
       SDADC1 $74 + constant SDADC1_RDATA12R
       SDADC1 $78 + constant SDADC1_JDATA13R
       SDADC1 $7C + constant SDADC1_RDATA13R
        
	
     $40016400 constant SDADC2  
        
	
     $40016800 constant SDADC3  
        
	
     $40009800 constant DAC2  
       DAC2 $0 + constant DAC2_CR
       DAC2 $4 + constant DAC2_SWTRIGR
       DAC2 $8 + constant DAC2_DHR12R1
       DAC2 $C + constant DAC2_DHR12L1
       DAC2 $10 + constant DAC2_DHR8R1
       DAC2 $2C + constant DAC2_DOR1
       DAC2 $34 + constant DAC2_SR
        
	
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
        
	
     $40009C00 constant TIM18  
        
	
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
        
	
     $40001800 constant TIM12  
       TIM12 $0 + constant TIM12_CR1
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
        
	
     $40007400 constant DAC1  
       DAC1 $0 + constant DAC1_CR
       DAC1 $4 + constant DAC1_SWTRIGR
       DAC1 $8 + constant DAC1_DHR12R1
       DAC1 $C + constant DAC1_DHR12L1
       DAC1 $10 + constant DAC1_DHR8R1
       DAC1 $14 + constant DAC1_DHR12R2
       DAC1 $18 + constant DAC1_DHR12L2
       DAC1 $1C + constant DAC1_DHR8R2
       DAC1 $20 + constant DAC1_DHR12RD
       DAC1 $24 + constant DAC1_DHR12LD
       DAC1 $28 + constant DAC1_DHR8RD
       DAC1 $2C + constant DAC1_DOR1
       DAC1 $30 + constant DAC1_DOR2
       DAC1 $34 + constant DAC1_SR
        
	
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
        
	
     $E000EB88 constant FPU  
       FPU $0 + constant FPU_FPSCR
        
	
     $E0042000 constant DBGMCU  
       DBGMCU $0 + constant DBGMCU_IDCODE
       DBGMCU $4 + constant DBGMCU_CR
       DBGMCU $8 + constant DBGMCU_APB1FZ
       DBGMCU $C + constant DBGMCU_APB2FZ
        
	
     