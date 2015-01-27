$40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
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
       SPI1 $1C + constant SPI1_I2SCFGR
       SPI1 $20 + constant SPI1_I2SPR
        
	
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
        
	
     $40012800 constant ADC2  
       ADC2 $0 + constant ADC2_SR
       ADC2 $4 + constant ADC2_CR1
       ADC2 $8 + constant ADC2_CR2
       ADC2 $C + constant ADC2_SMPR1
       ADC2 $10 + constant ADC2_SMPR2
       ADC2 $14 + constant ADC2_JOFR1
       ADC2 $18 + constant ADC2_JOFR2
       ADC2 $1C + constant ADC2_JOFR3
       ADC2 $20 + constant ADC2_JOFR4
       ADC2 $24 + constant ADC2_HTR
       ADC2 $28 + constant ADC2_LTR
       ADC2 $2C + constant ADC2_SQR1
       ADC2 $30 + constant ADC2_SQR2
       ADC2 $34 + constant ADC2_SQR3
       ADC2 $38 + constant ADC2_JSQR
       ADC2 $3C + constant ADC2_JDR1
       ADC2 $40 + constant ADC2_JDR2
       ADC2 $44 + constant ADC2_JDR3
       ADC2 $48 + constant ADC2_JDR4
       ADC2 $4C + constant ADC2_DR
        
	
     $40006800 constant CAN2  
       CAN2 $0 + constant CAN2_CAN_MCR
       CAN2 $4 + constant CAN2_CAN_MSR
       CAN2 $8 + constant CAN2_CAN_TSR
       CAN2 $C + constant CAN2_CAN_RF0R
       CAN2 $10 + constant CAN2_CAN_RF1R
       CAN2 $14 + constant CAN2_CAN_IER
       CAN2 $18 + constant CAN2_CAN_ESR
       CAN2 $1C + constant CAN2_CAN_BTR
       CAN2 $180 + constant CAN2_CAN_TI0R
       CAN2 $184 + constant CAN2_CAN_TDT0R
       CAN2 $188 + constant CAN2_CAN_TDL0R
       CAN2 $18C + constant CAN2_CAN_TDH0R
       CAN2 $190 + constant CAN2_CAN_TI1R
       CAN2 $194 + constant CAN2_CAN_TDT1R
       CAN2 $198 + constant CAN2_CAN_TDL1R
       CAN2 $19C + constant CAN2_CAN_TDH1R
       CAN2 $1A0 + constant CAN2_CAN_TI2R
       CAN2 $1A4 + constant CAN2_CAN_TDT2R
       CAN2 $1A8 + constant CAN2_CAN_TDL2R
       CAN2 $1AC + constant CAN2_CAN_TDH2R
       CAN2 $1B0 + constant CAN2_CAN_RI0R
       CAN2 $1B4 + constant CAN2_CAN_RDT0R
       CAN2 $1B8 + constant CAN2_CAN_RDL0R
       CAN2 $1BC + constant CAN2_CAN_RDH0R
       CAN2 $1C0 + constant CAN2_CAN_RI1R
       CAN2 $1C4 + constant CAN2_CAN_RDT1R
       CAN2 $1C8 + constant CAN2_CAN_RDL1R
       CAN2 $1CC + constant CAN2_CAN_RDH1R
       CAN2 $200 + constant CAN2_CAN_FMR
       CAN2 $204 + constant CAN2_CAN_FM1R
       CAN2 $20C + constant CAN2_CAN_FS1R
       CAN2 $214 + constant CAN2_CAN_FFA1R
       CAN2 $21C + constant CAN2_CAN_FA1R
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
        
	
     $50000000 constant USB_OTG_GLOBAL  
       USB_OTG_GLOBAL $0 + constant USB_OTG_GLOBAL_FS_GOTGCTL
       USB_OTG_GLOBAL $4 + constant USB_OTG_GLOBAL_FS_GOTGINT
       USB_OTG_GLOBAL $8 + constant USB_OTG_GLOBAL_FS_GAHBCFG
       USB_OTG_GLOBAL $C + constant USB_OTG_GLOBAL_FS_GUSBCFG
       USB_OTG_GLOBAL $10 + constant USB_OTG_GLOBAL_FS_GRSTCTL
       USB_OTG_GLOBAL $14 + constant USB_OTG_GLOBAL_FS_GINTSTS
       USB_OTG_GLOBAL $18 + constant USB_OTG_GLOBAL_FS_GINTMSK
       USB_OTG_GLOBAL $1C + constant USB_OTG_GLOBAL_FS_GRXSTSR_Device
       USB_OTG_GLOBAL $1C + constant USB_OTG_GLOBAL_FS_GRXSTSR_Host
       USB_OTG_GLOBAL $24 + constant USB_OTG_GLOBAL_FS_GRXFSIZ
       USB_OTG_GLOBAL $28 + constant USB_OTG_GLOBAL_FS_GNPTXFSIZ_Device
       USB_OTG_GLOBAL $28 + constant USB_OTG_GLOBAL_FS_GNPTXFSIZ_Host
       USB_OTG_GLOBAL $2C + constant USB_OTG_GLOBAL_FS_GNPTXSTS
       USB_OTG_GLOBAL $38 + constant USB_OTG_GLOBAL_FS_GCCFG
       USB_OTG_GLOBAL $3C + constant USB_OTG_GLOBAL_FS_CID
       USB_OTG_GLOBAL $100 + constant USB_OTG_GLOBAL_FS_HPTXFSIZ
       USB_OTG_GLOBAL $104 + constant USB_OTG_GLOBAL_FS_DIEPTXF1
       USB_OTG_GLOBAL $108 + constant USB_OTG_GLOBAL_FS_DIEPTXF2
       USB_OTG_GLOBAL $10C + constant USB_OTG_GLOBAL_FS_DIEPTXF3
        
	
     $50000400 constant USB_OTG_HOST  
       USB_OTG_HOST $0 + constant USB_OTG_HOST_FS_HCFG
       USB_OTG_HOST $4 + constant USB_OTG_HOST_HFIR
       USB_OTG_HOST $8 + constant USB_OTG_HOST_FS_HFNUM
       USB_OTG_HOST $10 + constant USB_OTG_HOST_FS_HPTXSTS
       USB_OTG_HOST $14 + constant USB_OTG_HOST_HAINT
       USB_OTG_HOST $18 + constant USB_OTG_HOST_HAINTMSK
       USB_OTG_HOST $40 + constant USB_OTG_HOST_FS_HPRT
       USB_OTG_HOST $100 + constant USB_OTG_HOST_FS_HCCHAR0
       USB_OTG_HOST $120 + constant USB_OTG_HOST_FS_HCCHAR1
       USB_OTG_HOST $140 + constant USB_OTG_HOST_FS_HCCHAR2
       USB_OTG_HOST $160 + constant USB_OTG_HOST_FS_HCCHAR3
       USB_OTG_HOST $180 + constant USB_OTG_HOST_FS_HCCHAR4
       USB_OTG_HOST $1A0 + constant USB_OTG_HOST_FS_HCCHAR5
       USB_OTG_HOST $1C0 + constant USB_OTG_HOST_FS_HCCHAR6
       USB_OTG_HOST $1E0 + constant USB_OTG_HOST_FS_HCCHAR7
       USB_OTG_HOST $108 + constant USB_OTG_HOST_FS_HCINT0
       USB_OTG_HOST $128 + constant USB_OTG_HOST_FS_HCINT1
       USB_OTG_HOST $148 + constant USB_OTG_HOST_FS_HCINT2
       USB_OTG_HOST $168 + constant USB_OTG_HOST_FS_HCINT3
       USB_OTG_HOST $188 + constant USB_OTG_HOST_FS_HCINT4
       USB_OTG_HOST $1A8 + constant USB_OTG_HOST_FS_HCINT5
       USB_OTG_HOST $1C8 + constant USB_OTG_HOST_FS_HCINT6
       USB_OTG_HOST $1E8 + constant USB_OTG_HOST_FS_HCINT7
       USB_OTG_HOST $10C + constant USB_OTG_HOST_FS_HCINTMSK0
       USB_OTG_HOST $12C + constant USB_OTG_HOST_FS_HCINTMSK1
       USB_OTG_HOST $14C + constant USB_OTG_HOST_FS_HCINTMSK2
       USB_OTG_HOST $16C + constant USB_OTG_HOST_FS_HCINTMSK3
       USB_OTG_HOST $18C + constant USB_OTG_HOST_FS_HCINTMSK4
       USB_OTG_HOST $1AC + constant USB_OTG_HOST_FS_HCINTMSK5
       USB_OTG_HOST $1CC + constant USB_OTG_HOST_FS_HCINTMSK6
       USB_OTG_HOST $1EC + constant USB_OTG_HOST_FS_HCINTMSK7
       USB_OTG_HOST $110 + constant USB_OTG_HOST_FS_HCTSIZ0
       USB_OTG_HOST $130 + constant USB_OTG_HOST_FS_HCTSIZ1
       USB_OTG_HOST $150 + constant USB_OTG_HOST_FS_HCTSIZ2
       USB_OTG_HOST $170 + constant USB_OTG_HOST_FS_HCTSIZ3
       USB_OTG_HOST $190 + constant USB_OTG_HOST_FS_HCTSIZ4
       USB_OTG_HOST $1B0 + constant USB_OTG_HOST_FS_HCTSIZ5
       USB_OTG_HOST $1D0 + constant USB_OTG_HOST_FS_HCTSIZ6
       USB_OTG_HOST $1F0 + constant USB_OTG_HOST_FS_HCTSIZ7
        
	
     $50000800 constant USB_OTG_DEVICE  
       USB_OTG_DEVICE $0 + constant USB_OTG_DEVICE_FS_DCFG
       USB_OTG_DEVICE $4 + constant USB_OTG_DEVICE_FS_DCTL
       USB_OTG_DEVICE $8 + constant USB_OTG_DEVICE_FS_DSTS
       USB_OTG_DEVICE $10 + constant USB_OTG_DEVICE_FS_DIEPMSK
       USB_OTG_DEVICE $14 + constant USB_OTG_DEVICE_FS_DOEPMSK
       USB_OTG_DEVICE $18 + constant USB_OTG_DEVICE_FS_DAINT
       USB_OTG_DEVICE $1C + constant USB_OTG_DEVICE_FS_DAINTMSK
       USB_OTG_DEVICE $28 + constant USB_OTG_DEVICE_DVBUSDIS
       USB_OTG_DEVICE $2C + constant USB_OTG_DEVICE_DVBUSPULSE
       USB_OTG_DEVICE $34 + constant USB_OTG_DEVICE_DIEPEMPMSK
       USB_OTG_DEVICE $100 + constant USB_OTG_DEVICE_FS_DIEPCTL0
       USB_OTG_DEVICE $120 + constant USB_OTG_DEVICE_DIEPCTL1
       USB_OTG_DEVICE $140 + constant USB_OTG_DEVICE_DIEPCTL2
       USB_OTG_DEVICE $160 + constant USB_OTG_DEVICE_DIEPCTL3
       USB_OTG_DEVICE $300 + constant USB_OTG_DEVICE_DOEPCTL0
       USB_OTG_DEVICE $320 + constant USB_OTG_DEVICE_DOEPCTL1
       USB_OTG_DEVICE $340 + constant USB_OTG_DEVICE_DOEPCTL2
       USB_OTG_DEVICE $360 + constant USB_OTG_DEVICE_DOEPCTL3
       USB_OTG_DEVICE $108 + constant USB_OTG_DEVICE_DIEPINT0
       USB_OTG_DEVICE $128 + constant USB_OTG_DEVICE_DIEPINT1
       USB_OTG_DEVICE $148 + constant USB_OTG_DEVICE_DIEPINT2
       USB_OTG_DEVICE $168 + constant USB_OTG_DEVICE_DIEPINT3
       USB_OTG_DEVICE $308 + constant USB_OTG_DEVICE_DOEPINT0
       USB_OTG_DEVICE $328 + constant USB_OTG_DEVICE_DOEPINT1
       USB_OTG_DEVICE $348 + constant USB_OTG_DEVICE_DOEPINT2
       USB_OTG_DEVICE $368 + constant USB_OTG_DEVICE_DOEPINT3
       USB_OTG_DEVICE $110 + constant USB_OTG_DEVICE_DIEPTSIZ0
       USB_OTG_DEVICE $310 + constant USB_OTG_DEVICE_DOEPTSIZ0
       USB_OTG_DEVICE $130 + constant USB_OTG_DEVICE_DIEPTSIZ1
       USB_OTG_DEVICE $150 + constant USB_OTG_DEVICE_DIEPTSIZ2
       USB_OTG_DEVICE $170 + constant USB_OTG_DEVICE_DIEPTSIZ3
       USB_OTG_DEVICE $118 + constant USB_OTG_DEVICE_DTXFSTS0
       USB_OTG_DEVICE $138 + constant USB_OTG_DEVICE_DTXFSTS1
       USB_OTG_DEVICE $158 + constant USB_OTG_DEVICE_DTXFSTS2
       USB_OTG_DEVICE $178 + constant USB_OTG_DEVICE_DTXFSTS3
       USB_OTG_DEVICE $330 + constant USB_OTG_DEVICE_DOEPTSIZ1
       USB_OTG_DEVICE $350 + constant USB_OTG_DEVICE_DOEPTSIZ2
       USB_OTG_DEVICE $370 + constant USB_OTG_DEVICE_DOEPTSIZ3
        
	
     $50000E00 constant USB_OTG_PWRCLK  
       USB_OTG_PWRCLK $0 + constant USB_OTG_PWRCLK_FS_PCGCCTL
        
	
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
        
	
     