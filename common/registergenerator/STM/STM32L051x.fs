$40007400 constant DAC  
       DAC $0 + constant DAC_CR
       DAC $4 + constant DAC_SWTRIGR
       DAC $8 + constant DAC_DHR12R1
       DAC $C + constant DAC_DHR12L1
       DAC $10 + constant DAC_DHR8R1
       DAC $2C + constant DAC_DOR1
       DAC $34 + constant DAC_SR
        
	
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
       DMA1 $A8 + constant DMA1_CSELR
        
	
     $40023000 constant CRC  
       CRC $0 + constant CRC_DR
       CRC $4 + constant CRC_IDR
       CRC $8 + constant CRC_CR
       CRC $10 + constant CRC_INIT
       CRC $14 + constant CRC_POL
        
	
     $50000000 constant GPIOA  
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
        
	
     $50000400 constant GPIOB  
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
        
	
     $50000800 constant GPIOC  
        
	
     $50000C00 constant GPIOD  
        
	
     $50001C00 constant GPIOH  
        
	
     $40007C00 constant LPTIM  
       LPTIM $0 + constant LPTIM_ISR
       LPTIM $4 + constant LPTIM_ICR
       LPTIM $8 + constant LPTIM_IER
       LPTIM $C + constant LPTIM_CFGR
       LPTIM $10 + constant LPTIM_CR
       LPTIM $14 + constant LPTIM_CMP
       LPTIM $18 + constant LPTIM_ARR
       LPTIM $1C + constant LPTIM_CNT
        
	
     $40025000 constant RNG  
       RNG $0 + constant RNG_CR
       RNG $4 + constant RNG_SR
       RNG $8 + constant RNG_DR
        
	
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
       RTC $40 + constant RTC_TAMPCR
       RTC $44 + constant RTC_ALRMASSR
       RTC $48 + constant RTC_ALRMBSSR
       RTC $4C + constant RTC_OR
       RTC $50 + constant RTC_BKP0R
       RTC $54 + constant RTC_BKP1R
       RTC $58 + constant RTC_BKP2R
       RTC $5C + constant RTC_BKP3R
       RTC $60 + constant RTC_BKP4R
        
	
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
        
	
     $40010018 constant COMP  
       COMP $18 + constant COMP_COMP1_CSR
       COMP $1C + constant COMP_COMP2_CSR
        
	
     $40005C00 constant USB_FS  
       USB_FS $0 + constant USB_FS_EP0R
       USB_FS $4 + constant USB_FS_EP1R
       USB_FS $8 + constant USB_FS_EP2R
       USB_FS $C + constant USB_FS_EP3R
       USB_FS $10 + constant USB_FS_EP4R
       USB_FS $14 + constant USB_FS_EP5R
       USB_FS $18 + constant USB_FS_EP6R
       USB_FS $1C + constant USB_FS_EP7R
       USB_FS $40 + constant USB_FS_CNTR
       USB_FS $44 + constant USB_FS_ISTR
       USB_FS $48 + constant USB_FS_FNR
       USB_FS $4C + constant USB_FS_DADDR
       USB_FS $50 + constant USB_FS_BTABLE
       USB_FS $54 + constant USB_FS_LPMCSR
       USB_FS $58 + constant USB_FS_BCDR
        
	
     $40006C00 constant CRS  
       CRS $0 + constant CRS_CR
       CRS $4 + constant CRS_CFGR
       CRS $8 + constant CRS_ISR
       CRS $C + constant CRS_ICR
        
	
     $40011C00 constant Firewall  
       Firewall $0 + constant Firewall_FIREWALL_CSSA
       Firewall $4 + constant Firewall_FIREWALL_CSL
       Firewall $8 + constant Firewall_FIREWALL_NVDSSA
       Firewall $C + constant Firewall_FIREWALL_NVDSL
       Firewall $10 + constant Firewall_FIREWALL_VDSSA
       Firewall $14 + constant Firewall_FIREWALL_VDSL
       Firewall $20 + constant Firewall_FIREWALL_CR
        
	
     $40021000 constant RCC  
       RCC $0 + constant RCC_CR
       RCC $4 + constant RCC_ICSCR
       RCC $8 + constant RCC_CRRCR
       RCC $C + constant RCC_CFGR
       RCC $10 + constant RCC_CIER
       RCC $14 + constant RCC_CIFR
       RCC $18 + constant RCC_CICR
       RCC $1C + constant RCC_IOPRSTR
       RCC $20 + constant RCC_AHBRSTR
       RCC $24 + constant RCC_APB2RSTR
       RCC $28 + constant RCC_APB1RSTR
       RCC $2C + constant RCC_IOPENR
       RCC $30 + constant RCC_AHBENR
       RCC $34 + constant RCC_APB2ENR
       RCC $38 + constant RCC_APB1ENR
       RCC $3C + constant RCC_IOPSMEN
       RCC $40 + constant RCC_AHBSMENR
       RCC $44 + constant RCC_APB2SMENR
       RCC $48 + constant RCC_APB1SMENR
       RCC $4C + constant RCC_CCIPR
       RCC $50 + constant RCC_CSR
        
	
     $40010000 constant SYSCFG  
       SYSCFG $0 + constant SYSCFG_CFGR1
       SYSCFG $4 + constant SYSCFG_CFGR2
       SYSCFG $8 + constant SYSCFG_EXTICR1
       SYSCFG $C + constant SYSCFG_EXTICR2
       SYSCFG $10 + constant SYSCFG_EXTICR3
       SYSCFG $14 + constant SYSCFG_EXTICR4
       SYSCFG $20 + constant SYSCFG_CFGR3
        
	
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
        
	
     $40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
     $40022000 constant Flash  
       Flash $0 + constant Flash_ACR
       Flash $4 + constant Flash_PECR
       Flash $8 + constant Flash_PDKEYR
       Flash $C + constant Flash_PEKEYR
       Flash $10 + constant Flash_PRGKEYR
       Flash $14 + constant Flash_OPTKEYR
       Flash $18 + constant Flash_SR
       Flash $1C + constant Flash_OBR
       Flash $20 + constant Flash_WRPR
        
	
     $40010400 constant EXTI  
       EXTI $0 + constant EXTI_IMR
       EXTI $4 + constant EXTI_EMR
       EXTI $8 + constant EXTI_RTSR
       EXTI $C + constant EXTI_FTSR
       EXTI $10 + constant EXTI_SWIER
       EXTI $14 + constant EXTI_PR
        
	
     $40012400 constant ADC  
       ADC $0 + constant ADC_ISR
       ADC $4 + constant ADC_IER
       ADC $8 + constant ADC_CR
       ADC $C + constant ADC_CFGR1
       ADC $10 + constant ADC_CFGR2
       ADC $14 + constant ADC_SMPR
       ADC $20 + constant ADC_TR
       ADC $28 + constant ADC_CHSELR
       ADC $40 + constant ADC_DR
       ADC $B4 + constant ADC_CALFACT
       ADC $308 + constant ADC_CCR
        
	
     $40015800 constant DBGMCU  
       DBGMCU $0 + constant DBGMCU_IDCODE
       DBGMCU $4 + constant DBGMCU_CR
       DBGMCU $8 + constant DBGMCU_APB1_FZ
       DBGMCU $C + constant DBGMCU_APB2_FZ
        
	
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
        
	
     $40001000 constant TIM6  
       TIM6 $0 + constant TIM6_CR1
       TIM6 $4 + constant TIM6_CR2
       TIM6 $C + constant TIM6_DIER
       TIM6 $10 + constant TIM6_SR
       TIM6 $14 + constant TIM6_EGR
       TIM6 $24 + constant TIM6_CNT
       TIM6 $28 + constant TIM6_PSC
       TIM6 $2C + constant TIM6_ARR
        
	
     $40010800 constant TIM21  
       TIM21 $0 + constant TIM21_CR1
       TIM21 $4 + constant TIM21_CR2
       TIM21 $8 + constant TIM21_SMCR
       TIM21 $C + constant TIM21_DIER
       TIM21 $10 + constant TIM21_SR
       TIM21 $14 + constant TIM21_EGR
       TIM21 $18 + constant TIM21_CCMR1_Output
       TIM21 $18 + constant TIM21_CCMR1_Input
       TIM21 $20 + constant TIM21_CCER
       TIM21 $24 + constant TIM21_CNT
       TIM21 $28 + constant TIM21_PSC
       TIM21 $2C + constant TIM21_ARR
       TIM21 $34 + constant TIM21_CCR1
       TIM21 $38 + constant TIM21_CCR2
       TIM21 $50 + constant TIM21_OR
        
	
     $40011400 constant TIM22  
       TIM22 $0 + constant TIM22_CR1
       TIM22 $4 + constant TIM22_CR2
       TIM22 $8 + constant TIM22_SMCR
       TIM22 $C + constant TIM22_DIER
       TIM22 $10 + constant TIM22_SR
       TIM22 $14 + constant TIM22_EGR
       TIM22 $18 + constant TIM22_CCMR1_Output
       TIM22 $18 + constant TIM22_CCMR1_Input
       TIM22 $20 + constant TIM22_CCER
       TIM22 $24 + constant TIM22_CNT
       TIM22 $28 + constant TIM22_PSC
       TIM22 $2C + constant TIM22_ARR
       TIM22 $34 + constant TIM22_CCR1
       TIM22 $38 + constant TIM22_CCR2
       TIM22 $50 + constant TIM22_OR
        
	
     $40004800 constant LPUSART1  
       LPUSART1 $0 + constant LPUSART1_CR1
       LPUSART1 $4 + constant LPUSART1_CR2
       LPUSART1 $8 + constant LPUSART1_CR3
       LPUSART1 $C + constant LPUSART1_BRR
       LPUSART1 $18 + constant LPUSART1_RQR
       LPUSART1 $1C + constant LPUSART1_ISR
       LPUSART1 $20 + constant LPUSART1_ICR
       LPUSART1 $24 + constant LPUSART1_RDR
       LPUSART1 $28 + constant LPUSART1_TDR
        
	
     $E000E100 constant NVIC  
       NVIC $0 + constant NVIC_ISER
       NVIC $80 + constant NVIC_ICER
       NVIC $100 + constant NVIC_ISPR
       NVIC $180 + constant NVIC_ICPR
       NVIC $300 + constant NVIC_IPR0
       NVIC $304 + constant NVIC_IPR1
       NVIC $308 + constant NVIC_IPR2
       NVIC $30C + constant NVIC_IPR3
       NVIC $310 + constant NVIC_IPR4
       NVIC $314 + constant NVIC_IPR5
       NVIC $318 + constant NVIC_IPR6
       NVIC $31C + constant NVIC_IPR7
        
	
     