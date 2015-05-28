\  STM32F10$x ARM CMSIS-SVD register file for Mecrisp-Stellaris Forth by Matthias Koch
	\  x = 0 or 1 below in the Register Field bit positions 
	 

    $A0000000 constant FSMC  
	 FSMC $0 + constant FSMC_BCR1	\ read-write		\  : RESET_FSMC_BCR1 $000030D0 
        \ %x  19 lshift FSMC_BCR1        \ FSMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FSMC_BCR1        \ FSMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FSMC_BCR1        \ FSMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FSMC_BCR1        \ FSMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FSMC_BCR1        \ FSMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FSMC_BCR1        \ FSMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  9 lshift FSMC_BCR1        \ FSMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FSMC_BCR1        \ FSMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FSMC_BCR1        \ FSMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FSMC_BCR1        \ FSMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FSMC_BCR1        \ FSMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FSMC_BCR1        \ FSMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FSMC_BCR1        \ FSMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FSMC $4 + constant FSMC_BTR1	\ read-write		\  : RESET_FSMC_BTR1 $FFFFFFFF 
        \ %xx  28 lshift FSMC_BTR1        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR1        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR1        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR1        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR1        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR1        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR1        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $8 + constant FSMC_BCR2	\ read-write		\  : RESET_FSMC_BCR2 $000030D0 
        \ %x  19 lshift FSMC_BCR2        \ FSMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FSMC_BCR2        \ FSMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FSMC_BCR2        \ FSMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FSMC_BCR2        \ FSMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FSMC_BCR2        \ FSMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FSMC_BCR2        \ FSMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FSMC_BCR2        \ FSMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FSMC_BCR2        \ FSMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FSMC_BCR2        \ FSMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FSMC_BCR2        \ FSMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FSMC_BCR2        \ FSMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FSMC_BCR2        \ FSMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FSMC_BCR2        \ FSMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FSMC_BCR2        \ FSMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FSMC $C + constant FSMC_BTR2	\ read-write		\  : RESET_FSMC_BTR2 $FFFFFFFF 
        \ %xx  28 lshift FSMC_BTR2        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR2        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR2        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR2        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR2        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR2        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR2        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $10 + constant FSMC_BCR3	\ read-write		\  : RESET_FSMC_BCR3 $000030D0 
        \ %x  19 lshift FSMC_BCR3        \ FSMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FSMC_BCR3        \ FSMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FSMC_BCR3        \ FSMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FSMC_BCR3        \ FSMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FSMC_BCR3        \ FSMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FSMC_BCR3        \ FSMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FSMC_BCR3        \ FSMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FSMC_BCR3        \ FSMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FSMC_BCR3        \ FSMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FSMC_BCR3        \ FSMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FSMC_BCR3        \ FSMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FSMC_BCR3        \ FSMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FSMC_BCR3        \ FSMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FSMC_BCR3        \ FSMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FSMC $14 + constant FSMC_BTR3	\ read-write		\  : RESET_FSMC_BTR3 $FFFFFFFF 
        \ %xx  28 lshift FSMC_BTR3        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR3        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR3        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR3        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR3        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR3        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR3        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $18 + constant FSMC_BCR4	\ read-write		\  : RESET_FSMC_BCR4 $000030D0 
        \ %x  19 lshift FSMC_BCR4        \ FSMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FSMC_BCR4        \ FSMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FSMC_BCR4        \ FSMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FSMC_BCR4        \ FSMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FSMC_BCR4        \ FSMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FSMC_BCR4        \ FSMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FSMC_BCR4        \ FSMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FSMC_BCR4        \ FSMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FSMC_BCR4        \ FSMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FSMC_BCR4        \ FSMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FSMC_BCR4        \ FSMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FSMC_BCR4        \ FSMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FSMC_BCR4        \ FSMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FSMC_BCR4        \ FSMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FSMC $1C + constant FSMC_BTR4	\ read-write		\  : RESET_FSMC_BTR4 $FFFFFFFF 
        \ %xx  28 lshift FSMC_BTR4        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR4        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR4        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR4        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR4        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR4        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR4        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $104 + constant FSMC_BWTR1	\ read-write		\  : RESET_FSMC_BWTR1 $0FFFFFFF 
        \ %xx  28 lshift FSMC_BWTR1        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR1        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR1        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR1        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR1        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR1        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $10C + constant FSMC_BWTR2	\ read-write		\  : RESET_FSMC_BWTR2 $0FFFFFFF 
        \ %xx  28 lshift FSMC_BWTR2        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR2        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR2        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR2        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR2        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR2        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $114 + constant FSMC_BWTR3	\ read-write		\  : RESET_FSMC_BWTR3 $0FFFFFFF 
        \ %xx  28 lshift FSMC_BWTR3        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR3        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR3        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR3        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR3        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR3        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $11C + constant FSMC_BWTR4	\ read-write		\  : RESET_FSMC_BWTR4 $0FFFFFFF 
        \ %xx  28 lshift FSMC_BWTR4        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR4        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR4        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR4        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR4        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR4        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
         
	
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
        \ %xxx  24 lshift RCC_CFGR        \ RCC_MCO	Bit Offset:24	Bit Width:3
        
        RCC $8 + constant RCC_CIR	\ 		\  : RESET_RCC_CIR $00000000 
        \ %x  0 lshift RCC_CIR        \ RCC_LSIRDYF	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_CIR        \ RCC_LSERDYF	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_CIR        \ RCC_HSIRDYF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_CIR        \ RCC_HSERDYF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_CIR        \ RCC_PLLRDYF	Bit Offset:4	Bit Width:1
        \ %x  7 lshift RCC_CIR        \ RCC_CSSF	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_CIR        \ RCC_LSIRDYIE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RCC_CIR        \ RCC_LSERDYIE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RCC_CIR        \ RCC_HSIRDYIE	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RCC_CIR        \ RCC_HSERDYIE	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_CIR        \ RCC_PLLRDYIE	Bit Offset:12	Bit Width:1
        \ %x  16 lshift RCC_CIR        \ RCC_LSIRDYC	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_CIR        \ RCC_LSERDYC	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_CIR        \ RCC_HSIRDYC	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_CIR        \ RCC_HSERDYC	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_CIR        \ RCC_PLLRDYC	Bit Offset:20	Bit Width:1
        \ %x  23 lshift RCC_CIR        \ RCC_CSSC	Bit Offset:23	Bit Width:1
        
        RCC $C + constant RCC_APB2RSTR	\ read-write		\  : RESET_RCC_APB2RSTR $000000000 
        \ %x  0 lshift RCC_APB2RSTR        \ RCC_AFIORST	Bit Offset:0	Bit Width:1
        \ %x  2 lshift RCC_APB2RSTR        \ RCC_IOPARST	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB2RSTR        \ RCC_IOPBRST	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB2RSTR        \ RCC_IOPCRST	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2RSTR        \ RCC_IOPDRST	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB2RSTR        \ RCC_IOPERST	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_APB2RSTR        \ RCC_IOPFRST	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_APB2RSTR        \ RCC_IOPGRST	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RCC_APB2RSTR        \ RCC_ADC1RST	Bit Offset:9	Bit Width:1
        \ %x  11 lshift RCC_APB2RSTR        \ RCC_TIM1RST	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2RSTR        \ RCC_SPI1RST	Bit Offset:12	Bit Width:1
        \ %x  14 lshift RCC_APB2RSTR        \ RCC_USART1RST	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RCC_APB2RSTR        \ RCC_TIM15RST	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_APB2RSTR        \ RCC_TIM16RST	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB2RSTR        \ RCC_TIM17RST	Bit Offset:18	Bit Width:1
        
        RCC $10 + constant RCC_APB1RSTR	\ read-write		\  : RESET_RCC_APB1RSTR $00000000 
        \ %x  0 lshift RCC_APB1RSTR        \ RCC_TIM2RST	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB1RSTR        \ RCC_TIM3RST	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_APB1RSTR        \ RCC_TIM4RST	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB1RSTR        \ RCC_TIM5RST	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB1RSTR        \ RCC_TIM6RST	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB1RSTR        \ RCC_TIM7RST	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB1RSTR        \ RCC_TIM12RST	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_APB1RSTR        \ RCC_TIM13RST	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_APB1RSTR        \ RCC_TIM14RST	Bit Offset:8	Bit Width:1
        \ %x  11 lshift RCC_APB1RSTR        \ RCC_WWDGRST	Bit Offset:11	Bit Width:1
        \ %x  14 lshift RCC_APB1RSTR        \ RCC_SPI2RST	Bit Offset:14	Bit Width:1
        \ %x  15 lshift RCC_APB1RSTR        \ RCC_SPI3RST	Bit Offset:15	Bit Width:1
        \ %x  17 lshift RCC_APB1RSTR        \ RCC_USART2RST	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB1RSTR        \ RCC_USART3RST	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_APB1RSTR        \ RCC_USART4RST	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_APB1RSTR        \ RCC_USART5RST	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB1RSTR        \ RCC_I2C1RST	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_APB1RSTR        \ RCC_I2C2RST	Bit Offset:22	Bit Width:1
        \ %x  27 lshift RCC_APB1RSTR        \ RCC_BKPRST	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_APB1RSTR        \ RCC_PWRRST	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1RSTR        \ RCC_DACRST	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_APB1RSTR        \ RCC_CECRST	Bit Offset:30	Bit Width:1
        
        RCC $14 + constant RCC_AHBENR	\ read-write		\  : RESET_RCC_AHBENR $00000014 
        \ %x  0 lshift RCC_AHBENR        \ RCC_DMA1EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_AHBENR        \ RCC_DMA2EN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_AHBENR        \ RCC_SRAMEN	Bit Offset:2	Bit Width:1
        \ %x  4 lshift RCC_AHBENR        \ RCC_FLITFEN	Bit Offset:4	Bit Width:1
        \ %x  6 lshift RCC_AHBENR        \ RCC_CRCEN	Bit Offset:6	Bit Width:1
        \ %x  8 lshift RCC_AHBENR        \ RCC_FSMCEN	Bit Offset:8	Bit Width:1
        
        RCC $18 + constant RCC_APB2ENR	\ read-write		\  : RESET_RCC_APB2ENR $00000000 
        \ %x  0 lshift RCC_APB2ENR        \ RCC_AFIOEN	Bit Offset:0	Bit Width:1
        \ %x  2 lshift RCC_APB2ENR        \ RCC_IOPAEN	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB2ENR        \ RCC_IOPBEN	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB2ENR        \ RCC_IOPCEN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2ENR        \ RCC_IOPDEN	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB2ENR        \ RCC_IOPEEN	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_APB2ENR        \ RCC_IOPFEN	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_APB2ENR        \ RCC_IOPGEN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RCC_APB2ENR        \ RCC_ADC1EN	Bit Offset:9	Bit Width:1
        \ %x  11 lshift RCC_APB2ENR        \ RCC_TIM1EN	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2ENR        \ RCC_SPI1EN	Bit Offset:12	Bit Width:1
        \ %x  14 lshift RCC_APB2ENR        \ RCC_USART1EN	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RCC_APB2ENR        \ RCC_TIM15EN	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_APB2ENR        \ RCC_TIM16EN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB2ENR        \ RCC_TIM17EN	Bit Offset:18	Bit Width:1
        
        RCC $1C + constant RCC_APB1ENR	\ read-write		\  : RESET_RCC_APB1ENR $00000000 
        \ %x  0 lshift RCC_APB1ENR        \ RCC_TIM2EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB1ENR        \ RCC_TIM3EN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_APB1ENR        \ RCC_TIM4EN	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB1ENR        \ RCC_TIM5EN	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB1ENR        \ RCC_TIM6EN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB1ENR        \ RCC_TIM7EN	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB1ENR        \ RCC_TIM12EN	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_APB1ENR        \ RCC_TIM13EN	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_APB1ENR        \ RCC_TIM14EN	Bit Offset:8	Bit Width:1
        \ %x  11 lshift RCC_APB1ENR        \ RCC_WWDGEN	Bit Offset:11	Bit Width:1
        \ %x  14 lshift RCC_APB1ENR        \ RCC_SPI2EN	Bit Offset:14	Bit Width:1
        \ %x  15 lshift RCC_APB1ENR        \ RCC_SPI3EN	Bit Offset:15	Bit Width:1
        \ %x  17 lshift RCC_APB1ENR        \ RCC_USART2EN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB1ENR        \ RCC_USART3EN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_APB1ENR        \ RCC_UART4EN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_APB1ENR        \ RCC_UART5EN	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB1ENR        \ RCC_I2C1EN	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_APB1ENR        \ RCC_I2C2EN	Bit Offset:22	Bit Width:1
        \ %x  27 lshift RCC_APB1ENR        \ RCC_BKPEN	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_APB1ENR        \ RCC_PWREN	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1ENR        \ RCC_DACEN	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_APB1ENR        \ RCC_CECEN	Bit Offset:30	Bit Width:1
        
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
        
        RCC $2C + constant RCC_CFGR2	\ read-write		\  : RESET_RCC_CFGR2 $00000000 
        \ %xxxx  0 lshift RCC_CFGR2        \ RCC_PREDIV1	Bit Offset:0	Bit Width:4
        
         
	
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
	  
	
     $40011C00 constant GPIOF  
	  
	
     $40012000 constant GPIOG  
	  
	
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
        \ %x  15 lshift AFIO_MAPR        \ AFIO_PD01_REMAP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift AFIO_MAPR        \ AFIO_TIM5CH4_IREMAP	Bit Offset:16	Bit Width:1
        \ %xxx  24 lshift AFIO_MAPR        \ AFIO_SWJ_CFG	Bit Offset:24	Bit Width:3
        
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
        \ %x  0 lshift AFIO_MAPR2        \ AFIO_TIM15_REMAP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift AFIO_MAPR2        \ AFIO_TIM16_REMAP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift AFIO_MAPR2        \ AFIO_TIM17_REMAP	Bit Offset:2	Bit Width:1
        \ %x  8 lshift AFIO_MAPR2        \ AFIO_TIM13_REMAP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift AFIO_MAPR2        \ AFIO_TIM14_REMAP	Bit Offset:9	Bit Width:1
        \ %x  10 lshift AFIO_MAPR2        \ AFIO_FSMC_NADV	Bit Offset:10	Bit Width:1
        \ %x  3 lshift AFIO_MAPR2        \ AFIO_CEC_REMAP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift AFIO_MAPR2        \ AFIO_TIM1_DMA_REMAP	Bit Offset:4	Bit Width:1
        \ %x  11 lshift AFIO_MAPR2        \ AFIO_TIM67_DAC_DMA_REMAP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift AFIO_MAPR2        \ AFIO_TIM12_REMAP	Bit Offset:12	Bit Width:1
        \ %x  13 lshift AFIO_MAPR2        \ AFIO_MISC_REMAP	Bit Offset:13	Bit Width:1
        
         
	
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
        \ %x  0 lshift TIM1_DIER        \ TIM1_UIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift TIM1_DIER        \ TIM1_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift TIM1_DIER        \ TIM1_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift TIM1_DIER        \ TIM1_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift TIM1_DIER        \ TIM1_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift TIM1_DIER        \ TIM1_COMIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift TIM1_DIER        \ TIM1_TIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift TIM1_DIER        \ TIM1_BIE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift TIM1_DIER        \ TIM1_UDE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift TIM1_DIER        \ TIM1_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift TIM1_DIER        \ TIM1_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  11 lshift TIM1_DIER        \ TIM1_CC3DE	Bit Offset:11	Bit Width:1
        \ %x  12 lshift TIM1_DIER        \ TIM1_CC4DE	Bit Offset:12	Bit Width:1
        \ %x  13 lshift TIM1_DIER        \ TIM1_COMDE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift TIM1_DIER        \ TIM1_TDE	Bit Offset:14	Bit Width:1
        
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
        \ %xxxx  15 lshift TIM1_CCMR1_Input        \ TIM1_IC2F	Bit Offset:15	Bit Width:4
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
        \ %xxxx  15 lshift TIM1_CCMR2_Input        \ TIM1_IC4F	Bit Offset:15	Bit Width:4
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
        \ %x  3 lshift TIM2_SMCR        \ TIM2_OCCS	Bit Offset:3	Bit Width:1
        
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
	  
	
     $40001800 constant TIM12  
	 TIM12 $0 + constant TIM12_CR1	\ read-write		\  : RESET_TIM12_CR1 $0000 
        \ %xx  8 lshift TIM12_CR1        \ TIM12_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM12_CR1        \ TIM12_ARPE	Bit Offset:7	Bit Width:1
        \ %x  3 lshift TIM12_CR1        \ TIM12_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM12_CR1        \ TIM12_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM12_CR1        \ TIM12_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM12_CR1        \ TIM12_CEN	Bit Offset:0	Bit Width:1
        
        TIM12 $4 + constant TIM12_CR2	\ read-write		\  : RESET_TIM12_CR2 $0000 
        \ %xxx  4 lshift TIM12_CR2        \ TIM12_MMS	Bit Offset:4	Bit Width:3
        
        TIM12 $8 + constant TIM12_SMCR	\ read-write		\  : RESET_TIM12_SMCR $0000 
        \ %x  7 lshift TIM12_SMCR        \ TIM12_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM12_SMCR        \ TIM12_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM12_SMCR        \ TIM12_SMS	Bit Offset:0	Bit Width:3
        
        TIM12 $C + constant TIM12_DIER	\ read-write		\  : RESET_TIM12_DIER $0000 
        \ %x  6 lshift TIM12_DIER        \ TIM12_TIE	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM12_DIER        \ TIM12_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM12_DIER        \ TIM12_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM12_DIER        \ TIM12_UIE	Bit Offset:0	Bit Width:1
        
        TIM12 $10 + constant TIM12_SR	\ read-write		\  : RESET_TIM12_SR $0000 
        \ %x  10 lshift TIM12_SR        \ TIM12_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM12_SR        \ TIM12_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM12_SR        \ TIM12_TIF	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM12_SR        \ TIM12_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM12_SR        \ TIM12_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM12_SR        \ TIM12_UIF	Bit Offset:0	Bit Width:1
        
        TIM12 $14 + constant TIM12_EGR	\ write-only		\  : RESET_TIM12_EGR $0000 
        \ %x  6 lshift TIM12_EGR        \ TIM12_TG	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM12_EGR        \ TIM12_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM12_EGR        \ TIM12_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM12_EGR        \ TIM12_UG	Bit Offset:0	Bit Width:1
        
        TIM12 $18 + constant TIM12_CCMR1_Output	\ read-write		\  : RESET_TIM12_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM12_CCMR1_Output        \ TIM12_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM12_CCMR1_Output        \ TIM12_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM12_CCMR1_Output        \ TIM12_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM12_CCMR1_Output        \ TIM12_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM12_CCMR1_Output        \ TIM12_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM12_CCMR1_Output        \ TIM12_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM12_CCMR1_Output        \ TIM12_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM12_CCMR1_Output        \ TIM12_CC1S	Bit Offset:0	Bit Width:2
        
        TIM12 $18 + constant TIM12_CCMR1_Input	\ read-write		\  : RESET_TIM12_CCMR1_Input $00000000 
        \ %xxx  12 lshift TIM12_CCMR1_Input        \ TIM12_IC2F	Bit Offset:12	Bit Width:3
        \ %xx  10 lshift TIM12_CCMR1_Input        \ TIM12_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM12_CCMR1_Input        \ TIM12_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM12_CCMR1_Input        \ TIM12_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM12_CCMR1_Input        \ TIM12_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM12_CCMR1_Input        \ TIM12_CC1S	Bit Offset:0	Bit Width:2
        
        TIM12 $20 + constant TIM12_CCER	\ read-write		\  : RESET_TIM12_CCER $0000 
        \ %x  7 lshift TIM12_CCER        \ TIM12_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM12_CCER        \ TIM12_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM12_CCER        \ TIM12_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM12_CCER        \ TIM12_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM12_CCER        \ TIM12_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM12_CCER        \ TIM12_CC1E	Bit Offset:0	Bit Width:1
        
        TIM12 $24 + constant TIM12_CNT	\ read-write		\  : RESET_TIM12_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM12_CNT        \ TIM12_CNT	Bit Offset:0	Bit Width:16
        
        TIM12 $28 + constant TIM12_PSC	\ read-write		\  : RESET_TIM12_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM12_PSC        \ TIM12_PSC	Bit Offset:0	Bit Width:16
        
        TIM12 $2C + constant TIM12_ARR	\ read-write		\  : RESET_TIM12_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM12_ARR        \ TIM12_ARR	Bit Offset:0	Bit Width:16
        
        TIM12 $34 + constant TIM12_CCR1	\ read-write		\  : RESET_TIM12_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM12_CCR1        \ TIM12_CCR1	Bit Offset:0	Bit Width:16
        
        TIM12 $38 + constant TIM12_CCR2	\ read-write		\  : RESET_TIM12_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM12_CCR2        \ TIM12_CCR2	Bit Offset:0	Bit Width:16
        
         
	
     $40001C00 constant TIM13  
	 TIM13 $0 + constant TIM13_CR1	\ read-write		\  : RESET_TIM13_CR1 $0000 
        \ %xx  8 lshift TIM13_CR1        \ TIM13_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM13_CR1        \ TIM13_ARPE	Bit Offset:7	Bit Width:1
        \ %x  2 lshift TIM13_CR1        \ TIM13_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM13_CR1        \ TIM13_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM13_CR1        \ TIM13_CEN	Bit Offset:0	Bit Width:1
        
        TIM13 $C + constant TIM13_DIER	\ read-write		\  : RESET_TIM13_DIER $0000 
        \ %x  1 lshift TIM13_DIER        \ TIM13_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM13_DIER        \ TIM13_UIE	Bit Offset:0	Bit Width:1
        
        TIM13 $10 + constant TIM13_SR	\ read-write		\  : RESET_TIM13_SR $0000 
        \ %x  9 lshift TIM13_SR        \ TIM13_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  1 lshift TIM13_SR        \ TIM13_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM13_SR        \ TIM13_UIF	Bit Offset:0	Bit Width:1
        
        TIM13 $14 + constant TIM13_EGR	\ write-only		\  : RESET_TIM13_EGR $0000 
        \ %x  1 lshift TIM13_EGR        \ TIM13_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM13_EGR        \ TIM13_UG	Bit Offset:0	Bit Width:1
        
        TIM13 $18 + constant TIM13_CCMR1_Output	\ read-write		\  : RESET_TIM13_CCMR1_Output $00000000 
        \ %xx  0 lshift TIM13_CCMR1_Output        \ TIM13_CC1S	Bit Offset:0	Bit Width:2
        \ %x  2 lshift TIM13_CCMR1_Output        \ TIM13_OC1FE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift TIM13_CCMR1_Output        \ TIM13_OC1PE	Bit Offset:3	Bit Width:1
        \ %xxx  4 lshift TIM13_CCMR1_Output        \ TIM13_OC1M	Bit Offset:4	Bit Width:3
        
        TIM13 $18 + constant TIM13_CCMR1_Input	\ read-write		\  : RESET_TIM13_CCMR1_Input $00000000 
        \ %xxxx  4 lshift TIM13_CCMR1_Input        \ TIM13_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM13_CCMR1_Input        \ TIM13_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM13_CCMR1_Input        \ TIM13_CC1S	Bit Offset:0	Bit Width:2
        
        TIM13 $20 + constant TIM13_CCER	\ read-write		\  : RESET_TIM13_CCER $0000 
        \ %x  3 lshift TIM13_CCER        \ TIM13_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM13_CCER        \ TIM13_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM13_CCER        \ TIM13_CC1E	Bit Offset:0	Bit Width:1
        
        TIM13 $24 + constant TIM13_CNT	\ read-write		\  : RESET_TIM13_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM13_CNT        \ TIM13_CNT	Bit Offset:0	Bit Width:16
        
        TIM13 $28 + constant TIM13_PSC	\ read-write		\  : RESET_TIM13_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM13_PSC        \ TIM13_PSC	Bit Offset:0	Bit Width:16
        
        TIM13 $2C + constant TIM13_ARR	\ read-write		\  : RESET_TIM13_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM13_ARR        \ TIM13_ARR	Bit Offset:0	Bit Width:16
        
        TIM13 $34 + constant TIM13_CCR1	\ read-write		\  : RESET_TIM13_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM13_CCR1        \ TIM13_CCR1	Bit Offset:0	Bit Width:16
        
         
	
     $40002000 constant TIM14  
	  
	
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
        \ %x  13 lshift DAC_CR        \ DAC_DMAUDRIE1	Bit Offset:13	Bit Width:1
        \ %x  29 lshift DAC_CR        \ DAC_DMAUDRIE2	Bit Offset:29	Bit Width:1
        
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
        
        DAC $34 + constant DAC_SR	\ read-write		\  : RESET_DAC_SR $00000000 
        \ %x  13 lshift DAC_SR        \ DAC_DMAUDR1	Bit Offset:13	Bit Width:1
        \ %x  29 lshift DAC_SR        \ DAC_DMAUDR2	Bit Offset:29	Bit Width:1
        
         
	
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
        \ %x  15 lshift DBG_CR        \ DBG_DBG_I2C1_SMBUS_TIMEOUT	Bit Offset:15	Bit Width:1
        \ %x  16 lshift DBG_CR        \ DBG_DBG_I2C2_SMBUS_TIMEOUT	Bit Offset:16	Bit Width:1
        \ %x  18 lshift DBG_CR        \ DBG_DBG_TIM5_STOP	Bit Offset:18	Bit Width:1
        \ %x  19 lshift DBG_CR        \ DBG_DBG_TIM6_STOP	Bit Offset:19	Bit Width:1
        \ %x  20 lshift DBG_CR        \ DBG_DBG_TIM7_STOP	Bit Offset:20	Bit Width:1
        \ %x  22 lshift DBG_CR        \ DBG_DBG_TIM15_STOP	Bit Offset:22	Bit Width:1
        \ %x  23 lshift DBG_CR        \ DBG_DBG_TIM16_STOP	Bit Offset:23	Bit Width:1
        \ %x  24 lshift DBG_CR        \ DBG_DBG_TIM17_STOP	Bit Offset:24	Bit Width:1
        \ %x  25 lshift DBG_CR        \ DBG_DBG_TIM12_STOP	Bit Offset:25	Bit Width:1
        \ %x  26 lshift DBG_CR        \ DBG_DBG_TIM13_STOP	Bit Offset:26	Bit Width:1
        \ %x  27 lshift DBG_CR        \ DBG_DBG_TIM14_STOP	Bit Offset:27	Bit Width:1
        
         
	
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
	 FLASH $0 + constant FLASH_ACR	\ read-write		\  : RESET_FLASH_ACR $00000000 
        \ %x  3 lshift FLASH_ACR        \ FLASH_HLFCYA	Bit Offset:3	Bit Width:1
        
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
        
         
	
     $40014000 constant TIM15  
	 TIM15 $0 + constant TIM15_CR1	\ read-write		\  : RESET_TIM15_CR1 $0000 
        \ %xx  8 lshift TIM15_CR1        \ TIM15_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM15_CR1        \ TIM15_ARPE	Bit Offset:7	Bit Width:1
        \ %x  3 lshift TIM15_CR1        \ TIM15_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM15_CR1        \ TIM15_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM15_CR1        \ TIM15_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM15_CR1        \ TIM15_CEN	Bit Offset:0	Bit Width:1
        
        TIM15 $4 + constant TIM15_CR2	\ read-write		\  : RESET_TIM15_CR2 $0000 
        \ %x  10 lshift TIM15_CR2        \ TIM15_OIS2	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM15_CR2        \ TIM15_OIS1N	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM15_CR2        \ TIM15_OIS1	Bit Offset:8	Bit Width:1
        \ %xxx  4 lshift TIM15_CR2        \ TIM15_MMS	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM15_CR2        \ TIM15_CCDS	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM15_CR2        \ TIM15_CCUS	Bit Offset:2	Bit Width:1
        \ %x  0 lshift TIM15_CR2        \ TIM15_CCPC	Bit Offset:0	Bit Width:1
        
        TIM15 $8 + constant TIM15_SMCR	\ read-write		\  : RESET_TIM15_SMCR $0000 
        \ %x  7 lshift TIM15_SMCR        \ TIM15_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM15_SMCR        \ TIM15_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM15_SMCR        \ TIM15_SMS	Bit Offset:0	Bit Width:3
        
        TIM15 $C + constant TIM15_DIER	\ read-write		\  : RESET_TIM15_DIER $0000 
        \ %x  14 lshift TIM15_DIER        \ TIM15_TDE	Bit Offset:14	Bit Width:1
        \ %x  10 lshift TIM15_DIER        \ TIM15_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM15_DIER        \ TIM15_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM15_DIER        \ TIM15_UDE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM15_DIER        \ TIM15_BIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM15_DIER        \ TIM15_TIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM15_DIER        \ TIM15_COMIE	Bit Offset:5	Bit Width:1
        \ %x  2 lshift TIM15_DIER        \ TIM15_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM15_DIER        \ TIM15_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM15_DIER        \ TIM15_UIE	Bit Offset:0	Bit Width:1
        
        TIM15 $10 + constant TIM15_SR	\ read-write		\  : RESET_TIM15_SR $0000 
        \ %x  10 lshift TIM15_SR        \ TIM15_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM15_SR        \ TIM15_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  7 lshift TIM15_SR        \ TIM15_BIF	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM15_SR        \ TIM15_TIF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM15_SR        \ TIM15_COMIF	Bit Offset:5	Bit Width:1
        \ %x  2 lshift TIM15_SR        \ TIM15_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM15_SR        \ TIM15_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM15_SR        \ TIM15_UIF	Bit Offset:0	Bit Width:1
        
        TIM15 $14 + constant TIM15_EGR	\ write-only		\  : RESET_TIM15_EGR $0000 
        \ %x  7 lshift TIM15_EGR        \ TIM15_BG	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM15_EGR        \ TIM15_TG	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM15_EGR        \ TIM15_COMG	Bit Offset:5	Bit Width:1
        \ %x  2 lshift TIM15_EGR        \ TIM15_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM15_EGR        \ TIM15_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM15_EGR        \ TIM15_UG	Bit Offset:0	Bit Width:1
        
        TIM15 $18 + constant TIM15_CCMR1_Output	\ read-write		\  : RESET_TIM15_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM15_CCMR1_Output        \ TIM15_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM15_CCMR1_Output        \ TIM15_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM15_CCMR1_Output        \ TIM15_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM15_CCMR1_Output        \ TIM15_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM15_CCMR1_Output        \ TIM15_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM15_CCMR1_Output        \ TIM15_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM15_CCMR1_Output        \ TIM15_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM15_CCMR1_Output        \ TIM15_CC1S	Bit Offset:0	Bit Width:2
        
        TIM15 $18 + constant TIM15_CCMR1_Input	\ read-write		\  : RESET_TIM15_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM15_CCMR1_Input        \ TIM15_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM15_CCMR1_Input        \ TIM15_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM15_CCMR1_Input        \ TIM15_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM15_CCMR1_Input        \ TIM15_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM15_CCMR1_Input        \ TIM15_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM15_CCMR1_Input        \ TIM15_CC1S	Bit Offset:0	Bit Width:2
        
        TIM15 $20 + constant TIM15_CCER	\ read-write		\  : RESET_TIM15_CCER $0000 
        \ %x  7 lshift TIM15_CCER        \ TIM15_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM15_CCER        \ TIM15_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM15_CCER        \ TIM15_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM15_CCER        \ TIM15_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM15_CCER        \ TIM15_CC1NE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM15_CCER        \ TIM15_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM15_CCER        \ TIM15_CC1E	Bit Offset:0	Bit Width:1
        
        TIM15 $24 + constant TIM15_CNT	\ read-write		\  : RESET_TIM15_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM15_CNT        \ TIM15_CNT	Bit Offset:0	Bit Width:16
        
        TIM15 $28 + constant TIM15_PSC	\ read-write		\  : RESET_TIM15_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM15_PSC        \ TIM15_PSC	Bit Offset:0	Bit Width:16
        
        TIM15 $2C + constant TIM15_ARR	\ read-write		\  : RESET_TIM15_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM15_ARR        \ TIM15_ARR	Bit Offset:0	Bit Width:16
        
        TIM15 $30 + constant TIM15_RCR	\ read-write		\  : RESET_TIM15_RCR $0000 
        \ %xxxxxxxx  0 lshift TIM15_RCR        \ TIM15_REP	Bit Offset:0	Bit Width:8
        
        TIM15 $34 + constant TIM15_CCR1	\ read-write		\  : RESET_TIM15_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM15_CCR1        \ TIM15_CCR1	Bit Offset:0	Bit Width:16
        
        TIM15 $38 + constant TIM15_CCR2	\ read-write		\  : RESET_TIM15_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM15_CCR2        \ TIM15_CCR2	Bit Offset:0	Bit Width:16
        
        TIM15 $44 + constant TIM15_BDTR	\ read-write		\  : RESET_TIM15_BDTR $0000 
        \ %x  15 lshift TIM15_BDTR        \ TIM15_MOE	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM15_BDTR        \ TIM15_AOE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TIM15_BDTR        \ TIM15_BKP	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM15_BDTR        \ TIM15_BKE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM15_BDTR        \ TIM15_OSSR	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM15_BDTR        \ TIM15_OSSI	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM15_BDTR        \ TIM15_LOCK	Bit Offset:8	Bit Width:2
        \ %xxxxxxxx  0 lshift TIM15_BDTR        \ TIM15_DTG	Bit Offset:0	Bit Width:8
        
        TIM15 $48 + constant TIM15_DCR	\ read-write		\  : RESET_TIM15_DCR $0000 
        \ %xxxxx  8 lshift TIM15_DCR        \ TIM15_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM15_DCR        \ TIM15_DBA	Bit Offset:0	Bit Width:5
        
        TIM15 $4C + constant TIM15_DMAR	\ read-write		\  : RESET_TIM15_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM15_DMAR        \ TIM15_DMAB	Bit Offset:0	Bit Width:16
        
         
	
     $40014400 constant TIM16  
	 TIM16 $0 + constant TIM16_CR1	\ read-write		\  : RESET_TIM16_CR1 $0000 
        \ %xx  8 lshift TIM16_CR1        \ TIM16_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM16_CR1        \ TIM16_ARPE	Bit Offset:7	Bit Width:1
        \ %x  3 lshift TIM16_CR1        \ TIM16_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM16_CR1        \ TIM16_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM16_CR1        \ TIM16_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM16_CR1        \ TIM16_CEN	Bit Offset:0	Bit Width:1
        
        TIM16 $4 + constant TIM16_CR2	\ read-write		\  : RESET_TIM16_CR2 $0000 
        \ %x  9 lshift TIM16_CR2        \ TIM16_OIS1N	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM16_CR2        \ TIM16_OIS1	Bit Offset:8	Bit Width:1
        \ %x  3 lshift TIM16_CR2        \ TIM16_CCDS	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM16_CR2        \ TIM16_CCUS	Bit Offset:2	Bit Width:1
        \ %x  0 lshift TIM16_CR2        \ TIM16_CCPC	Bit Offset:0	Bit Width:1
        
        TIM16 $C + constant TIM16_DIER	\ read-write		\  : RESET_TIM16_DIER $0000 
        \ %x  14 lshift TIM16_DIER        \ TIM16_TDE	Bit Offset:14	Bit Width:1
        \ %x  9 lshift TIM16_DIER        \ TIM16_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM16_DIER        \ TIM16_UDE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM16_DIER        \ TIM16_BIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM16_DIER        \ TIM16_TIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM16_DIER        \ TIM16_COMIE	Bit Offset:5	Bit Width:1
        \ %x  1 lshift TIM16_DIER        \ TIM16_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM16_DIER        \ TIM16_UIE	Bit Offset:0	Bit Width:1
        
        TIM16 $10 + constant TIM16_SR	\ read-write		\  : RESET_TIM16_SR $0000 
        \ %x  9 lshift TIM16_SR        \ TIM16_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  7 lshift TIM16_SR        \ TIM16_BIF	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM16_SR        \ TIM16_TIF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM16_SR        \ TIM16_COMIF	Bit Offset:5	Bit Width:1
        \ %x  1 lshift TIM16_SR        \ TIM16_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM16_SR        \ TIM16_UIF	Bit Offset:0	Bit Width:1
        
        TIM16 $14 + constant TIM16_EGR	\ write-only		\  : RESET_TIM16_EGR $0000 
        \ %x  7 lshift TIM16_EGR        \ TIM16_BG	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM16_EGR        \ TIM16_TG	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM16_EGR        \ TIM16_COMG	Bit Offset:5	Bit Width:1
        \ %x  1 lshift TIM16_EGR        \ TIM16_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM16_EGR        \ TIM16_UG	Bit Offset:0	Bit Width:1
        
        TIM16 $18 + constant TIM16_CCMR1_Output	\ read-write		\  : RESET_TIM16_CCMR1_Output $00000000 
        \ %xxx  4 lshift TIM16_CCMR1_Output        \ TIM16_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM16_CCMR1_Output        \ TIM16_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM16_CCMR1_Output        \ TIM16_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM16_CCMR1_Output        \ TIM16_CC1S	Bit Offset:0	Bit Width:2
        
        TIM16 $18 + constant TIM16_CCMR1_Input	\ read-write		\  : RESET_TIM16_CCMR1_Input $00000000 
        \ %xxxx  4 lshift TIM16_CCMR1_Input        \ TIM16_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM16_CCMR1_Input        \ TIM16_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM16_CCMR1_Input        \ TIM16_CC1S	Bit Offset:0	Bit Width:2
        
        TIM16 $20 + constant TIM16_CCER	\ read-write		\  : RESET_TIM16_CCER $0000 
        \ %x  3 lshift TIM16_CCER        \ TIM16_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM16_CCER        \ TIM16_CC1NE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM16_CCER        \ TIM16_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM16_CCER        \ TIM16_CC1E	Bit Offset:0	Bit Width:1
        
        TIM16 $24 + constant TIM16_CNT	\ read-write		\  : RESET_TIM16_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM16_CNT        \ TIM16_CNT	Bit Offset:0	Bit Width:16
        
        TIM16 $28 + constant TIM16_PSC	\ read-write		\  : RESET_TIM16_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM16_PSC        \ TIM16_PSC	Bit Offset:0	Bit Width:16
        
        TIM16 $2C + constant TIM16_ARR	\ read-write		\  : RESET_TIM16_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM16_ARR        \ TIM16_ARR	Bit Offset:0	Bit Width:16
        
        TIM16 $30 + constant TIM16_RCR	\ read-write		\  : RESET_TIM16_RCR $0000 
        \ %xxxxxxxx  0 lshift TIM16_RCR        \ TIM16_REP	Bit Offset:0	Bit Width:8
        
        TIM16 $34 + constant TIM16_CCR1	\ read-write		\  : RESET_TIM16_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM16_CCR1        \ TIM16_CCR1	Bit Offset:0	Bit Width:16
        
        TIM16 $44 + constant TIM16_BDTR	\ read-write		\  : RESET_TIM16_BDTR $0000 
        \ %x  15 lshift TIM16_BDTR        \ TIM16_MOE	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM16_BDTR        \ TIM16_AOE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TIM16_BDTR        \ TIM16_BKP	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM16_BDTR        \ TIM16_BKE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM16_BDTR        \ TIM16_OSSR	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM16_BDTR        \ TIM16_OSSI	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM16_BDTR        \ TIM16_LOCK	Bit Offset:8	Bit Width:2
        \ %xxxxxxxx  0 lshift TIM16_BDTR        \ TIM16_DTG	Bit Offset:0	Bit Width:8
        
        TIM16 $48 + constant TIM16_DCR	\ read-write		\  : RESET_TIM16_DCR $0000 
        \ %xxxxx  8 lshift TIM16_DCR        \ TIM16_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM16_DCR        \ TIM16_DBA	Bit Offset:0	Bit Width:5
        
        TIM16 $4C + constant TIM16_DMAR	\ read-write		\  : RESET_TIM16_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM16_DMAR        \ TIM16_DMAB	Bit Offset:0	Bit Width:16
        
         
	
     $40014800 constant TIM17  
	  
	
     $40007800 constant CEC  
	 CEC $0 + constant CEC_CFGR	\ read-write		\  : RESET_CEC_CFGR $00000000 
        \ %x  0 lshift CEC_CFGR        \ CEC_PE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CEC_CFGR        \ CEC_IE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CEC_CFGR        \ CEC_BTEM	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CEC_CFGR        \ CEC_BPEM	Bit Offset:3	Bit Width:1
        
        CEC $4 + constant CEC_OAR	\ read-write		\  : RESET_CEC_OAR $00000000 
        \ %xxxx  0 lshift CEC_OAR        \ CEC_OA	Bit Offset:0	Bit Width:4
        
        CEC $8 + constant CEC_PRES	\ read-write		\  : RESET_CEC_PRES $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift CEC_PRES        \ CEC_PRESC	Bit Offset:0	Bit Width:14
        
        CEC $C + constant CEC_ESR	\ read-only		\  : RESET_CEC_ESR $00000000 
        \ %x  0 lshift CEC_ESR        \ CEC_BTE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CEC_ESR        \ CEC_BPE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CEC_ESR        \ CEC_RBTFE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CEC_ESR        \ CEC_SBE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CEC_ESR        \ CEC_ACKE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CEC_ESR        \ CEC_LINE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CEC_ESR        \ CEC_TBTFE	Bit Offset:6	Bit Width:1
        
        CEC $10 + constant CEC_CSR	\ read-write		\  : RESET_CEC_CSR $00000000 
        \ %x  0 lshift CEC_CSR        \ CEC_TSOM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CEC_CSR        \ CEC_TEOM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CEC_CSR        \ CEC_TERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CEC_CSR        \ CEC_TBTRF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CEC_CSR        \ CEC_RSOM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CEC_CSR        \ CEC_REOM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CEC_CSR        \ CEC_RERR	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CEC_CSR        \ CEC_RBTF	Bit Offset:7	Bit Width:1
        
        CEC $14 + constant CEC_TXD	\ read-write		\  : RESET_CEC_TXD $00000000 
        \ %xxxxxxxx  0 lshift CEC_TXD        \ CEC_TXD	Bit Offset:0	Bit Width:8
        
        CEC $18 + constant CEC_RXD	\ read-only		\  : RESET_CEC_RXD $00000000 
        \ %xxxxxxxx  0 lshift CEC_RXD        \ CEC_RXD	Bit Offset:0	Bit Width:8
        
         
	
     $E000E000 constant NVIC  
	 NVIC $4 + constant NVIC_ICTR	\ read-only		\  : RESET_NVIC_ICTR $00000000 
        \ %xxxx  0 lshift NVIC_ICTR        \ NVIC_INTLINESNUM	Bit Offset:0	Bit Width:4
        
        NVIC $F00 + constant NVIC_STIR	\ write-only		\  : RESET_NVIC_STIR $00000000 
        \ %xxxxxxxxx  0 lshift NVIC_STIR        \ NVIC_INTID	Bit Offset:0	Bit Width:9
        
        NVIC $100 + constant NVIC_ISER0	\ read-write		\  : RESET_NVIC_ISER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER0        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $104 + constant NVIC_ISER1	\ read-write		\  : RESET_NVIC_ISER1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER1        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $180 + constant NVIC_ICER0	\ read-write		\  : RESET_NVIC_ICER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER0        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $184 + constant NVIC_ICER1	\ read-write		\  : RESET_NVIC_ICER1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER1        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $200 + constant NVIC_ISPR0	\ read-write		\  : RESET_NVIC_ISPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR0        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $204 + constant NVIC_ISPR1	\ read-write		\  : RESET_NVIC_ISPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR1        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $280 + constant NVIC_ICPR0	\ read-write		\  : RESET_NVIC_ICPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR0        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $284 + constant NVIC_ICPR1	\ read-write		\  : RESET_NVIC_ICPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR1        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $300 + constant NVIC_IABR0	\ read-only		\  : RESET_NVIC_IABR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR0        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
        NVIC $304 + constant NVIC_IABR1	\ read-only		\  : RESET_NVIC_IABR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR1        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
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
        
         
	
     