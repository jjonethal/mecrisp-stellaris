\  STM32W108 ARM CMSIS-SVD register file for Mecrisp-Stellaris Forth by Matthias Koch
	\  x = 0 or 1 below in the Register Field bit positions 
	 

    $4000A800 constant TIM1  
	 TIM1 $0 + constant TIM1_TIM1_ISR	\ 		\  : RESET_TIM1_TIM1_ISR $00000000 
        \ %xxxxx  8 lshift TIM1_TIM1_ISR        \ TIM1_RSVD	Bit Offset:8	Bit Width:5
        \ %x  6 lshift TIM1_TIM1_ISR        \ TIM1_TIF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM1_TIM1_ISR        \ TIM1_CC4IF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_TIM1_ISR        \ TIM1_CC3IF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_ISR        \ TIM1_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_TIM1_ISR        \ TIM1_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_TIM1_ISR        \ TIM1_UIF	Bit Offset:0	Bit Width:1
        
        TIM1 $18 + constant TIM1_TIM1_MISSR	\ 		\  : RESET_TIM1_TIM1_MISSR $00000000 
        \ %x  12 lshift TIM1_TIM1_MISSR        \ TIM1_CC4IM	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_TIM1_MISSR        \ TIM1_CC3IM	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_TIM1_MISSR        \ TIM1_CC2IM	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM1_TIM1_MISSR        \ TIM1_CC1IM	Bit Offset:9	Bit Width:1
        \ %xxxxxxx  0 lshift TIM1_TIM1_MISSR        \ TIM1_RSVD	Bit Offset:0	Bit Width:7
        
        TIM1 $3800 + constant TIM1_TIM1_CR1	\ read-write		\  : RESET_TIM1_TIM1_CR1 $00000000 
        \ %x  7 lshift TIM1_TIM1_CR1        \ TIM1_ARBE	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift TIM1_TIM1_CR1        \ TIM1_CMS	Bit Offset:5	Bit Width:2
        \ %x  4 lshift TIM1_TIM1_CR1        \ TIM1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_TIM1_CR1        \ TIM1_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_CR1        \ TIM1_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_TIM1_CR1        \ TIM1_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_TIM1_CR1        \ TIM1_CEN	Bit Offset:0	Bit Width:1
        
        TIM1 $40 + constant TIM1_TIM1_IER	\ read-write		\  : RESET_TIM1_TIM1_IER $00000000 
        \ %x  6 lshift TIM1_TIM1_IER        \ TIM1_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM1_TIM1_IER        \ TIM1_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_TIM1_IER        \ TIM1_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_IER        \ TIM1_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_TIM1_IER        \ TIM1_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_TIM1_IER        \ TIM1_UIE	Bit Offset:0	Bit Width:1
        
        TIM1 $3804 + constant TIM1_TIM1_CR2	\ read-write		\  : RESET_TIM1_TIM1_CR2 $00000000 
        \ %x  7 lshift TIM1_TIM1_CR2        \ TIM1_TI1S	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM1_TIM1_CR2        \ TIM1_MMS	Bit Offset:4	Bit Width:3
        
        TIM1 $3808 + constant TIM1_TIM1_SMCR	\ read-write		\  : RESET_TIM1_TIM1_SMCR $00000000 
        \ %x  15 lshift TIM1_TIM1_SMCR        \ TIM1_ETP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM1_TIM1_SMCR        \ TIM1_ECE	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift TIM1_TIM1_SMCR        \ TIM1_ETPS	Bit Offset:12	Bit Width:2
        \ %xxxx  8 lshift TIM1_TIM1_SMCR        \ TIM1_ETF	Bit Offset:8	Bit Width:4
        \ %x  7 lshift TIM1_TIM1_SMCR        \ TIM1_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM1_TIM1_SMCR        \ TIM1_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM1_TIM1_SMCR        \ TIM1_SMS	Bit Offset:0	Bit Width:3
        
        TIM1 $3814 + constant TIM1_TIM1_EGR	\ write-only		\  : RESET_TIM1_TIM1_EGR $00000000 
        \ %x  6 lshift TIM1_TIM1_EGR        \ TIM1_TG	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM1_TIM1_EGR        \ TIM1_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_TIM1_EGR        \ TIM1_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_EGR        \ TIM1_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_TIM1_EGR        \ TIM1_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_TIM1_EGR        \ TIM1_UG	Bit Offset:0	Bit Width:1
        
        TIM1 $3818 + constant TIM1_TIM1_CCMR1_Input	\ read-write		\  : RESET_TIM1_TIM1_CCMR1_Input $00000000 
        \ %xx  0 lshift TIM1_TIM1_CCMR1_Input        \ TIM1_CC1S	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift TIM1_TIM1_CCMR1_Input        \ TIM1_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xxxx  4 lshift TIM1_TIM1_CCMR1_Input        \ TIM1_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  8 lshift TIM1_TIM1_CCMR1_Input        \ TIM1_CC2S	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift TIM1_TIM1_CCMR1_Input        \ TIM1_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xxxx  12 lshift TIM1_TIM1_CCMR1_Input        \ TIM1_IC2F	Bit Offset:12	Bit Width:4
        
        TIM1 $3818 + constant TIM1_TIM1_CCMR1_Output	\ read-write		\  : RESET_TIM1_TIM1_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM1_TIM1_CCMR1_Output        \ TIM1_CC1S	Bit Offset:0	Bit Width:2
        
        TIM1 $381C + constant TIM1_TIM1_CCMR2_Input	\ read-write		\  : RESET_TIM1_TIM1_CCMR2_Input $00000000 
        \ %xx  0 lshift TIM1_TIM1_CCMR2_Input        \ TIM1_CC3S	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift TIM1_TIM1_CCMR2_Input        \ TIM1_IC3PSC	Bit Offset:2	Bit Width:2
        \ %xxxx  4 lshift TIM1_TIM1_CCMR2_Input        \ TIM1_IC3F	Bit Offset:4	Bit Width:4
        \ %xx  8 lshift TIM1_TIM1_CCMR2_Input        \ TIM1_CC4S	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift TIM1_TIM1_CCMR2_Input        \ TIM1_IC4PSC	Bit Offset:10	Bit Width:2
        \ %xxxx  12 lshift TIM1_TIM1_CCMR2_Input        \ TIM1_IC4F	Bit Offset:12	Bit Width:4
        
        TIM1 $381C + constant TIM1_TIM1_CCMR2_Output	\ read-write		\  : RESET_TIM1_TIM1_CCMR2_Output $00000000 
        \ %xxx  12 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_OC4FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_CC4S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_OC3M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_OC3PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_OC3FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM1_TIM1_CCMR2_Output        \ TIM1_CC3S	Bit Offset:0	Bit Width:2
        
        TIM1 $3820 + constant TIM1_TIM1_CCER	\ read-write		\  : RESET_TIM1_TIM1_CCER $00000000 
        \ %x  13 lshift TIM1_TIM1_CCER        \ TIM1_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM1_TIM1_CCER        \ TIM1_CC4E	Bit Offset:12	Bit Width:1
        \ %x  9 lshift TIM1_TIM1_CCER        \ TIM1_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM1_TIM1_CCER        \ TIM1_CC3E	Bit Offset:8	Bit Width:1
        \ %x  5 lshift TIM1_TIM1_CCER        \ TIM1_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM1_TIM1_CCER        \ TIM1_CC2E	Bit Offset:4	Bit Width:1
        \ %x  1 lshift TIM1_TIM1_CCER        \ TIM1_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_TIM1_CCER        \ TIM1_CC1E	Bit Offset:0	Bit Width:1
        
        TIM1 $3824 + constant TIM1_TIM1_CNT	\ read-write		\  : RESET_TIM1_TIM1_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_CNT        \ TIM1_CNT	Bit Offset:0	Bit Width:16
        
        TIM1 $3828 + constant TIM1_TIM1_PSC	\ read-write		\  : RESET_TIM1_TIM1_PSC $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_PSC        \ TIM1_PSC	Bit Offset:0	Bit Width:16
        
        TIM1 $382C + constant TIM1_TIM1_ARR	\ read-write		\  : RESET_TIM1_TIM1_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_ARR        \ TIM1_ARR	Bit Offset:0	Bit Width:16
        
        TIM1 $3834 + constant TIM1_TIM1_CCR1	\ read-write		\  : RESET_TIM1_TIM1_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_CCR1        \ TIM1_CCR	Bit Offset:0	Bit Width:16
        
        TIM1 $3838 + constant TIM1_TIM1_CCR2	\ read-write		\  : RESET_TIM1_TIM1_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_CCR2        \ TIM1_CCR	Bit Offset:0	Bit Width:16
        
        TIM1 $383C + constant TIM1_TIM1_CCR3	\ read-write		\  : RESET_TIM1_TIM1_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_CCR3        \ TIM1_CCR	Bit Offset:0	Bit Width:16
        
        TIM1 $3840 + constant TIM1_TIM1_CCR4	\ read-write		\  : RESET_TIM1_TIM1_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM1_TIM1_CCR4        \ TIM1_CCR	Bit Offset:0	Bit Width:16
        
        TIM1 $3850 + constant TIM1_TIM1_OR	\ read-write		\  : RESET_TIM1_TIM1_OR $00000000 
        \ %x  3 lshift TIM1_TIM1_OR        \ TIM1_ORRSVD	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_TIM1_OR        \ TIM1_CLKMSKEN	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM1_TIM1_OR        \ TIM1_EXTRIGSEL	Bit Offset:0	Bit Width:2
        
         
	
     $4000A804 constant TIM2  
	 TIM2 $0 + constant TIM2_TIM2_ISR	\ 		\  : RESET_TIM2_TIM2_ISR $00000000 
        \ %xxxxx  8 lshift TIM2_TIM2_ISR        \ TIM2_RSVD	Bit Offset:8	Bit Width:5
        \ %x  6 lshift TIM2_TIM2_ISR        \ TIM2_TIF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_TIM2_ISR        \ TIM2_CC4IF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_TIM2_ISR        \ TIM2_CC3IF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_ISR        \ TIM2_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_TIM2_ISR        \ TIM2_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_TIM2_ISR        \ TIM2_UIF	Bit Offset:0	Bit Width:1
        
        TIM2 $18 + constant TIM2_TIM2_MISSR	\ 		\  : RESET_TIM2_TIM2_MISSR $00000000 
        \ %x  12 lshift TIM2_TIM2_MISSR        \ TIM2_CC4IM	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM2_TIM2_MISSR        \ TIM2_CC3IM	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_TIM2_MISSR        \ TIM2_CC2IM	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM2_TIM2_MISSR        \ TIM2_CC1IM	Bit Offset:9	Bit Width:1
        \ %xxxxxxx  0 lshift TIM2_TIM2_MISSR        \ TIM2_RSVD	Bit Offset:0	Bit Width:7
        
        TIM2 $47FC + constant TIM2_TIM2_CR1	\ read-write		\  : RESET_TIM2_TIM2_CR1 $00000000 
        \ %x  7 lshift TIM2_TIM2_CR1        \ TIM2_ARBE	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift TIM2_TIM2_CR1        \ TIM2_CMS	Bit Offset:5	Bit Width:2
        \ %x  4 lshift TIM2_TIM2_CR1        \ TIM2_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_TIM2_CR1        \ TIM2_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_CR1        \ TIM2_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_TIM2_CR1        \ TIM2_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_TIM2_CR1        \ TIM2_CEN	Bit Offset:0	Bit Width:1
        
        TIM2 $40 + constant TIM2_TIM2_IER	\ read-write		\  : RESET_TIM2_TIM2_IER $00000000 
        \ %x  6 lshift TIM2_TIM2_IER        \ TIM2_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_TIM2_IER        \ TIM2_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_TIM2_IER        \ TIM2_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_IER        \ TIM2_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_TIM2_IER        \ TIM2_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_TIM2_IER        \ TIM2_UIE	Bit Offset:0	Bit Width:1
        
        TIM2 $4800 + constant TIM2_TIM2_CR2	\ read-write		\  : RESET_TIM2_TIM2_CR2 $00000000 
        \ %x  7 lshift TIM2_TIM2_CR2        \ TIM2_TI1S	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_TIM2_CR2        \ TIM2_MMS	Bit Offset:4	Bit Width:3
        
        TIM2 $4804 + constant TIM2_TIM2_SMCR	\ read-write		\  : RESET_TIM2_TIM2_SMCR $00000000 
        \ %x  15 lshift TIM2_TIM2_SMCR        \ TIM2_ETP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM2_TIM2_SMCR        \ TIM2_ECE	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift TIM2_TIM2_SMCR        \ TIM2_ETPS	Bit Offset:12	Bit Width:2
        \ %xxxx  8 lshift TIM2_TIM2_SMCR        \ TIM2_ETF	Bit Offset:8	Bit Width:4
        \ %x  7 lshift TIM2_TIM2_SMCR        \ TIM2_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_TIM2_SMCR        \ TIM2_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM2_TIM2_SMCR        \ TIM2_SMS	Bit Offset:0	Bit Width:3
        
        TIM2 $4810 + constant TIM2_TIM2_EGR	\ write-only		\  : RESET_TIM2_TIM2_EGR $00000000 
        \ %x  6 lshift TIM2_TIM2_EGR        \ TIM2_TG	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_TIM2_EGR        \ TIM2_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_TIM2_EGR        \ TIM2_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_EGR        \ TIM2_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_TIM2_EGR        \ TIM2_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_TIM2_EGR        \ TIM2_UG	Bit Offset:0	Bit Width:1
        
        TIM2 $4814 + constant TIM2_TIM2_CCMR1_Input	\ read-write		\  : RESET_TIM2_TIM2_CCMR1_Input $00000000 
        \ %xx  0 lshift TIM2_TIM2_CCMR1_Input        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift TIM2_TIM2_CCMR1_Input        \ TIM2_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xxxx  4 lshift TIM2_TIM2_CCMR1_Input        \ TIM2_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  8 lshift TIM2_TIM2_CCMR1_Input        \ TIM2_CC2S	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift TIM2_TIM2_CCMR1_Input        \ TIM2_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xxxx  12 lshift TIM2_TIM2_CCMR1_Input        \ TIM2_IC2F	Bit Offset:12	Bit Width:4
        
        TIM2 $4814 + constant TIM2_TIM2_CCMR1_Output	\ read-write		\  : RESET_TIM2_TIM2_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM2_TIM2_CCMR1_Output        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        
        TIM2 $4818 + constant TIM2_TIM2_CCMR2_Input	\ read-write		\  : RESET_TIM2_TIM2_CCMR2_Input $00000000 
        \ %xxxx  12 lshift TIM2_TIM2_CCMR2_Input        \ TIM2_IC4F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM2_TIM2_CCMR2_Input        \ TIM2_IC4PSC	Bit Offset:10	Bit Width:2
        \ %xxxx  4 lshift TIM2_TIM2_CCMR2_Input        \ TIM2_IC3F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM2_TIM2_CCMR2_Input        \ TIM2_IC3PSC	Bit Offset:2	Bit Width:2
        \ %xx  8 lshift TIM2_TIM2_CCMR2_Input        \ TIM2_CC4S	Bit Offset:8	Bit Width:2
        \ %xx  0 lshift TIM2_TIM2_CCMR2_Input        \ TIM2_CC3S	Bit Offset:0	Bit Width:2
        
        TIM2 $4818 + constant TIM2_TIM2_CCMR2_Output	\ read-write		\  : RESET_TIM2_TIM2_CCMR2_Output $00000000 
        \ %xxx  12 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_OC4FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_CC4S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_OC3M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_OC3PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_OC3FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM2_TIM2_CCMR2_Output        \ TIM2_CC3S	Bit Offset:0	Bit Width:2
        
        TIM2 $481C + constant TIM2_TIM2_CCER	\ read-write		\  : RESET_TIM2_TIM2_CCER $00000000 
        \ %x  13 lshift TIM2_TIM2_CCER        \ TIM2_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM2_TIM2_CCER        \ TIM2_CC4E	Bit Offset:12	Bit Width:1
        \ %x  9 lshift TIM2_TIM2_CCER        \ TIM2_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM2_TIM2_CCER        \ TIM2_CC3E	Bit Offset:8	Bit Width:1
        \ %x  5 lshift TIM2_TIM2_CCER        \ TIM2_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM2_TIM2_CCER        \ TIM2_CC2E	Bit Offset:4	Bit Width:1
        \ %x  1 lshift TIM2_TIM2_CCER        \ TIM2_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_TIM2_CCER        \ TIM2_CC1E	Bit Offset:0	Bit Width:1
        
        TIM2 $4820 + constant TIM2_TIM2_CNT	\ read-write		\  : RESET_TIM2_TIM2_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_CNT        \ TIM2_CNT	Bit Offset:0	Bit Width:16
        
        TIM2 $4824 + constant TIM2_TIM2_PSC	\ read-write		\  : RESET_TIM2_TIM2_PSC $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_PSC        \ TIM2_PSC	Bit Offset:0	Bit Width:16
        
        TIM2 $4828 + constant TIM2_TIM2_ARR	\ read-write		\  : RESET_TIM2_TIM2_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_ARR        \ TIM2_ARR	Bit Offset:0	Bit Width:16
        
        TIM2 $4830 + constant TIM2_TIM2_CCR1	\ read-write		\  : RESET_TIM2_TIM2_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_CCR1        \ TIM2_CCR	Bit Offset:0	Bit Width:16
        
        TIM2 $4834 + constant TIM2_TIM2_CCR2	\ read-write		\  : RESET_TIM2_TIM2_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_CCR2        \ TIM2_CCR	Bit Offset:0	Bit Width:16
        
        TIM2 $4838 + constant TIM2_TIM2_CCR3	\ read-write		\  : RESET_TIM2_TIM2_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_CCR3        \ TIM2_CCR	Bit Offset:0	Bit Width:16
        
        TIM2 $483C + constant TIM2_TIM2_CCR4	\ read-write		\  : RESET_TIM2_TIM2_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_TIM2_CCR4        \ TIM2_CCR	Bit Offset:0	Bit Width:16
        
        TIM2 $484C + constant TIM2_TIM2_OR	\ read-write		\  : RESET_TIM2_TIM2_OR $00000000 
        \ %x  7 lshift TIM2_TIM2_OR        \ TIM2_REMAPC4	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TIM2_TIM2_OR        \ TIM2_REMAPC3	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TIM2_TIM2_OR        \ TIM2_REMAPC2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM2_TIM2_OR        \ TIM2_REMAPC1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_TIM2_OR        \ TIM2_ORRSVD	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_TIM2_OR        \ TIM2_CLKMSKEN	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM2_TIM2_OR        \ TIM2_EXTRIGSEL	Bit Offset:0	Bit Width:2
        
         
	
     $4000A808 constant SC1  
	 SC1 $0 + constant SC1_SC1_ISR	\ read-write		\  : RESET_SC1_SC1_ISR $00000000 
        \ %x  14 lshift SC1_SC1_ISR        \ SC1_PE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SC1_SC1_ISR        \ SC1_FE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SC1_SC1_ISR        \ SC1_TXULODB	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SC1_SC1_ISR        \ SC1_TXULODA	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SC1_SC1_ISR        \ SC1_RXULODB	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SC1_SC1_ISR        \ SC1_RXULODA	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SC1_SC1_ISR        \ SC1_NACK	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SC1_SC1_ISR        \ SC1_CMDFIN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SC1_SC1_ISR        \ SC1_BTF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC1_SC1_ISR        \ SC1_BRF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_SC1_ISR        \ SC1_UDR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_SC1_ISR        \ SC1_OVR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_SC1_ISR        \ SC1_IDLE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_SC1_ISR        \ SC1_TXE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_SC1_ISR        \ SC1_RXNE	Bit Offset:0	Bit Width:1
        
        SC1 $40 + constant SC1_SC1_IER	\ read-write		\  : RESET_SC1_SC1_IER $00000000 
        \ %x  14 lshift SC1_SC1_IER        \ SC1_PEIE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SC1_SC1_IER        \ SC1_FEIE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SC1_SC1_IER        \ SC1_TXULODBIE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SC1_SC1_IER        \ SC1_TXULODAIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SC1_SC1_IER        \ SC1_RXULODBIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SC1_SC1_IER        \ SC1_RXULODAIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SC1_SC1_IER        \ SC1_NACKIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SC1_SC1_IER        \ SC1_CMDFINIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SC1_SC1_IER        \ SC1_BTFIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC1_SC1_IER        \ SC1_BRFIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_SC1_IER        \ SC1_UDRIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_SC1_IER        \ SC1_OVRIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_SC1_IER        \ SC1_IDLEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_SC1_IER        \ SC1_TXEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_SC1_IER        \ SC1_RXNEIE	Bit Offset:0	Bit Width:1
        
        SC1 $4C + constant SC1_SC1_ICR	\ read-write		\  : RESET_SC1_SC1_ICR $00000000 
        \ %x  2 lshift SC1_SC1_ICR        \ SC1_IDLELEVEL	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_SC1_ICR        \ SC1_TXELEVEL	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_SC1_ICR        \ SC1_RXNELEVEL	Bit Offset:0	Bit Width:1
        
        SC1 $2034 + constant SC1_SC1_DR	\ read-write		\  : RESET_SC1_SC1_DR $00000000 
        \ %xxxxxxxx  0 lshift SC1_SC1_DR        \ SC1_DR	Bit Offset:0	Bit Width:8
        
        SC1 $204C + constant SC1_SC1_CR	\ read-write		\  : RESET_SC1_SC1_CR $00000000 
        \ %xx  0 lshift SC1_SC1_CR        \ SC1_MODE	Bit Offset:0	Bit Width:2
        
        SC1 $2058 + constant SC1_SC1_CRR1	\ read-write		\  : RESET_SC1_SC1_CRR1 $00000000 
        \ %xxxx  0 lshift SC1_SC1_CRR1        \ SC1_LIN	Bit Offset:0	Bit Width:4
        
        SC1 $205C + constant SC1_SC1_CRR2	\ read-write		\  : RESET_SC1_SC1_CRR2 $00000000 
        \ %xxxx  0 lshift SC1_SC1_CRR2        \ SC1_EXP	Bit Offset:0	Bit Width:4
        
         
	
     $4000A80C constant SC2  
	 SC2 $0 + constant SC2_SC2_ISR	\ read-write		\  : RESET_SC2_SC2_ISR $00000000 
        \ %x  14 lshift SC2_SC2_ISR        \ SC2_PE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SC2_SC2_ISR        \ SC2_FE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SC2_SC2_ISR        \ SC2_TXULODB	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SC2_SC2_ISR        \ SC2_TXULODA	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SC2_SC2_ISR        \ SC2_RXULODB	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SC2_SC2_ISR        \ SC2_RXULODA	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SC2_SC2_ISR        \ SC2_NACK	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SC2_SC2_ISR        \ SC2_CMDFIN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SC2_SC2_ISR        \ SC2_BTF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC2_SC2_ISR        \ SC2_BRF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC2_SC2_ISR        \ SC2_UDR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC2_SC2_ISR        \ SC2_OVR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_SC2_ISR        \ SC2_IDLE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_SC2_ISR        \ SC2_TXE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_SC2_ISR        \ SC2_RXNE	Bit Offset:0	Bit Width:1
        
        SC2 $40 + constant SC2_SC2_IER	\ read-write		\  : RESET_SC2_SC2_IER $00000000 
        \ %x  14 lshift SC2_SC2_IER        \ SC2_PEIE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SC2_SC2_IER        \ SC2_FEIE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SC2_SC2_IER        \ SC2_TXULODBIE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SC2_SC2_IER        \ SC2_TXULODAIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SC2_SC2_IER        \ SC2_RXULODBIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SC2_SC2_IER        \ SC2_RXULODAIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SC2_SC2_IER        \ SC2_NACKIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SC2_SC2_IER        \ SC2_CMDFINIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SC2_SC2_IER        \ SC2_BTFIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC2_SC2_IER        \ SC2_BRFIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC2_SC2_IER        \ SC2_UDRIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC2_SC2_IER        \ SC2_OVRIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_SC2_IER        \ SC2_IDLEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_SC2_IER        \ SC2_TXEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_SC2_IER        \ SC2_RXNEIE	Bit Offset:0	Bit Width:1
        
        SC2 $4C + constant SC2_SC2_ICR	\ read-write		\  : RESET_SC2_SC2_ICR $00000000 
        \ %x  2 lshift SC2_SC2_ICR        \ SC2_IDLELEVEL	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_SC2_ICR        \ SC2_TXELEVEL	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_SC2_ICR        \ SC2_RXNELEVEL	Bit Offset:0	Bit Width:1
        
        SC2 $1830 + constant SC2_SC2_DR	\ read-write		\  : RESET_SC2_SC2_DR $00000000 
        \ %xxxxxxxx  0 lshift SC2_SC2_DR        \ SC2_DR	Bit Offset:0	Bit Width:8
        
        SC2 $1848 + constant SC2_SC2_CR	\ read-write		\  : RESET_SC2_SC2_CR $00000000 
        \ %xx  0 lshift SC2_SC2_CR        \ SC2_MODE	Bit Offset:0	Bit Width:2
        
        SC2 $1854 + constant SC2_SC2_CRR1	\ read-write		\  : RESET_SC2_SC2_CRR1 $00000000 
        \ %xxxx  0 lshift SC2_SC2_CRR1        \ SC2_LIN	Bit Offset:0	Bit Width:4
        
        SC2 $1858 + constant SC2_SC2_CRR2	\ read-write		\  : RESET_SC2_SC2_CRR2 $00000000 
        \ %xxxx  0 lshift SC2_SC2_CRR2        \ SC2_EXP	Bit Offset:0	Bit Width:4
        
         
	
     $4000A810 constant ADC  
	 ADC $0 + constant ADC_ADC_ISR	\ read-write		\  : RESET_ADC_ADC_ISR $00000000 
        \ %x  4 lshift ADC_ADC_ISR        \ ADC_DMAOVF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC_ADC_ISR        \ ADC_SAT	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC_ADC_ISR        \ ADC_DMABF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC_ADC_ISR        \ ADC_DMABHF	Bit Offset:1	Bit Width:1
        
        ADC $40 + constant ADC_ADC_IER	\ read-write		\  : RESET_ADC_ADC_IER $00000000 
        \ %x  4 lshift ADC_ADC_IER        \ ADC_DMAOVFIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC_ADC_IER        \ ADC_SATIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC_ADC_IER        \ ADC_DMABFIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC_ADC_IER        \ ADC_DMABHFIE	Bit Offset:1	Bit Width:1
        
        ADC $27F4 + constant ADC_ADC_CR	\ read-write		\  : RESET_ADC_ADC_CR $00001800 
        \ %xxx  13 lshift ADC_ADC_CR        \ ADC_SMP	Bit Offset:13	Bit Width:3
        \ %x  12 lshift ADC_ADC_CR        \ ADC_HVSELP	Bit Offset:12	Bit Width:1
        \ %x  11 lshift ADC_ADC_CR        \ ADC_HVSELN	Bit Offset:11	Bit Width:1
        \ %xxxx  7 lshift ADC_ADC_CR        \ ADC_CHSELP	Bit Offset:7	Bit Width:4
        \ %xxxx  3 lshift ADC_ADC_CR        \ ADC_CHSELN	Bit Offset:3	Bit Width:4
        \ %x  2 lshift ADC_ADC_CR        \ ADC_CLK	Bit Offset:2	Bit Width:1
        \ %x  0 lshift ADC_ADC_CR        \ ADC_ADON	Bit Offset:0	Bit Width:1
        
        ADC $27F8 + constant ADC_ADC_OFFSETR	\ read-write		\  : RESET_ADC_ADC_OFFSETR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_ADC_OFFSETR        \ ADC_OFFSET	Bit Offset:0	Bit Width:16
        
        ADC $27FC + constant ADC_ADC_GAINR	\ read-write		\  : RESET_ADC_ADC_GAINR $00008000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_ADC_GAINR        \ ADC_GAIN	Bit Offset:0	Bit Width:16
        
        ADC $2800 + constant ADC_ADC_DMACR	\ 		\  : RESET_ADC_ADC_DMACR $00000000 
        \ %x  4 lshift ADC_ADC_DMACR        \ ADC_RST	Bit Offset:4	Bit Width:1
        \ %x  1 lshift ADC_ADC_DMACR        \ ADC_AUTOWRAP	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC_ADC_DMACR        \ ADC_LOAD	Bit Offset:0	Bit Width:1
        
        ADC $2804 + constant ADC_ADC_DMASR	\ read-only		\  : RESET_ADC_ADC_DMASR $00000000 
        \ %x  1 lshift ADC_ADC_DMASR        \ ADC_AOVF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC_ADC_DMASR        \ ADC_ACT	Bit Offset:0	Bit Width:1
        
        ADC $2808 + constant ADC_ADC_DMAMSAR	\ read-write		\  : RESET_ADC_ADC_DMAMSAR $20000000 
        \ % 0 lshift ADC_ADC_DMAMSAR        \ ADC_MSA	Bit Offset:0	Bit Width:13
        
        ADC $280C + constant ADC_ADC_DMANDTR	\ read-write		\  : RESET_ADC_ADC_DMANDTR $00000000 
        \ % 0 lshift ADC_ADC_DMANDTR        \ ADC_NDT	Bit Offset:0	Bit Width:13
        
        ADC $2810 + constant ADC_ADC_DMAMNAR	\ read-only		\  : RESET_ADC_ADC_DMAMNAR $20000000 
        \ % 1 lshift ADC_ADC_DMAMNAR        \ ADC_MNA	Bit Offset:1	Bit Width:13
        
        ADC $2814 + constant ADC_ADC_DMACNDTR	\ read-only		\  : RESET_ADC_ADC_DMACNDTR $00000000 
        \ % 0 lshift ADC_ADC_DMACNDTR        \ ADC_CNDT	Bit Offset:0	Bit Width:13
        
         
	
     $4000A814 constant EXTI  
	 EXTI $0 + constant EXTI_EXTI_PR	\ read-write		\  : RESET_EXTI_EXTI_PR $00000000 
        
        EXTI $4C + constant EXTI_EXTIA_TSR	\ read-write		\  : RESET_EXTI_EXTIA_TSR $00000000 
        \ %x  8 lshift EXTI_EXTIA_TSR        \ EXTI_FILTEN	Bit Offset:8	Bit Width:1
        \ %xxx  5 lshift EXTI_EXTIA_TSR        \ EXTI_INTMOD	Bit Offset:5	Bit Width:3
        
        EXTI $50 + constant EXTI_EXTIB_TSR	\ read-write		\  : RESET_EXTI_EXTIB_TSR $00000000 
        \ %x  8 lshift EXTI_EXTIB_TSR        \ EXTI_FILTEN	Bit Offset:8	Bit Width:1
        \ %xxx  5 lshift EXTI_EXTIB_TSR        \ EXTI_INTMOD	Bit Offset:5	Bit Width:3
        
        EXTI $54 + constant EXTI_EXTIC_TSR	\ read-write		\  : RESET_EXTI_EXTIC_TSR $00000000 
        \ %x  8 lshift EXTI_EXTIC_TSR        \ EXTI_FILTEN	Bit Offset:8	Bit Width:1
        \ %xxx  5 lshift EXTI_EXTIC_TSR        \ EXTI_INTMOD	Bit Offset:5	Bit Width:3
        
        EXTI $1400 + constant EXTI_EXTIC_CR	\ read-write		\  : RESET_EXTI_EXTIC_CR $0000000F 
        \ %xxxxx  0 lshift EXTI_EXTIC_CR        \ EXTI_GPIO_SEL	Bit Offset:0	Bit Width:5
        
        EXTI $58 + constant EXTI_EXTID_TSR	\ read-write		\  : RESET_EXTI_EXTID_TSR $00000000 
        \ %x  8 lshift EXTI_EXTID_TSR        \ EXTI_FILTEN	Bit Offset:8	Bit Width:1
        \ %xxx  5 lshift EXTI_EXTID_TSR        \ EXTI_INTMOD	Bit Offset:5	Bit Width:3
        
        EXTI $1404 + constant EXTI_EXTID_CR	\ read-write		\  : RESET_EXTI_EXTID_CR $00000010 
        \ %xxxxx  0 lshift EXTI_EXTID_CR        \ EXTI_GPIO_SEL	Bit Offset:0	Bit Width:5
        
         
	
     $4000B000 constant GPIOA  
	 GPIOA $0 + constant GPIOA_GPIOA_CRL	\ read-write		\  : RESET_GPIOA_GPIOA_CRL $00004444 
        \ %xxxx  12 lshift GPIOA_GPIOA_CRL        \ GPIOA_CNFMODE3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOA_GPIOA_CRL        \ GPIOA_CNFMODE2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOA_GPIOA_CRL        \ GPIOA_CNFMODE1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOA_GPIOA_CRL        \ GPIOA_CNFMODE0	Bit Offset:0	Bit Width:4
        
        GPIOA $4 + constant GPIOA_GPIOA_CRH	\ read-write		\  : RESET_GPIOA_GPIOA_CRH $00004444 
        \ %xxxx  12 lshift GPIOA_GPIOA_CRH        \ GPIOA_CNFMODE7	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOA_GPIOA_CRH        \ GPIOA_CNFMODE6	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOA_GPIOA_CRH        \ GPIOA_CNFMODE5	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOA_GPIOA_CRH        \ GPIOA_CNFMODE4	Bit Offset:0	Bit Width:4
        
        GPIOA $8 + constant GPIOA_GPIOA_IDR	\ read-write		\  : RESET_GPIOA_GPIOA_IDR $00000000 
        \ %x  7 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_GPIOA_IDR        \ GPIOA_IDR0	Bit Offset:0	Bit Width:1
        
        GPIOA $C + constant GPIOA_GPIOA_ODR	\ read-write		\  : RESET_GPIOA_GPIOA_ODR $00000000 
        \ %x  7 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_GPIOA_ODR        \ GPIOA_ODR0	Bit Offset:0	Bit Width:1
        
        GPIOA $10 + constant GPIOA_GPIOA_BSR	\ read-write		\  : RESET_GPIOA_GPIOA_BSR $00000000 
        \ %x  7 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_GPIOA_BSR        \ GPIOA_BS0	Bit Offset:0	Bit Width:1
        
        GPIOA $14 + constant GPIOA_GPIOA_BRR	\ write-only		\  : RESET_GPIOA_GPIOA_BRR $00000000 
        \ %x  7 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_GPIOA_BRR        \ GPIOA_BR0	Bit Offset:0	Bit Width:1
        
         
	
     $4000B400 constant GPIOB  
	 GPIOB $0 + constant GPIOB_GPIOB_CRL	\ read-write		\  : RESET_GPIOB_GPIOB_CRL $00004444 
        \ %xxxx  12 lshift GPIOB_GPIOB_CRL        \ GPIOB_CNFMODE3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOB_GPIOB_CRL        \ GPIOB_CNFMODE2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOB_GPIOB_CRL        \ GPIOB_CNFMODE1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOB_GPIOB_CRL        \ GPIOB_CNFMODE0	Bit Offset:0	Bit Width:4
        
        GPIOB $4 + constant GPIOB_GPIOB_CRH	\ read-write		\  : RESET_GPIOB_GPIOB_CRH $00004444 
        \ %xxxx  12 lshift GPIOB_GPIOB_CRH        \ GPIOB_CNFMODE7	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOB_GPIOB_CRH        \ GPIOB_CNFMODE6	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOB_GPIOB_CRH        \ GPIOB_CNFMODE5	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOB_GPIOB_CRH        \ GPIOB_CNFMODE4	Bit Offset:0	Bit Width:4
        
        GPIOB $8 + constant GPIOB_GPIOB_IDR	\ read-write		\  : RESET_GPIOB_GPIOB_IDR $00000000 
        \ %x  7 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_GPIOB_IDR        \ GPIOB_ID0	Bit Offset:0	Bit Width:1
        
        GPIOB $C + constant GPIOB_GPIOB_ODR	\ read-write		\  : RESET_GPIOB_GPIOB_ODR $00000000 
        \ %x  7 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_GPIOB_ODR        \ GPIOB_OD0	Bit Offset:0	Bit Width:1
        
        GPIOB $10 + constant GPIOB_GPIOB_BSR	\ read-write		\  : RESET_GPIOB_GPIOB_BSR $00000000 
        \ %x  7 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_GPIOB_BSR        \ GPIOB_BS0	Bit Offset:0	Bit Width:1
        
        GPIOB $14 + constant GPIOB_GPIOB_BRR	\ write-only		\  : RESET_GPIOB_GPIOB_BRR $00000000 
        \ %x  7 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_GPIOB_BRR        \ GPIOB_BR0	Bit Offset:0	Bit Width:1
        
         
	
     $4000B800 constant GPIOC  
	 GPIOC $0 + constant GPIOC_GPIOC_CRL	\ read-write		\  : RESET_GPIOC_GPIOC_CRL $00004444 
        \ %xxxx  12 lshift GPIOC_GPIOC_CRL        \ GPIOC_CNFMODE3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOC_GPIOC_CRL        \ GPIOC_CNFMODE2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOC_GPIOC_CRL        \ GPIOC_CNFMODE1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOC_GPIOC_CRL        \ GPIOC_CNFMODE0	Bit Offset:0	Bit Width:4
        
        GPIOC $4 + constant GPIOC_GPIOC_CRH	\ read-write		\  : RESET_GPIOC_GPIOC_CRH $00004444 
        \ %xxxx  12 lshift GPIOC_GPIOC_CRH        \ GPIOC_CNFMODE7	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOC_GPIOC_CRH        \ GPIOC_CNFMODE6	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOC_GPIOC_CRH        \ GPIOC_CNFMODE5	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOC_GPIOC_CRH        \ GPIOC_CNFMODE4	Bit Offset:0	Bit Width:4
        
        GPIOC $8 + constant GPIOC_GPIOC_IDR	\ read-write		\  : RESET_GPIOC_GPIOC_IDR $00000000 
        \ %x  7 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_GPIOC_IDR        \ GPIOC_ID0	Bit Offset:0	Bit Width:1
        
        GPIOC $C + constant GPIOC_GPIOC_ODR	\ read-write		\  : RESET_GPIOC_GPIOC_ODR $00000000 
        \ %x  7 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_GPIOC_ODR        \ GPIOC_OD0	Bit Offset:0	Bit Width:1
        
        GPIOC $10 + constant GPIOC_GPIOC_BSR	\ read-write		\  : RESET_GPIOC_GPIOC_BSR $00000000 
        \ %x  7 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_GPIOC_BSR        \ GPIOC_BS0	Bit Offset:0	Bit Width:1
        
        GPIOC $14 + constant GPIOC_GPIOC_BRR	\ write-only		\  : RESET_GPIOC_GPIOC_BRR $00000000 
        \ %x  7 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_GPIOC_BRR        \ GPIOC_BR0	Bit Offset:0	Bit Width:1
        
         
	
     $40004028 constant GPIO_DBG  
	 GPIO_DBG $7BD8 + constant GPIO_DBG_GPIO_DBGCR	\ read-write		\  : RESET_GPIO_DBG_GPIO_DBGCR $00000010 
        \ %x  5 lshift GPIO_DBG_GPIO_DBGCR        \ GPIO_DBG_DBGDIS	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIO_DBG_GPIO_DBGCR        \ GPIO_DBG_EXTREGEN	Bit Offset:4	Bit Width:1
        
        GPIO_DBG $7BDC + constant GPIO_DBG_GPIO_DBGSR	\ read-only		\  : RESET_GPIO_DBG_GPIO_DBGSR $00000000 
        \ %x  3 lshift GPIO_DBG_GPIO_DBGSR        \ GPIO_DBG_BOOTMODE	Bit Offset:3	Bit Width:1
        \ %x  1 lshift GPIO_DBG_GPIO_DBGSR        \ GPIO_DBG_FORCEDBG	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIO_DBG_GPIO_DBGSR        \ GPIO_DBG_SWEN	Bit Offset:0	Bit Width:1
        
        GPIO_DBG $0 + constant GPIO_DBG_GPIO_PCTRACECR	\ read-write		\  : RESET_GPIO_DBG_GPIO_PCTRACECR $00000000 
        \ %x  0 lshift GPIO_DBG_GPIO_PCTRACECR        \ GPIO_DBG_SEL	Bit Offset:0	Bit Width:1
        
         
	
     $40006000 constant WDG  
	 WDG $0 + constant WDG_WDG_CR	\ read-write		\  : RESET_WDG_WDG_CR $00000002 
        \ %x  1 lshift WDG_WDG_CR        \ WDG_WDGDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift WDG_WDG_CR        \ WDG_WDGEN	Bit Offset:0	Bit Width:1
        
        WDG $4 + constant WDG_WDG_KR	\ write-only		\  : RESET_WDG_WDG_KR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift WDG_WDG_KR        \ WDG_KEY	Bit Offset:0	Bit Width:16
        
        WDG $8 + constant WDG_WDG_KICKSR	\ write-only		\  : RESET_WDG_WDG_KICKSR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift WDG_WDG_KICKSR        \ WDG_KS	Bit Offset:0	Bit Width:16
        
         
	
     $40000008 constant CLK  
	 CLK $0 + constant CLK_CLK_SLEEPCR	\ read-write		\  : RESET_CLK_CLK_SLEEPCR $00000002 
        \ %x  0 lshift CLK_CLK_SLEEPCR        \ CLK_LSEEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CLK_CLK_SLEEPCR        \ CLK_LSI10KEN	Bit Offset:1	Bit Width:1
        
        CLK $4 + constant CLK_CLK_LSI10KCR	\ read-write		\  : RESET_CLK_CLK_LSI10KCR $00000000 
        \ %xxxx  0 lshift CLK_CLK_LSI10KCR        \ CLK_TUNE	Bit Offset:0	Bit Width:4
        
        CLK $8 + constant CLK_CLK_LSI1KCR	\ read-write		\  : RESET_CLK_CLK_LSI1KCR $00005000 
        \ % 0 lshift CLK_CLK_LSI1KCR        \ CLK_CLKFRAC	Bit Offset:0	Bit Width:11
        \ %xxxxxxxxxxxxxxx  11 lshift CLK_CLK_LSI1KCR        \ CLK_CALINT	Bit Offset:11	Bit Width:15
        
        CLK $3FFC + constant CLK_CLK_HSECR1	\ read-write		\  : RESET_CLK_CLK_HSECR1 $0000000F 
        \ %xxxx  0 lshift CLK_CLK_HSECR1        \ CLK_BIASTRIM	Bit Offset:0	Bit Width:4
        
        CLK $4000 + constant CLK_CLK_HSICR	\ read-write		\  : RESET_CLK_CLK_HSICR $00000017 
        \ %xxxxx  0 lshift CLK_CLK_HSICR        \ CLK_TUNE	Bit Offset:0	Bit Width:5
        
        CLK $4008 + constant CLK_CLK_PERIODCR	\ read-write		\  : RESET_CLK_CLK_PERIODCR $00000200 
        \ %xx  0 lshift CLK_CLK_PERIODCR        \ CLK_MODE	Bit Offset:0	Bit Width:2
        
        CLK $400C + constant CLK_CLK_PERIODSR	\ read-only		\  : RESET_CLK_CLK_PERIODSR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift CLK_CLK_PERIODSR        \ CLK_PERIOD	Bit Offset:0	Bit Width:16
        
        CLK $4010 + constant CLK_CLK_DITHERCR	\ read-write		\  : RESET_CLK_CLK_DITHERCR $00000000 
        \ %x  0 lshift CLK_CLK_DITHERCR        \ CLK_DIS	Bit Offset:0	Bit Width:1
        
        CLK $4014 + constant CLK_CLK_HSECR2	\ read-write		\  : RESET_CLK_CLK_HSECR2 $00000000 
        \ %x  0 lshift CLK_CLK_HSECR2        \ CLK_SW1	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CLK_CLK_HSECR2        \ CLK_EN	Bit Offset:1	Bit Width:1
        
        CLK $4018 + constant CLK_CLK_CPUCR	\ read-write		\  : RESET_CLK_CLK_CPUCR $00000000 
        \ %x  0 lshift CLK_CLK_CPUCR        \ CLK_SW2	Bit Offset:0	Bit Width:1
        
         
	
     $4000002C constant RST  
	 RST $0 + constant RST_RST_SR	\ read-only		\  : RESET_RST_RST_SR $00000001 
        \ %x  7 lshift RST_RST_SR        \ RST_LKUP	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RST_RST_SR        \ RST_OBFAIL	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RST_RST_SR        \ RST_WKUP	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RST_RST_SR        \ RST_SWRST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RST_RST_SR        \ RST_WDG	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RST_RST_SR        \ RST_PIN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RST_RST_SR        \ RST_PWRLV	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RST_RST_SR        \ RST_PWRHV	Bit Offset:0	Bit Width:1
        
         
	
     $4000402C constant FLASH  
	 FLASH $3FD4 + constant FLASH_FLASH_ACR	\ 		\  : RESET_FLASH_FLASH_ACR $00000031 
        \ %x  5 lshift FLASH_FLASH_ACR        \ FLASH_PRFTBS	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FLASH_FLASH_ACR        \ FLASH_PRFTBE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift FLASH_FLASH_ACR        \ FLASH_HLFCYA	Bit Offset:3	Bit Width:1
        \ %xxx  0 lshift FLASH_FLASH_ACR        \ FLASH_LATENCY	Bit Offset:0	Bit Width:3
        
        FLASH $3FD8 + constant FLASH_FLASH_KEYR	\ write-only		\  : RESET_FLASH_FLASH_KEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_FLASH_KEYR        \ FLASH_FKEYR	Bit Offset:0	Bit Width:32
        
        FLASH $3FDC + constant FLASH_FLASH_OPTKEYR	\ write-only		\  : RESET_FLASH_FLASH_OPTKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_FLASH_OPTKEYR        \ FLASH_OPTKEYR	Bit Offset:0	Bit Width:32
        
        FLASH $3FE0 + constant FLASH_FLASH_SR	\ 		\  : RESET_FLASH_FLASH_SR $00000000 
        \ %x  5 lshift FLASH_FLASH_SR        \ FLASH_EOP	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FLASH_FLASH_SR        \ FLASH_WRPRTERR	Bit Offset:4	Bit Width:1
        \ %x  2 lshift FLASH_FLASH_SR        \ FLASH_PGERR	Bit Offset:2	Bit Width:1
        \ %x  0 lshift FLASH_FLASH_SR        \ FLASH_BSY	Bit Offset:0	Bit Width:1
        
        FLASH $3FE4 + constant FLASH_FLASH_CR	\ read-write		\  : RESET_FLASH_FLASH_CR $00000080 
        \ %x  12 lshift FLASH_FLASH_CR        \ FLASH_EOPIE	Bit Offset:12	Bit Width:1
        \ %x  10 lshift FLASH_FLASH_CR        \ FLASH_ERRIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FLASH_FLASH_CR        \ FLASH_OPTWRE	Bit Offset:9	Bit Width:1
        \ %x  7 lshift FLASH_FLASH_CR        \ FLASH_LOCK	Bit Offset:7	Bit Width:1
        \ %x  6 lshift FLASH_FLASH_CR        \ FLASH_STRT	Bit Offset:6	Bit Width:1
        \ %x  5 lshift FLASH_FLASH_CR        \ FLASH_OPTER	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FLASH_FLASH_CR        \ FLASH_OPTPG	Bit Offset:4	Bit Width:1
        \ %x  2 lshift FLASH_FLASH_CR        \ FLASH_MER	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FLASH_FLASH_CR        \ FLASH_PER	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FLASH_FLASH_CR        \ FLASH_PG	Bit Offset:0	Bit Width:1
        
        FLASH $3FE8 + constant FLASH_FLASH_AR	\ read-write		\  : RESET_FLASH_FLASH_AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_FLASH_AR        \ FLASH_FAR	Bit Offset:0	Bit Width:32
        
        FLASH $3FF0 + constant FLASH_FLASH_OBR	\ read-only		\  : RESET_FLASH_FLASH_OBR $03FFFFFC 
        \ %x  1 lshift FLASH_FLASH_OBR        \ FLASH_RDPRT	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FLASH_FLASH_OBR        \ FLASH_OPTERR	Bit Offset:0	Bit Width:1
        
        FLASH $3FF4 + constant FLASH_FLASH_WRPR	\ read-only		\  : RESET_FLASH_FLASH_WRPR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_FLASH_WRPR        \ FLASH_WRP	Bit Offset:0	Bit Width:32
        
        FLASH $0 + constant FLASH_FLASH_CLKER	\ read-write		\  : RESET_FLASH_FLASH_CLKER $00000000 
        \ %x  0 lshift FLASH_FLASH_CLKER        \ FLASH_EN	Bit Offset:0	Bit Width:1
        
        FLASH $4 + constant FLASH_FLASH_CLKSR	\ read-write		\  : RESET_FLASH_FLASH_CLKSR $00000000 
        \ %x  1 lshift FLASH_FLASH_CLKSR        \ FLASH_BSY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FLASH_FLASH_CLKSR        \ FLASH_ACK	Bit Offset:0	Bit Width:1
        
         
	
     $4000600C constant SLPTMR  
	 SLPTMR $0 + constant SLPTMR_SLPTMR_CR	\ read-write		\  : RESET_SLPTMR_SLPTMR_CR $00000400 
        \ %x  12 lshift SLPTMR_SLPTMR_CR        \ SLPTMR_REVERSE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SLPTMR_SLPTMR_CR        \ SLPTMR_EN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SLPTMR_SLPTMR_CR        \ SLPTMR_DBGP	Bit Offset:10	Bit Width:1
        \ %xxxx  4 lshift SLPTMR_SLPTMR_CR        \ SLPTMR_PSC	Bit Offset:4	Bit Width:4
        \ %x  0 lshift SLPTMR_SLPTMR_CR        \ SLPTMR_CLKSEL	Bit Offset:0	Bit Width:1
        
        SLPTMR $4 + constant SLPTMR_SLPTMR_CNTH	\ read-only		\  : RESET_SLPTMR_SLPTMR_CNTH $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift SLPTMR_SLPTMR_CNTH        \ SLPTMR_CNTH	Bit Offset:0	Bit Width:16
        
        SLPTMR $8 + constant SLPTMR_SLPTMR_CNTL	\ read-only		\  : RESET_SLPTMR_SLPTMR_CNTL $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift SLPTMR_SLPTMR_CNTL        \ SLPTMR_CNTL	Bit Offset:0	Bit Width:16
        
        SLPTMR $C + constant SLPTMR_SLPTMR_CMPAH	\ read-write		\  : RESET_SLPTMR_SLPTMR_CMPAH $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift SLPTMR_SLPTMR_CMPAH        \ SLPTMR_CMPAH	Bit Offset:0	Bit Width:16
        
        SLPTMR $10 + constant SLPTMR_SLPTMR_CMPAL	\ read-write		\  : RESET_SLPTMR_SLPTMR_CMPAL $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift SLPTMR_SLPTMR_CMPAL        \ SLPTMR_CMPAL	Bit Offset:0	Bit Width:16
        
        SLPTMR $14 + constant SLPTMR_SLPTMR_CMPBH	\ read-write		\  : RESET_SLPTMR_SLPTMR_CMPBH $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift SLPTMR_SLPTMR_CMPBH        \ SLPTMR_CMPBH	Bit Offset:0	Bit Width:16
        
        SLPTMR $18 + constant SLPTMR_SLPTMR_CMPBL	\ read-write		\  : RESET_SLPTMR_SLPTMR_CMPBL $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift SLPTMR_SLPTMR_CMPBL        \ SLPTMR_CMPBL	Bit Offset:0	Bit Width:16
        
        SLPTMR $4008 + constant SLPTMR_SLPTMR_ISR	\ read-write		\  : RESET_SLPTMR_SLPTMR_ISR $00000000 
        \ %x  2 lshift SLPTMR_SLPTMR_ISR        \ SLPTMR_CMPB	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SLPTMR_SLPTMR_ISR        \ SLPTMR_CMPA	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SLPTMR_SLPTMR_ISR        \ SLPTMR_OW	Bit Offset:0	Bit Width:1
        
        SLPTMR $4014 + constant SLPTMR_SLPTMR_IFR	\ read-write		\  : RESET_SLPTMR_SLPTMR_IFR $00000000 
        \ %x  2 lshift SLPTMR_SLPTMR_IFR        \ SLPTMR_CMPB	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SLPTMR_SLPTMR_IFR        \ SLPTMR_CMPA	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SLPTMR_SLPTMR_IFR        \ SLPTMR_OW	Bit Offset:0	Bit Width:1
        
        SLPTMR $4048 + constant SLPTMR_SLPTMR_IER	\ read-write		\  : RESET_SLPTMR_SLPTMR_IER $00000000 
        \ %x  0 lshift SLPTMR_SLPTMR_IER        \ SLPTMR_WRAP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift SLPTMR_SLPTMR_IER        \ SLPTMR_CMPA	Bit Offset:1	Bit Width:1
        \ %x  2 lshift SLPTMR_SLPTMR_IER        \ SLPTMR_CMPB	Bit Offset:2	Bit Width:1
        
         
	
     $40000004 constant PWR  
	 PWR $0 + constant PWR_PWR_DSLEEPCR1	\ read-write		\  : RESET_PWR_PWR_DSLEEPCR1 $00000000 
        \ %x  1 lshift PWR_PWR_DSLEEPCR1        \ PWR_PWR_CSYSPWRUPACKCR	Bit Offset:1	Bit Width:1
        
        PWR $10 + constant PWR_PWR_DSLEEPCR2	\ read-write		\  : RESET_PWR_PWR_DSLEEPCR2 $00000000 
        \ %x  0 lshift PWR_PWR_DSLEEPCR2        \ PWR_MODE	Bit Offset:0	Bit Width:1
        
        PWR $14 + constant PWR_PWR_VREGCR	\ read-write		\  : RESET_PWR_PWR_VREGCR $00000207 
        \ %xxx  0 lshift PWR_PWR_VREGCR        \ PWR_PWR_VREGCR_1V2TRIM	Bit Offset:0	Bit Width:3
        \ %x  4 lshift PWR_PWR_VREGCR        \ PWR_PWR_VREGCR_1V2EN	Bit Offset:4	Bit Width:1
        \ %xxx  7 lshift PWR_PWR_VREGCR        \ PWR_PWR_VREGCR_1V8TRIM	Bit Offset:7	Bit Width:3
        \ %x  11 lshift PWR_PWR_VREGCR        \ PWR_PWR_VREGCR_1V8EN	Bit Offset:11	Bit Width:1
        \ %x  15 lshift PWR_PWR_VREGCR        \ PWR_PWR_VREGCR_VREFEN	Bit Offset:15	Bit Width:1
        
        PWR $1C + constant PWR_PWR_WAKECR1	\ read-write		\  : RESET_PWR_PWR_WAKECR1 $00000200 
        \ %x  0 lshift PWR_PWR_WAKECR1        \ PWR_WAKEEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_PWR_WAKECR1        \ PWR_SC1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_PWR_WAKECR1        \ PWR_SC2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_PWR_WAKECR1        \ PWR_IRQD	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_PWR_WAKECR1        \ PWR_COMPA	Bit Offset:4	Bit Width:1
        \ %x  5 lshift PWR_PWR_WAKECR1        \ PWR_COMPB	Bit Offset:5	Bit Width:1
        \ %x  6 lshift PWR_PWR_WAKECR1        \ PWR_WRAP	Bit Offset:6	Bit Width:1
        \ %x  7 lshift PWR_PWR_WAKECR1        \ PWR_CORE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift PWR_PWR_WAKECR1        \ PWR_CPWRRUPREQ	Bit Offset:8	Bit Width:1
        \ %x  9 lshift PWR_PWR_WAKECR1        \ PWR_CSYSPWRUPREQ	Bit Offset:9	Bit Width:1
        
        PWR $20 + constant PWR_PWR_WAKECR2	\ write-only		\  : RESET_PWR_PWR_WAKECR2 $00000000 
        \ %x  5 lshift PWR_PWR_WAKECR2        \ PWR_COREWAKE	Bit Offset:5	Bit Width:1
        
        PWR $24 + constant PWR_PWR_WAKESR	\ read-write		\  : RESET_PWR_PWR_WAKESR $00000000 
        \ %x  0 lshift PWR_PWR_WAKESR        \ PWR_GPIOPIN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_PWR_WAKESR        \ PWR_SC1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_PWR_WAKESR        \ PWR_SC2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_PWR_WAKESR        \ PWR_IRQD	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_PWR_WAKESR        \ PWR_COMPA	Bit Offset:4	Bit Width:1
        \ %x  5 lshift PWR_PWR_WAKESR        \ PWR_COMPB	Bit Offset:5	Bit Width:1
        \ %x  6 lshift PWR_PWR_WAKESR        \ PWR_WRAP	Bit Offset:6	Bit Width:1
        \ %x  7 lshift PWR_PWR_WAKESR        \ PWR_CORE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift PWR_PWR_WAKESR        \ PWR_CPWRRUPREQ	Bit Offset:8	Bit Width:1
        \ %x  9 lshift PWR_PWR_WAKESR        \ PWR_CSYSPWRUPREQ	Bit Offset:9	Bit Width:1
        
        PWR $30 + constant PWR_PWR_CPWRUPREQSR	\ read-only		\  : RESET_PWR_PWR_CPWRUPREQSR $00000000 
        \ %x  0 lshift PWR_PWR_CPWRUPREQSR        \ PWR_REQ	Bit Offset:0	Bit Width:1
        
        PWR $34 + constant PWR_PWR_CSYSPWRUPREQSR	\ read-only		\  : RESET_PWR_PWR_CSYSPWRUPREQSR $00000000 
        \ %x  0 lshift PWR_PWR_CSYSPWRUPREQSR        \ PWR_REQ	Bit Offset:0	Bit Width:1
        
        PWR $38 + constant PWR_PWR_CSYSPWRUPACKSR	\ read-only		\  : RESET_PWR_PWR_CSYSPWRUPACKSR $00000000 
        \ %x  0 lshift PWR_PWR_CSYSPWRUPACKSR        \ PWR_ACK	Bit Offset:0	Bit Width:1
        
        PWR $3C + constant PWR_PWR_CSYSPWRUPACKCR	\ read-only		\  : RESET_PWR_PWR_CSYSPWRUPACKCR $00000000 
        \ %x  0 lshift PWR_PWR_CSYSPWRUPACKCR        \ PWR_INHIBIT	Bit Offset:0	Bit Width:1
        
        PWR $BC04 + constant PWR_PWR_WAKEPAR	\ read-write		\  : RESET_PWR_PWR_WAKEPAR $00000000 
        \ %x  0 lshift PWR_PWR_WAKEPAR        \ PWR_PA0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_PWR_WAKEPAR        \ PWR_PA1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_PWR_WAKEPAR        \ PWR_PA2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_PWR_WAKEPAR        \ PWR_PA3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_PWR_WAKEPAR        \ PWR_PA4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift PWR_PWR_WAKEPAR        \ PWR_PA5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift PWR_PWR_WAKEPAR        \ PWR_PA6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift PWR_PWR_WAKEPAR        \ PWR_PA7	Bit Offset:7	Bit Width:1
        
        PWR $BC08 + constant PWR_PWR_WAKEPBR	\ read-write		\  : RESET_PWR_PWR_WAKEPBR $00000000 
        \ %x  0 lshift PWR_PWR_WAKEPBR        \ PWR_PB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_PWR_WAKEPBR        \ PWR_PB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_PWR_WAKEPBR        \ PWR_PB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_PWR_WAKEPBR        \ PWR_PB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_PWR_WAKEPBR        \ PWR_PB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift PWR_PWR_WAKEPBR        \ PWR_PB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift PWR_PWR_WAKEPBR        \ PWR_PB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift PWR_PWR_WAKEPBR        \ PWR_PB7	Bit Offset:7	Bit Width:1
        
        PWR $BC0C + constant PWR_PWR_WAKEPCR	\ read-write		\  : RESET_PWR_PWR_WAKEPCR $00000000 
        \ %x  0 lshift PWR_PWR_WAKEPCR        \ PWR_PC0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_PWR_WAKEPCR        \ PWR_PC1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_PWR_WAKEPCR        \ PWR_PC2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_PWR_WAKEPCR        \ PWR_PC3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_PWR_WAKEPCR        \ PWR_PC4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift PWR_PWR_WAKEPCR        \ PWR_PC5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift PWR_PWR_WAKEPCR        \ PWR_PC6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift PWR_PWR_WAKEPCR        \ PWR_PC7	Bit Offset:7	Bit Width:1
        
        PWR $BC18 + constant PWR_PWR_WAKEFILTR	\ read-write		\  : RESET_PWR_PWR_WAKEFILTR $00000000 
        \ %x  0 lshift PWR_PWR_WAKEFILTR        \ PWR_GPIO	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_PWR_WAKEFILTR        \ PWR_SC1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_PWR_WAKEFILTR        \ PWR_SC2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_PWR_WAKEFILTR        \ PWR_IRQD	Bit Offset:3	Bit Width:1
        
         
	
     $E000E000 constant NVIC  
	 NVIC $4 + constant NVIC_ICTR	\ read-only		\  : RESET_NVIC_ICTR $00000000 
        \ %xxxx  0 lshift NVIC_ICTR        \ NVIC_INTLINESNUM	Bit Offset:0	Bit Width:4
        
        NVIC $F00 + constant NVIC_STIR	\ write-only		\  : RESET_NVIC_STIR $00000000 
        \ %xxxxxxxxx  0 lshift NVIC_STIR        \ NVIC_INTID	Bit Offset:0	Bit Width:9
        
        NVIC $100 + constant NVIC_ISER0	\ read-write		\  : RESET_NVIC_ISER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER0        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $180 + constant NVIC_ICER0	\ read-write		\  : RESET_NVIC_ICER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER0        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $200 + constant NVIC_ISPR0	\ read-write		\  : RESET_NVIC_ISPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR0        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $280 + constant NVIC_ICPR0	\ read-write		\  : RESET_NVIC_ICPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR0        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $300 + constant NVIC_IABR0	\ read-only		\  : RESET_NVIC_IABR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR0        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
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
        
         
	
     $40005000 constant MEM  
	 MEM $0 + constant MEM_RAMPROTR1	\ read-write		\  : RESET_MEM_RAMPROTR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR1        \ MEM_RAMPROT1	Bit Offset:0	Bit Width:32
        
        MEM $4 + constant MEM_RAMPROTR2	\ read-write		\  : RESET_MEM_RAMPROTR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR2        \ MEM_RAMPROT2	Bit Offset:0	Bit Width:32
        
        MEM $8 + constant MEM_RAMPROTR3	\ read-write		\  : RESET_MEM_RAMPROTR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR3        \ MEM_RAMPROT3	Bit Offset:0	Bit Width:32
        
        MEM $C + constant MEM_RAMPROTR4	\ read-write		\  : RESET_MEM_RAMPROTR4 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR4        \ MEM_RAMPROT4	Bit Offset:0	Bit Width:32
        
        MEM $10 + constant MEM_RAMPROTR5	\ read-write		\  : RESET_MEM_RAMPROTR5 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR5        \ MEM_RAMPROT5	Bit Offset:0	Bit Width:32
        
        MEM $14 + constant MEM_RAMPROTR6	\ read-write		\  : RESET_MEM_RAMPROTR6 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR6        \ MEM_RAMPROT6	Bit Offset:0	Bit Width:32
        
        MEM $18 + constant MEM_RAMPROTR7	\ read-write		\  : RESET_MEM_RAMPROTR7 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR7        \ MEM_RAMPROT7	Bit Offset:0	Bit Width:32
        
        MEM $1C + constant MEM_RAMPROTR8	\ read-write		\  : RESET_MEM_RAMPROTR8 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift MEM_RAMPROTR8        \ MEM_RAMPROT8	Bit Offset:0	Bit Width:32
        
        MEM $20 + constant MEM_DMAPROTR1	\ read-only		\  : RESET_MEM_DMAPROTR1 $20000000 
        \ %xxxxxxxxxxxxxx  0 lshift MEM_DMAPROTR1        \ MEM_ADDRESS	Bit Offset:0	Bit Width:14
        \ % 14 lshift MEM_DMAPROTR1        \ MEM_OFFSET	Bit Offset:14	Bit Width:18
        
        MEM $24 + constant MEM_DMAPROTR2	\ read-only		\  : RESET_MEM_DMAPROTR2 $00000000 
        \ %xxx  0 lshift MEM_DMAPROTR2        \ MEM_CHANNEL	Bit Offset:0	Bit Width:3
        
        MEM $28 + constant MEM_RAMCR	\ read-write		\  : RESET_MEM_RAMCR $00000000 
        \ %x  2 lshift MEM_RAMCR        \ MEM_WEN	Bit Offset:2	Bit Width:1
        
         
	
     $4000C800 constant SC1_DMA  
	 SC1_DMA $0 + constant SC1_DMA_SC1_DMARXBEGADDAR	\ read-write		\  : RESET_SC1_DMA_SC1_DMARXBEGADDAR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXBEGADDAR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $4 + constant SC1_DMA_SC1_DMARXENDADDAR	\ read-write		\  : RESET_SC1_DMA_SC1_DMARXENDADDAR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXENDADDAR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $8 + constant SC1_DMA_SC1_DMARXBEGADDBR	\ read-write		\  : RESET_SC1_DMA_SC1_DMARXBEGADDBR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXBEGADDBR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $C + constant SC1_DMA_SC1_DMARXENDADDBR	\ read-write		\  : RESET_SC1_DMA_SC1_DMARXENDADDBR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXENDADDBR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $10 + constant SC1_DMA_SC1_DMATXBEGADDAR	\ read-write		\  : RESET_SC1_DMA_SC1_DMATXBEGADDAR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMATXBEGADDAR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $14 + constant SC1_DMA_SC1_DMATXENDADDAR	\ read-write		\  : RESET_SC1_DMA_SC1_DMATXENDADDAR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMATXENDADDAR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $18 + constant SC1_DMA_SC1_DMATXBEGADDBR	\ read-write		\  : RESET_SC1_DMA_SC1_DMATXBEGADDBR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMATXBEGADDBR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $1C + constant SC1_DMA_SC1_DMATXENDADDBR	\ read-write		\  : RESET_SC1_DMA_SC1_DMATXENDADDBR $20000000 
        \ % 0 lshift SC1_DMA_SC1_DMATXENDADDBR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $20 + constant SC1_DMA_SC1_DMARXCNTAR	\ read-write		\  : RESET_SC1_DMA_SC1_DMARXCNTAR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXCNTAR        \ SC1_DMA_CNT	Bit Offset:0	Bit Width:13
        
        SC1_DMA $24 + constant SC1_DMA_SC1_DMARXCNTBR	\ read-write		\  : RESET_SC1_DMA_SC1_DMARXCNTBR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXCNTBR        \ SC1_DMA_CNT	Bit Offset:0	Bit Width:13
        
        SC1_DMA $28 + constant SC1_DMA_SC1_DMATXCNTR	\ read-only		\  : RESET_SC1_DMA_SC1_DMATXCNTR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMATXCNTR        \ SC1_DMA_CNT	Bit Offset:0	Bit Width:13
        
        SC1_DMA $2C + constant SC1_DMA_SC1_DMASR	\ read-only		\  : RESET_SC1_DMA_SC1_DMASR $00000000 
        \ %xxx  10 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_NSSS	Bit Offset:10	Bit Width:3
        \ %x  9 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_FEB	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_FEA	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_PEB	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_PEA	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_OVRB	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_OVRA	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_TXBACK	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_TXAACK	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_RXBACK	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_DMA_SC1_DMASR        \ SC1_DMA_RXAACK	Bit Offset:0	Bit Width:1
        
        SC1_DMA $30 + constant SC1_DMA_SC1_DMACR	\ 		\  : RESET_SC1_DMA_SC1_DMACR $00000000 
        \ %x  5 lshift SC1_DMA_SC1_DMACR        \ SC1_DMA_TXRST	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_DMA_SC1_DMACR        \ SC1_DMA_RXRST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_DMA_SC1_DMACR        \ SC1_DMA_TXLODB	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_DMA_SC1_DMACR        \ SC1_DMA_TXLODA	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_DMA_SC1_DMACR        \ SC1_DMA_RXLODB	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_DMA_SC1_DMACR        \ SC1_DMA_RXLODA	Bit Offset:0	Bit Width:1
        
        SC1_DMA $34 + constant SC1_DMA_SC1_DMARXERRAR	\ read-only		\  : RESET_SC1_DMA_SC1_DMARXERRAR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXERRAR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $38 + constant SC1_DMA_SC1_DMARXERRBR	\ read-only		\  : RESET_SC1_DMA_SC1_DMARXERRBR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXERRBR        \ SC1_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC1_DMA $70 + constant SC1_DMA_SC1_DMARXCNTSAVEDR	\ read-only		\  : RESET_SC1_DMA_SC1_DMARXCNTSAVEDR $00000000 
        \ % 0 lshift SC1_DMA_SC1_DMARXCNTSAVEDR        \ SC1_DMA_CNT	Bit Offset:0	Bit Width:13
        
         
	
     $4000C848 constant SC1_UART  
	 SC1_UART $0 + constant SC1_UART_SC1_UARTSR	\ read-only		\  : RESET_SC1_UART_SC1_UARTSR $00000040 
        \ %x  6 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_IDLE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_PE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_FE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_OVR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_TXE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_RXNE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_UART_SC1_UARTSR        \ SC1_UART_CTS	Bit Offset:0	Bit Width:1
        
        SC1_UART $14 + constant SC1_UART_SC1_UARTCR	\ read-write		\  : RESET_SC1_UART_SC1_UARTCR $00000000 
        \ %x  6 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_AHFCE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_HFCE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_PS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_PCE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_STOP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_M	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_UART_SC1_UARTCR        \ SC1_UART_nRTS	Bit Offset:0	Bit Width:1
        
        SC1_UART $20 + constant SC1_UART_SC1_UARTBRR1	\ read-write		\  : RESET_SC1_UART_SC1_UARTBRR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift SC1_UART_SC1_UARTBRR1        \ SC1_UART_N	Bit Offset:0	Bit Width:16
        
        SC1_UART $24 + constant SC1_UART_SC1_UARTBRR2	\ read-write		\  : RESET_SC1_UART_SC1_UARTBRR2 $00000000 
        \ %x  0 lshift SC1_UART_SC1_UARTBRR2        \ SC1_UART_F	Bit Offset:0	Bit Width:1
        
         
	
     $4000C844 constant SC1_I2C  
	 SC1_I2C $0 + constant SC1_I2C_SC1_I2CSR	\ read-only		\  : RESET_SC1_I2C_SC1_I2CSR $00000000 
        \ %x  3 lshift SC1_I2C_SC1_I2CSR        \ SC1_I2C_CMDFIN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_I2C_SC1_I2CSR        \ SC1_I2C_BRF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_I2C_SC1_I2CSR        \ SC1_I2C_BTF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_I2C_SC1_I2CSR        \ SC1_I2C_NACK	Bit Offset:0	Bit Width:1
        
        SC1_I2C $8 + constant SC1_I2C_SC1_I2CCR1	\ read-write		\  : RESET_SC1_I2C_SC1_I2CCR1 $00000000 
        \ %x  3 lshift SC1_I2C_SC1_I2CCR1        \ SC1_I2C_STOP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_I2C_SC1_I2CCR1        \ SC1_I2C_START	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_I2C_SC1_I2CCR1        \ SC1_I2C_BTE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_I2C_SC1_I2CCR1        \ SC1_I2C_BRE	Bit Offset:0	Bit Width:1
        
        SC1_I2C $C + constant SC1_I2C_SC1_I2CCR2	\ read-write		\  : RESET_SC1_I2C_SC1_I2CCR2 $00000000 
        \ %x  0 lshift SC1_I2C_SC1_I2CCR2        \ SC1_I2C_ACK	Bit Offset:0	Bit Width:1
        
         
	
     $4000C840 constant SC1_SPI  
	 SC1_SPI $0 + constant SC1_SPI_SC1_SPISR	\ read-only		\  : RESET_SC1_SPI_SC1_SPISR $00000000 
        \ %x  3 lshift SC1_SPI_SC1_SPISR        \ SC1_SPI_IDLE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_SPI_SC1_SPISR        \ SC1_SPI_TXE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_SPI_SC1_SPISR        \ SC1_SPI_RXNE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_SPI_SC1_SPISR        \ SC1_SPI_OVF	Bit Offset:0	Bit Width:1
        
        SC1_SPI $18 + constant SC1_SPI_SC1_SPICR	\ read-write		\  : RESET_SC1_SPI_SC1_SPICR $00000000 
        \ %x  5 lshift SC1_SPI_SC1_SPICR        \ SC1_SPI_RXMODE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC1_SPI_SC1_SPICR        \ SC1_SPI_MSTR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC1_SPI_SC1_SPICR        \ SC1_SPI_RPTEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC1_SPI_SC1_SPICR        \ SC1_SPI_LSBFIRST	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC1_SPI_SC1_SPICR        \ SC1_SPI_CPHA	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC1_SPI_SC1_SPICR        \ SC1_SPI_CPOL	Bit Offset:0	Bit Width:1
        
         
	
     $4000C000 constant SC2_DMA  
	 SC2_DMA $0 + constant SC2_DMA_SC2_DMARXBEGADDAR	\ read-write		\  : RESET_SC2_DMA_SC2_DMARXBEGADDAR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXBEGADDAR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $4 + constant SC2_DMA_SC2_DMARXENDADDAR	\ read-write		\  : RESET_SC2_DMA_SC2_DMARXENDADDAR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXENDADDAR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $8 + constant SC2_DMA_SC2_DMARXBEGADDBR	\ read-write		\  : RESET_SC2_DMA_SC2_DMARXBEGADDBR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXBEGADDBR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $C + constant SC2_DMA_SC2_DMARXENDADDBR	\ read-write		\  : RESET_SC2_DMA_SC2_DMARXENDADDBR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXENDADDBR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $10 + constant SC2_DMA_SC2_DMATXBEGADDAR	\ read-write		\  : RESET_SC2_DMA_SC2_DMATXBEGADDAR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMATXBEGADDAR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $14 + constant SC2_DMA_SC2_DMATXENDADDAR	\ read-write		\  : RESET_SC2_DMA_SC2_DMATXENDADDAR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMATXENDADDAR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $18 + constant SC2_DMA_SC2_DMATXBEGADDBR	\ read-write		\  : RESET_SC2_DMA_SC2_DMATXBEGADDBR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMATXBEGADDBR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $1C + constant SC2_DMA_SC2_DMATXENDADDBR	\ read-write		\  : RESET_SC2_DMA_SC2_DMATXENDADDBR $20000000 
        \ % 0 lshift SC2_DMA_SC2_DMATXENDADDBR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $20 + constant SC2_DMA_SC2_DMARXCNTAR	\ read-write		\  : RESET_SC2_DMA_SC2_DMARXCNTAR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXCNTAR        \ SC2_DMA_CNT	Bit Offset:0	Bit Width:13
        
        SC2_DMA $24 + constant SC2_DMA_SC2_DMARXCNTBR	\ read-write		\  : RESET_SC2_DMA_SC2_DMARXCNTBR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXCNTBR        \ SC2_DMA_CNT	Bit Offset:0	Bit Width:13
        
        SC2_DMA $28 + constant SC2_DMA_SC2_DMATXCNTR	\ read-only		\  : RESET_SC2_DMA_SC2_DMATXCNTR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMATXCNTR        \ SC2_DMA_CNT	Bit Offset:0	Bit Width:13
        
        SC2_DMA $2C + constant SC2_DMA_SC2_DMASR	\ read-only		\  : RESET_SC2_DMA_SC2_DMASR $00000000 
        \ %xxx  10 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_NSSS	Bit Offset:10	Bit Width:3
        \ %x  9 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_FEB	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_FEA	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_PEB	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_PEA	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_OVRB	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_OVRA	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_TXBACK	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_TXAACK	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_RXBACK	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_DMA_SC2_DMASR        \ SC2_DMA_RXAACK	Bit Offset:0	Bit Width:1
        
        SC2_DMA $30 + constant SC2_DMA_SC2_DMACR	\ 		\  : RESET_SC2_DMA_SC2_DMACR $00000000 
        \ %x  5 lshift SC2_DMA_SC2_DMACR        \ SC2_DMA_TXRST	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC2_DMA_SC2_DMACR        \ SC2_DMA_RXRST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC2_DMA_SC2_DMACR        \ SC2_DMA_TXLODB	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_DMA_SC2_DMACR        \ SC2_DMA_TXLODA	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_DMA_SC2_DMACR        \ SC2_DMA_RXLODB	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_DMA_SC2_DMACR        \ SC2_DMA_RXLODA	Bit Offset:0	Bit Width:1
        
        SC2_DMA $34 + constant SC2_DMA_SC2_DMARXERRAR	\ read-only		\  : RESET_SC2_DMA_SC2_DMARXERRAR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXERRAR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $38 + constant SC2_DMA_SC2_DMARXERRBR	\ read-only		\  : RESET_SC2_DMA_SC2_DMARXERRBR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXERRBR        \ SC2_DMA_ADD	Bit Offset:0	Bit Width:13
        
        SC2_DMA $70 + constant SC2_DMA_SC2_DMARXCNTSAVEDR	\ read-only		\  : RESET_SC2_DMA_SC2_DMARXCNTSAVEDR $00000000 
        \ % 0 lshift SC2_DMA_SC2_DMARXCNTSAVEDR        \ SC2_DMA_CNT	Bit Offset:0	Bit Width:13
        
         
	
     $4000C044 constant SC2_I2C  
	 SC2_I2C $0 + constant SC2_I2C_SC2_I2CSR	\ read-only		\  : RESET_SC2_I2C_SC2_I2CSR $00000000 
        \ %x  3 lshift SC2_I2C_SC2_I2CSR        \ SC2_I2C_CMDFIN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_I2C_SC2_I2CSR        \ SC2_I2C_BRF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_I2C_SC2_I2CSR        \ SC2_I2C_BTF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_I2C_SC2_I2CSR        \ SC2_I2C_NACK	Bit Offset:0	Bit Width:1
        
        SC2_I2C $8 + constant SC2_I2C_SC2_I2CCR1	\ read-write		\  : RESET_SC2_I2C_SC2_I2CCR1 $00000000 
        \ %x  3 lshift SC2_I2C_SC2_I2CCR1        \ SC2_I2C_STOP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_I2C_SC2_I2CCR1        \ SC2_I2C_START	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_I2C_SC2_I2CCR1        \ SC2_I2C_BTE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_I2C_SC2_I2CCR1        \ SC2_I2C_BRE	Bit Offset:0	Bit Width:1
        
        SC2_I2C $C + constant SC2_I2C_SC2_I2CCR2	\ read-write		\  : RESET_SC2_I2C_SC2_I2CCR2 $00000000 
        \ %x  0 lshift SC2_I2C_SC2_I2CCR2        \ SC2_I2C_ACK	Bit Offset:0	Bit Width:1
        
         
	
     $4000C040 constant SC2_SPI  
	 SC2_SPI $0 + constant SC2_SPI_SC2_SPISR	\ read-only		\  : RESET_SC2_SPI_SC2_SPISR $00000000 
        \ %x  3 lshift SC2_SPI_SC2_SPISR        \ SC2_SPI_IDLE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_SPI_SC2_SPISR        \ SC2_SPI_TXE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_SPI_SC2_SPISR        \ SC2_SPI_RXNE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_SPI_SC2_SPISR        \ SC2_SPI_OVF	Bit Offset:0	Bit Width:1
        
        SC2_SPI $18 + constant SC2_SPI_SC2_SPICR	\ read-write		\  : RESET_SC2_SPI_SC2_SPICR $00000000 
        \ %x  5 lshift SC2_SPI_SC2_SPICR        \ SC2_SPI_RXMODE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SC2_SPI_SC2_SPICR        \ SC2_SPI_MSTR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SC2_SPI_SC2_SPICR        \ SC2_SPI_RPTEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SC2_SPI_SC2_SPICR        \ SC2_SPI_LSBFIRST	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SC2_SPI_SC2_SPICR        \ SC2_SPI_CPHA	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SC2_SPI_SC2_SPICR        \ SC2_SPI_CPOL	Bit Offset:0	Bit Width:1
        
         
	
     $40002038 constant MAC_TIM  
	 MAC_TIM $0 + constant MAC_TIM_MACTMR_CNTR	\ read-write		\  : RESET_MAC_TIM_MACTMR_CNTR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxx  0 lshift MAC_TIM_MACTMR_CNTR        \ MAC_TIM_CNT	Bit Offset:0	Bit Width:20
        
        MAC_TIM $54 + constant MAC_TIM_MACTMR_CR	\ read-write		\  : RESET_MAC_TIM_MACTMR_CR $00000000 
        \ %x  0 lshift MAC_TIM_MACTMR_CR        \ MAC_TIM_EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift MAC_TIM_MACTMR_CR        \ MAC_TIM_RST	Bit Offset:1	Bit Width:1
        
         
	
     