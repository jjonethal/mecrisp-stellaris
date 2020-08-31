\ TEMPLATE FILE for STM32WBxx_CM4
\ created by svdcutter for Mecrisp-Stellaris Forth by Matthias Koch
\ sdvcutter  takes a CMSIS-SVD file plus a hand edited config.xml file as input 
\ By Terry Porter "terry@tjporter.com.au", released under the GPL V2 Licence

 compiletoflash

\ available forth template words as selected by config.xml

$40020000 constant DMA1 ( Direct memory access controller ) 
DMA1 $0 + constant DMA1-ISR ( interrupt status register ) 
DMA1 $4 + constant DMA1-IFCR ( interrupt flag clear register ) 
DMA1 $8 + constant DMA1-CCR1 ( channel x configuration register ) 
DMA1 $C + constant DMA1-CNDTR1 ( channel x number of data register ) 
DMA1 $10 + constant DMA1-CPAR1 ( channel x peripheral address register ) 
DMA1 $14 + constant DMA1-CMAR1 ( channel x memory address register ) 
DMA1 $1C + constant DMA1-CCR2 ( channel x configuration register ) 
DMA1 $20 + constant DMA1-CNDTR2 ( channel x number of data register ) 
DMA1 $24 + constant DMA1-CPAR2 ( channel x peripheral address register ) 
DMA1 $28 + constant DMA1-CMAR2 ( channel x memory address register ) 
DMA1 $30 + constant DMA1-CCR3 ( channel x configuration register ) 
DMA1 $34 + constant DMA1-CNDTR3 ( channel x number of data register ) 
DMA1 $38 + constant DMA1-CPAR3 ( channel x peripheral address register ) 
DMA1 $3C + constant DMA1-CMAR3 ( channel x memory address register ) 
DMA1 $44 + constant DMA1-CCR4 ( channel x configuration register ) 
DMA1 $48 + constant DMA1-CNDTR4 ( channel x number of data register ) 
DMA1 $4C + constant DMA1-CPAR4 ( channel x peripheral address register ) 
DMA1 $50 + constant DMA1-CMAR4 ( channel x memory address register ) 
DMA1 $58 + constant DMA1-CCR5 ( channel x configuration register ) 
DMA1 $5C + constant DMA1-CNDTR5 ( channel x number of data register ) 
DMA1 $60 + constant DMA1-CPAR5 ( channel x peripheral address register ) 
DMA1 $64 + constant DMA1-CMAR5 ( channel x memory address register ) 
DMA1 $6C + constant DMA1-CCR6 ( channel x configuration register ) 
DMA1 $70 + constant DMA1-CNDTR6 ( channel x number of data register ) 
DMA1 $74 + constant DMA1-CPAR6 ( channel x peripheral address register ) 
DMA1 $78 + constant DMA1-CMAR6 ( channel x memory address register ) 
DMA1 $80 + constant DMA1-CCR7 ( channel x configuration register ) 
DMA1 $84 + constant DMA1-CNDTR7 ( channel x number of data register ) 
DMA1 $88 + constant DMA1-CPAR7 ( channel x peripheral address register ) 
DMA1 $8C + constant DMA1-CMAR7 ( channel x memory address register ) 
: DMA1-ISR. ." DMA1-ISR (read-only) $" DMA1-ISR @ hex. DMA1-ISR 1b. ;
: DMA1-IFCR. ." DMA1-IFCR (write-only) $" DMA1-IFCR @ hex. DMA1-IFCR 1b. ;
: DMA1-CCR1. ." DMA1-CCR1 (read-write) $" DMA1-CCR1 @ hex. DMA1-CCR1 1b. ;
: DMA1-CNDTR1. ." DMA1-CNDTR1 (read-write) $" DMA1-CNDTR1 @ hex. DMA1-CNDTR1 1b. ;
: DMA1-CPAR1. ." DMA1-CPAR1 (read-write) $" DMA1-CPAR1 @ hex. DMA1-CPAR1 1b. ;
: DMA1-CMAR1. ." DMA1-CMAR1 (read-write) $" DMA1-CMAR1 @ hex. DMA1-CMAR1 1b. ;
: DMA1-CCR2. ." DMA1-CCR2 (read-write) $" DMA1-CCR2 @ hex. DMA1-CCR2 1b. ;
: DMA1-CNDTR2. ." DMA1-CNDTR2 (read-write) $" DMA1-CNDTR2 @ hex. DMA1-CNDTR2 1b. ;
: DMA1-CPAR2. ." DMA1-CPAR2 (read-write) $" DMA1-CPAR2 @ hex. DMA1-CPAR2 1b. ;
: DMA1-CMAR2. ." DMA1-CMAR2 (read-write) $" DMA1-CMAR2 @ hex. DMA1-CMAR2 1b. ;
: DMA1-CCR3. ." DMA1-CCR3 (read-write) $" DMA1-CCR3 @ hex. DMA1-CCR3 1b. ;
: DMA1-CNDTR3. ." DMA1-CNDTR3 (read-write) $" DMA1-CNDTR3 @ hex. DMA1-CNDTR3 1b. ;
: DMA1-CPAR3. ." DMA1-CPAR3 (read-write) $" DMA1-CPAR3 @ hex. DMA1-CPAR3 1b. ;
: DMA1-CMAR3. ." DMA1-CMAR3 (read-write) $" DMA1-CMAR3 @ hex. DMA1-CMAR3 1b. ;
: DMA1-CCR4. ." DMA1-CCR4 (read-write) $" DMA1-CCR4 @ hex. DMA1-CCR4 1b. ;
: DMA1-CNDTR4. ." DMA1-CNDTR4 (read-write) $" DMA1-CNDTR4 @ hex. DMA1-CNDTR4 1b. ;
: DMA1-CPAR4. ." DMA1-CPAR4 (read-write) $" DMA1-CPAR4 @ hex. DMA1-CPAR4 1b. ;
: DMA1-CMAR4. ." DMA1-CMAR4 (read-write) $" DMA1-CMAR4 @ hex. DMA1-CMAR4 1b. ;
: DMA1-CCR5. ." DMA1-CCR5 (read-write) $" DMA1-CCR5 @ hex. DMA1-CCR5 1b. ;
: DMA1-CNDTR5. ." DMA1-CNDTR5 (read-write) $" DMA1-CNDTR5 @ hex. DMA1-CNDTR5 1b. ;
: DMA1-CPAR5. ." DMA1-CPAR5 (read-write) $" DMA1-CPAR5 @ hex. DMA1-CPAR5 1b. ;
: DMA1-CMAR5. ." DMA1-CMAR5 (read-write) $" DMA1-CMAR5 @ hex. DMA1-CMAR5 1b. ;
: DMA1-CCR6. ." DMA1-CCR6 (read-write) $" DMA1-CCR6 @ hex. DMA1-CCR6 1b. ;
: DMA1-CNDTR6. ." DMA1-CNDTR6 (read-write) $" DMA1-CNDTR6 @ hex. DMA1-CNDTR6 1b. ;
: DMA1-CPAR6. ." DMA1-CPAR6 (read-write) $" DMA1-CPAR6 @ hex. DMA1-CPAR6 1b. ;
: DMA1-CMAR6. ." DMA1-CMAR6 (read-write) $" DMA1-CMAR6 @ hex. DMA1-CMAR6 1b. ;
: DMA1-CCR7. ." DMA1-CCR7 (read-write) $" DMA1-CCR7 @ hex. DMA1-CCR7 1b. ;
: DMA1-CNDTR7. ." DMA1-CNDTR7 (read-write) $" DMA1-CNDTR7 @ hex. DMA1-CNDTR7 1b. ;
: DMA1-CPAR7. ." DMA1-CPAR7 (read-write) $" DMA1-CPAR7 @ hex. DMA1-CPAR7 1b. ;
: DMA1-CMAR7. ." DMA1-CMAR7 (read-write) $" DMA1-CMAR7 @ hex. DMA1-CMAR7 1b. ;
: DMA1.
DMA1-ISR.
DMA1-IFCR.
DMA1-CCR1.
DMA1-CNDTR1.
DMA1-CPAR1.
DMA1-CMAR1.
DMA1-CCR2.
DMA1-CNDTR2.
DMA1-CPAR2.
DMA1-CMAR2.
DMA1-CCR3.
DMA1-CNDTR3.
DMA1-CPAR3.
DMA1-CMAR3.
DMA1-CCR4.
DMA1-CNDTR4.
DMA1-CPAR4.
DMA1-CMAR4.
DMA1-CCR5.
DMA1-CNDTR5.
DMA1-CPAR5.
DMA1-CMAR5.
DMA1-CCR6.
DMA1-CNDTR6.
DMA1-CPAR6.
DMA1-CMAR6.
DMA1-CCR7.
DMA1-CNDTR7.
DMA1-CPAR7.
DMA1-CMAR7.
;

$40020400 constant DMA2 ( Direct memory access controller ) 
DMA2 $0 + constant DMA2-ISR ( interrupt status register ) 
DMA2 $4 + constant DMA2-IFCR ( interrupt flag clear register ) 
DMA2 $8 + constant DMA2-CCR1 ( channel x configuration register ) 
DMA2 $C + constant DMA2-CNDTR1 ( channel x number of data register ) 
DMA2 $10 + constant DMA2-CPAR1 ( channel x peripheral address register ) 
DMA2 $14 + constant DMA2-CMAR1 ( channel x memory address register ) 
DMA2 $1C + constant DMA2-CCR2 ( channel x configuration register ) 
DMA2 $20 + constant DMA2-CNDTR2 ( channel x number of data register ) 
DMA2 $24 + constant DMA2-CPAR2 ( channel x peripheral address register ) 
DMA2 $28 + constant DMA2-CMAR2 ( channel x memory address register ) 
DMA2 $30 + constant DMA2-CCR3 ( channel x configuration register ) 
DMA2 $34 + constant DMA2-CNDTR3 ( channel x number of data register ) 
DMA2 $38 + constant DMA2-CPAR3 ( channel x peripheral address register ) 
DMA2 $3C + constant DMA2-CMAR3 ( channel x memory address register ) 
DMA2 $44 + constant DMA2-CCR4 ( channel x configuration register ) 
DMA2 $48 + constant DMA2-CNDTR4 ( channel x number of data register ) 
DMA2 $4C + constant DMA2-CPAR4 ( channel x peripheral address register ) 
DMA2 $50 + constant DMA2-CMAR4 ( channel x memory address register ) 
DMA2 $58 + constant DMA2-CCR5 ( channel x configuration register ) 
DMA2 $5C + constant DMA2-CNDTR5 ( channel x number of data register ) 
DMA2 $60 + constant DMA2-CPAR5 ( channel x peripheral address register ) 
DMA2 $64 + constant DMA2-CMAR5 ( channel x memory address register ) 
DMA2 $6C + constant DMA2-CCR6 ( channel x configuration register ) 
DMA2 $70 + constant DMA2-CNDTR6 ( channel x number of data register ) 
DMA2 $74 + constant DMA2-CPAR6 ( channel x peripheral address register ) 
DMA2 $78 + constant DMA2-CMAR6 ( channel x memory address register ) 
DMA2 $80 + constant DMA2-CCR7 ( channel x configuration register ) 
DMA2 $84 + constant DMA2-CNDTR7 ( channel x number of data register ) 
DMA2 $88 + constant DMA2-CPAR7 ( channel x peripheral address register ) 
DMA2 $8C + constant DMA2-CMAR7 ( channel x memory address register ) 
DMA2 $A8 + constant DMA2-CSELR ( channel selection register ) 
: DMA2-ISR. ." DMA2-ISR (read-only) $" DMA2-ISR @ hex. DMA2-ISR 1b. ;
: DMA2-IFCR. ." DMA2-IFCR (write-only) $" DMA2-IFCR @ hex. DMA2-IFCR 1b. ;
: DMA2-CCR1. ." DMA2-CCR1 (read-write) $" DMA2-CCR1 @ hex. DMA2-CCR1 1b. ;
: DMA2-CNDTR1. ." DMA2-CNDTR1 (read-write) $" DMA2-CNDTR1 @ hex. DMA2-CNDTR1 1b. ;
: DMA2-CPAR1. ." DMA2-CPAR1 (read-write) $" DMA2-CPAR1 @ hex. DMA2-CPAR1 1b. ;
: DMA2-CMAR1. ." DMA2-CMAR1 (read-write) $" DMA2-CMAR1 @ hex. DMA2-CMAR1 1b. ;
: DMA2-CCR2. ." DMA2-CCR2 (read-write) $" DMA2-CCR2 @ hex. DMA2-CCR2 1b. ;
: DMA2-CNDTR2. ." DMA2-CNDTR2 (read-write) $" DMA2-CNDTR2 @ hex. DMA2-CNDTR2 1b. ;
: DMA2-CPAR2. ." DMA2-CPAR2 (read-write) $" DMA2-CPAR2 @ hex. DMA2-CPAR2 1b. ;
: DMA2-CMAR2. ." DMA2-CMAR2 (read-write) $" DMA2-CMAR2 @ hex. DMA2-CMAR2 1b. ;
: DMA2-CCR3. ." DMA2-CCR3 (read-write) $" DMA2-CCR3 @ hex. DMA2-CCR3 1b. ;
: DMA2-CNDTR3. ." DMA2-CNDTR3 (read-write) $" DMA2-CNDTR3 @ hex. DMA2-CNDTR3 1b. ;
: DMA2-CPAR3. ." DMA2-CPAR3 (read-write) $" DMA2-CPAR3 @ hex. DMA2-CPAR3 1b. ;
: DMA2-CMAR3. ." DMA2-CMAR3 (read-write) $" DMA2-CMAR3 @ hex. DMA2-CMAR3 1b. ;
: DMA2-CCR4. ." DMA2-CCR4 (read-write) $" DMA2-CCR4 @ hex. DMA2-CCR4 1b. ;
: DMA2-CNDTR4. ." DMA2-CNDTR4 (read-write) $" DMA2-CNDTR4 @ hex. DMA2-CNDTR4 1b. ;
: DMA2-CPAR4. ." DMA2-CPAR4 (read-write) $" DMA2-CPAR4 @ hex. DMA2-CPAR4 1b. ;
: DMA2-CMAR4. ." DMA2-CMAR4 (read-write) $" DMA2-CMAR4 @ hex. DMA2-CMAR4 1b. ;
: DMA2-CCR5. ." DMA2-CCR5 (read-write) $" DMA2-CCR5 @ hex. DMA2-CCR5 1b. ;
: DMA2-CNDTR5. ." DMA2-CNDTR5 (read-write) $" DMA2-CNDTR5 @ hex. DMA2-CNDTR5 1b. ;
: DMA2-CPAR5. ." DMA2-CPAR5 (read-write) $" DMA2-CPAR5 @ hex. DMA2-CPAR5 1b. ;
: DMA2-CMAR5. ." DMA2-CMAR5 (read-write) $" DMA2-CMAR5 @ hex. DMA2-CMAR5 1b. ;
: DMA2-CCR6. ." DMA2-CCR6 (read-write) $" DMA2-CCR6 @ hex. DMA2-CCR6 1b. ;
: DMA2-CNDTR6. ." DMA2-CNDTR6 (read-write) $" DMA2-CNDTR6 @ hex. DMA2-CNDTR6 1b. ;
: DMA2-CPAR6. ." DMA2-CPAR6 (read-write) $" DMA2-CPAR6 @ hex. DMA2-CPAR6 1b. ;
: DMA2-CMAR6. ." DMA2-CMAR6 (read-write) $" DMA2-CMAR6 @ hex. DMA2-CMAR6 1b. ;
: DMA2-CCR7. ." DMA2-CCR7 (read-write) $" DMA2-CCR7 @ hex. DMA2-CCR7 1b. ;
: DMA2-CNDTR7. ." DMA2-CNDTR7 (read-write) $" DMA2-CNDTR7 @ hex. DMA2-CNDTR7 1b. ;
: DMA2-CPAR7. ." DMA2-CPAR7 (read-write) $" DMA2-CPAR7 @ hex. DMA2-CPAR7 1b. ;
: DMA2-CMAR7. ." DMA2-CMAR7 (read-write) $" DMA2-CMAR7 @ hex. DMA2-CMAR7 1b. ;
: DMA2-CSELR. ." DMA2-CSELR (read-write) $" DMA2-CSELR @ hex. DMA2-CSELR 1b. ;
: DMA2.
DMA2-ISR.
DMA2-IFCR.
DMA2-CCR1.
DMA2-CNDTR1.
DMA2-CPAR1.
DMA2-CMAR1.
DMA2-CCR2.
DMA2-CNDTR2.
DMA2-CPAR2.
DMA2-CMAR2.
DMA2-CCR3.
DMA2-CNDTR3.
DMA2-CPAR3.
DMA2-CMAR3.
DMA2-CCR4.
DMA2-CNDTR4.
DMA2-CPAR4.
DMA2-CMAR4.
DMA2-CCR5.
DMA2-CNDTR5.
DMA2-CPAR5.
DMA2-CMAR5.
DMA2-CCR6.
DMA2-CNDTR6.
DMA2-CPAR6.
DMA2-CMAR6.
DMA2-CCR7.
DMA2-CNDTR7.
DMA2-CPAR7.
DMA2-CMAR7.
DMA2-CSELR.
;

$40020800 constant DMAMUX1 ( Direct memory access Multiplexer ) 
DMAMUX1 $0 + constant DMAMUX1-C0CR ( DMA Multiplexer Channel 0 Control register ) 
DMAMUX1 $4 + constant DMAMUX1-C1CR ( DMA Multiplexer Channel 1 Control register ) 
DMAMUX1 $8 + constant DMAMUX1-C2CR ( DMA Multiplexer Channel 2 Control register ) 
DMAMUX1 $C + constant DMAMUX1-C3CR ( DMA Multiplexer Channel 3 Control register ) 
DMAMUX1 $10 + constant DMAMUX1-C4CR ( DMA Multiplexer Channel 4 Control register ) 
DMAMUX1 $14 + constant DMAMUX1-C5CR ( DMA Multiplexer Channel 5 Control register ) 
DMAMUX1 $18 + constant DMAMUX1-C6CR ( DMA Multiplexer Channel 6 Control register ) 
DMAMUX1 $1C + constant DMAMUX1-C7CR ( DMA Multiplexer Channel 7 Control register ) 
DMAMUX1 $20 + constant DMAMUX1-C8CR ( DMA Multiplexer Channel 8 Control register ) 
DMAMUX1 $24 + constant DMAMUX1-C9CR ( DMA Multiplexer Channel 9 Control register ) 
DMAMUX1 $28 + constant DMAMUX1-C10CR ( DMA Multiplexer Channel 10 Control register ) 
DMAMUX1 $2C + constant DMAMUX1-C11CR ( DMA Multiplexer Channel 11 Control register ) 
DMAMUX1 $30 + constant DMAMUX1-C12CR ( DMA Multiplexer Channel 12 Control register ) 
DMAMUX1 $34 + constant DMAMUX1-C13CR ( DMA Multiplexer Channel 13 Control register ) 
DMAMUX1 $80 + constant DMAMUX1-CSR ( DMA Multiplexer Channel Status register ) 
DMAMUX1 $84 + constant DMAMUX1-CFR ( DMA Channel Clear Flag Register ) 
DMAMUX1 $100 + constant DMAMUX1-RG0CR ( DMA Request Generator 0 Control Register ) 
DMAMUX1 $104 + constant DMAMUX1-RG1CR ( DMA Request Generator 1 Control Register ) 
DMAMUX1 $108 + constant DMAMUX1-RG2CR ( DMA Request Generator 2 Control Register ) 
DMAMUX1 $10C + constant DMAMUX1-RG3CR ( DMA Request Generator 3 Control Register ) 
DMAMUX1 $140 + constant DMAMUX1-RGSR ( DMA Request Generator Status Register ) 
DMAMUX1 $144 + constant DMAMUX1-RGCFR ( DMA Request Generator Clear Flag Register ) 
: DMAMUX1-C0CR. ." DMAMUX1-C0CR (read-write) $" DMAMUX1-C0CR @ hex. DMAMUX1-C0CR 1b. ;
: DMAMUX1-C1CR. ." DMAMUX1-C1CR (read-write) $" DMAMUX1-C1CR @ hex. DMAMUX1-C1CR 1b. ;
: DMAMUX1-C2CR. ." DMAMUX1-C2CR (read-write) $" DMAMUX1-C2CR @ hex. DMAMUX1-C2CR 1b. ;
: DMAMUX1-C3CR. ." DMAMUX1-C3CR (read-write) $" DMAMUX1-C3CR @ hex. DMAMUX1-C3CR 1b. ;
: DMAMUX1-C4CR. ." DMAMUX1-C4CR (read-write) $" DMAMUX1-C4CR @ hex. DMAMUX1-C4CR 1b. ;
: DMAMUX1-C5CR. ." DMAMUX1-C5CR (read-write) $" DMAMUX1-C5CR @ hex. DMAMUX1-C5CR 1b. ;
: DMAMUX1-C6CR. ." DMAMUX1-C6CR (read-write) $" DMAMUX1-C6CR @ hex. DMAMUX1-C6CR 1b. ;
: DMAMUX1-C7CR. ." DMAMUX1-C7CR (read-write) $" DMAMUX1-C7CR @ hex. DMAMUX1-C7CR 1b. ;
: DMAMUX1-C8CR. ." DMAMUX1-C8CR (read-write) $" DMAMUX1-C8CR @ hex. DMAMUX1-C8CR 1b. ;
: DMAMUX1-C9CR. ." DMAMUX1-C9CR (read-write) $" DMAMUX1-C9CR @ hex. DMAMUX1-C9CR 1b. ;
: DMAMUX1-C10CR. ." DMAMUX1-C10CR (read-write) $" DMAMUX1-C10CR @ hex. DMAMUX1-C10CR 1b. ;
: DMAMUX1-C11CR. ." DMAMUX1-C11CR (read-write) $" DMAMUX1-C11CR @ hex. DMAMUX1-C11CR 1b. ;
: DMAMUX1-C12CR. ." DMAMUX1-C12CR (read-write) $" DMAMUX1-C12CR @ hex. DMAMUX1-C12CR 1b. ;
: DMAMUX1-C13CR. ." DMAMUX1-C13CR (read-write) $" DMAMUX1-C13CR @ hex. DMAMUX1-C13CR 1b. ;
: DMAMUX1-CSR. ." DMAMUX1-CSR (read-only) $" DMAMUX1-CSR @ hex. DMAMUX1-CSR 1b. ;
: DMAMUX1-CFR. ." DMAMUX1-CFR (write-only) $" DMAMUX1-CFR @ hex. DMAMUX1-CFR 1b. ;
: DMAMUX1-RG0CR. ." DMAMUX1-RG0CR (read-write) $" DMAMUX1-RG0CR @ hex. DMAMUX1-RG0CR 1b. ;
: DMAMUX1-RG1CR. ." DMAMUX1-RG1CR (read-write) $" DMAMUX1-RG1CR @ hex. DMAMUX1-RG1CR 1b. ;
: DMAMUX1-RG2CR. ." DMAMUX1-RG2CR (read-write) $" DMAMUX1-RG2CR @ hex. DMAMUX1-RG2CR 1b. ;
: DMAMUX1-RG3CR. ." DMAMUX1-RG3CR (read-write) $" DMAMUX1-RG3CR @ hex. DMAMUX1-RG3CR 1b. ;
: DMAMUX1-RGSR. ." DMAMUX1-RGSR (read-only) $" DMAMUX1-RGSR @ hex. DMAMUX1-RGSR 1b. ;
: DMAMUX1-RGCFR. ." DMAMUX1-RGCFR (read-only) $" DMAMUX1-RGCFR @ hex. DMAMUX1-RGCFR 1b. ;
: DMAMUX1.
DMAMUX1-C0CR.
DMAMUX1-C1CR.
DMAMUX1-C2CR.
DMAMUX1-C3CR.
DMAMUX1-C4CR.
DMAMUX1-C5CR.
DMAMUX1-C6CR.
DMAMUX1-C7CR.
DMAMUX1-C8CR.
DMAMUX1-C9CR.
DMAMUX1-C10CR.
DMAMUX1-C11CR.
DMAMUX1-C12CR.
DMAMUX1-C13CR.
DMAMUX1-CSR.
DMAMUX1-CFR.
DMAMUX1-RG0CR.
DMAMUX1-RG1CR.
DMAMUX1-RG2CR.
DMAMUX1-RG3CR.
DMAMUX1-RGSR.
DMAMUX1-RGCFR.
;

$40023000 constant CRC ( Cyclic redundancy check calculation unit ) 
CRC $0 + constant CRC-DR ( Data register ) 
CRC $4 + constant CRC-IDR ( Independent data register ) 
CRC $8 + constant CRC-CR ( Control register ) 
CRC $10 + constant CRC-INIT ( Initial CRC value ) 
CRC $14 + constant CRC-POL ( polynomial ) 
: CRC-DR. ." CRC-DR (read-write) $" CRC-DR @ hex. CRC-DR 1b. ;
: CRC-IDR. ." CRC-IDR (read-write) $" CRC-IDR @ hex. CRC-IDR 1b. ;
: CRC-CR. ." CRC-CR (read-write) $" CRC-CR @ hex. CRC-CR 1b. ;
: CRC-INIT. ." CRC-INIT (read-write) $" CRC-INIT @ hex. CRC-INIT 1b. ;
: CRC-POL. ." CRC-POL (read-write) $" CRC-POL @ hex. CRC-POL 1b. ;
: CRC.
CRC-DR.
CRC-IDR.
CRC-CR.
CRC-INIT.
CRC-POL.
;

$40002400 constant LCD ( Liquid crystal display controller ) 
LCD $0 + constant LCD-CR ( control register ) 
LCD $4 + constant LCD-FCR ( frame control register ) 
LCD $8 + constant LCD-SR ( status register ) 
LCD $C + constant LCD-CLR ( clear register ) 
LCD $14 + constant LCD-RAM_COM0 ( display memory ) 
LCD $1C + constant LCD-RAM_COM1 ( display memory ) 
LCD $24 + constant LCD-RAM_COM2 ( display memory ) 
LCD $2C + constant LCD-RAM_COM3 ( display memory ) 
LCD $34 + constant LCD-RAM_COM4 ( display memory ) 
LCD $3C + constant LCD-RAM_COM5 ( display memory ) 
LCD $44 + constant LCD-RAM_COM6 ( display memory ) 
LCD $4C + constant LCD-RAM_COM7 ( display memory ) 
: LCD-CR. ." LCD-CR (read-write) $" LCD-CR @ hex. LCD-CR 1b. ;
: LCD-FCR. ." LCD-FCR (read-write) $" LCD-FCR @ hex. LCD-FCR 1b. ;
: LCD-SR. ." LCD-SR () $" LCD-SR @ hex. LCD-SR 1b. ;
: LCD-CLR. ." LCD-CLR (write-only) $" LCD-CLR @ hex. LCD-CLR 1b. ;
: LCD-RAM_COM0. ." LCD-RAM_COM0 (read-write) $" LCD-RAM_COM0 @ hex. LCD-RAM_COM0 1b. ;
: LCD-RAM_COM1. ." LCD-RAM_COM1 (read-write) $" LCD-RAM_COM1 @ hex. LCD-RAM_COM1 1b. ;
: LCD-RAM_COM2. ." LCD-RAM_COM2 (read-write) $" LCD-RAM_COM2 @ hex. LCD-RAM_COM2 1b. ;
: LCD-RAM_COM3. ." LCD-RAM_COM3 (read-write) $" LCD-RAM_COM3 @ hex. LCD-RAM_COM3 1b. ;
: LCD-RAM_COM4. ." LCD-RAM_COM4 (read-write) $" LCD-RAM_COM4 @ hex. LCD-RAM_COM4 1b. ;
: LCD-RAM_COM5. ." LCD-RAM_COM5 (read-write) $" LCD-RAM_COM5 @ hex. LCD-RAM_COM5 1b. ;
: LCD-RAM_COM6. ." LCD-RAM_COM6 (read-write) $" LCD-RAM_COM6 @ hex. LCD-RAM_COM6 1b. ;
: LCD-RAM_COM7. ." LCD-RAM_COM7 (read-write) $" LCD-RAM_COM7 @ hex. LCD-RAM_COM7 1b. ;
: LCD.
LCD-CR.
LCD-FCR.
LCD-SR.
LCD-CLR.
LCD-RAM_COM0.
LCD-RAM_COM1.
LCD-RAM_COM2.
LCD-RAM_COM3.
LCD-RAM_COM4.
LCD-RAM_COM5.
LCD-RAM_COM6.
LCD-RAM_COM7.
;

$40024000 constant TSC ( Touch sensing controller ) 
TSC $0 + constant TSC-CR ( control register ) 
TSC $4 + constant TSC-IER ( interrupt enable register ) 
TSC $8 + constant TSC-ICR ( interrupt clear register ) 
TSC $C + constant TSC-ISR ( interrupt status register ) 
TSC $10 + constant TSC-IOHCR ( I/O hysteresis control register ) 
TSC $18 + constant TSC-IOASCR ( I/O analog switch control register ) 
TSC $20 + constant TSC-IOSCR ( I/O sampling control register ) 
TSC $28 + constant TSC-IOCCR ( I/O channel control register ) 
TSC $30 + constant TSC-IOGCSR ( I/O group control status register ) 
TSC $34 + constant TSC-IOG1CR ( I/O group x counter register ) 
TSC $38 + constant TSC-IOG2CR ( I/O group x counter register ) 
TSC $3C + constant TSC-IOG3CR ( I/O group x counter register ) 
TSC $40 + constant TSC-IOG4CR ( I/O group x counter register ) 
TSC $44 + constant TSC-IOG5CR ( I/O group x counter register ) 
TSC $48 + constant TSC-IOG6CR ( I/O group x counter register ) 
TSC $4C + constant TSC-IOG7CR ( I/O group x counter register ) 
: TSC-CR. ." TSC-CR (read-write) $" TSC-CR @ hex. TSC-CR 1b. ;
: TSC-IER. ." TSC-IER (read-write) $" TSC-IER @ hex. TSC-IER 1b. ;
: TSC-ICR. ." TSC-ICR (read-write) $" TSC-ICR @ hex. TSC-ICR 1b. ;
: TSC-ISR. ." TSC-ISR (read-write) $" TSC-ISR @ hex. TSC-ISR 1b. ;
: TSC-IOHCR. ." TSC-IOHCR (read-write) $" TSC-IOHCR @ hex. TSC-IOHCR 1b. ;
: TSC-IOASCR. ." TSC-IOASCR (read-write) $" TSC-IOASCR @ hex. TSC-IOASCR 1b. ;
: TSC-IOSCR. ." TSC-IOSCR (read-write) $" TSC-IOSCR @ hex. TSC-IOSCR 1b. ;
: TSC-IOCCR. ." TSC-IOCCR (read-write) $" TSC-IOCCR @ hex. TSC-IOCCR 1b. ;
: TSC-IOGCSR. ." TSC-IOGCSR () $" TSC-IOGCSR @ hex. TSC-IOGCSR 1b. ;
: TSC-IOG1CR. ." TSC-IOG1CR (read-only) $" TSC-IOG1CR @ hex. TSC-IOG1CR 1b. ;
: TSC-IOG2CR. ." TSC-IOG2CR (read-only) $" TSC-IOG2CR @ hex. TSC-IOG2CR 1b. ;
: TSC-IOG3CR. ." TSC-IOG3CR (read-only) $" TSC-IOG3CR @ hex. TSC-IOG3CR 1b. ;
: TSC-IOG4CR. ." TSC-IOG4CR (read-only) $" TSC-IOG4CR @ hex. TSC-IOG4CR 1b. ;
: TSC-IOG5CR. ." TSC-IOG5CR (read-only) $" TSC-IOG5CR @ hex. TSC-IOG5CR 1b. ;
: TSC-IOG6CR. ." TSC-IOG6CR (read-only) $" TSC-IOG6CR @ hex. TSC-IOG6CR 1b. ;
: TSC-IOG7CR. ." TSC-IOG7CR (read-only) $" TSC-IOG7CR @ hex. TSC-IOG7CR 1b. ;
: TSC.
TSC-CR.
TSC-IER.
TSC-ICR.
TSC-ISR.
TSC-IOHCR.
TSC-IOASCR.
TSC-IOSCR.
TSC-IOCCR.
TSC-IOGCSR.
TSC-IOG1CR.
TSC-IOG2CR.
TSC-IOG3CR.
TSC-IOG4CR.
TSC-IOG5CR.
TSC-IOG6CR.
TSC-IOG7CR.
;

$40003000 constant IWDG ( Independent watchdog ) 
IWDG $0 + constant IWDG-KR ( Key register ) 
IWDG $4 + constant IWDG-PR ( Prescaler register ) 
IWDG $8 + constant IWDG-RLR ( Reload register ) 
IWDG $C + constant IWDG-SR ( Status register ) 
IWDG $10 + constant IWDG-WINR ( Window register ) 
: IWDG-KR. ." IWDG-KR (write-only) $" IWDG-KR @ hex. IWDG-KR 1b. ;
: IWDG-PR. ." IWDG-PR (read-write) $" IWDG-PR @ hex. IWDG-PR 1b. ;
: IWDG-RLR. ." IWDG-RLR (read-write) $" IWDG-RLR @ hex. IWDG-RLR 1b. ;
: IWDG-SR. ." IWDG-SR (read-only) $" IWDG-SR @ hex. IWDG-SR 1b. ;
: IWDG-WINR. ." IWDG-WINR (read-write) $" IWDG-WINR @ hex. IWDG-WINR 1b. ;
: IWDG.
IWDG-KR.
IWDG-PR.
IWDG-RLR.
IWDG-SR.
IWDG-WINR.
;

$40002C00 constant WWDG ( System window watchdog ) 
WWDG $0 + constant WWDG-CR ( Control register ) 
WWDG $4 + constant WWDG-CFR ( Configuration register ) 
WWDG $8 + constant WWDG-SR ( Status register ) 
: WWDG-CR. ." WWDG-CR (read-write) $" WWDG-CR @ hex. WWDG-CR 1b. ;
: WWDG-CFR. ." WWDG-CFR (read-write) $" WWDG-CFR @ hex. WWDG-CFR 1b. ;
: WWDG-SR. ." WWDG-SR (read-write) $" WWDG-SR @ hex. WWDG-SR 1b. ;
: WWDG.
WWDG-CR.
WWDG-CFR.
WWDG-SR.
;

$40010200 constant COMP ( Comparator instance 1 ) 
COMP $0 + constant COMP-COMP1_CSR ( Comparator control and status register ) 
COMP $4 + constant COMP-COMP2_CSR ( Comparator 2 control and status register ) 
: COMP-COMP1_CSR. ." COMP-COMP1_CSR () $" COMP-COMP1_CSR @ hex. COMP-COMP1_CSR 1b. ;
: COMP-COMP2_CSR. ." COMP-COMP2_CSR () $" COMP-COMP2_CSR @ hex. COMP-COMP2_CSR 1b. ;
: COMP.
COMP-COMP1_CSR.
COMP-COMP2_CSR.
;

$40005400 constant I2C1 ( Inter-integrated circuit ) 
I2C1 $0 + constant I2C1-CR1 ( Control register 1 ) 
I2C1 $4 + constant I2C1-CR2 ( Control register 2 ) 
I2C1 $8 + constant I2C1-OAR1 ( Own address register 1 ) 
I2C1 $C + constant I2C1-OAR2 ( Own address register 2 ) 
I2C1 $10 + constant I2C1-TIMINGR ( Timing register ) 
I2C1 $14 + constant I2C1-TIMEOUTR ( Status register 1 ) 
I2C1 $18 + constant I2C1-ISR ( Interrupt and Status register ) 
I2C1 $1C + constant I2C1-ICR ( Interrupt clear register ) 
I2C1 $20 + constant I2C1-PECR ( PEC register ) 
I2C1 $24 + constant I2C1-RXDR ( Receive data register ) 
I2C1 $28 + constant I2C1-TXDR ( Transmit data register ) 
: I2C1-CR1. ." I2C1-CR1 (read-write) $" I2C1-CR1 @ hex. I2C1-CR1 1b. ;
: I2C1-CR2. ." I2C1-CR2 (read-write) $" I2C1-CR2 @ hex. I2C1-CR2 1b. ;
: I2C1-OAR1. ." I2C1-OAR1 (read-write) $" I2C1-OAR1 @ hex. I2C1-OAR1 1b. ;
: I2C1-OAR2. ." I2C1-OAR2 (read-write) $" I2C1-OAR2 @ hex. I2C1-OAR2 1b. ;
: I2C1-TIMINGR. ." I2C1-TIMINGR (read-write) $" I2C1-TIMINGR @ hex. I2C1-TIMINGR 1b. ;
: I2C1-TIMEOUTR. ." I2C1-TIMEOUTR (read-write) $" I2C1-TIMEOUTR @ hex. I2C1-TIMEOUTR 1b. ;
: I2C1-ISR. ." I2C1-ISR () $" I2C1-ISR @ hex. I2C1-ISR 1b. ;
: I2C1-ICR. ." I2C1-ICR (write-only) $" I2C1-ICR @ hex. I2C1-ICR 1b. ;
: I2C1-PECR. ." I2C1-PECR (read-only) $" I2C1-PECR @ hex. I2C1-PECR 1b. ;
: I2C1-RXDR. ." I2C1-RXDR (read-only) $" I2C1-RXDR @ hex. I2C1-RXDR 1b. ;
: I2C1-TXDR. ." I2C1-TXDR (read-write) $" I2C1-TXDR @ hex. I2C1-TXDR 1b. ;
: I2C1.
I2C1-CR1.
I2C1-CR2.
I2C1-OAR1.
I2C1-OAR2.
I2C1-TIMINGR.
I2C1-TIMEOUTR.
I2C1-ISR.
I2C1-ICR.
I2C1-PECR.
I2C1-RXDR.
I2C1-TXDR.
;

$40005C00 constant I2C3 ( Inter-integrated circuit ) 
I2C3 $0 + constant I2C3-CR1 ( Control register 1 ) 
I2C3 $4 + constant I2C3-CR2 ( Control register 2 ) 
I2C3 $8 + constant I2C3-OAR1 ( Own address register 1 ) 
I2C3 $C + constant I2C3-OAR2 ( Own address register 2 ) 
I2C3 $10 + constant I2C3-TIMINGR ( Timing register ) 
I2C3 $14 + constant I2C3-TIMEOUTR ( Status register 1 ) 
I2C3 $18 + constant I2C3-ISR ( Interrupt and Status register ) 
I2C3 $1C + constant I2C3-ICR ( Interrupt clear register ) 
I2C3 $20 + constant I2C3-PECR ( PEC register ) 
I2C3 $24 + constant I2C3-RXDR ( Receive data register ) 
I2C3 $28 + constant I2C3-TXDR ( Transmit data register ) 
: I2C3-CR1. ." I2C3-CR1 (read-write) $" I2C3-CR1 @ hex. I2C3-CR1 1b. ;
: I2C3-CR2. ." I2C3-CR2 (read-write) $" I2C3-CR2 @ hex. I2C3-CR2 1b. ;
: I2C3-OAR1. ." I2C3-OAR1 (read-write) $" I2C3-OAR1 @ hex. I2C3-OAR1 1b. ;
: I2C3-OAR2. ." I2C3-OAR2 (read-write) $" I2C3-OAR2 @ hex. I2C3-OAR2 1b. ;
: I2C3-TIMINGR. ." I2C3-TIMINGR (read-write) $" I2C3-TIMINGR @ hex. I2C3-TIMINGR 1b. ;
: I2C3-TIMEOUTR. ." I2C3-TIMEOUTR (read-write) $" I2C3-TIMEOUTR @ hex. I2C3-TIMEOUTR 1b. ;
: I2C3-ISR. ." I2C3-ISR () $" I2C3-ISR @ hex. I2C3-ISR 1b. ;
: I2C3-ICR. ." I2C3-ICR (write-only) $" I2C3-ICR @ hex. I2C3-ICR 1b. ;
: I2C3-PECR. ." I2C3-PECR (read-only) $" I2C3-PECR @ hex. I2C3-PECR 1b. ;
: I2C3-RXDR. ." I2C3-RXDR (read-only) $" I2C3-RXDR @ hex. I2C3-RXDR 1b. ;
: I2C3-TXDR. ." I2C3-TXDR (read-write) $" I2C3-TXDR @ hex. I2C3-TXDR 1b. ;
: I2C3.
I2C3-CR1.
I2C3-CR2.
I2C3-OAR1.
I2C3-OAR2.
I2C3-TIMINGR.
I2C3-TIMEOUTR.
I2C3-ISR.
I2C3-ICR.
I2C3-PECR.
I2C3-RXDR.
I2C3-TXDR.
;

$58004000 constant Flash ( Flash ) 
Flash $0 + constant Flash-ACR ( Access control register ) 
Flash $8 + constant Flash-KEYR ( Flash key register ) 
Flash $C + constant Flash-OPTKEYR ( Option byte key register ) 
Flash $10 + constant Flash-SR ( Status register ) 
Flash $14 + constant Flash-CR ( Flash control register ) 
Flash $18 + constant Flash-ECCR ( Flash ECC register ) 
Flash $20 + constant Flash-OPTR ( Flash option register ) 
Flash $24 + constant Flash-PCROP1ASR ( Flash Bank 1 PCROP Start address zone A register ) 
Flash $28 + constant Flash-PCROP1AER ( Flash Bank 1 PCROP End address zone A register ) 
Flash $2C + constant Flash-WRP1AR ( Flash Bank 1 WRP area A address register ) 
Flash $30 + constant Flash-WRP1BR ( Flash Bank 1 WRP area B address register ) 
Flash $34 + constant Flash-PCROP1BSR ( Flash Bank 1 PCROP Start address area B register ) 
Flash $38 + constant Flash-PCROP1BER ( Flash Bank 1 PCROP End address area B register ) 
Flash $3C + constant Flash-IPCCBR ( IPCC mailbox data buffer address register ) 
Flash $5C + constant Flash-C2ACR ( CPU2 cortex M0 access control register ) 
Flash $60 + constant Flash-C2SR ( CPU2 cortex M0 status register ) 
Flash $64 + constant Flash-C2CR ( CPU2 cortex M0 control register ) 
Flash $80 + constant Flash-SFR ( Secure flash start address register ) 
Flash $84 + constant Flash-SRRVR ( Secure SRAM2 start address and cortex M0 reset vector register ) 
: Flash-ACR. ." Flash-ACR (read-write) $" Flash-ACR @ hex. Flash-ACR 1b. ;
: Flash-KEYR. ." Flash-KEYR (write-only) $" Flash-KEYR @ hex. Flash-KEYR 1b. ;
: Flash-OPTKEYR. ." Flash-OPTKEYR (write-only) $" Flash-OPTKEYR @ hex. Flash-OPTKEYR 1b. ;
: Flash-SR. ." Flash-SR () $" Flash-SR @ hex. Flash-SR 1b. ;
: Flash-CR. ." Flash-CR (read-write) $" Flash-CR @ hex. Flash-CR 1b. ;
: Flash-ECCR. ." Flash-ECCR () $" Flash-ECCR @ hex. Flash-ECCR 1b. ;
: Flash-OPTR. ." Flash-OPTR (read-write) $" Flash-OPTR @ hex. Flash-OPTR 1b. ;
: Flash-PCROP1ASR. ." Flash-PCROP1ASR (read-write) $" Flash-PCROP1ASR @ hex. Flash-PCROP1ASR 1b. ;
: Flash-PCROP1AER. ." Flash-PCROP1AER (read-write) $" Flash-PCROP1AER @ hex. Flash-PCROP1AER 1b. ;
: Flash-WRP1AR. ." Flash-WRP1AR (read-write) $" Flash-WRP1AR @ hex. Flash-WRP1AR 1b. ;
: Flash-WRP1BR. ." Flash-WRP1BR (read-write) $" Flash-WRP1BR @ hex. Flash-WRP1BR 1b. ;
: Flash-PCROP1BSR. ." Flash-PCROP1BSR (read-write) $" Flash-PCROP1BSR @ hex. Flash-PCROP1BSR 1b. ;
: Flash-PCROP1BER. ." Flash-PCROP1BER (read-write) $" Flash-PCROP1BER @ hex. Flash-PCROP1BER 1b. ;
: Flash-IPCCBR. ." Flash-IPCCBR (read-write) $" Flash-IPCCBR @ hex. Flash-IPCCBR 1b. ;
: Flash-C2ACR. ." Flash-C2ACR (read-write) $" Flash-C2ACR @ hex. Flash-C2ACR 1b. ;
: Flash-C2SR. ." Flash-C2SR (read-write) $" Flash-C2SR @ hex. Flash-C2SR 1b. ;
: Flash-C2CR. ." Flash-C2CR (read-write) $" Flash-C2CR @ hex. Flash-C2CR 1b. ;
: Flash-SFR. ." Flash-SFR (read-write) $" Flash-SFR @ hex. Flash-SFR 1b. ;
: Flash-SRRVR. ." Flash-SRRVR (read-write) $" Flash-SRRVR @ hex. Flash-SRRVR 1b. ;
: Flash.
Flash-ACR.
Flash-KEYR.
Flash-OPTKEYR.
Flash-SR.
Flash-CR.
Flash-ECCR.
Flash-OPTR.
Flash-PCROP1ASR.
Flash-PCROP1AER.
Flash-WRP1AR.
Flash-WRP1BR.
Flash-PCROP1BSR.
Flash-PCROP1BER.
Flash-IPCCBR.
Flash-C2ACR.
Flash-C2SR.
Flash-C2CR.
Flash-SFR.
Flash-SRRVR.
;

$A0001000 constant QUADSPI ( QuadSPI interface ) 
QUADSPI $0 + constant QUADSPI-CR ( control register ) 
QUADSPI $4 + constant QUADSPI-DCR ( device configuration register ) 
QUADSPI $8 + constant QUADSPI-SR ( status register ) 
QUADSPI $C + constant QUADSPI-FCR ( flag clear register ) 
QUADSPI $10 + constant QUADSPI-DLR ( data length register ) 
QUADSPI $14 + constant QUADSPI-CCR ( communication configuration register ) 
QUADSPI $18 + constant QUADSPI-AR ( address register ) 
QUADSPI $1C + constant QUADSPI-ABR ( ABR ) 
QUADSPI $20 + constant QUADSPI-DR ( data register ) 
QUADSPI $24 + constant QUADSPI-PSMKR ( polling status mask register ) 
QUADSPI $28 + constant QUADSPI-PSMAR ( polling status match register ) 
QUADSPI $2C + constant QUADSPI-PIR ( polling interval register ) 
QUADSPI $30 + constant QUADSPI-LPTR ( low-power timeout register ) 
: QUADSPI-CR. ." QUADSPI-CR (read-write) $" QUADSPI-CR @ hex. QUADSPI-CR 1b. ;
: QUADSPI-DCR. ." QUADSPI-DCR (read-write) $" QUADSPI-DCR @ hex. QUADSPI-DCR 1b. ;
: QUADSPI-SR. ." QUADSPI-SR (read-only) $" QUADSPI-SR @ hex. QUADSPI-SR 1b. ;
: QUADSPI-FCR. ." QUADSPI-FCR (read-write) $" QUADSPI-FCR @ hex. QUADSPI-FCR 1b. ;
: QUADSPI-DLR. ." QUADSPI-DLR (read-write) $" QUADSPI-DLR @ hex. QUADSPI-DLR 1b. ;
: QUADSPI-CCR. ." QUADSPI-CCR (read-write) $" QUADSPI-CCR @ hex. QUADSPI-CCR 1b. ;
: QUADSPI-AR. ." QUADSPI-AR (read-write) $" QUADSPI-AR @ hex. QUADSPI-AR 1b. ;
: QUADSPI-ABR. ." QUADSPI-ABR (read-write) $" QUADSPI-ABR @ hex. QUADSPI-ABR 1b. ;
: QUADSPI-DR. ." QUADSPI-DR (read-write) $" QUADSPI-DR @ hex. QUADSPI-DR 1b. ;
: QUADSPI-PSMKR. ." QUADSPI-PSMKR (read-write) $" QUADSPI-PSMKR @ hex. QUADSPI-PSMKR 1b. ;
: QUADSPI-PSMAR. ." QUADSPI-PSMAR (read-write) $" QUADSPI-PSMAR @ hex. QUADSPI-PSMAR 1b. ;
: QUADSPI-PIR. ." QUADSPI-PIR (read-write) $" QUADSPI-PIR @ hex. QUADSPI-PIR 1b. ;
: QUADSPI-LPTR. ." QUADSPI-LPTR (read-write) $" QUADSPI-LPTR @ hex. QUADSPI-LPTR 1b. ;
: QUADSPI.
QUADSPI-CR.
QUADSPI-DCR.
QUADSPI-SR.
QUADSPI-FCR.
QUADSPI-DLR.
QUADSPI-CCR.
QUADSPI-AR.
QUADSPI-ABR.
QUADSPI-DR.
QUADSPI-PSMKR.
QUADSPI-PSMAR.
QUADSPI-PIR.
QUADSPI-LPTR.
;

$58000000 constant RCC ( Reset and clock control ) 
RCC $0 + constant RCC-CR ( Clock control register ) 
RCC $4 + constant RCC-ICSCR ( Internal clock sources calibration register ) 
RCC $8 + constant RCC-CFGR ( Clock configuration register ) 
RCC $C + constant RCC-PLLCFGR ( PLLSYS configuration register ) 
RCC $10 + constant RCC-PLLSAI1CFGR ( PLLSAI1 configuration register ) 
RCC $18 + constant RCC-CIER ( Clock interrupt enable register ) 
RCC $1C + constant RCC-CIFR ( Clock interrupt flag register ) 
RCC $20 + constant RCC-CICR ( Clock interrupt clear register ) 
RCC $24 + constant RCC-SMPSCR ( Step Down converter control register ) 
RCC $28 + constant RCC-AHB1RSTR ( AHB1 peripheral reset register ) 
RCC $2C + constant RCC-AHB2RSTR ( AHB2 peripheral reset register ) 
RCC $30 + constant RCC-AHB3RSTR ( AHB3 peripheral reset register ) 
RCC $38 + constant RCC-APB1RSTR1 ( APB1 peripheral reset register 1 ) 
RCC $3C + constant RCC-APB1RSTR2 ( APB1 peripheral reset register 2 ) 
RCC $40 + constant RCC-APB2RSTR ( APB2 peripheral reset register ) 
RCC $44 + constant RCC-APB3RSTR ( APB3 peripheral reset register ) 
RCC $48 + constant RCC-AHB1ENR ( AHB1 peripheral clock enable register ) 
RCC $4C + constant RCC-AHB2ENR ( AHB2 peripheral clock enable register ) 
RCC $50 + constant RCC-AHB3ENR ( AHB3 peripheral clock enable register ) 
RCC $58 + constant RCC-APB1ENR1 ( APB1ENR1 ) 
RCC $5C + constant RCC-APB1ENR2 ( APB1 peripheral clock enable register 2 ) 
RCC $60 + constant RCC-APB2ENR ( APB2ENR ) 
RCC $68 + constant RCC-AHB1SMENR ( AHB1 peripheral clocks enable in Sleep and Stop modes register ) 
RCC $6C + constant RCC-AHB2SMENR ( AHB2 peripheral clocks enable in Sleep and Stop modes register ) 
RCC $70 + constant RCC-AHB3SMENR ( AHB3 peripheral clocks enable in Sleep and Stop modes register ) 
RCC $78 + constant RCC-APB1SMENR1 ( APB1SMENR1 ) 
RCC $7C + constant RCC-APB1SMENR2 ( APB1 peripheral clocks enable in Sleep and Stop modes register 2 ) 
RCC $80 + constant RCC-APB2SMENR ( APB2SMENR ) 
RCC $88 + constant RCC-CCIPR ( CCIPR ) 
RCC $90 + constant RCC-BDCR ( BDCR ) 
RCC $94 + constant RCC-CSR ( CSR ) 
RCC $98 + constant RCC-CRRCR ( Clock recovery RC register ) 
RCC $9C + constant RCC-HSECR ( Clock HSE register ) 
RCC $108 + constant RCC-EXTCFGR ( Extended clock recovery register ) 
RCC $148 + constant RCC-C2AHB1ENR ( CPU2 AHB1 peripheral clock enable register ) 
RCC $14C + constant RCC-C2AHB2ENR ( CPU2 AHB2 peripheral clock enable register ) 
RCC $150 + constant RCC-C2AHB3ENR ( CPU2 AHB3 peripheral clock enable register ) 
RCC $158 + constant RCC-C2APB1ENR1 ( CPU2 APB1ENR1 ) 
RCC $15C + constant RCC-C2APB1ENR2 ( CPU2 APB1 peripheral clock enable register 2 ) 
RCC $160 + constant RCC-C2APB2ENR ( CPU2 APB2ENR ) 
RCC $164 + constant RCC-C2APB3ENR ( CPU2 APB3ENR ) 
RCC $168 + constant RCC-C2AHB1SMENR ( CPU2 AHB1 peripheral clocks enable in Sleep and Stop modes register ) 
RCC $16C + constant RCC-C2AHB2SMENR ( CPU2 AHB2 peripheral clocks enable in Sleep and Stop modes register ) 
RCC $170 + constant RCC-C2AHB3SMENR ( CPU2 AHB3 peripheral clocks enable in Sleep and Stop modes register ) 
RCC $178 + constant RCC-C2APB1SMENR1 ( CPU2 APB1SMENR1 ) 
RCC $17C + constant RCC-C2APB1SMENR2 ( CPU2 APB1 peripheral clocks enable in Sleep and Stop modes register 2 ) 
RCC $180 + constant RCC-C2APB2SMENR ( CPU2 APB2SMENR ) 
RCC $184 + constant RCC-C2APB3SMENR ( CPU2 APB3SMENR ) 
: RCC-CR. ." RCC-CR () $" RCC-CR @ hex. RCC-CR 1b. ;
: RCC-ICSCR. ." RCC-ICSCR () $" RCC-ICSCR @ hex. RCC-ICSCR 1b. ;
: RCC-CFGR. ." RCC-CFGR () $" RCC-CFGR @ hex. RCC-CFGR 1b. ;
: RCC-PLLCFGR. ." RCC-PLLCFGR (read-write) $" RCC-PLLCFGR @ hex. RCC-PLLCFGR 1b. ;
: RCC-PLLSAI1CFGR. ." RCC-PLLSAI1CFGR (read-write) $" RCC-PLLSAI1CFGR @ hex. RCC-PLLSAI1CFGR 1b. ;
: RCC-CIER. ." RCC-CIER (read-write) $" RCC-CIER @ hex. RCC-CIER 1b. ;
: RCC-CIFR. ." RCC-CIFR (read-only) $" RCC-CIFR @ hex. RCC-CIFR 1b. ;
: RCC-CICR. ." RCC-CICR (write-only) $" RCC-CICR @ hex. RCC-CICR 1b. ;
: RCC-SMPSCR. ." RCC-SMPSCR () $" RCC-SMPSCR @ hex. RCC-SMPSCR 1b. ;
: RCC-AHB1RSTR. ." RCC-AHB1RSTR (read-write) $" RCC-AHB1RSTR @ hex. RCC-AHB1RSTR 1b. ;
: RCC-AHB2RSTR. ." RCC-AHB2RSTR (read-write) $" RCC-AHB2RSTR @ hex. RCC-AHB2RSTR 1b. ;
: RCC-AHB3RSTR. ." RCC-AHB3RSTR (read-write) $" RCC-AHB3RSTR @ hex. RCC-AHB3RSTR 1b. ;
: RCC-APB1RSTR1. ." RCC-APB1RSTR1 (read-write) $" RCC-APB1RSTR1 @ hex. RCC-APB1RSTR1 1b. ;
: RCC-APB1RSTR2. ." RCC-APB1RSTR2 (read-write) $" RCC-APB1RSTR2 @ hex. RCC-APB1RSTR2 1b. ;
: RCC-APB2RSTR. ." RCC-APB2RSTR (read-write) $" RCC-APB2RSTR @ hex. RCC-APB2RSTR 1b. ;
: RCC-APB3RSTR. ." RCC-APB3RSTR (read-write) $" RCC-APB3RSTR @ hex. RCC-APB3RSTR 1b. ;
: RCC-AHB1ENR. ." RCC-AHB1ENR (read-write) $" RCC-AHB1ENR @ hex. RCC-AHB1ENR 1b. ;
: RCC-AHB2ENR. ." RCC-AHB2ENR (read-write) $" RCC-AHB2ENR @ hex. RCC-AHB2ENR 1b. ;
: RCC-AHB3ENR. ." RCC-AHB3ENR (read-write) $" RCC-AHB3ENR @ hex. RCC-AHB3ENR 1b. ;
: RCC-APB1ENR1. ." RCC-APB1ENR1 (read-write) $" RCC-APB1ENR1 @ hex. RCC-APB1ENR1 1b. ;
: RCC-APB1ENR2. ." RCC-APB1ENR2 (read-write) $" RCC-APB1ENR2 @ hex. RCC-APB1ENR2 1b. ;
: RCC-APB2ENR. ." RCC-APB2ENR (read-write) $" RCC-APB2ENR @ hex. RCC-APB2ENR 1b. ;
: RCC-AHB1SMENR. ." RCC-AHB1SMENR (read-write) $" RCC-AHB1SMENR @ hex. RCC-AHB1SMENR 1b. ;
: RCC-AHB2SMENR. ." RCC-AHB2SMENR (read-write) $" RCC-AHB2SMENR @ hex. RCC-AHB2SMENR 1b. ;
: RCC-AHB3SMENR. ." RCC-AHB3SMENR (read-write) $" RCC-AHB3SMENR @ hex. RCC-AHB3SMENR 1b. ;
: RCC-APB1SMENR1. ." RCC-APB1SMENR1 (read-write) $" RCC-APB1SMENR1 @ hex. RCC-APB1SMENR1 1b. ;
: RCC-APB1SMENR2. ." RCC-APB1SMENR2 (read-write) $" RCC-APB1SMENR2 @ hex. RCC-APB1SMENR2 1b. ;
: RCC-APB2SMENR. ." RCC-APB2SMENR (read-write) $" RCC-APB2SMENR @ hex. RCC-APB2SMENR 1b. ;
: RCC-CCIPR. ." RCC-CCIPR (read-write) $" RCC-CCIPR @ hex. RCC-CCIPR 1b. ;
: RCC-BDCR. ." RCC-BDCR () $" RCC-BDCR @ hex. RCC-BDCR 1b. ;
: RCC-CSR. ." RCC-CSR () $" RCC-CSR @ hex. RCC-CSR 1b. ;
: RCC-CRRCR. ." RCC-CRRCR () $" RCC-CRRCR @ hex. RCC-CRRCR 1b. ;
: RCC-HSECR. ." RCC-HSECR () $" RCC-HSECR @ hex. RCC-HSECR 1b. ;
: RCC-EXTCFGR. ." RCC-EXTCFGR () $" RCC-EXTCFGR @ hex. RCC-EXTCFGR 1b. ;
: RCC-C2AHB1ENR. ." RCC-C2AHB1ENR (read-write) $" RCC-C2AHB1ENR @ hex. RCC-C2AHB1ENR 1b. ;
: RCC-C2AHB2ENR. ." RCC-C2AHB2ENR (read-write) $" RCC-C2AHB2ENR @ hex. RCC-C2AHB2ENR 1b. ;
: RCC-C2AHB3ENR. ." RCC-C2AHB3ENR (read-write) $" RCC-C2AHB3ENR @ hex. RCC-C2AHB3ENR 1b. ;
: RCC-C2APB1ENR1. ." RCC-C2APB1ENR1 (read-write) $" RCC-C2APB1ENR1 @ hex. RCC-C2APB1ENR1 1b. ;
: RCC-C2APB1ENR2. ." RCC-C2APB1ENR2 (read-write) $" RCC-C2APB1ENR2 @ hex. RCC-C2APB1ENR2 1b. ;
: RCC-C2APB2ENR. ." RCC-C2APB2ENR (read-write) $" RCC-C2APB2ENR @ hex. RCC-C2APB2ENR 1b. ;
: RCC-C2APB3ENR. ." RCC-C2APB3ENR (read-write) $" RCC-C2APB3ENR @ hex. RCC-C2APB3ENR 1b. ;
: RCC-C2AHB1SMENR. ." RCC-C2AHB1SMENR (read-write) $" RCC-C2AHB1SMENR @ hex. RCC-C2AHB1SMENR 1b. ;
: RCC-C2AHB2SMENR. ." RCC-C2AHB2SMENR (read-write) $" RCC-C2AHB2SMENR @ hex. RCC-C2AHB2SMENR 1b. ;
: RCC-C2AHB3SMENR. ." RCC-C2AHB3SMENR (read-write) $" RCC-C2AHB3SMENR @ hex. RCC-C2AHB3SMENR 1b. ;
: RCC-C2APB1SMENR1. ." RCC-C2APB1SMENR1 (read-write) $" RCC-C2APB1SMENR1 @ hex. RCC-C2APB1SMENR1 1b. ;
: RCC-C2APB1SMENR2. ." RCC-C2APB1SMENR2 (read-write) $" RCC-C2APB1SMENR2 @ hex. RCC-C2APB1SMENR2 1b. ;
: RCC-C2APB2SMENR. ." RCC-C2APB2SMENR (read-write) $" RCC-C2APB2SMENR @ hex. RCC-C2APB2SMENR 1b. ;
: RCC-C2APB3SMENR. ." RCC-C2APB3SMENR (read-write) $" RCC-C2APB3SMENR @ hex. RCC-C2APB3SMENR 1b. ;
: RCC.
RCC-CR.
RCC-ICSCR.
RCC-CFGR.
RCC-PLLCFGR.
RCC-PLLSAI1CFGR.
RCC-CIER.
RCC-CIFR.
RCC-CICR.
RCC-SMPSCR.
RCC-AHB1RSTR.
RCC-AHB2RSTR.
RCC-AHB3RSTR.
RCC-APB1RSTR1.
RCC-APB1RSTR2.
RCC-APB2RSTR.
RCC-APB3RSTR.
RCC-AHB1ENR.
RCC-AHB2ENR.
RCC-AHB3ENR.
RCC-APB1ENR1.
RCC-APB1ENR2.
RCC-APB2ENR.
RCC-AHB1SMENR.
RCC-AHB2SMENR.
RCC-AHB3SMENR.
RCC-APB1SMENR1.
RCC-APB1SMENR2.
RCC-APB2SMENR.
RCC-CCIPR.
RCC-BDCR.
RCC-CSR.
RCC-CRRCR.
RCC-HSECR.
RCC-EXTCFGR.
RCC-C2AHB1ENR.
RCC-C2AHB2ENR.
RCC-C2AHB3ENR.
RCC-C2APB1ENR1.
RCC-C2APB1ENR2.
RCC-C2APB2ENR.
RCC-C2APB3ENR.
RCC-C2AHB1SMENR.
RCC-C2AHB2SMENR.
RCC-C2AHB3SMENR.
RCC-C2APB1SMENR1.
RCC-C2APB1SMENR2.
RCC-C2APB2SMENR.
RCC-C2APB3SMENR.
;

$58000400 constant PWR ( Power control ) 
PWR $0 + constant PWR-CR1 ( Power control register 1 ) 
PWR $4 + constant PWR-CR2 ( Power control register 2 ) 
PWR $8 + constant PWR-CR3 ( Power control register 3 ) 
PWR $C + constant PWR-CR4 ( Power control register 4 ) 
PWR $10 + constant PWR-SR1 ( Power status register 1 ) 
PWR $14 + constant PWR-SR2 ( Power status register 2 ) 
PWR $18 + constant PWR-SCR ( Power status clear register ) 
PWR $1C + constant PWR-CR5 ( Power control register 5 ) 
PWR $20 + constant PWR-PUCRA ( Power Port A pull-up control register ) 
PWR $24 + constant PWR-PDCRA ( Power Port A pull-down control register ) 
PWR $28 + constant PWR-PUCRB ( Power Port B pull-up control register ) 
PWR $2C + constant PWR-PDCRB ( Power Port B pull-down control register ) 
PWR $30 + constant PWR-PUCRC ( Power Port C pull-up control register ) 
PWR $34 + constant PWR-PDCRC ( Power Port C pull-down control register ) 
PWR $38 + constant PWR-PUCRD ( Power Port D pull-up control register ) 
PWR $3C + constant PWR-PDCRD ( Power Port D pull-down control register ) 
PWR $40 + constant PWR-PUCRE ( Power Port E pull-up control register ) 
PWR $44 + constant PWR-PDCRE ( Power Port E pull-down control register ) 
PWR $58 + constant PWR-PUCRH ( Power Port H pull-up control register ) 
PWR $5C + constant PWR-PDCRH ( Power Port H pull-down control register ) 
PWR $80 + constant PWR-C2CR1 ( CPU2 Power control register 1 ) 
PWR $84 + constant PWR-C2CR3 ( CPU2 Power control register 3 ) 
PWR $88 + constant PWR-EXTSCR ( Power status clear register ) 
: PWR-CR1. ." PWR-CR1 (read-write) $" PWR-CR1 @ hex. PWR-CR1 1b. ;
: PWR-CR2. ." PWR-CR2 (read-write) $" PWR-CR2 @ hex. PWR-CR2 1b. ;
: PWR-CR3. ." PWR-CR3 (read-write) $" PWR-CR3 @ hex. PWR-CR3 1b. ;
: PWR-CR4. ." PWR-CR4 (read-write) $" PWR-CR4 @ hex. PWR-CR4 1b. ;
: PWR-SR1. ." PWR-SR1 (read-only) $" PWR-SR1 @ hex. PWR-SR1 1b. ;
: PWR-SR2. ." PWR-SR2 (read-only) $" PWR-SR2 @ hex. PWR-SR2 1b. ;
: PWR-SCR. ." PWR-SCR (write-only) $" PWR-SCR @ hex. PWR-SCR 1b. ;
: PWR-CR5. ." PWR-CR5 (read-write) $" PWR-CR5 @ hex. PWR-CR5 1b. ;
: PWR-PUCRA. ." PWR-PUCRA (read-write) $" PWR-PUCRA @ hex. PWR-PUCRA 1b. ;
: PWR-PDCRA. ." PWR-PDCRA (read-write) $" PWR-PDCRA @ hex. PWR-PDCRA 1b. ;
: PWR-PUCRB. ." PWR-PUCRB (read-write) $" PWR-PUCRB @ hex. PWR-PUCRB 1b. ;
: PWR-PDCRB. ." PWR-PDCRB (read-write) $" PWR-PDCRB @ hex. PWR-PDCRB 1b. ;
: PWR-PUCRC. ." PWR-PUCRC (read-write) $" PWR-PUCRC @ hex. PWR-PUCRC 1b. ;
: PWR-PDCRC. ." PWR-PDCRC (read-write) $" PWR-PDCRC @ hex. PWR-PDCRC 1b. ;
: PWR-PUCRD. ." PWR-PUCRD (read-write) $" PWR-PUCRD @ hex. PWR-PUCRD 1b. ;
: PWR-PDCRD. ." PWR-PDCRD (read-write) $" PWR-PDCRD @ hex. PWR-PDCRD 1b. ;
: PWR-PUCRE. ." PWR-PUCRE (read-write) $" PWR-PUCRE @ hex. PWR-PUCRE 1b. ;
: PWR-PDCRE. ." PWR-PDCRE (read-write) $" PWR-PDCRE @ hex. PWR-PDCRE 1b. ;
: PWR-PUCRH. ." PWR-PUCRH (read-write) $" PWR-PUCRH @ hex. PWR-PUCRH 1b. ;
: PWR-PDCRH. ." PWR-PDCRH (read-write) $" PWR-PDCRH @ hex. PWR-PDCRH 1b. ;
: PWR-C2CR1. ." PWR-C2CR1 (read-write) $" PWR-C2CR1 @ hex. PWR-C2CR1 1b. ;
: PWR-C2CR3. ." PWR-C2CR3 (read-write) $" PWR-C2CR3 @ hex. PWR-C2CR3 1b. ;
: PWR-EXTSCR. ." PWR-EXTSCR () $" PWR-EXTSCR @ hex. PWR-EXTSCR 1b. ;
: PWR.
PWR-CR1.
PWR-CR2.
PWR-CR3.
PWR-CR4.
PWR-SR1.
PWR-SR2.
PWR-SCR.
PWR-CR5.
PWR-PUCRA.
PWR-PDCRA.
PWR-PUCRB.
PWR-PDCRB.
PWR-PUCRC.
PWR-PDCRC.
PWR-PUCRD.
PWR-PDCRD.
PWR-PUCRE.
PWR-PDCRE.
PWR-PUCRH.
PWR-PDCRH.
PWR-C2CR1.
PWR-C2CR3.
PWR-EXTSCR.
;

$40010100 constant SYSCFG ( System configuration controller ) 
SYSCFG $0 + constant SYSCFG-MEMRMP ( memory remap register ) 
SYSCFG $4 + constant SYSCFG-CFGR1 ( configuration register 1 ) 
SYSCFG $8 + constant SYSCFG-EXTICR1 ( external interrupt configuration register 1 ) 
SYSCFG $C + constant SYSCFG-EXTICR2 ( external interrupt configuration register 2 ) 
SYSCFG $10 + constant SYSCFG-EXTICR3 ( external interrupt configuration register 3 ) 
SYSCFG $14 + constant SYSCFG-EXTICR4 ( external interrupt configuration register 4 ) 
SYSCFG $18 + constant SYSCFG-SCSR ( SCSR ) 
SYSCFG $1C + constant SYSCFG-CFGR2 ( CFGR2 ) 
SYSCFG $20 + constant SYSCFG-SWPR ( SRAM2 write protection register ) 
SYSCFG $24 + constant SYSCFG-SKR ( SKR ) 
SYSCFG $28 + constant SYSCFG-SWPR2 ( SRAM2 write protection register 2 ) 
SYSCFG $2C + constant SYSCFG-IMR1 ( CPU1 interrupt mask register 1 ) 
SYSCFG $30 + constant SYSCFG-IMR2 ( CPU1 interrupt mask register 2 ) 
SYSCFG $34 + constant SYSCFG-C2IMR1 ( CPU2 interrupt mask register 1 ) 
SYSCFG $38 + constant SYSCFG-C2IMR2 ( CPU2 interrupt mask register 1 ) 
SYSCFG $3C + constant SYSCFG-SIPCR ( secure IP control register ) 
: SYSCFG-MEMRMP. ." SYSCFG-MEMRMP (read-write) $" SYSCFG-MEMRMP @ hex. SYSCFG-MEMRMP 1b. ;
: SYSCFG-CFGR1. ." SYSCFG-CFGR1 (read-write) $" SYSCFG-CFGR1 @ hex. SYSCFG-CFGR1 1b. ;
: SYSCFG-EXTICR1. ." SYSCFG-EXTICR1 (read-write) $" SYSCFG-EXTICR1 @ hex. SYSCFG-EXTICR1 1b. ;
: SYSCFG-EXTICR2. ." SYSCFG-EXTICR2 (read-write) $" SYSCFG-EXTICR2 @ hex. SYSCFG-EXTICR2 1b. ;
: SYSCFG-EXTICR3. ." SYSCFG-EXTICR3 (read-write) $" SYSCFG-EXTICR3 @ hex. SYSCFG-EXTICR3 1b. ;
: SYSCFG-EXTICR4. ." SYSCFG-EXTICR4 (read-write) $" SYSCFG-EXTICR4 @ hex. SYSCFG-EXTICR4 1b. ;
: SYSCFG-SCSR. ." SYSCFG-SCSR () $" SYSCFG-SCSR @ hex. SYSCFG-SCSR 1b. ;
: SYSCFG-CFGR2. ." SYSCFG-CFGR2 () $" SYSCFG-CFGR2 @ hex. SYSCFG-CFGR2 1b. ;
: SYSCFG-SWPR. ." SYSCFG-SWPR (write-only) $" SYSCFG-SWPR @ hex. SYSCFG-SWPR 1b. ;
: SYSCFG-SKR. ." SYSCFG-SKR (write-only) $" SYSCFG-SKR @ hex. SYSCFG-SKR 1b. ;
: SYSCFG-SWPR2. ." SYSCFG-SWPR2 (write-only) $" SYSCFG-SWPR2 @ hex. SYSCFG-SWPR2 1b. ;
: SYSCFG-IMR1. ." SYSCFG-IMR1 (read-write) $" SYSCFG-IMR1 @ hex. SYSCFG-IMR1 1b. ;
: SYSCFG-IMR2. ." SYSCFG-IMR2 (read-write) $" SYSCFG-IMR2 @ hex. SYSCFG-IMR2 1b. ;
: SYSCFG-C2IMR1. ." SYSCFG-C2IMR1 (read-write) $" SYSCFG-C2IMR1 @ hex. SYSCFG-C2IMR1 1b. ;
: SYSCFG-C2IMR2. ." SYSCFG-C2IMR2 (read-write) $" SYSCFG-C2IMR2 @ hex. SYSCFG-C2IMR2 1b. ;
: SYSCFG-SIPCR. ." SYSCFG-SIPCR (read-write) $" SYSCFG-SIPCR @ hex. SYSCFG-SIPCR 1b. ;
: SYSCFG.
SYSCFG-MEMRMP.
SYSCFG-CFGR1.
SYSCFG-EXTICR1.
SYSCFG-EXTICR2.
SYSCFG-EXTICR3.
SYSCFG-EXTICR4.
SYSCFG-SCSR.
SYSCFG-CFGR2.
SYSCFG-SWPR.
SYSCFG-SKR.
SYSCFG-SWPR2.
SYSCFG-IMR1.
SYSCFG-IMR2.
SYSCFG-C2IMR1.
SYSCFG-C2IMR2.
SYSCFG-SIPCR.
;

$58001000 constant RNG ( Random number generator ) 
RNG $0 + constant RNG-CR ( control register ) 
RNG $4 + constant RNG-SR ( status register ) 
RNG $8 + constant RNG-DR ( data register ) 
: RNG-CR. ." RNG-CR (read-write) $" RNG-CR @ hex. RNG-CR 1b. ;
: RNG-SR. ." RNG-SR () $" RNG-SR @ hex. RNG-SR 1b. ;
: RNG-DR. ." RNG-DR (read-only) $" RNG-DR @ hex. RNG-DR 1b. ;
: RNG.
RNG-CR.
RNG-SR.
RNG-DR.
;

$50060000 constant AES1 ( Advanced encryption standard hardware accelerator 1 ) 
AES1 $0 + constant AES1-CR ( control register ) 
AES1 $4 + constant AES1-SR ( status register ) 
AES1 $8 + constant AES1-DINR ( data input register ) 
AES1 $C + constant AES1-DOUTR ( data output register ) 
AES1 $10 + constant AES1-KEYR0 ( key register 0 ) 
AES1 $14 + constant AES1-KEYR1 ( key register 1 ) 
AES1 $18 + constant AES1-KEYR2 ( key register 2 ) 
AES1 $1C + constant AES1-KEYR3 ( key register 3 ) 
AES1 $20 + constant AES1-IVR0 ( initialization vector register 0 ) 
AES1 $24 + constant AES1-IVR1 ( initialization vector register 1 ) 
AES1 $28 + constant AES1-IVR2 ( initialization vector register 2 ) 
AES1 $2C + constant AES1-IVR3 ( initialization vector register 3 ) 
AES1 $30 + constant AES1-KEYR4 ( key register 4 ) 
AES1 $34 + constant AES1-KEYR5 ( key register 5 ) 
AES1 $38 + constant AES1-KEYR6 ( key register 6 ) 
AES1 $3C + constant AES1-KEYR7 ( key register 7 ) 
AES1 $40 + constant AES1-SUSP0R ( AES suspend register 0 ) 
AES1 $44 + constant AES1-SUSP1R ( AES suspend register 1 ) 
AES1 $48 + constant AES1-SUSP2R ( AES suspend register 2 ) 
AES1 $4C + constant AES1-SUSP3R ( AES suspend register 3 ) 
AES1 $50 + constant AES1-SUSP4R ( AES suspend register 4 ) 
AES1 $54 + constant AES1-SUSP5R ( AES suspend register 5 ) 
AES1 $58 + constant AES1-SUSP6R ( AES suspend register 6 ) 
AES1 $5C + constant AES1-SUSP7R ( AES suspend register 7 ) 
AES1 $3F0 + constant AES1-HWCFR ( AES hardware configuration register ) 
AES1 $3F4 + constant AES1-VERR ( AES version register ) 
AES1 $3F8 + constant AES1-IPIDR ( AES identification register ) 
AES1 $3FC + constant AES1-SIDR ( AES size ID register ) 
: AES1-CR. ." AES1-CR (read-write) $" AES1-CR @ hex. AES1-CR 1b. ;
: AES1-SR. ." AES1-SR (read-only) $" AES1-SR @ hex. AES1-SR 1b. ;
: AES1-DINR. ." AES1-DINR (read-write) $" AES1-DINR @ hex. AES1-DINR 1b. ;
: AES1-DOUTR. ." AES1-DOUTR (read-only) $" AES1-DOUTR @ hex. AES1-DOUTR 1b. ;
: AES1-KEYR0. ." AES1-KEYR0 (read-write) $" AES1-KEYR0 @ hex. AES1-KEYR0 1b. ;
: AES1-KEYR1. ." AES1-KEYR1 (read-write) $" AES1-KEYR1 @ hex. AES1-KEYR1 1b. ;
: AES1-KEYR2. ." AES1-KEYR2 (read-write) $" AES1-KEYR2 @ hex. AES1-KEYR2 1b. ;
: AES1-KEYR3. ." AES1-KEYR3 (read-write) $" AES1-KEYR3 @ hex. AES1-KEYR3 1b. ;
: AES1-IVR0. ." AES1-IVR0 (read-write) $" AES1-IVR0 @ hex. AES1-IVR0 1b. ;
: AES1-IVR1. ." AES1-IVR1 (read-write) $" AES1-IVR1 @ hex. AES1-IVR1 1b. ;
: AES1-IVR2. ." AES1-IVR2 (read-write) $" AES1-IVR2 @ hex. AES1-IVR2 1b. ;
: AES1-IVR3. ." AES1-IVR3 (read-write) $" AES1-IVR3 @ hex. AES1-IVR3 1b. ;
: AES1-KEYR4. ." AES1-KEYR4 (read-write) $" AES1-KEYR4 @ hex. AES1-KEYR4 1b. ;
: AES1-KEYR5. ." AES1-KEYR5 (read-write) $" AES1-KEYR5 @ hex. AES1-KEYR5 1b. ;
: AES1-KEYR6. ." AES1-KEYR6 (read-write) $" AES1-KEYR6 @ hex. AES1-KEYR6 1b. ;
: AES1-KEYR7. ." AES1-KEYR7 (read-write) $" AES1-KEYR7 @ hex. AES1-KEYR7 1b. ;
: AES1-SUSP0R. ." AES1-SUSP0R (read-write) $" AES1-SUSP0R @ hex. AES1-SUSP0R 1b. ;
: AES1-SUSP1R. ." AES1-SUSP1R (read-write) $" AES1-SUSP1R @ hex. AES1-SUSP1R 1b. ;
: AES1-SUSP2R. ." AES1-SUSP2R (read-write) $" AES1-SUSP2R @ hex. AES1-SUSP2R 1b. ;
: AES1-SUSP3R. ." AES1-SUSP3R (read-write) $" AES1-SUSP3R @ hex. AES1-SUSP3R 1b. ;
: AES1-SUSP4R. ." AES1-SUSP4R (read-write) $" AES1-SUSP4R @ hex. AES1-SUSP4R 1b. ;
: AES1-SUSP5R. ." AES1-SUSP5R (read-write) $" AES1-SUSP5R @ hex. AES1-SUSP5R 1b. ;
: AES1-SUSP6R. ." AES1-SUSP6R (read-write) $" AES1-SUSP6R @ hex. AES1-SUSP6R 1b. ;
: AES1-SUSP7R. ." AES1-SUSP7R (read-write) $" AES1-SUSP7R @ hex. AES1-SUSP7R 1b. ;
: AES1-HWCFR. ." AES1-HWCFR (read-only) $" AES1-HWCFR @ hex. AES1-HWCFR 1b. ;
: AES1-VERR. ." AES1-VERR (read-only) $" AES1-VERR @ hex. AES1-VERR 1b. ;
: AES1-IPIDR. ." AES1-IPIDR (read-only) $" AES1-IPIDR @ hex. AES1-IPIDR 1b. ;
: AES1-SIDR. ." AES1-SIDR (read-only) $" AES1-SIDR @ hex. AES1-SIDR 1b. ;
: AES1.
AES1-CR.
AES1-SR.
AES1-DINR.
AES1-DOUTR.
AES1-KEYR0.
AES1-KEYR1.
AES1-KEYR2.
AES1-KEYR3.
AES1-IVR0.
AES1-IVR1.
AES1-IVR2.
AES1-IVR3.
AES1-KEYR4.
AES1-KEYR5.
AES1-KEYR6.
AES1-KEYR7.
AES1-SUSP0R.
AES1-SUSP1R.
AES1-SUSP2R.
AES1-SUSP3R.
AES1-SUSP4R.
AES1-SUSP5R.
AES1-SUSP6R.
AES1-SUSP7R.
AES1-HWCFR.
AES1-VERR.
AES1-IPIDR.
AES1-SIDR.
;

$58001800 constant AES2 ( Advanced encryption standard hardware accelerator 1 ) 
AES2 $0 + constant AES2-CR ( control register ) 
AES2 $4 + constant AES2-SR ( status register ) 
AES2 $8 + constant AES2-DINR ( data input register ) 
AES2 $C + constant AES2-DOUTR ( data output register ) 
AES2 $10 + constant AES2-KEYR0 ( key register 0 ) 
AES2 $14 + constant AES2-KEYR1 ( key register 1 ) 
AES2 $18 + constant AES2-KEYR2 ( key register 2 ) 
AES2 $1C + constant AES2-KEYR3 ( key register 3 ) 
AES2 $20 + constant AES2-IVR0 ( initialization vector register 0 ) 
AES2 $24 + constant AES2-IVR1 ( initialization vector register 1 ) 
AES2 $28 + constant AES2-IVR2 ( initialization vector register 2 ) 
AES2 $2C + constant AES2-IVR3 ( initialization vector register 3 ) 
AES2 $30 + constant AES2-KEYR4 ( key register 4 ) 
AES2 $34 + constant AES2-KEYR5 ( key register 5 ) 
AES2 $38 + constant AES2-KEYR6 ( key register 6 ) 
AES2 $3C + constant AES2-KEYR7 ( key register 7 ) 
AES2 $40 + constant AES2-SUSP0R ( AES suspend register 0 ) 
AES2 $44 + constant AES2-SUSP1R ( AES suspend register 1 ) 
AES2 $48 + constant AES2-SUSP2R ( AES suspend register 2 ) 
AES2 $4C + constant AES2-SUSP3R ( AES suspend register 3 ) 
AES2 $50 + constant AES2-SUSP4R ( AES suspend register 4 ) 
AES2 $54 + constant AES2-SUSP5R ( AES suspend register 5 ) 
AES2 $58 + constant AES2-SUSP6R ( AES suspend register 6 ) 
AES2 $5C + constant AES2-SUSP7R ( AES suspend register 7 ) 
AES2 $60 + constant AES2-HWCFR ( AES hardware configuration register ) 
AES2 $64 + constant AES2-VERR ( AES version register ) 
AES2 $68 + constant AES2-IPIDR ( AES identification register ) 
AES2 $6C + constant AES2-SIDR ( AES size ID register ) 
: AES2-CR. ." AES2-CR (read-write) $" AES2-CR @ hex. AES2-CR 1b. ;
: AES2-SR. ." AES2-SR (read-only) $" AES2-SR @ hex. AES2-SR 1b. ;
: AES2-DINR. ." AES2-DINR (read-write) $" AES2-DINR @ hex. AES2-DINR 1b. ;
: AES2-DOUTR. ." AES2-DOUTR (read-only) $" AES2-DOUTR @ hex. AES2-DOUTR 1b. ;
: AES2-KEYR0. ." AES2-KEYR0 (read-write) $" AES2-KEYR0 @ hex. AES2-KEYR0 1b. ;
: AES2-KEYR1. ." AES2-KEYR1 (read-write) $" AES2-KEYR1 @ hex. AES2-KEYR1 1b. ;
: AES2-KEYR2. ." AES2-KEYR2 (read-write) $" AES2-KEYR2 @ hex. AES2-KEYR2 1b. ;
: AES2-KEYR3. ." AES2-KEYR3 (read-write) $" AES2-KEYR3 @ hex. AES2-KEYR3 1b. ;
: AES2-IVR0. ." AES2-IVR0 (read-write) $" AES2-IVR0 @ hex. AES2-IVR0 1b. ;
: AES2-IVR1. ." AES2-IVR1 (read-write) $" AES2-IVR1 @ hex. AES2-IVR1 1b. ;
: AES2-IVR2. ." AES2-IVR2 (read-write) $" AES2-IVR2 @ hex. AES2-IVR2 1b. ;
: AES2-IVR3. ." AES2-IVR3 (read-write) $" AES2-IVR3 @ hex. AES2-IVR3 1b. ;
: AES2-KEYR4. ." AES2-KEYR4 (read-write) $" AES2-KEYR4 @ hex. AES2-KEYR4 1b. ;
: AES2-KEYR5. ." AES2-KEYR5 (read-write) $" AES2-KEYR5 @ hex. AES2-KEYR5 1b. ;
: AES2-KEYR6. ." AES2-KEYR6 (read-write) $" AES2-KEYR6 @ hex. AES2-KEYR6 1b. ;
: AES2-KEYR7. ." AES2-KEYR7 (read-write) $" AES2-KEYR7 @ hex. AES2-KEYR7 1b. ;
: AES2-SUSP0R. ." AES2-SUSP0R (read-write) $" AES2-SUSP0R @ hex. AES2-SUSP0R 1b. ;
: AES2-SUSP1R. ." AES2-SUSP1R (read-write) $" AES2-SUSP1R @ hex. AES2-SUSP1R 1b. ;
: AES2-SUSP2R. ." AES2-SUSP2R (read-write) $" AES2-SUSP2R @ hex. AES2-SUSP2R 1b. ;
: AES2-SUSP3R. ." AES2-SUSP3R (read-write) $" AES2-SUSP3R @ hex. AES2-SUSP3R 1b. ;
: AES2-SUSP4R. ." AES2-SUSP4R (read-write) $" AES2-SUSP4R @ hex. AES2-SUSP4R 1b. ;
: AES2-SUSP5R. ." AES2-SUSP5R (read-write) $" AES2-SUSP5R @ hex. AES2-SUSP5R 1b. ;
: AES2-SUSP6R. ." AES2-SUSP6R (read-write) $" AES2-SUSP6R @ hex. AES2-SUSP6R 1b. ;
: AES2-SUSP7R. ." AES2-SUSP7R (read-write) $" AES2-SUSP7R @ hex. AES2-SUSP7R 1b. ;
: AES2-HWCFR. ." AES2-HWCFR (read-only) $" AES2-HWCFR @ hex. AES2-HWCFR 1b. ;
: AES2-VERR. ." AES2-VERR (read-only) $" AES2-VERR @ hex. AES2-VERR 1b. ;
: AES2-IPIDR. ." AES2-IPIDR (read-only) $" AES2-IPIDR @ hex. AES2-IPIDR 1b. ;
: AES2-SIDR. ." AES2-SIDR (read-only) $" AES2-SIDR @ hex. AES2-SIDR 1b. ;
: AES2.
AES2-CR.
AES2-SR.
AES2-DINR.
AES2-DOUTR.
AES2-KEYR0.
AES2-KEYR1.
AES2-KEYR2.
AES2-KEYR3.
AES2-IVR0.
AES2-IVR1.
AES2-IVR2.
AES2-IVR3.
AES2-KEYR4.
AES2-KEYR5.
AES2-KEYR6.
AES2-KEYR7.
AES2-SUSP0R.
AES2-SUSP1R.
AES2-SUSP2R.
AES2-SUSP3R.
AES2-SUSP4R.
AES2-SUSP5R.
AES2-SUSP6R.
AES2-SUSP7R.
AES2-HWCFR.
AES2-VERR.
AES2-IPIDR.
AES2-SIDR.
;

$58001400 constant HSEM ( HSEM ) 
HSEM $0 + constant HSEM-R0 ( Semaphore 0 register ) 
HSEM $4 + constant HSEM-R1 ( Semaphore 1 register ) 
HSEM $8 + constant HSEM-R2 ( Semaphore 2 register ) 
HSEM $C + constant HSEM-R3 ( Semaphore 3 register ) 
HSEM $10 + constant HSEM-R4 ( Semaphore 4 register ) 
HSEM $14 + constant HSEM-R5 ( Semaphore 5 register ) 
HSEM $18 + constant HSEM-R6 ( Semaphore 6 register ) 
HSEM $1C + constant HSEM-R7 ( Semaphore 7 register ) 
HSEM $20 + constant HSEM-R8 ( Semaphore 8 register ) 
HSEM $24 + constant HSEM-R9 ( Semaphore 9 register ) 
HSEM $28 + constant HSEM-R10 ( Semaphore 10 register ) 
HSEM $2C + constant HSEM-R11 ( Semaphore 11 register ) 
HSEM $30 + constant HSEM-R12 ( Semaphore 12 register ) 
HSEM $34 + constant HSEM-R13 ( Semaphore 13 register ) 
HSEM $38 + constant HSEM-R14 ( Semaphore 14 register ) 
HSEM $3C + constant HSEM-R15 ( Semaphore 15 register ) 
HSEM $40 + constant HSEM-R16 ( Semaphore 16 register ) 
HSEM $44 + constant HSEM-R17 ( Semaphore 17 register ) 
HSEM $48 + constant HSEM-R18 ( Semaphore 18 register ) 
HSEM $4C + constant HSEM-R19 ( Semaphore 19 register ) 
HSEM $50 + constant HSEM-R20 ( Semaphore 20 register ) 
HSEM $54 + constant HSEM-R21 ( Semaphore 21 register ) 
HSEM $58 + constant HSEM-R22 ( Semaphore 22 register ) 
HSEM $5C + constant HSEM-R23 ( Semaphore 23 register ) 
HSEM $60 + constant HSEM-R24 ( Semaphore 24 register ) 
HSEM $64 + constant HSEM-R25 ( Semaphore 25 register ) 
HSEM $68 + constant HSEM-R26 ( Semaphore 26 register ) 
HSEM $6C + constant HSEM-R27 ( Semaphore 27 register ) 
HSEM $70 + constant HSEM-R28 ( Semaphore 28 register ) 
HSEM $74 + constant HSEM-R29 ( Semaphore 29 register ) 
HSEM $78 + constant HSEM-R30 ( Semaphore 30 register ) 
HSEM $7C + constant HSEM-R31 ( Semaphore 31 register ) 
HSEM $80 + constant HSEM-RLR0 ( Semaphore 0 read lock register ) 
HSEM $84 + constant HSEM-RLR1 ( Semaphore 1 read lock register ) 
HSEM $88 + constant HSEM-RLR2 ( Semaphore 2 read lock register ) 
HSEM $8C + constant HSEM-RLR3 ( Semaphore 3 read lock register ) 
HSEM $90 + constant HSEM-RLR4 ( Semaphore 4 read lock read lock register ) 
HSEM $94 + constant HSEM-RLR5 ( Semaphore 5 read lock register ) 
HSEM $98 + constant HSEM-RLR6 ( Semaphore 6 read lock register ) 
HSEM $9C + constant HSEM-RLR7 ( Semaphore 7 read lock register ) 
HSEM $A0 + constant HSEM-RLR8 ( Semaphore 8 read lock register ) 
HSEM $A4 + constant HSEM-RLR9 ( Semaphore 9 read lock register ) 
HSEM $A8 + constant HSEM-RLR10 ( Semaphore 10 read lock register ) 
HSEM $AC + constant HSEM-RLR11 ( Semaphore 11 read lock register ) 
HSEM $B0 + constant HSEM-RLR12 ( Semaphore 12 read lock register ) 
HSEM $B4 + constant HSEM-RLR13 ( Semaphore 13 read lock register ) 
HSEM $B8 + constant HSEM-RLR14 ( Semaphore 14 read lock register ) 
HSEM $BC + constant HSEM-RLR15 ( Semaphore 15 read lock register ) 
HSEM $C0 + constant HSEM-RLR16 ( Semaphore 16 read lock register ) 
HSEM $C4 + constant HSEM-RLR17 ( Semaphore 17 read lock register ) 
HSEM $C8 + constant HSEM-RLR18 ( Semaphore 18 read lock register ) 
HSEM $CC + constant HSEM-RLR19 ( Semaphore 19 read lock register ) 
HSEM $D0 + constant HSEM-RLR20 ( Semaphore 20 read lock register ) 
HSEM $D4 + constant HSEM-RLR21 ( Semaphore 21 read lock register ) 
HSEM $D8 + constant HSEM-RLR22 ( Semaphore 22 read lock register ) 
HSEM $DC + constant HSEM-RLR23 ( Semaphore 23 read lock register ) 
HSEM $E0 + constant HSEM-RLR24 ( Semaphore 24 read lock register ) 
HSEM $E4 + constant HSEM-RLR25 ( Semaphore 25 read lock register ) 
HSEM $E8 + constant HSEM-RLR26 ( Semaphore 26 read lock register ) 
HSEM $EC + constant HSEM-RLR27 ( Semaphore 27 read lock register ) 
HSEM $F0 + constant HSEM-RLR28 ( Semaphore 28 read lock register ) 
HSEM $F4 + constant HSEM-RLR29 ( Semaphore 29 read lock register ) 
HSEM $F8 + constant HSEM-RLR30 ( Semaphore 30 read lock register ) 
HSEM $FC + constant HSEM-RLR31 ( Semaphore 31 read lock register ) 
HSEM $140 + constant HSEM-CR ( Semaphore Clear register ) 
HSEM $144 + constant HSEM-KEYR ( Interrupt clear register ) 
HSEM $3EC + constant HSEM-HWCFGR2 ( Semaphore hardware configuration register 2 ) 
HSEM $3F0 + constant HSEM-HWCFGR1 ( Semaphore hardware configuration register 1 ) 
HSEM $3F4 + constant HSEM-VERR ( HSEM version register ) 
HSEM $3F8 + constant HSEM-IPIDR ( HSEM indentification register ) 
HSEM $3FC + constant HSEM-SIDR ( HSEM size indentification register ) 
HSEM $100 + constant HSEM-C1IER0 ( HSEM Interrupt enable register ) 
HSEM $104 + constant HSEM-C1ICR ( HSEM Interrupt clear register ) 
HSEM $108 + constant HSEM-C1ISR ( HSEM Interrupt status register ) 
HSEM $10C + constant HSEM-C1MISR ( HSEM Masked interrupt status register ) 
HSEM $110 + constant HSEM-C2IER0 ( HSEM Interrupt enable register ) 
HSEM $114 + constant HSEM-C2ICR ( HSEM Interrupt clear register ) 
HSEM $118 + constant HSEM-C2ISR ( HSEM Interrupt status register ) 
HSEM $11C + constant HSEM-C2MISR ( HSEM Masked interrupt status register ) 
: HSEM-R0. ." HSEM-R0 (read-write) $" HSEM-R0 @ hex. HSEM-R0 1b. ;
: HSEM-R1. ." HSEM-R1 (read-write) $" HSEM-R1 @ hex. HSEM-R1 1b. ;
: HSEM-R2. ." HSEM-R2 (read-write) $" HSEM-R2 @ hex. HSEM-R2 1b. ;
: HSEM-R3. ." HSEM-R3 (read-write) $" HSEM-R3 @ hex. HSEM-R3 1b. ;
: HSEM-R4. ." HSEM-R4 (read-write) $" HSEM-R4 @ hex. HSEM-R4 1b. ;
: HSEM-R5. ." HSEM-R5 (read-write) $" HSEM-R5 @ hex. HSEM-R5 1b. ;
: HSEM-R6. ." HSEM-R6 (read-write) $" HSEM-R6 @ hex. HSEM-R6 1b. ;
: HSEM-R7. ." HSEM-R7 (read-write) $" HSEM-R7 @ hex. HSEM-R7 1b. ;
: HSEM-R8. ." HSEM-R8 (read-write) $" HSEM-R8 @ hex. HSEM-R8 1b. ;
: HSEM-R9. ." HSEM-R9 (read-write) $" HSEM-R9 @ hex. HSEM-R9 1b. ;
: HSEM-R10. ." HSEM-R10 (read-write) $" HSEM-R10 @ hex. HSEM-R10 1b. ;
: HSEM-R11. ." HSEM-R11 (read-write) $" HSEM-R11 @ hex. HSEM-R11 1b. ;
: HSEM-R12. ." HSEM-R12 (read-write) $" HSEM-R12 @ hex. HSEM-R12 1b. ;
: HSEM-R13. ." HSEM-R13 (read-write) $" HSEM-R13 @ hex. HSEM-R13 1b. ;
: HSEM-R14. ." HSEM-R14 (read-write) $" HSEM-R14 @ hex. HSEM-R14 1b. ;
: HSEM-R15. ." HSEM-R15 (read-write) $" HSEM-R15 @ hex. HSEM-R15 1b. ;
: HSEM-R16. ." HSEM-R16 (read-write) $" HSEM-R16 @ hex. HSEM-R16 1b. ;
: HSEM-R17. ." HSEM-R17 (read-write) $" HSEM-R17 @ hex. HSEM-R17 1b. ;
: HSEM-R18. ." HSEM-R18 (read-write) $" HSEM-R18 @ hex. HSEM-R18 1b. ;
: HSEM-R19. ." HSEM-R19 (read-write) $" HSEM-R19 @ hex. HSEM-R19 1b. ;
: HSEM-R20. ." HSEM-R20 (read-write) $" HSEM-R20 @ hex. HSEM-R20 1b. ;
: HSEM-R21. ." HSEM-R21 (read-write) $" HSEM-R21 @ hex. HSEM-R21 1b. ;
: HSEM-R22. ." HSEM-R22 (read-write) $" HSEM-R22 @ hex. HSEM-R22 1b. ;
: HSEM-R23. ." HSEM-R23 (read-write) $" HSEM-R23 @ hex. HSEM-R23 1b. ;
: HSEM-R24. ." HSEM-R24 (read-write) $" HSEM-R24 @ hex. HSEM-R24 1b. ;
: HSEM-R25. ." HSEM-R25 (read-write) $" HSEM-R25 @ hex. HSEM-R25 1b. ;
: HSEM-R26. ." HSEM-R26 (read-write) $" HSEM-R26 @ hex. HSEM-R26 1b. ;
: HSEM-R27. ." HSEM-R27 (read-write) $" HSEM-R27 @ hex. HSEM-R27 1b. ;
: HSEM-R28. ." HSEM-R28 (read-write) $" HSEM-R28 @ hex. HSEM-R28 1b. ;
: HSEM-R29. ." HSEM-R29 (read-write) $" HSEM-R29 @ hex. HSEM-R29 1b. ;
: HSEM-R30. ." HSEM-R30 (read-write) $" HSEM-R30 @ hex. HSEM-R30 1b. ;
: HSEM-R31. ." HSEM-R31 (read-write) $" HSEM-R31 @ hex. HSEM-R31 1b. ;
: HSEM-RLR0. ." HSEM-RLR0 (read-only) $" HSEM-RLR0 @ hex. HSEM-RLR0 1b. ;
: HSEM-RLR1. ." HSEM-RLR1 (read-only) $" HSEM-RLR1 @ hex. HSEM-RLR1 1b. ;
: HSEM-RLR2. ." HSEM-RLR2 (read-only) $" HSEM-RLR2 @ hex. HSEM-RLR2 1b. ;
: HSEM-RLR3. ." HSEM-RLR3 (read-only) $" HSEM-RLR3 @ hex. HSEM-RLR3 1b. ;
: HSEM-RLR4. ." HSEM-RLR4 (read-only) $" HSEM-RLR4 @ hex. HSEM-RLR4 1b. ;
: HSEM-RLR5. ." HSEM-RLR5 (read-only) $" HSEM-RLR5 @ hex. HSEM-RLR5 1b. ;
: HSEM-RLR6. ." HSEM-RLR6 (read-only) $" HSEM-RLR6 @ hex. HSEM-RLR6 1b. ;
: HSEM-RLR7. ." HSEM-RLR7 (read-only) $" HSEM-RLR7 @ hex. HSEM-RLR7 1b. ;
: HSEM-RLR8. ." HSEM-RLR8 (read-only) $" HSEM-RLR8 @ hex. HSEM-RLR8 1b. ;
: HSEM-RLR9. ." HSEM-RLR9 (read-only) $" HSEM-RLR9 @ hex. HSEM-RLR9 1b. ;
: HSEM-RLR10. ." HSEM-RLR10 (read-only) $" HSEM-RLR10 @ hex. HSEM-RLR10 1b. ;
: HSEM-RLR11. ." HSEM-RLR11 (read-only) $" HSEM-RLR11 @ hex. HSEM-RLR11 1b. ;
: HSEM-RLR12. ." HSEM-RLR12 (read-only) $" HSEM-RLR12 @ hex. HSEM-RLR12 1b. ;
: HSEM-RLR13. ." HSEM-RLR13 (read-only) $" HSEM-RLR13 @ hex. HSEM-RLR13 1b. ;
: HSEM-RLR14. ." HSEM-RLR14 (read-only) $" HSEM-RLR14 @ hex. HSEM-RLR14 1b. ;
: HSEM-RLR15. ." HSEM-RLR15 (read-only) $" HSEM-RLR15 @ hex. HSEM-RLR15 1b. ;
: HSEM-RLR16. ." HSEM-RLR16 (read-only) $" HSEM-RLR16 @ hex. HSEM-RLR16 1b. ;
: HSEM-RLR17. ." HSEM-RLR17 (read-only) $" HSEM-RLR17 @ hex. HSEM-RLR17 1b. ;
: HSEM-RLR18. ." HSEM-RLR18 (read-only) $" HSEM-RLR18 @ hex. HSEM-RLR18 1b. ;
: HSEM-RLR19. ." HSEM-RLR19 (read-only) $" HSEM-RLR19 @ hex. HSEM-RLR19 1b. ;
: HSEM-RLR20. ." HSEM-RLR20 (read-only) $" HSEM-RLR20 @ hex. HSEM-RLR20 1b. ;
: HSEM-RLR21. ." HSEM-RLR21 (read-only) $" HSEM-RLR21 @ hex. HSEM-RLR21 1b. ;
: HSEM-RLR22. ." HSEM-RLR22 (read-only) $" HSEM-RLR22 @ hex. HSEM-RLR22 1b. ;
: HSEM-RLR23. ." HSEM-RLR23 (read-only) $" HSEM-RLR23 @ hex. HSEM-RLR23 1b. ;
: HSEM-RLR24. ." HSEM-RLR24 (read-only) $" HSEM-RLR24 @ hex. HSEM-RLR24 1b. ;
: HSEM-RLR25. ." HSEM-RLR25 (read-only) $" HSEM-RLR25 @ hex. HSEM-RLR25 1b. ;
: HSEM-RLR26. ." HSEM-RLR26 (read-only) $" HSEM-RLR26 @ hex. HSEM-RLR26 1b. ;
: HSEM-RLR27. ." HSEM-RLR27 (read-only) $" HSEM-RLR27 @ hex. HSEM-RLR27 1b. ;
: HSEM-RLR28. ." HSEM-RLR28 (read-only) $" HSEM-RLR28 @ hex. HSEM-RLR28 1b. ;
: HSEM-RLR29. ." HSEM-RLR29 (read-only) $" HSEM-RLR29 @ hex. HSEM-RLR29 1b. ;
: HSEM-RLR30. ." HSEM-RLR30 (read-only) $" HSEM-RLR30 @ hex. HSEM-RLR30 1b. ;
: HSEM-RLR31. ." HSEM-RLR31 (read-only) $" HSEM-RLR31 @ hex. HSEM-RLR31 1b. ;
: HSEM-CR. ." HSEM-CR (read-write) $" HSEM-CR @ hex. HSEM-CR 1b. ;
: HSEM-KEYR. ." HSEM-KEYR (read-write) $" HSEM-KEYR @ hex. HSEM-KEYR 1b. ;
: HSEM-HWCFGR2. ." HSEM-HWCFGR2 (read-only) $" HSEM-HWCFGR2 @ hex. HSEM-HWCFGR2 1b. ;
: HSEM-HWCFGR1. ." HSEM-HWCFGR1 (read-only) $" HSEM-HWCFGR1 @ hex. HSEM-HWCFGR1 1b. ;
: HSEM-VERR. ." HSEM-VERR (read-only) $" HSEM-VERR @ hex. HSEM-VERR 1b. ;
: HSEM-IPIDR. ." HSEM-IPIDR (read-only) $" HSEM-IPIDR @ hex. HSEM-IPIDR 1b. ;
: HSEM-SIDR. ." HSEM-SIDR (read-only) $" HSEM-SIDR @ hex. HSEM-SIDR 1b. ;
: HSEM-C1IER0. ." HSEM-C1IER0 (read-write) $" HSEM-C1IER0 @ hex. HSEM-C1IER0 1b. ;
: HSEM-C1ICR. ." HSEM-C1ICR (read-write) $" HSEM-C1ICR @ hex. HSEM-C1ICR 1b. ;
: HSEM-C1ISR. ." HSEM-C1ISR (read-only) $" HSEM-C1ISR @ hex. HSEM-C1ISR 1b. ;
: HSEM-C1MISR. ." HSEM-C1MISR (read-only) $" HSEM-C1MISR @ hex. HSEM-C1MISR 1b. ;
: HSEM-C2IER0. ." HSEM-C2IER0 (read-write) $" HSEM-C2IER0 @ hex. HSEM-C2IER0 1b. ;
: HSEM-C2ICR. ." HSEM-C2ICR (read-write) $" HSEM-C2ICR @ hex. HSEM-C2ICR 1b. ;
: HSEM-C2ISR. ." HSEM-C2ISR (read-only) $" HSEM-C2ISR @ hex. HSEM-C2ISR 1b. ;
: HSEM-C2MISR. ." HSEM-C2MISR (read-only) $" HSEM-C2MISR @ hex. HSEM-C2MISR 1b. ;
: HSEM.
HSEM-R0.
HSEM-R1.
HSEM-R2.
HSEM-R3.
HSEM-R4.
HSEM-R5.
HSEM-R6.
HSEM-R7.
HSEM-R8.
HSEM-R9.
HSEM-R10.
HSEM-R11.
HSEM-R12.
HSEM-R13.
HSEM-R14.
HSEM-R15.
HSEM-R16.
HSEM-R17.
HSEM-R18.
HSEM-R19.
HSEM-R20.
HSEM-R21.
HSEM-R22.
HSEM-R23.
HSEM-R24.
HSEM-R25.
HSEM-R26.
HSEM-R27.
HSEM-R28.
HSEM-R29.
HSEM-R30.
HSEM-R31.
HSEM-RLR0.
HSEM-RLR1.
HSEM-RLR2.
HSEM-RLR3.
HSEM-RLR4.
HSEM-RLR5.
HSEM-RLR6.
HSEM-RLR7.
HSEM-RLR8.
HSEM-RLR9.
HSEM-RLR10.
HSEM-RLR11.
HSEM-RLR12.
HSEM-RLR13.
HSEM-RLR14.
HSEM-RLR15.
HSEM-RLR16.
HSEM-RLR17.
HSEM-RLR18.
HSEM-RLR19.
HSEM-RLR20.
HSEM-RLR21.
HSEM-RLR22.
HSEM-RLR23.
HSEM-RLR24.
HSEM-RLR25.
HSEM-RLR26.
HSEM-RLR27.
HSEM-RLR28.
HSEM-RLR29.
HSEM-RLR30.
HSEM-RLR31.
HSEM-CR.
HSEM-KEYR.
HSEM-HWCFGR2.
HSEM-HWCFGR1.
HSEM-VERR.
HSEM-IPIDR.
HSEM-SIDR.
HSEM-C1IER0.
HSEM-C1ICR.
HSEM-C1ISR.
HSEM-C1MISR.
HSEM-C2IER0.
HSEM-C2ICR.
HSEM-C2ISR.
HSEM-C2MISR.
;

$50040000 constant ADC ( Analog to Digital Converter instance 1 ) 
ADC $0 + constant ADC-ISR ( ADC interrupt and status register ) 
ADC $4 + constant ADC-IER ( ADC interrupt enable register ) 
ADC $8 + constant ADC-CR ( ADC control register ) 
ADC $C + constant ADC-CFGR ( ADC configuration register 1 ) 
ADC $10 + constant ADC-CFGR2 ( ADC configuration register 2 ) 
ADC $14 + constant ADC-SMPR1 ( ADC sampling time register 1 ) 
ADC $18 + constant ADC-SMPR2 ( ADC sampling time register 2 ) 
ADC $20 + constant ADC-TR1 ( ADC analog watchdog 1 threshold register ) 
ADC $24 + constant ADC-TR2 ( ADC analog watchdog 2 threshold register ) 
ADC $28 + constant ADC-TR3 ( ADC analog watchdog 3 threshold register ) 
ADC $30 + constant ADC-SQR1 ( ADC group regular sequencer ranks register 1 ) 
ADC $34 + constant ADC-SQR2 ( ADC group regular sequencer ranks register 2 ) 
ADC $38 + constant ADC-SQR3 ( ADC group regular sequencer ranks register 3 ) 
ADC $3C + constant ADC-SQR4 ( ADC group regular sequencer ranks register 4 ) 
ADC $40 + constant ADC-DR ( ADC group regular conversion data register ) 
ADC $4C + constant ADC-JSQR ( ADC group injected sequencer register ) 
ADC $60 + constant ADC-OFR1 ( ADC offset number 1 register ) 
ADC $64 + constant ADC-OFR2 ( ADC offset number 2 register ) 
ADC $68 + constant ADC-OFR3 ( ADC offset number 3 register ) 
ADC $6C + constant ADC-OFR4 ( ADC offset number 4 register ) 
ADC $80 + constant ADC-JDR1 ( ADC group injected sequencer rank 1 register ) 
ADC $84 + constant ADC-JDR2 ( ADC group injected sequencer rank 2 register ) 
ADC $88 + constant ADC-JDR3 ( ADC group injected sequencer rank 3 register ) 
ADC $8C + constant ADC-JDR4 ( ADC group injected sequencer rank 4 register ) 
ADC $A0 + constant ADC-AWD2CR ( ADC analog watchdog 2 configuration register ) 
ADC $A4 + constant ADC-AWD3CR ( ADC analog watchdog 3 configuration register ) 
ADC $B0 + constant ADC-DIFSEL ( ADC channel differential or single-ended mode selection register ) 
ADC $B4 + constant ADC-CALFACT ( ADC calibration factors register ) 
ADC $308 + constant ADC-CCR ( ADC common control register ) 
: ADC-ISR. ." ADC-ISR (read-write) $" ADC-ISR @ hex. ADC-ISR 1b. ;
: ADC-IER. ." ADC-IER (read-write) $" ADC-IER @ hex. ADC-IER 1b. ;
: ADC-CR. ." ADC-CR (read-write) $" ADC-CR @ hex. ADC-CR 1b. ;
: ADC-CFGR. ." ADC-CFGR (read-write) $" ADC-CFGR @ hex. ADC-CFGR 1b. ;
: ADC-CFGR2. ." ADC-CFGR2 (read-write) $" ADC-CFGR2 @ hex. ADC-CFGR2 1b. ;
: ADC-SMPR1. ." ADC-SMPR1 (read-write) $" ADC-SMPR1 @ hex. ADC-SMPR1 1b. ;
: ADC-SMPR2. ." ADC-SMPR2 (read-write) $" ADC-SMPR2 @ hex. ADC-SMPR2 1b. ;
: ADC-TR1. ." ADC-TR1 (read-write) $" ADC-TR1 @ hex. ADC-TR1 1b. ;
: ADC-TR2. ." ADC-TR2 (read-write) $" ADC-TR2 @ hex. ADC-TR2 1b. ;
: ADC-TR3. ." ADC-TR3 (read-write) $" ADC-TR3 @ hex. ADC-TR3 1b. ;
: ADC-SQR1. ." ADC-SQR1 (read-write) $" ADC-SQR1 @ hex. ADC-SQR1 1b. ;
: ADC-SQR2. ." ADC-SQR2 (read-write) $" ADC-SQR2 @ hex. ADC-SQR2 1b. ;
: ADC-SQR3. ." ADC-SQR3 (read-write) $" ADC-SQR3 @ hex. ADC-SQR3 1b. ;
: ADC-SQR4. ." ADC-SQR4 (read-write) $" ADC-SQR4 @ hex. ADC-SQR4 1b. ;
: ADC-DR. ." ADC-DR () $" ADC-DR @ hex. ADC-DR 1b. ;
: ADC-JSQR. ." ADC-JSQR (read-write) $" ADC-JSQR @ hex. ADC-JSQR 1b. ;
: ADC-OFR1. ." ADC-OFR1 (read-write) $" ADC-OFR1 @ hex. ADC-OFR1 1b. ;
: ADC-OFR2. ." ADC-OFR2 (read-write) $" ADC-OFR2 @ hex. ADC-OFR2 1b. ;
: ADC-OFR3. ." ADC-OFR3 (read-write) $" ADC-OFR3 @ hex. ADC-OFR3 1b. ;
: ADC-OFR4. ." ADC-OFR4 (read-write) $" ADC-OFR4 @ hex. ADC-OFR4 1b. ;
: ADC-JDR1. ." ADC-JDR1 (read-only) $" ADC-JDR1 @ hex. ADC-JDR1 1b. ;
: ADC-JDR2. ." ADC-JDR2 (read-only) $" ADC-JDR2 @ hex. ADC-JDR2 1b. ;
: ADC-JDR3. ." ADC-JDR3 (read-only) $" ADC-JDR3 @ hex. ADC-JDR3 1b. ;
: ADC-JDR4. ." ADC-JDR4 (read-only) $" ADC-JDR4 @ hex. ADC-JDR4 1b. ;
: ADC-AWD2CR. ." ADC-AWD2CR (read-write) $" ADC-AWD2CR @ hex. ADC-AWD2CR 1b. ;
: ADC-AWD3CR. ." ADC-AWD3CR (read-write) $" ADC-AWD3CR @ hex. ADC-AWD3CR 1b. ;
: ADC-DIFSEL. ." ADC-DIFSEL () $" ADC-DIFSEL @ hex. ADC-DIFSEL 1b. ;
: ADC-CALFACT. ." ADC-CALFACT (read-write) $" ADC-CALFACT @ hex. ADC-CALFACT 1b. ;
: ADC-CCR. ." ADC-CCR (read-write) $" ADC-CCR @ hex. ADC-CCR 1b. ;
: ADC.
ADC-ISR.
ADC-IER.
ADC-CR.
ADC-CFGR.
ADC-CFGR2.
ADC-SMPR1.
ADC-SMPR2.
ADC-TR1.
ADC-TR2.
ADC-TR3.
ADC-SQR1.
ADC-SQR2.
ADC-SQR3.
ADC-SQR4.
ADC-DR.
ADC-JSQR.
ADC-OFR1.
ADC-OFR2.
ADC-OFR3.
ADC-OFR4.
ADC-JDR1.
ADC-JDR2.
ADC-JDR3.
ADC-JDR4.
ADC-AWD2CR.
ADC-AWD3CR.
ADC-DIFSEL.
ADC-CALFACT.
ADC-CCR.
;

$48000000 constant GPIOA ( General-purpose I/Os ) 
GPIOA $0 + constant GPIOA-MODER ( GPIO port mode register ) 
GPIOA $4 + constant GPIOA-OTYPER ( GPIO port output type register ) 
GPIOA $8 + constant GPIOA-OSPEEDR ( GPIO port output speed register ) 
GPIOA $C + constant GPIOA-PUPDR ( GPIO port pull-up/pull-down register ) 
GPIOA $10 + constant GPIOA-IDR ( GPIO port input data register ) 
GPIOA $14 + constant GPIOA-ODR ( GPIO port output data register ) 
GPIOA $18 + constant GPIOA-BSRR ( GPIO port bit set/reset register ) 
GPIOA $1C + constant GPIOA-LCKR ( GPIO port configuration lock register ) 
GPIOA $20 + constant GPIOA-AFRL ( GPIO alternate function low register ) 
GPIOA $24 + constant GPIOA-AFRH ( GPIO alternate function high register ) 
GPIOA $28 + constant GPIOA-BRR ( port bit reset register ) 
: GPIOA-MODER. ." GPIOA-MODER (read-write) $" GPIOA-MODER @ hex. GPIOA-MODER 1b. ;
: GPIOA-OTYPER. ." GPIOA-OTYPER (read-write) $" GPIOA-OTYPER @ hex. GPIOA-OTYPER 1b. ;
: GPIOA-OSPEEDR. ." GPIOA-OSPEEDR (read-write) $" GPIOA-OSPEEDR @ hex. GPIOA-OSPEEDR 1b. ;
: GPIOA-PUPDR. ." GPIOA-PUPDR (read-write) $" GPIOA-PUPDR @ hex. GPIOA-PUPDR 1b. ;
: GPIOA-IDR. ." GPIOA-IDR (read-only) $" GPIOA-IDR @ hex. GPIOA-IDR 1b. ;
: GPIOA-ODR. ." GPIOA-ODR (read-write) $" GPIOA-ODR @ hex. GPIOA-ODR 1b. ;
: GPIOA-BSRR. ." GPIOA-BSRR (write-only) $" GPIOA-BSRR @ hex. GPIOA-BSRR 1b. ;
: GPIOA-LCKR. ." GPIOA-LCKR (read-write) $" GPIOA-LCKR @ hex. GPIOA-LCKR 1b. ;
: GPIOA-AFRL. ." GPIOA-AFRL (read-write) $" GPIOA-AFRL @ hex. GPIOA-AFRL 1b. ;
: GPIOA-AFRH. ." GPIOA-AFRH (read-write) $" GPIOA-AFRH @ hex. GPIOA-AFRH 1b. ;
: GPIOA-BRR. ." GPIOA-BRR (write-only) $" GPIOA-BRR @ hex. GPIOA-BRR 1b. ;
: GPIOA.
GPIOA-MODER.
GPIOA-OTYPER.
GPIOA-OSPEEDR.
GPIOA-PUPDR.
GPIOA-IDR.
GPIOA-ODR.
GPIOA-BSRR.
GPIOA-LCKR.
GPIOA-AFRL.
GPIOA-AFRH.
GPIOA-BRR.
;

$48000400 constant GPIOB ( General-purpose I/Os ) 
GPIOB $0 + constant GPIOB-MODER ( GPIO port mode register ) 
GPIOB $4 + constant GPIOB-OTYPER ( GPIO port output type register ) 
GPIOB $8 + constant GPIOB-OSPEEDR ( GPIO port output speed register ) 
GPIOB $C + constant GPIOB-PUPDR ( GPIO port pull-up/pull-down register ) 
GPIOB $10 + constant GPIOB-IDR ( GPIO port input data register ) 
GPIOB $14 + constant GPIOB-ODR ( GPIO port output data register ) 
GPIOB $18 + constant GPIOB-BSRR ( GPIO port bit set/reset register ) 
GPIOB $1C + constant GPIOB-LCKR ( GPIO port configuration lock register ) 
GPIOB $20 + constant GPIOB-AFRL ( GPIO alternate function low register ) 
GPIOB $24 + constant GPIOB-AFRH ( GPIO alternate function high register ) 
GPIOB $28 + constant GPIOB-BRR ( port bit reset register ) 
: GPIOB-MODER. ." GPIOB-MODER (read-write) $" GPIOB-MODER @ hex. GPIOB-MODER 1b. ;
: GPIOB-OTYPER. ." GPIOB-OTYPER (read-write) $" GPIOB-OTYPER @ hex. GPIOB-OTYPER 1b. ;
: GPIOB-OSPEEDR. ." GPIOB-OSPEEDR (read-write) $" GPIOB-OSPEEDR @ hex. GPIOB-OSPEEDR 1b. ;
: GPIOB-PUPDR. ." GPIOB-PUPDR (read-write) $" GPIOB-PUPDR @ hex. GPIOB-PUPDR 1b. ;
: GPIOB-IDR. ." GPIOB-IDR (read-only) $" GPIOB-IDR @ hex. GPIOB-IDR 1b. ;
: GPIOB-ODR. ." GPIOB-ODR (read-write) $" GPIOB-ODR @ hex. GPIOB-ODR 1b. ;
: GPIOB-BSRR. ." GPIOB-BSRR (write-only) $" GPIOB-BSRR @ hex. GPIOB-BSRR 1b. ;
: GPIOB-LCKR. ." GPIOB-LCKR (read-write) $" GPIOB-LCKR @ hex. GPIOB-LCKR 1b. ;
: GPIOB-AFRL. ." GPIOB-AFRL (read-write) $" GPIOB-AFRL @ hex. GPIOB-AFRL 1b. ;
: GPIOB-AFRH. ." GPIOB-AFRH (read-write) $" GPIOB-AFRH @ hex. GPIOB-AFRH 1b. ;
: GPIOB-BRR. ." GPIOB-BRR (write-only) $" GPIOB-BRR @ hex. GPIOB-BRR 1b. ;
: GPIOB.
GPIOB-MODER.
GPIOB-OTYPER.
GPIOB-OSPEEDR.
GPIOB-PUPDR.
GPIOB-IDR.
GPIOB-ODR.
GPIOB-BSRR.
GPIOB-LCKR.
GPIOB-AFRL.
GPIOB-AFRH.
GPIOB-BRR.
;

$48000800 constant GPIOC ( General-purpose I/Os ) 
GPIOC $0 + constant GPIOC-MODER ( GPIO port mode register ) 
GPIOC $4 + constant GPIOC-OTYPER ( GPIO port output type register ) 
GPIOC $8 + constant GPIOC-OSPEEDR ( GPIO port output speed register ) 
GPIOC $C + constant GPIOC-PUPDR ( GPIO port pull-up/pull-down register ) 
GPIOC $10 + constant GPIOC-IDR ( GPIO port input data register ) 
GPIOC $14 + constant GPIOC-ODR ( GPIO port output data register ) 
GPIOC $18 + constant GPIOC-BSRR ( GPIO port bit set/reset register ) 
GPIOC $1C + constant GPIOC-LCKR ( GPIO port configuration lock register ) 
GPIOC $20 + constant GPIOC-AFRL ( GPIO alternate function low register ) 
GPIOC $24 + constant GPIOC-AFRH ( GPIO alternate function high register ) 
GPIOC $28 + constant GPIOC-BRR ( port bit reset register ) 
: GPIOC-MODER. ." GPIOC-MODER (read-write) $" GPIOC-MODER @ hex. GPIOC-MODER 1b. ;
: GPIOC-OTYPER. ." GPIOC-OTYPER (read-write) $" GPIOC-OTYPER @ hex. GPIOC-OTYPER 1b. ;
: GPIOC-OSPEEDR. ." GPIOC-OSPEEDR (read-write) $" GPIOC-OSPEEDR @ hex. GPIOC-OSPEEDR 1b. ;
: GPIOC-PUPDR. ." GPIOC-PUPDR (read-write) $" GPIOC-PUPDR @ hex. GPIOC-PUPDR 1b. ;
: GPIOC-IDR. ." GPIOC-IDR (read-only) $" GPIOC-IDR @ hex. GPIOC-IDR 1b. ;
: GPIOC-ODR. ." GPIOC-ODR (read-write) $" GPIOC-ODR @ hex. GPIOC-ODR 1b. ;
: GPIOC-BSRR. ." GPIOC-BSRR (write-only) $" GPIOC-BSRR @ hex. GPIOC-BSRR 1b. ;
: GPIOC-LCKR. ." GPIOC-LCKR (read-write) $" GPIOC-LCKR @ hex. GPIOC-LCKR 1b. ;
: GPIOC-AFRL. ." GPIOC-AFRL (read-write) $" GPIOC-AFRL @ hex. GPIOC-AFRL 1b. ;
: GPIOC-AFRH. ." GPIOC-AFRH (read-write) $" GPIOC-AFRH @ hex. GPIOC-AFRH 1b. ;
: GPIOC-BRR. ." GPIOC-BRR (write-only) $" GPIOC-BRR @ hex. GPIOC-BRR 1b. ;
: GPIOC.
GPIOC-MODER.
GPIOC-OTYPER.
GPIOC-OSPEEDR.
GPIOC-PUPDR.
GPIOC-IDR.
GPIOC-ODR.
GPIOC-BSRR.
GPIOC-LCKR.
GPIOC-AFRL.
GPIOC-AFRH.
GPIOC-BRR.
;

$48000C00 constant GPIOD ( General-purpose I/Os ) 
GPIOD $0 + constant GPIOD-MODER ( GPIO port mode register ) 
GPIOD $4 + constant GPIOD-OTYPER ( GPIO port output type register ) 
GPIOD $8 + constant GPIOD-OSPEEDR ( GPIO port output speed register ) 
GPIOD $C + constant GPIOD-PUPDR ( GPIO port pull-up/pull-down register ) 
GPIOD $10 + constant GPIOD-IDR ( GPIO port input data register ) 
GPIOD $14 + constant GPIOD-ODR ( GPIO port output data register ) 
GPIOD $18 + constant GPIOD-BSRR ( GPIO port bit set/reset register ) 
GPIOD $1C + constant GPIOD-LCKR ( GPIO port configuration lock register ) 
GPIOD $20 + constant GPIOD-AFRL ( GPIO alternate function low register ) 
GPIOD $24 + constant GPIOD-AFRH ( GPIO alternate function high register ) 
GPIOD $28 + constant GPIOD-BRR ( port bit reset register ) 
: GPIOD-MODER. ." GPIOD-MODER (read-write) $" GPIOD-MODER @ hex. GPIOD-MODER 1b. ;
: GPIOD-OTYPER. ." GPIOD-OTYPER (read-write) $" GPIOD-OTYPER @ hex. GPIOD-OTYPER 1b. ;
: GPIOD-OSPEEDR. ." GPIOD-OSPEEDR (read-write) $" GPIOD-OSPEEDR @ hex. GPIOD-OSPEEDR 1b. ;
: GPIOD-PUPDR. ." GPIOD-PUPDR (read-write) $" GPIOD-PUPDR @ hex. GPIOD-PUPDR 1b. ;
: GPIOD-IDR. ." GPIOD-IDR (read-only) $" GPIOD-IDR @ hex. GPIOD-IDR 1b. ;
: GPIOD-ODR. ." GPIOD-ODR (read-write) $" GPIOD-ODR @ hex. GPIOD-ODR 1b. ;
: GPIOD-BSRR. ." GPIOD-BSRR (write-only) $" GPIOD-BSRR @ hex. GPIOD-BSRR 1b. ;
: GPIOD-LCKR. ." GPIOD-LCKR (read-write) $" GPIOD-LCKR @ hex. GPIOD-LCKR 1b. ;
: GPIOD-AFRL. ." GPIOD-AFRL (read-write) $" GPIOD-AFRL @ hex. GPIOD-AFRL 1b. ;
: GPIOD-AFRH. ." GPIOD-AFRH (read-write) $" GPIOD-AFRH @ hex. GPIOD-AFRH 1b. ;
: GPIOD-BRR. ." GPIOD-BRR (write-only) $" GPIOD-BRR @ hex. GPIOD-BRR 1b. ;
: GPIOD.
GPIOD-MODER.
GPIOD-OTYPER.
GPIOD-OSPEEDR.
GPIOD-PUPDR.
GPIOD-IDR.
GPIOD-ODR.
GPIOD-BSRR.
GPIOD-LCKR.
GPIOD-AFRL.
GPIOD-AFRH.
GPIOD-BRR.
;

$48001000 constant GPIOE ( General-purpose I/Os ) 
GPIOE $0 + constant GPIOE-MODER ( GPIO port mode register ) 
GPIOE $4 + constant GPIOE-OTYPER ( GPIO port output type register ) 
GPIOE $8 + constant GPIOE-OSPEEDR ( GPIO port output speed register ) 
GPIOE $C + constant GPIOE-PUPDR ( GPIO port pull-up/pull-down register ) 
GPIOE $10 + constant GPIOE-IDR ( GPIO port input data register ) 
GPIOE $14 + constant GPIOE-ODR ( GPIO port output data register ) 
GPIOE $18 + constant GPIOE-BSRR ( GPIO port bit set/reset register ) 
GPIOE $1C + constant GPIOE-LCKR ( GPIO port configuration lock register ) 
GPIOE $20 + constant GPIOE-AFRL ( GPIO alternate function low register ) 
GPIOE $24 + constant GPIOE-AFRH ( GPIO alternate function high register ) 
GPIOE $28 + constant GPIOE-BRR ( port bit reset register ) 
: GPIOE-MODER. ." GPIOE-MODER (read-write) $" GPIOE-MODER @ hex. GPIOE-MODER 1b. ;
: GPIOE-OTYPER. ." GPIOE-OTYPER (read-write) $" GPIOE-OTYPER @ hex. GPIOE-OTYPER 1b. ;
: GPIOE-OSPEEDR. ." GPIOE-OSPEEDR (read-write) $" GPIOE-OSPEEDR @ hex. GPIOE-OSPEEDR 1b. ;
: GPIOE-PUPDR. ." GPIOE-PUPDR (read-write) $" GPIOE-PUPDR @ hex. GPIOE-PUPDR 1b. ;
: GPIOE-IDR. ." GPIOE-IDR (read-only) $" GPIOE-IDR @ hex. GPIOE-IDR 1b. ;
: GPIOE-ODR. ." GPIOE-ODR (read-write) $" GPIOE-ODR @ hex. GPIOE-ODR 1b. ;
: GPIOE-BSRR. ." GPIOE-BSRR (write-only) $" GPIOE-BSRR @ hex. GPIOE-BSRR 1b. ;
: GPIOE-LCKR. ." GPIOE-LCKR (read-write) $" GPIOE-LCKR @ hex. GPIOE-LCKR 1b. ;
: GPIOE-AFRL. ." GPIOE-AFRL (read-write) $" GPIOE-AFRL @ hex. GPIOE-AFRL 1b. ;
: GPIOE-AFRH. ." GPIOE-AFRH (read-write) $" GPIOE-AFRH @ hex. GPIOE-AFRH 1b. ;
: GPIOE-BRR. ." GPIOE-BRR (write-only) $" GPIOE-BRR @ hex. GPIOE-BRR 1b. ;
: GPIOE.
GPIOE-MODER.
GPIOE-OTYPER.
GPIOE-OSPEEDR.
GPIOE-PUPDR.
GPIOE-IDR.
GPIOE-ODR.
GPIOE-BSRR.
GPIOE-LCKR.
GPIOE-AFRL.
GPIOE-AFRH.
GPIOE-BRR.
;

$48001C00 constant GPIOH ( General-purpose I/Os ) 
GPIOH $0 + constant GPIOH-MODER ( GPIO port mode register ) 
GPIOH $4 + constant GPIOH-OTYPER ( GPIO port output type register ) 
GPIOH $8 + constant GPIOH-OSPEEDR ( GPIO port output speed register ) 
GPIOH $C + constant GPIOH-PUPDR ( GPIO port pull-up/pull-down register ) 
GPIOH $10 + constant GPIOH-IDR ( GPIO port input data register ) 
GPIOH $14 + constant GPIOH-ODR ( GPIO port output data register ) 
GPIOH $18 + constant GPIOH-BSRR ( GPIO port bit set/reset register ) 
GPIOH $1C + constant GPIOH-LCKR ( GPIO port configuration lock register ) 
GPIOH $20 + constant GPIOH-AFRL ( GPIO alternate function low register ) 
GPIOH $24 + constant GPIOH-AFRH ( GPIO alternate function high register ) 
GPIOH $28 + constant GPIOH-BRR ( port bit reset register ) 
: GPIOH-MODER. ." GPIOH-MODER (read-write) $" GPIOH-MODER @ hex. GPIOH-MODER 1b. ;
: GPIOH-OTYPER. ." GPIOH-OTYPER (read-write) $" GPIOH-OTYPER @ hex. GPIOH-OTYPER 1b. ;
: GPIOH-OSPEEDR. ." GPIOH-OSPEEDR (read-write) $" GPIOH-OSPEEDR @ hex. GPIOH-OSPEEDR 1b. ;
: GPIOH-PUPDR. ." GPIOH-PUPDR (read-write) $" GPIOH-PUPDR @ hex. GPIOH-PUPDR 1b. ;
: GPIOH-IDR. ." GPIOH-IDR (read-only) $" GPIOH-IDR @ hex. GPIOH-IDR 1b. ;
: GPIOH-ODR. ." GPIOH-ODR (read-write) $" GPIOH-ODR @ hex. GPIOH-ODR 1b. ;
: GPIOH-BSRR. ." GPIOH-BSRR (write-only) $" GPIOH-BSRR @ hex. GPIOH-BSRR 1b. ;
: GPIOH-LCKR. ." GPIOH-LCKR (read-write) $" GPIOH-LCKR @ hex. GPIOH-LCKR 1b. ;
: GPIOH-AFRL. ." GPIOH-AFRL (read-write) $" GPIOH-AFRL @ hex. GPIOH-AFRL 1b. ;
: GPIOH-AFRH. ." GPIOH-AFRH (read-write) $" GPIOH-AFRH @ hex. GPIOH-AFRH 1b. ;
: GPIOH-BRR. ." GPIOH-BRR (write-only) $" GPIOH-BRR @ hex. GPIOH-BRR 1b. ;
: GPIOH.
GPIOH-MODER.
GPIOH-OTYPER.
GPIOH-OSPEEDR.
GPIOH-PUPDR.
GPIOH-IDR.
GPIOH-ODR.
GPIOH-BSRR.
GPIOH-LCKR.
GPIOH-AFRL.
GPIOH-AFRH.
GPIOH-BRR.
;

$40015400 constant SAI1 ( Serial audio interface ) 
SAI1 $0 + constant SAI1-GCR ( Global configuration register ) 
SAI1 $24 + constant SAI1-BCR1 ( BConfiguration register 1 ) 
SAI1 $28 + constant SAI1-BCR2 ( BConfiguration register 2 ) 
SAI1 $2C + constant SAI1-BFRCR ( BFRCR ) 
SAI1 $30 + constant SAI1-BSLOTR ( BSlot register ) 
SAI1 $34 + constant SAI1-BIM ( BInterrupt mask register2 ) 
SAI1 $38 + constant SAI1-BSR ( BStatus register ) 
SAI1 $3C + constant SAI1-BCLRFR ( BClear flag register ) 
SAI1 $40 + constant SAI1-BDR ( BData register ) 
SAI1 $4 + constant SAI1-ACR1 ( AConfiguration register 1 ) 
SAI1 $8 + constant SAI1-ACR2 ( AConfiguration register 2 ) 
SAI1 $C + constant SAI1-AFRCR ( AFRCR ) 
SAI1 $10 + constant SAI1-ASLOTR ( ASlot register ) 
SAI1 $14 + constant SAI1-AIM ( AInterrupt mask register2 ) 
SAI1 $18 + constant SAI1-ASR ( AStatus register ) 
SAI1 $1C + constant SAI1-ACLRFR ( AClear flag register ) 
SAI1 $20 + constant SAI1-ADR ( AData register ) 
SAI1 $44 + constant SAI1-PDMCR ( PDM control register ) 
SAI1 $48 + constant SAI1-PDMDLY ( PDM delay register ) 
: SAI1-GCR. ." SAI1-GCR (read-write) $" SAI1-GCR @ hex. SAI1-GCR 1b. ;
: SAI1-BCR1. ." SAI1-BCR1 (read-write) $" SAI1-BCR1 @ hex. SAI1-BCR1 1b. ;
: SAI1-BCR2. ." SAI1-BCR2 (read-write) $" SAI1-BCR2 @ hex. SAI1-BCR2 1b. ;
: SAI1-BFRCR. ." SAI1-BFRCR (read-write) $" SAI1-BFRCR @ hex. SAI1-BFRCR 1b. ;
: SAI1-BSLOTR. ." SAI1-BSLOTR (read-write) $" SAI1-BSLOTR @ hex. SAI1-BSLOTR 1b. ;
: SAI1-BIM. ." SAI1-BIM (read-write) $" SAI1-BIM @ hex. SAI1-BIM 1b. ;
: SAI1-BSR. ." SAI1-BSR (read-only) $" SAI1-BSR @ hex. SAI1-BSR 1b. ;
: SAI1-BCLRFR. ." SAI1-BCLRFR (write-only) $" SAI1-BCLRFR @ hex. SAI1-BCLRFR 1b. ;
: SAI1-BDR. ." SAI1-BDR (read-write) $" SAI1-BDR @ hex. SAI1-BDR 1b. ;
: SAI1-ACR1. ." SAI1-ACR1 (read-write) $" SAI1-ACR1 @ hex. SAI1-ACR1 1b. ;
: SAI1-ACR2. ." SAI1-ACR2 (read-write) $" SAI1-ACR2 @ hex. SAI1-ACR2 1b. ;
: SAI1-AFRCR. ." SAI1-AFRCR (read-write) $" SAI1-AFRCR @ hex. SAI1-AFRCR 1b. ;
: SAI1-ASLOTR. ." SAI1-ASLOTR (read-write) $" SAI1-ASLOTR @ hex. SAI1-ASLOTR 1b. ;
: SAI1-AIM. ." SAI1-AIM (read-write) $" SAI1-AIM @ hex. SAI1-AIM 1b. ;
: SAI1-ASR. ." SAI1-ASR (read-only) $" SAI1-ASR @ hex. SAI1-ASR 1b. ;
: SAI1-ACLRFR. ." SAI1-ACLRFR (write-only) $" SAI1-ACLRFR @ hex. SAI1-ACLRFR 1b. ;
: SAI1-ADR. ." SAI1-ADR (read-write) $" SAI1-ADR @ hex. SAI1-ADR 1b. ;
: SAI1-PDMCR. ." SAI1-PDMCR (read-write) $" SAI1-PDMCR @ hex. SAI1-PDMCR 1b. ;
: SAI1-PDMDLY. ." SAI1-PDMDLY (read-write) $" SAI1-PDMDLY @ hex. SAI1-PDMDLY 1b. ;
: SAI1.
SAI1-GCR.
SAI1-BCR1.
SAI1-BCR2.
SAI1-BFRCR.
SAI1-BSLOTR.
SAI1-BIM.
SAI1-BSR.
SAI1-BCLRFR.
SAI1-BDR.
SAI1-ACR1.
SAI1-ACR2.
SAI1-AFRCR.
SAI1-ASLOTR.
SAI1-AIM.
SAI1-ASR.
SAI1-ACLRFR.
SAI1-ADR.
SAI1-PDMCR.
SAI1-PDMDLY.
;

$40000000 constant TIM2 ( General-purpose-timers ) 
TIM2 $0 + constant TIM2-CR1 ( control register 1 ) 
TIM2 $4 + constant TIM2-CR2 ( control register 2 ) 
TIM2 $8 + constant TIM2-SMCR ( slave mode control register ) 
TIM2 $C + constant TIM2-DIER ( DMA/Interrupt enable register ) 
TIM2 $10 + constant TIM2-SR ( status register ) 
TIM2 $14 + constant TIM2-EGR ( event generation register ) 
TIM2 $18 + constant TIM2-CCMR1_Output ( capture/compare mode register 1 output mode ) 
TIM2 $18 + constant TIM2-CCMR1_Input ( capture/compare mode register 1 input mode ) 
TIM2 $1C + constant TIM2-CCMR2_Output ( capture/compare mode register 2 output mode ) 
TIM2 $1C + constant TIM2-CCMR2_Input ( capture/compare mode register 2 input mode ) 
TIM2 $20 + constant TIM2-CCER ( capture/compare enable register ) 
TIM2 $24 + constant TIM2-CNT ( counter ) 
TIM2 $28 + constant TIM2-PSC ( prescaler ) 
TIM2 $2C + constant TIM2-ARR ( auto-reload register ) 
TIM2 $34 + constant TIM2-CCR1 ( capture/compare register 1 ) 
TIM2 $38 + constant TIM2-CCR2 ( capture/compare register 2 ) 
TIM2 $3C + constant TIM2-CCR3 ( capture/compare register 3 ) 
TIM2 $40 + constant TIM2-CCR4 ( capture/compare register 4 ) 
TIM2 $48 + constant TIM2-DCR ( DMA control register ) 
TIM2 $4C + constant TIM2-DMAR ( DMA address for full transfer ) 
TIM2 $50 + constant TIM2-OR ( TIM2 option register ) 
TIM2 $60 + constant TIM2-AF ( TIM2 alternate function option register 1 ) 
: TIM2-CR1. ." TIM2-CR1 (read-write) $" TIM2-CR1 @ hex. TIM2-CR1 1b. ;
: TIM2-CR2. ." TIM2-CR2 (read-write) $" TIM2-CR2 @ hex. TIM2-CR2 1b. ;
: TIM2-SMCR. ." TIM2-SMCR (read-write) $" TIM2-SMCR @ hex. TIM2-SMCR 1b. ;
: TIM2-DIER. ." TIM2-DIER (read-write) $" TIM2-DIER @ hex. TIM2-DIER 1b. ;
: TIM2-SR. ." TIM2-SR (read-write) $" TIM2-SR @ hex. TIM2-SR 1b. ;
: TIM2-EGR. ." TIM2-EGR (write-only) $" TIM2-EGR @ hex. TIM2-EGR 1b. ;
: TIM2-CCMR1_Output. ." TIM2-CCMR1_Output (read-write) $" TIM2-CCMR1_Output @ hex. TIM2-CCMR1_Output 1b. ;
: TIM2-CCMR1_Input. ." TIM2-CCMR1_Input (read-write) $" TIM2-CCMR1_Input @ hex. TIM2-CCMR1_Input 1b. ;
: TIM2-CCMR2_Output. ." TIM2-CCMR2_Output (read-write) $" TIM2-CCMR2_Output @ hex. TIM2-CCMR2_Output 1b. ;
: TIM2-CCMR2_Input. ." TIM2-CCMR2_Input (read-write) $" TIM2-CCMR2_Input @ hex. TIM2-CCMR2_Input 1b. ;
: TIM2-CCER. ." TIM2-CCER (read-write) $" TIM2-CCER @ hex. TIM2-CCER 1b. ;
: TIM2-CNT. ." TIM2-CNT () $" TIM2-CNT @ hex. TIM2-CNT 1b. ;
: TIM2-PSC. ." TIM2-PSC (read-write) $" TIM2-PSC @ hex. TIM2-PSC 1b. ;
: TIM2-ARR. ." TIM2-ARR (read-write) $" TIM2-ARR @ hex. TIM2-ARR 1b. ;
: TIM2-CCR1. ." TIM2-CCR1 (read-write) $" TIM2-CCR1 @ hex. TIM2-CCR1 1b. ;
: TIM2-CCR2. ." TIM2-CCR2 (read-write) $" TIM2-CCR2 @ hex. TIM2-CCR2 1b. ;
: TIM2-CCR3. ." TIM2-CCR3 (read-write) $" TIM2-CCR3 @ hex. TIM2-CCR3 1b. ;
: TIM2-CCR4. ." TIM2-CCR4 (read-write) $" TIM2-CCR4 @ hex. TIM2-CCR4 1b. ;
: TIM2-DCR. ." TIM2-DCR (read-write) $" TIM2-DCR @ hex. TIM2-DCR 1b. ;
: TIM2-DMAR. ." TIM2-DMAR (read-write) $" TIM2-DMAR @ hex. TIM2-DMAR 1b. ;
: TIM2-OR. ." TIM2-OR (read-write) $" TIM2-OR @ hex. TIM2-OR 1b. ;
: TIM2-AF. ." TIM2-AF (read-write) $" TIM2-AF @ hex. TIM2-AF 1b. ;
: TIM2.
TIM2-CR1.
TIM2-CR2.
TIM2-SMCR.
TIM2-DIER.
TIM2-SR.
TIM2-EGR.
TIM2-CCMR1_Output.
TIM2-CCMR1_Input.
TIM2-CCMR2_Output.
TIM2-CCMR2_Input.
TIM2-CCER.
TIM2-CNT.
TIM2-PSC.
TIM2-ARR.
TIM2-CCR1.
TIM2-CCR2.
TIM2-CCR3.
TIM2-CCR4.
TIM2-DCR.
TIM2-DMAR.
TIM2-OR.
TIM2-AF.
;

$40014400 constant TIM16 ( General purpose timers ) 
TIM16 $0 + constant TIM16-CR1 ( control register 1 ) 
TIM16 $4 + constant TIM16-CR2 ( control register 2 ) 
TIM16 $C + constant TIM16-DIER ( DMA/Interrupt enable register ) 
TIM16 $10 + constant TIM16-SR ( status register ) 
TIM16 $14 + constant TIM16-EGR ( event generation register ) 
TIM16 $18 + constant TIM16-CCMR1_Output ( capture/compare mode register output mode ) 
TIM16 $18 + constant TIM16-CCMR1_Input ( capture/compare mode register 1 input mode ) 
TIM16 $20 + constant TIM16-CCER ( capture/compare enable register ) 
TIM16 $24 + constant TIM16-CNT ( counter ) 
TIM16 $28 + constant TIM16-PSC ( prescaler ) 
TIM16 $2C + constant TIM16-ARR ( auto-reload register ) 
TIM16 $30 + constant TIM16-RCR ( repetition counter register ) 
TIM16 $34 + constant TIM16-CCR1 ( capture/compare register 1 ) 
TIM16 $44 + constant TIM16-BDTR ( break and dead-time register ) 
TIM16 $48 + constant TIM16-DCR ( DMA control register ) 
TIM16 $4C + constant TIM16-DMAR ( DMA address for full transfer ) 
TIM16 $50 + constant TIM16-OR ( TIM16 option register 1 ) 
TIM16 $60 + constant TIM16-AF1 ( TIM17 option register 1 ) 
: TIM16-CR1. ." TIM16-CR1 (read-write) $" TIM16-CR1 @ hex. TIM16-CR1 1b. ;
: TIM16-CR2. ." TIM16-CR2 (read-write) $" TIM16-CR2 @ hex. TIM16-CR2 1b. ;
: TIM16-DIER. ." TIM16-DIER (read-write) $" TIM16-DIER @ hex. TIM16-DIER 1b. ;
: TIM16-SR. ." TIM16-SR (read-write) $" TIM16-SR @ hex. TIM16-SR 1b. ;
: TIM16-EGR. ." TIM16-EGR (write-only) $" TIM16-EGR @ hex. TIM16-EGR 1b. ;
: TIM16-CCMR1_Output. ." TIM16-CCMR1_Output (read-write) $" TIM16-CCMR1_Output @ hex. TIM16-CCMR1_Output 1b. ;
: TIM16-CCMR1_Input. ." TIM16-CCMR1_Input (read-write) $" TIM16-CCMR1_Input @ hex. TIM16-CCMR1_Input 1b. ;
: TIM16-CCER. ." TIM16-CCER (read-write) $" TIM16-CCER @ hex. TIM16-CCER 1b. ;
: TIM16-CNT. ." TIM16-CNT () $" TIM16-CNT @ hex. TIM16-CNT 1b. ;
: TIM16-PSC. ." TIM16-PSC (read-write) $" TIM16-PSC @ hex. TIM16-PSC 1b. ;
: TIM16-ARR. ." TIM16-ARR (read-write) $" TIM16-ARR @ hex. TIM16-ARR 1b. ;
: TIM16-RCR. ." TIM16-RCR (read-write) $" TIM16-RCR @ hex. TIM16-RCR 1b. ;
: TIM16-CCR1. ." TIM16-CCR1 (read-write) $" TIM16-CCR1 @ hex. TIM16-CCR1 1b. ;
: TIM16-BDTR. ." TIM16-BDTR (read-write) $" TIM16-BDTR @ hex. TIM16-BDTR 1b. ;
: TIM16-DCR. ." TIM16-DCR (read-write) $" TIM16-DCR @ hex. TIM16-DCR 1b. ;
: TIM16-DMAR. ." TIM16-DMAR (read-write) $" TIM16-DMAR @ hex. TIM16-DMAR 1b. ;
: TIM16-OR. ." TIM16-OR (read-write) $" TIM16-OR @ hex. TIM16-OR 1b. ;
: TIM16-AF1. ." TIM16-AF1 (read-write) $" TIM16-AF1 @ hex. TIM16-AF1 1b. ;
: TIM16.
TIM16-CR1.
TIM16-CR2.
TIM16-DIER.
TIM16-SR.
TIM16-EGR.
TIM16-CCMR1_Output.
TIM16-CCMR1_Input.
TIM16-CCER.
TIM16-CNT.
TIM16-PSC.
TIM16-ARR.
TIM16-RCR.
TIM16-CCR1.
TIM16-BDTR.
TIM16-DCR.
TIM16-DMAR.
TIM16-OR.
TIM16-AF1.
;

$40014800 constant TIM17 ( General purpose timers ) 
TIM17 $0 + constant TIM17-CR1 ( control register 1 ) 
TIM17 $4 + constant TIM17-CR2 ( control register 2 ) 
TIM17 $8 + constant TIM17-DIER ( DMA/Interrupt enable register ) 
TIM17 $C + constant TIM17-SR ( status register ) 
TIM17 $10 + constant TIM17-EGR ( event generation register ) 
TIM17 $14 + constant TIM17-CCMR1_Output ( capture/compare mode register output mode ) 
TIM17 $18 + constant TIM17-CCMR1_Input ( capture/compare mode register 1 input mode ) 
TIM17 $1C + constant TIM17-CCER ( capture/compare enable register ) 
TIM17 $20 + constant TIM17-CNT ( counter ) 
TIM17 $24 + constant TIM17-PSC ( prescaler ) 
TIM17 $28 + constant TIM17-ARR ( auto-reload register ) 
TIM17 $2C + constant TIM17-RCR ( repetition counter register ) 
TIM17 $30 + constant TIM17-CCR1 ( capture/compare register 1 ) 
TIM17 $34 + constant TIM17-BDTR ( break and dead-time register ) 
TIM17 $38 + constant TIM17-DCR ( DMA control register ) 
TIM17 $3C + constant TIM17-DMAR ( DMA address for full transfer ) 
TIM17 $40 + constant TIM17-OR ( TIM16 option register 1 ) 
TIM17 $44 + constant TIM17-AF1 ( TIM17 option register 1 ) 
: TIM17-CR1. ." TIM17-CR1 (read-write) $" TIM17-CR1 @ hex. TIM17-CR1 1b. ;
: TIM17-CR2. ." TIM17-CR2 (read-write) $" TIM17-CR2 @ hex. TIM17-CR2 1b. ;
: TIM17-DIER. ." TIM17-DIER (read-write) $" TIM17-DIER @ hex. TIM17-DIER 1b. ;
: TIM17-SR. ." TIM17-SR (read-write) $" TIM17-SR @ hex. TIM17-SR 1b. ;
: TIM17-EGR. ." TIM17-EGR (write-only) $" TIM17-EGR @ hex. TIM17-EGR 1b. ;
: TIM17-CCMR1_Output. ." TIM17-CCMR1_Output (read-write) $" TIM17-CCMR1_Output @ hex. TIM17-CCMR1_Output 1b. ;
: TIM17-CCMR1_Input. ." TIM17-CCMR1_Input (read-write) $" TIM17-CCMR1_Input @ hex. TIM17-CCMR1_Input 1b. ;
: TIM17-CCER. ." TIM17-CCER (read-write) $" TIM17-CCER @ hex. TIM17-CCER 1b. ;
: TIM17-CNT. ." TIM17-CNT () $" TIM17-CNT @ hex. TIM17-CNT 1b. ;
: TIM17-PSC. ." TIM17-PSC (read-write) $" TIM17-PSC @ hex. TIM17-PSC 1b. ;
: TIM17-ARR. ." TIM17-ARR (read-write) $" TIM17-ARR @ hex. TIM17-ARR 1b. ;
: TIM17-RCR. ." TIM17-RCR (read-write) $" TIM17-RCR @ hex. TIM17-RCR 1b. ;
: TIM17-CCR1. ." TIM17-CCR1 (read-write) $" TIM17-CCR1 @ hex. TIM17-CCR1 1b. ;
: TIM17-BDTR. ." TIM17-BDTR (read-write) $" TIM17-BDTR @ hex. TIM17-BDTR 1b. ;
: TIM17-DCR. ." TIM17-DCR (read-write) $" TIM17-DCR @ hex. TIM17-DCR 1b. ;
: TIM17-DMAR. ." TIM17-DMAR (read-write) $" TIM17-DMAR @ hex. TIM17-DMAR 1b. ;
: TIM17-OR. ." TIM17-OR (read-write) $" TIM17-OR @ hex. TIM17-OR 1b. ;
: TIM17-AF1. ." TIM17-AF1 (read-write) $" TIM17-AF1 @ hex. TIM17-AF1 1b. ;
: TIM17.
TIM17-CR1.
TIM17-CR2.
TIM17-DIER.
TIM17-SR.
TIM17-EGR.
TIM17-CCMR1_Output.
TIM17-CCMR1_Input.
TIM17-CCER.
TIM17-CNT.
TIM17-PSC.
TIM17-ARR.
TIM17-RCR.
TIM17-CCR1.
TIM17-BDTR.
TIM17-DCR.
TIM17-DMAR.
TIM17-OR.
TIM17-AF1.
;

$40012C00 constant TIM1 ( Advanced-timers ) 
TIM1 $0 + constant TIM1-CR1 ( control register 1 ) 
TIM1 $4 + constant TIM1-CR2 ( control register 2 ) 
TIM1 $8 + constant TIM1-SMCR ( slave mode control register ) 
TIM1 $C + constant TIM1-DIER ( DMA/Interrupt enable register ) 
TIM1 $10 + constant TIM1-SR ( status register ) 
TIM1 $14 + constant TIM1-EGR ( event generation register ) 
TIM1 $18 + constant TIM1-CCMR1_Input ( capture/compare mode register 1 output mode ) 
TIM1 $18 + constant TIM1-CCMR1_Output ( capture/compare mode register 1 output mode ) 
TIM1 $1C + constant TIM1-CCMR2_Output ( capture/compare mode register 2 output mode ) 
TIM1 $1C + constant TIM1-CCMR2_Input ( capture/compare mode register 2 output mode ) 
TIM1 $20 + constant TIM1-CCER ( capture/compare enable register ) 
TIM1 $24 + constant TIM1-CNT ( counter ) 
TIM1 $28 + constant TIM1-PSC ( prescaler ) 
TIM1 $2C + constant TIM1-ARR ( auto-reload register ) 
TIM1 $30 + constant TIM1-RCR ( repetition counter register ) 
TIM1 $34 + constant TIM1-CCR1 ( capture/compare register 1 ) 
TIM1 $38 + constant TIM1-CCR2 ( capture/compare register 2 ) 
TIM1 $3C + constant TIM1-CCR3 ( capture/compare register 3 ) 
TIM1 $40 + constant TIM1-CCR4 ( capture/compare register 4 ) 
TIM1 $44 + constant TIM1-BDTR ( break and dead-time register ) 
TIM1 $48 + constant TIM1-DCR ( DMA control register ) 
TIM1 $4C + constant TIM1-DMAR ( DMA address for full transfer ) 
TIM1 $50 + constant TIM1-OR ( DMA address for full transfer ) 
TIM1 $54 + constant TIM1-CCMR3_Output ( capture/compare mode register 2 output mode ) 
TIM1 $58 + constant TIM1-CCR5 ( capture/compare register 4 ) 
TIM1 $5C + constant TIM1-CCR6 ( capture/compare register 4 ) 
TIM1 $60 + constant TIM1-AF1 ( DMA address for full transfer ) 
TIM1 $64 + constant TIM1-AF2 ( DMA address for full transfer ) 
: TIM1-CR1. ." TIM1-CR1 (read-write) $" TIM1-CR1 @ hex. TIM1-CR1 1b. ;
: TIM1-CR2. ." TIM1-CR2 (read-write) $" TIM1-CR2 @ hex. TIM1-CR2 1b. ;
: TIM1-SMCR. ." TIM1-SMCR (read-write) $" TIM1-SMCR @ hex. TIM1-SMCR 1b. ;
: TIM1-DIER. ." TIM1-DIER (read-write) $" TIM1-DIER @ hex. TIM1-DIER 1b. ;
: TIM1-SR. ." TIM1-SR (read-write) $" TIM1-SR @ hex. TIM1-SR 1b. ;
: TIM1-EGR. ." TIM1-EGR (write-only) $" TIM1-EGR @ hex. TIM1-EGR 1b. ;
: TIM1-CCMR1_Input. ." TIM1-CCMR1_Input (read-write) $" TIM1-CCMR1_Input @ hex. TIM1-CCMR1_Input 1b. ;
: TIM1-CCMR1_Output. ." TIM1-CCMR1_Output (read-write) $" TIM1-CCMR1_Output @ hex. TIM1-CCMR1_Output 1b. ;
: TIM1-CCMR2_Output. ." TIM1-CCMR2_Output (read-write) $" TIM1-CCMR2_Output @ hex. TIM1-CCMR2_Output 1b. ;
: TIM1-CCMR2_Input. ." TIM1-CCMR2_Input (read-write) $" TIM1-CCMR2_Input @ hex. TIM1-CCMR2_Input 1b. ;
: TIM1-CCER. ." TIM1-CCER (read-write) $" TIM1-CCER @ hex. TIM1-CCER 1b. ;
: TIM1-CNT. ." TIM1-CNT () $" TIM1-CNT @ hex. TIM1-CNT 1b. ;
: TIM1-PSC. ." TIM1-PSC (read-write) $" TIM1-PSC @ hex. TIM1-PSC 1b. ;
: TIM1-ARR. ." TIM1-ARR (read-write) $" TIM1-ARR @ hex. TIM1-ARR 1b. ;
: TIM1-RCR. ." TIM1-RCR (read-write) $" TIM1-RCR @ hex. TIM1-RCR 1b. ;
: TIM1-CCR1. ." TIM1-CCR1 (read-write) $" TIM1-CCR1 @ hex. TIM1-CCR1 1b. ;
: TIM1-CCR2. ." TIM1-CCR2 (read-write) $" TIM1-CCR2 @ hex. TIM1-CCR2 1b. ;
: TIM1-CCR3. ." TIM1-CCR3 (read-write) $" TIM1-CCR3 @ hex. TIM1-CCR3 1b. ;
: TIM1-CCR4. ." TIM1-CCR4 (read-write) $" TIM1-CCR4 @ hex. TIM1-CCR4 1b. ;
: TIM1-BDTR. ." TIM1-BDTR (read-write) $" TIM1-BDTR @ hex. TIM1-BDTR 1b. ;
: TIM1-DCR. ." TIM1-DCR (read-write) $" TIM1-DCR @ hex. TIM1-DCR 1b. ;
: TIM1-DMAR. ." TIM1-DMAR (read-write) $" TIM1-DMAR @ hex. TIM1-DMAR 1b. ;
: TIM1-OR. ." TIM1-OR (read-write) $" TIM1-OR @ hex. TIM1-OR 1b. ;
: TIM1-CCMR3_Output. ." TIM1-CCMR3_Output (read-write) $" TIM1-CCMR3_Output @ hex. TIM1-CCMR3_Output 1b. ;
: TIM1-CCR5. ." TIM1-CCR5 (read-write) $" TIM1-CCR5 @ hex. TIM1-CCR5 1b. ;
: TIM1-CCR6. ." TIM1-CCR6 (read-write) $" TIM1-CCR6 @ hex. TIM1-CCR6 1b. ;
: TIM1-AF1. ." TIM1-AF1 (read-write) $" TIM1-AF1 @ hex. TIM1-AF1 1b. ;
: TIM1-AF2. ." TIM1-AF2 (read-write) $" TIM1-AF2 @ hex. TIM1-AF2 1b. ;
: TIM1.
TIM1-CR1.
TIM1-CR2.
TIM1-SMCR.
TIM1-DIER.
TIM1-SR.
TIM1-EGR.
TIM1-CCMR1_Input.
TIM1-CCMR1_Output.
TIM1-CCMR2_Output.
TIM1-CCMR2_Input.
TIM1-CCER.
TIM1-CNT.
TIM1-PSC.
TIM1-ARR.
TIM1-RCR.
TIM1-CCR1.
TIM1-CCR2.
TIM1-CCR3.
TIM1-CCR4.
TIM1-BDTR.
TIM1-DCR.
TIM1-DMAR.
TIM1-OR.
TIM1-CCMR3_Output.
TIM1-CCR5.
TIM1-CCR6.
TIM1-AF1.
TIM1-AF2.
;

$40007C00 constant LPTIM1 ( Low power timer ) 
LPTIM1 $0 + constant LPTIM1-ISR ( Interrupt and Status Register ) 
LPTIM1 $4 + constant LPTIM1-ICR ( Interrupt Clear Register ) 
LPTIM1 $8 + constant LPTIM1-IER ( Interrupt Enable Register ) 
LPTIM1 $C + constant LPTIM1-CFGR ( Configuration Register ) 
LPTIM1 $10 + constant LPTIM1-CR ( Control Register ) 
LPTIM1 $14 + constant LPTIM1-CMP ( Compare Register ) 
LPTIM1 $18 + constant LPTIM1-ARR ( Autoreload Register ) 
LPTIM1 $1C + constant LPTIM1-CNT ( Counter Register ) 
LPTIM1 $20 + constant LPTIM1-OR ( Option Register ) 
: LPTIM1-ISR. ." LPTIM1-ISR (read-only) $" LPTIM1-ISR @ hex. LPTIM1-ISR 1b. ;
: LPTIM1-ICR. ." LPTIM1-ICR (write-only) $" LPTIM1-ICR @ hex. LPTIM1-ICR 1b. ;
: LPTIM1-IER. ." LPTIM1-IER (read-write) $" LPTIM1-IER @ hex. LPTIM1-IER 1b. ;
: LPTIM1-CFGR. ." LPTIM1-CFGR (read-write) $" LPTIM1-CFGR @ hex. LPTIM1-CFGR 1b. ;
: LPTIM1-CR. ." LPTIM1-CR (read-write) $" LPTIM1-CR @ hex. LPTIM1-CR 1b. ;
: LPTIM1-CMP. ." LPTIM1-CMP (read-write) $" LPTIM1-CMP @ hex. LPTIM1-CMP 1b. ;
: LPTIM1-ARR. ." LPTIM1-ARR (read-write) $" LPTIM1-ARR @ hex. LPTIM1-ARR 1b. ;
: LPTIM1-CNT. ." LPTIM1-CNT (read-only) $" LPTIM1-CNT @ hex. LPTIM1-CNT 1b. ;
: LPTIM1-OR. ." LPTIM1-OR (read-write) $" LPTIM1-OR @ hex. LPTIM1-OR 1b. ;
: LPTIM1.
LPTIM1-ISR.
LPTIM1-ICR.
LPTIM1-IER.
LPTIM1-CFGR.
LPTIM1-CR.
LPTIM1-CMP.
LPTIM1-ARR.
LPTIM1-CNT.
LPTIM1-OR.
;

$40009400 constant LPTIM2 ( Low power timer ) 
LPTIM2 $0 + constant LPTIM2-ISR ( Interrupt and Status Register ) 
LPTIM2 $4 + constant LPTIM2-ICR ( Interrupt Clear Register ) 
LPTIM2 $8 + constant LPTIM2-IER ( Interrupt Enable Register ) 
LPTIM2 $C + constant LPTIM2-CFGR ( Configuration Register ) 
LPTIM2 $10 + constant LPTIM2-CR ( Control Register ) 
LPTIM2 $14 + constant LPTIM2-CMP ( Compare Register ) 
LPTIM2 $18 + constant LPTIM2-ARR ( Autoreload Register ) 
LPTIM2 $1C + constant LPTIM2-CNT ( Counter Register ) 
LPTIM2 $20 + constant LPTIM2-OR ( Option Register ) 
: LPTIM2-ISR. ." LPTIM2-ISR (read-only) $" LPTIM2-ISR @ hex. LPTIM2-ISR 1b. ;
: LPTIM2-ICR. ." LPTIM2-ICR (write-only) $" LPTIM2-ICR @ hex. LPTIM2-ICR 1b. ;
: LPTIM2-IER. ." LPTIM2-IER (read-write) $" LPTIM2-IER @ hex. LPTIM2-IER 1b. ;
: LPTIM2-CFGR. ." LPTIM2-CFGR (read-write) $" LPTIM2-CFGR @ hex. LPTIM2-CFGR 1b. ;
: LPTIM2-CR. ." LPTIM2-CR (read-write) $" LPTIM2-CR @ hex. LPTIM2-CR 1b. ;
: LPTIM2-CMP. ." LPTIM2-CMP (read-write) $" LPTIM2-CMP @ hex. LPTIM2-CMP 1b. ;
: LPTIM2-ARR. ." LPTIM2-ARR (read-write) $" LPTIM2-ARR @ hex. LPTIM2-ARR 1b. ;
: LPTIM2-CNT. ." LPTIM2-CNT (read-only) $" LPTIM2-CNT @ hex. LPTIM2-CNT 1b. ;
: LPTIM2-OR. ." LPTIM2-OR (read-write) $" LPTIM2-OR @ hex. LPTIM2-OR 1b. ;
: LPTIM2.
LPTIM2-ISR.
LPTIM2-ICR.
LPTIM2-IER.
LPTIM2-CFGR.
LPTIM2-CR.
LPTIM2-CMP.
LPTIM2-ARR.
LPTIM2-CNT.
LPTIM2-OR.
;

$40013800 constant USART1 ( Universal synchronous asynchronous receiver transmitter ) 
USART1 $0 + constant USART1-CR1 ( Control register 1 ) 
USART1 $4 + constant USART1-CR2 ( Control register 2 ) 
USART1 $8 + constant USART1-CR3 ( Control register 3 ) 
USART1 $C + constant USART1-BRR ( Baud rate register ) 
USART1 $10 + constant USART1-GTPR ( Guard time and prescaler register ) 
USART1 $14 + constant USART1-RTOR ( Receiver timeout register ) 
USART1 $18 + constant USART1-RQR ( Request register ) 
USART1 $1C + constant USART1-ISR ( Interrupt & status register ) 
USART1 $20 + constant USART1-ICR ( Interrupt flag clear register ) 
USART1 $24 + constant USART1-RDR ( Receive data register ) 
USART1 $28 + constant USART1-TDR ( Transmit data register ) 
USART1 $2C + constant USART1-PRESC ( Prescaler register ) 
: USART1-CR1. ." USART1-CR1 (read-write) $" USART1-CR1 @ hex. USART1-CR1 1b. ;
: USART1-CR2. ." USART1-CR2 (read-write) $" USART1-CR2 @ hex. USART1-CR2 1b. ;
: USART1-CR3. ." USART1-CR3 (read-write) $" USART1-CR3 @ hex. USART1-CR3 1b. ;
: USART1-BRR. ." USART1-BRR (read-write) $" USART1-BRR @ hex. USART1-BRR 1b. ;
: USART1-GTPR. ." USART1-GTPR (read-write) $" USART1-GTPR @ hex. USART1-GTPR 1b. ;
: USART1-RTOR. ." USART1-RTOR (read-write) $" USART1-RTOR @ hex. USART1-RTOR 1b. ;
: USART1-RQR. ." USART1-RQR (write-only) $" USART1-RQR @ hex. USART1-RQR 1b. ;
: USART1-ISR. ." USART1-ISR (read-only) $" USART1-ISR @ hex. USART1-ISR 1b. ;
: USART1-ICR. ." USART1-ICR (write-only) $" USART1-ICR @ hex. USART1-ICR 1b. ;
: USART1-RDR. ." USART1-RDR (read-only) $" USART1-RDR @ hex. USART1-RDR 1b. ;
: USART1-TDR. ." USART1-TDR (read-write) $" USART1-TDR @ hex. USART1-TDR 1b. ;
: USART1-PRESC. ." USART1-PRESC (read-write) $" USART1-PRESC @ hex. USART1-PRESC 1b. ;
: USART1.
USART1-CR1.
USART1-CR2.
USART1-CR3.
USART1-BRR.
USART1-GTPR.
USART1-RTOR.
USART1-RQR.
USART1-ISR.
USART1-ICR.
USART1-RDR.
USART1-TDR.
USART1-PRESC.
;

$40008000 constant LPUART1 ( Universal synchronous asynchronous receiver transmitter ) 
LPUART1 $0 + constant LPUART1-CR1 ( Control register 1 ) 
LPUART1 $4 + constant LPUART1-CR2 ( Control register 2 ) 
LPUART1 $8 + constant LPUART1-CR3 ( Control register 3 ) 
LPUART1 $C + constant LPUART1-BRR ( Baud rate register ) 
LPUART1 $10 + constant LPUART1-GTPR ( Guard time and prescaler register ) 
LPUART1 $14 + constant LPUART1-RTOR ( Receiver timeout register ) 
LPUART1 $18 + constant LPUART1-RQR ( Request register ) 
LPUART1 $1C + constant LPUART1-ISR ( Interrupt & status register ) 
LPUART1 $20 + constant LPUART1-ICR ( Interrupt flag clear register ) 
LPUART1 $24 + constant LPUART1-RDR ( Receive data register ) 
LPUART1 $28 + constant LPUART1-TDR ( Transmit data register ) 
LPUART1 $2C + constant LPUART1-PRESC ( Prescaler register ) 
: LPUART1-CR1. ." LPUART1-CR1 (read-write) $" LPUART1-CR1 @ hex. LPUART1-CR1 1b. ;
: LPUART1-CR2. ." LPUART1-CR2 (read-write) $" LPUART1-CR2 @ hex. LPUART1-CR2 1b. ;
: LPUART1-CR3. ." LPUART1-CR3 (read-write) $" LPUART1-CR3 @ hex. LPUART1-CR3 1b. ;
: LPUART1-BRR. ." LPUART1-BRR (read-write) $" LPUART1-BRR @ hex. LPUART1-BRR 1b. ;
: LPUART1-GTPR. ." LPUART1-GTPR (read-write) $" LPUART1-GTPR @ hex. LPUART1-GTPR 1b. ;
: LPUART1-RTOR. ." LPUART1-RTOR (read-write) $" LPUART1-RTOR @ hex. LPUART1-RTOR 1b. ;
: LPUART1-RQR. ." LPUART1-RQR (write-only) $" LPUART1-RQR @ hex. LPUART1-RQR 1b. ;
: LPUART1-ISR. ." LPUART1-ISR (read-only) $" LPUART1-ISR @ hex. LPUART1-ISR 1b. ;
: LPUART1-ICR. ." LPUART1-ICR (write-only) $" LPUART1-ICR @ hex. LPUART1-ICR 1b. ;
: LPUART1-RDR. ." LPUART1-RDR (read-only) $" LPUART1-RDR @ hex. LPUART1-RDR 1b. ;
: LPUART1-TDR. ." LPUART1-TDR (read-write) $" LPUART1-TDR @ hex. LPUART1-TDR 1b. ;
: LPUART1-PRESC. ." LPUART1-PRESC (read-write) $" LPUART1-PRESC @ hex. LPUART1-PRESC 1b. ;
: LPUART1.
LPUART1-CR1.
LPUART1-CR2.
LPUART1-CR3.
LPUART1-BRR.
LPUART1-GTPR.
LPUART1-RTOR.
LPUART1-RQR.
LPUART1-ISR.
LPUART1-ICR.
LPUART1-RDR.
LPUART1-TDR.
LPUART1-PRESC.
;

$40013000 constant SPI1 ( Serial peripheral interface/Inter-IC sound ) 
SPI1 $0 + constant SPI1-CR1 ( control register 1 ) 
SPI1 $4 + constant SPI1-CR2 ( control register 2 ) 
SPI1 $8 + constant SPI1-SR ( status register ) 
SPI1 $C + constant SPI1-DR ( data register ) 
SPI1 $10 + constant SPI1-CRCPR ( CRC polynomial register ) 
SPI1 $14 + constant SPI1-RXCRCR ( RX CRC register ) 
SPI1 $18 + constant SPI1-TXCRCR ( TX CRC register ) 
: SPI1-CR1. ." SPI1-CR1 (read-write) $" SPI1-CR1 @ hex. SPI1-CR1 1b. ;
: SPI1-CR2. ." SPI1-CR2 (read-write) $" SPI1-CR2 @ hex. SPI1-CR2 1b. ;
: SPI1-SR. ." SPI1-SR () $" SPI1-SR @ hex. SPI1-SR 1b. ;
: SPI1-DR. ." SPI1-DR (read-write) $" SPI1-DR @ hex. SPI1-DR 1b. ;
: SPI1-CRCPR. ." SPI1-CRCPR (read-write) $" SPI1-CRCPR @ hex. SPI1-CRCPR 1b. ;
: SPI1-RXCRCR. ." SPI1-RXCRCR (read-only) $" SPI1-RXCRCR @ hex. SPI1-RXCRCR 1b. ;
: SPI1-TXCRCR. ." SPI1-TXCRCR (read-only) $" SPI1-TXCRCR @ hex. SPI1-TXCRCR 1b. ;
: SPI1.
SPI1-CR1.
SPI1-CR2.
SPI1-SR.
SPI1-DR.
SPI1-CRCPR.
SPI1-RXCRCR.
SPI1-TXCRCR.
;

$40003800 constant SPI2 ( Serial peripheral interface/Inter-IC sound ) 
SPI2 $0 + constant SPI2-CR1 ( control register 1 ) 
SPI2 $4 + constant SPI2-CR2 ( control register 2 ) 
SPI2 $8 + constant SPI2-SR ( status register ) 
SPI2 $C + constant SPI2-DR ( data register ) 
SPI2 $10 + constant SPI2-CRCPR ( CRC polynomial register ) 
SPI2 $14 + constant SPI2-RXCRCR ( RX CRC register ) 
SPI2 $18 + constant SPI2-TXCRCR ( TX CRC register ) 
: SPI2-CR1. ." SPI2-CR1 (read-write) $" SPI2-CR1 @ hex. SPI2-CR1 1b. ;
: SPI2-CR2. ." SPI2-CR2 (read-write) $" SPI2-CR2 @ hex. SPI2-CR2 1b. ;
: SPI2-SR. ." SPI2-SR () $" SPI2-SR @ hex. SPI2-SR 1b. ;
: SPI2-DR. ." SPI2-DR (read-write) $" SPI2-DR @ hex. SPI2-DR 1b. ;
: SPI2-CRCPR. ." SPI2-CRCPR (read-write) $" SPI2-CRCPR @ hex. SPI2-CRCPR 1b. ;
: SPI2-RXCRCR. ." SPI2-RXCRCR (read-only) $" SPI2-RXCRCR @ hex. SPI2-RXCRCR 1b. ;
: SPI2-TXCRCR. ." SPI2-TXCRCR (read-only) $" SPI2-TXCRCR @ hex. SPI2-TXCRCR 1b. ;
: SPI2.
SPI2-CR1.
SPI2-CR2.
SPI2-SR.
SPI2-DR.
SPI2-CRCPR.
SPI2-RXCRCR.
SPI2-TXCRCR.
;

$40010030 constant VREFBUF ( Voltage reference buffer ) 
VREFBUF $0 + constant VREFBUF-CSR ( VREF control and status register ) 
VREFBUF $4 + constant VREFBUF-CCR ( calibration control register ) 
: VREFBUF-CSR. ." VREFBUF-CSR () $" VREFBUF-CSR @ hex. VREFBUF-CSR 1b. ;
: VREFBUF-CCR. ." VREFBUF-CCR (read-write) $" VREFBUF-CCR @ hex. VREFBUF-CCR 1b. ;
: VREFBUF.
VREFBUF-CSR.
VREFBUF-CCR.
;

$40002800 constant RTC ( Real-time clock ) 
RTC $0 + constant RTC-TR ( time register ) 
RTC $4 + constant RTC-DR ( date register ) 
RTC $8 + constant RTC-CR ( control register ) 
RTC $C + constant RTC-ISR ( initialization and status register ) 
RTC $10 + constant RTC-PRER ( prescaler register ) 
RTC $14 + constant RTC-WUTR ( wakeup timer register ) 
RTC $1C + constant RTC-ALRMAR ( alarm A register ) 
RTC $20 + constant RTC-ALRMBR ( alarm B register ) 
RTC $24 + constant RTC-WPR ( write protection register ) 
RTC $28 + constant RTC-SSR ( sub second register ) 
RTC $2C + constant RTC-SHIFTR ( shift control register ) 
RTC $30 + constant RTC-TSTR ( time stamp time register ) 
RTC $34 + constant RTC-TSDR ( time stamp date register ) 
RTC $38 + constant RTC-TSSSR ( timestamp sub second register ) 
RTC $3C + constant RTC-CALR ( calibration register ) 
RTC $40 + constant RTC-TAMPCR ( tamper configuration register ) 
RTC $44 + constant RTC-ALRMASSR ( alarm A sub second register ) 
RTC $48 + constant RTC-ALRMBSSR ( alarm B sub second register ) 
RTC $4C + constant RTC-OR ( option register ) 
RTC $50 + constant RTC-BKP0R ( backup register ) 
RTC $54 + constant RTC-BKP1R ( backup register ) 
RTC $58 + constant RTC-BKP2R ( backup register ) 
RTC $5C + constant RTC-BKP3R ( backup register ) 
RTC $60 + constant RTC-BKP4R ( backup register ) 
RTC $64 + constant RTC-BKP5R ( backup register ) 
RTC $68 + constant RTC-BKP6R ( backup register ) 
RTC $6C + constant RTC-BKP7R ( backup register ) 
RTC $70 + constant RTC-BKP8R ( backup register ) 
RTC $74 + constant RTC-BKP9R ( backup register ) 
RTC $78 + constant RTC-BKP10R ( backup register ) 
RTC $7C + constant RTC-BKP11R ( backup register ) 
RTC $80 + constant RTC-BKP12R ( backup register ) 
RTC $84 + constant RTC-BKP13R ( backup register ) 
RTC $88 + constant RTC-BKP14R ( backup register ) 
RTC $8C + constant RTC-BKP15R ( backup register ) 
RTC $90 + constant RTC-BKP16R ( backup register ) 
RTC $94 + constant RTC-BKP17R ( backup register ) 
RTC $98 + constant RTC-BKP18R ( backup register ) 
RTC $9C + constant RTC-BKP19R ( backup register ) 
: RTC-TR. ." RTC-TR (read-write) $" RTC-TR @ hex. RTC-TR 1b. ;
: RTC-DR. ." RTC-DR (read-write) $" RTC-DR @ hex. RTC-DR 1b. ;
: RTC-CR. ." RTC-CR (read-write) $" RTC-CR @ hex. RTC-CR 1b. ;
: RTC-ISR. ." RTC-ISR () $" RTC-ISR @ hex. RTC-ISR 1b. ;
: RTC-PRER. ." RTC-PRER (read-write) $" RTC-PRER @ hex. RTC-PRER 1b. ;
: RTC-WUTR. ." RTC-WUTR (read-write) $" RTC-WUTR @ hex. RTC-WUTR 1b. ;
: RTC-ALRMAR. ." RTC-ALRMAR (read-write) $" RTC-ALRMAR @ hex. RTC-ALRMAR 1b. ;
: RTC-ALRMBR. ." RTC-ALRMBR (read-write) $" RTC-ALRMBR @ hex. RTC-ALRMBR 1b. ;
: RTC-WPR. ." RTC-WPR (write-only) $" RTC-WPR @ hex. RTC-WPR 1b. ;
: RTC-SSR. ." RTC-SSR (read-only) $" RTC-SSR @ hex. RTC-SSR 1b. ;
: RTC-SHIFTR. ." RTC-SHIFTR (write-only) $" RTC-SHIFTR @ hex. RTC-SHIFTR 1b. ;
: RTC-TSTR. ." RTC-TSTR (read-only) $" RTC-TSTR @ hex. RTC-TSTR 1b. ;
: RTC-TSDR. ." RTC-TSDR (read-only) $" RTC-TSDR @ hex. RTC-TSDR 1b. ;
: RTC-TSSSR. ." RTC-TSSSR (read-only) $" RTC-TSSSR @ hex. RTC-TSSSR 1b. ;
: RTC-CALR. ." RTC-CALR (read-write) $" RTC-CALR @ hex. RTC-CALR 1b. ;
: RTC-TAMPCR. ." RTC-TAMPCR (read-write) $" RTC-TAMPCR @ hex. RTC-TAMPCR 1b. ;
: RTC-ALRMASSR. ." RTC-ALRMASSR (read-write) $" RTC-ALRMASSR @ hex. RTC-ALRMASSR 1b. ;
: RTC-ALRMBSSR. ." RTC-ALRMBSSR (read-write) $" RTC-ALRMBSSR @ hex. RTC-ALRMBSSR 1b. ;
: RTC-OR. ." RTC-OR (read-write) $" RTC-OR @ hex. RTC-OR 1b. ;
: RTC-BKP0R. ." RTC-BKP0R (read-write) $" RTC-BKP0R @ hex. RTC-BKP0R 1b. ;
: RTC-BKP1R. ." RTC-BKP1R (read-write) $" RTC-BKP1R @ hex. RTC-BKP1R 1b. ;
: RTC-BKP2R. ." RTC-BKP2R (read-write) $" RTC-BKP2R @ hex. RTC-BKP2R 1b. ;
: RTC-BKP3R. ." RTC-BKP3R (read-write) $" RTC-BKP3R @ hex. RTC-BKP3R 1b. ;
: RTC-BKP4R. ." RTC-BKP4R (read-write) $" RTC-BKP4R @ hex. RTC-BKP4R 1b. ;
: RTC-BKP5R. ." RTC-BKP5R (read-write) $" RTC-BKP5R @ hex. RTC-BKP5R 1b. ;
: RTC-BKP6R. ." RTC-BKP6R (read-write) $" RTC-BKP6R @ hex. RTC-BKP6R 1b. ;
: RTC-BKP7R. ." RTC-BKP7R (read-write) $" RTC-BKP7R @ hex. RTC-BKP7R 1b. ;
: RTC-BKP8R. ." RTC-BKP8R (read-write) $" RTC-BKP8R @ hex. RTC-BKP8R 1b. ;
: RTC-BKP9R. ." RTC-BKP9R (read-write) $" RTC-BKP9R @ hex. RTC-BKP9R 1b. ;
: RTC-BKP10R. ." RTC-BKP10R (read-write) $" RTC-BKP10R @ hex. RTC-BKP10R 1b. ;
: RTC-BKP11R. ." RTC-BKP11R (read-write) $" RTC-BKP11R @ hex. RTC-BKP11R 1b. ;
: RTC-BKP12R. ." RTC-BKP12R (read-write) $" RTC-BKP12R @ hex. RTC-BKP12R 1b. ;
: RTC-BKP13R. ." RTC-BKP13R (read-write) $" RTC-BKP13R @ hex. RTC-BKP13R 1b. ;
: RTC-BKP14R. ." RTC-BKP14R (read-write) $" RTC-BKP14R @ hex. RTC-BKP14R 1b. ;
: RTC-BKP15R. ." RTC-BKP15R (read-write) $" RTC-BKP15R @ hex. RTC-BKP15R 1b. ;
: RTC-BKP16R. ." RTC-BKP16R (read-write) $" RTC-BKP16R @ hex. RTC-BKP16R 1b. ;
: RTC-BKP17R. ." RTC-BKP17R (read-write) $" RTC-BKP17R @ hex. RTC-BKP17R 1b. ;
: RTC-BKP18R. ." RTC-BKP18R (read-write) $" RTC-BKP18R @ hex. RTC-BKP18R 1b. ;
: RTC-BKP19R. ." RTC-BKP19R (read-write) $" RTC-BKP19R @ hex. RTC-BKP19R 1b. ;
: RTC.
RTC-TR.
RTC-DR.
RTC-CR.
RTC-ISR.
RTC-PRER.
RTC-WUTR.
RTC-ALRMAR.
RTC-ALRMBR.
RTC-WPR.
RTC-SSR.
RTC-SHIFTR.
RTC-TSTR.
RTC-TSDR.
RTC-TSSSR.
RTC-CALR.
RTC-TAMPCR.
RTC-ALRMASSR.
RTC-ALRMBSSR.
RTC-OR.
RTC-BKP0R.
RTC-BKP1R.
RTC-BKP2R.
RTC-BKP3R.
RTC-BKP4R.
RTC-BKP5R.
RTC-BKP6R.
RTC-BKP7R.
RTC-BKP8R.
RTC-BKP9R.
RTC-BKP10R.
RTC-BKP11R.
RTC-BKP12R.
RTC-BKP13R.
RTC-BKP14R.
RTC-BKP15R.
RTC-BKP16R.
RTC-BKP17R.
RTC-BKP18R.
RTC-BKP19R.
;

$E0042000 constant DBGMCU ( Debug support ) 
DBGMCU $0 + constant DBGMCU-IDCODE ( MCU Device ID Code Register ) 
DBGMCU $4 + constant DBGMCU-CR ( Debug MCU Configuration Register ) 
DBGMCU $3C + constant DBGMCU-APB1FZR1 ( APB1 Low Freeze Register CPU1 ) 
DBGMCU $40 + constant DBGMCU-C2AP_B1FZR1 ( APB1 Low Freeze Register CPU2 ) 
DBGMCU $44 + constant DBGMCU-APB1FZR2 ( APB1 High Freeze Register CPU1 ) 
DBGMCU $48 + constant DBGMCU-C2APB1FZR2 ( APB1 High Freeze Register CPU2 ) 
DBGMCU $4C + constant DBGMCU-APB2FZR ( APB2 Freeze Register CPU1 ) 
DBGMCU $48 + constant DBGMCU-C2APB2FZR ( APB2 Freeze Register CPU2 ) 
: DBGMCU-IDCODE. ." DBGMCU-IDCODE (read-only) $" DBGMCU-IDCODE @ hex. DBGMCU-IDCODE 1b. ;
: DBGMCU-CR. ." DBGMCU-CR (read-write) $" DBGMCU-CR @ hex. DBGMCU-CR 1b. ;
: DBGMCU-APB1FZR1. ." DBGMCU-APB1FZR1 (read-write) $" DBGMCU-APB1FZR1 @ hex. DBGMCU-APB1FZR1 1b. ;
: DBGMCU-C2AP_B1FZR1. ." DBGMCU-C2AP_B1FZR1 (read-write) $" DBGMCU-C2AP_B1FZR1 @ hex. DBGMCU-C2AP_B1FZR1 1b. ;
: DBGMCU-APB1FZR2. ." DBGMCU-APB1FZR2 (read-write) $" DBGMCU-APB1FZR2 @ hex. DBGMCU-APB1FZR2 1b. ;
: DBGMCU-C2APB1FZR2. ." DBGMCU-C2APB1FZR2 (read-write) $" DBGMCU-C2APB1FZR2 @ hex. DBGMCU-C2APB1FZR2 1b. ;
: DBGMCU-APB2FZR. ." DBGMCU-APB2FZR (read-write) $" DBGMCU-APB2FZR @ hex. DBGMCU-APB2FZR 1b. ;
: DBGMCU-C2APB2FZR. ." DBGMCU-C2APB2FZR (read-write) $" DBGMCU-C2APB2FZR @ hex. DBGMCU-C2APB2FZR 1b. ;
: DBGMCU.
DBGMCU-IDCODE.
DBGMCU-CR.
DBGMCU-APB1FZR1.
DBGMCU-C2AP_B1FZR1.
DBGMCU-APB1FZR2.
DBGMCU-C2APB1FZR2.
DBGMCU-APB2FZR.
DBGMCU-C2APB2FZR.
;

$58002000 constant PKA ( PKA ) 
PKA $0 + constant PKA-CR ( Control register ) 
PKA $4 + constant PKA-SR ( PKA status register ) 
PKA $8 + constant PKA-CLRFR ( PKA clear flag register ) 
PKA $1FF4 + constant PKA-VERR ( PKA version register ) 
PKA $1FF8 + constant PKA-IPIDR ( PKA identification register ) 
PKA $1FFC + constant PKA-SIDR ( PKA size ID register ) 
: PKA-CR. ." PKA-CR (read-write) $" PKA-CR @ hex. PKA-CR 1b. ;
: PKA-SR. ." PKA-SR (read-only) $" PKA-SR @ hex. PKA-SR 1b. ;
: PKA-CLRFR. ." PKA-CLRFR (read-write) $" PKA-CLRFR @ hex. PKA-CLRFR 1b. ;
: PKA-VERR. ." PKA-VERR (read-only) $" PKA-VERR @ hex. PKA-VERR 1b. ;
: PKA-IPIDR. ." PKA-IPIDR (read-only) $" PKA-IPIDR @ hex. PKA-IPIDR 1b. ;
: PKA-SIDR. ." PKA-SIDR (read-only) $" PKA-SIDR @ hex. PKA-SIDR 1b. ;
: PKA.
PKA-CR.
PKA-SR.
PKA-CLRFR.
PKA-VERR.
PKA-IPIDR.
PKA-SIDR.
;

$58000C00 constant IPCC ( IPCC ) 
IPCC $0 + constant IPCC-C1CR ( Control register CPU1 ) 
IPCC $4 + constant IPCC-C1MR ( Mask register CPU1 ) 
IPCC $8 + constant IPCC-C1SCR ( Status Set or Clear register CPU1 ) 
IPCC $C + constant IPCC-C1TO2SR ( CPU1 to CPU2 status register ) 
IPCC $10 + constant IPCC-C2CR ( Control register CPU2 ) 
IPCC $14 + constant IPCC-C2MR ( Mask register CPU2 ) 
IPCC $18 + constant IPCC-C2SCR ( Status Set or Clear register CPU2 ) 
IPCC $1C + constant IPCC-C2TOC1SR ( CPU2 to CPU1 status register ) 
IPCC $3F0 + constant IPCC-HWCFGR ( IPCC Hardware configuration register ) 
IPCC $3F4 + constant IPCC-VERR ( IPCC version register ) 
IPCC $3F8 + constant IPCC-IPIDR ( IPCC indentification register ) 
IPCC $3FC + constant IPCC-SIDR ( IPCC size indentification register ) 
: IPCC-C1CR. ." IPCC-C1CR (read-write) $" IPCC-C1CR @ hex. IPCC-C1CR 1b. ;
: IPCC-C1MR. ." IPCC-C1MR (read-write) $" IPCC-C1MR @ hex. IPCC-C1MR 1b. ;
: IPCC-C1SCR. ." IPCC-C1SCR (write-only) $" IPCC-C1SCR @ hex. IPCC-C1SCR 1b. ;
: IPCC-C1TO2SR. ." IPCC-C1TO2SR (read-only) $" IPCC-C1TO2SR @ hex. IPCC-C1TO2SR 1b. ;
: IPCC-C2CR. ." IPCC-C2CR (read-write) $" IPCC-C2CR @ hex. IPCC-C2CR 1b. ;
: IPCC-C2MR. ." IPCC-C2MR (read-write) $" IPCC-C2MR @ hex. IPCC-C2MR 1b. ;
: IPCC-C2SCR. ." IPCC-C2SCR (write-only) $" IPCC-C2SCR @ hex. IPCC-C2SCR 1b. ;
: IPCC-C2TOC1SR. ." IPCC-C2TOC1SR (read-only) $" IPCC-C2TOC1SR @ hex. IPCC-C2TOC1SR 1b. ;
: IPCC-HWCFGR. ." IPCC-HWCFGR (read-only) $" IPCC-HWCFGR @ hex. IPCC-HWCFGR 1b. ;
: IPCC-VERR. ." IPCC-VERR (read-only) $" IPCC-VERR @ hex. IPCC-VERR 1b. ;
: IPCC-IPIDR. ." IPCC-IPIDR (read-only) $" IPCC-IPIDR @ hex. IPCC-IPIDR 1b. ;
: IPCC-SIDR. ." IPCC-SIDR (read-only) $" IPCC-SIDR @ hex. IPCC-SIDR 1b. ;
: IPCC.
IPCC-C1CR.
IPCC-C1MR.
IPCC-C1SCR.
IPCC-C1TO2SR.
IPCC-C2CR.
IPCC-C2MR.
IPCC-C2SCR.
IPCC-C2TOC1SR.
IPCC-HWCFGR.
IPCC-VERR.
IPCC-IPIDR.
IPCC-SIDR.
;

$58000800 constant EXTI ( External interrupt/event controller ) 
EXTI $0 + constant EXTI-RTSR1 ( rising trigger selection register ) 
EXTI $4 + constant EXTI-FTSR1 ( falling trigger selection register ) 
EXTI $8 + constant EXTI-SWIER1 ( software interrupt event register ) 
EXTI $C + constant EXTI-PR1 ( EXTI pending register ) 
EXTI $20 + constant EXTI-RTSR2 ( rising trigger selection register ) 
EXTI $24 + constant EXTI-FTSR2 ( falling trigger selection register ) 
EXTI $28 + constant EXTI-SWIER2 ( software interrupt event register ) 
EXTI $2C + constant EXTI-PR2 ( pending register ) 
EXTI $80 + constant EXTI-C1IMR1 ( CPUm wakeup with interrupt mask register ) 
EXTI $C0 + constant EXTI-C2IMR1 ( CPUm wakeup with interrupt mask register ) 
EXTI $84 + constant EXTI-C1EMR1 ( CPUm wakeup with event mask register ) 
EXTI $C4 + constant EXTI-C2EMR1 ( CPUm wakeup with event mask register ) 
EXTI $90 + constant EXTI-C1IMR2 ( CPUm wakeup with interrupt mask register ) 
EXTI $D0 + constant EXTI-C2IMR2 ( CPUm wakeup with interrupt mask register ) 
EXTI $94 + constant EXTI-C1EMR2 ( CPUm wakeup with event mask register ) 
EXTI $D4 + constant EXTI-C2EMR2 ( CPUm wakeup with event mask register ) 
EXTI $3E0 + constant EXTI-HWCFGR5 ( Hardware configuration registers ) 
EXTI $3DC + constant EXTI-HWCFGR6 ( Hardware configuration registers ) 
EXTI $3D8 + constant EXTI-HWCFGR7 ( EXTI Hardware configuration registers ) 
EXTI $3EC + constant EXTI-HWCFGR2 ( Hardware configuration registers ) 
EXTI $3E8 + constant EXTI-HWCFGR3 ( Hardware configuration registers ) 
EXTI $3E4 + constant EXTI-HWCFGR4 ( Hardware configuration registers ) 
EXTI $3F0 + constant EXTI-HWCFGR1 ( Hardware configuration register 1 ) 
EXTI $3F4 + constant EXTI-VERR ( EXTI IP Version register ) 
EXTI $3F8 + constant EXTI-IPIDR ( Identification register ) 
EXTI $3FC + constant EXTI-SIDR ( Size ID register ) 
: EXTI-RTSR1. ." EXTI-RTSR1 (read-write) $" EXTI-RTSR1 @ hex. EXTI-RTSR1 1b. ;
: EXTI-FTSR1. ." EXTI-FTSR1 (read-write) $" EXTI-FTSR1 @ hex. EXTI-FTSR1 1b. ;
: EXTI-SWIER1. ." EXTI-SWIER1 (read-write) $" EXTI-SWIER1 @ hex. EXTI-SWIER1 1b. ;
: EXTI-PR1. ." EXTI-PR1 (read-write) $" EXTI-PR1 @ hex. EXTI-PR1 1b. ;
: EXTI-RTSR2. ." EXTI-RTSR2 (read-write) $" EXTI-RTSR2 @ hex. EXTI-RTSR2 1b. ;
: EXTI-FTSR2. ." EXTI-FTSR2 (read-write) $" EXTI-FTSR2 @ hex. EXTI-FTSR2 1b. ;
: EXTI-SWIER2. ." EXTI-SWIER2 (read-write) $" EXTI-SWIER2 @ hex. EXTI-SWIER2 1b. ;
: EXTI-PR2. ." EXTI-PR2 (read-write) $" EXTI-PR2 @ hex. EXTI-PR2 1b. ;
: EXTI-C1IMR1. ." EXTI-C1IMR1 (read-write) $" EXTI-C1IMR1 @ hex. EXTI-C1IMR1 1b. ;
: EXTI-C2IMR1. ." EXTI-C2IMR1 (read-write) $" EXTI-C2IMR1 @ hex. EXTI-C2IMR1 1b. ;
: EXTI-C1EMR1. ." EXTI-C1EMR1 (read-write) $" EXTI-C1EMR1 @ hex. EXTI-C1EMR1 1b. ;
: EXTI-C2EMR1. ." EXTI-C2EMR1 (read-write) $" EXTI-C2EMR1 @ hex. EXTI-C2EMR1 1b. ;
: EXTI-C1IMR2. ." EXTI-C1IMR2 (read-write) $" EXTI-C1IMR2 @ hex. EXTI-C1IMR2 1b. ;
: EXTI-C2IMR2. ." EXTI-C2IMR2 (read-write) $" EXTI-C2IMR2 @ hex. EXTI-C2IMR2 1b. ;
: EXTI-C1EMR2. ." EXTI-C1EMR2 (read-write) $" EXTI-C1EMR2 @ hex. EXTI-C1EMR2 1b. ;
: EXTI-C2EMR2. ." EXTI-C2EMR2 (read-write) $" EXTI-C2EMR2 @ hex. EXTI-C2EMR2 1b. ;
: EXTI-HWCFGR5. ." EXTI-HWCFGR5 (read-only) $" EXTI-HWCFGR5 @ hex. EXTI-HWCFGR5 1b. ;
: EXTI-HWCFGR6. ." EXTI-HWCFGR6 (read-only) $" EXTI-HWCFGR6 @ hex. EXTI-HWCFGR6 1b. ;
: EXTI-HWCFGR7. ." EXTI-HWCFGR7 (read-only) $" EXTI-HWCFGR7 @ hex. EXTI-HWCFGR7 1b. ;
: EXTI-HWCFGR2. ." EXTI-HWCFGR2 (read-only) $" EXTI-HWCFGR2 @ hex. EXTI-HWCFGR2 1b. ;
: EXTI-HWCFGR3. ." EXTI-HWCFGR3 (read-only) $" EXTI-HWCFGR3 @ hex. EXTI-HWCFGR3 1b. ;
: EXTI-HWCFGR4. ." EXTI-HWCFGR4 (read-only) $" EXTI-HWCFGR4 @ hex. EXTI-HWCFGR4 1b. ;
: EXTI-HWCFGR1. ." EXTI-HWCFGR1 (read-only) $" EXTI-HWCFGR1 @ hex. EXTI-HWCFGR1 1b. ;
: EXTI-VERR. ." EXTI-VERR (read-only) $" EXTI-VERR @ hex. EXTI-VERR 1b. ;
: EXTI-IPIDR. ." EXTI-IPIDR (read-only) $" EXTI-IPIDR @ hex. EXTI-IPIDR 1b. ;
: EXTI-SIDR. ." EXTI-SIDR (read-only) $" EXTI-SIDR @ hex. EXTI-SIDR 1b. ;
: EXTI.
EXTI-RTSR1.
EXTI-FTSR1.
EXTI-SWIER1.
EXTI-PR1.
EXTI-RTSR2.
EXTI-FTSR2.
EXTI-SWIER2.
EXTI-PR2.
EXTI-C1IMR1.
EXTI-C2IMR1.
EXTI-C1EMR1.
EXTI-C2EMR1.
EXTI-C1IMR2.
EXTI-C2IMR2.
EXTI-C1EMR2.
EXTI-C2EMR2.
EXTI-HWCFGR5.
EXTI-HWCFGR6.
EXTI-HWCFGR7.
EXTI-HWCFGR2.
EXTI-HWCFGR3.
EXTI-HWCFGR4.
EXTI-HWCFGR1.
EXTI-VERR.
EXTI-IPIDR.
EXTI-SIDR.
;

$40006000 constant CRS ( Clock recovery system ) 
CRS $0 + constant CRS-CR ( CRS control register ) 
CRS $4 + constant CRS-CFGR ( CRS configuration register ) 
CRS $8 + constant CRS-ISR ( CRS interrupt and status register ) 
CRS $C + constant CRS-ICR ( CRS interrupt flag clear register ) 
: CRS-CR. ." CRS-CR (read-write) $" CRS-CR @ hex. CRS-CR 1b. ;
: CRS-CFGR. ." CRS-CFGR (read-write) $" CRS-CFGR @ hex. CRS-CFGR 1b. ;
: CRS-ISR. ." CRS-ISR (read-only) $" CRS-ISR @ hex. CRS-ISR 1b. ;
: CRS-ICR. ." CRS-ICR (read-write) $" CRS-ICR @ hex. CRS-ICR 1b. ;
: CRS.
CRS-CR.
CRS-CFGR.
CRS-ISR.
CRS-ICR.
;

$40006800 constant USB ( Universal serial bus full-speed device interface ) 
USB $0 + constant USB-EP0R ( endpoint 0 register ) 
USB $4 + constant USB-EP1R ( endpoint 1 register ) 
USB $8 + constant USB-EP2R ( endpoint 2 register ) 
USB $C + constant USB-EP3R ( endpoint 3 register ) 
USB $10 + constant USB-EP4R ( endpoint 4 register ) 
USB $14 + constant USB-EP5R ( endpoint 5 register ) 
USB $18 + constant USB-EP6R ( endpoint 6 register ) 
USB $1C + constant USB-EP7R ( endpoint 7 register ) 
USB $40 + constant USB-CNTR ( control register ) 
USB $44 + constant USB-ISTR ( interrupt status register ) 
USB $48 + constant USB-FNR ( frame number register ) 
USB $4C + constant USB-DADDR ( device address ) 
USB $50 + constant USB-BTABLE ( Buffer table address ) 
USB $52 + constant USB-COUNT0_TX ( Transmission byte count 0 ) 
USB $5A + constant USB-COUNT1_TX ( Transmission byte count 0 ) 
USB $62 + constant USB-COUNT2_TX ( Transmission byte count 0 ) 
USB $6A + constant USB-COUNT3_TX ( Transmission byte count 0 ) 
USB $72 + constant USB-COUNT4_TX ( Transmission byte count 0 ) 
USB $7A + constant USB-COUNT5_TX ( Transmission byte count 0 ) 
USB $82 + constant USB-COUNT6_TX ( Transmission byte count 0 ) 
USB $8A + constant USB-COUNT7_TX ( Transmission byte count 0 ) 
USB $54 + constant USB-ADDR0_RX ( Reception buffer address 0 ) 
USB $5C + constant USB-ADDR1_RX ( Reception buffer address 0 ) 
USB $64 + constant USB-ADDR2_RX ( Reception buffer address 0 ) 
USB $6C + constant USB-ADDR3_RX ( Reception buffer address 0 ) 
USB $74 + constant USB-ADDR4_RX ( Reception buffer address 0 ) 
USB $7C + constant USB-ADDR5_RX ( Reception buffer address 0 ) 
USB $84 + constant USB-ADDR6_RX ( Reception buffer address 0 ) 
USB $8C + constant USB-ADDR7_RX ( Reception buffer address 0 ) 
USB $56 + constant USB-COUNT0_RX ( Reception byte count 0 ) 
USB $5E + constant USB-COUNT1_RX ( Reception byte count 0 ) 
USB $66 + constant USB-COUNT2_RX ( Reception byte count 0 ) 
USB $6E + constant USB-COUNT3_RX ( Reception byte count 0 ) 
USB $76 + constant USB-COUNT4_RX ( Reception byte count 0 ) 
USB $7E + constant USB-COUNT5_RX ( Reception byte count 0 ) 
USB $86 + constant USB-COUNT6_RX ( Reception byte count 0 ) 
USB $8E + constant USB-COUNT7_RX ( Reception byte count 0 ) 
USB $54 + constant USB-LPMCSR ( control and status register ) 
USB $58 + constant USB-BCDR ( Battery charging detector ) 
: USB-EP0R. ." USB-EP0R (read-write) $" USB-EP0R @ hex. USB-EP0R 1b. ;
: USB-EP1R. ." USB-EP1R (read-write) $" USB-EP1R @ hex. USB-EP1R 1b. ;
: USB-EP2R. ." USB-EP2R (read-write) $" USB-EP2R @ hex. USB-EP2R 1b. ;
: USB-EP3R. ." USB-EP3R (read-write) $" USB-EP3R @ hex. USB-EP3R 1b. ;
: USB-EP4R. ." USB-EP4R (read-write) $" USB-EP4R @ hex. USB-EP4R 1b. ;
: USB-EP5R. ." USB-EP5R (read-write) $" USB-EP5R @ hex. USB-EP5R 1b. ;
: USB-EP6R. ." USB-EP6R (read-write) $" USB-EP6R @ hex. USB-EP6R 1b. ;
: USB-EP7R. ." USB-EP7R (read-write) $" USB-EP7R @ hex. USB-EP7R 1b. ;
: USB-CNTR. ." USB-CNTR (read-write) $" USB-CNTR @ hex. USB-CNTR 1b. ;
: USB-ISTR. ." USB-ISTR () $" USB-ISTR @ hex. USB-ISTR 1b. ;
: USB-FNR. ." USB-FNR (read-only) $" USB-FNR @ hex. USB-FNR 1b. ;
: USB-DADDR. ." USB-DADDR (read-write) $" USB-DADDR @ hex. USB-DADDR 1b. ;
: USB-BTABLE. ." USB-BTABLE (read-write) $" USB-BTABLE @ hex. USB-BTABLE 1b. ;
: USB-COUNT0_TX. ." USB-COUNT0_TX (read-write) $" USB-COUNT0_TX @ hex. USB-COUNT0_TX 1b. ;
: USB-COUNT1_TX. ." USB-COUNT1_TX (read-write) $" USB-COUNT1_TX @ hex. USB-COUNT1_TX 1b. ;
: USB-COUNT2_TX. ." USB-COUNT2_TX (read-write) $" USB-COUNT2_TX @ hex. USB-COUNT2_TX 1b. ;
: USB-COUNT3_TX. ." USB-COUNT3_TX (read-write) $" USB-COUNT3_TX @ hex. USB-COUNT3_TX 1b. ;
: USB-COUNT4_TX. ." USB-COUNT4_TX (read-write) $" USB-COUNT4_TX @ hex. USB-COUNT4_TX 1b. ;
: USB-COUNT5_TX. ." USB-COUNT5_TX (read-write) $" USB-COUNT5_TX @ hex. USB-COUNT5_TX 1b. ;
: USB-COUNT6_TX. ." USB-COUNT6_TX (read-write) $" USB-COUNT6_TX @ hex. USB-COUNT6_TX 1b. ;
: USB-COUNT7_TX. ." USB-COUNT7_TX (read-write) $" USB-COUNT7_TX @ hex. USB-COUNT7_TX 1b. ;
: USB-ADDR0_RX. ." USB-ADDR0_RX (read-write) $" USB-ADDR0_RX @ hex. USB-ADDR0_RX 1b. ;
: USB-ADDR1_RX. ." USB-ADDR1_RX (read-write) $" USB-ADDR1_RX @ hex. USB-ADDR1_RX 1b. ;
: USB-ADDR2_RX. ." USB-ADDR2_RX (read-write) $" USB-ADDR2_RX @ hex. USB-ADDR2_RX 1b. ;
: USB-ADDR3_RX. ." USB-ADDR3_RX (read-write) $" USB-ADDR3_RX @ hex. USB-ADDR3_RX 1b. ;
: USB-ADDR4_RX. ." USB-ADDR4_RX (read-write) $" USB-ADDR4_RX @ hex. USB-ADDR4_RX 1b. ;
: USB-ADDR5_RX. ." USB-ADDR5_RX (read-write) $" USB-ADDR5_RX @ hex. USB-ADDR5_RX 1b. ;
: USB-ADDR6_RX. ." USB-ADDR6_RX (read-write) $" USB-ADDR6_RX @ hex. USB-ADDR6_RX 1b. ;
: USB-ADDR7_RX. ." USB-ADDR7_RX (read-write) $" USB-ADDR7_RX @ hex. USB-ADDR7_RX 1b. ;
: USB-COUNT0_RX. ." USB-COUNT0_RX () $" USB-COUNT0_RX @ hex. USB-COUNT0_RX 1b. ;
: USB-COUNT1_RX. ." USB-COUNT1_RX () $" USB-COUNT1_RX @ hex. USB-COUNT1_RX 1b. ;
: USB-COUNT2_RX. ." USB-COUNT2_RX () $" USB-COUNT2_RX @ hex. USB-COUNT2_RX 1b. ;
: USB-COUNT3_RX. ." USB-COUNT3_RX () $" USB-COUNT3_RX @ hex. USB-COUNT3_RX 1b. ;
: USB-COUNT4_RX. ." USB-COUNT4_RX () $" USB-COUNT4_RX @ hex. USB-COUNT4_RX 1b. ;
: USB-COUNT5_RX. ." USB-COUNT5_RX () $" USB-COUNT5_RX @ hex. USB-COUNT5_RX 1b. ;
: USB-COUNT6_RX. ." USB-COUNT6_RX () $" USB-COUNT6_RX @ hex. USB-COUNT6_RX 1b. ;
: USB-COUNT7_RX. ." USB-COUNT7_RX () $" USB-COUNT7_RX @ hex. USB-COUNT7_RX 1b. ;
: USB-LPMCSR. ." USB-LPMCSR () $" USB-LPMCSR @ hex. USB-LPMCSR 1b. ;
: USB-BCDR. ." USB-BCDR () $" USB-BCDR @ hex. USB-BCDR 1b. ;
: USB.
USB-EP0R.
USB-EP1R.
USB-EP2R.
USB-EP3R.
USB-EP4R.
USB-EP5R.
USB-EP6R.
USB-EP7R.
USB-CNTR.
USB-ISTR.
USB-FNR.
USB-DADDR.
USB-BTABLE.
USB-COUNT0_TX.
USB-COUNT1_TX.
USB-COUNT2_TX.
USB-COUNT3_TX.
USB-COUNT4_TX.
USB-COUNT5_TX.
USB-COUNT6_TX.
USB-COUNT7_TX.
USB-ADDR0_RX.
USB-ADDR1_RX.
USB-ADDR2_RX.
USB-ADDR3_RX.
USB-ADDR4_RX.
USB-ADDR5_RX.
USB-ADDR6_RX.
USB-ADDR7_RX.
USB-COUNT0_RX.
USB-COUNT1_RX.
USB-COUNT2_RX.
USB-COUNT3_RX.
USB-COUNT4_RX.
USB-COUNT5_RX.
USB-COUNT6_RX.
USB-COUNT7_RX.
USB-LPMCSR.
USB-BCDR.
;

$E000ED00 constant SCB ( System control block ) 
SCB $0 + constant SCB-CPUID ( CPUID base register ) 
SCB $4 + constant SCB-ICSR ( Interrupt control and state register ) 
SCB $8 + constant SCB-VTOR ( Vector table offset register ) 
SCB $C + constant SCB-AIRCR ( Application interrupt and reset control register ) 
SCB $10 + constant SCB-SCR ( System control register ) 
SCB $14 + constant SCB-CCR ( Configuration and control register ) 
SCB $18 + constant SCB-SHPR1 ( System handler priority registers ) 
SCB $1C + constant SCB-SHPR2 ( System handler priority registers ) 
SCB $20 + constant SCB-SHPR3 ( System handler priority registers ) 
SCB $24 + constant SCB-SHCRS ( System handler control and state register ) 
SCB $28 + constant SCB-CFSR_UFSR_BFSR_MMFSR ( Configurable fault status register ) 
SCB $2C + constant SCB-HFSR ( Hard fault status register ) 
SCB $34 + constant SCB-MMFAR ( Memory management fault address register ) 
SCB $38 + constant SCB-BFAR ( Bus fault address register ) 
SCB $3C + constant SCB-AFSR ( Auxiliary fault status register ) 
: SCB-CPUID. ." SCB-CPUID (read-only) $" SCB-CPUID @ hex. SCB-CPUID 1b. ;
: SCB-ICSR. ." SCB-ICSR (read-write) $" SCB-ICSR @ hex. SCB-ICSR 1b. ;
: SCB-VTOR. ." SCB-VTOR (read-write) $" SCB-VTOR @ hex. SCB-VTOR 1b. ;
: SCB-AIRCR. ." SCB-AIRCR (read-write) $" SCB-AIRCR @ hex. SCB-AIRCR 1b. ;
: SCB-SCR. ." SCB-SCR (read-write) $" SCB-SCR @ hex. SCB-SCR 1b. ;
: SCB-CCR. ." SCB-CCR (read-write) $" SCB-CCR @ hex. SCB-CCR 1b. ;
: SCB-SHPR1. ." SCB-SHPR1 (read-write) $" SCB-SHPR1 @ hex. SCB-SHPR1 1b. ;
: SCB-SHPR2. ." SCB-SHPR2 (read-write) $" SCB-SHPR2 @ hex. SCB-SHPR2 1b. ;
: SCB-SHPR3. ." SCB-SHPR3 (read-write) $" SCB-SHPR3 @ hex. SCB-SHPR3 1b. ;
: SCB-SHCRS. ." SCB-SHCRS (read-write) $" SCB-SHCRS @ hex. SCB-SHCRS 1b. ;
: SCB-CFSR_UFSR_BFSR_MMFSR. ." SCB-CFSR_UFSR_BFSR_MMFSR (read-write) $" SCB-CFSR_UFSR_BFSR_MMFSR @ hex. SCB-CFSR_UFSR_BFSR_MMFSR 1b. ;
: SCB-HFSR. ." SCB-HFSR (read-write) $" SCB-HFSR @ hex. SCB-HFSR 1b. ;
: SCB-MMFAR. ." SCB-MMFAR (read-write) $" SCB-MMFAR @ hex. SCB-MMFAR 1b. ;
: SCB-BFAR. ." SCB-BFAR (read-write) $" SCB-BFAR @ hex. SCB-BFAR 1b. ;
: SCB-AFSR. ." SCB-AFSR (read-write) $" SCB-AFSR @ hex. SCB-AFSR 1b. ;
: SCB.
SCB-CPUID.
SCB-ICSR.
SCB-VTOR.
SCB-AIRCR.
SCB-SCR.
SCB-CCR.
SCB-SHPR1.
SCB-SHPR2.
SCB-SHPR3.
SCB-SHCRS.
SCB-CFSR_UFSR_BFSR_MMFSR.
SCB-HFSR.
SCB-MMFAR.
SCB-BFAR.
SCB-AFSR.
;

$E000E010 constant STK ( SysTick timer ) 
STK $0 + constant STK-CTRL ( SysTick control and status register ) 
STK $4 + constant STK-LOAD ( SysTick reload value register ) 
STK $8 + constant STK-VAL ( SysTick current value register ) 
STK $C + constant STK-CALIB ( SysTick calibration value register ) 
: STK-CTRL. ." STK-CTRL (read-write) $" STK-CTRL @ hex. STK-CTRL 1b. ;
: STK-LOAD. ." STK-LOAD (read-write) $" STK-LOAD @ hex. STK-LOAD 1b. ;
: STK-VAL. ." STK-VAL (read-write) $" STK-VAL @ hex. STK-VAL 1b. ;
: STK-CALIB. ." STK-CALIB (read-write) $" STK-CALIB @ hex. STK-CALIB 1b. ;
: STK.
STK-CTRL.
STK-LOAD.
STK-VAL.
STK-CALIB.
;

$E000ED90 constant MPU ( Memory protection unit ) 
MPU $0 + constant MPU-MPU_TYPER ( MPU type register ) 
MPU $4 + constant MPU-MPU_CTRL ( MPU control register ) 
MPU $8 + constant MPU-MPU_RNR ( MPU region number register ) 
MPU $C + constant MPU-MPU_RBAR ( MPU region base address register ) 
MPU $10 + constant MPU-MPU_RASR ( MPU region attribute and size register ) 
: MPU-MPU_TYPER. ." MPU-MPU_TYPER (read-only) $" MPU-MPU_TYPER @ hex. MPU-MPU_TYPER 1b. ;
: MPU-MPU_CTRL. ." MPU-MPU_CTRL (read-only) $" MPU-MPU_CTRL @ hex. MPU-MPU_CTRL 1b. ;
: MPU-MPU_RNR. ." MPU-MPU_RNR (read-write) $" MPU-MPU_RNR @ hex. MPU-MPU_RNR 1b. ;
: MPU-MPU_RBAR. ." MPU-MPU_RBAR (read-write) $" MPU-MPU_RBAR @ hex. MPU-MPU_RBAR 1b. ;
: MPU-MPU_RASR. ." MPU-MPU_RASR (read-write) $" MPU-MPU_RASR @ hex. MPU-MPU_RASR 1b. ;
: MPU.
MPU-MPU_TYPER.
MPU-MPU_CTRL.
MPU-MPU_RNR.
MPU-MPU_RBAR.
MPU-MPU_RASR.
;

$E000EF34 constant FPU ( Floting point unit ) 
FPU $0 + constant FPU-FPCCR ( Floating-point context control register ) 
FPU $4 + constant FPU-FPCAR ( Floating-point context address register ) 
FPU $8 + constant FPU-FPSCR ( Floating-point status control register ) 
: FPU-FPCCR. ." FPU-FPCCR (read-write) $" FPU-FPCCR @ hex. FPU-FPCCR 1b. ;
: FPU-FPCAR. ." FPU-FPCAR (read-write) $" FPU-FPCAR @ hex. FPU-FPCAR 1b. ;
: FPU-FPSCR. ." FPU-FPSCR (read-write) $" FPU-FPSCR @ hex. FPU-FPSCR 1b. ;
: FPU.
FPU-FPCCR.
FPU-FPCAR.
FPU-FPSCR.
;

$E000E100 constant NVIC ( Nested Vectored Interrupt Controller ) 
NVIC $0 + constant NVIC-ISER0 ( Interrupt Set-Enable Register ) 
NVIC $4 + constant NVIC-ISER1 ( Interrupt Set-Enable Register ) 
NVIC $80 + constant NVIC-ICER0 ( Interrupt Clear-Enable Register ) 
NVIC $84 + constant NVIC-ICER1 ( Interrupt Clear-Enable Register ) 
NVIC $100 + constant NVIC-ISPR0 ( Interrupt Set-Pending Register ) 
NVIC $104 + constant NVIC-ISPR1 ( Interrupt Set-Pending Register ) 
NVIC $180 + constant NVIC-ICPR0 ( Interrupt Clear-Pending Register ) 
NVIC $184 + constant NVIC-ICPR1 ( Interrupt Clear-Pending Register ) 
NVIC $200 + constant NVIC-IABR0 ( Interrupt Active Bit Register ) 
NVIC $204 + constant NVIC-IABR1 ( Interrupt Active Bit Register ) 
NVIC $300 + constant NVIC-IPR0 ( Interrupt Priority Register ) 
NVIC $304 + constant NVIC-IPR1 ( Interrupt Priority Register ) 
NVIC $308 + constant NVIC-IPR2 ( Interrupt Priority Register ) 
NVIC $30C + constant NVIC-IPR3 ( Interrupt Priority Register ) 
NVIC $310 + constant NVIC-IPR4 ( Interrupt Priority Register ) 
NVIC $314 + constant NVIC-IPR5 ( Interrupt Priority Register ) 
NVIC $318 + constant NVIC-IPR6 ( Interrupt Priority Register ) 
NVIC $31C + constant NVIC-IPR7 ( Interrupt Priority Register ) 
NVIC $320 + constant NVIC-IPR8 ( Interrupt Priority Register ) 
NVIC $324 + constant NVIC-IPR9 ( Interrupt Priority Register ) 
NVIC $328 + constant NVIC-IPR10 ( Interrupt Priority Register ) 
NVIC $32C + constant NVIC-IPR11 ( Interrupt Priority Register ) 
NVIC $330 + constant NVIC-IPR12 ( Interrupt Priority Register ) 
NVIC $334 + constant NVIC-IPR13 ( Interrupt Priority Register ) 
NVIC $338 + constant NVIC-IPR14 ( Interrupt Priority Register ) 
NVIC $33C + constant NVIC-IPR15 ( Interrupt Priority Register ) 
NVIC $340 + constant NVIC-IPR16 ( Interrupt Priority Register ) 
NVIC $344 + constant NVIC-IPR17 ( Interrupt Priority Register ) 
: NVIC-ISER0. ." NVIC-ISER0 (read-write) $" NVIC-ISER0 @ hex. NVIC-ISER0 1b. ;
: NVIC-ISER1. ." NVIC-ISER1 (read-write) $" NVIC-ISER1 @ hex. NVIC-ISER1 1b. ;
: NVIC-ICER0. ." NVIC-ICER0 (read-write) $" NVIC-ICER0 @ hex. NVIC-ICER0 1b. ;
: NVIC-ICER1. ." NVIC-ICER1 (read-write) $" NVIC-ICER1 @ hex. NVIC-ICER1 1b. ;
: NVIC-ISPR0. ." NVIC-ISPR0 (read-write) $" NVIC-ISPR0 @ hex. NVIC-ISPR0 1b. ;
: NVIC-ISPR1. ." NVIC-ISPR1 (read-write) $" NVIC-ISPR1 @ hex. NVIC-ISPR1 1b. ;
: NVIC-ICPR0. ." NVIC-ICPR0 (read-write) $" NVIC-ICPR0 @ hex. NVIC-ICPR0 1b. ;
: NVIC-ICPR1. ." NVIC-ICPR1 (read-write) $" NVIC-ICPR1 @ hex. NVIC-ICPR1 1b. ;
: NVIC-IABR0. ." NVIC-IABR0 (read-only) $" NVIC-IABR0 @ hex. NVIC-IABR0 1b. ;
: NVIC-IABR1. ." NVIC-IABR1 (read-only) $" NVIC-IABR1 @ hex. NVIC-IABR1 1b. ;
: NVIC-IPR0. ." NVIC-IPR0 (read-write) $" NVIC-IPR0 @ hex. NVIC-IPR0 1b. ;
: NVIC-IPR1. ." NVIC-IPR1 (read-write) $" NVIC-IPR1 @ hex. NVIC-IPR1 1b. ;
: NVIC-IPR2. ." NVIC-IPR2 (read-write) $" NVIC-IPR2 @ hex. NVIC-IPR2 1b. ;
: NVIC-IPR3. ." NVIC-IPR3 (read-write) $" NVIC-IPR3 @ hex. NVIC-IPR3 1b. ;
: NVIC-IPR4. ." NVIC-IPR4 (read-write) $" NVIC-IPR4 @ hex. NVIC-IPR4 1b. ;
: NVIC-IPR5. ." NVIC-IPR5 (read-write) $" NVIC-IPR5 @ hex. NVIC-IPR5 1b. ;
: NVIC-IPR6. ." NVIC-IPR6 (read-write) $" NVIC-IPR6 @ hex. NVIC-IPR6 1b. ;
: NVIC-IPR7. ." NVIC-IPR7 (read-write) $" NVIC-IPR7 @ hex. NVIC-IPR7 1b. ;
: NVIC-IPR8. ." NVIC-IPR8 (read-write) $" NVIC-IPR8 @ hex. NVIC-IPR8 1b. ;
: NVIC-IPR9. ." NVIC-IPR9 (read-write) $" NVIC-IPR9 @ hex. NVIC-IPR9 1b. ;
: NVIC-IPR10. ." NVIC-IPR10 (read-write) $" NVIC-IPR10 @ hex. NVIC-IPR10 1b. ;
: NVIC-IPR11. ." NVIC-IPR11 (read-write) $" NVIC-IPR11 @ hex. NVIC-IPR11 1b. ;
: NVIC-IPR12. ." NVIC-IPR12 (read-write) $" NVIC-IPR12 @ hex. NVIC-IPR12 1b. ;
: NVIC-IPR13. ." NVIC-IPR13 (read-write) $" NVIC-IPR13 @ hex. NVIC-IPR13 1b. ;
: NVIC-IPR14. ." NVIC-IPR14 (read-write) $" NVIC-IPR14 @ hex. NVIC-IPR14 1b. ;
: NVIC-IPR15. ." NVIC-IPR15 (read-write) $" NVIC-IPR15 @ hex. NVIC-IPR15 1b. ;
: NVIC-IPR16. ." NVIC-IPR16 (read-write) $" NVIC-IPR16 @ hex. NVIC-IPR16 1b. ;
: NVIC-IPR17. ." NVIC-IPR17 (read-write) $" NVIC-IPR17 @ hex. NVIC-IPR17 1b. ;
: NVIC.
NVIC-ISER0.
NVIC-ISER1.
NVIC-ICER0.
NVIC-ICER1.
NVIC-ISPR0.
NVIC-ISPR1.
NVIC-ICPR0.
NVIC-ICPR1.
NVIC-IABR0.
NVIC-IABR1.
NVIC-IPR0.
NVIC-IPR1.
NVIC-IPR2.
NVIC-IPR3.
NVIC-IPR4.
NVIC-IPR5.
NVIC-IPR6.
NVIC-IPR7.
NVIC-IPR8.
NVIC-IPR9.
NVIC-IPR10.
NVIC-IPR11.
NVIC-IPR12.
NVIC-IPR13.
NVIC-IPR14.
NVIC-IPR15.
NVIC-IPR16.
NVIC-IPR17.
;

$E000EF00 constant NVIC_STIR ( Nested vectored interrupt controller ) 
NVIC_STIR $0 + constant NVIC_STIR-STIR ( Software trigger interrupt register ) 
: NVIC_STIR-STIR. ." NVIC_STIR-STIR (read-write) $" NVIC_STIR-STIR @ hex. NVIC_STIR-STIR 1b. ;
: NVIC_STIR.
NVIC_STIR-STIR.
;

$E000E008 constant SCB_ACTRL ( System control block ACTLR ) 
SCB_ACTRL $0 + constant SCB_ACTRL-ACTRL ( Auxiliary control register ) 
: SCB_ACTRL-ACTRL. ." SCB_ACTRL-ACTRL (read-write) $" SCB_ACTRL-ACTRL @ hex. SCB_ACTRL-ACTRL 1b. ;
: SCB_ACTRL.
SCB_ACTRL-ACTRL.
;

$E000ED88 constant FPU_CPACR ( Floating point unit CPACR ) 
FPU_CPACR $0 + constant FPU_CPACR-CPACR ( Coprocessor access control register ) 
: FPU_CPACR-CPACR. ." FPU_CPACR-CPACR (read-write) $" FPU_CPACR-CPACR @ hex. FPU_CPACR-CPACR 1b. ;
: FPU_CPACR.
FPU_CPACR-CPACR.
;


compiletoram
