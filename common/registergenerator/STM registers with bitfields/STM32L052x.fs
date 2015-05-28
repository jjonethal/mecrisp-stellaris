\  STM32L052x ARM CMSIS-SVD register file for Mecrisp-Stellaris Forth by Matthias Koch
	\  x = 0 or 1 below in the Register Field bit positions 
	 

    $40007400 constant DAC  
	 DAC $0 + constant DAC_CR	\ read-write		\  : RESET_DAC_CR $00000000 
        \ %x  13 lshift DAC_CR        \ DAC_DMAUDRIE1	Bit Offset:13	Bit Width:1
        \ %x  12 lshift DAC_CR        \ DAC_DMAEN1	Bit Offset:12	Bit Width:1
        \ %xxxx  8 lshift DAC_CR        \ DAC_MAMP1	Bit Offset:8	Bit Width:4
        \ %xx  6 lshift DAC_CR        \ DAC_WAVE1	Bit Offset:6	Bit Width:2
        \ %xxx  3 lshift DAC_CR        \ DAC_TSEL1	Bit Offset:3	Bit Width:3
        \ %x  2 lshift DAC_CR        \ DAC_TEN1	Bit Offset:2	Bit Width:1
        \ %x  1 lshift DAC_CR        \ DAC_BOFF1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift DAC_CR        \ DAC_EN1	Bit Offset:0	Bit Width:1
        
        DAC $4 + constant DAC_SWTRIGR	\ write-only		\  : RESET_DAC_SWTRIGR $00000000 
        \ %x  0 lshift DAC_SWTRIGR        \ DAC_SWTRIG1	Bit Offset:0	Bit Width:1
        
        DAC $8 + constant DAC_DHR12R1	\ read-write		\  : RESET_DAC_DHR12R1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DHR12R1        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:12
        
        DAC $C + constant DAC_DHR12L1	\ read-write		\  : RESET_DAC_DHR12L1 $00000000 
        \ %xxxxxxxxxxxx  4 lshift DAC_DHR12L1        \ DAC_DACC1DHR	Bit Offset:4	Bit Width:12
        
        DAC $10 + constant DAC_DHR8R1	\ read-write		\  : RESET_DAC_DHR8R1 $00000000 
        \ %xxxxxxxx  0 lshift DAC_DHR8R1        \ DAC_DACC1DHR	Bit Offset:0	Bit Width:8
        
        DAC $2C + constant DAC_DOR1	\ read-only		\  : RESET_DAC_DOR1 $00000000 
        \ %xxxxxxxxxxxx  0 lshift DAC_DOR1        \ DAC_DACC1DOR	Bit Offset:0	Bit Width:12
        
        DAC $34 + constant DAC_SR	\ read-writeOnce		\  : RESET_DAC_SR $00000000 
        \ %x  13 lshift DAC_SR        \ DAC_DMAUDR1	Bit Offset:13	Bit Width:1
        
         
	
     $40020000 constant DMA1  
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
        
        DMA1 $A8 + constant DMA1_CSELR	\ read-write		\  : RESET_DMA1_CSELR $00000000 
        \ %xxxx  24 lshift DMA1_CSELR        \ DMA1_C7S	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift DMA1_CSELR        \ DMA1_C6S	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift DMA1_CSELR        \ DMA1_C5S	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift DMA1_CSELR        \ DMA1_C4S	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift DMA1_CSELR        \ DMA1_C3S	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift DMA1_CSELR        \ DMA1_C2S	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift DMA1_CSELR        \ DMA1_C1S	Bit Offset:0	Bit Width:4
        
         
	
     $40023000 constant CRC  
	 CRC $0 + constant CRC_DR	\ read-write		\  : RESET_CRC_DR $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift CRC_DR        \ CRC_DR	Bit Offset:0	Bit Width:32
        
        CRC $4 + constant CRC_IDR	\ read-write		\  : RESET_CRC_IDR $00000000 
        \ %xxxxxxxx  0 lshift CRC_IDR        \ CRC_IDR	Bit Offset:0	Bit Width:8
        
        CRC $8 + constant CRC_CR	\ 		\  : RESET_CRC_CR $00000000 
        \ %x  7 lshift CRC_CR        \ CRC_REV_OUT	Bit Offset:7	Bit Width:1
        \ %xx  5 lshift CRC_CR        \ CRC_REV_IN	Bit Offset:5	Bit Width:2
        \ %xx  3 lshift CRC_CR        \ CRC_POLYSIZE	Bit Offset:3	Bit Width:2
        \ %x  0 lshift CRC_CR        \ CRC_RESET	Bit Offset:0	Bit Width:1
        
        CRC $10 + constant CRC_INIT	\ read-write		\  : RESET_CRC_INIT $FFFFFFFF 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift CRC_INIT        \ CRC_CRC_INIT	Bit Offset:0	Bit Width:32
        
        CRC $14 + constant CRC_POL	\ read-write		\  : RESET_CRC_POL $04C11DB7 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift CRC_POL        \ CRC_Polynomialcoefficients	Bit Offset:0	Bit Width:32
        
         
	
     $50000000 constant GPIOA  
	 GPIOA $0 + constant GPIOA_MODER	\ read-write		\  : RESET_GPIOA_MODER $EBFFFCFF 
        \ %xx  0 lshift GPIOA_MODER        \ GPIOA_MODE0	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift GPIOA_MODER        \ GPIOA_MODE1	Bit Offset:2	Bit Width:2
        \ %xx  4 lshift GPIOA_MODER        \ GPIOA_MODE2	Bit Offset:4	Bit Width:2
        \ %xx  6 lshift GPIOA_MODER        \ GPIOA_MODE3	Bit Offset:6	Bit Width:2
        \ %xx  8 lshift GPIOA_MODER        \ GPIOA_MODE4	Bit Offset:8	Bit Width:2
        \ %xx  10 lshift GPIOA_MODER        \ GPIOA_MODE5	Bit Offset:10	Bit Width:2
        \ %xx  12 lshift GPIOA_MODER        \ GPIOA_MODE6	Bit Offset:12	Bit Width:2
        \ %xx  14 lshift GPIOA_MODER        \ GPIOA_MODE7	Bit Offset:14	Bit Width:2
        \ %xx  16 lshift GPIOA_MODER        \ GPIOA_MODE8	Bit Offset:16	Bit Width:2
        \ %xx  18 lshift GPIOA_MODER        \ GPIOA_MODE9	Bit Offset:18	Bit Width:2
        \ %xx  20 lshift GPIOA_MODER        \ GPIOA_MODE10	Bit Offset:20	Bit Width:2
        \ %xx  22 lshift GPIOA_MODER        \ GPIOA_MODE11	Bit Offset:22	Bit Width:2
        \ %xx  24 lshift GPIOA_MODER        \ GPIOA_MODE12	Bit Offset:24	Bit Width:2
        \ %xx  26 lshift GPIOA_MODER        \ GPIOA_MODE13	Bit Offset:26	Bit Width:2
        \ %xx  28 lshift GPIOA_MODER        \ GPIOA_MODE14	Bit Offset:28	Bit Width:2
        \ %xx  30 lshift GPIOA_MODER        \ GPIOA_MODE15	Bit Offset:30	Bit Width:2
        
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
        \ %xx  30 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOA_OSPEEDR        \ GPIOA_OSPEED0	Bit Offset:0	Bit Width:2
        
        GPIOA $C + constant GPIOA_PUPDR	\ read-write		\  : RESET_GPIOA_PUPDR $24000000 
        \ %xx  30 lshift GPIOA_PUPDR        \ GPIOA_PUPD15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOA_PUPDR        \ GPIOA_PUPD14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOA_PUPDR        \ GPIOA_PUPD13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOA_PUPDR        \ GPIOA_PUPD12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOA_PUPDR        \ GPIOA_PUPD11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOA_PUPDR        \ GPIOA_PUPD10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOA_PUPDR        \ GPIOA_PUPD9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOA_PUPDR        \ GPIOA_PUPD8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOA_PUPDR        \ GPIOA_PUPD7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOA_PUPDR        \ GPIOA_PUPD6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOA_PUPDR        \ GPIOA_PUPD5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOA_PUPDR        \ GPIOA_PUPD4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOA_PUPDR        \ GPIOA_PUPD3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOA_PUPDR        \ GPIOA_PUPD2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOA_PUPDR        \ GPIOA_PUPD1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOA_PUPDR        \ GPIOA_PUPD0	Bit Offset:0	Bit Width:2
        
        GPIOA $10 + constant GPIOA_IDR	\ read-only		\  : RESET_GPIOA_IDR $00000000 
        \ %x  15 lshift GPIOA_IDR        \ GPIOA_ID15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_IDR        \ GPIOA_ID14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_IDR        \ GPIOA_ID13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_IDR        \ GPIOA_ID12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_IDR        \ GPIOA_ID11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_IDR        \ GPIOA_ID10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_IDR        \ GPIOA_ID9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_IDR        \ GPIOA_ID8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_IDR        \ GPIOA_ID7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_IDR        \ GPIOA_ID6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_IDR        \ GPIOA_ID5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_IDR        \ GPIOA_ID4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_IDR        \ GPIOA_ID3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_IDR        \ GPIOA_ID2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_IDR        \ GPIOA_ID1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_IDR        \ GPIOA_ID0	Bit Offset:0	Bit Width:1
        
        GPIOA $14 + constant GPIOA_ODR	\ read-write		\  : RESET_GPIOA_ODR $00000000 
        \ %x  15 lshift GPIOA_ODR        \ GPIOA_OD15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_ODR        \ GPIOA_OD14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_ODR        \ GPIOA_OD13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_ODR        \ GPIOA_OD12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_ODR        \ GPIOA_OD11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_ODR        \ GPIOA_OD10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_ODR        \ GPIOA_OD9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_ODR        \ GPIOA_OD8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_ODR        \ GPIOA_OD7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_ODR        \ GPIOA_OD6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_ODR        \ GPIOA_OD5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_ODR        \ GPIOA_OD4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_ODR        \ GPIOA_OD3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_ODR        \ GPIOA_OD2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_ODR        \ GPIOA_OD1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_ODR        \ GPIOA_OD0	Bit Offset:0	Bit Width:1
        
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
        \ %xxxx  28 lshift GPIOA_AFRL        \ GPIOA_AFSEL7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOA_AFRL        \ GPIOA_AFSEL6	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOA_AFRL        \ GPIOA_AFSEL5	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOA_AFRL        \ GPIOA_AFSEL4	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOA_AFRL        \ GPIOA_AFSEL3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOA_AFRL        \ GPIOA_AFSEL2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOA_AFRL        \ GPIOA_AFSEL1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOA_AFRL        \ GPIOA_AFSEL0	Bit Offset:0	Bit Width:4
        
        GPIOA $24 + constant GPIOA_AFRH	\ read-write		\  : RESET_GPIOA_AFRH $00000000 
        \ %xxxx  28 lshift GPIOA_AFRH        \ GPIOA_AFSEL15	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOA_AFRH        \ GPIOA_AFSEL14	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOA_AFRH        \ GPIOA_AFSEL13	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOA_AFRH        \ GPIOA_AFSEL12	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOA_AFRH        \ GPIOA_AFSEL11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOA_AFRH        \ GPIOA_AFSEL10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOA_AFRH        \ GPIOA_AFSEL9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOA_AFRH        \ GPIOA_AFSEL8	Bit Offset:0	Bit Width:4
        
        GPIOA $28 + constant GPIOA_BRR	\ write-only		\  : RESET_GPIOA_BRR $00000000 
        \ %x  15 lshift GPIOA_BRR        \ GPIOA_BR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOA_BRR        \ GPIOA_BR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOA_BRR        \ GPIOA_BR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOA_BRR        \ GPIOA_BR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOA_BRR        \ GPIOA_BR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOA_BRR        \ GPIOA_BR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOA_BRR        \ GPIOA_BR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOA_BRR        \ GPIOA_BR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOA_BRR        \ GPIOA_BR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOA_BRR        \ GPIOA_BR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOA_BRR        \ GPIOA_BR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOA_BRR        \ GPIOA_BR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOA_BRR        \ GPIOA_BR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOA_BRR        \ GPIOA_BR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOA_BRR        \ GPIOA_BR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOA_BRR        \ GPIOA_BR0	Bit Offset:0	Bit Width:1
        
         
	
     $50000400 constant GPIOB  
	 GPIOB $0 + constant GPIOB_MODER	\ read-write		\  : RESET_GPIOB_MODER $FFFFFFFF 
        \ %xx  30 lshift GPIOB_MODER        \ GPIOB_MODE15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_MODER        \ GPIOB_MODE14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_MODER        \ GPIOB_MODE13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_MODER        \ GPIOB_MODE12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_MODER        \ GPIOB_MODE11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_MODER        \ GPIOB_MODE10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_MODER        \ GPIOB_MODE9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_MODER        \ GPIOB_MODE8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_MODER        \ GPIOB_MODE7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_MODER        \ GPIOB_MODE6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_MODER        \ GPIOB_MODE5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_MODER        \ GPIOB_MODE4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_MODER        \ GPIOB_MODE3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_MODER        \ GPIOB_MODE2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_MODER        \ GPIOB_MODE1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_MODER        \ GPIOB_MODE0	Bit Offset:0	Bit Width:2
        
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
        
        GPIOB $8 + constant GPIOB_OSPEEDR	\ read-write		\  : RESET_GPIOB_OSPEEDR $00000000 
        \ %xx  30 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_OSPEEDR        \ GPIOB_OSPEED0	Bit Offset:0	Bit Width:2
        
        GPIOB $C + constant GPIOB_PUPDR	\ read-write		\  : RESET_GPIOB_PUPDR $00000000 
        \ %xx  30 lshift GPIOB_PUPDR        \ GPIOB_PUPD15	Bit Offset:30	Bit Width:2
        \ %xx  28 lshift GPIOB_PUPDR        \ GPIOB_PUPD14	Bit Offset:28	Bit Width:2
        \ %xx  26 lshift GPIOB_PUPDR        \ GPIOB_PUPD13	Bit Offset:26	Bit Width:2
        \ %xx  24 lshift GPIOB_PUPDR        \ GPIOB_PUPD12	Bit Offset:24	Bit Width:2
        \ %xx  22 lshift GPIOB_PUPDR        \ GPIOB_PUPD11	Bit Offset:22	Bit Width:2
        \ %xx  20 lshift GPIOB_PUPDR        \ GPIOB_PUPD10	Bit Offset:20	Bit Width:2
        \ %xx  18 lshift GPIOB_PUPDR        \ GPIOB_PUPD9	Bit Offset:18	Bit Width:2
        \ %xx  16 lshift GPIOB_PUPDR        \ GPIOB_PUPD8	Bit Offset:16	Bit Width:2
        \ %xx  14 lshift GPIOB_PUPDR        \ GPIOB_PUPD7	Bit Offset:14	Bit Width:2
        \ %xx  12 lshift GPIOB_PUPDR        \ GPIOB_PUPD6	Bit Offset:12	Bit Width:2
        \ %xx  10 lshift GPIOB_PUPDR        \ GPIOB_PUPD5	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift GPIOB_PUPDR        \ GPIOB_PUPD4	Bit Offset:8	Bit Width:2
        \ %xx  6 lshift GPIOB_PUPDR        \ GPIOB_PUPD3	Bit Offset:6	Bit Width:2
        \ %xx  4 lshift GPIOB_PUPDR        \ GPIOB_PUPD2	Bit Offset:4	Bit Width:2
        \ %xx  2 lshift GPIOB_PUPDR        \ GPIOB_PUPD1	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift GPIOB_PUPDR        \ GPIOB_PUPD0	Bit Offset:0	Bit Width:2
        
        GPIOB $10 + constant GPIOB_IDR	\ read-only		\  : RESET_GPIOB_IDR $00000000 
        \ %x  15 lshift GPIOB_IDR        \ GPIOB_ID15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_IDR        \ GPIOB_ID14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_IDR        \ GPIOB_ID13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_IDR        \ GPIOB_ID12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_IDR        \ GPIOB_ID11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_IDR        \ GPIOB_ID10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_IDR        \ GPIOB_ID9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_IDR        \ GPIOB_ID8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_IDR        \ GPIOB_ID7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_IDR        \ GPIOB_ID6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_IDR        \ GPIOB_ID5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_IDR        \ GPIOB_ID4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_IDR        \ GPIOB_ID3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_IDR        \ GPIOB_ID2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_IDR        \ GPIOB_ID1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_IDR        \ GPIOB_ID0	Bit Offset:0	Bit Width:1
        
        GPIOB $14 + constant GPIOB_ODR	\ read-write		\  : RESET_GPIOB_ODR $00000000 
        \ %x  15 lshift GPIOB_ODR        \ GPIOB_OD15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_ODR        \ GPIOB_OD14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_ODR        \ GPIOB_OD13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_ODR        \ GPIOB_OD12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_ODR        \ GPIOB_OD11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_ODR        \ GPIOB_OD10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_ODR        \ GPIOB_OD9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_ODR        \ GPIOB_OD8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_ODR        \ GPIOB_OD7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_ODR        \ GPIOB_OD6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_ODR        \ GPIOB_OD5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_ODR        \ GPIOB_OD4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_ODR        \ GPIOB_OD3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_ODR        \ GPIOB_OD2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_ODR        \ GPIOB_OD1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_ODR        \ GPIOB_OD0	Bit Offset:0	Bit Width:1
        
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
        \ %xxxx  28 lshift GPIOB_AFRL        \ GPIOB_AFSEL7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOB_AFRL        \ GPIOB_AFSEL6	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOB_AFRL        \ GPIOB_AFSEL5	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOB_AFRL        \ GPIOB_AFSEL4	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOB_AFRL        \ GPIOB_AFSEL3	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOB_AFRL        \ GPIOB_AFSEL2	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOB_AFRL        \ GPIOB_AFSEL1	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOB_AFRL        \ GPIOB_AFSEL0	Bit Offset:0	Bit Width:4
        
        GPIOB $24 + constant GPIOB_AFRH	\ read-write		\  : RESET_GPIOB_AFRH $00000000 
        \ %xxxx  28 lshift GPIOB_AFRH        \ GPIOB_AFSEL15	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift GPIOB_AFRH        \ GPIOB_AFSEL14	Bit Offset:24	Bit Width:4
        \ %xxxx  20 lshift GPIOB_AFRH        \ GPIOB_AFSEL13	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift GPIOB_AFRH        \ GPIOB_AFSEL12	Bit Offset:16	Bit Width:4
        \ %xxxx  12 lshift GPIOB_AFRH        \ GPIOB_AFSEL11	Bit Offset:12	Bit Width:4
        \ %xxxx  8 lshift GPIOB_AFRH        \ GPIOB_AFSEL10	Bit Offset:8	Bit Width:4
        \ %xxxx  4 lshift GPIOB_AFRH        \ GPIOB_AFSEL9	Bit Offset:4	Bit Width:4
        \ %xxxx  0 lshift GPIOB_AFRH        \ GPIOB_AFSEL8	Bit Offset:0	Bit Width:4
        
        GPIOB $28 + constant GPIOB_BRR	\ write-only		\  : RESET_GPIOB_BRR $00000000 
        \ %x  15 lshift GPIOB_BRR        \ GPIOB_BR15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift GPIOB_BRR        \ GPIOB_BR14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift GPIOB_BRR        \ GPIOB_BR13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift GPIOB_BRR        \ GPIOB_BR12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift GPIOB_BRR        \ GPIOB_BR11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift GPIOB_BRR        \ GPIOB_BR10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift GPIOB_BRR        \ GPIOB_BR9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift GPIOB_BRR        \ GPIOB_BR8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift GPIOB_BRR        \ GPIOB_BR7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift GPIOB_BRR        \ GPIOB_BR6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift GPIOB_BRR        \ GPIOB_BR5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift GPIOB_BRR        \ GPIOB_BR4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift GPIOB_BRR        \ GPIOB_BR3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift GPIOB_BRR        \ GPIOB_BR2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift GPIOB_BRR        \ GPIOB_BR1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift GPIOB_BRR        \ GPIOB_BR0	Bit Offset:0	Bit Width:1
        
         
	
     $50000800 constant GPIOC  
	  
	
     $50000C00 constant GPIOD  
	  
	
     $50001C00 constant GPIOH  
	  
	
     $40007C00 constant LPTIM  
	 LPTIM $0 + constant LPTIM_ISR	\ read-only		\  : RESET_LPTIM_ISR $00000000 
        \ %x  6 lshift LPTIM_ISR        \ LPTIM_DOWN	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LPTIM_ISR        \ LPTIM_UP	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LPTIM_ISR        \ LPTIM_ARROK	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LPTIM_ISR        \ LPTIM_CMPOK	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPTIM_ISR        \ LPTIM_EXTTRIG	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPTIM_ISR        \ LPTIM_ARRM	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPTIM_ISR        \ LPTIM_CMPM	Bit Offset:0	Bit Width:1
        
        LPTIM $4 + constant LPTIM_ICR	\ write-only		\  : RESET_LPTIM_ICR $00000000 
        \ %x  6 lshift LPTIM_ICR        \ LPTIM_DOWNCF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LPTIM_ICR        \ LPTIM_UPCF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LPTIM_ICR        \ LPTIM_ARROKCF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LPTIM_ICR        \ LPTIM_CMPOKCF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPTIM_ICR        \ LPTIM_EXTTRIGCF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPTIM_ICR        \ LPTIM_ARRMCF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPTIM_ICR        \ LPTIM_CMPMCF	Bit Offset:0	Bit Width:1
        
        LPTIM $8 + constant LPTIM_IER	\ read-write		\  : RESET_LPTIM_IER $00000000 
        \ %x  6 lshift LPTIM_IER        \ LPTIM_DOWNIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LPTIM_IER        \ LPTIM_UPIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LPTIM_IER        \ LPTIM_ARROKIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LPTIM_IER        \ LPTIM_CMPOKIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPTIM_IER        \ LPTIM_EXTTRIGIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPTIM_IER        \ LPTIM_ARRMIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPTIM_IER        \ LPTIM_CMPMIE	Bit Offset:0	Bit Width:1
        
        LPTIM $C + constant LPTIM_CFGR	\ read-write		\  : RESET_LPTIM_CFGR $00000000 
        \ %x  24 lshift LPTIM_CFGR        \ LPTIM_ENC	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LPTIM_CFGR        \ LPTIM_COUNTMODE	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LPTIM_CFGR        \ LPTIM_PRELOAD	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LPTIM_CFGR        \ LPTIM_WAVPOL	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LPTIM_CFGR        \ LPTIM_WAVE	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LPTIM_CFGR        \ LPTIM_TIMOUT	Bit Offset:19	Bit Width:1
        \ %xx  17 lshift LPTIM_CFGR        \ LPTIM_TRIGEN	Bit Offset:17	Bit Width:2
        \ %xxx  13 lshift LPTIM_CFGR        \ LPTIM_TRIGSEL	Bit Offset:13	Bit Width:3
        \ %xxx  9 lshift LPTIM_CFGR        \ LPTIM_PRESC	Bit Offset:9	Bit Width:3
        \ %xx  6 lshift LPTIM_CFGR        \ LPTIM_TRGFLT	Bit Offset:6	Bit Width:2
        \ %xx  3 lshift LPTIM_CFGR        \ LPTIM_CKFLT	Bit Offset:3	Bit Width:2
        \ %xx  1 lshift LPTIM_CFGR        \ LPTIM_CKPOL	Bit Offset:1	Bit Width:2
        \ %x  0 lshift LPTIM_CFGR        \ LPTIM_CKSEL	Bit Offset:0	Bit Width:1
        
        LPTIM $10 + constant LPTIM_CR	\ read-write		\  : RESET_LPTIM_CR $00000000 
        \ %x  2 lshift LPTIM_CR        \ LPTIM_CNTSTRT	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPTIM_CR        \ LPTIM_SNGSTRT	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPTIM_CR        \ LPTIM_ENABLE	Bit Offset:0	Bit Width:1
        
        LPTIM $14 + constant LPTIM_CMP	\ read-write		\  : RESET_LPTIM_CMP $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift LPTIM_CMP        \ LPTIM_CMP	Bit Offset:0	Bit Width:16
        
        LPTIM $18 + constant LPTIM_ARR	\ read-write		\  : RESET_LPTIM_ARR $00000001 
        \ %xxxxxxxxxxxxxxxx  0 lshift LPTIM_ARR        \ LPTIM_ARR	Bit Offset:0	Bit Width:16
        
        LPTIM $1C + constant LPTIM_CNT	\ read-only		\  : RESET_LPTIM_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift LPTIM_CNT        \ LPTIM_CNT	Bit Offset:0	Bit Width:16
        
         
	
     $40025000 constant RNG  
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
        
         
	
     $40002800 constant RTC  
	 RTC $0 + constant RTC_TR	\ read-write		\  : RESET_RTC_TR $00000000 
        \ %x  22 lshift RTC_TR        \ RTC_PM	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift RTC_TR        \ RTC_HT	Bit Offset:20	Bit Width:2
        \ %xxxx  16 lshift RTC_TR        \ RTC_HU	Bit Offset:16	Bit Width:4
        \ %xxx  12 lshift RTC_TR        \ RTC_MNT	Bit Offset:12	Bit Width:3
        \ %xxxx  8 lshift RTC_TR        \ RTC_MNU	Bit Offset:8	Bit Width:4
        \ %xxx  4 lshift RTC_TR        \ RTC_ST	Bit Offset:4	Bit Width:3
        \ %xxxx  0 lshift RTC_TR        \ RTC_SU	Bit Offset:0	Bit Width:4
        
        RTC $4 + constant RTC_DR	\ read-write		\  : RESET_RTC_DR $00000000 
        \ %xxxx  20 lshift RTC_DR        \ RTC_YT	Bit Offset:20	Bit Width:4
        \ %xxxx  16 lshift RTC_DR        \ RTC_YU	Bit Offset:16	Bit Width:4
        \ %xxx  13 lshift RTC_DR        \ RTC_WDU	Bit Offset:13	Bit Width:3
        \ %x  12 lshift RTC_DR        \ RTC_MT	Bit Offset:12	Bit Width:1
        \ %xxxx  8 lshift RTC_DR        \ RTC_MU	Bit Offset:8	Bit Width:4
        \ %xx  4 lshift RTC_DR        \ RTC_DT	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift RTC_DR        \ RTC_DU	Bit Offset:0	Bit Width:4
        
        RTC $8 + constant RTC_CR	\ 		\  : RESET_RTC_CR $00000000 
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
        \ %x  6 lshift RTC_CR        \ RTC_FMT	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RTC_CR        \ RTC_BYPSHAD	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RTC_CR        \ RTC_REFCKON	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_CR        \ RTC_TSEDGE	Bit Offset:3	Bit Width:1
        \ %xxx  0 lshift RTC_CR        \ RTC_WUCKSEL	Bit Offset:0	Bit Width:3
        
        RTC $C + constant RTC_ISR	\ 		\  : RESET_RTC_ISR $00000000 
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
        
        RTC $10 + constant RTC_PRER	\ read-write		\  : RESET_RTC_PRER $00000000 
        \ %xxxxxxx  16 lshift RTC_PRER        \ RTC_PREDIV_A	Bit Offset:16	Bit Width:7
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_PRER        \ RTC_PREDIV_S	Bit Offset:0	Bit Width:16
        
        RTC $14 + constant RTC_WUTR	\ read-write		\  : RESET_RTC_WUTR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_WUTR        \ RTC_WUT	Bit Offset:0	Bit Width:16
        
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
        \ %xxxxxxxxxxxxxxxx  0 lshift RTC_TSSSR        \ RTC_SS	Bit Offset:0	Bit Width:16
        
        RTC $3C + constant RTC_CALR	\ read-write		\  : RESET_RTC_CALR $00000000 
        \ %x  15 lshift RTC_CALR        \ RTC_CALP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift RTC_CALR        \ RTC_CALW8	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RTC_CALR        \ RTC_CALW16	Bit Offset:13	Bit Width:1
        \ %xxxxxxxxx  0 lshift RTC_CALR        \ RTC_CALM	Bit Offset:0	Bit Width:9
        
        RTC $40 + constant RTC_TAMPCR	\ read-write		\  : RESET_RTC_TAMPCR $00000000 
        \ %x  21 lshift RTC_TAMPCR        \ RTC_TAMP2MF	Bit Offset:21	Bit Width:1
        \ %x  20 lshift RTC_TAMPCR        \ RTC_TAMP2NOERASE	Bit Offset:20	Bit Width:1
        \ %x  19 lshift RTC_TAMPCR        \ RTC_TAMP2IE	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RTC_TAMPCR        \ RTC_TAMP1MF	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RTC_TAMPCR        \ RTC_TAMP1NOERASE	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RTC_TAMPCR        \ RTC_TAMP1IE	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RTC_TAMPCR        \ RTC_TAMPPUDIS	Bit Offset:15	Bit Width:1
        \ %xx  13 lshift RTC_TAMPCR        \ RTC_TAMPPRCH	Bit Offset:13	Bit Width:2
        \ %xx  11 lshift RTC_TAMPCR        \ RTC_TAMPFLT	Bit Offset:11	Bit Width:2
        \ %xxx  8 lshift RTC_TAMPCR        \ RTC_TAMPFREQ	Bit Offset:8	Bit Width:3
        \ %x  7 lshift RTC_TAMPCR        \ RTC_TAMPTS	Bit Offset:7	Bit Width:1
        \ %x  4 lshift RTC_TAMPCR        \ RTC_TAMP2_TRG	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RTC_TAMPCR        \ RTC_TAMP2E	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RTC_TAMPCR        \ RTC_TAMPIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RTC_TAMPCR        \ RTC_TAMP1TRG	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RTC_TAMPCR        \ RTC_TAMP1E	Bit Offset:0	Bit Width:1
        
        RTC $44 + constant RTC_ALRMASSR	\ read-write		\  : RESET_RTC_ALRMASSR $00000000 
        \ %xxxx  24 lshift RTC_ALRMASSR        \ RTC_MASKSS	Bit Offset:24	Bit Width:4
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_ALRMASSR        \ RTC_SS	Bit Offset:0	Bit Width:15
        
        RTC $48 + constant RTC_ALRMBSSR	\ read-write		\  : RESET_RTC_ALRMBSSR $00000000 
        \ %xxxx  24 lshift RTC_ALRMBSSR        \ RTC_MASKSS	Bit Offset:24	Bit Width:4
        \ %xxxxxxxxxxxxxxx  0 lshift RTC_ALRMBSSR        \ RTC_SS	Bit Offset:0	Bit Width:15
        
        RTC $4C + constant RTC_OR	\ read-write		\  : RESET_RTC_OR $00000000 
        \ %x  1 lshift RTC_OR        \ RTC_RTC_OUT_RMP	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RTC_OR        \ RTC_RTC_ALARM_TYPE	Bit Offset:0	Bit Width:1
        
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
        
         
	
     $40013800 constant USART1  
	 USART1 $0 + constant USART1_CR1	\ read-write		\  : RESET_USART1_CR1 $0000 
        \ %x  28 lshift USART1_CR1        \ USART1_M1	Bit Offset:28	Bit Width:1
        \ %x  27 lshift USART1_CR1        \ USART1_EOBIE	Bit Offset:27	Bit Width:1
        \ %x  26 lshift USART1_CR1        \ USART1_RTOIE	Bit Offset:26	Bit Width:1
        \ %x  25 lshift USART1_CR1        \ USART1_DEAT4	Bit Offset:25	Bit Width:1
        \ %x  24 lshift USART1_CR1        \ USART1_DEAT3	Bit Offset:24	Bit Width:1
        \ %x  23 lshift USART1_CR1        \ USART1_DEAT2	Bit Offset:23	Bit Width:1
        \ %x  22 lshift USART1_CR1        \ USART1_DEAT1	Bit Offset:22	Bit Width:1
        \ %x  21 lshift USART1_CR1        \ USART1_DEAT0	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USART1_CR1        \ USART1_DEDT4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift USART1_CR1        \ USART1_DEDT3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift USART1_CR1        \ USART1_DEDT2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift USART1_CR1        \ USART1_DEDT1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USART1_CR1        \ USART1_DEDT0	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USART1_CR1        \ USART1_OVER8	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USART1_CR1        \ USART1_CMIE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift USART1_CR1        \ USART1_MME	Bit Offset:13	Bit Width:1
        \ %x  12 lshift USART1_CR1        \ USART1_M0	Bit Offset:12	Bit Width:1
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
        \ %x  1 lshift USART1_CR1        \ USART1_UESM	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_CR1        \ USART1_UE	Bit Offset:0	Bit Width:1
        
        USART1 $4 + constant USART1_CR2	\ read-write		\  : RESET_USART1_CR2 $0000 
        \ %xxxx  28 lshift USART1_CR2        \ USART1_ADD4_7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift USART1_CR2        \ USART1_ADD0_3	Bit Offset:24	Bit Width:4
        \ %x  23 lshift USART1_CR2        \ USART1_RTOEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift USART1_CR2        \ USART1_ABRMOD1	Bit Offset:22	Bit Width:1
        \ %x  21 lshift USART1_CR2        \ USART1_ABRMOD0	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USART1_CR2        \ USART1_ABREN	Bit Offset:20	Bit Width:1
        \ %x  19 lshift USART1_CR2        \ USART1_MSBFIRST	Bit Offset:19	Bit Width:1
        \ %x  18 lshift USART1_CR2        \ USART1_TAINV	Bit Offset:18	Bit Width:1
        \ %x  17 lshift USART1_CR2        \ USART1_TXINV	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USART1_CR2        \ USART1_RXINV	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USART1_CR2        \ USART1_SWAP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USART1_CR2        \ USART1_LINEN	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USART1_CR2        \ USART1_STOP	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USART1_CR2        \ USART1_CLKEN	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART1_CR2        \ USART1_CPOL	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART1_CR2        \ USART1_CPHA	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_CR2        \ USART1_LBCL	Bit Offset:8	Bit Width:1
        \ %x  6 lshift USART1_CR2        \ USART1_LBDIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_CR2        \ USART1_LBDL	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART1_CR2        \ USART1_ADDM7	Bit Offset:4	Bit Width:1
        
        USART1 $8 + constant USART1_CR3	\ read-write		\  : RESET_USART1_CR3 $0000 
        \ %x  22 lshift USART1_CR3        \ USART1_WUFIE	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift USART1_CR3        \ USART1_WUS	Bit Offset:20	Bit Width:2
        \ %xxx  17 lshift USART1_CR3        \ USART1_SCARCNT	Bit Offset:17	Bit Width:3
        \ %x  15 lshift USART1_CR3        \ USART1_DEP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USART1_CR3        \ USART1_DEM	Bit Offset:14	Bit Width:1
        \ %x  13 lshift USART1_CR3        \ USART1_DDRE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift USART1_CR3        \ USART1_OVRDIS	Bit Offset:12	Bit Width:1
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
        
        USART1 $C + constant USART1_BRR	\ read-write		\  : RESET_USART1_BRR $0000 
        \ %xxxxxxxxxxxx  4 lshift USART1_BRR        \ USART1_DIV_Mantissa	Bit Offset:4	Bit Width:12
        \ %xxxx  0 lshift USART1_BRR        \ USART1_DIV_Fraction	Bit Offset:0	Bit Width:4
        
        USART1 $10 + constant USART1_GTPR	\ read-write		\  : RESET_USART1_GTPR $0000 
        \ %xxxxxxxx  8 lshift USART1_GTPR        \ USART1_GT	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  0 lshift USART1_GTPR        \ USART1_PSC	Bit Offset:0	Bit Width:8
        
        USART1 $14 + constant USART1_RTOR	\ read-write		\  : RESET_USART1_RTOR $0000 
        \ %xxxxxxxx  24 lshift USART1_RTOR        \ USART1_BLEN	Bit Offset:24	Bit Width:8
        \ %xxxxxxxxxxxxxxxxxxxxxxxx  0 lshift USART1_RTOR        \ USART1_RTO	Bit Offset:0	Bit Width:24
        
        USART1 $18 + constant USART1_RQR	\ write-only		\  : RESET_USART1_RQR $0000 
        \ %x  4 lshift USART1_RQR        \ USART1_TXFRQ	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_RQR        \ USART1_RXFRQ	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_RQR        \ USART1_MMRQ	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_RQR        \ USART1_SBKRQ	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_RQR        \ USART1_ABRRQ	Bit Offset:0	Bit Width:1
        
        USART1 $1C + constant USART1_ISR	\ read-only		\  : RESET_USART1_ISR $00C0 
        \ %x  22 lshift USART1_ISR        \ USART1_REACK	Bit Offset:22	Bit Width:1
        \ %x  21 lshift USART1_ISR        \ USART1_TEACK	Bit Offset:21	Bit Width:1
        \ %x  20 lshift USART1_ISR        \ USART1_WUF	Bit Offset:20	Bit Width:1
        \ %x  19 lshift USART1_ISR        \ USART1_RWU	Bit Offset:19	Bit Width:1
        \ %x  18 lshift USART1_ISR        \ USART1_SBKF	Bit Offset:18	Bit Width:1
        \ %x  17 lshift USART1_ISR        \ USART1_CMF	Bit Offset:17	Bit Width:1
        \ %x  16 lshift USART1_ISR        \ USART1_BUSY	Bit Offset:16	Bit Width:1
        \ %x  15 lshift USART1_ISR        \ USART1_ABRF	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USART1_ISR        \ USART1_ABRE	Bit Offset:14	Bit Width:1
        \ %x  12 lshift USART1_ISR        \ USART1_EOBF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift USART1_ISR        \ USART1_RTOF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USART1_ISR        \ USART1_CTS	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USART1_ISR        \ USART1_CTSIF	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_ISR        \ USART1_LBDF	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USART1_ISR        \ USART1_TXE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USART1_ISR        \ USART1_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USART1_ISR        \ USART1_RXNE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USART1_ISR        \ USART1_IDLE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_ISR        \ USART1_ORE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_ISR        \ USART1_NF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_ISR        \ USART1_FE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_ISR        \ USART1_PE	Bit Offset:0	Bit Width:1
        
        USART1 $20 + constant USART1_ICR	\ write-only		\  : RESET_USART1_ICR $0000 
        \ %x  20 lshift USART1_ICR        \ USART1_WUCF	Bit Offset:20	Bit Width:1
        \ %x  17 lshift USART1_ICR        \ USART1_CMCF	Bit Offset:17	Bit Width:1
        \ %x  12 lshift USART1_ICR        \ USART1_EOBCF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift USART1_ICR        \ USART1_RTOCF	Bit Offset:11	Bit Width:1
        \ %x  9 lshift USART1_ICR        \ USART1_CTSCF	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USART1_ICR        \ USART1_LBDCF	Bit Offset:8	Bit Width:1
        \ %x  6 lshift USART1_ICR        \ USART1_TCCF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift USART1_ICR        \ USART1_IDLECF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USART1_ICR        \ USART1_ORECF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USART1_ICR        \ USART1_NCF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USART1_ICR        \ USART1_FECF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USART1_ICR        \ USART1_PECF	Bit Offset:0	Bit Width:1
        
        USART1 $24 + constant USART1_RDR	\ read-only		\  : RESET_USART1_RDR $0000 
        \ %xxxxxxxxx  0 lshift USART1_RDR        \ USART1_RDR	Bit Offset:0	Bit Width:9
        
        USART1 $28 + constant USART1_TDR	\ read-write		\  : RESET_USART1_TDR $0000 
        \ %xxxxxxxxx  0 lshift USART1_TDR        \ USART1_TDR	Bit Offset:0	Bit Width:9
        
         
	
     $40004400 constant USART2  
	  
	
     $40024000 constant TSC  
	 TSC $0 + constant TSC_CR	\ read-write		\  : RESET_TSC_CR $00000000 
        \ %xxxx  28 lshift TSC_CR        \ TSC_CTPH	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift TSC_CR        \ TSC_CTPL	Bit Offset:24	Bit Width:4
        \ %xxxxxxx  17 lshift TSC_CR        \ TSC_SSD	Bit Offset:17	Bit Width:7
        \ %x  16 lshift TSC_CR        \ TSC_SSE	Bit Offset:16	Bit Width:1
        \ %x  15 lshift TSC_CR        \ TSC_SSPSC	Bit Offset:15	Bit Width:1
        \ %xxx  12 lshift TSC_CR        \ TSC_PGPSC	Bit Offset:12	Bit Width:3
        \ %xxx  5 lshift TSC_CR        \ TSC_MCV	Bit Offset:5	Bit Width:3
        \ %x  4 lshift TSC_CR        \ TSC_IODEF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TSC_CR        \ TSC_SYNCPOL	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TSC_CR        \ TSC_AM	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TSC_CR        \ TSC_START	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_CR        \ TSC_TSCE	Bit Offset:0	Bit Width:1
        
        TSC $4 + constant TSC_IER	\ read-write		\  : RESET_TSC_IER $00000000 
        \ %x  1 lshift TSC_IER        \ TSC_MCEIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_IER        \ TSC_EOAIE	Bit Offset:0	Bit Width:1
        
        TSC $8 + constant TSC_ICR	\ read-write		\  : RESET_TSC_ICR $00000000 
        \ %x  1 lshift TSC_ICR        \ TSC_MCEIC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_ICR        \ TSC_EOAIC	Bit Offset:0	Bit Width:1
        
        TSC $C + constant TSC_ISR	\ read-write		\  : RESET_TSC_ISR $00000000 
        \ %x  1 lshift TSC_ISR        \ TSC_MCEF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_ISR        \ TSC_EOAF	Bit Offset:0	Bit Width:1
        
        TSC $10 + constant TSC_IOHCR	\ read-write		\  : RESET_TSC_IOHCR $FFFFFFFF 
        \ %x  31 lshift TSC_IOHCR        \ TSC_G8_IO4	Bit Offset:31	Bit Width:1
        \ %x  30 lshift TSC_IOHCR        \ TSC_G8_IO3	Bit Offset:30	Bit Width:1
        \ %x  29 lshift TSC_IOHCR        \ TSC_G8_IO2	Bit Offset:29	Bit Width:1
        \ %x  28 lshift TSC_IOHCR        \ TSC_G8_IO1	Bit Offset:28	Bit Width:1
        \ %x  27 lshift TSC_IOHCR        \ TSC_G7_IO4	Bit Offset:27	Bit Width:1
        \ %x  26 lshift TSC_IOHCR        \ TSC_G7_IO3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift TSC_IOHCR        \ TSC_G7_IO2	Bit Offset:25	Bit Width:1
        \ %x  24 lshift TSC_IOHCR        \ TSC_G7_IO1	Bit Offset:24	Bit Width:1
        \ %x  23 lshift TSC_IOHCR        \ TSC_G6_IO4	Bit Offset:23	Bit Width:1
        \ %x  22 lshift TSC_IOHCR        \ TSC_G6_IO3	Bit Offset:22	Bit Width:1
        \ %x  21 lshift TSC_IOHCR        \ TSC_G6_IO2	Bit Offset:21	Bit Width:1
        \ %x  20 lshift TSC_IOHCR        \ TSC_G6_IO1	Bit Offset:20	Bit Width:1
        \ %x  19 lshift TSC_IOHCR        \ TSC_G5_IO4	Bit Offset:19	Bit Width:1
        \ %x  18 lshift TSC_IOHCR        \ TSC_G5_IO3	Bit Offset:18	Bit Width:1
        \ %x  17 lshift TSC_IOHCR        \ TSC_G5_IO2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift TSC_IOHCR        \ TSC_G5_IO1	Bit Offset:16	Bit Width:1
        \ %x  15 lshift TSC_IOHCR        \ TSC_G4_IO4	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TSC_IOHCR        \ TSC_G4_IO3	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TSC_IOHCR        \ TSC_G4_IO2	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TSC_IOHCR        \ TSC_G4_IO1	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TSC_IOHCR        \ TSC_G3_IO4	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TSC_IOHCR        \ TSC_G3_IO3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TSC_IOHCR        \ TSC_G3_IO2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TSC_IOHCR        \ TSC_G3_IO1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TSC_IOHCR        \ TSC_G2_IO4	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TSC_IOHCR        \ TSC_G2_IO3	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TSC_IOHCR        \ TSC_G2_IO2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TSC_IOHCR        \ TSC_G2_IO1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TSC_IOHCR        \ TSC_G1_IO4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TSC_IOHCR        \ TSC_G1_IO3	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TSC_IOHCR        \ TSC_G1_IO2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_IOHCR        \ TSC_G1_IO1	Bit Offset:0	Bit Width:1
        
        TSC $18 + constant TSC_IOASCR	\ read-write		\  : RESET_TSC_IOASCR $00000000 
        \ %x  31 lshift TSC_IOASCR        \ TSC_G8_IO4	Bit Offset:31	Bit Width:1
        \ %x  30 lshift TSC_IOASCR        \ TSC_G8_IO3	Bit Offset:30	Bit Width:1
        \ %x  29 lshift TSC_IOASCR        \ TSC_G8_IO2	Bit Offset:29	Bit Width:1
        \ %x  28 lshift TSC_IOASCR        \ TSC_G8_IO1	Bit Offset:28	Bit Width:1
        \ %x  27 lshift TSC_IOASCR        \ TSC_G7_IO4	Bit Offset:27	Bit Width:1
        \ %x  26 lshift TSC_IOASCR        \ TSC_G7_IO3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift TSC_IOASCR        \ TSC_G7_IO2	Bit Offset:25	Bit Width:1
        \ %x  24 lshift TSC_IOASCR        \ TSC_G7_IO1	Bit Offset:24	Bit Width:1
        \ %x  23 lshift TSC_IOASCR        \ TSC_G6_IO4	Bit Offset:23	Bit Width:1
        \ %x  22 lshift TSC_IOASCR        \ TSC_G6_IO3	Bit Offset:22	Bit Width:1
        \ %x  21 lshift TSC_IOASCR        \ TSC_G6_IO2	Bit Offset:21	Bit Width:1
        \ %x  20 lshift TSC_IOASCR        \ TSC_G6_IO1	Bit Offset:20	Bit Width:1
        \ %x  19 lshift TSC_IOASCR        \ TSC_G5_IO4	Bit Offset:19	Bit Width:1
        \ %x  18 lshift TSC_IOASCR        \ TSC_G5_IO3	Bit Offset:18	Bit Width:1
        \ %x  17 lshift TSC_IOASCR        \ TSC_G5_IO2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift TSC_IOASCR        \ TSC_G5_IO1	Bit Offset:16	Bit Width:1
        \ %x  15 lshift TSC_IOASCR        \ TSC_G4_IO4	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TSC_IOASCR        \ TSC_G4_IO3	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TSC_IOASCR        \ TSC_G4_IO2	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TSC_IOASCR        \ TSC_G4_IO1	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TSC_IOASCR        \ TSC_G3_IO4	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TSC_IOASCR        \ TSC_G3_IO3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TSC_IOASCR        \ TSC_G3_IO2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TSC_IOASCR        \ TSC_G3_IO1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TSC_IOASCR        \ TSC_G2_IO4	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TSC_IOASCR        \ TSC_G2_IO3	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TSC_IOASCR        \ TSC_G2_IO2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TSC_IOASCR        \ TSC_G2_IO1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TSC_IOASCR        \ TSC_G1_IO4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TSC_IOASCR        \ TSC_G1_IO3	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TSC_IOASCR        \ TSC_G1_IO2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_IOASCR        \ TSC_G1_IO1	Bit Offset:0	Bit Width:1
        
        TSC $20 + constant TSC_IOSCR	\ read-write		\  : RESET_TSC_IOSCR $00000000 
        \ %x  31 lshift TSC_IOSCR        \ TSC_G8_IO4	Bit Offset:31	Bit Width:1
        \ %x  30 lshift TSC_IOSCR        \ TSC_G8_IO3	Bit Offset:30	Bit Width:1
        \ %x  29 lshift TSC_IOSCR        \ TSC_G8_IO2	Bit Offset:29	Bit Width:1
        \ %x  28 lshift TSC_IOSCR        \ TSC_G8_IO1	Bit Offset:28	Bit Width:1
        \ %x  27 lshift TSC_IOSCR        \ TSC_G7_IO4	Bit Offset:27	Bit Width:1
        \ %x  26 lshift TSC_IOSCR        \ TSC_G7_IO3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift TSC_IOSCR        \ TSC_G7_IO2	Bit Offset:25	Bit Width:1
        \ %x  24 lshift TSC_IOSCR        \ TSC_G7_IO1	Bit Offset:24	Bit Width:1
        \ %x  23 lshift TSC_IOSCR        \ TSC_G6_IO4	Bit Offset:23	Bit Width:1
        \ %x  22 lshift TSC_IOSCR        \ TSC_G6_IO3	Bit Offset:22	Bit Width:1
        \ %x  21 lshift TSC_IOSCR        \ TSC_G6_IO2	Bit Offset:21	Bit Width:1
        \ %x  20 lshift TSC_IOSCR        \ TSC_G6_IO1	Bit Offset:20	Bit Width:1
        \ %x  19 lshift TSC_IOSCR        \ TSC_G5_IO4	Bit Offset:19	Bit Width:1
        \ %x  18 lshift TSC_IOSCR        \ TSC_G5_IO3	Bit Offset:18	Bit Width:1
        \ %x  17 lshift TSC_IOSCR        \ TSC_G5_IO2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift TSC_IOSCR        \ TSC_G5_IO1	Bit Offset:16	Bit Width:1
        \ %x  15 lshift TSC_IOSCR        \ TSC_G4_IO4	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TSC_IOSCR        \ TSC_G4_IO3	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TSC_IOSCR        \ TSC_G4_IO2	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TSC_IOSCR        \ TSC_G4_IO1	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TSC_IOSCR        \ TSC_G3_IO4	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TSC_IOSCR        \ TSC_G3_IO3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TSC_IOSCR        \ TSC_G3_IO2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TSC_IOSCR        \ TSC_G3_IO1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TSC_IOSCR        \ TSC_G2_IO4	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TSC_IOSCR        \ TSC_G2_IO3	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TSC_IOSCR        \ TSC_G2_IO2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TSC_IOSCR        \ TSC_G2_IO1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TSC_IOSCR        \ TSC_G1_IO4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TSC_IOSCR        \ TSC_G1_IO3	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TSC_IOSCR        \ TSC_G1_IO2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_IOSCR        \ TSC_G1_IO1	Bit Offset:0	Bit Width:1
        
        TSC $28 + constant TSC_IOCCR	\ read-write		\  : RESET_TSC_IOCCR $00000000 
        \ %x  31 lshift TSC_IOCCR        \ TSC_G8_IO4	Bit Offset:31	Bit Width:1
        \ %x  30 lshift TSC_IOCCR        \ TSC_G8_IO3	Bit Offset:30	Bit Width:1
        \ %x  29 lshift TSC_IOCCR        \ TSC_G8_IO2	Bit Offset:29	Bit Width:1
        \ %x  28 lshift TSC_IOCCR        \ TSC_G8_IO1	Bit Offset:28	Bit Width:1
        \ %x  27 lshift TSC_IOCCR        \ TSC_G7_IO4	Bit Offset:27	Bit Width:1
        \ %x  26 lshift TSC_IOCCR        \ TSC_G7_IO3	Bit Offset:26	Bit Width:1
        \ %x  25 lshift TSC_IOCCR        \ TSC_G7_IO2	Bit Offset:25	Bit Width:1
        \ %x  24 lshift TSC_IOCCR        \ TSC_G7_IO1	Bit Offset:24	Bit Width:1
        \ %x  23 lshift TSC_IOCCR        \ TSC_G6_IO4	Bit Offset:23	Bit Width:1
        \ %x  22 lshift TSC_IOCCR        \ TSC_G6_IO3	Bit Offset:22	Bit Width:1
        \ %x  21 lshift TSC_IOCCR        \ TSC_G6_IO2	Bit Offset:21	Bit Width:1
        \ %x  20 lshift TSC_IOCCR        \ TSC_G6_IO1	Bit Offset:20	Bit Width:1
        \ %x  19 lshift TSC_IOCCR        \ TSC_G5_IO4	Bit Offset:19	Bit Width:1
        \ %x  18 lshift TSC_IOCCR        \ TSC_G5_IO3	Bit Offset:18	Bit Width:1
        \ %x  17 lshift TSC_IOCCR        \ TSC_G5_IO2	Bit Offset:17	Bit Width:1
        \ %x  16 lshift TSC_IOCCR        \ TSC_G5_IO1	Bit Offset:16	Bit Width:1
        \ %x  15 lshift TSC_IOCCR        \ TSC_G4_IO4	Bit Offset:15	Bit Width:1
        \ %x  14 lshift TSC_IOCCR        \ TSC_G4_IO3	Bit Offset:14	Bit Width:1
        \ %x  13 lshift TSC_IOCCR        \ TSC_G4_IO2	Bit Offset:13	Bit Width:1
        \ %x  12 lshift TSC_IOCCR        \ TSC_G4_IO1	Bit Offset:12	Bit Width:1
        \ %x  11 lshift TSC_IOCCR        \ TSC_G3_IO4	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TSC_IOCCR        \ TSC_G3_IO3	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TSC_IOCCR        \ TSC_G3_IO2	Bit Offset:9	Bit Width:1
        \ %x  8 lshift TSC_IOCCR        \ TSC_G3_IO1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift TSC_IOCCR        \ TSC_G2_IO4	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TSC_IOCCR        \ TSC_G2_IO3	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TSC_IOCCR        \ TSC_G2_IO2	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TSC_IOCCR        \ TSC_G2_IO1	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TSC_IOCCR        \ TSC_G1_IO4	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TSC_IOCCR        \ TSC_G1_IO3	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TSC_IOCCR        \ TSC_G1_IO2	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_IOCCR        \ TSC_G1_IO1	Bit Offset:0	Bit Width:1
        
        TSC $30 + constant TSC_IOGCSR	\ 		\  : RESET_TSC_IOGCSR $00000000 
        \ %x  23 lshift TSC_IOGCSR        \ TSC_G8S	Bit Offset:23	Bit Width:1
        \ %x  22 lshift TSC_IOGCSR        \ TSC_G7S	Bit Offset:22	Bit Width:1
        \ %x  21 lshift TSC_IOGCSR        \ TSC_G6S	Bit Offset:21	Bit Width:1
        \ %x  20 lshift TSC_IOGCSR        \ TSC_G5S	Bit Offset:20	Bit Width:1
        \ %x  19 lshift TSC_IOGCSR        \ TSC_G4S	Bit Offset:19	Bit Width:1
        \ %x  18 lshift TSC_IOGCSR        \ TSC_G3S	Bit Offset:18	Bit Width:1
        \ %x  17 lshift TSC_IOGCSR        \ TSC_G2S	Bit Offset:17	Bit Width:1
        \ %x  16 lshift TSC_IOGCSR        \ TSC_G1S	Bit Offset:16	Bit Width:1
        \ %x  7 lshift TSC_IOGCSR        \ TSC_G8E	Bit Offset:7	Bit Width:1
        \ %x  6 lshift TSC_IOGCSR        \ TSC_G7E	Bit Offset:6	Bit Width:1
        \ %x  5 lshift TSC_IOGCSR        \ TSC_G6E	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TSC_IOGCSR        \ TSC_G5E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TSC_IOGCSR        \ TSC_G4E	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TSC_IOGCSR        \ TSC_G3E	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TSC_IOGCSR        \ TSC_G2E	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TSC_IOGCSR        \ TSC_G1E	Bit Offset:0	Bit Width:1
        
        TSC $34 + constant TSC_IOG1CR	\ read-only		\  : RESET_TSC_IOG1CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG1CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $38 + constant TSC_IOG2CR	\ read-only		\  : RESET_TSC_IOG2CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG2CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $3C + constant TSC_IOG3CR	\ read-only		\  : RESET_TSC_IOG3CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG3CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $40 + constant TSC_IOG4CR	\ read-only		\  : RESET_TSC_IOG4CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG4CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $44 + constant TSC_IOG5CR	\ read-only		\  : RESET_TSC_IOG5CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG5CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $48 + constant TSC_IOG6CR	\ read-only		\  : RESET_TSC_IOG6CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG6CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $4C + constant TSC_IOG7CR	\ read-only		\  : RESET_TSC_IOG7CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG7CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
        TSC $50 + constant TSC_IOG8CR	\ read-only		\  : RESET_TSC_IOG8CR $00000000 
        \ %xxxxxxxxxxxxxx  0 lshift TSC_IOG8CR        \ TSC_CNT	Bit Offset:0	Bit Width:14
        
         
	
     $40003000 constant IWDG  
	 IWDG $0 + constant IWDG_KR	\ write-only		\  : RESET_IWDG_KR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift IWDG_KR        \ IWDG_KEY	Bit Offset:0	Bit Width:16
        
        IWDG $4 + constant IWDG_PR	\ read-write		\  : RESET_IWDG_PR $00000000 
        \ %xxx  0 lshift IWDG_PR        \ IWDG_PR	Bit Offset:0	Bit Width:3
        
        IWDG $8 + constant IWDG_RLR	\ read-write		\  : RESET_IWDG_RLR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift IWDG_RLR        \ IWDG_RL	Bit Offset:0	Bit Width:12
        
        IWDG $C + constant IWDG_SR	\ read-only		\  : RESET_IWDG_SR $00000000 
        \ %x  2 lshift IWDG_SR        \ IWDG_WVU	Bit Offset:2	Bit Width:1
        \ %x  1 lshift IWDG_SR        \ IWDG_RVU	Bit Offset:1	Bit Width:1
        \ %x  0 lshift IWDG_SR        \ IWDG_PVU	Bit Offset:0	Bit Width:1
        
        IWDG $10 + constant IWDG_WINR	\ read-write		\  : RESET_IWDG_WINR $00000FFF 
        \ %xxxxxxxxxxxx  0 lshift IWDG_WINR        \ IWDG_WIN	Bit Offset:0	Bit Width:12
        
         
	
     $40002C00 constant WWDG  
	 WWDG $0 + constant WWDG_CR	\ read-write		\  : RESET_WWDG_CR $0000007F 
        \ %x  7 lshift WWDG_CR        \ WWDG_WDGA	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift WWDG_CR        \ WWDG_T	Bit Offset:0	Bit Width:7
        
        WWDG $4 + constant WWDG_CFR	\ read-write		\  : RESET_WWDG_CFR $0000007F 
        \ %x  9 lshift WWDG_CFR        \ WWDG_EWI	Bit Offset:9	Bit Width:1
        \ %x  8 lshift WWDG_CFR        \ WWDG_WDGTB1	Bit Offset:8	Bit Width:1
        \ %x  7 lshift WWDG_CFR        \ WWDG_WDGTB0	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift WWDG_CFR        \ WWDG_W	Bit Offset:0	Bit Width:7
        
        WWDG $8 + constant WWDG_SR	\ read-writeOnce		\  : RESET_WWDG_SR $00000000 
        \ %x  0 lshift WWDG_SR        \ WWDG_EWIF	Bit Offset:0	Bit Width:1
        
         
	
     $40010018 constant COMP  
	 COMP $18 + constant COMP_COMP1_CSR	\ 		\  : RESET_COMP_COMP1_CSR $0 
        \ %x  0 lshift COMP_COMP1_CSR        \ COMP_COMP1_EN	Bit Offset:0	Bit Width:1
        \ %xx  4 lshift COMP_COMP1_CSR        \ COMP_COMP1_INN_SEL	Bit Offset:4	Bit Width:2
        \ %x  8 lshift COMP_COMP1_CSR        \ COMP_COMP1_WM	Bit Offset:8	Bit Width:1
        \ %xxx  12 lshift COMP_COMP1_CSR        \ COMP_COMP1_OUT_SEL	Bit Offset:12	Bit Width:3
        \ %x  15 lshift COMP_COMP1_CSR        \ COMP_COMP1_POLARITY	Bit Offset:15	Bit Width:1
        \ %x  30 lshift COMP_COMP1_CSR        \ COMP_COMP1_VALUE	Bit Offset:30	Bit Width:1
        \ %x  31 lshift COMP_COMP1_CSR        \ COMP_COMP1_LOCK	Bit Offset:31	Bit Width:1
        
        COMP $1C + constant COMP_COMP2_CSR	\ 		\  : RESET_COMP_COMP2_CSR $0 
        \ %x  31 lshift COMP_COMP2_CSR        \ COMP_COMP2_LOCK	Bit Offset:31	Bit Width:1
        \ %x  30 lshift COMP_COMP2_CSR        \ COMP_COMP2_VALUE	Bit Offset:30	Bit Width:1
        \ %x  15 lshift COMP_COMP2_CSR        \ COMP_COMP2_POLARITY	Bit Offset:15	Bit Width:1
        \ %xxx  8 lshift COMP_COMP2_CSR        \ COMP_COMP2_INP_SEL	Bit Offset:8	Bit Width:3
        \ %xxx  4 lshift COMP_COMP2_CSR        \ COMP_COMP2_INN_SEL	Bit Offset:4	Bit Width:3
        \ %x  3 lshift COMP_COMP2_CSR        \ COMP_COMP2_SPEED	Bit Offset:3	Bit Width:1
        \ %x  0 lshift COMP_COMP2_CSR        \ COMP_COMP2_EN	Bit Offset:0	Bit Width:1
        \ %xxx  12 lshift COMP_COMP2_CSR        \ COMP_COMP2_OUT_SEL	Bit Offset:12	Bit Width:3
        
         
	
     $40005C00 constant USB_FS  
	 USB_FS $0 + constant USB_FS_EP0R	\ read-write		\  : RESET_USB_FS_EP0R $0 
        \ %x  15 lshift USB_FS_EP0R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP0R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP0R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP0R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP0R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP0R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP0R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP0R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP0R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP0R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $4 + constant USB_FS_EP1R	\ read-write		\  : RESET_USB_FS_EP1R $0 
        \ %x  15 lshift USB_FS_EP1R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP1R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP1R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP1R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP1R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP1R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP1R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP1R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP1R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP1R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $8 + constant USB_FS_EP2R	\ read-write		\  : RESET_USB_FS_EP2R $0 
        \ %x  15 lshift USB_FS_EP2R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP2R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP2R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP2R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP2R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP2R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP2R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP2R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP2R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP2R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $C + constant USB_FS_EP3R	\ read-write		\  : RESET_USB_FS_EP3R $0 
        \ %x  15 lshift USB_FS_EP3R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP3R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP3R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP3R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP3R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP3R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP3R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP3R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP3R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP3R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $10 + constant USB_FS_EP4R	\ read-write		\  : RESET_USB_FS_EP4R $0 
        \ %x  15 lshift USB_FS_EP4R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP4R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP4R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP4R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP4R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP4R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP4R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP4R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP4R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP4R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $14 + constant USB_FS_EP5R	\ read-write		\  : RESET_USB_FS_EP5R $0 
        \ %x  15 lshift USB_FS_EP5R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP5R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP5R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP5R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP5R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP5R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP5R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP5R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP5R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP5R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $18 + constant USB_FS_EP6R	\ read-write		\  : RESET_USB_FS_EP6R $0 
        \ %x  15 lshift USB_FS_EP6R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP6R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP6R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP6R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP6R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP6R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP6R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP6R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP6R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP6R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $1C + constant USB_FS_EP7R	\ read-write		\  : RESET_USB_FS_EP7R $0 
        \ %x  15 lshift USB_FS_EP7R        \ USB_FS_CTR_RX	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_EP7R        \ USB_FS_DTOG_RX	Bit Offset:14	Bit Width:1
        \ %xx  12 lshift USB_FS_EP7R        \ USB_FS_STAT_RX	Bit Offset:12	Bit Width:2
        \ %x  11 lshift USB_FS_EP7R        \ USB_FS_SETUP	Bit Offset:11	Bit Width:1
        \ %xx  9 lshift USB_FS_EP7R        \ USB_FS_EPTYPE	Bit Offset:9	Bit Width:2
        \ %x  8 lshift USB_FS_EP7R        \ USB_FS_EP_KIND	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_EP7R        \ USB_FS_CTR_TX	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_EP7R        \ USB_FS_DTOG_TX	Bit Offset:6	Bit Width:1
        \ %xx  4 lshift USB_FS_EP7R        \ USB_FS_STAT_TX	Bit Offset:4	Bit Width:2
        \ %xxxx  0 lshift USB_FS_EP7R        \ USB_FS_EA	Bit Offset:0	Bit Width:4
        
        USB_FS $40 + constant USB_FS_CNTR	\ read-write		\  : RESET_USB_FS_CNTR $0 
        \ %x  15 lshift USB_FS_CNTR        \ USB_FS_CTRM	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_CNTR        \ USB_FS_PMAOVRM	Bit Offset:14	Bit Width:1
        \ %x  13 lshift USB_FS_CNTR        \ USB_FS_ERRM	Bit Offset:13	Bit Width:1
        \ %x  12 lshift USB_FS_CNTR        \ USB_FS_WKUPM	Bit Offset:12	Bit Width:1
        \ %x  11 lshift USB_FS_CNTR        \ USB_FS_SUSPM	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USB_FS_CNTR        \ USB_FS_RESETM	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USB_FS_CNTR        \ USB_FS_SOFM	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USB_FS_CNTR        \ USB_FS_ESOFM	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_CNTR        \ USB_FS_L1REQM	Bit Offset:7	Bit Width:1
        \ %x  5 lshift USB_FS_CNTR        \ USB_FS_L1RESUME	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USB_FS_CNTR        \ USB_FS_RESUME	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_FS_CNTR        \ USB_FS_FSUSP	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USB_FS_CNTR        \ USB_FS_LPMODE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USB_FS_CNTR        \ USB_FS_PDWN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_FS_CNTR        \ USB_FS_FRES	Bit Offset:0	Bit Width:1
        
        USB_FS $44 + constant USB_FS_ISTR	\ read-write		\  : RESET_USB_FS_ISTR $0 
        \ %x  15 lshift USB_FS_ISTR        \ USB_FS_CTR	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_ISTR        \ USB_FS_PMAOVR	Bit Offset:14	Bit Width:1
        \ %x  13 lshift USB_FS_ISTR        \ USB_FS_ERR	Bit Offset:13	Bit Width:1
        \ %x  12 lshift USB_FS_ISTR        \ USB_FS_WKUP	Bit Offset:12	Bit Width:1
        \ %x  11 lshift USB_FS_ISTR        \ USB_FS_SUSP	Bit Offset:11	Bit Width:1
        \ %x  10 lshift USB_FS_ISTR        \ USB_FS_RESET	Bit Offset:10	Bit Width:1
        \ %x  9 lshift USB_FS_ISTR        \ USB_FS_SOF	Bit Offset:9	Bit Width:1
        \ %x  8 lshift USB_FS_ISTR        \ USB_FS_ESOF	Bit Offset:8	Bit Width:1
        \ %x  7 lshift USB_FS_ISTR        \ USB_FS_L1REQ	Bit Offset:7	Bit Width:1
        \ %x  4 lshift USB_FS_ISTR        \ USB_FS_DIR	Bit Offset:4	Bit Width:1
        \ %xxxx  0 lshift USB_FS_ISTR        \ USB_FS_EP_ID	Bit Offset:0	Bit Width:4
        
        USB_FS $48 + constant USB_FS_FNR	\ read-only		\  : RESET_USB_FS_FNR $0 
        \ %x  15 lshift USB_FS_FNR        \ USB_FS_RXDP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift USB_FS_FNR        \ USB_FS_RXDM	Bit Offset:14	Bit Width:1
        \ %x  13 lshift USB_FS_FNR        \ USB_FS_LCK	Bit Offset:13	Bit Width:1
        \ %xx  11 lshift USB_FS_FNR        \ USB_FS_LSOF	Bit Offset:11	Bit Width:2
        \ % 0 lshift USB_FS_FNR        \ USB_FS_FN	Bit Offset:0	Bit Width:11
        
        USB_FS $4C + constant USB_FS_DADDR	\ read-write		\  : RESET_USB_FS_DADDR $0 
        \ %x  7 lshift USB_FS_DADDR        \ USB_FS_EF	Bit Offset:7	Bit Width:1
        \ %xxxxxxx  0 lshift USB_FS_DADDR        \ USB_FS_ADD	Bit Offset:0	Bit Width:7
        
        USB_FS $50 + constant USB_FS_BTABLE	\ read-write		\  : RESET_USB_FS_BTABLE $0 
        \ % 3 lshift USB_FS_BTABLE        \ USB_FS_BTABLE	Bit Offset:3	Bit Width:13
        
        USB_FS $54 + constant USB_FS_LPMCSR	\ 		\  : RESET_USB_FS_LPMCSR $0 
        \ %xxxx  4 lshift USB_FS_LPMCSR        \ USB_FS_BESL	Bit Offset:4	Bit Width:4
        \ %x  3 lshift USB_FS_LPMCSR        \ USB_FS_REMWAKE	Bit Offset:3	Bit Width:1
        \ %x  1 lshift USB_FS_LPMCSR        \ USB_FS_LPMACK	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_FS_LPMCSR        \ USB_FS_LPMEN	Bit Offset:0	Bit Width:1
        
        USB_FS $58 + constant USB_FS_BCDR	\ 		\  : RESET_USB_FS_BCDR $0 
        \ %x  15 lshift USB_FS_BCDR        \ USB_FS_DPPU	Bit Offset:15	Bit Width:1
        \ %x  7 lshift USB_FS_BCDR        \ USB_FS_PS2DET	Bit Offset:7	Bit Width:1
        \ %x  6 lshift USB_FS_BCDR        \ USB_FS_SDET	Bit Offset:6	Bit Width:1
        \ %x  5 lshift USB_FS_BCDR        \ USB_FS_PDET	Bit Offset:5	Bit Width:1
        \ %x  4 lshift USB_FS_BCDR        \ USB_FS_DCDET	Bit Offset:4	Bit Width:1
        \ %x  3 lshift USB_FS_BCDR        \ USB_FS_SDEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift USB_FS_BCDR        \ USB_FS_PDEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift USB_FS_BCDR        \ USB_FS_DCDEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift USB_FS_BCDR        \ USB_FS_BCDEN	Bit Offset:0	Bit Width:1
        
         
	
     $40006C00 constant CRS  
	 CRS $0 + constant CRS_CR	\ read-write		\  : RESET_CRS_CR $00002000 
        \ %xxxxxx  8 lshift CRS_CR        \ CRS_TRIM	Bit Offset:8	Bit Width:6
        \ %x  7 lshift CRS_CR        \ CRS_SWSYNC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift CRS_CR        \ CRS_AUTOTRIMEN	Bit Offset:6	Bit Width:1
        \ %x  5 lshift CRS_CR        \ CRS_CEN	Bit Offset:5	Bit Width:1
        \ %x  3 lshift CRS_CR        \ CRS_ESYNCIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CRS_CR        \ CRS_ERRIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CRS_CR        \ CRS_SYNCWARNIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CRS_CR        \ CRS_SYNCOKIE	Bit Offset:0	Bit Width:1
        
        CRS $4 + constant CRS_CFGR	\ read-write		\  : RESET_CRS_CFGR $2022BB7F 
        \ %x  31 lshift CRS_CFGR        \ CRS_SYNCPOL	Bit Offset:31	Bit Width:1
        \ %xx  28 lshift CRS_CFGR        \ CRS_SYNCSRC	Bit Offset:28	Bit Width:2
        \ %xxx  24 lshift CRS_CFGR        \ CRS_SYNCDIV	Bit Offset:24	Bit Width:3
        \ %xxxxxxxx  16 lshift CRS_CFGR        \ CRS_FELIM	Bit Offset:16	Bit Width:8
        \ %xxxxxxxxxxxxxxxx  0 lshift CRS_CFGR        \ CRS_RELOAD	Bit Offset:0	Bit Width:16
        
        CRS $8 + constant CRS_ISR	\ read-only		\  : RESET_CRS_ISR $00000000 
        \ %xxxxxxxxxxxxxxxx  16 lshift CRS_ISR        \ CRS_FECAP	Bit Offset:16	Bit Width:16
        \ %x  15 lshift CRS_ISR        \ CRS_FEDIR	Bit Offset:15	Bit Width:1
        \ %x  10 lshift CRS_ISR        \ CRS_TRIMOVF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift CRS_ISR        \ CRS_SYNCMISS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift CRS_ISR        \ CRS_SYNCERR	Bit Offset:8	Bit Width:1
        \ %x  3 lshift CRS_ISR        \ CRS_ESYNCF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CRS_ISR        \ CRS_ERRF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CRS_ISR        \ CRS_SYNCWARNF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CRS_ISR        \ CRS_SYNCOKF	Bit Offset:0	Bit Width:1
        
        CRS $C + constant CRS_ICR	\ read-write		\  : RESET_CRS_ICR $00000000 
        \ %x  3 lshift CRS_ICR        \ CRS_ESYNCC	Bit Offset:3	Bit Width:1
        \ %x  2 lshift CRS_ICR        \ CRS_ERRC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift CRS_ICR        \ CRS_SYNCWARNC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift CRS_ICR        \ CRS_SYNCOKC	Bit Offset:0	Bit Width:1
        
         
	
     $40011C00 constant Firewall  
	 Firewall $0 + constant Firewall_FIREWALL_CSSA	\ read-write		\  : RESET_Firewall_FIREWALL_CSSA $00000000 
        \ %xxxxxxxxxxxxxxxx  8 lshift Firewall_FIREWALL_CSSA        \ Firewall_ADD	Bit Offset:8	Bit Width:16
        
        Firewall $4 + constant Firewall_FIREWALL_CSL	\ read-write		\  : RESET_Firewall_FIREWALL_CSL $00000000 
        \ %xxxxxxxxxxxxxx  8 lshift Firewall_FIREWALL_CSL        \ Firewall_LENG	Bit Offset:8	Bit Width:14
        
        Firewall $8 + constant Firewall_FIREWALL_NVDSSA	\ read-write		\  : RESET_Firewall_FIREWALL_NVDSSA $00000000 
        \ %xxxxxxxxxxxxxxxx  8 lshift Firewall_FIREWALL_NVDSSA        \ Firewall_ADD	Bit Offset:8	Bit Width:16
        
        Firewall $C + constant Firewall_FIREWALL_NVDSL	\ read-write		\  : RESET_Firewall_FIREWALL_NVDSL $00000000 
        \ %xxxxxxxxxxxxxx  8 lshift Firewall_FIREWALL_NVDSL        \ Firewall_LENG	Bit Offset:8	Bit Width:14
        
        Firewall $10 + constant Firewall_FIREWALL_VDSSA	\ read-write		\  : RESET_Firewall_FIREWALL_VDSSA $00000000 
        \ % 6 lshift Firewall_FIREWALL_VDSSA        \ Firewall_ADD	Bit Offset:6	Bit Width:10
        
        Firewall $14 + constant Firewall_FIREWALL_VDSL	\ read-write		\  : RESET_Firewall_FIREWALL_VDSL $00000000 
        \ % 6 lshift Firewall_FIREWALL_VDSL        \ Firewall_LENG	Bit Offset:6	Bit Width:10
        
        Firewall $20 + constant Firewall_FIREWALL_CR	\ read-write		\  : RESET_Firewall_FIREWALL_CR $00000000 
        \ %x  2 lshift Firewall_FIREWALL_CR        \ Firewall_VDE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift Firewall_FIREWALL_CR        \ Firewall_VDS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift Firewall_FIREWALL_CR        \ Firewall_FPA	Bit Offset:0	Bit Width:1
        
         
	
     $40021000 constant RCC  
	 RCC $0 + constant RCC_CR	\ 		\  : RESET_RCC_CR $00000300 
        \ %x  25 lshift RCC_CR        \ RCC_PLLRDY	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_CR        \ RCC_PLLON	Bit Offset:24	Bit Width:1
        \ %xx  20 lshift RCC_CR        \ RCC_RTCPRE	Bit Offset:20	Bit Width:2
        \ %x  19 lshift RCC_CR        \ RCC_CSSLSEON	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_CR        \ RCC_HSEBYP	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_CR        \ RCC_HSERDY	Bit Offset:17	Bit Width:1
        \ %x  16 lshift RCC_CR        \ RCC_HSEON	Bit Offset:16	Bit Width:1
        \ %x  9 lshift RCC_CR        \ RCC_MSIRDY	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_CR        \ RCC_MSION	Bit Offset:8	Bit Width:1
        \ %x  4 lshift RCC_CR        \ RCC_HSI16DIVF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_CR        \ RCC_HSI16DIVEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CR        \ RCC_HSI16RDYF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CR        \ RCC_HSI16KERON	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CR        \ RCC_HSI16ON	Bit Offset:0	Bit Width:1
        
        RCC $4 + constant RCC_ICSCR	\ 		\  : RESET_RCC_ICSCR $0000B000 
        \ %xxxxxxxx  24 lshift RCC_ICSCR        \ RCC_MSITRIM	Bit Offset:24	Bit Width:8
        \ %xxxxxxxx  16 lshift RCC_ICSCR        \ RCC_MSICAL	Bit Offset:16	Bit Width:8
        \ %xxx  13 lshift RCC_ICSCR        \ RCC_MSIRANGE	Bit Offset:13	Bit Width:3
        \ %xxxxx  8 lshift RCC_ICSCR        \ RCC_HSI16TRIM	Bit Offset:8	Bit Width:5
        \ %xxxxxxxx  0 lshift RCC_ICSCR        \ RCC_HSI16CAL	Bit Offset:0	Bit Width:8
        
        RCC $8 + constant RCC_CRRCR	\ 		\  : RESET_RCC_CRRCR $00000000 
        \ %xxxxxxxx  8 lshift RCC_CRRCR        \ RCC_HSI48CAL	Bit Offset:8	Bit Width:8
        \ %x  1 lshift RCC_CRRCR        \ RCC_HSI48RDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CRRCR        \ RCC_HSI48ON	Bit Offset:0	Bit Width:1
        
        RCC $C + constant RCC_CFGR	\ 		\  : RESET_RCC_CFGR $00000000 
        \ %xxx  28 lshift RCC_CFGR        \ RCC_MCOPRE	Bit Offset:28	Bit Width:3
        \ %xxx  24 lshift RCC_CFGR        \ RCC_MCOSEL	Bit Offset:24	Bit Width:3
        \ %xx  22 lshift RCC_CFGR        \ RCC_PLLDIV	Bit Offset:22	Bit Width:2
        \ %xxxx  18 lshift RCC_CFGR        \ RCC_PLLMUL	Bit Offset:18	Bit Width:4
        \ %x  16 lshift RCC_CFGR        \ RCC_PLLSRC	Bit Offset:16	Bit Width:1
        \ %x  15 lshift RCC_CFGR        \ RCC_STOPWUCK	Bit Offset:15	Bit Width:1
        \ %xxx  11 lshift RCC_CFGR        \ RCC_PPRE2	Bit Offset:11	Bit Width:3
        \ %xxx  8 lshift RCC_CFGR        \ RCC_PPRE1	Bit Offset:8	Bit Width:3
        \ %xxxx  4 lshift RCC_CFGR        \ RCC_HPRE	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift RCC_CFGR        \ RCC_SWS	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift RCC_CFGR        \ RCC_SW	Bit Offset:0	Bit Width:2
        
        RCC $10 + constant RCC_CIER	\ read-only		\  : RESET_RCC_CIER $00000000 
        \ %x  7 lshift RCC_CIER        \ RCC_CSSLSE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_CIER        \ RCC_HSI48RDYIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_CIER        \ RCC_MSIRDYIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_CIER        \ RCC_PLLRDYIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_CIER        \ RCC_HSERDYIE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CIER        \ RCC_HSI16RDYIE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CIER        \ RCC_LSERDYIE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CIER        \ RCC_LSIRDYIE	Bit Offset:0	Bit Width:1
        
        RCC $14 + constant RCC_CIFR	\ read-only		\  : RESET_RCC_CIFR $00000000 
        \ %x  8 lshift RCC_CIFR        \ RCC_CSSHSEF	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_CIFR        \ RCC_CSSLSEF	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_CIFR        \ RCC_HSI48RDYF	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_CIFR        \ RCC_MSIRDYF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_CIFR        \ RCC_PLLRDYF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_CIFR        \ RCC_HSERDYF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CIFR        \ RCC_HSI16RDYF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CIFR        \ RCC_LSERDYF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CIFR        \ RCC_LSIRDYF	Bit Offset:0	Bit Width:1
        
        RCC $18 + constant RCC_CICR	\ read-only		\  : RESET_RCC_CICR $00000000 
        \ %x  8 lshift RCC_CICR        \ RCC_CSSHSEC	Bit Offset:8	Bit Width:1
        \ %x  7 lshift RCC_CICR        \ RCC_CSSLSEC	Bit Offset:7	Bit Width:1
        \ %x  6 lshift RCC_CICR        \ RCC_HSI48RDYC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift RCC_CICR        \ RCC_MSIRDYC	Bit Offset:5	Bit Width:1
        \ %x  4 lshift RCC_CICR        \ RCC_PLLRDYC	Bit Offset:4	Bit Width:1
        \ %x  3 lshift RCC_CICR        \ RCC_HSERDYC	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CICR        \ RCC_HSI16RDYC	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CICR        \ RCC_LSERDYC	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CICR        \ RCC_LSIRDYC	Bit Offset:0	Bit Width:1
        
        RCC $1C + constant RCC_IOPRSTR	\ read-write		\  : RESET_RCC_IOPRSTR $00000000 
        \ %x  7 lshift RCC_IOPRSTR        \ RCC_IOPHRST	Bit Offset:7	Bit Width:1
        \ %x  3 lshift RCC_IOPRSTR        \ RCC_IOPDRST	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_IOPRSTR        \ RCC_IOPCRST	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_IOPRSTR        \ RCC_IOPBRST	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_IOPRSTR        \ RCC_IOPARST	Bit Offset:0	Bit Width:1
        
        RCC $20 + constant RCC_AHBRSTR	\ read-write		\  : RESET_RCC_AHBRSTR $00000000 
        \ %x  24 lshift RCC_AHBRSTR        \ RCC_CRYPRST	Bit Offset:24	Bit Width:1
        \ %x  20 lshift RCC_AHBRSTR        \ RCC_RNGRST	Bit Offset:20	Bit Width:1
        \ %x  16 lshift RCC_AHBRSTR        \ RCC_TOUCHRST	Bit Offset:16	Bit Width:1
        \ %x  12 lshift RCC_AHBRSTR        \ RCC_CRCRST	Bit Offset:12	Bit Width:1
        \ %x  8 lshift RCC_AHBRSTR        \ RCC_MIFRST	Bit Offset:8	Bit Width:1
        \ %x  0 lshift RCC_AHBRSTR        \ RCC_DMARST	Bit Offset:0	Bit Width:1
        
        RCC $24 + constant RCC_APB2RSTR	\ read-write		\  : RESET_RCC_APB2RSTR $000000000 
        \ %x  22 lshift RCC_APB2RSTR        \ RCC_DBGRST	Bit Offset:22	Bit Width:1
        \ %x  14 lshift RCC_APB2RSTR        \ RCC_USART1RST	Bit Offset:14	Bit Width:1
        \ %x  12 lshift RCC_APB2RSTR        \ RCC_SPI1RST	Bit Offset:12	Bit Width:1
        \ %x  9 lshift RCC_APB2RSTR        \ RCC_ADCRST	Bit Offset:9	Bit Width:1
        \ %x  5 lshift RCC_APB2RSTR        \ RCC_TM12RST	Bit Offset:5	Bit Width:1
        \ %x  2 lshift RCC_APB2RSTR        \ RCC_TIM21RST	Bit Offset:2	Bit Width:1
        \ %x  0 lshift RCC_APB2RSTR        \ RCC_SYSCFGRST	Bit Offset:0	Bit Width:1
        
        RCC $28 + constant RCC_APB1RSTR	\ read-write		\  : RESET_RCC_APB1RSTR $00000000 
        \ %x  31 lshift RCC_APB1RSTR        \ RCC_LPTIM1RST	Bit Offset:31	Bit Width:1
        \ %x  29 lshift RCC_APB1RSTR        \ RCC_DACRST	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_APB1RSTR        \ RCC_PWRRST	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_APB1RSTR        \ RCC_CRSRST	Bit Offset:27	Bit Width:1
        \ %x  23 lshift RCC_APB1RSTR        \ RCC_USBRST	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_APB1RSTR        \ RCC_I2C2RST	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_APB1RSTR        \ RCC_I2C1RST	Bit Offset:21	Bit Width:1
        \ %x  18 lshift RCC_APB1RSTR        \ RCC_LPUART1RST	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_APB1RSTR        \ RCC_LPUART12RST	Bit Offset:17	Bit Width:1
        \ %x  14 lshift RCC_APB1RSTR        \ RCC_SPI2RST	Bit Offset:14	Bit Width:1
        \ %x  11 lshift RCC_APB1RSTR        \ RCC_WWDRST	Bit Offset:11	Bit Width:1
        \ %x  4 lshift RCC_APB1RSTR        \ RCC_TIM6RST	Bit Offset:4	Bit Width:1
        \ %x  0 lshift RCC_APB1RSTR        \ RCC_TIM2RST	Bit Offset:0	Bit Width:1
        
        RCC $2C + constant RCC_IOPENR	\ read-write		\  : RESET_RCC_IOPENR $00000000 
        \ %x  7 lshift RCC_IOPENR        \ RCC_IOPHEN	Bit Offset:7	Bit Width:1
        \ %x  3 lshift RCC_IOPENR        \ RCC_IOPDEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_IOPENR        \ RCC_IOPCEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_IOPENR        \ RCC_IOPBEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_IOPENR        \ RCC_IOPAEN	Bit Offset:0	Bit Width:1
        
        RCC $30 + constant RCC_AHBENR	\ read-write		\  : RESET_RCC_AHBENR $00000100 
        \ %x  24 lshift RCC_AHBENR        \ RCC_CRYPEN	Bit Offset:24	Bit Width:1
        \ %x  20 lshift RCC_AHBENR        \ RCC_RNGEN	Bit Offset:20	Bit Width:1
        \ %x  16 lshift RCC_AHBENR        \ RCC_TOUCHEN	Bit Offset:16	Bit Width:1
        \ %x  12 lshift RCC_AHBENR        \ RCC_CRCEN	Bit Offset:12	Bit Width:1
        \ %x  8 lshift RCC_AHBENR        \ RCC_MIFEN	Bit Offset:8	Bit Width:1
        \ %x  0 lshift RCC_AHBENR        \ RCC_DMAEN	Bit Offset:0	Bit Width:1
        
        RCC $34 + constant RCC_APB2ENR	\ read-write		\  : RESET_RCC_APB2ENR $00000000 
        \ %x  22 lshift RCC_APB2ENR        \ RCC_DBGEN	Bit Offset:22	Bit Width:1
        \ %x  14 lshift RCC_APB2ENR        \ RCC_USART1EN	Bit Offset:14	Bit Width:1
        \ %x  12 lshift RCC_APB2ENR        \ RCC_SPI1EN	Bit Offset:12	Bit Width:1
        \ %x  9 lshift RCC_APB2ENR        \ RCC_ADCEN	Bit Offset:9	Bit Width:1
        \ %x  7 lshift RCC_APB2ENR        \ RCC_MIFIEN	Bit Offset:7	Bit Width:1
        \ %x  5 lshift RCC_APB2ENR        \ RCC_TIM22EN	Bit Offset:5	Bit Width:1
        \ %x  2 lshift RCC_APB2ENR        \ RCC_TIM21EN	Bit Offset:2	Bit Width:1
        \ %x  0 lshift RCC_APB2ENR        \ RCC_SYSCFGEN	Bit Offset:0	Bit Width:1
        
        RCC $38 + constant RCC_APB1ENR	\ read-write		\  : RESET_RCC_APB1ENR $00000000 
        \ %x  31 lshift RCC_APB1ENR        \ RCC_LPTIM1EN	Bit Offset:31	Bit Width:1
        \ %x  29 lshift RCC_APB1ENR        \ RCC_DACEN	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_APB1ENR        \ RCC_PWREN	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_APB1ENR        \ RCC_CRSEN	Bit Offset:27	Bit Width:1
        \ %x  23 lshift RCC_APB1ENR        \ RCC_USBEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_APB1ENR        \ RCC_I2C2EN	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_APB1ENR        \ RCC_I2C1EN	Bit Offset:21	Bit Width:1
        \ %x  18 lshift RCC_APB1ENR        \ RCC_LPUART1EN	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_APB1ENR        \ RCC_USART2EN	Bit Offset:17	Bit Width:1
        \ %x  14 lshift RCC_APB1ENR        \ RCC_SPI2EN	Bit Offset:14	Bit Width:1
        \ %x  11 lshift RCC_APB1ENR        \ RCC_WWDGEN	Bit Offset:11	Bit Width:1
        \ %x  4 lshift RCC_APB1ENR        \ RCC_TIM6EN	Bit Offset:4	Bit Width:1
        \ %x  0 lshift RCC_APB1ENR        \ RCC_TIM2EN	Bit Offset:0	Bit Width:1
        
        RCC $3C + constant RCC_IOPSMEN	\ read-write		\  : RESET_RCC_IOPSMEN $0000008F 
        \ %x  7 lshift RCC_IOPSMEN        \ RCC_IOPHSMEN	Bit Offset:7	Bit Width:1
        \ %x  3 lshift RCC_IOPSMEN        \ RCC_IOPDSMEN	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_IOPSMEN        \ RCC_IOPCSMEN	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_IOPSMEN        \ RCC_IOPBSMEN	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_IOPSMEN        \ RCC_IOPASMEN	Bit Offset:0	Bit Width:1
        
        RCC $40 + constant RCC_AHBSMENR	\ read-write		\  : RESET_RCC_AHBSMENR $01111301 
        \ %x  24 lshift RCC_AHBSMENR        \ RCC_CRYPSMEN	Bit Offset:24	Bit Width:1
        \ %x  20 lshift RCC_AHBSMENR        \ RCC_RNGSMEN	Bit Offset:20	Bit Width:1
        \ %x  16 lshift RCC_AHBSMENR        \ RCC_TOUCHSMEN	Bit Offset:16	Bit Width:1
        \ %x  12 lshift RCC_AHBSMENR        \ RCC_CRCSMEN	Bit Offset:12	Bit Width:1
        \ %x  9 lshift RCC_AHBSMENR        \ RCC_SRAMSMEN	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_AHBSMENR        \ RCC_MIFSMEN	Bit Offset:8	Bit Width:1
        \ %x  0 lshift RCC_AHBSMENR        \ RCC_DMASMEN	Bit Offset:0	Bit Width:1
        
        RCC $44 + constant RCC_APB2SMENR	\ read-write		\  : RESET_RCC_APB2SMENR $00405225 
        \ %x  22 lshift RCC_APB2SMENR        \ RCC_DBGSMEN	Bit Offset:22	Bit Width:1
        \ %x  14 lshift RCC_APB2SMENR        \ RCC_USART1SMEN	Bit Offset:14	Bit Width:1
        \ %x  12 lshift RCC_APB2SMENR        \ RCC_SPI1SMEN	Bit Offset:12	Bit Width:1
        \ %x  9 lshift RCC_APB2SMENR        \ RCC_ADCSMEN	Bit Offset:9	Bit Width:1
        \ %x  5 lshift RCC_APB2SMENR        \ RCC_TIM22SMEN	Bit Offset:5	Bit Width:1
        \ %x  2 lshift RCC_APB2SMENR        \ RCC_TIM21SMEN	Bit Offset:2	Bit Width:1
        \ %x  0 lshift RCC_APB2SMENR        \ RCC_SYSCFGSMEN	Bit Offset:0	Bit Width:1
        
        RCC $48 + constant RCC_APB1SMENR	\ read-write		\  : RESET_RCC_APB1SMENR $B8E64A11 
        \ %x  31 lshift RCC_APB1SMENR        \ RCC_LPTIM1SMEN	Bit Offset:31	Bit Width:1
        \ %x  29 lshift RCC_APB1SMENR        \ RCC_DACSMEN	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_APB1SMENR        \ RCC_PWRSMEN	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_APB1SMENR        \ RCC_CRSSMEN	Bit Offset:27	Bit Width:1
        \ %x  23 lshift RCC_APB1SMENR        \ RCC_USBSMEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift RCC_APB1SMENR        \ RCC_I2C2SMEN	Bit Offset:22	Bit Width:1
        \ %x  21 lshift RCC_APB1SMENR        \ RCC_I2C1SMEN	Bit Offset:21	Bit Width:1
        \ %x  18 lshift RCC_APB1SMENR        \ RCC_LPUART1SMEN	Bit Offset:18	Bit Width:1
        \ %x  17 lshift RCC_APB1SMENR        \ RCC_USART2SMEN	Bit Offset:17	Bit Width:1
        \ %x  14 lshift RCC_APB1SMENR        \ RCC_SPI2SMEN	Bit Offset:14	Bit Width:1
        \ %x  11 lshift RCC_APB1SMENR        \ RCC_WWDGSMEN	Bit Offset:11	Bit Width:1
        \ %x  4 lshift RCC_APB1SMENR        \ RCC_TIM6SMEN	Bit Offset:4	Bit Width:1
        \ %x  0 lshift RCC_APB1SMENR        \ RCC_TIM2SMEN	Bit Offset:0	Bit Width:1
        
        RCC $4C + constant RCC_CCIPR	\ read-write		\  : RESET_RCC_CCIPR $00000000 
        \ %x  26 lshift RCC_CCIPR        \ RCC_HSI48MSEL	Bit Offset:26	Bit Width:1
        \ %x  19 lshift RCC_CCIPR        \ RCC_LPTIM1SEL1	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_CCIPR        \ RCC_LPTIM1SEL0	Bit Offset:18	Bit Width:1
        \ %x  13 lshift RCC_CCIPR        \ RCC_I2C1SEL1	Bit Offset:13	Bit Width:1
        \ %x  12 lshift RCC_CCIPR        \ RCC_I2C1SEL0	Bit Offset:12	Bit Width:1
        \ %x  11 lshift RCC_CCIPR        \ RCC_LPUART1SEL1	Bit Offset:11	Bit Width:1
        \ %x  10 lshift RCC_CCIPR        \ RCC_LPUART1SEL0	Bit Offset:10	Bit Width:1
        \ %x  3 lshift RCC_CCIPR        \ RCC_USART2SEL1	Bit Offset:3	Bit Width:1
        \ %x  2 lshift RCC_CCIPR        \ RCC_USART2SEL0	Bit Offset:2	Bit Width:1
        \ %x  1 lshift RCC_CCIPR        \ RCC_USART1SEL1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CCIPR        \ RCC_USART1SEL0	Bit Offset:0	Bit Width:1
        
        RCC $50 + constant RCC_CSR	\ 		\  : RESET_RCC_CSR $0C000000 
        \ %x  31 lshift RCC_CSR        \ RCC_LPWRSTF	Bit Offset:31	Bit Width:1
        \ %x  30 lshift RCC_CSR        \ RCC_WWDGRSTF	Bit Offset:30	Bit Width:1
        \ %x  29 lshift RCC_CSR        \ RCC_IWDGRSTF	Bit Offset:29	Bit Width:1
        \ %x  28 lshift RCC_CSR        \ RCC_SFTRSTF	Bit Offset:28	Bit Width:1
        \ %x  27 lshift RCC_CSR        \ RCC_PORRSTF	Bit Offset:27	Bit Width:1
        \ %x  26 lshift RCC_CSR        \ RCC_PINRSTF	Bit Offset:26	Bit Width:1
        \ %x  25 lshift RCC_CSR        \ RCC_OBLRSTF	Bit Offset:25	Bit Width:1
        \ %x  24 lshift RCC_CSR        \ RCC_RMVF	Bit Offset:24	Bit Width:1
        \ %x  19 lshift RCC_CSR        \ RCC_RTCRST	Bit Offset:19	Bit Width:1
        \ %x  18 lshift RCC_CSR        \ RCC_RTCEN	Bit Offset:18	Bit Width:1
        \ %xx  16 lshift RCC_CSR        \ RCC_RTCSEL	Bit Offset:16	Bit Width:2
        \ %x  14 lshift RCC_CSR        \ RCC_CSSLSED	Bit Offset:14	Bit Width:1
        \ %x  13 lshift RCC_CSR        \ RCC_CSSLSEON	Bit Offset:13	Bit Width:1
        \ %xx  11 lshift RCC_CSR        \ RCC_LSEDRV	Bit Offset:11	Bit Width:2
        \ %x  10 lshift RCC_CSR        \ RCC_LSEBYP	Bit Offset:10	Bit Width:1
        \ %x  9 lshift RCC_CSR        \ RCC_LSERDY	Bit Offset:9	Bit Width:1
        \ %x  8 lshift RCC_CSR        \ RCC_LSEON	Bit Offset:8	Bit Width:1
        \ %x  1 lshift RCC_CSR        \ RCC_LSIRDY	Bit Offset:1	Bit Width:1
        \ %x  0 lshift RCC_CSR        \ RCC_LSION	Bit Offset:0	Bit Width:1
        
         
	
     $40010000 constant SYSCFG  
	 SYSCFG $0 + constant SYSCFG_CFGR1	\ 		\  : RESET_SYSCFG_CFGR1 $00000000 
        \ %xx  8 lshift SYSCFG_CFGR1        \ SYSCFG_BOOT_MODE	Bit Offset:8	Bit Width:2
        \ %xx  0 lshift SYSCFG_CFGR1        \ SYSCFG_MEM_MODE	Bit Offset:0	Bit Width:2
        
        SYSCFG $4 + constant SYSCFG_CFGR2	\ read-write		\  : RESET_SYSCFG_CFGR2 $00000000 
        \ %x  13 lshift SYSCFG_CFGR2        \ SYSCFG_I2C2_FMP	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SYSCFG_CFGR2        \ SYSCFG_I2C1_FMP	Bit Offset:12	Bit Width:1
        \ %x  11 lshift SYSCFG_CFGR2        \ SYSCFG_I2C_PB9_FMP	Bit Offset:11	Bit Width:1
        \ %x  10 lshift SYSCFG_CFGR2        \ SYSCFG_I2C_PB8_FMP	Bit Offset:10	Bit Width:1
        \ %x  9 lshift SYSCFG_CFGR2        \ SYSCFG_I2C_PB7_FMP	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SYSCFG_CFGR2        \ SYSCFG_I2C_PB6_FMP	Bit Offset:8	Bit Width:1
        \ %xxx  1 lshift SYSCFG_CFGR2        \ SYSCFG_CAPA	Bit Offset:1	Bit Width:3
        \ %x  0 lshift SYSCFG_CFGR2        \ SYSCFG_FWDISEN	Bit Offset:0	Bit Width:1
        
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
        
        SYSCFG $20 + constant SYSCFG_CFGR3	\ 		\  : RESET_SYSCFG_CFGR3 $00000000 
        \ %x  31 lshift SYSCFG_CFGR3        \ SYSCFG_REF_LOCK	Bit Offset:31	Bit Width:1
        \ %x  30 lshift SYSCFG_CFGR3        \ SYSCFG_VREFINT_RDYF	Bit Offset:30	Bit Width:1
        \ %x  29 lshift SYSCFG_CFGR3        \ SYSCFG_VREFINT_COMP_RDYF	Bit Offset:29	Bit Width:1
        \ %x  28 lshift SYSCFG_CFGR3        \ SYSCFG_VREFINT_ADC_RDYF	Bit Offset:28	Bit Width:1
        \ %x  27 lshift SYSCFG_CFGR3        \ SYSCFG_SENSOR_ADC_RDYF	Bit Offset:27	Bit Width:1
        \ %x  26 lshift SYSCFG_CFGR3        \ SYSCFG_REF_RC48MHz_RDYF	Bit Offset:26	Bit Width:1
        \ %x  13 lshift SYSCFG_CFGR3        \ SYSCFG_ENREF_RC48MHz	Bit Offset:13	Bit Width:1
        \ %x  12 lshift SYSCFG_CFGR3        \ SYSCFG_ENBUF_VREFINT_COMP	Bit Offset:12	Bit Width:1
        \ %x  9 lshift SYSCFG_CFGR3        \ SYSCFG_ENBUF_SENSOR_ADC	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SYSCFG_CFGR3        \ SYSCFG_ENBUF_BGAP_ADC	Bit Offset:8	Bit Width:1
        \ %xx  4 lshift SYSCFG_CFGR3        \ SYSCFG_SEL_VREF_OUT	Bit Offset:4	Bit Width:2
        \ %x  0 lshift SYSCFG_CFGR3        \ SYSCFG_EN_BGAP	Bit Offset:0	Bit Width:1
        
         
	
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
        \ %x  0 lshift SPI1_CR2        \ SPI1_RXDMAEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift SPI1_CR2        \ SPI1_TXDMAEN	Bit Offset:1	Bit Width:1
        \ %x  2 lshift SPI1_CR2        \ SPI1_SSOE	Bit Offset:2	Bit Width:1
        \ %x  4 lshift SPI1_CR2        \ SPI1_FRF	Bit Offset:4	Bit Width:1
        \ %x  5 lshift SPI1_CR2        \ SPI1_ERRIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift SPI1_CR2        \ SPI1_RXNEIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift SPI1_CR2        \ SPI1_TXEIE	Bit Offset:7	Bit Width:1
        
        SPI1 $8 + constant SPI1_SR	\ 		\  : RESET_SPI1_SR $0002 
        \ %x  0 lshift SPI1_SR        \ SPI1_RXNE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift SPI1_SR        \ SPI1_TXE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift SPI1_SR        \ SPI1_CHSIDE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift SPI1_SR        \ SPI1_UDR	Bit Offset:3	Bit Width:1
        \ %x  4 lshift SPI1_SR        \ SPI1_CRCERR	Bit Offset:4	Bit Width:1
        \ %x  5 lshift SPI1_SR        \ SPI1_MODF	Bit Offset:5	Bit Width:1
        \ %x  6 lshift SPI1_SR        \ SPI1_OVR	Bit Offset:6	Bit Width:1
        \ %x  7 lshift SPI1_SR        \ SPI1_BSY	Bit Offset:7	Bit Width:1
        \ %x  8 lshift SPI1_SR        \ SPI1_TIFRFE	Bit Offset:8	Bit Width:1
        
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
        
        SPI1 $20 + constant SPI1_I2SPR	\ read-write		\  : RESET_SPI1_I2SPR $00000010 
        \ %x  9 lshift SPI1_I2SPR        \ SPI1_MCKOE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift SPI1_I2SPR        \ SPI1_ODD	Bit Offset:8	Bit Width:1
        \ %xxxxxxxx  0 lshift SPI1_I2SPR        \ SPI1_I2SDIV	Bit Offset:0	Bit Width:8
        
         
	
     $40003800 constant SPI2  
	  
	
     $40005400 constant I2C1  
	 I2C1 $0 + constant I2C1_CR1	\ read-write		\  : RESET_I2C1_CR1 $00000000 
        \ %x  0 lshift I2C1_CR1        \ I2C1_PE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift I2C1_CR1        \ I2C1_TXIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift I2C1_CR1        \ I2C1_RXIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift I2C1_CR1        \ I2C1_ADDRIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift I2C1_CR1        \ I2C1_NACKIE	Bit Offset:4	Bit Width:1
        \ %x  5 lshift I2C1_CR1        \ I2C1_STOPIE	Bit Offset:5	Bit Width:1
        \ %x  6 lshift I2C1_CR1        \ I2C1_TCIE	Bit Offset:6	Bit Width:1
        \ %x  7 lshift I2C1_CR1        \ I2C1_ERRIE	Bit Offset:7	Bit Width:1
        \ %xxxx  8 lshift I2C1_CR1        \ I2C1_DNF	Bit Offset:8	Bit Width:4
        \ %x  12 lshift I2C1_CR1        \ I2C1_ANFOFF	Bit Offset:12	Bit Width:1
        \ %x  14 lshift I2C1_CR1        \ I2C1_TXDMAEN	Bit Offset:14	Bit Width:1
        \ %x  15 lshift I2C1_CR1        \ I2C1_RXDMAEN	Bit Offset:15	Bit Width:1
        \ %x  16 lshift I2C1_CR1        \ I2C1_SBC	Bit Offset:16	Bit Width:1
        \ %x  17 lshift I2C1_CR1        \ I2C1_NOSTRETCH	Bit Offset:17	Bit Width:1
        \ %x  18 lshift I2C1_CR1        \ I2C1_WUPEN	Bit Offset:18	Bit Width:1
        \ %x  19 lshift I2C1_CR1        \ I2C1_GCEN	Bit Offset:19	Bit Width:1
        \ %x  20 lshift I2C1_CR1        \ I2C1_SMBHEN	Bit Offset:20	Bit Width:1
        \ %x  21 lshift I2C1_CR1        \ I2C1_SMBDEN	Bit Offset:21	Bit Width:1
        \ %x  22 lshift I2C1_CR1        \ I2C1_ALERTEN	Bit Offset:22	Bit Width:1
        \ %x  23 lshift I2C1_CR1        \ I2C1_PECEN	Bit Offset:23	Bit Width:1
        
        I2C1 $4 + constant I2C1_CR2	\ read-write		\  : RESET_I2C1_CR2 $00000000 
        \ %x  26 lshift I2C1_CR2        \ I2C1_PECBYTE	Bit Offset:26	Bit Width:1
        \ %x  25 lshift I2C1_CR2        \ I2C1_AUTOEND	Bit Offset:25	Bit Width:1
        \ %x  24 lshift I2C1_CR2        \ I2C1_RELOAD	Bit Offset:24	Bit Width:1
        \ %xxxxxxxx  16 lshift I2C1_CR2        \ I2C1_NBYTES	Bit Offset:16	Bit Width:8
        \ %x  15 lshift I2C1_CR2        \ I2C1_NACK	Bit Offset:15	Bit Width:1
        \ %x  14 lshift I2C1_CR2        \ I2C1_STOP	Bit Offset:14	Bit Width:1
        \ %x  13 lshift I2C1_CR2        \ I2C1_START	Bit Offset:13	Bit Width:1
        \ %x  12 lshift I2C1_CR2        \ I2C1_HEAD10R	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C1_CR2        \ I2C1_ADD10	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C1_CR2        \ I2C1_RD_WRN	Bit Offset:10	Bit Width:1
        \ % 0 lshift I2C1_CR2        \ I2C1_SADD	Bit Offset:0	Bit Width:10
        
        I2C1 $8 + constant I2C1_OAR1	\ read-write		\  : RESET_I2C1_OAR1 $00000000 
        \ % 0 lshift I2C1_OAR1        \ I2C1_OA1	Bit Offset:0	Bit Width:10
        \ %x  10 lshift I2C1_OAR1        \ I2C1_OA1MODE	Bit Offset:10	Bit Width:1
        \ %x  15 lshift I2C1_OAR1        \ I2C1_OA1EN	Bit Offset:15	Bit Width:1
        
        I2C1 $C + constant I2C1_OAR2	\ read-write		\  : RESET_I2C1_OAR2 $00000000 
        \ %xxxxxxx  1 lshift I2C1_OAR2        \ I2C1_OA2	Bit Offset:1	Bit Width:7
        \ %xxx  8 lshift I2C1_OAR2        \ I2C1_OA2MSK	Bit Offset:8	Bit Width:3
        \ %x  15 lshift I2C1_OAR2        \ I2C1_OA2EN	Bit Offset:15	Bit Width:1
        
        I2C1 $10 + constant I2C1_TIMINGR	\ read-write		\  : RESET_I2C1_TIMINGR $00000000 
        \ %xxxxxxxx  0 lshift I2C1_TIMINGR        \ I2C1_SCLL	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift I2C1_TIMINGR        \ I2C1_SCLH	Bit Offset:8	Bit Width:8
        \ %xxxx  16 lshift I2C1_TIMINGR        \ I2C1_SDADEL	Bit Offset:16	Bit Width:4
        \ %xxxx  20 lshift I2C1_TIMINGR        \ I2C1_SCLDEL	Bit Offset:20	Bit Width:4
        \ %xxxx  28 lshift I2C1_TIMINGR        \ I2C1_PRESC	Bit Offset:28	Bit Width:4
        
        I2C1 $14 + constant I2C1_TIMEOUTR	\ read-write		\  : RESET_I2C1_TIMEOUTR $00000000 
        \ %xxxxxxxxxxxx  0 lshift I2C1_TIMEOUTR        \ I2C1_TIMEOUTA	Bit Offset:0	Bit Width:12
        \ %x  12 lshift I2C1_TIMEOUTR        \ I2C1_TIDLE	Bit Offset:12	Bit Width:1
        \ %x  15 lshift I2C1_TIMEOUTR        \ I2C1_TIMOUTEN	Bit Offset:15	Bit Width:1
        \ %xxxxxxxxxxxx  16 lshift I2C1_TIMEOUTR        \ I2C1_TIMEOUTB	Bit Offset:16	Bit Width:12
        \ %x  31 lshift I2C1_TIMEOUTR        \ I2C1_TEXTEN	Bit Offset:31	Bit Width:1
        
        I2C1 $18 + constant I2C1_ISR	\ 		\  : RESET_I2C1_ISR $00000001 
        \ %xxxxxxx  17 lshift I2C1_ISR        \ I2C1_ADDCODE	Bit Offset:17	Bit Width:7
        \ %x  16 lshift I2C1_ISR        \ I2C1_DIR	Bit Offset:16	Bit Width:1
        \ %x  15 lshift I2C1_ISR        \ I2C1_BUSY	Bit Offset:15	Bit Width:1
        \ %x  13 lshift I2C1_ISR        \ I2C1_ALERT	Bit Offset:13	Bit Width:1
        \ %x  12 lshift I2C1_ISR        \ I2C1_TIMEOUT	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C1_ISR        \ I2C1_PECERR	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C1_ISR        \ I2C1_OVR	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C1_ISR        \ I2C1_ARLO	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C1_ISR        \ I2C1_BERR	Bit Offset:8	Bit Width:1
        \ %x  7 lshift I2C1_ISR        \ I2C1_TCR	Bit Offset:7	Bit Width:1
        \ %x  6 lshift I2C1_ISR        \ I2C1_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift I2C1_ISR        \ I2C1_STOPF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift I2C1_ISR        \ I2C1_NACKF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift I2C1_ISR        \ I2C1_ADDR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift I2C1_ISR        \ I2C1_RXNE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift I2C1_ISR        \ I2C1_TXIS	Bit Offset:1	Bit Width:1
        \ %x  0 lshift I2C1_ISR        \ I2C1_TXE	Bit Offset:0	Bit Width:1
        
        I2C1 $1C + constant I2C1_ICR	\ write-only		\  : RESET_I2C1_ICR $00000000 
        \ %x  13 lshift I2C1_ICR        \ I2C1_ALERTCF	Bit Offset:13	Bit Width:1
        \ %x  12 lshift I2C1_ICR        \ I2C1_TIMOUTCF	Bit Offset:12	Bit Width:1
        \ %x  11 lshift I2C1_ICR        \ I2C1_PECCF	Bit Offset:11	Bit Width:1
        \ %x  10 lshift I2C1_ICR        \ I2C1_OVRCF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift I2C1_ICR        \ I2C1_ARLOCF	Bit Offset:9	Bit Width:1
        \ %x  8 lshift I2C1_ICR        \ I2C1_BERRCF	Bit Offset:8	Bit Width:1
        \ %x  5 lshift I2C1_ICR        \ I2C1_STOPCF	Bit Offset:5	Bit Width:1
        \ %x  4 lshift I2C1_ICR        \ I2C1_NACKCF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift I2C1_ICR        \ I2C1_ADDRCF	Bit Offset:3	Bit Width:1
        
        I2C1 $20 + constant I2C1_PECR	\ read-only		\  : RESET_I2C1_PECR $00000000 
        \ %xxxxxxxx  0 lshift I2C1_PECR        \ I2C1_PEC	Bit Offset:0	Bit Width:8
        
        I2C1 $24 + constant I2C1_RXDR	\ read-only		\  : RESET_I2C1_RXDR $00000000 
        \ %xxxxxxxx  0 lshift I2C1_RXDR        \ I2C1_RXDATA	Bit Offset:0	Bit Width:8
        
        I2C1 $28 + constant I2C1_TXDR	\ read-write		\  : RESET_I2C1_TXDR $00000000 
        \ %xxxxxxxx  0 lshift I2C1_TXDR        \ I2C1_TXDATA	Bit Offset:0	Bit Width:8
        
         
	
     $40005800 constant I2C2  
	  
	
     $40007000 constant PWR  
	 PWR $0 + constant PWR_CR	\ read-write		\  : RESET_PWR_CR $00001000 
        \ %x  0 lshift PWR_CR        \ PWR_LPDS	Bit Offset:0	Bit Width:1
        \ %x  1 lshift PWR_CR        \ PWR_PDDS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift PWR_CR        \ PWR_CWUF	Bit Offset:2	Bit Width:1
        \ %x  3 lshift PWR_CR        \ PWR_CSBF	Bit Offset:3	Bit Width:1
        \ %x  4 lshift PWR_CR        \ PWR_PVDE	Bit Offset:4	Bit Width:1
        \ %xxx  5 lshift PWR_CR        \ PWR_PLS	Bit Offset:5	Bit Width:3
        \ %x  8 lshift PWR_CR        \ PWR_DBP	Bit Offset:8	Bit Width:1
        \ %x  9 lshift PWR_CR        \ PWR_FPDS	Bit Offset:9	Bit Width:1
        \ %x  10 lshift PWR_CR        \ PWR_FWU	Bit Offset:10	Bit Width:1
        \ %xx  11 lshift PWR_CR        \ PWR_VOS	Bit Offset:11	Bit Width:2
        \ %x  13 lshift PWR_CR        \ PWR_DS_EE_KOFF	Bit Offset:13	Bit Width:1
        \ %x  14 lshift PWR_CR        \ PWR_LPRUN	Bit Offset:14	Bit Width:1
        
        PWR $4 + constant PWR_CSR	\ 		\  : RESET_PWR_CSR $00000000 
        \ %x  9 lshift PWR_CSR        \ PWR_BRE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift PWR_CSR        \ PWR_EWUP	Bit Offset:8	Bit Width:1
        \ %x  3 lshift PWR_CSR        \ PWR_BRR	Bit Offset:3	Bit Width:1
        \ %x  2 lshift PWR_CSR        \ PWR_PVDO	Bit Offset:2	Bit Width:1
        \ %x  1 lshift PWR_CSR        \ PWR_SBF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift PWR_CSR        \ PWR_WUF	Bit Offset:0	Bit Width:1
        \ %x  4 lshift PWR_CSR        \ PWR_VOSF	Bit Offset:4	Bit Width:1
        \ %x  5 lshift PWR_CSR        \ PWR_REGLPF	Bit Offset:5	Bit Width:1
        
         
	
     $40022000 constant Flash  
	 Flash $0 + constant Flash_ACR	\ read-write		\  : RESET_Flash_ACR $00000000 
        \ %x  0 lshift Flash_ACR        \ Flash_LATENCY	Bit Offset:0	Bit Width:1
        \ %x  1 lshift Flash_ACR        \ Flash_PRFTEN	Bit Offset:1	Bit Width:1
        \ %x  3 lshift Flash_ACR        \ Flash_SLEEP_PD	Bit Offset:3	Bit Width:1
        \ %x  4 lshift Flash_ACR        \ Flash_RUN_PD	Bit Offset:4	Bit Width:1
        \ %x  5 lshift Flash_ACR        \ Flash_DESAB_BUF	Bit Offset:5	Bit Width:1
        \ %x  6 lshift Flash_ACR        \ Flash_PRE_READ	Bit Offset:6	Bit Width:1
        
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
        \ %x  14 lshift Flash_SR        \ Flash_RDERR	Bit Offset:14	Bit Width:1
        \ %x  16 lshift Flash_SR        \ Flash_NOTZEROERR	Bit Offset:16	Bit Width:1
        \ %x  17 lshift Flash_SR        \ Flash_FWWERR	Bit Offset:17	Bit Width:1
        
        Flash $1C + constant Flash_OBR	\ read-only		\  : RESET_Flash_OBR $00F80000 
        \ %xxxxxxxx  0 lshift Flash_OBR        \ Flash_RDPRT	Bit Offset:0	Bit Width:8
        \ %xxxx  16 lshift Flash_OBR        \ Flash_BOR_LEV	Bit Offset:16	Bit Width:4
        \ %x  8 lshift Flash_OBR        \ Flash_SPRMOD	Bit Offset:8	Bit Width:1
        
        Flash $20 + constant Flash_WRPR	\ read-write		\  : RESET_Flash_WRPR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift Flash_WRPR        \ Flash_WRP	Bit Offset:0	Bit Width:16
        
         
	
     $40010400 constant EXTI  
	 EXTI $0 + constant EXTI_IMR	\ read-write		\  : RESET_EXTI_IMR $FF840000 
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
        \ %x  19 lshift EXTI_IMR        \ EXTI_MR19	Bit Offset:19	Bit Width:1
        \ %x  21 lshift EXTI_IMR        \ EXTI_MR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_IMR        \ EXTI_MR22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift EXTI_IMR        \ EXTI_MR23	Bit Offset:23	Bit Width:1
        \ %x  25 lshift EXTI_IMR        \ EXTI_MR25	Bit Offset:25	Bit Width:1
        \ %x  27 lshift EXTI_IMR        \ EXTI_MR27	Bit Offset:27	Bit Width:1
        
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
        \ %x  19 lshift EXTI_EMR        \ EXTI_MR19	Bit Offset:19	Bit Width:1
        \ %x  21 lshift EXTI_EMR        \ EXTI_MR21	Bit Offset:21	Bit Width:1
        \ %x  22 lshift EXTI_EMR        \ EXTI_MR22	Bit Offset:22	Bit Width:1
        \ %x  23 lshift EXTI_EMR        \ EXTI_MR23	Bit Offset:23	Bit Width:1
        \ %x  25 lshift EXTI_EMR        \ EXTI_MR25	Bit Offset:25	Bit Width:1
        \ %x  27 lshift EXTI_EMR        \ EXTI_MR27	Bit Offset:27	Bit Width:1
        
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
        \ %x  19 lshift EXTI_RTSR        \ EXTI_TR19	Bit Offset:19	Bit Width:1
        
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
        \ %x  19 lshift EXTI_FTSR        \ EXTI_TR19	Bit Offset:19	Bit Width:1
        
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
        \ %x  19 lshift EXTI_SWIER        \ EXTI_SWIER19	Bit Offset:19	Bit Width:1
        
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
        \ %x  19 lshift EXTI_PR        \ EXTI_PR19	Bit Offset:19	Bit Width:1
        
         
	
     $40012400 constant ADC  
	 ADC $0 + constant ADC_ISR	\ read-write		\  : RESET_ADC_ISR $00000000 
        \ %x  0 lshift ADC_ISR        \ ADC_ADRDY	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ADC_ISR        \ ADC_EOSMP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ADC_ISR        \ ADC_EOC	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ADC_ISR        \ ADC_EOS	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ADC_ISR        \ ADC_OVR	Bit Offset:4	Bit Width:1
        \ %x  7 lshift ADC_ISR        \ ADC_AWD	Bit Offset:7	Bit Width:1
        \ %x  11 lshift ADC_ISR        \ ADC_EOCAL	Bit Offset:11	Bit Width:1
        
        ADC $4 + constant ADC_IER	\ read-write		\  : RESET_ADC_IER $00000000 
        \ %x  0 lshift ADC_IER        \ ADC_ADRDYIE	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ADC_IER        \ ADC_EOSMPIE	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ADC_IER        \ ADC_EOCIE	Bit Offset:2	Bit Width:1
        \ %x  3 lshift ADC_IER        \ ADC_EOSIE	Bit Offset:3	Bit Width:1
        \ %x  4 lshift ADC_IER        \ ADC_OVRIE	Bit Offset:4	Bit Width:1
        \ %x  7 lshift ADC_IER        \ ADC_AWDIE	Bit Offset:7	Bit Width:1
        \ %x  11 lshift ADC_IER        \ ADC_EOCALIE	Bit Offset:11	Bit Width:1
        
        ADC $8 + constant ADC_CR	\ read-write		\  : RESET_ADC_CR $00000000 
        \ %x  0 lshift ADC_CR        \ ADC_ADEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift ADC_CR        \ ADC_ADDIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift ADC_CR        \ ADC_ADSTART	Bit Offset:2	Bit Width:1
        \ %x  4 lshift ADC_CR        \ ADC_ADSTP	Bit Offset:4	Bit Width:1
        \ %x  28 lshift ADC_CR        \ ADC_ADVREGEN	Bit Offset:28	Bit Width:1
        \ %x  31 lshift ADC_CR        \ ADC_ADCAL	Bit Offset:31	Bit Width:1
        
        ADC $C + constant ADC_CFGR1	\ read-write		\  : RESET_ADC_CFGR1 $00000000 
        \ %xxxxx  26 lshift ADC_CFGR1        \ ADC_AWDCH	Bit Offset:26	Bit Width:5
        \ %x  23 lshift ADC_CFGR1        \ ADC_AWDEN	Bit Offset:23	Bit Width:1
        \ %x  22 lshift ADC_CFGR1        \ ADC_AWDSGL	Bit Offset:22	Bit Width:1
        \ %x  16 lshift ADC_CFGR1        \ ADC_DISCEN	Bit Offset:16	Bit Width:1
        \ %x  15 lshift ADC_CFGR1        \ ADC_AUTOFF	Bit Offset:15	Bit Width:1
        \ %x  14 lshift ADC_CFGR1        \ ADC_AUTDLY	Bit Offset:14	Bit Width:1
        \ %x  13 lshift ADC_CFGR1        \ ADC_CONT	Bit Offset:13	Bit Width:1
        \ %x  12 lshift ADC_CFGR1        \ ADC_OVRMOD	Bit Offset:12	Bit Width:1
        \ %xx  10 lshift ADC_CFGR1        \ ADC_EXTEN	Bit Offset:10	Bit Width:2
        \ %xxx  6 lshift ADC_CFGR1        \ ADC_EXTSEL	Bit Offset:6	Bit Width:3
        \ %x  5 lshift ADC_CFGR1        \ ADC_ALIGN	Bit Offset:5	Bit Width:1
        \ %xx  3 lshift ADC_CFGR1        \ ADC_RES	Bit Offset:3	Bit Width:2
        \ %x  2 lshift ADC_CFGR1        \ ADC_SCANDIR	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC_CFGR1        \ ADC_DMACFG	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC_CFGR1        \ ADC_DMAEN	Bit Offset:0	Bit Width:1
        
        ADC $10 + constant ADC_CFGR2	\ read-write		\  : RESET_ADC_CFGR2 $00000000 
        \ %x  0 lshift ADC_CFGR2        \ ADC_OVSE	Bit Offset:0	Bit Width:1
        \ %xxx  2 lshift ADC_CFGR2        \ ADC_OVSR	Bit Offset:2	Bit Width:3
        \ %xxxx  5 lshift ADC_CFGR2        \ ADC_OVSS	Bit Offset:5	Bit Width:4
        \ %x  9 lshift ADC_CFGR2        \ ADC_TOVS	Bit Offset:9	Bit Width:1
        \ %xx  30 lshift ADC_CFGR2        \ ADC_CKMODE	Bit Offset:30	Bit Width:2
        
        ADC $14 + constant ADC_SMPR	\ read-write		\  : RESET_ADC_SMPR $00000000 
        \ %xxx  0 lshift ADC_SMPR        \ ADC_SMPR	Bit Offset:0	Bit Width:3
        
        ADC $20 + constant ADC_TR	\ read-write		\  : RESET_ADC_TR $0FFF0000 
        \ %xxxxxxxxxxxx  16 lshift ADC_TR        \ ADC_HT	Bit Offset:16	Bit Width:12
        \ %xxxxxxxxxxxx  0 lshift ADC_TR        \ ADC_LT	Bit Offset:0	Bit Width:12
        
        ADC $28 + constant ADC_CHSELR	\ read-write		\  : RESET_ADC_CHSELR $00000000 
        \ %x  18 lshift ADC_CHSELR        \ ADC_CHSEL18	Bit Offset:18	Bit Width:1
        \ %x  17 lshift ADC_CHSELR        \ ADC_CHSEL17	Bit Offset:17	Bit Width:1
        \ %x  16 lshift ADC_CHSELR        \ ADC_CHSEL16	Bit Offset:16	Bit Width:1
        \ %x  15 lshift ADC_CHSELR        \ ADC_CHSEL15	Bit Offset:15	Bit Width:1
        \ %x  14 lshift ADC_CHSELR        \ ADC_CHSEL14	Bit Offset:14	Bit Width:1
        \ %x  13 lshift ADC_CHSELR        \ ADC_CHSEL13	Bit Offset:13	Bit Width:1
        \ %x  12 lshift ADC_CHSELR        \ ADC_CHSEL12	Bit Offset:12	Bit Width:1
        \ %x  11 lshift ADC_CHSELR        \ ADC_CHSEL11	Bit Offset:11	Bit Width:1
        \ %x  10 lshift ADC_CHSELR        \ ADC_CHSEL10	Bit Offset:10	Bit Width:1
        \ %x  9 lshift ADC_CHSELR        \ ADC_CHSEL9	Bit Offset:9	Bit Width:1
        \ %x  8 lshift ADC_CHSELR        \ ADC_CHSEL8	Bit Offset:8	Bit Width:1
        \ %x  7 lshift ADC_CHSELR        \ ADC_CHSEL7	Bit Offset:7	Bit Width:1
        \ %x  6 lshift ADC_CHSELR        \ ADC_CHSEL6	Bit Offset:6	Bit Width:1
        \ %x  5 lshift ADC_CHSELR        \ ADC_CHSEL5	Bit Offset:5	Bit Width:1
        \ %x  4 lshift ADC_CHSELR        \ ADC_CHSEL4	Bit Offset:4	Bit Width:1
        \ %x  3 lshift ADC_CHSELR        \ ADC_CHSEL3	Bit Offset:3	Bit Width:1
        \ %x  2 lshift ADC_CHSELR        \ ADC_CHSEL2	Bit Offset:2	Bit Width:1
        \ %x  1 lshift ADC_CHSELR        \ ADC_CHSEL1	Bit Offset:1	Bit Width:1
        \ %x  0 lshift ADC_CHSELR        \ ADC_CHSEL0	Bit Offset:0	Bit Width:1
        
        ADC $40 + constant ADC_DR	\ read-only		\  : RESET_ADC_DR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift ADC_DR        \ ADC_DATA	Bit Offset:0	Bit Width:16
        
        ADC $B4 + constant ADC_CALFACT	\ read-write		\  : RESET_ADC_CALFACT $00000000 
        \ %xxxxxxx  0 lshift ADC_CALFACT        \ ADC_CALFACT	Bit Offset:0	Bit Width:7
        
        ADC $308 + constant ADC_CCR	\ read-write		\  : RESET_ADC_CCR $00000000 
        \ %xxxx  18 lshift ADC_CCR        \ ADC_PRESC	Bit Offset:18	Bit Width:4
        \ %x  22 lshift ADC_CCR        \ ADC_VREFEN	Bit Offset:22	Bit Width:1
        \ %x  23 lshift ADC_CCR        \ ADC_TSEN	Bit Offset:23	Bit Width:1
        \ %x  24 lshift ADC_CCR        \ ADC_VLCDEN	Bit Offset:24	Bit Width:1
        \ %x  25 lshift ADC_CCR        \ ADC_LFMEN	Bit Offset:25	Bit Width:1
        
         
	
     $40015800 constant DBGMCU  
	 DBGMCU $0 + constant DBGMCU_IDCODE	\ read-only		\  : RESET_DBGMCU_IDCODE $0 
        \ %xxxxxxxxxxxx  0 lshift DBGMCU_IDCODE        \ DBGMCU_DEV_ID	Bit Offset:0	Bit Width:12
        \ %xxxxxxxxxxxxxxxx  16 lshift DBGMCU_IDCODE        \ DBGMCU_REV_ID	Bit Offset:16	Bit Width:16
        
        DBGMCU $4 + constant DBGMCU_CR	\ read-write		\  : RESET_DBGMCU_CR $0 
        \ %x  1 lshift DBGMCU_CR        \ DBGMCU_DBG_STOP	Bit Offset:1	Bit Width:1
        \ %x  2 lshift DBGMCU_CR        \ DBGMCU_DBG_STANDBY	Bit Offset:2	Bit Width:1
        \ %x  0 lshift DBGMCU_CR        \ DBGMCU_DBG_SLEEP	Bit Offset:0	Bit Width:1
        
        DBGMCU $8 + constant DBGMCU_APB1_FZ	\ read-write		\  : RESET_DBGMCU_APB1_FZ $0 
        \ %x  0 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_TIMER2_STOP	Bit Offset:0	Bit Width:1
        \ %x  4 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_TIMER6_STOP	Bit Offset:4	Bit Width:1
        \ %x  10 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_RTC_STOP	Bit Offset:10	Bit Width:1
        \ %x  11 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_WWDG_STOP	Bit Offset:11	Bit Width:1
        \ %x  12 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_IWDG_STOP	Bit Offset:12	Bit Width:1
        \ %x  21 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_I2C1_STOP	Bit Offset:21	Bit Width:1
        \ %x  22 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_I2C2_STOP	Bit Offset:22	Bit Width:1
        \ %x  31 lshift DBGMCU_APB1_FZ        \ DBGMCU_DBG_LPTIMER_STOP	Bit Offset:31	Bit Width:1
        
        DBGMCU $C + constant DBGMCU_APB2_FZ	\ read-write		\  : RESET_DBGMCU_APB2_FZ $0 
        \ %x  2 lshift DBGMCU_APB2_FZ        \ DBGMCU_DBG_TIMER21_STOP	Bit Offset:2	Bit Width:1
        \ %x  6 lshift DBGMCU_APB2_FZ        \ DBGMCU_DBG_TIMER22_STO	Bit Offset:6	Bit Width:1
        
         
	
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
        \ %x  13 lshift TIM2_DIER        \ TIM2_COMDE	Bit Offset:13	Bit Width:1
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
        \ %xxx  0 lshift TIM2_OR        \ TIM2_ETR_RMP	Bit Offset:0	Bit Width:3
        \ %xx  3 lshift TIM2_OR        \ TIM2_TI4_RMP	Bit Offset:3	Bit Width:2
        
         
	
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
        
         
	
     $40010800 constant TIM21  
	 TIM21 $0 + constant TIM21_CR1	\ read-write		\  : RESET_TIM21_CR1 $0000 
        \ %x  0 lshift TIM21_CR1        \ TIM21_CEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift TIM21_CR1        \ TIM21_UDIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift TIM21_CR1        \ TIM21_URS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift TIM21_CR1        \ TIM21_OPM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift TIM21_CR1        \ TIM21_DIR	Bit Offset:4	Bit Width:1
        \ %xx  5 lshift TIM21_CR1        \ TIM21_CMS	Bit Offset:5	Bit Width:2
        \ %x  7 lshift TIM21_CR1        \ TIM21_ARPE	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift TIM21_CR1        \ TIM21_CKD	Bit Offset:8	Bit Width:2
        
        TIM21 $4 + constant TIM21_CR2	\ read-write		\  : RESET_TIM21_CR2 $0000 
        \ %xxx  4 lshift TIM21_CR2        \ TIM21_MMS	Bit Offset:4	Bit Width:3
        
        TIM21 $8 + constant TIM21_SMCR	\ read-write		\  : RESET_TIM21_SMCR $0000 
        \ %xxx  0 lshift TIM21_SMCR        \ TIM21_SMS	Bit Offset:0	Bit Width:3
        \ %xxx  4 lshift TIM21_SMCR        \ TIM21_TS	Bit Offset:4	Bit Width:3
        \ %x  7 lshift TIM21_SMCR        \ TIM21_MSM	Bit Offset:7	Bit Width:1
        \ %xxxx  8 lshift TIM21_SMCR        \ TIM21_ETF	Bit Offset:8	Bit Width:4
        \ %xx  12 lshift TIM21_SMCR        \ TIM21_ETPS	Bit Offset:12	Bit Width:2
        \ %x  14 lshift TIM21_SMCR        \ TIM21_ECE	Bit Offset:14	Bit Width:1
        \ %x  15 lshift TIM21_SMCR        \ TIM21_ETP	Bit Offset:15	Bit Width:1
        
        TIM21 $C + constant TIM21_DIER	\ read-write		\  : RESET_TIM21_DIER $0000 
        \ %x  6 lshift TIM21_DIER        \ TIM21_TIE	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM21_DIER        \ TIM21_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM21_DIER        \ TIM21_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM21_DIER        \ TIM21_UIE	Bit Offset:0	Bit Width:1
        
        TIM21 $10 + constant TIM21_SR	\ read-write		\  : RESET_TIM21_SR $0000 
        \ %x  10 lshift TIM21_SR        \ TIM21_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM21_SR        \ TIM21_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM21_SR        \ TIM21_TIF	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM21_SR        \ TIM21_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM21_SR        \ TIM21_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM21_SR        \ TIM21_UIF	Bit Offset:0	Bit Width:1
        
        TIM21 $14 + constant TIM21_EGR	\ write-only		\  : RESET_TIM21_EGR $0000 
        \ %x  6 lshift TIM21_EGR        \ TIM21_TG	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM21_EGR        \ TIM21_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM21_EGR        \ TIM21_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM21_EGR        \ TIM21_UG	Bit Offset:0	Bit Width:1
        
        TIM21 $18 + constant TIM21_CCMR1_Output	\ read-write		\  : RESET_TIM21_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM21_CCMR1_Output        \ TIM21_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM21_CCMR1_Output        \ TIM21_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM21_CCMR1_Output        \ TIM21_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM21_CCMR1_Output        \ TIM21_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM21_CCMR1_Output        \ TIM21_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM21_CCMR1_Output        \ TIM21_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM21_CCMR1_Output        \ TIM21_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM21_CCMR1_Output        \ TIM21_CC1S	Bit Offset:0	Bit Width:2
        
        TIM21 $18 + constant TIM21_CCMR1_Input	\ read-write		\  : RESET_TIM21_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM21_CCMR1_Input        \ TIM21_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM21_CCMR1_Input        \ TIM21_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM21_CCMR1_Input        \ TIM21_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM21_CCMR1_Input        \ TIM21_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM21_CCMR1_Input        \ TIM21_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM21_CCMR1_Input        \ TIM21_CC1S	Bit Offset:0	Bit Width:2
        
        TIM21 $20 + constant TIM21_CCER	\ read-write		\  : RESET_TIM21_CCER $0000 
        \ %x  7 lshift TIM21_CCER        \ TIM21_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM21_CCER        \ TIM21_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM21_CCER        \ TIM21_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM21_CCER        \ TIM21_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM21_CCER        \ TIM21_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM21_CCER        \ TIM21_CC1E	Bit Offset:0	Bit Width:1
        
        TIM21 $24 + constant TIM21_CNT	\ read-write		\  : RESET_TIM21_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM21_CNT        \ TIM21_CNT	Bit Offset:0	Bit Width:16
        
        TIM21 $28 + constant TIM21_PSC	\ read-write		\  : RESET_TIM21_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM21_PSC        \ TIM21_PSC	Bit Offset:0	Bit Width:16
        
        TIM21 $2C + constant TIM21_ARR	\ read-write		\  : RESET_TIM21_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM21_ARR        \ TIM21_ARR	Bit Offset:0	Bit Width:16
        
        TIM21 $34 + constant TIM21_CCR1	\ read-write		\  : RESET_TIM21_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM21_CCR1        \ TIM21_CCR1	Bit Offset:0	Bit Width:16
        
        TIM21 $38 + constant TIM21_CCR2	\ read-write		\  : RESET_TIM21_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM21_CCR2        \ TIM21_CCR2	Bit Offset:0	Bit Width:16
        
        TIM21 $50 + constant TIM21_OR	\ read-write		\  : RESET_TIM21_OR $00000000 
        \ %xx  0 lshift TIM21_OR        \ TIM21_ETR_RMP	Bit Offset:0	Bit Width:2
        \ %xxx  2 lshift TIM21_OR        \ TIM21_TI1_RMP	Bit Offset:2	Bit Width:3
        \ %x  5 lshift TIM21_OR        \ TIM21_TI2_RMP	Bit Offset:5	Bit Width:1
        
         
	
     $40011400 constant TIM22  
	 TIM22 $0 + constant TIM22_CR1	\ read-write		\  : RESET_TIM22_CR1 $0000 
        \ %x  0 lshift TIM22_CR1        \ TIM22_CEN	Bit Offset:0	Bit Width:1
        \ %x  1 lshift TIM22_CR1        \ TIM22_UDIS	Bit Offset:1	Bit Width:1
        \ %x  2 lshift TIM22_CR1        \ TIM22_URS	Bit Offset:2	Bit Width:1
        \ %x  3 lshift TIM22_CR1        \ TIM22_OPM	Bit Offset:3	Bit Width:1
        \ %x  4 lshift TIM22_CR1        \ TIM22_DIR	Bit Offset:4	Bit Width:1
        \ %xx  5 lshift TIM22_CR1        \ TIM22_CMS	Bit Offset:5	Bit Width:2
        \ %x  7 lshift TIM22_CR1        \ TIM22_ARPE	Bit Offset:7	Bit Width:1
        \ %xx  8 lshift TIM22_CR1        \ TIM22_CKD	Bit Offset:8	Bit Width:2
        
        TIM22 $4 + constant TIM22_CR2	\ read-write		\  : RESET_TIM22_CR2 $0000 
        \ %xxx  4 lshift TIM22_CR2        \ TIM22_MMS	Bit Offset:4	Bit Width:3
        
        TIM22 $8 + constant TIM22_SMCR	\ read-write		\  : RESET_TIM22_SMCR $0000 
        \ %xxx  0 lshift TIM22_SMCR        \ TIM22_SMS	Bit Offset:0	Bit Width:3
        \ %xxx  4 lshift TIM22_SMCR        \ TIM22_TS	Bit Offset:4	Bit Width:3
        \ %x  7 lshift TIM22_SMCR        \ TIM22_MSM	Bit Offset:7	Bit Width:1
        \ %xxxx  8 lshift TIM22_SMCR        \ TIM22_ETF	Bit Offset:8	Bit Width:4
        \ %xx  12 lshift TIM22_SMCR        \ TIM22_ETPS	Bit Offset:12	Bit Width:2
        \ %x  14 lshift TIM22_SMCR        \ TIM22_ECE	Bit Offset:14	Bit Width:1
        \ %x  15 lshift TIM22_SMCR        \ TIM22_ETP	Bit Offset:15	Bit Width:1
        
        TIM22 $C + constant TIM22_DIER	\ read-write		\  : RESET_TIM22_DIER $0000 
        \ %x  6 lshift TIM22_DIER        \ TIM22_TIE	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM22_DIER        \ TIM22_CC2IE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM22_DIER        \ TIM22_CC1IE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM22_DIER        \ TIM22_UIE	Bit Offset:0	Bit Width:1
        
        TIM22 $10 + constant TIM22_SR	\ read-write		\  : RESET_TIM22_SR $0000 
        \ %x  10 lshift TIM22_SR        \ TIM22_CC2OF	Bit Offset:10	Bit Width:1
        \ %x  9 lshift TIM22_SR        \ TIM22_CC1OF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift TIM22_SR        \ TIM22_TIF	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM22_SR        \ TIM22_CC2IF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM22_SR        \ TIM22_CC1IF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM22_SR        \ TIM22_UIF	Bit Offset:0	Bit Width:1
        
        TIM22 $14 + constant TIM22_EGR	\ write-only		\  : RESET_TIM22_EGR $0000 
        \ %x  6 lshift TIM22_EGR        \ TIM22_TG	Bit Offset:6	Bit Width:1
        \ %x  2 lshift TIM22_EGR        \ TIM22_CC2G	Bit Offset:2	Bit Width:1
        \ %x  1 lshift TIM22_EGR        \ TIM22_CC1G	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM22_EGR        \ TIM22_UG	Bit Offset:0	Bit Width:1
        
        TIM22 $18 + constant TIM22_CCMR1_Output	\ read-write		\  : RESET_TIM22_CCMR1_Output $00000000 
        \ %xxx  12 lshift TIM22_CCMR1_Output        \ TIM22_OC2M	Bit Offset:12	Bit Width:3
        \ %x  11 lshift TIM22_CCMR1_Output        \ TIM22_OC2PE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift TIM22_CCMR1_Output        \ TIM22_OC2FE	Bit Offset:10	Bit Width:1
        \ %xx  8 lshift TIM22_CCMR1_Output        \ TIM22_CC2S	Bit Offset:8	Bit Width:2
        \ %xxx  4 lshift TIM22_CCMR1_Output        \ TIM22_OC1M	Bit Offset:4	Bit Width:3
        \ %x  3 lshift TIM22_CCMR1_Output        \ TIM22_OC1PE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift TIM22_CCMR1_Output        \ TIM22_OC1FE	Bit Offset:2	Bit Width:1
        \ %xx  0 lshift TIM22_CCMR1_Output        \ TIM22_CC1S	Bit Offset:0	Bit Width:2
        
        TIM22 $18 + constant TIM22_CCMR1_Input	\ read-write		\  : RESET_TIM22_CCMR1_Input $00000000 
        \ %xxxx  12 lshift TIM22_CCMR1_Input        \ TIM22_IC2F	Bit Offset:12	Bit Width:4
        \ %xx  10 lshift TIM22_CCMR1_Input        \ TIM22_IC2PSC	Bit Offset:10	Bit Width:2
        \ %xx  8 lshift TIM22_CCMR1_Input        \ TIM22_CC2S	Bit Offset:8	Bit Width:2
        \ %xxxx  4 lshift TIM22_CCMR1_Input        \ TIM22_IC1F	Bit Offset:4	Bit Width:4
        \ %xx  2 lshift TIM22_CCMR1_Input        \ TIM22_IC1PSC	Bit Offset:2	Bit Width:2
        \ %xx  0 lshift TIM22_CCMR1_Input        \ TIM22_CC1S	Bit Offset:0	Bit Width:2
        
        TIM22 $20 + constant TIM22_CCER	\ read-write		\  : RESET_TIM22_CCER $0000 
        \ %x  7 lshift TIM22_CCER        \ TIM22_CC2NP	Bit Offset:7	Bit Width:1
        \ %x  5 lshift TIM22_CCER        \ TIM22_CC2P	Bit Offset:5	Bit Width:1
        \ %x  4 lshift TIM22_CCER        \ TIM22_CC2E	Bit Offset:4	Bit Width:1
        \ %x  3 lshift TIM22_CCER        \ TIM22_CC1NP	Bit Offset:3	Bit Width:1
        \ %x  1 lshift TIM22_CCER        \ TIM22_CC1P	Bit Offset:1	Bit Width:1
        \ %x  0 lshift TIM22_CCER        \ TIM22_CC1E	Bit Offset:0	Bit Width:1
        
        TIM22 $24 + constant TIM22_CNT	\ read-write		\  : RESET_TIM22_CNT $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM22_CNT        \ TIM22_CNT	Bit Offset:0	Bit Width:16
        
        TIM22 $28 + constant TIM22_PSC	\ read-write		\  : RESET_TIM22_PSC $0000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM22_PSC        \ TIM22_PSC	Bit Offset:0	Bit Width:16
        
        TIM22 $2C + constant TIM22_ARR	\ read-write		\  : RESET_TIM22_ARR $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM22_ARR        \ TIM22_ARR	Bit Offset:0	Bit Width:16
        
        TIM22 $34 + constant TIM22_CCR1	\ read-write		\  : RESET_TIM22_CCR1 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM22_CCR1        \ TIM22_CCR1	Bit Offset:0	Bit Width:16
        
        TIM22 $38 + constant TIM22_CCR2	\ read-write		\  : RESET_TIM22_CCR2 $00000000 
        \ %xxxxxxxxxxxxxxxx  0 lshift TIM22_CCR2        \ TIM22_CCR2	Bit Offset:0	Bit Width:16
        
        TIM22 $50 + constant TIM22_OR	\ read-write		\  : RESET_TIM22_OR $00000000 
        \ %xx  0 lshift TIM22_OR        \ TIM22_ETR_RMP	Bit Offset:0	Bit Width:2
        \ %xx  2 lshift TIM22_OR        \ TIM22_TI1_RMP	Bit Offset:2	Bit Width:2
        
         
	
     $40004800 constant LPUSART1  
	 LPUSART1 $0 + constant LPUSART1_CR1	\ read-write		\  : RESET_LPUSART1_CR1 $0000 
        \ %x  28 lshift LPUSART1_CR1        \ LPUSART1_M1	Bit Offset:28	Bit Width:1
        \ %x  25 lshift LPUSART1_CR1        \ LPUSART1_DEAT4	Bit Offset:25	Bit Width:1
        \ %x  24 lshift LPUSART1_CR1        \ LPUSART1_DEAT3	Bit Offset:24	Bit Width:1
        \ %x  23 lshift LPUSART1_CR1        \ LPUSART1_DEAT2	Bit Offset:23	Bit Width:1
        \ %x  22 lshift LPUSART1_CR1        \ LPUSART1_DEAT1	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LPUSART1_CR1        \ LPUSART1_DEAT0	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LPUSART1_CR1        \ LPUSART1_DEDT4	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LPUSART1_CR1        \ LPUSART1_DEDT3	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LPUSART1_CR1        \ LPUSART1_DEDT2	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LPUSART1_CR1        \ LPUSART1_DEDT1	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LPUSART1_CR1        \ LPUSART1_DEDT0	Bit Offset:16	Bit Width:1
        \ %x  14 lshift LPUSART1_CR1        \ LPUSART1_CMIE	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LPUSART1_CR1        \ LPUSART1_MME	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LPUSART1_CR1        \ LPUSART1_M0	Bit Offset:12	Bit Width:1
        \ %x  11 lshift LPUSART1_CR1        \ LPUSART1_WAKE	Bit Offset:11	Bit Width:1
        \ %x  10 lshift LPUSART1_CR1        \ LPUSART1_PCE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LPUSART1_CR1        \ LPUSART1_PS	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LPUSART1_CR1        \ LPUSART1_PEIE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LPUSART1_CR1        \ LPUSART1_TXEIE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LPUSART1_CR1        \ LPUSART1_TCIE	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LPUSART1_CR1        \ LPUSART1_RXNEIE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LPUSART1_CR1        \ LPUSART1_IDLEIE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LPUSART1_CR1        \ LPUSART1_TE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPUSART1_CR1        \ LPUSART1_RE	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPUSART1_CR1        \ LPUSART1_UESM	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPUSART1_CR1        \ LPUSART1_UE	Bit Offset:0	Bit Width:1
        
        LPUSART1 $4 + constant LPUSART1_CR2	\ read-write		\  : RESET_LPUSART1_CR2 $0000 
        \ %xxxx  28 lshift LPUSART1_CR2        \ LPUSART1_ADD4_7	Bit Offset:28	Bit Width:4
        \ %xxxx  24 lshift LPUSART1_CR2        \ LPUSART1_ADD0_3	Bit Offset:24	Bit Width:4
        \ %x  19 lshift LPUSART1_CR2        \ LPUSART1_MSBFIRST	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LPUSART1_CR2        \ LPUSART1_TAINV	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LPUSART1_CR2        \ LPUSART1_TXINV	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LPUSART1_CR2        \ LPUSART1_RXINV	Bit Offset:16	Bit Width:1
        \ %x  15 lshift LPUSART1_CR2        \ LPUSART1_SWAP	Bit Offset:15	Bit Width:1
        \ %xx  12 lshift LPUSART1_CR2        \ LPUSART1_STOP	Bit Offset:12	Bit Width:2
        \ %x  11 lshift LPUSART1_CR2        \ LPUSART1_CLKEN	Bit Offset:11	Bit Width:1
        \ %x  4 lshift LPUSART1_CR2        \ LPUSART1_ADDM7	Bit Offset:4	Bit Width:1
        
        LPUSART1 $8 + constant LPUSART1_CR3	\ read-write		\  : RESET_LPUSART1_CR3 $0000 
        \ %x  22 lshift LPUSART1_CR3        \ LPUSART1_WUFIE	Bit Offset:22	Bit Width:1
        \ %xx  20 lshift LPUSART1_CR3        \ LPUSART1_WUS	Bit Offset:20	Bit Width:2
        \ %x  15 lshift LPUSART1_CR3        \ LPUSART1_DEP	Bit Offset:15	Bit Width:1
        \ %x  14 lshift LPUSART1_CR3        \ LPUSART1_DEM	Bit Offset:14	Bit Width:1
        \ %x  13 lshift LPUSART1_CR3        \ LPUSART1_DDRE	Bit Offset:13	Bit Width:1
        \ %x  12 lshift LPUSART1_CR3        \ LPUSART1_OVRDIS	Bit Offset:12	Bit Width:1
        \ %x  10 lshift LPUSART1_CR3        \ LPUSART1_CTSIE	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LPUSART1_CR3        \ LPUSART1_CTSE	Bit Offset:9	Bit Width:1
        \ %x  8 lshift LPUSART1_CR3        \ LPUSART1_RTSE	Bit Offset:8	Bit Width:1
        \ %x  7 lshift LPUSART1_CR3        \ LPUSART1_DMAT	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LPUSART1_CR3        \ LPUSART1_DMAR	Bit Offset:6	Bit Width:1
        \ %x  3 lshift LPUSART1_CR3        \ LPUSART1_HDSEL	Bit Offset:3	Bit Width:1
        \ %x  0 lshift LPUSART1_CR3        \ LPUSART1_EIE	Bit Offset:0	Bit Width:1
        
        LPUSART1 $C + constant LPUSART1_BRR	\ read-write		\  : RESET_LPUSART1_BRR $0000 
        \ %xxxxxxxxxxxxxxxxxxxx  0 lshift LPUSART1_BRR        \ LPUSART1_BRR	Bit Offset:0	Bit Width:20
        
        LPUSART1 $18 + constant LPUSART1_RQR	\ write-only		\  : RESET_LPUSART1_RQR $0000 
        \ %x  3 lshift LPUSART1_RQR        \ LPUSART1_RXFRQ	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPUSART1_RQR        \ LPUSART1_MMRQ	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPUSART1_RQR        \ LPUSART1_SBKRQ	Bit Offset:1	Bit Width:1
        
        LPUSART1 $1C + constant LPUSART1_ISR	\ read-only		\  : RESET_LPUSART1_ISR $00C0 
        \ %x  22 lshift LPUSART1_ISR        \ LPUSART1_REACK	Bit Offset:22	Bit Width:1
        \ %x  21 lshift LPUSART1_ISR        \ LPUSART1_TEACK	Bit Offset:21	Bit Width:1
        \ %x  20 lshift LPUSART1_ISR        \ LPUSART1_WUF	Bit Offset:20	Bit Width:1
        \ %x  19 lshift LPUSART1_ISR        \ LPUSART1_RWU	Bit Offset:19	Bit Width:1
        \ %x  18 lshift LPUSART1_ISR        \ LPUSART1_SBKF	Bit Offset:18	Bit Width:1
        \ %x  17 lshift LPUSART1_ISR        \ LPUSART1_CMF	Bit Offset:17	Bit Width:1
        \ %x  16 lshift LPUSART1_ISR        \ LPUSART1_BUSY	Bit Offset:16	Bit Width:1
        \ %x  10 lshift LPUSART1_ISR        \ LPUSART1_CTS	Bit Offset:10	Bit Width:1
        \ %x  9 lshift LPUSART1_ISR        \ LPUSART1_CTSIF	Bit Offset:9	Bit Width:1
        \ %x  7 lshift LPUSART1_ISR        \ LPUSART1_TXE	Bit Offset:7	Bit Width:1
        \ %x  6 lshift LPUSART1_ISR        \ LPUSART1_TC	Bit Offset:6	Bit Width:1
        \ %x  5 lshift LPUSART1_ISR        \ LPUSART1_RXNE	Bit Offset:5	Bit Width:1
        \ %x  4 lshift LPUSART1_ISR        \ LPUSART1_IDLE	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LPUSART1_ISR        \ LPUSART1_ORE	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPUSART1_ISR        \ LPUSART1_NF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPUSART1_ISR        \ LPUSART1_FE	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPUSART1_ISR        \ LPUSART1_PE	Bit Offset:0	Bit Width:1
        
        LPUSART1 $20 + constant LPUSART1_ICR	\ write-only		\  : RESET_LPUSART1_ICR $0000 
        \ %x  20 lshift LPUSART1_ICR        \ LPUSART1_WUCF	Bit Offset:20	Bit Width:1
        \ %x  17 lshift LPUSART1_ICR        \ LPUSART1_CMCF	Bit Offset:17	Bit Width:1
        \ %x  9 lshift LPUSART1_ICR        \ LPUSART1_CTSCF	Bit Offset:9	Bit Width:1
        \ %x  6 lshift LPUSART1_ICR        \ LPUSART1_TCCF	Bit Offset:6	Bit Width:1
        \ %x  4 lshift LPUSART1_ICR        \ LPUSART1_IDLECF	Bit Offset:4	Bit Width:1
        \ %x  3 lshift LPUSART1_ICR        \ LPUSART1_ORECF	Bit Offset:3	Bit Width:1
        \ %x  2 lshift LPUSART1_ICR        \ LPUSART1_NCF	Bit Offset:2	Bit Width:1
        \ %x  1 lshift LPUSART1_ICR        \ LPUSART1_FECF	Bit Offset:1	Bit Width:1
        \ %x  0 lshift LPUSART1_ICR        \ LPUSART1_PECF	Bit Offset:0	Bit Width:1
        
        LPUSART1 $24 + constant LPUSART1_RDR	\ read-only		\  : RESET_LPUSART1_RDR $0000 
        \ %xxxxxxxxx  0 lshift LPUSART1_RDR        \ LPUSART1_RDR	Bit Offset:0	Bit Width:9
        
        LPUSART1 $28 + constant LPUSART1_TDR	\ read-write		\  : RESET_LPUSART1_TDR $0000 
        \ %xxxxxxxxx  0 lshift LPUSART1_TDR        \ LPUSART1_TDR	Bit Offset:0	Bit Width:9
        
         
	
     $E000E100 constant NVIC  
	 NVIC $0 + constant NVIC_ISER	\ read-write		\  : RESET_NVIC_ISER $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISER        \ NVIC_SETENA	Bit Offset:0	Bit Width:32
        
        NVIC $80 + constant NVIC_ICER	\ read-write		\  : RESET_NVIC_ICER $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICER        \ NVIC_CLRENA	Bit Offset:0	Bit Width:32
        
        NVIC $100 + constant NVIC_ISPR	\ read-write		\  : RESET_NVIC_ISPR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ISPR        \ NVIC_SETPEND	Bit Offset:0	Bit Width:32
        
        NVIC $180 + constant NVIC_ICPR	\ read-write		\  : RESET_NVIC_ICPR $00000000 
        \ %xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  0 lshift NVIC_ICPR        \ NVIC_CLRPEND	Bit Offset:0	Bit Width:32
        
        NVIC $300 + constant NVIC_IPR0	\ read-write		\  : RESET_NVIC_IPR0 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR0        \ NVIC_PRI_0	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR0        \ NVIC_PRI_1	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR0        \ NVIC_PRI_2	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR0        \ NVIC_PRI_3	Bit Offset:24	Bit Width:8
        
        NVIC $304 + constant NVIC_IPR1	\ read-write		\  : RESET_NVIC_IPR1 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR1        \ NVIC_PRI_4	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR1        \ NVIC_PRI_5	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR1        \ NVIC_PRI_6	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR1        \ NVIC_PRI_7	Bit Offset:24	Bit Width:8
        
        NVIC $308 + constant NVIC_IPR2	\ read-write		\  : RESET_NVIC_IPR2 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR2        \ NVIC_PRI_8	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR2        \ NVIC_PRI_9	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR2        \ NVIC_PRI_10	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR2        \ NVIC_PRI_11	Bit Offset:24	Bit Width:8
        
        NVIC $30C + constant NVIC_IPR3	\ read-write		\  : RESET_NVIC_IPR3 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR3        \ NVIC_PRI_12	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR3        \ NVIC_PRI_13	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR3        \ NVIC_PRI_14	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR3        \ NVIC_PRI_15	Bit Offset:24	Bit Width:8
        
        NVIC $310 + constant NVIC_IPR4	\ read-write		\  : RESET_NVIC_IPR4 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR4        \ NVIC_PRI_16	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR4        \ NVIC_PRI_17	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR4        \ NVIC_PRI_18	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR4        \ NVIC_PRI_19	Bit Offset:24	Bit Width:8
        
        NVIC $314 + constant NVIC_IPR5	\ read-write		\  : RESET_NVIC_IPR5 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR5        \ NVIC_PRI_20	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR5        \ NVIC_PRI_21	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR5        \ NVIC_PRI_22	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR5        \ NVIC_PRI_23	Bit Offset:24	Bit Width:8
        
        NVIC $318 + constant NVIC_IPR6	\ read-write		\  : RESET_NVIC_IPR6 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR6        \ NVIC_PRI_24	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR6        \ NVIC_PRI_25	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR6        \ NVIC_PRI_26	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR6        \ NVIC_PRI_27	Bit Offset:24	Bit Width:8
        
        NVIC $31C + constant NVIC_IPR7	\ read-write		\  : RESET_NVIC_IPR7 $00000000 
        \ %xxxxxxxx  0 lshift NVIC_IPR7        \ NVIC_PRI_28	Bit Offset:0	Bit Width:8
        \ %xxxxxxxx  8 lshift NVIC_IPR7        \ NVIC_PRI_29	Bit Offset:8	Bit Width:8
        \ %xxxxxxxx  16 lshift NVIC_IPR7        \ NVIC_PRI_30	Bit Offset:16	Bit Width:8
        \ %xxxxxxxx  24 lshift NVIC_IPR7        \ NVIC_PRI_31	Bit Offset:24	Bit Width:8
        
         
	
     