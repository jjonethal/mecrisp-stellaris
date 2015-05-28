\  STM32L1xx ARM CMSIS-SVD register file for Mecrisp-Stellaris Forth by Matthias Koch
	\  x = 0 or 1 below in the Register Field bit positions 
	 

    $50060000 constant AES  
	 AES $0 + constant AES_CR	\ read-write		\  : RESET_AES_CR $00000000 
        \ %x  12 lshift AES_CR        \ AES_DMAOUTEN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift AES_CR        \ AES_DMAINEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift AES_CR        \ AES_ERRIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift AES_CR        \ AES_CCFIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift AES_CR        \ AES_ERRC	Bit Offset:8	Bit Width:1
        \ %x  7 lshift AES_CR        \ AES_CCFC	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift AES_CR        \ AES_CHMOD	Bit Offset:5	Bit Width:2
        \ %xx  3 lshift AES_CR        \ AES_MODE	Bit Offset:3	Bit Width:2
        \ %xx  1 lshift AES_CR        \ AES_DATATYPE	Bit Offset:1	Bit Width:2
        \ %x  0 lshift AES_CR        \ AES_EN	Bit Offset:0	Bit Width:1
        
        AES $4 + constant AES_SR	\ read-only		\  : RESET_AES_SR $00000000 
        \ %x  2 lshift AES_SR        \ AES_WRERR	Bit Offset:2	Bit Width:1
        \ %x  1 lshift AES_SR        \ AES_RDERR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift AES_SR        \ AES_CCF	Bit Offset:0	Bit Width:1
        
        AES $8 + constant AES_DINR	\ read-write		\  : RESET_AES_DINR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_DINR        \ AES_DINR	Bit Offset:0	Bit Width:32
        
        AES $C + constant AES_DOUTR	\ read-only		\  : RESET_AES_DOUTR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_DOUTR        \ AES_DOUTR	Bit Offset:0	Bit Width:32
        
        AES $10 + constant AES_KEYR0	\ read-write		\  : RESET_AES_KEYR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_KEYR0        \ AES_KEYR0	Bit Offset:0	Bit Width:32
        
        AES $14 + constant AES_KEYR1	\ read-write		\  : RESET_AES_KEYR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_KEYR1        \ AES_KEYR1	Bit Offset:0	Bit Width:32
        
        AES $18 + constant AES_KEYR2	\ read-write		\  : RESET_AES_KEYR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_KEYR2        \ AES_KEYR2	Bit Offset:0	Bit Width:32
        
        AES $1C + constant AES_KEYR3	\ read-write		\  : RESET_AES_KEYR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_KEYR3        \ AES_KEYR3	Bit Offset:0	Bit Width:32
        
        AES $20 + constant AES_IVR0	\ read-write		\  : RESET_AES_IVR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_IVR0        \ AES_IVR0	Bit Offset:0	Bit Width:32
        
        AES $24 + constant AES_IVR1	\ read-write		\  : RESET_AES_IVR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_IVR1        \ AES_IVR1	Bit Offset:0	Bit Width:32
        
        AES $28 + constant AES_IVR2	\ read-write		\  : RESET_AES_IVR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_IVR2        \ AES_IVR2	Bit Offset:0	Bit Width:32
        
        AES $2C + constant AES_IVR3	\ read-write		\  : RESET_AES_IVR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift AES_IVR3        \ AES_IVR3	Bit Offset:0	Bit Width:32
        
         
	
     $40012700 constant C_ADC  
	 C_ADC $0 + constant C_ADC_CSR	\ read-only		\  : RESET_C_ADC_CSR $00000000 
        \ %x  6 lshift C_ADC_CSR        \ C_ADC_ADONS1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift C_ADC_CSR        \ C_ADC_OVR1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift C_ADC_CSR        \ C_ADC_STRT1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift C_ADC_CSR        \ C_ADC_JSTRT1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift C_ADC_CSR        \ C_ADC_JEOC1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift C_ADC_CSR        \ C_ADC_EOC1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift C_ADC_CSR        \ C_ADC_AWD1	Bit Offset:0	Bit Width:1
        
        C_ADC $4 + constant C_ADC_CCR	\ read-write		\  : RESET_C_ADC_CCR $00000000 
        \ %x  23 lshift C_ADC_CCR        \ C_ADC_TSVREFE	Bit Offset:23	Bit Width:1
        \ %xx  16 lshift C_ADC_CCR        \ C_ADC_ADCPRE	Bit Offset:16	Bit Width:2
        
         
	
     $40007C00 constant COMP  
	 COMP $0 + constant COMP_CSR	\ 		\  : RESET_COMP_CSR $00000000 
        \ %x  31 lshift COMP_CSR        \ COMP_TSUSP	Bit Offset:31	Bit Width:1
        \ %x  30 lshift COMP_CSR        \ COMP_CAIF	Bit Offset:30	Bit Width:1
        \ %x  29 lshift COMP_CSR        \ COMP_CAIE	Bit Offset:29	Bit Width:1
        \ %x  28 lshift COMP_CSR        \ COMP_RCH13	Bit Offset:28	Bit Width:1
        \ %x  27 lshift COMP_CSR        \ COMP_FCH8	Bit Offset:27	Bit Width:1
        \ %x  26 lshift COMP_CSR        \ COMP_FCH3	Bit Offset:26	Bit Width:1
        \ %xxx  21 lshift COMP_CSR        \ COMP_OUTSEL	Bit Offset:21	Bit Width:3
        \ %xxx  18 lshift COMP_CSR        \ COMP_INSEL	Bit Offset:18	Bit Width:3
        \ %x  17 lshift COMP_CSR        \ COMP_WNDWE	Bit Offset:17	Bit Width:1
        \ %x  16 lshift COMP_CSR        \ COMP_VREFOUTEN	Bit Offset:16	Bit Width:1
        \ %x  13 lshift COMP_CSR        \ COMP_CMP2OUT	Bit Offset:13	Bit Width:1
        \ %x  12 lshift COMP_CSR        \ COMP_SPEED	Bit Offset:12	Bit Width:1
        \ %x  7 lshift COMP_CSR        \ COMP_CMP1OUT	Bit Offset:7	Bit Width:1
        \ %x  5 lshift COMP_CSR        \ COMP_SW1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift COMP_CSR        \ COMP_CMP1EN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift COMP_CSR        \ COMP_PD400K	Bit Offset:3	Bit Width:1
        \ %x  2 lshift COMP_CSR        \ COMP_PD10K	Bit Offset:2	Bit Width:1
        \ %x  1 lshift COMP_CSR        \ COMP_PU400K	Bit Offset:1	Bit Width:1
        \ %x  0 lshift COMP_CSR        \ COMP_PU10K	Bit Offset:0	Bit Width:1
        
         
	
     $40023000 constant CRC  
	 CRC $0 + constant CRC_DR	\ read-write		\  : RESET_CRC_DR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift CRC_DR        \ CRC_Data_register	Bit Offset:0	Bit Width:32
        
        CRC $4 + constant CRC_IDR	\ read-write		\  : RESET_CRC_IDR $00000000 
        \ %xxxxxxx  0 lshift CRC_IDR        \ CRC_Independent_data_register	Bit Offset:0	Bit Width:7
        
        CRC $8 + constant CRC_CR	\ write-only		\  : RESET_CRC_CR $00000000 
        \ %x  0 lshift CRC_CR        \ CRC_RESET	Bit Offset:0	Bit Width:1
        
         
	
     $40007400 constant DAC  
	 DAC $0 + constant DAC_CR	\ read-write		\  : RESET_DAC_CR $00000000 
        \ %x  29 lshift DAC_CR        \ DAC_DMAUDRIE2	Bit Offset:29	Bit Width:1
        \ %x  28 lshift DAC_CR        \ DAC_DMAEN2	Bit Offset:28	Bit Width:1
        \ %xxxx  24 lshift DAC_CR        \ DAC_MAMP2	Bit Offset:24	Bit Width:4
        \ %xx  22 lshift DAC_CR        \ DAC_WAVE2	Bit Offset:22	Bit Width:2
        \ %xxx  19 lshift DAC_CR        \ DAC_TSEL2	Bit Offset:19	Bit Width:3
        \ %x  18 lshift DAC_CR        \ DAC_TEN2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift DAC_CR        \ DAC_BOFF2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift DAC_CR        \ DAC_EN2	Bit Offset:16	Bit Width:1
        \ %x  13 lshift DAC_CR        \ DAC_DMAUDRIE1	Bit Offset:13	Bit Width:1
        \ %x  12 lshift DAC_CR        \ DAC_DMAEN1	Bit Offset:12	Bit Width:1
        \ %xxxx  8 lshift DAC_CR        \ DAC_MAMP1	Bit Offset:8	Bit Width:4
        \ %xx  6 lshift DAC_CR        \ DAC_WAVE1	Bit Offset:6	Bit Width:2
        \ %xxx  3 lshift DAC_CR        \ DAC_TSEL1	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DAC_CR        \ DAC_TEN1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DAC_CR        \ DAC_BOFF1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DAC_CR        \ DAC_EN1	Bit Offset:0	Bit Width:1
        
        DAC $4 + constant DAC_SWTRIGR	\ write-only		\  : RESET_DAC_SWTRIGR $00000000 
        \ %x  1 lshift DAC_SWTRIGR        \ DAC_SWTRIG2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DAC_SWTRIGR        \ DAC_SWTRIG1	Bit Offset:0	Bit Width:1
        
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
        \ %xxxxxxxxxxxx  16 lshift DAC_DHR12RD        \ DAC_DACC2DHR	Bit Offset:16	Bit Width:12
        \ %xxxxxxxxxxxx  0 lshift DAC_DHR12RD        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:12
        
        DAC $24 + constant DAC_DHR12LD	\ read-write		\  : RESET_DAC_DHR12LD $00000000 
        \ %xxxxxxxxxxxx  20 lshift DAC_DHR12LD        \ DAC_DACC2DHR	Bit Offset:20	Bit Width:12
        \ %xxxxxxxxxxxx  4 lshift DAC_DHR12LD        \ DAC_DACC1DHR	Bit Offset:4	Bit Width:12
        
        DAC $28 + constant DAC_DHR8RD	\ read-write		\  : RESET_DAC_DHR8RD $00000000 
        \ %xxxxxxxx  8 lshift DAC_DHR8RD        \ DAC_DACC2DHR	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift DAC_DHR8RD        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:8
        
        DAC $2C + constant DAC_DOR1	\ read-only		\  : RESET_DAC_DOR1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DOR1        \ DAC_DACC1DOR	Bit Offset:0	Bit Width:12
        
        DAC $30 + constant DAC_DOR2	\ read-only		\  : RESET_DAC_DOR2 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DOR2        \ DAC_DACC2DOR	Bit Offset:0	Bit Width:12
        
        DAC $34 + constant DAC_SR	\ read-write		\  : RESET_DAC_SR $00000000 
        \ %x  29 lshift DAC_SR        \ DAC_DMAUDR2	Bit Offset:29	Bit Width:1
        \ %x  13 lshift DAC_SR        \ DAC_DMAUDR1	Bit Offset:13	Bit Width:1
        
         
	
     $40026000 constant DMA1  
	 DMA1 $0 + constant DMA1_ISR	\ read-only		\  : RESET_DMA1_ISR $00000000 
        \ %x  27 lshift DMA1_ISR        \ DMA1_TEIF7	Bit Offset:27	Bit Width:1
        \ %x  26 lshift DMA1_ISR        \ DMA1_HTIF7	Bit Offset:26	Bit Width:1
        \ %x  25 lshift DMA1_ISR        \ DMA1_TCIF7	Bit Offset:25	Bit Width:1
        \ %x  24 lshift DMA1_ISR        \ DMA1_GIF7	Bit Offset:24	Bit Width:1
        \ %x  23 lshift DMA1_ISR        \ DMA1_TEIF6	Bit Offset:23	Bit Width:1
        \ %x  22 lshift DMA1_ISR        \ DMA1_HTIF6	Bit Offset:22	Bit Width:1
        \ %x  21 lshift DMA1_ISR        \ DMA1_TCIF6	Bit Offset:21	Bit Width:1
        \ %x  20 lshift DMA1_ISR        \ DMA1_GIF6	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA1_ISR        \ DMA1_TEIF5	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA1_ISR        \ DMA1_HTIF5	Bit Offset:18	Bit Width:1
        \ %x  17 lshift DMA1_ISR        \ DMA1_TCIF5	Bit Offset:17	Bit Width:1
        \ %x  16 lshift DMA1_ISR        \ DMA1_GIF5	Bit Offset:16	Bit Width:1
        \ %x  15 lshift DMA1_ISR        \ DMA1_TEIF4	Bit Offset:15	Bit Width:1
        \ %x  14 lshift DMA1_ISR        \ DMA1_HTIF4	Bit Offset:14	Bit Width:1
        \ %x  13 lshift DMA1_ISR        \ DMA1_TCIF4	Bit Offset:13	Bit Width:1
        \ %x  12 lshift DMA1_ISR        \ DMA1_GIF4	Bit Offset:12	Bit Width:1
        \ %x  11 lshift DMA1_ISR        \ DMA1_TEIF3	Bit Offset:11	Bit Width:1
        \ %x  10 lshift DMA1_ISR        \ DMA1_HTIF3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA1_ISR        \ DMA1_TCIF3	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA1_ISR        \ DMA1_GIF3	Bit Offset:8	Bit Width:1
        \ %x  7 lshift DMA1_ISR        \ DMA1_TEIF2	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_ISR        \ DMA1_HTIF2	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_ISR        \ DMA1_TCIF2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_ISR        \ DMA1_GIF2	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_ISR        \ DMA1_TEIF1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_ISR        \ DMA1_HTIF1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_ISR        \ DMA1_TCIF1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_ISR        \ DMA1_GIF1	Bit Offset:0	Bit Width:1
        
        DMA1 $4 + constant DMA1_IFCR	\ write-only		\  : RESET_DMA1_IFCR $00000000 
        \ %x  27 lshift DMA1_IFCR        \ DMA1_CTEIF7	Bit Offset:27	Bit Width:1
        \ %x  26 lshift DMA1_IFCR        \ DMA1_CHTIF7	Bit Offset:26	Bit Width:1
        \ %x  25 lshift DMA1_IFCR        \ DMA1_CTCIF7	Bit Offset:25	Bit Width:1
        \ %x  24 lshift DMA1_IFCR        \ DMA1_CGIF7	Bit Offset:24	Bit Width:1
        \ %x  23 lshift DMA1_IFCR        \ DMA1_CTEIF6	Bit Offset:23	Bit Width:1
        \ %x  22 lshift DMA1_IFCR        \ DMA1_CHTIF6	Bit Offset:22	Bit Width:1
        \ %x  21 lshift DMA1_IFCR        \ DMA1_CTCIF6	Bit Offset:21	Bit Width:1
        \ %x  20 lshift DMA1_IFCR        \ DMA1_CGIF6	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA1_IFCR        \ DMA1_CTEIF5	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA1_IFCR        \ DMA1_CHTIF5	Bit Offset:18	Bit Width:1
        \ %x  17 lshift DMA1_IFCR        \ DMA1_CTCIF5	Bit Offset:17	Bit Width:1
        \ %x  16 lshift DMA1_IFCR        \ DMA1_CGIF5	Bit Offset:16	Bit Width:1
        \ %x  15 lshift DMA1_IFCR        \ DMA1_CTEIF4	Bit Offset:15	Bit Width:1
        \ %x  14 lshift DMA1_IFCR        \ DMA1_CHTIF4	Bit Offset:14	Bit Width:1
        \ %x  13 lshift DMA1_IFCR        \ DMA1_CTCIF4	Bit Offset:13	Bit Width:1
        \ %x  12 lshift DMA1_IFCR        \ DMA1_CGIF4	Bit Offset:12	Bit Width:1
        \ %x  11 lshift DMA1_IFCR        \ DMA1_CTEIF3	Bit Offset:11	Bit Width:1
        \ %x  10 lshift DMA1_IFCR        \ DMA1_CHTIF3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA1_IFCR        \ DMA1_CTCIF3	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA1_IFCR        \ DMA1_CGIF3	Bit Offset:8	Bit Width:1
        \ %x  7 lshift DMA1_IFCR        \ DMA1_CTEIF2	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_IFCR        \ DMA1_CHTIF2	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_IFCR        \ DMA1_CTCIF2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_IFCR        \ DMA1_CGIF2	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_IFCR        \ DMA1_CTEIF1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_IFCR        \ DMA1_CHTIF1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_IFCR        \ DMA1_CTCIF1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_IFCR        \ DMA1_CGIF1	Bit Offset:0	Bit Width:1
        
        DMA1 $8 + constant DMA1_CCR1	\ read-write		\  : RESET_DMA1_CCR1 $00000000 
        \ %x  14 lshift DMA1_CCR1        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR1        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR1        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR1        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR1        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR1        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR1        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR1        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR1        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR1        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR1        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR1        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $C + constant DMA1_CNDTR1	\ read-write		\  : RESET_DMA1_CNDTR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR1        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $10 + constant DMA1_CPAR1	\ read-write		\  : RESET_DMA1_CPAR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR1        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $14 + constant DMA1_CMAR1	\ read-write		\  : RESET_DMA1_CMAR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR1        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $1C + constant DMA1_CCR2	\ read-write		\  : RESET_DMA1_CCR2 $00000000 
        \ %x  14 lshift DMA1_CCR2        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR2        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR2        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR2        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR2        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR2        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR2        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR2        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR2        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR2        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR2        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR2        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $20 + constant DMA1_CNDTR2	\ read-write		\  : RESET_DMA1_CNDTR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR2        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $24 + constant DMA1_CPAR2	\ read-write		\  : RESET_DMA1_CPAR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR2        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $28 + constant DMA1_CMAR2	\ read-write		\  : RESET_DMA1_CMAR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR2        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $30 + constant DMA1_CCR3	\ read-write		\  : RESET_DMA1_CCR3 $00000000 
        \ %x  14 lshift DMA1_CCR3        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR3        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR3        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR3        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR3        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR3        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR3        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR3        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR3        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR3        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR3        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR3        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $34 + constant DMA1_CNDTR3	\ read-write		\  : RESET_DMA1_CNDTR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR3        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $38 + constant DMA1_CPAR3	\ read-write		\  : RESET_DMA1_CPAR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR3        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $3C + constant DMA1_CMAR3	\ read-write		\  : RESET_DMA1_CMAR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR3        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $44 + constant DMA1_CCR4	\ read-write		\  : RESET_DMA1_CCR4 $00000000 
        \ %x  14 lshift DMA1_CCR4        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR4        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR4        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR4        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR4        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR4        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR4        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR4        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR4        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR4        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR4        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR4        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $48 + constant DMA1_CNDTR4	\ read-write		\  : RESET_DMA1_CNDTR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR4        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $4C + constant DMA1_CPAR4	\ read-write		\  : RESET_DMA1_CPAR4 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR4        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $50 + constant DMA1_CMAR4	\ read-write		\  : RESET_DMA1_CMAR4 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR4        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $58 + constant DMA1_CCR5	\ read-write		\  : RESET_DMA1_CCR5 $00000000 
        \ %x  14 lshift DMA1_CCR5        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR5        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR5        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR5        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR5        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR5        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR5        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR5        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR5        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR5        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR5        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR5        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $5C + constant DMA1_CNDTR5	\ read-write		\  : RESET_DMA1_CNDTR5 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR5        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $60 + constant DMA1_CPAR5	\ read-write		\  : RESET_DMA1_CPAR5 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR5        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $64 + constant DMA1_CMAR5	\ read-write		\  : RESET_DMA1_CMAR5 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR5        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $6C + constant DMA1_CCR6	\ read-write		\  : RESET_DMA1_CCR6 $00000000 
        \ %x  14 lshift DMA1_CCR6        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR6        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR6        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR6        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR6        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR6        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR6        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR6        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR6        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR6        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR6        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR6        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $70 + constant DMA1_CNDTR6	\ read-write		\  : RESET_DMA1_CNDTR6 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR6        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $74 + constant DMA1_CPAR6	\ read-write		\  : RESET_DMA1_CPAR6 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR6        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $78 + constant DMA1_CMAR6	\ read-write		\  : RESET_DMA1_CMAR6 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR6        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
        DMA1 $80 + constant DMA1_CCR7	\ read-write		\  : RESET_DMA1_CCR7 $00000000 
        \ %x  14 lshift DMA1_CCR7        \ DMA1_MEM2MEM	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift DMA1_CCR7        \ DMA1_PL	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift DMA1_CCR7        \ DMA1_MSIZE	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DMA1_CCR7        \ DMA1_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DMA1_CCR7        \ DMA1_MINC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DMA1_CCR7        \ DMA1_PINC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA1_CCR7        \ DMA1_CIRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA1_CCR7        \ DMA1_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA1_CCR7        \ DMA1_TEIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA1_CCR7        \ DMA1_HTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA1_CCR7        \ DMA1_TCIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA1_CCR7        \ DMA1_EN	Bit Offset:0	Bit Width:1
        
        DMA1 $84 + constant DMA1_CNDTR7	\ read-write		\  : RESET_DMA1_CNDTR7 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA1_CNDTR7        \ DMA1_NDT	Bit Offset:0	Bit Width:16
        
        DMA1 $88 + constant DMA1_CPAR7	\ read-write		\  : RESET_DMA1_CPAR7 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CPAR7        \ DMA1_PA	Bit Offset:0	Bit Width:32
        
        DMA1 $8C + constant DMA1_CMAR7	\ read-write		\  : RESET_DMA1_CMAR7 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA1_CMAR7        \ DMA1_MA	Bit Offset:0	Bit Width:32
        
         
	
     $40026400 constant DMA2  
	  
	
     $40010400 constant EXTI  
	 EXTI $0 + constant EXTI_IMR	\ read-write		\  : RESET_EXTI_IMR $00000000 
        \ % 0 lshift EXTI_IMR        \ EXTI_MR	Bit Offset:0	Bit Width:23
        
        EXTI $4 + constant EXTI_EMR	\ read-write		\  : RESET_EXTI_EMR $00000000 
        \ % 0 lshift EXTI_EMR        \ EXTI_MR	Bit Offset:0	Bit Width:23
        
        EXTI $8 + constant EXTI_RTSR	\ read-write		\  : RESET_EXTI_RTSR $00000000 
        \ % 0 lshift EXTI_RTSR        \ EXTI_TR	Bit Offset:0	Bit Width:23
        
        EXTI $C + constant EXTI_FTSR	\ read-write		\  : RESET_EXTI_FTSR $00000000 
        \ % 0 lshift EXTI_FTSR        \ EXTI_TR	Bit Offset:0	Bit Width:23
        
        EXTI $10 + constant EXTI_SWIER	\ read-write		\  : RESET_EXTI_SWIER $00000000 
        \ % 0 lshift EXTI_SWIER        \ EXTI_SWIER	Bit Offset:0	Bit Width:23
        
        EXTI $14 + constant EXTI_PR	\ read-write		\  : RESET_EXTI_PR $00000000 
        \ % 0 lshift EXTI_PR        \ EXTI_PR	Bit Offset:0	Bit Width:23
        
         
	
     $40023C00 constant Flash  
	 Flash $0 + constant Flash_ACR	\ read-write		\  : RESET_Flash_ACR $00000000 
        \ %x  0 lshift Flash_ACR        \ Flash_LATENCY	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Flash_ACR        \ Flash_PRFTEN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Flash_ACR        \ Flash_ACC64	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Flash_ACR        \ Flash_SLEEP_PD	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Flash_ACR        \ Flash_RUN_PD	Bit Offset:4	Bit Width:1
        
        Flash $4 + constant Flash_PECR	\ read-write		\  : RESET_Flash_PECR $00000007 
        \ %x  0 lshift Flash_PECR        \ Flash_PELOCK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Flash_PECR        \ Flash_PRGLOCK	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Flash_PECR        \ Flash_OPTLOCK	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Flash_PECR        \ Flash_PROG	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Flash_PECR        \ Flash_DATA	Bit Offset:4	Bit Width:1
        \ %x  8 lshift Flash_PECR        \ Flash_FTDW	Bit Offset:8	Bit Width:1
        \ %x  9 lshift Flash_PECR        \ Flash_ERASE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift Flash_PECR        \ Flash_FPRG	Bit Offset:10	Bit Width:1
        \ %x  15 lshift Flash_PECR        \ Flash_PARALLELBANK	Bit Offset:15	Bit Width:1
        \ %x  16 lshift Flash_PECR        \ Flash_EOPIE	Bit Offset:16	Bit Width:1
        \ %x  17 lshift Flash_PECR        \ Flash_ERRIE	Bit Offset:17	Bit Width:1
        \ %x  18 lshift Flash_PECR        \ Flash_OBL_LAUNCH	Bit Offset:18	Bit Width:1
        
        Flash $8 + constant Flash_PDKEYR	\ write-only		\  : RESET_Flash_PDKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_PDKEYR        \ Flash_PDKEYR	Bit Offset:0	Bit Width:32
        
        Flash $C + constant Flash_PEKEYR	\ write-only		\  : RESET_Flash_PEKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_PEKEYR        \ Flash_PEKEYR	Bit Offset:0	Bit Width:32
        
        Flash $10 + constant Flash_PRGKEYR	\ write-only		\  : RESET_Flash_PRGKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_PRGKEYR        \ Flash_PRGKEYR	Bit Offset:0	Bit Width:32
        
        Flash $14 + constant Flash_OPTKEYR	\ write-only		\  : RESET_Flash_OPTKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_OPTKEYR        \ Flash_OPTKEYR	Bit Offset:0	Bit Width:32
        
        Flash $18 + constant Flash_SR	\ 		\  : RESET_Flash_SR $00000004 
        \ %x  0 lshift Flash_SR        \ Flash_BSY	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Flash_SR        \ Flash_EOP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Flash_SR        \ Flash_ENDHV	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Flash_SR        \ Flash_READY	Bit Offset:3	Bit Width:1
        \ %x  8 lshift Flash_SR        \ Flash_WRPERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift Flash_SR        \ Flash_PGAERR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift Flash_SR        \ Flash_SIZERR	Bit Offset:10	Bit Width:1
        \ %x  11 lshift Flash_SR        \ Flash_OPTVERR	Bit Offset:11	Bit Width:1
        \ %x  12 lshift Flash_SR        \ Flash_OPTVERRUSR	Bit Offset:12	Bit Width:1
        
        Flash $1C + constant Flash_OBR	\ read-only		\  : RESET_Flash_OBR $00F80000 
        \ %xxxxxxxx  0 lshift Flash_OBR        \ Flash_RDPRT	Bit Offset:0	Bit Width:8
        \ %xxxx  16 lshift Flash_OBR        \ Flash_BOR_LEV	Bit Offset:16	Bit Width:4
        \ %x  20 lshift Flash_OBR        \ Flash_IWDG_SW	Bit Offset:20	Bit Width:1
        \ %x  21 lshift Flash_OBR        \ Flash_nRTS_STOP	Bit Offset:21	Bit Width:1
        \ %x  22 lshift Flash_OBR        \ Flash_nRST_STDBY	Bit Offset:22	Bit Width:1
        \ %x  23 lshift Flash_OBR        \ Flash_BFB2	Bit Offset:23	Bit Width:1
        
        Flash $20 + constant Flash_WRPR1	\ read-write		\  : RESET_Flash_WRPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_WRPR1        \ Flash_WRP1	Bit Offset:0	Bit Width:32
        
        Flash $80 + constant Flash_WRPR2	\ read-write		\  : RESET_Flash_WRPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_WRPR2        \ Flash_WRP2	Bit Offset:0	Bit Width:32
        
        Flash $84 + constant Flash_WRPR3	\ read-write		\  : RESET_Flash_WRPR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Flash_WRPR3        \ Flash_WRP3	Bit Offset:0	Bit Width:32
        
         
	
     $A0000000 constant FSMC  
	 FSMC $0 + constant FSMC_BCR1	\ read-write		\  : RESET_FSMC_BCR1 $00000000 
        \ %x  19 lshift FSMC_BCR1        \ FSMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FSMC_BCR1        \ FSMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FSMC_BCR1        \ FSMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FSMC_BCR1        \ FSMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FSMC_BCR1        \ FSMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FSMC_BCR1        \ FSMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FSMC_BCR1        \ FSMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FSMC_BCR1        \ FSMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FSMC_BCR1        \ FSMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FSMC_BCR1        \ FSMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FSMC_BCR1        \ FSMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FSMC_BCR1        \ FSMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FSMC_BCR1        \ FSMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FSMC_BCR1        \ FSMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FSMC $4 + constant FSMC_BTR1	\ read-write		\  : RESET_FSMC_BTR1 $00000000 
        \ %xx  28 lshift FSMC_BTR1        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR1        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR1        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR1        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR1        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR1        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR1        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $8 + constant FSMC_BCR2	\ read-write		\  : RESET_FSMC_BCR2 $00000000 
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
        
        FSMC $C + constant FSMC_BTR2	\ read-write		\  : RESET_FSMC_BTR2 $00000000 
        \ %xx  28 lshift FSMC_BTR2        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR2        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR2        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR2        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR2        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR2        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR2        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $10 + constant FSMC_BCR3	\ read-write		\  : RESET_FSMC_BCR3 $00000000 
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
        
        FSMC $14 + constant FSMC_BTR3	\ read-write		\  : RESET_FSMC_BTR3 $00000000 
        \ %xx  28 lshift FSMC_BTR3        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR3        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR3        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR3        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR3        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR3        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR3        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $18 + constant FSMC_BCR4	\ read-write		\  : RESET_FSMC_BCR4 $00000000 
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
        
        FSMC $1C + constant FSMC_BTR4	\ read-write		\  : RESET_FSMC_BTR4 $00000000 
        \ %xx  28 lshift FSMC_BTR4        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BTR4        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BTR4        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FSMC_BTR4        \ FSMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BTR4        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BTR4        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BTR4        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $104 + constant FSMC_BWTR1	\ read-write		\  : RESET_FSMC_BWTR1 $00000000 
        \ %xx  28 lshift FSMC_BWTR1        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR1        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR1        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR1        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR1        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR1        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $10C + constant FSMC_BWTR2	\ read-write		\  : RESET_FSMC_BWTR2 $00000000 
        \ %xx  28 lshift FSMC_BWTR2        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR2        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR2        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR2        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR2        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR2        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $114 + constant FSMC_BWTR3	\ read-write		\  : RESET_FSMC_BWTR3 $00000000 
        \ %xx  28 lshift FSMC_BWTR3        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR3        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR3        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR3        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR3        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR3        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FSMC $11C + constant FSMC_BWTR4	\ read-write		\  : RESET_FSMC_BWTR4 $00000000 
        \ %xx  28 lshift FSMC_BWTR4        \ FSMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FSMC_BWTR4        \ FSMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FSMC_BWTR4        \ FSMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FSMC_BWTR4        \ FSMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FSMC_BWTR4        \ FSMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FSMC_BWTR4        \ FSMC_ADDSET	Bit Offset:0	Bit Width:4
        
         
	
     $40020000 constant GPIOA  
	 GPIOA $0 + constant GPIOA_MODER	\ read-write		\  : RESET_GPIOA_MODER $A8000000 
        \ %xx  30 lshift GPIOA_MODER        \ GPIOA_MODER15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOA_MODER        \ GPIOA_MODER14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOA_MODER        \ GPIOA_MODER13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOA_MODER        \ GPIOA_MODER12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOA_MODER        \ GPIOA_MODER11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOA_MODER        \ GPIOA_MODER10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOA_MODER        \ GPIOA_MODER9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOA_MODER        \ GPIOA_MODER8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOA_MODER        \ GPIOA_MODER7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOA_MODER        \ GPIOA_MODER6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOA_MODER        \ GPIOA_MODER5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOA_MODER        \ GPIOA_MODER4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOA_MODER        \ GPIOA_MODER3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOA_MODER        \ GPIOA_MODER2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOA_MODER        \ GPIOA_MODER1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOA_MODER        \ GPIOA_MODER0	Bit Offset:0	Bit Width:2
        
        GPIOA $4 + constant GPIOA_OTYPER	\ read-write		\  : RESET_GPIOA_OTYPER $00000000 
        \ %x  15 lshift GPIOA_OTYPER        \ GPIOA_OT15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_OTYPER        \ GPIOA_OT14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_OTYPER        \ GPIOA_OT13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_OTYPER        \ GPIOA_OT12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_OTYPER        \ GPIOA_OT11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_OTYPER        \ GPIOA_OT10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_OTYPER        \ GPIOA_OT9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_OTYPER        \ GPIOA_OT8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_OTYPER        \ GPIOA_OT7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_OTYPER        \ GPIOA_OT6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_OTYPER        \ GPIOA_OT5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_OTYPER        \ GPIOA_OT4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_OTYPER        \ GPIOA_OT3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_OTYPER        \ GPIOA_OT2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_OTYPER        \ GPIOA_OT1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_OTYPER        \ GPIOA_OT0	Bit Offset:0	Bit Width:1
        
        GPIOA $8 + constant GPIOA_OSPEEDER	\ read-write		\  : RESET_GPIOA_OSPEEDER $00000000 
        \ %xx  30 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOA_OSPEEDER        \ GPIOA_OSPEEDR0	Bit Offset:0	Bit Width:2
        
        GPIOA $C + constant GPIOA_PUPDR	\ read-write		\  : RESET_GPIOA_PUPDR $64000000 
        \ %xx  30 lshift GPIOA_PUPDR        \ GPIOA_PUPDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOA_PUPDR        \ GPIOA_PUPDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOA_PUPDR        \ GPIOA_PUPDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOA_PUPDR        \ GPIOA_PUPDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOA_PUPDR        \ GPIOA_PUPDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOA_PUPDR        \ GPIOA_PUPDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOA_PUPDR        \ GPIOA_PUPDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOA_PUPDR        \ GPIOA_PUPDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOA_PUPDR        \ GPIOA_PUPDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOA_PUPDR        \ GPIOA_PUPDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOA_PUPDR        \ GPIOA_PUPDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOA_PUPDR        \ GPIOA_PUPDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOA_PUPDR        \ GPIOA_PUPDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOA_PUPDR        \ GPIOA_PUPDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOA_PUPDR        \ GPIOA_PUPDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOA_PUPDR        \ GPIOA_PUPDR0	Bit Offset:0	Bit Width:2
        
        GPIOA $10 + constant GPIOA_IDR	\ read-only		\  : RESET_GPIOA_IDR $00000000 
        \ %x  15 lshift GPIOA_IDR        \ GPIOA_IDR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_IDR        \ GPIOA_IDR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_IDR        \ GPIOA_IDR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_IDR        \ GPIOA_IDR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_IDR        \ GPIOA_IDR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_IDR        \ GPIOA_IDR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_IDR        \ GPIOA_IDR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_IDR        \ GPIOA_IDR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_IDR        \ GPIOA_IDR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_IDR        \ GPIOA_IDR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_IDR        \ GPIOA_IDR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_IDR        \ GPIOA_IDR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_IDR        \ GPIOA_IDR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_IDR        \ GPIOA_IDR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_IDR        \ GPIOA_IDR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_IDR        \ GPIOA_IDR0	Bit Offset:0	Bit Width:1
        
        GPIOA $14 + constant GPIOA_ODR	\ read-write		\  : RESET_GPIOA_ODR $00000000 
        \ %x  15 lshift GPIOA_ODR        \ GPIOA_ODR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_ODR        \ GPIOA_ODR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_ODR        \ GPIOA_ODR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_ODR        \ GPIOA_ODR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_ODR        \ GPIOA_ODR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_ODR        \ GPIOA_ODR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_ODR        \ GPIOA_ODR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_ODR        \ GPIOA_ODR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_ODR        \ GPIOA_ODR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_ODR        \ GPIOA_ODR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_ODR        \ GPIOA_ODR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_ODR        \ GPIOA_ODR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_ODR        \ GPIOA_ODR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_ODR        \ GPIOA_ODR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_ODR        \ GPIOA_ODR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_ODR        \ GPIOA_ODR0	Bit Offset:0	Bit Width:1
        
        GPIOA $18 + constant GPIOA_BSRR	\ write-only		\  : RESET_GPIOA_BSRR $00000000 
        \ %x  31 lshift GPIOA_BSRR        \ GPIOA_BR15	Bit Offset:31	Bit Width:1
        \ %x  30 lshift GPIOA_BSRR        \ GPIOA_BR14	Bit Offset:30	Bit Width:1
        \ %x  29 lshift GPIOA_BSRR        \ GPIOA_BR13	Bit Offset:29	Bit Width:1
        \ %x  28 lshift GPIOA_BSRR        \ GPIOA_BR12	Bit Offset:28	Bit Width:1
        \ %x  27 lshift GPIOA_BSRR        \ GPIOA_BR11	Bit Offset:27	Bit Width:1
        \ %x  26 lshift GPIOA_BSRR        \ GPIOA_BR10	Bit Offset:26	Bit Width:1
        \ %x  25 lshift GPIOA_BSRR        \ GPIOA_BR9	Bit Offset:25	Bit Width:1
        \ %x  24 lshift GPIOA_BSRR        \ GPIOA_BR8	Bit Offset:24	Bit Width:1
        \ %x  23 lshift GPIOA_BSRR        \ GPIOA_BR7	Bit Offset:23	Bit Width:1
        \ %x  22 lshift GPIOA_BSRR        \ GPIOA_BR6	Bit Offset:22	Bit Width:1
        \ %x  21 lshift GPIOA_BSRR        \ GPIOA_BR5	Bit Offset:21	Bit Width:1
        \ %x  20 lshift GPIOA_BSRR        \ GPIOA_BR4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift GPIOA_BSRR        \ GPIOA_BR3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift GPIOA_BSRR        \ GPIOA_BR2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift GPIOA_BSRR        \ GPIOA_BR1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift GPIOA_BSRR        \ GPIOA_BR0	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOA_BSRR        \ GPIOA_BS15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_BSRR        \ GPIOA_BS14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_BSRR        \ GPIOA_BS13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_BSRR        \ GPIOA_BS12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_BSRR        \ GPIOA_BS11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_BSRR        \ GPIOA_BS10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_BSRR        \ GPIOA_BS9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_BSRR        \ GPIOA_BS8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_BSRR        \ GPIOA_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_BSRR        \ GPIOA_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_BSRR        \ GPIOA_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_BSRR        \ GPIOA_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_BSRR        \ GPIOA_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_BSRR        \ GPIOA_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_BSRR        \ GPIOA_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_BSRR        \ GPIOA_BS0	Bit Offset:0	Bit Width:1
        
        GPIOA $1C + constant GPIOA_LCKR	\ read-write		\  : RESET_GPIOA_LCKR $00000000 
        \ %x  16 lshift GPIOA_LCKR        \ GPIOA_LCKK	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOA_LCKR        \ GPIOA_LCK15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_LCKR        \ GPIOA_LCK14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_LCKR        \ GPIOA_LCK13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_LCKR        \ GPIOA_LCK12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_LCKR        \ GPIOA_LCK11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_LCKR        \ GPIOA_LCK10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_LCKR        \ GPIOA_LCK9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_LCKR        \ GPIOA_LCK8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_LCKR        \ GPIOA_LCK7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_LCKR        \ GPIOA_LCK6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_LCKR        \ GPIOA_LCK5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_LCKR        \ GPIOA_LCK4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_LCKR        \ GPIOA_LCK3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_LCKR        \ GPIOA_LCK2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_LCKR        \ GPIOA_LCK1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_LCKR        \ GPIOA_LCK0	Bit Offset:0	Bit Width:1
        
        GPIOA $20 + constant GPIOA_AFRL	\ read-write		\  : RESET_GPIOA_AFRL $00000000 
        \ %xxxx  28 lshift GPIOA_AFRL        \ GPIOA_AFRL7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOA_AFRL        \ GPIOA_AFRL6	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOA_AFRL        \ GPIOA_AFRL5	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOA_AFRL        \ GPIOA_AFRL4	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOA_AFRL        \ GPIOA_AFRL3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOA_AFRL        \ GPIOA_AFRL2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOA_AFRL        \ GPIOA_AFRL1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOA_AFRL        \ GPIOA_AFRL0	Bit Offset:0	Bit Width:4
        
        GPIOA $24 + constant GPIOA_AFRH	\ read-write		\  : RESET_GPIOA_AFRH $00000000 
        \ %xxxx  28 lshift GPIOA_AFRH        \ GPIOA_AFRH15	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOA_AFRH        \ GPIOA_AFRH14	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOA_AFRH        \ GPIOA_AFRH13	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOA_AFRH        \ GPIOA_AFRH12	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOA_AFRH        \ GPIOA_AFRH11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOA_AFRH        \ GPIOA_AFRH10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOA_AFRH        \ GPIOA_AFRH9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOA_AFRH        \ GPIOA_AFRH8	Bit Offset:0	Bit Width:4
        
         
	
     $40020400 constant GPIOB  
	 GPIOB $0 + constant GPIOB_MODER	\ read-write		\  : RESET_GPIOB_MODER $00000280 
        \ %xx  30 lshift GPIOB_MODER        \ GPIOB_MODER15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_MODER        \ GPIOB_MODER14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_MODER        \ GPIOB_MODER13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_MODER        \ GPIOB_MODER12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_MODER        \ GPIOB_MODER11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_MODER        \ GPIOB_MODER10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_MODER        \ GPIOB_MODER9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_MODER        \ GPIOB_MODER8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_MODER        \ GPIOB_MODER7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_MODER        \ GPIOB_MODER6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_MODER        \ GPIOB_MODER5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_MODER        \ GPIOB_MODER4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_MODER        \ GPIOB_MODER3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_MODER        \ GPIOB_MODER2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_MODER        \ GPIOB_MODER1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_MODER        \ GPIOB_MODER0	Bit Offset:0	Bit Width:2
        
        GPIOB $4 + constant GPIOB_OTYPER	\ read-write		\  : RESET_GPIOB_OTYPER $00000000 
        \ %x  15 lshift GPIOB_OTYPER        \ GPIOB_OT15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_OTYPER        \ GPIOB_OT14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_OTYPER        \ GPIOB_OT13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_OTYPER        \ GPIOB_OT12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_OTYPER        \ GPIOB_OT11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_OTYPER        \ GPIOB_OT10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_OTYPER        \ GPIOB_OT9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_OTYPER        \ GPIOB_OT8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_OTYPER        \ GPIOB_OT7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_OTYPER        \ GPIOB_OT6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_OTYPER        \ GPIOB_OT5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_OTYPER        \ GPIOB_OT4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_OTYPER        \ GPIOB_OT3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_OTYPER        \ GPIOB_OT2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_OTYPER        \ GPIOB_OT1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_OTYPER        \ GPIOB_OT0	Bit Offset:0	Bit Width:1
        
        GPIOB $8 + constant GPIOB_OSPEEDER	\ read-write		\  : RESET_GPIOB_OSPEEDER $000000C0 
        \ %xx  30 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_OSPEEDER        \ GPIOB_OSPEEDR0	Bit Offset:0	Bit Width:2
        
        GPIOB $C + constant GPIOB_PUPDR	\ read-write		\  : RESET_GPIOB_PUPDR $00000100 
        \ %xx  30 lshift GPIOB_PUPDR        \ GPIOB_PUPDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_PUPDR        \ GPIOB_PUPDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_PUPDR        \ GPIOB_PUPDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_PUPDR        \ GPIOB_PUPDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_PUPDR        \ GPIOB_PUPDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_PUPDR        \ GPIOB_PUPDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_PUPDR        \ GPIOB_PUPDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_PUPDR        \ GPIOB_PUPDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_PUPDR        \ GPIOB_PUPDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_PUPDR        \ GPIOB_PUPDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_PUPDR        \ GPIOB_PUPDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_PUPDR        \ GPIOB_PUPDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_PUPDR        \ GPIOB_PUPDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_PUPDR        \ GPIOB_PUPDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_PUPDR        \ GPIOB_PUPDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_PUPDR        \ GPIOB_PUPDR0	Bit Offset:0	Bit Width:2
        
        GPIOB $10 + constant GPIOB_IDR	\ read-only		\  : RESET_GPIOB_IDR $00000000 
        \ %x  15 lshift GPIOB_IDR        \ GPIOB_IDR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_IDR        \ GPIOB_IDR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_IDR        \ GPIOB_IDR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_IDR        \ GPIOB_IDR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_IDR        \ GPIOB_IDR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_IDR        \ GPIOB_IDR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_IDR        \ GPIOB_IDR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_IDR        \ GPIOB_IDR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_IDR        \ GPIOB_IDR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_IDR        \ GPIOB_IDR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_IDR        \ GPIOB_IDR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_IDR        \ GPIOB_IDR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_IDR        \ GPIOB_IDR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_IDR        \ GPIOB_IDR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_IDR        \ GPIOB_IDR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_IDR        \ GPIOB_IDR0	Bit Offset:0	Bit Width:1
        
        GPIOB $14 + constant GPIOB_ODR	\ read-write		\  : RESET_GPIOB_ODR $00000000 
        \ %x  15 lshift GPIOB_ODR        \ GPIOB_ODR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_ODR        \ GPIOB_ODR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_ODR        \ GPIOB_ODR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_ODR        \ GPIOB_ODR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_ODR        \ GPIOB_ODR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_ODR        \ GPIOB_ODR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_ODR        \ GPIOB_ODR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_ODR        \ GPIOB_ODR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_ODR        \ GPIOB_ODR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_ODR        \ GPIOB_ODR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_ODR        \ GPIOB_ODR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_ODR        \ GPIOB_ODR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_ODR        \ GPIOB_ODR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_ODR        \ GPIOB_ODR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_ODR        \ GPIOB_ODR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_ODR        \ GPIOB_ODR0	Bit Offset:0	Bit Width:1
        
        GPIOB $18 + constant GPIOB_BSRR	\ write-only		\  : RESET_GPIOB_BSRR $00000000 
        \ %x  31 lshift GPIOB_BSRR        \ GPIOB_BR15	Bit Offset:31	Bit Width:1
        \ %x  30 lshift GPIOB_BSRR        \ GPIOB_BR14	Bit Offset:30	Bit Width:1
        \ %x  29 lshift GPIOB_BSRR        \ GPIOB_BR13	Bit Offset:29	Bit Width:1
        \ %x  28 lshift GPIOB_BSRR        \ GPIOB_BR12	Bit Offset:28	Bit Width:1
        \ %x  27 lshift GPIOB_BSRR        \ GPIOB_BR11	Bit Offset:27	Bit Width:1
        \ %x  26 lshift GPIOB_BSRR        \ GPIOB_BR10	Bit Offset:26	Bit Width:1
        \ %x  25 lshift GPIOB_BSRR        \ GPIOB_BR9	Bit Offset:25	Bit Width:1
        \ %x  24 lshift GPIOB_BSRR        \ GPIOB_BR8	Bit Offset:24	Bit Width:1
        \ %x  23 lshift GPIOB_BSRR        \ GPIOB_BR7	Bit Offset:23	Bit Width:1
        \ %x  22 lshift GPIOB_BSRR        \ GPIOB_BR6	Bit Offset:22	Bit Width:1
        \ %x  21 lshift GPIOB_BSRR        \ GPIOB_BR5	Bit Offset:21	Bit Width:1
        \ %x  20 lshift GPIOB_BSRR        \ GPIOB_BR4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift GPIOB_BSRR        \ GPIOB_BR3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift GPIOB_BSRR        \ GPIOB_BR2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift GPIOB_BSRR        \ GPIOB_BR1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift GPIOB_BSRR        \ GPIOB_BR0	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOB_BSRR        \ GPIOB_BS15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_BSRR        \ GPIOB_BS14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_BSRR        \ GPIOB_BS13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_BSRR        \ GPIOB_BS12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_BSRR        \ GPIOB_BS11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_BSRR        \ GPIOB_BS10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_BSRR        \ GPIOB_BS9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_BSRR        \ GPIOB_BS8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_BSRR        \ GPIOB_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_BSRR        \ GPIOB_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_BSRR        \ GPIOB_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_BSRR        \ GPIOB_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_BSRR        \ GPIOB_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_BSRR        \ GPIOB_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_BSRR        \ GPIOB_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_BSRR        \ GPIOB_BS0	Bit Offset:0	Bit Width:1
        
        GPIOB $1C + constant GPIOB_LCKR	\ read-write		\  : RESET_GPIOB_LCKR $00000000 
        \ %x  16 lshift GPIOB_LCKR        \ GPIOB_LCKK	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOB_LCKR        \ GPIOB_LCK15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_LCKR        \ GPIOB_LCK14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_LCKR        \ GPIOB_LCK13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_LCKR        \ GPIOB_LCK12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_LCKR        \ GPIOB_LCK11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_LCKR        \ GPIOB_LCK10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_LCKR        \ GPIOB_LCK9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_LCKR        \ GPIOB_LCK8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_LCKR        \ GPIOB_LCK7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_LCKR        \ GPIOB_LCK6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_LCKR        \ GPIOB_LCK5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_LCKR        \ GPIOB_LCK4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_LCKR        \ GPIOB_LCK3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_LCKR        \ GPIOB_LCK2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_LCKR        \ GPIOB_LCK1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_LCKR        \ GPIOB_LCK0	Bit Offset:0	Bit Width:1
        
        GPIOB $20 + constant GPIOB_AFRL	\ read-write		\  : RESET_GPIOB_AFRL $00000000 
        \ %xxxx  28 lshift GPIOB_AFRL        \ GPIOB_AFRL7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOB_AFRL        \ GPIOB_AFRL6	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOB_AFRL        \ GPIOB_AFRL5	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOB_AFRL        \ GPIOB_AFRL4	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOB_AFRL        \ GPIOB_AFRL3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOB_AFRL        \ GPIOB_AFRL2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOB_AFRL        \ GPIOB_AFRL1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOB_AFRL        \ GPIOB_AFRL0	Bit Offset:0	Bit Width:4
        
        GPIOB $24 + constant GPIOB_AFRH	\ read-write		\  : RESET_GPIOB_AFRH $00000000 
        \ %xxxx  28 lshift GPIOB_AFRH        \ GPIOB_AFRH15	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOB_AFRH        \ GPIOB_AFRH14	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOB_AFRH        \ GPIOB_AFRH13	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOB_AFRH        \ GPIOB_AFRH12	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOB_AFRH        \ GPIOB_AFRH11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOB_AFRH        \ GPIOB_AFRH10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOB_AFRH        \ GPIOB_AFRH9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOB_AFRH        \ GPIOB_AFRH8	Bit Offset:0	Bit Width:4
        
         
	
     $40020800 constant GPIOC  
	 GPIOC $0 + constant GPIOC_MODER	\ read-write		\  : RESET_GPIOC_MODER $00000000 
        \ %xx  30 lshift GPIOC_MODER        \ GPIOC_MODER15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOC_MODER        \ GPIOC_MODER14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOC_MODER        \ GPIOC_MODER13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOC_MODER        \ GPIOC_MODER12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOC_MODER        \ GPIOC_MODER11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOC_MODER        \ GPIOC_MODER10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOC_MODER        \ GPIOC_MODER9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOC_MODER        \ GPIOC_MODER8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOC_MODER        \ GPIOC_MODER7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOC_MODER        \ GPIOC_MODER6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOC_MODER        \ GPIOC_MODER5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOC_MODER        \ GPIOC_MODER4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOC_MODER        \ GPIOC_MODER3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOC_MODER        \ GPIOC_MODER2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOC_MODER        \ GPIOC_MODER1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOC_MODER        \ GPIOC_MODER0	Bit Offset:0	Bit Width:2
        
        GPIOC $4 + constant GPIOC_OTYPER	\ read-write		\  : RESET_GPIOC_OTYPER $00000000 
        \ %x  15 lshift GPIOC_OTYPER        \ GPIOC_OT15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOC_OTYPER        \ GPIOC_OT14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOC_OTYPER        \ GPIOC_OT13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOC_OTYPER        \ GPIOC_OT12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOC_OTYPER        \ GPIOC_OT11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOC_OTYPER        \ GPIOC_OT10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOC_OTYPER        \ GPIOC_OT9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOC_OTYPER        \ GPIOC_OT8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOC_OTYPER        \ GPIOC_OT7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_OTYPER        \ GPIOC_OT6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_OTYPER        \ GPIOC_OT5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_OTYPER        \ GPIOC_OT4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_OTYPER        \ GPIOC_OT3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_OTYPER        \ GPIOC_OT2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_OTYPER        \ GPIOC_OT1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_OTYPER        \ GPIOC_OT0	Bit Offset:0	Bit Width:1
        
        GPIOC $8 + constant GPIOC_OSPEEDER	\ read-write		\  : RESET_GPIOC_OSPEEDER $00000000 
        \ %xx  30 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOC_OSPEEDER        \ GPIOC_OSPEEDR0	Bit Offset:0	Bit Width:2
        
        GPIOC $C + constant GPIOC_PUPDR	\ read-write		\  : RESET_GPIOC_PUPDR $00000000 
        \ %xx  30 lshift GPIOC_PUPDR        \ GPIOC_PUPDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOC_PUPDR        \ GPIOC_PUPDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOC_PUPDR        \ GPIOC_PUPDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOC_PUPDR        \ GPIOC_PUPDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOC_PUPDR        \ GPIOC_PUPDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOC_PUPDR        \ GPIOC_PUPDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOC_PUPDR        \ GPIOC_PUPDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOC_PUPDR        \ GPIOC_PUPDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOC_PUPDR        \ GPIOC_PUPDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOC_PUPDR        \ GPIOC_PUPDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOC_PUPDR        \ GPIOC_PUPDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOC_PUPDR        \ GPIOC_PUPDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOC_PUPDR        \ GPIOC_PUPDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOC_PUPDR        \ GPIOC_PUPDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOC_PUPDR        \ GPIOC_PUPDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOC_PUPDR        \ GPIOC_PUPDR0	Bit Offset:0	Bit Width:2
        
        GPIOC $10 + constant GPIOC_IDR	\ read-only		\  : RESET_GPIOC_IDR $00000000 
        \ %x  15 lshift GPIOC_IDR        \ GPIOC_IDR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOC_IDR        \ GPIOC_IDR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOC_IDR        \ GPIOC_IDR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOC_IDR        \ GPIOC_IDR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOC_IDR        \ GPIOC_IDR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOC_IDR        \ GPIOC_IDR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOC_IDR        \ GPIOC_IDR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOC_IDR        \ GPIOC_IDR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOC_IDR        \ GPIOC_IDR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_IDR        \ GPIOC_IDR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_IDR        \ GPIOC_IDR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_IDR        \ GPIOC_IDR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_IDR        \ GPIOC_IDR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_IDR        \ GPIOC_IDR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_IDR        \ GPIOC_IDR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_IDR        \ GPIOC_IDR0	Bit Offset:0	Bit Width:1
        
        GPIOC $14 + constant GPIOC_ODR	\ read-write		\  : RESET_GPIOC_ODR $00000000 
        \ %x  15 lshift GPIOC_ODR        \ GPIOC_ODR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOC_ODR        \ GPIOC_ODR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOC_ODR        \ GPIOC_ODR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOC_ODR        \ GPIOC_ODR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOC_ODR        \ GPIOC_ODR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOC_ODR        \ GPIOC_ODR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOC_ODR        \ GPIOC_ODR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOC_ODR        \ GPIOC_ODR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOC_ODR        \ GPIOC_ODR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_ODR        \ GPIOC_ODR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_ODR        \ GPIOC_ODR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_ODR        \ GPIOC_ODR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_ODR        \ GPIOC_ODR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_ODR        \ GPIOC_ODR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_ODR        \ GPIOC_ODR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_ODR        \ GPIOC_ODR0	Bit Offset:0	Bit Width:1
        
        GPIOC $18 + constant GPIOC_BSRR	\ write-only		\  : RESET_GPIOC_BSRR $00000000 
        \ %x  31 lshift GPIOC_BSRR        \ GPIOC_BR15	Bit Offset:31	Bit Width:1
        \ %x  30 lshift GPIOC_BSRR        \ GPIOC_BR14	Bit Offset:30	Bit Width:1
        \ %x  29 lshift GPIOC_BSRR        \ GPIOC_BR13	Bit Offset:29	Bit Width:1
        \ %x  28 lshift GPIOC_BSRR        \ GPIOC_BR12	Bit Offset:28	Bit Width:1
        \ %x  27 lshift GPIOC_BSRR        \ GPIOC_BR11	Bit Offset:27	Bit Width:1
        \ %x  26 lshift GPIOC_BSRR        \ GPIOC_BR10	Bit Offset:26	Bit Width:1
        \ %x  25 lshift GPIOC_BSRR        \ GPIOC_BR9	Bit Offset:25	Bit Width:1
        \ %x  24 lshift GPIOC_BSRR        \ GPIOC_BR8	Bit Offset:24	Bit Width:1
        \ %x  23 lshift GPIOC_BSRR        \ GPIOC_BR7	Bit Offset:23	Bit Width:1
        \ %x  22 lshift GPIOC_BSRR        \ GPIOC_BR6	Bit Offset:22	Bit Width:1
        \ %x  21 lshift GPIOC_BSRR        \ GPIOC_BR5	Bit Offset:21	Bit Width:1
        \ %x  20 lshift GPIOC_BSRR        \ GPIOC_BR4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift GPIOC_BSRR        \ GPIOC_BR3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift GPIOC_BSRR        \ GPIOC_BR2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift GPIOC_BSRR        \ GPIOC_BR1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift GPIOC_BSRR        \ GPIOC_BR0	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOC_BSRR        \ GPIOC_BS15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOC_BSRR        \ GPIOC_BS14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOC_BSRR        \ GPIOC_BS13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOC_BSRR        \ GPIOC_BS12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOC_BSRR        \ GPIOC_BS11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOC_BSRR        \ GPIOC_BS10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOC_BSRR        \ GPIOC_BS9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOC_BSRR        \ GPIOC_BS8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOC_BSRR        \ GPIOC_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_BSRR        \ GPIOC_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_BSRR        \ GPIOC_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_BSRR        \ GPIOC_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_BSRR        \ GPIOC_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_BSRR        \ GPIOC_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_BSRR        \ GPIOC_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_BSRR        \ GPIOC_BS0	Bit Offset:0	Bit Width:1
        
        GPIOC $1C + constant GPIOC_LCKR	\ read-write		\  : RESET_GPIOC_LCKR $00000000 
        \ %x  16 lshift GPIOC_LCKR        \ GPIOC_LCKK	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOC_LCKR        \ GPIOC_LCK15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOC_LCKR        \ GPIOC_LCK14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOC_LCKR        \ GPIOC_LCK13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOC_LCKR        \ GPIOC_LCK12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOC_LCKR        \ GPIOC_LCK11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOC_LCKR        \ GPIOC_LCK10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOC_LCKR        \ GPIOC_LCK9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOC_LCKR        \ GPIOC_LCK8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOC_LCKR        \ GPIOC_LCK7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOC_LCKR        \ GPIOC_LCK6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOC_LCKR        \ GPIOC_LCK5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOC_LCKR        \ GPIOC_LCK4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOC_LCKR        \ GPIOC_LCK3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOC_LCKR        \ GPIOC_LCK2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOC_LCKR        \ GPIOC_LCK1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOC_LCKR        \ GPIOC_LCK0	Bit Offset:0	Bit Width:1
        
        GPIOC $20 + constant GPIOC_AFRL	\ read-write		\  : RESET_GPIOC_AFRL $00000000 
        \ %xxxx  28 lshift GPIOC_AFRL        \ GPIOC_AFRL7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOC_AFRL        \ GPIOC_AFRL6	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOC_AFRL        \ GPIOC_AFRL5	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOC_AFRL        \ GPIOC_AFRL4	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOC_AFRL        \ GPIOC_AFRL3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOC_AFRL        \ GPIOC_AFRL2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOC_AFRL        \ GPIOC_AFRL1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOC_AFRL        \ GPIOC_AFRL0	Bit Offset:0	Bit Width:4
        
        GPIOC $24 + constant GPIOC_AFRH	\ read-write		\  : RESET_GPIOC_AFRH $00000000 
        \ %xxxx  28 lshift GPIOC_AFRH        \ GPIOC_AFRH15	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOC_AFRH        \ GPIOC_AFRH14	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOC_AFRH        \ GPIOC_AFRH13	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOC_AFRH        \ GPIOC_AFRH12	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOC_AFRH        \ GPIOC_AFRH11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOC_AFRH        \ GPIOC_AFRH10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOC_AFRH        \ GPIOC_AFRH9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOC_AFRH        \ GPIOC_AFRH8	Bit Offset:0	Bit Width:4
        
         
	
     $40020C00 constant GPIOD  
	  
	
     $40021000 constant GPIOE  
	  
	
     $40021800 constant GPIOF  
	  
	
     $40021C00 constant GPIOG  
	  
	
     $40021400 constant GPIOH  
	  
	
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
        \ %xx  8 lshift I2C1_OAR1        \ I2C1_ADD_8_9	Bit Offset:8	Bit Width:2
        \ %xxxxxxx  1 lshift I2C1_OAR1        \ I2C1_ADD_1_7	Bit Offset:1	Bit Width:7
        \ %x  0 lshift I2C1_OAR1        \ I2C1_ADD_0	Bit Offset:0	Bit Width:1
        
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
	  
	
     $40003000 constant IWDG  
	 IWDG $0 + constant IWDG_KR	\ write-only		\  : RESET_IWDG_KR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift IWDG_KR        \ IWDG_KEY	Bit Offset:0	Bit Width:16
        
        IWDG $4 + constant IWDG_PR	\ read-write		\  : RESET_IWDG_PR $00000000 
        \ %xxx  0 lshift IWDG_PR        \ IWDG_PR	Bit Offset:0	Bit Width:3
        
        IWDG $8 + constant IWDG_RLR	\ read-write		\  : RESET_IWDG_RLR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift IWDG_RLR        \ IWDG_RL	Bit Offset:0	Bit Width:12
        
        IWDG $C + constant IWDG_SR	\ read-only		\  : RESET_IWDG_SR $00000000 
        \ %x  1 lshift IWDG_SR        \ IWDG_RVU	Bit Offset:1	Bit Width:1
        \ %x  0 lshift IWDG_SR        \ IWDG_PVU	Bit Offset:0	Bit Width:1
        
         
	
     $40002400 constant LCD  
	 LCD $0 + constant LCD_CR	\ read-write		\  : RESET_LCD_CR $00000000 
        \ %x  7 lshift LCD_CR        \ LCD_MUX_SEG	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift LCD_CR        \ LCD_BIAS	Bit Offset:5	Bit Width:2
        \ %xxx  2 lshift LCD_CR        \ LCD_DUTY	Bit Offset:2	Bit Width:3
        \ %x  1 lshift LCD_CR        \ LCD_VSEL	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_CR        \ LCD_LCDEN	Bit Offset:0	Bit Width:1
        
        LCD $4 + constant LCD_FCR	\ read-write		\  : RESET_LCD_FCR $00000000 
        \ %xxxx  22 lshift LCD_FCR        \ LCD_PS	Bit Offset:22	Bit Width:4
        \ %xxxx  18 lshift LCD_FCR        \ LCD_DIV	Bit Offset:18	Bit Width:4
        \ %xx  16 lshift LCD_FCR        \ LCD_BLINK	Bit Offset:16	Bit Width:2
        \ %xxx  13 lshift LCD_FCR        \ LCD_BLINKF	Bit Offset:13	Bit Width:3
        \ %xxx  10 lshift LCD_FCR        \ LCD_CC	Bit Offset:10	Bit Width:3
        \ %xxx  7 lshift LCD_FCR        \ LCD_DEAD	Bit Offset:7	Bit Width:3
        \ %xxx  4 lshift LCD_FCR        \ LCD_PON	Bit Offset:4	Bit Width:3
        \ %x  3 lshift LCD_FCR        \ LCD_UDDIE	Bit Offset:3	Bit Width:1
        \ %x  1 lshift LCD_FCR        \ LCD_SOFIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_FCR        \ LCD_HD	Bit Offset:0	Bit Width:1
        
        LCD $8 + constant LCD_SR	\ 		\  : RESET_LCD_SR $00000020 
        \ %x  5 lshift LCD_SR        \ LCD_FCRSF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_SR        \ LCD_RDY	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_SR        \ LCD_UDD	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_SR        \ LCD_UDR	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_SR        \ LCD_SOF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_SR        \ LCD_ENS	Bit Offset:0	Bit Width:1
        
        LCD $C + constant LCD_CLR	\ write-only		\  : RESET_LCD_CLR $00000000 
        \ %x  3 lshift LCD_CLR        \ LCD_UDDC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift LCD_CLR        \ LCD_SOFC	Bit Offset:1	Bit Width:1
        
        LCD $14 + constant LCD_RAM_COM0	\ read-write		\  : RESET_LCD_RAM_COM0 $00000000 
        \ %x  31 lshift LCD_RAM_COM0        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM0        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM0        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM0        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM0        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM0        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM0        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM0        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM0        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM0        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM0        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM0        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM0        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM0        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM0        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM0        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM0        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM0        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM0        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM0        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM0        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM0        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM0        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM0        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM0        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM0        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM0        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM0        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM0        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM0        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM0        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM0        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $1C + constant LCD_RAM_COM1	\ read-write		\  : RESET_LCD_RAM_COM1 $00000000 
        \ %x  31 lshift LCD_RAM_COM1        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM1        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM1        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM1        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM1        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM1        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM1        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM1        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM1        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM1        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM1        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM1        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM1        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM1        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM1        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM1        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM1        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM1        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM1        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM1        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM1        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM1        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM1        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM1        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM1        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM1        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM1        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM1        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM1        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM1        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM1        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM1        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $24 + constant LCD_RAM_COM2	\ read-write		\  : RESET_LCD_RAM_COM2 $00000000 
        \ %x  31 lshift LCD_RAM_COM2        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM2        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM2        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM2        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM2        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM2        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM2        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM2        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM2        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM2        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM2        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM2        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM2        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM2        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM2        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM2        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM2        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM2        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM2        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM2        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM2        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM2        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM2        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM2        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM2        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM2        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM2        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM2        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM2        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM2        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM2        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM2        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $2C + constant LCD_RAM_COM3	\ read-write		\  : RESET_LCD_RAM_COM3 $00000000 
        \ %x  31 lshift LCD_RAM_COM3        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM3        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM3        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM3        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM3        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM3        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM3        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM3        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM3        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM3        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM3        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM3        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM3        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM3        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM3        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM3        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM3        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM3        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM3        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM3        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM3        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM3        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM3        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM3        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM3        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM3        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM3        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM3        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM3        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM3        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM3        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM3        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $34 + constant LCD_RAM_COM4	\ read-write		\  : RESET_LCD_RAM_COM4 $00000000 
        \ %x  31 lshift LCD_RAM_COM4        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM4        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM4        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM4        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM4        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM4        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM4        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM4        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM4        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM4        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM4        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM4        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM4        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM4        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM4        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM4        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM4        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM4        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM4        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM4        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM4        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM4        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM4        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM4        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM4        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM4        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM4        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM4        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM4        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM4        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM4        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM4        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $3C + constant LCD_RAM_COM5	\ read-write		\  : RESET_LCD_RAM_COM5 $00000000 
        \ %x  31 lshift LCD_RAM_COM5        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM5        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM5        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM5        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM5        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM5        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM5        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM5        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM5        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM5        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM5        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM5        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM5        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM5        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM5        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM5        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM5        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM5        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM5        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM5        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM5        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM5        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM5        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM5        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM5        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM5        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM5        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM5        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM5        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM5        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM5        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM5        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $44 + constant LCD_RAM_COM6	\ read-write		\  : RESET_LCD_RAM_COM6 $00000000 
        \ %x  31 lshift LCD_RAM_COM6        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM6        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM6        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM6        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM6        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM6        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM6        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM6        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM6        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM6        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM6        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM6        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM6        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM6        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM6        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM6        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM6        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM6        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM6        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM6        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM6        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM6        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM6        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM6        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM6        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM6        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM6        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM6        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM6        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM6        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM6        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM6        \ LCD_S00	Bit Offset:0	Bit Width:1
        
        LCD $4C + constant LCD_RAM_COM7	\ read-write		\  : RESET_LCD_RAM_COM7 $00000000 
        \ %x  31 lshift LCD_RAM_COM7        \ LCD_S31	Bit Offset:31	Bit Width:1
        \ %x  30 lshift LCD_RAM_COM7        \ LCD_S30	Bit Offset:30	Bit Width:1
        \ %x  29 lshift LCD_RAM_COM7        \ LCD_S29	Bit Offset:29	Bit Width:1
        \ %x  28 lshift LCD_RAM_COM7        \ LCD_S28	Bit Offset:28	Bit Width:1
        \ %x  27 lshift LCD_RAM_COM7        \ LCD_S27	Bit Offset:27	Bit Width:1
        \ %x  26 lshift LCD_RAM_COM7        \ LCD_S26	Bit Offset:26	Bit Width:1
        \ %x  25 lshift LCD_RAM_COM7        \ LCD_S25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LCD_RAM_COM7        \ LCD_S24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LCD_RAM_COM7        \ LCD_S23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LCD_RAM_COM7        \ LCD_S22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LCD_RAM_COM7        \ LCD_S21	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LCD_RAM_COM7        \ LCD_S20	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LCD_RAM_COM7        \ LCD_S19	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LCD_RAM_COM7        \ LCD_S18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LCD_RAM_COM7        \ LCD_S17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LCD_RAM_COM7        \ LCD_S16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LCD_RAM_COM7        \ LCD_S15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LCD_RAM_COM7        \ LCD_S14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LCD_RAM_COM7        \ LCD_S13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LCD_RAM_COM7        \ LCD_S12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LCD_RAM_COM7        \ LCD_S11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LCD_RAM_COM7        \ LCD_S10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LCD_RAM_COM7        \ LCD_S09	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LCD_RAM_COM7        \ LCD_S08	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LCD_RAM_COM7        \ LCD_S07	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LCD_RAM_COM7        \ LCD_S06	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LCD_RAM_COM7        \ LCD_S05	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LCD_RAM_COM7        \ LCD_S04	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LCD_RAM_COM7        \ LCD_S03	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LCD_RAM_COM7        \ LCD_S02	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LCD_RAM_COM7        \ LCD_S01	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LCD_RAM_COM7        \ LCD_S00	Bit Offset:0	Bit Width:1
        
         
	
     $40007C5C constant OPAMP  
	 OPAMP $0 + constant OPAMP_CSR	\ read-write		\  : RESET_OPAMP_CSR $00010101 
        \ %x  31 lshift OPAMP_CSR        \ OPAMP_OPA3CALOUT	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OPAMP_CSR        \ OPAMP_OPA2CALOUT	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OPAMP_CSR        \ OPAMP_OPA1CALOUT	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OPAMP_CSR        \ OPAMP_AOP_RANGE	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OPAMP_CSR        \ OPAMP_S7SEL2	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OPAMP_CSR        \ OPAMP_ANAWSEL3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift OPAMP_CSR        \ OPAMP_ANAWSEL2	Bit Offset:25	Bit Width:1
        \ %x  24 lshift OPAMP_CSR        \ OPAMP_ANAWSEL1	Bit Offset:24	Bit Width:1
        \ %x  23 lshift OPAMP_CSR        \ OPAMP_OPA3LPM	Bit Offset:23	Bit Width:1
        \ %x  22 lshift OPAMP_CSR        \ OPAMP_OPA3CAL_H	Bit Offset:22	Bit Width:1
        \ %x  21 lshift OPAMP_CSR        \ OPAMP_OPA3CAL_L	Bit Offset:21	Bit Width:1
        \ %x  20 lshift OPAMP_CSR        \ OPAMP_S6SEL3	Bit Offset:20	Bit Width:1
        \ %x  19 lshift OPAMP_CSR        \ OPAMP_S5SEL3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift OPAMP_CSR        \ OPAMP_S4SEL3	Bit Offset:18	Bit Width:1
        \ %x  17 lshift OPAMP_CSR        \ OPAMP_S3SEL3	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OPAMP_CSR        \ OPAMP_OPA3PD	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OPAMP_CSR        \ OPAMP_OPA2LPM	Bit Offset:15	Bit Width:1
        \ %x  14 lshift OPAMP_CSR        \ OPAMP_OPA2CAL_H	Bit Offset:14	Bit Width:1
        \ %x  13 lshift OPAMP_CSR        \ OPAMP_OPA2CAL_L	Bit Offset:13	Bit Width:1
        \ %x  12 lshift OPAMP_CSR        \ OPAMP_S6SEL2	Bit Offset:12	Bit Width:1
        \ %x  11 lshift OPAMP_CSR        \ OPAMP_S5SEL2	Bit Offset:11	Bit Width:1
        \ %x  10 lshift OPAMP_CSR        \ OPAMP_S4SEL2	Bit Offset:10	Bit Width:1
        \ %x  9 lshift OPAMP_CSR        \ OPAMP_S3SEL2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift OPAMP_CSR        \ OPAMP_OPA2PD	Bit Offset:8	Bit Width:1
        \ %x  7 lshift OPAMP_CSR        \ OPAMP_OPA1LPM	Bit Offset:7	Bit Width:1
        \ %x  6 lshift OPAMP_CSR        \ OPAMP_OPA1CAL_H	Bit Offset:6	Bit Width:1
        \ %x  5 lshift OPAMP_CSR        \ OPAMP_OPA1CAL_L	Bit Offset:5	Bit Width:1
        \ %x  4 lshift OPAMP_CSR        \ OPAMP_S6SEL1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OPAMP_CSR        \ OPAMP_S5SEL1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift OPAMP_CSR        \ OPAMP_S4SEL1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift OPAMP_CSR        \ OPAMP_S3SEL1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OPAMP_CSR        \ OPAMP_OPA1PD	Bit Offset:0	Bit Width:1
        
        OPAMP $4 + constant OPAMP_OTR	\ read-write		\  : RESET_OPAMP_OTR $00000000 
        \ %x  31 lshift OPAMP_OTR        \ OPAMP_OT_USER	Bit Offset:31	Bit Width:1
        \ % 20 lshift OPAMP_OTR        \ OPAMP_AO3_OPT_OFFSET_TRIM	Bit Offset:20	Bit Width:10
        \ % 10 lshift OPAMP_OTR        \ OPAMP_AO2_OPT_OFFSET_TRIM	Bit Offset:10	Bit Width:10
        \ % 0 lshift OPAMP_OTR        \ OPAMP_AO1_OPT_OFFSET_TRIM	Bit Offset:0	Bit Width:10
        
        OPAMP $8 + constant OPAMP_LPOTR	\ read-write		\  : RESET_OPAMP_LPOTR $00000000 
        \ % 20 lshift OPAMP_LPOTR        \ OPAMP_AO3_OPT_OFFSET_TRIM_LP	Bit Offset:20	Bit Width:10
        \ % 10 lshift OPAMP_LPOTR        \ OPAMP_AO2_OPT_OFFSET_TRIM_LP	Bit Offset:10	Bit Width:10
        \ % 0 lshift OPAMP_LPOTR        \ OPAMP_AO1_OPT_OFFSET_TRIM_LP	Bit Offset:0	Bit Width:10
        
         
	
     $40007000 constant PWR  
	 PWR $0 + constant PWR_CR	\ read-write		\  : RESET_PWR_CR $00001000 
        \ %x  14 lshift PWR_CR        \ PWR_LPRUN	Bit Offset:14	Bit Width:1
        \ %xx  11 lshift PWR_CR        \ PWR_VOS	Bit Offset:11	Bit Width:2
        \ %x  10 lshift PWR_CR        \ PWR_FWU	Bit Offset:10	Bit Width:1
        \ %x  9 lshift PWR_CR        \ PWR_ULP	Bit Offset:9	Bit Width:1
        \ %x  8 lshift PWR_CR        \ PWR_DBP	Bit Offset:8	Bit Width:1
        \ %xxx  5 lshift PWR_CR        \ PWR_PLS	Bit Offset:5	Bit Width:3
        \ %x  4 lshift PWR_CR        \ PWR_PVDE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift PWR_CR        \ PWR_CSBF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift PWR_CR        \ PWR_CWUF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift PWR_CR        \ PWR_PDDS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift PWR_CR        \ PWR_LPSDSR	Bit Offset:0	Bit Width:1
        
        PWR $4 + constant PWR_CSR	\ 		\  : RESET_PWR_CSR $00000008 
        \ %x  10 lshift PWR_CSR        \ PWR_EWUP3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift PWR_CSR        \ PWR_EWUP2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift PWR_CSR        \ PWR_EWUP1	Bit Offset:8	Bit Width:1
        \ %x  5 lshift PWR_CSR        \ PWR_REGLPF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift PWR_CSR        \ PWR_VOSF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift PWR_CSR        \ PWR_VREFINTRDYF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift PWR_CSR        \ PWR_PVDO	Bit Offset:2	Bit Width:1
        \ %x  1 lshift PWR_CSR        \ PWR_SBF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift PWR_CSR        \ PWR_WUF	Bit Offset:0	Bit Width:1
        
         
	
     $40023800 constant RCC  
	 RCC $0 + constant RCC_CR	\ 		\  : RESET_RCC_CR $00000300 
        \ %x  30 lshift RCC_CR        \ RCC_RTCPRE1	Bit Offset:30	Bit Width:1
        \ %x  29 lshift RCC_CR        \ RCC_RTCPRE0	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_CR        \ RCC_CSSON	Bit Offset:28	Bit Width:1
        \ %x  25 lshift RCC_CR        \ RCC_PLLRDY	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_CR        \ RCC_PLLON	Bit Offset:24	Bit Width:1
        \ %x  18 lshift RCC_CR        \ RCC_HSEBYP	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_CR        \ RCC_HSERDY	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RCC_CR        \ RCC_HSEON	Bit Offset:16	Bit Width:1
        \ %x  9 lshift RCC_CR        \ RCC_MSIRDY	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_CR        \ RCC_MSION	Bit Offset:8	Bit Width:1
        \ %x  1 lshift RCC_CR        \ RCC_HSIRDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CR        \ RCC_HSION	Bit Offset:0	Bit Width:1
        
        RCC $4 + constant RCC_ICSCR	\ 		\  : RESET_RCC_ICSCR $0000B000 
        \ %xxxxxxxx  24 lshift RCC_ICSCR        \ RCC_MSITRIM	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift RCC_ICSCR        \ RCC_MSICAL	Bit Offset:16	Bit Width:8
        \ %xxx  13 lshift RCC_ICSCR        \ RCC_MSIRANGE	Bit Offset:13	Bit Width:3
        \ %xxxxx  8 lshift RCC_ICSCR        \ RCC_HSITRIM	Bit Offset:8	Bit Width:5
        \ %xxxxxxxx  0 lshift RCC_ICSCR        \ RCC_HSICAL	Bit Offset:0	Bit Width:8
        
        RCC $8 + constant RCC_CFGR	\ 		\  : RESET_RCC_CFGR $00000000 
        \ %xxx  28 lshift RCC_CFGR        \ RCC_MCOPRE	Bit Offset:28	Bit Width:3
        \ %xxx  24 lshift RCC_CFGR        \ RCC_MCOSEL	Bit Offset:24	Bit Width:3
        \ %xx  22 lshift RCC_CFGR        \ RCC_PLLDIV	Bit Offset:22	Bit Width:2
        \ %xxxx  18 lshift RCC_CFGR        \ RCC_PLLMUL	Bit Offset:18	Bit Width:4
        \ %x  16 lshift RCC_CFGR        \ RCC_PLLSRC	Bit Offset:16	Bit Width:1
        \ %xxx  11 lshift RCC_CFGR        \ RCC_PPRE2	Bit Offset:11	Bit Width:3
        \ %xxx  8 lshift RCC_CFGR        \ RCC_PPRE1	Bit Offset:8	Bit Width:3
        \ %xxxx  4 lshift RCC_CFGR        \ RCC_HPRE	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift RCC_CFGR        \ RCC_SWS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift RCC_CFGR        \ RCC_SW	Bit Offset:0	Bit Width:2
        
        RCC $C + constant RCC_CIR	\ 		\  : RESET_RCC_CIR $00000000 
        \ %x  23 lshift RCC_CIR        \ RCC_CSSC	Bit Offset:23	Bit Width:1
        \ %x  21 lshift RCC_CIR        \ RCC_MSIRDYC	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RCC_CIR        \ RCC_PLLRDYC	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RCC_CIR        \ RCC_HSERDYC	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_CIR        \ RCC_HSIRDYC	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_CIR        \ RCC_LSERDYC	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RCC_CIR        \ RCC_LSIRDYC	Bit Offset:16	Bit Width:1
        \ %x  13 lshift RCC_CIR        \ RCC_MSIRDYIE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RCC_CIR        \ RCC_PLLRDYIE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_CIR        \ RCC_HSERDYIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RCC_CIR        \ RCC_HSIRDYIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RCC_CIR        \ RCC_LSERDYIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_CIR        \ RCC_LSIRDYIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_CIR        \ RCC_CSSF	Bit Offset:7	Bit Width:1
        \ %x  5 lshift RCC_CIR        \ RCC_MSIRDYF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_CIR        \ RCC_PLLRDYF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_CIR        \ RCC_HSERDYF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CIR        \ RCC_HSIRDYF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CIR        \ RCC_LSERDYF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CIR        \ RCC_LSIRDYF	Bit Offset:0	Bit Width:1
        
        RCC $10 + constant RCC_AHBRSTR	\ read-write		\  : RESET_RCC_AHBRSTR $00000000 
        \ %x  30 lshift RCC_AHBRSTR        \ RCC_FSMCRST	Bit Offset:30	Bit Width:1
        \ %x  25 lshift RCC_AHBRSTR        \ RCC_DMA2RST	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_AHBRSTR        \ RCC_DMA1RST	Bit Offset:24	Bit Width:1
        \ %x  15 lshift RCC_AHBRSTR        \ RCC_FLITFRST	Bit Offset:15	Bit Width:1
        \ %x  12 lshift RCC_AHBRSTR        \ RCC_CRCRST	Bit Offset:12	Bit Width:1
        \ %x  7 lshift RCC_AHBRSTR        \ RCC_GPIOGRST	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHBRSTR        \ RCC_GPIOFRST	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_AHBRSTR        \ RCC_GPIOHRST	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_AHBRSTR        \ RCC_GPIOERST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_AHBRSTR        \ RCC_GPIODRST	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_AHBRSTR        \ RCC_GPIOCRST	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_AHBRSTR        \ RCC_GPIOBRST	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_AHBRSTR        \ RCC_GPIOARST	Bit Offset:0	Bit Width:1
        
        RCC $14 + constant RCC_APB2RSTR	\ read-write		\  : RESET_RCC_APB2RSTR $00000000 
        \ %x  14 lshift RCC_APB2RSTR        \ RCC_USART1RST	Bit Offset:14	Bit Width:1
        \ %x  12 lshift RCC_APB2RSTR        \ RCC_SPI1RST	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_APB2RSTR        \ RCC_SDIORST	Bit Offset:11	Bit Width:1
        \ %x  9 lshift RCC_APB2RSTR        \ RCC_ADC1RST	Bit Offset:9	Bit Width:1
        \ %x  4 lshift RCC_APB2RSTR        \ RCC_TM11RST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_APB2RSTR        \ RCC_TM10RST	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_APB2RSTR        \ RCC_TIM9RST	Bit Offset:2	Bit Width:1
        \ %x  0 lshift RCC_APB2RSTR        \ RCC_SYSCFGRST	Bit Offset:0	Bit Width:1
        
        RCC $18 + constant RCC_APB1RSTR	\ read-write		\  : RESET_RCC_APB1RSTR $00000000 
        \ %x  31 lshift RCC_APB1RSTR        \ RCC_COMPRST	Bit Offset:31	Bit Width:1
        \ %x  29 lshift RCC_APB1RSTR        \ RCC_DACRST	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_APB1RSTR        \ RCC_PWRRST	Bit Offset:28	Bit Width:1
        \ %x  23 lshift RCC_APB1RSTR        \ RCC_USBRST	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_APB1RSTR        \ RCC_I2C2RST	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_APB1RSTR        \ RCC_I2C1RST	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RCC_APB1RSTR        \ RCC_UART5RST	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RCC_APB1RSTR        \ RCC_UART4RST	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_APB1RSTR        \ RCC_USART3RST	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_APB1RSTR        \ RCC_USART2RST	Bit Offset:17	Bit Width:1
        \ %x  15 lshift RCC_APB1RSTR        \ RCC_SPI3RST	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RCC_APB1RSTR        \ RCC_SPI2RST	Bit Offset:14	Bit Width:1
        \ %x  11 lshift RCC_APB1RSTR        \ RCC_WWDRST	Bit Offset:11	Bit Width:1
        \ %x  9 lshift RCC_APB1RSTR        \ RCC_LCDRST	Bit Offset:9	Bit Width:1
        \ %x  5 lshift RCC_APB1RSTR        \ RCC_TIM7RST	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_APB1RSTR        \ RCC_TIM6RST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_APB1RSTR        \ RCC_TIM5RST	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_APB1RSTR        \ RCC_TIM4RST	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_APB1RSTR        \ RCC_TIM3RST	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_APB1RSTR        \ RCC_TIM2RST	Bit Offset:0	Bit Width:1
        
        RCC $1C + constant RCC_AHBENR	\ read-write		\  : RESET_RCC_AHBENR $00008000 
        \ %x  30 lshift RCC_AHBENR        \ RCC_FSMCEN	Bit Offset:30	Bit Width:1
        \ %x  25 lshift RCC_AHBENR        \ RCC_DMA2EN	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_AHBENR        \ RCC_DMA1EN	Bit Offset:24	Bit Width:1
        \ %x  15 lshift RCC_AHBENR        \ RCC_FLITFEN	Bit Offset:15	Bit Width:1
        \ %x  12 lshift RCC_AHBENR        \ RCC_CRCEN	Bit Offset:12	Bit Width:1
        \ %x  7 lshift RCC_AHBENR        \ RCC_GPIOPGEN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHBENR        \ RCC_GPIOPFEN	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_AHBENR        \ RCC_GPIOPHEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_AHBENR        \ RCC_GPIOPEEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_AHBENR        \ RCC_GPIOPDEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_AHBENR        \ RCC_GPIOPCEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_AHBENR        \ RCC_GPIOPBEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_AHBENR        \ RCC_GPIOPAEN	Bit Offset:0	Bit Width:1
        
        RCC $20 + constant RCC_APB2ENR	\ read-write		\  : RESET_RCC_APB2ENR $00000000 
        \ %x  14 lshift RCC_APB2ENR        \ RCC_USART1EN	Bit Offset:14	Bit Width:1
        \ %x  12 lshift RCC_APB2ENR        \ RCC_SPI1EN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_APB2ENR        \ RCC_SDIOEN	Bit Offset:11	Bit Width:1
        \ %x  9 lshift RCC_APB2ENR        \ RCC_ADC1EN	Bit Offset:9	Bit Width:1
        \ %x  4 lshift RCC_APB2ENR        \ RCC_TIM11EN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_APB2ENR        \ RCC_TIM10EN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_APB2ENR        \ RCC_TIM9EN	Bit Offset:2	Bit Width:1
        \ %x  0 lshift RCC_APB2ENR        \ RCC_SYSCFGEN	Bit Offset:0	Bit Width:1
        
        RCC $24 + constant RCC_APB1ENR	\ read-write		\  : RESET_RCC_APB1ENR $00000000 
        \ %x  31 lshift RCC_APB1ENR        \ RCC_COMPEN	Bit Offset:31	Bit Width:1
        \ %x  29 lshift RCC_APB1ENR        \ RCC_DACEN	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_APB1ENR        \ RCC_PWREN	Bit Offset:28	Bit Width:1
        \ %x  23 lshift RCC_APB1ENR        \ RCC_USBEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_APB1ENR        \ RCC_I2C2EN	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_APB1ENR        \ RCC_I2C1EN	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RCC_APB1ENR        \ RCC_USART5EN	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RCC_APB1ENR        \ RCC_USART4EN	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_APB1ENR        \ RCC_USART3EN	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_APB1ENR        \ RCC_USART2EN	Bit Offset:17	Bit Width:1
        \ %x  15 lshift RCC_APB1ENR        \ RCC_SPI3EN	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RCC_APB1ENR        \ RCC_SPI2EN	Bit Offset:14	Bit Width:1
        \ %x  11 lshift RCC_APB1ENR        \ RCC_WWDGEN	Bit Offset:11	Bit Width:1
        \ %x  9 lshift RCC_APB1ENR        \ RCC_LCDEN	Bit Offset:9	Bit Width:1
        \ %x  5 lshift RCC_APB1ENR        \ RCC_TIM7EN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_APB1ENR        \ RCC_TIM6EN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_APB1ENR        \ RCC_TIM5EN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_APB1ENR        \ RCC_TIM4EN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_APB1ENR        \ RCC_TIM3EN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_APB1ENR        \ RCC_TIM2EN	Bit Offset:0	Bit Width:1
        
        RCC $28 + constant RCC_AHBLPENR	\ read-write		\  : RESET_RCC_AHBLPENR $0101903F 
        \ %x  25 lshift RCC_AHBLPENR        \ RCC_DMA2LPEN	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_AHBLPENR        \ RCC_DMA1LPEN	Bit Offset:24	Bit Width:1
        \ %x  16 lshift RCC_AHBLPENR        \ RCC_SRAMLPEN	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RCC_AHBLPENR        \ RCC_FLITFLPEN	Bit Offset:15	Bit Width:1
        \ %x  12 lshift RCC_AHBLPENR        \ RCC_CRCLPEN	Bit Offset:12	Bit Width:1
        \ %x  7 lshift RCC_AHBLPENR        \ RCC_GPIOGLPEN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHBLPENR        \ RCC_GPIOFLPEN	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_AHBLPENR        \ RCC_GPIOHLPEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_AHBLPENR        \ RCC_GPIOELPEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_AHBLPENR        \ RCC_GPIODLPEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_AHBLPENR        \ RCC_GPIOCLPEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_AHBLPENR        \ RCC_GPIOBLPEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_AHBLPENR        \ RCC_GPIOALPEN	Bit Offset:0	Bit Width:1
        
        RCC $2C + constant RCC_APB2LPENR	\ read-write		\  : RESET_RCC_APB2LPENR $00000000 
        \ %x  14 lshift RCC_APB2LPENR        \ RCC_USART1LPEN	Bit Offset:14	Bit Width:1
        \ %x  12 lshift RCC_APB2LPENR        \ RCC_SPI1LPEN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_APB2LPENR        \ RCC_SDIOLPEN	Bit Offset:11	Bit Width:1
        \ %x  9 lshift RCC_APB2LPENR        \ RCC_ADC1LPEN	Bit Offset:9	Bit Width:1
        \ %x  4 lshift RCC_APB2LPENR        \ RCC_TIM11LPEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_APB2LPENR        \ RCC_TIM10LPEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_APB2LPENR        \ RCC_TIM9LPEN	Bit Offset:2	Bit Width:1
        \ %x  0 lshift RCC_APB2LPENR        \ RCC_SYSCFGLPEN	Bit Offset:0	Bit Width:1
        
        RCC $30 + constant RCC_APB1LPENR	\ read-write		\  : RESET_RCC_APB1LPENR $00000000 
        \ %x  31 lshift RCC_APB1LPENR        \ RCC_COMPLPEN	Bit Offset:31	Bit Width:1
        \ %x  29 lshift RCC_APB1LPENR        \ RCC_DACLPEN	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_APB1LPENR        \ RCC_PWRLPEN	Bit Offset:28	Bit Width:1
        \ %x  23 lshift RCC_APB1LPENR        \ RCC_USBLPEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_APB1LPENR        \ RCC_I2C2LPEN	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_APB1LPENR        \ RCC_I2C1LPEN	Bit Offset:21	Bit Width:1
        \ %x  18 lshift RCC_APB1LPENR        \ RCC_USART3LPEN	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_APB1LPENR        \ RCC_USART2LPEN	Bit Offset:17	Bit Width:1
        \ %x  14 lshift RCC_APB1LPENR        \ RCC_SPI2LPEN	Bit Offset:14	Bit Width:1
        \ %x  11 lshift RCC_APB1LPENR        \ RCC_WWDGLPEN	Bit Offset:11	Bit Width:1
        \ %x  9 lshift RCC_APB1LPENR        \ RCC_LCDLPEN	Bit Offset:9	Bit Width:1
        \ %x  5 lshift RCC_APB1LPENR        \ RCC_TIM7LPEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_APB1LPENR        \ RCC_TIM6LPEN	Bit Offset:4	Bit Width:1
        \ %x  2 lshift RCC_APB1LPENR        \ RCC_TIM4LPEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_APB1LPENR        \ RCC_TIM3LPEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_APB1LPENR        \ RCC_TIM2LPEN	Bit Offset:0	Bit Width:1
        
        RCC $34 + constant RCC_CSR	\ 		\  : RESET_RCC_CSR $00000000 
        \ %x  31 lshift RCC_CSR        \ RCC_LPWRSTF	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RCC_CSR        \ RCC_WWDGRSTF	Bit Offset:30	Bit Width:1
        \ %x  29 lshift RCC_CSR        \ RCC_IWDGRSTF	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_CSR        \ RCC_SFTRSTF	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_CSR        \ RCC_PORRSTF	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RCC_CSR        \ RCC_PINRSTF	Bit Offset:26	Bit Width:1
        \ %x  24 lshift RCC_CSR        \ RCC_RMVF	Bit Offset:24	Bit Width:1
        \ %x  23 lshift RCC_CSR        \ RCC_RTCRST	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_CSR        \ RCC_RTCEN	Bit Offset:22	Bit Width:1
        \ %xx  16 lshift RCC_CSR        \ RCC_RTCSEL	Bit Offset:16	Bit Width:2
        \ %x  10 lshift RCC_CSR        \ RCC_LSEBYP	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RCC_CSR        \ RCC_LSERDY	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_CSR        \ RCC_LSEON	Bit Offset:8	Bit Width:1
        \ %x  1 lshift RCC_CSR        \ RCC_LSIRDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CSR        \ RCC_LSION	Bit Offset:0	Bit Width:1
        
         
	
     $40007C04 constant RI  
	 RI $4 + constant RI_ICR	\ read-write		\  : RESET_RI_ICR $00000000 
        \ %x  21 lshift RI_ICR        \ RI_IC4	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RI_ICR        \ RI_IC3	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RI_ICR        \ RI_IC2	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RI_ICR        \ RI_IC1	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift RI_ICR        \ RI_TIM	Bit Offset:16	Bit Width:2
        \ %xxxx  12 lshift RI_ICR        \ RI_IC4IOS	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift RI_ICR        \ RI_IC3IOS	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift RI_ICR        \ RI_IC2IOS	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift RI_ICR        \ RI_IC1IOS	Bit Offset:0	Bit Width:4
        
        RI $8 + constant RI_ASCR1	\ read-write		\  : RESET_RI_ASCR1 $00000000 
        \ %x  31 lshift RI_ASCR1        \ RI_SCM	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RI_ASCR1        \ RI_CH30GR11_4	Bit Offset:30	Bit Width:1
        \ %x  29 lshift RI_ASCR1        \ RI_CH29GR11_3	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RI_ASCR1        \ RI_CH28GR11_2	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RI_ASCR1        \ RI_CH27GR11_1	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RI_ASCR1        \ RI_VCOMP	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RI_ASCR1        \ RI_CH25	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RI_ASCR1        \ RI_CH24	Bit Offset:24	Bit Width:1
        \ %x  23 lshift RI_ASCR1        \ RI_CH23	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RI_ASCR1        \ RI_CH22	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RI_ASCR1        \ RI_CH21GR7_4	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RI_ASCR1        \ RI_CH20GR7_3	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RI_ASCR1        \ RI_CH19GR7_2	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RI_ASCR1        \ RI_CH18GR7_1	Bit Offset:18	Bit Width:1
        \ %x  16 lshift RI_ASCR1        \ RI_CH31GR7_1	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RI_ASCR1        \ RI_CH15GR9_2	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RI_ASCR1        \ RI_CH14GR9_1	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RI_ASCR1        \ RI_CH13GR8_4	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RI_ASCR1        \ RI_CH12GR8_3	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RI_ASCR1        \ RI_CH11GR8_2	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RI_ASCR1        \ RI_CH10GR8_1	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RI_ASCR1        \ RI_CH9GR3_2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RI_ASCR1        \ RI_CH8GR3_1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RI_ASCR1        \ RI_CH7GR2_2	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RI_ASCR1        \ RI_CH6GR2_1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RI_ASCR1        \ RI_COMP1_SW1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RI_ASCR1        \ RI_CH31GR11_5	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RI_ASCR1        \ RI_CH3GR1_4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RI_ASCR1        \ RI_CH2GR1_3	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RI_ASCR1        \ RI_CH1GR1_2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RI_ASCR1        \ RI_CH0GR1_1	Bit Offset:0	Bit Width:1
        
        RI $C + constant RI_ASCR2	\ read-write		\  : RESET_RI_ASCR2 $00000000 
        \ %x  29 lshift RI_ASCR2        \ RI_GR5_4	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RI_ASCR2        \ RI_GR6_4	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RI_ASCR2        \ RI_GR6_3	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RI_ASCR2        \ RI_GR7_7	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RI_ASCR2        \ RI_GR7_6	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RI_ASCR2        \ RI_GR7_5	Bit Offset:24	Bit Width:1
        \ %x  23 lshift RI_ASCR2        \ RI_GR2_5	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RI_ASCR2        \ RI_GR2_4	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RI_ASCR2        \ RI_GR2_3	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RI_ASCR2        \ RI_GR9_4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RI_ASCR2        \ RI_GR9_3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RI_ASCR2        \ RI_GR3_5	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RI_ASCR2        \ RI_GR3_4	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RI_ASCR2        \ RI_GR3_3	Bit Offset:16	Bit Width:1
        \ %x  11 lshift RI_ASCR2        \ RI_GR4_3	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RI_ASCR2        \ RI_GR4_2	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RI_ASCR2        \ RI_GR4_1	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RI_ASCR2        \ RI_GR5_3	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RI_ASCR2        \ RI_GR5_2	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RI_ASCR2        \ RI_GR5_1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RI_ASCR2        \ RI_GR6_2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RI_ASCR2        \ RI_GR6_1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RI_ASCR2        \ RI_GR10_4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RI_ASCR2        \ RI_GR10_3	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RI_ASCR2        \ RI_GR10_2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RI_ASCR2        \ RI_GR10_1	Bit Offset:0	Bit Width:1
        
        RI $10 + constant RI_HYSCR1	\ read-write		\  : RESET_RI_HYSCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift RI_HYSCR1        \ RI_PB	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift RI_HYSCR1        \ RI_PA	Bit Offset:0	Bit Width:16
        
        RI $14 + constant RI_HYSCR2	\ read-write		\  : RESET_RI_HYSCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift RI_HYSCR2        \ RI_PD	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift RI_HYSCR2        \ RI_PC	Bit Offset:0	Bit Width:16
        
        RI $18 + constant RI_HYSCR3	\ read-write		\  : RESET_RI_HYSCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift RI_HYSCR3        \ RI_PF	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift RI_HYSCR3        \ RI_PE	Bit Offset:0	Bit Width:16
        
        RI $1C + constant RI_HYSCR4	\ read-write		\  : RESET_RI_HYSCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RI_HYSCR4        \ RI_PG	Bit Offset:0	Bit Width:16
        
         
	
     $40002800 constant RTC  
	 RTC $0 + constant RTC_TR	\ read-write		\  : RESET_RTC_TR $00000000 
        \ %x  22 lshift RTC_TR        \ RTC_PM	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift RTC_TR        \ RTC_HT	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift RTC_TR        \ RTC_HU	Bit Offset:16	Bit Width:4
        \ %xxx  12 lshift RTC_TR        \ RTC_MNT	Bit Offset:12	Bit Width:3
        \ %xxxx  8 lshift RTC_TR        \ RTC_MNU	Bit Offset:8	Bit Width:4
        \ %xxx  4 lshift RTC_TR        \ RTC_ST	Bit Offset:4	Bit Width:3
        \ %xxxx  0 lshift RTC_TR        \ RTC_SU	Bit Offset:0	Bit Width:4
        
        RTC $4 + constant RTC_DR	\ read-write		\  : RESET_RTC_DR $00002101 
        \ %xxxx  20 lshift RTC_DR        \ RTC_YT	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift RTC_DR        \ RTC_YU	Bit Offset:16	Bit Width:4
        \ %xxx  13 lshift RTC_DR        \ RTC_WDU	Bit Offset:13	Bit Width:3
        \ %x  12 lshift RTC_DR        \ RTC_MT	Bit Offset:12	Bit Width:1
        \ %xxxx  8 lshift RTC_DR        \ RTC_MU	Bit Offset:8	Bit Width:4
        \ %xx  4 lshift RTC_DR        \ RTC_DT	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift RTC_DR        \ RTC_DU	Bit Offset:0	Bit Width:4
        
        RTC $8 + constant RTC_CR	\ read-write		\  : RESET_RTC_CR $00000000 
        \ %x  23 lshift RTC_CR        \ RTC_COE	Bit Offset:23	Bit Width:1
        \ %xx  21 lshift RTC_CR        \ RTC_OSEL	Bit Offset:21	Bit Width:2
        \ %x  20 lshift RTC_CR        \ RTC_POL	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RTC_CR        \ RTC_COSEL	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RTC_CR        \ RTC_BKP	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RTC_CR        \ RTC_SUB1H	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RTC_CR        \ RTC_ADD1H	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RTC_CR        \ RTC_TSIE	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RTC_CR        \ RTC_WUTIE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RTC_CR        \ RTC_ALRBIE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RTC_CR        \ RTC_ALRAIE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RTC_CR        \ RTC_TSE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RTC_CR        \ RTC_WUTE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RTC_CR        \ RTC_ALRBE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RTC_CR        \ RTC_ALRAE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RTC_CR        \ RTC_DCE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RTC_CR        \ RTC_FMT	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RTC_CR        \ RTC_BYPSHAD	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RTC_CR        \ RTC_REFCKON	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_CR        \ RTC_TSEDGE	Bit Offset:3	Bit Width:1
        \ %xxx  0 lshift RTC_CR        \ RTC_WCKSEL	Bit Offset:0	Bit Width:3
        
        RTC $C + constant RTC_ISR	\ 		\  : RESET_RTC_ISR $00000007 
        \ %x  16 lshift RTC_ISR        \ RTC_RECALPF	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RTC_ISR        \ RTC_TAMP3F	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RTC_ISR        \ RTC_TAMP2F	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RTC_ISR        \ RTC_TAMP1F	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RTC_ISR        \ RTC_TSOVF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RTC_ISR        \ RTC_TSF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RTC_ISR        \ RTC_WUTF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RTC_ISR        \ RTC_ALRBF	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RTC_ISR        \ RTC_ALRAF	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RTC_ISR        \ RTC_INIT	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RTC_ISR        \ RTC_INITF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RTC_ISR        \ RTC_RSF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RTC_ISR        \ RTC_INITS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_ISR        \ RTC_SHPF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RTC_ISR        \ RTC_WUTWF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RTC_ISR        \ RTC_ALRBWF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RTC_ISR        \ RTC_ALRAWF	Bit Offset:0	Bit Width:1
        
        RTC $10 + constant RTC_PRER	\ read-write		\  : RESET_RTC_PRER $007F00FF 
        \ %xxxxxxx  16 lshift RTC_PRER        \ RTC_PREDIV_A	Bit Offset:16	Bit Width:7
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_PRER        \ RTC_PREDIV_S	Bit Offset:0	Bit Width:15
        
        RTC $14 + constant RTC_WUTR	\ read-write		\  : RESET_RTC_WUTR $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_WUTR        \ RTC_WUT	Bit Offset:0	Bit Width:16
        
        RTC $18 + constant RTC_CALIBR	\ read-write		\  : RESET_RTC_CALIBR $00000000 
        \ %x  7 lshift RTC_CALIBR        \ RTC_DCS	Bit Offset:7	Bit Width:1
        \ %xxxxx  0 lshift RTC_CALIBR        \ RTC_DC	Bit Offset:0	Bit Width:5
        
        RTC $1C + constant RTC_ALRMAR	\ read-write		\  : RESET_RTC_ALRMAR $00000000 
        \ %x  31 lshift RTC_ALRMAR        \ RTC_MSK4	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RTC_ALRMAR        \ RTC_WDSEL	Bit Offset:30	Bit Width:1
        \ %xx  28 lshift RTC_ALRMAR        \ RTC_DT	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift RTC_ALRMAR        \ RTC_DU	Bit Offset:24	Bit Width:4
        \ %x  23 lshift RTC_ALRMAR        \ RTC_MSK3	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RTC_ALRMAR        \ RTC_PM	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift RTC_ALRMAR        \ RTC_HT	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift RTC_ALRMAR        \ RTC_HU	Bit Offset:16	Bit Width:4
        \ %x  15 lshift RTC_ALRMAR        \ RTC_MSK2	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift RTC_ALRMAR        \ RTC_MNT	Bit Offset:12	Bit Width:3
        \ %xxxx  8 lshift RTC_ALRMAR        \ RTC_MNU	Bit Offset:8	Bit Width:4
        \ %x  7 lshift RTC_ALRMAR        \ RTC_MSK1	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift RTC_ALRMAR        \ RTC_ST	Bit Offset:4	Bit Width:3
        \ %xxxx  0 lshift RTC_ALRMAR        \ RTC_SU	Bit Offset:0	Bit Width:4
        
        RTC $20 + constant RTC_ALRMBR	\ read-write		\  : RESET_RTC_ALRMBR $00000000 
        \ %x  31 lshift RTC_ALRMBR        \ RTC_MSK4	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RTC_ALRMBR        \ RTC_WDSEL	Bit Offset:30	Bit Width:1
        \ %xx  28 lshift RTC_ALRMBR        \ RTC_DT	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift RTC_ALRMBR        \ RTC_DU	Bit Offset:24	Bit Width:4
        \ %x  23 lshift RTC_ALRMBR        \ RTC_MSK3	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RTC_ALRMBR        \ RTC_PM	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift RTC_ALRMBR        \ RTC_HT	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift RTC_ALRMBR        \ RTC_HU	Bit Offset:16	Bit Width:4
        \ %x  15 lshift RTC_ALRMBR        \ RTC_MSK2	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift RTC_ALRMBR        \ RTC_MNT	Bit Offset:12	Bit Width:3
        \ %xxxx  8 lshift RTC_ALRMBR        \ RTC_MNU	Bit Offset:8	Bit Width:4
        \ %x  7 lshift RTC_ALRMBR        \ RTC_MSK1	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift RTC_ALRMBR        \ RTC_ST	Bit Offset:4	Bit Width:3
        \ %xxxx  0 lshift RTC_ALRMBR        \ RTC_SU	Bit Offset:0	Bit Width:4
        
        RTC $24 + constant RTC_WPR	\ write-only		\  : RESET_RTC_WPR $00000000 
        \ %xxxxxxxx  0 lshift RTC_WPR        \ RTC_KEY	Bit Offset:0	Bit Width:8
        
        RTC $28 + constant RTC_SSR	\ read-only		\  : RESET_RTC_SSR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_SSR        \ RTC_SS	Bit Offset:0	Bit Width:16
        
        RTC $2C + constant RTC_SHIFTR	\ write-only		\  : RESET_RTC_SHIFTR $00000000 
        \ %x  31 lshift RTC_SHIFTR        \ RTC_ADD1S	Bit Offset:31	Bit Width:1
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_SHIFTR        \ RTC_SUBFS	Bit Offset:0	Bit Width:15
        
        RTC $30 + constant RTC_TSTR	\ read-only		\  : RESET_RTC_TSTR $00000000 
        \ %x  22 lshift RTC_TSTR        \ RTC_PM	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift RTC_TSTR        \ RTC_HT	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift RTC_TSTR        \ RTC_HU	Bit Offset:16	Bit Width:4
        \ %xxx  12 lshift RTC_TSTR        \ RTC_MNT	Bit Offset:12	Bit Width:3
        \ %xxxx  8 lshift RTC_TSTR        \ RTC_MNU	Bit Offset:8	Bit Width:4
        \ %xxx  4 lshift RTC_TSTR        \ RTC_ST	Bit Offset:4	Bit Width:3
        \ %xxxx  0 lshift RTC_TSTR        \ RTC_SU	Bit Offset:0	Bit Width:4
        
        RTC $34 + constant RTC_TSDR	\ read-only		\  : RESET_RTC_TSDR $00000000 
        \ %xxx  13 lshift RTC_TSDR        \ RTC_WDU	Bit Offset:13	Bit Width:3
        \ %x  12 lshift RTC_TSDR        \ RTC_MT	Bit Offset:12	Bit Width:1
        \ %xxxx  8 lshift RTC_TSDR        \ RTC_MU	Bit Offset:8	Bit Width:4
        \ %xx  4 lshift RTC_TSDR        \ RTC_DT	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift RTC_TSDR        \ RTC_DU	Bit Offset:0	Bit Width:4
        
        RTC $38 + constant RTC_TSSSR	\ read-only		\  : RESET_RTC_TSSSR $00000000 
        \ %x  15 lshift RTC_TSSSR        \ RTC_CALP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RTC_TSSSR        \ RTC_CALW8	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RTC_TSSSR        \ RTC_CALW16	Bit Offset:13	Bit Width:1
        \ %xxxxxxxxx  0 lshift RTC_TSSSR        \ RTC_CALM	Bit Offset:0	Bit Width:9
        
        RTC $3C + constant RTC_CALR	\ 		\  : RESET_RTC_CALR $00000000 
        \ %x  18 lshift RTC_CALR        \ RTC_ALARMOUTTYPE	Bit Offset:18	Bit Width:1
        \ %x  15 lshift RTC_CALR        \ RTC_TAMPPUDIS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift RTC_CALR        \ RTC_TAMPPRCH	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift RTC_CALR        \ RTC_TAMPFLT	Bit Offset:11	Bit Width:2
        \ %xxx  8 lshift RTC_CALR        \ RTC_TAMPFREQ	Bit Offset:8	Bit Width:3
        \ %x  7 lshift RTC_CALR        \ RTC_TAMPTS	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RTC_CALR        \ RTC_TAMP3TRG	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RTC_CALR        \ RTC_TAMP3E	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RTC_CALR        \ RTC_TAMP2TRG	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_CALR        \ RTC_TAMP2E	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RTC_CALR        \ RTC_TAMPIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RTC_CALR        \ RTC_TAMP1ETRG	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RTC_CALR        \ RTC_TAMP1E	Bit Offset:0	Bit Width:1
        
        RTC $40 + constant RTC_TAFCR	\ read-write		\  : RESET_RTC_TAFCR $00000000 
        \ %xxxx  24 lshift RTC_TAFCR        \ RTC_MASKSS	Bit Offset:24	Bit Width:4
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_TAFCR        \ RTC_SS	Bit Offset:0	Bit Width:15
        
        RTC $44 + constant RTC_ALRMASSR	\ read-write		\  : RESET_RTC_ALRMASSR $00000000 
        \ %xxxx  24 lshift RTC_ALRMASSR        \ RTC_MASKSS	Bit Offset:24	Bit Width:4
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_ALRMASSR        \ RTC_SS	Bit Offset:0	Bit Width:15
        
        RTC $48 + constant RTC_ALRMBSSR	\ read-write		\  : RESET_RTC_ALRMBSSR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_ALRMBSSR        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $9C + constant RTC_BK0R	\ read-write		\  : RESET_RTC_BK0R $00000000 
        
         
	
     $40012C00 constant SDIO  
	 SDIO $0 + constant SDIO_POWER	\ read-write		\  : RESET_SDIO_POWER $00000000 
        \ %xx  0 lshift SDIO_POWER        \ SDIO_PWRCTRL	Bit Offset:0	Bit Width:2
        
        SDIO $4 + constant SDIO_CLKCR	\ read-write		\  : RESET_SDIO_CLKCR $00000000 
        \ %x  14 lshift SDIO_CLKCR        \ SDIO_HWFC_EN	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SDIO_CLKCR        \ SDIO_NEGEDGE	Bit Offset:13	Bit Width:1
        \ %xx  11 lshift SDIO_CLKCR        \ SDIO_WIDBUS	Bit Offset:11	Bit Width:2
        \ %x  10 lshift SDIO_CLKCR        \ SDIO_BYPASS	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SDIO_CLKCR        \ SDIO_PWRSAV	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SDIO_CLKCR        \ SDIO_CLKEN	Bit Offset:8	Bit Width:1
        \ %xxxxxxxx  0 lshift SDIO_CLKCR        \ SDIO_CLKDIV	Bit Offset:0	Bit Width:8
        
        SDIO $8 + constant SDIO_ARG	\ read-write		\  : RESET_SDIO_ARG $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_ARG        \ SDIO_CMDARG	Bit Offset:0	Bit Width:32
        
        SDIO $C + constant SDIO_CMD	\ read-write		\  : RESET_SDIO_CMD $00000000 
        \ %x  14 lshift SDIO_CMD        \ SDIO_CE_ATACMD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SDIO_CMD        \ SDIO_nIEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SDIO_CMD        \ SDIO_ENCMDcompl	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SDIO_CMD        \ SDIO_SDIOSuspend	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SDIO_CMD        \ SDIO_CPSMEN	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SDIO_CMD        \ SDIO_WAITPEND	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SDIO_CMD        \ SDIO_WAITINT	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift SDIO_CMD        \ SDIO_WAITRESP	Bit Offset:6	Bit Width:2
        \ %xxxxxx  0 lshift SDIO_CMD        \ SDIO_CMDINDEX	Bit Offset:0	Bit Width:6
        
        SDIO $10 + constant SDIO_RESPCMD	\ read-only		\  : RESET_SDIO_RESPCMD $00000000 
        \ %xxxxxx  0 lshift SDIO_RESPCMD        \ SDIO_RESPCMD	Bit Offset:0	Bit Width:6
        
        SDIO $14 + constant SDIO_RESP1	\ read-only		\  : RESET_SDIO_RESP1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_RESP1        \ SDIO_CARDSTATUS1	Bit Offset:0	Bit Width:32
        
        SDIO $18 + constant SDIO_RESP2	\ read-only		\  : RESET_SDIO_RESP2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_RESP2        \ SDIO_CARDSTATUS2	Bit Offset:0	Bit Width:32
        
        SDIO $1C + constant SDIO_RESP3	\ read-only		\  : RESET_SDIO_RESP3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_RESP3        \ SDIO_CARDSTATUS3	Bit Offset:0	Bit Width:32
        
        SDIO $20 + constant SDIO_RESP4	\ read-only		\  : RESET_SDIO_RESP4 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_RESP4        \ SDIO_CARDSTATUS4	Bit Offset:0	Bit Width:32
        
        SDIO $24 + constant SDIO_DTIMER	\ read-write		\  : RESET_SDIO_DTIMER $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_DTIMER        \ SDIO_DATATIME	Bit Offset:0	Bit Width:32
        
        SDIO $28 + constant SDIO_DLEN	\ read-write		\  : RESET_SDIO_DLEN $00000000 
        \ % 0 lshift SDIO_DLEN        \ SDIO_DATALENGTH	Bit Offset:0	Bit Width:25
        
        SDIO $2C + constant SDIO_DCTRL	\ read-write		\  : RESET_SDIO_DCTRL $00000000 
        \ %x  11 lshift SDIO_DCTRL        \ SDIO_SDIOEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SDIO_DCTRL        \ SDIO_RWMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SDIO_DCTRL        \ SDIO_RWSTOP	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SDIO_DCTRL        \ SDIO_RWSTART	Bit Offset:8	Bit Width:1
        \ %xxxx  4 lshift SDIO_DCTRL        \ SDIO_DBLOCKSIZE	Bit Offset:4	Bit Width:4
        \ %x  3 lshift SDIO_DCTRL        \ SDIO_DMAEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SDIO_DCTRL        \ SDIO_DTMODE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SDIO_DCTRL        \ SDIO_DTDIR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SDIO_DCTRL        \ SDIO_DTEN	Bit Offset:0	Bit Width:1
        
        SDIO $30 + constant SDIO_DCOUNT	\ read-only		\  : RESET_SDIO_DCOUNT $00000000 
        \ % 0 lshift SDIO_DCOUNT        \ SDIO_DATACOUNT	Bit Offset:0	Bit Width:25
        
        SDIO $34 + constant SDIO_STA	\ read-only		\  : RESET_SDIO_STA $00000000 
        \ %x  23 lshift SDIO_STA        \ SDIO_CEATAEND	Bit Offset:23	Bit Width:1
        \ %x  22 lshift SDIO_STA        \ SDIO_SDIOIT	Bit Offset:22	Bit Width:1
        \ %x  21 lshift SDIO_STA        \ SDIO_RXDAVL	Bit Offset:21	Bit Width:1
        \ %x  20 lshift SDIO_STA        \ SDIO_TXDAVL	Bit Offset:20	Bit Width:1
        \ %x  19 lshift SDIO_STA        \ SDIO_RXFIFOE	Bit Offset:19	Bit Width:1
        \ %x  18 lshift SDIO_STA        \ SDIO_TXFIFOE	Bit Offset:18	Bit Width:1
        \ %x  17 lshift SDIO_STA        \ SDIO_RXFIFOF	Bit Offset:17	Bit Width:1
        \ %x  16 lshift SDIO_STA        \ SDIO_TXFIFOF	Bit Offset:16	Bit Width:1
        \ %x  15 lshift SDIO_STA        \ SDIO_RXFIFOHF	Bit Offset:15	Bit Width:1
        \ %x  14 lshift SDIO_STA        \ SDIO_TXFIFOHE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SDIO_STA        \ SDIO_RXACT	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SDIO_STA        \ SDIO_TXACT	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SDIO_STA        \ SDIO_CMDACT	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SDIO_STA        \ SDIO_DBCKEND	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SDIO_STA        \ SDIO_STBITERR	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SDIO_STA        \ SDIO_DATAEND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SDIO_STA        \ SDIO_CMDSENT	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SDIO_STA        \ SDIO_CMDREND	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SDIO_STA        \ SDIO_RXOVERR	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SDIO_STA        \ SDIO_TXUNDERR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SDIO_STA        \ SDIO_DTIMEOUT	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SDIO_STA        \ SDIO_CTIMEOUT	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SDIO_STA        \ SDIO_DCRCFAIL	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SDIO_STA        \ SDIO_CCRCFAIL	Bit Offset:0	Bit Width:1
        
        SDIO $38 + constant SDIO_ICR	\ read-write		\  : RESET_SDIO_ICR $00000000 
        \ %x  23 lshift SDIO_ICR        \ SDIO_CEATAENDC	Bit Offset:23	Bit Width:1
        \ %x  22 lshift SDIO_ICR        \ SDIO_SDIOITC	Bit Offset:22	Bit Width:1
        \ %x  10 lshift SDIO_ICR        \ SDIO_DBCKENDC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SDIO_ICR        \ SDIO_STBITERRC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SDIO_ICR        \ SDIO_DATAENDC	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SDIO_ICR        \ SDIO_CMDSENTC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SDIO_ICR        \ SDIO_CMDRENDC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SDIO_ICR        \ SDIO_RXOVERRC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SDIO_ICR        \ SDIO_TXUNDERRC	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SDIO_ICR        \ SDIO_DTIMEOUTC	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SDIO_ICR        \ SDIO_CTIMEOUTC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SDIO_ICR        \ SDIO_DCRCFAILC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SDIO_ICR        \ SDIO_CCRCFAILC	Bit Offset:0	Bit Width:1
        
        SDIO $3C + constant SDIO_MASK	\ read-write		\  : RESET_SDIO_MASK $00000000 
        \ %x  23 lshift SDIO_MASK        \ SDIO_CEATAENDIE	Bit Offset:23	Bit Width:1
        \ %x  22 lshift SDIO_MASK        \ SDIO_SDIOITIE	Bit Offset:22	Bit Width:1
        \ %x  21 lshift SDIO_MASK        \ SDIO_RXDAVLIE	Bit Offset:21	Bit Width:1
        \ %x  20 lshift SDIO_MASK        \ SDIO_TXDAVLIE	Bit Offset:20	Bit Width:1
        \ %x  19 lshift SDIO_MASK        \ SDIO_RXFIFOEIE	Bit Offset:19	Bit Width:1
        \ %x  18 lshift SDIO_MASK        \ SDIO_TXFIFOEIE	Bit Offset:18	Bit Width:1
        \ %x  17 lshift SDIO_MASK        \ SDIO_RXFIFOFIE	Bit Offset:17	Bit Width:1
        \ %x  16 lshift SDIO_MASK        \ SDIO_TXFIFOFIE	Bit Offset:16	Bit Width:1
        \ %x  15 lshift SDIO_MASK        \ SDIO_RXFIFOHFIE	Bit Offset:15	Bit Width:1
        \ %x  14 lshift SDIO_MASK        \ SDIO_TXFIFOHEIE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift SDIO_MASK        \ SDIO_RXACTIE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SDIO_MASK        \ SDIO_TXACTIE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SDIO_MASK        \ SDIO_CMDACTIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SDIO_MASK        \ SDIO_DBCKENDIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SDIO_MASK        \ SDIO_STBITERRIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SDIO_MASK        \ SDIO_DATAENDIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SDIO_MASK        \ SDIO_CMDSENTIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SDIO_MASK        \ SDIO_CMDRENDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SDIO_MASK        \ SDIO_RXOVERRIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SDIO_MASK        \ SDIO_TXUNDERRIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SDIO_MASK        \ SDIO_DTIMEOUTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SDIO_MASK        \ SDIO_CTIMEOUTIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SDIO_MASK        \ SDIO_DCRCFAILIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SDIO_MASK        \ SDIO_CCRCFAILIE	Bit Offset:0	Bit Width:1
        
        SDIO $48 + constant SDIO_FIFOCNT	\ read-only		\  : RESET_SDIO_FIFOCNT $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_FIFOCNT        \ SDIO_FIFOCOUNT	Bit Offset:0	Bit Width:24
        
        SDIO $80 + constant SDIO_FIFO	\ read-write		\  : RESET_SDIO_FIFO $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_FIFO        \ SDIO_FIF0Data	Bit Offset:0	Bit Width:32
        
         
	
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
        \ %x  4 lshift SPI1_CR2        \ SPI1_FRF	Bit Offset:4	Bit Width:1
        \ %x  2 lshift SPI1_CR2        \ SPI1_SSOE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift SPI1_CR2        \ SPI1_TXDMAEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift SPI1_CR2        \ SPI1_RXDMAEN	Bit Offset:0	Bit Width:1
        
        SPI1 $8 + constant SPI1_SR	\ 		\  : RESET_SPI1_SR $0002 
        \ %x  8 lshift SPI1_SR        \ SPI1_TIFRFE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift SPI1_SR        \ SPI1_BSY	Bit Offset:7	Bit Width:1
        \ %x  6 lshift SPI1_SR        \ SPI1_OVR	Bit Offset:6	Bit Width:1
        \ %x  5 lshift SPI1_SR        \ SPI1_MODF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift SPI1_SR        \ SPI1_CRCERR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift SPI1_SR        \ SPI1_UDR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift SPI1_SR        \ SPI1_CHSIDE	Bit Offset:2	Bit Width:1
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
        
        SPI1 $1C + constant SPI1_I2SCFGR	\ read-write		\  : RESET_SPI1_I2SCFGR $0000 
        \ %x  11 lshift SPI1_I2SCFGR        \ SPI1_I2SMOD	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SPI1_I2SCFGR        \ SPI1_I2SE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift SPI1_I2SCFGR        \ SPI1_I2SCFG	Bit Offset:8	Bit Width:2
        \ %x  7 lshift SPI1_I2SCFGR        \ SPI1_PCMSYNC	Bit Offset:7	Bit Width:1
        \ %xx  4 lshift SPI1_I2SCFGR        \ SPI1_I2SSTD	Bit Offset:4	Bit Width:2
        \ %x  3 lshift SPI1_I2SCFGR        \ SPI1_CKPOL	Bit Offset:3	Bit Width:1
        \ %xx  1 lshift SPI1_I2SCFGR        \ SPI1_DATLEN	Bit Offset:1	Bit Width:2
        \ %x  0 lshift SPI1_I2SCFGR        \ SPI1_CHLEN	Bit Offset:0	Bit Width:1
        
        SPI1 $20 + constant SPI1_I2SPR	\ read-write		\  : RESET_SPI1_I2SPR $00000002 
        \ %x  9 lshift SPI1_I2SPR        \ SPI1_MCKOE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SPI1_I2SPR        \ SPI1_ODD	Bit Offset:8	Bit Width:1
        \ %xxxxxxxx  0 lshift SPI1_I2SPR        \ SPI1_I2SDIV	Bit Offset:0	Bit Width:8
        
         
	
     $40003800 constant SPI2  
	  
	
     $40003C00 constant SPI3  
	  
	
     $40010000 constant SYSCFG  
	 SYSCFG $0 + constant SYSCFG_MEMRMP	\ 		\  : RESET_SYSCFG_MEMRMP $00000000 
        \ %xx  0 lshift SYSCFG_MEMRMP        \ SYSCFG_MEM_MODE	Bit Offset:0	Bit Width:2
        \ %xx  8 lshift SYSCFG_MEMRMP        \ SYSCFG_BOOT_MODE	Bit Offset:8	Bit Width:2
        
        SYSCFG $4 + constant SYSCFG_PMC	\ read-write		\  : RESET_SYSCFG_PMC $00000000 
        \ %x  0 lshift SYSCFG_PMC        \ SYSCFG_USB_PU	Bit Offset:0	Bit Width:1
        
        SYSCFG $8 + constant SYSCFG_EXTICR1	\ read-write		\  : RESET_SYSCFG_EXTICR1 $0000 
        \ %xxxx  12 lshift SYSCFG_EXTICR1        \ SYSCFG_EXTI3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift SYSCFG_EXTICR1        \ SYSCFG_EXTI2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift SYSCFG_EXTICR1        \ SYSCFG_EXTI1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift SYSCFG_EXTICR1        \ SYSCFG_EXTI0	Bit Offset:0	Bit Width:4
        
        SYSCFG $C + constant SYSCFG_EXTICR2	\ read-write		\  : RESET_SYSCFG_EXTICR2 $0000 
        \ %xxxx  12 lshift SYSCFG_EXTICR2        \ SYSCFG_EXTI7	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift SYSCFG_EXTICR2        \ SYSCFG_EXTI6	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift SYSCFG_EXTICR2        \ SYSCFG_EXTI5	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift SYSCFG_EXTICR2        \ SYSCFG_EXTI4	Bit Offset:0	Bit Width:4
        
        SYSCFG $10 + constant SYSCFG_EXTICR3	\ read-write		\  : RESET_SYSCFG_EXTICR3 $0000 
        \ %xxxx  12 lshift SYSCFG_EXTICR3        \ SYSCFG_EXTI11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift SYSCFG_EXTICR3        \ SYSCFG_EXTI10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift SYSCFG_EXTICR3        \ SYSCFG_EXTI9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift SYSCFG_EXTICR3        \ SYSCFG_EXTI8	Bit Offset:0	Bit Width:4
        
        SYSCFG $14 + constant SYSCFG_EXTICR4	\ read-write		\  : RESET_SYSCFG_EXTICR4 $0000 
        \ %xxxx  12 lshift SYSCFG_EXTICR4        \ SYSCFG_EXTI15	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift SYSCFG_EXTICR4        \ SYSCFG_EXTI14	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift SYSCFG_EXTICR4        \ SYSCFG_EXTI13	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift SYSCFG_EXTICR4        \ SYSCFG_EXTI12	Bit Offset:0	Bit Width:4
        
         
	
     $40010C00 constant TIM10  
	 TIM10 $0 + constant TIM10_CR1	\ read-write		\  : RESET_TIM10_CR1 $0000 
        \ %xx  8 lshift TIM10_CR1        \ TIM10_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM10_CR1        \ TIM10_ARPE	Bit Offset:7	Bit Width:1
        \ %x  2 lshift TIM10_CR1        \ TIM10_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM10_CR1        \ TIM10_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_CR1        \ TIM10_CEN	Bit Offset:0	Bit Width:1
        
        TIM10 $C + constant TIM10_DIER	\ write-only		\  : RESET_TIM10_DIER $0000 
        \ %x  1 lshift TIM10_DIER        \ TIM10_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_DIER        \ TIM10_UIE	Bit Offset:0	Bit Width:1
        
        TIM10 $10 + constant TIM10_SR	\ read-write		\  : RESET_TIM10_SR $0000 
        \ %x  9 lshift TIM10_SR        \ TIM10_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  1 lshift TIM10_SR        \ TIM10_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_SR        \ TIM10_UIF	Bit Offset:0	Bit Width:1
        
        TIM10 $14 + constant TIM10_EGR	\ read-write		\  : RESET_TIM10_EGR $0000 
        \ %x  1 lshift TIM10_EGR        \ TIM10_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_EGR        \ TIM10_UG	Bit Offset:0	Bit Width:1
        
        TIM10 $18 + constant TIM10_CCMR1_Output	\ read-write		\  : RESET_TIM10_CCMR1_Output $0000 
        \ %xxx  4 lshift TIM10_CCMR1_Output        \ TIM10_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM10_CCMR1_Output        \ TIM10_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM10_CCMR1_Output        \ TIM10_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM10_CCMR1_Output        \ TIM10_CC1S	Bit Offset:0	Bit Width:2
        
        TIM10 $18 + constant TIM10_CCMR1_Input	\ read-write		\  : RESET_TIM10_CCMR1_Input $00000000 
        \ %xxxx  4 lshift TIM10_CCMR1_Input        \ TIM10_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM10_CCMR1_Input        \ TIM10_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM10_CCMR1_Input        \ TIM10_CC1S	Bit Offset:0	Bit Width:2
        
        TIM10 $20 + constant TIM10_CCER	\ read-write		\  : RESET_TIM10_CCER $0000 
        \ %x  3 lshift TIM10_CCER        \ TIM10_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM10_CCER        \ TIM10_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_CCER        \ TIM10_CC1E	Bit Offset:0	Bit Width:1
        
        TIM10 $24 + constant TIM10_CNT	\ read-write		\  : RESET_TIM10_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM10_CNT        \ TIM10_CNT	Bit Offset:0	Bit Width:16
        
        TIM10 $28 + constant TIM10_PSC	\ read-write		\  : RESET_TIM10_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM10_PSC        \ TIM10_PSC	Bit Offset:0	Bit Width:16
        
        TIM10 $2C + constant TIM10_ARR	\ read-write		\  : RESET_TIM10_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM10_ARR        \ TIM10_ARR	Bit Offset:0	Bit Width:16
        
        TIM10 $34 + constant TIM10_CCR1	\ read-write		\  : RESET_TIM10_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM10_CCR1        \ TIM10_CCR1	Bit Offset:0	Bit Width:16
        
        TIM10 $50 + constant TIM10_OR	\ read-write		\  : RESET_TIM10_OR $0000 
        \ %xx  0 lshift TIM10_OR        \ TIM10_TI1_RMP	Bit Offset:0	Bit Width:2
        
         
	
     $40011000 constant TIM11  
	  
	
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
        \ %x  3 lshift TIM2_SMCR        \ TIM2_OCCS	Bit Offset:3	Bit Width:1
        \ %xxx  0 lshift TIM2_SMCR        \ TIM2_SMS	Bit Offset:0	Bit Width:3
        
        TIM2 $C + constant TIM2_DIER	\ write-only		\  : RESET_TIM2_DIER $0000 
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
        
        TIM2 $14 + constant TIM2_EGR	\ read-write		\  : RESET_TIM2_EGR $0000 
        \ %x  6 lshift TIM2_EGR        \ TIM2_TG	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM2_EGR        \ TIM2_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_EGR        \ TIM2_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_EGR        \ TIM2_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM2_EGR        \ TIM2_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_EGR        \ TIM2_UG	Bit Offset:0	Bit Width:1
        
        TIM2 $18 + constant TIM2_CCMR1_Output	\ read-write		\  : RESET_TIM2_CCMR1_Output $0000 
        \ %x  15 lshift TIM2_CCMR1_Output        \ TIM2_OC2CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM2_CCMR1_Output        \ TIM2_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM2_CCMR1_Output        \ TIM2_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_CCMR1_Output        \ TIM2_OC2FE	Bit Offset:10	Bit Width:1
        \ %x  8 lshift TIM2_CCMR1_Output        \ TIM2_CC2S	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM2_CCMR1_Output        \ TIM2_OC1CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM2_CCMR1_Output        \ TIM2_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM2_CCMR1_Output        \ TIM2_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM2_CCMR1_Output        \ TIM2_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM2_CCMR1_Output        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        
        TIM2 $18 + constant TIM2_CCMR1_Input	\ read-write		\  : RESET_TIM2_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM2_CCMR1_Input        \ TIM2_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM2_CCMR1_Input        \ TIM2_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM2_CCMR1_Input        \ TIM2_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM2_CCMR1_Input        \ TIM2_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM2_CCMR1_Input        \ TIM2_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM2_CCMR1_Input        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        
        TIM2 $1C + constant TIM2_CCMR2_Output	\ read-write		\  : RESET_TIM2_CCMR2_Output $0000 
        \ %x  15 lshift TIM2_CCMR2_Output        \ TIM2_OC4CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM2_CCMR2_Output        \ TIM2_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM2_CCMR2_Output        \ TIM2_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM2_CCMR2_Output        \ TIM2_OC4FE	Bit Offset:10	Bit Width:1
        \ %x  8 lshift TIM2_CCMR2_Output        \ TIM2_CC4S	Bit Offset:8	Bit Width:1
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
        \ %x  15 lshift TIM2_CCER        \ TIM2_CC4NP	Bit Offset:15	Bit Width:1
        \ %x  13 lshift TIM2_CCER        \ TIM2_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM2_CCER        \ TIM2_CC4E	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM2_CCER        \ TIM2_CC3NP	Bit Offset:11	Bit Width:1
        \ %x  9 lshift TIM2_CCER        \ TIM2_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM2_CCER        \ TIM2_CC3E	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM2_CCER        \ TIM2_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM2_CCER        \ TIM2_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM2_CCER        \ TIM2_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM2_CCER        \ TIM2_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM2_CCER        \ TIM2_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM2_CCER        \ TIM2_CC1E	Bit Offset:0	Bit Width:1
        
        TIM2 $24 + constant TIM2_CNT	\ read-write		\  : RESET_TIM2_CNT $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CNT        \ TIM2_CNT	Bit Offset:0	Bit Width:16
        
        TIM2 $28 + constant TIM2_PSC	\ read-write		\  : RESET_TIM2_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_PSC        \ TIM2_PSC	Bit Offset:0	Bit Width:16
        
        TIM2 $2C + constant TIM2_ARR	\ read-write		\  : RESET_TIM2_ARR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_ARR        \ TIM2_ARR	Bit Offset:0	Bit Width:16
        
        TIM2 $34 + constant TIM2_CCR1	\ read-write		\  : RESET_TIM2_CCR1 $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR1        \ TIM2_CCR1	Bit Offset:0	Bit Width:16
        
        TIM2 $38 + constant TIM2_CCR2	\ read-write		\  : RESET_TIM2_CCR2 $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR2        \ TIM2_CCR2	Bit Offset:0	Bit Width:16
        
        TIM2 $3C + constant TIM2_CCR3	\ read-write		\  : RESET_TIM2_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR3        \ TIM2_CCR1	Bit Offset:0	Bit Width:16
        
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
        
        TIM6 $24 + constant TIM6_CNT	\ read-write		\  : RESET_TIM6_CNT $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM6_CNT        \ TIM6_CNT	Bit Offset:0	Bit Width:16
        
        TIM6 $28 + constant TIM6_PSC	\ read-write		\  : RESET_TIM6_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM6_PSC        \ TIM6_PSC	Bit Offset:0	Bit Width:16
        
        TIM6 $2C + constant TIM6_ARR	\ read-write		\  : RESET_TIM6_ARR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM6_ARR        \ TIM6_ARR	Bit Offset:0	Bit Width:16
        
         
	
     $40001400 constant TIM7  
	  
	
     $40010800 constant TIM9  
	 TIM9 $0 + constant TIM9_CR1	\ read-write		\  : RESET_TIM9_CR1 $0000 
        \ %xx  8 lshift TIM9_CR1        \ TIM9_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM9_CR1        \ TIM9_ARPE	Bit Offset:7	Bit Width:1
        \ %x  3 lshift TIM9_CR1        \ TIM9_OMP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM9_CR1        \ TIM9_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM9_CR1        \ TIM9_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_CR1        \ TIM9_CEN	Bit Offset:0	Bit Width:1
        
        TIM9 $4 + constant TIM9_CR2	\ read-write		\  : RESET_TIM9_CR2 $0000 
        \ %xxx  4 lshift TIM9_CR2        \ TIM9_MMS	Bit Offset:4	Bit Width:3
        
        TIM9 $8 + constant TIM9_SMCR	\ read-write		\  : RESET_TIM9_SMCR $0000 
        \ %x  7 lshift TIM9_SMCR        \ TIM9_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM9_SMCR        \ TIM9_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM9_SMCR        \ TIM9_SMS	Bit Offset:0	Bit Width:3
        
        TIM9 $C + constant TIM9_DIER	\ write-only		\  : RESET_TIM9_DIER $0000 
        \ %x  6 lshift TIM9_DIER        \ TIM9_TIE	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM9_DIER        \ TIM9_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM9_DIER        \ TIM9_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_DIER        \ TIM9_UIE	Bit Offset:0	Bit Width:1
        
        TIM9 $10 + constant TIM9_SR	\ read-write		\  : RESET_TIM9_SR $0000 
        \ %x  10 lshift TIM9_SR        \ TIM9_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM9_SR        \ TIM9_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM9_SR        \ TIM9_TIF	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM9_SR        \ TIM9_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM9_SR        \ TIM9_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_SR        \ TIM9_UIF	Bit Offset:0	Bit Width:1
        
        TIM9 $14 + constant TIM9_EGR	\ read-write		\  : RESET_TIM9_EGR $0000 
        \ %x  6 lshift TIM9_EGR        \ TIM9_TG	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM9_EGR        \ TIM9_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM9_EGR        \ TIM9_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_EGR        \ TIM9_UG	Bit Offset:0	Bit Width:1
        
        TIM9 $18 + constant TIM9_CCMR1_Output	\ read-write		\  : RESET_TIM9_CCMR1_Output $0000 
        \ %x  15 lshift TIM9_CCMR1_Output        \ TIM9_OC2CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM9_CCMR1_Output        \ TIM9_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM9_CCMR1_Output        \ TIM9_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM9_CCMR1_Output        \ TIM9_OC2FE	Bit Offset:10	Bit Width:1
        \ %x  8 lshift TIM9_CCMR1_Output        \ TIM9_CC2S	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM9_CCMR1_Output        \ TIM9_OC1CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM9_CCMR1_Output        \ TIM9_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM9_CCMR1_Output        \ TIM9_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM9_CCMR1_Output        \ TIM9_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM9_CCMR1_Output        \ TIM9_CC1S	Bit Offset:0	Bit Width:2
        
        TIM9 $18 + constant TIM9_CCMR1_Input	\ read-write		\  : RESET_TIM9_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM9_CCMR1_Input        \ TIM9_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM9_CCMR1_Input        \ TIM9_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM9_CCMR1_Input        \ TIM9_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM9_CCMR1_Input        \ TIM9_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM9_CCMR1_Input        \ TIM9_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM9_CCMR1_Input        \ TIM9_CC1S	Bit Offset:0	Bit Width:2
        
        TIM9 $24 + constant TIM9_CNT	\ read-write		\  : RESET_TIM9_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM9_CNT        \ TIM9_CNT	Bit Offset:0	Bit Width:16
        
        TIM9 $28 + constant TIM9_PSC	\ read-write		\  : RESET_TIM9_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM9_PSC        \ TIM9_PSC	Bit Offset:0	Bit Width:16
        
        TIM9 $2C + constant TIM9_ARR	\ read-write		\  : RESET_TIM9_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM9_ARR        \ TIM9_ARR	Bit Offset:0	Bit Width:16
        
        TIM9 $34 + constant TIM9_CCR1	\ read-write		\  : RESET_TIM9_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM9_CCR1        \ TIM9_CCR1	Bit Offset:0	Bit Width:16
        
        TIM9 $38 + constant TIM9_CCR2	\ read-write		\  : RESET_TIM9_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM9_CCR2        \ TIM9_CCR2	Bit Offset:0	Bit Width:16
        
        TIM9 $50 + constant TIM9_OR	\ read-write		\  : RESET_TIM9_OR $0000 
        \ %xx  0 lshift TIM9_OR        \ TIM9_TI1_RMP	Bit Offset:0	Bit Width:2
        
         
	
     $40013800 constant USART1  
	 USART1 $0 + constant USART1_SR	\ 		\  : RESET_USART1_SR $00C00000 
        \ %x  9 lshift USART1_SR        \ USART1_CTS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_SR        \ USART1_LBD	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART1_SR        \ USART1_TXE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART1_SR        \ USART1_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_SR        \ USART1_RXNE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART1_SR        \ USART1_IDLE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_SR        \ USART1_ORE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_SR        \ USART1_NF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_SR        \ USART1_FE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_SR        \ USART1_PE	Bit Offset:0	Bit Width:1
        
        USART1 $4 + constant USART1_DR	\ read-write		\  : RESET_USART1_DR $00000000 
        \ %xxxxxxxxx  0 lshift USART1_DR        \ USART1_DR	Bit Offset:0	Bit Width:9
        
        USART1 $8 + constant USART1_BRR	\ read-write		\  : RESET_USART1_BRR $00000000 
        \ %xxxxxxxxxxxx  4 lshift USART1_BRR        \ USART1_DIV_Mantissa	Bit Offset:4	Bit Width:12
        \ %xxxx  0 lshift USART1_BRR        \ USART1_DIV_Fraction	Bit Offset:0	Bit Width:4
        
        USART1 $C + constant USART1_CR1	\ read-write		\  : RESET_USART1_CR1 $00000000 
        \ %x  15 lshift USART1_CR1        \ USART1_OVER8	Bit Offset:15	Bit Width:1
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
        
        USART1 $10 + constant USART1_CR2	\ read-write		\  : RESET_USART1_CR2 $00000000 
        \ %x  14 lshift USART1_CR2        \ USART1_LINEN	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USART1_CR2        \ USART1_STOP	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USART1_CR2        \ USART1_CLKEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART1_CR2        \ USART1_CPOL	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART1_CR2        \ USART1_CPHA	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_CR2        \ USART1_LBCL	Bit Offset:8	Bit Width:1
        \ %x  6 lshift USART1_CR2        \ USART1_LBDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_CR2        \ USART1_LBDL	Bit Offset:5	Bit Width:1
        \ %xxxx  0 lshift USART1_CR2        \ USART1_ADD	Bit Offset:0	Bit Width:4
        
        USART1 $14 + constant USART1_CR3	\ read-write		\  : RESET_USART1_CR3 $00000000 
        \ %x  11 lshift USART1_CR3        \ USART1_ONEBIT	Bit Offset:11	Bit Width:1
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
        
        USART1 $18 + constant USART1_GTPR	\ read-write		\  : RESET_USART1_GTPR $00000000 
        \ %xxxxxxxx  8 lshift USART1_GTPR        \ USART1_GT	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift USART1_GTPR        \ USART1_PSC	Bit Offset:0	Bit Width:8
        
         
	
     $40004400 constant USART2  
	  
	
     $40004800 constant USART3  
	  
	
     $40004C00 constant UART4  
	  
	
     $40005000 constant UART5  
	  
	
     $40005C00 constant USB  
	 USB $0 + constant USB_USB_EP0R	\ read-write		\  : RESET_USB_USB_EP0R $00000000 
        \ %xxxx  0 lshift USB_USB_EP0R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP0R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP0R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP0R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP0R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP0R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP0R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP0R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP0R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP0R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $4 + constant USB_USB_EP1R	\ read-write		\  : RESET_USB_USB_EP1R $00000000 
        \ %xxxx  0 lshift USB_USB_EP1R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP1R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP1R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP1R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP1R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP1R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP1R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP1R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP1R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP1R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $8 + constant USB_USB_EP2R	\ read-write		\  : RESET_USB_USB_EP2R $00000000 
        \ %xxxx  0 lshift USB_USB_EP2R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP2R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP2R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP2R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP2R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP2R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP2R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP2R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP2R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP2R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $C + constant USB_USB_EP3R	\ read-write		\  : RESET_USB_USB_EP3R $00000000 
        \ %xxxx  0 lshift USB_USB_EP3R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP3R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP3R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP3R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP3R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP3R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP3R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP3R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP3R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP3R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $10 + constant USB_USB_EP4R	\ read-write		\  : RESET_USB_USB_EP4R $00000000 
        \ %xxxx  0 lshift USB_USB_EP4R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP4R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP4R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP4R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP4R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP4R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP4R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP4R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP4R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP4R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $14 + constant USB_USB_EP5R	\ read-write		\  : RESET_USB_USB_EP5R $00000000 
        \ %xxxx  0 lshift USB_USB_EP5R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP5R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP5R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP5R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP5R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP5R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP5R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP5R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP5R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP5R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $18 + constant USB_USB_EP6R	\ read-write		\  : RESET_USB_USB_EP6R $00000000 
        \ %xxxx  0 lshift USB_USB_EP6R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP6R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP6R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP6R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP6R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP6R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP6R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP6R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP6R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP6R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $1C + constant USB_USB_EP7R	\ read-write		\  : RESET_USB_USB_EP7R $00000000 
        \ %xxxx  0 lshift USB_USB_EP7R        \ USB_EA	Bit Offset:0	Bit Width:4
        \ %xx  4 lshift USB_USB_EP7R        \ USB_STAT_TX	Bit Offset:4	Bit Width:2
        \ %x  6 lshift USB_USB_EP7R        \ USB_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %x  7 lshift USB_USB_EP7R        \ USB_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  8 lshift USB_USB_EP7R        \ USB_EP_KIND	Bit Offset:8	Bit Width:1
        \ %xx  9 lshift USB_USB_EP7R        \ USB_EP_TYPE	Bit Offset:9	Bit Width:2
        \ %x  11 lshift USB_USB_EP7R        \ USB_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  12 lshift USB_USB_EP7R        \ USB_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  14 lshift USB_USB_EP7R        \ USB_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_EP7R        \ USB_CTR_RX	Bit Offset:15	Bit Width:1
        
        USB $40 + constant USB_USB_CNTR	\ read-write		\  : RESET_USB_USB_CNTR $00000003 
        \ %x  0 lshift USB_USB_CNTR        \ USB_FRES	Bit Offset:0	Bit Width:1
        \ %x  1 lshift USB_USB_CNTR        \ USB_PDWN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift USB_USB_CNTR        \ USB_LPMODE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift USB_USB_CNTR        \ USB_FSUSP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift USB_USB_CNTR        \ USB_RESUME	Bit Offset:4	Bit Width:1
        \ %x  8 lshift USB_USB_CNTR        \ USB_ESOFM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_USB_CNTR        \ USB_SOFM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_USB_CNTR        \ USB_RESETM	Bit Offset:10	Bit Width:1
        \ %x  11 lshift USB_USB_CNTR        \ USB_SUSPM	Bit Offset:11	Bit Width:1
        \ %x  12 lshift USB_USB_CNTR        \ USB_WKUPM	Bit Offset:12	Bit Width:1
        \ %x  13 lshift USB_USB_CNTR        \ USB_ERRM	Bit Offset:13	Bit Width:1
        \ %x  14 lshift USB_USB_CNTR        \ USB_PMAOVRM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_USB_CNTR        \ USB_CTRM	Bit Offset:15	Bit Width:1
        
        USB $44 + constant USB_ISTR	\ read-write		\  : RESET_USB_ISTR $00000000 
        \ %xxxx  0 lshift USB_ISTR        \ USB_EP_ID	Bit Offset:0	Bit Width:4
        \ %x  4 lshift USB_ISTR        \ USB_DIR	Bit Offset:4	Bit Width:1
        \ %x  8 lshift USB_ISTR        \ USB_ESOF	Bit Offset:8	Bit Width:1
        \ %x  9 lshift USB_ISTR        \ USB_SOF	Bit Offset:9	Bit Width:1
        \ %x  10 lshift USB_ISTR        \ USB_RESET	Bit Offset:10	Bit Width:1
        \ %x  11 lshift USB_ISTR        \ USB_SUSP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift USB_ISTR        \ USB_WKUP	Bit Offset:12	Bit Width:1
        \ %x  13 lshift USB_ISTR        \ USB_ERR	Bit Offset:13	Bit Width:1
        \ %x  14 lshift USB_ISTR        \ USB_PMAOVR	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_ISTR        \ USB_CTR	Bit Offset:15	Bit Width:1
        
        USB $48 + constant USB_FNR	\ read-only		\  : RESET_USB_FNR $0000 
        \ % 0 lshift USB_FNR        \ USB_FN	Bit Offset:0	Bit Width:11
        \ %xx  11 lshift USB_FNR        \ USB_LSOF	Bit Offset:11	Bit Width:2
        \ %x  13 lshift USB_FNR        \ USB_LCK	Bit Offset:13	Bit Width:1
        \ %x  14 lshift USB_FNR        \ USB_RXDM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift USB_FNR        \ USB_RXDP	Bit Offset:15	Bit Width:1
        
        USB $4C + constant USB_DADDR	\ read-write		\  : RESET_USB_DADDR $0000 
        \ %xxxxxxx  0 lshift USB_DADDR        \ USB_ADD	Bit Offset:0	Bit Width:7
        \ %x  7 lshift USB_DADDR        \ USB_EF	Bit Offset:7	Bit Width:1
        
        USB $50 + constant USB_BTABLE	\ read-write		\  : RESET_USB_BTABLE $0000 
        \ % 3 lshift USB_BTABLE        \ USB_BTABLE	Bit Offset:3	Bit Width:13
        
         
	
     $40006000 constant USB_SRAM  
	  
	
     $40002C00 constant WWDG  
	 WWDG $0 + constant WWDG_CR	\ 		\  : RESET_WWDG_CR $0000007F 
        \ %x  7 lshift WWDG_CR        \ WWDG_WDGA	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift WWDG_CR        \ WWDG_T	Bit Offset:0	Bit Width:7
        
        WWDG $4 + constant WWDG_CFR	\ 		\  : RESET_WWDG_CFR $0000007F 
        \ %x  9 lshift WWDG_CFR        \ WWDG_EWI	Bit Offset:9	Bit Width:1
        \ %x  8 lshift WWDG_CFR        \ WWDG_WDGTB1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift WWDG_CFR        \ WWDG_WDGTB0	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift WWDG_CFR        \ WWDG_W	Bit Offset:0	Bit Width:7
        
        WWDG $8 + constant WWDG_SR	\ read-write		\  : RESET_WWDG_SR $00000000 
        \ %x  0 lshift WWDG_SR        \ WWDG_EWIF	Bit Offset:0	Bit Width:1
        
         
	
     $40012400 constant ADC  
	 ADC $0 + constant ADC_SR	\ 		\  : RESET_ADC_SR $00000000 
        \ %x  9 lshift ADC_SR        \ ADC_JCNR	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC_SR        \ ADC_RCNR	Bit Offset:8	Bit Width:1
        \ %x  6 lshift ADC_SR        \ ADC_ADONS	Bit Offset:6	Bit Width:1
        \ %x  5 lshift ADC_SR        \ ADC_OVR	Bit Offset:5	Bit Width:1
        \ %x  4 lshift ADC_SR        \ ADC_STRT	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC_SR        \ ADC_JSTRT	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC_SR        \ ADC_JEOC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC_SR        \ ADC_EOC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC_SR        \ ADC_AWD	Bit Offset:0	Bit Width:1
        
        ADC $4 + constant ADC_CR1	\ read-write		\  : RESET_ADC_CR1 $00000000 
        \ %x  26 lshift ADC_CR1        \ ADC_OVRIE	Bit Offset:26	Bit Width:1
        \ %xx  24 lshift ADC_CR1        \ ADC_RES	Bit Offset:24	Bit Width:2
        \ %x  23 lshift ADC_CR1        \ ADC_AWDEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift ADC_CR1        \ ADC_JAWDEN	Bit Offset:22	Bit Width:1
        \ %x  17 lshift ADC_CR1        \ ADC_PDI	Bit Offset:17	Bit Width:1
        \ %x  16 lshift ADC_CR1        \ ADC_PDD	Bit Offset:16	Bit Width:1
        \ %xxx  13 lshift ADC_CR1        \ ADC_DISCNUM	Bit Offset:13	Bit Width:3
        \ %x  12 lshift ADC_CR1        \ ADC_JDISCEN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift ADC_CR1        \ ADC_DISCEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift ADC_CR1        \ ADC_JAUTO	Bit Offset:10	Bit Width:1
        \ %x  9 lshift ADC_CR1        \ ADC_AWDSGL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC_CR1        \ ADC_SCAN	Bit Offset:8	Bit Width:1
        \ %x  7 lshift ADC_CR1        \ ADC_JEOCIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift ADC_CR1        \ ADC_AWDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift ADC_CR1        \ ADC_EOCIE	Bit Offset:5	Bit Width:1
        \ %xxxxx  0 lshift ADC_CR1        \ ADC_AWDCH	Bit Offset:0	Bit Width:5
        
        ADC $8 + constant ADC_CR2	\ read-write		\  : RESET_ADC_CR2 $00000000 
        \ %x  30 lshift ADC_CR2        \ ADC_SWSTART	Bit Offset:30	Bit Width:1
        \ %xx  28 lshift ADC_CR2        \ ADC_EXTEN	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift ADC_CR2        \ ADC_EXTSEL	Bit Offset:24	Bit Width:4
        \ %x  22 lshift ADC_CR2        \ ADC_JSWSTART	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift ADC_CR2        \ ADC_JEXTEN	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift ADC_CR2        \ ADC_JEXTSEL	Bit Offset:16	Bit Width:4
        \ %x  11 lshift ADC_CR2        \ ADC_ALIGN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift ADC_CR2        \ ADC_EOCS	Bit Offset:10	Bit Width:1
        \ %x  9 lshift ADC_CR2        \ ADC_DDS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC_CR2        \ ADC_DMA	Bit Offset:8	Bit Width:1
        \ %xxx  4 lshift ADC_CR2        \ ADC_DELS	Bit Offset:4	Bit Width:3
        \ %x  2 lshift ADC_CR2        \ ADC_ADC_CFG	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC_CR2        \ ADC_CONT	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC_CR2        \ ADC_ADON	Bit Offset:0	Bit Width:1
        
        ADC $C + constant ADC_SMPR1	\ read-write		\  : RESET_ADC_SMPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ADC_SMPR1        \ ADC_SampletimebitsSMPx_x	Bit Offset:0	Bit Width:32
        
        ADC $10 + constant ADC_SMPR2	\ read-write		\  : RESET_ADC_SMPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ADC_SMPR2        \ ADC_SampletimebitsSMPx_x	Bit Offset:0	Bit Width:32
        
        ADC $14 + constant ADC_SMPR3	\ read-write		\  : RESET_ADC_SMPR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ADC_SMPR3        \ ADC_SampletimebitsSMPx_x	Bit Offset:0	Bit Width:32
        
        ADC $18 + constant ADC_JOFR1	\ read-write		\  : RESET_ADC_JOFR1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC_JOFR1        \ ADC_JOFFSET1	Bit Offset:0	Bit Width:12
        
        ADC $1C + constant ADC_JOFR2	\ read-write		\  : RESET_ADC_JOFR2 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC_JOFR2        \ ADC_JOFFSET2	Bit Offset:0	Bit Width:12
        
        ADC $20 + constant ADC_JOFR3	\ read-write		\  : RESET_ADC_JOFR3 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC_JOFR3        \ ADC_JOFFSET3	Bit Offset:0	Bit Width:12
        
        ADC $24 + constant ADC_JOFR4	\ read-write		\  : RESET_ADC_JOFR4 $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC_JOFR4        \ ADC_JOFFSET4	Bit Offset:0	Bit Width:12
        
        ADC $28 + constant ADC_HTR	\ read-write		\  : RESET_ADC_HTR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift ADC_HTR        \ ADC_HT	Bit Offset:0	Bit Width:12
        
        ADC $2C + constant ADC_LTR	\ read-write		\  : RESET_ADC_LTR $00000000 
        \ %xxxxxxxxxxxx  0 lshift ADC_LTR        \ ADC_LT	Bit Offset:0	Bit Width:12
        
        ADC $30 + constant ADC_SQR1	\ read-write		\  : RESET_ADC_SQR1 $00000000 
        \ %xxxx  20 lshift ADC_SQR1        \ ADC_L	Bit Offset:20	Bit Width:4
        \ %xxxxx  15 lshift ADC_SQR1        \ ADC_SQ28	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC_SQR1        \ ADC_SQ27	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC_SQR1        \ ADC_SQ26	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC_SQR1        \ ADC_SQ25	Bit Offset:0	Bit Width:5
        
        ADC $34 + constant ADC_SQR2	\ read-write		\  : RESET_ADC_SQR2 $00000000 
        \ %xxxxx  25 lshift ADC_SQR2        \ ADC_SQ24	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC_SQR2        \ ADC_SQ23	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC_SQR2        \ ADC_SQ22	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC_SQR2        \ ADC_SQ21	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC_SQR2        \ ADC_SQ20	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC_SQR2        \ ADC_SQ19	Bit Offset:0	Bit Width:5
        
        ADC $38 + constant ADC_SQR3	\ read-write		\  : RESET_ADC_SQR3 $00000000 
        \ %xxxxx  25 lshift ADC_SQR3        \ ADC_SQ18	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC_SQR3        \ ADC_SQ17	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC_SQR3        \ ADC_SQ16	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC_SQR3        \ ADC_SQ15	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC_SQR3        \ ADC_SQ14	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC_SQR3        \ ADC_SQ13	Bit Offset:0	Bit Width:5
        
        ADC $3C + constant ADC_SQR4	\ read-write		\  : RESET_ADC_SQR4 $00000000 
        \ %xxxxx  25 lshift ADC_SQR4        \ ADC_SQ12	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC_SQR4        \ ADC_SQ11	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC_SQR4        \ ADC_SQ10	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC_SQR4        \ ADC_SQ9	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC_SQR4        \ ADC_SQ8	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC_SQR4        \ ADC_SQ7	Bit Offset:0	Bit Width:5
        
        ADC $40 + constant ADC_SQR5	\ read-write		\  : RESET_ADC_SQR5 $00000000 
        \ %xxxxx  25 lshift ADC_SQR5        \ ADC_SQ6	Bit Offset:25	Bit Width:5
        \ %xxxxx  20 lshift ADC_SQR5        \ ADC_SQ5	Bit Offset:20	Bit Width:5
        \ %xxxxx  15 lshift ADC_SQR5        \ ADC_SQ4	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC_SQR5        \ ADC_SQ3	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC_SQR5        \ ADC_SQ2	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC_SQR5        \ ADC_SQ1	Bit Offset:0	Bit Width:5
        
        ADC $44 + constant ADC_JSQR	\ read-write		\  : RESET_ADC_JSQR $00000000 
        \ %xx  20 lshift ADC_JSQR        \ ADC_JL	Bit Offset:20	Bit Width:2
        \ %xxxxx  15 lshift ADC_JSQR        \ ADC_JSQ4	Bit Offset:15	Bit Width:5
        \ %xxxxx  10 lshift ADC_JSQR        \ ADC_JSQ3	Bit Offset:10	Bit Width:5
        \ %xxxxx  5 lshift ADC_JSQR        \ ADC_JSQ2	Bit Offset:5	Bit Width:5
        \ %xxxxx  0 lshift ADC_JSQR        \ ADC_JSQ1	Bit Offset:0	Bit Width:5
        
        ADC $48 + constant ADC_JDR1	\ read-only		\  : RESET_ADC_JDR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_JDR1        \ ADC_JDATA	Bit Offset:0	Bit Width:16
        
        ADC $4C + constant ADC_JDR2	\ read-only		\  : RESET_ADC_JDR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_JDR2        \ ADC_JDATA	Bit Offset:0	Bit Width:16
        
        ADC $50 + constant ADC_JDR3	\ read-only		\  : RESET_ADC_JDR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_JDR3        \ ADC_JDATA	Bit Offset:0	Bit Width:16
        
        ADC $54 + constant ADC_JDR4	\ read-only		\  : RESET_ADC_JDR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_JDR4        \ ADC_JDATA	Bit Offset:0	Bit Width:16
        
        ADC $58 + constant ADC_DR	\ read-only		\  : RESET_ADC_DR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_DR        \ ADC_RegularDATA	Bit Offset:0	Bit Width:16
        
        ADC $5C + constant ADC_SMPR0	\ read-write		\  : RESET_ADC_SMPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ADC_SMPR0        \ ADC_SampletimebitsSMPx_x	Bit Offset:0	Bit Width:32
        
         
	
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
        
         
	
     