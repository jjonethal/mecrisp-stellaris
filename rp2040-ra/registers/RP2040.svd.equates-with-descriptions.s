@ arm-none-eabi-as equates file for RP2040
@ Equates Generator, Copyright Terry Porter 2017 "terry@tjporter.com.au" for RP2040 
@ Takes a CMSIS-SVD file plus a hand edited config.xml file as input 
@ MIT Licensed 


@=========================== XIP_CTRL ===========================@
.equ XIP_CTRL_BASE, 0x14000000 
    .equ XIP_CTRL_CTRL_OFFSET, 0x0000 
       @ .equ XIP_CTRL_CTRL_POWER_DOWN [3:3]    When 1, the cache memories are powered down. They retain state,\n  but can not be accessed. This reduces static power dissipation.\n  Writing 1 to this bit forces CTRL_EN to 0, i.e. the cache cannot\n  be enabled when powered down.\n  Cache-as-SRAM accesses will produce a bus error response when\n  the cache is powered down. 
       @ .equ XIP_CTRL_CTRL_ERR_BADWRITE [1:1]    When 1, writes to any alias other than 0x0 caching, allocating\n  will produce a bus fault. When 0, these writes are silently ignored.\n  In either case, writes to the 0x0 alias will deallocate on tag match,\n  as usual. 
       @ .equ XIP_CTRL_CTRL_EN [0:0]    When 1, enable the cache. When the cache is disabled, all XIP accesses\n  will go straight to the flash, without querying the cache. When enabled,\n  cacheable XIP accesses will query the cache, and the flash will\n  not be accessed if the tag matches and the valid bit is set.\n\n  If the cache is enabled, cache-as-SRAM accesses have no effect on the\n  cache data RAM, and will produce a bus error response. 
 
    .equ XIP_CTRL_FLUSH_OFFSET, 0x0004 
       @ .equ XIP_CTRL_FLUSH_FLUSH [0:0]    Write 1 to flush the cache. This clears the tag memory, but\n  the data memory retains its contents. This means cache-as-SRAM\n  contents is not affected by flush or reset.\n  Reading will hold the bus stall the processor until the flush\n  completes. Alternatively STAT can be polled until completion. 
 
    .equ XIP_CTRL_STAT_OFFSET, 0x0008 
       @ .equ XIP_CTRL_STAT_FIFO_FULL [2:2]    When 1, indicates the XIP streaming FIFO is completely full.\n  The streaming FIFO is 2 entries deep, so the full and empty\n  flag allow its level to be ascertained. 
       @ .equ XIP_CTRL_STAT_FIFO_EMPTY [1:1]    When 1, indicates the XIP streaming FIFO is completely empty. 
       @ .equ XIP_CTRL_STAT_FLUSH_READY [0:0]    Reads as 0 while a cache flush is in progress, and 1 otherwise.\n  The cache is flushed whenever the XIP block is reset, and also\n  when requested via the FLUSH register. 
 
    .equ XIP_CTRL_CTR_HIT_OFFSET, 0x000c 
 
    .equ XIP_CTRL_CTR_ACC_OFFSET, 0x0010 
 
    .equ XIP_CTRL_STREAM_ADDR_OFFSET, 0x0014 
       @ .equ XIP_CTRL_STREAM_ADDR_STREAM_ADDR [31:2]    The address of the next word to be streamed from flash to the streaming FIFO.\n  Increments automatically after each flash access.\n  Write the initial access address here before starting a streaming read. 
 
    .equ XIP_CTRL_STREAM_CTR_OFFSET, 0x0018 
       @ .equ XIP_CTRL_STREAM_CTR_STREAM_CTR [21:0]    Write a nonzero value to start a streaming read. This will then\n  progress in the background, using flash idle cycles to transfer\n  a linear data block from flash to the streaming FIFO.\n  Decrements automatically 1 at a time as the stream\n  progresses, and halts on reaching 0.\n  Write 0 to halt an in-progress stream, and discard any in-flight\n  read, so that a new stream can immediately be started after\n  draining the FIFO and reinitialising STREAM_ADDR 
 
    .equ XIP_CTRL_STREAM_FIFO_OFFSET, 0x001c 
 

@=========================== XIP_SSI ===========================@
.equ XIP_SSI_BASE, 0x18000000 
    .equ XIP_SSI_CTRLR0_OFFSET, 0x0000 
       @ .equ XIP_SSI_CTRLR0_SSTE [24:24]    Slave select toggle enable 
       @ .equ XIP_SSI_CTRLR0_SPI_FRF [22:21]    SPI frame format 
       @ .equ XIP_SSI_CTRLR0_DFS_32 [20:16]    Data frame size in 32b transfer mode\n  Value of n -> n+1 clocks per frame. 
       @ .equ XIP_SSI_CTRLR0_CFS [15:12]    Control frame size\n  Value of n -> n+1 clocks per frame. 
       @ .equ XIP_SSI_CTRLR0_SRL [11:11]    Shift register loop test mode 
       @ .equ XIP_SSI_CTRLR0_SLV_OE [10:10]    Slave output enable 
       @ .equ XIP_SSI_CTRLR0_TMOD [9:8]    Transfer mode 
       @ .equ XIP_SSI_CTRLR0_SCPOL [7:7]    Serial clock polarity 
       @ .equ XIP_SSI_CTRLR0_SCPH [6:6]    Serial clock phase 
       @ .equ XIP_SSI_CTRLR0_FRF [5:4]    Frame format 
       @ .equ XIP_SSI_CTRLR0_DFS [3:0]    Data frame size 
 
    .equ XIP_SSI_CTRLR1_OFFSET, 0x0004 
       @ .equ XIP_SSI_CTRLR1_NDF [15:0]    Number of data frames 
 
    .equ XIP_SSI_SSIENR_OFFSET, 0x0008 
       @ .equ XIP_SSI_SSIENR_SSI_EN [0:0]    SSI enable 
 
    .equ XIP_SSI_MWCR_OFFSET, 0x000c 
       @ .equ XIP_SSI_MWCR_MHS [2:2]    Microwire handshaking 
       @ .equ XIP_SSI_MWCR_MDD [1:1]    Microwire control 
       @ .equ XIP_SSI_MWCR_MWMOD [0:0]    Microwire transfer mode 
 
    .equ XIP_SSI_SER_OFFSET, 0x0010 
       @ .equ XIP_SSI_SER_SER [0:0]    For each bit:\n  0 -> slave not selected\n  1 -> slave selected 
 
    .equ XIP_SSI_BAUDR_OFFSET, 0x0014 
       @ .equ XIP_SSI_BAUDR_SCKDV [15:0]    SSI clock divider 
 
    .equ XIP_SSI_TXFTLR_OFFSET, 0x0018 
       @ .equ XIP_SSI_TXFTLR_TFT [7:0]    Transmit FIFO threshold 
 
    .equ XIP_SSI_RXFTLR_OFFSET, 0x001c 
       @ .equ XIP_SSI_RXFTLR_RFT [7:0]    Receive FIFO threshold 
 
    .equ XIP_SSI_TXFLR_OFFSET, 0x0020 
       @ .equ XIP_SSI_TXFLR_TFTFL [7:0]    Transmit FIFO level 
 
    .equ XIP_SSI_RXFLR_OFFSET, 0x0024 
       @ .equ XIP_SSI_RXFLR_RXTFL [7:0]    Receive FIFO level 
 
    .equ XIP_SSI_SR_OFFSET, 0x0028 
       @ .equ XIP_SSI_SR_DCOL [6:6]    Data collision error 
       @ .equ XIP_SSI_SR_TXE [5:5]    Transmission error 
       @ .equ XIP_SSI_SR_RFF [4:4]    Receive FIFO full 
       @ .equ XIP_SSI_SR_RFNE [3:3]    Receive FIFO not empty 
       @ .equ XIP_SSI_SR_TFE [2:2]    Transmit FIFO empty 
       @ .equ XIP_SSI_SR_TFNF [1:1]    Transmit FIFO not full 
       @ .equ XIP_SSI_SR_BUSY [0:0]    SSI busy flag 
 
    .equ XIP_SSI_IMR_OFFSET, 0x002c 
       @ .equ XIP_SSI_IMR_MSTIM [5:5]    Multi-master contention interrupt mask 
       @ .equ XIP_SSI_IMR_RXFIM [4:4]    Receive FIFO full interrupt mask 
       @ .equ XIP_SSI_IMR_RXOIM [3:3]    Receive FIFO overflow interrupt mask 
       @ .equ XIP_SSI_IMR_RXUIM [2:2]    Receive FIFO underflow interrupt mask 
       @ .equ XIP_SSI_IMR_TXOIM [1:1]    Transmit FIFO overflow interrupt mask 
       @ .equ XIP_SSI_IMR_TXEIM [0:0]    Transmit FIFO empty interrupt mask 
 
    .equ XIP_SSI_ISR_OFFSET, 0x0030 
       @ .equ XIP_SSI_ISR_MSTIS [5:5]    Multi-master contention interrupt status 
       @ .equ XIP_SSI_ISR_RXFIS [4:4]    Receive FIFO full interrupt status 
       @ .equ XIP_SSI_ISR_RXOIS [3:3]    Receive FIFO overflow interrupt status 
       @ .equ XIP_SSI_ISR_RXUIS [2:2]    Receive FIFO underflow interrupt status 
       @ .equ XIP_SSI_ISR_TXOIS [1:1]    Transmit FIFO overflow interrupt status 
       @ .equ XIP_SSI_ISR_TXEIS [0:0]    Transmit FIFO empty interrupt status 
 
    .equ XIP_SSI_RISR_OFFSET, 0x0034 
       @ .equ XIP_SSI_RISR_MSTIR [5:5]    Multi-master contention raw interrupt status 
       @ .equ XIP_SSI_RISR_RXFIR [4:4]    Receive FIFO full raw interrupt status 
       @ .equ XIP_SSI_RISR_RXOIR [3:3]    Receive FIFO overflow raw interrupt status 
       @ .equ XIP_SSI_RISR_RXUIR [2:2]    Receive FIFO underflow raw interrupt status 
       @ .equ XIP_SSI_RISR_TXOIR [1:1]    Transmit FIFO overflow raw interrupt status 
       @ .equ XIP_SSI_RISR_TXEIR [0:0]    Transmit FIFO empty raw interrupt status 
 
    .equ XIP_SSI_TXOICR_OFFSET, 0x0038 
       @ .equ XIP_SSI_TXOICR_TXOICR [0:0]    Clear-on-read transmit FIFO overflow interrupt 
 
    .equ XIP_SSI_RXOICR_OFFSET, 0x003c 
       @ .equ XIP_SSI_RXOICR_RXOICR [0:0]    Clear-on-read receive FIFO overflow interrupt 
 
    .equ XIP_SSI_RXUICR_OFFSET, 0x0040 
       @ .equ XIP_SSI_RXUICR_RXUICR [0:0]    Clear-on-read receive FIFO underflow interrupt 
 
    .equ XIP_SSI_MSTICR_OFFSET, 0x0044 
       @ .equ XIP_SSI_MSTICR_MSTICR [0:0]    Clear-on-read multi-master contention interrupt 
 
    .equ XIP_SSI_ICR_OFFSET, 0x0048 
       @ .equ XIP_SSI_ICR_ICR [0:0]    Clear-on-read all active interrupts 
 
    .equ XIP_SSI_DMACR_OFFSET, 0x004c 
       @ .equ XIP_SSI_DMACR_TDMAE [1:1]    Transmit DMA enable 
       @ .equ XIP_SSI_DMACR_RDMAE [0:0]    Receive DMA enable 
 
    .equ XIP_SSI_DMATDLR_OFFSET, 0x0050 
       @ .equ XIP_SSI_DMATDLR_DMATDL [7:0]    Transmit data watermark level 
 
    .equ XIP_SSI_DMARDLR_OFFSET, 0x0054 
       @ .equ XIP_SSI_DMARDLR_DMARDL [7:0]    Receive data watermark level DMARDLR+1 
 
    .equ XIP_SSI_IDR_OFFSET, 0x0058 
       @ .equ XIP_SSI_IDR_IDCODE [31:0]    Peripheral dentification code 
 
    .equ XIP_SSI_SSI_VERSION_ID_OFFSET, 0x005c 
       @ .equ XIP_SSI_SSI_VERSION_ID_SSI_COMP_VERSION [31:0]    SNPS component version format X.YY 
 
    .equ XIP_SSI_DR0_OFFSET, 0x0060 
       @ .equ XIP_SSI_DR0_DR [31:0]    First data register of 36 
 
    .equ XIP_SSI_RX_SAMPLE_DLY_OFFSET, 0x00f0 
       @ .equ XIP_SSI_RX_SAMPLE_DLY_RSD [7:0]    RXD sample delay in SCLK cycles 
 
    .equ XIP_SSI_SPI_CTRLR0_OFFSET, 0x00f4 
       @ .equ XIP_SSI_SPI_CTRLR0_XIP_CMD [31:24]    SPI Command to send in XIP mode INST_L = 8-bit or to append to Address INST_L = 0-bit 
       @ .equ XIP_SSI_SPI_CTRLR0_SPI_RXDS_EN [18:18]    Read data strobe enable 
       @ .equ XIP_SSI_SPI_CTRLR0_INST_DDR_EN [17:17]    Instruction DDR transfer enable 
       @ .equ XIP_SSI_SPI_CTRLR0_SPI_DDR_EN [16:16]    SPI DDR transfer enable 
       @ .equ XIP_SSI_SPI_CTRLR0_WAIT_CYCLES [15:11]    Wait cycles between control frame transmit and data reception in SCLK cycles 
       @ .equ XIP_SSI_SPI_CTRLR0_INST_L [9:8]    Instruction length 0/4/8/16b 
       @ .equ XIP_SSI_SPI_CTRLR0_ADDR_L [5:2]    Address length 0b-60b in 4b increments 
       @ .equ XIP_SSI_SPI_CTRLR0_TRANS_TYPE [1:0]    Address and instruction transfer format 
 
    .equ XIP_SSI_TXD_DRIVE_EDGE_OFFSET, 0x00f8 
       @ .equ XIP_SSI_TXD_DRIVE_EDGE_TDE [7:0]    TXD drive edge 
 

@=========================== SYSINFO ===========================@
.equ SYSINFO_BASE, 0x40000000 
    .equ SYSINFO_CHIP_ID_OFFSET, 0x0000 
       @ .equ SYSINFO_CHIP_ID_REVISION [31:28]     
       @ .equ SYSINFO_CHIP_ID_PART [27:12]     
       @ .equ SYSINFO_CHIP_ID_MANUFACTURER [11:0]     
 
    .equ SYSINFO_PLATFORM_OFFSET, 0x0004 
       @ .equ SYSINFO_PLATFORM_ASIC [1:1]     
       @ .equ SYSINFO_PLATFORM_FPGA [0:0]     
 
    .equ SYSINFO_GITREF_RP2040_OFFSET, 0x0040 
 

@=========================== SYSCFG ===========================@
.equ SYSCFG_BASE, 0x40004000 
    .equ SYSCFG_PROC0_NMI_MASK_OFFSET, 0x0000 
 
    .equ SYSCFG_PROC1_NMI_MASK_OFFSET, 0x0004 
 
    .equ SYSCFG_PROC_CONFIG_OFFSET, 0x0008 
       @ .equ SYSCFG_PROC_CONFIG_PROC1_DAP_INSTID [31:28]    Configure proc1 DAP instance ID.\n  Recommend that this is NOT changed until you require debug access in multi-chip environment\n  WARNING: do not set to 15 as this is reserved for RescueDP 
       @ .equ SYSCFG_PROC_CONFIG_PROC0_DAP_INSTID [27:24]    Configure proc0 DAP instance ID.\n  Recommend that this is NOT changed until you require debug access in multi-chip environment\n  WARNING: do not set to 15 as this is reserved for RescueDP 
       @ .equ SYSCFG_PROC_CONFIG_PROC1_HALTED [1:1]    Indication that proc1 has halted 
       @ .equ SYSCFG_PROC_CONFIG_PROC0_HALTED [0:0]    Indication that proc0 has halted 
 
    .equ SYSCFG_PROC_IN_SYNC_BYPASS_OFFSET, 0x000c 
       @ .equ SYSCFG_PROC_IN_SYNC_BYPASS_PROC_IN_SYNC_BYPASS [29:0]     
 
    .equ SYSCFG_PROC_IN_SYNC_BYPASS_HI_OFFSET, 0x0010 
       @ .equ SYSCFG_PROC_IN_SYNC_BYPASS_HI_PROC_IN_SYNC_BYPASS_HI [5:0]     
 
    .equ SYSCFG_DBGFORCE_OFFSET, 0x0014 
       @ .equ SYSCFG_DBGFORCE_PROC1_ATTACH [7:7]    Attach processor 1 debug port to syscfg controls, and disconnect it from external SWD pads. 
       @ .equ SYSCFG_DBGFORCE_PROC1_SWCLK [6:6]    Directly drive processor 1 SWCLK, if PROC1_ATTACH is set 
       @ .equ SYSCFG_DBGFORCE_PROC1_SWDI [5:5]    Directly drive processor 1 SWDIO input, if PROC1_ATTACH is set 
       @ .equ SYSCFG_DBGFORCE_PROC1_SWDO [4:4]    Observe the value of processor 1 SWDIO output. 
       @ .equ SYSCFG_DBGFORCE_PROC0_ATTACH [3:3]    Attach processor 0 debug port to syscfg controls, and disconnect it from external SWD pads. 
       @ .equ SYSCFG_DBGFORCE_PROC0_SWCLK [2:2]    Directly drive processor 0 SWCLK, if PROC0_ATTACH is set 
       @ .equ SYSCFG_DBGFORCE_PROC0_SWDI [1:1]    Directly drive processor 0 SWDIO input, if PROC0_ATTACH is set 
       @ .equ SYSCFG_DBGFORCE_PROC0_SWDO [0:0]    Observe the value of processor 0 SWDIO output. 
 
    .equ SYSCFG_MEMPOWERDOWN_OFFSET, 0x0018 
       @ .equ SYSCFG_MEMPOWERDOWN_ROM [7:7]     
       @ .equ SYSCFG_MEMPOWERDOWN_USB [6:6]     
       @ .equ SYSCFG_MEMPOWERDOWN_SRAM5 [5:5]     
       @ .equ SYSCFG_MEMPOWERDOWN_SRAM4 [4:4]     
       @ .equ SYSCFG_MEMPOWERDOWN_SRAM3 [3:3]     
       @ .equ SYSCFG_MEMPOWERDOWN_SRAM2 [2:2]     
       @ .equ SYSCFG_MEMPOWERDOWN_SRAM1 [1:1]     
       @ .equ SYSCFG_MEMPOWERDOWN_SRAM0 [0:0]     
 

@=========================== CLOCKS ===========================@
.equ CLOCKS_BASE, 0x40008000 
    .equ CLOCKS_CLK_GPOUT0_CTRL_OFFSET, 0x0000 
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT0_DIV_OFFSET, 0x0004 
       @ .equ CLOCKS_CLK_GPOUT0_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLOCKS_CLK_GPOUT0_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT0_SELECTED_OFFSET, 0x0008 
 
    .equ CLOCKS_CLK_GPOUT1_CTRL_OFFSET, 0x000c 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT1_DIV_OFFSET, 0x0010 
       @ .equ CLOCKS_CLK_GPOUT1_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLOCKS_CLK_GPOUT1_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT1_SELECTED_OFFSET, 0x0014 
 
    .equ CLOCKS_CLK_GPOUT2_CTRL_OFFSET, 0x0018 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT2_DIV_OFFSET, 0x001c 
       @ .equ CLOCKS_CLK_GPOUT2_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLOCKS_CLK_GPOUT2_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT2_SELECTED_OFFSET, 0x0020 
 
    .equ CLOCKS_CLK_GPOUT3_CTRL_OFFSET, 0x0024 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_DC50 [12:12]    Enables duty cycle correction for odd divisors 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_AUXSRC [8:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_GPOUT3_DIV_OFFSET, 0x0028 
       @ .equ CLOCKS_CLK_GPOUT3_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLOCKS_CLK_GPOUT3_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_GPOUT3_SELECTED_OFFSET, 0x002c 
 
    .equ CLOCKS_CLK_REF_CTRL_OFFSET, 0x0030 
       @ .equ CLOCKS_CLK_REF_CTRL_AUXSRC [6:5]    Selects the auxiliary clock source, will glitch when switching 
       @ .equ CLOCKS_CLK_REF_CTRL_SRC [1:0]    Selects the clock source glitchlessly, can be changed on-the-fly 
 
    .equ CLOCKS_CLK_REF_DIV_OFFSET, 0x0034 
       @ .equ CLOCKS_CLK_REF_DIV_INT [9:8]    Integer component of the divisor, 0 -> divide by 2^16 
 
    .equ CLOCKS_CLK_REF_SELECTED_OFFSET, 0x0038 
 
    .equ CLOCKS_CLK_SYS_CTRL_OFFSET, 0x003c 
       @ .equ CLOCKS_CLK_SYS_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
       @ .equ CLOCKS_CLK_SYS_CTRL_SRC [0:0]    Selects the clock source glitchlessly, can be changed on-the-fly 
 
    .equ CLOCKS_CLK_SYS_DIV_OFFSET, 0x0040 
       @ .equ CLOCKS_CLK_SYS_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLOCKS_CLK_SYS_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_SYS_SELECTED_OFFSET, 0x0044 
 
    .equ CLOCKS_CLK_PERI_CTRL_OFFSET, 0x0048 
       @ .equ CLOCKS_CLK_PERI_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_PERI_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_PERI_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_PERI_SELECTED_OFFSET, 0x0050 
 
    .equ CLOCKS_CLK_USB_CTRL_OFFSET, 0x0054 
       @ .equ CLOCKS_CLK_USB_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_USB_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_USB_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_USB_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_USB_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_USB_DIV_OFFSET, 0x0058 
       @ .equ CLOCKS_CLK_USB_DIV_INT [9:8]    Integer component of the divisor, 0 -> divide by 2^16 
 
    .equ CLOCKS_CLK_USB_SELECTED_OFFSET, 0x005c 
 
    .equ CLOCKS_CLK_ADC_CTRL_OFFSET, 0x0060 
       @ .equ CLOCKS_CLK_ADC_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_ADC_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_ADC_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_ADC_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_ADC_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_ADC_DIV_OFFSET, 0x0064 
       @ .equ CLOCKS_CLK_ADC_DIV_INT [9:8]    Integer component of the divisor, 0 -> divide by 2^16 
 
    .equ CLOCKS_CLK_ADC_SELECTED_OFFSET, 0x0068 
 
    .equ CLOCKS_CLK_RTC_CTRL_OFFSET, 0x006c 
       @ .equ CLOCKS_CLK_RTC_CTRL_NUDGE [20:20]    An edge on this signal shifts the phase of the output by 1 cycle of the input clock\n  This can be done at any time 
       @ .equ CLOCKS_CLK_RTC_CTRL_PHASE [17:16]    This delays the enable signal by up to 3 cycles of the input clock\n  This must be set before the clock is enabled to have any effect 
       @ .equ CLOCKS_CLK_RTC_CTRL_ENABLE [11:11]    Starts and stops the clock generator cleanly 
       @ .equ CLOCKS_CLK_RTC_CTRL_KILL [10:10]    Asynchronously kills the clock generator 
       @ .equ CLOCKS_CLK_RTC_CTRL_AUXSRC [7:5]    Selects the auxiliary clock source, will glitch when switching 
 
    .equ CLOCKS_CLK_RTC_DIV_OFFSET, 0x0070 
       @ .equ CLOCKS_CLK_RTC_DIV_INT [31:8]    Integer component of the divisor, 0 -> divide by 2^16 
       @ .equ CLOCKS_CLK_RTC_DIV_FRAC [7:0]    Fractional component of the divisor 
 
    .equ CLOCKS_CLK_RTC_SELECTED_OFFSET, 0x0074 
 
    .equ CLOCKS_CLK_SYS_RESUS_CTRL_OFFSET, 0x0078 
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_CLEAR [16:16]    For clearing the resus after the fault that triggered it has been corrected 
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_FRCE [12:12]    Force a resus, for test purposes only 
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_ENABLE [8:8]    Enable resus 
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_TIMEOUT [7:0]    This is expressed as a number of clk_ref cycles\n  and must be >= 2x clk_ref_freq/min_clk_tst_freq 
 
    .equ CLOCKS_CLK_SYS_RESUS_STATUS_OFFSET, 0x007c 
       @ .equ CLOCKS_CLK_SYS_RESUS_STATUS_RESUSSED [0:0]    Clock has been resuscitated, correct the error then send ctrl_clear=1 
 
    .equ CLOCKS_FC0_REF_KHZ_OFFSET, 0x0080 
       @ .equ CLOCKS_FC0_REF_KHZ_FC0_REF_KHZ [19:0]     
 
    .equ CLOCKS_FC0_MIN_KHZ_OFFSET, 0x0084 
       @ .equ CLOCKS_FC0_MIN_KHZ_FC0_MIN_KHZ [24:0]     
 
    .equ CLOCKS_FC0_MAX_KHZ_OFFSET, 0x0088 
       @ .equ CLOCKS_FC0_MAX_KHZ_FC0_MAX_KHZ [24:0]     
 
    .equ CLOCKS_FC0_DELAY_OFFSET, 0x008c 
       @ .equ CLOCKS_FC0_DELAY_FC0_DELAY [2:0]     
 
    .equ CLOCKS_FC0_INTERVAL_OFFSET, 0x0090 
       @ .equ CLOCKS_FC0_INTERVAL_FC0_INTERVAL [3:0]     
 
    .equ CLOCKS_FC0_SRC_OFFSET, 0x0094 
       @ .equ CLOCKS_FC0_SRC_FC0_SRC [7:0]     
 
    .equ CLOCKS_FC0_STATUS_OFFSET, 0x0098 
       @ .equ CLOCKS_FC0_STATUS_DIED [28:28]    Test clock stopped during test 
       @ .equ CLOCKS_FC0_STATUS_FAST [24:24]    Test clock faster than expected, only valid when status_done=1 
       @ .equ CLOCKS_FC0_STATUS_SLOW [20:20]    Test clock slower than expected, only valid when status_done=1 
       @ .equ CLOCKS_FC0_STATUS_FAIL [16:16]    Test failed 
       @ .equ CLOCKS_FC0_STATUS_WAITING [12:12]    Waiting for test clock to start 
       @ .equ CLOCKS_FC0_STATUS_RUNNING [8:8]    Test running 
       @ .equ CLOCKS_FC0_STATUS_DONE [4:4]    Test complete 
       @ .equ CLOCKS_FC0_STATUS_PASS [0:0]    Test passed 
 
    .equ CLOCKS_FC0_RESULT_OFFSET, 0x009c 
       @ .equ CLOCKS_FC0_RESULT_KHZ [29:5]     
       @ .equ CLOCKS_FC0_RESULT_FRAC [4:0]     
 
    .equ CLOCKS_WAKE_EN0_OFFSET, 0x00a0 
       @ .equ CLOCKS_WAKE_EN0_clk_sys_sram3 [31:31]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_sram2 [30:30]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_sram1 [29:29]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_sram0 [28:28]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_spi1 [27:27]     
       @ .equ CLOCKS_WAKE_EN0_clk_peri_spi1 [26:26]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_spi0 [25:25]     
       @ .equ CLOCKS_WAKE_EN0_clk_peri_spi0 [24:24]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_sio [23:23]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_rtc [22:22]     
       @ .equ CLOCKS_WAKE_EN0_clk_rtc_rtc [21:21]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_rosc [20:20]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_rom [19:19]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_resets [18:18]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_pwm [17:17]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_psm [16:16]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_pll_usb [15:15]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_pll_sys [14:14]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_pio1 [13:13]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_pio0 [12:12]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_pads [11:11]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_vreg_and_chip_reset [10:10]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_jtag [9:9]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_io [8:8]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_i2c1 [7:7]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_i2c0 [6:6]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_dma [5:5]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_busfabric [4:4]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_busctrl [3:3]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_adc [2:2]     
       @ .equ CLOCKS_WAKE_EN0_clk_adc_adc [1:1]     
       @ .equ CLOCKS_WAKE_EN0_clk_sys_clocks [0:0]     
 
    .equ CLOCKS_WAKE_EN1_OFFSET, 0x00a4 
       @ .equ CLOCKS_WAKE_EN1_clk_sys_xosc [14:14]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_xip [13:13]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_watchdog [12:12]     
       @ .equ CLOCKS_WAKE_EN1_clk_usb_usbctrl [11:11]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_usbctrl [10:10]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_uart1 [9:9]     
       @ .equ CLOCKS_WAKE_EN1_clk_peri_uart1 [8:8]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_uart0 [7:7]     
       @ .equ CLOCKS_WAKE_EN1_clk_peri_uart0 [6:6]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_timer [5:5]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_tbman [4:4]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_sysinfo [3:3]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_syscfg [2:2]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_sram5 [1:1]     
       @ .equ CLOCKS_WAKE_EN1_clk_sys_sram4 [0:0]     
 
    .equ CLOCKS_SLEEP_EN0_OFFSET, 0x00a8 
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_sram3 [31:31]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_sram2 [30:30]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_sram1 [29:29]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_sram0 [28:28]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_spi1 [27:27]     
       @ .equ CLOCKS_SLEEP_EN0_clk_peri_spi1 [26:26]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_spi0 [25:25]     
       @ .equ CLOCKS_SLEEP_EN0_clk_peri_spi0 [24:24]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_sio [23:23]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_rtc [22:22]     
       @ .equ CLOCKS_SLEEP_EN0_clk_rtc_rtc [21:21]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_rosc [20:20]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_rom [19:19]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_resets [18:18]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_pwm [17:17]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_psm [16:16]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_pll_usb [15:15]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_pll_sys [14:14]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_pio1 [13:13]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_pio0 [12:12]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_pads [11:11]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_vreg_and_chip_reset [10:10]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_jtag [9:9]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_io [8:8]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_i2c1 [7:7]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_i2c0 [6:6]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_dma [5:5]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_busfabric [4:4]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_busctrl [3:3]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_adc [2:2]     
       @ .equ CLOCKS_SLEEP_EN0_clk_adc_adc [1:1]     
       @ .equ CLOCKS_SLEEP_EN0_clk_sys_clocks [0:0]     
 
    .equ CLOCKS_SLEEP_EN1_OFFSET, 0x00ac 
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_xosc [14:14]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_xip [13:13]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_watchdog [12:12]     
       @ .equ CLOCKS_SLEEP_EN1_clk_usb_usbctrl [11:11]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_usbctrl [10:10]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_uart1 [9:9]     
       @ .equ CLOCKS_SLEEP_EN1_clk_peri_uart1 [8:8]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_uart0 [7:7]     
       @ .equ CLOCKS_SLEEP_EN1_clk_peri_uart0 [6:6]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_timer [5:5]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_tbman [4:4]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_sysinfo [3:3]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_syscfg [2:2]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_sram5 [1:1]     
       @ .equ CLOCKS_SLEEP_EN1_clk_sys_sram4 [0:0]     
 
    .equ CLOCKS_ENABLED0_OFFSET, 0x00b0 
       @ .equ CLOCKS_ENABLED0_clk_sys_sram3 [31:31]     
       @ .equ CLOCKS_ENABLED0_clk_sys_sram2 [30:30]     
       @ .equ CLOCKS_ENABLED0_clk_sys_sram1 [29:29]     
       @ .equ CLOCKS_ENABLED0_clk_sys_sram0 [28:28]     
       @ .equ CLOCKS_ENABLED0_clk_sys_spi1 [27:27]     
       @ .equ CLOCKS_ENABLED0_clk_peri_spi1 [26:26]     
       @ .equ CLOCKS_ENABLED0_clk_sys_spi0 [25:25]     
       @ .equ CLOCKS_ENABLED0_clk_peri_spi0 [24:24]     
       @ .equ CLOCKS_ENABLED0_clk_sys_sio [23:23]     
       @ .equ CLOCKS_ENABLED0_clk_sys_rtc [22:22]     
       @ .equ CLOCKS_ENABLED0_clk_rtc_rtc [21:21]     
       @ .equ CLOCKS_ENABLED0_clk_sys_rosc [20:20]     
       @ .equ CLOCKS_ENABLED0_clk_sys_rom [19:19]     
       @ .equ CLOCKS_ENABLED0_clk_sys_resets [18:18]     
       @ .equ CLOCKS_ENABLED0_clk_sys_pwm [17:17]     
       @ .equ CLOCKS_ENABLED0_clk_sys_psm [16:16]     
       @ .equ CLOCKS_ENABLED0_clk_sys_pll_usb [15:15]     
       @ .equ CLOCKS_ENABLED0_clk_sys_pll_sys [14:14]     
       @ .equ CLOCKS_ENABLED0_clk_sys_pio1 [13:13]     
       @ .equ CLOCKS_ENABLED0_clk_sys_pio0 [12:12]     
       @ .equ CLOCKS_ENABLED0_clk_sys_pads [11:11]     
       @ .equ CLOCKS_ENABLED0_clk_sys_vreg_and_chip_reset [10:10]     
       @ .equ CLOCKS_ENABLED0_clk_sys_jtag [9:9]     
       @ .equ CLOCKS_ENABLED0_clk_sys_io [8:8]     
       @ .equ CLOCKS_ENABLED0_clk_sys_i2c1 [7:7]     
       @ .equ CLOCKS_ENABLED0_clk_sys_i2c0 [6:6]     
       @ .equ CLOCKS_ENABLED0_clk_sys_dma [5:5]     
       @ .equ CLOCKS_ENABLED0_clk_sys_busfabric [4:4]     
       @ .equ CLOCKS_ENABLED0_clk_sys_busctrl [3:3]     
       @ .equ CLOCKS_ENABLED0_clk_sys_adc [2:2]     
       @ .equ CLOCKS_ENABLED0_clk_adc_adc [1:1]     
       @ .equ CLOCKS_ENABLED0_clk_sys_clocks [0:0]     
 
    .equ CLOCKS_ENABLED1_OFFSET, 0x00b4 
       @ .equ CLOCKS_ENABLED1_clk_sys_xosc [14:14]     
       @ .equ CLOCKS_ENABLED1_clk_sys_xip [13:13]     
       @ .equ CLOCKS_ENABLED1_clk_sys_watchdog [12:12]     
       @ .equ CLOCKS_ENABLED1_clk_usb_usbctrl [11:11]     
       @ .equ CLOCKS_ENABLED1_clk_sys_usbctrl [10:10]     
       @ .equ CLOCKS_ENABLED1_clk_sys_uart1 [9:9]     
       @ .equ CLOCKS_ENABLED1_clk_peri_uart1 [8:8]     
       @ .equ CLOCKS_ENABLED1_clk_sys_uart0 [7:7]     
       @ .equ CLOCKS_ENABLED1_clk_peri_uart0 [6:6]     
       @ .equ CLOCKS_ENABLED1_clk_sys_timer [5:5]     
       @ .equ CLOCKS_ENABLED1_clk_sys_tbman [4:4]     
       @ .equ CLOCKS_ENABLED1_clk_sys_sysinfo [3:3]     
       @ .equ CLOCKS_ENABLED1_clk_sys_syscfg [2:2]     
       @ .equ CLOCKS_ENABLED1_clk_sys_sram5 [1:1]     
       @ .equ CLOCKS_ENABLED1_clk_sys_sram4 [0:0]     
 
    .equ CLOCKS_INTR_OFFSET, 0x00b8 
       @ .equ CLOCKS_INTR_CLK_SYS_RESUS [0:0]     
 
    .equ CLOCKS_INTE_OFFSET, 0x00bc 
       @ .equ CLOCKS_INTE_CLK_SYS_RESUS [0:0]     
 
    .equ CLOCKS_INTF_OFFSET, 0x00c0 
       @ .equ CLOCKS_INTF_CLK_SYS_RESUS [0:0]     
 
    .equ CLOCKS_INTS_OFFSET, 0x00c4 
       @ .equ CLOCKS_INTS_CLK_SYS_RESUS [0:0]     
 

@=========================== RESETS ===========================@
.equ RESETS_BASE, 0x4000c000 
    .equ RESETS_RESET_OFFSET, 0x0000 
       @ .equ RESETS_RESET_usbctrl [24:24]     
       @ .equ RESETS_RESET_uart1 [23:23]     
       @ .equ RESETS_RESET_uart0 [22:22]     
       @ .equ RESETS_RESET_timer [21:21]     
       @ .equ RESETS_RESET_tbman [20:20]     
       @ .equ RESETS_RESET_sysinfo [19:19]     
       @ .equ RESETS_RESET_syscfg [18:18]     
       @ .equ RESETS_RESET_spi1 [17:17]     
       @ .equ RESETS_RESET_spi0 [16:16]     
       @ .equ RESETS_RESET_rtc [15:15]     
       @ .equ RESETS_RESET_pwm [14:14]     
       @ .equ RESETS_RESET_pll_usb [13:13]     
       @ .equ RESETS_RESET_pll_sys [12:12]     
       @ .equ RESETS_RESET_pio1 [11:11]     
       @ .equ RESETS_RESET_pio0 [10:10]     
       @ .equ RESETS_RESET_pads_qspi [9:9]     
       @ .equ RESETS_RESET_pads_bank0 [8:8]     
       @ .equ RESETS_RESET_jtag [7:7]     
       @ .equ RESETS_RESET_io_qspi [6:6]     
       @ .equ RESETS_RESET_io_bank0 [5:5]     
       @ .equ RESETS_RESET_i2c1 [4:4]     
       @ .equ RESETS_RESET_i2c0 [3:3]     
       @ .equ RESETS_RESET_dma [2:2]     
       @ .equ RESETS_RESET_busctrl [1:1]     
       @ .equ RESETS_RESET_adc [0:0]     
 
    .equ RESETS_WDSEL_OFFSET, 0x0004 
       @ .equ RESETS_WDSEL_usbctrl [24:24]     
       @ .equ RESETS_WDSEL_uart1 [23:23]     
       @ .equ RESETS_WDSEL_uart0 [22:22]     
       @ .equ RESETS_WDSEL_timer [21:21]     
       @ .equ RESETS_WDSEL_tbman [20:20]     
       @ .equ RESETS_WDSEL_sysinfo [19:19]     
       @ .equ RESETS_WDSEL_syscfg [18:18]     
       @ .equ RESETS_WDSEL_spi1 [17:17]     
       @ .equ RESETS_WDSEL_spi0 [16:16]     
       @ .equ RESETS_WDSEL_rtc [15:15]     
       @ .equ RESETS_WDSEL_pwm [14:14]     
       @ .equ RESETS_WDSEL_pll_usb [13:13]     
       @ .equ RESETS_WDSEL_pll_sys [12:12]     
       @ .equ RESETS_WDSEL_pio1 [11:11]     
       @ .equ RESETS_WDSEL_pio0 [10:10]     
       @ .equ RESETS_WDSEL_pads_qspi [9:9]     
       @ .equ RESETS_WDSEL_pads_bank0 [8:8]     
       @ .equ RESETS_WDSEL_jtag [7:7]     
       @ .equ RESETS_WDSEL_io_qspi [6:6]     
       @ .equ RESETS_WDSEL_io_bank0 [5:5]     
       @ .equ RESETS_WDSEL_i2c1 [4:4]     
       @ .equ RESETS_WDSEL_i2c0 [3:3]     
       @ .equ RESETS_WDSEL_dma [2:2]     
       @ .equ RESETS_WDSEL_busctrl [1:1]     
       @ .equ RESETS_WDSEL_adc [0:0]     
 
    .equ RESETS_RESET_DONE_OFFSET, 0x0008 
       @ .equ RESETS_RESET_DONE_usbctrl [24:24]     
       @ .equ RESETS_RESET_DONE_uart1 [23:23]     
       @ .equ RESETS_RESET_DONE_uart0 [22:22]     
       @ .equ RESETS_RESET_DONE_timer [21:21]     
       @ .equ RESETS_RESET_DONE_tbman [20:20]     
       @ .equ RESETS_RESET_DONE_sysinfo [19:19]     
       @ .equ RESETS_RESET_DONE_syscfg [18:18]     
       @ .equ RESETS_RESET_DONE_spi1 [17:17]     
       @ .equ RESETS_RESET_DONE_spi0 [16:16]     
       @ .equ RESETS_RESET_DONE_rtc [15:15]     
       @ .equ RESETS_RESET_DONE_pwm [14:14]     
       @ .equ RESETS_RESET_DONE_pll_usb [13:13]     
       @ .equ RESETS_RESET_DONE_pll_sys [12:12]     
       @ .equ RESETS_RESET_DONE_pio1 [11:11]     
       @ .equ RESETS_RESET_DONE_pio0 [10:10]     
       @ .equ RESETS_RESET_DONE_pads_qspi [9:9]     
       @ .equ RESETS_RESET_DONE_pads_bank0 [8:8]     
       @ .equ RESETS_RESET_DONE_jtag [7:7]     
       @ .equ RESETS_RESET_DONE_io_qspi [6:6]     
       @ .equ RESETS_RESET_DONE_io_bank0 [5:5]     
       @ .equ RESETS_RESET_DONE_i2c1 [4:4]     
       @ .equ RESETS_RESET_DONE_i2c0 [3:3]     
       @ .equ RESETS_RESET_DONE_dma [2:2]     
       @ .equ RESETS_RESET_DONE_busctrl [1:1]     
       @ .equ RESETS_RESET_DONE_adc [0:0]     
 

@=========================== PSM ===========================@
.equ PSM_BASE, 0x40010000 
    .equ PSM_FRCE_ON_OFFSET, 0x0000 
       @ .equ PSM_FRCE_ON_proc1 [16:16]     
       @ .equ PSM_FRCE_ON_proc0 [15:15]     
       @ .equ PSM_FRCE_ON_sio [14:14]     
       @ .equ PSM_FRCE_ON_vreg_and_chip_reset [13:13]     
       @ .equ PSM_FRCE_ON_xip [12:12]     
       @ .equ PSM_FRCE_ON_sram5 [11:11]     
       @ .equ PSM_FRCE_ON_sram4 [10:10]     
       @ .equ PSM_FRCE_ON_sram3 [9:9]     
       @ .equ PSM_FRCE_ON_sram2 [8:8]     
       @ .equ PSM_FRCE_ON_sram1 [7:7]     
       @ .equ PSM_FRCE_ON_sram0 [6:6]     
       @ .equ PSM_FRCE_ON_rom [5:5]     
       @ .equ PSM_FRCE_ON_busfabric [4:4]     
       @ .equ PSM_FRCE_ON_resets [3:3]     
       @ .equ PSM_FRCE_ON_clocks [2:2]     
       @ .equ PSM_FRCE_ON_xosc [1:1]     
       @ .equ PSM_FRCE_ON_rosc [0:0]     
 
    .equ PSM_FRCE_OFF_OFFSET, 0x0004 
       @ .equ PSM_FRCE_OFF_proc1 [16:16]     
       @ .equ PSM_FRCE_OFF_proc0 [15:15]     
       @ .equ PSM_FRCE_OFF_sio [14:14]     
       @ .equ PSM_FRCE_OFF_vreg_and_chip_reset [13:13]     
       @ .equ PSM_FRCE_OFF_xip [12:12]     
       @ .equ PSM_FRCE_OFF_sram5 [11:11]     
       @ .equ PSM_FRCE_OFF_sram4 [10:10]     
       @ .equ PSM_FRCE_OFF_sram3 [9:9]     
       @ .equ PSM_FRCE_OFF_sram2 [8:8]     
       @ .equ PSM_FRCE_OFF_sram1 [7:7]     
       @ .equ PSM_FRCE_OFF_sram0 [6:6]     
       @ .equ PSM_FRCE_OFF_rom [5:5]     
       @ .equ PSM_FRCE_OFF_busfabric [4:4]     
       @ .equ PSM_FRCE_OFF_resets [3:3]     
       @ .equ PSM_FRCE_OFF_clocks [2:2]     
       @ .equ PSM_FRCE_OFF_xosc [1:1]     
       @ .equ PSM_FRCE_OFF_rosc [0:0]     
 
    .equ PSM_WDSEL_OFFSET, 0x0008 
       @ .equ PSM_WDSEL_proc1 [16:16]     
       @ .equ PSM_WDSEL_proc0 [15:15]     
       @ .equ PSM_WDSEL_sio [14:14]     
       @ .equ PSM_WDSEL_vreg_and_chip_reset [13:13]     
       @ .equ PSM_WDSEL_xip [12:12]     
       @ .equ PSM_WDSEL_sram5 [11:11]     
       @ .equ PSM_WDSEL_sram4 [10:10]     
       @ .equ PSM_WDSEL_sram3 [9:9]     
       @ .equ PSM_WDSEL_sram2 [8:8]     
       @ .equ PSM_WDSEL_sram1 [7:7]     
       @ .equ PSM_WDSEL_sram0 [6:6]     
       @ .equ PSM_WDSEL_rom [5:5]     
       @ .equ PSM_WDSEL_busfabric [4:4]     
       @ .equ PSM_WDSEL_resets [3:3]     
       @ .equ PSM_WDSEL_clocks [2:2]     
       @ .equ PSM_WDSEL_xosc [1:1]     
       @ .equ PSM_WDSEL_rosc [0:0]     
 
    .equ PSM_DONE_OFFSET, 0x000c 
       @ .equ PSM_DONE_proc1 [16:16]     
       @ .equ PSM_DONE_proc0 [15:15]     
       @ .equ PSM_DONE_sio [14:14]     
       @ .equ PSM_DONE_vreg_and_chip_reset [13:13]     
       @ .equ PSM_DONE_xip [12:12]     
       @ .equ PSM_DONE_sram5 [11:11]     
       @ .equ PSM_DONE_sram4 [10:10]     
       @ .equ PSM_DONE_sram3 [9:9]     
       @ .equ PSM_DONE_sram2 [8:8]     
       @ .equ PSM_DONE_sram1 [7:7]     
       @ .equ PSM_DONE_sram0 [6:6]     
       @ .equ PSM_DONE_rom [5:5]     
       @ .equ PSM_DONE_busfabric [4:4]     
       @ .equ PSM_DONE_resets [3:3]     
       @ .equ PSM_DONE_clocks [2:2]     
       @ .equ PSM_DONE_xosc [1:1]     
       @ .equ PSM_DONE_rosc [0:0]     
 

@=========================== IO_BANK0 ===========================@
.equ IO_BANK0_BASE, 0x40014000 
    .equ IO_BANK0_GPIO0_STATUS_OFFSET, 0x0000 
       @ .equ IO_BANK0_GPIO0_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO0_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO0_CTRL_OFFSET, 0x0004 
       @ .equ IO_BANK0_GPIO0_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO0_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO0_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO0_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO0_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO1_STATUS_OFFSET, 0x0008 
       @ .equ IO_BANK0_GPIO1_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO1_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO1_CTRL_OFFSET, 0x000c 
       @ .equ IO_BANK0_GPIO1_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO1_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO1_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO1_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO1_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO2_STATUS_OFFSET, 0x0010 
       @ .equ IO_BANK0_GPIO2_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO2_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO2_CTRL_OFFSET, 0x0014 
       @ .equ IO_BANK0_GPIO2_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO2_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO2_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO2_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO2_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO3_STATUS_OFFSET, 0x0018 
       @ .equ IO_BANK0_GPIO3_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO3_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO3_CTRL_OFFSET, 0x001c 
       @ .equ IO_BANK0_GPIO3_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO3_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO3_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO3_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO3_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO4_STATUS_OFFSET, 0x0020 
       @ .equ IO_BANK0_GPIO4_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO4_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO4_CTRL_OFFSET, 0x0024 
       @ .equ IO_BANK0_GPIO4_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO4_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO4_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO4_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO4_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO5_STATUS_OFFSET, 0x0028 
       @ .equ IO_BANK0_GPIO5_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO5_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO5_CTRL_OFFSET, 0x002c 
       @ .equ IO_BANK0_GPIO5_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO5_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO5_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO5_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO5_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO6_STATUS_OFFSET, 0x0030 
       @ .equ IO_BANK0_GPIO6_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO6_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO6_CTRL_OFFSET, 0x0034 
       @ .equ IO_BANK0_GPIO6_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO6_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO6_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO6_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO6_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO7_STATUS_OFFSET, 0x0038 
       @ .equ IO_BANK0_GPIO7_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO7_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO7_CTRL_OFFSET, 0x003c 
       @ .equ IO_BANK0_GPIO7_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO7_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO7_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO7_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO7_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO8_STATUS_OFFSET, 0x0040 
       @ .equ IO_BANK0_GPIO8_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO8_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO8_CTRL_OFFSET, 0x0044 
       @ .equ IO_BANK0_GPIO8_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO8_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO8_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO8_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO8_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO9_STATUS_OFFSET, 0x0048 
       @ .equ IO_BANK0_GPIO9_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO9_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO9_CTRL_OFFSET, 0x004c 
       @ .equ IO_BANK0_GPIO9_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO9_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO9_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO9_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO9_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO10_STATUS_OFFSET, 0x0050 
       @ .equ IO_BANK0_GPIO10_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO10_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO10_CTRL_OFFSET, 0x0054 
       @ .equ IO_BANK0_GPIO10_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO10_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO10_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO10_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO10_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO11_STATUS_OFFSET, 0x0058 
       @ .equ IO_BANK0_GPIO11_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO11_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO11_CTRL_OFFSET, 0x005c 
       @ .equ IO_BANK0_GPIO11_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO11_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO11_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO11_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO11_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO12_STATUS_OFFSET, 0x0060 
       @ .equ IO_BANK0_GPIO12_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO12_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO12_CTRL_OFFSET, 0x0064 
       @ .equ IO_BANK0_GPIO12_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO12_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO12_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO12_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO12_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO13_STATUS_OFFSET, 0x0068 
       @ .equ IO_BANK0_GPIO13_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO13_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO13_CTRL_OFFSET, 0x006c 
       @ .equ IO_BANK0_GPIO13_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO13_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO13_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO13_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO13_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO14_STATUS_OFFSET, 0x0070 
       @ .equ IO_BANK0_GPIO14_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO14_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO14_CTRL_OFFSET, 0x0074 
       @ .equ IO_BANK0_GPIO14_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO14_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO14_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO14_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO14_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO15_STATUS_OFFSET, 0x0078 
       @ .equ IO_BANK0_GPIO15_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO15_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO15_CTRL_OFFSET, 0x007c 
       @ .equ IO_BANK0_GPIO15_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO15_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO15_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO15_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO15_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO16_STATUS_OFFSET, 0x0080 
       @ .equ IO_BANK0_GPIO16_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO16_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO16_CTRL_OFFSET, 0x0084 
       @ .equ IO_BANK0_GPIO16_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO16_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO16_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO16_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO16_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO17_STATUS_OFFSET, 0x0088 
       @ .equ IO_BANK0_GPIO17_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO17_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO17_CTRL_OFFSET, 0x008c 
       @ .equ IO_BANK0_GPIO17_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO17_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO17_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO17_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO17_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO18_STATUS_OFFSET, 0x0090 
       @ .equ IO_BANK0_GPIO18_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO18_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO18_CTRL_OFFSET, 0x0094 
       @ .equ IO_BANK0_GPIO18_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO18_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO18_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO18_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO18_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO19_STATUS_OFFSET, 0x0098 
       @ .equ IO_BANK0_GPIO19_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO19_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO19_CTRL_OFFSET, 0x009c 
       @ .equ IO_BANK0_GPIO19_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO19_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO19_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO19_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO19_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO20_STATUS_OFFSET, 0x00a0 
       @ .equ IO_BANK0_GPIO20_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO20_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO20_CTRL_OFFSET, 0x00a4 
       @ .equ IO_BANK0_GPIO20_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO20_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO20_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO20_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO20_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO21_STATUS_OFFSET, 0x00a8 
       @ .equ IO_BANK0_GPIO21_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO21_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO21_CTRL_OFFSET, 0x00ac 
       @ .equ IO_BANK0_GPIO21_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO21_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO21_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO21_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO21_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO22_STATUS_OFFSET, 0x00b0 
       @ .equ IO_BANK0_GPIO22_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO22_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO22_CTRL_OFFSET, 0x00b4 
       @ .equ IO_BANK0_GPIO22_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO22_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO22_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO22_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO22_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO23_STATUS_OFFSET, 0x00b8 
       @ .equ IO_BANK0_GPIO23_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO23_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO23_CTRL_OFFSET, 0x00bc 
       @ .equ IO_BANK0_GPIO23_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO23_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO23_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO23_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO23_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO24_STATUS_OFFSET, 0x00c0 
       @ .equ IO_BANK0_GPIO24_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO24_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO24_CTRL_OFFSET, 0x00c4 
       @ .equ IO_BANK0_GPIO24_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO24_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO24_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO24_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO24_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO25_STATUS_OFFSET, 0x00c8 
       @ .equ IO_BANK0_GPIO25_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO25_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO25_CTRL_OFFSET, 0x00cc 
       @ .equ IO_BANK0_GPIO25_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO25_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO25_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO25_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO25_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO26_STATUS_OFFSET, 0x00d0 
       @ .equ IO_BANK0_GPIO26_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO26_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO26_CTRL_OFFSET, 0x00d4 
       @ .equ IO_BANK0_GPIO26_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO26_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO26_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO26_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO26_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO27_STATUS_OFFSET, 0x00d8 
       @ .equ IO_BANK0_GPIO27_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO27_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO27_CTRL_OFFSET, 0x00dc 
       @ .equ IO_BANK0_GPIO27_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO27_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO27_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO27_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO27_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO28_STATUS_OFFSET, 0x00e0 
       @ .equ IO_BANK0_GPIO28_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO28_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO28_CTRL_OFFSET, 0x00e4 
       @ .equ IO_BANK0_GPIO28_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO28_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO28_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO28_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO28_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_GPIO29_STATUS_OFFSET, 0x00e8 
       @ .equ IO_BANK0_GPIO29_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_BANK0_GPIO29_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_BANK0_GPIO29_CTRL_OFFSET, 0x00ec 
       @ .equ IO_BANK0_GPIO29_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO29_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO29_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO29_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO29_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_BANK0_INTR0_OFFSET, 0x00f0 
       @ .equ IO_BANK0_INTR0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_INTR0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_INTR0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_INTR0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_INTR0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_INTR0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_INTR0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_INTR0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_INTR0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_INTR0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_INTR0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_INTR0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_INTR0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_INTR0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_INTR0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_INTR0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_INTR0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_INTR0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_INTR0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_INTR0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_INTR0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_INTR0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_INTR0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_INTR0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_INTR0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_INTR0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_INTR0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_INTR0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_INTR0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_INTR0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_INTR0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_INTR0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_INTR1_OFFSET, 0x00f4 
       @ .equ IO_BANK0_INTR1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_INTR1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_INTR1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_INTR1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_INTR1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_INTR1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_INTR1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_INTR1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_INTR1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_INTR1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_INTR1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_INTR1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_INTR1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_INTR1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_INTR1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_INTR1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_INTR1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_INTR1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_INTR1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_INTR1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_INTR1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_INTR1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_INTR1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_INTR1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_INTR1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_INTR1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_INTR1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_INTR1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_INTR1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_INTR1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_INTR1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_INTR1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_INTR2_OFFSET, 0x00f8 
       @ .equ IO_BANK0_INTR2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_INTR2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_INTR2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_INTR2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_INTR2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_INTR2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_INTR2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_INTR2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_INTR2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_INTR2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_INTR2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_INTR2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_INTR2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_INTR2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_INTR2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_INTR2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_INTR2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_INTR2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_INTR2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_INTR2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_INTR2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_INTR2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_INTR2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_INTR2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_INTR2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_INTR2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_INTR2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_INTR2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_INTR2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_INTR2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_INTR2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_INTR2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_INTR3_OFFSET, 0x00fc 
       @ .equ IO_BANK0_INTR3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_INTR3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_INTR3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_INTR3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_INTR3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_INTR3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_INTR3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_INTR3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_INTR3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_INTR3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_INTR3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_INTR3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_INTR3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_INTR3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_INTR3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_INTR3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_INTR3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_INTR3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_INTR3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_INTR3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_INTR3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_INTR3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_INTR3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_INTR3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE0_OFFSET, 0x0100 
       @ .equ IO_BANK0_PROC0_INTE0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTE0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE1_OFFSET, 0x0104 
       @ .equ IO_BANK0_PROC0_INTE1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTE1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE2_OFFSET, 0x0108 
       @ .equ IO_BANK0_PROC0_INTE2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTE2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTE3_OFFSET, 0x010c 
       @ .equ IO_BANK0_PROC0_INTE3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTE3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF0_OFFSET, 0x0110 
       @ .equ IO_BANK0_PROC0_INTF0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTF0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF1_OFFSET, 0x0114 
       @ .equ IO_BANK0_PROC0_INTF1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTF1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF2_OFFSET, 0x0118 
       @ .equ IO_BANK0_PROC0_INTF2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTF2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTF3_OFFSET, 0x011c 
       @ .equ IO_BANK0_PROC0_INTF3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTF3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS0_OFFSET, 0x0120 
       @ .equ IO_BANK0_PROC0_INTS0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTS0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS1_OFFSET, 0x0124 
       @ .equ IO_BANK0_PROC0_INTS1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTS1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS2_OFFSET, 0x0128 
       @ .equ IO_BANK0_PROC0_INTS2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTS2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC0_INTS3_OFFSET, 0x012c 
       @ .equ IO_BANK0_PROC0_INTS3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC0_INTS3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE0_OFFSET, 0x0130 
       @ .equ IO_BANK0_PROC1_INTE0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTE0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE1_OFFSET, 0x0134 
       @ .equ IO_BANK0_PROC1_INTE1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTE1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE2_OFFSET, 0x0138 
       @ .equ IO_BANK0_PROC1_INTE2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTE2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTE3_OFFSET, 0x013c 
       @ .equ IO_BANK0_PROC1_INTE3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTE3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF0_OFFSET, 0x0140 
       @ .equ IO_BANK0_PROC1_INTF0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTF0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF1_OFFSET, 0x0144 
       @ .equ IO_BANK0_PROC1_INTF1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTF1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF2_OFFSET, 0x0148 
       @ .equ IO_BANK0_PROC1_INTF2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTF2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTF3_OFFSET, 0x014c 
       @ .equ IO_BANK0_PROC1_INTF3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTF3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS0_OFFSET, 0x0150 
       @ .equ IO_BANK0_PROC1_INTS0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTS0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS1_OFFSET, 0x0154 
       @ .equ IO_BANK0_PROC1_INTS1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTS1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS2_OFFSET, 0x0158 
       @ .equ IO_BANK0_PROC1_INTS2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTS2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_PROC1_INTS3_OFFSET, 0x015c 
       @ .equ IO_BANK0_PROC1_INTS3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_PROC1_INTS3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE0_OFFSET, 0x0160 
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE1_OFFSET, 0x0164 
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE2_OFFSET, 0x0168 
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTE3_OFFSET, 0x016c 
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTE3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF0_OFFSET, 0x0170 
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF1_OFFSET, 0x0174 
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF2_OFFSET, 0x0178 
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTF3_OFFSET, 0x017c 
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTF3_GPIO24_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS0_OFFSET, 0x0180 
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO7_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO7_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO7_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO7_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO6_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO6_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO6_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO6_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO5_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO5_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO5_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO5_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO4_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO4_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO4_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO4_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO3_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO3_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO3_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO3_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO2_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO2_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO2_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO2_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO1_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO1_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO1_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO1_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO0_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO0_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO0_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS0_GPIO0_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS1_OFFSET, 0x0184 
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO15_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO15_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO15_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO15_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO14_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO14_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO14_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO14_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO13_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO13_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO13_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO13_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO12_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO12_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO12_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO12_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO11_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO11_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO11_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO11_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO10_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO10_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO10_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO10_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO9_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO9_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO9_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO9_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO8_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO8_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO8_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS1_GPIO8_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS2_OFFSET, 0x0188 
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO23_EDGE_HIGH [31:31]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO23_EDGE_LOW [30:30]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO23_LEVEL_HIGH [29:29]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO23_LEVEL_LOW [28:28]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO22_EDGE_HIGH [27:27]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO22_EDGE_LOW [26:26]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO22_LEVEL_HIGH [25:25]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO22_LEVEL_LOW [24:24]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO21_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO21_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO21_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO21_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO20_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO20_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO20_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO20_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO19_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO19_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO19_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO19_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO18_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO18_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO18_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO18_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO17_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO17_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO17_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO17_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO16_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO16_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO16_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS2_GPIO16_LEVEL_LOW [0:0]     
 
    .equ IO_BANK0_DORMANT_WAKE_INTS3_OFFSET, 0x018c 
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO29_EDGE_HIGH [23:23]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO29_EDGE_LOW [22:22]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO29_LEVEL_HIGH [21:21]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO29_LEVEL_LOW [20:20]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO28_EDGE_HIGH [19:19]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO28_EDGE_LOW [18:18]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO28_LEVEL_HIGH [17:17]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO28_LEVEL_LOW [16:16]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO27_EDGE_HIGH [15:15]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO27_EDGE_LOW [14:14]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO27_LEVEL_HIGH [13:13]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO27_LEVEL_LOW [12:12]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO26_EDGE_HIGH [11:11]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO26_EDGE_LOW [10:10]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO26_LEVEL_HIGH [9:9]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO26_LEVEL_LOW [8:8]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO25_EDGE_HIGH [7:7]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO25_EDGE_LOW [6:6]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO25_LEVEL_HIGH [5:5]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO25_LEVEL_LOW [4:4]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO24_EDGE_HIGH [3:3]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO24_EDGE_LOW [2:2]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO24_LEVEL_HIGH [1:1]     
       @ .equ IO_BANK0_DORMANT_WAKE_INTS3_GPIO24_LEVEL_LOW [0:0]     
 

@=========================== IO_QSPI ===========================@
.equ IO_QSPI_BASE, 0x40018000 
    .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OFFSET, 0x0000 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_OFFSET, 0x0004 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OFFSET, 0x0008 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SS_CTRL_OFFSET, 0x000c 
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OFFSET, 0x0010 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_OFFSET, 0x0014 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OFFSET, 0x0018 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_OFFSET, 0x001c 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OFFSET, 0x0020 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_OFFSET, 0x0024 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OFFSET, 0x0028 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_IRQTOPROC [26:26]    interrupt to processors, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_IRQFROMPAD [24:24]    interrupt from pad before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_INTOPERI [19:19]    input signal to peripheral, after override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_INFROMPAD [17:17]    input signal from pad, before override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OETOPAD [13:13]    output enable to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OEFROMPERI [12:12]    output enable from selected peripheral, before register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OUTTOPAD [9:9]    output signal to pad after register override is applied 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OUTFROMPERI [8:8]    output signal from selected peripheral, before register override is applied 
 
    .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_OFFSET, 0x002c 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_FUNCSEL [4:0]    0-31 -> selects pin function according to the gpio table\n  31 == NULL 
 
    .equ IO_QSPI_INTR_OFFSET, 0x0030 
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_INTR_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC0_INTE_OFFSET, 0x0034 
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_PROC0_INTE_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC0_INTF_OFFSET, 0x0038 
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_PROC0_INTF_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC0_INTS_OFFSET, 0x003c 
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_PROC0_INTS_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC1_INTE_OFFSET, 0x0040 
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_PROC1_INTE_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC1_INTF_OFFSET, 0x0044 
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_PROC1_INTF_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_PROC1_INTS_OFFSET, 0x0048 
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_PROC1_INTS_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_DORMANT_WAKE_INTE_OFFSET, 0x004c 
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTE_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_DORMANT_WAKE_INTF_OFFSET, 0x0050 
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTF_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 
    .equ IO_QSPI_DORMANT_WAKE_INTS_OFFSET, 0x0054 
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD3_EDGE_HIGH [23:23]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD3_EDGE_LOW [22:22]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD3_LEVEL_HIGH [21:21]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD3_LEVEL_LOW [20:20]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD2_EDGE_HIGH [19:19]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD2_EDGE_LOW [18:18]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD2_LEVEL_HIGH [17:17]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD2_LEVEL_LOW [16:16]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD1_EDGE_HIGH [15:15]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD1_EDGE_LOW [14:14]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD1_LEVEL_HIGH [13:13]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD1_LEVEL_LOW [12:12]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD0_EDGE_HIGH [11:11]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD0_EDGE_LOW [10:10]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD0_LEVEL_HIGH [9:9]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SD0_LEVEL_LOW [8:8]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SS_EDGE_HIGH [7:7]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SS_EDGE_LOW [6:6]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SS_LEVEL_HIGH [5:5]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SS_LEVEL_LOW [4:4]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_EDGE_HIGH [3:3]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_EDGE_LOW [2:2]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_LEVEL_HIGH [1:1]     
       @ .equ IO_QSPI_DORMANT_WAKE_INTS_GPIO_QSPI_SCLK_LEVEL_LOW [0:0]     
 

@=========================== PADS_BANK0 ===========================@
.equ PADS_BANK0_BASE, 0x4001c000 
    .equ PADS_BANK0_VOLTAGE_SELECT_OFFSET, 0x0000 
       @ .equ PADS_BANK0_VOLTAGE_SELECT_VOLTAGE_SELECT [0:0]     
 
    .equ PADS_BANK0_GPIO0_OFFSET, 0x0004 
       @ .equ PADS_BANK0_GPIO0_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO0_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO0_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO0_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO0_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO0_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO0_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO1_OFFSET, 0x0008 
       @ .equ PADS_BANK0_GPIO1_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO1_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO1_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO1_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO1_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO1_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO1_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO2_OFFSET, 0x000c 
       @ .equ PADS_BANK0_GPIO2_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO2_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO2_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO2_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO2_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO2_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO2_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO3_OFFSET, 0x0010 
       @ .equ PADS_BANK0_GPIO3_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO3_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO3_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO3_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO3_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO3_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO3_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO4_OFFSET, 0x0014 
       @ .equ PADS_BANK0_GPIO4_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO4_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO4_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO4_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO4_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO4_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO4_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO5_OFFSET, 0x0018 
       @ .equ PADS_BANK0_GPIO5_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO5_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO5_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO5_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO5_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO5_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO5_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO6_OFFSET, 0x001c 
       @ .equ PADS_BANK0_GPIO6_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO6_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO6_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO6_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO6_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO6_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO6_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO7_OFFSET, 0x0020 
       @ .equ PADS_BANK0_GPIO7_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO7_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO7_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO7_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO7_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO7_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO7_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO8_OFFSET, 0x0024 
       @ .equ PADS_BANK0_GPIO8_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO8_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO8_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO8_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO8_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO8_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO8_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO9_OFFSET, 0x0028 
       @ .equ PADS_BANK0_GPIO9_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO9_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO9_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO9_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO9_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO9_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO9_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO10_OFFSET, 0x002c 
       @ .equ PADS_BANK0_GPIO10_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO10_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO10_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO10_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO10_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO10_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO10_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO11_OFFSET, 0x0030 
       @ .equ PADS_BANK0_GPIO11_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO11_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO11_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO11_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO11_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO11_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO11_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO12_OFFSET, 0x0034 
       @ .equ PADS_BANK0_GPIO12_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO12_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO12_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO12_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO12_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO12_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO12_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO13_OFFSET, 0x0038 
       @ .equ PADS_BANK0_GPIO13_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO13_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO13_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO13_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO13_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO13_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO13_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO14_OFFSET, 0x003c 
       @ .equ PADS_BANK0_GPIO14_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO14_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO14_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO14_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO14_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO14_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO14_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO15_OFFSET, 0x0040 
       @ .equ PADS_BANK0_GPIO15_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO15_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO15_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO15_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO15_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO15_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO15_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO16_OFFSET, 0x0044 
       @ .equ PADS_BANK0_GPIO16_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO16_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO16_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO16_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO16_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO16_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO16_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO17_OFFSET, 0x0048 
       @ .equ PADS_BANK0_GPIO17_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO17_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO17_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO17_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO17_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO17_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO17_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO18_OFFSET, 0x004c 
       @ .equ PADS_BANK0_GPIO18_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO18_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO18_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO18_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO18_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO18_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO18_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO19_OFFSET, 0x0050 
       @ .equ PADS_BANK0_GPIO19_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO19_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO19_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO19_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO19_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO19_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO19_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO20_OFFSET, 0x0054 
       @ .equ PADS_BANK0_GPIO20_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO20_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO20_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO20_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO20_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO20_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO20_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO21_OFFSET, 0x0058 
       @ .equ PADS_BANK0_GPIO21_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO21_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO21_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO21_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO21_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO21_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO21_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO22_OFFSET, 0x005c 
       @ .equ PADS_BANK0_GPIO22_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO22_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO22_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO22_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO22_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO22_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO22_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO23_OFFSET, 0x0060 
       @ .equ PADS_BANK0_GPIO23_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO23_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO23_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO23_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO23_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO23_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO23_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO24_OFFSET, 0x0064 
       @ .equ PADS_BANK0_GPIO24_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO24_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO24_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO24_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO24_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO24_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO24_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO25_OFFSET, 0x0068 
       @ .equ PADS_BANK0_GPIO25_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO25_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO25_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO25_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO25_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO25_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO25_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO26_OFFSET, 0x006c 
       @ .equ PADS_BANK0_GPIO26_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO26_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO26_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO26_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO26_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO26_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO26_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO27_OFFSET, 0x0070 
       @ .equ PADS_BANK0_GPIO27_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO27_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO27_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO27_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO27_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO27_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO27_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO28_OFFSET, 0x0074 
       @ .equ PADS_BANK0_GPIO28_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO28_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO28_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO28_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO28_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO28_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO28_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_GPIO29_OFFSET, 0x0078 
       @ .equ PADS_BANK0_GPIO29_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_GPIO29_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_GPIO29_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_GPIO29_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_GPIO29_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_GPIO29_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_GPIO29_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_SWCLK_OFFSET, 0x007c 
       @ .equ PADS_BANK0_SWCLK_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_SWCLK_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_SWCLK_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_SWCLK_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_SWCLK_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_SWCLK_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_SWCLK_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_BANK0_SWD_OFFSET, 0x0080 
       @ .equ PADS_BANK0_SWD_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_BANK0_SWD_IE [6:6]    Input enable 
       @ .equ PADS_BANK0_SWD_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_BANK0_SWD_PUE [3:3]    Pull up enable 
       @ .equ PADS_BANK0_SWD_PDE [2:2]    Pull down enable 
       @ .equ PADS_BANK0_SWD_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_BANK0_SWD_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 

@=========================== PADS_QSPI ===========================@
.equ PADS_QSPI_BASE, 0x40020000 
    .equ PADS_QSPI_VOLTAGE_SELECT_OFFSET, 0x0000 
       @ .equ PADS_QSPI_VOLTAGE_SELECT_VOLTAGE_SELECT [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SCLK_OFFSET, 0x0004 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_IE [6:6]    Input enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_PUE [3:3]    Pull up enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_PDE [2:2]    Pull down enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD0_OFFSET, 0x0008 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_IE [6:6]    Input enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_PUE [3:3]    Pull up enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_PDE [2:2]    Pull down enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD1_OFFSET, 0x000c 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_IE [6:6]    Input enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_PUE [3:3]    Pull up enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_PDE [2:2]    Pull down enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD2_OFFSET, 0x0010 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_IE [6:6]    Input enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_PUE [3:3]    Pull up enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_PDE [2:2]    Pull down enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SD3_OFFSET, 0x0014 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_IE [6:6]    Input enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_PUE [3:3]    Pull up enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_PDE [2:2]    Pull down enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 
    .equ PADS_QSPI_GPIO_QSPI_SS_OFFSET, 0x0018 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_OD [7:7]    Output disable. Has priority over output enable from peripherals 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_IE [6:6]    Input enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_DRIVE [5:4]    Drive strength. 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_PUE [3:3]    Pull up enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_PDE [2:2]    Pull down enable 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_SCHMITT [1:1]    Enable schmitt trigger 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_SLEWFAST [0:0]    Slew rate control. 1 = Fast, 0 = Slow 
 

@=========================== XOSC ===========================@
.equ XOSC_BASE, 0x40024000 
    .equ XOSC_CTRL_OFFSET, 0x0000 
       @ .equ XOSC_CTRL_ENABLE [23:12]    On power-up this field is initialised to DISABLE and the chip runs from the ROSC.\n  If the chip has subsequently been programmed to run from the XOSC then setting this field to DISABLE may lock-up the chip. If this is a concern then run the clk_ref from the ROSC and enable the clk_sys RESUS feature.\n  The 12-bit code is intended to give some protection against accidental writes. An invalid setting will enable the oscillator. 
       @ .equ XOSC_CTRL_FREQ_RANGE [11:0]    Frequency range. This resets to 0xAA0 and cannot be changed. 
 
    .equ XOSC_STATUS_OFFSET, 0x0004 
       @ .equ XOSC_STATUS_STABLE [31:31]    Oscillator is running and stable 
       @ .equ XOSC_STATUS_BADWRITE [24:24]    An invalid value has been written to CTRL_ENABLE or CTRL_FREQ_RANGE or DORMANT 
       @ .equ XOSC_STATUS_ENABLED [12:12]    Oscillator is enabled but not necessarily running and stable, resets to 0 
       @ .equ XOSC_STATUS_FREQ_RANGE [1:0]    The current frequency range setting, always reads 0 
 
    .equ XOSC_DORMANT_OFFSET, 0x0008 
 
    .equ XOSC_STARTUP_OFFSET, 0x000c 
       @ .equ XOSC_STARTUP_X4 [20:20]    Multiplies the startup_delay by 4. This is of little value to the user given that the delay can be programmed directly 
       @ .equ XOSC_STARTUP_DELAY [13:0]    in multiples of 256*xtal_period 
 
    .equ XOSC_COUNT_OFFSET, 0x001c 
       @ .equ XOSC_COUNT_COUNT [7:0]     
 

@=========================== PLL_SYS ===========================@
.equ PLL_SYS_BASE, 0x40028000 
    .equ PLL_SYS_CS_OFFSET, 0x0000 
       @ .equ PLL_SYS_CS_LOCK [31:31]    PLL is locked 
       @ .equ PLL_SYS_CS_BYPASS [8:8]    Passes the reference clock to the output instead of the divided VCO. The VCO continues to run so the user can switch between the reference clock and the divided VCO but the output will glitch when doing so. 
       @ .equ PLL_SYS_CS_REFDIV [5:0]    Divides the PLL input reference clock.\n  Behaviour is undefined for div=0.\n  PLL output will be unpredictable during refdiv changes, wait for lock=1 before using it. 
 
    .equ PLL_SYS_PWR_OFFSET, 0x0004 
       @ .equ PLL_SYS_PWR_VCOPD [5:5]    PLL VCO powerdown\n  To save power set high when PLL output not required or bypass=1. 
       @ .equ PLL_SYS_PWR_POSTDIVPD [3:3]    PLL post divider powerdown\n  To save power set high when PLL output not required or bypass=1. 
       @ .equ PLL_SYS_PWR_DSMPD [2:2]    PLL DSM powerdown\n  Nothing is achieved by setting this low. 
       @ .equ PLL_SYS_PWR_PD [0:0]    PLL powerdown\n  To save power set high when PLL output not required. 
 
    .equ PLL_SYS_FBDIV_INT_OFFSET, 0x0008 
       @ .equ PLL_SYS_FBDIV_INT_FBDIV_INT [11:0]    see ctrl reg description for constraints 
 
    .equ PLL_SYS_PRIM_OFFSET, 0x000c 
       @ .equ PLL_SYS_PRIM_POSTDIV1 [18:16]    divide by 1-7 
       @ .equ PLL_SYS_PRIM_POSTDIV2 [14:12]    divide by 1-7 
 

@=========================== PLL_USB ===========================@
.equ PLL_USB_BASE, 0x4002c000 
    .equ PLL_USB_CS_OFFSET, 0x0000 
       @ .equ PLL_USB_CS_LOCK [31:31]    PLL is locked 
       @ .equ PLL_USB_CS_BYPASS [8:8]    Passes the reference clock to the output instead of the divided VCO. The VCO continues to run so the user can switch between the reference clock and the divided VCO but the output will glitch when doing so. 
       @ .equ PLL_USB_CS_REFDIV [5:0]    Divides the PLL input reference clock.\n  Behaviour is undefined for div=0.\n  PLL output will be unpredictable during refdiv changes, wait for lock=1 before using it. 
 
    .equ PLL_USB_PWR_OFFSET, 0x0004 
       @ .equ PLL_USB_PWR_VCOPD [5:5]    PLL VCO powerdown\n  To save power set high when PLL output not required or bypass=1. 
       @ .equ PLL_USB_PWR_POSTDIVPD [3:3]    PLL post divider powerdown\n  To save power set high when PLL output not required or bypass=1. 
       @ .equ PLL_USB_PWR_DSMPD [2:2]    PLL DSM powerdown\n  Nothing is achieved by setting this low. 
       @ .equ PLL_USB_PWR_PD [0:0]    PLL powerdown\n  To save power set high when PLL output not required. 
 
    .equ PLL_USB_FBDIV_INT_OFFSET, 0x0008 
       @ .equ PLL_USB_FBDIV_INT_FBDIV_INT [11:0]    see ctrl reg description for constraints 
 
    .equ PLL_USB_PRIM_OFFSET, 0x000c 
       @ .equ PLL_USB_PRIM_POSTDIV1 [18:16]    divide by 1-7 
       @ .equ PLL_USB_PRIM_POSTDIV2 [14:12]    divide by 1-7 
 

@=========================== BUSCTRL ===========================@
.equ BUSCTRL_BASE, 0x40030000 
    .equ BUSCTRL_BUS_PRIORITY_OFFSET, 0x0000 
       @ .equ BUSCTRL_BUS_PRIORITY_DMA_W [12:12]    0 - low priority, 1 - high priority 
       @ .equ BUSCTRL_BUS_PRIORITY_DMA_R [8:8]    0 - low priority, 1 - high priority 
       @ .equ BUSCTRL_BUS_PRIORITY_PROC1 [4:4]    0 - low priority, 1 - high priority 
       @ .equ BUSCTRL_BUS_PRIORITY_PROC0 [0:0]    0 - low priority, 1 - high priority 
 
    .equ BUSCTRL_BUS_PRIORITY_ACK_OFFSET, 0x0004 
       @ .equ BUSCTRL_BUS_PRIORITY_ACK_BUS_PRIORITY_ACK [0:0]    Goes to 1 once all arbiters have registered the new global priority levels.\n  Arbiters update their local priority when servicing a new nonsequential access.\n  In normal circumstances this will happen almost immediately. 
 
    .equ BUSCTRL_PERFCTR0_OFFSET, 0x0008 
       @ .equ BUSCTRL_PERFCTR0_PERFCTR0 [23:0]    Busfabric saturating performance counter 0\n  Count some event signal from the busfabric arbiters.\n  Write any value to clear. Select an event to count using PERFSEL0 
 
    .equ BUSCTRL_PERFSEL0_OFFSET, 0x000c 
       @ .equ BUSCTRL_PERFSEL0_PERFSEL0 [4:0]    Select a performance event for PERFCTR0 
 
    .equ BUSCTRL_PERFCTR1_OFFSET, 0x0010 
       @ .equ BUSCTRL_PERFCTR1_PERFCTR1 [23:0]    Busfabric saturating performance counter 1\n  Count some event signal from the busfabric arbiters.\n  Write any value to clear. Select an event to count using PERFSEL1 
 
    .equ BUSCTRL_PERFSEL1_OFFSET, 0x0014 
       @ .equ BUSCTRL_PERFSEL1_PERFSEL1 [4:0]    Select a performance event for PERFCTR1 
 
    .equ BUSCTRL_PERFCTR2_OFFSET, 0x0018 
       @ .equ BUSCTRL_PERFCTR2_PERFCTR2 [23:0]    Busfabric saturating performance counter 2\n  Count some event signal from the busfabric arbiters.\n  Write any value to clear. Select an event to count using PERFSEL2 
 
    .equ BUSCTRL_PERFSEL2_OFFSET, 0x001c 
       @ .equ BUSCTRL_PERFSEL2_PERFSEL2 [4:0]    Select a performance event for PERFCTR2 
 
    .equ BUSCTRL_PERFCTR3_OFFSET, 0x0020 
       @ .equ BUSCTRL_PERFCTR3_PERFCTR3 [23:0]    Busfabric saturating performance counter 3\n  Count some event signal from the busfabric arbiters.\n  Write any value to clear. Select an event to count using PERFSEL3 
 
    .equ BUSCTRL_PERFSEL3_OFFSET, 0x0024 
       @ .equ BUSCTRL_PERFSEL3_PERFSEL3 [4:0]    Select a performance event for PERFCTR3 
 

@=========================== UART0 ===========================@
.equ UART0_BASE, 0x40034000 
    .equ UART0_UARTDR_OFFSET, 0x0000 
       @ .equ UART0_UARTDR_OE [11:11]    Overrun error. This bit is set to 1 if data is received and the receive FIFO is already full. This is cleared to 0 once there is an empty space in the FIFO and a new character can be written to it. 
       @ .equ UART0_UARTDR_BE [10:10]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity and stop bits. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state, and the next valid start bit is received. 
       @ .equ UART0_UARTDR_PE [9:9]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UART0_UARTDR_FE [8:8]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UART0_UARTDR_DATA [7:0]    Receive read data character. Transmit write data character. 
 
    .equ UART0_UARTRSR_OFFSET, 0x0004 
       @ .equ UART0_UARTRSR_OE [3:3]    Overrun error. This bit is set to 1 if data is received and the FIFO is already full. This bit is cleared to 0 by a write to UARTECR. The FIFO contents remain valid because no more data is written when the FIFO is full, only the contents of the shift register are overwritten. The CPU must now read the data, to empty the FIFO. 
       @ .equ UART0_UARTRSR_BE [2:2]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity, and stop bits. This bit is cleared to 0 after a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state and the next valid start bit is received. 
       @ .equ UART0_UARTRSR_PE [1:1]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UART0_UARTRSR_FE [0:0]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
 
    .equ UART0_UARTFR_OFFSET, 0x0018 
       @ .equ UART0_UARTFR_RI [8:8]    Ring indicator. This bit is the complement of the UART ring indicator, nUARTRI, modem status input. That is, the bit is 1 when nUARTRI is LOW. 
       @ .equ UART0_UARTFR_TXFE [7:7]    Transmit FIFO empty. The meaning of this bit depends on the state of the FEN bit in the Line Control Register, UARTLCR_H. If the FIFO is disabled, this bit is set when the transmit holding register is empty. If the FIFO is enabled, the TXFE bit is set when the transmit FIFO is empty. This bit does not indicate if there is data in the transmit shift register. 
       @ .equ UART0_UARTFR_RXFF [6:6]    Receive FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is full. If the FIFO is enabled, the RXFF bit is set when the receive FIFO is full. 
       @ .equ UART0_UARTFR_TXFF [5:5]    Transmit FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the transmit holding register is full. If the FIFO is enabled, the TXFF bit is set when the transmit FIFO is full. 
       @ .equ UART0_UARTFR_RXFE [4:4]    Receive FIFO empty. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is empty. If the FIFO is enabled, the RXFE bit is set when the receive FIFO is empty. 
       @ .equ UART0_UARTFR_BUSY [3:3]    UART busy. If this bit is set to 1, the UART is busy transmitting data. This bit remains set until the complete byte, including all the stop bits, has been sent from the shift register. This bit is set as soon as the transmit FIFO becomes non-empty, regardless of whether the UART is enabled or not. 
       @ .equ UART0_UARTFR_DCD [2:2]    Data carrier detect. This bit is the complement of the UART data carrier detect, nUARTDCD, modem status input. That is, the bit is 1 when nUARTDCD is LOW. 
       @ .equ UART0_UARTFR_DSR [1:1]    Data set ready. This bit is the complement of the UART data set ready, nUARTDSR, modem status input. That is, the bit is 1 when nUARTDSR is LOW. 
       @ .equ UART0_UARTFR_CTS [0:0]    Clear to send. This bit is the complement of the UART clear to send, nUARTCTS, modem status input. That is, the bit is 1 when nUARTCTS is LOW. 
 
    .equ UART0_UARTILPR_OFFSET, 0x0020 
       @ .equ UART0_UARTILPR_ILPDVSR [7:0]    8-bit low-power divisor value. These bits are cleared to 0 at reset. 
 
    .equ UART0_UARTIBRD_OFFSET, 0x0024 
       @ .equ UART0_UARTIBRD_BAUD_DIVINT [15:0]    The integer baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART0_UARTFBRD_OFFSET, 0x0028 
       @ .equ UART0_UARTFBRD_BAUD_DIVFRAC [5:0]    The fractional baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART0_UARTLCR_H_OFFSET, 0x002c 
       @ .equ UART0_UARTLCR_H_SPS [7:7]    Stick parity select. 0 = stick parity is disabled 1 = either: * if the EPS bit is 0 then the parity bit is transmitted and checked as a 1 * if the EPS bit is 1 then the parity bit is transmitted and checked as a 0. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UART0_UARTLCR_H_WLEN [6:5]    Word length. These bits indicate the number of data bits transmitted or received in a frame as follows: b11 = 8 bits b10 = 7 bits b01 = 6 bits b00 = 5 bits. 
       @ .equ UART0_UARTLCR_H_FEN [4:4]    Enable FIFOs: 0 = FIFOs are disabled character mode that is, the FIFOs become 1-byte-deep holding registers 1 = transmit and receive FIFO buffers are enabled FIFO mode. 
       @ .equ UART0_UARTLCR_H_STP2 [3:3]    Two stop bits select. If this bit is set to 1, two stop bits are transmitted at the end of the frame. The receive logic does not check for two stop bits being received. 
       @ .equ UART0_UARTLCR_H_EPS [2:2]    Even parity select. Controls the type of parity the UART uses during transmission and reception: 0 = odd parity. The UART generates or checks for an odd number of 1s in the data and parity bits. 1 = even parity. The UART generates or checks for an even number of 1s in the data and parity bits. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UART0_UARTLCR_H_PEN [1:1]    Parity enable: 0 = parity is disabled and no parity bit added to the data frame 1 = parity checking and generation is enabled. 
       @ .equ UART0_UARTLCR_H_BRK [0:0]    Send break. If this bit is set to 1, a low-level is continually output on the UARTTXD output, after completing transmission of the current character. For the proper execution of the break command, the software must set this bit for at least two complete frames. For normal use, this bit must be cleared to 0. 
 
    .equ UART0_UARTCR_OFFSET, 0x0030 
       @ .equ UART0_UARTCR_CTSEN [15:15]    CTS hardware flow control enable. If this bit is set to 1, CTS hardware flow control is enabled. Data is only transmitted when the nUARTCTS signal is asserted. 
       @ .equ UART0_UARTCR_RTSEN [14:14]    RTS hardware flow control enable. If this bit is set to 1, RTS hardware flow control is enabled. Data is only requested when there is space in the receive FIFO for it to be received. 
       @ .equ UART0_UARTCR_OUT2 [13:13]    This bit is the complement of the UART Out2 nUARTOut2 modem status output. That is, when the bit is programmed to a 1, the output is 0. For DTE this can be used as Ring Indicator RI. 
       @ .equ UART0_UARTCR_OUT1 [12:12]    This bit is the complement of the UART Out1 nUARTOut1 modem status output. That is, when the bit is programmed to a 1 the output is 0. For DTE this can be used as Data Carrier Detect DCD. 
       @ .equ UART0_UARTCR_RTS [11:11]    Request to send. This bit is the complement of the UART request to send, nUARTRTS, modem status output. That is, when the bit is programmed to a 1 then nUARTRTS is LOW. 
       @ .equ UART0_UARTCR_DTR [10:10]    Data transmit ready. This bit is the complement of the UART data transmit ready, nUARTDTR, modem status output. That is, when the bit is programmed to a 1 then nUARTDTR is LOW. 
       @ .equ UART0_UARTCR_RXE [9:9]    Receive enable. If this bit is set to 1, the receive section of the UART is enabled. Data reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of reception, it completes the current character before stopping. 
       @ .equ UART0_UARTCR_TXE [8:8]    Transmit enable. If this bit is set to 1, the transmit section of the UART is enabled. Data transmission occurs for either UART signals, or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of transmission, it completes the current character before stopping. 
       @ .equ UART0_UARTCR_LBE [7:7]    Loopback enable. If this bit is set to 1 and the SIREN bit is set to 1 and the SIRTEST bit in the Test Control Register, UARTTCR is set to 1, then the nSIROUT path is inverted, and fed through to the SIRIN path. The SIRTEST bit in the test register must be set to 1 to override the normal half-duplex SIR operation. This must be the requirement for accessing the test registers during normal operation, and SIRTEST must be cleared to 0 when loopback testing is finished. This feature reduces the amount of external coupling required during system test. If this bit is set to 1, and the SIRTEST bit is set to 0, the UARTTXD path is fed through to the UARTRXD path. In either SIR mode or UART mode, when this bit is set, the modem outputs are also fed through to the modem inputs. This bit is cleared to 0 on reset, to disable loopback. 
       @ .equ UART0_UARTCR_SIRLP [2:2]    SIR low-power IrDA mode. This bit selects the IrDA encoding mode. If this bit is cleared to 0, low-level bits are transmitted as an active high pulse with a width of 3 / 16th of the bit period. If this bit is set to 1, low-level bits are transmitted with a pulse width that is 3 times the period of the IrLPBaud16 input signal, regardless of the selected bit rate. Setting this bit uses less power, but might reduce transmission distances. 
       @ .equ UART0_UARTCR_SIREN [1:1]    SIR enable: 0 = IrDA SIR ENDEC is disabled. nSIROUT remains LOW no light pulse generated, and signal transitions on SIRIN have no effect. 1 = IrDA SIR ENDEC is enabled. Data is transmitted and received on nSIROUT and SIRIN. UARTTXD remains HIGH, in the marking state. Signal transitions on UARTRXD or modem status inputs have no effect. This bit has no effect if the UARTEN bit disables the UART. 
       @ .equ UART0_UARTCR_UARTEN [0:0]    UART enable: 0 = UART is disabled. If the UART is disabled in the middle of transmission or reception, it completes the current character before stopping. 1 = the UART is enabled. Data transmission and reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. 
 
    .equ UART0_UARTIFLS_OFFSET, 0x0034 
       @ .equ UART0_UARTIFLS_RXIFLSEL [5:3]    Receive interrupt FIFO level select. The trigger points for the receive interrupt are as follows: b000 = Receive FIFO becomes >= 1 / 8 full b001 = Receive FIFO becomes >= 1 / 4 full b010 = Receive FIFO becomes >= 1 / 2 full b011 = Receive FIFO becomes >= 3 / 4 full b100 = Receive FIFO becomes >= 7 / 8 full b101-b111 = reserved. 
       @ .equ UART0_UARTIFLS_TXIFLSEL [2:0]    Transmit interrupt FIFO level select. The trigger points for the transmit interrupt are as follows: b000 = Transmit FIFO becomes <= 1 / 8 full b001 = Transmit FIFO becomes <= 1 / 4 full b010 = Transmit FIFO becomes <= 1 / 2 full b011 = Transmit FIFO becomes <= 3 / 4 full b100 = Transmit FIFO becomes <= 7 / 8 full b101-b111 = reserved. 
 
    .equ UART0_UARTIMSC_OFFSET, 0x0038 
       @ .equ UART0_UARTIMSC_OEIM [10:10]    Overrun error interrupt mask. A read returns the current mask for the UARTOEINTR interrupt. On a write of 1, the mask of the UARTOEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_BEIM [9:9]    Break error interrupt mask. A read returns the current mask for the UARTBEINTR interrupt. On a write of 1, the mask of the UARTBEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_PEIM [8:8]    Parity error interrupt mask. A read returns the current mask for the UARTPEINTR interrupt. On a write of 1, the mask of the UARTPEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_FEIM [7:7]    Framing error interrupt mask. A read returns the current mask for the UARTFEINTR interrupt. On a write of 1, the mask of the UARTFEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_RTIM [6:6]    Receive timeout interrupt mask. A read returns the current mask for the UARTRTINTR interrupt. On a write of 1, the mask of the UARTRTINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_TXIM [5:5]    Transmit interrupt mask. A read returns the current mask for the UARTTXINTR interrupt. On a write of 1, the mask of the UARTTXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_RXIM [4:4]    Receive interrupt mask. A read returns the current mask for the UARTRXINTR interrupt. On a write of 1, the mask of the UARTRXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_DSRMIM [3:3]    nUARTDSR modem interrupt mask. A read returns the current mask for the UARTDSRINTR interrupt. On a write of 1, the mask of the UARTDSRINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_DCDMIM [2:2]    nUARTDCD modem interrupt mask. A read returns the current mask for the UARTDCDINTR interrupt. On a write of 1, the mask of the UARTDCDINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_CTSMIM [1:1]    nUARTCTS modem interrupt mask. A read returns the current mask for the UARTCTSINTR interrupt. On a write of 1, the mask of the UARTCTSINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART0_UARTIMSC_RIMIM [0:0]    nUARTRI modem interrupt mask. A read returns the current mask for the UARTRIINTR interrupt. On a write of 1, the mask of the UARTRIINTR interrupt is set. A write of 0 clears the mask. 
 
    .equ UART0_UARTRIS_OFFSET, 0x003c 
       @ .equ UART0_UARTRIS_OERIS [10:10]    Overrun error interrupt status. Returns the raw interrupt state of the UARTOEINTR interrupt. 
       @ .equ UART0_UARTRIS_BERIS [9:9]    Break error interrupt status. Returns the raw interrupt state of the UARTBEINTR interrupt. 
       @ .equ UART0_UARTRIS_PERIS [8:8]    Parity error interrupt status. Returns the raw interrupt state of the UARTPEINTR interrupt. 
       @ .equ UART0_UARTRIS_FERIS [7:7]    Framing error interrupt status. Returns the raw interrupt state of the UARTFEINTR interrupt. 
       @ .equ UART0_UARTRIS_RTRIS [6:6]    Receive timeout interrupt status. Returns the raw interrupt state of the UARTRTINTR interrupt. a 
       @ .equ UART0_UARTRIS_TXRIS [5:5]    Transmit interrupt status. Returns the raw interrupt state of the UARTTXINTR interrupt. 
       @ .equ UART0_UARTRIS_RXRIS [4:4]    Receive interrupt status. Returns the raw interrupt state of the UARTRXINTR interrupt. 
       @ .equ UART0_UARTRIS_DSRRMIS [3:3]    nUARTDSR modem interrupt status. Returns the raw interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UART0_UARTRIS_DCDRMIS [2:2]    nUARTDCD modem interrupt status. Returns the raw interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UART0_UARTRIS_CTSRMIS [1:1]    nUARTCTS modem interrupt status. Returns the raw interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UART0_UARTRIS_RIRMIS [0:0]    nUARTRI modem interrupt status. Returns the raw interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART0_UARTMIS_OFFSET, 0x0040 
       @ .equ UART0_UARTMIS_OEMIS [10:10]    Overrun error masked interrupt status. Returns the masked interrupt state of the UARTOEINTR interrupt. 
       @ .equ UART0_UARTMIS_BEMIS [9:9]    Break error masked interrupt status. Returns the masked interrupt state of the UARTBEINTR interrupt. 
       @ .equ UART0_UARTMIS_PEMIS [8:8]    Parity error masked interrupt status. Returns the masked interrupt state of the UARTPEINTR interrupt. 
       @ .equ UART0_UARTMIS_FEMIS [7:7]    Framing error masked interrupt status. Returns the masked interrupt state of the UARTFEINTR interrupt. 
       @ .equ UART0_UARTMIS_RTMIS [6:6]    Receive timeout masked interrupt status. Returns the masked interrupt state of the UARTRTINTR interrupt. 
       @ .equ UART0_UARTMIS_TXMIS [5:5]    Transmit masked interrupt status. Returns the masked interrupt state of the UARTTXINTR interrupt. 
       @ .equ UART0_UARTMIS_RXMIS [4:4]    Receive masked interrupt status. Returns the masked interrupt state of the UARTRXINTR interrupt. 
       @ .equ UART0_UARTMIS_DSRMMIS [3:3]    nUARTDSR modem masked interrupt status. Returns the masked interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UART0_UARTMIS_DCDMMIS [2:2]    nUARTDCD modem masked interrupt status. Returns the masked interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UART0_UARTMIS_CTSMMIS [1:1]    nUARTCTS modem masked interrupt status. Returns the masked interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UART0_UARTMIS_RIMMIS [0:0]    nUARTRI modem masked interrupt status. Returns the masked interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART0_UARTICR_OFFSET, 0x0044 
       @ .equ UART0_UARTICR_OEIC [10:10]    Overrun error interrupt clear. Clears the UARTOEINTR interrupt. 
       @ .equ UART0_UARTICR_BEIC [9:9]    Break error interrupt clear. Clears the UARTBEINTR interrupt. 
       @ .equ UART0_UARTICR_PEIC [8:8]    Parity error interrupt clear. Clears the UARTPEINTR interrupt. 
       @ .equ UART0_UARTICR_FEIC [7:7]    Framing error interrupt clear. Clears the UARTFEINTR interrupt. 
       @ .equ UART0_UARTICR_RTIC [6:6]    Receive timeout interrupt clear. Clears the UARTRTINTR interrupt. 
       @ .equ UART0_UARTICR_TXIC [5:5]    Transmit interrupt clear. Clears the UARTTXINTR interrupt. 
       @ .equ UART0_UARTICR_RXIC [4:4]    Receive interrupt clear. Clears the UARTRXINTR interrupt. 
       @ .equ UART0_UARTICR_DSRMIC [3:3]    nUARTDSR modem interrupt clear. Clears the UARTDSRINTR interrupt. 
       @ .equ UART0_UARTICR_DCDMIC [2:2]    nUARTDCD modem interrupt clear. Clears the UARTDCDINTR interrupt. 
       @ .equ UART0_UARTICR_CTSMIC [1:1]    nUARTCTS modem interrupt clear. Clears the UARTCTSINTR interrupt. 
       @ .equ UART0_UARTICR_RIMIC [0:0]    nUARTRI modem interrupt clear. Clears the UARTRIINTR interrupt. 
 
    .equ UART0_UARTDMACR_OFFSET, 0x0048 
       @ .equ UART0_UARTDMACR_DMAONERR [2:2]    DMA on error. If this bit is set to 1, the DMA receive request outputs, UARTRXDMASREQ or UARTRXDMABREQ, are disabled when the UART error interrupt is asserted. 
       @ .equ UART0_UARTDMACR_TXDMAE [1:1]    Transmit DMA enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ UART0_UARTDMACR_RXDMAE [0:0]    Receive DMA enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ UART0_UARTPERIPHID0_OFFSET, 0x0fe0 
       @ .equ UART0_UARTPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x11 
 
    .equ UART0_UARTPERIPHID1_OFFSET, 0x0fe4 
       @ .equ UART0_UARTPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ UART0_UARTPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ UART0_UARTPERIPHID2_OFFSET, 0x0fe8 
       @ .equ UART0_UARTPERIPHID2_REVISION [7:4]    This field depends on the revision of the UART: r1p0 0x0 r1p1 0x1 r1p3 0x2 r1p4 0x2 r1p5 0x3 
       @ .equ UART0_UARTPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ UART0_UARTPERIPHID3_OFFSET, 0x0fec 
       @ .equ UART0_UARTPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ UART0_UARTPCELLID0_OFFSET, 0x0ff0 
       @ .equ UART0_UARTPCELLID0_UARTPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ UART0_UARTPCELLID1_OFFSET, 0x0ff4 
       @ .equ UART0_UARTPCELLID1_UARTPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ UART0_UARTPCELLID2_OFFSET, 0x0ff8 
       @ .equ UART0_UARTPCELLID2_UARTPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ UART0_UARTPCELLID3_OFFSET, 0x0ffc 
       @ .equ UART0_UARTPCELLID3_UARTPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== UART1 ===========================@
.equ UART1_BASE, 0x40038000 
    .equ UART1_UARTDR_OFFSET, 0x0000 
       @ .equ UART1_UARTDR_OE [11:11]    Overrun error. This bit is set to 1 if data is received and the receive FIFO is already full. This is cleared to 0 once there is an empty space in the FIFO and a new character can be written to it. 
       @ .equ UART1_UARTDR_BE [10:10]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity and stop bits. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state, and the next valid start bit is received. 
       @ .equ UART1_UARTDR_PE [9:9]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UART1_UARTDR_FE [8:8]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UART1_UARTDR_DATA [7:0]    Receive read data character. Transmit write data character. 
 
    .equ UART1_UARTRSR_OFFSET, 0x0004 
       @ .equ UART1_UARTRSR_OE [3:3]    Overrun error. This bit is set to 1 if data is received and the FIFO is already full. This bit is cleared to 0 by a write to UARTECR. The FIFO contents remain valid because no more data is written when the FIFO is full, only the contents of the shift register are overwritten. The CPU must now read the data, to empty the FIFO. 
       @ .equ UART1_UARTRSR_BE [2:2]    Break error. This bit is set to 1 if a break condition was detected, indicating that the received data input was held LOW for longer than a full-word transmission time defined as start, data, parity, and stop bits. This bit is cleared to 0 after a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. When a break occurs, only one 0 character is loaded into the FIFO. The next character is only enabled after the receive data input goes to a 1 marking state and the next valid start bit is received. 
       @ .equ UART1_UARTRSR_PE [1:1]    Parity error. When set to 1, it indicates that the parity of the received data character does not match the parity that the EPS and SPS bits in the Line Control Register, UARTLCR_H. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
       @ .equ UART1_UARTRSR_FE [0:0]    Framing error. When set to 1, it indicates that the received character did not have a valid stop bit a valid stop bit is 1. This bit is cleared to 0 by a write to UARTECR. In FIFO mode, this error is associated with the character at the top of the FIFO. 
 
    .equ UART1_UARTFR_OFFSET, 0x0018 
       @ .equ UART1_UARTFR_RI [8:8]    Ring indicator. This bit is the complement of the UART ring indicator, nUARTRI, modem status input. That is, the bit is 1 when nUARTRI is LOW. 
       @ .equ UART1_UARTFR_TXFE [7:7]    Transmit FIFO empty. The meaning of this bit depends on the state of the FEN bit in the Line Control Register, UARTLCR_H. If the FIFO is disabled, this bit is set when the transmit holding register is empty. If the FIFO is enabled, the TXFE bit is set when the transmit FIFO is empty. This bit does not indicate if there is data in the transmit shift register. 
       @ .equ UART1_UARTFR_RXFF [6:6]    Receive FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is full. If the FIFO is enabled, the RXFF bit is set when the receive FIFO is full. 
       @ .equ UART1_UARTFR_TXFF [5:5]    Transmit FIFO full. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the transmit holding register is full. If the FIFO is enabled, the TXFF bit is set when the transmit FIFO is full. 
       @ .equ UART1_UARTFR_RXFE [4:4]    Receive FIFO empty. The meaning of this bit depends on the state of the FEN bit in the UARTLCR_H Register. If the FIFO is disabled, this bit is set when the receive holding register is empty. If the FIFO is enabled, the RXFE bit is set when the receive FIFO is empty. 
       @ .equ UART1_UARTFR_BUSY [3:3]    UART busy. If this bit is set to 1, the UART is busy transmitting data. This bit remains set until the complete byte, including all the stop bits, has been sent from the shift register. This bit is set as soon as the transmit FIFO becomes non-empty, regardless of whether the UART is enabled or not. 
       @ .equ UART1_UARTFR_DCD [2:2]    Data carrier detect. This bit is the complement of the UART data carrier detect, nUARTDCD, modem status input. That is, the bit is 1 when nUARTDCD is LOW. 
       @ .equ UART1_UARTFR_DSR [1:1]    Data set ready. This bit is the complement of the UART data set ready, nUARTDSR, modem status input. That is, the bit is 1 when nUARTDSR is LOW. 
       @ .equ UART1_UARTFR_CTS [0:0]    Clear to send. This bit is the complement of the UART clear to send, nUARTCTS, modem status input. That is, the bit is 1 when nUARTCTS is LOW. 
 
    .equ UART1_UARTILPR_OFFSET, 0x0020 
       @ .equ UART1_UARTILPR_ILPDVSR [7:0]    8-bit low-power divisor value. These bits are cleared to 0 at reset. 
 
    .equ UART1_UARTIBRD_OFFSET, 0x0024 
       @ .equ UART1_UARTIBRD_BAUD_DIVINT [15:0]    The integer baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART1_UARTFBRD_OFFSET, 0x0028 
       @ .equ UART1_UARTFBRD_BAUD_DIVFRAC [5:0]    The fractional baud rate divisor. These bits are cleared to 0 on reset. 
 
    .equ UART1_UARTLCR_H_OFFSET, 0x002c 
       @ .equ UART1_UARTLCR_H_SPS [7:7]    Stick parity select. 0 = stick parity is disabled 1 = either: * if the EPS bit is 0 then the parity bit is transmitted and checked as a 1 * if the EPS bit is 1 then the parity bit is transmitted and checked as a 0. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UART1_UARTLCR_H_WLEN [6:5]    Word length. These bits indicate the number of data bits transmitted or received in a frame as follows: b11 = 8 bits b10 = 7 bits b01 = 6 bits b00 = 5 bits. 
       @ .equ UART1_UARTLCR_H_FEN [4:4]    Enable FIFOs: 0 = FIFOs are disabled character mode that is, the FIFOs become 1-byte-deep holding registers 1 = transmit and receive FIFO buffers are enabled FIFO mode. 
       @ .equ UART1_UARTLCR_H_STP2 [3:3]    Two stop bits select. If this bit is set to 1, two stop bits are transmitted at the end of the frame. The receive logic does not check for two stop bits being received. 
       @ .equ UART1_UARTLCR_H_EPS [2:2]    Even parity select. Controls the type of parity the UART uses during transmission and reception: 0 = odd parity. The UART generates or checks for an odd number of 1s in the data and parity bits. 1 = even parity. The UART generates or checks for an even number of 1s in the data and parity bits. This bit has no effect when the PEN bit disables parity checking and generation. 
       @ .equ UART1_UARTLCR_H_PEN [1:1]    Parity enable: 0 = parity is disabled and no parity bit added to the data frame 1 = parity checking and generation is enabled. 
       @ .equ UART1_UARTLCR_H_BRK [0:0]    Send break. If this bit is set to 1, a low-level is continually output on the UARTTXD output, after completing transmission of the current character. For the proper execution of the break command, the software must set this bit for at least two complete frames. For normal use, this bit must be cleared to 0. 
 
    .equ UART1_UARTCR_OFFSET, 0x0030 
       @ .equ UART1_UARTCR_CTSEN [15:15]    CTS hardware flow control enable. If this bit is set to 1, CTS hardware flow control is enabled. Data is only transmitted when the nUARTCTS signal is asserted. 
       @ .equ UART1_UARTCR_RTSEN [14:14]    RTS hardware flow control enable. If this bit is set to 1, RTS hardware flow control is enabled. Data is only requested when there is space in the receive FIFO for it to be received. 
       @ .equ UART1_UARTCR_OUT2 [13:13]    This bit is the complement of the UART Out2 nUARTOut2 modem status output. That is, when the bit is programmed to a 1, the output is 0. For DTE this can be used as Ring Indicator RI. 
       @ .equ UART1_UARTCR_OUT1 [12:12]    This bit is the complement of the UART Out1 nUARTOut1 modem status output. That is, when the bit is programmed to a 1 the output is 0. For DTE this can be used as Data Carrier Detect DCD. 
       @ .equ UART1_UARTCR_RTS [11:11]    Request to send. This bit is the complement of the UART request to send, nUARTRTS, modem status output. That is, when the bit is programmed to a 1 then nUARTRTS is LOW. 
       @ .equ UART1_UARTCR_DTR [10:10]    Data transmit ready. This bit is the complement of the UART data transmit ready, nUARTDTR, modem status output. That is, when the bit is programmed to a 1 then nUARTDTR is LOW. 
       @ .equ UART1_UARTCR_RXE [9:9]    Receive enable. If this bit is set to 1, the receive section of the UART is enabled. Data reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of reception, it completes the current character before stopping. 
       @ .equ UART1_UARTCR_TXE [8:8]    Transmit enable. If this bit is set to 1, the transmit section of the UART is enabled. Data transmission occurs for either UART signals, or SIR signals depending on the setting of the SIREN bit. When the UART is disabled in the middle of transmission, it completes the current character before stopping. 
       @ .equ UART1_UARTCR_LBE [7:7]    Loopback enable. If this bit is set to 1 and the SIREN bit is set to 1 and the SIRTEST bit in the Test Control Register, UARTTCR is set to 1, then the nSIROUT path is inverted, and fed through to the SIRIN path. The SIRTEST bit in the test register must be set to 1 to override the normal half-duplex SIR operation. This must be the requirement for accessing the test registers during normal operation, and SIRTEST must be cleared to 0 when loopback testing is finished. This feature reduces the amount of external coupling required during system test. If this bit is set to 1, and the SIRTEST bit is set to 0, the UARTTXD path is fed through to the UARTRXD path. In either SIR mode or UART mode, when this bit is set, the modem outputs are also fed through to the modem inputs. This bit is cleared to 0 on reset, to disable loopback. 
       @ .equ UART1_UARTCR_SIRLP [2:2]    SIR low-power IrDA mode. This bit selects the IrDA encoding mode. If this bit is cleared to 0, low-level bits are transmitted as an active high pulse with a width of 3 / 16th of the bit period. If this bit is set to 1, low-level bits are transmitted with a pulse width that is 3 times the period of the IrLPBaud16 input signal, regardless of the selected bit rate. Setting this bit uses less power, but might reduce transmission distances. 
       @ .equ UART1_UARTCR_SIREN [1:1]    SIR enable: 0 = IrDA SIR ENDEC is disabled. nSIROUT remains LOW no light pulse generated, and signal transitions on SIRIN have no effect. 1 = IrDA SIR ENDEC is enabled. Data is transmitted and received on nSIROUT and SIRIN. UARTTXD remains HIGH, in the marking state. Signal transitions on UARTRXD or modem status inputs have no effect. This bit has no effect if the UARTEN bit disables the UART. 
       @ .equ UART1_UARTCR_UARTEN [0:0]    UART enable: 0 = UART is disabled. If the UART is disabled in the middle of transmission or reception, it completes the current character before stopping. 1 = the UART is enabled. Data transmission and reception occurs for either UART signals or SIR signals depending on the setting of the SIREN bit. 
 
    .equ UART1_UARTIFLS_OFFSET, 0x0034 
       @ .equ UART1_UARTIFLS_RXIFLSEL [5:3]    Receive interrupt FIFO level select. The trigger points for the receive interrupt are as follows: b000 = Receive FIFO becomes >= 1 / 8 full b001 = Receive FIFO becomes >= 1 / 4 full b010 = Receive FIFO becomes >= 1 / 2 full b011 = Receive FIFO becomes >= 3 / 4 full b100 = Receive FIFO becomes >= 7 / 8 full b101-b111 = reserved. 
       @ .equ UART1_UARTIFLS_TXIFLSEL [2:0]    Transmit interrupt FIFO level select. The trigger points for the transmit interrupt are as follows: b000 = Transmit FIFO becomes <= 1 / 8 full b001 = Transmit FIFO becomes <= 1 / 4 full b010 = Transmit FIFO becomes <= 1 / 2 full b011 = Transmit FIFO becomes <= 3 / 4 full b100 = Transmit FIFO becomes <= 7 / 8 full b101-b111 = reserved. 
 
    .equ UART1_UARTIMSC_OFFSET, 0x0038 
       @ .equ UART1_UARTIMSC_OEIM [10:10]    Overrun error interrupt mask. A read returns the current mask for the UARTOEINTR interrupt. On a write of 1, the mask of the UARTOEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_BEIM [9:9]    Break error interrupt mask. A read returns the current mask for the UARTBEINTR interrupt. On a write of 1, the mask of the UARTBEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_PEIM [8:8]    Parity error interrupt mask. A read returns the current mask for the UARTPEINTR interrupt. On a write of 1, the mask of the UARTPEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_FEIM [7:7]    Framing error interrupt mask. A read returns the current mask for the UARTFEINTR interrupt. On a write of 1, the mask of the UARTFEINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_RTIM [6:6]    Receive timeout interrupt mask. A read returns the current mask for the UARTRTINTR interrupt. On a write of 1, the mask of the UARTRTINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_TXIM [5:5]    Transmit interrupt mask. A read returns the current mask for the UARTTXINTR interrupt. On a write of 1, the mask of the UARTTXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_RXIM [4:4]    Receive interrupt mask. A read returns the current mask for the UARTRXINTR interrupt. On a write of 1, the mask of the UARTRXINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_DSRMIM [3:3]    nUARTDSR modem interrupt mask. A read returns the current mask for the UARTDSRINTR interrupt. On a write of 1, the mask of the UARTDSRINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_DCDMIM [2:2]    nUARTDCD modem interrupt mask. A read returns the current mask for the UARTDCDINTR interrupt. On a write of 1, the mask of the UARTDCDINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_CTSMIM [1:1]    nUARTCTS modem interrupt mask. A read returns the current mask for the UARTCTSINTR interrupt. On a write of 1, the mask of the UARTCTSINTR interrupt is set. A write of 0 clears the mask. 
       @ .equ UART1_UARTIMSC_RIMIM [0:0]    nUARTRI modem interrupt mask. A read returns the current mask for the UARTRIINTR interrupt. On a write of 1, the mask of the UARTRIINTR interrupt is set. A write of 0 clears the mask. 
 
    .equ UART1_UARTRIS_OFFSET, 0x003c 
       @ .equ UART1_UARTRIS_OERIS [10:10]    Overrun error interrupt status. Returns the raw interrupt state of the UARTOEINTR interrupt. 
       @ .equ UART1_UARTRIS_BERIS [9:9]    Break error interrupt status. Returns the raw interrupt state of the UARTBEINTR interrupt. 
       @ .equ UART1_UARTRIS_PERIS [8:8]    Parity error interrupt status. Returns the raw interrupt state of the UARTPEINTR interrupt. 
       @ .equ UART1_UARTRIS_FERIS [7:7]    Framing error interrupt status. Returns the raw interrupt state of the UARTFEINTR interrupt. 
       @ .equ UART1_UARTRIS_RTRIS [6:6]    Receive timeout interrupt status. Returns the raw interrupt state of the UARTRTINTR interrupt. a 
       @ .equ UART1_UARTRIS_TXRIS [5:5]    Transmit interrupt status. Returns the raw interrupt state of the UARTTXINTR interrupt. 
       @ .equ UART1_UARTRIS_RXRIS [4:4]    Receive interrupt status. Returns the raw interrupt state of the UARTRXINTR interrupt. 
       @ .equ UART1_UARTRIS_DSRRMIS [3:3]    nUARTDSR modem interrupt status. Returns the raw interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UART1_UARTRIS_DCDRMIS [2:2]    nUARTDCD modem interrupt status. Returns the raw interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UART1_UARTRIS_CTSRMIS [1:1]    nUARTCTS modem interrupt status. Returns the raw interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UART1_UARTRIS_RIRMIS [0:0]    nUARTRI modem interrupt status. Returns the raw interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART1_UARTMIS_OFFSET, 0x0040 
       @ .equ UART1_UARTMIS_OEMIS [10:10]    Overrun error masked interrupt status. Returns the masked interrupt state of the UARTOEINTR interrupt. 
       @ .equ UART1_UARTMIS_BEMIS [9:9]    Break error masked interrupt status. Returns the masked interrupt state of the UARTBEINTR interrupt. 
       @ .equ UART1_UARTMIS_PEMIS [8:8]    Parity error masked interrupt status. Returns the masked interrupt state of the UARTPEINTR interrupt. 
       @ .equ UART1_UARTMIS_FEMIS [7:7]    Framing error masked interrupt status. Returns the masked interrupt state of the UARTFEINTR interrupt. 
       @ .equ UART1_UARTMIS_RTMIS [6:6]    Receive timeout masked interrupt status. Returns the masked interrupt state of the UARTRTINTR interrupt. 
       @ .equ UART1_UARTMIS_TXMIS [5:5]    Transmit masked interrupt status. Returns the masked interrupt state of the UARTTXINTR interrupt. 
       @ .equ UART1_UARTMIS_RXMIS [4:4]    Receive masked interrupt status. Returns the masked interrupt state of the UARTRXINTR interrupt. 
       @ .equ UART1_UARTMIS_DSRMMIS [3:3]    nUARTDSR modem masked interrupt status. Returns the masked interrupt state of the UARTDSRINTR interrupt. 
       @ .equ UART1_UARTMIS_DCDMMIS [2:2]    nUARTDCD modem masked interrupt status. Returns the masked interrupt state of the UARTDCDINTR interrupt. 
       @ .equ UART1_UARTMIS_CTSMMIS [1:1]    nUARTCTS modem masked interrupt status. Returns the masked interrupt state of the UARTCTSINTR interrupt. 
       @ .equ UART1_UARTMIS_RIMMIS [0:0]    nUARTRI modem masked interrupt status. Returns the masked interrupt state of the UARTRIINTR interrupt. 
 
    .equ UART1_UARTICR_OFFSET, 0x0044 
       @ .equ UART1_UARTICR_OEIC [10:10]    Overrun error interrupt clear. Clears the UARTOEINTR interrupt. 
       @ .equ UART1_UARTICR_BEIC [9:9]    Break error interrupt clear. Clears the UARTBEINTR interrupt. 
       @ .equ UART1_UARTICR_PEIC [8:8]    Parity error interrupt clear. Clears the UARTPEINTR interrupt. 
       @ .equ UART1_UARTICR_FEIC [7:7]    Framing error interrupt clear. Clears the UARTFEINTR interrupt. 
       @ .equ UART1_UARTICR_RTIC [6:6]    Receive timeout interrupt clear. Clears the UARTRTINTR interrupt. 
       @ .equ UART1_UARTICR_TXIC [5:5]    Transmit interrupt clear. Clears the UARTTXINTR interrupt. 
       @ .equ UART1_UARTICR_RXIC [4:4]    Receive interrupt clear. Clears the UARTRXINTR interrupt. 
       @ .equ UART1_UARTICR_DSRMIC [3:3]    nUARTDSR modem interrupt clear. Clears the UARTDSRINTR interrupt. 
       @ .equ UART1_UARTICR_DCDMIC [2:2]    nUARTDCD modem interrupt clear. Clears the UARTDCDINTR interrupt. 
       @ .equ UART1_UARTICR_CTSMIC [1:1]    nUARTCTS modem interrupt clear. Clears the UARTCTSINTR interrupt. 
       @ .equ UART1_UARTICR_RIMIC [0:0]    nUARTRI modem interrupt clear. Clears the UARTRIINTR interrupt. 
 
    .equ UART1_UARTDMACR_OFFSET, 0x0048 
       @ .equ UART1_UARTDMACR_DMAONERR [2:2]    DMA on error. If this bit is set to 1, the DMA receive request outputs, UARTRXDMASREQ or UARTRXDMABREQ, are disabled when the UART error interrupt is asserted. 
       @ .equ UART1_UARTDMACR_TXDMAE [1:1]    Transmit DMA enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ UART1_UARTDMACR_RXDMAE [0:0]    Receive DMA enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ UART1_UARTPERIPHID0_OFFSET, 0x0fe0 
       @ .equ UART1_UARTPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x11 
 
    .equ UART1_UARTPERIPHID1_OFFSET, 0x0fe4 
       @ .equ UART1_UARTPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ UART1_UARTPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ UART1_UARTPERIPHID2_OFFSET, 0x0fe8 
       @ .equ UART1_UARTPERIPHID2_REVISION [7:4]    This field depends on the revision of the UART: r1p0 0x0 r1p1 0x1 r1p3 0x2 r1p4 0x2 r1p5 0x3 
       @ .equ UART1_UARTPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ UART1_UARTPERIPHID3_OFFSET, 0x0fec 
       @ .equ UART1_UARTPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ UART1_UARTPCELLID0_OFFSET, 0x0ff0 
       @ .equ UART1_UARTPCELLID0_UARTPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ UART1_UARTPCELLID1_OFFSET, 0x0ff4 
       @ .equ UART1_UARTPCELLID1_UARTPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ UART1_UARTPCELLID2_OFFSET, 0x0ff8 
       @ .equ UART1_UARTPCELLID2_UARTPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ UART1_UARTPCELLID3_OFFSET, 0x0ffc 
       @ .equ UART1_UARTPCELLID3_UARTPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== SPI0 ===========================@
.equ SPI0_BASE, 0x4003c000 
    .equ SPI0_SSPCR0_OFFSET, 0x0000 
       @ .equ SPI0_SSPCR0_SCR [15:8]    Serial clock rate. The value SCR is used to generate the transmit and receive bit rate of the PrimeCell SSP. The bit rate is: F SSPCLK CPSDVSR x 1+SCR where CPSDVSR is an even value from 2-254, programmed through the SSPCPSR register and SCR is a value from 0-255. 
       @ .equ SPI0_SSPCR0_SPH [7:7]    SSPCLKOUT phase, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SPI0_SSPCR0_SPO [6:6]    SSPCLKOUT polarity, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SPI0_SSPCR0_FRF [5:4]    Frame format: 00 Motorola SPI frame format. 01 TI synchronous serial frame format. 10 National Microwire frame format. 11 Reserved, undefined operation. 
       @ .equ SPI0_SSPCR0_DSS [3:0]    Data Size Select: 0000 Reserved, undefined operation. 0001 Reserved, undefined operation. 0010 Reserved, undefined operation. 0011 4-bit data. 0100 5-bit data. 0101 6-bit data. 0110 7-bit data. 0111 8-bit data. 1000 9-bit data. 1001 10-bit data. 1010 11-bit data. 1011 12-bit data. 1100 13-bit data. 1101 14-bit data. 1110 15-bit data. 1111 16-bit data. 
 
    .equ SPI0_SSPCR1_OFFSET, 0x0004 
       @ .equ SPI0_SSPCR1_SOD [3:3]    Slave-mode output disable. This bit is relevant only in the slave mode, MS=1. In multiple-slave systems, it is possible for an PrimeCell SSP master to broadcast a message to all slaves in the system while ensuring that only one slave drives data onto its serial output line. In such systems the RXD lines from multiple slaves could be tied together. To operate in such systems, the SOD bit can be set if the PrimeCell SSP slave is not supposed to drive the SSPTXD line: 0 SSP can drive the SSPTXD output in slave mode. 1 SSP must not drive the SSPTXD output in slave mode. 
       @ .equ SPI0_SSPCR1_MS [2:2]    Master or slave mode select. This bit can be modified only when the PrimeCell SSP is disabled, SSE=0: 0 Device configured as master, default. 1 Device configured as slave. 
       @ .equ SPI0_SSPCR1_SSE [1:1]    Synchronous serial port enable: 0 SSP operation disabled. 1 SSP operation enabled. 
       @ .equ SPI0_SSPCR1_LBM [0:0]    Loop back mode: 0 Normal serial port operation enabled. 1 Output of transmit serial shifter is connected to input of receive serial shifter internally. 
 
    .equ SPI0_SSPDR_OFFSET, 0x0008 
       @ .equ SPI0_SSPDR_DATA [15:0]    Transmit/Receive FIFO: Read Receive FIFO. Write Transmit FIFO. You must right-justify data when the PrimeCell SSP is programmed for a data size that is less than 16 bits. Unused bits at the top are ignored by transmit logic. The receive logic automatically right-justifies. 
 
    .equ SPI0_SSPSR_OFFSET, 0x000c 
       @ .equ SPI0_SSPSR_BSY [4:4]    PrimeCell SSP busy flag, RO: 0 SSP is idle. 1 SSP is currently transmitting and/or receiving a frame or the transmit FIFO is not empty. 
       @ .equ SPI0_SSPSR_RFF [3:3]    Receive FIFO full, RO: 0 Receive FIFO is not full. 1 Receive FIFO is full. 
       @ .equ SPI0_SSPSR_RNE [2:2]    Receive FIFO not empty, RO: 0 Receive FIFO is empty. 1 Receive FIFO is not empty. 
       @ .equ SPI0_SSPSR_TNF [1:1]    Transmit FIFO not full, RO: 0 Transmit FIFO is full. 1 Transmit FIFO is not full. 
       @ .equ SPI0_SSPSR_TFE [0:0]    Transmit FIFO empty, RO: 0 Transmit FIFO is not empty. 1 Transmit FIFO is empty. 
 
    .equ SPI0_SSPCPSR_OFFSET, 0x0010 
       @ .equ SPI0_SSPCPSR_CPSDVSR [7:0]    Clock prescale divisor. Must be an even number from 2-254, depending on the frequency of SSPCLK. The least significant bit always returns zero on reads. 
 
    .equ SPI0_SSPIMSC_OFFSET, 0x0014 
       @ .equ SPI0_SSPIMSC_TXIM [3:3]    Transmit FIFO interrupt mask: 0 Transmit FIFO half empty or less condition interrupt is masked. 1 Transmit FIFO half empty or less condition interrupt is not masked. 
       @ .equ SPI0_SSPIMSC_RXIM [2:2]    Receive FIFO interrupt mask: 0 Receive FIFO half full or less condition interrupt is masked. 1 Receive FIFO half full or less condition interrupt is not masked. 
       @ .equ SPI0_SSPIMSC_RTIM [1:1]    Receive timeout interrupt mask: 0 Receive FIFO not empty and no read prior to timeout period interrupt is masked. 1 Receive FIFO not empty and no read prior to timeout period interrupt is not masked. 
       @ .equ SPI0_SSPIMSC_RORIM [0:0]    Receive overrun interrupt mask: 0 Receive FIFO written to while full condition interrupt is masked. 1 Receive FIFO written to while full condition interrupt is not masked. 
 
    .equ SPI0_SSPRIS_OFFSET, 0x0018 
       @ .equ SPI0_SSPRIS_TXRIS [3:3]    Gives the raw interrupt state, prior to masking, of the SSPTXINTR interrupt 
       @ .equ SPI0_SSPRIS_RXRIS [2:2]    Gives the raw interrupt state, prior to masking, of the SSPRXINTR interrupt 
       @ .equ SPI0_SSPRIS_RTRIS [1:1]    Gives the raw interrupt state, prior to masking, of the SSPRTINTR interrupt 
       @ .equ SPI0_SSPRIS_RORRIS [0:0]    Gives the raw interrupt state, prior to masking, of the SSPRORINTR interrupt 
 
    .equ SPI0_SSPMIS_OFFSET, 0x001c 
       @ .equ SPI0_SSPMIS_TXMIS [3:3]    Gives the transmit FIFO masked interrupt state, after masking, of the SSPTXINTR interrupt 
       @ .equ SPI0_SSPMIS_RXMIS [2:2]    Gives the receive FIFO masked interrupt state, after masking, of the SSPRXINTR interrupt 
       @ .equ SPI0_SSPMIS_RTMIS [1:1]    Gives the receive timeout masked interrupt state, after masking, of the SSPRTINTR interrupt 
       @ .equ SPI0_SSPMIS_RORMIS [0:0]    Gives the receive over run masked interrupt status, after masking, of the SSPRORINTR interrupt 
 
    .equ SPI0_SSPICR_OFFSET, 0x0020 
       @ .equ SPI0_SSPICR_RTIC [1:1]    Clears the SSPRTINTR interrupt 
       @ .equ SPI0_SSPICR_RORIC [0:0]    Clears the SSPRORINTR interrupt 
 
    .equ SPI0_SSPDMACR_OFFSET, 0x0024 
       @ .equ SPI0_SSPDMACR_TXDMAE [1:1]    Transmit DMA Enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ SPI0_SSPDMACR_RXDMAE [0:0]    Receive DMA Enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ SPI0_SSPPERIPHID0_OFFSET, 0x0fe0 
       @ .equ SPI0_SSPPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x22 
 
    .equ SPI0_SSPPERIPHID1_OFFSET, 0x0fe4 
       @ .equ SPI0_SSPPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ SPI0_SSPPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ SPI0_SSPPERIPHID2_OFFSET, 0x0fe8 
       @ .equ SPI0_SSPPERIPHID2_REVISION [7:4]    These bits return the peripheral revision 
       @ .equ SPI0_SSPPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ SPI0_SSPPERIPHID3_OFFSET, 0x0fec 
       @ .equ SPI0_SSPPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ SPI0_SSPPCELLID0_OFFSET, 0x0ff0 
       @ .equ SPI0_SSPPCELLID0_SSPPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ SPI0_SSPPCELLID1_OFFSET, 0x0ff4 
       @ .equ SPI0_SSPPCELLID1_SSPPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ SPI0_SSPPCELLID2_OFFSET, 0x0ff8 
       @ .equ SPI0_SSPPCELLID2_SSPPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ SPI0_SSPPCELLID3_OFFSET, 0x0ffc 
       @ .equ SPI0_SSPPCELLID3_SSPPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== SPI1 ===========================@
.equ SPI1_BASE, 0x40040000 
    .equ SPI1_SSPCR0_OFFSET, 0x0000 
       @ .equ SPI1_SSPCR0_SCR [15:8]    Serial clock rate. The value SCR is used to generate the transmit and receive bit rate of the PrimeCell SSP. The bit rate is: F SSPCLK CPSDVSR x 1+SCR where CPSDVSR is an even value from 2-254, programmed through the SSPCPSR register and SCR is a value from 0-255. 
       @ .equ SPI1_SSPCR0_SPH [7:7]    SSPCLKOUT phase, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SPI1_SSPCR0_SPO [6:6]    SSPCLKOUT polarity, applicable to Motorola SPI frame format only. See Motorola SPI frame format on page 2-10. 
       @ .equ SPI1_SSPCR0_FRF [5:4]    Frame format: 00 Motorola SPI frame format. 01 TI synchronous serial frame format. 10 National Microwire frame format. 11 Reserved, undefined operation. 
       @ .equ SPI1_SSPCR0_DSS [3:0]    Data Size Select: 0000 Reserved, undefined operation. 0001 Reserved, undefined operation. 0010 Reserved, undefined operation. 0011 4-bit data. 0100 5-bit data. 0101 6-bit data. 0110 7-bit data. 0111 8-bit data. 1000 9-bit data. 1001 10-bit data. 1010 11-bit data. 1011 12-bit data. 1100 13-bit data. 1101 14-bit data. 1110 15-bit data. 1111 16-bit data. 
 
    .equ SPI1_SSPCR1_OFFSET, 0x0004 
       @ .equ SPI1_SSPCR1_SOD [3:3]    Slave-mode output disable. This bit is relevant only in the slave mode, MS=1. In multiple-slave systems, it is possible for an PrimeCell SSP master to broadcast a message to all slaves in the system while ensuring that only one slave drives data onto its serial output line. In such systems the RXD lines from multiple slaves could be tied together. To operate in such systems, the SOD bit can be set if the PrimeCell SSP slave is not supposed to drive the SSPTXD line: 0 SSP can drive the SSPTXD output in slave mode. 1 SSP must not drive the SSPTXD output in slave mode. 
       @ .equ SPI1_SSPCR1_MS [2:2]    Master or slave mode select. This bit can be modified only when the PrimeCell SSP is disabled, SSE=0: 0 Device configured as master, default. 1 Device configured as slave. 
       @ .equ SPI1_SSPCR1_SSE [1:1]    Synchronous serial port enable: 0 SSP operation disabled. 1 SSP operation enabled. 
       @ .equ SPI1_SSPCR1_LBM [0:0]    Loop back mode: 0 Normal serial port operation enabled. 1 Output of transmit serial shifter is connected to input of receive serial shifter internally. 
 
    .equ SPI1_SSPDR_OFFSET, 0x0008 
       @ .equ SPI1_SSPDR_DATA [15:0]    Transmit/Receive FIFO: Read Receive FIFO. Write Transmit FIFO. You must right-justify data when the PrimeCell SSP is programmed for a data size that is less than 16 bits. Unused bits at the top are ignored by transmit logic. The receive logic automatically right-justifies. 
 
    .equ SPI1_SSPSR_OFFSET, 0x000c 
       @ .equ SPI1_SSPSR_BSY [4:4]    PrimeCell SSP busy flag, RO: 0 SSP is idle. 1 SSP is currently transmitting and/or receiving a frame or the transmit FIFO is not empty. 
       @ .equ SPI1_SSPSR_RFF [3:3]    Receive FIFO full, RO: 0 Receive FIFO is not full. 1 Receive FIFO is full. 
       @ .equ SPI1_SSPSR_RNE [2:2]    Receive FIFO not empty, RO: 0 Receive FIFO is empty. 1 Receive FIFO is not empty. 
       @ .equ SPI1_SSPSR_TNF [1:1]    Transmit FIFO not full, RO: 0 Transmit FIFO is full. 1 Transmit FIFO is not full. 
       @ .equ SPI1_SSPSR_TFE [0:0]    Transmit FIFO empty, RO: 0 Transmit FIFO is not empty. 1 Transmit FIFO is empty. 
 
    .equ SPI1_SSPCPSR_OFFSET, 0x0010 
       @ .equ SPI1_SSPCPSR_CPSDVSR [7:0]    Clock prescale divisor. Must be an even number from 2-254, depending on the frequency of SSPCLK. The least significant bit always returns zero on reads. 
 
    .equ SPI1_SSPIMSC_OFFSET, 0x0014 
       @ .equ SPI1_SSPIMSC_TXIM [3:3]    Transmit FIFO interrupt mask: 0 Transmit FIFO half empty or less condition interrupt is masked. 1 Transmit FIFO half empty or less condition interrupt is not masked. 
       @ .equ SPI1_SSPIMSC_RXIM [2:2]    Receive FIFO interrupt mask: 0 Receive FIFO half full or less condition interrupt is masked. 1 Receive FIFO half full or less condition interrupt is not masked. 
       @ .equ SPI1_SSPIMSC_RTIM [1:1]    Receive timeout interrupt mask: 0 Receive FIFO not empty and no read prior to timeout period interrupt is masked. 1 Receive FIFO not empty and no read prior to timeout period interrupt is not masked. 
       @ .equ SPI1_SSPIMSC_RORIM [0:0]    Receive overrun interrupt mask: 0 Receive FIFO written to while full condition interrupt is masked. 1 Receive FIFO written to while full condition interrupt is not masked. 
 
    .equ SPI1_SSPRIS_OFFSET, 0x0018 
       @ .equ SPI1_SSPRIS_TXRIS [3:3]    Gives the raw interrupt state, prior to masking, of the SSPTXINTR interrupt 
       @ .equ SPI1_SSPRIS_RXRIS [2:2]    Gives the raw interrupt state, prior to masking, of the SSPRXINTR interrupt 
       @ .equ SPI1_SSPRIS_RTRIS [1:1]    Gives the raw interrupt state, prior to masking, of the SSPRTINTR interrupt 
       @ .equ SPI1_SSPRIS_RORRIS [0:0]    Gives the raw interrupt state, prior to masking, of the SSPRORINTR interrupt 
 
    .equ SPI1_SSPMIS_OFFSET, 0x001c 
       @ .equ SPI1_SSPMIS_TXMIS [3:3]    Gives the transmit FIFO masked interrupt state, after masking, of the SSPTXINTR interrupt 
       @ .equ SPI1_SSPMIS_RXMIS [2:2]    Gives the receive FIFO masked interrupt state, after masking, of the SSPRXINTR interrupt 
       @ .equ SPI1_SSPMIS_RTMIS [1:1]    Gives the receive timeout masked interrupt state, after masking, of the SSPRTINTR interrupt 
       @ .equ SPI1_SSPMIS_RORMIS [0:0]    Gives the receive over run masked interrupt status, after masking, of the SSPRORINTR interrupt 
 
    .equ SPI1_SSPICR_OFFSET, 0x0020 
       @ .equ SPI1_SSPICR_RTIC [1:1]    Clears the SSPRTINTR interrupt 
       @ .equ SPI1_SSPICR_RORIC [0:0]    Clears the SSPRORINTR interrupt 
 
    .equ SPI1_SSPDMACR_OFFSET, 0x0024 
       @ .equ SPI1_SSPDMACR_TXDMAE [1:1]    Transmit DMA Enable. If this bit is set to 1, DMA for the transmit FIFO is enabled. 
       @ .equ SPI1_SSPDMACR_RXDMAE [0:0]    Receive DMA Enable. If this bit is set to 1, DMA for the receive FIFO is enabled. 
 
    .equ SPI1_SSPPERIPHID0_OFFSET, 0x0fe0 
       @ .equ SPI1_SSPPERIPHID0_PARTNUMBER0 [7:0]    These bits read back as 0x22 
 
    .equ SPI1_SSPPERIPHID1_OFFSET, 0x0fe4 
       @ .equ SPI1_SSPPERIPHID1_DESIGNER0 [7:4]    These bits read back as 0x1 
       @ .equ SPI1_SSPPERIPHID1_PARTNUMBER1 [3:0]    These bits read back as 0x0 
 
    .equ SPI1_SSPPERIPHID2_OFFSET, 0x0fe8 
       @ .equ SPI1_SSPPERIPHID2_REVISION [7:4]    These bits return the peripheral revision 
       @ .equ SPI1_SSPPERIPHID2_DESIGNER1 [3:0]    These bits read back as 0x4 
 
    .equ SPI1_SSPPERIPHID3_OFFSET, 0x0fec 
       @ .equ SPI1_SSPPERIPHID3_CONFIGURATION [7:0]    These bits read back as 0x00 
 
    .equ SPI1_SSPPCELLID0_OFFSET, 0x0ff0 
       @ .equ SPI1_SSPPCELLID0_SSPPCELLID0 [7:0]    These bits read back as 0x0D 
 
    .equ SPI1_SSPPCELLID1_OFFSET, 0x0ff4 
       @ .equ SPI1_SSPPCELLID1_SSPPCELLID1 [7:0]    These bits read back as 0xF0 
 
    .equ SPI1_SSPPCELLID2_OFFSET, 0x0ff8 
       @ .equ SPI1_SSPPCELLID2_SSPPCELLID2 [7:0]    These bits read back as 0x05 
 
    .equ SPI1_SSPPCELLID3_OFFSET, 0x0ffc 
       @ .equ SPI1_SSPPCELLID3_SSPPCELLID3 [7:0]    These bits read back as 0xB1 
 

@=========================== I2C0 ===========================@
.equ I2C0_BASE, 0x40044000 
    .equ I2C0_IC_CON_OFFSET, 0x0000 
       @ .equ I2C0_IC_CON_STOP_DET_IF_MASTER_ACTIVE [10:10]    Master issues the STOP_DET interrupt irrespective of whether master is active or not 
       @ .equ I2C0_IC_CON_RX_FIFO_FULL_HLD_CTRL [9:9]    This bit controls whether DW_apb_i2c should hold the bus when the Rx FIFO is physically full to its RX_BUFFER_DEPTH, as described in the IC_RX_FULL_HLD_BUS_EN parameter.\n\n  Reset value: 0x0. 
       @ .equ I2C0_IC_CON_TX_EMPTY_CTRL [8:8]    This bit controls the generation of the TX_EMPTY interrupt, as described in the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0. 
       @ .equ I2C0_IC_CON_STOP_DET_IFADDRESSED [7:7]    In slave mode: - 1'b1: issues the STOP_DET interrupt only when it is addressed. - 1'b0: issues the STOP_DET irrespective of whether it's addressed or not. Reset value: 0x0\n\n  NOTE: During a general call address, this slave does not issue the STOP_DET interrupt if STOP_DET_IF_ADDRESSED = 1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. 
       @ .equ I2C0_IC_CON_IC_SLAVE_DISABLE [6:6]    This bit controls whether I2C has its slave disabled, which means once the presetn signal is applied, then this bit is set and the slave is disabled.\n\n  If this bit is set slave is disabled, DW_apb_i2c functions only as a master and does not perform any action that requires a slave.\n\n  NOTE: Software should ensure that if this bit is written with 0, then bit 0 should also be written with a 0. 
       @ .equ I2C0_IC_CON_IC_RESTART_EN [5:5]    Determines whether RESTART conditions may be sent when acting as a master. Some older slaves do not support handling RESTART conditions; however, RESTART conditions are used in several DW_apb_i2c operations. When RESTART is disabled, the master is prohibited from performing the following functions: - Sending a START BYTE - Performing any high-speed mode operation - High-speed mode operation - Performing direction changes in combined format mode - Performing a read operation with a 10-bit address By replacing RESTART condition followed by a STOP and a subsequent START condition, split operations are broken down into multiple DW_apb_i2c transfers. If the above operations are performed, it will result in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register.\n\n  Reset value: ENABLED 
       @ .equ I2C0_IC_CON_IC_10BITADDR_MASTER [4:4]    Controls whether the DW_apb_i2c starts its transfers in 7- or 10-bit addressing mode when acting as a master. - 0: 7-bit addressing - 1: 10-bit addressing 
       @ .equ I2C0_IC_CON_IC_10BITADDR_SLAVE [3:3]    When acting as a slave, this bit controls whether the DW_apb_i2c responds to 7- or 10-bit addresses. - 0: 7-bit addressing. The DW_apb_i2c ignores transactions that involve 10-bit addressing; for 7-bit addressing, only the lower 7 bits of the IC_SAR register are compared. - 1: 10-bit addressing. The DW_apb_i2c responds to only 10-bit addressing transfers that match the full 10 bits of the IC_SAR register. 
       @ .equ I2C0_IC_CON_SPEED [2:1]    These bits control at which speed the DW_apb_i2c operates; its setting is relevant only if one is operating the DW_apb_i2c in master mode. Hardware protects against illegal values being programmed by software. These bits must be programmed appropriately for slave mode also, as it is used to capture correct value of spike filter as per the speed mode.\n\n  This register should be programmed only with a value in the range of 1 to IC_MAX_SPEED_MODE; otherwise, hardware updates this register with the value of IC_MAX_SPEED_MODE.\n\n  1: standard mode 100 kbit/s\n\n  2: fast mode <=400 kbit/s or fast mode plus <=1000Kbit/s\n\n  3: high speed mode 3.4 Mbit/s\n\n  Note: This field is not applicable when IC_ULTRA_FAST_MODE=1 
       @ .equ I2C0_IC_CON_MASTER_MODE [0:0]    This bit controls whether the DW_apb_i2c master is enabled.\n\n  NOTE: Software should ensure that if this bit is written with '1' then bit 6 should also be written with a '1'. 
 
    .equ I2C0_IC_TAR_OFFSET, 0x0004 
       @ .equ I2C0_IC_TAR_SPECIAL [11:11]    This bit indicates whether software performs a Device-ID or General Call or START BYTE command. - 0: ignore bit 10 GC_OR_START and use IC_TAR normally - 1: perform special I2C command as specified in Device_ID or GC_OR_START bit Reset value: 0x0 
       @ .equ I2C0_IC_TAR_GC_OR_START [10:10]    If bit 11 SPECIAL is set to 1 and bit 13Device-ID is set to 0, then this bit indicates whether a General Call or START byte command is to be performed by the DW_apb_i2c. - 0: General Call Address - after issuing a General Call, only writes may be performed. Attempting to issue a read command results in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register. The DW_apb_i2c remains in General Call mode until the SPECIAL bit value bit 11 is cleared. - 1: START BYTE Reset value: 0x0 
       @ .equ I2C0_IC_TAR_IC_TAR [9:0]    This is the target address for any master transaction. When transmitting a General Call, these bits are ignored. To generate a START BYTE, the CPU needs to write only once into these bits.\n\n  If the IC_TAR and IC_SAR are the same, loopback exists but the FIFOs are shared between master and slave, so full loopback is not feasible. Only one direction loopback mode is supported simplex, not duplex. A master cannot transmit to itself; it can transmit to only a slave. 
 
    .equ I2C0_IC_SAR_OFFSET, 0x0008 
       @ .equ I2C0_IC_SAR_IC_SAR [9:0]    The IC_SAR holds the slave address when the I2C is operating as a slave. For 7-bit addressing, only IC_SAR[6:0] is used.\n\n  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  Note: The default values cannot be any of the reserved address locations: that is, 0x00 to 0x07, or 0x78 to 0x7f. The correct operation of the device is not guaranteed if you program the IC_SAR or IC_TAR to a reserved value. Refer to <<table_I2C_firstbyte_bit_defs>> for a complete list of these reserved values. 
 
    .equ I2C0_IC_DATA_CMD_OFFSET, 0x0010 
       @ .equ I2C0_IC_DATA_CMD_FIRST_DATA_BYTE [11:11]    Indicates the first data byte received after the address phase for receive transfer in Master receiver or Slave receiver mode.\n\n  Reset value : 0x0\n\n  NOTE: In case of APB_DATA_WIDTH=8,\n\n  1. The user has to perform two APB Reads to IC_DATA_CMD in order to get status on 11 bit.\n\n  2. In order to read the 11 bit, the user has to perform the first data byte read [7:0] offset 0x10 and then perform the second read [15:8] offset 0x11 in order to know the status of 11 bit whether the data received in previous read is a first data byte or not.\n\n  3. The 11th bit is an optional read field, user can ignore 2nd byte read [15:8] offset 0x11 if not interested in FIRST_DATA_BYTE status. 
       @ .equ I2C0_IC_DATA_CMD_RESTART [10:10]    This bit controls whether a RESTART is issued before the byte is sent or received.\n\n  1 - If IC_RESTART_EN is 1, a RESTART is issued before the data is sent/received according to the value of CMD, regardless of whether or not the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.\n\n  0 - If IC_RESTART_EN is 1, a RESTART is issued only if the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_DATA_CMD_STOP [9:9]    This bit controls whether a STOP is issued after the byte is sent or received.\n\n  - 1 - STOP is issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master immediately tries to start a new transfer by issuing a START and arbitrating for the bus. - 0 - STOP is not issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master continues the current transfer by sending/receiving data bytes according to the value of the CMD bit. If the Tx FIFO is empty, the master holds the SCL line low and stalls the bus until a new command is available in the Tx FIFO. Reset value: 0x0 
       @ .equ I2C0_IC_DATA_CMD_CMD [8:8]    This bit controls whether a read or a write is performed. This bit does not control the direction when the DW_apb_i2con acts as a slave. It controls only the direction when it acts as a master.\n\n  When a command is entered in the TX FIFO, this bit distinguishes the write and read commands. In slave-receiver mode, this bit is a 'don't care' because writes to this register are not required. In slave-transmitter mode, a '0' indicates that the data in IC_DATA_CMD is to be transmitted.\n\n  When programming this bit, you should remember the following: attempting to perform a read operation after a General Call command has been sent results in a TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, unless bit 11 SPECIAL in the IC_TAR register has been cleared. If a '1' is written to this bit after receiving a RD_REQ interrupt, then a TX_ABRT interrupt occurs.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_DATA_CMD_DAT [7:0]    This register contains the data to be transmitted or received on the I2C bus. If you are writing to this register and want to perform a read, bits 7:0 DAT are ignored by the DW_apb_i2c. However, when you read this register, these bits return the value of data received on the DW_apb_i2c interface.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_SS_SCL_HCNT_OFFSET, 0x0014 
       @ .equ I2C0_IC_SS_SCL_HCNT_IC_SS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'.\n\n  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed.\n\n  NOTE: This register must not be programmed to a value higher than 65525, because DW_apb_i2c uses a 16-bit counter to flag an I2C bus idle condition when this counter reaches a value of IC_SS_SCL_HCNT + 10. 
 
    .equ I2C0_IC_SS_SCL_LCNT_OFFSET, 0x0018 
       @ .equ I2C0_IC_SS_SCL_LCNT_IC_SS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'\n\n  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted, results in 8 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of DW_apb_i2c. The lower byte must be programmed first, and then the upper byte is programmed. 
 
    .equ I2C0_IC_FS_SCL_HCNT_OFFSET, 0x001c 
       @ .equ I2C0_IC_FS_SCL_HCNT_IC_FS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for fast mode or fast mode plus. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.\n\n  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard. This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH == 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. 
 
    .equ I2C0_IC_FS_SCL_LCNT_OFFSET, 0x0020 
       @ .equ I2C0_IC_FS_SCL_LCNT_IC_FS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for fast speed. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.\n\n  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard.\n\n  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted results in 8 being set. For designs with APB_DATA_WIDTH = 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. If the value is less than 8 then the count value gets changed to 8. 
 
    .equ I2C0_IC_INTR_STAT_OFFSET, 0x002c 
       @ .equ I2C0_IC_INTR_STAT_R_MASTER_ON_HOLD [13:13]    See IC_RAW_INTR_STAT for a detailed description of R_MASTER_ON_HOLD bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_RESTART_DET [12:12]    See IC_RAW_INTR_STAT for a detailed description of R_RESTART_DET bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_GEN_CALL [11:11]    See IC_RAW_INTR_STAT for a detailed description of R_GEN_CALL bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_START_DET [10:10]    See IC_RAW_INTR_STAT for a detailed description of R_START_DET bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_STOP_DET [9:9]    See IC_RAW_INTR_STAT for a detailed description of R_STOP_DET bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_ACTIVITY [8:8]    See IC_RAW_INTR_STAT for a detailed description of R_ACTIVITY bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_RX_DONE [7:7]    See IC_RAW_INTR_STAT for a detailed description of R_RX_DONE bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_TX_ABRT [6:6]    See IC_RAW_INTR_STAT for a detailed description of R_TX_ABRT bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_RD_REQ [5:5]    See IC_RAW_INTR_STAT for a detailed description of R_RD_REQ bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_TX_EMPTY [4:4]    See IC_RAW_INTR_STAT for a detailed description of R_TX_EMPTY bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_TX_OVER [3:3]    See IC_RAW_INTR_STAT for a detailed description of R_TX_OVER bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_RX_FULL [2:2]    See IC_RAW_INTR_STAT for a detailed description of R_RX_FULL bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_RX_OVER [1:1]    See IC_RAW_INTR_STAT for a detailed description of R_RX_OVER bit.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_STAT_R_RX_UNDER [0:0]    See IC_RAW_INTR_STAT for a detailed description of R_RX_UNDER bit.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_INTR_MASK_OFFSET, 0x0030 
       @ .equ I2C0_IC_INTR_MASK_M_MASTER_ON_HOLD_READ_ONLY [13:13]    This M_MASTER_ON_HOLD_read_only bit masks the R_MASTER_ON_HOLD interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_MASK_M_RESTART_DET [12:12]    This bit masks the R_RESTART_DET interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_MASK_M_GEN_CALL [11:11]    This bit masks the R_GEN_CALL interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_START_DET [10:10]    This bit masks the R_START_DET interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_MASK_M_STOP_DET [9:9]    This bit masks the R_STOP_DET interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_MASK_M_ACTIVITY [8:8]    This bit masks the R_ACTIVITY interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_INTR_MASK_M_RX_DONE [7:7]    This bit masks the R_RX_DONE interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_TX_ABRT [6:6]    This bit masks the R_TX_ABRT interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_RD_REQ [5:5]    This bit masks the R_RD_REQ interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_TX_EMPTY [4:4]    This bit masks the R_TX_EMPTY interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_TX_OVER [3:3]    This bit masks the R_TX_OVER interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_RX_FULL [2:2]    This bit masks the R_RX_FULL interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_RX_OVER [1:1]    This bit masks the R_RX_OVER interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C0_IC_INTR_MASK_M_RX_UNDER [0:0]    This bit masks the R_RX_UNDER interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
 
    .equ I2C0_IC_RAW_INTR_STAT_OFFSET, 0x0034 
       @ .equ I2C0_IC_RAW_INTR_STAT_MASTER_ON_HOLD [13:13]    Indicates whether master is holding the bus and TX FIFO is empty. Enabled only when I2C_DYNAMIC_TAR_UPDATE=1 and IC_EMPTYFIFO_HOLD_MASTER_EN=1.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_RESTART_DET [12:12]    Indicates whether a RESTART condition has occurred on the I2C interface when DW_apb_i2c is operating in Slave mode and the slave is being addressed. Enabled only when IC_SLV_RESTART_DET_EN=1.\n\n  Note: However, in high-speed mode or during a START BYTE transfer, the RESTART comes before the address field as per the I2C protocol. In this case, the slave is not the addressed slave when the RESTART is issued, therefore DW_apb_i2c does not generate the RESTART_DET interrupt.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_GEN_CALL [11:11]    Set only when a General Call address is received and it is acknowledged. It stays set until it is cleared either by disabling DW_apb_i2c or when the CPU reads bit 0 of the IC_CLR_GEN_CALL register. DW_apb_i2c stores the received data in the Rx buffer.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_START_DET [10:10]    Indicates whether a START or RESTART condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_STOP_DET [9:9]    Indicates whether a STOP condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.\n\n  In Slave Mode: - If IC_CON[7]=1'b1 STOP_DET_IFADDRESSED, the STOP_DET interrupt will be issued only if slave is addressed. Note: During a general call address, this slave does not issue a STOP_DET interrupt if STOP_DET_IF_ADDRESSED=1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. - If IC_CON[7]=1'b0 STOP_DET_IFADDRESSED, the STOP_DET interrupt is issued irrespective of whether it is being addressed. In Master Mode: - If IC_CON[10]=1'b1 STOP_DET_IF_MASTER_ACTIVE,the STOP_DET interrupt will be issued only if Master is active. - If IC_CON[10]=1'b0 STOP_DET_IFADDRESSED,the STOP_DET interrupt will be issued irrespective of whether master is active or not. Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_ACTIVITY [8:8]    This bit captures DW_apb_i2c activity and stays set until it is cleared. There are four ways to clear it: - Disabling the DW_apb_i2c - Reading the IC_CLR_ACTIVITY register - Reading the IC_CLR_INTR register - System reset Once this bit is set, it stays set unless one of the four methods is used to clear it. Even if the DW_apb_i2c module is idle, this bit remains set until cleared, indicating that there was activity on the bus.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_DONE [7:7]    When the DW_apb_i2c is acting as a slave-transmitter, this bit is set to 1 if the master does not acknowledge a transmitted byte. This occurs on the last byte of the transmission, indicating that the transmission is done.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_TX_ABRT [6:6]    This bit indicates if DW_apb_i2c, as an I2C transmitter, is unable to complete the intended actions on the contents of the transmit FIFO. This situation can occur both as an I2C master or an I2C slave, and is referred to as a 'transmit abort'. When this bit is set to 1, the IC_TX_ABRT_SOURCE register indicates the reason why the transmit abort takes places.\n\n  Note: The DW_apb_i2c flushes/resets/empties the TX_FIFO and RX_FIFO whenever there is a transmit abort caused by any of the events tracked by the IC_TX_ABRT_SOURCE register. The FIFOs remains in this flushed state until the register IC_CLR_TX_ABRT is read. Once this read is performed, the Tx FIFO is then ready to accept more data bytes from the APB interface.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_RD_REQ [5:5]    This bit is set to 1 when DW_apb_i2c is acting as a slave and another I2C master is attempting to read data from DW_apb_i2c. The DW_apb_i2c holds the I2C bus in a wait state SCL=0 until this interrupt is serviced, which means that the slave has been addressed by a remote master that is asking for data to be transferred. The processor must respond to this interrupt and then write the requested data to the IC_DATA_CMD register. This bit is set to 0 just after the processor reads the IC_CLR_RD_REQ register.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_TX_EMPTY [4:4]    The behavior of the TX_EMPTY interrupt status differs based on the TX_EMPTY_CTRL selection in the IC_CON register. - When TX_EMPTY_CTRL = 0: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register. - When TX_EMPTY_CTRL = 1: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register and the transmission of the address/data from the internal shift register for the most recently popped command is completed. It is automatically cleared by hardware when the buffer level goes above the threshold. When IC_ENABLE[0] is set to 0, the TX FIFO is flushed and held in reset. There the TX FIFO looks like it has no data within it, so this bit is set to 1, provided there is activity in the master or slave state machines. When there is no longer any activity, then with ic_en=0, this bit is set to 0.\n\n  Reset value: 0x0. 
       @ .equ I2C0_IC_RAW_INTR_STAT_TX_OVER [3:3]    Set during transmit if the transmit buffer is filled to IC_TX_BUFFER_DEPTH and the processor attempts to issue another I2C command by writing to the IC_DATA_CMD register. When the module is disabled, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_FULL [2:2]    Set when the receive buffer reaches or goes above the RX_TL threshold in the IC_RX_TL register. It is automatically cleared by hardware when buffer level goes below the threshold. If the module is disabled IC_ENABLE[0]=0, the RX FIFO is flushed and held in reset; therefore the RX FIFO is not full. So this bit is cleared once the IC_ENABLE bit 0 is programmed with a 0, regardless of the activity that continues.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_OVER [1:1]    Set if the receive buffer is completely filled to IC_RX_BUFFER_DEPTH and an additional byte is received from an external I2C device. The DW_apb_i2c acknowledges this, but any data bytes received after the FIFO is full are lost. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.\n\n  Note: If bit 9 of the IC_CON register RX_FIFO_FULL_HLD_CTRL is programmed to HIGH, then the RX_OVER interrupt never occurs, because the Rx FIFO never overflows.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_UNDER [0:0]    Set if the processor attempts to read the receive buffer when it is empty by reading from the IC_DATA_CMD register. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_RX_TL_OFFSET, 0x0038 
       @ .equ I2C0_IC_RX_TL_RX_TL [7:0]    Receive FIFO Threshold Level.\n\n  Controls the level of entries or above that triggers the RX_FULL interrupt bit 2 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that hardware does not allow this value to be set to a value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 1 entry, and a value of 255 sets the threshold for 256 entries. 
 
    .equ I2C0_IC_TX_TL_OFFSET, 0x003c 
       @ .equ I2C0_IC_TX_TL_TX_TL [7:0]    Transmit FIFO Threshold Level.\n\n  Controls the level of entries or below that trigger the TX_EMPTY interrupt bit 4 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that it may not be set to value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 0 entries, and a value of 255 sets the threshold for 255 entries. 
 
    .equ I2C0_IC_CLR_INTR_OFFSET, 0x0040 
       @ .equ I2C0_IC_CLR_INTR_CLR_INTR [0:0]    Read this register to clear the combined interrupt, all individual interrupts, and the IC_TX_ABRT_SOURCE register. This bit does not clear hardware clearable interrupts but software clearable interrupts. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RX_UNDER_OFFSET, 0x0044 
       @ .equ I2C0_IC_CLR_RX_UNDER_CLR_RX_UNDER [0:0]    Read this register to clear the RX_UNDER interrupt bit 0 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RX_OVER_OFFSET, 0x0048 
       @ .equ I2C0_IC_CLR_RX_OVER_CLR_RX_OVER [0:0]    Read this register to clear the RX_OVER interrupt bit 1 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_TX_OVER_OFFSET, 0x004c 
       @ .equ I2C0_IC_CLR_TX_OVER_CLR_TX_OVER [0:0]    Read this register to clear the TX_OVER interrupt bit 3 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RD_REQ_OFFSET, 0x0050 
       @ .equ I2C0_IC_CLR_RD_REQ_CLR_RD_REQ [0:0]    Read this register to clear the RD_REQ interrupt bit 5 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_TX_ABRT_OFFSET, 0x0054 
       @ .equ I2C0_IC_CLR_TX_ABRT_CLR_TX_ABRT [0:0]    Read this register to clear the TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, and the IC_TX_ABRT_SOURCE register. This also releases the TX FIFO from the flushed/reset state, allowing more writes to the TX FIFO. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_RX_DONE_OFFSET, 0x0058 
       @ .equ I2C0_IC_CLR_RX_DONE_CLR_RX_DONE [0:0]    Read this register to clear the RX_DONE interrupt bit 7 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_ACTIVITY_OFFSET, 0x005c 
       @ .equ I2C0_IC_CLR_ACTIVITY_CLR_ACTIVITY [0:0]    Reading this register clears the ACTIVITY interrupt if the I2C is not active anymore. If the I2C module is still active on the bus, the ACTIVITY interrupt bit continues to be set. It is automatically cleared by hardware if the module is disabled and if there is no further activity on the bus. The value read from this register to get status of the ACTIVITY interrupt bit 8 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_STOP_DET_OFFSET, 0x0060 
       @ .equ I2C0_IC_CLR_STOP_DET_CLR_STOP_DET [0:0]    Read this register to clear the STOP_DET interrupt bit 9 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_START_DET_OFFSET, 0x0064 
       @ .equ I2C0_IC_CLR_START_DET_CLR_START_DET [0:0]    Read this register to clear the START_DET interrupt bit 10 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_CLR_GEN_CALL_OFFSET, 0x0068 
       @ .equ I2C0_IC_CLR_GEN_CALL_CLR_GEN_CALL [0:0]    Read this register to clear the GEN_CALL interrupt bit 11 of IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_ENABLE_OFFSET, 0x006c 
       @ .equ I2C0_IC_ENABLE_TX_CMD_BLOCK [2:2]    In Master mode: - 1'b1: Blocks the transmission of data on I2C bus even if Tx FIFO has data to transmit. - 1'b0: The transmission of data starts on I2C bus automatically, as soon as the first data is available in the Tx FIFO. Note: To block the execution of Master commands, set the TX_CMD_BLOCK bit only when Tx FIFO is empty IC_STATUS[2]==1 and Master is in Idle state IC_STATUS[5] == 0. Any further commands put in the Tx FIFO are not executed until TX_CMD_BLOCK bit is unset. Reset value: IC_TX_CMD_BLOCK_DEFAULT 
       @ .equ I2C0_IC_ENABLE_ABORT [1:1]    When set, the controller initiates the transfer abort. - 0: ABORT not initiated or ABORT done - 1: ABORT operation in progress The software can abort the I2C transfer in master mode by setting this bit. The software can set this bit only when ENABLE is already set; otherwise, the controller ignores any write to ABORT bit. The software cannot clear the ABORT bit once set. In response to an ABORT, the controller issues a STOP and flushes the Tx FIFO after completing the current transfer, then sets the TX_ABORT interrupt after the abort operation. The ABORT bit is cleared automatically after the abort operation.\n\n  For a detailed description on how to abort I2C transfers, refer to 'Aborting I2C Transfers'.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_ENABLE_ENABLE [0:0]    Controls whether the DW_apb_i2c is enabled. - 0: Disables DW_apb_i2c TX and RX FIFOs are held in an erased state - 1: Enables DW_apb_i2c Software can disable DW_apb_i2c while it is active. However, it is important that care be taken to ensure that DW_apb_i2c is disabled properly. A recommended procedure is described in 'Disabling DW_apb_i2c'.\n\n  When DW_apb_i2c is disabled, the following occurs: - The TX FIFO and RX FIFO get flushed. - Status bits in the IC_INTR_STAT register are still active until DW_apb_i2c goes into IDLE state. If the module is transmitting, it stops as well as deletes the contents of the transmit buffer after the current transfer is complete. If the module is receiving, the DW_apb_i2c stops the current transfer at the end of the current byte and does not acknowledge the transfer.\n\n  In systems with asynchronous pclk and ic_clk when IC_CLK_TYPE parameter set to asynchronous 1, there is a two ic_clk delay when enabling or disabling the DW_apb_i2c. For a detailed description on how to disable DW_apb_i2c, refer to 'Disabling DW_apb_i2c'\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_STATUS_OFFSET, 0x0070 
       @ .equ I2C0_IC_STATUS_SLV_ACTIVITY [6:6]    Slave FSM Activity Status. When the Slave Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Slave FSM is in IDLE state so the Slave part of DW_apb_i2c is not Active - 1: Slave FSM is not in IDLE state so the Slave part of DW_apb_i2c is Active Reset value: 0x0 
       @ .equ I2C0_IC_STATUS_MST_ACTIVITY [5:5]    Master FSM Activity Status. When the Master Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Master FSM is in IDLE state so the Master part of DW_apb_i2c is not Active - 1: Master FSM is not in IDLE state so the Master part of DW_apb_i2c is Active Note: IC_STATUS[0]-that is, ACTIVITY bit-is the OR of SLV_ACTIVITY and MST_ACTIVITY bits.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_STATUS_RFF [4:4]    Receive FIFO Completely Full. When the receive FIFO is completely full, this bit is set. When the receive FIFO contains one or more empty location, this bit is cleared. - 0: Receive FIFO is not full - 1: Receive FIFO is full Reset value: 0x0 
       @ .equ I2C0_IC_STATUS_RFNE [3:3]    Receive FIFO Not Empty. This bit is set when the receive FIFO contains one or more entries; it is cleared when the receive FIFO is empty. - 0: Receive FIFO is empty - 1: Receive FIFO is not empty Reset value: 0x0 
       @ .equ I2C0_IC_STATUS_TFE [2:2]    Transmit FIFO Completely Empty. When the transmit FIFO is completely empty, this bit is set. When it contains one or more valid entries, this bit is cleared. This bit field does not request an interrupt. - 0: Transmit FIFO is not empty - 1: Transmit FIFO is empty Reset value: 0x1 
       @ .equ I2C0_IC_STATUS_TFNF [1:1]    Transmit FIFO Not Full. Set when the transmit FIFO contains one or more empty locations, and is cleared when the FIFO is full. - 0: Transmit FIFO is full - 1: Transmit FIFO is not full Reset value: 0x1 
       @ .equ I2C0_IC_STATUS_ACTIVITY [0:0]    I2C Activity Status. Reset value: 0x0 
 
    .equ I2C0_IC_TXFLR_OFFSET, 0x0074 
       @ .equ I2C0_IC_TXFLR_TXFLR [4:0]    Transmit FIFO Level. Contains the number of valid data entries in the transmit FIFO.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_RXFLR_OFFSET, 0x0078 
       @ .equ I2C0_IC_RXFLR_RXFLR [4:0]    Receive FIFO Level. Contains the number of valid data entries in the receive FIFO.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_SDA_HOLD_OFFSET, 0x007c 
       @ .equ I2C0_IC_SDA_HOLD_IC_SDA_RX_HOLD [23:16]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a receiver.\n\n  Reset value: IC_DEFAULT_SDA_HOLD[23:16]. 
       @ .equ I2C0_IC_SDA_HOLD_IC_SDA_TX_HOLD [15:0]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a transmitter.\n\n  Reset value: IC_DEFAULT_SDA_HOLD[15:0]. 
 
    .equ I2C0_IC_TX_ABRT_SOURCE_OFFSET, 0x0080 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_TX_FLUSH_CNT [31:23]    This field indicates the number of Tx FIFO Data Commands which are flushed due to TX_ABRT interrupt. It is cleared whenever I2C is disabled.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_USER_ABRT [16:16]    This is a master-mode-only bit. Master has detected the transfer abort IC_ENABLE[1]\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SLVRD_INTX [15:15]    1: When the processor side responds to a slave mode request for data to be transmitted to a remote master and user writes a 1 in CMD bit 8 of IC_DATA_CMD register.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SLV_ARBLOST [14:14]    This field indicates that a Slave has lost the bus while transmitting data to a remote master. IC_TX_ABRT_SOURCE[12] is set at the same time. Note: Even though the slave never 'owns' the bus, something could go wrong on the bus. This is a fail safe check. For instance, during a data transmission at the low-to-high transition of SCL, if what is on the data bus is not what is supposed to be transmitted, then DW_apb_i2c no longer own the bus.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SLVFLUSH_TXFIFO [13:13]    This field specifies that the Slave has received a read command and some data exists in the TX FIFO, so the slave issues a TX_ABRT interrupt to flush old data in TX FIFO.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ARB_LOST [12:12]    This field specifies that the Master has lost arbitration, or if IC_TX_ABRT_SOURCE[14] is also set, then the slave transmitter has lost arbitration.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_MASTER_DIS [11:11]    This field indicates that the User tries to initiate a Master operation with the Master mode disabled.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_10B_RD_NORSTRT [10:10]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the master sends a read command in 10-bit addressing mode.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Receiver 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SBYTE_NORSTRT [9:9]    To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; restart must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10]. Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, bit 9 clears for one cycle and then gets reasserted. When this field is set to 1, the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to send a START Byte.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_HS_NORSTRT [8:8]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to use the master to transfer data in High Speed mode.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SBYTE_ACKDET [7:7]    This field indicates that the Master has sent a START Byte and the START Byte was acknowledged wrong behavior.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_HS_ACKDET [6:6]    This field indicates that the Master is in High Speed mode and the High Speed Master code was acknowledged wrong behavior.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_GCALL_READ [5:5]    This field indicates that DW_apb_i2c in the master mode has sent a General Call but the user programmed the byte following the General Call to be a read from the bus IC_DATA_CMD[9] is set to 1.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_GCALL_NOACK [4:4]    This field indicates that DW_apb_i2c in master mode has sent a General Call and no slave on the bus acknowledged the General Call.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_TXDATA_NOACK [3:3]    This field indicates the master-mode only bit. When the master receives an acknowledgement for the address, but when it sends data bytes following the address, it did not receive an acknowledge from the remote slaves.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_10ADDR2_NOACK [2:2]    This field indicates that the Master is in 10-bit address mode and that the second address byte of the 10-bit address was not acknowledged by any slave.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_10ADDR1_NOACK [1:1]    This field indicates that the Master is in 10-bit address mode and the first 10-bit address byte was not acknowledged by any slave.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_7B_ADDR_NOACK [0:0]    This field indicates that the Master is in 7-bit addressing mode and the address sent was not acknowledged by any slave.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
 
    .equ I2C0_IC_SLV_DATA_NACK_ONLY_OFFSET, 0x0084 
       @ .equ I2C0_IC_SLV_DATA_NACK_ONLY_NACK [0:0]    Generate NACK. This NACK generation only occurs when DW_apb_i2c is a slave-receiver. If this register is set to a value of 1, it can only generate a NACK after a data byte is received; hence, the data transfer is aborted and the data received is not pushed to the receive buffer.\n\n  When the register is set to a value of 0, it generates NACK/ACK, depending on normal criteria. - 1: generate NACK after data byte received - 0: generate NACK/ACK normally Reset value: 0x0 
 
    .equ I2C0_IC_DMA_CR_OFFSET, 0x0088 
       @ .equ I2C0_IC_DMA_CR_TDMAE [1:1]    Transmit DMA Enable. This bit enables/disables the transmit FIFO DMA channel. Reset value: 0x0 
       @ .equ I2C0_IC_DMA_CR_RDMAE [0:0]    Receive DMA Enable. This bit enables/disables the receive FIFO DMA channel. Reset value: 0x0 
 
    .equ I2C0_IC_DMA_TDLR_OFFSET, 0x008c 
       @ .equ I2C0_IC_DMA_TDLR_DMATDL [3:0]    Transmit Data Level. This bit field controls the level at which a DMA request is made by the transmit logic. It is equal to the watermark level; that is, the dma_tx_req signal is generated when the number of valid data entries in the transmit FIFO is equal to or below this field value, and TDMAE = 1.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_DMA_RDLR_OFFSET, 0x0090 
       @ .equ I2C0_IC_DMA_RDLR_DMARDL [3:0]    Receive Data Level. This bit field controls the level at which a DMA request is made by the receive logic. The watermark level = DMARDL+1; that is, dma_rx_req is generated when the number of valid data entries in the receive FIFO is equal to or more than this field value + 1, and RDMAE =1. For instance, when DMARDL is 0, then dma_rx_req is asserted when 1 or more data entries are present in the receive FIFO.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_SDA_SETUP_OFFSET, 0x0094 
       @ .equ I2C0_IC_SDA_SETUP_SDA_SETUP [7:0]    SDA Setup. It is recommended that if the required delay is 1000ns, then for an ic_clk frequency of 10 MHz, IC_SDA_SETUP should be programmed to a value of 11. IC_SDA_SETUP must be programmed with a minimum value of 2. 
 
    .equ I2C0_IC_ACK_GENERAL_CALL_OFFSET, 0x0098 
       @ .equ I2C0_IC_ACK_GENERAL_CALL_ACK_GEN_CALL [0:0]    ACK General Call. When set to 1, DW_apb_i2c responds with a ACK by asserting ic_data_oe when it receives a General Call. Otherwise, DW_apb_i2c responds with a NACK by negating ic_data_oe. 
 
    .equ I2C0_IC_ENABLE_STATUS_OFFSET, 0x009c 
       @ .equ I2C0_IC_ENABLE_STATUS_SLV_RX_DATA_LOST [2:2]    Slave Received Data Lost. This bit indicates if a Slave-Receiver operation has been aborted with at least one data byte received from an I2C transfer due to the setting bit 0 of IC_ENABLE from 1 to 0. When read as 1, DW_apb_i2c is deemed to have been actively engaged in an aborted I2C transfer with matching address and the data phase of the I2C transfer has been entered, even though a data byte has been responded with a NACK.\n\n  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit is also set to 1.\n\n  When read as 0, DW_apb_i2c is deemed to have been disabled without being actively involved in the data phase of a Slave-Receiver transfer.\n\n  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_ENABLE_STATUS_SLV_DISABLED_WHILE_BUSY [1:1]    Slave Disabled While Busy Transmit, Receive. This bit indicates if a potential or active Slave operation has been aborted due to the setting bit 0 of the IC_ENABLE register from 1 to 0. This bit is set when the CPU writes a 0 to the IC_ENABLE register while:\n\n  a DW_apb_i2c is receiving the address byte of the Slave-Transmitter operation from a remote master;\n\n  OR,\n\n  b address and data bytes of the Slave-Receiver operation from a remote master.\n\n  When read as 1, DW_apb_i2c is deemed to have forced a NACK during any part of an I2C transfer, irrespective of whether the I2C address matches the slave address set in DW_apb_i2c IC_SAR register OR if the transfer is completed before IC_ENABLE is set to 0 but has not taken effect.\n\n  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit will also be set to 1.\n\n  When read as 0, DW_apb_i2c is deemed to have been disabled when there is master activity, or when the I2C bus is idle.\n\n  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.\n\n  Reset value: 0x0 
       @ .equ I2C0_IC_ENABLE_STATUS_IC_EN [0:0]    ic_en Status. This bit always reflects the value driven on the output port ic_en. - When read as 1, DW_apb_i2c is deemed to be in an enabled state. - When read as 0, DW_apb_i2c is deemed completely inactive. Note: The CPU can safely read this bit anytime. When this bit is read as 0, the CPU can safely read SLV_RX_DATA_LOST bit 2 and SLV_DISABLED_WHILE_BUSY bit 1.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_FS_SPKLEN_OFFSET, 0x00a0 
       @ .equ I2C0_IC_FS_SPKLEN_IC_FS_SPKLEN [7:0]    This register must be set before any I2C bus transaction can take place to ensure stable operation. This register sets the duration, measured in ic_clk cycles, of the longest spike in the SCL or SDA lines that will be filtered out by the spike suppression logic. This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect. The minimum valid value is 1; hardware prevents values less than this being written, and if attempted results in 1 being set. or more information, refer to 'Spike Suppression'. 
 
    .equ I2C0_IC_CLR_RESTART_DET_OFFSET, 0x00a8 
       @ .equ I2C0_IC_CLR_RESTART_DET_CLR_RESTART_DET [0:0]    Read this register to clear the RESTART_DET interrupt bit 12 of IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C0_IC_COMP_PARAM_1_OFFSET, 0x00f4 
       @ .equ I2C0_IC_COMP_PARAM_1_TX_BUFFER_DEPTH [23:16]    TX Buffer Depth = 16 
       @ .equ I2C0_IC_COMP_PARAM_1_RX_BUFFER_DEPTH [15:8]    RX Buffer Depth = 16 
       @ .equ I2C0_IC_COMP_PARAM_1_ADD_ENCODED_PARAMS [7:7]    Encoded parameters not visible 
       @ .equ I2C0_IC_COMP_PARAM_1_HAS_DMA [6:6]    DMA handshaking signals are enabled 
       @ .equ I2C0_IC_COMP_PARAM_1_INTR_IO [5:5]    COMBINED Interrupt outputs 
       @ .equ I2C0_IC_COMP_PARAM_1_HC_COUNT_VALUES [4:4]    Programmable count values for each mode. 
       @ .equ I2C0_IC_COMP_PARAM_1_MAX_SPEED_MODE [3:2]    MAX SPEED MODE = FAST MODE 
       @ .equ I2C0_IC_COMP_PARAM_1_APB_DATA_WIDTH [1:0]    APB data bus width is 32 bits 
 
    .equ I2C0_IC_COMP_VERSION_OFFSET, 0x00f8 
       @ .equ I2C0_IC_COMP_VERSION_IC_COMP_VERSION [31:0]     
 
    .equ I2C0_IC_COMP_TYPE_OFFSET, 0x00fc 
       @ .equ I2C0_IC_COMP_TYPE_IC_COMP_TYPE [31:0]    Designware Component Type number = 0x44_57_01_40. This assigned unique hex value is constant and is derived from the two ASCII letters 'DW' followed by a 16-bit unsigned number. 
 

@=========================== I2C1 ===========================@
.equ I2C1_BASE, 0x40048000 
    .equ I2C1_IC_CON_OFFSET, 0x0000 
       @ .equ I2C1_IC_CON_STOP_DET_IF_MASTER_ACTIVE [10:10]    Master issues the STOP_DET interrupt irrespective of whether master is active or not 
       @ .equ I2C1_IC_CON_RX_FIFO_FULL_HLD_CTRL [9:9]    This bit controls whether DW_apb_i2c should hold the bus when the Rx FIFO is physically full to its RX_BUFFER_DEPTH, as described in the IC_RX_FULL_HLD_BUS_EN parameter.\n\n  Reset value: 0x0. 
       @ .equ I2C1_IC_CON_TX_EMPTY_CTRL [8:8]    This bit controls the generation of the TX_EMPTY interrupt, as described in the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0. 
       @ .equ I2C1_IC_CON_STOP_DET_IFADDRESSED [7:7]    In slave mode: - 1'b1: issues the STOP_DET interrupt only when it is addressed. - 1'b0: issues the STOP_DET irrespective of whether it's addressed or not. Reset value: 0x0\n\n  NOTE: During a general call address, this slave does not issue the STOP_DET interrupt if STOP_DET_IF_ADDRESSED = 1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. 
       @ .equ I2C1_IC_CON_IC_SLAVE_DISABLE [6:6]    This bit controls whether I2C has its slave disabled, which means once the presetn signal is applied, then this bit is set and the slave is disabled.\n\n  If this bit is set slave is disabled, DW_apb_i2c functions only as a master and does not perform any action that requires a slave.\n\n  NOTE: Software should ensure that if this bit is written with 0, then bit 0 should also be written with a 0. 
       @ .equ I2C1_IC_CON_IC_RESTART_EN [5:5]    Determines whether RESTART conditions may be sent when acting as a master. Some older slaves do not support handling RESTART conditions; however, RESTART conditions are used in several DW_apb_i2c operations. When RESTART is disabled, the master is prohibited from performing the following functions: - Sending a START BYTE - Performing any high-speed mode operation - High-speed mode operation - Performing direction changes in combined format mode - Performing a read operation with a 10-bit address By replacing RESTART condition followed by a STOP and a subsequent START condition, split operations are broken down into multiple DW_apb_i2c transfers. If the above operations are performed, it will result in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register.\n\n  Reset value: ENABLED 
       @ .equ I2C1_IC_CON_IC_10BITADDR_MASTER [4:4]    Controls whether the DW_apb_i2c starts its transfers in 7- or 10-bit addressing mode when acting as a master. - 0: 7-bit addressing - 1: 10-bit addressing 
       @ .equ I2C1_IC_CON_IC_10BITADDR_SLAVE [3:3]    When acting as a slave, this bit controls whether the DW_apb_i2c responds to 7- or 10-bit addresses. - 0: 7-bit addressing. The DW_apb_i2c ignores transactions that involve 10-bit addressing; for 7-bit addressing, only the lower 7 bits of the IC_SAR register are compared. - 1: 10-bit addressing. The DW_apb_i2c responds to only 10-bit addressing transfers that match the full 10 bits of the IC_SAR register. 
       @ .equ I2C1_IC_CON_SPEED [2:1]    These bits control at which speed the DW_apb_i2c operates; its setting is relevant only if one is operating the DW_apb_i2c in master mode. Hardware protects against illegal values being programmed by software. These bits must be programmed appropriately for slave mode also, as it is used to capture correct value of spike filter as per the speed mode.\n\n  This register should be programmed only with a value in the range of 1 to IC_MAX_SPEED_MODE; otherwise, hardware updates this register with the value of IC_MAX_SPEED_MODE.\n\n  1: standard mode 100 kbit/s\n\n  2: fast mode <=400 kbit/s or fast mode plus <=1000Kbit/s\n\n  3: high speed mode 3.4 Mbit/s\n\n  Note: This field is not applicable when IC_ULTRA_FAST_MODE=1 
       @ .equ I2C1_IC_CON_MASTER_MODE [0:0]    This bit controls whether the DW_apb_i2c master is enabled.\n\n  NOTE: Software should ensure that if this bit is written with '1' then bit 6 should also be written with a '1'. 
 
    .equ I2C1_IC_TAR_OFFSET, 0x0004 
       @ .equ I2C1_IC_TAR_SPECIAL [11:11]    This bit indicates whether software performs a Device-ID or General Call or START BYTE command. - 0: ignore bit 10 GC_OR_START and use IC_TAR normally - 1: perform special I2C command as specified in Device_ID or GC_OR_START bit Reset value: 0x0 
       @ .equ I2C1_IC_TAR_GC_OR_START [10:10]    If bit 11 SPECIAL is set to 1 and bit 13Device-ID is set to 0, then this bit indicates whether a General Call or START byte command is to be performed by the DW_apb_i2c. - 0: General Call Address - after issuing a General Call, only writes may be performed. Attempting to issue a read command results in setting bit 6 TX_ABRT of the IC_RAW_INTR_STAT register. The DW_apb_i2c remains in General Call mode until the SPECIAL bit value bit 11 is cleared. - 1: START BYTE Reset value: 0x0 
       @ .equ I2C1_IC_TAR_IC_TAR [9:0]    This is the target address for any master transaction. When transmitting a General Call, these bits are ignored. To generate a START BYTE, the CPU needs to write only once into these bits.\n\n  If the IC_TAR and IC_SAR are the same, loopback exists but the FIFOs are shared between master and slave, so full loopback is not feasible. Only one direction loopback mode is supported simplex, not duplex. A master cannot transmit to itself; it can transmit to only a slave. 
 
    .equ I2C1_IC_SAR_OFFSET, 0x0008 
       @ .equ I2C1_IC_SAR_IC_SAR [9:0]    The IC_SAR holds the slave address when the I2C is operating as a slave. For 7-bit addressing, only IC_SAR[6:0] is used.\n\n  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  Note: The default values cannot be any of the reserved address locations: that is, 0x00 to 0x07, or 0x78 to 0x7f. The correct operation of the device is not guaranteed if you program the IC_SAR or IC_TAR to a reserved value. Refer to <<table_I2C_firstbyte_bit_defs>> for a complete list of these reserved values. 
 
    .equ I2C1_IC_DATA_CMD_OFFSET, 0x0010 
       @ .equ I2C1_IC_DATA_CMD_FIRST_DATA_BYTE [11:11]    Indicates the first data byte received after the address phase for receive transfer in Master receiver or Slave receiver mode.\n\n  Reset value : 0x0\n\n  NOTE: In case of APB_DATA_WIDTH=8,\n\n  1. The user has to perform two APB Reads to IC_DATA_CMD in order to get status on 11 bit.\n\n  2. In order to read the 11 bit, the user has to perform the first data byte read [7:0] offset 0x10 and then perform the second read [15:8] offset 0x11 in order to know the status of 11 bit whether the data received in previous read is a first data byte or not.\n\n  3. The 11th bit is an optional read field, user can ignore 2nd byte read [15:8] offset 0x11 if not interested in FIRST_DATA_BYTE status. 
       @ .equ I2C1_IC_DATA_CMD_RESTART [10:10]    This bit controls whether a RESTART is issued before the byte is sent or received.\n\n  1 - If IC_RESTART_EN is 1, a RESTART is issued before the data is sent/received according to the value of CMD, regardless of whether or not the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.\n\n  0 - If IC_RESTART_EN is 1, a RESTART is issued only if the transfer direction is changing from the previous command; if IC_RESTART_EN is 0, a STOP followed by a START is issued instead.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_DATA_CMD_STOP [9:9]    This bit controls whether a STOP is issued after the byte is sent or received.\n\n  - 1 - STOP is issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master immediately tries to start a new transfer by issuing a START and arbitrating for the bus. - 0 - STOP is not issued after this byte, regardless of whether or not the Tx FIFO is empty. If the Tx FIFO is not empty, the master continues the current transfer by sending/receiving data bytes according to the value of the CMD bit. If the Tx FIFO is empty, the master holds the SCL line low and stalls the bus until a new command is available in the Tx FIFO. Reset value: 0x0 
       @ .equ I2C1_IC_DATA_CMD_CMD [8:8]    This bit controls whether a read or a write is performed. This bit does not control the direction when the DW_apb_i2con acts as a slave. It controls only the direction when it acts as a master.\n\n  When a command is entered in the TX FIFO, this bit distinguishes the write and read commands. In slave-receiver mode, this bit is a 'don't care' because writes to this register are not required. In slave-transmitter mode, a '0' indicates that the data in IC_DATA_CMD is to be transmitted.\n\n  When programming this bit, you should remember the following: attempting to perform a read operation after a General Call command has been sent results in a TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, unless bit 11 SPECIAL in the IC_TAR register has been cleared. If a '1' is written to this bit after receiving a RD_REQ interrupt, then a TX_ABRT interrupt occurs.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_DATA_CMD_DAT [7:0]    This register contains the data to be transmitted or received on the I2C bus. If you are writing to this register and want to perform a read, bits 7:0 DAT are ignored by the DW_apb_i2c. However, when you read this register, these bits return the value of data received on the DW_apb_i2c interface.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_SS_SCL_HCNT_OFFSET, 0x0014 
       @ .equ I2C1_IC_SS_SCL_HCNT_IC_SS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'.\n\n  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed.\n\n  NOTE: This register must not be programmed to a value higher than 65525, because DW_apb_i2c uses a 16-bit counter to flag an I2C bus idle condition when this counter reaches a value of IC_SS_SCL_HCNT + 10. 
 
    .equ I2C1_IC_SS_SCL_LCNT_OFFSET, 0x0018 
       @ .equ I2C1_IC_SS_SCL_LCNT_IC_SS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for standard speed. For more information, refer to 'IC_CLK Frequency Configuration'\n\n  This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted, results in 8 being set. For designs with APB_DATA_WIDTH = 8, the order of programming is important to ensure the correct operation of DW_apb_i2c. The lower byte must be programmed first, and then the upper byte is programmed. 
 
    .equ I2C1_IC_FS_SCL_HCNT_OFFSET, 0x001c 
       @ .equ I2C1_IC_FS_SCL_HCNT_IC_FS_SCL_HCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock high-period count for fast mode or fast mode plus. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.\n\n  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard. This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 6; hardware prevents values less than this being written, and if attempted results in 6 being set. For designs with APB_DATA_WIDTH == 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. 
 
    .equ I2C1_IC_FS_SCL_LCNT_OFFSET, 0x0020 
       @ .equ I2C1_IC_FS_SCL_LCNT_IC_FS_SCL_LCNT [15:0]    This register must be set before any I2C bus transaction can take place to ensure proper I/O timing. This register sets the SCL clock low period count for fast speed. It is used in high-speed mode to send the Master Code and START BYTE or General CALL. For more information, refer to 'IC_CLK Frequency Configuration'.\n\n  This register goes away and becomes read-only returning 0s if IC_MAX_SPEED_MODE = standard.\n\n  This register can be written only when the I2C interface is disabled, which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect.\n\n  The minimum valid value is 8; hardware prevents values less than this being written, and if attempted results in 8 being set. For designs with APB_DATA_WIDTH = 8 the order of programming is important to ensure the correct operation of the DW_apb_i2c. The lower byte must be programmed first. Then the upper byte is programmed. If the value is less than 8 then the count value gets changed to 8. 
 
    .equ I2C1_IC_INTR_STAT_OFFSET, 0x002c 
       @ .equ I2C1_IC_INTR_STAT_R_MASTER_ON_HOLD [13:13]    See IC_RAW_INTR_STAT for a detailed description of R_MASTER_ON_HOLD bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_RESTART_DET [12:12]    See IC_RAW_INTR_STAT for a detailed description of R_RESTART_DET bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_GEN_CALL [11:11]    See IC_RAW_INTR_STAT for a detailed description of R_GEN_CALL bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_START_DET [10:10]    See IC_RAW_INTR_STAT for a detailed description of R_START_DET bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_STOP_DET [9:9]    See IC_RAW_INTR_STAT for a detailed description of R_STOP_DET bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_ACTIVITY [8:8]    See IC_RAW_INTR_STAT for a detailed description of R_ACTIVITY bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_RX_DONE [7:7]    See IC_RAW_INTR_STAT for a detailed description of R_RX_DONE bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_TX_ABRT [6:6]    See IC_RAW_INTR_STAT for a detailed description of R_TX_ABRT bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_RD_REQ [5:5]    See IC_RAW_INTR_STAT for a detailed description of R_RD_REQ bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_TX_EMPTY [4:4]    See IC_RAW_INTR_STAT for a detailed description of R_TX_EMPTY bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_TX_OVER [3:3]    See IC_RAW_INTR_STAT for a detailed description of R_TX_OVER bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_RX_FULL [2:2]    See IC_RAW_INTR_STAT for a detailed description of R_RX_FULL bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_RX_OVER [1:1]    See IC_RAW_INTR_STAT for a detailed description of R_RX_OVER bit.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_STAT_R_RX_UNDER [0:0]    See IC_RAW_INTR_STAT for a detailed description of R_RX_UNDER bit.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_INTR_MASK_OFFSET, 0x0030 
       @ .equ I2C1_IC_INTR_MASK_M_MASTER_ON_HOLD_READ_ONLY [13:13]    This M_MASTER_ON_HOLD_read_only bit masks the R_MASTER_ON_HOLD interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_MASK_M_RESTART_DET [12:12]    This bit masks the R_RESTART_DET interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_MASK_M_GEN_CALL [11:11]    This bit masks the R_GEN_CALL interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_START_DET [10:10]    This bit masks the R_START_DET interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_MASK_M_STOP_DET [9:9]    This bit masks the R_STOP_DET interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_MASK_M_ACTIVITY [8:8]    This bit masks the R_ACTIVITY interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_INTR_MASK_M_RX_DONE [7:7]    This bit masks the R_RX_DONE interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_TX_ABRT [6:6]    This bit masks the R_TX_ABRT interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_RD_REQ [5:5]    This bit masks the R_RD_REQ interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_TX_EMPTY [4:4]    This bit masks the R_TX_EMPTY interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_TX_OVER [3:3]    This bit masks the R_TX_OVER interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_RX_FULL [2:2]    This bit masks the R_RX_FULL interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_RX_OVER [1:1]    This bit masks the R_RX_OVER interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
       @ .equ I2C1_IC_INTR_MASK_M_RX_UNDER [0:0]    This bit masks the R_RX_UNDER interrupt in IC_INTR_STAT register.\n\n  Reset value: 0x1 
 
    .equ I2C1_IC_RAW_INTR_STAT_OFFSET, 0x0034 
       @ .equ I2C1_IC_RAW_INTR_STAT_MASTER_ON_HOLD [13:13]    Indicates whether master is holding the bus and TX FIFO is empty. Enabled only when I2C_DYNAMIC_TAR_UPDATE=1 and IC_EMPTYFIFO_HOLD_MASTER_EN=1.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_RESTART_DET [12:12]    Indicates whether a RESTART condition has occurred on the I2C interface when DW_apb_i2c is operating in Slave mode and the slave is being addressed. Enabled only when IC_SLV_RESTART_DET_EN=1.\n\n  Note: However, in high-speed mode or during a START BYTE transfer, the RESTART comes before the address field as per the I2C protocol. In this case, the slave is not the addressed slave when the RESTART is issued, therefore DW_apb_i2c does not generate the RESTART_DET interrupt.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_GEN_CALL [11:11]    Set only when a General Call address is received and it is acknowledged. It stays set until it is cleared either by disabling DW_apb_i2c or when the CPU reads bit 0 of the IC_CLR_GEN_CALL register. DW_apb_i2c stores the received data in the Rx buffer.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_START_DET [10:10]    Indicates whether a START or RESTART condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_STOP_DET [9:9]    Indicates whether a STOP condition has occurred on the I2C interface regardless of whether DW_apb_i2c is operating in slave or master mode.\n\n  In Slave Mode: - If IC_CON[7]=1'b1 STOP_DET_IFADDRESSED, the STOP_DET interrupt will be issued only if slave is addressed. Note: During a general call address, this slave does not issue a STOP_DET interrupt if STOP_DET_IF_ADDRESSED=1'b1, even if the slave responds to the general call address by generating ACK. The STOP_DET interrupt is generated only when the transmitted address matches the slave address SAR. - If IC_CON[7]=1'b0 STOP_DET_IFADDRESSED, the STOP_DET interrupt is issued irrespective of whether it is being addressed. In Master Mode: - If IC_CON[10]=1'b1 STOP_DET_IF_MASTER_ACTIVE,the STOP_DET interrupt will be issued only if Master is active. - If IC_CON[10]=1'b0 STOP_DET_IFADDRESSED,the STOP_DET interrupt will be issued irrespective of whether master is active or not. Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_ACTIVITY [8:8]    This bit captures DW_apb_i2c activity and stays set until it is cleared. There are four ways to clear it: - Disabling the DW_apb_i2c - Reading the IC_CLR_ACTIVITY register - Reading the IC_CLR_INTR register - System reset Once this bit is set, it stays set unless one of the four methods is used to clear it. Even if the DW_apb_i2c module is idle, this bit remains set until cleared, indicating that there was activity on the bus.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_DONE [7:7]    When the DW_apb_i2c is acting as a slave-transmitter, this bit is set to 1 if the master does not acknowledge a transmitted byte. This occurs on the last byte of the transmission, indicating that the transmission is done.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_TX_ABRT [6:6]    This bit indicates if DW_apb_i2c, as an I2C transmitter, is unable to complete the intended actions on the contents of the transmit FIFO. This situation can occur both as an I2C master or an I2C slave, and is referred to as a 'transmit abort'. When this bit is set to 1, the IC_TX_ABRT_SOURCE register indicates the reason why the transmit abort takes places.\n\n  Note: The DW_apb_i2c flushes/resets/empties the TX_FIFO and RX_FIFO whenever there is a transmit abort caused by any of the events tracked by the IC_TX_ABRT_SOURCE register. The FIFOs remains in this flushed state until the register IC_CLR_TX_ABRT is read. Once this read is performed, the Tx FIFO is then ready to accept more data bytes from the APB interface.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_RD_REQ [5:5]    This bit is set to 1 when DW_apb_i2c is acting as a slave and another I2C master is attempting to read data from DW_apb_i2c. The DW_apb_i2c holds the I2C bus in a wait state SCL=0 until this interrupt is serviced, which means that the slave has been addressed by a remote master that is asking for data to be transferred. The processor must respond to this interrupt and then write the requested data to the IC_DATA_CMD register. This bit is set to 0 just after the processor reads the IC_CLR_RD_REQ register.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_TX_EMPTY [4:4]    The behavior of the TX_EMPTY interrupt status differs based on the TX_EMPTY_CTRL selection in the IC_CON register. - When TX_EMPTY_CTRL = 0: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register. - When TX_EMPTY_CTRL = 1: This bit is set to 1 when the transmit buffer is at or below the threshold value set in the IC_TX_TL register and the transmission of the address/data from the internal shift register for the most recently popped command is completed. It is automatically cleared by hardware when the buffer level goes above the threshold. When IC_ENABLE[0] is set to 0, the TX FIFO is flushed and held in reset. There the TX FIFO looks like it has no data within it, so this bit is set to 1, provided there is activity in the master or slave state machines. When there is no longer any activity, then with ic_en=0, this bit is set to 0.\n\n  Reset value: 0x0. 
       @ .equ I2C1_IC_RAW_INTR_STAT_TX_OVER [3:3]    Set during transmit if the transmit buffer is filled to IC_TX_BUFFER_DEPTH and the processor attempts to issue another I2C command by writing to the IC_DATA_CMD register. When the module is disabled, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_FULL [2:2]    Set when the receive buffer reaches or goes above the RX_TL threshold in the IC_RX_TL register. It is automatically cleared by hardware when buffer level goes below the threshold. If the module is disabled IC_ENABLE[0]=0, the RX FIFO is flushed and held in reset; therefore the RX FIFO is not full. So this bit is cleared once the IC_ENABLE bit 0 is programmed with a 0, regardless of the activity that continues.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_OVER [1:1]    Set if the receive buffer is completely filled to IC_RX_BUFFER_DEPTH and an additional byte is received from an external I2C device. The DW_apb_i2c acknowledges this, but any data bytes received after the FIFO is full are lost. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.\n\n  Note: If bit 9 of the IC_CON register RX_FIFO_FULL_HLD_CTRL is programmed to HIGH, then the RX_OVER interrupt never occurs, because the Rx FIFO never overflows.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_UNDER [0:0]    Set if the processor attempts to read the receive buffer when it is empty by reading from the IC_DATA_CMD register. If the module is disabled IC_ENABLE[0]=0, this bit keeps its level until the master or slave state machines go into idle, and when ic_en goes to 0, this interrupt is cleared.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_RX_TL_OFFSET, 0x0038 
       @ .equ I2C1_IC_RX_TL_RX_TL [7:0]    Receive FIFO Threshold Level.\n\n  Controls the level of entries or above that triggers the RX_FULL interrupt bit 2 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that hardware does not allow this value to be set to a value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 1 entry, and a value of 255 sets the threshold for 256 entries. 
 
    .equ I2C1_IC_TX_TL_OFFSET, 0x003c 
       @ .equ I2C1_IC_TX_TL_TX_TL [7:0]    Transmit FIFO Threshold Level.\n\n  Controls the level of entries or below that trigger the TX_EMPTY interrupt bit 4 in IC_RAW_INTR_STAT register. The valid range is 0-255, with the additional restriction that it may not be set to value larger than the depth of the buffer. If an attempt is made to do that, the actual value set will be the maximum depth of the buffer. A value of 0 sets the threshold for 0 entries, and a value of 255 sets the threshold for 255 entries. 
 
    .equ I2C1_IC_CLR_INTR_OFFSET, 0x0040 
       @ .equ I2C1_IC_CLR_INTR_CLR_INTR [0:0]    Read this register to clear the combined interrupt, all individual interrupts, and the IC_TX_ABRT_SOURCE register. This bit does not clear hardware clearable interrupts but software clearable interrupts. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RX_UNDER_OFFSET, 0x0044 
       @ .equ I2C1_IC_CLR_RX_UNDER_CLR_RX_UNDER [0:0]    Read this register to clear the RX_UNDER interrupt bit 0 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RX_OVER_OFFSET, 0x0048 
       @ .equ I2C1_IC_CLR_RX_OVER_CLR_RX_OVER [0:0]    Read this register to clear the RX_OVER interrupt bit 1 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_TX_OVER_OFFSET, 0x004c 
       @ .equ I2C1_IC_CLR_TX_OVER_CLR_TX_OVER [0:0]    Read this register to clear the TX_OVER interrupt bit 3 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RD_REQ_OFFSET, 0x0050 
       @ .equ I2C1_IC_CLR_RD_REQ_CLR_RD_REQ [0:0]    Read this register to clear the RD_REQ interrupt bit 5 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_TX_ABRT_OFFSET, 0x0054 
       @ .equ I2C1_IC_CLR_TX_ABRT_CLR_TX_ABRT [0:0]    Read this register to clear the TX_ABRT interrupt bit 6 of the IC_RAW_INTR_STAT register, and the IC_TX_ABRT_SOURCE register. This also releases the TX FIFO from the flushed/reset state, allowing more writes to the TX FIFO. Refer to Bit 9 of the IC_TX_ABRT_SOURCE register for an exception to clearing IC_TX_ABRT_SOURCE.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_RX_DONE_OFFSET, 0x0058 
       @ .equ I2C1_IC_CLR_RX_DONE_CLR_RX_DONE [0:0]    Read this register to clear the RX_DONE interrupt bit 7 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_ACTIVITY_OFFSET, 0x005c 
       @ .equ I2C1_IC_CLR_ACTIVITY_CLR_ACTIVITY [0:0]    Reading this register clears the ACTIVITY interrupt if the I2C is not active anymore. If the I2C module is still active on the bus, the ACTIVITY interrupt bit continues to be set. It is automatically cleared by hardware if the module is disabled and if there is no further activity on the bus. The value read from this register to get status of the ACTIVITY interrupt bit 8 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_STOP_DET_OFFSET, 0x0060 
       @ .equ I2C1_IC_CLR_STOP_DET_CLR_STOP_DET [0:0]    Read this register to clear the STOP_DET interrupt bit 9 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_START_DET_OFFSET, 0x0064 
       @ .equ I2C1_IC_CLR_START_DET_CLR_START_DET [0:0]    Read this register to clear the START_DET interrupt bit 10 of the IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_CLR_GEN_CALL_OFFSET, 0x0068 
       @ .equ I2C1_IC_CLR_GEN_CALL_CLR_GEN_CALL [0:0]    Read this register to clear the GEN_CALL interrupt bit 11 of IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_ENABLE_OFFSET, 0x006c 
       @ .equ I2C1_IC_ENABLE_TX_CMD_BLOCK [2:2]    In Master mode: - 1'b1: Blocks the transmission of data on I2C bus even if Tx FIFO has data to transmit. - 1'b0: The transmission of data starts on I2C bus automatically, as soon as the first data is available in the Tx FIFO. Note: To block the execution of Master commands, set the TX_CMD_BLOCK bit only when Tx FIFO is empty IC_STATUS[2]==1 and Master is in Idle state IC_STATUS[5] == 0. Any further commands put in the Tx FIFO are not executed until TX_CMD_BLOCK bit is unset. Reset value: IC_TX_CMD_BLOCK_DEFAULT 
       @ .equ I2C1_IC_ENABLE_ABORT [1:1]    When set, the controller initiates the transfer abort. - 0: ABORT not initiated or ABORT done - 1: ABORT operation in progress The software can abort the I2C transfer in master mode by setting this bit. The software can set this bit only when ENABLE is already set; otherwise, the controller ignores any write to ABORT bit. The software cannot clear the ABORT bit once set. In response to an ABORT, the controller issues a STOP and flushes the Tx FIFO after completing the current transfer, then sets the TX_ABORT interrupt after the abort operation. The ABORT bit is cleared automatically after the abort operation.\n\n  For a detailed description on how to abort I2C transfers, refer to 'Aborting I2C Transfers'.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_ENABLE_ENABLE [0:0]    Controls whether the DW_apb_i2c is enabled. - 0: Disables DW_apb_i2c TX and RX FIFOs are held in an erased state - 1: Enables DW_apb_i2c Software can disable DW_apb_i2c while it is active. However, it is important that care be taken to ensure that DW_apb_i2c is disabled properly. A recommended procedure is described in 'Disabling DW_apb_i2c'.\n\n  When DW_apb_i2c is disabled, the following occurs: - The TX FIFO and RX FIFO get flushed. - Status bits in the IC_INTR_STAT register are still active until DW_apb_i2c goes into IDLE state. If the module is transmitting, it stops as well as deletes the contents of the transmit buffer after the current transfer is complete. If the module is receiving, the DW_apb_i2c stops the current transfer at the end of the current byte and does not acknowledge the transfer.\n\n  In systems with asynchronous pclk and ic_clk when IC_CLK_TYPE parameter set to asynchronous 1, there is a two ic_clk delay when enabling or disabling the DW_apb_i2c. For a detailed description on how to disable DW_apb_i2c, refer to 'Disabling DW_apb_i2c'\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_STATUS_OFFSET, 0x0070 
       @ .equ I2C1_IC_STATUS_SLV_ACTIVITY [6:6]    Slave FSM Activity Status. When the Slave Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Slave FSM is in IDLE state so the Slave part of DW_apb_i2c is not Active - 1: Slave FSM is not in IDLE state so the Slave part of DW_apb_i2c is Active Reset value: 0x0 
       @ .equ I2C1_IC_STATUS_MST_ACTIVITY [5:5]    Master FSM Activity Status. When the Master Finite State Machine FSM is not in the IDLE state, this bit is set. - 0: Master FSM is in IDLE state so the Master part of DW_apb_i2c is not Active - 1: Master FSM is not in IDLE state so the Master part of DW_apb_i2c is Active Note: IC_STATUS[0]-that is, ACTIVITY bit-is the OR of SLV_ACTIVITY and MST_ACTIVITY bits.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_STATUS_RFF [4:4]    Receive FIFO Completely Full. When the receive FIFO is completely full, this bit is set. When the receive FIFO contains one or more empty location, this bit is cleared. - 0: Receive FIFO is not full - 1: Receive FIFO is full Reset value: 0x0 
       @ .equ I2C1_IC_STATUS_RFNE [3:3]    Receive FIFO Not Empty. This bit is set when the receive FIFO contains one or more entries; it is cleared when the receive FIFO is empty. - 0: Receive FIFO is empty - 1: Receive FIFO is not empty Reset value: 0x0 
       @ .equ I2C1_IC_STATUS_TFE [2:2]    Transmit FIFO Completely Empty. When the transmit FIFO is completely empty, this bit is set. When it contains one or more valid entries, this bit is cleared. This bit field does not request an interrupt. - 0: Transmit FIFO is not empty - 1: Transmit FIFO is empty Reset value: 0x1 
       @ .equ I2C1_IC_STATUS_TFNF [1:1]    Transmit FIFO Not Full. Set when the transmit FIFO contains one or more empty locations, and is cleared when the FIFO is full. - 0: Transmit FIFO is full - 1: Transmit FIFO is not full Reset value: 0x1 
       @ .equ I2C1_IC_STATUS_ACTIVITY [0:0]    I2C Activity Status. Reset value: 0x0 
 
    .equ I2C1_IC_TXFLR_OFFSET, 0x0074 
       @ .equ I2C1_IC_TXFLR_TXFLR [4:0]    Transmit FIFO Level. Contains the number of valid data entries in the transmit FIFO.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_RXFLR_OFFSET, 0x0078 
       @ .equ I2C1_IC_RXFLR_RXFLR [4:0]    Receive FIFO Level. Contains the number of valid data entries in the receive FIFO.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_SDA_HOLD_OFFSET, 0x007c 
       @ .equ I2C1_IC_SDA_HOLD_IC_SDA_RX_HOLD [23:16]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a receiver.\n\n  Reset value: IC_DEFAULT_SDA_HOLD[23:16]. 
       @ .equ I2C1_IC_SDA_HOLD_IC_SDA_TX_HOLD [15:0]    Sets the required SDA hold time in units of ic_clk period, when DW_apb_i2c acts as a transmitter.\n\n  Reset value: IC_DEFAULT_SDA_HOLD[15:0]. 
 
    .equ I2C1_IC_TX_ABRT_SOURCE_OFFSET, 0x0080 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_TX_FLUSH_CNT [31:23]    This field indicates the number of Tx FIFO Data Commands which are flushed due to TX_ABRT interrupt. It is cleared whenever I2C is disabled.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_USER_ABRT [16:16]    This is a master-mode-only bit. Master has detected the transfer abort IC_ENABLE[1]\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SLVRD_INTX [15:15]    1: When the processor side responds to a slave mode request for data to be transmitted to a remote master and user writes a 1 in CMD bit 8 of IC_DATA_CMD register.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SLV_ARBLOST [14:14]    This field indicates that a Slave has lost the bus while transmitting data to a remote master. IC_TX_ABRT_SOURCE[12] is set at the same time. Note: Even though the slave never 'owns' the bus, something could go wrong on the bus. This is a fail safe check. For instance, during a data transmission at the low-to-high transition of SCL, if what is on the data bus is not what is supposed to be transmitted, then DW_apb_i2c no longer own the bus.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SLVFLUSH_TXFIFO [13:13]    This field specifies that the Slave has received a read command and some data exists in the TX FIFO, so the slave issues a TX_ABRT interrupt to flush old data in TX FIFO.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Slave-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ARB_LOST [12:12]    This field specifies that the Master has lost arbitration, or if IC_TX_ABRT_SOURCE[14] is also set, then the slave transmitter has lost arbitration.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Slave-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_MASTER_DIS [11:11]    This field indicates that the User tries to initiate a Master operation with the Master mode disabled.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_10B_RD_NORSTRT [10:10]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the master sends a read command in 10-bit addressing mode.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Receiver 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SBYTE_NORSTRT [9:9]    To clear Bit 9, the source of the ABRT_SBYTE_NORSTRT must be fixed first; restart must be enabled IC_CON[5]=1, the SPECIAL bit must be cleared IC_TAR[11], or the GC_OR_START bit must be cleared IC_TAR[10]. Once the source of the ABRT_SBYTE_NORSTRT is fixed, then this bit can be cleared in the same manner as other bits in this register. If the source of the ABRT_SBYTE_NORSTRT is not fixed before attempting to clear this bit, bit 9 clears for one cycle and then gets reasserted. When this field is set to 1, the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to send a START Byte.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_HS_NORSTRT [8:8]    This field indicates that the restart is disabled IC_RESTART_EN bit IC_CON[5] =0 and the user is trying to use the master to transfer data in High Speed mode.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SBYTE_ACKDET [7:7]    This field indicates that the Master has sent a START Byte and the START Byte was acknowledged wrong behavior.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_HS_ACKDET [6:6]    This field indicates that the Master is in High Speed mode and the High Speed Master code was acknowledged wrong behavior.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_GCALL_READ [5:5]    This field indicates that DW_apb_i2c in the master mode has sent a General Call but the user programmed the byte following the General Call to be a read from the bus IC_DATA_CMD[9] is set to 1.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_GCALL_NOACK [4:4]    This field indicates that DW_apb_i2c in master mode has sent a General Call and no slave on the bus acknowledged the General Call.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_TXDATA_NOACK [3:3]    This field indicates the master-mode only bit. When the master receives an acknowledgement for the address, but when it sends data bytes following the address, it did not receive an acknowledge from the remote slaves.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_10ADDR2_NOACK [2:2]    This field indicates that the Master is in 10-bit address mode and that the second address byte of the 10-bit address was not acknowledged by any slave.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_10ADDR1_NOACK [1:1]    This field indicates that the Master is in 10-bit address mode and the first 10-bit address byte was not acknowledged by any slave.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_7B_ADDR_NOACK [0:0]    This field indicates that the Master is in 7-bit addressing mode and the address sent was not acknowledged by any slave.\n\n  Reset value: 0x0\n\n  Role of DW_apb_i2c: Master-Transmitter or Master-Receiver 
 
    .equ I2C1_IC_SLV_DATA_NACK_ONLY_OFFSET, 0x0084 
       @ .equ I2C1_IC_SLV_DATA_NACK_ONLY_NACK [0:0]    Generate NACK. This NACK generation only occurs when DW_apb_i2c is a slave-receiver. If this register is set to a value of 1, it can only generate a NACK after a data byte is received; hence, the data transfer is aborted and the data received is not pushed to the receive buffer.\n\n  When the register is set to a value of 0, it generates NACK/ACK, depending on normal criteria. - 1: generate NACK after data byte received - 0: generate NACK/ACK normally Reset value: 0x0 
 
    .equ I2C1_IC_DMA_CR_OFFSET, 0x0088 
       @ .equ I2C1_IC_DMA_CR_TDMAE [1:1]    Transmit DMA Enable. This bit enables/disables the transmit FIFO DMA channel. Reset value: 0x0 
       @ .equ I2C1_IC_DMA_CR_RDMAE [0:0]    Receive DMA Enable. This bit enables/disables the receive FIFO DMA channel. Reset value: 0x0 
 
    .equ I2C1_IC_DMA_TDLR_OFFSET, 0x008c 
       @ .equ I2C1_IC_DMA_TDLR_DMATDL [3:0]    Transmit Data Level. This bit field controls the level at which a DMA request is made by the transmit logic. It is equal to the watermark level; that is, the dma_tx_req signal is generated when the number of valid data entries in the transmit FIFO is equal to or below this field value, and TDMAE = 1.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_DMA_RDLR_OFFSET, 0x0090 
       @ .equ I2C1_IC_DMA_RDLR_DMARDL [3:0]    Receive Data Level. This bit field controls the level at which a DMA request is made by the receive logic. The watermark level = DMARDL+1; that is, dma_rx_req is generated when the number of valid data entries in the receive FIFO is equal to or more than this field value + 1, and RDMAE =1. For instance, when DMARDL is 0, then dma_rx_req is asserted when 1 or more data entries are present in the receive FIFO.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_SDA_SETUP_OFFSET, 0x0094 
       @ .equ I2C1_IC_SDA_SETUP_SDA_SETUP [7:0]    SDA Setup. It is recommended that if the required delay is 1000ns, then for an ic_clk frequency of 10 MHz, IC_SDA_SETUP should be programmed to a value of 11. IC_SDA_SETUP must be programmed with a minimum value of 2. 
 
    .equ I2C1_IC_ACK_GENERAL_CALL_OFFSET, 0x0098 
       @ .equ I2C1_IC_ACK_GENERAL_CALL_ACK_GEN_CALL [0:0]    ACK General Call. When set to 1, DW_apb_i2c responds with a ACK by asserting ic_data_oe when it receives a General Call. Otherwise, DW_apb_i2c responds with a NACK by negating ic_data_oe. 
 
    .equ I2C1_IC_ENABLE_STATUS_OFFSET, 0x009c 
       @ .equ I2C1_IC_ENABLE_STATUS_SLV_RX_DATA_LOST [2:2]    Slave Received Data Lost. This bit indicates if a Slave-Receiver operation has been aborted with at least one data byte received from an I2C transfer due to the setting bit 0 of IC_ENABLE from 1 to 0. When read as 1, DW_apb_i2c is deemed to have been actively engaged in an aborted I2C transfer with matching address and the data phase of the I2C transfer has been entered, even though a data byte has been responded with a NACK.\n\n  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit is also set to 1.\n\n  When read as 0, DW_apb_i2c is deemed to have been disabled without being actively involved in the data phase of a Slave-Receiver transfer.\n\n  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_ENABLE_STATUS_SLV_DISABLED_WHILE_BUSY [1:1]    Slave Disabled While Busy Transmit, Receive. This bit indicates if a potential or active Slave operation has been aborted due to the setting bit 0 of the IC_ENABLE register from 1 to 0. This bit is set when the CPU writes a 0 to the IC_ENABLE register while:\n\n  a DW_apb_i2c is receiving the address byte of the Slave-Transmitter operation from a remote master;\n\n  OR,\n\n  b address and data bytes of the Slave-Receiver operation from a remote master.\n\n  When read as 1, DW_apb_i2c is deemed to have forced a NACK during any part of an I2C transfer, irrespective of whether the I2C address matches the slave address set in DW_apb_i2c IC_SAR register OR if the transfer is completed before IC_ENABLE is set to 0 but has not taken effect.\n\n  Note: If the remote I2C master terminates the transfer with a STOP condition before the DW_apb_i2c has a chance to NACK a transfer, and IC_ENABLE[0] has been set to 0, then this bit will also be set to 1.\n\n  When read as 0, DW_apb_i2c is deemed to have been disabled when there is master activity, or when the I2C bus is idle.\n\n  Note: The CPU can safely read this bit when IC_EN bit 0 is read as 0.\n\n  Reset value: 0x0 
       @ .equ I2C1_IC_ENABLE_STATUS_IC_EN [0:0]    ic_en Status. This bit always reflects the value driven on the output port ic_en. - When read as 1, DW_apb_i2c is deemed to be in an enabled state. - When read as 0, DW_apb_i2c is deemed completely inactive. Note: The CPU can safely read this bit anytime. When this bit is read as 0, the CPU can safely read SLV_RX_DATA_LOST bit 2 and SLV_DISABLED_WHILE_BUSY bit 1.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_FS_SPKLEN_OFFSET, 0x00a0 
       @ .equ I2C1_IC_FS_SPKLEN_IC_FS_SPKLEN [7:0]    This register must be set before any I2C bus transaction can take place to ensure stable operation. This register sets the duration, measured in ic_clk cycles, of the longest spike in the SCL or SDA lines that will be filtered out by the spike suppression logic. This register can be written only when the I2C interface is disabled which corresponds to the IC_ENABLE[0] register being set to 0. Writes at other times have no effect. The minimum valid value is 1; hardware prevents values less than this being written, and if attempted results in 1 being set. or more information, refer to 'Spike Suppression'. 
 
    .equ I2C1_IC_CLR_RESTART_DET_OFFSET, 0x00a8 
       @ .equ I2C1_IC_CLR_RESTART_DET_CLR_RESTART_DET [0:0]    Read this register to clear the RESTART_DET interrupt bit 12 of IC_RAW_INTR_STAT register.\n\n  Reset value: 0x0 
 
    .equ I2C1_IC_COMP_PARAM_1_OFFSET, 0x00f4 
       @ .equ I2C1_IC_COMP_PARAM_1_TX_BUFFER_DEPTH [23:16]    TX Buffer Depth = 16 
       @ .equ I2C1_IC_COMP_PARAM_1_RX_BUFFER_DEPTH [15:8]    RX Buffer Depth = 16 
       @ .equ I2C1_IC_COMP_PARAM_1_ADD_ENCODED_PARAMS [7:7]    Encoded parameters not visible 
       @ .equ I2C1_IC_COMP_PARAM_1_HAS_DMA [6:6]    DMA handshaking signals are enabled 
       @ .equ I2C1_IC_COMP_PARAM_1_INTR_IO [5:5]    COMBINED Interrupt outputs 
       @ .equ I2C1_IC_COMP_PARAM_1_HC_COUNT_VALUES [4:4]    Programmable count values for each mode. 
       @ .equ I2C1_IC_COMP_PARAM_1_MAX_SPEED_MODE [3:2]    MAX SPEED MODE = FAST MODE 
       @ .equ I2C1_IC_COMP_PARAM_1_APB_DATA_WIDTH [1:0]    APB data bus width is 32 bits 
 
    .equ I2C1_IC_COMP_VERSION_OFFSET, 0x00f8 
       @ .equ I2C1_IC_COMP_VERSION_IC_COMP_VERSION [31:0]     
 
    .equ I2C1_IC_COMP_TYPE_OFFSET, 0x00fc 
       @ .equ I2C1_IC_COMP_TYPE_IC_COMP_TYPE [31:0]    Designware Component Type number = 0x44_57_01_40. This assigned unique hex value is constant and is derived from the two ASCII letters 'DW' followed by a 16-bit unsigned number. 
 

@=========================== ADC ===========================@
.equ ADC_BASE, 0x4004c000 
    .equ ADC_CS_OFFSET, 0x0000 
       @ .equ ADC_CS_RROBIN [20:16]    Round-robin sampling. 1 bit per channel. Set all bits to 0 to disable.\n  Otherwise, the ADC will cycle through each enabled channel in a round-robin fashion.\n  The first channel to be sampled will be the one currently indicated by AINSEL.\n  AINSEL will be updated after each conversion with the newly-selected channel. 
       @ .equ ADC_CS_AINSEL [14:12]    Select analog mux input. Updated automatically in round-robin mode. 
       @ .equ ADC_CS_ERR_STICKY [10:10]    Some past ADC conversion encountered an error. Write 1 to clear. 
       @ .equ ADC_CS_ERR [9:9]    The most recent ADC conversion encountered an error; result is undefined or noisy. 
       @ .equ ADC_CS_READY [8:8]    1 if the ADC is ready to start a new conversion. Implies any previous conversion has completed.\n  0 whilst conversion in progress. 
       @ .equ ADC_CS_START_MANY [3:3]    Continuously perform conversions whilst this bit is 1. A new conversion will start immediately after the previous finishes. 
       @ .equ ADC_CS_START_ONCE [2:2]    Start a single conversion. Self-clearing. Ignored if start_many is asserted. 
       @ .equ ADC_CS_TS_EN [1:1]    Power on temperature sensor. 1 - enabled. 0 - disabled. 
       @ .equ ADC_CS_EN [0:0]    Power on ADC and enable its clock.\n  1 - enabled. 0 - disabled. 
 
    .equ ADC_RESULT_OFFSET, 0x0004 
       @ .equ ADC_RESULT_RESULT [11:0]     
 
    .equ ADC_FCS_OFFSET, 0x0008 
       @ .equ ADC_FCS_THRESH [27:24]    DREQ/IRQ asserted when level >= threshold 
       @ .equ ADC_FCS_LEVEL [19:16]    The number of conversion results currently waiting in the FIFO 
       @ .equ ADC_FCS_OVER [11:11]    1 if the FIFO has been overflowed. Write 1 to clear. 
       @ .equ ADC_FCS_UNDER [10:10]    1 if the FIFO has been underflowed. Write 1 to clear. 
       @ .equ ADC_FCS_FULL [9:9]     
       @ .equ ADC_FCS_EMPTY [8:8]     
       @ .equ ADC_FCS_DREQ_EN [3:3]    If 1: assert DMA requests when FIFO contains data 
       @ .equ ADC_FCS_ERR [2:2]    If 1: conversion error bit appears in the FIFO alongside the result 
       @ .equ ADC_FCS_SHIFT [1:1]    If 1: FIFO results are right-shifted to be one byte in size. Enables DMA to byte buffers. 
       @ .equ ADC_FCS_EN [0:0]    If 1: write result to the FIFO after each conversion. 
 
    .equ ADC_FIFO_OFFSET, 0x000c 
       @ .equ ADC_FIFO_ERR [15:15]    1 if this particular sample experienced a conversion error. Remains in the same location if the sample is shifted. 
       @ .equ ADC_FIFO_VAL [11:0]     
 
    .equ ADC_DIV_OFFSET, 0x0010 
       @ .equ ADC_DIV_INT [23:8]    Integer part of clock divisor. 
       @ .equ ADC_DIV_FRAC [7:0]    Fractional part of clock divisor. First-order delta-sigma. 
 
    .equ ADC_INTR_OFFSET, 0x0014 
       @ .equ ADC_INTR_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.\n  This level can be programmed via the FCS_THRESH field. 
 
    .equ ADC_INTE_OFFSET, 0x0018 
       @ .equ ADC_INTE_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.\n  This level can be programmed via the FCS_THRESH field. 
 
    .equ ADC_INTF_OFFSET, 0x001c 
       @ .equ ADC_INTF_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.\n  This level can be programmed via the FCS_THRESH field. 
 
    .equ ADC_INTS_OFFSET, 0x0020 
       @ .equ ADC_INTS_FIFO [0:0]    Triggered when the sample FIFO reaches a certain level.\n  This level can be programmed via the FCS_THRESH field. 
 

@=========================== PWM ===========================@
.equ PWM_BASE, 0x40050000 
    .equ PWM_CH0_CSR_OFFSET, 0x0000 
       @ .equ PWM_CH0_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH0_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH0_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH0_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH0_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH0_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH0_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH0_DIV_OFFSET, 0x0004 
       @ .equ PWM_CH0_DIV_INT [11:4]     
       @ .equ PWM_CH0_DIV_FRAC [3:0]     
 
    .equ PWM_CH0_CTR_OFFSET, 0x0008 
       @ .equ PWM_CH0_CTR_CH0_CTR [15:0]     
 
    .equ PWM_CH0_CC_OFFSET, 0x000c 
       @ .equ PWM_CH0_CC_B [31:16]     
       @ .equ PWM_CH0_CC_A [15:0]     
 
    .equ PWM_CH0_TOP_OFFSET, 0x0010 
       @ .equ PWM_CH0_TOP_CH0_TOP [15:0]     
 
    .equ PWM_CH1_CSR_OFFSET, 0x0014 
       @ .equ PWM_CH1_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH1_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH1_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH1_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH1_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH1_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH1_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH1_DIV_OFFSET, 0x0018 
       @ .equ PWM_CH1_DIV_INT [11:4]     
       @ .equ PWM_CH1_DIV_FRAC [3:0]     
 
    .equ PWM_CH1_CTR_OFFSET, 0x001c 
       @ .equ PWM_CH1_CTR_CH1_CTR [15:0]     
 
    .equ PWM_CH1_CC_OFFSET, 0x0020 
       @ .equ PWM_CH1_CC_B [31:16]     
       @ .equ PWM_CH1_CC_A [15:0]     
 
    .equ PWM_CH1_TOP_OFFSET, 0x0024 
       @ .equ PWM_CH1_TOP_CH1_TOP [15:0]     
 
    .equ PWM_CH2_CSR_OFFSET, 0x0028 
       @ .equ PWM_CH2_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH2_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH2_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH2_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH2_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH2_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH2_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH2_DIV_OFFSET, 0x002c 
       @ .equ PWM_CH2_DIV_INT [11:4]     
       @ .equ PWM_CH2_DIV_FRAC [3:0]     
 
    .equ PWM_CH2_CTR_OFFSET, 0x0030 
       @ .equ PWM_CH2_CTR_CH2_CTR [15:0]     
 
    .equ PWM_CH2_CC_OFFSET, 0x0034 
       @ .equ PWM_CH2_CC_B [31:16]     
       @ .equ PWM_CH2_CC_A [15:0]     
 
    .equ PWM_CH2_TOP_OFFSET, 0x0038 
       @ .equ PWM_CH2_TOP_CH2_TOP [15:0]     
 
    .equ PWM_CH3_CSR_OFFSET, 0x003c 
       @ .equ PWM_CH3_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH3_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH3_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH3_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH3_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH3_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH3_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH3_DIV_OFFSET, 0x0040 
       @ .equ PWM_CH3_DIV_INT [11:4]     
       @ .equ PWM_CH3_DIV_FRAC [3:0]     
 
    .equ PWM_CH3_CTR_OFFSET, 0x0044 
       @ .equ PWM_CH3_CTR_CH3_CTR [15:0]     
 
    .equ PWM_CH3_CC_OFFSET, 0x0048 
       @ .equ PWM_CH3_CC_B [31:16]     
       @ .equ PWM_CH3_CC_A [15:0]     
 
    .equ PWM_CH3_TOP_OFFSET, 0x004c 
       @ .equ PWM_CH3_TOP_CH3_TOP [15:0]     
 
    .equ PWM_CH4_CSR_OFFSET, 0x0050 
       @ .equ PWM_CH4_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH4_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH4_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH4_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH4_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH4_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH4_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH4_DIV_OFFSET, 0x0054 
       @ .equ PWM_CH4_DIV_INT [11:4]     
       @ .equ PWM_CH4_DIV_FRAC [3:0]     
 
    .equ PWM_CH4_CTR_OFFSET, 0x0058 
       @ .equ PWM_CH4_CTR_CH4_CTR [15:0]     
 
    .equ PWM_CH4_CC_OFFSET, 0x005c 
       @ .equ PWM_CH4_CC_B [31:16]     
       @ .equ PWM_CH4_CC_A [15:0]     
 
    .equ PWM_CH4_TOP_OFFSET, 0x0060 
       @ .equ PWM_CH4_TOP_CH4_TOP [15:0]     
 
    .equ PWM_CH5_CSR_OFFSET, 0x0064 
       @ .equ PWM_CH5_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH5_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH5_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH5_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH5_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH5_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH5_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH5_DIV_OFFSET, 0x0068 
       @ .equ PWM_CH5_DIV_INT [11:4]     
       @ .equ PWM_CH5_DIV_FRAC [3:0]     
 
    .equ PWM_CH5_CTR_OFFSET, 0x006c 
       @ .equ PWM_CH5_CTR_CH5_CTR [15:0]     
 
    .equ PWM_CH5_CC_OFFSET, 0x0070 
       @ .equ PWM_CH5_CC_B [31:16]     
       @ .equ PWM_CH5_CC_A [15:0]     
 
    .equ PWM_CH5_TOP_OFFSET, 0x0074 
       @ .equ PWM_CH5_TOP_CH5_TOP [15:0]     
 
    .equ PWM_CH6_CSR_OFFSET, 0x0078 
       @ .equ PWM_CH6_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH6_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH6_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH6_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH6_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH6_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH6_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH6_DIV_OFFSET, 0x007c 
       @ .equ PWM_CH6_DIV_INT [11:4]     
       @ .equ PWM_CH6_DIV_FRAC [3:0]     
 
    .equ PWM_CH6_CTR_OFFSET, 0x0080 
       @ .equ PWM_CH6_CTR_CH6_CTR [15:0]     
 
    .equ PWM_CH6_CC_OFFSET, 0x0084 
       @ .equ PWM_CH6_CC_B [31:16]     
       @ .equ PWM_CH6_CC_A [15:0]     
 
    .equ PWM_CH6_TOP_OFFSET, 0x0088 
       @ .equ PWM_CH6_TOP_CH6_TOP [15:0]     
 
    .equ PWM_CH7_CSR_OFFSET, 0x008c 
       @ .equ PWM_CH7_CSR_PH_ADV [7:7]    Advance the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running\n  at less than full speed div_int + div_frac / 16 > 1 
       @ .equ PWM_CH7_CSR_PH_RET [6:6]    Retard the phase of the counter by 1 count, while it is running.\n  Self-clearing. Write a 1, and poll until low. Counter must be running. 
       @ .equ PWM_CH7_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH7_CSR_B_INV [3:3]    Invert output B 
       @ .equ PWM_CH7_CSR_A_INV [2:2]    Invert output A 
       @ .equ PWM_CH7_CSR_PH_CORRECT [1:1]    1: Enable phase-correct modulation. 0: Trailing-edge 
       @ .equ PWM_CH7_CSR_EN [0:0]    Enable the PWM channel. 
 
    .equ PWM_CH7_DIV_OFFSET, 0x0090 
       @ .equ PWM_CH7_DIV_INT [11:4]     
       @ .equ PWM_CH7_DIV_FRAC [3:0]     
 
    .equ PWM_CH7_CTR_OFFSET, 0x0094 
       @ .equ PWM_CH7_CTR_CH7_CTR [15:0]     
 
    .equ PWM_CH7_CC_OFFSET, 0x0098 
       @ .equ PWM_CH7_CC_B [31:16]     
       @ .equ PWM_CH7_CC_A [15:0]     
 
    .equ PWM_CH7_TOP_OFFSET, 0x009c 
       @ .equ PWM_CH7_TOP_CH7_TOP [15:0]     
 
    .equ PWM_EN_OFFSET, 0x00a0 
       @ .equ PWM_EN_CH7 [7:7]     
       @ .equ PWM_EN_CH6 [6:6]     
       @ .equ PWM_EN_CH5 [5:5]     
       @ .equ PWM_EN_CH4 [4:4]     
       @ .equ PWM_EN_CH3 [3:3]     
       @ .equ PWM_EN_CH2 [2:2]     
       @ .equ PWM_EN_CH1 [1:1]     
       @ .equ PWM_EN_CH0 [0:0]     
 
    .equ PWM_INTR_OFFSET, 0x00a4 
       @ .equ PWM_INTR_CH7 [7:7]     
       @ .equ PWM_INTR_CH6 [6:6]     
       @ .equ PWM_INTR_CH5 [5:5]     
       @ .equ PWM_INTR_CH4 [4:4]     
       @ .equ PWM_INTR_CH3 [3:3]     
       @ .equ PWM_INTR_CH2 [2:2]     
       @ .equ PWM_INTR_CH1 [1:1]     
       @ .equ PWM_INTR_CH0 [0:0]     
 
    .equ PWM_INTE_OFFSET, 0x00a8 
       @ .equ PWM_INTE_CH7 [7:7]     
       @ .equ PWM_INTE_CH6 [6:6]     
       @ .equ PWM_INTE_CH5 [5:5]     
       @ .equ PWM_INTE_CH4 [4:4]     
       @ .equ PWM_INTE_CH3 [3:3]     
       @ .equ PWM_INTE_CH2 [2:2]     
       @ .equ PWM_INTE_CH1 [1:1]     
       @ .equ PWM_INTE_CH0 [0:0]     
 
    .equ PWM_INTF_OFFSET, 0x00ac 
       @ .equ PWM_INTF_CH7 [7:7]     
       @ .equ PWM_INTF_CH6 [6:6]     
       @ .equ PWM_INTF_CH5 [5:5]     
       @ .equ PWM_INTF_CH4 [4:4]     
       @ .equ PWM_INTF_CH3 [3:3]     
       @ .equ PWM_INTF_CH2 [2:2]     
       @ .equ PWM_INTF_CH1 [1:1]     
       @ .equ PWM_INTF_CH0 [0:0]     
 
    .equ PWM_INTS_OFFSET, 0x00b0 
       @ .equ PWM_INTS_CH7 [7:7]     
       @ .equ PWM_INTS_CH6 [6:6]     
       @ .equ PWM_INTS_CH5 [5:5]     
       @ .equ PWM_INTS_CH4 [4:4]     
       @ .equ PWM_INTS_CH3 [3:3]     
       @ .equ PWM_INTS_CH2 [2:2]     
       @ .equ PWM_INTS_CH1 [1:1]     
       @ .equ PWM_INTS_CH0 [0:0]     
 

@=========================== TIMER ===========================@
.equ TIMER_BASE, 0x40054000 
    .equ TIMER_TIMEHW_OFFSET, 0x0000 
 
    .equ TIMER_TIMELW_OFFSET, 0x0004 
 
    .equ TIMER_TIMEHR_OFFSET, 0x0008 
 
    .equ TIMER_TIMELR_OFFSET, 0x000c 
 
    .equ TIMER_ALARM0_OFFSET, 0x0010 
 
    .equ TIMER_ALARM1_OFFSET, 0x0014 
 
    .equ TIMER_ALARM2_OFFSET, 0x0018 
 
    .equ TIMER_ALARM3_OFFSET, 0x001c 
 
    .equ TIMER_ARMED_OFFSET, 0x0020 
       @ .equ TIMER_ARMED_ARMED [3:0]     
 
    .equ TIMER_TIMERAWH_OFFSET, 0x0024 
 
    .equ TIMER_TIMERAWL_OFFSET, 0x0028 
 
    .equ TIMER_DBGPAUSE_OFFSET, 0x002c 
       @ .equ TIMER_DBGPAUSE_DBG1 [2:2]    Pause when processor 1 is in debug mode 
       @ .equ TIMER_DBGPAUSE_DBG0 [1:1]    Pause when processor 0 is in debug mode 
 
    .equ TIMER_PAUSE_OFFSET, 0x0030 
       @ .equ TIMER_PAUSE_PAUSE [0:0]     
 
    .equ TIMER_INTR_OFFSET, 0x0034 
       @ .equ TIMER_INTR_ALARM_3 [3:3]     
       @ .equ TIMER_INTR_ALARM_2 [2:2]     
       @ .equ TIMER_INTR_ALARM_1 [1:1]     
       @ .equ TIMER_INTR_ALARM_0 [0:0]     
 
    .equ TIMER_INTE_OFFSET, 0x0038 
       @ .equ TIMER_INTE_ALARM_3 [3:3]     
       @ .equ TIMER_INTE_ALARM_2 [2:2]     
       @ .equ TIMER_INTE_ALARM_1 [1:1]     
       @ .equ TIMER_INTE_ALARM_0 [0:0]     
 
    .equ TIMER_INTF_OFFSET, 0x003c 
       @ .equ TIMER_INTF_ALARM_3 [3:3]     
       @ .equ TIMER_INTF_ALARM_2 [2:2]     
       @ .equ TIMER_INTF_ALARM_1 [1:1]     
       @ .equ TIMER_INTF_ALARM_0 [0:0]     
 
    .equ TIMER_INTS_OFFSET, 0x0040 
       @ .equ TIMER_INTS_ALARM_3 [3:3]     
       @ .equ TIMER_INTS_ALARM_2 [2:2]     
       @ .equ TIMER_INTS_ALARM_1 [1:1]     
       @ .equ TIMER_INTS_ALARM_0 [0:0]     
 

@=========================== WATCHDOG ===========================@
.equ WATCHDOG_BASE, 0x40058000 
    .equ WATCHDOG_CTRL_OFFSET, 0x0000 
       @ .equ WATCHDOG_CTRL_TRIGGER [31:31]    Trigger a watchdog reset 
       @ .equ WATCHDOG_CTRL_ENABLE [30:30]    When not enabled the watchdog timer is paused 
       @ .equ WATCHDOG_CTRL_PAUSE_DBG1 [26:26]    Pause the watchdog timer when processor 1 is in debug mode 
       @ .equ WATCHDOG_CTRL_PAUSE_DBG0 [25:25]    Pause the watchdog timer when processor 0 is in debug mode 
       @ .equ WATCHDOG_CTRL_PAUSE_JTAG [24:24]    Pause the watchdog timer when JTAG is accessing the bus fabric 
       @ .equ WATCHDOG_CTRL_TIME [23:0]    Indicates the number of ticks / 2 see errata RP2040-E1 before a watchdog reset will be triggered 
 
    .equ WATCHDOG_LOAD_OFFSET, 0x0004 
       @ .equ WATCHDOG_LOAD_LOAD [23:0]     
 
    .equ WATCHDOG_REASON_OFFSET, 0x0008 
       @ .equ WATCHDOG_REASON_FORCE [1:1]     
       @ .equ WATCHDOG_REASON_TIMER [0:0]     
 
    .equ WATCHDOG_SCRATCH0_OFFSET, 0x000c 
 
    .equ WATCHDOG_SCRATCH1_OFFSET, 0x0010 
 
    .equ WATCHDOG_SCRATCH2_OFFSET, 0x0014 
 
    .equ WATCHDOG_SCRATCH3_OFFSET, 0x0018 
 
    .equ WATCHDOG_SCRATCH4_OFFSET, 0x001c 
 
    .equ WATCHDOG_SCRATCH5_OFFSET, 0x0020 
 
    .equ WATCHDOG_SCRATCH6_OFFSET, 0x0024 
 
    .equ WATCHDOG_SCRATCH7_OFFSET, 0x0028 
 
    .equ WATCHDOG_TICK_OFFSET, 0x002c 
       @ .equ WATCHDOG_TICK_COUNT [19:11]    Count down timer: the remaining number clk_tick cycles before the next tick is generated. 
       @ .equ WATCHDOG_TICK_RUNNING [10:10]    Is the tick generator running? 
       @ .equ WATCHDOG_TICK_ENABLE [9:9]    start / stop tick generation 
       @ .equ WATCHDOG_TICK_CYCLES [8:0]    Total number of clk_tick cycles before the next tick. 
 

@=========================== RTC ===========================@
.equ RTC_BASE, 0x4005c000 
    .equ RTC_CLKDIV_M1_OFFSET, 0x0000 
       @ .equ RTC_CLKDIV_M1_CLKDIV_M1 [15:0]     
 
    .equ RTC_SETUP_0_OFFSET, 0x0004 
       @ .equ RTC_SETUP_0_YEAR [23:12]    Year 
       @ .equ RTC_SETUP_0_MONTH [11:8]    Month 1..12 
       @ .equ RTC_SETUP_0_DAY [4:0]    Day of the month 1..31 
 
    .equ RTC_SETUP_1_OFFSET, 0x0008 
       @ .equ RTC_SETUP_1_DOTW [26:24]    Day of the week: 1-Monday...0-Sunday ISO 8601 mod 7 
       @ .equ RTC_SETUP_1_HOUR [20:16]    Hours 
       @ .equ RTC_SETUP_1_MIN [13:8]    Minutes 
       @ .equ RTC_SETUP_1_SEC [5:0]    Seconds 
 
    .equ RTC_CTRL_OFFSET, 0x000c 
       @ .equ RTC_CTRL_FORCE_NOTLEAPYEAR [8:8]    If set, leapyear is forced off.\n  Useful for years divisible by 100 but not by 400 
       @ .equ RTC_CTRL_LOAD [4:4]    Load RTC 
       @ .equ RTC_CTRL_RTC_ACTIVE [1:1]    RTC enabled running 
       @ .equ RTC_CTRL_RTC_ENABLE [0:0]    Enable RTC 
 
    .equ RTC_IRQ_SETUP_0_OFFSET, 0x0010 
       @ .equ RTC_IRQ_SETUP_0_MATCH_ACTIVE [29:29]     
       @ .equ RTC_IRQ_SETUP_0_MATCH_ENA [28:28]    Global match enable. Don't change any other value while this one is enabled 
       @ .equ RTC_IRQ_SETUP_0_YEAR_ENA [26:26]    Enable year matching 
       @ .equ RTC_IRQ_SETUP_0_MONTH_ENA [25:25]    Enable month matching 
       @ .equ RTC_IRQ_SETUP_0_DAY_ENA [24:24]    Enable day matching 
       @ .equ RTC_IRQ_SETUP_0_YEAR [23:12]    Year 
       @ .equ RTC_IRQ_SETUP_0_MONTH [11:8]    Month 1..12 
       @ .equ RTC_IRQ_SETUP_0_DAY [4:0]    Day of the month 1..31 
 
    .equ RTC_IRQ_SETUP_1_OFFSET, 0x0014 
       @ .equ RTC_IRQ_SETUP_1_DOTW_ENA [31:31]    Enable day of the week matching 
       @ .equ RTC_IRQ_SETUP_1_HOUR_ENA [30:30]    Enable hour matching 
       @ .equ RTC_IRQ_SETUP_1_MIN_ENA [29:29]    Enable minute matching 
       @ .equ RTC_IRQ_SETUP_1_SEC_ENA [28:28]    Enable second matching 
       @ .equ RTC_IRQ_SETUP_1_DOTW [26:24]    Day of the week 
       @ .equ RTC_IRQ_SETUP_1_HOUR [20:16]    Hours 
       @ .equ RTC_IRQ_SETUP_1_MIN [13:8]    Minutes 
       @ .equ RTC_IRQ_SETUP_1_SEC [5:0]    Seconds 
 
    .equ RTC_RTC_1_OFFSET, 0x0018 
       @ .equ RTC_RTC_1_YEAR [23:12]    Year 
       @ .equ RTC_RTC_1_MONTH [11:8]    Month 1..12 
       @ .equ RTC_RTC_1_DAY [4:0]    Day of the month 1..31 
 
    .equ RTC_RTC_0_OFFSET, 0x001c 
       @ .equ RTC_RTC_0_DOTW [26:24]    Day of the week 
       @ .equ RTC_RTC_0_HOUR [20:16]    Hours 
       @ .equ RTC_RTC_0_MIN [13:8]    Minutes 
       @ .equ RTC_RTC_0_SEC [5:0]    Seconds 
 
    .equ RTC_INTR_OFFSET, 0x0020 
       @ .equ RTC_INTR_RTC [0:0]     
 
    .equ RTC_INTE_OFFSET, 0x0024 
       @ .equ RTC_INTE_RTC [0:0]     
 
    .equ RTC_INTF_OFFSET, 0x0028 
       @ .equ RTC_INTF_RTC [0:0]     
 
    .equ RTC_INTS_OFFSET, 0x002c 
       @ .equ RTC_INTS_RTC [0:0]     
 

@=========================== ROSC ===========================@
.equ ROSC_BASE, 0x40060000 
    .equ ROSC_CTRL_OFFSET, 0x0000 
       @ .equ ROSC_CTRL_ENABLE [23:12]    On power-up this field is initialised to ENABLE\n  The system clock must be switched to another source before setting this field to DISABLE otherwise the chip will lock up\n  The 12-bit code is intended to give some protection against accidental writes. An invalid setting will enable the oscillator. 
       @ .equ ROSC_CTRL_FREQ_RANGE [11:0]    Controls the number of delay stages in the ROSC ring\n  LOW uses stages 0 to 7\n  MEDIUM uses stages 0 to 5\n  HIGH uses stages 0 to 3\n  TOOHIGH uses stages 0 to 1 and should not be used because its frequency exceeds design specifications\n  The clock output will not glitch when changing the range up one step at a time\n  The clock output will glitch when changing the range down\n  Note: the values here are gray coded which is why HIGH comes before TOOHIGH 
 
    .equ ROSC_FREQA_OFFSET, 0x0004 
       @ .equ ROSC_FREQA_PASSWD [31:16]    Set to 0x9696 to apply the settings\n  Any other value in this field will set all drive strengths to 0 
       @ .equ ROSC_FREQA_DS3 [14:12]    Stage 3 drive strength 
       @ .equ ROSC_FREQA_DS2 [10:8]    Stage 2 drive strength 
       @ .equ ROSC_FREQA_DS1 [6:4]    Stage 1 drive strength 
       @ .equ ROSC_FREQA_DS0 [2:0]    Stage 0 drive strength 
 
    .equ ROSC_FREQB_OFFSET, 0x0008 
       @ .equ ROSC_FREQB_PASSWD [31:16]    Set to 0x9696 to apply the settings\n  Any other value in this field will set all drive strengths to 0 
       @ .equ ROSC_FREQB_DS7 [14:12]    Stage 7 drive strength 
       @ .equ ROSC_FREQB_DS6 [10:8]    Stage 6 drive strength 
       @ .equ ROSC_FREQB_DS5 [6:4]    Stage 5 drive strength 
       @ .equ ROSC_FREQB_DS4 [2:0]    Stage 4 drive strength 
 
    .equ ROSC_DORMANT_OFFSET, 0x000c 
 
    .equ ROSC_DIV_OFFSET, 0x0010 
       @ .equ ROSC_DIV_DIV [11:0]    set to 0xaa0 + div where\n  div = 0 divides by 32\n  div = 1-31 divides by div\n  any other value sets div=0 and therefore divides by 32\n  this register resets to div=16 
 
    .equ ROSC_PHASE_OFFSET, 0x0014 
       @ .equ ROSC_PHASE_PASSWD [11:4]    set to 0xaa0\n  any other value enables the output with shift=0 
       @ .equ ROSC_PHASE_ENABLE [3:3]    enable the phase-shifted output\n  this can be changed on-the-fly 
       @ .equ ROSC_PHASE_FLIP [2:2]    invert the phase-shifted output\n  this is ignored when div=1 
       @ .equ ROSC_PHASE_SHIFT [1:0]    phase shift the phase-shifted output by SHIFT input clocks\n  this can be changed on-the-fly\n  must be set to 0 before setting div=1 
 
    .equ ROSC_STATUS_OFFSET, 0x0018 
       @ .equ ROSC_STATUS_STABLE [31:31]    Oscillator is running and stable 
       @ .equ ROSC_STATUS_BADWRITE [24:24]    An invalid value has been written to CTRL_ENABLE or CTRL_FREQ_RANGE or FRFEQA or FREQB or DORMANT 
       @ .equ ROSC_STATUS_DIV_RUNNING [16:16]    post-divider is running\n  this resets to 0 but transitions to 1 during chip startup 
       @ .equ ROSC_STATUS_ENABLED [12:12]    Oscillator is enabled but not necessarily running and stable\n  this resets to 0 but transitions to 1 during chip startup 
 
    .equ ROSC_RANDOMBIT_OFFSET, 0x001c 
       @ .equ ROSC_RANDOMBIT_RANDOMBIT [0:0]     
 
    .equ ROSC_COUNT_OFFSET, 0x0020 
       @ .equ ROSC_COUNT_COUNT [7:0]     
 

@=========================== VREG_AND_CHIP_RESET ===========================@
.equ VREG_AND_CHIP_RESET_BASE, 0x40064000 
    .equ VREG_AND_CHIP_RESET_VREG_OFFSET, 0x0000 
       @ .equ VREG_AND_CHIP_RESET_VREG_ROK [12:12]    regulation status\n  0=not in regulation, 1=in regulation 
       @ .equ VREG_AND_CHIP_RESET_VREG_VSEL [7:4]    output voltage select\n  0000 to 0101 - 0.80V\n  0110 - 0.85V\n  0111 - 0.90V\n  1000 - 0.95V\n  1001 - 1.00V\n  1010 - 1.05V\n  1011 - 1.10V default\n  1100 - 1.15V\n  1101 - 1.20V\n  1110 - 1.25V\n  1111 - 1.30V 
       @ .equ VREG_AND_CHIP_RESET_VREG_HIZ [1:1]    high impedance mode select\n  0=not in high impedance mode, 1=in high impedance mode 
       @ .equ VREG_AND_CHIP_RESET_VREG_EN [0:0]    enable\n  0=not enabled, 1=enabled 
 
    .equ VREG_AND_CHIP_RESET_BOD_OFFSET, 0x0004 
       @ .equ VREG_AND_CHIP_RESET_BOD_VSEL [7:4]    threshold select\n  0000 - 0.473V\n  0001 - 0.516V\n  0010 - 0.559V\n  0011 - 0.602V\n  0100 - 0.645V\n  0101 - 0.688V\n  0110 - 0.731V\n  0111 - 0.774V\n  1000 - 0.817V\n  1001 - 0.860V default\n  1010 - 0.903V\n  1011 - 0.946V\n  1100 - 0.989V\n  1101 - 1.032V\n  1110 - 1.075V\n  1111 - 1.118V 
       @ .equ VREG_AND_CHIP_RESET_BOD_EN [0:0]    enable\n  0=not enabled, 1=enabled 
 
    .equ VREG_AND_CHIP_RESET_CHIP_RESET_OFFSET, 0x0008 
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_PSM_RESTART_FLAG [24:24]    This is set by psm_restart from the debugger.\n  Its purpose is to branch bootcode to a safe mode when the debugger has issued a psm_restart in order to recover from a boot lock-up.\n  In the safe mode the debugger can repair the boot code, clear this flag then reboot the processor. 
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_HAD_PSM_RESTART [20:20]    Last reset was from the debug port 
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_HAD_RUN [16:16]    Last reset was from the RUN pin 
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_HAD_POR [8:8]    Last reset was from the power-on reset or brown-out detection blocks 
 

@=========================== TBMAN ===========================@
.equ TBMAN_BASE, 0x4006c000 
    .equ TBMAN_PLATFORM_OFFSET, 0x0000 
       @ .equ TBMAN_PLATFORM_FPGA [1:1]    Indicates the platform is an FPGA 
       @ .equ TBMAN_PLATFORM_ASIC [0:0]    Indicates the platform is an ASIC 
 

@=========================== DMA ===========================@
.equ DMA_BASE, 0x50000000 
    .equ DMA_CH0_READ_ADDR_OFFSET, 0x0000 
 
    .equ DMA_CH0_WRITE_ADDR_OFFSET, 0x0004 
 
    .equ DMA_CH0_TRANS_COUNT_OFFSET, 0x0008 
 
    .equ DMA_CH0_CTRL_TRIG_OFFSET, 0x000c 
       @ .equ DMA_CH0_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH0_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH0_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH0_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH0_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH0_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH0_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH0_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH0_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 0. 
       @ .equ DMA_CH0_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH0_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH0_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH0_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH0_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH0_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH0_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH0_AL1_CTRL_OFFSET, 0x0010 
 
    .equ DMA_CH0_AL1_READ_ADDR_OFFSET, 0x0014 
 
    .equ DMA_CH0_AL1_WRITE_ADDR_OFFSET, 0x0018 
 
    .equ DMA_CH0_AL1_TRANS_COUNT_TRIG_OFFSET, 0x001c 
 
    .equ DMA_CH0_AL2_CTRL_OFFSET, 0x0020 
 
    .equ DMA_CH0_AL2_TRANS_COUNT_OFFSET, 0x0024 
 
    .equ DMA_CH0_AL2_READ_ADDR_OFFSET, 0x0028 
 
    .equ DMA_CH0_AL2_WRITE_ADDR_TRIG_OFFSET, 0x002c 
 
    .equ DMA_CH0_AL3_CTRL_OFFSET, 0x0030 
 
    .equ DMA_CH0_AL3_WRITE_ADDR_OFFSET, 0x0034 
 
    .equ DMA_CH0_AL3_TRANS_COUNT_OFFSET, 0x0038 
 
    .equ DMA_CH0_AL3_READ_ADDR_TRIG_OFFSET, 0x003c 
 
    .equ DMA_CH1_READ_ADDR_OFFSET, 0x0040 
 
    .equ DMA_CH1_WRITE_ADDR_OFFSET, 0x0044 
 
    .equ DMA_CH1_TRANS_COUNT_OFFSET, 0x0048 
 
    .equ DMA_CH1_CTRL_TRIG_OFFSET, 0x004c 
       @ .equ DMA_CH1_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH1_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH1_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH1_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH1_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH1_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH1_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH1_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH1_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 1. 
       @ .equ DMA_CH1_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH1_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH1_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH1_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH1_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH1_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH1_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH1_AL1_CTRL_OFFSET, 0x0050 
 
    .equ DMA_CH1_AL1_READ_ADDR_OFFSET, 0x0054 
 
    .equ DMA_CH1_AL1_WRITE_ADDR_OFFSET, 0x0058 
 
    .equ DMA_CH1_AL1_TRANS_COUNT_TRIG_OFFSET, 0x005c 
 
    .equ DMA_CH1_AL2_CTRL_OFFSET, 0x0060 
 
    .equ DMA_CH1_AL2_TRANS_COUNT_OFFSET, 0x0064 
 
    .equ DMA_CH1_AL2_READ_ADDR_OFFSET, 0x0068 
 
    .equ DMA_CH1_AL2_WRITE_ADDR_TRIG_OFFSET, 0x006c 
 
    .equ DMA_CH1_AL3_CTRL_OFFSET, 0x0070 
 
    .equ DMA_CH1_AL3_WRITE_ADDR_OFFSET, 0x0074 
 
    .equ DMA_CH1_AL3_TRANS_COUNT_OFFSET, 0x0078 
 
    .equ DMA_CH1_AL3_READ_ADDR_TRIG_OFFSET, 0x007c 
 
    .equ DMA_CH2_READ_ADDR_OFFSET, 0x0080 
 
    .equ DMA_CH2_WRITE_ADDR_OFFSET, 0x0084 
 
    .equ DMA_CH2_TRANS_COUNT_OFFSET, 0x0088 
 
    .equ DMA_CH2_CTRL_TRIG_OFFSET, 0x008c 
       @ .equ DMA_CH2_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH2_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH2_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH2_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH2_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH2_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH2_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH2_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH2_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 2. 
       @ .equ DMA_CH2_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH2_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH2_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH2_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH2_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH2_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH2_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH2_AL1_CTRL_OFFSET, 0x0090 
 
    .equ DMA_CH2_AL1_READ_ADDR_OFFSET, 0x0094 
 
    .equ DMA_CH2_AL1_WRITE_ADDR_OFFSET, 0x0098 
 
    .equ DMA_CH2_AL1_TRANS_COUNT_TRIG_OFFSET, 0x009c 
 
    .equ DMA_CH2_AL2_CTRL_OFFSET, 0x00a0 
 
    .equ DMA_CH2_AL2_TRANS_COUNT_OFFSET, 0x00a4 
 
    .equ DMA_CH2_AL2_READ_ADDR_OFFSET, 0x00a8 
 
    .equ DMA_CH2_AL2_WRITE_ADDR_TRIG_OFFSET, 0x00ac 
 
    .equ DMA_CH2_AL3_CTRL_OFFSET, 0x00b0 
 
    .equ DMA_CH2_AL3_WRITE_ADDR_OFFSET, 0x00b4 
 
    .equ DMA_CH2_AL3_TRANS_COUNT_OFFSET, 0x00b8 
 
    .equ DMA_CH2_AL3_READ_ADDR_TRIG_OFFSET, 0x00bc 
 
    .equ DMA_CH3_READ_ADDR_OFFSET, 0x00c0 
 
    .equ DMA_CH3_WRITE_ADDR_OFFSET, 0x00c4 
 
    .equ DMA_CH3_TRANS_COUNT_OFFSET, 0x00c8 
 
    .equ DMA_CH3_CTRL_TRIG_OFFSET, 0x00cc 
       @ .equ DMA_CH3_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH3_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH3_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH3_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH3_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH3_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH3_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH3_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH3_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 3. 
       @ .equ DMA_CH3_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH3_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH3_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH3_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH3_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH3_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH3_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH3_AL1_CTRL_OFFSET, 0x00d0 
 
    .equ DMA_CH3_AL1_READ_ADDR_OFFSET, 0x00d4 
 
    .equ DMA_CH3_AL1_WRITE_ADDR_OFFSET, 0x00d8 
 
    .equ DMA_CH3_AL1_TRANS_COUNT_TRIG_OFFSET, 0x00dc 
 
    .equ DMA_CH3_AL2_CTRL_OFFSET, 0x00e0 
 
    .equ DMA_CH3_AL2_TRANS_COUNT_OFFSET, 0x00e4 
 
    .equ DMA_CH3_AL2_READ_ADDR_OFFSET, 0x00e8 
 
    .equ DMA_CH3_AL2_WRITE_ADDR_TRIG_OFFSET, 0x00ec 
 
    .equ DMA_CH3_AL3_CTRL_OFFSET, 0x00f0 
 
    .equ DMA_CH3_AL3_WRITE_ADDR_OFFSET, 0x00f4 
 
    .equ DMA_CH3_AL3_TRANS_COUNT_OFFSET, 0x00f8 
 
    .equ DMA_CH3_AL3_READ_ADDR_TRIG_OFFSET, 0x00fc 
 
    .equ DMA_CH4_READ_ADDR_OFFSET, 0x0100 
 
    .equ DMA_CH4_WRITE_ADDR_OFFSET, 0x0104 
 
    .equ DMA_CH4_TRANS_COUNT_OFFSET, 0x0108 
 
    .equ DMA_CH4_CTRL_TRIG_OFFSET, 0x010c 
       @ .equ DMA_CH4_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH4_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH4_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH4_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH4_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH4_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH4_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH4_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH4_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 4. 
       @ .equ DMA_CH4_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH4_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH4_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH4_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH4_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH4_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH4_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH4_AL1_CTRL_OFFSET, 0x0110 
 
    .equ DMA_CH4_AL1_READ_ADDR_OFFSET, 0x0114 
 
    .equ DMA_CH4_AL1_WRITE_ADDR_OFFSET, 0x0118 
 
    .equ DMA_CH4_AL1_TRANS_COUNT_TRIG_OFFSET, 0x011c 
 
    .equ DMA_CH4_AL2_CTRL_OFFSET, 0x0120 
 
    .equ DMA_CH4_AL2_TRANS_COUNT_OFFSET, 0x0124 
 
    .equ DMA_CH4_AL2_READ_ADDR_OFFSET, 0x0128 
 
    .equ DMA_CH4_AL2_WRITE_ADDR_TRIG_OFFSET, 0x012c 
 
    .equ DMA_CH4_AL3_CTRL_OFFSET, 0x0130 
 
    .equ DMA_CH4_AL3_WRITE_ADDR_OFFSET, 0x0134 
 
    .equ DMA_CH4_AL3_TRANS_COUNT_OFFSET, 0x0138 
 
    .equ DMA_CH4_AL3_READ_ADDR_TRIG_OFFSET, 0x013c 
 
    .equ DMA_CH5_READ_ADDR_OFFSET, 0x0140 
 
    .equ DMA_CH5_WRITE_ADDR_OFFSET, 0x0144 
 
    .equ DMA_CH5_TRANS_COUNT_OFFSET, 0x0148 
 
    .equ DMA_CH5_CTRL_TRIG_OFFSET, 0x014c 
       @ .equ DMA_CH5_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH5_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH5_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH5_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH5_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH5_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH5_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH5_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH5_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 5. 
       @ .equ DMA_CH5_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH5_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH5_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH5_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH5_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH5_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH5_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH5_AL1_CTRL_OFFSET, 0x0150 
 
    .equ DMA_CH5_AL1_READ_ADDR_OFFSET, 0x0154 
 
    .equ DMA_CH5_AL1_WRITE_ADDR_OFFSET, 0x0158 
 
    .equ DMA_CH5_AL1_TRANS_COUNT_TRIG_OFFSET, 0x015c 
 
    .equ DMA_CH5_AL2_CTRL_OFFSET, 0x0160 
 
    .equ DMA_CH5_AL2_TRANS_COUNT_OFFSET, 0x0164 
 
    .equ DMA_CH5_AL2_READ_ADDR_OFFSET, 0x0168 
 
    .equ DMA_CH5_AL2_WRITE_ADDR_TRIG_OFFSET, 0x016c 
 
    .equ DMA_CH5_AL3_CTRL_OFFSET, 0x0170 
 
    .equ DMA_CH5_AL3_WRITE_ADDR_OFFSET, 0x0174 
 
    .equ DMA_CH5_AL3_TRANS_COUNT_OFFSET, 0x0178 
 
    .equ DMA_CH5_AL3_READ_ADDR_TRIG_OFFSET, 0x017c 
 
    .equ DMA_CH6_READ_ADDR_OFFSET, 0x0180 
 
    .equ DMA_CH6_WRITE_ADDR_OFFSET, 0x0184 
 
    .equ DMA_CH6_TRANS_COUNT_OFFSET, 0x0188 
 
    .equ DMA_CH6_CTRL_TRIG_OFFSET, 0x018c 
       @ .equ DMA_CH6_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH6_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH6_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH6_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH6_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH6_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH6_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH6_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH6_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 6. 
       @ .equ DMA_CH6_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH6_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH6_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH6_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH6_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH6_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH6_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH6_AL1_CTRL_OFFSET, 0x0190 
 
    .equ DMA_CH6_AL1_READ_ADDR_OFFSET, 0x0194 
 
    .equ DMA_CH6_AL1_WRITE_ADDR_OFFSET, 0x0198 
 
    .equ DMA_CH6_AL1_TRANS_COUNT_TRIG_OFFSET, 0x019c 
 
    .equ DMA_CH6_AL2_CTRL_OFFSET, 0x01a0 
 
    .equ DMA_CH6_AL2_TRANS_COUNT_OFFSET, 0x01a4 
 
    .equ DMA_CH6_AL2_READ_ADDR_OFFSET, 0x01a8 
 
    .equ DMA_CH6_AL2_WRITE_ADDR_TRIG_OFFSET, 0x01ac 
 
    .equ DMA_CH6_AL3_CTRL_OFFSET, 0x01b0 
 
    .equ DMA_CH6_AL3_WRITE_ADDR_OFFSET, 0x01b4 
 
    .equ DMA_CH6_AL3_TRANS_COUNT_OFFSET, 0x01b8 
 
    .equ DMA_CH6_AL3_READ_ADDR_TRIG_OFFSET, 0x01bc 
 
    .equ DMA_CH7_READ_ADDR_OFFSET, 0x01c0 
 
    .equ DMA_CH7_WRITE_ADDR_OFFSET, 0x01c4 
 
    .equ DMA_CH7_TRANS_COUNT_OFFSET, 0x01c8 
 
    .equ DMA_CH7_CTRL_TRIG_OFFSET, 0x01cc 
       @ .equ DMA_CH7_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH7_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH7_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH7_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH7_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH7_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH7_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH7_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH7_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 7. 
       @ .equ DMA_CH7_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH7_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH7_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH7_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH7_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH7_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH7_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH7_AL1_CTRL_OFFSET, 0x01d0 
 
    .equ DMA_CH7_AL1_READ_ADDR_OFFSET, 0x01d4 
 
    .equ DMA_CH7_AL1_WRITE_ADDR_OFFSET, 0x01d8 
 
    .equ DMA_CH7_AL1_TRANS_COUNT_TRIG_OFFSET, 0x01dc 
 
    .equ DMA_CH7_AL2_CTRL_OFFSET, 0x01e0 
 
    .equ DMA_CH7_AL2_TRANS_COUNT_OFFSET, 0x01e4 
 
    .equ DMA_CH7_AL2_READ_ADDR_OFFSET, 0x01e8 
 
    .equ DMA_CH7_AL2_WRITE_ADDR_TRIG_OFFSET, 0x01ec 
 
    .equ DMA_CH7_AL3_CTRL_OFFSET, 0x01f0 
 
    .equ DMA_CH7_AL3_WRITE_ADDR_OFFSET, 0x01f4 
 
    .equ DMA_CH7_AL3_TRANS_COUNT_OFFSET, 0x01f8 
 
    .equ DMA_CH7_AL3_READ_ADDR_TRIG_OFFSET, 0x01fc 
 
    .equ DMA_CH8_READ_ADDR_OFFSET, 0x0200 
 
    .equ DMA_CH8_WRITE_ADDR_OFFSET, 0x0204 
 
    .equ DMA_CH8_TRANS_COUNT_OFFSET, 0x0208 
 
    .equ DMA_CH8_CTRL_TRIG_OFFSET, 0x020c 
       @ .equ DMA_CH8_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH8_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH8_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH8_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH8_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH8_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH8_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH8_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH8_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 8. 
       @ .equ DMA_CH8_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH8_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH8_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH8_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH8_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH8_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH8_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH8_AL1_CTRL_OFFSET, 0x0210 
 
    .equ DMA_CH8_AL1_READ_ADDR_OFFSET, 0x0214 
 
    .equ DMA_CH8_AL1_WRITE_ADDR_OFFSET, 0x0218 
 
    .equ DMA_CH8_AL1_TRANS_COUNT_TRIG_OFFSET, 0x021c 
 
    .equ DMA_CH8_AL2_CTRL_OFFSET, 0x0220 
 
    .equ DMA_CH8_AL2_TRANS_COUNT_OFFSET, 0x0224 
 
    .equ DMA_CH8_AL2_READ_ADDR_OFFSET, 0x0228 
 
    .equ DMA_CH8_AL2_WRITE_ADDR_TRIG_OFFSET, 0x022c 
 
    .equ DMA_CH8_AL3_CTRL_OFFSET, 0x0230 
 
    .equ DMA_CH8_AL3_WRITE_ADDR_OFFSET, 0x0234 
 
    .equ DMA_CH8_AL3_TRANS_COUNT_OFFSET, 0x0238 
 
    .equ DMA_CH8_AL3_READ_ADDR_TRIG_OFFSET, 0x023c 
 
    .equ DMA_CH9_READ_ADDR_OFFSET, 0x0240 
 
    .equ DMA_CH9_WRITE_ADDR_OFFSET, 0x0244 
 
    .equ DMA_CH9_TRANS_COUNT_OFFSET, 0x0248 
 
    .equ DMA_CH9_CTRL_TRIG_OFFSET, 0x024c 
       @ .equ DMA_CH9_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH9_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH9_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH9_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH9_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH9_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH9_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH9_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH9_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 9. 
       @ .equ DMA_CH9_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH9_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH9_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH9_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH9_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH9_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH9_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH9_AL1_CTRL_OFFSET, 0x0250 
 
    .equ DMA_CH9_AL1_READ_ADDR_OFFSET, 0x0254 
 
    .equ DMA_CH9_AL1_WRITE_ADDR_OFFSET, 0x0258 
 
    .equ DMA_CH9_AL1_TRANS_COUNT_TRIG_OFFSET, 0x025c 
 
    .equ DMA_CH9_AL2_CTRL_OFFSET, 0x0260 
 
    .equ DMA_CH9_AL2_TRANS_COUNT_OFFSET, 0x0264 
 
    .equ DMA_CH9_AL2_READ_ADDR_OFFSET, 0x0268 
 
    .equ DMA_CH9_AL2_WRITE_ADDR_TRIG_OFFSET, 0x026c 
 
    .equ DMA_CH9_AL3_CTRL_OFFSET, 0x0270 
 
    .equ DMA_CH9_AL3_WRITE_ADDR_OFFSET, 0x0274 
 
    .equ DMA_CH9_AL3_TRANS_COUNT_OFFSET, 0x0278 
 
    .equ DMA_CH9_AL3_READ_ADDR_TRIG_OFFSET, 0x027c 
 
    .equ DMA_CH10_READ_ADDR_OFFSET, 0x0280 
 
    .equ DMA_CH10_WRITE_ADDR_OFFSET, 0x0284 
 
    .equ DMA_CH10_TRANS_COUNT_OFFSET, 0x0288 
 
    .equ DMA_CH10_CTRL_TRIG_OFFSET, 0x028c 
       @ .equ DMA_CH10_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH10_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH10_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH10_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH10_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH10_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH10_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH10_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH10_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 10. 
       @ .equ DMA_CH10_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH10_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH10_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH10_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH10_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH10_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH10_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH10_AL1_CTRL_OFFSET, 0x0290 
 
    .equ DMA_CH10_AL1_READ_ADDR_OFFSET, 0x0294 
 
    .equ DMA_CH10_AL1_WRITE_ADDR_OFFSET, 0x0298 
 
    .equ DMA_CH10_AL1_TRANS_COUNT_TRIG_OFFSET, 0x029c 
 
    .equ DMA_CH10_AL2_CTRL_OFFSET, 0x02a0 
 
    .equ DMA_CH10_AL2_TRANS_COUNT_OFFSET, 0x02a4 
 
    .equ DMA_CH10_AL2_READ_ADDR_OFFSET, 0x02a8 
 
    .equ DMA_CH10_AL2_WRITE_ADDR_TRIG_OFFSET, 0x02ac 
 
    .equ DMA_CH10_AL3_CTRL_OFFSET, 0x02b0 
 
    .equ DMA_CH10_AL3_WRITE_ADDR_OFFSET, 0x02b4 
 
    .equ DMA_CH10_AL3_TRANS_COUNT_OFFSET, 0x02b8 
 
    .equ DMA_CH10_AL3_READ_ADDR_TRIG_OFFSET, 0x02bc 
 
    .equ DMA_CH11_READ_ADDR_OFFSET, 0x02c0 
 
    .equ DMA_CH11_WRITE_ADDR_OFFSET, 0x02c4 
 
    .equ DMA_CH11_TRANS_COUNT_OFFSET, 0x02c8 
 
    .equ DMA_CH11_CTRL_TRIG_OFFSET, 0x02cc 
       @ .equ DMA_CH11_CTRL_TRIG_AHB_ERROR [31:31]    Logical OR of the READ_ERROR and WRITE_ERROR flags. The channel halts when it encounters any bus error, and always raises its channel IRQ flag. 
       @ .equ DMA_CH11_CTRL_TRIG_READ_ERROR [30:30]    If 1, the channel received a read bus error. Write one to clear.\n  READ_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 3 transfers later 
       @ .equ DMA_CH11_CTRL_TRIG_WRITE_ERROR [29:29]    If 1, the channel received a write bus error. Write one to clear.\n  WRITE_ADDR shows the approximate address where the bus error was encountered will not to be earlier, or more than 5 transfers later 
       @ .equ DMA_CH11_CTRL_TRIG_BUSY [24:24]    This flag goes high when the channel starts a new transfer sequence, and low when the last transfer of that sequence completes. Clearing EN while BUSY is high pauses the channel, and BUSY will stay high while paused.\n\n  To terminate a sequence early and clear the BUSY flag, see CHAN_ABORT. 
       @ .equ DMA_CH11_CTRL_TRIG_SNIFF_EN [23:23]    If 1, this channel's data transfers are visible to the sniff hardware, and each transfer will advance the state of the checksum. This only applies if the sniff hardware is enabled, and has this channel selected.\n\n  This allows checksum to be enabled or disabled on a per-control- block basis. 
       @ .equ DMA_CH11_CTRL_TRIG_BSWAP [22:22]    Apply byte-swap transformation to DMA data.\n  For byte data, this has no effect. For halfword data, the two bytes of each halfword are swapped. For word data, the four bytes of each word are swapped to reverse order. 
       @ .equ DMA_CH11_CTRL_TRIG_IRQ_QUIET [21:21]    In QUIET mode, the channel does not generate IRQs at the end of every transfer block. Instead, an IRQ is raised when NULL is written to a trigger register, indicating the end of a control block chain.\n\n  This reduces the number of interrupts to be serviced by the CPU when transferring a DMA chain of many small control blocks. 
       @ .equ DMA_CH11_CTRL_TRIG_TREQ_SEL [20:15]    Select a Transfer Request signal.\n  The channel uses the transfer request signal to pace its data transfer rate. Sources for TREQ signals are internal TIMERS or external DREQ, a Data Request from the system.\n  0x0 to 0x3a -> select DREQ n as TREQ 
       @ .equ DMA_CH11_CTRL_TRIG_CHAIN_TO [14:11]    When this channel completes, it will trigger the channel indicated by CHAIN_TO. Disable by setting CHAIN_TO = _this channel_.\n  Reset value is equal to channel number 11. 
       @ .equ DMA_CH11_CTRL_TRIG_RING_SEL [10:10]    Select whether RING_SIZE applies to read or write addresses.\n  If 0, read addresses are wrapped on a 1 << RING_SIZE boundary. If 1, write addresses are wrapped. 
       @ .equ DMA_CH11_CTRL_TRIG_RING_SIZE [9:6]    Size of address wrap region. If 0, don't wrap. For values n > 0, only the lower n bits of the address will change. This wraps the address on a 1 << n byte boundary, facilitating access to naturally-aligned ring buffers.\n\n  Ring sizes between 2 and 32768 bytes are possible. This can apply to either read or write addresses, based on value of RING_SEL. 
       @ .equ DMA_CH11_CTRL_TRIG_INCR_WRITE [5:5]    If 1, the write address increments with each transfer. If 0, each write is directed to the same, initial address.\n\n  Generally this should be disabled for memory-to-peripheral transfers. 
       @ .equ DMA_CH11_CTRL_TRIG_INCR_READ [4:4]    If 1, the read address increments with each transfer. If 0, each read is directed to the same, initial address.\n\n  Generally this should be disabled for peripheral-to-memory transfers. 
       @ .equ DMA_CH11_CTRL_TRIG_DATA_SIZE [3:2]    Set the size of each bus transfer byte/halfword/word. READ_ADDR and WRITE_ADDR advance by this amount 1/2/4 bytes with each transfer. 
       @ .equ DMA_CH11_CTRL_TRIG_HIGH_PRIORITY [1:1]    HIGH_PRIORITY gives a channel preferential treatment in issue scheduling: in each scheduling round, all high priority channels are considered first, and then only a single low priority channel, before returning to the high priority channels.\n\n  This only affects the order in which the DMA schedules channels. The DMA's bus priority is not changed. If the DMA is not saturated then a low priority channel will see no loss of throughput. 
       @ .equ DMA_CH11_CTRL_TRIG_EN [0:0]    DMA Channel Enable.\n  When 1, the channel will respond to triggering events, which will cause it to become BUSY and start transferring data. When 0, the channel will ignore triggers, stop issuing transfers, and pause the current transfer sequence i.e. BUSY will remain high if already high 
 
    .equ DMA_CH11_AL1_CTRL_OFFSET, 0x02d0 
 
    .equ DMA_CH11_AL1_READ_ADDR_OFFSET, 0x02d4 
 
    .equ DMA_CH11_AL1_WRITE_ADDR_OFFSET, 0x02d8 
 
    .equ DMA_CH11_AL1_TRANS_COUNT_TRIG_OFFSET, 0x02dc 
 
    .equ DMA_CH11_AL2_CTRL_OFFSET, 0x02e0 
 
    .equ DMA_CH11_AL2_TRANS_COUNT_OFFSET, 0x02e4 
 
    .equ DMA_CH11_AL2_READ_ADDR_OFFSET, 0x02e8 
 
    .equ DMA_CH11_AL2_WRITE_ADDR_TRIG_OFFSET, 0x02ec 
 
    .equ DMA_CH11_AL3_CTRL_OFFSET, 0x02f0 
 
    .equ DMA_CH11_AL3_WRITE_ADDR_OFFSET, 0x02f4 
 
    .equ DMA_CH11_AL3_TRANS_COUNT_OFFSET, 0x02f8 
 
    .equ DMA_CH11_AL3_READ_ADDR_TRIG_OFFSET, 0x02fc 
 
    .equ DMA_INTR_OFFSET, 0x0400 
       @ .equ DMA_INTR_INTR [15:0]    Raw interrupt status for DMA Channels 0..15. Bit n corresponds to channel n. Ignores any masking or forcing. Channel interrupts can be cleared by writing a bit mask to INTR, INTS0 or INTS1.\n\n  Channel interrupts can be routed to either of two system-level IRQs based on INTE0 and INTE1.\n\n  This can be used vector different channel interrupts to different ISRs: this might be done to allow NVIC IRQ preemption for more time-critical channels, or to spread IRQ load across different cores.\n\n  It is also valid to ignore this behaviour and just use INTE0/INTS0/IRQ 0. 
 
    .equ DMA_INTE0_OFFSET, 0x0404 
       @ .equ DMA_INTE0_INTE0 [15:0]    Set bit n to pass interrupts from channel n to DMA IRQ 0. 
 
    .equ DMA_INTF0_OFFSET, 0x0408 
       @ .equ DMA_INTF0_INTF0 [15:0]    Write 1s to force the corresponding bits in INTE0. The interrupt remains asserted until INTF0 is cleared. 
 
    .equ DMA_INTS0_OFFSET, 0x040c 
       @ .equ DMA_INTS0_INTS0 [15:0]    Indicates active channel interrupt requests which are currently causing IRQ 0 to be asserted.\n  Channel interrupts can be cleared by writing a bit mask here. 
 
    .equ DMA_INTE1_OFFSET, 0x0414 
       @ .equ DMA_INTE1_INTE1 [15:0]    Set bit n to pass interrupts from channel n to DMA IRQ 1. 
 
    .equ DMA_INTF1_OFFSET, 0x0418 
       @ .equ DMA_INTF1_INTF1 [15:0]    Write 1s to force the corresponding bits in INTE0. The interrupt remains asserted until INTF0 is cleared. 
 
    .equ DMA_INTS1_OFFSET, 0x041c 
       @ .equ DMA_INTS1_INTS1 [15:0]    Indicates active channel interrupt requests which are currently causing IRQ 1 to be asserted.\n  Channel interrupts can be cleared by writing a bit mask here. 
 
    .equ DMA_TIMER0_OFFSET, 0x0420 
       @ .equ DMA_TIMER0_X [31:16]    Pacing Timer Dividend. Specifies the X value for the X/Y fractional timer. 
       @ .equ DMA_TIMER0_Y [15:0]    Pacing Timer Divisor. Specifies the Y value for the X/Y fractional timer. 
 
    .equ DMA_TIMER1_OFFSET, 0x0424 
       @ .equ DMA_TIMER1_X [31:16]    Pacing Timer Dividend. Specifies the X value for the X/Y fractional timer. 
       @ .equ DMA_TIMER1_Y [15:0]    Pacing Timer Divisor. Specifies the Y value for the X/Y fractional timer. 
 
    .equ DMA_MULTI_CHAN_TRIGGER_OFFSET, 0x0430 
       @ .equ DMA_MULTI_CHAN_TRIGGER_MULTI_CHAN_TRIGGER [15:0]    Each bit in this register corresponds to a DMA channel. Writing a 1 to the relevant bit is the same as writing to that channel's trigger register; the channel will start if it is currently enabled and not already busy. 
 
    .equ DMA_SNIFF_CTRL_OFFSET, 0x0434 
       @ .equ DMA_SNIFF_CTRL_OUT_INV [11:11]    If set, the result appears inverted bitwise complement when read. This does not affect the way the checksum is calculated; the result is transformed on-the-fly between the result register and the bus. 
       @ .equ DMA_SNIFF_CTRL_OUT_REV [10:10]    If set, the result appears bit-reversed when read. This does not affect the way the checksum is calculated; the result is transformed on-the-fly between the result register and the bus. 
       @ .equ DMA_SNIFF_CTRL_BSWAP [9:9]    Locally perform a byte reverse on the sniffed data, before feeding into checksum.\n\n  Note that the sniff hardware is downstream of the DMA channel byteswap performed in the read master: if channel CTRL_BSWAP and SNIFF_CTRL_BSWAP are both enabled, their effects cancel from the sniffer's point of view. 
       @ .equ DMA_SNIFF_CTRL_CALC [8:5]     
       @ .equ DMA_SNIFF_CTRL_DMACH [4:1]    DMA channel for Sniffer to observe 
       @ .equ DMA_SNIFF_CTRL_EN [0:0]    Enable sniffer 
 
    .equ DMA_SNIFF_DATA_OFFSET, 0x0438 
 
    .equ DMA_FIFO_LEVELS_OFFSET, 0x0440 
       @ .equ DMA_FIFO_LEVELS_RAF_LVL [23:16]    Current Read-Address-FIFO fill level 
       @ .equ DMA_FIFO_LEVELS_WAF_LVL [15:8]    Current Write-Address-FIFO fill level 
       @ .equ DMA_FIFO_LEVELS_TDF_LVL [7:0]    Current Transfer-Data-FIFO fill level 
 
    .equ DMA_CHAN_ABORT_OFFSET, 0x0444 
       @ .equ DMA_CHAN_ABORT_CHAN_ABORT [15:0]    Each bit corresponds to a channel. Writing a 1 aborts whatever transfer sequence is in progress on that channel. The bit will remain high until any in-flight transfers have been flushed through the address and data FIFOs.\n\n  After writing, this register must be polled until it returns all-zero. Until this point, it is unsafe to restart the channel. 
 
    .equ DMA_N_CHANNELS_OFFSET, 0x0448 
       @ .equ DMA_N_CHANNELS_N_CHANNELS [4:0]     
 
    .equ DMA_CH0_DBG_CTDREQ_OFFSET, 0x0800 
       @ .equ DMA_CH0_DBG_CTDREQ_CH0_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH0_DBG_TCR_OFFSET, 0x0804 
 
    .equ DMA_CH1_DBG_CTDREQ_OFFSET, 0x0840 
       @ .equ DMA_CH1_DBG_CTDREQ_CH1_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH1_DBG_TCR_OFFSET, 0x0844 
 
    .equ DMA_CH2_DBG_CTDREQ_OFFSET, 0x0880 
       @ .equ DMA_CH2_DBG_CTDREQ_CH2_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH2_DBG_TCR_OFFSET, 0x0884 
 
    .equ DMA_CH3_DBG_CTDREQ_OFFSET, 0x08c0 
       @ .equ DMA_CH3_DBG_CTDREQ_CH3_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH3_DBG_TCR_OFFSET, 0x08c4 
 
    .equ DMA_CH4_DBG_CTDREQ_OFFSET, 0x0900 
       @ .equ DMA_CH4_DBG_CTDREQ_CH4_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH4_DBG_TCR_OFFSET, 0x0904 
 
    .equ DMA_CH5_DBG_CTDREQ_OFFSET, 0x0940 
       @ .equ DMA_CH5_DBG_CTDREQ_CH5_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH5_DBG_TCR_OFFSET, 0x0944 
 
    .equ DMA_CH6_DBG_CTDREQ_OFFSET, 0x0980 
       @ .equ DMA_CH6_DBG_CTDREQ_CH6_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH6_DBG_TCR_OFFSET, 0x0984 
 
    .equ DMA_CH7_DBG_CTDREQ_OFFSET, 0x09c0 
       @ .equ DMA_CH7_DBG_CTDREQ_CH7_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH7_DBG_TCR_OFFSET, 0x09c4 
 
    .equ DMA_CH8_DBG_CTDREQ_OFFSET, 0x0a00 
       @ .equ DMA_CH8_DBG_CTDREQ_CH8_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH8_DBG_TCR_OFFSET, 0x0a04 
 
    .equ DMA_CH9_DBG_CTDREQ_OFFSET, 0x0a40 
       @ .equ DMA_CH9_DBG_CTDREQ_CH9_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH9_DBG_TCR_OFFSET, 0x0a44 
 
    .equ DMA_CH10_DBG_CTDREQ_OFFSET, 0x0a80 
       @ .equ DMA_CH10_DBG_CTDREQ_CH10_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH10_DBG_TCR_OFFSET, 0x0a84 
 
    .equ DMA_CH11_DBG_CTDREQ_OFFSET, 0x0ac0 
       @ .equ DMA_CH11_DBG_CTDREQ_CH11_DBG_CTDREQ [5:0]     
 
    .equ DMA_CH11_DBG_TCR_OFFSET, 0x0ac4 
 

@=========================== USBCTRL_REGS ===========================@
.equ USBCTRL_REGS_BASE, 0x50110000 
    .equ USBCTRL_REGS_ADDR_ENDP_OFFSET, 0x0000 
       @ .equ USBCTRL_REGS_ADDR_ENDP_ENDPOINT [19:16]    Device endpoint to send data to. Only valid for HOST mode. 
       @ .equ USBCTRL_REGS_ADDR_ENDP_ADDRESS [6:0]    In device mode, the address that the device should respond to. Set in response to a SET_ADDR setup packet from the host. In host mode set to the address of the device to communicate with. 
 
    .equ USBCTRL_REGS_ADDR_ENDP1_OFFSET, 0x0004 
       @ .equ USBCTRL_REGS_ADDR_ENDP1_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP1_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP1_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP1_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP2_OFFSET, 0x0008 
       @ .equ USBCTRL_REGS_ADDR_ENDP2_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP2_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP2_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP2_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP3_OFFSET, 0x000c 
       @ .equ USBCTRL_REGS_ADDR_ENDP3_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP3_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP3_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP3_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP4_OFFSET, 0x0010 
       @ .equ USBCTRL_REGS_ADDR_ENDP4_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP4_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP4_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP4_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP5_OFFSET, 0x0014 
       @ .equ USBCTRL_REGS_ADDR_ENDP5_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP5_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP5_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP5_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP6_OFFSET, 0x0018 
       @ .equ USBCTRL_REGS_ADDR_ENDP6_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP6_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP6_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP6_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP7_OFFSET, 0x001c 
       @ .equ USBCTRL_REGS_ADDR_ENDP7_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP7_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP7_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP7_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP8_OFFSET, 0x0020 
       @ .equ USBCTRL_REGS_ADDR_ENDP8_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP8_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP8_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP8_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP9_OFFSET, 0x0024 
       @ .equ USBCTRL_REGS_ADDR_ENDP9_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP9_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP9_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP9_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP10_OFFSET, 0x0028 
       @ .equ USBCTRL_REGS_ADDR_ENDP10_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP10_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP10_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP10_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP11_OFFSET, 0x002c 
       @ .equ USBCTRL_REGS_ADDR_ENDP11_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP11_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP11_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP11_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP12_OFFSET, 0x0030 
       @ .equ USBCTRL_REGS_ADDR_ENDP12_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP12_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP12_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP12_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP13_OFFSET, 0x0034 
       @ .equ USBCTRL_REGS_ADDR_ENDP13_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP13_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP13_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP13_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP14_OFFSET, 0x0038 
       @ .equ USBCTRL_REGS_ADDR_ENDP14_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP14_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP14_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP14_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_ADDR_ENDP15_OFFSET, 0x003c 
       @ .equ USBCTRL_REGS_ADDR_ENDP15_INTEP_PREAMBLE [26:26]    Interrupt EP requires preamble is a low speed device on a full speed hub 
       @ .equ USBCTRL_REGS_ADDR_ENDP15_INTEP_DIR [25:25]    Direction of the interrupt endpoint. In=0, Out=1 
       @ .equ USBCTRL_REGS_ADDR_ENDP15_ENDPOINT [19:16]    Endpoint number of the interrupt endpoint 
       @ .equ USBCTRL_REGS_ADDR_ENDP15_ADDRESS [6:0]    Device address 
 
    .equ USBCTRL_REGS_MAIN_CTRL_OFFSET, 0x0040 
       @ .equ USBCTRL_REGS_MAIN_CTRL_SIM_TIMING [31:31]    Reduced timings for simulation 
       @ .equ USBCTRL_REGS_MAIN_CTRL_HOST_NDEVICE [1:1]    Device mode = 0, Host mode = 1 
       @ .equ USBCTRL_REGS_MAIN_CTRL_CONTROLLER_EN [0:0]    Enable controller 
 
    .equ USBCTRL_REGS_SOF_WR_OFFSET, 0x0044 
       @ .equ USBCTRL_REGS_SOF_WR_COUNT [10:0]     
 
    .equ USBCTRL_REGS_SOF_RD_OFFSET, 0x0048 
       @ .equ USBCTRL_REGS_SOF_RD_COUNT [10:0]     
 
    .equ USBCTRL_REGS_SIE_CTRL_OFFSET, 0x004c 
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_STALL [31:31]    Device: Set bit in EP_STATUS_STALL_NAK when EP0 sends a STALL 
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_DOUBLE_BUF [30:30]    Device: EP0 single buffered = 0, double buffered = 1 
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_1BUF [29:29]    Device: Set bit in BUFF_STATUS for every buffer completed on EP0 
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_2BUF [28:28]    Device: Set bit in BUFF_STATUS for every 2 buffers completed on EP0 
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_NAK [27:27]    Device: Set bit in EP_STATUS_STALL_NAK when EP0 sends a NAK 
       @ .equ USBCTRL_REGS_SIE_CTRL_DIRECT_EN [26:26]    Direct bus drive enable 
       @ .equ USBCTRL_REGS_SIE_CTRL_DIRECT_DP [25:25]    Direct control of DP 
       @ .equ USBCTRL_REGS_SIE_CTRL_DIRECT_DM [24:24]    Direct control of DM 
       @ .equ USBCTRL_REGS_SIE_CTRL_TRANSCEIVER_PD [18:18]    Power down bus transceiver 
       @ .equ USBCTRL_REGS_SIE_CTRL_RPU_OPT [17:17]    Device: Pull-up strength 0=1K2, 1=2k3 
       @ .equ USBCTRL_REGS_SIE_CTRL_PULLUP_EN [16:16]    Device: Enable pull up resistor 
       @ .equ USBCTRL_REGS_SIE_CTRL_PULLDOWN_EN [15:15]    Host: Enable pull down resistors 
       @ .equ USBCTRL_REGS_SIE_CTRL_RESET_BUS [13:13]    Host: Reset bus 
       @ .equ USBCTRL_REGS_SIE_CTRL_RESUME [12:12]    Device: Remote wakeup. Device can initiate its own resume after suspend. 
       @ .equ USBCTRL_REGS_SIE_CTRL_VBUS_EN [11:11]    Host: Enable VBUS 
       @ .equ USBCTRL_REGS_SIE_CTRL_KEEP_ALIVE_EN [10:10]    Host: Enable keep alive packet for low speed bus 
       @ .equ USBCTRL_REGS_SIE_CTRL_SOF_EN [9:9]    Host: Enable SOF generation for full speed bus 
       @ .equ USBCTRL_REGS_SIE_CTRL_SOF_SYNC [8:8]    Host: Delay packets until after SOF 
       @ .equ USBCTRL_REGS_SIE_CTRL_PREAMBLE_EN [6:6]    Host: Preable enable for LS device on FS hub 
       @ .equ USBCTRL_REGS_SIE_CTRL_STOP_TRANS [4:4]    Host: Stop transaction 
       @ .equ USBCTRL_REGS_SIE_CTRL_RECEIVE_DATA [3:3]    Host: Receive transaction IN to host 
       @ .equ USBCTRL_REGS_SIE_CTRL_SEND_DATA [2:2]    Host: Send transaction OUT from host 
       @ .equ USBCTRL_REGS_SIE_CTRL_SEND_SETUP [1:1]    Host: Send Setup packet 
       @ .equ USBCTRL_REGS_SIE_CTRL_START_TRANS [0:0]    Host: Start transaction 
 
    .equ USBCTRL_REGS_SIE_STATUS_OFFSET, 0x0050 
       @ .equ USBCTRL_REGS_SIE_STATUS_DATA_SEQ_ERROR [31:31]    Data Sequence Error.\n\n  The device can raise a sequence error in the following conditions:\n\n  * A SETUP packet is received followed by a DATA1 packet data phase should always be DATA0 * An OUT packet is received from the host but doesn't match the data pid in the buffer control register read from DPSRAM\n\n  The host can raise a data sequence error in the following conditions:\n\n  * An IN packet from the device has the wrong data PID 
       @ .equ USBCTRL_REGS_SIE_STATUS_ACK_REC [30:30]    ACK received. Raised by both host and device. 
       @ .equ USBCTRL_REGS_SIE_STATUS_STALL_REC [29:29]    Host: STALL received 
       @ .equ USBCTRL_REGS_SIE_STATUS_NAK_REC [28:28]    Host: NAK received 
       @ .equ USBCTRL_REGS_SIE_STATUS_RX_TIMEOUT [27:27]    RX timeout is raised by both the host and device if an ACK is not received in the maximum time specified by the USB spec. 
       @ .equ USBCTRL_REGS_SIE_STATUS_RX_OVERFLOW [26:26]    RX overflow is raised by the Serial RX engine if the incoming data is too fast. 
       @ .equ USBCTRL_REGS_SIE_STATUS_BIT_STUFF_ERROR [25:25]    Bit Stuff Error. Raised by the Serial RX engine. 
       @ .equ USBCTRL_REGS_SIE_STATUS_CRC_ERROR [24:24]    CRC Error. Raised by the Serial RX engine. 
       @ .equ USBCTRL_REGS_SIE_STATUS_BUS_RESET [19:19]    Device: bus reset received 
       @ .equ USBCTRL_REGS_SIE_STATUS_TRANS_COMPLETE [18:18]    Transaction complete.\n\n  Raised by device if:\n\n  * An IN or OUT packet is sent with the `LAST_BUFF` bit set in the buffer control register\n\n  Raised by host if:\n\n  * A setup packet is sent when no data in or data out transaction follows * An IN packet is received and the `LAST_BUFF` bit is set in the buffer control register * An IN packet is received with zero length * An OUT packet is sent and the `LAST_BUFF` bit is set 
       @ .equ USBCTRL_REGS_SIE_STATUS_SETUP_REC [17:17]    Device: Setup packet received 
       @ .equ USBCTRL_REGS_SIE_STATUS_CONNECTED [16:16]    Device: connected 
       @ .equ USBCTRL_REGS_SIE_STATUS_RESUME [11:11]    Host: Device has initiated a remote resume. Device: host has initiated a resume. 
       @ .equ USBCTRL_REGS_SIE_STATUS_VBUS_OVER_CURR [10:10]    VBUS over current detected 
       @ .equ USBCTRL_REGS_SIE_STATUS_SPEED [9:8]    Host: device speed. Disconnected = 00, LS = 01, FS = 10 
       @ .equ USBCTRL_REGS_SIE_STATUS_SUSPENDED [4:4]    Bus in suspended state. Valid for device and host. Host and device will go into suspend if neither Keep Alive / SOF frames are enabled. 
       @ .equ USBCTRL_REGS_SIE_STATUS_LINE_STATE [3:2]    USB bus line state 
       @ .equ USBCTRL_REGS_SIE_STATUS_VBUS_DETECTED [0:0]    Device: VBUS Detected 
 
    .equ USBCTRL_REGS_INT_EP_CTRL_OFFSET, 0x0054 
       @ .equ USBCTRL_REGS_INT_EP_CTRL_INT_EP_ACTIVE [15:1]    Host: Enable interrupt endpoint 1 -> 15 
 
    .equ USBCTRL_REGS_BUFF_STATUS_OFFSET, 0x0058 
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP15_OUT [31:31]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP15_IN [30:30]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP14_OUT [29:29]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP14_IN [28:28]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP13_OUT [27:27]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP13_IN [26:26]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP12_OUT [25:25]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP12_IN [24:24]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP11_OUT [23:23]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP11_IN [22:22]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP10_OUT [21:21]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP10_IN [20:20]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP9_OUT [19:19]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP9_IN [18:18]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP8_OUT [17:17]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP8_IN [16:16]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP7_OUT [15:15]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP7_IN [14:14]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP6_OUT [13:13]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP6_IN [12:12]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP5_OUT [11:11]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP5_IN [10:10]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP4_OUT [9:9]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP4_IN [8:8]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP3_OUT [7:7]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP3_IN [6:6]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP2_OUT [5:5]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP2_IN [4:4]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP1_OUT [3:3]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP1_IN [2:2]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP0_OUT [1:1]     
       @ .equ USBCTRL_REGS_BUFF_STATUS_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_OFFSET, 0x005c 
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP15_OUT [31:31]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP15_IN [30:30]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP14_OUT [29:29]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP14_IN [28:28]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP13_OUT [27:27]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP13_IN [26:26]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP12_OUT [25:25]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP12_IN [24:24]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP11_OUT [23:23]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP11_IN [22:22]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP10_OUT [21:21]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP10_IN [20:20]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP9_OUT [19:19]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP9_IN [18:18]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP8_OUT [17:17]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP8_IN [16:16]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP7_OUT [15:15]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP7_IN [14:14]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP6_OUT [13:13]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP6_IN [12:12]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP5_OUT [11:11]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP5_IN [10:10]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP4_OUT [9:9]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP4_IN [8:8]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP3_OUT [7:7]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP3_IN [6:6]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP2_OUT [5:5]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP2_IN [4:4]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP1_OUT [3:3]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP1_IN [2:2]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP0_OUT [1:1]     
       @ .equ USBCTRL_REGS_BUFF_CPU_SHOULD_HANDLE_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_EP_ABORT_OFFSET, 0x0060 
       @ .equ USBCTRL_REGS_EP_ABORT_EP15_OUT [31:31]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP15_IN [30:30]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP14_OUT [29:29]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP14_IN [28:28]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP13_OUT [27:27]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP13_IN [26:26]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP12_OUT [25:25]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP12_IN [24:24]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP11_OUT [23:23]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP11_IN [22:22]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP10_OUT [21:21]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP10_IN [20:20]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP9_OUT [19:19]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP9_IN [18:18]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP8_OUT [17:17]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP8_IN [16:16]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP7_OUT [15:15]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP7_IN [14:14]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP6_OUT [13:13]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP6_IN [12:12]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP5_OUT [11:11]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP5_IN [10:10]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP4_OUT [9:9]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP4_IN [8:8]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP3_OUT [7:7]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP3_IN [6:6]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP2_OUT [5:5]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP2_IN [4:4]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP1_OUT [3:3]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP1_IN [2:2]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP0_OUT [1:1]     
       @ .equ USBCTRL_REGS_EP_ABORT_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_EP_ABORT_DONE_OFFSET, 0x0064 
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP15_OUT [31:31]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP15_IN [30:30]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP14_OUT [29:29]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP14_IN [28:28]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP13_OUT [27:27]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP13_IN [26:26]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP12_OUT [25:25]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP12_IN [24:24]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP11_OUT [23:23]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP11_IN [22:22]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP10_OUT [21:21]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP10_IN [20:20]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP9_OUT [19:19]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP9_IN [18:18]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP8_OUT [17:17]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP8_IN [16:16]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP7_OUT [15:15]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP7_IN [14:14]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP6_OUT [13:13]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP6_IN [12:12]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP5_OUT [11:11]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP5_IN [10:10]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP4_OUT [9:9]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP4_IN [8:8]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP3_OUT [7:7]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP3_IN [6:6]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP2_OUT [5:5]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP2_IN [4:4]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP1_OUT [3:3]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP1_IN [2:2]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP0_OUT [1:1]     
       @ .equ USBCTRL_REGS_EP_ABORT_DONE_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_EP_STALL_ARM_OFFSET, 0x0068 
       @ .equ USBCTRL_REGS_EP_STALL_ARM_EP0_OUT [1:1]     
       @ .equ USBCTRL_REGS_EP_STALL_ARM_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_NAK_POLL_OFFSET, 0x006c 
       @ .equ USBCTRL_REGS_NAK_POLL_DELAY_FS [25:16]    NAK polling interval for a full speed device 
       @ .equ USBCTRL_REGS_NAK_POLL_DELAY_LS [9:0]    NAK polling interval for a low speed device 
 
    .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_OFFSET, 0x0070 
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP15_OUT [31:31]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP15_IN [30:30]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP14_OUT [29:29]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP14_IN [28:28]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP13_OUT [27:27]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP13_IN [26:26]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP12_OUT [25:25]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP12_IN [24:24]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP11_OUT [23:23]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP11_IN [22:22]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP10_OUT [21:21]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP10_IN [20:20]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP9_OUT [19:19]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP9_IN [18:18]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP8_OUT [17:17]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP8_IN [16:16]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP7_OUT [15:15]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP7_IN [14:14]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP6_OUT [13:13]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP6_IN [12:12]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP5_OUT [11:11]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP5_IN [10:10]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP4_OUT [9:9]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP4_IN [8:8]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP3_OUT [7:7]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP3_IN [6:6]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP2_OUT [5:5]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP2_IN [4:4]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP1_OUT [3:3]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP1_IN [2:2]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP0_OUT [1:1]     
       @ .equ USBCTRL_REGS_EP_STATUS_STALL_NAK_EP0_IN [0:0]     
 
    .equ USBCTRL_REGS_USB_MUXING_OFFSET, 0x0074 
       @ .equ USBCTRL_REGS_USB_MUXING_SOFTCON [3:3]     
       @ .equ USBCTRL_REGS_USB_MUXING_TO_DIGITAL_PAD [2:2]     
       @ .equ USBCTRL_REGS_USB_MUXING_TO_EXTPHY [1:1]     
       @ .equ USBCTRL_REGS_USB_MUXING_TO_PHY [0:0]     
 
    .equ USBCTRL_REGS_USB_PWR_OFFSET, 0x0078 
       @ .equ USBCTRL_REGS_USB_PWR_OVERCURR_DETECT_EN [5:5]     
       @ .equ USBCTRL_REGS_USB_PWR_OVERCURR_DETECT [4:4]     
       @ .equ USBCTRL_REGS_USB_PWR_VBUS_DETECT_OVERRIDE_EN [3:3]     
       @ .equ USBCTRL_REGS_USB_PWR_VBUS_DETECT [2:2]     
       @ .equ USBCTRL_REGS_USB_PWR_VBUS_EN_OVERRIDE_EN [1:1]     
       @ .equ USBCTRL_REGS_USB_PWR_VBUS_EN [0:0]     
 
    .equ USBCTRL_REGS_USBPHY_DIRECT_OFFSET, 0x007c 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_OVV [22:22]    DM over voltage 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_OVV [21:21]    DP over voltage 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_OVCN [20:20]    DM overcurrent 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_OVCN [19:19]    DP overcurrent 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_DM [18:18]    DPM pin state 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_DP [17:17]    DPP pin state 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_DD [16:16]    Differential RX 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DIFFMODE [15:15]    TX_DIFFMODE=0: Single ended mode\n  TX_DIFFMODE=1: Differential drive mode TX_DM, TX_DM_OE ignored 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_FSSLEW [14:14]    TX_FSSLEW=0: Low speed slew rate\n  TX_FSSLEW=1: Full speed slew rate 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_PD [13:13]    TX power down override if override enable is set. 1 = powered down. 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_PD [12:12]    RX power down override if override enable is set. 1 = powered down. 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DM [11:11]    Output data. TX_DIFFMODE=1, Ignored\n  TX_DIFFMODE=0, Drives DPM only. TX_DM_OE=1 to enable drive. DPM=TX_DM 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DP [10:10]    Output data. If TX_DIFFMODE=1, Drives DPP/DPM diff pair. TX_DP_OE=1 to enable drive. DPP=TX_DP, DPM=~TX_DP\n  If TX_DIFFMODE=0, Drives DPP only. TX_DP_OE=1 to enable drive. DPP=TX_DP 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DM_OE [9:9]    Output enable. If TX_DIFFMODE=1, Ignored.\n  If TX_DIFFMODE=0, OE for DPM only. 0 - DPM in Hi-Z state; 1 - DPM driving 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DP_OE [8:8]    Output enable. If TX_DIFFMODE=1, OE for DPP/DPM diff pair. 0 - DPP/DPM in Hi-Z state; 1 - DPP/DPM driving\n  If TX_DIFFMODE=0, OE for DPP only. 0 - DPP in Hi-Z state; 1 - DPP driving 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_PULLDN_EN [6:6]    DM pull down enable 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_PULLUP_EN [5:5]    DM pull up enable 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_PULLUP_HISEL [4:4]    Enable the second DM pull up resistor. 0 - Pull = Rpu2; 1 - Pull = Rpu1 + Rpu2 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_PULLDN_EN [2:2]    DP pull down enable 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_PULLUP_EN [1:1]    DP pull up enable 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_PULLUP_HISEL [0:0]    Enable the second DP pull up resistor. 0 - Pull = Rpu2; 1 - Pull = Rpu1 + Rpu2 
 
    .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_OFFSET, 0x0080 
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_DIFFMODE_OVERRIDE_EN [15:15]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_DM_PULLUP_OVERRIDE_EN [12:12]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_FSSLEW_OVERRIDE_EN [11:11]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_PD_OVERRIDE_EN [10:10]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_RX_PD_OVERRIDE_EN [9:9]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_DM_OVERRIDE_EN [8:8]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_DP_OVERRIDE_EN [7:7]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_DM_OE_OVERRIDE_EN [6:6]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_TX_DP_OE_OVERRIDE_EN [5:5]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_DM_PULLDN_EN_OVERRIDE_EN [4:4]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_DP_PULLDN_EN_OVERRIDE_EN [3:3]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_DP_PULLUP_EN_OVERRIDE_EN [2:2]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_DM_PULLUP_HISEL_OVERRIDE_EN [1:1]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_OVERRIDE_DP_PULLUP_HISEL_OVERRIDE_EN [0:0]     
 
    .equ USBCTRL_REGS_USBPHY_TRIM_OFFSET, 0x0084 
       @ .equ USBCTRL_REGS_USBPHY_TRIM_DM_PULLDN_TRIM [12:8]    Value to drive to USB PHY\n  DM pulldown resistor trim control\n  Experimental data suggests that the reset value will work, but this register allows adjustment if required 
       @ .equ USBCTRL_REGS_USBPHY_TRIM_DP_PULLDN_TRIM [4:0]    Value to drive to USB PHY\n  DP pulldown resistor trim control\n  Experimental data suggests that the reset value will work, but this register allows adjustment if required 
 
    .equ USBCTRL_REGS_INTR_OFFSET, 0x008c 
       @ .equ USBCTRL_REGS_INTR_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ USBCTRL_REGS_INTR_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ USBCTRL_REGS_INTR_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTR_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ USBCTRL_REGS_INTR_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTR_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ USBCTRL_REGS_INTR_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ USBCTRL_REGS_INTR_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ USBCTRL_REGS_INTR_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ USBCTRL_REGS_INTR_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ USBCTRL_REGS_INTR_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ USBCTRL_REGS_INTR_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ USBCTRL_REGS_INTR_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ USBCTRL_REGS_INTR_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ USBCTRL_REGS_INTR_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ USBCTRL_REGS_INTR_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ USBCTRL_REGS_INTR_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ USBCTRL_REGS_INTR_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTR_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTR_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 
    .equ USBCTRL_REGS_INTE_OFFSET, 0x0090 
       @ .equ USBCTRL_REGS_INTE_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ USBCTRL_REGS_INTE_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ USBCTRL_REGS_INTE_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTE_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ USBCTRL_REGS_INTE_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTE_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ USBCTRL_REGS_INTE_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ USBCTRL_REGS_INTE_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ USBCTRL_REGS_INTE_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ USBCTRL_REGS_INTE_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ USBCTRL_REGS_INTE_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ USBCTRL_REGS_INTE_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ USBCTRL_REGS_INTE_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ USBCTRL_REGS_INTE_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ USBCTRL_REGS_INTE_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ USBCTRL_REGS_INTE_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ USBCTRL_REGS_INTE_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ USBCTRL_REGS_INTE_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTE_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTE_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 
    .equ USBCTRL_REGS_INTF_OFFSET, 0x0094 
       @ .equ USBCTRL_REGS_INTF_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ USBCTRL_REGS_INTF_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ USBCTRL_REGS_INTF_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTF_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ USBCTRL_REGS_INTF_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTF_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ USBCTRL_REGS_INTF_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ USBCTRL_REGS_INTF_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ USBCTRL_REGS_INTF_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ USBCTRL_REGS_INTF_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ USBCTRL_REGS_INTF_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ USBCTRL_REGS_INTF_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ USBCTRL_REGS_INTF_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ USBCTRL_REGS_INTF_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ USBCTRL_REGS_INTF_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ USBCTRL_REGS_INTF_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ USBCTRL_REGS_INTF_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ USBCTRL_REGS_INTF_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTF_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTF_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 
    .equ USBCTRL_REGS_INTS_OFFSET, 0x0098 
       @ .equ USBCTRL_REGS_INTS_EP_STALL_NAK [19:19]    Raised when any bit in EP_STATUS_STALL_NAK is set. Clear by clearing all bits in EP_STATUS_STALL_NAK. 
       @ .equ USBCTRL_REGS_INTS_ABORT_DONE [18:18]    Raised when any bit in ABORT_DONE is set. Clear by clearing all bits in ABORT_DONE. 
       @ .equ USBCTRL_REGS_INTS_DEV_SOF [17:17]    Set every time the device receives a SOF Start of Frame packet. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTS_SETUP_REQ [16:16]    Device. Source: SIE_STATUS.SETUP_REC 
       @ .equ USBCTRL_REGS_INTS_DEV_RESUME_FROM_HOST [15:15]    Set when the device receives a resume from the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTS_DEV_SUSPEND [14:14]    Set when the device suspend state changes. Cleared by writing to SIE_STATUS.SUSPENDED 
       @ .equ USBCTRL_REGS_INTS_DEV_CONN_DIS [13:13]    Set when the device connection state changes. Cleared by writing to SIE_STATUS.CONNECTED 
       @ .equ USBCTRL_REGS_INTS_BUS_RESET [12:12]    Source: SIE_STATUS.BUS_RESET 
       @ .equ USBCTRL_REGS_INTS_VBUS_DETECT [11:11]    Source: SIE_STATUS.VBUS_DETECT 
       @ .equ USBCTRL_REGS_INTS_STALL [10:10]    Source: SIE_STATUS.STALL_REC 
       @ .equ USBCTRL_REGS_INTS_ERROR_CRC [9:9]    Source: SIE_STATUS.CRC_ERROR 
       @ .equ USBCTRL_REGS_INTS_ERROR_BIT_STUFF [8:8]    Source: SIE_STATUS.BIT_STUFF_ERROR 
       @ .equ USBCTRL_REGS_INTS_ERROR_RX_OVERFLOW [7:7]    Source: SIE_STATUS.RX_OVERFLOW 
       @ .equ USBCTRL_REGS_INTS_ERROR_RX_TIMEOUT [6:6]    Source: SIE_STATUS.RX_TIMEOUT 
       @ .equ USBCTRL_REGS_INTS_ERROR_DATA_SEQ [5:5]    Source: SIE_STATUS.DATA_SEQ_ERROR 
       @ .equ USBCTRL_REGS_INTS_BUFF_STATUS [4:4]    Raised when any bit in BUFF_STATUS is set. Clear by clearing all bits in BUFF_STATUS. 
       @ .equ USBCTRL_REGS_INTS_TRANS_COMPLETE [3:3]    Raised every time SIE_STATUS.TRANS_COMPLETE is set. Clear by writing to this bit. 
       @ .equ USBCTRL_REGS_INTS_HOST_SOF [2:2]    Host: raised every time the host sends a SOF Start of Frame. Cleared by reading SOF_RD 
       @ .equ USBCTRL_REGS_INTS_HOST_RESUME [1:1]    Host: raised when a device wakes up the host. Cleared by writing to SIE_STATUS.RESUME 
       @ .equ USBCTRL_REGS_INTS_HOST_CONN_DIS [0:0]    Host: raised when a device is connected or disconnected i.e. when SIE_STATUS.SPEED changes. Cleared by writing to SIE_STATUS.SPEED 
 

@=========================== PIO0 ===========================@
.equ PIO0_BASE, 0x50200000 
    .equ PIO0_CTRL_OFFSET, 0x0000 
       @ .equ PIO0_CTRL_CLKDIV_RESTART [11:8]    Force clock dividers to restart their count and clear fractional\n  accumulators. Restart multiple dividers to synchronise them. 
       @ .equ PIO0_CTRL_SM_RESTART [7:4]    Clear internal SM state which is otherwise difficult to access\n  e.g. shift counters. Self-clearing. 
       @ .equ PIO0_CTRL_SM_ENABLE [3:0]    Enable state machine 
 
    .equ PIO0_FSTAT_OFFSET, 0x0004 
       @ .equ PIO0_FSTAT_TXEMPTY [27:24]    State machine TX FIFO is empty 
       @ .equ PIO0_FSTAT_TXFULL [19:16]    State machine TX FIFO is full 
       @ .equ PIO0_FSTAT_RXEMPTY [11:8]    State machine RX FIFO is empty 
       @ .equ PIO0_FSTAT_RXFULL [3:0]    State machine RX FIFO is full 
 
    .equ PIO0_FDEBUG_OFFSET, 0x0008 
       @ .equ PIO0_FDEBUG_TXSTALL [27:24]    State machine has stalled on empty TX FIFO. Write 1 to clear. 
       @ .equ PIO0_FDEBUG_TXOVER [19:16]    TX FIFO overflow has occurred. Write 1 to clear. 
       @ .equ PIO0_FDEBUG_RXUNDER [11:8]    RX FIFO underflow has occurred. Write 1 to clear. 
       @ .equ PIO0_FDEBUG_RXSTALL [3:0]    State machine has stalled on full RX FIFO. Write 1 to clear. 
 
    .equ PIO0_FLEVEL_OFFSET, 0x000c 
       @ .equ PIO0_FLEVEL_RX3 [31:28]     
       @ .equ PIO0_FLEVEL_TX3 [27:24]     
       @ .equ PIO0_FLEVEL_RX2 [23:20]     
       @ .equ PIO0_FLEVEL_TX2 [19:16]     
       @ .equ PIO0_FLEVEL_RX1 [15:12]     
       @ .equ PIO0_FLEVEL_TX1 [11:8]     
       @ .equ PIO0_FLEVEL_RX0 [7:4]     
       @ .equ PIO0_FLEVEL_TX0 [3:0]     
 
    .equ PIO0_TXF0_OFFSET, 0x0010 
 
    .equ PIO0_TXF1_OFFSET, 0x0014 
 
    .equ PIO0_TXF2_OFFSET, 0x0018 
 
    .equ PIO0_TXF3_OFFSET, 0x001c 
 
    .equ PIO0_RXF0_OFFSET, 0x0020 
 
    .equ PIO0_RXF1_OFFSET, 0x0024 
 
    .equ PIO0_RXF2_OFFSET, 0x0028 
 
    .equ PIO0_RXF3_OFFSET, 0x002c 
 
    .equ PIO0_IRQ_OFFSET, 0x0030 
       @ .equ PIO0_IRQ_IRQ [7:0]     
 
    .equ PIO0_IRQ_FORCE_OFFSET, 0x0034 
       @ .equ PIO0_IRQ_FORCE_IRQ_FORCE [7:0]     
 
    .equ PIO0_INPUT_SYNC_BYPASS_OFFSET, 0x0038 
 
    .equ PIO0_DBG_PADOUT_OFFSET, 0x003c 
 
    .equ PIO0_DBG_PADOE_OFFSET, 0x0040 
 
    .equ PIO0_DBG_CFGINFO_OFFSET, 0x0044 
       @ .equ PIO0_DBG_CFGINFO_IMEM_SIZE [21:16]    The size of the instruction memory, measured in units of one instruction 
       @ .equ PIO0_DBG_CFGINFO_SM_COUNT [11:8]    The number of state machines this PIO instance is equipped with. 
       @ .equ PIO0_DBG_CFGINFO_FIFO_DEPTH [5:0]    The depth of the state machine TX/RX FIFOs, measured in words.\n  Joining fifos via SHIFTCTRL_FJOIN gives one FIFO with double\n  this depth. 
 
    .equ PIO0_INSTR_MEM0_OFFSET, 0x0048 
       @ .equ PIO0_INSTR_MEM0_INSTR_MEM0 [15:0]     
 
    .equ PIO0_INSTR_MEM1_OFFSET, 0x004c 
       @ .equ PIO0_INSTR_MEM1_INSTR_MEM1 [15:0]     
 
    .equ PIO0_INSTR_MEM2_OFFSET, 0x0050 
       @ .equ PIO0_INSTR_MEM2_INSTR_MEM2 [15:0]     
 
    .equ PIO0_INSTR_MEM3_OFFSET, 0x0054 
       @ .equ PIO0_INSTR_MEM3_INSTR_MEM3 [15:0]     
 
    .equ PIO0_INSTR_MEM4_OFFSET, 0x0058 
       @ .equ PIO0_INSTR_MEM4_INSTR_MEM4 [15:0]     
 
    .equ PIO0_INSTR_MEM5_OFFSET, 0x005c 
       @ .equ PIO0_INSTR_MEM5_INSTR_MEM5 [15:0]     
 
    .equ PIO0_INSTR_MEM6_OFFSET, 0x0060 
       @ .equ PIO0_INSTR_MEM6_INSTR_MEM6 [15:0]     
 
    .equ PIO0_INSTR_MEM7_OFFSET, 0x0064 
       @ .equ PIO0_INSTR_MEM7_INSTR_MEM7 [15:0]     
 
    .equ PIO0_INSTR_MEM8_OFFSET, 0x0068 
       @ .equ PIO0_INSTR_MEM8_INSTR_MEM8 [15:0]     
 
    .equ PIO0_INSTR_MEM9_OFFSET, 0x006c 
       @ .equ PIO0_INSTR_MEM9_INSTR_MEM9 [15:0]     
 
    .equ PIO0_INSTR_MEM10_OFFSET, 0x0070 
       @ .equ PIO0_INSTR_MEM10_INSTR_MEM10 [15:0]     
 
    .equ PIO0_INSTR_MEM11_OFFSET, 0x0074 
       @ .equ PIO0_INSTR_MEM11_INSTR_MEM11 [15:0]     
 
    .equ PIO0_INSTR_MEM12_OFFSET, 0x0078 
       @ .equ PIO0_INSTR_MEM12_INSTR_MEM12 [15:0]     
 
    .equ PIO0_INSTR_MEM13_OFFSET, 0x007c 
       @ .equ PIO0_INSTR_MEM13_INSTR_MEM13 [15:0]     
 
    .equ PIO0_INSTR_MEM14_OFFSET, 0x0080 
       @ .equ PIO0_INSTR_MEM14_INSTR_MEM14 [15:0]     
 
    .equ PIO0_INSTR_MEM15_OFFSET, 0x0084 
       @ .equ PIO0_INSTR_MEM15_INSTR_MEM15 [15:0]     
 
    .equ PIO0_INSTR_MEM16_OFFSET, 0x0088 
       @ .equ PIO0_INSTR_MEM16_INSTR_MEM16 [15:0]     
 
    .equ PIO0_INSTR_MEM17_OFFSET, 0x008c 
       @ .equ PIO0_INSTR_MEM17_INSTR_MEM17 [15:0]     
 
    .equ PIO0_INSTR_MEM18_OFFSET, 0x0090 
       @ .equ PIO0_INSTR_MEM18_INSTR_MEM18 [15:0]     
 
    .equ PIO0_INSTR_MEM19_OFFSET, 0x0094 
       @ .equ PIO0_INSTR_MEM19_INSTR_MEM19 [15:0]     
 
    .equ PIO0_INSTR_MEM20_OFFSET, 0x0098 
       @ .equ PIO0_INSTR_MEM20_INSTR_MEM20 [15:0]     
 
    .equ PIO0_INSTR_MEM21_OFFSET, 0x009c 
       @ .equ PIO0_INSTR_MEM21_INSTR_MEM21 [15:0]     
 
    .equ PIO0_INSTR_MEM22_OFFSET, 0x00a0 
       @ .equ PIO0_INSTR_MEM22_INSTR_MEM22 [15:0]     
 
    .equ PIO0_INSTR_MEM23_OFFSET, 0x00a4 
       @ .equ PIO0_INSTR_MEM23_INSTR_MEM23 [15:0]     
 
    .equ PIO0_INSTR_MEM24_OFFSET, 0x00a8 
       @ .equ PIO0_INSTR_MEM24_INSTR_MEM24 [15:0]     
 
    .equ PIO0_INSTR_MEM25_OFFSET, 0x00ac 
       @ .equ PIO0_INSTR_MEM25_INSTR_MEM25 [15:0]     
 
    .equ PIO0_INSTR_MEM26_OFFSET, 0x00b0 
       @ .equ PIO0_INSTR_MEM26_INSTR_MEM26 [15:0]     
 
    .equ PIO0_INSTR_MEM27_OFFSET, 0x00b4 
       @ .equ PIO0_INSTR_MEM27_INSTR_MEM27 [15:0]     
 
    .equ PIO0_INSTR_MEM28_OFFSET, 0x00b8 
       @ .equ PIO0_INSTR_MEM28_INSTR_MEM28 [15:0]     
 
    .equ PIO0_INSTR_MEM29_OFFSET, 0x00bc 
       @ .equ PIO0_INSTR_MEM29_INSTR_MEM29 [15:0]     
 
    .equ PIO0_INSTR_MEM30_OFFSET, 0x00c0 
       @ .equ PIO0_INSTR_MEM30_INSTR_MEM30 [15:0]     
 
    .equ PIO0_INSTR_MEM31_OFFSET, 0x00c4 
       @ .equ PIO0_INSTR_MEM31_INSTR_MEM31 [15:0]     
 
    .equ PIO0_SM0_CLKDIV_OFFSET, 0x00c8 
       @ .equ PIO0_SM0_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO0_SM0_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM0_EXECCTRL_OFFSET, 0x00cc 
       @ .equ PIO0_SM0_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO0_SM0_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO0_SM0_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO0_SM0_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO0_SM0_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO0_SM0_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO0_SM0_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO0_SM0_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO0_SM0_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO0_SM0_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO0_SM0_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM0_SHIFTCTRL_OFFSET, 0x00d0 
       @ .equ PIO0_SM0_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM0_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM0_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM0_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM0_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO0_SM0_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO0_SM0_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO0_SM0_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM0_ADDR_OFFSET, 0x00d4 
       @ .equ PIO0_SM0_ADDR_SM0_ADDR [4:0]     
 
    .equ PIO0_SM0_INSTR_OFFSET, 0x00d8 
       @ .equ PIO0_SM0_INSTR_SM0_INSTR [15:0]     
 
    .equ PIO0_SM0_PINCTRL_OFFSET, 0x00dc 
       @ .equ PIO0_SM0_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO0_SM0_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO0_SM0_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO0_SM0_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO0_SM0_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO0_SM0_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO0_SM0_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_SM1_CLKDIV_OFFSET, 0x00e0 
       @ .equ PIO0_SM1_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO0_SM1_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM1_EXECCTRL_OFFSET, 0x00e4 
       @ .equ PIO0_SM1_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO0_SM1_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO0_SM1_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO0_SM1_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO0_SM1_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO0_SM1_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO0_SM1_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO0_SM1_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO0_SM1_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO0_SM1_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO0_SM1_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM1_SHIFTCTRL_OFFSET, 0x00e8 
       @ .equ PIO0_SM1_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM1_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM1_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM1_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM1_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO0_SM1_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO0_SM1_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO0_SM1_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM1_ADDR_OFFSET, 0x00ec 
       @ .equ PIO0_SM1_ADDR_SM1_ADDR [4:0]     
 
    .equ PIO0_SM1_INSTR_OFFSET, 0x00f0 
       @ .equ PIO0_SM1_INSTR_SM1_INSTR [15:0]     
 
    .equ PIO0_SM1_PINCTRL_OFFSET, 0x00f4 
       @ .equ PIO0_SM1_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO0_SM1_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO0_SM1_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO0_SM1_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO0_SM1_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO0_SM1_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO0_SM1_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_SM2_CLKDIV_OFFSET, 0x00f8 
       @ .equ PIO0_SM2_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO0_SM2_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM2_EXECCTRL_OFFSET, 0x00fc 
       @ .equ PIO0_SM2_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO0_SM2_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO0_SM2_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO0_SM2_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO0_SM2_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO0_SM2_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO0_SM2_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO0_SM2_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO0_SM2_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO0_SM2_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO0_SM2_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM2_SHIFTCTRL_OFFSET, 0x0100 
       @ .equ PIO0_SM2_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM2_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM2_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM2_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM2_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO0_SM2_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO0_SM2_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO0_SM2_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM2_ADDR_OFFSET, 0x0104 
       @ .equ PIO0_SM2_ADDR_SM2_ADDR [4:0]     
 
    .equ PIO0_SM2_INSTR_OFFSET, 0x0108 
       @ .equ PIO0_SM2_INSTR_SM2_INSTR [15:0]     
 
    .equ PIO0_SM2_PINCTRL_OFFSET, 0x010c 
       @ .equ PIO0_SM2_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO0_SM2_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO0_SM2_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO0_SM2_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO0_SM2_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO0_SM2_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO0_SM2_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_SM3_CLKDIV_OFFSET, 0x0110 
       @ .equ PIO0_SM3_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO0_SM3_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO0_SM3_EXECCTRL_OFFSET, 0x0114 
       @ .equ PIO0_SM3_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO0_SM3_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO0_SM3_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO0_SM3_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO0_SM3_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO0_SM3_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO0_SM3_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO0_SM3_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO0_SM3_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO0_SM3_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO0_SM3_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO0_SM3_SHIFTCTRL_OFFSET, 0x0118 
       @ .equ PIO0_SM3_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM3_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO0_SM3_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM3_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO0_SM3_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO0_SM3_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO0_SM3_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO0_SM3_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO0_SM3_ADDR_OFFSET, 0x011c 
       @ .equ PIO0_SM3_ADDR_SM3_ADDR [4:0]     
 
    .equ PIO0_SM3_INSTR_OFFSET, 0x0120 
       @ .equ PIO0_SM3_INSTR_SM3_INSTR [15:0]     
 
    .equ PIO0_SM3_PINCTRL_OFFSET, 0x0124 
       @ .equ PIO0_SM3_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO0_SM3_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO0_SM3_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO0_SM3_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO0_SM3_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO0_SM3_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO0_SM3_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO0_INTR_OFFSET, 0x0128 
       @ .equ PIO0_INTR_SM3 [11:11]     
       @ .equ PIO0_INTR_SM2 [10:10]     
       @ .equ PIO0_INTR_SM1 [9:9]     
       @ .equ PIO0_INTR_SM0 [8:8]     
       @ .equ PIO0_INTR_SM3_TXNFULL [7:7]     
       @ .equ PIO0_INTR_SM2_TXNFULL [6:6]     
       @ .equ PIO0_INTR_SM1_TXNFULL [5:5]     
       @ .equ PIO0_INTR_SM0_TXNFULL [4:4]     
       @ .equ PIO0_INTR_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_INTR_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_INTR_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_INTR_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ0_INTE_OFFSET, 0x012c 
       @ .equ PIO0_IRQ0_INTE_SM3 [11:11]     
       @ .equ PIO0_IRQ0_INTE_SM2 [10:10]     
       @ .equ PIO0_IRQ0_INTE_SM1 [9:9]     
       @ .equ PIO0_IRQ0_INTE_SM0 [8:8]     
       @ .equ PIO0_IRQ0_INTE_SM3_TXNFULL [7:7]     
       @ .equ PIO0_IRQ0_INTE_SM2_TXNFULL [6:6]     
       @ .equ PIO0_IRQ0_INTE_SM1_TXNFULL [5:5]     
       @ .equ PIO0_IRQ0_INTE_SM0_TXNFULL [4:4]     
       @ .equ PIO0_IRQ0_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_IRQ0_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_IRQ0_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_IRQ0_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ0_INTF_OFFSET, 0x0130 
       @ .equ PIO0_IRQ0_INTF_SM3 [11:11]     
       @ .equ PIO0_IRQ0_INTF_SM2 [10:10]     
       @ .equ PIO0_IRQ0_INTF_SM1 [9:9]     
       @ .equ PIO0_IRQ0_INTF_SM0 [8:8]     
       @ .equ PIO0_IRQ0_INTF_SM3_TXNFULL [7:7]     
       @ .equ PIO0_IRQ0_INTF_SM2_TXNFULL [6:6]     
       @ .equ PIO0_IRQ0_INTF_SM1_TXNFULL [5:5]     
       @ .equ PIO0_IRQ0_INTF_SM0_TXNFULL [4:4]     
       @ .equ PIO0_IRQ0_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_IRQ0_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_IRQ0_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_IRQ0_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ0_INTS_OFFSET, 0x0134 
       @ .equ PIO0_IRQ0_INTS_SM3 [11:11]     
       @ .equ PIO0_IRQ0_INTS_SM2 [10:10]     
       @ .equ PIO0_IRQ0_INTS_SM1 [9:9]     
       @ .equ PIO0_IRQ0_INTS_SM0 [8:8]     
       @ .equ PIO0_IRQ0_INTS_SM3_TXNFULL [7:7]     
       @ .equ PIO0_IRQ0_INTS_SM2_TXNFULL [6:6]     
       @ .equ PIO0_IRQ0_INTS_SM1_TXNFULL [5:5]     
       @ .equ PIO0_IRQ0_INTS_SM0_TXNFULL [4:4]     
       @ .equ PIO0_IRQ0_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_IRQ0_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_IRQ0_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_IRQ0_INTS_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ1_INTE_OFFSET, 0x0138 
       @ .equ PIO0_IRQ1_INTE_SM3 [11:11]     
       @ .equ PIO0_IRQ1_INTE_SM2 [10:10]     
       @ .equ PIO0_IRQ1_INTE_SM1 [9:9]     
       @ .equ PIO0_IRQ1_INTE_SM0 [8:8]     
       @ .equ PIO0_IRQ1_INTE_SM3_TXNFULL [7:7]     
       @ .equ PIO0_IRQ1_INTE_SM2_TXNFULL [6:6]     
       @ .equ PIO0_IRQ1_INTE_SM1_TXNFULL [5:5]     
       @ .equ PIO0_IRQ1_INTE_SM0_TXNFULL [4:4]     
       @ .equ PIO0_IRQ1_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_IRQ1_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_IRQ1_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_IRQ1_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ1_INTF_OFFSET, 0x013c 
       @ .equ PIO0_IRQ1_INTF_SM3 [11:11]     
       @ .equ PIO0_IRQ1_INTF_SM2 [10:10]     
       @ .equ PIO0_IRQ1_INTF_SM1 [9:9]     
       @ .equ PIO0_IRQ1_INTF_SM0 [8:8]     
       @ .equ PIO0_IRQ1_INTF_SM3_TXNFULL [7:7]     
       @ .equ PIO0_IRQ1_INTF_SM2_TXNFULL [6:6]     
       @ .equ PIO0_IRQ1_INTF_SM1_TXNFULL [5:5]     
       @ .equ PIO0_IRQ1_INTF_SM0_TXNFULL [4:4]     
       @ .equ PIO0_IRQ1_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_IRQ1_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_IRQ1_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_IRQ1_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO0_IRQ1_INTS_OFFSET, 0x0140 
       @ .equ PIO0_IRQ1_INTS_SM3 [11:11]     
       @ .equ PIO0_IRQ1_INTS_SM2 [10:10]     
       @ .equ PIO0_IRQ1_INTS_SM1 [9:9]     
       @ .equ PIO0_IRQ1_INTS_SM0 [8:8]     
       @ .equ PIO0_IRQ1_INTS_SM3_TXNFULL [7:7]     
       @ .equ PIO0_IRQ1_INTS_SM2_TXNFULL [6:6]     
       @ .equ PIO0_IRQ1_INTS_SM1_TXNFULL [5:5]     
       @ .equ PIO0_IRQ1_INTS_SM0_TXNFULL [4:4]     
       @ .equ PIO0_IRQ1_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ PIO0_IRQ1_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ PIO0_IRQ1_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ PIO0_IRQ1_INTS_SM0_RXNEMPTY [0:0]     
 

@=========================== PIO1 ===========================@
.equ PIO1_BASE, 0x50300000 
    .equ PIO1_CTRL_OFFSET, 0x0000 
       @ .equ PIO1_CTRL_CLKDIV_RESTART [11:8]    Force clock dividers to restart their count and clear fractional\n  accumulators. Restart multiple dividers to synchronise them. 
       @ .equ PIO1_CTRL_SM_RESTART [7:4]    Clear internal SM state which is otherwise difficult to access\n  e.g. shift counters. Self-clearing. 
       @ .equ PIO1_CTRL_SM_ENABLE [3:0]    Enable state machine 
 
    .equ PIO1_FSTAT_OFFSET, 0x0004 
       @ .equ PIO1_FSTAT_TXEMPTY [27:24]    State machine TX FIFO is empty 
       @ .equ PIO1_FSTAT_TXFULL [19:16]    State machine TX FIFO is full 
       @ .equ PIO1_FSTAT_RXEMPTY [11:8]    State machine RX FIFO is empty 
       @ .equ PIO1_FSTAT_RXFULL [3:0]    State machine RX FIFO is full 
 
    .equ PIO1_FDEBUG_OFFSET, 0x0008 
       @ .equ PIO1_FDEBUG_TXSTALL [27:24]    State machine has stalled on empty TX FIFO. Write 1 to clear. 
       @ .equ PIO1_FDEBUG_TXOVER [19:16]    TX FIFO overflow has occurred. Write 1 to clear. 
       @ .equ PIO1_FDEBUG_RXUNDER [11:8]    RX FIFO underflow has occurred. Write 1 to clear. 
       @ .equ PIO1_FDEBUG_RXSTALL [3:0]    State machine has stalled on full RX FIFO. Write 1 to clear. 
 
    .equ PIO1_FLEVEL_OFFSET, 0x000c 
       @ .equ PIO1_FLEVEL_RX3 [31:28]     
       @ .equ PIO1_FLEVEL_TX3 [27:24]     
       @ .equ PIO1_FLEVEL_RX2 [23:20]     
       @ .equ PIO1_FLEVEL_TX2 [19:16]     
       @ .equ PIO1_FLEVEL_RX1 [15:12]     
       @ .equ PIO1_FLEVEL_TX1 [11:8]     
       @ .equ PIO1_FLEVEL_RX0 [7:4]     
       @ .equ PIO1_FLEVEL_TX0 [3:0]     
 
    .equ PIO1_TXF0_OFFSET, 0x0010 
 
    .equ PIO1_TXF1_OFFSET, 0x0014 
 
    .equ PIO1_TXF2_OFFSET, 0x0018 
 
    .equ PIO1_TXF3_OFFSET, 0x001c 
 
    .equ PIO1_RXF0_OFFSET, 0x0020 
 
    .equ PIO1_RXF1_OFFSET, 0x0024 
 
    .equ PIO1_RXF2_OFFSET, 0x0028 
 
    .equ PIO1_RXF3_OFFSET, 0x002c 
 
    .equ PIO1_IRQ_OFFSET, 0x0030 
       @ .equ PIO1_IRQ_IRQ [7:0]     
 
    .equ PIO1_IRQ_FORCE_OFFSET, 0x0034 
       @ .equ PIO1_IRQ_FORCE_IRQ_FORCE [7:0]     
 
    .equ PIO1_INPUT_SYNC_BYPASS_OFFSET, 0x0038 
 
    .equ PIO1_DBG_PADOUT_OFFSET, 0x003c 
 
    .equ PIO1_DBG_PADOE_OFFSET, 0x0040 
 
    .equ PIO1_DBG_CFGINFO_OFFSET, 0x0044 
       @ .equ PIO1_DBG_CFGINFO_IMEM_SIZE [21:16]    The size of the instruction memory, measured in units of one instruction 
       @ .equ PIO1_DBG_CFGINFO_SM_COUNT [11:8]    The number of state machines this PIO instance is equipped with. 
       @ .equ PIO1_DBG_CFGINFO_FIFO_DEPTH [5:0]    The depth of the state machine TX/RX FIFOs, measured in words.\n  Joining fifos via SHIFTCTRL_FJOIN gives one FIFO with double\n  this depth. 
 
    .equ PIO1_INSTR_MEM0_OFFSET, 0x0048 
       @ .equ PIO1_INSTR_MEM0_INSTR_MEM0 [15:0]     
 
    .equ PIO1_INSTR_MEM1_OFFSET, 0x004c 
       @ .equ PIO1_INSTR_MEM1_INSTR_MEM1 [15:0]     
 
    .equ PIO1_INSTR_MEM2_OFFSET, 0x0050 
       @ .equ PIO1_INSTR_MEM2_INSTR_MEM2 [15:0]     
 
    .equ PIO1_INSTR_MEM3_OFFSET, 0x0054 
       @ .equ PIO1_INSTR_MEM3_INSTR_MEM3 [15:0]     
 
    .equ PIO1_INSTR_MEM4_OFFSET, 0x0058 
       @ .equ PIO1_INSTR_MEM4_INSTR_MEM4 [15:0]     
 
    .equ PIO1_INSTR_MEM5_OFFSET, 0x005c 
       @ .equ PIO1_INSTR_MEM5_INSTR_MEM5 [15:0]     
 
    .equ PIO1_INSTR_MEM6_OFFSET, 0x0060 
       @ .equ PIO1_INSTR_MEM6_INSTR_MEM6 [15:0]     
 
    .equ PIO1_INSTR_MEM7_OFFSET, 0x0064 
       @ .equ PIO1_INSTR_MEM7_INSTR_MEM7 [15:0]     
 
    .equ PIO1_INSTR_MEM8_OFFSET, 0x0068 
       @ .equ PIO1_INSTR_MEM8_INSTR_MEM8 [15:0]     
 
    .equ PIO1_INSTR_MEM9_OFFSET, 0x006c 
       @ .equ PIO1_INSTR_MEM9_INSTR_MEM9 [15:0]     
 
    .equ PIO1_INSTR_MEM10_OFFSET, 0x0070 
       @ .equ PIO1_INSTR_MEM10_INSTR_MEM10 [15:0]     
 
    .equ PIO1_INSTR_MEM11_OFFSET, 0x0074 
       @ .equ PIO1_INSTR_MEM11_INSTR_MEM11 [15:0]     
 
    .equ PIO1_INSTR_MEM12_OFFSET, 0x0078 
       @ .equ PIO1_INSTR_MEM12_INSTR_MEM12 [15:0]     
 
    .equ PIO1_INSTR_MEM13_OFFSET, 0x007c 
       @ .equ PIO1_INSTR_MEM13_INSTR_MEM13 [15:0]     
 
    .equ PIO1_INSTR_MEM14_OFFSET, 0x0080 
       @ .equ PIO1_INSTR_MEM14_INSTR_MEM14 [15:0]     
 
    .equ PIO1_INSTR_MEM15_OFFSET, 0x0084 
       @ .equ PIO1_INSTR_MEM15_INSTR_MEM15 [15:0]     
 
    .equ PIO1_INSTR_MEM16_OFFSET, 0x0088 
       @ .equ PIO1_INSTR_MEM16_INSTR_MEM16 [15:0]     
 
    .equ PIO1_INSTR_MEM17_OFFSET, 0x008c 
       @ .equ PIO1_INSTR_MEM17_INSTR_MEM17 [15:0]     
 
    .equ PIO1_INSTR_MEM18_OFFSET, 0x0090 
       @ .equ PIO1_INSTR_MEM18_INSTR_MEM18 [15:0]     
 
    .equ PIO1_INSTR_MEM19_OFFSET, 0x0094 
       @ .equ PIO1_INSTR_MEM19_INSTR_MEM19 [15:0]     
 
    .equ PIO1_INSTR_MEM20_OFFSET, 0x0098 
       @ .equ PIO1_INSTR_MEM20_INSTR_MEM20 [15:0]     
 
    .equ PIO1_INSTR_MEM21_OFFSET, 0x009c 
       @ .equ PIO1_INSTR_MEM21_INSTR_MEM21 [15:0]     
 
    .equ PIO1_INSTR_MEM22_OFFSET, 0x00a0 
       @ .equ PIO1_INSTR_MEM22_INSTR_MEM22 [15:0]     
 
    .equ PIO1_INSTR_MEM23_OFFSET, 0x00a4 
       @ .equ PIO1_INSTR_MEM23_INSTR_MEM23 [15:0]     
 
    .equ PIO1_INSTR_MEM24_OFFSET, 0x00a8 
       @ .equ PIO1_INSTR_MEM24_INSTR_MEM24 [15:0]     
 
    .equ PIO1_INSTR_MEM25_OFFSET, 0x00ac 
       @ .equ PIO1_INSTR_MEM25_INSTR_MEM25 [15:0]     
 
    .equ PIO1_INSTR_MEM26_OFFSET, 0x00b0 
       @ .equ PIO1_INSTR_MEM26_INSTR_MEM26 [15:0]     
 
    .equ PIO1_INSTR_MEM27_OFFSET, 0x00b4 
       @ .equ PIO1_INSTR_MEM27_INSTR_MEM27 [15:0]     
 
    .equ PIO1_INSTR_MEM28_OFFSET, 0x00b8 
       @ .equ PIO1_INSTR_MEM28_INSTR_MEM28 [15:0]     
 
    .equ PIO1_INSTR_MEM29_OFFSET, 0x00bc 
       @ .equ PIO1_INSTR_MEM29_INSTR_MEM29 [15:0]     
 
    .equ PIO1_INSTR_MEM30_OFFSET, 0x00c0 
       @ .equ PIO1_INSTR_MEM30_INSTR_MEM30 [15:0]     
 
    .equ PIO1_INSTR_MEM31_OFFSET, 0x00c4 
       @ .equ PIO1_INSTR_MEM31_INSTR_MEM31 [15:0]     
 
    .equ PIO1_SM0_CLKDIV_OFFSET, 0x00c8 
       @ .equ PIO1_SM0_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO1_SM0_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM0_EXECCTRL_OFFSET, 0x00cc 
       @ .equ PIO1_SM0_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO1_SM0_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO1_SM0_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO1_SM0_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO1_SM0_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO1_SM0_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO1_SM0_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO1_SM0_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO1_SM0_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO1_SM0_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO1_SM0_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM0_SHIFTCTRL_OFFSET, 0x00d0 
       @ .equ PIO1_SM0_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM0_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM0_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM0_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM0_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO1_SM0_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO1_SM0_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO1_SM0_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM0_ADDR_OFFSET, 0x00d4 
       @ .equ PIO1_SM0_ADDR_SM0_ADDR [4:0]     
 
    .equ PIO1_SM0_INSTR_OFFSET, 0x00d8 
       @ .equ PIO1_SM0_INSTR_SM0_INSTR [15:0]     
 
    .equ PIO1_SM0_PINCTRL_OFFSET, 0x00dc 
       @ .equ PIO1_SM0_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO1_SM0_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO1_SM0_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO1_SM0_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO1_SM0_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO1_SM0_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO1_SM0_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_SM1_CLKDIV_OFFSET, 0x00e0 
       @ .equ PIO1_SM1_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO1_SM1_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM1_EXECCTRL_OFFSET, 0x00e4 
       @ .equ PIO1_SM1_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO1_SM1_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO1_SM1_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO1_SM1_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO1_SM1_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO1_SM1_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO1_SM1_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO1_SM1_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO1_SM1_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO1_SM1_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO1_SM1_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM1_SHIFTCTRL_OFFSET, 0x00e8 
       @ .equ PIO1_SM1_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM1_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM1_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM1_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM1_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO1_SM1_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO1_SM1_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO1_SM1_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM1_ADDR_OFFSET, 0x00ec 
       @ .equ PIO1_SM1_ADDR_SM1_ADDR [4:0]     
 
    .equ PIO1_SM1_INSTR_OFFSET, 0x00f0 
       @ .equ PIO1_SM1_INSTR_SM1_INSTR [15:0]     
 
    .equ PIO1_SM1_PINCTRL_OFFSET, 0x00f4 
       @ .equ PIO1_SM1_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO1_SM1_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO1_SM1_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO1_SM1_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO1_SM1_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO1_SM1_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO1_SM1_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_SM2_CLKDIV_OFFSET, 0x00f8 
       @ .equ PIO1_SM2_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO1_SM2_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM2_EXECCTRL_OFFSET, 0x00fc 
       @ .equ PIO1_SM2_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO1_SM2_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO1_SM2_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO1_SM2_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO1_SM2_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO1_SM2_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO1_SM2_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO1_SM2_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO1_SM2_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO1_SM2_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO1_SM2_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM2_SHIFTCTRL_OFFSET, 0x0100 
       @ .equ PIO1_SM2_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM2_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM2_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM2_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM2_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO1_SM2_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO1_SM2_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO1_SM2_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM2_ADDR_OFFSET, 0x0104 
       @ .equ PIO1_SM2_ADDR_SM2_ADDR [4:0]     
 
    .equ PIO1_SM2_INSTR_OFFSET, 0x0108 
       @ .equ PIO1_SM2_INSTR_SM2_INSTR [15:0]     
 
    .equ PIO1_SM2_PINCTRL_OFFSET, 0x010c 
       @ .equ PIO1_SM2_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO1_SM2_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO1_SM2_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO1_SM2_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO1_SM2_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO1_SM2_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO1_SM2_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_SM3_CLKDIV_OFFSET, 0x0110 
       @ .equ PIO1_SM3_CLKDIV_INT [31:16]    Effective frequency is sysclk/int.\n  Value of 0 is interpreted as max possible value 
       @ .equ PIO1_SM3_CLKDIV_FRAC [15:8]    Fractional part of clock divider 
 
    .equ PIO1_SM3_EXECCTRL_OFFSET, 0x0114 
       @ .equ PIO1_SM3_EXECCTRL_EXEC_STALLED [31:31]    An instruction written to SMx_INSTR is stalled, and latched by the\n  state machine. Will clear once the instruction completes. 
       @ .equ PIO1_SM3_EXECCTRL_SIDE_EN [30:30]    If 1, the delay MSB is used as side-set enable, rather than a\n  side-set data bit. This allows instructions to perform side-set optionally,\n  rather than on every instruction. 
       @ .equ PIO1_SM3_EXECCTRL_SIDE_PINDIR [29:29]    Side-set data is asserted to pin OEs instead of pin values 
       @ .equ PIO1_SM3_EXECCTRL_JMP_PIN [28:24]    The GPIO number to use as condition for JMP PIN. Unaffected by input mapping. 
       @ .equ PIO1_SM3_EXECCTRL_OUT_EN_SEL [23:19]    Which data bit to use for inline OUT enable 
       @ .equ PIO1_SM3_EXECCTRL_INLINE_OUT_EN [18:18]    If 1, use a bit of OUT data as an auxiliary write enable\n  When used in conjunction with OUT_STICKY, writes with an enable of 0 will\n  deassert the latest pin write. This can create useful masking/override behaviour\n  due to the priority ordering of state machine pin writes SM0 < SM1 < ... 
       @ .equ PIO1_SM3_EXECCTRL_OUT_STICKY [17:17]    Continuously assert the most recent OUT/SET to the pins 
       @ .equ PIO1_SM3_EXECCTRL_WRAP_TOP [16:12]    After reaching this address, execution is wrapped to wrap_bottom.\n  If the instruction is a jump, and the jump condition is true, the jump takes priority. 
       @ .equ PIO1_SM3_EXECCTRL_WRAP_BOTTOM [11:7]    After reaching wrap_top, execution is wrapped to this address. 
       @ .equ PIO1_SM3_EXECCTRL_STATUS_SEL [4:4]    Comparison used for the MOV x, STATUS instruction. 
       @ .equ PIO1_SM3_EXECCTRL_STATUS_N [3:0]    Comparison level for the MOV x, STATUS instruction 
 
    .equ PIO1_SM3_SHIFTCTRL_OFFSET, 0x0118 
       @ .equ PIO1_SM3_SHIFTCTRL_FJOIN_RX [31:31]    When 1, RX FIFO steals the TX FIFO's storage, and becomes twice as deep.\n  TX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM3_SHIFTCTRL_FJOIN_TX [30:30]    When 1, TX FIFO steals the RX FIFO's storage, and becomes twice as deep.\n  RX FIFO is disabled as a result always reads as both full and empty.\n  FIFOs are flushed when this bit is changed. 
       @ .equ PIO1_SM3_SHIFTCTRL_PULL_THRESH [29:25]    Number of bits shifted out of TXSR before autopull or conditional pull.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM3_SHIFTCTRL_PUSH_THRESH [24:20]    Number of bits shifted into RXSR before autopush or conditional push.\n  Write 0 for value of 32. 
       @ .equ PIO1_SM3_SHIFTCTRL_OUT_SHIFTDIR [19:19]    1 = shift out of output shift register to right. 0 = to left. 
       @ .equ PIO1_SM3_SHIFTCTRL_IN_SHIFTDIR [18:18]    1 = shift input shift register to right data enters from left. 0 = to left. 
       @ .equ PIO1_SM3_SHIFTCTRL_AUTOPULL [17:17]    Pull automatically when the output shift register is emptied 
       @ .equ PIO1_SM3_SHIFTCTRL_AUTOPUSH [16:16]    Push automatically when the input shift register is filled 
 
    .equ PIO1_SM3_ADDR_OFFSET, 0x011c 
       @ .equ PIO1_SM3_ADDR_SM3_ADDR [4:0]     
 
    .equ PIO1_SM3_INSTR_OFFSET, 0x0120 
       @ .equ PIO1_SM3_INSTR_SM3_INSTR [15:0]     
 
    .equ PIO1_SM3_PINCTRL_OFFSET, 0x0124 
       @ .equ PIO1_SM3_PINCTRL_SIDESET_COUNT [31:29]    The number of delay bits co-opted for side-set. Inclusive of the enable bit, if present. 
       @ .equ PIO1_SM3_PINCTRL_SET_COUNT [28:26]    The number of pins asserted by a SET. Max of 5 
       @ .equ PIO1_SM3_PINCTRL_OUT_COUNT [25:20]    The number of pins asserted by an OUT. Value of 0 -> 32 pins 
       @ .equ PIO1_SM3_PINCTRL_IN_BASE [19:15]    The virtual pin corresponding to IN bit 0 
       @ .equ PIO1_SM3_PINCTRL_SIDESET_BASE [14:10]    The virtual pin corresponding to delay field bit 0 
       @ .equ PIO1_SM3_PINCTRL_SET_BASE [9:5]    The virtual pin corresponding to SET bit 0 
       @ .equ PIO1_SM3_PINCTRL_OUT_BASE [4:0]    The virtual pin corresponding to OUT bit 0 
 
    .equ PIO1_INTR_OFFSET, 0x0128 
       @ .equ PIO1_INTR_SM3 [11:11]     
       @ .equ PIO1_INTR_SM2 [10:10]     
       @ .equ PIO1_INTR_SM1 [9:9]     
       @ .equ PIO1_INTR_SM0 [8:8]     
       @ .equ PIO1_INTR_SM3_TXNFULL [7:7]     
       @ .equ PIO1_INTR_SM2_TXNFULL [6:6]     
       @ .equ PIO1_INTR_SM1_TXNFULL [5:5]     
       @ .equ PIO1_INTR_SM0_TXNFULL [4:4]     
       @ .equ PIO1_INTR_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_INTR_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_INTR_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_INTR_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ0_INTE_OFFSET, 0x012c 
       @ .equ PIO1_IRQ0_INTE_SM3 [11:11]     
       @ .equ PIO1_IRQ0_INTE_SM2 [10:10]     
       @ .equ PIO1_IRQ0_INTE_SM1 [9:9]     
       @ .equ PIO1_IRQ0_INTE_SM0 [8:8]     
       @ .equ PIO1_IRQ0_INTE_SM3_TXNFULL [7:7]     
       @ .equ PIO1_IRQ0_INTE_SM2_TXNFULL [6:6]     
       @ .equ PIO1_IRQ0_INTE_SM1_TXNFULL [5:5]     
       @ .equ PIO1_IRQ0_INTE_SM0_TXNFULL [4:4]     
       @ .equ PIO1_IRQ0_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_IRQ0_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_IRQ0_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_IRQ0_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ0_INTF_OFFSET, 0x0130 
       @ .equ PIO1_IRQ0_INTF_SM3 [11:11]     
       @ .equ PIO1_IRQ0_INTF_SM2 [10:10]     
       @ .equ PIO1_IRQ0_INTF_SM1 [9:9]     
       @ .equ PIO1_IRQ0_INTF_SM0 [8:8]     
       @ .equ PIO1_IRQ0_INTF_SM3_TXNFULL [7:7]     
       @ .equ PIO1_IRQ0_INTF_SM2_TXNFULL [6:6]     
       @ .equ PIO1_IRQ0_INTF_SM1_TXNFULL [5:5]     
       @ .equ PIO1_IRQ0_INTF_SM0_TXNFULL [4:4]     
       @ .equ PIO1_IRQ0_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_IRQ0_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_IRQ0_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_IRQ0_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ0_INTS_OFFSET, 0x0134 
       @ .equ PIO1_IRQ0_INTS_SM3 [11:11]     
       @ .equ PIO1_IRQ0_INTS_SM2 [10:10]     
       @ .equ PIO1_IRQ0_INTS_SM1 [9:9]     
       @ .equ PIO1_IRQ0_INTS_SM0 [8:8]     
       @ .equ PIO1_IRQ0_INTS_SM3_TXNFULL [7:7]     
       @ .equ PIO1_IRQ0_INTS_SM2_TXNFULL [6:6]     
       @ .equ PIO1_IRQ0_INTS_SM1_TXNFULL [5:5]     
       @ .equ PIO1_IRQ0_INTS_SM0_TXNFULL [4:4]     
       @ .equ PIO1_IRQ0_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_IRQ0_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_IRQ0_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_IRQ0_INTS_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ1_INTE_OFFSET, 0x0138 
       @ .equ PIO1_IRQ1_INTE_SM3 [11:11]     
       @ .equ PIO1_IRQ1_INTE_SM2 [10:10]     
       @ .equ PIO1_IRQ1_INTE_SM1 [9:9]     
       @ .equ PIO1_IRQ1_INTE_SM0 [8:8]     
       @ .equ PIO1_IRQ1_INTE_SM3_TXNFULL [7:7]     
       @ .equ PIO1_IRQ1_INTE_SM2_TXNFULL [6:6]     
       @ .equ PIO1_IRQ1_INTE_SM1_TXNFULL [5:5]     
       @ .equ PIO1_IRQ1_INTE_SM0_TXNFULL [4:4]     
       @ .equ PIO1_IRQ1_INTE_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_IRQ1_INTE_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_IRQ1_INTE_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_IRQ1_INTE_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ1_INTF_OFFSET, 0x013c 
       @ .equ PIO1_IRQ1_INTF_SM3 [11:11]     
       @ .equ PIO1_IRQ1_INTF_SM2 [10:10]     
       @ .equ PIO1_IRQ1_INTF_SM1 [9:9]     
       @ .equ PIO1_IRQ1_INTF_SM0 [8:8]     
       @ .equ PIO1_IRQ1_INTF_SM3_TXNFULL [7:7]     
       @ .equ PIO1_IRQ1_INTF_SM2_TXNFULL [6:6]     
       @ .equ PIO1_IRQ1_INTF_SM1_TXNFULL [5:5]     
       @ .equ PIO1_IRQ1_INTF_SM0_TXNFULL [4:4]     
       @ .equ PIO1_IRQ1_INTF_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_IRQ1_INTF_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_IRQ1_INTF_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_IRQ1_INTF_SM0_RXNEMPTY [0:0]     
 
    .equ PIO1_IRQ1_INTS_OFFSET, 0x0140 
       @ .equ PIO1_IRQ1_INTS_SM3 [11:11]     
       @ .equ PIO1_IRQ1_INTS_SM2 [10:10]     
       @ .equ PIO1_IRQ1_INTS_SM1 [9:9]     
       @ .equ PIO1_IRQ1_INTS_SM0 [8:8]     
       @ .equ PIO1_IRQ1_INTS_SM3_TXNFULL [7:7]     
       @ .equ PIO1_IRQ1_INTS_SM2_TXNFULL [6:6]     
       @ .equ PIO1_IRQ1_INTS_SM1_TXNFULL [5:5]     
       @ .equ PIO1_IRQ1_INTS_SM0_TXNFULL [4:4]     
       @ .equ PIO1_IRQ1_INTS_SM3_RXNEMPTY [3:3]     
       @ .equ PIO1_IRQ1_INTS_SM2_RXNEMPTY [2:2]     
       @ .equ PIO1_IRQ1_INTS_SM1_RXNEMPTY [1:1]     
       @ .equ PIO1_IRQ1_INTS_SM0_RXNEMPTY [0:0]     
 

@=========================== SIO ===========================@
.equ SIO_BASE, 0xd0000000 
    .equ SIO_CPUID_OFFSET, 0x0000 
 
    .equ SIO_GPIO_IN_OFFSET, 0x0004 
       @ .equ SIO_GPIO_IN_GPIO_IN [29:0]    Input value for GPIO0...29 
 
    .equ SIO_GPIO_HI_IN_OFFSET, 0x0008 
       @ .equ SIO_GPIO_HI_IN_GPIO_HI_IN [5:0]    Input value on QSPI IO in order 0..5: SCLK, SSn, SD0, SD1, SD2, SD3 
 
    .equ SIO_GPIO_OUT_OFFSET, 0x0010 
       @ .equ SIO_GPIO_OUT_GPIO_OUT [29:0]    Set output level 1/0 -> high/low for GPIO0...29.\n  Reading back gives the last value written, NOT the input value from the pins.\n  If core 0 and core 1 both write to GPIO_OUT simultaneously or to a SET/CLR/XOR alias,\n  the result is as though the write from core 0 took place first,\n  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_OUT_SET_OFFSET, 0x0014 
       @ .equ SIO_GPIO_OUT_SET_GPIO_OUT_SET [29:0]    Perform an atomic bit-set on GPIO_OUT, i.e. `GPIO_OUT |= wdata` 
 
    .equ SIO_GPIO_OUT_CLR_OFFSET, 0x0018 
       @ .equ SIO_GPIO_OUT_CLR_GPIO_OUT_CLR [29:0]    Perform an atomic bit-clear on GPIO_OUT, i.e. `GPIO_OUT &= ~wdata` 
 
    .equ SIO_GPIO_OUT_XOR_OFFSET, 0x001c 
       @ .equ SIO_GPIO_OUT_XOR_GPIO_OUT_XOR [29:0]    Perform an atomic bitwise XOR on GPIO_OUT, i.e. `GPIO_OUT ^= wdata` 
 
    .equ SIO_GPIO_OE_OFFSET, 0x0020 
       @ .equ SIO_GPIO_OE_GPIO_OE [29:0]    Set output enable 1/0 -> output/input for GPIO0...29.\n  Reading back gives the last value written.\n  If core 0 and core 1 both write to GPIO_OE simultaneously or to a SET/CLR/XOR alias,\n  the result is as though the write from core 0 took place first,\n  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_OE_SET_OFFSET, 0x0024 
       @ .equ SIO_GPIO_OE_SET_GPIO_OE_SET [29:0]    Perform an atomic bit-set on GPIO_OE, i.e. `GPIO_OE |= wdata` 
 
    .equ SIO_GPIO_OE_CLR_OFFSET, 0x0028 
       @ .equ SIO_GPIO_OE_CLR_GPIO_OE_CLR [29:0]    Perform an atomic bit-clear on GPIO_OE, i.e. `GPIO_OE &= ~wdata` 
 
    .equ SIO_GPIO_OE_XOR_OFFSET, 0x002c 
       @ .equ SIO_GPIO_OE_XOR_GPIO_OE_XOR [29:0]    Perform an atomic bitwise XOR on GPIO_OE, i.e. `GPIO_OE ^= wdata` 
 
    .equ SIO_GPIO_HI_OUT_OFFSET, 0x0030 
       @ .equ SIO_GPIO_HI_OUT_GPIO_HI_OUT [5:0]    Set output level 1/0 -> high/low for QSPI IO0...5.\n  Reading back gives the last value written, NOT the input value from the pins.\n  If core 0 and core 1 both write to GPIO_HI_OUT simultaneously or to a SET/CLR/XOR alias,\n  the result is as though the write from core 0 took place first,\n  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_HI_OUT_SET_OFFSET, 0x0034 
       @ .equ SIO_GPIO_HI_OUT_SET_GPIO_HI_OUT_SET [5:0]    Perform an atomic bit-set on GPIO_HI_OUT, i.e. `GPIO_HI_OUT |= wdata` 
 
    .equ SIO_GPIO_HI_OUT_CLR_OFFSET, 0x0038 
       @ .equ SIO_GPIO_HI_OUT_CLR_GPIO_HI_OUT_CLR [5:0]    Perform an atomic bit-clear on GPIO_HI_OUT, i.e. `GPIO_HI_OUT &= ~wdata` 
 
    .equ SIO_GPIO_HI_OUT_XOR_OFFSET, 0x003c 
       @ .equ SIO_GPIO_HI_OUT_XOR_GPIO_HI_OUT_XOR [5:0]    Perform an atomic bitwise XOR on GPIO_HI_OUT, i.e. `GPIO_HI_OUT ^= wdata` 
 
    .equ SIO_GPIO_HI_OE_OFFSET, 0x0040 
       @ .equ SIO_GPIO_HI_OE_GPIO_HI_OE [5:0]    Set output enable 1/0 -> output/input for QSPI IO0...5.\n  Reading back gives the last value written.\n  If core 0 and core 1 both write to GPIO_HI_OE simultaneously or to a SET/CLR/XOR alias,\n  the result is as though the write from core 0 took place first,\n  and the write from core 1 was then applied to that intermediate result. 
 
    .equ SIO_GPIO_HI_OE_SET_OFFSET, 0x0044 
       @ .equ SIO_GPIO_HI_OE_SET_GPIO_HI_OE_SET [5:0]    Perform an atomic bit-set on GPIO_HI_OE, i.e. `GPIO_HI_OE |= wdata` 
 
    .equ SIO_GPIO_HI_OE_CLR_OFFSET, 0x0048 
       @ .equ SIO_GPIO_HI_OE_CLR_GPIO_HI_OE_CLR [5:0]    Perform an atomic bit-clear on GPIO_HI_OE, i.e. `GPIO_HI_OE &= ~wdata` 
 
    .equ SIO_GPIO_HI_OE_XOR_OFFSET, 0x004c 
       @ .equ SIO_GPIO_HI_OE_XOR_GPIO_HI_OE_XOR [5:0]    Perform an atomic bitwise XOR on GPIO_HI_OE, i.e. `GPIO_HI_OE ^= wdata` 
 
    .equ SIO_FIFO_ST_OFFSET, 0x0050 
       @ .equ SIO_FIFO_ST_ROE [3:3]    Sticky flag indicating the RX FIFO was read when empty. This read was ignored by the FIFO. 
       @ .equ SIO_FIFO_ST_WOF [2:2]    Sticky flag indicating the TX FIFO was written when full. This write was ignored by the FIFO. 
       @ .equ SIO_FIFO_ST_RDY [1:1]    Value is 1 if this core's TX FIFO is not full i.e. if FIFO_WR is ready for more data 
       @ .equ SIO_FIFO_ST_VLD [0:0]    Value is 1 if this core's RX FIFO is not empty i.e. if FIFO_RD is valid 
 
    .equ SIO_FIFO_WR_OFFSET, 0x0054 
 
    .equ SIO_FIFO_RD_OFFSET, 0x0058 
 
    .equ SIO_SPINLOCK_ST_OFFSET, 0x005c 
 
    .equ SIO_DIV_UDIVIDEND_OFFSET, 0x0060 
 
    .equ SIO_DIV_UDIVISOR_OFFSET, 0x0064 
 
    .equ SIO_DIV_SDIVIDEND_OFFSET, 0x0068 
 
    .equ SIO_DIV_SDIVISOR_OFFSET, 0x006c 
 
    .equ SIO_DIV_QUOTIENT_OFFSET, 0x0070 
 
    .equ SIO_DIV_REMAINDER_OFFSET, 0x0074 
 
    .equ SIO_DIV_CSR_OFFSET, 0x0078 
       @ .equ SIO_DIV_CSR_DIRTY [1:1]    Changes to 1 when any register is written, and back to 0 when QUOTIENT is read.\n  Software can use this flag to make save/restore more efficient skip if not DIRTY.\n  If the flag is used in this way, it's recommended to either read QUOTIENT only,\n  or REMAINDER and then QUOTIENT, to prevent data loss on context switch. 
       @ .equ SIO_DIV_CSR_READY [0:0]    Reads as 0 when a calculation is in progress, 1 otherwise.\n  Writing an operand xDIVIDEND, xDIVISOR will immediately start a new calculation, no\n  matter if one is already in progress.\n  Writing to a result register will immediately terminate any in-progress calculation\n  and set the READY and DIRTY flags. 
 
    .equ SIO_INTERP0_ACCUM0_OFFSET, 0x0080 
 
    .equ SIO_INTERP0_ACCUM1_OFFSET, 0x0084 
 
    .equ SIO_INTERP0_BASE0_OFFSET, 0x0088 
 
    .equ SIO_INTERP0_BASE1_OFFSET, 0x008c 
 
    .equ SIO_INTERP0_BASE2_OFFSET, 0x0090 
 
    .equ SIO_INTERP0_POP_LANE0_OFFSET, 0x0094 
 
    .equ SIO_INTERP0_POP_LANE1_OFFSET, 0x0098 
 
    .equ SIO_INTERP0_POP_FULL_OFFSET, 0x009c 
 
    .equ SIO_INTERP0_PEEK_LANE0_OFFSET, 0x00a0 
 
    .equ SIO_INTERP0_PEEK_LANE1_OFFSET, 0x00a4 
 
    .equ SIO_INTERP0_PEEK_FULL_OFFSET, 0x00a8 
 
    .equ SIO_INTERP0_CTRL_LANE0_OFFSET, 0x00ac 
       @ .equ SIO_INTERP0_CTRL_LANE0_OVERF [25:25]    Set if either OVERF0 or OVERF1 is set. 
       @ .equ SIO_INTERP0_CTRL_LANE0_OVERF1 [24:24]    Indicates if any masked-off MSBs in ACCUM1 are set. 
       @ .equ SIO_INTERP0_CTRL_LANE0_OVERF0 [23:23]    Indicates if any masked-off MSBs in ACCUM0 are set. 
       @ .equ SIO_INTERP0_CTRL_LANE0_BLEND [21:21]    Only present on INTERP0 on each core. If BLEND mode is enabled:\n  - LANE1 result is a linear interpolation between BASE0 and BASE1, controlled\n  by the 8 LSBs of lane 1 shift and mask value a fractional number between\n  0 and 255/256ths\n  - LANE0 result does not have BASE0 added yields only the 8 LSBs of lane 1 shift+mask value\n  - FULL result does not have lane 1 shift+mask value added BASE2 + lane 0 shift+mask\n  LANE1 SIGNED flag controls whether the interpolation is signed or unsigned. 
       @ .equ SIO_INTERP0_CTRL_LANE0_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.\n  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence\n  of pointers into flash or SRAM. 
       @ .equ SIO_INTERP0_CTRL_LANE0_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE0 result. This does not affect FULL result. 
       @ .equ SIO_INTERP0_CTRL_LANE0_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ SIO_INTERP0_CTRL_LANE0_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.\n  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ SIO_INTERP0_CTRL_LANE0_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits\n  before adding to BASE0, and LANE0 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ SIO_INTERP0_CTRL_LANE0_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive\n  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ SIO_INTERP0_CTRL_LANE0_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ SIO_INTERP0_CTRL_LANE0_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP0_CTRL_LANE1_OFFSET, 0x00b0 
       @ .equ SIO_INTERP0_CTRL_LANE1_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.\n  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence\n  of pointers into flash or SRAM. 
       @ .equ SIO_INTERP0_CTRL_LANE1_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE1 result. This does not affect FULL result. 
       @ .equ SIO_INTERP0_CTRL_LANE1_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ SIO_INTERP0_CTRL_LANE1_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.\n  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ SIO_INTERP0_CTRL_LANE1_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits\n  before adding to BASE1, and LANE1 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ SIO_INTERP0_CTRL_LANE1_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive\n  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ SIO_INTERP0_CTRL_LANE1_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ SIO_INTERP0_CTRL_LANE1_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP0_ACCUM0_ADD_OFFSET, 0x00b4 
       @ .equ SIO_INTERP0_ACCUM0_ADD_INTERP0_ACCUM0_ADD [23:0]     
 
    .equ SIO_INTERP0_ACCUM1_ADD_OFFSET, 0x00b8 
       @ .equ SIO_INTERP0_ACCUM1_ADD_INTERP0_ACCUM1_ADD [23:0]     
 
    .equ SIO_INTERP0_BASE_1AND0_OFFSET, 0x00bc 
 
    .equ SIO_INTERP1_ACCUM0_OFFSET, 0x00c0 
 
    .equ SIO_INTERP1_ACCUM1_OFFSET, 0x00c4 
 
    .equ SIO_INTERP1_BASE0_OFFSET, 0x00c8 
 
    .equ SIO_INTERP1_BASE1_OFFSET, 0x00cc 
 
    .equ SIO_INTERP1_BASE2_OFFSET, 0x00d0 
 
    .equ SIO_INTERP1_POP_LANE0_OFFSET, 0x00d4 
 
    .equ SIO_INTERP1_POP_LANE1_OFFSET, 0x00d8 
 
    .equ SIO_INTERP1_POP_FULL_OFFSET, 0x00dc 
 
    .equ SIO_INTERP1_PEEK_LANE0_OFFSET, 0x00e0 
 
    .equ SIO_INTERP1_PEEK_LANE1_OFFSET, 0x00e4 
 
    .equ SIO_INTERP1_PEEK_FULL_OFFSET, 0x00e8 
 
    .equ SIO_INTERP1_CTRL_LANE0_OFFSET, 0x00ec 
       @ .equ SIO_INTERP1_CTRL_LANE0_OVERF [25:25]    Set if either OVERF0 or OVERF1 is set. 
       @ .equ SIO_INTERP1_CTRL_LANE0_OVERF1 [24:24]    Indicates if any masked-off MSBs in ACCUM1 are set. 
       @ .equ SIO_INTERP1_CTRL_LANE0_OVERF0 [23:23]    Indicates if any masked-off MSBs in ACCUM0 are set. 
       @ .equ SIO_INTERP1_CTRL_LANE0_CLAMP [22:22]    Only present on INTERP1 on each core. If CLAMP mode is enabled:\n  - LANE0 result is shifted and masked ACCUM0, clamped by a lower bound of\n  BASE0 and an upper bound of BASE1.\n  - Signedness of these comparisons is determined by LANE0_CTRL_SIGNED 
       @ .equ SIO_INTERP1_CTRL_LANE0_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.\n  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence\n  of pointers into flash or SRAM. 
       @ .equ SIO_INTERP1_CTRL_LANE0_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE0 result. This does not affect FULL result. 
       @ .equ SIO_INTERP1_CTRL_LANE0_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ SIO_INTERP1_CTRL_LANE0_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.\n  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ SIO_INTERP1_CTRL_LANE0_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits\n  before adding to BASE0, and LANE0 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ SIO_INTERP1_CTRL_LANE0_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive\n  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ SIO_INTERP1_CTRL_LANE0_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ SIO_INTERP1_CTRL_LANE0_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP1_CTRL_LANE1_OFFSET, 0x00f0 
       @ .equ SIO_INTERP1_CTRL_LANE1_FORCE_MSB [20:19]    ORed into bits 29:28 of the lane result presented to the processor on the bus.\n  No effect on the internal 32-bit datapath. Handy for using a lane to generate sequence\n  of pointers into flash or SRAM. 
       @ .equ SIO_INTERP1_CTRL_LANE1_ADD_RAW [18:18]    If 1, mask + shift is bypassed for LANE1 result. This does not affect FULL result. 
       @ .equ SIO_INTERP1_CTRL_LANE1_CROSS_RESULT [17:17]    If 1, feed the opposite lane's result into this lane's accumulator on POP. 
       @ .equ SIO_INTERP1_CTRL_LANE1_CROSS_INPUT [16:16]    If 1, feed the opposite lane's accumulator into this lane's shift + mask hardware.\n  Takes effect even if ADD_RAW is set the CROSS_INPUT mux is before the shift+mask bypass 
       @ .equ SIO_INTERP1_CTRL_LANE1_SIGNED [15:15]    If SIGNED is set, the shifted and masked accumulator value is sign-extended to 32 bits\n  before adding to BASE1, and LANE1 PEEK/POP appear extended to 32 bits when read by processor. 
       @ .equ SIO_INTERP1_CTRL_LANE1_MASK_MSB [14:10]    The most-significant bit allowed to pass by the mask inclusive\n  Setting MSB < LSB may cause chip to turn inside-out 
       @ .equ SIO_INTERP1_CTRL_LANE1_MASK_LSB [9:5]    The least-significant bit allowed to pass by the mask inclusive 
       @ .equ SIO_INTERP1_CTRL_LANE1_SHIFT [4:0]    Logical right-shift applied to accumulator before masking 
 
    .equ SIO_INTERP1_ACCUM0_ADD_OFFSET, 0x00f4 
       @ .equ SIO_INTERP1_ACCUM0_ADD_INTERP1_ACCUM0_ADD [23:0]     
 
    .equ SIO_INTERP1_ACCUM1_ADD_OFFSET, 0x00f8 
       @ .equ SIO_INTERP1_ACCUM1_ADD_INTERP1_ACCUM1_ADD [23:0]     
 
    .equ SIO_INTERP1_BASE_1AND0_OFFSET, 0x00fc 
 
    .equ SIO_SPINLOCK0_OFFSET, 0x0100 
 
    .equ SIO_SPINLOCK1_OFFSET, 0x0104 
 
    .equ SIO_SPINLOCK2_OFFSET, 0x0108 
 
    .equ SIO_SPINLOCK3_OFFSET, 0x010c 
 
    .equ SIO_SPINLOCK4_OFFSET, 0x0110 
 
    .equ SIO_SPINLOCK5_OFFSET, 0x0114 
 
    .equ SIO_SPINLOCK6_OFFSET, 0x0118 
 
    .equ SIO_SPINLOCK7_OFFSET, 0x011c 
 
    .equ SIO_SPINLOCK8_OFFSET, 0x0120 
 
    .equ SIO_SPINLOCK9_OFFSET, 0x0124 
 
    .equ SIO_SPINLOCK10_OFFSET, 0x0128 
 
    .equ SIO_SPINLOCK11_OFFSET, 0x012c 
 
    .equ SIO_SPINLOCK12_OFFSET, 0x0130 
 
    .equ SIO_SPINLOCK13_OFFSET, 0x0134 
 
    .equ SIO_SPINLOCK14_OFFSET, 0x0138 
 
    .equ SIO_SPINLOCK15_OFFSET, 0x013c 
 
    .equ SIO_SPINLOCK16_OFFSET, 0x0140 
 
    .equ SIO_SPINLOCK17_OFFSET, 0x0144 
 
    .equ SIO_SPINLOCK18_OFFSET, 0x0148 
 
    .equ SIO_SPINLOCK19_OFFSET, 0x014c 
 
    .equ SIO_SPINLOCK20_OFFSET, 0x0150 
 
    .equ SIO_SPINLOCK21_OFFSET, 0x0154 
 
    .equ SIO_SPINLOCK22_OFFSET, 0x0158 
 
    .equ SIO_SPINLOCK23_OFFSET, 0x015c 
 
    .equ SIO_SPINLOCK24_OFFSET, 0x0160 
 
    .equ SIO_SPINLOCK25_OFFSET, 0x0164 
 
    .equ SIO_SPINLOCK26_OFFSET, 0x0168 
 
    .equ SIO_SPINLOCK27_OFFSET, 0x016c 
 
    .equ SIO_SPINLOCK28_OFFSET, 0x0170 
 
    .equ SIO_SPINLOCK29_OFFSET, 0x0174 
 
    .equ SIO_SPINLOCK30_OFFSET, 0x0178 
 
    .equ SIO_SPINLOCK31_OFFSET, 0x017c 
 

@=========================== PPB ===========================@
.equ PPB_BASE, 0xe0000000 
    .equ PPB_SYST_CSR_OFFSET, 0xe010 
       @ .equ PPB_SYST_CSR_COUNTFLAG [16:16]    Returns 1 if timer counted to 0 since last time this was read. Clears on read by application or debugger. 
       @ .equ PPB_SYST_CSR_CLKSOURCE [2:2]    SysTick clock source. Always reads as one if SYST_CALIB reports NOREF.\n  Selects the SysTick timer clock source:\n  0 = External reference clock.\n  1 = Processor clock. 
       @ .equ PPB_SYST_CSR_TICKINT [1:1]    Enables SysTick exception request:\n  0 = Counting down to zero does not assert the SysTick exception request.\n  1 = Counting down to zero to asserts the SysTick exception request. 
       @ .equ PPB_SYST_CSR_ENABLE [0:0]    Enable SysTick counter:\n  0 = Counter disabled.\n  1 = Counter enabled. 
 
    .equ PPB_SYST_RVR_OFFSET, 0xe014 
       @ .equ PPB_SYST_RVR_RELOAD [23:0]    Value to load into the SysTick Current Value Register when the counter reaches 0. 
 
    .equ PPB_SYST_CVR_OFFSET, 0xe018 
       @ .equ PPB_SYST_CVR_CURRENT [23:0]    Reads return the current value of the SysTick counter. This register is write-clear. Writing to it with any value clears the register to 0. Clearing this register also clears the COUNTFLAG bit of the SysTick Control and Status Register. 
 
    .equ PPB_SYST_CALIB_OFFSET, 0xe01c 
       @ .equ PPB_SYST_CALIB_NOREF [31:31]    If reads as 1, the Reference clock is not provided - the CLKSOURCE bit of the SysTick Control and Status register will be forced to 1 and cannot be cleared to 0. 
       @ .equ PPB_SYST_CALIB_SKEW [30:30]    If reads as 1, the calibration value for 10ms is inexact due to clock frequency. 
       @ .equ PPB_SYST_CALIB_TENMS [23:0]    An optional Reload value to be used for 10ms 100Hz timing, subject to system clock skew errors. If the value reads as 0, the calibration value is not known. 
 
    .equ PPB_NVIC_ISER_OFFSET, 0xe100 
       @ .equ PPB_NVIC_ISER_SETENA [31:0]    Interrupt set-enable bits.\n  Write:\n  0 = No effect.\n  1 = Enable interrupt.\n  Read:\n  0 = Interrupt disabled.\n  1 = Interrupt enabled. 
 
    .equ PPB_NVIC_ICER_OFFSET, 0xe180 
       @ .equ PPB_NVIC_ICER_CLRENA [31:0]    Interrupt clear-enable bits.\n  Write:\n  0 = No effect.\n  1 = Disable interrupt.\n  Read:\n  0 = Interrupt disabled.\n  1 = Interrupt enabled. 
 
    .equ PPB_NVIC_ISPR_OFFSET, 0xe200 
       @ .equ PPB_NVIC_ISPR_SETPEND [31:0]    Interrupt set-pending bits.\n  Write:\n  0 = No effect.\n  1 = Changes interrupt state to pending.\n  Read:\n  0 = Interrupt is not pending.\n  1 = Interrupt is pending.\n  Note: Writing 1 to the NVIC_ISPR bit corresponding to:\n  An interrupt that is pending has no effect.\n  A disabled interrupt sets the state of that interrupt to pending. 
 
    .equ PPB_NVIC_ICPR_OFFSET, 0xe280 
       @ .equ PPB_NVIC_ICPR_CLRPEND [31:0]    Interrupt clear-pending bits.\n  Write:\n  0 = No effect.\n  1 = Removes pending state and interrupt.\n  Read:\n  0 = Interrupt is not pending.\n  1 = Interrupt is pending. 
 
    .equ PPB_NVIC_IPR0_OFFSET, 0xe400 
       @ .equ PPB_NVIC_IPR0_IP_3 [31:30]    Priority of interrupt 3 
       @ .equ PPB_NVIC_IPR0_IP_2 [23:22]    Priority of interrupt 2 
       @ .equ PPB_NVIC_IPR0_IP_1 [15:14]    Priority of interrupt 1 
       @ .equ PPB_NVIC_IPR0_IP_0 [7:6]    Priority of interrupt 0 
 
    .equ PPB_NVIC_IPR1_OFFSET, 0xe404 
       @ .equ PPB_NVIC_IPR1_IP_7 [31:30]    Priority of interrupt 7 
       @ .equ PPB_NVIC_IPR1_IP_6 [23:22]    Priority of interrupt 6 
       @ .equ PPB_NVIC_IPR1_IP_5 [15:14]    Priority of interrupt 5 
       @ .equ PPB_NVIC_IPR1_IP_4 [7:6]    Priority of interrupt 4 
 
    .equ PPB_NVIC_IPR2_OFFSET, 0xe408 
       @ .equ PPB_NVIC_IPR2_IP_11 [31:30]    Priority of interrupt 11 
       @ .equ PPB_NVIC_IPR2_IP_10 [23:22]    Priority of interrupt 10 
       @ .equ PPB_NVIC_IPR2_IP_9 [15:14]    Priority of interrupt 9 
       @ .equ PPB_NVIC_IPR2_IP_8 [7:6]    Priority of interrupt 8 
 
    .equ PPB_NVIC_IPR3_OFFSET, 0xe40c 
       @ .equ PPB_NVIC_IPR3_IP_15 [31:30]    Priority of interrupt 15 
       @ .equ PPB_NVIC_IPR3_IP_14 [23:22]    Priority of interrupt 14 
       @ .equ PPB_NVIC_IPR3_IP_13 [15:14]    Priority of interrupt 13 
       @ .equ PPB_NVIC_IPR3_IP_12 [7:6]    Priority of interrupt 12 
 
    .equ PPB_NVIC_IPR4_OFFSET, 0xe410 
       @ .equ PPB_NVIC_IPR4_IP_19 [31:30]    Priority of interrupt 19 
       @ .equ PPB_NVIC_IPR4_IP_18 [23:22]    Priority of interrupt 18 
       @ .equ PPB_NVIC_IPR4_IP_17 [15:14]    Priority of interrupt 17 
       @ .equ PPB_NVIC_IPR4_IP_16 [7:6]    Priority of interrupt 16 
 
    .equ PPB_NVIC_IPR5_OFFSET, 0xe414 
       @ .equ PPB_NVIC_IPR5_IP_23 [31:30]    Priority of interrupt 23 
       @ .equ PPB_NVIC_IPR5_IP_22 [23:22]    Priority of interrupt 22 
       @ .equ PPB_NVIC_IPR5_IP_21 [15:14]    Priority of interrupt 21 
       @ .equ PPB_NVIC_IPR5_IP_20 [7:6]    Priority of interrupt 20 
 
    .equ PPB_NVIC_IPR6_OFFSET, 0xe418 
       @ .equ PPB_NVIC_IPR6_IP_27 [31:30]    Priority of interrupt 27 
       @ .equ PPB_NVIC_IPR6_IP_26 [23:22]    Priority of interrupt 26 
       @ .equ PPB_NVIC_IPR6_IP_25 [15:14]    Priority of interrupt 25 
       @ .equ PPB_NVIC_IPR6_IP_24 [7:6]    Priority of interrupt 24 
 
    .equ PPB_NVIC_IPR7_OFFSET, 0xe41c 
       @ .equ PPB_NVIC_IPR7_IP_31 [31:30]    Priority of interrupt 31 
       @ .equ PPB_NVIC_IPR7_IP_30 [23:22]    Priority of interrupt 30 
       @ .equ PPB_NVIC_IPR7_IP_29 [15:14]    Priority of interrupt 29 
       @ .equ PPB_NVIC_IPR7_IP_28 [7:6]    Priority of interrupt 28 
 
    .equ PPB_CPUID_OFFSET, 0xed00 
       @ .equ PPB_CPUID_IMPLEMENTER [31:24]    Implementor code: 0x41 = ARM 
       @ .equ PPB_CPUID_VARIANT [23:20]    Major revision number n in the rnpm revision status:\n  0x0 = Revision 0. 
       @ .equ PPB_CPUID_ARCHITECTURE [19:16]    Constant that defines the architecture of the processor:\n  0xC = ARMv6-M architecture. 
       @ .equ PPB_CPUID_PARTNO [15:4]    Number of processor within family: 0xC60 = Cortex-M0+ 
       @ .equ PPB_CPUID_REVISION [3:0]    Minor revision number m in the rnpm revision status:\n  0x1 = Patch 1. 
 
    .equ PPB_ICSR_OFFSET, 0xed04 
       @ .equ PPB_ICSR_NMIPENDSET [31:31]    Setting this bit will activate an NMI. Since NMI is the highest priority exception, it will activate as soon as it is registered.\n  NMI set-pending bit.\n  Write:\n  0 = No effect.\n  1 = Changes NMI exception state to pending.\n  Read:\n  0 = NMI exception is not pending.\n  1 = NMI exception is pending.\n  Because NMI is the highest-priority exception, normally the processor enters the NMI\n  exception handler as soon as it detects a write of 1 to this bit. Entering the handler then clears\n  this bit to 0. This means a read of this bit by the NMI exception handler returns 1 only if the\n  NMI signal is reasserted while the processor is executing that handler. 
       @ .equ PPB_ICSR_PENDSVSET [28:28]    PendSV set-pending bit.\n  Write:\n  0 = No effect.\n  1 = Changes PendSV exception state to pending.\n  Read:\n  0 = PendSV exception is not pending.\n  1 = PendSV exception is pending.\n  Writing 1 to this bit is the only way to set the PendSV exception state to pending. 
       @ .equ PPB_ICSR_PENDSVCLR [27:27]    PendSV clear-pending bit.\n  Write:\n  0 = No effect.\n  1 = Removes the pending state from the PendSV exception. 
       @ .equ PPB_ICSR_PENDSTSET [26:26]    SysTick exception set-pending bit.\n  Write:\n  0 = No effect.\n  1 = Changes SysTick exception state to pending.\n  Read:\n  0 = SysTick exception is not pending.\n  1 = SysTick exception is pending. 
       @ .equ PPB_ICSR_PENDSTCLR [25:25]    SysTick exception clear-pending bit.\n  Write:\n  0 = No effect.\n  1 = Removes the pending state from the SysTick exception.\n  This bit is WO. On a register read its value is Unknown. 
       @ .equ PPB_ICSR_ISRPREEMPT [23:23]    The system can only access this bit when the core is halted. It indicates that a pending interrupt is to be taken in the next running cycle. If C_MASKINTS is clear in the Debug Halting Control and Status Register, the interrupt is serviced. 
       @ .equ PPB_ICSR_ISRPENDING [22:22]    External interrupt pending flag 
       @ .equ PPB_ICSR_VECTPENDING [20:12]    Indicates the exception number for the highest priority pending exception: 0 = no pending exceptions. Non zero = The pending state includes the effect of memory-mapped enable and mask registers. It does not include the PRIMASK special-purpose register qualifier. 
       @ .equ PPB_ICSR_VECTACTIVE [8:0]    Active exception number field. Reset clears the VECTACTIVE field. 
 
    .equ PPB_VTOR_OFFSET, 0xed08 
       @ .equ PPB_VTOR_TBLOFF [31:8]    Bits [31:8] of the indicate the vector table offset address. 
 
    .equ PPB_AIRCR_OFFSET, 0xed0c 
       @ .equ PPB_AIRCR_VECTKEY [31:16]    Register key:\n  Reads as Unknown\n  On writes, write 0x05FA to VECTKEY, otherwise the write is ignored. 
       @ .equ PPB_AIRCR_ENDIANESS [15:15]    Data endianness implemented:\n  0 = Little-endian. 
       @ .equ PPB_AIRCR_SYSRESETREQ [2:2]    Writing 1 to this bit causes the SYSRESETREQ signal to the outer system to be asserted to request a reset. The intention is to force a large system reset of all major components except for debug. The C_HALT bit in the DHCSR is cleared as a result of the system reset requested. The debugger does not lose contact with the device. 
       @ .equ PPB_AIRCR_VECTCLRACTIVE [1:1]    Clears all active state information for fixed and configurable exceptions. This bit: is self-clearing, can only be set by the DAP when the core is halted. When set: clears all active exception status of the processor, forces a return to Thread mode, forces an IPSR of 0. A debugger must re-initialize the stack. 
 
    .equ PPB_SCR_OFFSET, 0xed10 
       @ .equ PPB_SCR_SEVONPEND [4:4]    Send Event on Pending bit:\n  0 = Only enabled interrupts or events can wakeup the processor, disabled interrupts are excluded.\n  1 = Enabled events and all interrupts, including disabled interrupts, can wakeup the processor.\n  When an event or interrupt becomes pending, the event signal wakes up the processor from WFE. If the\n  processor is not waiting for an event, the event is registered and affects the next WFE.\n  The processor also wakes up on execution of an SEV instruction or an external event. 
       @ .equ PPB_SCR_SLEEPDEEP [2:2]    Controls whether the processor uses sleep or deep sleep as its low power mode:\n  0 = Sleep.\n  1 = Deep sleep. 
       @ .equ PPB_SCR_SLEEPONEXIT [1:1]    Indicates sleep-on-exit when returning from Handler mode to Thread mode:\n  0 = Do not sleep when returning to Thread mode.\n  1 = Enter sleep, or deep sleep, on return from an ISR to Thread mode.\n  Setting this bit to 1 enables an interrupt driven application to avoid returning to an empty main application. 
 
    .equ PPB_CCR_OFFSET, 0xed14 
       @ .equ PPB_CCR_STKALIGN [9:9]    Always reads as one, indicates 8-byte stack alignment on exception entry. On exception entry, the processor uses bit[9] of the stacked PSR to indicate the stack alignment. On return from the exception it uses this stacked bit to restore the correct stack alignment. 
       @ .equ PPB_CCR_UNALIGN_TRP [3:3]    Always reads as one, indicates that all unaligned accesses generate a HardFault. 
 
    .equ PPB_SHPR2_OFFSET, 0xed1c 
       @ .equ PPB_SHPR2_PRI_11 [31:30]    Priority of system handler 11, SVCall 
 
    .equ PPB_SHPR3_OFFSET, 0xed20 
       @ .equ PPB_SHPR3_PRI_15 [31:30]    Priority of system handler 15, SysTick 
       @ .equ PPB_SHPR3_PRI_14 [23:22]    Priority of system handler 14, PendSV 
 
    .equ PPB_SHCSR_OFFSET, 0xed24 
       @ .equ PPB_SHCSR_SVCALLPENDED [15:15]    Reads as 1 if SVCall is Pending. Write 1 to set pending SVCall, write 0 to clear pending SVCall. 
 
    .equ PPB_MPU_TYPE_OFFSET, 0xed90 
       @ .equ PPB_MPU_TYPE_IREGION [23:16]    Instruction region. Reads as zero as ARMv6-M only supports a unified MPU. 
       @ .equ PPB_MPU_TYPE_DREGION [15:8]    Number of regions supported by the MPU. 
       @ .equ PPB_MPU_TYPE_SEPARATE [0:0]    Indicates support for separate instruction and data address maps. Reads as 0 as ARMv6-M only supports a unified MPU. 
 
    .equ PPB_MPU_CTRL_OFFSET, 0xed94 
       @ .equ PPB_MPU_CTRL_PRIVDEFENA [2:2]    Controls whether the default memory map is enabled as a background region for privileged accesses. This bit is ignored when ENABLE is clear.\n  0 = If the MPU is enabled, disables use of the default memory map. Any memory access to a location not\n  covered by any enabled region causes a fault.\n  1 = If the MPU is enabled, enables use of the default memory map as a background region for privileged software accesses.\n  When enabled, the background region acts as if it is region number -1. Any region that is defined and enabled has priority over this default map. 
       @ .equ PPB_MPU_CTRL_HFNMIENA [1:1]    Controls the use of the MPU for HardFaults and NMIs. Setting this bit when ENABLE is clear results in UNPREDICTABLE behaviour.\n  When the MPU is enabled:\n  0 = MPU is disabled during HardFault and NMI handlers, regardless of the value of the ENABLE bit.\n  1 = the MPU is enabled during HardFault and NMI handlers. 
       @ .equ PPB_MPU_CTRL_ENABLE [0:0]    Enables the MPU. If the MPU is disabled, privileged and unprivileged accesses use the default memory map.\n  0 = MPU disabled.\n  1 = MPU enabled. 
 
    .equ PPB_MPU_RNR_OFFSET, 0xed98 
       @ .equ PPB_MPU_RNR_REGION [3:0]    Indicates the MPU region referenced by the MPU_RBAR and MPU_RASR registers.\n  The MPU supports 8 memory regions, so the permitted values of this field are 0-7. 
 
    .equ PPB_MPU_RBAR_OFFSET, 0xed9c 
       @ .equ PPB_MPU_RBAR_ADDR [31:8]    Base address of the region. 
       @ .equ PPB_MPU_RBAR_VALID [4:4]    On writes, indicates whether the write must update the base address of the region identified by the REGION field, updating the MPU_RNR to indicate this new region.\n  Write:\n  0 = MPU_RNR not changed, and the processor:\n  Updates the base address for the region specified in the MPU_RNR.\n  Ignores the value of the REGION field.\n  1 = The processor:\n  Updates the value of the MPU_RNR to the value of the REGION field.\n  Updates the base address for the region specified in the REGION field.\n  Always reads as zero. 
       @ .equ PPB_MPU_RBAR_REGION [3:0]    On writes, specifies the number of the region whose base address to update provided VALID is set written as 1. On reads, returns bits [3:0] of MPU_RNR. 
 
    .equ PPB_MPU_RASR_OFFSET, 0xeda0 
       @ .equ PPB_MPU_RASR_ATTRS [31:16]    The MPU Region Attribute field. Use to define the region attribute control.\n  28 = XN: Instruction access disable bit:\n  0 = Instruction fetches enabled.\n  1 = Instruction fetches disabled.\n  26:24 = AP: Access permission field\n  18 = S: Shareable bit\n  17 = C: Cacheable bit\n  16 = B: Bufferable bit 
       @ .equ PPB_MPU_RASR_SRD [15:8]    Subregion Disable. For regions of 256 bytes or larger, each bit of this field controls whether one of the eight equal subregions is enabled. 
       @ .equ PPB_MPU_RASR_SIZE [5:1]    Indicates the region size. Region size in bytes = 2^SIZE+1. The minimum permitted value is 7 b00111 = 256Bytes 
       @ .equ PPB_MPU_RASR_ENABLE [0:0]    Enables the region. 
 
