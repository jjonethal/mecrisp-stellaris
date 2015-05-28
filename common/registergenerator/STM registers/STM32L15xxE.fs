$40012400 constant ADC  
       ADC $0 + constant ADC_SR
       ADC $4 + constant ADC_CR1
       ADC $8 + constant ADC_CR2
       ADC $C + constant ADC_SMPR1
       ADC $10 + constant ADC_SMPR2
       ADC $14 + constant ADC_SMPR3
       ADC $18 + constant ADC_JOFR1
       ADC $1C + constant ADC_JOFR2
       ADC $20 + constant ADC_JOFR3
       ADC $24 + constant ADC_JOFR4
       ADC $28 + constant ADC_HTR
       ADC $2C + constant ADC_LTR
       ADC $30 + constant ADC_SQR1
       ADC $34 + constant ADC_SQR2
       ADC $38 + constant ADC_SQR3
       ADC $3C + constant ADC_SQR4
       ADC $40 + constant ADC_SQR5
       ADC $44 + constant ADC_JSQR
       ADC $48 + constant ADC_JDR1
       ADC $4C + constant ADC_JDR2
       ADC $50 + constant ADC_JDR3
       ADC $54 + constant ADC_JDR4
       ADC $58 + constant ADC_DR
       ADC $5C + constant ADC_SMPR0
        
	
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
        
	
     $40012700 constant C_ADC  
       C_ADC $0 + constant C_ADC_CSR
       C_ADC $4 + constant C_ADC_CCR
        
	
     $40007C00 constant COMP  
       COMP $0 + constant COMP_CSR
        
	
     $40023000 constant CRC  
       CRC $0 + constant CRC_DR
       CRC $4 + constant CRC_IDR
       CRC $8 + constant CRC_CR
        
	
     $E0042000 constant DBG  
       DBG $0 + constant DBG_DBGMCU_IDCODE
       DBG $4 + constant DBG_DBGMCU_CR
       DBG $8 + constant DBG_DBGMCU_APB1_FZ
       DBG $C + constant DBG_DBGMCU_APB2_FZ
        
	
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
        
	
     $40026000 constant DMA1  
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
        
	
     $40026400 constant DMA2  
        
	
     $40010400 constant EXTI  
       EXTI $0 + constant EXTI_IMR
       EXTI $4 + constant EXTI_EMR
       EXTI $8 + constant EXTI_RTSR
       EXTI $C + constant EXTI_FTSR
       EXTI $10 + constant EXTI_SWIER
       EXTI $14 + constant EXTI_PR
        
	
     $40023C00 constant Flash  
       Flash $0 + constant Flash_ACR
       Flash $4 + constant Flash_PECR
       Flash $8 + constant Flash_PDKEYR
       Flash $C + constant Flash_PEKEYR
       Flash $10 + constant Flash_PRGKEYR
       Flash $14 + constant Flash_OPTKEYR
       Flash $18 + constant Flash_SR
       Flash $1C + constant Flash_OBR
       Flash $20 + constant Flash_WRPR1
       Flash $80 + constant Flash_WRPR2
       Flash $84 + constant Flash_WRPR3
        
	
     $40021000 constant GPIOE  
       GPIOE $FFFFF800 + constant GPIOE_MODER
       GPIOE $FFFFF804 + constant GPIOE_OTYPER
       GPIOE $FFFFF808 + constant GPIOE_OSPEEDER
       GPIOE $FFFFF80C + constant GPIOE_PUPDR
       GPIOE $FFFFF810 + constant GPIOE_IDR
       GPIOE $FFFFF814 + constant GPIOE_ODR
       GPIOE $FFFFF818 + constant GPIOE_BSRR
       GPIOE $FFFFF81C + constant GPIOE_LCKR
       GPIOE $FFFFF820 + constant GPIOE_AFRL
       GPIOE $FFFFF824 + constant GPIOE_AFRH
        
	
     $40020800 constant GPIOC  
        
	
     $40020C00 constant GPIOD  
        
	
     $40021400 constant GPIOH  
        
	
     $40021800 constant GPIOF  
        
	
     $40021C00 constant GPIOG  
        
	
     $40020000 constant GPIOA  
       GPIOA $0 + constant GPIOA_MODER
       GPIOA $4 + constant GPIOA_OTYPER
       GPIOA $8 + constant GPIOA_OSPEEDER
       GPIOA $C + constant GPIOA_PUPDR
       GPIOA $10 + constant GPIOA_IDR
       GPIOA $14 + constant GPIOA_ODR
       GPIOA $18 + constant GPIOA_BSRR
       GPIOA $1C + constant GPIOA_LCKR
       GPIOA $20 + constant GPIOA_AFRL
       GPIOA $24 + constant GPIOA_AFRH
        
	
     $40020400 constant GPIOB  
       GPIOB $0 + constant GPIOB_MODER
       GPIOB $4 + constant GPIOB_OTYPER
       GPIOB $8 + constant GPIOB_OSPEEDER
       GPIOB $C + constant GPIOB_PUPDR
       GPIOB $10 + constant GPIOB_IDR
       GPIOB $14 + constant GPIOB_ODR
       GPIOB $18 + constant GPIOB_BSRR
       GPIOB $1C + constant GPIOB_LCKR
       GPIOB $20 + constant GPIOB_AFRL
       GPIOB $24 + constant GPIOB_AFRH
        
	
     $40010800 constant TIM9  
       TIM9 $0 + constant TIM9_CR1
       TIM9 $4 + constant TIM9_CR2
       TIM9 $8 + constant TIM9_SMCR
       TIM9 $C + constant TIM9_DIER
       TIM9 $10 + constant TIM9_SR
       TIM9 $14 + constant TIM9_EGR
       TIM9 $18 + constant TIM9_CCMR1_Output
       TIM9 $18 + constant TIM9_CCMR1_Input
       TIM9 $24 + constant TIM9_CNT
       TIM9 $28 + constant TIM9_PSC
       TIM9 $2C + constant TIM9_ARR
       TIM9 $34 + constant TIM9_CCR1
       TIM9 $38 + constant TIM9_CCR2
       TIM9 $50 + constant TIM9_OR
        
	
     $40010C00 constant TIM10  
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
        
	
     $40011000 constant TIM11  
        
	
     $40000400 constant TIM3  
       TIM3 $FFFFFC00 + constant TIM3_CR1
       TIM3 $FFFFFC04 + constant TIM3_CR2
       TIM3 $FFFFFC08 + constant TIM3_SMCR
       TIM3 $FFFFFC0C + constant TIM3_DIER
       TIM3 $FFFFFC10 + constant TIM3_SR
       TIM3 $FFFFFC14 + constant TIM3_EGR
       TIM3 $FFFFFC18 + constant TIM3_CCMR1_Output
       TIM3 $FFFFFC18 + constant TIM3_CCMR1_Input
       TIM3 $FFFFFC1C + constant TIM3_CCMR2_Output
       TIM3 $FFFFFC1C + constant TIM3_CCMR2_Input
       TIM3 $FFFFFC20 + constant TIM3_CCER
       TIM3 $FFFFFC24 + constant TIM3_CNT
       TIM3 $FFFFFC28 + constant TIM3_PSC
       TIM3 $FFFFFC2C + constant TIM3_ARR
       TIM3 $FFFFFC34 + constant TIM3_CCR1
       TIM3 $FFFFFC38 + constant TIM3_CCR2
       TIM3 $FFFFFC3C + constant TIM3_CCR3
       TIM3 $FFFFFC40 + constant TIM3_CCR4
       TIM3 $FFFFFC48 + constant TIM3_DCR
       TIM3 $FFFFFC4C + constant TIM3_DMAR
        
	
     $40000000 constant TIM2  
        
	
     $40000800 constant TIM4  
        
	
     $40000C00 constant TIM5  
        
	
     $40003000 constant IWDG  
       IWDG $0 + constant IWDG_KR
       IWDG $4 + constant IWDG_PR
       IWDG $8 + constant IWDG_RLR
       IWDG $C + constant IWDG_SR
        
	
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
        
	
     $40002400 constant LCD  
       LCD $0 + constant LCD_CR
       LCD $4 + constant LCD_FCR
       LCD $8 + constant LCD_SR
       LCD $C + constant LCD_CLR
       LCD $14 + constant LCD_RAM_COM0
       LCD $1C + constant LCD_RAM_COM1
       LCD $24 + constant LCD_RAM_COM2
       LCD $2C + constant LCD_RAM_COM3
       LCD $34 + constant LCD_RAM_COM4
       LCD $3C + constant LCD_RAM_COM5
       LCD $44 + constant LCD_RAM_COM6
       LCD $4C + constant LCD_RAM_COM7
        
	
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
        
	
     $40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
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
        
	
     $40023800 constant RCC  
       RCC $0 + constant RCC_CR
       RCC $4 + constant RCC_ICSCR
       RCC $8 + constant RCC_CFGR
       RCC $C + constant RCC_CIR
       RCC $10 + constant RCC_AHBRSTR
       RCC $14 + constant RCC_APB2RSTR
       RCC $18 + constant RCC_APB1RSTR
       RCC $1C + constant RCC_AHBENR
       RCC $20 + constant RCC_APB2ENR
       RCC $24 + constant RCC_APB1ENR
       RCC $28 + constant RCC_AHBLPENR
       RCC $2C + constant RCC_APB2LPENR
       RCC $30 + constant RCC_APB1LPENR
       RCC $34 + constant RCC_CSR
        
	
     $40007C04 constant RI  
       RI $0 + constant RI_ICR
       RI $4 + constant RI_ASCR1
       RI $8 + constant RI_ASCR2
       RI $C + constant RI_HYSCR1
       RI $10 + constant RI_HYSCR2
       RI $14 + constant RI_HYSCR3
       RI $18 + constant RI_HYSCR4
       RI $1C + constant RI_ASMR1
       RI $20 + constant RI_CMR1
       RI $24 + constant RI_CICR1
       RI $28 + constant RI_ASMR2
       RI $2C + constant RI_CMR2
       RI $30 + constant RI_CICR2
       RI $34 + constant RI_ASMR3
       RI $38 + constant RI_CMR3
       RI $3C + constant RI_CICR3
       RI $40 + constant RI_ASMR4
       RI $44 + constant RI_CMR4
       RI $48 + constant RI_CICR4
       RI $4C + constant RI_ASMR5
       RI $50 + constant RI_CMR5
       RI $54 + constant RI_CICR5
        
	
     $40003800 constant SPI2  
       SPI2 $F800 + constant SPI2_CR1
       SPI2 $F804 + constant SPI2_CR2
       SPI2 $F808 + constant SPI2_SR
       SPI2 $F80C + constant SPI2_DR
       SPI2 $F810 + constant SPI2_CRCPR
       SPI2 $F814 + constant SPI2_RXCRCR
       SPI2 $F818 + constant SPI2_TXCRCR
       SPI2 $F81C + constant SPI2_I2SCFGR
       SPI2 $F820 + constant SPI2_I2SPR
        
	
     $40013000 constant SPI1  
        
	
     $40013C00 constant SPI3  
        
	
     $40010000 constant SYSCFG  
       SYSCFG $0 + constant SYSCFG_MEMRMP
       SYSCFG $4 + constant SYSCFG_PMC
       SYSCFG $8 + constant SYSCFG_EXTICR1
       SYSCFG $C + constant SYSCFG_EXTICR2
       SYSCFG $10 + constant SYSCFG_EXTICR3
       SYSCFG $14 + constant SYSCFG_EXTICR4
        
	
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
        
	
     $40006000 constant USB_SRAM  
        
	
     $40004800 constant USART3  
       USART3 $F000 + constant USART3_SR
       USART3 $F004 + constant USART3_DR
       USART3 $F008 + constant USART3_BRR
       USART3 $F00C + constant USART3_CR1
       USART3 $F010 + constant USART3_CR2
       USART3 $F014 + constant USART3_CR3
       USART3 $F018 + constant USART3_GTPR
        
	
     $40004400 constant USART2  
        
	
     $40013800 constant USART1  
        
	
     $40002C00 constant WWDG  
       WWDG $0 + constant WWDG_CR
       WWDG $4 + constant WWDG_CFR
       WWDG $8 + constant WWDG_SR
        
	
     