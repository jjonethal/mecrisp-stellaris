\ STM32WBxx_CM4 Register Bitfield Definitions for Mecrisp-Stellaris Forth by Matthias Koch. 
\ bitfield.xsl takes STM32Fxx.svd, config.xml and produces bitfield.fs
\ Written by Terry Porter "terry@tjporter.com.au" 2016 - 2018 and released under the GPL V2.
\ Replace 'bis!' (set bit) with 'bic!' to CLEAR bit, 'bit@' to test bit etc.


\ DMA1-ISR (read-only)
: DMA1-ISR_TEIF7   %1 27 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF7    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF7   %1 26 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF7    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF7   %1 25 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF7    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF7   %1 24 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF7    Channel x global interrupt flag x = 1 ..7
: DMA1-ISR_TEIF6   %1 23 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF6    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF6   %1 22 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF6    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF6   %1 21 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF6    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF6   %1 20 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF6    Channel x global interrupt flag x = 1 ..7
: DMA1-ISR_TEIF5   %1 19 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF5    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF5   %1 18 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF5    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF5   %1 17 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF5    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF5   %1 16 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF5    Channel x global interrupt flag x = 1 ..7
: DMA1-ISR_TEIF4   %1 15 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF4    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF4   %1 14 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF4    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF4   %1 13 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF4    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF4   %1 12 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF4    Channel x global interrupt flag x = 1 ..7
: DMA1-ISR_TEIF3   %1 11 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF3    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF3   %1 10 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF3    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF3   %1 9 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF3    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF3   %1 8 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF3    Channel x global interrupt flag x = 1 ..7
: DMA1-ISR_TEIF2   %1 7 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF2    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF2   %1 6 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF2    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF2   %1 5 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF2    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF2   %1 4 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF2    Channel x global interrupt flag x = 1 ..7
: DMA1-ISR_TEIF1   %1 3 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TEIF1    Channel x transfer error flag x = 1 ..7
: DMA1-ISR_HTIF1   %1 2 lshift DMA1-ISR bis! ;  \ DMA1-ISR_HTIF1    Channel x half transfer flag x = 1 ..7
: DMA1-ISR_TCIF1   %1 1 lshift DMA1-ISR bis! ;  \ DMA1-ISR_TCIF1    Channel x transfer complete flag x = 1 ..7
: DMA1-ISR_GIF1   %1 0 lshift DMA1-ISR bis! ;  \ DMA1-ISR_GIF1    Channel x global interrupt flag x = 1 ..7

\ DMA1-IFCR (write-only)
: DMA1-IFCR_CTEIF7   %1 27 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF7    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF7   %1 26 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF7    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF7   %1 25 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF7    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF7   %1 24 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF7    Channel x global interrupt clear x = 1 ..7
: DMA1-IFCR_CTEIF6   %1 23 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF6    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF6   %1 22 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF6    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF6   %1 21 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF6    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF6   %1 20 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF6    Channel x global interrupt clear x = 1 ..7
: DMA1-IFCR_CTEIF5   %1 19 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF5    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF5   %1 18 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF5    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF5   %1 17 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF5    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF5   %1 16 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF5    Channel x global interrupt clear x = 1 ..7
: DMA1-IFCR_CTEIF4   %1 15 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF4    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF4   %1 14 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF4    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF4   %1 13 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF4    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF4   %1 12 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF4    Channel x global interrupt clear x = 1 ..7
: DMA1-IFCR_CTEIF3   %1 11 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF3    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF3   %1 10 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF3    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF3   %1 9 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF3    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF3   %1 8 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF3    Channel x global interrupt clear x = 1 ..7
: DMA1-IFCR_CTEIF2   %1 7 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF2    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF2   %1 6 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF2    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF2   %1 5 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF2    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF2   %1 4 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF2    Channel x global interrupt clear x = 1 ..7
: DMA1-IFCR_CTEIF1   %1 3 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTEIF1    Channel x transfer error clear x = 1 ..7
: DMA1-IFCR_CHTIF1   %1 2 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CHTIF1    Channel x half transfer clear x = 1 ..7
: DMA1-IFCR_CTCIF1   %1 1 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CTCIF1    Channel x transfer complete clear x = 1 ..7
: DMA1-IFCR_CGIF1   %1 0 lshift DMA1-IFCR bis! ;  \ DMA1-IFCR_CGIF1    Channel x global interrupt clear x = 1 ..7

\ DMA1-CCR1 (read-write)
: DMA1-CCR1_MEM2MEM   %1 14 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_MEM2MEM    Memory to memory mode
: DMA1-CCR1_PL   ( %XX -- ) 12 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_PL    Channel priority level
: DMA1-CCR1_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_MSIZE    Memory size
: DMA1-CCR1_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_PSIZE    Peripheral size
: DMA1-CCR1_MINC   %1 7 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_MINC    Memory increment mode
: DMA1-CCR1_PINC   %1 6 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_PINC    Peripheral increment mode
: DMA1-CCR1_CIRC   %1 5 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_CIRC    Circular mode
: DMA1-CCR1_DIR   %1 4 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_DIR    Data transfer direction
: DMA1-CCR1_TEIE   %1 3 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_TEIE    Transfer error interrupt enable
: DMA1-CCR1_HTIE   %1 2 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_HTIE    Half transfer interrupt enable
: DMA1-CCR1_TCIE   %1 1 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_TCIE    Transfer complete interrupt enable
: DMA1-CCR1_EN   %1 0 lshift DMA1-CCR1 bis! ;  \ DMA1-CCR1_EN    Channel enable

\ DMA1-CNDTR1 (read-write)
: DMA1-CNDTR1_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR1 bis! ;  \ DMA1-CNDTR1_NDT    Number of data to transfer

\ DMA1-CPAR1 (read-write)
: DMA1-CPAR1_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR1 bis! ;  \ DMA1-CPAR1_PA    Peripheral address

\ DMA1-CMAR1 (read-write)
: DMA1-CMAR1_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR1 bis! ;  \ DMA1-CMAR1_MA    Memory address

\ DMA1-CCR2 (read-write)
: DMA1-CCR2_MEM2MEM   %1 14 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_MEM2MEM    Memory to memory mode
: DMA1-CCR2_PL   ( %XX -- ) 12 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_PL    Channel priority level
: DMA1-CCR2_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_MSIZE    Memory size
: DMA1-CCR2_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_PSIZE    Peripheral size
: DMA1-CCR2_MINC   %1 7 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_MINC    Memory increment mode
: DMA1-CCR2_PINC   %1 6 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_PINC    Peripheral increment mode
: DMA1-CCR2_CIRC   %1 5 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_CIRC    Circular mode
: DMA1-CCR2_DIR   %1 4 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_DIR    Data transfer direction
: DMA1-CCR2_TEIE   %1 3 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_TEIE    Transfer error interrupt enable
: DMA1-CCR2_HTIE   %1 2 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_HTIE    Half transfer interrupt enable
: DMA1-CCR2_TCIE   %1 1 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_TCIE    Transfer complete interrupt enable
: DMA1-CCR2_EN   %1 0 lshift DMA1-CCR2 bis! ;  \ DMA1-CCR2_EN    Channel enable

\ DMA1-CNDTR2 (read-write)
: DMA1-CNDTR2_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR2 bis! ;  \ DMA1-CNDTR2_NDT    Number of data to transfer

\ DMA1-CPAR2 (read-write)
: DMA1-CPAR2_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR2 bis! ;  \ DMA1-CPAR2_PA    Peripheral address

\ DMA1-CMAR2 (read-write)
: DMA1-CMAR2_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR2 bis! ;  \ DMA1-CMAR2_MA    Memory address

\ DMA1-CCR3 (read-write)
: DMA1-CCR3_MEM2MEM   %1 14 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_MEM2MEM    Memory to memory mode
: DMA1-CCR3_PL   ( %XX -- ) 12 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_PL    Channel priority level
: DMA1-CCR3_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_MSIZE    Memory size
: DMA1-CCR3_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_PSIZE    Peripheral size
: DMA1-CCR3_MINC   %1 7 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_MINC    Memory increment mode
: DMA1-CCR3_PINC   %1 6 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_PINC    Peripheral increment mode
: DMA1-CCR3_CIRC   %1 5 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_CIRC    Circular mode
: DMA1-CCR3_DIR   %1 4 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_DIR    Data transfer direction
: DMA1-CCR3_TEIE   %1 3 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_TEIE    Transfer error interrupt enable
: DMA1-CCR3_HTIE   %1 2 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_HTIE    Half transfer interrupt enable
: DMA1-CCR3_TCIE   %1 1 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_TCIE    Transfer complete interrupt enable
: DMA1-CCR3_EN   %1 0 lshift DMA1-CCR3 bis! ;  \ DMA1-CCR3_EN    Channel enable

\ DMA1-CNDTR3 (read-write)
: DMA1-CNDTR3_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR3 bis! ;  \ DMA1-CNDTR3_NDT    Number of data to transfer

\ DMA1-CPAR3 (read-write)
: DMA1-CPAR3_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR3 bis! ;  \ DMA1-CPAR3_PA    Peripheral address

\ DMA1-CMAR3 (read-write)
: DMA1-CMAR3_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR3 bis! ;  \ DMA1-CMAR3_MA    Memory address

\ DMA1-CCR4 (read-write)
: DMA1-CCR4_MEM2MEM   %1 14 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_MEM2MEM    Memory to memory mode
: DMA1-CCR4_PL   ( %XX -- ) 12 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_PL    Channel priority level
: DMA1-CCR4_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_MSIZE    Memory size
: DMA1-CCR4_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_PSIZE    Peripheral size
: DMA1-CCR4_MINC   %1 7 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_MINC    Memory increment mode
: DMA1-CCR4_PINC   %1 6 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_PINC    Peripheral increment mode
: DMA1-CCR4_CIRC   %1 5 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_CIRC    Circular mode
: DMA1-CCR4_DIR   %1 4 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_DIR    Data transfer direction
: DMA1-CCR4_TEIE   %1 3 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_TEIE    Transfer error interrupt enable
: DMA1-CCR4_HTIE   %1 2 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_HTIE    Half transfer interrupt enable
: DMA1-CCR4_TCIE   %1 1 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_TCIE    Transfer complete interrupt enable
: DMA1-CCR4_EN   %1 0 lshift DMA1-CCR4 bis! ;  \ DMA1-CCR4_EN    Channel enable

\ DMA1-CNDTR4 (read-write)
: DMA1-CNDTR4_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR4 bis! ;  \ DMA1-CNDTR4_NDT    Number of data to transfer

\ DMA1-CPAR4 (read-write)
: DMA1-CPAR4_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR4 bis! ;  \ DMA1-CPAR4_PA    Peripheral address

\ DMA1-CMAR4 (read-write)
: DMA1-CMAR4_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR4 bis! ;  \ DMA1-CMAR4_MA    Memory address

\ DMA1-CCR5 (read-write)
: DMA1-CCR5_MEM2MEM   %1 14 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_MEM2MEM    Memory to memory mode
: DMA1-CCR5_PL   ( %XX -- ) 12 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_PL    Channel priority level
: DMA1-CCR5_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_MSIZE    Memory size
: DMA1-CCR5_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_PSIZE    Peripheral size
: DMA1-CCR5_MINC   %1 7 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_MINC    Memory increment mode
: DMA1-CCR5_PINC   %1 6 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_PINC    Peripheral increment mode
: DMA1-CCR5_CIRC   %1 5 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_CIRC    Circular mode
: DMA1-CCR5_DIR   %1 4 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_DIR    Data transfer direction
: DMA1-CCR5_TEIE   %1 3 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_TEIE    Transfer error interrupt enable
: DMA1-CCR5_HTIE   %1 2 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_HTIE    Half transfer interrupt enable
: DMA1-CCR5_TCIE   %1 1 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_TCIE    Transfer complete interrupt enable
: DMA1-CCR5_EN   %1 0 lshift DMA1-CCR5 bis! ;  \ DMA1-CCR5_EN    Channel enable

\ DMA1-CNDTR5 (read-write)
: DMA1-CNDTR5_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR5 bis! ;  \ DMA1-CNDTR5_NDT    Number of data to transfer

\ DMA1-CPAR5 (read-write)
: DMA1-CPAR5_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR5 bis! ;  \ DMA1-CPAR5_PA    Peripheral address

\ DMA1-CMAR5 (read-write)
: DMA1-CMAR5_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR5 bis! ;  \ DMA1-CMAR5_MA    Memory address

\ DMA1-CCR6 (read-write)
: DMA1-CCR6_MEM2MEM   %1 14 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_MEM2MEM    Memory to memory mode
: DMA1-CCR6_PL   ( %XX -- ) 12 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_PL    Channel priority level
: DMA1-CCR6_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_MSIZE    Memory size
: DMA1-CCR6_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_PSIZE    Peripheral size
: DMA1-CCR6_MINC   %1 7 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_MINC    Memory increment mode
: DMA1-CCR6_PINC   %1 6 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_PINC    Peripheral increment mode
: DMA1-CCR6_CIRC   %1 5 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_CIRC    Circular mode
: DMA1-CCR6_DIR   %1 4 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_DIR    Data transfer direction
: DMA1-CCR6_TEIE   %1 3 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_TEIE    Transfer error interrupt enable
: DMA1-CCR6_HTIE   %1 2 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_HTIE    Half transfer interrupt enable
: DMA1-CCR6_TCIE   %1 1 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_TCIE    Transfer complete interrupt enable
: DMA1-CCR6_EN   %1 0 lshift DMA1-CCR6 bis! ;  \ DMA1-CCR6_EN    Channel enable

\ DMA1-CNDTR6 (read-write)
: DMA1-CNDTR6_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR6 bis! ;  \ DMA1-CNDTR6_NDT    Number of data to transfer

\ DMA1-CPAR6 (read-write)
: DMA1-CPAR6_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR6 bis! ;  \ DMA1-CPAR6_PA    Peripheral address

\ DMA1-CMAR6 (read-write)
: DMA1-CMAR6_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR6 bis! ;  \ DMA1-CMAR6_MA    Memory address

\ DMA1-CCR7 (read-write)
: DMA1-CCR7_MEM2MEM   %1 14 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_MEM2MEM    Memory to memory mode
: DMA1-CCR7_PL   ( %XX -- ) 12 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_PL    Channel priority level
: DMA1-CCR7_MSIZE   ( %XX -- ) 10 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_MSIZE    Memory size
: DMA1-CCR7_PSIZE   ( %XX -- ) 8 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_PSIZE    Peripheral size
: DMA1-CCR7_MINC   %1 7 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_MINC    Memory increment mode
: DMA1-CCR7_PINC   %1 6 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_PINC    Peripheral increment mode
: DMA1-CCR7_CIRC   %1 5 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_CIRC    Circular mode
: DMA1-CCR7_DIR   %1 4 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_DIR    Data transfer direction
: DMA1-CCR7_TEIE   %1 3 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_TEIE    Transfer error interrupt enable
: DMA1-CCR7_HTIE   %1 2 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_HTIE    Half transfer interrupt enable
: DMA1-CCR7_TCIE   %1 1 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_TCIE    Transfer complete interrupt enable
: DMA1-CCR7_EN   %1 0 lshift DMA1-CCR7 bis! ;  \ DMA1-CCR7_EN    Channel enable

\ DMA1-CNDTR7 (read-write)
: DMA1-CNDTR7_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CNDTR7 bis! ;  \ DMA1-CNDTR7_NDT    Number of data to transfer

\ DMA1-CPAR7 (read-write)
: DMA1-CPAR7_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CPAR7 bis! ;  \ DMA1-CPAR7_PA    Peripheral address

\ DMA1-CMAR7 (read-write)
: DMA1-CMAR7_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA1-CMAR7 bis! ;  \ DMA1-CMAR7_MA    Memory address

\ DMA2-ISR (read-only)
: DMA2-ISR_TEIF7   %1 27 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF7    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF7   %1 26 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF7    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF7   %1 25 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF7    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF7   %1 24 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF7    Channel x global interrupt flag x = 1 ..7
: DMA2-ISR_TEIF6   %1 23 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF6    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF6   %1 22 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF6    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF6   %1 21 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF6    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF6   %1 20 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF6    Channel x global interrupt flag x = 1 ..7
: DMA2-ISR_TEIF5   %1 19 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF5    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF5   %1 18 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF5    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF5   %1 17 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF5    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF5   %1 16 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF5    Channel x global interrupt flag x = 1 ..7
: DMA2-ISR_TEIF4   %1 15 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF4    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF4   %1 14 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF4    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF4   %1 13 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF4    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF4   %1 12 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF4    Channel x global interrupt flag x = 1 ..7
: DMA2-ISR_TEIF3   %1 11 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF3    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF3   %1 10 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF3    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF3   %1 9 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF3    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF3   %1 8 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF3    Channel x global interrupt flag x = 1 ..7
: DMA2-ISR_TEIF2   %1 7 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF2    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF2   %1 6 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF2    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF2   %1 5 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF2    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF2   %1 4 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF2    Channel x global interrupt flag x = 1 ..7
: DMA2-ISR_TEIF1   %1 3 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TEIF1    Channel x transfer error flag x = 1 ..7
: DMA2-ISR_HTIF1   %1 2 lshift DMA2-ISR bis! ;  \ DMA2-ISR_HTIF1    Channel x half transfer flag x = 1 ..7
: DMA2-ISR_TCIF1   %1 1 lshift DMA2-ISR bis! ;  \ DMA2-ISR_TCIF1    Channel x transfer complete flag x = 1 ..7
: DMA2-ISR_GIF1   %1 0 lshift DMA2-ISR bis! ;  \ DMA2-ISR_GIF1    Channel x global interrupt flag x = 1 ..7

\ DMA2-IFCR (write-only)
: DMA2-IFCR_CTEIF7   %1 27 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF7    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF7   %1 26 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF7    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF7   %1 25 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF7    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF7   %1 24 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF7    Channel x global interrupt clear x = 1 ..7
: DMA2-IFCR_CTEIF6   %1 23 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF6    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF6   %1 22 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF6    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF6   %1 21 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF6    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF6   %1 20 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF6    Channel x global interrupt clear x = 1 ..7
: DMA2-IFCR_CTEIF5   %1 19 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF5    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF5   %1 18 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF5    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF5   %1 17 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF5    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF5   %1 16 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF5    Channel x global interrupt clear x = 1 ..7
: DMA2-IFCR_CTEIF4   %1 15 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF4    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF4   %1 14 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF4    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF4   %1 13 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF4    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF4   %1 12 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF4    Channel x global interrupt clear x = 1 ..7
: DMA2-IFCR_CTEIF3   %1 11 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF3    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF3   %1 10 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF3    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF3   %1 9 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF3    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF3   %1 8 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF3    Channel x global interrupt clear x = 1 ..7
: DMA2-IFCR_CTEIF2   %1 7 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF2    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF2   %1 6 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF2    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF2   %1 5 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF2    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF2   %1 4 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF2    Channel x global interrupt clear x = 1 ..7
: DMA2-IFCR_CTEIF1   %1 3 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTEIF1    Channel x transfer error clear x = 1 ..7
: DMA2-IFCR_CHTIF1   %1 2 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CHTIF1    Channel x half transfer clear x = 1 ..7
: DMA2-IFCR_CTCIF1   %1 1 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CTCIF1    Channel x transfer complete clear x = 1 ..7
: DMA2-IFCR_CGIF1   %1 0 lshift DMA2-IFCR bis! ;  \ DMA2-IFCR_CGIF1    Channel x global interrupt clear x = 1 ..7

\ DMA2-CCR1 (read-write)
: DMA2-CCR1_MEM2MEM   %1 14 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_MEM2MEM    Memory to memory mode
: DMA2-CCR1_PL   ( %XX -- ) 12 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_PL    Channel priority level
: DMA2-CCR1_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_MSIZE    Memory size
: DMA2-CCR1_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_PSIZE    Peripheral size
: DMA2-CCR1_MINC   %1 7 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_MINC    Memory increment mode
: DMA2-CCR1_PINC   %1 6 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_PINC    Peripheral increment mode
: DMA2-CCR1_CIRC   %1 5 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_CIRC    Circular mode
: DMA2-CCR1_DIR   %1 4 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_DIR    Data transfer direction
: DMA2-CCR1_TEIE   %1 3 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_TEIE    Transfer error interrupt enable
: DMA2-CCR1_HTIE   %1 2 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_HTIE    Half transfer interrupt enable
: DMA2-CCR1_TCIE   %1 1 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_TCIE    Transfer complete interrupt enable
: DMA2-CCR1_EN   %1 0 lshift DMA2-CCR1 bis! ;  \ DMA2-CCR1_EN    Channel enable

\ DMA2-CNDTR1 (read-write)
: DMA2-CNDTR1_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR1 bis! ;  \ DMA2-CNDTR1_NDT    Number of data to transfer

\ DMA2-CPAR1 (read-write)
: DMA2-CPAR1_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR1 bis! ;  \ DMA2-CPAR1_PA    Peripheral address

\ DMA2-CMAR1 (read-write)
: DMA2-CMAR1_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR1 bis! ;  \ DMA2-CMAR1_MA    Memory address

\ DMA2-CCR2 (read-write)
: DMA2-CCR2_MEM2MEM   %1 14 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_MEM2MEM    Memory to memory mode
: DMA2-CCR2_PL   ( %XX -- ) 12 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_PL    Channel priority level
: DMA2-CCR2_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_MSIZE    Memory size
: DMA2-CCR2_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_PSIZE    Peripheral size
: DMA2-CCR2_MINC   %1 7 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_MINC    Memory increment mode
: DMA2-CCR2_PINC   %1 6 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_PINC    Peripheral increment mode
: DMA2-CCR2_CIRC   %1 5 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_CIRC    Circular mode
: DMA2-CCR2_DIR   %1 4 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_DIR    Data transfer direction
: DMA2-CCR2_TEIE   %1 3 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_TEIE    Transfer error interrupt enable
: DMA2-CCR2_HTIE   %1 2 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_HTIE    Half transfer interrupt enable
: DMA2-CCR2_TCIE   %1 1 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_TCIE    Transfer complete interrupt enable
: DMA2-CCR2_EN   %1 0 lshift DMA2-CCR2 bis! ;  \ DMA2-CCR2_EN    Channel enable

\ DMA2-CNDTR2 (read-write)
: DMA2-CNDTR2_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR2 bis! ;  \ DMA2-CNDTR2_NDT    Number of data to transfer

\ DMA2-CPAR2 (read-write)
: DMA2-CPAR2_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR2 bis! ;  \ DMA2-CPAR2_PA    Peripheral address

\ DMA2-CMAR2 (read-write)
: DMA2-CMAR2_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR2 bis! ;  \ DMA2-CMAR2_MA    Memory address

\ DMA2-CCR3 (read-write)
: DMA2-CCR3_MEM2MEM   %1 14 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_MEM2MEM    Memory to memory mode
: DMA2-CCR3_PL   ( %XX -- ) 12 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_PL    Channel priority level
: DMA2-CCR3_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_MSIZE    Memory size
: DMA2-CCR3_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_PSIZE    Peripheral size
: DMA2-CCR3_MINC   %1 7 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_MINC    Memory increment mode
: DMA2-CCR3_PINC   %1 6 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_PINC    Peripheral increment mode
: DMA2-CCR3_CIRC   %1 5 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_CIRC    Circular mode
: DMA2-CCR3_DIR   %1 4 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_DIR    Data transfer direction
: DMA2-CCR3_TEIE   %1 3 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_TEIE    Transfer error interrupt enable
: DMA2-CCR3_HTIE   %1 2 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_HTIE    Half transfer interrupt enable
: DMA2-CCR3_TCIE   %1 1 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_TCIE    Transfer complete interrupt enable
: DMA2-CCR3_EN   %1 0 lshift DMA2-CCR3 bis! ;  \ DMA2-CCR3_EN    Channel enable

\ DMA2-CNDTR3 (read-write)
: DMA2-CNDTR3_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR3 bis! ;  \ DMA2-CNDTR3_NDT    Number of data to transfer

\ DMA2-CPAR3 (read-write)
: DMA2-CPAR3_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR3 bis! ;  \ DMA2-CPAR3_PA    Peripheral address

\ DMA2-CMAR3 (read-write)
: DMA2-CMAR3_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR3 bis! ;  \ DMA2-CMAR3_MA    Memory address

\ DMA2-CCR4 (read-write)
: DMA2-CCR4_MEM2MEM   %1 14 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_MEM2MEM    Memory to memory mode
: DMA2-CCR4_PL   ( %XX -- ) 12 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_PL    Channel priority level
: DMA2-CCR4_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_MSIZE    Memory size
: DMA2-CCR4_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_PSIZE    Peripheral size
: DMA2-CCR4_MINC   %1 7 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_MINC    Memory increment mode
: DMA2-CCR4_PINC   %1 6 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_PINC    Peripheral increment mode
: DMA2-CCR4_CIRC   %1 5 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_CIRC    Circular mode
: DMA2-CCR4_DIR   %1 4 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_DIR    Data transfer direction
: DMA2-CCR4_TEIE   %1 3 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_TEIE    Transfer error interrupt enable
: DMA2-CCR4_HTIE   %1 2 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_HTIE    Half transfer interrupt enable
: DMA2-CCR4_TCIE   %1 1 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_TCIE    Transfer complete interrupt enable
: DMA2-CCR4_EN   %1 0 lshift DMA2-CCR4 bis! ;  \ DMA2-CCR4_EN    Channel enable

\ DMA2-CNDTR4 (read-write)
: DMA2-CNDTR4_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR4 bis! ;  \ DMA2-CNDTR4_NDT    Number of data to transfer

\ DMA2-CPAR4 (read-write)
: DMA2-CPAR4_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR4 bis! ;  \ DMA2-CPAR4_PA    Peripheral address

\ DMA2-CMAR4 (read-write)
: DMA2-CMAR4_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR4 bis! ;  \ DMA2-CMAR4_MA    Memory address

\ DMA2-CCR5 (read-write)
: DMA2-CCR5_MEM2MEM   %1 14 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_MEM2MEM    Memory to memory mode
: DMA2-CCR5_PL   ( %XX -- ) 12 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_PL    Channel priority level
: DMA2-CCR5_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_MSIZE    Memory size
: DMA2-CCR5_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_PSIZE    Peripheral size
: DMA2-CCR5_MINC   %1 7 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_MINC    Memory increment mode
: DMA2-CCR5_PINC   %1 6 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_PINC    Peripheral increment mode
: DMA2-CCR5_CIRC   %1 5 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_CIRC    Circular mode
: DMA2-CCR5_DIR   %1 4 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_DIR    Data transfer direction
: DMA2-CCR5_TEIE   %1 3 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_TEIE    Transfer error interrupt enable
: DMA2-CCR5_HTIE   %1 2 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_HTIE    Half transfer interrupt enable
: DMA2-CCR5_TCIE   %1 1 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_TCIE    Transfer complete interrupt enable
: DMA2-CCR5_EN   %1 0 lshift DMA2-CCR5 bis! ;  \ DMA2-CCR5_EN    Channel enable

\ DMA2-CNDTR5 (read-write)
: DMA2-CNDTR5_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR5 bis! ;  \ DMA2-CNDTR5_NDT    Number of data to transfer

\ DMA2-CPAR5 (read-write)
: DMA2-CPAR5_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR5 bis! ;  \ DMA2-CPAR5_PA    Peripheral address

\ DMA2-CMAR5 (read-write)
: DMA2-CMAR5_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR5 bis! ;  \ DMA2-CMAR5_MA    Memory address

\ DMA2-CCR6 (read-write)
: DMA2-CCR6_MEM2MEM   %1 14 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_MEM2MEM    Memory to memory mode
: DMA2-CCR6_PL   ( %XX -- ) 12 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_PL    Channel priority level
: DMA2-CCR6_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_MSIZE    Memory size
: DMA2-CCR6_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_PSIZE    Peripheral size
: DMA2-CCR6_MINC   %1 7 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_MINC    Memory increment mode
: DMA2-CCR6_PINC   %1 6 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_PINC    Peripheral increment mode
: DMA2-CCR6_CIRC   %1 5 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_CIRC    Circular mode
: DMA2-CCR6_DIR   %1 4 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_DIR    Data transfer direction
: DMA2-CCR6_TEIE   %1 3 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_TEIE    Transfer error interrupt enable
: DMA2-CCR6_HTIE   %1 2 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_HTIE    Half transfer interrupt enable
: DMA2-CCR6_TCIE   %1 1 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_TCIE    Transfer complete interrupt enable
: DMA2-CCR6_EN   %1 0 lshift DMA2-CCR6 bis! ;  \ DMA2-CCR6_EN    Channel enable

\ DMA2-CNDTR6 (read-write)
: DMA2-CNDTR6_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR6 bis! ;  \ DMA2-CNDTR6_NDT    Number of data to transfer

\ DMA2-CPAR6 (read-write)
: DMA2-CPAR6_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR6 bis! ;  \ DMA2-CPAR6_PA    Peripheral address

\ DMA2-CMAR6 (read-write)
: DMA2-CMAR6_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR6 bis! ;  \ DMA2-CMAR6_MA    Memory address

\ DMA2-CCR7 (read-write)
: DMA2-CCR7_MEM2MEM   %1 14 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_MEM2MEM    Memory to memory mode
: DMA2-CCR7_PL   ( %XX -- ) 12 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_PL    Channel priority level
: DMA2-CCR7_MSIZE   ( %XX -- ) 10 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_MSIZE    Memory size
: DMA2-CCR7_PSIZE   ( %XX -- ) 8 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_PSIZE    Peripheral size
: DMA2-CCR7_MINC   %1 7 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_MINC    Memory increment mode
: DMA2-CCR7_PINC   %1 6 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_PINC    Peripheral increment mode
: DMA2-CCR7_CIRC   %1 5 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_CIRC    Circular mode
: DMA2-CCR7_DIR   %1 4 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_DIR    Data transfer direction
: DMA2-CCR7_TEIE   %1 3 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_TEIE    Transfer error interrupt enable
: DMA2-CCR7_HTIE   %1 2 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_HTIE    Half transfer interrupt enable
: DMA2-CCR7_TCIE   %1 1 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_TCIE    Transfer complete interrupt enable
: DMA2-CCR7_EN   %1 0 lshift DMA2-CCR7 bis! ;  \ DMA2-CCR7_EN    Channel enable

\ DMA2-CNDTR7 (read-write)
: DMA2-CNDTR7_NDT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CNDTR7 bis! ;  \ DMA2-CNDTR7_NDT    Number of data to transfer

\ DMA2-CPAR7 (read-write)
: DMA2-CPAR7_PA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CPAR7 bis! ;  \ DMA2-CPAR7_PA    Peripheral address

\ DMA2-CMAR7 (read-write)
: DMA2-CMAR7_MA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift DMA2-CMAR7 bis! ;  \ DMA2-CMAR7_MA    Memory address

\ DMA2-CSELR (read-write)
: DMA2-CSELR_C7S   ( %XXXX -- ) 24 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C7S    DMA channel 7 selection
: DMA2-CSELR_C6S   ( %XXXX -- ) 20 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C6S    DMA channel 6 selection
: DMA2-CSELR_C5S   ( %XXXX -- ) 16 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C5S    DMA channel 5 selection
: DMA2-CSELR_C4S   ( %XXXX -- ) 12 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C4S    DMA channel 4 selection
: DMA2-CSELR_C3S   ( %XXXX -- ) 8 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C3S    DMA channel 3 selection
: DMA2-CSELR_C2S   ( %XXXX -- ) 4 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C2S    DMA channel 2 selection
: DMA2-CSELR_C1S   ( %XXXX -- ) 0 lshift DMA2-CSELR bis! ;  \ DMA2-CSELR_C1S    DMA channel 1 selection

\ DMAMUX1-C0CR (read-write)
: DMAMUX1-C0CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_SYNC_ID    SYNC_ID
: DMAMUX1-C0CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_NBREQ    Nb request
: DMAMUX1-C0CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_SPOL    Sync polarity
: DMAMUX1-C0CR_SE   %1 16 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_SE    Synchronization enable
: DMAMUX1-C0CR_EGE   %1 9 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_EGE    Event Generation Enable
: DMAMUX1-C0CR_SOIE   %1 8 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C0CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C0CR bis! ;  \ DMAMUX1-C0CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C1CR (read-write)
: DMAMUX1-C1CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_SYNC_ID    SYNC_ID
: DMAMUX1-C1CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_NBREQ    Nb request
: DMAMUX1-C1CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_SPOL    Sync polarity
: DMAMUX1-C1CR_SE   %1 16 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_SE    Synchronization enable
: DMAMUX1-C1CR_EGE   %1 9 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_EGE    Event Generation Enable
: DMAMUX1-C1CR_SOIE   %1 8 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C1CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C1CR bis! ;  \ DMAMUX1-C1CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C2CR (read-write)
: DMAMUX1-C2CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_SYNC_ID    SYNC_ID
: DMAMUX1-C2CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_NBREQ    Nb request
: DMAMUX1-C2CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_SPOL    Sync polarity
: DMAMUX1-C2CR_SE   %1 16 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_SE    Synchronization enable
: DMAMUX1-C2CR_EGE   %1 9 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_EGE    Event Generation Enable
: DMAMUX1-C2CR_SOIE   %1 8 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C2CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C2CR bis! ;  \ DMAMUX1-C2CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C3CR (read-write)
: DMAMUX1-C3CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_SYNC_ID    SYNC_ID
: DMAMUX1-C3CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_NBREQ    Nb request
: DMAMUX1-C3CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_SPOL    Sync polarity
: DMAMUX1-C3CR_SE   %1 16 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_SE    Synchronization enable
: DMAMUX1-C3CR_EGE   %1 9 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_EGE    Event Generation Enable
: DMAMUX1-C3CR_SOIE   %1 8 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C3CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C3CR bis! ;  \ DMAMUX1-C3CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C4CR (read-write)
: DMAMUX1-C4CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_SYNC_ID    SYNC_ID
: DMAMUX1-C4CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_NBREQ    Nb request
: DMAMUX1-C4CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_SPOL    Sync polarity
: DMAMUX1-C4CR_SE   %1 16 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_SE    Synchronization enable
: DMAMUX1-C4CR_EGE   %1 9 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_EGE    Event Generation Enable
: DMAMUX1-C4CR_SOIE   %1 8 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C4CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C4CR bis! ;  \ DMAMUX1-C4CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C5CR (read-write)
: DMAMUX1-C5CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_SYNC_ID    SYNC_ID
: DMAMUX1-C5CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_NBREQ    Nb request
: DMAMUX1-C5CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_SPOL    Sync polarity
: DMAMUX1-C5CR_SE   %1 16 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_SE    Synchronization enable
: DMAMUX1-C5CR_EGE   %1 9 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_EGE    Event Generation Enable
: DMAMUX1-C5CR_SOIE   %1 8 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C5CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C5CR bis! ;  \ DMAMUX1-C5CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C6CR (read-write)
: DMAMUX1-C6CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_SYNC_ID    SYNC_ID
: DMAMUX1-C6CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_NBREQ    Nb request
: DMAMUX1-C6CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_SPOL    Sync polarity
: DMAMUX1-C6CR_SE   %1 16 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_SE    Synchronization enable
: DMAMUX1-C6CR_EGE   %1 9 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_EGE    Event Generation Enable
: DMAMUX1-C6CR_SOIE   %1 8 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C6CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C6CR bis! ;  \ DMAMUX1-C6CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C7CR (read-write)
: DMAMUX1-C7CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_SYNC_ID    SYNC_ID
: DMAMUX1-C7CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_NBREQ    Nb request
: DMAMUX1-C7CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_SPOL    Sync polarity
: DMAMUX1-C7CR_SE   %1 16 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_SE    Synchronization enable
: DMAMUX1-C7CR_EGE   %1 9 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_EGE    Event Generation Enable
: DMAMUX1-C7CR_SOIE   %1 8 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C7CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C7CR bis! ;  \ DMAMUX1-C7CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C8CR (read-write)
: DMAMUX1-C8CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_SYNC_ID    SYNC_ID
: DMAMUX1-C8CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_NBREQ    Nb request
: DMAMUX1-C8CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_SPOL    Sync polarity
: DMAMUX1-C8CR_SE   %1 16 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_SE    Synchronization enable
: DMAMUX1-C8CR_EGE   %1 9 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_EGE    Event Generation Enable
: DMAMUX1-C8CR_SOIE   %1 8 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C8CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C8CR bis! ;  \ DMAMUX1-C8CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C9CR (read-write)
: DMAMUX1-C9CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_SYNC_ID    SYNC_ID
: DMAMUX1-C9CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_NBREQ    Nb request
: DMAMUX1-C9CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_SPOL    Sync polarity
: DMAMUX1-C9CR_SE   %1 16 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_SE    Synchronization enable
: DMAMUX1-C9CR_EGE   %1 9 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_EGE    Event Generation Enable
: DMAMUX1-C9CR_SOIE   %1 8 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C9CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C9CR bis! ;  \ DMAMUX1-C9CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C10CR (read-write)
: DMAMUX1-C10CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_SYNC_ID    SYNC_ID
: DMAMUX1-C10CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_NBREQ    Nb request
: DMAMUX1-C10CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_SPOL    Sync polarity
: DMAMUX1-C10CR_SE   %1 16 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_SE    Synchronization enable
: DMAMUX1-C10CR_EGE   %1 9 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_EGE    Event Generation Enable
: DMAMUX1-C10CR_SOIE   %1 8 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C10CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C10CR bis! ;  \ DMAMUX1-C10CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C11CR (read-write)
: DMAMUX1-C11CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_SYNC_ID    SYNC_ID
: DMAMUX1-C11CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_NBREQ    Nb request
: DMAMUX1-C11CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_SPOL    Sync polarity
: DMAMUX1-C11CR_SE   %1 16 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_SE    Synchronization enable
: DMAMUX1-C11CR_EGE   %1 9 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_EGE    Event Generation Enable
: DMAMUX1-C11CR_SOIE   %1 8 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C11CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C11CR bis! ;  \ DMAMUX1-C11CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C12CR (read-write)
: DMAMUX1-C12CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_SYNC_ID    SYNC_ID
: DMAMUX1-C12CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_NBREQ    Nb request
: DMAMUX1-C12CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_SPOL    Sync polarity
: DMAMUX1-C12CR_SE   %1 16 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_SE    Synchronization enable
: DMAMUX1-C12CR_EGE   %1 9 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_EGE    Event Generation Enable
: DMAMUX1-C12CR_SOIE   %1 8 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C12CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C12CR bis! ;  \ DMAMUX1-C12CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-C13CR (read-write)
: DMAMUX1-C13CR_SYNC_ID   ( %XXXXX -- ) 24 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_SYNC_ID    SYNC_ID
: DMAMUX1-C13CR_NBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_NBREQ    Nb request
: DMAMUX1-C13CR_SPOL   ( %XX -- ) 17 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_SPOL    Sync polarity
: DMAMUX1-C13CR_SE   %1 16 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_SE    Synchronization enable
: DMAMUX1-C13CR_EGE   %1 9 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_EGE    Event Generation Enable
: DMAMUX1-C13CR_SOIE   %1 8 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_SOIE    Synchronization Overrun Interrupt Enable
: DMAMUX1-C13CR_DMAREQ_ID   ( %XXXXXXXX -- ) 0 lshift DMAMUX1-C13CR bis! ;  \ DMAMUX1-C13CR_DMAREQ_ID    DMA Request ID

\ DMAMUX1-CSR (read-only)
: DMAMUX1-CSR_SOF0   %1 0 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF0    Synchronization Overrun Flag 0
: DMAMUX1-CSR_SOF1   %1 1 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF1    Synchronization Overrun Flag 1
: DMAMUX1-CSR_SOF2   %1 2 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF2    Synchronization Overrun Flag 2
: DMAMUX1-CSR_SOF3   %1 3 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF3    Synchronization Overrun Flag 3
: DMAMUX1-CSR_SOF4   %1 4 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF4    Synchronization Overrun Flag 4
: DMAMUX1-CSR_SOF5   %1 5 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF5    Synchronization Overrun Flag 5
: DMAMUX1-CSR_SOF6   %1 6 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF6    Synchronization Overrun Flag 6
: DMAMUX1-CSR_SOF7   %1 7 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF7    Synchronization Overrun Flag 7
: DMAMUX1-CSR_SOF8   %1 8 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF8    Synchronization Overrun Flag 8
: DMAMUX1-CSR_SOF9   %1 9 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF9    Synchronization Overrun Flag 9
: DMAMUX1-CSR_SOF10   %1 10 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF10    Synchronization Overrun Flag 10
: DMAMUX1-CSR_SOF11   %1 11 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF11    Synchronization Overrun Flag 11
: DMAMUX1-CSR_SOF12   %1 12 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF12    Synchronization Overrun Flag 12
: DMAMUX1-CSR_SOF13   %1 13 lshift DMAMUX1-CSR bis! ;  \ DMAMUX1-CSR_SOF13    Synchronization Overrun Flag 13

\ DMAMUX1-CFR (write-only)
: DMAMUX1-CFR_CSOF0   %1 0 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF0    Synchronization Clear Overrun Flag 0
: DMAMUX1-CFR_CSOF1   %1 1 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF1    Synchronization Clear Overrun Flag 1
: DMAMUX1-CFR_CSOF2   %1 2 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF2    Synchronization Clear Overrun Flag 2
: DMAMUX1-CFR_CSOF3   %1 3 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF3    Synchronization Clear Overrun Flag 3
: DMAMUX1-CFR_CSOF4   %1 4 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF4    Synchronization Clear Overrun Flag 4
: DMAMUX1-CFR_CSOF5   %1 5 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF5    Synchronization Clear Overrun Flag 5
: DMAMUX1-CFR_CSOF6   %1 6 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF6    Synchronization Clear Overrun Flag 6
: DMAMUX1-CFR_CSOF7   %1 7 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF7    Synchronization Clear Overrun Flag 7
: DMAMUX1-CFR_CSOF8   %1 8 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF8    Synchronization Clear Overrun Flag 8
: DMAMUX1-CFR_CSOF9   %1 9 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF9    Synchronization Clear Overrun Flag 9
: DMAMUX1-CFR_CSOF10   %1 10 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF10    Synchronization Clear Overrun Flag 10
: DMAMUX1-CFR_CSOF11   %1 11 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF11    Synchronization Clear Overrun Flag 11
: DMAMUX1-CFR_CSOF12   %1 12 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF12    Synchronization Clear Overrun Flag 12
: DMAMUX1-CFR_CSOF13   %1 13 lshift DMAMUX1-CFR bis! ;  \ DMAMUX1-CFR_CSOF13    Synchronization Clear Overrun Flag 13

\ DMAMUX1-RG0CR (read-write)
: DMAMUX1-RG0CR_GNBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-RG0CR bis! ;  \ DMAMUX1-RG0CR_GNBREQ    Number of Request
: DMAMUX1-RG0CR_GPOL   ( %XX -- ) 17 lshift DMAMUX1-RG0CR bis! ;  \ DMAMUX1-RG0CR_GPOL    Generation Polarity
: DMAMUX1-RG0CR_GE   %1 16 lshift DMAMUX1-RG0CR bis! ;  \ DMAMUX1-RG0CR_GE    Generation Enable
: DMAMUX1-RG0CR_OIE   %1 8 lshift DMAMUX1-RG0CR bis! ;  \ DMAMUX1-RG0CR_OIE    Overrun Interrupt Enable
: DMAMUX1-RG0CR_SIG_ID   ( %XXXXX -- ) 0 lshift DMAMUX1-RG0CR bis! ;  \ DMAMUX1-RG0CR_SIG_ID    Signal ID

\ DMAMUX1-RG1CR (read-write)
: DMAMUX1-RG1CR_GNBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-RG1CR bis! ;  \ DMAMUX1-RG1CR_GNBREQ    Number of Request
: DMAMUX1-RG1CR_GPOL   ( %XX -- ) 17 lshift DMAMUX1-RG1CR bis! ;  \ DMAMUX1-RG1CR_GPOL    Generation Polarity
: DMAMUX1-RG1CR_GE   %1 16 lshift DMAMUX1-RG1CR bis! ;  \ DMAMUX1-RG1CR_GE    Generation Enable
: DMAMUX1-RG1CR_OIE   %1 8 lshift DMAMUX1-RG1CR bis! ;  \ DMAMUX1-RG1CR_OIE    Overrun Interrupt Enable
: DMAMUX1-RG1CR_SIG_ID   ( %XXXXX -- ) 0 lshift DMAMUX1-RG1CR bis! ;  \ DMAMUX1-RG1CR_SIG_ID    Signal ID

\ DMAMUX1-RG2CR (read-write)
: DMAMUX1-RG2CR_GNBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-RG2CR bis! ;  \ DMAMUX1-RG2CR_GNBREQ    Number of Request
: DMAMUX1-RG2CR_GPOL   ( %XX -- ) 17 lshift DMAMUX1-RG2CR bis! ;  \ DMAMUX1-RG2CR_GPOL    Generation Polarity
: DMAMUX1-RG2CR_GE   %1 16 lshift DMAMUX1-RG2CR bis! ;  \ DMAMUX1-RG2CR_GE    Generation Enable
: DMAMUX1-RG2CR_OIE   %1 8 lshift DMAMUX1-RG2CR bis! ;  \ DMAMUX1-RG2CR_OIE    Overrun Interrupt Enable
: DMAMUX1-RG2CR_SIG_ID   ( %XXXXX -- ) 0 lshift DMAMUX1-RG2CR bis! ;  \ DMAMUX1-RG2CR_SIG_ID    Signal ID

\ DMAMUX1-RG3CR (read-write)
: DMAMUX1-RG3CR_GNBREQ   ( %XXXXX -- ) 19 lshift DMAMUX1-RG3CR bis! ;  \ DMAMUX1-RG3CR_GNBREQ    Number of Request
: DMAMUX1-RG3CR_GPOL   ( %XX -- ) 17 lshift DMAMUX1-RG3CR bis! ;  \ DMAMUX1-RG3CR_GPOL    Generation Polarity
: DMAMUX1-RG3CR_GE   %1 16 lshift DMAMUX1-RG3CR bis! ;  \ DMAMUX1-RG3CR_GE    Generation Enable
: DMAMUX1-RG3CR_OIE   %1 8 lshift DMAMUX1-RG3CR bis! ;  \ DMAMUX1-RG3CR_OIE    Overrun Interrupt Enable
: DMAMUX1-RG3CR_SIG_ID   ( %XXXXX -- ) 0 lshift DMAMUX1-RG3CR bis! ;  \ DMAMUX1-RG3CR_SIG_ID    Signal ID

\ DMAMUX1-RGSR (read-only)
: DMAMUX1-RGSR_OF0   %1 0 lshift DMAMUX1-RGSR bis! ;  \ DMAMUX1-RGSR_OF0    Generator Overrun Flag 0
: DMAMUX1-RGSR_OF1   %1 1 lshift DMAMUX1-RGSR bis! ;  \ DMAMUX1-RGSR_OF1    Generator Overrun Flag 1
: DMAMUX1-RGSR_OF2   %1 2 lshift DMAMUX1-RGSR bis! ;  \ DMAMUX1-RGSR_OF2    Generator Overrun Flag 2
: DMAMUX1-RGSR_OF3   %1 3 lshift DMAMUX1-RGSR bis! ;  \ DMAMUX1-RGSR_OF3    Generator Overrun Flag 3

\ DMAMUX1-RGCFR (read-only)
: DMAMUX1-RGCFR_CSOF0   %1 0 lshift DMAMUX1-RGCFR bis! ;  \ DMAMUX1-RGCFR_CSOF0    Generator Clear Overrun Flag 0
: DMAMUX1-RGCFR_CSOF1   %1 1 lshift DMAMUX1-RGCFR bis! ;  \ DMAMUX1-RGCFR_CSOF1    Generator Clear Overrun Flag 1
: DMAMUX1-RGCFR_CSOF2   %1 2 lshift DMAMUX1-RGCFR bis! ;  \ DMAMUX1-RGCFR_CSOF2    Generator Clear Overrun Flag 2
: DMAMUX1-RGCFR_CSOF3   %1 3 lshift DMAMUX1-RGCFR bis! ;  \ DMAMUX1-RGCFR_CSOF3    Generator Clear Overrun Flag 3

\ CRC-DR (read-write)
: CRC-DR_DR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift CRC-DR bis! ;  \ CRC-DR_DR    Data register bits

\ CRC-IDR (read-write)
: CRC-IDR_IDR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift CRC-IDR bis! ;  \ CRC-IDR_IDR    General-purpose 32-bit data register bits

\ CRC-CR (read-write)
: CRC-CR_REV_OUT   %1 7 lshift CRC-CR bis! ;  \ CRC-CR_REV_OUT    Reverse output data
: CRC-CR_REV_IN   ( %XX -- ) 5 lshift CRC-CR bis! ;  \ CRC-CR_REV_IN    Reverse input data
: CRC-CR_POLYSIZE   ( %XX -- ) 3 lshift CRC-CR bis! ;  \ CRC-CR_POLYSIZE    Polynomial size
: CRC-CR_RESET   %1 0 lshift CRC-CR bis! ;  \ CRC-CR_RESET    RESET bit

\ CRC-INIT (read-write)
: CRC-INIT_CRC_INIT   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift CRC-INIT bis! ;  \ CRC-INIT_CRC_INIT    Programmable initial CRC value

\ CRC-POL (read-write)
: CRC-POL_POL   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift CRC-POL bis! ;  \ CRC-POL_POL    Programmable polynomial

\ LCD-CR (read-write)
: LCD-CR_BIAS   ( %XX -- ) 5 lshift LCD-CR bis! ;  \ LCD-CR_BIAS    Bias selector
: LCD-CR_DUTY   ( %XXX -- ) 2 lshift LCD-CR bis! ;  \ LCD-CR_DUTY    Duty selection
: LCD-CR_VSEL   %1 1 lshift LCD-CR bis! ;  \ LCD-CR_VSEL    Voltage source selection
: LCD-CR_LCDEN   %1 0 lshift LCD-CR bis! ;  \ LCD-CR_LCDEN    LCD controller enable
: LCD-CR_MUX_SEG   %1 7 lshift LCD-CR bis! ;  \ LCD-CR_MUX_SEG    Mux segment enable
: LCD-CR_BUFEN   %1 8 lshift LCD-CR bis! ;  \ LCD-CR_BUFEN    Voltage output buffer enable

\ LCD-FCR (read-write)
: LCD-FCR_PS   ( %XXXX -- ) 22 lshift LCD-FCR bis! ;  \ LCD-FCR_PS    PS 16-bit prescaler
: LCD-FCR_DIV   ( %XXXX -- ) 18 lshift LCD-FCR bis! ;  \ LCD-FCR_DIV    DIV clock divider
: LCD-FCR_BLINK   ( %XX -- ) 16 lshift LCD-FCR bis! ;  \ LCD-FCR_BLINK    Blink mode selection
: LCD-FCR_BLINKF   ( %XXX -- ) 13 lshift LCD-FCR bis! ;  \ LCD-FCR_BLINKF    Blink frequency selection
: LCD-FCR_CC   ( %XXX -- ) 10 lshift LCD-FCR bis! ;  \ LCD-FCR_CC    Contrast control
: LCD-FCR_DEAD   ( %XXX -- ) 7 lshift LCD-FCR bis! ;  \ LCD-FCR_DEAD    Dead time duration
: LCD-FCR_PON   ( %XXX -- ) 4 lshift LCD-FCR bis! ;  \ LCD-FCR_PON    Pulse ON duration
: LCD-FCR_UDDIE   %1 3 lshift LCD-FCR bis! ;  \ LCD-FCR_UDDIE    Update display done interrupt enable
: LCD-FCR_SOFIE   %1 1 lshift LCD-FCR bis! ;  \ LCD-FCR_SOFIE    Start of frame interrupt enable
: LCD-FCR_HD   %1 0 lshift LCD-FCR bis! ;  \ LCD-FCR_HD    High drive enable

\ LCD-SR ()
: LCD-SR_FCRSF   %1 5 lshift LCD-SR bis! ;  \ LCD-SR_FCRSF    LCD Frame Control Register Synchronization flag
: LCD-SR_RDY   %1 4 lshift LCD-SR bis! ;  \ LCD-SR_RDY    Ready flag
: LCD-SR_UDD   %1 3 lshift LCD-SR bis! ;  \ LCD-SR_UDD    Update Display Done
: LCD-SR_UDR   %1 2 lshift LCD-SR bis! ;  \ LCD-SR_UDR    Update display request
: LCD-SR_SOF   %1 1 lshift LCD-SR bis! ;  \ LCD-SR_SOF    Start of frame flag
: LCD-SR_ENS   %1 0 lshift LCD-SR bis! ;  \ LCD-SR_ENS    ENS

\ LCD-CLR (write-only)
: LCD-CLR_UDDC   %1 3 lshift LCD-CLR bis! ;  \ LCD-CLR_UDDC    Update display done clear
: LCD-CLR_SOFC   %1 1 lshift LCD-CLR bis! ;  \ LCD-CLR_SOFC    Start of frame flag clear

\ LCD-RAM_COM0 (read-write)
: LCD-RAM_COM0_S31   %1 31 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S31    S31
: LCD-RAM_COM0_S30   %1 30 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S30    S30
: LCD-RAM_COM0_S29   %1 29 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S29    S29
: LCD-RAM_COM0_S28   %1 28 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S28    S28
: LCD-RAM_COM0_S27   %1 27 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S27    S27
: LCD-RAM_COM0_S26   %1 26 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S26    S26
: LCD-RAM_COM0_S25   %1 25 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S25    S25
: LCD-RAM_COM0_S24   %1 24 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S24    S24
: LCD-RAM_COM0_S23   %1 23 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S23    S23
: LCD-RAM_COM0_S22   %1 22 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S22    S22
: LCD-RAM_COM0_S21   %1 21 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S21    S21
: LCD-RAM_COM0_S20   %1 20 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S20    S20
: LCD-RAM_COM0_S19   %1 19 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S19    S19
: LCD-RAM_COM0_S18   %1 18 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S18    S18
: LCD-RAM_COM0_S17   %1 17 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S17    S17
: LCD-RAM_COM0_S16   %1 16 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S16    S16
: LCD-RAM_COM0_S15   %1 15 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S15    S15
: LCD-RAM_COM0_S14   %1 14 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S14    S14
: LCD-RAM_COM0_S13   %1 13 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S13    S13
: LCD-RAM_COM0_S12   %1 12 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S12    S12
: LCD-RAM_COM0_S11   %1 11 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S11    S11
: LCD-RAM_COM0_S10   %1 10 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S10    S10
: LCD-RAM_COM0_S09   %1 9 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S09    S09
: LCD-RAM_COM0_S08   %1 8 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S08    S08
: LCD-RAM_COM0_S07   %1 7 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S07    S07
: LCD-RAM_COM0_S06   %1 6 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S06    S06
: LCD-RAM_COM0_S05   %1 5 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S05    S05
: LCD-RAM_COM0_S04   %1 4 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S04    S04
: LCD-RAM_COM0_S03   %1 3 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S03    S03
: LCD-RAM_COM0_S02   %1 2 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S02    S02
: LCD-RAM_COM0_S01   %1 1 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S01    S01
: LCD-RAM_COM0_S00   %1 0 lshift LCD-RAM_COM0 bis! ;  \ LCD-RAM_COM0_S00    S00

\ LCD-RAM_COM1 (read-write)
: LCD-RAM_COM1_S31   %1 31 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S31    S31
: LCD-RAM_COM1_S30   %1 30 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S30    S30
: LCD-RAM_COM1_S29   %1 29 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S29    S29
: LCD-RAM_COM1_S28   %1 28 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S28    S28
: LCD-RAM_COM1_S27   %1 27 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S27    S27
: LCD-RAM_COM1_S26   %1 26 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S26    S26
: LCD-RAM_COM1_S25   %1 25 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S25    S25
: LCD-RAM_COM1_S24   %1 24 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S24    S24
: LCD-RAM_COM1_S23   %1 23 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S23    S23
: LCD-RAM_COM1_S22   %1 22 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S22    S22
: LCD-RAM_COM1_S21   %1 21 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S21    S21
: LCD-RAM_COM1_S20   %1 20 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S20    S20
: LCD-RAM_COM1_S19   %1 19 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S19    S19
: LCD-RAM_COM1_S18   %1 18 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S18    S18
: LCD-RAM_COM1_S17   %1 17 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S17    S17
: LCD-RAM_COM1_S16   %1 16 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S16    S16
: LCD-RAM_COM1_S15   %1 15 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S15    S15
: LCD-RAM_COM1_S14   %1 14 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S14    S14
: LCD-RAM_COM1_S13   %1 13 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S13    S13
: LCD-RAM_COM1_S12   %1 12 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S12    S12
: LCD-RAM_COM1_S11   %1 11 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S11    S11
: LCD-RAM_COM1_S10   %1 10 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S10    S10
: LCD-RAM_COM1_S09   %1 9 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S09    S09
: LCD-RAM_COM1_S08   %1 8 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S08    S08
: LCD-RAM_COM1_S07   %1 7 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S07    S07
: LCD-RAM_COM1_S06   %1 6 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S06    S06
: LCD-RAM_COM1_S05   %1 5 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S05    S05
: LCD-RAM_COM1_S04   %1 4 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S04    S04
: LCD-RAM_COM1_S03   %1 3 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S03    S03
: LCD-RAM_COM1_S02   %1 2 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S02    S02
: LCD-RAM_COM1_S01   %1 1 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S01    S01
: LCD-RAM_COM1_S00   %1 0 lshift LCD-RAM_COM1 bis! ;  \ LCD-RAM_COM1_S00    S00

\ LCD-RAM_COM2 (read-write)
: LCD-RAM_COM2_S31   %1 31 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S31    S31
: LCD-RAM_COM2_S30   %1 30 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S30    S30
: LCD-RAM_COM2_S29   %1 29 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S29    S29
: LCD-RAM_COM2_S28   %1 28 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S28    S28
: LCD-RAM_COM2_S27   %1 27 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S27    S27
: LCD-RAM_COM2_S26   %1 26 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S26    S26
: LCD-RAM_COM2_S25   %1 25 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S25    S25
: LCD-RAM_COM2_S24   %1 24 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S24    S24
: LCD-RAM_COM2_S23   %1 23 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S23    S23
: LCD-RAM_COM2_S22   %1 22 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S22    S22
: LCD-RAM_COM2_S21   %1 21 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S21    S21
: LCD-RAM_COM2_S20   %1 20 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S20    S20
: LCD-RAM_COM2_S19   %1 19 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S19    S19
: LCD-RAM_COM2_S18   %1 18 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S18    S18
: LCD-RAM_COM2_S17   %1 17 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S17    S17
: LCD-RAM_COM2_S16   %1 16 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S16    S16
: LCD-RAM_COM2_S15   %1 15 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S15    S15
: LCD-RAM_COM2_S14   %1 14 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S14    S14
: LCD-RAM_COM2_S13   %1 13 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S13    S13
: LCD-RAM_COM2_S12   %1 12 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S12    S12
: LCD-RAM_COM2_S11   %1 11 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S11    S11
: LCD-RAM_COM2_S10   %1 10 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S10    S10
: LCD-RAM_COM2_S09   %1 9 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S09    S09
: LCD-RAM_COM2_S08   %1 8 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S08    S08
: LCD-RAM_COM2_S07   %1 7 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S07    S07
: LCD-RAM_COM2_S06   %1 6 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S06    S06
: LCD-RAM_COM2_S05   %1 5 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S05    S05
: LCD-RAM_COM2_S04   %1 4 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S04    S04
: LCD-RAM_COM2_S03   %1 3 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S03    S03
: LCD-RAM_COM2_S02   %1 2 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S02    S02
: LCD-RAM_COM2_S01   %1 1 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S01    S01
: LCD-RAM_COM2_S00   %1 0 lshift LCD-RAM_COM2 bis! ;  \ LCD-RAM_COM2_S00    S00

\ LCD-RAM_COM3 (read-write)
: LCD-RAM_COM3_S31   %1 31 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S31    S31
: LCD-RAM_COM3_S30   %1 30 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S30    S30
: LCD-RAM_COM3_S29   %1 29 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S29    S29
: LCD-RAM_COM3_S28   %1 28 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S28    S28
: LCD-RAM_COM3_S27   %1 27 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S27    S27
: LCD-RAM_COM3_S26   %1 26 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S26    S26
: LCD-RAM_COM3_S25   %1 25 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S25    S25
: LCD-RAM_COM3_S24   %1 24 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S24    S24
: LCD-RAM_COM3_S23   %1 23 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S23    S23
: LCD-RAM_COM3_S22   %1 22 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S22    S22
: LCD-RAM_COM3_S21   %1 21 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S21    S21
: LCD-RAM_COM3_S20   %1 20 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S20    S20
: LCD-RAM_COM3_S19   %1 19 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S19    S19
: LCD-RAM_COM3_S18   %1 18 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S18    S18
: LCD-RAM_COM3_S17   %1 17 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S17    S17
: LCD-RAM_COM3_S16   %1 16 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S16    S16
: LCD-RAM_COM3_S15   %1 15 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S15    S15
: LCD-RAM_COM3_S14   %1 14 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S14    S14
: LCD-RAM_COM3_S13   %1 13 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S13    S13
: LCD-RAM_COM3_S12   %1 12 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S12    S12
: LCD-RAM_COM3_S11   %1 11 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S11    S11
: LCD-RAM_COM3_S10   %1 10 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S10    S10
: LCD-RAM_COM3_S09   %1 9 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S09    S09
: LCD-RAM_COM3_S08   %1 8 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S08    S08
: LCD-RAM_COM3_S07   %1 7 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S07    S07
: LCD-RAM_COM3_S06   %1 6 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S06    S06
: LCD-RAM_COM3_S05   %1 5 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S05    S05
: LCD-RAM_COM3_S04   %1 4 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S04    S04
: LCD-RAM_COM3_S03   %1 3 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S03    S03
: LCD-RAM_COM3_S02   %1 2 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S02    S02
: LCD-RAM_COM3_S01   %1 1 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S01    S01
: LCD-RAM_COM3_S00   %1 0 lshift LCD-RAM_COM3 bis! ;  \ LCD-RAM_COM3_S00    S00

\ LCD-RAM_COM4 (read-write)
: LCD-RAM_COM4_S31   %1 31 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S31    S31
: LCD-RAM_COM4_S30   %1 30 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S30    S30
: LCD-RAM_COM4_S29   %1 29 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S29    S29
: LCD-RAM_COM4_S28   %1 28 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S28    S28
: LCD-RAM_COM4_S27   %1 27 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S27    S27
: LCD-RAM_COM4_S26   %1 26 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S26    S26
: LCD-RAM_COM4_S25   %1 25 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S25    S25
: LCD-RAM_COM4_S24   %1 24 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S24    S24
: LCD-RAM_COM4_S23   %1 23 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S23    S23
: LCD-RAM_COM4_S22   %1 22 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S22    S22
: LCD-RAM_COM4_S21   %1 21 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S21    S21
: LCD-RAM_COM4_S20   %1 20 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S20    S20
: LCD-RAM_COM4_S19   %1 19 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S19    S19
: LCD-RAM_COM4_S18   %1 18 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S18    S18
: LCD-RAM_COM4_S17   %1 17 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S17    S17
: LCD-RAM_COM4_S16   %1 16 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S16    S16
: LCD-RAM_COM4_S15   %1 15 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S15    S15
: LCD-RAM_COM4_S14   %1 14 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S14    S14
: LCD-RAM_COM4_S13   %1 13 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S13    S13
: LCD-RAM_COM4_S12   %1 12 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S12    S12
: LCD-RAM_COM4_S11   %1 11 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S11    S11
: LCD-RAM_COM4_S10   %1 10 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S10    S10
: LCD-RAM_COM4_S09   %1 9 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S09    S09
: LCD-RAM_COM4_S08   %1 8 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S08    S08
: LCD-RAM_COM4_S07   %1 7 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S07    S07
: LCD-RAM_COM4_S06   %1 6 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S06    S06
: LCD-RAM_COM4_S05   %1 5 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S05    S05
: LCD-RAM_COM4_S04   %1 4 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S04    S04
: LCD-RAM_COM4_S03   %1 3 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S03    S03
: LCD-RAM_COM4_S02   %1 2 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S02    S02
: LCD-RAM_COM4_S01   %1 1 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S01    S01
: LCD-RAM_COM4_S00   %1 0 lshift LCD-RAM_COM4 bis! ;  \ LCD-RAM_COM4_S00    S00

\ LCD-RAM_COM5 (read-write)
: LCD-RAM_COM5_S31   %1 31 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S31    S31
: LCD-RAM_COM5_S30   %1 30 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S30    S30
: LCD-RAM_COM5_S29   %1 29 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S29    S29
: LCD-RAM_COM5_S28   %1 28 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S28    S28
: LCD-RAM_COM5_S27   %1 27 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S27    S27
: LCD-RAM_COM5_S26   %1 26 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S26    S26
: LCD-RAM_COM5_S25   %1 25 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S25    S25
: LCD-RAM_COM5_S24   %1 24 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S24    S24
: LCD-RAM_COM5_S23   %1 23 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S23    S23
: LCD-RAM_COM5_S22   %1 22 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S22    S22
: LCD-RAM_COM5_S21   %1 21 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S21    S21
: LCD-RAM_COM5_S20   %1 20 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S20    S20
: LCD-RAM_COM5_S19   %1 19 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S19    S19
: LCD-RAM_COM5_S18   %1 18 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S18    S18
: LCD-RAM_COM5_S17   %1 17 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S17    S17
: LCD-RAM_COM5_S16   %1 16 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S16    S16
: LCD-RAM_COM5_S15   %1 15 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S15    S15
: LCD-RAM_COM5_S14   %1 14 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S14    S14
: LCD-RAM_COM5_S13   %1 13 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S13    S13
: LCD-RAM_COM5_S12   %1 12 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S12    S12
: LCD-RAM_COM5_S11   %1 11 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S11    S11
: LCD-RAM_COM5_S10   %1 10 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S10    S10
: LCD-RAM_COM5_S09   %1 9 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S09    S09
: LCD-RAM_COM5_S08   %1 8 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S08    S08
: LCD-RAM_COM5_S07   %1 7 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S07    S07
: LCD-RAM_COM5_S06   %1 6 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S06    S06
: LCD-RAM_COM5_S05   %1 5 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S05    S05
: LCD-RAM_COM5_S04   %1 4 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S04    S04
: LCD-RAM_COM5_S03   %1 3 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S03    S03
: LCD-RAM_COM5_S02   %1 2 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S02    S02
: LCD-RAM_COM5_S01   %1 1 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S01    S01
: LCD-RAM_COM5_S00   %1 0 lshift LCD-RAM_COM5 bis! ;  \ LCD-RAM_COM5_S00    S00

\ LCD-RAM_COM6 (read-write)
: LCD-RAM_COM6_S31   %1 31 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S31    S31
: LCD-RAM_COM6_S30   %1 30 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S30    S30
: LCD-RAM_COM6_S29   %1 29 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S29    S29
: LCD-RAM_COM6_S28   %1 28 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S28    S28
: LCD-RAM_COM6_S27   %1 27 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S27    S27
: LCD-RAM_COM6_S26   %1 26 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S26    S26
: LCD-RAM_COM6_S25   %1 25 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S25    S25
: LCD-RAM_COM6_S24   %1 24 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S24    S24
: LCD-RAM_COM6_S23   %1 23 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S23    S23
: LCD-RAM_COM6_S22   %1 22 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S22    S22
: LCD-RAM_COM6_S21   %1 21 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S21    S21
: LCD-RAM_COM6_S20   %1 20 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S20    S20
: LCD-RAM_COM6_S19   %1 19 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S19    S19
: LCD-RAM_COM6_S18   %1 18 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S18    S18
: LCD-RAM_COM6_S17   %1 17 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S17    S17
: LCD-RAM_COM6_S16   %1 16 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S16    S16
: LCD-RAM_COM6_S15   %1 15 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S15    S15
: LCD-RAM_COM6_S14   %1 14 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S14    S14
: LCD-RAM_COM6_S13   %1 13 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S13    S13
: LCD-RAM_COM6_S12   %1 12 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S12    S12
: LCD-RAM_COM6_S11   %1 11 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S11    S11
: LCD-RAM_COM6_S10   %1 10 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S10    S10
: LCD-RAM_COM6_S09   %1 9 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S09    S09
: LCD-RAM_COM6_S08   %1 8 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S08    S08
: LCD-RAM_COM6_S07   %1 7 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S07    S07
: LCD-RAM_COM6_S06   %1 6 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S06    S06
: LCD-RAM_COM6_S05   %1 5 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S05    S05
: LCD-RAM_COM6_S04   %1 4 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S04    S04
: LCD-RAM_COM6_S03   %1 3 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S03    S03
: LCD-RAM_COM6_S02   %1 2 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S02    S02
: LCD-RAM_COM6_S01   %1 1 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S01    S01
: LCD-RAM_COM6_S00   %1 0 lshift LCD-RAM_COM6 bis! ;  \ LCD-RAM_COM6_S00    S00

\ LCD-RAM_COM7 (read-write)
: LCD-RAM_COM7_S31   %1 31 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S31    S31
: LCD-RAM_COM7_S30   %1 30 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S30    S30
: LCD-RAM_COM7_S29   %1 29 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S29    S29
: LCD-RAM_COM7_S28   %1 28 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S28    S28
: LCD-RAM_COM7_S27   %1 27 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S27    S27
: LCD-RAM_COM7_S26   %1 26 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S26    S26
: LCD-RAM_COM7_S25   %1 25 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S25    S25
: LCD-RAM_COM7_S24   %1 24 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S24    S24
: LCD-RAM_COM7_S23   %1 23 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S23    S23
: LCD-RAM_COM7_S22   %1 22 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S22    S22
: LCD-RAM_COM7_S21   %1 21 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S21    S21
: LCD-RAM_COM7_S20   %1 20 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S20    S20
: LCD-RAM_COM7_S19   %1 19 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S19    S19
: LCD-RAM_COM7_S18   %1 18 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S18    S18
: LCD-RAM_COM7_S17   %1 17 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S17    S17
: LCD-RAM_COM7_S16   %1 16 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S16    S16
: LCD-RAM_COM7_S15   %1 15 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S15    S15
: LCD-RAM_COM7_S14   %1 14 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S14    S14
: LCD-RAM_COM7_S13   %1 13 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S13    S13
: LCD-RAM_COM7_S12   %1 12 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S12    S12
: LCD-RAM_COM7_S11   %1 11 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S11    S11
: LCD-RAM_COM7_S10   %1 10 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S10    S10
: LCD-RAM_COM7_S09   %1 9 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S09    S09
: LCD-RAM_COM7_S08   %1 8 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S08    S08
: LCD-RAM_COM7_S07   %1 7 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S07    S07
: LCD-RAM_COM7_S06   %1 6 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S06    S06
: LCD-RAM_COM7_S05   %1 5 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S05    S05
: LCD-RAM_COM7_S04   %1 4 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S04    S04
: LCD-RAM_COM7_S03   %1 3 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S03    S03
: LCD-RAM_COM7_S02   %1 2 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S02    S02
: LCD-RAM_COM7_S01   %1 1 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S01    S01
: LCD-RAM_COM7_S00   %1 0 lshift LCD-RAM_COM7 bis! ;  \ LCD-RAM_COM7_S00    S00

\ TSC-CR (read-write)
: TSC-CR_CTPH   ( %XXXX -- ) 28 lshift TSC-CR bis! ;  \ TSC-CR_CTPH    Charge transfer pulse high
: TSC-CR_CTPL   ( %XXXX -- ) 24 lshift TSC-CR bis! ;  \ TSC-CR_CTPL    Charge transfer pulse low
: TSC-CR_SSD   ( %XXXXXXX -- ) 17 lshift TSC-CR bis! ;  \ TSC-CR_SSD    Spread spectrum deviation
: TSC-CR_SSE   %1 16 lshift TSC-CR bis! ;  \ TSC-CR_SSE    Spread spectrum enable
: TSC-CR_SSPSC   %1 15 lshift TSC-CR bis! ;  \ TSC-CR_SSPSC    Spread spectrum prescaler
: TSC-CR_PGPSC   ( %XXX -- ) 12 lshift TSC-CR bis! ;  \ TSC-CR_PGPSC    pulse generator prescaler
: TSC-CR_MCV   ( %XXX -- ) 5 lshift TSC-CR bis! ;  \ TSC-CR_MCV    Max count value
: TSC-CR_IODEF   %1 4 lshift TSC-CR bis! ;  \ TSC-CR_IODEF    I/O Default mode
: TSC-CR_SYNCPOL   %1 3 lshift TSC-CR bis! ;  \ TSC-CR_SYNCPOL    Synchronization pin polarity
: TSC-CR_AM   %1 2 lshift TSC-CR bis! ;  \ TSC-CR_AM    Acquisition mode
: TSC-CR_START   %1 1 lshift TSC-CR bis! ;  \ TSC-CR_START    Start a new acquisition
: TSC-CR_TSCE   %1 0 lshift TSC-CR bis! ;  \ TSC-CR_TSCE    Touch sensing controller enable

\ TSC-IER (read-write)
: TSC-IER_MCEIE   %1 1 lshift TSC-IER bis! ;  \ TSC-IER_MCEIE    Max count error interrupt enable
: TSC-IER_EOAIE   %1 0 lshift TSC-IER bis! ;  \ TSC-IER_EOAIE    End of acquisition interrupt enable

\ TSC-ICR (read-write)
: TSC-ICR_MCEIC   %1 1 lshift TSC-ICR bis! ;  \ TSC-ICR_MCEIC    Max count error interrupt clear
: TSC-ICR_EOAIC   %1 0 lshift TSC-ICR bis! ;  \ TSC-ICR_EOAIC    End of acquisition interrupt clear

\ TSC-ISR (read-write)
: TSC-ISR_MCEF   %1 1 lshift TSC-ISR bis! ;  \ TSC-ISR_MCEF    Max count error flag
: TSC-ISR_EOAF   %1 0 lshift TSC-ISR bis! ;  \ TSC-ISR_EOAF    End of acquisition flag

\ TSC-IOHCR (read-write)
: TSC-IOHCR_G7_IO4   %1 27 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G7_IO4    G7_IO4
: TSC-IOHCR_G7_IO3   %1 26 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G7_IO3    G7_IO3
: TSC-IOHCR_G7_IO2   %1 25 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G7_IO2    G7_IO2
: TSC-IOHCR_G7_IO1   %1 24 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G7_IO1    G7_IO1
: TSC-IOHCR_G6_IO4   %1 23 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G6_IO4    G6_IO4
: TSC-IOHCR_G6_IO3   %1 22 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G6_IO3    G6_IO3
: TSC-IOHCR_G6_IO2   %1 21 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G6_IO2    G6_IO2
: TSC-IOHCR_G6_IO1   %1 20 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G6_IO1    G6_IO1
: TSC-IOHCR_G5_IO4   %1 19 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G5_IO4    G5_IO4
: TSC-IOHCR_G5_IO3   %1 18 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G5_IO3    G5_IO3
: TSC-IOHCR_G5_IO2   %1 17 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G5_IO2    G5_IO2
: TSC-IOHCR_G5_IO1   %1 16 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G5_IO1    G5_IO1
: TSC-IOHCR_G4_IO4   %1 15 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G4_IO4    G4_IO4
: TSC-IOHCR_G4_IO3   %1 14 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G4_IO3    G4_IO3
: TSC-IOHCR_G4_IO2   %1 13 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G4_IO2    G4_IO2
: TSC-IOHCR_G4_IO1   %1 12 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G4_IO1    G4_IO1
: TSC-IOHCR_G3_IO4   %1 11 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G3_IO4    G3_IO4
: TSC-IOHCR_G3_IO3   %1 10 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G3_IO3    G3_IO3
: TSC-IOHCR_G3_IO2   %1 9 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G3_IO2    G3_IO2
: TSC-IOHCR_G3_IO1   %1 8 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G3_IO1    G3_IO1
: TSC-IOHCR_G2_IO4   %1 7 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G2_IO4    G2_IO4
: TSC-IOHCR_G2_IO3   %1 6 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G2_IO3    G2_IO3
: TSC-IOHCR_G2_IO2   %1 5 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G2_IO2    G2_IO2
: TSC-IOHCR_G2_IO1   %1 4 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G2_IO1    G2_IO1
: TSC-IOHCR_G1_IO4   %1 3 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G1_IO4    G1_IO4
: TSC-IOHCR_G1_IO3   %1 2 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G1_IO3    G1_IO3
: TSC-IOHCR_G1_IO2   %1 1 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G1_IO2    G1_IO2
: TSC-IOHCR_G1_IO1   %1 0 lshift TSC-IOHCR bis! ;  \ TSC-IOHCR_G1_IO1    G1_IO1

\ TSC-IOASCR (read-write)
: TSC-IOASCR_G7_IO4   %1 27 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G7_IO4    G7_IO4
: TSC-IOASCR_G7_IO3   %1 26 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G7_IO3    G7_IO3
: TSC-IOASCR_G7_IO2   %1 25 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G7_IO2    G7_IO2
: TSC-IOASCR_G7_IO1   %1 24 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G7_IO1    G7_IO1
: TSC-IOASCR_G6_IO4   %1 23 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G6_IO4    G6_IO4
: TSC-IOASCR_G6_IO3   %1 22 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G6_IO3    G6_IO3
: TSC-IOASCR_G6_IO2   %1 21 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G6_IO2    G6_IO2
: TSC-IOASCR_G6_IO1   %1 20 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G6_IO1    G6_IO1
: TSC-IOASCR_G5_IO4   %1 19 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G5_IO4    G5_IO4
: TSC-IOASCR_G5_IO3   %1 18 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G5_IO3    G5_IO3
: TSC-IOASCR_G5_IO2   %1 17 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G5_IO2    G5_IO2
: TSC-IOASCR_G5_IO1   %1 16 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G5_IO1    G5_IO1
: TSC-IOASCR_G4_IO4   %1 15 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G4_IO4    G4_IO4
: TSC-IOASCR_G4_IO3   %1 14 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G4_IO3    G4_IO3
: TSC-IOASCR_G4_IO2   %1 13 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G4_IO2    G4_IO2
: TSC-IOASCR_G4_IO1   %1 12 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G4_IO1    G4_IO1
: TSC-IOASCR_G3_IO4   %1 11 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G3_IO4    G3_IO4
: TSC-IOASCR_G3_IO3   %1 10 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G3_IO3    G3_IO3
: TSC-IOASCR_G3_IO2   %1 9 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G3_IO2    G3_IO2
: TSC-IOASCR_G3_IO1   %1 8 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G3_IO1    G3_IO1
: TSC-IOASCR_G2_IO4   %1 7 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G2_IO4    G2_IO4
: TSC-IOASCR_G2_IO3   %1 6 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G2_IO3    G2_IO3
: TSC-IOASCR_G2_IO2   %1 5 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G2_IO2    G2_IO2
: TSC-IOASCR_G2_IO1   %1 4 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G2_IO1    G2_IO1
: TSC-IOASCR_G1_IO4   %1 3 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G1_IO4    G1_IO4
: TSC-IOASCR_G1_IO3   %1 2 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G1_IO3    G1_IO3
: TSC-IOASCR_G1_IO2   %1 1 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G1_IO2    G1_IO2
: TSC-IOASCR_G1_IO1   %1 0 lshift TSC-IOASCR bis! ;  \ TSC-IOASCR_G1_IO1    G1_IO1

\ TSC-IOSCR (read-write)
: TSC-IOSCR_G7_IO4   %1 27 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G7_IO4    G7_IO4
: TSC-IOSCR_G7_IO3   %1 26 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G7_IO3    G7_IO3
: TSC-IOSCR_G7_IO2   %1 25 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G7_IO2    G7_IO2
: TSC-IOSCR_G7_IO1   %1 24 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G7_IO1    G7_IO1
: TSC-IOSCR_G6_IO4   %1 23 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G6_IO4    G6_IO4
: TSC-IOSCR_G6_IO3   %1 22 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G6_IO3    G6_IO3
: TSC-IOSCR_G6_IO2   %1 21 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G6_IO2    G6_IO2
: TSC-IOSCR_G6_IO1   %1 20 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G6_IO1    G6_IO1
: TSC-IOSCR_G5_IO4   %1 19 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G5_IO4    G5_IO4
: TSC-IOSCR_G5_IO3   %1 18 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G5_IO3    G5_IO3
: TSC-IOSCR_G5_IO2   %1 17 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G5_IO2    G5_IO2
: TSC-IOSCR_G5_IO1   %1 16 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G5_IO1    G5_IO1
: TSC-IOSCR_G4_IO4   %1 15 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G4_IO4    G4_IO4
: TSC-IOSCR_G4_IO3   %1 14 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G4_IO3    G4_IO3
: TSC-IOSCR_G4_IO2   %1 13 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G4_IO2    G4_IO2
: TSC-IOSCR_G4_IO1   %1 12 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G4_IO1    G4_IO1
: TSC-IOSCR_G3_IO4   %1 11 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G3_IO4    G3_IO4
: TSC-IOSCR_G3_IO3   %1 10 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G3_IO3    G3_IO3
: TSC-IOSCR_G3_IO2   %1 9 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G3_IO2    G3_IO2
: TSC-IOSCR_G3_IO1   %1 8 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G3_IO1    G3_IO1
: TSC-IOSCR_G2_IO4   %1 7 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G2_IO4    G2_IO4
: TSC-IOSCR_G2_IO3   %1 6 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G2_IO3    G2_IO3
: TSC-IOSCR_G2_IO2   %1 5 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G2_IO2    G2_IO2
: TSC-IOSCR_G2_IO1   %1 4 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G2_IO1    G2_IO1
: TSC-IOSCR_G1_IO4   %1 3 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G1_IO4    G1_IO4
: TSC-IOSCR_G1_IO3   %1 2 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G1_IO3    G1_IO3
: TSC-IOSCR_G1_IO2   %1 1 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G1_IO2    G1_IO2
: TSC-IOSCR_G1_IO1   %1 0 lshift TSC-IOSCR bis! ;  \ TSC-IOSCR_G1_IO1    G1_IO1

\ TSC-IOCCR (read-write)
: TSC-IOCCR_G7_IO4   %1 27 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G7_IO4    G7_IO4
: TSC-IOCCR_G7_IO3   %1 26 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G7_IO3    G7_IO3
: TSC-IOCCR_G7_IO2   %1 25 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G7_IO2    G7_IO2
: TSC-IOCCR_G7_IO1   %1 24 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G7_IO1    G7_IO1
: TSC-IOCCR_G6_IO4   %1 23 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G6_IO4    G6_IO4
: TSC-IOCCR_G6_IO3   %1 22 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G6_IO3    G6_IO3
: TSC-IOCCR_G6_IO2   %1 21 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G6_IO2    G6_IO2
: TSC-IOCCR_G6_IO1   %1 20 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G6_IO1    G6_IO1
: TSC-IOCCR_G5_IO4   %1 19 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G5_IO4    G5_IO4
: TSC-IOCCR_G5_IO3   %1 18 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G5_IO3    G5_IO3
: TSC-IOCCR_G5_IO2   %1 17 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G5_IO2    G5_IO2
: TSC-IOCCR_G5_IO1   %1 16 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G5_IO1    G5_IO1
: TSC-IOCCR_G4_IO4   %1 15 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G4_IO4    G4_IO4
: TSC-IOCCR_G4_IO3   %1 14 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G4_IO3    G4_IO3
: TSC-IOCCR_G4_IO2   %1 13 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G4_IO2    G4_IO2
: TSC-IOCCR_G4_IO1   %1 12 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G4_IO1    G4_IO1
: TSC-IOCCR_G3_IO4   %1 11 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G3_IO4    G3_IO4
: TSC-IOCCR_G3_IO3   %1 10 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G3_IO3    G3_IO3
: TSC-IOCCR_G3_IO2   %1 9 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G3_IO2    G3_IO2
: TSC-IOCCR_G3_IO1   %1 8 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G3_IO1    G3_IO1
: TSC-IOCCR_G2_IO4   %1 7 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G2_IO4    G2_IO4
: TSC-IOCCR_G2_IO3   %1 6 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G2_IO3    G2_IO3
: TSC-IOCCR_G2_IO2   %1 5 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G2_IO2    G2_IO2
: TSC-IOCCR_G2_IO1   %1 4 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G2_IO1    G2_IO1
: TSC-IOCCR_G1_IO4   %1 3 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G1_IO4    G1_IO4
: TSC-IOCCR_G1_IO3   %1 2 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G1_IO3    G1_IO3
: TSC-IOCCR_G1_IO2   %1 1 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G1_IO2    G1_IO2
: TSC-IOCCR_G1_IO1   %1 0 lshift TSC-IOCCR bis! ;  \ TSC-IOCCR_G1_IO1    G1_IO1

\ TSC-IOGCSR ()
: TSC-IOGCSR_G7S   %1 22 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G7S    Analog I/O group x status
: TSC-IOGCSR_G6S   %1 21 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G6S    Analog I/O group x status
: TSC-IOGCSR_G5S   %1 20 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G5S    Analog I/O group x status
: TSC-IOGCSR_G4S   %1 19 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G4S    Analog I/O group x status
: TSC-IOGCSR_G3S   %1 18 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G3S    Analog I/O group x status
: TSC-IOGCSR_G2S   %1 17 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G2S    Analog I/O group x status
: TSC-IOGCSR_G1S   %1 16 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G1S    Analog I/O group x status
: TSC-IOGCSR_G7E   %1 6 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G7E    Analog I/O group x enable
: TSC-IOGCSR_G6E   %1 5 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G6E    Analog I/O group x enable
: TSC-IOGCSR_G5E   %1 4 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G5E    Analog I/O group x enable
: TSC-IOGCSR_G4E   %1 3 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G4E    Analog I/O group x enable
: TSC-IOGCSR_G3E   %1 2 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G3E    Analog I/O group x enable
: TSC-IOGCSR_G2E   %1 1 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G2E    Analog I/O group x enable
: TSC-IOGCSR_G1E   %1 0 lshift TSC-IOGCSR bis! ;  \ TSC-IOGCSR_G1E    Analog I/O group x enable

\ TSC-IOG1CR (read-only)
: TSC-IOG1CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG1CR bis! ;  \ TSC-IOG1CR_CNT    Counter value

\ TSC-IOG2CR (read-only)
: TSC-IOG2CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG2CR bis! ;  \ TSC-IOG2CR_CNT    Counter value

\ TSC-IOG3CR (read-only)
: TSC-IOG3CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG3CR bis! ;  \ TSC-IOG3CR_CNT    Counter value

\ TSC-IOG4CR (read-only)
: TSC-IOG4CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG4CR bis! ;  \ TSC-IOG4CR_CNT    Counter value

\ TSC-IOG5CR (read-only)
: TSC-IOG5CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG5CR bis! ;  \ TSC-IOG5CR_CNT    Counter value

\ TSC-IOG6CR (read-only)
: TSC-IOG6CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG6CR bis! ;  \ TSC-IOG6CR_CNT    Counter value

\ TSC-IOG7CR (read-only)
: TSC-IOG7CR_CNT   ( %XXXXXXXXXXXXXX -- ) 0 lshift TSC-IOG7CR bis! ;  \ TSC-IOG7CR_CNT    Counter value

\ IWDG-KR (write-only)
: IWDG-KR_KEY   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift IWDG-KR bis! ;  \ IWDG-KR_KEY    Key value write only, read $0000

\ IWDG-PR (read-write)
: IWDG-PR_PR   ( %XXX -- ) 0 lshift IWDG-PR bis! ;  \ IWDG-PR_PR    Prescaler divider

\ IWDG-RLR (read-write)
: IWDG-RLR_RL   ( %XXXXXXXXXXX -- ) 0 lshift IWDG-RLR bis! ;  \ IWDG-RLR_RL    Watchdog counter reload value

\ IWDG-SR (read-only)
: IWDG-SR_WVU   %1 2 lshift IWDG-SR bis! ;  \ IWDG-SR_WVU    Watchdog counter window value update
: IWDG-SR_RVU   %1 1 lshift IWDG-SR bis! ;  \ IWDG-SR_RVU    Watchdog counter reload value update
: IWDG-SR_PVU   %1 0 lshift IWDG-SR bis! ;  \ IWDG-SR_PVU    Watchdog prescaler value update

\ IWDG-WINR (read-write)
: IWDG-WINR_WIN   ( %XXXXXXXXXXX -- ) 0 lshift IWDG-WINR bis! ;  \ IWDG-WINR_WIN    Watchdog counter window value

\ WWDG-CR (read-write)
: WWDG-CR_WDGA   %1 7 lshift WWDG-CR bis! ;  \ WWDG-CR_WDGA    Activation bit
: WWDG-CR_T   ( %XXXXXXX -- ) 0 lshift WWDG-CR bis! ;  \ WWDG-CR_T    7-bit counter MSB to LSB

\ WWDG-CFR (read-write)
: WWDG-CFR_WDGTB   ( %XXX -- ) 11 lshift WWDG-CFR bis! ;  \ WWDG-CFR_WDGTB    Timer base
: WWDG-CFR_EWI   %1 9 lshift WWDG-CFR bis! ;  \ WWDG-CFR_EWI    Early wakeup interrupt
: WWDG-CFR_W   ( %XXXXXXX -- ) 0 lshift WWDG-CFR bis! ;  \ WWDG-CFR_W    7-bit window value

\ WWDG-SR (read-write)
: WWDG-SR_EWIF   %1 0 lshift WWDG-SR bis! ;  \ WWDG-SR_EWIF    Early wakeup interrupt flag

\ COMP-COMP1_CSR ()
: COMP-COMP1_CSR_COMP1_EN   %1 0 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_EN    Comparator enable
: COMP-COMP1_CSR_COMP1_PWRMODE   ( %XX -- ) 2 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_PWRMODE    Comparator power mode
: COMP-COMP1_CSR_COMP1_INMSEL   ( %XXX -- ) 4 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_INMSEL    Comparator input minus selection
: COMP-COMP1_CSR_COMP1_INPSEL   ( %XX -- ) 7 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_INPSEL    Comparator input plus selection
: COMP-COMP1_CSR_COMP1_POLARITY   %1 15 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_POLARITY    Comparator output polarity
: COMP-COMP1_CSR_COMP1_HYST   ( %XX -- ) 16 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_HYST    Comparator hysteresis
: COMP-COMP1_CSR_COMP1_BLANKING   ( %XXX -- ) 18 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_BLANKING    Comparator blanking source
: COMP-COMP1_CSR_COMP1_BRGEN   %1 22 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_BRGEN    Comparator voltage scaler enable
: COMP-COMP1_CSR_COMP1_SCALEN   %1 23 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_SCALEN    Comparator scaler bridge enable
: COMP-COMP1_CSR_COMP1_INMESEL   ( %XX -- ) 25 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_INMESEL    Comparator input minus extended selection
: COMP-COMP1_CSR_COMP1_VALUE   %1 30 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_VALUE    Comparator output level
: COMP-COMP1_CSR_COMP1_LOCK   %1 31 lshift COMP-COMP1_CSR bis! ;  \ COMP-COMP1_CSR_COMP1_LOCK    Comparator lock

\ COMP-COMP2_CSR ()
: COMP-COMP2_CSR_COMP2_EN   %1 0 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_EN    Comparator 2 enable bit
: COMP-COMP2_CSR_COMP2_PWRMODE   ( %XX -- ) 2 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_PWRMODE    Power Mode of the comparator 2
: COMP-COMP2_CSR_COMP2_INMSEL   ( %XX -- ) 4 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_INMSEL    Comparator 2 input minus selection bits
: COMP-COMP2_CSR_COMP2_INPSEL   ( %XX -- ) 7 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_INPSEL    Comparator 1 input plus selection bit
: COMP-COMP2_CSR_COMP2_WINMODE   %1 9 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_WINMODE    Windows mode selection bit
: COMP-COMP2_CSR_COMP2_POLARITY   %1 15 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_POLARITY    Comparator 2 polarity selection bit
: COMP-COMP2_CSR_COMP2_HYST   ( %XX -- ) 16 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_HYST    Comparator 2 hysteresis selection bits
: COMP-COMP2_CSR_COMP2_BLANKING   ( %XXX -- ) 18 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_BLANKING    Comparator 2 blanking source selection bits
: COMP-COMP2_CSR_COMP2_BRGEN   %1 22 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_BRGEN    Scaler bridge enable
: COMP-COMP2_CSR_COMP2_SCALEN   %1 23 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_SCALEN    Voltage scaler enable bit
: COMP-COMP2_CSR_COMP2_INMESEL   ( %XX -- ) 25 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_INMESEL    comparator 2 input minus extended selection bits.
: COMP-COMP2_CSR_COMP2_VALUE   %1 30 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_VALUE    Comparator 2 output status bit
: COMP-COMP2_CSR_COMP2_LOCK   %1 31 lshift COMP-COMP2_CSR bis! ;  \ COMP-COMP2_CSR_COMP2_LOCK    CSR register lock bit

\ I2C1-CR1 (read-write)
: I2C1-CR1_PE   %1 0 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_PE    Peripheral enable
: I2C1-CR1_TXIE   %1 1 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_TXIE    TX Interrupt enable
: I2C1-CR1_RXIE   %1 2 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_RXIE    RX Interrupt enable
: I2C1-CR1_ADDRIE   %1 3 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_ADDRIE    Address match interrupt enable slave only
: I2C1-CR1_NACKIE   %1 4 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_NACKIE    Not acknowledge received interrupt enable
: I2C1-CR1_STOPIE   %1 5 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_STOPIE    STOP detection Interrupt enable
: I2C1-CR1_TCIE   %1 6 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_TCIE    Transfer Complete interrupt enable
: I2C1-CR1_ERRIE   %1 7 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_ERRIE    Error interrupts enable
: I2C1-CR1_DNF   ( %XXXX -- ) 8 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_DNF    Digital noise filter
: I2C1-CR1_ANFOFF   %1 12 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_ANFOFF    Analog noise filter OFF
: I2C1-CR1_TXDMAEN   %1 14 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_TXDMAEN    DMA transmission requests enable
: I2C1-CR1_RXDMAEN   %1 15 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_RXDMAEN    DMA reception requests enable
: I2C1-CR1_SBC   %1 16 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_SBC    Slave byte control
: I2C1-CR1_NOSTRETCH   %1 17 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_NOSTRETCH    Clock stretching disable
: I2C1-CR1_WUPEN   %1 18 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_WUPEN    Wakeup from STOP enable
: I2C1-CR1_GCEN   %1 19 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_GCEN    General call enable
: I2C1-CR1_SMBHEN   %1 20 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_SMBHEN    SMBus Host address enable
: I2C1-CR1_SMBDEN   %1 21 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_SMBDEN    SMBus Device Default address enable
: I2C1-CR1_ALERTEN   %1 22 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_ALERTEN    SMBUS alert enable
: I2C1-CR1_PECEN   %1 23 lshift I2C1-CR1 bis! ;  \ I2C1-CR1_PECEN    PEC enable

\ I2C1-CR2 (read-write)
: I2C1-CR2_PECBYTE   %1 26 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_PECBYTE    Packet error checking byte
: I2C1-CR2_AUTOEND   %1 25 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_AUTOEND    Automatic end mode master mode
: I2C1-CR2_RELOAD   %1 24 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_RELOAD    NBYTES reload mode
: I2C1-CR2_NBYTES   ( %XXXXXXXX -- ) 16 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_NBYTES    Number of bytes
: I2C1-CR2_NACK   %1 15 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_NACK    NACK generation slave mode
: I2C1-CR2_STOP   %1 14 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_STOP    Stop generation master mode
: I2C1-CR2_START   %1 13 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_START    Start generation
: I2C1-CR2_HEAD10R   %1 12 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_HEAD10R    10-bit address header only read direction master receiver mode
: I2C1-CR2_ADD10   %1 11 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_ADD10    10-bit addressing mode master mode
: I2C1-CR2_RD_WRN   %1 10 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_RD_WRN    Transfer direction master mode
: I2C1-CR2_SADD  0 lshift I2C1-CR2 bis! ;  \ I2C1-CR2_SADD    Slave address bit master mode

\ I2C1-OAR1 (read-write)
: I2C1-OAR1_OA1  0 lshift I2C1-OAR1 bis! ;  \ I2C1-OAR1_OA1    Interface address
: I2C1-OAR1_OA1MODE   %1 10 lshift I2C1-OAR1 bis! ;  \ I2C1-OAR1_OA1MODE    Own Address 1 10-bit mode
: I2C1-OAR1_OA1EN   %1 15 lshift I2C1-OAR1 bis! ;  \ I2C1-OAR1_OA1EN    Own Address 1 enable

\ I2C1-OAR2 (read-write)
: I2C1-OAR2_OA2   ( %XXXXXXX -- ) 1 lshift I2C1-OAR2 bis! ;  \ I2C1-OAR2_OA2    Interface address
: I2C1-OAR2_OA2MSK   ( %XXX -- ) 8 lshift I2C1-OAR2 bis! ;  \ I2C1-OAR2_OA2MSK    Own Address 2 masks
: I2C1-OAR2_OA2EN   %1 15 lshift I2C1-OAR2 bis! ;  \ I2C1-OAR2_OA2EN    Own Address 2 enable

\ I2C1-TIMINGR (read-write)
: I2C1-TIMINGR_SCLL   ( %XXXXXXXX -- ) 0 lshift I2C1-TIMINGR bis! ;  \ I2C1-TIMINGR_SCLL    SCL low period master mode
: I2C1-TIMINGR_SCLH   ( %XXXXXXXX -- ) 8 lshift I2C1-TIMINGR bis! ;  \ I2C1-TIMINGR_SCLH    SCL high period master mode
: I2C1-TIMINGR_SDADEL   ( %XXXX -- ) 16 lshift I2C1-TIMINGR bis! ;  \ I2C1-TIMINGR_SDADEL    Data hold time
: I2C1-TIMINGR_SCLDEL   ( %XXXX -- ) 20 lshift I2C1-TIMINGR bis! ;  \ I2C1-TIMINGR_SCLDEL    Data setup time
: I2C1-TIMINGR_PRESC   ( %XXXX -- ) 28 lshift I2C1-TIMINGR bis! ;  \ I2C1-TIMINGR_PRESC    Timing prescaler

\ I2C1-TIMEOUTR (read-write)
: I2C1-TIMEOUTR_TIMEOUTA   ( %XXXXXXXXXXX -- ) 0 lshift I2C1-TIMEOUTR bis! ;  \ I2C1-TIMEOUTR_TIMEOUTA    Bus timeout A
: I2C1-TIMEOUTR_TIDLE   %1 12 lshift I2C1-TIMEOUTR bis! ;  \ I2C1-TIMEOUTR_TIDLE    Idle clock timeout detection
: I2C1-TIMEOUTR_TIMOUTEN   %1 15 lshift I2C1-TIMEOUTR bis! ;  \ I2C1-TIMEOUTR_TIMOUTEN    Clock timeout enable
: I2C1-TIMEOUTR_TIMEOUTB   ( %XXXXXXXXXXX -- ) 16 lshift I2C1-TIMEOUTR bis! ;  \ I2C1-TIMEOUTR_TIMEOUTB    Bus timeout B
: I2C1-TIMEOUTR_TEXTEN   %1 31 lshift I2C1-TIMEOUTR bis! ;  \ I2C1-TIMEOUTR_TEXTEN    Extended clock timeout enable

\ I2C1-ISR ()
: I2C1-ISR_ADDCODE   ( %XXXXXXX -- ) 17 lshift I2C1-ISR bis! ;  \ I2C1-ISR_ADDCODE    Address match code Slave mode
: I2C1-ISR_DIR   %1 16 lshift I2C1-ISR bis! ;  \ I2C1-ISR_DIR    Transfer direction Slave mode
: I2C1-ISR_BUSY   %1 15 lshift I2C1-ISR bis! ;  \ I2C1-ISR_BUSY    Bus busy
: I2C1-ISR_ALERT   %1 13 lshift I2C1-ISR bis! ;  \ I2C1-ISR_ALERT    SMBus alert
: I2C1-ISR_TIMEOUT   %1 12 lshift I2C1-ISR bis! ;  \ I2C1-ISR_TIMEOUT    Timeout or t_low detection flag
: I2C1-ISR_PECERR   %1 11 lshift I2C1-ISR bis! ;  \ I2C1-ISR_PECERR    PEC Error in reception
: I2C1-ISR_OVR   %1 10 lshift I2C1-ISR bis! ;  \ I2C1-ISR_OVR    Overrun/Underrun slave mode
: I2C1-ISR_ARLO   %1 9 lshift I2C1-ISR bis! ;  \ I2C1-ISR_ARLO    Arbitration lost
: I2C1-ISR_BERR   %1 8 lshift I2C1-ISR bis! ;  \ I2C1-ISR_BERR    Bus error
: I2C1-ISR_TCR   %1 7 lshift I2C1-ISR bis! ;  \ I2C1-ISR_TCR    Transfer Complete Reload
: I2C1-ISR_TC   %1 6 lshift I2C1-ISR bis! ;  \ I2C1-ISR_TC    Transfer Complete master mode
: I2C1-ISR_STOPF   %1 5 lshift I2C1-ISR bis! ;  \ I2C1-ISR_STOPF    Stop detection flag
: I2C1-ISR_NACKF   %1 4 lshift I2C1-ISR bis! ;  \ I2C1-ISR_NACKF    Not acknowledge received flag
: I2C1-ISR_ADDR   %1 3 lshift I2C1-ISR bis! ;  \ I2C1-ISR_ADDR    Address matched slave mode
: I2C1-ISR_RXNE   %1 2 lshift I2C1-ISR bis! ;  \ I2C1-ISR_RXNE    Receive data register not empty receivers
: I2C1-ISR_TXIS   %1 1 lshift I2C1-ISR bis! ;  \ I2C1-ISR_TXIS    Transmit interrupt status transmitters
: I2C1-ISR_TXE   %1 0 lshift I2C1-ISR bis! ;  \ I2C1-ISR_TXE    Transmit data register empty transmitters

\ I2C1-ICR (write-only)
: I2C1-ICR_ALERTCF   %1 13 lshift I2C1-ICR bis! ;  \ I2C1-ICR_ALERTCF    Alert flag clear
: I2C1-ICR_TIMOUTCF   %1 12 lshift I2C1-ICR bis! ;  \ I2C1-ICR_TIMOUTCF    Timeout detection flag clear
: I2C1-ICR_PECCF   %1 11 lshift I2C1-ICR bis! ;  \ I2C1-ICR_PECCF    PEC Error flag clear
: I2C1-ICR_OVRCF   %1 10 lshift I2C1-ICR bis! ;  \ I2C1-ICR_OVRCF    Overrun/Underrun flag clear
: I2C1-ICR_ARLOCF   %1 9 lshift I2C1-ICR bis! ;  \ I2C1-ICR_ARLOCF    Arbitration lost flag clear
: I2C1-ICR_BERRCF   %1 8 lshift I2C1-ICR bis! ;  \ I2C1-ICR_BERRCF    Bus error flag clear
: I2C1-ICR_STOPCF   %1 5 lshift I2C1-ICR bis! ;  \ I2C1-ICR_STOPCF    Stop detection flag clear
: I2C1-ICR_NACKCF   %1 4 lshift I2C1-ICR bis! ;  \ I2C1-ICR_NACKCF    Not Acknowledge flag clear
: I2C1-ICR_ADDRCF   %1 3 lshift I2C1-ICR bis! ;  \ I2C1-ICR_ADDRCF    Address Matched flag clear

\ I2C1-PECR (read-only)
: I2C1-PECR_PEC   ( %XXXXXXXX -- ) 0 lshift I2C1-PECR bis! ;  \ I2C1-PECR_PEC    Packet error checking register

\ I2C1-RXDR (read-only)
: I2C1-RXDR_RXDATA   ( %XXXXXXXX -- ) 0 lshift I2C1-RXDR bis! ;  \ I2C1-RXDR_RXDATA    8-bit receive data

\ I2C1-TXDR (read-write)
: I2C1-TXDR_TXDATA   ( %XXXXXXXX -- ) 0 lshift I2C1-TXDR bis! ;  \ I2C1-TXDR_TXDATA    8-bit transmit data

\ I2C3-CR1 (read-write)
: I2C3-CR1_PE   %1 0 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_PE    Peripheral enable
: I2C3-CR1_TXIE   %1 1 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_TXIE    TX Interrupt enable
: I2C3-CR1_RXIE   %1 2 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_RXIE    RX Interrupt enable
: I2C3-CR1_ADDRIE   %1 3 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_ADDRIE    Address match interrupt enable slave only
: I2C3-CR1_NACKIE   %1 4 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_NACKIE    Not acknowledge received interrupt enable
: I2C3-CR1_STOPIE   %1 5 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_STOPIE    STOP detection Interrupt enable
: I2C3-CR1_TCIE   %1 6 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_TCIE    Transfer Complete interrupt enable
: I2C3-CR1_ERRIE   %1 7 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_ERRIE    Error interrupts enable
: I2C3-CR1_DNF   ( %XXXX -- ) 8 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_DNF    Digital noise filter
: I2C3-CR1_ANFOFF   %1 12 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_ANFOFF    Analog noise filter OFF
: I2C3-CR1_TXDMAEN   %1 14 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_TXDMAEN    DMA transmission requests enable
: I2C3-CR1_RXDMAEN   %1 15 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_RXDMAEN    DMA reception requests enable
: I2C3-CR1_SBC   %1 16 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_SBC    Slave byte control
: I2C3-CR1_NOSTRETCH   %1 17 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_NOSTRETCH    Clock stretching disable
: I2C3-CR1_WUPEN   %1 18 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_WUPEN    Wakeup from STOP enable
: I2C3-CR1_GCEN   %1 19 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_GCEN    General call enable
: I2C3-CR1_SMBHEN   %1 20 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_SMBHEN    SMBus Host address enable
: I2C3-CR1_SMBDEN   %1 21 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_SMBDEN    SMBus Device Default address enable
: I2C3-CR1_ALERTEN   %1 22 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_ALERTEN    SMBUS alert enable
: I2C3-CR1_PECEN   %1 23 lshift I2C3-CR1 bis! ;  \ I2C3-CR1_PECEN    PEC enable

\ I2C3-CR2 (read-write)
: I2C3-CR2_PECBYTE   %1 26 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_PECBYTE    Packet error checking byte
: I2C3-CR2_AUTOEND   %1 25 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_AUTOEND    Automatic end mode master mode
: I2C3-CR2_RELOAD   %1 24 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_RELOAD    NBYTES reload mode
: I2C3-CR2_NBYTES   ( %XXXXXXXX -- ) 16 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_NBYTES    Number of bytes
: I2C3-CR2_NACK   %1 15 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_NACK    NACK generation slave mode
: I2C3-CR2_STOP   %1 14 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_STOP    Stop generation master mode
: I2C3-CR2_START   %1 13 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_START    Start generation
: I2C3-CR2_HEAD10R   %1 12 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_HEAD10R    10-bit address header only read direction master receiver mode
: I2C3-CR2_ADD10   %1 11 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_ADD10    10-bit addressing mode master mode
: I2C3-CR2_RD_WRN   %1 10 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_RD_WRN    Transfer direction master mode
: I2C3-CR2_SADD  0 lshift I2C3-CR2 bis! ;  \ I2C3-CR2_SADD    Slave address bit master mode

\ I2C3-OAR1 (read-write)
: I2C3-OAR1_OA1  0 lshift I2C3-OAR1 bis! ;  \ I2C3-OAR1_OA1    Interface address
: I2C3-OAR1_OA1MODE   %1 10 lshift I2C3-OAR1 bis! ;  \ I2C3-OAR1_OA1MODE    Own Address 1 10-bit mode
: I2C3-OAR1_OA1EN   %1 15 lshift I2C3-OAR1 bis! ;  \ I2C3-OAR1_OA1EN    Own Address 1 enable

\ I2C3-OAR2 (read-write)
: I2C3-OAR2_OA2   ( %XXXXXXX -- ) 1 lshift I2C3-OAR2 bis! ;  \ I2C3-OAR2_OA2    Interface address
: I2C3-OAR2_OA2MSK   ( %XXX -- ) 8 lshift I2C3-OAR2 bis! ;  \ I2C3-OAR2_OA2MSK    Own Address 2 masks
: I2C3-OAR2_OA2EN   %1 15 lshift I2C3-OAR2 bis! ;  \ I2C3-OAR2_OA2EN    Own Address 2 enable

\ I2C3-TIMINGR (read-write)
: I2C3-TIMINGR_SCLL   ( %XXXXXXXX -- ) 0 lshift I2C3-TIMINGR bis! ;  \ I2C3-TIMINGR_SCLL    SCL low period master mode
: I2C3-TIMINGR_SCLH   ( %XXXXXXXX -- ) 8 lshift I2C3-TIMINGR bis! ;  \ I2C3-TIMINGR_SCLH    SCL high period master mode
: I2C3-TIMINGR_SDADEL   ( %XXXX -- ) 16 lshift I2C3-TIMINGR bis! ;  \ I2C3-TIMINGR_SDADEL    Data hold time
: I2C3-TIMINGR_SCLDEL   ( %XXXX -- ) 20 lshift I2C3-TIMINGR bis! ;  \ I2C3-TIMINGR_SCLDEL    Data setup time
: I2C3-TIMINGR_PRESC   ( %XXXX -- ) 28 lshift I2C3-TIMINGR bis! ;  \ I2C3-TIMINGR_PRESC    Timing prescaler

\ I2C3-TIMEOUTR (read-write)
: I2C3-TIMEOUTR_TIMEOUTA   ( %XXXXXXXXXXX -- ) 0 lshift I2C3-TIMEOUTR bis! ;  \ I2C3-TIMEOUTR_TIMEOUTA    Bus timeout A
: I2C3-TIMEOUTR_TIDLE   %1 12 lshift I2C3-TIMEOUTR bis! ;  \ I2C3-TIMEOUTR_TIDLE    Idle clock timeout detection
: I2C3-TIMEOUTR_TIMOUTEN   %1 15 lshift I2C3-TIMEOUTR bis! ;  \ I2C3-TIMEOUTR_TIMOUTEN    Clock timeout enable
: I2C3-TIMEOUTR_TIMEOUTB   ( %XXXXXXXXXXX -- ) 16 lshift I2C3-TIMEOUTR bis! ;  \ I2C3-TIMEOUTR_TIMEOUTB    Bus timeout B
: I2C3-TIMEOUTR_TEXTEN   %1 31 lshift I2C3-TIMEOUTR bis! ;  \ I2C3-TIMEOUTR_TEXTEN    Extended clock timeout enable

\ I2C3-ISR ()
: I2C3-ISR_ADDCODE   ( %XXXXXXX -- ) 17 lshift I2C3-ISR bis! ;  \ I2C3-ISR_ADDCODE    Address match code Slave mode
: I2C3-ISR_DIR   %1 16 lshift I2C3-ISR bis! ;  \ I2C3-ISR_DIR    Transfer direction Slave mode
: I2C3-ISR_BUSY   %1 15 lshift I2C3-ISR bis! ;  \ I2C3-ISR_BUSY    Bus busy
: I2C3-ISR_ALERT   %1 13 lshift I2C3-ISR bis! ;  \ I2C3-ISR_ALERT    SMBus alert
: I2C3-ISR_TIMEOUT   %1 12 lshift I2C3-ISR bis! ;  \ I2C3-ISR_TIMEOUT    Timeout or t_low detection flag
: I2C3-ISR_PECERR   %1 11 lshift I2C3-ISR bis! ;  \ I2C3-ISR_PECERR    PEC Error in reception
: I2C3-ISR_OVR   %1 10 lshift I2C3-ISR bis! ;  \ I2C3-ISR_OVR    Overrun/Underrun slave mode
: I2C3-ISR_ARLO   %1 9 lshift I2C3-ISR bis! ;  \ I2C3-ISR_ARLO    Arbitration lost
: I2C3-ISR_BERR   %1 8 lshift I2C3-ISR bis! ;  \ I2C3-ISR_BERR    Bus error
: I2C3-ISR_TCR   %1 7 lshift I2C3-ISR bis! ;  \ I2C3-ISR_TCR    Transfer Complete Reload
: I2C3-ISR_TC   %1 6 lshift I2C3-ISR bis! ;  \ I2C3-ISR_TC    Transfer Complete master mode
: I2C3-ISR_STOPF   %1 5 lshift I2C3-ISR bis! ;  \ I2C3-ISR_STOPF    Stop detection flag
: I2C3-ISR_NACKF   %1 4 lshift I2C3-ISR bis! ;  \ I2C3-ISR_NACKF    Not acknowledge received flag
: I2C3-ISR_ADDR   %1 3 lshift I2C3-ISR bis! ;  \ I2C3-ISR_ADDR    Address matched slave mode
: I2C3-ISR_RXNE   %1 2 lshift I2C3-ISR bis! ;  \ I2C3-ISR_RXNE    Receive data register not empty receivers
: I2C3-ISR_TXIS   %1 1 lshift I2C3-ISR bis! ;  \ I2C3-ISR_TXIS    Transmit interrupt status transmitters
: I2C3-ISR_TXE   %1 0 lshift I2C3-ISR bis! ;  \ I2C3-ISR_TXE    Transmit data register empty transmitters

\ I2C3-ICR (write-only)
: I2C3-ICR_ALERTCF   %1 13 lshift I2C3-ICR bis! ;  \ I2C3-ICR_ALERTCF    Alert flag clear
: I2C3-ICR_TIMOUTCF   %1 12 lshift I2C3-ICR bis! ;  \ I2C3-ICR_TIMOUTCF    Timeout detection flag clear
: I2C3-ICR_PECCF   %1 11 lshift I2C3-ICR bis! ;  \ I2C3-ICR_PECCF    PEC Error flag clear
: I2C3-ICR_OVRCF   %1 10 lshift I2C3-ICR bis! ;  \ I2C3-ICR_OVRCF    Overrun/Underrun flag clear
: I2C3-ICR_ARLOCF   %1 9 lshift I2C3-ICR bis! ;  \ I2C3-ICR_ARLOCF    Arbitration lost flag clear
: I2C3-ICR_BERRCF   %1 8 lshift I2C3-ICR bis! ;  \ I2C3-ICR_BERRCF    Bus error flag clear
: I2C3-ICR_STOPCF   %1 5 lshift I2C3-ICR bis! ;  \ I2C3-ICR_STOPCF    Stop detection flag clear
: I2C3-ICR_NACKCF   %1 4 lshift I2C3-ICR bis! ;  \ I2C3-ICR_NACKCF    Not Acknowledge flag clear
: I2C3-ICR_ADDRCF   %1 3 lshift I2C3-ICR bis! ;  \ I2C3-ICR_ADDRCF    Address Matched flag clear

\ I2C3-PECR (read-only)
: I2C3-PECR_PEC   ( %XXXXXXXX -- ) 0 lshift I2C3-PECR bis! ;  \ I2C3-PECR_PEC    Packet error checking register

\ I2C3-RXDR (read-only)
: I2C3-RXDR_RXDATA   ( %XXXXXXXX -- ) 0 lshift I2C3-RXDR bis! ;  \ I2C3-RXDR_RXDATA    8-bit receive data

\ I2C3-TXDR (read-write)
: I2C3-TXDR_TXDATA   ( %XXXXXXXX -- ) 0 lshift I2C3-TXDR bis! ;  \ I2C3-TXDR_TXDATA    8-bit transmit data

\ Flash-ACR (read-write)
: Flash-ACR_LATENCY   ( %XXX -- ) 0 lshift Flash-ACR bis! ;  \ Flash-ACR_LATENCY    Latency
: Flash-ACR_PRFTEN   %1 8 lshift Flash-ACR bis! ;  \ Flash-ACR_PRFTEN    Prefetch enable
: Flash-ACR_ICEN   %1 9 lshift Flash-ACR bis! ;  \ Flash-ACR_ICEN    Instruction cache enable
: Flash-ACR_DCEN   %1 10 lshift Flash-ACR bis! ;  \ Flash-ACR_DCEN    Data cache enable
: Flash-ACR_ICRST   %1 11 lshift Flash-ACR bis! ;  \ Flash-ACR_ICRST    Instruction cache reset
: Flash-ACR_DCRST   %1 12 lshift Flash-ACR bis! ;  \ Flash-ACR_DCRST    Data cache reset
: Flash-ACR_PES   %1 15 lshift Flash-ACR bis! ;  \ Flash-ACR_PES    CPU1 CortexM4 program erase suspend request
: Flash-ACR_EMPTY   %1 16 lshift Flash-ACR bis! ;  \ Flash-ACR_EMPTY    Flash User area empty

\ Flash-KEYR (write-only)
: Flash-KEYR_KEYR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift Flash-KEYR bis! ;  \ Flash-KEYR_KEYR    KEYR

\ Flash-OPTKEYR (write-only)
: Flash-OPTKEYR_OPTKEYR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift Flash-OPTKEYR bis! ;  \ Flash-OPTKEYR_OPTKEYR    Option byte key

\ Flash-SR ()
: Flash-SR_EOP   %1 0 lshift Flash-SR bis! ;  \ Flash-SR_EOP    End of operation
: Flash-SR_OPERR   %1 1 lshift Flash-SR bis! ;  \ Flash-SR_OPERR    Operation error
: Flash-SR_PROGERR   %1 3 lshift Flash-SR bis! ;  \ Flash-SR_PROGERR    Programming error
: Flash-SR_WRPERR   %1 4 lshift Flash-SR bis! ;  \ Flash-SR_WRPERR    Write protected error
: Flash-SR_PGAERR   %1 5 lshift Flash-SR bis! ;  \ Flash-SR_PGAERR    Programming alignment error
: Flash-SR_SIZERR   %1 6 lshift Flash-SR bis! ;  \ Flash-SR_SIZERR    Size error
: Flash-SR_PGSERR   %1 7 lshift Flash-SR bis! ;  \ Flash-SR_PGSERR    Programming sequence error
: Flash-SR_MISERR   %1 8 lshift Flash-SR bis! ;  \ Flash-SR_MISERR    Fast programming data miss error
: Flash-SR_FASTERR   %1 9 lshift Flash-SR bis! ;  \ Flash-SR_FASTERR    Fast programming error
: Flash-SR_OPTNV   %1 13 lshift Flash-SR bis! ;  \ Flash-SR_OPTNV    User Option OPTVAL indication
: Flash-SR_RDERR   %1 14 lshift Flash-SR bis! ;  \ Flash-SR_RDERR    PCROP read error
: Flash-SR_OPTVERR   %1 15 lshift Flash-SR bis! ;  \ Flash-SR_OPTVERR    Option validity error
: Flash-SR_BSY   %1 16 lshift Flash-SR bis! ;  \ Flash-SR_BSY    Busy
: Flash-SR_CFGBSY   %1 18 lshift Flash-SR bis! ;  \ Flash-SR_CFGBSY    Programming or erase configuration busy
: Flash-SR_PESD   %1 19 lshift Flash-SR bis! ;  \ Flash-SR_PESD    Programming or erase operation suspended

\ Flash-CR (read-write)
: Flash-CR_PG   %1 0 lshift Flash-CR bis! ;  \ Flash-CR_PG    Programming
: Flash-CR_PER   %1 1 lshift Flash-CR bis! ;  \ Flash-CR_PER    Page erase
: Flash-CR_MER   %1 2 lshift Flash-CR bis! ;  \ Flash-CR_MER    This bit triggers the mass erase all user pages when set
: Flash-CR_PNB   ( %XXXXXXXX -- ) 3 lshift Flash-CR bis! ;  \ Flash-CR_PNB    Page number selection
: Flash-CR_STRT   %1 16 lshift Flash-CR bis! ;  \ Flash-CR_STRT    Start
: Flash-CR_OPTSTRT   %1 17 lshift Flash-CR bis! ;  \ Flash-CR_OPTSTRT    Options modification start
: Flash-CR_FSTPG   %1 18 lshift Flash-CR bis! ;  \ Flash-CR_FSTPG    Fast programming
: Flash-CR_EOPIE   %1 24 lshift Flash-CR bis! ;  \ Flash-CR_EOPIE    End of operation interrupt enable
: Flash-CR_ERRIE   %1 25 lshift Flash-CR bis! ;  \ Flash-CR_ERRIE    Error interrupt enable
: Flash-CR_RDERRIE   %1 26 lshift Flash-CR bis! ;  \ Flash-CR_RDERRIE    PCROP read error interrupt enable
: Flash-CR_OBL_LAUNCH   %1 27 lshift Flash-CR bis! ;  \ Flash-CR_OBL_LAUNCH    Force the option byte loading
: Flash-CR_OPTLOCK   %1 30 lshift Flash-CR bis! ;  \ Flash-CR_OPTLOCK    Options Lock
: Flash-CR_LOCK   %1 31 lshift Flash-CR bis! ;  \ Flash-CR_LOCK    FLASH_CR Lock

\ Flash-ECCR ()
: Flash-ECCR_ADDR_ECC  0 lshift Flash-ECCR bis! ;  \ Flash-ECCR_ADDR_ECC    ECC fail address
: Flash-ECCR_SYSF_ECC   %1 20 lshift Flash-ECCR bis! ;  \ Flash-ECCR_SYSF_ECC    System Flash ECC fail
: Flash-ECCR_ECCCIE   %1 24 lshift Flash-ECCR bis! ;  \ Flash-ECCR_ECCCIE    ECC correction interrupt enable
: Flash-ECCR_CPUID   ( %XXX -- ) 26 lshift Flash-ECCR bis! ;  \ Flash-ECCR_CPUID    CPU identification
: Flash-ECCR_ECCC   %1 30 lshift Flash-ECCR bis! ;  \ Flash-ECCR_ECCC    ECC correction
: Flash-ECCR_ECCD   %1 31 lshift Flash-ECCR bis! ;  \ Flash-ECCR_ECCD    ECC detection

\ Flash-OPTR (read-write)
: Flash-OPTR_RDP   ( %XXXXXXXX -- ) 0 lshift Flash-OPTR bis! ;  \ Flash-OPTR_RDP    Read protection level
: Flash-OPTR_ESE   %1 8 lshift Flash-OPTR bis! ;  \ Flash-OPTR_ESE    Security enabled
: Flash-OPTR_BOR_LEV   ( %XXX -- ) 9 lshift Flash-OPTR bis! ;  \ Flash-OPTR_BOR_LEV    BOR reset Level
: Flash-OPTR_nRST_STOP   %1 12 lshift Flash-OPTR bis! ;  \ Flash-OPTR_nRST_STOP    nRST_STOP
: Flash-OPTR_nRST_STDBY   %1 13 lshift Flash-OPTR bis! ;  \ Flash-OPTR_nRST_STDBY    nRST_STDBY
: Flash-OPTR_nRST_SHDW   %1 14 lshift Flash-OPTR bis! ;  \ Flash-OPTR_nRST_SHDW    nRST_SHDW
: Flash-OPTR_IDWG_SW   %1 16 lshift Flash-OPTR bis! ;  \ Flash-OPTR_IDWG_SW    Independent watchdog selection
: Flash-OPTR_IWDG_STOP   %1 17 lshift Flash-OPTR bis! ;  \ Flash-OPTR_IWDG_STOP    Independent watchdog counter freeze in Stop mode
: Flash-OPTR_IWDG_STDBY   %1 18 lshift Flash-OPTR bis! ;  \ Flash-OPTR_IWDG_STDBY    Independent watchdog counter freeze in Standby mode
: Flash-OPTR_WWDG_SW   %1 19 lshift Flash-OPTR bis! ;  \ Flash-OPTR_WWDG_SW    Window watchdog selection
: Flash-OPTR_nBOOT1   %1 23 lshift Flash-OPTR bis! ;  \ Flash-OPTR_nBOOT1    Boot configuration
: Flash-OPTR_SRAM2_PE   %1 24 lshift Flash-OPTR bis! ;  \ Flash-OPTR_SRAM2_PE    SRAM2 parity check enable
: Flash-OPTR_SRAM2_RST   %1 25 lshift Flash-OPTR bis! ;  \ Flash-OPTR_SRAM2_RST    SRAM2 Erase when system reset
: Flash-OPTR_nSWBOOT0   %1 26 lshift Flash-OPTR bis! ;  \ Flash-OPTR_nSWBOOT0    Software Boot0
: Flash-OPTR_nBOOT0   %1 27 lshift Flash-OPTR bis! ;  \ Flash-OPTR_nBOOT0    nBoot0 option bit
: Flash-OPTR_AGC_TRIM   ( %XXX -- ) 29 lshift Flash-OPTR bis! ;  \ Flash-OPTR_AGC_TRIM    Radio Automatic Gain Control Trimming

\ Flash-PCROP1ASR (read-write)
: Flash-PCROP1ASR_PCROP1A_STRT   ( %XXXXXXXXX -- ) 0 lshift Flash-PCROP1ASR bis! ;  \ Flash-PCROP1ASR_PCROP1A_STRT    Bank 1 PCROPQ area start offset

\ Flash-PCROP1AER (read-write)
: Flash-PCROP1AER_PCROP1A_END   ( %XXXXXXXXX -- ) 0 lshift Flash-PCROP1AER bis! ;  \ Flash-PCROP1AER_PCROP1A_END    Bank 1 PCROP area end offset
: Flash-PCROP1AER_PCROP_RDP   %1 31 lshift Flash-PCROP1AER bis! ;  \ Flash-PCROP1AER_PCROP_RDP    PCROP area preserved when RDP level decreased

\ Flash-WRP1AR (read-write)
: Flash-WRP1AR_WRP1A_STRT   ( %XXXXXXXX -- ) 0 lshift Flash-WRP1AR bis! ;  \ Flash-WRP1AR_WRP1A_STRT    Bank 1 WRP first area A start offset
: Flash-WRP1AR_WRP1A_END   ( %XXXXXXXX -- ) 16 lshift Flash-WRP1AR bis! ;  \ Flash-WRP1AR_WRP1A_END    Bank 1 WRP first area A end offset

\ Flash-WRP1BR (read-write)
: Flash-WRP1BR_WRP1B_STRT   ( %XXXXXXXX -- ) 16 lshift Flash-WRP1BR bis! ;  \ Flash-WRP1BR_WRP1B_STRT    Bank 1 WRP second area B end offset
: Flash-WRP1BR_WRP1B_END   ( %XXXXXXXX -- ) 0 lshift Flash-WRP1BR bis! ;  \ Flash-WRP1BR_WRP1B_END    Bank 1 WRP second area B start offset

\ Flash-PCROP1BSR (read-write)
: Flash-PCROP1BSR_PCROP1B_STRT   ( %XXXXXXXXX -- ) 0 lshift Flash-PCROP1BSR bis! ;  \ Flash-PCROP1BSR_PCROP1B_STRT    Bank 1 PCROP area B start offset

\ Flash-PCROP1BER (read-write)
: Flash-PCROP1BER_PCROP1B_END   ( %XXXXXXXXX -- ) 0 lshift Flash-PCROP1BER bis! ;  \ Flash-PCROP1BER_PCROP1B_END    Bank 1 PCROP area end area B offset

\ Flash-IPCCBR (read-write)
: Flash-IPCCBR_IPCCDBA   ( %XXXXXXXXXXXXXX -- ) 0 lshift Flash-IPCCBR bis! ;  \ Flash-IPCCBR_IPCCDBA    PCC mailbox data buffer base address

\ Flash-C2ACR (read-write)
: Flash-C2ACR_PRFTEN   %1 8 lshift Flash-C2ACR bis! ;  \ Flash-C2ACR_PRFTEN    CPU2 cortex M0 prefetch enable
: Flash-C2ACR_ICEN   %1 9 lshift Flash-C2ACR bis! ;  \ Flash-C2ACR_ICEN    CPU2 cortex M0 instruction cache enable
: Flash-C2ACR_ICRST   %1 11 lshift Flash-C2ACR bis! ;  \ Flash-C2ACR_ICRST    CPU2 cortex M0 instruction cache reset
: Flash-C2ACR_PES   %1 15 lshift Flash-C2ACR bis! ;  \ Flash-C2ACR_PES    CPU2 cortex M0 program erase suspend request

\ Flash-C2SR (read-write)
: Flash-C2SR_EOP   %1 0 lshift Flash-C2SR bis! ;  \ Flash-C2SR_EOP    End of operation
: Flash-C2SR_OPERR   %1 1 lshift Flash-C2SR bis! ;  \ Flash-C2SR_OPERR    Operation error
: Flash-C2SR_PROGERR   %1 3 lshift Flash-C2SR bis! ;  \ Flash-C2SR_PROGERR    Programming error
: Flash-C2SR_WRPERR   %1 4 lshift Flash-C2SR bis! ;  \ Flash-C2SR_WRPERR    write protection error
: Flash-C2SR_PGAERR   %1 5 lshift Flash-C2SR bis! ;  \ Flash-C2SR_PGAERR    Programming alignment error
: Flash-C2SR_SIZERR   %1 6 lshift Flash-C2SR bis! ;  \ Flash-C2SR_SIZERR    Size error
: Flash-C2SR_PGSERR   %1 7 lshift Flash-C2SR bis! ;  \ Flash-C2SR_PGSERR    Programming sequence error
: Flash-C2SR_MISSERR   %1 8 lshift Flash-C2SR bis! ;  \ Flash-C2SR_MISSERR    Fast programming data miss error
: Flash-C2SR_FASTERR   %1 9 lshift Flash-C2SR bis! ;  \ Flash-C2SR_FASTERR    Fast programming error
: Flash-C2SR_RDERR   %1 14 lshift Flash-C2SR bis! ;  \ Flash-C2SR_RDERR    PCROP read error
: Flash-C2SR_BSY   %1 16 lshift Flash-C2SR bis! ;  \ Flash-C2SR_BSY    Busy
: Flash-C2SR_CFGBSY   %1 18 lshift Flash-C2SR bis! ;  \ Flash-C2SR_CFGBSY    Programming or erase configuration busy
: Flash-C2SR_PESD   %1 19 lshift Flash-C2SR bis! ;  \ Flash-C2SR_PESD    Programming or erase operation suspended

\ Flash-C2CR (read-write)
: Flash-C2CR_PG   %1 0 lshift Flash-C2CR bis! ;  \ Flash-C2CR_PG    Programming
: Flash-C2CR_PER   %1 1 lshift Flash-C2CR bis! ;  \ Flash-C2CR_PER    Page erase
: Flash-C2CR_MER   %1 2 lshift Flash-C2CR bis! ;  \ Flash-C2CR_MER    Masse erase
: Flash-C2CR_PNB   ( %XXXXXXXX -- ) 3 lshift Flash-C2CR bis! ;  \ Flash-C2CR_PNB    Page Number selection
: Flash-C2CR_STRT   %1 16 lshift Flash-C2CR bis! ;  \ Flash-C2CR_STRT    Start
: Flash-C2CR_FSTPG   %1 18 lshift Flash-C2CR bis! ;  \ Flash-C2CR_FSTPG    Fast programming
: Flash-C2CR_EOPIE   %1 24 lshift Flash-C2CR bis! ;  \ Flash-C2CR_EOPIE    End of operation interrupt enable
: Flash-C2CR_ERRIE   %1 25 lshift Flash-C2CR bis! ;  \ Flash-C2CR_ERRIE    Error interrupt enable
: Flash-C2CR_RDERRIE   %1 26 lshift Flash-C2CR bis! ;  \ Flash-C2CR_RDERRIE    PCROP read error interrupt enable

\ Flash-SFR (read-write)
: Flash-SFR_SFSA   ( %XXXXXXXX -- ) 0 lshift Flash-SFR bis! ;  \ Flash-SFR_SFSA    Secure flash start address
: Flash-SFR_DDS   %1 12 lshift Flash-SFR bis! ;  \ Flash-SFR_DDS    Disable Cortex M0 debug access
: Flash-SFR_FSD   %1 8 lshift Flash-SFR bis! ;  \ Flash-SFR_FSD    Flash security disable

\ Flash-SRRVR (read-write)
: Flash-SRRVR_SBRV  0 lshift Flash-SRRVR bis! ;  \ Flash-SRRVR_SBRV    cortex M0 access control register
: Flash-SRRVR_SBRSA   ( %XXXXX -- ) 18 lshift Flash-SRRVR bis! ;  \ Flash-SRRVR_SBRSA    Secure backup SRAM2a start address
: Flash-SRRVR_BRSD   %1 23 lshift Flash-SRRVR bis! ;  \ Flash-SRRVR_BRSD    backup SRAM2a security disable
: Flash-SRRVR_SNBRSA   ( %XXXXX -- ) 25 lshift Flash-SRRVR bis! ;  \ Flash-SRRVR_SNBRSA    Secure non backup SRAM2a start address
: Flash-SRRVR_C2OPT   %1 31 lshift Flash-SRRVR bis! ;  \ Flash-SRRVR_C2OPT    CPU2 cortex M0 boot reset vector memory selection
: Flash-SRRVR_NBRSD   %1 30 lshift Flash-SRRVR bis! ;  \ Flash-SRRVR_NBRSD    non-backup SRAM2b security disable

\ QUADSPI-CR (read-write)
: QUADSPI-CR_PRESCALER   ( %XXXXXXXX -- ) 24 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_PRESCALER    Clock prescaler
: QUADSPI-CR_PMM   %1 23 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_PMM    Polling match mode
: QUADSPI-CR_APMS   %1 22 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_APMS    Automatic poll mode stop
: QUADSPI-CR_TOIE   %1 20 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_TOIE    TimeOut interrupt enable
: QUADSPI-CR_SMIE   %1 19 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_SMIE    Status match interrupt enable
: QUADSPI-CR_FTIE   %1 18 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_FTIE    FIFO threshold interrupt enable
: QUADSPI-CR_TCIE   %1 17 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_TCIE    Transfer complete interrupt enable
: QUADSPI-CR_TEIE   %1 16 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_TEIE    Transfer error interrupt enable
: QUADSPI-CR_FTHRES   ( %XXXX -- ) 8 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_FTHRES    FIFO threshold level
: QUADSPI-CR_SSHIFT   %1 4 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_SSHIFT    Sample shift
: QUADSPI-CR_TCEN   %1 3 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_TCEN    Timeout counter enable
: QUADSPI-CR_DMAEN   %1 2 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_DMAEN    DMA enable
: QUADSPI-CR_ABORT   %1 1 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_ABORT    Abort request
: QUADSPI-CR_EN   %1 0 lshift QUADSPI-CR bis! ;  \ QUADSPI-CR_EN    Enable

\ QUADSPI-DCR (read-write)
: QUADSPI-DCR_FSIZE   ( %XXXXX -- ) 16 lshift QUADSPI-DCR bis! ;  \ QUADSPI-DCR_FSIZE    FLASH memory size
: QUADSPI-DCR_CSHT   ( %XXX -- ) 8 lshift QUADSPI-DCR bis! ;  \ QUADSPI-DCR_CSHT    Chip select high time
: QUADSPI-DCR_CKMODE   %1 0 lshift QUADSPI-DCR bis! ;  \ QUADSPI-DCR_CKMODE    Mode 0 / mode 3

\ QUADSPI-SR (read-only)
: QUADSPI-SR_FLEVEL   ( %XXXXX -- ) 8 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_FLEVEL    FIFO level
: QUADSPI-SR_BUSY   %1 5 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_BUSY    Busy
: QUADSPI-SR_TOF   %1 4 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_TOF    Timeout flag
: QUADSPI-SR_SMF   %1 3 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_SMF    Status match flag
: QUADSPI-SR_FTF   %1 2 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_FTF    FIFO threshold flag
: QUADSPI-SR_TCF   %1 1 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_TCF    Transfer complete flag
: QUADSPI-SR_TEF   %1 0 lshift QUADSPI-SR bis! ;  \ QUADSPI-SR_TEF    Transfer error flag

\ QUADSPI-FCR (read-write)
: QUADSPI-FCR_CTOF   %1 4 lshift QUADSPI-FCR bis! ;  \ QUADSPI-FCR_CTOF    Clear timeout flag
: QUADSPI-FCR_CSMF   %1 3 lshift QUADSPI-FCR bis! ;  \ QUADSPI-FCR_CSMF    Clear status match flag
: QUADSPI-FCR_CTCF   %1 1 lshift QUADSPI-FCR bis! ;  \ QUADSPI-FCR_CTCF    Clear transfer complete flag
: QUADSPI-FCR_CTEF   %1 0 lshift QUADSPI-FCR bis! ;  \ QUADSPI-FCR_CTEF    Clear transfer error flag

\ QUADSPI-DLR (read-write)
: QUADSPI-DLR_DL   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-DLR bis! ;  \ QUADSPI-DLR_DL    Data length

\ QUADSPI-CCR (read-write)
: QUADSPI-CCR_DDRM   %1 31 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_DDRM    Double data rate mode
: QUADSPI-CCR_SIOO   %1 28 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_SIOO    Send instruction only once mode
: QUADSPI-CCR_FMODE   ( %XX -- ) 26 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_FMODE    Functional mode
: QUADSPI-CCR_DMODE   ( %XX -- ) 24 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_DMODE    Data mode
: QUADSPI-CCR_DCYC   ( %XXXXX -- ) 18 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_DCYC    Number of dummy cycles
: QUADSPI-CCR_ABSIZE   ( %XX -- ) 16 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_ABSIZE    Alternate bytes size
: QUADSPI-CCR_ABMODE   ( %XX -- ) 14 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_ABMODE    Alternate bytes mode
: QUADSPI-CCR_ADSIZE   ( %XX -- ) 12 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_ADSIZE    Address size
: QUADSPI-CCR_ADMODE   ( %XX -- ) 10 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_ADMODE    Address mode
: QUADSPI-CCR_IMODE   ( %XX -- ) 8 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_IMODE    Instruction mode
: QUADSPI-CCR_INSTRUCTION   ( %XXXXXXXX -- ) 0 lshift QUADSPI-CCR bis! ;  \ QUADSPI-CCR_INSTRUCTION    Instruction

\ QUADSPI-AR (read-write)
: QUADSPI-AR_ADDRESS   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-AR bis! ;  \ QUADSPI-AR_ADDRESS    Address

\ QUADSPI-ABR (read-write)
: QUADSPI-ABR_ALTERNATE   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-ABR bis! ;  \ QUADSPI-ABR_ALTERNATE    ALTERNATE

\ QUADSPI-DR (read-write)
: QUADSPI-DR_DATA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-DR bis! ;  \ QUADSPI-DR_DATA    Data

\ QUADSPI-PSMKR (read-write)
: QUADSPI-PSMKR_MASK   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-PSMKR bis! ;  \ QUADSPI-PSMKR_MASK    Status mask

\ QUADSPI-PSMAR (read-write)
: QUADSPI-PSMAR_MATCH   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-PSMAR bis! ;  \ QUADSPI-PSMAR_MATCH    Status match

\ QUADSPI-PIR (read-write)
: QUADSPI-PIR_INTERVAL   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-PIR bis! ;  \ QUADSPI-PIR_INTERVAL    Polling interval

\ QUADSPI-LPTR (read-write)
: QUADSPI-LPTR_TIMEOUT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift QUADSPI-LPTR bis! ;  \ QUADSPI-LPTR_TIMEOUT    Timeout period

\ RCC-CR ()
: RCC-CR_PLLSAI1RDY   %1 27 lshift RCC-CR bis! ;  \ RCC-CR_PLLSAI1RDY    SAI1 PLL clock ready flag
: RCC-CR_PLLSAI1ON   %1 26 lshift RCC-CR bis! ;  \ RCC-CR_PLLSAI1ON    SAI1 PLL enable
: RCC-CR_PLLRDY   %1 25 lshift RCC-CR bis! ;  \ RCC-CR_PLLRDY    Main PLL clock ready flag
: RCC-CR_PLLON   %1 24 lshift RCC-CR bis! ;  \ RCC-CR_PLLON    Main PLL enable
: RCC-CR_HSEPRE   %1 20 lshift RCC-CR bis! ;  \ RCC-CR_HSEPRE    HSE sysclk and PLL M divider prescaler
: RCC-CR_CSSON   %1 19 lshift RCC-CR bis! ;  \ RCC-CR_CSSON    HSE Clock security system enable
: RCC-CR_HSEBYP   %1 18 lshift RCC-CR bis! ;  \ RCC-CR_HSEBYP    HSE crystal oscillator bypass
: RCC-CR_HSERDY   %1 17 lshift RCC-CR bis! ;  \ RCC-CR_HSERDY    HSE clock ready flag
: RCC-CR_HSEON   %1 16 lshift RCC-CR bis! ;  \ RCC-CR_HSEON    HSE clock enabled
: RCC-CR_HSIKERDY   %1 12 lshift RCC-CR bis! ;  \ RCC-CR_HSIKERDY    HSI kernel clock ready flag for peripherals requests
: RCC-CR_HSIASFS   %1 11 lshift RCC-CR bis! ;  \ RCC-CR_HSIASFS    HSI automatic start from Stop
: RCC-CR_HSIRDY   %1 10 lshift RCC-CR bis! ;  \ RCC-CR_HSIRDY    HSI clock ready flag
: RCC-CR_HSIKERON   %1 9 lshift RCC-CR bis! ;  \ RCC-CR_HSIKERON    HSI always enable for peripheral kernels
: RCC-CR_HSION   %1 8 lshift RCC-CR bis! ;  \ RCC-CR_HSION    HSI clock enabled
: RCC-CR_MSIRANGE   ( %XXXX -- ) 4 lshift RCC-CR bis! ;  \ RCC-CR_MSIRANGE    MSI clock ranges
: RCC-CR_MSIPLLEN   %1 2 lshift RCC-CR bis! ;  \ RCC-CR_MSIPLLEN    MSI clock PLL enable
: RCC-CR_MSIRDY   %1 1 lshift RCC-CR bis! ;  \ RCC-CR_MSIRDY    MSI clock ready flag
: RCC-CR_MSION   %1 0 lshift RCC-CR bis! ;  \ RCC-CR_MSION    MSI clock enable

\ RCC-ICSCR ()
: RCC-ICSCR_HSITRIM   ( %XXXXXXX -- ) 24 lshift RCC-ICSCR bis! ;  \ RCC-ICSCR_HSITRIM    HSI clock trimming
: RCC-ICSCR_HSICAL   ( %XXXXXXXX -- ) 16 lshift RCC-ICSCR bis! ;  \ RCC-ICSCR_HSICAL    HSI clock calibration
: RCC-ICSCR_MSITRIM   ( %XXXXXXXX -- ) 8 lshift RCC-ICSCR bis! ;  \ RCC-ICSCR_MSITRIM    MSI clock trimming
: RCC-ICSCR_MSICAL   ( %XXXXXXXX -- ) 0 lshift RCC-ICSCR bis! ;  \ RCC-ICSCR_MSICAL    MSI clock calibration

\ RCC-CFGR ()
: RCC-CFGR_MCOPRE   ( %XXX -- ) 28 lshift RCC-CFGR bis! ;  \ RCC-CFGR_MCOPRE    Microcontroller clock output prescaler
: RCC-CFGR_MCOSEL   ( %XXXX -- ) 24 lshift RCC-CFGR bis! ;  \ RCC-CFGR_MCOSEL    Microcontroller clock output
: RCC-CFGR_PPRE2F   %1 18 lshift RCC-CFGR bis! ;  \ RCC-CFGR_PPRE2F    APB2 prescaler flag
: RCC-CFGR_PPRE1F   %1 17 lshift RCC-CFGR bis! ;  \ RCC-CFGR_PPRE1F    APB1 prescaler flag
: RCC-CFGR_HPREF   %1 16 lshift RCC-CFGR bis! ;  \ RCC-CFGR_HPREF    AHB prescaler flag
: RCC-CFGR_STOPWUCK   %1 15 lshift RCC-CFGR bis! ;  \ RCC-CFGR_STOPWUCK    Wakeup from Stop and CSS backup clock selection
: RCC-CFGR_PPRE2   ( %XXX -- ) 11 lshift RCC-CFGR bis! ;  \ RCC-CFGR_PPRE2    APB high-speed prescaler APB2
: RCC-CFGR_PPRE1   ( %XXX -- ) 8 lshift RCC-CFGR bis! ;  \ RCC-CFGR_PPRE1    PB low-speed prescaler APB1
: RCC-CFGR_HPRE   ( %XXXX -- ) 4 lshift RCC-CFGR bis! ;  \ RCC-CFGR_HPRE    AHB prescaler
: RCC-CFGR_SWS   ( %XX -- ) 2 lshift RCC-CFGR bis! ;  \ RCC-CFGR_SWS    System clock switch status
: RCC-CFGR_SW   ( %XX -- ) 0 lshift RCC-CFGR bis! ;  \ RCC-CFGR_SW    System clock switch

\ RCC-PLLCFGR (read-write)
: RCC-PLLCFGR_PLLR   ( %XXX -- ) 29 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLR    Main PLLSYS division factor R for SYSCLK system clock
: RCC-PLLCFGR_PLLREN   %1 28 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLREN    Main PLLSYSR PLLCLK output enable
: RCC-PLLCFGR_PLLQ   ( %XXX -- ) 25 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLQ    Main PLLSYS division factor Q for PLLSYSUSBCLK
: RCC-PLLCFGR_PLLQEN   %1 24 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLQEN    Main PLLSYSQ output enable
: RCC-PLLCFGR_PLLP   ( %XXXXX -- ) 17 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLP    Main PLL division factor P for PPLSYSSAICLK
: RCC-PLLCFGR_PLLPEN   %1 16 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLPEN    Main PLLSYSP output enable
: RCC-PLLCFGR_PLLN   ( %XXXXXXX -- ) 8 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLN    Main PLLSYS multiplication factor N
: RCC-PLLCFGR_PLLM   ( %XXX -- ) 4 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLM    Division factor M for the main PLL and audio PLL PLLSAI1 and PLLSAI2 input clock
: RCC-PLLCFGR_PLLSRC   ( %XX -- ) 0 lshift RCC-PLLCFGR bis! ;  \ RCC-PLLCFGR_PLLSRC    Main PLL, PLLSAI1 and PLLSAI2 entry clock source

\ RCC-PLLSAI1CFGR (read-write)
: RCC-PLLSAI1CFGR_PLLR   ( %XXX -- ) 29 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLR    PLLSAI division factor R for PLLADC1CLK ADC clock
: RCC-PLLSAI1CFGR_PLLREN   %1 28 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLREN    PLLSAI PLLADC1CLK output enable
: RCC-PLLSAI1CFGR_PLLQ   ( %XXX -- ) 25 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLQ    SAIPLL division factor Q for PLLSAIUSBCLK 48 MHz clock
: RCC-PLLSAI1CFGR_PLLQEN   %1 24 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLQEN    SAIPLL PLLSAIUSBCLK output enable
: RCC-PLLSAI1CFGR_PLLP   ( %XXXXX -- ) 17 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLP    SAI1PLL division factor P for PLLSAICLK SAI1clock
: RCC-PLLSAI1CFGR_PLLPEN   %1 16 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLPEN    SAIPLL PLLSAI1CLK output enable
: RCC-PLLSAI1CFGR_PLLN   ( %XXXXXXX -- ) 8 lshift RCC-PLLSAI1CFGR bis! ;  \ RCC-PLLSAI1CFGR_PLLN    SAIPLL multiplication factor for VCO

\ RCC-CIER (read-write)
: RCC-CIER_LSI2RDYIE   %1 11 lshift RCC-CIER bis! ;  \ RCC-CIER_LSI2RDYIE    LSI2 ready interrupt enable
: RCC-CIER_HSI48RDYIE   %1 10 lshift RCC-CIER bis! ;  \ RCC-CIER_HSI48RDYIE    HSI48 ready interrupt enable
: RCC-CIER_LSECSSIE   %1 9 lshift RCC-CIER bis! ;  \ RCC-CIER_LSECSSIE    LSE clock security system interrupt enable
: RCC-CIER_PLLSAI1RDYIE   %1 6 lshift RCC-CIER bis! ;  \ RCC-CIER_PLLSAI1RDYIE    PLLSAI1 ready interrupt enable
: RCC-CIER_PLLRDYIE   %1 5 lshift RCC-CIER bis! ;  \ RCC-CIER_PLLRDYIE    PLLSYS ready interrupt enable
: RCC-CIER_HSERDYIE   %1 4 lshift RCC-CIER bis! ;  \ RCC-CIER_HSERDYIE    HSE ready interrupt enable
: RCC-CIER_HSIRDYIE   %1 3 lshift RCC-CIER bis! ;  \ RCC-CIER_HSIRDYIE    HSI ready interrupt enable
: RCC-CIER_MSIRDYIE   %1 2 lshift RCC-CIER bis! ;  \ RCC-CIER_MSIRDYIE    MSI ready interrupt enable
: RCC-CIER_LSERDYIE   %1 1 lshift RCC-CIER bis! ;  \ RCC-CIER_LSERDYIE    LSE ready interrupt enable
: RCC-CIER_LSI1RDYIE   %1 0 lshift RCC-CIER bis! ;  \ RCC-CIER_LSI1RDYIE    LSI1 ready interrupt enable

\ RCC-CIFR (read-only)
: RCC-CIFR_LSI2RDYF   %1 11 lshift RCC-CIFR bis! ;  \ RCC-CIFR_LSI2RDYF    LSI2 ready interrupt flag
: RCC-CIFR_HSI48RDYF   %1 10 lshift RCC-CIFR bis! ;  \ RCC-CIFR_HSI48RDYF    HSI48 ready interrupt flag
: RCC-CIFR_LSECSSF   %1 9 lshift RCC-CIFR bis! ;  \ RCC-CIFR_LSECSSF    LSE Clock security system interrupt flag
: RCC-CIFR_HSECSSF   %1 8 lshift RCC-CIFR bis! ;  \ RCC-CIFR_HSECSSF    HSE Clock security system interrupt flag
: RCC-CIFR_PLLSAI1RDYF   %1 6 lshift RCC-CIFR bis! ;  \ RCC-CIFR_PLLSAI1RDYF    PLLSAI1 ready interrupt flag
: RCC-CIFR_PLLRDYF   %1 5 lshift RCC-CIFR bis! ;  \ RCC-CIFR_PLLRDYF    PLL ready interrupt flag
: RCC-CIFR_HSERDYF   %1 4 lshift RCC-CIFR bis! ;  \ RCC-CIFR_HSERDYF    HSE ready interrupt flag
: RCC-CIFR_HSIRDYF   %1 3 lshift RCC-CIFR bis! ;  \ RCC-CIFR_HSIRDYF    HSI ready interrupt flag
: RCC-CIFR_MSIRDYF   %1 2 lshift RCC-CIFR bis! ;  \ RCC-CIFR_MSIRDYF    MSI ready interrupt flag
: RCC-CIFR_LSERDYF   %1 1 lshift RCC-CIFR bis! ;  \ RCC-CIFR_LSERDYF    LSE ready interrupt flag
: RCC-CIFR_LSI1RDYF   %1 0 lshift RCC-CIFR bis! ;  \ RCC-CIFR_LSI1RDYF    LSI1 ready interrupt flag

\ RCC-CICR (write-only)
: RCC-CICR_LSI2RDYC   %1 11 lshift RCC-CICR bis! ;  \ RCC-CICR_LSI2RDYC    LSI2 ready interrupt clear
: RCC-CICR_HSI48RDYC   %1 10 lshift RCC-CICR bis! ;  \ RCC-CICR_HSI48RDYC    HSI48 ready interrupt clear
: RCC-CICR_LSECSSC   %1 9 lshift RCC-CICR bis! ;  \ RCC-CICR_LSECSSC    LSE Clock security system interrupt clear
: RCC-CICR_HSECSSC   %1 8 lshift RCC-CICR bis! ;  \ RCC-CICR_HSECSSC    HSE Clock security system interrupt clear
: RCC-CICR_PLLSAI1RDYC   %1 6 lshift RCC-CICR bis! ;  \ RCC-CICR_PLLSAI1RDYC    PLLSAI1 ready interrupt clear
: RCC-CICR_PLLRDYC   %1 5 lshift RCC-CICR bis! ;  \ RCC-CICR_PLLRDYC    PLL ready interrupt clear
: RCC-CICR_HSERDYC   %1 4 lshift RCC-CICR bis! ;  \ RCC-CICR_HSERDYC    HSE ready interrupt clear
: RCC-CICR_HSIRDYC   %1 3 lshift RCC-CICR bis! ;  \ RCC-CICR_HSIRDYC    HSI ready interrupt clear
: RCC-CICR_MSIRDYC   %1 2 lshift RCC-CICR bis! ;  \ RCC-CICR_MSIRDYC    MSI ready interrupt clear
: RCC-CICR_LSERDYC   %1 1 lshift RCC-CICR bis! ;  \ RCC-CICR_LSERDYC    LSE ready interrupt clear
: RCC-CICR_LSI1RDYC   %1 0 lshift RCC-CICR bis! ;  \ RCC-CICR_LSI1RDYC    LSI1 ready interrupt clear

\ RCC-SMPSCR ()
: RCC-SMPSCR_SMPSSWS   ( %XX -- ) 8 lshift RCC-SMPSCR bis! ;  \ RCC-SMPSCR_SMPSSWS    Step Down converter clock switch status
: RCC-SMPSCR_SMPSDIV   ( %XX -- ) 4 lshift RCC-SMPSCR bis! ;  \ RCC-SMPSCR_SMPSDIV    Step Down converter clock prescaler
: RCC-SMPSCR_SMPSSEL   ( %XX -- ) 0 lshift RCC-SMPSCR bis! ;  \ RCC-SMPSCR_SMPSSEL    Step Down converter clock selection

\ RCC-AHB1RSTR (read-write)
: RCC-AHB1RSTR_TSCRST   %1 16 lshift RCC-AHB1RSTR bis! ;  \ RCC-AHB1RSTR_TSCRST    Touch Sensing Controller reset
: RCC-AHB1RSTR_CRCRST   %1 12 lshift RCC-AHB1RSTR bis! ;  \ RCC-AHB1RSTR_CRCRST    CRC reset
: RCC-AHB1RSTR_DMAMUXRST   %1 2 lshift RCC-AHB1RSTR bis! ;  \ RCC-AHB1RSTR_DMAMUXRST    DMAMUX reset
: RCC-AHB1RSTR_DMA2RST   %1 1 lshift RCC-AHB1RSTR bis! ;  \ RCC-AHB1RSTR_DMA2RST    DMA2 reset
: RCC-AHB1RSTR_DMA1RST   %1 0 lshift RCC-AHB1RSTR bis! ;  \ RCC-AHB1RSTR_DMA1RST    DMA1 reset

\ RCC-AHB2RSTR (read-write)
: RCC-AHB2RSTR_AES1RST   %1 16 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_AES1RST    AES1 hardware accelerator reset
: RCC-AHB2RSTR_ADCRST   %1 13 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_ADCRST    ADC reset
: RCC-AHB2RSTR_GPIOHRST   %1 7 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_GPIOHRST    IO port H reset
: RCC-AHB2RSTR_GPIOERST   %1 4 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_GPIOERST    IO port E reset
: RCC-AHB2RSTR_GPIODRST   %1 3 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_GPIODRST    IO port D reset
: RCC-AHB2RSTR_GPIOCRST   %1 2 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_GPIOCRST    IO port C reset
: RCC-AHB2RSTR_GPIOBRST   %1 1 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_GPIOBRST    IO port B reset
: RCC-AHB2RSTR_GPIOARST   %1 0 lshift RCC-AHB2RSTR bis! ;  \ RCC-AHB2RSTR_GPIOARST    IO port A reset

\ RCC-AHB3RSTR (read-write)
: RCC-AHB3RSTR_FLASHRST   %1 25 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_FLASHRST    Flash interface reset
: RCC-AHB3RSTR_IPCCRST   %1 20 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_IPCCRST    IPCC interface reset
: RCC-AHB3RSTR_HSEMRST   %1 19 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_HSEMRST    HSEM interface reset
: RCC-AHB3RSTR_RNGRST   %1 18 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_RNGRST    RNG interface reset
: RCC-AHB3RSTR_AES2RST   %1 17 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_AES2RST    AES2 interface reset
: RCC-AHB3RSTR_PKARST   %1 16 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_PKARST    PKA interface reset
: RCC-AHB3RSTR_QSPIRST   %1 8 lshift RCC-AHB3RSTR bis! ;  \ RCC-AHB3RSTR_QSPIRST    Quad SPI memory interface reset

\ RCC-APB1RSTR1 (read-write)
: RCC-APB1RSTR1_LPTIM1RST   %1 31 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_LPTIM1RST    Low Power Timer 1 reset
: RCC-APB1RSTR1_USBFSRST   %1 26 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_USBFSRST    USB FS reset
: RCC-APB1RSTR1_CRSRST   %1 24 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_CRSRST    CRS reset
: RCC-APB1RSTR1_I2C3RST   %1 23 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_I2C3RST    I2C3 reset
: RCC-APB1RSTR1_I2C1RST   %1 21 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_I2C1RST    I2C1 reset
: RCC-APB1RSTR1_SPI2RST   %1 14 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_SPI2RST    SPI2 reset
: RCC-APB1RSTR1_LCDRST   %1 9 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_LCDRST    LCD interface reset
: RCC-APB1RSTR1_TIM2RST   %1 0 lshift RCC-APB1RSTR1 bis! ;  \ RCC-APB1RSTR1_TIM2RST    TIM2 timer reset

\ RCC-APB1RSTR2 (read-write)
: RCC-APB1RSTR2_LPTIM2RST   %1 5 lshift RCC-APB1RSTR2 bis! ;  \ RCC-APB1RSTR2_LPTIM2RST    Low-power timer 2 reset
: RCC-APB1RSTR2_LPUART1RST   %1 0 lshift RCC-APB1RSTR2 bis! ;  \ RCC-APB1RSTR2_LPUART1RST    Low-power UART 1 reset

\ RCC-APB2RSTR (read-write)
: RCC-APB2RSTR_SAI1RST   %1 21 lshift RCC-APB2RSTR bis! ;  \ RCC-APB2RSTR_SAI1RST    Serial audio interface 1 SAI1 reset
: RCC-APB2RSTR_TIM17RST   %1 18 lshift RCC-APB2RSTR bis! ;  \ RCC-APB2RSTR_TIM17RST    TIM17 timer reset
: RCC-APB2RSTR_TIM16RST   %1 17 lshift RCC-APB2RSTR bis! ;  \ RCC-APB2RSTR_TIM16RST    TIM16 timer reset
: RCC-APB2RSTR_USART1RST   %1 14 lshift RCC-APB2RSTR bis! ;  \ RCC-APB2RSTR_USART1RST    USART1 reset
: RCC-APB2RSTR_SPI1RST   %1 12 lshift RCC-APB2RSTR bis! ;  \ RCC-APB2RSTR_SPI1RST    SPI1 reset
: RCC-APB2RSTR_TIM1RST   %1 11 lshift RCC-APB2RSTR bis! ;  \ RCC-APB2RSTR_TIM1RST    TIM1 timer reset

\ RCC-APB3RSTR (read-write)
: RCC-APB3RSTR_RFRST   %1 0 lshift RCC-APB3RSTR bis! ;  \ RCC-APB3RSTR_RFRST    Radio system BLE reset

\ RCC-AHB1ENR (read-write)
: RCC-AHB1ENR_TSCEN   %1 16 lshift RCC-AHB1ENR bis! ;  \ RCC-AHB1ENR_TSCEN    Touch Sensing Controller clock enable
: RCC-AHB1ENR_CRCEN   %1 12 lshift RCC-AHB1ENR bis! ;  \ RCC-AHB1ENR_CRCEN    CPU1 CRC clock enable
: RCC-AHB1ENR_DMAMUXEN   %1 2 lshift RCC-AHB1ENR bis! ;  \ RCC-AHB1ENR_DMAMUXEN    DMAMUX clock enable
: RCC-AHB1ENR_DMA2EN   %1 1 lshift RCC-AHB1ENR bis! ;  \ RCC-AHB1ENR_DMA2EN    DMA2 clock enable
: RCC-AHB1ENR_DMA1EN   %1 0 lshift RCC-AHB1ENR bis! ;  \ RCC-AHB1ENR_DMA1EN    DMA1 clock enable

\ RCC-AHB2ENR (read-write)
: RCC-AHB2ENR_AES1EN   %1 16 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_AES1EN    AES1 accelerator clock enable
: RCC-AHB2ENR_ADCEN   %1 13 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_ADCEN    ADC clock enable
: RCC-AHB2ENR_GPIOHEN   %1 7 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_GPIOHEN    IO port H clock enable
: RCC-AHB2ENR_GPIOEEN   %1 4 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_GPIOEEN    IO port E clock enable
: RCC-AHB2ENR_GPIODEN   %1 3 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_GPIODEN    IO port D clock enable
: RCC-AHB2ENR_GPIOCEN   %1 2 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_GPIOCEN    IO port C clock enable
: RCC-AHB2ENR_GPIOBEN   %1 1 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_GPIOBEN    IO port B clock enable
: RCC-AHB2ENR_GPIOAEN   %1 0 lshift RCC-AHB2ENR bis! ;  \ RCC-AHB2ENR_GPIOAEN    IO port A clock enable

\ RCC-AHB3ENR (read-write)
: RCC-AHB3ENR_FLASHEN   %1 25 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_FLASHEN    FLASHEN
: RCC-AHB3ENR_IPCCEN   %1 20 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_IPCCEN    IPCCEN
: RCC-AHB3ENR_HSEMEN   %1 19 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_HSEMEN    HSEMEN
: RCC-AHB3ENR_RNGEN   %1 18 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_RNGEN    RNGEN
: RCC-AHB3ENR_AES2EN   %1 17 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_AES2EN    AES2EN
: RCC-AHB3ENR_PKAEN   %1 16 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_PKAEN    PKAEN
: RCC-AHB3ENR_QSPIEN   %1 8 lshift RCC-AHB3ENR bis! ;  \ RCC-AHB3ENR_QSPIEN    QSPIEN

\ RCC-APB1ENR1 (read-write)
: RCC-APB1ENR1_LPTIM1EN   %1 31 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_LPTIM1EN    CPU1 Low power timer 1 clock enable
: RCC-APB1ENR1_USBEN   %1 26 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_USBEN    CPU1 USB clock enable
: RCC-APB1ENR1_CRSEN   %1 24 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_CRSEN    CPU1 CRS clock enable
: RCC-APB1ENR1_I2C3EN   %1 23 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_I2C3EN    CPU1 I2C3 clock enable
: RCC-APB1ENR1_I2C1EN   %1 21 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_I2C1EN    CPU1 I2C1 clock enable
: RCC-APB1ENR1_SPI2EN   %1 14 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_SPI2EN    CPU1 SPI2 clock enable
: RCC-APB1ENR1_WWDGEN   %1 11 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_WWDGEN    CPU1 Window watchdog clock enable
: RCC-APB1ENR1_RTCAPBEN   %1 10 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_RTCAPBEN    CPU1 RTC APB clock enable
: RCC-APB1ENR1_LCDEN   %1 9 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_LCDEN    CPU1 LCD clock enable
: RCC-APB1ENR1_TIM2EN   %1 0 lshift RCC-APB1ENR1 bis! ;  \ RCC-APB1ENR1_TIM2EN    CPU1 TIM2 timer clock enable

\ RCC-APB1ENR2 (read-write)
: RCC-APB1ENR2_LPTIM2EN   %1 5 lshift RCC-APB1ENR2 bis! ;  \ RCC-APB1ENR2_LPTIM2EN    CPU1 LPTIM2EN
: RCC-APB1ENR2_LPUART1EN   %1 0 lshift RCC-APB1ENR2 bis! ;  \ RCC-APB1ENR2_LPUART1EN    CPU1 Low power UART 1 clock enable

\ RCC-APB2ENR (read-write)
: RCC-APB2ENR_SAI1EN   %1 21 lshift RCC-APB2ENR bis! ;  \ RCC-APB2ENR_SAI1EN    CPU1 SAI1 clock enable
: RCC-APB2ENR_TIM17EN   %1 18 lshift RCC-APB2ENR bis! ;  \ RCC-APB2ENR_TIM17EN    CPU1 TIM17 timer clock enable
: RCC-APB2ENR_TIM16EN   %1 17 lshift RCC-APB2ENR bis! ;  \ RCC-APB2ENR_TIM16EN    CPU1 TIM16 timer clock enable
: RCC-APB2ENR_USART1EN   %1 14 lshift RCC-APB2ENR bis! ;  \ RCC-APB2ENR_USART1EN    CPU1 USART1clock enable
: RCC-APB2ENR_SPI1EN   %1 12 lshift RCC-APB2ENR bis! ;  \ RCC-APB2ENR_SPI1EN    CPU1 SPI1 clock enable
: RCC-APB2ENR_TIM1EN   %1 11 lshift RCC-APB2ENR bis! ;  \ RCC-APB2ENR_TIM1EN    CPU1 TIM1 timer clock enable

\ RCC-AHB1SMENR (read-write)
: RCC-AHB1SMENR_TSCSMEN   %1 16 lshift RCC-AHB1SMENR bis! ;  \ RCC-AHB1SMENR_TSCSMEN    CPU1 Touch Sensing Controller clocks enable during Sleep and Stop modes
: RCC-AHB1SMENR_CRCSMEN   %1 12 lshift RCC-AHB1SMENR bis! ;  \ RCC-AHB1SMENR_CRCSMEN    CPU1 CRCSMEN
: RCC-AHB1SMENR_SRAM1SMEN   %1 9 lshift RCC-AHB1SMENR bis! ;  \ RCC-AHB1SMENR_SRAM1SMEN    CPU1 SRAM1 interface clocks enable during Sleep and Stop modes
: RCC-AHB1SMENR_DMAMUXSMEN   %1 2 lshift RCC-AHB1SMENR bis! ;  \ RCC-AHB1SMENR_DMAMUXSMEN    CPU1 DMAMUX clocks enable during Sleep and Stop modes
: RCC-AHB1SMENR_DMA2SMEN   %1 1 lshift RCC-AHB1SMENR bis! ;  \ RCC-AHB1SMENR_DMA2SMEN    CPU1 DMA2 clocks enable during Sleep and Stop modes
: RCC-AHB1SMENR_DMA1SMEN   %1 0 lshift RCC-AHB1SMENR bis! ;  \ RCC-AHB1SMENR_DMA1SMEN    CPU1 DMA1 clocks enable during Sleep and Stop modes

\ RCC-AHB2SMENR (read-write)
: RCC-AHB2SMENR_AES1SMEN   %1 16 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_AES1SMEN    CPU1 AES1 accelerator clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_ADCFSSMEN   %1 13 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_ADCFSSMEN    CPU1 ADC clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_GPIOHSMEN   %1 7 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_GPIOHSMEN    CPU1 IO port H clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_GPIOESMEN   %1 4 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_GPIOESMEN    CPU1 IO port E clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_GPIODSMEN   %1 3 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_GPIODSMEN    CPU1 IO port D clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_GPIOCSMEN   %1 2 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_GPIOCSMEN    CPU1 IO port C clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_GPIOBSMEN   %1 1 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_GPIOBSMEN    CPU1 IO port B clocks enable during Sleep and Stop modes
: RCC-AHB2SMENR_GPIOASMEN   %1 0 lshift RCC-AHB2SMENR bis! ;  \ RCC-AHB2SMENR_GPIOASMEN    CPU1 IO port A clocks enable during Sleep and Stop modes

\ RCC-AHB3SMENR (read-write)
: RCC-AHB3SMENR_FLASHSMEN   %1 25 lshift RCC-AHB3SMENR bis! ;  \ RCC-AHB3SMENR_FLASHSMEN    Flash interface clocks enable during CPU1 sleep mode
: RCC-AHB3SMENR_SRAM2SMEN   %1 24 lshift RCC-AHB3SMENR bis! ;  \ RCC-AHB3SMENR_SRAM2SMEN    SRAM2a and SRAM2b memory interface clocks enable during CPU1 sleep mode
: RCC-AHB3SMENR_RNGSMEN   %1 18 lshift RCC-AHB3SMENR bis! ;  \ RCC-AHB3SMENR_RNGSMEN    True RNG clocks enable during CPU1 sleep mode
: RCC-AHB3SMENR_AES2SMEN   %1 17 lshift RCC-AHB3SMENR bis! ;  \ RCC-AHB3SMENR_AES2SMEN    AES2 accelerator clocks enable during CPU1 sleep mode
: RCC-AHB3SMENR_PKASMEN   %1 16 lshift RCC-AHB3SMENR bis! ;  \ RCC-AHB3SMENR_PKASMEN    PKA accelerator clocks enable during CPU1 sleep mode
: RCC-AHB3SMENR_QSPISMEN   %1 8 lshift RCC-AHB3SMENR bis! ;  \ RCC-AHB3SMENR_QSPISMEN    QSPISMEN

\ RCC-APB1SMENR1 (read-write)
: RCC-APB1SMENR1_LPTIM1SMEN   %1 31 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_LPTIM1SMEN    Low power timer 1 clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_USBSMEN   %1 26 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_USBSMEN    USB FS clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_CRSMEN   %1 24 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_CRSMEN    CRS clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_I2C3SMEN   %1 23 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_I2C3SMEN    I2C3 clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_I2C1SMEN   %1 21 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_I2C1SMEN    I2C1 clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_SPI2SMEN   %1 14 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_SPI2SMEN    SPI2 clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_WWDGSMEN   %1 11 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_WWDGSMEN    Window watchdog clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_RTCAPBSMEN   %1 10 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_RTCAPBSMEN    RTC APB clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_LCDSMEN   %1 9 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_LCDSMEN    LCD clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR1_TIM2SMEN   %1 0 lshift RCC-APB1SMENR1 bis! ;  \ RCC-APB1SMENR1_TIM2SMEN    TIM2 timer clocks enable during CPU1 Sleep mode

\ RCC-APB1SMENR2 (read-write)
: RCC-APB1SMENR2_LPTIM2SMEN   %1 5 lshift RCC-APB1SMENR2 bis! ;  \ RCC-APB1SMENR2_LPTIM2SMEN    Low power timer 2 clocks enable during CPU1 Sleep mode
: RCC-APB1SMENR2_LPUART1SMEN   %1 0 lshift RCC-APB1SMENR2 bis! ;  \ RCC-APB1SMENR2_LPUART1SMEN    Low power UART 1 clocks enable during CPU1 Sleep mode

\ RCC-APB2SMENR (read-write)
: RCC-APB2SMENR_SAI1SMEN   %1 21 lshift RCC-APB2SMENR bis! ;  \ RCC-APB2SMENR_SAI1SMEN    SAI1 clocks enable during CPU1 Sleep mode
: RCC-APB2SMENR_TIM17SMEN   %1 18 lshift RCC-APB2SMENR bis! ;  \ RCC-APB2SMENR_TIM17SMEN    TIM17 timer clocks enable during CPU1 Sleep mode
: RCC-APB2SMENR_TIM16SMEN   %1 17 lshift RCC-APB2SMENR bis! ;  \ RCC-APB2SMENR_TIM16SMEN    TIM16 timer clocks enable during CPU1 Sleep mode
: RCC-APB2SMENR_USART1SMEN   %1 14 lshift RCC-APB2SMENR bis! ;  \ RCC-APB2SMENR_USART1SMEN    USART1clocks enable during CPU1 Sleep mode
: RCC-APB2SMENR_SPI1SMEN   %1 12 lshift RCC-APB2SMENR bis! ;  \ RCC-APB2SMENR_SPI1SMEN    SPI1 clocks enable during CPU1 Sleep mode
: RCC-APB2SMENR_TIM1SMEN   %1 11 lshift RCC-APB2SMENR bis! ;  \ RCC-APB2SMENR_TIM1SMEN    TIM1 timer clocks enable during CPU1 Sleep mode

\ RCC-CCIPR (read-write)
: RCC-CCIPR_RNGSEL   ( %XX -- ) 30 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_RNGSEL    RNG clock source selection
: RCC-CCIPR_ADCSEL   ( %XX -- ) 28 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_ADCSEL    ADCs clock source selection
: RCC-CCIPR_CLK48SEL   ( %XX -- ) 26 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_CLK48SEL    48 MHz clock source selection
: RCC-CCIPR_SAI1SEL   ( %XX -- ) 22 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_SAI1SEL    SAI1 clock source selection
: RCC-CCIPR_LPTIM2SEL   ( %XX -- ) 20 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_LPTIM2SEL    Low power timer 2 clock source selection
: RCC-CCIPR_LPTIM1SEL   ( %XX -- ) 18 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_LPTIM1SEL    Low power timer 1 clock source selection
: RCC-CCIPR_I2C3SEL   ( %XX -- ) 16 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_I2C3SEL    I2C3 clock source selection
: RCC-CCIPR_I2C1SEL   ( %XX -- ) 12 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_I2C1SEL    I2C1 clock source selection
: RCC-CCIPR_LPUART1SEL   ( %XX -- ) 10 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_LPUART1SEL    LPUART1 clock source selection
: RCC-CCIPR_USART1SEL   ( %XX -- ) 0 lshift RCC-CCIPR bis! ;  \ RCC-CCIPR_USART1SEL    USART1 clock source selection

\ RCC-BDCR ()
: RCC-BDCR_LSCOSEL   ( %XX -- ) 25 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSCOSEL    Low speed clock output selection
: RCC-BDCR_LSCOEN   %1 24 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSCOEN    Low speed clock output enable
: RCC-BDCR_BDRST   %1 16 lshift RCC-BDCR bis! ;  \ RCC-BDCR_BDRST    Backup domain software reset
: RCC-BDCR_RTCEN   %1 15 lshift RCC-BDCR bis! ;  \ RCC-BDCR_RTCEN    RTC clock enable
: RCC-BDCR_RTCSEL   ( %XX -- ) 8 lshift RCC-BDCR bis! ;  \ RCC-BDCR_RTCSEL    RTC clock source selection
: RCC-BDCR_LSECSSD_   %1 6 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSECSSD_    CSS on LSE failure detection
: RCC-BDCR_LSECSSON   %1 5 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSECSSON    LSECSSON
: RCC-BDCR_LSEDRV   ( %XX -- ) 3 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSEDRV    SE oscillator drive capability
: RCC-BDCR_LSEBYP   %1 2 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSEBYP    LSE oscillator bypass
: RCC-BDCR_LSERDY   %1 1 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSERDY    LSE oscillator ready
: RCC-BDCR_LSEON   %1 0 lshift RCC-BDCR bis! ;  \ RCC-BDCR_LSEON    LSE oscillator enable

\ RCC-CSR ()
: RCC-CSR_LPWRRSTF   %1 31 lshift RCC-CSR bis! ;  \ RCC-CSR_LPWRRSTF    Low-power reset flag
: RCC-CSR_WWDGRSTF   %1 30 lshift RCC-CSR bis! ;  \ RCC-CSR_WWDGRSTF    Window watchdog reset flag
: RCC-CSR_IWDGRSTF   %1 29 lshift RCC-CSR bis! ;  \ RCC-CSR_IWDGRSTF    Independent window watchdog reset flag
: RCC-CSR_SFTRSTF   %1 28 lshift RCC-CSR bis! ;  \ RCC-CSR_SFTRSTF    Software reset flag
: RCC-CSR_BORRSTF   %1 27 lshift RCC-CSR bis! ;  \ RCC-CSR_BORRSTF    BOR flag
: RCC-CSR_PINRSTF   %1 26 lshift RCC-CSR bis! ;  \ RCC-CSR_PINRSTF    Pin reset flag
: RCC-CSR_OBLRSTF   %1 25 lshift RCC-CSR bis! ;  \ RCC-CSR_OBLRSTF    Option byte loader reset flag
: RCC-CSR_RMVF   %1 23 lshift RCC-CSR bis! ;  \ RCC-CSR_RMVF    Remove reset flag
: RCC-CSR_RFWKPSEL   ( %XX -- ) 14 lshift RCC-CSR bis! ;  \ RCC-CSR_RFWKPSEL    RF system wakeup clock source selection
: RCC-CSR_LSI2BW   ( %XXXX -- ) 8 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI2BW    LSI2 oscillator bias configuration
: RCC-CSR_LSI2TRIMOK   %1 5 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI2TRIMOK    LSI2 oscillator trim OK
: RCC-CSR_LSI2TRIMEN   %1 4 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI2TRIMEN    LSI2 oscillator trimming enable
: RCC-CSR_LSI2RDY   %1 3 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI2RDY    LSI2 oscillator ready
: RCC-CSR_LSI2ON   %1 2 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI2ON    LSI2 oscillator enabled
: RCC-CSR_LSI1RDY   %1 1 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI1RDY    LSI1 oscillator ready
: RCC-CSR_LSI1ON   %1 0 lshift RCC-CSR bis! ;  \ RCC-CSR_LSI1ON    LSI1 oscillator enabled
: RCC-CSR_RFRSTS   %1 16 lshift RCC-CSR bis! ;  \ RCC-CSR_RFRSTS    Radio system BLE and 802.15.4 reset status

\ RCC-CRRCR ()
: RCC-CRRCR_HSI48CAL   ( %XXXXXXXXX -- ) 7 lshift RCC-CRRCR bis! ;  \ RCC-CRRCR_HSI48CAL    HSI48 clock calibration
: RCC-CRRCR_HSI48RDY   %1 1 lshift RCC-CRRCR bis! ;  \ RCC-CRRCR_HSI48RDY    HSI48 clock ready
: RCC-CRRCR_HSI48ON   %1 0 lshift RCC-CRRCR bis! ;  \ RCC-CRRCR_HSI48ON    HSI48 oscillator enabled

\ RCC-HSECR ()
: RCC-HSECR_HSETUNE   ( %XXXXXX -- ) 8 lshift RCC-HSECR bis! ;  \ RCC-HSECR_HSETUNE    HSE capacitor tuning
: RCC-HSECR_HSEGMC   ( %XXX -- ) 4 lshift RCC-HSECR bis! ;  \ RCC-HSECR_HSEGMC    HSE current control
: RCC-HSECR_HSES   %1 3 lshift RCC-HSECR bis! ;  \ RCC-HSECR_HSES    HSE Sense amplifier threshold
: RCC-HSECR_UNLOCKED   %1 0 lshift RCC-HSECR bis! ;  \ RCC-HSECR_UNLOCKED    Register lock system

\ RCC-EXTCFGR ()
: RCC-EXTCFGR_RFCSS   %1 20 lshift RCC-EXTCFGR bis! ;  \ RCC-EXTCFGR_RFCSS    RF clock source selected
: RCC-EXTCFGR_C2HPREF   %1 17 lshift RCC-EXTCFGR bis! ;  \ RCC-EXTCFGR_C2HPREF    CPU2 AHB prescaler flag
: RCC-EXTCFGR_SHDHPREF   %1 16 lshift RCC-EXTCFGR bis! ;  \ RCC-EXTCFGR_SHDHPREF    Shared AHB prescaler flag
: RCC-EXTCFGR_C2HPRE   ( %XXXX -- ) 4 lshift RCC-EXTCFGR bis! ;  \ RCC-EXTCFGR_C2HPRE    CPU2 AHB prescaler
: RCC-EXTCFGR_SHDHPRE   ( %XXXX -- ) 0 lshift RCC-EXTCFGR bis! ;  \ RCC-EXTCFGR_SHDHPRE    Shared AHB prescaler

\ RCC-C2AHB1ENR (read-write)
: RCC-C2AHB1ENR_TSCEN   %1 16 lshift RCC-C2AHB1ENR bis! ;  \ RCC-C2AHB1ENR_TSCEN    CPU2 Touch Sensing Controller clock enable
: RCC-C2AHB1ENR_CRCEN   %1 12 lshift RCC-C2AHB1ENR bis! ;  \ RCC-C2AHB1ENR_CRCEN    CPU2 CRC clock enable
: RCC-C2AHB1ENR_SRAM1EN   %1 9 lshift RCC-C2AHB1ENR bis! ;  \ RCC-C2AHB1ENR_SRAM1EN    CPU2 SRAM1 clock enable
: RCC-C2AHB1ENR_DMAMUXEN   %1 2 lshift RCC-C2AHB1ENR bis! ;  \ RCC-C2AHB1ENR_DMAMUXEN    CPU2 DMAMUX clock enable
: RCC-C2AHB1ENR_DMA2EN   %1 1 lshift RCC-C2AHB1ENR bis! ;  \ RCC-C2AHB1ENR_DMA2EN    CPU2 DMA2 clock enable
: RCC-C2AHB1ENR_DMA1EN   %1 0 lshift RCC-C2AHB1ENR bis! ;  \ RCC-C2AHB1ENR_DMA1EN    CPU2 DMA1 clock enable

\ RCC-C2AHB2ENR (read-write)
: RCC-C2AHB2ENR_AES1EN   %1 16 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_AES1EN    CPU2 AES1 accelerator clock enable
: RCC-C2AHB2ENR_ADCEN   %1 13 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_ADCEN    CPU2 ADC clock enable
: RCC-C2AHB2ENR_GPIOHEN   %1 7 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_GPIOHEN    CPU2 IO port H clock enable
: RCC-C2AHB2ENR_GPIOEEN   %1 4 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_GPIOEEN    CPU2 IO port E clock enable
: RCC-C2AHB2ENR_GPIODEN   %1 3 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_GPIODEN    CPU2 IO port D clock enable
: RCC-C2AHB2ENR_GPIOCEN   %1 2 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_GPIOCEN    CPU2 IO port C clock enable
: RCC-C2AHB2ENR_GPIOBEN   %1 1 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_GPIOBEN    CPU2 IO port B clock enable
: RCC-C2AHB2ENR_GPIOAEN   %1 0 lshift RCC-C2AHB2ENR bis! ;  \ RCC-C2AHB2ENR_GPIOAEN    CPU2 IO port A clock enable

\ RCC-C2AHB3ENR (read-write)
: RCC-C2AHB3ENR_FLASHEN   %1 25 lshift RCC-C2AHB3ENR bis! ;  \ RCC-C2AHB3ENR_FLASHEN    CPU2 FLASHEN
: RCC-C2AHB3ENR_IPCCEN   %1 20 lshift RCC-C2AHB3ENR bis! ;  \ RCC-C2AHB3ENR_IPCCEN    CPU2 IPCCEN
: RCC-C2AHB3ENR_HSEMEN   %1 19 lshift RCC-C2AHB3ENR bis! ;  \ RCC-C2AHB3ENR_HSEMEN    CPU2 HSEMEN
: RCC-C2AHB3ENR_RNGEN   %1 18 lshift RCC-C2AHB3ENR bis! ;  \ RCC-C2AHB3ENR_RNGEN    CPU2 RNGEN
: RCC-C2AHB3ENR_AES2EN   %1 17 lshift RCC-C2AHB3ENR bis! ;  \ RCC-C2AHB3ENR_AES2EN    CPU2 AES2EN
: RCC-C2AHB3ENR_PKAEN   %1 16 lshift RCC-C2AHB3ENR bis! ;  \ RCC-C2AHB3ENR_PKAEN    CPU2 PKAEN

\ RCC-C2APB1ENR1 (read-write)
: RCC-C2APB1ENR1_LPTIM1EN   %1 31 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_LPTIM1EN    CPU2 Low power timer 1 clock enable
: RCC-C2APB1ENR1_USBEN   %1 26 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_USBEN    CPU2 USB clock enable
: RCC-C2APB1ENR1_CRSEN   %1 24 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_CRSEN    CPU2 CRS clock enable
: RCC-C2APB1ENR1_I2C3EN   %1 23 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_I2C3EN    CPU2 I2C3 clock enable
: RCC-C2APB1ENR1_I2C1EN   %1 21 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_I2C1EN    CPU2 I2C1 clock enable
: RCC-C2APB1ENR1_SPI2EN   %1 14 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_SPI2EN    CPU2 SPI2 clock enable
: RCC-C2APB1ENR1_RTCAPBEN   %1 10 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_RTCAPBEN    CPU2 RTC APB clock enable
: RCC-C2APB1ENR1_LCDEN   %1 9 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_LCDEN    CPU2 LCD clock enable
: RCC-C2APB1ENR1_TIM2EN   %1 0 lshift RCC-C2APB1ENR1 bis! ;  \ RCC-C2APB1ENR1_TIM2EN    CPU2 TIM2 timer clock enable

\ RCC-C2APB1ENR2 (read-write)
: RCC-C2APB1ENR2_LPTIM2EN   %1 5 lshift RCC-C2APB1ENR2 bis! ;  \ RCC-C2APB1ENR2_LPTIM2EN    CPU2 LPTIM2EN
: RCC-C2APB1ENR2_LPUART1EN   %1 0 lshift RCC-C2APB1ENR2 bis! ;  \ RCC-C2APB1ENR2_LPUART1EN    CPU2 Low power UART 1 clock enable

\ RCC-C2APB2ENR (read-write)
: RCC-C2APB2ENR_SAI1EN   %1 21 lshift RCC-C2APB2ENR bis! ;  \ RCC-C2APB2ENR_SAI1EN    CPU2 SAI1 clock enable
: RCC-C2APB2ENR_TIM17EN   %1 18 lshift RCC-C2APB2ENR bis! ;  \ RCC-C2APB2ENR_TIM17EN    CPU2 TIM17 timer clock enable
: RCC-C2APB2ENR_TIM16EN   %1 17 lshift RCC-C2APB2ENR bis! ;  \ RCC-C2APB2ENR_TIM16EN    CPU2 TIM16 timer clock enable
: RCC-C2APB2ENR_USART1EN   %1 14 lshift RCC-C2APB2ENR bis! ;  \ RCC-C2APB2ENR_USART1EN    CPU2 USART1clock enable
: RCC-C2APB2ENR_SPI1EN   %1 12 lshift RCC-C2APB2ENR bis! ;  \ RCC-C2APB2ENR_SPI1EN    CPU2 SPI1 clock enable
: RCC-C2APB2ENR_TIM1EN   %1 11 lshift RCC-C2APB2ENR bis! ;  \ RCC-C2APB2ENR_TIM1EN    CPU2 TIM1 timer clock enable

\ RCC-C2APB3ENR (read-write)
: RCC-C2APB3ENR_EN802   %1 1 lshift RCC-C2APB3ENR bis! ;  \ RCC-C2APB3ENR_EN802    CPU2 802.15.4 interface clock enable
: RCC-C2APB3ENR_BLEEN   %1 0 lshift RCC-C2APB3ENR bis! ;  \ RCC-C2APB3ENR_BLEEN    CPU2 BLE interface clock enable

\ RCC-C2AHB1SMENR (read-write)
: RCC-C2AHB1SMENR_TSCSMEN   %1 16 lshift RCC-C2AHB1SMENR bis! ;  \ RCC-C2AHB1SMENR_TSCSMEN    CPU2 Touch Sensing Controller clocks enable during Sleep and Stop modes
: RCC-C2AHB1SMENR_CRCSMEN   %1 12 lshift RCC-C2AHB1SMENR bis! ;  \ RCC-C2AHB1SMENR_CRCSMEN    CPU2 CRCSMEN
: RCC-C2AHB1SMENR_SRAM1SMEN   %1 9 lshift RCC-C2AHB1SMENR bis! ;  \ RCC-C2AHB1SMENR_SRAM1SMEN    SRAM1 interface clock enable during CPU1 CSleep mode
: RCC-C2AHB1SMENR_DMAMUXSMEN   %1 2 lshift RCC-C2AHB1SMENR bis! ;  \ RCC-C2AHB1SMENR_DMAMUXSMEN    CPU2 DMAMUX clocks enable during Sleep and Stop modes
: RCC-C2AHB1SMENR_DMA2SMEN   %1 1 lshift RCC-C2AHB1SMENR bis! ;  \ RCC-C2AHB1SMENR_DMA2SMEN    CPU2 DMA2 clocks enable during Sleep and Stop modes
: RCC-C2AHB1SMENR_DMA1SMEN   %1 0 lshift RCC-C2AHB1SMENR bis! ;  \ RCC-C2AHB1SMENR_DMA1SMEN    CPU2 DMA1 clocks enable during Sleep and Stop modes

\ RCC-C2AHB2SMENR (read-write)
: RCC-C2AHB2SMENR_AES1SMEN   %1 16 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_AES1SMEN    CPU2 AES1 accelerator clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_ADCFSSMEN   %1 13 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_ADCFSSMEN    CPU2 ADC clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_GPIOHSMEN   %1 7 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_GPIOHSMEN    CPU2 IO port H clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_GPIOESMEN   %1 4 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_GPIOESMEN    CPU2 IO port E clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_GPIODSMEN   %1 3 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_GPIODSMEN    CPU2 IO port D clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_GPIOCSMEN   %1 2 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_GPIOCSMEN    CPU2 IO port C clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_GPIOBSMEN   %1 1 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_GPIOBSMEN    CPU2 IO port B clocks enable during Sleep and Stop modes
: RCC-C2AHB2SMENR_GPIOASMEN   %1 0 lshift RCC-C2AHB2SMENR bis! ;  \ RCC-C2AHB2SMENR_GPIOASMEN    CPU2 IO port A clocks enable during Sleep and Stop modes

\ RCC-C2AHB3SMENR (read-write)
: RCC-C2AHB3SMENR_FLASHSMEN   %1 25 lshift RCC-C2AHB3SMENR bis! ;  \ RCC-C2AHB3SMENR_FLASHSMEN    Flash interface clocks enable during CPU2 sleep modes
: RCC-C2AHB3SMENR_SRAM2SMEN   %1 24 lshift RCC-C2AHB3SMENR bis! ;  \ RCC-C2AHB3SMENR_SRAM2SMEN    SRAM2a and SRAM2b memory interface clocks enable during CPU2 sleep modes
: RCC-C2AHB3SMENR_RNGSMEN   %1 18 lshift RCC-C2AHB3SMENR bis! ;  \ RCC-C2AHB3SMENR_RNGSMEN    True RNG clocks enable during CPU2 sleep modes
: RCC-C2AHB3SMENR_AES2SMEN   %1 17 lshift RCC-C2AHB3SMENR bis! ;  \ RCC-C2AHB3SMENR_AES2SMEN    AES2 accelerator clocks enable during CPU2 sleep modes
: RCC-C2AHB3SMENR_PKASMEN   %1 16 lshift RCC-C2AHB3SMENR bis! ;  \ RCC-C2AHB3SMENR_PKASMEN    PKA accelerator clocks enable during CPU2 sleep modes

\ RCC-C2APB1SMENR1 (read-write)
: RCC-C2APB1SMENR1_LPTIM1SMEN   %1 31 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_LPTIM1SMEN    Low power timer 1 clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_USBSMEN   %1 26 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_USBSMEN    USB FS clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_CRSMEN   %1 24 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_CRSMEN    CRS clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_I2C3SMEN   %1 23 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_I2C3SMEN    I2C3 clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_I2C1SMEN   %1 21 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_I2C1SMEN    I2C1 clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_SPI2SMEN   %1 14 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_SPI2SMEN    SPI2 clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_RTCAPBSMEN   %1 10 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_RTCAPBSMEN    RTC APB clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_LCDSMEN   %1 9 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_LCDSMEN    LCD clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR1_TIM2SMEN   %1 0 lshift RCC-C2APB1SMENR1 bis! ;  \ RCC-C2APB1SMENR1_TIM2SMEN    TIM2 timer clocks enable during CPU2 Sleep mode

\ RCC-C2APB1SMENR2 (read-write)
: RCC-C2APB1SMENR2_LPTIM2SMEN   %1 5 lshift RCC-C2APB1SMENR2 bis! ;  \ RCC-C2APB1SMENR2_LPTIM2SMEN    Low power timer 2 clocks enable during CPU2 Sleep mode
: RCC-C2APB1SMENR2_LPUART1SMEN   %1 0 lshift RCC-C2APB1SMENR2 bis! ;  \ RCC-C2APB1SMENR2_LPUART1SMEN    Low power UART 1 clocks enable during CPU2 Sleep mode

\ RCC-C2APB2SMENR (read-write)
: RCC-C2APB2SMENR_SAI1SMEN   %1 21 lshift RCC-C2APB2SMENR bis! ;  \ RCC-C2APB2SMENR_SAI1SMEN    SAI1 clocks enable during CPU2 Sleep mode
: RCC-C2APB2SMENR_TIM17SMEN   %1 18 lshift RCC-C2APB2SMENR bis! ;  \ RCC-C2APB2SMENR_TIM17SMEN    TIM17 timer clocks enable during CPU2 Sleep mode
: RCC-C2APB2SMENR_TIM16SMEN   %1 17 lshift RCC-C2APB2SMENR bis! ;  \ RCC-C2APB2SMENR_TIM16SMEN    TIM16 timer clocks enable during CPU2 Sleep mode
: RCC-C2APB2SMENR_USART1SMEN   %1 14 lshift RCC-C2APB2SMENR bis! ;  \ RCC-C2APB2SMENR_USART1SMEN    USART1clocks enable during CPU2 Sleep mode
: RCC-C2APB2SMENR_SPI1SMEN   %1 12 lshift RCC-C2APB2SMENR bis! ;  \ RCC-C2APB2SMENR_SPI1SMEN    SPI1 clocks enable during CPU2 Sleep mode
: RCC-C2APB2SMENR_TIM1SMEN   %1 11 lshift RCC-C2APB2SMENR bis! ;  \ RCC-C2APB2SMENR_TIM1SMEN    TIM1 timer clocks enable during CPU2 Sleep mode

\ RCC-C2APB3SMENR (read-write)
: RCC-C2APB3SMENR_SMEN802   %1 1 lshift RCC-C2APB3SMENR bis! ;  \ RCC-C2APB3SMENR_SMEN802    802.15.4 interface clocks enable during CPU2 Sleep modes
: RCC-C2APB3SMENR_BLESMEN   %1 0 lshift RCC-C2APB3SMENR bis! ;  \ RCC-C2APB3SMENR_BLESMEN    BLE interface clocks enable during CPU2 Sleep mode

\ PWR-CR1 (read-write)
: PWR-CR1_LPR   %1 14 lshift PWR-CR1 bis! ;  \ PWR-CR1_LPR    Low-power run
: PWR-CR1_VOS   ( %XX -- ) 9 lshift PWR-CR1 bis! ;  \ PWR-CR1_VOS    Voltage scaling range selection
: PWR-CR1_DBP   %1 8 lshift PWR-CR1 bis! ;  \ PWR-CR1_DBP    Disable backup domain write protection
: PWR-CR1_FPDS   %1 5 lshift PWR-CR1 bis! ;  \ PWR-CR1_FPDS    Flash power down mode during LPsSleep for CPU1
: PWR-CR1_FPDR   %1 4 lshift PWR-CR1 bis! ;  \ PWR-CR1_FPDR    Flash power down mode during LPRun for CPU1
: PWR-CR1_LPMS   ( %XXX -- ) 0 lshift PWR-CR1 bis! ;  \ PWR-CR1_LPMS    Low-power mode selection for CPU1

\ PWR-CR2 (read-write)
: PWR-CR2_USV   %1 10 lshift PWR-CR2 bis! ;  \ PWR-CR2_USV    VDDUSB USB supply valid
: PWR-CR2_PVME3   %1 6 lshift PWR-CR2 bis! ;  \ PWR-CR2_PVME3    Peripheral voltage monitoring 3 enable: VDDA vs. 1.62V
: PWR-CR2_PVME1   %1 4 lshift PWR-CR2 bis! ;  \ PWR-CR2_PVME1    Peripheral voltage monitoring 1 enable: VDDUSB vs. 1.2V
: PWR-CR2_PLS   ( %XXX -- ) 1 lshift PWR-CR2 bis! ;  \ PWR-CR2_PLS    Power voltage detector level selection
: PWR-CR2_PVDE   %1 0 lshift PWR-CR2 bis! ;  \ PWR-CR2_PVDE    Power voltage detector enable

\ PWR-CR3 (read-write)
: PWR-CR3_EIWUL   %1 15 lshift PWR-CR3 bis! ;  \ PWR-CR3_EIWUL    Enable internal wakeup line for CPU1
: PWR-CR3_EC2H   %1 14 lshift PWR-CR3 bis! ;  \ PWR-CR3_EC2H    Enable CPU2 Hold interrupt for CPU1
: PWR-CR3_E802A   %1 13 lshift PWR-CR3 bis! ;  \ PWR-CR3_E802A    Enable end of activity interrupt for CPU1
: PWR-CR3_EBLEA   %1 11 lshift PWR-CR3 bis! ;  \ PWR-CR3_EBLEA    Enable BLE end of activity interrupt for CPU1
: PWR-CR3_ECRPE   %1 12 lshift PWR-CR3 bis! ;  \ PWR-CR3_ECRPE    Enable critical radio phase end of activity interrupt for CPU1
: PWR-CR3_APC   %1 10 lshift PWR-CR3 bis! ;  \ PWR-CR3_APC    Apply pull-up and pull-down configuration
: PWR-CR3_RRS   %1 9 lshift PWR-CR3 bis! ;  \ PWR-CR3_RRS    SRAM2a retention in Standby mode
: PWR-CR3_EBORHSDFB   %1 8 lshift PWR-CR3 bis! ;  \ PWR-CR3_EBORHSDFB    Enable BORH and Step Down counverter forced in Bypass interrups for CPU1
: PWR-CR3_EWUP5   %1 4 lshift PWR-CR3 bis! ;  \ PWR-CR3_EWUP5    Enable Wakeup pin WKUP5
: PWR-CR3_EWUP4   %1 3 lshift PWR-CR3 bis! ;  \ PWR-CR3_EWUP4    Enable Wakeup pin WKUP4
: PWR-CR3_EWUP3   %1 2 lshift PWR-CR3 bis! ;  \ PWR-CR3_EWUP3    Enable Wakeup pin WKUP3
: PWR-CR3_EWUP2   %1 1 lshift PWR-CR3 bis! ;  \ PWR-CR3_EWUP2    Enable Wakeup pin WKUP2
: PWR-CR3_EWUP1   %1 0 lshift PWR-CR3 bis! ;  \ PWR-CR3_EWUP1    Enable Wakeup pin WKUP1

\ PWR-CR4 (read-write)
: PWR-CR4_C2BOOT   %1 15 lshift PWR-CR4 bis! ;  \ PWR-CR4_C2BOOT    BOOT CPU2 after reset or wakeup from Stop or Standby modes
: PWR-CR4_VBRS   %1 9 lshift PWR-CR4 bis! ;  \ PWR-CR4_VBRS    VBAT battery charging resistor selection
: PWR-CR4_VBE   %1 8 lshift PWR-CR4 bis! ;  \ PWR-CR4_VBE    VBAT battery charging enable
: PWR-CR4_WP5   %1 4 lshift PWR-CR4 bis! ;  \ PWR-CR4_WP5    Wakeup pin WKUP5 polarity
: PWR-CR4_WP4   %1 3 lshift PWR-CR4 bis! ;  \ PWR-CR4_WP4    Wakeup pin WKUP4 polarity
: PWR-CR4_WP3   %1 2 lshift PWR-CR4 bis! ;  \ PWR-CR4_WP3    Wakeup pin WKUP3 polarity
: PWR-CR4_WP2   %1 1 lshift PWR-CR4 bis! ;  \ PWR-CR4_WP2    Wakeup pin WKUP2 polarity
: PWR-CR4_WP1   %1 0 lshift PWR-CR4 bis! ;  \ PWR-CR4_WP1    Wakeup pin WKUP1 polarity

\ PWR-SR1 (read-only)
: PWR-SR1_WUFI   %1 15 lshift PWR-SR1 bis! ;  \ PWR-SR1_WUFI    Internal Wakeup interrupt flag
: PWR-SR1_C2HF   %1 14 lshift PWR-SR1 bis! ;  \ PWR-SR1_C2HF    CPU2 Hold interrupt flag
: PWR-SR1_AF802   %1 13 lshift PWR-SR1 bis! ;  \ PWR-SR1_AF802    802.15.4 end of activity interrupt flag
: PWR-SR1_BLEAF   %1 12 lshift PWR-SR1 bis! ;  \ PWR-SR1_BLEAF    BLE end of activity interrupt flag
: PWR-SR1_CRPEF   %1 11 lshift PWR-SR1 bis! ;  \ PWR-SR1_CRPEF    Enable critical radio phase end of activity interrupt flag
: PWR-SR1_802WUF   %1 10 lshift PWR-SR1 bis! ;  \ PWR-SR1_802WUF    802.15.4 wakeup interrupt flag
: PWR-SR1_BLEWUF   %1 9 lshift PWR-SR1 bis! ;  \ PWR-SR1_BLEWUF    BLE wakeup interrupt flag
: PWR-SR1_BORHF   %1 8 lshift PWR-SR1 bis! ;  \ PWR-SR1_BORHF    BORH interrupt flag
: PWR-SR1_SDFBF   %1 7 lshift PWR-SR1 bis! ;  \ PWR-SR1_SDFBF    Step Down converter forced in Bypass interrupt flag
: PWR-SR1_CWUF5   %1 4 lshift PWR-SR1 bis! ;  \ PWR-SR1_CWUF5    Wakeup flag 5
: PWR-SR1_CWUF4   %1 3 lshift PWR-SR1 bis! ;  \ PWR-SR1_CWUF4    Wakeup flag 4
: PWR-SR1_CWUF3   %1 2 lshift PWR-SR1 bis! ;  \ PWR-SR1_CWUF3    Wakeup flag 3
: PWR-SR1_CWUF2   %1 1 lshift PWR-SR1 bis! ;  \ PWR-SR1_CWUF2    Wakeup flag 2
: PWR-SR1_CWUF1   %1 0 lshift PWR-SR1 bis! ;  \ PWR-SR1_CWUF1    Wakeup flag 1

\ PWR-SR2 (read-only)
: PWR-SR2_PVMO3   %1 14 lshift PWR-SR2 bis! ;  \ PWR-SR2_PVMO3    Peripheral voltage monitoring output: VDDA vs. 1.62 V
: PWR-SR2_PVMO1   %1 12 lshift PWR-SR2 bis! ;  \ PWR-SR2_PVMO1    Peripheral voltage monitoring output: VDDUSB vs. 1.2 V
: PWR-SR2_PVDO   %1 11 lshift PWR-SR2 bis! ;  \ PWR-SR2_PVDO    Power voltage detector output
: PWR-SR2_VOSF   %1 10 lshift PWR-SR2 bis! ;  \ PWR-SR2_VOSF    Voltage scaling flag
: PWR-SR2_REGLPF   %1 9 lshift PWR-SR2 bis! ;  \ PWR-SR2_REGLPF    Low-power regulator flag
: PWR-SR2_REGLPS   %1 8 lshift PWR-SR2 bis! ;  \ PWR-SR2_REGLPS    Low-power regulator started
: PWR-SR2_SDSMPSF   %1 1 lshift PWR-SR2 bis! ;  \ PWR-SR2_SDSMPSF    Step Down converter SMPS mode flag
: PWR-SR2_SDBF   %1 0 lshift PWR-SR2 bis! ;  \ PWR-SR2_SDBF    Step Down converter Bypass mode flag

\ PWR-SCR (write-only)
: PWR-SCR_CC2HF   %1 14 lshift PWR-SCR bis! ;  \ PWR-SCR_CC2HF    Clear CPU2 Hold interrupt flag
: PWR-SCR_C802AF   %1 13 lshift PWR-SCR bis! ;  \ PWR-SCR_C802AF    Clear 802.15.4 end of activity interrupt flag
: PWR-SCR_CBLEAF   %1 12 lshift PWR-SCR bis! ;  \ PWR-SCR_CBLEAF    Clear BLE end of activity interrupt flag
: PWR-SCR_CCRPEF   %1 11 lshift PWR-SCR bis! ;  \ PWR-SCR_CCRPEF    Clear critical radio phase end of activity interrupt flag
: PWR-SCR_C802WUF   %1 10 lshift PWR-SCR bis! ;  \ PWR-SCR_C802WUF    Clear 802.15.4 wakeup interrupt flag
: PWR-SCR_CBLEWUF   %1 9 lshift PWR-SCR bis! ;  \ PWR-SCR_CBLEWUF    Clear BLE wakeup interrupt flag
: PWR-SCR_CBORHF   %1 8 lshift PWR-SCR bis! ;  \ PWR-SCR_CBORHF    Clear BORH interrupt flag
: PWR-SCR_CSMPSFBF   %1 7 lshift PWR-SCR bis! ;  \ PWR-SCR_CSMPSFBF    Clear SMPS Step Down converter forced in Bypass interrupt flag
: PWR-SCR_CWUF5   %1 4 lshift PWR-SCR bis! ;  \ PWR-SCR_CWUF5    Clear wakeup flag 5
: PWR-SCR_CWUF4   %1 3 lshift PWR-SCR bis! ;  \ PWR-SCR_CWUF4    Clear wakeup flag 4
: PWR-SCR_CWUF3   %1 2 lshift PWR-SCR bis! ;  \ PWR-SCR_CWUF3    Clear wakeup flag 3
: PWR-SCR_CWUF2   %1 1 lshift PWR-SCR bis! ;  \ PWR-SCR_CWUF2    Clear wakeup flag 2
: PWR-SCR_CWUF1   %1 0 lshift PWR-SCR bis! ;  \ PWR-SCR_CWUF1    Clear wakeup flag 1

\ PWR-CR5 (read-write)
: PWR-CR5_SDEB   %1 15 lshift PWR-CR5 bis! ;  \ PWR-CR5_SDEB    Enable Step Down converter SMPS mode enabled
: PWR-CR5_SDBEN   %1 14 lshift PWR-CR5 bis! ;  \ PWR-CR5_SDBEN    Enable Step Down converter Bypass mode enabled
: PWR-CR5_SMPSCFG   %1 9 lshift PWR-CR5 bis! ;  \ PWR-CR5_SMPSCFG    VOS configuration selection non user
: PWR-CR5_BORHC   %1 8 lshift PWR-CR5 bis! ;  \ PWR-CR5_BORHC    BORH configuration selection
: PWR-CR5_SDSC   ( %XXX -- ) 4 lshift PWR-CR5 bis! ;  \ PWR-CR5_SDSC    Step Down converter supplt startup current selection
: PWR-CR5_SDVOS   ( %XXXX -- ) 0 lshift PWR-CR5 bis! ;  \ PWR-CR5_SDVOS    Step Down converter voltage output scaling

\ PWR-PUCRA (read-write)
: PWR-PUCRA_PU15   %1 15 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU15    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU13   %1 13 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU13    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU12   %1 12 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU12    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU11   %1 11 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU11    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU10   %1 10 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU10    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU9   %1 9 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU9    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU8   %1 8 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU8    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU7   %1 7 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU7    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU6   %1 6 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU6    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU5   %1 5 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU5    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU4   %1 4 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU4    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU3   %1 3 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU3    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU2   %1 2 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU2    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU1   %1 1 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU1    Port A pull-up bit y y=0..15
: PWR-PUCRA_PU0   %1 0 lshift PWR-PUCRA bis! ;  \ PWR-PUCRA_PU0    Port A pull-up bit y y=0..15

\ PWR-PDCRA (read-write)
: PWR-PDCRA_PD14   %1 14 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD14    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD12   %1 12 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD12    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD11   %1 11 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD11    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD10   %1 10 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD10    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD9   %1 9 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD9    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD8   %1 8 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD8    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD7   %1 7 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD7    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD6   %1 6 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD6    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD5   %1 5 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD5    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD4   %1 4 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD4    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD3   %1 3 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD3    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD2   %1 2 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD2    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD1   %1 1 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD1    Port A pull-down bit y y=0..15
: PWR-PDCRA_PD0   %1 0 lshift PWR-PDCRA bis! ;  \ PWR-PDCRA_PD0    Port A pull-down bit y y=0..15

\ PWR-PUCRB (read-write)
: PWR-PUCRB_PU15   %1 15 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU15    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU14   %1 14 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU14    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU13   %1 13 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU13    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU12   %1 12 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU12    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU11   %1 11 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU11    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU10   %1 10 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU10    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU9   %1 9 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU9    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU8   %1 8 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU8    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU7   %1 7 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU7    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU6   %1 6 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU6    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU5   %1 5 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU5    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU4   %1 4 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU4    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU3   %1 3 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU3    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU2   %1 2 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU2    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU1   %1 1 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU1    Port B pull-up bit y y=0..15
: PWR-PUCRB_PU0   %1 0 lshift PWR-PUCRB bis! ;  \ PWR-PUCRB_PU0    Port B pull-up bit y y=0..15

\ PWR-PDCRB (read-write)
: PWR-PDCRB_PD15   %1 15 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD15    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD14   %1 14 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD14    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD13   %1 13 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD13    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD12   %1 12 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD12    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD11   %1 11 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD11    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD10   %1 10 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD10    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD9   %1 9 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD9    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD8   %1 8 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD8    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD7   %1 7 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD7    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD6   %1 6 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD6    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD5   %1 5 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD5    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD3   %1 3 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD3    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD2   %1 2 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD2    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD1   %1 1 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD1    Port B pull-down bit y y=0..15
: PWR-PDCRB_PD0   %1 0 lshift PWR-PDCRB bis! ;  \ PWR-PDCRB_PD0    Port B pull-down bit y y=0..15

\ PWR-PUCRC (read-write)
: PWR-PUCRC_PU15   %1 15 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU15    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU14   %1 14 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU14    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU13   %1 13 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU13    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU12   %1 12 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU12    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU11   %1 11 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU11    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU10   %1 10 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU10    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU9   %1 9 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU9    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU8   %1 8 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU8    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU7   %1 7 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU7    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU6   %1 6 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU6    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU5   %1 5 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU5    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU4   %1 4 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU4    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU3   %1 3 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU3    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU2   %1 2 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU2    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU1   %1 1 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU1    Port C pull-up bit y y=0..15
: PWR-PUCRC_PU0   %1 0 lshift PWR-PUCRC bis! ;  \ PWR-PUCRC_PU0    Port C pull-up bit y y=0..15

\ PWR-PDCRC (read-write)
: PWR-PDCRC_PD15   %1 15 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD15    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD14   %1 14 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD14    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD13   %1 13 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD13    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD12   %1 12 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD12    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD11   %1 11 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD11    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD10   %1 10 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD10    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD9   %1 9 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD9    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD8   %1 8 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD8    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD7   %1 7 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD7    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD6   %1 6 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD6    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD5   %1 5 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD5    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD4   %1 4 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD4    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD3   %1 3 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD3    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD2   %1 2 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD2    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD1   %1 1 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD1    Port C pull-down bit y y=0..15
: PWR-PDCRC_PD0   %1 0 lshift PWR-PDCRC bis! ;  \ PWR-PDCRC_PD0    Port C pull-down bit y y=0..15

\ PWR-PUCRD (read-write)
: PWR-PUCRD_PU15   %1 15 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU15    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU14   %1 14 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU14    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU13   %1 13 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU13    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU12   %1 12 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU12    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU11   %1 11 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU11    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU10   %1 10 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU10    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU9   %1 9 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU9    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU8   %1 8 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU8    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU7   %1 7 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU7    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU6   %1 6 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU6    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU5   %1 5 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU5    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU4   %1 4 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU4    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU3   %1 3 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU3    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU2   %1 2 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU2    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU1   %1 1 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU1    Port D pull-up bit y y=0..15
: PWR-PUCRD_PU0   %1 0 lshift PWR-PUCRD bis! ;  \ PWR-PUCRD_PU0    Port D pull-up bit y y=0..15

\ PWR-PDCRD (read-write)
: PWR-PDCRD_PD15   %1 15 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD15    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD14   %1 14 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD14    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD13   %1 13 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD13    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD12   %1 12 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD12    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD11   %1 11 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD11    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD10   %1 10 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD10    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD9   %1 9 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD9    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD8   %1 8 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD8    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD7   %1 7 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD7    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD6   %1 6 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD6    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD5   %1 5 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD5    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD4   %1 4 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD4    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD3   %1 3 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD3    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD2   %1 2 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD2    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD1   %1 1 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD1    Port D pull-down bit y y=0..15
: PWR-PDCRD_PD0   %1 0 lshift PWR-PDCRD bis! ;  \ PWR-PDCRD_PD0    Port D pull-down bit y y=0..15

\ PWR-PUCRE (read-write)
: PWR-PUCRE_PU4   %1 4 lshift PWR-PUCRE bis! ;  \ PWR-PUCRE_PU4    Port E pull-up bit y y=0..15
: PWR-PUCRE_PU3   %1 3 lshift PWR-PUCRE bis! ;  \ PWR-PUCRE_PU3    Port E pull-up bit y y=0..15
: PWR-PUCRE_PU2   %1 2 lshift PWR-PUCRE bis! ;  \ PWR-PUCRE_PU2    Port E pull-up bit y y=0..15
: PWR-PUCRE_PU1   %1 1 lshift PWR-PUCRE bis! ;  \ PWR-PUCRE_PU1    Port E pull-up bit y y=0..15
: PWR-PUCRE_PU0   %1 0 lshift PWR-PUCRE bis! ;  \ PWR-PUCRE_PU0    Port E pull-up bit y y=0..15

\ PWR-PDCRE (read-write)
: PWR-PDCRE_PD4   %1 4 lshift PWR-PDCRE bis! ;  \ PWR-PDCRE_PD4    Port E pull-down bit y y=0..15
: PWR-PDCRE_PD3   %1 3 lshift PWR-PDCRE bis! ;  \ PWR-PDCRE_PD3    Port E pull-down bit y y=0..15
: PWR-PDCRE_PD2   %1 2 lshift PWR-PDCRE bis! ;  \ PWR-PDCRE_PD2    Port E pull-down bit y y=0..15
: PWR-PDCRE_PD1   %1 1 lshift PWR-PDCRE bis! ;  \ PWR-PDCRE_PD1    Port E pull-down bit y y=0..15
: PWR-PDCRE_PD0   %1 0 lshift PWR-PDCRE bis! ;  \ PWR-PDCRE_PD0    Port E pull-down bit y y=0..15

\ PWR-PUCRH (read-write)
: PWR-PUCRH_PU3   %1 3 lshift PWR-PUCRH bis! ;  \ PWR-PUCRH_PU3    Port H pull-up bit y y=0..1
: PWR-PUCRH_PU1   %1 1 lshift PWR-PUCRH bis! ;  \ PWR-PUCRH_PU1    Port H pull-up bit y y=0..1
: PWR-PUCRH_PU0   %1 0 lshift PWR-PUCRH bis! ;  \ PWR-PUCRH_PU0    Port H pull-up bit y y=0..1

\ PWR-PDCRH (read-write)
: PWR-PDCRH_PD3   %1 3 lshift PWR-PDCRH bis! ;  \ PWR-PDCRH_PD3    Port H pull-down bit y y=0..1
: PWR-PDCRH_PD1   %1 1 lshift PWR-PDCRH bis! ;  \ PWR-PDCRH_PD1    Port H pull-down bit y y=0..1
: PWR-PDCRH_PD0   %1 0 lshift PWR-PDCRH bis! ;  \ PWR-PDCRH_PD0    Port H pull-down bit y y=0..1

\ PWR-C2CR1 (read-write)
: PWR-C2CR1_802EWKUP   %1 15 lshift PWR-C2CR1 bis! ;  \ PWR-C2CR1_802EWKUP    802.15.4 external wakeup signal
: PWR-C2CR1_BLEEWKUP   %1 14 lshift PWR-C2CR1 bis! ;  \ PWR-C2CR1_BLEEWKUP    BLE external wakeup signal
: PWR-C2CR1_FPDS   %1 5 lshift PWR-C2CR1 bis! ;  \ PWR-C2CR1_FPDS    Flash power down mode during LPSleep for CPU2
: PWR-C2CR1_FPDR   %1 4 lshift PWR-C2CR1 bis! ;  \ PWR-C2CR1_FPDR    Flash power down mode during LPRun for CPU2
: PWR-C2CR1_LPMS   ( %XXX -- ) 0 lshift PWR-C2CR1 bis! ;  \ PWR-C2CR1_LPMS    Low-power mode selection for CPU2

\ PWR-C2CR3 (read-write)
: PWR-C2CR3_EIWUL   %1 15 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EIWUL    Enable internal wakeup line for CPU2
: PWR-C2CR3_APC   %1 12 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_APC    Apply pull-up and pull-down configuration for CPU2
: PWR-C2CR3_E802WUP   %1 10 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_E802WUP    Enable 802.15.4 host wakeup interrupt for CPU2
: PWR-C2CR3_EBLEWUP   %1 9 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EBLEWUP    Enable BLE host wakeup interrupt for CPU2
: PWR-C2CR3_EWUP5   %1 4 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EWUP5    Enable Wakeup pin WKUP5 for CPU2
: PWR-C2CR3_EWUP4   %1 3 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EWUP4    Enable Wakeup pin WKUP4 for CPU2
: PWR-C2CR3_EWUP3   %1 2 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EWUP3    Enable Wakeup pin WKUP3 for CPU2
: PWR-C2CR3_EWUP2   %1 1 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EWUP2    Enable Wakeup pin WKUP2 for CPU2
: PWR-C2CR3_EWUP1   %1 0 lshift PWR-C2CR3 bis! ;  \ PWR-C2CR3_EWUP1    Enable Wakeup pin WKUP1 for CPU2

\ PWR-EXTSCR ()
: PWR-EXTSCR_C2DS   %1 15 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C2DS    CPU2 deepsleep mode
: PWR-EXTSCR_C1DS   %1 14 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C1DS    CPU1 deepsleep mode
: PWR-EXTSCR_CRPF   %1 13 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_CRPF    Critical Radio system phase
: PWR-EXTSCR_C2STOPF   %1 11 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C2STOPF    System Stop flag for CPU2
: PWR-EXTSCR_C2SBF   %1 10 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C2SBF    System Standby flag for CPU2
: PWR-EXTSCR_C1STOPF   %1 9 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C1STOPF    System Stop flag for CPU1
: PWR-EXTSCR_C1SBF   %1 8 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C1SBF    System Standby flag for CPU1
: PWR-EXTSCR_CCRPF   %1 2 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_CCRPF    Clear Critical Radio system phase
: PWR-EXTSCR_C2CSSF   %1 1 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C2CSSF    Clear CPU2 Stop Standby flags
: PWR-EXTSCR_C1CSSF   %1 0 lshift PWR-EXTSCR bis! ;  \ PWR-EXTSCR_C1CSSF    Clear CPU1 Stop Standby flags

\ SYSCFG-MEMRMP (read-write)
: SYSCFG-MEMRMP_MEM_MODE   ( %XXX -- ) 0 lshift SYSCFG-MEMRMP bis! ;  \ SYSCFG-MEMRMP_MEM_MODE    Memory mapping selection

\ SYSCFG-CFGR1 (read-write)
: SYSCFG-CFGR1_FPU_IE   ( %XXXXXX -- ) 26 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_FPU_IE    Floating Point Unit interrupts enable bits
: SYSCFG-CFGR1_I2C3_FMP   %1 22 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_I2C3_FMP    I2C3 Fast-mode Plus driving capability activation
: SYSCFG-CFGR1_I2C1_FMP   %1 20 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_I2C1_FMP    I2C1 Fast-mode Plus driving capability activation
: SYSCFG-CFGR1_I2C_PB9_FMP   %1 19 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_I2C_PB9_FMP    Fast-mode Plus Fm+ driving capability activation on PB9
: SYSCFG-CFGR1_I2C_PB8_FMP   %1 18 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_I2C_PB8_FMP    Fast-mode Plus Fm+ driving capability activation on PB8
: SYSCFG-CFGR1_I2C_PB7_FMP   %1 17 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_I2C_PB7_FMP    Fast-mode Plus Fm+ driving capability activation on PB7
: SYSCFG-CFGR1_I2C_PB6_FMP   %1 16 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_I2C_PB6_FMP    Fast-mode Plus Fm+ driving capability activation on PB6
: SYSCFG-CFGR1_BOOSTEN   %1 8 lshift SYSCFG-CFGR1 bis! ;  \ SYSCFG-CFGR1_BOOSTEN    I/O analog switch voltage booster enable

\ SYSCFG-EXTICR1 (read-write)
: SYSCFG-EXTICR1_EXTI3   ( %XXX -- ) 12 lshift SYSCFG-EXTICR1 bis! ;  \ SYSCFG-EXTICR1_EXTI3    EXTI 3 configuration bits
: SYSCFG-EXTICR1_EXTI2   ( %XXX -- ) 8 lshift SYSCFG-EXTICR1 bis! ;  \ SYSCFG-EXTICR1_EXTI2    EXTI 2 configuration bits
: SYSCFG-EXTICR1_EXTI1   ( %XXX -- ) 4 lshift SYSCFG-EXTICR1 bis! ;  \ SYSCFG-EXTICR1_EXTI1    EXTI 1 configuration bits
: SYSCFG-EXTICR1_EXTI0   ( %XXX -- ) 0 lshift SYSCFG-EXTICR1 bis! ;  \ SYSCFG-EXTICR1_EXTI0    EXTI 0 configuration bits

\ SYSCFG-EXTICR2 (read-write)
: SYSCFG-EXTICR2_EXTI7   ( %XXX -- ) 12 lshift SYSCFG-EXTICR2 bis! ;  \ SYSCFG-EXTICR2_EXTI7    EXTI 7 configuration bits
: SYSCFG-EXTICR2_EXTI6   ( %XXX -- ) 8 lshift SYSCFG-EXTICR2 bis! ;  \ SYSCFG-EXTICR2_EXTI6    EXTI 6 configuration bits
: SYSCFG-EXTICR2_EXTI5   ( %XXX -- ) 4 lshift SYSCFG-EXTICR2 bis! ;  \ SYSCFG-EXTICR2_EXTI5    EXTI 5 configuration bits
: SYSCFG-EXTICR2_EXTI4   ( %XXX -- ) 0 lshift SYSCFG-EXTICR2 bis! ;  \ SYSCFG-EXTICR2_EXTI4    EXTI 4 configuration bits

\ SYSCFG-EXTICR3 (read-write)
: SYSCFG-EXTICR3_EXTI11   ( %XXX -- ) 12 lshift SYSCFG-EXTICR3 bis! ;  \ SYSCFG-EXTICR3_EXTI11    EXTI 11 configuration bits
: SYSCFG-EXTICR3_EXTI10   ( %XXX -- ) 8 lshift SYSCFG-EXTICR3 bis! ;  \ SYSCFG-EXTICR3_EXTI10    EXTI 10 configuration bits
: SYSCFG-EXTICR3_EXTI9   ( %XXX -- ) 4 lshift SYSCFG-EXTICR3 bis! ;  \ SYSCFG-EXTICR3_EXTI9    EXTI 9 configuration bits
: SYSCFG-EXTICR3_EXTI8   ( %XXX -- ) 0 lshift SYSCFG-EXTICR3 bis! ;  \ SYSCFG-EXTICR3_EXTI8    EXTI 8 configuration bits

\ SYSCFG-EXTICR4 (read-write)
: SYSCFG-EXTICR4_EXTI15   ( %XXX -- ) 12 lshift SYSCFG-EXTICR4 bis! ;  \ SYSCFG-EXTICR4_EXTI15    EXTI15 configuration bits
: SYSCFG-EXTICR4_EXTI14   ( %XXX -- ) 8 lshift SYSCFG-EXTICR4 bis! ;  \ SYSCFG-EXTICR4_EXTI14    EXTI14 configuration bits
: SYSCFG-EXTICR4_EXTI13   ( %XXX -- ) 4 lshift SYSCFG-EXTICR4 bis! ;  \ SYSCFG-EXTICR4_EXTI13    EXTI13 configuration bits
: SYSCFG-EXTICR4_EXTI12   ( %XXX -- ) 0 lshift SYSCFG-EXTICR4 bis! ;  \ SYSCFG-EXTICR4_EXTI12    EXTI12 configuration bits

\ SYSCFG-SCSR ()
: SYSCFG-SCSR_SRAM2BSY   %1 1 lshift SYSCFG-SCSR bis! ;  \ SYSCFG-SCSR_SRAM2BSY    SRAM2 busy by erase operation
: SYSCFG-SCSR_SRAM2ER   %1 0 lshift SYSCFG-SCSR bis! ;  \ SYSCFG-SCSR_SRAM2ER    SRAM2 Erase
: SYSCFG-SCSR_C2RFD   %1 31 lshift SYSCFG-SCSR bis! ;  \ SYSCFG-SCSR_C2RFD    CPU2 SRAM fetch execution disable.

\ SYSCFG-CFGR2 ()
: SYSCFG-CFGR2_SPF   %1 8 lshift SYSCFG-CFGR2 bis! ;  \ SYSCFG-CFGR2_SPF    SRAM2 parity error flag
: SYSCFG-CFGR2_ECCL   %1 3 lshift SYSCFG-CFGR2 bis! ;  \ SYSCFG-CFGR2_ECCL    ECC Lock
: SYSCFG-CFGR2_PVDL   %1 2 lshift SYSCFG-CFGR2 bis! ;  \ SYSCFG-CFGR2_PVDL    PVD lock enable bit
: SYSCFG-CFGR2_SPL   %1 1 lshift SYSCFG-CFGR2 bis! ;  \ SYSCFG-CFGR2_SPL    SRAM2 parity lock bit
: SYSCFG-CFGR2_CLL   %1 0 lshift SYSCFG-CFGR2 bis! ;  \ SYSCFG-CFGR2_CLL    Cortex-M4 LOCKUP Hardfault output enable bit

\ SYSCFG-SWPR (write-only)
: SYSCFG-SWPR_P31WP   %1 31 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P31WP    SRAM2 page 31 write protection
: SYSCFG-SWPR_P30WP   %1 30 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P30WP    P30WP
: SYSCFG-SWPR_P29WP   %1 29 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P29WP    P29WP
: SYSCFG-SWPR_P28WP   %1 28 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P28WP    P28WP
: SYSCFG-SWPR_P27WP   %1 27 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P27WP    P27WP
: SYSCFG-SWPR_P26WP   %1 26 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P26WP    P26WP
: SYSCFG-SWPR_P25WP   %1 25 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P25WP    P25WP
: SYSCFG-SWPR_P24WP   %1 24 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P24WP    P24WP
: SYSCFG-SWPR_P23WP   %1 23 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P23WP    P23WP
: SYSCFG-SWPR_P22WP   %1 22 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P22WP    P22WP
: SYSCFG-SWPR_P21WP   %1 21 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P21WP    P21WP
: SYSCFG-SWPR_P20WP   %1 20 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P20WP    P20WP
: SYSCFG-SWPR_P19WP   %1 19 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P19WP    P19WP
: SYSCFG-SWPR_P18WP   %1 18 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P18WP    P18WP
: SYSCFG-SWPR_P17WP   %1 17 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P17WP    P17WP
: SYSCFG-SWPR_P16WP   %1 16 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P16WP    P16WP
: SYSCFG-SWPR_P15WP   %1 15 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P15WP    P15WP
: SYSCFG-SWPR_P14WP   %1 14 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P14WP    P14WP
: SYSCFG-SWPR_P13WP   %1 13 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P13WP    P13WP
: SYSCFG-SWPR_P12WP   %1 12 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P12WP    P12WP
: SYSCFG-SWPR_P11WP   %1 11 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P11WP    P11WP
: SYSCFG-SWPR_P10WP   %1 10 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P10WP    P10WP
: SYSCFG-SWPR_P9WP   %1 9 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P9WP    P9WP
: SYSCFG-SWPR_P8WP   %1 8 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P8WP    P8WP
: SYSCFG-SWPR_P7WP   %1 7 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P7WP    P7WP
: SYSCFG-SWPR_P6WP   %1 6 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P6WP    P6WP
: SYSCFG-SWPR_P5WP   %1 5 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P5WP    P5WP
: SYSCFG-SWPR_P4WP   %1 4 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P4WP    P4WP
: SYSCFG-SWPR_P3WP   %1 3 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P3WP    P3WP
: SYSCFG-SWPR_P2WP   %1 2 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P2WP    P2WP
: SYSCFG-SWPR_P1WP   %1 1 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P1WP    P1WP
: SYSCFG-SWPR_P0WP   %1 0 lshift SYSCFG-SWPR bis! ;  \ SYSCFG-SWPR_P0WP    P0WP

\ SYSCFG-SKR (write-only)
: SYSCFG-SKR_KEY   ( %XXXXXXXX -- ) 0 lshift SYSCFG-SKR bis! ;  \ SYSCFG-SKR_KEY    SRAM2 write protection key for software erase

\ SYSCFG-SWPR2 (write-only)
: SYSCFG-SWPR2_P63WP   %1 31 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P63WP    SRAM2 page 63 write protection
: SYSCFG-SWPR2_P62WP   %1 30 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P62WP    P62WP
: SYSCFG-SWPR2_P61WP   %1 29 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P61WP    P61WP
: SYSCFG-SWPR2_P60WP   %1 28 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P60WP    P60WP
: SYSCFG-SWPR2_P59WP   %1 27 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P59WP    P59WP
: SYSCFG-SWPR2_P58WP   %1 26 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P58WP    P58WP
: SYSCFG-SWPR2_P57WP   %1 25 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P57WP    P57WP
: SYSCFG-SWPR2_P56WP   %1 24 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P56WP    P56WP
: SYSCFG-SWPR2_P55WP   %1 23 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P55WP    P55WP
: SYSCFG-SWPR2_P54WP   %1 22 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P54WP    P54WP
: SYSCFG-SWPR2_P53WP   %1 21 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P53WP    P53WP
: SYSCFG-SWPR2_P52WP   %1 20 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P52WP    P52WP
: SYSCFG-SWPR2_P51WP   %1 19 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P51WP    P51WP
: SYSCFG-SWPR2_P50WP   %1 18 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P50WP    P50WP
: SYSCFG-SWPR2_P49WP   %1 17 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P49WP    P49WP
: SYSCFG-SWPR2_P48WP   %1 16 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P48WP    P48WP
: SYSCFG-SWPR2_P47WP   %1 15 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P47WP    P47WP
: SYSCFG-SWPR2_P46WP   %1 14 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P46WP    P46WP
: SYSCFG-SWPR2_P45WP   %1 13 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P45WP    P45WP
: SYSCFG-SWPR2_P44WP   %1 12 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P44WP    P44WP
: SYSCFG-SWPR2_P43WP   %1 11 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P43WP    P43WP
: SYSCFG-SWPR2_P42WP   %1 10 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P42WP    P42WP
: SYSCFG-SWPR2_P41WP   %1 9 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P41WP    P41WP
: SYSCFG-SWPR2_P40WP   %1 8 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P40WP    P40WP
: SYSCFG-SWPR2_P39WP   %1 7 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P39WP    P39WP
: SYSCFG-SWPR2_P38WP   %1 6 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P38WP    P38WP
: SYSCFG-SWPR2_P37WP   %1 5 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P37WP    P37WP
: SYSCFG-SWPR2_P36WP   %1 4 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P36WP    P36WP
: SYSCFG-SWPR2_P35WP   %1 3 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P35WP    P35WP
: SYSCFG-SWPR2_P34WP   %1 2 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P34WP    P34WP
: SYSCFG-SWPR2_P33WP   %1 1 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P33WP    P33WP
: SYSCFG-SWPR2_P32WP   %1 0 lshift SYSCFG-SWPR2 bis! ;  \ SYSCFG-SWPR2_P32WP    P32WP

\ SYSCFG-IMR1 (read-write)
: SYSCFG-IMR1_TIM1IM   %1 13 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_TIM1IM    Peripheral TIM1 interrupt mask to CPU1
: SYSCFG-IMR1_TIM16IM   %1 14 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_TIM16IM    Peripheral TIM16 interrupt mask to CPU1
: SYSCFG-IMR1_TIM17IM   %1 15 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_TIM17IM    Peripheral TIM17 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT5IM   %1 21 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT5IM    Peripheral EXIT5 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT6IM   %1 22 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT6IM    Peripheral EXIT6 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT7IM   %1 23 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT7IM    Peripheral EXIT7 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT8IM   %1 24 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT8IM    Peripheral EXIT8 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT9IM   %1 25 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT9IM    Peripheral EXIT9 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT10IM   %1 26 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT10IM    Peripheral EXIT10 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT11IM   %1 27 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT11IM    Peripheral EXIT11 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT12IM   %1 28 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT12IM    Peripheral EXIT12 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT13IM   %1 29 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT13IM    Peripheral EXIT13 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT14IM   %1 30 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT14IM    Peripheral EXIT14 interrupt mask to CPU1
: SYSCFG-IMR1_EXIT15IM   %1 31 lshift SYSCFG-IMR1 bis! ;  \ SYSCFG-IMR1_EXIT15IM    Peripheral EXIT15 interrupt mask to CPU1

\ SYSCFG-IMR2 (read-write)
: SYSCFG-IMR2_PVM3IM   %1 18 lshift SYSCFG-IMR2 bis! ;  \ SYSCFG-IMR2_PVM3IM    Peripheral PVM3 interrupt mask to CPU1
: SYSCFG-IMR2_PVM1IM   %1 16 lshift SYSCFG-IMR2 bis! ;  \ SYSCFG-IMR2_PVM1IM    Peripheral PVM1 interrupt mask to CPU1
: SYSCFG-IMR2_PVDIM   %1 20 lshift SYSCFG-IMR2 bis! ;  \ SYSCFG-IMR2_PVDIM    Peripheral PVD interrupt mask to CPU1

\ SYSCFG-C2IMR1 (read-write)
: SYSCFG-C2IMR1_RTCSTAMP   %1 0 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_RTCSTAMP    Peripheral RTCSTAMP interrupt mask to CPU2
: SYSCFG-C2IMR1_RTCWKUP   %1 3 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_RTCWKUP    Peripheral RTCWKUP interrupt mask to CPU2
: SYSCFG-C2IMR1_RTCALARM   %1 4 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_RTCALARM    Peripheral RTCALARM interrupt mask to CPU2
: SYSCFG-C2IMR1_RCC   %1 5 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_RCC    Peripheral RCC interrupt mask to CPU2
: SYSCFG-C2IMR1_FLASH   %1 6 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_FLASH    Peripheral FLASH interrupt mask to CPU2
: SYSCFG-C2IMR1_PKA   %1 8 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_PKA    Peripheral PKA interrupt mask to CPU2
: SYSCFG-C2IMR1_RNG   %1 9 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_RNG    Peripheral RNG interrupt mask to CPU2
: SYSCFG-C2IMR1_AES1   %1 10 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_AES1    Peripheral AES1 interrupt mask to CPU2
: SYSCFG-C2IMR1_COMP   %1 11 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_COMP    Peripheral COMP interrupt mask to CPU2
: SYSCFG-C2IMR1_ADC   %1 12 lshift SYSCFG-C2IMR1 bis! ;  \ SYSCFG-C2IMR1_ADC    Peripheral ADC interrupt mask to CPU2

\ SYSCFG-C2IMR2 (read-write)
: SYSCFG-C2IMR2_DMA1_CH1_IM   %1 0 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH1_IM    Peripheral DMA1 CH1 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA1_CH2_IM   %1 1 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH2_IM    Peripheral DMA1 CH2 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA1_CH3_IM   %1 2 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH3_IM    Peripheral DMA1 CH3 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA1_CH4_IM   %1 3 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH4_IM    Peripheral DMA1 CH4 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA1_CH5_IM   %1 4 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH5_IM    Peripheral DMA1 CH5 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA1_CH6_IM   %1 5 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH6_IM    Peripheral DMA1 CH6 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA1_CH7_IM   %1 6 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA1_CH7_IM    Peripheral DMA1 CH7 interrupt mask to CPU2
: SYSCFG-C2IMR2_DMA2_CH1_IM   %1 8 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH1_IM    Peripheral DMA2 CH1 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMA2_CH2_IM   %1 9 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH2_IM    Peripheral DMA2 CH2 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMA2_CH3_IM   %1 10 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH3_IM    Peripheral DMA2 CH3 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMA2_CH4_IM   %1 11 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH4_IM    Peripheral DMA2 CH4 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMA2_CH5_IM   %1 12 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH5_IM    Peripheral DMA2 CH5 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMA2_CH6_IM   %1 13 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH6_IM    Peripheral DMA2 CH6 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMA2_CH7_IM   %1 14 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMA2_CH7_IM    Peripheral DMA2 CH7 interrupt mask to CPU1
: SYSCFG-C2IMR2_DMAM_UX1_IM   %1 15 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_DMAM_UX1_IM    Peripheral DMAM UX1 interrupt mask to CPU1
: SYSCFG-C2IMR2_PVM1IM   %1 16 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_PVM1IM    Peripheral PVM1IM interrupt mask to CPU1
: SYSCFG-C2IMR2_PVM3IM   %1 18 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_PVM3IM    Peripheral PVM3IM interrupt mask to CPU1
: SYSCFG-C2IMR2_PVDIM   %1 20 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_PVDIM    Peripheral PVDIM interrupt mask to CPU1
: SYSCFG-C2IMR2_TSCIM   %1 21 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_TSCIM    Peripheral TSCIM interrupt mask to CPU1
: SYSCFG-C2IMR2_LCDIM   %1 22 lshift SYSCFG-C2IMR2 bis! ;  \ SYSCFG-C2IMR2_LCDIM    Peripheral LCDIM interrupt mask to CPU1

\ SYSCFG-SIPCR (read-write)
: SYSCFG-SIPCR_SAES1   %1 0 lshift SYSCFG-SIPCR bis! ;  \ SYSCFG-SIPCR_SAES1    Enable AES1 KEY[7:0] security.
: SYSCFG-SIPCR_SAES2   %1 1 lshift SYSCFG-SIPCR bis! ;  \ SYSCFG-SIPCR_SAES2    Enable AES2 security.
: SYSCFG-SIPCR_SPKA   %1 2 lshift SYSCFG-SIPCR bis! ;  \ SYSCFG-SIPCR_SPKA    Enable PKA security
: SYSCFG-SIPCR_SRNG   %1 3 lshift SYSCFG-SIPCR bis! ;  \ SYSCFG-SIPCR_SRNG    Enable True RNG security

\ RNG-CR (read-write)
: RNG-CR_RNGEN   %1 2 lshift RNG-CR bis! ;  \ RNG-CR_RNGEN    Random number generator enable
: RNG-CR_IE   %1 3 lshift RNG-CR bis! ;  \ RNG-CR_IE    Interrupt enable
: RNG-CR_BYP   %1 6 lshift RNG-CR bis! ;  \ RNG-CR_BYP    Bypass mode enable

\ RNG-SR ()
: RNG-SR_SEIS   %1 6 lshift RNG-SR bis! ;  \ RNG-SR_SEIS    Seed error interrupt status
: RNG-SR_CEIS   %1 5 lshift RNG-SR bis! ;  \ RNG-SR_CEIS    Clock error interrupt status
: RNG-SR_SECS   %1 2 lshift RNG-SR bis! ;  \ RNG-SR_SECS    Seed error current status
: RNG-SR_CECS   %1 1 lshift RNG-SR bis! ;  \ RNG-SR_CECS    Clock error current status
: RNG-SR_DRDY   %1 0 lshift RNG-SR bis! ;  \ RNG-SR_DRDY    Data ready

\ RNG-DR (read-only)
: RNG-DR_RNDATA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RNG-DR bis! ;  \ RNG-DR_RNDATA    Random data

\ AES1-CR (read-write)
: AES1-CR_NPBLB   ( %XXXX -- ) 20 lshift AES1-CR bis! ;  \ AES1-CR_NPBLB    Number of padding bytes in last block of payload
: AES1-CR_KEYSIZE   %1 18 lshift AES1-CR bis! ;  \ AES1-CR_KEYSIZE    Key size selection
: AES1-CR_CHMOD2   %1 16 lshift AES1-CR bis! ;  \ AES1-CR_CHMOD2    AES chaining mode Bit2
: AES1-CR_GCMPH   ( %XX -- ) 13 lshift AES1-CR bis! ;  \ AES1-CR_GCMPH    Used only for GCM, CCM and GMAC algorithms and has no effect when other algorithms are selected
: AES1-CR_DMAOUTEN   %1 12 lshift AES1-CR bis! ;  \ AES1-CR_DMAOUTEN    Enable DMA management of data output phase
: AES1-CR_DMAINEN   %1 11 lshift AES1-CR bis! ;  \ AES1-CR_DMAINEN    Enable DMA management of data input phase
: AES1-CR_ERRIE   %1 10 lshift AES1-CR bis! ;  \ AES1-CR_ERRIE    Error interrupt enable
: AES1-CR_CCFIE   %1 9 lshift AES1-CR bis! ;  \ AES1-CR_CCFIE    CCF flag interrupt enable
: AES1-CR_ERRC   %1 8 lshift AES1-CR bis! ;  \ AES1-CR_ERRC    Error clear
: AES1-CR_CCFC   %1 7 lshift AES1-CR bis! ;  \ AES1-CR_CCFC    Computation Complete Flag Clear
: AES1-CR_CHMOD10   ( %XX -- ) 5 lshift AES1-CR bis! ;  \ AES1-CR_CHMOD10    AES chaining mode Bit1 Bit0
: AES1-CR_MODE   ( %XX -- ) 3 lshift AES1-CR bis! ;  \ AES1-CR_MODE    AES operating mode
: AES1-CR_DATATYPE   ( %XX -- ) 1 lshift AES1-CR bis! ;  \ AES1-CR_DATATYPE    Data type selection for data in and data out to/from the cryptographic block
: AES1-CR_EN   %1 0 lshift AES1-CR bis! ;  \ AES1-CR_EN    AES enable

\ AES1-SR (read-only)
: AES1-SR_BUSY   %1 3 lshift AES1-SR bis! ;  \ AES1-SR_BUSY    Busy flag
: AES1-SR_WRERR   %1 2 lshift AES1-SR bis! ;  \ AES1-SR_WRERR    Write error flag
: AES1-SR_RDERR   %1 1 lshift AES1-SR bis! ;  \ AES1-SR_RDERR    Read error flag
: AES1-SR_CCF   %1 0 lshift AES1-SR bis! ;  \ AES1-SR_CCF    Computation complete flag

\ AES1-DINR (read-write)
: AES1-DINR_AES_DINR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-DINR bis! ;  \ AES1-DINR_AES_DINR    Data Input Register

\ AES1-DOUTR (read-only)
: AES1-DOUTR_AES_DOUTR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-DOUTR bis! ;  \ AES1-DOUTR_AES_DOUTR    Data output register

\ AES1-KEYR0 (read-write)
: AES1-KEYR0_AES_KEYR0   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR0 bis! ;  \ AES1-KEYR0_AES_KEYR0    Data Output Register LSB key [31:0]

\ AES1-KEYR1 (read-write)
: AES1-KEYR1_AES_KEYR1   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR1 bis! ;  \ AES1-KEYR1_AES_KEYR1    AES key register key [63:32]

\ AES1-KEYR2 (read-write)
: AES1-KEYR2_AES_KEYR2   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR2 bis! ;  \ AES1-KEYR2_AES_KEYR2    AES key register key [95:64]

\ AES1-KEYR3 (read-write)
: AES1-KEYR3_AES_KEYR3   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR3 bis! ;  \ AES1-KEYR3_AES_KEYR3    AES key register MSB key [127:96]

\ AES1-IVR0 (read-write)
: AES1-IVR0_AES_IVR0   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-IVR0 bis! ;  \ AES1-IVR0_AES_IVR0    initialization vector register LSB IVR [31:0]

\ AES1-IVR1 (read-write)
: AES1-IVR1_AES_IVR1   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-IVR1 bis! ;  \ AES1-IVR1_AES_IVR1    Initialization Vector Register IVR [63:32]

\ AES1-IVR2 (read-write)
: AES1-IVR2_AES_IVR2   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-IVR2 bis! ;  \ AES1-IVR2_AES_IVR2    Initialization Vector Register IVR [95:64]

\ AES1-IVR3 (read-write)
: AES1-IVR3_AES_IVR3   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-IVR3 bis! ;  \ AES1-IVR3_AES_IVR3    Initialization Vector Register MSB IVR [127:96]

\ AES1-KEYR4 (read-write)
: AES1-KEYR4_AES_KEYR4   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR4 bis! ;  \ AES1-KEYR4_AES_KEYR4    AES key register MSB key [159:128]

\ AES1-KEYR5 (read-write)
: AES1-KEYR5_AES_KEYR5   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR5 bis! ;  \ AES1-KEYR5_AES_KEYR5    AES key register MSB key [191:160]

\ AES1-KEYR6 (read-write)
: AES1-KEYR6_AES_KEYR6   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR6 bis! ;  \ AES1-KEYR6_AES_KEYR6    AES key register MSB key [223:192]

\ AES1-KEYR7 (read-write)
: AES1-KEYR7_AES_KEYR7   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-KEYR7 bis! ;  \ AES1-KEYR7_AES_KEYR7    AES key register MSB key [255:224]

\ AES1-SUSP0R (read-write)
: AES1-SUSP0R_AES_SUSP0R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP0R bis! ;  \ AES1-SUSP0R_AES_SUSP0R    AES suspend register 0

\ AES1-SUSP1R (read-write)
: AES1-SUSP1R_AES_SUSP1R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP1R bis! ;  \ AES1-SUSP1R_AES_SUSP1R    AES suspend register 1

\ AES1-SUSP2R (read-write)
: AES1-SUSP2R_AES_SUSP2R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP2R bis! ;  \ AES1-SUSP2R_AES_SUSP2R    AES suspend register 2

\ AES1-SUSP3R (read-write)
: AES1-SUSP3R_AES_SUSP3R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP3R bis! ;  \ AES1-SUSP3R_AES_SUSP3R    AES suspend register 3

\ AES1-SUSP4R (read-write)
: AES1-SUSP4R_AES_SUSP4R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP4R bis! ;  \ AES1-SUSP4R_AES_SUSP4R    AES suspend register 4

\ AES1-SUSP5R (read-write)
: AES1-SUSP5R_AES_SUSP5R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP5R bis! ;  \ AES1-SUSP5R_AES_SUSP5R    AES suspend register 5

\ AES1-SUSP6R (read-write)
: AES1-SUSP6R_AES_SUSP6R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP6R bis! ;  \ AES1-SUSP6R_AES_SUSP6R    AES suspend register 6

\ AES1-SUSP7R (read-write)
: AES1-SUSP7R_AES_SUSP7R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SUSP7R bis! ;  \ AES1-SUSP7R_AES_SUSP7R    AES suspend register 7

\ AES1-HWCFR (read-only)
: AES1-HWCFR_CFG4   ( %XXXX -- ) 12 lshift AES1-HWCFR bis! ;  \ AES1-HWCFR_CFG4    HW Generic 4
: AES1-HWCFR_CFG3   ( %XXXX -- ) 8 lshift AES1-HWCFR bis! ;  \ AES1-HWCFR_CFG3    HW Generic 3
: AES1-HWCFR_CFG2   ( %XXXX -- ) 4 lshift AES1-HWCFR bis! ;  \ AES1-HWCFR_CFG2    HW Generic 2
: AES1-HWCFR_CFG1   ( %XXXX -- ) 0 lshift AES1-HWCFR bis! ;  \ AES1-HWCFR_CFG1    HW Generic 1

\ AES1-VERR (read-only)
: AES1-VERR_MAJREV   ( %XXXX -- ) 4 lshift AES1-VERR bis! ;  \ AES1-VERR_MAJREV    Major revision
: AES1-VERR_MINREV   ( %XXXX -- ) 0 lshift AES1-VERR bis! ;  \ AES1-VERR_MINREV    Minor revision

\ AES1-IPIDR (read-only)
: AES1-IPIDR_ID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-IPIDR bis! ;  \ AES1-IPIDR_ID    Identification code

\ AES1-SIDR (read-only)
: AES1-SIDR_ID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES1-SIDR bis! ;  \ AES1-SIDR_ID    Size Identification code

\ AES2-CR (read-write)
: AES2-CR_NPBLB   ( %XXXX -- ) 20 lshift AES2-CR bis! ;  \ AES2-CR_NPBLB    Number of padding bytes in last block of payload
: AES2-CR_KEYSIZE   %1 18 lshift AES2-CR bis! ;  \ AES2-CR_KEYSIZE    Key size selection
: AES2-CR_CHMOD2   %1 16 lshift AES2-CR bis! ;  \ AES2-CR_CHMOD2    AES chaining mode Bit2
: AES2-CR_GCMPH   ( %XX -- ) 13 lshift AES2-CR bis! ;  \ AES2-CR_GCMPH    Used only for GCM, CCM and GMAC algorithms and has no effect when other algorithms are selected
: AES2-CR_DMAOUTEN   %1 12 lshift AES2-CR bis! ;  \ AES2-CR_DMAOUTEN    Enable DMA management of data output phase
: AES2-CR_DMAINEN   %1 11 lshift AES2-CR bis! ;  \ AES2-CR_DMAINEN    Enable DMA management of data input phase
: AES2-CR_ERRIE   %1 10 lshift AES2-CR bis! ;  \ AES2-CR_ERRIE    Error interrupt enable
: AES2-CR_CCFIE   %1 9 lshift AES2-CR bis! ;  \ AES2-CR_CCFIE    CCF flag interrupt enable
: AES2-CR_ERRC   %1 8 lshift AES2-CR bis! ;  \ AES2-CR_ERRC    Error clear
: AES2-CR_CCFC   %1 7 lshift AES2-CR bis! ;  \ AES2-CR_CCFC    Computation Complete Flag Clear
: AES2-CR_CHMOD10   ( %XX -- ) 5 lshift AES2-CR bis! ;  \ AES2-CR_CHMOD10    AES chaining mode Bit1 Bit0
: AES2-CR_MODE   ( %XX -- ) 3 lshift AES2-CR bis! ;  \ AES2-CR_MODE    AES operating mode
: AES2-CR_DATATYPE   ( %XX -- ) 1 lshift AES2-CR bis! ;  \ AES2-CR_DATATYPE    Data type selection for data in and data out to/from the cryptographic block
: AES2-CR_EN   %1 0 lshift AES2-CR bis! ;  \ AES2-CR_EN    AES enable

\ AES2-SR (read-only)
: AES2-SR_BUSY   %1 3 lshift AES2-SR bis! ;  \ AES2-SR_BUSY    Busy flag
: AES2-SR_WRERR   %1 2 lshift AES2-SR bis! ;  \ AES2-SR_WRERR    Write error flag
: AES2-SR_RDERR   %1 1 lshift AES2-SR bis! ;  \ AES2-SR_RDERR    Read error flag
: AES2-SR_CCF   %1 0 lshift AES2-SR bis! ;  \ AES2-SR_CCF    Computation complete flag

\ AES2-DINR (read-write)
: AES2-DINR_AES_DINR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-DINR bis! ;  \ AES2-DINR_AES_DINR    Data Input Register

\ AES2-DOUTR (read-only)
: AES2-DOUTR_AES_DOUTR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-DOUTR bis! ;  \ AES2-DOUTR_AES_DOUTR    Data output register

\ AES2-KEYR0 (read-write)
: AES2-KEYR0_AES_KEYR0   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR0 bis! ;  \ AES2-KEYR0_AES_KEYR0    Data Output Register LSB key [31:0]

\ AES2-KEYR1 (read-write)
: AES2-KEYR1_AES_KEYR1   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR1 bis! ;  \ AES2-KEYR1_AES_KEYR1    AES key register key [63:32]

\ AES2-KEYR2 (read-write)
: AES2-KEYR2_AES_KEYR2   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR2 bis! ;  \ AES2-KEYR2_AES_KEYR2    AES key register key [95:64]

\ AES2-KEYR3 (read-write)
: AES2-KEYR3_AES_KEYR3   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR3 bis! ;  \ AES2-KEYR3_AES_KEYR3    AES key register MSB key [127:96]

\ AES2-IVR0 (read-write)
: AES2-IVR0_AES_IVR0   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-IVR0 bis! ;  \ AES2-IVR0_AES_IVR0    initialization vector register LSB IVR [31:0]

\ AES2-IVR1 (read-write)
: AES2-IVR1_AES_IVR1   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-IVR1 bis! ;  \ AES2-IVR1_AES_IVR1    Initialization Vector Register IVR [63:32]

\ AES2-IVR2 (read-write)
: AES2-IVR2_AES_IVR2   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-IVR2 bis! ;  \ AES2-IVR2_AES_IVR2    Initialization Vector Register IVR [95:64]

\ AES2-IVR3 (read-write)
: AES2-IVR3_AES_IVR3   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-IVR3 bis! ;  \ AES2-IVR3_AES_IVR3    Initialization Vector Register MSB IVR [127:96]

\ AES2-KEYR4 (read-write)
: AES2-KEYR4_AES_KEYR4   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR4 bis! ;  \ AES2-KEYR4_AES_KEYR4    AES key register MSB key [159:128]

\ AES2-KEYR5 (read-write)
: AES2-KEYR5_AES_KEYR5   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR5 bis! ;  \ AES2-KEYR5_AES_KEYR5    AES key register MSB key [191:160]

\ AES2-KEYR6 (read-write)
: AES2-KEYR6_AES_KEYR6   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR6 bis! ;  \ AES2-KEYR6_AES_KEYR6    AES key register MSB key [223:192]

\ AES2-KEYR7 (read-write)
: AES2-KEYR7_AES_KEYR7   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-KEYR7 bis! ;  \ AES2-KEYR7_AES_KEYR7    AES key register MSB key [255:224]

\ AES2-SUSP0R (read-write)
: AES2-SUSP0R_AES_SUSP0R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP0R bis! ;  \ AES2-SUSP0R_AES_SUSP0R    AES suspend register 0

\ AES2-SUSP1R (read-write)
: AES2-SUSP1R_AES_SUSP1R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP1R bis! ;  \ AES2-SUSP1R_AES_SUSP1R    AES suspend register 1

\ AES2-SUSP2R (read-write)
: AES2-SUSP2R_AES_SUSP2R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP2R bis! ;  \ AES2-SUSP2R_AES_SUSP2R    AES suspend register 2

\ AES2-SUSP3R (read-write)
: AES2-SUSP3R_AES_SUSP3R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP3R bis! ;  \ AES2-SUSP3R_AES_SUSP3R    AES suspend register 3

\ AES2-SUSP4R (read-write)
: AES2-SUSP4R_AES_SUSP4R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP4R bis! ;  \ AES2-SUSP4R_AES_SUSP4R    AES suspend register 4

\ AES2-SUSP5R (read-write)
: AES2-SUSP5R_AES_SUSP5R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP5R bis! ;  \ AES2-SUSP5R_AES_SUSP5R    AES suspend register 5

\ AES2-SUSP6R (read-write)
: AES2-SUSP6R_AES_SUSP6R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP6R bis! ;  \ AES2-SUSP6R_AES_SUSP6R    AES suspend register 6

\ AES2-SUSP7R (read-write)
: AES2-SUSP7R_AES_SUSP7R   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SUSP7R bis! ;  \ AES2-SUSP7R_AES_SUSP7R    AES suspend register 7

\ AES2-HWCFR (read-only)
: AES2-HWCFR_CFG4   ( %XXXX -- ) 12 lshift AES2-HWCFR bis! ;  \ AES2-HWCFR_CFG4    HW Generic 4
: AES2-HWCFR_CFG3   ( %XXXX -- ) 8 lshift AES2-HWCFR bis! ;  \ AES2-HWCFR_CFG3    HW Generic 3
: AES2-HWCFR_CFG2   ( %XXXX -- ) 4 lshift AES2-HWCFR bis! ;  \ AES2-HWCFR_CFG2    HW Generic 2
: AES2-HWCFR_CFG1   ( %XXXX -- ) 0 lshift AES2-HWCFR bis! ;  \ AES2-HWCFR_CFG1    HW Generic 1

\ AES2-VERR (read-only)
: AES2-VERR_MAJREV   ( %XXXX -- ) 4 lshift AES2-VERR bis! ;  \ AES2-VERR_MAJREV    Major revision
: AES2-VERR_MINREV   ( %XXXX -- ) 0 lshift AES2-VERR bis! ;  \ AES2-VERR_MINREV    Minor revision

\ AES2-IPIDR (read-only)
: AES2-IPIDR_ID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-IPIDR bis! ;  \ AES2-IPIDR_ID    Identification code

\ AES2-SIDR (read-only)
: AES2-SIDR_ID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift AES2-SIDR bis! ;  \ AES2-SIDR_ID    Size Identification code

\ HSEM-R0 (read-write)
: HSEM-R0_LOCK   %1 31 lshift HSEM-R0 bis! ;  \ HSEM-R0_LOCK    lock indication
: HSEM-R0_COREID   ( %XXXX -- ) 8 lshift HSEM-R0 bis! ;  \ HSEM-R0_COREID    Semaphore CoreID
: HSEM-R0_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R0 bis! ;  \ HSEM-R0_PROCID    Semaphore ProcessID

\ HSEM-R1 (read-write)
: HSEM-R1_LOCK   %1 31 lshift HSEM-R1 bis! ;  \ HSEM-R1_LOCK    lock indication
: HSEM-R1_COREID   ( %XXXX -- ) 8 lshift HSEM-R1 bis! ;  \ HSEM-R1_COREID    Semaphore CoreID
: HSEM-R1_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R1 bis! ;  \ HSEM-R1_PROCID    Semaphore ProcessID

\ HSEM-R2 (read-write)
: HSEM-R2_LOCK   %1 31 lshift HSEM-R2 bis! ;  \ HSEM-R2_LOCK    lock indication
: HSEM-R2_COREID   ( %XXXX -- ) 8 lshift HSEM-R2 bis! ;  \ HSEM-R2_COREID    Semaphore CoreID
: HSEM-R2_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R2 bis! ;  \ HSEM-R2_PROCID    Semaphore ProcessID

\ HSEM-R3 (read-write)
: HSEM-R3_LOCK   %1 31 lshift HSEM-R3 bis! ;  \ HSEM-R3_LOCK    lock indication
: HSEM-R3_COREID   ( %XXXX -- ) 8 lshift HSEM-R3 bis! ;  \ HSEM-R3_COREID    Semaphore CoreID
: HSEM-R3_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R3 bis! ;  \ HSEM-R3_PROCID    Semaphore ProcessID

\ HSEM-R4 (read-write)
: HSEM-R4_LOCK   %1 31 lshift HSEM-R4 bis! ;  \ HSEM-R4_LOCK    lock indication
: HSEM-R4_COREID   ( %XXXX -- ) 8 lshift HSEM-R4 bis! ;  \ HSEM-R4_COREID    Semaphore CoreID
: HSEM-R4_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R4 bis! ;  \ HSEM-R4_PROCID    Semaphore ProcessID

\ HSEM-R5 (read-write)
: HSEM-R5_LOCK   %1 31 lshift HSEM-R5 bis! ;  \ HSEM-R5_LOCK    lock indication
: HSEM-R5_COREID   ( %XXXX -- ) 8 lshift HSEM-R5 bis! ;  \ HSEM-R5_COREID    Semaphore CoreID
: HSEM-R5_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R5 bis! ;  \ HSEM-R5_PROCID    Semaphore ProcessID

\ HSEM-R6 (read-write)
: HSEM-R6_LOCK   %1 31 lshift HSEM-R6 bis! ;  \ HSEM-R6_LOCK    lock indication
: HSEM-R6_COREID   ( %XXXX -- ) 8 lshift HSEM-R6 bis! ;  \ HSEM-R6_COREID    Semaphore CoreID
: HSEM-R6_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R6 bis! ;  \ HSEM-R6_PROCID    Semaphore ProcessID

\ HSEM-R7 (read-write)
: HSEM-R7_LOCK   %1 31 lshift HSEM-R7 bis! ;  \ HSEM-R7_LOCK    lock indication
: HSEM-R7_COREID   ( %XXXX -- ) 8 lshift HSEM-R7 bis! ;  \ HSEM-R7_COREID    Semaphore CoreID
: HSEM-R7_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R7 bis! ;  \ HSEM-R7_PROCID    Semaphore ProcessID

\ HSEM-R8 (read-write)
: HSEM-R8_LOCK   %1 31 lshift HSEM-R8 bis! ;  \ HSEM-R8_LOCK    lock indication
: HSEM-R8_COREID   ( %XXXX -- ) 8 lshift HSEM-R8 bis! ;  \ HSEM-R8_COREID    Semaphore CoreID
: HSEM-R8_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R8 bis! ;  \ HSEM-R8_PROCID    Semaphore ProcessID

\ HSEM-R9 (read-write)
: HSEM-R9_LOCK   %1 31 lshift HSEM-R9 bis! ;  \ HSEM-R9_LOCK    lock indication
: HSEM-R9_COREID   ( %XXXX -- ) 8 lshift HSEM-R9 bis! ;  \ HSEM-R9_COREID    Semaphore CoreID
: HSEM-R9_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R9 bis! ;  \ HSEM-R9_PROCID    Semaphore ProcessID

\ HSEM-R10 (read-write)
: HSEM-R10_LOCK   %1 31 lshift HSEM-R10 bis! ;  \ HSEM-R10_LOCK    lock indication
: HSEM-R10_COREID   ( %XXXX -- ) 8 lshift HSEM-R10 bis! ;  \ HSEM-R10_COREID    Semaphore CoreID
: HSEM-R10_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R10 bis! ;  \ HSEM-R10_PROCID    Semaphore ProcessID

\ HSEM-R11 (read-write)
: HSEM-R11_LOCK   %1 31 lshift HSEM-R11 bis! ;  \ HSEM-R11_LOCK    lock indication
: HSEM-R11_COREID   ( %XXXX -- ) 8 lshift HSEM-R11 bis! ;  \ HSEM-R11_COREID    Semaphore CoreID
: HSEM-R11_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R11 bis! ;  \ HSEM-R11_PROCID    Semaphore ProcessID

\ HSEM-R12 (read-write)
: HSEM-R12_LOCK   %1 31 lshift HSEM-R12 bis! ;  \ HSEM-R12_LOCK    lock indication
: HSEM-R12_COREID   ( %XXXX -- ) 8 lshift HSEM-R12 bis! ;  \ HSEM-R12_COREID    Semaphore CoreID
: HSEM-R12_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R12 bis! ;  \ HSEM-R12_PROCID    Semaphore ProcessID

\ HSEM-R13 (read-write)
: HSEM-R13_LOCK   %1 31 lshift HSEM-R13 bis! ;  \ HSEM-R13_LOCK    lock indication
: HSEM-R13_COREID   ( %XXXX -- ) 8 lshift HSEM-R13 bis! ;  \ HSEM-R13_COREID    Semaphore CoreID
: HSEM-R13_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R13 bis! ;  \ HSEM-R13_PROCID    Semaphore ProcessID

\ HSEM-R14 (read-write)
: HSEM-R14_LOCK   %1 31 lshift HSEM-R14 bis! ;  \ HSEM-R14_LOCK    lock indication
: HSEM-R14_COREID   ( %XXXX -- ) 8 lshift HSEM-R14 bis! ;  \ HSEM-R14_COREID    Semaphore CoreID
: HSEM-R14_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R14 bis! ;  \ HSEM-R14_PROCID    Semaphore ProcessID

\ HSEM-R15 (read-write)
: HSEM-R15_LOCK   %1 31 lshift HSEM-R15 bis! ;  \ HSEM-R15_LOCK    lock indication
: HSEM-R15_COREID   ( %XXXX -- ) 8 lshift HSEM-R15 bis! ;  \ HSEM-R15_COREID    Semaphore CoreID
: HSEM-R15_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R15 bis! ;  \ HSEM-R15_PROCID    Semaphore ProcessID

\ HSEM-R16 (read-write)
: HSEM-R16_LOCK   %1 31 lshift HSEM-R16 bis! ;  \ HSEM-R16_LOCK    lock indication
: HSEM-R16_COREID   ( %XXXX -- ) 8 lshift HSEM-R16 bis! ;  \ HSEM-R16_COREID    Semaphore CoreID
: HSEM-R16_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R16 bis! ;  \ HSEM-R16_PROCID    Semaphore ProcessID

\ HSEM-R17 (read-write)
: HSEM-R17_LOCK   %1 31 lshift HSEM-R17 bis! ;  \ HSEM-R17_LOCK    lock indication
: HSEM-R17_COREID   ( %XXXX -- ) 8 lshift HSEM-R17 bis! ;  \ HSEM-R17_COREID    Semaphore CoreID
: HSEM-R17_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R17 bis! ;  \ HSEM-R17_PROCID    Semaphore ProcessID

\ HSEM-R18 (read-write)
: HSEM-R18_LOCK   %1 31 lshift HSEM-R18 bis! ;  \ HSEM-R18_LOCK    lock indication
: HSEM-R18_COREID   ( %XXXX -- ) 8 lshift HSEM-R18 bis! ;  \ HSEM-R18_COREID    Semaphore CoreID
: HSEM-R18_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R18 bis! ;  \ HSEM-R18_PROCID    Semaphore ProcessID

\ HSEM-R19 (read-write)
: HSEM-R19_LOCK   %1 31 lshift HSEM-R19 bis! ;  \ HSEM-R19_LOCK    lock indication
: HSEM-R19_COREID   ( %XXXX -- ) 8 lshift HSEM-R19 bis! ;  \ HSEM-R19_COREID    Semaphore CoreID
: HSEM-R19_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R19 bis! ;  \ HSEM-R19_PROCID    Semaphore ProcessID

\ HSEM-R20 (read-write)
: HSEM-R20_LOCK   %1 31 lshift HSEM-R20 bis! ;  \ HSEM-R20_LOCK    lock indication
: HSEM-R20_COREID   ( %XXXX -- ) 8 lshift HSEM-R20 bis! ;  \ HSEM-R20_COREID    Semaphore CoreID
: HSEM-R20_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R20 bis! ;  \ HSEM-R20_PROCID    Semaphore ProcessID

\ HSEM-R21 (read-write)
: HSEM-R21_LOCK   %1 31 lshift HSEM-R21 bis! ;  \ HSEM-R21_LOCK    lock indication
: HSEM-R21_COREID   ( %XXXX -- ) 8 lshift HSEM-R21 bis! ;  \ HSEM-R21_COREID    Semaphore CoreID
: HSEM-R21_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R21 bis! ;  \ HSEM-R21_PROCID    Semaphore ProcessID

\ HSEM-R22 (read-write)
: HSEM-R22_LOCK   %1 31 lshift HSEM-R22 bis! ;  \ HSEM-R22_LOCK    lock indication
: HSEM-R22_COREID   ( %XXXX -- ) 8 lshift HSEM-R22 bis! ;  \ HSEM-R22_COREID    Semaphore CoreID
: HSEM-R22_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R22 bis! ;  \ HSEM-R22_PROCID    Semaphore ProcessID

\ HSEM-R23 (read-write)
: HSEM-R23_LOCK   %1 31 lshift HSEM-R23 bis! ;  \ HSEM-R23_LOCK    lock indication
: HSEM-R23_COREID   ( %XXXX -- ) 8 lshift HSEM-R23 bis! ;  \ HSEM-R23_COREID    Semaphore CoreID
: HSEM-R23_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R23 bis! ;  \ HSEM-R23_PROCID    Semaphore ProcessID

\ HSEM-R24 (read-write)
: HSEM-R24_LOCK   %1 31 lshift HSEM-R24 bis! ;  \ HSEM-R24_LOCK    lock indication
: HSEM-R24_COREID   ( %XXXX -- ) 8 lshift HSEM-R24 bis! ;  \ HSEM-R24_COREID    Semaphore CoreID
: HSEM-R24_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R24 bis! ;  \ HSEM-R24_PROCID    Semaphore ProcessID

\ HSEM-R25 (read-write)
: HSEM-R25_LOCK   %1 31 lshift HSEM-R25 bis! ;  \ HSEM-R25_LOCK    lock indication
: HSEM-R25_COREID   ( %XXXX -- ) 8 lshift HSEM-R25 bis! ;  \ HSEM-R25_COREID    Semaphore CoreID
: HSEM-R25_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R25 bis! ;  \ HSEM-R25_PROCID    Semaphore ProcessID

\ HSEM-R26 (read-write)
: HSEM-R26_LOCK   %1 31 lshift HSEM-R26 bis! ;  \ HSEM-R26_LOCK    lock indication
: HSEM-R26_COREID   ( %XXXX -- ) 8 lshift HSEM-R26 bis! ;  \ HSEM-R26_COREID    Semaphore CoreID
: HSEM-R26_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R26 bis! ;  \ HSEM-R26_PROCID    Semaphore ProcessID

\ HSEM-R27 (read-write)
: HSEM-R27_LOCK   %1 31 lshift HSEM-R27 bis! ;  \ HSEM-R27_LOCK    lock indication
: HSEM-R27_COREID   ( %XXXX -- ) 8 lshift HSEM-R27 bis! ;  \ HSEM-R27_COREID    Semaphore CoreID
: HSEM-R27_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R27 bis! ;  \ HSEM-R27_PROCID    Semaphore ProcessID

\ HSEM-R28 (read-write)
: HSEM-R28_LOCK   %1 31 lshift HSEM-R28 bis! ;  \ HSEM-R28_LOCK    lock indication
: HSEM-R28_COREID   ( %XXXX -- ) 8 lshift HSEM-R28 bis! ;  \ HSEM-R28_COREID    Semaphore CoreID
: HSEM-R28_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R28 bis! ;  \ HSEM-R28_PROCID    Semaphore ProcessID

\ HSEM-R29 (read-write)
: HSEM-R29_LOCK   %1 31 lshift HSEM-R29 bis! ;  \ HSEM-R29_LOCK    lock indication
: HSEM-R29_COREID   ( %XXXX -- ) 8 lshift HSEM-R29 bis! ;  \ HSEM-R29_COREID    Semaphore CoreID
: HSEM-R29_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R29 bis! ;  \ HSEM-R29_PROCID    Semaphore ProcessID

\ HSEM-R30 (read-write)
: HSEM-R30_LOCK   %1 31 lshift HSEM-R30 bis! ;  \ HSEM-R30_LOCK    lock indication
: HSEM-R30_COREID   ( %XXXX -- ) 8 lshift HSEM-R30 bis! ;  \ HSEM-R30_COREID    Semaphore CoreID
: HSEM-R30_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R30 bis! ;  \ HSEM-R30_PROCID    Semaphore ProcessID

\ HSEM-R31 (read-write)
: HSEM-R31_LOCK   %1 31 lshift HSEM-R31 bis! ;  \ HSEM-R31_LOCK    lock indication
: HSEM-R31_COREID   ( %XXXX -- ) 8 lshift HSEM-R31 bis! ;  \ HSEM-R31_COREID    Semaphore CoreID
: HSEM-R31_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-R31 bis! ;  \ HSEM-R31_PROCID    Semaphore ProcessID

\ HSEM-RLR0 (read-only)
: HSEM-RLR0_LOCK   %1 31 lshift HSEM-RLR0 bis! ;  \ HSEM-RLR0_LOCK    lock indication
: HSEM-RLR0_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR0 bis! ;  \ HSEM-RLR0_COREID    Semaphore CoreID
: HSEM-RLR0_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR0 bis! ;  \ HSEM-RLR0_PROCID    Semaphore ProcessID

\ HSEM-RLR1 (read-only)
: HSEM-RLR1_LOCK   %1 31 lshift HSEM-RLR1 bis! ;  \ HSEM-RLR1_LOCK    lock indication
: HSEM-RLR1_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR1 bis! ;  \ HSEM-RLR1_COREID    Semaphore CoreID
: HSEM-RLR1_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR1 bis! ;  \ HSEM-RLR1_PROCID    Semaphore ProcessID

\ HSEM-RLR2 (read-only)
: HSEM-RLR2_LOCK   %1 31 lshift HSEM-RLR2 bis! ;  \ HSEM-RLR2_LOCK    lock indication
: HSEM-RLR2_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR2 bis! ;  \ HSEM-RLR2_COREID    Semaphore CoreID
: HSEM-RLR2_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR2 bis! ;  \ HSEM-RLR2_PROCID    Semaphore ProcessID

\ HSEM-RLR3 (read-only)
: HSEM-RLR3_LOCK   %1 31 lshift HSEM-RLR3 bis! ;  \ HSEM-RLR3_LOCK    lock indication
: HSEM-RLR3_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR3 bis! ;  \ HSEM-RLR3_COREID    Semaphore CoreID
: HSEM-RLR3_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR3 bis! ;  \ HSEM-RLR3_PROCID    Semaphore ProcessID

\ HSEM-RLR4 (read-only)
: HSEM-RLR4_LOCK   %1 31 lshift HSEM-RLR4 bis! ;  \ HSEM-RLR4_LOCK    lock indication
: HSEM-RLR4_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR4 bis! ;  \ HSEM-RLR4_COREID    Semaphore CoreID
: HSEM-RLR4_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR4 bis! ;  \ HSEM-RLR4_PROCID    Semaphore ProcessID

\ HSEM-RLR5 (read-only)
: HSEM-RLR5_LOCK   %1 31 lshift HSEM-RLR5 bis! ;  \ HSEM-RLR5_LOCK    lock indication
: HSEM-RLR5_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR5 bis! ;  \ HSEM-RLR5_COREID    Semaphore CoreID
: HSEM-RLR5_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR5 bis! ;  \ HSEM-RLR5_PROCID    Semaphore ProcessID

\ HSEM-RLR6 (read-only)
: HSEM-RLR6_LOCK   %1 31 lshift HSEM-RLR6 bis! ;  \ HSEM-RLR6_LOCK    lock indication
: HSEM-RLR6_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR6 bis! ;  \ HSEM-RLR6_COREID    Semaphore CoreID
: HSEM-RLR6_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR6 bis! ;  \ HSEM-RLR6_PROCID    Semaphore ProcessID

\ HSEM-RLR7 (read-only)
: HSEM-RLR7_LOCK   %1 31 lshift HSEM-RLR7 bis! ;  \ HSEM-RLR7_LOCK    lock indication
: HSEM-RLR7_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR7 bis! ;  \ HSEM-RLR7_COREID    Semaphore CoreID
: HSEM-RLR7_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR7 bis! ;  \ HSEM-RLR7_PROCID    Semaphore ProcessID

\ HSEM-RLR8 (read-only)
: HSEM-RLR8_LOCK   %1 31 lshift HSEM-RLR8 bis! ;  \ HSEM-RLR8_LOCK    lock indication
: HSEM-RLR8_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR8 bis! ;  \ HSEM-RLR8_COREID    Semaphore CoreID
: HSEM-RLR8_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR8 bis! ;  \ HSEM-RLR8_PROCID    Semaphore ProcessID

\ HSEM-RLR9 (read-only)
: HSEM-RLR9_LOCK   %1 31 lshift HSEM-RLR9 bis! ;  \ HSEM-RLR9_LOCK    lock indication
: HSEM-RLR9_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR9 bis! ;  \ HSEM-RLR9_COREID    Semaphore CoreID
: HSEM-RLR9_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR9 bis! ;  \ HSEM-RLR9_PROCID    Semaphore ProcessID

\ HSEM-RLR10 (read-only)
: HSEM-RLR10_LOCK   %1 31 lshift HSEM-RLR10 bis! ;  \ HSEM-RLR10_LOCK    lock indication
: HSEM-RLR10_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR10 bis! ;  \ HSEM-RLR10_COREID    Semaphore CoreID
: HSEM-RLR10_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR10 bis! ;  \ HSEM-RLR10_PROCID    Semaphore ProcessID

\ HSEM-RLR11 (read-only)
: HSEM-RLR11_LOCK   %1 31 lshift HSEM-RLR11 bis! ;  \ HSEM-RLR11_LOCK    lock indication
: HSEM-RLR11_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR11 bis! ;  \ HSEM-RLR11_COREID    Semaphore CoreID
: HSEM-RLR11_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR11 bis! ;  \ HSEM-RLR11_PROCID    Semaphore ProcessID

\ HSEM-RLR12 (read-only)
: HSEM-RLR12_LOCK   %1 31 lshift HSEM-RLR12 bis! ;  \ HSEM-RLR12_LOCK    lock indication
: HSEM-RLR12_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR12 bis! ;  \ HSEM-RLR12_COREID    Semaphore CoreID
: HSEM-RLR12_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR12 bis! ;  \ HSEM-RLR12_PROCID    Semaphore ProcessID

\ HSEM-RLR13 (read-only)
: HSEM-RLR13_LOCK   %1 31 lshift HSEM-RLR13 bis! ;  \ HSEM-RLR13_LOCK    lock indication
: HSEM-RLR13_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR13 bis! ;  \ HSEM-RLR13_COREID    Semaphore CoreID
: HSEM-RLR13_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR13 bis! ;  \ HSEM-RLR13_PROCID    Semaphore ProcessID

\ HSEM-RLR14 (read-only)
: HSEM-RLR14_LOCK   %1 31 lshift HSEM-RLR14 bis! ;  \ HSEM-RLR14_LOCK    lock indication
: HSEM-RLR14_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR14 bis! ;  \ HSEM-RLR14_COREID    Semaphore CoreID
: HSEM-RLR14_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR14 bis! ;  \ HSEM-RLR14_PROCID    Semaphore ProcessID

\ HSEM-RLR15 (read-only)
: HSEM-RLR15_LOCK   %1 31 lshift HSEM-RLR15 bis! ;  \ HSEM-RLR15_LOCK    lock indication
: HSEM-RLR15_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR15 bis! ;  \ HSEM-RLR15_COREID    Semaphore CoreID
: HSEM-RLR15_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR15 bis! ;  \ HSEM-RLR15_PROCID    Semaphore ProcessID

\ HSEM-RLR16 (read-only)
: HSEM-RLR16_LOCK   %1 31 lshift HSEM-RLR16 bis! ;  \ HSEM-RLR16_LOCK    lock indication
: HSEM-RLR16_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR16 bis! ;  \ HSEM-RLR16_COREID    Semaphore CoreID
: HSEM-RLR16_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR16 bis! ;  \ HSEM-RLR16_PROCID    Semaphore ProcessID

\ HSEM-RLR17 (read-only)
: HSEM-RLR17_LOCK   %1 31 lshift HSEM-RLR17 bis! ;  \ HSEM-RLR17_LOCK    lock indication
: HSEM-RLR17_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR17 bis! ;  \ HSEM-RLR17_COREID    Semaphore CoreID
: HSEM-RLR17_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR17 bis! ;  \ HSEM-RLR17_PROCID    Semaphore ProcessID

\ HSEM-RLR18 (read-only)
: HSEM-RLR18_LOCK   %1 31 lshift HSEM-RLR18 bis! ;  \ HSEM-RLR18_LOCK    lock indication
: HSEM-RLR18_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR18 bis! ;  \ HSEM-RLR18_COREID    Semaphore CoreID
: HSEM-RLR18_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR18 bis! ;  \ HSEM-RLR18_PROCID    Semaphore ProcessID

\ HSEM-RLR19 (read-only)
: HSEM-RLR19_LOCK   %1 31 lshift HSEM-RLR19 bis! ;  \ HSEM-RLR19_LOCK    lock indication
: HSEM-RLR19_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR19 bis! ;  \ HSEM-RLR19_COREID    Semaphore CoreID
: HSEM-RLR19_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR19 bis! ;  \ HSEM-RLR19_PROCID    Semaphore ProcessID

\ HSEM-RLR20 (read-only)
: HSEM-RLR20_LOCK   %1 31 lshift HSEM-RLR20 bis! ;  \ HSEM-RLR20_LOCK    lock indication
: HSEM-RLR20_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR20 bis! ;  \ HSEM-RLR20_COREID    Semaphore CoreID
: HSEM-RLR20_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR20 bis! ;  \ HSEM-RLR20_PROCID    Semaphore ProcessID

\ HSEM-RLR21 (read-only)
: HSEM-RLR21_LOCK   %1 31 lshift HSEM-RLR21 bis! ;  \ HSEM-RLR21_LOCK    lock indication
: HSEM-RLR21_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR21 bis! ;  \ HSEM-RLR21_COREID    Semaphore CoreID
: HSEM-RLR21_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR21 bis! ;  \ HSEM-RLR21_PROCID    Semaphore ProcessID

\ HSEM-RLR22 (read-only)
: HSEM-RLR22_LOCK   %1 31 lshift HSEM-RLR22 bis! ;  \ HSEM-RLR22_LOCK    lock indication
: HSEM-RLR22_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR22 bis! ;  \ HSEM-RLR22_COREID    Semaphore CoreID
: HSEM-RLR22_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR22 bis! ;  \ HSEM-RLR22_PROCID    Semaphore ProcessID

\ HSEM-RLR23 (read-only)
: HSEM-RLR23_LOCK   %1 31 lshift HSEM-RLR23 bis! ;  \ HSEM-RLR23_LOCK    lock indication
: HSEM-RLR23_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR23 bis! ;  \ HSEM-RLR23_COREID    Semaphore CoreID
: HSEM-RLR23_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR23 bis! ;  \ HSEM-RLR23_PROCID    Semaphore ProcessID

\ HSEM-RLR24 (read-only)
: HSEM-RLR24_LOCK   %1 31 lshift HSEM-RLR24 bis! ;  \ HSEM-RLR24_LOCK    lock indication
: HSEM-RLR24_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR24 bis! ;  \ HSEM-RLR24_COREID    Semaphore CoreID
: HSEM-RLR24_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR24 bis! ;  \ HSEM-RLR24_PROCID    Semaphore ProcessID

\ HSEM-RLR25 (read-only)
: HSEM-RLR25_LOCK   %1 31 lshift HSEM-RLR25 bis! ;  \ HSEM-RLR25_LOCK    lock indication
: HSEM-RLR25_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR25 bis! ;  \ HSEM-RLR25_COREID    Semaphore CoreID
: HSEM-RLR25_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR25 bis! ;  \ HSEM-RLR25_PROCID    Semaphore ProcessID

\ HSEM-RLR26 (read-only)
: HSEM-RLR26_LOCK   %1 31 lshift HSEM-RLR26 bis! ;  \ HSEM-RLR26_LOCK    lock indication
: HSEM-RLR26_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR26 bis! ;  \ HSEM-RLR26_COREID    Semaphore CoreID
: HSEM-RLR26_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR26 bis! ;  \ HSEM-RLR26_PROCID    Semaphore ProcessID

\ HSEM-RLR27 (read-only)
: HSEM-RLR27_LOCK   %1 31 lshift HSEM-RLR27 bis! ;  \ HSEM-RLR27_LOCK    lock indication
: HSEM-RLR27_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR27 bis! ;  \ HSEM-RLR27_COREID    Semaphore CoreID
: HSEM-RLR27_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR27 bis! ;  \ HSEM-RLR27_PROCID    Semaphore ProcessID

\ HSEM-RLR28 (read-only)
: HSEM-RLR28_LOCK   %1 31 lshift HSEM-RLR28 bis! ;  \ HSEM-RLR28_LOCK    lock indication
: HSEM-RLR28_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR28 bis! ;  \ HSEM-RLR28_COREID    Semaphore CoreID
: HSEM-RLR28_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR28 bis! ;  \ HSEM-RLR28_PROCID    Semaphore ProcessID

\ HSEM-RLR29 (read-only)
: HSEM-RLR29_LOCK   %1 31 lshift HSEM-RLR29 bis! ;  \ HSEM-RLR29_LOCK    lock indication
: HSEM-RLR29_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR29 bis! ;  \ HSEM-RLR29_COREID    Semaphore CoreID
: HSEM-RLR29_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR29 bis! ;  \ HSEM-RLR29_PROCID    Semaphore ProcessID

\ HSEM-RLR30 (read-only)
: HSEM-RLR30_LOCK   %1 31 lshift HSEM-RLR30 bis! ;  \ HSEM-RLR30_LOCK    lock indication
: HSEM-RLR30_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR30 bis! ;  \ HSEM-RLR30_COREID    Semaphore CoreID
: HSEM-RLR30_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR30 bis! ;  \ HSEM-RLR30_PROCID    Semaphore ProcessID

\ HSEM-RLR31 (read-only)
: HSEM-RLR31_LOCK   %1 31 lshift HSEM-RLR31 bis! ;  \ HSEM-RLR31_LOCK    lock indication
: HSEM-RLR31_COREID   ( %XXXX -- ) 8 lshift HSEM-RLR31 bis! ;  \ HSEM-RLR31_COREID    Semaphore CoreID
: HSEM-RLR31_PROCID   ( %XXXXXXXX -- ) 0 lshift HSEM-RLR31 bis! ;  \ HSEM-RLR31_PROCID    Semaphore ProcessID

\ HSEM-CR (read-write)
: HSEM-CR_KEY   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift HSEM-CR bis! ;  \ HSEM-CR_KEY    Semaphore clear Key
: HSEM-CR_COREID   ( %XXXX -- ) 8 lshift HSEM-CR bis! ;  \ HSEM-CR_COREID    CoreID of semaphore to be cleared

\ HSEM-KEYR (read-write)
: HSEM-KEYR_KEY   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift HSEM-KEYR bis! ;  \ HSEM-KEYR_KEY    Semaphore Clear Key

\ HSEM-HWCFGR2 (read-only)
: HSEM-HWCFGR2_MASTERID4   ( %XXXX -- ) 12 lshift HSEM-HWCFGR2 bis! ;  \ HSEM-HWCFGR2_MASTERID4    Hardware Configuration valid bus masters ID4
: HSEM-HWCFGR2_MASTERID3   ( %XXXX -- ) 8 lshift HSEM-HWCFGR2 bis! ;  \ HSEM-HWCFGR2_MASTERID3    Hardware Configuration valid bus masters ID3
: HSEM-HWCFGR2_MASTERID2   ( %XXXX -- ) 4 lshift HSEM-HWCFGR2 bis! ;  \ HSEM-HWCFGR2_MASTERID2    Hardware Configuration valid bus masters ID2
: HSEM-HWCFGR2_MASTERID1   ( %XXXX -- ) 0 lshift HSEM-HWCFGR2 bis! ;  \ HSEM-HWCFGR2_MASTERID1    Hardware Configuration valid bus masters ID1

\ HSEM-HWCFGR1 (read-only)
: HSEM-HWCFGR1_NBINT   ( %XXXX -- ) 8 lshift HSEM-HWCFGR1 bis! ;  \ HSEM-HWCFGR1_NBINT    Hardware Configuration number of interrupts supported number of master IDs
: HSEM-HWCFGR1_NBSEM   ( %XXXXXXXX -- ) 0 lshift HSEM-HWCFGR1 bis! ;  \ HSEM-HWCFGR1_NBSEM    Hardware Configuration number of semaphores

\ HSEM-VERR (read-only)
: HSEM-VERR_MAJREV   ( %XXXX -- ) 4 lshift HSEM-VERR bis! ;  \ HSEM-VERR_MAJREV    Major Revision
: HSEM-VERR_MINREV   ( %XXXX -- ) 0 lshift HSEM-VERR bis! ;  \ HSEM-VERR_MINREV    Minor Revision

\ HSEM-IPIDR (read-only)
: HSEM-IPIDR_ID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-IPIDR bis! ;  \ HSEM-IPIDR_ID    Identification Code

\ HSEM-SIDR (read-only)
: HSEM-SIDR_SID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-SIDR bis! ;  \ HSEM-SIDR_SID    Size Identification Code

\ HSEM-C1IER0 (read-write)
: HSEM-C1IER0_ISEm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C1IER0 bis! ;  \ HSEM-C1IER0_ISEm    CPUn semaphore m enable bit

\ HSEM-C1ICR (read-write)
: HSEM-C1ICR_ISCm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C1ICR bis! ;  \ HSEM-C1ICR_ISCm    CPUn semaphore m clear bit

\ HSEM-C1ISR (read-only)
: HSEM-C1ISR_ISFm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C1ISR bis! ;  \ HSEM-C1ISR_ISFm    CPUn semaphore m status bit before enable mask

\ HSEM-C1MISR (read-only)
: HSEM-C1MISR_MISFm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C1MISR bis! ;  \ HSEM-C1MISR_MISFm    masked CPUn semaphore m status bit after enable mask.

\ HSEM-C2IER0 (read-write)
: HSEM-C2IER0_ISEm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C2IER0 bis! ;  \ HSEM-C2IER0_ISEm    CPU2 semaphore m enable bit.

\ HSEM-C2ICR (read-write)
: HSEM-C2ICR_ISCm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C2ICR bis! ;  \ HSEM-C2ICR_ISCm    CPU2 semaphore m clear bit

\ HSEM-C2ISR (read-only)
: HSEM-C2ISR_ISFm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C2ISR bis! ;  \ HSEM-C2ISR_ISFm    CPU2 semaphore m status bit before enable mask.

\ HSEM-C2MISR (read-only)
: HSEM-C2MISR_MISFm   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift HSEM-C2MISR bis! ;  \ HSEM-C2MISR_MISFm    masked CPU2 semaphore m status bit after enable mask.

\ ADC-ISR (read-write)
: ADC-ISR_JQOVF   %1 10 lshift ADC-ISR bis! ;  \ ADC-ISR_JQOVF    ADC group injected contexts queue overflow flag
: ADC-ISR_AWD3   %1 9 lshift ADC-ISR bis! ;  \ ADC-ISR_AWD3    ADC analog watchdog 3 flag
: ADC-ISR_AWD2   %1 8 lshift ADC-ISR bis! ;  \ ADC-ISR_AWD2    ADC analog watchdog 2 flag
: ADC-ISR_AWD1   %1 7 lshift ADC-ISR bis! ;  \ ADC-ISR_AWD1    ADC analog watchdog 1 flag
: ADC-ISR_JEOS   %1 6 lshift ADC-ISR bis! ;  \ ADC-ISR_JEOS    ADC group injected end of sequence conversions flag
: ADC-ISR_JEOC   %1 5 lshift ADC-ISR bis! ;  \ ADC-ISR_JEOC    ADC group injected end of unitary conversion flag
: ADC-ISR_OVR   %1 4 lshift ADC-ISR bis! ;  \ ADC-ISR_OVR    ADC group regular overrun flag
: ADC-ISR_EOS   %1 3 lshift ADC-ISR bis! ;  \ ADC-ISR_EOS    ADC group regular end of sequence conversions flag
: ADC-ISR_EOC   %1 2 lshift ADC-ISR bis! ;  \ ADC-ISR_EOC    ADC group regular end of unitary conversion flag
: ADC-ISR_EOSMP   %1 1 lshift ADC-ISR bis! ;  \ ADC-ISR_EOSMP    ADC group regular end of sampling flag
: ADC-ISR_ADRDY   %1 0 lshift ADC-ISR bis! ;  \ ADC-ISR_ADRDY    ADC ready flag

\ ADC-IER (read-write)
: ADC-IER_JQOVFIE   %1 10 lshift ADC-IER bis! ;  \ ADC-IER_JQOVFIE    ADC group injected contexts queue overflow interrupt
: ADC-IER_AWD3IE   %1 9 lshift ADC-IER bis! ;  \ ADC-IER_AWD3IE    ADC analog watchdog 3 interrupt
: ADC-IER_AWD2IE   %1 8 lshift ADC-IER bis! ;  \ ADC-IER_AWD2IE    ADC analog watchdog 2 interrupt
: ADC-IER_AWD1IE   %1 7 lshift ADC-IER bis! ;  \ ADC-IER_AWD1IE    ADC analog watchdog 1 interrupt
: ADC-IER_JEOSIE   %1 6 lshift ADC-IER bis! ;  \ ADC-IER_JEOSIE    ADC group injected end of sequence conversions interrupt
: ADC-IER_JEOCIE   %1 5 lshift ADC-IER bis! ;  \ ADC-IER_JEOCIE    ADC group injected end of unitary conversion interrupt
: ADC-IER_OVRIE   %1 4 lshift ADC-IER bis! ;  \ ADC-IER_OVRIE    ADC group regular overrun interrupt
: ADC-IER_EOSIE   %1 3 lshift ADC-IER bis! ;  \ ADC-IER_EOSIE    ADC group regular end of sequence conversions interrupt
: ADC-IER_EOCIE   %1 2 lshift ADC-IER bis! ;  \ ADC-IER_EOCIE    ADC group regular end of unitary conversion interrupt
: ADC-IER_EOSMPIE   %1 1 lshift ADC-IER bis! ;  \ ADC-IER_EOSMPIE    ADC group regular end of sampling interrupt
: ADC-IER_ADRDYIE   %1 0 lshift ADC-IER bis! ;  \ ADC-IER_ADRDYIE    ADC ready interrupt

\ ADC-CR (read-write)
: ADC-CR_ADCAL   %1 31 lshift ADC-CR bis! ;  \ ADC-CR_ADCAL    ADC calibration
: ADC-CR_ADCALDIF   %1 30 lshift ADC-CR bis! ;  \ ADC-CR_ADCALDIF    ADC differential mode for calibration
: ADC-CR_DEEPPWD   %1 29 lshift ADC-CR bis! ;  \ ADC-CR_DEEPPWD    ADC deep power down enable
: ADC-CR_ADVREGEN   %1 28 lshift ADC-CR bis! ;  \ ADC-CR_ADVREGEN    ADC voltage regulator enable
: ADC-CR_JADSTP   %1 5 lshift ADC-CR bis! ;  \ ADC-CR_JADSTP    ADC group injected conversion stop
: ADC-CR_ADSTP   %1 4 lshift ADC-CR bis! ;  \ ADC-CR_ADSTP    ADC group regular conversion stop
: ADC-CR_JADSTART   %1 3 lshift ADC-CR bis! ;  \ ADC-CR_JADSTART    ADC group injected conversion start
: ADC-CR_ADSTART   %1 2 lshift ADC-CR bis! ;  \ ADC-CR_ADSTART    ADC group regular conversion start
: ADC-CR_ADDIS   %1 1 lshift ADC-CR bis! ;  \ ADC-CR_ADDIS    ADC disable
: ADC-CR_ADEN   %1 0 lshift ADC-CR bis! ;  \ ADC-CR_ADEN    ADC enable

\ ADC-CFGR (read-write)
: ADC-CFGR_JQDIS   %1 31 lshift ADC-CFGR bis! ;  \ ADC-CFGR_JQDIS    ADC group injected contexts queue disable
: ADC-CFGR_AWDCH1CH   ( %XXXXX -- ) 26 lshift ADC-CFGR bis! ;  \ ADC-CFGR_AWDCH1CH    ADC analog watchdog 1 monitored channel selection
: ADC-CFGR_JAUTO   %1 25 lshift ADC-CFGR bis! ;  \ ADC-CFGR_JAUTO    ADC group injected automatic trigger mode
: ADC-CFGR_JAWD1EN   %1 24 lshift ADC-CFGR bis! ;  \ ADC-CFGR_JAWD1EN    ADC analog watchdog 1 enable on scope ADC group injected
: ADC-CFGR_AWD1EN   %1 23 lshift ADC-CFGR bis! ;  \ ADC-CFGR_AWD1EN    ADC analog watchdog 1 enable on scope ADC group regular
: ADC-CFGR_AWD1SGL   %1 22 lshift ADC-CFGR bis! ;  \ ADC-CFGR_AWD1SGL    ADC analog watchdog 1 monitoring a single channel or all channels
: ADC-CFGR_JQM   %1 21 lshift ADC-CFGR bis! ;  \ ADC-CFGR_JQM    ADC group injected contexts queue mode
: ADC-CFGR_JDISCEN   %1 20 lshift ADC-CFGR bis! ;  \ ADC-CFGR_JDISCEN    ADC group injected sequencer discontinuous mode
: ADC-CFGR_DISCNUM   ( %XXX -- ) 17 lshift ADC-CFGR bis! ;  \ ADC-CFGR_DISCNUM    ADC group regular sequencer discontinuous number of ranks
: ADC-CFGR_DISCEN   %1 16 lshift ADC-CFGR bis! ;  \ ADC-CFGR_DISCEN    ADC group regular sequencer discontinuous mode
: ADC-CFGR_AUTDLY   %1 14 lshift ADC-CFGR bis! ;  \ ADC-CFGR_AUTDLY    ADC low power auto wait
: ADC-CFGR_CONT   %1 13 lshift ADC-CFGR bis! ;  \ ADC-CFGR_CONT    ADC group regular continuous conversion mode
: ADC-CFGR_OVRMOD   %1 12 lshift ADC-CFGR bis! ;  \ ADC-CFGR_OVRMOD    ADC group regular overrun configuration
: ADC-CFGR_EXTEN   ( %XX -- ) 10 lshift ADC-CFGR bis! ;  \ ADC-CFGR_EXTEN    ADC group regular external trigger polarity
: ADC-CFGR_EXTSEL   ( %XXXX -- ) 6 lshift ADC-CFGR bis! ;  \ ADC-CFGR_EXTSEL    ADC group regular external trigger source
: ADC-CFGR_ALIGN   %1 5 lshift ADC-CFGR bis! ;  \ ADC-CFGR_ALIGN    ADC data alignement
: ADC-CFGR_RES   ( %XX -- ) 3 lshift ADC-CFGR bis! ;  \ ADC-CFGR_RES    ADC data resolution
: ADC-CFGR_DMACFG   %1 1 lshift ADC-CFGR bis! ;  \ ADC-CFGR_DMACFG    ADC DMA transfer configuration
: ADC-CFGR_DMAEN   %1 0 lshift ADC-CFGR bis! ;  \ ADC-CFGR_DMAEN    ADC DMA transfer enable

\ ADC-CFGR2 (read-write)
: ADC-CFGR2_ROVSM   %1 10 lshift ADC-CFGR2 bis! ;  \ ADC-CFGR2_ROVSM    ADC oversampling mode managing interlaced conversions of ADC group regular and group injected
: ADC-CFGR2_TOVS   %1 9 lshift ADC-CFGR2 bis! ;  \ ADC-CFGR2_TOVS    ADC oversampling discontinuous mode triggered mode for ADC group regular
: ADC-CFGR2_OVSS   ( %XXXX -- ) 5 lshift ADC-CFGR2 bis! ;  \ ADC-CFGR2_OVSS    ADC oversampling shift
: ADC-CFGR2_OVSR   ( %XXX -- ) 2 lshift ADC-CFGR2 bis! ;  \ ADC-CFGR2_OVSR    ADC oversampling ratio
: ADC-CFGR2_JOVSE   %1 1 lshift ADC-CFGR2 bis! ;  \ ADC-CFGR2_JOVSE    ADC oversampler enable on scope ADC group injected
: ADC-CFGR2_ROVSE   %1 0 lshift ADC-CFGR2 bis! ;  \ ADC-CFGR2_ROVSE    ADC oversampler enable on scope ADC group regular

\ ADC-SMPR1 (read-write)
: ADC-SMPR1_SMP9   ( %XXX -- ) 27 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP9    ADC channel 9 sampling time selection
: ADC-SMPR1_SMP8   ( %XXX -- ) 24 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP8    ADC channel 8 sampling time selection
: ADC-SMPR1_SMP7   ( %XXX -- ) 21 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP7    ADC channel 7 sampling time selection
: ADC-SMPR1_SMP6   ( %XXX -- ) 18 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP6    ADC channel 6 sampling time selection
: ADC-SMPR1_SMP5   ( %XXX -- ) 15 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP5    ADC channel 5 sampling time selection
: ADC-SMPR1_SMP4   ( %XXX -- ) 12 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP4    ADC channel 4 sampling time selection
: ADC-SMPR1_SMP3   ( %XXX -- ) 9 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP3    ADC channel 3 sampling time selection
: ADC-SMPR1_SMP2   ( %XXX -- ) 6 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP2    ADC channel 2 sampling time selection
: ADC-SMPR1_SMP1   ( %XXX -- ) 3 lshift ADC-SMPR1 bis! ;  \ ADC-SMPR1_SMP1    ADC channel 1 sampling time selection

\ ADC-SMPR2 (read-write)
: ADC-SMPR2_SMP18   ( %XXX -- ) 24 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP18    ADC channel 18 sampling time selection
: ADC-SMPR2_SMP17   ( %XXX -- ) 21 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP17    ADC channel 17 sampling time selection
: ADC-SMPR2_SMP16   ( %XXX -- ) 18 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP16    ADC channel 16 sampling time selection
: ADC-SMPR2_SMP15   ( %XXX -- ) 15 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP15    ADC channel 15 sampling time selection
: ADC-SMPR2_SMP14   ( %XXX -- ) 12 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP14    ADC channel 14 sampling time selection
: ADC-SMPR2_SMP13   ( %XXX -- ) 9 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP13    ADC channel 13 sampling time selection
: ADC-SMPR2_SMP12   ( %XXX -- ) 6 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP12    ADC channel 12 sampling time selection
: ADC-SMPR2_SMP11   ( %XXX -- ) 3 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP11    ADC channel 11 sampling time selection
: ADC-SMPR2_SMP10   ( %XXX -- ) 0 lshift ADC-SMPR2 bis! ;  \ ADC-SMPR2_SMP10    ADC channel 10 sampling time selection

\ ADC-TR1 (read-write)
: ADC-TR1_HT1   ( %XXXXXXXXXXX -- ) 16 lshift ADC-TR1 bis! ;  \ ADC-TR1_HT1    ADC analog watchdog 1 threshold high
: ADC-TR1_LT1   ( %XXXXXXXXXXX -- ) 0 lshift ADC-TR1 bis! ;  \ ADC-TR1_LT1    ADC analog watchdog 1 threshold low

\ ADC-TR2 (read-write)
: ADC-TR2_HT2   ( %XXXXXXXX -- ) 16 lshift ADC-TR2 bis! ;  \ ADC-TR2_HT2    ADC analog watchdog 2 threshold high
: ADC-TR2_LT2   ( %XXXXXXXX -- ) 0 lshift ADC-TR2 bis! ;  \ ADC-TR2_LT2    ADC analog watchdog 2 threshold low

\ ADC-TR3 (read-write)
: ADC-TR3_HT3   ( %XXXXXXXX -- ) 16 lshift ADC-TR3 bis! ;  \ ADC-TR3_HT3    ADC analog watchdog 3 threshold high
: ADC-TR3_LT3   ( %XXXXXXXX -- ) 0 lshift ADC-TR3 bis! ;  \ ADC-TR3_LT3    ADC analog watchdog 3 threshold low

\ ADC-SQR1 (read-write)
: ADC-SQR1_SQ4   ( %XXXXX -- ) 24 lshift ADC-SQR1 bis! ;  \ ADC-SQR1_SQ4    ADC group regular sequencer rank 4
: ADC-SQR1_SQ3   ( %XXXXX -- ) 18 lshift ADC-SQR1 bis! ;  \ ADC-SQR1_SQ3    ADC group regular sequencer rank 3
: ADC-SQR1_SQ2   ( %XXXXX -- ) 12 lshift ADC-SQR1 bis! ;  \ ADC-SQR1_SQ2    ADC group regular sequencer rank 2
: ADC-SQR1_SQ1   ( %XXXXX -- ) 6 lshift ADC-SQR1 bis! ;  \ ADC-SQR1_SQ1    ADC group regular sequencer rank 1
: ADC-SQR1_L3   ( %XXXX -- ) 0 lshift ADC-SQR1 bis! ;  \ ADC-SQR1_L3    L3

\ ADC-SQR2 (read-write)
: ADC-SQR2_SQ9   ( %XXXXX -- ) 24 lshift ADC-SQR2 bis! ;  \ ADC-SQR2_SQ9    ADC group regular sequencer rank 9
: ADC-SQR2_SQ8   ( %XXXXX -- ) 18 lshift ADC-SQR2 bis! ;  \ ADC-SQR2_SQ8    ADC group regular sequencer rank 8
: ADC-SQR2_SQ7   ( %XXXXX -- ) 12 lshift ADC-SQR2 bis! ;  \ ADC-SQR2_SQ7    ADC group regular sequencer rank 7
: ADC-SQR2_SQ6   ( %XXXXX -- ) 6 lshift ADC-SQR2 bis! ;  \ ADC-SQR2_SQ6    ADC group regular sequencer rank 6
: ADC-SQR2_SQ5   ( %XXXXX -- ) 0 lshift ADC-SQR2 bis! ;  \ ADC-SQR2_SQ5    ADC group regular sequencer rank 5

\ ADC-SQR3 (read-write)
: ADC-SQR3_SQ14   ( %XXXXX -- ) 24 lshift ADC-SQR3 bis! ;  \ ADC-SQR3_SQ14    ADC group regular sequencer rank 14
: ADC-SQR3_SQ13   ( %XXXXX -- ) 18 lshift ADC-SQR3 bis! ;  \ ADC-SQR3_SQ13    ADC group regular sequencer rank 13
: ADC-SQR3_SQ12   ( %XXXXX -- ) 12 lshift ADC-SQR3 bis! ;  \ ADC-SQR3_SQ12    ADC group regular sequencer rank 12
: ADC-SQR3_SQ11   ( %XXXXX -- ) 6 lshift ADC-SQR3 bis! ;  \ ADC-SQR3_SQ11    ADC group regular sequencer rank 11
: ADC-SQR3_SQ10   ( %XXXXX -- ) 0 lshift ADC-SQR3 bis! ;  \ ADC-SQR3_SQ10    ADC group regular sequencer rank 10

\ ADC-SQR4 (read-write)
: ADC-SQR4_SQ16   ( %XXXXX -- ) 6 lshift ADC-SQR4 bis! ;  \ ADC-SQR4_SQ16    ADC group regular sequencer rank 16
: ADC-SQR4_SQ15   ( %XXXXX -- ) 0 lshift ADC-SQR4 bis! ;  \ ADC-SQR4_SQ15    ADC group regular sequencer rank 15

\ ADC-DR ()
: ADC-DR_RDATA_0_6   ( %XXXXXX -- ) 0 lshift ADC-DR bis! ;  \ ADC-DR_RDATA_0_6    Regular Data converted 0_6
: ADC-DR_RDATA_7_15   ( %XXXXXXXXX -- ) 7 lshift ADC-DR bis! ;  \ ADC-DR_RDATA_7_15    15

\ ADC-JSQR (read-write)
: ADC-JSQR_JSQ4   ( %XXXXX -- ) 26 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JSQ4    ADC group injected sequencer rank 4
: ADC-JSQR_JSQ3   ( %XXXXX -- ) 20 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JSQ3    ADC group injected sequencer rank 3
: ADC-JSQR_JSQ2   ( %XXXXX -- ) 14 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JSQ2    ADC group injected sequencer rank 2
: ADC-JSQR_JSQ1   ( %XXXXX -- ) 8 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JSQ1    ADC group injected sequencer rank 1
: ADC-JSQR_JEXTEN   ( %XX -- ) 6 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JEXTEN    ADC group injected external trigger polarity
: ADC-JSQR_JEXTSEL   ( %XXXX -- ) 2 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JEXTSEL    ADC group injected external trigger source
: ADC-JSQR_JL   ( %XX -- ) 0 lshift ADC-JSQR bis! ;  \ ADC-JSQR_JL    ADC group injected sequencer scan length

\ ADC-OFR1 (read-write)
: ADC-OFR1_OFFSET1_EN   %1 31 lshift ADC-OFR1 bis! ;  \ ADC-OFR1_OFFSET1_EN    ADC offset number 1 enable
: ADC-OFR1_OFFSET1_CH   ( %XXXXX -- ) 26 lshift ADC-OFR1 bis! ;  \ ADC-OFR1_OFFSET1_CH    ADC offset number 1 channel selection
: ADC-OFR1_OFFSET1   ( %XXXXXXXXXXX -- ) 0 lshift ADC-OFR1 bis! ;  \ ADC-OFR1_OFFSET1    ADC offset number 1 offset level

\ ADC-OFR2 (read-write)
: ADC-OFR2_OFFSET2_EN   %1 31 lshift ADC-OFR2 bis! ;  \ ADC-OFR2_OFFSET2_EN    ADC offset number 2 enable
: ADC-OFR2_OFFSET2_CH   ( %XXXXX -- ) 26 lshift ADC-OFR2 bis! ;  \ ADC-OFR2_OFFSET2_CH    ADC offset number 2 channel selection
: ADC-OFR2_OFFSET2   ( %XXXXXXXXXXX -- ) 0 lshift ADC-OFR2 bis! ;  \ ADC-OFR2_OFFSET2    ADC offset number 2 offset level

\ ADC-OFR3 (read-write)
: ADC-OFR3_OFFSET3_EN   %1 31 lshift ADC-OFR3 bis! ;  \ ADC-OFR3_OFFSET3_EN    ADC offset number 3 enable
: ADC-OFR3_OFFSET3_CH   ( %XXXXX -- ) 26 lshift ADC-OFR3 bis! ;  \ ADC-OFR3_OFFSET3_CH    ADC offset number 3 channel selection
: ADC-OFR3_OFFSET3   ( %XXXXXXXXXXX -- ) 0 lshift ADC-OFR3 bis! ;  \ ADC-OFR3_OFFSET3    ADC offset number 3 offset level

\ ADC-OFR4 (read-write)
: ADC-OFR4_OFFSET4_EN   %1 31 lshift ADC-OFR4 bis! ;  \ ADC-OFR4_OFFSET4_EN    ADC offset number 4 enable
: ADC-OFR4_OFFSET4_CH   ( %XXXXX -- ) 26 lshift ADC-OFR4 bis! ;  \ ADC-OFR4_OFFSET4_CH    ADC offset number 4 channel selection
: ADC-OFR4_OFFSET4   ( %XXXXXXXXXXX -- ) 0 lshift ADC-OFR4 bis! ;  \ ADC-OFR4_OFFSET4    ADC offset number 4 offset level

\ ADC-JDR1 (read-only)
: ADC-JDR1_JDATA1   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift ADC-JDR1 bis! ;  \ ADC-JDR1_JDATA1    ADC group injected sequencer rank 1 conversion data

\ ADC-JDR2 (read-only)
: ADC-JDR2_JDATA2   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift ADC-JDR2 bis! ;  \ ADC-JDR2_JDATA2    ADC group injected sequencer rank 2 conversion data

\ ADC-JDR3 (read-only)
: ADC-JDR3_JDATA3   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift ADC-JDR3 bis! ;  \ ADC-JDR3_JDATA3    ADC group injected sequencer rank 3 conversion data

\ ADC-JDR4 (read-only)
: ADC-JDR4_JDATA4   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift ADC-JDR4 bis! ;  \ ADC-JDR4_JDATA4    ADC group injected sequencer rank 4 conversion data

\ ADC-AWD2CR (read-write)
: ADC-AWD2CR_AWD2CH  0 lshift ADC-AWD2CR bis! ;  \ ADC-AWD2CR_AWD2CH    ADC analog watchdog 2 monitored channel selection

\ ADC-AWD3CR (read-write)
: ADC-AWD3CR_AWD3CH  0 lshift ADC-AWD3CR bis! ;  \ ADC-AWD3CR_AWD3CH    ADC analog watchdog 3 monitored channel selection

\ ADC-DIFSEL ()
: ADC-DIFSEL_DIFSEL_0   %1 0 lshift ADC-DIFSEL bis! ;  \ ADC-DIFSEL_DIFSEL_0    ADC channel differential or single-ended mode for channel 0
: ADC-DIFSEL_DIFSEL_1_15   ( %XXXXXXXXXXXXXXX -- ) 1 lshift ADC-DIFSEL bis! ;  \ ADC-DIFSEL_DIFSEL_1_15    ADC channel differential or single-ended mode for channels 1 to 15
: ADC-DIFSEL_DIFSEL_16_18   ( %XXX -- ) 16 lshift ADC-DIFSEL bis! ;  \ ADC-DIFSEL_DIFSEL_16_18    ADC channel differential or single-ended mode for channels 18 to 16

\ ADC-CALFACT (read-write)
: ADC-CALFACT_CALFACT_D   ( %XXXXXXX -- ) 16 lshift ADC-CALFACT bis! ;  \ ADC-CALFACT_CALFACT_D    ADC calibration factor in differential mode
: ADC-CALFACT_CALFACT_S   ( %XXXXXXX -- ) 0 lshift ADC-CALFACT bis! ;  \ ADC-CALFACT_CALFACT_S    ADC calibration factor in single-ended mode

\ ADC-CCR (read-write)
: ADC-CCR_VBATEN   %1 24 lshift ADC-CCR bis! ;  \ ADC-CCR_VBATEN    VBAT enable
: ADC-CCR_TSEN   %1 23 lshift ADC-CCR bis! ;  \ ADC-CCR_TSEN    Temperature sensor enable
: ADC-CCR_VREFEN   %1 22 lshift ADC-CCR bis! ;  \ ADC-CCR_VREFEN    VREFEN
: ADC-CCR_PRESC   ( %XXXX -- ) 18 lshift ADC-CCR bis! ;  \ ADC-CCR_PRESC    ADC prescaler
: ADC-CCR_CKMODE   ( %XX -- ) 16 lshift ADC-CCR bis! ;  \ ADC-CCR_CKMODE    ADC clock mode

\ GPIOA-MODER (read-write)
: GPIOA-MODER_MODER15   ( %XX -- ) 30 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER15    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER14   ( %XX -- ) 28 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER14    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER13   ( %XX -- ) 26 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER13    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER12   ( %XX -- ) 24 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER12    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER11   ( %XX -- ) 22 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER11    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER10   ( %XX -- ) 20 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER10    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER9   ( %XX -- ) 18 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER9    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER8   ( %XX -- ) 16 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER8    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER7   ( %XX -- ) 14 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER7    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER6   ( %XX -- ) 12 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER6    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER5   ( %XX -- ) 10 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER5    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER4   ( %XX -- ) 8 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER4    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER3   ( %XX -- ) 6 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER3    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER2   ( %XX -- ) 4 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER2    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER1   ( %XX -- ) 2 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER1    Port x configuration bits y = 0..15
: GPIOA-MODER_MODER0   ( %XX -- ) 0 lshift GPIOA-MODER bis! ;  \ GPIOA-MODER_MODER0    Port x configuration bits y = 0..15

\ GPIOA-OTYPER (read-write)
: GPIOA-OTYPER_OT15   %1 15 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT15    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT14   %1 14 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT14    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT13   %1 13 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT13    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT12   %1 12 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT12    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT11   %1 11 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT11    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT10   %1 10 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT10    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT9   %1 9 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT9    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT8   %1 8 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT8    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT7   %1 7 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT7    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT6   %1 6 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT6    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT5   %1 5 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT5    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT4   %1 4 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT4    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT3   %1 3 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT3    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT2   %1 2 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT2    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT1   %1 1 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT1    Port x configuration bits y = 0..15
: GPIOA-OTYPER_OT0   %1 0 lshift GPIOA-OTYPER bis! ;  \ GPIOA-OTYPER_OT0    Port x configuration bits y = 0..15

\ GPIOA-OSPEEDR (read-write)
: GPIOA-OSPEEDR_OSPEEDR15   ( %XX -- ) 30 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR15    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR14   ( %XX -- ) 28 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR14    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR13   ( %XX -- ) 26 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR13    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR12   ( %XX -- ) 24 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR12    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR11   ( %XX -- ) 22 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR11    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR10   ( %XX -- ) 20 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR10    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR9   ( %XX -- ) 18 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR9    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR8   ( %XX -- ) 16 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR8    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR7   ( %XX -- ) 14 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR7    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR6   ( %XX -- ) 12 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR6    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR5   ( %XX -- ) 10 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR5    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR4   ( %XX -- ) 8 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR4    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR3   ( %XX -- ) 6 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR3    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR2   ( %XX -- ) 4 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR2    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR1   ( %XX -- ) 2 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR1    Port x configuration bits y = 0..15
: GPIOA-OSPEEDR_OSPEEDR0   ( %XX -- ) 0 lshift GPIOA-OSPEEDR bis! ;  \ GPIOA-OSPEEDR_OSPEEDR0    Port x configuration bits y = 0..15

\ GPIOA-PUPDR (read-write)
: GPIOA-PUPDR_PUPDR15   ( %XX -- ) 30 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR15    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR14   ( %XX -- ) 28 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR14    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR13   ( %XX -- ) 26 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR13    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR12   ( %XX -- ) 24 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR12    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR11   ( %XX -- ) 22 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR11    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR10   ( %XX -- ) 20 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR10    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR9   ( %XX -- ) 18 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR9    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR8   ( %XX -- ) 16 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR8    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR7   ( %XX -- ) 14 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR7    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR6   ( %XX -- ) 12 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR6    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR5   ( %XX -- ) 10 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR5    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR4   ( %XX -- ) 8 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR4    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR3   ( %XX -- ) 6 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR3    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR2   ( %XX -- ) 4 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR2    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR1   ( %XX -- ) 2 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR1    Port x configuration bits y = 0..15
: GPIOA-PUPDR_PUPDR0   ( %XX -- ) 0 lshift GPIOA-PUPDR bis! ;  \ GPIOA-PUPDR_PUPDR0    Port x configuration bits y = 0..15

\ GPIOA-IDR (read-only)
: GPIOA-IDR_IDR15   %1 15 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR15    Port input data y = 0..15
: GPIOA-IDR_IDR14   %1 14 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR14    Port input data y = 0..15
: GPIOA-IDR_IDR13   %1 13 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR13    Port input data y = 0..15
: GPIOA-IDR_IDR12   %1 12 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR12    Port input data y = 0..15
: GPIOA-IDR_IDR11   %1 11 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR11    Port input data y = 0..15
: GPIOA-IDR_IDR10   %1 10 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR10    Port input data y = 0..15
: GPIOA-IDR_IDR9   %1 9 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR9    Port input data y = 0..15
: GPIOA-IDR_IDR8   %1 8 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR8    Port input data y = 0..15
: GPIOA-IDR_IDR7   %1 7 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR7    Port input data y = 0..15
: GPIOA-IDR_IDR6   %1 6 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR6    Port input data y = 0..15
: GPIOA-IDR_IDR5   %1 5 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR5    Port input data y = 0..15
: GPIOA-IDR_IDR4   %1 4 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR4    Port input data y = 0..15
: GPIOA-IDR_IDR3   %1 3 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR3    Port input data y = 0..15
: GPIOA-IDR_IDR2   %1 2 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR2    Port input data y = 0..15
: GPIOA-IDR_IDR1   %1 1 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR1    Port input data y = 0..15
: GPIOA-IDR_IDR0   %1 0 lshift GPIOA-IDR bis! ;  \ GPIOA-IDR_IDR0    Port input data y = 0..15

\ GPIOA-ODR (read-write)
: GPIOA-ODR_ODR15   %1 15 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR15    Port output data y = 0..15
: GPIOA-ODR_ODR14   %1 14 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR14    Port output data y = 0..15
: GPIOA-ODR_ODR13   %1 13 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR13    Port output data y = 0..15
: GPIOA-ODR_ODR12   %1 12 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR12    Port output data y = 0..15
: GPIOA-ODR_ODR11   %1 11 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR11    Port output data y = 0..15
: GPIOA-ODR_ODR10   %1 10 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR10    Port output data y = 0..15
: GPIOA-ODR_ODR9   %1 9 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR9    Port output data y = 0..15
: GPIOA-ODR_ODR8   %1 8 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR8    Port output data y = 0..15
: GPIOA-ODR_ODR7   %1 7 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR7    Port output data y = 0..15
: GPIOA-ODR_ODR6   %1 6 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR6    Port output data y = 0..15
: GPIOA-ODR_ODR5   %1 5 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR5    Port output data y = 0..15
: GPIOA-ODR_ODR4   %1 4 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR4    Port output data y = 0..15
: GPIOA-ODR_ODR3   %1 3 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR3    Port output data y = 0..15
: GPIOA-ODR_ODR2   %1 2 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR2    Port output data y = 0..15
: GPIOA-ODR_ODR1   %1 1 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR1    Port output data y = 0..15
: GPIOA-ODR_ODR0   %1 0 lshift GPIOA-ODR bis! ;  \ GPIOA-ODR_ODR0    Port output data y = 0..15

\ GPIOA-BSRR (write-only)
: GPIOA-BSRR_BR15   %1 31 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR15    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR14   %1 30 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR14    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR13   %1 29 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR13    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR12   %1 28 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR12    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR11   %1 27 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR11    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR10   %1 26 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR10    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR9   %1 25 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR9    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR8   %1 24 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR8    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR7   %1 23 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR7    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR6   %1 22 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR6    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR5   %1 21 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR5    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR4   %1 20 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR4    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR3   %1 19 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR3    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR2   %1 18 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR2    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR1   %1 17 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR1    Port x reset bit y y = 0..15
: GPIOA-BSRR_BR0   %1 16 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BR0    Port x set bit y y= 0..15
: GPIOA-BSRR_BS15   %1 15 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS15    Port x set bit y y= 0..15
: GPIOA-BSRR_BS14   %1 14 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS14    Port x set bit y y= 0..15
: GPIOA-BSRR_BS13   %1 13 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS13    Port x set bit y y= 0..15
: GPIOA-BSRR_BS12   %1 12 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS12    Port x set bit y y= 0..15
: GPIOA-BSRR_BS11   %1 11 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS11    Port x set bit y y= 0..15
: GPIOA-BSRR_BS10   %1 10 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS10    Port x set bit y y= 0..15
: GPIOA-BSRR_BS9   %1 9 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS9    Port x set bit y y= 0..15
: GPIOA-BSRR_BS8   %1 8 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS8    Port x set bit y y= 0..15
: GPIOA-BSRR_BS7   %1 7 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS7    Port x set bit y y= 0..15
: GPIOA-BSRR_BS6   %1 6 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS6    Port x set bit y y= 0..15
: GPIOA-BSRR_BS5   %1 5 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS5    Port x set bit y y= 0..15
: GPIOA-BSRR_BS4   %1 4 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS4    Port x set bit y y= 0..15
: GPIOA-BSRR_BS3   %1 3 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS3    Port x set bit y y= 0..15
: GPIOA-BSRR_BS2   %1 2 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS2    Port x set bit y y= 0..15
: GPIOA-BSRR_BS1   %1 1 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS1    Port x set bit y y= 0..15
: GPIOA-BSRR_BS0   %1 0 lshift GPIOA-BSRR bis! ;  \ GPIOA-BSRR_BS0    Port x set bit y y= 0..15

\ GPIOA-LCKR (read-write)
: GPIOA-LCKR_LCKK   %1 16 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCKK    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK15   %1 15 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK15    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK14   %1 14 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK14    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK13   %1 13 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK13    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK12   %1 12 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK12    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK11   %1 11 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK11    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK10   %1 10 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK10    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK9   %1 9 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK9    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK8   %1 8 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK8    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK7   %1 7 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK7    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK6   %1 6 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK6    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK5   %1 5 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK5    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK4   %1 4 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK4    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK3   %1 3 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK3    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK2   %1 2 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK2    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK1   %1 1 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK1    Port x lock bit y y= 0..15
: GPIOA-LCKR_LCK0   %1 0 lshift GPIOA-LCKR bis! ;  \ GPIOA-LCKR_LCK0    Port x lock bit y y= 0..15

\ GPIOA-AFRL (read-write)
: GPIOA-AFRL_AFSEL7   ( %XXXX -- ) 28 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL7    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL6   ( %XXXX -- ) 24 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL6    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL5   ( %XXXX -- ) 20 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL5    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL4   ( %XXXX -- ) 16 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL4    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL3   ( %XXXX -- ) 12 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL3    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL2   ( %XXXX -- ) 8 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL2    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL1   ( %XXXX -- ) 4 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL1    Alternate function selection for port x bit y y = 0..7
: GPIOA-AFRL_AFSEL0   ( %XXXX -- ) 0 lshift GPIOA-AFRL bis! ;  \ GPIOA-AFRL_AFSEL0    Alternate function selection for port x bit y y = 0..7

\ GPIOA-AFRH (read-write)
: GPIOA-AFRH_AFSEL15   ( %XXXX -- ) 28 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL15    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL14   ( %XXXX -- ) 24 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL14    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL13   ( %XXXX -- ) 20 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL13    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL12   ( %XXXX -- ) 16 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL12    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL11   ( %XXXX -- ) 12 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL11    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL10   ( %XXXX -- ) 8 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL10    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL9   ( %XXXX -- ) 4 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL9    Alternate function selection for port x bit y y = 8..15
: GPIOA-AFRH_AFSEL8   ( %XXXX -- ) 0 lshift GPIOA-AFRH bis! ;  \ GPIOA-AFRH_AFSEL8    Alternate function selection for port x bit y y = 8..15

\ GPIOA-BRR (write-only)
: GPIOA-BRR_BR0   %1 0 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR0    Port Reset bit
: GPIOA-BRR_BR1   %1 1 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR1    Port Reset bit
: GPIOA-BRR_BR2   %1 2 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR2    Port Reset bit
: GPIOA-BRR_BR3   %1 3 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR3    Port Reset bit
: GPIOA-BRR_BR4   %1 4 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR4    Port Reset bit
: GPIOA-BRR_BR5   %1 5 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR5    Port Reset bit
: GPIOA-BRR_BR6   %1 6 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR6    Port Reset bit
: GPIOA-BRR_BR7   %1 7 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR7    Port Reset bit
: GPIOA-BRR_BR8   %1 8 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR8    Port Reset bit
: GPIOA-BRR_BR9   %1 9 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR9    Port Reset bit
: GPIOA-BRR_BR10   %1 10 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR10    Port Reset bit
: GPIOA-BRR_BR11   %1 11 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR11    Port Reset bit
: GPIOA-BRR_BR12   %1 12 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR12    Port Reset bit
: GPIOA-BRR_BR13   %1 13 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR13    Port Reset bit
: GPIOA-BRR_BR14   %1 14 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR14    Port Reset bit
: GPIOA-BRR_BR15   %1 15 lshift GPIOA-BRR bis! ;  \ GPIOA-BRR_BR15    Port Reset bit

\ GPIOB-MODER (read-write)
: GPIOB-MODER_MODER15   ( %XX -- ) 30 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER15    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER14   ( %XX -- ) 28 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER14    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER13   ( %XX -- ) 26 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER13    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER12   ( %XX -- ) 24 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER12    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER11   ( %XX -- ) 22 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER11    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER10   ( %XX -- ) 20 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER10    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER9   ( %XX -- ) 18 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER9    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER8   ( %XX -- ) 16 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER8    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER7   ( %XX -- ) 14 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER7    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER6   ( %XX -- ) 12 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER6    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER5   ( %XX -- ) 10 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER5    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER4   ( %XX -- ) 8 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER4    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER3   ( %XX -- ) 6 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER3    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER2   ( %XX -- ) 4 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER2    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER1   ( %XX -- ) 2 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER1    Port x configuration bits y = 0..15
: GPIOB-MODER_MODER0   ( %XX -- ) 0 lshift GPIOB-MODER bis! ;  \ GPIOB-MODER_MODER0    Port x configuration bits y = 0..15

\ GPIOB-OTYPER (read-write)
: GPIOB-OTYPER_OT15   %1 15 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT15    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT14   %1 14 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT14    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT13   %1 13 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT13    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT12   %1 12 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT12    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT11   %1 11 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT11    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT10   %1 10 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT10    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT9   %1 9 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT9    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT8   %1 8 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT8    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT7   %1 7 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT7    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT6   %1 6 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT6    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT5   %1 5 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT5    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT4   %1 4 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT4    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT3   %1 3 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT3    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT2   %1 2 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT2    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT1   %1 1 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT1    Port x configuration bits y = 0..15
: GPIOB-OTYPER_OT0   %1 0 lshift GPIOB-OTYPER bis! ;  \ GPIOB-OTYPER_OT0    Port x configuration bits y = 0..15

\ GPIOB-OSPEEDR (read-write)
: GPIOB-OSPEEDR_OSPEEDR15   ( %XX -- ) 30 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR15    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR14   ( %XX -- ) 28 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR14    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR13   ( %XX -- ) 26 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR13    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR12   ( %XX -- ) 24 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR12    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR11   ( %XX -- ) 22 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR11    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR10   ( %XX -- ) 20 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR10    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR9   ( %XX -- ) 18 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR9    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR8   ( %XX -- ) 16 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR8    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR7   ( %XX -- ) 14 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR7    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR6   ( %XX -- ) 12 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR6    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR5   ( %XX -- ) 10 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR5    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR4   ( %XX -- ) 8 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR4    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR3   ( %XX -- ) 6 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR3    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR2   ( %XX -- ) 4 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR2    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR1   ( %XX -- ) 2 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR1    Port x configuration bits y = 0..15
: GPIOB-OSPEEDR_OSPEEDR0   ( %XX -- ) 0 lshift GPIOB-OSPEEDR bis! ;  \ GPIOB-OSPEEDR_OSPEEDR0    Port x configuration bits y = 0..15

\ GPIOB-PUPDR (read-write)
: GPIOB-PUPDR_PUPDR15   ( %XX -- ) 30 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR15    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR14   ( %XX -- ) 28 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR14    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR13   ( %XX -- ) 26 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR13    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR12   ( %XX -- ) 24 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR12    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR11   ( %XX -- ) 22 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR11    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR10   ( %XX -- ) 20 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR10    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR9   ( %XX -- ) 18 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR9    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR8   ( %XX -- ) 16 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR8    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR7   ( %XX -- ) 14 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR7    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR6   ( %XX -- ) 12 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR6    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR5   ( %XX -- ) 10 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR5    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR4   ( %XX -- ) 8 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR4    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR3   ( %XX -- ) 6 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR3    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR2   ( %XX -- ) 4 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR2    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR1   ( %XX -- ) 2 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR1    Port x configuration bits y = 0..15
: GPIOB-PUPDR_PUPDR0   ( %XX -- ) 0 lshift GPIOB-PUPDR bis! ;  \ GPIOB-PUPDR_PUPDR0    Port x configuration bits y = 0..15

\ GPIOB-IDR (read-only)
: GPIOB-IDR_IDR15   %1 15 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR15    Port input data y = 0..15
: GPIOB-IDR_IDR14   %1 14 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR14    Port input data y = 0..15
: GPIOB-IDR_IDR13   %1 13 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR13    Port input data y = 0..15
: GPIOB-IDR_IDR12   %1 12 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR12    Port input data y = 0..15
: GPIOB-IDR_IDR11   %1 11 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR11    Port input data y = 0..15
: GPIOB-IDR_IDR10   %1 10 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR10    Port input data y = 0..15
: GPIOB-IDR_IDR9   %1 9 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR9    Port input data y = 0..15
: GPIOB-IDR_IDR8   %1 8 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR8    Port input data y = 0..15
: GPIOB-IDR_IDR7   %1 7 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR7    Port input data y = 0..15
: GPIOB-IDR_IDR6   %1 6 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR6    Port input data y = 0..15
: GPIOB-IDR_IDR5   %1 5 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR5    Port input data y = 0..15
: GPIOB-IDR_IDR4   %1 4 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR4    Port input data y = 0..15
: GPIOB-IDR_IDR3   %1 3 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR3    Port input data y = 0..15
: GPIOB-IDR_IDR2   %1 2 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR2    Port input data y = 0..15
: GPIOB-IDR_IDR1   %1 1 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR1    Port input data y = 0..15
: GPIOB-IDR_IDR0   %1 0 lshift GPIOB-IDR bis! ;  \ GPIOB-IDR_IDR0    Port input data y = 0..15

\ GPIOB-ODR (read-write)
: GPIOB-ODR_ODR15   %1 15 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR15    Port output data y = 0..15
: GPIOB-ODR_ODR14   %1 14 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR14    Port output data y = 0..15
: GPIOB-ODR_ODR13   %1 13 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR13    Port output data y = 0..15
: GPIOB-ODR_ODR12   %1 12 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR12    Port output data y = 0..15
: GPIOB-ODR_ODR11   %1 11 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR11    Port output data y = 0..15
: GPIOB-ODR_ODR10   %1 10 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR10    Port output data y = 0..15
: GPIOB-ODR_ODR9   %1 9 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR9    Port output data y = 0..15
: GPIOB-ODR_ODR8   %1 8 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR8    Port output data y = 0..15
: GPIOB-ODR_ODR7   %1 7 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR7    Port output data y = 0..15
: GPIOB-ODR_ODR6   %1 6 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR6    Port output data y = 0..15
: GPIOB-ODR_ODR5   %1 5 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR5    Port output data y = 0..15
: GPIOB-ODR_ODR4   %1 4 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR4    Port output data y = 0..15
: GPIOB-ODR_ODR3   %1 3 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR3    Port output data y = 0..15
: GPIOB-ODR_ODR2   %1 2 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR2    Port output data y = 0..15
: GPIOB-ODR_ODR1   %1 1 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR1    Port output data y = 0..15
: GPIOB-ODR_ODR0   %1 0 lshift GPIOB-ODR bis! ;  \ GPIOB-ODR_ODR0    Port output data y = 0..15

\ GPIOB-BSRR (write-only)
: GPIOB-BSRR_BR15   %1 31 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR15    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR14   %1 30 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR14    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR13   %1 29 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR13    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR12   %1 28 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR12    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR11   %1 27 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR11    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR10   %1 26 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR10    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR9   %1 25 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR9    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR8   %1 24 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR8    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR7   %1 23 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR7    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR6   %1 22 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR6    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR5   %1 21 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR5    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR4   %1 20 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR4    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR3   %1 19 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR3    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR2   %1 18 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR2    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR1   %1 17 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR1    Port x reset bit y y = 0..15
: GPIOB-BSRR_BR0   %1 16 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BR0    Port x set bit y y= 0..15
: GPIOB-BSRR_BS15   %1 15 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS15    Port x set bit y y= 0..15
: GPIOB-BSRR_BS14   %1 14 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS14    Port x set bit y y= 0..15
: GPIOB-BSRR_BS13   %1 13 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS13    Port x set bit y y= 0..15
: GPIOB-BSRR_BS12   %1 12 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS12    Port x set bit y y= 0..15
: GPIOB-BSRR_BS11   %1 11 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS11    Port x set bit y y= 0..15
: GPIOB-BSRR_BS10   %1 10 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS10    Port x set bit y y= 0..15
: GPIOB-BSRR_BS9   %1 9 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS9    Port x set bit y y= 0..15
: GPIOB-BSRR_BS8   %1 8 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS8    Port x set bit y y= 0..15
: GPIOB-BSRR_BS7   %1 7 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS7    Port x set bit y y= 0..15
: GPIOB-BSRR_BS6   %1 6 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS6    Port x set bit y y= 0..15
: GPIOB-BSRR_BS5   %1 5 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS5    Port x set bit y y= 0..15
: GPIOB-BSRR_BS4   %1 4 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS4    Port x set bit y y= 0..15
: GPIOB-BSRR_BS3   %1 3 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS3    Port x set bit y y= 0..15
: GPIOB-BSRR_BS2   %1 2 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS2    Port x set bit y y= 0..15
: GPIOB-BSRR_BS1   %1 1 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS1    Port x set bit y y= 0..15
: GPIOB-BSRR_BS0   %1 0 lshift GPIOB-BSRR bis! ;  \ GPIOB-BSRR_BS0    Port x set bit y y= 0..15

\ GPIOB-LCKR (read-write)
: GPIOB-LCKR_LCKK   %1 16 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCKK    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK15   %1 15 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK15    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK14   %1 14 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK14    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK13   %1 13 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK13    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK12   %1 12 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK12    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK11   %1 11 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK11    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK10   %1 10 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK10    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK9   %1 9 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK9    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK8   %1 8 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK8    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK7   %1 7 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK7    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK6   %1 6 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK6    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK5   %1 5 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK5    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK4   %1 4 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK4    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK3   %1 3 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK3    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK2   %1 2 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK2    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK1   %1 1 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK1    Port x lock bit y y= 0..15
: GPIOB-LCKR_LCK0   %1 0 lshift GPIOB-LCKR bis! ;  \ GPIOB-LCKR_LCK0    Port x lock bit y y= 0..15

\ GPIOB-AFRL (read-write)
: GPIOB-AFRL_AFSEL7   ( %XXXX -- ) 28 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL7    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL6   ( %XXXX -- ) 24 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL6    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL5   ( %XXXX -- ) 20 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL5    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL4   ( %XXXX -- ) 16 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL4    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL3   ( %XXXX -- ) 12 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL3    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL2   ( %XXXX -- ) 8 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL2    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL1   ( %XXXX -- ) 4 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL1    Alternate function selection for port x bit y y = 0..7
: GPIOB-AFRL_AFSEL0   ( %XXXX -- ) 0 lshift GPIOB-AFRL bis! ;  \ GPIOB-AFRL_AFSEL0    Alternate function selection for port x bit y y = 0..7

\ GPIOB-AFRH (read-write)
: GPIOB-AFRH_AFSEL15   ( %XXXX -- ) 28 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL15    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL14   ( %XXXX -- ) 24 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL14    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL13   ( %XXXX -- ) 20 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL13    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL12   ( %XXXX -- ) 16 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL12    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL11   ( %XXXX -- ) 12 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL11    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL10   ( %XXXX -- ) 8 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL10    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL9   ( %XXXX -- ) 4 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL9    Alternate function selection for port x bit y y = 8..15
: GPIOB-AFRH_AFSEL8   ( %XXXX -- ) 0 lshift GPIOB-AFRH bis! ;  \ GPIOB-AFRH_AFSEL8    Alternate function selection for port x bit y y = 8..15

\ GPIOB-BRR (write-only)
: GPIOB-BRR_BR0   %1 0 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR0    Port Reset bit
: GPIOB-BRR_BR1   %1 1 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR1    Port Reset bit
: GPIOB-BRR_BR2   %1 2 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR2    Port Reset bit
: GPIOB-BRR_BR3   %1 3 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR3    Port Reset bit
: GPIOB-BRR_BR4   %1 4 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR4    Port Reset bit
: GPIOB-BRR_BR5   %1 5 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR5    Port Reset bit
: GPIOB-BRR_BR6   %1 6 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR6    Port Reset bit
: GPIOB-BRR_BR7   %1 7 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR7    Port Reset bit
: GPIOB-BRR_BR8   %1 8 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR8    Port Reset bit
: GPIOB-BRR_BR9   %1 9 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR9    Port Reset bit
: GPIOB-BRR_BR10   %1 10 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR10    Port Reset bit
: GPIOB-BRR_BR11   %1 11 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR11    Port Reset bit
: GPIOB-BRR_BR12   %1 12 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR12    Port Reset bit
: GPIOB-BRR_BR13   %1 13 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR13    Port Reset bit
: GPIOB-BRR_BR14   %1 14 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR14    Port Reset bit
: GPIOB-BRR_BR15   %1 15 lshift GPIOB-BRR bis! ;  \ GPIOB-BRR_BR15    Port Reset bit

\ GPIOC-MODER (read-write)
: GPIOC-MODER_MODER15   ( %XX -- ) 30 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER15    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER14   ( %XX -- ) 28 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER14    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER13   ( %XX -- ) 26 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER13    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER12   ( %XX -- ) 24 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER12    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER11   ( %XX -- ) 22 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER11    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER10   ( %XX -- ) 20 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER10    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER9   ( %XX -- ) 18 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER9    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER8   ( %XX -- ) 16 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER8    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER7   ( %XX -- ) 14 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER7    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER6   ( %XX -- ) 12 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER6    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER5   ( %XX -- ) 10 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER5    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER4   ( %XX -- ) 8 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER4    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER3   ( %XX -- ) 6 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER3    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER2   ( %XX -- ) 4 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER2    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER1   ( %XX -- ) 2 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER1    Port x configuration bits y = 0..15
: GPIOC-MODER_MODER0   ( %XX -- ) 0 lshift GPIOC-MODER bis! ;  \ GPIOC-MODER_MODER0    Port x configuration bits y = 0..15

\ GPIOC-OTYPER (read-write)
: GPIOC-OTYPER_OT15   %1 15 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT15    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT14   %1 14 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT14    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT13   %1 13 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT13    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT12   %1 12 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT12    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT11   %1 11 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT11    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT10   %1 10 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT10    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT9   %1 9 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT9    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT8   %1 8 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT8    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT7   %1 7 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT7    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT6   %1 6 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT6    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT5   %1 5 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT5    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT4   %1 4 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT4    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT3   %1 3 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT3    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT2   %1 2 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT2    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT1   %1 1 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT1    Port x configuration bits y = 0..15
: GPIOC-OTYPER_OT0   %1 0 lshift GPIOC-OTYPER bis! ;  \ GPIOC-OTYPER_OT0    Port x configuration bits y = 0..15

\ GPIOC-OSPEEDR (read-write)
: GPIOC-OSPEEDR_OSPEEDR15   ( %XX -- ) 30 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR15    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR14   ( %XX -- ) 28 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR14    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR13   ( %XX -- ) 26 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR13    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR12   ( %XX -- ) 24 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR12    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR11   ( %XX -- ) 22 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR11    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR10   ( %XX -- ) 20 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR10    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR9   ( %XX -- ) 18 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR9    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR8   ( %XX -- ) 16 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR8    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR7   ( %XX -- ) 14 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR7    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR6   ( %XX -- ) 12 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR6    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR5   ( %XX -- ) 10 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR5    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR4   ( %XX -- ) 8 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR4    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR3   ( %XX -- ) 6 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR3    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR2   ( %XX -- ) 4 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR2    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR1   ( %XX -- ) 2 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR1    Port x configuration bits y = 0..15
: GPIOC-OSPEEDR_OSPEEDR0   ( %XX -- ) 0 lshift GPIOC-OSPEEDR bis! ;  \ GPIOC-OSPEEDR_OSPEEDR0    Port x configuration bits y = 0..15

\ GPIOC-PUPDR (read-write)
: GPIOC-PUPDR_PUPDR15   ( %XX -- ) 30 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR15    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR14   ( %XX -- ) 28 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR14    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR13   ( %XX -- ) 26 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR13    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR12   ( %XX -- ) 24 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR12    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR11   ( %XX -- ) 22 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR11    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR10   ( %XX -- ) 20 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR10    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR9   ( %XX -- ) 18 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR9    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR8   ( %XX -- ) 16 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR8    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR7   ( %XX -- ) 14 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR7    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR6   ( %XX -- ) 12 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR6    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR5   ( %XX -- ) 10 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR5    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR4   ( %XX -- ) 8 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR4    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR3   ( %XX -- ) 6 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR3    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR2   ( %XX -- ) 4 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR2    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR1   ( %XX -- ) 2 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR1    Port x configuration bits y = 0..15
: GPIOC-PUPDR_PUPDR0   ( %XX -- ) 0 lshift GPIOC-PUPDR bis! ;  \ GPIOC-PUPDR_PUPDR0    Port x configuration bits y = 0..15

\ GPIOC-IDR (read-only)
: GPIOC-IDR_IDR15   %1 15 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR15    Port input data y = 0..15
: GPIOC-IDR_IDR14   %1 14 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR14    Port input data y = 0..15
: GPIOC-IDR_IDR13   %1 13 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR13    Port input data y = 0..15
: GPIOC-IDR_IDR12   %1 12 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR12    Port input data y = 0..15
: GPIOC-IDR_IDR11   %1 11 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR11    Port input data y = 0..15
: GPIOC-IDR_IDR10   %1 10 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR10    Port input data y = 0..15
: GPIOC-IDR_IDR9   %1 9 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR9    Port input data y = 0..15
: GPIOC-IDR_IDR8   %1 8 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR8    Port input data y = 0..15
: GPIOC-IDR_IDR7   %1 7 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR7    Port input data y = 0..15
: GPIOC-IDR_IDR6   %1 6 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR6    Port input data y = 0..15
: GPIOC-IDR_IDR5   %1 5 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR5    Port input data y = 0..15
: GPIOC-IDR_IDR4   %1 4 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR4    Port input data y = 0..15
: GPIOC-IDR_IDR3   %1 3 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR3    Port input data y = 0..15
: GPIOC-IDR_IDR2   %1 2 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR2    Port input data y = 0..15
: GPIOC-IDR_IDR1   %1 1 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR1    Port input data y = 0..15
: GPIOC-IDR_IDR0   %1 0 lshift GPIOC-IDR bis! ;  \ GPIOC-IDR_IDR0    Port input data y = 0..15

\ GPIOC-ODR (read-write)
: GPIOC-ODR_ODR15   %1 15 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR15    Port output data y = 0..15
: GPIOC-ODR_ODR14   %1 14 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR14    Port output data y = 0..15
: GPIOC-ODR_ODR13   %1 13 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR13    Port output data y = 0..15
: GPIOC-ODR_ODR12   %1 12 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR12    Port output data y = 0..15
: GPIOC-ODR_ODR11   %1 11 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR11    Port output data y = 0..15
: GPIOC-ODR_ODR10   %1 10 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR10    Port output data y = 0..15
: GPIOC-ODR_ODR9   %1 9 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR9    Port output data y = 0..15
: GPIOC-ODR_ODR8   %1 8 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR8    Port output data y = 0..15
: GPIOC-ODR_ODR7   %1 7 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR7    Port output data y = 0..15
: GPIOC-ODR_ODR6   %1 6 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR6    Port output data y = 0..15
: GPIOC-ODR_ODR5   %1 5 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR5    Port output data y = 0..15
: GPIOC-ODR_ODR4   %1 4 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR4    Port output data y = 0..15
: GPIOC-ODR_ODR3   %1 3 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR3    Port output data y = 0..15
: GPIOC-ODR_ODR2   %1 2 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR2    Port output data y = 0..15
: GPIOC-ODR_ODR1   %1 1 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR1    Port output data y = 0..15
: GPIOC-ODR_ODR0   %1 0 lshift GPIOC-ODR bis! ;  \ GPIOC-ODR_ODR0    Port output data y = 0..15

\ GPIOC-BSRR (write-only)
: GPIOC-BSRR_BR15   %1 31 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR15    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR14   %1 30 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR14    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR13   %1 29 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR13    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR12   %1 28 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR12    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR11   %1 27 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR11    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR10   %1 26 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR10    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR9   %1 25 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR9    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR8   %1 24 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR8    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR7   %1 23 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR7    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR6   %1 22 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR6    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR5   %1 21 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR5    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR4   %1 20 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR4    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR3   %1 19 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR3    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR2   %1 18 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR2    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR1   %1 17 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR1    Port x reset bit y y = 0..15
: GPIOC-BSRR_BR0   %1 16 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BR0    Port x set bit y y= 0..15
: GPIOC-BSRR_BS15   %1 15 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS15    Port x set bit y y= 0..15
: GPIOC-BSRR_BS14   %1 14 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS14    Port x set bit y y= 0..15
: GPIOC-BSRR_BS13   %1 13 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS13    Port x set bit y y= 0..15
: GPIOC-BSRR_BS12   %1 12 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS12    Port x set bit y y= 0..15
: GPIOC-BSRR_BS11   %1 11 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS11    Port x set bit y y= 0..15
: GPIOC-BSRR_BS10   %1 10 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS10    Port x set bit y y= 0..15
: GPIOC-BSRR_BS9   %1 9 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS9    Port x set bit y y= 0..15
: GPIOC-BSRR_BS8   %1 8 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS8    Port x set bit y y= 0..15
: GPIOC-BSRR_BS7   %1 7 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS7    Port x set bit y y= 0..15
: GPIOC-BSRR_BS6   %1 6 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS6    Port x set bit y y= 0..15
: GPIOC-BSRR_BS5   %1 5 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS5    Port x set bit y y= 0..15
: GPIOC-BSRR_BS4   %1 4 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS4    Port x set bit y y= 0..15
: GPIOC-BSRR_BS3   %1 3 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS3    Port x set bit y y= 0..15
: GPIOC-BSRR_BS2   %1 2 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS2    Port x set bit y y= 0..15
: GPIOC-BSRR_BS1   %1 1 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS1    Port x set bit y y= 0..15
: GPIOC-BSRR_BS0   %1 0 lshift GPIOC-BSRR bis! ;  \ GPIOC-BSRR_BS0    Port x set bit y y= 0..15

\ GPIOC-LCKR (read-write)
: GPIOC-LCKR_LCKK   %1 16 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCKK    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK15   %1 15 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK15    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK14   %1 14 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK14    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK13   %1 13 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK13    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK12   %1 12 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK12    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK11   %1 11 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK11    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK10   %1 10 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK10    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK9   %1 9 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK9    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK8   %1 8 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK8    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK7   %1 7 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK7    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK6   %1 6 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK6    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK5   %1 5 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK5    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK4   %1 4 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK4    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK3   %1 3 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK3    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK2   %1 2 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK2    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK1   %1 1 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK1    Port x lock bit y y= 0..15
: GPIOC-LCKR_LCK0   %1 0 lshift GPIOC-LCKR bis! ;  \ GPIOC-LCKR_LCK0    Port x lock bit y y= 0..15

\ GPIOC-AFRL (read-write)
: GPIOC-AFRL_AFSEL7   ( %XXXX -- ) 28 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL7    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL6   ( %XXXX -- ) 24 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL6    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL5   ( %XXXX -- ) 20 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL5    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL4   ( %XXXX -- ) 16 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL4    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL3   ( %XXXX -- ) 12 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL3    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL2   ( %XXXX -- ) 8 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL2    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL1   ( %XXXX -- ) 4 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL1    Alternate function selection for port x bit y y = 0..7
: GPIOC-AFRL_AFSEL0   ( %XXXX -- ) 0 lshift GPIOC-AFRL bis! ;  \ GPIOC-AFRL_AFSEL0    Alternate function selection for port x bit y y = 0..7

\ GPIOC-AFRH (read-write)
: GPIOC-AFRH_AFSEL15   ( %XXXX -- ) 28 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL15    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL14   ( %XXXX -- ) 24 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL14    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL13   ( %XXXX -- ) 20 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL13    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL12   ( %XXXX -- ) 16 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL12    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL11   ( %XXXX -- ) 12 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL11    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL10   ( %XXXX -- ) 8 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL10    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL9   ( %XXXX -- ) 4 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL9    Alternate function selection for port x bit y y = 8..15
: GPIOC-AFRH_AFSEL8   ( %XXXX -- ) 0 lshift GPIOC-AFRH bis! ;  \ GPIOC-AFRH_AFSEL8    Alternate function selection for port x bit y y = 8..15

\ GPIOC-BRR (write-only)
: GPIOC-BRR_BR0   %1 0 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR0    Port Reset bit
: GPIOC-BRR_BR1   %1 1 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR1    Port Reset bit
: GPIOC-BRR_BR2   %1 2 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR2    Port Reset bit
: GPIOC-BRR_BR3   %1 3 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR3    Port Reset bit
: GPIOC-BRR_BR4   %1 4 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR4    Port Reset bit
: GPIOC-BRR_BR5   %1 5 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR5    Port Reset bit
: GPIOC-BRR_BR6   %1 6 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR6    Port Reset bit
: GPIOC-BRR_BR7   %1 7 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR7    Port Reset bit
: GPIOC-BRR_BR8   %1 8 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR8    Port Reset bit
: GPIOC-BRR_BR9   %1 9 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR9    Port Reset bit
: GPIOC-BRR_BR10   %1 10 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR10    Port Reset bit
: GPIOC-BRR_BR11   %1 11 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR11    Port Reset bit
: GPIOC-BRR_BR12   %1 12 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR12    Port Reset bit
: GPIOC-BRR_BR13   %1 13 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR13    Port Reset bit
: GPIOC-BRR_BR14   %1 14 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR14    Port Reset bit
: GPIOC-BRR_BR15   %1 15 lshift GPIOC-BRR bis! ;  \ GPIOC-BRR_BR15    Port Reset bit

\ GPIOD-MODER (read-write)
: GPIOD-MODER_MODER15   ( %XX -- ) 30 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER15    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER14   ( %XX -- ) 28 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER14    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER13   ( %XX -- ) 26 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER13    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER12   ( %XX -- ) 24 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER12    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER11   ( %XX -- ) 22 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER11    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER10   ( %XX -- ) 20 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER10    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER9   ( %XX -- ) 18 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER9    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER8   ( %XX -- ) 16 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER8    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER7   ( %XX -- ) 14 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER7    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER6   ( %XX -- ) 12 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER6    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER5   ( %XX -- ) 10 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER5    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER4   ( %XX -- ) 8 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER4    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER3   ( %XX -- ) 6 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER3    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER2   ( %XX -- ) 4 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER2    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER1   ( %XX -- ) 2 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER1    Port x configuration bits y = 0..15
: GPIOD-MODER_MODER0   ( %XX -- ) 0 lshift GPIOD-MODER bis! ;  \ GPIOD-MODER_MODER0    Port x configuration bits y = 0..15

\ GPIOD-OTYPER (read-write)
: GPIOD-OTYPER_OT15   %1 15 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT15    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT14   %1 14 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT14    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT13   %1 13 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT13    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT12   %1 12 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT12    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT11   %1 11 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT11    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT10   %1 10 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT10    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT9   %1 9 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT9    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT8   %1 8 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT8    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT7   %1 7 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT7    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT6   %1 6 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT6    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT5   %1 5 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT5    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT4   %1 4 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT4    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT3   %1 3 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT3    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT2   %1 2 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT2    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT1   %1 1 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT1    Port x configuration bits y = 0..15
: GPIOD-OTYPER_OT0   %1 0 lshift GPIOD-OTYPER bis! ;  \ GPIOD-OTYPER_OT0    Port x configuration bits y = 0..15

\ GPIOD-OSPEEDR (read-write)
: GPIOD-OSPEEDR_OSPEEDR15   ( %XX -- ) 30 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR15    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR14   ( %XX -- ) 28 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR14    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR13   ( %XX -- ) 26 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR13    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR12   ( %XX -- ) 24 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR12    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR11   ( %XX -- ) 22 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR11    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR10   ( %XX -- ) 20 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR10    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR9   ( %XX -- ) 18 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR9    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR8   ( %XX -- ) 16 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR8    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR7   ( %XX -- ) 14 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR7    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR6   ( %XX -- ) 12 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR6    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR5   ( %XX -- ) 10 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR5    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR4   ( %XX -- ) 8 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR4    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR3   ( %XX -- ) 6 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR3    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR2   ( %XX -- ) 4 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR2    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR1   ( %XX -- ) 2 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR1    Port x configuration bits y = 0..15
: GPIOD-OSPEEDR_OSPEEDR0   ( %XX -- ) 0 lshift GPIOD-OSPEEDR bis! ;  \ GPIOD-OSPEEDR_OSPEEDR0    Port x configuration bits y = 0..15

\ GPIOD-PUPDR (read-write)
: GPIOD-PUPDR_PUPDR15   ( %XX -- ) 30 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR15    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR14   ( %XX -- ) 28 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR14    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR13   ( %XX -- ) 26 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR13    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR12   ( %XX -- ) 24 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR12    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR11   ( %XX -- ) 22 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR11    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR10   ( %XX -- ) 20 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR10    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR9   ( %XX -- ) 18 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR9    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR8   ( %XX -- ) 16 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR8    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR7   ( %XX -- ) 14 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR7    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR6   ( %XX -- ) 12 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR6    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR5   ( %XX -- ) 10 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR5    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR4   ( %XX -- ) 8 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR4    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR3   ( %XX -- ) 6 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR3    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR2   ( %XX -- ) 4 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR2    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR1   ( %XX -- ) 2 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR1    Port x configuration bits y = 0..15
: GPIOD-PUPDR_PUPDR0   ( %XX -- ) 0 lshift GPIOD-PUPDR bis! ;  \ GPIOD-PUPDR_PUPDR0    Port x configuration bits y = 0..15

\ GPIOD-IDR (read-only)
: GPIOD-IDR_IDR15   %1 15 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR15    Port input data y = 0..15
: GPIOD-IDR_IDR14   %1 14 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR14    Port input data y = 0..15
: GPIOD-IDR_IDR13   %1 13 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR13    Port input data y = 0..15
: GPIOD-IDR_IDR12   %1 12 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR12    Port input data y = 0..15
: GPIOD-IDR_IDR11   %1 11 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR11    Port input data y = 0..15
: GPIOD-IDR_IDR10   %1 10 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR10    Port input data y = 0..15
: GPIOD-IDR_IDR9   %1 9 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR9    Port input data y = 0..15
: GPIOD-IDR_IDR8   %1 8 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR8    Port input data y = 0..15
: GPIOD-IDR_IDR7   %1 7 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR7    Port input data y = 0..15
: GPIOD-IDR_IDR6   %1 6 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR6    Port input data y = 0..15
: GPIOD-IDR_IDR5   %1 5 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR5    Port input data y = 0..15
: GPIOD-IDR_IDR4   %1 4 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR4    Port input data y = 0..15
: GPIOD-IDR_IDR3   %1 3 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR3    Port input data y = 0..15
: GPIOD-IDR_IDR2   %1 2 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR2    Port input data y = 0..15
: GPIOD-IDR_IDR1   %1 1 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR1    Port input data y = 0..15
: GPIOD-IDR_IDR0   %1 0 lshift GPIOD-IDR bis! ;  \ GPIOD-IDR_IDR0    Port input data y = 0..15

\ GPIOD-ODR (read-write)
: GPIOD-ODR_ODR15   %1 15 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR15    Port output data y = 0..15
: GPIOD-ODR_ODR14   %1 14 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR14    Port output data y = 0..15
: GPIOD-ODR_ODR13   %1 13 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR13    Port output data y = 0..15
: GPIOD-ODR_ODR12   %1 12 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR12    Port output data y = 0..15
: GPIOD-ODR_ODR11   %1 11 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR11    Port output data y = 0..15
: GPIOD-ODR_ODR10   %1 10 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR10    Port output data y = 0..15
: GPIOD-ODR_ODR9   %1 9 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR9    Port output data y = 0..15
: GPIOD-ODR_ODR8   %1 8 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR8    Port output data y = 0..15
: GPIOD-ODR_ODR7   %1 7 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR7    Port output data y = 0..15
: GPIOD-ODR_ODR6   %1 6 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR6    Port output data y = 0..15
: GPIOD-ODR_ODR5   %1 5 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR5    Port output data y = 0..15
: GPIOD-ODR_ODR4   %1 4 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR4    Port output data y = 0..15
: GPIOD-ODR_ODR3   %1 3 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR3    Port output data y = 0..15
: GPIOD-ODR_ODR2   %1 2 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR2    Port output data y = 0..15
: GPIOD-ODR_ODR1   %1 1 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR1    Port output data y = 0..15
: GPIOD-ODR_ODR0   %1 0 lshift GPIOD-ODR bis! ;  \ GPIOD-ODR_ODR0    Port output data y = 0..15

\ GPIOD-BSRR (write-only)
: GPIOD-BSRR_BR15   %1 31 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR15    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR14   %1 30 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR14    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR13   %1 29 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR13    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR12   %1 28 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR12    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR11   %1 27 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR11    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR10   %1 26 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR10    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR9   %1 25 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR9    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR8   %1 24 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR8    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR7   %1 23 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR7    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR6   %1 22 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR6    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR5   %1 21 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR5    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR4   %1 20 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR4    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR3   %1 19 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR3    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR2   %1 18 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR2    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR1   %1 17 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR1    Port x reset bit y y = 0..15
: GPIOD-BSRR_BR0   %1 16 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BR0    Port x set bit y y= 0..15
: GPIOD-BSRR_BS15   %1 15 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS15    Port x set bit y y= 0..15
: GPIOD-BSRR_BS14   %1 14 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS14    Port x set bit y y= 0..15
: GPIOD-BSRR_BS13   %1 13 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS13    Port x set bit y y= 0..15
: GPIOD-BSRR_BS12   %1 12 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS12    Port x set bit y y= 0..15
: GPIOD-BSRR_BS11   %1 11 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS11    Port x set bit y y= 0..15
: GPIOD-BSRR_BS10   %1 10 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS10    Port x set bit y y= 0..15
: GPIOD-BSRR_BS9   %1 9 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS9    Port x set bit y y= 0..15
: GPIOD-BSRR_BS8   %1 8 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS8    Port x set bit y y= 0..15
: GPIOD-BSRR_BS7   %1 7 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS7    Port x set bit y y= 0..15
: GPIOD-BSRR_BS6   %1 6 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS6    Port x set bit y y= 0..15
: GPIOD-BSRR_BS5   %1 5 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS5    Port x set bit y y= 0..15
: GPIOD-BSRR_BS4   %1 4 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS4    Port x set bit y y= 0..15
: GPIOD-BSRR_BS3   %1 3 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS3    Port x set bit y y= 0..15
: GPIOD-BSRR_BS2   %1 2 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS2    Port x set bit y y= 0..15
: GPIOD-BSRR_BS1   %1 1 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS1    Port x set bit y y= 0..15
: GPIOD-BSRR_BS0   %1 0 lshift GPIOD-BSRR bis! ;  \ GPIOD-BSRR_BS0    Port x set bit y y= 0..15

\ GPIOD-LCKR (read-write)
: GPIOD-LCKR_LCKK   %1 16 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCKK    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK15   %1 15 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK15    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK14   %1 14 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK14    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK13   %1 13 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK13    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK12   %1 12 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK12    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK11   %1 11 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK11    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK10   %1 10 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK10    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK9   %1 9 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK9    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK8   %1 8 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK8    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK7   %1 7 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK7    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK6   %1 6 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK6    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK5   %1 5 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK5    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK4   %1 4 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK4    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK3   %1 3 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK3    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK2   %1 2 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK2    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK1   %1 1 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK1    Port x lock bit y y= 0..15
: GPIOD-LCKR_LCK0   %1 0 lshift GPIOD-LCKR bis! ;  \ GPIOD-LCKR_LCK0    Port x lock bit y y= 0..15

\ GPIOD-AFRL (read-write)
: GPIOD-AFRL_AFSEL7   ( %XXXX -- ) 28 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL7    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL6   ( %XXXX -- ) 24 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL6    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL5   ( %XXXX -- ) 20 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL5    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL4   ( %XXXX -- ) 16 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL4    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL3   ( %XXXX -- ) 12 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL3    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL2   ( %XXXX -- ) 8 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL2    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL1   ( %XXXX -- ) 4 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL1    Alternate function selection for port x bit y y = 0..7
: GPIOD-AFRL_AFSEL0   ( %XXXX -- ) 0 lshift GPIOD-AFRL bis! ;  \ GPIOD-AFRL_AFSEL0    Alternate function selection for port x bit y y = 0..7

\ GPIOD-AFRH (read-write)
: GPIOD-AFRH_AFSEL15   ( %XXXX -- ) 28 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL15    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL14   ( %XXXX -- ) 24 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL14    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL13   ( %XXXX -- ) 20 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL13    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL12   ( %XXXX -- ) 16 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL12    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL11   ( %XXXX -- ) 12 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL11    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL10   ( %XXXX -- ) 8 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL10    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL9   ( %XXXX -- ) 4 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL9    Alternate function selection for port x bit y y = 8..15
: GPIOD-AFRH_AFSEL8   ( %XXXX -- ) 0 lshift GPIOD-AFRH bis! ;  \ GPIOD-AFRH_AFSEL8    Alternate function selection for port x bit y y = 8..15

\ GPIOD-BRR (write-only)
: GPIOD-BRR_BR0   %1 0 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR0    Port Reset bit
: GPIOD-BRR_BR1   %1 1 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR1    Port Reset bit
: GPIOD-BRR_BR2   %1 2 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR2    Port Reset bit
: GPIOD-BRR_BR3   %1 3 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR3    Port Reset bit
: GPIOD-BRR_BR4   %1 4 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR4    Port Reset bit
: GPIOD-BRR_BR5   %1 5 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR5    Port Reset bit
: GPIOD-BRR_BR6   %1 6 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR6    Port Reset bit
: GPIOD-BRR_BR7   %1 7 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR7    Port Reset bit
: GPIOD-BRR_BR8   %1 8 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR8    Port Reset bit
: GPIOD-BRR_BR9   %1 9 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR9    Port Reset bit
: GPIOD-BRR_BR10   %1 10 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR10    Port Reset bit
: GPIOD-BRR_BR11   %1 11 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR11    Port Reset bit
: GPIOD-BRR_BR12   %1 12 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR12    Port Reset bit
: GPIOD-BRR_BR13   %1 13 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR13    Port Reset bit
: GPIOD-BRR_BR14   %1 14 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR14    Port Reset bit
: GPIOD-BRR_BR15   %1 15 lshift GPIOD-BRR bis! ;  \ GPIOD-BRR_BR15    Port Reset bit

\ GPIOE-MODER (read-write)
: GPIOE-MODER_MODER4   ( %XX -- ) 8 lshift GPIOE-MODER bis! ;  \ GPIOE-MODER_MODER4    Port x configuration bits y = 0..15
: GPIOE-MODER_MODER3   ( %XX -- ) 6 lshift GPIOE-MODER bis! ;  \ GPIOE-MODER_MODER3    Port x configuration bits y = 0..15
: GPIOE-MODER_MODER2   ( %XX -- ) 4 lshift GPIOE-MODER bis! ;  \ GPIOE-MODER_MODER2    Port x configuration bits y = 0..15
: GPIOE-MODER_MODER1   ( %XX -- ) 2 lshift GPIOE-MODER bis! ;  \ GPIOE-MODER_MODER1    Port x configuration bits y = 0..15
: GPIOE-MODER_MODER0   ( %XX -- ) 0 lshift GPIOE-MODER bis! ;  \ GPIOE-MODER_MODER0    Port x configuration bits y = 0..15

\ GPIOE-OTYPER (read-write)
: GPIOE-OTYPER_OT4   %1 4 lshift GPIOE-OTYPER bis! ;  \ GPIOE-OTYPER_OT4    Port x configuration bits y = 0..15
: GPIOE-OTYPER_OT3   %1 3 lshift GPIOE-OTYPER bis! ;  \ GPIOE-OTYPER_OT3    Port x configuration bits y = 0..15
: GPIOE-OTYPER_OT2   %1 2 lshift GPIOE-OTYPER bis! ;  \ GPIOE-OTYPER_OT2    Port x configuration bits y = 0..15
: GPIOE-OTYPER_OT1   %1 1 lshift GPIOE-OTYPER bis! ;  \ GPIOE-OTYPER_OT1    Port x configuration bits y = 0..15
: GPIOE-OTYPER_OT0   %1 0 lshift GPIOE-OTYPER bis! ;  \ GPIOE-OTYPER_OT0    Port x configuration bits y = 0..15

\ GPIOE-OSPEEDR (read-write)
: GPIOE-OSPEEDR_OSPEEDR4   ( %XX -- ) 8 lshift GPIOE-OSPEEDR bis! ;  \ GPIOE-OSPEEDR_OSPEEDR4    Port x configuration bits y = 0..15
: GPIOE-OSPEEDR_OSPEEDR3   ( %XX -- ) 6 lshift GPIOE-OSPEEDR bis! ;  \ GPIOE-OSPEEDR_OSPEEDR3    Port x configuration bits y = 0..15
: GPIOE-OSPEEDR_OSPEEDR2   ( %XX -- ) 4 lshift GPIOE-OSPEEDR bis! ;  \ GPIOE-OSPEEDR_OSPEEDR2    Port x configuration bits y = 0..15
: GPIOE-OSPEEDR_OSPEEDR1   ( %XX -- ) 2 lshift GPIOE-OSPEEDR bis! ;  \ GPIOE-OSPEEDR_OSPEEDR1    Port x configuration bits y = 0..15
: GPIOE-OSPEEDR_OSPEEDR0   ( %XX -- ) 0 lshift GPIOE-OSPEEDR bis! ;  \ GPIOE-OSPEEDR_OSPEEDR0    Port x configuration bits y = 0..15

\ GPIOE-PUPDR (read-write)
: GPIOE-PUPDR_PUPDR4   ( %XX -- ) 8 lshift GPIOE-PUPDR bis! ;  \ GPIOE-PUPDR_PUPDR4    Port x configuration bits y = 0..15
: GPIOE-PUPDR_PUPDR3   ( %XX -- ) 6 lshift GPIOE-PUPDR bis! ;  \ GPIOE-PUPDR_PUPDR3    Port x configuration bits y = 0..15
: GPIOE-PUPDR_PUPDR2   ( %XX -- ) 4 lshift GPIOE-PUPDR bis! ;  \ GPIOE-PUPDR_PUPDR2    Port x configuration bits y = 0..15
: GPIOE-PUPDR_PUPDR1   ( %XX -- ) 2 lshift GPIOE-PUPDR bis! ;  \ GPIOE-PUPDR_PUPDR1    Port x configuration bits y = 0..15
: GPIOE-PUPDR_PUPDR0   ( %XX -- ) 0 lshift GPIOE-PUPDR bis! ;  \ GPIOE-PUPDR_PUPDR0    Port x configuration bits y = 0..15

\ GPIOE-IDR (read-only)
: GPIOE-IDR_IDR4   %1 4 lshift GPIOE-IDR bis! ;  \ GPIOE-IDR_IDR4    Port input data y = 0..15
: GPIOE-IDR_IDR3   %1 3 lshift GPIOE-IDR bis! ;  \ GPIOE-IDR_IDR3    Port input data y = 0..15
: GPIOE-IDR_IDR2   %1 2 lshift GPIOE-IDR bis! ;  \ GPIOE-IDR_IDR2    Port input data y = 0..15
: GPIOE-IDR_IDR1   %1 1 lshift GPIOE-IDR bis! ;  \ GPIOE-IDR_IDR1    Port input data y = 0..15
: GPIOE-IDR_IDR0   %1 0 lshift GPIOE-IDR bis! ;  \ GPIOE-IDR_IDR0    Port input data y = 0..15

\ GPIOE-ODR (read-write)
: GPIOE-ODR_ODR4   %1 4 lshift GPIOE-ODR bis! ;  \ GPIOE-ODR_ODR4    Port output data y = 0..15
: GPIOE-ODR_ODR3   %1 3 lshift GPIOE-ODR bis! ;  \ GPIOE-ODR_ODR3    Port output data y = 0..15
: GPIOE-ODR_ODR2   %1 2 lshift GPIOE-ODR bis! ;  \ GPIOE-ODR_ODR2    Port output data y = 0..15
: GPIOE-ODR_ODR1   %1 1 lshift GPIOE-ODR bis! ;  \ GPIOE-ODR_ODR1    Port output data y = 0..15
: GPIOE-ODR_ODR0   %1 0 lshift GPIOE-ODR bis! ;  \ GPIOE-ODR_ODR0    Port output data y = 0..15

\ GPIOE-BSRR (write-only)
: GPIOE-BSRR_BR4   %1 20 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BR4    Port x reset bit y y = 0..15
: GPIOE-BSRR_BR3   %1 19 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BR3    Port x reset bit y y = 0..15
: GPIOE-BSRR_BR2   %1 18 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BR2    Port x reset bit y y = 0..15
: GPIOE-BSRR_BR1   %1 17 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BR1    Port x reset bit y y = 0..15
: GPIOE-BSRR_BR0   %1 16 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BR0    Port x set bit y y= 0..15
: GPIOE-BSRR_BS4   %1 4 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BS4    Port x set bit y y= 0..15
: GPIOE-BSRR_BS3   %1 3 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BS3    Port x set bit y y= 0..15
: GPIOE-BSRR_BS2   %1 2 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BS2    Port x set bit y y= 0..15
: GPIOE-BSRR_BS1   %1 1 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BS1    Port x set bit y y= 0..15
: GPIOE-BSRR_BS0   %1 0 lshift GPIOE-BSRR bis! ;  \ GPIOE-BSRR_BS0    Port x set bit y y= 0..15

\ GPIOE-LCKR (read-write)
: GPIOE-LCKR_LCKK   %1 16 lshift GPIOE-LCKR bis! ;  \ GPIOE-LCKR_LCKK    Port x lock bit y y= 0..15
: GPIOE-LCKR_LCK4   %1 4 lshift GPIOE-LCKR bis! ;  \ GPIOE-LCKR_LCK4    Port x lock bit y y= 0..15
: GPIOE-LCKR_LCK3   %1 3 lshift GPIOE-LCKR bis! ;  \ GPIOE-LCKR_LCK3    Port x lock bit y y= 0..15
: GPIOE-LCKR_LCK2   %1 2 lshift GPIOE-LCKR bis! ;  \ GPIOE-LCKR_LCK2    Port x lock bit y y= 0..15
: GPIOE-LCKR_LCK1   %1 1 lshift GPIOE-LCKR bis! ;  \ GPIOE-LCKR_LCK1    Port x lock bit y y= 0..15
: GPIOE-LCKR_LCK0   %1 0 lshift GPIOE-LCKR bis! ;  \ GPIOE-LCKR_LCK0    Port x lock bit y y= 0..15

\ GPIOE-AFRL (read-write)
: GPIOE-AFRL_AFSEL4   ( %XXXX -- ) 16 lshift GPIOE-AFRL bis! ;  \ GPIOE-AFRL_AFSEL4    Alternate function selection for port x bit y y = 0..7
: GPIOE-AFRL_AFSEL3   ( %XXXX -- ) 12 lshift GPIOE-AFRL bis! ;  \ GPIOE-AFRL_AFSEL3    Alternate function selection for port x bit y y = 0..7
: GPIOE-AFRL_AFSEL2   ( %XXXX -- ) 8 lshift GPIOE-AFRL bis! ;  \ GPIOE-AFRL_AFSEL2    Alternate function selection for port x bit y y = 0..7
: GPIOE-AFRL_AFSEL1   ( %XXXX -- ) 4 lshift GPIOE-AFRL bis! ;  \ GPIOE-AFRL_AFSEL1    Alternate function selection for port x bit y y = 0..7
: GPIOE-AFRL_AFSEL0   ( %XXXX -- ) 0 lshift GPIOE-AFRL bis! ;  \ GPIOE-AFRL_AFSEL0    Alternate function selection for port x bit y y = 0..7

\ GPIOE-AFRH (read-write)
: GPIOE-AFRH_AFSEL15   ( %XXXX -- ) 28 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL15    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL14   ( %XXXX -- ) 24 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL14    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL13   ( %XXXX -- ) 20 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL13    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL12   ( %XXXX -- ) 16 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL12    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL11   ( %XXXX -- ) 12 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL11    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL10   ( %XXXX -- ) 8 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL10    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL9   ( %XXXX -- ) 4 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL9    Alternate function selection for port x bit y y = 8..15
: GPIOE-AFRH_AFSEL8   ( %XXXX -- ) 0 lshift GPIOE-AFRH bis! ;  \ GPIOE-AFRH_AFSEL8    Alternate function selection for port x bit y y = 8..15

\ GPIOE-BRR (write-only)
: GPIOE-BRR_BR0   %1 0 lshift GPIOE-BRR bis! ;  \ GPIOE-BRR_BR0    Port Reset bit
: GPIOE-BRR_BR1   %1 1 lshift GPIOE-BRR bis! ;  \ GPIOE-BRR_BR1    Port Reset bit
: GPIOE-BRR_BR2   %1 2 lshift GPIOE-BRR bis! ;  \ GPIOE-BRR_BR2    Port Reset bit
: GPIOE-BRR_BR3   %1 3 lshift GPIOE-BRR bis! ;  \ GPIOE-BRR_BR3    Port Reset bit
: GPIOE-BRR_BR4   %1 4 lshift GPIOE-BRR bis! ;  \ GPIOE-BRR_BR4    Port Reset bit

\ GPIOH-MODER (read-write)
: GPIOH-MODER_MODER3   ( %XX -- ) 6 lshift GPIOH-MODER bis! ;  \ GPIOH-MODER_MODER3    Port x configuration bits y = 0..15
: GPIOH-MODER_MODER1   ( %XX -- ) 2 lshift GPIOH-MODER bis! ;  \ GPIOH-MODER_MODER1    Port x configuration bits y = 0..15
: GPIOH-MODER_MODER0   ( %XX -- ) 0 lshift GPIOH-MODER bis! ;  \ GPIOH-MODER_MODER0    Port x configuration bits y = 0..15

\ GPIOH-OTYPER (read-write)
: GPIOH-OTYPER_OT3   %1 3 lshift GPIOH-OTYPER bis! ;  \ GPIOH-OTYPER_OT3    Port x configuration bits y = 0..15
: GPIOH-OTYPER_OT1   %1 1 lshift GPIOH-OTYPER bis! ;  \ GPIOH-OTYPER_OT1    Port x configuration bits y = 0..15
: GPIOH-OTYPER_OT0   %1 0 lshift GPIOH-OTYPER bis! ;  \ GPIOH-OTYPER_OT0    Port x configuration bits y = 0..15

\ GPIOH-OSPEEDR (read-write)
: GPIOH-OSPEEDR_OSPEEDR3   ( %XX -- ) 6 lshift GPIOH-OSPEEDR bis! ;  \ GPIOH-OSPEEDR_OSPEEDR3    Port x configuration bits y = 0..15
: GPIOH-OSPEEDR_OSPEEDR1   ( %XX -- ) 2 lshift GPIOH-OSPEEDR bis! ;  \ GPIOH-OSPEEDR_OSPEEDR1    Port x configuration bits y = 0..15
: GPIOH-OSPEEDR_OSPEEDR0   ( %XX -- ) 0 lshift GPIOH-OSPEEDR bis! ;  \ GPIOH-OSPEEDR_OSPEEDR0    Port x configuration bits y = 0..15

\ GPIOH-PUPDR (read-write)
: GPIOH-PUPDR_PUPDR3   ( %XX -- ) 6 lshift GPIOH-PUPDR bis! ;  \ GPIOH-PUPDR_PUPDR3    Port x configuration bits y = 0..15
: GPIOH-PUPDR_PUPDR1   ( %XX -- ) 2 lshift GPIOH-PUPDR bis! ;  \ GPIOH-PUPDR_PUPDR1    Port x configuration bits y = 0..15
: GPIOH-PUPDR_PUPDR0   ( %XX -- ) 0 lshift GPIOH-PUPDR bis! ;  \ GPIOH-PUPDR_PUPDR0    Port x configuration bits y = 0..15

\ GPIOH-IDR (read-only)
: GPIOH-IDR_IDR3   %1 3 lshift GPIOH-IDR bis! ;  \ GPIOH-IDR_IDR3    Port input data y = 0..15
: GPIOH-IDR_IDR1   %1 1 lshift GPIOH-IDR bis! ;  \ GPIOH-IDR_IDR1    Port input data y = 0..15
: GPIOH-IDR_IDR0   %1 0 lshift GPIOH-IDR bis! ;  \ GPIOH-IDR_IDR0    Port input data y = 0..15

\ GPIOH-ODR (read-write)
: GPIOH-ODR_ODR3   %1 3 lshift GPIOH-ODR bis! ;  \ GPIOH-ODR_ODR3    Port output data y = 0..15
: GPIOH-ODR_ODR1   %1 1 lshift GPIOH-ODR bis! ;  \ GPIOH-ODR_ODR1    Port output data y = 0..15
: GPIOH-ODR_ODR0   %1 0 lshift GPIOH-ODR bis! ;  \ GPIOH-ODR_ODR0    Port output data y = 0..15

\ GPIOH-BSRR (write-only)
: GPIOH-BSRR_BR3   %1 19 lshift GPIOH-BSRR bis! ;  \ GPIOH-BSRR_BR3    Port x reset bit y y = 0..15
: GPIOH-BSRR_BR1   %1 17 lshift GPIOH-BSRR bis! ;  \ GPIOH-BSRR_BR1    Port x reset bit y y = 0..15
: GPIOH-BSRR_BR0   %1 16 lshift GPIOH-BSRR bis! ;  \ GPIOH-BSRR_BR0    Port x set bit y y= 0..15
: GPIOH-BSRR_BS3   %1 3 lshift GPIOH-BSRR bis! ;  \ GPIOH-BSRR_BS3    Port x set bit y y= 0..15
: GPIOH-BSRR_BS1   %1 1 lshift GPIOH-BSRR bis! ;  \ GPIOH-BSRR_BS1    Port x set bit y y= 0..15
: GPIOH-BSRR_BS0   %1 0 lshift GPIOH-BSRR bis! ;  \ GPIOH-BSRR_BS0    Port x set bit y y= 0..15

\ GPIOH-LCKR (read-write)
: GPIOH-LCKR_LCKK   %1 16 lshift GPIOH-LCKR bis! ;  \ GPIOH-LCKR_LCKK    Port x lock bit y y= 0..15
: GPIOH-LCKR_LCK3   %1 3 lshift GPIOH-LCKR bis! ;  \ GPIOH-LCKR_LCK3    Port x lock bit y y= 0..15
: GPIOH-LCKR_LCK1   %1 1 lshift GPIOH-LCKR bis! ;  \ GPIOH-LCKR_LCK1    Port x lock bit y y= 0..15
: GPIOH-LCKR_LCK0   %1 0 lshift GPIOH-LCKR bis! ;  \ GPIOH-LCKR_LCK0    Port x lock bit y y= 0..15

\ GPIOH-AFRL (read-write)
: GPIOH-AFRL_AFSEL3   ( %XXXX -- ) 12 lshift GPIOH-AFRL bis! ;  \ GPIOH-AFRL_AFSEL3    Alternate function selection for port x bit y y = 0..7
: GPIOH-AFRL_AFSEL1   ( %XXXX -- ) 4 lshift GPIOH-AFRL bis! ;  \ GPIOH-AFRL_AFSEL1    Alternate function selection for port x bit y y = 0..7
: GPIOH-AFRL_AFSEL0   ( %XXXX -- ) 0 lshift GPIOH-AFRL bis! ;  \ GPIOH-AFRL_AFSEL0    Alternate function selection for port x bit y y = 0..7

\ GPIOH-AFRH (read-write)
: GPIOH-AFRH_AFSEL15   ( %XXXX -- ) 28 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL15    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL14   ( %XXXX -- ) 24 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL14    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL13   ( %XXXX -- ) 20 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL13    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL12   ( %XXXX -- ) 16 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL12    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL11   ( %XXXX -- ) 12 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL11    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL10   ( %XXXX -- ) 8 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL10    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL9   ( %XXXX -- ) 4 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL9    Alternate function selection for port x bit y y = 8..15
: GPIOH-AFRH_AFSEL8   ( %XXXX -- ) 0 lshift GPIOH-AFRH bis! ;  \ GPIOH-AFRH_AFSEL8    Alternate function selection for port x bit y y = 8..15

\ GPIOH-BRR (write-only)
: GPIOH-BRR_BR0   %1 0 lshift GPIOH-BRR bis! ;  \ GPIOH-BRR_BR0    Port Reset bit
: GPIOH-BRR_BR1   %1 1 lshift GPIOH-BRR bis! ;  \ GPIOH-BRR_BR1    Port Reset bit
: GPIOH-BRR_BR3   %1 3 lshift GPIOH-BRR bis! ;  \ GPIOH-BRR_BR3    Port Reset bit

\ SAI1-GCR (read-write)
: SAI1-GCR_SYNCOUT   ( %XX -- ) 4 lshift SAI1-GCR bis! ;  \ SAI1-GCR_SYNCOUT    Synchronization outputs
: SAI1-GCR_SYNCIN   ( %XX -- ) 0 lshift SAI1-GCR bis! ;  \ SAI1-GCR_SYNCIN    Synchronization inputs

\ SAI1-BCR1 (read-write)
: SAI1-BCR1_MCKEN   %1 27 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_MCKEN    Master clock generation enable
: SAI1-BCR1_OSR   %1 26 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_OSR    Oversampling ratio for master clock
: SAI1-BCR1_MCJDIV   ( %XXXXXX -- ) 20 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_MCJDIV    Master clock divider
: SAI1-BCR1_NODIV   %1 19 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_NODIV    No divider
: SAI1-BCR1_DMAEN   %1 17 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_DMAEN    DMA enable
: SAI1-BCR1_SAIBEN   %1 16 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_SAIBEN    Audio block B enable
: SAI1-BCR1_OutDri   %1 13 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_OutDri    Output drive
: SAI1-BCR1_MONO   %1 12 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_MONO    Mono mode
: SAI1-BCR1_SYNCEN   ( %XX -- ) 10 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_SYNCEN    Synchronization enable
: SAI1-BCR1_CKSTR   %1 9 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_CKSTR    Clock strobing edge
: SAI1-BCR1_LSBFIRST   %1 8 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_LSBFIRST    Least significant bit first
: SAI1-BCR1_DS   ( %XXX -- ) 5 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_DS    Data size
: SAI1-BCR1_PRTCFG   ( %XX -- ) 2 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_PRTCFG    Protocol configuration
: SAI1-BCR1_MODE   ( %XX -- ) 0 lshift SAI1-BCR1 bis! ;  \ SAI1-BCR1_MODE    Audio block mode

\ SAI1-BCR2 (read-write)
: SAI1-BCR2_COMP   ( %XX -- ) 14 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_COMP    Companding mode
: SAI1-BCR2_CPL   %1 13 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_CPL    Complement bit
: SAI1-BCR2_MUTECN   ( %XXXXXX -- ) 7 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_MUTECN    Mute counter
: SAI1-BCR2_MUTEVAL   %1 6 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_MUTEVAL    Mute value
: SAI1-BCR2_MUTE   %1 5 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_MUTE    Mute
: SAI1-BCR2_TRIS   %1 4 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_TRIS    Tristate management on data line
: SAI1-BCR2_FFLUS   %1 3 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_FFLUS    FIFO flush
: SAI1-BCR2_FTH   ( %XXX -- ) 0 lshift SAI1-BCR2 bis! ;  \ SAI1-BCR2_FTH    FIFO threshold

\ SAI1-BFRCR (read-write)
: SAI1-BFRCR_FSOFF   %1 18 lshift SAI1-BFRCR bis! ;  \ SAI1-BFRCR_FSOFF    Frame synchronization offset
: SAI1-BFRCR_FSPOL   %1 17 lshift SAI1-BFRCR bis! ;  \ SAI1-BFRCR_FSPOL    Frame synchronization polarity
: SAI1-BFRCR_FSDEF   %1 16 lshift SAI1-BFRCR bis! ;  \ SAI1-BFRCR_FSDEF    Frame synchronization definition
: SAI1-BFRCR_FSALL   ( %XXXXXXX -- ) 8 lshift SAI1-BFRCR bis! ;  \ SAI1-BFRCR_FSALL    Frame synchronization active level length
: SAI1-BFRCR_FRL   ( %XXXXXXXX -- ) 0 lshift SAI1-BFRCR bis! ;  \ SAI1-BFRCR_FRL    Frame length

\ SAI1-BSLOTR (read-write)
: SAI1-BSLOTR_SLOTEN   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift SAI1-BSLOTR bis! ;  \ SAI1-BSLOTR_SLOTEN    Slot enable
: SAI1-BSLOTR_NBSLOT   ( %XXXX -- ) 8 lshift SAI1-BSLOTR bis! ;  \ SAI1-BSLOTR_NBSLOT    Number of slots in an audio frame
: SAI1-BSLOTR_SLOTSZ   ( %XX -- ) 6 lshift SAI1-BSLOTR bis! ;  \ SAI1-BSLOTR_SLOTSZ    Slot size
: SAI1-BSLOTR_FBOFF   ( %XXXXX -- ) 0 lshift SAI1-BSLOTR bis! ;  \ SAI1-BSLOTR_FBOFF    First bit offset

\ SAI1-BIM (read-write)
: SAI1-BIM_LFSDETIE   %1 6 lshift SAI1-BIM bis! ;  \ SAI1-BIM_LFSDETIE    Late frame synchronization detection interrupt enable
: SAI1-BIM_AFSDETIE   %1 5 lshift SAI1-BIM bis! ;  \ SAI1-BIM_AFSDETIE    Anticipated frame synchronization detection interrupt enable
: SAI1-BIM_CNRDYIE   %1 4 lshift SAI1-BIM bis! ;  \ SAI1-BIM_CNRDYIE    Codec not ready interrupt enable
: SAI1-BIM_FREQIE   %1 3 lshift SAI1-BIM bis! ;  \ SAI1-BIM_FREQIE    FIFO request interrupt enable
: SAI1-BIM_WCKCFG   %1 2 lshift SAI1-BIM bis! ;  \ SAI1-BIM_WCKCFG    Wrong clock configuration interrupt enable
: SAI1-BIM_MUTEDET   %1 1 lshift SAI1-BIM bis! ;  \ SAI1-BIM_MUTEDET    Mute detection interrupt enable
: SAI1-BIM_OVRUDRIE   %1 0 lshift SAI1-BIM bis! ;  \ SAI1-BIM_OVRUDRIE    Overrun/underrun interrupt enable

\ SAI1-BSR (read-only)
: SAI1-BSR_FLVL   ( %XXX -- ) 16 lshift SAI1-BSR bis! ;  \ SAI1-BSR_FLVL    FIFO level threshold
: SAI1-BSR_LFSDET   %1 6 lshift SAI1-BSR bis! ;  \ SAI1-BSR_LFSDET    Late frame synchronization detection
: SAI1-BSR_AFSDET   %1 5 lshift SAI1-BSR bis! ;  \ SAI1-BSR_AFSDET    Anticipated frame synchronization detection
: SAI1-BSR_CNRDY   %1 4 lshift SAI1-BSR bis! ;  \ SAI1-BSR_CNRDY    Codec not ready
: SAI1-BSR_FREQ   %1 3 lshift SAI1-BSR bis! ;  \ SAI1-BSR_FREQ    FIFO request
: SAI1-BSR_WCKCFG   %1 2 lshift SAI1-BSR bis! ;  \ SAI1-BSR_WCKCFG    Wrong clock configuration flag
: SAI1-BSR_MUTEDET   %1 1 lshift SAI1-BSR bis! ;  \ SAI1-BSR_MUTEDET    Mute detection
: SAI1-BSR_OVRUDR   %1 0 lshift SAI1-BSR bis! ;  \ SAI1-BSR_OVRUDR    Overrun / underrun

\ SAI1-BCLRFR (write-only)
: SAI1-BCLRFR_LFSDET   %1 6 lshift SAI1-BCLRFR bis! ;  \ SAI1-BCLRFR_LFSDET    Clear late frame synchronization detection flag
: SAI1-BCLRFR_CAFSDET   %1 5 lshift SAI1-BCLRFR bis! ;  \ SAI1-BCLRFR_CAFSDET    Clear anticipated frame synchronization detection flag
: SAI1-BCLRFR_CNRDY   %1 4 lshift SAI1-BCLRFR bis! ;  \ SAI1-BCLRFR_CNRDY    Clear codec not ready flag
: SAI1-BCLRFR_WCKCFG   %1 2 lshift SAI1-BCLRFR bis! ;  \ SAI1-BCLRFR_WCKCFG    Clear wrong clock configuration flag
: SAI1-BCLRFR_MUTEDET   %1 1 lshift SAI1-BCLRFR bis! ;  \ SAI1-BCLRFR_MUTEDET    Mute detection flag
: SAI1-BCLRFR_OVRUDR   %1 0 lshift SAI1-BCLRFR bis! ;  \ SAI1-BCLRFR_OVRUDR    Clear overrun / underrun

\ SAI1-BDR (read-write)
: SAI1-BDR_DATA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift SAI1-BDR bis! ;  \ SAI1-BDR_DATA    Data

\ SAI1-ACR1 (read-write)
: SAI1-ACR1_MCKEN   %1 27 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_MCKEN    Master clock generation enable
: SAI1-ACR1_OSR   %1 26 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_OSR    Oversampling ratio for master clock
: SAI1-ACR1_MCJDIV   ( %XXXXXX -- ) 20 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_MCJDIV    Master clock divider
: SAI1-ACR1_NODIV   %1 19 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_NODIV    No divider
: SAI1-ACR1_DMAEN   %1 17 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_DMAEN    DMA enable
: SAI1-ACR1_SAIBEN   %1 16 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_SAIBEN    Audio block B enable
: SAI1-ACR1_OutDri   %1 13 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_OutDri    Output drive
: SAI1-ACR1_MONO   %1 12 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_MONO    Mono mode
: SAI1-ACR1_SYNCEN   ( %XX -- ) 10 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_SYNCEN    Synchronization enable
: SAI1-ACR1_CKSTR   %1 9 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_CKSTR    Clock strobing edge
: SAI1-ACR1_LSBFIRST   %1 8 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_LSBFIRST    Least significant bit first
: SAI1-ACR1_DS   ( %XXX -- ) 5 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_DS    Data size
: SAI1-ACR1_PRTCFG   ( %XX -- ) 2 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_PRTCFG    Protocol configuration
: SAI1-ACR1_MODE   ( %XX -- ) 0 lshift SAI1-ACR1 bis! ;  \ SAI1-ACR1_MODE    Audio block mode

\ SAI1-ACR2 (read-write)
: SAI1-ACR2_COMP   ( %XX -- ) 14 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_COMP    Companding mode
: SAI1-ACR2_CPL   %1 13 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_CPL    Complement bit
: SAI1-ACR2_MUTECN   ( %XXXXXX -- ) 7 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_MUTECN    Mute counter
: SAI1-ACR2_MUTEVAL   %1 6 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_MUTEVAL    Mute value
: SAI1-ACR2_MUTE   %1 5 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_MUTE    Mute
: SAI1-ACR2_TRIS   %1 4 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_TRIS    Tristate management on data line
: SAI1-ACR2_FFLUS   %1 3 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_FFLUS    FIFO flush
: SAI1-ACR2_FTH   ( %XXX -- ) 0 lshift SAI1-ACR2 bis! ;  \ SAI1-ACR2_FTH    FIFO threshold

\ SAI1-AFRCR (read-write)
: SAI1-AFRCR_FSOFF   %1 18 lshift SAI1-AFRCR bis! ;  \ SAI1-AFRCR_FSOFF    Frame synchronization offset
: SAI1-AFRCR_FSPOL   %1 17 lshift SAI1-AFRCR bis! ;  \ SAI1-AFRCR_FSPOL    Frame synchronization polarity
: SAI1-AFRCR_FSDEF   %1 16 lshift SAI1-AFRCR bis! ;  \ SAI1-AFRCR_FSDEF    Frame synchronization definition
: SAI1-AFRCR_FSALL   ( %XXXXXXX -- ) 8 lshift SAI1-AFRCR bis! ;  \ SAI1-AFRCR_FSALL    Frame synchronization active level length
: SAI1-AFRCR_FRL   ( %XXXXXXXX -- ) 0 lshift SAI1-AFRCR bis! ;  \ SAI1-AFRCR_FRL    Frame length

\ SAI1-ASLOTR (read-write)
: SAI1-ASLOTR_SLOTEN   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift SAI1-ASLOTR bis! ;  \ SAI1-ASLOTR_SLOTEN    Slot enable
: SAI1-ASLOTR_NBSLOT   ( %XXXX -- ) 8 lshift SAI1-ASLOTR bis! ;  \ SAI1-ASLOTR_NBSLOT    Number of slots in an audio frame
: SAI1-ASLOTR_SLOTSZ   ( %XX -- ) 6 lshift SAI1-ASLOTR bis! ;  \ SAI1-ASLOTR_SLOTSZ    Slot size
: SAI1-ASLOTR_FBOFF   ( %XXXXX -- ) 0 lshift SAI1-ASLOTR bis! ;  \ SAI1-ASLOTR_FBOFF    First bit offset

\ SAI1-AIM (read-write)
: SAI1-AIM_LFSDET   %1 6 lshift SAI1-AIM bis! ;  \ SAI1-AIM_LFSDET    Late frame synchronization detection interrupt enable
: SAI1-AIM_AFSDETIE   %1 5 lshift SAI1-AIM bis! ;  \ SAI1-AIM_AFSDETIE    Anticipated frame synchronization detection interrupt enable
: SAI1-AIM_CNRDYIE   %1 4 lshift SAI1-AIM bis! ;  \ SAI1-AIM_CNRDYIE    Codec not ready interrupt enable
: SAI1-AIM_FREQIE   %1 3 lshift SAI1-AIM bis! ;  \ SAI1-AIM_FREQIE    FIFO request interrupt enable
: SAI1-AIM_WCKCFG   %1 2 lshift SAI1-AIM bis! ;  \ SAI1-AIM_WCKCFG    Wrong clock configuration interrupt enable
: SAI1-AIM_MUTEDET   %1 1 lshift SAI1-AIM bis! ;  \ SAI1-AIM_MUTEDET    Mute detection interrupt enable
: SAI1-AIM_OVRUDRIE   %1 0 lshift SAI1-AIM bis! ;  \ SAI1-AIM_OVRUDRIE    Overrun/underrun interrupt enable

\ SAI1-ASR (read-only)
: SAI1-ASR_FLVL   ( %XXX -- ) 16 lshift SAI1-ASR bis! ;  \ SAI1-ASR_FLVL    FIFO level threshold
: SAI1-ASR_LFSDET   %1 6 lshift SAI1-ASR bis! ;  \ SAI1-ASR_LFSDET    Late frame synchronization detection
: SAI1-ASR_AFSDET   %1 5 lshift SAI1-ASR bis! ;  \ SAI1-ASR_AFSDET    Anticipated frame synchronization detection
: SAI1-ASR_CNRDY   %1 4 lshift SAI1-ASR bis! ;  \ SAI1-ASR_CNRDY    Codec not ready
: SAI1-ASR_FREQ   %1 3 lshift SAI1-ASR bis! ;  \ SAI1-ASR_FREQ    FIFO request
: SAI1-ASR_WCKCFG   %1 2 lshift SAI1-ASR bis! ;  \ SAI1-ASR_WCKCFG    Wrong clock configuration flag. This bit is read only
: SAI1-ASR_MUTEDET   %1 1 lshift SAI1-ASR bis! ;  \ SAI1-ASR_MUTEDET    Mute detection
: SAI1-ASR_OVRUDR   %1 0 lshift SAI1-ASR bis! ;  \ SAI1-ASR_OVRUDR    Overrun / underrun

\ SAI1-ACLRFR (write-only)
: SAI1-ACLRFR_LFSDET   %1 6 lshift SAI1-ACLRFR bis! ;  \ SAI1-ACLRFR_LFSDET    Clear late frame synchronization detection flag
: SAI1-ACLRFR_CAFSDET   %1 5 lshift SAI1-ACLRFR bis! ;  \ SAI1-ACLRFR_CAFSDET    Clear anticipated frame synchronization detection flag
: SAI1-ACLRFR_CNRDY   %1 4 lshift SAI1-ACLRFR bis! ;  \ SAI1-ACLRFR_CNRDY    Clear codec not ready flag
: SAI1-ACLRFR_WCKCFG   %1 2 lshift SAI1-ACLRFR bis! ;  \ SAI1-ACLRFR_WCKCFG    Clear wrong clock configuration flag
: SAI1-ACLRFR_MUTEDET   %1 1 lshift SAI1-ACLRFR bis! ;  \ SAI1-ACLRFR_MUTEDET    Mute detection flag
: SAI1-ACLRFR_OVRUDR   %1 0 lshift SAI1-ACLRFR bis! ;  \ SAI1-ACLRFR_OVRUDR    Clear overrun / underrun

\ SAI1-ADR (read-write)
: SAI1-ADR_DATA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift SAI1-ADR bis! ;  \ SAI1-ADR_DATA    Data

\ SAI1-PDMCR (read-write)
: SAI1-PDMCR_CKEN4   %1 11 lshift SAI1-PDMCR bis! ;  \ SAI1-PDMCR_CKEN4    Clock enable of bitstream clock number 4
: SAI1-PDMCR_CKEN3   %1 10 lshift SAI1-PDMCR bis! ;  \ SAI1-PDMCR_CKEN3    Clock enable of bitstream clock number 3
: SAI1-PDMCR_CKEN2   %1 9 lshift SAI1-PDMCR bis! ;  \ SAI1-PDMCR_CKEN2    Clock enable of bitstream clock number 2
: SAI1-PDMCR_CKEN1   %1 8 lshift SAI1-PDMCR bis! ;  \ SAI1-PDMCR_CKEN1    Clock enable of bitstream clock number 1
: SAI1-PDMCR_MICNBR   ( %XX -- ) 4 lshift SAI1-PDMCR bis! ;  \ SAI1-PDMCR_MICNBR    Number of microphones
: SAI1-PDMCR_PDMEN   %1 0 lshift SAI1-PDMCR bis! ;  \ SAI1-PDMCR_PDMEN    PDM enable

\ SAI1-PDMDLY (read-write)
: SAI1-PDMDLY_DLYM4R   ( %XXX -- ) 28 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM4R    Delay line for second microphone of pair 4
: SAI1-PDMDLY_DLYM4L   ( %XXX -- ) 24 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM4L    Delay line for first microphone of pair 4
: SAI1-PDMDLY_DLYM3R   ( %XXX -- ) 20 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM3R    Delay line for second microphone of pair 3
: SAI1-PDMDLY_DLYM3L   ( %XXX -- ) 16 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM3L    Delay line for first microphone of pair 3
: SAI1-PDMDLY_DLYM2R   ( %XXX -- ) 12 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM2R    Delay line for second microphone of pair 2
: SAI1-PDMDLY_DLYM2L   ( %XXX -- ) 8 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM2L    Delay line for first microphone of pair 2
: SAI1-PDMDLY_DLYM1R   ( %XXX -- ) 4 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM1R    Delay line for second microphone of pair 1
: SAI1-PDMDLY_DLYM1L   ( %XXX -- ) 0 lshift SAI1-PDMDLY bis! ;  \ SAI1-PDMDLY_DLYM1L    Delay line for first microphone of pair 1

\ TIM2-CR1 (read-write)
: TIM2-CR1_UIFREMAP   %1 11 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_UIFREMAP    UIF status bit remapping
: TIM2-CR1_CKD   ( %XX -- ) 8 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_CKD    Clock division
: TIM2-CR1_ARPE   %1 7 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_ARPE    Auto-reload preload enable
: TIM2-CR1_CMS   ( %XX -- ) 5 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_CMS    Center-aligned mode selection
: TIM2-CR1_DIR   %1 4 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_DIR    Direction
: TIM2-CR1_OPM   %1 3 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_OPM    One-pulse mode
: TIM2-CR1_URS   %1 2 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_URS    Update request source
: TIM2-CR1_UDIS   %1 1 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_UDIS    Update disable
: TIM2-CR1_CEN   %1 0 lshift TIM2-CR1 bis! ;  \ TIM2-CR1_CEN    Counter enable

\ TIM2-CR2 (read-write)
: TIM2-CR2_TI1S   %1 7 lshift TIM2-CR2 bis! ;  \ TIM2-CR2_TI1S    TI1 selection
: TIM2-CR2_MMS   ( %XXX -- ) 4 lshift TIM2-CR2 bis! ;  \ TIM2-CR2_MMS    Master mode selection
: TIM2-CR2_CCDS   %1 3 lshift TIM2-CR2 bis! ;  \ TIM2-CR2_CCDS    Capture/compare DMA selection

\ TIM2-SMCR (read-write)
: TIM2-SMCR_SMS_3   %1 16 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_SMS_3    Slave mode selection - bit 3
: TIM2-SMCR_ETP   %1 15 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_ETP    External trigger polarity
: TIM2-SMCR_ECE   %1 14 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_ECE    External clock enable
: TIM2-SMCR_ETPS   ( %XX -- ) 12 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_ETPS    External trigger prescaler
: TIM2-SMCR_ETF   ( %XXXX -- ) 8 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_ETF    External trigger filter
: TIM2-SMCR_MSM   %1 7 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_MSM    Master/Slave mode
: TIM2-SMCR_TS   ( %XXX -- ) 4 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_TS    Trigger selection
: TIM2-SMCR_OCCS   %1 3 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_OCCS    OCREF clear selection
: TIM2-SMCR_SMS   ( %XXX -- ) 0 lshift TIM2-SMCR bis! ;  \ TIM2-SMCR_SMS    Slave mode selection

\ TIM2-DIER (read-write)
: TIM2-DIER_CC4DE   %1 12 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC4DE    Capture/Compare 4 DMA request enable
: TIM2-DIER_CC3DE   %1 11 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC3DE    Capture/Compare 3 DMA request enable
: TIM2-DIER_CC2DE   %1 10 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC2DE    Capture/Compare 2 DMA request enable
: TIM2-DIER_CC1DE   %1 9 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC1DE    Capture/Compare 1 DMA request enable
: TIM2-DIER_UDE   %1 8 lshift TIM2-DIER bis! ;  \ TIM2-DIER_UDE    Update DMA request enable
: TIM2-DIER_TIE   %1 6 lshift TIM2-DIER bis! ;  \ TIM2-DIER_TIE    Trigger interrupt enable
: TIM2-DIER_CC4IE   %1 4 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC4IE    Capture/Compare 4 interrupt enable
: TIM2-DIER_CC3IE   %1 3 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC3IE    Capture/Compare 3 interrupt enable
: TIM2-DIER_CC2IE   %1 2 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC2IE    Capture/Compare 2 interrupt enable
: TIM2-DIER_CC1IE   %1 1 lshift TIM2-DIER bis! ;  \ TIM2-DIER_CC1IE    Capture/Compare 1 interrupt enable
: TIM2-DIER_UIE   %1 0 lshift TIM2-DIER bis! ;  \ TIM2-DIER_UIE    Update interrupt enable

\ TIM2-SR (read-write)
: TIM2-SR_CC4OF   %1 12 lshift TIM2-SR bis! ;  \ TIM2-SR_CC4OF    Capture/Compare 4 overcapture flag
: TIM2-SR_CC3OF   %1 11 lshift TIM2-SR bis! ;  \ TIM2-SR_CC3OF    Capture/Compare 3 overcapture flag
: TIM2-SR_CC2OF   %1 10 lshift TIM2-SR bis! ;  \ TIM2-SR_CC2OF    Capture/compare 2 overcapture flag
: TIM2-SR_CC1OF   %1 9 lshift TIM2-SR bis! ;  \ TIM2-SR_CC1OF    Capture/Compare 1 overcapture flag
: TIM2-SR_TIF   %1 6 lshift TIM2-SR bis! ;  \ TIM2-SR_TIF    Trigger interrupt flag
: TIM2-SR_CC4IF   %1 4 lshift TIM2-SR bis! ;  \ TIM2-SR_CC4IF    Capture/Compare 4 interrupt flag
: TIM2-SR_CC3IF   %1 3 lshift TIM2-SR bis! ;  \ TIM2-SR_CC3IF    Capture/Compare 3 interrupt flag
: TIM2-SR_CC2IF   %1 2 lshift TIM2-SR bis! ;  \ TIM2-SR_CC2IF    Capture/Compare 2 interrupt flag
: TIM2-SR_CC1IF   %1 1 lshift TIM2-SR bis! ;  \ TIM2-SR_CC1IF    Capture/compare 1 interrupt flag
: TIM2-SR_UIF   %1 0 lshift TIM2-SR bis! ;  \ TIM2-SR_UIF    Update interrupt flag

\ TIM2-EGR (write-only)
: TIM2-EGR_TG   %1 6 lshift TIM2-EGR bis! ;  \ TIM2-EGR_TG    Trigger generation
: TIM2-EGR_CC4G   %1 4 lshift TIM2-EGR bis! ;  \ TIM2-EGR_CC4G    Capture/compare 4 generation
: TIM2-EGR_CC3G   %1 3 lshift TIM2-EGR bis! ;  \ TIM2-EGR_CC3G    Capture/compare 3 generation
: TIM2-EGR_CC2G   %1 2 lshift TIM2-EGR bis! ;  \ TIM2-EGR_CC2G    Capture/compare 2 generation
: TIM2-EGR_CC1G   %1 1 lshift TIM2-EGR bis! ;  \ TIM2-EGR_CC1G    Capture/compare 1 generation
: TIM2-EGR_UG   %1 0 lshift TIM2-EGR bis! ;  \ TIM2-EGR_UG    Update generation

\ TIM2-CCMR1_Output (read-write)
: TIM2-CCMR1_Output_OC2M_3   %1 24 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC2M_3    Output Compare 2 mode - bit 3
: TIM2-CCMR1_Output_OC1M_3   %1 16 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC1M_3    Output Compare 1 mode - bit 3
: TIM2-CCMR1_Output_OC2CE   %1 15 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC2CE    Output compare 2 clear enable
: TIM2-CCMR1_Output_OC2M   ( %XXX -- ) 12 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC2M    Output compare 2 mode
: TIM2-CCMR1_Output_OC2PE   %1 11 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC2PE    Output compare 2 preload enable
: TIM2-CCMR1_Output_OC2FE   %1 10 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC2FE    Output compare 2 fast enable
: TIM2-CCMR1_Output_CC2S   ( %XX -- ) 8 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_CC2S    Capture/Compare 2 selection
: TIM2-CCMR1_Output_OC1CE   %1 7 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC1CE    Output compare 1 clear enable
: TIM2-CCMR1_Output_OC1M   ( %XXX -- ) 4 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC1M    Output compare 1 mode
: TIM2-CCMR1_Output_OC1PE   %1 3 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC1PE    Output compare 1 preload enable
: TIM2-CCMR1_Output_OC1FE   %1 2 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_OC1FE    Output compare 1 fast enable
: TIM2-CCMR1_Output_CC1S   ( %XX -- ) 0 lshift TIM2-CCMR1_Output bis! ;  \ TIM2-CCMR1_Output_CC1S    Capture/Compare 1 selection

\ TIM2-CCMR1_Input (read-write)
: TIM2-CCMR1_Input_IC2F   ( %XXXX -- ) 12 lshift TIM2-CCMR1_Input bis! ;  \ TIM2-CCMR1_Input_IC2F    Input capture 2 filter
: TIM2-CCMR1_Input_IC2PSC   ( %XX -- ) 10 lshift TIM2-CCMR1_Input bis! ;  \ TIM2-CCMR1_Input_IC2PSC    Input capture 2 prescaler
: TIM2-CCMR1_Input_CC2S   ( %XX -- ) 8 lshift TIM2-CCMR1_Input bis! ;  \ TIM2-CCMR1_Input_CC2S    Capture/compare 2 selection
: TIM2-CCMR1_Input_IC1F   ( %XXXX -- ) 4 lshift TIM2-CCMR1_Input bis! ;  \ TIM2-CCMR1_Input_IC1F    Input capture 1 filter
: TIM2-CCMR1_Input_IC1PSC   ( %XX -- ) 2 lshift TIM2-CCMR1_Input bis! ;  \ TIM2-CCMR1_Input_IC1PSC    Input capture 1 prescaler
: TIM2-CCMR1_Input_CC1S   ( %XX -- ) 0 lshift TIM2-CCMR1_Input bis! ;  \ TIM2-CCMR1_Input_CC1S    Capture/Compare 1 selection

\ TIM2-CCMR2_Output (read-write)
: TIM2-CCMR2_Output_OC4M_3   %1 24 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC4M_3    Output Compare 4 mode - bit 3
: TIM2-CCMR2_Output_OC3M_3   %1 16 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC3M_3    Output Compare 3 mode - bit 3
: TIM2-CCMR2_Output_OC4CE   %1 15 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC4CE    Output compare 4 clear enable
: TIM2-CCMR2_Output_OC4M   ( %XXX -- ) 12 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC4M    Output compare 4 mode
: TIM2-CCMR2_Output_OC4PE   %1 11 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC4PE    Output compare 4 preload enable
: TIM2-CCMR2_Output_OC4FE   %1 10 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC4FE    Output compare 4 fast enable
: TIM2-CCMR2_Output_CC4S   ( %XX -- ) 8 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_CC4S    Capture/Compare 4 selection
: TIM2-CCMR2_Output_OC3CE   %1 7 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC3CE    Output compare 3 clear enable
: TIM2-CCMR2_Output_OC3M   ( %XXX -- ) 4 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC3M    Output compare 3 mode
: TIM2-CCMR2_Output_OC3PE   %1 3 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC3PE    Output compare 3 preload enable
: TIM2-CCMR2_Output_OC3FE   %1 2 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_OC3FE    Output compare 3 fast enable
: TIM2-CCMR2_Output_CC3S   ( %XX -- ) 0 lshift TIM2-CCMR2_Output bis! ;  \ TIM2-CCMR2_Output_CC3S    Capture/Compare 3 selection

\ TIM2-CCMR2_Input (read-write)
: TIM2-CCMR2_Input_IC4F   ( %XXXX -- ) 12 lshift TIM2-CCMR2_Input bis! ;  \ TIM2-CCMR2_Input_IC4F    Input capture 4 filter
: TIM2-CCMR2_Input_IC4PSC   ( %XX -- ) 10 lshift TIM2-CCMR2_Input bis! ;  \ TIM2-CCMR2_Input_IC4PSC    Input capture 4 prescaler
: TIM2-CCMR2_Input_CC4S   ( %XX -- ) 8 lshift TIM2-CCMR2_Input bis! ;  \ TIM2-CCMR2_Input_CC4S    Capture/Compare 4 selection
: TIM2-CCMR2_Input_IC3F   ( %XXXX -- ) 4 lshift TIM2-CCMR2_Input bis! ;  \ TIM2-CCMR2_Input_IC3F    Input capture 3 filter
: TIM2-CCMR2_Input_IC3PSC   ( %XX -- ) 2 lshift TIM2-CCMR2_Input bis! ;  \ TIM2-CCMR2_Input_IC3PSC    Input capture 3 prescaler
: TIM2-CCMR2_Input_CC3S   ( %XX -- ) 0 lshift TIM2-CCMR2_Input bis! ;  \ TIM2-CCMR2_Input_CC3S    Capture/Compare 3 selection

\ TIM2-CCER (read-write)
: TIM2-CCER_CC4NP   %1 15 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC4NP    Capture/Compare 4 output Polarity
: TIM2-CCER_CC4P   %1 13 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC4P    Capture/Compare 3 output Polarity
: TIM2-CCER_CC4E   %1 12 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC4E    Capture/Compare 4 output enable
: TIM2-CCER_CC3NP   %1 11 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC3NP    Capture/Compare 3 output Polarity
: TIM2-CCER_CC3P   %1 9 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC3P    Capture/Compare 3 output Polarity
: TIM2-CCER_CC3E   %1 8 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC3E    Capture/Compare 3 output enable
: TIM2-CCER_CC2NP   %1 7 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC2NP    Capture/Compare 2 output Polarity
: TIM2-CCER_CC2P   %1 5 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC2P    Capture/Compare 2 output Polarity
: TIM2-CCER_CC2E   %1 4 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC2E    Capture/Compare 2 output enable
: TIM2-CCER_CC1NP   %1 3 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC1NP    Capture/Compare 1 output Polarity
: TIM2-CCER_CC1P   %1 1 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC1P    Capture/Compare 1 output Polarity
: TIM2-CCER_CC1E   %1 0 lshift TIM2-CCER bis! ;  \ TIM2-CCER_CC1E    Capture/Compare 1 output enable

\ TIM2-CNT ()
: TIM2-CNT_CNT_H   ( %XXXXXXXXXXXXXXX -- ) 16 lshift TIM2-CNT bis! ;  \ TIM2-CNT_CNT_H    High counter value TIM2 only
: TIM2-CNT_CNT_L   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-CNT bis! ;  \ TIM2-CNT_CNT_L    Low counter value
: TIM2-CNT_UIFCPY   %1 31 lshift TIM2-CNT bis! ;  \ TIM2-CNT_UIFCPY    Value depends on IUFREMAP in TIM2_CR1.

\ TIM2-PSC (read-write)
: TIM2-PSC_PSC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-PSC bis! ;  \ TIM2-PSC_PSC    Prescaler value

\ TIM2-ARR (read-write)
: TIM2-ARR_ARR_H   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift TIM2-ARR bis! ;  \ TIM2-ARR_ARR_H    High Auto-reload value TIM2 only
: TIM2-ARR_ARR_L   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-ARR bis! ;  \ TIM2-ARR_ARR_L    Low Auto-reload value

\ TIM2-CCR1 (read-write)
: TIM2-CCR1_CCR1_H   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift TIM2-CCR1 bis! ;  \ TIM2-CCR1_CCR1_H    High Capture/Compare 1 value TIM2 only
: TIM2-CCR1_CCR1_L   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-CCR1 bis! ;  \ TIM2-CCR1_CCR1_L    Low Capture/Compare 1 value

\ TIM2-CCR2 (read-write)
: TIM2-CCR2_CCR2_H   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift TIM2-CCR2 bis! ;  \ TIM2-CCR2_CCR2_H    High Capture/Compare 2 value TIM2 only
: TIM2-CCR2_CCR2_L   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-CCR2 bis! ;  \ TIM2-CCR2_CCR2_L    Low Capture/Compare 2 value

\ TIM2-CCR3 (read-write)
: TIM2-CCR3_CCR3_H   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift TIM2-CCR3 bis! ;  \ TIM2-CCR3_CCR3_H    High Capture/Compare value TIM2 only
: TIM2-CCR3_CCR3_L   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-CCR3 bis! ;  \ TIM2-CCR3_CCR3_L    Low Capture/Compare value

\ TIM2-CCR4 (read-write)
: TIM2-CCR4_CCR4_H   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift TIM2-CCR4 bis! ;  \ TIM2-CCR4_CCR4_H    High Capture/Compare value TIM2 only
: TIM2-CCR4_CCR4_L   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-CCR4 bis! ;  \ TIM2-CCR4_CCR4_L    Low Capture/Compare value

\ TIM2-DCR (read-write)
: TIM2-DCR_DBL   ( %XXXXX -- ) 8 lshift TIM2-DCR bis! ;  \ TIM2-DCR_DBL    DMA burst length
: TIM2-DCR_DBA   ( %XXXXX -- ) 0 lshift TIM2-DCR bis! ;  \ TIM2-DCR_DBA    DMA base address

\ TIM2-DMAR (read-write)
: TIM2-DMAR_DMAB   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM2-DMAR bis! ;  \ TIM2-DMAR_DMAB    DMA register for burst accesses

\ TIM2-OR (read-write)
: TIM2-OR_TI4_RMP   ( %XX -- ) 2 lshift TIM2-OR bis! ;  \ TIM2-OR_TI4_RMP    Input capture 4 remap
: TIM2-OR_ETR_RMP   %1 1 lshift TIM2-OR bis! ;  \ TIM2-OR_ETR_RMP    External trigger remap
: TIM2-OR_ITR_RMP   %1 0 lshift TIM2-OR bis! ;  \ TIM2-OR_ITR_RMP    Internal trigger remap

\ TIM2-AF (read-write)
: TIM2-AF_ETRSEL   ( %XXX -- ) 14 lshift TIM2-AF bis! ;  \ TIM2-AF_ETRSEL    External trigger source selection

\ TIM16-CR1 (read-write)
: TIM16-CR1_BKINE   %1 0 lshift TIM16-CR1 bis! ;  \ TIM16-CR1_BKINE    BRK BKIN input enable
: TIM16-CR1_BKCMP1E   %1 1 lshift TIM16-CR1 bis! ;  \ TIM16-CR1_BKCMP1E    BRK COMP1 enable
: TIM16-CR1_BKCMP2E   %1 2 lshift TIM16-CR1 bis! ;  \ TIM16-CR1_BKCMP2E    BRK COMP2 enable
: TIM16-CR1_BKINP   %1 9 lshift TIM16-CR1 bis! ;  \ TIM16-CR1_BKINP    BRK BKIN input polarity
: TIM16-CR1_BKCMP1P   %1 10 lshift TIM16-CR1 bis! ;  \ TIM16-CR1_BKCMP1P    BRK COMP1 input polarity
: TIM16-CR1_BKCMP2P   %1 11 lshift TIM16-CR1 bis! ;  \ TIM16-CR1_BKCMP2P    BRK COMP2 input polarit

\ TIM16-CR2 (read-write)
: TIM16-CR2_OIS1N   %1 9 lshift TIM16-CR2 bis! ;  \ TIM16-CR2_OIS1N    Output Idle state 1
: TIM16-CR2_OIS1   %1 8 lshift TIM16-CR2 bis! ;  \ TIM16-CR2_OIS1    Output Idle state 1
: TIM16-CR2_CCDS   %1 3 lshift TIM16-CR2 bis! ;  \ TIM16-CR2_CCDS    Capture/compare DMA selection
: TIM16-CR2_CCUS   %1 2 lshift TIM16-CR2 bis! ;  \ TIM16-CR2_CCUS    Capture/compare control update selection
: TIM16-CR2_CCPC   %1 0 lshift TIM16-CR2 bis! ;  \ TIM16-CR2_CCPC    Capture/compare preloaded control

\ TIM16-DIER (read-write)
: TIM16-DIER_BKINE   %1 0 lshift TIM16-DIER bis! ;  \ TIM16-DIER_BKINE    BRK BKIN input enable
: TIM16-DIER_BKCMP1E   %1 1 lshift TIM16-DIER bis! ;  \ TIM16-DIER_BKCMP1E    BRK COMP1 enable
: TIM16-DIER_BKCMP2E   %1 2 lshift TIM16-DIER bis! ;  \ TIM16-DIER_BKCMP2E    BRK COMP2 enable
: TIM16-DIER_BKINP   %1 9 lshift TIM16-DIER bis! ;  \ TIM16-DIER_BKINP    BRK BKIN input polarity
: TIM16-DIER_BKCMP1P   %1 10 lshift TIM16-DIER bis! ;  \ TIM16-DIER_BKCMP1P    BRK COMP1 input polarity
: TIM16-DIER_BKCMP2P   %1 11 lshift TIM16-DIER bis! ;  \ TIM16-DIER_BKCMP2P    BRK COMP2 input polarit

\ TIM16-SR (read-write)
: TIM16-SR_CC1OF   %1 9 lshift TIM16-SR bis! ;  \ TIM16-SR_CC1OF    Capture/Compare 1 overcapture flag
: TIM16-SR_BIF   %1 7 lshift TIM16-SR bis! ;  \ TIM16-SR_BIF    Break interrupt flag
: TIM16-SR_TIF   %1 6 lshift TIM16-SR bis! ;  \ TIM16-SR_TIF    Trigger interrupt flag
: TIM16-SR_COMIF   %1 5 lshift TIM16-SR bis! ;  \ TIM16-SR_COMIF    COM interrupt flag
: TIM16-SR_CC1IF   %1 1 lshift TIM16-SR bis! ;  \ TIM16-SR_CC1IF    Capture/compare 1 interrupt flag
: TIM16-SR_UIF   %1 0 lshift TIM16-SR bis! ;  \ TIM16-SR_UIF    Update interrupt flag

\ TIM16-EGR (write-only)
: TIM16-EGR_BG   %1 7 lshift TIM16-EGR bis! ;  \ TIM16-EGR_BG    Break generation
: TIM16-EGR_TG   %1 6 lshift TIM16-EGR bis! ;  \ TIM16-EGR_TG    Trigger generation
: TIM16-EGR_COMG   %1 5 lshift TIM16-EGR bis! ;  \ TIM16-EGR_COMG    Capture/Compare control update generation
: TIM16-EGR_CC1G   %1 1 lshift TIM16-EGR bis! ;  \ TIM16-EGR_CC1G    Capture/compare 1 generation
: TIM16-EGR_UG   %1 0 lshift TIM16-EGR bis! ;  \ TIM16-EGR_UG    Update generation

\ TIM16-CCMR1_Output (read-write)
: TIM16-CCMR1_Output_OC1M_2   %1 16 lshift TIM16-CCMR1_Output bis! ;  \ TIM16-CCMR1_Output_OC1M_2    Output Compare 1 mode
: TIM16-CCMR1_Output_OC1M   ( %XXX -- ) 4 lshift TIM16-CCMR1_Output bis! ;  \ TIM16-CCMR1_Output_OC1M    Output Compare 1 mode
: TIM16-CCMR1_Output_OC1PE   %1 3 lshift TIM16-CCMR1_Output bis! ;  \ TIM16-CCMR1_Output_OC1PE    Output Compare 1 preload enable
: TIM16-CCMR1_Output_OC1FE   %1 2 lshift TIM16-CCMR1_Output bis! ;  \ TIM16-CCMR1_Output_OC1FE    Output Compare 1 fast enable
: TIM16-CCMR1_Output_CC1S   ( %XX -- ) 0 lshift TIM16-CCMR1_Output bis! ;  \ TIM16-CCMR1_Output_CC1S    Capture/Compare 1 selection

\ TIM16-CCMR1_Input (read-write)
: TIM16-CCMR1_Input_IC1F   ( %XXXX -- ) 4 lshift TIM16-CCMR1_Input bis! ;  \ TIM16-CCMR1_Input_IC1F    Input capture 1 filter
: TIM16-CCMR1_Input_IC1PSC   ( %XX -- ) 2 lshift TIM16-CCMR1_Input bis! ;  \ TIM16-CCMR1_Input_IC1PSC    Input capture 1 prescaler
: TIM16-CCMR1_Input_CC1S   ( %XX -- ) 0 lshift TIM16-CCMR1_Input bis! ;  \ TIM16-CCMR1_Input_CC1S    Capture/Compare 1 selection

\ TIM16-CCER (read-write)
: TIM16-CCER_CC1NP   %1 3 lshift TIM16-CCER bis! ;  \ TIM16-CCER_CC1NP    Capture/Compare 1 output Polarity
: TIM16-CCER_CC1NE   %1 2 lshift TIM16-CCER bis! ;  \ TIM16-CCER_CC1NE    Capture/Compare 1 complementary output enable
: TIM16-CCER_CC1P   %1 1 lshift TIM16-CCER bis! ;  \ TIM16-CCER_CC1P    Capture/Compare 1 output Polarity
: TIM16-CCER_CC1E   %1 0 lshift TIM16-CCER bis! ;  \ TIM16-CCER_CC1E    Capture/Compare 1 output enable

\ TIM16-CNT ()
: TIM16-CNT_CNT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM16-CNT bis! ;  \ TIM16-CNT_CNT    counter value
: TIM16-CNT_UIFCPY   %1 31 lshift TIM16-CNT bis! ;  \ TIM16-CNT_UIFCPY    UIF Copy

\ TIM16-PSC (read-write)
: TIM16-PSC_PSC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM16-PSC bis! ;  \ TIM16-PSC_PSC    Prescaler value

\ TIM16-ARR (read-write)
: TIM16-ARR_ARR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM16-ARR bis! ;  \ TIM16-ARR_ARR    Auto-reload value

\ TIM16-RCR (read-write)
: TIM16-RCR_REP   ( %XXXXXXXX -- ) 0 lshift TIM16-RCR bis! ;  \ TIM16-RCR_REP    Repetition counter value

\ TIM16-CCR1 (read-write)
: TIM16-CCR1_CCR1   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM16-CCR1 bis! ;  \ TIM16-CCR1_CCR1    Capture/Compare 1 value

\ TIM16-BDTR (read-write)
: TIM16-BDTR_DTG   ( %XXXXXXXX -- ) 0 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_DTG    Dead-time generator setup
: TIM16-BDTR_LOCK   ( %XX -- ) 8 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_LOCK    Lock configuration
: TIM16-BDTR_OSSI   %1 10 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_OSSI    Off-state selection for Idle mode
: TIM16-BDTR_OSSR   %1 11 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_OSSR    Off-state selection for Run mode
: TIM16-BDTR_BKE   %1 12 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_BKE    Break enable
: TIM16-BDTR_BKP   %1 13 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_BKP    Break polarity
: TIM16-BDTR_AOE   %1 14 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_AOE    Automatic output enable
: TIM16-BDTR_MOE   %1 15 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_MOE    Main output enable
: TIM16-BDTR_BKF   ( %XXXX -- ) 16 lshift TIM16-BDTR bis! ;  \ TIM16-BDTR_BKF    Break filter

\ TIM16-DCR (read-write)
: TIM16-DCR_DBL   ( %XXXXX -- ) 8 lshift TIM16-DCR bis! ;  \ TIM16-DCR_DBL    DMA burst length
: TIM16-DCR_DBA   ( %XXXXX -- ) 0 lshift TIM16-DCR bis! ;  \ TIM16-DCR_DBA    DMA base address

\ TIM16-DMAR (read-write)
: TIM16-DMAR_DMAB   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM16-DMAR bis! ;  \ TIM16-DMAR_DMAB    DMA register for burst accesses

\ TIM16-OR (read-write)
: TIM16-OR_TI1_RMP   ( %XX -- ) 0 lshift TIM16-OR bis! ;  \ TIM16-OR_TI1_RMP    Input capture 1 remap

\ TIM16-AF1 (read-write)
: TIM16-AF1_BKINE   %1 0 lshift TIM16-AF1 bis! ;  \ TIM16-AF1_BKINE    BRK BKIN input enable
: TIM16-AF1_BKCMP1E   %1 1 lshift TIM16-AF1 bis! ;  \ TIM16-AF1_BKCMP1E    BRK COMP1 enable
: TIM16-AF1_BKCMP2E   %1 2 lshift TIM16-AF1 bis! ;  \ TIM16-AF1_BKCMP2E    BRK COMP2 enable
: TIM16-AF1_BKINP   %1 9 lshift TIM16-AF1 bis! ;  \ TIM16-AF1_BKINP    BRK BKIN input polarity
: TIM16-AF1_BKCMP1P   %1 10 lshift TIM16-AF1 bis! ;  \ TIM16-AF1_BKCMP1P    BRK COMP1 input polarity
: TIM16-AF1_BKCMP2P   %1 11 lshift TIM16-AF1 bis! ;  \ TIM16-AF1_BKCMP2P    BRK COMP2 input polarit

\ TIM17-CR1 (read-write)
: TIM17-CR1_CEN   %1 0 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_CEN    Counter enable
: TIM17-CR1_UDIS   %1 1 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_UDIS    Update disable
: TIM17-CR1_URS   %1 2 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_URS    Update request source
: TIM17-CR1_OPM   %1 3 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_OPM    One-pulse mode
: TIM17-CR1_ARPE   %1 7 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_ARPE    Auto-reload preload enable
: TIM17-CR1_CKD   ( %XX -- ) 8 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_CKD    Clock division
: TIM17-CR1_UIFREMAP   %1 11 lshift TIM17-CR1 bis! ;  \ TIM17-CR1_UIFREMAP    UIF status bit remapping

\ TIM17-CR2 (read-write)
: TIM17-CR2_OIS1N   %1 9 lshift TIM17-CR2 bis! ;  \ TIM17-CR2_OIS1N    Output Idle state 1
: TIM17-CR2_OIS1   %1 8 lshift TIM17-CR2 bis! ;  \ TIM17-CR2_OIS1    Output Idle state 1
: TIM17-CR2_CCDS   %1 3 lshift TIM17-CR2 bis! ;  \ TIM17-CR2_CCDS    Capture/compare DMA selection
: TIM17-CR2_CCUS   %1 2 lshift TIM17-CR2 bis! ;  \ TIM17-CR2_CCUS    Capture/compare control update selection
: TIM17-CR2_CCPC   %1 0 lshift TIM17-CR2 bis! ;  \ TIM17-CR2_CCPC    Capture/compare preloaded control

\ TIM17-DIER (read-write)
: TIM17-DIER_BKINE   %1 0 lshift TIM17-DIER bis! ;  \ TIM17-DIER_BKINE    BRK BKIN input enable
: TIM17-DIER_BKCMP1E   %1 1 lshift TIM17-DIER bis! ;  \ TIM17-DIER_BKCMP1E    BRK COMP1 enable
: TIM17-DIER_BKCMP2E   %1 2 lshift TIM17-DIER bis! ;  \ TIM17-DIER_BKCMP2E    BRK COMP2 enable
: TIM17-DIER_BKINP   %1 9 lshift TIM17-DIER bis! ;  \ TIM17-DIER_BKINP    BRK BKIN input polarity
: TIM17-DIER_BKCMP1P   %1 10 lshift TIM17-DIER bis! ;  \ TIM17-DIER_BKCMP1P    BRK COMP1 input polarity
: TIM17-DIER_BKCMP2P   %1 11 lshift TIM17-DIER bis! ;  \ TIM17-DIER_BKCMP2P    BRK COMP2 input polarit

\ TIM17-SR (read-write)
: TIM17-SR_CC1OF   %1 9 lshift TIM17-SR bis! ;  \ TIM17-SR_CC1OF    Capture/Compare 1 overcapture flag
: TIM17-SR_BIF   %1 7 lshift TIM17-SR bis! ;  \ TIM17-SR_BIF    Break interrupt flag
: TIM17-SR_TIF   %1 6 lshift TIM17-SR bis! ;  \ TIM17-SR_TIF    Trigger interrupt flag
: TIM17-SR_COMIF   %1 5 lshift TIM17-SR bis! ;  \ TIM17-SR_COMIF    COM interrupt flag
: TIM17-SR_CC1IF   %1 1 lshift TIM17-SR bis! ;  \ TIM17-SR_CC1IF    Capture/compare 1 interrupt flag
: TIM17-SR_UIF   %1 0 lshift TIM17-SR bis! ;  \ TIM17-SR_UIF    Update interrupt flag

\ TIM17-EGR (write-only)
: TIM17-EGR_BG   %1 7 lshift TIM17-EGR bis! ;  \ TIM17-EGR_BG    Break generation
: TIM17-EGR_TG   %1 6 lshift TIM17-EGR bis! ;  \ TIM17-EGR_TG    Trigger generation
: TIM17-EGR_COMG   %1 5 lshift TIM17-EGR bis! ;  \ TIM17-EGR_COMG    Capture/Compare control update generation
: TIM17-EGR_CC1G   %1 1 lshift TIM17-EGR bis! ;  \ TIM17-EGR_CC1G    Capture/compare 1 generation
: TIM17-EGR_UG   %1 0 lshift TIM17-EGR bis! ;  \ TIM17-EGR_UG    Update generation

\ TIM17-CCMR1_Output (read-write)
: TIM17-CCMR1_Output_OC1M_2   %1 16 lshift TIM17-CCMR1_Output bis! ;  \ TIM17-CCMR1_Output_OC1M_2    Output Compare 1 mode
: TIM17-CCMR1_Output_OC1M   ( %XXX -- ) 4 lshift TIM17-CCMR1_Output bis! ;  \ TIM17-CCMR1_Output_OC1M    Output Compare 1 mode
: TIM17-CCMR1_Output_OC1PE   %1 3 lshift TIM17-CCMR1_Output bis! ;  \ TIM17-CCMR1_Output_OC1PE    Output Compare 1 preload enable
: TIM17-CCMR1_Output_OC1FE   %1 2 lshift TIM17-CCMR1_Output bis! ;  \ TIM17-CCMR1_Output_OC1FE    Output Compare 1 fast enable
: TIM17-CCMR1_Output_CC1S   ( %XX -- ) 0 lshift TIM17-CCMR1_Output bis! ;  \ TIM17-CCMR1_Output_CC1S    Capture/Compare 1 selection

\ TIM17-CCMR1_Input (read-write)
: TIM17-CCMR1_Input_IC1F   ( %XXXX -- ) 4 lshift TIM17-CCMR1_Input bis! ;  \ TIM17-CCMR1_Input_IC1F    Input capture 1 filter
: TIM17-CCMR1_Input_IC1PSC   ( %XX -- ) 2 lshift TIM17-CCMR1_Input bis! ;  \ TIM17-CCMR1_Input_IC1PSC    Input capture 1 prescaler
: TIM17-CCMR1_Input_CC1S   ( %XX -- ) 0 lshift TIM17-CCMR1_Input bis! ;  \ TIM17-CCMR1_Input_CC1S    Capture/Compare 1 selection

\ TIM17-CCER (read-write)
: TIM17-CCER_CC1NP   %1 3 lshift TIM17-CCER bis! ;  \ TIM17-CCER_CC1NP    Capture/Compare 1 output Polarity
: TIM17-CCER_CC1NE   %1 2 lshift TIM17-CCER bis! ;  \ TIM17-CCER_CC1NE    Capture/Compare 1 complementary output enable
: TIM17-CCER_CC1P   %1 1 lshift TIM17-CCER bis! ;  \ TIM17-CCER_CC1P    Capture/Compare 1 output Polarity
: TIM17-CCER_CC1E   %1 0 lshift TIM17-CCER bis! ;  \ TIM17-CCER_CC1E    Capture/Compare 1 output enable

\ TIM17-CNT ()
: TIM17-CNT_CNT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM17-CNT bis! ;  \ TIM17-CNT_CNT    counter value
: TIM17-CNT_UIFCPY   %1 31 lshift TIM17-CNT bis! ;  \ TIM17-CNT_UIFCPY    UIF Copy

\ TIM17-PSC (read-write)
: TIM17-PSC_PSC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM17-PSC bis! ;  \ TIM17-PSC_PSC    Prescaler value

\ TIM17-ARR (read-write)
: TIM17-ARR_ARR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM17-ARR bis! ;  \ TIM17-ARR_ARR    Auto-reload value

\ TIM17-RCR (read-write)
: TIM17-RCR_REP   ( %XXXXXXXX -- ) 0 lshift TIM17-RCR bis! ;  \ TIM17-RCR_REP    Repetition counter value

\ TIM17-CCR1 (read-write)
: TIM17-CCR1_CCR1   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM17-CCR1 bis! ;  \ TIM17-CCR1_CCR1    Capture/Compare 1 value

\ TIM17-BDTR (read-write)
: TIM17-BDTR_DTG   ( %XXXXXXXX -- ) 0 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_DTG    Dead-time generator setup
: TIM17-BDTR_LOCK   ( %XX -- ) 8 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_LOCK    Lock configuration
: TIM17-BDTR_OSSI   %1 10 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_OSSI    Off-state selection for Idle mode
: TIM17-BDTR_OSSR   %1 11 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_OSSR    Off-state selection for Run mode
: TIM17-BDTR_BKE   %1 12 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_BKE    Break enable
: TIM17-BDTR_BKP   %1 13 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_BKP    Break polarity
: TIM17-BDTR_AOE   %1 14 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_AOE    Automatic output enable
: TIM17-BDTR_MOE   %1 15 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_MOE    Main output enable
: TIM17-BDTR_BKF   ( %XXXX -- ) 16 lshift TIM17-BDTR bis! ;  \ TIM17-BDTR_BKF    Break filter

\ TIM17-DCR (read-write)
: TIM17-DCR_DBL   ( %XXXXX -- ) 8 lshift TIM17-DCR bis! ;  \ TIM17-DCR_DBL    DMA burst length
: TIM17-DCR_DBA   ( %XXXXX -- ) 0 lshift TIM17-DCR bis! ;  \ TIM17-DCR_DBA    DMA base address

\ TIM17-DMAR (read-write)
: TIM17-DMAR_DMAB   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM17-DMAR bis! ;  \ TIM17-DMAR_DMAB    DMA register for burst accesses

\ TIM17-OR (read-write)
: TIM17-OR_TI1_RMP   ( %XX -- ) 0 lshift TIM17-OR bis! ;  \ TIM17-OR_TI1_RMP    Input capture 1 remap

\ TIM17-AF1 (read-write)
: TIM17-AF1_BKINE   %1 0 lshift TIM17-AF1 bis! ;  \ TIM17-AF1_BKINE    BRK BKIN input enable
: TIM17-AF1_BKCMP1E   %1 1 lshift TIM17-AF1 bis! ;  \ TIM17-AF1_BKCMP1E    BRK COMP1 enable
: TIM17-AF1_BKCMP2E   %1 2 lshift TIM17-AF1 bis! ;  \ TIM17-AF1_BKCMP2E    BRK COMP2 enable
: TIM17-AF1_BKINP   %1 9 lshift TIM17-AF1 bis! ;  \ TIM17-AF1_BKINP    BRK BKIN input polarity
: TIM17-AF1_BKCMP1P   %1 10 lshift TIM17-AF1 bis! ;  \ TIM17-AF1_BKCMP1P    BRK COMP1 input polarity
: TIM17-AF1_BKCMP2P   %1 11 lshift TIM17-AF1 bis! ;  \ TIM17-AF1_BKCMP2P    BRK COMP2 input polarit

\ TIM1-CR1 (read-write)
: TIM1-CR1_CEN   %1 0 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_CEN    Counter enable
: TIM1-CR1_OPM   %1 3 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_OPM    One-pulse mode
: TIM1-CR1_UDIS   %1 1 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_UDIS    Update disable
: TIM1-CR1_URS   %1 2 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_URS    Update request source
: TIM1-CR1_DIR   %1 4 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_DIR    Direction
: TIM1-CR1_CMS   ( %XX -- ) 5 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_CMS    Center-aligned mode selection
: TIM1-CR1_ARPE   %1 7 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_ARPE    Auto-reload preload enable
: TIM1-CR1_CKD   ( %XX -- ) 8 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_CKD    Clock division
: TIM1-CR1_UIFREMAP   %1 11 lshift TIM1-CR1 bis! ;  \ TIM1-CR1_UIFREMAP    UIF status bit remapping

\ TIM1-CR2 (read-write)
: TIM1-CR2_MMS2   ( %XXXX -- ) 20 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_MMS2    Master mode selection 2
: TIM1-CR2_OIS6   %1 18 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS6    Output Idle state 6 OC6 output
: TIM1-CR2_OIS5   %1 16 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS5    Output Idle state 5 OC5 output
: TIM1-CR2_OIS4   %1 14 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS4    Output Idle state 4
: TIM1-CR2_OIS3N   %1 13 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS3N    Output Idle state 3
: TIM1-CR2_OIS3   %1 12 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS3    Output Idle state 3
: TIM1-CR2_OIS2N   %1 11 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS2N    Output Idle state 2
: TIM1-CR2_OIS2   %1 10 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS2    Output Idle state 2
: TIM1-CR2_OIS1N   %1 9 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS1N    Output Idle state 1
: TIM1-CR2_OIS1   %1 8 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_OIS1    Output Idle state 1
: TIM1-CR2_TI1S   %1 7 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_TI1S    TI1 selection
: TIM1-CR2_MMS   ( %XXX -- ) 4 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_MMS    Master mode selection
: TIM1-CR2_CCDS   %1 3 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_CCDS    Capture/compare DMA selection
: TIM1-CR2_CCUS   %1 2 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_CCUS    Capture/compare control update selection
: TIM1-CR2_CCPC   %1 0 lshift TIM1-CR2 bis! ;  \ TIM1-CR2_CCPC    Capture/compare preloaded control

\ TIM1-SMCR (read-write)
: TIM1-SMCR_SMS   ( %XXX -- ) 0 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_SMS    Slave mode selection
: TIM1-SMCR_OCCS   %1 3 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_OCCS    OCREF clear selection
: TIM1-SMCR_TS   ( %XXX -- ) 4 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_TS    Trigger selection
: TIM1-SMCR_MSM   %1 7 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_MSM    Master/Slave mode
: TIM1-SMCR_ETF   ( %XXXX -- ) 8 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_ETF    External trigger filter
: TIM1-SMCR_ETPS   ( %XX -- ) 12 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_ETPS    External trigger prescaler
: TIM1-SMCR_ECE   %1 14 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_ECE    External clock enable
: TIM1-SMCR_ETP   %1 15 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_ETP    External trigger polarity
: TIM1-SMCR_SMS_3   %1 16 lshift TIM1-SMCR bis! ;  \ TIM1-SMCR_SMS_3    Slave mode selection - bit 3

\ TIM1-DIER (read-write)
: TIM1-DIER_UIE   %1 0 lshift TIM1-DIER bis! ;  \ TIM1-DIER_UIE    Update interrupt enable
: TIM1-DIER_CC1IE   %1 1 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC1IE    Capture/Compare 1 interrupt enable
: TIM1-DIER_CC2IE   %1 2 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC2IE    Capture/Compare 2 interrupt enable
: TIM1-DIER_CC3IE   %1 3 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC3IE    Capture/Compare 3 interrupt enable
: TIM1-DIER_CC4IE   %1 4 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC4IE    Capture/Compare 4 interrupt enable
: TIM1-DIER_COMIE   %1 5 lshift TIM1-DIER bis! ;  \ TIM1-DIER_COMIE    COM interrupt enable
: TIM1-DIER_TIE   %1 6 lshift TIM1-DIER bis! ;  \ TIM1-DIER_TIE    Trigger interrupt enable
: TIM1-DIER_BIE   %1 7 lshift TIM1-DIER bis! ;  \ TIM1-DIER_BIE    Break interrupt enable
: TIM1-DIER_UDE   %1 8 lshift TIM1-DIER bis! ;  \ TIM1-DIER_UDE    Update DMA request enable
: TIM1-DIER_CC1DE   %1 9 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC1DE    Capture/Compare 1 DMA request enable
: TIM1-DIER_CC2DE   %1 10 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC2DE    Capture/Compare 2 DMA request enable
: TIM1-DIER_CC3DE   %1 11 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC3DE    Capture/Compare 3 DMA request enable
: TIM1-DIER_CC4DE   %1 12 lshift TIM1-DIER bis! ;  \ TIM1-DIER_CC4DE    Capture/Compare 4 DMA request enable
: TIM1-DIER_COMDE   %1 13 lshift TIM1-DIER bis! ;  \ TIM1-DIER_COMDE    COM DMA request enable
: TIM1-DIER_TDE   %1 14 lshift TIM1-DIER bis! ;  \ TIM1-DIER_TDE    Trigger DMA request enable

\ TIM1-SR (read-write)
: TIM1-SR_UIF   %1 0 lshift TIM1-SR bis! ;  \ TIM1-SR_UIF    Update interrupt flag
: TIM1-SR_CC1IF   %1 1 lshift TIM1-SR bis! ;  \ TIM1-SR_CC1IF    Capture/compare 1 interrupt flag
: TIM1-SR_CC2IF   %1 2 lshift TIM1-SR bis! ;  \ TIM1-SR_CC2IF    Capture/Compare 2 interrupt flag
: TIM1-SR_CC3IF   %1 3 lshift TIM1-SR bis! ;  \ TIM1-SR_CC3IF    Capture/Compare 3 interrupt flag
: TIM1-SR_CC4IF   %1 4 lshift TIM1-SR bis! ;  \ TIM1-SR_CC4IF    Capture/Compare 4 interrupt flag
: TIM1-SR_COMIF   %1 5 lshift TIM1-SR bis! ;  \ TIM1-SR_COMIF    COM interrupt flag
: TIM1-SR_TIF   %1 6 lshift TIM1-SR bis! ;  \ TIM1-SR_TIF    Trigger interrupt flag
: TIM1-SR_BIF   %1 7 lshift TIM1-SR bis! ;  \ TIM1-SR_BIF    Break interrupt flag
: TIM1-SR_B2IF   %1 8 lshift TIM1-SR bis! ;  \ TIM1-SR_B2IF    Break 2 interrupt flag
: TIM1-SR_CC1OF   %1 9 lshift TIM1-SR bis! ;  \ TIM1-SR_CC1OF    Capture/Compare 1 overcapture flag
: TIM1-SR_CC2OF   %1 10 lshift TIM1-SR bis! ;  \ TIM1-SR_CC2OF    Capture/compare 2 overcapture flag
: TIM1-SR_CC3OF   %1 11 lshift TIM1-SR bis! ;  \ TIM1-SR_CC3OF    Capture/Compare 3 overcapture flag
: TIM1-SR_CC4OF   %1 12 lshift TIM1-SR bis! ;  \ TIM1-SR_CC4OF    Capture/Compare 4 overcapture flag
: TIM1-SR_SBIF   %1 13 lshift TIM1-SR bis! ;  \ TIM1-SR_SBIF    System Break interrupt flag
: TIM1-SR_CC5IF   %1 16 lshift TIM1-SR bis! ;  \ TIM1-SR_CC5IF    Compare 5 interrupt flag
: TIM1-SR_CC6IF   %1 17 lshift TIM1-SR bis! ;  \ TIM1-SR_CC6IF    Compare 6 interrupt flag

\ TIM1-EGR (write-only)
: TIM1-EGR_UG   %1 0 lshift TIM1-EGR bis! ;  \ TIM1-EGR_UG    Update generation
: TIM1-EGR_CC1G   %1 1 lshift TIM1-EGR bis! ;  \ TIM1-EGR_CC1G    Capture/compare 1 generation
: TIM1-EGR_CC2G   %1 2 lshift TIM1-EGR bis! ;  \ TIM1-EGR_CC2G    Capture/compare 2 generation
: TIM1-EGR_CC3G   %1 3 lshift TIM1-EGR bis! ;  \ TIM1-EGR_CC3G    Capture/compare 3 generation
: TIM1-EGR_CC4G   %1 4 lshift TIM1-EGR bis! ;  \ TIM1-EGR_CC4G    Capture/compare 4 generation
: TIM1-EGR_COMG   %1 5 lshift TIM1-EGR bis! ;  \ TIM1-EGR_COMG    Capture/Compare control update generation
: TIM1-EGR_TG   %1 6 lshift TIM1-EGR bis! ;  \ TIM1-EGR_TG    Trigger generation
: TIM1-EGR_BG   %1 7 lshift TIM1-EGR bis! ;  \ TIM1-EGR_BG    Break generation
: TIM1-EGR_B2G   %1 8 lshift TIM1-EGR bis! ;  \ TIM1-EGR_B2G    Break 2 generation

\ TIM1-CCMR1_Input (read-write)
: TIM1-CCMR1_Input_CC1S   ( %XX -- ) 0 lshift TIM1-CCMR1_Input bis! ;  \ TIM1-CCMR1_Input_CC1S    Capture/Compare 1 selection
: TIM1-CCMR1_Input_IC1PSC   ( %XX -- ) 2 lshift TIM1-CCMR1_Input bis! ;  \ TIM1-CCMR1_Input_IC1PSC    Input capture 1 prescaler
: TIM1-CCMR1_Input_C1F   ( %XXXX -- ) 4 lshift TIM1-CCMR1_Input bis! ;  \ TIM1-CCMR1_Input_C1F    Input capture 1 filter
: TIM1-CCMR1_Input_CC2S   ( %XX -- ) 8 lshift TIM1-CCMR1_Input bis! ;  \ TIM1-CCMR1_Input_CC2S    capture/Compare 2 selection
: TIM1-CCMR1_Input_IC2PSC   ( %XX -- ) 10 lshift TIM1-CCMR1_Input bis! ;  \ TIM1-CCMR1_Input_IC2PSC    Input capture 2 prescaler
: TIM1-CCMR1_Input_IC2F   ( %XXXX -- ) 12 lshift TIM1-CCMR1_Input bis! ;  \ TIM1-CCMR1_Input_IC2F    Input capture 2 filter

\ TIM1-CCMR1_Output (read-write)
: TIM1-CCMR1_Output_CC1S   ( %XX -- ) 0 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_CC1S    Capture/Compare 1 selection
: TIM1-CCMR1_Output_OC1FE   %1 2 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC1FE    Output Compare 1 fast enable
: TIM1-CCMR1_Output_OC1PE   %1 3 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC1PE    Output Compare 1 preload enable
: TIM1-CCMR1_Output_OC1M   ( %XXX -- ) 4 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC1M    Output Compare 1 mode
: TIM1-CCMR1_Output_OC1CE   %1 7 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC1CE    Output Compare 1 clear enable
: TIM1-CCMR1_Output_CC2S   ( %XX -- ) 8 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_CC2S    Capture/Compare 2 selection
: TIM1-CCMR1_Output_OC2FE   %1 10 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC2FE    Output Compare 2 fast enable
: TIM1-CCMR1_Output_OC2PE   %1 11 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC2PE    Output Compare 2 preload enable
: TIM1-CCMR1_Output_OC2M   ( %XXX -- ) 12 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC2M    Output Compare 2 mode
: TIM1-CCMR1_Output_OC2CE   %1 15 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC2CE    Output Compare 2 clear enable
: TIM1-CCMR1_Output_OC1M_3   %1 16 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC1M_3    Output Compare 1 mode - bit 3
: TIM1-CCMR1_Output_OC2M_3   %1 24 lshift TIM1-CCMR1_Output bis! ;  \ TIM1-CCMR1_Output_OC2M_3    Output Compare 2 mode - bit 3

\ TIM1-CCMR2_Output (read-write)
: TIM1-CCMR2_Output_CC3S   ( %XX -- ) 0 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_CC3S    Capture/Compare 3 selection
: TIM1-CCMR2_Output_OC3FE   %1 2 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC3FE    Output compare 3 fast enable
: TIM1-CCMR2_Output_OC3PE   %1 3 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC3PE    Output compare 3 preload enable
: TIM1-CCMR2_Output_OC3M   ( %XXX -- ) 4 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC3M    Output compare 3 mode
: TIM1-CCMR2_Output_OC3CE   %1 7 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC3CE    Output compare 3 clear enable
: TIM1-CCMR2_Output_CC4S   ( %XX -- ) 8 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_CC4S    Capture/Compare 4 selection
: TIM1-CCMR2_Output_OC4FE   %1 10 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC4FE    Output compare 4 fast enable
: TIM1-CCMR2_Output_OC4PE   %1 11 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC4PE    Output compare 4 preload enable
: TIM1-CCMR2_Output_OC4M   ( %XXX -- ) 12 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC4M    Output compare 4 mode
: TIM1-CCMR2_Output_OC4CE   %1 15 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC4CE    Output compare 4 clear enable
: TIM1-CCMR2_Output_OC3M_3   %1 16 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC3M_3    Output Compare 3 mode - bit 3
: TIM1-CCMR2_Output_OC4M_3   %1 24 lshift TIM1-CCMR2_Output bis! ;  \ TIM1-CCMR2_Output_OC4M_3    Output Compare 4 mode - bit 3

\ TIM1-CCMR2_Input (read-write)
: TIM1-CCMR2_Input_CC3S   ( %XX -- ) 0 lshift TIM1-CCMR2_Input bis! ;  \ TIM1-CCMR2_Input_CC3S    Capture/Compare 3 selection
: TIM1-CCMR2_Input_C3PSC   ( %XX -- ) 2 lshift TIM1-CCMR2_Input bis! ;  \ TIM1-CCMR2_Input_C3PSC    Input capture 3 prescaler
: TIM1-CCMR2_Input_IC3F   ( %XXXX -- ) 4 lshift TIM1-CCMR2_Input bis! ;  \ TIM1-CCMR2_Input_IC3F    Input capture 3 filter
: TIM1-CCMR2_Input_CC4S   ( %XX -- ) 8 lshift TIM1-CCMR2_Input bis! ;  \ TIM1-CCMR2_Input_CC4S    Capture/Compare 4 selection
: TIM1-CCMR2_Input_IC4PSC   ( %XX -- ) 10 lshift TIM1-CCMR2_Input bis! ;  \ TIM1-CCMR2_Input_IC4PSC    Input capture 4 prescaler
: TIM1-CCMR2_Input_IC4F   ( %XXXX -- ) 12 lshift TIM1-CCMR2_Input bis! ;  \ TIM1-CCMR2_Input_IC4F    Input capture 4 filter

\ TIM1-CCER (read-write)
: TIM1-CCER_CC1E   %1 0 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC1E    Capture/Compare 1 output enable
: TIM1-CCER_CC1P   %1 1 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC1P    Capture/Compare 1 output Polarity
: TIM1-CCER_CC1NE   %1 2 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC1NE    Capture/Compare 1 complementary output enable
: TIM1-CCER_CC1NP   %1 3 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC1NP    Capture/Compare 1 output Polarity
: TIM1-CCER_CC2E   %1 4 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC2E    Capture/Compare 2 output enable
: TIM1-CCER_CC2P   %1 5 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC2P    Capture/Compare 2 output Polarity
: TIM1-CCER_CC2NE   %1 6 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC2NE    Capture/Compare 2 complementary output enable
: TIM1-CCER_CC2NP   %1 7 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC2NP    Capture/Compare 2 output Polarity
: TIM1-CCER_CC3E   %1 8 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC3E    Capture/Compare 3 output enable
: TIM1-CCER_CC3P   %1 9 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC3P    Capture/Compare 3 output Polarity
: TIM1-CCER_CC3NE   %1 10 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC3NE    Capture/Compare 3 complementary output enable
: TIM1-CCER_CC3NP   %1 11 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC3NP    Capture/Compare 3 output Polarity
: TIM1-CCER_CC4E   %1 12 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC4E    Capture/Compare 4 output enable
: TIM1-CCER_CC4P   %1 13 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC4P    Capture/Compare 3 output Polarity
: TIM1-CCER_CC4NP   %1 15 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC4NP    Capture/Compare 4 complementary output polarity
: TIM1-CCER_CC5E   %1 16 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC5E    Capture/Compare 5 output enable
: TIM1-CCER_CC5P   %1 17 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC5P    Capture/Compare 5 output polarity
: TIM1-CCER_CC6E   %1 20 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC6E    Capture/Compare 6 output enable
: TIM1-CCER_CC6P   %1 21 lshift TIM1-CCER bis! ;  \ TIM1-CCER_CC6P    Capture/Compare 6 output polarity

\ TIM1-CNT ()
: TIM1-CNT_CNT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CNT bis! ;  \ TIM1-CNT_CNT    counter value
: TIM1-CNT_UIFCPY   %1 31 lshift TIM1-CNT bis! ;  \ TIM1-CNT_UIFCPY    UIF copy

\ TIM1-PSC (read-write)
: TIM1-PSC_PSC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-PSC bis! ;  \ TIM1-PSC_PSC    Prescaler value

\ TIM1-ARR (read-write)
: TIM1-ARR_ARR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-ARR bis! ;  \ TIM1-ARR_ARR    Auto-reload value

\ TIM1-RCR (read-write)
: TIM1-RCR_REP   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-RCR bis! ;  \ TIM1-RCR_REP    Repetition counter value

\ TIM1-CCR1 (read-write)
: TIM1-CCR1_CCR1   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CCR1 bis! ;  \ TIM1-CCR1_CCR1    Capture/Compare 1 value

\ TIM1-CCR2 (read-write)
: TIM1-CCR2_CCR2   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CCR2 bis! ;  \ TIM1-CCR2_CCR2    Capture/Compare 2 value

\ TIM1-CCR3 (read-write)
: TIM1-CCR3_CCR3   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CCR3 bis! ;  \ TIM1-CCR3_CCR3    Capture/Compare value

\ TIM1-CCR4 (read-write)
: TIM1-CCR4_CCR4   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CCR4 bis! ;  \ TIM1-CCR4_CCR4    Capture/Compare value

\ TIM1-BDTR (read-write)
: TIM1-BDTR_DTG   ( %XXXXXXXX -- ) 0 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_DTG    Dead-time generator setup
: TIM1-BDTR_LOCK   ( %XX -- ) 8 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_LOCK    Lock configuration
: TIM1-BDTR_OSSI   %1 10 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_OSSI    Off-state selection for Idle mode
: TIM1-BDTR_OSSR   %1 11 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_OSSR    Off-state selection for Run mode
: TIM1-BDTR_BKE   %1 12 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_BKE    Break enable
: TIM1-BDTR_BKP   %1 13 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_BKP    Break polarity
: TIM1-BDTR_AOE   %1 14 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_AOE    Automatic output enable
: TIM1-BDTR_MOE   %1 15 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_MOE    Main output enable
: TIM1-BDTR_BKF   ( %XXXX -- ) 16 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_BKF    Break filter
: TIM1-BDTR_BK2F   ( %XXXX -- ) 20 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_BK2F    Break 2 filter
: TIM1-BDTR_BK2E   %1 24 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_BK2E    Break 2 enable
: TIM1-BDTR_BK2P   %1 25 lshift TIM1-BDTR bis! ;  \ TIM1-BDTR_BK2P    Break 2 polarity

\ TIM1-DCR (read-write)
: TIM1-DCR_DBL   ( %XXXXX -- ) 8 lshift TIM1-DCR bis! ;  \ TIM1-DCR_DBL    DMA burst length
: TIM1-DCR_DBA   ( %XXXXX -- ) 0 lshift TIM1-DCR bis! ;  \ TIM1-DCR_DBA    DMA base address

\ TIM1-DMAR (read-write)
: TIM1-DMAR_DMAB   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-DMAR bis! ;  \ TIM1-DMAR_DMAB    DMA register for burst accesses

\ TIM1-OR (read-write)
: TIM1-OR_TIM1_ETR_ADC1_RMP   ( %XX -- ) 0 lshift TIM1-OR bis! ;  \ TIM1-OR_TIM1_ETR_ADC1_RMP    TIM1_ETR_ADC1 remapping capability
: TIM1-OR_TI1_RMP   %1 4 lshift TIM1-OR bis! ;  \ TIM1-OR_TI1_RMP    Input Capture 1 remap

\ TIM1-CCMR3_Output (read-write)
: TIM1-CCMR3_Output_OC6M_bit3   %1 24 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC6M_bit3    Output Compare 6 mode bit 3
: TIM1-CCMR3_Output_OC5M_bit3   %1 16 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC5M_bit3    Output Compare 5 mode bit 3
: TIM1-CCMR3_Output_OC6CE   %1 15 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC6CE    Output compare 6 clear enable
: TIM1-CCMR3_Output_OC6M   ( %XXX -- ) 12 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC6M    Output compare 6 mode
: TIM1-CCMR3_Output_OC6PE   %1 11 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC6PE    Output compare 6 preload enable
: TIM1-CCMR3_Output_OC6FE   %1 10 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC6FE    Output compare 6 fast enable
: TIM1-CCMR3_Output_OC5CE   %1 7 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC5CE    Output compare 5 clear enable
: TIM1-CCMR3_Output_OC5M   ( %XXX -- ) 4 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC5M    Output compare 5 mode
: TIM1-CCMR3_Output_OC5PE   %1 3 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC5PE    Output compare 5 preload enable
: TIM1-CCMR3_Output_OC5FE   %1 2 lshift TIM1-CCMR3_Output bis! ;  \ TIM1-CCMR3_Output_OC5FE    Output compare 5 fast enable

\ TIM1-CCR5 (read-write)
: TIM1-CCR5_CCR5   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CCR5 bis! ;  \ TIM1-CCR5_CCR5    Capture/Compare value
: TIM1-CCR5_GC5C1   %1 29 lshift TIM1-CCR5 bis! ;  \ TIM1-CCR5_GC5C1    Group Channel 5 and Channel 1
: TIM1-CCR5_GC5C2   %1 30 lshift TIM1-CCR5 bis! ;  \ TIM1-CCR5_GC5C2    Group Channel 5 and Channel 2
: TIM1-CCR5_GC5C3   %1 31 lshift TIM1-CCR5 bis! ;  \ TIM1-CCR5_GC5C3    Group Channel 5 and Channel 3

\ TIM1-CCR6 (read-write)
: TIM1-CCR6_CCR6   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift TIM1-CCR6 bis! ;  \ TIM1-CCR6_CCR6    Capture/Compare value

\ TIM1-AF1 (read-write)
: TIM1-AF1_BKINE   %1 0 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_BKINE    BRK BKIN input enable
: TIM1-AF1_BKCMP1E   %1 1 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_BKCMP1E    BRK COMP1 enable
: TIM1-AF1_BKCMP2E   %1 2 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_BKCMP2E    BRK COMP2 enable
: TIM1-AF1_BKINP   %1 9 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_BKINP    BRK BKIN input polarity
: TIM1-AF1_BKCMP1P   %1 10 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_BKCMP1P    BRK COMP1 input polarity
: TIM1-AF1_BKCMP2P   %1 11 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_BKCMP2P    BRK COMP2 input polarity
: TIM1-AF1_ETRSEL   ( %XXX -- ) 14 lshift TIM1-AF1 bis! ;  \ TIM1-AF1_ETRSEL    ETR source selection

\ TIM1-AF2 (read-write)
: TIM1-AF2_BK2INE   %1 0 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2INE    BRK2 BKIN input enable
: TIM1-AF2_BK2CMP1E   %1 1 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2CMP1E    BRK2 COMP1 enable
: TIM1-AF2_BK2CMP2E   %1 2 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2CMP2E    BRK2 COMP2 enable
: TIM1-AF2_BK2DFBK0E   %1 8 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2DFBK0E    BRK2 DFSDM_BREAK0 enable
: TIM1-AF2_BK2INP   %1 9 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2INP    BRK2 BKIN input polarity
: TIM1-AF2_BK2CMP1P   %1 10 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2CMP1P    BRK2 COMP1 input polarity
: TIM1-AF2_BK2CMP2P   %1 11 lshift TIM1-AF2 bis! ;  \ TIM1-AF2_BK2CMP2P    BRK2 COMP2 input polarity

\ LPTIM1-ISR (read-only)
: LPTIM1-ISR_DOWN   %1 6 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_DOWN    Counter direction change up to down
: LPTIM1-ISR_UP   %1 5 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_UP    Counter direction change down to up
: LPTIM1-ISR_ARROK   %1 4 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_ARROK    Autoreload register update OK
: LPTIM1-ISR_CMPOK   %1 3 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_CMPOK    Compare register update OK
: LPTIM1-ISR_EXTTRIG   %1 2 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_EXTTRIG    External trigger edge event
: LPTIM1-ISR_ARRM   %1 1 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_ARRM    Autoreload match
: LPTIM1-ISR_CMPM   %1 0 lshift LPTIM1-ISR bis! ;  \ LPTIM1-ISR_CMPM    Compare match

\ LPTIM1-ICR (write-only)
: LPTIM1-ICR_DOWNCF   %1 6 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_DOWNCF    Direction change to down Clear Flag
: LPTIM1-ICR_UPCF   %1 5 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_UPCF    Direction change to UP Clear Flag
: LPTIM1-ICR_ARROKCF   %1 4 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_ARROKCF    Autoreload register update OK Clear Flag
: LPTIM1-ICR_CMPOKCF   %1 3 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_CMPOKCF    Compare register update OK Clear Flag
: LPTIM1-ICR_EXTTRIGCF   %1 2 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_EXTTRIGCF    External trigger valid edge Clear Flag
: LPTIM1-ICR_ARRMCF   %1 1 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_ARRMCF    Autoreload match Clear Flag
: LPTIM1-ICR_CMPMCF   %1 0 lshift LPTIM1-ICR bis! ;  \ LPTIM1-ICR_CMPMCF    compare match Clear Flag

\ LPTIM1-IER (read-write)
: LPTIM1-IER_DOWNIE   %1 6 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_DOWNIE    Direction change to down Interrupt Enable
: LPTIM1-IER_UPIE   %1 5 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_UPIE    Direction change to UP Interrupt Enable
: LPTIM1-IER_ARROKIE   %1 4 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_ARROKIE    Autoreload register update OK Interrupt Enable
: LPTIM1-IER_CMPOKIE   %1 3 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_CMPOKIE    Compare register update OK Interrupt Enable
: LPTIM1-IER_EXTTRIGIE   %1 2 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_EXTTRIGIE    External trigger valid edge Interrupt Enable
: LPTIM1-IER_ARRMIE   %1 1 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_ARRMIE    Autoreload match Interrupt Enable
: LPTIM1-IER_CMPMIE   %1 0 lshift LPTIM1-IER bis! ;  \ LPTIM1-IER_CMPMIE    Compare match Interrupt Enable

\ LPTIM1-CFGR (read-write)
: LPTIM1-CFGR_ENC   %1 24 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_ENC    Encoder mode enable
: LPTIM1-CFGR_COUNTMODE   %1 23 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_COUNTMODE    counter mode enabled
: LPTIM1-CFGR_PRELOAD   %1 22 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_PRELOAD    Registers update mode
: LPTIM1-CFGR_WAVPOL   %1 21 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_WAVPOL    Waveform shape polarity
: LPTIM1-CFGR_WAVE   %1 20 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_WAVE    Waveform shape
: LPTIM1-CFGR_TIMOUT   %1 19 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_TIMOUT    Timeout enable
: LPTIM1-CFGR_TRIGEN   ( %XX -- ) 17 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_TRIGEN    Trigger enable and polarity
: LPTIM1-CFGR_TRIGSEL   ( %XXX -- ) 13 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_TRIGSEL    Trigger selector
: LPTIM1-CFGR_PRESC   ( %XXX -- ) 9 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_PRESC    Clock prescaler
: LPTIM1-CFGR_TRGFLT   ( %XX -- ) 6 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_TRGFLT    Configurable digital filter for trigger
: LPTIM1-CFGR_CKFLT   ( %XX -- ) 3 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_CKFLT    Configurable digital filter for external clock
: LPTIM1-CFGR_CKPOL   ( %XX -- ) 1 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_CKPOL    Clock Polarity
: LPTIM1-CFGR_CKSEL   %1 0 lshift LPTIM1-CFGR bis! ;  \ LPTIM1-CFGR_CKSEL    Clock selector

\ LPTIM1-CR (read-write)
: LPTIM1-CR_RSTARE   %1 4 lshift LPTIM1-CR bis! ;  \ LPTIM1-CR_RSTARE    Reset after read enable
: LPTIM1-CR_COUNTRST   %1 3 lshift LPTIM1-CR bis! ;  \ LPTIM1-CR_COUNTRST    Counter reset
: LPTIM1-CR_CNTSTRT   %1 2 lshift LPTIM1-CR bis! ;  \ LPTIM1-CR_CNTSTRT    Timer start in continuous mode
: LPTIM1-CR_SNGSTRT   %1 1 lshift LPTIM1-CR bis! ;  \ LPTIM1-CR_SNGSTRT    LPTIM start in single mode
: LPTIM1-CR_ENABLE   %1 0 lshift LPTIM1-CR bis! ;  \ LPTIM1-CR_ENABLE    LPTIM Enable

\ LPTIM1-CMP (read-write)
: LPTIM1-CMP_CMP   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPTIM1-CMP bis! ;  \ LPTIM1-CMP_CMP    Compare value

\ LPTIM1-ARR (read-write)
: LPTIM1-ARR_ARR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPTIM1-ARR bis! ;  \ LPTIM1-ARR_ARR    Auto reload value

\ LPTIM1-CNT (read-only)
: LPTIM1-CNT_CNT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPTIM1-CNT bis! ;  \ LPTIM1-CNT_CNT    Counter value

\ LPTIM1-OR (read-write)
: LPTIM1-OR_OR1   %1 0 lshift LPTIM1-OR bis! ;  \ LPTIM1-OR_OR1    Option register bit 1
: LPTIM1-OR_OR2   %1 1 lshift LPTIM1-OR bis! ;  \ LPTIM1-OR_OR2    Option register bit 2

\ LPTIM2-ISR (read-only)
: LPTIM2-ISR_DOWN   %1 6 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_DOWN    Counter direction change up to down
: LPTIM2-ISR_UP   %1 5 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_UP    Counter direction change down to up
: LPTIM2-ISR_ARROK   %1 4 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_ARROK    Autoreload register update OK
: LPTIM2-ISR_CMPOK   %1 3 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_CMPOK    Compare register update OK
: LPTIM2-ISR_EXTTRIG   %1 2 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_EXTTRIG    External trigger edge event
: LPTIM2-ISR_ARRM   %1 1 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_ARRM    Autoreload match
: LPTIM2-ISR_CMPM   %1 0 lshift LPTIM2-ISR bis! ;  \ LPTIM2-ISR_CMPM    Compare match

\ LPTIM2-ICR (write-only)
: LPTIM2-ICR_DOWNCF   %1 6 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_DOWNCF    Direction change to down Clear Flag
: LPTIM2-ICR_UPCF   %1 5 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_UPCF    Direction change to UP Clear Flag
: LPTIM2-ICR_ARROKCF   %1 4 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_ARROKCF    Autoreload register update OK Clear Flag
: LPTIM2-ICR_CMPOKCF   %1 3 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_CMPOKCF    Compare register update OK Clear Flag
: LPTIM2-ICR_EXTTRIGCF   %1 2 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_EXTTRIGCF    External trigger valid edge Clear Flag
: LPTIM2-ICR_ARRMCF   %1 1 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_ARRMCF    Autoreload match Clear Flag
: LPTIM2-ICR_CMPMCF   %1 0 lshift LPTIM2-ICR bis! ;  \ LPTIM2-ICR_CMPMCF    compare match Clear Flag

\ LPTIM2-IER (read-write)
: LPTIM2-IER_DOWNIE   %1 6 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_DOWNIE    Direction change to down Interrupt Enable
: LPTIM2-IER_UPIE   %1 5 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_UPIE    Direction change to UP Interrupt Enable
: LPTIM2-IER_ARROKIE   %1 4 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_ARROKIE    Autoreload register update OK Interrupt Enable
: LPTIM2-IER_CMPOKIE   %1 3 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_CMPOKIE    Compare register update OK Interrupt Enable
: LPTIM2-IER_EXTTRIGIE   %1 2 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_EXTTRIGIE    External trigger valid edge Interrupt Enable
: LPTIM2-IER_ARRMIE   %1 1 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_ARRMIE    Autoreload match Interrupt Enable
: LPTIM2-IER_CMPMIE   %1 0 lshift LPTIM2-IER bis! ;  \ LPTIM2-IER_CMPMIE    Compare match Interrupt Enable

\ LPTIM2-CFGR (read-write)
: LPTIM2-CFGR_ENC   %1 24 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_ENC    Encoder mode enable
: LPTIM2-CFGR_COUNTMODE   %1 23 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_COUNTMODE    counter mode enabled
: LPTIM2-CFGR_PRELOAD   %1 22 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_PRELOAD    Registers update mode
: LPTIM2-CFGR_WAVPOL   %1 21 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_WAVPOL    Waveform shape polarity
: LPTIM2-CFGR_WAVE   %1 20 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_WAVE    Waveform shape
: LPTIM2-CFGR_TIMOUT   %1 19 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_TIMOUT    Timeout enable
: LPTIM2-CFGR_TRIGEN   ( %XX -- ) 17 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_TRIGEN    Trigger enable and polarity
: LPTIM2-CFGR_TRIGSEL   ( %XXX -- ) 13 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_TRIGSEL    Trigger selector
: LPTIM2-CFGR_PRESC   ( %XXX -- ) 9 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_PRESC    Clock prescaler
: LPTIM2-CFGR_TRGFLT   ( %XX -- ) 6 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_TRGFLT    Configurable digital filter for trigger
: LPTIM2-CFGR_CKFLT   ( %XX -- ) 3 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_CKFLT    Configurable digital filter for external clock
: LPTIM2-CFGR_CKPOL   ( %XX -- ) 1 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_CKPOL    Clock Polarity
: LPTIM2-CFGR_CKSEL   %1 0 lshift LPTIM2-CFGR bis! ;  \ LPTIM2-CFGR_CKSEL    Clock selector

\ LPTIM2-CR (read-write)
: LPTIM2-CR_RSTARE   %1 4 lshift LPTIM2-CR bis! ;  \ LPTIM2-CR_RSTARE    Reset after read enable
: LPTIM2-CR_COUNTRST   %1 3 lshift LPTIM2-CR bis! ;  \ LPTIM2-CR_COUNTRST    Counter reset
: LPTIM2-CR_CNTSTRT   %1 2 lshift LPTIM2-CR bis! ;  \ LPTIM2-CR_CNTSTRT    Timer start in continuous mode
: LPTIM2-CR_SNGSTRT   %1 1 lshift LPTIM2-CR bis! ;  \ LPTIM2-CR_SNGSTRT    LPTIM start in single mode
: LPTIM2-CR_ENABLE   %1 0 lshift LPTIM2-CR bis! ;  \ LPTIM2-CR_ENABLE    LPTIM Enable

\ LPTIM2-CMP (read-write)
: LPTIM2-CMP_CMP   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPTIM2-CMP bis! ;  \ LPTIM2-CMP_CMP    Compare value

\ LPTIM2-ARR (read-write)
: LPTIM2-ARR_ARR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPTIM2-ARR bis! ;  \ LPTIM2-ARR_ARR    Auto reload value

\ LPTIM2-CNT (read-only)
: LPTIM2-CNT_CNT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPTIM2-CNT bis! ;  \ LPTIM2-CNT_CNT    Counter value

\ LPTIM2-OR (read-write)
: LPTIM2-OR_OR1   %1 0 lshift LPTIM2-OR bis! ;  \ LPTIM2-OR_OR1    Option register bit 1
: LPTIM2-OR_OR2   %1 1 lshift LPTIM2-OR bis! ;  \ LPTIM2-OR_OR2    Option register bit 2

\ USART1-CR1 (read-write)
: USART1-CR1_RXFFIE   %1 31 lshift USART1-CR1 bis! ;  \ USART1-CR1_RXFFIE    RXFIFO Full interrupt enable
: USART1-CR1_TXFEIE   %1 30 lshift USART1-CR1 bis! ;  \ USART1-CR1_TXFEIE    TXFIFO empty interrupt enable
: USART1-CR1_FIFOEN   %1 29 lshift USART1-CR1 bis! ;  \ USART1-CR1_FIFOEN    FIFO mode enable
: USART1-CR1_M1   %1 28 lshift USART1-CR1 bis! ;  \ USART1-CR1_M1    Word length
: USART1-CR1_EOBIE   %1 27 lshift USART1-CR1 bis! ;  \ USART1-CR1_EOBIE    End of Block interrupt enable
: USART1-CR1_RTOIE   %1 26 lshift USART1-CR1 bis! ;  \ USART1-CR1_RTOIE    Receiver timeout interrupt enable
: USART1-CR1_DEAT4   %1 25 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEAT4    Driver Enable assertion time
: USART1-CR1_DEAT3   %1 24 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEAT3    DEAT3
: USART1-CR1_DEAT2   %1 23 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEAT2    DEAT2
: USART1-CR1_DEAT1   %1 22 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEAT1    DEAT1
: USART1-CR1_DEAT0   %1 21 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEAT0    DEAT0
: USART1-CR1_DEDT4   %1 20 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEDT4    Driver Enable de-assertion time
: USART1-CR1_DEDT3   %1 19 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEDT3    DEDT3
: USART1-CR1_DEDT2   %1 18 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEDT2    DEDT2
: USART1-CR1_DEDT1   %1 17 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEDT1    DEDT1
: USART1-CR1_DEDT0   %1 16 lshift USART1-CR1 bis! ;  \ USART1-CR1_DEDT0    DEDT0
: USART1-CR1_OVER8   %1 15 lshift USART1-CR1 bis! ;  \ USART1-CR1_OVER8    Oversampling mode
: USART1-CR1_CMIE   %1 14 lshift USART1-CR1 bis! ;  \ USART1-CR1_CMIE    Character match interrupt enable
: USART1-CR1_MME   %1 13 lshift USART1-CR1 bis! ;  \ USART1-CR1_MME    Mute mode enable
: USART1-CR1_M0   %1 12 lshift USART1-CR1 bis! ;  \ USART1-CR1_M0    Word length
: USART1-CR1_WAKE   %1 11 lshift USART1-CR1 bis! ;  \ USART1-CR1_WAKE    Receiver wakeup method
: USART1-CR1_PCE   %1 10 lshift USART1-CR1 bis! ;  \ USART1-CR1_PCE    Parity control enable
: USART1-CR1_PS   %1 9 lshift USART1-CR1 bis! ;  \ USART1-CR1_PS    Parity selection
: USART1-CR1_PEIE   %1 8 lshift USART1-CR1 bis! ;  \ USART1-CR1_PEIE    PE interrupt enable
: USART1-CR1_TXEIE   %1 7 lshift USART1-CR1 bis! ;  \ USART1-CR1_TXEIE    interrupt enable
: USART1-CR1_TCIE   %1 6 lshift USART1-CR1 bis! ;  \ USART1-CR1_TCIE    Transmission complete interrupt enable
: USART1-CR1_RXNEIE   %1 5 lshift USART1-CR1 bis! ;  \ USART1-CR1_RXNEIE    RXNE interrupt enable
: USART1-CR1_IDLEIE   %1 4 lshift USART1-CR1 bis! ;  \ USART1-CR1_IDLEIE    IDLE interrupt enable
: USART1-CR1_TE   %1 3 lshift USART1-CR1 bis! ;  \ USART1-CR1_TE    Transmitter enable
: USART1-CR1_RE   %1 2 lshift USART1-CR1 bis! ;  \ USART1-CR1_RE    Receiver enable
: USART1-CR1_UESM   %1 1 lshift USART1-CR1 bis! ;  \ USART1-CR1_UESM    USART enable in Stop mode
: USART1-CR1_UE   %1 0 lshift USART1-CR1 bis! ;  \ USART1-CR1_UE    USART enable

\ USART1-CR2 (read-write)
: USART1-CR2_ADD4_7   ( %XXXX -- ) 28 lshift USART1-CR2 bis! ;  \ USART1-CR2_ADD4_7    Address of the USART node
: USART1-CR2_ADD0_3   ( %XXXX -- ) 24 lshift USART1-CR2 bis! ;  \ USART1-CR2_ADD0_3    Address of the USART node
: USART1-CR2_RTOEN   %1 23 lshift USART1-CR2 bis! ;  \ USART1-CR2_RTOEN    Receiver timeout enable
: USART1-CR2_ABRMOD1   %1 22 lshift USART1-CR2 bis! ;  \ USART1-CR2_ABRMOD1    Auto baud rate mode
: USART1-CR2_ABRMOD0   %1 21 lshift USART1-CR2 bis! ;  \ USART1-CR2_ABRMOD0    ABRMOD0
: USART1-CR2_ABREN   %1 20 lshift USART1-CR2 bis! ;  \ USART1-CR2_ABREN    Auto baud rate enable
: USART1-CR2_MSBFIRST   %1 19 lshift USART1-CR2 bis! ;  \ USART1-CR2_MSBFIRST    Most significant bit first
: USART1-CR2_TAINV   %1 18 lshift USART1-CR2 bis! ;  \ USART1-CR2_TAINV    Binary data inversion
: USART1-CR2_TXINV   %1 17 lshift USART1-CR2 bis! ;  \ USART1-CR2_TXINV    TX pin active level inversion
: USART1-CR2_RXINV   %1 16 lshift USART1-CR2 bis! ;  \ USART1-CR2_RXINV    RX pin active level inversion
: USART1-CR2_SWAP   %1 15 lshift USART1-CR2 bis! ;  \ USART1-CR2_SWAP    Swap TX/RX pins
: USART1-CR2_LINEN   %1 14 lshift USART1-CR2 bis! ;  \ USART1-CR2_LINEN    LIN mode enable
: USART1-CR2_STOP   ( %XX -- ) 12 lshift USART1-CR2 bis! ;  \ USART1-CR2_STOP    STOP bits
: USART1-CR2_CLKEN   %1 11 lshift USART1-CR2 bis! ;  \ USART1-CR2_CLKEN    Clock enable
: USART1-CR2_CPOL   %1 10 lshift USART1-CR2 bis! ;  \ USART1-CR2_CPOL    Clock polarity
: USART1-CR2_CPHA   %1 9 lshift USART1-CR2 bis! ;  \ USART1-CR2_CPHA    Clock phase
: USART1-CR2_LBCL   %1 8 lshift USART1-CR2 bis! ;  \ USART1-CR2_LBCL    Last bit clock pulse
: USART1-CR2_LBDIE   %1 6 lshift USART1-CR2 bis! ;  \ USART1-CR2_LBDIE    LIN break detection interrupt enable
: USART1-CR2_LBDL   %1 5 lshift USART1-CR2 bis! ;  \ USART1-CR2_LBDL    LIN break detection length
: USART1-CR2_ADDM7   %1 4 lshift USART1-CR2 bis! ;  \ USART1-CR2_ADDM7    7-bit Address Detection/4-bit Address Detection
: USART1-CR2_DIS_NSS   %1 3 lshift USART1-CR2 bis! ;  \ USART1-CR2_DIS_NSS    When the DSI_NSS bit is set, the NSS pin input will be ignored
: USART1-CR2_SLVEN   %1 0 lshift USART1-CR2 bis! ;  \ USART1-CR2_SLVEN    Synchronous Slave mode enable

\ USART1-CR3 (read-write)
: USART1-CR3_TXFTCFG   ( %XXX -- ) 29 lshift USART1-CR3 bis! ;  \ USART1-CR3_TXFTCFG    TXFIFO threshold configuration
: USART1-CR3_RXFTIE   %1 28 lshift USART1-CR3 bis! ;  \ USART1-CR3_RXFTIE    RXFIFO threshold interrupt enable
: USART1-CR3_RXFTCFG   ( %XXX -- ) 25 lshift USART1-CR3 bis! ;  \ USART1-CR3_RXFTCFG    Receive FIFO threshold configuration
: USART1-CR3_TCBGTIE   %1 24 lshift USART1-CR3 bis! ;  \ USART1-CR3_TCBGTIE    Tr Complete before guard time, interrupt enable
: USART1-CR3_TXFTIE   %1 23 lshift USART1-CR3 bis! ;  \ USART1-CR3_TXFTIE    threshold interrupt enable
: USART1-CR3_WUFIE   %1 22 lshift USART1-CR3 bis! ;  \ USART1-CR3_WUFIE    Wakeup from Stop mode interrupt enable
: USART1-CR3_WUS   ( %XX -- ) 20 lshift USART1-CR3 bis! ;  \ USART1-CR3_WUS    Wakeup from Stop mode interrupt flag selection
: USART1-CR3_SCARCNT   ( %XXX -- ) 17 lshift USART1-CR3 bis! ;  \ USART1-CR3_SCARCNT    Smartcard auto-retry count
: USART1-CR3_DEP   %1 15 lshift USART1-CR3 bis! ;  \ USART1-CR3_DEP    Driver enable polarity selection
: USART1-CR3_DEM   %1 14 lshift USART1-CR3 bis! ;  \ USART1-CR3_DEM    Driver enable mode
: USART1-CR3_DDRE   %1 13 lshift USART1-CR3 bis! ;  \ USART1-CR3_DDRE    DMA Disable on Reception Error
: USART1-CR3_OVRDIS   %1 12 lshift USART1-CR3 bis! ;  \ USART1-CR3_OVRDIS    Overrun Disable
: USART1-CR3_ONEBIT   %1 11 lshift USART1-CR3 bis! ;  \ USART1-CR3_ONEBIT    One sample bit method enable
: USART1-CR3_CTSIE   %1 10 lshift USART1-CR3 bis! ;  \ USART1-CR3_CTSIE    CTS interrupt enable
: USART1-CR3_CTSE   %1 9 lshift USART1-CR3 bis! ;  \ USART1-CR3_CTSE    CTS enable
: USART1-CR3_RTSE   %1 8 lshift USART1-CR3 bis! ;  \ USART1-CR3_RTSE    RTS enable
: USART1-CR3_DMAT   %1 7 lshift USART1-CR3 bis! ;  \ USART1-CR3_DMAT    DMA enable transmitter
: USART1-CR3_DMAR   %1 6 lshift USART1-CR3 bis! ;  \ USART1-CR3_DMAR    DMA enable receiver
: USART1-CR3_SCEN   %1 5 lshift USART1-CR3 bis! ;  \ USART1-CR3_SCEN    Smartcard mode enable
: USART1-CR3_NACK   %1 4 lshift USART1-CR3 bis! ;  \ USART1-CR3_NACK    Smartcard NACK enable
: USART1-CR3_HDSEL   %1 3 lshift USART1-CR3 bis! ;  \ USART1-CR3_HDSEL    Half-duplex selection
: USART1-CR3_IRLP   %1 2 lshift USART1-CR3 bis! ;  \ USART1-CR3_IRLP    Ir low-power
: USART1-CR3_IREN   %1 1 lshift USART1-CR3 bis! ;  \ USART1-CR3_IREN    Ir mode enable
: USART1-CR3_EIE   %1 0 lshift USART1-CR3 bis! ;  \ USART1-CR3_EIE    Error interrupt enable

\ USART1-BRR (read-write)
: USART1-BRR_BRR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift USART1-BRR bis! ;  \ USART1-BRR_BRR    BRR_4_15

\ USART1-GTPR (read-write)
: USART1-GTPR_GT   ( %XXXXXXXX -- ) 8 lshift USART1-GTPR bis! ;  \ USART1-GTPR_GT    Guard time value
: USART1-GTPR_PSC   ( %XXXXXXXX -- ) 0 lshift USART1-GTPR bis! ;  \ USART1-GTPR_PSC    Prescaler value

\ USART1-RTOR (read-write)
: USART1-RTOR_BLEN   ( %XXXXXXXX -- ) 24 lshift USART1-RTOR bis! ;  \ USART1-RTOR_BLEN    Block Length
: USART1-RTOR_RTO   ( %XXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift USART1-RTOR bis! ;  \ USART1-RTOR_RTO    Receiver timeout value

\ USART1-RQR (write-only)
: USART1-RQR_TXFRQ   %1 4 lshift USART1-RQR bis! ;  \ USART1-RQR_TXFRQ    Transmit data flush request
: USART1-RQR_RXFRQ   %1 3 lshift USART1-RQR bis! ;  \ USART1-RQR_RXFRQ    Receive data flush request
: USART1-RQR_MMRQ   %1 2 lshift USART1-RQR bis! ;  \ USART1-RQR_MMRQ    Mute mode request
: USART1-RQR_SBKRQ   %1 1 lshift USART1-RQR bis! ;  \ USART1-RQR_SBKRQ    Send break request
: USART1-RQR_ABRRQ   %1 0 lshift USART1-RQR bis! ;  \ USART1-RQR_ABRRQ    Auto baud rate request

\ USART1-ISR (read-only)
: USART1-ISR_TXFT   %1 27 lshift USART1-ISR bis! ;  \ USART1-ISR_TXFT    TXFIFO threshold flag
: USART1-ISR_RXFT   %1 26 lshift USART1-ISR bis! ;  \ USART1-ISR_RXFT    RXFIFO threshold flag
: USART1-ISR_TCBGT   %1 25 lshift USART1-ISR bis! ;  \ USART1-ISR_TCBGT    Transmission complete before guard time flag
: USART1-ISR_RXFF   %1 24 lshift USART1-ISR bis! ;  \ USART1-ISR_RXFF    RXFIFO Full
: USART1-ISR_TXFE   %1 23 lshift USART1-ISR bis! ;  \ USART1-ISR_TXFE    TXFIFO Empty
: USART1-ISR_REACK   %1 22 lshift USART1-ISR bis! ;  \ USART1-ISR_REACK    REACK
: USART1-ISR_TEACK   %1 21 lshift USART1-ISR bis! ;  \ USART1-ISR_TEACK    TEACK
: USART1-ISR_WUF   %1 20 lshift USART1-ISR bis! ;  \ USART1-ISR_WUF    WUF
: USART1-ISR_RWU   %1 19 lshift USART1-ISR bis! ;  \ USART1-ISR_RWU    RWU
: USART1-ISR_SBKF   %1 18 lshift USART1-ISR bis! ;  \ USART1-ISR_SBKF    SBKF
: USART1-ISR_CMF   %1 17 lshift USART1-ISR bis! ;  \ USART1-ISR_CMF    CMF
: USART1-ISR_BUSY   %1 16 lshift USART1-ISR bis! ;  \ USART1-ISR_BUSY    BUSY
: USART1-ISR_ABRF   %1 15 lshift USART1-ISR bis! ;  \ USART1-ISR_ABRF    ABRF
: USART1-ISR_ABRE   %1 14 lshift USART1-ISR bis! ;  \ USART1-ISR_ABRE    ABRE
: USART1-ISR_UDR   %1 13 lshift USART1-ISR bis! ;  \ USART1-ISR_UDR    SPI slave underrun error flag
: USART1-ISR_EOBF   %1 12 lshift USART1-ISR bis! ;  \ USART1-ISR_EOBF    EOBF
: USART1-ISR_RTOF   %1 11 lshift USART1-ISR bis! ;  \ USART1-ISR_RTOF    RTOF
: USART1-ISR_CTS   %1 10 lshift USART1-ISR bis! ;  \ USART1-ISR_CTS    CTS
: USART1-ISR_CTSIF   %1 9 lshift USART1-ISR bis! ;  \ USART1-ISR_CTSIF    CTSIF
: USART1-ISR_LBDF   %1 8 lshift USART1-ISR bis! ;  \ USART1-ISR_LBDF    LBDF
: USART1-ISR_TXE   %1 7 lshift USART1-ISR bis! ;  \ USART1-ISR_TXE    TXE
: USART1-ISR_TC   %1 6 lshift USART1-ISR bis! ;  \ USART1-ISR_TC    TC
: USART1-ISR_RXNE   %1 5 lshift USART1-ISR bis! ;  \ USART1-ISR_RXNE    RXNE
: USART1-ISR_IDLE   %1 4 lshift USART1-ISR bis! ;  \ USART1-ISR_IDLE    IDLE
: USART1-ISR_ORE   %1 3 lshift USART1-ISR bis! ;  \ USART1-ISR_ORE    ORE
: USART1-ISR_NF   %1 2 lshift USART1-ISR bis! ;  \ USART1-ISR_NF    NF
: USART1-ISR_FE   %1 1 lshift USART1-ISR bis! ;  \ USART1-ISR_FE    FE
: USART1-ISR_PE   %1 0 lshift USART1-ISR bis! ;  \ USART1-ISR_PE    PE

\ USART1-ICR (write-only)
: USART1-ICR_WUCF   %1 20 lshift USART1-ICR bis! ;  \ USART1-ICR_WUCF    Wakeup from Stop mode clear flag
: USART1-ICR_CMCF   %1 17 lshift USART1-ICR bis! ;  \ USART1-ICR_CMCF    Character match clear flag
: USART1-ICR_UDRCF   %1 13 lshift USART1-ICR bis! ;  \ USART1-ICR_UDRCF    SPI slave underrun clear flag
: USART1-ICR_EOBCF   %1 12 lshift USART1-ICR bis! ;  \ USART1-ICR_EOBCF    End of block clear flag
: USART1-ICR_RTOCF   %1 11 lshift USART1-ICR bis! ;  \ USART1-ICR_RTOCF    Receiver timeout clear flag
: USART1-ICR_CTSCF   %1 9 lshift USART1-ICR bis! ;  \ USART1-ICR_CTSCF    CTS clear flag
: USART1-ICR_LBDCF   %1 8 lshift USART1-ICR bis! ;  \ USART1-ICR_LBDCF    LIN break detection clear flag
: USART1-ICR_TCBGTCF   %1 7 lshift USART1-ICR bis! ;  \ USART1-ICR_TCBGTCF    Transmission complete before Guard time clear flag
: USART1-ICR_TCCF   %1 6 lshift USART1-ICR bis! ;  \ USART1-ICR_TCCF    Transmission complete clear flag
: USART1-ICR_TXFECF   %1 5 lshift USART1-ICR bis! ;  \ USART1-ICR_TXFECF    TXFIFO empty clear flag
: USART1-ICR_IDLECF   %1 4 lshift USART1-ICR bis! ;  \ USART1-ICR_IDLECF    Idle line detected clear flag
: USART1-ICR_ORECF   %1 3 lshift USART1-ICR bis! ;  \ USART1-ICR_ORECF    Overrun error clear flag
: USART1-ICR_NCF   %1 2 lshift USART1-ICR bis! ;  \ USART1-ICR_NCF    Noise detected clear flag
: USART1-ICR_FECF   %1 1 lshift USART1-ICR bis! ;  \ USART1-ICR_FECF    Framing error clear flag
: USART1-ICR_PECF   %1 0 lshift USART1-ICR bis! ;  \ USART1-ICR_PECF    Parity error clear flag

\ USART1-RDR (read-only)
: USART1-RDR_RDR   ( %XXXXXXXXX -- ) 0 lshift USART1-RDR bis! ;  \ USART1-RDR_RDR    Receive data value

\ USART1-TDR (read-write)
: USART1-TDR_TDR   ( %XXXXXXXXX -- ) 0 lshift USART1-TDR bis! ;  \ USART1-TDR_TDR    Transmit data value

\ USART1-PRESC (read-write)
: USART1-PRESC_PRESCALER   ( %XXXX -- ) 0 lshift USART1-PRESC bis! ;  \ USART1-PRESC_PRESCALER    Clock prescaler

\ LPUART1-CR1 (read-write)
: LPUART1-CR1_RXFFIE   %1 31 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_RXFFIE    RXFIFO Full interrupt enable
: LPUART1-CR1_TXFEIE   %1 30 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_TXFEIE    TXFIFO empty interrupt enable
: LPUART1-CR1_FIFOEN   %1 29 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_FIFOEN    FIFO mode enable
: LPUART1-CR1_M1   %1 28 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_M1    Word length
: LPUART1-CR1_EOBIE   %1 27 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_EOBIE    End of Block interrupt enable
: LPUART1-CR1_RTOIE   %1 26 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_RTOIE    Receiver timeout interrupt enable
: LPUART1-CR1_DEAT4   %1 25 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEAT4    Driver Enable assertion time
: LPUART1-CR1_DEAT3   %1 24 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEAT3    DEAT3
: LPUART1-CR1_DEAT2   %1 23 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEAT2    DEAT2
: LPUART1-CR1_DEAT1   %1 22 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEAT1    DEAT1
: LPUART1-CR1_DEAT0   %1 21 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEAT0    DEAT0
: LPUART1-CR1_DEDT4   %1 20 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEDT4    Driver Enable de-assertion time
: LPUART1-CR1_DEDT3   %1 19 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEDT3    DEDT3
: LPUART1-CR1_DEDT2   %1 18 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEDT2    DEDT2
: LPUART1-CR1_DEDT1   %1 17 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEDT1    DEDT1
: LPUART1-CR1_DEDT0   %1 16 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_DEDT0    DEDT0
: LPUART1-CR1_OVER8   %1 15 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_OVER8    Oversampling mode
: LPUART1-CR1_CMIE   %1 14 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_CMIE    Character match interrupt enable
: LPUART1-CR1_MME   %1 13 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_MME    Mute mode enable
: LPUART1-CR1_M0   %1 12 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_M0    Word length
: LPUART1-CR1_WAKE   %1 11 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_WAKE    Receiver wakeup method
: LPUART1-CR1_PCE   %1 10 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_PCE    Parity control enable
: LPUART1-CR1_PS   %1 9 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_PS    Parity selection
: LPUART1-CR1_PEIE   %1 8 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_PEIE    PE interrupt enable
: LPUART1-CR1_TXEIE   %1 7 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_TXEIE    interrupt enable
: LPUART1-CR1_TCIE   %1 6 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_TCIE    Transmission complete interrupt enable
: LPUART1-CR1_RXNEIE   %1 5 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_RXNEIE    RXNE interrupt enable
: LPUART1-CR1_IDLEIE   %1 4 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_IDLEIE    IDLE interrupt enable
: LPUART1-CR1_TE   %1 3 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_TE    Transmitter enable
: LPUART1-CR1_RE   %1 2 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_RE    Receiver enable
: LPUART1-CR1_UESM   %1 1 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_UESM    USART enable in Stop mode
: LPUART1-CR1_UE   %1 0 lshift LPUART1-CR1 bis! ;  \ LPUART1-CR1_UE    USART enable

\ LPUART1-CR2 (read-write)
: LPUART1-CR2_ADD4_7   ( %XXXX -- ) 28 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_ADD4_7    Address of the USART node
: LPUART1-CR2_ADD0_3   ( %XXXX -- ) 24 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_ADD0_3    Address of the USART node
: LPUART1-CR2_RTOEN   %1 23 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_RTOEN    Receiver timeout enable
: LPUART1-CR2_ABRMOD1   %1 22 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_ABRMOD1    Auto baud rate mode
: LPUART1-CR2_ABRMOD0   %1 21 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_ABRMOD0    ABRMOD0
: LPUART1-CR2_ABREN   %1 20 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_ABREN    Auto baud rate enable
: LPUART1-CR2_MSBFIRST   %1 19 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_MSBFIRST    Most significant bit first
: LPUART1-CR2_TAINV   %1 18 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_TAINV    Binary data inversion
: LPUART1-CR2_TXINV   %1 17 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_TXINV    TX pin active level inversion
: LPUART1-CR2_RXINV   %1 16 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_RXINV    RX pin active level inversion
: LPUART1-CR2_SWAP   %1 15 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_SWAP    Swap TX/RX pins
: LPUART1-CR2_LINEN   %1 14 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_LINEN    LIN mode enable
: LPUART1-CR2_STOP   ( %XX -- ) 12 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_STOP    STOP bits
: LPUART1-CR2_CLKEN   %1 11 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_CLKEN    Clock enable
: LPUART1-CR2_CPOL   %1 10 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_CPOL    Clock polarity
: LPUART1-CR2_CPHA   %1 9 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_CPHA    Clock phase
: LPUART1-CR2_LBCL   %1 8 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_LBCL    Last bit clock pulse
: LPUART1-CR2_LBDIE   %1 6 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_LBDIE    LIN break detection interrupt enable
: LPUART1-CR2_LBDL   %1 5 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_LBDL    LIN break detection length
: LPUART1-CR2_ADDM7   %1 4 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_ADDM7    7-bit Address Detection/4-bit Address Detection
: LPUART1-CR2_DIS_NSS   %1 3 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_DIS_NSS    When the DSI_NSS bit is set, the NSS pin input will be ignored
: LPUART1-CR2_SLVEN   %1 0 lshift LPUART1-CR2 bis! ;  \ LPUART1-CR2_SLVEN    Synchronous Slave mode enable

\ LPUART1-CR3 (read-write)
: LPUART1-CR3_TXFTCFG   ( %XXX -- ) 29 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_TXFTCFG    TXFIFO threshold configuration
: LPUART1-CR3_RXFTIE   %1 28 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_RXFTIE    RXFIFO threshold interrupt enable
: LPUART1-CR3_RXFTCFG   ( %XXX -- ) 25 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_RXFTCFG    Receive FIFO threshold configuration
: LPUART1-CR3_TCBGTIE   %1 24 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_TCBGTIE    Tr Complete before guard time, interrupt enable
: LPUART1-CR3_TXFTIE   %1 23 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_TXFTIE    threshold interrupt enable
: LPUART1-CR3_WUFIE   %1 22 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_WUFIE    Wakeup from Stop mode interrupt enable
: LPUART1-CR3_WUS   ( %XX -- ) 20 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_WUS    Wakeup from Stop mode interrupt flag selection
: LPUART1-CR3_SCARCNT   ( %XXX -- ) 17 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_SCARCNT    Smartcard auto-retry count
: LPUART1-CR3_DEP   %1 15 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_DEP    Driver enable polarity selection
: LPUART1-CR3_DEM   %1 14 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_DEM    Driver enable mode
: LPUART1-CR3_DDRE   %1 13 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_DDRE    DMA Disable on Reception Error
: LPUART1-CR3_OVRDIS   %1 12 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_OVRDIS    Overrun Disable
: LPUART1-CR3_ONEBIT   %1 11 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_ONEBIT    One sample bit method enable
: LPUART1-CR3_CTSIE   %1 10 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_CTSIE    CTS interrupt enable
: LPUART1-CR3_CTSE   %1 9 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_CTSE    CTS enable
: LPUART1-CR3_RTSE   %1 8 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_RTSE    RTS enable
: LPUART1-CR3_DMAT   %1 7 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_DMAT    DMA enable transmitter
: LPUART1-CR3_DMAR   %1 6 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_DMAR    DMA enable receiver
: LPUART1-CR3_SCEN   %1 5 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_SCEN    Smartcard mode enable
: LPUART1-CR3_NACK   %1 4 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_NACK    Smartcard NACK enable
: LPUART1-CR3_HDSEL   %1 3 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_HDSEL    Half-duplex selection
: LPUART1-CR3_IRLP   %1 2 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_IRLP    Ir low-power
: LPUART1-CR3_IREN   %1 1 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_IREN    Ir mode enable
: LPUART1-CR3_EIE   %1 0 lshift LPUART1-CR3 bis! ;  \ LPUART1-CR3_EIE    Error interrupt enable

\ LPUART1-BRR (read-write)
: LPUART1-BRR_BRR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift LPUART1-BRR bis! ;  \ LPUART1-BRR_BRR    BRR_4_15

\ LPUART1-GTPR (read-write)
: LPUART1-GTPR_GT   ( %XXXXXXXX -- ) 8 lshift LPUART1-GTPR bis! ;  \ LPUART1-GTPR_GT    Guard time value
: LPUART1-GTPR_PSC   ( %XXXXXXXX -- ) 0 lshift LPUART1-GTPR bis! ;  \ LPUART1-GTPR_PSC    Prescaler value

\ LPUART1-RTOR (read-write)
: LPUART1-RTOR_BLEN   ( %XXXXXXXX -- ) 24 lshift LPUART1-RTOR bis! ;  \ LPUART1-RTOR_BLEN    Block Length
: LPUART1-RTOR_RTO   ( %XXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift LPUART1-RTOR bis! ;  \ LPUART1-RTOR_RTO    Receiver timeout value

\ LPUART1-RQR (write-only)
: LPUART1-RQR_TXFRQ   %1 4 lshift LPUART1-RQR bis! ;  \ LPUART1-RQR_TXFRQ    Transmit data flush request
: LPUART1-RQR_RXFRQ   %1 3 lshift LPUART1-RQR bis! ;  \ LPUART1-RQR_RXFRQ    Receive data flush request
: LPUART1-RQR_MMRQ   %1 2 lshift LPUART1-RQR bis! ;  \ LPUART1-RQR_MMRQ    Mute mode request
: LPUART1-RQR_SBKRQ   %1 1 lshift LPUART1-RQR bis! ;  \ LPUART1-RQR_SBKRQ    Send break request
: LPUART1-RQR_ABRRQ   %1 0 lshift LPUART1-RQR bis! ;  \ LPUART1-RQR_ABRRQ    Auto baud rate request

\ LPUART1-ISR (read-only)
: LPUART1-ISR_TXFT   %1 27 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_TXFT    TXFIFO threshold flag
: LPUART1-ISR_RXFT   %1 26 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_RXFT    RXFIFO threshold flag
: LPUART1-ISR_TCBGT   %1 25 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_TCBGT    Transmission complete before guard time flag
: LPUART1-ISR_RXFF   %1 24 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_RXFF    RXFIFO Full
: LPUART1-ISR_TXFE   %1 23 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_TXFE    TXFIFO Empty
: LPUART1-ISR_REACK   %1 22 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_REACK    REACK
: LPUART1-ISR_TEACK   %1 21 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_TEACK    TEACK
: LPUART1-ISR_WUF   %1 20 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_WUF    WUF
: LPUART1-ISR_RWU   %1 19 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_RWU    RWU
: LPUART1-ISR_SBKF   %1 18 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_SBKF    SBKF
: LPUART1-ISR_CMF   %1 17 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_CMF    CMF
: LPUART1-ISR_BUSY   %1 16 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_BUSY    BUSY
: LPUART1-ISR_ABRF   %1 15 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_ABRF    ABRF
: LPUART1-ISR_ABRE   %1 14 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_ABRE    ABRE
: LPUART1-ISR_UDR   %1 13 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_UDR    SPI slave underrun error flag
: LPUART1-ISR_EOBF   %1 12 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_EOBF    EOBF
: LPUART1-ISR_RTOF   %1 11 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_RTOF    RTOF
: LPUART1-ISR_CTS   %1 10 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_CTS    CTS
: LPUART1-ISR_CTSIF   %1 9 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_CTSIF    CTSIF
: LPUART1-ISR_LBDF   %1 8 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_LBDF    LBDF
: LPUART1-ISR_TXE   %1 7 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_TXE    TXE
: LPUART1-ISR_TC   %1 6 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_TC    TC
: LPUART1-ISR_RXNE   %1 5 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_RXNE    RXNE
: LPUART1-ISR_IDLE   %1 4 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_IDLE    IDLE
: LPUART1-ISR_ORE   %1 3 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_ORE    ORE
: LPUART1-ISR_NF   %1 2 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_NF    NF
: LPUART1-ISR_FE   %1 1 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_FE    FE
: LPUART1-ISR_PE   %1 0 lshift LPUART1-ISR bis! ;  \ LPUART1-ISR_PE    PE

\ LPUART1-ICR (write-only)
: LPUART1-ICR_WUCF   %1 20 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_WUCF    Wakeup from Stop mode clear flag
: LPUART1-ICR_CMCF   %1 17 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_CMCF    Character match clear flag
: LPUART1-ICR_UDRCF   %1 13 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_UDRCF    SPI slave underrun clear flag
: LPUART1-ICR_EOBCF   %1 12 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_EOBCF    End of block clear flag
: LPUART1-ICR_RTOCF   %1 11 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_RTOCF    Receiver timeout clear flag
: LPUART1-ICR_CTSCF   %1 9 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_CTSCF    CTS clear flag
: LPUART1-ICR_LBDCF   %1 8 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_LBDCF    LIN break detection clear flag
: LPUART1-ICR_TCBGTCF   %1 7 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_TCBGTCF    Transmission complete before Guard time clear flag
: LPUART1-ICR_TCCF   %1 6 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_TCCF    Transmission complete clear flag
: LPUART1-ICR_TXFECF   %1 5 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_TXFECF    TXFIFO empty clear flag
: LPUART1-ICR_IDLECF   %1 4 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_IDLECF    Idle line detected clear flag
: LPUART1-ICR_ORECF   %1 3 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_ORECF    Overrun error clear flag
: LPUART1-ICR_NCF   %1 2 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_NCF    Noise detected clear flag
: LPUART1-ICR_FECF   %1 1 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_FECF    Framing error clear flag
: LPUART1-ICR_PECF   %1 0 lshift LPUART1-ICR bis! ;  \ LPUART1-ICR_PECF    Parity error clear flag

\ LPUART1-RDR (read-only)
: LPUART1-RDR_RDR   ( %XXXXXXXXX -- ) 0 lshift LPUART1-RDR bis! ;  \ LPUART1-RDR_RDR    Receive data value

\ LPUART1-TDR (read-write)
: LPUART1-TDR_TDR   ( %XXXXXXXXX -- ) 0 lshift LPUART1-TDR bis! ;  \ LPUART1-TDR_TDR    Transmit data value

\ LPUART1-PRESC (read-write)
: LPUART1-PRESC_PRESCALER   ( %XXXX -- ) 0 lshift LPUART1-PRESC bis! ;  \ LPUART1-PRESC_PRESCALER    Clock prescaler

\ SPI1-CR1 (read-write)
: SPI1-CR1_BIDIMODE   %1 15 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_BIDIMODE    Bidirectional data mode enable
: SPI1-CR1_BIDIOE   %1 14 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_BIDIOE    Output enable in bidirectional mode
: SPI1-CR1_CRCEN   %1 13 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_CRCEN    Hardware CRC calculation enable
: SPI1-CR1_CRCNEXT   %1 12 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_CRCNEXT    CRC transfer next
: SPI1-CR1_DFF   %1 11 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_DFF    Data frame format
: SPI1-CR1_RXONLY   %1 10 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_RXONLY    Receive only
: SPI1-CR1_SSM   %1 9 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_SSM    Software slave management
: SPI1-CR1_SSI   %1 8 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_SSI    Internal slave select
: SPI1-CR1_LSBFIRST   %1 7 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_LSBFIRST    Frame format
: SPI1-CR1_SPE   %1 6 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_SPE    SPI enable
: SPI1-CR1_BR   ( %XXX -- ) 3 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_BR    Baud rate control
: SPI1-CR1_MSTR   %1 2 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_MSTR    Master selection
: SPI1-CR1_CPOL   %1 1 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_CPOL    Clock polarity
: SPI1-CR1_CPHA   %1 0 lshift SPI1-CR1 bis! ;  \ SPI1-CR1_CPHA    Clock phase

\ SPI1-CR2 (read-write)
: SPI1-CR2_RXDMAEN   %1 0 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_RXDMAEN    Rx buffer DMA enable
: SPI1-CR2_TXDMAEN   %1 1 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_TXDMAEN    Tx buffer DMA enable
: SPI1-CR2_SSOE   %1 2 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_SSOE    SS output enable
: SPI1-CR2_NSSP   %1 3 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_NSSP    NSS pulse management
: SPI1-CR2_FRF   %1 4 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_FRF    Frame format
: SPI1-CR2_ERRIE   %1 5 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_ERRIE    Error interrupt enable
: SPI1-CR2_RXNEIE   %1 6 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_RXNEIE    RX buffer not empty interrupt enable
: SPI1-CR2_TXEIE   %1 7 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_TXEIE    Tx buffer empty interrupt enable
: SPI1-CR2_DS   ( %XXXX -- ) 8 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_DS    Data size
: SPI1-CR2_FRXTH   %1 12 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_FRXTH    FIFO reception threshold
: SPI1-CR2_LDMA_RX   %1 13 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_LDMA_RX    Last DMA transfer for reception
: SPI1-CR2_LDMA_TX   %1 14 lshift SPI1-CR2 bis! ;  \ SPI1-CR2_LDMA_TX    Last DMA transfer for transmission

\ SPI1-SR ()
: SPI1-SR_RXNE   %1 0 lshift SPI1-SR bis! ;  \ SPI1-SR_RXNE    Receive buffer not empty
: SPI1-SR_TXE   %1 1 lshift SPI1-SR bis! ;  \ SPI1-SR_TXE    Transmit buffer empty
: SPI1-SR_CRCERR   %1 4 lshift SPI1-SR bis! ;  \ SPI1-SR_CRCERR    CRC error flag
: SPI1-SR_MODF   %1 5 lshift SPI1-SR bis! ;  \ SPI1-SR_MODF    Mode fault
: SPI1-SR_OVR   %1 6 lshift SPI1-SR bis! ;  \ SPI1-SR_OVR    Overrun flag
: SPI1-SR_BSY   %1 7 lshift SPI1-SR bis! ;  \ SPI1-SR_BSY    Busy flag
: SPI1-SR_TIFRFE   %1 8 lshift SPI1-SR bis! ;  \ SPI1-SR_TIFRFE    TI frame format error
: SPI1-SR_FRLVL   ( %XX -- ) 9 lshift SPI1-SR bis! ;  \ SPI1-SR_FRLVL    FIFO reception level
: SPI1-SR_FTLVL   ( %XX -- ) 11 lshift SPI1-SR bis! ;  \ SPI1-SR_FTLVL    FIFO transmission level

\ SPI1-DR (read-write)
: SPI1-DR_DR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI1-DR bis! ;  \ SPI1-DR_DR    Data register

\ SPI1-CRCPR (read-write)
: SPI1-CRCPR_CRCPOLY   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI1-CRCPR bis! ;  \ SPI1-CRCPR_CRCPOLY    CRC polynomial register

\ SPI1-RXCRCR (read-only)
: SPI1-RXCRCR_RxCRC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI1-RXCRCR bis! ;  \ SPI1-RXCRCR_RxCRC    Rx CRC register

\ SPI1-TXCRCR (read-only)
: SPI1-TXCRCR_TxCRC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI1-TXCRCR bis! ;  \ SPI1-TXCRCR_TxCRC    Tx CRC register

\ SPI2-CR1 (read-write)
: SPI2-CR1_BIDIMODE   %1 15 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_BIDIMODE    Bidirectional data mode enable
: SPI2-CR1_BIDIOE   %1 14 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_BIDIOE    Output enable in bidirectional mode
: SPI2-CR1_CRCEN   %1 13 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_CRCEN    Hardware CRC calculation enable
: SPI2-CR1_CRCNEXT   %1 12 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_CRCNEXT    CRC transfer next
: SPI2-CR1_DFF   %1 11 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_DFF    Data frame format
: SPI2-CR1_RXONLY   %1 10 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_RXONLY    Receive only
: SPI2-CR1_SSM   %1 9 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_SSM    Software slave management
: SPI2-CR1_SSI   %1 8 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_SSI    Internal slave select
: SPI2-CR1_LSBFIRST   %1 7 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_LSBFIRST    Frame format
: SPI2-CR1_SPE   %1 6 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_SPE    SPI enable
: SPI2-CR1_BR   ( %XXX -- ) 3 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_BR    Baud rate control
: SPI2-CR1_MSTR   %1 2 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_MSTR    Master selection
: SPI2-CR1_CPOL   %1 1 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_CPOL    Clock polarity
: SPI2-CR1_CPHA   %1 0 lshift SPI2-CR1 bis! ;  \ SPI2-CR1_CPHA    Clock phase

\ SPI2-CR2 (read-write)
: SPI2-CR2_RXDMAEN   %1 0 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_RXDMAEN    Rx buffer DMA enable
: SPI2-CR2_TXDMAEN   %1 1 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_TXDMAEN    Tx buffer DMA enable
: SPI2-CR2_SSOE   %1 2 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_SSOE    SS output enable
: SPI2-CR2_NSSP   %1 3 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_NSSP    NSS pulse management
: SPI2-CR2_FRF   %1 4 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_FRF    Frame format
: SPI2-CR2_ERRIE   %1 5 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_ERRIE    Error interrupt enable
: SPI2-CR2_RXNEIE   %1 6 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_RXNEIE    RX buffer not empty interrupt enable
: SPI2-CR2_TXEIE   %1 7 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_TXEIE    Tx buffer empty interrupt enable
: SPI2-CR2_DS   ( %XXXX -- ) 8 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_DS    Data size
: SPI2-CR2_FRXTH   %1 12 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_FRXTH    FIFO reception threshold
: SPI2-CR2_LDMA_RX   %1 13 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_LDMA_RX    Last DMA transfer for reception
: SPI2-CR2_LDMA_TX   %1 14 lshift SPI2-CR2 bis! ;  \ SPI2-CR2_LDMA_TX    Last DMA transfer for transmission

\ SPI2-SR ()
: SPI2-SR_RXNE   %1 0 lshift SPI2-SR bis! ;  \ SPI2-SR_RXNE    Receive buffer not empty
: SPI2-SR_TXE   %1 1 lshift SPI2-SR bis! ;  \ SPI2-SR_TXE    Transmit buffer empty
: SPI2-SR_CRCERR   %1 4 lshift SPI2-SR bis! ;  \ SPI2-SR_CRCERR    CRC error flag
: SPI2-SR_MODF   %1 5 lshift SPI2-SR bis! ;  \ SPI2-SR_MODF    Mode fault
: SPI2-SR_OVR   %1 6 lshift SPI2-SR bis! ;  \ SPI2-SR_OVR    Overrun flag
: SPI2-SR_BSY   %1 7 lshift SPI2-SR bis! ;  \ SPI2-SR_BSY    Busy flag
: SPI2-SR_TIFRFE   %1 8 lshift SPI2-SR bis! ;  \ SPI2-SR_TIFRFE    TI frame format error
: SPI2-SR_FRLVL   ( %XX -- ) 9 lshift SPI2-SR bis! ;  \ SPI2-SR_FRLVL    FIFO reception level
: SPI2-SR_FTLVL   ( %XX -- ) 11 lshift SPI2-SR bis! ;  \ SPI2-SR_FTLVL    FIFO transmission level

\ SPI2-DR (read-write)
: SPI2-DR_DR   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI2-DR bis! ;  \ SPI2-DR_DR    Data register

\ SPI2-CRCPR (read-write)
: SPI2-CRCPR_CRCPOLY   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI2-CRCPR bis! ;  \ SPI2-CRCPR_CRCPOLY    CRC polynomial register

\ SPI2-RXCRCR (read-only)
: SPI2-RXCRCR_RxCRC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI2-RXCRCR bis! ;  \ SPI2-RXCRCR_RxCRC    Rx CRC register

\ SPI2-TXCRCR (read-only)
: SPI2-TXCRCR_TxCRC   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift SPI2-TXCRCR bis! ;  \ SPI2-TXCRCR_TxCRC    Tx CRC register

\ VREFBUF-CSR ()
: VREFBUF-CSR_ENVR   %1 0 lshift VREFBUF-CSR bis! ;  \ VREFBUF-CSR_ENVR    Voltage reference buffer enable
: VREFBUF-CSR_HIZ   %1 1 lshift VREFBUF-CSR bis! ;  \ VREFBUF-CSR_HIZ    High impedance mode
: VREFBUF-CSR_VRS   %1 2 lshift VREFBUF-CSR bis! ;  \ VREFBUF-CSR_VRS    Voltage reference scale
: VREFBUF-CSR_VRR   %1 3 lshift VREFBUF-CSR bis! ;  \ VREFBUF-CSR_VRR    Voltage reference buffer ready

\ VREFBUF-CCR (read-write)
: VREFBUF-CCR_TRIM   ( %XXXXXX -- ) 0 lshift VREFBUF-CCR bis! ;  \ VREFBUF-CCR_TRIM    Trimming code

\ RTC-TR (read-write)
: RTC-TR_PM   %1 22 lshift RTC-TR bis! ;  \ RTC-TR_PM    AM/PM notation
: RTC-TR_HT   ( %XX -- ) 20 lshift RTC-TR bis! ;  \ RTC-TR_HT    Hour tens in BCD format
: RTC-TR_HU   ( %XXXX -- ) 16 lshift RTC-TR bis! ;  \ RTC-TR_HU    Hour units in BCD format
: RTC-TR_MNT   ( %XXX -- ) 12 lshift RTC-TR bis! ;  \ RTC-TR_MNT    Minute tens in BCD format
: RTC-TR_MNU   ( %XXXX -- ) 8 lshift RTC-TR bis! ;  \ RTC-TR_MNU    Minute units in BCD format
: RTC-TR_ST   ( %XXX -- ) 4 lshift RTC-TR bis! ;  \ RTC-TR_ST    Second tens in BCD format
: RTC-TR_SU   ( %XXXX -- ) 0 lshift RTC-TR bis! ;  \ RTC-TR_SU    Second units in BCD format

\ RTC-DR (read-write)
: RTC-DR_YT   ( %XXXX -- ) 20 lshift RTC-DR bis! ;  \ RTC-DR_YT    Year tens in BCD format
: RTC-DR_YU   ( %XXXX -- ) 16 lshift RTC-DR bis! ;  \ RTC-DR_YU    Year units in BCD format
: RTC-DR_WDU   ( %XXX -- ) 13 lshift RTC-DR bis! ;  \ RTC-DR_WDU    Week day units
: RTC-DR_MT   %1 12 lshift RTC-DR bis! ;  \ RTC-DR_MT    Month tens in BCD format
: RTC-DR_MU   ( %XXXX -- ) 8 lshift RTC-DR bis! ;  \ RTC-DR_MU    Month units in BCD format
: RTC-DR_DT   ( %XX -- ) 4 lshift RTC-DR bis! ;  \ RTC-DR_DT    Date tens in BCD format
: RTC-DR_DU   ( %XXXX -- ) 0 lshift RTC-DR bis! ;  \ RTC-DR_DU    Date units in BCD format

\ RTC-CR (read-write)
: RTC-CR_WCKSEL   ( %XXX -- ) 0 lshift RTC-CR bis! ;  \ RTC-CR_WCKSEL    Wakeup clock selection
: RTC-CR_TSEDGE   %1 3 lshift RTC-CR bis! ;  \ RTC-CR_TSEDGE    Time-stamp event active edge
: RTC-CR_REFCKON   %1 4 lshift RTC-CR bis! ;  \ RTC-CR_REFCKON    Reference clock detection enable 50 or 60 Hz
: RTC-CR_BYPSHAD   %1 5 lshift RTC-CR bis! ;  \ RTC-CR_BYPSHAD    Bypass the shadow registers
: RTC-CR_FMT   %1 6 lshift RTC-CR bis! ;  \ RTC-CR_FMT    Hour format
: RTC-CR_ALRAE   %1 8 lshift RTC-CR bis! ;  \ RTC-CR_ALRAE    Alarm A enable
: RTC-CR_ALRBE   %1 9 lshift RTC-CR bis! ;  \ RTC-CR_ALRBE    Alarm B enable
: RTC-CR_WUTE   %1 10 lshift RTC-CR bis! ;  \ RTC-CR_WUTE    Wakeup timer enable
: RTC-CR_TSE   %1 11 lshift RTC-CR bis! ;  \ RTC-CR_TSE    Time stamp enable
: RTC-CR_ALRAIE   %1 12 lshift RTC-CR bis! ;  \ RTC-CR_ALRAIE    Alarm A interrupt enable
: RTC-CR_ALRBIE   %1 13 lshift RTC-CR bis! ;  \ RTC-CR_ALRBIE    Alarm B interrupt enable
: RTC-CR_WUTIE   %1 14 lshift RTC-CR bis! ;  \ RTC-CR_WUTIE    Wakeup timer interrupt enable
: RTC-CR_TSIE   %1 15 lshift RTC-CR bis! ;  \ RTC-CR_TSIE    Time-stamp interrupt enable
: RTC-CR_ADD1H   %1 16 lshift RTC-CR bis! ;  \ RTC-CR_ADD1H    Add 1 hour summer time change
: RTC-CR_SUB1H   %1 17 lshift RTC-CR bis! ;  \ RTC-CR_SUB1H    Subtract 1 hour winter time change
: RTC-CR_BKP   %1 18 lshift RTC-CR bis! ;  \ RTC-CR_BKP    Backup
: RTC-CR_COSEL   %1 19 lshift RTC-CR bis! ;  \ RTC-CR_COSEL    Calibration output selection
: RTC-CR_POL   %1 20 lshift RTC-CR bis! ;  \ RTC-CR_POL    Output polarity
: RTC-CR_OSEL   ( %XX -- ) 21 lshift RTC-CR bis! ;  \ RTC-CR_OSEL    Output selection
: RTC-CR_COE   %1 23 lshift RTC-CR bis! ;  \ RTC-CR_COE    Calibration output enable
: RTC-CR_ITSE   %1 24 lshift RTC-CR bis! ;  \ RTC-CR_ITSE    timestamp on internal event enable

\ RTC-ISR ()
: RTC-ISR_ALRAWF   %1 0 lshift RTC-ISR bis! ;  \ RTC-ISR_ALRAWF    Alarm A write flag
: RTC-ISR_ALRBWF   %1 1 lshift RTC-ISR bis! ;  \ RTC-ISR_ALRBWF    Alarm B write flag
: RTC-ISR_WUTWF   %1 2 lshift RTC-ISR bis! ;  \ RTC-ISR_WUTWF    Wakeup timer write flag
: RTC-ISR_SHPF   %1 3 lshift RTC-ISR bis! ;  \ RTC-ISR_SHPF    Shift operation pending
: RTC-ISR_INITS   %1 4 lshift RTC-ISR bis! ;  \ RTC-ISR_INITS    Initialization status flag
: RTC-ISR_RSF   %1 5 lshift RTC-ISR bis! ;  \ RTC-ISR_RSF    Registers synchronization flag
: RTC-ISR_INITF   %1 6 lshift RTC-ISR bis! ;  \ RTC-ISR_INITF    Initialization flag
: RTC-ISR_INIT   %1 7 lshift RTC-ISR bis! ;  \ RTC-ISR_INIT    Initialization mode
: RTC-ISR_ALRAF   %1 8 lshift RTC-ISR bis! ;  \ RTC-ISR_ALRAF    Alarm A flag
: RTC-ISR_ALRBF   %1 9 lshift RTC-ISR bis! ;  \ RTC-ISR_ALRBF    Alarm B flag
: RTC-ISR_WUTF   %1 10 lshift RTC-ISR bis! ;  \ RTC-ISR_WUTF    Wakeup timer flag
: RTC-ISR_TSF   %1 11 lshift RTC-ISR bis! ;  \ RTC-ISR_TSF    Time-stamp flag
: RTC-ISR_TSOVF   %1 12 lshift RTC-ISR bis! ;  \ RTC-ISR_TSOVF    Time-stamp overflow flag
: RTC-ISR_TAMP1F   %1 13 lshift RTC-ISR bis! ;  \ RTC-ISR_TAMP1F    Tamper detection flag
: RTC-ISR_TAMP2F   %1 14 lshift RTC-ISR bis! ;  \ RTC-ISR_TAMP2F    RTC_TAMP2 detection flag
: RTC-ISR_TAMP3F   %1 15 lshift RTC-ISR bis! ;  \ RTC-ISR_TAMP3F    RTC_TAMP3 detection flag
: RTC-ISR_RECALPF   %1 16 lshift RTC-ISR bis! ;  \ RTC-ISR_RECALPF    Recalibration pending Flag
: RTC-ISR_ITSF   %1 17 lshift RTC-ISR bis! ;  \ RTC-ISR_ITSF    INTERNAL TIME-STAMP FLAG

\ RTC-PRER (read-write)
: RTC-PRER_PREDIV_A   ( %XXXXXXX -- ) 16 lshift RTC-PRER bis! ;  \ RTC-PRER_PREDIV_A    Asynchronous prescaler factor
: RTC-PRER_PREDIV_S   ( %XXXXXXXXXXXXXXX -- ) 0 lshift RTC-PRER bis! ;  \ RTC-PRER_PREDIV_S    Synchronous prescaler factor

\ RTC-WUTR (read-write)
: RTC-WUTR_WUT   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift RTC-WUTR bis! ;  \ RTC-WUTR_WUT    Wakeup auto-reload value bits

\ RTC-ALRMAR (read-write)
: RTC-ALRMAR_MSK4   %1 31 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_MSK4    Alarm A date mask
: RTC-ALRMAR_WDSEL   %1 30 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_WDSEL    Week day selection
: RTC-ALRMAR_DT   ( %XX -- ) 28 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_DT    Date tens in BCD format
: RTC-ALRMAR_DU   ( %XXXX -- ) 24 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_DU    Date units or day in BCD format
: RTC-ALRMAR_MSK3   %1 23 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_MSK3    Alarm A hours mask
: RTC-ALRMAR_PM   %1 22 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_PM    AM/PM notation
: RTC-ALRMAR_HT   ( %XX -- ) 20 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_HT    Hour tens in BCD format
: RTC-ALRMAR_HU   ( %XXXX -- ) 16 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_HU    Hour units in BCD format
: RTC-ALRMAR_MSK2   %1 15 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_MSK2    Alarm A minutes mask
: RTC-ALRMAR_MNT   ( %XXX -- ) 12 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_MNT    Minute tens in BCD format
: RTC-ALRMAR_MNU   ( %XXXX -- ) 8 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_MNU    Minute units in BCD format
: RTC-ALRMAR_MSK1   %1 7 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_MSK1    Alarm A seconds mask
: RTC-ALRMAR_ST   ( %XXX -- ) 4 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_ST    Second tens in BCD format
: RTC-ALRMAR_SU   ( %XXXX -- ) 0 lshift RTC-ALRMAR bis! ;  \ RTC-ALRMAR_SU    Second units in BCD format

\ RTC-ALRMBR (read-write)
: RTC-ALRMBR_MSK4   %1 31 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_MSK4    Alarm B date mask
: RTC-ALRMBR_WDSEL   %1 30 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_WDSEL    Week day selection
: RTC-ALRMBR_DT   ( %XX -- ) 28 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_DT    Date tens in BCD format
: RTC-ALRMBR_DU   ( %XXXX -- ) 24 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_DU    Date units or day in BCD format
: RTC-ALRMBR_MSK3   %1 23 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_MSK3    Alarm B hours mask
: RTC-ALRMBR_PM   %1 22 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_PM    AM/PM notation
: RTC-ALRMBR_HT   ( %XX -- ) 20 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_HT    Hour tens in BCD format
: RTC-ALRMBR_HU   ( %XXXX -- ) 16 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_HU    Hour units in BCD format
: RTC-ALRMBR_MSK2   %1 15 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_MSK2    Alarm B minutes mask
: RTC-ALRMBR_MNT   ( %XXX -- ) 12 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_MNT    Minute tens in BCD format
: RTC-ALRMBR_MNU   ( %XXXX -- ) 8 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_MNU    Minute units in BCD format
: RTC-ALRMBR_MSK1   %1 7 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_MSK1    Alarm B seconds mask
: RTC-ALRMBR_ST   ( %XXX -- ) 4 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_ST    Second tens in BCD format
: RTC-ALRMBR_SU   ( %XXXX -- ) 0 lshift RTC-ALRMBR bis! ;  \ RTC-ALRMBR_SU    Second units in BCD format

\ RTC-WPR (write-only)
: RTC-WPR_KEY   ( %XXXXXXXX -- ) 0 lshift RTC-WPR bis! ;  \ RTC-WPR_KEY    Write protection key

\ RTC-SSR (read-only)
: RTC-SSR_SS   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift RTC-SSR bis! ;  \ RTC-SSR_SS    Sub second value

\ RTC-SHIFTR (write-only)
: RTC-SHIFTR_ADD1S   %1 31 lshift RTC-SHIFTR bis! ;  \ RTC-SHIFTR_ADD1S    Add one second
: RTC-SHIFTR_SUBFS   ( %XXXXXXXXXXXXXXX -- ) 0 lshift RTC-SHIFTR bis! ;  \ RTC-SHIFTR_SUBFS    Subtract a fraction of a second

\ RTC-TSTR (read-only)
: RTC-TSTR_SU   ( %XXXX -- ) 0 lshift RTC-TSTR bis! ;  \ RTC-TSTR_SU    Second units in BCD format
: RTC-TSTR_ST   ( %XXX -- ) 4 lshift RTC-TSTR bis! ;  \ RTC-TSTR_ST    Second tens in BCD format
: RTC-TSTR_MNU   ( %XXXX -- ) 8 lshift RTC-TSTR bis! ;  \ RTC-TSTR_MNU    Minute units in BCD format
: RTC-TSTR_MNT   ( %XXX -- ) 12 lshift RTC-TSTR bis! ;  \ RTC-TSTR_MNT    Minute tens in BCD format
: RTC-TSTR_HU   ( %XXXX -- ) 16 lshift RTC-TSTR bis! ;  \ RTC-TSTR_HU    Hour units in BCD format
: RTC-TSTR_HT   ( %XX -- ) 20 lshift RTC-TSTR bis! ;  \ RTC-TSTR_HT    Hour tens in BCD format
: RTC-TSTR_PM   %1 22 lshift RTC-TSTR bis! ;  \ RTC-TSTR_PM    AM/PM notation

\ RTC-TSDR (read-only)
: RTC-TSDR_WDU   ( %XXX -- ) 13 lshift RTC-TSDR bis! ;  \ RTC-TSDR_WDU    Week day units
: RTC-TSDR_MT   %1 12 lshift RTC-TSDR bis! ;  \ RTC-TSDR_MT    Month tens in BCD format
: RTC-TSDR_MU   ( %XXXX -- ) 8 lshift RTC-TSDR bis! ;  \ RTC-TSDR_MU    Month units in BCD format
: RTC-TSDR_DT   ( %XX -- ) 4 lshift RTC-TSDR bis! ;  \ RTC-TSDR_DT    Date tens in BCD format
: RTC-TSDR_DU   ( %XXXX -- ) 0 lshift RTC-TSDR bis! ;  \ RTC-TSDR_DU    Date units in BCD format

\ RTC-TSSSR (read-only)
: RTC-TSSSR_SS   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift RTC-TSSSR bis! ;  \ RTC-TSSSR_SS    Sub second value

\ RTC-CALR (read-write)
: RTC-CALR_CALP   %1 15 lshift RTC-CALR bis! ;  \ RTC-CALR_CALP    Increase frequency of RTC by 488.5 ppm
: RTC-CALR_CALW8   %1 14 lshift RTC-CALR bis! ;  \ RTC-CALR_CALW8    Use an 8-second calibration cycle period
: RTC-CALR_CALW16   %1 13 lshift RTC-CALR bis! ;  \ RTC-CALR_CALW16    Use a 16-second calibration cycle period
: RTC-CALR_CALM   ( %XXXXXXXXX -- ) 0 lshift RTC-CALR bis! ;  \ RTC-CALR_CALM    Calibration minus

\ RTC-TAMPCR (read-write)
: RTC-TAMPCR_TAMP1E   %1 0 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP1E    Tamper 1 detection enable
: RTC-TAMPCR_TAMP1TRG   %1 1 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP1TRG    Active level for tamper 1
: RTC-TAMPCR_TAMPIE   %1 2 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMPIE    Tamper interrupt enable
: RTC-TAMPCR_TAMP2E   %1 3 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP2E    Tamper 2 detection enable
: RTC-TAMPCR_TAMP2TRG   %1 4 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP2TRG    Active level for tamper 2
: RTC-TAMPCR_TAMP3E   %1 5 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP3E    Tamper 3 detection enable
: RTC-TAMPCR_TAMP3TRG   %1 6 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP3TRG    Active level for tamper 3
: RTC-TAMPCR_TAMPTS   %1 7 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMPTS    Activate timestamp on tamper detection event
: RTC-TAMPCR_TAMPFREQ   ( %XXX -- ) 8 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMPFREQ    Tamper sampling frequency
: RTC-TAMPCR_TAMPFLT   ( %XX -- ) 11 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMPFLT    Tamper filter count
: RTC-TAMPCR_TAMPPRCH   ( %XX -- ) 13 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMPPRCH    Tamper precharge duration
: RTC-TAMPCR_TAMPPUDIS   %1 15 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMPPUDIS    TAMPER pull-up disable
: RTC-TAMPCR_TAMP1IE   %1 16 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP1IE    Tamper 1 interrupt enable
: RTC-TAMPCR_TAMP1NOERASE   %1 17 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP1NOERASE    Tamper 1 no erase
: RTC-TAMPCR_TAMP1MF   %1 18 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP1MF    Tamper 1 mask flag
: RTC-TAMPCR_TAMP2IE   %1 19 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP2IE    Tamper 2 interrupt enable
: RTC-TAMPCR_TAMP2NOERASE   %1 20 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP2NOERASE    Tamper 2 no erase
: RTC-TAMPCR_TAMP2MF   %1 21 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP2MF    Tamper 2 mask flag
: RTC-TAMPCR_TAMP3IE   %1 22 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP3IE    Tamper 3 interrupt enable
: RTC-TAMPCR_TAMP3NOERASE   %1 23 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP3NOERASE    Tamper 3 no erase
: RTC-TAMPCR_TAMP3MF   %1 24 lshift RTC-TAMPCR bis! ;  \ RTC-TAMPCR_TAMP3MF    Tamper 3 mask flag

\ RTC-ALRMASSR (read-write)
: RTC-ALRMASSR_MASKSS   ( %XXXX -- ) 24 lshift RTC-ALRMASSR bis! ;  \ RTC-ALRMASSR_MASKSS    Mask the most-significant bits starting at this bit
: RTC-ALRMASSR_SS   ( %XXXXXXXXXXXXXXX -- ) 0 lshift RTC-ALRMASSR bis! ;  \ RTC-ALRMASSR_SS    Sub seconds value

\ RTC-ALRMBSSR (read-write)
: RTC-ALRMBSSR_MASKSS   ( %XXXX -- ) 24 lshift RTC-ALRMBSSR bis! ;  \ RTC-ALRMBSSR_MASKSS    Mask the most-significant bits starting at this bit
: RTC-ALRMBSSR_SS   ( %XXXXXXXXXXXXXXX -- ) 0 lshift RTC-ALRMBSSR bis! ;  \ RTC-ALRMBSSR_SS    Sub seconds value

\ RTC-OR (read-write)
: RTC-OR_RTC_ALARM_TYPE   %1 0 lshift RTC-OR bis! ;  \ RTC-OR_RTC_ALARM_TYPE    RTC_ALARM on PC13 output type
: RTC-OR_RTC_OUT_RMP   %1 1 lshift RTC-OR bis! ;  \ RTC-OR_RTC_OUT_RMP    RTC_OUT remap

\ RTC-BKP0R (read-write)
: RTC-BKP0R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP0R bis! ;  \ RTC-BKP0R_BKP    BKP

\ RTC-BKP1R (read-write)
: RTC-BKP1R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP1R bis! ;  \ RTC-BKP1R_BKP    BKP

\ RTC-BKP2R (read-write)
: RTC-BKP2R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP2R bis! ;  \ RTC-BKP2R_BKP    BKP

\ RTC-BKP3R (read-write)
: RTC-BKP3R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP3R bis! ;  \ RTC-BKP3R_BKP    BKP

\ RTC-BKP4R (read-write)
: RTC-BKP4R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP4R bis! ;  \ RTC-BKP4R_BKP    BKP

\ RTC-BKP5R (read-write)
: RTC-BKP5R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP5R bis! ;  \ RTC-BKP5R_BKP    BKP

\ RTC-BKP6R (read-write)
: RTC-BKP6R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP6R bis! ;  \ RTC-BKP6R_BKP    BKP

\ RTC-BKP7R (read-write)
: RTC-BKP7R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP7R bis! ;  \ RTC-BKP7R_BKP    BKP

\ RTC-BKP8R (read-write)
: RTC-BKP8R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP8R bis! ;  \ RTC-BKP8R_BKP    BKP

\ RTC-BKP9R (read-write)
: RTC-BKP9R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP9R bis! ;  \ RTC-BKP9R_BKP    BKP

\ RTC-BKP10R (read-write)
: RTC-BKP10R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP10R bis! ;  \ RTC-BKP10R_BKP    BKP

\ RTC-BKP11R (read-write)
: RTC-BKP11R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP11R bis! ;  \ RTC-BKP11R_BKP    BKP

\ RTC-BKP12R (read-write)
: RTC-BKP12R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP12R bis! ;  \ RTC-BKP12R_BKP    BKP

\ RTC-BKP13R (read-write)
: RTC-BKP13R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP13R bis! ;  \ RTC-BKP13R_BKP    BKP

\ RTC-BKP14R (read-write)
: RTC-BKP14R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP14R bis! ;  \ RTC-BKP14R_BKP    BKP

\ RTC-BKP15R (read-write)
: RTC-BKP15R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP15R bis! ;  \ RTC-BKP15R_BKP    BKP

\ RTC-BKP16R (read-write)
: RTC-BKP16R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP16R bis! ;  \ RTC-BKP16R_BKP    BKP

\ RTC-BKP17R (read-write)
: RTC-BKP17R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP17R bis! ;  \ RTC-BKP17R_BKP    BKP

\ RTC-BKP18R (read-write)
: RTC-BKP18R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP18R bis! ;  \ RTC-BKP18R_BKP    BKP

\ RTC-BKP19R (read-write)
: RTC-BKP19R_BKP   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift RTC-BKP19R bis! ;  \ RTC-BKP19R_BKP    BKP

\ DBGMCU-IDCODE (read-only)
: DBGMCU-IDCODE_DEV_ID   ( %XXXXXXXXXXX -- ) 0 lshift DBGMCU-IDCODE bis! ;  \ DBGMCU-IDCODE_DEV_ID    Device Identifier
: DBGMCU-IDCODE_REV_ID   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift DBGMCU-IDCODE bis! ;  \ DBGMCU-IDCODE_REV_ID    Revision Identifier

\ DBGMCU-CR (read-write)
: DBGMCU-CR_DBG_SLEEP   %1 0 lshift DBGMCU-CR bis! ;  \ DBGMCU-CR_DBG_SLEEP    Debug Sleep Mode
: DBGMCU-CR_DBG_STOP   %1 1 lshift DBGMCU-CR bis! ;  \ DBGMCU-CR_DBG_STOP    Debug Stop Mode
: DBGMCU-CR_DBG_STANDBY   %1 2 lshift DBGMCU-CR bis! ;  \ DBGMCU-CR_DBG_STANDBY    Debug Standby Mode
: DBGMCU-CR_TRACE_IOEN   %1 5 lshift DBGMCU-CR bis! ;  \ DBGMCU-CR_TRACE_IOEN    Trace port and clock enable
: DBGMCU-CR_TRGOEN   %1 28 lshift DBGMCU-CR bis! ;  \ DBGMCU-CR_TRGOEN    External trigger output enable

\ DBGMCU-APB1FZR1 (read-write)
: DBGMCU-APB1FZR1_DBG_TIMER2_STOP   %1 0 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_TIMER2_STOP    Debug Timer 2 stopped when Core is halted
: DBGMCU-APB1FZR1_DBG_RTC_STOP   %1 10 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_RTC_STOP    RTC counter stopped when core is halted
: DBGMCU-APB1FZR1_DBG_WWDG_STOP   %1 11 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_WWDG_STOP    WWDG counter stopped when core is halted
: DBGMCU-APB1FZR1_DBG_IWDG_STOP   %1 12 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_IWDG_STOP    IWDG counter stopped when core is halted
: DBGMCU-APB1FZR1_DBG_I2C1_STOP   %1 21 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_I2C1_STOP    Debug I2C1 SMBUS timeout stopped when Core is halted
: DBGMCU-APB1FZR1_DBG_I2C3_STOP   %1 23 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_I2C3_STOP    Debug I2C3 SMBUS timeout stopped when core is halted
: DBGMCU-APB1FZR1_DBG_LPTIM1_STOP   %1 31 lshift DBGMCU-APB1FZR1 bis! ;  \ DBGMCU-APB1FZR1_DBG_LPTIM1_STOP    Debug LPTIM1 stopped when Core is halted

\ DBGMCU-C2AP_B1FZR1 (read-write)
: DBGMCU-C2AP_B1FZR1_DBG_LPTIM2_STOP   %1 0 lshift DBGMCU-C2AP_B1FZR1 bis! ;  \ DBGMCU-C2AP_B1FZR1_DBG_LPTIM2_STOP    LPTIM2 counter stopped when core is halted
: DBGMCU-C2AP_B1FZR1_DBG_RTC_STOP   %1 10 lshift DBGMCU-C2AP_B1FZR1 bis! ;  \ DBGMCU-C2AP_B1FZR1_DBG_RTC_STOP    RTC counter stopped when core is halted
: DBGMCU-C2AP_B1FZR1_DBG_IWDG_STOP   %1 12 lshift DBGMCU-C2AP_B1FZR1 bis! ;  \ DBGMCU-C2AP_B1FZR1_DBG_IWDG_STOP    IWDG stopped when core is halted
: DBGMCU-C2AP_B1FZR1_DBG_I2C1_STOP   %1 21 lshift DBGMCU-C2AP_B1FZR1 bis! ;  \ DBGMCU-C2AP_B1FZR1_DBG_I2C1_STOP    I2C1 SMBUS timeout stopped when core is halted
: DBGMCU-C2AP_B1FZR1_DBG_I2C3_STOP   %1 23 lshift DBGMCU-C2AP_B1FZR1 bis! ;  \ DBGMCU-C2AP_B1FZR1_DBG_I2C3_STOP    I2C3 SMBUS timeout stopped when core is halted
: DBGMCU-C2AP_B1FZR1_DBG_LPTIM1_STOP   %1 31 lshift DBGMCU-C2AP_B1FZR1 bis! ;  \ DBGMCU-C2AP_B1FZR1_DBG_LPTIM1_STOP    LPTIM1 counter stopped when core is halted

\ DBGMCU-APB1FZR2 (read-write)
: DBGMCU-APB1FZR2_DBG_LPTIM2_STOP   %1 5 lshift DBGMCU-APB1FZR2 bis! ;  \ DBGMCU-APB1FZR2_DBG_LPTIM2_STOP    LPTIM2 counter stopped when core is halted

\ DBGMCU-C2APB1FZR2 (read-write)
: DBGMCU-C2APB1FZR2_DBG_LPTIM2_STOP   %1 5 lshift DBGMCU-C2APB1FZR2 bis! ;  \ DBGMCU-C2APB1FZR2_DBG_LPTIM2_STOP    LPTIM2 counter stopped when core is halted

\ DBGMCU-APB2FZR (read-write)
: DBGMCU-APB2FZR_DBG_TIM1_STOP   %1 11 lshift DBGMCU-APB2FZR bis! ;  \ DBGMCU-APB2FZR_DBG_TIM1_STOP    TIM1 counter stopped when core is halted
: DBGMCU-APB2FZR_DBG_TIM16_STOP   %1 17 lshift DBGMCU-APB2FZR bis! ;  \ DBGMCU-APB2FZR_DBG_TIM16_STOP    TIM16 counter stopped when core is halted
: DBGMCU-APB2FZR_DBG_TIM17_STOP   %1 18 lshift DBGMCU-APB2FZR bis! ;  \ DBGMCU-APB2FZR_DBG_TIM17_STOP    TIM17 counter stopped when core is halted

\ DBGMCU-C2APB2FZR (read-write)
: DBGMCU-C2APB2FZR_DBG_TIM1_STOP   %1 11 lshift DBGMCU-C2APB2FZR bis! ;  \ DBGMCU-C2APB2FZR_DBG_TIM1_STOP    TIM1 counter stopped when core is halted
: DBGMCU-C2APB2FZR_DBG_TIM16_STOP   %1 17 lshift DBGMCU-C2APB2FZR bis! ;  \ DBGMCU-C2APB2FZR_DBG_TIM16_STOP    TIM16 counter stopped when core is halted
: DBGMCU-C2APB2FZR_DBG_TIM17_STOP   %1 18 lshift DBGMCU-C2APB2FZR bis! ;  \ DBGMCU-C2APB2FZR_DBG_TIM17_STOP    TIM17 counter stopped when core is halted

\ PKA-CR (read-write)
: PKA-CR_ADDRERRIE   %1 20 lshift PKA-CR bis! ;  \ PKA-CR_ADDRERRIE    Address error interrupt enable
: PKA-CR_RAMERRIE   %1 19 lshift PKA-CR bis! ;  \ PKA-CR_RAMERRIE    RAM error interrupt enable
: PKA-CR_PROCENDIE   %1 17 lshift PKA-CR bis! ;  \ PKA-CR_PROCENDIE    End of operation interrupt enable
: PKA-CR_MODE   ( %XXXXXX -- ) 8 lshift PKA-CR bis! ;  \ PKA-CR_MODE    PKA Operation Mode
: PKA-CR_SECLVL   %1 2 lshift PKA-CR bis! ;  \ PKA-CR_SECLVL    Security Enable
: PKA-CR_START   %1 1 lshift PKA-CR bis! ;  \ PKA-CR_START    Start the operation
: PKA-CR_EN   %1 0 lshift PKA-CR bis! ;  \ PKA-CR_EN    Peripheral Enable

\ PKA-SR (read-only)
: PKA-SR_ADDRERRF   %1 20 lshift PKA-SR bis! ;  \ PKA-SR_ADDRERRF    Address error flag
: PKA-SR_RAMERRF   %1 19 lshift PKA-SR bis! ;  \ PKA-SR_RAMERRF    RAM error flag
: PKA-SR_PROCENDF   %1 17 lshift PKA-SR bis! ;  \ PKA-SR_PROCENDF    PKA End of Operation flag
: PKA-SR_BUSY   %1 16 lshift PKA-SR bis! ;  \ PKA-SR_BUSY    PKA Operation in progress

\ PKA-CLRFR (read-write)
: PKA-CLRFR_ADDRERRFC   %1 20 lshift PKA-CLRFR bis! ;  \ PKA-CLRFR_ADDRERRFC    Clear Address error flag
: PKA-CLRFR_RAMERRFC   %1 19 lshift PKA-CLRFR bis! ;  \ PKA-CLRFR_RAMERRFC    Clear RAM error flag
: PKA-CLRFR_PROCENDFC   %1 17 lshift PKA-CLRFR bis! ;  \ PKA-CLRFR_PROCENDFC    Clear PKA End of Operation flag

\ PKA-VERR (read-only)
: PKA-VERR_MINREV   ( %XXXX -- ) 0 lshift PKA-VERR bis! ;  \ PKA-VERR_MINREV    Minor revision
: PKA-VERR_MAJREV   ( %XXXX -- ) 4 lshift PKA-VERR bis! ;  \ PKA-VERR_MAJREV    Major revision

\ PKA-IPIDR (read-only)
: PKA-IPIDR_ID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift PKA-IPIDR bis! ;  \ PKA-IPIDR_ID    Identification Code

\ PKA-SIDR (read-only)
: PKA-SIDR_SID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift PKA-SIDR bis! ;  \ PKA-SIDR_SID    Side Identification Code

\ IPCC-C1CR (read-write)
: IPCC-C1CR_TXFIE   %1 16 lshift IPCC-C1CR bis! ;  \ IPCC-C1CR_TXFIE    processor 1 Transmit channel free interrupt enable
: IPCC-C1CR_RXOIE   %1 0 lshift IPCC-C1CR bis! ;  \ IPCC-C1CR_RXOIE    processor 1 Receive channel occupied interrupt enable

\ IPCC-C1MR (read-write)
: IPCC-C1MR_CH6FM   %1 21 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH6FM    processor 1 Transmit channel 6 free interrupt mask
: IPCC-C1MR_CH5FM   %1 20 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH5FM    processor 1 Transmit channel 5 free interrupt mask
: IPCC-C1MR_CH4FM   %1 19 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH4FM    processor 1 Transmit channel 4 free interrupt mask
: IPCC-C1MR_CH3FM   %1 18 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH3FM    processor 1 Transmit channel 3 free interrupt mask
: IPCC-C1MR_CH2FM   %1 17 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH2FM    processor 1 Transmit channel 2 free interrupt mask
: IPCC-C1MR_CH1FM   %1 16 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH1FM    processor 1 Transmit channel 1 free interrupt mask
: IPCC-C1MR_CH6OM   %1 5 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH6OM    processor 1 Receive channel 6 occupied interrupt enable
: IPCC-C1MR_CH5OM   %1 4 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH5OM    processor 1 Receive channel 5 occupied interrupt enable
: IPCC-C1MR_CH4OM   %1 3 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH4OM    processor 1 Receive channel 4 occupied interrupt enable
: IPCC-C1MR_CH3OM   %1 2 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH3OM    processor 1 Receive channel 3 occupied interrupt enable
: IPCC-C1MR_CH2OM   %1 1 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH2OM    processor 1 Receive channel 2 occupied interrupt enable
: IPCC-C1MR_CH1OM   %1 0 lshift IPCC-C1MR bis! ;  \ IPCC-C1MR_CH1OM    processor 1 Receive channel 1 occupied interrupt enable

\ IPCC-C1SCR (write-only)
: IPCC-C1SCR_CH6S   %1 21 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH6S    processor 1 Transmit channel 6 status set
: IPCC-C1SCR_CH5S   %1 20 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH5S    processor 1 Transmit channel 5 status set
: IPCC-C1SCR_CH4S   %1 19 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH4S    processor 1 Transmit channel 4 status set
: IPCC-C1SCR_CH3S   %1 18 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH3S    processor 1 Transmit channel 3 status set
: IPCC-C1SCR_CH2S   %1 17 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH2S    processor 1 Transmit channel 2 status set
: IPCC-C1SCR_CH1S   %1 16 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH1S    processor 1 Transmit channel 1 status set
: IPCC-C1SCR_CH6C   %1 5 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH6C    processor 1 Receive channel 6 status clear
: IPCC-C1SCR_CH5C   %1 4 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH5C    processor 1 Receive channel 5 status clear
: IPCC-C1SCR_CH4C   %1 3 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH4C    processor 1 Receive channel 4 status clear
: IPCC-C1SCR_CH3C   %1 2 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH3C    processor 1 Receive channel 3 status clear
: IPCC-C1SCR_CH2C   %1 1 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH2C    processor 1 Receive channel 2 status clear
: IPCC-C1SCR_CH1C   %1 0 lshift IPCC-C1SCR bis! ;  \ IPCC-C1SCR_CH1C    processor 1 Receive channel 1 status clear

\ IPCC-C1TO2SR (read-only)
: IPCC-C1TO2SR_CH6F   %1 5 lshift IPCC-C1TO2SR bis! ;  \ IPCC-C1TO2SR_CH6F    processor 1 transmit to process 2 Receive channel 6 status flag
: IPCC-C1TO2SR_CH5F   %1 4 lshift IPCC-C1TO2SR bis! ;  \ IPCC-C1TO2SR_CH5F    processor 1 transmit to process 2 Receive channel 5 status flag
: IPCC-C1TO2SR_CH4F   %1 3 lshift IPCC-C1TO2SR bis! ;  \ IPCC-C1TO2SR_CH4F    processor 1 transmit to process 2 Receive channel 4 status flag
: IPCC-C1TO2SR_CH3F   %1 2 lshift IPCC-C1TO2SR bis! ;  \ IPCC-C1TO2SR_CH3F    processor 1 transmit to process 2 Receive channel 3 status flag
: IPCC-C1TO2SR_CH2F   %1 1 lshift IPCC-C1TO2SR bis! ;  \ IPCC-C1TO2SR_CH2F    processor 1 transmit to process 2 Receive channel 2 status flag
: IPCC-C1TO2SR_CH1F   %1 0 lshift IPCC-C1TO2SR bis! ;  \ IPCC-C1TO2SR_CH1F    processor 1 transmit to process 2 Receive channel 1 status flag

\ IPCC-C2CR (read-write)
: IPCC-C2CR_TXFIE   %1 16 lshift IPCC-C2CR bis! ;  \ IPCC-C2CR_TXFIE    processor 2 Transmit channel free interrupt enable
: IPCC-C2CR_RXOIE   %1 0 lshift IPCC-C2CR bis! ;  \ IPCC-C2CR_RXOIE    processor 2 Receive channel occupied interrupt enable

\ IPCC-C2MR (read-write)
: IPCC-C2MR_CH6FM   %1 21 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH6FM    processor 2 Transmit channel 6 free interrupt mask
: IPCC-C2MR_CH5FM   %1 20 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH5FM    processor 2 Transmit channel 5 free interrupt mask
: IPCC-C2MR_CH4FM   %1 19 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH4FM    processor 2 Transmit channel 4 free interrupt mask
: IPCC-C2MR_CH3FM   %1 18 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH3FM    processor 2 Transmit channel 3 free interrupt mask
: IPCC-C2MR_CH2FM   %1 17 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH2FM    processor 2 Transmit channel 2 free interrupt mask
: IPCC-C2MR_CH1FM   %1 16 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH1FM    processor 2 Transmit channel 1 free interrupt mask
: IPCC-C2MR_CH6OM   %1 5 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH6OM    processor 2 Receive channel 6 occupied interrupt enable
: IPCC-C2MR_CH5OM   %1 4 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH5OM    processor 2 Receive channel 5 occupied interrupt enable
: IPCC-C2MR_CH4OM   %1 3 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH4OM    processor 2 Receive channel 4 occupied interrupt enable
: IPCC-C2MR_CH3OM   %1 2 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH3OM    processor 2 Receive channel 3 occupied interrupt enable
: IPCC-C2MR_CH2OM   %1 1 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH2OM    processor 2 Receive channel 2 occupied interrupt enable
: IPCC-C2MR_CH1OM   %1 0 lshift IPCC-C2MR bis! ;  \ IPCC-C2MR_CH1OM    processor 2 Receive channel 1 occupied interrupt enable

\ IPCC-C2SCR (write-only)
: IPCC-C2SCR_CH6S   %1 21 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH6S    processor 2 Transmit channel 6 status set
: IPCC-C2SCR_CH5S   %1 20 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH5S    processor 2 Transmit channel 5 status set
: IPCC-C2SCR_CH4S   %1 19 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH4S    processor 2 Transmit channel 4 status set
: IPCC-C2SCR_CH3S   %1 18 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH3S    processor 2 Transmit channel 3 status set
: IPCC-C2SCR_CH2S   %1 17 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH2S    processor 2 Transmit channel 2 status set
: IPCC-C2SCR_CH1S   %1 16 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH1S    processor 2 Transmit channel 1 status set
: IPCC-C2SCR_CH6C   %1 5 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH6C    processor 2 Receive channel 6 status clear
: IPCC-C2SCR_CH5C   %1 4 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH5C    processor 2 Receive channel 5 status clear
: IPCC-C2SCR_CH4C   %1 3 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH4C    processor 2 Receive channel 4 status clear
: IPCC-C2SCR_CH3C   %1 2 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH3C    processor 2 Receive channel 3 status clear
: IPCC-C2SCR_CH2C   %1 1 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH2C    processor 2 Receive channel 2 status clear
: IPCC-C2SCR_CH1C   %1 0 lshift IPCC-C2SCR bis! ;  \ IPCC-C2SCR_CH1C    processor 2 Receive channel 1 status clear

\ IPCC-C2TOC1SR (read-only)
: IPCC-C2TOC1SR_CH6F   %1 5 lshift IPCC-C2TOC1SR bis! ;  \ IPCC-C2TOC1SR_CH6F    processor 2 transmit to process 1 Receive channel 6 status flag
: IPCC-C2TOC1SR_CH5F   %1 4 lshift IPCC-C2TOC1SR bis! ;  \ IPCC-C2TOC1SR_CH5F    processor 2 transmit to process 1 Receive channel 5 status flag
: IPCC-C2TOC1SR_CH4F   %1 3 lshift IPCC-C2TOC1SR bis! ;  \ IPCC-C2TOC1SR_CH4F    processor 2 transmit to process 1 Receive channel 4 status flag
: IPCC-C2TOC1SR_CH3F   %1 2 lshift IPCC-C2TOC1SR bis! ;  \ IPCC-C2TOC1SR_CH3F    processor 2 transmit to process 1 Receive channel 3 status flag
: IPCC-C2TOC1SR_CH2F   %1 1 lshift IPCC-C2TOC1SR bis! ;  \ IPCC-C2TOC1SR_CH2F    processor 2 transmit to process 1 Receive channel 2 status flag
: IPCC-C2TOC1SR_CH1F   %1 0 lshift IPCC-C2TOC1SR bis! ;  \ IPCC-C2TOC1SR_CH1F    processor 2 transmit to process 1 Receive channel 1 status flag

\ IPCC-HWCFGR (read-only)
: IPCC-HWCFGR_CHANNELS   ( %XXXXXXXX -- ) 0 lshift IPCC-HWCFGR bis! ;  \ IPCC-HWCFGR_CHANNELS    Number of channels per CPU supported by the IP, range 1 to 16

\ IPCC-VERR (read-only)
: IPCC-VERR_MAJREV   ( %XXXX -- ) 4 lshift IPCC-VERR bis! ;  \ IPCC-VERR_MAJREV    Major Revision
: IPCC-VERR_MINREV   ( %XXXX -- ) 0 lshift IPCC-VERR bis! ;  \ IPCC-VERR_MINREV    Minor Revision

\ IPCC-IPIDR (read-only)
: IPCC-IPIDR_IPID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift IPCC-IPIDR bis! ;  \ IPCC-IPIDR_IPID    Identification Code

\ IPCC-SIDR (read-only)
: IPCC-SIDR_SID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift IPCC-SIDR bis! ;  \ IPCC-SIDR_SID    Size Identification Code

\ EXTI-RTSR1 (read-write)
: EXTI-RTSR1_RT  0 lshift EXTI-RTSR1 bis! ;  \ EXTI-RTSR1_RT    Rising trigger event configuration bit of Configurable Event input
: EXTI-RTSR1_RT_31   %1 31 lshift EXTI-RTSR1 bis! ;  \ EXTI-RTSR1_RT_31    Rising trigger event configuration bit of Configurable Event input

\ EXTI-FTSR1 (read-write)
: EXTI-FTSR1_FT  0 lshift EXTI-FTSR1 bis! ;  \ EXTI-FTSR1_FT    Falling trigger event configuration bit of Configurable Event input
: EXTI-FTSR1_FT_31   %1 31 lshift EXTI-FTSR1 bis! ;  \ EXTI-FTSR1_FT_31    Falling trigger event configuration bit of Configurable Event input

\ EXTI-SWIER1 (read-write)
: EXTI-SWIER1_SWI  0 lshift EXTI-SWIER1 bis! ;  \ EXTI-SWIER1_SWI    Software interrupt on event
: EXTI-SWIER1_SWI_31   %1 31 lshift EXTI-SWIER1 bis! ;  \ EXTI-SWIER1_SWI_31    Software interrupt on event

\ EXTI-PR1 (read-write)
: EXTI-PR1_PIF  0 lshift EXTI-PR1 bis! ;  \ EXTI-PR1_PIF    Configurable event inputs Pending bit
: EXTI-PR1_PIF_31   %1 31 lshift EXTI-PR1 bis! ;  \ EXTI-PR1_PIF_31    Configurable event inputs Pending bit

\ EXTI-RTSR2 (read-write)
: EXTI-RTSR2_RT33   %1 1 lshift EXTI-RTSR2 bis! ;  \ EXTI-RTSR2_RT33    Rising trigger event configuration bit of Configurable Event input
: EXTI-RTSR2_RT40_41   ( %XX -- ) 8 lshift EXTI-RTSR2 bis! ;  \ EXTI-RTSR2_RT40_41    Rising trigger event configuration bit of Configurable Event input

\ EXTI-FTSR2 (read-write)
: EXTI-FTSR2_FT33   %1 1 lshift EXTI-FTSR2 bis! ;  \ EXTI-FTSR2_FT33    Falling trigger event configuration bit of Configurable Event input
: EXTI-FTSR2_FT40_41   ( %XX -- ) 8 lshift EXTI-FTSR2 bis! ;  \ EXTI-FTSR2_FT40_41    Falling trigger event configuration bit of Configurable Event input

\ EXTI-SWIER2 (read-write)
: EXTI-SWIER2_SWI33   %1 1 lshift EXTI-SWIER2 bis! ;  \ EXTI-SWIER2_SWI33    Software interrupt on event
: EXTI-SWIER2_SWI40_41   ( %XX -- ) 8 lshift EXTI-SWIER2 bis! ;  \ EXTI-SWIER2_SWI40_41    Software interrupt on event

\ EXTI-PR2 (read-write)
: EXTI-PR2_PIF33   %1 1 lshift EXTI-PR2 bis! ;  \ EXTI-PR2_PIF33    Configurable event inputs x+32 Pending bit.
: EXTI-PR2_PIF40_41   ( %XX -- ) 8 lshift EXTI-PR2 bis! ;  \ EXTI-PR2_PIF40_41    Configurable event inputs x+32 Pending bit.

\ EXTI-C1IMR1 (read-write)
: EXTI-C1IMR1_IM   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-C1IMR1 bis! ;  \ EXTI-C1IMR1_IM    CPUm wakeup with interrupt Mask on Event input

\ EXTI-C2IMR1 (read-write)
: EXTI-C2IMR1_IM   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-C2IMR1 bis! ;  \ EXTI-C2IMR1_IM    CPUm wakeup with interrupt Mask on Event input

\ EXTI-C1EMR1 (read-write)
: EXTI-C1EMR1_EM0_15   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-C1EMR1 bis! ;  \ EXTI-C1EMR1_EM0_15    CPUm Wakeup with event generation Mask on Event input
: EXTI-C1EMR1_EM17_21   ( %XXXXX -- ) 17 lshift EXTI-C1EMR1 bis! ;  \ EXTI-C1EMR1_EM17_21    CPUm Wakeup with event generation Mask on Event input

\ EXTI-C2EMR1 (read-write)
: EXTI-C2EMR1_EM0_15   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-C2EMR1 bis! ;  \ EXTI-C2EMR1_EM0_15    CPUm Wakeup with event generation Mask on Event input
: EXTI-C2EMR1_EM17_21   ( %XXXXX -- ) 17 lshift EXTI-C2EMR1 bis! ;  \ EXTI-C2EMR1_EM17_21    CPUm Wakeup with event generation Mask on Event input

\ EXTI-C1IMR2 (read-write)
: EXTI-C1IMR2_IM  0 lshift EXTI-C1IMR2 bis! ;  \ EXTI-C1IMR2_IM    CPUm Wakeup with interrupt Mask on Event input

\ EXTI-C2IMR2 (read-write)
: EXTI-C2IMR2_IM  0 lshift EXTI-C2IMR2 bis! ;  \ EXTI-C2IMR2_IM    CPUm Wakeup with interrupt Mask on Event input

\ EXTI-C1EMR2 (read-write)
: EXTI-C1EMR2_EM   ( %XX -- ) 8 lshift EXTI-C1EMR2 bis! ;  \ EXTI-C1EMR2_EM    CPUm Wakeup with event generation Mask on Event input

\ EXTI-C2EMR2 (read-write)
: EXTI-C2EMR2_EM   ( %XX -- ) 8 lshift EXTI-C2EMR2 bis! ;  \ EXTI-C2EMR2_EM    CPUm Wakeup with event generation Mask on Event input

\ EXTI-HWCFGR5 (read-only)
: EXTI-HWCFGR5_CPUEVENT   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-HWCFGR5 bis! ;  \ EXTI-HWCFGR5_CPUEVENT    HW configuration CPU event generation

\ EXTI-HWCFGR6 (read-only)
: EXTI-HWCFGR6_CPUEVENT   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-HWCFGR6 bis! ;  \ EXTI-HWCFGR6_CPUEVENT    HW configuration CPU event generation

\ EXTI-HWCFGR7 (read-only)
: EXTI-HWCFGR7_CPUEVENT   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-HWCFGR7 bis! ;  \ EXTI-HWCFGR7_CPUEVENT    HW configuration CPU event generation

\ EXTI-HWCFGR2 (read-only)
: EXTI-HWCFGR2_EVENT_TRG   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-HWCFGR2 bis! ;  \ EXTI-HWCFGR2_EVENT_TRG    HW configuration event trigger type

\ EXTI-HWCFGR3 (read-only)
: EXTI-HWCFGR3_EVENT_TRG   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-HWCFGR3 bis! ;  \ EXTI-HWCFGR3_EVENT_TRG    HW configuration event trigger type

\ EXTI-HWCFGR4 (read-only)
: EXTI-HWCFGR4_EVENT_TRG   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-HWCFGR4 bis! ;  \ EXTI-HWCFGR4_EVENT_TRG    HW configuration event trigger type

\ EXTI-HWCFGR1 (read-only)
: EXTI-HWCFGR1_NBEVENTS   ( %XXXXXXXX -- ) 0 lshift EXTI-HWCFGR1 bis! ;  \ EXTI-HWCFGR1_NBEVENTS    HW configuration number of event
: EXTI-HWCFGR1_NBCPUS   ( %XXXX -- ) 8 lshift EXTI-HWCFGR1 bis! ;  \ EXTI-HWCFGR1_NBCPUS    HW configuration number of CPUs
: EXTI-HWCFGR1_CPUEVTEN   ( %XXXX -- ) 12 lshift EXTI-HWCFGR1 bis! ;  \ EXTI-HWCFGR1_CPUEVTEN    HW configuration of CPUm event output enable

\ EXTI-VERR (read-only)
: EXTI-VERR_MINREV   ( %XXXX -- ) 0 lshift EXTI-VERR bis! ;  \ EXTI-VERR_MINREV    Minor Revision number
: EXTI-VERR_MAJREV   ( %XXXX -- ) 4 lshift EXTI-VERR bis! ;  \ EXTI-VERR_MAJREV    Major Revision number

\ EXTI-IPIDR (read-only)
: EXTI-IPIDR_IPID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-IPIDR bis! ;  \ EXTI-IPIDR_IPID    IP Identification

\ EXTI-SIDR (read-only)
: EXTI-SIDR_SID   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift EXTI-SIDR bis! ;  \ EXTI-SIDR_SID    Size Identification

\ CRS-CR (read-write)
: CRS-CR_SYNCOKIE   %1 0 lshift CRS-CR bis! ;  \ CRS-CR_SYNCOKIE    SYNC event OK interrupt enable
: CRS-CR_SYNCWARNIE   %1 1 lshift CRS-CR bis! ;  \ CRS-CR_SYNCWARNIE    SYNC warning interrupt enable
: CRS-CR_ERRIE   %1 2 lshift CRS-CR bis! ;  \ CRS-CR_ERRIE    Synchronization or trimming error interrupt enable
: CRS-CR_ESYNCIE   %1 3 lshift CRS-CR bis! ;  \ CRS-CR_ESYNCIE    Expected SYNC interrupt enable
: CRS-CR_CEN   %1 5 lshift CRS-CR bis! ;  \ CRS-CR_CEN    Frequency error counter enable
: CRS-CR_AUTOTRIMEN   %1 6 lshift CRS-CR bis! ;  \ CRS-CR_AUTOTRIMEN    Automatic trimming enable
: CRS-CR_SWSYNC   %1 7 lshift CRS-CR bis! ;  \ CRS-CR_SWSYNC    Automatic trimming enable
: CRS-CR_TRIM   ( %XXXXXX -- ) 8 lshift CRS-CR bis! ;  \ CRS-CR_TRIM    HSI48 oscillator smooth trimming

\ CRS-CFGR (read-write)
: CRS-CFGR_RELOAD   ( %XXXXXXXXXXXXXXXX -- ) 0 lshift CRS-CFGR bis! ;  \ CRS-CFGR_RELOAD    Counter reload value
: CRS-CFGR_FELIM   ( %XXXXXXXX -- ) 16 lshift CRS-CFGR bis! ;  \ CRS-CFGR_FELIM    Frequency error limit
: CRS-CFGR_SYNCDIV   ( %XXX -- ) 24 lshift CRS-CFGR bis! ;  \ CRS-CFGR_SYNCDIV    SYNCDIV
: CRS-CFGR_SYNCSRC   ( %XX -- ) 28 lshift CRS-CFGR bis! ;  \ CRS-CFGR_SYNCSRC    SYNC signal source selection
: CRS-CFGR_SYNCPOL   %1 31 lshift CRS-CFGR bis! ;  \ CRS-CFGR_SYNCPOL    SYNC polarity selection

\ CRS-ISR (read-only)
: CRS-ISR_SYNCOKF   %1 0 lshift CRS-ISR bis! ;  \ CRS-ISR_SYNCOKF    SYNC event OK flag
: CRS-ISR_SYNCWARNF   %1 1 lshift CRS-ISR bis! ;  \ CRS-ISR_SYNCWARNF    SYNC warning flag
: CRS-ISR_ERRF   %1 2 lshift CRS-ISR bis! ;  \ CRS-ISR_ERRF    Error flag
: CRS-ISR_ESYNCF   %1 3 lshift CRS-ISR bis! ;  \ CRS-ISR_ESYNCF    Expected SYNC flag
: CRS-ISR_SYNCERR   %1 8 lshift CRS-ISR bis! ;  \ CRS-ISR_SYNCERR    SYNC error
: CRS-ISR_SYNCMISS   %1 9 lshift CRS-ISR bis! ;  \ CRS-ISR_SYNCMISS    SYNC missed
: CRS-ISR_TRIMOVF   %1 10 lshift CRS-ISR bis! ;  \ CRS-ISR_TRIMOVF    Trimming overflow or underflow
: CRS-ISR_FEDIR   %1 15 lshift CRS-ISR bis! ;  \ CRS-ISR_FEDIR    Frequency error direction
: CRS-ISR_FECAP   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift CRS-ISR bis! ;  \ CRS-ISR_FECAP    Frequency error capture

\ CRS-ICR (read-write)
: CRS-ICR_SYNCOKC   %1 0 lshift CRS-ICR bis! ;  \ CRS-ICR_SYNCOKC    SYNC event OK clear flag
: CRS-ICR_SYNCWARNC   %1 1 lshift CRS-ICR bis! ;  \ CRS-ICR_SYNCWARNC    warning clear flag
: CRS-ICR_ERRC   %1 2 lshift CRS-ICR bis! ;  \ CRS-ICR_ERRC    Error clear flag
: CRS-ICR_ESYNCC   %1 3 lshift CRS-ICR bis! ;  \ CRS-ICR_ESYNCC    Expected SYNC clear flag

\ USB-EP0R (read-write)
: USB-EP0R_EA   ( %XXXX -- ) 0 lshift USB-EP0R bis! ;  \ USB-EP0R_EA    Endpoint address
: USB-EP0R_STAT_TX   ( %XX -- ) 4 lshift USB-EP0R bis! ;  \ USB-EP0R_STAT_TX    Status bits, for transmission transfers
: USB-EP0R_DTOG_TX   %1 6 lshift USB-EP0R bis! ;  \ USB-EP0R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP0R_CTR_TX   %1 7 lshift USB-EP0R bis! ;  \ USB-EP0R_CTR_TX    Correct Transfer for transmission
: USB-EP0R_EP_KIND   %1 8 lshift USB-EP0R bis! ;  \ USB-EP0R_EP_KIND    Endpoint kind
: USB-EP0R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP0R bis! ;  \ USB-EP0R_EP_TYPE    Endpoint type
: USB-EP0R_SETUP   %1 11 lshift USB-EP0R bis! ;  \ USB-EP0R_SETUP    Setup transaction completed
: USB-EP0R_STAT_RX   ( %XX -- ) 12 lshift USB-EP0R bis! ;  \ USB-EP0R_STAT_RX    Status bits, for reception transfers
: USB-EP0R_DTOG_RX   %1 14 lshift USB-EP0R bis! ;  \ USB-EP0R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP0R_CTR_RX   %1 15 lshift USB-EP0R bis! ;  \ USB-EP0R_CTR_RX    Correct transfer for reception

\ USB-EP1R (read-write)
: USB-EP1R_EA   ( %XXXX -- ) 0 lshift USB-EP1R bis! ;  \ USB-EP1R_EA    Endpoint address
: USB-EP1R_STAT_TX   ( %XX -- ) 4 lshift USB-EP1R bis! ;  \ USB-EP1R_STAT_TX    Status bits, for transmission transfers
: USB-EP1R_DTOG_TX   %1 6 lshift USB-EP1R bis! ;  \ USB-EP1R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP1R_CTR_TX   %1 7 lshift USB-EP1R bis! ;  \ USB-EP1R_CTR_TX    Correct Transfer for transmission
: USB-EP1R_EP_KIND   %1 8 lshift USB-EP1R bis! ;  \ USB-EP1R_EP_KIND    Endpoint kind
: USB-EP1R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP1R bis! ;  \ USB-EP1R_EP_TYPE    Endpoint type
: USB-EP1R_SETUP   %1 11 lshift USB-EP1R bis! ;  \ USB-EP1R_SETUP    Setup transaction completed
: USB-EP1R_STAT_RX   ( %XX -- ) 12 lshift USB-EP1R bis! ;  \ USB-EP1R_STAT_RX    Status bits, for reception transfers
: USB-EP1R_DTOG_RX   %1 14 lshift USB-EP1R bis! ;  \ USB-EP1R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP1R_CTR_RX   %1 15 lshift USB-EP1R bis! ;  \ USB-EP1R_CTR_RX    Correct transfer for reception

\ USB-EP2R (read-write)
: USB-EP2R_EA   ( %XXXX -- ) 0 lshift USB-EP2R bis! ;  \ USB-EP2R_EA    Endpoint address
: USB-EP2R_STAT_TX   ( %XX -- ) 4 lshift USB-EP2R bis! ;  \ USB-EP2R_STAT_TX    Status bits, for transmission transfers
: USB-EP2R_DTOG_TX   %1 6 lshift USB-EP2R bis! ;  \ USB-EP2R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP2R_CTR_TX   %1 7 lshift USB-EP2R bis! ;  \ USB-EP2R_CTR_TX    Correct Transfer for transmission
: USB-EP2R_EP_KIND   %1 8 lshift USB-EP2R bis! ;  \ USB-EP2R_EP_KIND    Endpoint kind
: USB-EP2R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP2R bis! ;  \ USB-EP2R_EP_TYPE    Endpoint type
: USB-EP2R_SETUP   %1 11 lshift USB-EP2R bis! ;  \ USB-EP2R_SETUP    Setup transaction completed
: USB-EP2R_STAT_RX   ( %XX -- ) 12 lshift USB-EP2R bis! ;  \ USB-EP2R_STAT_RX    Status bits, for reception transfers
: USB-EP2R_DTOG_RX   %1 14 lshift USB-EP2R bis! ;  \ USB-EP2R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP2R_CTR_RX   %1 15 lshift USB-EP2R bis! ;  \ USB-EP2R_CTR_RX    Correct transfer for reception

\ USB-EP3R (read-write)
: USB-EP3R_EA   ( %XXXX -- ) 0 lshift USB-EP3R bis! ;  \ USB-EP3R_EA    Endpoint address
: USB-EP3R_STAT_TX   ( %XX -- ) 4 lshift USB-EP3R bis! ;  \ USB-EP3R_STAT_TX    Status bits, for transmission transfers
: USB-EP3R_DTOG_TX   %1 6 lshift USB-EP3R bis! ;  \ USB-EP3R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP3R_CTR_TX   %1 7 lshift USB-EP3R bis! ;  \ USB-EP3R_CTR_TX    Correct Transfer for transmission
: USB-EP3R_EP_KIND   %1 8 lshift USB-EP3R bis! ;  \ USB-EP3R_EP_KIND    Endpoint kind
: USB-EP3R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP3R bis! ;  \ USB-EP3R_EP_TYPE    Endpoint type
: USB-EP3R_SETUP   %1 11 lshift USB-EP3R bis! ;  \ USB-EP3R_SETUP    Setup transaction completed
: USB-EP3R_STAT_RX   ( %XX -- ) 12 lshift USB-EP3R bis! ;  \ USB-EP3R_STAT_RX    Status bits, for reception transfers
: USB-EP3R_DTOG_RX   %1 14 lshift USB-EP3R bis! ;  \ USB-EP3R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP3R_CTR_RX   %1 15 lshift USB-EP3R bis! ;  \ USB-EP3R_CTR_RX    Correct transfer for reception

\ USB-EP4R (read-write)
: USB-EP4R_EA   ( %XXXX -- ) 0 lshift USB-EP4R bis! ;  \ USB-EP4R_EA    Endpoint address
: USB-EP4R_STAT_TX   ( %XX -- ) 4 lshift USB-EP4R bis! ;  \ USB-EP4R_STAT_TX    Status bits, for transmission transfers
: USB-EP4R_DTOG_TX   %1 6 lshift USB-EP4R bis! ;  \ USB-EP4R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP4R_CTR_TX   %1 7 lshift USB-EP4R bis! ;  \ USB-EP4R_CTR_TX    Correct Transfer for transmission
: USB-EP4R_EP_KIND   %1 8 lshift USB-EP4R bis! ;  \ USB-EP4R_EP_KIND    Endpoint kind
: USB-EP4R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP4R bis! ;  \ USB-EP4R_EP_TYPE    Endpoint type
: USB-EP4R_SETUP   %1 11 lshift USB-EP4R bis! ;  \ USB-EP4R_SETUP    Setup transaction completed
: USB-EP4R_STAT_RX   ( %XX -- ) 12 lshift USB-EP4R bis! ;  \ USB-EP4R_STAT_RX    Status bits, for reception transfers
: USB-EP4R_DTOG_RX   %1 14 lshift USB-EP4R bis! ;  \ USB-EP4R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP4R_CTR_RX   %1 15 lshift USB-EP4R bis! ;  \ USB-EP4R_CTR_RX    Correct transfer for reception

\ USB-EP5R (read-write)
: USB-EP5R_EA   ( %XXXX -- ) 0 lshift USB-EP5R bis! ;  \ USB-EP5R_EA    Endpoint address
: USB-EP5R_STAT_TX   ( %XX -- ) 4 lshift USB-EP5R bis! ;  \ USB-EP5R_STAT_TX    Status bits, for transmission transfers
: USB-EP5R_DTOG_TX   %1 6 lshift USB-EP5R bis! ;  \ USB-EP5R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP5R_CTR_TX   %1 7 lshift USB-EP5R bis! ;  \ USB-EP5R_CTR_TX    Correct Transfer for transmission
: USB-EP5R_EP_KIND   %1 8 lshift USB-EP5R bis! ;  \ USB-EP5R_EP_KIND    Endpoint kind
: USB-EP5R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP5R bis! ;  \ USB-EP5R_EP_TYPE    Endpoint type
: USB-EP5R_SETUP   %1 11 lshift USB-EP5R bis! ;  \ USB-EP5R_SETUP    Setup transaction completed
: USB-EP5R_STAT_RX   ( %XX -- ) 12 lshift USB-EP5R bis! ;  \ USB-EP5R_STAT_RX    Status bits, for reception transfers
: USB-EP5R_DTOG_RX   %1 14 lshift USB-EP5R bis! ;  \ USB-EP5R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP5R_CTR_RX   %1 15 lshift USB-EP5R bis! ;  \ USB-EP5R_CTR_RX    Correct transfer for reception

\ USB-EP6R (read-write)
: USB-EP6R_EA   ( %XXXX -- ) 0 lshift USB-EP6R bis! ;  \ USB-EP6R_EA    Endpoint address
: USB-EP6R_STAT_TX   ( %XX -- ) 4 lshift USB-EP6R bis! ;  \ USB-EP6R_STAT_TX    Status bits, for transmission transfers
: USB-EP6R_DTOG_TX   %1 6 lshift USB-EP6R bis! ;  \ USB-EP6R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP6R_CTR_TX   %1 7 lshift USB-EP6R bis! ;  \ USB-EP6R_CTR_TX    Correct Transfer for transmission
: USB-EP6R_EP_KIND   %1 8 lshift USB-EP6R bis! ;  \ USB-EP6R_EP_KIND    Endpoint kind
: USB-EP6R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP6R bis! ;  \ USB-EP6R_EP_TYPE    Endpoint type
: USB-EP6R_SETUP   %1 11 lshift USB-EP6R bis! ;  \ USB-EP6R_SETUP    Setup transaction completed
: USB-EP6R_STAT_RX   ( %XX -- ) 12 lshift USB-EP6R bis! ;  \ USB-EP6R_STAT_RX    Status bits, for reception transfers
: USB-EP6R_DTOG_RX   %1 14 lshift USB-EP6R bis! ;  \ USB-EP6R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP6R_CTR_RX   %1 15 lshift USB-EP6R bis! ;  \ USB-EP6R_CTR_RX    Correct transfer for reception

\ USB-EP7R (read-write)
: USB-EP7R_EA   ( %XXXX -- ) 0 lshift USB-EP7R bis! ;  \ USB-EP7R_EA    Endpoint address
: USB-EP7R_STAT_TX   ( %XX -- ) 4 lshift USB-EP7R bis! ;  \ USB-EP7R_STAT_TX    Status bits, for transmission transfers
: USB-EP7R_DTOG_TX   %1 6 lshift USB-EP7R bis! ;  \ USB-EP7R_DTOG_TX    Data Toggle, for transmission transfers
: USB-EP7R_CTR_TX   %1 7 lshift USB-EP7R bis! ;  \ USB-EP7R_CTR_TX    Correct Transfer for transmission
: USB-EP7R_EP_KIND   %1 8 lshift USB-EP7R bis! ;  \ USB-EP7R_EP_KIND    Endpoint kind
: USB-EP7R_EP_TYPE   ( %XX -- ) 9 lshift USB-EP7R bis! ;  \ USB-EP7R_EP_TYPE    Endpoint type
: USB-EP7R_SETUP   %1 11 lshift USB-EP7R bis! ;  \ USB-EP7R_SETUP    Setup transaction completed
: USB-EP7R_STAT_RX   ( %XX -- ) 12 lshift USB-EP7R bis! ;  \ USB-EP7R_STAT_RX    Status bits, for reception transfers
: USB-EP7R_DTOG_RX   %1 14 lshift USB-EP7R bis! ;  \ USB-EP7R_DTOG_RX    Data Toggle, for reception transfers
: USB-EP7R_CTR_RX   %1 15 lshift USB-EP7R bis! ;  \ USB-EP7R_CTR_RX    Correct transfer for reception

\ USB-CNTR (read-write)
: USB-CNTR_FRES   %1 0 lshift USB-CNTR bis! ;  \ USB-CNTR_FRES    Force USB Reset
: USB-CNTR_PDWN   %1 1 lshift USB-CNTR bis! ;  \ USB-CNTR_PDWN    Power down
: USB-CNTR_LPMODE   %1 2 lshift USB-CNTR bis! ;  \ USB-CNTR_LPMODE    Low-power mode
: USB-CNTR_FSUSP   %1 3 lshift USB-CNTR bis! ;  \ USB-CNTR_FSUSP    Force suspend
: USB-CNTR_RESUME   %1 4 lshift USB-CNTR bis! ;  \ USB-CNTR_RESUME    Resume request
: USB-CNTR_L1RESUME   %1 5 lshift USB-CNTR bis! ;  \ USB-CNTR_L1RESUME    LPM L1 Resume request
: USB-CNTR_L1REQM   %1 7 lshift USB-CNTR bis! ;  \ USB-CNTR_L1REQM    LPM L1 state request interrupt mask
: USB-CNTR_ESOFM   %1 8 lshift USB-CNTR bis! ;  \ USB-CNTR_ESOFM    Expected start of frame interrupt mask
: USB-CNTR_SOFM   %1 9 lshift USB-CNTR bis! ;  \ USB-CNTR_SOFM    Start of frame interrupt mask
: USB-CNTR_RESETM   %1 10 lshift USB-CNTR bis! ;  \ USB-CNTR_RESETM    USB reset interrupt mask
: USB-CNTR_SUSPM   %1 11 lshift USB-CNTR bis! ;  \ USB-CNTR_SUSPM    Suspend mode interrupt mask
: USB-CNTR_WKUPM   %1 12 lshift USB-CNTR bis! ;  \ USB-CNTR_WKUPM    Wakeup interrupt mask
: USB-CNTR_ERRM   %1 13 lshift USB-CNTR bis! ;  \ USB-CNTR_ERRM    Error interrupt mask
: USB-CNTR_PMAOVRM   %1 14 lshift USB-CNTR bis! ;  \ USB-CNTR_PMAOVRM    Packet memory area over / underrun interrupt mask
: USB-CNTR_CTRM   %1 15 lshift USB-CNTR bis! ;  \ USB-CNTR_CTRM    Correct transfer interrupt mask

\ USB-ISTR ()
: USB-ISTR_EP_ID   ( %XXXX -- ) 0 lshift USB-ISTR bis! ;  \ USB-ISTR_EP_ID    Endpoint Identifier
: USB-ISTR_DIR   %1 4 lshift USB-ISTR bis! ;  \ USB-ISTR_DIR    Direction of transaction
: USB-ISTR_L1REQ   %1 7 lshift USB-ISTR bis! ;  \ USB-ISTR_L1REQ    LPM L1 state request
: USB-ISTR_ESOF   %1 8 lshift USB-ISTR bis! ;  \ USB-ISTR_ESOF    Expected start frame
: USB-ISTR_SOF   %1 9 lshift USB-ISTR bis! ;  \ USB-ISTR_SOF    start of frame
: USB-ISTR_RESET   %1 10 lshift USB-ISTR bis! ;  \ USB-ISTR_RESET    reset request
: USB-ISTR_SUSP   %1 11 lshift USB-ISTR bis! ;  \ USB-ISTR_SUSP    Suspend mode request
: USB-ISTR_WKUP   %1 12 lshift USB-ISTR bis! ;  \ USB-ISTR_WKUP    Wakeup
: USB-ISTR_ERR   %1 13 lshift USB-ISTR bis! ;  \ USB-ISTR_ERR    Error
: USB-ISTR_PMAOVR   %1 14 lshift USB-ISTR bis! ;  \ USB-ISTR_PMAOVR    Packet memory area over / underrun
: USB-ISTR_CTR   %1 15 lshift USB-ISTR bis! ;  \ USB-ISTR_CTR    Correct transfer

\ USB-FNR (read-only)
: USB-FNR_FN  0 lshift USB-FNR bis! ;  \ USB-FNR_FN    Frame number
: USB-FNR_LSOF   ( %XX -- ) 11 lshift USB-FNR bis! ;  \ USB-FNR_LSOF    Lost SOF
: USB-FNR_LCK   %1 13 lshift USB-FNR bis! ;  \ USB-FNR_LCK    Locked
: USB-FNR_RXDM   %1 14 lshift USB-FNR bis! ;  \ USB-FNR_RXDM    Receive data - line status
: USB-FNR_RXDP   %1 15 lshift USB-FNR bis! ;  \ USB-FNR_RXDP    Receive data + line status

\ USB-DADDR (read-write)
: USB-DADDR_ADD   ( %XXXXXXX -- ) 0 lshift USB-DADDR bis! ;  \ USB-DADDR_ADD    Device address
: USB-DADDR_EF   %1 7 lshift USB-DADDR bis! ;  \ USB-DADDR_EF    Enable function

\ USB-BTABLE (read-write)
: USB-BTABLE_BTABLE  3 lshift USB-BTABLE bis! ;  \ USB-BTABLE_BTABLE    Buffer table

\ USB-COUNT0_TX (read-write)
: USB-COUNT0_TX_COUNT0_TX  0 lshift USB-COUNT0_TX bis! ;  \ USB-COUNT0_TX_COUNT0_TX    Transmission byte count

\ USB-COUNT1_TX (read-write)
: USB-COUNT1_TX_COUNT1_TX  0 lshift USB-COUNT1_TX bis! ;  \ USB-COUNT1_TX_COUNT1_TX    Transmission byte count

\ USB-COUNT2_TX (read-write)
: USB-COUNT2_TX_COUNT2_TX  0 lshift USB-COUNT2_TX bis! ;  \ USB-COUNT2_TX_COUNT2_TX    Transmission byte count

\ USB-COUNT3_TX (read-write)
: USB-COUNT3_TX_COUNT3_TX  0 lshift USB-COUNT3_TX bis! ;  \ USB-COUNT3_TX_COUNT3_TX    Transmission byte count

\ USB-COUNT4_TX (read-write)
: USB-COUNT4_TX_COUNT4_TX  0 lshift USB-COUNT4_TX bis! ;  \ USB-COUNT4_TX_COUNT4_TX    Transmission byte count

\ USB-COUNT5_TX (read-write)
: USB-COUNT5_TX_COUNT5_TX  0 lshift USB-COUNT5_TX bis! ;  \ USB-COUNT5_TX_COUNT5_TX    Transmission byte count

\ USB-COUNT6_TX (read-write)
: USB-COUNT6_TX_COUNT6_TX  0 lshift USB-COUNT6_TX bis! ;  \ USB-COUNT6_TX_COUNT6_TX    Transmission byte count

\ USB-COUNT7_TX (read-write)
: USB-COUNT7_TX_COUNT7_TX  0 lshift USB-COUNT7_TX bis! ;  \ USB-COUNT7_TX_COUNT7_TX    Transmission byte count

\ USB-ADDR0_RX (read-write)
: USB-ADDR0_RX_ADDR0_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR0_RX bis! ;  \ USB-ADDR0_RX_ADDR0_RX    Reception buffer address

\ USB-ADDR1_RX (read-write)
: USB-ADDR1_RX_ADDR1_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR1_RX bis! ;  \ USB-ADDR1_RX_ADDR1_RX    Reception buffer address

\ USB-ADDR2_RX (read-write)
: USB-ADDR2_RX_ADDR2_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR2_RX bis! ;  \ USB-ADDR2_RX_ADDR2_RX    Reception buffer address

\ USB-ADDR3_RX (read-write)
: USB-ADDR3_RX_ADDR3_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR3_RX bis! ;  \ USB-ADDR3_RX_ADDR3_RX    Reception buffer address

\ USB-ADDR4_RX (read-write)
: USB-ADDR4_RX_ADDR4_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR4_RX bis! ;  \ USB-ADDR4_RX_ADDR4_RX    Reception buffer address

\ USB-ADDR5_RX (read-write)
: USB-ADDR5_RX_ADDR5_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR5_RX bis! ;  \ USB-ADDR5_RX_ADDR5_RX    Reception buffer address

\ USB-ADDR6_RX (read-write)
: USB-ADDR6_RX_ADDR6_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR6_RX bis! ;  \ USB-ADDR6_RX_ADDR6_RX    Reception buffer address

\ USB-ADDR7_RX (read-write)
: USB-ADDR7_RX_ADDR7_RX   ( %XXXXXXXXXXXXXXX -- ) 1 lshift USB-ADDR7_RX bis! ;  \ USB-ADDR7_RX_ADDR7_RX    Reception buffer address

\ USB-COUNT0_RX ()
: USB-COUNT0_RX_COUNT0_RX  0 lshift USB-COUNT0_RX bis! ;  \ USB-COUNT0_RX_COUNT0_RX    Reception byte count
: USB-COUNT0_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT0_RX bis! ;  \ USB-COUNT0_RX_NUM_BLOCK    Number of blocks
: USB-COUNT0_RX_BL_SIZE   %1 15 lshift USB-COUNT0_RX bis! ;  \ USB-COUNT0_RX_BL_SIZE    Block size

\ USB-COUNT1_RX ()
: USB-COUNT1_RX_COUNT1_RX  0 lshift USB-COUNT1_RX bis! ;  \ USB-COUNT1_RX_COUNT1_RX    Reception byte count
: USB-COUNT1_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT1_RX bis! ;  \ USB-COUNT1_RX_NUM_BLOCK    Number of blocks
: USB-COUNT1_RX_BL_SIZE   %1 15 lshift USB-COUNT1_RX bis! ;  \ USB-COUNT1_RX_BL_SIZE    Block size

\ USB-COUNT2_RX ()
: USB-COUNT2_RX_COUNT2_RX  0 lshift USB-COUNT2_RX bis! ;  \ USB-COUNT2_RX_COUNT2_RX    Reception byte count
: USB-COUNT2_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT2_RX bis! ;  \ USB-COUNT2_RX_NUM_BLOCK    Number of blocks
: USB-COUNT2_RX_BL_SIZE   %1 15 lshift USB-COUNT2_RX bis! ;  \ USB-COUNT2_RX_BL_SIZE    Block size

\ USB-COUNT3_RX ()
: USB-COUNT3_RX_COUNT3_RX  0 lshift USB-COUNT3_RX bis! ;  \ USB-COUNT3_RX_COUNT3_RX    Reception byte count
: USB-COUNT3_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT3_RX bis! ;  \ USB-COUNT3_RX_NUM_BLOCK    Number of blocks
: USB-COUNT3_RX_BL_SIZE   %1 15 lshift USB-COUNT3_RX bis! ;  \ USB-COUNT3_RX_BL_SIZE    Block size

\ USB-COUNT4_RX ()
: USB-COUNT4_RX_COUNT4_RX  0 lshift USB-COUNT4_RX bis! ;  \ USB-COUNT4_RX_COUNT4_RX    Reception byte count
: USB-COUNT4_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT4_RX bis! ;  \ USB-COUNT4_RX_NUM_BLOCK    Number of blocks
: USB-COUNT4_RX_BL_SIZE   %1 15 lshift USB-COUNT4_RX bis! ;  \ USB-COUNT4_RX_BL_SIZE    Block size

\ USB-COUNT5_RX ()
: USB-COUNT5_RX_COUNT5_RX  0 lshift USB-COUNT5_RX bis! ;  \ USB-COUNT5_RX_COUNT5_RX    Reception byte count
: USB-COUNT5_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT5_RX bis! ;  \ USB-COUNT5_RX_NUM_BLOCK    Number of blocks
: USB-COUNT5_RX_BL_SIZE   %1 15 lshift USB-COUNT5_RX bis! ;  \ USB-COUNT5_RX_BL_SIZE    Block size

\ USB-COUNT6_RX ()
: USB-COUNT6_RX_COUNT6_RX  0 lshift USB-COUNT6_RX bis! ;  \ USB-COUNT6_RX_COUNT6_RX    Reception byte count
: USB-COUNT6_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT6_RX bis! ;  \ USB-COUNT6_RX_NUM_BLOCK    Number of blocks
: USB-COUNT6_RX_BL_SIZE   %1 15 lshift USB-COUNT6_RX bis! ;  \ USB-COUNT6_RX_BL_SIZE    Block size

\ USB-COUNT7_RX ()
: USB-COUNT7_RX_COUNT7_RX  0 lshift USB-COUNT7_RX bis! ;  \ USB-COUNT7_RX_COUNT7_RX    Reception byte count
: USB-COUNT7_RX_NUM_BLOCK   ( %XXXXX -- ) 10 lshift USB-COUNT7_RX bis! ;  \ USB-COUNT7_RX_NUM_BLOCK    Number of blocks
: USB-COUNT7_RX_BL_SIZE   %1 15 lshift USB-COUNT7_RX bis! ;  \ USB-COUNT7_RX_BL_SIZE    Block size

\ USB-LPMCSR ()
: USB-LPMCSR_LPMEN   %1 0 lshift USB-LPMCSR bis! ;  \ USB-LPMCSR_LPMEN    LPM support enable
: USB-LPMCSR_LPMACK   %1 1 lshift USB-LPMCSR bis! ;  \ USB-LPMCSR_LPMACK    LPM Token acknowledge enable
: USB-LPMCSR_REMWAKE   %1 3 lshift USB-LPMCSR bis! ;  \ USB-LPMCSR_REMWAKE    RemoteWake value
: USB-LPMCSR_BESL   ( %XXXX -- ) 4 lshift USB-LPMCSR bis! ;  \ USB-LPMCSR_BESL    BESL value

\ USB-BCDR ()
: USB-BCDR_BCDEN   %1 0 lshift USB-BCDR bis! ;  \ USB-BCDR_BCDEN    Battery charging detector BCD enable
: USB-BCDR_DCDEN   %1 1 lshift USB-BCDR bis! ;  \ USB-BCDR_DCDEN    Data contact detection DCD mode enable
: USB-BCDR_PDEN   %1 2 lshift USB-BCDR bis! ;  \ USB-BCDR_PDEN    Primary detection PD mode enable
: USB-BCDR_SDEN   %1 3 lshift USB-BCDR bis! ;  \ USB-BCDR_SDEN    Secondary detection SD mode enable
: USB-BCDR_DCDET   %1 4 lshift USB-BCDR bis! ;  \ USB-BCDR_DCDET    Data contact detection DCD status
: USB-BCDR_PDET   %1 5 lshift USB-BCDR bis! ;  \ USB-BCDR_PDET    Primary detection PD status
: USB-BCDR_SDET   %1 6 lshift USB-BCDR bis! ;  \ USB-BCDR_SDET    Secondary detection SD status
: USB-BCDR_PS2DET   %1 7 lshift USB-BCDR bis! ;  \ USB-BCDR_PS2DET    DM pull-up detection status
: USB-BCDR_DPPU   %1 15 lshift USB-BCDR bis! ;  \ USB-BCDR_DPPU    DP pull-up control

\ SCB-CPUID (read-only)
: SCB-CPUID_Revision   ( %XXXX -- ) 0 lshift SCB-CPUID bis! ;  \ SCB-CPUID_Revision    Revision number
: SCB-CPUID_PartNo   ( %XXXXXXXXXXX -- ) 4 lshift SCB-CPUID bis! ;  \ SCB-CPUID_PartNo    Part number of the processor
: SCB-CPUID_Constant   ( %XXXX -- ) 16 lshift SCB-CPUID bis! ;  \ SCB-CPUID_Constant    Reads as $F
: SCB-CPUID_Variant   ( %XXXX -- ) 20 lshift SCB-CPUID bis! ;  \ SCB-CPUID_Variant    Variant number
: SCB-CPUID_Implementer   ( %XXXXXXXX -- ) 24 lshift SCB-CPUID bis! ;  \ SCB-CPUID_Implementer    Implementer code

\ SCB-ICSR (read-write)
: SCB-ICSR_VECTACTIVE   ( %XXXXXXXXX -- ) 0 lshift SCB-ICSR bis! ;  \ SCB-ICSR_VECTACTIVE    Active vector
: SCB-ICSR_RETTOBASE   %1 11 lshift SCB-ICSR bis! ;  \ SCB-ICSR_RETTOBASE    Return to base level
: SCB-ICSR_VECTPENDING   ( %XXXXXXX -- ) 12 lshift SCB-ICSR bis! ;  \ SCB-ICSR_VECTPENDING    Pending vector
: SCB-ICSR_ISRPENDING   %1 22 lshift SCB-ICSR bis! ;  \ SCB-ICSR_ISRPENDING    Interrupt pending flag
: SCB-ICSR_PENDSTCLR   %1 25 lshift SCB-ICSR bis! ;  \ SCB-ICSR_PENDSTCLR    SysTick exception clear-pending bit
: SCB-ICSR_PENDSTSET   %1 26 lshift SCB-ICSR bis! ;  \ SCB-ICSR_PENDSTSET    SysTick exception set-pending bit
: SCB-ICSR_PENDSVCLR   %1 27 lshift SCB-ICSR bis! ;  \ SCB-ICSR_PENDSVCLR    PendSV clear-pending bit
: SCB-ICSR_PENDSVSET   %1 28 lshift SCB-ICSR bis! ;  \ SCB-ICSR_PENDSVSET    PendSV set-pending bit
: SCB-ICSR_NMIPENDSET   %1 31 lshift SCB-ICSR bis! ;  \ SCB-ICSR_NMIPENDSET    NMI set-pending bit.

\ SCB-VTOR (read-write)
: SCB-VTOR_TBLOFF  9 lshift SCB-VTOR bis! ;  \ SCB-VTOR_TBLOFF    Vector table base offset field

\ SCB-AIRCR (read-write)
: SCB-AIRCR_VECTRESET   %1 0 lshift SCB-AIRCR bis! ;  \ SCB-AIRCR_VECTRESET    VECTRESET
: SCB-AIRCR_VECTCLRACTIVE   %1 1 lshift SCB-AIRCR bis! ;  \ SCB-AIRCR_VECTCLRACTIVE    VECTCLRACTIVE
: SCB-AIRCR_SYSRESETREQ   %1 2 lshift SCB-AIRCR bis! ;  \ SCB-AIRCR_SYSRESETREQ    SYSRESETREQ
: SCB-AIRCR_PRIGROUP   ( %XXX -- ) 8 lshift SCB-AIRCR bis! ;  \ SCB-AIRCR_PRIGROUP    PRIGROUP
: SCB-AIRCR_ENDIANESS   %1 15 lshift SCB-AIRCR bis! ;  \ SCB-AIRCR_ENDIANESS    ENDIANESS
: SCB-AIRCR_VECTKEYSTAT   ( %XXXXXXXXXXXXXXXX -- ) 16 lshift SCB-AIRCR bis! ;  \ SCB-AIRCR_VECTKEYSTAT    Register key

\ SCB-SCR (read-write)
: SCB-SCR_SLEEPONEXIT   %1 1 lshift SCB-SCR bis! ;  \ SCB-SCR_SLEEPONEXIT    SLEEPONEXIT
: SCB-SCR_SLEEPDEEP   %1 2 lshift SCB-SCR bis! ;  \ SCB-SCR_SLEEPDEEP    SLEEPDEEP
: SCB-SCR_SEVEONPEND   %1 4 lshift SCB-SCR bis! ;  \ SCB-SCR_SEVEONPEND    Send Event on Pending bit

\ SCB-CCR (read-write)
: SCB-CCR_NONBASETHRDENA   %1 0 lshift SCB-CCR bis! ;  \ SCB-CCR_NONBASETHRDENA    Configures how the processor enters Thread mode
: SCB-CCR_USERSETMPEND   %1 1 lshift SCB-CCR bis! ;  \ SCB-CCR_USERSETMPEND    USERSETMPEND
: SCB-CCR_UNALIGN__TRP   %1 3 lshift SCB-CCR bis! ;  \ SCB-CCR_UNALIGN__TRP    UNALIGN_ TRP
: SCB-CCR_DIV_0_TRP   %1 4 lshift SCB-CCR bis! ;  \ SCB-CCR_DIV_0_TRP    DIV_0_TRP
: SCB-CCR_BFHFNMIGN   %1 8 lshift SCB-CCR bis! ;  \ SCB-CCR_BFHFNMIGN    BFHFNMIGN
: SCB-CCR_STKALIGN   %1 9 lshift SCB-CCR bis! ;  \ SCB-CCR_STKALIGN    STKALIGN

\ SCB-SHPR1 (read-write)
: SCB-SHPR1_PRI_4   ( %XXXXXXXX -- ) 0 lshift SCB-SHPR1 bis! ;  \ SCB-SHPR1_PRI_4    Priority of system handler 4
: SCB-SHPR1_PRI_5   ( %XXXXXXXX -- ) 8 lshift SCB-SHPR1 bis! ;  \ SCB-SHPR1_PRI_5    Priority of system handler 5
: SCB-SHPR1_PRI_6   ( %XXXXXXXX -- ) 16 lshift SCB-SHPR1 bis! ;  \ SCB-SHPR1_PRI_6    Priority of system handler 6

\ SCB-SHPR2 (read-write)
: SCB-SHPR2_PRI_11   ( %XXXXXXXX -- ) 24 lshift SCB-SHPR2 bis! ;  \ SCB-SHPR2_PRI_11    Priority of system handler 11

\ SCB-SHPR3 (read-write)
: SCB-SHPR3_PRI_14   ( %XXXXXXXX -- ) 16 lshift SCB-SHPR3 bis! ;  \ SCB-SHPR3_PRI_14    Priority of system handler 14
: SCB-SHPR3_PRI_15   ( %XXXXXXXX -- ) 24 lshift SCB-SHPR3 bis! ;  \ SCB-SHPR3_PRI_15    Priority of system handler 15

\ SCB-SHCRS (read-write)
: SCB-SHCRS_MEMFAULTACT   %1 0 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_MEMFAULTACT    Memory management fault exception active bit
: SCB-SHCRS_BUSFAULTACT   %1 1 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_BUSFAULTACT    Bus fault exception active bit
: SCB-SHCRS_USGFAULTACT   %1 3 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_USGFAULTACT    Usage fault exception active bit
: SCB-SHCRS_SVCALLACT   %1 7 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_SVCALLACT    SVC call active bit
: SCB-SHCRS_MONITORACT   %1 8 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_MONITORACT    Debug monitor active bit
: SCB-SHCRS_PENDSVACT   %1 10 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_PENDSVACT    PendSV exception active bit
: SCB-SHCRS_SYSTICKACT   %1 11 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_SYSTICKACT    SysTick exception active bit
: SCB-SHCRS_USGFAULTPENDED   %1 12 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_USGFAULTPENDED    Usage fault exception pending bit
: SCB-SHCRS_MEMFAULTPENDED   %1 13 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_MEMFAULTPENDED    Memory management fault exception pending bit
: SCB-SHCRS_BUSFAULTPENDED   %1 14 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_BUSFAULTPENDED    Bus fault exception pending bit
: SCB-SHCRS_SVCALLPENDED   %1 15 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_SVCALLPENDED    SVC call pending bit
: SCB-SHCRS_MEMFAULTENA   %1 16 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_MEMFAULTENA    Memory management fault enable bit
: SCB-SHCRS_BUSFAULTENA   %1 17 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_BUSFAULTENA    Bus fault enable bit
: SCB-SHCRS_USGFAULTENA   %1 18 lshift SCB-SHCRS bis! ;  \ SCB-SHCRS_USGFAULTENA    Usage fault enable bit

\ SCB-CFSR_UFSR_BFSR_MMFSR (read-write)
: SCB-CFSR_UFSR_BFSR_MMFSR_IACCVIOL   %1 1 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_IACCVIOL    Instruction access violation flag
: SCB-CFSR_UFSR_BFSR_MMFSR_MUNSTKERR   %1 3 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_MUNSTKERR    Memory manager fault on unstacking for a return from exception
: SCB-CFSR_UFSR_BFSR_MMFSR_MSTKERR   %1 4 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_MSTKERR    Memory manager fault on stacking for exception entry.
: SCB-CFSR_UFSR_BFSR_MMFSR_MLSPERR   %1 5 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_MLSPERR    MLSPERR
: SCB-CFSR_UFSR_BFSR_MMFSR_MMARVALID   %1 7 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_MMARVALID    Memory Management Fault Address Register MMAR valid flag
: SCB-CFSR_UFSR_BFSR_MMFSR_IBUSERR   %1 8 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_IBUSERR    Instruction bus error
: SCB-CFSR_UFSR_BFSR_MMFSR_PRECISERR   %1 9 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_PRECISERR    Precise data bus error
: SCB-CFSR_UFSR_BFSR_MMFSR_IMPRECISERR   %1 10 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_IMPRECISERR    Imprecise data bus error
: SCB-CFSR_UFSR_BFSR_MMFSR_UNSTKERR   %1 11 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_UNSTKERR    Bus fault on unstacking for a return from exception
: SCB-CFSR_UFSR_BFSR_MMFSR_STKERR   %1 12 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_STKERR    Bus fault on stacking for exception entry
: SCB-CFSR_UFSR_BFSR_MMFSR_LSPERR   %1 13 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_LSPERR    Bus fault on floating-point lazy state preservation
: SCB-CFSR_UFSR_BFSR_MMFSR_BFARVALID   %1 15 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_BFARVALID    Bus Fault Address Register BFAR valid flag
: SCB-CFSR_UFSR_BFSR_MMFSR_UNDEFINSTR   %1 16 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_UNDEFINSTR    Undefined instruction usage fault
: SCB-CFSR_UFSR_BFSR_MMFSR_INVSTATE   %1 17 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_INVSTATE    Invalid state usage fault
: SCB-CFSR_UFSR_BFSR_MMFSR_INVPC   %1 18 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_INVPC    Invalid PC load usage fault
: SCB-CFSR_UFSR_BFSR_MMFSR_NOCP   %1 19 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_NOCP    No coprocessor usage fault.
: SCB-CFSR_UFSR_BFSR_MMFSR_UNALIGNED   %1 24 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_UNALIGNED    Unaligned access usage fault
: SCB-CFSR_UFSR_BFSR_MMFSR_DIVBYZERO   %1 25 lshift SCB-CFSR_UFSR_BFSR_MMFSR bis! ;  \ SCB-CFSR_UFSR_BFSR_MMFSR_DIVBYZERO    Divide by zero usage fault

\ SCB-HFSR (read-write)
: SCB-HFSR_VECTTBL   %1 1 lshift SCB-HFSR bis! ;  \ SCB-HFSR_VECTTBL    Vector table hard fault
: SCB-HFSR_FORCED   %1 30 lshift SCB-HFSR bis! ;  \ SCB-HFSR_FORCED    Forced hard fault
: SCB-HFSR_DEBUG_VT   %1 31 lshift SCB-HFSR bis! ;  \ SCB-HFSR_DEBUG_VT    Reserved for Debug use

\ SCB-MMFAR (read-write)
: SCB-MMFAR_MMFAR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift SCB-MMFAR bis! ;  \ SCB-MMFAR_MMFAR    Memory management fault address

\ SCB-BFAR (read-write)
: SCB-BFAR_BFAR   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift SCB-BFAR bis! ;  \ SCB-BFAR_BFAR    Bus fault address

\ SCB-AFSR (read-write)
: SCB-AFSR_IMPDEF   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift SCB-AFSR bis! ;  \ SCB-AFSR_IMPDEF    Implementation defined

\ STK-CTRL (read-write)
: STK-CTRL_ENABLE   %1 0 lshift STK-CTRL bis! ;  \ STK-CTRL_ENABLE    Counter enable
: STK-CTRL_TICKINT   %1 1 lshift STK-CTRL bis! ;  \ STK-CTRL_TICKINT    SysTick exception request enable
: STK-CTRL_CLKSOURCE   %1 2 lshift STK-CTRL bis! ;  \ STK-CTRL_CLKSOURCE    Clock source selection
: STK-CTRL_COUNTFLAG   %1 16 lshift STK-CTRL bis! ;  \ STK-CTRL_COUNTFLAG    COUNTFLAG

\ STK-LOAD (read-write)
: STK-LOAD_RELOAD   ( %XXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift STK-LOAD bis! ;  \ STK-LOAD_RELOAD    RELOAD value

\ STK-VAL (read-write)
: STK-VAL_CURRENT   ( %XXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift STK-VAL bis! ;  \ STK-VAL_CURRENT    Current counter value

\ STK-CALIB (read-write)
: STK-CALIB_TENMS   ( %XXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift STK-CALIB bis! ;  \ STK-CALIB_TENMS    Calibration value
: STK-CALIB_SKEW   %1 30 lshift STK-CALIB bis! ;  \ STK-CALIB_SKEW    SKEW flag: Indicates whether the TENMS value is exact
: STK-CALIB_NOREF   %1 31 lshift STK-CALIB bis! ;  \ STK-CALIB_NOREF    NOREF flag. Reads as zero

\ MPU-MPU_TYPER (read-only)
: MPU-MPU_TYPER_SEPARATE   %1 0 lshift MPU-MPU_TYPER bis! ;  \ MPU-MPU_TYPER_SEPARATE    Separate flag
: MPU-MPU_TYPER_DREGION   ( %XXXXXXXX -- ) 8 lshift MPU-MPU_TYPER bis! ;  \ MPU-MPU_TYPER_DREGION    Number of MPU data regions
: MPU-MPU_TYPER_IREGION   ( %XXXXXXXX -- ) 16 lshift MPU-MPU_TYPER bis! ;  \ MPU-MPU_TYPER_IREGION    Number of MPU instruction regions

\ MPU-MPU_CTRL (read-only)
: MPU-MPU_CTRL_ENABLE   %1 0 lshift MPU-MPU_CTRL bis! ;  \ MPU-MPU_CTRL_ENABLE    Enables the MPU
: MPU-MPU_CTRL_HFNMIENA   %1 1 lshift MPU-MPU_CTRL bis! ;  \ MPU-MPU_CTRL_HFNMIENA    Enables the operation of MPU during hard fault
: MPU-MPU_CTRL_PRIVDEFENA   %1 2 lshift MPU-MPU_CTRL bis! ;  \ MPU-MPU_CTRL_PRIVDEFENA    Enable priviliged software access to default memory map

\ MPU-MPU_RNR (read-write)
: MPU-MPU_RNR_REGION   ( %XXXXXXXX -- ) 0 lshift MPU-MPU_RNR bis! ;  \ MPU-MPU_RNR_REGION    MPU region

\ MPU-MPU_RBAR (read-write)
: MPU-MPU_RBAR_REGION   ( %XXXX -- ) 0 lshift MPU-MPU_RBAR bis! ;  \ MPU-MPU_RBAR_REGION    MPU region field
: MPU-MPU_RBAR_VALID   %1 4 lshift MPU-MPU_RBAR bis! ;  \ MPU-MPU_RBAR_VALID    MPU region number valid
: MPU-MPU_RBAR_ADDR  5 lshift MPU-MPU_RBAR bis! ;  \ MPU-MPU_RBAR_ADDR    Region base address field

\ MPU-MPU_RASR (read-write)
: MPU-MPU_RASR_ENABLE   %1 0 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_ENABLE    Region enable bit.
: MPU-MPU_RASR_SIZE   ( %XXXXX -- ) 1 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_SIZE    Size of the MPU protection region
: MPU-MPU_RASR_SRD   ( %XXXXXXXX -- ) 8 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_SRD    Subregion disable bits
: MPU-MPU_RASR_B   %1 16 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_B    memory attribute
: MPU-MPU_RASR_C   %1 17 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_C    memory attribute
: MPU-MPU_RASR_S   %1 18 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_S    Shareable memory attribute
: MPU-MPU_RASR_TEX   ( %XXX -- ) 19 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_TEX    memory attribute
: MPU-MPU_RASR_AP   ( %XXX -- ) 24 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_AP    Access permission
: MPU-MPU_RASR_XN   %1 28 lshift MPU-MPU_RASR bis! ;  \ MPU-MPU_RASR_XN    Instruction access disable bit

\ FPU-FPCCR (read-write)
: FPU-FPCCR_LSPACT   %1 0 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_LSPACT    LSPACT
: FPU-FPCCR_USER   %1 1 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_USER    USER
: FPU-FPCCR_THREAD   %1 3 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_THREAD    THREAD
: FPU-FPCCR_HFRDY   %1 4 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_HFRDY    HFRDY
: FPU-FPCCR_MMRDY   %1 5 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_MMRDY    MMRDY
: FPU-FPCCR_BFRDY   %1 6 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_BFRDY    BFRDY
: FPU-FPCCR_MONRDY   %1 8 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_MONRDY    MONRDY
: FPU-FPCCR_LSPEN   %1 30 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_LSPEN    LSPEN
: FPU-FPCCR_ASPEN   %1 31 lshift FPU-FPCCR bis! ;  \ FPU-FPCCR_ASPEN    ASPEN

\ FPU-FPCAR (read-write)
: FPU-FPCAR_ADDRESS  3 lshift FPU-FPCAR bis! ;  \ FPU-FPCAR_ADDRESS    Location of unpopulated floating-point

\ FPU-FPSCR (read-write)
: FPU-FPSCR_IOC   %1 0 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_IOC    Invalid operation cumulative exception bit
: FPU-FPSCR_DZC   %1 1 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_DZC    Division by zero cumulative exception bit.
: FPU-FPSCR_OFC   %1 2 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_OFC    Overflow cumulative exception bit
: FPU-FPSCR_UFC   %1 3 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_UFC    Underflow cumulative exception bit
: FPU-FPSCR_IXC   %1 4 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_IXC    Inexact cumulative exception bit
: FPU-FPSCR_IDC   %1 7 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_IDC    Input denormal cumulative exception bit.
: FPU-FPSCR_RMode   ( %XX -- ) 22 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_RMode    Rounding Mode control field
: FPU-FPSCR_FZ   %1 24 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_FZ    Flush-to-zero mode control bit:
: FPU-FPSCR_DN   %1 25 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_DN    Default NaN mode control bit
: FPU-FPSCR_AHP   %1 26 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_AHP    Alternative half-precision control bit
: FPU-FPSCR_V   %1 28 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_V    Overflow condition code flag
: FPU-FPSCR_C   %1 29 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_C    Carry condition code flag
: FPU-FPSCR_Z   %1 30 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_Z    Zero condition code flag
: FPU-FPSCR_N   %1 31 lshift FPU-FPSCR bis! ;  \ FPU-FPSCR_N    Negative condition code flag

\ NVIC-ISER0 (read-write)
: NVIC-ISER0_SETENA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ISER0 bis! ;  \ NVIC-ISER0_SETENA    SETENA

\ NVIC-ISER1 (read-write)
: NVIC-ISER1_SETENA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ISER1 bis! ;  \ NVIC-ISER1_SETENA    SETENA

\ NVIC-ICER0 (read-write)
: NVIC-ICER0_CLRENA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ICER0 bis! ;  \ NVIC-ICER0_CLRENA    CLRENA

\ NVIC-ICER1 (read-write)
: NVIC-ICER1_CLRENA   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ICER1 bis! ;  \ NVIC-ICER1_CLRENA    CLRENA

\ NVIC-ISPR0 (read-write)
: NVIC-ISPR0_SETPEND   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ISPR0 bis! ;  \ NVIC-ISPR0_SETPEND    SETPEND

\ NVIC-ISPR1 (read-write)
: NVIC-ISPR1_SETPEND   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ISPR1 bis! ;  \ NVIC-ISPR1_SETPEND    SETPEND

\ NVIC-ICPR0 (read-write)
: NVIC-ICPR0_CLRPEND   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ICPR0 bis! ;  \ NVIC-ICPR0_CLRPEND    CLRPEND

\ NVIC-ICPR1 (read-write)
: NVIC-ICPR1_CLRPEND   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-ICPR1 bis! ;  \ NVIC-ICPR1_CLRPEND    CLRPEND

\ NVIC-IABR0 (read-only)
: NVIC-IABR0_ACTIVE   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-IABR0 bis! ;  \ NVIC-IABR0_ACTIVE    ACTIVE

\ NVIC-IABR1 (read-only)
: NVIC-IABR1_ACTIVE   ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) 0 lshift NVIC-IABR1 bis! ;  \ NVIC-IABR1_ACTIVE    ACTIVE

\ NVIC-IPR0 (read-write)
: NVIC-IPR0_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR0 bis! ;  \ NVIC-IPR0_IPR_N0    IPR_N0
: NVIC-IPR0_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR0 bis! ;  \ NVIC-IPR0_IPR_N1    IPR_N1
: NVIC-IPR0_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR0 bis! ;  \ NVIC-IPR0_IPR_N2    IPR_N2
: NVIC-IPR0_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR0 bis! ;  \ NVIC-IPR0_IPR_N3    IPR_N3

\ NVIC-IPR1 (read-write)
: NVIC-IPR1_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR1 bis! ;  \ NVIC-IPR1_IPR_N0    IPR_N0
: NVIC-IPR1_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR1 bis! ;  \ NVIC-IPR1_IPR_N1    IPR_N1
: NVIC-IPR1_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR1 bis! ;  \ NVIC-IPR1_IPR_N2    IPR_N2
: NVIC-IPR1_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR1 bis! ;  \ NVIC-IPR1_IPR_N3    IPR_N3

\ NVIC-IPR2 (read-write)
: NVIC-IPR2_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR2 bis! ;  \ NVIC-IPR2_IPR_N0    IPR_N0
: NVIC-IPR2_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR2 bis! ;  \ NVIC-IPR2_IPR_N1    IPR_N1
: NVIC-IPR2_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR2 bis! ;  \ NVIC-IPR2_IPR_N2    IPR_N2
: NVIC-IPR2_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR2 bis! ;  \ NVIC-IPR2_IPR_N3    IPR_N3

\ NVIC-IPR3 (read-write)
: NVIC-IPR3_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR3 bis! ;  \ NVIC-IPR3_IPR_N0    IPR_N0
: NVIC-IPR3_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR3 bis! ;  \ NVIC-IPR3_IPR_N1    IPR_N1
: NVIC-IPR3_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR3 bis! ;  \ NVIC-IPR3_IPR_N2    IPR_N2
: NVIC-IPR3_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR3 bis! ;  \ NVIC-IPR3_IPR_N3    IPR_N3

\ NVIC-IPR4 (read-write)
: NVIC-IPR4_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR4 bis! ;  \ NVIC-IPR4_IPR_N0    IPR_N0
: NVIC-IPR4_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR4 bis! ;  \ NVIC-IPR4_IPR_N1    IPR_N1
: NVIC-IPR4_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR4 bis! ;  \ NVIC-IPR4_IPR_N2    IPR_N2
: NVIC-IPR4_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR4 bis! ;  \ NVIC-IPR4_IPR_N3    IPR_N3

\ NVIC-IPR5 (read-write)
: NVIC-IPR5_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR5 bis! ;  \ NVIC-IPR5_IPR_N0    IPR_N0
: NVIC-IPR5_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR5 bis! ;  \ NVIC-IPR5_IPR_N1    IPR_N1
: NVIC-IPR5_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR5 bis! ;  \ NVIC-IPR5_IPR_N2    IPR_N2
: NVIC-IPR5_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR5 bis! ;  \ NVIC-IPR5_IPR_N3    IPR_N3

\ NVIC-IPR6 (read-write)
: NVIC-IPR6_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR6 bis! ;  \ NVIC-IPR6_IPR_N0    IPR_N0
: NVIC-IPR6_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR6 bis! ;  \ NVIC-IPR6_IPR_N1    IPR_N1
: NVIC-IPR6_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR6 bis! ;  \ NVIC-IPR6_IPR_N2    IPR_N2
: NVIC-IPR6_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR6 bis! ;  \ NVIC-IPR6_IPR_N3    IPR_N3

\ NVIC-IPR7 (read-write)
: NVIC-IPR7_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR7 bis! ;  \ NVIC-IPR7_IPR_N0    IPR_N0
: NVIC-IPR7_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR7 bis! ;  \ NVIC-IPR7_IPR_N1    IPR_N1
: NVIC-IPR7_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR7 bis! ;  \ NVIC-IPR7_IPR_N2    IPR_N2
: NVIC-IPR7_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR7 bis! ;  \ NVIC-IPR7_IPR_N3    IPR_N3

\ NVIC-IPR8 (read-write)
: NVIC-IPR8_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR8 bis! ;  \ NVIC-IPR8_IPR_N0    IPR_N0
: NVIC-IPR8_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR8 bis! ;  \ NVIC-IPR8_IPR_N1    IPR_N1
: NVIC-IPR8_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR8 bis! ;  \ NVIC-IPR8_IPR_N2    IPR_N2
: NVIC-IPR8_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR8 bis! ;  \ NVIC-IPR8_IPR_N3    IPR_N3

\ NVIC-IPR9 (read-write)
: NVIC-IPR9_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR9 bis! ;  \ NVIC-IPR9_IPR_N0    IPR_N0
: NVIC-IPR9_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR9 bis! ;  \ NVIC-IPR9_IPR_N1    IPR_N1
: NVIC-IPR9_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR9 bis! ;  \ NVIC-IPR9_IPR_N2    IPR_N2
: NVIC-IPR9_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR9 bis! ;  \ NVIC-IPR9_IPR_N3    IPR_N3

\ NVIC-IPR10 (read-write)
: NVIC-IPR10_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR10 bis! ;  \ NVIC-IPR10_IPR_N0    IPR_N0
: NVIC-IPR10_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR10 bis! ;  \ NVIC-IPR10_IPR_N1    IPR_N1
: NVIC-IPR10_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR10 bis! ;  \ NVIC-IPR10_IPR_N2    IPR_N2
: NVIC-IPR10_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR10 bis! ;  \ NVIC-IPR10_IPR_N3    IPR_N3

\ NVIC-IPR11 (read-write)
: NVIC-IPR11_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR11 bis! ;  \ NVIC-IPR11_IPR_N0    IPR_N0
: NVIC-IPR11_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR11 bis! ;  \ NVIC-IPR11_IPR_N1    IPR_N1
: NVIC-IPR11_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR11 bis! ;  \ NVIC-IPR11_IPR_N2    IPR_N2
: NVIC-IPR11_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR11 bis! ;  \ NVIC-IPR11_IPR_N3    IPR_N3

\ NVIC-IPR12 (read-write)
: NVIC-IPR12_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR12 bis! ;  \ NVIC-IPR12_IPR_N0    IPR_N0
: NVIC-IPR12_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR12 bis! ;  \ NVIC-IPR12_IPR_N1    IPR_N1
: NVIC-IPR12_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR12 bis! ;  \ NVIC-IPR12_IPR_N2    IPR_N2
: NVIC-IPR12_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR12 bis! ;  \ NVIC-IPR12_IPR_N3    IPR_N3

\ NVIC-IPR13 (read-write)
: NVIC-IPR13_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR13 bis! ;  \ NVIC-IPR13_IPR_N0    IPR_N0
: NVIC-IPR13_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR13 bis! ;  \ NVIC-IPR13_IPR_N1    IPR_N1
: NVIC-IPR13_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR13 bis! ;  \ NVIC-IPR13_IPR_N2    IPR_N2
: NVIC-IPR13_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR13 bis! ;  \ NVIC-IPR13_IPR_N3    IPR_N3

\ NVIC-IPR14 (read-write)
: NVIC-IPR14_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR14 bis! ;  \ NVIC-IPR14_IPR_N0    IPR_N0
: NVIC-IPR14_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR14 bis! ;  \ NVIC-IPR14_IPR_N1    IPR_N1
: NVIC-IPR14_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR14 bis! ;  \ NVIC-IPR14_IPR_N2    IPR_N2
: NVIC-IPR14_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR14 bis! ;  \ NVIC-IPR14_IPR_N3    IPR_N3

\ NVIC-IPR15 (read-write)
: NVIC-IPR15_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR15 bis! ;  \ NVIC-IPR15_IPR_N0    IPR_N0
: NVIC-IPR15_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR15 bis! ;  \ NVIC-IPR15_IPR_N1    IPR_N1
: NVIC-IPR15_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR15 bis! ;  \ NVIC-IPR15_IPR_N2    IPR_N2
: NVIC-IPR15_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR15 bis! ;  \ NVIC-IPR15_IPR_N3    IPR_N3

\ NVIC-IPR16 (read-write)
: NVIC-IPR16_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR16 bis! ;  \ NVIC-IPR16_IPR_N0    IPR_N0
: NVIC-IPR16_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR16 bis! ;  \ NVIC-IPR16_IPR_N1    IPR_N1
: NVIC-IPR16_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR16 bis! ;  \ NVIC-IPR16_IPR_N2    IPR_N2
: NVIC-IPR16_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR16 bis! ;  \ NVIC-IPR16_IPR_N3    IPR_N3

\ NVIC-IPR17 (read-write)
: NVIC-IPR17_IPR_N0   ( %XXXXXXXX -- ) 0 lshift NVIC-IPR17 bis! ;  \ NVIC-IPR17_IPR_N0    IPR_N0
: NVIC-IPR17_IPR_N1   ( %XXXXXXXX -- ) 8 lshift NVIC-IPR17 bis! ;  \ NVIC-IPR17_IPR_N1    IPR_N1
: NVIC-IPR17_IPR_N2   ( %XXXXXXXX -- ) 16 lshift NVIC-IPR17 bis! ;  \ NVIC-IPR17_IPR_N2    IPR_N2
: NVIC-IPR17_IPR_N3   ( %XXXXXXXX -- ) 24 lshift NVIC-IPR17 bis! ;  \ NVIC-IPR17_IPR_N3    IPR_N3

\ NVIC_STIR-STIR (read-write)
: NVIC_STIR-STIR_INTID   ( %XXXXXXXXX -- ) 0 lshift NVIC_STIR-STIR bis! ;  \ NVIC_STIR-STIR_INTID    Software generated interrupt ID

\ SCB_ACTRL-ACTRL (read-write)
: SCB_ACTRL-ACTRL_DISMCYCINT   %1 0 lshift SCB_ACTRL-ACTRL bis! ;  \ SCB_ACTRL-ACTRL_DISMCYCINT    DISMCYCINT
: SCB_ACTRL-ACTRL_DISDEFWBUF   %1 1 lshift SCB_ACTRL-ACTRL bis! ;  \ SCB_ACTRL-ACTRL_DISDEFWBUF    DISDEFWBUF
: SCB_ACTRL-ACTRL_DISFOLD   %1 2 lshift SCB_ACTRL-ACTRL bis! ;  \ SCB_ACTRL-ACTRL_DISFOLD    DISFOLD
: SCB_ACTRL-ACTRL_DISFPCA   %1 8 lshift SCB_ACTRL-ACTRL bis! ;  \ SCB_ACTRL-ACTRL_DISFPCA    DISFPCA
: SCB_ACTRL-ACTRL_DISOOFP   %1 9 lshift SCB_ACTRL-ACTRL bis! ;  \ SCB_ACTRL-ACTRL_DISOOFP    DISOOFP

\ FPU_CPACR-CPACR (read-write)
: FPU_CPACR-CPACR_CP   ( %XXXX -- ) 20 lshift FPU_CPACR-CPACR bis! ;  \ FPU_CPACR-CPACR_CP    CP
