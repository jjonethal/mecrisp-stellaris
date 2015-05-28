\  STM32F427x ARM CMSIS-SVD register file for Mecrisp-Stellaris Forth by Matthias Koch
	\  x = 0 or 1 below in the Register Field bit positions 
	 

    $50060800 constant RNG  
	 RNG $0 + constant RNG_CR	\ read-write		\  : RESET_RNG_CR $00000000 
        \ %x  3 lshift RNG_CR        \ RNG_IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RNG_CR        \ RNG_RNGEN	Bit Offset:2	Bit Width:1
        
        RNG $4 + constant RNG_SR	\ 		\  : RESET_RNG_SR $00000000 
        \ %x  6 lshift RNG_SR        \ RNG_SEIS	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RNG_SR        \ RNG_CEIS	Bit Offset:5	Bit Width:1
        \ %x  2 lshift RNG_SR        \ RNG_SECS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RNG_SR        \ RNG_CECS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RNG_SR        \ RNG_DRDY	Bit Offset:0	Bit Width:1
        
        RNG $8 + constant RNG_DR	\ read-only		\  : RESET_RNG_DR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RNG_DR        \ RNG_RNDATA	Bit Offset:0	Bit Width:32
        
         
	
     $50050000 constant DCMI  
	 DCMI $0 + constant DCMI_CR	\ read-write		\  : RESET_DCMI_CR $0000 
        \ %x  14 lshift DCMI_CR        \ DCMI_ENABLE	Bit Offset:14	Bit Width:1
        \ %xx  10 lshift DCMI_CR        \ DCMI_EDM	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift DCMI_CR        \ DCMI_FCRC	Bit Offset:8	Bit Width:2
        \ %x  7 lshift DCMI_CR        \ DCMI_VSPOL	Bit Offset:7	Bit Width:1
        \ %x  6 lshift DCMI_CR        \ DCMI_HSPOL	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DCMI_CR        \ DCMI_PCKPOL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DCMI_CR        \ DCMI_ESS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DCMI_CR        \ DCMI_JPEG	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DCMI_CR        \ DCMI_CROP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DCMI_CR        \ DCMI_CM	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DCMI_CR        \ DCMI_CAPTURE	Bit Offset:0	Bit Width:1
        
        DCMI $4 + constant DCMI_SR	\ read-only		\  : RESET_DCMI_SR $0000 
        \ %x  2 lshift DCMI_SR        \ DCMI_FNE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DCMI_SR        \ DCMI_VSYNC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DCMI_SR        \ DCMI_HSYNC	Bit Offset:0	Bit Width:1
        
        DCMI $8 + constant DCMI_RIS	\ read-only		\  : RESET_DCMI_RIS $0000 
        \ %x  4 lshift DCMI_RIS        \ DCMI_LINE_RIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DCMI_RIS        \ DCMI_VSYNC_RIS	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DCMI_RIS        \ DCMI_ERR_RIS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DCMI_RIS        \ DCMI_OVR_RIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DCMI_RIS        \ DCMI_FRAME_RIS	Bit Offset:0	Bit Width:1
        
        DCMI $C + constant DCMI_IER	\ read-write		\  : RESET_DCMI_IER $0000 
        \ %x  4 lshift DCMI_IER        \ DCMI_LINE_IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DCMI_IER        \ DCMI_VSYNC_IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DCMI_IER        \ DCMI_ERR_IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DCMI_IER        \ DCMI_OVR_IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DCMI_IER        \ DCMI_FRAME_IE	Bit Offset:0	Bit Width:1
        
        DCMI $10 + constant DCMI_MIS	\ read-only		\  : RESET_DCMI_MIS $0000 
        \ %x  4 lshift DCMI_MIS        \ DCMI_LINE_MIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DCMI_MIS        \ DCMI_VSYNC_MIS	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DCMI_MIS        \ DCMI_ERR_MIS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DCMI_MIS        \ DCMI_OVR_MIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DCMI_MIS        \ DCMI_FRAME_MIS	Bit Offset:0	Bit Width:1
        
        DCMI $14 + constant DCMI_ICR	\ write-only		\  : RESET_DCMI_ICR $0000 
        \ %x  4 lshift DCMI_ICR        \ DCMI_LINE_ISC	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DCMI_ICR        \ DCMI_VSYNC_ISC	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DCMI_ICR        \ DCMI_ERR_ISC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DCMI_ICR        \ DCMI_OVR_ISC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DCMI_ICR        \ DCMI_FRAME_ISC	Bit Offset:0	Bit Width:1
        
        DCMI $18 + constant DCMI_ESCR	\ read-write		\  : RESET_DCMI_ESCR $0000 
        \ %xxxxxxxx  24 lshift DCMI_ESCR        \ DCMI_FEC	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift DCMI_ESCR        \ DCMI_LEC	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift DCMI_ESCR        \ DCMI_LSC	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift DCMI_ESCR        \ DCMI_FSC	Bit Offset:0	Bit Width:8
        
        DCMI $1C + constant DCMI_ESUR	\ read-write		\  : RESET_DCMI_ESUR $0000 
        \ %xxxxxxxx  24 lshift DCMI_ESUR        \ DCMI_FEU	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift DCMI_ESUR        \ DCMI_LEU	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift DCMI_ESUR        \ DCMI_LSU	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift DCMI_ESUR        \ DCMI_FSU	Bit Offset:0	Bit Width:8
        
        DCMI $20 + constant DCMI_CWSTRT	\ read-write		\  : RESET_DCMI_CWSTRT $0000 
        \ % 16 lshift DCMI_CWSTRT        \ DCMI_VST	Bit Offset:16	Bit Width:13
        \ %xxxxxxxxxxxxxx  0 lshift DCMI_CWSTRT        \ DCMI_HOFFCNT	Bit Offset:0	Bit Width:14
        
        DCMI $24 + constant DCMI_CWSIZE	\ read-write		\  : RESET_DCMI_CWSIZE $0000 
        \ %xxxxxxxxxxxxxx  16 lshift DCMI_CWSIZE        \ DCMI_VLINE	Bit Offset:16	Bit Width:14
        \ %xxxxxxxxxxxxxx  0 lshift DCMI_CWSIZE        \ DCMI_CAPCNT	Bit Offset:0	Bit Width:14
        
        DCMI $28 + constant DCMI_DR	\ read-only		\  : RESET_DCMI_DR $0000 
        \ %xxxxxxxx  24 lshift DCMI_DR        \ DCMI_Byte3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift DCMI_DR        \ DCMI_Byte2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift DCMI_DR        \ DCMI_Byte1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift DCMI_DR        \ DCMI_Byte0	Bit Offset:0	Bit Width:8
        
         
	
     $40026400 constant DMA2  
	 DMA2 $0 + constant DMA2_LISR	\ read-only		\  : RESET_DMA2_LISR $00000000 
        \ %x  27 lshift DMA2_LISR        \ DMA2_TCIF3	Bit Offset:27	Bit Width:1
        \ %x  26 lshift DMA2_LISR        \ DMA2_HTIF3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift DMA2_LISR        \ DMA2_TEIF3	Bit Offset:25	Bit Width:1
        \ %x  24 lshift DMA2_LISR        \ DMA2_DMEIF3	Bit Offset:24	Bit Width:1
        \ %x  22 lshift DMA2_LISR        \ DMA2_FEIF3	Bit Offset:22	Bit Width:1
        \ %x  21 lshift DMA2_LISR        \ DMA2_TCIF2	Bit Offset:21	Bit Width:1
        \ %x  20 lshift DMA2_LISR        \ DMA2_HTIF2	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_LISR        \ DMA2_TEIF2	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_LISR        \ DMA2_DMEIF2	Bit Offset:18	Bit Width:1
        \ %x  16 lshift DMA2_LISR        \ DMA2_FEIF2	Bit Offset:16	Bit Width:1
        \ %x  11 lshift DMA2_LISR        \ DMA2_TCIF1	Bit Offset:11	Bit Width:1
        \ %x  10 lshift DMA2_LISR        \ DMA2_HTIF1	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_LISR        \ DMA2_TEIF1	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_LISR        \ DMA2_DMEIF1	Bit Offset:8	Bit Width:1
        \ %x  6 lshift DMA2_LISR        \ DMA2_FEIF1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA2_LISR        \ DMA2_TCIF0	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_LISR        \ DMA2_HTIF0	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_LISR        \ DMA2_TEIF0	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_LISR        \ DMA2_DMEIF0	Bit Offset:2	Bit Width:1
        \ %x  0 lshift DMA2_LISR        \ DMA2_FEIF0	Bit Offset:0	Bit Width:1
        
        DMA2 $4 + constant DMA2_HISR	\ read-only		\  : RESET_DMA2_HISR $00000000 
        \ %x  27 lshift DMA2_HISR        \ DMA2_TCIF7	Bit Offset:27	Bit Width:1
        \ %x  26 lshift DMA2_HISR        \ DMA2_HTIF7	Bit Offset:26	Bit Width:1
        \ %x  25 lshift DMA2_HISR        \ DMA2_TEIF7	Bit Offset:25	Bit Width:1
        \ %x  24 lshift DMA2_HISR        \ DMA2_DMEIF7	Bit Offset:24	Bit Width:1
        \ %x  22 lshift DMA2_HISR        \ DMA2_FEIF7	Bit Offset:22	Bit Width:1
        \ %x  21 lshift DMA2_HISR        \ DMA2_TCIF6	Bit Offset:21	Bit Width:1
        \ %x  20 lshift DMA2_HISR        \ DMA2_HTIF6	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_HISR        \ DMA2_TEIF6	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_HISR        \ DMA2_DMEIF6	Bit Offset:18	Bit Width:1
        \ %x  16 lshift DMA2_HISR        \ DMA2_FEIF6	Bit Offset:16	Bit Width:1
        \ %x  11 lshift DMA2_HISR        \ DMA2_TCIF5	Bit Offset:11	Bit Width:1
        \ %x  10 lshift DMA2_HISR        \ DMA2_HTIF5	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_HISR        \ DMA2_TEIF5	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_HISR        \ DMA2_DMEIF5	Bit Offset:8	Bit Width:1
        \ %x  6 lshift DMA2_HISR        \ DMA2_FEIF5	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA2_HISR        \ DMA2_TCIF4	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_HISR        \ DMA2_HTIF4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_HISR        \ DMA2_TEIF4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_HISR        \ DMA2_DMEIF4	Bit Offset:2	Bit Width:1
        \ %x  0 lshift DMA2_HISR        \ DMA2_FEIF4	Bit Offset:0	Bit Width:1
        
        DMA2 $8 + constant DMA2_LIFCR	\ read-write		\  : RESET_DMA2_LIFCR $00000000 
        \ %x  27 lshift DMA2_LIFCR        \ DMA2_CTCIF3	Bit Offset:27	Bit Width:1
        \ %x  26 lshift DMA2_LIFCR        \ DMA2_CHTIF3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift DMA2_LIFCR        \ DMA2_CTEIF3	Bit Offset:25	Bit Width:1
        \ %x  24 lshift DMA2_LIFCR        \ DMA2_CDMEIF3	Bit Offset:24	Bit Width:1
        \ %x  22 lshift DMA2_LIFCR        \ DMA2_CFEIF3	Bit Offset:22	Bit Width:1
        \ %x  21 lshift DMA2_LIFCR        \ DMA2_CTCIF2	Bit Offset:21	Bit Width:1
        \ %x  20 lshift DMA2_LIFCR        \ DMA2_CHTIF2	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_LIFCR        \ DMA2_CTEIF2	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_LIFCR        \ DMA2_CDMEIF2	Bit Offset:18	Bit Width:1
        \ %x  16 lshift DMA2_LIFCR        \ DMA2_CFEIF2	Bit Offset:16	Bit Width:1
        \ %x  11 lshift DMA2_LIFCR        \ DMA2_CTCIF1	Bit Offset:11	Bit Width:1
        \ %x  10 lshift DMA2_LIFCR        \ DMA2_CHTIF1	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_LIFCR        \ DMA2_CTEIF1	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_LIFCR        \ DMA2_CDMEIF1	Bit Offset:8	Bit Width:1
        \ %x  6 lshift DMA2_LIFCR        \ DMA2_CFEIF1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA2_LIFCR        \ DMA2_CTCIF0	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_LIFCR        \ DMA2_CHTIF0	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_LIFCR        \ DMA2_CTEIF0	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_LIFCR        \ DMA2_CDMEIF0	Bit Offset:2	Bit Width:1
        \ %x  0 lshift DMA2_LIFCR        \ DMA2_CFEIF0	Bit Offset:0	Bit Width:1
        
        DMA2 $C + constant DMA2_HIFCR	\ read-write		\  : RESET_DMA2_HIFCR $00000000 
        \ %x  27 lshift DMA2_HIFCR        \ DMA2_CTCIF7	Bit Offset:27	Bit Width:1
        \ %x  26 lshift DMA2_HIFCR        \ DMA2_CHTIF7	Bit Offset:26	Bit Width:1
        \ %x  25 lshift DMA2_HIFCR        \ DMA2_CTEIF7	Bit Offset:25	Bit Width:1
        \ %x  24 lshift DMA2_HIFCR        \ DMA2_CDMEIF7	Bit Offset:24	Bit Width:1
        \ %x  22 lshift DMA2_HIFCR        \ DMA2_CFEIF7	Bit Offset:22	Bit Width:1
        \ %x  21 lshift DMA2_HIFCR        \ DMA2_CTCIF6	Bit Offset:21	Bit Width:1
        \ %x  20 lshift DMA2_HIFCR        \ DMA2_CHTIF6	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_HIFCR        \ DMA2_CTEIF6	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_HIFCR        \ DMA2_CDMEIF6	Bit Offset:18	Bit Width:1
        \ %x  16 lshift DMA2_HIFCR        \ DMA2_CFEIF6	Bit Offset:16	Bit Width:1
        \ %x  11 lshift DMA2_HIFCR        \ DMA2_CTCIF5	Bit Offset:11	Bit Width:1
        \ %x  10 lshift DMA2_HIFCR        \ DMA2_CHTIF5	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_HIFCR        \ DMA2_CTEIF5	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_HIFCR        \ DMA2_CDMEIF5	Bit Offset:8	Bit Width:1
        \ %x  6 lshift DMA2_HIFCR        \ DMA2_CFEIF5	Bit Offset:6	Bit Width:1
        \ %x  5 lshift DMA2_HIFCR        \ DMA2_CTCIF4	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_HIFCR        \ DMA2_CHTIF4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_HIFCR        \ DMA2_CTEIF4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_HIFCR        \ DMA2_CDMEIF4	Bit Offset:2	Bit Width:1
        \ %x  0 lshift DMA2_HIFCR        \ DMA2_CFEIF4	Bit Offset:0	Bit Width:1
        
        DMA2 $10 + constant DMA2_S0CR	\ read-write		\  : RESET_DMA2_S0CR $00000000 
        \ %xxx  25 lshift DMA2_S0CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S0CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S0CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  19 lshift DMA2_S0CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S0CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S0CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S0CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S0CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S0CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S0CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S0CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S0CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S0CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S0CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S0CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S0CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S0CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S0CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S0CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $14 + constant DMA2_S0NDTR	\ read-write		\  : RESET_DMA2_S0NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S0NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $18 + constant DMA2_S0PAR	\ read-write		\  : RESET_DMA2_S0PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S0PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $1C + constant DMA2_S0M0AR	\ read-write		\  : RESET_DMA2_S0M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S0M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $20 + constant DMA2_S0M1AR	\ read-write		\  : RESET_DMA2_S0M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S0M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $24 + constant DMA2_S0FCR	\ 		\  : RESET_DMA2_S0FCR $00000021 
        \ %x  7 lshift DMA2_S0FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S0FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S0FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S0FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $28 + constant DMA2_S1CR	\ read-write		\  : RESET_DMA2_S1CR $00000000 
        \ %xxx  25 lshift DMA2_S1CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S1CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S1CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S1CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S1CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S1CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S1CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S1CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S1CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S1CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S1CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S1CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S1CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S1CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S1CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S1CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S1CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S1CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S1CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S1CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $2C + constant DMA2_S1NDTR	\ read-write		\  : RESET_DMA2_S1NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S1NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $30 + constant DMA2_S1PAR	\ read-write		\  : RESET_DMA2_S1PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S1PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $34 + constant DMA2_S1M0AR	\ read-write		\  : RESET_DMA2_S1M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S1M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $38 + constant DMA2_S1M1AR	\ read-write		\  : RESET_DMA2_S1M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S1M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $3C + constant DMA2_S1FCR	\ 		\  : RESET_DMA2_S1FCR $00000021 
        \ %x  7 lshift DMA2_S1FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S1FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S1FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S1FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $40 + constant DMA2_S2CR	\ read-write		\  : RESET_DMA2_S2CR $00000000 
        \ %xxx  25 lshift DMA2_S2CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S2CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S2CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S2CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S2CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S2CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S2CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S2CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S2CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S2CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S2CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S2CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S2CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S2CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S2CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S2CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S2CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S2CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S2CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S2CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $44 + constant DMA2_S2NDTR	\ read-write		\  : RESET_DMA2_S2NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S2NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $48 + constant DMA2_S2PAR	\ read-write		\  : RESET_DMA2_S2PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S2PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $4C + constant DMA2_S2M0AR	\ read-write		\  : RESET_DMA2_S2M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S2M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $50 + constant DMA2_S2M1AR	\ read-write		\  : RESET_DMA2_S2M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S2M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $54 + constant DMA2_S2FCR	\ 		\  : RESET_DMA2_S2FCR $00000021 
        \ %x  7 lshift DMA2_S2FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S2FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S2FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S2FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $58 + constant DMA2_S3CR	\ read-write		\  : RESET_DMA2_S3CR $00000000 
        \ %xxx  25 lshift DMA2_S3CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S3CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S3CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S3CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S3CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S3CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S3CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S3CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S3CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S3CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S3CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S3CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S3CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S3CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S3CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S3CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S3CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S3CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S3CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S3CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $5C + constant DMA2_S3NDTR	\ read-write		\  : RESET_DMA2_S3NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S3NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $60 + constant DMA2_S3PAR	\ read-write		\  : RESET_DMA2_S3PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S3PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $64 + constant DMA2_S3M0AR	\ read-write		\  : RESET_DMA2_S3M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S3M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $68 + constant DMA2_S3M1AR	\ read-write		\  : RESET_DMA2_S3M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S3M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $6C + constant DMA2_S3FCR	\ 		\  : RESET_DMA2_S3FCR $00000021 
        \ %x  7 lshift DMA2_S3FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S3FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S3FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S3FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $70 + constant DMA2_S4CR	\ read-write		\  : RESET_DMA2_S4CR $00000000 
        \ %xxx  25 lshift DMA2_S4CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S4CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S4CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S4CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S4CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S4CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S4CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S4CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S4CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S4CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S4CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S4CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S4CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S4CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S4CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S4CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S4CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S4CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S4CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S4CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $74 + constant DMA2_S4NDTR	\ read-write		\  : RESET_DMA2_S4NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S4NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $78 + constant DMA2_S4PAR	\ read-write		\  : RESET_DMA2_S4PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S4PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $7C + constant DMA2_S4M0AR	\ read-write		\  : RESET_DMA2_S4M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S4M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $80 + constant DMA2_S4M1AR	\ read-write		\  : RESET_DMA2_S4M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S4M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $84 + constant DMA2_S4FCR	\ 		\  : RESET_DMA2_S4FCR $00000021 
        \ %x  7 lshift DMA2_S4FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S4FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S4FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S4FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $88 + constant DMA2_S5CR	\ read-write		\  : RESET_DMA2_S5CR $00000000 
        \ %xxx  25 lshift DMA2_S5CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S5CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S5CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S5CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S5CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S5CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S5CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S5CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S5CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S5CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S5CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S5CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S5CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S5CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S5CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S5CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S5CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S5CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S5CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S5CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $8C + constant DMA2_S5NDTR	\ read-write		\  : RESET_DMA2_S5NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S5NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $90 + constant DMA2_S5PAR	\ read-write		\  : RESET_DMA2_S5PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S5PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $94 + constant DMA2_S5M0AR	\ read-write		\  : RESET_DMA2_S5M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S5M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $98 + constant DMA2_S5M1AR	\ read-write		\  : RESET_DMA2_S5M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S5M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $9C + constant DMA2_S5FCR	\ 		\  : RESET_DMA2_S5FCR $00000021 
        \ %x  7 lshift DMA2_S5FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S5FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S5FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S5FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $A0 + constant DMA2_S6CR	\ read-write		\  : RESET_DMA2_S6CR $00000000 
        \ %xxx  25 lshift DMA2_S6CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S6CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S6CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S6CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S6CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S6CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S6CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S6CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S6CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S6CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S6CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S6CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S6CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S6CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S6CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S6CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S6CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S6CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S6CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S6CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $A4 + constant DMA2_S6NDTR	\ read-write		\  : RESET_DMA2_S6NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S6NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $A8 + constant DMA2_S6PAR	\ read-write		\  : RESET_DMA2_S6PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S6PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $AC + constant DMA2_S6M0AR	\ read-write		\  : RESET_DMA2_S6M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S6M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $B0 + constant DMA2_S6M1AR	\ read-write		\  : RESET_DMA2_S6M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S6M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $B4 + constant DMA2_S6FCR	\ 		\  : RESET_DMA2_S6FCR $00000021 
        \ %x  7 lshift DMA2_S6FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S6FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S6FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S6FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
        DMA2 $B8 + constant DMA2_S7CR	\ read-write		\  : RESET_DMA2_S7CR $00000000 
        \ %xxx  25 lshift DMA2_S7CR        \ DMA2_CHSEL	Bit Offset:25	Bit Width:3
        \ %xx  23 lshift DMA2_S7CR        \ DMA2_MBURST	Bit Offset:23	Bit Width:2
        \ %xx  21 lshift DMA2_S7CR        \ DMA2_PBURST	Bit Offset:21	Bit Width:2
        \ %x  20 lshift DMA2_S7CR        \ DMA2_ACK	Bit Offset:20	Bit Width:1
        \ %x  19 lshift DMA2_S7CR        \ DMA2_CT	Bit Offset:19	Bit Width:1
        \ %x  18 lshift DMA2_S7CR        \ DMA2_DBM	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift DMA2_S7CR        \ DMA2_PL	Bit Offset:16	Bit Width:2
        \ %x  15 lshift DMA2_S7CR        \ DMA2_PINCOS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift DMA2_S7CR        \ DMA2_MSIZE	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift DMA2_S7CR        \ DMA2_PSIZE	Bit Offset:11	Bit Width:2
        \ %x  10 lshift DMA2_S7CR        \ DMA2_MINC	Bit Offset:10	Bit Width:1
        \ %x  9 lshift DMA2_S7CR        \ DMA2_PINC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift DMA2_S7CR        \ DMA2_CIRC	Bit Offset:8	Bit Width:1
        \ %xx  6 lshift DMA2_S7CR        \ DMA2_DIR	Bit Offset:6	Bit Width:2
        \ %x  5 lshift DMA2_S7CR        \ DMA2_PFCTRL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift DMA2_S7CR        \ DMA2_TCIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift DMA2_S7CR        \ DMA2_HTIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift DMA2_S7CR        \ DMA2_TEIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DMA2_S7CR        \ DMA2_DMEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DMA2_S7CR        \ DMA2_EN	Bit Offset:0	Bit Width:1
        
        DMA2 $BC + constant DMA2_S7NDTR	\ read-write		\  : RESET_DMA2_S7NDTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift DMA2_S7NDTR        \ DMA2_NDT	Bit Offset:0	Bit Width:16
        
        DMA2 $C0 + constant DMA2_S7PAR	\ read-write		\  : RESET_DMA2_S7PAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S7PAR        \ DMA2_PA	Bit Offset:0	Bit Width:32
        
        DMA2 $C4 + constant DMA2_S7M0AR	\ read-write		\  : RESET_DMA2_S7M0AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S7M0AR        \ DMA2_M0A	Bit Offset:0	Bit Width:32
        
        DMA2 $C8 + constant DMA2_S7M1AR	\ read-write		\  : RESET_DMA2_S7M1AR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift DMA2_S7M1AR        \ DMA2_M1A	Bit Offset:0	Bit Width:32
        
        DMA2 $CC + constant DMA2_S7FCR	\ 		\  : RESET_DMA2_S7FCR $00000021 
        \ %x  7 lshift DMA2_S7FCR        \ DMA2_FEIE	Bit Offset:7	Bit Width:1
        \ %xxx  3 lshift DMA2_S7FCR        \ DMA2_FS	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DMA2_S7FCR        \ DMA2_DMDIS	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift DMA2_S7FCR        \ DMA2_FTH	Bit Offset:0	Bit Width:2
        
         
	
     $40026000 constant DMA1  
	  
	
     $40023800 constant RCC  
	 RCC $0 + constant RCC_CR	\ 		\  : RESET_RCC_CR $00000083 
        \ %x  27 lshift RCC_CR        \ RCC_PLLI2SRDY	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RCC_CR        \ RCC_PLLI2SON	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RCC_CR        \ RCC_PLLRDY	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_CR        \ RCC_PLLON	Bit Offset:24	Bit Width:1
        \ %x  19 lshift RCC_CR        \ RCC_CSSON	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_CR        \ RCC_HSEBYP	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_CR        \ RCC_HSERDY	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RCC_CR        \ RCC_HSEON	Bit Offset:16	Bit Width:1
        \ %xxxxxxxx  8 lshift RCC_CR        \ RCC_HSICAL	Bit Offset:8	Bit Width:8
        \ %xxxxx  3 lshift RCC_CR        \ RCC_HSITRIM	Bit Offset:3	Bit Width:5
        \ %x  1 lshift RCC_CR        \ RCC_HSIRDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CR        \ RCC_HSION	Bit Offset:0	Bit Width:1
        
        RCC $4 + constant RCC_PLLCFGR	\ read-write		\  : RESET_RCC_PLLCFGR $24003010 
        \ %x  27 lshift RCC_PLLCFGR        \ RCC_PLLQ3	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RCC_PLLCFGR        \ RCC_PLLQ2	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RCC_PLLCFGR        \ RCC_PLLQ1	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_PLLCFGR        \ RCC_PLLQ0	Bit Offset:24	Bit Width:1
        \ %x  22 lshift RCC_PLLCFGR        \ RCC_PLLSRC	Bit Offset:22	Bit Width:1
        \ %x  17 lshift RCC_PLLCFGR        \ RCC_PLLP1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RCC_PLLCFGR        \ RCC_PLLP0	Bit Offset:16	Bit Width:1
        \ %x  14 lshift RCC_PLLCFGR        \ RCC_PLLN8	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RCC_PLLCFGR        \ RCC_PLLN7	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RCC_PLLCFGR        \ RCC_PLLN6	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_PLLCFGR        \ RCC_PLLN5	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RCC_PLLCFGR        \ RCC_PLLN4	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RCC_PLLCFGR        \ RCC_PLLN3	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_PLLCFGR        \ RCC_PLLN2	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_PLLCFGR        \ RCC_PLLN1	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_PLLCFGR        \ RCC_PLLN0	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_PLLCFGR        \ RCC_PLLM5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_PLLCFGR        \ RCC_PLLM4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_PLLCFGR        \ RCC_PLLM3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_PLLCFGR        \ RCC_PLLM2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_PLLCFGR        \ RCC_PLLM1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_PLLCFGR        \ RCC_PLLM0	Bit Offset:0	Bit Width:1
        
        RCC $8 + constant RCC_CFGR	\ 		\  : RESET_RCC_CFGR $00000000 
        \ %xx  30 lshift RCC_CFGR        \ RCC_MCO2	Bit Offset:30	Bit Width:2
        \ %xxx  27 lshift RCC_CFGR        \ RCC_MCO2PRE	Bit Offset:27	Bit Width:3
        \ %xxx  24 lshift RCC_CFGR        \ RCC_MCO1PRE	Bit Offset:24	Bit Width:3
        \ %x  23 lshift RCC_CFGR        \ RCC_I2SSRC	Bit Offset:23	Bit Width:1
        \ %xx  21 lshift RCC_CFGR        \ RCC_MCO1	Bit Offset:21	Bit Width:2
        \ %xxxxx  16 lshift RCC_CFGR        \ RCC_RTCPRE	Bit Offset:16	Bit Width:5
        \ %xxx  13 lshift RCC_CFGR        \ RCC_PPRE2	Bit Offset:13	Bit Width:3
        \ %xxx  10 lshift RCC_CFGR        \ RCC_PPRE1	Bit Offset:10	Bit Width:3
        \ %xxxx  4 lshift RCC_CFGR        \ RCC_HPRE	Bit Offset:4	Bit Width:4
        \ %x  3 lshift RCC_CFGR        \ RCC_SWS1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CFGR        \ RCC_SWS0	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CFGR        \ RCC_SW1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CFGR        \ RCC_SW0	Bit Offset:0	Bit Width:1
        
        RCC $C + constant RCC_CIR	\ 		\  : RESET_RCC_CIR $00000000 
        \ %x  23 lshift RCC_CIR        \ RCC_CSSC	Bit Offset:23	Bit Width:1
        \ %x  21 lshift RCC_CIR        \ RCC_PLLI2SRDYC	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RCC_CIR        \ RCC_PLLRDYC	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RCC_CIR        \ RCC_HSERDYC	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_CIR        \ RCC_HSIRDYC	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_CIR        \ RCC_LSERDYC	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RCC_CIR        \ RCC_LSIRDYC	Bit Offset:16	Bit Width:1
        \ %x  13 lshift RCC_CIR        \ RCC_PLLI2SRDYIE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RCC_CIR        \ RCC_PLLRDYIE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_CIR        \ RCC_HSERDYIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RCC_CIR        \ RCC_HSIRDYIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RCC_CIR        \ RCC_LSERDYIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_CIR        \ RCC_LSIRDYIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_CIR        \ RCC_CSSF	Bit Offset:7	Bit Width:1
        \ %x  5 lshift RCC_CIR        \ RCC_PLLI2SRDYF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_CIR        \ RCC_PLLRDYF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_CIR        \ RCC_HSERDYF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CIR        \ RCC_HSIRDYF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CIR        \ RCC_LSERDYF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CIR        \ RCC_LSIRDYF	Bit Offset:0	Bit Width:1
        
        RCC $10 + constant RCC_AHB1RSTR	\ read-write		\  : RESET_RCC_AHB1RSTR $00000000 
        \ %x  29 lshift RCC_AHB1RSTR        \ RCC_OTGHSRST	Bit Offset:29	Bit Width:1
        \ %x  25 lshift RCC_AHB1RSTR        \ RCC_ETHMACRST	Bit Offset:25	Bit Width:1
        \ %x  22 lshift RCC_AHB1RSTR        \ RCC_DMA2RST	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_AHB1RSTR        \ RCC_DMA1RST	Bit Offset:21	Bit Width:1
        \ %x  12 lshift RCC_AHB1RSTR        \ RCC_CRCRST	Bit Offset:12	Bit Width:1
        \ %x  8 lshift RCC_AHB1RSTR        \ RCC_GPIOIRST	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_AHB1RSTR        \ RCC_GPIOHRST	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHB1RSTR        \ RCC_GPIOGRST	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_AHB1RSTR        \ RCC_GPIOFRST	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_AHB1RSTR        \ RCC_GPIOERST	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_AHB1RSTR        \ RCC_GPIODRST	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_AHB1RSTR        \ RCC_GPIOCRST	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_AHB1RSTR        \ RCC_GPIOBRST	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_AHB1RSTR        \ RCC_GPIOARST	Bit Offset:0	Bit Width:1
        
        RCC $14 + constant RCC_AHB2RSTR	\ read-write		\  : RESET_RCC_AHB2RSTR $00000000 
        \ %x  7 lshift RCC_AHB2RSTR        \ RCC_OTGFSRST	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHB2RSTR        \ RCC_RNGRST	Bit Offset:6	Bit Width:1
        \ %x  0 lshift RCC_AHB2RSTR        \ RCC_DCMIRST	Bit Offset:0	Bit Width:1
        
        RCC $18 + constant RCC_AHB3RSTR	\ read-write		\  : RESET_RCC_AHB3RSTR $00000000 
        \ %x  0 lshift RCC_AHB3RSTR        \ RCC_FMCRST	Bit Offset:0	Bit Width:1
        
        RCC $20 + constant RCC_APB1RSTR	\ read-write		\  : RESET_RCC_APB1RSTR $00000000 
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
        \ %x  17 lshift RCC_APB1RSTR        \ RCC_UART2RST	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB1RSTR        \ RCC_UART3RST	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_APB1RSTR        \ RCC_UART4RST	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_APB1RSTR        \ RCC_UART5RST	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB1RSTR        \ RCC_I2C1RST	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_APB1RSTR        \ RCC_I2C2RST	Bit Offset:22	Bit Width:1
        \ %x  23 lshift RCC_APB1RSTR        \ RCC_I2C3RST	Bit Offset:23	Bit Width:1
        \ %x  25 lshift RCC_APB1RSTR        \ RCC_CAN1RST	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_APB1RSTR        \ RCC_CAN2RST	Bit Offset:26	Bit Width:1
        \ %x  28 lshift RCC_APB1RSTR        \ RCC_PWRRST	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1RSTR        \ RCC_DACRST	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_APB1RSTR        \ RCC_UART7RST	Bit Offset:30	Bit Width:1
        \ %x  31 lshift RCC_APB1RSTR        \ RCC_UART8RST	Bit Offset:31	Bit Width:1
        
        RCC $24 + constant RCC_APB2RSTR	\ read-write		\  : RESET_RCC_APB2RSTR $00000000 
        \ %x  0 lshift RCC_APB2RSTR        \ RCC_TIM1RST	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB2RSTR        \ RCC_TIM8RST	Bit Offset:1	Bit Width:1
        \ %x  4 lshift RCC_APB2RSTR        \ RCC_USART1RST	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2RSTR        \ RCC_USART6RST	Bit Offset:5	Bit Width:1
        \ %x  8 lshift RCC_APB2RSTR        \ RCC_ADCRST	Bit Offset:8	Bit Width:1
        \ %x  11 lshift RCC_APB2RSTR        \ RCC_SDIORST	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2RSTR        \ RCC_SPI1RST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift RCC_APB2RSTR        \ RCC_SPI4RST	Bit Offset:13	Bit Width:1
        \ %x  14 lshift RCC_APB2RSTR        \ RCC_SYSCFGRST	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RCC_APB2RSTR        \ RCC_TIM9RST	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_APB2RSTR        \ RCC_TIM10RST	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB2RSTR        \ RCC_TIM11RST	Bit Offset:18	Bit Width:1
        \ %x  20 lshift RCC_APB2RSTR        \ RCC_SPI5RST	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB2RSTR        \ RCC_SPI6RST	Bit Offset:21	Bit Width:1
        
        RCC $30 + constant RCC_AHB1ENR	\ read-write		\  : RESET_RCC_AHB1ENR $00100000 
        \ %x  30 lshift RCC_AHB1ENR        \ RCC_OTGHSULPIEN	Bit Offset:30	Bit Width:1
        \ %x  29 lshift RCC_AHB1ENR        \ RCC_OTGHSEN	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_AHB1ENR        \ RCC_ETHMACPTPEN	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_AHB1ENR        \ RCC_ETHMACRXEN	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RCC_AHB1ENR        \ RCC_ETHMACTXEN	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RCC_AHB1ENR        \ RCC_ETHMACEN	Bit Offset:25	Bit Width:1
        \ %x  22 lshift RCC_AHB1ENR        \ RCC_DMA2EN	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_AHB1ENR        \ RCC_DMA1EN	Bit Offset:21	Bit Width:1
        \ %x  18 lshift RCC_AHB1ENR        \ RCC_BKPSRAMEN	Bit Offset:18	Bit Width:1
        \ %x  12 lshift RCC_AHB1ENR        \ RCC_CRCEN	Bit Offset:12	Bit Width:1
        \ %x  8 lshift RCC_AHB1ENR        \ RCC_GPIOIEN	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_AHB1ENR        \ RCC_GPIOHEN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHB1ENR        \ RCC_GPIOGEN	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_AHB1ENR        \ RCC_GPIOFEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_AHB1ENR        \ RCC_GPIOEEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_AHB1ENR        \ RCC_GPIODEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_AHB1ENR        \ RCC_GPIOCEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_AHB1ENR        \ RCC_GPIOBEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_AHB1ENR        \ RCC_GPIOAEN	Bit Offset:0	Bit Width:1
        
        RCC $34 + constant RCC_AHB2ENR	\ read-write		\  : RESET_RCC_AHB2ENR $00000000 
        \ %x  7 lshift RCC_AHB2ENR        \ RCC_OTGFSEN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHB2ENR        \ RCC_RNGEN	Bit Offset:6	Bit Width:1
        \ %x  0 lshift RCC_AHB2ENR        \ RCC_DCMIEN	Bit Offset:0	Bit Width:1
        
        RCC $38 + constant RCC_AHB3ENR	\ read-write		\  : RESET_RCC_AHB3ENR $00000000 
        \ %x  0 lshift RCC_AHB3ENR        \ RCC_FMCEN	Bit Offset:0	Bit Width:1
        
        RCC $40 + constant RCC_APB1ENR	\ read-write		\  : RESET_RCC_APB1ENR $00000000 
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
        \ %x  23 lshift RCC_APB1ENR        \ RCC_I2C3EN	Bit Offset:23	Bit Width:1
        \ %x  25 lshift RCC_APB1ENR        \ RCC_CAN1EN	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_APB1ENR        \ RCC_CAN2EN	Bit Offset:26	Bit Width:1
        \ %x  28 lshift RCC_APB1ENR        \ RCC_PWREN	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1ENR        \ RCC_DACEN	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_APB1ENR        \ RCC_UART7ENR	Bit Offset:30	Bit Width:1
        \ %x  31 lshift RCC_APB1ENR        \ RCC_UART8ENR	Bit Offset:31	Bit Width:1
        
        RCC $44 + constant RCC_APB2ENR	\ read-write		\  : RESET_RCC_APB2ENR $00000000 
        \ %x  0 lshift RCC_APB2ENR        \ RCC_TIM1EN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB2ENR        \ RCC_TIM8EN	Bit Offset:1	Bit Width:1
        \ %x  4 lshift RCC_APB2ENR        \ RCC_USART1EN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2ENR        \ RCC_USART6EN	Bit Offset:5	Bit Width:1
        \ %x  8 lshift RCC_APB2ENR        \ RCC_ADC1EN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RCC_APB2ENR        \ RCC_ADC2EN	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RCC_APB2ENR        \ RCC_ADC3EN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RCC_APB2ENR        \ RCC_SDIOEN	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2ENR        \ RCC_SPI1EN	Bit Offset:12	Bit Width:1
        \ %x  13 lshift RCC_APB2ENR        \ RCC_SPI4ENR	Bit Offset:13	Bit Width:1
        \ %x  14 lshift RCC_APB2ENR        \ RCC_SYSCFGEN	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RCC_APB2ENR        \ RCC_TIM9EN	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_APB2ENR        \ RCC_TIM10EN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB2ENR        \ RCC_TIM11EN	Bit Offset:18	Bit Width:1
        \ %x  20 lshift RCC_APB2ENR        \ RCC_SPI5ENR	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB2ENR        \ RCC_SPI6ENR	Bit Offset:21	Bit Width:1
        
        RCC $50 + constant RCC_AHB1LPENR	\ read-write		\  : RESET_RCC_AHB1LPENR $7E6791FF 
        \ %x  0 lshift RCC_AHB1LPENR        \ RCC_GPIOALPEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_AHB1LPENR        \ RCC_GPIOBLPEN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_AHB1LPENR        \ RCC_GPIOCLPEN	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_AHB1LPENR        \ RCC_GPIODLPEN	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_AHB1LPENR        \ RCC_GPIOELPEN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_AHB1LPENR        \ RCC_GPIOFLPEN	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_AHB1LPENR        \ RCC_GPIOGLPEN	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_AHB1LPENR        \ RCC_GPIOHLPEN	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_AHB1LPENR        \ RCC_GPIOILPEN	Bit Offset:8	Bit Width:1
        \ %x  12 lshift RCC_AHB1LPENR        \ RCC_CRCLPEN	Bit Offset:12	Bit Width:1
        \ %x  15 lshift RCC_AHB1LPENR        \ RCC_FLITFLPEN	Bit Offset:15	Bit Width:1
        \ %x  16 lshift RCC_AHB1LPENR        \ RCC_SRAM1LPEN	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_AHB1LPENR        \ RCC_SRAM2LPEN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_AHB1LPENR        \ RCC_BKPSRAMLPEN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_AHB1LPENR        \ RCC_SRAM3LPEN	Bit Offset:19	Bit Width:1
        \ %x  21 lshift RCC_AHB1LPENR        \ RCC_DMA1LPEN	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_AHB1LPENR        \ RCC_DMA2LPEN	Bit Offset:22	Bit Width:1
        \ %x  25 lshift RCC_AHB1LPENR        \ RCC_ETHMACLPEN	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_AHB1LPENR        \ RCC_ETHMACTXLPEN	Bit Offset:26	Bit Width:1
        \ %x  27 lshift RCC_AHB1LPENR        \ RCC_ETHMACRXLPEN	Bit Offset:27	Bit Width:1
        \ %x  28 lshift RCC_AHB1LPENR        \ RCC_ETHMACPTPLPEN	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_AHB1LPENR        \ RCC_OTGHSLPEN	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_AHB1LPENR        \ RCC_OTGHSULPILPEN	Bit Offset:30	Bit Width:1
        
        RCC $54 + constant RCC_AHB2LPENR	\ read-write		\  : RESET_RCC_AHB2LPENR $000000F1 
        \ %x  7 lshift RCC_AHB2LPENR        \ RCC_OTGFSLPEN	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_AHB2LPENR        \ RCC_RNGLPEN	Bit Offset:6	Bit Width:1
        \ %x  0 lshift RCC_AHB2LPENR        \ RCC_DCMILPEN	Bit Offset:0	Bit Width:1
        
        RCC $58 + constant RCC_AHB3LPENR	\ read-write		\  : RESET_RCC_AHB3LPENR $00000001 
        \ %x  0 lshift RCC_AHB3LPENR        \ RCC_FMCLPEN	Bit Offset:0	Bit Width:1
        
        RCC $60 + constant RCC_APB1LPENR	\ read-write		\  : RESET_RCC_APB1LPENR $36FEC9FF 
        \ %x  0 lshift RCC_APB1LPENR        \ RCC_TIM2LPEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB1LPENR        \ RCC_TIM3LPEN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RCC_APB1LPENR        \ RCC_TIM4LPEN	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RCC_APB1LPENR        \ RCC_TIM5LPEN	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RCC_APB1LPENR        \ RCC_TIM6LPEN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB1LPENR        \ RCC_TIM7LPEN	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RCC_APB1LPENR        \ RCC_TIM12LPEN	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RCC_APB1LPENR        \ RCC_TIM13LPEN	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RCC_APB1LPENR        \ RCC_TIM14LPEN	Bit Offset:8	Bit Width:1
        \ %x  11 lshift RCC_APB1LPENR        \ RCC_WWDGLPEN	Bit Offset:11	Bit Width:1
        \ %x  14 lshift RCC_APB1LPENR        \ RCC_SPI2LPEN	Bit Offset:14	Bit Width:1
        \ %x  15 lshift RCC_APB1LPENR        \ RCC_SPI3LPEN	Bit Offset:15	Bit Width:1
        \ %x  17 lshift RCC_APB1LPENR        \ RCC_USART2LPEN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB1LPENR        \ RCC_USART3LPEN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift RCC_APB1LPENR        \ RCC_UART4LPEN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift RCC_APB1LPENR        \ RCC_UART5LPEN	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB1LPENR        \ RCC_I2C1LPEN	Bit Offset:21	Bit Width:1
        \ %x  22 lshift RCC_APB1LPENR        \ RCC_I2C2LPEN	Bit Offset:22	Bit Width:1
        \ %x  23 lshift RCC_APB1LPENR        \ RCC_I2C3LPEN	Bit Offset:23	Bit Width:1
        \ %x  25 lshift RCC_APB1LPENR        \ RCC_CAN1LPEN	Bit Offset:25	Bit Width:1
        \ %x  26 lshift RCC_APB1LPENR        \ RCC_CAN2LPEN	Bit Offset:26	Bit Width:1
        \ %x  28 lshift RCC_APB1LPENR        \ RCC_PWRLPEN	Bit Offset:28	Bit Width:1
        \ %x  29 lshift RCC_APB1LPENR        \ RCC_DACLPEN	Bit Offset:29	Bit Width:1
        \ %x  30 lshift RCC_APB1LPENR        \ RCC_UART7LPEN	Bit Offset:30	Bit Width:1
        \ %x  31 lshift RCC_APB1LPENR        \ RCC_UART8LPEN	Bit Offset:31	Bit Width:1
        
        RCC $64 + constant RCC_APB2LPENR	\ read-write		\  : RESET_RCC_APB2LPENR $00075F33 
        \ %x  0 lshift RCC_APB2LPENR        \ RCC_TIM1LPEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RCC_APB2LPENR        \ RCC_TIM8LPEN	Bit Offset:1	Bit Width:1
        \ %x  4 lshift RCC_APB2LPENR        \ RCC_USART1LPEN	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RCC_APB2LPENR        \ RCC_USART6LPEN	Bit Offset:5	Bit Width:1
        \ %x  8 lshift RCC_APB2LPENR        \ RCC_ADC1LPEN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RCC_APB2LPENR        \ RCC_ADC2LPEN	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RCC_APB2LPENR        \ RCC_ADC3LPEN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RCC_APB2LPENR        \ RCC_SDIOLPEN	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RCC_APB2LPENR        \ RCC_SPI1LPEN	Bit Offset:12	Bit Width:1
        \ %x  13 lshift RCC_APB2LPENR        \ RCC_SPI4LPEN	Bit Offset:13	Bit Width:1
        \ %x  14 lshift RCC_APB2LPENR        \ RCC_SYSCFGLPEN	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RCC_APB2LPENR        \ RCC_TIM9LPEN	Bit Offset:16	Bit Width:1
        \ %x  17 lshift RCC_APB2LPENR        \ RCC_TIM10LPEN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift RCC_APB2LPENR        \ RCC_TIM11LPEN	Bit Offset:18	Bit Width:1
        \ %x  20 lshift RCC_APB2LPENR        \ RCC_SPI5LPEN	Bit Offset:20	Bit Width:1
        \ %x  21 lshift RCC_APB2LPENR        \ RCC_SPI6LPEN	Bit Offset:21	Bit Width:1
        
        RCC $70 + constant RCC_BDCR	\ 		\  : RESET_RCC_BDCR $00000000 
        \ %x  16 lshift RCC_BDCR        \ RCC_BDRST	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RCC_BDCR        \ RCC_RTCEN	Bit Offset:15	Bit Width:1
        \ %x  9 lshift RCC_BDCR        \ RCC_RTCSEL1	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_BDCR        \ RCC_RTCSEL0	Bit Offset:8	Bit Width:1
        \ %x  2 lshift RCC_BDCR        \ RCC_LSEBYP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_BDCR        \ RCC_LSERDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_BDCR        \ RCC_LSEON	Bit Offset:0	Bit Width:1
        
        RCC $74 + constant RCC_CSR	\ 		\  : RESET_RCC_CSR $0E000000 
        \ %x  31 lshift RCC_CSR        \ RCC_LPWRRSTF	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RCC_CSR        \ RCC_WWDGRSTF	Bit Offset:30	Bit Width:1
        \ %x  29 lshift RCC_CSR        \ RCC_WDGRSTF	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_CSR        \ RCC_SFTRSTF	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_CSR        \ RCC_PORRSTF	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RCC_CSR        \ RCC_PADRSTF	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RCC_CSR        \ RCC_BORRSTF	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_CSR        \ RCC_RMVF	Bit Offset:24	Bit Width:1
        \ %x  1 lshift RCC_CSR        \ RCC_LSIRDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CSR        \ RCC_LSION	Bit Offset:0	Bit Width:1
        
        RCC $80 + constant RCC_SSCGR	\ read-write		\  : RESET_RCC_SSCGR $00000000 
        \ %x  31 lshift RCC_SSCGR        \ RCC_SSCGEN	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RCC_SSCGR        \ RCC_SPREADSEL	Bit Offset:30	Bit Width:1
        \ %xxxxxxxxxxxxxxx  13 lshift RCC_SSCGR        \ RCC_INCSTEP	Bit Offset:13	Bit Width:15
        \ % 0 lshift RCC_SSCGR        \ RCC_MODPER	Bit Offset:0	Bit Width:13
        
        RCC $84 + constant RCC_PLLI2SCFGR	\ read-write		\  : RESET_RCC_PLLI2SCFGR $20003000 
        \ %xxx  28 lshift RCC_PLLI2SCFGR        \ RCC_PLLI2SRx	Bit Offset:28	Bit Width:3
        \ %xxxxxxxxx  6 lshift RCC_PLLI2SCFGR        \ RCC_PLLI2SNx	Bit Offset:6	Bit Width:9
        
         
	
     $40022000 constant GPIOI  
	 GPIOI $0 + constant GPIOI_MODER	\ read-write		\  : RESET_GPIOI_MODER $00000000 
        \ %xx  30 lshift GPIOI_MODER        \ GPIOI_MODER15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOI_MODER        \ GPIOI_MODER14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOI_MODER        \ GPIOI_MODER13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOI_MODER        \ GPIOI_MODER12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOI_MODER        \ GPIOI_MODER11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOI_MODER        \ GPIOI_MODER10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOI_MODER        \ GPIOI_MODER9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOI_MODER        \ GPIOI_MODER8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOI_MODER        \ GPIOI_MODER7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOI_MODER        \ GPIOI_MODER6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOI_MODER        \ GPIOI_MODER5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOI_MODER        \ GPIOI_MODER4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOI_MODER        \ GPIOI_MODER3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOI_MODER        \ GPIOI_MODER2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOI_MODER        \ GPIOI_MODER1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOI_MODER        \ GPIOI_MODER0	Bit Offset:0	Bit Width:2
        
        GPIOI $4 + constant GPIOI_OTYPER	\ read-write		\  : RESET_GPIOI_OTYPER $00000000 
        \ %x  15 lshift GPIOI_OTYPER        \ GPIOI_OT15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOI_OTYPER        \ GPIOI_OT14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOI_OTYPER        \ GPIOI_OT13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOI_OTYPER        \ GPIOI_OT12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOI_OTYPER        \ GPIOI_OT11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOI_OTYPER        \ GPIOI_OT10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOI_OTYPER        \ GPIOI_OT9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOI_OTYPER        \ GPIOI_OT8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOI_OTYPER        \ GPIOI_OT7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOI_OTYPER        \ GPIOI_OT6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOI_OTYPER        \ GPIOI_OT5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOI_OTYPER        \ GPIOI_OT4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOI_OTYPER        \ GPIOI_OT3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOI_OTYPER        \ GPIOI_OT2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOI_OTYPER        \ GPIOI_OT1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOI_OTYPER        \ GPIOI_OT0	Bit Offset:0	Bit Width:1
        
        GPIOI $8 + constant GPIOI_OSPEEDR	\ read-write		\  : RESET_GPIOI_OSPEEDR $00000000 
        \ %xx  30 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOI_OSPEEDR        \ GPIOI_OSPEEDR0	Bit Offset:0	Bit Width:2
        
        GPIOI $C + constant GPIOI_PUPDR	\ read-write		\  : RESET_GPIOI_PUPDR $00000000 
        \ %xx  30 lshift GPIOI_PUPDR        \ GPIOI_PUPDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOI_PUPDR        \ GPIOI_PUPDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOI_PUPDR        \ GPIOI_PUPDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOI_PUPDR        \ GPIOI_PUPDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOI_PUPDR        \ GPIOI_PUPDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOI_PUPDR        \ GPIOI_PUPDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOI_PUPDR        \ GPIOI_PUPDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOI_PUPDR        \ GPIOI_PUPDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOI_PUPDR        \ GPIOI_PUPDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOI_PUPDR        \ GPIOI_PUPDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOI_PUPDR        \ GPIOI_PUPDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOI_PUPDR        \ GPIOI_PUPDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOI_PUPDR        \ GPIOI_PUPDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOI_PUPDR        \ GPIOI_PUPDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOI_PUPDR        \ GPIOI_PUPDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOI_PUPDR        \ GPIOI_PUPDR0	Bit Offset:0	Bit Width:2
        
        GPIOI $10 + constant GPIOI_IDR	\ read-only		\  : RESET_GPIOI_IDR $00000000 
        \ %x  15 lshift GPIOI_IDR        \ GPIOI_IDR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOI_IDR        \ GPIOI_IDR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOI_IDR        \ GPIOI_IDR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOI_IDR        \ GPIOI_IDR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOI_IDR        \ GPIOI_IDR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOI_IDR        \ GPIOI_IDR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOI_IDR        \ GPIOI_IDR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOI_IDR        \ GPIOI_IDR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOI_IDR        \ GPIOI_IDR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOI_IDR        \ GPIOI_IDR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOI_IDR        \ GPIOI_IDR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOI_IDR        \ GPIOI_IDR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOI_IDR        \ GPIOI_IDR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOI_IDR        \ GPIOI_IDR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOI_IDR        \ GPIOI_IDR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOI_IDR        \ GPIOI_IDR0	Bit Offset:0	Bit Width:1
        
        GPIOI $14 + constant GPIOI_ODR	\ read-write		\  : RESET_GPIOI_ODR $00000000 
        \ %x  15 lshift GPIOI_ODR        \ GPIOI_ODR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOI_ODR        \ GPIOI_ODR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOI_ODR        \ GPIOI_ODR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOI_ODR        \ GPIOI_ODR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOI_ODR        \ GPIOI_ODR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOI_ODR        \ GPIOI_ODR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOI_ODR        \ GPIOI_ODR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOI_ODR        \ GPIOI_ODR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOI_ODR        \ GPIOI_ODR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOI_ODR        \ GPIOI_ODR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOI_ODR        \ GPIOI_ODR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOI_ODR        \ GPIOI_ODR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOI_ODR        \ GPIOI_ODR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOI_ODR        \ GPIOI_ODR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOI_ODR        \ GPIOI_ODR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOI_ODR        \ GPIOI_ODR0	Bit Offset:0	Bit Width:1
        
        GPIOI $18 + constant GPIOI_BSRR	\ write-only		\  : RESET_GPIOI_BSRR $00000000 
        \ %x  31 lshift GPIOI_BSRR        \ GPIOI_BR15	Bit Offset:31	Bit Width:1
        \ %x  30 lshift GPIOI_BSRR        \ GPIOI_BR14	Bit Offset:30	Bit Width:1
        \ %x  29 lshift GPIOI_BSRR        \ GPIOI_BR13	Bit Offset:29	Bit Width:1
        \ %x  28 lshift GPIOI_BSRR        \ GPIOI_BR12	Bit Offset:28	Bit Width:1
        \ %x  27 lshift GPIOI_BSRR        \ GPIOI_BR11	Bit Offset:27	Bit Width:1
        \ %x  26 lshift GPIOI_BSRR        \ GPIOI_BR10	Bit Offset:26	Bit Width:1
        \ %x  25 lshift GPIOI_BSRR        \ GPIOI_BR9	Bit Offset:25	Bit Width:1
        \ %x  24 lshift GPIOI_BSRR        \ GPIOI_BR8	Bit Offset:24	Bit Width:1
        \ %x  23 lshift GPIOI_BSRR        \ GPIOI_BR7	Bit Offset:23	Bit Width:1
        \ %x  22 lshift GPIOI_BSRR        \ GPIOI_BR6	Bit Offset:22	Bit Width:1
        \ %x  21 lshift GPIOI_BSRR        \ GPIOI_BR5	Bit Offset:21	Bit Width:1
        \ %x  20 lshift GPIOI_BSRR        \ GPIOI_BR4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift GPIOI_BSRR        \ GPIOI_BR3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift GPIOI_BSRR        \ GPIOI_BR2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift GPIOI_BSRR        \ GPIOI_BR1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift GPIOI_BSRR        \ GPIOI_BR0	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOI_BSRR        \ GPIOI_BS15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOI_BSRR        \ GPIOI_BS14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOI_BSRR        \ GPIOI_BS13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOI_BSRR        \ GPIOI_BS12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOI_BSRR        \ GPIOI_BS11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOI_BSRR        \ GPIOI_BS10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOI_BSRR        \ GPIOI_BS9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOI_BSRR        \ GPIOI_BS8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOI_BSRR        \ GPIOI_BS7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOI_BSRR        \ GPIOI_BS6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOI_BSRR        \ GPIOI_BS5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOI_BSRR        \ GPIOI_BS4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOI_BSRR        \ GPIOI_BS3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOI_BSRR        \ GPIOI_BS2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOI_BSRR        \ GPIOI_BS1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOI_BSRR        \ GPIOI_BS0	Bit Offset:0	Bit Width:1
        
        GPIOI $1C + constant GPIOI_LCKR	\ read-write		\  : RESET_GPIOI_LCKR $00000000 
        \ %x  16 lshift GPIOI_LCKR        \ GPIOI_LCKK	Bit Offset:16	Bit Width:1
        \ %x  15 lshift GPIOI_LCKR        \ GPIOI_LCK15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOI_LCKR        \ GPIOI_LCK14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOI_LCKR        \ GPIOI_LCK13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOI_LCKR        \ GPIOI_LCK12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOI_LCKR        \ GPIOI_LCK11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOI_LCKR        \ GPIOI_LCK10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOI_LCKR        \ GPIOI_LCK9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOI_LCKR        \ GPIOI_LCK8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOI_LCKR        \ GPIOI_LCK7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOI_LCKR        \ GPIOI_LCK6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOI_LCKR        \ GPIOI_LCK5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOI_LCKR        \ GPIOI_LCK4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOI_LCKR        \ GPIOI_LCK3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOI_LCKR        \ GPIOI_LCK2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOI_LCKR        \ GPIOI_LCK1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOI_LCKR        \ GPIOI_LCK0	Bit Offset:0	Bit Width:1
        
        GPIOI $20 + constant GPIOI_AFRL	\ read-write		\  : RESET_GPIOI_AFRL $00000000 
        \ %xxxx  28 lshift GPIOI_AFRL        \ GPIOI_AFRL7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOI_AFRL        \ GPIOI_AFRL6	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOI_AFRL        \ GPIOI_AFRL5	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOI_AFRL        \ GPIOI_AFRL4	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOI_AFRL        \ GPIOI_AFRL3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOI_AFRL        \ GPIOI_AFRL2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOI_AFRL        \ GPIOI_AFRL1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOI_AFRL        \ GPIOI_AFRL0	Bit Offset:0	Bit Width:4
        
        GPIOI $24 + constant GPIOI_AFRH	\ read-write		\  : RESET_GPIOI_AFRH $00000000 
        \ %xxxx  28 lshift GPIOI_AFRH        \ GPIOI_AFRH15	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOI_AFRH        \ GPIOI_AFRH14	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOI_AFRH        \ GPIOI_AFRH13	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOI_AFRH        \ GPIOI_AFRH12	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOI_AFRH        \ GPIOI_AFRH11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOI_AFRH        \ GPIOI_AFRH10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOI_AFRH        \ GPIOI_AFRH9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOI_AFRH        \ GPIOI_AFRH8	Bit Offset:0	Bit Width:4
        
         
	
     $40021C00 constant GPIOH  
	  
	
     $40021800 constant GPIOG  
	  
	
     $40021400 constant GPIOF  
	  
	
     $40021000 constant GPIOE  
	  
	
     $40020C00 constant GPIOD  
	  
	
     $40020800 constant GPIOC  
	  
	
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
        
        GPIOB $8 + constant GPIOB_OSPEEDR	\ read-write		\  : RESET_GPIOB_OSPEEDR $000000C0 
        \ %xx  30 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEEDR0	Bit Offset:0	Bit Width:2
        
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
        
        GPIOA $8 + constant GPIOA_OSPEEDR	\ read-write		\  : RESET_GPIOA_OSPEEDR $00000000 
        \ %xx  30 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEEDR0	Bit Offset:0	Bit Width:2
        
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
        
         
	
     $40013800 constant SYSCFG  
	 SYSCFG $0 + constant SYSCFG_MEMRM	\ read-write		\  : RESET_SYSCFG_MEMRM $00000000 
        \ %xx  0 lshift SYSCFG_MEMRM        \ SYSCFG_MEM_MODE	Bit Offset:0	Bit Width:2
        
        SYSCFG $4 + constant SYSCFG_PMC	\ read-write		\  : RESET_SYSCFG_PMC $00000000 
        \ %x  23 lshift SYSCFG_PMC        \ SYSCFG_MII_RMII_SEL	Bit Offset:23	Bit Width:1
        \ %x  16 lshift SYSCFG_PMC        \ SYSCFG_ADC1DC2	Bit Offset:16	Bit Width:1
        \ %x  17 lshift SYSCFG_PMC        \ SYSCFG_ADC2DC2	Bit Offset:17	Bit Width:1
        \ %x  18 lshift SYSCFG_PMC        \ SYSCFG_ADC3DC2	Bit Offset:18	Bit Width:1
        
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
        
        SYSCFG $20 + constant SYSCFG_CMPCR	\ read-only		\  : RESET_SYSCFG_CMPCR $00000000 
        \ %x  8 lshift SYSCFG_CMPCR        \ SYSCFG_READY	Bit Offset:8	Bit Width:1
        \ %x  0 lshift SYSCFG_CMPCR        \ SYSCFG_CMP_PD	Bit Offset:0	Bit Width:1
        
         
	
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
        
        SPI1 $20 + constant SPI1_I2SPR	\ read-write		\  : RESET_SPI1_I2SPR 00000010 
        \ %x  9 lshift SPI1_I2SPR        \ SPI1_MCKOE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SPI1_I2SPR        \ SPI1_ODD	Bit Offset:8	Bit Width:1
        \ %xxxxxxxx  0 lshift SPI1_I2SPR        \ SPI1_I2SDIV	Bit Offset:0	Bit Width:8
        
         
	
     $40003800 constant SPI2  
	  
	
     $40003C00 constant SPI3  
	  
	
     $40003400 constant I2S2ext  
	  
	
     $40004000 constant I2S3ext  
	  
	
     $40013400 constant SPI4  
	  
	
     $40015000 constant SPI5  
	  
	
     $40015400 constant SPI6  
	  
	
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
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift SDIO_FIFO        \ SDIO_FIFOData	Bit Offset:0	Bit Width:32
        
         
	
     $40012000 constant ADC1  
	 ADC1 $0 + constant ADC1_SR	\ read-write		\  : RESET_ADC1_SR $00000000 
        \ %x  5 lshift ADC1_SR        \ ADC1_OVR	Bit Offset:5	Bit Width:1
        \ %x  4 lshift ADC1_SR        \ ADC1_STRT	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC1_SR        \ ADC1_JSTRT	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC1_SR        \ ADC1_JEOC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC1_SR        \ ADC1_EOC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC1_SR        \ ADC1_AWD	Bit Offset:0	Bit Width:1
        
        ADC1 $4 + constant ADC1_CR1	\ read-write		\  : RESET_ADC1_CR1 $00000000 
        \ %x  26 lshift ADC1_CR1        \ ADC1_OVRIE	Bit Offset:26	Bit Width:1
        \ %xx  24 lshift ADC1_CR1        \ ADC1_RES	Bit Offset:24	Bit Width:2
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
        \ %x  30 lshift ADC1_CR2        \ ADC1_SWSTART	Bit Offset:30	Bit Width:1
        \ %xx  28 lshift ADC1_CR2        \ ADC1_EXTEN	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift ADC1_CR2        \ ADC1_EXTSEL	Bit Offset:24	Bit Width:4
        \ %x  22 lshift ADC1_CR2        \ ADC1_JSWSTART	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift ADC1_CR2        \ ADC1_JEXTEN	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift ADC1_CR2        \ ADC1_JEXTSEL	Bit Offset:16	Bit Width:4
        \ %x  11 lshift ADC1_CR2        \ ADC1_ALIGN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift ADC1_CR2        \ ADC1_EOCS	Bit Offset:10	Bit Width:1
        \ %x  9 lshift ADC1_CR2        \ ADC1_DDS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC1_CR2        \ ADC1_DMA	Bit Offset:8	Bit Width:1
        \ %x  1 lshift ADC1_CR2        \ ADC1_CONT	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC1_CR2        \ ADC1_ADON	Bit Offset:0	Bit Width:1
        
        ADC1 $C + constant ADC1_SMPR1	\ read-write		\  : RESET_ADC1_SMPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ADC1_SMPR1        \ ADC1_SMPx_x	Bit Offset:0	Bit Width:32
        
        ADC1 $10 + constant ADC1_SMPR2	\ read-write		\  : RESET_ADC1_SMPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift ADC1_SMPR2        \ ADC1_SMPx_x	Bit Offset:0	Bit Width:32
        
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
        
         
	
     $40012100 constant ADC2  
	  
	
     $40012200 constant ADC3  
	  
	
     $40011400 constant USART6  
	 USART6 $0 + constant USART6_SR	\ 		\  : RESET_USART6_SR $00C00000 
        \ %x  9 lshift USART6_SR        \ USART6_CTS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART6_SR        \ USART6_LBD	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART6_SR        \ USART6_TXE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART6_SR        \ USART6_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART6_SR        \ USART6_RXNE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART6_SR        \ USART6_IDLE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART6_SR        \ USART6_ORE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART6_SR        \ USART6_NF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART6_SR        \ USART6_FE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART6_SR        \ USART6_PE	Bit Offset:0	Bit Width:1
        
        USART6 $4 + constant USART6_DR	\ read-write		\  : RESET_USART6_DR $00000000 
        \ %xxxxxxxxx  0 lshift USART6_DR        \ USART6_DR	Bit Offset:0	Bit Width:9
        
        USART6 $8 + constant USART6_BRR	\ read-write		\  : RESET_USART6_BRR $0000 
        \ %xxxxxxxxxxxx  4 lshift USART6_BRR        \ USART6_DIV_Mantissa	Bit Offset:4	Bit Width:12
        \ %xxxx  0 lshift USART6_BRR        \ USART6_DIV_Fraction	Bit Offset:0	Bit Width:4
        
        USART6 $C + constant USART6_CR1	\ read-write		\  : RESET_USART6_CR1 $0000 
        \ %x  15 lshift USART6_CR1        \ USART6_OVER8	Bit Offset:15	Bit Width:1
        \ %x  13 lshift USART6_CR1        \ USART6_UE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift USART6_CR1        \ USART6_M	Bit Offset:12	Bit Width:1
        \ %x  11 lshift USART6_CR1        \ USART6_WAKE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART6_CR1        \ USART6_PCE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART6_CR1        \ USART6_PS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART6_CR1        \ USART6_PEIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART6_CR1        \ USART6_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART6_CR1        \ USART6_TCIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART6_CR1        \ USART6_RXNEIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART6_CR1        \ USART6_IDLEIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART6_CR1        \ USART6_TE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART6_CR1        \ USART6_RE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART6_CR1        \ USART6_RWU	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART6_CR1        \ USART6_SBK	Bit Offset:0	Bit Width:1
        
        USART6 $10 + constant USART6_CR2	\ read-write		\  : RESET_USART6_CR2 $0000 
        \ %x  14 lshift USART6_CR2        \ USART6_LINEN	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USART6_CR2        \ USART6_STOP	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USART6_CR2        \ USART6_CLKEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART6_CR2        \ USART6_CPOL	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART6_CR2        \ USART6_CPHA	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART6_CR2        \ USART6_LBCL	Bit Offset:8	Bit Width:1
        \ %x  6 lshift USART6_CR2        \ USART6_LBDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART6_CR2        \ USART6_LBDL	Bit Offset:5	Bit Width:1
        \ %xxxx  0 lshift USART6_CR2        \ USART6_ADD	Bit Offset:0	Bit Width:4
        
        USART6 $14 + constant USART6_CR3	\ read-write		\  : RESET_USART6_CR3 $0000 
        \ %x  11 lshift USART6_CR3        \ USART6_ONEBIT	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART6_CR3        \ USART6_CTSIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART6_CR3        \ USART6_CTSE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART6_CR3        \ USART6_RTSE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART6_CR3        \ USART6_DMAT	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART6_CR3        \ USART6_DMAR	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART6_CR3        \ USART6_SCEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART6_CR3        \ USART6_NACK	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART6_CR3        \ USART6_HDSEL	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART6_CR3        \ USART6_IRLP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART6_CR3        \ USART6_IREN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART6_CR3        \ USART6_EIE	Bit Offset:0	Bit Width:1
        
        USART6 $18 + constant USART6_GTPR	\ read-write		\  : RESET_USART6_GTPR $0000 
        \ %xxxxxxxx  8 lshift USART6_GTPR        \ USART6_GT	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift USART6_GTPR        \ USART6_PSC	Bit Offset:0	Bit Width:8
        
         
	
     $40011000 constant USART1  
	  
	
     $40004400 constant USART2  
	  
	
     $40004800 constant USART3  
	  
	
     $40007800 constant UART7  
	  
	
     $40007C00 constant UART8  
	  
	
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
        
         
	
     $40002C00 constant WWDG  
	 WWDG $0 + constant WWDG_CR	\ read-write		\  : RESET_WWDG_CR $7F 
        \ %x  7 lshift WWDG_CR        \ WWDG_WDGA	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift WWDG_CR        \ WWDG_T	Bit Offset:0	Bit Width:7
        
        WWDG $4 + constant WWDG_CFR	\ read-write		\  : RESET_WWDG_CFR $7F 
        \ %x  9 lshift WWDG_CFR        \ WWDG_EWI	Bit Offset:9	Bit Width:1
        \ %x  8 lshift WWDG_CFR        \ WWDG_WDGTB1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift WWDG_CFR        \ WWDG_WDGTB0	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift WWDG_CFR        \ WWDG_W	Bit Offset:0	Bit Width:7
        
        WWDG $8 + constant WWDG_SR	\ read-write		\  : RESET_WWDG_SR $00 
        \ %x  0 lshift WWDG_SR        \ WWDG_EWIF	Bit Offset:0	Bit Width:1
        
         
	
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
        \ %x  4 lshift RTC_CR        \ RTC_REFCKON	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_CR        \ RTC_TSEDGE	Bit Offset:3	Bit Width:1
        \ %xxx  0 lshift RTC_CR        \ RTC_WCKSEL	Bit Offset:0	Bit Width:3
        
        RTC $C + constant RTC_ISR	\ 		\  : RESET_RTC_ISR $00000007 
        \ %x  0 lshift RTC_ISR        \ RTC_ALRAWF	Bit Offset:0	Bit Width:1
        \ %x  1 lshift RTC_ISR        \ RTC_ALRBWF	Bit Offset:1	Bit Width:1
        \ %x  2 lshift RTC_ISR        \ RTC_WUTWF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift RTC_ISR        \ RTC_SHPF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift RTC_ISR        \ RTC_INITS	Bit Offset:4	Bit Width:1
        \ %x  5 lshift RTC_ISR        \ RTC_RSF	Bit Offset:5	Bit Width:1
        \ %x  6 lshift RTC_ISR        \ RTC_INITF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift RTC_ISR        \ RTC_INIT	Bit Offset:7	Bit Width:1
        \ %x  8 lshift RTC_ISR        \ RTC_ALRAF	Bit Offset:8	Bit Width:1
        \ %x  9 lshift RTC_ISR        \ RTC_ALRBF	Bit Offset:9	Bit Width:1
        \ %x  10 lshift RTC_ISR        \ RTC_WUTF	Bit Offset:10	Bit Width:1
        \ %x  11 lshift RTC_ISR        \ RTC_TSF	Bit Offset:11	Bit Width:1
        \ %x  12 lshift RTC_ISR        \ RTC_TSOVF	Bit Offset:12	Bit Width:1
        \ %x  13 lshift RTC_ISR        \ RTC_TAMP1F	Bit Offset:13	Bit Width:1
        \ %x  14 lshift RTC_ISR        \ RTC_TAMP2F	Bit Offset:14	Bit Width:1
        \ %x  16 lshift RTC_ISR        \ RTC_RECALPF	Bit Offset:16	Bit Width:1
        
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
        \ %x  18 lshift RTC_TSTR        \ RTC_ALARMOUTTYPE	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RTC_TSTR        \ RTC_TSINSEL	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RTC_TSTR        \ RTC_TAMP1INSEL	Bit Offset:16	Bit Width:1
        \ %x  2 lshift RTC_TSTR        \ RTC_TAMPIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RTC_TSTR        \ RTC_TAMP1TRG	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RTC_TSTR        \ RTC_TAMP1E	Bit Offset:0	Bit Width:1
        
        RTC $34 + constant RTC_TSDR	\ read-only		\  : RESET_RTC_TSDR $00000000 
        \ %xxx  13 lshift RTC_TSDR        \ RTC_WDU	Bit Offset:13	Bit Width:3
        \ %x  12 lshift RTC_TSDR        \ RTC_MT	Bit Offset:12	Bit Width:1
        \ %xxxx  8 lshift RTC_TSDR        \ RTC_MU	Bit Offset:8	Bit Width:4
        \ %xx  4 lshift RTC_TSDR        \ RTC_DT	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift RTC_TSDR        \ RTC_DU	Bit Offset:0	Bit Width:4
        
        RTC $38 + constant RTC_TSSSR	\ read-only		\  : RESET_RTC_TSSSR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_TSSSR        \ RTC_SS	Bit Offset:0	Bit Width:16
        
        RTC $3C + constant RTC_CALR	\ read-write		\  : RESET_RTC_CALR $00000000 
        \ %x  15 lshift RTC_CALR        \ RTC_CALP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RTC_CALR        \ RTC_CALW8	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RTC_CALR        \ RTC_CALW16	Bit Offset:13	Bit Width:1
        \ %xxxxxxxxx  0 lshift RTC_CALR        \ RTC_CALM	Bit Offset:0	Bit Width:9
        
        RTC $40 + constant RTC_TAFCR	\ read-write		\  : RESET_RTC_TAFCR $00000000 
        \ %x  18 lshift RTC_TAFCR        \ RTC_ALARMOUTTYPE	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RTC_TAFCR        \ RTC_TSINSEL	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RTC_TAFCR        \ RTC_TAMP1INSEL	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RTC_TAFCR        \ RTC_TAMPPUDIS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift RTC_TAFCR        \ RTC_TAMPPRCH	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift RTC_TAFCR        \ RTC_TAMPFLT	Bit Offset:11	Bit Width:2
        \ %xxx  8 lshift RTC_TAFCR        \ RTC_TAMPFREQ	Bit Offset:8	Bit Width:3
        \ %x  7 lshift RTC_TAFCR        \ RTC_TAMPTS	Bit Offset:7	Bit Width:1
        \ %x  4 lshift RTC_TAFCR        \ RTC_TAMP2TRG	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_TAFCR        \ RTC_TAMP2E	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RTC_TAFCR        \ RTC_TAMPIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RTC_TAFCR        \ RTC_TAMP1TRG	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RTC_TAFCR        \ RTC_TAMP1E	Bit Offset:0	Bit Width:1
        
        RTC $44 + constant RTC_ALRMASSR	\ read-write		\  : RESET_RTC_ALRMASSR $00000000 
        \ %xxxx  24 lshift RTC_ALRMASSR        \ RTC_MASKSS	Bit Offset:24	Bit Width:4
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_ALRMASSR        \ RTC_SS	Bit Offset:0	Bit Width:15
        
        RTC $48 + constant RTC_ALRMBSSR	\ read-write		\  : RESET_RTC_ALRMBSSR $00000000 
        \ %xxxx  24 lshift RTC_ALRMBSSR        \ RTC_MASKSS	Bit Offset:24	Bit Width:4
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_ALRMBSSR        \ RTC_SS	Bit Offset:0	Bit Width:15
        
        RTC $50 + constant RTC_BKP0R	\ read-write		\  : RESET_RTC_BKP0R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP0R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $54 + constant RTC_BKP1R	\ read-write		\  : RESET_RTC_BKP1R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP1R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $58 + constant RTC_BKP2R	\ read-write		\  : RESET_RTC_BKP2R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP2R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $5C + constant RTC_BKP3R	\ read-write		\  : RESET_RTC_BKP3R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP3R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $60 + constant RTC_BKP4R	\ read-write		\  : RESET_RTC_BKP4R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP4R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $64 + constant RTC_BKP5R	\ read-write		\  : RESET_RTC_BKP5R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP5R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $68 + constant RTC_BKP6R	\ read-write		\  : RESET_RTC_BKP6R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP6R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $6C + constant RTC_BKP7R	\ read-write		\  : RESET_RTC_BKP7R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP7R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $70 + constant RTC_BKP8R	\ read-write		\  : RESET_RTC_BKP8R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP8R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $74 + constant RTC_BKP9R	\ read-write		\  : RESET_RTC_BKP9R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP9R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $78 + constant RTC_BKP10R	\ read-write		\  : RESET_RTC_BKP10R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP10R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $7C + constant RTC_BKP11R	\ read-write		\  : RESET_RTC_BKP11R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP11R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $80 + constant RTC_BKP12R	\ read-write		\  : RESET_RTC_BKP12R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP12R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $84 + constant RTC_BKP13R	\ read-write		\  : RESET_RTC_BKP13R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP13R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $88 + constant RTC_BKP14R	\ read-write		\  : RESET_RTC_BKP14R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP14R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $8C + constant RTC_BKP15R	\ read-write		\  : RESET_RTC_BKP15R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP15R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $90 + constant RTC_BKP16R	\ read-write		\  : RESET_RTC_BKP16R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP16R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $94 + constant RTC_BKP17R	\ read-write		\  : RESET_RTC_BKP17R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP17R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $98 + constant RTC_BKP18R	\ read-write		\  : RESET_RTC_BKP18R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP18R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
        RTC $9C + constant RTC_BKP19R	\ read-write		\  : RESET_RTC_BKP19R $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift RTC_BKP19R        \ RTC_BKP	Bit Offset:0	Bit Width:32
        
         
	
     $40004C00 constant UART4  
	 UART4 $0 + constant UART4_SR	\ 		\  : RESET_UART4_SR $00C00000 
        \ %x  8 lshift UART4_SR        \ UART4_LBD	Bit Offset:8	Bit Width:1
        \ %x  7 lshift UART4_SR        \ UART4_TXE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift UART4_SR        \ UART4_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift UART4_SR        \ UART4_RXNE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift UART4_SR        \ UART4_IDLE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift UART4_SR        \ UART4_ORE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift UART4_SR        \ UART4_NF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift UART4_SR        \ UART4_FE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift UART4_SR        \ UART4_PE	Bit Offset:0	Bit Width:1
        
        UART4 $4 + constant UART4_DR	\ read-write		\  : RESET_UART4_DR $00000000 
        \ %xxxxxxxxx  0 lshift UART4_DR        \ UART4_DR	Bit Offset:0	Bit Width:9
        
        UART4 $8 + constant UART4_BRR	\ read-write		\  : RESET_UART4_BRR $0000 
        \ %xxxxxxxxxxxx  4 lshift UART4_BRR        \ UART4_DIV_Mantissa	Bit Offset:4	Bit Width:12
        \ %xxxx  0 lshift UART4_BRR        \ UART4_DIV_Fraction	Bit Offset:0	Bit Width:4
        
        UART4 $C + constant UART4_CR1	\ read-write		\  : RESET_UART4_CR1 $0000 
        \ %x  15 lshift UART4_CR1        \ UART4_OVER8	Bit Offset:15	Bit Width:1
        \ %x  13 lshift UART4_CR1        \ UART4_UE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift UART4_CR1        \ UART4_M	Bit Offset:12	Bit Width:1
        \ %x  11 lshift UART4_CR1        \ UART4_WAKE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift UART4_CR1        \ UART4_PCE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift UART4_CR1        \ UART4_PS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift UART4_CR1        \ UART4_PEIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift UART4_CR1        \ UART4_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift UART4_CR1        \ UART4_TCIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift UART4_CR1        \ UART4_RXNEIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift UART4_CR1        \ UART4_IDLEIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift UART4_CR1        \ UART4_TE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift UART4_CR1        \ UART4_RE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift UART4_CR1        \ UART4_RWU	Bit Offset:1	Bit Width:1
        \ %x  0 lshift UART4_CR1        \ UART4_SBK	Bit Offset:0	Bit Width:1
        
        UART4 $10 + constant UART4_CR2	\ read-write		\  : RESET_UART4_CR2 $0000 
        \ %x  14 lshift UART4_CR2        \ UART4_LINEN	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift UART4_CR2        \ UART4_STOP	Bit Offset:12	Bit Width:2
        \ %x  6 lshift UART4_CR2        \ UART4_LBDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift UART4_CR2        \ UART4_LBDL	Bit Offset:5	Bit Width:1
        \ %xxxx  0 lshift UART4_CR2        \ UART4_ADD	Bit Offset:0	Bit Width:4
        
        UART4 $14 + constant UART4_CR3	\ read-write		\  : RESET_UART4_CR3 $0000 
        \ %x  11 lshift UART4_CR3        \ UART4_ONEBIT	Bit Offset:11	Bit Width:1
        \ %x  7 lshift UART4_CR3        \ UART4_DMAT	Bit Offset:7	Bit Width:1
        \ %x  6 lshift UART4_CR3        \ UART4_DMAR	Bit Offset:6	Bit Width:1
        \ %x  3 lshift UART4_CR3        \ UART4_HDSEL	Bit Offset:3	Bit Width:1
        \ %x  2 lshift UART4_CR3        \ UART4_IRLP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift UART4_CR3        \ UART4_IREN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift UART4_CR3        \ UART4_EIE	Bit Offset:0	Bit Width:1
        
         
	
     $40005000 constant UART5  
	  
	
     $40012300 constant C_ADC  
	 C_ADC $0 + constant C_ADC_CSR	\ read-only		\  : RESET_C_ADC_CSR $00000000 
        \ %x  21 lshift C_ADC_CSR        \ C_ADC_OVR3	Bit Offset:21	Bit Width:1
        \ %x  20 lshift C_ADC_CSR        \ C_ADC_STRT3	Bit Offset:20	Bit Width:1
        \ %x  19 lshift C_ADC_CSR        \ C_ADC_JSTRT3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift C_ADC_CSR        \ C_ADC_JEOC3	Bit Offset:18	Bit Width:1
        \ %x  17 lshift C_ADC_CSR        \ C_ADC_EOC3	Bit Offset:17	Bit Width:1
        \ %x  16 lshift C_ADC_CSR        \ C_ADC_AWD3	Bit Offset:16	Bit Width:1
        \ %x  13 lshift C_ADC_CSR        \ C_ADC_OVR2	Bit Offset:13	Bit Width:1
        \ %x  12 lshift C_ADC_CSR        \ C_ADC_STRT2	Bit Offset:12	Bit Width:1
        \ %x  11 lshift C_ADC_CSR        \ C_ADC_JSTRT2	Bit Offset:11	Bit Width:1
        \ %x  10 lshift C_ADC_CSR        \ C_ADC_JEOC2	Bit Offset:10	Bit Width:1
        \ %x  9 lshift C_ADC_CSR        \ C_ADC_EOC2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift C_ADC_CSR        \ C_ADC_AWD2	Bit Offset:8	Bit Width:1
        \ %x  5 lshift C_ADC_CSR        \ C_ADC_OVR1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift C_ADC_CSR        \ C_ADC_STRT1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift C_ADC_CSR        \ C_ADC_JSTRT1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift C_ADC_CSR        \ C_ADC_JEOC1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift C_ADC_CSR        \ C_ADC_EOC1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift C_ADC_CSR        \ C_ADC_AWD1	Bit Offset:0	Bit Width:1
        
        C_ADC $4 + constant C_ADC_CCR	\ read-write		\  : RESET_C_ADC_CCR $00000000 
        \ %x  23 lshift C_ADC_CCR        \ C_ADC_TSVREFE	Bit Offset:23	Bit Width:1
        \ %x  22 lshift C_ADC_CCR        \ C_ADC_VBATE	Bit Offset:22	Bit Width:1
        \ %xx  16 lshift C_ADC_CCR        \ C_ADC_ADCPRE	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift C_ADC_CCR        \ C_ADC_DMA	Bit Offset:14	Bit Width:2
        \ %x  13 lshift C_ADC_CCR        \ C_ADC_DDS	Bit Offset:13	Bit Width:1
        \ %xxxx  8 lshift C_ADC_CCR        \ C_ADC_DELAY	Bit Offset:8	Bit Width:4
        \ %xxxxx  0 lshift C_ADC_CCR        \ C_ADC_MULT	Bit Offset:0	Bit Width:5
        
        C_ADC $8 + constant C_ADC_CDR	\ read-only		\  : RESET_C_ADC_CDR $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift C_ADC_CDR        \ C_ADC_DATA2	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift C_ADC_CDR        \ C_ADC_DATA1	Bit Offset:0	Bit Width:16
        
         
	
     $40010000 constant TIM1  
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
        \ %x  14 lshift TIM1_DIER        \ TIM1_TDE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TIM1_DIER        \ TIM1_COMDE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM1_DIER        \ TIM1_CC4DE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM1_DIER        \ TIM1_CC3DE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM1_DIER        \ TIM1_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM1_DIER        \ TIM1_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM1_DIER        \ TIM1_UDE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift TIM1_DIER        \ TIM1_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM1_DIER        \ TIM1_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM1_DIER        \ TIM1_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM1_DIER        \ TIM1_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM1_DIER        \ TIM1_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM1_DIER        \ TIM1_UIE	Bit Offset:0	Bit Width:1
        \ %x  7 lshift TIM1_DIER        \ TIM1_BIE	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM1_DIER        \ TIM1_COMIE	Bit Offset:5	Bit Width:1
        
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
        \ %xxxx  12 lshift TIM1_CCMR1_Input        \ TIM1_IC2F	Bit Offset:12	Bit Width:4
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
        \ %xxxx  12 lshift TIM1_CCMR2_Input        \ TIM1_IC4F	Bit Offset:12	Bit Width:4
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
        
         
	
     $40010400 constant TIM8  
	  
	
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
        \ %xx  10 lshift TIM2_CCMR1_Input        \ TIM2_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM2_CCMR1_Input        \ TIM2_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM2_CCMR1_Input        \ TIM2_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM2_CCMR1_Input        \ TIM2_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM2_CCMR1_Input        \ TIM2_CC1S	Bit Offset:0	Bit Width:2
        
        TIM2 $1C + constant TIM2_CCMR2_Output	\ read-write		\  : RESET_TIM2_CCMR2_Output $00000000 
        \ %x  15 lshift TIM2_CCMR2_Output        \ TIM2_O24CE	Bit Offset:15	Bit Width:1
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
        
        TIM2 $24 + constant TIM2_CNT	\ read-write		\  : RESET_TIM2_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM2_CNT        \ TIM2_CNT_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CNT        \ TIM2_CNT_L	Bit Offset:0	Bit Width:16
        
        TIM2 $28 + constant TIM2_PSC	\ read-write		\  : RESET_TIM2_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_PSC        \ TIM2_PSC	Bit Offset:0	Bit Width:16
        
        TIM2 $2C + constant TIM2_ARR	\ read-write		\  : RESET_TIM2_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM2_ARR        \ TIM2_ARR_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_ARR        \ TIM2_ARR_L	Bit Offset:0	Bit Width:16
        
        TIM2 $34 + constant TIM2_CCR1	\ read-write		\  : RESET_TIM2_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM2_CCR1        \ TIM2_CCR1_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR1        \ TIM2_CCR1_L	Bit Offset:0	Bit Width:16
        
        TIM2 $38 + constant TIM2_CCR2	\ read-write		\  : RESET_TIM2_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM2_CCR2        \ TIM2_CCR2_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR2        \ TIM2_CCR2_L	Bit Offset:0	Bit Width:16
        
        TIM2 $3C + constant TIM2_CCR3	\ read-write		\  : RESET_TIM2_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM2_CCR3        \ TIM2_CCR3_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR3        \ TIM2_CCR3_L	Bit Offset:0	Bit Width:16
        
        TIM2 $40 + constant TIM2_CCR4	\ read-write		\  : RESET_TIM2_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM2_CCR4        \ TIM2_CCR4_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_CCR4        \ TIM2_CCR4_L	Bit Offset:0	Bit Width:16
        
        TIM2 $48 + constant TIM2_DCR	\ read-write		\  : RESET_TIM2_DCR $0000 
        \ %xxxxx  8 lshift TIM2_DCR        \ TIM2_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM2_DCR        \ TIM2_DBA	Bit Offset:0	Bit Width:5
        
        TIM2 $4C + constant TIM2_DMAR	\ read-write		\  : RESET_TIM2_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM2_DMAR        \ TIM2_DMAB	Bit Offset:0	Bit Width:16
        
        TIM2 $50 + constant TIM2_OR	\ read-write		\  : RESET_TIM2_OR $0000 
        \ %xx  10 lshift TIM2_OR        \ TIM2_ITR1_RMP	Bit Offset:10	Bit Width:2
        
         
	
     $40000400 constant TIM3  
	 TIM3 $0 + constant TIM3_CR1	\ read-write		\  : RESET_TIM3_CR1 $0000 
        \ %xx  8 lshift TIM3_CR1        \ TIM3_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM3_CR1        \ TIM3_ARPE	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift TIM3_CR1        \ TIM3_CMS	Bit Offset:5	Bit Width:2
        \ %x  4 lshift TIM3_CR1        \ TIM3_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM3_CR1        \ TIM3_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM3_CR1        \ TIM3_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM3_CR1        \ TIM3_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM3_CR1        \ TIM3_CEN	Bit Offset:0	Bit Width:1
        
        TIM3 $4 + constant TIM3_CR2	\ read-write		\  : RESET_TIM3_CR2 $0000 
        \ %x  7 lshift TIM3_CR2        \ TIM3_TI1S	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM3_CR2        \ TIM3_MMS	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM3_CR2        \ TIM3_CCDS	Bit Offset:3	Bit Width:1
        
        TIM3 $8 + constant TIM3_SMCR	\ read-write		\  : RESET_TIM3_SMCR $0000 
        \ %x  15 lshift TIM3_SMCR        \ TIM3_ETP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM3_SMCR        \ TIM3_ECE	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift TIM3_SMCR        \ TIM3_ETPS	Bit Offset:12	Bit Width:2
        \ %xxxx  8 lshift TIM3_SMCR        \ TIM3_ETF	Bit Offset:8	Bit Width:4
        \ %x  7 lshift TIM3_SMCR        \ TIM3_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM3_SMCR        \ TIM3_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM3_SMCR        \ TIM3_SMS	Bit Offset:0	Bit Width:3
        
        TIM3 $C + constant TIM3_DIER	\ read-write		\  : RESET_TIM3_DIER $0000 
        \ %x  14 lshift TIM3_DIER        \ TIM3_TDE	Bit Offset:14	Bit Width:1
        \ %x  12 lshift TIM3_DIER        \ TIM3_CC4DE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM3_DIER        \ TIM3_CC3DE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM3_DIER        \ TIM3_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM3_DIER        \ TIM3_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM3_DIER        \ TIM3_UDE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift TIM3_DIER        \ TIM3_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM3_DIER        \ TIM3_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM3_DIER        \ TIM3_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM3_DIER        \ TIM3_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM3_DIER        \ TIM3_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM3_DIER        \ TIM3_UIE	Bit Offset:0	Bit Width:1
        
        TIM3 $10 + constant TIM3_SR	\ read-write		\  : RESET_TIM3_SR $0000 
        \ %x  12 lshift TIM3_SR        \ TIM3_CC4OF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM3_SR        \ TIM3_CC3OF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM3_SR        \ TIM3_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM3_SR        \ TIM3_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM3_SR        \ TIM3_TIF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM3_SR        \ TIM3_CC4IF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM3_SR        \ TIM3_CC3IF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM3_SR        \ TIM3_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM3_SR        \ TIM3_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM3_SR        \ TIM3_UIF	Bit Offset:0	Bit Width:1
        
        TIM3 $14 + constant TIM3_EGR	\ write-only		\  : RESET_TIM3_EGR $0000 
        \ %x  6 lshift TIM3_EGR        \ TIM3_TG	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM3_EGR        \ TIM3_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM3_EGR        \ TIM3_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM3_EGR        \ TIM3_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM3_EGR        \ TIM3_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM3_EGR        \ TIM3_UG	Bit Offset:0	Bit Width:1
        
        TIM3 $18 + constant TIM3_CCMR1_Output	\ read-write		\  : RESET_TIM3_CCMR1_Output $00000000 
        \ %x  15 lshift TIM3_CCMR1_Output        \ TIM3_OC2CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM3_CCMR1_Output        \ TIM3_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM3_CCMR1_Output        \ TIM3_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM3_CCMR1_Output        \ TIM3_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM3_CCMR1_Output        \ TIM3_CC2S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM3_CCMR1_Output        \ TIM3_OC1CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM3_CCMR1_Output        \ TIM3_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM3_CCMR1_Output        \ TIM3_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM3_CCMR1_Output        \ TIM3_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM3_CCMR1_Output        \ TIM3_CC1S	Bit Offset:0	Bit Width:2
        
        TIM3 $18 + constant TIM3_CCMR1_Input	\ read-write		\  : RESET_TIM3_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM3_CCMR1_Input        \ TIM3_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM3_CCMR1_Input        \ TIM3_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM3_CCMR1_Input        \ TIM3_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM3_CCMR1_Input        \ TIM3_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM3_CCMR1_Input        \ TIM3_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM3_CCMR1_Input        \ TIM3_CC1S	Bit Offset:0	Bit Width:2
        
        TIM3 $1C + constant TIM3_CCMR2_Output	\ read-write		\  : RESET_TIM3_CCMR2_Output $00000000 
        \ %x  15 lshift TIM3_CCMR2_Output        \ TIM3_O24CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM3_CCMR2_Output        \ TIM3_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM3_CCMR2_Output        \ TIM3_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM3_CCMR2_Output        \ TIM3_OC4FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM3_CCMR2_Output        \ TIM3_CC4S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM3_CCMR2_Output        \ TIM3_OC3CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM3_CCMR2_Output        \ TIM3_OC3M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM3_CCMR2_Output        \ TIM3_OC3PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM3_CCMR2_Output        \ TIM3_OC3FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM3_CCMR2_Output        \ TIM3_CC3S	Bit Offset:0	Bit Width:2
        
        TIM3 $1C + constant TIM3_CCMR2_Input	\ read-write		\  : RESET_TIM3_CCMR2_Input $00000000 
        \ %xxxx  12 lshift TIM3_CCMR2_Input        \ TIM3_IC4F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM3_CCMR2_Input        \ TIM3_IC4PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM3_CCMR2_Input        \ TIM3_CC4S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM3_CCMR2_Input        \ TIM3_IC3F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM3_CCMR2_Input        \ TIM3_IC3PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM3_CCMR2_Input        \ TIM3_CC3S	Bit Offset:0	Bit Width:2
        
        TIM3 $20 + constant TIM3_CCER	\ read-write		\  : RESET_TIM3_CCER $0000 
        \ %x  15 lshift TIM3_CCER        \ TIM3_CC4NP	Bit Offset:15	Bit Width:1
        \ %x  13 lshift TIM3_CCER        \ TIM3_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM3_CCER        \ TIM3_CC4E	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM3_CCER        \ TIM3_CC3NP	Bit Offset:11	Bit Width:1
        \ %x  9 lshift TIM3_CCER        \ TIM3_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM3_CCER        \ TIM3_CC3E	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM3_CCER        \ TIM3_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM3_CCER        \ TIM3_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM3_CCER        \ TIM3_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM3_CCER        \ TIM3_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM3_CCER        \ TIM3_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM3_CCER        \ TIM3_CC1E	Bit Offset:0	Bit Width:1
        
        TIM3 $24 + constant TIM3_CNT	\ read-write		\  : RESET_TIM3_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM3_CNT        \ TIM3_CNT_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_CNT        \ TIM3_CNT_L	Bit Offset:0	Bit Width:16
        
        TIM3 $28 + constant TIM3_PSC	\ read-write		\  : RESET_TIM3_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_PSC        \ TIM3_PSC	Bit Offset:0	Bit Width:16
        
        TIM3 $2C + constant TIM3_ARR	\ read-write		\  : RESET_TIM3_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM3_ARR        \ TIM3_ARR_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_ARR        \ TIM3_ARR_L	Bit Offset:0	Bit Width:16
        
        TIM3 $34 + constant TIM3_CCR1	\ read-write		\  : RESET_TIM3_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM3_CCR1        \ TIM3_CCR1_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_CCR1        \ TIM3_CCR1_L	Bit Offset:0	Bit Width:16
        
        TIM3 $38 + constant TIM3_CCR2	\ read-write		\  : RESET_TIM3_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM3_CCR2        \ TIM3_CCR2_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_CCR2        \ TIM3_CCR2_L	Bit Offset:0	Bit Width:16
        
        TIM3 $3C + constant TIM3_CCR3	\ read-write		\  : RESET_TIM3_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM3_CCR3        \ TIM3_CCR3_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_CCR3        \ TIM3_CCR3_L	Bit Offset:0	Bit Width:16
        
        TIM3 $40 + constant TIM3_CCR4	\ read-write		\  : RESET_TIM3_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM3_CCR4        \ TIM3_CCR4_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_CCR4        \ TIM3_CCR4_L	Bit Offset:0	Bit Width:16
        
        TIM3 $48 + constant TIM3_DCR	\ read-write		\  : RESET_TIM3_DCR $0000 
        \ %xxxxx  8 lshift TIM3_DCR        \ TIM3_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM3_DCR        \ TIM3_DBA	Bit Offset:0	Bit Width:5
        
        TIM3 $4C + constant TIM3_DMAR	\ read-write		\  : RESET_TIM3_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM3_DMAR        \ TIM3_DMAB	Bit Offset:0	Bit Width:16
        
         
	
     $40000800 constant TIM4  
	  
	
     $40000C00 constant TIM5  
	 TIM5 $0 + constant TIM5_CR1	\ read-write		\  : RESET_TIM5_CR1 $0000 
        \ %xx  8 lshift TIM5_CR1        \ TIM5_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM5_CR1        \ TIM5_ARPE	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift TIM5_CR1        \ TIM5_CMS	Bit Offset:5	Bit Width:2
        \ %x  4 lshift TIM5_CR1        \ TIM5_DIR	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM5_CR1        \ TIM5_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM5_CR1        \ TIM5_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM5_CR1        \ TIM5_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM5_CR1        \ TIM5_CEN	Bit Offset:0	Bit Width:1
        
        TIM5 $4 + constant TIM5_CR2	\ read-write		\  : RESET_TIM5_CR2 $0000 
        \ %x  7 lshift TIM5_CR2        \ TIM5_TI1S	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM5_CR2        \ TIM5_MMS	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM5_CR2        \ TIM5_CCDS	Bit Offset:3	Bit Width:1
        
        TIM5 $8 + constant TIM5_SMCR	\ read-write		\  : RESET_TIM5_SMCR $0000 
        \ %x  15 lshift TIM5_SMCR        \ TIM5_ETP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TIM5_SMCR        \ TIM5_ECE	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift TIM5_SMCR        \ TIM5_ETPS	Bit Offset:12	Bit Width:2
        \ %xxxx  8 lshift TIM5_SMCR        \ TIM5_ETF	Bit Offset:8	Bit Width:4
        \ %x  7 lshift TIM5_SMCR        \ TIM5_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM5_SMCR        \ TIM5_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM5_SMCR        \ TIM5_SMS	Bit Offset:0	Bit Width:3
        
        TIM5 $C + constant TIM5_DIER	\ read-write		\  : RESET_TIM5_DIER $0000 
        \ %x  14 lshift TIM5_DIER        \ TIM5_TDE	Bit Offset:14	Bit Width:1
        \ %x  12 lshift TIM5_DIER        \ TIM5_CC4DE	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM5_DIER        \ TIM5_CC3DE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM5_DIER        \ TIM5_CC2DE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM5_DIER        \ TIM5_CC1DE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM5_DIER        \ TIM5_UDE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift TIM5_DIER        \ TIM5_TIE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM5_DIER        \ TIM5_CC4IE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM5_DIER        \ TIM5_CC3IE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM5_DIER        \ TIM5_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM5_DIER        \ TIM5_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM5_DIER        \ TIM5_UIE	Bit Offset:0	Bit Width:1
        
        TIM5 $10 + constant TIM5_SR	\ read-write		\  : RESET_TIM5_SR $0000 
        \ %x  12 lshift TIM5_SR        \ TIM5_CC4OF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM5_SR        \ TIM5_CC3OF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM5_SR        \ TIM5_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM5_SR        \ TIM5_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM5_SR        \ TIM5_TIF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM5_SR        \ TIM5_CC4IF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM5_SR        \ TIM5_CC3IF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM5_SR        \ TIM5_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM5_SR        \ TIM5_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM5_SR        \ TIM5_UIF	Bit Offset:0	Bit Width:1
        
        TIM5 $14 + constant TIM5_EGR	\ write-only		\  : RESET_TIM5_EGR $0000 
        \ %x  6 lshift TIM5_EGR        \ TIM5_TG	Bit Offset:6	Bit Width:1
        \ %x  4 lshift TIM5_EGR        \ TIM5_CC4G	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM5_EGR        \ TIM5_CC3G	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM5_EGR        \ TIM5_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM5_EGR        \ TIM5_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM5_EGR        \ TIM5_UG	Bit Offset:0	Bit Width:1
        
        TIM5 $18 + constant TIM5_CCMR1_Output	\ read-write		\  : RESET_TIM5_CCMR1_Output $00000000 
        \ %x  15 lshift TIM5_CCMR1_Output        \ TIM5_OC2CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM5_CCMR1_Output        \ TIM5_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM5_CCMR1_Output        \ TIM5_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM5_CCMR1_Output        \ TIM5_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM5_CCMR1_Output        \ TIM5_CC2S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM5_CCMR1_Output        \ TIM5_OC1CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM5_CCMR1_Output        \ TIM5_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM5_CCMR1_Output        \ TIM5_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM5_CCMR1_Output        \ TIM5_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM5_CCMR1_Output        \ TIM5_CC1S	Bit Offset:0	Bit Width:2
        
        TIM5 $18 + constant TIM5_CCMR1_Input	\ read-write		\  : RESET_TIM5_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM5_CCMR1_Input        \ TIM5_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM5_CCMR1_Input        \ TIM5_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM5_CCMR1_Input        \ TIM5_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM5_CCMR1_Input        \ TIM5_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM5_CCMR1_Input        \ TIM5_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM5_CCMR1_Input        \ TIM5_CC1S	Bit Offset:0	Bit Width:2
        
        TIM5 $1C + constant TIM5_CCMR2_Output	\ read-write		\  : RESET_TIM5_CCMR2_Output $00000000 
        \ %x  15 lshift TIM5_CCMR2_Output        \ TIM5_O24CE	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TIM5_CCMR2_Output        \ TIM5_OC4M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM5_CCMR2_Output        \ TIM5_OC4PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM5_CCMR2_Output        \ TIM5_OC4FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM5_CCMR2_Output        \ TIM5_CC4S	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM5_CCMR2_Output        \ TIM5_OC3CE	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM5_CCMR2_Output        \ TIM5_OC3M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM5_CCMR2_Output        \ TIM5_OC3PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM5_CCMR2_Output        \ TIM5_OC3FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM5_CCMR2_Output        \ TIM5_CC3S	Bit Offset:0	Bit Width:2
        
        TIM5 $1C + constant TIM5_CCMR2_Input	\ read-write		\  : RESET_TIM5_CCMR2_Input $00000000 
        \ %xxxx  12 lshift TIM5_CCMR2_Input        \ TIM5_IC4F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM5_CCMR2_Input        \ TIM5_IC4PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM5_CCMR2_Input        \ TIM5_CC4S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM5_CCMR2_Input        \ TIM5_IC3F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM5_CCMR2_Input        \ TIM5_IC3PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM5_CCMR2_Input        \ TIM5_CC3S	Bit Offset:0	Bit Width:2
        
        TIM5 $20 + constant TIM5_CCER	\ read-write		\  : RESET_TIM5_CCER $0000 
        \ %x  15 lshift TIM5_CCER        \ TIM5_CC4NP	Bit Offset:15	Bit Width:1
        \ %x  13 lshift TIM5_CCER        \ TIM5_CC4P	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TIM5_CCER        \ TIM5_CC4E	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TIM5_CCER        \ TIM5_CC3NP	Bit Offset:11	Bit Width:1
        \ %x  9 lshift TIM5_CCER        \ TIM5_CC3P	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TIM5_CCER        \ TIM5_CC3E	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TIM5_CCER        \ TIM5_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM5_CCER        \ TIM5_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM5_CCER        \ TIM5_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM5_CCER        \ TIM5_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM5_CCER        \ TIM5_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM5_CCER        \ TIM5_CC1E	Bit Offset:0	Bit Width:1
        
        TIM5 $24 + constant TIM5_CNT	\ read-write		\  : RESET_TIM5_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM5_CNT        \ TIM5_CNT_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_CNT        \ TIM5_CNT_L	Bit Offset:0	Bit Width:16
        
        TIM5 $28 + constant TIM5_PSC	\ read-write		\  : RESET_TIM5_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_PSC        \ TIM5_PSC	Bit Offset:0	Bit Width:16
        
        TIM5 $2C + constant TIM5_ARR	\ read-write		\  : RESET_TIM5_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM5_ARR        \ TIM5_ARR_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_ARR        \ TIM5_ARR_L	Bit Offset:0	Bit Width:16
        
        TIM5 $34 + constant TIM5_CCR1	\ read-write		\  : RESET_TIM5_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM5_CCR1        \ TIM5_CCR1_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_CCR1        \ TIM5_CCR1_L	Bit Offset:0	Bit Width:16
        
        TIM5 $38 + constant TIM5_CCR2	\ read-write		\  : RESET_TIM5_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM5_CCR2        \ TIM5_CCR2_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_CCR2        \ TIM5_CCR2_L	Bit Offset:0	Bit Width:16
        
        TIM5 $3C + constant TIM5_CCR3	\ read-write		\  : RESET_TIM5_CCR3 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM5_CCR3        \ TIM5_CCR3_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_CCR3        \ TIM5_CCR3_L	Bit Offset:0	Bit Width:16
        
        TIM5 $40 + constant TIM5_CCR4	\ read-write		\  : RESET_TIM5_CCR4 $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift TIM5_CCR4        \ TIM5_CCR4_H	Bit Offset:16	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_CCR4        \ TIM5_CCR4_L	Bit Offset:0	Bit Width:16
        
        TIM5 $48 + constant TIM5_DCR	\ read-write		\  : RESET_TIM5_DCR $0000 
        \ %xxxxx  8 lshift TIM5_DCR        \ TIM5_DBL	Bit Offset:8	Bit Width:5
        \ %xxxxx  0 lshift TIM5_DCR        \ TIM5_DBA	Bit Offset:0	Bit Width:5
        
        TIM5 $4C + constant TIM5_DMAR	\ read-write		\  : RESET_TIM5_DMAR $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM5_DMAR        \ TIM5_DMAB	Bit Offset:0	Bit Width:16
        
        TIM5 $50 + constant TIM5_OR	\ read-write		\  : RESET_TIM5_OR $0000 
        \ %xx  6 lshift TIM5_OR        \ TIM5_IT4_RMP	Bit Offset:6	Bit Width:2
        
         
	
     $40014000 constant TIM9  
	 TIM9 $0 + constant TIM9_CR1	\ read-write		\  : RESET_TIM9_CR1 $0000 
        \ %xx  8 lshift TIM9_CR1        \ TIM9_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM9_CR1        \ TIM9_ARPE	Bit Offset:7	Bit Width:1
        \ %x  3 lshift TIM9_CR1        \ TIM9_OPM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM9_CR1        \ TIM9_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM9_CR1        \ TIM9_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_CR1        \ TIM9_CEN	Bit Offset:0	Bit Width:1
        
        TIM9 $4 + constant TIM9_CR2	\ read-write		\  : RESET_TIM9_CR2 $0000 
        \ %xxx  4 lshift TIM9_CR2        \ TIM9_MMS	Bit Offset:4	Bit Width:3
        
        TIM9 $8 + constant TIM9_SMCR	\ read-write		\  : RESET_TIM9_SMCR $0000 
        \ %x  7 lshift TIM9_SMCR        \ TIM9_MSM	Bit Offset:7	Bit Width:1
        \ %xxx  4 lshift TIM9_SMCR        \ TIM9_TS	Bit Offset:4	Bit Width:3
        \ %xxx  0 lshift TIM9_SMCR        \ TIM9_SMS	Bit Offset:0	Bit Width:3
        
        TIM9 $C + constant TIM9_DIER	\ read-write		\  : RESET_TIM9_DIER $0000 
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
        
        TIM9 $14 + constant TIM9_EGR	\ write-only		\  : RESET_TIM9_EGR $0000 
        \ %x  6 lshift TIM9_EGR        \ TIM9_TG	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM9_EGR        \ TIM9_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM9_EGR        \ TIM9_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_EGR        \ TIM9_UG	Bit Offset:0	Bit Width:1
        
        TIM9 $18 + constant TIM9_CCMR1_Output	\ read-write		\  : RESET_TIM9_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM9_CCMR1_Output        \ TIM9_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM9_CCMR1_Output        \ TIM9_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM9_CCMR1_Output        \ TIM9_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM9_CCMR1_Output        \ TIM9_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM9_CCMR1_Output        \ TIM9_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM9_CCMR1_Output        \ TIM9_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM9_CCMR1_Output        \ TIM9_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM9_CCMR1_Output        \ TIM9_CC1S	Bit Offset:0	Bit Width:2
        
        TIM9 $18 + constant TIM9_CCMR1_Input	\ read-write		\  : RESET_TIM9_CCMR1_Input $00000000 
        \ %xxx  12 lshift TIM9_CCMR1_Input        \ TIM9_IC2F	Bit Offset:12	Bit Width:3
        \ %xx  10 lshift TIM9_CCMR1_Input        \ TIM9_IC2PCS	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM9_CCMR1_Input        \ TIM9_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM9_CCMR1_Input        \ TIM9_IC1F	Bit Offset:4	Bit Width:3
        \ %xx  2 lshift TIM9_CCMR1_Input        \ TIM9_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM9_CCMR1_Input        \ TIM9_CC1S	Bit Offset:0	Bit Width:2
        
        TIM9 $20 + constant TIM9_CCER	\ read-write		\  : RESET_TIM9_CCER $0000 
        \ %x  7 lshift TIM9_CCER        \ TIM9_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM9_CCER        \ TIM9_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM9_CCER        \ TIM9_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM9_CCER        \ TIM9_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM9_CCER        \ TIM9_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM9_CCER        \ TIM9_CC1E	Bit Offset:0	Bit Width:1
        
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
        
         
	
     $40001800 constant TIM12  
	  
	
     $40014400 constant TIM10  
	 TIM10 $0 + constant TIM10_CR1	\ read-write		\  : RESET_TIM10_CR1 $0000 
        \ %xx  8 lshift TIM10_CR1        \ TIM10_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM10_CR1        \ TIM10_ARPE	Bit Offset:7	Bit Width:1
        \ %x  2 lshift TIM10_CR1        \ TIM10_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM10_CR1        \ TIM10_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_CR1        \ TIM10_CEN	Bit Offset:0	Bit Width:1
        
        TIM10 $C + constant TIM10_DIER	\ read-write		\  : RESET_TIM10_DIER $0000 
        \ %x  1 lshift TIM10_DIER        \ TIM10_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_DIER        \ TIM10_UIE	Bit Offset:0	Bit Width:1
        
        TIM10 $10 + constant TIM10_SR	\ read-write		\  : RESET_TIM10_SR $0000 
        \ %x  9 lshift TIM10_SR        \ TIM10_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  1 lshift TIM10_SR        \ TIM10_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_SR        \ TIM10_UIF	Bit Offset:0	Bit Width:1
        
        TIM10 $14 + constant TIM10_EGR	\ write-only		\  : RESET_TIM10_EGR $0000 
        \ %x  1 lshift TIM10_EGR        \ TIM10_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM10_EGR        \ TIM10_UG	Bit Offset:0	Bit Width:1
        
        TIM10 $18 + constant TIM10_CCMR1_Output	\ read-write		\  : RESET_TIM10_CCMR1_Output $00000000 
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
        
         
	
     $40001C00 constant TIM13  
	  
	
     $40002000 constant TIM14  
	  
	
     $40014800 constant TIM11  
	 TIM11 $0 + constant TIM11_CR1	\ read-write		\  : RESET_TIM11_CR1 $0000 
        \ %xx  8 lshift TIM11_CR1        \ TIM11_CKD	Bit Offset:8	Bit Width:2
        \ %x  7 lshift TIM11_CR1        \ TIM11_ARPE	Bit Offset:7	Bit Width:1
        \ %x  2 lshift TIM11_CR1        \ TIM11_URS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM11_CR1        \ TIM11_UDIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM11_CR1        \ TIM11_CEN	Bit Offset:0	Bit Width:1
        
        TIM11 $C + constant TIM11_DIER	\ read-write		\  : RESET_TIM11_DIER $0000 
        \ %x  1 lshift TIM11_DIER        \ TIM11_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM11_DIER        \ TIM11_UIE	Bit Offset:0	Bit Width:1
        
        TIM11 $10 + constant TIM11_SR	\ read-write		\  : RESET_TIM11_SR $0000 
        \ %x  9 lshift TIM11_SR        \ TIM11_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  1 lshift TIM11_SR        \ TIM11_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM11_SR        \ TIM11_UIF	Bit Offset:0	Bit Width:1
        
        TIM11 $14 + constant TIM11_EGR	\ write-only		\  : RESET_TIM11_EGR $0000 
        \ %x  1 lshift TIM11_EGR        \ TIM11_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM11_EGR        \ TIM11_UG	Bit Offset:0	Bit Width:1
        
        TIM11 $18 + constant TIM11_CCMR1_Output	\ read-write		\  : RESET_TIM11_CCMR1_Output $00000000 
        \ %xxx  4 lshift TIM11_CCMR1_Output        \ TIM11_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM11_CCMR1_Output        \ TIM11_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM11_CCMR1_Output        \ TIM11_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM11_CCMR1_Output        \ TIM11_CC1S	Bit Offset:0	Bit Width:2
        
        TIM11 $18 + constant TIM11_CCMR1_Input	\ read-write		\  : RESET_TIM11_CCMR1_Input $00000000 
        \ %xxxx  4 lshift TIM11_CCMR1_Input        \ TIM11_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM11_CCMR1_Input        \ TIM11_ICPCS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM11_CCMR1_Input        \ TIM11_CC1S	Bit Offset:0	Bit Width:2
        
        TIM11 $20 + constant TIM11_CCER	\ read-write		\  : RESET_TIM11_CCER $0000 
        \ %x  3 lshift TIM11_CCER        \ TIM11_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM11_CCER        \ TIM11_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM11_CCER        \ TIM11_CC1E	Bit Offset:0	Bit Width:1
        
        TIM11 $24 + constant TIM11_CNT	\ read-write		\  : RESET_TIM11_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM11_CNT        \ TIM11_CNT	Bit Offset:0	Bit Width:16
        
        TIM11 $28 + constant TIM11_PSC	\ read-write		\  : RESET_TIM11_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM11_PSC        \ TIM11_PSC	Bit Offset:0	Bit Width:16
        
        TIM11 $2C + constant TIM11_ARR	\ read-write		\  : RESET_TIM11_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM11_ARR        \ TIM11_ARR	Bit Offset:0	Bit Width:16
        
        TIM11 $34 + constant TIM11_CCR1	\ read-write		\  : RESET_TIM11_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM11_CCR1        \ TIM11_CCR1	Bit Offset:0	Bit Width:16
        
        TIM11 $50 + constant TIM11_OR	\ read-write		\  : RESET_TIM11_OR $00000000 
        \ %xx  0 lshift TIM11_OR        \ TIM11_RMP	Bit Offset:0	Bit Width:2
        
         
	
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
	  
	
     $40028000 constant Ethernet_MAC  
	 Ethernet_MAC $0 + constant Ethernet_MAC_MACCR	\ read-write		\  : RESET_Ethernet_MAC_MACCR $0008000 
        \ %x  2 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_RE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_TE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_DC	Bit Offset:4	Bit Width:1
        \ %xx  5 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_BL	Bit Offset:5	Bit Width:2
        \ %x  7 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_APCS	Bit Offset:7	Bit Width:1
        \ %x  9 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_RD	Bit Offset:9	Bit Width:1
        \ %x  10 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_IPCO	Bit Offset:10	Bit Width:1
        \ %x  11 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_DM	Bit Offset:11	Bit Width:1
        \ %x  12 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_LM	Bit Offset:12	Bit Width:1
        \ %x  13 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_ROD	Bit Offset:13	Bit Width:1
        \ %x  14 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_FES	Bit Offset:14	Bit Width:1
        \ %x  16 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_CSD	Bit Offset:16	Bit Width:1
        \ %xxx  17 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_IFG	Bit Offset:17	Bit Width:3
        \ %x  22 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_JD	Bit Offset:22	Bit Width:1
        \ %x  23 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_WD	Bit Offset:23	Bit Width:1
        \ %x  25 lshift Ethernet_MAC_MACCR        \ Ethernet_MAC_CSTF	Bit Offset:25	Bit Width:1
        
        Ethernet_MAC $4 + constant Ethernet_MAC_MACFFR	\ read-write		\  : RESET_Ethernet_MAC_MACFFR $00000000 
        \ %x  0 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_PM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_HU	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_HM	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_DAIF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_RAM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_BFD	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_PCF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_SAIF	Bit Offset:7	Bit Width:1
        \ %x  8 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_SAF	Bit Offset:8	Bit Width:1
        \ %x  9 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_HPF	Bit Offset:9	Bit Width:1
        \ %x  31 lshift Ethernet_MAC_MACFFR        \ Ethernet_MAC_RA	Bit Offset:31	Bit Width:1
        
        Ethernet_MAC $8 + constant Ethernet_MAC_MACHTHR	\ read-write		\  : RESET_Ethernet_MAC_MACHTHR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACHTHR        \ Ethernet_MAC_HTH	Bit Offset:0	Bit Width:32
        
        Ethernet_MAC $C + constant Ethernet_MAC_MACHTLR	\ read-write		\  : RESET_Ethernet_MAC_MACHTLR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACHTLR        \ Ethernet_MAC_HTL	Bit Offset:0	Bit Width:32
        
        Ethernet_MAC $10 + constant Ethernet_MAC_MACMIIAR	\ read-write		\  : RESET_Ethernet_MAC_MACMIIAR $00000000 
        \ %x  0 lshift Ethernet_MAC_MACMIIAR        \ Ethernet_MAC_MB	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_MAC_MACMIIAR        \ Ethernet_MAC_MW	Bit Offset:1	Bit Width:1
        \ %xxx  2 lshift Ethernet_MAC_MACMIIAR        \ Ethernet_MAC_CR	Bit Offset:2	Bit Width:3
        \ %xxxxx  6 lshift Ethernet_MAC_MACMIIAR        \ Ethernet_MAC_MR	Bit Offset:6	Bit Width:5
        \ %xxxxx  11 lshift Ethernet_MAC_MACMIIAR        \ Ethernet_MAC_PA	Bit Offset:11	Bit Width:5
        
        Ethernet_MAC $14 + constant Ethernet_MAC_MACMIIDR	\ read-write		\  : RESET_Ethernet_MAC_MACMIIDR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACMIIDR        \ Ethernet_MAC_TD	Bit Offset:0	Bit Width:16
        
        Ethernet_MAC $18 + constant Ethernet_MAC_MACFCR	\ read-write		\  : RESET_Ethernet_MAC_MACFCR $00000000 
        \ %x  0 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_FCB	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_TFCE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_RFCE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_UPFD	Bit Offset:3	Bit Width:1
        \ %xx  4 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_PLT	Bit Offset:4	Bit Width:2
        \ %x  7 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_ZQPD	Bit Offset:7	Bit Width:1
        \ %xxxxxxxxxxxxxxxx  16 lshift Ethernet_MAC_MACFCR        \ Ethernet_MAC_PT	Bit Offset:16	Bit Width:16
        
        Ethernet_MAC $1C + constant Ethernet_MAC_MACVLANTR	\ read-write		\  : RESET_Ethernet_MAC_MACVLANTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACVLANTR        \ Ethernet_MAC_VLANTI	Bit Offset:0	Bit Width:16
        \ %x  16 lshift Ethernet_MAC_MACVLANTR        \ Ethernet_MAC_VLANTC	Bit Offset:16	Bit Width:1
        
        Ethernet_MAC $2C + constant Ethernet_MAC_MACPMTCSR	\ read-write		\  : RESET_Ethernet_MAC_MACPMTCSR $00000000 
        \ %x  0 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_PD	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_MPE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_WFE	Bit Offset:2	Bit Width:1
        \ %x  5 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_MPR	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_WFR	Bit Offset:6	Bit Width:1
        \ %x  9 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_GU	Bit Offset:9	Bit Width:1
        \ %x  31 lshift Ethernet_MAC_MACPMTCSR        \ Ethernet_MAC_WFFRPR	Bit Offset:31	Bit Width:1
        
        Ethernet_MAC $34 + constant Ethernet_MAC_MACDBGR	\ read-only		\  : RESET_Ethernet_MAC_MACDBGR $00000000 
        \ %x  0 lshift Ethernet_MAC_MACDBGR        \ Ethernet_MAC_CR	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_MAC_MACDBGR        \ Ethernet_MAC_CSR	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_MAC_MACDBGR        \ Ethernet_MAC_ROR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_MAC_MACDBGR        \ Ethernet_MAC_MCF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_MAC_MACDBGR        \ Ethernet_MAC_MCP	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_MAC_MACDBGR        \ Ethernet_MAC_MCFHP	Bit Offset:5	Bit Width:1
        
        Ethernet_MAC $38 + constant Ethernet_MAC_MACSR	\ 		\  : RESET_Ethernet_MAC_MACSR $00000000 
        \ %x  3 lshift Ethernet_MAC_MACSR        \ Ethernet_MAC_PMTS	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_MAC_MACSR        \ Ethernet_MAC_MMCS	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_MAC_MACSR        \ Ethernet_MAC_MMCRS	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_MAC_MACSR        \ Ethernet_MAC_MMCTS	Bit Offset:6	Bit Width:1
        \ %x  9 lshift Ethernet_MAC_MACSR        \ Ethernet_MAC_TSTS	Bit Offset:9	Bit Width:1
        
        Ethernet_MAC $3C + constant Ethernet_MAC_MACIMR	\ read-write		\  : RESET_Ethernet_MAC_MACIMR $00000000 
        \ %x  3 lshift Ethernet_MAC_MACIMR        \ Ethernet_MAC_PMTIM	Bit Offset:3	Bit Width:1
        \ %x  9 lshift Ethernet_MAC_MACIMR        \ Ethernet_MAC_TSTIM	Bit Offset:9	Bit Width:1
        
        Ethernet_MAC $40 + constant Ethernet_MAC_MACA0HR	\ 		\  : RESET_Ethernet_MAC_MACA0HR $0010FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA0HR        \ Ethernet_MAC_MACA0H	Bit Offset:0	Bit Width:16
        \ %x  31 lshift Ethernet_MAC_MACA0HR        \ Ethernet_MAC_MO	Bit Offset:31	Bit Width:1
        
        Ethernet_MAC $44 + constant Ethernet_MAC_MACA0LR	\ read-write		\  : RESET_Ethernet_MAC_MACA0LR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA0LR        \ Ethernet_MAC_MACA0L	Bit Offset:0	Bit Width:32
        
        Ethernet_MAC $48 + constant Ethernet_MAC_MACA1HR	\ read-write		\  : RESET_Ethernet_MAC_MACA1HR $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA1HR        \ Ethernet_MAC_MACA1H	Bit Offset:0	Bit Width:16
        \ %xxxxxx  24 lshift Ethernet_MAC_MACA1HR        \ Ethernet_MAC_MBC	Bit Offset:24	Bit Width:6
        \ %x  30 lshift Ethernet_MAC_MACA1HR        \ Ethernet_MAC_SA	Bit Offset:30	Bit Width:1
        \ %x  31 lshift Ethernet_MAC_MACA1HR        \ Ethernet_MAC_AE	Bit Offset:31	Bit Width:1
        
        Ethernet_MAC $4C + constant Ethernet_MAC_MACA1LR	\ read-write		\  : RESET_Ethernet_MAC_MACA1LR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA1LR        \ Ethernet_MAC_MACA1LR	Bit Offset:0	Bit Width:32
        
        Ethernet_MAC $50 + constant Ethernet_MAC_MACA2HR	\ read-write		\  : RESET_Ethernet_MAC_MACA2HR $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA2HR        \ Ethernet_MAC_MAC2AH	Bit Offset:0	Bit Width:16
        \ %xxxxxx  24 lshift Ethernet_MAC_MACA2HR        \ Ethernet_MAC_MBC	Bit Offset:24	Bit Width:6
        \ %x  30 lshift Ethernet_MAC_MACA2HR        \ Ethernet_MAC_SA	Bit Offset:30	Bit Width:1
        \ %x  31 lshift Ethernet_MAC_MACA2HR        \ Ethernet_MAC_AE	Bit Offset:31	Bit Width:1
        
        Ethernet_MAC $54 + constant Ethernet_MAC_MACA2LR	\ read-write		\  : RESET_Ethernet_MAC_MACA2LR $FFFFFFFF 
        \ % 0 lshift Ethernet_MAC_MACA2LR        \ Ethernet_MAC_MACA2L	Bit Offset:0	Bit Width:31
        
        Ethernet_MAC $58 + constant Ethernet_MAC_MACA3HR	\ read-write		\  : RESET_Ethernet_MAC_MACA3HR $0000FFFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA3HR        \ Ethernet_MAC_MACA3H	Bit Offset:0	Bit Width:16
        \ %xxxxxx  24 lshift Ethernet_MAC_MACA3HR        \ Ethernet_MAC_MBC	Bit Offset:24	Bit Width:6
        \ %x  30 lshift Ethernet_MAC_MACA3HR        \ Ethernet_MAC_SA	Bit Offset:30	Bit Width:1
        \ %x  31 lshift Ethernet_MAC_MACA3HR        \ Ethernet_MAC_AE	Bit Offset:31	Bit Width:1
        
        Ethernet_MAC $5C + constant Ethernet_MAC_MACA3LR	\ read-write		\  : RESET_Ethernet_MAC_MACA3LR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MAC_MACA3LR        \ Ethernet_MAC_MBCA3L	Bit Offset:0	Bit Width:32
        
         
	
     $40028100 constant Ethernet_MMC  
	 Ethernet_MMC $0 + constant Ethernet_MMC_MMCCR	\ read-write		\  : RESET_Ethernet_MMC_MMCCR $00000000 
        \ %x  0 lshift Ethernet_MMC_MMCCR        \ Ethernet_MMC_CR	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_MMC_MMCCR        \ Ethernet_MMC_CSR	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_MMC_MMCCR        \ Ethernet_MMC_ROR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_MMC_MMCCR        \ Ethernet_MMC_MCF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_MMC_MMCCR        \ Ethernet_MMC_MCP	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_MMC_MMCCR        \ Ethernet_MMC_MCFHP	Bit Offset:5	Bit Width:1
        
        Ethernet_MMC $4 + constant Ethernet_MMC_MMCRIR	\ read-write		\  : RESET_Ethernet_MMC_MMCRIR $00000000 
        \ %x  5 lshift Ethernet_MMC_MMCRIR        \ Ethernet_MMC_RFCES	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_MMC_MMCRIR        \ Ethernet_MMC_RFAES	Bit Offset:6	Bit Width:1
        \ %x  17 lshift Ethernet_MMC_MMCRIR        \ Ethernet_MMC_RGUFS	Bit Offset:17	Bit Width:1
        
        Ethernet_MMC $8 + constant Ethernet_MMC_MMCTIR	\ read-only		\  : RESET_Ethernet_MMC_MMCTIR $00000000 
        \ %x  14 lshift Ethernet_MMC_MMCTIR        \ Ethernet_MMC_TGFSCS	Bit Offset:14	Bit Width:1
        \ %x  15 lshift Ethernet_MMC_MMCTIR        \ Ethernet_MMC_TGFMSCS	Bit Offset:15	Bit Width:1
        \ %x  21 lshift Ethernet_MMC_MMCTIR        \ Ethernet_MMC_TGFS	Bit Offset:21	Bit Width:1
        
        Ethernet_MMC $C + constant Ethernet_MMC_MMCRIMR	\ read-write		\  : RESET_Ethernet_MMC_MMCRIMR $00000000 
        \ %x  5 lshift Ethernet_MMC_MMCRIMR        \ Ethernet_MMC_RFCEM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_MMC_MMCRIMR        \ Ethernet_MMC_RFAEM	Bit Offset:6	Bit Width:1
        \ %x  17 lshift Ethernet_MMC_MMCRIMR        \ Ethernet_MMC_RGUFM	Bit Offset:17	Bit Width:1
        
        Ethernet_MMC $10 + constant Ethernet_MMC_MMCTIMR	\ read-write		\  : RESET_Ethernet_MMC_MMCTIMR $00000000 
        \ %x  14 lshift Ethernet_MMC_MMCTIMR        \ Ethernet_MMC_TGFSCM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift Ethernet_MMC_MMCTIMR        \ Ethernet_MMC_TGFMSCM	Bit Offset:15	Bit Width:1
        \ %x  16 lshift Ethernet_MMC_MMCTIMR        \ Ethernet_MMC_TGFM	Bit Offset:16	Bit Width:1
        
        Ethernet_MMC $4C + constant Ethernet_MMC_MMCTGFSCCR	\ read-only		\  : RESET_Ethernet_MMC_MMCTGFSCCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MMC_MMCTGFSCCR        \ Ethernet_MMC_TGFSCC	Bit Offset:0	Bit Width:32
        
        Ethernet_MMC $50 + constant Ethernet_MMC_MMCTGFMSCCR	\ read-only		\  : RESET_Ethernet_MMC_MMCTGFMSCCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MMC_MMCTGFMSCCR        \ Ethernet_MMC_TGFMSCC	Bit Offset:0	Bit Width:32
        
        Ethernet_MMC $68 + constant Ethernet_MMC_MMCTGFCR	\ read-only		\  : RESET_Ethernet_MMC_MMCTGFCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MMC_MMCTGFCR        \ Ethernet_MMC_TGFC	Bit Offset:0	Bit Width:32
        
        Ethernet_MMC $94 + constant Ethernet_MMC_MMCRFCECR	\ read-only		\  : RESET_Ethernet_MMC_MMCRFCECR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MMC_MMCRFCECR        \ Ethernet_MMC_RFCFC	Bit Offset:0	Bit Width:32
        
        Ethernet_MMC $98 + constant Ethernet_MMC_MMCRFAECR	\ read-only		\  : RESET_Ethernet_MMC_MMCRFAECR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MMC_MMCRFAECR        \ Ethernet_MMC_RFAEC	Bit Offset:0	Bit Width:32
        
        Ethernet_MMC $C4 + constant Ethernet_MMC_MMCRGUFCR	\ read-only		\  : RESET_Ethernet_MMC_MMCRGUFCR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_MMC_MMCRGUFCR        \ Ethernet_MMC_RGUFC	Bit Offset:0	Bit Width:32
        
         
	
     $40028700 constant Ethernet_PTP  
	 Ethernet_PTP $0 + constant Ethernet_PTP_PTPTSCR	\ read-write		\  : RESET_Ethernet_PTP_PTPTSCR $00002000 
        \ %x  0 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSFCU	Bit Offset:1	Bit Width:1
        \ %x  10 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSPTPPSV2E	Bit Offset:10	Bit Width:1
        \ %x  11 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSPTPOEFE	Bit Offset:11	Bit Width:1
        \ %x  12 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSIPV6FE	Bit Offset:12	Bit Width:1
        \ %x  13 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSIPV4FE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSEME	Bit Offset:14	Bit Width:1
        \ %x  15 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSMRME	Bit Offset:15	Bit Width:1
        \ %xx  16 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSCNT	Bit Offset:16	Bit Width:2
        \ %x  18 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSPFFMAE	Bit Offset:18	Bit Width:1
        \ %x  2 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSTI	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSTU	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSITE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TTSARU	Bit Offset:5	Bit Width:1
        \ %x  8 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSARFE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift Ethernet_PTP_PTPTSCR        \ Ethernet_PTP_TSSSR	Bit Offset:9	Bit Width:1
        
        Ethernet_PTP $4 + constant Ethernet_PTP_PTPSSIR	\ read-write		\  : RESET_Ethernet_PTP_PTPSSIR $00000000 
        \ %xxxxxxxx  0 lshift Ethernet_PTP_PTPSSIR        \ Ethernet_PTP_STSSI	Bit Offset:0	Bit Width:8
        
        Ethernet_PTP $8 + constant Ethernet_PTP_PTPTSHR	\ read-only		\  : RESET_Ethernet_PTP_PTPTSHR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_PTP_PTPTSHR        \ Ethernet_PTP_STS	Bit Offset:0	Bit Width:32
        
        Ethernet_PTP $C + constant Ethernet_PTP_PTPTSLR	\ read-only		\  : RESET_Ethernet_PTP_PTPTSLR $00000000 
        \ % 0 lshift Ethernet_PTP_PTPTSLR        \ Ethernet_PTP_STSS	Bit Offset:0	Bit Width:31
        \ %x  31 lshift Ethernet_PTP_PTPTSLR        \ Ethernet_PTP_STPNS	Bit Offset:31	Bit Width:1
        
        Ethernet_PTP $10 + constant Ethernet_PTP_PTPTSHUR	\ read-write		\  : RESET_Ethernet_PTP_PTPTSHUR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_PTP_PTPTSHUR        \ Ethernet_PTP_TSUS	Bit Offset:0	Bit Width:32
        
        Ethernet_PTP $14 + constant Ethernet_PTP_PTPTSLUR	\ read-write		\  : RESET_Ethernet_PTP_PTPTSLUR $00000000 
        \ % 0 lshift Ethernet_PTP_PTPTSLUR        \ Ethernet_PTP_TSUSS	Bit Offset:0	Bit Width:31
        \ %x  31 lshift Ethernet_PTP_PTPTSLUR        \ Ethernet_PTP_TSUPNS	Bit Offset:31	Bit Width:1
        
        Ethernet_PTP $18 + constant Ethernet_PTP_PTPTSAR	\ read-write		\  : RESET_Ethernet_PTP_PTPTSAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_PTP_PTPTSAR        \ Ethernet_PTP_TSA	Bit Offset:0	Bit Width:32
        
        Ethernet_PTP $1C + constant Ethernet_PTP_PTPTTHR	\ read-write		\  : RESET_Ethernet_PTP_PTPTTHR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_PTP_PTPTTHR        \ Ethernet_PTP_TTSH	Bit Offset:0	Bit Width:32
        
        Ethernet_PTP $20 + constant Ethernet_PTP_PTPTTLR	\ read-write		\  : RESET_Ethernet_PTP_PTPTTLR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_PTP_PTPTTLR        \ Ethernet_PTP_TTSL	Bit Offset:0	Bit Width:32
        
        Ethernet_PTP $28 + constant Ethernet_PTP_PTPTSSR	\ read-only		\  : RESET_Ethernet_PTP_PTPTSSR $00000000 
        \ %x  0 lshift Ethernet_PTP_PTPTSSR        \ Ethernet_PTP_TSSO	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_PTP_PTPTSSR        \ Ethernet_PTP_TSTTR	Bit Offset:1	Bit Width:1
        
        Ethernet_PTP $2C + constant Ethernet_PTP_PTPPPSCR	\ read-only		\  : RESET_Ethernet_PTP_PTPPPSCR $00000000 
        \ %x  0 lshift Ethernet_PTP_PTPPPSCR        \ Ethernet_PTP_TSSO	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_PTP_PTPPPSCR        \ Ethernet_PTP_TSTTR	Bit Offset:1	Bit Width:1
        
         
	
     $40029000 constant Ethernet_DMA  
	 Ethernet_DMA $0 + constant Ethernet_DMA_DMABMR	\ read-write		\  : RESET_Ethernet_DMA_DMABMR $00002101 
        \ %x  0 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_SR	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_DA	Bit Offset:1	Bit Width:1
        \ %xxxxx  2 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_DSL	Bit Offset:2	Bit Width:5
        \ %x  7 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_EDFE	Bit Offset:7	Bit Width:1
        \ %xxxxxx  8 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_PBL	Bit Offset:8	Bit Width:6
        \ %xx  14 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_RTPR	Bit Offset:14	Bit Width:2
        \ %x  16 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_FB	Bit Offset:16	Bit Width:1
        \ %xxxxxx  17 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_RDP	Bit Offset:17	Bit Width:6
        \ %x  23 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_USP	Bit Offset:23	Bit Width:1
        \ %x  24 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_FPM	Bit Offset:24	Bit Width:1
        \ %x  25 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_AAB	Bit Offset:25	Bit Width:1
        \ %x  26 lshift Ethernet_DMA_DMABMR        \ Ethernet_DMA_MB	Bit Offset:26	Bit Width:1
        
        Ethernet_DMA $4 + constant Ethernet_DMA_DMATPDR	\ read-write		\  : RESET_Ethernet_DMA_DMATPDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMATPDR        \ Ethernet_DMA_TPD	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $8 + constant Ethernet_DMA_DMARPDR	\ read-write		\  : RESET_Ethernet_DMA_DMARPDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMARPDR        \ Ethernet_DMA_RPD	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $C + constant Ethernet_DMA_DMARDLAR	\ read-write		\  : RESET_Ethernet_DMA_DMARDLAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMARDLAR        \ Ethernet_DMA_SRL	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $10 + constant Ethernet_DMA_DMATDLAR	\ read-write		\  : RESET_Ethernet_DMA_DMATDLAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMATDLAR        \ Ethernet_DMA_STL	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $14 + constant Ethernet_DMA_DMASR	\ 		\  : RESET_Ethernet_DMA_DMASR $00000000 
        \ %x  0 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TPSS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TBUS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TJTS	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_ROS	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TUS	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_RS	Bit Offset:6	Bit Width:1
        \ %x  7 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_RBUS	Bit Offset:7	Bit Width:1
        \ %x  8 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_RPSS	Bit Offset:8	Bit Width:1
        \ %x  9 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_PWTS	Bit Offset:9	Bit Width:1
        \ %x  10 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_ETS	Bit Offset:10	Bit Width:1
        \ %x  13 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_FBES	Bit Offset:13	Bit Width:1
        \ %x  14 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_ERS	Bit Offset:14	Bit Width:1
        \ %x  15 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_AIS	Bit Offset:15	Bit Width:1
        \ %x  16 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_NIS	Bit Offset:16	Bit Width:1
        \ %xxx  17 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_RPS	Bit Offset:17	Bit Width:3
        \ %xxx  20 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TPS	Bit Offset:20	Bit Width:3
        \ %xxx  23 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_EBS	Bit Offset:23	Bit Width:3
        \ %x  27 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_MMCS	Bit Offset:27	Bit Width:1
        \ %x  28 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_PMTS	Bit Offset:28	Bit Width:1
        \ %x  29 lshift Ethernet_DMA_DMASR        \ Ethernet_DMA_TSTS	Bit Offset:29	Bit Width:1
        
        Ethernet_DMA $18 + constant Ethernet_DMA_DMAOMR	\ read-write		\  : RESET_Ethernet_DMA_DMAOMR $00000000 
        \ %x  1 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_SR	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_OSF	Bit Offset:2	Bit Width:1
        \ %xx  3 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_RTC	Bit Offset:3	Bit Width:2
        \ %x  6 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_FUGF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_FEF	Bit Offset:7	Bit Width:1
        \ %x  13 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_ST	Bit Offset:13	Bit Width:1
        \ %xxx  14 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_TTC	Bit Offset:14	Bit Width:3
        \ %x  20 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_FTF	Bit Offset:20	Bit Width:1
        \ %x  21 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_TSF	Bit Offset:21	Bit Width:1
        \ %x  24 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_DFRF	Bit Offset:24	Bit Width:1
        \ %x  25 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_RSF	Bit Offset:25	Bit Width:1
        \ %x  26 lshift Ethernet_DMA_DMAOMR        \ Ethernet_DMA_DTCEFD	Bit Offset:26	Bit Width:1
        
        Ethernet_DMA $1C + constant Ethernet_DMA_DMAIER	\ read-write		\  : RESET_Ethernet_DMA_DMAIER $00000000 
        \ %x  0 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_TIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_TPSIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_TBUIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_TJTIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_ROIE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_TUIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_RIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_RBUIE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_RPSIE	Bit Offset:8	Bit Width:1
        \ %x  9 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_RWTIE	Bit Offset:9	Bit Width:1
        \ %x  10 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_ETIE	Bit Offset:10	Bit Width:1
        \ %x  13 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_FBEIE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_ERIE	Bit Offset:14	Bit Width:1
        \ %x  15 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_AISE	Bit Offset:15	Bit Width:1
        \ %x  16 lshift Ethernet_DMA_DMAIER        \ Ethernet_DMA_NISE	Bit Offset:16	Bit Width:1
        
        Ethernet_DMA $20 + constant Ethernet_DMA_DMAMFBOCR	\ read-write		\  : RESET_Ethernet_DMA_DMAMFBOCR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMAMFBOCR        \ Ethernet_DMA_MFC	Bit Offset:0	Bit Width:16
        \ %x  16 lshift Ethernet_DMA_DMAMFBOCR        \ Ethernet_DMA_OMFC	Bit Offset:16	Bit Width:1
        \ % 17 lshift Ethernet_DMA_DMAMFBOCR        \ Ethernet_DMA_MFA	Bit Offset:17	Bit Width:11
        \ %x  28 lshift Ethernet_DMA_DMAMFBOCR        \ Ethernet_DMA_OFOC	Bit Offset:28	Bit Width:1
        
        Ethernet_DMA $24 + constant Ethernet_DMA_DMARSWTR	\ read-write		\  : RESET_Ethernet_DMA_DMARSWTR $00000000 
        \ %xxxxxxxx  0 lshift Ethernet_DMA_DMARSWTR        \ Ethernet_DMA_RSWTC	Bit Offset:0	Bit Width:8
        
        Ethernet_DMA $48 + constant Ethernet_DMA_DMACHTDR	\ read-only		\  : RESET_Ethernet_DMA_DMACHTDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMACHTDR        \ Ethernet_DMA_HTDAP	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $4C + constant Ethernet_DMA_DMACHRDR	\ read-only		\  : RESET_Ethernet_DMA_DMACHRDR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMACHRDR        \ Ethernet_DMA_HRDAP	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $50 + constant Ethernet_DMA_DMACHTBAR	\ read-only		\  : RESET_Ethernet_DMA_DMACHTBAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMACHTBAR        \ Ethernet_DMA_HTBAP	Bit Offset:0	Bit Width:32
        
        Ethernet_DMA $54 + constant Ethernet_DMA_DMACHRBAR	\ read-only		\  : RESET_Ethernet_DMA_DMACHRBAR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift Ethernet_DMA_DMACHRBAR        \ Ethernet_DMA_HRBAP	Bit Offset:0	Bit Width:32
        
         
	
     $40023000 constant CRC  
	 CRC $0 + constant CRC_DR	\ read-write		\  : RESET_CRC_DR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift CRC_DR        \ CRC_DR	Bit Offset:0	Bit Width:32
        
        CRC $4 + constant CRC_IDR	\ read-write		\  : RESET_CRC_IDR $00000000 
        \ %xxxxxxxx  0 lshift CRC_IDR        \ CRC_IDR	Bit Offset:0	Bit Width:8
        
        CRC $8 + constant CRC_CR	\ write-only		\  : RESET_CRC_CR $00000000 
        \ %x  0 lshift CRC_CR        \ CRC_CR	Bit Offset:0	Bit Width:1
        
         
	
     $50000000 constant OTG_FS_GLOBAL  
	 OTG_FS_GLOBAL $0 + constant OTG_FS_GLOBAL_FS_GOTGCTL	\ 		\  : RESET_OTG_FS_GLOBAL_FS_GOTGCTL $00000800 
        \ %x  0 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_SRQSCS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_SRQ	Bit Offset:1	Bit Width:1
        \ %x  8 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_HNGSCS	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_HNPRQ	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_HSHNPEN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_DHNPEN	Bit Offset:11	Bit Width:1
        \ %x  16 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_CIDSTS	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_DBCT	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_ASVLD	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_FS_GLOBAL_FS_GOTGCTL        \ OTG_FS_GLOBAL_BSVLD	Bit Offset:19	Bit Width:1
        
        OTG_FS_GLOBAL $4 + constant OTG_FS_GLOBAL_FS_GOTGINT	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_GOTGINT $00000000 
        \ %x  2 lshift OTG_FS_GLOBAL_FS_GOTGINT        \ OTG_FS_GLOBAL_SEDET	Bit Offset:2	Bit Width:1
        \ %x  8 lshift OTG_FS_GLOBAL_FS_GOTGINT        \ OTG_FS_GLOBAL_SRSSCHG	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_GLOBAL_FS_GOTGINT        \ OTG_FS_GLOBAL_HNSSCHG	Bit Offset:9	Bit Width:1
        \ %x  17 lshift OTG_FS_GLOBAL_FS_GOTGINT        \ OTG_FS_GLOBAL_HNGDET	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_FS_GLOBAL_FS_GOTGINT        \ OTG_FS_GLOBAL_ADTOCHG	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_FS_GLOBAL_FS_GOTGINT        \ OTG_FS_GLOBAL_DBCDNE	Bit Offset:19	Bit Width:1
        
        OTG_FS_GLOBAL $8 + constant OTG_FS_GLOBAL_FS_GAHBCFG	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_GAHBCFG $00000000 
        \ %x  0 lshift OTG_FS_GLOBAL_FS_GAHBCFG        \ OTG_FS_GLOBAL_GINT	Bit Offset:0	Bit Width:1
        \ %x  7 lshift OTG_FS_GLOBAL_FS_GAHBCFG        \ OTG_FS_GLOBAL_TXFELVL	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_GLOBAL_FS_GAHBCFG        \ OTG_FS_GLOBAL_PTXFELVL	Bit Offset:8	Bit Width:1
        
        OTG_FS_GLOBAL $C + constant OTG_FS_GLOBAL_FS_GUSBCFG	\ 		\  : RESET_OTG_FS_GLOBAL_FS_GUSBCFG $00000A00 
        \ %xxx  0 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_TOCAL	Bit Offset:0	Bit Width:3
        \ %x  6 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_PHYSEL	Bit Offset:6	Bit Width:1
        \ %x  8 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_SRPCAP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_HNPCAP	Bit Offset:9	Bit Width:1
        \ %xxxx  10 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_TRDT	Bit Offset:10	Bit Width:4
        \ %x  29 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_FHMOD	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_FDMOD	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_GLOBAL_FS_GUSBCFG        \ OTG_FS_GLOBAL_CTXPKT	Bit Offset:31	Bit Width:1
        
        OTG_FS_GLOBAL $10 + constant OTG_FS_GLOBAL_FS_GRSTCTL	\ 		\  : RESET_OTG_FS_GLOBAL_FS_GRSTCTL $20000000 
        \ %x  0 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_CSRST	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_HSRST	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_FCRST	Bit Offset:2	Bit Width:1
        \ %x  4 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_RXFFLSH	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_TXFFLSH	Bit Offset:5	Bit Width:1
        \ %xxxxx  6 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_TXFNUM	Bit Offset:6	Bit Width:5
        \ %x  31 lshift OTG_FS_GLOBAL_FS_GRSTCTL        \ OTG_FS_GLOBAL_AHBIDL	Bit Offset:31	Bit Width:1
        
        OTG_FS_GLOBAL $14 + constant OTG_FS_GLOBAL_FS_GINTSTS	\ 		\  : RESET_OTG_FS_GLOBAL_FS_GINTSTS $04000020 
        \ %x  0 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_CMOD	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_MMIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_OTGINT	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_SOF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_RXFLVL	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_NPTXFE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_GINAKEFF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_GOUTNAKEFF	Bit Offset:7	Bit Width:1
        \ %x  10 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_ESUSP	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_USBSUSP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_USBRST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_ENUMDNE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_ISOODRP	Bit Offset:14	Bit Width:1
        \ %x  15 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_EOPF	Bit Offset:15	Bit Width:1
        \ %x  18 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_IEPINT	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_OEPINT	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_IISOIXFR	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_IPXFR_INCOMPISOOUT	Bit Offset:21	Bit Width:1
        \ %x  24 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_HPRTINT	Bit Offset:24	Bit Width:1
        \ %x  25 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_HCINT	Bit Offset:25	Bit Width:1
        \ %x  26 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_PTXFE	Bit Offset:26	Bit Width:1
        \ %x  28 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_CIDSCHG	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_DISCINT	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_SRQINT	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_GLOBAL_FS_GINTSTS        \ OTG_FS_GLOBAL_WKUPINT	Bit Offset:31	Bit Width:1
        
        OTG_FS_GLOBAL $18 + constant OTG_FS_GLOBAL_FS_GINTMSK	\ 		\  : RESET_OTG_FS_GLOBAL_FS_GINTMSK $00000000 
        \ %x  1 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_MMISM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_OTGINT	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_SOFM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_RXFLVLM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_NPTXFEM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_GINAKEFFM	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_GONAKEFFM	Bit Offset:7	Bit Width:1
        \ %x  10 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_ESUSPM	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_USBSUSPM	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_USBRST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_ENUMDNEM	Bit Offset:13	Bit Width:1
        \ %x  14 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_ISOODRPM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_EOPFM	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_EPMISM	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_IEPINT	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_OEPINT	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_IISOIXFRM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_IPXFRM_IISOOXFRM	Bit Offset:21	Bit Width:1
        \ %x  24 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_PRTIM	Bit Offset:24	Bit Width:1
        \ %x  25 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_HCIM	Bit Offset:25	Bit Width:1
        \ %x  26 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_PTXFEM	Bit Offset:26	Bit Width:1
        \ %x  28 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_CIDSCHGM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_DISCINT	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_SRQIM	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_GLOBAL_FS_GINTMSK        \ OTG_FS_GLOBAL_WUIM	Bit Offset:31	Bit Width:1
        
        OTG_FS_GLOBAL $1C + constant OTG_FS_GLOBAL_FS_GRXSTSR_Device	\ read-only		\  : RESET_OTG_FS_GLOBAL_FS_GRXSTSR_Device $00000000 
        \ %xxxx  0 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Device        \ OTG_FS_GLOBAL_EPNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Device        \ OTG_FS_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Device        \ OTG_FS_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Device        \ OTG_FS_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        \ %xxxx  21 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Device        \ OTG_FS_GLOBAL_FRMNUM	Bit Offset:21	Bit Width:4
        
        OTG_FS_GLOBAL $1C + constant OTG_FS_GLOBAL_FS_GRXSTSR_Host	\ read-only		\  : RESET_OTG_FS_GLOBAL_FS_GRXSTSR_Host $00000000 
        \ %xxxx  0 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Host        \ OTG_FS_GLOBAL_EPNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Host        \ OTG_FS_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Host        \ OTG_FS_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Host        \ OTG_FS_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        \ %xxxx  21 lshift OTG_FS_GLOBAL_FS_GRXSTSR_Host        \ OTG_FS_GLOBAL_FRMNUM	Bit Offset:21	Bit Width:4
        
        OTG_FS_GLOBAL $24 + constant OTG_FS_GLOBAL_FS_GRXFSIZ	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_GRXFSIZ $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_GRXFSIZ        \ OTG_FS_GLOBAL_RXFD	Bit Offset:0	Bit Width:16
        
        OTG_FS_GLOBAL $28 + constant OTG_FS_GLOBAL_FS_GNPTXFSIZ_Device	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_GNPTXFSIZ_Device $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_GNPTXFSIZ_Device        \ OTG_FS_GLOBAL_TX0FSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_GNPTXFSIZ_Device        \ OTG_FS_GLOBAL_TX0FD	Bit Offset:16	Bit Width:16
        
        OTG_FS_GLOBAL $28 + constant OTG_FS_GLOBAL_FS_GNPTXFSIZ_Host	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_GNPTXFSIZ_Host $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_GNPTXFSIZ_Host        \ OTG_FS_GLOBAL_NPTXFSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_GNPTXFSIZ_Host        \ OTG_FS_GLOBAL_NPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_FS_GLOBAL $2C + constant OTG_FS_GLOBAL_FS_GNPTXSTS	\ read-only		\  : RESET_OTG_FS_GLOBAL_FS_GNPTXSTS $00080200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_GNPTXSTS        \ OTG_FS_GLOBAL_NPTXFSAV	Bit Offset:0	Bit Width:16
        \ %xxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_GNPTXSTS        \ OTG_FS_GLOBAL_NPTQXSAV	Bit Offset:16	Bit Width:8
        \ %xxxxxxx  24 lshift OTG_FS_GLOBAL_FS_GNPTXSTS        \ OTG_FS_GLOBAL_NPTXQTOP	Bit Offset:24	Bit Width:7
        
        OTG_FS_GLOBAL $38 + constant OTG_FS_GLOBAL_FS_GCCFG	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_GCCFG $00000000 
        \ %x  16 lshift OTG_FS_GLOBAL_FS_GCCFG        \ OTG_FS_GLOBAL_PWRDWN	Bit Offset:16	Bit Width:1
        \ %x  18 lshift OTG_FS_GLOBAL_FS_GCCFG        \ OTG_FS_GLOBAL_VBUSASEN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_FS_GLOBAL_FS_GCCFG        \ OTG_FS_GLOBAL_VBUSBSEN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_FS_GLOBAL_FS_GCCFG        \ OTG_FS_GLOBAL_SOFOUTEN	Bit Offset:20	Bit Width:1
        
        OTG_FS_GLOBAL $3C + constant OTG_FS_GLOBAL_FS_CID	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_CID $00001000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_CID        \ OTG_FS_GLOBAL_PRODUCT_ID	Bit Offset:0	Bit Width:32
        
        OTG_FS_GLOBAL $100 + constant OTG_FS_GLOBAL_FS_HPTXFSIZ	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_HPTXFSIZ $02000600 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_HPTXFSIZ        \ OTG_FS_GLOBAL_PTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_HPTXFSIZ        \ OTG_FS_GLOBAL_PTXFSIZ	Bit Offset:16	Bit Width:16
        
        OTG_FS_GLOBAL $104 + constant OTG_FS_GLOBAL_FS_DIEPTXF1	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_DIEPTXF1 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_DIEPTXF1        \ OTG_FS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_DIEPTXF1        \ OTG_FS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_FS_GLOBAL $108 + constant OTG_FS_GLOBAL_FS_DIEPTXF2	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_DIEPTXF2 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_DIEPTXF2        \ OTG_FS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_DIEPTXF2        \ OTG_FS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_FS_GLOBAL $10C + constant OTG_FS_GLOBAL_FS_DIEPTXF3	\ read-write		\  : RESET_OTG_FS_GLOBAL_FS_DIEPTXF3 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_GLOBAL_FS_DIEPTXF3        \ OTG_FS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_GLOBAL_FS_DIEPTXF3        \ OTG_FS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
         
	
     $50000400 constant OTG_FS_HOST  
	 OTG_FS_HOST $0 + constant OTG_FS_HOST_FS_HCFG	\ 		\  : RESET_OTG_FS_HOST_FS_HCFG $00000000 
        \ %xx  0 lshift OTG_FS_HOST_FS_HCFG        \ OTG_FS_HOST_FSLSPCS	Bit Offset:0	Bit Width:2
        \ %x  2 lshift OTG_FS_HOST_FS_HCFG        \ OTG_FS_HOST_FSLSS	Bit Offset:2	Bit Width:1
        
        OTG_FS_HOST $4 + constant OTG_FS_HOST_HFIR	\ read-write		\  : RESET_OTG_FS_HOST_HFIR $0000EA60 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_HOST_HFIR        \ OTG_FS_HOST_FRIVL	Bit Offset:0	Bit Width:16
        
        OTG_FS_HOST $8 + constant OTG_FS_HOST_FS_HFNUM	\ read-only		\  : RESET_OTG_FS_HOST_FS_HFNUM $00003FFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_HOST_FS_HFNUM        \ OTG_FS_HOST_FRNUM	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_HOST_FS_HFNUM        \ OTG_FS_HOST_FTREM	Bit Offset:16	Bit Width:16
        
        OTG_FS_HOST $10 + constant OTG_FS_HOST_FS_HPTXSTS	\ 		\  : RESET_OTG_FS_HOST_FS_HPTXSTS $00080100 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_HOST_FS_HPTXSTS        \ OTG_FS_HOST_PTXFSAVL	Bit Offset:0	Bit Width:16
        \ %xxxxxxxx  16 lshift OTG_FS_HOST_FS_HPTXSTS        \ OTG_FS_HOST_PTXQSAV	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift OTG_FS_HOST_FS_HPTXSTS        \ OTG_FS_HOST_PTXQTOP	Bit Offset:24	Bit Width:8
        
        OTG_FS_HOST $14 + constant OTG_FS_HOST_HAINT	\ read-only		\  : RESET_OTG_FS_HOST_HAINT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_HOST_HAINT        \ OTG_FS_HOST_HAINT	Bit Offset:0	Bit Width:16
        
        OTG_FS_HOST $18 + constant OTG_FS_HOST_HAINTMSK	\ read-write		\  : RESET_OTG_FS_HOST_HAINTMSK $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_HOST_HAINTMSK        \ OTG_FS_HOST_HAINTM	Bit Offset:0	Bit Width:16
        
        OTG_FS_HOST $40 + constant OTG_FS_HOST_FS_HPRT	\ 		\  : RESET_OTG_FS_HOST_FS_HPRT $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PCSTS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PCDET	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PENA	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PENCHNG	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_POCA	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_POCCHNG	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PRES	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PSUSP	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PRST	Bit Offset:8	Bit Width:1
        \ %xx  10 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PLSTS	Bit Offset:10	Bit Width:2
        \ %x  12 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PPWR	Bit Offset:12	Bit Width:1
        \ %xxxx  13 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PTCTL	Bit Offset:13	Bit Width:4
        \ %xx  17 lshift OTG_FS_HOST_FS_HPRT        \ OTG_FS_HOST_PSPD	Bit Offset:17	Bit Width:2
        
        OTG_FS_HOST $100 + constant OTG_FS_HOST_FS_HCCHAR0	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR0 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR0        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $120 + constant OTG_FS_HOST_FS_HCCHAR1	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR1 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR1        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $140 + constant OTG_FS_HOST_FS_HCCHAR2	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR2 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR2        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $160 + constant OTG_FS_HOST_FS_HCCHAR3	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR3 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR3        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $180 + constant OTG_FS_HOST_FS_HCCHAR4	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR4 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR4        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $1A0 + constant OTG_FS_HOST_FS_HCCHAR5	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR5 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR5        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $1C0 + constant OTG_FS_HOST_FS_HCCHAR6	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR6 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR6        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $1E0 + constant OTG_FS_HOST_FS_HCCHAR7	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCCHAR7 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_MCNT	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_HOST_FS_HCCHAR7        \ OTG_FS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_HOST $108 + constant OTG_FS_HOST_FS_HCINT0	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT0 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT0        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $128 + constant OTG_FS_HOST_FS_HCINT1	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT1 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT1        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $148 + constant OTG_FS_HOST_FS_HCINT2	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT2 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT2        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $168 + constant OTG_FS_HOST_FS_HCINT3	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT3 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT3        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $188 + constant OTG_FS_HOST_FS_HCINT4	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT4 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT4        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $1A8 + constant OTG_FS_HOST_FS_HCINT5	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT5 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT5        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $1C8 + constant OTG_FS_HOST_FS_HCINT6	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT6 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT6        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $1E8 + constant OTG_FS_HOST_FS_HCINT7	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINT7 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINT7        \ OTG_FS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $10C + constant OTG_FS_HOST_FS_HCINTMSK0	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK0 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK0        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $12C + constant OTG_FS_HOST_FS_HCINTMSK1	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK1 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK1        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $14C + constant OTG_FS_HOST_FS_HCINTMSK2	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK2 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK2        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $16C + constant OTG_FS_HOST_FS_HCINTMSK3	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK3 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK3        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $18C + constant OTG_FS_HOST_FS_HCINTMSK4	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK4 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK4        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $1AC + constant OTG_FS_HOST_FS_HCINTMSK5	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK5 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK5        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $1CC + constant OTG_FS_HOST_FS_HCINTMSK6	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK6 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK6        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $1EC + constant OTG_FS_HOST_FS_HCINTMSK7	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCINTMSK7 $00000000 
        \ %x  0 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_HOST_FS_HCINTMSK7        \ OTG_FS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_FS_HOST $110 + constant OTG_FS_HOST_FS_HCTSIZ0	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ0 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ0        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ0        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ0        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $130 + constant OTG_FS_HOST_FS_HCTSIZ1	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ1 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ1        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ1        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ1        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $150 + constant OTG_FS_HOST_FS_HCTSIZ2	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ2 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ2        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ2        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ2        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $170 + constant OTG_FS_HOST_FS_HCTSIZ3	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ3 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ3        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ3        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ3        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $190 + constant OTG_FS_HOST_FS_HCTSIZ4	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ4 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ4        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ4        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ4        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $1B0 + constant OTG_FS_HOST_FS_HCTSIZ5	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ5 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ5        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ5        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ5        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $1D0 + constant OTG_FS_HOST_FS_HCTSIZ6	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ6 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ6        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ6        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ6        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_FS_HOST $1F0 + constant OTG_FS_HOST_FS_HCTSIZ7	\ read-write		\  : RESET_OTG_FS_HOST_FS_HCTSIZ7 $00000000 
        \ % 0 lshift OTG_FS_HOST_FS_HCTSIZ7        \ OTG_FS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_FS_HOST_FS_HCTSIZ7        \ OTG_FS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_FS_HOST_FS_HCTSIZ7        \ OTG_FS_HOST_DPID	Bit Offset:29	Bit Width:2
        
         
	
     $50000800 constant OTG_FS_DEVICE  
	 OTG_FS_DEVICE $0 + constant OTG_FS_DEVICE_FS_DCFG	\ read-write		\  : RESET_OTG_FS_DEVICE_FS_DCFG $02200000 
        \ %xx  0 lshift OTG_FS_DEVICE_FS_DCFG        \ OTG_FS_DEVICE_DSPD	Bit Offset:0	Bit Width:2
        \ %x  2 lshift OTG_FS_DEVICE_FS_DCFG        \ OTG_FS_DEVICE_NZLSOHSK	Bit Offset:2	Bit Width:1
        \ %xxxxxxx  4 lshift OTG_FS_DEVICE_FS_DCFG        \ OTG_FS_DEVICE_DAD	Bit Offset:4	Bit Width:7
        \ %xx  11 lshift OTG_FS_DEVICE_FS_DCFG        \ OTG_FS_DEVICE_PFIVL	Bit Offset:11	Bit Width:2
        
        OTG_FS_DEVICE $4 + constant OTG_FS_DEVICE_FS_DCTL	\ 		\  : RESET_OTG_FS_DEVICE_FS_DCTL $00000000 
        \ %x  0 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_RWUSIG	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_SDIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_GINSTS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_GONSTS	Bit Offset:3	Bit Width:1
        \ %xxx  4 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_TCTL	Bit Offset:4	Bit Width:3
        \ %x  7 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_SGINAK	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_CGINAK	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_SGONAK	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_CGONAK	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_FS_DEVICE_FS_DCTL        \ OTG_FS_DEVICE_POPRGDNE	Bit Offset:11	Bit Width:1
        
        OTG_FS_DEVICE $8 + constant OTG_FS_DEVICE_FS_DSTS	\ read-only		\  : RESET_OTG_FS_DEVICE_FS_DSTS $00000010 
        \ %x  0 lshift OTG_FS_DEVICE_FS_DSTS        \ OTG_FS_DEVICE_SUSPSTS	Bit Offset:0	Bit Width:1
        \ %xx  1 lshift OTG_FS_DEVICE_FS_DSTS        \ OTG_FS_DEVICE_ENUMSPD	Bit Offset:1	Bit Width:2
        \ %x  3 lshift OTG_FS_DEVICE_FS_DSTS        \ OTG_FS_DEVICE_EERR	Bit Offset:3	Bit Width:1
        \ %xxxxxxxxxxxxxx  8 lshift OTG_FS_DEVICE_FS_DSTS        \ OTG_FS_DEVICE_FNSOF	Bit Offset:8	Bit Width:14
        
        OTG_FS_DEVICE $10 + constant OTG_FS_DEVICE_FS_DIEPMSK	\ read-write		\  : RESET_OTG_FS_DEVICE_FS_DIEPMSK $00000000 
        \ %x  0 lshift OTG_FS_DEVICE_FS_DIEPMSK        \ OTG_FS_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_FS_DIEPMSK        \ OTG_FS_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_FS_DIEPMSK        \ OTG_FS_DEVICE_TOM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_FS_DIEPMSK        \ OTG_FS_DEVICE_ITTXFEMSK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_FS_DEVICE_FS_DIEPMSK        \ OTG_FS_DEVICE_INEPNMM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_FS_DEVICE_FS_DIEPMSK        \ OTG_FS_DEVICE_INEPNEM	Bit Offset:6	Bit Width:1
        
        OTG_FS_DEVICE $14 + constant OTG_FS_DEVICE_FS_DOEPMSK	\ read-write		\  : RESET_OTG_FS_DEVICE_FS_DOEPMSK $00000000 
        \ %x  0 lshift OTG_FS_DEVICE_FS_DOEPMSK        \ OTG_FS_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_FS_DOEPMSK        \ OTG_FS_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_FS_DOEPMSK        \ OTG_FS_DEVICE_STUPM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_FS_DOEPMSK        \ OTG_FS_DEVICE_OTEPDM	Bit Offset:4	Bit Width:1
        
        OTG_FS_DEVICE $18 + constant OTG_FS_DEVICE_FS_DAINT	\ read-only		\  : RESET_OTG_FS_DEVICE_FS_DAINT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_FS_DAINT        \ OTG_FS_DEVICE_IEPINT	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_DEVICE_FS_DAINT        \ OTG_FS_DEVICE_OEPINT	Bit Offset:16	Bit Width:16
        
        OTG_FS_DEVICE $1C + constant OTG_FS_DEVICE_FS_DAINTMSK	\ read-write		\  : RESET_OTG_FS_DEVICE_FS_DAINTMSK $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_FS_DAINTMSK        \ OTG_FS_DEVICE_IEPM	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_FS_DEVICE_FS_DAINTMSK        \ OTG_FS_DEVICE_OEPINT	Bit Offset:16	Bit Width:16
        
        OTG_FS_DEVICE $28 + constant OTG_FS_DEVICE_DVBUSDIS	\ read-write		\  : RESET_OTG_FS_DEVICE_DVBUSDIS $000017D7 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DVBUSDIS        \ OTG_FS_DEVICE_VBUSDT	Bit Offset:0	Bit Width:16
        
        OTG_FS_DEVICE $2C + constant OTG_FS_DEVICE_DVBUSPULSE	\ read-write		\  : RESET_OTG_FS_DEVICE_DVBUSPULSE $000005B8 
        \ %xxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DVBUSPULSE        \ OTG_FS_DEVICE_DVBUSP	Bit Offset:0	Bit Width:12
        
        OTG_FS_DEVICE $34 + constant OTG_FS_DEVICE_DIEPEMPMSK	\ read-write		\  : RESET_OTG_FS_DEVICE_DIEPEMPMSK $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DIEPEMPMSK        \ OTG_FS_DEVICE_INEPTXFEM	Bit Offset:0	Bit Width:16
        
        OTG_FS_DEVICE $100 + constant OTG_FS_DEVICE_FS_DIEPCTL0	\ 		\  : RESET_OTG_FS_DEVICE_FS_DIEPCTL0 $00000000 
        \ %xx  0 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:2
        \ %x  15 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_STALL	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_FS_DEVICE_FS_DIEPCTL0        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_FS_DEVICE $120 + constant OTG_FS_DEVICE_DIEPCTL1	\ 		\  : RESET_OTG_FS_DEVICE_DIEPCTL1 $00000000 
        \ %x  31 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_SODDFRM_SD1PID	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %xxxx  22 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  21 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift OTG_FS_DEVICE_DIEPCTL1        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        OTG_FS_DEVICE $140 + constant OTG_FS_DEVICE_DIEPCTL2	\ 		\  : RESET_OTG_FS_DEVICE_DIEPCTL2 $00000000 
        \ %x  31 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %xxxx  22 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  21 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift OTG_FS_DEVICE_DIEPCTL2        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        OTG_FS_DEVICE $160 + constant OTG_FS_DEVICE_DIEPCTL3	\ 		\  : RESET_OTG_FS_DEVICE_DIEPCTL3 $00000000 
        \ %x  31 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %xxxx  22 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  21 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift OTG_FS_DEVICE_DIEPCTL3        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        OTG_FS_DEVICE $300 + constant OTG_FS_DEVICE_DOEPCTL0	\ 		\  : RESET_OTG_FS_DEVICE_DOEPCTL0 $00008000 
        \ %x  31 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %xx  0 lshift OTG_FS_DEVICE_DOEPCTL0        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:2
        
        OTG_FS_DEVICE $320 + constant OTG_FS_DEVICE_DOEPCTL1	\ 		\  : RESET_OTG_FS_DEVICE_DOEPCTL1 $00000000 
        \ %x  31 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift OTG_FS_DEVICE_DOEPCTL1        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        OTG_FS_DEVICE $340 + constant OTG_FS_DEVICE_DOEPCTL2	\ 		\  : RESET_OTG_FS_DEVICE_DOEPCTL2 $00000000 
        \ %x  31 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift OTG_FS_DEVICE_DOEPCTL2        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        OTG_FS_DEVICE $360 + constant OTG_FS_DEVICE_DOEPCTL3	\ 		\  : RESET_OTG_FS_DEVICE_DOEPCTL3 $00000000 
        \ %x  31 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        \ %x  30 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  29 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  28 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  27 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  26 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  21 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  20 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %xx  18 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  17 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %x  16 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  15 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ % 0 lshift OTG_FS_DEVICE_DOEPCTL3        \ OTG_FS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        
        OTG_FS_DEVICE $108 + constant OTG_FS_DEVICE_DIEPINT0	\ 		\  : RESET_OTG_FS_DEVICE_DIEPINT0 $00000080 
        \ %x  7 lshift OTG_FS_DEVICE_DIEPINT0        \ OTG_FS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift OTG_FS_DEVICE_DIEPINT0        \ OTG_FS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DIEPINT0        \ OTG_FS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DIEPINT0        \ OTG_FS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DIEPINT0        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DIEPINT0        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $128 + constant OTG_FS_DEVICE_DIEPINT1	\ 		\  : RESET_OTG_FS_DEVICE_DIEPINT1 $00000080 
        \ %x  7 lshift OTG_FS_DEVICE_DIEPINT1        \ OTG_FS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift OTG_FS_DEVICE_DIEPINT1        \ OTG_FS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DIEPINT1        \ OTG_FS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DIEPINT1        \ OTG_FS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DIEPINT1        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DIEPINT1        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $148 + constant OTG_FS_DEVICE_DIEPINT2	\ 		\  : RESET_OTG_FS_DEVICE_DIEPINT2 $00000080 
        \ %x  7 lshift OTG_FS_DEVICE_DIEPINT2        \ OTG_FS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift OTG_FS_DEVICE_DIEPINT2        \ OTG_FS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DIEPINT2        \ OTG_FS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DIEPINT2        \ OTG_FS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DIEPINT2        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DIEPINT2        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $168 + constant OTG_FS_DEVICE_DIEPINT3	\ 		\  : RESET_OTG_FS_DEVICE_DIEPINT3 $00000080 
        \ %x  7 lshift OTG_FS_DEVICE_DIEPINT3        \ OTG_FS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift OTG_FS_DEVICE_DIEPINT3        \ OTG_FS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DIEPINT3        \ OTG_FS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DIEPINT3        \ OTG_FS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DIEPINT3        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DIEPINT3        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $308 + constant OTG_FS_DEVICE_DOEPINT0	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPINT0 $00000080 
        \ %x  6 lshift OTG_FS_DEVICE_DOEPINT0        \ OTG_FS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DOEPINT0        \ OTG_FS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DOEPINT0        \ OTG_FS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DOEPINT0        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DOEPINT0        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $328 + constant OTG_FS_DEVICE_DOEPINT1	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPINT1 $00000080 
        \ %x  6 lshift OTG_FS_DEVICE_DOEPINT1        \ OTG_FS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DOEPINT1        \ OTG_FS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DOEPINT1        \ OTG_FS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DOEPINT1        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DOEPINT1        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $348 + constant OTG_FS_DEVICE_DOEPINT2	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPINT2 $00000080 
        \ %x  6 lshift OTG_FS_DEVICE_DOEPINT2        \ OTG_FS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DOEPINT2        \ OTG_FS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DOEPINT2        \ OTG_FS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DOEPINT2        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DOEPINT2        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $368 + constant OTG_FS_DEVICE_DOEPINT3	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPINT3 $00000080 
        \ %x  6 lshift OTG_FS_DEVICE_DOEPINT3        \ OTG_FS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  4 lshift OTG_FS_DEVICE_DOEPINT3        \ OTG_FS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  3 lshift OTG_FS_DEVICE_DOEPINT3        \ OTG_FS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift OTG_FS_DEVICE_DOEPINT3        \ OTG_FS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  0 lshift OTG_FS_DEVICE_DOEPINT3        \ OTG_FS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        
        OTG_FS_DEVICE $110 + constant OTG_FS_DEVICE_DIEPTSIZ0	\ read-write		\  : RESET_OTG_FS_DEVICE_DIEPTSIZ0 $00000000 
        \ %xx  19 lshift OTG_FS_DEVICE_DIEPTSIZ0        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:2
        \ %xxxxxxx  0 lshift OTG_FS_DEVICE_DIEPTSIZ0        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:7
        
        OTG_FS_DEVICE $310 + constant OTG_FS_DEVICE_DOEPTSIZ0	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPTSIZ0 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DOEPTSIZ0        \ OTG_FS_DEVICE_STUPCNT	Bit Offset:29	Bit Width:2
        \ %x  19 lshift OTG_FS_DEVICE_DOEPTSIZ0        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:1
        \ %xxxxxxx  0 lshift OTG_FS_DEVICE_DOEPTSIZ0        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:7
        
        OTG_FS_DEVICE $130 + constant OTG_FS_DEVICE_DIEPTSIZ1	\ read-write		\  : RESET_OTG_FS_DEVICE_DIEPTSIZ1 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DIEPTSIZ1        \ OTG_FS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift OTG_FS_DEVICE_DIEPTSIZ1        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift OTG_FS_DEVICE_DIEPTSIZ1        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        OTG_FS_DEVICE $150 + constant OTG_FS_DEVICE_DIEPTSIZ2	\ read-write		\  : RESET_OTG_FS_DEVICE_DIEPTSIZ2 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DIEPTSIZ2        \ OTG_FS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift OTG_FS_DEVICE_DIEPTSIZ2        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift OTG_FS_DEVICE_DIEPTSIZ2        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        OTG_FS_DEVICE $170 + constant OTG_FS_DEVICE_DIEPTSIZ3	\ read-write		\  : RESET_OTG_FS_DEVICE_DIEPTSIZ3 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DIEPTSIZ3        \ OTG_FS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift OTG_FS_DEVICE_DIEPTSIZ3        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift OTG_FS_DEVICE_DIEPTSIZ3        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        OTG_FS_DEVICE $118 + constant OTG_FS_DEVICE_DTXFSTS0	\ read-only		\  : RESET_OTG_FS_DEVICE_DTXFSTS0 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DTXFSTS0        \ OTG_FS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_FS_DEVICE $138 + constant OTG_FS_DEVICE_DTXFSTS1	\ read-only		\  : RESET_OTG_FS_DEVICE_DTXFSTS1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DTXFSTS1        \ OTG_FS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_FS_DEVICE $158 + constant OTG_FS_DEVICE_DTXFSTS2	\ read-only		\  : RESET_OTG_FS_DEVICE_DTXFSTS2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DTXFSTS2        \ OTG_FS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_FS_DEVICE $178 + constant OTG_FS_DEVICE_DTXFSTS3	\ read-only		\  : RESET_OTG_FS_DEVICE_DTXFSTS3 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_FS_DEVICE_DTXFSTS3        \ OTG_FS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_FS_DEVICE $330 + constant OTG_FS_DEVICE_DOEPTSIZ1	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPTSIZ1 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DOEPTSIZ1        \ OTG_FS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift OTG_FS_DEVICE_DOEPTSIZ1        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift OTG_FS_DEVICE_DOEPTSIZ1        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        OTG_FS_DEVICE $350 + constant OTG_FS_DEVICE_DOEPTSIZ2	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPTSIZ2 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DOEPTSIZ2        \ OTG_FS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift OTG_FS_DEVICE_DOEPTSIZ2        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift OTG_FS_DEVICE_DOEPTSIZ2        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
        OTG_FS_DEVICE $370 + constant OTG_FS_DEVICE_DOEPTSIZ3	\ read-write		\  : RESET_OTG_FS_DEVICE_DOEPTSIZ3 $00000000 
        \ %xx  29 lshift OTG_FS_DEVICE_DOEPTSIZ3        \ OTG_FS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        \ % 19 lshift OTG_FS_DEVICE_DOEPTSIZ3        \ OTG_FS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ % 0 lshift OTG_FS_DEVICE_DOEPTSIZ3        \ OTG_FS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        
         
	
     $50000E00 constant OTG_FS_PWRCLK  
	 OTG_FS_PWRCLK $0 + constant OTG_FS_PWRCLK_FS_PCGCCTL	\ read-write		\  : RESET_OTG_FS_PWRCLK_FS_PCGCCTL $00000000 
        \ %x  0 lshift OTG_FS_PWRCLK_FS_PCGCCTL        \ OTG_FS_PWRCLK_STPPCLK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_FS_PWRCLK_FS_PCGCCTL        \ OTG_FS_PWRCLK_GATEHCLK	Bit Offset:1	Bit Width:1
        \ %x  4 lshift OTG_FS_PWRCLK_FS_PCGCCTL        \ OTG_FS_PWRCLK_PHYSUSP	Bit Offset:4	Bit Width:1
        
         
	
     $40006400 constant CAN1  
	 CAN1 $0 + constant CAN1_MCR	\ read-write		\  : RESET_CAN1_MCR $00010002 
        \ %x  16 lshift CAN1_MCR        \ CAN1_DBF	Bit Offset:16	Bit Width:1
        \ %x  15 lshift CAN1_MCR        \ CAN1_RESET	Bit Offset:15	Bit Width:1
        \ %x  7 lshift CAN1_MCR        \ CAN1_TTCM	Bit Offset:7	Bit Width:1
        \ %x  6 lshift CAN1_MCR        \ CAN1_ABOM	Bit Offset:6	Bit Width:1
        \ %x  5 lshift CAN1_MCR        \ CAN1_AWUM	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN1_MCR        \ CAN1_NART	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN1_MCR        \ CAN1_RFLM	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN1_MCR        \ CAN1_TXFP	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_MCR        \ CAN1_SLEEP	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_MCR        \ CAN1_INRQ	Bit Offset:0	Bit Width:1
        
        CAN1 $4 + constant CAN1_MSR	\ 		\  : RESET_CAN1_MSR $00000C02 
        \ %x  11 lshift CAN1_MSR        \ CAN1_RX	Bit Offset:11	Bit Width:1
        \ %x  10 lshift CAN1_MSR        \ CAN1_SAMP	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CAN1_MSR        \ CAN1_RXM	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CAN1_MSR        \ CAN1_TXM	Bit Offset:8	Bit Width:1
        \ %x  4 lshift CAN1_MSR        \ CAN1_SLAKI	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN1_MSR        \ CAN1_WKUI	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN1_MSR        \ CAN1_ERRI	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_MSR        \ CAN1_SLAK	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_MSR        \ CAN1_INAK	Bit Offset:0	Bit Width:1
        
        CAN1 $8 + constant CAN1_TSR	\ 		\  : RESET_CAN1_TSR $1C000000 
        \ %x  31 lshift CAN1_TSR        \ CAN1_LOW2	Bit Offset:31	Bit Width:1
        \ %x  30 lshift CAN1_TSR        \ CAN1_LOW1	Bit Offset:30	Bit Width:1
        \ %x  29 lshift CAN1_TSR        \ CAN1_LOW0	Bit Offset:29	Bit Width:1
        \ %x  28 lshift CAN1_TSR        \ CAN1_TME2	Bit Offset:28	Bit Width:1
        \ %x  27 lshift CAN1_TSR        \ CAN1_TME1	Bit Offset:27	Bit Width:1
        \ %x  26 lshift CAN1_TSR        \ CAN1_TME0	Bit Offset:26	Bit Width:1
        \ %xx  24 lshift CAN1_TSR        \ CAN1_CODE	Bit Offset:24	Bit Width:2
        \ %x  23 lshift CAN1_TSR        \ CAN1_ABRQ2	Bit Offset:23	Bit Width:1
        \ %x  19 lshift CAN1_TSR        \ CAN1_TERR2	Bit Offset:19	Bit Width:1
        \ %x  18 lshift CAN1_TSR        \ CAN1_ALST2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift CAN1_TSR        \ CAN1_TXOK2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift CAN1_TSR        \ CAN1_RQCP2	Bit Offset:16	Bit Width:1
        \ %x  15 lshift CAN1_TSR        \ CAN1_ABRQ1	Bit Offset:15	Bit Width:1
        \ %x  11 lshift CAN1_TSR        \ CAN1_TERR1	Bit Offset:11	Bit Width:1
        \ %x  10 lshift CAN1_TSR        \ CAN1_ALST1	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CAN1_TSR        \ CAN1_TXOK1	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CAN1_TSR        \ CAN1_RQCP1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift CAN1_TSR        \ CAN1_ABRQ0	Bit Offset:7	Bit Width:1
        \ %x  3 lshift CAN1_TSR        \ CAN1_TERR0	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN1_TSR        \ CAN1_ALST0	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_TSR        \ CAN1_TXOK0	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_TSR        \ CAN1_RQCP0	Bit Offset:0	Bit Width:1
        
        CAN1 $C + constant CAN1_RF0R	\ 		\  : RESET_CAN1_RF0R $00000000 
        \ %x  5 lshift CAN1_RF0R        \ CAN1_RFOM0	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN1_RF0R        \ CAN1_FOVR0	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN1_RF0R        \ CAN1_FULL0	Bit Offset:3	Bit Width:1
        \ %xx  0 lshift CAN1_RF0R        \ CAN1_FMP0	Bit Offset:0	Bit Width:2
        
        CAN1 $10 + constant CAN1_RF1R	\ 		\  : RESET_CAN1_RF1R $00000000 
        \ %x  5 lshift CAN1_RF1R        \ CAN1_RFOM1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN1_RF1R        \ CAN1_FOVR1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN1_RF1R        \ CAN1_FULL1	Bit Offset:3	Bit Width:1
        \ %xx  0 lshift CAN1_RF1R        \ CAN1_FMP1	Bit Offset:0	Bit Width:2
        
        CAN1 $14 + constant CAN1_IER	\ read-write		\  : RESET_CAN1_IER $00000000 
        \ %x  17 lshift CAN1_IER        \ CAN1_SLKIE	Bit Offset:17	Bit Width:1
        \ %x  16 lshift CAN1_IER        \ CAN1_WKUIE	Bit Offset:16	Bit Width:1
        \ %x  15 lshift CAN1_IER        \ CAN1_ERRIE	Bit Offset:15	Bit Width:1
        \ %x  11 lshift CAN1_IER        \ CAN1_LECIE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift CAN1_IER        \ CAN1_BOFIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CAN1_IER        \ CAN1_EPVIE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CAN1_IER        \ CAN1_EWGIE	Bit Offset:8	Bit Width:1
        \ %x  6 lshift CAN1_IER        \ CAN1_FOVIE1	Bit Offset:6	Bit Width:1
        \ %x  5 lshift CAN1_IER        \ CAN1_FFIE1	Bit Offset:5	Bit Width:1
        \ %x  4 lshift CAN1_IER        \ CAN1_FMPIE1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift CAN1_IER        \ CAN1_FOVIE0	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CAN1_IER        \ CAN1_FFIE0	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_IER        \ CAN1_FMPIE0	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_IER        \ CAN1_TMEIE	Bit Offset:0	Bit Width:1
        
        CAN1 $18 + constant CAN1_ESR	\ 		\  : RESET_CAN1_ESR $00000000 
        \ %xxxxxxxx  24 lshift CAN1_ESR        \ CAN1_REC	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_ESR        \ CAN1_TEC	Bit Offset:16	Bit Width:8
        \ %xxx  4 lshift CAN1_ESR        \ CAN1_LEC	Bit Offset:4	Bit Width:3
        \ %x  2 lshift CAN1_ESR        \ CAN1_BOFF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_ESR        \ CAN1_EPVF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_ESR        \ CAN1_EWGF	Bit Offset:0	Bit Width:1
        
        CAN1 $1C + constant CAN1_BTR	\ read-write		\  : RESET_CAN1_BTR $00000000 
        \ %x  31 lshift CAN1_BTR        \ CAN1_SILM	Bit Offset:31	Bit Width:1
        \ %x  30 lshift CAN1_BTR        \ CAN1_LBKM	Bit Offset:30	Bit Width:1
        \ %xx  24 lshift CAN1_BTR        \ CAN1_SJW	Bit Offset:24	Bit Width:2
        \ %xxx  20 lshift CAN1_BTR        \ CAN1_TS2	Bit Offset:20	Bit Width:3
        \ %xxxx  16 lshift CAN1_BTR        \ CAN1_TS1	Bit Offset:16	Bit Width:4
        \ % 0 lshift CAN1_BTR        \ CAN1_BRP	Bit Offset:0	Bit Width:10
        
        CAN1 $180 + constant CAN1_TI0R	\ read-write		\  : RESET_CAN1_TI0R $00000000 
        \ % 21 lshift CAN1_TI0R        \ CAN1_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN1_TI0R        \ CAN1_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN1_TI0R        \ CAN1_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_TI0R        \ CAN1_RTR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_TI0R        \ CAN1_TXRQ	Bit Offset:0	Bit Width:1
        
        CAN1 $184 + constant CAN1_TDT0R	\ read-write		\  : RESET_CAN1_TDT0R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN1_TDT0R        \ CAN1_TIME	Bit Offset:16	Bit Width:16
        \ %x  8 lshift CAN1_TDT0R        \ CAN1_TGT	Bit Offset:8	Bit Width:1
        \ %xxxx  0 lshift CAN1_TDT0R        \ CAN1_DLC	Bit Offset:0	Bit Width:4
        
        CAN1 $188 + constant CAN1_TDL0R	\ read-write		\  : RESET_CAN1_TDL0R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_TDL0R        \ CAN1_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_TDL0R        \ CAN1_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_TDL0R        \ CAN1_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_TDL0R        \ CAN1_DATA0	Bit Offset:0	Bit Width:8
        
        CAN1 $18C + constant CAN1_TDH0R	\ read-write		\  : RESET_CAN1_TDH0R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_TDH0R        \ CAN1_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_TDH0R        \ CAN1_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_TDH0R        \ CAN1_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_TDH0R        \ CAN1_DATA4	Bit Offset:0	Bit Width:8
        
        CAN1 $190 + constant CAN1_TI1R	\ read-write		\  : RESET_CAN1_TI1R $00000000 
        \ % 21 lshift CAN1_TI1R        \ CAN1_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN1_TI1R        \ CAN1_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN1_TI1R        \ CAN1_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_TI1R        \ CAN1_RTR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_TI1R        \ CAN1_TXRQ	Bit Offset:0	Bit Width:1
        
        CAN1 $194 + constant CAN1_TDT1R	\ read-write		\  : RESET_CAN1_TDT1R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN1_TDT1R        \ CAN1_TIME	Bit Offset:16	Bit Width:16
        \ %x  8 lshift CAN1_TDT1R        \ CAN1_TGT	Bit Offset:8	Bit Width:1
        \ %xxxx  0 lshift CAN1_TDT1R        \ CAN1_DLC	Bit Offset:0	Bit Width:4
        
        CAN1 $198 + constant CAN1_TDL1R	\ read-write		\  : RESET_CAN1_TDL1R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_TDL1R        \ CAN1_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_TDL1R        \ CAN1_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_TDL1R        \ CAN1_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_TDL1R        \ CAN1_DATA0	Bit Offset:0	Bit Width:8
        
        CAN1 $19C + constant CAN1_TDH1R	\ read-write		\  : RESET_CAN1_TDH1R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_TDH1R        \ CAN1_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_TDH1R        \ CAN1_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_TDH1R        \ CAN1_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_TDH1R        \ CAN1_DATA4	Bit Offset:0	Bit Width:8
        
        CAN1 $1A0 + constant CAN1_TI2R	\ read-write		\  : RESET_CAN1_TI2R $00000000 
        \ % 21 lshift CAN1_TI2R        \ CAN1_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN1_TI2R        \ CAN1_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN1_TI2R        \ CAN1_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_TI2R        \ CAN1_RTR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CAN1_TI2R        \ CAN1_TXRQ	Bit Offset:0	Bit Width:1
        
        CAN1 $1A4 + constant CAN1_TDT2R	\ read-write		\  : RESET_CAN1_TDT2R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN1_TDT2R        \ CAN1_TIME	Bit Offset:16	Bit Width:16
        \ %x  8 lshift CAN1_TDT2R        \ CAN1_TGT	Bit Offset:8	Bit Width:1
        \ %xxxx  0 lshift CAN1_TDT2R        \ CAN1_DLC	Bit Offset:0	Bit Width:4
        
        CAN1 $1A8 + constant CAN1_TDL2R	\ read-write		\  : RESET_CAN1_TDL2R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_TDL2R        \ CAN1_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_TDL2R        \ CAN1_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_TDL2R        \ CAN1_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_TDL2R        \ CAN1_DATA0	Bit Offset:0	Bit Width:8
        
        CAN1 $1AC + constant CAN1_TDH2R	\ read-write		\  : RESET_CAN1_TDH2R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_TDH2R        \ CAN1_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_TDH2R        \ CAN1_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_TDH2R        \ CAN1_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_TDH2R        \ CAN1_DATA4	Bit Offset:0	Bit Width:8
        
        CAN1 $1B0 + constant CAN1_RI0R	\ read-only		\  : RESET_CAN1_RI0R $00000000 
        \ % 21 lshift CAN1_RI0R        \ CAN1_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN1_RI0R        \ CAN1_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN1_RI0R        \ CAN1_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_RI0R        \ CAN1_RTR	Bit Offset:1	Bit Width:1
        
        CAN1 $1B4 + constant CAN1_RDT0R	\ read-only		\  : RESET_CAN1_RDT0R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN1_RDT0R        \ CAN1_TIME	Bit Offset:16	Bit Width:16
        \ %xxxxxxxx  8 lshift CAN1_RDT0R        \ CAN1_FMI	Bit Offset:8	Bit Width:8
        \ %xxxx  0 lshift CAN1_RDT0R        \ CAN1_DLC	Bit Offset:0	Bit Width:4
        
        CAN1 $1B8 + constant CAN1_RDL0R	\ read-only		\  : RESET_CAN1_RDL0R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_RDL0R        \ CAN1_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_RDL0R        \ CAN1_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_RDL0R        \ CAN1_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_RDL0R        \ CAN1_DATA0	Bit Offset:0	Bit Width:8
        
        CAN1 $1BC + constant CAN1_RDH0R	\ read-only		\  : RESET_CAN1_RDH0R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_RDH0R        \ CAN1_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_RDH0R        \ CAN1_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_RDH0R        \ CAN1_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_RDH0R        \ CAN1_DATA4	Bit Offset:0	Bit Width:8
        
        CAN1 $1C0 + constant CAN1_RI1R	\ read-only		\  : RESET_CAN1_RI1R $00000000 
        \ % 21 lshift CAN1_RI1R        \ CAN1_STID	Bit Offset:21	Bit Width:11
        \ % 3 lshift CAN1_RI1R        \ CAN1_EXID	Bit Offset:3	Bit Width:18
        \ %x  2 lshift CAN1_RI1R        \ CAN1_IDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CAN1_RI1R        \ CAN1_RTR	Bit Offset:1	Bit Width:1
        
        CAN1 $1C4 + constant CAN1_RDT1R	\ read-only		\  : RESET_CAN1_RDT1R $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CAN1_RDT1R        \ CAN1_TIME	Bit Offset:16	Bit Width:16
        \ %xxxxxxxx  8 lshift CAN1_RDT1R        \ CAN1_FMI	Bit Offset:8	Bit Width:8
        \ %xxxx  0 lshift CAN1_RDT1R        \ CAN1_DLC	Bit Offset:0	Bit Width:4
        
        CAN1 $1C8 + constant CAN1_RDL1R	\ read-only		\  : RESET_CAN1_RDL1R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_RDL1R        \ CAN1_DATA3	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_RDL1R        \ CAN1_DATA2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_RDL1R        \ CAN1_DATA1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_RDL1R        \ CAN1_DATA0	Bit Offset:0	Bit Width:8
        
        CAN1 $1CC + constant CAN1_RDH1R	\ read-only		\  : RESET_CAN1_RDH1R $00000000 
        \ %xxxxxxxx  24 lshift CAN1_RDH1R        \ CAN1_DATA7	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift CAN1_RDH1R        \ CAN1_DATA6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift CAN1_RDH1R        \ CAN1_DATA5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift CAN1_RDH1R        \ CAN1_DATA4	Bit Offset:0	Bit Width:8
        
        CAN1 $200 + constant CAN1_FMR	\ read-write		\  : RESET_CAN1_FMR $2A1C0E01 
        \ %xxxxxx  8 lshift CAN1_FMR        \ CAN1_CAN2SB	Bit Offset:8	Bit Width:6
        \ %x  0 lshift CAN1_FMR        \ CAN1_FINIT	Bit Offset:0	Bit Width:1
        
        CAN1 $204 + constant CAN1_FM1R	\ read-write		\  : RESET_CAN1_FM1R $00000000 
        \ %x  0 lshift CAN1_FM1R        \ CAN1_FBM0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_FM1R        \ CAN1_FBM1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_FM1R        \ CAN1_FBM2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_FM1R        \ CAN1_FBM3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_FM1R        \ CAN1_FBM4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_FM1R        \ CAN1_FBM5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_FM1R        \ CAN1_FBM6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_FM1R        \ CAN1_FBM7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_FM1R        \ CAN1_FBM8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_FM1R        \ CAN1_FBM9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_FM1R        \ CAN1_FBM10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_FM1R        \ CAN1_FBM11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_FM1R        \ CAN1_FBM12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_FM1R        \ CAN1_FBM13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_FM1R        \ CAN1_FBM14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_FM1R        \ CAN1_FBM15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_FM1R        \ CAN1_FBM16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_FM1R        \ CAN1_FBM17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_FM1R        \ CAN1_FBM18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_FM1R        \ CAN1_FBM19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_FM1R        \ CAN1_FBM20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_FM1R        \ CAN1_FBM21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_FM1R        \ CAN1_FBM22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_FM1R        \ CAN1_FBM23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_FM1R        \ CAN1_FBM24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_FM1R        \ CAN1_FBM25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_FM1R        \ CAN1_FBM26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_FM1R        \ CAN1_FBM27	Bit Offset:27	Bit Width:1
        
        CAN1 $20C + constant CAN1_FS1R	\ read-write		\  : RESET_CAN1_FS1R $00000000 
        \ %x  0 lshift CAN1_FS1R        \ CAN1_FSC0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_FS1R        \ CAN1_FSC1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_FS1R        \ CAN1_FSC2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_FS1R        \ CAN1_FSC3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_FS1R        \ CAN1_FSC4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_FS1R        \ CAN1_FSC5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_FS1R        \ CAN1_FSC6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_FS1R        \ CAN1_FSC7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_FS1R        \ CAN1_FSC8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_FS1R        \ CAN1_FSC9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_FS1R        \ CAN1_FSC10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_FS1R        \ CAN1_FSC11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_FS1R        \ CAN1_FSC12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_FS1R        \ CAN1_FSC13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_FS1R        \ CAN1_FSC14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_FS1R        \ CAN1_FSC15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_FS1R        \ CAN1_FSC16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_FS1R        \ CAN1_FSC17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_FS1R        \ CAN1_FSC18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_FS1R        \ CAN1_FSC19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_FS1R        \ CAN1_FSC20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_FS1R        \ CAN1_FSC21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_FS1R        \ CAN1_FSC22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_FS1R        \ CAN1_FSC23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_FS1R        \ CAN1_FSC24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_FS1R        \ CAN1_FSC25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_FS1R        \ CAN1_FSC26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_FS1R        \ CAN1_FSC27	Bit Offset:27	Bit Width:1
        
        CAN1 $214 + constant CAN1_FFA1R	\ read-write		\  : RESET_CAN1_FFA1R $00000000 
        \ %x  0 lshift CAN1_FFA1R        \ CAN1_FFA0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_FFA1R        \ CAN1_FFA1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_FFA1R        \ CAN1_FFA2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_FFA1R        \ CAN1_FFA3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_FFA1R        \ CAN1_FFA4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_FFA1R        \ CAN1_FFA5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_FFA1R        \ CAN1_FFA6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_FFA1R        \ CAN1_FFA7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_FFA1R        \ CAN1_FFA8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_FFA1R        \ CAN1_FFA9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_FFA1R        \ CAN1_FFA10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_FFA1R        \ CAN1_FFA11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_FFA1R        \ CAN1_FFA12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_FFA1R        \ CAN1_FFA13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_FFA1R        \ CAN1_FFA14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_FFA1R        \ CAN1_FFA15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_FFA1R        \ CAN1_FFA16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_FFA1R        \ CAN1_FFA17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_FFA1R        \ CAN1_FFA18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_FFA1R        \ CAN1_FFA19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_FFA1R        \ CAN1_FFA20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_FFA1R        \ CAN1_FFA21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_FFA1R        \ CAN1_FFA22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_FFA1R        \ CAN1_FFA23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_FFA1R        \ CAN1_FFA24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_FFA1R        \ CAN1_FFA25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_FFA1R        \ CAN1_FFA26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_FFA1R        \ CAN1_FFA27	Bit Offset:27	Bit Width:1
        
        CAN1 $21C + constant CAN1_FA1R	\ read-write		\  : RESET_CAN1_FA1R $00000000 
        \ %x  0 lshift CAN1_FA1R        \ CAN1_FACT0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_FA1R        \ CAN1_FACT1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_FA1R        \ CAN1_FACT2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_FA1R        \ CAN1_FACT3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_FA1R        \ CAN1_FACT4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_FA1R        \ CAN1_FACT5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_FA1R        \ CAN1_FACT6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_FA1R        \ CAN1_FACT7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_FA1R        \ CAN1_FACT8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_FA1R        \ CAN1_FACT9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_FA1R        \ CAN1_FACT10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_FA1R        \ CAN1_FACT11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_FA1R        \ CAN1_FACT12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_FA1R        \ CAN1_FACT13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_FA1R        \ CAN1_FACT14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_FA1R        \ CAN1_FACT15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_FA1R        \ CAN1_FACT16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_FA1R        \ CAN1_FACT17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_FA1R        \ CAN1_FACT18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_FA1R        \ CAN1_FACT19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_FA1R        \ CAN1_FACT20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_FA1R        \ CAN1_FACT21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_FA1R        \ CAN1_FACT22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_FA1R        \ CAN1_FACT23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_FA1R        \ CAN1_FACT24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_FA1R        \ CAN1_FACT25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_FA1R        \ CAN1_FACT26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_FA1R        \ CAN1_FACT27	Bit Offset:27	Bit Width:1
        
        CAN1 $240 + constant CAN1_F0R1	\ read-write		\  : RESET_CAN1_F0R1 $00000000 
        \ %x  0 lshift CAN1_F0R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F0R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F0R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F0R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F0R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F0R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F0R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F0R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F0R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F0R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F0R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F0R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F0R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F0R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F0R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F0R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F0R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F0R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F0R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F0R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F0R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F0R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F0R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F0R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F0R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F0R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F0R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F0R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F0R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F0R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F0R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F0R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $244 + constant CAN1_F0R2	\ read-write		\  : RESET_CAN1_F0R2 $00000000 
        \ %x  0 lshift CAN1_F0R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F0R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F0R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F0R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F0R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F0R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F0R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F0R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F0R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F0R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F0R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F0R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F0R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F0R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F0R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F0R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F0R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F0R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F0R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F0R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F0R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F0R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F0R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F0R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F0R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F0R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F0R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F0R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F0R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F0R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F0R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F0R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $248 + constant CAN1_F1R1	\ read-write		\  : RESET_CAN1_F1R1 $00000000 
        \ %x  0 lshift CAN1_F1R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F1R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F1R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F1R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F1R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F1R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F1R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F1R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F1R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F1R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F1R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F1R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F1R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F1R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F1R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F1R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F1R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F1R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F1R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F1R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F1R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F1R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F1R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F1R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F1R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F1R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F1R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F1R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F1R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F1R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F1R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F1R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $24C + constant CAN1_F1R2	\ read-write		\  : RESET_CAN1_F1R2 $00000000 
        \ %x  0 lshift CAN1_F1R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F1R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F1R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F1R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F1R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F1R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F1R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F1R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F1R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F1R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F1R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F1R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F1R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F1R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F1R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F1R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F1R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F1R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F1R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F1R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F1R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F1R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F1R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F1R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F1R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F1R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F1R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F1R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F1R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F1R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F1R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F1R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $250 + constant CAN1_F2R1	\ read-write		\  : RESET_CAN1_F2R1 $00000000 
        \ %x  0 lshift CAN1_F2R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F2R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F2R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F2R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F2R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F2R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F2R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F2R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F2R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F2R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F2R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F2R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F2R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F2R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F2R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F2R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F2R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F2R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F2R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F2R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F2R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F2R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F2R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F2R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F2R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F2R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F2R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F2R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F2R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F2R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F2R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F2R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $254 + constant CAN1_F2R2	\ read-write		\  : RESET_CAN1_F2R2 $00000000 
        \ %x  0 lshift CAN1_F2R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F2R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F2R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F2R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F2R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F2R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F2R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F2R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F2R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F2R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F2R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F2R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F2R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F2R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F2R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F2R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F2R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F2R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F2R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F2R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F2R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F2R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F2R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F2R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F2R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F2R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F2R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F2R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F2R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F2R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F2R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F2R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $258 + constant CAN1_F3R1	\ read-write		\  : RESET_CAN1_F3R1 $00000000 
        \ %x  0 lshift CAN1_F3R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F3R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F3R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F3R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F3R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F3R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F3R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F3R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F3R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F3R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F3R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F3R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F3R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F3R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F3R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F3R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F3R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F3R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F3R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F3R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F3R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F3R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F3R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F3R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F3R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F3R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F3R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F3R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F3R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F3R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F3R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F3R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $25C + constant CAN1_F3R2	\ read-write		\  : RESET_CAN1_F3R2 $00000000 
        \ %x  0 lshift CAN1_F3R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F3R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F3R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F3R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F3R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F3R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F3R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F3R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F3R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F3R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F3R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F3R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F3R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F3R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F3R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F3R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F3R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F3R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F3R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F3R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F3R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F3R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F3R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F3R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F3R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F3R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F3R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F3R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F3R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F3R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F3R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F3R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $260 + constant CAN1_F4R1	\ read-write		\  : RESET_CAN1_F4R1 $00000000 
        \ %x  0 lshift CAN1_F4R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F4R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F4R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F4R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F4R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F4R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F4R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F4R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F4R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F4R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F4R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F4R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F4R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F4R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F4R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F4R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F4R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F4R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F4R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F4R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F4R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F4R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F4R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F4R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F4R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F4R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F4R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F4R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F4R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F4R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F4R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F4R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $264 + constant CAN1_F4R2	\ read-write		\  : RESET_CAN1_F4R2 $00000000 
        \ %x  0 lshift CAN1_F4R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F4R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F4R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F4R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F4R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F4R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F4R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F4R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F4R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F4R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F4R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F4R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F4R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F4R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F4R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F4R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F4R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F4R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F4R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F4R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F4R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F4R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F4R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F4R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F4R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F4R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F4R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F4R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F4R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F4R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F4R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F4R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $268 + constant CAN1_F5R1	\ read-write		\  : RESET_CAN1_F5R1 $00000000 
        \ %x  0 lshift CAN1_F5R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F5R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F5R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F5R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F5R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F5R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F5R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F5R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F5R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F5R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F5R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F5R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F5R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F5R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F5R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F5R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F5R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F5R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F5R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F5R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F5R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F5R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F5R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F5R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F5R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F5R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F5R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F5R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F5R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F5R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F5R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F5R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $26C + constant CAN1_F5R2	\ read-write		\  : RESET_CAN1_F5R2 $00000000 
        \ %x  0 lshift CAN1_F5R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F5R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F5R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F5R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F5R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F5R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F5R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F5R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F5R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F5R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F5R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F5R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F5R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F5R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F5R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F5R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F5R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F5R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F5R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F5R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F5R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F5R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F5R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F5R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F5R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F5R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F5R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F5R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F5R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F5R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F5R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F5R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $270 + constant CAN1_F6R1	\ read-write		\  : RESET_CAN1_F6R1 $00000000 
        \ %x  0 lshift CAN1_F6R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F6R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F6R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F6R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F6R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F6R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F6R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F6R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F6R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F6R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F6R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F6R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F6R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F6R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F6R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F6R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F6R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F6R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F6R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F6R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F6R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F6R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F6R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F6R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F6R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F6R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F6R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F6R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F6R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F6R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F6R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F6R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $274 + constant CAN1_F6R2	\ read-write		\  : RESET_CAN1_F6R2 $00000000 
        \ %x  0 lshift CAN1_F6R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F6R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F6R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F6R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F6R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F6R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F6R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F6R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F6R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F6R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F6R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F6R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F6R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F6R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F6R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F6R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F6R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F6R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F6R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F6R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F6R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F6R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F6R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F6R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F6R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F6R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F6R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F6R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F6R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F6R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F6R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F6R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $278 + constant CAN1_F7R1	\ read-write		\  : RESET_CAN1_F7R1 $00000000 
        \ %x  0 lshift CAN1_F7R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F7R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F7R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F7R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F7R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F7R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F7R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F7R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F7R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F7R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F7R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F7R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F7R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F7R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F7R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F7R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F7R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F7R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F7R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F7R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F7R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F7R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F7R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F7R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F7R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F7R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F7R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F7R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F7R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F7R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F7R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F7R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $27C + constant CAN1_F7R2	\ read-write		\  : RESET_CAN1_F7R2 $00000000 
        \ %x  0 lshift CAN1_F7R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F7R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F7R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F7R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F7R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F7R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F7R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F7R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F7R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F7R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F7R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F7R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F7R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F7R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F7R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F7R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F7R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F7R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F7R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F7R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F7R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F7R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F7R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F7R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F7R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F7R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F7R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F7R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F7R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F7R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F7R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F7R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $280 + constant CAN1_F8R1	\ read-write		\  : RESET_CAN1_F8R1 $00000000 
        \ %x  0 lshift CAN1_F8R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F8R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F8R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F8R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F8R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F8R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F8R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F8R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F8R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F8R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F8R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F8R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F8R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F8R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F8R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F8R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F8R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F8R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F8R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F8R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F8R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F8R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F8R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F8R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F8R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F8R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F8R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F8R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F8R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F8R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F8R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F8R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $284 + constant CAN1_F8R2	\ read-write		\  : RESET_CAN1_F8R2 $00000000 
        \ %x  0 lshift CAN1_F8R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F8R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F8R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F8R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F8R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F8R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F8R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F8R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F8R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F8R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F8R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F8R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F8R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F8R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F8R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F8R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F8R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F8R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F8R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F8R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F8R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F8R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F8R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F8R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F8R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F8R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F8R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F8R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F8R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F8R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F8R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F8R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $288 + constant CAN1_F9R1	\ read-write		\  : RESET_CAN1_F9R1 $00000000 
        \ %x  0 lshift CAN1_F9R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F9R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F9R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F9R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F9R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F9R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F9R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F9R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F9R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F9R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F9R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F9R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F9R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F9R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F9R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F9R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F9R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F9R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F9R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F9R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F9R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F9R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F9R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F9R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F9R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F9R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F9R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F9R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F9R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F9R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F9R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F9R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $28C + constant CAN1_F9R2	\ read-write		\  : RESET_CAN1_F9R2 $00000000 
        \ %x  0 lshift CAN1_F9R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F9R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F9R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F9R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F9R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F9R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F9R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F9R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F9R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F9R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F9R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F9R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F9R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F9R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F9R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F9R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F9R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F9R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F9R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F9R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F9R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F9R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F9R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F9R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F9R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F9R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F9R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F9R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F9R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F9R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F9R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F9R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $290 + constant CAN1_F10R1	\ read-write		\  : RESET_CAN1_F10R1 $00000000 
        \ %x  0 lshift CAN1_F10R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F10R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F10R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F10R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F10R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F10R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F10R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F10R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F10R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F10R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F10R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F10R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F10R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F10R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F10R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F10R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F10R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F10R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F10R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F10R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F10R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F10R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F10R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F10R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F10R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F10R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F10R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F10R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F10R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F10R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F10R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F10R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $294 + constant CAN1_F10R2	\ read-write		\  : RESET_CAN1_F10R2 $00000000 
        \ %x  0 lshift CAN1_F10R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F10R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F10R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F10R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F10R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F10R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F10R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F10R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F10R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F10R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F10R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F10R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F10R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F10R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F10R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F10R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F10R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F10R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F10R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F10R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F10R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F10R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F10R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F10R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F10R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F10R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F10R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F10R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F10R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F10R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F10R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F10R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $298 + constant CAN1_F11R1	\ read-write		\  : RESET_CAN1_F11R1 $00000000 
        \ %x  0 lshift CAN1_F11R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F11R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F11R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F11R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F11R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F11R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F11R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F11R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F11R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F11R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F11R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F11R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F11R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F11R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F11R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F11R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F11R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F11R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F11R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F11R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F11R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F11R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F11R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F11R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F11R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F11R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F11R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F11R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F11R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F11R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F11R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F11R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $29C + constant CAN1_F11R2	\ read-write		\  : RESET_CAN1_F11R2 $00000000 
        \ %x  0 lshift CAN1_F11R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F11R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F11R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F11R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F11R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F11R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F11R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F11R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F11R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F11R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F11R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F11R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F11R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F11R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F11R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F11R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F11R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F11R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F11R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F11R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F11R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F11R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F11R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F11R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F11R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F11R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F11R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F11R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F11R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F11R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F11R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F11R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2A0 + constant CAN1_F12R1	\ read-write		\  : RESET_CAN1_F12R1 $00000000 
        \ %x  0 lshift CAN1_F12R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F12R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F12R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F12R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F12R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F12R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F12R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F12R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F12R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F12R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F12R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F12R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F12R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F12R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F12R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F12R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F12R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F12R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F12R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F12R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F12R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F12R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F12R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F12R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F12R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F12R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F12R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F12R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F12R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F12R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F12R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F12R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2A4 + constant CAN1_F12R2	\ read-write		\  : RESET_CAN1_F12R2 $00000000 
        \ %x  0 lshift CAN1_F12R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F12R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F12R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F12R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F12R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F12R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F12R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F12R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F12R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F12R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F12R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F12R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F12R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F12R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F12R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F12R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F12R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F12R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F12R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F12R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F12R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F12R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F12R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F12R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F12R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F12R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F12R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F12R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F12R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F12R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F12R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F12R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2A8 + constant CAN1_F13R1	\ read-write		\  : RESET_CAN1_F13R1 $00000000 
        \ %x  0 lshift CAN1_F13R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F13R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F13R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F13R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F13R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F13R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F13R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F13R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F13R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F13R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F13R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F13R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F13R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F13R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F13R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F13R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F13R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F13R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F13R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F13R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F13R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F13R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F13R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F13R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F13R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F13R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F13R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F13R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F13R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F13R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F13R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F13R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2AC + constant CAN1_F13R2	\ read-write		\  : RESET_CAN1_F13R2 $00000000 
        \ %x  0 lshift CAN1_F13R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F13R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F13R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F13R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F13R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F13R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F13R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F13R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F13R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F13R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F13R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F13R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F13R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F13R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F13R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F13R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F13R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F13R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F13R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F13R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F13R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F13R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F13R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F13R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F13R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F13R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F13R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F13R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F13R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F13R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F13R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F13R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2B0 + constant CAN1_F14R1	\ read-write		\  : RESET_CAN1_F14R1 $00000000 
        \ %x  0 lshift CAN1_F14R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F14R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F14R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F14R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F14R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F14R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F14R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F14R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F14R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F14R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F14R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F14R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F14R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F14R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F14R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F14R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F14R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F14R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F14R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F14R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F14R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F14R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F14R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F14R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F14R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F14R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F14R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F14R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F14R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F14R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F14R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F14R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2B4 + constant CAN1_F14R2	\ read-write		\  : RESET_CAN1_F14R2 $00000000 
        \ %x  0 lshift CAN1_F14R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F14R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F14R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F14R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F14R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F14R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F14R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F14R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F14R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F14R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F14R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F14R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F14R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F14R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F14R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F14R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F14R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F14R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F14R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F14R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F14R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F14R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F14R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F14R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F14R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F14R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F14R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F14R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F14R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F14R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F14R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F14R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2B8 + constant CAN1_F15R1	\ read-write		\  : RESET_CAN1_F15R1 $00000000 
        \ %x  0 lshift CAN1_F15R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F15R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F15R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F15R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F15R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F15R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F15R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F15R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F15R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F15R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F15R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F15R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F15R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F15R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F15R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F15R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F15R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F15R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F15R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F15R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F15R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F15R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F15R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F15R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F15R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F15R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F15R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F15R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F15R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F15R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F15R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F15R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2BC + constant CAN1_F15R2	\ read-write		\  : RESET_CAN1_F15R2 $00000000 
        \ %x  0 lshift CAN1_F15R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F15R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F15R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F15R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F15R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F15R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F15R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F15R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F15R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F15R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F15R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F15R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F15R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F15R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F15R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F15R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F15R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F15R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F15R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F15R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F15R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F15R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F15R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F15R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F15R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F15R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F15R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F15R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F15R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F15R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F15R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F15R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2C0 + constant CAN1_F16R1	\ read-write		\  : RESET_CAN1_F16R1 $00000000 
        \ %x  0 lshift CAN1_F16R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F16R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F16R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F16R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F16R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F16R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F16R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F16R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F16R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F16R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F16R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F16R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F16R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F16R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F16R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F16R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F16R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F16R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F16R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F16R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F16R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F16R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F16R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F16R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F16R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F16R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F16R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F16R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F16R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F16R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F16R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F16R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2C4 + constant CAN1_F16R2	\ read-write		\  : RESET_CAN1_F16R2 $00000000 
        \ %x  0 lshift CAN1_F16R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F16R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F16R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F16R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F16R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F16R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F16R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F16R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F16R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F16R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F16R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F16R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F16R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F16R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F16R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F16R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F16R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F16R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F16R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F16R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F16R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F16R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F16R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F16R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F16R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F16R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F16R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F16R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F16R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F16R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F16R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F16R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2C8 + constant CAN1_F17R1	\ read-write		\  : RESET_CAN1_F17R1 $00000000 
        \ %x  0 lshift CAN1_F17R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F17R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F17R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F17R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F17R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F17R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F17R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F17R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F17R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F17R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F17R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F17R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F17R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F17R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F17R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F17R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F17R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F17R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F17R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F17R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F17R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F17R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F17R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F17R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F17R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F17R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F17R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F17R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F17R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F17R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F17R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F17R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2CC + constant CAN1_F17R2	\ read-write		\  : RESET_CAN1_F17R2 $00000000 
        \ %x  0 lshift CAN1_F17R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F17R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F17R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F17R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F17R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F17R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F17R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F17R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F17R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F17R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F17R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F17R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F17R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F17R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F17R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F17R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F17R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F17R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F17R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F17R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F17R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F17R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F17R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F17R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F17R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F17R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F17R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F17R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F17R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F17R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F17R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F17R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2D0 + constant CAN1_F18R1	\ read-write		\  : RESET_CAN1_F18R1 $00000000 
        \ %x  0 lshift CAN1_F18R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F18R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F18R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F18R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F18R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F18R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F18R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F18R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F18R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F18R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F18R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F18R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F18R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F18R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F18R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F18R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F18R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F18R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F18R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F18R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F18R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F18R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F18R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F18R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F18R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F18R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F18R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F18R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F18R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F18R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F18R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F18R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2D4 + constant CAN1_F18R2	\ read-write		\  : RESET_CAN1_F18R2 $00000000 
        \ %x  0 lshift CAN1_F18R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F18R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F18R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F18R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F18R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F18R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F18R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F18R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F18R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F18R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F18R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F18R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F18R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F18R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F18R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F18R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F18R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F18R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F18R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F18R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F18R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F18R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F18R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F18R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F18R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F18R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F18R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F18R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F18R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F18R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F18R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F18R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2D8 + constant CAN1_F19R1	\ read-write		\  : RESET_CAN1_F19R1 $00000000 
        \ %x  0 lshift CAN1_F19R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F19R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F19R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F19R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F19R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F19R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F19R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F19R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F19R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F19R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F19R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F19R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F19R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F19R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F19R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F19R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F19R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F19R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F19R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F19R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F19R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F19R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F19R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F19R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F19R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F19R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F19R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F19R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F19R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F19R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F19R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F19R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2DC + constant CAN1_F19R2	\ read-write		\  : RESET_CAN1_F19R2 $00000000 
        \ %x  0 lshift CAN1_F19R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F19R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F19R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F19R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F19R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F19R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F19R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F19R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F19R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F19R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F19R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F19R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F19R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F19R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F19R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F19R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F19R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F19R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F19R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F19R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F19R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F19R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F19R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F19R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F19R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F19R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F19R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F19R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F19R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F19R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F19R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F19R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2E0 + constant CAN1_F20R1	\ read-write		\  : RESET_CAN1_F20R1 $00000000 
        \ %x  0 lshift CAN1_F20R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F20R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F20R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F20R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F20R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F20R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F20R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F20R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F20R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F20R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F20R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F20R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F20R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F20R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F20R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F20R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F20R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F20R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F20R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F20R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F20R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F20R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F20R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F20R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F20R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F20R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F20R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F20R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F20R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F20R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F20R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F20R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2E4 + constant CAN1_F20R2	\ read-write		\  : RESET_CAN1_F20R2 $00000000 
        \ %x  0 lshift CAN1_F20R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F20R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F20R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F20R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F20R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F20R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F20R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F20R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F20R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F20R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F20R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F20R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F20R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F20R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F20R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F20R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F20R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F20R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F20R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F20R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F20R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F20R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F20R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F20R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F20R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F20R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F20R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F20R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F20R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F20R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F20R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F20R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2E8 + constant CAN1_F21R1	\ read-write		\  : RESET_CAN1_F21R1 $00000000 
        \ %x  0 lshift CAN1_F21R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F21R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F21R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F21R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F21R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F21R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F21R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F21R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F21R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F21R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F21R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F21R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F21R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F21R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F21R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F21R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F21R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F21R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F21R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F21R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F21R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F21R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F21R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F21R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F21R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F21R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F21R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F21R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F21R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F21R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F21R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F21R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2EC + constant CAN1_F21R2	\ read-write		\  : RESET_CAN1_F21R2 $00000000 
        \ %x  0 lshift CAN1_F21R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F21R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F21R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F21R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F21R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F21R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F21R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F21R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F21R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F21R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F21R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F21R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F21R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F21R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F21R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F21R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F21R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F21R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F21R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F21R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F21R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F21R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F21R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F21R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F21R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F21R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F21R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F21R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F21R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F21R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F21R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F21R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2F0 + constant CAN1_F22R1	\ read-write		\  : RESET_CAN1_F22R1 $00000000 
        \ %x  0 lshift CAN1_F22R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F22R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F22R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F22R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F22R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F22R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F22R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F22R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F22R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F22R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F22R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F22R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F22R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F22R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F22R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F22R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F22R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F22R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F22R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F22R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F22R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F22R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F22R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F22R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F22R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F22R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F22R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F22R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F22R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F22R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F22R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F22R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2F4 + constant CAN1_F22R2	\ read-write		\  : RESET_CAN1_F22R2 $00000000 
        \ %x  0 lshift CAN1_F22R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F22R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F22R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F22R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F22R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F22R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F22R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F22R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F22R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F22R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F22R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F22R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F22R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F22R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F22R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F22R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F22R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F22R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F22R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F22R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F22R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F22R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F22R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F22R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F22R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F22R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F22R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F22R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F22R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F22R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F22R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F22R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2F8 + constant CAN1_F23R1	\ read-write		\  : RESET_CAN1_F23R1 $00000000 
        \ %x  0 lshift CAN1_F23R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F23R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F23R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F23R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F23R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F23R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F23R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F23R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F23R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F23R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F23R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F23R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F23R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F23R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F23R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F23R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F23R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F23R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F23R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F23R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F23R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F23R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F23R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F23R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F23R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F23R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F23R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F23R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F23R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F23R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F23R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F23R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $2FC + constant CAN1_F23R2	\ read-write		\  : RESET_CAN1_F23R2 $00000000 
        \ %x  0 lshift CAN1_F23R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F23R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F23R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F23R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F23R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F23R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F23R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F23R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F23R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F23R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F23R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F23R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F23R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F23R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F23R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F23R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F23R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F23R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F23R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F23R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F23R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F23R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F23R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F23R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F23R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F23R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F23R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F23R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F23R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F23R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F23R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F23R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $300 + constant CAN1_F24R1	\ read-write		\  : RESET_CAN1_F24R1 $00000000 
        \ %x  0 lshift CAN1_F24R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F24R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F24R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F24R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F24R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F24R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F24R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F24R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F24R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F24R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F24R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F24R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F24R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F24R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F24R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F24R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F24R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F24R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F24R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F24R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F24R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F24R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F24R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F24R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F24R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F24R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F24R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F24R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F24R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F24R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F24R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F24R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $304 + constant CAN1_F24R2	\ read-write		\  : RESET_CAN1_F24R2 $00000000 
        \ %x  0 lshift CAN1_F24R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F24R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F24R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F24R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F24R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F24R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F24R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F24R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F24R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F24R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F24R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F24R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F24R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F24R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F24R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F24R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F24R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F24R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F24R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F24R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F24R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F24R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F24R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F24R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F24R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F24R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F24R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F24R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F24R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F24R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F24R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F24R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $308 + constant CAN1_F25R1	\ read-write		\  : RESET_CAN1_F25R1 $00000000 
        \ %x  0 lshift CAN1_F25R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F25R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F25R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F25R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F25R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F25R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F25R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F25R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F25R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F25R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F25R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F25R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F25R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F25R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F25R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F25R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F25R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F25R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F25R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F25R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F25R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F25R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F25R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F25R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F25R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F25R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F25R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F25R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F25R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F25R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F25R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F25R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $30C + constant CAN1_F25R2	\ read-write		\  : RESET_CAN1_F25R2 $00000000 
        \ %x  0 lshift CAN1_F25R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F25R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F25R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F25R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F25R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F25R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F25R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F25R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F25R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F25R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F25R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F25R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F25R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F25R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F25R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F25R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F25R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F25R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F25R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F25R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F25R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F25R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F25R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F25R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F25R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F25R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F25R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F25R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F25R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F25R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F25R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F25R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $310 + constant CAN1_F26R1	\ read-write		\  : RESET_CAN1_F26R1 $00000000 
        \ %x  0 lshift CAN1_F26R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F26R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F26R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F26R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F26R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F26R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F26R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F26R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F26R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F26R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F26R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F26R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F26R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F26R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F26R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F26R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F26R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F26R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F26R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F26R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F26R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F26R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F26R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F26R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F26R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F26R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F26R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F26R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F26R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F26R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F26R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F26R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $314 + constant CAN1_F26R2	\ read-write		\  : RESET_CAN1_F26R2 $00000000 
        \ %x  0 lshift CAN1_F26R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F26R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F26R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F26R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F26R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F26R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F26R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F26R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F26R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F26R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F26R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F26R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F26R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F26R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F26R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F26R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F26R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F26R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F26R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F26R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F26R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F26R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F26R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F26R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F26R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F26R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F26R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F26R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F26R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F26R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F26R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F26R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $318 + constant CAN1_F27R1	\ read-write		\  : RESET_CAN1_F27R1 $00000000 
        \ %x  0 lshift CAN1_F27R1        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F27R1        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F27R1        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F27R1        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F27R1        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F27R1        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F27R1        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F27R1        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F27R1        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F27R1        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F27R1        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F27R1        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F27R1        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F27R1        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F27R1        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F27R1        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F27R1        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F27R1        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F27R1        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F27R1        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F27R1        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F27R1        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F27R1        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F27R1        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F27R1        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F27R1        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F27R1        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F27R1        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F27R1        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F27R1        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F27R1        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F27R1        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
        CAN1 $31C + constant CAN1_F27R2	\ read-write		\  : RESET_CAN1_F27R2 $00000000 
        \ %x  0 lshift CAN1_F27R2        \ CAN1_FB0	Bit Offset:0	Bit Width:1
        \ %x  1 lshift CAN1_F27R2        \ CAN1_FB1	Bit Offset:1	Bit Width:1
        \ %x  2 lshift CAN1_F27R2        \ CAN1_FB2	Bit Offset:2	Bit Width:1
        \ %x  3 lshift CAN1_F27R2        \ CAN1_FB3	Bit Offset:3	Bit Width:1
        \ %x  4 lshift CAN1_F27R2        \ CAN1_FB4	Bit Offset:4	Bit Width:1
        \ %x  5 lshift CAN1_F27R2        \ CAN1_FB5	Bit Offset:5	Bit Width:1
        \ %x  6 lshift CAN1_F27R2        \ CAN1_FB6	Bit Offset:6	Bit Width:1
        \ %x  7 lshift CAN1_F27R2        \ CAN1_FB7	Bit Offset:7	Bit Width:1
        \ %x  8 lshift CAN1_F27R2        \ CAN1_FB8	Bit Offset:8	Bit Width:1
        \ %x  9 lshift CAN1_F27R2        \ CAN1_FB9	Bit Offset:9	Bit Width:1
        \ %x  10 lshift CAN1_F27R2        \ CAN1_FB10	Bit Offset:10	Bit Width:1
        \ %x  11 lshift CAN1_F27R2        \ CAN1_FB11	Bit Offset:11	Bit Width:1
        \ %x  12 lshift CAN1_F27R2        \ CAN1_FB12	Bit Offset:12	Bit Width:1
        \ %x  13 lshift CAN1_F27R2        \ CAN1_FB13	Bit Offset:13	Bit Width:1
        \ %x  14 lshift CAN1_F27R2        \ CAN1_FB14	Bit Offset:14	Bit Width:1
        \ %x  15 lshift CAN1_F27R2        \ CAN1_FB15	Bit Offset:15	Bit Width:1
        \ %x  16 lshift CAN1_F27R2        \ CAN1_FB16	Bit Offset:16	Bit Width:1
        \ %x  17 lshift CAN1_F27R2        \ CAN1_FB17	Bit Offset:17	Bit Width:1
        \ %x  18 lshift CAN1_F27R2        \ CAN1_FB18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift CAN1_F27R2        \ CAN1_FB19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift CAN1_F27R2        \ CAN1_FB20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift CAN1_F27R2        \ CAN1_FB21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift CAN1_F27R2        \ CAN1_FB22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift CAN1_F27R2        \ CAN1_FB23	Bit Offset:23	Bit Width:1
        \ %x  24 lshift CAN1_F27R2        \ CAN1_FB24	Bit Offset:24	Bit Width:1
        \ %x  25 lshift CAN1_F27R2        \ CAN1_FB25	Bit Offset:25	Bit Width:1
        \ %x  26 lshift CAN1_F27R2        \ CAN1_FB26	Bit Offset:26	Bit Width:1
        \ %x  27 lshift CAN1_F27R2        \ CAN1_FB27	Bit Offset:27	Bit Width:1
        \ %x  28 lshift CAN1_F27R2        \ CAN1_FB28	Bit Offset:28	Bit Width:1
        \ %x  29 lshift CAN1_F27R2        \ CAN1_FB29	Bit Offset:29	Bit Width:1
        \ %x  30 lshift CAN1_F27R2        \ CAN1_FB30	Bit Offset:30	Bit Width:1
        \ %x  31 lshift CAN1_F27R2        \ CAN1_FB31	Bit Offset:31	Bit Width:1
        
         
	
     $40006800 constant CAN2  
	  
	
     $E000E000 constant NVIC  
	 NVIC $4 + constant NVIC_ICTR	\ read-only		\  : RESET_NVIC_ICTR $00000000 
        \ %xxxx  0 lshift NVIC_ICTR        \ NVIC_INTLINESNUM	Bit Offset:0	Bit Width:4
        
        NVIC $F00 + constant NVIC_STIR	\ write-only		\  : RESET_NVIC_STIR $00000000 
        \ %xxxxxxxxx  0 lshift NVIC_STIR        \ NVIC_INTID	Bit Offset:0	Bit Width:9
        
        NVIC $100 + constant NVIC_ISER0	\ read-write		\  : RESET_NVIC_ISER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER0        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $104 + constant NVIC_ISER1	\ read-write		\  : RESET_NVIC_ISER1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER1        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $108 + constant NVIC_ISER2	\ read-write		\  : RESET_NVIC_ISER2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER2        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $180 + constant NVIC_ICER0	\ read-write		\  : RESET_NVIC_ICER0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER0        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $184 + constant NVIC_ICER1	\ read-write		\  : RESET_NVIC_ICER1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER1        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $188 + constant NVIC_ICER2	\ read-write		\  : RESET_NVIC_ICER2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER2        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $200 + constant NVIC_ISPR0	\ read-write		\  : RESET_NVIC_ISPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR0        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $204 + constant NVIC_ISPR1	\ read-write		\  : RESET_NVIC_ISPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR1        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $208 + constant NVIC_ISPR2	\ read-write		\  : RESET_NVIC_ISPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR2        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $280 + constant NVIC_ICPR0	\ read-write		\  : RESET_NVIC_ICPR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR0        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $284 + constant NVIC_ICPR1	\ read-write		\  : RESET_NVIC_ICPR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR1        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $288 + constant NVIC_ICPR2	\ read-write		\  : RESET_NVIC_ICPR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR2        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $300 + constant NVIC_IABR0	\ read-only		\  : RESET_NVIC_IABR0 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR0        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
        NVIC $304 + constant NVIC_IABR1	\ read-only		\  : RESET_NVIC_IABR1 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR1        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
        NVIC $308 + constant NVIC_IABR2	\ read-only		\  : RESET_NVIC_IABR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_IABR2        \ NVIC_ACTIVE	Bit Offset:0	Bit Width:32
        
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
        
        NVIC $43C + constant NVIC_IPR15	\ read-write		\  : RESET_NVIC_IPR15 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR15        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR15        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR15        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR15        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $440 + constant NVIC_IPR16	\ read-write		\  : RESET_NVIC_IPR16 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR16        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR16        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR16        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR16        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $444 + constant NVIC_IPR17	\ read-write		\  : RESET_NVIC_IPR17 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR17        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR17        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR17        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR17        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $448 + constant NVIC_IPR18	\ read-write		\  : RESET_NVIC_IPR18 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR18        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR18        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR18        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR18        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $44C + constant NVIC_IPR19	\ read-write		\  : RESET_NVIC_IPR19 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR19        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR19        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR19        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR19        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
        NVIC $450 + constant NVIC_IPR20	\ read-write		\  : RESET_NVIC_IPR20 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR20        \ NVIC_IPR_N0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR20        \ NVIC_IPR_N1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR20        \ NVIC_IPR_N2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR20        \ NVIC_IPR_N3	Bit Offset:24	Bit Width:8
        
         
	
     $40023C00 constant FLASH  
	 FLASH $0 + constant FLASH_ACR	\ 		\  : RESET_FLASH_ACR $00000000 
        \ %xxx  0 lshift FLASH_ACR        \ FLASH_LATENCY	Bit Offset:0	Bit Width:3
        \ %x  8 lshift FLASH_ACR        \ FLASH_PRFTEN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift FLASH_ACR        \ FLASH_ICEN	Bit Offset:9	Bit Width:1
        \ %x  10 lshift FLASH_ACR        \ FLASH_DCEN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift FLASH_ACR        \ FLASH_ICRST	Bit Offset:11	Bit Width:1
        \ %x  12 lshift FLASH_ACR        \ FLASH_DCRST	Bit Offset:12	Bit Width:1
        
        FLASH $4 + constant FLASH_KEYR	\ write-only		\  : RESET_FLASH_KEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_KEYR        \ FLASH_KEY	Bit Offset:0	Bit Width:32
        
        FLASH $8 + constant FLASH_OPTKEYR	\ write-only		\  : RESET_FLASH_OPTKEYR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FLASH_OPTKEYR        \ FLASH_OPTKEY	Bit Offset:0	Bit Width:32
        
        FLASH $C + constant FLASH_SR	\ 		\  : RESET_FLASH_SR $00000000 
        \ %x  0 lshift FLASH_SR        \ FLASH_EOP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift FLASH_SR        \ FLASH_OPERR	Bit Offset:1	Bit Width:1
        \ %x  4 lshift FLASH_SR        \ FLASH_WRPERR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift FLASH_SR        \ FLASH_PGAERR	Bit Offset:5	Bit Width:1
        \ %x  6 lshift FLASH_SR        \ FLASH_PGPERR	Bit Offset:6	Bit Width:1
        \ %x  7 lshift FLASH_SR        \ FLASH_PGSERR	Bit Offset:7	Bit Width:1
        \ %x  16 lshift FLASH_SR        \ FLASH_BSY	Bit Offset:16	Bit Width:1
        
        FLASH $10 + constant FLASH_CR	\ read-write		\  : RESET_FLASH_CR $80000000 
        \ %x  0 lshift FLASH_CR        \ FLASH_PG	Bit Offset:0	Bit Width:1
        \ %x  1 lshift FLASH_CR        \ FLASH_SER	Bit Offset:1	Bit Width:1
        \ %x  2 lshift FLASH_CR        \ FLASH_MER	Bit Offset:2	Bit Width:1
        \ %xxxxx  3 lshift FLASH_CR        \ FLASH_SNB	Bit Offset:3	Bit Width:5
        \ %xx  8 lshift FLASH_CR        \ FLASH_PSIZE	Bit Offset:8	Bit Width:2
        \ %x  15 lshift FLASH_CR        \ FLASH_MER1	Bit Offset:15	Bit Width:1
        \ %x  16 lshift FLASH_CR        \ FLASH_STRT	Bit Offset:16	Bit Width:1
        \ %x  24 lshift FLASH_CR        \ FLASH_EOPIE	Bit Offset:24	Bit Width:1
        \ %x  25 lshift FLASH_CR        \ FLASH_ERRIE	Bit Offset:25	Bit Width:1
        \ %x  31 lshift FLASH_CR        \ FLASH_LOCK	Bit Offset:31	Bit Width:1
        
        FLASH $14 + constant FLASH_OPTCR	\ read-write		\  : RESET_FLASH_OPTCR $0FFFAAED 
        \ %x  0 lshift FLASH_OPTCR        \ FLASH_OPTLOCK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift FLASH_OPTCR        \ FLASH_OPTSTRT	Bit Offset:1	Bit Width:1
        \ %xx  2 lshift FLASH_OPTCR        \ FLASH_BOR_LEV	Bit Offset:2	Bit Width:2
        \ %x  5 lshift FLASH_OPTCR        \ FLASH_WDG_SW	Bit Offset:5	Bit Width:1
        \ %x  6 lshift FLASH_OPTCR        \ FLASH_nRST_STOP	Bit Offset:6	Bit Width:1
        \ %x  7 lshift FLASH_OPTCR        \ FLASH_nRST_STDBY	Bit Offset:7	Bit Width:1
        \ %xxxxxxxx  8 lshift FLASH_OPTCR        \ FLASH_RDP	Bit Offset:8	Bit Width:8
        \ %xxxxxxxxxxxx  16 lshift FLASH_OPTCR        \ FLASH_nWRP	Bit Offset:16	Bit Width:12
        
        FLASH $18 + constant FLASH_OPTCR1	\ read-write		\  : RESET_FLASH_OPTCR1 $0FFF0000 
        \ %xxxxxxxxxxxx  16 lshift FLASH_OPTCR1        \ FLASH_nWRP	Bit Offset:16	Bit Width:12
        
         
	
     $40013C00 constant EXTI  
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
        \ %x  18 lshift EXTI_IMR        \ EXTI_MR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_IMR        \ EXTI_MR19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift EXTI_IMR        \ EXTI_MR20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift EXTI_IMR        \ EXTI_MR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_IMR        \ EXTI_MR22	Bit Offset:22	Bit Width:1
        
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
        \ %x  18 lshift EXTI_EMR        \ EXTI_MR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_EMR        \ EXTI_MR19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift EXTI_EMR        \ EXTI_MR20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift EXTI_EMR        \ EXTI_MR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_EMR        \ EXTI_MR22	Bit Offset:22	Bit Width:1
        
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
        \ %x  18 lshift EXTI_RTSR        \ EXTI_TR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_RTSR        \ EXTI_TR19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift EXTI_RTSR        \ EXTI_TR20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift EXTI_RTSR        \ EXTI_TR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_RTSR        \ EXTI_TR22	Bit Offset:22	Bit Width:1
        
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
        \ %x  18 lshift EXTI_FTSR        \ EXTI_TR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_FTSR        \ EXTI_TR19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift EXTI_FTSR        \ EXTI_TR20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift EXTI_FTSR        \ EXTI_TR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_FTSR        \ EXTI_TR22	Bit Offset:22	Bit Width:1
        
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
        \ %x  18 lshift EXTI_SWIER        \ EXTI_SWIER18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_SWIER        \ EXTI_SWIER19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift EXTI_SWIER        \ EXTI_SWIER20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift EXTI_SWIER        \ EXTI_SWIER21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_SWIER        \ EXTI_SWIER22	Bit Offset:22	Bit Width:1
        
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
        \ %x  18 lshift EXTI_PR        \ EXTI_PR18	Bit Offset:18	Bit Width:1
        \ %x  19 lshift EXTI_PR        \ EXTI_PR19	Bit Offset:19	Bit Width:1
        \ %x  20 lshift EXTI_PR        \ EXTI_PR20	Bit Offset:20	Bit Width:1
        \ %x  21 lshift EXTI_PR        \ EXTI_PR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_PR        \ EXTI_PR22	Bit Offset:22	Bit Width:1
        
         
	
     $40040000 constant OTG_HS_GLOBAL  
	 OTG_HS_GLOBAL $0 + constant OTG_HS_GLOBAL_OTG_HS_GOTGCTL	\ 		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GOTGCTL $00000800 
        \ %x  0 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_SRQSCS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_SRQ	Bit Offset:1	Bit Width:1
        \ %x  8 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_HNGSCS	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_HNPRQ	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_HSHNPEN	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_DHNPEN	Bit Offset:11	Bit Width:1
        \ %x  16 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_CIDSTS	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_DBCT	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_ASVLD	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_HS_GLOBAL_OTG_HS_GOTGCTL        \ OTG_HS_GLOBAL_BSVLD	Bit Offset:19	Bit Width:1
        
        OTG_HS_GLOBAL $4 + constant OTG_HS_GLOBAL_OTG_HS_GOTGINT	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GOTGINT $0 
        \ %x  2 lshift OTG_HS_GLOBAL_OTG_HS_GOTGINT        \ OTG_HS_GLOBAL_SEDET	Bit Offset:2	Bit Width:1
        \ %x  8 lshift OTG_HS_GLOBAL_OTG_HS_GOTGINT        \ OTG_HS_GLOBAL_SRSSCHG	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_GLOBAL_OTG_HS_GOTGINT        \ OTG_HS_GLOBAL_HNSSCHG	Bit Offset:9	Bit Width:1
        \ %x  17 lshift OTG_HS_GLOBAL_OTG_HS_GOTGINT        \ OTG_HS_GLOBAL_HNGDET	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_HS_GLOBAL_OTG_HS_GOTGINT        \ OTG_HS_GLOBAL_ADTOCHG	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_HS_GLOBAL_OTG_HS_GOTGINT        \ OTG_HS_GLOBAL_DBCDNE	Bit Offset:19	Bit Width:1
        
        OTG_HS_GLOBAL $8 + constant OTG_HS_GLOBAL_OTG_HS_GAHBCFG	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GAHBCFG $0 
        \ %x  0 lshift OTG_HS_GLOBAL_OTG_HS_GAHBCFG        \ OTG_HS_GLOBAL_GINT	Bit Offset:0	Bit Width:1
        \ %xxxx  1 lshift OTG_HS_GLOBAL_OTG_HS_GAHBCFG        \ OTG_HS_GLOBAL_HBSTLEN	Bit Offset:1	Bit Width:4
        \ %x  5 lshift OTG_HS_GLOBAL_OTG_HS_GAHBCFG        \ OTG_HS_GLOBAL_DMAEN	Bit Offset:5	Bit Width:1
        \ %x  7 lshift OTG_HS_GLOBAL_OTG_HS_GAHBCFG        \ OTG_HS_GLOBAL_TXFELVL	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_GLOBAL_OTG_HS_GAHBCFG        \ OTG_HS_GLOBAL_PTXFELVL	Bit Offset:8	Bit Width:1
        
        OTG_HS_GLOBAL $C + constant OTG_HS_GLOBAL_OTG_HS_GUSBCFG	\ 		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GUSBCFG $00000A00 
        \ %xxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_TOCAL	Bit Offset:0	Bit Width:3
        \ %x  6 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_PHYSEL	Bit Offset:6	Bit Width:1
        \ %x  8 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_SRPCAP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_HNPCAP	Bit Offset:9	Bit Width:1
        \ %xxxx  10 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_TRDT	Bit Offset:10	Bit Width:4
        \ %x  15 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_PHYLPCS	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_ULPIFSLS	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_ULPIAR	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_ULPICSM	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_ULPIEVBUSD	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_ULPIEVBUSI	Bit Offset:21	Bit Width:1
        \ %x  22 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_TSDPS	Bit Offset:22	Bit Width:1
        \ %x  23 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_PCCI	Bit Offset:23	Bit Width:1
        \ %x  24 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_PTCI	Bit Offset:24	Bit Width:1
        \ %x  25 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_ULPIIPD	Bit Offset:25	Bit Width:1
        \ %x  29 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_FHMOD	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_FDMOD	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_GLOBAL_OTG_HS_GUSBCFG        \ OTG_HS_GLOBAL_CTXPKT	Bit Offset:31	Bit Width:1
        
        OTG_HS_GLOBAL $10 + constant OTG_HS_GLOBAL_OTG_HS_GRSTCTL	\ 		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GRSTCTL $20000000 
        \ %x  0 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_CSRST	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_HSRST	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_FCRST	Bit Offset:2	Bit Width:1
        \ %x  4 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_RXFFLSH	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_TXFFLSH	Bit Offset:5	Bit Width:1
        \ %xxxxx  6 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_TXFNUM	Bit Offset:6	Bit Width:5
        \ %x  30 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_DMAREQ	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_GLOBAL_OTG_HS_GRSTCTL        \ OTG_HS_GLOBAL_AHBIDL	Bit Offset:31	Bit Width:1
        
        OTG_HS_GLOBAL $14 + constant OTG_HS_GLOBAL_OTG_HS_GINTSTS	\ 		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GINTSTS $04000020 
        \ %x  0 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_CMOD	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_MMIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_OTGINT	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_SOF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_RXFLVL	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_NPTXFE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_GINAKEFF	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_BOUTNAKEFF	Bit Offset:7	Bit Width:1
        \ %x  10 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_ESUSP	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_USBSUSP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_USBRST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_ENUMDNE	Bit Offset:13	Bit Width:1
        \ %x  14 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_ISOODRP	Bit Offset:14	Bit Width:1
        \ %x  15 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_EOPF	Bit Offset:15	Bit Width:1
        \ %x  18 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_IEPINT	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_OEPINT	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_IISOIXFR	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_PXFR_INCOMPISOOUT	Bit Offset:21	Bit Width:1
        \ %x  22 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_DATAFSUSP	Bit Offset:22	Bit Width:1
        \ %x  24 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_HPRTINT	Bit Offset:24	Bit Width:1
        \ %x  25 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_HCINT	Bit Offset:25	Bit Width:1
        \ %x  26 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_PTXFE	Bit Offset:26	Bit Width:1
        \ %x  28 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_CIDSCHG	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_DISCINT	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_SRQINT	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_GLOBAL_OTG_HS_GINTSTS        \ OTG_HS_GLOBAL_WKUINT	Bit Offset:31	Bit Width:1
        
        OTG_HS_GLOBAL $18 + constant OTG_HS_GLOBAL_OTG_HS_GINTMSK	\ 		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GINTMSK $0 
        \ %x  1 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_MMISM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_OTGINT	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_SOFM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_RXFLVLM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_NPTXFEM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_GINAKEFFM	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_GONAKEFFM	Bit Offset:7	Bit Width:1
        \ %x  10 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_ESUSPM	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_USBSUSPM	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_USBRST	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_ENUMDNEM	Bit Offset:13	Bit Width:1
        \ %x  14 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_ISOODRPM	Bit Offset:14	Bit Width:1
        \ %x  15 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_EOPFM	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_EPMISM	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_IEPINT	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_OEPINT	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_IISOIXFRM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_PXFRM_IISOOXFRM	Bit Offset:21	Bit Width:1
        \ %x  22 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_FSUSPM	Bit Offset:22	Bit Width:1
        \ %x  24 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_PRTIM	Bit Offset:24	Bit Width:1
        \ %x  25 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_HCIM	Bit Offset:25	Bit Width:1
        \ %x  26 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_PTXFEM	Bit Offset:26	Bit Width:1
        \ %x  28 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_CIDSCHGM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_DISCINT	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_SRQIM	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_GLOBAL_OTG_HS_GINTMSK        \ OTG_HS_GLOBAL_WUIM	Bit Offset:31	Bit Width:1
        
        OTG_HS_GLOBAL $1C + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host	\ read-only		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host $0 
        \ %xxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host        \ OTG_HS_GLOBAL_CHNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host        \ OTG_HS_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host        \ OTG_HS_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Host        \ OTG_HS_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        
        OTG_HS_GLOBAL $20 + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host	\ read-only		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host $0 
        \ %xxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host        \ OTG_HS_GLOBAL_CHNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host        \ OTG_HS_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host        \ OTG_HS_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Host        \ OTG_HS_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        
        OTG_HS_GLOBAL $24 + constant OTG_HS_GLOBAL_OTG_HS_GRXFSIZ	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GRXFSIZ $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GRXFSIZ        \ OTG_HS_GLOBAL_RXFD	Bit Offset:0	Bit Width:16
        
        OTG_HS_GLOBAL $28 + constant OTG_HS_GLOBAL_OTG_HS_GNPTXFSIZ_Host	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GNPTXFSIZ_Host $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GNPTXFSIZ_Host        \ OTG_HS_GLOBAL_NPTXFSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_GNPTXFSIZ_Host        \ OTG_HS_GLOBAL_NPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $28 + constant OTG_HS_GLOBAL_OTG_HS_TX0FSIZ_Peripheral	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_TX0FSIZ_Peripheral $00000200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_TX0FSIZ_Peripheral        \ OTG_HS_GLOBAL_TX0FSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_TX0FSIZ_Peripheral        \ OTG_HS_GLOBAL_TX0FD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $2C + constant OTG_HS_GLOBAL_OTG_HS_GNPTXSTS	\ read-only		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GNPTXSTS $00080200 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GNPTXSTS        \ OTG_HS_GLOBAL_NPTXFSAV	Bit Offset:0	Bit Width:16
        \ %xxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_GNPTXSTS        \ OTG_HS_GLOBAL_NPTQXSAV	Bit Offset:16	Bit Width:8
        \ %xxxxxxx  24 lshift OTG_HS_GLOBAL_OTG_HS_GNPTXSTS        \ OTG_HS_GLOBAL_NPTXQTOP	Bit Offset:24	Bit Width:7
        
        OTG_HS_GLOBAL $38 + constant OTG_HS_GLOBAL_OTG_HS_GCCFG	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GCCFG $0 
        \ %x  16 lshift OTG_HS_GLOBAL_OTG_HS_GCCFG        \ OTG_HS_GLOBAL_PWRDWN	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_GLOBAL_OTG_HS_GCCFG        \ OTG_HS_GLOBAL_I2CPADEN	Bit Offset:17	Bit Width:1
        \ %x  18 lshift OTG_HS_GLOBAL_OTG_HS_GCCFG        \ OTG_HS_GLOBAL_VBUSASEN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift OTG_HS_GLOBAL_OTG_HS_GCCFG        \ OTG_HS_GLOBAL_VBUSBSEN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift OTG_HS_GLOBAL_OTG_HS_GCCFG        \ OTG_HS_GLOBAL_SOFOUTEN	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_GLOBAL_OTG_HS_GCCFG        \ OTG_HS_GLOBAL_NOVBUSSENS	Bit Offset:21	Bit Width:1
        
        OTG_HS_GLOBAL $3C + constant OTG_HS_GLOBAL_OTG_HS_CID	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_CID $00001200 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_CID        \ OTG_HS_GLOBAL_PRODUCT_ID	Bit Offset:0	Bit Width:32
        
        OTG_HS_GLOBAL $100 + constant OTG_HS_GLOBAL_OTG_HS_HPTXFSIZ	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_HPTXFSIZ $02000600 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_HPTXFSIZ        \ OTG_HS_GLOBAL_PTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_HPTXFSIZ        \ OTG_HS_GLOBAL_PTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $104 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF1	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF1 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF1        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF1        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $108 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF2	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF2 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF2        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF2        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $11C + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF3	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF3 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF3        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF3        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $120 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF4	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF4 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF4        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF4        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $124 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF5	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF5 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF5        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF5        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $128 + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF6	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF6 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF6        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF6        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $12C + constant OTG_HS_GLOBAL_OTG_HS_DIEPTXF7	\ read-write		\  : RESET_OTG_HS_GLOBAL_OTG_HS_DIEPTXF7 $02000400 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF7        \ OTG_HS_GLOBAL_INEPTXSA	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_GLOBAL_OTG_HS_DIEPTXF7        \ OTG_HS_GLOBAL_INEPTXFD	Bit Offset:16	Bit Width:16
        
        OTG_HS_GLOBAL $1C + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral	\ read-only		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral $0 
        \ %xxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral        \ OTG_HS_GLOBAL_EPNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral        \ OTG_HS_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral        \ OTG_HS_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral        \ OTG_HS_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        \ %xxxx  21 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSR_Peripheral        \ OTG_HS_GLOBAL_FRMNUM	Bit Offset:21	Bit Width:4
        
        OTG_HS_GLOBAL $20 + constant OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral	\ read-only		\  : RESET_OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral $0 
        \ %xxxx  0 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral        \ OTG_HS_GLOBAL_EPNUM	Bit Offset:0	Bit Width:4
        \ % 4 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral        \ OTG_HS_GLOBAL_BCNT	Bit Offset:4	Bit Width:11
        \ %xx  15 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral        \ OTG_HS_GLOBAL_DPID	Bit Offset:15	Bit Width:2
        \ %xxxx  17 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral        \ OTG_HS_GLOBAL_PKTSTS	Bit Offset:17	Bit Width:4
        \ %xxxx  21 lshift OTG_HS_GLOBAL_OTG_HS_GRXSTSP_Peripheral        \ OTG_HS_GLOBAL_FRMNUM	Bit Offset:21	Bit Width:4
        
         
	
     $40040400 constant OTG_HS_HOST  
	 OTG_HS_HOST $0 + constant OTG_HS_HOST_OTG_HS_HCFG	\ 		\  : RESET_OTG_HS_HOST_OTG_HS_HCFG $0 
        \ %xx  0 lshift OTG_HS_HOST_OTG_HS_HCFG        \ OTG_HS_HOST_FSLSPCS	Bit Offset:0	Bit Width:2
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCFG        \ OTG_HS_HOST_FSLSS	Bit Offset:2	Bit Width:1
        
        OTG_HS_HOST $4 + constant OTG_HS_HOST_OTG_HS_HFIR	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HFIR $0000EA60 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HFIR        \ OTG_HS_HOST_FRIVL	Bit Offset:0	Bit Width:16
        
        OTG_HS_HOST $8 + constant OTG_HS_HOST_OTG_HS_HFNUM	\ read-only		\  : RESET_OTG_HS_HOST_OTG_HS_HFNUM $00003FFF 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HFNUM        \ OTG_HS_HOST_FRNUM	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_HOST_OTG_HS_HFNUM        \ OTG_HS_HOST_FTREM	Bit Offset:16	Bit Width:16
        
        OTG_HS_HOST $10 + constant OTG_HS_HOST_OTG_HS_HPTXSTS	\ 		\  : RESET_OTG_HS_HOST_OTG_HS_HPTXSTS $00080100 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HPTXSTS        \ OTG_HS_HOST_PTXFSAVL	Bit Offset:0	Bit Width:16
        \ %xxxxxxxx  16 lshift OTG_HS_HOST_OTG_HS_HPTXSTS        \ OTG_HS_HOST_PTXQSAV	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift OTG_HS_HOST_OTG_HS_HPTXSTS        \ OTG_HS_HOST_PTXQTOP	Bit Offset:24	Bit Width:8
        
        OTG_HS_HOST $14 + constant OTG_HS_HOST_OTG_HS_HAINT	\ read-only		\  : RESET_OTG_HS_HOST_OTG_HS_HAINT $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HAINT        \ OTG_HS_HOST_HAINT	Bit Offset:0	Bit Width:16
        
        OTG_HS_HOST $18 + constant OTG_HS_HOST_OTG_HS_HAINTMSK	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HAINTMSK $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HAINTMSK        \ OTG_HS_HOST_HAINTM	Bit Offset:0	Bit Width:16
        
        OTG_HS_HOST $40 + constant OTG_HS_HOST_OTG_HS_HPRT	\ 		\  : RESET_OTG_HS_HOST_OTG_HS_HPRT $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PCSTS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PCDET	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PENA	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PENCHNG	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_POCA	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_POCCHNG	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PRES	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PSUSP	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PRST	Bit Offset:8	Bit Width:1
        \ %xx  10 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PLSTS	Bit Offset:10	Bit Width:2
        \ %x  12 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PPWR	Bit Offset:12	Bit Width:1
        \ %xxxx  13 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PTCTL	Bit Offset:13	Bit Width:4
        \ %xx  17 lshift OTG_HS_HOST_OTG_HS_HPRT        \ OTG_HS_HOST_PSPD	Bit Offset:17	Bit Width:2
        
        OTG_HS_HOST $100 + constant OTG_HS_HOST_OTG_HS_HCCHAR0	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR0 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR0        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $120 + constant OTG_HS_HOST_OTG_HS_HCCHAR1	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR1 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR1        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $140 + constant OTG_HS_HOST_OTG_HS_HCCHAR2	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR2 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR2        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $160 + constant OTG_HS_HOST_OTG_HS_HCCHAR3	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR3 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR3        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $180 + constant OTG_HS_HOST_OTG_HS_HCCHAR4	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR4 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR4        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $1A0 + constant OTG_HS_HOST_OTG_HS_HCCHAR5	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR5 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR5        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $1C0 + constant OTG_HS_HOST_OTG_HS_HCCHAR6	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR6 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR6        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $1E0 + constant OTG_HS_HOST_OTG_HS_HCCHAR7	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR7 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR7        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $200 + constant OTG_HS_HOST_OTG_HS_HCCHAR8	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR8 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR8        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $220 + constant OTG_HS_HOST_OTG_HS_HCCHAR9	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR9 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR9        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $240 + constant OTG_HS_HOST_OTG_HS_HCCHAR10	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR10 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR10        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $260 + constant OTG_HS_HOST_OTG_HS_HCCHAR11	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCCHAR11 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_MPSIZ	Bit Offset:0	Bit Width:11
        \ %xxxx  11 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_EPNUM	Bit Offset:11	Bit Width:4
        \ %x  15 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_EPDIR	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_LSDEV	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_EPTYP	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_MC	Bit Offset:20	Bit Width:2
        \ %xxxxxxx  22 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_DAD	Bit Offset:22	Bit Width:7
        \ %x  29 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_ODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_CHDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCCHAR11        \ OTG_HS_HOST_CHENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $104 + constant OTG_HS_HOST_OTG_HS_HCSPLT0	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT0 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT0        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT0        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT0        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT0        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT0        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $124 + constant OTG_HS_HOST_OTG_HS_HCSPLT1	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT1 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT1        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT1        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT1        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT1        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT1        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $144 + constant OTG_HS_HOST_OTG_HS_HCSPLT2	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT2 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT2        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT2        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT2        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT2        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT2        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $164 + constant OTG_HS_HOST_OTG_HS_HCSPLT3	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT3 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT3        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT3        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT3        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT3        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT3        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $184 + constant OTG_HS_HOST_OTG_HS_HCSPLT4	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT4 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT4        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT4        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT4        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT4        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT4        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $1A4 + constant OTG_HS_HOST_OTG_HS_HCSPLT5	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT5 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT5        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT5        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT5        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT5        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT5        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $1C4 + constant OTG_HS_HOST_OTG_HS_HCSPLT6	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT6 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT6        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT6        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT6        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT6        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT6        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $1E4 + constant OTG_HS_HOST_OTG_HS_HCSPLT7	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT7 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT7        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT7        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT7        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT7        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT7        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $204 + constant OTG_HS_HOST_OTG_HS_HCSPLT8	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT8 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT8        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT8        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT8        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT8        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT8        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $224 + constant OTG_HS_HOST_OTG_HS_HCSPLT9	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT9 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT9        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT9        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT9        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT9        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT9        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $244 + constant OTG_HS_HOST_OTG_HS_HCSPLT10	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT10 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT10        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT10        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT10        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT10        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT10        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $264 + constant OTG_HS_HOST_OTG_HS_HCSPLT11	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCSPLT11 $0 
        \ %xxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCSPLT11        \ OTG_HS_HOST_PRTADDR	Bit Offset:0	Bit Width:7
        \ %xxxxxxx  7 lshift OTG_HS_HOST_OTG_HS_HCSPLT11        \ OTG_HS_HOST_HUBADDR	Bit Offset:7	Bit Width:7
        \ %xx  14 lshift OTG_HS_HOST_OTG_HS_HCSPLT11        \ OTG_HS_HOST_XACTPOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift OTG_HS_HOST_OTG_HS_HCSPLT11        \ OTG_HS_HOST_COMPLSPLT	Bit Offset:16	Bit Width:1
        \ %x  31 lshift OTG_HS_HOST_OTG_HS_HCSPLT11        \ OTG_HS_HOST_SPLITEN	Bit Offset:31	Bit Width:1
        
        OTG_HS_HOST $108 + constant OTG_HS_HOST_OTG_HS_HCINT0	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT0 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT0        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $128 + constant OTG_HS_HOST_OTG_HS_HCINT1	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT1 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT1        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $148 + constant OTG_HS_HOST_OTG_HS_HCINT2	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT2 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT2        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $168 + constant OTG_HS_HOST_OTG_HS_HCINT3	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT3 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT3        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $188 + constant OTG_HS_HOST_OTG_HS_HCINT4	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT4 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT4        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $1A8 + constant OTG_HS_HOST_OTG_HS_HCINT5	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT5 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT5        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $1C8 + constant OTG_HS_HOST_OTG_HS_HCINT6	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT6 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT6        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $1E8 + constant OTG_HS_HOST_OTG_HS_HCINT7	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT7 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT7        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $208 + constant OTG_HS_HOST_OTG_HS_HCINT8	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT8 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT8        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $228 + constant OTG_HS_HOST_OTG_HS_HCINT9	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT9 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT9        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $248 + constant OTG_HS_HOST_OTG_HS_HCINT10	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT10 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT10        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $268 + constant OTG_HS_HOST_OTG_HS_HCINT11	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINT11 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_CHH	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_STALL	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_NAK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_ACK	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_TXERR	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_BBERR	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_FRMOR	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINT11        \ OTG_HS_HOST_DTERR	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $10C + constant OTG_HS_HOST_OTG_HS_HCINTMSK0	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK0 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK0        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $12C + constant OTG_HS_HOST_OTG_HS_HCINTMSK1	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK1 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK1        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $14C + constant OTG_HS_HOST_OTG_HS_HCINTMSK2	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK2 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK2        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $16C + constant OTG_HS_HOST_OTG_HS_HCINTMSK3	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK3 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK3        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $18C + constant OTG_HS_HOST_OTG_HS_HCINTMSK4	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK4 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK4        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $1AC + constant OTG_HS_HOST_OTG_HS_HCINTMSK5	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK5 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK5        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $1CC + constant OTG_HS_HOST_OTG_HS_HCINTMSK6	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK6 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK6        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $1EC + constant OTG_HS_HOST_OTG_HS_HCINTMSK7	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK7 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK7        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $20C + constant OTG_HS_HOST_OTG_HS_HCINTMSK8	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK8 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK8        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $22C + constant OTG_HS_HOST_OTG_HS_HCINTMSK9	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK9 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK9        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $24C + constant OTG_HS_HOST_OTG_HS_HCINTMSK10	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK10 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK10        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $26C + constant OTG_HS_HOST_OTG_HS_HCINTMSK11	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCINTMSK11 $0 
        \ %x  0 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_CHHM	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_AHBERR	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_STALLM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_NAKM	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_ACKM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_NYET	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_TXERRM	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_BBERRM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_FRMORM	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_HOST_OTG_HS_HCINTMSK11        \ OTG_HS_HOST_DTERRM	Bit Offset:10	Bit Width:1
        
        OTG_HS_HOST $110 + constant OTG_HS_HOST_OTG_HS_HCTSIZ0	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ0 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ0        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ0        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ0        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $130 + constant OTG_HS_HOST_OTG_HS_HCTSIZ1	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ1 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ1        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ1        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ1        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $150 + constant OTG_HS_HOST_OTG_HS_HCTSIZ2	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ2 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ2        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ2        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ2        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $170 + constant OTG_HS_HOST_OTG_HS_HCTSIZ3	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ3 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ3        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ3        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ3        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $190 + constant OTG_HS_HOST_OTG_HS_HCTSIZ4	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ4 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ4        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ4        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ4        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $1B0 + constant OTG_HS_HOST_OTG_HS_HCTSIZ5	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ5 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ5        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ5        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ5        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $1D0 + constant OTG_HS_HOST_OTG_HS_HCTSIZ6	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ6 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ6        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ6        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ6        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $1F0 + constant OTG_HS_HOST_OTG_HS_HCTSIZ7	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ7 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ7        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ7        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ7        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $210 + constant OTG_HS_HOST_OTG_HS_HCTSIZ8	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ8 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ8        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ8        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ8        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $230 + constant OTG_HS_HOST_OTG_HS_HCTSIZ9	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ9 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ9        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ9        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ9        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $250 + constant OTG_HS_HOST_OTG_HS_HCTSIZ10	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ10 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ10        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ10        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ10        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $270 + constant OTG_HS_HOST_OTG_HS_HCTSIZ11	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCTSIZ11 $0 
        \ % 0 lshift OTG_HS_HOST_OTG_HS_HCTSIZ11        \ OTG_HS_HOST_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_HOST_OTG_HS_HCTSIZ11        \ OTG_HS_HOST_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_HOST_OTG_HS_HCTSIZ11        \ OTG_HS_HOST_DPID	Bit Offset:29	Bit Width:2
        
        OTG_HS_HOST $114 + constant OTG_HS_HOST_OTG_HS_HCDMA0	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA0 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA0        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $134 + constant OTG_HS_HOST_OTG_HS_HCDMA1	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA1 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA1        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $154 + constant OTG_HS_HOST_OTG_HS_HCDMA2	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA2 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA2        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $174 + constant OTG_HS_HOST_OTG_HS_HCDMA3	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA3 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA3        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $194 + constant OTG_HS_HOST_OTG_HS_HCDMA4	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA4 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA4        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $1B4 + constant OTG_HS_HOST_OTG_HS_HCDMA5	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA5 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA5        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $1D4 + constant OTG_HS_HOST_OTG_HS_HCDMA6	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA6 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA6        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $1F4 + constant OTG_HS_HOST_OTG_HS_HCDMA7	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA7 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA7        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $214 + constant OTG_HS_HOST_OTG_HS_HCDMA8	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA8 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA8        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $234 + constant OTG_HS_HOST_OTG_HS_HCDMA9	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA9 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA9        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $254 + constant OTG_HS_HOST_OTG_HS_HCDMA10	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA10 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA10        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_HOST $274 + constant OTG_HS_HOST_OTG_HS_HCDMA11	\ read-write		\  : RESET_OTG_HS_HOST_OTG_HS_HCDMA11 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_HOST_OTG_HS_HCDMA11        \ OTG_HS_HOST_DMAADDR	Bit Offset:0	Bit Width:32
        
         
	
     $40040800 constant OTG_HS_DEVICE  
	 OTG_HS_DEVICE $0 + constant OTG_HS_DEVICE_OTG_HS_DCFG	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DCFG $02200000 
        \ %xx  0 lshift OTG_HS_DEVICE_OTG_HS_DCFG        \ OTG_HS_DEVICE_DSPD	Bit Offset:0	Bit Width:2
        \ %x  2 lshift OTG_HS_DEVICE_OTG_HS_DCFG        \ OTG_HS_DEVICE_NZLSOHSK	Bit Offset:2	Bit Width:1
        \ %xxxxxxx  4 lshift OTG_HS_DEVICE_OTG_HS_DCFG        \ OTG_HS_DEVICE_DAD	Bit Offset:4	Bit Width:7
        \ %xx  11 lshift OTG_HS_DEVICE_OTG_HS_DCFG        \ OTG_HS_DEVICE_PFIVL	Bit Offset:11	Bit Width:2
        \ %xx  24 lshift OTG_HS_DEVICE_OTG_HS_DCFG        \ OTG_HS_DEVICE_PERSCHIVL	Bit Offset:24	Bit Width:2
        
        OTG_HS_DEVICE $4 + constant OTG_HS_DEVICE_OTG_HS_DCTL	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DCTL $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_RWUSIG	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_SDIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_GINSTS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_GONSTS	Bit Offset:3	Bit Width:1
        \ %xxx  4 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_TCTL	Bit Offset:4	Bit Width:3
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_SGINAK	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_CGINAK	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_SGONAK	Bit Offset:9	Bit Width:1
        \ %x  10 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_CGONAK	Bit Offset:10	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DCTL        \ OTG_HS_DEVICE_POPRGDNE	Bit Offset:11	Bit Width:1
        
        OTG_HS_DEVICE $8 + constant OTG_HS_DEVICE_OTG_HS_DSTS	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DSTS $00000010 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DSTS        \ OTG_HS_DEVICE_SUSPSTS	Bit Offset:0	Bit Width:1
        \ %xx  1 lshift OTG_HS_DEVICE_OTG_HS_DSTS        \ OTG_HS_DEVICE_ENUMSPD	Bit Offset:1	Bit Width:2
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DSTS        \ OTG_HS_DEVICE_EERR	Bit Offset:3	Bit Width:1
        \ %xxxxxxxxxxxxxx  8 lshift OTG_HS_DEVICE_OTG_HS_DSTS        \ OTG_HS_DEVICE_FNSOF	Bit Offset:8	Bit Width:14
        
        OTG_HS_DEVICE $10 + constant OTG_HS_DEVICE_OTG_HS_DIEPMSK	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPMSK $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_TOM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_ITTXFEMSK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_INEPNMM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_INEPNEM	Bit Offset:6	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_TXFURM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPMSK        \ OTG_HS_DEVICE_BIM	Bit Offset:9	Bit Width:1
        
        OTG_HS_DEVICE $14 + constant OTG_HS_DEVICE_OTG_HS_DOEPMSK	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPMSK $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_STUPM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_OTEPDM	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_OPEM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DOEPMSK        \ OTG_HS_DEVICE_BOIM	Bit Offset:9	Bit Width:1
        
        OTG_HS_DEVICE $18 + constant OTG_HS_DEVICE_OTG_HS_DAINT	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DAINT $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DAINT        \ OTG_HS_DEVICE_IEPINT	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_DEVICE_OTG_HS_DAINT        \ OTG_HS_DEVICE_OEPINT	Bit Offset:16	Bit Width:16
        
        OTG_HS_DEVICE $1C + constant OTG_HS_DEVICE_OTG_HS_DAINTMSK	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DAINTMSK $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DAINTMSK        \ OTG_HS_DEVICE_IEPM	Bit Offset:0	Bit Width:16
        \ %xxxxxxxxxxxxxxxx  16 lshift OTG_HS_DEVICE_OTG_HS_DAINTMSK        \ OTG_HS_DEVICE_OEPM	Bit Offset:16	Bit Width:16
        
        OTG_HS_DEVICE $28 + constant OTG_HS_DEVICE_OTG_HS_DVBUSDIS	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DVBUSDIS $000017D7 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DVBUSDIS        \ OTG_HS_DEVICE_VBUSDT	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $2C + constant OTG_HS_DEVICE_OTG_HS_DVBUSPULSE	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DVBUSPULSE $000005B8 
        \ %xxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DVBUSPULSE        \ OTG_HS_DEVICE_DVBUSP	Bit Offset:0	Bit Width:12
        
        OTG_HS_DEVICE $30 + constant OTG_HS_DEVICE_OTG_HS_DTHRCTL	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTHRCTL $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DTHRCTL        \ OTG_HS_DEVICE_NONISOTHREN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DTHRCTL        \ OTG_HS_DEVICE_ISOTHREN	Bit Offset:1	Bit Width:1
        \ %xxxxxxxxx  2 lshift OTG_HS_DEVICE_OTG_HS_DTHRCTL        \ OTG_HS_DEVICE_TXTHRLEN	Bit Offset:2	Bit Width:9
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DTHRCTL        \ OTG_HS_DEVICE_RXTHREN	Bit Offset:16	Bit Width:1
        \ %xxxxxxxxx  17 lshift OTG_HS_DEVICE_OTG_HS_DTHRCTL        \ OTG_HS_DEVICE_RXTHRLEN	Bit Offset:17	Bit Width:9
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DTHRCTL        \ OTG_HS_DEVICE_ARPEN	Bit Offset:27	Bit Width:1
        
        OTG_HS_DEVICE $34 + constant OTG_HS_DEVICE_OTG_HS_DIEPEMPMSK	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPEMPMSK $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPEMPMSK        \ OTG_HS_DEVICE_INEPTXFEM	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $38 + constant OTG_HS_DEVICE_OTG_HS_DEACHINT	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DEACHINT $0 
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DEACHINT        \ OTG_HS_DEVICE_IEP1INT	Bit Offset:1	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DEACHINT        \ OTG_HS_DEVICE_OEP1INT	Bit Offset:17	Bit Width:1
        
        OTG_HS_DEVICE $3C + constant OTG_HS_DEVICE_OTG_HS_DEACHINTMSK	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DEACHINTMSK $0 
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DEACHINTMSK        \ OTG_HS_DEVICE_IEP1INTM	Bit Offset:1	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DEACHINTMSK        \ OTG_HS_DEVICE_OEP1INTM	Bit Offset:17	Bit Width:1
        
        OTG_HS_DEVICE $40 + constant OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_TOM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_ITTXFEMSK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_INEPNMM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_INEPNEM	Bit Offset:6	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_TXFURM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_BIM	Bit Offset:9	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPEACHMSK1        \ OTG_HS_DEVICE_NAKM	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $80 + constant OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_XFRCM	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_EPDM	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_TOM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_ITTXFEMSK	Bit Offset:4	Bit Width:1
        \ %x  5 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_INEPNMM	Bit Offset:5	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_INEPNEM	Bit Offset:6	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_TXFURM	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_BIM	Bit Offset:9	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_BERRM	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_NAKM	Bit Offset:13	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPEACHMSK1        \ OTG_HS_DEVICE_NYETM	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $100 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL0	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL0 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL0        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $120 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL1	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL1 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL1        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $140 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL2	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL2 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL2        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $160 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL3	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL3 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL3        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $180 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL4	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL4 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL4        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $1A0 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL5	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL5 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL5        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $1C0 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL6	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL6 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL6        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $1E0 + constant OTG_HS_DEVICE_OTG_HS_DIEPCTL7	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPCTL7 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %xxxx  22 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_TXFNUM	Bit Offset:22	Bit Width:4
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DIEPCTL7        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $108 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT0	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT0 $00000080 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT0        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $128 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT1	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT1 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT1        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $148 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT2	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT2 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT2        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $168 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT3	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT3 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT3        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $188 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT4	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT4 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT4        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $1A8 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT5	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT5 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT5        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $1C8 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT6	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT6 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT6        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $1E8 + constant OTG_HS_DEVICE_OTG_HS_DIEPINT7	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPINT7 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_TOC	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_ITTXFE	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_INEPNE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_TXFE	Bit Offset:7	Bit Width:1
        \ %x  8 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_TXFIFOUDRN	Bit Offset:8	Bit Width:1
        \ %x  9 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_BNA	Bit Offset:9	Bit Width:1
        \ %x  11 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_PKTDRPSTS	Bit Offset:11	Bit Width:1
        \ %x  12 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_BERR	Bit Offset:12	Bit Width:1
        \ %x  13 lshift OTG_HS_DEVICE_OTG_HS_DIEPINT7        \ OTG_HS_DEVICE_NAK	Bit Offset:13	Bit Width:1
        
        OTG_HS_DEVICE $110 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ0	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPTSIZ0 $0 
        \ %xxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ0        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:7
        \ %xx  19 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ0        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:2
        
        OTG_HS_DEVICE $114 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA1	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPDMA1 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPDMA1        \ OTG_HS_DEVICE_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_DEVICE $134 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA2	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPDMA2 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPDMA2        \ OTG_HS_DEVICE_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_DEVICE $154 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA3	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPDMA3 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPDMA3        \ OTG_HS_DEVICE_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_DEVICE $174 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA4	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPDMA4 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPDMA4        \ OTG_HS_DEVICE_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_DEVICE $194 + constant OTG_HS_DEVICE_OTG_HS_DIEPDMA5	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPDMA5 $0 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DIEPDMA5        \ OTG_HS_DEVICE_DMAADDR	Bit Offset:0	Bit Width:32
        
        OTG_HS_DEVICE $118 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS0	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTXFSTS0 $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DTXFSTS0        \ OTG_HS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $138 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS1	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTXFSTS1 $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DTXFSTS1        \ OTG_HS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $158 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS2	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTXFSTS2 $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DTXFSTS2        \ OTG_HS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $178 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS3	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTXFSTS3 $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DTXFSTS3        \ OTG_HS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $198 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS4	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTXFSTS4 $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DTXFSTS4        \ OTG_HS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $1B8 + constant OTG_HS_DEVICE_OTG_HS_DTXFSTS5	\ read-only		\  : RESET_OTG_HS_DEVICE_OTG_HS_DTXFSTS5 $0 
        \ %xxxxxxxxxxxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DTXFSTS5        \ OTG_HS_DEVICE_INEPTFSAV	Bit Offset:0	Bit Width:16
        
        OTG_HS_DEVICE $130 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ1	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPTSIZ1 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ1        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ1        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ1        \ OTG_HS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $150 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ2	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPTSIZ2 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ2        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ2        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ2        \ OTG_HS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $170 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ3	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPTSIZ3 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ3        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ3        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ3        \ OTG_HS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $190 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ4	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPTSIZ4 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ4        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ4        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ4        \ OTG_HS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $1B0 + constant OTG_HS_DEVICE_OTG_HS_DIEPTSIZ5	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DIEPTSIZ5 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ5        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ5        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DIEPTSIZ5        \ OTG_HS_DEVICE_MCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $300 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL0	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPCTL0 $00008000 
        \ %xx  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:2
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  20 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL0        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $320 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL1	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPCTL1 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  20 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL1        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $340 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL2	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPCTL2 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  20 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL2        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $360 + constant OTG_HS_DEVICE_OTG_HS_DOEPCTL3	\ 		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPCTL3 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_MPSIZ	Bit Offset:0	Bit Width:11
        \ %x  15 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_USBAEP	Bit Offset:15	Bit Width:1
        \ %x  16 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_EONUM_DPID	Bit Offset:16	Bit Width:1
        \ %x  17 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_NAKSTS	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_EPTYP	Bit Offset:18	Bit Width:2
        \ %x  20 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_SNPM	Bit Offset:20	Bit Width:1
        \ %x  21 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_Stall	Bit Offset:21	Bit Width:1
        \ %x  26 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_CNAK	Bit Offset:26	Bit Width:1
        \ %x  27 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_SNAK	Bit Offset:27	Bit Width:1
        \ %x  28 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_SD0PID_SEVNFRM	Bit Offset:28	Bit Width:1
        \ %x  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_SODDFRM	Bit Offset:29	Bit Width:1
        \ %x  30 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_EPDIS	Bit Offset:30	Bit Width:1
        \ %x  31 lshift OTG_HS_DEVICE_OTG_HS_DOEPCTL3        \ OTG_HS_DEVICE_EPENA	Bit Offset:31	Bit Width:1
        
        OTG_HS_DEVICE $308 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT0	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT0 $00000080 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT0        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT0        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT0        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT0        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT0        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT0        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $328 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT1	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT1 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT1        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT1        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT1        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT1        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT1        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT1        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $348 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT2	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT2 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT2        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT2        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT2        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT2        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT2        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT2        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $368 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT3	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT3 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT3        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT3        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT3        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT3        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT3        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT3        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $388 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT4	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT4 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT4        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT4        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT4        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT4        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT4        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT4        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $3A8 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT5	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT5 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT5        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT5        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT5        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT5        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT5        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT5        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $3C8 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT6	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT6 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT6        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT6        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT6        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT6        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT6        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT6        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $3E8 + constant OTG_HS_DEVICE_OTG_HS_DOEPINT7	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPINT7 $0 
        \ %x  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT7        \ OTG_HS_DEVICE_XFRC	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT7        \ OTG_HS_DEVICE_EPDISD	Bit Offset:1	Bit Width:1
        \ %x  3 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT7        \ OTG_HS_DEVICE_STUP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT7        \ OTG_HS_DEVICE_OTEPDIS	Bit Offset:4	Bit Width:1
        \ %x  6 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT7        \ OTG_HS_DEVICE_B2BSTUP	Bit Offset:6	Bit Width:1
        \ %x  14 lshift OTG_HS_DEVICE_OTG_HS_DOEPINT7        \ OTG_HS_DEVICE_NYET	Bit Offset:14	Bit Width:1
        
        OTG_HS_DEVICE $310 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ0	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPTSIZ0 $0 
        \ %xxxxxxx  0 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ0        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:7
        \ %x  19 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ0        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:1
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ0        \ OTG_HS_DEVICE_STUPCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $330 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ1	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPTSIZ1 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ1        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ1        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ1        \ OTG_HS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $350 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ2	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPTSIZ2 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ2        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ2        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ2        \ OTG_HS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $370 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ3	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPTSIZ3 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ3        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ3        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ3        \ OTG_HS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        
        OTG_HS_DEVICE $390 + constant OTG_HS_DEVICE_OTG_HS_DOEPTSIZ4	\ read-write		\  : RESET_OTG_HS_DEVICE_OTG_HS_DOEPTSIZ4 $0 
        \ % 0 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ4        \ OTG_HS_DEVICE_XFRSIZ	Bit Offset:0	Bit Width:19
        \ % 19 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ4        \ OTG_HS_DEVICE_PKTCNT	Bit Offset:19	Bit Width:10
        \ %xx  29 lshift OTG_HS_DEVICE_OTG_HS_DOEPTSIZ4        \ OTG_HS_DEVICE_RXDPID_STUPCNT	Bit Offset:29	Bit Width:2
        
         
	
     $40040E00 constant OTG_HS_PWRCLK  
	 OTG_HS_PWRCLK $0 + constant OTG_HS_PWRCLK_OTG_HS_PCGCR	\ read-write		\  : RESET_OTG_HS_PWRCLK_OTG_HS_PCGCR $0 
        \ %x  0 lshift OTG_HS_PWRCLK_OTG_HS_PCGCR        \ OTG_HS_PWRCLK_STPPCLK	Bit Offset:0	Bit Width:1
        \ %x  1 lshift OTG_HS_PWRCLK_OTG_HS_PCGCR        \ OTG_HS_PWRCLK_GATEHCLK	Bit Offset:1	Bit Width:1
        \ %x  4 lshift OTG_HS_PWRCLK_OTG_HS_PCGCR        \ OTG_HS_PWRCLK_PHYSUSP	Bit Offset:4	Bit Width:1
        
         
	
     $E0042000 constant DBG  
	 DBG $0 + constant DBG_DBGMCU_IDCODE	\ read-only		\  : RESET_DBG_DBGMCU_IDCODE $10006411 
        \ %xxxxxxxxxxxx  0 lshift DBG_DBGMCU_IDCODE        \ DBG_DEV_ID	Bit Offset:0	Bit Width:12
        \ %xxxxxxxxxxxxxxxx  16 lshift DBG_DBGMCU_IDCODE        \ DBG_REV_ID	Bit Offset:16	Bit Width:16
        
        DBG $4 + constant DBG_DBGMCU_CR	\ read-write		\  : RESET_DBG_DBGMCU_CR $00000000 
        \ %x  0 lshift DBG_DBGMCU_CR        \ DBG_DBG_SLEEP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DBG_DBGMCU_CR        \ DBG_DBG_STOP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DBG_DBGMCU_CR        \ DBG_DBG_STANDBY	Bit Offset:2	Bit Width:1
        \ %x  5 lshift DBG_DBGMCU_CR        \ DBG_TRACE_IOEN	Bit Offset:5	Bit Width:1
        \ %xx  6 lshift DBG_DBGMCU_CR        \ DBG_TRACE_MODE	Bit Offset:6	Bit Width:2
        
        DBG $8 + constant DBG_DBGMCU_APB1_FZ	\ read-write		\  : RESET_DBG_DBGMCU_APB1_FZ $00000000 
        \ %x  0 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM2_STOP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM3_STOP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM4_STOP	Bit Offset:2	Bit Width:1
        \ %x  3 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM5_STOP	Bit Offset:3	Bit Width:1
        \ %x  4 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM6_STOP	Bit Offset:4	Bit Width:1
        \ %x  5 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM7_STOP	Bit Offset:5	Bit Width:1
        \ %x  6 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM12_STOP	Bit Offset:6	Bit Width:1
        \ %x  7 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM13_STOP	Bit Offset:7	Bit Width:1
        \ %x  8 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_TIM14_STOP	Bit Offset:8	Bit Width:1
        \ %x  11 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_WWDG_STOP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_IWDEG_STOP	Bit Offset:12	Bit Width:1
        \ %x  21 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_J2C1_SMBUS_TIMEOUT	Bit Offset:21	Bit Width:1
        \ %x  22 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_J2C2_SMBUS_TIMEOUT	Bit Offset:22	Bit Width:1
        \ %x  23 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_J2C3SMBUS_TIMEOUT	Bit Offset:23	Bit Width:1
        \ %x  25 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_CAN1_STOP	Bit Offset:25	Bit Width:1
        \ %x  26 lshift DBG_DBGMCU_APB1_FZ        \ DBG_DBG_CAN2_STOP	Bit Offset:26	Bit Width:1
        
        DBG $C + constant DBG_DBGMCU_APB2_FZ	\ read-write		\  : RESET_DBG_DBGMCU_APB2_FZ $00000000 
        \ %x  0 lshift DBG_DBGMCU_APB2_FZ        \ DBG_DBG_TIM1_STOP	Bit Offset:0	Bit Width:1
        \ %x  1 lshift DBG_DBGMCU_APB2_FZ        \ DBG_DBG_TIM8_STOP	Bit Offset:1	Bit Width:1
        \ %x  16 lshift DBG_DBGMCU_APB2_FZ        \ DBG_DBG_TIM9_STOP	Bit Offset:16	Bit Width:1
        \ %x  17 lshift DBG_DBGMCU_APB2_FZ        \ DBG_DBG_TIM10_STOP	Bit Offset:17	Bit Width:1
        \ %x  18 lshift DBG_DBGMCU_APB2_FZ        \ DBG_DBG_TIM11_STOP	Bit Offset:18	Bit Width:1
        
         
	
     $A0000000 constant FMC  
	 FMC $0 + constant FMC_BCR1	\ read-write		\  : RESET_FMC_BCR1 $000030D0 
        \ %x  20 lshift FMC_BCR1        \ FMC_CCLKEN	Bit Offset:20	Bit Width:1
        \ %x  19 lshift FMC_BCR1        \ FMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FMC_BCR1        \ FMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FMC_BCR1        \ FMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FMC_BCR1        \ FMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FMC_BCR1        \ FMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FMC_BCR1        \ FMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  9 lshift FMC_BCR1        \ FMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FMC_BCR1        \ FMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FMC_BCR1        \ FMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_BCR1        \ FMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FMC_BCR1        \ FMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FMC_BCR1        \ FMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_BCR1        \ FMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FMC $4 + constant FMC_BTR1	\ read-write		\  : RESET_FMC_BTR1 $FFFFFFFF 
        \ %xx  28 lshift FMC_BTR1        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BTR1        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BTR1        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FMC_BTR1        \ FMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BTR1        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BTR1        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BTR1        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $8 + constant FMC_BCR2	\ read-write		\  : RESET_FMC_BCR2 $000030D0 
        \ %x  19 lshift FMC_BCR2        \ FMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FMC_BCR2        \ FMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FMC_BCR2        \ FMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FMC_BCR2        \ FMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FMC_BCR2        \ FMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FMC_BCR2        \ FMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FMC_BCR2        \ FMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FMC_BCR2        \ FMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FMC_BCR2        \ FMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FMC_BCR2        \ FMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_BCR2        \ FMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FMC_BCR2        \ FMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FMC_BCR2        \ FMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_BCR2        \ FMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FMC $C + constant FMC_BTR2	\ read-write		\  : RESET_FMC_BTR2 $FFFFFFFF 
        \ %xx  28 lshift FMC_BTR2        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BTR2        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BTR2        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FMC_BTR2        \ FMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BTR2        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BTR2        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BTR2        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $10 + constant FMC_BCR3	\ read-write		\  : RESET_FMC_BCR3 $000030D0 
        \ %x  19 lshift FMC_BCR3        \ FMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FMC_BCR3        \ FMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FMC_BCR3        \ FMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FMC_BCR3        \ FMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FMC_BCR3        \ FMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FMC_BCR3        \ FMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FMC_BCR3        \ FMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FMC_BCR3        \ FMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FMC_BCR3        \ FMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FMC_BCR3        \ FMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_BCR3        \ FMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FMC_BCR3        \ FMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FMC_BCR3        \ FMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_BCR3        \ FMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FMC $14 + constant FMC_BTR3	\ read-write		\  : RESET_FMC_BTR3 $FFFFFFFF 
        \ %xx  28 lshift FMC_BTR3        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BTR3        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BTR3        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FMC_BTR3        \ FMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BTR3        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BTR3        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BTR3        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $18 + constant FMC_BCR4	\ read-write		\  : RESET_FMC_BCR4 $000030D0 
        \ %x  19 lshift FMC_BCR4        \ FMC_CBURSTRW	Bit Offset:19	Bit Width:1
        \ %x  15 lshift FMC_BCR4        \ FMC_ASYNCWAIT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift FMC_BCR4        \ FMC_EXTMOD	Bit Offset:14	Bit Width:1
        \ %x  13 lshift FMC_BCR4        \ FMC_WAITEN	Bit Offset:13	Bit Width:1
        \ %x  12 lshift FMC_BCR4        \ FMC_WREN	Bit Offset:12	Bit Width:1
        \ %x  11 lshift FMC_BCR4        \ FMC_WAITCFG	Bit Offset:11	Bit Width:1
        \ %x  10 lshift FMC_BCR4        \ FMC_WRAPMOD	Bit Offset:10	Bit Width:1
        \ %x  9 lshift FMC_BCR4        \ FMC_WAITPOL	Bit Offset:9	Bit Width:1
        \ %x  8 lshift FMC_BCR4        \ FMC_BURSTEN	Bit Offset:8	Bit Width:1
        \ %x  6 lshift FMC_BCR4        \ FMC_FACCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_BCR4        \ FMC_MWID	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift FMC_BCR4        \ FMC_MTYP	Bit Offset:2	Bit Width:2
        \ %x  1 lshift FMC_BCR4        \ FMC_MUXEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_BCR4        \ FMC_MBKEN	Bit Offset:0	Bit Width:1
        
        FMC $1C + constant FMC_BTR4	\ read-write		\  : RESET_FMC_BTR4 $FFFFFFFF 
        \ %xx  28 lshift FMC_BTR4        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BTR4        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BTR4        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift FMC_BTR4        \ FMC_BUSTURN	Bit Offset:16	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BTR4        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BTR4        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BTR4        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $60 + constant FMC_PCR2	\ read-write		\  : RESET_FMC_PCR2 $00000018 
        \ %xxx  17 lshift FMC_PCR2        \ FMC_ECCPS	Bit Offset:17	Bit Width:3
        \ %xxxx  13 lshift FMC_PCR2        \ FMC_TAR	Bit Offset:13	Bit Width:4
        \ %xxxx  9 lshift FMC_PCR2        \ FMC_TCLR	Bit Offset:9	Bit Width:4
        \ %x  6 lshift FMC_PCR2        \ FMC_ECCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_PCR2        \ FMC_PWID	Bit Offset:4	Bit Width:2
        \ %x  3 lshift FMC_PCR2        \ FMC_PTYP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift FMC_PCR2        \ FMC_PBKEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FMC_PCR2        \ FMC_PWAITEN	Bit Offset:1	Bit Width:1
        
        FMC $64 + constant FMC_SR2	\ 		\  : RESET_FMC_SR2 $00000040 
        \ %x  6 lshift FMC_SR2        \ FMC_FEMPT	Bit Offset:6	Bit Width:1
        \ %x  5 lshift FMC_SR2        \ FMC_IFEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FMC_SR2        \ FMC_ILEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift FMC_SR2        \ FMC_IREN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift FMC_SR2        \ FMC_IFS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FMC_SR2        \ FMC_ILS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_SR2        \ FMC_IRS	Bit Offset:0	Bit Width:1
        
        FMC $68 + constant FMC_PMEM2	\ read-write		\  : RESET_FMC_PMEM2 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PMEM2        \ FMC_MEMHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PMEM2        \ FMC_MEMHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PMEM2        \ FMC_MEMWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PMEM2        \ FMC_MEMSETx	Bit Offset:0	Bit Width:8
        
        FMC $6C + constant FMC_PATT2	\ read-write		\  : RESET_FMC_PATT2 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PATT2        \ FMC_ATTHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PATT2        \ FMC_ATTHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PATT2        \ FMC_ATTWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PATT2        \ FMC_ATTSETx	Bit Offset:0	Bit Width:8
        
        FMC $74 + constant FMC_ECCR2	\ read-only		\  : RESET_FMC_ECCR2 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FMC_ECCR2        \ FMC_ECCx	Bit Offset:0	Bit Width:32
        
        FMC $80 + constant FMC_PCR3	\ read-write		\  : RESET_FMC_PCR3 $00000018 
        \ %xxx  17 lshift FMC_PCR3        \ FMC_ECCPS	Bit Offset:17	Bit Width:3
        \ %xxxx  13 lshift FMC_PCR3        \ FMC_TAR	Bit Offset:13	Bit Width:4
        \ %xxxx  9 lshift FMC_PCR3        \ FMC_TCLR	Bit Offset:9	Bit Width:4
        \ %x  6 lshift FMC_PCR3        \ FMC_ECCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_PCR3        \ FMC_PWID	Bit Offset:4	Bit Width:2
        \ %x  3 lshift FMC_PCR3        \ FMC_PTYP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift FMC_PCR3        \ FMC_PBKEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FMC_PCR3        \ FMC_PWAITEN	Bit Offset:1	Bit Width:1
        
        FMC $84 + constant FMC_SR3	\ 		\  : RESET_FMC_SR3 $00000040 
        \ %x  6 lshift FMC_SR3        \ FMC_FEMPT	Bit Offset:6	Bit Width:1
        \ %x  5 lshift FMC_SR3        \ FMC_IFEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FMC_SR3        \ FMC_ILEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift FMC_SR3        \ FMC_IREN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift FMC_SR3        \ FMC_IFS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FMC_SR3        \ FMC_ILS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_SR3        \ FMC_IRS	Bit Offset:0	Bit Width:1
        
        FMC $88 + constant FMC_PMEM3	\ read-write		\  : RESET_FMC_PMEM3 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PMEM3        \ FMC_MEMHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PMEM3        \ FMC_MEMHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PMEM3        \ FMC_MEMWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PMEM3        \ FMC_MEMSETx	Bit Offset:0	Bit Width:8
        
        FMC $8C + constant FMC_PATT3	\ read-write		\  : RESET_FMC_PATT3 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PATT3        \ FMC_ATTHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PATT3        \ FMC_ATTHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PATT3        \ FMC_ATTWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PATT3        \ FMC_ATTSETx	Bit Offset:0	Bit Width:8
        
        FMC $94 + constant FMC_ECCR3	\ read-only		\  : RESET_FMC_ECCR3 $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift FMC_ECCR3        \ FMC_ECCx	Bit Offset:0	Bit Width:32
        
        FMC $A0 + constant FMC_PCR4	\ read-write		\  : RESET_FMC_PCR4 $00000018 
        \ %xxx  17 lshift FMC_PCR4        \ FMC_ECCPS	Bit Offset:17	Bit Width:3
        \ %xxxx  13 lshift FMC_PCR4        \ FMC_TAR	Bit Offset:13	Bit Width:4
        \ %xxxx  9 lshift FMC_PCR4        \ FMC_TCLR	Bit Offset:9	Bit Width:4
        \ %x  6 lshift FMC_PCR4        \ FMC_ECCEN	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift FMC_PCR4        \ FMC_PWID	Bit Offset:4	Bit Width:2
        \ %x  3 lshift FMC_PCR4        \ FMC_PTYP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift FMC_PCR4        \ FMC_PBKEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FMC_PCR4        \ FMC_PWAITEN	Bit Offset:1	Bit Width:1
        
        FMC $A4 + constant FMC_SR4	\ 		\  : RESET_FMC_SR4 $00000040 
        \ %x  6 lshift FMC_SR4        \ FMC_FEMPT	Bit Offset:6	Bit Width:1
        \ %x  5 lshift FMC_SR4        \ FMC_IFEN	Bit Offset:5	Bit Width:1
        \ %x  4 lshift FMC_SR4        \ FMC_ILEN	Bit Offset:4	Bit Width:1
        \ %x  3 lshift FMC_SR4        \ FMC_IREN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift FMC_SR4        \ FMC_IFS	Bit Offset:2	Bit Width:1
        \ %x  1 lshift FMC_SR4        \ FMC_ILS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift FMC_SR4        \ FMC_IRS	Bit Offset:0	Bit Width:1
        
        FMC $A8 + constant FMC_PMEM4	\ read-write		\  : RESET_FMC_PMEM4 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PMEM4        \ FMC_MEMHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PMEM4        \ FMC_MEMHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PMEM4        \ FMC_MEMWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PMEM4        \ FMC_MEMSETx	Bit Offset:0	Bit Width:8
        
        FMC $AC + constant FMC_PATT4	\ read-write		\  : RESET_FMC_PATT4 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PATT4        \ FMC_ATTHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PATT4        \ FMC_ATTHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PATT4        \ FMC_ATTWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PATT4        \ FMC_ATTSETx	Bit Offset:0	Bit Width:8
        
        FMC $B0 + constant FMC_PIO4	\ read-write		\  : RESET_FMC_PIO4 $FCFCFCFC 
        \ %xxxxxxxx  24 lshift FMC_PIO4        \ FMC_IOHIZx	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift FMC_PIO4        \ FMC_IOHOLDx	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  8 lshift FMC_PIO4        \ FMC_IOWAITx	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift FMC_PIO4        \ FMC_IOSETx	Bit Offset:0	Bit Width:8
        
        FMC $104 + constant FMC_BWTR1	\ read-write		\  : RESET_FMC_BWTR1 $0FFFFFFF 
        \ %xx  28 lshift FMC_BWTR1        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BWTR1        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BWTR1        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BWTR1        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BWTR1        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BWTR1        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $10C + constant FMC_BWTR2	\ read-write		\  : RESET_FMC_BWTR2 $0FFFFFFF 
        \ %xx  28 lshift FMC_BWTR2        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BWTR2        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BWTR2        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BWTR2        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BWTR2        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BWTR2        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $114 + constant FMC_BWTR3	\ read-write		\  : RESET_FMC_BWTR3 $0FFFFFFF 
        \ %xx  28 lshift FMC_BWTR3        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BWTR3        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BWTR3        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BWTR3        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BWTR3        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BWTR3        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $11C + constant FMC_BWTR4	\ read-write		\  : RESET_FMC_BWTR4 $0FFFFFFF 
        \ %xx  28 lshift FMC_BWTR4        \ FMC_ACCMOD	Bit Offset:28	Bit Width:2
        \ %xxxx  24 lshift FMC_BWTR4        \ FMC_DATLAT	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift FMC_BWTR4        \ FMC_CLKDIV	Bit Offset:20	Bit Width:4
        \ %xxxxxxxx  8 lshift FMC_BWTR4        \ FMC_DATAST	Bit Offset:8	Bit Width:8
        \ %xxxx  4 lshift FMC_BWTR4        \ FMC_ADDHLD	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift FMC_BWTR4        \ FMC_ADDSET	Bit Offset:0	Bit Width:4
        
        FMC $140 + constant FMC_SDCR1	\ read-write		\  : RESET_FMC_SDCR1 $000002D0 
        \ %xx  0 lshift FMC_SDCR1        \ FMC_NC	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift FMC_SDCR1        \ FMC_NR	Bit Offset:2	Bit Width:2
        \ %xx  4 lshift FMC_SDCR1        \ FMC_MWID	Bit Offset:4	Bit Width:2
        \ %x  6 lshift FMC_SDCR1        \ FMC_NB	Bit Offset:6	Bit Width:1
        \ %xx  7 lshift FMC_SDCR1        \ FMC_CAS	Bit Offset:7	Bit Width:2
        \ %x  9 lshift FMC_SDCR1        \ FMC_WP	Bit Offset:9	Bit Width:1
        \ %xx  10 lshift FMC_SDCR1        \ FMC_SDCLK	Bit Offset:10	Bit Width:2
        \ %x  12 lshift FMC_SDCR1        \ FMC_RBURST	Bit Offset:12	Bit Width:1
        \ %xx  13 lshift FMC_SDCR1        \ FMC_RPIPE	Bit Offset:13	Bit Width:2
        
        FMC $144 + constant FMC_SDCR2	\ read-write		\  : RESET_FMC_SDCR2 $000002D0 
        \ %xx  0 lshift FMC_SDCR2        \ FMC_NC	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift FMC_SDCR2        \ FMC_NR	Bit Offset:2	Bit Width:2
        \ %xx  4 lshift FMC_SDCR2        \ FMC_MWID	Bit Offset:4	Bit Width:2
        \ %x  6 lshift FMC_SDCR2        \ FMC_NB	Bit Offset:6	Bit Width:1
        \ %xx  7 lshift FMC_SDCR2        \ FMC_CAS	Bit Offset:7	Bit Width:2
        \ %x  9 lshift FMC_SDCR2        \ FMC_WP	Bit Offset:9	Bit Width:1
        \ %xx  10 lshift FMC_SDCR2        \ FMC_SDCLK	Bit Offset:10	Bit Width:2
        \ %x  12 lshift FMC_SDCR2        \ FMC_RBURST	Bit Offset:12	Bit Width:1
        \ %xx  13 lshift FMC_SDCR2        \ FMC_RPIPE	Bit Offset:13	Bit Width:2
        
        FMC $148 + constant FMC_SDTR1	\ read-write		\  : RESET_FMC_SDTR1 $0FFFFFFF 
        \ %xxxx  0 lshift FMC_SDTR1        \ FMC_TMRD	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift FMC_SDTR1        \ FMC_TXSR	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift FMC_SDTR1        \ FMC_TRAS	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift FMC_SDTR1        \ FMC_TRC	Bit Offset:12	Bit Width:4
        \ %xxxx  16 lshift FMC_SDTR1        \ FMC_TWR	Bit Offset:16	Bit Width:4
        \ %xxxx  20 lshift FMC_SDTR1        \ FMC_TRP	Bit Offset:20	Bit Width:4
        \ %xxxx  24 lshift FMC_SDTR1        \ FMC_TRCD	Bit Offset:24	Bit Width:4
        
        FMC $14C + constant FMC_SDTR2	\ read-write		\  : RESET_FMC_SDTR2 $0FFFFFFF 
        \ %xxxx  0 lshift FMC_SDTR2        \ FMC_TMRD	Bit Offset:0	Bit Width:4
        \ %xxxx  4 lshift FMC_SDTR2        \ FMC_TXSR	Bit Offset:4	Bit Width:4
        \ %xxxx  8 lshift FMC_SDTR2        \ FMC_TRAS	Bit Offset:8	Bit Width:4
        \ %xxxx  12 lshift FMC_SDTR2        \ FMC_TRC	Bit Offset:12	Bit Width:4
        \ %xxxx  16 lshift FMC_SDTR2        \ FMC_TWR	Bit Offset:16	Bit Width:4
        \ %xxxx  20 lshift FMC_SDTR2        \ FMC_TRP	Bit Offset:20	Bit Width:4
        \ %xxxx  24 lshift FMC_SDTR2        \ FMC_TRCD	Bit Offset:24	Bit Width:4
        
        FMC $150 + constant FMC_SDCMR	\ 		\  : RESET_FMC_SDCMR $00000000 
        \ %xxx  0 lshift FMC_SDCMR        \ FMC_MODE	Bit Offset:0	Bit Width:3
        \ %x  3 lshift FMC_SDCMR        \ FMC_CTB2	Bit Offset:3	Bit Width:1
        \ %x  4 lshift FMC_SDCMR        \ FMC_CTB1	Bit Offset:4	Bit Width:1
        \ %xxxx  5 lshift FMC_SDCMR        \ FMC_NRFS	Bit Offset:5	Bit Width:4
        \ % 9 lshift FMC_SDCMR        \ FMC_MRD	Bit Offset:9	Bit Width:13
        
        FMC $154 + constant FMC_SDRTR	\ 		\  : RESET_FMC_SDRTR $00000000 
        \ %x  0 lshift FMC_SDRTR        \ FMC_CRE	Bit Offset:0	Bit Width:1
        \ % 1 lshift FMC_SDRTR        \ FMC_COUNT	Bit Offset:1	Bit Width:13
        \ %x  14 lshift FMC_SDRTR        \ FMC_REIE	Bit Offset:14	Bit Width:1
        
        FMC $158 + constant FMC_SDSR	\ read-only		\  : RESET_FMC_SDSR $00000000 
        \ %x  0 lshift FMC_SDSR        \ FMC_RE	Bit Offset:0	Bit Width:1
        \ %xx  1 lshift FMC_SDSR        \ FMC_MODES1	Bit Offset:1	Bit Width:2
        \ %xx  3 lshift FMC_SDSR        \ FMC_MODES2	Bit Offset:3	Bit Width:2
        \ %x  5 lshift FMC_SDSR        \ FMC_BUSY	Bit Offset:5	Bit Width:1
        
         
	
     $40005C00 constant I2C3  
	 I2C3 $0 + constant I2C3_CR1	\ read-write		\  : RESET_I2C3_CR1 $0000 
        \ %x  15 lshift I2C3_CR1        \ I2C3_SWRST	Bit Offset:15	Bit Width:1
        \ %x  13 lshift I2C3_CR1        \ I2C3_ALERT	Bit Offset:13	Bit Width:1
        \ %x  12 lshift I2C3_CR1        \ I2C3_PEC	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C3_CR1        \ I2C3_POS	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C3_CR1        \ I2C3_ACK	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C3_CR1        \ I2C3_STOP	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C3_CR1        \ I2C3_START	Bit Offset:8	Bit Width:1
        \ %x  7 lshift I2C3_CR1        \ I2C3_NOSTRETCH	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C3_CR1        \ I2C3_ENGC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift I2C3_CR1        \ I2C3_ENPEC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift I2C3_CR1        \ I2C3_ENARP	Bit Offset:4	Bit Width:1
        \ %x  3 lshift I2C3_CR1        \ I2C3_SMBTYPE	Bit Offset:3	Bit Width:1
        \ %x  1 lshift I2C3_CR1        \ I2C3_SMBUS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C3_CR1        \ I2C3_PE	Bit Offset:0	Bit Width:1
        
        I2C3 $4 + constant I2C3_CR2	\ read-write		\  : RESET_I2C3_CR2 $0000 
        \ %x  12 lshift I2C3_CR2        \ I2C3_LAST	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C3_CR2        \ I2C3_DMAEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C3_CR2        \ I2C3_ITBUFEN	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C3_CR2        \ I2C3_ITEVTEN	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C3_CR2        \ I2C3_ITERREN	Bit Offset:8	Bit Width:1
        \ %xxxxxx  0 lshift I2C3_CR2        \ I2C3_FREQ	Bit Offset:0	Bit Width:6
        
        I2C3 $8 + constant I2C3_OAR1	\ read-write		\  : RESET_I2C3_OAR1 $0000 
        \ %x  15 lshift I2C3_OAR1        \ I2C3_ADDMODE	Bit Offset:15	Bit Width:1
        \ %xx  8 lshift I2C3_OAR1        \ I2C3_ADD10	Bit Offset:8	Bit Width:2
        \ %xxxxxxx  1 lshift I2C3_OAR1        \ I2C3_ADD7	Bit Offset:1	Bit Width:7
        \ %x  0 lshift I2C3_OAR1        \ I2C3_ADD0	Bit Offset:0	Bit Width:1
        
        I2C3 $C + constant I2C3_OAR2	\ read-write		\  : RESET_I2C3_OAR2 $0000 
        \ %xxxxxxx  1 lshift I2C3_OAR2        \ I2C3_ADD2	Bit Offset:1	Bit Width:7
        \ %x  0 lshift I2C3_OAR2        \ I2C3_ENDUAL	Bit Offset:0	Bit Width:1
        
        I2C3 $10 + constant I2C3_DR	\ read-write		\  : RESET_I2C3_DR $0000 
        \ %xxxxxxxx  0 lshift I2C3_DR        \ I2C3_DR	Bit Offset:0	Bit Width:8
        
        I2C3 $14 + constant I2C3_SR1	\ 		\  : RESET_I2C3_SR1 $0000 
        \ %x  15 lshift I2C3_SR1        \ I2C3_SMBALERT	Bit Offset:15	Bit Width:1
        \ %x  14 lshift I2C3_SR1        \ I2C3_TIMEOUT	Bit Offset:14	Bit Width:1
        \ %x  12 lshift I2C3_SR1        \ I2C3_PECERR	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C3_SR1        \ I2C3_OVR	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C3_SR1        \ I2C3_AF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C3_SR1        \ I2C3_ARLO	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C3_SR1        \ I2C3_BERR	Bit Offset:8	Bit Width:1
        \ %x  7 lshift I2C3_SR1        \ I2C3_TxE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C3_SR1        \ I2C3_RxNE	Bit Offset:6	Bit Width:1
        \ %x  4 lshift I2C3_SR1        \ I2C3_STOPF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift I2C3_SR1        \ I2C3_ADD10	Bit Offset:3	Bit Width:1
        \ %x  2 lshift I2C3_SR1        \ I2C3_BTF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift I2C3_SR1        \ I2C3_ADDR	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C3_SR1        \ I2C3_SB	Bit Offset:0	Bit Width:1
        
        I2C3 $18 + constant I2C3_SR2	\ read-only		\  : RESET_I2C3_SR2 $0000 
        \ %xxxxxxxx  8 lshift I2C3_SR2        \ I2C3_PEC	Bit Offset:8	Bit Width:8
        \ %x  7 lshift I2C3_SR2        \ I2C3_DUALF	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C3_SR2        \ I2C3_SMBHOST	Bit Offset:6	Bit Width:1
        \ %x  5 lshift I2C3_SR2        \ I2C3_SMBDEFAULT	Bit Offset:5	Bit Width:1
        \ %x  4 lshift I2C3_SR2        \ I2C3_GENCALL	Bit Offset:4	Bit Width:1
        \ %x  2 lshift I2C3_SR2        \ I2C3_TRA	Bit Offset:2	Bit Width:1
        \ %x  1 lshift I2C3_SR2        \ I2C3_BUSY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C3_SR2        \ I2C3_MSL	Bit Offset:0	Bit Width:1
        
        I2C3 $1C + constant I2C3_CCR	\ read-write		\  : RESET_I2C3_CCR $0000 
        \ %x  15 lshift I2C3_CCR        \ I2C3_F_S	Bit Offset:15	Bit Width:1
        \ %x  14 lshift I2C3_CCR        \ I2C3_DUTY	Bit Offset:14	Bit Width:1
        \ %xxxxxxxxxxxx  0 lshift I2C3_CCR        \ I2C3_CCR	Bit Offset:0	Bit Width:12
        
        I2C3 $20 + constant I2C3_TRISE	\ read-write		\  : RESET_I2C3_TRISE $0002 
        \ %xxxxxx  0 lshift I2C3_TRISE        \ I2C3_TRISE	Bit Offset:0	Bit Width:6
        
        I2C3 $24 + constant I2C3_FLTR	\ read-write		\  : RESET_I2C3_FLTR $0000 
        \ %xxxx  0 lshift I2C3_FLTR        \ I2C3_DNF	Bit Offset:0	Bit Width:4
        \ %x  4 lshift I2C3_FLTR        \ I2C3_ANOFF	Bit Offset:4	Bit Width:1
        
         
	
     $40005800 constant I2C2  
	  
	
     $40005400 constant I2C1  
	  
	
     $40007000 constant PWR  
	 PWR $0 + constant PWR_CR	\ read-write		\  : RESET_PWR_CR $0000C000 
        \ %x  0 lshift PWR_CR        \ PWR_LPDS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_CR        \ PWR_PDDS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_CR        \ PWR_CWUF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_CR        \ PWR_CSBF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_CR        \ PWR_PVDE	Bit Offset:4	Bit Width:1
        \ %xxx  5 lshift PWR_CR        \ PWR_PLS	Bit Offset:5	Bit Width:3
        \ %x  8 lshift PWR_CR        \ PWR_DBP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift PWR_CR        \ PWR_FPDS	Bit Offset:9	Bit Width:1
        \ %x  10 lshift PWR_CR        \ PWR_LPLVDS	Bit Offset:10	Bit Width:1
        \ %x  11 lshift PWR_CR        \ PWR_MRLVDS	Bit Offset:11	Bit Width:1
        \ %xx  14 lshift PWR_CR        \ PWR_VOS	Bit Offset:14	Bit Width:2
        \ %x  16 lshift PWR_CR        \ PWR_ODEN	Bit Offset:16	Bit Width:1
        \ %x  17 lshift PWR_CR        \ PWR_ODSWEN	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift PWR_CR        \ PWR_UDEN	Bit Offset:18	Bit Width:2
        
        PWR $4 + constant PWR_CSR	\ 		\  : RESET_PWR_CSR $00000000 
        \ %x  0 lshift PWR_CSR        \ PWR_WUF	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_CSR        \ PWR_SBF	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_CSR        \ PWR_PVDO	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_CSR        \ PWR_BRR	Bit Offset:3	Bit Width:1
        \ %x  8 lshift PWR_CSR        \ PWR_EWUP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift PWR_CSR        \ PWR_BRE	Bit Offset:9	Bit Width:1
        \ %x  14 lshift PWR_CSR        \ PWR_VOSRDY	Bit Offset:14	Bit Width:1
        \ %x  16 lshift PWR_CSR        \ PWR_ODRDY	Bit Offset:16	Bit Width:1
        \ %x  17 lshift PWR_CSR        \ PWR_ODSWRDY	Bit Offset:17	Bit Width:1
        \ %xx  18 lshift PWR_CSR        \ PWR_UDRDY	Bit Offset:18	Bit Width:2
        
         
	
     