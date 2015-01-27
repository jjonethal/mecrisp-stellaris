$4000A800 constant TIM1  
       TIM1 $0 + constant TIM1_TIM1_ISR
       TIM1 $18 + constant TIM1_TIM1_MISSR
       TIM1 $3800 + constant TIM1_TIM1_CR1
       TIM1 $40 + constant TIM1_TIM1_IER
       TIM1 $3804 + constant TIM1_TIM1_CR2
       TIM1 $3808 + constant TIM1_TIM1_SMCR
       TIM1 $3814 + constant TIM1_TIM1_EGR
       TIM1 $3818 + constant TIM1_TIM1_CCMR1_Input
       TIM1 $3818 + constant TIM1_TIM1_CCMR1_Output
       TIM1 $381C + constant TIM1_TIM1_CCMR2_Input
       TIM1 $381C + constant TIM1_TIM1_CCMR2_Output
       TIM1 $3820 + constant TIM1_TIM1_CCER
       TIM1 $3824 + constant TIM1_TIM1_CNT
       TIM1 $3828 + constant TIM1_TIM1_PSC
       TIM1 $382C + constant TIM1_TIM1_ARR
       TIM1 $3834 + constant TIM1_TIM1_CCR1
       TIM1 $3838 + constant TIM1_TIM1_CCR2
       TIM1 $383C + constant TIM1_TIM1_CCR3
       TIM1 $3840 + constant TIM1_TIM1_CCR4
       TIM1 $3850 + constant TIM1_TIM1_OR
        
	
     $4000A804 constant TIM2  
       TIM2 $0 + constant TIM2_TIM2_ISR
       TIM2 $18 + constant TIM2_TIM2_MISSR
       TIM2 $47FC + constant TIM2_TIM2_CR1
       TIM2 $40 + constant TIM2_TIM2_IER
       TIM2 $4800 + constant TIM2_TIM2_CR2
       TIM2 $4804 + constant TIM2_TIM2_SMCR
       TIM2 $4810 + constant TIM2_TIM2_EGR
       TIM2 $4814 + constant TIM2_TIM2_CCMR1_Input
       TIM2 $4814 + constant TIM2_TIM2_CCMR1_Output
       TIM2 $4818 + constant TIM2_TIM2_CCMR2_Input
       TIM2 $4818 + constant TIM2_TIM2_CCMR2_Output
       TIM2 $481C + constant TIM2_TIM2_CCER
       TIM2 $4820 + constant TIM2_TIM2_CNT
       TIM2 $4824 + constant TIM2_TIM2_PSC
       TIM2 $4828 + constant TIM2_TIM2_ARR
       TIM2 $4830 + constant TIM2_TIM2_CCR1
       TIM2 $4834 + constant TIM2_TIM2_CCR2
       TIM2 $4838 + constant TIM2_TIM2_CCR3
       TIM2 $483C + constant TIM2_TIM2_CCR4
       TIM2 $484C + constant TIM2_TIM2_OR
        
	
     $4000A808 constant SC1  
       SC1 $0 + constant SC1_SC1_ISR
       SC1 $40 + constant SC1_SC1_IER
       SC1 $4C + constant SC1_SC1_ICR
       SC1 $2034 + constant SC1_SC1_DR
       SC1 $204C + constant SC1_SC1_CR
       SC1 $2058 + constant SC1_SC1_CRR1
       SC1 $205C + constant SC1_SC1_CRR2
        
	
     $4000A80C constant SC2  
       SC2 $0 + constant SC2_SC2_ISR
       SC2 $40 + constant SC2_SC2_IER
       SC2 $4C + constant SC2_SC2_ICR
       SC2 $1830 + constant SC2_SC2_DR
       SC2 $1848 + constant SC2_SC2_CR
       SC2 $1854 + constant SC2_SC2_CRR1
       SC2 $1858 + constant SC2_SC2_CRR2
        
	
     $4000A810 constant ADC  
       ADC $0 + constant ADC_ADC_ISR
       ADC $40 + constant ADC_ADC_IER
       ADC $27F4 + constant ADC_ADC_CR
       ADC $27F8 + constant ADC_ADC_OFFSETR
       ADC $27FC + constant ADC_ADC_GAINR
       ADC $2800 + constant ADC_ADC_DMACR
       ADC $2804 + constant ADC_ADC_DMASR
       ADC $2808 + constant ADC_ADC_DMAMSAR
       ADC $280C + constant ADC_ADC_DMANDTR
       ADC $2810 + constant ADC_ADC_DMAMNAR
       ADC $2814 + constant ADC_ADC_DMACNDTR
        
	
     $4000A814 constant EXTI  
       EXTI $0 + constant EXTI_EXTI_PR
       EXTI $4C + constant EXTI_EXTIA_TSR
       EXTI $50 + constant EXTI_EXTIB_TSR
       EXTI $54 + constant EXTI_EXTIC_TSR
       EXTI $1400 + constant EXTI_EXTIC_CR
       EXTI $58 + constant EXTI_EXTID_TSR
       EXTI $1404 + constant EXTI_EXTID_CR
        
	
     $4000B000 constant GPIOA  
       GPIOA $0 + constant GPIOA_GPIOA_CRL
       GPIOA $4 + constant GPIOA_GPIOA_CRH
       GPIOA $8 + constant GPIOA_GPIOA_IDR
       GPIOA $C + constant GPIOA_GPIOA_ODR
       GPIOA $10 + constant GPIOA_GPIOA_BSR
       GPIOA $14 + constant GPIOA_GPIOA_BRR
        
	
     $4000B400 constant GPIOB  
       GPIOB $0 + constant GPIOB_GPIOB_CRL
       GPIOB $4 + constant GPIOB_GPIOB_CRH
       GPIOB $8 + constant GPIOB_GPIOB_IDR
       GPIOB $C + constant GPIOB_GPIOB_ODR
       GPIOB $10 + constant GPIOB_GPIOB_BSR
       GPIOB $14 + constant GPIOB_GPIOB_BRR
        
	
     $4000B800 constant GPIOC  
       GPIOC $0 + constant GPIOC_GPIOC_CRL
       GPIOC $4 + constant GPIOC_GPIOC_CRH
       GPIOC $8 + constant GPIOC_GPIOC_IDR
       GPIOC $C + constant GPIOC_GPIOC_ODR
       GPIOC $10 + constant GPIOC_GPIOC_BSR
       GPIOC $14 + constant GPIOC_GPIOC_BRR
        
	
     $40004028 constant GPIO_DBG  
       GPIO_DBG $7BD8 + constant GPIO_DBG_GPIO_DBGCR
       GPIO_DBG $7BDC + constant GPIO_DBG_GPIO_DBGSR
       GPIO_DBG $0 + constant GPIO_DBG_GPIO_PCTRACECR
        
	
     $40006000 constant WDG  
       WDG $0 + constant WDG_WDG_CR
       WDG $4 + constant WDG_WDG_KR
       WDG $8 + constant WDG_WDG_KICKSR
        
	
     $40000008 constant CLK  
       CLK $0 + constant CLK_CLK_SLEEPCR
       CLK $4 + constant CLK_CLK_LSI10KCR
       CLK $8 + constant CLK_CLK_LSI1KCR
       CLK $3FFC + constant CLK_CLK_HSECR1
       CLK $4000 + constant CLK_CLK_HSICR
       CLK $4008 + constant CLK_CLK_PERIODCR
       CLK $400C + constant CLK_CLK_PERIODSR
       CLK $4010 + constant CLK_CLK_DITHERCR
       CLK $4014 + constant CLK_CLK_HSECR2
       CLK $4018 + constant CLK_CLK_CPUCR
        
	
     $4000002C constant RST  
       RST $0 + constant RST_RST_SR
        
	
     $4000402C constant FLASH  
       FLASH $3FD4 + constant FLASH_FLASH_ACR
       FLASH $3FD8 + constant FLASH_FLASH_KEYR
       FLASH $3FDC + constant FLASH_FLASH_OPTKEYR
       FLASH $3FE0 + constant FLASH_FLASH_SR
       FLASH $3FE4 + constant FLASH_FLASH_CR
       FLASH $3FE8 + constant FLASH_FLASH_AR
       FLASH $3FF0 + constant FLASH_FLASH_OBR
       FLASH $3FF4 + constant FLASH_FLASH_WRPR
       FLASH $0 + constant FLASH_FLASH_CLKER
       FLASH $4 + constant FLASH_FLASH_CLKSR
        
	
     $4000600C constant SLPTMR  
       SLPTMR $0 + constant SLPTMR_SLPTMR_CR
       SLPTMR $4 + constant SLPTMR_SLPTMR_CNTH
       SLPTMR $8 + constant SLPTMR_SLPTMR_CNTL
       SLPTMR $C + constant SLPTMR_SLPTMR_CMPAH
       SLPTMR $10 + constant SLPTMR_SLPTMR_CMPAL
       SLPTMR $14 + constant SLPTMR_SLPTMR_CMPBH
       SLPTMR $18 + constant SLPTMR_SLPTMR_CMPBL
       SLPTMR $4008 + constant SLPTMR_SLPTMR_ISR
       SLPTMR $4014 + constant SLPTMR_SLPTMR_IFR
       SLPTMR $4048 + constant SLPTMR_SLPTMR_IER
        
	
     $40000004 constant PWR  
       PWR $0 + constant PWR_PWR_DSLEEPCR1
       PWR $10 + constant PWR_PWR_DSLEEPCR2
       PWR $14 + constant PWR_PWR_VREGCR
       PWR $1C + constant PWR_PWR_WAKECR1
       PWR $20 + constant PWR_PWR_WAKECR2
       PWR $24 + constant PWR_PWR_WAKESR
       PWR $30 + constant PWR_PWR_CPWRUPREQSR
       PWR $34 + constant PWR_PWR_CSYSPWRUPREQSR
       PWR $38 + constant PWR_PWR_CSYSPWRUPACKSR
       PWR $3C + constant PWR_PWR_CSYSPWRUPACKCR
       PWR $BC04 + constant PWR_PWR_WAKEPAR
       PWR $BC08 + constant PWR_PWR_WAKEPBR
       PWR $BC0C + constant PWR_PWR_WAKEPCR
       PWR $BC18 + constant PWR_PWR_WAKEFILTR
        
	
     $E000E000 constant NVIC  
       NVIC $4 + constant NVIC_ICTR
       NVIC $F00 + constant NVIC_STIR
       NVIC $100 + constant NVIC_ISER0
       NVIC $180 + constant NVIC_ICER0
       NVIC $200 + constant NVIC_ISPR0
       NVIC $280 + constant NVIC_ICPR0
       NVIC $300 + constant NVIC_IABR0
       NVIC $400 + constant NVIC_IPR0
       NVIC $404 + constant NVIC_IPR1
       NVIC $408 + constant NVIC_IPR2
       NVIC $40C + constant NVIC_IPR3
       NVIC $410 + constant NVIC_IPR4
        
	
     $40005000 constant MEM  
       MEM $0 + constant MEM_RAMPROTR1
       MEM $4 + constant MEM_RAMPROTR2
       MEM $8 + constant MEM_RAMPROTR3
       MEM $C + constant MEM_RAMPROTR4
       MEM $10 + constant MEM_RAMPROTR5
       MEM $14 + constant MEM_RAMPROTR6
       MEM $18 + constant MEM_RAMPROTR7
       MEM $1C + constant MEM_RAMPROTR8
       MEM $20 + constant MEM_DMAPROTR1
       MEM $24 + constant MEM_DMAPROTR2
       MEM $28 + constant MEM_RAMCR
        
	
     $4000C800 constant SC1_DMA  
       SC1_DMA $0 + constant SC1_DMA_SC1_DMARXBEGADDAR
       SC1_DMA $4 + constant SC1_DMA_SC1_DMARXENDADDAR
       SC1_DMA $8 + constant SC1_DMA_SC1_DMARXBEGADDBR
       SC1_DMA $C + constant SC1_DMA_SC1_DMARXENDADDBR
       SC1_DMA $10 + constant SC1_DMA_SC1_DMATXBEGADDAR
       SC1_DMA $14 + constant SC1_DMA_SC1_DMATXENDADDAR
       SC1_DMA $18 + constant SC1_DMA_SC1_DMATXBEGADDBR
       SC1_DMA $1C + constant SC1_DMA_SC1_DMATXENDADDBR
       SC1_DMA $20 + constant SC1_DMA_SC1_DMARXCNTAR
       SC1_DMA $24 + constant SC1_DMA_SC1_DMARXCNTBR
       SC1_DMA $28 + constant SC1_DMA_SC1_DMATXCNTR
       SC1_DMA $2C + constant SC1_DMA_SC1_DMASR
       SC1_DMA $30 + constant SC1_DMA_SC1_DMACR
       SC1_DMA $34 + constant SC1_DMA_SC1_DMARXERRAR
       SC1_DMA $38 + constant SC1_DMA_SC1_DMARXERRBR
       SC1_DMA $70 + constant SC1_DMA_SC1_DMARXCNTSAVEDR
        
	
     $4000C848 constant SC1_UART  
       SC1_UART $0 + constant SC1_UART_SC1_UARTSR
       SC1_UART $14 + constant SC1_UART_SC1_UARTCR
       SC1_UART $20 + constant SC1_UART_SC1_UARTBRR1
       SC1_UART $24 + constant SC1_UART_SC1_UARTBRR2
        
	
     $4000C844 constant SC1_I2C  
       SC1_I2C $0 + constant SC1_I2C_SC1_I2CSR
       SC1_I2C $8 + constant SC1_I2C_SC1_I2CCR1
       SC1_I2C $C + constant SC1_I2C_SC1_I2CCR2
        
	
     $4000C840 constant SC1_SPI  
       SC1_SPI $0 + constant SC1_SPI_SC1_SPISR
       SC1_SPI $18 + constant SC1_SPI_SC1_SPICR
        
	
     $4000C000 constant SC2_DMA  
       SC2_DMA $0 + constant SC2_DMA_SC2_DMARXBEGADDAR
       SC2_DMA $4 + constant SC2_DMA_SC2_DMARXENDADDAR
       SC2_DMA $8 + constant SC2_DMA_SC2_DMARXBEGADDBR
       SC2_DMA $C + constant SC2_DMA_SC2_DMARXENDADDBR
       SC2_DMA $10 + constant SC2_DMA_SC2_DMATXBEGADDAR
       SC2_DMA $14 + constant SC2_DMA_SC2_DMATXENDADDAR
       SC2_DMA $18 + constant SC2_DMA_SC2_DMATXBEGADDBR
       SC2_DMA $1C + constant SC2_DMA_SC2_DMATXENDADDBR
       SC2_DMA $20 + constant SC2_DMA_SC2_DMARXCNTAR
       SC2_DMA $24 + constant SC2_DMA_SC2_DMARXCNTBR
       SC2_DMA $28 + constant SC2_DMA_SC2_DMATXCNTR
       SC2_DMA $2C + constant SC2_DMA_SC2_DMASR
       SC2_DMA $30 + constant SC2_DMA_SC2_DMACR
       SC2_DMA $34 + constant SC2_DMA_SC2_DMARXERRAR
       SC2_DMA $38 + constant SC2_DMA_SC2_DMARXERRBR
       SC2_DMA $70 + constant SC2_DMA_SC2_DMARXCNTSAVEDR
        
	
     $4000C044 constant SC2_I2C  
       SC2_I2C $0 + constant SC2_I2C_SC2_I2CSR
       SC2_I2C $8 + constant SC2_I2C_SC2_I2CCR1
       SC2_I2C $C + constant SC2_I2C_SC2_I2CCR2
        
	
     $4000C040 constant SC2_SPI  
       SC2_SPI $0 + constant SC2_SPI_SC2_SPISR
       SC2_SPI $18 + constant SC2_SPI_SC2_SPICR
        
	
     $40002038 constant MAC_TIM  
       MAC_TIM $0 + constant MAC_TIM_MACTMR_CNTR
       MAC_TIM $54 + constant MAC_TIM_MACTMR_CR
        
	
     