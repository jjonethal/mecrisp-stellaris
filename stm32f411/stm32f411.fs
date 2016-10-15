compiletoflash
$40012300 constant ADC_Common  
       ADC_Common $0 + constant ADC_Common_CSR
       ADC_Common $4 + constant ADC_Common_CCR
        
	
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
        
	
     $40023000 constant CRC  
       CRC $0 + constant CRC_DR
       CRC $4 + constant CRC_IDR
       CRC $8 + constant CRC_CR
        
	
     $E0042000 constant DBG  
       DBG $0 + constant DBG_DBGMCU_IDCODE
       DBG $4 + constant DBG_DBGMCU_CR
       DBG $8 + constant DBG_DBGMCU_APB1_FZ
       DBG $C + constant DBG_DBGMCU_APB2_FZ
        
	
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
        
	
     $40003000 constant IWDG  
       IWDG $0 + constant IWDG_KR
       IWDG $4 + constant IWDG_PR
       IWDG $8 + constant IWDG_RLR
       IWDG $C + constant IWDG_SR
        
	
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
        
	
     $50000E00 constant OTG_FS_PWRCLK  
       OTG_FS_PWRCLK $0 + constant OTG_FS_PWRCLK_FS_PCGCCTL
        
	
     $40007000 constant PWR  
       PWR $0 + constant PWR_CR
       PWR $4 + constant PWR_CSR
        
	
     $40023800 constant RCC  
       RCC $0 + constant RCC_CR
       RCC $4 + constant RCC_PLLCFGR
       RCC $8 + constant RCC_CFGR
       RCC $C + constant RCC_CIR
       RCC $10 + constant RCC_AHB1RSTR
       RCC $14 + constant RCC_AHB2RSTR
       RCC $20 + constant RCC_APB1RSTR
       RCC $24 + constant RCC_APB2RSTR
       RCC $30 + constant RCC_AHB1ENR
       RCC $34 + constant RCC_AHB2ENR
       RCC $40 + constant RCC_APB1ENR
       RCC $44 + constant RCC_APB2ENR
       RCC $50 + constant RCC_AHB1LPENR
       RCC $54 + constant RCC_AHB2LPENR
       RCC $60 + constant RCC_APB1LPENR
       RCC $64 + constant RCC_APB2LPENR
       RCC $70 + constant RCC_BDCR
       RCC $74 + constant RCC_CSR
       RCC $80 + constant RCC_SSCGR
       RCC $84 + constant RCC_PLLI2SCFGR
        
	
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
        
	
     $40013800 constant SYSCFG  
       SYSCFG $0 + constant SYSCFG_MEMRM
       SYSCFG $4 + constant SYSCFG_PMC
       SYSCFG $8 + constant SYSCFG_EXTICR1
       SYSCFG $C + constant SYSCFG_EXTICR2
       SYSCFG $10 + constant SYSCFG_EXTICR3
       SYSCFG $14 + constant SYSCFG_EXTICR4
       SYSCFG $20 + constant SYSCFG_CMPCR
        
	
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
        
	
     $40014800 constant TIM11  
       TIM11 $0 + constant TIM11_CR1
       TIM11 $C + constant TIM11_DIER
       TIM11 $10 + constant TIM11_SR
       TIM11 $14 + constant TIM11_EGR
       TIM11 $18 + constant TIM11_CCMR1_Output
       TIM11 $18 + constant TIM11_CCMR1_Input
       TIM11 $20 + constant TIM11_CCER
       TIM11 $24 + constant TIM11_CNT
       TIM11 $28 + constant TIM11_PSC
       TIM11 $2C + constant TIM11_ARR
       TIM11 $34 + constant TIM11_CCR1
       TIM11 $50 + constant TIM11_OR
        
	
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
       TIM5 $50 + constant TIM5_OR
        
	
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
        
	
     $40011000 constant USART1  
       USART1 $0 + constant USART1_SR
       USART1 $4 + constant USART1_DR
       USART1 $8 + constant USART1_BRR
       USART1 $C + constant USART1_CR1
       USART1 $10 + constant USART1_CR2
       USART1 $14 + constant USART1_CR3
       USART1 $18 + constant USART1_GTPR
        
	
     $40004400 constant USART2  
        
	
     $40011400 constant USART6  
        
	
     $40002C00 constant WWDG  
       WWDG $0 + constant WWDG_CR
       WWDG $4 + constant WWDG_CFR
       WWDG $8 + constant WWDG_SR
        
	
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
        
	
     $40021C00 constant GPIOH  
       GPIOH $0 + constant GPIOH_MODER
       GPIOH $4 + constant GPIOH_OTYPER
       GPIOH $8 + constant GPIOH_OSPEEDR
       GPIOH $C + constant GPIOH_PUPDR
       GPIOH $10 + constant GPIOH_IDR
       GPIOH $14 + constant GPIOH_ODR
       GPIOH $18 + constant GPIOH_BSRR
       GPIOH $1C + constant GPIOH_LCKR
       GPIOH $20 + constant GPIOH_AFRL
       GPIOH $24 + constant GPIOH_AFRH
        
	
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
        
	
     $40003400 constant I2S2ext  
       I2S2ext $0 + constant I2S2ext_CR1
       I2S2ext $4 + constant I2S2ext_CR2
       I2S2ext $8 + constant I2S2ext_SR
       I2S2ext $C + constant I2S2ext_DR
       I2S2ext $10 + constant I2S2ext_CRCPR
       I2S2ext $14 + constant I2S2ext_RXCRCR
       I2S2ext $18 + constant I2S2ext_TXCRCR
       I2S2ext $1C + constant I2S2ext_I2SCFGR
       I2S2ext $20 + constant I2S2ext_I2SPR
        
	
     $40004000 constant I2S3ext  
        
	
     $40013000 constant SPI1  
        
	
     $40003800 constant SPI2  
        
	
     $40003C00 constant SPI3  
        
	
     $40013400 constant SPI4  
        
	
     $40015000 constant SPI5  
        
	
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
        
compiletoram	
     
