@ arm-none-eabi-as equates file for RP2040
@ Equates Generator, Copyright Terry Porter 2017 "terry@tjporter.com.au" for RP2040 
@ Takes a CMSIS-SVD file plus a hand edited config.xml file as input 
@ MIT Licensed 


@=========================== XIP_CTRL ===========================@
.equ XIP_CTRL_BASE, 0x14000000 
    .equ XIP_CTRL_CTRL_OFFSET, 0x0000 
       @ .equ XIP_CTRL_CTRL_POWER_DOWN [3:3]     
       @ .equ XIP_CTRL_CTRL_ERR_BADWRITE [1:1]     
       @ .equ XIP_CTRL_CTRL_EN [0:0]     
 
    .equ XIP_CTRL_FLUSH_OFFSET, 0x0004 
       @ .equ XIP_CTRL_FLUSH_FLUSH [0:0]     
 
    .equ XIP_CTRL_STAT_OFFSET, 0x0008 
       @ .equ XIP_CTRL_STAT_FIFO_FULL [2:2]     
       @ .equ XIP_CTRL_STAT_FIFO_EMPTY [1:1]     
       @ .equ XIP_CTRL_STAT_FLUSH_READY [0:0]     
 
    .equ XIP_CTRL_CTR_HIT_OFFSET, 0x000c 
 
    .equ XIP_CTRL_CTR_ACC_OFFSET, 0x0010 
 
    .equ XIP_CTRL_STREAM_ADDR_OFFSET, 0x0014 
       @ .equ XIP_CTRL_STREAM_ADDR_STREAM_ADDR [31:2]     
 
    .equ XIP_CTRL_STREAM_CTR_OFFSET, 0x0018 
       @ .equ XIP_CTRL_STREAM_CTR_STREAM_CTR [21:0]     
 
    .equ XIP_CTRL_STREAM_FIFO_OFFSET, 0x001c 
 

@=========================== XIP_SSI ===========================@
.equ XIP_SSI_BASE, 0x18000000 
    .equ XIP_SSI_CTRLR0_OFFSET, 0x0000 
       @ .equ XIP_SSI_CTRLR0_SSTE [24:24]     
       @ .equ XIP_SSI_CTRLR0_SPI_FRF [22:21]     
       @ .equ XIP_SSI_CTRLR0_DFS_32 [20:16]     
       @ .equ XIP_SSI_CTRLR0_CFS [15:12]     
       @ .equ XIP_SSI_CTRLR0_SRL [11:11]     
       @ .equ XIP_SSI_CTRLR0_SLV_OE [10:10]     
       @ .equ XIP_SSI_CTRLR0_TMOD [9:8]     
       @ .equ XIP_SSI_CTRLR0_SCPOL [7:7]     
       @ .equ XIP_SSI_CTRLR0_SCPH [6:6]     
       @ .equ XIP_SSI_CTRLR0_FRF [5:4]     
       @ .equ XIP_SSI_CTRLR0_DFS [3:0]     
 
    .equ XIP_SSI_CTRLR1_OFFSET, 0x0004 
       @ .equ XIP_SSI_CTRLR1_NDF [15:0]     
 
    .equ XIP_SSI_SSIENR_OFFSET, 0x0008 
       @ .equ XIP_SSI_SSIENR_SSI_EN [0:0]     
 
    .equ XIP_SSI_MWCR_OFFSET, 0x000c 
       @ .equ XIP_SSI_MWCR_MHS [2:2]     
       @ .equ XIP_SSI_MWCR_MDD [1:1]     
       @ .equ XIP_SSI_MWCR_MWMOD [0:0]     
 
    .equ XIP_SSI_SER_OFFSET, 0x0010 
       @ .equ XIP_SSI_SER_SER [0:0]     
 
    .equ XIP_SSI_BAUDR_OFFSET, 0x0014 
       @ .equ XIP_SSI_BAUDR_SCKDV [15:0]     
 
    .equ XIP_SSI_TXFTLR_OFFSET, 0x0018 
       @ .equ XIP_SSI_TXFTLR_TFT [7:0]     
 
    .equ XIP_SSI_RXFTLR_OFFSET, 0x001c 
       @ .equ XIP_SSI_RXFTLR_RFT [7:0]     
 
    .equ XIP_SSI_TXFLR_OFFSET, 0x0020 
       @ .equ XIP_SSI_TXFLR_TFTFL [7:0]     
 
    .equ XIP_SSI_RXFLR_OFFSET, 0x0024 
       @ .equ XIP_SSI_RXFLR_RXTFL [7:0]     
 
    .equ XIP_SSI_SR_OFFSET, 0x0028 
       @ .equ XIP_SSI_SR_DCOL [6:6]     
       @ .equ XIP_SSI_SR_TXE [5:5]     
       @ .equ XIP_SSI_SR_RFF [4:4]     
       @ .equ XIP_SSI_SR_RFNE [3:3]     
       @ .equ XIP_SSI_SR_TFE [2:2]     
       @ .equ XIP_SSI_SR_TFNF [1:1]     
       @ .equ XIP_SSI_SR_BUSY [0:0]     
 
    .equ XIP_SSI_IMR_OFFSET, 0x002c 
       @ .equ XIP_SSI_IMR_MSTIM [5:5]     
       @ .equ XIP_SSI_IMR_RXFIM [4:4]     
       @ .equ XIP_SSI_IMR_RXOIM [3:3]     
       @ .equ XIP_SSI_IMR_RXUIM [2:2]     
       @ .equ XIP_SSI_IMR_TXOIM [1:1]     
       @ .equ XIP_SSI_IMR_TXEIM [0:0]     
 
    .equ XIP_SSI_ISR_OFFSET, 0x0030 
       @ .equ XIP_SSI_ISR_MSTIS [5:5]     
       @ .equ XIP_SSI_ISR_RXFIS [4:4]     
       @ .equ XIP_SSI_ISR_RXOIS [3:3]     
       @ .equ XIP_SSI_ISR_RXUIS [2:2]     
       @ .equ XIP_SSI_ISR_TXOIS [1:1]     
       @ .equ XIP_SSI_ISR_TXEIS [0:0]     
 
    .equ XIP_SSI_RISR_OFFSET, 0x0034 
       @ .equ XIP_SSI_RISR_MSTIR [5:5]     
       @ .equ XIP_SSI_RISR_RXFIR [4:4]     
       @ .equ XIP_SSI_RISR_RXOIR [3:3]     
       @ .equ XIP_SSI_RISR_RXUIR [2:2]     
       @ .equ XIP_SSI_RISR_TXOIR [1:1]     
       @ .equ XIP_SSI_RISR_TXEIR [0:0]     
 
    .equ XIP_SSI_TXOICR_OFFSET, 0x0038 
       @ .equ XIP_SSI_TXOICR_TXOICR [0:0]     
 
    .equ XIP_SSI_RXOICR_OFFSET, 0x003c 
       @ .equ XIP_SSI_RXOICR_RXOICR [0:0]     
 
    .equ XIP_SSI_RXUICR_OFFSET, 0x0040 
       @ .equ XIP_SSI_RXUICR_RXUICR [0:0]     
 
    .equ XIP_SSI_MSTICR_OFFSET, 0x0044 
       @ .equ XIP_SSI_MSTICR_MSTICR [0:0]     
 
    .equ XIP_SSI_ICR_OFFSET, 0x0048 
       @ .equ XIP_SSI_ICR_ICR [0:0]     
 
    .equ XIP_SSI_DMACR_OFFSET, 0x004c 
       @ .equ XIP_SSI_DMACR_TDMAE [1:1]     
       @ .equ XIP_SSI_DMACR_RDMAE [0:0]     
 
    .equ XIP_SSI_DMATDLR_OFFSET, 0x0050 
       @ .equ XIP_SSI_DMATDLR_DMATDL [7:0]     
 
    .equ XIP_SSI_DMARDLR_OFFSET, 0x0054 
       @ .equ XIP_SSI_DMARDLR_DMARDL [7:0]     
 
    .equ XIP_SSI_IDR_OFFSET, 0x0058 
       @ .equ XIP_SSI_IDR_IDCODE [31:0]     
 
    .equ XIP_SSI_SSI_VERSION_ID_OFFSET, 0x005c 
       @ .equ XIP_SSI_SSI_VERSION_ID_SSI_COMP_VERSION [31:0]     
 
    .equ XIP_SSI_DR0_OFFSET, 0x0060 
       @ .equ XIP_SSI_DR0_DR [31:0]     
 
    .equ XIP_SSI_RX_SAMPLE_DLY_OFFSET, 0x00f0 
       @ .equ XIP_SSI_RX_SAMPLE_DLY_RSD [7:0]     
 
    .equ XIP_SSI_SPI_CTRLR0_OFFSET, 0x00f4 
       @ .equ XIP_SSI_SPI_CTRLR0_XIP_CMD [31:24]     
       @ .equ XIP_SSI_SPI_CTRLR0_SPI_RXDS_EN [18:18]     
       @ .equ XIP_SSI_SPI_CTRLR0_INST_DDR_EN [17:17]     
       @ .equ XIP_SSI_SPI_CTRLR0_SPI_DDR_EN [16:16]     
       @ .equ XIP_SSI_SPI_CTRLR0_WAIT_CYCLES [15:11]     
       @ .equ XIP_SSI_SPI_CTRLR0_INST_L [9:8]     
       @ .equ XIP_SSI_SPI_CTRLR0_ADDR_L [5:2]     
       @ .equ XIP_SSI_SPI_CTRLR0_TRANS_TYPE [1:0]     
 
    .equ XIP_SSI_TXD_DRIVE_EDGE_OFFSET, 0x00f8 
       @ .equ XIP_SSI_TXD_DRIVE_EDGE_TDE [7:0]     
 

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
       @ .equ SYSCFG_PROC_CONFIG_PROC1_DAP_INSTID [31:28]     
       @ .equ SYSCFG_PROC_CONFIG_PROC0_DAP_INSTID [27:24]     
       @ .equ SYSCFG_PROC_CONFIG_PROC1_HALTED [1:1]     
       @ .equ SYSCFG_PROC_CONFIG_PROC0_HALTED [0:0]     
 
    .equ SYSCFG_PROC_IN_SYNC_BYPASS_OFFSET, 0x000c 
       @ .equ SYSCFG_PROC_IN_SYNC_BYPASS_PROC_IN_SYNC_BYPASS [29:0]     
 
    .equ SYSCFG_PROC_IN_SYNC_BYPASS_HI_OFFSET, 0x0010 
       @ .equ SYSCFG_PROC_IN_SYNC_BYPASS_HI_PROC_IN_SYNC_BYPASS_HI [5:0]     
 
    .equ SYSCFG_DBGFORCE_OFFSET, 0x0014 
       @ .equ SYSCFG_DBGFORCE_PROC1_ATTACH [7:7]     
       @ .equ SYSCFG_DBGFORCE_PROC1_SWCLK [6:6]     
       @ .equ SYSCFG_DBGFORCE_PROC1_SWDI [5:5]     
       @ .equ SYSCFG_DBGFORCE_PROC1_SWDO [4:4]     
       @ .equ SYSCFG_DBGFORCE_PROC0_ATTACH [3:3]     
       @ .equ SYSCFG_DBGFORCE_PROC0_SWCLK [2:2]     
       @ .equ SYSCFG_DBGFORCE_PROC0_SWDI [1:1]     
       @ .equ SYSCFG_DBGFORCE_PROC0_SWDO [0:0]     
 
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
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_DC50 [12:12]     
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_GPOUT0_CTRL_AUXSRC [8:5]     
 
    .equ CLOCKS_CLK_GPOUT0_DIV_OFFSET, 0x0004 
       @ .equ CLOCKS_CLK_GPOUT0_DIV_INT [31:8]     
       @ .equ CLOCKS_CLK_GPOUT0_DIV_FRAC [7:0]     
 
    .equ CLOCKS_CLK_GPOUT0_SELECTED_OFFSET, 0x0008 
 
    .equ CLOCKS_CLK_GPOUT1_CTRL_OFFSET, 0x000c 
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_DC50 [12:12]     
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_GPOUT1_CTRL_AUXSRC [8:5]     
 
    .equ CLOCKS_CLK_GPOUT1_DIV_OFFSET, 0x0010 
       @ .equ CLOCKS_CLK_GPOUT1_DIV_INT [31:8]     
       @ .equ CLOCKS_CLK_GPOUT1_DIV_FRAC [7:0]     
 
    .equ CLOCKS_CLK_GPOUT1_SELECTED_OFFSET, 0x0014 
 
    .equ CLOCKS_CLK_GPOUT2_CTRL_OFFSET, 0x0018 
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_DC50 [12:12]     
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_GPOUT2_CTRL_AUXSRC [8:5]     
 
    .equ CLOCKS_CLK_GPOUT2_DIV_OFFSET, 0x001c 
       @ .equ CLOCKS_CLK_GPOUT2_DIV_INT [31:8]     
       @ .equ CLOCKS_CLK_GPOUT2_DIV_FRAC [7:0]     
 
    .equ CLOCKS_CLK_GPOUT2_SELECTED_OFFSET, 0x0020 
 
    .equ CLOCKS_CLK_GPOUT3_CTRL_OFFSET, 0x0024 
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_DC50 [12:12]     
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_GPOUT3_CTRL_AUXSRC [8:5]     
 
    .equ CLOCKS_CLK_GPOUT3_DIV_OFFSET, 0x0028 
       @ .equ CLOCKS_CLK_GPOUT3_DIV_INT [31:8]     
       @ .equ CLOCKS_CLK_GPOUT3_DIV_FRAC [7:0]     
 
    .equ CLOCKS_CLK_GPOUT3_SELECTED_OFFSET, 0x002c 
 
    .equ CLOCKS_CLK_REF_CTRL_OFFSET, 0x0030 
       @ .equ CLOCKS_CLK_REF_CTRL_AUXSRC [6:5]     
       @ .equ CLOCKS_CLK_REF_CTRL_SRC [1:0]     
 
    .equ CLOCKS_CLK_REF_DIV_OFFSET, 0x0034 
       @ .equ CLOCKS_CLK_REF_DIV_INT [9:8]     
 
    .equ CLOCKS_CLK_REF_SELECTED_OFFSET, 0x0038 
 
    .equ CLOCKS_CLK_SYS_CTRL_OFFSET, 0x003c 
       @ .equ CLOCKS_CLK_SYS_CTRL_AUXSRC [7:5]     
       @ .equ CLOCKS_CLK_SYS_CTRL_SRC [0:0]     
 
    .equ CLOCKS_CLK_SYS_DIV_OFFSET, 0x0040 
       @ .equ CLOCKS_CLK_SYS_DIV_INT [31:8]     
       @ .equ CLOCKS_CLK_SYS_DIV_FRAC [7:0]     
 
    .equ CLOCKS_CLK_SYS_SELECTED_OFFSET, 0x0044 
 
    .equ CLOCKS_CLK_PERI_CTRL_OFFSET, 0x0048 
       @ .equ CLOCKS_CLK_PERI_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_PERI_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_PERI_CTRL_AUXSRC [7:5]     
 
    .equ CLOCKS_CLK_PERI_SELECTED_OFFSET, 0x0050 
 
    .equ CLOCKS_CLK_USB_CTRL_OFFSET, 0x0054 
       @ .equ CLOCKS_CLK_USB_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_USB_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_USB_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_USB_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_USB_CTRL_AUXSRC [7:5]     
 
    .equ CLOCKS_CLK_USB_DIV_OFFSET, 0x0058 
       @ .equ CLOCKS_CLK_USB_DIV_INT [9:8]     
 
    .equ CLOCKS_CLK_USB_SELECTED_OFFSET, 0x005c 
 
    .equ CLOCKS_CLK_ADC_CTRL_OFFSET, 0x0060 
       @ .equ CLOCKS_CLK_ADC_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_ADC_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_ADC_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_ADC_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_ADC_CTRL_AUXSRC [7:5]     
 
    .equ CLOCKS_CLK_ADC_DIV_OFFSET, 0x0064 
       @ .equ CLOCKS_CLK_ADC_DIV_INT [9:8]     
 
    .equ CLOCKS_CLK_ADC_SELECTED_OFFSET, 0x0068 
 
    .equ CLOCKS_CLK_RTC_CTRL_OFFSET, 0x006c 
       @ .equ CLOCKS_CLK_RTC_CTRL_NUDGE [20:20]     
       @ .equ CLOCKS_CLK_RTC_CTRL_PHASE [17:16]     
       @ .equ CLOCKS_CLK_RTC_CTRL_ENABLE [11:11]     
       @ .equ CLOCKS_CLK_RTC_CTRL_KILL [10:10]     
       @ .equ CLOCKS_CLK_RTC_CTRL_AUXSRC [7:5]     
 
    .equ CLOCKS_CLK_RTC_DIV_OFFSET, 0x0070 
       @ .equ CLOCKS_CLK_RTC_DIV_INT [31:8]     
       @ .equ CLOCKS_CLK_RTC_DIV_FRAC [7:0]     
 
    .equ CLOCKS_CLK_RTC_SELECTED_OFFSET, 0x0074 
 
    .equ CLOCKS_CLK_SYS_RESUS_CTRL_OFFSET, 0x0078 
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_CLEAR [16:16]     
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_FRCE [12:12]     
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_ENABLE [8:8]     
       @ .equ CLOCKS_CLK_SYS_RESUS_CTRL_TIMEOUT [7:0]     
 
    .equ CLOCKS_CLK_SYS_RESUS_STATUS_OFFSET, 0x007c 
       @ .equ CLOCKS_CLK_SYS_RESUS_STATUS_RESUSSED [0:0]     
 
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
       @ .equ CLOCKS_FC0_STATUS_DIED [28:28]     
       @ .equ CLOCKS_FC0_STATUS_FAST [24:24]     
       @ .equ CLOCKS_FC0_STATUS_SLOW [20:20]     
       @ .equ CLOCKS_FC0_STATUS_FAIL [16:16]     
       @ .equ CLOCKS_FC0_STATUS_WAITING [12:12]     
       @ .equ CLOCKS_FC0_STATUS_RUNNING [8:8]     
       @ .equ CLOCKS_FC0_STATUS_DONE [4:4]     
       @ .equ CLOCKS_FC0_STATUS_PASS [0:0]     
 
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
       @ .equ IO_BANK0_GPIO0_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO0_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO0_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO0_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO0_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO0_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO0_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO0_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO0_CTRL_OFFSET, 0x0004 
       @ .equ IO_BANK0_GPIO0_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO0_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO0_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO0_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO0_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO1_STATUS_OFFSET, 0x0008 
       @ .equ IO_BANK0_GPIO1_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO1_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO1_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO1_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO1_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO1_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO1_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO1_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO1_CTRL_OFFSET, 0x000c 
       @ .equ IO_BANK0_GPIO1_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO1_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO1_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO1_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO1_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO2_STATUS_OFFSET, 0x0010 
       @ .equ IO_BANK0_GPIO2_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO2_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO2_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO2_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO2_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO2_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO2_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO2_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO2_CTRL_OFFSET, 0x0014 
       @ .equ IO_BANK0_GPIO2_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO2_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO2_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO2_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO2_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO3_STATUS_OFFSET, 0x0018 
       @ .equ IO_BANK0_GPIO3_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO3_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO3_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO3_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO3_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO3_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO3_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO3_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO3_CTRL_OFFSET, 0x001c 
       @ .equ IO_BANK0_GPIO3_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO3_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO3_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO3_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO3_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO4_STATUS_OFFSET, 0x0020 
       @ .equ IO_BANK0_GPIO4_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO4_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO4_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO4_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO4_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO4_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO4_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO4_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO4_CTRL_OFFSET, 0x0024 
       @ .equ IO_BANK0_GPIO4_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO4_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO4_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO4_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO4_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO5_STATUS_OFFSET, 0x0028 
       @ .equ IO_BANK0_GPIO5_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO5_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO5_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO5_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO5_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO5_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO5_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO5_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO5_CTRL_OFFSET, 0x002c 
       @ .equ IO_BANK0_GPIO5_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO5_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO5_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO5_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO5_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO6_STATUS_OFFSET, 0x0030 
       @ .equ IO_BANK0_GPIO6_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO6_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO6_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO6_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO6_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO6_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO6_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO6_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO6_CTRL_OFFSET, 0x0034 
       @ .equ IO_BANK0_GPIO6_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO6_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO6_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO6_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO6_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO7_STATUS_OFFSET, 0x0038 
       @ .equ IO_BANK0_GPIO7_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO7_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO7_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO7_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO7_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO7_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO7_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO7_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO7_CTRL_OFFSET, 0x003c 
       @ .equ IO_BANK0_GPIO7_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO7_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO7_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO7_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO7_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO8_STATUS_OFFSET, 0x0040 
       @ .equ IO_BANK0_GPIO8_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO8_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO8_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO8_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO8_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO8_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO8_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO8_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO8_CTRL_OFFSET, 0x0044 
       @ .equ IO_BANK0_GPIO8_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO8_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO8_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO8_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO8_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO9_STATUS_OFFSET, 0x0048 
       @ .equ IO_BANK0_GPIO9_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO9_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO9_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO9_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO9_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO9_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO9_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO9_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO9_CTRL_OFFSET, 0x004c 
       @ .equ IO_BANK0_GPIO9_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO9_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO9_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO9_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO9_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO10_STATUS_OFFSET, 0x0050 
       @ .equ IO_BANK0_GPIO10_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO10_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO10_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO10_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO10_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO10_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO10_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO10_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO10_CTRL_OFFSET, 0x0054 
       @ .equ IO_BANK0_GPIO10_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO10_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO10_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO10_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO10_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO11_STATUS_OFFSET, 0x0058 
       @ .equ IO_BANK0_GPIO11_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO11_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO11_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO11_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO11_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO11_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO11_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO11_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO11_CTRL_OFFSET, 0x005c 
       @ .equ IO_BANK0_GPIO11_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO11_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO11_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO11_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO11_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO12_STATUS_OFFSET, 0x0060 
       @ .equ IO_BANK0_GPIO12_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO12_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO12_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO12_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO12_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO12_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO12_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO12_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO12_CTRL_OFFSET, 0x0064 
       @ .equ IO_BANK0_GPIO12_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO12_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO12_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO12_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO12_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO13_STATUS_OFFSET, 0x0068 
       @ .equ IO_BANK0_GPIO13_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO13_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO13_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO13_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO13_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO13_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO13_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO13_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO13_CTRL_OFFSET, 0x006c 
       @ .equ IO_BANK0_GPIO13_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO13_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO13_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO13_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO13_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO14_STATUS_OFFSET, 0x0070 
       @ .equ IO_BANK0_GPIO14_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO14_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO14_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO14_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO14_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO14_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO14_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO14_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO14_CTRL_OFFSET, 0x0074 
       @ .equ IO_BANK0_GPIO14_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO14_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO14_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO14_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO14_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO15_STATUS_OFFSET, 0x0078 
       @ .equ IO_BANK0_GPIO15_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO15_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO15_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO15_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO15_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO15_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO15_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO15_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO15_CTRL_OFFSET, 0x007c 
       @ .equ IO_BANK0_GPIO15_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO15_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO15_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO15_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO15_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO16_STATUS_OFFSET, 0x0080 
       @ .equ IO_BANK0_GPIO16_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO16_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO16_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO16_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO16_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO16_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO16_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO16_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO16_CTRL_OFFSET, 0x0084 
       @ .equ IO_BANK0_GPIO16_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO16_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO16_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO16_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO16_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO17_STATUS_OFFSET, 0x0088 
       @ .equ IO_BANK0_GPIO17_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO17_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO17_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO17_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO17_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO17_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO17_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO17_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO17_CTRL_OFFSET, 0x008c 
       @ .equ IO_BANK0_GPIO17_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO17_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO17_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO17_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO17_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO18_STATUS_OFFSET, 0x0090 
       @ .equ IO_BANK0_GPIO18_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO18_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO18_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO18_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO18_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO18_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO18_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO18_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO18_CTRL_OFFSET, 0x0094 
       @ .equ IO_BANK0_GPIO18_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO18_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO18_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO18_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO18_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO19_STATUS_OFFSET, 0x0098 
       @ .equ IO_BANK0_GPIO19_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO19_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO19_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO19_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO19_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO19_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO19_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO19_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO19_CTRL_OFFSET, 0x009c 
       @ .equ IO_BANK0_GPIO19_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO19_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO19_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO19_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO19_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO20_STATUS_OFFSET, 0x00a0 
       @ .equ IO_BANK0_GPIO20_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO20_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO20_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO20_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO20_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO20_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO20_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO20_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO20_CTRL_OFFSET, 0x00a4 
       @ .equ IO_BANK0_GPIO20_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO20_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO20_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO20_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO20_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO21_STATUS_OFFSET, 0x00a8 
       @ .equ IO_BANK0_GPIO21_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO21_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO21_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO21_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO21_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO21_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO21_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO21_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO21_CTRL_OFFSET, 0x00ac 
       @ .equ IO_BANK0_GPIO21_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO21_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO21_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO21_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO21_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO22_STATUS_OFFSET, 0x00b0 
       @ .equ IO_BANK0_GPIO22_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO22_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO22_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO22_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO22_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO22_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO22_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO22_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO22_CTRL_OFFSET, 0x00b4 
       @ .equ IO_BANK0_GPIO22_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO22_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO22_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO22_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO22_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO23_STATUS_OFFSET, 0x00b8 
       @ .equ IO_BANK0_GPIO23_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO23_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO23_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO23_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO23_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO23_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO23_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO23_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO23_CTRL_OFFSET, 0x00bc 
       @ .equ IO_BANK0_GPIO23_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO23_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO23_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO23_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO23_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO24_STATUS_OFFSET, 0x00c0 
       @ .equ IO_BANK0_GPIO24_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO24_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO24_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO24_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO24_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO24_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO24_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO24_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO24_CTRL_OFFSET, 0x00c4 
       @ .equ IO_BANK0_GPIO24_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO24_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO24_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO24_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO24_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO25_STATUS_OFFSET, 0x00c8 
       @ .equ IO_BANK0_GPIO25_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO25_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO25_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO25_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO25_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO25_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO25_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO25_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO25_CTRL_OFFSET, 0x00cc 
       @ .equ IO_BANK0_GPIO25_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO25_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO25_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO25_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO25_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO26_STATUS_OFFSET, 0x00d0 
       @ .equ IO_BANK0_GPIO26_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO26_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO26_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO26_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO26_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO26_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO26_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO26_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO26_CTRL_OFFSET, 0x00d4 
       @ .equ IO_BANK0_GPIO26_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO26_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO26_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO26_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO26_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO27_STATUS_OFFSET, 0x00d8 
       @ .equ IO_BANK0_GPIO27_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO27_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO27_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO27_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO27_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO27_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO27_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO27_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO27_CTRL_OFFSET, 0x00dc 
       @ .equ IO_BANK0_GPIO27_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO27_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO27_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO27_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO27_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO28_STATUS_OFFSET, 0x00e0 
       @ .equ IO_BANK0_GPIO28_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO28_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO28_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO28_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO28_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO28_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO28_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO28_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO28_CTRL_OFFSET, 0x00e4 
       @ .equ IO_BANK0_GPIO28_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO28_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO28_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO28_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO28_CTRL_FUNCSEL [4:0]     
 
    .equ IO_BANK0_GPIO29_STATUS_OFFSET, 0x00e8 
       @ .equ IO_BANK0_GPIO29_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_BANK0_GPIO29_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_BANK0_GPIO29_STATUS_INTOPERI [19:19]     
       @ .equ IO_BANK0_GPIO29_STATUS_INFROMPAD [17:17]     
       @ .equ IO_BANK0_GPIO29_STATUS_OETOPAD [13:13]     
       @ .equ IO_BANK0_GPIO29_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_BANK0_GPIO29_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_BANK0_GPIO29_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_BANK0_GPIO29_CTRL_OFFSET, 0x00ec 
       @ .equ IO_BANK0_GPIO29_CTRL_IRQOVER [29:28]     
       @ .equ IO_BANK0_GPIO29_CTRL_INOVER [17:16]     
       @ .equ IO_BANK0_GPIO29_CTRL_OEOVER [13:12]     
       @ .equ IO_BANK0_GPIO29_CTRL_OUTOVER [9:8]     
       @ .equ IO_BANK0_GPIO29_CTRL_FUNCSEL [4:0]     
 
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
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_INTOPERI [19:19]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_INFROMPAD [17:17]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OETOPAD [13:13]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_OFFSET, 0x0004 
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SCLK_CTRL_FUNCSEL [4:0]     
 
    .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OFFSET, 0x0008 
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_INTOPERI [19:19]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_INFROMPAD [17:17]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OETOPAD [13:13]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_QSPI_GPIO_QSPI_SS_CTRL_OFFSET, 0x000c 
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SS_CTRL_FUNCSEL [4:0]     
 
    .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OFFSET, 0x0010 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_INTOPERI [19:19]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_INFROMPAD [17:17]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OETOPAD [13:13]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_OFFSET, 0x0014 
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD0_CTRL_FUNCSEL [4:0]     
 
    .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OFFSET, 0x0018 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_INTOPERI [19:19]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_INFROMPAD [17:17]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OETOPAD [13:13]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_OFFSET, 0x001c 
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD1_CTRL_FUNCSEL [4:0]     
 
    .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OFFSET, 0x0020 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_INTOPERI [19:19]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_INFROMPAD [17:17]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OETOPAD [13:13]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_OFFSET, 0x0024 
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD2_CTRL_FUNCSEL [4:0]     
 
    .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OFFSET, 0x0028 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_IRQTOPROC [26:26]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_IRQFROMPAD [24:24]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_INTOPERI [19:19]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_INFROMPAD [17:17]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OETOPAD [13:13]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OEFROMPERI [12:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OUTTOPAD [9:9]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_STATUS_OUTFROMPERI [8:8]     
 
    .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_OFFSET, 0x002c 
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_IRQOVER [29:28]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_INOVER [17:16]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_OEOVER [13:12]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_OUTOVER [9:8]     
       @ .equ IO_QSPI_GPIO_QSPI_SD3_CTRL_FUNCSEL [4:0]     
 
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
       @ .equ PADS_BANK0_GPIO0_OD [7:7]     
       @ .equ PADS_BANK0_GPIO0_IE [6:6]     
       @ .equ PADS_BANK0_GPIO0_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO0_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO0_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO0_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO0_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO1_OFFSET, 0x0008 
       @ .equ PADS_BANK0_GPIO1_OD [7:7]     
       @ .equ PADS_BANK0_GPIO1_IE [6:6]     
       @ .equ PADS_BANK0_GPIO1_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO1_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO1_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO1_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO1_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO2_OFFSET, 0x000c 
       @ .equ PADS_BANK0_GPIO2_OD [7:7]     
       @ .equ PADS_BANK0_GPIO2_IE [6:6]     
       @ .equ PADS_BANK0_GPIO2_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO2_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO2_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO2_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO2_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO3_OFFSET, 0x0010 
       @ .equ PADS_BANK0_GPIO3_OD [7:7]     
       @ .equ PADS_BANK0_GPIO3_IE [6:6]     
       @ .equ PADS_BANK0_GPIO3_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO3_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO3_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO3_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO3_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO4_OFFSET, 0x0014 
       @ .equ PADS_BANK0_GPIO4_OD [7:7]     
       @ .equ PADS_BANK0_GPIO4_IE [6:6]     
       @ .equ PADS_BANK0_GPIO4_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO4_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO4_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO4_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO4_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO5_OFFSET, 0x0018 
       @ .equ PADS_BANK0_GPIO5_OD [7:7]     
       @ .equ PADS_BANK0_GPIO5_IE [6:6]     
       @ .equ PADS_BANK0_GPIO5_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO5_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO5_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO5_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO5_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO6_OFFSET, 0x001c 
       @ .equ PADS_BANK0_GPIO6_OD [7:7]     
       @ .equ PADS_BANK0_GPIO6_IE [6:6]     
       @ .equ PADS_BANK0_GPIO6_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO6_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO6_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO6_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO6_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO7_OFFSET, 0x0020 
       @ .equ PADS_BANK0_GPIO7_OD [7:7]     
       @ .equ PADS_BANK0_GPIO7_IE [6:6]     
       @ .equ PADS_BANK0_GPIO7_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO7_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO7_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO7_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO7_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO8_OFFSET, 0x0024 
       @ .equ PADS_BANK0_GPIO8_OD [7:7]     
       @ .equ PADS_BANK0_GPIO8_IE [6:6]     
       @ .equ PADS_BANK0_GPIO8_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO8_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO8_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO8_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO8_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO9_OFFSET, 0x0028 
       @ .equ PADS_BANK0_GPIO9_OD [7:7]     
       @ .equ PADS_BANK0_GPIO9_IE [6:6]     
       @ .equ PADS_BANK0_GPIO9_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO9_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO9_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO9_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO9_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO10_OFFSET, 0x002c 
       @ .equ PADS_BANK0_GPIO10_OD [7:7]     
       @ .equ PADS_BANK0_GPIO10_IE [6:6]     
       @ .equ PADS_BANK0_GPIO10_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO10_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO10_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO10_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO10_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO11_OFFSET, 0x0030 
       @ .equ PADS_BANK0_GPIO11_OD [7:7]     
       @ .equ PADS_BANK0_GPIO11_IE [6:6]     
       @ .equ PADS_BANK0_GPIO11_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO11_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO11_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO11_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO11_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO12_OFFSET, 0x0034 
       @ .equ PADS_BANK0_GPIO12_OD [7:7]     
       @ .equ PADS_BANK0_GPIO12_IE [6:6]     
       @ .equ PADS_BANK0_GPIO12_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO12_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO12_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO12_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO12_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO13_OFFSET, 0x0038 
       @ .equ PADS_BANK0_GPIO13_OD [7:7]     
       @ .equ PADS_BANK0_GPIO13_IE [6:6]     
       @ .equ PADS_BANK0_GPIO13_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO13_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO13_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO13_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO13_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO14_OFFSET, 0x003c 
       @ .equ PADS_BANK0_GPIO14_OD [7:7]     
       @ .equ PADS_BANK0_GPIO14_IE [6:6]     
       @ .equ PADS_BANK0_GPIO14_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO14_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO14_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO14_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO14_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO15_OFFSET, 0x0040 
       @ .equ PADS_BANK0_GPIO15_OD [7:7]     
       @ .equ PADS_BANK0_GPIO15_IE [6:6]     
       @ .equ PADS_BANK0_GPIO15_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO15_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO15_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO15_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO15_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO16_OFFSET, 0x0044 
       @ .equ PADS_BANK0_GPIO16_OD [7:7]     
       @ .equ PADS_BANK0_GPIO16_IE [6:6]     
       @ .equ PADS_BANK0_GPIO16_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO16_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO16_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO16_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO16_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO17_OFFSET, 0x0048 
       @ .equ PADS_BANK0_GPIO17_OD [7:7]     
       @ .equ PADS_BANK0_GPIO17_IE [6:6]     
       @ .equ PADS_BANK0_GPIO17_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO17_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO17_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO17_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO17_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO18_OFFSET, 0x004c 
       @ .equ PADS_BANK0_GPIO18_OD [7:7]     
       @ .equ PADS_BANK0_GPIO18_IE [6:6]     
       @ .equ PADS_BANK0_GPIO18_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO18_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO18_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO18_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO18_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO19_OFFSET, 0x0050 
       @ .equ PADS_BANK0_GPIO19_OD [7:7]     
       @ .equ PADS_BANK0_GPIO19_IE [6:6]     
       @ .equ PADS_BANK0_GPIO19_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO19_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO19_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO19_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO19_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO20_OFFSET, 0x0054 
       @ .equ PADS_BANK0_GPIO20_OD [7:7]     
       @ .equ PADS_BANK0_GPIO20_IE [6:6]     
       @ .equ PADS_BANK0_GPIO20_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO20_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO20_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO20_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO20_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO21_OFFSET, 0x0058 
       @ .equ PADS_BANK0_GPIO21_OD [7:7]     
       @ .equ PADS_BANK0_GPIO21_IE [6:6]     
       @ .equ PADS_BANK0_GPIO21_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO21_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO21_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO21_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO21_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO22_OFFSET, 0x005c 
       @ .equ PADS_BANK0_GPIO22_OD [7:7]     
       @ .equ PADS_BANK0_GPIO22_IE [6:6]     
       @ .equ PADS_BANK0_GPIO22_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO22_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO22_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO22_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO22_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO23_OFFSET, 0x0060 
       @ .equ PADS_BANK0_GPIO23_OD [7:7]     
       @ .equ PADS_BANK0_GPIO23_IE [6:6]     
       @ .equ PADS_BANK0_GPIO23_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO23_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO23_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO23_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO23_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO24_OFFSET, 0x0064 
       @ .equ PADS_BANK0_GPIO24_OD [7:7]     
       @ .equ PADS_BANK0_GPIO24_IE [6:6]     
       @ .equ PADS_BANK0_GPIO24_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO24_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO24_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO24_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO24_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO25_OFFSET, 0x0068 
       @ .equ PADS_BANK0_GPIO25_OD [7:7]     
       @ .equ PADS_BANK0_GPIO25_IE [6:6]     
       @ .equ PADS_BANK0_GPIO25_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO25_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO25_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO25_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO25_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO26_OFFSET, 0x006c 
       @ .equ PADS_BANK0_GPIO26_OD [7:7]     
       @ .equ PADS_BANK0_GPIO26_IE [6:6]     
       @ .equ PADS_BANK0_GPIO26_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO26_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO26_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO26_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO26_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO27_OFFSET, 0x0070 
       @ .equ PADS_BANK0_GPIO27_OD [7:7]     
       @ .equ PADS_BANK0_GPIO27_IE [6:6]     
       @ .equ PADS_BANK0_GPIO27_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO27_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO27_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO27_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO27_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO28_OFFSET, 0x0074 
       @ .equ PADS_BANK0_GPIO28_OD [7:7]     
       @ .equ PADS_BANK0_GPIO28_IE [6:6]     
       @ .equ PADS_BANK0_GPIO28_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO28_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO28_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO28_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO28_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_GPIO29_OFFSET, 0x0078 
       @ .equ PADS_BANK0_GPIO29_OD [7:7]     
       @ .equ PADS_BANK0_GPIO29_IE [6:6]     
       @ .equ PADS_BANK0_GPIO29_DRIVE [5:4]     
       @ .equ PADS_BANK0_GPIO29_PUE [3:3]     
       @ .equ PADS_BANK0_GPIO29_PDE [2:2]     
       @ .equ PADS_BANK0_GPIO29_SCHMITT [1:1]     
       @ .equ PADS_BANK0_GPIO29_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_SWCLK_OFFSET, 0x007c 
       @ .equ PADS_BANK0_SWCLK_OD [7:7]     
       @ .equ PADS_BANK0_SWCLK_IE [6:6]     
       @ .equ PADS_BANK0_SWCLK_DRIVE [5:4]     
       @ .equ PADS_BANK0_SWCLK_PUE [3:3]     
       @ .equ PADS_BANK0_SWCLK_PDE [2:2]     
       @ .equ PADS_BANK0_SWCLK_SCHMITT [1:1]     
       @ .equ PADS_BANK0_SWCLK_SLEWFAST [0:0]     
 
    .equ PADS_BANK0_SWD_OFFSET, 0x0080 
       @ .equ PADS_BANK0_SWD_OD [7:7]     
       @ .equ PADS_BANK0_SWD_IE [6:6]     
       @ .equ PADS_BANK0_SWD_DRIVE [5:4]     
       @ .equ PADS_BANK0_SWD_PUE [3:3]     
       @ .equ PADS_BANK0_SWD_PDE [2:2]     
       @ .equ PADS_BANK0_SWD_SCHMITT [1:1]     
       @ .equ PADS_BANK0_SWD_SLEWFAST [0:0]     
 

@=========================== PADS_QSPI ===========================@
.equ PADS_QSPI_BASE, 0x40020000 
    .equ PADS_QSPI_VOLTAGE_SELECT_OFFSET, 0x0000 
       @ .equ PADS_QSPI_VOLTAGE_SELECT_VOLTAGE_SELECT [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SCLK_OFFSET, 0x0004 
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_OD [7:7]     
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_IE [6:6]     
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_DRIVE [5:4]     
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_PUE [3:3]     
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_PDE [2:2]     
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_SCHMITT [1:1]     
       @ .equ PADS_QSPI_GPIO_QSPI_SCLK_SLEWFAST [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SD0_OFFSET, 0x0008 
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_OD [7:7]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_IE [6:6]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_DRIVE [5:4]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_PUE [3:3]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_PDE [2:2]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_SCHMITT [1:1]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD0_SLEWFAST [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SD1_OFFSET, 0x000c 
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_OD [7:7]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_IE [6:6]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_DRIVE [5:4]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_PUE [3:3]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_PDE [2:2]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_SCHMITT [1:1]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD1_SLEWFAST [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SD2_OFFSET, 0x0010 
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_OD [7:7]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_IE [6:6]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_DRIVE [5:4]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_PUE [3:3]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_PDE [2:2]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_SCHMITT [1:1]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD2_SLEWFAST [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SD3_OFFSET, 0x0014 
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_OD [7:7]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_IE [6:6]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_DRIVE [5:4]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_PUE [3:3]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_PDE [2:2]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_SCHMITT [1:1]     
       @ .equ PADS_QSPI_GPIO_QSPI_SD3_SLEWFAST [0:0]     
 
    .equ PADS_QSPI_GPIO_QSPI_SS_OFFSET, 0x0018 
       @ .equ PADS_QSPI_GPIO_QSPI_SS_OD [7:7]     
       @ .equ PADS_QSPI_GPIO_QSPI_SS_IE [6:6]     
       @ .equ PADS_QSPI_GPIO_QSPI_SS_DRIVE [5:4]     
       @ .equ PADS_QSPI_GPIO_QSPI_SS_PUE [3:3]     
       @ .equ PADS_QSPI_GPIO_QSPI_SS_PDE [2:2]     
       @ .equ PADS_QSPI_GPIO_QSPI_SS_SCHMITT [1:1]     
       @ .equ PADS_QSPI_GPIO_QSPI_SS_SLEWFAST [0:0]     
 

@=========================== XOSC ===========================@
.equ XOSC_BASE, 0x40024000 
    .equ XOSC_CTRL_OFFSET, 0x0000 
       @ .equ XOSC_CTRL_ENABLE [23:12]     
       @ .equ XOSC_CTRL_FREQ_RANGE [11:0]     
 
    .equ XOSC_STATUS_OFFSET, 0x0004 
       @ .equ XOSC_STATUS_STABLE [31:31]     
       @ .equ XOSC_STATUS_BADWRITE [24:24]     
       @ .equ XOSC_STATUS_ENABLED [12:12]     
       @ .equ XOSC_STATUS_FREQ_RANGE [1:0]     
 
    .equ XOSC_DORMANT_OFFSET, 0x0008 
 
    .equ XOSC_STARTUP_OFFSET, 0x000c 
       @ .equ XOSC_STARTUP_X4 [20:20]     
       @ .equ XOSC_STARTUP_DELAY [13:0]     
 
    .equ XOSC_COUNT_OFFSET, 0x001c 
       @ .equ XOSC_COUNT_COUNT [7:0]     
 

@=========================== PLL_SYS ===========================@
.equ PLL_SYS_BASE, 0x40028000 
    .equ PLL_SYS_CS_OFFSET, 0x0000 
       @ .equ PLL_SYS_CS_LOCK [31:31]     
       @ .equ PLL_SYS_CS_BYPASS [8:8]     
       @ .equ PLL_SYS_CS_REFDIV [5:0]     
 
    .equ PLL_SYS_PWR_OFFSET, 0x0004 
       @ .equ PLL_SYS_PWR_VCOPD [5:5]     
       @ .equ PLL_SYS_PWR_POSTDIVPD [3:3]     
       @ .equ PLL_SYS_PWR_DSMPD [2:2]     
       @ .equ PLL_SYS_PWR_PD [0:0]     
 
    .equ PLL_SYS_FBDIV_INT_OFFSET, 0x0008 
       @ .equ PLL_SYS_FBDIV_INT_FBDIV_INT [11:0]     
 
    .equ PLL_SYS_PRIM_OFFSET, 0x000c 
       @ .equ PLL_SYS_PRIM_POSTDIV1 [18:16]     
       @ .equ PLL_SYS_PRIM_POSTDIV2 [14:12]     
 

@=========================== PLL_USB ===========================@
.equ PLL_USB_BASE, 0x4002c000 
    .equ PLL_USB_CS_OFFSET, 0x0000 
       @ .equ PLL_USB_CS_LOCK [31:31]     
       @ .equ PLL_USB_CS_BYPASS [8:8]     
       @ .equ PLL_USB_CS_REFDIV [5:0]     
 
    .equ PLL_USB_PWR_OFFSET, 0x0004 
       @ .equ PLL_USB_PWR_VCOPD [5:5]     
       @ .equ PLL_USB_PWR_POSTDIVPD [3:3]     
       @ .equ PLL_USB_PWR_DSMPD [2:2]     
       @ .equ PLL_USB_PWR_PD [0:0]     
 
    .equ PLL_USB_FBDIV_INT_OFFSET, 0x0008 
       @ .equ PLL_USB_FBDIV_INT_FBDIV_INT [11:0]     
 
    .equ PLL_USB_PRIM_OFFSET, 0x000c 
       @ .equ PLL_USB_PRIM_POSTDIV1 [18:16]     
       @ .equ PLL_USB_PRIM_POSTDIV2 [14:12]     
 

@=========================== BUSCTRL ===========================@
.equ BUSCTRL_BASE, 0x40030000 
    .equ BUSCTRL_BUS_PRIORITY_OFFSET, 0x0000 
       @ .equ BUSCTRL_BUS_PRIORITY_DMA_W [12:12]     
       @ .equ BUSCTRL_BUS_PRIORITY_DMA_R [8:8]     
       @ .equ BUSCTRL_BUS_PRIORITY_PROC1 [4:4]     
       @ .equ BUSCTRL_BUS_PRIORITY_PROC0 [0:0]     
 
    .equ BUSCTRL_BUS_PRIORITY_ACK_OFFSET, 0x0004 
       @ .equ BUSCTRL_BUS_PRIORITY_ACK_BUS_PRIORITY_ACK [0:0]     
 
    .equ BUSCTRL_PERFCTR0_OFFSET, 0x0008 
       @ .equ BUSCTRL_PERFCTR0_PERFCTR0 [23:0]     
 
    .equ BUSCTRL_PERFSEL0_OFFSET, 0x000c 
       @ .equ BUSCTRL_PERFSEL0_PERFSEL0 [4:0]     
 
    .equ BUSCTRL_PERFCTR1_OFFSET, 0x0010 
       @ .equ BUSCTRL_PERFCTR1_PERFCTR1 [23:0]     
 
    .equ BUSCTRL_PERFSEL1_OFFSET, 0x0014 
       @ .equ BUSCTRL_PERFSEL1_PERFSEL1 [4:0]     
 
    .equ BUSCTRL_PERFCTR2_OFFSET, 0x0018 
       @ .equ BUSCTRL_PERFCTR2_PERFCTR2 [23:0]     
 
    .equ BUSCTRL_PERFSEL2_OFFSET, 0x001c 
       @ .equ BUSCTRL_PERFSEL2_PERFSEL2 [4:0]     
 
    .equ BUSCTRL_PERFCTR3_OFFSET, 0x0020 
       @ .equ BUSCTRL_PERFCTR3_PERFCTR3 [23:0]     
 
    .equ BUSCTRL_PERFSEL3_OFFSET, 0x0024 
       @ .equ BUSCTRL_PERFSEL3_PERFSEL3 [4:0]     
 

@=========================== UART0 ===========================@
.equ UART0_BASE, 0x40034000 
    .equ UART0_UARTDR_OFFSET, 0x0000 
       @ .equ UART0_UARTDR_OE [11:11]     
       @ .equ UART0_UARTDR_BE [10:10]     
       @ .equ UART0_UARTDR_PE [9:9]     
       @ .equ UART0_UARTDR_FE [8:8]     
       @ .equ UART0_UARTDR_DATA [7:0]     
 
    .equ UART0_UARTRSR_OFFSET, 0x0004 
       @ .equ UART0_UARTRSR_OE [3:3]     
       @ .equ UART0_UARTRSR_BE [2:2]     
       @ .equ UART0_UARTRSR_PE [1:1]     
       @ .equ UART0_UARTRSR_FE [0:0]     
 
    .equ UART0_UARTFR_OFFSET, 0x0018 
       @ .equ UART0_UARTFR_RI [8:8]     
       @ .equ UART0_UARTFR_TXFE [7:7]     
       @ .equ UART0_UARTFR_RXFF [6:6]     
       @ .equ UART0_UARTFR_TXFF [5:5]     
       @ .equ UART0_UARTFR_RXFE [4:4]     
       @ .equ UART0_UARTFR_BUSY [3:3]     
       @ .equ UART0_UARTFR_DCD [2:2]     
       @ .equ UART0_UARTFR_DSR [1:1]     
       @ .equ UART0_UARTFR_CTS [0:0]     
 
    .equ UART0_UARTILPR_OFFSET, 0x0020 
       @ .equ UART0_UARTILPR_ILPDVSR [7:0]     
 
    .equ UART0_UARTIBRD_OFFSET, 0x0024 
       @ .equ UART0_UARTIBRD_BAUD_DIVINT [15:0]     
 
    .equ UART0_UARTFBRD_OFFSET, 0x0028 
       @ .equ UART0_UARTFBRD_BAUD_DIVFRAC [5:0]     
 
    .equ UART0_UARTLCR_H_OFFSET, 0x002c 
       @ .equ UART0_UARTLCR_H_SPS [7:7]     
       @ .equ UART0_UARTLCR_H_WLEN [6:5]     
       @ .equ UART0_UARTLCR_H_FEN [4:4]     
       @ .equ UART0_UARTLCR_H_STP2 [3:3]     
       @ .equ UART0_UARTLCR_H_EPS [2:2]     
       @ .equ UART0_UARTLCR_H_PEN [1:1]     
       @ .equ UART0_UARTLCR_H_BRK [0:0]     
 
    .equ UART0_UARTCR_OFFSET, 0x0030 
       @ .equ UART0_UARTCR_CTSEN [15:15]     
       @ .equ UART0_UARTCR_RTSEN [14:14]     
       @ .equ UART0_UARTCR_OUT2 [13:13]     
       @ .equ UART0_UARTCR_OUT1 [12:12]     
       @ .equ UART0_UARTCR_RTS [11:11]     
       @ .equ UART0_UARTCR_DTR [10:10]     
       @ .equ UART0_UARTCR_RXE [9:9]     
       @ .equ UART0_UARTCR_TXE [8:8]     
       @ .equ UART0_UARTCR_LBE [7:7]     
       @ .equ UART0_UARTCR_SIRLP [2:2]     
       @ .equ UART0_UARTCR_SIREN [1:1]     
       @ .equ UART0_UARTCR_UARTEN [0:0]     
 
    .equ UART0_UARTIFLS_OFFSET, 0x0034 
       @ .equ UART0_UARTIFLS_RXIFLSEL [5:3]     
       @ .equ UART0_UARTIFLS_TXIFLSEL [2:0]     
 
    .equ UART0_UARTIMSC_OFFSET, 0x0038 
       @ .equ UART0_UARTIMSC_OEIM [10:10]     
       @ .equ UART0_UARTIMSC_BEIM [9:9]     
       @ .equ UART0_UARTIMSC_PEIM [8:8]     
       @ .equ UART0_UARTIMSC_FEIM [7:7]     
       @ .equ UART0_UARTIMSC_RTIM [6:6]     
       @ .equ UART0_UARTIMSC_TXIM [5:5]     
       @ .equ UART0_UARTIMSC_RXIM [4:4]     
       @ .equ UART0_UARTIMSC_DSRMIM [3:3]     
       @ .equ UART0_UARTIMSC_DCDMIM [2:2]     
       @ .equ UART0_UARTIMSC_CTSMIM [1:1]     
       @ .equ UART0_UARTIMSC_RIMIM [0:0]     
 
    .equ UART0_UARTRIS_OFFSET, 0x003c 
       @ .equ UART0_UARTRIS_OERIS [10:10]     
       @ .equ UART0_UARTRIS_BERIS [9:9]     
       @ .equ UART0_UARTRIS_PERIS [8:8]     
       @ .equ UART0_UARTRIS_FERIS [7:7]     
       @ .equ UART0_UARTRIS_RTRIS [6:6]     
       @ .equ UART0_UARTRIS_TXRIS [5:5]     
       @ .equ UART0_UARTRIS_RXRIS [4:4]     
       @ .equ UART0_UARTRIS_DSRRMIS [3:3]     
       @ .equ UART0_UARTRIS_DCDRMIS [2:2]     
       @ .equ UART0_UARTRIS_CTSRMIS [1:1]     
       @ .equ UART0_UARTRIS_RIRMIS [0:0]     
 
    .equ UART0_UARTMIS_OFFSET, 0x0040 
       @ .equ UART0_UARTMIS_OEMIS [10:10]     
       @ .equ UART0_UARTMIS_BEMIS [9:9]     
       @ .equ UART0_UARTMIS_PEMIS [8:8]     
       @ .equ UART0_UARTMIS_FEMIS [7:7]     
       @ .equ UART0_UARTMIS_RTMIS [6:6]     
       @ .equ UART0_UARTMIS_TXMIS [5:5]     
       @ .equ UART0_UARTMIS_RXMIS [4:4]     
       @ .equ UART0_UARTMIS_DSRMMIS [3:3]     
       @ .equ UART0_UARTMIS_DCDMMIS [2:2]     
       @ .equ UART0_UARTMIS_CTSMMIS [1:1]     
       @ .equ UART0_UARTMIS_RIMMIS [0:0]     
 
    .equ UART0_UARTICR_OFFSET, 0x0044 
       @ .equ UART0_UARTICR_OEIC [10:10]     
       @ .equ UART0_UARTICR_BEIC [9:9]     
       @ .equ UART0_UARTICR_PEIC [8:8]     
       @ .equ UART0_UARTICR_FEIC [7:7]     
       @ .equ UART0_UARTICR_RTIC [6:6]     
       @ .equ UART0_UARTICR_TXIC [5:5]     
       @ .equ UART0_UARTICR_RXIC [4:4]     
       @ .equ UART0_UARTICR_DSRMIC [3:3]     
       @ .equ UART0_UARTICR_DCDMIC [2:2]     
       @ .equ UART0_UARTICR_CTSMIC [1:1]     
       @ .equ UART0_UARTICR_RIMIC [0:0]     
 
    .equ UART0_UARTDMACR_OFFSET, 0x0048 
       @ .equ UART0_UARTDMACR_DMAONERR [2:2]     
       @ .equ UART0_UARTDMACR_TXDMAE [1:1]     
       @ .equ UART0_UARTDMACR_RXDMAE [0:0]     
 
    .equ UART0_UARTPERIPHID0_OFFSET, 0x0fe0 
       @ .equ UART0_UARTPERIPHID0_PARTNUMBER0 [7:0]     
 
    .equ UART0_UARTPERIPHID1_OFFSET, 0x0fe4 
       @ .equ UART0_UARTPERIPHID1_DESIGNER0 [7:4]     
       @ .equ UART0_UARTPERIPHID1_PARTNUMBER1 [3:0]     
 
    .equ UART0_UARTPERIPHID2_OFFSET, 0x0fe8 
       @ .equ UART0_UARTPERIPHID2_REVISION [7:4]     
       @ .equ UART0_UARTPERIPHID2_DESIGNER1 [3:0]     
 
    .equ UART0_UARTPERIPHID3_OFFSET, 0x0fec 
       @ .equ UART0_UARTPERIPHID3_CONFIGURATION [7:0]     
 
    .equ UART0_UARTPCELLID0_OFFSET, 0x0ff0 
       @ .equ UART0_UARTPCELLID0_UARTPCELLID0 [7:0]     
 
    .equ UART0_UARTPCELLID1_OFFSET, 0x0ff4 
       @ .equ UART0_UARTPCELLID1_UARTPCELLID1 [7:0]     
 
    .equ UART0_UARTPCELLID2_OFFSET, 0x0ff8 
       @ .equ UART0_UARTPCELLID2_UARTPCELLID2 [7:0]     
 
    .equ UART0_UARTPCELLID3_OFFSET, 0x0ffc 
       @ .equ UART0_UARTPCELLID3_UARTPCELLID3 [7:0]     
 

@=========================== UART1 ===========================@
.equ UART1_BASE, 0x40038000 
    .equ UART1_UARTDR_OFFSET, 0x0000 
       @ .equ UART1_UARTDR_OE [11:11]     
       @ .equ UART1_UARTDR_BE [10:10]     
       @ .equ UART1_UARTDR_PE [9:9]     
       @ .equ UART1_UARTDR_FE [8:8]     
       @ .equ UART1_UARTDR_DATA [7:0]     
 
    .equ UART1_UARTRSR_OFFSET, 0x0004 
       @ .equ UART1_UARTRSR_OE [3:3]     
       @ .equ UART1_UARTRSR_BE [2:2]     
       @ .equ UART1_UARTRSR_PE [1:1]     
       @ .equ UART1_UARTRSR_FE [0:0]     
 
    .equ UART1_UARTFR_OFFSET, 0x0018 
       @ .equ UART1_UARTFR_RI [8:8]     
       @ .equ UART1_UARTFR_TXFE [7:7]     
       @ .equ UART1_UARTFR_RXFF [6:6]     
       @ .equ UART1_UARTFR_TXFF [5:5]     
       @ .equ UART1_UARTFR_RXFE [4:4]     
       @ .equ UART1_UARTFR_BUSY [3:3]     
       @ .equ UART1_UARTFR_DCD [2:2]     
       @ .equ UART1_UARTFR_DSR [1:1]     
       @ .equ UART1_UARTFR_CTS [0:0]     
 
    .equ UART1_UARTILPR_OFFSET, 0x0020 
       @ .equ UART1_UARTILPR_ILPDVSR [7:0]     
 
    .equ UART1_UARTIBRD_OFFSET, 0x0024 
       @ .equ UART1_UARTIBRD_BAUD_DIVINT [15:0]     
 
    .equ UART1_UARTFBRD_OFFSET, 0x0028 
       @ .equ UART1_UARTFBRD_BAUD_DIVFRAC [5:0]     
 
    .equ UART1_UARTLCR_H_OFFSET, 0x002c 
       @ .equ UART1_UARTLCR_H_SPS [7:7]     
       @ .equ UART1_UARTLCR_H_WLEN [6:5]     
       @ .equ UART1_UARTLCR_H_FEN [4:4]     
       @ .equ UART1_UARTLCR_H_STP2 [3:3]     
       @ .equ UART1_UARTLCR_H_EPS [2:2]     
       @ .equ UART1_UARTLCR_H_PEN [1:1]     
       @ .equ UART1_UARTLCR_H_BRK [0:0]     
 
    .equ UART1_UARTCR_OFFSET, 0x0030 
       @ .equ UART1_UARTCR_CTSEN [15:15]     
       @ .equ UART1_UARTCR_RTSEN [14:14]     
       @ .equ UART1_UARTCR_OUT2 [13:13]     
       @ .equ UART1_UARTCR_OUT1 [12:12]     
       @ .equ UART1_UARTCR_RTS [11:11]     
       @ .equ UART1_UARTCR_DTR [10:10]     
       @ .equ UART1_UARTCR_RXE [9:9]     
       @ .equ UART1_UARTCR_TXE [8:8]     
       @ .equ UART1_UARTCR_LBE [7:7]     
       @ .equ UART1_UARTCR_SIRLP [2:2]     
       @ .equ UART1_UARTCR_SIREN [1:1]     
       @ .equ UART1_UARTCR_UARTEN [0:0]     
 
    .equ UART1_UARTIFLS_OFFSET, 0x0034 
       @ .equ UART1_UARTIFLS_RXIFLSEL [5:3]     
       @ .equ UART1_UARTIFLS_TXIFLSEL [2:0]     
 
    .equ UART1_UARTIMSC_OFFSET, 0x0038 
       @ .equ UART1_UARTIMSC_OEIM [10:10]     
       @ .equ UART1_UARTIMSC_BEIM [9:9]     
       @ .equ UART1_UARTIMSC_PEIM [8:8]     
       @ .equ UART1_UARTIMSC_FEIM [7:7]     
       @ .equ UART1_UARTIMSC_RTIM [6:6]     
       @ .equ UART1_UARTIMSC_TXIM [5:5]     
       @ .equ UART1_UARTIMSC_RXIM [4:4]     
       @ .equ UART1_UARTIMSC_DSRMIM [3:3]     
       @ .equ UART1_UARTIMSC_DCDMIM [2:2]     
       @ .equ UART1_UARTIMSC_CTSMIM [1:1]     
       @ .equ UART1_UARTIMSC_RIMIM [0:0]     
 
    .equ UART1_UARTRIS_OFFSET, 0x003c 
       @ .equ UART1_UARTRIS_OERIS [10:10]     
       @ .equ UART1_UARTRIS_BERIS [9:9]     
       @ .equ UART1_UARTRIS_PERIS [8:8]     
       @ .equ UART1_UARTRIS_FERIS [7:7]     
       @ .equ UART1_UARTRIS_RTRIS [6:6]     
       @ .equ UART1_UARTRIS_TXRIS [5:5]     
       @ .equ UART1_UARTRIS_RXRIS [4:4]     
       @ .equ UART1_UARTRIS_DSRRMIS [3:3]     
       @ .equ UART1_UARTRIS_DCDRMIS [2:2]     
       @ .equ UART1_UARTRIS_CTSRMIS [1:1]     
       @ .equ UART1_UARTRIS_RIRMIS [0:0]     
 
    .equ UART1_UARTMIS_OFFSET, 0x0040 
       @ .equ UART1_UARTMIS_OEMIS [10:10]     
       @ .equ UART1_UARTMIS_BEMIS [9:9]     
       @ .equ UART1_UARTMIS_PEMIS [8:8]     
       @ .equ UART1_UARTMIS_FEMIS [7:7]     
       @ .equ UART1_UARTMIS_RTMIS [6:6]     
       @ .equ UART1_UARTMIS_TXMIS [5:5]     
       @ .equ UART1_UARTMIS_RXMIS [4:4]     
       @ .equ UART1_UARTMIS_DSRMMIS [3:3]     
       @ .equ UART1_UARTMIS_DCDMMIS [2:2]     
       @ .equ UART1_UARTMIS_CTSMMIS [1:1]     
       @ .equ UART1_UARTMIS_RIMMIS [0:0]     
 
    .equ UART1_UARTICR_OFFSET, 0x0044 
       @ .equ UART1_UARTICR_OEIC [10:10]     
       @ .equ UART1_UARTICR_BEIC [9:9]     
       @ .equ UART1_UARTICR_PEIC [8:8]     
       @ .equ UART1_UARTICR_FEIC [7:7]     
       @ .equ UART1_UARTICR_RTIC [6:6]     
       @ .equ UART1_UARTICR_TXIC [5:5]     
       @ .equ UART1_UARTICR_RXIC [4:4]     
       @ .equ UART1_UARTICR_DSRMIC [3:3]     
       @ .equ UART1_UARTICR_DCDMIC [2:2]     
       @ .equ UART1_UARTICR_CTSMIC [1:1]     
       @ .equ UART1_UARTICR_RIMIC [0:0]     
 
    .equ UART1_UARTDMACR_OFFSET, 0x0048 
       @ .equ UART1_UARTDMACR_DMAONERR [2:2]     
       @ .equ UART1_UARTDMACR_TXDMAE [1:1]     
       @ .equ UART1_UARTDMACR_RXDMAE [0:0]     
 
    .equ UART1_UARTPERIPHID0_OFFSET, 0x0fe0 
       @ .equ UART1_UARTPERIPHID0_PARTNUMBER0 [7:0]     
 
    .equ UART1_UARTPERIPHID1_OFFSET, 0x0fe4 
       @ .equ UART1_UARTPERIPHID1_DESIGNER0 [7:4]     
       @ .equ UART1_UARTPERIPHID1_PARTNUMBER1 [3:0]     
 
    .equ UART1_UARTPERIPHID2_OFFSET, 0x0fe8 
       @ .equ UART1_UARTPERIPHID2_REVISION [7:4]     
       @ .equ UART1_UARTPERIPHID2_DESIGNER1 [3:0]     
 
    .equ UART1_UARTPERIPHID3_OFFSET, 0x0fec 
       @ .equ UART1_UARTPERIPHID3_CONFIGURATION [7:0]     
 
    .equ UART1_UARTPCELLID0_OFFSET, 0x0ff0 
       @ .equ UART1_UARTPCELLID0_UARTPCELLID0 [7:0]     
 
    .equ UART1_UARTPCELLID1_OFFSET, 0x0ff4 
       @ .equ UART1_UARTPCELLID1_UARTPCELLID1 [7:0]     
 
    .equ UART1_UARTPCELLID2_OFFSET, 0x0ff8 
       @ .equ UART1_UARTPCELLID2_UARTPCELLID2 [7:0]     
 
    .equ UART1_UARTPCELLID3_OFFSET, 0x0ffc 
       @ .equ UART1_UARTPCELLID3_UARTPCELLID3 [7:0]     
 

@=========================== SPI0 ===========================@
.equ SPI0_BASE, 0x4003c000 
    .equ SPI0_SSPCR0_OFFSET, 0x0000 
       @ .equ SPI0_SSPCR0_SCR [15:8]     
       @ .equ SPI0_SSPCR0_SPH [7:7]     
       @ .equ SPI0_SSPCR0_SPO [6:6]     
       @ .equ SPI0_SSPCR0_FRF [5:4]     
       @ .equ SPI0_SSPCR0_DSS [3:0]     
 
    .equ SPI0_SSPCR1_OFFSET, 0x0004 
       @ .equ SPI0_SSPCR1_SOD [3:3]     
       @ .equ SPI0_SSPCR1_MS [2:2]     
       @ .equ SPI0_SSPCR1_SSE [1:1]     
       @ .equ SPI0_SSPCR1_LBM [0:0]     
 
    .equ SPI0_SSPDR_OFFSET, 0x0008 
       @ .equ SPI0_SSPDR_DATA [15:0]     
 
    .equ SPI0_SSPSR_OFFSET, 0x000c 
       @ .equ SPI0_SSPSR_BSY [4:4]     
       @ .equ SPI0_SSPSR_RFF [3:3]     
       @ .equ SPI0_SSPSR_RNE [2:2]     
       @ .equ SPI0_SSPSR_TNF [1:1]     
       @ .equ SPI0_SSPSR_TFE [0:0]     
 
    .equ SPI0_SSPCPSR_OFFSET, 0x0010 
       @ .equ SPI0_SSPCPSR_CPSDVSR [7:0]     
 
    .equ SPI0_SSPIMSC_OFFSET, 0x0014 
       @ .equ SPI0_SSPIMSC_TXIM [3:3]     
       @ .equ SPI0_SSPIMSC_RXIM [2:2]     
       @ .equ SPI0_SSPIMSC_RTIM [1:1]     
       @ .equ SPI0_SSPIMSC_RORIM [0:0]     
 
    .equ SPI0_SSPRIS_OFFSET, 0x0018 
       @ .equ SPI0_SSPRIS_TXRIS [3:3]     
       @ .equ SPI0_SSPRIS_RXRIS [2:2]     
       @ .equ SPI0_SSPRIS_RTRIS [1:1]     
       @ .equ SPI0_SSPRIS_RORRIS [0:0]     
 
    .equ SPI0_SSPMIS_OFFSET, 0x001c 
       @ .equ SPI0_SSPMIS_TXMIS [3:3]     
       @ .equ SPI0_SSPMIS_RXMIS [2:2]     
       @ .equ SPI0_SSPMIS_RTMIS [1:1]     
       @ .equ SPI0_SSPMIS_RORMIS [0:0]     
 
    .equ SPI0_SSPICR_OFFSET, 0x0020 
       @ .equ SPI0_SSPICR_RTIC [1:1]     
       @ .equ SPI0_SSPICR_RORIC [0:0]     
 
    .equ SPI0_SSPDMACR_OFFSET, 0x0024 
       @ .equ SPI0_SSPDMACR_TXDMAE [1:1]     
       @ .equ SPI0_SSPDMACR_RXDMAE [0:0]     
 
    .equ SPI0_SSPPERIPHID0_OFFSET, 0x0fe0 
       @ .equ SPI0_SSPPERIPHID0_PARTNUMBER0 [7:0]     
 
    .equ SPI0_SSPPERIPHID1_OFFSET, 0x0fe4 
       @ .equ SPI0_SSPPERIPHID1_DESIGNER0 [7:4]     
       @ .equ SPI0_SSPPERIPHID1_PARTNUMBER1 [3:0]     
 
    .equ SPI0_SSPPERIPHID2_OFFSET, 0x0fe8 
       @ .equ SPI0_SSPPERIPHID2_REVISION [7:4]     
       @ .equ SPI0_SSPPERIPHID2_DESIGNER1 [3:0]     
 
    .equ SPI0_SSPPERIPHID3_OFFSET, 0x0fec 
       @ .equ SPI0_SSPPERIPHID3_CONFIGURATION [7:0]     
 
    .equ SPI0_SSPPCELLID0_OFFSET, 0x0ff0 
       @ .equ SPI0_SSPPCELLID0_SSPPCELLID0 [7:0]     
 
    .equ SPI0_SSPPCELLID1_OFFSET, 0x0ff4 
       @ .equ SPI0_SSPPCELLID1_SSPPCELLID1 [7:0]     
 
    .equ SPI0_SSPPCELLID2_OFFSET, 0x0ff8 
       @ .equ SPI0_SSPPCELLID2_SSPPCELLID2 [7:0]     
 
    .equ SPI0_SSPPCELLID3_OFFSET, 0x0ffc 
       @ .equ SPI0_SSPPCELLID3_SSPPCELLID3 [7:0]     
 

@=========================== SPI1 ===========================@
.equ SPI1_BASE, 0x40040000 
    .equ SPI1_SSPCR0_OFFSET, 0x0000 
       @ .equ SPI1_SSPCR0_SCR [15:8]     
       @ .equ SPI1_SSPCR0_SPH [7:7]     
       @ .equ SPI1_SSPCR0_SPO [6:6]     
       @ .equ SPI1_SSPCR0_FRF [5:4]     
       @ .equ SPI1_SSPCR0_DSS [3:0]     
 
    .equ SPI1_SSPCR1_OFFSET, 0x0004 
       @ .equ SPI1_SSPCR1_SOD [3:3]     
       @ .equ SPI1_SSPCR1_MS [2:2]     
       @ .equ SPI1_SSPCR1_SSE [1:1]     
       @ .equ SPI1_SSPCR1_LBM [0:0]     
 
    .equ SPI1_SSPDR_OFFSET, 0x0008 
       @ .equ SPI1_SSPDR_DATA [15:0]     
 
    .equ SPI1_SSPSR_OFFSET, 0x000c 
       @ .equ SPI1_SSPSR_BSY [4:4]     
       @ .equ SPI1_SSPSR_RFF [3:3]     
       @ .equ SPI1_SSPSR_RNE [2:2]     
       @ .equ SPI1_SSPSR_TNF [1:1]     
       @ .equ SPI1_SSPSR_TFE [0:0]     
 
    .equ SPI1_SSPCPSR_OFFSET, 0x0010 
       @ .equ SPI1_SSPCPSR_CPSDVSR [7:0]     
 
    .equ SPI1_SSPIMSC_OFFSET, 0x0014 
       @ .equ SPI1_SSPIMSC_TXIM [3:3]     
       @ .equ SPI1_SSPIMSC_RXIM [2:2]     
       @ .equ SPI1_SSPIMSC_RTIM [1:1]     
       @ .equ SPI1_SSPIMSC_RORIM [0:0]     
 
    .equ SPI1_SSPRIS_OFFSET, 0x0018 
       @ .equ SPI1_SSPRIS_TXRIS [3:3]     
       @ .equ SPI1_SSPRIS_RXRIS [2:2]     
       @ .equ SPI1_SSPRIS_RTRIS [1:1]     
       @ .equ SPI1_SSPRIS_RORRIS [0:0]     
 
    .equ SPI1_SSPMIS_OFFSET, 0x001c 
       @ .equ SPI1_SSPMIS_TXMIS [3:3]     
       @ .equ SPI1_SSPMIS_RXMIS [2:2]     
       @ .equ SPI1_SSPMIS_RTMIS [1:1]     
       @ .equ SPI1_SSPMIS_RORMIS [0:0]     
 
    .equ SPI1_SSPICR_OFFSET, 0x0020 
       @ .equ SPI1_SSPICR_RTIC [1:1]     
       @ .equ SPI1_SSPICR_RORIC [0:0]     
 
    .equ SPI1_SSPDMACR_OFFSET, 0x0024 
       @ .equ SPI1_SSPDMACR_TXDMAE [1:1]     
       @ .equ SPI1_SSPDMACR_RXDMAE [0:0]     
 
    .equ SPI1_SSPPERIPHID0_OFFSET, 0x0fe0 
       @ .equ SPI1_SSPPERIPHID0_PARTNUMBER0 [7:0]     
 
    .equ SPI1_SSPPERIPHID1_OFFSET, 0x0fe4 
       @ .equ SPI1_SSPPERIPHID1_DESIGNER0 [7:4]     
       @ .equ SPI1_SSPPERIPHID1_PARTNUMBER1 [3:0]     
 
    .equ SPI1_SSPPERIPHID2_OFFSET, 0x0fe8 
       @ .equ SPI1_SSPPERIPHID2_REVISION [7:4]     
       @ .equ SPI1_SSPPERIPHID2_DESIGNER1 [3:0]     
 
    .equ SPI1_SSPPERIPHID3_OFFSET, 0x0fec 
       @ .equ SPI1_SSPPERIPHID3_CONFIGURATION [7:0]     
 
    .equ SPI1_SSPPCELLID0_OFFSET, 0x0ff0 
       @ .equ SPI1_SSPPCELLID0_SSPPCELLID0 [7:0]     
 
    .equ SPI1_SSPPCELLID1_OFFSET, 0x0ff4 
       @ .equ SPI1_SSPPCELLID1_SSPPCELLID1 [7:0]     
 
    .equ SPI1_SSPPCELLID2_OFFSET, 0x0ff8 
       @ .equ SPI1_SSPPCELLID2_SSPPCELLID2 [7:0]     
 
    .equ SPI1_SSPPCELLID3_OFFSET, 0x0ffc 
       @ .equ SPI1_SSPPCELLID3_SSPPCELLID3 [7:0]     
 

@=========================== I2C0 ===========================@
.equ I2C0_BASE, 0x40044000 
    .equ I2C0_IC_CON_OFFSET, 0x0000 
       @ .equ I2C0_IC_CON_STOP_DET_IF_MASTER_ACTIVE [10:10]     
       @ .equ I2C0_IC_CON_RX_FIFO_FULL_HLD_CTRL [9:9]     
       @ .equ I2C0_IC_CON_TX_EMPTY_CTRL [8:8]     
       @ .equ I2C0_IC_CON_STOP_DET_IFADDRESSED [7:7]     
       @ .equ I2C0_IC_CON_IC_SLAVE_DISABLE [6:6]     
       @ .equ I2C0_IC_CON_IC_RESTART_EN [5:5]     
       @ .equ I2C0_IC_CON_IC_10BITADDR_MASTER [4:4]     
       @ .equ I2C0_IC_CON_IC_10BITADDR_SLAVE [3:3]     
       @ .equ I2C0_IC_CON_SPEED [2:1]     
       @ .equ I2C0_IC_CON_MASTER_MODE [0:0]     
 
    .equ I2C0_IC_TAR_OFFSET, 0x0004 
       @ .equ I2C0_IC_TAR_SPECIAL [11:11]     
       @ .equ I2C0_IC_TAR_GC_OR_START [10:10]     
       @ .equ I2C0_IC_TAR_IC_TAR [9:0]     
 
    .equ I2C0_IC_SAR_OFFSET, 0x0008 
       @ .equ I2C0_IC_SAR_IC_SAR [9:0]     
 
    .equ I2C0_IC_DATA_CMD_OFFSET, 0x0010 
       @ .equ I2C0_IC_DATA_CMD_FIRST_DATA_BYTE [11:11]     
       @ .equ I2C0_IC_DATA_CMD_RESTART [10:10]     
       @ .equ I2C0_IC_DATA_CMD_STOP [9:9]     
       @ .equ I2C0_IC_DATA_CMD_CMD [8:8]     
       @ .equ I2C0_IC_DATA_CMD_DAT [7:0]     
 
    .equ I2C0_IC_SS_SCL_HCNT_OFFSET, 0x0014 
       @ .equ I2C0_IC_SS_SCL_HCNT_IC_SS_SCL_HCNT [15:0]     
 
    .equ I2C0_IC_SS_SCL_LCNT_OFFSET, 0x0018 
       @ .equ I2C0_IC_SS_SCL_LCNT_IC_SS_SCL_LCNT [15:0]     
 
    .equ I2C0_IC_FS_SCL_HCNT_OFFSET, 0x001c 
       @ .equ I2C0_IC_FS_SCL_HCNT_IC_FS_SCL_HCNT [15:0]     
 
    .equ I2C0_IC_FS_SCL_LCNT_OFFSET, 0x0020 
       @ .equ I2C0_IC_FS_SCL_LCNT_IC_FS_SCL_LCNT [15:0]     
 
    .equ I2C0_IC_INTR_STAT_OFFSET, 0x002c 
       @ .equ I2C0_IC_INTR_STAT_R_MASTER_ON_HOLD [13:13]     
       @ .equ I2C0_IC_INTR_STAT_R_RESTART_DET [12:12]     
       @ .equ I2C0_IC_INTR_STAT_R_GEN_CALL [11:11]     
       @ .equ I2C0_IC_INTR_STAT_R_START_DET [10:10]     
       @ .equ I2C0_IC_INTR_STAT_R_STOP_DET [9:9]     
       @ .equ I2C0_IC_INTR_STAT_R_ACTIVITY [8:8]     
       @ .equ I2C0_IC_INTR_STAT_R_RX_DONE [7:7]     
       @ .equ I2C0_IC_INTR_STAT_R_TX_ABRT [6:6]     
       @ .equ I2C0_IC_INTR_STAT_R_RD_REQ [5:5]     
       @ .equ I2C0_IC_INTR_STAT_R_TX_EMPTY [4:4]     
       @ .equ I2C0_IC_INTR_STAT_R_TX_OVER [3:3]     
       @ .equ I2C0_IC_INTR_STAT_R_RX_FULL [2:2]     
       @ .equ I2C0_IC_INTR_STAT_R_RX_OVER [1:1]     
       @ .equ I2C0_IC_INTR_STAT_R_RX_UNDER [0:0]     
 
    .equ I2C0_IC_INTR_MASK_OFFSET, 0x0030 
       @ .equ I2C0_IC_INTR_MASK_M_MASTER_ON_HOLD_READ_ONLY [13:13]     
       @ .equ I2C0_IC_INTR_MASK_M_RESTART_DET [12:12]     
       @ .equ I2C0_IC_INTR_MASK_M_GEN_CALL [11:11]     
       @ .equ I2C0_IC_INTR_MASK_M_START_DET [10:10]     
       @ .equ I2C0_IC_INTR_MASK_M_STOP_DET [9:9]     
       @ .equ I2C0_IC_INTR_MASK_M_ACTIVITY [8:8]     
       @ .equ I2C0_IC_INTR_MASK_M_RX_DONE [7:7]     
       @ .equ I2C0_IC_INTR_MASK_M_TX_ABRT [6:6]     
       @ .equ I2C0_IC_INTR_MASK_M_RD_REQ [5:5]     
       @ .equ I2C0_IC_INTR_MASK_M_TX_EMPTY [4:4]     
       @ .equ I2C0_IC_INTR_MASK_M_TX_OVER [3:3]     
       @ .equ I2C0_IC_INTR_MASK_M_RX_FULL [2:2]     
       @ .equ I2C0_IC_INTR_MASK_M_RX_OVER [1:1]     
       @ .equ I2C0_IC_INTR_MASK_M_RX_UNDER [0:0]     
 
    .equ I2C0_IC_RAW_INTR_STAT_OFFSET, 0x0034 
       @ .equ I2C0_IC_RAW_INTR_STAT_MASTER_ON_HOLD [13:13]     
       @ .equ I2C0_IC_RAW_INTR_STAT_RESTART_DET [12:12]     
       @ .equ I2C0_IC_RAW_INTR_STAT_GEN_CALL [11:11]     
       @ .equ I2C0_IC_RAW_INTR_STAT_START_DET [10:10]     
       @ .equ I2C0_IC_RAW_INTR_STAT_STOP_DET [9:9]     
       @ .equ I2C0_IC_RAW_INTR_STAT_ACTIVITY [8:8]     
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_DONE [7:7]     
       @ .equ I2C0_IC_RAW_INTR_STAT_TX_ABRT [6:6]     
       @ .equ I2C0_IC_RAW_INTR_STAT_RD_REQ [5:5]     
       @ .equ I2C0_IC_RAW_INTR_STAT_TX_EMPTY [4:4]     
       @ .equ I2C0_IC_RAW_INTR_STAT_TX_OVER [3:3]     
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_FULL [2:2]     
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_OVER [1:1]     
       @ .equ I2C0_IC_RAW_INTR_STAT_RX_UNDER [0:0]     
 
    .equ I2C0_IC_RX_TL_OFFSET, 0x0038 
       @ .equ I2C0_IC_RX_TL_RX_TL [7:0]     
 
    .equ I2C0_IC_TX_TL_OFFSET, 0x003c 
       @ .equ I2C0_IC_TX_TL_TX_TL [7:0]     
 
    .equ I2C0_IC_CLR_INTR_OFFSET, 0x0040 
       @ .equ I2C0_IC_CLR_INTR_CLR_INTR [0:0]     
 
    .equ I2C0_IC_CLR_RX_UNDER_OFFSET, 0x0044 
       @ .equ I2C0_IC_CLR_RX_UNDER_CLR_RX_UNDER [0:0]     
 
    .equ I2C0_IC_CLR_RX_OVER_OFFSET, 0x0048 
       @ .equ I2C0_IC_CLR_RX_OVER_CLR_RX_OVER [0:0]     
 
    .equ I2C0_IC_CLR_TX_OVER_OFFSET, 0x004c 
       @ .equ I2C0_IC_CLR_TX_OVER_CLR_TX_OVER [0:0]     
 
    .equ I2C0_IC_CLR_RD_REQ_OFFSET, 0x0050 
       @ .equ I2C0_IC_CLR_RD_REQ_CLR_RD_REQ [0:0]     
 
    .equ I2C0_IC_CLR_TX_ABRT_OFFSET, 0x0054 
       @ .equ I2C0_IC_CLR_TX_ABRT_CLR_TX_ABRT [0:0]     
 
    .equ I2C0_IC_CLR_RX_DONE_OFFSET, 0x0058 
       @ .equ I2C0_IC_CLR_RX_DONE_CLR_RX_DONE [0:0]     
 
    .equ I2C0_IC_CLR_ACTIVITY_OFFSET, 0x005c 
       @ .equ I2C0_IC_CLR_ACTIVITY_CLR_ACTIVITY [0:0]     
 
    .equ I2C0_IC_CLR_STOP_DET_OFFSET, 0x0060 
       @ .equ I2C0_IC_CLR_STOP_DET_CLR_STOP_DET [0:0]     
 
    .equ I2C0_IC_CLR_START_DET_OFFSET, 0x0064 
       @ .equ I2C0_IC_CLR_START_DET_CLR_START_DET [0:0]     
 
    .equ I2C0_IC_CLR_GEN_CALL_OFFSET, 0x0068 
       @ .equ I2C0_IC_CLR_GEN_CALL_CLR_GEN_CALL [0:0]     
 
    .equ I2C0_IC_ENABLE_OFFSET, 0x006c 
       @ .equ I2C0_IC_ENABLE_TX_CMD_BLOCK [2:2]     
       @ .equ I2C0_IC_ENABLE_ABORT [1:1]     
       @ .equ I2C0_IC_ENABLE_ENABLE [0:0]     
 
    .equ I2C0_IC_STATUS_OFFSET, 0x0070 
       @ .equ I2C0_IC_STATUS_SLV_ACTIVITY [6:6]     
       @ .equ I2C0_IC_STATUS_MST_ACTIVITY [5:5]     
       @ .equ I2C0_IC_STATUS_RFF [4:4]     
       @ .equ I2C0_IC_STATUS_RFNE [3:3]     
       @ .equ I2C0_IC_STATUS_TFE [2:2]     
       @ .equ I2C0_IC_STATUS_TFNF [1:1]     
       @ .equ I2C0_IC_STATUS_ACTIVITY [0:0]     
 
    .equ I2C0_IC_TXFLR_OFFSET, 0x0074 
       @ .equ I2C0_IC_TXFLR_TXFLR [4:0]     
 
    .equ I2C0_IC_RXFLR_OFFSET, 0x0078 
       @ .equ I2C0_IC_RXFLR_RXFLR [4:0]     
 
    .equ I2C0_IC_SDA_HOLD_OFFSET, 0x007c 
       @ .equ I2C0_IC_SDA_HOLD_IC_SDA_RX_HOLD [23:16]     
       @ .equ I2C0_IC_SDA_HOLD_IC_SDA_TX_HOLD [15:0]     
 
    .equ I2C0_IC_TX_ABRT_SOURCE_OFFSET, 0x0080 
       @ .equ I2C0_IC_TX_ABRT_SOURCE_TX_FLUSH_CNT [31:23]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_USER_ABRT [16:16]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SLVRD_INTX [15:15]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SLV_ARBLOST [14:14]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SLVFLUSH_TXFIFO [13:13]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ARB_LOST [12:12]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_MASTER_DIS [11:11]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_10B_RD_NORSTRT [10:10]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SBYTE_NORSTRT [9:9]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_HS_NORSTRT [8:8]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_SBYTE_ACKDET [7:7]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_HS_ACKDET [6:6]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_GCALL_READ [5:5]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_GCALL_NOACK [4:4]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_TXDATA_NOACK [3:3]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_10ADDR2_NOACK [2:2]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_10ADDR1_NOACK [1:1]     
       @ .equ I2C0_IC_TX_ABRT_SOURCE_ABRT_7B_ADDR_NOACK [0:0]     
 
    .equ I2C0_IC_SLV_DATA_NACK_ONLY_OFFSET, 0x0084 
       @ .equ I2C0_IC_SLV_DATA_NACK_ONLY_NACK [0:0]     
 
    .equ I2C0_IC_DMA_CR_OFFSET, 0x0088 
       @ .equ I2C0_IC_DMA_CR_TDMAE [1:1]     
       @ .equ I2C0_IC_DMA_CR_RDMAE [0:0]     
 
    .equ I2C0_IC_DMA_TDLR_OFFSET, 0x008c 
       @ .equ I2C0_IC_DMA_TDLR_DMATDL [3:0]     
 
    .equ I2C0_IC_DMA_RDLR_OFFSET, 0x0090 
       @ .equ I2C0_IC_DMA_RDLR_DMARDL [3:0]     
 
    .equ I2C0_IC_SDA_SETUP_OFFSET, 0x0094 
       @ .equ I2C0_IC_SDA_SETUP_SDA_SETUP [7:0]     
 
    .equ I2C0_IC_ACK_GENERAL_CALL_OFFSET, 0x0098 
       @ .equ I2C0_IC_ACK_GENERAL_CALL_ACK_GEN_CALL [0:0]     
 
    .equ I2C0_IC_ENABLE_STATUS_OFFSET, 0x009c 
       @ .equ I2C0_IC_ENABLE_STATUS_SLV_RX_DATA_LOST [2:2]     
       @ .equ I2C0_IC_ENABLE_STATUS_SLV_DISABLED_WHILE_BUSY [1:1]     
       @ .equ I2C0_IC_ENABLE_STATUS_IC_EN [0:0]     
 
    .equ I2C0_IC_FS_SPKLEN_OFFSET, 0x00a0 
       @ .equ I2C0_IC_FS_SPKLEN_IC_FS_SPKLEN [7:0]     
 
    .equ I2C0_IC_CLR_RESTART_DET_OFFSET, 0x00a8 
       @ .equ I2C0_IC_CLR_RESTART_DET_CLR_RESTART_DET [0:0]     
 
    .equ I2C0_IC_COMP_PARAM_1_OFFSET, 0x00f4 
       @ .equ I2C0_IC_COMP_PARAM_1_TX_BUFFER_DEPTH [23:16]     
       @ .equ I2C0_IC_COMP_PARAM_1_RX_BUFFER_DEPTH [15:8]     
       @ .equ I2C0_IC_COMP_PARAM_1_ADD_ENCODED_PARAMS [7:7]     
       @ .equ I2C0_IC_COMP_PARAM_1_HAS_DMA [6:6]     
       @ .equ I2C0_IC_COMP_PARAM_1_INTR_IO [5:5]     
       @ .equ I2C0_IC_COMP_PARAM_1_HC_COUNT_VALUES [4:4]     
       @ .equ I2C0_IC_COMP_PARAM_1_MAX_SPEED_MODE [3:2]     
       @ .equ I2C0_IC_COMP_PARAM_1_APB_DATA_WIDTH [1:0]     
 
    .equ I2C0_IC_COMP_VERSION_OFFSET, 0x00f8 
       @ .equ I2C0_IC_COMP_VERSION_IC_COMP_VERSION [31:0]     
 
    .equ I2C0_IC_COMP_TYPE_OFFSET, 0x00fc 
       @ .equ I2C0_IC_COMP_TYPE_IC_COMP_TYPE [31:0]     
 

@=========================== I2C1 ===========================@
.equ I2C1_BASE, 0x40048000 
    .equ I2C1_IC_CON_OFFSET, 0x0000 
       @ .equ I2C1_IC_CON_STOP_DET_IF_MASTER_ACTIVE [10:10]     
       @ .equ I2C1_IC_CON_RX_FIFO_FULL_HLD_CTRL [9:9]     
       @ .equ I2C1_IC_CON_TX_EMPTY_CTRL [8:8]     
       @ .equ I2C1_IC_CON_STOP_DET_IFADDRESSED [7:7]     
       @ .equ I2C1_IC_CON_IC_SLAVE_DISABLE [6:6]     
       @ .equ I2C1_IC_CON_IC_RESTART_EN [5:5]     
       @ .equ I2C1_IC_CON_IC_10BITADDR_MASTER [4:4]     
       @ .equ I2C1_IC_CON_IC_10BITADDR_SLAVE [3:3]     
       @ .equ I2C1_IC_CON_SPEED [2:1]     
       @ .equ I2C1_IC_CON_MASTER_MODE [0:0]     
 
    .equ I2C1_IC_TAR_OFFSET, 0x0004 
       @ .equ I2C1_IC_TAR_SPECIAL [11:11]     
       @ .equ I2C1_IC_TAR_GC_OR_START [10:10]     
       @ .equ I2C1_IC_TAR_IC_TAR [9:0]     
 
    .equ I2C1_IC_SAR_OFFSET, 0x0008 
       @ .equ I2C1_IC_SAR_IC_SAR [9:0]     
 
    .equ I2C1_IC_DATA_CMD_OFFSET, 0x0010 
       @ .equ I2C1_IC_DATA_CMD_FIRST_DATA_BYTE [11:11]     
       @ .equ I2C1_IC_DATA_CMD_RESTART [10:10]     
       @ .equ I2C1_IC_DATA_CMD_STOP [9:9]     
       @ .equ I2C1_IC_DATA_CMD_CMD [8:8]     
       @ .equ I2C1_IC_DATA_CMD_DAT [7:0]     
 
    .equ I2C1_IC_SS_SCL_HCNT_OFFSET, 0x0014 
       @ .equ I2C1_IC_SS_SCL_HCNT_IC_SS_SCL_HCNT [15:0]     
 
    .equ I2C1_IC_SS_SCL_LCNT_OFFSET, 0x0018 
       @ .equ I2C1_IC_SS_SCL_LCNT_IC_SS_SCL_LCNT [15:0]     
 
    .equ I2C1_IC_FS_SCL_HCNT_OFFSET, 0x001c 
       @ .equ I2C1_IC_FS_SCL_HCNT_IC_FS_SCL_HCNT [15:0]     
 
    .equ I2C1_IC_FS_SCL_LCNT_OFFSET, 0x0020 
       @ .equ I2C1_IC_FS_SCL_LCNT_IC_FS_SCL_LCNT [15:0]     
 
    .equ I2C1_IC_INTR_STAT_OFFSET, 0x002c 
       @ .equ I2C1_IC_INTR_STAT_R_MASTER_ON_HOLD [13:13]     
       @ .equ I2C1_IC_INTR_STAT_R_RESTART_DET [12:12]     
       @ .equ I2C1_IC_INTR_STAT_R_GEN_CALL [11:11]     
       @ .equ I2C1_IC_INTR_STAT_R_START_DET [10:10]     
       @ .equ I2C1_IC_INTR_STAT_R_STOP_DET [9:9]     
       @ .equ I2C1_IC_INTR_STAT_R_ACTIVITY [8:8]     
       @ .equ I2C1_IC_INTR_STAT_R_RX_DONE [7:7]     
       @ .equ I2C1_IC_INTR_STAT_R_TX_ABRT [6:6]     
       @ .equ I2C1_IC_INTR_STAT_R_RD_REQ [5:5]     
       @ .equ I2C1_IC_INTR_STAT_R_TX_EMPTY [4:4]     
       @ .equ I2C1_IC_INTR_STAT_R_TX_OVER [3:3]     
       @ .equ I2C1_IC_INTR_STAT_R_RX_FULL [2:2]     
       @ .equ I2C1_IC_INTR_STAT_R_RX_OVER [1:1]     
       @ .equ I2C1_IC_INTR_STAT_R_RX_UNDER [0:0]     
 
    .equ I2C1_IC_INTR_MASK_OFFSET, 0x0030 
       @ .equ I2C1_IC_INTR_MASK_M_MASTER_ON_HOLD_READ_ONLY [13:13]     
       @ .equ I2C1_IC_INTR_MASK_M_RESTART_DET [12:12]     
       @ .equ I2C1_IC_INTR_MASK_M_GEN_CALL [11:11]     
       @ .equ I2C1_IC_INTR_MASK_M_START_DET [10:10]     
       @ .equ I2C1_IC_INTR_MASK_M_STOP_DET [9:9]     
       @ .equ I2C1_IC_INTR_MASK_M_ACTIVITY [8:8]     
       @ .equ I2C1_IC_INTR_MASK_M_RX_DONE [7:7]     
       @ .equ I2C1_IC_INTR_MASK_M_TX_ABRT [6:6]     
       @ .equ I2C1_IC_INTR_MASK_M_RD_REQ [5:5]     
       @ .equ I2C1_IC_INTR_MASK_M_TX_EMPTY [4:4]     
       @ .equ I2C1_IC_INTR_MASK_M_TX_OVER [3:3]     
       @ .equ I2C1_IC_INTR_MASK_M_RX_FULL [2:2]     
       @ .equ I2C1_IC_INTR_MASK_M_RX_OVER [1:1]     
       @ .equ I2C1_IC_INTR_MASK_M_RX_UNDER [0:0]     
 
    .equ I2C1_IC_RAW_INTR_STAT_OFFSET, 0x0034 
       @ .equ I2C1_IC_RAW_INTR_STAT_MASTER_ON_HOLD [13:13]     
       @ .equ I2C1_IC_RAW_INTR_STAT_RESTART_DET [12:12]     
       @ .equ I2C1_IC_RAW_INTR_STAT_GEN_CALL [11:11]     
       @ .equ I2C1_IC_RAW_INTR_STAT_START_DET [10:10]     
       @ .equ I2C1_IC_RAW_INTR_STAT_STOP_DET [9:9]     
       @ .equ I2C1_IC_RAW_INTR_STAT_ACTIVITY [8:8]     
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_DONE [7:7]     
       @ .equ I2C1_IC_RAW_INTR_STAT_TX_ABRT [6:6]     
       @ .equ I2C1_IC_RAW_INTR_STAT_RD_REQ [5:5]     
       @ .equ I2C1_IC_RAW_INTR_STAT_TX_EMPTY [4:4]     
       @ .equ I2C1_IC_RAW_INTR_STAT_TX_OVER [3:3]     
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_FULL [2:2]     
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_OVER [1:1]     
       @ .equ I2C1_IC_RAW_INTR_STAT_RX_UNDER [0:0]     
 
    .equ I2C1_IC_RX_TL_OFFSET, 0x0038 
       @ .equ I2C1_IC_RX_TL_RX_TL [7:0]     
 
    .equ I2C1_IC_TX_TL_OFFSET, 0x003c 
       @ .equ I2C1_IC_TX_TL_TX_TL [7:0]     
 
    .equ I2C1_IC_CLR_INTR_OFFSET, 0x0040 
       @ .equ I2C1_IC_CLR_INTR_CLR_INTR [0:0]     
 
    .equ I2C1_IC_CLR_RX_UNDER_OFFSET, 0x0044 
       @ .equ I2C1_IC_CLR_RX_UNDER_CLR_RX_UNDER [0:0]     
 
    .equ I2C1_IC_CLR_RX_OVER_OFFSET, 0x0048 
       @ .equ I2C1_IC_CLR_RX_OVER_CLR_RX_OVER [0:0]     
 
    .equ I2C1_IC_CLR_TX_OVER_OFFSET, 0x004c 
       @ .equ I2C1_IC_CLR_TX_OVER_CLR_TX_OVER [0:0]     
 
    .equ I2C1_IC_CLR_RD_REQ_OFFSET, 0x0050 
       @ .equ I2C1_IC_CLR_RD_REQ_CLR_RD_REQ [0:0]     
 
    .equ I2C1_IC_CLR_TX_ABRT_OFFSET, 0x0054 
       @ .equ I2C1_IC_CLR_TX_ABRT_CLR_TX_ABRT [0:0]     
 
    .equ I2C1_IC_CLR_RX_DONE_OFFSET, 0x0058 
       @ .equ I2C1_IC_CLR_RX_DONE_CLR_RX_DONE [0:0]     
 
    .equ I2C1_IC_CLR_ACTIVITY_OFFSET, 0x005c 
       @ .equ I2C1_IC_CLR_ACTIVITY_CLR_ACTIVITY [0:0]     
 
    .equ I2C1_IC_CLR_STOP_DET_OFFSET, 0x0060 
       @ .equ I2C1_IC_CLR_STOP_DET_CLR_STOP_DET [0:0]     
 
    .equ I2C1_IC_CLR_START_DET_OFFSET, 0x0064 
       @ .equ I2C1_IC_CLR_START_DET_CLR_START_DET [0:0]     
 
    .equ I2C1_IC_CLR_GEN_CALL_OFFSET, 0x0068 
       @ .equ I2C1_IC_CLR_GEN_CALL_CLR_GEN_CALL [0:0]     
 
    .equ I2C1_IC_ENABLE_OFFSET, 0x006c 
       @ .equ I2C1_IC_ENABLE_TX_CMD_BLOCK [2:2]     
       @ .equ I2C1_IC_ENABLE_ABORT [1:1]     
       @ .equ I2C1_IC_ENABLE_ENABLE [0:0]     
 
    .equ I2C1_IC_STATUS_OFFSET, 0x0070 
       @ .equ I2C1_IC_STATUS_SLV_ACTIVITY [6:6]     
       @ .equ I2C1_IC_STATUS_MST_ACTIVITY [5:5]     
       @ .equ I2C1_IC_STATUS_RFF [4:4]     
       @ .equ I2C1_IC_STATUS_RFNE [3:3]     
       @ .equ I2C1_IC_STATUS_TFE [2:2]     
       @ .equ I2C1_IC_STATUS_TFNF [1:1]     
       @ .equ I2C1_IC_STATUS_ACTIVITY [0:0]     
 
    .equ I2C1_IC_TXFLR_OFFSET, 0x0074 
       @ .equ I2C1_IC_TXFLR_TXFLR [4:0]     
 
    .equ I2C1_IC_RXFLR_OFFSET, 0x0078 
       @ .equ I2C1_IC_RXFLR_RXFLR [4:0]     
 
    .equ I2C1_IC_SDA_HOLD_OFFSET, 0x007c 
       @ .equ I2C1_IC_SDA_HOLD_IC_SDA_RX_HOLD [23:16]     
       @ .equ I2C1_IC_SDA_HOLD_IC_SDA_TX_HOLD [15:0]     
 
    .equ I2C1_IC_TX_ABRT_SOURCE_OFFSET, 0x0080 
       @ .equ I2C1_IC_TX_ABRT_SOURCE_TX_FLUSH_CNT [31:23]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_USER_ABRT [16:16]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SLVRD_INTX [15:15]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SLV_ARBLOST [14:14]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SLVFLUSH_TXFIFO [13:13]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ARB_LOST [12:12]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_MASTER_DIS [11:11]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_10B_RD_NORSTRT [10:10]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SBYTE_NORSTRT [9:9]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_HS_NORSTRT [8:8]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_SBYTE_ACKDET [7:7]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_HS_ACKDET [6:6]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_GCALL_READ [5:5]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_GCALL_NOACK [4:4]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_TXDATA_NOACK [3:3]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_10ADDR2_NOACK [2:2]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_10ADDR1_NOACK [1:1]     
       @ .equ I2C1_IC_TX_ABRT_SOURCE_ABRT_7B_ADDR_NOACK [0:0]     
 
    .equ I2C1_IC_SLV_DATA_NACK_ONLY_OFFSET, 0x0084 
       @ .equ I2C1_IC_SLV_DATA_NACK_ONLY_NACK [0:0]     
 
    .equ I2C1_IC_DMA_CR_OFFSET, 0x0088 
       @ .equ I2C1_IC_DMA_CR_TDMAE [1:1]     
       @ .equ I2C1_IC_DMA_CR_RDMAE [0:0]     
 
    .equ I2C1_IC_DMA_TDLR_OFFSET, 0x008c 
       @ .equ I2C1_IC_DMA_TDLR_DMATDL [3:0]     
 
    .equ I2C1_IC_DMA_RDLR_OFFSET, 0x0090 
       @ .equ I2C1_IC_DMA_RDLR_DMARDL [3:0]     
 
    .equ I2C1_IC_SDA_SETUP_OFFSET, 0x0094 
       @ .equ I2C1_IC_SDA_SETUP_SDA_SETUP [7:0]     
 
    .equ I2C1_IC_ACK_GENERAL_CALL_OFFSET, 0x0098 
       @ .equ I2C1_IC_ACK_GENERAL_CALL_ACK_GEN_CALL [0:0]     
 
    .equ I2C1_IC_ENABLE_STATUS_OFFSET, 0x009c 
       @ .equ I2C1_IC_ENABLE_STATUS_SLV_RX_DATA_LOST [2:2]     
       @ .equ I2C1_IC_ENABLE_STATUS_SLV_DISABLED_WHILE_BUSY [1:1]     
       @ .equ I2C1_IC_ENABLE_STATUS_IC_EN [0:0]     
 
    .equ I2C1_IC_FS_SPKLEN_OFFSET, 0x00a0 
       @ .equ I2C1_IC_FS_SPKLEN_IC_FS_SPKLEN [7:0]     
 
    .equ I2C1_IC_CLR_RESTART_DET_OFFSET, 0x00a8 
       @ .equ I2C1_IC_CLR_RESTART_DET_CLR_RESTART_DET [0:0]     
 
    .equ I2C1_IC_COMP_PARAM_1_OFFSET, 0x00f4 
       @ .equ I2C1_IC_COMP_PARAM_1_TX_BUFFER_DEPTH [23:16]     
       @ .equ I2C1_IC_COMP_PARAM_1_RX_BUFFER_DEPTH [15:8]     
       @ .equ I2C1_IC_COMP_PARAM_1_ADD_ENCODED_PARAMS [7:7]     
       @ .equ I2C1_IC_COMP_PARAM_1_HAS_DMA [6:6]     
       @ .equ I2C1_IC_COMP_PARAM_1_INTR_IO [5:5]     
       @ .equ I2C1_IC_COMP_PARAM_1_HC_COUNT_VALUES [4:4]     
       @ .equ I2C1_IC_COMP_PARAM_1_MAX_SPEED_MODE [3:2]     
       @ .equ I2C1_IC_COMP_PARAM_1_APB_DATA_WIDTH [1:0]     
 
    .equ I2C1_IC_COMP_VERSION_OFFSET, 0x00f8 
       @ .equ I2C1_IC_COMP_VERSION_IC_COMP_VERSION [31:0]     
 
    .equ I2C1_IC_COMP_TYPE_OFFSET, 0x00fc 
       @ .equ I2C1_IC_COMP_TYPE_IC_COMP_TYPE [31:0]     
 

@=========================== ADC ===========================@
.equ ADC_BASE, 0x4004c000 
    .equ ADC_CS_OFFSET, 0x0000 
       @ .equ ADC_CS_RROBIN [20:16]     
       @ .equ ADC_CS_AINSEL [14:12]     
       @ .equ ADC_CS_ERR_STICKY [10:10]     
       @ .equ ADC_CS_ERR [9:9]     
       @ .equ ADC_CS_READY [8:8]     
       @ .equ ADC_CS_START_MANY [3:3]     
       @ .equ ADC_CS_START_ONCE [2:2]     
       @ .equ ADC_CS_TS_EN [1:1]     
       @ .equ ADC_CS_EN [0:0]     
 
    .equ ADC_RESULT_OFFSET, 0x0004 
       @ .equ ADC_RESULT_RESULT [11:0]     
 
    .equ ADC_FCS_OFFSET, 0x0008 
       @ .equ ADC_FCS_THRESH [27:24]     
       @ .equ ADC_FCS_LEVEL [19:16]     
       @ .equ ADC_FCS_OVER [11:11]     
       @ .equ ADC_FCS_UNDER [10:10]     
       @ .equ ADC_FCS_FULL [9:9]     
       @ .equ ADC_FCS_EMPTY [8:8]     
       @ .equ ADC_FCS_DREQ_EN [3:3]     
       @ .equ ADC_FCS_ERR [2:2]     
       @ .equ ADC_FCS_SHIFT [1:1]     
       @ .equ ADC_FCS_EN [0:0]     
 
    .equ ADC_FIFO_OFFSET, 0x000c 
       @ .equ ADC_FIFO_ERR [15:15]     
       @ .equ ADC_FIFO_VAL [11:0]     
 
    .equ ADC_DIV_OFFSET, 0x0010 
       @ .equ ADC_DIV_INT [23:8]     
       @ .equ ADC_DIV_FRAC [7:0]     
 
    .equ ADC_INTR_OFFSET, 0x0014 
       @ .equ ADC_INTR_FIFO [0:0]     
 
    .equ ADC_INTE_OFFSET, 0x0018 
       @ .equ ADC_INTE_FIFO [0:0]     
 
    .equ ADC_INTF_OFFSET, 0x001c 
       @ .equ ADC_INTF_FIFO [0:0]     
 
    .equ ADC_INTS_OFFSET, 0x0020 
       @ .equ ADC_INTS_FIFO [0:0]     
 

@=========================== PWM ===========================@
.equ PWM_BASE, 0x40050000 
    .equ PWM_CH0_CSR_OFFSET, 0x0000 
       @ .equ PWM_CH0_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH0_CSR_PH_RET [6:6]     
       @ .equ PWM_CH0_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH0_CSR_B_INV [3:3]     
       @ .equ PWM_CH0_CSR_A_INV [2:2]     
       @ .equ PWM_CH0_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH0_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH1_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH1_CSR_PH_RET [6:6]     
       @ .equ PWM_CH1_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH1_CSR_B_INV [3:3]     
       @ .equ PWM_CH1_CSR_A_INV [2:2]     
       @ .equ PWM_CH1_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH1_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH2_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH2_CSR_PH_RET [6:6]     
       @ .equ PWM_CH2_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH2_CSR_B_INV [3:3]     
       @ .equ PWM_CH2_CSR_A_INV [2:2]     
       @ .equ PWM_CH2_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH2_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH3_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH3_CSR_PH_RET [6:6]     
       @ .equ PWM_CH3_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH3_CSR_B_INV [3:3]     
       @ .equ PWM_CH3_CSR_A_INV [2:2]     
       @ .equ PWM_CH3_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH3_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH4_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH4_CSR_PH_RET [6:6]     
       @ .equ PWM_CH4_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH4_CSR_B_INV [3:3]     
       @ .equ PWM_CH4_CSR_A_INV [2:2]     
       @ .equ PWM_CH4_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH4_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH5_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH5_CSR_PH_RET [6:6]     
       @ .equ PWM_CH5_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH5_CSR_B_INV [3:3]     
       @ .equ PWM_CH5_CSR_A_INV [2:2]     
       @ .equ PWM_CH5_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH5_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH6_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH6_CSR_PH_RET [6:6]     
       @ .equ PWM_CH6_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH6_CSR_B_INV [3:3]     
       @ .equ PWM_CH6_CSR_A_INV [2:2]     
       @ .equ PWM_CH6_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH6_CSR_EN [0:0]     
 
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
       @ .equ PWM_CH7_CSR_PH_ADV [7:7]     
       @ .equ PWM_CH7_CSR_PH_RET [6:6]     
       @ .equ PWM_CH7_CSR_DIVMODE [5:4]     
       @ .equ PWM_CH7_CSR_B_INV [3:3]     
       @ .equ PWM_CH7_CSR_A_INV [2:2]     
       @ .equ PWM_CH7_CSR_PH_CORRECT [1:1]     
       @ .equ PWM_CH7_CSR_EN [0:0]     
 
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
       @ .equ TIMER_DBGPAUSE_DBG1 [2:2]     
       @ .equ TIMER_DBGPAUSE_DBG0 [1:1]     
 
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
       @ .equ WATCHDOG_CTRL_TRIGGER [31:31]     
       @ .equ WATCHDOG_CTRL_ENABLE [30:30]     
       @ .equ WATCHDOG_CTRL_PAUSE_DBG1 [26:26]     
       @ .equ WATCHDOG_CTRL_PAUSE_DBG0 [25:25]     
       @ .equ WATCHDOG_CTRL_PAUSE_JTAG [24:24]     
       @ .equ WATCHDOG_CTRL_TIME [23:0]     
 
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
       @ .equ WATCHDOG_TICK_COUNT [19:11]     
       @ .equ WATCHDOG_TICK_RUNNING [10:10]     
       @ .equ WATCHDOG_TICK_ENABLE [9:9]     
       @ .equ WATCHDOG_TICK_CYCLES [8:0]     
 

@=========================== RTC ===========================@
.equ RTC_BASE, 0x4005c000 
    .equ RTC_CLKDIV_M1_OFFSET, 0x0000 
       @ .equ RTC_CLKDIV_M1_CLKDIV_M1 [15:0]     
 
    .equ RTC_SETUP_0_OFFSET, 0x0004 
       @ .equ RTC_SETUP_0_YEAR [23:12]     
       @ .equ RTC_SETUP_0_MONTH [11:8]     
       @ .equ RTC_SETUP_0_DAY [4:0]     
 
    .equ RTC_SETUP_1_OFFSET, 0x0008 
       @ .equ RTC_SETUP_1_DOTW [26:24]     
       @ .equ RTC_SETUP_1_HOUR [20:16]     
       @ .equ RTC_SETUP_1_MIN [13:8]     
       @ .equ RTC_SETUP_1_SEC [5:0]     
 
    .equ RTC_CTRL_OFFSET, 0x000c 
       @ .equ RTC_CTRL_FORCE_NOTLEAPYEAR [8:8]     
       @ .equ RTC_CTRL_LOAD [4:4]     
       @ .equ RTC_CTRL_RTC_ACTIVE [1:1]     
       @ .equ RTC_CTRL_RTC_ENABLE [0:0]     
 
    .equ RTC_IRQ_SETUP_0_OFFSET, 0x0010 
       @ .equ RTC_IRQ_SETUP_0_MATCH_ACTIVE [29:29]     
       @ .equ RTC_IRQ_SETUP_0_MATCH_ENA [28:28]     
       @ .equ RTC_IRQ_SETUP_0_YEAR_ENA [26:26]     
       @ .equ RTC_IRQ_SETUP_0_MONTH_ENA [25:25]     
       @ .equ RTC_IRQ_SETUP_0_DAY_ENA [24:24]     
       @ .equ RTC_IRQ_SETUP_0_YEAR [23:12]     
       @ .equ RTC_IRQ_SETUP_0_MONTH [11:8]     
       @ .equ RTC_IRQ_SETUP_0_DAY [4:0]     
 
    .equ RTC_IRQ_SETUP_1_OFFSET, 0x0014 
       @ .equ RTC_IRQ_SETUP_1_DOTW_ENA [31:31]     
       @ .equ RTC_IRQ_SETUP_1_HOUR_ENA [30:30]     
       @ .equ RTC_IRQ_SETUP_1_MIN_ENA [29:29]     
       @ .equ RTC_IRQ_SETUP_1_SEC_ENA [28:28]     
       @ .equ RTC_IRQ_SETUP_1_DOTW [26:24]     
       @ .equ RTC_IRQ_SETUP_1_HOUR [20:16]     
       @ .equ RTC_IRQ_SETUP_1_MIN [13:8]     
       @ .equ RTC_IRQ_SETUP_1_SEC [5:0]     
 
    .equ RTC_RTC_1_OFFSET, 0x0018 
       @ .equ RTC_RTC_1_YEAR [23:12]     
       @ .equ RTC_RTC_1_MONTH [11:8]     
       @ .equ RTC_RTC_1_DAY [4:0]     
 
    .equ RTC_RTC_0_OFFSET, 0x001c 
       @ .equ RTC_RTC_0_DOTW [26:24]     
       @ .equ RTC_RTC_0_HOUR [20:16]     
       @ .equ RTC_RTC_0_MIN [13:8]     
       @ .equ RTC_RTC_0_SEC [5:0]     
 
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
       @ .equ ROSC_CTRL_ENABLE [23:12]     
       @ .equ ROSC_CTRL_FREQ_RANGE [11:0]     
 
    .equ ROSC_FREQA_OFFSET, 0x0004 
       @ .equ ROSC_FREQA_PASSWD [31:16]     
       @ .equ ROSC_FREQA_DS3 [14:12]     
       @ .equ ROSC_FREQA_DS2 [10:8]     
       @ .equ ROSC_FREQA_DS1 [6:4]     
       @ .equ ROSC_FREQA_DS0 [2:0]     
 
    .equ ROSC_FREQB_OFFSET, 0x0008 
       @ .equ ROSC_FREQB_PASSWD [31:16]     
       @ .equ ROSC_FREQB_DS7 [14:12]     
       @ .equ ROSC_FREQB_DS6 [10:8]     
       @ .equ ROSC_FREQB_DS5 [6:4]     
       @ .equ ROSC_FREQB_DS4 [2:0]     
 
    .equ ROSC_DORMANT_OFFSET, 0x000c 
 
    .equ ROSC_DIV_OFFSET, 0x0010 
       @ .equ ROSC_DIV_DIV [11:0]     
 
    .equ ROSC_PHASE_OFFSET, 0x0014 
       @ .equ ROSC_PHASE_PASSWD [11:4]     
       @ .equ ROSC_PHASE_ENABLE [3:3]     
       @ .equ ROSC_PHASE_FLIP [2:2]     
       @ .equ ROSC_PHASE_SHIFT [1:0]     
 
    .equ ROSC_STATUS_OFFSET, 0x0018 
       @ .equ ROSC_STATUS_STABLE [31:31]     
       @ .equ ROSC_STATUS_BADWRITE [24:24]     
       @ .equ ROSC_STATUS_DIV_RUNNING [16:16]     
       @ .equ ROSC_STATUS_ENABLED [12:12]     
 
    .equ ROSC_RANDOMBIT_OFFSET, 0x001c 
       @ .equ ROSC_RANDOMBIT_RANDOMBIT [0:0]     
 
    .equ ROSC_COUNT_OFFSET, 0x0020 
       @ .equ ROSC_COUNT_COUNT [7:0]     
 

@=========================== VREG_AND_CHIP_RESET ===========================@
.equ VREG_AND_CHIP_RESET_BASE, 0x40064000 
    .equ VREG_AND_CHIP_RESET_VREG_OFFSET, 0x0000 
       @ .equ VREG_AND_CHIP_RESET_VREG_ROK [12:12]     
       @ .equ VREG_AND_CHIP_RESET_VREG_VSEL [7:4]     
       @ .equ VREG_AND_CHIP_RESET_VREG_HIZ [1:1]     
       @ .equ VREG_AND_CHIP_RESET_VREG_EN [0:0]     
 
    .equ VREG_AND_CHIP_RESET_BOD_OFFSET, 0x0004 
       @ .equ VREG_AND_CHIP_RESET_BOD_VSEL [7:4]     
       @ .equ VREG_AND_CHIP_RESET_BOD_EN [0:0]     
 
    .equ VREG_AND_CHIP_RESET_CHIP_RESET_OFFSET, 0x0008 
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_PSM_RESTART_FLAG [24:24]     
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_HAD_PSM_RESTART [20:20]     
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_HAD_RUN [16:16]     
       @ .equ VREG_AND_CHIP_RESET_CHIP_RESET_HAD_POR [8:8]     
 

@=========================== TBMAN ===========================@
.equ TBMAN_BASE, 0x4006c000 
    .equ TBMAN_PLATFORM_OFFSET, 0x0000 
       @ .equ TBMAN_PLATFORM_FPGA [1:1]     
       @ .equ TBMAN_PLATFORM_ASIC [0:0]     
 

@=========================== DMA ===========================@
.equ DMA_BASE, 0x50000000 
    .equ DMA_CH0_READ_ADDR_OFFSET, 0x0000 
 
    .equ DMA_CH0_WRITE_ADDR_OFFSET, 0x0004 
 
    .equ DMA_CH0_TRANS_COUNT_OFFSET, 0x0008 
 
    .equ DMA_CH0_CTRL_TRIG_OFFSET, 0x000c 
       @ .equ DMA_CH0_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH0_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH0_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH0_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH0_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH0_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH0_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH0_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH0_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH0_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH0_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH0_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH0_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH0_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH0_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH0_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH1_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH1_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH1_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH1_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH1_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH1_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH1_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH1_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH1_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH1_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH1_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH1_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH1_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH1_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH1_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH1_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH2_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH2_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH2_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH2_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH2_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH2_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH2_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH2_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH2_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH2_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH2_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH2_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH2_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH2_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH2_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH2_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH3_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH3_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH3_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH3_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH3_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH3_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH3_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH3_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH3_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH3_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH3_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH3_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH3_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH3_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH3_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH3_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH4_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH4_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH4_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH4_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH4_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH4_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH4_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH4_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH4_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH4_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH4_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH4_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH4_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH4_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH4_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH4_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH5_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH5_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH5_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH5_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH5_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH5_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH5_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH5_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH5_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH5_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH5_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH5_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH5_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH5_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH5_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH5_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH6_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH6_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH6_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH6_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH6_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH6_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH6_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH6_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH6_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH6_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH6_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH6_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH6_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH6_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH6_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH6_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH7_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH7_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH7_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH7_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH7_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH7_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH7_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH7_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH7_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH7_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH7_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH7_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH7_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH7_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH7_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH7_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH8_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH8_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH8_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH8_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH8_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH8_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH8_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH8_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH8_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH8_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH8_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH8_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH8_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH8_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH8_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH8_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH9_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH9_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH9_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH9_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH9_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH9_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH9_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH9_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH9_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH9_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH9_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH9_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH9_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH9_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH9_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH9_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH10_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH10_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH10_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH10_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH10_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH10_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH10_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH10_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH10_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH10_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH10_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH10_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH10_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH10_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH10_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH10_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_CH11_CTRL_TRIG_AHB_ERROR [31:31]     
       @ .equ DMA_CH11_CTRL_TRIG_READ_ERROR [30:30]     
       @ .equ DMA_CH11_CTRL_TRIG_WRITE_ERROR [29:29]     
       @ .equ DMA_CH11_CTRL_TRIG_BUSY [24:24]     
       @ .equ DMA_CH11_CTRL_TRIG_SNIFF_EN [23:23]     
       @ .equ DMA_CH11_CTRL_TRIG_BSWAP [22:22]     
       @ .equ DMA_CH11_CTRL_TRIG_IRQ_QUIET [21:21]     
       @ .equ DMA_CH11_CTRL_TRIG_TREQ_SEL [20:15]     
       @ .equ DMA_CH11_CTRL_TRIG_CHAIN_TO [14:11]     
       @ .equ DMA_CH11_CTRL_TRIG_RING_SEL [10:10]     
       @ .equ DMA_CH11_CTRL_TRIG_RING_SIZE [9:6]     
       @ .equ DMA_CH11_CTRL_TRIG_INCR_WRITE [5:5]     
       @ .equ DMA_CH11_CTRL_TRIG_INCR_READ [4:4]     
       @ .equ DMA_CH11_CTRL_TRIG_DATA_SIZE [3:2]     
       @ .equ DMA_CH11_CTRL_TRIG_HIGH_PRIORITY [1:1]     
       @ .equ DMA_CH11_CTRL_TRIG_EN [0:0]     
 
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
       @ .equ DMA_INTR_INTR [15:0]     
 
    .equ DMA_INTE0_OFFSET, 0x0404 
       @ .equ DMA_INTE0_INTE0 [15:0]     
 
    .equ DMA_INTF0_OFFSET, 0x0408 
       @ .equ DMA_INTF0_INTF0 [15:0]     
 
    .equ DMA_INTS0_OFFSET, 0x040c 
       @ .equ DMA_INTS0_INTS0 [15:0]     
 
    .equ DMA_INTE1_OFFSET, 0x0414 
       @ .equ DMA_INTE1_INTE1 [15:0]     
 
    .equ DMA_INTF1_OFFSET, 0x0418 
       @ .equ DMA_INTF1_INTF1 [15:0]     
 
    .equ DMA_INTS1_OFFSET, 0x041c 
       @ .equ DMA_INTS1_INTS1 [15:0]     
 
    .equ DMA_TIMER0_OFFSET, 0x0420 
       @ .equ DMA_TIMER0_X [31:16]     
       @ .equ DMA_TIMER0_Y [15:0]     
 
    .equ DMA_TIMER1_OFFSET, 0x0424 
       @ .equ DMA_TIMER1_X [31:16]     
       @ .equ DMA_TIMER1_Y [15:0]     
 
    .equ DMA_MULTI_CHAN_TRIGGER_OFFSET, 0x0430 
       @ .equ DMA_MULTI_CHAN_TRIGGER_MULTI_CHAN_TRIGGER [15:0]     
 
    .equ DMA_SNIFF_CTRL_OFFSET, 0x0434 
       @ .equ DMA_SNIFF_CTRL_OUT_INV [11:11]     
       @ .equ DMA_SNIFF_CTRL_OUT_REV [10:10]     
       @ .equ DMA_SNIFF_CTRL_BSWAP [9:9]     
       @ .equ DMA_SNIFF_CTRL_CALC [8:5]     
       @ .equ DMA_SNIFF_CTRL_DMACH [4:1]     
       @ .equ DMA_SNIFF_CTRL_EN [0:0]     
 
    .equ DMA_SNIFF_DATA_OFFSET, 0x0438 
 
    .equ DMA_FIFO_LEVELS_OFFSET, 0x0440 
       @ .equ DMA_FIFO_LEVELS_RAF_LVL [23:16]     
       @ .equ DMA_FIFO_LEVELS_WAF_LVL [15:8]     
       @ .equ DMA_FIFO_LEVELS_TDF_LVL [7:0]     
 
    .equ DMA_CHAN_ABORT_OFFSET, 0x0444 
       @ .equ DMA_CHAN_ABORT_CHAN_ABORT [15:0]     
 
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
       @ .equ USBCTRL_REGS_ADDR_ENDP_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP1_OFFSET, 0x0004 
       @ .equ USBCTRL_REGS_ADDR_ENDP1_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP1_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP1_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP1_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP2_OFFSET, 0x0008 
       @ .equ USBCTRL_REGS_ADDR_ENDP2_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP2_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP2_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP2_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP3_OFFSET, 0x000c 
       @ .equ USBCTRL_REGS_ADDR_ENDP3_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP3_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP3_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP3_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP4_OFFSET, 0x0010 
       @ .equ USBCTRL_REGS_ADDR_ENDP4_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP4_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP4_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP4_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP5_OFFSET, 0x0014 
       @ .equ USBCTRL_REGS_ADDR_ENDP5_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP5_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP5_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP5_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP6_OFFSET, 0x0018 
       @ .equ USBCTRL_REGS_ADDR_ENDP6_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP6_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP6_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP6_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP7_OFFSET, 0x001c 
       @ .equ USBCTRL_REGS_ADDR_ENDP7_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP7_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP7_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP7_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP8_OFFSET, 0x0020 
       @ .equ USBCTRL_REGS_ADDR_ENDP8_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP8_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP8_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP8_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP9_OFFSET, 0x0024 
       @ .equ USBCTRL_REGS_ADDR_ENDP9_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP9_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP9_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP9_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP10_OFFSET, 0x0028 
       @ .equ USBCTRL_REGS_ADDR_ENDP10_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP10_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP10_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP10_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP11_OFFSET, 0x002c 
       @ .equ USBCTRL_REGS_ADDR_ENDP11_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP11_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP11_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP11_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP12_OFFSET, 0x0030 
       @ .equ USBCTRL_REGS_ADDR_ENDP12_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP12_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP12_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP12_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP13_OFFSET, 0x0034 
       @ .equ USBCTRL_REGS_ADDR_ENDP13_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP13_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP13_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP13_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP14_OFFSET, 0x0038 
       @ .equ USBCTRL_REGS_ADDR_ENDP14_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP14_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP14_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP14_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_ADDR_ENDP15_OFFSET, 0x003c 
       @ .equ USBCTRL_REGS_ADDR_ENDP15_INTEP_PREAMBLE [26:26]     
       @ .equ USBCTRL_REGS_ADDR_ENDP15_INTEP_DIR [25:25]     
       @ .equ USBCTRL_REGS_ADDR_ENDP15_ENDPOINT [19:16]     
       @ .equ USBCTRL_REGS_ADDR_ENDP15_ADDRESS [6:0]     
 
    .equ USBCTRL_REGS_MAIN_CTRL_OFFSET, 0x0040 
       @ .equ USBCTRL_REGS_MAIN_CTRL_SIM_TIMING [31:31]     
       @ .equ USBCTRL_REGS_MAIN_CTRL_HOST_NDEVICE [1:1]     
       @ .equ USBCTRL_REGS_MAIN_CTRL_CONTROLLER_EN [0:0]     
 
    .equ USBCTRL_REGS_SOF_WR_OFFSET, 0x0044 
       @ .equ USBCTRL_REGS_SOF_WR_COUNT [10:0]     
 
    .equ USBCTRL_REGS_SOF_RD_OFFSET, 0x0048 
       @ .equ USBCTRL_REGS_SOF_RD_COUNT [10:0]     
 
    .equ USBCTRL_REGS_SIE_CTRL_OFFSET, 0x004c 
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_STALL [31:31]     
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_DOUBLE_BUF [30:30]     
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_1BUF [29:29]     
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_2BUF [28:28]     
       @ .equ USBCTRL_REGS_SIE_CTRL_EP0_INT_NAK [27:27]     
       @ .equ USBCTRL_REGS_SIE_CTRL_DIRECT_EN [26:26]     
       @ .equ USBCTRL_REGS_SIE_CTRL_DIRECT_DP [25:25]     
       @ .equ USBCTRL_REGS_SIE_CTRL_DIRECT_DM [24:24]     
       @ .equ USBCTRL_REGS_SIE_CTRL_TRANSCEIVER_PD [18:18]     
       @ .equ USBCTRL_REGS_SIE_CTRL_RPU_OPT [17:17]     
       @ .equ USBCTRL_REGS_SIE_CTRL_PULLUP_EN [16:16]     
       @ .equ USBCTRL_REGS_SIE_CTRL_PULLDOWN_EN [15:15]     
       @ .equ USBCTRL_REGS_SIE_CTRL_RESET_BUS [13:13]     
       @ .equ USBCTRL_REGS_SIE_CTRL_RESUME [12:12]     
       @ .equ USBCTRL_REGS_SIE_CTRL_VBUS_EN [11:11]     
       @ .equ USBCTRL_REGS_SIE_CTRL_KEEP_ALIVE_EN [10:10]     
       @ .equ USBCTRL_REGS_SIE_CTRL_SOF_EN [9:9]     
       @ .equ USBCTRL_REGS_SIE_CTRL_SOF_SYNC [8:8]     
       @ .equ USBCTRL_REGS_SIE_CTRL_PREAMBLE_EN [6:6]     
       @ .equ USBCTRL_REGS_SIE_CTRL_STOP_TRANS [4:4]     
       @ .equ USBCTRL_REGS_SIE_CTRL_RECEIVE_DATA [3:3]     
       @ .equ USBCTRL_REGS_SIE_CTRL_SEND_DATA [2:2]     
       @ .equ USBCTRL_REGS_SIE_CTRL_SEND_SETUP [1:1]     
       @ .equ USBCTRL_REGS_SIE_CTRL_START_TRANS [0:0]     
 
    .equ USBCTRL_REGS_SIE_STATUS_OFFSET, 0x0050 
       @ .equ USBCTRL_REGS_SIE_STATUS_DATA_SEQ_ERROR [31:31]     
       @ .equ USBCTRL_REGS_SIE_STATUS_ACK_REC [30:30]     
       @ .equ USBCTRL_REGS_SIE_STATUS_STALL_REC [29:29]     
       @ .equ USBCTRL_REGS_SIE_STATUS_NAK_REC [28:28]     
       @ .equ USBCTRL_REGS_SIE_STATUS_RX_TIMEOUT [27:27]     
       @ .equ USBCTRL_REGS_SIE_STATUS_RX_OVERFLOW [26:26]     
       @ .equ USBCTRL_REGS_SIE_STATUS_BIT_STUFF_ERROR [25:25]     
       @ .equ USBCTRL_REGS_SIE_STATUS_CRC_ERROR [24:24]     
       @ .equ USBCTRL_REGS_SIE_STATUS_BUS_RESET [19:19]     
       @ .equ USBCTRL_REGS_SIE_STATUS_TRANS_COMPLETE [18:18]     
       @ .equ USBCTRL_REGS_SIE_STATUS_SETUP_REC [17:17]     
       @ .equ USBCTRL_REGS_SIE_STATUS_CONNECTED [16:16]     
       @ .equ USBCTRL_REGS_SIE_STATUS_RESUME [11:11]     
       @ .equ USBCTRL_REGS_SIE_STATUS_VBUS_OVER_CURR [10:10]     
       @ .equ USBCTRL_REGS_SIE_STATUS_SPEED [9:8]     
       @ .equ USBCTRL_REGS_SIE_STATUS_SUSPENDED [4:4]     
       @ .equ USBCTRL_REGS_SIE_STATUS_LINE_STATE [3:2]     
       @ .equ USBCTRL_REGS_SIE_STATUS_VBUS_DETECTED [0:0]     
 
    .equ USBCTRL_REGS_INT_EP_CTRL_OFFSET, 0x0054 
       @ .equ USBCTRL_REGS_INT_EP_CTRL_INT_EP_ACTIVE [15:1]     
 
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
       @ .equ USBCTRL_REGS_NAK_POLL_DELAY_FS [25:16]     
       @ .equ USBCTRL_REGS_NAK_POLL_DELAY_LS [9:0]     
 
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
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_OVV [22:22]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_OVV [21:21]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_OVCN [20:20]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_OVCN [19:19]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_DM [18:18]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_DP [17:17]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_DD [16:16]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DIFFMODE [15:15]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_FSSLEW [14:14]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_PD [13:13]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_RX_PD [12:12]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DM [11:11]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DP [10:10]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DM_OE [9:9]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_TX_DP_OE [8:8]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_PULLDN_EN [6:6]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_PULLUP_EN [5:5]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DM_PULLUP_HISEL [4:4]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_PULLDN_EN [2:2]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_PULLUP_EN [1:1]     
       @ .equ USBCTRL_REGS_USBPHY_DIRECT_DP_PULLUP_HISEL [0:0]     
 
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
       @ .equ USBCTRL_REGS_USBPHY_TRIM_DM_PULLDN_TRIM [12:8]     
       @ .equ USBCTRL_REGS_USBPHY_TRIM_DP_PULLDN_TRIM [4:0]     
 
    .equ USBCTRL_REGS_INTR_OFFSET, 0x008c 
       @ .equ USBCTRL_REGS_INTR_EP_STALL_NAK [19:19]     
       @ .equ USBCTRL_REGS_INTR_ABORT_DONE [18:18]     
       @ .equ USBCTRL_REGS_INTR_DEV_SOF [17:17]     
       @ .equ USBCTRL_REGS_INTR_SETUP_REQ [16:16]     
       @ .equ USBCTRL_REGS_INTR_DEV_RESUME_FROM_HOST [15:15]     
       @ .equ USBCTRL_REGS_INTR_DEV_SUSPEND [14:14]     
       @ .equ USBCTRL_REGS_INTR_DEV_CONN_DIS [13:13]     
       @ .equ USBCTRL_REGS_INTR_BUS_RESET [12:12]     
       @ .equ USBCTRL_REGS_INTR_VBUS_DETECT [11:11]     
       @ .equ USBCTRL_REGS_INTR_STALL [10:10]     
       @ .equ USBCTRL_REGS_INTR_ERROR_CRC [9:9]     
       @ .equ USBCTRL_REGS_INTR_ERROR_BIT_STUFF [8:8]     
       @ .equ USBCTRL_REGS_INTR_ERROR_RX_OVERFLOW [7:7]     
       @ .equ USBCTRL_REGS_INTR_ERROR_RX_TIMEOUT [6:6]     
       @ .equ USBCTRL_REGS_INTR_ERROR_DATA_SEQ [5:5]     
       @ .equ USBCTRL_REGS_INTR_BUFF_STATUS [4:4]     
       @ .equ USBCTRL_REGS_INTR_TRANS_COMPLETE [3:3]     
       @ .equ USBCTRL_REGS_INTR_HOST_SOF [2:2]     
       @ .equ USBCTRL_REGS_INTR_HOST_RESUME [1:1]     
       @ .equ USBCTRL_REGS_INTR_HOST_CONN_DIS [0:0]     
 
    .equ USBCTRL_REGS_INTE_OFFSET, 0x0090 
       @ .equ USBCTRL_REGS_INTE_EP_STALL_NAK [19:19]     
       @ .equ USBCTRL_REGS_INTE_ABORT_DONE [18:18]     
       @ .equ USBCTRL_REGS_INTE_DEV_SOF [17:17]     
       @ .equ USBCTRL_REGS_INTE_SETUP_REQ [16:16]     
       @ .equ USBCTRL_REGS_INTE_DEV_RESUME_FROM_HOST [15:15]     
       @ .equ USBCTRL_REGS_INTE_DEV_SUSPEND [14:14]     
       @ .equ USBCTRL_REGS_INTE_DEV_CONN_DIS [13:13]     
       @ .equ USBCTRL_REGS_INTE_BUS_RESET [12:12]     
       @ .equ USBCTRL_REGS_INTE_VBUS_DETECT [11:11]     
       @ .equ USBCTRL_REGS_INTE_STALL [10:10]     
       @ .equ USBCTRL_REGS_INTE_ERROR_CRC [9:9]     
       @ .equ USBCTRL_REGS_INTE_ERROR_BIT_STUFF [8:8]     
       @ .equ USBCTRL_REGS_INTE_ERROR_RX_OVERFLOW [7:7]     
       @ .equ USBCTRL_REGS_INTE_ERROR_RX_TIMEOUT [6:6]     
       @ .equ USBCTRL_REGS_INTE_ERROR_DATA_SEQ [5:5]     
       @ .equ USBCTRL_REGS_INTE_BUFF_STATUS [4:4]     
       @ .equ USBCTRL_REGS_INTE_TRANS_COMPLETE [3:3]     
       @ .equ USBCTRL_REGS_INTE_HOST_SOF [2:2]     
       @ .equ USBCTRL_REGS_INTE_HOST_RESUME [1:1]     
       @ .equ USBCTRL_REGS_INTE_HOST_CONN_DIS [0:0]     
 
    .equ USBCTRL_REGS_INTF_OFFSET, 0x0094 
       @ .equ USBCTRL_REGS_INTF_EP_STALL_NAK [19:19]     
       @ .equ USBCTRL_REGS_INTF_ABORT_DONE [18:18]     
       @ .equ USBCTRL_REGS_INTF_DEV_SOF [17:17]     
       @ .equ USBCTRL_REGS_INTF_SETUP_REQ [16:16]     
       @ .equ USBCTRL_REGS_INTF_DEV_RESUME_FROM_HOST [15:15]     
       @ .equ USBCTRL_REGS_INTF_DEV_SUSPEND [14:14]     
       @ .equ USBCTRL_REGS_INTF_DEV_CONN_DIS [13:13]     
       @ .equ USBCTRL_REGS_INTF_BUS_RESET [12:12]     
       @ .equ USBCTRL_REGS_INTF_VBUS_DETECT [11:11]     
       @ .equ USBCTRL_REGS_INTF_STALL [10:10]     
       @ .equ USBCTRL_REGS_INTF_ERROR_CRC [9:9]     
       @ .equ USBCTRL_REGS_INTF_ERROR_BIT_STUFF [8:8]     
       @ .equ USBCTRL_REGS_INTF_ERROR_RX_OVERFLOW [7:7]     
       @ .equ USBCTRL_REGS_INTF_ERROR_RX_TIMEOUT [6:6]     
       @ .equ USBCTRL_REGS_INTF_ERROR_DATA_SEQ [5:5]     
       @ .equ USBCTRL_REGS_INTF_BUFF_STATUS [4:4]     
       @ .equ USBCTRL_REGS_INTF_TRANS_COMPLETE [3:3]     
       @ .equ USBCTRL_REGS_INTF_HOST_SOF [2:2]     
       @ .equ USBCTRL_REGS_INTF_HOST_RESUME [1:1]     
       @ .equ USBCTRL_REGS_INTF_HOST_CONN_DIS [0:0]     
 
    .equ USBCTRL_REGS_INTS_OFFSET, 0x0098 
       @ .equ USBCTRL_REGS_INTS_EP_STALL_NAK [19:19]     
       @ .equ USBCTRL_REGS_INTS_ABORT_DONE [18:18]     
       @ .equ USBCTRL_REGS_INTS_DEV_SOF [17:17]     
       @ .equ USBCTRL_REGS_INTS_SETUP_REQ [16:16]     
       @ .equ USBCTRL_REGS_INTS_DEV_RESUME_FROM_HOST [15:15]     
       @ .equ USBCTRL_REGS_INTS_DEV_SUSPEND [14:14]     
       @ .equ USBCTRL_REGS_INTS_DEV_CONN_DIS [13:13]     
       @ .equ USBCTRL_REGS_INTS_BUS_RESET [12:12]     
       @ .equ USBCTRL_REGS_INTS_VBUS_DETECT [11:11]     
       @ .equ USBCTRL_REGS_INTS_STALL [10:10]     
       @ .equ USBCTRL_REGS_INTS_ERROR_CRC [9:9]     
       @ .equ USBCTRL_REGS_INTS_ERROR_BIT_STUFF [8:8]     
       @ .equ USBCTRL_REGS_INTS_ERROR_RX_OVERFLOW [7:7]     
       @ .equ USBCTRL_REGS_INTS_ERROR_RX_TIMEOUT [6:6]     
       @ .equ USBCTRL_REGS_INTS_ERROR_DATA_SEQ [5:5]     
       @ .equ USBCTRL_REGS_INTS_BUFF_STATUS [4:4]     
       @ .equ USBCTRL_REGS_INTS_TRANS_COMPLETE [3:3]     
       @ .equ USBCTRL_REGS_INTS_HOST_SOF [2:2]     
       @ .equ USBCTRL_REGS_INTS_HOST_RESUME [1:1]     
       @ .equ USBCTRL_REGS_INTS_HOST_CONN_DIS [0:0]     
 

@=========================== PIO0 ===========================@
.equ PIO0_BASE, 0x50200000 
    .equ PIO0_CTRL_OFFSET, 0x0000 
       @ .equ PIO0_CTRL_CLKDIV_RESTART [11:8]     
       @ .equ PIO0_CTRL_SM_RESTART [7:4]     
       @ .equ PIO0_CTRL_SM_ENABLE [3:0]     
 
    .equ PIO0_FSTAT_OFFSET, 0x0004 
       @ .equ PIO0_FSTAT_TXEMPTY [27:24]     
       @ .equ PIO0_FSTAT_TXFULL [19:16]     
       @ .equ PIO0_FSTAT_RXEMPTY [11:8]     
       @ .equ PIO0_FSTAT_RXFULL [3:0]     
 
    .equ PIO0_FDEBUG_OFFSET, 0x0008 
       @ .equ PIO0_FDEBUG_TXSTALL [27:24]     
       @ .equ PIO0_FDEBUG_TXOVER [19:16]     
       @ .equ PIO0_FDEBUG_RXUNDER [11:8]     
       @ .equ PIO0_FDEBUG_RXSTALL [3:0]     
 
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
       @ .equ PIO0_DBG_CFGINFO_IMEM_SIZE [21:16]     
       @ .equ PIO0_DBG_CFGINFO_SM_COUNT [11:8]     
       @ .equ PIO0_DBG_CFGINFO_FIFO_DEPTH [5:0]     
 
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
       @ .equ PIO0_SM0_CLKDIV_INT [31:16]     
       @ .equ PIO0_SM0_CLKDIV_FRAC [15:8]     
 
    .equ PIO0_SM0_EXECCTRL_OFFSET, 0x00cc 
       @ .equ PIO0_SM0_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO0_SM0_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO0_SM0_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO0_SM0_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO0_SM0_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO0_SM0_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO0_SM0_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO0_SM0_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO0_SM0_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO0_SM0_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO0_SM0_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO0_SM0_SHIFTCTRL_OFFSET, 0x00d0 
       @ .equ PIO0_SM0_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO0_SM0_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO0_SM0_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO0_SM0_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO0_SM0_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO0_SM0_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO0_SM0_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO0_SM0_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO0_SM0_ADDR_OFFSET, 0x00d4 
       @ .equ PIO0_SM0_ADDR_SM0_ADDR [4:0]     
 
    .equ PIO0_SM0_INSTR_OFFSET, 0x00d8 
       @ .equ PIO0_SM0_INSTR_SM0_INSTR [15:0]     
 
    .equ PIO0_SM0_PINCTRL_OFFSET, 0x00dc 
       @ .equ PIO0_SM0_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO0_SM0_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO0_SM0_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO0_SM0_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO0_SM0_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO0_SM0_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO0_SM0_PINCTRL_OUT_BASE [4:0]     
 
    .equ PIO0_SM1_CLKDIV_OFFSET, 0x00e0 
       @ .equ PIO0_SM1_CLKDIV_INT [31:16]     
       @ .equ PIO0_SM1_CLKDIV_FRAC [15:8]     
 
    .equ PIO0_SM1_EXECCTRL_OFFSET, 0x00e4 
       @ .equ PIO0_SM1_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO0_SM1_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO0_SM1_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO0_SM1_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO0_SM1_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO0_SM1_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO0_SM1_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO0_SM1_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO0_SM1_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO0_SM1_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO0_SM1_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO0_SM1_SHIFTCTRL_OFFSET, 0x00e8 
       @ .equ PIO0_SM1_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO0_SM1_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO0_SM1_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO0_SM1_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO0_SM1_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO0_SM1_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO0_SM1_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO0_SM1_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO0_SM1_ADDR_OFFSET, 0x00ec 
       @ .equ PIO0_SM1_ADDR_SM1_ADDR [4:0]     
 
    .equ PIO0_SM1_INSTR_OFFSET, 0x00f0 
       @ .equ PIO0_SM1_INSTR_SM1_INSTR [15:0]     
 
    .equ PIO0_SM1_PINCTRL_OFFSET, 0x00f4 
       @ .equ PIO0_SM1_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO0_SM1_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO0_SM1_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO0_SM1_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO0_SM1_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO0_SM1_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO0_SM1_PINCTRL_OUT_BASE [4:0]     
 
    .equ PIO0_SM2_CLKDIV_OFFSET, 0x00f8 
       @ .equ PIO0_SM2_CLKDIV_INT [31:16]     
       @ .equ PIO0_SM2_CLKDIV_FRAC [15:8]     
 
    .equ PIO0_SM2_EXECCTRL_OFFSET, 0x00fc 
       @ .equ PIO0_SM2_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO0_SM2_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO0_SM2_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO0_SM2_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO0_SM2_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO0_SM2_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO0_SM2_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO0_SM2_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO0_SM2_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO0_SM2_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO0_SM2_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO0_SM2_SHIFTCTRL_OFFSET, 0x0100 
       @ .equ PIO0_SM2_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO0_SM2_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO0_SM2_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO0_SM2_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO0_SM2_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO0_SM2_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO0_SM2_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO0_SM2_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO0_SM2_ADDR_OFFSET, 0x0104 
       @ .equ PIO0_SM2_ADDR_SM2_ADDR [4:0]     
 
    .equ PIO0_SM2_INSTR_OFFSET, 0x0108 
       @ .equ PIO0_SM2_INSTR_SM2_INSTR [15:0]     
 
    .equ PIO0_SM2_PINCTRL_OFFSET, 0x010c 
       @ .equ PIO0_SM2_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO0_SM2_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO0_SM2_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO0_SM2_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO0_SM2_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO0_SM2_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO0_SM2_PINCTRL_OUT_BASE [4:0]     
 
    .equ PIO0_SM3_CLKDIV_OFFSET, 0x0110 
       @ .equ PIO0_SM3_CLKDIV_INT [31:16]     
       @ .equ PIO0_SM3_CLKDIV_FRAC [15:8]     
 
    .equ PIO0_SM3_EXECCTRL_OFFSET, 0x0114 
       @ .equ PIO0_SM3_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO0_SM3_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO0_SM3_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO0_SM3_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO0_SM3_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO0_SM3_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO0_SM3_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO0_SM3_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO0_SM3_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO0_SM3_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO0_SM3_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO0_SM3_SHIFTCTRL_OFFSET, 0x0118 
       @ .equ PIO0_SM3_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO0_SM3_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO0_SM3_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO0_SM3_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO0_SM3_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO0_SM3_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO0_SM3_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO0_SM3_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO0_SM3_ADDR_OFFSET, 0x011c 
       @ .equ PIO0_SM3_ADDR_SM3_ADDR [4:0]     
 
    .equ PIO0_SM3_INSTR_OFFSET, 0x0120 
       @ .equ PIO0_SM3_INSTR_SM3_INSTR [15:0]     
 
    .equ PIO0_SM3_PINCTRL_OFFSET, 0x0124 
       @ .equ PIO0_SM3_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO0_SM3_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO0_SM3_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO0_SM3_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO0_SM3_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO0_SM3_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO0_SM3_PINCTRL_OUT_BASE [4:0]     
 
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
       @ .equ PIO1_CTRL_CLKDIV_RESTART [11:8]     
       @ .equ PIO1_CTRL_SM_RESTART [7:4]     
       @ .equ PIO1_CTRL_SM_ENABLE [3:0]     
 
    .equ PIO1_FSTAT_OFFSET, 0x0004 
       @ .equ PIO1_FSTAT_TXEMPTY [27:24]     
       @ .equ PIO1_FSTAT_TXFULL [19:16]     
       @ .equ PIO1_FSTAT_RXEMPTY [11:8]     
       @ .equ PIO1_FSTAT_RXFULL [3:0]     
 
    .equ PIO1_FDEBUG_OFFSET, 0x0008 
       @ .equ PIO1_FDEBUG_TXSTALL [27:24]     
       @ .equ PIO1_FDEBUG_TXOVER [19:16]     
       @ .equ PIO1_FDEBUG_RXUNDER [11:8]     
       @ .equ PIO1_FDEBUG_RXSTALL [3:0]     
 
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
       @ .equ PIO1_DBG_CFGINFO_IMEM_SIZE [21:16]     
       @ .equ PIO1_DBG_CFGINFO_SM_COUNT [11:8]     
       @ .equ PIO1_DBG_CFGINFO_FIFO_DEPTH [5:0]     
 
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
       @ .equ PIO1_SM0_CLKDIV_INT [31:16]     
       @ .equ PIO1_SM0_CLKDIV_FRAC [15:8]     
 
    .equ PIO1_SM0_EXECCTRL_OFFSET, 0x00cc 
       @ .equ PIO1_SM0_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO1_SM0_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO1_SM0_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO1_SM0_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO1_SM0_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO1_SM0_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO1_SM0_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO1_SM0_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO1_SM0_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO1_SM0_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO1_SM0_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO1_SM0_SHIFTCTRL_OFFSET, 0x00d0 
       @ .equ PIO1_SM0_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO1_SM0_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO1_SM0_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO1_SM0_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO1_SM0_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO1_SM0_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO1_SM0_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO1_SM0_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO1_SM0_ADDR_OFFSET, 0x00d4 
       @ .equ PIO1_SM0_ADDR_SM0_ADDR [4:0]     
 
    .equ PIO1_SM0_INSTR_OFFSET, 0x00d8 
       @ .equ PIO1_SM0_INSTR_SM0_INSTR [15:0]     
 
    .equ PIO1_SM0_PINCTRL_OFFSET, 0x00dc 
       @ .equ PIO1_SM0_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO1_SM0_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO1_SM0_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO1_SM0_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO1_SM0_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO1_SM0_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO1_SM0_PINCTRL_OUT_BASE [4:0]     
 
    .equ PIO1_SM1_CLKDIV_OFFSET, 0x00e0 
       @ .equ PIO1_SM1_CLKDIV_INT [31:16]     
       @ .equ PIO1_SM1_CLKDIV_FRAC [15:8]     
 
    .equ PIO1_SM1_EXECCTRL_OFFSET, 0x00e4 
       @ .equ PIO1_SM1_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO1_SM1_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO1_SM1_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO1_SM1_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO1_SM1_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO1_SM1_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO1_SM1_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO1_SM1_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO1_SM1_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO1_SM1_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO1_SM1_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO1_SM1_SHIFTCTRL_OFFSET, 0x00e8 
       @ .equ PIO1_SM1_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO1_SM1_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO1_SM1_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO1_SM1_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO1_SM1_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO1_SM1_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO1_SM1_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO1_SM1_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO1_SM1_ADDR_OFFSET, 0x00ec 
       @ .equ PIO1_SM1_ADDR_SM1_ADDR [4:0]     
 
    .equ PIO1_SM1_INSTR_OFFSET, 0x00f0 
       @ .equ PIO1_SM1_INSTR_SM1_INSTR [15:0]     
 
    .equ PIO1_SM1_PINCTRL_OFFSET, 0x00f4 
       @ .equ PIO1_SM1_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO1_SM1_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO1_SM1_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO1_SM1_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO1_SM1_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO1_SM1_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO1_SM1_PINCTRL_OUT_BASE [4:0]     
 
    .equ PIO1_SM2_CLKDIV_OFFSET, 0x00f8 
       @ .equ PIO1_SM2_CLKDIV_INT [31:16]     
       @ .equ PIO1_SM2_CLKDIV_FRAC [15:8]     
 
    .equ PIO1_SM2_EXECCTRL_OFFSET, 0x00fc 
       @ .equ PIO1_SM2_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO1_SM2_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO1_SM2_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO1_SM2_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO1_SM2_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO1_SM2_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO1_SM2_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO1_SM2_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO1_SM2_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO1_SM2_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO1_SM2_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO1_SM2_SHIFTCTRL_OFFSET, 0x0100 
       @ .equ PIO1_SM2_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO1_SM2_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO1_SM2_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO1_SM2_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO1_SM2_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO1_SM2_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO1_SM2_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO1_SM2_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO1_SM2_ADDR_OFFSET, 0x0104 
       @ .equ PIO1_SM2_ADDR_SM2_ADDR [4:0]     
 
    .equ PIO1_SM2_INSTR_OFFSET, 0x0108 
       @ .equ PIO1_SM2_INSTR_SM2_INSTR [15:0]     
 
    .equ PIO1_SM2_PINCTRL_OFFSET, 0x010c 
       @ .equ PIO1_SM2_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO1_SM2_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO1_SM2_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO1_SM2_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO1_SM2_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO1_SM2_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO1_SM2_PINCTRL_OUT_BASE [4:0]     
 
    .equ PIO1_SM3_CLKDIV_OFFSET, 0x0110 
       @ .equ PIO1_SM3_CLKDIV_INT [31:16]     
       @ .equ PIO1_SM3_CLKDIV_FRAC [15:8]     
 
    .equ PIO1_SM3_EXECCTRL_OFFSET, 0x0114 
       @ .equ PIO1_SM3_EXECCTRL_EXEC_STALLED [31:31]     
       @ .equ PIO1_SM3_EXECCTRL_SIDE_EN [30:30]     
       @ .equ PIO1_SM3_EXECCTRL_SIDE_PINDIR [29:29]     
       @ .equ PIO1_SM3_EXECCTRL_JMP_PIN [28:24]     
       @ .equ PIO1_SM3_EXECCTRL_OUT_EN_SEL [23:19]     
       @ .equ PIO1_SM3_EXECCTRL_INLINE_OUT_EN [18:18]     
       @ .equ PIO1_SM3_EXECCTRL_OUT_STICKY [17:17]     
       @ .equ PIO1_SM3_EXECCTRL_WRAP_TOP [16:12]     
       @ .equ PIO1_SM3_EXECCTRL_WRAP_BOTTOM [11:7]     
       @ .equ PIO1_SM3_EXECCTRL_STATUS_SEL [4:4]     
       @ .equ PIO1_SM3_EXECCTRL_STATUS_N [3:0]     
 
    .equ PIO1_SM3_SHIFTCTRL_OFFSET, 0x0118 
       @ .equ PIO1_SM3_SHIFTCTRL_FJOIN_RX [31:31]     
       @ .equ PIO1_SM3_SHIFTCTRL_FJOIN_TX [30:30]     
       @ .equ PIO1_SM3_SHIFTCTRL_PULL_THRESH [29:25]     
       @ .equ PIO1_SM3_SHIFTCTRL_PUSH_THRESH [24:20]     
       @ .equ PIO1_SM3_SHIFTCTRL_OUT_SHIFTDIR [19:19]     
       @ .equ PIO1_SM3_SHIFTCTRL_IN_SHIFTDIR [18:18]     
       @ .equ PIO1_SM3_SHIFTCTRL_AUTOPULL [17:17]     
       @ .equ PIO1_SM3_SHIFTCTRL_AUTOPUSH [16:16]     
 
    .equ PIO1_SM3_ADDR_OFFSET, 0x011c 
       @ .equ PIO1_SM3_ADDR_SM3_ADDR [4:0]     
 
    .equ PIO1_SM3_INSTR_OFFSET, 0x0120 
       @ .equ PIO1_SM3_INSTR_SM3_INSTR [15:0]     
 
    .equ PIO1_SM3_PINCTRL_OFFSET, 0x0124 
       @ .equ PIO1_SM3_PINCTRL_SIDESET_COUNT [31:29]     
       @ .equ PIO1_SM3_PINCTRL_SET_COUNT [28:26]     
       @ .equ PIO1_SM3_PINCTRL_OUT_COUNT [25:20]     
       @ .equ PIO1_SM3_PINCTRL_IN_BASE [19:15]     
       @ .equ PIO1_SM3_PINCTRL_SIDESET_BASE [14:10]     
       @ .equ PIO1_SM3_PINCTRL_SET_BASE [9:5]     
       @ .equ PIO1_SM3_PINCTRL_OUT_BASE [4:0]     
 
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
       @ .equ SIO_GPIO_IN_GPIO_IN [29:0]     
 
    .equ SIO_GPIO_HI_IN_OFFSET, 0x0008 
       @ .equ SIO_GPIO_HI_IN_GPIO_HI_IN [5:0]     
 
    .equ SIO_GPIO_OUT_OFFSET, 0x0010 
       @ .equ SIO_GPIO_OUT_GPIO_OUT [29:0]     
 
    .equ SIO_GPIO_OUT_SET_OFFSET, 0x0014 
       @ .equ SIO_GPIO_OUT_SET_GPIO_OUT_SET [29:0]     
 
    .equ SIO_GPIO_OUT_CLR_OFFSET, 0x0018 
       @ .equ SIO_GPIO_OUT_CLR_GPIO_OUT_CLR [29:0]     
 
    .equ SIO_GPIO_OUT_XOR_OFFSET, 0x001c 
       @ .equ SIO_GPIO_OUT_XOR_GPIO_OUT_XOR [29:0]     
 
    .equ SIO_GPIO_OE_OFFSET, 0x0020 
       @ .equ SIO_GPIO_OE_GPIO_OE [29:0]     
 
    .equ SIO_GPIO_OE_SET_OFFSET, 0x0024 
       @ .equ SIO_GPIO_OE_SET_GPIO_OE_SET [29:0]     
 
    .equ SIO_GPIO_OE_CLR_OFFSET, 0x0028 
       @ .equ SIO_GPIO_OE_CLR_GPIO_OE_CLR [29:0]     
 
    .equ SIO_GPIO_OE_XOR_OFFSET, 0x002c 
       @ .equ SIO_GPIO_OE_XOR_GPIO_OE_XOR [29:0]     
 
    .equ SIO_GPIO_HI_OUT_OFFSET, 0x0030 
       @ .equ SIO_GPIO_HI_OUT_GPIO_HI_OUT [5:0]     
 
    .equ SIO_GPIO_HI_OUT_SET_OFFSET, 0x0034 
       @ .equ SIO_GPIO_HI_OUT_SET_GPIO_HI_OUT_SET [5:0]     
 
    .equ SIO_GPIO_HI_OUT_CLR_OFFSET, 0x0038 
       @ .equ SIO_GPIO_HI_OUT_CLR_GPIO_HI_OUT_CLR [5:0]     
 
    .equ SIO_GPIO_HI_OUT_XOR_OFFSET, 0x003c 
       @ .equ SIO_GPIO_HI_OUT_XOR_GPIO_HI_OUT_XOR [5:0]     
 
    .equ SIO_GPIO_HI_OE_OFFSET, 0x0040 
       @ .equ SIO_GPIO_HI_OE_GPIO_HI_OE [5:0]     
 
    .equ SIO_GPIO_HI_OE_SET_OFFSET, 0x0044 
       @ .equ SIO_GPIO_HI_OE_SET_GPIO_HI_OE_SET [5:0]     
 
    .equ SIO_GPIO_HI_OE_CLR_OFFSET, 0x0048 
       @ .equ SIO_GPIO_HI_OE_CLR_GPIO_HI_OE_CLR [5:0]     
 
    .equ SIO_GPIO_HI_OE_XOR_OFFSET, 0x004c 
       @ .equ SIO_GPIO_HI_OE_XOR_GPIO_HI_OE_XOR [5:0]     
 
    .equ SIO_FIFO_ST_OFFSET, 0x0050 
       @ .equ SIO_FIFO_ST_ROE [3:3]     
       @ .equ SIO_FIFO_ST_WOF [2:2]     
       @ .equ SIO_FIFO_ST_RDY [1:1]     
       @ .equ SIO_FIFO_ST_VLD [0:0]     
 
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
       @ .equ SIO_DIV_CSR_DIRTY [1:1]     
       @ .equ SIO_DIV_CSR_READY [0:0]     
 
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
       @ .equ SIO_INTERP0_CTRL_LANE0_OVERF [25:25]     
       @ .equ SIO_INTERP0_CTRL_LANE0_OVERF1 [24:24]     
       @ .equ SIO_INTERP0_CTRL_LANE0_OVERF0 [23:23]     
       @ .equ SIO_INTERP0_CTRL_LANE0_BLEND [21:21]     
       @ .equ SIO_INTERP0_CTRL_LANE0_FORCE_MSB [20:19]     
       @ .equ SIO_INTERP0_CTRL_LANE0_ADD_RAW [18:18]     
       @ .equ SIO_INTERP0_CTRL_LANE0_CROSS_RESULT [17:17]     
       @ .equ SIO_INTERP0_CTRL_LANE0_CROSS_INPUT [16:16]     
       @ .equ SIO_INTERP0_CTRL_LANE0_SIGNED [15:15]     
       @ .equ SIO_INTERP0_CTRL_LANE0_MASK_MSB [14:10]     
       @ .equ SIO_INTERP0_CTRL_LANE0_MASK_LSB [9:5]     
       @ .equ SIO_INTERP0_CTRL_LANE0_SHIFT [4:0]     
 
    .equ SIO_INTERP0_CTRL_LANE1_OFFSET, 0x00b0 
       @ .equ SIO_INTERP0_CTRL_LANE1_FORCE_MSB [20:19]     
       @ .equ SIO_INTERP0_CTRL_LANE1_ADD_RAW [18:18]     
       @ .equ SIO_INTERP0_CTRL_LANE1_CROSS_RESULT [17:17]     
       @ .equ SIO_INTERP0_CTRL_LANE1_CROSS_INPUT [16:16]     
       @ .equ SIO_INTERP0_CTRL_LANE1_SIGNED [15:15]     
       @ .equ SIO_INTERP0_CTRL_LANE1_MASK_MSB [14:10]     
       @ .equ SIO_INTERP0_CTRL_LANE1_MASK_LSB [9:5]     
       @ .equ SIO_INTERP0_CTRL_LANE1_SHIFT [4:0]     
 
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
       @ .equ SIO_INTERP1_CTRL_LANE0_OVERF [25:25]     
       @ .equ SIO_INTERP1_CTRL_LANE0_OVERF1 [24:24]     
       @ .equ SIO_INTERP1_CTRL_LANE0_OVERF0 [23:23]     
       @ .equ SIO_INTERP1_CTRL_LANE0_CLAMP [22:22]     
       @ .equ SIO_INTERP1_CTRL_LANE0_FORCE_MSB [20:19]     
       @ .equ SIO_INTERP1_CTRL_LANE0_ADD_RAW [18:18]     
       @ .equ SIO_INTERP1_CTRL_LANE0_CROSS_RESULT [17:17]     
       @ .equ SIO_INTERP1_CTRL_LANE0_CROSS_INPUT [16:16]     
       @ .equ SIO_INTERP1_CTRL_LANE0_SIGNED [15:15]     
       @ .equ SIO_INTERP1_CTRL_LANE0_MASK_MSB [14:10]     
       @ .equ SIO_INTERP1_CTRL_LANE0_MASK_LSB [9:5]     
       @ .equ SIO_INTERP1_CTRL_LANE0_SHIFT [4:0]     
 
    .equ SIO_INTERP1_CTRL_LANE1_OFFSET, 0x00f0 
       @ .equ SIO_INTERP1_CTRL_LANE1_FORCE_MSB [20:19]     
       @ .equ SIO_INTERP1_CTRL_LANE1_ADD_RAW [18:18]     
       @ .equ SIO_INTERP1_CTRL_LANE1_CROSS_RESULT [17:17]     
       @ .equ SIO_INTERP1_CTRL_LANE1_CROSS_INPUT [16:16]     
       @ .equ SIO_INTERP1_CTRL_LANE1_SIGNED [15:15]     
       @ .equ SIO_INTERP1_CTRL_LANE1_MASK_MSB [14:10]     
       @ .equ SIO_INTERP1_CTRL_LANE1_MASK_LSB [9:5]     
       @ .equ SIO_INTERP1_CTRL_LANE1_SHIFT [4:0]     
 
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
       @ .equ PPB_SYST_CSR_COUNTFLAG [16:16]     
       @ .equ PPB_SYST_CSR_CLKSOURCE [2:2]     
       @ .equ PPB_SYST_CSR_TICKINT [1:1]     
       @ .equ PPB_SYST_CSR_ENABLE [0:0]     
 
    .equ PPB_SYST_RVR_OFFSET, 0xe014 
       @ .equ PPB_SYST_RVR_RELOAD [23:0]     
 
    .equ PPB_SYST_CVR_OFFSET, 0xe018 
       @ .equ PPB_SYST_CVR_CURRENT [23:0]     
 
    .equ PPB_SYST_CALIB_OFFSET, 0xe01c 
       @ .equ PPB_SYST_CALIB_NOREF [31:31]     
       @ .equ PPB_SYST_CALIB_SKEW [30:30]     
       @ .equ PPB_SYST_CALIB_TENMS [23:0]     
 
    .equ PPB_NVIC_ISER_OFFSET, 0xe100 
       @ .equ PPB_NVIC_ISER_SETENA [31:0]     
 
    .equ PPB_NVIC_ICER_OFFSET, 0xe180 
       @ .equ PPB_NVIC_ICER_CLRENA [31:0]     
 
    .equ PPB_NVIC_ISPR_OFFSET, 0xe200 
       @ .equ PPB_NVIC_ISPR_SETPEND [31:0]     
 
    .equ PPB_NVIC_ICPR_OFFSET, 0xe280 
       @ .equ PPB_NVIC_ICPR_CLRPEND [31:0]     
 
    .equ PPB_NVIC_IPR0_OFFSET, 0xe400 
       @ .equ PPB_NVIC_IPR0_IP_3 [31:30]     
       @ .equ PPB_NVIC_IPR0_IP_2 [23:22]     
       @ .equ PPB_NVIC_IPR0_IP_1 [15:14]     
       @ .equ PPB_NVIC_IPR0_IP_0 [7:6]     
 
    .equ PPB_NVIC_IPR1_OFFSET, 0xe404 
       @ .equ PPB_NVIC_IPR1_IP_7 [31:30]     
       @ .equ PPB_NVIC_IPR1_IP_6 [23:22]     
       @ .equ PPB_NVIC_IPR1_IP_5 [15:14]     
       @ .equ PPB_NVIC_IPR1_IP_4 [7:6]     
 
    .equ PPB_NVIC_IPR2_OFFSET, 0xe408 
       @ .equ PPB_NVIC_IPR2_IP_11 [31:30]     
       @ .equ PPB_NVIC_IPR2_IP_10 [23:22]     
       @ .equ PPB_NVIC_IPR2_IP_9 [15:14]     
       @ .equ PPB_NVIC_IPR2_IP_8 [7:6]     
 
    .equ PPB_NVIC_IPR3_OFFSET, 0xe40c 
       @ .equ PPB_NVIC_IPR3_IP_15 [31:30]     
       @ .equ PPB_NVIC_IPR3_IP_14 [23:22]     
       @ .equ PPB_NVIC_IPR3_IP_13 [15:14]     
       @ .equ PPB_NVIC_IPR3_IP_12 [7:6]     
 
    .equ PPB_NVIC_IPR4_OFFSET, 0xe410 
       @ .equ PPB_NVIC_IPR4_IP_19 [31:30]     
       @ .equ PPB_NVIC_IPR4_IP_18 [23:22]     
       @ .equ PPB_NVIC_IPR4_IP_17 [15:14]     
       @ .equ PPB_NVIC_IPR4_IP_16 [7:6]     
 
    .equ PPB_NVIC_IPR5_OFFSET, 0xe414 
       @ .equ PPB_NVIC_IPR5_IP_23 [31:30]     
       @ .equ PPB_NVIC_IPR5_IP_22 [23:22]     
       @ .equ PPB_NVIC_IPR5_IP_21 [15:14]     
       @ .equ PPB_NVIC_IPR5_IP_20 [7:6]     
 
    .equ PPB_NVIC_IPR6_OFFSET, 0xe418 
       @ .equ PPB_NVIC_IPR6_IP_27 [31:30]     
       @ .equ PPB_NVIC_IPR6_IP_26 [23:22]     
       @ .equ PPB_NVIC_IPR6_IP_25 [15:14]     
       @ .equ PPB_NVIC_IPR6_IP_24 [7:6]     
 
    .equ PPB_NVIC_IPR7_OFFSET, 0xe41c 
       @ .equ PPB_NVIC_IPR7_IP_31 [31:30]     
       @ .equ PPB_NVIC_IPR7_IP_30 [23:22]     
       @ .equ PPB_NVIC_IPR7_IP_29 [15:14]     
       @ .equ PPB_NVIC_IPR7_IP_28 [7:6]     
 
    .equ PPB_CPUID_OFFSET, 0xed00 
       @ .equ PPB_CPUID_IMPLEMENTER [31:24]     
       @ .equ PPB_CPUID_VARIANT [23:20]     
       @ .equ PPB_CPUID_ARCHITECTURE [19:16]     
       @ .equ PPB_CPUID_PARTNO [15:4]     
       @ .equ PPB_CPUID_REVISION [3:0]     
 
    .equ PPB_ICSR_OFFSET, 0xed04 
       @ .equ PPB_ICSR_NMIPENDSET [31:31]     
       @ .equ PPB_ICSR_PENDSVSET [28:28]     
       @ .equ PPB_ICSR_PENDSVCLR [27:27]     
       @ .equ PPB_ICSR_PENDSTSET [26:26]     
       @ .equ PPB_ICSR_PENDSTCLR [25:25]     
       @ .equ PPB_ICSR_ISRPREEMPT [23:23]     
       @ .equ PPB_ICSR_ISRPENDING [22:22]     
       @ .equ PPB_ICSR_VECTPENDING [20:12]     
       @ .equ PPB_ICSR_VECTACTIVE [8:0]     
 
    .equ PPB_VTOR_OFFSET, 0xed08 
       @ .equ PPB_VTOR_TBLOFF [31:8]     
 
    .equ PPB_AIRCR_OFFSET, 0xed0c 
       @ .equ PPB_AIRCR_VECTKEY [31:16]     
       @ .equ PPB_AIRCR_ENDIANESS [15:15]     
       @ .equ PPB_AIRCR_SYSRESETREQ [2:2]     
       @ .equ PPB_AIRCR_VECTCLRACTIVE [1:1]     
 
    .equ PPB_SCR_OFFSET, 0xed10 
       @ .equ PPB_SCR_SEVONPEND [4:4]     
       @ .equ PPB_SCR_SLEEPDEEP [2:2]     
       @ .equ PPB_SCR_SLEEPONEXIT [1:1]     
 
    .equ PPB_CCR_OFFSET, 0xed14 
       @ .equ PPB_CCR_STKALIGN [9:9]     
       @ .equ PPB_CCR_UNALIGN_TRP [3:3]     
 
    .equ PPB_SHPR2_OFFSET, 0xed1c 
       @ .equ PPB_SHPR2_PRI_11 [31:30]     
 
    .equ PPB_SHPR3_OFFSET, 0xed20 
       @ .equ PPB_SHPR3_PRI_15 [31:30]     
       @ .equ PPB_SHPR3_PRI_14 [23:22]     
 
    .equ PPB_SHCSR_OFFSET, 0xed24 
       @ .equ PPB_SHCSR_SVCALLPENDED [15:15]     
 
    .equ PPB_MPU_TYPE_OFFSET, 0xed90 
       @ .equ PPB_MPU_TYPE_IREGION [23:16]     
       @ .equ PPB_MPU_TYPE_DREGION [15:8]     
       @ .equ PPB_MPU_TYPE_SEPARATE [0:0]     
 
    .equ PPB_MPU_CTRL_OFFSET, 0xed94 
       @ .equ PPB_MPU_CTRL_PRIVDEFENA [2:2]     
       @ .equ PPB_MPU_CTRL_HFNMIENA [1:1]     
       @ .equ PPB_MPU_CTRL_ENABLE [0:0]     
 
    .equ PPB_MPU_RNR_OFFSET, 0xed98 
       @ .equ PPB_MPU_RNR_REGION [3:0]     
 
    .equ PPB_MPU_RBAR_OFFSET, 0xed9c 
       @ .equ PPB_MPU_RBAR_ADDR [31:8]     
       @ .equ PPB_MPU_RBAR_VALID [4:4]     
       @ .equ PPB_MPU_RBAR_REGION [3:0]     
 
    .equ PPB_MPU_RASR_OFFSET, 0xeda0 
       @ .equ PPB_MPU_RASR_ATTRS [31:16]     
       @ .equ PPB_MPU_RASR_SRD [15:8]     
       @ .equ PPB_MPU_RASR_SIZE [5:1]     
       @ .equ PPB_MPU_RASR_ENABLE [0:0]     
 
