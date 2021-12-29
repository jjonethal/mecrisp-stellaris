@ arm-none-eabi-as equates file for RP2040
@ Equates Generator, Copyright Terry Porter 2021 "terry@tjporter.com.au" for RP2040 
@ Transformed from the RP2040.SVD 
@ MIT Licensed 

@ EXAMPLE: By Matthias Koch, GPL3 Licensed. Wait for the peripherals to return from reset
@    .equ RESET, 0
@    str  r0, [r1, #RESET]
@    ldr  r1, =RESETS_BASE 
@ 1: ldr  r2, [r1, #RESETS_RESET_DONE] 
@    mvns r2, r2 
@    ands r2, r0 
@    bne  1b 



@=========================== XIP_CTRL ===========================@
.equ XIP_CTRL_BASE, 0x14000000 QSPI flash execute-in-place block
    .equ XIP_CTRL_CTRL, 0x0000 Cache control
       @ .equ CTRL_POWER_DOWN [3:3]    When 1, the cache memories are powered down. They retain state,  but can not be accessed. This reduces static power dissipation.  Writing 1 to this bit forces CTRL_EN to 0, i.e. the cache cannot  be enabled when powered down.  Cache-as-SRAM accesses will produce a bus error response when  the cache is powered down. 
       @ .equ CTRL_ERR_BADWRITE [1:1]    When 1, writes to any alias other than 0x0 caching, allocating  will produce a bus fault. When 0, these writes are silently ignored.  In either case, writes to the 0x0 alias will deallocate on tag match,  as usual. 
       @ .equ CTRL_EN [0:0]    When 1, enable the cache. When the cache is disabled, all XIP accesses  will go straight to the flash, without querying the cache. When enabled,  cacheable XIP accesses will query the cache, and the flash will  not be accessed if the tag matches and the valid bit is set.  If the cache is enabled, cache-as-SRAM accesses have no effect on the  cache data RAM, and will produce a bus error response. 
 
    .equ XIP_CTRL_FLUSH, 0x0004 Cache Flush control
       @ .equ FLUSH_FLUSH [0:0]    Write 1 to flush the cache. This clears the tag memory, but  the data memory retains its contents. This means cache-as-SRAM  contents is not affected by flush or reset.  Reading will hold the bus stall the processor until the flush  completes. Alternatively STAT can be polled until completion. 
 
    .equ XIP_CTRL_STAT, 0x0008 Cache Status
       @ .equ STAT_FIFO_FULL [2:2]    When 1, indicates the XIP streaming FIFO is completely full.  The streaming FIFO is 2 entries deep, so the full and empty  flag allow its level to be ascertained. 
       @ .equ STAT_FIFO_EMPTY [1:1]    When 1, indicates the XIP streaming FIFO is completely empty. 
       @ .equ STAT_FLUSH_READY [0:0]    Reads as 0 while a cache flush is in progress, and 1 otherwise.  The cache is flushed whenever the XIP block is reset, and also  when requested via the FLUSH register. 
 
    .equ XIP_CTRL_CTR_HIT, 0x000c Cache Hit counter  A 32 bit saturating counter that increments upon each cache hit,  i.e. when an XIP access is serviced directly from cached data.  Write any value to clear.
 
    .equ XIP_CTRL_CTR_ACC, 0x0010 Cache Access counter  A 32 bit saturating counter that increments upon each XIP access,  whether the cache is hit or not. This includes noncacheable accesses.  Write any value to clear.
 
    .equ XIP_CTRL_STREAM_ADDR, 0x0014 FIFO stream address
       @ .equ STREAM_ADDR_STREAM_ADDR [31:2]    The address of the next word to be streamed from flash to the streaming FIFO.  Increments automatically after each flash access.  Write the initial access address here before starting a streaming read. 
 
    .equ XIP_CTRL_STREAM_CTR, 0x0018 FIFO stream control
       @ .equ STREAM_CTR_STREAM_CTR [21:0]    Write a nonzero value to start a streaming read. This will then  progress in the background, using flash idle cycles to transfer  a linear data block from flash to the streaming FIFO.  Decrements automatically 1 at a time as the stream  progresses, and halts on reaching 0.  Write 0 to halt an in-progress stream, and discard any in-flight  read, so that a new stream can immediately be started after  draining the FIFO and reinitialising STREAM_ADDR 
 
    .equ XIP_CTRL_STREAM_FIFO, 0x001c FIFO stream data  Streamed data is buffered here, for retrieval by the system DMA.  This FIFO can also be accessed via the XIP_AUX slave, to avoid exposing  the DMA to bus stalls caused by other XIP traffic.
 

@=========================== XIP_SSI ===========================@
.equ XIP_SSI_BASE, 0x18000000 DW_apb_ssi has the following features:  * APB interface – Allows for easy integration into a DesignWare Synthesizable Components for AMBA 2 implementation.  * APB3 and APB4 protocol support.  * Scalable APB data bus width – Supports APB data bus widths of 8, 16, and 32 bits.  * Serial-master or serial-slave operation – Enables serial communication with serial-master or serial-slave peripheral devices.  * Programmable Dual/Quad/Octal SPI support in Master Mode.  * Dual Data Rate DDR and Read Data Strobe RDS Support - Enables the DW_apb_ssi master to perform operations with the device in DDR and RDS modes when working in Dual/Quad/Octal mode of operation.  * Data Mask Support - Enables the DW_apb_ssi to selectively update the bytes in the device. This feature is applicable only in enhanced SPI modes.  * eXecute-In-Place XIP support - Enables the DW_apb_ssi master to behave as a memory mapped I/O and fetches the data from the device based on the APB read request. This feature is applicable only in enhanced SPI modes.  * DMA Controller Interface – Enables the DW_apb_ssi to interface to a DMA controller over the bus using a handshaking interface for transfer requests.  * Independent masking of interrupts – Master collision, transmit FIFO overflow, transmit FIFO empty, receive FIFO full, receive FIFO underflow, and receive FIFO overflow interrupts can all be masked independently.  * Multi-master contention detection – Informs the processor of multiple serial-master accesses on the serial bus.  * Bypass of meta-stability flip-flops for synchronous clocks – When the APB clock pclk and the DW_apb_ssi serial clock ssi_clk are synchronous, meta-stable flip-flops are not used when transferring control signals across these clock domains.  * Programmable delay on the sample time of the received serial data bit rxd; enables programmable control of routing delays resulting in higher serial data-bit rates.  * Programmable features:  - Serial interface operation – Choice of Motorola SPI, Texas Instruments Synchronous Serial Protocol or National Semiconductor Microwire.  - Clock bit-rate – Dynamic control of the serial bit rate of the data transfer; used in only serial-master mode of operation.  - Data Item size 4 to 32 bits – Item size of each data transfer under the control of the programmer.  * Configured features:  - FIFO depth – 16 words deep. The FIFO width is fixed at 32 bits.  - 1 slave select output.  - Hardware slave-select – Dedicated hardware slave-select line.  - Combined interrupt line - one combined interrupt line from the DW_apb_ssi to the interrupt controller.  - Interrupt polarity – active high interrupt lines.  - Serial clock polarity – low serial-clock polarity directly after reset.  - Serial clock phase – capture on first edge of serial-clock directly after reset.
    .equ XIP_SSI_CTRLR0, 0x0000 Control register 0
       @ .equ CTRLR0_SSTE [24:24]    Slave select toggle enable 
       @ .equ CTRLR0_SPI_FRF [22:21]    SPI frame format 
       @ .equ CTRLR0_DFS_32 [20:16]    Data frame size in 32b transfer mode  Value of n -> n+1 clocks per frame. 
       @ .equ CTRLR0_CFS [15:12]    Control frame size  Value of n -> n+1 clocks per frame. 
       @ .equ CTRLR0_SRL [11:11]    Shift register loop test mode 
       @ .equ CTRLR0_SLV_OE [10:10]    Slave output enable 
       @ .equ CTRLR0_TMOD [9:8]    Transfer mode 
       @ .equ CTRLR0_SCPOL [7:7]    Serial clock polarity 
       @ .equ CTRLR0_SCPH [6:6]    Serial clock phase 
       @ .equ CTRLR0_FRF [5:4]    Frame format 
       @ .equ CTRLR0_DFS [3:0]    Data frame size 
 
    .equ XIP_SSI_CTRLR1, 0x0004 Master Control register 1
       @ .equ CTRLR1_NDF [15:0]    Number of data frames 
 
    .equ XIP_SSI_SSIENR, 0x0008 SSI Enable
       @ .equ SSIENR_SSI_EN [0:0]    SSI enable 
 
    .equ XIP_SSI_MWCR, 0x000c Microwire Control
       @ .equ MWCR_MHS [2:2]    Microwire handshaking 
       @ .equ MWCR_MDD [1:1]    Microwire control 
       @ .equ MWCR_MWMOD [0:0]    Microwire transfer mode 
 
    .equ XIP_SSI_SER, 0x0010 Slave enable
       @ .equ SER_SER [0:0]    For each bit:  0 -> slave not selected  1 -> slave selected 
 
    .equ XIP_SSI_BAUDR, 0x0014 Baud rate
       @ .equ BAUDR_SCKDV [15:0]    SSI clock divider 
 
    .equ XIP_SSI_TXFTLR, 0x0018 TX FIFO threshold level
       @ .equ TXFTLR_TFT [7:0]    Transmit FIFO threshold 
 
    .equ XIP_SSI_RXFTLR, 0x001c RX FIFO threshold level
       @ .equ RXFTLR_RFT [7:0]    Receive FIFO threshold 
 
    .equ XIP_SSI_TXFLR, 0x0020 TX FIFO level
       @ .equ TXFLR_TFTFL [7:0]    Transmit FIFO level 
 
    .equ XIP_SSI_RXFLR, 0x0024 RX FIFO level
       @ .equ RXFLR_RXTFL [7:0]    Receive FIFO level 
 
    .equ XIP_SSI_SR, 0x0028 Status register
       @ .equ SR_DCOL [6:6]    Data collision error 
       @ .equ SR_TXE [5:5]    Transmission error 
       @ .equ SR_RFF [4:4]    Receive FIFO full 
       @ .equ SR_RFNE [3:3]    Receive FIFO not empty 
       @ .equ SR_TFE [2:2]    Transmit FIFO empty 
       @ .equ SR_TFNF [1:1]    Transmit FIFO not full 
       @ .equ SR_BUSY [0:0]    SSI busy flag 
 
    .equ XIP_SSI_IMR, 0x002c Interrupt mask
       @ .equ IMR_MSTIM [5:5]    Multi-master contention interrupt mask 
       @ .equ IMR_RXFIM [4:4]    Receive FIFO full interrupt mask 
       @ .equ IMR_RXOIM [3:3]    Receive FIFO overflow interrupt mask 
       @ .equ IMR_RXUIM [2:2]    Receive FIFO underflow interrupt mask 
       @ .equ IMR_TXOIM [1:1]    Transmit FIFO overflow interrupt mask 
       @ .equ IMR_TXEIM [0:0]    Transmit FIFO empty interrupt mask 
 
    .equ XIP_SSI_ISR, 0x0030 Interrupt status
       @ .equ ISR_MSTIS [5:5]    Multi-master contention interrupt status 
       @ .equ ISR_RXFIS [4:4]    Receive FIFO full interrupt status 
       @ .equ ISR_RXOIS [3:3]    Receive FIFO overflow interrupt status 
       @ .equ ISR_RXUIS [2:2]    Receive FIFO underflow interrupt status 
       @ .equ ISR_TXOIS [1:1]    Transmit FIFO overflow interrupt status 
       @ .equ ISR_TXEIS [0:0]    Transmit FIFO empty interrupt status 
 
    .equ XIP_SSI_RISR, 0x0034 Raw interrupt status
       @ .equ RISR_MSTIR [5:5]    Multi-master contention raw interrupt status 
       @ .equ RISR_RXFIR [4:4]    Receive FIFO full raw interrupt status 
       @ .equ RISR_RXOIR [3:3]    Receive FIFO overflow raw interrupt status 
       @ .equ RISR_RXUIR [2:2]    Receive FIFO underflow raw interrupt status 
       @ .equ RISR_TXOIR [1:1]    Transmit FIFO overflow raw interrupt status 
       @ .equ RISR_TXEIR [0:0]    Transmit FIFO empty raw interrupt status 
 
    .equ XIP_SSI_TXOICR, 0x0038 TX FIFO overflow interrupt clear
       @ .equ TXOICR_TXOICR [0:0]    Clear-on-read transmit FIFO overflow interrupt 
 
    .equ XIP_SSI_RXOICR, 0x003c RX FIFO overflow interrupt clear
       @ .equ RXOICR_RXOICR [0:0]    Clear-on-read receive FIFO overflow interrupt 
 
    .equ XIP_SSI_RXUICR, 0x0040 RX FIFO underflow interrupt clear
       @ .equ RXUICR_RXUICR [0:0]    Clear-on-read receive FIFO underflow interrupt 
 
    .equ XIP_SSI_MSTICR, 0x0044 Multi-master interrupt clear
       @ .equ MSTICR_MSTICR [0:0]    Clear-on-read multi-master contention interrupt 
 
    .equ XIP_SSI_ICR, 0x0048 Interrupt clear
       @ .equ ICR_ICR [0:0]    Clear-on-read all active interrupts 
 
    .equ XIP_SSI_DMACR, 0x004c DMA control
       @ .equ DMACR_TDMAE [1:1]    Transmit DMA enable 
       @ .equ DMACR_RDMAE [0:0]    Receive DMA enable 
 
    .equ XIP_SSI_DMATDLR, 0x0050 DMA TX data level
       @ .equ DMATDLR_DMATDL [7:0]    Transmit data watermark level 
 
    .equ XIP_SSI_DMARDLR, 0x0054 DMA RX data level
       @ .equ DMARDLR_DMARDL [7:0]    Receive data watermark level DMARDLR+1 
 
    .equ XIP_SSI_IDR, 0x0058 Identification register
       @ .equ IDR_IDCODE [31:0]    Peripheral dentification code 
 
    .equ XIP_SSI_SSI_VERSION_ID, 0x005c Version ID
       @ .equ SSI_VERSION_ID_SSI_COMP_VERSION [31:0]    SNPS component version format X.YY 
 
    .equ XIP_SSI_DR0, 0x0060 Data Register 0 of 36
       @ .equ DR0_DR [31:0]    First data register of 36 
 
    .equ XIP_SSI_RX_SAMPLE_DLY, 0x00f0 RX sample delay
       @ .equ RX_SAMPLE_DLY_RSD [7:0]    RXD sample delay in SCLK cycles 
 
    .equ XIP_SSI_SPI_CTRLR0, 0x00f4 SPI control
       @ .equ SPI_CTRLR0_XIP_CMD [31:24]    SPI Command to send in XIP mode INST_L = 8-bit or to append to Address INST_L = 0-bit 
       @ .equ SPI_CTRLR0_SPI_RXDS_EN [18:18]    Read data strobe enable 
       @ .equ SPI_CTRLR0_INST_DDR_EN [17:17]    Instruction DDR transfer enable 
       @ .equ SPI_CTRLR0_SPI_DDR_EN [16:16]    SPI DDR transfer enable 
       @ .equ SPI_CTRLR0_WAIT_CYCLES [15:11]    Wait cycles between control frame transmit and data reception in SCLK cycles 
       @ .equ SPI_CTRLR0_INST_L [9:8]    Instruction length 0/4/8/16b 
       @ .equ SPI_CTRLR0_ADDR_L [5:2]    Address length 0b-60b in 4b increments 
       @ .equ SPI_CTRLR0_TRANS_TYPE [1:0]    Address and instruction transfer format 
 
    .equ XIP_SSI_TXD_DRIVE_EDGE, 0x00f8 TX drive edge
       @ .equ TXD_DRIVE_EDGE_TDE [7:0]    TXD drive edge 
 

@=========================== SYSINFO ===========================@
.equ SYSINFO_BASE, 0x40000000 
    .equ SYSINFO_CHIP_ID, 0x0000 JEDEC JEP-106 compliant chip identifier.
       @ .equ CHIP_ID_REVISION [31:28]     
       @ .equ CHIP_ID_PART [27:12]     
       @ .equ CHIP_ID_MANUFACTURER [11:0]     
 
    .equ SYSINFO_PLATFORM, 0x0004 Platform register. Allows software to know what environment it is running in.
       @ .equ PLATFORM_ASIC [1:1]     
       @ .equ PLATFORM_FPGA [0:0]     
 
    .equ SYSINFO_GITREF_RP2040, 0x0040 Git hash of the chip source. Used to identify chip version.
 

@=========================== SYSCFG ===========================@
.equ SYSCFG_BASE, 0x40004000 Register block for various chip control signals
    .equ SYSCFG_PROC0_NMI_MASK, 0x0000 Processor core 0 NMI source mask  Set a bit high to enable NMI from that IRQ
 
    .equ SYSCFG_PROC1_NMI_MASK, 0x0004 Processor core 1 NMI source mask  Set a bit high to enable NMI from that IRQ
 
    .equ SYSCFG_PROC_CONFIG, 0x0008 Configuration for processors
       @ .equ PROC_CONFIG_PROC1_DAP_INSTID [31:28]    Configure proc1 DAP instance ID.  Recommend that this is NOT changed until you require debug access in multi-chip environment  WARNING: do not set to 15 as this is reserved for RescueDP 
       @ .equ PROC_CONFIG_PROC0_DAP_INSTID [27:24]    Configure proc0 DAP instance ID.  Recommend that this is NOT changed until you require debug access in multi-chip environment  WARNING: do not set to 15 as this is reserved for RescueDP 
       @ .equ PROC_CONFIG_PROC1_HALTED [1:1]    Indication that proc1 has halted 
       @ .equ PROC_CONFIG_PROC0_HALTED [0:0]    Indication that proc0 has halted 
 
    .equ SYSCFG_PROC_IN_SYNC_BYPASS, 0x000c For each bit, if 1, bypass the input synchronizer between that GPIO  and the GPIO input register in the SIO. The input synchronizers should  generally be unbypassed, to avoid injecting metastabilities into processors.  If you're feeling brave, you can bypass to save two cycles of input  latency. This register applies to GPIO 0...29.
       @ .equ PROC_IN_SYNC_BYPASS_PROC_IN_SYNC_BYPASS [29:0]     
 
    .equ SYSCFG_PROC_IN_SYNC_BYPASS_HI, 0x0010 For each bit, if 1, bypass the input synchronizer between that GPIO  and the GPIO input register in the SIO. The input synchronizers should  generally be unbypassed, to avoid injecting metastabilities into processors.  If you're feeling brave, you can bypass to save two cycles of input  latency. This register applies to GPIO 30...35 the QSPI IOs.
       @ .equ PROC_IN_SYNC_BYPASS_HI_PROC_IN_SYNC_BYPASS_HI [5:0]     
 
    .equ SYSCFG_DBGFORCE, 0x0014 Directly control the SWD debug port of either processor
       @ .equ DBGFORCE_PROC1_ATTACH [7:7]    Attach processor 1 debug port to syscfg controls, and disconnect it from external SWD pads. 
       @ .equ DBGFORCE_PROC1_SWCLK [6:6]    Directly drive processor 1 SWCLK, if PROC1_ATTACH is set 
       @ .equ DBGFORCE_PROC1_SWDI [5:5]    Directly drive processor 1 SWDIO input, if PROC1_ATTACH is set 
       @ .equ DBGFORCE_PROC1_SWDO [4:4]    Observe the value of processor 1 SWDIO output. 
       @ .equ DBGFORCE_PROC0_ATTACH [3:3]    Attach processor 0 debug port to syscfg controls, and disconnect it from external SWD pads. 
       @ .equ DBGFORCE_PROC0_SWCLK [2:2]    Directly drive processor 0 SWCLK, if PROC0_ATTACH is set 
       @ .equ DBGFORCE_PROC0_SWDI [1:1]    Directly drive processor 0 SWDIO input, if PROC0_ATTACH is set 
       @ .equ DBGFORCE_PROC0_SWDO [0:0]    Observe the value of processor 0 SWDIO output. 
 
    .equ SYSCFG_MEMPOWERDOWN, 0x0018 Control power downs to memories. Set high to power down memories.  Use with extreme caution
       @ .equ MEMPOWERDOWN_ROM [7:7]     
       @ .equ MEMPOWERDOWN_USB [6:6]     
       @ .equ MEMPOWERDOWN_SRAM5 [5:5]     
       @ .equ MEMPOWERDOWN_SRAM4 [4:4]     
       @ .equ MEMPOWERDOWN_SRAM3 [3:3]     
       @ .equ MEMPOWERDOWN_SRAM2 [2:2]     
       @ .equ MEMPOWERDOWN_SRAM1 [1:1]     
       @ .equ MEMPOWERDOWN_SRAM0 [0:0]     
 

@=========================== CLOCKS ===========================@
.equ CLOCKS_BASE, 0x40008000 
    .equ CLOCKS_CLK_GPOUT0_CTRL, 0x0000 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_GPOUT0_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_GPOUT0_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_GPOUT0_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLK_GPOUT0_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_GPOUT0_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_GPOUT0_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT0_DIV, 0x0004 Clock divisor, can be changed on-the-fly
       @ .equ CLK_GPOUT0_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLK_GPOUT0_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT0_SELECTED, 0x0008 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_GPOUT1_CTRL, 0x000c Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_GPOUT1_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_GPOUT1_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_GPOUT1_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLK_GPOUT1_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_GPOUT1_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_GPOUT1_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT1_DIV, 0x0010 Clock divisor, can be changed on-the-fly
       @ .equ CLK_GPOUT1_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLK_GPOUT1_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT1_SELECTED, 0x0014 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_GPOUT2_CTRL, 0x0018 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_GPOUT2_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_GPOUT2_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_GPOUT2_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLK_GPOUT2_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_GPOUT2_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_GPOUT2_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT2_DIV, 0x001c Clock divisor, can be changed on-the-fly
       @ .equ CLK_GPOUT2_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLK_GPOUT2_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT2_SELECTED, 0x0020 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_GPOUT3_CTRL, 0x0024 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_GPOUT3_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_GPOUT3_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_GPOUT3_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLK_GPOUT3_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_GPOUT3_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_GPOUT3_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT3_DIV, 0x0028 Clock divisor, can be changed on-the-fly
       @ .equ CLK_GPOUT3_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLK_GPOUT3_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT3_SELECTED, 0x002c Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_REF_CTRL, 0x0030 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_REF_CTRL_AUXSRC [6:5]    Selects the auxiliary clock source, will glitch when switching 
       @ .equ CLK_REF_CTRL_SRC [1:0]    Selects the clock source glitchlessly, can be changed on-the-fly 
 
    .equ CLOCKS_CLK_REF_DIV, 0x0034 Clock divisor, can be changed on-the-fly
       @ .equ CLK_REF_DIV_INT [9:8]    Integer component of the divisor, 0 -> divide by 2^16 
 
    .equ CLOCKS_CLK_REF_SELECTED, 0x0038 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_SYS_CTRL, 0x003c Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_SYS_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
       @ .equ CLK_SYS_CTRL_SRC [0:0]    Selects the clock source glitchlessly, can be changed on-the-fly 
 
    .equ CLOCKS_CLK_SYS_DIV, 0x0040 Clock divisor, can be changed on-the-fly
       @ .equ CLK_SYS_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLK_SYS_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_SYS_SELECTED, 0x0044 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_PERI_CTRL, 0x0048 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_PERI_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_PERI_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_PERI_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_PERI_SELECTED, 0x0050 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_USB_CTRL, 0x0054 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_USB_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_USB_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_USB_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_USB_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_USB_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_USB_DIV, 0x0058 Clock divisor, can be changed on-the-fly
       @ .equ CLK_USB_DIV_INT [9:8]    Integer component of the divisor, 0 -> divide by 2^16 
 
    .equ CLOCKS_CLK_USB_SELECTED, 0x005c Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_ADC_CTRL, 0x0060 Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_ADC_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_ADC_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_ADC_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_ADC_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_ADC_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_ADC_DIV, 0x0064 Clock divisor, can be changed on-the-fly
       @ .equ CLK_ADC_DIV_INT [9:8]    Integer component of the divisor, 0 -> divide by 2^16 
 
    .equ CLOCKS_CLK_ADC_SELECTED, 0x0068 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_RTC_CTRL, 0x006c Clock control, can be changed on-the-fly except for auxsrc
       @ .equ CLK_RTC_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock  This can be done at any time 
       @ .equ CLK_RTC_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock  This must be set before the clock is enabled to have any effect 
       @ .equ CLK_RTC_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLK_RTC_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLK_RTC_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_RTC_DIV, 0x0070 Clock divisor, can be changed on-the-fly
       @ .equ CLK_RTC_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLK_RTC_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_RTC_SELECTED, 0x0074 Indicates which src is currently selected one-hot
 
    .equ CLOCKS_CLK_SYS_RESUS_CTRL, 0x0078 
       @ .equ CLK_SYS_RESUS_CTRL_CLEAR [16:16]    For clearing the resus after the fault that triggered it has been corrected 
       @ .equ CLK_SYS_RESUS_CTRL_FRCE [12:12]    Force a resus, for test purposes only 
       @ .equ CLK_SYS_RESUS_CTRL_ENABLE [8:8]    Enable resus 
       @ .equ CLK_SYS_RESUS_CTRL_TIMEOUT [7:0]    This is expressed as a number of clk_ref cycles  and must be >= 2x clk_ref_freq/min_clk_tst_freq 
 
    .equ CLOCKS_CLK_SYS_RESUS_STATUS, 0x007c 
       @ .equ CLK_SYS_RESUS_STATUS_RESUSSED [0:0]    Clock has been resuscitated, correct the error then send ctrl_clear=1 
 
    .equ CLOCKS_FC0_REF_KHZ, 0x0080 Reference clock frequency in kHz
       @ .equ FC0_REF_KHZ_FC0_REF_KHZ [19:0]     
 
    .equ CLOCKS_FC0_MIN_KHZ, 0x0084 Minimum pass frequency in kHz. This is optional. Set to 0 if you are not using the pass/fail flags
       @ .equ FC0_MIN_KHZ_FC0_MIN_KHZ [24:0]     
 
    .equ CLOCKS_FC0_MAX_KHZ, 0x0088 Maximum pass frequency in kHz. This is optional. Set to 0x1ffffff if you are not using the pass/fail flags
       @ .equ FC0_MAX_KHZ_FC0_MAX_KHZ [24:0]     
 
    .equ CLOCKS_FC0_DELAY, 0x008c Delays the start of frequency counting to allow the mux to settle  Delay is measured in multiples of the reference clock period
       @ .equ FC0_DELAY_FC0_DELAY [2:0]     
 
    .equ CLOCKS_FC0_INTERVAL, 0x0090 The test interval is 0.98us * 2**interval, but let's call it 1us * 2**interval  The default gives a test interval of 250us
       @ .equ FC0_INTERVAL_FC0_INTERVAL [3:0]     
 
    .equ CLOCKS_FC0_SRC, 0x0094 Clock sent to frequency counter, set to 0 when not required  Writing to this register initiates the frequency count
       @ .equ FC0_SRC_FC0_SRC [7:0]     
 
    .equ CLOCKS_FC0_STATUS, 0x0098 Frequency counter status
       @ .equ FC0_STATUS_DIED [28:28]    Test clock stopped during test 
       @ .equ FC0_STATUS_FAST [24:24]    Test clock faster than expected, only valid when status_done=1 
       @ .equ FC0_STATUS_SLOW [20:20]    Test clock slower than expected, only valid when status_done=1 
       @ .equ FC0_STATUS_FAIL [16:16]    Test failed 
       @ .equ FC0_STATUS_WAITING [12:12]    Waiting for test clock to start 
       @ .equ FC0_STATUS_RUNNING [8:8]    Test running 
       @ .equ FC0_STATUS_DONE [4:4]    Test complete 
       @ .equ FC0_STATUS_PASS [0:0]    Test passed 
 
    .equ CLOCKS_FC0_RESULT, 0x009c Result of frequency measurement, only valid when status_done=1
       @ .equ FC0_RESULT_KHZ [29:5]     
       @ .equ FC0_RESULT_FRAC [4:0]     
 
    .equ CLOCKS_WAKE_EN0, 0x00a0 enable clock in wake mode
       @ .equ WAKE_EN0_clk_sys_sram3 [31:31]     
       @ .equ WAKE_EN0_clk_sys_sram2 [30:30]     
       @ .equ WAKE_EN0_clk_sys_sram1 [29:29]     
       @ .equ WAKE_EN0_clk_sys_sram0 [28:28]     
       @ .equ WAKE_EN0_clk_sys_spi1 [27:27]     
       @ .equ WAKE_EN0_clk_peri_spi1 [26:26]     
       @ .equ WAKE_EN0_clk_sys_spi0 [25:25]     
       @ .equ WAKE_EN0_clk_peri_spi0 [24:24]     
       @ .equ WAKE_EN0_clk_sys_sio [23:23]     
       @ .equ WAKE_EN0_clk_sys_rtc [22:22]     
       @ .equ WAKE_EN0_clk_rtc_rtc [21:21]     
       @ .equ WAKE_EN0_clk_sys_rosc [20:20]     
       @ .equ WAKE_EN0_clk_sys_rom [19:19]     
       @ .equ WAKE_EN0_clk_sys_resets [18:18]     
       @ .equ WAKE_EN0_clk_sys_pwm [17:17]     
       @ .equ WAKE_EN0_clk_sys_psm [16:16]     
       @ .equ WAKE_EN0_clk_sys_pll_usb [15:15]     
       @ .equ WAKE_EN0_clk_sys_pll_sys [14:14]     
       @ .equ WAKE_EN0_clk_sys_pio1 [13:13]     
       @ .equ WAKE_EN0_clk_sys_pio0 [12:12]     
       @ .equ WAKE_EN0_clk_sys_pads [11:11]     
       @ .equ WAKE_EN0_clk_sys_vreg_and_chip_reset [10:10]     
       @ .equ WAKE_EN0_clk_sys_jtag [9:9]     
       @ .equ WAKE_EN0_clk_sys_io [8:8]     
       @ .equ WAKE_EN0_clk_sys_i2c1 [7:7]     
       @ .equ WAKE_EN0_clk_sys_i2c0 [6:6]     
       @ .equ WAKE_EN0_clk_sys_dma [5:5]     
       @ .equ WAKE_EN0_clk_sys_busfabric [4:4]     
       @ .equ WAKE_EN0_clk_sys_busctrl [3:3]     
       @ .equ WAKE_EN0_clk_sys_adc [2:2]     
       @ .equ WAKE_EN0_clk_adc_adc [1:1]     
       @ .equ WAKE_EN0_clk_sys_clocks [0:0]     
 
    .equ CLOCKS_WAKE_EN1, 0x00a4 enable clock in wake mode
       @ .equ WAKE_EN1_clk_sys_xosc [14:14]     
       @ .equ WAKE_EN1_clk_sys_xip [13:13]     
       @ .equ WAKE_EN1_clk_sys_watchdog [12:12]     
       @ .equ WAKE_EN1_clk_usb_usbctrl [11:11]     
       @ .equ WAKE_EN1_clk_sys_usbctrl [10:10]     
       @ .equ WAKE_EN1_clk_sys_uart1 [9:9]     
       @ .equ WAKE_EN1_clk_peri_uart1 [8:8]     
       @ .equ WAKE_EN1_clk_sys_uart0 [7:7]     
       @ .equ WAKE_EN1_clk_peri_uart0 [6:6]     
       @ .equ WAKE_EN1_clk_sys_timer [5:5]     
       @ .equ WAKE_EN1_clk_sys_tbman [4:4]     
       @ .equ WAKE_EN1_clk_sys_sysinfo [3:3]     
       @ .equ WAKE_EN1_clk_sys_syscfg [2:2]     
       @ .equ WAKE_EN1_clk_sys_sram5 [1:1]     
       @ .equ WAKE_EN1_clk_sys_sram4 [0:0]     
 
    .equ CLOCKS_SLEEP_EN0, 0x00a8 enable clock in sleep mode
       @ .equ SLEEP_EN0_clk_sys_sram3 [31:31]     
       @ .equ SLEEP_EN0_clk_sys_sram2 [30:30]     
       @ .equ SLEEP_EN0_clk_sys_sram1 [29:29]     
       @ .equ SLEEP_EN0_clk_sys_sram0 [28:28]     
       @ .equ SLEEP_EN0_clk_sys_spi1 [27:27]     
       @ .equ SLEEP_EN0_clk_peri_spi1 [26:26]     
       @ .equ SLEEP_EN0_clk_sys_spi0 [25:25]     
       @ .equ SLEEP_EN0_clk_peri_spi0 [24:24]     
       @ .equ SLEEP_EN0_clk_sys_sio [23:23]     
       @ .equ SLEEP_EN0_clk_sys_rtc [22:22]     
       @ .equ SLEEP_EN0_clk_rtc_rtc [21:21]     
       @ .equ SLEEP_EN0_clk_sys_rosc [20:20]     
       @ .equ SLEEP_EN0_clk_sys_rom [19:19]     
       @ .equ SLEEP_EN0_clk_sys_resets [18:18]     
       @ .equ SLEEP_EN0_clk_sys_pwm [17:17]     
       @ .equ SLEEP_EN0_clk_sys_psm [16:16]     
       @ .equ SLEEP_EN0_clk_sys_pll_usb [15:15]     
       @ .equ SLEEP_EN0_clk_sys_pll_sys [14:14]     
       @ .equ SLEEP_EN0_clk_sys_pio1 [13:13]     
       @ .equ SLEEP_EN0_clk_sys_pio0 [12:12]     
       @ .equ SLEEP_EN0_clk_sys_pads [11:11]     
       @ .equ SLEEP_EN0_clk_sys_vreg_and_chip_reset [10:10]     
       @ .equ SLEEP_EN0_clk_sys_jtag [9:9]     
       @ .equ SLEEP_EN0_clk_sys_io [8:8]     
       @ .equ SLEEP_EN0_clk_sys_i2c1 [7:7]     
       @ .equ SLEEP_EN0_clk_sys_i2c0 [6:6]     
       @ .equ SLEEP_EN0_clk_sys_dma [5:5]     
       @ .equ SLEEP_EN0_clk_sys_busfabric [4:4]     
       @ .equ SLEEP_EN0_clk_sys_busctrl [3:3]     
       @ .equ SLEEP_EN0_clk_sys_adc [2:2]     
       @ .equ SLEEP_EN0_clk_adc_adc [1:1]     
       @ .equ SLEEP_EN0_clk_sys_clocks [0:0]     
 
    .equ CLOCKS_SLEEP_EN1, 0x00ac enable clock in sleep mode
       @ .equ SLEEP_EN1_clk_sys_xosc [14:14]     
       @ .equ SLEEP_EN1_clk_sys_xip [13:13]     
       @ .equ SLEEP_EN1_clk_sys_watchdog [12:12]     
       @ .equ SLEEP_EN1_clk_usb_usbctrl [11:11]     
       @ .equ SLEEP_EN1_clk_sys_usbctrl [10:10]     
       @ .equ SLEEP_EN1_clk_sys_uart1 [9:9]     
       @ .equ SLEEP_EN1_clk_peri_uart1 [8:8]     
       @ .equ SLEEP_EN1_clk_sys_uart0 [7:7]     
       @ .equ SLEEP_EN1_clk_peri_uart0 [6:6]     
       @ .equ SLEEP_EN1_clk_sys_timer [5:5]     
       @ .equ SLEEP_EN1_clk_sys_tbman [4:4]     
       @ .equ SLEEP_EN1_clk_sys_sysinfo [3:3]     
       @ .equ SLEEP_EN1_clk_sys_syscfg [2:2]     
       @ .equ SLEEP_EN1_clk_sys_sram5 [1:1]     
       @ .equ SLEEP_EN1_clk_sys_sram4 [0:0]     
 
    .equ CLOCKS_ENABLED0, 0x00b0 indicates the state of the clock enable
       @ .equ ENABLED0_clk_sys_sram3 [31:31]     
       @ .equ ENABLED0_clk_sys_sram2 [30:30]     
       @ .equ ENABLED0_clk_sys_sram1 [29:29]     
       @ .equ ENABLED0_clk_sys_sram0 [28:28]     
       @ .equ ENABLED0_clk_sys_spi1 [27:27]     
       @ .equ ENABLED0_clk_peri_spi1 [26:26]     
       @ .equ ENABLED0_clk_sys_spi0 [25:25]     
       @ .equ ENABLED0_clk_peri_spi0 [24:24]     
       @ .equ ENABLED0_clk_sys_sio [23:23]     
       @ .equ ENABLED0_clk_sys_rtc [22:22]     
       @ .equ ENABLED0_clk_rtc_rtc [21:21]     
       @ .equ ENABLED0_clk_sys_rosc [20:20]     
       @ .equ ENABLED0_clk_sys_rom [19:19]     
       @ .equ ENABLED0_clk_sys_resets [18:18]     
       @ .equ ENABLED0_clk_sys_pwm [17:17]     
       @ .equ ENABLED0_clk_sys_psm [16:16]     
       @ .equ ENABLED0_clk_sys_pll_usb [15:15]     
       @ .equ ENABLED0_clk_sys_pll_sys [14:14]     
       @ .equ ENABLED0_clk_sys_pio1 [13:13]     
       @ .equ ENABLED0_clk_sys_pio0 [12:12]     
       @ .equ ENABLED0_clk_sys_pads [11:11]     
       @ .equ ENABLED0_clk_sys_vreg_and_chip_reset [10:10]     
       @ .equ ENABLED0_clk_sys_jtag [9:9]     
       @ .equ ENABLED0_clk_sys_io [8:8]     
       @ .equ ENABLED0_clk_sys_i2c1 [7:7]     
       @ .equ ENABLED0_clk_sys_i2c0 [6:6]     
       @ .equ ENABLED0_clk_sys_dma [5:5]     
       @ .equ ENABLED0_clk_sys_busfabric [4:4]     
       @ .equ ENABLED0_clk_sys_busctrl [3:3]     
       @ .equ ENABLED0_clk_sys_adc [2:2]     
       @ .equ ENABLED0_clk_adc_adc [1:1]     
       @ .equ ENABLED0_clk_sys_clocks [0:0]     
 
    .equ CLOCKS_ENABLED1, 0x00b4 indicates the state of the clock enable
       @ .equ ENABLED1_clk_sys_xosc [14:14]     
       @ .equ ENABLED1_clk_sys_xip [13:13]     
       @ .equ ENABLED1_clk_sys_watchdog [12:12]     
       @ .equ ENABLED1_clk_usb_usbctrl [11:11]     
       @ .equ ENABLED1_clk_sys_usbctrl [10:10]     
       @ .equ ENABLED1_clk_sys_uart1 [9:9]     
       @ .equ ENABLED1_clk_peri_uart1 [8:8]     
       @ .equ ENABLED1_clk_sys_uart0 [7:7]     
       @ .equ ENABLED1_clk_peri_uart0 [6:6]     
       @ .equ ENABLED1_clk_sys_timer [5:5]     
       @ .equ ENABLED1_clk_sys_tbman [4:4]     
       @ .equ ENABLED1_clk_sys_sysinfo [3:3]     
       @ .equ ENABLED1_clk_sys_syscfg [2:2]     
       @ .equ ENABLED1_clk_sys_sram5 [1:1]     
       @ .equ ENABLED1_clk_sys_sram4 [0:0]     
 
    .equ CLOCKS_INTR, 0x00b8 Raw Interrupts
       @ .equ INTR_CLK_SYS_RESUS [0:0]     
 
    .equ CLOCKS_INTE, 0x00bc Interrupt Enable
       @ .equ INTE_CLK_SYS_RESUS [0:0]     
 
    .equ CLOCKS_INTF, 0x00c0 Interrupt Force
       @ .equ INTF_CLK_SYS_RESUS [0:0]     
 
    .equ CLOCKS_INTS, 0x00c4 Interrupt status after masking & forcing
       @ .equ INTS_CLK_SYS_RESUS [0:0]     
 

@=========================== RESETS ===========================@
.equ RESETS_BASE, 0x4000c000 
    .equ RESETS_RESET, 0x0000 Reset control. If a bit is set it means the peripheral is in reset. 0 means the peripheral's reset is deasserted.
       @ .equ RESET_usbctrl [24:24]     
       @ .equ RESET_uart1 [23:23]     
       @ .equ RESET_uart0 [22:22]     
       @ .equ RESET_timer [21:21]     
       @ .equ RESET_tbman [20:20]     
       @ .equ RESET_sysinfo [19:19]     
       @ .equ RESET_syscfg [18:18]     
       @ .equ RESET_spi1 [17:17]     
       @ .equ RESET_spi0 [16:16]     
       @ .equ RESET_rtc [15:15]     
       @ .equ RESET_pwm [14:14]     
       @ .equ RESET_pll_usb [13:13]     
       @ .equ RESET_pll_sys [12:12]     
       @ .equ RESET_pio1 [11:11]     
       @ .equ RESET_pio0 [10:10]     
       @ .equ RESET_pads_qspi [9:9]     
       @ .equ RESET_pads_bank0 [8:8]     
       @ .equ RESET_jtag [7:7]     
       @ .equ RESET_io_qspi [6:6]     
       @ .equ RESET_io_bank0 [5:5]     
       @ .equ RESET_i2c1 [4:4]     
       @ .equ RESET_i2c0 [3:3]     
       @ .equ RESET_dma [2:2]     
       @ .equ RESET_busctrl [1:1]     
       @ .equ RESET_adc [0:0]     
 
    .equ RESETS_WDSEL, 0x0004 Watchdog select. If a bit is set then the watchdog will reset this peripheral when the watchdog fires.
       @ .equ WDSEL_usbctrl [24:24]     
       @ .equ WDSEL_uart1 [23:23]     
       @ .equ WDSEL_uart0 [22:22]     
       @ .equ WDSEL_timer [21:21]     
       @ .equ WDSEL_tbman [20:20]     
       @ .equ WDSEL_sysinfo [19:19]     
       @ .equ WDSEL_syscfg [18:18]     
       @ .equ WDSEL_spi1 [17:17]     
       @ .equ WDSEL_spi0 [16:16]     
       @ .equ WDSEL_rtc [15:15]     
       @ .equ WDSEL_pwm [14:14]     
       @ .equ WDSEL_pll_usb [13:13]     
       @ .equ WDSEL_pll_sys [12:12]     
       @ .equ WDSEL_pio1 [11:11]     
       @ .equ WDSEL_pio0 [10:10]     
       @ .equ WDSEL_pads_qspi [9:9]     
       @ .equ WDSEL_pads_bank0 [8:8]     
       @ .equ WDSEL_jtag [7:7]     
       @ .equ WDSEL_io_qspi [6:6]     
       @ .equ WDSEL_io_bank0 [5:5]     
       @ .equ WDSEL_i2c1 [4:4]     
       @ .equ WDSEL_i2c0 [3:3]     
       @ .equ WDSEL_dma [2:2]     
       @ .equ WDSEL_busctrl [1:1]     
       @ .equ WDSEL_adc [0:0]     
 
    .equ RESETS_RESET_DONE, 0x0008 Reset done. If a bit is set then a reset done signal has been returned by the peripheral. This indicates that the peripheral's registers are ready to be accessed.
       @ .equ RESET_DONE_usbctrl [24:24]     
       @ .equ RESET_DONE_uart1 [23:23]     
       @ .equ RESET_DONE_uart0 [22:22]     
       @ .equ RESET_DONE_timer [21:21]     
       @ .equ RESET_DONE_tbman [20:20]     
       @ .equ RESET_DONE_sysinfo [19:19]     
       @ .equ RESET_DONE_syscfg [18:18]     
       @ .equ RESET_DONE_spi1 [17:17]     
       @ .equ RESET_DONE_spi0 [16:16]     
       @ .equ RESET_DONE_rtc [15:15]     
       @ .equ RESET_DONE_pwm [14:14]     
       @ .equ RESET_DONE_pll_usb [13:13]     
       @ .equ RESET_DONE_pll_sys [12:12]     
       @ .equ RESET_DONE_pio1 [11:11]     
       @ .equ RESET_DONE_pio0 [10:10]     
       @ .equ RESET_DONE_pads_qspi [9:9]     
       @ .equ RESET_DONE_pads_bank0 [8:8]     
       @ .equ RESET_DONE_jtag [7:7]     
       @ .equ RESET_DONE_io_qspi [6:6]     
       @ .equ RESET_DONE_io_bank0 [5:5]     
       @ .equ RESET_DONE_i2c1 [4:4]     
       @ .equ RESET_DONE_i2c0 [3:3]     
       @ .equ RESET_DONE_dma [2:2]     
       @ .equ RESET_DONE_busctrl [1:1]     
       @ .equ RESET_DONE_adc [0:0]     
 

@=========================== PSM ===========================@
.equ PSM_BASE, 0x40010000 
    .equ PSM_FRCE_ON, 0x0000 Force block out of reset i.e. power it on
       @ .equ FRCE_ON_proc1 [16:16]     
       @ .equ FRCE_ON_proc0 [15:15]     
       @ .equ FRCE_ON_sio [14:14]     
       @ .equ FRCE_ON_vreg_and_chip_reset [13:13]     
       @ .equ FRCE_ON_xip [12:12]     
       @ .equ FRCE_ON_sram5 [11:11]     
       @ .equ FRCE_ON_sram4 [10:10]     
       @ .equ FRCE_ON_sram3 [9:9]     
       @ .equ FRCE_ON_sram2 [8:8]     
       @ .equ FRCE_ON_sram1 [7:7]     
       @ .equ FRCE_ON_sram0 [6:6]     
       @ .equ FRCE_ON_rom [5:5]     
       @ .equ FRCE_ON_busfabric [4:4]     
       @ .equ FRCE_ON_resets [3:3]     
       @ .equ FRCE_ON_clocks [2:2]     
       @ .equ FRCE_ON_xosc [1:1]     
       @ .equ FRCE_ON_rosc [0:0]     
 
    .equ PSM_FRCE_OFF, 0x0004 Force into reset i.e. power it off
       @ .equ FRCE_OFF_proc1 [16:16]     
       @ .equ FRCE_OFF_proc0 [15:15]     
       @ .equ FRCE_OFF_sio [14:14]     
       @ .equ FRCE_OFF_vreg_and_chip_reset [13:13]     
       @ .equ FRCE_OFF_xip [12:12]     
       @ .equ FRCE_OFF_sram5 [11:11]     
       @ .equ FRCE_OFF_sram4 [10:10]     
       @ .equ FRCE_OFF_sram3 [9:9]     
       @ .equ FRCE_OFF_sram2 [8:8]     
       @ .equ FRCE_OFF_sram1 [7:7]     
       @ .equ FRCE_OFF_sram0 [6:6]     
       @ .equ FRCE_OFF_rom [5:5]     
       @ .equ FRCE_OFF_busfabric [4:4]     
       @ .equ FRCE_OFF_resets [3:3]     
       @ .equ FRCE_OFF_clocks [2:2]     
       @ .equ FRCE_OFF_xosc [1:1]     
       @ .equ FRCE_OFF_rosc [0:0]     
 
    .equ PSM_WDSEL, 0x0008 Set to 1 if this peripheral should be reset when the watchdog fires.
       @ .equ WDSEL_proc1 [16:16]     
       @ .equ WDSEL_proc0 [15:15]     
       @ .equ WDSEL_sio [14:14]     
       @ .equ WDSEL_vreg_and_chip_reset [13:13]     
       @ .equ WDSEL_xip [12:12]     
       @ .equ WDSEL_sram5 [11:11]     
       @ .equ WDSEL_sram4 [10:10]     
       @ .equ WDSEL_sram3 [9:9]     
       @ .equ WDSEL_sram2 [8:8]     
       @ .equ WDSEL_sram1 [7:7]     
       @ .equ WDSEL_sram0 [6:6]     
       @ .equ WDSEL_rom [5:5]     
       @ .equ WDSEL_busfabric [4:4]     
       @ .equ WDSEL_resets [3:3]     
       @ .equ WDSEL_clocks [2:2]     
       @ .equ WDSEL_xosc [1:1]     
       @ .equ WDSEL_rosc [0:0]     
 
    .equ PSM_DONE, 0x000c Indicates the peripheral's registers are ready to access.
       @ .equ DONE_proc1 [16:16]     
       @ .equ DONE_proc0 [15:15]     
       @ .equ DONE_sio [14:14]     
       @ .equ DONE_vreg_and_chip_reset [13:13]     
       @ .equ DONE_xip [12:12]     
       @ .equ DONE_sram5 [11:11]     
       @ .equ DONE_sram4 [10:10]     
       @ .equ DONE_sram3 [9:9]     
       @ .equ DONE_sram2 [8:8]     
       @ .equ DONE_sram1 [7:7]     
       @ .equ DONE_sram0 [6:6]     
       @ .equ DONE_rom [5:5]     
       @ .equ DONE_busfabric [4:4]     
       @ .equ DONE_resets [3:3]     
       @ .equ DONE_clocks [2:2]     
       @ .equ DONE_xosc [1:1]     
       @ .equ DONE_rosc [0:0]     
 

@=========================== IO_BANK0 ===========================@
.equ IO_BANK0_BASE, 0x40014000 
    .equ IO_BANK0_GPIO0_STATUS, 0x0000 GPIO status
       @ .equ GPIO0_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO0_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO0_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO0_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO0_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO0_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO0_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO0_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO0_CTRL, 0x0004 GPIO control including function select and overrides.
       @ .equ GPIO0_CTRL_IRQOVER [29:28]     
       @ .equ GPIO0_CTRL_INOVER [17:16]     
       @ .equ GPIO0_CTRL_OEOVER [13:12]     
       @ .equ GPIO0_CTRL_OUTOVER [9:8]     
       @ .equ GPIO0_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO1_STATUS, 0x0008 GPIO status
       @ .equ GPIO1_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO1_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO1_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO1_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO1_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO1_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO1_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO1_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO1_CTRL, 0x000c GPIO control including function select and overrides.
       @ .equ GPIO1_CTRL_IRQOVER [29:28]     
       @ .equ GPIO1_CTRL_INOVER [17:16]     
       @ .equ GPIO1_CTRL_OEOVER [13:12]     
       @ .equ GPIO1_CTRL_OUTOVER [9:8]     
       @ .equ GPIO1_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO2_STATUS, 0x0010 GPIO status
       @ .equ GPIO2_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO2_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO2_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO2_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO2_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO2_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO2_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO2_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO2_CTRL, 0x0014 GPIO control including function select and overrides.
       @ .equ GPIO2_CTRL_IRQOVER [29:28]     
       @ .equ GPIO2_CTRL_INOVER [17:16]     
       @ .equ GPIO2_CTRL_OEOVER [13:12]     
       @ .equ GPIO2_CTRL_OUTOVER [9:8]     
       @ .equ GPIO2_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO3_STATUS, 0x0018 GPIO status
       @ .equ GPIO3_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO3_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO3_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO3_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO3_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO3_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO3_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO3_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO3_CTRL, 0x001c GPIO control including function select and overrides.
       @ .equ GPIO3_CTRL_IRQOVER [29:28]     
       @ .equ GPIO3_CTRL_INOVER [17:16]     
       @ .equ GPIO3_CTRL_OEOVER [13:12]     
       @ .equ GPIO3_CTRL_OUTOVER [9:8]     
       @ .equ GPIO3_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO4_STATUS, 0x0020 GPIO status
       @ .equ GPIO4_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO4_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO4_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO4_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO4_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO4_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO4_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO4_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO4_CTRL, 0x0024 GPIO control including function select and overrides.
       @ .equ GPIO4_CTRL_IRQOVER [29:28]     
       @ .equ GPIO4_CTRL_INOVER [17:16]     
       @ .equ GPIO4_CTRL_OEOVER [13:12]     
       @ .equ GPIO4_CTRL_OUTOVER [9:8]     
       @ .equ GPIO4_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO5_STATUS, 0x0028 GPIO status
       @ .equ GPIO5_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO5_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO5_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO5_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO5_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO5_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO5_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO5_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO5_CTRL, 0x002c GPIO control including function select and overrides.
       @ .equ GPIO5_CTRL_IRQOVER [29:28]     
       @ .equ GPIO5_CTRL_INOVER [17:16]     
       @ .equ GPIO5_CTRL_OEOVER [13:12]     
       @ .equ GPIO5_CTRL_OUTOVER [9:8]     
       @ .equ GPIO5_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO6_STATUS, 0x0030 GPIO status
       @ .equ GPIO6_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO6_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO6_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO6_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO6_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO6_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO6_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO6_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO6_CTRL, 0x0034 GPIO control including function select and overrides.
       @ .equ GPIO6_CTRL_IRQOVER [29:28]     
       @ .equ GPIO6_CTRL_INOVER [17:16]     
       @ .equ GPIO6_CTRL_OEOVER [13:12]     
       @ .equ GPIO6_CTRL_OUTOVER [9:8]     
       @ .equ GPIO6_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO7_STATUS, 0x0038 GPIO status
       @ .equ GPIO7_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO7_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO7_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO7_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO7_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO7_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO7_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO7_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO7_CTRL, 0x003c GPIO control including function select and overrides.
       @ .equ GPIO7_CTRL_IRQOVER [29:28]     
       @ .equ GPIO7_CTRL_INOVER [17:16]     
       @ .equ GPIO7_CTRL_OEOVER [13:12]     
       @ .equ GPIO7_CTRL_OUTOVER [9:8]     
       @ .equ GPIO7_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO8_STATUS, 0x0040 GPIO status
       @ .equ GPIO8_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO8_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO8_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO8_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO8_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO8_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO8_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO8_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO8_CTRL, 0x0044 GPIO control including function select and overrides.
       @ .equ GPIO8_CTRL_IRQOVER [29:28]     
       @ .equ GPIO8_CTRL_INOVER [17:16]     
       @ .equ GPIO8_CTRL_OEOVER [13:12]     
       @ .equ GPIO8_CTRL_OUTOVER [9:8]     
       @ .equ GPIO8_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO9_STATUS, 0x0048 GPIO status
       @ .equ GPIO9_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO9_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO9_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO9_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO9_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO9_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO9_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO9_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO9_CTRL, 0x004c GPIO control including function select and overrides.
       @ .equ GPIO9_CTRL_IRQOVER [29:28]     
       @ .equ GPIO9_CTRL_INOVER [17:16]     
       @ .equ GPIO9_CTRL_OEOVER [13:12]     
       @ .equ GPIO9_CTRL_OUTOVER [9:8]     
       @ .equ GPIO9_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO10_STATUS, 0x0050 GPIO status
       @ .equ GPIO10_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO10_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO10_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO10_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO10_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO10_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO10_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO10_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO10_CTRL, 0x0054 GPIO control including function select and overrides.
       @ .equ GPIO10_CTRL_IRQOVER [29:28]     
       @ .equ GPIO10_CTRL_INOVER [17:16]     
       @ .equ GPIO10_CTRL_OEOVER [13:12]     
       @ .equ GPIO10_CTRL_OUTOVER [9:8]     
       @ .equ GPIO10_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO11_STATUS, 0x0058 GPIO status
       @ .equ GPIO11_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO11_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO11_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO11_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO11_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO11_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO11_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO11_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO11_CTRL, 0x005c GPIO control including function select and overrides.
       @ .equ GPIO11_CTRL_IRQOVER [29:28]     
       @ .equ GPIO11_CTRL_INOVER [17:16]     
       @ .equ GPIO11_CTRL_OEOVER [13:12]     
       @ .equ GPIO11_CTRL_OUTOVER [9:8]     
       @ .equ GPIO11_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO12_STATUS, 0x0060 GPIO status
       @ .equ GPIO12_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO12_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO12_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO12_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO12_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO12_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO12_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO12_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO12_CTRL, 0x0064 GPIO control including function select and overrides.
       @ .equ GPIO12_CTRL_IRQOVER [29:28]     
       @ .equ GPIO12_CTRL_INOVER [17:16]     
       @ .equ GPIO12_CTRL_OEOVER [13:12]     
       @ .equ GPIO12_CTRL_OUTOVER [9:8]     
       @ .equ GPIO12_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO13_STATUS, 0x0068 GPIO status
       @ .equ GPIO13_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO13_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO13_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO13_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO13_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO13_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO13_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO13_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO13_CTRL, 0x006c GPIO control including function select and overrides.
       @ .equ GPIO13_CTRL_IRQOVER [29:28]     
       @ .equ GPIO13_CTRL_INOVER [17:16]     
       @ .equ GPIO13_CTRL_OEOVER [13:12]     
       @ .equ GPIO13_CTRL_OUTOVER [9:8]     
       @ .equ GPIO13_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO14_STATUS, 0x0070 GPIO status
       @ .equ GPIO14_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO14_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO14_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO14_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO14_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO14_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO14_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO14_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO14_CTRL, 0x0074 GPIO control including function select and overrides.
       @ .equ GPIO14_CTRL_IRQOVER [29:28]     
       @ .equ GPIO14_CTRL_INOVER [17:16]     
       @ .equ GPIO14_CTRL_OEOVER [13:12]     
       @ .equ GPIO14_CTRL_OUTOVER [9:8]     
       @ .equ GPIO14_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO15_STATUS, 0x0078 GPIO status
       @ .equ GPIO15_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO15_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO15_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO15_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO15_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO15_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO15_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO15_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO15_CTRL, 0x007c GPIO control including function select and overrides.
       @ .equ GPIO15_CTRL_IRQOVER [29:28]     
       @ .equ GPIO15_CTRL_INOVER [17:16]     
       @ .equ GPIO15_CTRL_OEOVER [13:12]     
       @ .equ GPIO15_CTRL_OUTOVER [9:8]     
       @ .equ GPIO15_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO16_STATUS, 0x0080 GPIO status
       @ .equ GPIO16_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO16_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO16_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO16_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO16_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO16_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO16_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO16_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO16_CTRL, 0x0084 GPIO control including function select and overrides.
       @ .equ GPIO16_CTRL_IRQOVER [29:28]     
       @ .equ GPIO16_CTRL_INOVER [17:16]     
       @ .equ GPIO16_CTRL_OEOVER [13:12]     
       @ .equ GPIO16_CTRL_OUTOVER [9:8]     
       @ .equ GPIO16_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO17_STATUS, 0x0088 GPIO status
       @ .equ GPIO17_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO17_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO17_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO17_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO17_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO17_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO17_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO17_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO17_CTRL, 0x008c GPIO control including function select and overrides.
       @ .equ GPIO17_CTRL_IRQOVER [29:28]     
       @ .equ GPIO17_CTRL_INOVER [17:16]     
       @ .equ GPIO17_CTRL_OEOVER [13:12]     
       @ .equ GPIO17_CTRL_OUTOVER [9:8]     
       @ .equ GPIO17_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO18_STATUS, 0x0090 GPIO status
       @ .equ GPIO18_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO18_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO18_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO18_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO18_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO18_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO18_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO18_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO18_CTRL, 0x0094 GPIO control including function select and overrides.
       @ .equ GPIO18_CTRL_IRQOVER [29:28]     
       @ .equ GPIO18_CTRL_INOVER [17:16]     
       @ .equ GPIO18_CTRL_OEOVER [13:12]     
       @ .equ GPIO18_CTRL_OUTOVER [9:8]     
       @ .equ GPIO18_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO19_STATUS, 0x0098 GPIO status
       @ .equ GPIO19_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO19_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO19_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO19_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO19_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO19_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO19_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO19_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO19_CTRL, 0x009c GPIO control including function select and overrides.
       @ .equ GPIO19_CTRL_IRQOVER [29:28]     
       @ .equ GPIO19_CTRL_INOVER [17:16]     
       @ .equ GPIO19_CTRL_OEOVER [13:12]     
       @ .equ GPIO19_CTRL_OUTOVER [9:8]     
       @ .equ GPIO19_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO20_STATUS, 0x00a0 GPIO status
       @ .equ GPIO20_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO20_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO20_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO20_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO20_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO20_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO20_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO20_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO20_CTRL, 0x00a4 GPIO control including function select and overrides.
       @ .equ GPIO20_CTRL_IRQOVER [29:28]     
       @ .equ GPIO20_CTRL_INOVER [17:16]     
       @ .equ GPIO20_CTRL_OEOVER [13:12]     
       @ .equ GPIO20_CTRL_OUTOVER [9:8]     
       @ .equ GPIO20_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO21_STATUS, 0x00a8 GPIO status
       @ .equ GPIO21_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO21_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO21_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO21_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO21_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO21_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO21_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO21_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO21_CTRL, 0x00ac GPIO control including function select and overrides.
       @ .equ GPIO21_CTRL_IRQOVER [29:28]     
       @ .equ GPIO21_CTRL_INOVER [17:16]     
       @ .equ GPIO21_CTRL_OEOVER [13:12]     
       @ .equ GPIO21_CTRL_OUTOVER [9:8]     
       @ .equ GPIO21_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO22_STATUS, 0x00b0 GPIO status
       @ .equ GPIO22_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO22_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO22_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO22_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO22_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO22_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO22_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO22_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO22_CTRL, 0x00b4 GPIO control including function select and overrides.
       @ .equ GPIO22_CTRL_IRQOVER [29:28]     
       @ .equ GPIO22_CTRL_INOVER [17:16]     
       @ .equ GPIO22_CTRL_OEOVER [13:12]     
       @ .equ GPIO22_CTRL_OUTOVER [9:8]     
       @ .equ GPIO22_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO23_STATUS, 0x00b8 GPIO status
       @ .equ GPIO23_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO23_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO23_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO23_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO23_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO23_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO23_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO23_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO23_CTRL, 0x00bc GPIO control including function select and overrides.
       @ .equ GPIO23_CTRL_IRQOVER [29:28]     
       @ .equ GPIO23_CTRL_INOVER [17:16]     
       @ .equ GPIO23_CTRL_OEOVER [13:12]     
       @ .equ GPIO23_CTRL_OUTOVER [9:8]     
       @ .equ GPIO23_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO24_STATUS, 0x00c0 GPIO status
       @ .equ GPIO24_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO24_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO24_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO24_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO24_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO24_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO24_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO24_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO24_CTRL, 0x00c4 GPIO control including function select and overrides.
       @ .equ GPIO24_CTRL_IRQOVER [29:28]     
       @ .equ GPIO24_CTRL_INOVER [17:16]     
       @ .equ GPIO24_CTRL_OEOVER [13:12]     
       @ .equ GPIO24_CTRL_OUTOVER [9:8]     
       @ .equ GPIO24_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO25_STATUS, 0x00c8 GPIO status
       @ .equ GPIO25_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO25_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO25_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO25_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO25_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO25_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO25_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO25_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO25_CTRL, 0x00cc GPIO control including function select and overrides.
       @ .equ GPIO25_CTRL_IRQOVER [29:28]     
       @ .equ GPIO25_CTRL_INOVER [17:16]     
       @ .equ GPIO25_CTRL_OEOVER [13:12]     
       @ .equ GPIO25_CTRL_OUTOVER [9:8]     
       @ .equ GPIO25_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO26_STATUS, 0x00d0 GPIO status
       @ .equ GPIO26_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO26_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO26_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO26_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO26_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO26_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO26_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO26_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO26_CTRL, 0x00d4 GPIO control including function select and overrides.
       @ .equ GPIO26_CTRL_IRQOVER [29:28]     
       @ .equ GPIO26_CTRL_INOVER [17:16]     
       @ .equ GPIO26_CTRL_OEOVER [13:12]     
       @ .equ GPIO26_CTRL_OUTOVER [9:8]     
       @ .equ GPIO26_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO27_STATUS, 0x00d8 GPIO status
       @ .equ GPIO27_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO27_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO27_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO27_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO27_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO27_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO27_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO27_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO27_CTRL, 0x00dc GPIO control including function select and overrides.
       @ .equ GPIO27_CTRL_IRQOVER [29:28]     
       @ .equ GPIO27_CTRL_INOVER [17:16]     
       @ .equ GPIO27_CTRL_OEOVER [13:12]     
       @ .equ GPIO27_CTRL_OUTOVER [9:8]     
       @ .equ GPIO27_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO28_STATUS, 0x00e0 GPIO status
       @ .equ GPIO28_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO28_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO28_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO28_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO28_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO28_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO28_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO28_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO28_CTRL, 0x00e4 GPIO control including function select and overrides.
       @ .equ GPIO28_CTRL_IRQOVER [29:28]     
       @ .equ GPIO28_CTRL_INOVER [17:16]     
       @ .equ GPIO28_CTRL_OEOVER [13:12]     
       @ .equ GPIO28_CTRL_OUTOVER [9:8]     
       @ .equ GPIO28_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_GPIO29_STATUS, 0x00e8 GPIO status
       @ .equ GPIO29_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO29_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO29_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO29_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO29_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO29_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO29_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO29_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO29_CTRL, 0x00ec GPIO control including function select and overrides.
       @ .equ GPIO29_CTRL_IRQOVER [29:28]     
       @ .equ GPIO29_CTRL_INOVER [17:16]     
       @ .equ GPIO29_CTRL_OEOVER [13:12]     
       @ .equ GPIO29_CTRL_OUTOVER [9:8]     
       @ .equ GPIO29_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_BANK0_INTR0, 0x00f0 Raw Interrupts
       @ .equ INTR0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ INTR0_GPIO7_EDGE_LOW [30:30]     
       @ .equ INTR0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ INTR0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ INTR0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ INTR0_GPIO6_EDGE_LOW [26:26]     
       @ .equ INTR0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ INTR0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ INTR0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ INTR0_GPIO5_EDGE_LOW [22:22]     
       @ .equ INTR0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ INTR0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ INTR0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ INTR0_GPIO4_EDGE_LOW [18:18]     
       @ .equ INTR0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ INTR0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ INTR0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ INTR0_GPIO3_EDGE_LOW [14:14]     
       @ .equ INTR0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ INTR0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ INTR0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ INTR0_GPIO2_EDGE_LOW [10:10]     
       @ .equ INTR0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ INTR0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ INTR0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ INTR0_GPIO1_EDGE_LOW [6:6]     
       @ .equ INTR0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ INTR0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ INTR0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ INTR0_GPIO0_EDGE_LOW [2:2]     
       @ .equ INTR0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ INTR0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_INTR1, 0x00f4 Raw Interrupts
       @ .equ INTR1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ INTR1_GPIO15_EDGE_LOW [30:30]     
       @ .equ INTR1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ INTR1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ INTR1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ INTR1_GPIO14_EDGE_LOW [26:26]     
       @ .equ INTR1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ INTR1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ INTR1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ INTR1_GPIO13_EDGE_LOW [22:22]     
       @ .equ INTR1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ INTR1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ INTR1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ INTR1_GPIO12_EDGE_LOW [18:18]     
       @ .equ INTR1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ INTR1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ INTR1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ INTR1_GPIO11_EDGE_LOW [14:14]     
       @ .equ INTR1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ INTR1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ INTR1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ INTR1_GPIO10_EDGE_LOW [10:10]     
       @ .equ INTR1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ INTR1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ INTR1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ INTR1_GPIO9_EDGE_LOW [6:6]     
       @ .equ INTR1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ INTR1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ INTR1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ INTR1_GPIO8_EDGE_LOW [2:2]     
       @ .equ INTR1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ INTR1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_INTR2, 0x00f8 Raw Interrupts
       @ .equ INTR2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ INTR2_GPIO23_EDGE_LOW [30:30]     
       @ .equ INTR2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ INTR2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ INTR2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ INTR2_GPIO22_EDGE_LOW [26:26]     
       @ .equ INTR2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ INTR2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ INTR2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ INTR2_GPIO21_EDGE_LOW [22:22]     
       @ .equ INTR2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ INTR2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ INTR2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ INTR2_GPIO20_EDGE_LOW [18:18]     
       @ .equ INTR2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ INTR2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ INTR2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ INTR2_GPIO19_EDGE_LOW [14:14]     
       @ .equ INTR2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ INTR2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ INTR2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ INTR2_GPIO18_EDGE_LOW [10:10]     
       @ .equ INTR2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ INTR2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ INTR2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ INTR2_GPIO17_EDGE_LOW [6:6]     
       @ .equ INTR2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ INTR2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ INTR2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ INTR2_GPIO16_EDGE_LOW [2:2]     
       @ .equ INTR2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ INTR2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_INTR3, 0x00fc Raw Interrupts
       @ .equ INTR3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ INTR3_GPIO29_EDGE_LOW [22:22]     
       @ .equ INTR3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ INTR3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ INTR3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ INTR3_GPIO28_EDGE_LOW [18:18]     
       @ .equ INTR3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ INTR3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ INTR3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ INTR3_GPIO27_EDGE_LOW [14:14]     
       @ .equ INTR3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ INTR3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ INTR3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ INTR3_GPIO26_EDGE_LOW [10:10]     
       @ .equ INTR3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ INTR3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ INTR3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ INTR3_GPIO25_EDGE_LOW [6:6]     
       @ .equ INTR3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ INTR3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ INTR3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ INTR3_GPIO24_EDGE_LOW [2:2]     
       @ .equ INTR3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ INTR3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE0, 0x0100 Interrupt Enable for proc0
       @ .equ PROC0_INTE0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTE0_GPIO7_EDGE_LOW [30:30]     
       @ .equ PROC0_INTE0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTE0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTE0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTE0_GPIO6_EDGE_LOW [26:26]     
       @ .equ PROC0_INTE0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTE0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTE0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTE0_GPIO5_EDGE_LOW [22:22]     
       @ .equ PROC0_INTE0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTE0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTE0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTE0_GPIO4_EDGE_LOW [18:18]     
       @ .equ PROC0_INTE0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTE0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTE0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTE0_GPIO3_EDGE_LOW [14:14]     
       @ .equ PROC0_INTE0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTE0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTE0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTE0_GPIO2_EDGE_LOW [10:10]     
       @ .equ PROC0_INTE0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTE0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTE0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTE0_GPIO1_EDGE_LOW [6:6]     
       @ .equ PROC0_INTE0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTE0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTE0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTE0_GPIO0_EDGE_LOW [2:2]     
       @ .equ PROC0_INTE0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTE0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE1, 0x0104 Interrupt Enable for proc0
       @ .equ PROC0_INTE1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTE1_GPIO15_EDGE_LOW [30:30]     
       @ .equ PROC0_INTE1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTE1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTE1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTE1_GPIO14_EDGE_LOW [26:26]     
       @ .equ PROC0_INTE1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTE1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTE1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTE1_GPIO13_EDGE_LOW [22:22]     
       @ .equ PROC0_INTE1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTE1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTE1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTE1_GPIO12_EDGE_LOW [18:18]     
       @ .equ PROC0_INTE1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTE1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTE1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTE1_GPIO11_EDGE_LOW [14:14]     
       @ .equ PROC0_INTE1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTE1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTE1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTE1_GPIO10_EDGE_LOW [10:10]     
       @ .equ PROC0_INTE1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTE1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTE1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTE1_GPIO9_EDGE_LOW [6:6]     
       @ .equ PROC0_INTE1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTE1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTE1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTE1_GPIO8_EDGE_LOW [2:2]     
       @ .equ PROC0_INTE1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTE1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE2, 0x0108 Interrupt Enable for proc0
       @ .equ PROC0_INTE2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTE2_GPIO23_EDGE_LOW [30:30]     
       @ .equ PROC0_INTE2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTE2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTE2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTE2_GPIO22_EDGE_LOW [26:26]     
       @ .equ PROC0_INTE2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTE2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTE2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTE2_GPIO21_EDGE_LOW [22:22]     
       @ .equ PROC0_INTE2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTE2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTE2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTE2_GPIO20_EDGE_LOW [18:18]     
       @ .equ PROC0_INTE2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTE2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTE2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTE2_GPIO19_EDGE_LOW [14:14]     
       @ .equ PROC0_INTE2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTE2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTE2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTE2_GPIO18_EDGE_LOW [10:10]     
       @ .equ PROC0_INTE2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTE2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTE2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTE2_GPIO17_EDGE_LOW [6:6]     
       @ .equ PROC0_INTE2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTE2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTE2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTE2_GPIO16_EDGE_LOW [2:2]     
       @ .equ PROC0_INTE2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTE2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE3, 0x010c Interrupt Enable for proc0
       @ .equ PROC0_INTE3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTE3_GPIO29_EDGE_LOW [22:22]     
       @ .equ PROC0_INTE3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTE3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTE3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTE3_GPIO28_EDGE_LOW [18:18]     
       @ .equ PROC0_INTE3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTE3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTE3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTE3_GPIO27_EDGE_LOW [14:14]     
       @ .equ PROC0_INTE3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTE3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTE3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTE3_GPIO26_EDGE_LOW [10:10]     
       @ .equ PROC0_INTE3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTE3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTE3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTE3_GPIO25_EDGE_LOW [6:6]     
       @ .equ PROC0_INTE3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTE3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTE3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTE3_GPIO24_EDGE_LOW [2:2]     
       @ .equ PROC0_INTE3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTE3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF0, 0x0110 Interrupt Force for proc0
       @ .equ PROC0_INTF0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTF0_GPIO7_EDGE_LOW [30:30]     
       @ .equ PROC0_INTF0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTF0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTF0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTF0_GPIO6_EDGE_LOW [26:26]     
       @ .equ PROC0_INTF0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTF0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTF0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTF0_GPIO5_EDGE_LOW [22:22]     
       @ .equ PROC0_INTF0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTF0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTF0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTF0_GPIO4_EDGE_LOW [18:18]     
       @ .equ PROC0_INTF0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTF0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTF0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTF0_GPIO3_EDGE_LOW [14:14]     
       @ .equ PROC0_INTF0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTF0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTF0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTF0_GPIO2_EDGE_LOW [10:10]     
       @ .equ PROC0_INTF0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTF0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTF0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTF0_GPIO1_EDGE_LOW [6:6]     
       @ .equ PROC0_INTF0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTF0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTF0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTF0_GPIO0_EDGE_LOW [2:2]     
       @ .equ PROC0_INTF0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTF0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF1, 0x0114 Interrupt Force for proc0
       @ .equ PROC0_INTF1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTF1_GPIO15_EDGE_LOW [30:30]     
       @ .equ PROC0_INTF1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTF1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTF1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTF1_GPIO14_EDGE_LOW [26:26]     
       @ .equ PROC0_INTF1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTF1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTF1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTF1_GPIO13_EDGE_LOW [22:22]     
       @ .equ PROC0_INTF1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTF1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTF1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTF1_GPIO12_EDGE_LOW [18:18]     
       @ .equ PROC0_INTF1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTF1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTF1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTF1_GPIO11_EDGE_LOW [14:14]     
       @ .equ PROC0_INTF1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTF1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTF1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTF1_GPIO10_EDGE_LOW [10:10]     
       @ .equ PROC0_INTF1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTF1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTF1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTF1_GPIO9_EDGE_LOW [6:6]     
       @ .equ PROC0_INTF1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTF1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTF1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTF1_GPIO8_EDGE_LOW [2:2]     
       @ .equ PROC0_INTF1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTF1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF2, 0x0118 Interrupt Force for proc0
       @ .equ PROC0_INTF2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTF2_GPIO23_EDGE_LOW [30:30]     
       @ .equ PROC0_INTF2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTF2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTF2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTF2_GPIO22_EDGE_LOW [26:26]     
       @ .equ PROC0_INTF2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTF2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTF2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTF2_GPIO21_EDGE_LOW [22:22]     
       @ .equ PROC0_INTF2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTF2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTF2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTF2_GPIO20_EDGE_LOW [18:18]     
       @ .equ PROC0_INTF2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTF2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTF2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTF2_GPIO19_EDGE_LOW [14:14]     
       @ .equ PROC0_INTF2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTF2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTF2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTF2_GPIO18_EDGE_LOW [10:10]     
       @ .equ PROC0_INTF2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTF2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTF2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTF2_GPIO17_EDGE_LOW [6:6]     
       @ .equ PROC0_INTF2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTF2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTF2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTF2_GPIO16_EDGE_LOW [2:2]     
       @ .equ PROC0_INTF2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTF2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF3, 0x011c Interrupt Force for proc0
       @ .equ PROC0_INTF3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTF3_GPIO29_EDGE_LOW [22:22]     
       @ .equ PROC0_INTF3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTF3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTF3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTF3_GPIO28_EDGE_LOW [18:18]     
       @ .equ PROC0_INTF3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTF3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTF3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTF3_GPIO27_EDGE_LOW [14:14]     
       @ .equ PROC0_INTF3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTF3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTF3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTF3_GPIO26_EDGE_LOW [10:10]     
       @ .equ PROC0_INTF3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTF3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTF3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTF3_GPIO25_EDGE_LOW [6:6]     
       @ .equ PROC0_INTF3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTF3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTF3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTF3_GPIO24_EDGE_LOW [2:2]     
       @ .equ PROC0_INTF3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTF3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS0, 0x0120 Interrupt status after masking & forcing for proc0
       @ .equ PROC0_INTS0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTS0_GPIO7_EDGE_LOW [30:30]     
       @ .equ PROC0_INTS0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTS0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTS0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTS0_GPIO6_EDGE_LOW [26:26]     
       @ .equ PROC0_INTS0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTS0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTS0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTS0_GPIO5_EDGE_LOW [22:22]     
       @ .equ PROC0_INTS0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTS0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTS0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTS0_GPIO4_EDGE_LOW [18:18]     
       @ .equ PROC0_INTS0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTS0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTS0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTS0_GPIO3_EDGE_LOW [14:14]     
       @ .equ PROC0_INTS0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTS0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTS0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTS0_GPIO2_EDGE_LOW [10:10]     
       @ .equ PROC0_INTS0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTS0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTS0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTS0_GPIO1_EDGE_LOW [6:6]     
       @ .equ PROC0_INTS0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTS0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTS0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTS0_GPIO0_EDGE_LOW [2:2]     
       @ .equ PROC0_INTS0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTS0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS1, 0x0124 Interrupt status after masking & forcing for proc0
       @ .equ PROC0_INTS1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTS1_GPIO15_EDGE_LOW [30:30]     
       @ .equ PROC0_INTS1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTS1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTS1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTS1_GPIO14_EDGE_LOW [26:26]     
       @ .equ PROC0_INTS1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTS1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTS1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTS1_GPIO13_EDGE_LOW [22:22]     
       @ .equ PROC0_INTS1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTS1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTS1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTS1_GPIO12_EDGE_LOW [18:18]     
       @ .equ PROC0_INTS1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTS1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTS1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTS1_GPIO11_EDGE_LOW [14:14]     
       @ .equ PROC0_INTS1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTS1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTS1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTS1_GPIO10_EDGE_LOW [10:10]     
       @ .equ PROC0_INTS1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTS1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTS1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTS1_GPIO9_EDGE_LOW [6:6]     
       @ .equ PROC0_INTS1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTS1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTS1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTS1_GPIO8_EDGE_LOW [2:2]     
       @ .equ PROC0_INTS1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTS1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS2, 0x0128 Interrupt status after masking & forcing for proc0
       @ .equ PROC0_INTS2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ PROC0_INTS2_GPIO23_EDGE_LOW [30:30]     
       @ .equ PROC0_INTS2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ PROC0_INTS2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ PROC0_INTS2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ PROC0_INTS2_GPIO22_EDGE_LOW [26:26]     
       @ .equ PROC0_INTS2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ PROC0_INTS2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ PROC0_INTS2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTS2_GPIO21_EDGE_LOW [22:22]     
       @ .equ PROC0_INTS2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTS2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTS2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTS2_GPIO20_EDGE_LOW [18:18]     
       @ .equ PROC0_INTS2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTS2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTS2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTS2_GPIO19_EDGE_LOW [14:14]     
       @ .equ PROC0_INTS2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTS2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTS2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTS2_GPIO18_EDGE_LOW [10:10]     
       @ .equ PROC0_INTS2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTS2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTS2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTS2_GPIO17_EDGE_LOW [6:6]     
       @ .equ PROC0_INTS2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTS2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTS2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTS2_GPIO16_EDGE_LOW [2:2]     
       @ .equ PROC0_INTS2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTS2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS3, 0x012c Interrupt status after masking & forcing for proc0
       @ .equ PROC0_INTS3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTS3_GPIO29_EDGE_LOW [22:22]     
       @ .equ PROC0_INTS3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTS3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTS3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTS3_GPIO28_EDGE_LOW [18:18]     
       @ .equ PROC0_INTS3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTS3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTS3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTS3_GPIO27_EDGE_LOW [14:14]     
       @ .equ PROC0_INTS3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTS3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTS3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTS3_GPIO26_EDGE_LOW [10:10]     
       @ .equ PROC0_INTS3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTS3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTS3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTS3_GPIO25_EDGE_LOW [6:6]     
       @ .equ PROC0_INTS3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTS3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTS3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTS3_GPIO24_EDGE_LOW [2:2]     
       @ .equ PROC0_INTS3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTS3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE0, 0x0130 Interrupt Enable for proc1
       @ .equ PROC1_INTE0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTE0_GPIO7_EDGE_LOW [30:30]     
       @ .equ PROC1_INTE0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTE0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTE0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTE0_GPIO6_EDGE_LOW [26:26]     
       @ .equ PROC1_INTE0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTE0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTE0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTE0_GPIO5_EDGE_LOW [22:22]     
       @ .equ PROC1_INTE0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTE0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTE0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTE0_GPIO4_EDGE_LOW [18:18]     
       @ .equ PROC1_INTE0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTE0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTE0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTE0_GPIO3_EDGE_LOW [14:14]     
       @ .equ PROC1_INTE0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTE0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTE0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTE0_GPIO2_EDGE_LOW [10:10]     
       @ .equ PROC1_INTE0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTE0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTE0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTE0_GPIO1_EDGE_LOW [6:6]     
       @ .equ PROC1_INTE0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTE0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTE0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTE0_GPIO0_EDGE_LOW [2:2]     
       @ .equ PROC1_INTE0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTE0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE1, 0x0134 Interrupt Enable for proc1
       @ .equ PROC1_INTE1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTE1_GPIO15_EDGE_LOW [30:30]     
       @ .equ PROC1_INTE1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTE1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTE1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTE1_GPIO14_EDGE_LOW [26:26]     
       @ .equ PROC1_INTE1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTE1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTE1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTE1_GPIO13_EDGE_LOW [22:22]     
       @ .equ PROC1_INTE1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTE1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTE1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTE1_GPIO12_EDGE_LOW [18:18]     
       @ .equ PROC1_INTE1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTE1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTE1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTE1_GPIO11_EDGE_LOW [14:14]     
       @ .equ PROC1_INTE1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTE1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTE1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTE1_GPIO10_EDGE_LOW [10:10]     
       @ .equ PROC1_INTE1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTE1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTE1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTE1_GPIO9_EDGE_LOW [6:6]     
       @ .equ PROC1_INTE1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTE1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTE1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTE1_GPIO8_EDGE_LOW [2:2]     
       @ .equ PROC1_INTE1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTE1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE2, 0x0138 Interrupt Enable for proc1
       @ .equ PROC1_INTE2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTE2_GPIO23_EDGE_LOW [30:30]     
       @ .equ PROC1_INTE2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTE2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTE2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTE2_GPIO22_EDGE_LOW [26:26]     
       @ .equ PROC1_INTE2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTE2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTE2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTE2_GPIO21_EDGE_LOW [22:22]     
       @ .equ PROC1_INTE2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTE2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTE2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTE2_GPIO20_EDGE_LOW [18:18]     
       @ .equ PROC1_INTE2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTE2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTE2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTE2_GPIO19_EDGE_LOW [14:14]     
       @ .equ PROC1_INTE2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTE2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTE2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTE2_GPIO18_EDGE_LOW [10:10]     
       @ .equ PROC1_INTE2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTE2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTE2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTE2_GPIO17_EDGE_LOW [6:6]     
       @ .equ PROC1_INTE2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTE2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTE2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTE2_GPIO16_EDGE_LOW [2:2]     
       @ .equ PROC1_INTE2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTE2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE3, 0x013c Interrupt Enable for proc1
       @ .equ PROC1_INTE3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTE3_GPIO29_EDGE_LOW [22:22]     
       @ .equ PROC1_INTE3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTE3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTE3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTE3_GPIO28_EDGE_LOW [18:18]     
       @ .equ PROC1_INTE3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTE3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTE3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTE3_GPIO27_EDGE_LOW [14:14]     
       @ .equ PROC1_INTE3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTE3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTE3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTE3_GPIO26_EDGE_LOW [10:10]     
       @ .equ PROC1_INTE3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTE3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTE3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTE3_GPIO25_EDGE_LOW [6:6]     
       @ .equ PROC1_INTE3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTE3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTE3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTE3_GPIO24_EDGE_LOW [2:2]     
       @ .equ PROC1_INTE3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTE3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF0, 0x0140 Interrupt Force for proc1
       @ .equ PROC1_INTF0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTF0_GPIO7_EDGE_LOW [30:30]     
       @ .equ PROC1_INTF0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTF0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTF0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTF0_GPIO6_EDGE_LOW [26:26]     
       @ .equ PROC1_INTF0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTF0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTF0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTF0_GPIO5_EDGE_LOW [22:22]     
       @ .equ PROC1_INTF0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTF0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTF0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTF0_GPIO4_EDGE_LOW [18:18]     
       @ .equ PROC1_INTF0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTF0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTF0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTF0_GPIO3_EDGE_LOW [14:14]     
       @ .equ PROC1_INTF0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTF0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTF0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTF0_GPIO2_EDGE_LOW [10:10]     
       @ .equ PROC1_INTF0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTF0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTF0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTF0_GPIO1_EDGE_LOW [6:6]     
       @ .equ PROC1_INTF0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTF0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTF0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTF0_GPIO0_EDGE_LOW [2:2]     
       @ .equ PROC1_INTF0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTF0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF1, 0x0144 Interrupt Force for proc1
       @ .equ PROC1_INTF1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTF1_GPIO15_EDGE_LOW [30:30]     
       @ .equ PROC1_INTF1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTF1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTF1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTF1_GPIO14_EDGE_LOW [26:26]     
       @ .equ PROC1_INTF1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTF1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTF1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTF1_GPIO13_EDGE_LOW [22:22]     
       @ .equ PROC1_INTF1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTF1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTF1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTF1_GPIO12_EDGE_LOW [18:18]     
       @ .equ PROC1_INTF1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTF1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTF1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTF1_GPIO11_EDGE_LOW [14:14]     
       @ .equ PROC1_INTF1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTF1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTF1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTF1_GPIO10_EDGE_LOW [10:10]     
       @ .equ PROC1_INTF1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTF1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTF1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTF1_GPIO9_EDGE_LOW [6:6]     
       @ .equ PROC1_INTF1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTF1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTF1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTF1_GPIO8_EDGE_LOW [2:2]     
       @ .equ PROC1_INTF1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTF1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF2, 0x0148 Interrupt Force for proc1
       @ .equ PROC1_INTF2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTF2_GPIO23_EDGE_LOW [30:30]     
       @ .equ PROC1_INTF2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTF2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTF2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTF2_GPIO22_EDGE_LOW [26:26]     
       @ .equ PROC1_INTF2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTF2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTF2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTF2_GPIO21_EDGE_LOW [22:22]     
       @ .equ PROC1_INTF2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTF2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTF2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTF2_GPIO20_EDGE_LOW [18:18]     
       @ .equ PROC1_INTF2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTF2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTF2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTF2_GPIO19_EDGE_LOW [14:14]     
       @ .equ PROC1_INTF2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTF2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTF2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTF2_GPIO18_EDGE_LOW [10:10]     
       @ .equ PROC1_INTF2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTF2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTF2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTF2_GPIO17_EDGE_LOW [6:6]     
       @ .equ PROC1_INTF2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTF2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTF2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTF2_GPIO16_EDGE_LOW [2:2]     
       @ .equ PROC1_INTF2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTF2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF3, 0x014c Interrupt Force for proc1
       @ .equ PROC1_INTF3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTF3_GPIO29_EDGE_LOW [22:22]     
       @ .equ PROC1_INTF3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTF3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTF3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTF3_GPIO28_EDGE_LOW [18:18]     
       @ .equ PROC1_INTF3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTF3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTF3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTF3_GPIO27_EDGE_LOW [14:14]     
       @ .equ PROC1_INTF3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTF3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTF3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTF3_GPIO26_EDGE_LOW [10:10]     
       @ .equ PROC1_INTF3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTF3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTF3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTF3_GPIO25_EDGE_LOW [6:6]     
       @ .equ PROC1_INTF3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTF3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTF3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTF3_GPIO24_EDGE_LOW [2:2]     
       @ .equ PROC1_INTF3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTF3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS0, 0x0150 Interrupt status after masking & forcing for proc1
       @ .equ PROC1_INTS0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTS0_GPIO7_EDGE_LOW [30:30]     
       @ .equ PROC1_INTS0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTS0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTS0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTS0_GPIO6_EDGE_LOW [26:26]     
       @ .equ PROC1_INTS0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTS0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTS0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTS0_GPIO5_EDGE_LOW [22:22]     
       @ .equ PROC1_INTS0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTS0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTS0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTS0_GPIO4_EDGE_LOW [18:18]     
       @ .equ PROC1_INTS0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTS0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTS0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTS0_GPIO3_EDGE_LOW [14:14]     
       @ .equ PROC1_INTS0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTS0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTS0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTS0_GPIO2_EDGE_LOW [10:10]     
       @ .equ PROC1_INTS0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTS0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTS0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTS0_GPIO1_EDGE_LOW [6:6]     
       @ .equ PROC1_INTS0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTS0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTS0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTS0_GPIO0_EDGE_LOW [2:2]     
       @ .equ PROC1_INTS0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTS0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS1, 0x0154 Interrupt status after masking & forcing for proc1
       @ .equ PROC1_INTS1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTS1_GPIO15_EDGE_LOW [30:30]     
       @ .equ PROC1_INTS1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTS1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTS1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTS1_GPIO14_EDGE_LOW [26:26]     
       @ .equ PROC1_INTS1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTS1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTS1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTS1_GPIO13_EDGE_LOW [22:22]     
       @ .equ PROC1_INTS1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTS1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTS1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTS1_GPIO12_EDGE_LOW [18:18]     
       @ .equ PROC1_INTS1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTS1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTS1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTS1_GPIO11_EDGE_LOW [14:14]     
       @ .equ PROC1_INTS1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTS1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTS1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTS1_GPIO10_EDGE_LOW [10:10]     
       @ .equ PROC1_INTS1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTS1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTS1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTS1_GPIO9_EDGE_LOW [6:6]     
       @ .equ PROC1_INTS1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTS1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTS1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTS1_GPIO8_EDGE_LOW [2:2]     
       @ .equ PROC1_INTS1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTS1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS2, 0x0158 Interrupt status after masking & forcing for proc1
       @ .equ PROC1_INTS2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ PROC1_INTS2_GPIO23_EDGE_LOW [30:30]     
       @ .equ PROC1_INTS2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ PROC1_INTS2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ PROC1_INTS2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ PROC1_INTS2_GPIO22_EDGE_LOW [26:26]     
       @ .equ PROC1_INTS2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ PROC1_INTS2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ PROC1_INTS2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTS2_GPIO21_EDGE_LOW [22:22]     
       @ .equ PROC1_INTS2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTS2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTS2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTS2_GPIO20_EDGE_LOW [18:18]     
       @ .equ PROC1_INTS2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTS2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTS2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTS2_GPIO19_EDGE_LOW [14:14]     
       @ .equ PROC1_INTS2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTS2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTS2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTS2_GPIO18_EDGE_LOW [10:10]     
       @ .equ PROC1_INTS2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTS2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTS2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTS2_GPIO17_EDGE_LOW [6:6]     
       @ .equ PROC1_INTS2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTS2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTS2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTS2_GPIO16_EDGE_LOW [2:2]     
       @ .equ PROC1_INTS2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTS2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS3, 0x015c Interrupt status after masking & forcing for proc1
       @ .equ PROC1_INTS3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTS3_GPIO29_EDGE_LOW [22:22]     
       @ .equ PROC1_INTS3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTS3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTS3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTS3_GPIO28_EDGE_LOW [18:18]     
       @ .equ PROC1_INTS3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTS3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTS3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTS3_GPIO27_EDGE_LOW [14:14]     
       @ .equ PROC1_INTS3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTS3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTS3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTS3_GPIO26_EDGE_LOW [10:10]     
       @ .equ PROC1_INTS3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTS3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTS3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTS3_GPIO25_EDGE_LOW [6:6]     
       @ .equ PROC1_INTS3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTS3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTS3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTS3_GPIO24_EDGE_LOW [2:2]     
       @ .equ PROC1_INTS3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTS3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE0, 0x0160 Interrupt Enable for dormant_wake
       @ .equ DORMANT_WAKE_INTE0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTE0_GPIO7_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTE0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTE0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTE0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTE0_GPIO6_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTE0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTE0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTE0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTE0_GPIO5_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTE0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTE0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTE0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTE0_GPIO4_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTE0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTE0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTE0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTE0_GPIO3_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTE0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTE0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTE0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTE0_GPIO2_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTE0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTE0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTE0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTE0_GPIO1_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTE0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTE0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTE0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTE0_GPIO0_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTE0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTE0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE1, 0x0164 Interrupt Enable for dormant_wake
       @ .equ DORMANT_WAKE_INTE1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTE1_GPIO15_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTE1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTE1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTE1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTE1_GPIO14_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTE1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTE1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTE1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTE1_GPIO13_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTE1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTE1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTE1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTE1_GPIO12_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTE1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTE1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTE1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTE1_GPIO11_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTE1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTE1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTE1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTE1_GPIO10_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTE1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTE1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTE1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTE1_GPIO9_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTE1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTE1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTE1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTE1_GPIO8_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTE1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTE1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE2, 0x0168 Interrupt Enable for dormant_wake
       @ .equ DORMANT_WAKE_INTE2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTE2_GPIO23_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTE2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTE2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTE2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTE2_GPIO22_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTE2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTE2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTE2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTE2_GPIO21_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTE2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTE2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTE2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTE2_GPIO20_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTE2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTE2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTE2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTE2_GPIO19_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTE2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTE2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTE2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTE2_GPIO18_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTE2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTE2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTE2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTE2_GPIO17_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTE2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTE2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTE2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTE2_GPIO16_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTE2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTE2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE3, 0x016c Interrupt Enable for dormant_wake
       @ .equ DORMANT_WAKE_INTE3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTE3_GPIO29_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTE3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTE3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTE3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTE3_GPIO28_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTE3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTE3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTE3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTE3_GPIO27_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTE3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTE3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTE3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTE3_GPIO26_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTE3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTE3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTE3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTE3_GPIO25_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTE3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTE3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTE3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTE3_GPIO24_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTE3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTE3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF0, 0x0170 Interrupt Force for dormant_wake
       @ .equ DORMANT_WAKE_INTF0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTF0_GPIO7_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTF0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTF0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTF0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTF0_GPIO6_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTF0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTF0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTF0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTF0_GPIO5_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTF0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTF0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTF0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTF0_GPIO4_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTF0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTF0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTF0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTF0_GPIO3_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTF0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTF0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTF0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTF0_GPIO2_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTF0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTF0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTF0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTF0_GPIO1_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTF0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTF0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTF0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTF0_GPIO0_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTF0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTF0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF1, 0x0174 Interrupt Force for dormant_wake
       @ .equ DORMANT_WAKE_INTF1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTF1_GPIO15_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTF1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTF1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTF1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTF1_GPIO14_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTF1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTF1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTF1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTF1_GPIO13_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTF1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTF1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTF1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTF1_GPIO12_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTF1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTF1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTF1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTF1_GPIO11_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTF1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTF1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTF1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTF1_GPIO10_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTF1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTF1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTF1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTF1_GPIO9_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTF1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTF1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTF1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTF1_GPIO8_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTF1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTF1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF2, 0x0178 Interrupt Force for dormant_wake
       @ .equ DORMANT_WAKE_INTF2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTF2_GPIO23_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTF2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTF2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTF2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTF2_GPIO22_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTF2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTF2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTF2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTF2_GPIO21_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTF2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTF2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTF2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTF2_GPIO20_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTF2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTF2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTF2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTF2_GPIO19_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTF2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTF2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTF2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTF2_GPIO18_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTF2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTF2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTF2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTF2_GPIO17_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTF2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTF2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTF2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTF2_GPIO16_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTF2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTF2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF3, 0x017c Interrupt Force for dormant_wake
       @ .equ DORMANT_WAKE_INTF3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTF3_GPIO29_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTF3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTF3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTF3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTF3_GPIO28_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTF3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTF3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTF3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTF3_GPIO27_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTF3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTF3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTF3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTF3_GPIO26_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTF3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTF3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTF3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTF3_GPIO25_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTF3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTF3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTF3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTF3_GPIO24_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTF3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTF3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS0, 0x0180 Interrupt status after masking & forcing for dormant_wake
       @ .equ DORMANT_WAKE_INTS0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTS0_GPIO7_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTS0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTS0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTS0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTS0_GPIO6_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTS0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTS0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTS0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTS0_GPIO5_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTS0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTS0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTS0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTS0_GPIO4_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTS0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTS0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTS0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTS0_GPIO3_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTS0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTS0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTS0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTS0_GPIO2_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTS0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTS0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTS0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTS0_GPIO1_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTS0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTS0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTS0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTS0_GPIO0_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTS0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTS0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS1, 0x0184 Interrupt status after masking & forcing for dormant_wake
       @ .equ DORMANT_WAKE_INTS1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTS1_GPIO15_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTS1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTS1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTS1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTS1_GPIO14_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTS1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTS1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTS1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTS1_GPIO13_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTS1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTS1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTS1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTS1_GPIO12_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTS1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTS1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTS1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTS1_GPIO11_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTS1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTS1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTS1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTS1_GPIO10_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTS1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTS1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTS1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTS1_GPIO9_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTS1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTS1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTS1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTS1_GPIO8_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTS1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTS1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS2, 0x0188 Interrupt status after masking & forcing for dormant_wake
       @ .equ DORMANT_WAKE_INTS2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ DORMANT_WAKE_INTS2_GPIO23_EDGE_LOW [30:30]     
       @ .equ DORMANT_WAKE_INTS2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ DORMANT_WAKE_INTS2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ DORMANT_WAKE_INTS2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ DORMANT_WAKE_INTS2_GPIO22_EDGE_LOW [26:26]     
       @ .equ DORMANT_WAKE_INTS2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ DORMANT_WAKE_INTS2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ DORMANT_WAKE_INTS2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTS2_GPIO21_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTS2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTS2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTS2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTS2_GPIO20_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTS2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTS2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTS2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTS2_GPIO19_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTS2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTS2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTS2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTS2_GPIO18_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTS2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTS2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTS2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTS2_GPIO17_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTS2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTS2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTS2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTS2_GPIO16_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTS2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTS2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS3, 0x018c Interrupt status after masking & forcing for dormant_wake
       @ .equ DORMANT_WAKE_INTS3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTS3_GPIO29_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTS3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTS3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTS3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTS3_GPIO28_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTS3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTS3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTS3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTS3_GPIO27_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTS3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTS3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTS3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTS3_GPIO26_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTS3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTS3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTS3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTS3_GPIO25_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTS3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTS3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTS3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTS3_GPIO24_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTS3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTS3_GPIO24_LEVEL_LOW [0:0]     
 

@=========================== IO_QSPI ===========================@
.equ IO_QSPI_BASE, 0x40018000 
    .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS, 0x0000 GPIO status
       @ .equ GPIO_QSPI_SCLK_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO_QSPI_SCLK_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL, 0x0004 GPIO control including function select and overrides.
       @ .equ GPIO_QSPI_SCLK_CTRL_IRQOVER [29:28]     
       @ .equ GPIO_QSPI_SCLK_CTRL_INOVER [17:16]     
       @ .equ GPIO_QSPI_SCLK_CTRL_OEOVER [13:12]     
       @ .equ GPIO_QSPI_SCLK_CTRL_OUTOVER [9:8]     
       @ .equ GPIO_QSPI_SCLK_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SS_STATUS, 0x0008 GPIO status
       @ .equ GPIO_QSPI_SS_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO_QSPI_SS_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SS_CTRL, 0x000c GPIO control including function select and overrides.
       @ .equ GPIO_QSPI_SS_CTRL_IRQOVER [29:28]     
       @ .equ GPIO_QSPI_SS_CTRL_INOVER [17:16]     
       @ .equ GPIO_QSPI_SS_CTRL_OEOVER [13:12]     
       @ .equ GPIO_QSPI_SS_CTRL_OUTOVER [9:8]     
       @ .equ GPIO_QSPI_SS_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD0_STATUS, 0x0010 GPIO status
       @ .equ GPIO_QSPI_SD0_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO_QSPI_SD0_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD0_CTRL, 0x0014 GPIO control including function select and overrides.
       @ .equ GPIO_QSPI_SD0_CTRL_IRQOVER [29:28]     
       @ .equ GPIO_QSPI_SD0_CTRL_INOVER [17:16]     
       @ .equ GPIO_QSPI_SD0_CTRL_OEOVER [13:12]     
       @ .equ GPIO_QSPI_SD0_CTRL_OUTOVER [9:8]     
       @ .equ GPIO_QSPI_SD0_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD1_STATUS, 0x0018 GPIO status
       @ .equ GPIO_QSPI_SD1_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO_QSPI_SD1_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD1_CTRL, 0x001c GPIO control including function select and overrides.
       @ .equ GPIO_QSPI_SD1_CTRL_IRQOVER [29:28]     
       @ .equ GPIO_QSPI_SD1_CTRL_INOVER [17:16]     
       @ .equ GPIO_QSPI_SD1_CTRL_OEOVER [13:12]     
       @ .equ GPIO_QSPI_SD1_CTRL_OUTOVER [9:8]     
       @ .equ GPIO_QSPI_SD1_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD2_STATUS, 0x0020 GPIO status
       @ .equ GPIO_QSPI_SD2_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO_QSPI_SD2_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD2_CTRL, 0x0024 GPIO control including function select and overrides.
       @ .equ GPIO_QSPI_SD2_CTRL_IRQOVER [29:28]     
       @ .equ GPIO_QSPI_SD2_CTRL_INOVER [17:16]     
       @ .equ GPIO_QSPI_SD2_CTRL_OEOVER [13:12]     
       @ .equ GPIO_QSPI_SD2_CTRL_OUTOVER [9:8]     
       @ .equ GPIO_QSPI_SD2_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD3_STATUS, 0x0028 GPIO status
       @ .equ GPIO_QSPI_SD3_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ GPIO_QSPI_SD3_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD3_CTRL, 0x002c GPIO control including function select and overrides.
       @ .equ GPIO_QSPI_SD3_CTRL_IRQOVER [29:28]     
       @ .equ GPIO_QSPI_SD3_CTRL_INOVER [17:16]     
       @ .equ GPIO_QSPI_SD3_CTRL_OEOVER [13:12]     
       @ .equ GPIO_QSPI_SD3_CTRL_OUTOVER [9:8]     
       @ .equ GPIO_QSPI_SD3_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table  31 == NULL 
 
    .equ IO_QSPI_INTR, 0x0030 Raw Interrupts
       @ .equ INTR_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ INTR_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ INTR_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ INTR_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ INTR_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ INTR_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ INTR_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ INTR_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ INTR_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ INTR_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ INTR_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ INTR_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ INTR_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ INTR_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ INTR_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ INTR_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ INTR_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ INTR_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ INTR_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ INTR_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ INTR_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ INTR_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ INTR_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ INTR_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC0_INTE, 0x0034 Interrupt Enable for proc0
       @ .equ PROC0_INTE_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTE_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTE_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTE_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ PROC0_INTE_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTE_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTE_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTE_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ PROC0_INTE_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTE_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC0_INTF, 0x0038 Interrupt Force for proc0
       @ .equ PROC0_INTF_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTF_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTF_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTF_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ PROC0_INTF_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTF_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTF_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTF_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ PROC0_INTF_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTF_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC0_INTS, 0x003c Interrupt status after masking & forcing for proc0
       @ .equ PROC0_INTS_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ PROC0_INTS_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ PROC0_INTS_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ PROC0_INTS_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ PROC0_INTS_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ PROC0_INTS_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ PROC0_INTS_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ PROC0_INTS_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ PROC0_INTS_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ PROC0_INTS_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC1_INTE, 0x0040 Interrupt Enable for proc1
       @ .equ PROC1_INTE_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTE_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTE_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTE_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ PROC1_INTE_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTE_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTE_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTE_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ PROC1_INTE_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTE_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC1_INTF, 0x0044 Interrupt Force for proc1
       @ .equ PROC1_INTF_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTF_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTF_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTF_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ PROC1_INTF_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTF_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTF_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTF_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ PROC1_INTF_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTF_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC1_INTS, 0x0048 Interrupt status after masking & forcing for proc1
       @ .equ PROC1_INTS_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ PROC1_INTS_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ PROC1_INTS_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ PROC1_INTS_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ PROC1_INTS_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ PROC1_INTS_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ PROC1_INTS_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ PROC1_INTS_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ PROC1_INTS_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ PROC1_INTS_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_DORMANT_WAKE_INTE, 0x004c Interrupt Enable for dormant_wake
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_DORMANT_WAKE_INTF, 0x0050 Interrupt Force for dormant_wake
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_DORMANT_WAKE_INTS, 0x0054 Interrupt status after masking & forcing for dormant_wake
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 

@=========================== PADS_BANK0 ===========================@
.equ PADS_BANK0_BASE, 0x4001c000 
    .equ PADS_BANK0_VOLTAGE_SELECT, 0x0000 Voltage select. Per bank control
       @ .equ VOLTAGE_SELECT_VOLTAGE_SELECT [0:0]     
 
    .equ PADS_BANK0_GPIO0, 0x0004 Pad control register
       @ .equ GPIO0_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO0_IE [6:6]    Input enable 
       @ .equ GPIO0_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO0_PUE [3:3]    Pull up enable 
       @ .equ GPIO0_PDE [2:2]    Pull down enable 
       @ .equ GPIO0_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO0_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO1, 0x0008 Pad control register
       @ .equ GPIO1_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO1_IE [6:6]    Input enable 
       @ .equ GPIO1_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO1_PUE [3:3]    Pull up enable 
       @ .equ GPIO1_PDE [2:2]    Pull down enable 
       @ .equ GPIO1_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO1_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO2, 0x000c Pad control register
       @ .equ GPIO2_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO2_IE [6:6]    Input enable 
       @ .equ GPIO2_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO2_PUE [3:3]    Pull up enable 
       @ .equ GPIO2_PDE [2:2]    Pull down enable 
       @ .equ GPIO2_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO2_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO3, 0x0010 Pad control register
       @ .equ GPIO3_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO3_IE [6:6]    Input enable 
       @ .equ GPIO3_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO3_PUE [3:3]    Pull up enable 
       @ .equ GPIO3_PDE [2:2]    Pull down enable 
       @ .equ GPIO3_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO3_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO4, 0x0014 Pad control register
       @ .equ GPIO4_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO4_IE [6:6]    Input enable 
       @ .equ GPIO4_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO4_PUE [3:3]    Pull up enable 
       @ .equ GPIO4_PDE [2:2]    Pull down enable 
       @ .equ GPIO4_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO4_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO5, 0x0018 Pad control register
       @ .equ GPIO5_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO5_IE [6:6]    Input enable 
       @ .equ GPIO5_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO5_PUE [3:3]    Pull up enable 
       @ .equ GPIO5_PDE [2:2]    Pull down enable 
       @ .equ GPIO5_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO5_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO6, 0x001c Pad control register
       @ .equ GPIO6_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO6_IE [6:6]    Input enable 
       @ .equ GPIO6_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO6_PUE [3:3]    Pull up enable 
       @ .equ GPIO6_PDE [2:2]    Pull down enable 
       @ .equ GPIO6_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO6_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO7, 0x0020 Pad control register
       @ .equ GPIO7_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO7_IE [6:6]    Input enable 
       @ .equ GPIO7_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO7_PUE [3:3]    Pull up enable 
       @ .equ GPIO7_PDE [2:2]    Pull down enable 
       @ .equ GPIO7_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO7_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO8, 0x0024 Pad control register
       @ .equ GPIO8_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO8_IE [6:6]    Input enable 
       @ .equ GPIO8_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO8_PUE [3:3]    Pull up enable 
       @ .equ GPIO8_PDE [2:2]    Pull down enable 
       @ .equ GPIO8_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO8_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO9, 0x0028 Pad control register
       @ .equ GPIO9_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO9_IE [6:6]    Input enable 
       @ .equ GPIO9_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO9_PUE [3:3]    Pull up enable 
       @ .equ GPIO9_PDE [2:2]    Pull down enable 
       @ .equ GPIO9_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO9_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO10, 0x002c Pad control register
       @ .equ GPIO10_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO10_IE [6:6]    Input enable 
       @ .equ GPIO10_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO10_PUE [3:3]    Pull up enable 
       @ .equ GPIO10_PDE [2:2]    Pull down enable 
       @ .equ GPIO10_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO10_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO11, 0x0030 Pad control register
       @ .equ GPIO11_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO11_IE [6:6]    Input enable 
       @ .equ GPIO11_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO11_PUE [3:3]    Pull up enable 
       @ .equ GPIO11_PDE [2:2]    Pull down enable 
       @ .equ GPIO11_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO11_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO12, 0x0034 Pad control register
       @ .equ GPIO12_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO12_IE [6:6]    Input enable 
       @ .equ GPIO12_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO12_PUE [3:3]    Pull up enable 
       @ .equ GPIO12_PDE [2:2]    Pull down enable 
       @ .equ GPIO12_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO12_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO13, 0x0038 Pad control register
       @ .equ GPIO13_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO13_IE [6:6]    Input enable 
       @ .equ GPIO13_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO13_PUE [3:3]    Pull up enable 
       @ .equ GPIO13_PDE [2:2]    Pull down enable 
       @ .equ GPIO13_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO13_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO14, 0x003c Pad control register
       @ .equ GPIO14_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO14_IE [6:6]    Input enable 
       @ .equ GPIO14_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO14_PUE [3:3]    Pull up enable 
       @ .equ GPIO14_PDE [2:2]    Pull down enable 
       @ .equ GPIO14_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO14_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO15, 0x0040 Pad control register
       @ .equ GPIO15_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO15_IE [6:6]    Input enable 
       @ .equ GPIO15_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO15_PUE [3:3]    Pull up enable 
       @ .equ GPIO15_PDE [2:2]    Pull down enable 
       @ .equ GPIO15_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO15_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO16, 0x0044 Pad control register
       @ .equ GPIO16_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO16_IE [6:6]    Input enable 
       @ .equ GPIO16_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO16_PUE [3:3]    Pull up enable 
       @ .equ GPIO16_PDE [2:2]    Pull down enable 
       @ .equ GPIO16_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO16_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO17, 0x0048 Pad control register
       @ .equ GPIO17_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO17_IE [6:6]    Input enable 
       @ .equ GPIO17_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO17_PUE [3:3]    Pull up enable 
       @ .equ GPIO17_PDE [2:2]    Pull down enable 
       @ .equ GPIO17_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO17_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO18, 0x004c Pad control register
       @ .equ GPIO18_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO18_IE [6:6]    Input enable 
       @ .equ GPIO18_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO18_PUE [3:3]    Pull up enable 
       @ .equ GPIO18_PDE [2:2]    Pull down enable 
       @ .equ GPIO18_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO18_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO19, 0x0050 Pad control register
       @ .equ GPIO19_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO19_IE [6:6]    Input enable 
       @ .equ GPIO19_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO19_PUE [3:3]    Pull up enable 
       @ .equ GPIO19_PDE [2:2]    Pull down enable 
       @ .equ GPIO19_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO19_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO20, 0x0054 Pad control register
       @ .equ GPIO20_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO20_IE [6:6]    Input enable 
       @ .equ GPIO20_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO20_PUE [3:3]    Pull up enable 
       @ .equ GPIO20_PDE [2:2]    Pull down enable 
       @ .equ GPIO20_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO20_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO21, 0x0058 Pad control register
       @ .equ GPIO21_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO21_IE [6:6]    Input enable 
       @ .equ GPIO21_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO21_PUE [3:3]    Pull up enable 
       @ .equ GPIO21_PDE [2:2]    Pull down enable 
       @ .equ GPIO21_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO21_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO22, 0x005c Pad control register
       @ .equ GPIO22_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO22_IE [6:6]    Input enable 
       @ .equ GPIO22_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO22_PUE [3:3]    Pull up enable 
       @ .equ GPIO22_PDE [2:2]    Pull down enable 
       @ .equ GPIO22_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO22_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO23, 0x0060 Pad control register
       @ .equ GPIO23_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO23_IE [6:6]    Input enable 
       @ .equ GPIO23_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO23_PUE [3:3]    Pull up enable 
       @ .equ GPIO23_PDE [2:2]    Pull down enable 
       @ .equ GPIO23_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO23_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO24, 0x0064 Pad control register
       @ .equ GPIO24_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO24_IE [6:6]    Input enable 
       @ .equ GPIO24_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO24_PUE [3:3]    Pull up enable 
       @ .equ GPIO24_PDE [2:2]    Pull down enable 
       @ .equ GPIO24_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO24_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO25, 0x0068 Pad control register
       @ .equ GPIO25_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO25_IE [6:6]    Input enable 
       @ .equ GPIO25_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO25_PUE [3:3]    Pull up enable 
       @ .equ GPIO25_PDE [2:2]    Pull down enable 
       @ .equ GPIO25_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO25_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO26, 0x006c Pad control register
       @ .equ GPIO26_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO26_IE [6:6]    Input enable 
       @ .equ GPIO26_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO26_PUE [3:3]    Pull up enable 
       @ .equ GPIO26_PDE [2:2]    Pull down enable 
       @ .equ GPIO26_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO26_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO27, 0x0070 Pad control register
       @ .equ GPIO27_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO27_IE [6:6]    Input enable 
       @ .equ GPIO27_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO27_PUE [3:3]    Pull up enable 
       @ .equ GPIO27_PDE [2:2]    Pull down enable 
       @ .equ GPIO27_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO27_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO28, 0x0074 Pad control register
       @ .equ GPIO28_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO28_IE [6:6]    Input enable 
       @ .equ GPIO28_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO28_PUE [3:3]    Pull up enable 
       @ .equ GPIO28_PDE [2:2]    Pull down enable 
       @ .equ GPIO28_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO28_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO29, 0x0078 Pad control register
       @ .equ GPIO29_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO29_IE [6:6]    Input enable 
       @ .equ GPIO29_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO29_PUE [3:3]    Pull up enable 
       @ .equ GPIO29_PDE [2:2]    Pull down enable 
       @ .equ GPIO29_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO29_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_SWCLK, 0x007c Pad control register
       @ .equ SWCLK_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ SWCLK_IE [6:6]    Input enable 
       @ .equ SWCLK_DRIVE [5:4]    Drive strength. 
       @ .equ SWCLK_PUE [3:3]    Pull up enable 
       @ .equ SWCLK_PDE [2:2]    Pull down enable 
       @ .equ SWCLK_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ SWCLK_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_SWD, 0x0080 Pad control register
       @ .equ SWD_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ SWD_IE [6:6]    Input enable 
       @ .equ SWD_DRIVE [5:4]    Drive strength. 
       @ .equ SWD_PUE [3:3]    Pull up enable 
       @ .equ SWD_PDE [2:2]    Pull down enable 
       @ .equ SWD_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ SWD_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 

@=========================== PADS_QSPI ===========================@
.equ PADS_QSPI_BASE, 0x40020000 
    .equ PADS_QSPI_VOLTAGE_SELECT, 0x0000 Voltage select. Per bank control
       @ .equ VOLTAGE_SELECT_VOLTAGE_SELECT [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SCLK, 0x0004 Pad control register
       @ .equ GPIO_QSPI_SCLK_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO_QSPI_SCLK_IE [6:6]    Input enable 
       @ .equ GPIO_QSPI_SCLK_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO_QSPI_SCLK_PUE [3:3]    Pull up enable 
       @ .equ GPIO_QSPI_SCLK_PDE [2:2]    Pull down enable 
       @ .equ GPIO_QSPI_SCLK_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO_QSPI_SCLK_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD0, 0x0008 Pad control register
       @ .equ GPIO_QSPI_SD0_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO_QSPI_SD0_IE [6:6]    Input enable 
       @ .equ GPIO_QSPI_SD0_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO_QSPI_SD0_PUE [3:3]    Pull up enable 
       @ .equ GPIO_QSPI_SD0_PDE [2:2]    Pull down enable 
       @ .equ GPIO_QSPI_SD0_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO_QSPI_SD0_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD1, 0x000c Pad control register
       @ .equ GPIO_QSPI_SD1_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO_QSPI_SD1_IE [6:6]    Input enable 
       @ .equ GPIO_QSPI_SD1_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO_QSPI_SD1_PUE [3:3]    Pull up enable 
       @ .equ GPIO_QSPI_SD1_PDE [2:2]    Pull down enable 
       @ .equ GPIO_QSPI_SD1_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO_QSPI_SD1_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD2, 0x0010 Pad control register
       @ .equ GPIO_QSPI_SD2_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO_QSPI_SD2_IE [6:6]    Input enable 
       @ .equ GPIO_QSPI_SD2_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO_QSPI_SD2_PUE [3:3]    Pull up enable 
       @ .equ GPIO_QSPI_SD2_PDE [2:2]    Pull down enable 
       @ .equ GPIO_QSPI_SD2_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO_QSPI_SD2_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD3, 0x0014 Pad control register
       @ .equ GPIO_QSPI_SD3_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO_QSPI_SD3_IE [6:6]    Input enable 
       @ .equ GPIO_QSPI_SD3_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO_QSPI_SD3_PUE [3:3]    Pull up enable 
       @ .equ GPIO_QSPI_SD3_PDE [2:2]    Pull down enable 
       @ .equ GPIO_QSPI_SD3_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO_QSPI_SD3_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SS, 0x0018 Pad control register
       @ .equ GPIO_QSPI_SS_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ GPIO_QSPI_SS_IE [6:6]    Input enable 
       @ .equ GPIO_QSPI_SS_DRIVE [5:4]    Drive strength. 
       @ .equ GPIO_QSPI_SS_PUE [3:3]    Pull up enable 
       @ .equ GPIO_QSPI_SS_PDE [2:2]    Pull down enable 
       @ .equ GPIO_QSPI_SS_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ GPIO_QSPI_SS_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 

@=========================== XOSC ===========================@
.equ XOSC_BASE, 0x40024000 Controls the crystal oscillator
    .equ XOSC_CTRL, 0x0000 Crystal Oscillator Control
       @ .equ CTRL_ENABLE [23:12]    On power-up this field is initialised to DISABLE and the chip runs from the ROSC.  If the chip has subsequently been programmed to run from the XOSC then setting this field to DISABLE may lock-up the chip. If this is a concern then run the clk_ref from the ROSC and enable the clk_sys RESUS feature.  The 12-bit code is intended to give some protection against accidental writes. An invalid setting will enable the oscillator. 
       @ .equ CTRL_FREQ_RANGE [11:0]    Frequency range. This resets to 0xAA0 and cannot be changed. 
 
    .equ XOSC_STATUS, 0x0004 Crystal Oscillator Status
       @ .equ STATUS_STABLE [31:31]    Oscillator is running and stable 
       @ .equ STATUS_BADWRITE [24:24]    An invalid value has been written to CTRL_ENABLE or CTRL_FREQ_RANGE or DORMANT 
       @ .equ STATUS_ENABLED [12:12]    Oscillator is enabled but not necessarily running and stable, resets to 0 
       @ .equ STATUS_FREQ_RANGE [1:0]    The current frequency range setting, always reads 0 
 
    .equ XOSC_DORMANT, 0x0008 Crystal Oscillator pause control  This is used to save power by pausing the XOSC  On power-up this field is initialised to WAKE  An invalid write will also select WAKE  WARNING: stop the PLLs before selecting dormant mode  WARNING: setup the irq before selecting dormant mode
 
    .equ XOSC_STARTUP, 0x000c Controls the startup delay
       @ .equ STARTUP_X4 [20:20]    Multiplies the startup_delay by 4. This is of little value to the user given that the delay can be programmed directly 
       @ .equ STARTUP_DELAY [13:0]    in multiples of 256*xtal_period 
 
    .equ XOSC_COUNT, 0x001c A down counter running at the xosc frequency which counts to zero and stops.  To start the counter write a non-zero value.  Can be used for short software pauses when setting up time sensitive hardware.
       @ .equ COUNT_COUNT [7:0]     
 

@=========================== PLL_SYS ===========================@
.equ PLL_SYS_BASE, 0x40028000 
    .equ PLL_SYS_CS, 0x0000 Control and Status  GENERAL CONSTRAINTS:  Reference clock frequency min=5MHz, max=800MHz  Feedback divider min=16, max=320  VCO frequency min=400MHz, max=1600MHz
       @ .equ CS_LOCK [31:31]    PLL is locked 
       @ .equ CS_BYPASS [8:8]    Passes the reference clock to the output instead of the divided VCO. The VCO continues to run so the user can switch between the reference clock and the divided VCO but the output will glitch when doing so. 
       @ .equ CS_REFDIV [5:0]    Divides the PLL input reference clock.  Behaviour is undefined for div=0.  PLL output will be unpredictable during refdiv changes, wait for lock=1 before using it. 
 
    .equ PLL_SYS_PWR, 0x0004 Controls the PLL power modes.
       @ .equ PWR_VCOPD [5:5]    PLL VCO powerdown  To save power set high when PLL output not required or bypass=1. 
       @ .equ PWR_POSTDIVPD [3:3]    PLL post divider powerdown  To save power set high when PLL output not required or bypass=1. 
       @ .equ PWR_DSMPD [2:2]    PLL DSM powerdown  Nothing is achieved by setting this low. 
       @ .equ PWR_PD [0:0]    PLL powerdown  To save power set high when PLL output not required. 
 
    .equ PLL_SYS_FBDIV_INT, 0x0008 Feedback divisor  note: this PLL does not support fractional division
       @ .equ FBDIV_INT_FBDIV_INT [11:0]    see ctrl reg description for constraints 
 
    .equ PLL_SYS_PRIM, 0x000c Controls the PLL post dividers for the primary output  note: this PLL does not have a secondary output  the primary output is driven from VCO divided by postdiv1*postdiv2
       @ .equ PRIM_POSTDIV1 [18:16]    divide by 1-7 
       @ .equ PRIM_POSTDIV2 [14:12]    divide by 1-7 
 

@=========================== PLL_USB ===========================@
.equ PLL_USB_BASE, 0x4002c000 
    .equ PLL_USB_CS, 0x0000 Control and Status  GENERAL CONSTRAINTS:  Reference clock frequency min=5MHz, max=800MHz  Feedback divider min=16, max=320  VCO frequency min=400MHz, max=1600MHz
       @ .equ CS_LOCK [31:31]    PLL is locked 
       @ .equ CS_BYPASS [8:8]    Passes the reference clock to the output instead of the divided VCO. The VCO continues to run so the user can switch between the reference clock and the divided VCO but the output will glitch when doing so. 
       @ .equ CS_REFDIV [5:0]    Divides the PLL input reference clock.  Behaviour is undefined for div=0.  PLL output will be unpredictable during refdiv changes, wait for lock=1 before using it. 
 
    .equ PLL_USB_PWR, 0x0004 Controls the PLL power modes.
       @ .equ PWR_VCOPD [5:5]    PLL VCO powerdown  To save power set high when PLL output not required or bypass=1. 
       @ .equ PWR_POSTDIVPD [3:3]    PLL post divider powerdown  To save power set high when PLL output not required or bypass=1. 
       @ .equ PWR_DSMPD [2:2]    PLL DSM powerdown  Nothing is achieved by setting this low. 
       @ .equ PWR_PD [0:0]    PLL powerdown  To save power set high when PLL output not required. 
 
    .equ PLL_USB_FBDIV_INT, 0x0008 Feedback divisor  note: this PLL does not support fractional division
       @ .equ FBDIV_INT_FBDIV_INT [11:0]    see ctrl reg description for constraints 
 
    .equ PLL_USB_PRIM, 0x000c Controls the PLL post dividers for the primary output  note: this PLL does not have a secondary output  the primary output is driven from VCO divided by postdiv1*postdiv2
       @ .equ PRIM_POSTDIV1 [18:16]    divide by 1-7 
       @ .equ PRIM_POSTDIV2 [14:12]    divide by 1-7 
 

@=========================== BUSCTRL ===========================@
.equ BUSCTRL_BASE, 0x40030000 Register block for busfabric control signals and performance counters
    .equ BUSCTRL_BUS_PRIORITY, 0x0000 Set the priority of each master for bus arbitration.
       @ .equ BUS_PRIORITY_DMA_W [12:12]    0 - low priority, 1 - high priority 
       @ .equ BUS_PRIORITY_DMA_R [8:8]    0 - low priority, 1 - high priority 
       @ .equ BUS_PRIORITY_PROC1 [4:4]    0 - low priority, 1 - high priority 
       @ .equ BUS_PRIORITY_PROC0 [0:0]    0 - low priority, 1 - high priority 
 
    .equ BUSCTRL_BUS_PRIORITY_ACK, 0x0004 Bus priority acknowledge
       @ .equ BUS_PRIORITY_ACK_BUS_PRIORITY_ACK [0:0]    Goes to 1 once all arbiters have registered the new global priority levels.  Arbiters update their local priority when servicing a new nonsequential access.  In normal circumstances this will happen almost immediately. 
 
    .equ BUSCTRL_PERFCTR0, 0x0008 Bus fabric performance counter 0
       @ .equ PERFCTR0_PERFCTR0 [23:0]    Busfabric saturating performance counter 0  Count some event signal from the busfabric arbiters.  Write any value to clear. Select an event to count using PERFSEL0 
 
    .equ BUSCTRL_PERFSEL0, 0x000c Bus fabric performance event select for PERFCTR0
       @ .equ PERFSEL0_PERFSEL0 [4:0]    Select a performance event for PERFCTR0 
 
    .equ BUSCTRL_PERFCTR1, 0x0010 Bus fabric performance counter 1
       @ .equ PERFCTR1_PERFCTR1 [23:0]    Busfabric saturating performance counter 1  Count some event signal from the busfabric arbiters.  Write any value to clear. Select an event to count using PERFSEL1 
 
    .equ BUSCTRL_PERFSEL1, 0x0014 Bus fabric performance event select for PERFCTR1
       @ .equ PERFSEL1_PERFSEL1 [4:0]    Select a performance event for PERFCTR1 
 
    .equ BUSCTRL_PERFCTR2, 0x0018 Bus fabric performance counter 2
       @ .equ PERFCTR2_PERFCTR2 [23:0]    Busfabric saturating performance counter 2  Count some event signal from the busfabric arbiters.  Write any value to clear. Select an event to count using PERFSEL2 
 
    .equ BUSCTRL_PERFSEL2, 0x001c Bus fabric performance event select for PERFCTR2
       @ .equ PERFSEL2_PERFSEL2 [4:0]    Select a performance event for PERFCTR2 
 
    .equ BUSCTRL_PERFCTR3, 0x0020 Bus fabric performance counter 3
       @ .equ PERFCTR3_PERFCTR3 [23:0]    Busfabric saturating performance counter 3  Count some event signal from the busfabric arbiters.  Write any value to clear. Select an event to count using PERFSEL3 
 
    .equ BUSCTRL_PERFSEL3, 0x0024 Bus fabric performance event select for PERFCTR3
       @ .equ PERFSEL3_PERFSEL3 [4:0]    Select a performance event for PERFCTR3 
 

@=========================== UART0 ===========================@
.equ UART0_BASE, 0x40034000 
    .equ UART0_UARTDR, 0x0000 Data Register, UARTDR
       @ .equ UARTDR_OE [11:11]    Overrun error. This bit is set to 1 if data is received and the receive FIFO is already full. This is cleared to 0 once there is an empty space in the FIFO and a new character can be written to it. 
       @ .equ UARTDR_BE [10:10]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity and stop bits. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state, and the next valid start bit is received. 
       @ .equ UARTDR_PE [9:9]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UARTDR_FE [8:8]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UARTDR_DATA [7:0]    Receive read data character. Transmit write data character. 
 
    .equ UART0_UARTRSR, 0x0004 Receive Status Register/Error Clear Register, UARTRSR/UARTECR
       @ .equ UARTRSR_OE [3:3]    Overrun error. This bit is set to 1 if data is received and the FIFO is already full. This bit is cleared to 0 by a write to UARTECR. The FIFO contents remain valid because no more data is written when the FIFO is full, only the contents of the shift register are overwritten. The CPU must now read the data, to empty the FIFO. 
       @ .equ UARTRSR_BE [2:2]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity, and stop bits. This bit is cleared to 0 after a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state and the next valid start bit is received. 
       @ .equ UARTRSR_PE [1:1]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UARTRSR_FE [0:0]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
 
    .equ UART0_UARTFR, 0x0018 Flag Register, UARTFR
       @ .equ UARTFR_RI [8:8]    Ring indicator. This bit is the complement of the UART ring indicator, nUARTRI, modem status input. That is, the bit is 1 when nUARTRI is LOW. 
       @ .equ UARTFR_TXFE [7:7]    Transmit FIFO empty. The meaning of this bit depends on the state of the FEN bit in the Line Control Register, UARTLCR_H. If the FIFO is disabled, this bit is set when the transmit holding register is empty. If the FIFO is enabled, the TXFE bit is set when the transmit FIFO is empty. This bit does not indicate if there is data in the transmit shift register. 
       @ .equ UARTFR_RXFF [6:6]    Receive FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is full. If the FIFO is enabled, the RXFF bit is set when the receive FIFO is full. 
       @ .equ UARTFR_TXFF [5:5]    Transmit FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the transmit holding register is full. If the FIFO is enabled, the TXFF bit is set when the transmit FIFO is full. 
       @ .equ UARTFR_RXFE [4:4]    Receive FIFO empty. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is empty. If the FIFO is enabled, the RXFE bit is set when the receive FIFO is empty. 
       @ .equ UARTFR_BUSY [3:3]    UART busy. If this bit is set to 1, the UART is busy transmitting data. This bit remains set until the complete byte, including all the stop bits, has been sent from the shift register. This bit is set as soon as the transmit FIFO becomes non-empty, regardless of whether the UART is enabled or not. 
       @ .equ UARTFR_DCD [2:2]    Data carrier detect. This bit is the complement of the UART data carrier detect, nUARTDCD, modem status input. That is, the bit is 1 when nUARTDCD is LOW. 
       @ .equ UARTFR_DSR [1:1]    Data set ready. This bit is the complement of the UART data set ready, nUARTDSR, modem status input. That is, the bit is 1 when nUARTDSR is LOW. 
       @ .equ UARTFR_CTS [0:0]    Clear to send. This bit is the complement of the UART clear to send, nUARTCTS, modem status input. That is, the bit is 1 when nUARTCTS is LOW. 
 
    .equ UART0_UARTILPR, 0x0020 IrDA Low-Power Counter Register, UARTILPR
       @ .equ UARTILPR_ILPDVSR [7:0]    8-bit low-power divisor value. These bits are cleared to 0 at reset. 
 
    .equ UART0_UARTIBRD, 0x0024 Integer Baud Rate Register, UARTIBRD
       @ .equ UARTIBRD_BAUD_DIVINT [15:0]    The integer baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART0_UARTFBRD, 0x0028 Fractional Baud Rate Register, UARTFBRD
       @ .equ UARTFBRD_BAUD_DIVFRAC [5:0]    The fractional baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART0_UARTLCR_H, 0x002c Line Control Register, UARTLCR_H
       @ .equ UARTLCR_H_SPS [7:7]    Stick parity select. 0 = stick parity is disabled 1 = either: * if the EPS bit is 0 then the parity bit is transmitted and checked as a 1 * if the EPS bit is 1 then the parity bit is transmitted and checked as a 0. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UARTLCR_H_WLEN [6:5]    Word length. These bits indicate the number of data bits transmitted or received in a frame as follows: b11 = 8 bits b10 = 7 bits b01 = 6 bits b00 = 5 bits. 
       @ .equ UARTLCR_H_FEN [4:4]    Enable FIFOs: 0 = FIFOs are disabled character mode that is, the FIFOs become 1-byte-deep holding registers 1 = transmit and receive FIFO buffers are enabled FIFO mode. 
       @ .equ UARTLCR_H_STP2 [3:3]    Two stop bits select. If this bit is set to 1, two stop bits are transmitted at the end of the frame. The receive logic does not check for two stop bits being received. 
       @ .equ UARTLCR_H_EPS [2:2]    Even parity select. Controls the type of parity the UART uses during transmission and reception: 0 = odd parity. The UART generates or checks for an odd number of 1s in the data and parity bits. 1 = even parity. The UART generates or checks for an even number of 1s in the data and parity bits. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UARTLCR_H_PEN [1:1]    Parity enable: 0 = parity is disabled and no parity bit added to the data frame 1 = parity checking and generation is enabled. 
       @ .equ UARTLCR_H_BRK [0:0]    Send break. If this bit is set to 1, a low-level is continually output on the UARTTXD output, after completing transmission of the current character. For the proper execution of the break command, the software must set this bit for at least two complete frames. For normal use, this bit must be cleared to 0. 
 
    .equ UART0_UARTCR, 0x0030 Control Register, UARTCR
       @ .equ UARTCR_CTSEN [15:15]    CTS hardware flow control enable. If this bit is set to 1, CTS hardware flow control is enabled. Data is only transmitted when the nUARTCTS signal is asserted. 
       @ .equ UARTCR_RTSEN [14:14]    RTS hardware flow control enable. If this bit is set to 1, RTS hardware flow control is enabled. Data is only requested when there is space in the receive FIFO for it to be received. 
       @ .equ UARTCR_OUT2 [13:13]    This bit is the complement of the UART Out2 nUARTOut2 modem status output. That is, when the bit is programmed to a 1, the output is 0. For DTE this can be used as Ring Indicator RI. 
       @ .equ UARTCR_OUT1 [12:12]    This bit is the complement of the UART Out1 nUARTOut1 modem status output. That is, when the bit is programmed to a 1 the output is 0. For DTE this can be used as Data Carrier Detect DCD. 
       @ .equ UARTCR_RTS [11:11]    Request to send. This bit is the complement of the UART request to send, nUARTRTS, modem status output. That is, when the bit is programmed to a 1 then nUARTRTS is LOW. 
       @ .equ UARTCR_DTR [10:10]    Data transmit ready. This bit is the complement of the UART data transmit ready, nUARTDTR, modem status output. That is, when the bit is programmed to a 1 then nUARTDTR is LOW. 
       @ .equ UARTCR_RXE [9:9]    Receive enable. If this bit is set to 1, the receive section of the UART is enabled. Data reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of reception, it completes the current character before stopping. 
       @ .equ UARTCR_TXE [8:8]    Transmit enable. If this bit is set to 1, the transmit section of the UART is enabled. Data transmission occurs for either UART signals, or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of transmission, it completes the current character before stopping. 
       @ .equ UARTCR_LBE [7:7]    Loopback enable. If this bit is set to 1 and the SIREN bit is set to 1 and the SIRTEST bit in the Test Control Register, UARTTCR is set to 1, then the nSIROUT path is inverted, and fed through to the SIRIN path. The SIRTEST bit in the test register must be set to 1 to override the normal half-duplex SIR operation. This must be the requirement for accessing the test registers during normal operation, and SIRTEST must be cleared to 0 when loopback testing is finished. This feature reduces the amount of external coupling required during system test. If this bit is set to 1, and the SIRTEST bit is set to 0, the UARTTXD path is fed through to the UARTRXD path. In either SIR mode or UART mode, when this bit is set, the modem outputs are also fed through to the modem inputs. This bit is cleared to 0 on reset, to disable loopback. 
       @ .equ UARTCR_SIRLP [2:2]    SIR low-power IrDA mode. This bit selects the IrDA encoding mode. If this bit is cleared to 0, low-level bits are transmitted as an active high pulse with a width of 3 / 16th of the bit period. If this bit is set to 1, low-level bits are transmitted with a pulse width that is 3 times the period of the IrLPBaud16 input signal, regardless of the selected bit rate. Setting this bit uses less power, but might reduce transmission distances. 
       @ .equ UARTCR_SIREN [1:1]    SIR enable: 0 = IrDA SIR ENDEC is disabled. nSIROUT remains LOW no light pulse generated, and signal transitions on SIRIN have no effect. 1 = IrDA SIR ENDEC is enabled. Data is transmitted and received on nSIROUT and SIRIN. UARTTXD remains HIGH, in the marking state. Signal transitions on UARTRXD or modem status inputs have no effect. This bit has no effect if the UARTEN bit disables the UART. 
       @ .equ UARTCR_UARTEN [0:0]    UART enable: 0 = UART is disabled. If the UART is disabled in the middle of transmission or reception, it completes the current character before stopping. 1 = the UART is enabled. Data transmission and reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. 
 
    .equ UART0_UARTIFLS, 0x0034 Interrupt FIFO Level Select Register, UARTIFLS
       @ .equ UARTIFLS_RXIFLSEL [5:3]    Receive interrupt FIFO level select. The trigger points for the receive interrupt are as follows: b000 = Receive FIFO becomes >= 1 / 8 full b001 = Receive FIFO becomes >= 1 / 4 full b010 = Receive FIFO becomes >= 1 / 2 full b011 = Receive FIFO becomes >= 3 / 4 full b100 = Receive FIFO becomes >= 7 / 8 full b101-b111 = reserved. 
       @ .equ UARTIFLS_TXIFLSEL [2:0]    Transmit interrupt FIFO level select. The trigger points for the transmit interrupt are as follows: b000 = Transmit FIFO becomes <= 1 / 8 full b001 = Transmit FIFO becomes <= 1 / 4 full b010 = Transmit FIFO becomes <= 1 / 2 full b011 = Transmit FIFO becomes <= 3 / 4 full b100 = Transmit FIFO becomes <= 7 / 8 full b101-b111 = reserved. 
 
    .equ UART0_UARTIMSC, 0x0038 Interrupt Mask Set/Clear Register, UARTIMSC
       @ .equ UARTIMSC_OEIM [10:10]    Overrun error interrupt mask. A read returns the current mask for the UARTOEINTR interrupt. On a write of 1, the mask of the UARTOEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_BEIM [9:9]    Break error interrupt mask. A read returns the current mask for the UARTBEINTR interrupt. On a write of 1, the mask of the UARTBEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_PEIM [8:8]    Parity error interrupt mask. A read returns the current mask for the UARTPEINTR interrupt. On a write of 1, the mask of the UARTPEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_FEIM [7:7]    Framing error interrupt mask. A read returns the current mask for the UARTFEINTR interrupt. On a write of 1, the mask of the UARTFEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_RTIM [6:6]    Receive timeout interrupt mask. A read returns the current mask for the UARTRTINTR interrupt. On a write of 1, the mask of the UARTRTINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_TXIM [5:5]    Transmit interrupt mask. A read returns the current mask for the UARTTXINTR interrupt. On a write of 1, the mask of the UARTTXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_RXIM [4:4]    Receive interrupt mask. A read returns the current mask for the UARTRXINTR interrupt. On a write of 1, the mask of the UARTRXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_DSRMIM [3:3]    nUARTDSR modem interrupt mask. A read returns the current mask for the UARTDSRINTR interrupt. On a write of 1, the mask of the UARTDSRINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_DCDMIM [2:2]    nUARTDCD modem interrupt mask. A read returns the current mask for the UARTDCDINTR interrupt. On a write of 1, the mask of the UARTDCDINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_CTSMIM [1:1]    nUARTCTS modem interrupt mask. A read returns the current mask for the UARTCTSINTR interrupt. On a write of 1, the mask of the UARTCTSINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_RIMIM [0:0]    nUARTRI modem interrupt mask. A read returns the current mask for the UARTRIINTR interrupt. On a write of 1, the mask of the UARTRIINTR interrupt is set. A write of 0 clears the mask. 
 
    .equ UART0_UARTRIS, 0x003c Raw Interrupt Status Register, UARTRIS
       @ .equ UARTRIS_OERIS [10:10]    Overrun error interrupt status. Returns the raw interrupt state of the UARTOEINTR interrupt. 
       @ .equ UARTRIS_BERIS [9:9]    Break error interrupt status. Returns the raw interrupt state of the UARTBEINTR interrupt. 
       @ .equ UARTRIS_PERIS [8:8]    Parity error interrupt status. Returns the raw interrupt state of the UARTPEINTR interrupt. 
       @ .equ UARTRIS_FERIS [7:7]    Framing error interrupt status. Returns the raw interrupt state of the UARTFEINTR interrupt. 
       @ .equ UARTRIS_RTRIS [6:6]    Receive timeout interrupt status. Returns the raw interrupt state of the UARTRTINTR interrupt. a 
       @ .equ UARTRIS_TXRIS [5:5]    Transmit interrupt status. Returns the raw interrupt state of the UARTTXINTR interrupt. 
       @ .equ UARTRIS_RXRIS [4:4]    Receive interrupt status. Returns the raw interrupt state of the UARTRXINTR interrupt. 
       @ .equ UARTRIS_DSRRMIS [3:3]    nUARTDSR modem interrupt status. Returns the raw interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UARTRIS_DCDRMIS [2:2]    nUARTDCD modem interrupt status. Returns the raw interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UARTRIS_CTSRMIS [1:1]    nUARTCTS modem interrupt status. Returns the raw interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UARTRIS_RIRMIS [0:0]    nUARTRI modem interrupt status. Returns the raw interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART0_UARTMIS, 0x0040 Masked Interrupt Status Register, UARTMIS
       @ .equ UARTMIS_OEMIS [10:10]    Overrun error masked interrupt status. Returns the masked interrupt state of the UARTOEINTR interrupt. 
       @ .equ UARTMIS_BEMIS [9:9]    Break error masked interrupt status. Returns the masked interrupt state of the UARTBEINTR interrupt. 
       @ .equ UARTMIS_PEMIS [8:8]    Parity error masked interrupt status. Returns the masked interrupt state of the UARTPEINTR interrupt. 
       @ .equ UARTMIS_FEMIS [7:7]    Framing error masked interrupt status. Returns the masked interrupt state of the UARTFEINTR interrupt. 
       @ .equ UARTMIS_RTMIS [6:6]    Receive timeout masked interrupt status. Returns the masked interrupt state of the UARTRTINTR interrupt. 
       @ .equ UARTMIS_TXMIS [5:5]    Transmit masked interrupt status. Returns the masked interrupt state of the UARTTXINTR interrupt. 
       @ .equ UARTMIS_RXMIS [4:4]    Receive masked interrupt status. Returns the masked interrupt state of the UARTRXINTR interrupt. 
       @ .equ UARTMIS_DSRMMIS [3:3]    nUARTDSR modem masked interrupt status. Returns the masked interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UARTMIS_DCDMMIS [2:2]    nUARTDCD modem masked interrupt status. Returns the masked interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UARTMIS_CTSMMIS [1:1]    nUARTCTS modem masked interrupt status. Returns the masked interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UARTMIS_RIMMIS [0:0]    nUARTRI modem masked interrupt status. Returns the masked interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART0_UARTICR, 0x0044 Interrupt Clear Register, UARTICR
       @ .equ UARTICR_OEIC [10:10]    Overrun error interrupt clear. Clears the UARTOEINTR interrupt. 
       @ .equ UARTICR_BEIC [9:9]    Break error interrupt clear. Clears the UARTBEINTR interrupt. 
       @ .equ UARTICR_PEIC [8:8]    Parity error interrupt clear. Clears the UARTPEINTR interrupt. 
       @ .equ UARTICR_FEIC [7:7]    Framing error interrupt clear. Clears the UARTFEINTR interrupt. 
       @ .equ UARTICR_RTIC [6:6]    Receive timeout interrupt clear. Clears the UARTRTINTR interrupt. 
       @ .equ UARTICR_TXIC [5:5]    Transmit interrupt clear. Clears the UARTTXINTR interrupt. 
       @ .equ UARTICR_RXIC [4:4]    Receive interrupt clear. Clears the UARTRXINTR interrupt. 
       @ .equ UARTICR_DSRMIC [3:3]    nUARTDSR modem interrupt clear. Clears the UARTDSRINTR interrupt. 
       @ .equ UARTICR_DCDMIC [2:2]    nUARTDCD modem interrupt clear. Clears the UARTDCDINTR interrupt. 
       @ .equ UARTICR_CTSMIC [1:1]    nUARTCTS modem interrupt clear. Clears the UARTCTSINTR interrupt. 
       @ .equ UARTICR_RIMIC [0:0]    nUARTRI modem interrupt clear. Clears the UARTRIINTR interrupt. 
 
    .equ UART0_UARTDMACR, 0x0048 DMA Control Register, UARTDMACR
       @ .equ UARTDMACR_DMAONERR [2:2]    DMA on error. If this bit is set to 1, the DMA receive request outputs, UARTRXDMASREQ or UARTRXDMABREQ, are disabled when the UART error interrupt is asserted. 
       @ .equ UARTDMACR_TXDMAE [1:1]    Transmit DMA enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ UARTDMACR_RXDMAE [0:0]    Receive DMA enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ UART0_UARTPERIPHID0, 0x0fe0 UARTPeriphID0 Register
       @ .equ UARTPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x11 
 
    .equ UART0_UARTPERIPHID1, 0x0fe4 UARTPeriphID1 Register
       @ .equ UARTPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ UARTPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ UART0_UARTPERIPHID2, 0x0fe8 UARTPeriphID2 Register
       @ .equ UARTPERIPHID2_REVISION [7:4]    This field depends on the revision of the UART: r1p0 0x0 r1p1 0x1 r1p3 0x2 r1p4 0x2 r1p5 0x3 
       @ .equ UARTPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ UART0_UARTPERIPHID3, 0x0fec UARTPeriphID3 Register
       @ .equ UARTPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ UART0_UARTPCELLID0, 0x0ff0 UARTPCellID0 Register
       @ .equ UARTPCELLID0_UARTPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ UART0_UARTPCELLID1, 0x0ff4 UARTPCellID1 Register
       @ .equ UARTPCELLID1_UARTPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ UART0_UARTPCELLID2, 0x0ff8 UARTPCellID2 Register
       @ .equ UARTPCELLID2_UARTPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ UART0_UARTPCELLID3, 0x0ffc UARTPCellID3 Register
       @ .equ UARTPCELLID3_UARTPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== UART1 ===========================@
.equ UART1_BASE, 0x40038000 
    .equ UART1_UARTDR, 0x0000 Data Register, UARTDR
       @ .equ UARTDR_OE [11:11]    Overrun error. This bit is set to 1 if data is received and the receive FIFO is already full. This is cleared to 0 once there is an empty space in the FIFO and a new character can be written to it. 
       @ .equ UARTDR_BE [10:10]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity and stop bits. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state, and the next valid start bit is received. 
       @ .equ UARTDR_PE [9:9]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UARTDR_FE [8:8]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UARTDR_DATA [7:0]    Receive read data character. Transmit write data character. 
 
    .equ UART1_UARTRSR, 0x0004 Receive Status Register/Error Clear Register, UARTRSR/UARTECR
       @ .equ UARTRSR_OE [3:3]    Overrun error. This bit is set to 1 if data is received and the FIFO is already full. This bit is cleared to 0 by a write to UARTECR. The FIFO contents remain valid because no more data is written when the FIFO is full, only the contents of the shift register are overwritten. The CPU must now read the data, to empty the FIFO. 
       @ .equ UARTRSR_BE [2:2]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity, and stop bits. This bit is cleared to 0 after a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state and the next valid start bit is received. 
       @ .equ UARTRSR_PE [1:1]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UARTRSR_FE [0:0]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
 
    .equ UART1_UARTFR, 0x0018 Flag Register, UARTFR
       @ .equ UARTFR_RI [8:8]    Ring indicator. This bit is the complement of the UART ring indicator, nUARTRI, modem status input. That is, the bit is 1 when nUARTRI is LOW. 
       @ .equ UARTFR_TXFE [7:7]    Transmit FIFO empty. The meaning of this bit depends on the state of the FEN bit in the Line Control Register, UARTLCR_H. If the FIFO is disabled, this bit is set when the transmit holding register is empty. If the FIFO is enabled, the TXFE bit is set when the transmit FIFO is empty. This bit does not indicate if there is data in the transmit shift register. 
       @ .equ UARTFR_RXFF [6:6]    Receive FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is full. If the FIFO is enabled, the RXFF bit is set when the receive FIFO is full. 
       @ .equ UARTFR_TXFF [5:5]    Transmit FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the transmit holding register is full. If the FIFO is enabled, the TXFF bit is set when the transmit FIFO is full. 
       @ .equ UARTFR_RXFE [4:4]    Receive FIFO empty. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is empty. If the FIFO is enabled, the RXFE bit is set when the receive FIFO is empty. 
       @ .equ UARTFR_BUSY [3:3]    UART busy. If this bit is set to 1, the UART is busy transmitting data. This bit remains set until the complete byte, including all the stop bits, has been sent from the shift register. This bit is set as soon as the transmit FIFO becomes non-empty, regardless of whether the UART is enabled or not. 
       @ .equ UARTFR_DCD [2:2]    Data carrier detect. This bit is the complement of the UART data carrier detect, nUARTDCD, modem status input. That is, the bit is 1 when nUARTDCD is LOW. 
       @ .equ UARTFR_DSR [1:1]    Data set ready. This bit is the complement of the UART data set ready, nUARTDSR, modem status input. That is, the bit is 1 when nUARTDSR is LOW. 
       @ .equ UARTFR_CTS [0:0]    Clear to send. This bit is the complement of the UART clear to send, nUARTCTS, modem status input. That is, the bit is 1 when nUARTCTS is LOW. 
 
    .equ UART1_UARTILPR, 0x0020 IrDA Low-Power Counter Register, UARTILPR
       @ .equ UARTILPR_ILPDVSR [7:0]    8-bit low-power divisor value. These bits are cleared to 0 at reset. 
 
    .equ UART1_UARTIBRD, 0x0024 Integer Baud Rate Register, UARTIBRD
       @ .equ UARTIBRD_BAUD_DIVINT [15:0]    The integer baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART1_UARTFBRD, 0x0028 Fractional Baud Rate Register, UARTFBRD
       @ .equ UARTFBRD_BAUD_DIVFRAC [5:0]    The fractional baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART1_UARTLCR_H, 0x002c Line Control Register, UARTLCR_H
       @ .equ UARTLCR_H_SPS [7:7]    Stick parity select. 0 = stick parity is disabled 1 = either: * if the EPS bit is 0 then the parity bit is transmitted and checked as a 1 * if the EPS bit is 1 then the parity bit is transmitted and checked as a 0. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UARTLCR_H_WLEN [6:5]    Word length. These bits indicate the number of data bits transmitted or received in a frame as follows: b11 = 8 bits b10 = 7 bits b01 = 6 bits b00 = 5 bits. 
       @ .equ UARTLCR_H_FEN [4:4]    Enable FIFOs: 0 = FIFOs are disabled character mode that is, the FIFOs become 1-byte-deep holding registers 1 = transmit and receive FIFO buffers are enabled FIFO mode. 
       @ .equ UARTLCR_H_STP2 [3:3]    Two stop bits select. If this bit is set to 1, two stop bits are transmitted at the end of the frame. The receive logic does not check for two stop bits being received. 
       @ .equ UARTLCR_H_EPS [2:2]    Even parity select. Controls the type of parity the UART uses during transmission and reception: 0 = odd parity. The UART generates or checks for an odd number of 1s in the data and parity bits. 1 = even parity. The UART generates or checks for an even number of 1s in the data and parity bits. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UARTLCR_H_PEN [1:1]    Parity enable: 0 = parity is disabled and no parity bit added to the data frame 1 = parity checking and generation is enabled. 
       @ .equ UARTLCR_H_BRK [0:0]    Send break. If this bit is set to 1, a low-level is continually output on the UARTTXD output, after completing transmission of the current character. For the proper execution of the break command, the software must set this bit for at least two complete frames. For normal use, this bit must be cleared to 0. 
 
    .equ UART1_UARTCR, 0x0030 Control Register, UARTCR
       @ .equ UARTCR_CTSEN [15:15]    CTS hardware flow control enable. If this bit is set to 1, CTS hardware flow control is enabled. Data is only transmitted when the nUARTCTS signal is asserted. 
       @ .equ UARTCR_RTSEN [14:14]    RTS hardware flow control enable. If this bit is set to 1, RTS hardware flow control is enabled. Data is only requested when there is space in the receive FIFO for it to be received. 
       @ .equ UARTCR_OUT2 [13:13]    This bit is the complement of the UART Out2 nUARTOut2 modem status output. That is, when the bit is programmed to a 1, the output is 0. For DTE this can be used as Ring Indicator RI. 
       @ .equ UARTCR_OUT1 [12:12]    This bit is the complement of the UART Out1 nUARTOut1 modem status output. That is, when the bit is programmed to a 1 the output is 0. For DTE this can be used as Data Carrier Detect DCD. 
       @ .equ UARTCR_RTS [11:11]    Request to send. This bit is the complement of the UART request to send, nUARTRTS, modem status output. That is, when the bit is programmed to a 1 then nUARTRTS is LOW. 
       @ .equ UARTCR_DTR [10:10]    Data transmit ready. This bit is the complement of the UART data transmit ready, nUARTDTR, modem status output. That is, when the bit is programmed to a 1 then nUARTDTR is LOW. 
       @ .equ UARTCR_RXE [9:9]    Receive enable. If this bit is set to 1, the receive section of the UART is enabled. Data reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of reception, it completes the current character before stopping. 
       @ .equ UARTCR_TXE [8:8]    Transmit enable. If this bit is set to 1, the transmit section of the UART is enabled. Data transmission occurs for either UART signals, or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of transmission, it completes the current character before stopping. 
       @ .equ UARTCR_LBE [7:7]    Loopback enable. If this bit is set to 1 and the SIREN bit is set to 1 and the SIRTEST bit in the Test Control Register, UARTTCR is set to 1, then the nSIROUT path is inverted, and fed through to the SIRIN path. The SIRTEST bit in the test register must be set to 1 to override the normal half-duplex SIR operation. This must be the requirement for accessing the test registers during normal operation, and SIRTEST must be cleared to 0 when loopback testing is finished. This feature reduces the amount of external coupling required during system test. If this bit is set to 1, and the SIRTEST bit is set to 0, the UARTTXD path is fed through to the UARTRXD path. In either SIR mode or UART mode, when this bit is set, the modem outputs are also fed through to the modem inputs. This bit is cleared to 0 on reset, to disable loopback. 
       @ .equ UARTCR_SIRLP [2:2]    SIR low-power IrDA mode. This bit selects the IrDA encoding mode. If this bit is cleared to 0, low-level bits are transmitted as an active high pulse with a width of 3 / 16th of the bit period. If this bit is set to 1, low-level bits are transmitted with a pulse width that is 3 times the period of the IrLPBaud16 input signal, regardless of the selected bit rate. Setting this bit uses less power, but might reduce transmission distances. 
       @ .equ UARTCR_SIREN [1:1]    SIR enable: 0 = IrDA SIR ENDEC is disabled. nSIROUT remains LOW no light pulse generated, and signal transitions on SIRIN have no effect. 1 = IrDA SIR ENDEC is enabled. Data is transmitted and received on nSIROUT and SIRIN. UARTTXD remains HIGH, in the marking state. Signal transitions on UARTRXD or modem status inputs have no effect. This bit has no effect if the UARTEN bit disables the UART. 
       @ .equ UARTCR_UARTEN [0:0]    UART enable: 0 = UART is disabled. If the UART is disabled in the middle of transmission or reception, it completes the current character before stopping. 1 = the UART is enabled. Data transmission and reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. 
 
    .equ UART1_UARTIFLS, 0x0034 Interrupt FIFO Level Select Register, UARTIFLS
       @ .equ UARTIFLS_RXIFLSEL [5:3]    Receive interrupt FIFO level select. The trigger points for the receive interrupt are as follows: b000 = Receive FIFO becomes >= 1 / 8 full b001 = Receive FIFO becomes >= 1 / 4 full b010 = Receive FIFO becomes >= 1 / 2 full b011 = Receive FIFO becomes >= 3 / 4 full b100 = Receive FIFO becomes >= 7 / 8 full b101-b111 = reserved. 
       @ .equ UARTIFLS_TXIFLSEL [2:0]    Transmit interrupt FIFO level select. The trigger points for the transmit interrupt are as follows: b000 = Transmit FIFO becomes <= 1 / 8 full b001 = Transmit FIFO becomes <= 1 / 4 full b010 = Transmit FIFO becomes <= 1 / 2 full b011 = Transmit FIFO becomes <= 3 / 4 full b100 = Transmit FIFO becomes <= 7 / 8 full b101-b111 = reserved. 
 
    .equ UART1_UARTIMSC, 0x0038 Interrupt Mask Set/Clear Register, UARTIMSC
       @ .equ UARTIMSC_OEIM [10:10]    Overrun error interrupt mask. A read returns the current mask for the UARTOEINTR interrupt. On a write of 1, the mask of the UARTOEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_BEIM [9:9]    Break error interrupt mask. A read returns the current mask for the UARTBEINTR interrupt. On a write of 1, the mask of the UARTBEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_PEIM [8:8]    Parity error interrupt mask. A read returns the current mask for the UARTPEINTR interrupt. On a write of 1, the mask of the UARTPEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_FEIM [7:7]    Framing error interrupt mask. A read returns the current mask for the UARTFEINTR interrupt. On a write of 1, the mask of the UARTFEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_RTIM [6:6]    Receive timeout interrupt mask. A read returns the current mask for the UARTRTINTR interrupt. On a write of 1, the mask of the UARTRTINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_TXIM [5:5]    Transmit interrupt mask. A read returns the current mask for the UARTTXINTR interrupt. On a write of 1, the mask of the UARTTXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_RXIM [4:4]    Receive interrupt mask. A read returns the current mask for the UARTRXINTR interrupt. On a write of 1, the mask of the UARTRXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_DSRMIM [3:3]    nUARTDSR modem interrupt mask. A read returns the current mask for the UARTDSRINTR interrupt. On a write of 1, the mask of the UARTDSRINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_DCDMIM [2:2]    nUARTDCD modem interrupt mask. A read returns the current mask for the UARTDCDINTR interrupt. On a write of 1, the mask of the UARTDCDINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_CTSMIM [1:1]    nUARTCTS modem interrupt mask. A read returns the current mask for the UARTCTSINTR interrupt. On a write of 1, the mask of the UARTCTSINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UARTIMSC_RIMIM [0:0]    nUARTRI modem interrupt mask. A read returns the current mask for the UARTRIINTR interrupt. On a write of 1, the mask of the UARTRIINTR interrupt is set. A write of 0 clears the mask. 
 
    .equ UART1_UARTRIS, 0x003c Raw Interrupt Status Register, UARTRIS
       @ .equ UARTRIS_OERIS [10:10]    Overrun error interrupt status. Returns the raw interrupt state of the UARTOEINTR interrupt. 
       @ .equ UARTRIS_BERIS [9:9]    Break error interrupt status. Returns the raw interrupt state of the UARTBEINTR interrupt. 
       @ .equ UARTRIS_PERIS [8:8]    Parity error interrupt status. Returns the raw interrupt state of the UARTPEINTR interrupt. 
       @ .equ UARTRIS_FERIS [7:7]    Framing error interrupt status. Returns the raw interrupt state of the UARTFEINTR interrupt. 
       @ .equ UARTRIS_RTRIS [6:6]    Receive timeout interrupt status. Returns the raw interrupt state of the UARTRTINTR interrupt. a 
       @ .equ UARTRIS_TXRIS [5:5]    Transmit interrupt status. Returns the raw interrupt state of the UARTTXINTR interrupt. 
       @ .equ UARTRIS_RXRIS [4:4]    Receive interrupt status. Returns the raw interrupt state of the UARTRXINTR interrupt. 
       @ .equ UARTRIS_DSRRMIS [3:3]    nUARTDSR modem interrupt status. Returns the raw interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UARTRIS_DCDRMIS [2:2]    nUARTDCD modem interrupt status. Returns the raw interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UARTRIS_CTSRMIS [1:1]    nUARTCTS modem interrupt status. Returns the raw interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UARTRIS_RIRMIS [0:0]    nUARTRI modem interrupt status. Returns the raw interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART1_UARTMIS, 0x0040 Masked Interrupt Status Register, UARTMIS
       @ .equ UARTMIS_OEMIS [10:10]    Overrun error masked interrupt status. Returns the masked interrupt state of the UARTOEINTR interrupt. 
       @ .equ UARTMIS_BEMIS [9:9]    Break error masked interrupt status. Returns the masked interrupt state of the UARTBEINTR interrupt. 
       @ .equ UARTMIS_PEMIS [8:8]    Parity error masked interrupt status. Returns the masked interrupt state of the UARTPEINTR interrupt. 
       @ .equ UARTMIS_FEMIS [7:7]    Framing error masked interrupt status. Returns the masked interrupt state of the UARTFEINTR interrupt. 
       @ .equ UARTMIS_RTMIS [6:6]    Receive timeout masked interrupt status. Returns the masked interrupt state of the UARTRTINTR interrupt. 
       @ .equ UARTMIS_TXMIS [5:5]    Transmit masked interrupt status. Returns the masked interrupt state of the UARTTXINTR interrupt. 
       @ .equ UARTMIS_RXMIS [4:4]    Receive masked interrupt status. Returns the masked interrupt state of the UARTRXINTR interrupt. 
       @ .equ UARTMIS_DSRMMIS [3:3]    nUARTDSR modem masked interrupt status. Returns the masked interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UARTMIS_DCDMMIS [2:2]    nUARTDCD modem masked interrupt status. Returns the masked interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UARTMIS_CTSMMIS [1:1]    nUARTCTS modem masked interrupt status. Returns the masked interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UARTMIS_RIMMIS [0:0]    nUARTRI modem masked interrupt status. Returns the masked interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART1_UARTICR, 0x0044 Interrupt Clear Register, UARTICR
       @ .equ UARTICR_OEIC [10:10]    Overrun error interrupt clear. Clears the UARTOEINTR interrupt. 
       @ .equ UARTICR_BEIC [9:9]    Break error interrupt clear. Clears the UARTBEINTR interrupt. 
       @ .equ UARTICR_PEIC [8:8]    Parity error interrupt clear. Clears the UARTPEINTR interrupt. 
       @ .equ UARTICR_FEIC [7:7]    Framing error interrupt clear. Clears the UARTFEINTR interrupt. 
       @ .equ UARTICR_RTIC [6:6]    Receive timeout interrupt clear. Clears the UARTRTINTR interrupt. 
       @ .equ UARTICR_TXIC [5:5]    Transmit interrupt clear. Clears the UARTTXINTR interrupt. 
       @ .equ UARTICR_RXIC [4:4]    Receive interrupt clear. Clears the UARTRXINTR interrupt. 
       @ .equ UARTICR_DSRMIC [3:3]    nUARTDSR modem interrupt clear. Clears the UARTDSRINTR interrupt. 
       @ .equ UARTICR_DCDMIC [2:2]    nUARTDCD modem interrupt clear. Clears the UARTDCDINTR interrupt. 
       @ .equ UARTICR_CTSMIC [1:1]    nUARTCTS modem interrupt clear. Clears the UARTCTSINTR interrupt. 
       @ .equ UARTICR_RIMIC [0:0]    nUARTRI modem interrupt clear. Clears the UARTRIINTR interrupt. 
 
    .equ UART1_UARTDMACR, 0x0048 DMA Control Register, UARTDMACR
       @ .equ UARTDMACR_DMAONERR [2:2]    DMA on error. If this bit is set to 1, the DMA receive request outputs, UARTRXDMASREQ or UARTRXDMABREQ, are disabled when the UART error interrupt is asserted. 
       @ .equ UARTDMACR_TXDMAE [1:1]    Transmit DMA enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ UARTDMACR_RXDMAE [0:0]    Receive DMA enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ UART1_UARTPERIPHID0, 0x0fe0 UARTPeriphID0 Register
       @ .equ UARTPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x11 
 
    .equ UART1_UARTPERIPHID1, 0x0fe4 UARTPeriphID1 Register
       @ .equ UARTPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ UARTPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ UART1_UARTPERIPHID2, 0x0fe8 UARTPeriphID2 Register
       @ .equ UARTPERIPHID2_REVISION [7:4]    This field depends on the revision of the UART: r1p0 0x0 r1p1 0x1 r1p3 0x2 r1p4 0x2 r1p5 0x3 
       @ .equ UARTPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ UART1_UARTPERIPHID3, 0x0fec UARTPeriphID3 Register
       @ .equ UARTPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ UART1_UARTPCELLID0, 0x0ff0 UARTPCellID0 Register
       @ .equ UARTPCELLID0_UARTPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ UART1_UARTPCELLID1, 0x0ff4 UARTPCellID1 Register
       @ .equ UARTPCELLID1_UARTPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ UART1_UARTPCELLID2, 0x0ff8 UARTPCellID2 Register
       @ .equ UARTPCELLID2_UARTPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ UART1_UARTPCELLID3, 0x0ffc UARTPCellID3 Register
       @ .equ UARTPCELLID3_UARTPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== SPI0 ===========================@
.equ SPI0_BASE, 0x4003c000 
    .equ SPI0_SSPCR0, 0x0000 Control register 0, SSPCR0 on page 3-4
       @ .equ SSPCR0_SCR [15:8]    Serial clock rate. The value SCR is used to generate the transmit and receive bit rate of the PrimeCell SSP. The bit rate is: F SSPCLK CPSDVSR x 1+SCR where CPSDVSR is an even value from 2-254, programmed through the SSPCPSR register and SCR is a value from 0-255. 
       @ .equ SSPCR0_SPH [7:7]    SSPCLKOUT phase, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SSPCR0_SPO [6:6]    SSPCLKOUT polarity, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SSPCR0_FRF [5:4]    Frame format: 00 Motorola SPI frame format. 01 TI synchronous serial frame format. 10 National Microwire frame format. 11 Reserved, undefined operation. 
       @ .equ SSPCR0_DSS [3:0]    Data Size Select: 0000 Reserved, undefined operation. 0001 Reserved, undefined operation. 0010 Reserved, undefined operation. 0011 4-bit data. 0100 5-bit data. 0101 6-bit data. 0110 7-bit data. 0111 8-bit data. 1000 9-bit data. 1001 10-bit data. 1010 11-bit data. 1011 12-bit data. 1100 13-bit data. 1101 14-bit data. 1110 15-bit data. 1111 16-bit data. 
 
    .equ SPI0_SSPCR1, 0x0004 Control register 1, SSPCR1 on page 3-5
       @ .equ SSPCR1_SOD [3:3]    Slave-mode output disable. This bit is relevant only in the slave mode, MS=1. In multiple-slave systems, it is possible for an PrimeCell SSP master to broadcast a message to all slaves in the system while ensuring that only one slave drives data onto its serial output line. In such systems the RXD lines from multiple slaves could be tied together. To operate in such systems, the SOD bit can be set if the PrimeCell SSP slave is not supposed to drive the SSPTXD line: 0 SSP can drive the SSPTXD output in slave mode. 1 SSP must not drive the SSPTXD output in slave mode. 
       @ .equ SSPCR1_MS [2:2]    Master or slave mode select. This bit can be modified only when the PrimeCell SSP is disabled, SSE=0: 0 Device configured as master, default. 1 Device configured as slave. 
       @ .equ SSPCR1_SSE [1:1]    Synchronous serial port enable: 0 SSP operation disabled. 1 SSP operation enabled. 
       @ .equ SSPCR1_LBM [0:0]    Loop back mode: 0 Normal serial port operation enabled. 1 Output of transmit serial shifter is connected to input of receive serial shifter internally. 
 
    .equ SPI0_SSPDR, 0x0008 Data register, SSPDR on page 3-6
       @ .equ SSPDR_DATA [15:0]    Transmit/Receive FIFO: Read Receive FIFO. Write Transmit FIFO. You must right-justify data when the PrimeCell SSP is programmed for a data size that is less than 16 bits. Unused bits at the top are ignored by transmit logic. The receive logic automatically right-justifies. 
 
    .equ SPI0_SSPSR, 0x000c Status register, SSPSR on page 3-7
       @ .equ SSPSR_BSY [4:4]    PrimeCell SSP busy flag, RO: 0 SSP is idle. 1 SSP is currently transmitting and/or receiving a frame or the transmit FIFO is not empty. 
       @ .equ SSPSR_RFF [3:3]    Receive FIFO full, RO: 0 Receive FIFO is not full. 1 Receive FIFO is full. 
       @ .equ SSPSR_RNE [2:2]    Receive FIFO not empty, RO: 0 Receive FIFO is empty. 1 Receive FIFO is not empty. 
       @ .equ SSPSR_TNF [1:1]    Transmit FIFO not full, RO: 0 Transmit FIFO is full. 1 Transmit FIFO is not full. 
       @ .equ SSPSR_TFE [0:0]    Transmit FIFO empty, RO: 0 Transmit FIFO is not empty. 1 Transmit FIFO is empty. 
 
    .equ SPI0_SSPCPSR, 0x0010 Clock prescale register, SSPCPSR on page 3-8
       @ .equ SSPCPSR_CPSDVSR [7:0]    Clock prescale divisor. Must be an even number from 2-254, depending on the frequency of SSPCLK. The least significant bit always returns zero on reads. 
 
    .equ SPI0_SSPIMSC, 0x0014 Interrupt mask set or clear register, SSPIMSC on page 3-9
       @ .equ SSPIMSC_TXIM [3:3]    Transmit FIFO interrupt mask: 0 Transmit FIFO half empty or less condition interrupt is masked. 1 Transmit FIFO half empty or less condition interrupt is not masked. 
       @ .equ SSPIMSC_RXIM [2:2]    Receive FIFO interrupt mask: 0 Receive FIFO half full or less condition interrupt is masked. 1 Receive FIFO half full or less condition interrupt is not masked. 
       @ .equ SSPIMSC_RTIM [1:1]    Receive timeout interrupt mask: 0 Receive FIFO not empty and no read prior to timeout period interrupt is masked. 1 Receive FIFO not empty and no read prior to timeout period interrupt is not masked. 
       @ .equ SSPIMSC_RORIM [0:0]    Receive overrun interrupt mask: 0 Receive FIFO written to while full condition interrupt is masked. 1 Receive FIFO written to while full condition interrupt is not masked. 
 
    .equ SPI0_SSPRIS, 0x0018 Raw interrupt status register, SSPRIS on page 3-10
       @ .equ SSPRIS_TXRIS [3:3]    Gives the raw interrupt state, prior to masking, of the SSPTXINTR interrupt 
       @ .equ SSPRIS_RXRIS [2:2]    Gives the raw interrupt state, prior to masking, of the SSPRXINTR interrupt 
       @ .equ SSPRIS_RTRIS [1:1]    Gives the raw interrupt state, prior to masking, of the SSPRTINTR interrupt 
       @ .equ SSPRIS_RORRIS [0:0]    Gives the raw interrupt state, prior to masking, of the SSPRORINTR interrupt 
 
    .equ SPI0_SSPMIS, 0x001c Masked interrupt status register, SSPMIS on page 3-11
       @ .equ SSPMIS_TXMIS [3:3]    Gives the transmit FIFO masked interrupt state, after masking, of the SSPTXINTR interrupt 
       @ .equ SSPMIS_RXMIS [2:2]    Gives the receive FIFO masked interrupt state, after masking, of the SSPRXINTR interrupt 
       @ .equ SSPMIS_RTMIS [1:1]    Gives the receive timeout masked interrupt state, after masking, of the SSPRTINTR interrupt 
       @ .equ SSPMIS_RORMIS [0:0]    Gives the receive over run masked interrupt status, after masking, of the SSPRORINTR interrupt 
 
    .equ SPI0_SSPICR, 0x0020 Interrupt clear register, SSPICR on page 3-11
       @ .equ SSPICR_RTIC [1:1]    Clears the SSPRTINTR interrupt 
       @ .equ SSPICR_RORIC [0:0]    Clears the SSPRORINTR interrupt 
 
    .equ SPI0_SSPDMACR, 0x0024 DMA control register, SSPDMACR on page 3-12
       @ .equ SSPDMACR_TXDMAE [1:1]    Transmit DMA Enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ SSPDMACR_RXDMAE [0:0]    Receive DMA Enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ SPI0_SSPPERIPHID0, 0x0fe0 Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x22 
 
    .equ SPI0_SSPPERIPHID1, 0x0fe4 Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ SSPPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ SPI0_SSPPERIPHID2, 0x0fe8 Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID2_REVISION [7:4]    These bits return the peripheral revision 
       @ .equ SSPPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ SPI0_SSPPERIPHID3, 0x0fec Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ SPI0_SSPPCELLID0, 0x0ff0 PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID0_SSPPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ SPI0_SSPPCELLID1, 0x0ff4 PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID1_SSPPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ SPI0_SSPPCELLID2, 0x0ff8 PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID2_SSPPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ SPI0_SSPPCELLID3, 0x0ffc PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID3_SSPPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== SPI1 ===========================@
.equ SPI1_BASE, 0x40040000 
    .equ SPI1_SSPCR0, 0x0000 Control register 0, SSPCR0 on page 3-4
       @ .equ SSPCR0_SCR [15:8]    Serial clock rate. The value SCR is used to generate the transmit and receive bit rate of the PrimeCell SSP. The bit rate is: F SSPCLK CPSDVSR x 1+SCR where CPSDVSR is an even value from 2-254, programmed through the SSPCPSR register and SCR is a value from 0-255. 
       @ .equ SSPCR0_SPH [7:7]    SSPCLKOUT phase, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SSPCR0_SPO [6:6]    SSPCLKOUT polarity, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SSPCR0_FRF [5:4]    Frame format: 00 Motorola SPI frame format. 01 TI synchronous serial frame format. 10 National Microwire frame format. 11 Reserved, undefined operation. 
       @ .equ SSPCR0_DSS [3:0]    Data Size Select: 0000 Reserved, undefined operation. 0001 Reserved, undefined operation. 0010 Reserved, undefined operation. 0011 4-bit data. 0100 5-bit data. 0101 6-bit data. 0110 7-bit data. 0111 8-bit data. 1000 9-bit data. 1001 10-bit data. 1010 11-bit data. 1011 12-bit data. 1100 13-bit data. 1101 14-bit data. 1110 15-bit data. 1111 16-bit data. 
 
    .equ SPI1_SSPCR1, 0x0004 Control register 1, SSPCR1 on page 3-5
       @ .equ SSPCR1_SOD [3:3]    Slave-mode output disable. This bit is relevant only in the slave mode, MS=1. In multiple-slave systems, it is possible for an PrimeCell SSP master to broadcast a message to all slaves in the system while ensuring that only one slave drives data onto its serial output line. In such systems the RXD lines from multiple slaves could be tied together. To operate in such systems, the SOD bit can be set if the PrimeCell SSP slave is not supposed to drive the SSPTXD line: 0 SSP can drive the SSPTXD output in slave mode. 1 SSP must not drive the SSPTXD output in slave mode. 
       @ .equ SSPCR1_MS [2:2]    Master or slave mode select. This bit can be modified only when the PrimeCell SSP is disabled, SSE=0: 0 Device configured as master, default. 1 Device configured as slave. 
       @ .equ SSPCR1_SSE [1:1]    Synchronous serial port enable: 0 SSP operation disabled. 1 SSP operation enabled. 
       @ .equ SSPCR1_LBM [0:0]    Loop back mode: 0 Normal serial port operation enabled. 1 Output of transmit serial shifter is connected to input of receive serial shifter internally. 
 
    .equ SPI1_SSPDR, 0x0008 Data register, SSPDR on page 3-6
       @ .equ SSPDR_DATA [15:0]    Transmit/Receive FIFO: Read Receive FIFO. Write Transmit FIFO. You must right-justify data when the PrimeCell SSP is programmed for a data size that is less than 16 bits. Unused bits at the top are ignored by transmit logic. The receive logic automatically right-justifies. 
 
    .equ SPI1_SSPSR, 0x000c Status register, SSPSR on page 3-7
       @ .equ SSPSR_BSY [4:4]    PrimeCell SSP busy flag, RO: 0 SSP is idle. 1 SSP is currently transmitting and/or receiving a frame or the transmit FIFO is not empty. 
       @ .equ SSPSR_RFF [3:3]    Receive FIFO full, RO: 0 Receive FIFO is not full. 1 Receive FIFO is full. 
       @ .equ SSPSR_RNE [2:2]    Receive FIFO not empty, RO: 0 Receive FIFO is empty. 1 Receive FIFO is not empty. 
       @ .equ SSPSR_TNF [1:1]    Transmit FIFO not full, RO: 0 Transmit FIFO is full. 1 Transmit FIFO is not full. 
       @ .equ SSPSR_TFE [0:0]    Transmit FIFO empty, RO: 0 Transmit FIFO is not empty. 1 Transmit FIFO is empty. 
 
    .equ SPI1_SSPCPSR, 0x0010 Clock prescale register, SSPCPSR on page 3-8
       @ .equ SSPCPSR_CPSDVSR [7:0]    Clock prescale divisor. Must be an even number from 2-254, depending on the frequency of SSPCLK. The least significant bit always returns zero on reads. 
 
    .equ SPI1_SSPIMSC, 0x0014 Interrupt mask set or clear register, SSPIMSC on page 3-9
       @ .equ SSPIMSC_TXIM [3:3]    Transmit FIFO interrupt mask: 0 Transmit FIFO half empty or less condition interrupt is masked. 1 Transmit FIFO half empty or less condition interrupt is not masked. 
       @ .equ SSPIMSC_RXIM [2:2]    Receive FIFO interrupt mask: 0 Receive FIFO half full or less condition interrupt is masked. 1 Receive FIFO half full or less condition interrupt is not masked. 
       @ .equ SSPIMSC_RTIM [1:1]    Receive timeout interrupt mask: 0 Receive FIFO not empty and no read prior to timeout period interrupt is masked. 1 Receive FIFO not empty and no read prior to timeout period interrupt is not masked. 
       @ .equ SSPIMSC_RORIM [0:0]    Receive overrun interrupt mask: 0 Receive FIFO written to while full condition interrupt is masked. 1 Receive FIFO written to while full condition interrupt is not masked. 
 
    .equ SPI1_SSPRIS, 0x0018 Raw interrupt status register, SSPRIS on page 3-10
       @ .equ SSPRIS_TXRIS [3:3]    Gives the raw interrupt state, prior to masking, of the SSPTXINTR interrupt 
       @ .equ SSPRIS_RXRIS [2:2]    Gives the raw interrupt state, prior to masking, of the SSPRXINTR interrupt 
       @ .equ SSPRIS_RTRIS [1:1]    Gives the raw interrupt state, prior to masking, of the SSPRTINTR interrupt 
       @ .equ SSPRIS_RORRIS [0:0]    Gives the raw interrupt state, prior to masking, of the SSPRORINTR interrupt 
 
    .equ SPI1_SSPMIS, 0x001c Masked interrupt status register, SSPMIS on page 3-11
       @ .equ SSPMIS_TXMIS [3:3]    Gives the transmit FIFO masked interrupt state, after masking, of the SSPTXINTR interrupt 
       @ .equ SSPMIS_RXMIS [2:2]    Gives the receive FIFO masked interrupt state, after masking, of the SSPRXINTR interrupt 
       @ .equ SSPMIS_RTMIS [1:1]    Gives the receive timeout masked interrupt state, after masking, of the SSPRTINTR interrupt 
       @ .equ SSPMIS_RORMIS [0:0]    Gives the receive over run masked interrupt status, after masking, of the SSPRORINTR interrupt 
 
    .equ SPI1_SSPICR, 0x0020 Interrupt clear register, SSPICR on page 3-11
       @ .equ SSPICR_RTIC [1:1]    Clears the SSPRTINTR interrupt 
       @ .equ SSPICR_RORIC [0:0]    Clears the SSPRORINTR interrupt 
 
    .equ SPI1_SSPDMACR, 0x0024 DMA control register, SSPDMACR on page 3-12
       @ .equ SSPDMACR_TXDMAE [1:1]    Transmit DMA Enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ SSPDMACR_RXDMAE [0:0]    Receive DMA Enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ SPI1_SSPPERIPHID0, 0x0fe0 Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x22 
 
    .equ SPI1_SSPPERIPHID1, 0x0fe4 Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ SSPPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ SPI1_SSPPERIPHID2, 0x0fe8 Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID2_REVISION [7:4]    These bits return the peripheral revision 
       @ .equ SSPPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ SPI1_SSPPERIPHID3, 0x0fec Peripheral identification registers, SSPPeriphID0-3 on page 3-13
       @ .equ SSPPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ SPI1_SSPPCELLID0, 0x0ff0 PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID0_SSPPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ SPI1_SSPPCELLID1, 0x0ff4 PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID1_SSPPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ SPI1_SSPPCELLID2, 0x0ff8 PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID2_SSPPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ SPI1_SSPPCELLID3, 0x0ffc PrimeCell identification registers, SSPPCellID0-3 on page 3-16
       @ .equ SSPPCELLID3_SSPPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== I2C0 ===========================@
.equ I2C0_BASE, 0x40044000 DW_apb_i2c address block
    .equ I2C0_IC_CON, 0x0000 I2C Control Register. This register can be written only when the DW_apb_i2c is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  Read/Write Access: - bit 10 is read only. - bit 11 is read only - bit 16 is read only - bit 17 is read only - bits 18 and 19 are read only.
       @ .equ IC_CON_STOP_DET_IF_MASTER_ACTIVE [10:10]    Master issues the STOP_DET interrupt irrespective of whether master is active or not 
       @ .equ IC_CON_RX_FIFO_FULL_HLD_CTRL [9:9]    This bit controls whether DW_apb_i2c should hold the bus when the Rx FIFO is physically full to its RX_BUFFER_DEPTH, as described in the IC_RX_FULL_HLD_BUS_EN parameter.  Reset value: 0x0. 
       @ .equ IC_CON_TX_EMPTY_CTRL [8:8]    This bit controls the generation of the TX_EMPTY interrupt, as described in the IC_RAW_INTR_STAT register.  Reset value: 0x0. 
       @ .equ IC_CON_STOP_DET_IFADDRESSED [7:7]    In slave mode: - 1'b1: issues the STOP_DET interrupt only when it is addressed. - 1'b0: issues the STOP_DET irrespective of whether it's addressed or not. Reset value: 0x0  NOTE: During a general call address, this slave does not issue the STOP_DET interrupt if STOP_DET_IF_ADDRESSED = 1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. 
       @ .equ IC_CON_IC_SLAVE_DISABLE [6:6]    This bit controls whether I2C has its slave disabled, which means once the presetn signal is applied, then this bit is set and the slave is disabled.  If this bit is set slave is disabled, DW_apb_i2c functions only as a master and does not perform any action that requires a slave.  NOTE: Software should ensure that if this bit is written with 0, then bit 0 should also be written with a 0. 
       @ .equ IC_CON_IC_RESTART_EN [5:5]    Determines whether RESTART conditions may be sent when acting as a master. Some older slaves do not support handling RESTART conditions; however, RESTART conditions are used in several DW_apb_i2c operations. When RESTART is disabled, the master is prohibited from performing the following functions: - Sending a START BYTE - Performing any high-speed mode operation - High-speed mode operation - Performing direction changes in combined format mode - Performing a read operation with a 10-bit address By replacing RESTART condition followed by a STOP and a subsequent START condition, split operations are broken down into multiple DW_apb_i2c transfers. If the above operations are performed, it will result in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register.  Reset value: ENABLED 
       @ .equ IC_CON_IC_10BITADDR_MASTER [4:4]    Controls whether the DW_apb_i2c starts its transfers in 7- or 10-bit addressing mode when acting as a master. - 0: 7-bit addressing - 1: 10-bit addressing 
       @ .equ IC_CON_IC_10BITADDR_SLAVE [3:3]    When acting as a slave, this bit controls whether the DW_apb_i2c responds to 7- or 10-bit addresses. - 0: 7-bit addressing. The DW_apb_i2c ignores transactions that involve 10-bit addressing; for 7-bit addressing, only the lower 7 bits of the IC_SAR register are compared. - 1: 10-bit addressing. The DW_apb_i2c responds to only 10-bit addressing transfers that match the full 10 bits of the IC_SAR register. 
       @ .equ IC_CON_SPEED [2:1]    These bits control at which speed the DW_apb_i2c operates; its setting is relevant only if one is operating the DW_apb_i2c in master mode. Hardware protects against illegal values being programmed by software. These bits must be programmed appropriately for slave mode also, as it is used to capture correct value of spike filter as per the speed mode.  This register should be programmed only with a value in the range of 1 to IC_MAX_SPEED_MODE; otherwise, hardware updates this register with the value of IC_MAX_SPEED_MODE.  1: standard mode 100 kbit/s  2: fast mode <=400 kbit/s or fast mode plus <=1000Kbit/s  3: high speed mode 3.4 Mbit/s  Note: This field is not applicable when IC_ULTRA_FAST_MODE=1 
       @ .equ IC_CON_MASTER_MODE [0:0]    This bit controls whether the DW_apb_i2c master is enabled.  NOTE: Software should ensure that if this bit is written with '1' then bit 6 should also be written with a '1'. 
 
    .equ I2C0_IC_TAR, 0x0004 I2C Target Address Register  This register is 12 bits wide, and bits 31:12 are reserved. This register can be written to only when IC_ENABLE[0] is set to 0.  Note: If the software or application is aware that the DW_apb_i2c is not using the TAR address for the pending commands in the Tx FIFO, then it is possible to update the TAR address even while the Tx FIFO has entries IC_STATUS[2]= 0. - It is not necessary to perform any write to this register if DW_apb_i2c is enabled as an I2C slave only.
       @ .equ IC_TAR_SPECIAL [11:11]    This bit indicates whether software performs a Device-ID or General Call or START BYTE command. - 0: ignore bit 10 GC_OR_START and use IC_TAR normally - 1: perform special I2C command as specified in Device_ID or GC_OR_START bit Reset value: 0x0 
       @ .equ IC_TAR_GC_OR_START [10:10]    If bit 11 SPECIAL is set to 1 and bit 13Device-ID is set to 0, then this bit indicates whether a General Call or START byte command is to be performed by the DW_apb_i2c. - 0: General Call Address - after issuing a General Call, only writes may be performed. Attempting to issue a read command results in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register. The DW_apb_i2c remains in General Call mode until the SPECIAL bit value bit 11 is cleared. - 1: START BYTE Reset value: 0x0 
       @ .equ IC_TAR_IC_TAR [9:0]    This is the target address for any master transaction. When transmitting a General Call, these bits are ignored. To generate a START BYTE, the CPU needs to write only once into these bits.  If the IC_TAR and IC_SAR are the same, loopback exists but the FIFOs are shared between master and slave, so full loopback is not feasible. Only one direction loopback mode is supported simplex, not duplex. A master cannot transmit to itself; it can transmit to only a slave. 
 
    .equ I2C0_IC_SAR, 0x0008 I2C Slave Address Register
       @ .equ IC_SAR_IC_SAR [9:0]    The IC_SAR holds the slave address when the I2C is operating as a slave. For 7-bit addressing, only IC_SAR[6:0] is used.  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  Note: The default values cannot be any of the reserved address locations: that is, 0x00 to 0x07, or 0x78 to 0x7f. The correct operation of the device is not guaranteed if you program the IC_SAR or IC_TAR to a reserved value. Refer to <<table_I2C_firstbyte_bit_defs>> for a complete list of these reserved values. 
 
    .equ I2C0_IC_DATA_CMD, 0x0010 I2C Rx/Tx Data Buffer and Command Register; this is the register the CPU writes to when filling the TX FIFO and the CPU reads from when retrieving bytes from RX FIFO.  The size of the register changes as follows:  Write: - 11 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=1 - 9 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=0 Read: - 12 bits when IC_FIRST_DATA_BYTE_STATUS = 1 - 8 bits when IC_FIRST_DATA_BYTE_STATUS = 0 Note: In order for the DW_apb_i2c to continue acknowledging reads, a read command should be written for every byte that is to be received; otherwise the DW_apb_i2c will stop acknowledging.
       @ .equ IC_DATA_CMD_FIRST_DATA_BYTE [11:11]    Indicates the first data byte received after the address phase for receive transfer in Master receiver or Slave receiver mode.  Reset value : 0x0  NOTE: In case of APB_DATA_WIDTH=8,  1. The user has to perform two APB Reads to IC_DATA_CMD in order to get status on 11 bit.  2. In order to read the 11 bit, the user has to perform the first data byte read [7:0] offset 0x10 and then perform the second read [15:8] offset 0x11 in order to know the status of 11 bit whether the data received in previous read is a first data byte or not.  3. The 11th bit is an optional read field, user can ignore 2nd byte read [15:8] offset 0x11 if not interested in FIRST_DATA_BYTE status. 
       @ .equ IC_DATA_CMD_RESTART [10:10]    This bit controls whether a RESTART is issued before the byte is sent or received.  1 - If IC_RESTART_EN is 1, a RESTART is issued before the data is sent/received according to the value of CMD, regardless of whether or not the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.  0 - If IC_RESTART_EN is 1, a RESTART is issued only if the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.  Reset value: 0x0 
       @ .equ IC_DATA_CMD_STOP [9:9]    This bit controls whether a STOP is issued after the byte is sent or received.  - 1 - STOP is issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master immediately tries to start a new transfer by issuing a START and arbitrating for the bus. - 0 - STOP is not issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master continues the current transfer by sending/receiving data bytes according to the value of the CMD bit. If the Tx FIFO is empty, the master holds the SCL line low and stalls the bus until a new command is available in the Tx FIFO. Reset value: 0x0 
       @ .equ IC_DATA_CMD_CMD [8:8]    This bit controls whether a read or a write is performed. This bit does not control the direction when the DW_apb_i2con acts as a slave. It controls only the direction when it acts as a master.  When a command is entered in the TX FIFO, this bit distinguishes the write and read commands. In slave-receiver mode, this bit is a 'don't care' because writes to this register are not required. In slave-transmitter mode, a '0' indicates that the data in IC_DATA_CMD is to be transmitted.  When programming this bit, you should remember the following: attempting to perform a read operation after a General Call command has been sent results in a TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, unless bit 11 SPECIAL in the IC_TAR register has been cleared. If a '1' is written to this bit after receiving a RD_REQ interrupt, then a TX_ABRT interrupt occurs.  Reset value: 0x0 
       @ .equ IC_DATA_CMD_DAT [7:0]    This register contains the data to be transmitted or received on the I2C bus. If you are writing to this register and want to perform a read, bits 7:0 DAT are ignored by the DW_apb_i2c. However, when you read this register, these bits return the value of data received on the DW_apb_i2c interface.  Reset value: 0x0 
 
    .equ I2C0_IC_SS_SCL_HCNT, 0x0014 Standard Speed I2C Clock SCL High Count Register
       @ .equ IC_SS_SCL_HCNT_IC_SS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'.  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed.  NOTE: This register must not be programmed to a value higher than 65525, because DW_apb_i2c uses a 16-bit counter to flag an I2C bus idle condition when this counter reaches a value of IC_SS_SCL_HCNT + 10. 
 
    .equ I2C0_IC_SS_SCL_LCNT, 0x0018 Standard Speed I2C Clock SCL Low Count Register
       @ .equ IC_SS_SCL_LCNT_IC_SS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted, results in 8 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of DW_apb_i2c. The lower byte must be programmed first, and then the upper byte is programmed. 
 
    .equ I2C0_IC_FS_SCL_HCNT, 0x001c Fast Mode or Fast Mode Plus I2C Clock SCL High Count Register
       @ .equ IC_FS_SCL_HCNT_IC_FS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for fast mode or fast mode plus. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard. This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH == 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. 
 
    .equ I2C0_IC_FS_SCL_LCNT, 0x0020 Fast Mode or Fast Mode Plus I2C Clock SCL Low Count Register
       @ .equ IC_FS_SCL_LCNT_IC_FS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for fast speed. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard.  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted results in 8 being set. For designs with APB_DATA_WIDTH = 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. If the value is less than 8 then the count value gets changed to 8. 
 
    .equ I2C0_IC_INTR_STAT, 0x002c I2C Interrupt Status Register  Each bit in this register has a corresponding mask bit in the IC_INTR_MASK register. These bits are cleared by reading the matching interrupt clear register. The unmasked raw versions of these bits are available in the IC_RAW_INTR_STAT register.
       @ .equ IC_INTR_STAT_R_MASTER_ON_HOLD [13:13]    See IC_RAW_INTR_STAT for a detailed description of R_MASTER_ON_HOLD bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RESTART_DET [12:12]    See IC_RAW_INTR_STAT for a detailed description of R_RESTART_DET bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_GEN_CALL [11:11]    See IC_RAW_INTR_STAT for a detailed description of R_GEN_CALL bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_START_DET [10:10]    See IC_RAW_INTR_STAT for a detailed description of R_START_DET bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_STOP_DET [9:9]    See IC_RAW_INTR_STAT for a detailed description of R_STOP_DET bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_ACTIVITY [8:8]    See IC_RAW_INTR_STAT for a detailed description of R_ACTIVITY bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_DONE [7:7]    See IC_RAW_INTR_STAT for a detailed description of R_RX_DONE bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_TX_ABRT [6:6]    See IC_RAW_INTR_STAT for a detailed description of R_TX_ABRT bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RD_REQ [5:5]    See IC_RAW_INTR_STAT for a detailed description of R_RD_REQ bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_TX_EMPTY [4:4]    See IC_RAW_INTR_STAT for a detailed description of R_TX_EMPTY bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_TX_OVER [3:3]    See IC_RAW_INTR_STAT for a detailed description of R_TX_OVER bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_FULL [2:2]    See IC_RAW_INTR_STAT for a detailed description of R_RX_FULL bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_OVER [1:1]    See IC_RAW_INTR_STAT for a detailed description of R_RX_OVER bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_UNDER [0:0]    See IC_RAW_INTR_STAT for a detailed description of R_RX_UNDER bit.  Reset value: 0x0 
 
    .equ I2C0_IC_INTR_MASK, 0x0030 I2C Interrupt Mask Register.  These bits mask their corresponding interrupt status bits. This register is active low; a value of 0 masks the interrupt, whereas a value of 1 unmasks the interrupt.
       @ .equ IC_INTR_MASK_M_MASTER_ON_HOLD_READ_ONLY [13:13]    This M_MASTER_ON_HOLD_read_only bit masks the R_MASTER_ON_HOLD interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_RESTART_DET [12:12]    This bit masks the R_RESTART_DET interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_GEN_CALL [11:11]    This bit masks the R_GEN_CALL interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_START_DET [10:10]    This bit masks the R_START_DET interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_STOP_DET [9:9]    This bit masks the R_STOP_DET interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_ACTIVITY [8:8]    This bit masks the R_ACTIVITY interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_RX_DONE [7:7]    This bit masks the R_RX_DONE interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_TX_ABRT [6:6]    This bit masks the R_TX_ABRT interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RD_REQ [5:5]    This bit masks the R_RD_REQ interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_TX_EMPTY [4:4]    This bit masks the R_TX_EMPTY interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_TX_OVER [3:3]    This bit masks the R_TX_OVER interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RX_FULL [2:2]    This bit masks the R_RX_FULL interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RX_OVER [1:1]    This bit masks the R_RX_OVER interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RX_UNDER [0:0]    This bit masks the R_RX_UNDER interrupt in IC_INTR_STAT register.  Reset value: 0x1 
 
    .equ I2C0_IC_RAW_INTR_STAT, 0x0034 I2C Raw Interrupt Status Register  Unlike the IC_INTR_STAT register, these bits are not masked so they always show the true status of the DW_apb_i2c.
       @ .equ IC_RAW_INTR_STAT_MASTER_ON_HOLD [13:13]    Indicates whether master is holding the bus and TX FIFO is empty. Enabled only when I2C_DYNAMIC_TAR_UPDATE=1 and IC_EMPTYFIFO_HOLD_MASTER_EN=1.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RESTART_DET [12:12]    Indicates whether a RESTART condition has occurred on the I2C interface when DW_apb_i2c is operating in Slave mode and the slave is being addressed. Enabled only when IC_SLV_RESTART_DET_EN=1.  Note: However, in high-speed mode or during a START BYTE transfer, the RESTART comes before the address field as per the I2C protocol. In this case, the slave is not the addressed slave when the RESTART is issued, therefore DW_apb_i2c does not generate the RESTART_DET interrupt.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_GEN_CALL [11:11]    Set only when a General Call address is received and it is acknowledged. It stays set until it is cleared either by disabling DW_apb_i2c or when the CPU reads bit 0 of the IC_CLR_GEN_CALL register. DW_apb_i2c stores the received data in the Rx buffer.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_START_DET [10:10]    Indicates whether a START or RESTART condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_STOP_DET [9:9]    Indicates whether a STOP condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.  In Slave Mode: - If IC_CON[7]=1'b1 STOP_DET_IFADDRESSED, the STOP_DET interrupt will be issued only if slave is addressed. Note: During a general call address, this slave does not issue a STOP_DET interrupt if STOP_DET_IF_ADDRESSED=1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. - If IC_CON[7]=1'b0 STOP_DET_IFADDRESSED, the STOP_DET interrupt is issued irrespective of whether it is being addressed. In Master Mode: - If IC_CON[10]=1'b1 STOP_DET_IF_MASTER_ACTIVE,the STOP_DET interrupt will be issued only if Master is active. - If IC_CON[10]=1'b0 STOP_DET_IFADDRESSED,the STOP_DET interrupt will be issued irrespective of whether master is active or not. Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_ACTIVITY [8:8]    This bit captures DW_apb_i2c activity and stays set until it is cleared. There are four ways to clear it: - Disabling the DW_apb_i2c - Reading the IC_CLR_ACTIVITY register - Reading the IC_CLR_INTR register - System reset Once this bit is set, it stays set unless one of the four methods is used to clear it. Even if the DW_apb_i2c module is idle, this bit remains set until cleared, indicating that there was activity on the bus.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_DONE [7:7]    When the DW_apb_i2c is acting as a slave-transmitter, this bit is set to 1 if the master does not acknowledge a transmitted byte. This occurs on the last byte of the transmission, indicating that the transmission is done.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_TX_ABRT [6:6]    This bit indicates if DW_apb_i2c, as an I2C transmitter, is unable to complete the intended actions on the contents of the transmit FIFO. This situation can occur both as an I2C master or an I2C slave, and is referred to as a 'transmit abort'. When this bit is set to 1, the IC_TX_ABRT_SOURCE register indicates the reason why the transmit abort takes places.  Note: The DW_apb_i2c flushes/resets/empties the TX_FIFO and RX_FIFO whenever there is a transmit abort caused by any of the events tracked by the IC_TX_ABRT_SOURCE register. The FIFOs remains in this flushed state until the register IC_CLR_TX_ABRT is read. Once this read is performed, the Tx FIFO is then ready to accept more data bytes from the APB interface.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RD_REQ [5:5]    This bit is set to 1 when DW_apb_i2c is acting as a slave and another I2C master is attempting to read data from DW_apb_i2c. The DW_apb_i2c holds the I2C bus in a wait state SCL=0 until this interrupt is serviced, which means that the slave has been addressed by a remote master that is asking for data to be transferred. The processor must respond to this interrupt and then write the requested data to the IC_DATA_CMD register. This bit is set to 0 just after the processor reads the IC_CLR_RD_REQ register.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_TX_EMPTY [4:4]    The behavior of the TX_EMPTY interrupt status differs based on the TX_EMPTY_CTRL selection in the IC_CON register. - When TX_EMPTY_CTRL = 0: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register. - When TX_EMPTY_CTRL = 1: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register and the transmission of the address/data from the internal shift register for the most recently popped command is completed. It is automatically cleared by hardware when the buffer level goes above the threshold. When IC_ENABLE[0] is set to 0, the TX FIFO is flushed and held in reset. There the TX FIFO looks like it has no data within it, so this bit is set to 1, provided there is activity in the master or slave state machines. When there is no longer any activity, then with ic_en=0, this bit is set to 0.  Reset value: 0x0. 
       @ .equ IC_RAW_INTR_STAT_TX_OVER [3:3]    Set during transmit if the transmit buffer is filled to IC_TX_BUFFER_DEPTH and the processor attempts to issue another I2C command by writing to the IC_DATA_CMD register. When the module is disabled, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_FULL [2:2]    Set when the receive buffer reaches or goes above the RX_TL threshold in the IC_RX_TL register. It is automatically cleared by hardware when buffer level goes below the threshold. If the module is disabled IC_ENABLE[0]=0, the RX FIFO is flushed and held in reset; therefore the RX FIFO is not full. So this bit is cleared once the IC_ENABLE bit 0 is programmed with a 0, regardless of the activity that continues.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_OVER [1:1]    Set if the receive buffer is completely filled to IC_RX_BUFFER_DEPTH and an additional byte is received from an external I2C device. The DW_apb_i2c acknowledges this, but any data bytes received after the FIFO is full are lost. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.  Note: If bit 9 of the IC_CON register RX_FIFO_FULL_HLD_CTRL is programmed to HIGH, then the RX_OVER interrupt never occurs, because the Rx FIFO never overflows.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_UNDER [0:0]    Set if the processor attempts to read the receive buffer when it is empty by reading from the IC_DATA_CMD register. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.  Reset value: 0x0 
 
    .equ I2C0_IC_RX_TL, 0x0038 I2C Receive FIFO Threshold Register
       @ .equ IC_RX_TL_RX_TL [7:0]    Receive FIFO Threshold Level.  Controls the level of entries or above that triggers the RX_FULL interrupt bit 2 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that hardware does not allow this value to be set to a value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 1 entry, and a value of 255 sets the threshold for 256 entries. 
 
    .equ I2C0_IC_TX_TL, 0x003c I2C Transmit FIFO Threshold Register
       @ .equ IC_TX_TL_TX_TL [7:0]    Transmit FIFO Threshold Level.  Controls the level of entries or below that trigger the TX_EMPTY interrupt bit 4 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that it may not be set to value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 0 entries, and a value of 255 sets the threshold for 255 entries. 
 
    .equ I2C0_IC_CLR_INTR, 0x0040 Clear Combined and Individual Interrupt Register
       @ .equ IC_CLR_INTR_CLR_INTR [0:0]    Read this register to clear the combined interrupt, all individual interrupts, and the IC_TX_ABRT_SOURCE register. This bit does not clear hardware clearable interrupts but software clearable interrupts. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RX_UNDER, 0x0044 Clear RX_UNDER Interrupt Register
       @ .equ IC_CLR_RX_UNDER_CLR_RX_UNDER [0:0]    Read this register to clear the RX_UNDER interrupt bit 0 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RX_OVER, 0x0048 Clear RX_OVER Interrupt Register
       @ .equ IC_CLR_RX_OVER_CLR_RX_OVER [0:0]    Read this register to clear the RX_OVER interrupt bit 1 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_TX_OVER, 0x004c Clear TX_OVER Interrupt Register
       @ .equ IC_CLR_TX_OVER_CLR_TX_OVER [0:0]    Read this register to clear the TX_OVER interrupt bit 3 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RD_REQ, 0x0050 Clear RD_REQ Interrupt Register
       @ .equ IC_CLR_RD_REQ_CLR_RD_REQ [0:0]    Read this register to clear the RD_REQ interrupt bit 5 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_TX_ABRT, 0x0054 Clear TX_ABRT Interrupt Register
       @ .equ IC_CLR_TX_ABRT_CLR_TX_ABRT [0:0]    Read this register to clear the TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, and the IC_TX_ABRT_SOURCE register. This also releases the TX FIFO from the flushed/reset state, allowing more writes to the TX FIFO. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RX_DONE, 0x0058 Clear RX_DONE Interrupt Register
       @ .equ IC_CLR_RX_DONE_CLR_RX_DONE [0:0]    Read this register to clear the RX_DONE interrupt bit 7 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_ACTIVITY, 0x005c Clear ACTIVITY Interrupt Register
       @ .equ IC_CLR_ACTIVITY_CLR_ACTIVITY [0:0]    Reading this register clears the ACTIVITY interrupt if the I2C is not active anymore. If the I2C module is still active on the bus, the ACTIVITY interrupt bit continues to be set. It is automatically cleared by hardware if the module is disabled and if there is no further activity on the bus. The value read from this register to get status of the ACTIVITY interrupt bit 8 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_STOP_DET, 0x0060 Clear STOP_DET Interrupt Register
       @ .equ IC_CLR_STOP_DET_CLR_STOP_DET [0:0]    Read this register to clear the STOP_DET interrupt bit 9 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_START_DET, 0x0064 Clear START_DET Interrupt Register
       @ .equ IC_CLR_START_DET_CLR_START_DET [0:0]    Read this register to clear the START_DET interrupt bit 10 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_GEN_CALL, 0x0068 Clear GEN_CALL Interrupt Register
       @ .equ IC_CLR_GEN_CALL_CLR_GEN_CALL [0:0]    Read this register to clear the GEN_CALL interrupt bit 11 of IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_ENABLE, 0x006c I2C Enable Register
       @ .equ IC_ENABLE_TX_CMD_BLOCK [2:2]    In Master mode: - 1'b1: Blocks the transmission of data on I2C bus even if Tx FIFO has data to transmit. - 1'b0: The transmission of data starts on I2C bus automatically, as soon as the first data is available in the Tx FIFO. Note: To block the execution of Master commands, set the TX_CMD_BLOCK bit only when Tx FIFO is empty IC_STATUS[2]==1 and Master is in Idle state IC_STATUS[5] == 0. Any further commands put in the Tx FIFO are not executed until TX_CMD_BLOCK bit is unset. Reset value: IC_TX_CMD_BLOCK_DEFAULT 
       @ .equ IC_ENABLE_ABORT [1:1]    When set, the controller initiates the transfer abort. - 0: ABORT not initiated or ABORT done - 1: ABORT operation in progress The software can abort the I2C transfer in master mode by setting this bit. The software can set this bit only when ENABLE is already set; otherwise, the controller ignores any write to ABORT bit. The software cannot clear the ABORT bit once set. In response to an ABORT, the controller issues a STOP and flushes the Tx FIFO after completing the current transfer, then sets the TX_ABORT interrupt after the abort operation. The ABORT bit is cleared automatically after the abort operation.  For a detailed description on how to abort I2C transfers, refer to 'Aborting I2C Transfers'.  Reset value: 0x0 
       @ .equ IC_ENABLE_ENABLE [0:0]    Controls whether the DW_apb_i2c is enabled. - 0: Disables DW_apb_i2c TX and RX FIFOs are held in an erased state - 1: Enables DW_apb_i2c Software can disable DW_apb_i2c while it is active. However, it is important that care be taken to ensure that DW_apb_i2c is disabled properly. A recommended procedure is described in 'Disabling DW_apb_i2c'.  When DW_apb_i2c is disabled, the following occurs: - The TX FIFO and RX FIFO get flushed. - Status bits in the IC_INTR_STAT register are still active until DW_apb_i2c goes into IDLE state. If the module is transmitting, it stops as well as deletes the contents of the transmit buffer after the current transfer is complete. If the module is receiving, the DW_apb_i2c stops the current transfer at the end of the current byte and does not acknowledge the transfer.  In systems with asynchronous pclk and ic_clk when IC_CLK_TYPE parameter set to asynchronous 1, there is a two ic_clk delay when enabling or disabling the DW_apb_i2c. For a detailed description on how to disable DW_apb_i2c, refer to 'Disabling DW_apb_i2c'  Reset value: 0x0 
 
    .equ I2C0_IC_STATUS, 0x0070 I2C Status Register  This is a read-only register used to indicate the current transfer status and FIFO status. The status register may be read at any time. None of the bits in this register request an interrupt.  When the I2C is disabled by writing 0 in bit 0 of the IC_ENABLE register: - Bits 1 and 2 are set to 1 - Bits 3 and 10 are set to 0 When the master or slave state machines goes to idle and ic_en=0: - Bits 5 and 6 are set to 0
       @ .equ IC_STATUS_SLV_ACTIVITY [6:6]    Slave FSM Activity Status. When the Slave Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Slave FSM is in IDLE state so the Slave part of DW_apb_i2c is not Active - 1: Slave FSM is not in IDLE state so the Slave part of DW_apb_i2c is Active Reset value: 0x0 
       @ .equ IC_STATUS_MST_ACTIVITY [5:5]    Master FSM Activity Status. When the Master Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Master FSM is in IDLE state so the Master part of DW_apb_i2c is not Active - 1: Master FSM is not in IDLE state so the Master part of DW_apb_i2c is Active Note: IC_STATUS[0]-that is, ACTIVITY bit-is the OR of SLV_ACTIVITY and MST_ACTIVITY bits.  Reset value: 0x0 
       @ .equ IC_STATUS_RFF [4:4]    Receive FIFO Completely Full. When the receive FIFO is completely full, this bit is set. When the receive FIFO contains one or more empty location, this bit is cleared. - 0: Receive FIFO is not full - 1: Receive FIFO is full Reset value: 0x0 
       @ .equ IC_STATUS_RFNE [3:3]    Receive FIFO Not Empty. This bit is set when the receive FIFO contains one or more entries; it is cleared when the receive FIFO is empty. - 0: Receive FIFO is empty - 1: Receive FIFO is not empty Reset value: 0x0 
       @ .equ IC_STATUS_TFE [2:2]    Transmit FIFO Completely Empty. When the transmit FIFO is completely empty, this bit is set. When it contains one or more valid entries, this bit is cleared. This bit field does not request an interrupt. - 0: Transmit FIFO is not empty - 1: Transmit FIFO is empty Reset value: 0x1 
       @ .equ IC_STATUS_TFNF [1:1]    Transmit FIFO Not Full. Set when the transmit FIFO contains one or more empty locations, and is cleared when the FIFO is full. - 0: Transmit FIFO is full - 1: Transmit FIFO is not full Reset value: 0x1 
       @ .equ IC_STATUS_ACTIVITY [0:0]    I2C Activity Status. Reset value: 0x0 
 
    .equ I2C0_IC_TXFLR, 0x0074 I2C Transmit FIFO Level Register This register contains the number of valid data entries in the transmit FIFO buffer. It is cleared whenever: - The I2C is disabled - There is a transmit abort - that is, TX_ABRT bit is set in the IC_RAW_INTR_STAT register - The slave bulk transmit mode is aborted The register increments whenever data is placed into the transmit FIFO and decrements when data is taken from the transmit FIFO.
       @ .equ IC_TXFLR_TXFLR [4:0]    Transmit FIFO Level. Contains the number of valid data entries in the transmit FIFO.  Reset value: 0x0 
 
    .equ I2C0_IC_RXFLR, 0x0078 I2C Receive FIFO Level Register This register contains the number of valid data entries in the receive FIFO buffer. It is cleared whenever: - The I2C is disabled - Whenever there is a transmit abort caused by any of the events tracked in IC_TX_ABRT_SOURCE The register increments whenever data is placed into the receive FIFO and decrements when data is taken from the receive FIFO.
       @ .equ IC_RXFLR_RXFLR [4:0]    Receive FIFO Level. Contains the number of valid data entries in the receive FIFO.  Reset value: 0x0 
 
    .equ I2C0_IC_SDA_HOLD, 0x007c I2C SDA Hold Time Length Register  The bits [15:0] of this register are used to control the hold time of SDA during transmit in both slave and master mode after SCL goes from HIGH to LOW.  The bits [23:16] of this register are used to extend the SDA transition if any whenever SCL is HIGH in the receiver in either master or slave mode.  Writes to this register succeed only when IC_ENABLE[0]=0.  The values in this register are in units of ic_clk period. The value programmed in IC_SDA_TX_HOLD must be greater than the minimum hold time in each mode one cycle in master mode, seven cycles in slave mode for the value to be implemented.  The programmed SDA hold time during transmit IC_SDA_TX_HOLD cannot exceed at any time the duration of the low part of scl. Therefore the programmed value cannot be larger than N_SCL_LOW-2, where N_SCL_LOW is the duration of the low part of the scl period measured in ic_clk cycles.
       @ .equ IC_SDA_HOLD_IC_SDA_RX_HOLD [23:16]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a receiver.  Reset value: IC_DEFAULT_SDA_HOLD[23:16]. 
       @ .equ IC_SDA_HOLD_IC_SDA_TX_HOLD [15:0]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a transmitter.  Reset value: IC_DEFAULT_SDA_HOLD[15:0]. 
 
    .equ I2C0_IC_TX_ABRT_SOURCE, 0x0080 I2C Transmit Abort Source Register  This register has 32 bits that indicate the source of the TX_ABRT bit. Except for Bit 9, this register is cleared whenever the IC_CLR_TX_ABRT register or the IC_CLR_INTR register is read. To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; RESTART must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10].  Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, Bit 9 clears for one cycle and is then re-asserted.
       @ .equ IC_TX_ABRT_SOURCE_TX_FLUSH_CNT [31:23]    This field indicates the number of Tx FIFO Data Commands which are flushed due to TX_ABRT interrupt. It is cleared whenever I2C is disabled.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_USER_ABRT [16:16]    This is a master-mode-only bit. Master has detected the transfer abort IC_ENABLE[1]  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SLVRD_INTX [15:15]    1: When the processor side responds to a slave mode request for data to be transmitted to a remote master and user writes a 1 in CMD bit 8 of IC_DATA_CMD register.  Reset value: 0x0  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SLV_ARBLOST [14:14]    This field indicates that a Slave has lost the bus while transmitting data to a remote master. IC_TX_ABRT_SOURCE[12] is set at the same time. Note: Even though the slave never 'owns' the bus, something could go wrong on the bus. This is a fail safe check. For instance, during a data transmission at the low-to-high transition of SCL, if what is on the data bus is not what is supposed to be transmitted, then DW_apb_i2c no longer own the bus.  Reset value: 0x0  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SLVFLUSH_TXFIFO [13:13]    This field specifies that the Slave has received a read command and some data exists in the TX FIFO, so the slave issues a TX_ABRT interrupt to flush old data in TX FIFO.  Reset value: 0x0  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ARB_LOST [12:12]    This field specifies that the Master has lost arbitration, or if IC_TX_ABRT_SOURCE[14] is also set, then the slave transmitter has lost arbitration.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_MASTER_DIS [11:11]    This field indicates that the User tries to initiate a Master operation with the Master mode disabled.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_10B_RD_NORSTRT [10:10]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the master sends a read command in 10-bit addressing mode.  Reset value: 0x0  Role of DW_apb_i2c: Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SBYTE_NORSTRT [9:9]    To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; restart must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10]. Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, bit 9 clears for one cycle and then gets reasserted. When this field is set to 1, the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to send a START Byte.  Reset value: 0x0  Role of DW_apb_i2c: Master 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_HS_NORSTRT [8:8]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to use the master to transfer data in High Speed mode.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SBYTE_ACKDET [7:7]    This field indicates that the Master has sent a START Byte and the START Byte was acknowledged wrong behavior.  Reset value: 0x0  Role of DW_apb_i2c: Master 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_HS_ACKDET [6:6]    This field indicates that the Master is in High Speed mode and the High Speed Master code was acknowledged wrong behavior.  Reset value: 0x0  Role of DW_apb_i2c: Master 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_GCALL_READ [5:5]    This field indicates that DW_apb_i2c in the master mode has sent a General Call but the user programmed the byte following the General Call to be a read from the bus IC_DATA_CMD[9] is set to 1.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_GCALL_NOACK [4:4]    This field indicates that DW_apb_i2c in master mode has sent a General Call and no slave on the bus acknowledged the General Call.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_TXDATA_NOACK [3:3]    This field indicates the master-mode only bit. When the master receives an acknowledgement for the address, but when it sends data bytes following the address, it did not receive an acknowledge from the remote slaves.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_10ADDR2_NOACK [2:2]    This field indicates that the Master is in 10-bit address mode and that the second address byte of the 10-bit address was not acknowledged by any slave.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_10ADDR1_NOACK [1:1]    This field indicates that the Master is in 10-bit address mode and the first 10-bit address byte was not acknowledged by any slave.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_7B_ADDR_NOACK [0:0]    This field indicates that the Master is in 7-bit addressing mode and the address sent was not acknowledged by any slave.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
 
    .equ I2C0_IC_SLV_DATA_NACK_ONLY, 0x0084 Generate Slave Data NACK Register  The register is used to generate a NACK for the data part of a transfer when DW_apb_i2c is acting as a slave-receiver. This register only exists when the IC_SLV_DATA_NACK_ONLY parameter is set to 1. When this parameter disabled, this register does not exist and writing to the register's address has no effect.  A write can occur on this register if both of the following conditions are met: - DW_apb_i2c is disabled IC_ENABLE[0] = 0 - Slave part is inactive IC_STATUS[6] = 0 Note: The IC_STATUS[6] is a register read-back location for the internal slv_activity signal; the user should poll this before writing the ic_slv_data_nack_only bit.
       @ .equ IC_SLV_DATA_NACK_ONLY_NACK [0:0]    Generate NACK. This NACK generation only occurs when DW_apb_i2c is a slave-receiver. If this register is set to a value of 1, it can only generate a NACK after a data byte is received; hence, the data transfer is aborted and the data received is not pushed to the receive buffer.  When the register is set to a value of 0, it generates NACK/ACK, depending on normal criteria. - 1: generate NACK after data byte received - 0: generate NACK/ACK normally Reset value: 0x0 
 
    .equ I2C0_IC_DMA_CR, 0x0088 DMA Control Register  The register is used to enable the DMA Controller interface operation. There is a separate bit for transmit and receive. This can be programmed regardless of the state of IC_ENABLE.
       @ .equ IC_DMA_CR_TDMAE [1:1]    Transmit DMA Enable. This bit enables/disables the transmit FIFO DMA channel. Reset value: 0x0 
       @ .equ IC_DMA_CR_RDMAE [0:0]    Receive DMA Enable. This bit enables/disables the receive FIFO DMA channel. Reset value: 0x0 
 
    .equ I2C0_IC_DMA_TDLR, 0x008c DMA Transmit Data Level Register
       @ .equ IC_DMA_TDLR_DMATDL [3:0]    Transmit Data Level. This bit field controls the level at which a DMA request is made by the transmit logic. It is equal to the watermark level; that is, the dma_tx_req signal is generated when the number of valid data entries in the transmit FIFO is equal to or below this field value, and TDMAE = 1.  Reset value: 0x0 
 
    .equ I2C0_IC_DMA_RDLR, 0x0090 I2C Receive Data Level Register
       @ .equ IC_DMA_RDLR_DMARDL [3:0]    Receive Data Level. This bit field controls the level at which a DMA request is made by the receive logic. The watermark level = DMARDL+1; that is, dma_rx_req is generated when the number of valid data entries in the receive FIFO is equal to or more than this field value + 1, and RDMAE =1. For instance, when DMARDL is 0, then dma_rx_req is asserted when 1 or more data entries are present in the receive FIFO.  Reset value: 0x0 
 
    .equ I2C0_IC_SDA_SETUP, 0x0094 I2C SDA Setup Register  This register controls the amount of time delay in terms of number of ic_clk clock periods introduced in the rising edge of SCL - relative to SDA changing - when DW_apb_i2c services a read request in a slave-transmitter operation. The relevant I2C requirement is tSU:DAT note 4 as detailed in the I2C Bus Specification. This register must be programmed with a value equal to or greater than 2.  Writes to this register succeed only when IC_ENABLE[0] = 0.  Note: The length of setup time is calculated using [IC_SDA_SETUP - 1 * ic_clk_period], so if the user requires 10 ic_clk periods of setup time, they should program a value of 11. The IC_SDA_SETUP register is only used by the DW_apb_i2c when operating as a slave transmitter.
       @ .equ IC_SDA_SETUP_SDA_SETUP [7:0]    SDA Setup. It is recommended that if the required delay is 1000ns, then for an ic_clk frequency of 10 MHz, IC_SDA_SETUP should be programmed to a value of 11. IC_SDA_SETUP must be programmed with a minimum value of 2. 
 
    .equ I2C0_IC_ACK_GENERAL_CALL, 0x0098 I2C ACK General Call Register  The register controls whether DW_apb_i2c responds with a ACK or NACK when it receives an I2C General Call address.  This register is applicable only when the DW_apb_i2c is in slave mode.
       @ .equ IC_ACK_GENERAL_CALL_ACK_GEN_CALL [0:0]    ACK General Call. When set to 1, DW_apb_i2c responds with a ACK by asserting ic_data_oe when it receives a General Call. Otherwise, DW_apb_i2c responds with a NACK by negating ic_data_oe. 
 
    .equ I2C0_IC_ENABLE_STATUS, 0x009c I2C Enable Status Register  The register is used to report the DW_apb_i2c hardware status when the IC_ENABLE[0] register is set from 1 to 0; that is, when DW_apb_i2c is disabled.  If IC_ENABLE[0] has been set to 1, bits 2:1 are forced to 0, and bit 0 is forced to 1.  If IC_ENABLE[0] has been set to 0, bits 2:1 is only be valid as soon as bit 0 is read as '0'.  Note: When IC_ENABLE[0] has been set to 0, a delay occurs for bit 0 to be read as 0 because disabling the DW_apb_i2c depends on I2C bus activities.
       @ .equ IC_ENABLE_STATUS_SLV_RX_DATA_LOST [2:2]    Slave Received Data Lost. This bit indicates if a Slave-Receiver operation has been aborted with at least one data byte received from an I2C transfer due to the setting bit 0 of IC_ENABLE from 1 to 0. When read as 1, DW_apb_i2c is deemed to have been actively engaged in an aborted I2C transfer with matching address and the data phase of the I2C transfer has been entered, even though a data byte has been responded with a NACK.  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit is also set to 1.  When read as 0, DW_apb_i2c is deemed to have been disabled without being actively involved in the data phase of a Slave-Receiver transfer.  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.  Reset value: 0x0 
       @ .equ IC_ENABLE_STATUS_SLV_DISABLED_WHILE_BUSY [1:1]    Slave Disabled While Busy Transmit, Receive. This bit indicates if a potential or active Slave operation has been aborted due to the setting bit 0 of the IC_ENABLE register from 1 to 0. This bit is set when the CPU writes a 0 to the IC_ENABLE register while:  a DW_apb_i2c is receiving the address byte of the Slave-Transmitter operation from a remote master;  OR,  b address and data bytes of the Slave-Receiver operation from a remote master.  When read as 1, DW_apb_i2c is deemed to have forced a NACK during any part of an I2C transfer, irrespective of whether the I2C address matches the slave address set in DW_apb_i2c IC_SAR register OR if the transfer is completed before IC_ENABLE is set to 0 but has not taken effect.  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit will also be set to 1.  When read as 0, DW_apb_i2c is deemed to have been disabled when there is master activity, or when the I2C bus is idle.  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.  Reset value: 0x0 
       @ .equ IC_ENABLE_STATUS_IC_EN [0:0]    ic_en Status. This bit always reflects the value driven on the output port ic_en. - When read as 1, DW_apb_i2c is deemed to be in an enabled state. - When read as 0, DW_apb_i2c is deemed completely inactive. Note: The CPU can safely read this bit anytime. When this bit is read as 0, the CPU can safely read SLV_RX_DATA_LOST bit 2 and SLV_DISABLED_WHILE_BUSY bit 1.  Reset value: 0x0 
 
    .equ I2C0_IC_FS_SPKLEN, 0x00a0 I2C SS, FS or FM+ spike suppression limit  This register is used to store the duration, measured in ic_clk cycles, of the longest spike that is filtered out by the spike suppression logic when the component is operating in SS, FS or FM+ modes. The relevant I2C requirement is tSP table 4 as detailed in the I2C Bus Specification. This register must be programmed with a minimum value of 1.
       @ .equ IC_FS_SPKLEN_IC_FS_SPKLEN [7:0]    This register must be set before any I2C bus transaction can take place to ensure stable operation. This register sets the duration, measured in ic_clk cycles, of the longest spike in the SCL or SDA lines that will be filtered out by the spike suppression logic. This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect. The minimum valid value is 1; hardware prevents values less than this being written, and if attempted results in 1 being set. or more information, refer to 'Spike Suppression'. 
 
    .equ I2C0_IC_CLR_RESTART_DET, 0x00a8 Clear RESTART_DET Interrupt Register
       @ .equ IC_CLR_RESTART_DET_CLR_RESTART_DET [0:0]    Read this register to clear the RESTART_DET interrupt bit 12 of IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C0_IC_COMP_PARAM_1, 0x00f4 Component Parameter Register 1  Note This register is not implemented and therefore reads as 0. If it was implemented it would be a constant read-only register that contains encoded information about the component's parameter settings. Fields shown below are the settings for those parameters
       @ .equ IC_COMP_PARAM_1_TX_BUFFER_DEPTH [23:16]    TX Buffer Depth = 16 
       @ .equ IC_COMP_PARAM_1_RX_BUFFER_DEPTH [15:8]    RX Buffer Depth = 16 
       @ .equ IC_COMP_PARAM_1_ADD_ENCODED_PARAMS [7:7]    Encoded parameters not visible 
       @ .equ IC_COMP_PARAM_1_HAS_DMA [6:6]    DMA handshaking signals are enabled 
       @ .equ IC_COMP_PARAM_1_INTR_IO [5:5]    COMBINED Interrupt outputs 
       @ .equ IC_COMP_PARAM_1_HC_COUNT_VALUES [4:4]    Programmable count values for each mode. 
       @ .equ IC_COMP_PARAM_1_MAX_SPEED_MODE [3:2]    MAX SPEED MODE = FAST MODE 
       @ .equ IC_COMP_PARAM_1_APB_DATA_WIDTH [1:0]    APB data bus width is 32 bits 
 
    .equ I2C0_IC_COMP_VERSION, 0x00f8 I2C Component Version Register
       @ .equ IC_COMP_VERSION_IC_COMP_VERSION [31:0]     
 
    .equ I2C0_IC_COMP_TYPE, 0x00fc I2C Component Type Register
       @ .equ IC_COMP_TYPE_IC_COMP_TYPE [31:0]    Designware Component Type number = 0x44_57_01_40. This assigned unique hex value is constant and is derived from the two ASCII letters 'DW' followed by a 16-bit unsigned number. 
 

@=========================== I2C1 ===========================@
.equ I2C1_BASE, 0x40048000 DW_apb_i2c address block
    .equ I2C1_IC_CON, 0x0000 I2C Control Register. This register can be written only when the DW_apb_i2c is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  Read/Write Access: - bit 10 is read only. - bit 11 is read only - bit 16 is read only - bit 17 is read only - bits 18 and 19 are read only.
       @ .equ IC_CON_STOP_DET_IF_MASTER_ACTIVE [10:10]    Master issues the STOP_DET interrupt irrespective of whether master is active or not 
       @ .equ IC_CON_RX_FIFO_FULL_HLD_CTRL [9:9]    This bit controls whether DW_apb_i2c should hold the bus when the Rx FIFO is physically full to its RX_BUFFER_DEPTH, as described in the IC_RX_FULL_HLD_BUS_EN parameter.  Reset value: 0x0. 
       @ .equ IC_CON_TX_EMPTY_CTRL [8:8]    This bit controls the generation of the TX_EMPTY interrupt, as described in the IC_RAW_INTR_STAT register.  Reset value: 0x0. 
       @ .equ IC_CON_STOP_DET_IFADDRESSED [7:7]    In slave mode: - 1'b1: issues the STOP_DET interrupt only when it is addressed. - 1'b0: issues the STOP_DET irrespective of whether it's addressed or not. Reset value: 0x0  NOTE: During a general call address, this slave does not issue the STOP_DET interrupt if STOP_DET_IF_ADDRESSED = 1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. 
       @ .equ IC_CON_IC_SLAVE_DISABLE [6:6]    This bit controls whether I2C has its slave disabled, which means once the presetn signal is applied, then this bit is set and the slave is disabled.  If this bit is set slave is disabled, DW_apb_i2c functions only as a master and does not perform any action that requires a slave.  NOTE: Software should ensure that if this bit is written with 0, then bit 0 should also be written with a 0. 
       @ .equ IC_CON_IC_RESTART_EN [5:5]    Determines whether RESTART conditions may be sent when acting as a master. Some older slaves do not support handling RESTART conditions; however, RESTART conditions are used in several DW_apb_i2c operations. When RESTART is disabled, the master is prohibited from performing the following functions: - Sending a START BYTE - Performing any high-speed mode operation - High-speed mode operation - Performing direction changes in combined format mode - Performing a read operation with a 10-bit address By replacing RESTART condition followed by a STOP and a subsequent START condition, split operations are broken down into multiple DW_apb_i2c transfers. If the above operations are performed, it will result in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register.  Reset value: ENABLED 
       @ .equ IC_CON_IC_10BITADDR_MASTER [4:4]    Controls whether the DW_apb_i2c starts its transfers in 7- or 10-bit addressing mode when acting as a master. - 0: 7-bit addressing - 1: 10-bit addressing 
       @ .equ IC_CON_IC_10BITADDR_SLAVE [3:3]    When acting as a slave, this bit controls whether the DW_apb_i2c responds to 7- or 10-bit addresses. - 0: 7-bit addressing. The DW_apb_i2c ignores transactions that involve 10-bit addressing; for 7-bit addressing, only the lower 7 bits of the IC_SAR register are compared. - 1: 10-bit addressing. The DW_apb_i2c responds to only 10-bit addressing transfers that match the full 10 bits of the IC_SAR register. 
       @ .equ IC_CON_SPEED [2:1]    These bits control at which speed the DW_apb_i2c operates; its setting is relevant only if one is operating the DW_apb_i2c in master mode. Hardware protects against illegal values being programmed by software. These bits must be programmed appropriately for slave mode also, as it is used to capture correct value of spike filter as per the speed mode.  This register should be programmed only with a value in the range of 1 to IC_MAX_SPEED_MODE; otherwise, hardware updates this register with the value of IC_MAX_SPEED_MODE.  1: standard mode 100 kbit/s  2: fast mode <=400 kbit/s or fast mode plus <=1000Kbit/s  3: high speed mode 3.4 Mbit/s  Note: This field is not applicable when IC_ULTRA_FAST_MODE=1 
       @ .equ IC_CON_MASTER_MODE [0:0]    This bit controls whether the DW_apb_i2c master is enabled.  NOTE: Software should ensure that if this bit is written with '1' then bit 6 should also be written with a '1'. 
 
    .equ I2C1_IC_TAR, 0x0004 I2C Target Address Register  This register is 12 bits wide, and bits 31:12 are reserved. This register can be written to only when IC_ENABLE[0] is set to 0.  Note: If the software or application is aware that the DW_apb_i2c is not using the TAR address for the pending commands in the Tx FIFO, then it is possible to update the TAR address even while the Tx FIFO has entries IC_STATUS[2]= 0. - It is not necessary to perform any write to this register if DW_apb_i2c is enabled as an I2C slave only.
       @ .equ IC_TAR_SPECIAL [11:11]    This bit indicates whether software performs a Device-ID or General Call or START BYTE command. - 0: ignore bit 10 GC_OR_START and use IC_TAR normally - 1: perform special I2C command as specified in Device_ID or GC_OR_START bit Reset value: 0x0 
       @ .equ IC_TAR_GC_OR_START [10:10]    If bit 11 SPECIAL is set to 1 and bit 13Device-ID is set to 0, then this bit indicates whether a General Call or START byte command is to be performed by the DW_apb_i2c. - 0: General Call Address - after issuing a General Call, only writes may be performed. Attempting to issue a read command results in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register. The DW_apb_i2c remains in General Call mode until the SPECIAL bit value bit 11 is cleared. - 1: START BYTE Reset value: 0x0 
       @ .equ IC_TAR_IC_TAR [9:0]    This is the target address for any master transaction. When transmitting a General Call, these bits are ignored. To generate a START BYTE, the CPU needs to write only once into these bits.  If the IC_TAR and IC_SAR are the same, loopback exists but the FIFOs are shared between master and slave, so full loopback is not feasible. Only one direction loopback mode is supported simplex, not duplex. A master cannot transmit to itself; it can transmit to only a slave. 
 
    .equ I2C1_IC_SAR, 0x0008 I2C Slave Address Register
       @ .equ IC_SAR_IC_SAR [9:0]    The IC_SAR holds the slave address when the I2C is operating as a slave. For 7-bit addressing, only IC_SAR[6:0] is used.  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  Note: The default values cannot be any of the reserved address locations: that is, 0x00 to 0x07, or 0x78 to 0x7f. The correct operation of the device is not guaranteed if you program the IC_SAR or IC_TAR to a reserved value. Refer to <<table_I2C_firstbyte_bit_defs>> for a complete list of these reserved values. 
 
    .equ I2C1_IC_DATA_CMD, 0x0010 I2C Rx/Tx Data Buffer and Command Register; this is the register the CPU writes to when filling the TX FIFO and the CPU reads from when retrieving bytes from RX FIFO.  The size of the register changes as follows:  Write: - 11 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=1 - 9 bits when IC_EMPTYFIFO_HOLD_MASTER_EN=0 Read: - 12 bits when IC_FIRST_DATA_BYTE_STATUS = 1 - 8 bits when IC_FIRST_DATA_BYTE_STATUS = 0 Note: In order for the DW_apb_i2c to continue acknowledging reads, a read command should be written for every byte that is to be received; otherwise the DW_apb_i2c will stop acknowledging.
       @ .equ IC_DATA_CMD_FIRST_DATA_BYTE [11:11]    Indicates the first data byte received after the address phase for receive transfer in Master receiver or Slave receiver mode.  Reset value : 0x0  NOTE: In case of APB_DATA_WIDTH=8,  1. The user has to perform two APB Reads to IC_DATA_CMD in order to get status on 11 bit.  2. In order to read the 11 bit, the user has to perform the first data byte read [7:0] offset 0x10 and then perform the second read [15:8] offset 0x11 in order to know the status of 11 bit whether the data received in previous read is a first data byte or not.  3. The 11th bit is an optional read field, user can ignore 2nd byte read [15:8] offset 0x11 if not interested in FIRST_DATA_BYTE status. 
       @ .equ IC_DATA_CMD_RESTART [10:10]    This bit controls whether a RESTART is issued before the byte is sent or received.  1 - If IC_RESTART_EN is 1, a RESTART is issued before the data is sent/received according to the value of CMD, regardless of whether or not the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.  0 - If IC_RESTART_EN is 1, a RESTART is issued only if the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.  Reset value: 0x0 
       @ .equ IC_DATA_CMD_STOP [9:9]    This bit controls whether a STOP is issued after the byte is sent or received.  - 1 - STOP is issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master immediately tries to start a new transfer by issuing a START and arbitrating for the bus. - 0 - STOP is not issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master continues the current transfer by sending/receiving data bytes according to the value of the CMD bit. If the Tx FIFO is empty, the master holds the SCL line low and stalls the bus until a new command is available in the Tx FIFO. Reset value: 0x0 
       @ .equ IC_DATA_CMD_CMD [8:8]    This bit controls whether a read or a write is performed. This bit does not control the direction when the DW_apb_i2con acts as a slave. It controls only the direction when it acts as a master.  When a command is entered in the TX FIFO, this bit distinguishes the write and read commands. In slave-receiver mode, this bit is a 'don't care' because writes to this register are not required. In slave-transmitter mode, a '0' indicates that the data in IC_DATA_CMD is to be transmitted.  When programming this bit, you should remember the following: attempting to perform a read operation after a General Call command has been sent results in a TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, unless bit 11 SPECIAL in the IC_TAR register has been cleared. If a '1' is written to this bit after receiving a RD_REQ interrupt, then a TX_ABRT interrupt occurs.  Reset value: 0x0 
       @ .equ IC_DATA_CMD_DAT [7:0]    This register contains the data to be transmitted or received on the I2C bus. If you are writing to this register and want to perform a read, bits 7:0 DAT are ignored by the DW_apb_i2c. However, when you read this register, these bits return the value of data received on the DW_apb_i2c interface.  Reset value: 0x0 
 
    .equ I2C1_IC_SS_SCL_HCNT, 0x0014 Standard Speed I2C Clock SCL High Count Register
       @ .equ IC_SS_SCL_HCNT_IC_SS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'.  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed.  NOTE: This register must not be programmed to a value higher than 65525, because DW_apb_i2c uses a 16-bit counter to flag an I2C bus idle condition when this counter reaches a value of IC_SS_SCL_HCNT + 10. 
 
    .equ I2C1_IC_SS_SCL_LCNT, 0x0018 Standard Speed I2C Clock SCL Low Count Register
       @ .equ IC_SS_SCL_LCNT_IC_SS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted, results in 8 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of DW_apb_i2c. The lower byte must be programmed first, and then the upper byte is programmed. 
 
    .equ I2C1_IC_FS_SCL_HCNT, 0x001c Fast Mode or Fast Mode Plus I2C Clock SCL High Count Register
       @ .equ IC_FS_SCL_HCNT_IC_FS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for fast mode or fast mode plus. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard. This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH == 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. 
 
    .equ I2C1_IC_FS_SCL_LCNT, 0x0020 Fast Mode or Fast Mode Plus I2C Clock SCL Low Count Register
       @ .equ IC_FS_SCL_LCNT_IC_FS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for fast speed. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard.  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted results in 8 being set. For designs with APB_DATA_WIDTH = 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. If the value is less than 8 then the count value gets changed to 8. 
 
    .equ I2C1_IC_INTR_STAT, 0x002c I2C Interrupt Status Register  Each bit in this register has a corresponding mask bit in the IC_INTR_MASK register. These bits are cleared by reading the matching interrupt clear register. The unmasked raw versions of these bits are available in the IC_RAW_INTR_STAT register.
       @ .equ IC_INTR_STAT_R_MASTER_ON_HOLD [13:13]    See IC_RAW_INTR_STAT for a detailed description of R_MASTER_ON_HOLD bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RESTART_DET [12:12]    See IC_RAW_INTR_STAT for a detailed description of R_RESTART_DET bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_GEN_CALL [11:11]    See IC_RAW_INTR_STAT for a detailed description of R_GEN_CALL bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_START_DET [10:10]    See IC_RAW_INTR_STAT for a detailed description of R_START_DET bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_STOP_DET [9:9]    See IC_RAW_INTR_STAT for a detailed description of R_STOP_DET bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_ACTIVITY [8:8]    See IC_RAW_INTR_STAT for a detailed description of R_ACTIVITY bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_DONE [7:7]    See IC_RAW_INTR_STAT for a detailed description of R_RX_DONE bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_TX_ABRT [6:6]    See IC_RAW_INTR_STAT for a detailed description of R_TX_ABRT bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RD_REQ [5:5]    See IC_RAW_INTR_STAT for a detailed description of R_RD_REQ bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_TX_EMPTY [4:4]    See IC_RAW_INTR_STAT for a detailed description of R_TX_EMPTY bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_TX_OVER [3:3]    See IC_RAW_INTR_STAT for a detailed description of R_TX_OVER bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_FULL [2:2]    See IC_RAW_INTR_STAT for a detailed description of R_RX_FULL bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_OVER [1:1]    See IC_RAW_INTR_STAT for a detailed description of R_RX_OVER bit.  Reset value: 0x0 
       @ .equ IC_INTR_STAT_R_RX_UNDER [0:0]    See IC_RAW_INTR_STAT for a detailed description of R_RX_UNDER bit.  Reset value: 0x0 
 
    .equ I2C1_IC_INTR_MASK, 0x0030 I2C Interrupt Mask Register.  These bits mask their corresponding interrupt status bits. This register is active low; a value of 0 masks the interrupt, whereas a value of 1 unmasks the interrupt.
       @ .equ IC_INTR_MASK_M_MASTER_ON_HOLD_READ_ONLY [13:13]    This M_MASTER_ON_HOLD_read_only bit masks the R_MASTER_ON_HOLD interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_RESTART_DET [12:12]    This bit masks the R_RESTART_DET interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_GEN_CALL [11:11]    This bit masks the R_GEN_CALL interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_START_DET [10:10]    This bit masks the R_START_DET interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_STOP_DET [9:9]    This bit masks the R_STOP_DET interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_ACTIVITY [8:8]    This bit masks the R_ACTIVITY interrupt in IC_INTR_STAT register.  Reset value: 0x0 
       @ .equ IC_INTR_MASK_M_RX_DONE [7:7]    This bit masks the R_RX_DONE interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_TX_ABRT [6:6]    This bit masks the R_TX_ABRT interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RD_REQ [5:5]    This bit masks the R_RD_REQ interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_TX_EMPTY [4:4]    This bit masks the R_TX_EMPTY interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_TX_OVER [3:3]    This bit masks the R_TX_OVER interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RX_FULL [2:2]    This bit masks the R_RX_FULL interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RX_OVER [1:1]    This bit masks the R_RX_OVER interrupt in IC_INTR_STAT register.  Reset value: 0x1 
       @ .equ IC_INTR_MASK_M_RX_UNDER [0:0]    This bit masks the R_RX_UNDER interrupt in IC_INTR_STAT register.  Reset value: 0x1 
 
    .equ I2C1_IC_RAW_INTR_STAT, 0x0034 I2C Raw Interrupt Status Register  Unlike the IC_INTR_STAT register, these bits are not masked so they always show the true status of the DW_apb_i2c.
       @ .equ IC_RAW_INTR_STAT_MASTER_ON_HOLD [13:13]    Indicates whether master is holding the bus and TX FIFO is empty. Enabled only when I2C_DYNAMIC_TAR_UPDATE=1 and IC_EMPTYFIFO_HOLD_MASTER_EN=1.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RESTART_DET [12:12]    Indicates whether a RESTART condition has occurred on the I2C interface when DW_apb_i2c is operating in Slave mode and the slave is being addressed. Enabled only when IC_SLV_RESTART_DET_EN=1.  Note: However, in high-speed mode or during a START BYTE transfer, the RESTART comes before the address field as per the I2C protocol. In this case, the slave is not the addressed slave when the RESTART is issued, therefore DW_apb_i2c does not generate the RESTART_DET interrupt.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_GEN_CALL [11:11]    Set only when a General Call address is received and it is acknowledged. It stays set until it is cleared either by disabling DW_apb_i2c or when the CPU reads bit 0 of the IC_CLR_GEN_CALL register. DW_apb_i2c stores the received data in the Rx buffer.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_START_DET [10:10]    Indicates whether a START or RESTART condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_STOP_DET [9:9]    Indicates whether a STOP condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.  In Slave Mode: - If IC_CON[7]=1'b1 STOP_DET_IFADDRESSED, the STOP_DET interrupt will be issued only if slave is addressed. Note: During a general call address, this slave does not issue a STOP_DET interrupt if STOP_DET_IF_ADDRESSED=1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. - If IC_CON[7]=1'b0 STOP_DET_IFADDRESSED, the STOP_DET interrupt is issued irrespective of whether it is being addressed. In Master Mode: - If IC_CON[10]=1'b1 STOP_DET_IF_MASTER_ACTIVE,the STOP_DET interrupt will be issued only if Master is active. - If IC_CON[10]=1'b0 STOP_DET_IFADDRESSED,the STOP_DET interrupt will be issued irrespective of whether master is active or not. Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_ACTIVITY [8:8]    This bit captures DW_apb_i2c activity and stays set until it is cleared. There are four ways to clear it: - Disabling the DW_apb_i2c - Reading the IC_CLR_ACTIVITY register - Reading the IC_CLR_INTR register - System reset Once this bit is set, it stays set unless one of the four methods is used to clear it. Even if the DW_apb_i2c module is idle, this bit remains set until cleared, indicating that there was activity on the bus.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_DONE [7:7]    When the DW_apb_i2c is acting as a slave-transmitter, this bit is set to 1 if the master does not acknowledge a transmitted byte. This occurs on the last byte of the transmission, indicating that the transmission is done.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_TX_ABRT [6:6]    This bit indicates if DW_apb_i2c, as an I2C transmitter, is unable to complete the intended actions on the contents of the transmit FIFO. This situation can occur both as an I2C master or an I2C slave, and is referred to as a 'transmit abort'. When this bit is set to 1, the IC_TX_ABRT_SOURCE register indicates the reason why the transmit abort takes places.  Note: The DW_apb_i2c flushes/resets/empties the TX_FIFO and RX_FIFO whenever there is a transmit abort caused by any of the events tracked by the IC_TX_ABRT_SOURCE register. The FIFOs remains in this flushed state until the register IC_CLR_TX_ABRT is read. Once this read is performed, the Tx FIFO is then ready to accept more data bytes from the APB interface.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RD_REQ [5:5]    This bit is set to 1 when DW_apb_i2c is acting as a slave and another I2C master is attempting to read data from DW_apb_i2c. The DW_apb_i2c holds the I2C bus in a wait state SCL=0 until this interrupt is serviced, which means that the slave has been addressed by a remote master that is asking for data to be transferred. The processor must respond to this interrupt and then write the requested data to the IC_DATA_CMD register. This bit is set to 0 just after the processor reads the IC_CLR_RD_REQ register.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_TX_EMPTY [4:4]    The behavior of the TX_EMPTY interrupt status differs based on the TX_EMPTY_CTRL selection in the IC_CON register. - When TX_EMPTY_CTRL = 0: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register. - When TX_EMPTY_CTRL = 1: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register and the transmission of the address/data from the internal shift register for the most recently popped command is completed. It is automatically cleared by hardware when the buffer level goes above the threshold. When IC_ENABLE[0] is set to 0, the TX FIFO is flushed and held in reset. There the TX FIFO looks like it has no data within it, so this bit is set to 1, provided there is activity in the master or slave state machines. When there is no longer any activity, then with ic_en=0, this bit is set to 0.  Reset value: 0x0. 
       @ .equ IC_RAW_INTR_STAT_TX_OVER [3:3]    Set during transmit if the transmit buffer is filled to IC_TX_BUFFER_DEPTH and the processor attempts to issue another I2C command by writing to the IC_DATA_CMD register. When the module is disabled, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_FULL [2:2]    Set when the receive buffer reaches or goes above the RX_TL threshold in the IC_RX_TL register. It is automatically cleared by hardware when buffer level goes below the threshold. If the module is disabled IC_ENABLE[0]=0, the RX FIFO is flushed and held in reset; therefore the RX FIFO is not full. So this bit is cleared once the IC_ENABLE bit 0 is programmed with a 0, regardless of the activity that continues.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_OVER [1:1]    Set if the receive buffer is completely filled to IC_RX_BUFFER_DEPTH and an additional byte is received from an external I2C device. The DW_apb_i2c acknowledges this, but any data bytes received after the FIFO is full are lost. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.  Note: If bit 9 of the IC_CON register RX_FIFO_FULL_HLD_CTRL is programmed to HIGH, then the RX_OVER interrupt never occurs, because the Rx FIFO never overflows.  Reset value: 0x0 
       @ .equ IC_RAW_INTR_STAT_RX_UNDER [0:0]    Set if the processor attempts to read the receive buffer when it is empty by reading from the IC_DATA_CMD register. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.  Reset value: 0x0 
 
    .equ I2C1_IC_RX_TL, 0x0038 I2C Receive FIFO Threshold Register
       @ .equ IC_RX_TL_RX_TL [7:0]    Receive FIFO Threshold Level.  Controls the level of entries or above that triggers the RX_FULL interrupt bit 2 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that hardware does not allow this value to be set to a value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 1 entry, and a value of 255 sets the threshold for 256 entries. 
 
    .equ I2C1_IC_TX_TL, 0x003c I2C Transmit FIFO Threshold Register
       @ .equ IC_TX_TL_TX_TL [7:0]    Transmit FIFO Threshold Level.  Controls the level of entries or below that trigger the TX_EMPTY interrupt bit 4 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that it may not be set to value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 0 entries, and a value of 255 sets the threshold for 255 entries. 
 
    .equ I2C1_IC_CLR_INTR, 0x0040 Clear Combined and Individual Interrupt Register
       @ .equ IC_CLR_INTR_CLR_INTR [0:0]    Read this register to clear the combined interrupt, all individual interrupts, and the IC_TX_ABRT_SOURCE register. This bit does not clear hardware clearable interrupts but software clearable interrupts. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RX_UNDER, 0x0044 Clear RX_UNDER Interrupt Register
       @ .equ IC_CLR_RX_UNDER_CLR_RX_UNDER [0:0]    Read this register to clear the RX_UNDER interrupt bit 0 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RX_OVER, 0x0048 Clear RX_OVER Interrupt Register
       @ .equ IC_CLR_RX_OVER_CLR_RX_OVER [0:0]    Read this register to clear the RX_OVER interrupt bit 1 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_TX_OVER, 0x004c Clear TX_OVER Interrupt Register
       @ .equ IC_CLR_TX_OVER_CLR_TX_OVER [0:0]    Read this register to clear the TX_OVER interrupt bit 3 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RD_REQ, 0x0050 Clear RD_REQ Interrupt Register
       @ .equ IC_CLR_RD_REQ_CLR_RD_REQ [0:0]    Read this register to clear the RD_REQ interrupt bit 5 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_TX_ABRT, 0x0054 Clear TX_ABRT Interrupt Register
       @ .equ IC_CLR_TX_ABRT_CLR_TX_ABRT [0:0]    Read this register to clear the TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, and the IC_TX_ABRT_SOURCE register. This also releases the TX FIFO from the flushed/reset state, allowing more writes to the TX FIFO. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RX_DONE, 0x0058 Clear RX_DONE Interrupt Register
       @ .equ IC_CLR_RX_DONE_CLR_RX_DONE [0:0]    Read this register to clear the RX_DONE interrupt bit 7 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_ACTIVITY, 0x005c Clear ACTIVITY Interrupt Register
       @ .equ IC_CLR_ACTIVITY_CLR_ACTIVITY [0:0]    Reading this register clears the ACTIVITY interrupt if the I2C is not active anymore. If the I2C module is still active on the bus, the ACTIVITY interrupt bit continues to be set. It is automatically cleared by hardware if the module is disabled and if there is no further activity on the bus. The value read from this register to get status of the ACTIVITY interrupt bit 8 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_STOP_DET, 0x0060 Clear STOP_DET Interrupt Register
       @ .equ IC_CLR_STOP_DET_CLR_STOP_DET [0:0]    Read this register to clear the STOP_DET interrupt bit 9 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_START_DET, 0x0064 Clear START_DET Interrupt Register
       @ .equ IC_CLR_START_DET_CLR_START_DET [0:0]    Read this register to clear the START_DET interrupt bit 10 of the IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_GEN_CALL, 0x0068 Clear GEN_CALL Interrupt Register
       @ .equ IC_CLR_GEN_CALL_CLR_GEN_CALL [0:0]    Read this register to clear the GEN_CALL interrupt bit 11 of IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_ENABLE, 0x006c I2C Enable Register
       @ .equ IC_ENABLE_TX_CMD_BLOCK [2:2]    In Master mode: - 1'b1: Blocks the transmission of data on I2C bus even if Tx FIFO has data to transmit. - 1'b0: The transmission of data starts on I2C bus automatically, as soon as the first data is available in the Tx FIFO. Note: To block the execution of Master commands, set the TX_CMD_BLOCK bit only when Tx FIFO is empty IC_STATUS[2]==1 and Master is in Idle state IC_STATUS[5] == 0. Any further commands put in the Tx FIFO are not executed until TX_CMD_BLOCK bit is unset. Reset value: IC_TX_CMD_BLOCK_DEFAULT 
       @ .equ IC_ENABLE_ABORT [1:1]    When set, the controller initiates the transfer abort. - 0: ABORT not initiated or ABORT done - 1: ABORT operation in progress The software can abort the I2C transfer in master mode by setting this bit. The software can set this bit only when ENABLE is already set; otherwise, the controller ignores any write to ABORT bit. The software cannot clear the ABORT bit once set. In response to an ABORT, the controller issues a STOP and flushes the Tx FIFO after completing the current transfer, then sets the TX_ABORT interrupt after the abort operation. The ABORT bit is cleared automatically after the abort operation.  For a detailed description on how to abort I2C transfers, refer to 'Aborting I2C Transfers'.  Reset value: 0x0 
       @ .equ IC_ENABLE_ENABLE [0:0]    Controls whether the DW_apb_i2c is enabled. - 0: Disables DW_apb_i2c TX and RX FIFOs are held in an erased state - 1: Enables DW_apb_i2c Software can disable DW_apb_i2c while it is active. However, it is important that care be taken to ensure that DW_apb_i2c is disabled properly. A recommended procedure is described in 'Disabling DW_apb_i2c'.  When DW_apb_i2c is disabled, the following occurs: - The TX FIFO and RX FIFO get flushed. - Status bits in the IC_INTR_STAT register are still active until DW_apb_i2c goes into IDLE state. If the module is transmitting, it stops as well as deletes the contents of the transmit buffer after the current transfer is complete. If the module is receiving, the DW_apb_i2c stops the current transfer at the end of the current byte and does not acknowledge the transfer.  In systems with asynchronous pclk and ic_clk when IC_CLK_TYPE parameter set to asynchronous 1, there is a two ic_clk delay when enabling or disabling the DW_apb_i2c. For a detailed description on how to disable DW_apb_i2c, refer to 'Disabling DW_apb_i2c'  Reset value: 0x0 
 
    .equ I2C1_IC_STATUS, 0x0070 I2C Status Register  This is a read-only register used to indicate the current transfer status and FIFO status. The status register may be read at any time. None of the bits in this register request an interrupt.  When the I2C is disabled by writing 0 in bit 0 of the IC_ENABLE register: - Bits 1 and 2 are set to 1 - Bits 3 and 10 are set to 0 When the master or slave state machines goes to idle and ic_en=0: - Bits 5 and 6 are set to 0
       @ .equ IC_STATUS_SLV_ACTIVITY [6:6]    Slave FSM Activity Status. When the Slave Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Slave FSM is in IDLE state so the Slave part of DW_apb_i2c is not Active - 1: Slave FSM is not in IDLE state so the Slave part of DW_apb_i2c is Active Reset value: 0x0 
       @ .equ IC_STATUS_MST_ACTIVITY [5:5]    Master FSM Activity Status. When the Master Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Master FSM is in IDLE state so the Master part of DW_apb_i2c is not Active - 1: Master FSM is not in IDLE state so the Master part of DW_apb_i2c is Active Note: IC_STATUS[0]-that is, ACTIVITY bit-is the OR of SLV_ACTIVITY and MST_ACTIVITY bits.  Reset value: 0x0 
       @ .equ IC_STATUS_RFF [4:4]    Receive FIFO Completely Full. When the receive FIFO is completely full, this bit is set. When the receive FIFO contains one or more empty location, this bit is cleared. - 0: Receive FIFO is not full - 1: Receive FIFO is full Reset value: 0x0 
       @ .equ IC_STATUS_RFNE [3:3]    Receive FIFO Not Empty. This bit is set when the receive FIFO contains one or more entries; it is cleared when the receive FIFO is empty. - 0: Receive FIFO is empty - 1: Receive FIFO is not empty Reset value: 0x0 
       @ .equ IC_STATUS_TFE [2:2]    Transmit FIFO Completely Empty. When the transmit FIFO is completely empty, this bit is set. When it contains one or more valid entries, this bit is cleared. This bit field does not request an interrupt. - 0: Transmit FIFO is not empty - 1: Transmit FIFO is empty Reset value: 0x1 
       @ .equ IC_STATUS_TFNF [1:1]    Transmit FIFO Not Full. Set when the transmit FIFO contains one or more empty locations, and is cleared when the FIFO is full. - 0: Transmit FIFO is full - 1: Transmit FIFO is not full Reset value: 0x1 
       @ .equ IC_STATUS_ACTIVITY [0:0]    I2C Activity Status. Reset value: 0x0 
 
    .equ I2C1_IC_TXFLR, 0x0074 I2C Transmit FIFO Level Register This register contains the number of valid data entries in the transmit FIFO buffer. It is cleared whenever: - The I2C is disabled - There is a transmit abort - that is, TX_ABRT bit is set in the IC_RAW_INTR_STAT register - The slave bulk transmit mode is aborted The register increments whenever data is placed into the transmit FIFO and decrements when data is taken from the transmit FIFO.
       @ .equ IC_TXFLR_TXFLR [4:0]    Transmit FIFO Level. Contains the number of valid data entries in the transmit FIFO.  Reset value: 0x0 
 
    .equ I2C1_IC_RXFLR, 0x0078 I2C Receive FIFO Level Register This register contains the number of valid data entries in the receive FIFO buffer. It is cleared whenever: - The I2C is disabled - Whenever there is a transmit abort caused by any of the events tracked in IC_TX_ABRT_SOURCE The register increments whenever data is placed into the receive FIFO and decrements when data is taken from the receive FIFO.
       @ .equ IC_RXFLR_RXFLR [4:0]    Receive FIFO Level. Contains the number of valid data entries in the receive FIFO.  Reset value: 0x0 
 
    .equ I2C1_IC_SDA_HOLD, 0x007c I2C SDA Hold Time Length Register  The bits [15:0] of this register are used to control the hold time of SDA during transmit in both slave and master mode after SCL goes from HIGH to LOW.  The bits [23:16] of this register are used to extend the SDA transition if any whenever SCL is HIGH in the receiver in either master or slave mode.  Writes to this register succeed only when IC_ENABLE[0]=0.  The values in this register are in units of ic_clk period. The value programmed in IC_SDA_TX_HOLD must be greater than the minimum hold time in each mode one cycle in master mode, seven cycles in slave mode for the value to be implemented.  The programmed SDA hold time during transmit IC_SDA_TX_HOLD cannot exceed at any time the duration of the low part of scl. Therefore the programmed value cannot be larger than N_SCL_LOW-2, where N_SCL_LOW is the duration of the low part of the scl period measured in ic_clk cycles.
       @ .equ IC_SDA_HOLD_IC_SDA_RX_HOLD [23:16]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a receiver.  Reset value: IC_DEFAULT_SDA_HOLD[23:16]. 
       @ .equ IC_SDA_HOLD_IC_SDA_TX_HOLD [15:0]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a transmitter.  Reset value: IC_DEFAULT_SDA_HOLD[15:0]. 
 
    .equ I2C1_IC_TX_ABRT_SOURCE, 0x0080 I2C Transmit Abort Source Register  This register has 32 bits that indicate the source of the TX_ABRT bit. Except for Bit 9, this register is cleared whenever the IC_CLR_TX_ABRT register or the IC_CLR_INTR register is read. To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; RESTART must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10].  Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, Bit 9 clears for one cycle and is then re-asserted.
       @ .equ IC_TX_ABRT_SOURCE_TX_FLUSH_CNT [31:23]    This field indicates the number of Tx FIFO Data Commands which are flushed due to TX_ABRT interrupt. It is cleared whenever I2C is disabled.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_USER_ABRT [16:16]    This is a master-mode-only bit. Master has detected the transfer abort IC_ENABLE[1]  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SLVRD_INTX [15:15]    1: When the processor side responds to a slave mode request for data to be transmitted to a remote master and user writes a 1 in CMD bit 8 of IC_DATA_CMD register.  Reset value: 0x0  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SLV_ARBLOST [14:14]    This field indicates that a Slave has lost the bus while transmitting data to a remote master. IC_TX_ABRT_SOURCE[12] is set at the same time. Note: Even though the slave never 'owns' the bus, something could go wrong on the bus. This is a fail safe check. For instance, during a data transmission at the low-to-high transition of SCL, if what is on the data bus is not what is supposed to be transmitted, then DW_apb_i2c no longer own the bus.  Reset value: 0x0  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SLVFLUSH_TXFIFO [13:13]    This field specifies that the Slave has received a read command and some data exists in the TX FIFO, so the slave issues a TX_ABRT interrupt to flush old data in TX FIFO.  Reset value: 0x0  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ARB_LOST [12:12]    This field specifies that the Master has lost arbitration, or if IC_TX_ABRT_SOURCE[14] is also set, then the slave transmitter has lost arbitration.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_MASTER_DIS [11:11]    This field indicates that the User tries to initiate a Master operation with the Master mode disabled.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_10B_RD_NORSTRT [10:10]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the master sends a read command in 10-bit addressing mode.  Reset value: 0x0  Role of DW_apb_i2c: Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SBYTE_NORSTRT [9:9]    To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; restart must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10]. Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, bit 9 clears for one cycle and then gets reasserted. When this field is set to 1, the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to send a START Byte.  Reset value: 0x0  Role of DW_apb_i2c: Master 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_HS_NORSTRT [8:8]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to use the master to transfer data in High Speed mode.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_SBYTE_ACKDET [7:7]    This field indicates that the Master has sent a START Byte and the START Byte was acknowledged wrong behavior.  Reset value: 0x0  Role of DW_apb_i2c: Master 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_HS_ACKDET [6:6]    This field indicates that the Master is in High Speed mode and the High Speed Master code was acknowledged wrong behavior.  Reset value: 0x0  Role of DW_apb_i2c: Master 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_GCALL_READ [5:5]    This field indicates that DW_apb_i2c in the master mode has sent a General Call but the user programmed the byte following the General Call to be a read from the bus IC_DATA_CMD[9] is set to 1.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_GCALL_NOACK [4:4]    This field indicates that DW_apb_i2c in master mode has sent a General Call and no slave on the bus acknowledged the General Call.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_TXDATA_NOACK [3:3]    This field indicates the master-mode only bit. When the master receives an acknowledgement for the address, but when it sends data bytes following the address, it did not receive an acknowledge from the remote slaves.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_10ADDR2_NOACK [2:2]    This field indicates that the Master is in 10-bit address mode and that the second address byte of the 10-bit address was not acknowledged by any slave.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_10ADDR1_NOACK [1:1]    This field indicates that the Master is in 10-bit address mode and the first 10-bit address byte was not acknowledged by any slave.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ IC_TX_ABRT_SOURCE_ABRT_7B_ADDR_NOACK [0:0]    This field indicates that the Master is in 7-bit addressing mode and the address sent was not acknowledged by any slave.  Reset value: 0x0  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
 
    .equ I2C1_IC_SLV_DATA_NACK_ONLY, 0x0084 Generate Slave Data NACK Register  The register is used to generate a NACK for the data part of a transfer when DW_apb_i2c is acting as a slave-receiver. This register only exists when the IC_SLV_DATA_NACK_ONLY parameter is set to 1. When this parameter disabled, this register does not exist and writing to the register's address has no effect.  A write can occur on this register if both of the following conditions are met: - DW_apb_i2c is disabled IC_ENABLE[0] = 0 - Slave part is inactive IC_STATUS[6] = 0 Note: The IC_STATUS[6] is a register read-back location for the internal slv_activity signal; the user should poll this before writing the ic_slv_data_nack_only bit.
       @ .equ IC_SLV_DATA_NACK_ONLY_NACK [0:0]    Generate NACK. This NACK generation only occurs when DW_apb_i2c is a slave-receiver. If this register is set to a value of 1, it can only generate a NACK after a data byte is received; hence, the data transfer is aborted and the data received is not pushed to the receive buffer.  When the register is set to a value of 0, it generates NACK/ACK, depending on normal criteria. - 1: generate NACK after data byte received - 0: generate NACK/ACK normally Reset value: 0x0 
 
    .equ I2C1_IC_DMA_CR, 0x0088 DMA Control Register  The register is used to enable the DMA Controller interface operation. There is a separate bit for transmit and receive. This can be programmed regardless of the state of IC_ENABLE.
       @ .equ IC_DMA_CR_TDMAE [1:1]    Transmit DMA Enable. This bit enables/disables the transmit FIFO DMA channel. Reset value: 0x0 
       @ .equ IC_DMA_CR_RDMAE [0:0]    Receive DMA Enable. This bit enables/disables the receive FIFO DMA channel. Reset value: 0x0 
 
    .equ I2C1_IC_DMA_TDLR, 0x008c DMA Transmit Data Level Register
       @ .equ IC_DMA_TDLR_DMATDL [3:0]    Transmit Data Level. This bit field controls the level at which a DMA request is made by the transmit logic. It is equal to the watermark level; that is, the dma_tx_req signal is generated when the number of valid data entries in the transmit FIFO is equal to or below this field value, and TDMAE = 1.  Reset value: 0x0 
 
    .equ I2C1_IC_DMA_RDLR, 0x0090 I2C Receive Data Level Register
       @ .equ IC_DMA_RDLR_DMARDL [3:0]    Receive Data Level. This bit field controls the level at which a DMA request is made by the receive logic. The watermark level = DMARDL+1; that is, dma_rx_req is generated when the number of valid data entries in the receive FIFO is equal to or more than this field value + 1, and RDMAE =1. For instance, when DMARDL is 0, then dma_rx_req is asserted when 1 or more data entries are present in the receive FIFO.  Reset value: 0x0 
 
    .equ I2C1_IC_SDA_SETUP, 0x0094 I2C SDA Setup Register  This register controls the amount of time delay in terms of number of ic_clk clock periods introduced in the rising edge of SCL - relative to SDA changing - when DW_apb_i2c services a read request in a slave-transmitter operation. The relevant I2C requirement is tSU:DAT note 4 as detailed in the I2C Bus Specification. This register must be programmed with a value equal to or greater than 2.  Writes to this register succeed only when IC_ENABLE[0] = 0.  Note: The length of setup time is calculated using [IC_SDA_SETUP - 1 * ic_clk_period], so if the user requires 10 ic_clk periods of setup time, they should program a value of 11. The IC_SDA_SETUP register is only used by the DW_apb_i2c when operating as a slave transmitter.
       @ .equ IC_SDA_SETUP_SDA_SETUP [7:0]    SDA Setup. It is recommended that if the required delay is 1000ns, then for an ic_clk frequency of 10 MHz, IC_SDA_SETUP should be programmed to a value of 11. IC_SDA_SETUP must be programmed with a minimum value of 2. 
 
    .equ I2C1_IC_ACK_GENERAL_CALL, 0x0098 I2C ACK General Call Register  The register controls whether DW_apb_i2c responds with a ACK or NACK when it receives an I2C General Call address.  This register is applicable only when the DW_apb_i2c is in slave mode.
       @ .equ IC_ACK_GENERAL_CALL_ACK_GEN_CALL [0:0]    ACK General Call. When set to 1, DW_apb_i2c responds with a ACK by asserting ic_data_oe when it receives a General Call. Otherwise, DW_apb_i2c responds with a NACK by negating ic_data_oe. 
 
    .equ I2C1_IC_ENABLE_STATUS, 0x009c I2C Enable Status Register  The register is used to report the DW_apb_i2c hardware status when the IC_ENABLE[0] register is set from 1 to 0; that is, when DW_apb_i2c is disabled.  If IC_ENABLE[0] has been set to 1, bits 2:1 are forced to 0, and bit 0 is forced to 1.  If IC_ENABLE[0] has been set to 0, bits 2:1 is only be valid as soon as bit 0 is read as '0'.  Note: When IC_ENABLE[0] has been set to 0, a delay occurs for bit 0 to be read as 0 because disabling the DW_apb_i2c depends on I2C bus activities.
       @ .equ IC_ENABLE_STATUS_SLV_RX_DATA_LOST [2:2]    Slave Received Data Lost. This bit indicates if a Slave-Receiver operation has been aborted with at least one data byte received from an I2C transfer due to the setting bit 0 of IC_ENABLE from 1 to 0. When read as 1, DW_apb_i2c is deemed to have been actively engaged in an aborted I2C transfer with matching address and the data phase of the I2C transfer has been entered, even though a data byte has been responded with a NACK.  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit is also set to 1.  When read as 0, DW_apb_i2c is deemed to have been disabled without being actively involved in the data phase of a Slave-Receiver transfer.  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.  Reset value: 0x0 
       @ .equ IC_ENABLE_STATUS_SLV_DISABLED_WHILE_BUSY [1:1]    Slave Disabled While Busy Transmit, Receive. This bit indicates if a potential or active Slave operation has been aborted due to the setting bit 0 of the IC_ENABLE register from 1 to 0. This bit is set when the CPU writes a 0 to the IC_ENABLE register while:  a DW_apb_i2c is receiving the address byte of the Slave-Transmitter operation from a remote master;  OR,  b address and data bytes of the Slave-Receiver operation from a remote master.  When read as 1, DW_apb_i2c is deemed to have forced a NACK during any part of an I2C transfer, irrespective of whether the I2C address matches the slave address set in DW_apb_i2c IC_SAR register OR if the transfer is completed before IC_ENABLE is set to 0 but has not taken effect.  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit will also be set to 1.  When read as 0, DW_apb_i2c is deemed to have been disabled when there is master activity, or when the I2C bus is idle.  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.  Reset value: 0x0 
       @ .equ IC_ENABLE_STATUS_IC_EN [0:0]    ic_en Status. This bit always reflects the value driven on the output port ic_en. - When read as 1, DW_apb_i2c is deemed to be in an enabled state. - When read as 0, DW_apb_i2c is deemed completely inactive. Note: The CPU can safely read this bit anytime. When this bit is read as 0, the CPU can safely read SLV_RX_DATA_LOST bit 2 and SLV_DISABLED_WHILE_BUSY bit 1.  Reset value: 0x0 
 
    .equ I2C1_IC_FS_SPKLEN, 0x00a0 I2C SS, FS or FM+ spike suppression limit  This register is used to store the duration, measured in ic_clk cycles, of the longest spike that is filtered out by the spike suppression logic when the component is operating in SS, FS or FM+ modes. The relevant I2C requirement is tSP table 4 as detailed in the I2C Bus Specification. This register must be programmed with a minimum value of 1.
       @ .equ IC_FS_SPKLEN_IC_FS_SPKLEN [7:0]    This register must be set before any I2C bus transaction can take place to ensure stable operation. This register sets the duration, measured in ic_clk cycles, of the longest spike in the SCL or SDA lines that will be filtered out by the spike suppression logic. This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect. The minimum valid value is 1; hardware prevents values less than this being written, and if attempted results in 1 being set. or more information, refer to 'Spike Suppression'. 
 
    .equ I2C1_IC_CLR_RESTART_DET, 0x00a8 Clear RESTART_DET Interrupt Register
       @ .equ IC_CLR_RESTART_DET_CLR_RESTART_DET [0:0]    Read this register to clear the RESTART_DET interrupt bit 12 of IC_RAW_INTR_STAT register.  Reset value: 0x0 
 
    .equ I2C1_IC_COMP_PARAM_1, 0x00f4 Component Parameter Register 1  Note This register is not implemented and therefore reads as 0. If it was implemented it would be a constant read-only register that contains encoded information about the component's parameter settings. Fields shown below are the settings for those parameters
       @ .equ IC_COMP_PARAM_1_TX_BUFFER_DEPTH [23:16]    TX Buffer Depth = 16 
       @ .equ IC_COMP_PARAM_1_RX_BUFFER_DEPTH [15:8]    RX Buffer Depth = 16 
       @ .equ IC_COMP_PARAM_1_ADD_ENCODED_PARAMS [7:7]    Encoded parameters not visible 
       @ .equ IC_COMP_PARAM_1_HAS_DMA [6:6]    DMA handshaking signals are enabled 
       @ .equ IC_COMP_PARAM_1_INTR_IO [5:5]    COMBINED Interrupt outputs 
       @ .equ IC_COMP_PARAM_1_HC_COUNT_VALUES [4:4]    Programmable count values for each mode. 
       @ .equ IC_COMP_PARAM_1_MAX_SPEED_MODE [3:2]    MAX SPEED MODE = FAST MODE 
       @ .equ IC_COMP_PARAM_1_APB_DATA_WIDTH [1:0]    APB data bus width is 32 bits 
 
    .equ I2C1_IC_COMP_VERSION, 0x00f8 I2C Component Version Register
       @ .equ IC_COMP_VERSION_IC_COMP_VERSION [31:0]     
 
    .equ I2C1_IC_COMP_TYPE, 0x00fc I2C Component Type Register
       @ .equ IC_COMP_TYPE_IC_COMP_TYPE [31:0]    Designware Component Type number = 0x44_57_01_40. This assigned unique hex value is constant and is derived from the two ASCII letters 'DW' followed by a 16-bit unsigned number. 
 

@=========================== ADC ===========================@
.equ ADC_BASE, 0x4004c000 Control and data interface to SAR ADC
    .equ ADC_CS, 0x0000 ADC Control and Status
       @ .equ CS_RROBIN [20:16]    Round-robin sampling. 1 bit per channel. Set all bits to 0 to disable.  Otherwise, the ADC will cycle through each enabled channel in a round-robin fashion.  The first channel to be sampled will be the one currently indicated by AINSEL.  AINSEL will be updated after each conversion with the newly-selected channel. 
       @ .equ CS_AINSEL [14:12]    Select analog mux input. Updated automatically in round-robin mode. 
       @ .equ CS_ERR_STICKY [10:10]    Some past ADC conversion encountered an error. Write 1 to clear. 
       @ .equ CS_ERR [9:9]    The most recent ADC conversion encountered an error; result is undefined or noisy. 
       @ .equ CS_READY [8:8]    1 if the ADC is ready to start a new conversion. Implies any previous conversion has completed.  0 whilst conversion in progress. 
       @ .equ CS_START_MANY [3:3]    Continuously perform conversions whilst this bit is 1. A new conversion will start immediately after the previous finishes. 
       @ .equ CS_START_ONCE [2:2]    Start a single conversion. Self-clearing. Ignored if start_many is asserted. 
       @ .equ CS_TS_EN [1:1]    Power on temperature sensor. 1 - enabled. 0 - disabled. 
       @ .equ CS_EN [0:0]    Power on ADC and enable its clock.  1 - enabled. 0 - disabled. 
 
    .equ ADC_RESULT, 0x0004 Result of most recent ADC conversion
       @ .equ RESULT_RESULT [11:0]     
 
    .equ ADC_FCS, 0x0008 FIFO control and status
       @ .equ FCS_THRESH [27:24]    DREQ/IRQ asserted when level >= threshold 
       @ .equ FCS_LEVEL [19:16]    The number of conversion results currently waiting in the FIFO 
       @ .equ FCS_OVER [11:11]    1 if the FIFO has been overflowed. Write 1 to clear. 
       @ .equ FCS_UNDER [10:10]    1 if the FIFO has been underflowed. Write 1 to clear. 
       @ .equ FCS_FULL [9:9]     
       @ .equ FCS_EMPTY [8:8]     
       @ .equ FCS_DREQ_EN [3:3]    If 1: assert DMA requests when FIFO contains data 
       @ .equ FCS_ERR [2:2]    If 1: conversion error bit appears in the FIFO alongside the result 
       @ .equ FCS_SHIFT [1:1]    If 1: FIFO results are right-shifted to be one byte in size. Enables DMA to byte buffers. 
       @ .equ FCS_EN [0:0]    If 1: write result to the FIFO after each conversion. 
 
    .equ ADC_FIFO, 0x000c Conversion result FIFO
       @ .equ FIFO_ERR [15:15]    1 if this particular sample experienced a conversion error. Remains in the same location if the sample is shifted. 
       @ .equ FIFO_VAL [11:0]     
 
    .equ ADC_DIV, 0x0010 Clock divider. If non-zero, CS_START_MANY will start conversions  at regular intervals rather than back-to-back.  The divider is reset when either of these fields are written.  Total period is 1 + INT + FRAC / 256
       @ .equ DIV_INT [23:8]    Integer part of clock divisor. 
       @ .equ DIV_FRAC [7:0]    Fractional part of clock divisor. First-order delta-sigma. 
 
    .equ ADC_INTR, 0x0014 Raw Interrupts
       @ .equ INTR_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.  This level can be programmed via the FCS_THRESH field. 
 
    .equ ADC_INTE, 0x0018 Interrupt Enable
       @ .equ INTE_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.  This level can be programmed via the FCS_THRESH field. 
 
    .equ ADC_INTF, 0x001c Interrupt Force
       @ .equ INTF_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.  This level can be programmed via the FCS_THRESH field. 
 
    .equ ADC_INTS, 0x0020 Interrupt status after masking & forcing
       @ .equ INTS_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.  This level can be programmed via the FCS_THRESH field. 
 

@=========================== PWM ===========================@
.equ PWM_BASE, 0x40050000 Simple PWM
    .equ PWM_CH0_CSR, 0x0000 Control and status register
       @ .equ CH0_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH0_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH0_CSR_DIVMODE [5:4]     
       @ .equ CH0_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH0_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH0_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH0_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH0_DIV, 0x0004 INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH0_DIV_INT [11:4]     
       @ .equ CH0_DIV_FRAC [3:0]     
 
    .equ PWM_CH0_CTR, 0x0008 Direct access to the PWM counter
       @ .equ CH0_CTR_CH0_CTR [15:0]     
 
    .equ PWM_CH0_CC, 0x000c Counter compare values
       @ .equ CH0_CC_B [31:16]     
       @ .equ CH0_CC_A [15:0]     
 
    .equ PWM_CH0_TOP, 0x0010 Counter wrap value
       @ .equ CH0_TOP_CH0_TOP [15:0]     
 
    .equ PWM_CH1_CSR, 0x0014 Control and status register
       @ .equ CH1_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH1_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH1_CSR_DIVMODE [5:4]     
       @ .equ CH1_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH1_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH1_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH1_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH1_DIV, 0x0018 INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH1_DIV_INT [11:4]     
       @ .equ CH1_DIV_FRAC [3:0]     
 
    .equ PWM_CH1_CTR, 0x001c Direct access to the PWM counter
       @ .equ CH1_CTR_CH1_CTR [15:0]     
 
    .equ PWM_CH1_CC, 0x0020 Counter compare values
       @ .equ CH1_CC_B [31:16]     
       @ .equ CH1_CC_A [15:0]     
 
    .equ PWM_CH1_TOP, 0x0024 Counter wrap value
       @ .equ CH1_TOP_CH1_TOP [15:0]     
 
    .equ PWM_CH2_CSR, 0x0028 Control and status register
       @ .equ CH2_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH2_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH2_CSR_DIVMODE [5:4]     
       @ .equ CH2_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH2_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH2_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH2_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH2_DIV, 0x002c INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH2_DIV_INT [11:4]     
       @ .equ CH2_DIV_FRAC [3:0]     
 
    .equ PWM_CH2_CTR, 0x0030 Direct access to the PWM counter
       @ .equ CH2_CTR_CH2_CTR [15:0]     
 
    .equ PWM_CH2_CC, 0x0034 Counter compare values
       @ .equ CH2_CC_B [31:16]     
       @ .equ CH2_CC_A [15:0]     
 
    .equ PWM_CH2_TOP, 0x0038 Counter wrap value
       @ .equ CH2_TOP_CH2_TOP [15:0]     
 
    .equ PWM_CH3_CSR, 0x003c Control and status register
       @ .equ CH3_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH3_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH3_CSR_DIVMODE [5:4]     
       @ .equ CH3_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH3_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH3_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH3_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH3_DIV, 0x0040 INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH3_DIV_INT [11:4]     
       @ .equ CH3_DIV_FRAC [3:0]     
 
    .equ PWM_CH3_CTR, 0x0044 Direct access to the PWM counter
       @ .equ CH3_CTR_CH3_CTR [15:0]     
 
    .equ PWM_CH3_CC, 0x0048 Counter compare values
       @ .equ CH3_CC_B [31:16]     
       @ .equ CH3_CC_A [15:0]     
 
    .equ PWM_CH3_TOP, 0x004c Counter wrap value
       @ .equ CH3_TOP_CH3_TOP [15:0]     
 
    .equ PWM_CH4_CSR, 0x0050 Control and status register
       @ .equ CH4_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH4_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH4_CSR_DIVMODE [5:4]     
       @ .equ CH4_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH4_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH4_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH4_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH4_DIV, 0x0054 INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH4_DIV_INT [11:4]     
       @ .equ CH4_DIV_FRAC [3:0]     
 
    .equ PWM_CH4_CTR, 0x0058 Direct access to the PWM counter
       @ .equ CH4_CTR_CH4_CTR [15:0]     
 
    .equ PWM_CH4_CC, 0x005c Counter compare values
       @ .equ CH4_CC_B [31:16]     
       @ .equ CH4_CC_A [15:0]     
 
    .equ PWM_CH4_TOP, 0x0060 Counter wrap value
       @ .equ CH4_TOP_CH4_TOP [15:0]     
 
    .equ PWM_CH5_CSR, 0x0064 Control and status register
       @ .equ CH5_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH5_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH5_CSR_DIVMODE [5:4]     
       @ .equ CH5_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH5_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH5_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH5_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH5_DIV, 0x0068 INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH5_DIV_INT [11:4]     
       @ .equ CH5_DIV_FRAC [3:0]     
 
    .equ PWM_CH5_CTR, 0x006c Direct access to the PWM counter
       @ .equ CH5_CTR_CH5_CTR [15:0]     
 
    .equ PWM_CH5_CC, 0x0070 Counter compare values
       @ .equ CH5_CC_B [31:16]     
       @ .equ CH5_CC_A [15:0]     
 
    .equ PWM_CH5_TOP, 0x0074 Counter wrap value
       @ .equ CH5_TOP_CH5_TOP [15:0]     
 
    .equ PWM_CH6_CSR, 0x0078 Control and status register
       @ .equ CH6_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH6_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH6_CSR_DIVMODE [5:4]     
       @ .equ CH6_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH6_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH6_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH6_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH6_DIV, 0x007c INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH6_DIV_INT [11:4]     
       @ .equ CH6_DIV_FRAC [3:0]     
 
    .equ PWM_CH6_CTR, 0x0080 Direct access to the PWM counter
       @ .equ CH6_CTR_CH6_CTR [15:0]     
 
    .equ PWM_CH6_CC, 0x0084 Counter compare values
       @ .equ CH6_CC_B [31:16]     
       @ .equ CH6_CC_A [15:0]     
 
    .equ PWM_CH6_TOP, 0x0088 Counter wrap value
       @ .equ CH6_TOP_CH6_TOP [15:0]     
 
    .equ PWM_CH7_CSR, 0x008c Control and status register
       @ .equ CH7_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ CH7_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ CH7_CSR_DIVMODE [5:4]     
       @ .equ CH7_CSR_B_INV [3:3]    Invert output B 
       @ .equ CH7_CSR_A_INV [2:2]    Invert output A 
       @ .equ CH7_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ CH7_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH7_DIV, 0x0090 INT and FRAC form a fixed-point fractional number.  Counting rate is system clock frequency divided by this number.  Fractional division uses simple 1st-order sigma-delta.
       @ .equ CH7_DIV_INT [11:4]     
       @ .equ CH7_DIV_FRAC [3:0]     
 
    .equ PWM_CH7_CTR, 0x0094 Direct access to the PWM counter
       @ .equ CH7_CTR_CH7_CTR [15:0]     
 
    .equ PWM_CH7_CC, 0x0098 Counter compare values
       @ .equ CH7_CC_B [31:16]     
       @ .equ CH7_CC_A [15:0]     
 
    .equ PWM_CH7_TOP, 0x009c Counter wrap value
       @ .equ CH7_TOP_CH7_TOP [15:0]     
 
    .equ PWM_EN, 0x00a0 This register aliases the CSR_EN bits for all channels.  Writing to this register allows multiple channels to be enabled  or disabled simultaneously, so they can run in perfect sync.  For each channel, there is only one physical EN register bit,  which can be accessed through here or CHx_CSR.
       @ .equ EN_CH7 [7:7]     
       @ .equ EN_CH6 [6:6]     
       @ .equ EN_CH5 [5:5]     
       @ .equ EN_CH4 [4:4]     
       @ .equ EN_CH3 [3:3]     
       @ .equ EN_CH2 [2:2]     
       @ .equ EN_CH1 [1:1]     
       @ .equ EN_CH0 [0:0]     
 
    .equ PWM_INTR, 0x00a4 Raw Interrupts
       @ .equ INTR_CH7 [7:7]     
       @ .equ INTR_CH6 [6:6]     
       @ .equ INTR_CH5 [5:5]     
       @ .equ INTR_CH4 [4:4]     
       @ .equ INTR_CH3 [3:3]     
       @ .equ INTR_CH2 [2:2]     
       @ .equ INTR_CH1 [1:1]     
       @ .equ INTR_CH0 [0:0]     
 
    .equ PWM_INTE, 0x00a8 Interrupt Enable
       @ .equ INTE_CH7 [7:7]     
       @ .equ INTE_CH6 [6:6]     
       @ .equ INTE_CH5 [5:5]     
       @ .equ INTE_CH4 [4:4]     
       @ .equ INTE_CH3 [3:3]     
       @ .equ INTE_CH2 [2:2]     
       @ .equ INTE_CH1 [1:1]     
       @ .equ INTE_CH0 [0:0]     
 
    .equ PWM_INTF, 0x00ac Interrupt Force
       @ .equ INTF_CH7 [7:7]     
       @ .equ INTF_CH6 [6:6]     
       @ .equ INTF_CH5 [5:5]     
       @ .equ INTF_CH4 [4:4]     
       @ .equ INTF_CH3 [3:3]     
       @ .equ INTF_CH2 [2:2]     
       @ .equ INTF_CH1 [1:1]     
       @ .equ INTF_CH0 [0:0]     
 
    .equ PWM_INTS, 0x00b0 Interrupt status after masking & forcing
       @ .equ INTS_CH7 [7:7]     
       @ .equ INTS_CH6 [6:6]     
       @ .equ INTS_CH5 [5:5]     
       @ .equ INTS_CH4 [4:4]     
       @ .equ INTS_CH3 [3:3]     
       @ .equ INTS_CH2 [2:2]     
       @ .equ INTS_CH1 [1:1]     
       @ .equ INTS_CH0 [0:0]     
 

@=========================== TIMER ===========================@
.equ TIMER_BASE, 0x40054000 Controls time and alarms  time is a 64 bit value indicating the time in usec since power-on  timeh is the top 32 bits of time & timel is the bottom 32 bits  to change time write to timelw before timehw  to read time read from timelr before timehr  An alarm is set by setting alarm_enable and writing to the corresponding alarm register  When an alarm is pending, the corresponding alarm_running signal will be high  An alarm can be cancelled before it has finished by clearing the alarm_enable  When an alarm fires, the corresponding alarm_irq is set and alarm_running is cleared  To clear the interrupt write a 1 to the corresponding alarm_irq
    .equ TIMER_TIMEHW, 0x0000 Write to bits 63:32 of time  always write timelw before timehw
 
    .equ TIMER_TIMELW, 0x0004 Write to bits 31:0 of time  writes do not get copied to time until timehw is written
 
    .equ TIMER_TIMEHR, 0x0008 Read from bits 63:32 of time  always read timelr before timehr
 
    .equ TIMER_TIMELR, 0x000c Read from bits 31:0 of time
 
    .equ TIMER_ALARM0, 0x0010 Arm alarm 0, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM0 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
 
    .equ TIMER_ALARM1, 0x0014 Arm alarm 1, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM1 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
 
    .equ TIMER_ALARM2, 0x0018 Arm alarm 2, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM2 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
 
    .equ TIMER_ALARM3, 0x001c Arm alarm 3, and configure the time it will fire.  Once armed, the alarm fires when TIMER_ALARM3 == TIMELR.  The alarm will disarm itself once it fires, and can  be disarmed early using the ARMED status register.
 
    .equ TIMER_ARMED, 0x0020 Indicates the armed/disarmed status of each alarm.  A write to the corresponding ALARMx register arms the alarm.  Alarms automatically disarm upon firing, but writing ones here  will disarm immediately without waiting to fire.
       @ .equ ARMED_ARMED [3:0]     
 
    .equ TIMER_TIMERAWH, 0x0024 Raw read from bits 63:32 of time no side effects
 
    .equ TIMER_TIMERAWL, 0x0028 Raw read from bits 31:0 of time no side effects
 
    .equ TIMER_DBGPAUSE, 0x002c Set bits high to enable pause when the corresponding debug ports are active
       @ .equ DBGPAUSE_DBG1 [2:2]    Pause when processor 1 is in debug mode 
       @ .equ DBGPAUSE_DBG0 [1:1]    Pause when processor 0 is in debug mode 
 
    .equ TIMER_PAUSE, 0x0030 Set high to pause the timer
       @ .equ PAUSE_PAUSE [0:0]     
 
    .equ TIMER_INTR, 0x0034 Raw Interrupts
       @ .equ INTR_ALARM_3 [3:3]     
       @ .equ INTR_ALARM_2 [2:2]     
       @ .equ INTR_ALARM_1 [1:1]     
       @ .equ INTR_ALARM_0 [0:0]     
 
    .equ TIMER_INTE, 0x0038 Interrupt Enable
       @ .equ INTE_ALARM_3 [3:3]     
       @ .equ INTE_ALARM_2 [2:2]     
       @ .equ INTE_ALARM_1 [1:1]     
       @ .equ INTE_ALARM_0 [0:0]     
 
    .equ TIMER_INTF, 0x003c Interrupt Force
       @ .equ INTF_ALARM_3 [3:3]     
       @ .equ INTF_ALARM_2 [2:2]     
       @ .equ INTF_ALARM_1 [1:1]     
       @ .equ INTF_ALARM_0 [0:0]     
 
    .equ TIMER_INTS, 0x0040 Interrupt status after masking & forcing
       @ .equ INTS_ALARM_3 [3:3]     
       @ .equ INTS_ALARM_2 [2:2]     
       @ .equ INTS_ALARM_1 [1:1]     
       @ .equ INTS_ALARM_0 [0:0]     
 

@=========================== WATCHDOG ===========================@
.equ WATCHDOG_BASE, 0x40058000 
    .equ WATCHDOG_CTRL, 0x0000 Watchdog control  The rst_wdsel register determines which subsystems are reset when the watchdog is triggered.  The watchdog can be triggered in software.
       @ .equ CTRL_TRIGGER [31:31]    Trigger a watchdog reset 
       @ .equ CTRL_ENABLE [30:30]    When not enabled the watchdog timer is paused 
       @ .equ CTRL_PAUSE_DBG1 [26:26]    Pause the watchdog timer when processor 1 is in debug mode 
       @ .equ CTRL_PAUSE_DBG0 [25:25]    Pause the watchdog timer when processor 0 is in debug mode 
       @ .equ CTRL_PAUSE_JTAG [24:24]    Pause the watchdog timer when JTAG is accessing the bus fabric 
       @ .equ CTRL_TIME [23:0]    Indicates the number of ticks / 2 see errata RP2040-E1 before a watchdog reset will be triggered 
 
    .equ WATCHDOG_LOAD, 0x0004 Load the watchdog timer. The maximum setting is 0xffffff which corresponds to 0xffffff / 2 ticks before triggering a watchdog reset see errata RP2040-E1.
       @ .equ LOAD_LOAD [23:0]     
 
    .equ WATCHDOG_REASON, 0x0008 Logs the reason for the last reset. Both bits are zero for the case of a hardware reset.
       @ .equ REASON_FORCE [1:1]     
       @ .equ REASON_TIMER [0:0]     
 
    .equ WATCHDOG_SCRATCH0, 0x000c Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH1, 0x0010 Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH2, 0x0014 Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH3, 0x0018 Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH4, 0x001c Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH5, 0x0020 Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH6, 0x0024 Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_SCRATCH7, 0x0028 Scratch register. Information persists through soft reset of the chip.
 
    .equ WATCHDOG_TICK, 0x002c Controls the tick generator
       @ .equ TICK_COUNT [19:11]    Count down timer: the remaining number clk_tick cycles before the next tick is generated. 
       @ .equ TICK_RUNNING [10:10]    Is the tick generator running? 
       @ .equ TICK_ENABLE [9:9]    start / stop tick generation 
       @ .equ TICK_CYCLES [8:0]    Total number of clk_tick cycles before the next tick. 
 

@=========================== RTC ===========================@
.equ RTC_BASE, 0x4005c000 Register block to control RTC
    .equ RTC_CLKDIV_M1, 0x0000 Divider minus 1 for the 1 second counter. Safe to change the value when RTC is not enabled.
       @ .equ CLKDIV_M1_CLKDIV_M1 [15:0]     
 
    .equ RTC_SETUP_0, 0x0004 RTC setup register 0
       @ .equ SETUP_0_YEAR [23:12]    Year 
       @ .equ SETUP_0_MONTH [11:8]    Month 1..12 
       @ .equ SETUP_0_DAY [4:0]    Day of the month 1..31 
 
    .equ RTC_SETUP_1, 0x0008 RTC setup register 1
       @ .equ SETUP_1_DOTW [26:24]    Day of the week: 1-Monday...0-Sunday ISO 8601 mod 7 
       @ .equ SETUP_1_HOUR [20:16]    Hours 
       @ .equ SETUP_1_MIN [13:8]    Minutes 
       @ .equ SETUP_1_SEC [5:0]    Seconds 
 
    .equ RTC_CTRL, 0x000c RTC Control and status
       @ .equ CTRL_FORCE_NOTLEAPYEAR [8:8]    If set, leapyear is forced off.  Useful for years divisible by 100 but not by 400 
       @ .equ CTRL_LOAD [4:4]    Load RTC 
       @ .equ CTRL_RTC_ACTIVE [1:1]    RTC enabled running 
       @ .equ CTRL_RTC_ENABLE [0:0]    Enable RTC 
 
    .equ RTC_IRQ_SETUP_0, 0x0010 Interrupt setup register 0
       @ .equ IRQ_SETUP_0_MATCH_ACTIVE [29:29]     
       @ .equ IRQ_SETUP_0_MATCH_ENA [28:28]    Global match enable. Don't change any other value while this one is enabled 
       @ .equ IRQ_SETUP_0_YEAR_ENA [26:26]    Enable year matching 
       @ .equ IRQ_SETUP_0_MONTH_ENA [25:25]    Enable month matching 
       @ .equ IRQ_SETUP_0_DAY_ENA [24:24]    Enable day matching 
       @ .equ IRQ_SETUP_0_YEAR [23:12]    Year 
       @ .equ IRQ_SETUP_0_MONTH [11:8]    Month 1..12 
       @ .equ IRQ_SETUP_0_DAY [4:0]    Day of the month 1..31 
 
    .equ RTC_IRQ_SETUP_1, 0x0014 Interrupt setup register 1
       @ .equ IRQ_SETUP_1_DOTW_ENA [31:31]    Enable day of the week matching 
       @ .equ IRQ_SETUP_1_HOUR_ENA [30:30]    Enable hour matching 
       @ .equ IRQ_SETUP_1_MIN_ENA [29:29]    Enable minute matching 
       @ .equ IRQ_SETUP_1_SEC_ENA [28:28]    Enable second matching 
       @ .equ IRQ_SETUP_1_DOTW [26:24]    Day of the week 
       @ .equ IRQ_SETUP_1_HOUR [20:16]    Hours 
       @ .equ IRQ_SETUP_1_MIN [13:8]    Minutes 
       @ .equ IRQ_SETUP_1_SEC [5:0]    Seconds 
 
    .equ RTC_RTC_1, 0x0018 RTC register 1.
       @ .equ RTC_1_YEAR [23:12]    Year 
       @ .equ RTC_1_MONTH [11:8]    Month 1..12 
       @ .equ RTC_1_DAY [4:0]    Day of the month 1..31 
 
    .equ RTC_RTC_0, 0x001c RTC register 0  Read this before RTC 1!
       @ .equ RTC_0_DOTW [26:24]    Day of the week 
       @ .equ RTC_0_HOUR [20:16]    Hours 
       @ .equ RTC_0_MIN [13:8]    Minutes 
       @ .equ RTC_0_SEC [5:0]    Seconds 
 
    .equ RTC_INTR, 0x0020 Raw Interrupts
       @ .equ INTR_RTC [0:0]     
 
    .equ RTC_INTE, 0x0024 Interrupt Enable
       @ .equ INTE_RTC [0:0]     
 
    .equ RTC_INTF, 0x0028 Interrupt Force
       @ .equ INTF_RTC [0:0]     
 
    .equ RTC_INTS, 0x002c Interrupt status after masking & forcing
       @ .equ INTS_RTC [0:0]     
 

@=========================== ROSC ===========================@
.equ ROSC_BASE, 0x40060000 
    .equ ROSC_CTRL, 0x0000 Ring Oscillator control
       @ .equ CTRL_ENABLE [23:12]    On power-up this field is initialised to ENABLE  The system clock must be switched to another source before setting this field to DISABLE otherwise the chip will lock up  The 12-bit code is intended to give some protection against accidental writes. An invalid setting will enable the oscillator. 
       @ .equ CTRL_FREQ_RANGE [11:0]    Controls the number of delay stages in the ROSC ring  LOW uses stages 0 to 7  MEDIUM uses stages 0 to 5  HIGH uses stages 0 to 3  TOOHIGH uses stages 0 to 1 and should not be used because its frequency exceeds design specifications  The clock output will not glitch when changing the range up one step at a time  The clock output will glitch when changing the range down  Note: the values here are gray coded which is why HIGH comes before TOOHIGH 
 
    .equ ROSC_FREQA, 0x0004 The FREQA & FREQB registers control the frequency by controlling the drive strength of each stage  The drive strength has 4 levels determined by the number of bits set  Increasing the number of bits set increases the drive strength and increases the oscillation frequency  0 bits set is the default drive strength  1 bit set doubles the drive strength  2 bits set triples drive strength  3 bits set quadruples drive strength
       @ .equ FREQA_PASSWD [31:16]    Set to 0x9696 to apply the settings  Any other value in this field will set all drive strengths to 0 
       @ .equ FREQA_DS3 [14:12]    Stage 3 drive strength 
       @ .equ FREQA_DS2 [10:8]    Stage 2 drive strength 
       @ .equ FREQA_DS1 [6:4]    Stage 1 drive strength 
       @ .equ FREQA_DS0 [2:0]    Stage 0 drive strength 
 
    .equ ROSC_FREQB, 0x0008 For a detailed description see freqa register
       @ .equ FREQB_PASSWD [31:16]    Set to 0x9696 to apply the settings  Any other value in this field will set all drive strengths to 0 
       @ .equ FREQB_DS7 [14:12]    Stage 7 drive strength 
       @ .equ FREQB_DS6 [10:8]    Stage 6 drive strength 
       @ .equ FREQB_DS5 [6:4]    Stage 5 drive strength 
       @ .equ FREQB_DS4 [2:0]    Stage 4 drive strength 
 
    .equ ROSC_DORMANT, 0x000c Ring Oscillator pause control  This is used to save power by pausing the ROSC  On power-up this field is initialised to WAKE  An invalid write will also select WAKE  Warning: setup the irq before selecting dormant mode
 
    .equ ROSC_DIV, 0x0010 Controls the output divider
       @ .equ DIV_DIV [11:0]    set to 0xaa0 + div where  div = 0 divides by 32  div = 1-31 divides by div  any other value sets div=0 and therefore divides by 32  this register resets to div=16 
 
    .equ ROSC_PHASE, 0x0014 Controls the phase shifted output
       @ .equ PHASE_PASSWD [11:4]    set to 0xaa0  any other value enables the output with shift=0 
       @ .equ PHASE_ENABLE [3:3]    enable the phase-shifted output  this can be changed on-the-fly 
       @ .equ PHASE_FLIP [2:2]    invert the phase-shifted output  this is ignored when div=1 
       @ .equ PHASE_SHIFT [1:0]    phase shift the phase-shifted output by SHIFT input clocks  this can be changed on-the-fly  must be set to 0 before setting div=1 
 
    .equ ROSC_STATUS, 0x0018 Ring Oscillator Status
       @ .equ STATUS_STABLE [31:31]    Oscillator is running and stable 
       @ .equ STATUS_BADWRITE [24:24]    An invalid value has been written to CTRL_ENABLE or CTRL_FREQ_RANGE or FRFEQA or FREQB or DORMANT 
       @ .equ STATUS_DIV_RUNNING [16:16]    post-divider is running  this resets to 0 but transitions to 1 during chip startup 
       @ .equ STATUS_ENABLED [12:12]    Oscillator is enabled but not necessarily running and stable  this resets to 0 but transitions to 1 during chip startup 
 
    .equ ROSC_RANDOMBIT, 0x001c This just reads the state of the oscillator output so randomness is compromised if the ring oscillator is stopped or run at a harmonic of the bus frequency
       @ .equ RANDOMBIT_RANDOMBIT [0:0]     
 
    .equ ROSC_COUNT, 0x0020 A down counter running at the ROSC frequency which counts to zero and stops.  To start the counter write a non-zero value.  Can be used for short software pauses when setting up time sensitive hardware.
       @ .equ COUNT_COUNT [7:0]     
 

@=========================== VREG_AND_CHIP_RESET ===========================@
.equ VREG_AND_CHIP_RESET_BASE, 0x40064000 control and status for on-chip voltage regulator and chip level reset subsystem
    .equ VREG_AND_CHIP_RESET_VREG, 0x0000 Voltage regulator control and status
       @ .equ VREG_ROK [12:12]    regulation status  0=not in regulation, 1=in regulation 
       @ .equ VREG_VSEL [7:4]    output voltage select  0000 to 0101 - 0.80V  0110 - 0.85V  0111 - 0.90V  1000 - 0.95V  1001 - 1.00V  1010 - 1.05V  1011 - 1.10V default  1100 - 1.15V  1101 - 1.20V  1110 - 1.25V  1111 - 1.30V 
       @ .equ VREG_HIZ [1:1]    high impedance mode select  0=not in high impedance mode, 1=in high impedance mode 
       @ .equ VREG_EN [0:0]    enable  0=not enabled, 1=enabled 
 
    .equ VREG_AND_CHIP_RESET_BOD, 0x0004 brown-out detection control
       @ .equ BOD_VSEL [7:4]    threshold select  0000 - 0.473V  0001 - 0.516V  0010 - 0.559V  0011 - 0.602V  0100 - 0.645V  0101 - 0.688V  0110 - 0.731V  0111 - 0.774V  1000 - 0.817V  1001 - 0.860V default  1010 - 0.903V  1011 - 0.946V  1100 - 0.989V  1101 - 1.032V  1110 - 1.075V  1111 - 1.118V 
       @ .equ BOD_EN [0:0]    enable  0=not enabled, 1=enabled 
 
    .equ VREG_AND_CHIP_RESET_CHIP_RESET, 0x0008 Chip reset control and status
       @ .equ CHIP_RESET_PSM_RESTART_FLAG [24:24]    This is set by psm_restart from the debugger.  Its purpose is to branch bootcode to a safe mode when the debugger has issued a psm_restart in order to recover from a boot lock-up.  In the safe mode the debugger can repair the boot code, clear this flag then reboot the processor. 
       @ .equ CHIP_RESET_HAD_PSM_RESTART [20:20]    Last reset was from the debug port 
       @ .equ CHIP_RESET_HAD_RUN [16:16]    Last reset was from the RUN pin 
       @ .equ CHIP_RESET_HAD_POR [8:8]    Last reset was from the power-on reset or brown-out detection blocks 
 

@=========================== TBMAN ===========================@
.equ TBMAN_BASE, 0x4006c000 Testbench manager. Allows the programmer to know what platform their software is running on.
    .equ TBMAN_PLATFORM, 0x0000 Indicates the type of platform in use
       @ .equ PLATFORM_FPGA [1:1]    Indicates the platform is an FPGA 
       @ .equ PLATFORM_ASIC [0:0]    Indicates the platform is an ASIC 
 

@=========================== DMA ===========================@
.equ DMA_BASE, 0x50000000 DMA with separate read and write masters
    .equ DMA_CH0_READ_ADDR, 0x0000 DMA Channel 0 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH0_WRITE_ADDR, 0x0004 DMA Channel 0 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH0_TRANS_COUNT, 0x0008 DMA Channel 0 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH0_CTRL_TRIG, 0x000c DMA Channel 0 Control and Status
       @ .equ CH0_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH0_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH0_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH0_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH0_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH0_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH0_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH0_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH0_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 0. 
       @ .equ CH0_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH0_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH0_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH0_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH0_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH0_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH0_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH0_AL1_CTRL, 0x0010 Alias for channel 0 CTRL register
 
    .equ DMA_CH0_AL1_READ_ADDR, 0x0014 Alias for channel 0 READ_ADDR register
 
    .equ DMA_CH0_AL1_WRITE_ADDR, 0x0018 Alias for channel 0 WRITE_ADDR register
 
    .equ DMA_CH0_AL1_TRANS_COUNT_TRIG, 0x001c Alias for channel 0 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH0_AL2_CTRL, 0x0020 Alias for channel 0 CTRL register
 
    .equ DMA_CH0_AL2_TRANS_COUNT, 0x0024 Alias for channel 0 TRANS_COUNT register
 
    .equ DMA_CH0_AL2_READ_ADDR, 0x0028 Alias for channel 0 READ_ADDR register
 
    .equ DMA_CH0_AL2_WRITE_ADDR_TRIG, 0x002c Alias for channel 0 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH0_AL3_CTRL, 0x0030 Alias for channel 0 CTRL register
 
    .equ DMA_CH0_AL3_WRITE_ADDR, 0x0034 Alias for channel 0 WRITE_ADDR register
 
    .equ DMA_CH0_AL3_TRANS_COUNT, 0x0038 Alias for channel 0 TRANS_COUNT register
 
    .equ DMA_CH0_AL3_READ_ADDR_TRIG, 0x003c Alias for channel 0 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH1_READ_ADDR, 0x0040 DMA Channel 1 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH1_WRITE_ADDR, 0x0044 DMA Channel 1 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH1_TRANS_COUNT, 0x0048 DMA Channel 1 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH1_CTRL_TRIG, 0x004c DMA Channel 1 Control and Status
       @ .equ CH1_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH1_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH1_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH1_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH1_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH1_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH1_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH1_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH1_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 1. 
       @ .equ CH1_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH1_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH1_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH1_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH1_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH1_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH1_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH1_AL1_CTRL, 0x0050 Alias for channel 1 CTRL register
 
    .equ DMA_CH1_AL1_READ_ADDR, 0x0054 Alias for channel 1 READ_ADDR register
 
    .equ DMA_CH1_AL1_WRITE_ADDR, 0x0058 Alias for channel 1 WRITE_ADDR register
 
    .equ DMA_CH1_AL1_TRANS_COUNT_TRIG, 0x005c Alias for channel 1 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH1_AL2_CTRL, 0x0060 Alias for channel 1 CTRL register
 
    .equ DMA_CH1_AL2_TRANS_COUNT, 0x0064 Alias for channel 1 TRANS_COUNT register
 
    .equ DMA_CH1_AL2_READ_ADDR, 0x0068 Alias for channel 1 READ_ADDR register
 
    .equ DMA_CH1_AL2_WRITE_ADDR_TRIG, 0x006c Alias for channel 1 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH1_AL3_CTRL, 0x0070 Alias for channel 1 CTRL register
 
    .equ DMA_CH1_AL3_WRITE_ADDR, 0x0074 Alias for channel 1 WRITE_ADDR register
 
    .equ DMA_CH1_AL3_TRANS_COUNT, 0x0078 Alias for channel 1 TRANS_COUNT register
 
    .equ DMA_CH1_AL3_READ_ADDR_TRIG, 0x007c Alias for channel 1 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH2_READ_ADDR, 0x0080 DMA Channel 2 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH2_WRITE_ADDR, 0x0084 DMA Channel 2 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH2_TRANS_COUNT, 0x0088 DMA Channel 2 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH2_CTRL_TRIG, 0x008c DMA Channel 2 Control and Status
       @ .equ CH2_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH2_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH2_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH2_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH2_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH2_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH2_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH2_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH2_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 2. 
       @ .equ CH2_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH2_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH2_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH2_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH2_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH2_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH2_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH2_AL1_CTRL, 0x0090 Alias for channel 2 CTRL register
 
    .equ DMA_CH2_AL1_READ_ADDR, 0x0094 Alias for channel 2 READ_ADDR register
 
    .equ DMA_CH2_AL1_WRITE_ADDR, 0x0098 Alias for channel 2 WRITE_ADDR register
 
    .equ DMA_CH2_AL1_TRANS_COUNT_TRIG, 0x009c Alias for channel 2 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH2_AL2_CTRL, 0x00a0 Alias for channel 2 CTRL register
 
    .equ DMA_CH2_AL2_TRANS_COUNT, 0x00a4 Alias for channel 2 TRANS_COUNT register
 
    .equ DMA_CH2_AL2_READ_ADDR, 0x00a8 Alias for channel 2 READ_ADDR register
 
    .equ DMA_CH2_AL2_WRITE_ADDR_TRIG, 0x00ac Alias for channel 2 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH2_AL3_CTRL, 0x00b0 Alias for channel 2 CTRL register
 
    .equ DMA_CH2_AL3_WRITE_ADDR, 0x00b4 Alias for channel 2 WRITE_ADDR register
 
    .equ DMA_CH2_AL3_TRANS_COUNT, 0x00b8 Alias for channel 2 TRANS_COUNT register
 
    .equ DMA_CH2_AL3_READ_ADDR_TRIG, 0x00bc Alias for channel 2 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH3_READ_ADDR, 0x00c0 DMA Channel 3 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH3_WRITE_ADDR, 0x00c4 DMA Channel 3 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH3_TRANS_COUNT, 0x00c8 DMA Channel 3 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH3_CTRL_TRIG, 0x00cc DMA Channel 3 Control and Status
       @ .equ CH3_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH3_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH3_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH3_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH3_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH3_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH3_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH3_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH3_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 3. 
       @ .equ CH3_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH3_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH3_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH3_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH3_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH3_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH3_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH3_AL1_CTRL, 0x00d0 Alias for channel 3 CTRL register
 
    .equ DMA_CH3_AL1_READ_ADDR, 0x00d4 Alias for channel 3 READ_ADDR register
 
    .equ DMA_CH3_AL1_WRITE_ADDR, 0x00d8 Alias for channel 3 WRITE_ADDR register
 
    .equ DMA_CH3_AL1_TRANS_COUNT_TRIG, 0x00dc Alias for channel 3 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH3_AL2_CTRL, 0x00e0 Alias for channel 3 CTRL register
 
    .equ DMA_CH3_AL2_TRANS_COUNT, 0x00e4 Alias for channel 3 TRANS_COUNT register
 
    .equ DMA_CH3_AL2_READ_ADDR, 0x00e8 Alias for channel 3 READ_ADDR register
 
    .equ DMA_CH3_AL2_WRITE_ADDR_TRIG, 0x00ec Alias for channel 3 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH3_AL3_CTRL, 0x00f0 Alias for channel 3 CTRL register
 
    .equ DMA_CH3_AL3_WRITE_ADDR, 0x00f4 Alias for channel 3 WRITE_ADDR register
 
    .equ DMA_CH3_AL3_TRANS_COUNT, 0x00f8 Alias for channel 3 TRANS_COUNT register
 
    .equ DMA_CH3_AL3_READ_ADDR_TRIG, 0x00fc Alias for channel 3 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH4_READ_ADDR, 0x0100 DMA Channel 4 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH4_WRITE_ADDR, 0x0104 DMA Channel 4 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH4_TRANS_COUNT, 0x0108 DMA Channel 4 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH4_CTRL_TRIG, 0x010c DMA Channel 4 Control and Status
       @ .equ CH4_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH4_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH4_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH4_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH4_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH4_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH4_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH4_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH4_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 4. 
       @ .equ CH4_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH4_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH4_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH4_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH4_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH4_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH4_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH4_AL1_CTRL, 0x0110 Alias for channel 4 CTRL register
 
    .equ DMA_CH4_AL1_READ_ADDR, 0x0114 Alias for channel 4 READ_ADDR register
 
    .equ DMA_CH4_AL1_WRITE_ADDR, 0x0118 Alias for channel 4 WRITE_ADDR register
 
    .equ DMA_CH4_AL1_TRANS_COUNT_TRIG, 0x011c Alias for channel 4 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH4_AL2_CTRL, 0x0120 Alias for channel 4 CTRL register
 
    .equ DMA_CH4_AL2_TRANS_COUNT, 0x0124 Alias for channel 4 TRANS_COUNT register
 
    .equ DMA_CH4_AL2_READ_ADDR, 0x0128 Alias for channel 4 READ_ADDR register
 
    .equ DMA_CH4_AL2_WRITE_ADDR_TRIG, 0x012c Alias for channel 4 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH4_AL3_CTRL, 0x0130 Alias for channel 4 CTRL register
 
    .equ DMA_CH4_AL3_WRITE_ADDR, 0x0134 Alias for channel 4 WRITE_ADDR register
 
    .equ DMA_CH4_AL3_TRANS_COUNT, 0x0138 Alias for channel 4 TRANS_COUNT register
 
    .equ DMA_CH4_AL3_READ_ADDR_TRIG, 0x013c Alias for channel 4 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH5_READ_ADDR, 0x0140 DMA Channel 5 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH5_WRITE_ADDR, 0x0144 DMA Channel 5 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH5_TRANS_COUNT, 0x0148 DMA Channel 5 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH5_CTRL_TRIG, 0x014c DMA Channel 5 Control and Status
       @ .equ CH5_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH5_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH5_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH5_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH5_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH5_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH5_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH5_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH5_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 5. 
       @ .equ CH5_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH5_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH5_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH5_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH5_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH5_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH5_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH5_AL1_CTRL, 0x0150 Alias for channel 5 CTRL register
 
    .equ DMA_CH5_AL1_READ_ADDR, 0x0154 Alias for channel 5 READ_ADDR register
 
    .equ DMA_CH5_AL1_WRITE_ADDR, 0x0158 Alias for channel 5 WRITE_ADDR register
 
    .equ DMA_CH5_AL1_TRANS_COUNT_TRIG, 0x015c Alias for channel 5 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH5_AL2_CTRL, 0x0160 Alias for channel 5 CTRL register
 
    .equ DMA_CH5_AL2_TRANS_COUNT, 0x0164 Alias for channel 5 TRANS_COUNT register
 
    .equ DMA_CH5_AL2_READ_ADDR, 0x0168 Alias for channel 5 READ_ADDR register
 
    .equ DMA_CH5_AL2_WRITE_ADDR_TRIG, 0x016c Alias for channel 5 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH5_AL3_CTRL, 0x0170 Alias for channel 5 CTRL register
 
    .equ DMA_CH5_AL3_WRITE_ADDR, 0x0174 Alias for channel 5 WRITE_ADDR register
 
    .equ DMA_CH5_AL3_TRANS_COUNT, 0x0178 Alias for channel 5 TRANS_COUNT register
 
    .equ DMA_CH5_AL3_READ_ADDR_TRIG, 0x017c Alias for channel 5 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH6_READ_ADDR, 0x0180 DMA Channel 6 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH6_WRITE_ADDR, 0x0184 DMA Channel 6 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH6_TRANS_COUNT, 0x0188 DMA Channel 6 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH6_CTRL_TRIG, 0x018c DMA Channel 6 Control and Status
       @ .equ CH6_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH6_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH6_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH6_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH6_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH6_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH6_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH6_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH6_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 6. 
       @ .equ CH6_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH6_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH6_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH6_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH6_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH6_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH6_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH6_AL1_CTRL, 0x0190 Alias for channel 6 CTRL register
 
    .equ DMA_CH6_AL1_READ_ADDR, 0x0194 Alias for channel 6 READ_ADDR register
 
    .equ DMA_CH6_AL1_WRITE_ADDR, 0x0198 Alias for channel 6 WRITE_ADDR register
 
    .equ DMA_CH6_AL1_TRANS_COUNT_TRIG, 0x019c Alias for channel 6 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH6_AL2_CTRL, 0x01a0 Alias for channel 6 CTRL register
 
    .equ DMA_CH6_AL2_TRANS_COUNT, 0x01a4 Alias for channel 6 TRANS_COUNT register
 
    .equ DMA_CH6_AL2_READ_ADDR, 0x01a8 Alias for channel 6 READ_ADDR register
 
    .equ DMA_CH6_AL2_WRITE_ADDR_TRIG, 0x01ac Alias for channel 6 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH6_AL3_CTRL, 0x01b0 Alias for channel 6 CTRL register
 
    .equ DMA_CH6_AL3_WRITE_ADDR, 0x01b4 Alias for channel 6 WRITE_ADDR register
 
    .equ DMA_CH6_AL3_TRANS_COUNT, 0x01b8 Alias for channel 6 TRANS_COUNT register
 
    .equ DMA_CH6_AL3_READ_ADDR_TRIG, 0x01bc Alias for channel 6 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH7_READ_ADDR, 0x01c0 DMA Channel 7 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH7_WRITE_ADDR, 0x01c4 DMA Channel 7 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH7_TRANS_COUNT, 0x01c8 DMA Channel 7 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH7_CTRL_TRIG, 0x01cc DMA Channel 7 Control and Status
       @ .equ CH7_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH7_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH7_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH7_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH7_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH7_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH7_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH7_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH7_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 7. 
       @ .equ CH7_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH7_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH7_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH7_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH7_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH7_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH7_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH7_AL1_CTRL, 0x01d0 Alias for channel 7 CTRL register
 
    .equ DMA_CH7_AL1_READ_ADDR, 0x01d4 Alias for channel 7 READ_ADDR register
 
    .equ DMA_CH7_AL1_WRITE_ADDR, 0x01d8 Alias for channel 7 WRITE_ADDR register
 
    .equ DMA_CH7_AL1_TRANS_COUNT_TRIG, 0x01dc Alias for channel 7 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH7_AL2_CTRL, 0x01e0 Alias for channel 7 CTRL register
 
    .equ DMA_CH7_AL2_TRANS_COUNT, 0x01e4 Alias for channel 7 TRANS_COUNT register
 
    .equ DMA_CH7_AL2_READ_ADDR, 0x01e8 Alias for channel 7 READ_ADDR register
 
    .equ DMA_CH7_AL2_WRITE_ADDR_TRIG, 0x01ec Alias for channel 7 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH7_AL3_CTRL, 0x01f0 Alias for channel 7 CTRL register
 
    .equ DMA_CH7_AL3_WRITE_ADDR, 0x01f4 Alias for channel 7 WRITE_ADDR register
 
    .equ DMA_CH7_AL3_TRANS_COUNT, 0x01f8 Alias for channel 7 TRANS_COUNT register
 
    .equ DMA_CH7_AL3_READ_ADDR_TRIG, 0x01fc Alias for channel 7 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH8_READ_ADDR, 0x0200 DMA Channel 8 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH8_WRITE_ADDR, 0x0204 DMA Channel 8 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH8_TRANS_COUNT, 0x0208 DMA Channel 8 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH8_CTRL_TRIG, 0x020c DMA Channel 8 Control and Status
       @ .equ CH8_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH8_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH8_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH8_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH8_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH8_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH8_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH8_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH8_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 8. 
       @ .equ CH8_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH8_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH8_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH8_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH8_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH8_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH8_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH8_AL1_CTRL, 0x0210 Alias for channel 8 CTRL register
 
    .equ DMA_CH8_AL1_READ_ADDR, 0x0214 Alias for channel 8 READ_ADDR register
 
    .equ DMA_CH8_AL1_WRITE_ADDR, 0x0218 Alias for channel 8 WRITE_ADDR register
 
    .equ DMA_CH8_AL1_TRANS_COUNT_TRIG, 0x021c Alias for channel 8 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH8_AL2_CTRL, 0x0220 Alias for channel 8 CTRL register
 
    .equ DMA_CH8_AL2_TRANS_COUNT, 0x0224 Alias for channel 8 TRANS_COUNT register
 
    .equ DMA_CH8_AL2_READ_ADDR, 0x0228 Alias for channel 8 READ_ADDR register
 
    .equ DMA_CH8_AL2_WRITE_ADDR_TRIG, 0x022c Alias for channel 8 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH8_AL3_CTRL, 0x0230 Alias for channel 8 CTRL register
 
    .equ DMA_CH8_AL3_WRITE_ADDR, 0x0234 Alias for channel 8 WRITE_ADDR register
 
    .equ DMA_CH8_AL3_TRANS_COUNT, 0x0238 Alias for channel 8 TRANS_COUNT register
 
    .equ DMA_CH8_AL3_READ_ADDR_TRIG, 0x023c Alias for channel 8 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH9_READ_ADDR, 0x0240 DMA Channel 9 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH9_WRITE_ADDR, 0x0244 DMA Channel 9 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH9_TRANS_COUNT, 0x0248 DMA Channel 9 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH9_CTRL_TRIG, 0x024c DMA Channel 9 Control and Status
       @ .equ CH9_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH9_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH9_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH9_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH9_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH9_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH9_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH9_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH9_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 9. 
       @ .equ CH9_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH9_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH9_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH9_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH9_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH9_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH9_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH9_AL1_CTRL, 0x0250 Alias for channel 9 CTRL register
 
    .equ DMA_CH9_AL1_READ_ADDR, 0x0254 Alias for channel 9 READ_ADDR register
 
    .equ DMA_CH9_AL1_WRITE_ADDR, 0x0258 Alias for channel 9 WRITE_ADDR register
 
    .equ DMA_CH9_AL1_TRANS_COUNT_TRIG, 0x025c Alias for channel 9 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH9_AL2_CTRL, 0x0260 Alias for channel 9 CTRL register
 
    .equ DMA_CH9_AL2_TRANS_COUNT, 0x0264 Alias for channel 9 TRANS_COUNT register
 
    .equ DMA_CH9_AL2_READ_ADDR, 0x0268 Alias for channel 9 READ_ADDR register
 
    .equ DMA_CH9_AL2_WRITE_ADDR_TRIG, 0x026c Alias for channel 9 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH9_AL3_CTRL, 0x0270 Alias for channel 9 CTRL register
 
    .equ DMA_CH9_AL3_WRITE_ADDR, 0x0274 Alias for channel 9 WRITE_ADDR register
 
    .equ DMA_CH9_AL3_TRANS_COUNT, 0x0278 Alias for channel 9 TRANS_COUNT register
 
    .equ DMA_CH9_AL3_READ_ADDR_TRIG, 0x027c Alias for channel 9 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH10_READ_ADDR, 0x0280 DMA Channel 10 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH10_WRITE_ADDR, 0x0284 DMA Channel 10 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH10_TRANS_COUNT, 0x0288 DMA Channel 10 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH10_CTRL_TRIG, 0x028c DMA Channel 10 Control and Status
       @ .equ CH10_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH10_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH10_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH10_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH10_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH10_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH10_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH10_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH10_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 10. 
       @ .equ CH10_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH10_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH10_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH10_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH10_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH10_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH10_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH10_AL1_CTRL, 0x0290 Alias for channel 10 CTRL register
 
    .equ DMA_CH10_AL1_READ_ADDR, 0x0294 Alias for channel 10 READ_ADDR register
 
    .equ DMA_CH10_AL1_WRITE_ADDR, 0x0298 Alias for channel 10 WRITE_ADDR register
 
    .equ DMA_CH10_AL1_TRANS_COUNT_TRIG, 0x029c Alias for channel 10 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH10_AL2_CTRL, 0x02a0 Alias for channel 10 CTRL register
 
    .equ DMA_CH10_AL2_TRANS_COUNT, 0x02a4 Alias for channel 10 TRANS_COUNT register
 
    .equ DMA_CH10_AL2_READ_ADDR, 0x02a8 Alias for channel 10 READ_ADDR register
 
    .equ DMA_CH10_AL2_WRITE_ADDR_TRIG, 0x02ac Alias for channel 10 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH10_AL3_CTRL, 0x02b0 Alias for channel 10 CTRL register
 
    .equ DMA_CH10_AL3_WRITE_ADDR, 0x02b4 Alias for channel 10 WRITE_ADDR register
 
    .equ DMA_CH10_AL3_TRANS_COUNT, 0x02b8 Alias for channel 10 TRANS_COUNT register
 
    .equ DMA_CH10_AL3_READ_ADDR_TRIG, 0x02bc Alias for channel 10 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH11_READ_ADDR, 0x02c0 DMA Channel 11 Read Address pointer  This register updates automatically each time a read completes. The current value is the next address to be read by this channel.
 
    .equ DMA_CH11_WRITE_ADDR, 0x02c4 DMA Channel 11 Write Address pointer  This register updates automatically each time a write completes. The current value is the next address to be written by this channel.
 
    .equ DMA_CH11_TRANS_COUNT, 0x02c8 DMA Channel 11 Transfer Count  Program the number of bus transfers a channel will perform before halting. Note that, if transfers are larger than one byte in size, this is not equal to the number of bytes transferred see CTRL_DATA_SIZE.  When the channel is active, reading this register shows the number of transfers remaining, updating automatically each time a write transfer completes.  Writing this register sets the RELOAD value for the transfer counter. Each time this channel is triggered, the RELOAD value is copied into the live transfer counter. The channel can be started multiple times, and will perform the same number of transfers each time, as programmed by most recent write.  The RELOAD value can be observed at CHx_DBG_TCR. If TRANS_COUNT is used as a trigger, the written value is used immediately as the length of the new transfer sequence, as well as being written to RELOAD.
 
    .equ DMA_CH11_CTRL_TRIG, 0x02cc DMA Channel 11 Control and Status
       @ .equ CH11_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ CH11_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ CH11_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ CH11_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ CH11_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ CH11_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ CH11_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ CH11_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ CH11_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.  Reset value is equal to channel number 11. 
       @ .equ CH11_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ CH11_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ CH11_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ CH11_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ CH11_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ CH11_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ CH11_CTRL_TRIG_EN [0:0]    DMA Channel Enable.  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH11_AL1_CTRL, 0x02d0 Alias for channel 11 CTRL register
 
    .equ DMA_CH11_AL1_READ_ADDR, 0x02d4 Alias for channel 11 READ_ADDR register
 
    .equ DMA_CH11_AL1_WRITE_ADDR, 0x02d8 Alias for channel 11 WRITE_ADDR register
 
    .equ DMA_CH11_AL1_TRANS_COUNT_TRIG, 0x02dc Alias for channel 11 TRANS_COUNT register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH11_AL2_CTRL, 0x02e0 Alias for channel 11 CTRL register
 
    .equ DMA_CH11_AL2_TRANS_COUNT, 0x02e4 Alias for channel 11 TRANS_COUNT register
 
    .equ DMA_CH11_AL2_READ_ADDR, 0x02e8 Alias for channel 11 READ_ADDR register
 
    .equ DMA_CH11_AL2_WRITE_ADDR_TRIG, 0x02ec Alias for channel 11 WRITE_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_CH11_AL3_CTRL, 0x02f0 Alias for channel 11 CTRL register
 
    .equ DMA_CH11_AL3_WRITE_ADDR, 0x02f4 Alias for channel 11 WRITE_ADDR register
 
    .equ DMA_CH11_AL3_TRANS_COUNT, 0x02f8 Alias for channel 11 TRANS_COUNT register
 
    .equ DMA_CH11_AL3_READ_ADDR_TRIG, 0x02fc Alias for channel 11 READ_ADDR register  This is a trigger register 0xc. Writing a nonzero value will  reload the channel counter and start the channel.
 
    .equ DMA_INTR, 0x0400 Interrupt Status raw
       @ .equ INTR_INTR [15:0]    Raw interrupt status for DMA Channels 0..15. Bit n corresponds to channel n. Ignores any masking or forcing. Channel interrupts can be cleared by writing a bit mask to INTR, INTS0 or INTS1.  Channel interrupts can be routed to either of two system-level IRQs based on INTE0 and INTE1.  This can be used vector different channel interrupts to different ISRs: this might be done to allow NVIC IRQ preemption for more time-critical channels, or to spread IRQ load across different cores.  It is also valid to ignore this behaviour and just use INTE0/INTS0/IRQ 0. 
 
    .equ DMA_INTE0, 0x0404 Interrupt Enables for IRQ 0
       @ .equ INTE0_INTE0 [15:0]    Set bit n to pass interrupts from channel n to DMA IRQ 0. 
 
    .equ DMA_INTF0, 0x0408 Force Interrupts
       @ .equ INTF0_INTF0 [15:0]    Write 1s to force the corresponding bits in INTE0. The interrupt remains asserted until INTF0 is cleared. 
 
    .equ DMA_INTS0, 0x040c Interrupt Status for IRQ 0
       @ .equ INTS0_INTS0 [15:0]    Indicates active channel interrupt requests which are currently causing IRQ 0 to be asserted.  Channel interrupts can be cleared by writing a bit mask here. 
 
    .equ DMA_INTE1, 0x0414 Interrupt Enables for IRQ 1
       @ .equ INTE1_INTE1 [15:0]    Set bit n to pass interrupts from channel n to DMA IRQ 1. 
 
    .equ DMA_INTF1, 0x0418 Force Interrupts for IRQ 1
       @ .equ INTF1_INTF1 [15:0]    Write 1s to force the corresponding bits in INTE0. The interrupt remains asserted until INTF0 is cleared. 
 
    .equ DMA_INTS1, 0x041c Interrupt Status masked for IRQ 1
       @ .equ INTS1_INTS1 [15:0]    Indicates active channel interrupt requests which are currently causing IRQ 1 to be asserted.  Channel interrupts can be cleared by writing a bit mask here. 
 
    .equ DMA_TIMER0, 0x0420 Pacing X/Y Fractional Timer  The pacing timer produces TREQ assertions at a rate set by X/Y * sys_clk. This equation is evaluated every sys_clk cycles and therefore can only generate TREQs at a rate of 1 per sys_clk i.e. permanent TREQ or less.
       @ .equ TIMER0_X [31:16]    Pacing Timer Dividend. Specifies the X value for the X/Y fractional timer. 
       @ .equ TIMER0_Y [15:0]    Pacing Timer Divisor. Specifies the Y value for the X/Y fractional timer. 
 
    .equ DMA_TIMER1, 0x0424 Pacing X/Y Fractional Timer  The pacing timer produces TREQ assertions at a rate set by X/Y * sys_clk. This equation is evaluated every sys_clk cycles and therefore can only generate TREQs at a rate of 1 per sys_clk i.e. permanent TREQ or less.
       @ .equ TIMER1_X [31:16]    Pacing Timer Dividend. Specifies the X value for the X/Y fractional timer. 
       @ .equ TIMER1_Y [15:0]    Pacing Timer Divisor. Specifies the Y value for the X/Y fractional timer. 
 
    .equ DMA_MULTI_CHAN_TRIGGER, 0x0430 Trigger one or more channels simultaneously
       @ .equ MULTI_CHAN_TRIGGER_MULTI_CHAN_TRIGGER [15:0]    Each bit in this register corresponds to a DMA channel. Writing a 1 to the relevant bit is the same as writing to that channel's trigger register; the channel will start if it is currently enabled and not already busy. 
 
    .equ DMA_SNIFF_CTRL, 0x0434 Sniffer Control
       @ .equ SNIFF_CTRL_OUT_INV [11:11]    If set, the result appears inverted bitwise complement when read. This does not affect the way the checksum is calculated; the result is transformed on-the-fly between the result register and the bus. 
       @ .equ SNIFF_CTRL_OUT_REV [10:10]    If set, the result appears bit-reversed when read. This does not affect the way the checksum is calculated; the result is transformed on-the-fly between the result register and the bus. 
       @ .equ SNIFF_CTRL_BSWAP [9:9]    Locally perform a byte reverse on the sniffed data, before feeding into checksum.  Note that the sniff hardware is downstream of the DMA channel byteswap performed in the read master: if channel CTRL_BSWAP and SNIFF_CTRL_BSWAP are both enabled, their effects cancel from the sniffer's point of view. 
       @ .equ SNIFF_CTRL_CALC [8:5]     
       @ .equ SNIFF_CTRL_DMACH [4:1]    DMA channel for Sniffer to observe 
       @ .equ SNIFF_CTRL_EN [0:0]    Enable sniffer 
 
    .equ DMA_SNIFF_DATA, 0x0438 Data accumulator for sniff hardware  Write an initial seed value here before starting a DMA transfer on the channel indicated by SNIFF_CTRL_DMACH. The hardware will update this register each time it observes a read from the indicated channel. Once the channel completes, the final result can be read from this register.
 
    .equ DMA_FIFO_LEVELS, 0x0440 Debug RAF, WAF, TDF levels
       @ .equ FIFO_LEVELS_RAF_LVL [23:16]    Current Read-Address-FIFO fill level 
       @ .equ FIFO_LEVELS_WAF_LVL [15:8]    Current Write-Address-FIFO fill level 
       @ .equ FIFO_LEVELS_TDF_LVL [7:0]    Current Transfer-Data-FIFO fill level 
 
    .equ DMA_CHAN_ABORT, 0x0444 Abort an in-progress transfer sequence on one or more channels
       @ .equ CHAN_ABORT_CHAN_ABORT [15:0]    Each bit corresponds to a channel. Writing a 1 aborts whatever transfer sequence is in progress on that channel. The bit will remain high until any in-flight transfers have been flushed through the address and data FIFOs.  After writing, this register must be polled until it returns all-zero. Until this point, it is unsafe to restart the channel. 
 
    .equ DMA_N_CHANNELS, 0x0448 The number of channels this DMA instance is equipped with. This DMA supports up to 16 hardware channels, but can be configured with as few as one, to minimise silicon area.
       @ .equ N_CHANNELS_N_CHANNELS [4:0]     
 
    .equ DMA_CH0_DBG_CTDREQ, 0x0800 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH0_DBG_CTDREQ_CH0_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH0_DBG_TCR, 0x0804 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH1_DBG_CTDREQ, 0x0840 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH1_DBG_CTDREQ_CH1_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH1_DBG_TCR, 0x0844 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH2_DBG_CTDREQ, 0x0880 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH2_DBG_CTDREQ_CH2_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH2_DBG_TCR, 0x0884 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH3_DBG_CTDREQ, 0x08c0 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH3_DBG_CTDREQ_CH3_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH3_DBG_TCR, 0x08c4 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH4_DBG_CTDREQ, 0x0900 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH4_DBG_CTDREQ_CH4_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH4_DBG_TCR, 0x0904 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH5_DBG_CTDREQ, 0x0940 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH5_DBG_CTDREQ_CH5_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH5_DBG_TCR, 0x0944 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH6_DBG_CTDREQ, 0x0980 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH6_DBG_CTDREQ_CH6_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH6_DBG_TCR, 0x0984 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH7_DBG_CTDREQ, 0x09c0 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH7_DBG_CTDREQ_CH7_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH7_DBG_TCR, 0x09c4 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH8_DBG_CTDREQ, 0x0a00 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH8_DBG_CTDREQ_CH8_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH8_DBG_TCR, 0x0a04 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH9_DBG_CTDREQ, 0x0a40 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH9_DBG_CTDREQ_CH9_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH9_DBG_TCR, 0x0a44 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH10_DBG_CTDREQ, 0x0a80 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH10_DBG_CTDREQ_CH10_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH10_DBG_TCR, 0x0a84 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 
    .equ DMA_CH11_DBG_CTDREQ, 0x0ac0 Read: get channel DREQ counter i.e. how many accesses the DMA expects it can perform on the peripheral without overflow/underflow. Write any value: clears the counter, and cause channel to re-initiate DREQ handshake.
       @ .equ CH11_DBG_CTDREQ_CH11_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH11_DBG_TCR, 0x0ac4 Read to get channel TRANS_COUNT reload value, i.e. the length of the next transfer
 

@=========================== USBCTRL_REGS ===========================@
.equ USBCTRL_REGS_BASE, 0x50110000 USB FS/LS controller device registers
    .equ USBCTRL_REGS_ADDR_ENDP, 0x0000 Device address and endpoint control
       @ .equ ADDR_ENDP_ENDPOINT [19:16]    Device endpoint to send data to. Only valid for HOST mode. 
       @ .equ ADDR_ENDP_ADDRESS [6:0]    In device mode, the address that the device should respond to. Set in response to a SET_ADDR setup packet from the host. In host mode set to the address of the device to communicate with. 
 
    .equ USBCTRL_REGS_ADDR_ENDP1, 0x0004 Interrupt endpoint 1. Only valid for HOST mode.
       @ .equ ADDR_ENDP1_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP1_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP1_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP1_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP2, 0x0008 Interrupt endpoint 2. Only valid for HOST mode.
       @ .equ ADDR_ENDP2_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP2_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP2_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP2_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP3, 0x000c Interrupt endpoint 3. Only valid for HOST mode.
       @ .equ ADDR_ENDP3_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP3_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP3_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP3_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP4, 0x0010 Interrupt endpoint 4. Only valid for HOST mode.
       @ .equ ADDR_ENDP4_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP4_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP4_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP4_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP5, 0x0014 Interrupt endpoint 5. Only valid for HOST mode.
       @ .equ ADDR_ENDP5_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP5_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP5_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP5_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP6, 0x0018 Interrupt endpoint 6. Only valid for HOST mode.
       @ .equ ADDR_ENDP6_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP6_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP6_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP6_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP7, 0x001c Interrupt endpoint 7. Only valid for HOST mode.
       @ .equ ADDR_ENDP7_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP7_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP7_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP7_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP8, 0x0020 Interrupt endpoint 8. Only valid for HOST mode.
       @ .equ ADDR_ENDP8_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP8_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP8_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP8_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP9, 0x0024 Interrupt endpoint 9. Only valid for HOST mode.
       @ .equ ADDR_ENDP9_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP9_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP9_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP9_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP10, 0x0028 Interrupt endpoint 10. Only valid for HOST mode.
       @ .equ ADDR_ENDP10_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP10_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP10_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP10_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP11, 0x002c Interrupt endpoint 11. Only valid for HOST mode.
       @ .equ ADDR_ENDP11_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP11_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP11_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP11_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP12, 0x0030 Interrupt endpoint 12. Only valid for HOST mode.
       @ .equ ADDR_ENDP12_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP12_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP12_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP12_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP13, 0x0034 Interrupt endpoint 13. Only valid for HOST mode.
       @ .equ ADDR_ENDP13_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP13_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP13_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP13_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP14, 0x0038 Interrupt endpoint 14. Only valid for HOST mode.
       @ .equ ADDR_ENDP14_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP14_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP14_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP14_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP15, 0x003c Interrupt endpoint 15. Only valid for HOST mode.
       @ .equ ADDR_ENDP15_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ ADDR_ENDP15_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ ADDR_ENDP15_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ ADDR_ENDP15_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_MAIN_CTRL, 0x0040 Main control register
       @ .equ MAIN_CTRL_SIM_TIMING [31:31]    Reduced timings for simulation 
       @ .equ MAIN_CTRL_HOST_NDEVICE [1:1]    Device mode = 0, Host mode = 1 
       @ .equ MAIN_CTRL_CONTROLLER_EN [0:0]    Enable controller 
 
    .equ USBCTRL_REGS_SOF_WR, 0x0044 Set the SOF Start of Frame frame number in the host controller. The SOF packet is sent every 1ms and the host will increment the frame number by 1 each time.
       @ .equ SOF_WR_COUNT [10:0]     
 
    .equ USBCTRL_REGS_SOF_RD, 0x0048 Read the last SOF Start of Frame frame number seen. In device mode the last SOF received from the host. In host mode the last SOF sent by the host.
       @ .equ SOF_RD_COUNT [10:0]     
 
    .equ USBCTRL_REGS_SIE_CTRL, 0x004c SIE control register
       @ .equ SIE_CTRL_EP0_INT_STALL [31:31]    Device: Set bit in EP_STATUS_STALL_NAK when EP0 sends a STALL 
       @ .equ SIE_CTRL_EP0_DOUBLE_BUF [30:30]    Device: EP0 single buffered = 0, double buffered = 1 
       @ .equ SIE_CTRL_EP0_INT_1BUF [29:29]    Device: Set bit in BUFF_STATUS for every buffer completed on EP0 
       @ .equ SIE_CTRL_EP0_INT_2BUF [28:28]    Device: Set bit in BUFF_STATUS for every 2 buffers completed on EP0 
       @ .equ SIE_CTRL_EP0_INT_NAK [27:27]    Device: Set bit in EP_STATUS_STALL_NAK when EP0 sends a NAK 
       @ .equ SIE_CTRL_DIRECT_EN [26:26]    Direct bus drive enable 
       @ .equ SIE_CTRL_DIRECT_DP [25:25]    Direct control of DP 
       @ .equ SIE_CTRL_DIRECT_DM [24:24]    Direct control of DM 
       @ .equ SIE_CTRL_TRANSCEIVER_PD [18:18]    Power down bus transceiver 
       @ .equ SIE_CTRL_RPU_OPT [17:17]    Device: Pull-up strength 0=1K2, 1=2k3 
       @ .equ SIE_CTRL_PULLUP_EN [16:16]    Device: Enable pull up resistor 
       @ .equ SIE_CTRL_PULLDOWN_EN [15:15]    Host: Enable pull down resistors 
       @ .equ SIE_CTRL_RESET_BUS [13:13]    Host: Reset bus 
       @ .equ SIE_CTRL_RESUME [12:12]    Device: Remote wakeup. Device can initiate its own resume after suspend. 
       @ .equ SIE_CTRL_VBUS_EN [11:11]    Host: Enable VBUS 
       @ .equ SIE_CTRL_KEEP_ALIVE_EN [10:10]    Host: Enable keep alive packet for low speed bus 
       @ .equ SIE_CTRL_SOF_EN [9:9]    Host: Enable SOF generation for full speed bus 
       @ .equ SIE_CTRL_SOF_SYNC [8:8]    Host: Delay packets until after SOF 
       @ .equ SIE_CTRL_PREAMBLE_EN [6:6]    Host: Preable enable for LS device on FS hub 
       @ .equ SIE_CTRL_STOP_TRANS [4:4]    Host: Stop transaction 
       @ .equ SIE_CTRL_RECEIVE_DATA [3:3]    Host: Receive transaction IN to host 
       @ .equ SIE_CTRL_SEND_DATA [2:2]    Host: Send transaction OUT from host 
       @ .equ SIE_CTRL_SEND_SETUP [1:1]    Host: Send Setup packet 
       @ .equ SIE_CTRL_START_TRANS [0:0]    Host: Start transaction 
 
    .equ USBCTRL_REGS_SIE_STATUS, 0x0050 SIE status register
       @ .equ SIE_STATUS_DATA_SEQ_ERROR [31:31]    Data Sequence Error.  The device can raise a sequence error in the following conditions:  * A SETUP packet is received followed by a DATA1 packet data phase should always be DATA0 * An OUT packet is received from the host but doesn't match the data pid in the buffer control register read from DPSRAM  The host can raise a data sequence error in the following conditions:  * An IN packet from the device has the wrong data PID 
       @ .equ SIE_STATUS_ACK_REC [30:30]    ACK received. Raised by both host and device. 
       @ .equ SIE_STATUS_STALL_REC [29:29]    Host: STALL received 
       @ .equ SIE_STATUS_NAK_REC [28:28]    Host: NAK received 
       @ .equ SIE_STATUS_RX_TIMEOUT [27:27]    RX timeout is raised by both the host and device if an ACK is not received in the maximum time specified by the USB spec. 
       @ .equ SIE_STATUS_RX_OVERFLOW [26:26]    RX overflow is raised by the Serial RX engine if the incoming data is too fast. 
       @ .equ SIE_STATUS_BIT_STUFF_ERROR [25:25]    Bit Stuff Error. Raised by the Serial RX engine. 
       @ .equ SIE_STATUS_CRC_ERROR [24:24]    CRC Error. Raised by the Serial RX engine. 
       @ .equ SIE_STATUS_BUS_RESET [19:19]    Device: bus reset received 
       @ .equ SIE_STATUS_TRANS_COMPLETE [18:18]    Transaction complete.  Raised by device if:  * An IN or OUT packet is sent with the `LAST_BUFF` bit set in the buffer control register  Raised by host if:  * A setup packet is sent when no data in or data out transaction follows * An IN packet is received and the `LAST_BUFF` bit is set in the buffer control register * An IN packet is received with zero length * An OUT packet is sent and the `LAST_BUFF` bit is set 
       @ .equ SIE_STATUS_SETUP_REC [17:17]    Device: Setup packet received 
       @ .equ SIE_STATUS_CONNECTED [16:16]    Device: connected 
       @ .equ SIE_STATUS_RESUME [11:11]    Host: Device has initiated a remote resume. Device: host has initiated a resume. 
       @ .equ SIE_STATUS_VBUS_OVER_CURR [10:10]    VBUS over current detected 
       @ .equ SIE_STATUS_SPEED [9:8]    Host: device speed. Disconnected = 00, LS = 01, FS = 10 
       @ .equ SIE_STATUS_SUSPENDED [4:4]    Bus in suspended state. Valid for device and host. Host and device will go into suspend if neither Keep Alive / SOF frames are enabled. 
       @ .equ SIE_STATUS_LINE_STATE [3:2]    USB bus line state 
       @ .equ SIE_STATUS_VBUS_DETECTED [0:0]    Device: VBUS Detected 
 
    .equ USBCTRL_REGS_INT_EP_CTRL, 0x0054 interrupt endpoint control register
       @ .equ INT_EP_CTRL_INT_EP_ACTIVE [15:1]    Host: Enable interrupt endpoint 1 -> 15 
 
    .equ USBCTRL_REGS_BUFF_STATUS, 0x0058 Buffer status register. A bit set here indicates that a buffer has completed on the endpoint if the buffer interrupt is enabled. It is possible for 2 buffers to be completed, so clearing the buffer status bit may instantly re set it on the next clock cycle.
       @ .equ BUFF_STATUS_EP15_OUT [31:31]     
       @ .equ BUFF_STATUS_EP15_IN [30:30]     
       @ .equ BUFF_STATUS_EP14_OUT [29:29]     
       @ .equ BUFF_STATUS_EP14_IN [28:28]     
       @ .equ BUFF_STATUS_EP13_OUT [27:27]     
       @ .equ BUFF_STATUS_EP13_IN [26:26]     
       @ .equ BUFF_STATUS_EP12_OUT [25:25]     
       @ .equ BUFF_STATUS_EP12_IN [24:24]     
       @ .equ BUFF_STATUS_EP11_OUT [23:23]     
       @ .equ BUFF_STATUS_EP11_IN [22:22]     
       @ .equ BUFF_STATUS_EP10_OUT [21:21]     
       @ .equ BUFF_STATUS_EP10_IN [20:20]     
       @ .equ BUFF_STATUS_EP9_OUT [19:19]     
       @ .equ BUFF_STATUS_EP9_IN [18:18]     
       @ .equ BUFF_STATUS_EP8_OUT [17:17]     
       @ .equ BUFF_STATUS_EP8_IN [16:16]     
       @ .equ BUFF_STATUS_EP7_OUT [15:15]     
       @ .equ BUFF_STATUS_EP7_IN [14:14]     
       @ .equ BUFF_STATUS_EP6_OUT [13:13]     
       @ .equ BUFF_STATUS_EP6_IN [12:12]     
       @ .equ BUFF_STATUS_EP5_OUT [11:11]     
       @ .equ BUFF_STATUS_EP5_IN [10:10]     
       @ .equ BUFF_STATUS_EP4_OUT [9:9]     
       @ .equ BUFF_STATUS_EP4_IN [8:8]     
       @ .equ BUFF_STATUS_EP3_OUT [7:7]     
       @ .equ BUFF_STATUS_EP3_IN [6:6]     
       @ .equ BUFF_STATUS_EP2_OUT [5:5]     
       @ .equ BUFF_STATUS_EP2_IN [4:4]     
       @ .equ BUFF_STATUS_EP1_OUT [3:3]     
       @ .equ BUFF_STATUS_EP1_IN [2:2]     
       @ .equ BUFF_STATUS_EP0_OUT [1:1]     
       @ .equ BUFF_STATUS_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE, 0x005c Which of the double buffers should be handled. Only valid if using an interrupt per buffer i.e. not per 2 buffers. Not valid for host interrupt endpoint polling because they are only single buffered.
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP15_OUT [31:31]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP15_IN [30:30]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP14_OUT [29:29]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP14_IN [28:28]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP13_OUT [27:27]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP13_IN [26:26]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP12_OUT [25:25]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP12_IN [24:24]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP11_OUT [23:23]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP11_IN [22:22]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP10_OUT [21:21]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP10_IN [20:20]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP9_OUT [19:19]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP9_IN [18:18]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP8_OUT [17:17]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP8_IN [16:16]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP7_OUT [15:15]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP7_IN [14:14]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP6_OUT [13:13]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP6_IN [12:12]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP5_OUT [11:11]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP5_IN [10:10]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP4_OUT [9:9]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP4_IN [8:8]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP3_OUT [7:7]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP3_IN [6:6]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP2_OUT [5:5]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP2_IN [4:4]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP1_OUT [3:3]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP1_IN [2:2]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP0_OUT [1:1]     
       @ .equ BUFF_CPU_SHOULD_HANDLE_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_EP_ABORT, 0x0060 Device only: Can be set to ignore the buffer control register for this endpoint in case you would like to revoke a buffer. A NAK will be sent for every access to the endpoint until this bit is cleared. A corresponding bit in `EP_ABORT_DONE` is set when it is safe to modify the buffer control register.
       @ .equ EP_ABORT_EP15_OUT [31:31]     
       @ .equ EP_ABORT_EP15_IN [30:30]     
       @ .equ EP_ABORT_EP14_OUT [29:29]     
       @ .equ EP_ABORT_EP14_IN [28:28]     
       @ .equ EP_ABORT_EP13_OUT [27:27]     
       @ .equ EP_ABORT_EP13_IN [26:26]     
       @ .equ EP_ABORT_EP12_OUT [25:25]     
       @ .equ EP_ABORT_EP12_IN [24:24]     
       @ .equ EP_ABORT_EP11_OUT [23:23]     
       @ .equ EP_ABORT_EP11_IN [22:22]     
       @ .equ EP_ABORT_EP10_OUT [21:21]     
       @ .equ EP_ABORT_EP10_IN [20:20]     
       @ .equ EP_ABORT_EP9_OUT [19:19]     
       @ .equ EP_ABORT_EP9_IN [18:18]     
       @ .equ EP_ABORT_EP8_OUT [17:17]     
       @ .equ EP_ABORT_EP8_IN [16:16]     
       @ .equ EP_ABORT_EP7_OUT [15:15]     
       @ .equ EP_ABORT_EP7_IN [14:14]     
       @ .equ EP_ABORT_EP6_OUT [13:13]     
       @ .equ EP_ABORT_EP6_IN [12:12]     
       @ .equ EP_ABORT_EP5_OUT [11:11]     
       @ .equ EP_ABORT_EP5_IN [10:10]     
       @ .equ EP_ABORT_EP4_OUT [9:9]     
       @ .equ EP_ABORT_EP4_IN [8:8]     
       @ .equ EP_ABORT_EP3_OUT [7:7]     
       @ .equ EP_ABORT_EP3_IN [6:6]     
       @ .equ EP_ABORT_EP2_OUT [5:5]     
       @ .equ EP_ABORT_EP2_IN [4:4]     
       @ .equ EP_ABORT_EP1_OUT [3:3]     
       @ .equ EP_ABORT_EP1_IN [2:2]     
       @ .equ EP_ABORT_EP0_OUT [1:1]     
       @ .equ EP_ABORT_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_EP_ABORT_DONE, 0x0064 Device only: Used in conjunction with `EP_ABORT`. Set once an endpoint is idle so the programmer knows it is safe to modify the buffer control register.
       @ .equ EP_ABORT_DONE_EP15_OUT [31:31]     
       @ .equ EP_ABORT_DONE_EP15_IN [30:30]     
       @ .equ EP_ABORT_DONE_EP14_OUT [29:29]     
       @ .equ EP_ABORT_DONE_EP14_IN [28:28]     
       @ .equ EP_ABORT_DONE_EP13_OUT [27:27]     
       @ .equ EP_ABORT_DONE_EP13_IN [26:26]     
       @ .equ EP_ABORT_DONE_EP12_OUT [25:25]     
       @ .equ EP_ABORT_DONE_EP12_IN [24:24]     
       @ .equ EP_ABORT_DONE_EP11_OUT [23:23]     
       @ .equ EP_ABORT_DONE_EP11_IN [22:22]     
       @ .equ EP_ABORT_DONE_EP10_OUT [21:21]     
       @ .equ EP_ABORT_DONE_EP10_IN [20:20]     
       @ .equ EP_ABORT_DONE_EP9_OUT [19:19]     
       @ .equ EP_ABORT_DONE_EP9_IN [18:18]     
       @ .equ EP_ABORT_DONE_EP8_OUT [17:17]     
       @ .equ EP_ABORT_DONE_EP8_IN [16:16]     
       @ .equ EP_ABORT_DONE_EP7_OUT [15:15]     
       @ .equ EP_ABORT_DONE_EP7_IN [14:14]     
       @ .equ EP_ABORT_DONE_EP6_OUT [13:13]     
       @ .equ EP_ABORT_DONE_EP6_IN [12:12]     
       @ .equ EP_ABORT_DONE_EP5_OUT [11:11]     
       @ .equ EP_ABORT_DONE_EP5_IN [10:10]     
       @ .equ EP_ABORT_DONE_EP4_OUT [9:9]     
       @ .equ EP_ABORT_DONE_EP4_IN [8:8]     
       @ .equ EP_ABORT_DONE_EP3_OUT [7:7]     
       @ .equ EP_ABORT_DONE_EP3_IN [6:6]     
       @ .equ EP_ABORT_DONE_EP2_OUT [5:5]     
       @ .equ EP_ABORT_DONE_EP2_IN [4:4]     
       @ .equ EP_ABORT_DONE_EP1_OUT [3:3]     
       @ .equ EP_ABORT_DONE_EP1_IN [2:2]     
       @ .equ EP_ABORT_DONE_EP0_OUT [1:1]     
       @ .equ EP_ABORT_DONE_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_EP_STALL_ARM, 0x0068 Device: this bit must be set in conjunction with the `STALL` bit in the buffer control register to send a STALL on EP0. The device controller clears these bits when a SETUP packet is received because the USB spec requires that a STALL condition is cleared when a SETUP packet is received.
       @ .equ EP_STALL_ARM_EP0_OUT [1:1]     
       @ .equ EP_STALL_ARM_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_NAK_POLL, 0x006c Used by the host controller. Sets the wait time in microseconds before trying again if the device replies with a NAK.
       @ .equ NAK_POLL_DELAY_FS [25:16]    NAK polling interval for a full speed device 
       @ .equ NAK_POLL_DELAY_LS [9:0]    NAK polling interval for a low speed device 
 
    .equ USBCTRL_REGS_EP_STATUS_STALL_NAK, 0x0070 Device: bits are set when the `IRQ_ON_NAK` or `IRQ_ON_STALL` bits are set. For EP0 this comes from `SIE_CTRL`. For all other endpoints it comes from the endpoint control register.
       @ .equ EP_STATUS_STALL_NAK_EP15_OUT [31:31]     
       @ .equ EP_STATUS_STALL_NAK_EP15_IN [30:30]     
       @ .equ EP_STATUS_STALL_NAK_EP14_OUT [29:29]     
       @ .equ EP_STATUS_STALL_NAK_EP14_IN [28:28]     
       @ .equ EP_STATUS_STALL_NAK_EP13_OUT [27:27]     
       @ .equ EP_STATUS_STALL_NAK_EP13_IN [26:26]     
       @ .equ EP_STATUS_STALL_NAK_EP12_OUT [25:25]     
       @ .equ EP_STATUS_STALL_NAK_EP12_IN [24:24]     
       @ .equ EP_STATUS_STALL_NAK_EP11_OUT [23:23]     
       @ .equ EP_STATUS_STALL_NAK_EP11_IN [22:22]     
       @ .equ EP_STATUS_STALL_NAK_EP10_OUT [21:21]     
       @ .equ EP_STATUS_STALL_NAK_EP10_IN [20:20]     
       @ .equ EP_STATUS_STALL_NAK_EP9_OUT [19:19]     
       @ .equ EP_STATUS_STALL_NAK_EP9_IN [18:18]     
       @ .equ EP_STATUS_STALL_NAK_EP8_OUT [17:17]     
       @ .equ EP_STATUS_STALL_NAK_EP8_IN [16:16]     
       @ .equ EP_STATUS_STALL_NAK_EP7_OUT [15:15]     
       @ .equ EP_STATUS_STALL_NAK_EP7_IN [14:14]     
       @ .equ EP_STATUS_STALL_NAK_EP6_OUT [13:13]     
       @ .equ EP_STATUS_STALL_NAK_EP6_IN [12:12]     
       @ .equ EP_STATUS_STALL_NAK_EP5_OUT [11:11]     
       @ .equ EP_STATUS_STALL_NAK_EP5_IN [10:10]     
       @ .equ EP_STATUS_STALL_NAK_EP4_OUT [9:9]     
       @ .equ EP_STATUS_STALL_NAK_EP4_IN [8:8]     
       @ .equ EP_STATUS_STALL_NAK_EP3_OUT [7:7]     
       @ .equ EP_STATUS_STALL_NAK_EP3_IN [6:6]     
       @ .equ EP_STATUS_STALL_NAK_EP2_OUT [5:5]     
       @ .equ EP_STATUS_STALL_NAK_EP2_IN [4:4]     
       @ .equ EP_STATUS_STALL_NAK_EP1_OUT [3:3]     
       @ .equ EP_STATUS_STALL_NAK_EP1_IN [2:2]     
       @ .equ EP_STATUS_STALL_NAK_EP0_OUT [1:1]     
       @ .equ EP_STATUS_STALL_NAK_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_USB_MUXING, 0x0074 Where to connect the USB controller. Should be to_phy by default.
       @ .equ USB_MUXING_SOFTCON [3:3]     
       @ .equ USB_MUXING_TO_DIGITAL_PAD [2:2]     
       @ .equ USB_MUXING_TO_EXTPHY [1:1]     
       @ .equ USB_MUXING_TO_PHY [0:0]     
 
    .equ USBCTRL_REGS_USB_PWR, 0x0078 Overrides for the power signals in the event that the VBUS signals are not hooked up to GPIO. Set the value of the override and then the override enable to switch over to the override value.
       @ .equ USB_PWR_OVERCURR_DETECT_EN [5:5]     
       @ .equ USB_PWR_OVERCURR_DETECT [4:4]     
       @ .equ USB_PWR_VBUS_DETECT_OVERRIDE_EN [3:3]     
       @ .equ USB_PWR_VBUS_DETECT [2:2]     
       @ .equ USB_PWR_VBUS_EN_OVERRIDE_EN [1:1]     
       @ .equ USB_PWR_VBUS_EN [0:0]     
 
    .equ USBCTRL_REGS_USBPHY_DIRECT, 0x007c This register allows for direct control of the USB phy. Use in conjunction with usbphy_direct_override register to enable each override bit.
       @ .equ USBPHY_DIRECT_DM_OVV [22:22]    DM over voltage 
       @ .equ USBPHY_DIRECT_DP_OVV [21:21]    DP over voltage 
       @ .equ USBPHY_DIRECT_DM_OVCN [20:20]    DM overcurrent 
       @ .equ USBPHY_DIRECT_DP_OVCN [19:19]    DP overcurrent 
       @ .equ USBPHY_DIRECT_RX_DM [18:18]    DPM pin state 
       @ .equ USBPHY_DIRECT_RX_DP [17:17]    DPP pin state 
       @ .equ USBPHY_DIRECT_RX_DD [16:16]    Differential RX 
       @ .equ USBPHY_DIRECT_TX_DIFFMODE [15:15]    TX_DIFFMODE=0: Single ended mode  TX_DIFFMODE=1: Differential drive mode TX_DM, TX_DM_OE ignored 
       @ .equ USBPHY_DIRECT_TX_FSSLEW [14:14]    TX_FSSLEW=0: Low speed slew rate  TX_FSSLEW=1: Full speed slew rate 
       @ .equ USBPHY_DIRECT_TX_PD [13:13]    TX power down override if override enable is set. 1 = powered down. 
       @ .equ USBPHY_DIRECT_RX_PD [12:12]    RX power down override if override enable is set. 1 = powered down. 
       @ .equ USBPHY_DIRECT_TX_DM [11:11]    Output data. TX_DIFFMODE=1, Ignored  TX_DIFFMODE=0, Drives DPM only. TX_DM_OE=1 to enable drive. DPM=TX_DM 
       @ .equ USBPHY_DIRECT_TX_DP [10:10]    Output data. If TX_DIFFMODE=1, Drives DPP/DPM diff pair. TX_DP_OE=1 to enable drive. DPP=TX_DP, DPM=~TX_DP  If TX_DIFFMODE=0, Drives DPP only. TX_DP_OE=1 to enable drive. DPP=TX_DP 
       @ .equ USBPHY_DIRECT_TX_DM_OE [9:9]    Output enable. If TX_DIFFMODE=1, Ignored.  If TX_DIFFMODE=0, OE for DPM only. 0 - DPM in Hi-Z state; 1 - DPM driving 
       @ .equ USBPHY_DIRECT_TX_DP_OE [8:8]    Output enable. If TX_DIFFMODE=1, OE for DPP/DPM diff pair. 0 - DPP/DPM in Hi-Z state; 1 - DPP/DPM driving  If TX_DIFFMODE=0, OE for DPP only. 0 - DPP in Hi-Z state; 1 - DPP driving 
       @ .equ USBPHY_DIRECT_DM_PULLDN_EN [6:6]    DM pull down enable 
       @ .equ USBPHY_DIRECT_DM_PULLUP_EN [5:5]    DM pull up enable 
       @ .equ USBPHY_DIRECT_DM_PULLUP_HISEL [4:4]    Enable the second DM pull up resistor. 0 - Pull = Rpu2; 1 - Pull = Rpu1 + Rpu2 
       @ .equ USBPHY_DIRECT_DP_PULLDN_EN [2:2]    DP pull down enable 
       @ .equ USBPHY_DIRECT_DP_PULLUP_EN [1:1]    DP pull up enable 
       @ .equ USBPHY_DIRECT_DP_PULLUP_HISEL [0:0]    Enable the second DP pull up resistor. 0 - Pull = Rpu2; 1 - Pull = Rpu1 + Rpu2 
 
    .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE, 0x0080 Override enable for each control in usbphy_direct
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_DIFFMODE_OVERRIDE_EN [15:15]     
       @ .equ USBPHY_DIRECT_OVERRIDE_DM_PULLUP_OVERRIDE_EN [12:12]     
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_FSSLEW_OVERRIDE_EN [11:11]     
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_PD_OVERRIDE_EN [10:10]     
       @ .equ USBPHY_DIRECT_OVERRIDE_RX_PD_OVERRIDE_EN [9:9]     
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_DM_OVERRIDE_EN [8:8]     
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_DP_OVERRIDE_EN [7:7]     
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_DM_OE_OVERRIDE_EN [6:6]     
       @ .equ USBPHY_DIRECT_OVERRIDE_TX_DP_OE_OVERRIDE_EN [5:5]     
       @ .equ USBPHY_DIRECT_OVERRIDE_DM_PULLDN_EN_OVERRIDE_EN [4:4]     
       @ .equ USBPHY_DIRECT_OVERRIDE_DP_PULLDN_EN_OVERRIDE_EN [3:3]     
       @ .equ USBPHY_DIRECT_OVERRIDE_DP_PULLUP_EN_OVERRIDE_EN [2:2]     
       @ .equ USBPHY_DIRECT_OVERRIDE_DM_PULLUP_HISEL_OVERRIDE_EN [1:1]     
       @ .equ USBPHY_DIRECT_OVERRIDE_DP_PULLUP_HISEL_OVERRIDE_EN [0:0]     
 
    .equ USBCTRL_REGS_USBPHY_TRIM, 0x0084 Used to adjust trim values of USB phy pull down resistors.
       @ .equ USBPHY_TRIM_DM_PULLDN_TRIM [12:8]    Value to drive to USB PHY  DM pulldown resistor trim control  Experimental data suggests that the reset value will work, but this register allows adjustment if required 
       @ .equ USBPHY_TRIM_DP_PULLDN_TRIM [4:0]    Value to drive to USB PHY  DP pulldown resistor trim control  Experimental data suggests that the reset value will work, but this register allows adjustment if required 
 
    .equ USBCTRL_REGS_INTR, 0x008c Raw Interrupts
       @ .equ INTR_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ INTR_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ INTR_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ INTR_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ INTR_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTR_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ INTR_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ INTR_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ INTR_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ INTR_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ INTR_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ INTR_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ INTR_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ INTR_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ INTR_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ INTR_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ INTR_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ INTR_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ INTR_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTR_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 
    .equ USBCTRL_REGS_INTE, 0x0090 Interrupt Enable
       @ .equ INTE_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ INTE_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ INTE_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ INTE_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ INTE_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTE_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ INTE_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ INTE_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ INTE_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ INTE_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ INTE_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ INTE_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ INTE_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ INTE_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ INTE_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ INTE_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ INTE_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ INTE_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ INTE_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTE_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 
    .equ USBCTRL_REGS_INTF, 0x0094 Interrupt Force
       @ .equ INTF_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ INTF_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ INTF_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ INTF_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ INTF_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTF_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ INTF_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ INTF_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ INTF_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ INTF_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ INTF_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ INTF_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ INTF_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ INTF_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ INTF_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ INTF_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ INTF_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ INTF_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ INTF_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTF_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 
    .equ USBCTRL_REGS_INTS, 0x0098 Interrupt status after masking & forcing
       @ .equ INTS_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ INTS_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ INTS_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ INTS_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ INTS_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTS_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ INTS_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ INTS_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ INTS_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ INTS_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ INTS_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ INTS_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ INTS_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ INTS_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ INTS_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ INTS_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ INTS_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ INTS_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ INTS_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ INTS_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 

@=========================== PIO0 ===========================@
.equ PIO0_BASE, 0x50200000 Programmable IO block
    .equ PIO0_CTRL, 0x0000 PIO control register
       @ .equ CTRL_CLKDIV_RESTART [11:8]    Force clock dividers to restart their count and clear fractional  accumulators. Restart multiple dividers to synchronise them. 
       @ .equ CTRL_SM_RESTART [7:4]    Clear internal SM state which is otherwise difficult to access  e.g. shift counters. Self-clearing. 
       @ .equ CTRL_SM_ENABLE [3:0]    Enable state machine 
 
    .equ PIO0_FSTAT, 0x0004 FIFO status register
       @ .equ FSTAT_TXEMPTY [27:24]    State machine TX FIFO is empty 
       @ .equ FSTAT_TXFULL [19:16]    State machine TX FIFO is full 
       @ .equ FSTAT_RXEMPTY [11:8]    State machine RX FIFO is empty 
       @ .equ FSTAT_RXFULL [3:0]    State machine RX FIFO is full 
 
    .equ PIO0_FDEBUG, 0x0008 FIFO debug register
       @ .equ FDEBUG_TXSTALL [27:24]    State machine has stalled on empty TX FIFO. Write 1 to clear. 
       @ .equ FDEBUG_TXOVER [19:16]    TX FIFO overflow has occurred. Write 1 to clear. 
       @ .equ FDEBUG_RXUNDER [11:8]    RX FIFO underflow has occurred. Write 1 to clear. 
       @ .equ FDEBUG_RXSTALL [3:0]    State machine has stalled on full RX FIFO. Write 1 to clear. 
 
    .equ PIO0_FLEVEL, 0x000c FIFO levels
       @ .equ FLEVEL_RX3 [31:28]     
       @ .equ FLEVEL_TX3 [27:24]     
       @ .equ FLEVEL_RX2 [23:20]     
       @ .equ FLEVEL_TX2 [19:16]     
       @ .equ FLEVEL_RX1 [15:12]     
       @ .equ FLEVEL_TX1 [11:8]     
       @ .equ FLEVEL_RX0 [7:4]     
       @ .equ FLEVEL_TX0 [3:0]     
 
    .equ PIO0_TXF0, 0x0010 Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO0_TXF1, 0x0014 Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO0_TXF2, 0x0018 Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO0_TXF3, 0x001c Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO0_RXF0, 0x0020 Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO0_RXF1, 0x0024 Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO0_RXF2, 0x0028 Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO0_RXF3, 0x002c Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO0_IRQ, 0x0030 Interrupt request register. Write 1 to clear
       @ .equ IRQ_IRQ [7:0]     
 
    .equ PIO0_IRQ_FORCE, 0x0034 Writing a 1 to each of these bits will forcibly assert the corresponding IRQ.  Note this is different to the INTF register: writing here affects PIO internal  state. INTF just asserts the processor-facing IRQ signal for testing ISRs,  and is not visible to the state machines.
       @ .equ IRQ_FORCE_IRQ_FORCE [7:0]     
 
    .equ PIO0_INPUT_SYNC_BYPASS, 0x0038 There is a 2-flipflop synchronizer on each GPIO input, which protects  PIO logic from metastabilities. This increases input delay, and for fast  synchronous IO e.g. SPI these synchronizers may need to be bypassed.  Each bit in this register corresponds to one GPIO.  0 -> input is synchronized default  1 -> synchronizer is bypassed  If in doubt, leave this register as all zeroes.
 
    .equ PIO0_DBG_PADOUT, 0x003c Read to sample the pad output values PIO is currently driving to the GPIOs.
 
    .equ PIO0_DBG_PADOE, 0x0040 Read to sample the pad output enables direction PIO is currently driving to the GPIOs.
 
    .equ PIO0_DBG_CFGINFO, 0x0044 The PIO hardware has some free parameters that may vary between chip products.  These should be provided in the chip datasheet, but are also exposed here.
       @ .equ DBG_CFGINFO_IMEM_SIZE [21:16]    The size of the instruction memory, measured in units of one instruction 
       @ .equ DBG_CFGINFO_SM_COUNT [11:8]    The number of state machines this PIO instance is equipped with. 
       @ .equ DBG_CFGINFO_FIFO_DEPTH [5:0]    The depth of the state machine TX/RX FIFOs, measured in words.  Joining fifos via SHIFTCTRL_FJOIN gives one FIFO with double  this depth. 
 
    .equ PIO0_INSTR_MEM0, 0x0048 Write-only access to instruction memory location 0
       @ .equ INSTR_MEM0_INSTR_MEM0 [15:0]     
 
    .equ PIO0_INSTR_MEM1, 0x004c Write-only access to instruction memory location 1
       @ .equ INSTR_MEM1_INSTR_MEM1 [15:0]     
 
    .equ PIO0_INSTR_MEM2, 0x0050 Write-only access to instruction memory location 2
       @ .equ INSTR_MEM2_INSTR_MEM2 [15:0]     
 
    .equ PIO0_INSTR_MEM3, 0x0054 Write-only access to instruction memory location 3
       @ .equ INSTR_MEM3_INSTR_MEM3 [15:0]     
 
    .equ PIO0_INSTR_MEM4, 0x0058 Write-only access to instruction memory location 4
       @ .equ INSTR_MEM4_INSTR_MEM4 [15:0]     
 
    .equ PIO0_INSTR_MEM5, 0x005c Write-only access to instruction memory location 5
       @ .equ INSTR_MEM5_INSTR_MEM5 [15:0]     
 
    .equ PIO0_INSTR_MEM6, 0x0060 Write-only access to instruction memory location 6
       @ .equ INSTR_MEM6_INSTR_MEM6 [15:0]     
 
    .equ PIO0_INSTR_MEM7, 0x0064 Write-only access to instruction memory location 7
       @ .equ INSTR_MEM7_INSTR_MEM7 [15:0]     
 
    .equ PIO0_INSTR_MEM8, 0x0068 Write-only access to instruction memory location 8
       @ .equ INSTR_MEM8_INSTR_MEM8 [15:0]     
 
    .equ PIO0_INSTR_MEM9, 0x006c Write-only access to instruction memory location 9
       @ .equ INSTR_MEM9_INSTR_MEM9 [15:0]     
 
    .equ PIO0_INSTR_MEM10, 0x0070 Write-only access to instruction memory location 10
       @ .equ INSTR_MEM10_INSTR_MEM10 [15:0]     
 
    .equ PIO0_INSTR_MEM11, 0x0074 Write-only access to instruction memory location 11
       @ .equ INSTR_MEM11_INSTR_MEM11 [15:0]     
 
    .equ PIO0_INSTR_MEM12, 0x0078 Write-only access to instruction memory location 12
       @ .equ INSTR_MEM12_INSTR_MEM12 [15:0]     
 
    .equ PIO0_INSTR_MEM13, 0x007c Write-only access to instruction memory location 13
       @ .equ INSTR_MEM13_INSTR_MEM13 [15:0]     
 
    .equ PIO0_INSTR_MEM14, 0x0080 Write-only access to instruction memory location 14
       @ .equ INSTR_MEM14_INSTR_MEM14 [15:0]     
 
    .equ PIO0_INSTR_MEM15, 0x0084 Write-only access to instruction memory location 15
       @ .equ INSTR_MEM15_INSTR_MEM15 [15:0]     
 
    .equ PIO0_INSTR_MEM16, 0x0088 Write-only access to instruction memory location 16
       @ .equ INSTR_MEM16_INSTR_MEM16 [15:0]     
 
    .equ PIO0_INSTR_MEM17, 0x008c Write-only access to instruction memory location 17
       @ .equ INSTR_MEM17_INSTR_MEM17 [15:0]     
 
    .equ PIO0_INSTR_MEM18, 0x0090 Write-only access to instruction memory location 18
       @ .equ INSTR_MEM18_INSTR_MEM18 [15:0]     
 
    .equ PIO0_INSTR_MEM19, 0x0094 Write-only access to instruction memory location 19
       @ .equ INSTR_MEM19_INSTR_MEM19 [15:0]     
 
    .equ PIO0_INSTR_MEM20, 0x0098 Write-only access to instruction memory location 20
       @ .equ INSTR_MEM20_INSTR_MEM20 [15:0]     
 
    .equ PIO0_INSTR_MEM21, 0x009c Write-only access to instruction memory location 21
       @ .equ INSTR_MEM21_INSTR_MEM21 [15:0]     
 
    .equ PIO0_INSTR_MEM22, 0x00a0 Write-only access to instruction memory location 22
       @ .equ INSTR_MEM22_INSTR_MEM22 [15:0]     
 
    .equ PIO0_INSTR_MEM23, 0x00a4 Write-only access to instruction memory location 23
       @ .equ INSTR_MEM23_INSTR_MEM23 [15:0]     
 
    .equ PIO0_INSTR_MEM24, 0x00a8 Write-only access to instruction memory location 24
       @ .equ INSTR_MEM24_INSTR_MEM24 [15:0]     
 
    .equ PIO0_INSTR_MEM25, 0x00ac Write-only access to instruction memory location 25
       @ .equ INSTR_MEM25_INSTR_MEM25 [15:0]     
 
    .equ PIO0_INSTR_MEM26, 0x00b0 Write-only access to instruction memory location 26
       @ .equ INSTR_MEM26_INSTR_MEM26 [15:0]     
 
    .equ PIO0_INSTR_MEM27, 0x00b4 Write-only access to instruction memory location 27
       @ .equ INSTR_MEM27_INSTR_MEM27 [15:0]     
 
    .equ PIO0_INSTR_MEM28, 0x00b8 Write-only access to instruction memory location 28
       @ .equ INSTR_MEM28_INSTR_MEM28 [15:0]     
 
    .equ PIO0_INSTR_MEM29, 0x00bc Write-only access to instruction memory location 29
       @ .equ INSTR_MEM29_INSTR_MEM29 [15:0]     
 
    .equ PIO0_INSTR_MEM30, 0x00c0 Write-only access to instruction memory location 30
       @ .equ INSTR_MEM30_INSTR_MEM30 [15:0]     
 
    .equ PIO0_INSTR_MEM31, 0x00c4 Write-only access to instruction memory location 31
       @ .equ INSTR_MEM31_INSTR_MEM31 [15:0]     
 
    .equ PIO0_SM0_CLKDIV, 0x00c8 Clock divider register for state machine 0  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM0_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM0_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM0_EXECCTRL, 0x00cc Execution/behavioural settings for state machine 0
       @ .equ SM0_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM0_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM0_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM0_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM0_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM0_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM0_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM0_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM0_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM0_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM0_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM0_SHIFTCTRL, 0x00d0 Control behaviour of the input/output shift registers for state machine 0
       @ .equ SM0_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM0_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM0_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM0_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM0_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM0_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM0_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM0_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM0_ADDR, 0x00d4 Current instruction address of state machine 0
       @ .equ SM0_ADDR_SM0_ADDR [4:0]     
 
    .equ PIO0_SM0_INSTR, 0x00d8 Instruction currently being executed by state machine 0  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM0_INSTR_SM0_INSTR [15:0]     
 
    .equ PIO0_SM0_PINCTRL, 0x00dc State machine pin control
       @ .equ SM0_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM0_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM0_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM0_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM0_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM0_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM0_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_SM1_CLKDIV, 0x00e0 Clock divider register for state machine 1  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM1_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM1_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM1_EXECCTRL, 0x00e4 Execution/behavioural settings for state machine 1
       @ .equ SM1_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM1_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM1_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM1_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM1_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM1_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM1_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM1_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM1_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM1_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM1_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM1_SHIFTCTRL, 0x00e8 Control behaviour of the input/output shift registers for state machine 1
       @ .equ SM1_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM1_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM1_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM1_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM1_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM1_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM1_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM1_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM1_ADDR, 0x00ec Current instruction address of state machine 1
       @ .equ SM1_ADDR_SM1_ADDR [4:0]     
 
    .equ PIO0_SM1_INSTR, 0x00f0 Instruction currently being executed by state machine 1  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM1_INSTR_SM1_INSTR [15:0]     
 
    .equ PIO0_SM1_PINCTRL, 0x00f4 State machine pin control
       @ .equ SM1_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM1_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM1_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM1_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM1_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM1_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM1_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_SM2_CLKDIV, 0x00f8 Clock divider register for state machine 2  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM2_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM2_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM2_EXECCTRL, 0x00fc Execution/behavioural settings for state machine 2
       @ .equ SM2_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM2_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM2_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM2_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM2_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM2_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM2_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM2_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM2_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM2_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM2_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM2_SHIFTCTRL, 0x0100 Control behaviour of the input/output shift registers for state machine 2
       @ .equ SM2_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM2_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM2_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM2_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM2_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM2_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM2_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM2_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM2_ADDR, 0x0104 Current instruction address of state machine 2
       @ .equ SM2_ADDR_SM2_ADDR [4:0]     
 
    .equ PIO0_SM2_INSTR, 0x0108 Instruction currently being executed by state machine 2  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM2_INSTR_SM2_INSTR [15:0]     
 
    .equ PIO0_SM2_PINCTRL, 0x010c State machine pin control
       @ .equ SM2_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM2_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM2_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM2_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM2_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM2_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM2_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_SM3_CLKDIV, 0x0110 Clock divider register for state machine 3  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM3_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM3_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM3_EXECCTRL, 0x0114 Execution/behavioural settings for state machine 3
       @ .equ SM3_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM3_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM3_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM3_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM3_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM3_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM3_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM3_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM3_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM3_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM3_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM3_SHIFTCTRL, 0x0118 Control behaviour of the input/output shift registers for state machine 3
       @ .equ SM3_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM3_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM3_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM3_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM3_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM3_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM3_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM3_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM3_ADDR, 0x011c Current instruction address of state machine 3
       @ .equ SM3_ADDR_SM3_ADDR [4:0]     
 
    .equ PIO0_SM3_INSTR, 0x0120 Instruction currently being executed by state machine 3  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM3_INSTR_SM3_INSTR [15:0]     
 
    .equ PIO0_SM3_PINCTRL, 0x0124 State machine pin control
       @ .equ SM3_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM3_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM3_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM3_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM3_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM3_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM3_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_INTR, 0x0128 Raw Interrupts
       @ .equ INTR_SM3 [11:11]     
       @ .equ INTR_SM2 [10:10]     
       @ .equ INTR_SM1 [9:9]     
       @ .equ INTR_SM0 [8:8]     
       @ .equ INTR_SM3_TXNFULL [7:7]     
       @ .equ INTR_SM2_TXNFULL [6:6]     
       @ .equ INTR_SM1_TXNFULL [5:5]     
       @ .equ INTR_SM0_TXNFULL [4:4]     
       @ .equ INTR_SM3_RXNEMPTY [3:3]     
       @ .equ INTR_SM2_RXNEMPTY [2:2]     
       @ .equ INTR_SM1_RXNEMPTY [1:1]     
       @ .equ INTR_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ0_INTE, 0x012c Interrupt Enable for irq0
       @ .equ IRQ0_INTE_SM3 [11:11]     
       @ .equ IRQ0_INTE_SM2 [10:10]     
       @ .equ IRQ0_INTE_SM1 [9:9]     
       @ .equ IRQ0_INTE_SM0 [8:8]     
       @ .equ IRQ0_INTE_SM3_TXNFULL [7:7]     
       @ .equ IRQ0_INTE_SM2_TXNFULL [6:6]     
       @ .equ IRQ0_INTE_SM1_TXNFULL [5:5]     
       @ .equ IRQ0_INTE_SM0_TXNFULL [4:4]     
       @ .equ IRQ0_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ0_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ0_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ0_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ0_INTF, 0x0130 Interrupt Force for irq0
       @ .equ IRQ0_INTF_SM3 [11:11]     
       @ .equ IRQ0_INTF_SM2 [10:10]     
       @ .equ IRQ0_INTF_SM1 [9:9]     
       @ .equ IRQ0_INTF_SM0 [8:8]     
       @ .equ IRQ0_INTF_SM3_TXNFULL [7:7]     
       @ .equ IRQ0_INTF_SM2_TXNFULL [6:6]     
       @ .equ IRQ0_INTF_SM1_TXNFULL [5:5]     
       @ .equ IRQ0_INTF_SM0_TXNFULL [4:4]     
       @ .equ IRQ0_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ0_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ0_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ0_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ0_INTS, 0x0134 Interrupt status after masking & forcing for irq0
       @ .equ IRQ0_INTS_SM3 [11:11]     
       @ .equ IRQ0_INTS_SM2 [10:10]     
       @ .equ IRQ0_INTS_SM1 [9:9]     
       @ .equ IRQ0_INTS_SM0 [8:8]     
       @ .equ IRQ0_INTS_SM3_TXNFULL [7:7]     
       @ .equ IRQ0_INTS_SM2_TXNFULL [6:6]     
       @ .equ IRQ0_INTS_SM1_TXNFULL [5:5]     
       @ .equ IRQ0_INTS_SM0_TXNFULL [4:4]     
       @ .equ IRQ0_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ0_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ0_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ0_INTS_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ1_INTE, 0x0138 Interrupt Enable for irq1
       @ .equ IRQ1_INTE_SM3 [11:11]     
       @ .equ IRQ1_INTE_SM2 [10:10]     
       @ .equ IRQ1_INTE_SM1 [9:9]     
       @ .equ IRQ1_INTE_SM0 [8:8]     
       @ .equ IRQ1_INTE_SM3_TXNFULL [7:7]     
       @ .equ IRQ1_INTE_SM2_TXNFULL [6:6]     
       @ .equ IRQ1_INTE_SM1_TXNFULL [5:5]     
       @ .equ IRQ1_INTE_SM0_TXNFULL [4:4]     
       @ .equ IRQ1_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ1_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ1_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ1_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ1_INTF, 0x013c Interrupt Force for irq1
       @ .equ IRQ1_INTF_SM3 [11:11]     
       @ .equ IRQ1_INTF_SM2 [10:10]     
       @ .equ IRQ1_INTF_SM1 [9:9]     
       @ .equ IRQ1_INTF_SM0 [8:8]     
       @ .equ IRQ1_INTF_SM3_TXNFULL [7:7]     
       @ .equ IRQ1_INTF_SM2_TXNFULL [6:6]     
       @ .equ IRQ1_INTF_SM1_TXNFULL [5:5]     
       @ .equ IRQ1_INTF_SM0_TXNFULL [4:4]     
       @ .equ IRQ1_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ1_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ1_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ1_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ1_INTS, 0x0140 Interrupt status after masking & forcing for irq1
       @ .equ IRQ1_INTS_SM3 [11:11]     
       @ .equ IRQ1_INTS_SM2 [10:10]     
       @ .equ IRQ1_INTS_SM1 [9:9]     
       @ .equ IRQ1_INTS_SM0 [8:8]     
       @ .equ IRQ1_INTS_SM3_TXNFULL [7:7]     
       @ .equ IRQ1_INTS_SM2_TXNFULL [6:6]     
       @ .equ IRQ1_INTS_SM1_TXNFULL [5:5]     
       @ .equ IRQ1_INTS_SM0_TXNFULL [4:4]     
       @ .equ IRQ1_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ1_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ1_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ1_INTS_SM0_RXNEMPTY [0:0]     
 

@=========================== PIO1 ===========================@
.equ PIO1_BASE, 0x50300000 Programmable IO block
    .equ PIO1_CTRL, 0x0000 PIO control register
       @ .equ CTRL_CLKDIV_RESTART [11:8]    Force clock dividers to restart their count and clear fractional  accumulators. Restart multiple dividers to synchronise them. 
       @ .equ CTRL_SM_RESTART [7:4]    Clear internal SM state which is otherwise difficult to access  e.g. shift counters. Self-clearing. 
       @ .equ CTRL_SM_ENABLE [3:0]    Enable state machine 
 
    .equ PIO1_FSTAT, 0x0004 FIFO status register
       @ .equ FSTAT_TXEMPTY [27:24]    State machine TX FIFO is empty 
       @ .equ FSTAT_TXFULL [19:16]    State machine TX FIFO is full 
       @ .equ FSTAT_RXEMPTY [11:8]    State machine RX FIFO is empty 
       @ .equ FSTAT_RXFULL [3:0]    State machine RX FIFO is full 
 
    .equ PIO1_FDEBUG, 0x0008 FIFO debug register
       @ .equ FDEBUG_TXSTALL [27:24]    State machine has stalled on empty TX FIFO. Write 1 to clear. 
       @ .equ FDEBUG_TXOVER [19:16]    TX FIFO overflow has occurred. Write 1 to clear. 
       @ .equ FDEBUG_RXUNDER [11:8]    RX FIFO underflow has occurred. Write 1 to clear. 
       @ .equ FDEBUG_RXSTALL [3:0]    State machine has stalled on full RX FIFO. Write 1 to clear. 
 
    .equ PIO1_FLEVEL, 0x000c FIFO levels
       @ .equ FLEVEL_RX3 [31:28]     
       @ .equ FLEVEL_TX3 [27:24]     
       @ .equ FLEVEL_RX2 [23:20]     
       @ .equ FLEVEL_TX2 [19:16]     
       @ .equ FLEVEL_RX1 [15:12]     
       @ .equ FLEVEL_TX1 [11:8]     
       @ .equ FLEVEL_RX0 [7:4]     
       @ .equ FLEVEL_TX0 [3:0]     
 
    .equ PIO1_TXF0, 0x0010 Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO1_TXF1, 0x0014 Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO1_TXF2, 0x0018 Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO1_TXF3, 0x001c Direct write access to the TX FIFO for this state machine. Each write pushes one word to the FIFO.
 
    .equ PIO1_RXF0, 0x0020 Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO1_RXF1, 0x0024 Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO1_RXF2, 0x0028 Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO1_RXF3, 0x002c Direct read access to the RX FIFO for this state machine. Each read pops one word from the FIFO.
 
    .equ PIO1_IRQ, 0x0030 Interrupt request register. Write 1 to clear
       @ .equ IRQ_IRQ [7:0]     
 
    .equ PIO1_IRQ_FORCE, 0x0034 Writing a 1 to each of these bits will forcibly assert the corresponding IRQ.  Note this is different to the INTF register: writing here affects PIO internal  state. INTF just asserts the processor-facing IRQ signal for testing ISRs,  and is not visible to the state machines.
       @ .equ IRQ_FORCE_IRQ_FORCE [7:0]     
 
    .equ PIO1_INPUT_SYNC_BYPASS, 0x0038 There is a 2-flipflop synchronizer on each GPIO input, which protects  PIO logic from metastabilities. This increases input delay, and for fast  synchronous IO e.g. SPI these synchronizers may need to be bypassed.  Each bit in this register corresponds to one GPIO.  0 -> input is synchronized default  1 -> synchronizer is bypassed  If in doubt, leave this register as all zeroes.
 
    .equ PIO1_DBG_PADOUT, 0x003c Read to sample the pad output values PIO is currently driving to the GPIOs.
 
    .equ PIO1_DBG_PADOE, 0x0040 Read to sample the pad output enables direction PIO is currently driving to the GPIOs.
 
    .equ PIO1_DBG_CFGINFO, 0x0044 The PIO hardware has some free parameters that may vary between chip products.  These should be provided in the chip datasheet, but are also exposed here.
       @ .equ DBG_CFGINFO_IMEM_SIZE [21:16]    The size of the instruction memory, measured in units of one instruction 
       @ .equ DBG_CFGINFO_SM_COUNT [11:8]    The number of state machines this PIO instance is equipped with. 
       @ .equ DBG_CFGINFO_FIFO_DEPTH [5:0]    The depth of the state machine TX/RX FIFOs, measured in words.  Joining fifos via SHIFTCTRL_FJOIN gives one FIFO with double  this depth. 
 
    .equ PIO1_INSTR_MEM0, 0x0048 Write-only access to instruction memory location 0
       @ .equ INSTR_MEM0_INSTR_MEM0 [15:0]     
 
    .equ PIO1_INSTR_MEM1, 0x004c Write-only access to instruction memory location 1
       @ .equ INSTR_MEM1_INSTR_MEM1 [15:0]     
 
    .equ PIO1_INSTR_MEM2, 0x0050 Write-only access to instruction memory location 2
       @ .equ INSTR_MEM2_INSTR_MEM2 [15:0]     
 
    .equ PIO1_INSTR_MEM3, 0x0054 Write-only access to instruction memory location 3
       @ .equ INSTR_MEM3_INSTR_MEM3 [15:0]     
 
    .equ PIO1_INSTR_MEM4, 0x0058 Write-only access to instruction memory location 4
       @ .equ INSTR_MEM4_INSTR_MEM4 [15:0]     
 
    .equ PIO1_INSTR_MEM5, 0x005c Write-only access to instruction memory location 5
       @ .equ INSTR_MEM5_INSTR_MEM5 [15:0]     
 
    .equ PIO1_INSTR_MEM6, 0x0060 Write-only access to instruction memory location 6
       @ .equ INSTR_MEM6_INSTR_MEM6 [15:0]     
 
    .equ PIO1_INSTR_MEM7, 0x0064 Write-only access to instruction memory location 7
       @ .equ INSTR_MEM7_INSTR_MEM7 [15:0]     
 
    .equ PIO1_INSTR_MEM8, 0x0068 Write-only access to instruction memory location 8
       @ .equ INSTR_MEM8_INSTR_MEM8 [15:0]     
 
    .equ PIO1_INSTR_MEM9, 0x006c Write-only access to instruction memory location 9
       @ .equ INSTR_MEM9_INSTR_MEM9 [15:0]     
 
    .equ PIO1_INSTR_MEM10, 0x0070 Write-only access to instruction memory location 10
       @ .equ INSTR_MEM10_INSTR_MEM10 [15:0]     
 
    .equ PIO1_INSTR_MEM11, 0x0074 Write-only access to instruction memory location 11
       @ .equ INSTR_MEM11_INSTR_MEM11 [15:0]     
 
    .equ PIO1_INSTR_MEM12, 0x0078 Write-only access to instruction memory location 12
       @ .equ INSTR_MEM12_INSTR_MEM12 [15:0]     
 
    .equ PIO1_INSTR_MEM13, 0x007c Write-only access to instruction memory location 13
       @ .equ INSTR_MEM13_INSTR_MEM13 [15:0]     
 
    .equ PIO1_INSTR_MEM14, 0x0080 Write-only access to instruction memory location 14
       @ .equ INSTR_MEM14_INSTR_MEM14 [15:0]     
 
    .equ PIO1_INSTR_MEM15, 0x0084 Write-only access to instruction memory location 15
       @ .equ INSTR_MEM15_INSTR_MEM15 [15:0]     
 
    .equ PIO1_INSTR_MEM16, 0x0088 Write-only access to instruction memory location 16
       @ .equ INSTR_MEM16_INSTR_MEM16 [15:0]     
 
    .equ PIO1_INSTR_MEM17, 0x008c Write-only access to instruction memory location 17
       @ .equ INSTR_MEM17_INSTR_MEM17 [15:0]     
 
    .equ PIO1_INSTR_MEM18, 0x0090 Write-only access to instruction memory location 18
       @ .equ INSTR_MEM18_INSTR_MEM18 [15:0]     
 
    .equ PIO1_INSTR_MEM19, 0x0094 Write-only access to instruction memory location 19
       @ .equ INSTR_MEM19_INSTR_MEM19 [15:0]     
 
    .equ PIO1_INSTR_MEM20, 0x0098 Write-only access to instruction memory location 20
       @ .equ INSTR_MEM20_INSTR_MEM20 [15:0]     
 
    .equ PIO1_INSTR_MEM21, 0x009c Write-only access to instruction memory location 21
       @ .equ INSTR_MEM21_INSTR_MEM21 [15:0]     
 
    .equ PIO1_INSTR_MEM22, 0x00a0 Write-only access to instruction memory location 22
       @ .equ INSTR_MEM22_INSTR_MEM22 [15:0]     
 
    .equ PIO1_INSTR_MEM23, 0x00a4 Write-only access to instruction memory location 23
       @ .equ INSTR_MEM23_INSTR_MEM23 [15:0]     
 
    .equ PIO1_INSTR_MEM24, 0x00a8 Write-only access to instruction memory location 24
       @ .equ INSTR_MEM24_INSTR_MEM24 [15:0]     
 
    .equ PIO1_INSTR_MEM25, 0x00ac Write-only access to instruction memory location 25
       @ .equ INSTR_MEM25_INSTR_MEM25 [15:0]     
 
    .equ PIO1_INSTR_MEM26, 0x00b0 Write-only access to instruction memory location 26
       @ .equ INSTR_MEM26_INSTR_MEM26 [15:0]     
 
    .equ PIO1_INSTR_MEM27, 0x00b4 Write-only access to instruction memory location 27
       @ .equ INSTR_MEM27_INSTR_MEM27 [15:0]     
 
    .equ PIO1_INSTR_MEM28, 0x00b8 Write-only access to instruction memory location 28
       @ .equ INSTR_MEM28_INSTR_MEM28 [15:0]     
 
    .equ PIO1_INSTR_MEM29, 0x00bc Write-only access to instruction memory location 29
       @ .equ INSTR_MEM29_INSTR_MEM29 [15:0]     
 
    .equ PIO1_INSTR_MEM30, 0x00c0 Write-only access to instruction memory location 30
       @ .equ INSTR_MEM30_INSTR_MEM30 [15:0]     
 
    .equ PIO1_INSTR_MEM31, 0x00c4 Write-only access to instruction memory location 31
       @ .equ INSTR_MEM31_INSTR_MEM31 [15:0]     
 
    .equ PIO1_SM0_CLKDIV, 0x00c8 Clock divider register for state machine 0  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM0_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM0_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM0_EXECCTRL, 0x00cc Execution/behavioural settings for state machine 0
       @ .equ SM0_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM0_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM0_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM0_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM0_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM0_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM0_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM0_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM0_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM0_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM0_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM0_SHIFTCTRL, 0x00d0 Control behaviour of the input/output shift registers for state machine 0
       @ .equ SM0_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM0_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM0_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM0_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM0_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM0_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM0_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM0_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM0_ADDR, 0x00d4 Current instruction address of state machine 0
       @ .equ SM0_ADDR_SM0_ADDR [4:0]     
 
    .equ PIO1_SM0_INSTR, 0x00d8 Instruction currently being executed by state machine 0  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM0_INSTR_SM0_INSTR [15:0]     
 
    .equ PIO1_SM0_PINCTRL, 0x00dc State machine pin control
       @ .equ SM0_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM0_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM0_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM0_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM0_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM0_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM0_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_SM1_CLKDIV, 0x00e0 Clock divider register for state machine 1  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM1_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM1_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM1_EXECCTRL, 0x00e4 Execution/behavioural settings for state machine 1
       @ .equ SM1_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM1_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM1_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM1_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM1_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM1_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM1_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM1_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM1_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM1_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM1_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM1_SHIFTCTRL, 0x00e8 Control behaviour of the input/output shift registers for state machine 1
       @ .equ SM1_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM1_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM1_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM1_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM1_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM1_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM1_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM1_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM1_ADDR, 0x00ec Current instruction address of state machine 1
       @ .equ SM1_ADDR_SM1_ADDR [4:0]     
 
    .equ PIO1_SM1_INSTR, 0x00f0 Instruction currently being executed by state machine 1  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM1_INSTR_SM1_INSTR [15:0]     
 
    .equ PIO1_SM1_PINCTRL, 0x00f4 State machine pin control
       @ .equ SM1_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM1_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM1_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM1_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM1_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM1_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM1_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_SM2_CLKDIV, 0x00f8 Clock divider register for state machine 2  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM2_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM2_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM2_EXECCTRL, 0x00fc Execution/behavioural settings for state machine 2
       @ .equ SM2_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM2_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM2_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM2_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM2_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM2_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM2_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM2_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM2_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM2_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM2_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM2_SHIFTCTRL, 0x0100 Control behaviour of the input/output shift registers for state machine 2
       @ .equ SM2_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM2_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM2_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM2_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM2_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM2_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM2_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM2_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM2_ADDR, 0x0104 Current instruction address of state machine 2
       @ .equ SM2_ADDR_SM2_ADDR [4:0]     
 
    .equ PIO1_SM2_INSTR, 0x0108 Instruction currently being executed by state machine 2  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM2_INSTR_SM2_INSTR [15:0]     
 
    .equ PIO1_SM2_PINCTRL, 0x010c State machine pin control
       @ .equ SM2_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM2_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM2_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM2_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM2_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM2_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM2_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_SM3_CLKDIV, 0x0110 Clock divider register for state machine 3  Frequency = clock freq / CLKDIV_INT + CLKDIV_FRAC / 256
       @ .equ SM3_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.  Value of 0 is interpreted as max possible value 
       @ .equ SM3_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM3_EXECCTRL, 0x0114 Execution/behavioural settings for state machine 3
       @ .equ SM3_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the  state machine. Will clear once the instruction completes. 
       @ .equ SM3_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a  side-set data bit. This allows instructions to perform side-set optionally,  rather than on every instruction. 
       @ .equ SM3_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ SM3_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ SM3_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ SM3_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable  When used in conjunction with OUT_STICKY, writes with an enable of 0 will  deassert the latest pin write. This can create useful masking/override behaviour  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ SM3_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ SM3_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ SM3_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ SM3_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ SM3_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM3_SHIFTCTRL, 0x0118 Control behaviour of the input/output shift registers for state machine 3
       @ .equ SM3_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.  TX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM3_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.  RX FIFO is disabled as a result always reads as both full and empty.  FIFOs are flushed when this bit is changed. 
       @ .equ SM3_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.  Write 0 for value of 32. 
       @ .equ SM3_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.  Write 0 for value of 32. 
       @ .equ SM3_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ SM3_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ SM3_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ SM3_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM3_ADDR, 0x011c Current instruction address of state machine 3
       @ .equ SM3_ADDR_SM3_ADDR [4:0]     
 
    .equ PIO1_SM3_INSTR, 0x0120 Instruction currently being executed by state machine 3  Write to execute an instruction immediately including jumps and then resume execution.
       @ .equ SM3_INSTR_SM3_INSTR [15:0]     
 
    .equ PIO1_SM3_PINCTRL, 0x0124 State machine pin control
       @ .equ SM3_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ SM3_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ SM3_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ SM3_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ SM3_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ SM3_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ SM3_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_INTR, 0x0128 Raw Interrupts
       @ .equ INTR_SM3 [11:11]     
       @ .equ INTR_SM2 [10:10]     
       @ .equ INTR_SM1 [9:9]     
       @ .equ INTR_SM0 [8:8]     
       @ .equ INTR_SM3_TXNFULL [7:7]     
       @ .equ INTR_SM2_TXNFULL [6:6]     
       @ .equ INTR_SM1_TXNFULL [5:5]     
       @ .equ INTR_SM0_TXNFULL [4:4]     
       @ .equ INTR_SM3_RXNEMPTY [3:3]     
       @ .equ INTR_SM2_RXNEMPTY [2:2]     
       @ .equ INTR_SM1_RXNEMPTY [1:1]     
       @ .equ INTR_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ0_INTE, 0x012c Interrupt Enable for irq0
       @ .equ IRQ0_INTE_SM3 [11:11]     
       @ .equ IRQ0_INTE_SM2 [10:10]     
       @ .equ IRQ0_INTE_SM1 [9:9]     
       @ .equ IRQ0_INTE_SM0 [8:8]     
       @ .equ IRQ0_INTE_SM3_TXNFULL [7:7]     
       @ .equ IRQ0_INTE_SM2_TXNFULL [6:6]     
       @ .equ IRQ0_INTE_SM1_TXNFULL [5:5]     
       @ .equ IRQ0_INTE_SM0_TXNFULL [4:4]     
       @ .equ IRQ0_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ0_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ0_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ0_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ0_INTF, 0x0130 Interrupt Force for irq0
       @ .equ IRQ0_INTF_SM3 [11:11]     
       @ .equ IRQ0_INTF_SM2 [10:10]     
       @ .equ IRQ0_INTF_SM1 [9:9]     
       @ .equ IRQ0_INTF_SM0 [8:8]     
       @ .equ IRQ0_INTF_SM3_TXNFULL [7:7]     
       @ .equ IRQ0_INTF_SM2_TXNFULL [6:6]     
       @ .equ IRQ0_INTF_SM1_TXNFULL [5:5]     
       @ .equ IRQ0_INTF_SM0_TXNFULL [4:4]     
       @ .equ IRQ0_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ0_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ0_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ0_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ0_INTS, 0x0134 Interrupt status after masking & forcing for irq0
       @ .equ IRQ0_INTS_SM3 [11:11]     
       @ .equ IRQ0_INTS_SM2 [10:10]     
       @ .equ IRQ0_INTS_SM1 [9:9]     
       @ .equ IRQ0_INTS_SM0 [8:8]     
       @ .equ IRQ0_INTS_SM3_TXNFULL [7:7]     
       @ .equ IRQ0_INTS_SM2_TXNFULL [6:6]     
       @ .equ IRQ0_INTS_SM1_TXNFULL [5:5]     
       @ .equ IRQ0_INTS_SM0_TXNFULL [4:4]     
       @ .equ IRQ0_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ0_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ0_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ0_INTS_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ1_INTE, 0x0138 Interrupt Enable for irq1
       @ .equ IRQ1_INTE_SM3 [11:11]     
       @ .equ IRQ1_INTE_SM2 [10:10]     
       @ .equ IRQ1_INTE_SM1 [9:9]     
       @ .equ IRQ1_INTE_SM0 [8:8]     
       @ .equ IRQ1_INTE_SM3_TXNFULL [7:7]     
       @ .equ IRQ1_INTE_SM2_TXNFULL [6:6]     
       @ .equ IRQ1_INTE_SM1_TXNFULL [5:5]     
       @ .equ IRQ1_INTE_SM0_TXNFULL [4:4]     
       @ .equ IRQ1_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ1_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ1_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ1_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ1_INTF, 0x013c Interrupt Force for irq1
       @ .equ IRQ1_INTF_SM3 [11:11]     
       @ .equ IRQ1_INTF_SM2 [10:10]     
       @ .equ IRQ1_INTF_SM1 [9:9]     
       @ .equ IRQ1_INTF_SM0 [8:8]     
       @ .equ IRQ1_INTF_SM3_TXNFULL [7:7]     
       @ .equ IRQ1_INTF_SM2_TXNFULL [6:6]     
       @ .equ IRQ1_INTF_SM1_TXNFULL [5:5]     
       @ .equ IRQ1_INTF_SM0_TXNFULL [4:4]     
       @ .equ IRQ1_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ1_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ1_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ1_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ1_INTS, 0x0140 Interrupt status after masking & forcing for irq1
       @ .equ IRQ1_INTS_SM3 [11:11]     
       @ .equ IRQ1_INTS_SM2 [10:10]     
       @ .equ IRQ1_INTS_SM1 [9:9]     
       @ .equ IRQ1_INTS_SM0 [8:8]     
       @ .equ IRQ1_INTS_SM3_TXNFULL [7:7]     
       @ .equ IRQ1_INTS_SM2_TXNFULL [6:6]     
       @ .equ IRQ1_INTS_SM1_TXNFULL [5:5]     
       @ .equ IRQ1_INTS_SM0_TXNFULL [4:4]     
       @ .equ IRQ1_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ IRQ1_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ IRQ1_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ IRQ1_INTS_SM0_RXNEMPTY [0:0]     
 

@=========================== SIO ===========================@
.equ SIO_BASE, 0xd0000000 Single-cycle IO block  Provides core-local and inter-core hardware for the two processors, with single-cycle access.
    .equ SIO_CPUID, 0x0000 Processor core identifier  Value is 0 when read from processor core 0, and 1 when read from processor core 1.
 
    .equ SIO_GPIO_IN, 0x0004 Input value for GPIO pins
       @ .equ GPIO_IN_GPIO_IN [29:0]    Input value for GPIO0...29 
 
    .equ SIO_GPIO_HI_IN, 0x0008 Input value for QSPI pins
       @ .equ GPIO_HI_IN_GPIO_HI_IN [5:0]    Input value on QSPI IO in order 0..5: SCLK, SSn, SD0, SD1, SD2, SD3 
 
    .equ SIO_GPIO_OUT, 0x0010 GPIO output value
       @ .equ GPIO_OUT_GPIO_OUT [29:0]    Set output level 1/0 -> high/low for GPIO0...29.  Reading back gives the last value written, NOT the input value from the pins.  If core 0 and core 1 both write to GPIO_OUT simultaneously or to a SET/CLR/XOR alias,  the result is as though the write from core 0 took place first,  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_OUT_SET, 0x0014 GPIO output value set
       @ .equ GPIO_OUT_SET_GPIO_OUT_SET [29:0]    Perform an atomic bit-set on GPIO_OUT, i.e. `GPIO_OUT |= wdata` 
 
    .equ SIO_GPIO_OUT_CLR, 0x0018 GPIO output value clear
       @ .equ GPIO_OUT_CLR_GPIO_OUT_CLR [29:0]    Perform an atomic bit-clear on GPIO_OUT, i.e. `GPIO_OUT &= ~wdata` 
 
    .equ SIO_GPIO_OUT_XOR, 0x001c GPIO output value XOR
       @ .equ GPIO_OUT_XOR_GPIO_OUT_XOR [29:0]    Perform an atomic bitwise XOR on GPIO_OUT, i.e. `GPIO_OUT ^= wdata` 
 
    .equ SIO_GPIO_OE, 0x0020 GPIO output enable
       @ .equ GPIO_OE_GPIO_OE [29:0]    Set output enable 1/0 -> output/input for GPIO0...29.  Reading back gives the last value written.  If core 0 and core 1 both write to GPIO_OE simultaneously or to a SET/CLR/XOR alias,  the result is as though the write from core 0 took place first,  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_OE_SET, 0x0024 GPIO output enable set
       @ .equ GPIO_OE_SET_GPIO_OE_SET [29:0]    Perform an atomic bit-set on GPIO_OE, i.e. `GPIO_OE |= wdata` 
 
    .equ SIO_GPIO_OE_CLR, 0x0028 GPIO output enable clear
       @ .equ GPIO_OE_CLR_GPIO_OE_CLR [29:0]    Perform an atomic bit-clear on GPIO_OE, i.e. `GPIO_OE &= ~wdata` 
 
    .equ SIO_GPIO_OE_XOR, 0x002c GPIO output enable XOR
       @ .equ GPIO_OE_XOR_GPIO_OE_XOR [29:0]    Perform an atomic bitwise XOR on GPIO_OE, i.e. `GPIO_OE ^= wdata` 
 
    .equ SIO_GPIO_HI_OUT, 0x0030 QSPI output value
       @ .equ GPIO_HI_OUT_GPIO_HI_OUT [5:0]    Set output level 1/0 -> high/low for QSPI IO0...5.  Reading back gives the last value written, NOT the input value from the pins.  If core 0 and core 1 both write to GPIO_HI_OUT simultaneously or to a SET/CLR/XOR alias,  the result is as though the write from core 0 took place first,  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_HI_OUT_SET, 0x0034 QSPI output value set
       @ .equ GPIO_HI_OUT_SET_GPIO_HI_OUT_SET [5:0]    Perform an atomic bit-set on GPIO_HI_OUT, i.e. `GPIO_HI_OUT |= wdata` 
 
    .equ SIO_GPIO_HI_OUT_CLR, 0x0038 QSPI output value clear
       @ .equ GPIO_HI_OUT_CLR_GPIO_HI_OUT_CLR [5:0]    Perform an atomic bit-clear on GPIO_HI_OUT, i.e. `GPIO_HI_OUT &= ~wdata` 
 
    .equ SIO_GPIO_HI_OUT_XOR, 0x003c QSPI output value XOR
       @ .equ GPIO_HI_OUT_XOR_GPIO_HI_OUT_XOR [5:0]    Perform an atomic bitwise XOR on GPIO_HI_OUT, i.e. `GPIO_HI_OUT ^= wdata` 
 
    .equ SIO_GPIO_HI_OE, 0x0040 QSPI output enable
       @ .equ GPIO_HI_OE_GPIO_HI_OE [5:0]    Set output enable 1/0 -> output/input for QSPI IO0...5.  Reading back gives the last value written.  If core 0 and core 1 both write to GPIO_HI_OE simultaneously or to a SET/CLR/XOR alias,  the result is as though the write from core 0 took place first,  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_HI_OE_SET, 0x0044 QSPI output enable set
       @ .equ GPIO_HI_OE_SET_GPIO_HI_OE_SET [5:0]    Perform an atomic bit-set on GPIO_HI_OE, i.e. `GPIO_HI_OE |= wdata` 
 
    .equ SIO_GPIO_HI_OE_CLR, 0x0048 QSPI output enable clear
       @ .equ GPIO_HI_OE_CLR_GPIO_HI_OE_CLR [5:0]    Perform an atomic bit-clear on GPIO_HI_OE, i.e. `GPIO_HI_OE &= ~wdata` 
 
    .equ SIO_GPIO_HI_OE_XOR, 0x004c QSPI output enable XOR
       @ .equ GPIO_HI_OE_XOR_GPIO_HI_OE_XOR [5:0]    Perform an atomic bitwise XOR on GPIO_HI_OE, i.e. `GPIO_HI_OE ^= wdata` 
 
    .equ SIO_FIFO_ST, 0x0050 Status register for inter-core FIFOs mailboxes.  There is one FIFO in the core 0 -> core 1 direction, and one core 1 -> core 0. Both are 32 bits wide and 8 words deep.  Core 0 can see the read side of the 1->0 FIFO RX, and the write side of 0->1 FIFO TX.  Core 1 can see the read side of the 0->1 FIFO RX, and the write side of 1->0 FIFO TX.  The SIO IRQ for each core is the logical OR of the VLD, WOF and ROE fields of its FIFO_ST register.
       @ .equ FIFO_ST_ROE [3:3]    Sticky flag indicating the RX FIFO was read when empty. This read was ignored by the FIFO. 
       @ .equ FIFO_ST_WOF [2:2]    Sticky flag indicating the TX FIFO was written when full. This write was ignored by the FIFO. 
       @ .equ FIFO_ST_RDY [1:1]    Value is 1 if this core's TX FIFO is not full i.e. if FIFO_WR is ready for more data 
       @ .equ FIFO_ST_VLD [0:0]    Value is 1 if this core's RX FIFO is not empty i.e. if FIFO_RD is valid 
 
    .equ SIO_FIFO_WR, 0x0054 Write access to this core's TX FIFO
 
    .equ SIO_FIFO_RD, 0x0058 Read access to this core's RX FIFO
 
    .equ SIO_SPINLOCK_ST, 0x005c Spinlock state  A bitmap containing the state of all 32 spinlocks 1=locked.  Mainly intended for debugging.
 
    .equ SIO_DIV_UDIVIDEND, 0x0060 Divider unsigned dividend  Write to the DIVIDEND operand of the divider, i.e. the p in `p / q`.  Any operand write starts a new calculation. The results appear in QUOTIENT, REMAINDER.  UDIVIDEND/SDIVIDEND are aliases of the same internal register. The U alias starts an  unsigned calculation, and the S alias starts a signed calculation.
 
    .equ SIO_DIV_UDIVISOR, 0x0064 Divider unsigned divisor  Write to the DIVISOR operand of the divider, i.e. the q in `p / q`.  Any operand write starts a new calculation. The results appear in QUOTIENT, REMAINDER.  UDIVIDEND/SDIVIDEND are aliases of the same internal register. The U alias starts an  unsigned calculation, and the S alias starts a signed calculation.
 
    .equ SIO_DIV_SDIVIDEND, 0x0068 Divider signed dividend  The same as UDIVIDEND, but starts a signed calculation, rather than unsigned.
 
    .equ SIO_DIV_SDIVISOR, 0x006c Divider signed divisor  The same as UDIVISOR, but starts a signed calculation, rather than unsigned.
 
    .equ SIO_DIV_QUOTIENT, 0x0070 Divider result quotient  The result of `DIVIDEND / DIVISOR` division. Contents undefined while CSR_READY is low.  For signed calculations, QUOTIENT is negative when the signs of DIVIDEND and DIVISOR differ.  This register can be written to directly, for context save/restore purposes. This halts any  in-progress calculation and sets the CSR_READY and CSR_DIRTY flags.  Reading from QUOTIENT clears the CSR_DIRTY flag, so should read results in the order  REMAINDER, QUOTIENT if CSR_DIRTY is used.
 
    .equ SIO_DIV_REMAINDER, 0x0074 Divider result remainder  The result of `DIVIDEND % DIVISOR` modulo. Contents undefined while CSR_READY is low.  For signed calculations, REMAINDER is negative only when DIVIDEND is negative.  This register can be written to directly, for context save/restore purposes. This halts any  in-progress calculation and sets the CSR_READY and CSR_DIRTY flags.
 
    .equ SIO_DIV_CSR, 0x0078 Control and status register for divider.
       @ .equ DIV_CSR_DIRTY [1:1]    Changes to 1 when any register is written, and back to 0 when QUOTIENT is read.  Software can use this flag to make save/restore more efficient skip if not DIRTY.  If the flag is used in this way, it's recommended to either read QUOTIENT only,  or REMAINDER and then QUOTIENT, to prevent data loss on context switch. 
       @ .equ DIV_CSR_READY [0:0]    Reads as 0 when a calculation is in progress, 1 otherwise.  Writing an operand xDIVIDEND, xDIVISOR will immediately start a new calculation, no  matter if one is already in progress.  Writing to a result register will immediately terminate any in-progress calculation  and set the READY and DIRTY flags. 
 
    .equ SIO_INTERP0_ACCUM0, 0x0080 Read/write access to accumulator 0
 
    .equ SIO_INTERP0_ACCUM1, 0x0084 Read/write access to accumulator 1
 
    .equ SIO_INTERP0_BASE0, 0x0088 Read/write access to BASE0 register.
 
    .equ SIO_INTERP0_BASE1, 0x008c Read/write access to BASE1 register.
 
    .equ SIO_INTERP0_BASE2, 0x0090 Read/write access to BASE2 register.
 
    .equ SIO_INTERP0_POP_LANE0, 0x0094 Read LANE0 result, and simultaneously write lane results to both accumulators POP.
 
    .equ SIO_INTERP0_POP_LANE1, 0x0098 Read LANE1 result, and simultaneously write lane results to both accumulators POP.
 
    .equ SIO_INTERP0_POP_FULL, 0x009c Read FULL result, and simultaneously write lane results to both accumulators POP.
 
    .equ SIO_INTERP0_PEEK_LANE0, 0x00a0 Read LANE0 result, without altering any internal state PEEK.
 
    .equ SIO_INTERP0_PEEK_LANE1, 0x00a4 Read LANE1 result, without altering any internal state PEEK.
 
    .equ SIO_INTERP0_PEEK_FULL, 0x00a8 Read FULL result, without altering any internal state PEEK.
 
    .equ SIO_INTERP0_CTRL_LANE0, 0x00ac Control register for lane 0
       @ .equ INTERP0_CTRL_LANE0_OVERF [25:25]    Set if either OVERF0 or OVERF1 is set. 
       @ .equ INTERP0_CTRL_LANE0_OVERF1 [24:24]    Indicates if any masked-off MSBs in ACCUM1 are set. 
       @ .equ INTERP0_CTRL_LANE0_OVERF0 [23:23]    Indicates if any masked-off MSBs in ACCUM0 are set. 
       @ .equ INTERP0_CTRL_LANE0_BLEND [21:21]    Only present on INTERP0 on each core. If BLEND mode is enabled:  - LANE1 result is a linear interpolation between BASE0 and BASE1, controlled  by the 8 LSBs of lane 1 shift and mask value a fractional number between  0 and 255/256ths  - LANE0 result does not have BASE0 added yields only the 8 LSBs of lane 1 shift+mask value  - FULL result does not have lane 1 shift+mask value added BASE2 + lane 0 shift+mask  LANE1 SIGNED flag controls whether the interpolation is signed or unsigned. 
       @ .equ INTERP0_CTRL_LANE0_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence  of pointers into flash or SRAM. 
       @ .equ INTERP0_CTRL_LANE0_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE0 result. This does not affect FULL result. 
       @ .equ INTERP0_CTRL_LANE0_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ INTERP0_CTRL_LANE0_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ INTERP0_CTRL_LANE0_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits  before adding to BASE0, and LANE0 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ INTERP0_CTRL_LANE0_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ INTERP0_CTRL_LANE0_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ INTERP0_CTRL_LANE0_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP0_CTRL_LANE1, 0x00b0 Control register for lane 1
       @ .equ INTERP0_CTRL_LANE1_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence  of pointers into flash or SRAM. 
       @ .equ INTERP0_CTRL_LANE1_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE1 result. This does not affect FULL result. 
       @ .equ INTERP0_CTRL_LANE1_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ INTERP0_CTRL_LANE1_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ INTERP0_CTRL_LANE1_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits  before adding to BASE1, and LANE1 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ INTERP0_CTRL_LANE1_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ INTERP0_CTRL_LANE1_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ INTERP0_CTRL_LANE1_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP0_ACCUM0_ADD, 0x00b4 Values written here are atomically added to ACCUM0  Reading yields lane 0's raw shift and mask value BASE0 not added.
       @ .equ INTERP0_ACCUM0_ADD_INTERP0_ACCUM0_ADD [23:0]     
 
    .equ SIO_INTERP0_ACCUM1_ADD, 0x00b8 Values written here are atomically added to ACCUM1  Reading yields lane 1's raw shift and mask value BASE1 not added.
       @ .equ INTERP0_ACCUM1_ADD_INTERP0_ACCUM1_ADD [23:0]     
 
    .equ SIO_INTERP0_BASE_1AND0, 0x00bc On write, the lower 16 bits go to BASE0, upper bits to BASE1 simultaneously.  Each half is sign-extended to 32 bits if that lane's SIGNED flag is set.
 
    .equ SIO_INTERP1_ACCUM0, 0x00c0 Read/write access to accumulator 0
 
    .equ SIO_INTERP1_ACCUM1, 0x00c4 Read/write access to accumulator 1
 
    .equ SIO_INTERP1_BASE0, 0x00c8 Read/write access to BASE0 register.
 
    .equ SIO_INTERP1_BASE1, 0x00cc Read/write access to BASE1 register.
 
    .equ SIO_INTERP1_BASE2, 0x00d0 Read/write access to BASE2 register.
 
    .equ SIO_INTERP1_POP_LANE0, 0x00d4 Read LANE0 result, and simultaneously write lane results to both accumulators POP.
 
    .equ SIO_INTERP1_POP_LANE1, 0x00d8 Read LANE1 result, and simultaneously write lane results to both accumulators POP.
 
    .equ SIO_INTERP1_POP_FULL, 0x00dc Read FULL result, and simultaneously write lane results to both accumulators POP.
 
    .equ SIO_INTERP1_PEEK_LANE0, 0x00e0 Read LANE0 result, without altering any internal state PEEK.
 
    .equ SIO_INTERP1_PEEK_LANE1, 0x00e4 Read LANE1 result, without altering any internal state PEEK.
 
    .equ SIO_INTERP1_PEEK_FULL, 0x00e8 Read FULL result, without altering any internal state PEEK.
 
    .equ SIO_INTERP1_CTRL_LANE0, 0x00ec Control register for lane 0
       @ .equ INTERP1_CTRL_LANE0_OVERF [25:25]    Set if either OVERF0 or OVERF1 is set. 
       @ .equ INTERP1_CTRL_LANE0_OVERF1 [24:24]    Indicates if any masked-off MSBs in ACCUM1 are set. 
       @ .equ INTERP1_CTRL_LANE0_OVERF0 [23:23]    Indicates if any masked-off MSBs in ACCUM0 are set. 
       @ .equ INTERP1_CTRL_LANE0_CLAMP [22:22]    Only present on INTERP1 on each core. If CLAMP mode is enabled:  - LANE0 result is shifted and masked ACCUM0, clamped by a lower bound of  BASE0 and an upper bound of BASE1.  - Signedness of these comparisons is determined by LANE0_CTRL_SIGNED 
       @ .equ INTERP1_CTRL_LANE0_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence  of pointers into flash or SRAM. 
       @ .equ INTERP1_CTRL_LANE0_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE0 result. This does not affect FULL result. 
       @ .equ INTERP1_CTRL_LANE0_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ INTERP1_CTRL_LANE0_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ INTERP1_CTRL_LANE0_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits  before adding to BASE0, and LANE0 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ INTERP1_CTRL_LANE0_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ INTERP1_CTRL_LANE0_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ INTERP1_CTRL_LANE0_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP1_CTRL_LANE1, 0x00f0 Control register for lane 1
       @ .equ INTERP1_CTRL_LANE1_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence  of pointers into flash or SRAM. 
       @ .equ INTERP1_CTRL_LANE1_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE1 result. This does not affect FULL result. 
       @ .equ INTERP1_CTRL_LANE1_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ INTERP1_CTRL_LANE1_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ INTERP1_CTRL_LANE1_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits  before adding to BASE1, and LANE1 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ INTERP1_CTRL_LANE1_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ INTERP1_CTRL_LANE1_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ INTERP1_CTRL_LANE1_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP1_ACCUM0_ADD, 0x00f4 Values written here are atomically added to ACCUM0  Reading yields lane 0's raw shift and mask value BASE0 not added.
       @ .equ INTERP1_ACCUM0_ADD_INTERP1_ACCUM0_ADD [23:0]     
 
    .equ SIO_INTERP1_ACCUM1_ADD, 0x00f8 Values written here are atomically added to ACCUM1  Reading yields lane 1's raw shift and mask value BASE1 not added.
       @ .equ INTERP1_ACCUM1_ADD_INTERP1_ACCUM1_ADD [23:0]     
 
    .equ SIO_INTERP1_BASE_1AND0, 0x00fc On write, the lower 16 bits go to BASE0, upper bits to BASE1 simultaneously.  Each half is sign-extended to 32 bits if that lane's SIGNED flag is set.
 
    .equ SIO_SPINLOCK0, 0x0100 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK1, 0x0104 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK2, 0x0108 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK3, 0x010c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK4, 0x0110 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK5, 0x0114 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK6, 0x0118 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK7, 0x011c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK8, 0x0120 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK9, 0x0124 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK10, 0x0128 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK11, 0x012c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK12, 0x0130 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK13, 0x0134 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK14, 0x0138 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK15, 0x013c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK16, 0x0140 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK17, 0x0144 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK18, 0x0148 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK19, 0x014c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK20, 0x0150 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK21, 0x0154 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK22, 0x0158 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK23, 0x015c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK24, 0x0160 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK25, 0x0164 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK26, 0x0168 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK27, 0x016c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK28, 0x0170 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK29, 0x0174 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK30, 0x0178 Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 
    .equ SIO_SPINLOCK31, 0x017c Reading from a spinlock address will:  - Return 0 if lock is already locked  - Otherwise return nonzero, and simultaneously claim the lock  Writing any value releases the lock.  If core 0 and core 1 attempt to claim the same lock simultaneously, core 0 wins.  The value returned on success is 0x1 << lock number.
 

@=========================== PPB ===========================@
.equ PPB_BASE, 0xe0000000 
    .equ PPB_SYST_CSR, 0xe010 Use the SysTick Control and Status Register to enable the SysTick features.
       @ .equ SYST_CSR_COUNTFLAG [16:16]    Returns 1 if timer counted to 0 since last time this was read. Clears on read by application or debugger. 
       @ .equ SYST_CSR_CLKSOURCE [2:2]    SysTick clock source. Always reads as one if SYST_CALIB reports NOREF.  Selects the SysTick timer clock source:  0 = External reference clock.  1 = Processor clock. 
       @ .equ SYST_CSR_TICKINT [1:1]    Enables SysTick exception request:  0 = Counting down to zero does not assert the SysTick exception request.  1 = Counting down to zero to asserts the SysTick exception request. 
       @ .equ SYST_CSR_ENABLE [0:0]    Enable SysTick counter:  0 = Counter disabled.  1 = Counter enabled. 
 
    .equ PPB_SYST_RVR, 0xe014 Use the SysTick Reload Value Register to specify the start value to load into the current value register when the counter reaches 0. It can be any value between 0 and 0x00FFFFFF. A start value of 0 is possible, but has no effect because the SysTick interrupt and COUNTFLAG are activated when counting from 1 to 0. The reset value of this register is UNKNOWN.  To generate a multi-shot timer with a period of N processor clock cycles, use a RELOAD value of N-1. For example, if the SysTick interrupt is required every 100 clock pulses, set RELOAD to 99.
       @ .equ SYST_RVR_RELOAD [23:0]    Value to load into the SysTick Current Value Register when the counter reaches 0. 
 
    .equ PPB_SYST_CVR, 0xe018 Use the SysTick Current Value Register to find the current value in the register. The reset value of this register is UNKNOWN.
       @ .equ SYST_CVR_CURRENT [23:0]    Reads return the current value of the SysTick counter. This register is write-clear. Writing to it with any value clears the register to 0. Clearing this register also clears the COUNTFLAG bit of the SysTick Control and Status Register. 
 
    .equ PPB_SYST_CALIB, 0xe01c Use the SysTick Calibration Value Register to enable software to scale to any required speed using divide and multiply.
       @ .equ SYST_CALIB_NOREF [31:31]    If reads as 1, the Reference clock is not provided - the CLKSOURCE bit of the SysTick Control and Status register will be forced to 1 and cannot be cleared to 0. 
       @ .equ SYST_CALIB_SKEW [30:30]    If reads as 1, the calibration value for 10ms is inexact due to clock frequency. 
       @ .equ SYST_CALIB_TENMS [23:0]    An optional Reload value to be used for 10ms 100Hz timing, subject to system clock skew errors. If the value reads as 0, the calibration value is not known. 
 
    .equ PPB_NVIC_ISER, 0xe100 Use the Interrupt Set-Enable Register to enable interrupts and determine which interrupts are currently enabled.  If a pending interrupt is enabled, the NVIC activates the interrupt based on its priority. If an interrupt is not enabled, asserting its interrupt signal changes the interrupt state to pending, but the NVIC never activates the interrupt, regardless of its priority.
       @ .equ NVIC_ISER_SETENA [31:0]    Interrupt set-enable bits.  Write:  0 = No effect.  1 = Enable interrupt.  Read:  0 = Interrupt disabled.  1 = Interrupt enabled. 
 
    .equ PPB_NVIC_ICER, 0xe180 Use the Interrupt Clear-Enable Registers to disable interrupts and determine which interrupts are currently enabled.
       @ .equ NVIC_ICER_CLRENA [31:0]    Interrupt clear-enable bits.  Write:  0 = No effect.  1 = Disable interrupt.  Read:  0 = Interrupt disabled.  1 = Interrupt enabled. 
 
    .equ PPB_NVIC_ISPR, 0xe200 The NVIC_ISPR forces interrupts into the pending state, and shows which interrupts are pending.
       @ .equ NVIC_ISPR_SETPEND [31:0]    Interrupt set-pending bits.  Write:  0 = No effect.  1 = Changes interrupt state to pending.  Read:  0 = Interrupt is not pending.  1 = Interrupt is pending.  Note: Writing 1 to the NVIC_ISPR bit corresponding to:  An interrupt that is pending has no effect.  A disabled interrupt sets the state of that interrupt to pending. 
 
    .equ PPB_NVIC_ICPR, 0xe280 Use the Interrupt Clear-Pending Register to clear pending interrupts and determine which interrupts are currently pending.
       @ .equ NVIC_ICPR_CLRPEND [31:0]    Interrupt clear-pending bits.  Write:  0 = No effect.  1 = Removes pending state and interrupt.  Read:  0 = Interrupt is not pending.  1 = Interrupt is pending. 
 
    .equ PPB_NVIC_IPR0, 0xe400 Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.  Note: Writing 1 to an NVIC_ICPR bit does not affect the active state of the corresponding interrupt.  These registers are only word-accessible
       @ .equ NVIC_IPR0_IP_3 [31:30]    Priority of interrupt 3 
       @ .equ NVIC_IPR0_IP_2 [23:22]    Priority of interrupt 2 
       @ .equ NVIC_IPR0_IP_1 [15:14]    Priority of interrupt 1 
       @ .equ NVIC_IPR0_IP_0 [7:6]    Priority of interrupt 0 
 
    .equ PPB_NVIC_IPR1, 0xe404 Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR1_IP_7 [31:30]    Priority of interrupt 7 
       @ .equ NVIC_IPR1_IP_6 [23:22]    Priority of interrupt 6 
       @ .equ NVIC_IPR1_IP_5 [15:14]    Priority of interrupt 5 
       @ .equ NVIC_IPR1_IP_4 [7:6]    Priority of interrupt 4 
 
    .equ PPB_NVIC_IPR2, 0xe408 Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR2_IP_11 [31:30]    Priority of interrupt 11 
       @ .equ NVIC_IPR2_IP_10 [23:22]    Priority of interrupt 10 
       @ .equ NVIC_IPR2_IP_9 [15:14]    Priority of interrupt 9 
       @ .equ NVIC_IPR2_IP_8 [7:6]    Priority of interrupt 8 
 
    .equ PPB_NVIC_IPR3, 0xe40c Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR3_IP_15 [31:30]    Priority of interrupt 15 
       @ .equ NVIC_IPR3_IP_14 [23:22]    Priority of interrupt 14 
       @ .equ NVIC_IPR3_IP_13 [15:14]    Priority of interrupt 13 
       @ .equ NVIC_IPR3_IP_12 [7:6]    Priority of interrupt 12 
 
    .equ PPB_NVIC_IPR4, 0xe410 Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR4_IP_19 [31:30]    Priority of interrupt 19 
       @ .equ NVIC_IPR4_IP_18 [23:22]    Priority of interrupt 18 
       @ .equ NVIC_IPR4_IP_17 [15:14]    Priority of interrupt 17 
       @ .equ NVIC_IPR4_IP_16 [7:6]    Priority of interrupt 16 
 
    .equ PPB_NVIC_IPR5, 0xe414 Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR5_IP_23 [31:30]    Priority of interrupt 23 
       @ .equ NVIC_IPR5_IP_22 [23:22]    Priority of interrupt 22 
       @ .equ NVIC_IPR5_IP_21 [15:14]    Priority of interrupt 21 
       @ .equ NVIC_IPR5_IP_20 [7:6]    Priority of interrupt 20 
 
    .equ PPB_NVIC_IPR6, 0xe418 Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR6_IP_27 [31:30]    Priority of interrupt 27 
       @ .equ NVIC_IPR6_IP_26 [23:22]    Priority of interrupt 26 
       @ .equ NVIC_IPR6_IP_25 [15:14]    Priority of interrupt 25 
       @ .equ NVIC_IPR6_IP_24 [7:6]    Priority of interrupt 24 
 
    .equ PPB_NVIC_IPR7, 0xe41c Use the Interrupt Priority Registers to assign a priority from 0 to 3 to each of the available interrupts. 0 is the highest priority, and 3 is the lowest.
       @ .equ NVIC_IPR7_IP_31 [31:30]    Priority of interrupt 31 
       @ .equ NVIC_IPR7_IP_30 [23:22]    Priority of interrupt 30 
       @ .equ NVIC_IPR7_IP_29 [15:14]    Priority of interrupt 29 
       @ .equ NVIC_IPR7_IP_28 [7:6]    Priority of interrupt 28 
 
    .equ PPB_CPUID, 0xed00 Read the CPU ID Base Register to determine: the ID number of the processor core, the version number of the processor core, the implementation details of the processor core.
       @ .equ CPUID_IMPLEMENTER [31:24]    Implementor code: 0x41 = ARM 
       @ .equ CPUID_VARIANT [23:20]    Major revision number n in the rnpm revision status:  0x0 = Revision 0. 
       @ .equ CPUID_ARCHITECTURE [19:16]    Constant that defines the architecture of the processor:  0xC = ARMv6-M architecture. 
       @ .equ CPUID_PARTNO [15:4]    Number of processor within family: 0xC60 = Cortex-M0+ 
       @ .equ CPUID_REVISION [3:0]    Minor revision number m in the rnpm revision status:  0x1 = Patch 1. 
 
    .equ PPB_ICSR, 0xed04 Use the Interrupt Control State Register to set a pending Non-Maskable Interrupt NMI, set or clear a pending PendSV, set or clear a pending SysTick, check for pending exceptions, check the vector number of the highest priority pended exception, check the vector number of the active exception.
       @ .equ ICSR_NMIPENDSET [31:31]    Setting this bit will activate an NMI. Since NMI is the highest priority exception, it will activate as soon as it is registered.  NMI set-pending bit.  Write:  0 = No effect.  1 = Changes NMI exception state to pending.  Read:  0 = NMI exception is not pending.  1 = NMI exception is pending.  Because NMI is the highest-priority exception, normally the processor enters the NMI  exception handler as soon as it detects a write of 1 to this bit. Entering the handler then clears  this bit to 0. This means a read of this bit by the NMI exception handler returns 1 only if the  NMI signal is reasserted while the processor is executing that handler. 
       @ .equ ICSR_PENDSVSET [28:28]    PendSV set-pending bit.  Write:  0 = No effect.  1 = Changes PendSV exception state to pending.  Read:  0 = PendSV exception is not pending.  1 = PendSV exception is pending.  Writing 1 to this bit is the only way to set the PendSV exception state to pending. 
       @ .equ ICSR_PENDSVCLR [27:27]    PendSV clear-pending bit.  Write:  0 = No effect.  1 = Removes the pending state from the PendSV exception. 
       @ .equ ICSR_PENDSTSET [26:26]    SysTick exception set-pending bit.  Write:  0 = No effect.  1 = Changes SysTick exception state to pending.  Read:  0 = SysTick exception is not pending.  1 = SysTick exception is pending. 
       @ .equ ICSR_PENDSTCLR [25:25]    SysTick exception clear-pending bit.  Write:  0 = No effect.  1 = Removes the pending state from the SysTick exception.  This bit is WO. On a register read its value is Unknown. 
       @ .equ ICSR_ISRPREEMPT [23:23]    The system can only access this bit when the core is halted. It indicates that a pending interrupt is to be taken in the next running cycle. If C_MASKINTS is clear in the Debug Halting Control and Status Register, the interrupt is serviced. 
       @ .equ ICSR_ISRPENDING [22:22]    External interrupt pending flag 
       @ .equ ICSR_VECTPENDING [20:12]    Indicates the exception number for the highest priority pending exception: 0 = no pending exceptions. Non zero = The pending state includes the effect of memory-mapped enable and mask registers. It does not include the PRIMASK special-purpose register qualifier. 
       @ .equ ICSR_VECTACTIVE [8:0]    Active exception number field. Reset clears the VECTACTIVE field. 
 
    .equ PPB_VTOR, 0xed08 The VTOR holds the vector table offset address.
       @ .equ VTOR_TBLOFF [31:8]    Bits [31:8] of the indicate the vector table offset address. 
 
    .equ PPB_AIRCR, 0xed0c Use the Application Interrupt and Reset Control Register to: determine data endianness, clear all active state information from debug halt mode, request a system reset.
       @ .equ AIRCR_VECTKEY [31:16]    Register key:  Reads as Unknown  On writes, write 0x05FA to VECTKEY, otherwise the write is ignored. 
       @ .equ AIRCR_ENDIANESS [15:15]    Data endianness implemented:  0 = Little-endian. 
       @ .equ AIRCR_SYSRESETREQ [2:2]    Writing 1 to this bit causes the SYSRESETREQ signal to the outer system to be asserted to request a reset. The intention is to force a large system reset of all major components except for debug. The C_HALT bit in the DHCSR is cleared as a result of the system reset requested. The debugger does not lose contact with the device. 
       @ .equ AIRCR_VECTCLRACTIVE [1:1]    Clears all active state information for fixed and configurable exceptions. This bit: is self-clearing, can only be set by the DAP when the core is halted. When set: clears all active exception status of the processor, forces a return to Thread mode, forces an IPSR of 0. A debugger must re-initialize the stack. 
 
    .equ PPB_SCR, 0xed10 System Control Register. Use the System Control Register for power-management functions: signal to the system when the processor can enter a low power state, control how the processor enters and exits low power states.
       @ .equ SCR_SEVONPEND [4:4]    Send Event on Pending bit:  0 = Only enabled interrupts or events can wakeup the processor, disabled interrupts are excluded.  1 = Enabled events and all interrupts, including disabled interrupts, can wakeup the processor.  When an event or interrupt becomes pending, the event signal wakes up the processor from WFE. If the  processor is not waiting for an event, the event is registered and affects the next WFE.  The processor also wakes up on execution of an SEV instruction or an external event. 
       @ .equ SCR_SLEEPDEEP [2:2]    Controls whether the processor uses sleep or deep sleep as its low power mode:  0 = Sleep.  1 = Deep sleep. 
       @ .equ SCR_SLEEPONEXIT [1:1]    Indicates sleep-on-exit when returning from Handler mode to Thread mode:  0 = Do not sleep when returning to Thread mode.  1 = Enter sleep, or deep sleep, on return from an ISR to Thread mode.  Setting this bit to 1 enables an interrupt driven application to avoid returning to an empty main application. 
 
    .equ PPB_CCR, 0xed14 The Configuration and Control Register permanently enables stack alignment and causes unaligned accesses to result in a Hard Fault.
       @ .equ CCR_STKALIGN [9:9]    Always reads as one, indicates 8-byte stack alignment on exception entry. On exception entry, the processor uses bit[9] of the stacked PSR to indicate the stack alignment. On return from the exception it uses this stacked bit to restore the correct stack alignment. 
       @ .equ CCR_UNALIGN_TRP [3:3]    Always reads as one, indicates that all unaligned accesses generate a HardFault. 
 
    .equ PPB_SHPR2, 0xed1c System handlers are a special class of exception handler that can have their priority set to any of the priority levels. Use the System Handler Priority Register 2 to set the priority of SVCall.
       @ .equ SHPR2_PRI_11 [31:30]    Priority of system handler 11, SVCall 
 
    .equ PPB_SHPR3, 0xed20 System handlers are a special class of exception handler that can have their priority set to any of the priority levels. Use the System Handler Priority Register 3 to set the priority of PendSV and SysTick.
       @ .equ SHPR3_PRI_15 [31:30]    Priority of system handler 15, SysTick 
       @ .equ SHPR3_PRI_14 [23:22]    Priority of system handler 14, PendSV 
 
    .equ PPB_SHCSR, 0xed24 Use the System Handler Control and State Register to determine or clear the pending status of SVCall.
       @ .equ SHCSR_SVCALLPENDED [15:15]    Reads as 1 if SVCall is Pending. Write 1 to set pending SVCall, write 0 to clear pending SVCall. 
 
    .equ PPB_MPU_TYPE, 0xed90 Read the MPU Type Register to determine if the processor implements an MPU, and how many regions the MPU supports.
       @ .equ MPU_TYPE_IREGION [23:16]    Instruction region. Reads as zero as ARMv6-M only supports a unified MPU. 
       @ .equ MPU_TYPE_DREGION [15:8]    Number of regions supported by the MPU. 
       @ .equ MPU_TYPE_SEPARATE [0:0]    Indicates support for separate instruction and data address maps. Reads as 0 as ARMv6-M only supports a unified MPU. 
 
    .equ PPB_MPU_CTRL, 0xed94 Use the MPU Control Register to enable and disable the MPU, and to control whether the default memory map is enabled as a background region for privileged accesses, and whether the MPU is enabled for HardFaults and NMIs.
       @ .equ MPU_CTRL_PRIVDEFENA [2:2]    Controls whether the default memory map is enabled as a background region for privileged accesses. This bit is ignored when ENABLE is clear.  0 = If the MPU is enabled, disables use of the default memory map. Any memory access to a location not  covered by any enabled region causes a fault.  1 = If the MPU is enabled, enables use of the default memory map as a background region for privileged software accesses.  When enabled, the background region acts as if it is region number -1. Any region that is defined and enabled has priority over this default map. 
       @ .equ MPU_CTRL_HFNMIENA [1:1]    Controls the use of the MPU for HardFaults and NMIs. Setting this bit when ENABLE is clear results in UNPREDICTABLE behaviour.  When the MPU is enabled:  0 = MPU is disabled during HardFault and NMI handlers, regardless of the value of the ENABLE bit.  1 = the MPU is enabled during HardFault and NMI handlers. 
       @ .equ MPU_CTRL_ENABLE [0:0]    Enables the MPU. If the MPU is disabled, privileged and unprivileged accesses use the default memory map.  0 = MPU disabled.  1 = MPU enabled. 
 
    .equ PPB_MPU_RNR, 0xed98 Use the MPU Region Number Register to select the region currently accessed by MPU_RBAR and MPU_RASR.
       @ .equ MPU_RNR_REGION [3:0]    Indicates the MPU region referenced by the MPU_RBAR and MPU_RASR registers.  The MPU supports 8 memory regions, so the permitted values of this field are 0-7. 
 
    .equ PPB_MPU_RBAR, 0xed9c Read the MPU Region Base Address Register to determine the base address of the region identified by MPU_RNR. Write to update the base address of said region or that of a specified region, with whose number MPU_RNR will also be updated.
       @ .equ MPU_RBAR_ADDR [31:8]    Base address of the region. 
       @ .equ MPU_RBAR_VALID [4:4]    On writes, indicates whether the write must update the base address of the region identified by the REGION field, updating the MPU_RNR to indicate this new region.  Write:  0 = MPU_RNR not changed, and the processor:  Updates the base address for the region specified in the MPU_RNR.  Ignores the value of the REGION field.  1 = The processor:  Updates the value of the MPU_RNR to the value of the REGION field.  Updates the base address for the region specified in the REGION field.  Always reads as zero. 
       @ .equ MPU_RBAR_REGION [3:0]    On writes, specifies the number of the region whose base address to update provided VALID is set written as 1. On reads, returns bits [3:0] of MPU_RNR. 
 
    .equ PPB_MPU_RASR, 0xeda0 Use the MPU Region Attribute and Size Register to define the size, access behaviour and memory type of the region identified by MPU_RNR, and enable that region.
       @ .equ MPU_RASR_ATTRS [31:16]    The MPU Region Attribute field. Use to define the region attribute control.  28 = XN: Instruction access disable bit:  0 = Instruction fetches enabled.  1 = Instruction fetches disabled.  26:24 = AP: Access permission field  18 = S: Shareable bit  17 = C: Cacheable bit  16 = B: Bufferable bit 
       @ .equ MPU_RASR_SRD [15:8]    Subregion Disable. For regions of 256 bytes or larger, each bit of this field controls whether one of the eight equal subregions is enabled. 
       @ .equ MPU_RASR_SIZE [5:1]    Indicates the region size. Region size in bytes = 2^SIZE+1. The minimum permitted value is 7 b00111 = 256Bytes 
       @ .equ MPU_RASR_ENABLE [0:0]    Enables the region. 
 
